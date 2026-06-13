---
title: JavaScript का उपयोग करके Read-Only मोड में प्रस्तुतियाँ सहेजें
linktitle: Read-Only प्रस्तुति
type: docs
weight: 30
url: /hi/nodejs-java/read-only-presentation/
keywords:
- केवल-पढ़ने योग्य
- प्रस्तुति को सुरक्षित करें
- संपादन रोकें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint फ़ाइलों को केवल-पढ़ने योग्य मोड में लोड और सहेजें, जिससे आपके प्रस्तुतियों को बदले बिना सटीक स्लाइड प्रीव्यू मिलते हैं।"
---
## **परिचय**

PowerPoint 2019 में, Microsoft ने **Always Open Read-Only** सेटिंग को पेश किया, जो उपयोगकर्ताओं के लिए अपनी प्रस्तुतियों को सुरक्षित रखने के विकल्पों में से एक है। आप इस Read-Only सेटिंग का उपयोग तब करना चाह सकते हैं जब

- आप अनजाने में होने वाले संपादनों को रोकना चाहते हैं और अपनी प्रस्तुति की सामग्री को सुरक्षित रखना चाहते हैं।  
- आप दर्शकों को यह बताना चाहते हैं कि आप द्वारा प्रदान की गई प्रस्तुति अंतिम संस्करण है।  

जब आप किसी प्रस्तुति के लिए **Always Open Read-Only** विकल्प चुनते हैं, तो उपयोगकर्ता जब प्रस्तुति खोलते हैं, उन्हें **Read-Only** सुझाव दिखता है और यह संदेश दिख सकता है: *अनजाने में बदलावों को रोकने के लिए, लेखक ने इस फ़ाइल को केवल पढ़ने के मोड में खोलने के लिए सेट किया है।*

Read-Only सुझाव एक साधारण लेकिन प्रभावी निरोधक है जो संपादन को हतोत्साहित करता है क्योंकि उपयोगकर्ताओं को इसे हटाने के बाद ही वे प्रस्तुति को संपादित कर सकते हैं। यदि आप चाहते हैं कि उपयोगकर्ता प्रस्तुति में बदलाव न करें और इसे विनम्रता से सूचित करना चाहते हैं, तो Read-Only सुझाव आपके लिए एक अच्छा विकल्प हो सकता है।

> यदि **Read-Only** सुरक्षा वाली प्रस्तुति को किसी पुराने Microsoft PowerPoint एप्लिकेशन में खोलते हैं—जो इस नई कार्यक्षमता का समर्थन नहीं करता—तो **Read-Only** सुझाव को अनदेखा किया जाता है (प्रस्तुति सामान्य रूप से खुलती है)।

## **Read-Only मोड लागू करें**

Aspose.Slides for Node.js via Java आपको एक प्रस्तुति को **Read-Only** सेट करने की अनुमति देता है, जिसका अर्थ है कि उपयोगकर्ता (प्रस्तुति खोलने के बाद) **Read-Only** सुझाव देखते हैं। नीचे दिया गया नमूना कोड दिखाता है कि Aspose.Slides का उपयोग करके JavaScript में प्रस्तुति को **Read-Only** कैसे सेट किया जाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

**ध्यान दें**: **Read-Only** सुझाव केवल प्रस्तुति को गलती से संपादित करने से रोकने या हतोत्साहित करने के लिए है। यदि कोई जानकार व्यक्ति, जो पूरी तरह से समझता है, आपकी प्रस्तुति को संपादित करने का चयन करता है, तो वह आसानी से Read-Only सेटिंग को हटा सकता है। यदि आपको वास्तव में अनधिकृत संपादन को रोकना है, तो आप [अधिक कठोर सुरक्षा जो एन्क्रिप्शन और पासवर्ड शामिल करती है](https://docs.aspose.com/slides/hi/nodejs-java/password-protected-presentation/) का उपयोग बेहतर रहेगा। 

{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**'Read-Only recommended' और पूर्ण पासवर्ड सुरक्षा में क्या अंतर है?**

'Read-Only recommended' केवल फ़ाइल को केवल पढ़ने के मोड में खोलने का सुझाव देता है और इसे आसानी से बायपास किया जा सकता है। [Password protection](/slides/hi/nodejs-java/password-protected-presentation/) वास्तव में खोलने या संपादन को प्रतिबंधित करता है और वास्तविक सुरक्षा नियंत्रण की आवश्यकता होने पर उपयुक्त है।

**क्या 'Read-Only recommended' को वॉटरमार्क के साथ मिलाकर संपादन को और अधिक हतोत्साहित किया जा सकता है?**

हां। सुझाव को [watermarks](/slides/hi/nodejs-java/watermark/) के साथ जोड़ा जा सकता है; ये अलग तंत्र हैं और साथ में अच्छी तरह कार्य करते हैं।

**क्या कोई मैक्रो या बाहरी उपकरण अभी भी फ़ाइल को संशोधित कर सकता है जब सुझाव सक्षम हो?**

हां। सुझाव प्रोग्रामेटिक बदलावों को नहीं रोकता। स्वचालित संपादन को रोकने के लिए, [passwords and encryption](/slides/hi/nodejs-java/password-protected-presentation/) का उपयोग करें।

**'Read-Only recommended' का 'IsEncrypted' और 'IsWriteProtected' फ्लैग से क्या संबंध है?**

ये अलग संकेत हैं। 'Read-Only recommended' एक सौम्य, वैकल्पिक प्रॉम्प्ट है; [isWriteProtected](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) और [isEncrypted](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/isencrypted/) वास्तविक लिखने या पढ़ने की प्रतिबंध दर्शाते हैं, जो पासवर्ड या एन्क्रिप्शन पर निर्भर करते हैं।