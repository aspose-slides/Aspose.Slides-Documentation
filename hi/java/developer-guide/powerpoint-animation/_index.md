---
title: Java में एनिमेशन के साथ PowerPoint प्रस्तुतियों को बेहतर बनाएं
linktitle: PowerPoint एनिमेशन
type: docs
weight: 150
url: /hi/java/powerpoint-animation/
keywords:
- एनिमेशन जोड़ें
- एनिमेशन अपडेट करें
- एनिमेशन बदलें
- एनिमेशन हटाएँ
- एनिमेशन प्रबंधित करें
- एनिमेशन नियंत्रित करें
- एनिमेशन इफ़ेक्ट
- PowerPoint एनिमेशन
- एनिमेशन टाइमलाइन
- इंटरएक्टिव एनिमेशन
- कस्टम एनिमेशन
- शेप एनिमेशन
- एनिमेटेड चार्ट
- एनिमेटेड टेक्स्ट
- एनिमेटेड शेप
- एनिमेटेड OLE ऑब्जेक्ट
- एनिमेटेड इमेज
- एनिमेटेड टेबल
- PowerPoint
- प्रेज़ेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java की PowerPoint एनिमेशन को संभालने की क्षमताओं का अन्वेषण करें। यह सामान्य अवलोकन प्रमुख विशेषताओं को उजागर करता है और आपकी प्रस्तुतियों को बेहतर बनाने के लिए अंतर्दृष्टि प्रदान करता है।"
---
## **परिचय**

चूँकि प्रस्तुतियाँ कुछ प्रस्तुत करने के लिए बनाई जाती हैं, इसलिए उनके दृश्य रूप और इंटरैक्टिव व्यवहार को निर्माण के दौरान हमेशा ध्यान में रखा जाता है।

**PowerPoint animation** प्रस्तुति को आकर्षक और दर्शकों के लिए सम्मोहक बनाने में महत्वपूर्ण भूमिका निभाता है। Aspose.Slides प्रस्तुतियों में एनिमेशन जोड़ने के लिए विभिन्न विकल्प प्रदान करता है:

- आकार, चार्ट, तालिकाएँ, OLE ऑब्जेक्ट और अन्य प्रस्तुति तत्वों पर विभिन्न प्रकार के PowerPoint animation प्रभाव लागू करें।
- एकल आकार पर कई PowerPoint animation प्रभाव उपयोग करें।
- एनिमेशन टाइमलाइन का उपयोग करके प्रभावों को नियंत्रित करें।
- कस्टम एनिमेशन बनाएँ।

Aspose.Slides में विभिन्न एनिमेशन प्रभाव आकारों पर लागू किए जा सकते हैं। स्लाइड पर प्रत्येक तत्व, जिसमें पाठ, चित्र, OLE ऑब्जेक्ट और तालिकाएँ शामिल हैं, को आकार माना जाता है, इसलिए एनिमेशन प्रभाव स्लाइड के किसी भी तत्व पर लागू किए जा सकते हैं।

## **एनिमेशन प्रभाव**
Aspose.Slides **150+ एनीमेशन प्रभाव** का समर्थन करता है, जिसमें बुनियादी प्रभाव जैसे Bounce, PathFootball, Zoom प्रभाव और विशिष्ट प्रभाव जैसे OLEObjectShow, OLEObjectOpen शामिल हैं। आप एनीमेशन प्रभावों की पूरी सूची [**EffectType**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/effecttype/) enumeration में पा सकते हैं।

इसके अतिरिक्त, इन एनीमेशन प्रभावों को एक साथ उपयोग किया जा सकता है:
- [ColorEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SetEffect)

## **कस्टम एनीमेशन**
Aspose.Slides में आप अपनी स्वयं की **कस्टम एनीमेशन** बना सकते हैं। यह तब संभव होता है जब आप कई व्यवहारों को मिलाकर एक नया कस्टम एनीमेशन बनाते हैं।

[**Behavior**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Behavior) किसी भी PowerPoint एनीमेशन प्रभाव की निर्माण इकाई है। सभी एनीमेशन प्रभाव वास्तविक रूप में व्यवहारों का सेट होते हैं जो एक रणनीति में सम्मिलित होते हैं। आप एक बार व्यवहारों को कस्टम एनीमेशन में जोड़ सकते हैं और इसे अन्य प्रस्तुतियों में पुन: उपयोग कर सकते हैं। यदि आप एक मानक PowerPoint एनीमेशन प्रभाव में नया व्यवहार जोड़ते हैं - वह एक अन्य कस्टम एनीमेशन बन जाएगा। उदाहरण के लिए, आप एनीमेशन में दोहराव व्यवहार जोड़ सकते हैं जिससे वह कई बार दोहराया जाए।

