# Description
Middle to redirect response. 

Intended to be used in Development environment and for Applications running in Docker container. The IDP url for the browser can be different than the container uri. 

## Problem
When setting up a local environment using Docker to spin up all the necessary services, the problem was redirect to Identity Provider was running into DNS issue. If the web application was able to fetch the metadata from well-known/openid-configuration endpoint, the user could not be redirect properly. The middleware changes updates the redirect uri to it's appropriate value so the client (browser) can reach the Identity Provider. 

## How to use 
Using environment variables or appsettings.Development.json set the values

```
services.AddRedirect(options => {
    options.RedirectFrom = configurationManager["AUTH:LOCAL:IDP:REDIRECTFROM"] ?? string.Empty;
    options.RedirectTo = configurationManager["AUTH:LOCAL:IDP:REDIRECTTO"] ?? string.Empty;
});
```
