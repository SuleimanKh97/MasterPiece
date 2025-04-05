import { Component } from '@angular/core';
import { AuthService } from '../../Services/auth/auth.service';
import { User } from '../../Models/user.module';

@Component({
  selector: 'app-profile',
  standalone: false,
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {
  user: User | null = null;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    //this.authService.getCurrentUser().subscribe((data: any) => {
    //  this.user = data;
    //});
  }
}
