import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent} from './login/login.component';
import { FormsModule } from '@angular/forms';
import { CoreModule } from '../core/core.module';
import { AuthService } from './shared/auth.service';

const routes: Routes = [
    { path: 'login', component: LoginComponent }
];

@NgModule({
  imports: [
      CoreModule,
      FormsModule,
      RouterModule.forRoot(routes),
  ],
  providers: [AuthService],
  declarations: [LoginComponent],
  exports: [LoginComponent],
})
export class AuthModule {}