---
title: Android पर Read-Only मोड में प्रस्तुतियों को सहेजें
linktitle: केवल-पढ़ने योग्य प्रस्तुति
type: docs
weight: 30
url: /hi/androidjava/read-only-presentation/
keywords:
- केवल पढ़ने योग्य
- प्रस्तुति की सुरक्षा
- संपादन रोकें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint फ़ाइलें (PPT, PPTX) को केवल-पढ़ने योग्य मोड में सहेजें, जिससे आपकी प्रस्तुतियों को बदले बिना सटीक स्लाइड पूर्वावलोकन मिलते हैं।"
---
## **परिचय**

PowerPoint 2019 में, Microsoft ने **Always Open Read-Only** सेटिंग को एक विकल्प के रूप में पेश किया जो उपयोगकर्ता अपनी प्रस्तुतियों की सुरक्षा के लिए उपयोग कर सकते हैं। आप इस Read-Only सेटिंग का उपयोग करके प्रस्तुति की सुरक्षा तब करना चाह सकते हैं जब

- आप आकस्मिक संपादन को रोकना चाहते हैं और अपनी प्रस्तुति की सामग्री को सुरक्षित रखना चाहते हैं।
- आप लोगों को यह बताना चाहते हैं कि आप द्वारा प्रदान की गई प्रस्तुति अंतिम संस्करण है।

जब आप किसी प्रस्तुति के लिए **Always Open Read-Only** विकल्प चुनते हैं, तो उपयोगकर्ता प्रस्तुति खोलते समय **Read-Only** सिफ़ारिश देखते हैं और इसे इस रूप में संदेश देख सकते हैं: *अचानक होने वाले बदलावों को रोकने के लिए, लेखक ने इस फ़ाइल को केवल-पढ़ने के लिए खोलने हेतु सेट किया है.*

Read-Only सिफ़ारिश एक सरल लेकिन प्रभावी निवारक है जो संपादन को हतोत्साहित करता है क्योंकि उपयोगकर्ताओं को प्रस्तुति को संपादित करने से पहले इसे हटाने के लिए एक कार्य करना पड़ता है। यदि आप उपयोगकर्ताओं को प्रस्तुति में बदलाव करने से रोकना चाहते हैं और इसे विनम्रता से बताना चाहते हैं, तो Read-Only सिफ़ारिश आपके लिए एक अच्छा विकल्प हो सकता है।

> यदि **Read-Only** सुरक्षा वाली प्रस्तुति को पुराने Microsoft PowerPoint एप्लिकेशन में खोला जाता है—जो हाल ही में पेश किए गए फ़ंक्शन का समर्थन नहीं करता—तो **Read-Only** सिफ़ारिश को अनदेखा किया जाता है (प्रस्तुति सामान्य रूप से खुलती है)।

## **Read-Only मोड लागू करें**

Aspose.Slides for Android via Java आपको एक प्रस्तुति को **Read-Only** सेट करने की अनुमति देता है, जिसका अर्थ है कि उपयोगकर्ता (प्रस्तुति खोलने के बाद) **Read-Only** सिफ़ारिश देखते हैं। यह नमूना कोड दिखाता है कि Aspose.Slides का उपयोग करके जावा में प्रस्तुति को **Read-Only** कैसे सेट करें:

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

**नोट**: **Read-Only** सिफ़ारिश का उद्देश्य केवल संपादन को हतोत्साहित करना या उपयोगकर्ताओं को PowerPoint प्रस्तुति में आकस्मिक बदलाव करने से रोकना है। यदि एक प्रेरित व्यक्ति—जो जानता है कि वह क्या कर रहा है—आपकी प्रस्तुति को संपादित करने का निर्णय लेता है, तो वह आसानी से Read-Only सेटिंग को हटा सकता है। यदि आपको अनधिकृत संपादन को गंभीरता से रोकने की आवश्यकता है, तो आप [एन्क्रिप्शन और पासवर्ड शामिल करने वाली अधिक कठोर सुरक्षा](https://docs.aspose.com/slides/hi/androidjava/password-protected-presentation/) का उपयोग करना बेहतर रहेगा।

{{% /alert %}} 

## **अधिकतर पूछे जाने वाले प्रश्न**

**Read-Only recommended** पूर्ण पासवर्ड सुरक्षा से कैसे अलग है?

'Read-Only recommended' केवल फ़ाइल को केवल-पढ़ने मोड में खोलने का सुझाव दिखाता है और इसे आसानी से बायपास किया जा सकता है। [Password protection](/slides/hi/androidjava/password-protected-presentation/) वास्तव में खोलने या संपादित करने को प्रतिबंधित करता है और जब आपको वास्तविक सुरक्षा नियंत्रणों की आवश्यकता होती है तब उपयुक्त है।

**Read-Only recommended** को वॉटरमार्क के साथ जोड़ा जा सकता है ताकि संपादन और भी हतोत्साहित हो सके?

हाँ। इस सिफ़ारिश को [watermarks](/slides/hi/androidjava/watermark/) के साथ दृश्य रोक के रूप में जोड़ा जा सकता है; वे अलग‑अलग तंत्र हैं और एक साथ अच्छी तरह काम करते हैं।

**Read-Only recommended** सक्षम होने पर क्या मैक्रो या बाहरी उपकरण अभी भी फ़ाइल को संशोधित कर सकते हैं?

हाँ। सिफ़ारिश प्रोग्रामेटिक परिवर्तन को ब्लॉक नहीं करती। स्वचालित संपादन को रोकने के लिए [passwords and encryption](/slides/hi/androidjava/password-protected-presentation/) का उपयोग करें।

**Read-Only recommended** 'isEncrypted' और 'isWriteProtected' मेथड्स से कैसे संबंधित है?

वे अलग‑अलग संकेत हैं। 'Read-Only recommended' एक नरम, वैकल्पिक संकेत है; [isWriteProtected](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) और [isEncrypted](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) वास्तविक लेखन या पढ़ने प्रतिबंध दर्शाते हैं जो पासवर्ड या एन्क्रिप्शन पर निर्भर होते हैं।