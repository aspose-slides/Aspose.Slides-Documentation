---
title: डिप्लॉयमेंट और एक्टिवेशन
type: docs
weight: 20
url: /hi/sharepoint/deployment-and-activation/
description: "Aspose.Slides for SharePoint समाधान के डिप्लॉय होने पर फ़ार्म में जो स्थापित करता है, तथा उसके साइट कलेक्शन फ़ीचर के सक्रिय होने पर जो जोड़ता है।"
---
## **डिप्लॉयमेंट**

डिप्लॉयमेंट के दौरान, Aspose.Slides for SharePoint समाधान:

- अपने असेंबली को ग्लोबल असेंबली कैश (GAC) में इंस्टॉल करता है और **web.config** फ़ाइल में इसके लिए SafeControl एंट्रीज़ जोड़ता है। SharePoint 2010 और उसके बाद के संस्करणों में यह *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* या *Aspose.Slides.SharePoint2016.dll* (SharePoint 2019 पैकेज भी *Aspose.Slides.SharePoint2016.dll* इंस्टॉल करता है) होता है। SharePoint 2007 में यह *Aspose.Slides.SharePointUI.dll* के साथ *Aspose.Slides.SharePoint.Deployment.dll* होता है।
- कन्‍वर्ज़न पेज और उसकी इमेज़ तथा अन्य सहायक फाइलें SharePoint इंस्टॉलेशन फ़ोल्डर्स में कॉपी करता है।
- फ़ीचर को इंस्टॉल करता है और साइट कलेक्शन्स पर सक्रिय करने के लिए उपलब्ध कराता है।

## **एक्टिवेशन**

Aspose.Slides for SharePoint को साइट कलेक्शन फ़ीचर के रूप में पैकेज किया गया है और इसे साइट कलेक्शन्स पर सक्रिय या निष्क्रिय किया जा सकता है। जब यह किसी साइट कलेक्शन पर सक्रिय किया जाता है, तो फ़ीचर जोड़ता है:

- SharePoint 2010 और उसके बाद के संस्करणों में:
  - दस्तावेज़ लाइब्रेरीज़ के मेन्यू में **Convert via Aspose.Slides** आइटम;
  - **Aspose Tools** रिबन टैब जिसमें **Convert Slides** बटन होता है, जो चयनित दस्तावेज़ों को कन्‍वर्ट करता है;
  - PPT, PPTX, PPS और PPSX फ़ाइलों के मेन्यू में **View Slides** आइटम।
- SharePoint 2007 में:
  - दस्तावेज़ लाइब्रेरीज़ के मेन्यू में **Convert with Aspose.Slides** आइटम;
  - दस्तावेज़ लाइब्रेरीज़ के **Actions** मेन्यू में **Convert All with Aspose.Slides** आइटम।

SharePoint 2007 में, एक्टिवेशन साइट कलेक्शन के पैरेंट वेब एप्लिकेशन की वर्चुअल डायरेक्टरी में भी बदलाव करता है। यह:

- कन्‍वर्ज़न सेटिंग्स पेज को साइटमैप फ़ाइल में जोड़ता है।
- आवश्यक रिसोर्स फ़ाइलें वर्चुअल डायरेक्टरी के App_GlobalResources फ़ोल्डर में कॉपी करता है।

सेटअप प्रोग्राम चयनित साइट कलेक्शन्स पर फीचर को सक्रिय करता है, जिसे आप [installation](/slides/hi/sharepoint/installing-aspose-slides-for-sharepoint/) के दौरान चुन सकते हैं।