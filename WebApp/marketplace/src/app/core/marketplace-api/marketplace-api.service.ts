import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { OfferModel } from './models/offer.model';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MarketplaceApiService {

  private readonly marketplaceApUrl = 'https://localhost:44313';

  constructor(private http: HttpClient) { }

  getOffers(page: number, pageSize: number): Observable<OfferModel[]> {
    // TODO: implement the logic to retrieve paginated offers from the service
    const url = `${this.marketplaceApUrl}/OffersPagination`;
    let params = new HttpParams();
    params = params.append('PageNumber', page.toString());
    params = params.append('PageSize', pageSize.toString());
    //return this.http.get(url, { params }).pipe((resp: any) => resp);
    return this.http.get<OfferModel[]>(url, { params });
  }

  postOffer(): Observable<string> {
    // TODO: implement the logic to post a new offer, also validate whatever you consider before posting
    return of('');
  }

  getCategories(): Observable<string[]> {
    // TODO: implement the logic to retrieve the categories from the service
    return of([]);
  }
}
