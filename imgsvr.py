import cherrypy
from hashids import Hashids
import base64
from os import listdir
from os.path import join
from cherrypy import request

# Simple image server for use with "Custom" in Snap. Requires cherrypy
# and hashids (install with pip). 
# Update the variables below to fit your environment.

OUTPUTDIR = "/home/krisp/public_html/i"
OUTPUTURI = "http://krisp.com/~krisp/i/"
PORT = 9090

class ImgSrv(object):
  @cherrypy.expose
  @cherrypy.tools.json_out()
  @cherrypy.tools.accept(media="application/x-www-form-urlencoded")
  def image(self, **kargs):
   try:
    if(request.params["data"]):
    	imgbytes = base64.b64decode(request.params["data"])
	hashids = Hashids(salt="cool salt brah")
	filename = "%s.png" % (hashids.encode(len(listdir(OUTPUTDIR))))
	with open(join(OUTPUTDIR, filename), "wb") as fd:
	  fd.write(imgbytes);
	
        result = {"data": { "link": OUTPUTURI + filename, "deletehash": "none" }, "result": "success"}
	return result
    else:
        return {"data": {}, "result": "failure"}
   except:
    return {"data": {}, "result": "failure"}

cherrypy.config.update({'server.socket_port': PORT, 'server.socket_host': '0.0.0.0'})
cherrypy.quickstart(ImgSrv())
