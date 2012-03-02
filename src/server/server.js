var express = require('express'),
	app = express.createServer(),
	io = require('socket.io').listen(app);

var allowCors = function(req, res, next) {
    res.header('Access-Control-Allow-Origin', 'http://localhost:8001');
    res.header('Access-Control-Allow-Methods', 'GET,PUT,POST,DELETE');
    res.header('Access-Control-Allow-Headers', 'Content-Type');

    next();
}

app.use(express.static(__dirname + '/public/'));
app.use(express.bodyParser());
app.use(express.methodOverride());	
app.use(express.logger());
app.use(allowCors);


app.get('/', function (req, res) {
  res.sendfile(__dirname + '/index.html');
});

app.post('/log', function (req, res) {

  console.log('end');
  var msg = req.body.entry;
  io.sockets.emit('entry', msg);
  res.send({ok:true});
  
});

io.sockets.on('connection', function (socket) {
  socket.emit('connected', {  });
  
});

console.log('Server started on port 8002');
app.listen(8002);