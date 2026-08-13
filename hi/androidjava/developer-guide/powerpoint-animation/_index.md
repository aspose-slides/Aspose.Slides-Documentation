---
title: एंड्रॉइड पर एनीमेशन्स के साथ PowerPoint प्रस्तुतियों को बेहतर बनाएं
linktitle: PowerPoint एनीमेशन
type: docs
weight: 150
url: /hi/androidjava/powerpoint-animation/
keywords:
- एनीमेशन जोड़ें
- एनीमेशन अपडेट करें
- एनीमेशन बदलें
- एनीमेशन हटाएं
- एनीमेशन प्रबंधित करें
- एनीमेशन नियंत्रित करें
- एनीमेशन इफ़ेक्ट
- PowerPoint एनीमेशन
- एनीमेशन टाइमलाइन
- इंटरैक्टिव एनीमेशन
- कस्टम एनीमेशन
- शेप एनीमेशन
- एनिमेटेड चार्ट
- एनिमेटेड टेक्स्ट
- एनिमेटेड शेप
- एनिमेटेड OLE ऑब्जेक्ट
- एनिमेटेड इमेज
- एनिमेटेड टेबल
- PowerPoint
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java द्वारा PowerPoint एनीमेशन्स को संभालने की क्षमताओं का अन्वेषण करें। यह सामान्य अवलोकन प्रमुख सुविधाओं को उजागर करता है।"
---
## **परिचय**

चूंकि प्रस्तुतियों का उद्देश्य कुछ प्रस्तुत करना होता है, इसलिए उन्हें बनाते समय उनकी दृश्य उपस्थिति और इंटरैक्टिव व्यवहार हमेशा ध्यान में रखा जाता है।

**PowerPoint animation** प्रस्तुति को दर्शकों के लिए आकर्षक और आकर्षक बनाने में महत्वपूर्ण भूमिका निभाता है। Aspose.Slides for Android via Java प्रस्तुतियों में एनीमेशन जोड़ने के लिए कई विकल्प प्रदान करता है:

- आकृतियों, चार्ट, तालिकाओं, OLE ऑब्जेक्ट्स और अन्य प्रस्तुति तत्वों पर विभिन्न प्रकार के PowerPoint एनीमेशन इफ़ेक्ट लागू करें।
- एक आकृति पर कई PowerPoint एनीमेशन इफ़ेक्ट का उपयोग करें।
- एनीमेशन इफ़ेक्ट को नियंत्रित करने के लिए एनीमेशन टाइमलाइन का उपयोग करें।
- कस्टम एनीमेशन बनाएं।

Aspose.Slides for Android via Java में, विभिन्न एनीमेशन इफ़ेक्ट को आकृतियों पर लागू किया जा सकता है। स्लाइड पर टेक्स्ट, चित्र, OLE ऑब्जेक्ट, तालिका आदि सहित हर तत्व को आकृति माना जाता है, इसका मतलब है कि हम स्लाइड के प्रत्येक तत्व पर एनीमेशन इफ़ेक्ट लागू कर सकते हैं।

## **एनीमेशन इफ़ेक्ट्स**

Aspose.Slides **150+ एनीमेशन इफ़ेक्ट** का समर्थन करता है, जिसमें बाउंस, PathFootball, ज़ूम इफ़ेक्ट जैसे बुनियादी एनीमेशन इफ़ेक्ट और OLEObjectShow, OLEObjectOpen जैसे विशिष्ट एनीमेशन इफ़ेक्ट शामिल हैं। आप एनीमेशन इफ़ेक्ट की पूरी सूची [**EffectType**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effecttype/)enumeration में पा सकते हैं।

इसके अतिरिक्त, इन एनीमेशन इफ़ेक्ट को उनके साथ संयोजन में उपयोग किया जा सकता है:

- [ColorEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SetEffect)

## **कस्टम एनीमेशन**

Aspose.Slides में आप अपने स्वयं के **कस्टम एनीमेशन** बना सकते हैं। यह तब संभव होता है जब आप कई व्यवहारों को मिलाकर एक नया कस्टम एनीमेशन बनाते हैं।

[**Behavior**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Behavior) किसी भी PowerPoint एनीमेशन इफ़ेक्ट की बिल्डिंग यूनिट है। सभी एनीमेशन इफ़ेक्ट मूल रूप से व्यवहारों का एक सेट होते हैं जो एक रणनीति में संयोजित होते हैं। आप व्यवहारों को एक बार कस्टम एनीमेशन में मिलाकर इसे अन्य प्रस्तुतियों में पुन: उपयोग कर सकते हैं। यदि आप एक मानक PowerPoint एनीमेशन इफ़ेक्ट में नया व्यवहार जोड़ते हैं - तो वह एक अन्य कस्टम एनीमेशन बन जाता है। उदाहरण के लिए, आप एनीमेशन में रिपीट व्यवहार जोड़ सकते हैं जिससे वह कई बार दोहराया जा सके।

