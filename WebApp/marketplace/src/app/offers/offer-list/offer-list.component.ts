import { Component, OnInit } from '@angular/core';
import { MarketplaceApiService } from 'src/app/core/marketplace-api/marketplace-api.service';
import { OfferModel } from 'src/app/core/marketplace-api/models/offer.model';
import { TempPage } from 'src/app/core/models/TempPage.model';

@Component({
  selector: 'app-offer-list',
  templateUrl: './offer-list.component.html',
  styleUrls: ['./offer-list.component.scss']
})
export class OfferListComponent implements OnInit {

  listOffers: OfferModel[] = [];
  listPages: TempPage[] = [];
  pageSize = 10;
  numberPages: number = 0;  
  loadSuccess: boolean = false;

  constructor(private serviceMarcketplace: MarketplaceApiService) {
  }

  ngOnInit(): void {
    this.getListOffers(1);
  }
  
  onRefreshPage(page){
    this.getListOffers(page);
  }

  private getListOffers(pageNumber: number) {
    this.serviceMarcketplace.getOffers(pageNumber, this.pageSize)
      .subscribe({
        next: (result: any) => {  
          console.log(result);

          this.listOffers = result.info;          
          this.numberPages = result.totalPages;          
          this.loadSuccess = true;
        }
        , error: (error) => {
          console.log("error: " + error);
        }
      })
  }


}
