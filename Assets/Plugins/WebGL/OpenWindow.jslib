mergeInto(LibraryManager.library, OpenWindowPlugin);

var OpenWindowPlugin = 
{
    openWindow: function(link)
    {
    	var url = Pointer_stringify(link);
        document.onmouseup = function()
        {
        	window.open(url);
        	document.onmouseup = null;
        }
    }
};

mergeInto(LibraryManager.library, 
{

  Hello: function ()  //alerts with a hello world
  {
    window.alert("Hello, world!");
  },

  HelloString: function (str)  //alerts with any string passed by unity
  {
    window.alert(Pointer_stringify(str));
  },

  PrintFloatArray: function (array, size) //prints the float array in console
  {
    for(var i = 0; i < size; i++)
    console.log(HEAPF32[(array >> 2) + i]);
  },

  AddNumbers: function (x, y) //add numbers and return the response
  {
    return x + y;
  },

  StringReturnValueFunction: function () 
  {
    var returnStr = "bla";
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  },

  BindWebGLTexture: function (texture) //not sure what it is
  {
    GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[texture]);
  },

  OpenInNewWindow : function(newUrl)
  {
    setInterval(CheckMouseActive, 10); // Time in milliseconds
    window.mouseOnScreen = true;
    mouseOnScreen = false;
    window.open(newUrl, '_blank');
    document.addEventListener("visibilitychange", ()=> {CheckMouseActive(); console.log("page active - ", mouseOnScreen)});
  },


  CheckMouseActive : function()
  {
    if(mouseOnScreen === false)
    {
        unityInstance.SendMessage('TestingObject', 'MouseOverPage');
        mouseOnScreen = true;
        document.removeEventListener("visibilitychange", ()=> {CheckMouseActive(); console.log("page active - ", mouseOnScreen)});
    }
  }

});