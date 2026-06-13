---
title: Android पर एनीमेशन के साथ PowerPoint प्रस्तुतियों को बेहतर बनाएं
linktitle: PowerPoint एनीमेशन
type: docs
weight: 150
url: /hi/androidjava/powerpoint-animation/
keywords:
- एनीमेशन जोड़ें
- एनीमेशन अपडेट करें
- एनीमेशन बदलें
- एनीमेशन हटाएं
- एनीमेशन प्रबंधन करें
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
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Android पर Java के माध्यम से Aspose.Slides की PowerPoint एनीमेशन संभालने की क्षमताओं का अन्वेषण करें। यह सामान्य अवलोकन प्रमुख विशेषताओं को उजागर करता है।"
---
## **परिचय**

चूंकि प्रस्तुतियों का उद्देश्य कुछ प्रस्तुत करना है, इसलिए उन्हें बनाते समय उनके दृश्य स्वरूप और इंटरेक्टिव व्यवहार को हमेशा ध्यान में रखा जाता है।

**PowerPoint animation** प्रस्तुतियों को दर्शकों के लिए आकर्षक और ध्यान आकर्षित करने वाला बनाने में महत्वपूर्ण भूमिका निभाता है। Aspose.Slides for Android via Java PowerPoint प्रस्तुति में एनीमेशन जोड़ने के लिए विविध विकल्प प्रदान करता है:

- विभिन्न प्रकार के PowerPoint एनीमेशन इफ़ेक्ट्स को shapes, charts, tables, OLE Objects और अन्य प्रस्तुति तत्वों पर लागू करें।
- एक shape पर कई PowerPoint एनीमेशन इफ़ेक्ट्स का उपयोग करें।
- एनीमेशन इफ़ेक्ट्स को नियंत्रित करने के लिए animation timeline का उपयोग करें।
- कस्टम एनीमेशन बनाएं।

Aspose.Slides for Android via Java में विभिन्न एनीमेशन इफ़ेक्ट्स को shapes पर लागू किया सकता है। स्लाइड पर प्रत्येक तत्व जिसमें टेक्स्ट, चित्र, OLE Object, टेबल आदि शामिल हैं, को shape माना जाता है, इसलिए हम स्लाइड के हर तत्व पर एनीमेशन इफ़ेक्ट लागू कर सकते हैं।

## **एनीमेशन इफ़ेक्ट्स**

Aspose.Slides **150+ एनीमेशन इफ़ेक्ट्स** का समर्थन करता है, जिसमें बेसिक एनीमेशन इफ़ेक्ट्स जैसे Bounce, PathFootball, Zoom इफ़ेक्ट और विशिष्ट एनीमेशन इफ़ेक्ट्स जैसे OLEObjectShow, OLEObjectOpen शामिल हैं। आप एनीमेशन इफ़ेक्ट्स की पूरी सूची [**EffectType**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/effecttype/) enumeration में पा सकते हैं।

इसके अतिरिक्त, इन एनीमेशन इफ़ेक्ट्स को उनके साथ संयोजन में उपयोग किया जा सकता है:

- [ColorEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SetEffect)

## **कस्टम एनीमेशन**

Aspose.Slides में आप अपनी स्वयं की **कस्टम एनीमेशन** बना सकते हैं। यह तब संभव होता है जब आप कई behaviours को मिलाकर एक नया कस्टम एनीमेशन बनाते हैं।

[**Behavior**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Behavior) किसी भी PowerPoint एनीमेशन इफ़ेक्ट की बिल्डिंग यूनिट है। सभी एनीमेशन इफ़ेक्ट्स मूलतः behaviours का एक सेट होते हैं जो एक रणनीति में संयोजित होते हैं। आप behaviours को एक बार कस्टम एनीमेशन में मिलाकर अन्य प्रस्तुतियों में पुन: उपयोग कर सकते हैं। यदि आप किसी मानक PowerPoint एनीमेशन इफ़ेक्ट में नया behaviour जोड़ते हैं - वह एक और कस्टम एनीमेशन बन जाता है। उदाहरण के रूप में, आप एनीमेशन में repeat behaviour जोड़ सकते हैं जिससे वह बहु बार दोहराया जा सके।

[**Animation Point**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Point) वह बिंदु है जहाँ behaviour लागू किया जाना चाहिए।

## **एनीमेशन टाइमलाइन**

[**Sequence**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Sequence) एनीमेशन इफ़ेक्ट्स का एक संग्रह है, जो किसी विशेष shape पर लागू होता है।

