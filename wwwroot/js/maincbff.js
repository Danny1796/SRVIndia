$(function () {

	$(window).scroll(function () {
		if ($(window).scrollTop() >= 10) {
			$("header").addClass("fix-nav");
		} else {
			$("header").removeClass("fix-nav");
		}
	});

	$(".sub-nav").hover(function () {
		$(this).find(".sub-nav-wrapper").stop(true, true).slideDown(300);
	},
		function () {
			$(this).find(".sub-nav-wrapper").slideUp(150);
		})

	$(".sub-menu").hover(function () {
		$(this).find(".sub-menu-wrapper").stop(true, true).slideDown(300);
	},
		function () {
			$(this).find(".sub-menu-wrapper").slideUp(150);
		})

	$(".mobile-nav-close").click(function () {
		$(".mobile-container").removeClass("open");
		$(".switch-toggle").removeClass("open");
	})

	$(".mobile-container .mask").click(function () {
		$(".mobile-container").removeClass("open");
		$(".switch-toggle").removeClass("open");
	})

	$(".switch-toggle").click(function () {
		$(this).toggleClass("open");
		$(".mobile-container").toggleClass("open");
	})

	$(".expand").click(function () {
		$(this).parent().toggleClass("active");
		$(this).closest('li').find('.son-box').slideToggle();
	})

	$(".triplparent").click(function () {
		$(this).toggleClass("active");
		$(this).closest('li').find('.triple').slideToggle();
	})

	//动画初始
	new WOW().init();

	$('.video-list li').click(function () {
		var videoId = $(this).data('id');
		var lang = $(this).data('lang');
		$(this).toggleClass("active").siblings().removeClass("active");

		$.ajax({
			url: '/video-play.asp',
			type: 'GET',
			data: { id: videoId, lang: lang },
			dataType: 'json',
			success: function (response) {
				$('.play-container iframe').attr('src', response.des1)
				$('.video-sum h3').html(response.des2);
				$('.video-des').html(response.des3);
			},
			error: function () {
				console.error('AJAX 请求失败');
			}
		});
	});


	$(".support-list .support-box").mouseover(function () {
		let _index = $(this).index();
		$(".show-pic .pic img").css({ "opacity": "0", "z-index": "0" });
		$(".show-pic .pic:eq(" + _index + ") img").css({ "opacity": "1", "z-index": "1" });
	});

	$(".business-type-switch li").click(function () {
		let i = $(this).index();
		$(this).addClass("active").siblings().removeClass("active");
		$(".business-type").eq(i).addClass("active").siblings().removeClass("active");
	})


	//关于我们页面动画
	$(".year-item").click(function () {
		var selectedIndex = $(this).index();
		var itemOffsetLeft = $(this).position().left;

		var containerWidth = $(".year-event").width();
		// 每个 events 的宽度（含外边距）
		var eventWidth = $(".events").outerWidth(true);
		// 总内容宽度
		var totalEventWidth = $(".event-wrapper")[0].scrollWidth;

		$(this).addClass("active").siblings().removeClass("active");
		$(".events").eq(selectedIndex).addClass("active").siblings().removeClass("active");

		$(".progress-bar .bar").css({
			"transition": "all 0.3s",
			"left": itemOffsetLeft + "px"
		});

		var targetLeft = -selectedIndex * eventWidth;

		var maxLeft = containerWidth - totalEventWidth;
		if (targetLeft < maxLeft) {
			targetLeft = maxLeft;
		}

		$(".event-wrapper").css("left", targetLeft + "px");
	});


	//模态框弹窗下拉列表
	$(".select-selected").click(function () {
		$(this).next(".select-list").toggleClass("select-show");
	})

	$(".select-option").click(function () {
		$(this).parent().prev().text($(this).text());
		$(this).closest(".input-box").find("input").val($(this).text());
		$(this).parent().toggleClass("select-show");
	})

	$("#enquiry").click(function () {
		if ($("#modal").hasClass("active")) {
			$("#modal").removeClass("active");
		} else {
			$("#modal").addClass("active");
			setTimeout(function () { $("#modal").find(".modal-content").addClass("active"); }, 0);
		}
	})

	$("#modal .close").click(function () {
		$(".modal-content").removeClass("active");
		setTimeout(function () {
			$("#modal").removeClass("active");
		}, 200);
	})

	//产品模态框提交
	$("#modal .submit").click(function () {
		var customerName = $(".customerName").val();
		var company = $(".company").val();
		var whatsapp = $(".whatsapp").val();
		var cargo = $(".cargo").val();
		var business = $(".business").val();
		var message = $(".message").val();
		var product = $("h1").text();
		$.ajax({
			url: "/en3.asp",
			dataType: "html",
			contentType: "application/json;charset=utf-8",
			type: "GET",
			beforeSend: function () {
				if (customerName == "") {
					alert("Please leave us your name");
					$(".customerName").focus();
					return false;
				} else if (whatsapp == "") {
					alert("Please leave us your number");
					$(".whatsapp").focus();
					return false;
				} else if (message == "") {
					alert("Please leave us your message");
					$(".message").focus();
					return false;
				}
			},
			data: {
				"customerName": customerName,
				"company": company,
				"whatsapp": whatsapp,
				"cargo": cargo,
				"business": business,
				"message": message,
				"product": product
			},

			success: function (statuscode) {
				if (statuscode == "200") {
					$(".txt").val("");
					$(".txt2").val("");
					$("#modal").removeClass("active");
					alert("Thanks! We will write you back as soon as possible!");
				} else if (statuscode == "202") {
					alert("We have received your message, please do not submit it again");
				}
			},
			error: function (e) { }
		})
	})

	$("#videomodal .close").click(function () {
		$("#videomodal video").get(0).pause();
		$("#videomodal video").remove();
		$("#videomodal .modal-content").removeClass("active");
		$("#videomodal").removeClass("active");
	})


	$(".single-faq .answer").click(function () {
		var p = $(this).parent();
		if (p.hasClass("active")) {
			p.removeClass("active");
			p.find(".content").slideUp();
		}
		else {
			p.addClass("active");
			p.find(".content").slideDown();
		}
	})

	//产品页面动效
	$(".tab-nav li").click(function () {
		var i = $(this).index();
		$(".product-content .panel").eq(i).addClass("active").siblings().removeClass("active");
	})

	$(".faq dt").click(function () {
		$(this).next().slideToggle();
	})


	$(".review-form-title").click(function () {
		$(".review-form").slideToggle();
	})

	$(".rate-star").on("mousemove", function (e) {
		var t = $(this);
		var currentStar = t.attr("class").split(" ")[1];
		var boxwidth = t.width();
		var mouseX = e.offsetX;
		var rate = Math.round(mouseX / boxwidth * 5) > 1 ? Math.round(mouseX / boxwidth * 5) : 1
		var nextStar = "star-" + rate;
		t.removeClass(currentStar).addClass(nextStar);
		$(".review-rate").val(rate);
	})

	$(".review-submit").click(function () {
		var rwt = $(".review-title").val();
		var rwe = $(".review-email").val();
		var rwr = $(".review-rate").val();
		var rwid = $(".review-id").val();
		var rwc = $(".review-content").val();
		var lang = $(".review-lang").val();
		$.ajax({
			url: "/addReview1.asp",
			dataType: "html",
			contentType: "application/json;charset=utf-8",
			type: "GET",
			beforeSend: function () {
				if (rwt == "") {
					alert("Review title is required");
					$(".review-title").focus();
					return false;
				} else if (rwe == "") {
					alert("E-mail is required");
					$(".review-email").focus();
					return false;
				} else if (rwc == "") {
					alert("Content is required");
					$(".review-content").focus();
					return false;
				}
			},
			data: {
				"rwt": rwt,
				"rwe": rwe,
				"rwr": rwr,
				"rwid": rwid,
				"rwc": rwc,
				"lang": lang
			},
			success: function (e) {
				$(".review-title").val("");
				$(".review-email").val("");
				$(".review-content").val("");
				$(".review-form").slideUp();
				$(".review").html(e)
			},
			error: function (e) { }
		})
	})

	$(".aside-list li").click(function () {
		var i = $(this).index();
		$(this).toggleClass("active").siblings().removeClass("active");
		$(".relate-product").eq(i).addClass("active").siblings().removeClass("active");

	})

	//下载页面动效	
	$(".down-list li").click(function () {
		var category = $(this).data("category");
		var catalogs = $(".file-list li");
		for (i = 0; i < catalogs.length; i++) {
			current = catalogs.eq(i);
			curCategory = current.data("category");
			if (curCategory.includes(category)) {
				current.show();
			} else {
				current.hide();
			}
		}

		$(this).addClass("active").siblings().removeClass("active");
	})


	//联系我们的页面
	$("#contactForm .submit-from").click(function () {
		var customerName = $(".customerName").val();
		var company = $(".company").val();
		var whatsapp = $(".whatsapp").val();
		var email = escape($(".email").val());
		var cargo = $(".cargo").val();
		var business = $(".business").val();
		var message = $(".message").val();

		$.ajax({
			url: "/en3.asp",
			dataType: "html",
			contentType: "application/json;charset=utf-8",
			type: "GET",
			beforeSend: function () {
				if (customerName == "") {
					alert("Please leave us your name");
					$(".customerName").focus();
					return false;
				} else if (email == "") {
					alert("Please leave us your email");
					$(".email").focus();
					return false;
				} else if (message == "") {
					alert("Please leave us your message");
					$(".message").focus();
					return false;
				}
			},
			data: {
				"customerName": customerName,
				"company": company,
				"whatsapp": whatsapp,
				"email": email,
				"cargo": cargo,
				"business": business,
				"message": message
			},

			success: function () {
				alert("Thanks! We will write you back as soon as possible!");
				gtag('set', 'user_data', { 'email': email });
				gtag('event', 'submit_form');
				gtag('event', 'conversion', {
					'send_to': 'AW-653404676/CauLCNeq5JEDEITUyLcC'
				});
			},
			error: function (e) { }
		})
	})


	$('.accept').click(function () {
		var d = new Date();
		d.setTime(d.getTime() + (60 * 60 * 1000));
		var expires = "expires=" + d.toUTCString();
		document.cookie = "GDPR_status=accept;" + expires + ";path=/";
		$(".cookie").slideToggle();
		if ($(window).width() <= 720) {
			$("body").append("<div class='lxdh'><a href='whatsapp://send/?phone=+8617000161888&text=Hello!'>Contact us on WhatsApp</a></div>");
		} else {
			var script = document.createElement("script");
			script.src = "//code.jivosite.com/widget/1w7IVKXsrb";
			document.body.appendChild(script);
		}
		// Google Ads Tag
		(function () {
			var script = document.createElement("script");
			script.async = true;
			script.src = "https://www.googletagmanager.com/gtag/js?id=AW-653404676";
			document.head.appendChild(script);
			window.dataLayer = window.dataLayer || [];
			function gtag() {
				dataLayer.push(arguments);
			}
			gtag('js', new Date());
			gtag('config', 'AW-653404676');
			gtag('config', 'UA-175303594-1');
			gtag('config', 'G-FEKYK485EK');
			window.addEventListener('load',
				function () {
					document.querySelectorAll('[href*="whatsapp"]').forEach(function (e) {
						e.addEventListener('click',
							function () {
								gtag('event', 'conversion', {
									'send_to': 'AW-653404676/HCshCOCHtN4DEITUyLcC'
								});
							});
					});
				});
		})();
	});
	/*
		$('.reject').click(function() {
			$(".cookie").slideToggle();
			if ($(window).width() <= 720) {
				$("body").append("<div class='lxdh'><a href='whatsapp://send/?phone=+8617000161888&text=Hello!'>Contact us on WhatsApp</a></div>");
			} else {
				var script = document.createElement("script");
				script.src = "//code.jivosite.com/widget/1w7IVKXsrb";
				document.body.appendChild(script);
			}
		})*/

})