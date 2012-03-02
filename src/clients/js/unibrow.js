UB = {};
UB.Recipients = {};
UB.Sources = {};
UB.Subjects = {};

UB.Log = Class({
	init: function(cfg) {
		this.cfg = cfg;
		this.cfg.source = cfg.source || function() { return window.location; };
		this.cfg.subject = cfg.subject || {};
		this.recipients = cfg.recipients || [];
	},
	write: function(entry) {
		if(typeof entry == 'string') {
			entry = this.createEntry(entry);
		}
		this.recipients.forEach(function(r) { 
			r.receive(entry);
		});
	},
	createEntry: function(message) {	
		if(_.isString(message)) {
			return {
				source:message.source || ( _.isFunction(this.cfg.source) ? this.cfg.source() : this.cfg.source.get()),
				subject:message.subject || (_.isFunction(this.cfg.subject) ? this.cfg.subject() : this.cfg.subject.get()),
				ts: new Date().getTime(),
				message:message
			};
		}
		message.ts = new Date().getTime();
		return message;
	}
	
	
});

UB.Recipients.Recipient = Class({
	receive: function(entry)  { }
});

UB.Recipients.Console = UB.Recipients.Recipient.extend(
{
	receive: function(entry) {
		console.log(entry.message);
	}
});

UB.Recipients.InMemory = UB.Recipients.Recipient.extend({
	init: function() {
		this.messages = [];
	},
	receive: function(entry) { 
		this.messages.push(entry);
	}
});

UB.Recipients.Server = UB.Recipients.Recipient.extend({
	init: function(cfg) {
		this.cfg = cfg;
	},
	receive: function(entry) {
		var data = new FormData();
		var xhr = new XMLHttpRequest();
		
		data.append("entry", JSON.stringify(entry));		
		xhr.open("POST", this.cfg.url);
		xhr.send(data);
	}
});

UB.Subjects.Subject = Class( {
	get: function() { }
});

UB.Subjects.Element = UB.Subjects.Subject.extend( {
	id: '',
	key: '',
	init: function(id,key) {
		this.id = id;
		this.key = key || id;
	},
	get: function() { 
		var e = document.getElementById(this.id);
		var v = e ? e.value : '<undefined>';
		var r = {};
		r[this.key] = v;
		return r;
	}
});

UB.Sources.Source = Class({
	get: function() { }
});

UB.Sources.Location = UB.Sources.Source.extend( {
	get: function() { return window.location.href; }
});



