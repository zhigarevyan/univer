$(function(){
	var header = $("#header"),
		introH = $("#intro").innerHeight(),
		scrollOffset = $(window).scrollTop();
	/*fixed header*/
	checkScroll(scrollOffset);
	
	$(window).on("scroll",function(){
		scrollOffset=$(this).scrollTop();
		checkScroll(scrollOffset);
	});
	
	function checkScroll(scrollOffset){
		if(scrollOffset >= introH){
			header.addClass("fixed");
		}
		else{
			header.removeClass("fixed");
		}
	}
	
	
	
	/*scroll */
	$("[data-scroll]").on("click",function(event){
		event.preventDefault();
		var	blockedId = $(this).data('scroll'),
			blockOffset = $(blockedId).offset().top;
		
		$("html, body").animate({
			scrollTop:blockOffset
		},500);
	});
	
	/*nav bar*/
	
	$("#navtoggle").on("click",function(event){
		event.preventDefault();
		
		$("#nav").toggleClass("active");
	});
	
	
	
	
	
});
/*preloader*/
document.body.onload = function(){
	
	setTimeout(function(){
		var preloader = document.getElementById("preloader");
		if(!preloader.classList.contains("done"))
			{
				preloader.classList.add("done");
			}
	},1000);
} 