[**Animation Point**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Point) वह बिंदु है जहाँ व्यवहार लागू किया जाना चाहिए।

## **एनीमेशन टाइमलाइन**
[**Sequence**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Sequence) एनीमेशन प्रभावों का संग्रह है, जो एक विशिष्ट आकार पर लागू होता है।

[**Timeline**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/AnimationTimeLine) एक स्लाइड में उपयोग किए जाने वाले Sequences का समूह है। यह PowerPoint 2002 से प्रस्तुत किया गया एनीमेशन इंजन है। पिछले PowerPoint संस्करणों में प्रस्तुतियों में एनीमेशन प्रभाव जोड़ना कठिन था, जो केवल विभिन्न वर्कअराउंड से संभव था। टाइमलाइन ने पुराने AnimationSettings क्लास को प्रतिस्थापित किया और PowerPoint एनीमेशन के लिए अधिक स्पष्ट ऑब्जेक्ट मॉडल प्रदान किया। एक स्लाइड में केवल एक एनीमेशन टाइमलाइन हो सकता है।

## **इंटरएक्टिव एनीमेशन**
[**Trigger**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/EffectTriggerType) उपयोगकर्ता क्रियाओं (जैसे बटन क्लिक) को परिभाषित करने की अनुमति देता है, जिससे कोई विशिष्ट एनीमेशन शुरू हो सके। ट्रिगर केवल नवीनतम PowerPoint संस्करण में जोड़े गए हैं।

## **शेप एनीमेशन**
Aspose.Slides आपको शैप पर एनीमेशन लागू करने देता है, जो वास्तविक रूप में टेक्स्ट, आयत, रेखा, फ्रेम, OLE ऑब्जेक्ट आदि हो सकते हैं।

{{% alert color="info" %}} 
और पढ़ें [**Shape एनीमेशन के बारे में**](/slides/hi/java/shape-animation/).
{{% /alert %}}

## **एनिमेटेड चार्ट्स**
एनिमेटेड चार्ट बनाने के लिए, आपको शैप के समान सभी क्लासों का उपयोग करना चाहिए। हालांकि, PowerPoint एनीमेशन को केवल चार्ट श्रेणियों या चार्ट श्रृंखला पर ही उपयोग किया जा सकता है। आप श्रेणी तत्व या श्रृंखला तत्व पर भी एनीमेशन प्रभाव लागू कर सकते हैं।

{{% alert color="info" %}} 
और पढ़ें [**एनिमेटेड चार्ट्स के बारे में**](/slides/hi/java/animated-charts/).
{{% /alert %}}

## **एनिमेटेड टेक्स्ट**
एनिमेटेड टेक्स्ट के अलावा, पैराग्राफ पर भी एनीमेशन लागू करना संभव है।

{{% alert color="info" %}} 
और पढ़ें [**एनिमेटेड टेक्स्ट के बारे में**](/slides/hi/java/animated-text/).
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या PDF में निर्यात करते समय एनीमेशन संरक्षित रहेंगे?
No. PDF एक स्थिर प्रारूप है, इसलिए एनीमेशन और [slide transitions](/slides/hi/java/slide-transition/) नहीं चलते। यदि आपको गति चाहिए, तो इसके बजाय [HTML5](/slides/hi/java/export-to-html5/), [animated GIF](/slides/hi/java/convert-powerpoint-to-animated-gif/), या [video](/slides/hi/java/convert-powerpoint-to-video/) में निर्यात करें।

### क्या मैं एनीमेटेड प्रस्तुति को वीडियो में बदल सकता हूँ और फ्रेम रेट और फ्रेम आकार नियंत्रित कर सकता हूँ?
Yes. आप [प्रस्तुति को फ्रेम्स के रूप में रेंडर करें](/slides/hi/java/convert-powerpoint-to-video/) कर सकते हैं और उन्हें वीडियो में एन्कोड कर सकते हैं (उदाहरण के लिए ffmpeg के द्वारा), FPS और रिजॉल्यूशन चुनते हुए। रेंडरिंग के दौरान एनीमेशन और स्लाइड ट्रांज़िशन चलाए जाते हैं।

### क्या ODP (केवल PPTX नहीं) के साथ काम करते समय एनीमेशन अपरिवर्तित रहेंगे?
PPT, PPTX और ODP को [reading](/slides/hi/java/open-presentation/) और [writing](/slides/hi/java/save-presentation/) के लिए समर्थित किया गया है, लेकिन फ़ॉर्मेट अंतर के कारण कुछ प्रभाव थोड़े अलग दिख या व्यवहार कर सकते हैं। महत्वपूर्ण मामलों को वास्तविक नमूनों से सत्यापित करें।