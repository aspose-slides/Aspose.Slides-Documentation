---
title: Aspose.Slides for SharePoint स्थापित करना
type: docs
weight: 10
url: /hi/sharepoint/installing-aspose-slides-for-sharepoint/
---
{{% alert color="primary" %}} 

Aspose.Slides for SharePoint को Aspose.Slides.SharePoint.zip अभिलेख के रूप में डाउनलोड किया जाता है। अभिलेख में शामिल हैं: 

- **Aspose.Slides.SharePoint.wsp**: SharePoint समाधान फ़ाइल। Aspose.Slides for SharePoint को सर्वर फ़ार्म में सक्रियण और निष्क्रियण को आसान बनाने के लिए SharePoint समाधान के रूप में पैकेज किया गया है।
- **Aspose_LicenseAgreement.rtf**: अंतिम उपयोगकर्ता लाइसेंस समझौता।
- **Setup.exe**: सेटअप प्रोग्राम।
- **Setup.exe.config**: सेटअप कॉन्फ़िगरेशन फ़ाइल।

{{% /alert %}} 
## **स्थापना प्रक्रिया**
स्थापना चलाने से पहले, सेटअप प्रोग्राम यह जांचता है कि:

- WSS 3.0 या MOSS 2007 स्थापित है।
- उपयोगकर्ता के पास SharePoint समाधान स्थापित करने की अनुमति है।
- SharePoint डेटाबेस ऑनलाइन है।
- WSS प्रशासन सेवा शुरू की गई है।
- WSS टाइमर सेवा शुरू की गई है।

WSS प्रशासन और टाइमर सेवाएँ आवश्यक हैं क्योंकि कुछ सेटअप कार्रवाईओं को सर्वर फ़ार्म के सभी सर्वरों तक पहुँचाने के लिए टाइमर जॉब पर निर्भर होना पड़ता है। 
### **स्थापना चलाना**
Aspose.Slides for SharePoint स्थापित करने के लिए: 

1. Aspose.Slides.SharePoint ज़िप को MOSS 7.0 या WSS 3.0 सर्वर पर स्थानीय ड्राइव में अनपैक करें।
2. setup.exe चलाएँ और स्क्रीन पर दिए गए निर्देशों का पालन करें।
   सेटअप प्रोग्राम निम्नलिखित कार्य करता है: 
   1. स्थापना पूर्वापेक्षाएँ जांचता है। यदि कोई जांच विफल होती है तो सेटअप आगे नहीं बढ़ेगा। 

      **सिस्टम जांच चलाना** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)




3. अंतिम उपयोगकर्ता लाइसेंस समझौता प्रदर्शित करता है। आगे बढ़ने के लिए आपको समझौते को स्वीकार करना होगा। 

   **EULA** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)




4. डिप्लॉयमेंट लक्ष्य चयन प्रदर्शित करता है। वेब एप्लिकेशन और साइट संग्रह चुनता है जिनके लिए फ़ीचर सक्रिय किया जाना चाहिए। 

   **डिप्लॉयमेंट लक्ष्य चुनना** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)




5. फ़ीचर को सर्वर फ़ार्म में तैनात करता है। 

   **स्थापना प्रगति बार** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)




6. चयनित साइट संग्रहों के लिए Aspose.Slides सक्रिय करता है और उनके मूल वेब एप्लिकेशन को कॉन्फ़िगर करता है।
7. फ़ीचर जिन वेब एप्लिकेशन और साइट संग्रहों के लिए तैनात और सक्रिय किया गया है, उसकी सूची प्रदर्शित करता है। 

   **सफल स्थापना** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)