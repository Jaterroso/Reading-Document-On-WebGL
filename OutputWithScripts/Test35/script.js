$(window).load(function () 
{
	//clicking on webGL will show the pop up
	//$(".webgl-content").click(function(){
	//   $('.hover_bkgr_fricc').show();
	//});

	//clicking on pop up will hide po up
	$('.hover_bkgr_fricc').click(function()
	{
		$('.hover_bkgr_fricc').hide();
		console.log("gameInstance: ", gameInstance);

		gameInstance.SendMessage('TestingObject', 'ResetTimer');
	});

	//clicking on 'x' button of pop up will hide the pop up
	$('.popupCloseButton').click(function()
	{
		$('.hover_bkgr_fricc').hide();
		console.log("gameInstance: ", gameInstance);
		gameInstance.SendMessage('TestingObject', 'ResetTimer');
	});
});


//$(window).showPopUp: function ()  //shows the pop up
//{
//	$('.hover_bkgr_fricc').show();
//},

function showPopUp()
{
	$('.hover_bkgr_fricc').show();
}


var browserPrefixes = ['moz', 'ms', 'o', 'webkit'];

// get the correct attribute name
function getHiddenPropertyName(prefix) {
  return (prefix ? prefix + 'Hidden' : 'hidden');
}

// get the correct event name
function getVisibilityEvent(prefix) {
  return (prefix ? prefix : '') + 'visibilitychange';
}

// get current browser vendor prefix
function getBrowserPrefix() {
  for (var i = 0; i < browserPrefixes.length; i++) {
    if(getHiddenPropertyName(browserPrefixes[i]) in document) {
      // return vendor prefix
      return browserPrefixes[i];
    }
  }

  // no vendor prefix needed
  return null;
}

// bind and handle events
var browserPrefix = getBrowserPrefix();

function handleVisibilityChange() {
  if(document[getHiddenPropertyName(browserPrefix )]) 
  {
    // the page is hidden
    gameInstance.SendMessage('TestingObject', 'PageIsNotFocused');
    console.log('hidden');
  } 
  else 
  {
    // the page is visible
    gameInstance.SendMessage('TestingObject', 'PageIsFocused');
    console.log('visible');
  }
}

document.addEventListener(getVisibilityEvent(browserPrefix), handleVisibilityChange, false);