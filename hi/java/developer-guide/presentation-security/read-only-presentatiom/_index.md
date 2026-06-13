---
title: Java का उपयोग करके Read-Only मोड में प्रस्तुतियों को सहेजें
linktitle: Read-Only प्रस्तुति
type: docs
weight: 30
url: /hi/java/read-only-presentation/
keywords:
- केवल-पढ़ने योग्य
- प्रस्तुति की सुरक्षा
- संपादन रोकें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint फ़ाइलें (PPT, PPTX) को read-only मोड में लोड और सहेजें, जिससे आपकी प्रस्तुतियों को बदले बिना सटीक स्लाइड पूर्वावलोकन मिलते हैं।"
---
## **परिचय**

PowerPoint 2019 में, Microsoft ने **Always Open Read-Only** सेटिंग को उन विकल्पों में से एक के रूप में पेश किया जिसे उपयोगकर्ता अपनी प्रस्तुतियों की रक्षा के लिए उपयोग कर सकते हैं। आप इस Read-Only सेटिंग का उपयोग तब कर सकते हैं जब

- आप आकस्मिक संपादन को रोकना चाहते हैं और अपनी प्रस्तुति की सामग्री को सुरक्षित रखना चाहते हैं। 
- आप लोगों को यह बताना चाहते हैं कि आप द्वारा प्रदान की गई प्रस्तुति अंतिम संस्करण है। 

जब आप किसी प्रस्तुति के लिए **Always Open Read-Only** विकल्प चुनते हैं, तो उपयोगकर्ता प्रस्तुति खोलते समय **Read-Only** अनुशंसा देखते हैं और उन्हें इस तरह का संदेश दिख सकता है: *अकस्मात परिवर्तन को रोकने के लिए, लेखक ने इस फ़ाइल को केवल-पढ़ने के रूप में खोलने के लिये सेट किया है।*  

Read-Only अनुशंसा एक साधारण लेकिन प्रभावी निवारक है जो संपादन को हतोत्साहित करता है क्योंकि उपयोगकर्ताओं को प्रस्तुति को संपादित करने से पहले इसे हटाने के लिए एक कार्य करना पड़ता है। यदि आप चाहते हैं कि उपयोगकर्ता प्रस्तुति में बदलाव न करें और इसे एक विनम्र तरीके से बताना चाहते हैं, तो Read-Only अनुशंसा आपके लिये एक अच्छा विकल्प हो सकता है। 

> यदि **Read-Only** सुरक्षा वाली प्रस्तुति को किसी पुराने Microsoft PowerPoint संस्करण में खोला जाता है—जो हाल ही में प्रस्तुत कार्यक्षमता का समर्थन नहीं करता—तो **Read-Only** अनुशंसा को अनदेखा कर दिया जाता है (प्रस्तुति सामान्य रूप से खुलती है)।

## **Read-Only मोड लागू करें**

Aspose.Slides for Java आपको किसी प्रस्तुति को **Read-Only** निर्धारित करने की अनुमति देता है, जिसका अर्थ है कि उपयोगकर्ता (प्रस्तुति खोलने के बाद) **Read-Only** अनुशंसा देखते हैं। यह नमूना कोड दिखाता है कि कैसे Aspose.Slides का उपयोग करके Java में किसी प्रस्तुति को **Read-Only** सेट किया जाता है:

```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**Note**: **Read-Only** अनुशंसा केवल संपादन को रोकने या उपयोगकर्ताओं को PowerPoint प्रस्तुति में आकस्मिक परिवर्तन करने से बचाने के लिए है। यदि कोई जानकार व्यक्ति—जो क्या कर रहा है जानता है—आपकी प्रस्तुति को संपादित करने का निर्णय लेता है, तो वह आसानी से Read-Only सेटिंग को हटा सकता है। यदि आपको अनधिकृत संपादन को गंभीरता से रोकना है, तो आप [अधिक कठोर सुरक्षा जो एन्क्रिप्शन और पासवर्ड शामिल करती हैं](https://docs.aspose.com/slides/hi/java/password-protected-presentation/) का उपयोग बेहतर रहेगा। 

{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**'Read-Only recommended' पूर्ण पासवर्ड सुरक्षा से कैसे अलग है?**

'Read-Only recommended' केवल फ़ाइल को केवल-पढ़ने मोड में खोलने का सुझाव देता है और इसे बायपास करना आसान है। [Password protection](/slides/hi/java/password-protected-presentation/) वास्तव में खोलने या संपादित करने पर प्रतिबंध लगाता है और वास्तविक सुरक्षा नियंत्रणों की आवश्यकता होने पर उपयुक्त है।  

**क्या 'Read-Only recommended' को वॉटरमार्क के साथ मिलाकर संपादन को और अधिक हतोत्साहित किया जा सकता है?**

हां। अनुशंसा को [watermarks](/slides/hi/java/watermark/) के साथ जोड़ा जा सकता है ताकि एक दृश्य निवारक बन सके; ये अलग‑अलग तंत्र हैं और साथ में अच्छी तरह काम करते हैं।  

**क्या अनुशंसा सक्षम होने पर भी मैक्रो या बाहरी टूल फ़ाइल को संशोधित कर सकते हैं?**

हां। अनुशंसा प्रोग्रामेटिक परिवर्तन को ब्लॉक नहीं करती। स्वचालित संपादन को रोकने के लिये आप [passwords and encryption](/slides/hi/java/password-protected-presentation/) का उपयोग करें।  

**'Read-Only recommended' का 'isEncrypted' और 'isWriteProtected' विधियों से क्या संबंध है?**

वे अलग संकेत हैं। 'Read-Only recommended' एक नरम, वैकल्पिक प्रॉम्प्ट है; [isWriteProtected](https://reference.aspose.com/slides/hi/java/com.aspose.slides/protectionmanager/#isWriteProtected--) और [isEncrypted](https://reference.aspose.com/slides/hi/java/com.aspose.slides/protectionmanager/#isEncrypted--) वास्तविक लिखने या पढ़ने प्रतिबंध दर्शाते हैं जो पासवर्ड या एन्क्रिप्शन पर निर्भर करते हैं।