import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductListComponent } from './Product/product-list/product-list.component';
import { ProductDetailsComponent } from './Product/product-details/product-details.component';
import { ContactComponent } from './contact/contact.component';
import { CartComponent } from './cart/cart.component';
import { AuthGuard } from './guard/auth.guard';
import { SellerDashboardComponent } from './seller/seller-dashboard/seller-dashboard.component';
import { AdminDashboardComponent } from './admin/admin-dashboard/admin-dashboard.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { BuyerDashboardComponent } from './buyer/buyer-dashboard/buyer-dashboard.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'shop', component: ProductListComponent },
  { path: 'product/:id', component: ProductDetailsComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'cart', component: CartComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: RegisterComponent },
  { path: 'buyerdashboard', component: BuyerDashboardComponent },

  { path: '', component: SellerDashboardComponent, canActivate: [AuthGuard], data: { roles: ['Seller'] } },
  { path: '', component: AdminDashboardComponent, canActivate: [AuthGuard], data: { roles: ['Admin'] } }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
