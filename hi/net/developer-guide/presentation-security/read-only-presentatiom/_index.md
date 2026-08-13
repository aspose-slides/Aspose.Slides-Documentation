---
title: Read-Only मोड में .NET में प्रस्तुतियों को सहेजें
linktitle: Read-Only प्रस्तुति
type: docs
weight: 30
url: /hi/net/read-only-presentation/
keywords:
- केवल पढ़ने योग्य
- प्रस्तुति सुरक्षित करें
- संपादन रोकें
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint फ़ाइलें (PPT, PPTX) को रीड-ओनली मोड में लोड और सहेजें, जिससे आपके प्रस्तुतियों को बदले बिना सटीक स्लाइड प्रीव्यू प्राप्त हो सके।"
---
## **परिचय**

PowerPoint 2019 में, Microsoft ने **Always Open Read-Only** सेटिंग को पेश किया, जो उपयोगकर्ताओं को अपनी प्रस्तुतियों की सुरक्षा के लिए उपलब्ध विकल्पों में से एक है। आप इस Read-Only सेटिंग का उपयोग करके प्रस्तुति को सुरक्षित करना चाह सकते हैं जब

- आप आकस्मिक संपादन को रोकना चाहते हैं और अपनी प्रस्तुति की सामग्री को सुरक्षित रखना चाहते हैं।  
- आप लोगों को सूचित करना चाहते हैं कि आपके द्वारा प्रदान की गई प्रस्तुति अंतिम संस्करण है।  

जब आप किसी प्रस्तुति के लिए **Always Open Read-Only** विकल्प चुनते हैं, तो उपयोगकर्ता प्रस्तुति खोलते समय **Read-Only** सिफारिश देखते हैं और उन्हें इस प्रकार का संदेश मिल सकता है: *अचानक परिवर्तन को रोकने के लिए, लेखक ने इस फ़ाइल को केवल‑पठन के रूप में खोलने के लिए सेट किया है।*

Read-Only सिफारिश एक सरल लेकिन प्रभावी निरोधक है जो संपादन को हतोत्साहित करता है क्योंकि उपयोगकर्ताओं को प्रस्तुति को संपादित करने से पहले इसे हटाने के लिए एक कार्य करना पड़ता है। यदि आप चाहते हैं कि उपयोगकर्ता प्रस्तुति में बदलाव न करें और इसे विनम्रता से बताना चाहते हैं, तो Read-Only सिफारिश आपके लिए एक अच्छा विकल्प हो सकता है।

> यदि **Read-Only** सुरक्षा वाली प्रस्तुति एक पुराने Microsoft PowerPoint अनुप्रयोग में खोली जाती है—जो हाल ही में पेश किए गए फ़ंक्शन का समर्थन नहीं करता—तो **Read-Only** सिफारिश को नजरअंदाज़ किया जाता है (प्रस्तुति सामान्य रूप से खुल जाती है)।

## **Read-Only मोड लागू करें**

Aspose.Slides for .NET आपको किसी प्रस्तुति को **Read-Only** सेट करने की अनुमति देता है, जिसका अर्थ है कि उपयोगकर्ता (प्रस्तुति खोलने के बाद) **Read-Only** सिफारिश देखते हैं। यह नमूना कोड दिखाता है कि Aspose.Slides का उपयोग करके C# में किसी प्रस्तुति को **Read-Only** कैसे सेट किया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**Note**: The **Read-Only** recommendation is simply meant to discourage editing or stop users from making accidental changes to a PowerPoint presentation. If a motivated person—who knows what they are doing—decides to edit your presentation, they can easily remove the Read-Only setting. If you seriously need to prevent unauthorized editing, you are better off using [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/hi/net/password-protected-presentation/). 

{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

### 'Read-Only recommended' पूर्ण पासवर्ड सुरक्षा से कैसे अलग है?

'Read-Only recommended' केवल फ़ाइल को केवल‑पठन मोड में खोलने का सुझाव देता है और इसे दूर करना आसान है। [Password protection](/slides/hi/net/password-protected-presentation/) वास्तव में खोलने या संपादित करने पर प्रतिबंध लगाता है और जब आपको वास्तविक सुरक्षा नियंत्रणों की आवश्यकता होती है तब उपयुक्त है।

### क्या 'Read-Only recommended' को वॉटरमार्क के साथ मिलाकर संपादन को और अधिक हतोत्साहित किया जा सकता है?

हां। सिफारिश को [watermarks](/slides/hi/net/watermark/) के साथ जोड़ा जा सकता है एक दृश्य निरोधक के रूप में; वे अलग‑अलग तंत्र हैं और साथ में अच्छी तरह काम करते हैं।

### जब सिफारिश सक्षम हो, तब क्या कोई मैक्रो या बाहरी टूल अभी भी फ़ाइल को संशोधित कर सकता है?

हां। सिफारिश प्रोग्रामेटिक बदलावों को बाधित नहीं करती। स्वचालित संपादन को रोकने के लिए, [passwords and encryption](/slides/hi/net/password-protected-presentation/) का उपयोग करें।

### 'Read-Only recommended' के संबंध में 'IsEncrypted' और 'IsWriteProtected' फ़्लैग्स क्या दर्शाते हैं?

वे अलग संकेत हैं। 'Read-Only recommended' एक नरम, वैकल्पिक प्रॉम्प्ट है; [IsWriteProtected](https://reference.aspose.com/slides/hi/net/aspose.slides/protectionmanager/iswriteprotected/) और [IsEncrypted](https://reference.aspose.com/slides/hi/net/aspose.slides/protectionmanager/isencrypted/) वास्तविक लेखन या पढ़ने की प्रतिबंधों को दर्शाते हैं जो पासवर्ड या एन्क्रिप्शन पर निर्भर होते हैं।