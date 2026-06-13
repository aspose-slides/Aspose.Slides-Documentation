---
title: RS सर्वर पर SharePoint की सेटअप
type: docs
weight: 40
url: /hi/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 

इसलिए, हमें SharePoint WFE के लिए जो किया था, वही करना है। सबसे पहले, पूर्वापेक्षित इंस्टॉलेशन को पूरा करना है और उसके बाद SharePoint सेटअप शुरू करना है।  

सेटअप के लिए, हम Server Farm चुनते हैं और एक पूर्ण इंस्टॉलेशन करते हैं जिससे यह मेरे SharePoint बॉक्स से मेल खाए, क्योंकि हम SharePoint के लिए एक स्टैंडअलोन इंस्टॉल नहीं चाहते।  

{{% /alert %}} 
### **SharePoint Configuration**
SharePoint Configuration Wizard में, हम एक मौजूदा फ़ार्म से कनेक्ट होना चाहते हैं। 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**चित्र 13**: SharePoint Configuration Wizard 

हम फिर इसे उस **SharePoint_Config** डेटाबेस की ओर इंगित करेंगे जिसका हमारे फ़ार्म द्वारा उपयोग किया जा रहा है। यदि आपको नहीं पता कि यह कहाँ है, तो आप इसे Central Admin में **System Settings -> Manager Servers in this farm.** के माध्यम से पता लगा सकते हैं। 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**चित्र 14**: SharePoint Configuration Wizard 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**चित्र 15**: SharePoint Configuration Wizard 

जब विज़ार्ड समाप्त हो जाए, तो अभी के लिए Report Server बॉक्स पर हमें केवल इतना ही करना है। ReportServer URL पर वापस जाने पर, हमें एक और त्रुटि दिखेगी, लेकिन यह इसलिए है क्योंकि हमने इसे Central Administrator के माध्यम से कॉन्फ़िगर नहीं किया है। 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**चित्र 16**: Report Server Error