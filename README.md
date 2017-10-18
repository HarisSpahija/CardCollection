# CardCollection

### Cookies

In ASP.NET Core 2.0 and later, the cookie-based TempData provider is used by default to store TempData in cookies.<br>
The cookie data is encoded with the Base64UrlTextEncoder.<br>
Because the cookie is encrypted and chunked, the single cookie size limit found in ASP.NET Core 1.x does not apply.<br>
The cookie data is not compressed because compressing encryped data can lead to security problems such as the CRIME and BREACH attacks. <br>
For more information on the cookie-based TempData provider, see CookieTempDataProvider.<br>
