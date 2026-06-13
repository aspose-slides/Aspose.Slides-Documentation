---
title: Read-Only मोड में प्रस्तुतियों को .NET में सहेजें
linktitle: Read-Only प्रस्तुति
type: docs
weight: 30
url: /hi/net/read-only-presentation/
keywords:
- केवल पढ़ने योग्य
- प्रस्तुति की सुरक्षा
- संपादन को रोकें
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint फ़ाइलें (PPT, PPTX) को पढ़ने-के-लिए मोड में लोड और सहेजें, जो आपकी प्रस्तुतियों को बदले बिना सटीक स्लाइड प्रीव्यू प्रदान करती हैं।"
---
## **परिचय**

PowerPoint 2019 में, Microsoft ने **Always Open Read-Only** सेटिंग को पेश किया, जो उपयोगकर्ता अपनी प्रस्तुतियों की सुरक्षा के लिए उपयोग कर सकते हैं। आप इस Read-Only सेटिंग का उपयोग तभी करना चाहेंगे जब

- आप आकस्मिक संपादन को रोकना चाहते हैं और अपनी प्रस्तुति की सामग्री को सुरक्षित रखना चाहते हैं। 
- आप लोगों को यह बताना चाहते हैं कि आपने जो प्रस्तुति प्रदान की है वह अंतिम संस्करण है। 

जब आप किसी प्रस्तुति के लिए **Always Open Read-Only** विकल्प चुनते हैं, तो उपयोगकर्ता जब प्रस्तुति खोलते हैं, उन्हें **Read-Only** सिफारिश दिखाई देती है और इस तरह का संदेश मिल सकता है: *To prevent accidental changes, the author has set this file to open as read-only.*

Read-Only सिफारिश एक सरल लेकिन प्रभावी निवारक है जो संपादन को हतोत्साहित करता है क्योंकि उपयोगकर्ताओं को प्रस्तुति संपादित करने से पहले इसे हटाने का कार्य करना पड़ता है। यदि आप उपयोगकर्ताओं को प्रस्तुति में परिवर्तन करने से रोकना चाहते हैं और यह बात शालीनता से बताना चाहते हैं, तो Read-Only सिफारिश आपके लिए एक अच्छा विकल्प हो सकता है। 

> यदि **Read-Only** सुरक्षा वाली प्रस्तुति को किसी पुराने Microsoft PowerPoint एप्लिकेशन में खोला जाता है—जो हाल ही में पेश की गई कार्यक्षमता का समर्थन नहीं करता—तो **Read-Only** सिफारिश को नजरअंदाज कर दिया जाता है (प्रस्तुति सामान्य रूप से खुलती है)।

## **Read-Only मोड लागू करें**

Aspose.Slides for .NET आपको एक प्रस्तुति को **Read-Only** सेट करने की अनुमति देता है, जिसका अर्थ है कि उपयोगकर्ता (प्रस्तुति खोलने के बाद) **Read-Only** सिफारिश देखते हैं। यह नमूना कोड दिखाता है कि आप Aspose.Slides का उपयोग करके C# में किसी प्रस्तुति को **Read-Only** कैसे सेट कर सकते हैं:

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**नोट**: **Read-Only** सिफारिश का उद्देश्य सिर्फ संपादन को हतोत्साहित करना या उपयोगकर्ताओं को PowerPoint प्रस्तुति में आकस्मिक परिवर्तन करने से रोकना है। यदि कोई प्रेरित व्यक्ति—जो जानता है कि वह क्या कर रहा है—आपकी प्रस्तुति को संपादित करना चाहता है, तो वह आसानी से Read-Only सेटिंग हटा सकता है। यदि आपको अनधिकृत संपादन को गंभीरता से रोकने की आवश्यकता है, तो आप [अधिक कड़े सुरक्षा जो एन्क्रिप्शन और पासवर्ड शामिल करती हैं](https://docs.aspose.com/slides/hi/net/password-protected-presentation/) का उपयोग करना बेहतर होगा। 

{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**'Read-Only recommended' पूर्ण पासवर्ड सुरक्षा से कैसे अलग है?**

'Read-Only recommended' केवल फ़ाइल को केवल-पठन मोड में खोलने का सुझाव देता है और इसे आसानी से बायपास किया जा सकता है। [Password protection](/slides/hi/net/password-protected-presentation/) वास्तव में खोलने या संपादित करने को प्रतिबंधित करता है और जब आपको वास्तविक सुरक्षा नियंत्रणों की आवश्यकता होती है, तब उपयुक्त है।

**क्या 'Read-Only recommended' को वॉटरमार्क के साथ मिलाकर संपादन को और अधिक हतोत्साहित किया जा सकता है?**

हाँ। इस सिफारिश को [watermarks](/slides/hi/net/watermark/) के साथ जोड़ा जा सकता है ताकि दृश्य हतोत्साहन प्रदान किया जा सके; ये अलग‑अलग तंत्र हैं और साथ में अच्छी तरह काम करते हैं।

**क्या कोई मैक्रो या बाहरी टूल सिफारिश सक्षम होने पर भी फ़ाइल को संशोधित कर सकता है?**

हाँ। सिफारिश प्रोग्रामेटिक परिवर्तन को ब्लॉक नहीं करती। स्वचालित संपादन को रोकने के लिए [passwords and encryption](/slides/hi/net/password-protected-presentation/) का उपयोग करें।

**'Read-Only recommended' का 'IsEncrypted' और 'IsWriteProtected' फ़्लैग्स से क्या संबंध है?**

ये अलग संकेत हैं। 'Read-Only recommended' एक नरम, वैकल्पिक प्रॉम्प्ट है; [IsWriteProtected](https://reference.aspose.com/slides/hi/net/aspose.slides/protectionmanager/iswriteprotected/) और [IsEncrypted](https://reference.aspose.com/slides/hi/net/aspose.slides/protectionmanager/isencrypted/) वास्तविक लेखन या पढ़ने के प्रतिबंध दर्शाते हैं जो पासवर्ड या एन्क्रिप्शन पर निर्भर करते हैं।