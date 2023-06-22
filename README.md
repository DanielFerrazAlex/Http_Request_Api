# HttpRequestMessage Class
The HttpRequestMessage class contains headers, the HTTP verb, and potentially data. This class is commonly used by developers who need additional control over HTTP requests. Common examples include the following:
To examine the underlying SSL/TLS transport information.
To use a less-common HTTP method.
To explicitly set request properties on the HttpRequestMessage.
In these cases, an app uses one of the HttpRequestMessage constructors to create an HttpRequestMessage instance. The app sets various properties on the HttpRequestMessage as needed. Then the HttpRequestMessage is passed as a parameter to one of the HttpClient.SendRequestAsync methods.
A number of convenience methods on the HttpClient class automatically create an HttpRequestMessage object for the app. These methods include the following:
DeleteAsync.
The GetAsync methods.
GetBufferAsync.
GetInputStreamAsync.
GetStringAsync.
PostAsync.
PutAsync.
Any filters that you add to the filter pipeline will be passed the HttpRequestMessage object whether it was explicitly specified by the app or was automatically constructed for you.
