# SMSey (Extreme Medicine Hackathon)
(Built to demo in under 8 hours)

---
 
### Contributors
---
 
* Kaelan Fouwels

Project
---
 
The aim of this demo was to build a platform to allow people in locations with poor or damaged network infrastructure to ping back their location (via gps) and relvant information back to a central source purely over SMS.

This was done by implementing three components:
- An offline app installed on a phone to retrieve the gps co-ordinates, present the user with mission relevent information fields, and encode this data into a compressed (ideally) payload to then be pasted into a text message and sent to a central number
- A central server to recieve the sms payloads, decode them, store the values, amd present the data in basic api form to the:
- Dashboard, implemented VERY basically for this demo, but designed to plot the text ins ona map, along with your local resources, and allow you to coordinate these and organise pick up/medical teams/etc (depending on the scenario), and ping back a message to the clients instructing them what to do (stay there/walk north 3km/etc.)

For the demo, the scenario of refugees needing medical attention in unknown countries/locations was used, but this could be replaced as desired. For example, tracking amd coordinating a medical team in the field when conventional infrastructure is not available.
 
###Running
---

Install git, dnvm, vnext beta4, and npm
 
```sh
git clone [repo url]
cd [repo name]
dnvm install 1.0.0-beta4
dnvm use 1.0.0-beta4

cd webapi(?)
dnu restore
bower install
gulp build

dnx . web
```
 
You will need to configure a twilio number to callback to /api/v0/twilio/in,  best done by ngrokking your local install and providing that gateway. note, the host header must be specified to localhost with the following in order to be accepted:

```ngrok http -host-header=localhost 5000```
