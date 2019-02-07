(function () {
	((nav, activeClass, navTrigger) => {
		const trigger = nav.querySelector(navTrigger);

		trigger.addEventListener('click', () => {
			if (nav.classList.contains(activeClass)) {
				nav.classList.remove(activeClass);
			} else {
				nav.classList.add(activeClass);
			}
		});

		function deviceChanged() {
			if (nav.classList.contains(activeClass)) {
				nav.classList.remove(activeClass);
			}
		}

		if (matchMedia) {
			const mobile = window.matchMedia('(max-width: 735px)');
			const tablet = window.matchMedia('(max-width: 1024px)');

			mobile.addListener(deviceChanged);
			tablet.addListener(deviceChanged);
		}
	})(document.querySelector('.navigation-menu'), 'navigation-menu_open', '.navigation-menu__trigger');
}());
