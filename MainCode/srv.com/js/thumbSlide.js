(function($) {
	var n = function() {
		var n = this;

		n.init = function(t) {
			this.ele = t; //$(this)对象
			this.slideList = this.ele.find(".slideList");
			this.imgList = this.slideList.find("li");
			this.boxWidth = this.ele.width();
			this.itemWidth;
			this.setup();
			return this;
		};

		n.setup = function() {
			var slideList = this.slideList;
			var imgList = this.imgList;
			var boxWidth = this.boxWidth;
			var thumbList = $("<ul class='thumbList'></ul>");
			var overlay = $("<div class='overlay'></div>");
			this.ele.css("overflow", "hidden");

			slideList.css({
				"position": "relative",
				"height": boxWidth,
				"margin-bottom": "20px"
			});
			for (i = 0; i < imgList.length; i++) {
				var item = {};
				item = imgList.eq(i);
				if (i == 0) item.addClass("active");
				item.clone().appendTo(thumbList);
				item.width(item.width() > boxWidth ? boxWidth : item.width());
				item.height(item.width() > boxWidth ? boxWidth : item.width());
				this.itemWidth = item.width()
				item.css({
					"position": "absolute",
					"left": this.itemWidth * i
				});

			};

			overlay.css({
				"position": "absolute",
				"top": "0",
				"left": "0",
				"overflow": "hidden",
				"width": boxWidth,
				"height": boxWidth,
				"z-index": "9",
				"opacity": "0"
			});			
			
			thumbList.appendTo(this.ele);
			overlay.appendTo(this.ele);

			$(".thumbList li").on("click", function () {
				i = $(this).index();
				c = $(this).attr("id");
				src=$(this).data("src");
				if (c === '' || c === null || c === undefined) {
					$(this).addClass("active").siblings().removeClass("active");
					$(".slideList").css({
						"transform": "translateX(-" + i * boxWidth + "px)",
						"transition": "all 0.5s"
					})
				}
				else {
					$("#videomodal .modal-content").append("<video controls autoplay src="+src+">Your browser does not support video playback</video>");	
					$("#videomodal").addClass("active");	
					$("#videomodal .modal-content").addClass("active");					
				}
			});

		}
	};

	$.fn.thumbSlide = function() {
		return this.each(function() {
			var thumbSlide = (new n).init($(this));
		})
	}
})(jQuery);