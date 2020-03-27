mergeInto(LibraryManager.library, OpenPopUpPlugin);

var OpenPopUpPlugin = 
{
    openWindow: function(ques01, option01, option02, option03, option04)
    {
    	//receive question with 4 options

      //update pop up with one header question and 4 answer options
      //on clicking a option, store it's value in an integer
      //on clicking submit, send unity message to unity c# function with the option number of answer
    }//,

    //openPopUp: function ()  //alerts with a hello world
    //{
      //showPopUp();
      //in script.js have defined this to open and close a pop up
    //}
};


  /*CheckMouseActive : function()
  {
    if(mouseOnScreen === false)
    {
        unityInstance.SendMessage('TestingObject', 'MouseOverPage');
        mouseOnScreen = true;
        document.removeEventListener("visibilitychange", ()=> {CheckMouseActive(); console.log("page active - ", mouseOnScreen)});
    }
  }*/
