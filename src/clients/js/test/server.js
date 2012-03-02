var http = require('http');
var fs = require('fs');
var path = require('path');

http.createServer(function (request, response) {

    console.log(request.url + ' [' + request.url + ']');

	var filePath = '.' + request.url;
	if (filePath == './')
		filePath = './index.html';

	var extname = path.extname(filePath);
	var contentType = 'text/html';
	switch (extname) {
		case '.js':
			contentType = 'text/javascript';
			break;
		case '.css':
			contentType = 'text/css';
			break;
		case '.ttf':
			contentType = 'font/truetype';
			break;
		case '.otf':
			contentType = 'font/opentype';
			break;
		case '.png':
			contentType = 'image/png';
			break;
		case '.gif':
			contentType = 'image/gif';
			break;
        case '.apk':
            contentType= 'application/vnd.android.package-archive';
	}

	path.exists(filePath, function(exists) {

		if (exists) {
			fs.readFile(filePath, function(error, content) {
				if (error) {
					response.writeHead(500);
					response.end();
				}
				else {
					response.writeHead(200, { 'Content-Type': contentType });
					response.end(content, 'utf-8');
				}
			});
		}
		else {
			console.log('not found');
			response.writeHead(404);
			response.end();
		}
	});

}).listen(8001);

console.log('Server running at http://127.0.0.1:8001/');