---
title: C++ का उपयोग करके पढ़ने-के-लिए मोड में प्रस्तुतियों को सहेजें
linktitle: केवल-रीड प्रस्तुति
type: docs
weight: 30
url: /hi/cpp/read-only-presentation/
keywords:
- केवल-रीड
- प्रस्तुति सुरक्षित करें
- संपादन रोकें
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint फ़ाइलों (PPT, PPTX) को पढ़ने-के-लिए मोड में लोड और सहेजें, जो आपकी प्रस्तुतियों को बदले बिना सटीक स्लाइड पूर्वावलोकन प्रदान करता है।"
---
## **परिचय**

PowerPoint 2019 में, Microsoft ने **Always Open Read-Only** सेटिंग को प्रस्तुत किया, जो उपयोगकर्ता अपनी प्रस्तुतियों की सुरक्षा के लिए उपयोग कर सकते हैं। आप इस Read-Only सेटिंग का उपयोग तब करना चाह सकते हैं जब

- आप आकस्मिक संपादन को रोकना चाहते हैं और अपनी प्रस्तुति की सामग्री को सुरक्षित रखना चाहते हैं। 
- आप लोगों को यह सूचित करना चाहते हैं कि आप द्वारा प्रदान की गई प्रस्तुति अंतिम संस्करण है। 

जब आप प्रस्तुति के लिए **Always Open Read-Only** विकल्प चुनते हैं, तो उपयोगकर्ता प्रस्तुति खोलते समय **Read-Only** सिफ़ारिश देखते हैं और इस प्रकार का संदेश देख सकते हैं: *आकस्मिक बदलावों को रोकने के लिए, लेखक ने इस फ़ाइल को रीड़-ऑनली के रूप में खोलने के लिए सेट किया है।*

Read-Only सिफ़ारिश एक सरल लेकिन प्रभावी रोक है जो संपादन को हतोत्साहित करती है क्योंकि उपयोगकर्ताओं को प्रस्तुति को संपादित करने से पहले इसे हटाने के लिए एक कार्य करना पड़ता है। यदि आप चाहते हैं कि उपयोगकर्ता प्रस्तुति में परिवर्तन न करें और इसे शिष्टतापूर्ण तरीके से बताना चाहते हैं, तो Read-Only सिफ़ारिश आपके लिए एक अच्छा विकल्प हो सकता है। 

> यदि **Read-Only** सुरक्षा वाली प्रस्तुति को पुराने Microsoft PowerPoint एप्लिकेशन में खोला जाता है—जो हाल ही में परिचित कराए गए फ़ंक्शन का समर्थन नहीं करता—तो **Read-Only** सिफ़ारिश को अनदेखा किया जाता है (प्रस्तुति सामान्य रूप से खुलती है)।

## **Read-Only मोड लागू करें**

Aspose.Slides for C++ आपको एक प्रस्तुति को **Read-Only** सेट करने की अनुमति देता है, जिसका अर्थ है कि उपयोगकर्ता (प्रस्तुति खोलने के बाद) **Read-Only** सिफ़ारिश देखते हैं। यह नमूना कोड दिखाता है कि कैसे Aspose.Slides का उपयोग करके C++ में एक प्रस्तुति को **Read-Only** सेट किया जाए:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**Note**: **Read-Only** सिफ़ारिश केवल संपादन को हतोत्साहित करने या उपयोगकर्ताओं को PowerPoint प्रस्तुति में आकस्मिक बदलाव करने से रोकने के लिए है। यदि कोई प्रेरित व्यक्ति—जो जानता है कि वह क्या कर रहा है—आपकी प्रस्तुति को संपादित करने का निर्णय लेता है, तो वह आसानी से Read-Only सेटिंग हटा सकता है। यदि आपको अनधिकृत संपादन को गंभीरता से रोकना है, तो आप [एन्क्रिप्शन और पासवर्ड शामिल अधिक सख्त सुरक्षा उपायों](https://docs.aspose.com/slides/hi/cpp/password-protected-presentation/) का उपयोग करना बेहतर रहेगा। 

{{% /alert %}} 

## **FAQ**

### ‘Read-Only recommended’ पूर्ण पासवर्ड सुरक्षा से कैसे अलग है?

‘Read-Only recommended’ केवल फ़ाइल को केवल-रीड़ मोड में खोलने का सुझाव दर्शाता है और इसे आसानी से बायपास किया जा सकता है। [पासवर्ड सुरक्षा](/slides/hi/cpp/password-protected-presentation/) वास्तव में खोलने या संपादित करने को प्रतिबंधित करता है और यह तब उपयुक्त है जब आपको वास्तविक सुरक्षा नियंत्रणों की आवश्यकता हो। 

### क्या ‘Read-Only recommended’ को watermarks के साथ मिलाकर और अधिक संपादन को हतोत्साहित किया जा सकता है?

हाँ। इस सिफ़ारिश को [watermarks](/slides/hi/cpp/watermark/) के साथ दृश्य रोक के रूप में जोड़ा जा सकता है; ये अलग‑अलग तंत्र हैं और साथ मिलकर अच्छी तरह काम करते हैं। 

### क्या किसी मैक्रो या बाहरी टूल से सिफ़ारिश सक्षम होने पर भी फ़ाइल को संशोधित किया जा सकता है?

हाँ। यह सिफ़ारिश प्रोग्रामेटिक बदलावों को ब्लॉक नहीं करती। स्वचालित संपादन को रोकने के लिए, [पासवर्ड और एन्क्रिप्शन](/slides/hi/cpp/password-protected-presentation/) का उपयोग करें। 

### ‘Read-Only recommended’ फ्लैग्स ‘is encrypted’ और ‘is write protected’ से कैसे संबंधित है?

वे अलग संकेत हैं। ‘Read-Only recommended’ एक सौम्य, वैकल्पिक प्रॉम्प्ट है; [get_IsWriteProtected](https://reference.aspose.com/slides/hi/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) और [get_IsEncrypted](https://reference.aspose.com/slides/hi/cpp/aspose.slides/protectionmanager/get_isencrypted/) वास्तविक लिखने या पढ़ने की प्रतिबन्धों को दर्शाते हैं जो पासवर्ड या एन्क्रिप्शन पर निर्भर होते हैं।