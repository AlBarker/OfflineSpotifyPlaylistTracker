import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'OfflineSpotifyPlaylistTracker.UI';
  public tracks : any;
  constructor(private http: HttpClient, public sanitizer: DomSanitizer) {
    this.http.get('https://localhost:7234/Track').subscribe((res) => this.tracks = res);
  }
}
