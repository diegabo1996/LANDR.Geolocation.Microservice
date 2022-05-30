LANDR Geolocation Service
-------------------------

LANDR Geolocation Service is a Microservice that could help you providing geo-information about IP's for your apps.

This can show you information as:

![image](https://user-images.githubusercontent.com/58711247/171029742-bc195603-cd3f-4f43-a16f-9e3324ec445d.png)

LANDR Location Service provides you of three end points for request:

![image](https://user-images.githubusercontent.com/58711247/171030048-e151a665-f8a4-4098-a62d-ac613cf442c7.png)

1. [GET] api/IPGeolocator
   
   Provides you information about the current client IP, just invoke the request and enjoy!
   
   https://geoservice.reddune-9da46cea.eastus.azurecontainerapps.io/api/IPGeolocator/

2. [POST] api/IPGeolocator

   Provides you information about a list of IP's, you have to pass the IP's in a JSON body with a string array.
   For Example:
   
   [
      "200.105.212.44",
      "64.233.190.94",
      "157.240.204.35"
  ]
3. [GET] /api/IPGeolocator/{IP}
  
  Provides you information about a certain  IP, for request just replace {IP} for the IP you want to get geo-information.
  For Example:
  
  https://geoservice.reddune-9da46cea.eastus.azurecontainerapps.io/api/IPGeolocator/157.240.204.35
  

Considerations
---------------

LANDR Location Service works with MaxMind GeoIPv2 thats why you need to get an AccountId and LicenseKey and replace this information in appsettings.json file:

![image](https://user-images.githubusercontent.com/58711247/171032215-add96b17-317a-443d-a8f5-e5de9baa3bca.png)

MaxMind SingUp: https://www.maxmind.com/en/geolite2/signup

DONT YOU WANT A MAXMIND ACCOUNT?
---------------------------------

You could set the flag "OnlineService" to false  on appsettings.json file:

![image](https://user-images.githubusercontent.com/58711247/171033160-3d61c165-5dd1-4c52-ad6b-fea3338539f3.png)

With this function you will have the opportunity to use the  LANDR Location Service partially offline.

NOTE: This function does not provide complete information about the IP's you could request.

LANDR Geolocation Service Docker Ready!
---------------------------------------

Just want to deploy and use it?

LANDR Geolocation Service is in Docker Hub just pull the image:

docker pull lbot96/landrgeolocationmicroservice:latest

Or just run this command:

docker run -it -e ConfigurationMicroservice:OnlineService={true_OR_false} -e MaxMind:AccountId="{YOUR_MAXMIND_ACCOUNT_ID}" -e MaxMind:LicenseKey="{YOUR_MAXMIND_LICENSE_KEY}" -p "443:80" lbot96/landrgeolocationmicroservice:latest

NOTE: Replace the enviroment variables for your personal settings before execute the command.

LANDR Geolocation Service Demo
-------------------------------------

The solution is ready for testing with its online DEMO:

https://geoservice.reddune-9da46cea.eastus.azurecontainerapps.io/swagger/index.html

Contact Me
-------------------------------------

Personal Web Site: https://www.diegoleon.me/ || Linkedin: in/diegoleonpena/ || Facebook: dleonpena || WhatsApp: +591 61130465 
