import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  featuredProducts = [
    {
      id: 1,
      name: 'Halal Beef Steak',
      description: 'Premium quality halal beef steak, perfect for grilling.',
      price: 29.99,
      discountPrice: 24.99,
      image: 'assets/products/beef-steak.jpg',
      rating: 4.8,
      reviews: 124,
      category: 'Food'
    },
    {
      id: 2,
      name: 'Organic Honey',
      description: 'Pure organic honey from ethically raised bees.',
      price: 18.99,
      discountPrice: null,
      image: 'assets/products/honey.jpg',
      rating: 4.7,
      reviews: 86,
      category: 'Food'
    },
    {
      id: 3,
      name: 'Halal Chicken Nuggets',
      description: 'Crispy halal chicken nuggets, ready to cook.',
      price: 14.99,
      discountPrice: 12.99,
      image: 'assets/products/chicken-nuggets.jpg',
      rating: 4.5,
      reviews: 62,
      category: 'Food'
    },
    {
      id: 4,
      name: 'Natural Rose Water',
      description: 'Pure rose water for cooking and beauty purposes.',
      price: 9.99,
      discountPrice: null,
      image: 'assets/products/rose-water.jpg',
      rating: 4.9,
      reviews: 42,
      category: 'Beauty'
    }
  ];

  bestSellerProducts = [
    {
      id: 5,
      name: 'Halal Lamb Chops',
      description: 'Premium quality halal lamb chops.',
      price: 39.99,
      discountPrice: 34.99,
      image: 'assets/products/lamb-chops.jpg',
      rating: 4.7,
      reviews: 95,
      category: 'Food'
    },
    {
      id: 6,
      name: 'Dates Gift Box',
      description: 'Premium selection of dates in an elegant gift box.',
      price: 24.99,
      discountPrice: null,
      image: 'assets/products/dates.jpg',
      rating: 4.9,
      reviews: 118,
      category: 'Food'
    },
    {
      id: 7,
      name: 'Halal Multivitamins',
      description: 'Halal certified daily multivitamins for adults.',
      price: 19.99,
      discountPrice: 17.99,
      image: 'assets/products/multivitamins.jpg',
      rating: 4.6,
      reviews: 73,
      category: 'Health'
    },
    {
      id: 8,
      name: 'Natural Olive Oil',
      description: 'Premium cold-pressed olive oil from organic farms.',
      price: 15.99,
      discountPrice: null,
      image: 'assets/products/olive-oil.jpg',
      rating: 4.8,
      reviews: 91,
      category: 'Food'
    }
  ];

  newArrivals = [
    {
      id: 9,
      name: 'Halal Gummy Vitamins',
      description: 'Kids\' halal gummy vitamins with no gelatin.',
      price: 16.99,
      discountPrice: null,
      image: 'assets/products/gummy-vitamins.jpg',
      rating: 4.5,
      reviews: 42,
      category: 'Health'
    },
    {
      id: 10,
      name: 'Prayer Rug',
      description: 'Elegant and comfortable prayer rug for daily prayers.',
      price: 29.99,
      discountPrice: 24.99,
      image: 'assets/products/prayer-rug.jpg',
      rating: 4.9,
      reviews: 37,
      category: 'Home'
    },
    {
      id: 11,
      name: 'Halal Marshmallows',
      description: 'Gelatin-free halal marshmallows for snacking and baking.',
      price: 7.99,
      discountPrice: null,
      image: 'assets/products/marshmallows.jpg',
      rating: 4.7,
      reviews: 28,
      category: 'Food'
    },
    {
      id: 12,
      name: 'Halal Hand Cream',
      description: 'Moisturizing hand cream with natural ingredients.',
      price: 12.99,
      discountPrice: 10.99,
      image: 'assets/products/hand-cream.jpg',
      rating: 4.8,
      reviews: 19,
      category: 'Beauty'
    }
  ];

  categories = [
    {
      id: 1,
      name: 'Food & Beverages',
      image: 'assets/categories/food.jpg',
      count: 245
    },
    {
      id: 2,
      name: 'Beauty & Personal Care',
      image: 'assets/categories/beauty.jpg',
      count: 184
    },
    {
      id: 3,
      name: 'Health & Wellness',
      image: 'assets/categories/health.jpg',
      count: 126
    },
    {
      id: 4,
      name: 'Clothing & Accessories',
      image: 'assets/categories/clothing.jpg',
      count: 98
    },
    {
      id: 5,
      name: 'Home & Kitchen',
      image: 'assets/categories/home.jpg',
      count: 157
    },
    {
      id: 6,
      name: 'Books & Media',
      image: 'assets/categories/books.jpg',
      count: 72
    }
  ];

  mainSlides = [
    {
      id: 1,
      title: 'Premium Halal Products',
      subtitle: 'Certified & Authentic',
      image: 'assets/slides/slide1.jpg',
      buttonText: 'Shop Now',
      buttonLink: '/products'
    },
    {
      id: 2,
      title: 'Ramadan Special',
      subtitle: 'Up to 50% Off',
      image: 'assets/slides/slide2.jpg',
      buttonText: 'View Offers',
      buttonLink: '/products'
    },
    {
      id: 3,
      title: 'New Arrivals',
      subtitle: 'Fresh & Exclusive Products',
      image: 'assets/slides/slide3.jpg',
      buttonText: 'Discover Now',
      buttonLink: '/products'
    }
  ];

  partners = [
    {
      id: 1,
      name: 'Halal Certification Authority',
      logo: 'assets/partners/hca.png'
    },
    {
      id: 2,
      name: 'Global Halal Alliance',
      logo: 'assets/partners/gha.png'
    },
    {
      id: 3,
      name: 'Islamic Food Council',
      logo: 'assets/partners/ifc.png'
    },
    {
      id: 4,
      name: 'Halal Quality Control',
      logo: 'assets/partners/hqc.png'
    },
    {
      id: 5,
      name: 'International Halal Integrity',
      logo: 'assets/partners/ihi.png'
    }
  ];

  currentSlide = 0;

  prevSlide() {
    this.currentSlide = this.currentSlide === 0 ? this.mainSlides.length - 1 : this.currentSlide - 1;
  }

  nextSlide() {
    this.currentSlide = this.currentSlide === this.mainSlides.length - 1 ? 0 : this.currentSlide + 1;
  }

  goToSlide(index: number) {
    this.currentSlide = index;
  }

  addToCart(product: any) {
    console.log('Added to cart:', product);
    // Cart logic would be implemented here
  }

  addToWishlist(product: any) {
    console.log('Added to wishlist:', product);
    // Wishlist logic would be implemented here
  }
}
