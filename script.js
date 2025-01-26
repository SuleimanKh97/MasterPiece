// تهيئة السلايدر
const swiper = new Swiper('.swiper-container', {
    loop: true, // تكرار الشرائح
    pagination: {
        el: '.swiper-pagination', // نقاط التصفح
        clickable: true,
    },
    navigation: {
        nextEl: '.swiper-button-next', // زر التالي
        prevEl: '.swiper-button-prev', // زر السابق
    },
    autoplay: {
        delay: 5000, // تغيير الشريحة كل 5 ثواني
    },
});