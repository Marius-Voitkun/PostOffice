import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GenericService<T> {

  constructor(
    protected http: HttpClient,
    protected url: string
  ) { }

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(this.url)
      .pipe(
        catchError(this.handleError)
      );
  }

  get(id: number): Observable<T> {
    return this.http.get<T>(`${this.url}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  add(t: T): Observable<T> {
    return this.http.post<T>(this.url, t)
      .pipe(
        catchError(this.handleError)
      );
  }

  update(id: number, t: T): Observable<unknown> {
    return this.http.put(`${this.url}/${id}`, t)
      .pipe(
        catchError(this.handleError)
      );
  }

  delete(id: number): Observable<unknown> {
    return this.http.delete(`${this.url}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    console.log(error);
    return throwError('Error: ' + error.message);
  }
}