[**Timeline**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/AnimationTimeLine) एक विशिष्ट स्लाइड में उपयोग किए गए Sequences का सेट है। यह PowerPoint 2002 से प्रस्तुत किया गया एनीमेशन इंजन है। पिछले PowerPoint संस्करणों में एनीमेशन इफ़ेक्ट्स जोड़ना चुनौतीपूर्ण था, जिसे केवल विभिन्न वर्कअराउंड के माध्यम से संभव था। Timeline ने पुराने AnimationSettings क्लास को बदल दिया है और PowerPoint एनीमेशन के लिए अधिक स्पष्ट ऑब्जेक्ट मॉडल प्रदान किया है। एक स्लाइड में केवल एक एनीमेशन टाइमलाइन हो सकती है।

## **इंटरैक्टिव एनीमेशन**

[**Trigger**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/EffectTriggerType) उपयोगकर्ता क्रियाओं (जैसे बटन क्लिक) को परिभाषित करने की सुविधा देता है, जिससे कोई विशेष एनीमेशन शुरू होता है। Triggers केवल नवीनतम PowerPoint संस्करण में जोड़े गए हैं।

## **शेप एनीमेशन**

Aspose.Slides आपको shapes पर एनीमेशन लागू करने की अनुमति देता है, जो वास्तव में टेक्स्ट, आयत, रेखा, फ्रेम, OLE Object आदि हो सकते हैं।

{{% alert color="primary" %}} 
और पढ़ें [**Shape Animation के बारे में**](/slides/hi/androidjava/shape-animation/).
{{% /alert %}}

## **एनिमेटेड चार्ट्स**

एनिमेटेड चार्ट्स बनाने के लिए आपको shapes के लिए उपयोग की जाने वाली वही सभी कक्षाओं का उपयोग करना चाहिए। हालांकि, PowerPoint एनीमेशन को केवल चार्ट श्रेणियों या चार्ट श्रृंखलाओं पर लागू किया जा सकता है। आप किसी श्रेणी तत्व या श्रृंखला तत्व पर भी एनीमेशन इफ़ेक्ट लागू कर सकते हैं।

{{% alert color="primary" %}} 
और पढ़ें [**एनिमेटेड चार्ट्स के बारे में**](/slides/hi/androidjava/animated-charts/).
{{% /alert %}}

## **एनिमेटेड टेक्स्ट**

एनिमेटेड टेक्स्ट के अलावा, पैराग्राफ पर भी एनीमेशन लागू करना संभव है।

{{% alert color="primary" %}} 
और पढ़ें [**एनिमेटेड टेक्स्ट के बारे में**](/slides/hi/androidjava/animated-text/).
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एनीमेशन को PDF में एक्सपोर्ट करने पर भी संरक्षित रखा जाएगा?**

नहीं। PDF एक स्थैतिक स्वरूप है, इसलिए एनीमेशन और [slide transitions](/slides/hi/androidjava/slide-transition/) नहीं चलते। यदि आपको गति चाहिए, तो इसके बजाय [HTML5](/slides/hi/androidjava/export-to-html5/), [animated GIF](/slides/hi/androidjava/convert-powerpoint-to-animated-gif/), या [video](/slides/hi/androidjava/convert-powerpoint-to-video/) में एक्सपोर्ट करें।

**क्या मैं एनिमेटेड प्रस्तुति को वीडियो में बदल सकता हूँ और फ्रेम रेट तथा फ्रेम आकार को नियंत्रित कर सकता हूँ?**

हाँ। आप [render the presentation as frames](/slides/hi/androidjava/convert-powerpoint-to-video/) को फ़्रेम के रूप में रेंडर कर सकते हैं और उन्हें एक वीडियो में एन्कोड कर सकते हैं (जैसे ffmpeg द्वारा), FPS और रिज़ॉल्यूशन चुनते हुए। रेंडरिंग के दौरान एनीमेशन और स्लाइड ट्रांज़िशन चलाए जाते हैं।

**क्या ODP (केवल PPTX नहीं) के साथ काम करने पर एनीमेशन समान रहेगा?**

PPT, PPTX, और ODP को [reading](/slides/hi/androidjava/open-presentation/) और [writing](/slides/hi/androidjava/save-presentation/) के लिए समर्थन प्राप्त है, लेकिन फ़ॉर्मेट अंतर के कारण कुछ इफ़ेक्ट्स थोड़ा अलग दिख सकते हैं या व्यवहार कर सकते हैं। वास्तविक नमूनों के साथ महत्वपूर्ण मामलों को मान्य करें।