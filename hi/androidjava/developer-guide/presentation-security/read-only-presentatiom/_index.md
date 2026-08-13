---
title: Android पर Read-Only मोड में प्रस्तुतियों को सहेजें
linktitle: Read-Only प्रस्तुति
type: docs
weight: 30
url: /hi/androidjava/read-only-presentation/
keywords:
- केवल पढ़ने का
- प्रस्तुति सुरक्षित करें
- संपादन रोकें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint फ़ाइलें (PPT, PPTX) को केवल-पढ़ने मोड में सहेजें, जो आपकी प्रस्तुतियों को बदले बिना सटीक स्लाइड पूर्वावलोकन प्रदान करती हैं।"
---
## **परिचय**

PowerPoint 2019 में, Microsoft ने **Always Open Read-Only** सेटिंग को यूज़र्स के लिए एक विकल्प के रूप में पेश किया जिससे वे अपनी प्रस्तुतियों की सुरक्षा कर सकते हैं। आप इस Read-Only सेटिंग का उपयोग तब कर सकते हैं जब

- आप आकस्मिक संशोधनों को रोकना चाहते हैं और अपनी प्रस्तुति की सामग्री को सुरक्षित रखना चाहते हैं। 
- आप लोगों को यह सूचित करना चाहते हैं कि आपके द्वारा प्रदान की गई प्रस्तुति अंतिम संस्करण है। 

जब आप किसी प्रस्तुति के लिए **Always Open Read-Only** विकल्प चुनते हैं, तो उपयोगकर्ता जब प्रस्तुति खोलते हैं, तो उन्हें **Read-Only** सिफारिश दिखाई देती है और वे इस प्रकार का संदेश देख सकते हैं: *अकस्मिक बदलावों को रोकने के लिए, लेखक ने इस फ़ाइल को केवल‑पढ़ने के रूप में खोलने के लिए सेट किया है।*

Read-Only सिफारिश एक सरल लेकिन प्रभावी निरोधक है जो संपादन को हतोत्साहित करता है क्योंकि उपयोगकर्ताओं को प्रस्तुति को संपादित करने से पहले इसे हटाने के लिए एक कदम उठाना पड़ता है। यदि आप नहीं चाहते कि उपयोगकर्ता प्रस्तुति में परिवर्तन करें और इसे विनम्रता से बताना चाहते हैं, तो Read-Only सिफारिश आपके लिए एक अच्छा विकल्प हो सकता है। 

> यदि **Read-Only** सुरक्षा वाली प्रस्तुति को किसी पुरानी Microsoft PowerPoint एप्लिकेशन में खोला जाता है—जो हाल ही में पेश की गई फ़ंक्शन को सपोर्ट नहीं करता—तो **Read-Only** सिफारिश को नजरअंदाज कर दिया जाता है (प्रेजेंटेशन सामान्य रूप से खुल जाता है)।

## **Read-Only मोड लागू करें**

Aspose.Slides for Android via Java आपको प्रस्तुति को **Read-Only** सेट करने की अनुमति देता है, जिससे उपयोगकर्ता (प्रस्तुति खोलने के बाद) **Read-Only** सिफारिश देखते हैं। यह नमूना कोड दिखाता है कि Java में Aspose.Slides का उपयोग करके प्रस्तुति को **Read-Only** कैसे सेट किया जाता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**नोट**: **Read-Only** सिफारिश केवल प्रस्तुति को संपादित करने या आकस्मिक बदलावों को रोकने के लिए एक निरोधक के रूप में दी गई है। यदि कोई जानकार व्यक्ति—जो अपनी हरकतों से परिचित है—आपकी प्रस्तुति को संपादित करने का निर्णय लेता है, तो वह आसानी से Read-Only सेटिंग हटा सकता है। यदि आपको अनधिकृत संपादन को रोकने की गंभीर आवश्यकता है, तो आप [एन्क्रिप्शन और पासवर्ड शामिल करने वाली अधिक कड़ी सुरक्षा](https://docs.aspose.com/slides/hi/androidjava/password-protected-presentation/) का उपयोग करना बेहतर रहेगा।

{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

### 'Read-Only recommended' और पूर्ण पासवर्ड सुरक्षा में क्या अंतर है?

'Read-Only recommended' केवल फ़ाइल को केवल‑पढ़ने के मोड में खोलने का सुझाव देता है और इसे आसानी से बायपास किया जा सकता है। [पासवर्ड सुरक्षा](/slides/hi/androidjava/password-protected-presentation/) वास्तव में खोलने या संपादित करने पर प्रतिबंध लगाती है और वास्तविक सुरक्षा नियंत्रणों की आवश्यकता होने पर उपयुक्त है।

### क्या 'Read-Only recommended' को वॉटरमार्क के साथ जोड़कर संपादन को और अधिक हतोत्साहित किया जा सकता है?

हां। इस सिफारिश को [वॉटरमार्क](/slides/hi/androidjava/watermark/) के साथ जोड़ा जा सकता है जिससे दृश्य निरोधक बनता है; यह अलग‑अलग तंत्र हैं और साथ में अच्छी तरह कार्य करते हैं।

### क्या अनुशंसा सक्षम होने पर भी मैक्रो या बाहरी टूल फ़ाइल को संशोधित कर सकते हैं?

हां। यह सिफारिश प्रोग्रामेटिक बदलावों को ब्लॉक नहीं करती। स्वचालित संपादन को रोकने के लिए [पासवर्ड और एन्क्रिप्शन](/slides/hi/androidjava/password-protected-presentation/) का प्रयोग करें।

### 'Read-Only recommended' का 'isEncrypted' और 'isWriteProtected' विधियों के साथ क्या संबंध है?

वे अलग संकेतक हैं। 'Read-Only recommended' एक सौम्य, वैकल्पिक प्रॉम्प्ट है; [isWriteProtected](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) और [isEncrypted](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) वास्तविक लिखने या पढ़ने की प्रतिबंधों को दर्शाते हैं जो पासवर्ड या एन्क्रिप्शन पर निर्भर होते हैं।