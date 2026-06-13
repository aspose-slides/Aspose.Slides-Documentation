---
title: रिपोर्टिंग सर्विसेज़ सेट अप करना
type: docs
weight: 30
url: /hi/reportingservices/setting-up-reporting-services/
---
{{% alert color="primary" %}} 

RS सर्वर पर हमारी पहली रोक रिपोर्टिंग सर्विसेज़ कॉन्फ़िगरेशन मैनेजर है। 

{{% /alert %}} 
## **सेवा खाता**
सुनिश्चित करें कि आप रिपोर्टिंग सर्विसेज़ के लिए कौन सा सर्विस अकाउंट उपयोग कर रहे हैं, इसे समझें। यदि हमें समस्याएँ आती हैं, तो वह आपके द्वारा उपयोग किए जा रहे सर्विस अकाउंट से संबंधित हो सकती हैं। डिफ़ॉल्ट रूप से Network Service होता है। जब भी मैं नई बिल्ड्स तैनात करता हूँ, मैं हमेशा डोमेन अकाउंट्स का उपयोग करता हूँ, क्योंकि वहीँ पर मुझे समस्याएँ मिलने की संभावना अधिक होती है। इस कॉन्फ़िगरेशन के लिए मेरे सर्वर पर मैंने **RSService** नामक डोमेन अकाउंट का उपयोग किया है। 
## **वेब सर्विस URL**
हमें Web Service URL को कॉन्फ़िगर करना होगा। यह **ReportServer** वर्चुअल डायरेक्टरी (vdir) है जो वेब सर्विसेज़ को होस्ट करती है, जिसे रिपोर्टिंग सर्विसेज़ उपयोग करती है, और जिसके साथ SharePoint संवाद करेगा। जब तक आप vdir की विशेषताओं (जैसे SSL, पोर्ट, होस्ट हेडर आदि) को अनुकूलित नहीं करना चाहते, तब तक आपको यहाँ Apply बटन पर क्लिक करके इसे ठीक से सेट करना चाहिए। 

![todo:image_alt_text](setting-up-reporting-services_1.png)

![todo:image_alt_text](setting-up-reporting-services_2.png)


**Figure 3**: Web Service URL सेट अप करना 

जब यह हो जाए, तो आपको निम्नलिखित चित्र दिखना चाहिए। 

![todo:image_alt_text](setting-up-reporting-services_3.png)

**Figure 4**: Web Service URL की सफल सेटअप 
## **डेटाबेस**
हमें रिपोर्टिंग सर्विसेज़ कैटलॉग डेटाबेस बनाना है। इसे किसी भी SQL 2008 या SQL 2008 R2 डेटाबेस इंजन पर रखा जा सकता है। SQL11 भी ठीक चलता है, लेकिन वह अभी BETA में है। यह क्रिया डिफ़ॉल्ट रूप से दो डेटाबेस बनाती है, **ReportServer** और **ReportServerTempDB**। 
इसके साथ अगला महत्वपूर्ण कदम यह सुनिश्चित करना है कि आप डेटाबेस प्रकार के लिए SharePoint Integrated चुनें। एक बार यह चयन करने के बाद इसे बदला नहीं जा सकता। कृपया संदर्भ के लिए चित्र 5, 6 और 7 देखें। 

![todo:image_alt_text](setting-up-reporting-services_4.png)

**Figure 5**: रिपोर्ट सर्वर डेटाबेस बनाना 

![todo:image_alt_text](setting-up-reporting-services_5.png)

**Figure 6**: डेटाबेस सर्वर और प्रमाणिकरण प्रकार सेट करना 

![todo:image_alt_text](setting-up-reporting-services_6.png)

**Figure 7**: डेटाबेस नाम और मोड सेट करना 

प्रमाणपत्रों के लिए, यह वह तरीका है जिससे Report Server SQL Server के साथ संवाद करेगा। आप जिस भी खाते को चुनते हैं, उसे Catalog डेटाबेस में तथा कुछ सिस्टम डेटाबेस में RSExecRole के माध्यम से अधिकार दिए जाएंगे। MSDB उन डेटाबेस में से एक है जिसका उपयोग हम सब्सक्रिप्शन के लिए करते हैं क्योंकि हम SQL Agent का उपयोग करते हैं। 

![todo:image_alt_text](setting-up-reporting-services_7.png)

**Figure 8**: Report Server डेटाबेस प्रमाणपत्र सेट करना 

जब यह हो जाए, तो यह निम्नलिखित चित्र जैसा दिखेगा। 

![todo:image_alt_text](setting-up-reporting-services_8.png)


**Figure 9**: Report Server डेटाबेस सेटअप को समाप्त करने की प्रक्रिया 
## **रिपोर्ट मैनेजर URL**
हम Report Manager URL को छोड़ सकते हैं, क्योंकि SharePoint Integrated मोड में यह उपयोग नहीं होता। SharePoint हमारा फ्रंटएंड है। Report Manager काम नहीं करता। 
## **एन्क्रिप्शन कुंजियाँ**
अपनी एन्क्रिप्शन कुंजियों का बैकअप लें और यह सुनिश्चित करें कि आप उन्हें कहां रख रहे हैं। यदि आपको डेटाबेस को माइग्रेट या पुनर्स्थापित करने की स्थिति आती है, तो आपको इनकी आवश्यकता होगी। 

![todo:image_alt_text](setting-up-reporting-services_9.png)

यही Reporting Services Configuration Manager का काम है। यदि आप Web Service URL टैब में URL पर जाएँ, तो यह निम्नलिखित चित्र जैसा कुछ दिखाना चाहिए। 

![todo:image_alt_text](setting-up-reporting-services_10.png)

**Figure 12**: इंस्टॉलेशन के बाद Report Server तक पहुँच 

क्या हुआ? SharePoint मेरे WFE पर इंस्टॉल है और मैंने Reporting Services की सेटअप पूरी कर ली है। इस उदाहरण में, Reporting Services और SharePoint अलग-अलग मशीनों पर हैं। यदि वे एक ही मशीन पर होते, तो आपको यह त्रुटि नहीं दिखती। तकनीकी रूप से हमें RS Box पर SharePoint स्थापित करना होगा। इसका मतलब है कि IIS भी सक्षम हो जाएगा।