[**Animation Point**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Point) वह बिंदु है जहाँ व्यवहार लागू होना चाहिए।

## **एनीमेशन टाइमलाइन**

[**Sequence**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Sequence) एनीमेशन इफ़ेक्ट का संग्रह है, जो किसी विशिष्ट आकृति पर लागू होता है।

[**Timeline**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/AnimationTimeLine) एक स्लाइड में उपयोग की जाने वाली सीक्वेंस का सेट है। यह PowerPoint 2002 से एक एनीमेशन इंजन के रूप में मौजूद है। पिछले PowerPoint संस्करणों में प्रस्तुति में एनीमेशन इफ़ेक्ट जोड़ना कठिन था, जिसे केवल विभिन्न वर्कअराउंड्स से ही हासिल किया जा सकता था। टाइमलाइन ने पुराने AnimationSettings क्लास को बदलकर PowerPoint एनीमेशन के लिए अधिक स्पष्ट ऑब्जेक्ट मॉडल प्रदान किया है। एक स्लाइड में केवल एक एनीमेशन टाइमलाइन हो सकती है।

## **इंटरऐक्टिव एनीमेशन**

[**Trigger**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/EffectTriggerType) उपयोगकर्ता क्रियाओं (उदा. बटन क्लिक) को परिभाषित करने की अनुमति देता है, जो किसी विशेष एनीमेशन को प्रारंभ करेगा। ट्रिगर केवल नवीनतम PowerPoint संस्करण में जोड़े गए हैं।

## **शेप एनीमेशन**

Aspose.Slides आपको आकृतियों पर एनीमेशन लागू करने की अनुमति देता है, जो वास्तव में टेक्स्ट, आयत, रेखा, फ़्रेम, OLE ऑब्जेक्ट आदि हो सकते हैं।

{{% alert color="info" %}} 
और पढ़ें [**शेप एनीमेशन के बारे में**](/slides/hi/androidjava/shape-animation/).
{{% /alert %}}

## **एनिमेटेड चार्ट्स**

एनिमेटेड चार्ट बनाने के लिए, आपको आकृतियों के लिए उपयोग किए जाने वाले सभी क्लासेज़ का उपयोग करना चाहिए। हालांकि, PowerPoint एनीमेशन को केवल चार्ट श्रेणियों या चार्ट सीरीज पर उपयोग किया जा सकता है। आप श्रेणी तत्व या सीरीज़ तत्व पर भी एनीमेशन इफ़ेक्ट लागू कर सकते हैं।

{{% alert color="info" %}} 
और पढ़ें [**एनिमेटेड चार्ट्स के बारे में**](/slides/hi/androidjava/animated-charts/).
{{% /alert %}}

## **एनिमेटेड टेक्स्ट**

एनिमेटेड टेक्स्ट के अलावा, पैराग्राफ पर भी एनीमेशन लागू करना संभव है।

{{% alert color="info" %}} 
और पढ़ें [**एनिमेटेड टेक्स्ट के बारे में**](/slides/hi/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

### क्या एनीमेशन PDF में निर्यात करते समय संरक्षित रहेंगे?

नहीं। PDF एक स्थिर प्रारूप है, इसलिए एनीमेशन और [slide transitions](/slides/hi/androidjava/slide-transition/) नहीं चलते। यदि आपको गति चाहिए, तो इसके बजाय [HTML5](/slides/hi/androidjava/export-to-html5/), [animated GIF](/slides/hi/androidjava/convert-powerpoint-to-animated-gif/), या [video](/slides/hi/androidjava/convert-powerpoint-to-video/) में निर्यात करें।

### क्या मैं एनिमेटेड प्रस्तुति को वीडियो में बदल सकता हूँ और फ्रेम रेट व फ्रेम आकार को नियंत्रण में रख सकता हूँ?

हां। आप [presentation को फ़्रेम्स के रूप में रेंडर](/slides/hi/androidjava/convert-powerpoint-to-video/) कर सकते हैं और उन्हें वीडियो (जैसे ffmpeg द्वारा) में एन्कोड कर सकते हैं, FPS और रिज़ॉल्यूशन चुनते हुए। रेंडरिंग के दौरान एनीमेशन और स्लाइड ट्रांज़िशन चलाए जाते हैं।

### क्या ODP (केवल PPTX नहीं) के साथ काम करते समय एनीमेशन बरकरार रहेंगे?

PPT, PPTX, और ODP को [पढ़ना](/slides/hi/androidjava/open-presentation/) और [लिखना](/slides/hi/androidjava/save-presentation/) के लिए समर्थन किया जाता है, लेकिन फ़ॉर्मेट अंतर के कारण कुछ इफ़ेक्ट थोड़ा अलग दिख सकते हैं या अलग व्यवहार कर सकते हैं। वास्तविक नमूनों के साथ महत्वपूर्ण केसों को सत्यापित करें।