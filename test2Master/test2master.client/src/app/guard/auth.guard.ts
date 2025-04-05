//import { CanActivateFn } from '@angular/router';
//import { Injectable } from '@angular/core';
//import { CanActivate, Router } from '@angular/router';
//import { AuthService } from '../Services/auth/auth.service';

//export class AuthGuard implements CanActivate {
//  constructor(private authService: AuthService, private router: Router) { }

//  canActivate(): boolean {
//    if (!this.authService.isAuthenticated()) {
//      this.router.navigate(['/login']);
//      return false;
//    }
//    return true;
//  }
//}
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(private router: Router) { }

  canActivate(): boolean {
    const token = localStorage.getItem('token');
    if (!token) {
      this.router.navigate(['/login']);
      return false;
    }
    return true;
  }
}
