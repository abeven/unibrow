test('Have namespace', function() 
{ 
	expect(1);	
	ok(UB != null);
});

test('Have class', function() 
{ 
	expect(1);	
	ok(UB.Log != null);
	
});

test('Sends to recipient', function() 
{ 
	var cfg = {
		recipients:[
			new UB.Recipients.InMemory()
		]
	};
	
	var log = new UB.Log(cfg);
	log.write('hello world');
	
	equals(1, cfg.recipients[0].messages.length);
	equals('hello world', cfg.recipients[0].messages);
	
});