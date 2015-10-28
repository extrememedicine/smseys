
## Extreme Medicine Hackathon
# SMSey
 
---
 
### Contributors
 
* Kaelan Fouwels
 
---
 
The idea begind this project was to build a platform to allow people in locations with poor or damaged network infrastructure to ping back their location (via gps) and relvant information back tp a central source purely over SMS.

This was done by implementing three components:
- an offline app installed on a phone to retrieve the gps co-ordinates, presemt the user with mission relevent information fields, and encode this data into a compressed (ideally) payload to then be pasted into a text message and sent to a central number
- a central server to recieve the sms payloads, decode them, store the values, amd present the data in basic api form to the:
- dashboard, implemented VERY basically for this demo, but designed to plot the text ins ona map, along with your local resources, and allow you to coordinate these and organise pick up/medical teams/etc (depending on the scenario), and ping back a message to the clients instructing them what to do (stay there/walk north 3km/etc.)

For the demo, the scenario of refugees needing medical attention in unknown countries/locations was used, but this could be replaced as desired. For exame, tracking amd coordinating a medical team in the field when conventional infrastructure is not available.

---
 
### How to run
 
Install git, dmvm, and npm
 
```sh
git clone [repo url]
cd [repo name]
dnvm install 1.0.0-beta4
dnvm use 1.0.0-beta4

cd webapi(?)
dnu restore
bpwer install
gulp build

dnx . web
```
 
 you will need to configure a twilio number to callback to /api/v0/twilio/in this is best done by ngrokking your local install and providing that gatewat. note, the host header must be specified as follows:


ngrok http -host-header=localhost 5000
