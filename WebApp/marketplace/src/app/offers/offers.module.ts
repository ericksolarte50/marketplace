import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OfferItemComponent } from './offer-item/offer-item.component';
import { OfferCreationComponent } from './offer-creation/offer-creation.component';
import { OfferListComponent } from './offer-list/offer-list.component';
import { ReactiveFormsModule } from '@angular/forms';
import { PaginatorComponent } from './paginator/paginator.component';



@NgModule({
  declarations: [OfferItemComponent, OfferCreationComponent, OfferListComponent, PaginatorComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class OffersModule { }
