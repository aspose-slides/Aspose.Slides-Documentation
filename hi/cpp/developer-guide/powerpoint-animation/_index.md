---
title: C++ में एनीमेशन के साथ PowerPoint प्रस्तुतियों को उन्नत बनाएं
linktitle: PowerPoint एनीमेशन
type: docs
weight: 150
url: /hi/cpp/powerpoint-animation/
keywords:
- एनीमेशन जोड़ें
- एनीमेशन अपडेट करें
- एनीमेशन बदलें
- एनीमेशन हटाएँ
- एनीमेशन प्रबंधित करें
- एनीमेशन नियंत्रित करें
- एनीमेशन प्रभाव
- PowerPoint एनीमेशन
- एनीमेशन टाइमलाइन
- इंटरैक्टिव एनीमेशन
- कस्टम एनीमेशन
- शैप एनीमेशन
- एनिमेटेड चार्ट
- एनिमेटेड टेक्स्ट
- एनिमेटेड शैप
- एनिमेटेड OLE ऑब्जेक्ट
- एनिमेटेड इमेज
- एनिमेटेड टेबल
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में उन्नत एनीमेशन प्रभाव जोड़ने और नियंत्रित करने के तरीके सीखें, ताकि गतिशील PowerPoint और OpenDocument प्रस्तुतियों का निर्माण कर सकें।"
---
## **परिचय**

चूंकि प्रस्तुतियों का उद्देश्य कुछ प्रस्तुत करना है, इसलिए उन्हें बनाते समय उनका दृश्य रूप और इंटरैक्टिव व्यवहार हमेशा ध्यान में रखा जाता है।

**PowerPoint एनीमेशन** प्रस्तुतियों को दर्शकों के लिए आकर्षक और आँखों को पकड़ने वाला बनाने में एक महत्वपूर्ण भूमिका निभाता है। Aspose.Slides for C++ PowerPoint प्रस्तुति में एनीमेशन जोड़ने के लिए कई विकल्प प्रदान करता है:

- विभिन्न प्रकार के PowerPoint एनीमेशन इफ़ेक्ट्स को शैप्स, चार्ट्स, टेबल्स, OLE ऑब्जेक्ट्स और अन्य प्रस्तुति तत्वों पर लागू करें।
- एक शैप पर कई PowerPoint एनीमेशन इफ़ेक्ट्स का प्रयोग करें।
- एनीमेशन इफ़ेक्ट्स को नियंत्रित करने के लिए एनीमेशन टाइमलाइन का उपयोग करें।
- कस्टम एनीमेशन बनाएं।

Aspose.Slides for C++ में विभिन्न एनीमेशन इफ़ेक्ट्स को शैप्स पर लागू किया जा सकता है। स्लाइड पर प्रत्येक तत्व, जैसे टेक्स्ट, चित्र, OLE ऑब्जेक्ट, टेबल आदि, को शैप माना जाता है, इसलिए हम स्लाइड के हर तत्व पर एनीमेशन इफ़ेक्ट लागू कर सकते हैं।

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides.animation) **namespace** PowerPoint एनीमेशन के साथ काम करने के लिए क्लासेस प्रदान करता है।

## **एनीमेशन इफ़ेक्ट्स**
Aspose.Slides **150+ एनीमेशन इफ़ेक्ट्स** का समर्थन करता है, जिसमें बुनियादी एनीमेशन इफ़ेक्ट्स जैसे Bounce, PathFootball, Zoom इफ़ेक्ट और विशिष्ट एनीमेशन इफ़ेक्ट्स जैसे OLEObjectShow, OLEObjectOpen शामिल हैं। आप एनीमेशन इफ़ेक्ट्स की पूरी सूची [**EffectType**](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) एनेमरेशन में पा सकते हैं।

इसके अतिरिक्त, इन एनीमेशन इफ़ेक्ट्स को एक साथ उपयोग किया जा सकता है:

- [ColorEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.set_effect)

## **कस्टम एनीमेशन**
Aspose.Slides में अपनी स्वयं की **कस्टम एनीमेशन** बनाना संभव है।  
यदि आप कई व्यवहारों को मिलाकर नया कस्टम एनीमेशन बनाते हैं तो यह प्राप्त किया जा सकता है।

[**Behavior**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.behavior) किसी भी PowerPoint एनीमेशन इफ़ेक्ट की निर्माण इकाई है। सभी एनीमेशन इफ़ेक्ट्स मूलतः व्यवहारों का सेट होते हैं जो एक रणनीति में संयोजित होते हैं। आप व्यवहारों को एक बार कस्टम एनीमेशन में जोड़ सकते हैं और इसे अन्य प्रस्तुतियों में पुनः उपयोग कर सकते हैं। यदि आप किसी मानक PowerPoint एनीमेशन इफ़ेक्ट में नया व्यवहार जोड़ते हैं - तो वह एक और कस्टम एनीमेशन बन जाता है। उदाहरण के तौर पर, आप एनीमेशन में रिपीट व्यवहार जोड़ सकते हैं ताकि वह कुछ बार दोहराए।

[**Animation Point**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.point) वह बिंदु है जहाँ व्यवहार लागू किया जाना चाहिए।

## **एनीमेशन टाइमलाइन**
[**Sequence**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.sequence) एक ठोस शैप पर लागू किए गए एनीमेशन इफ़ेक्ट्स का संग्रह है।

[**AnimationTimeLine**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.animation.animation_time_line) एक ठोस स्लाइड में उपयोग की जाने वाली सीक्वेंसेज़ का सेट है। यह PowerPoint 2002 से मौजूद एक एनीमेशन इंजन है। पिछले PowerPoint संस्करणों में प्रस्तुति में एनीमेशन इफ़ेक्ट्स जोड़ना कठिन था, जिसे केवल विभिन्न वर्कअराउंड्स के माध्यम से ही किया जा सकता था। टाइमलाइन ने पुराने AnimationSettings क्लास को प्रतिस्थापित किया और PowerPoint एनीमेशन के लिए अधिक स्पष्ट ऑब्जेक्ट मॉडल प्रदान किया। एक स्लाइड में केवल एक एनीमेशन टाइमलाइन हो सकती है।

## **इंटरएक्टिव एनीमेशन**
[**EffectTriggerType**](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) उपयोगकर्ता क्रियाएँ (जैसे बटन क्लिक) परिभाषित करने की अनुमति देता है, जो किसी विशिष्ट एनीमेशन को शुरू कराएगी। ट्रिगर्स केवल नवीनतम PowerPoint संस्करण में जोड़े गए हैं।

## **शेप एनीमेशन**
Aspose.Slides शैप्स, जो वास्तविक में टेक्स्ट, आयत, रेखा, फ्रेम, OLE ऑब्जेक्ट आदि हो सकते हैं, पर एनीमेशन लागू करने की अनुमति देता है।

{{% alert color="primary" %}} 
और पढ़ें [**शेप एनीमेशन के बारे में**](/slides/hi/cpp/shape-animation/).
{{% /alert %}}

## **एनिमेटेड चार्ट्स**
एनिमेटेड चार्ट्स बनाने के लिए आपको शैप्स के समान सभी क्लासेस का उपयोग करना चाहिए। हालांकि, PowerPoint एनीमेशन को केवल चार्ट श्रेणियों या चार्ट सीरीज पर ही उपयोग किया जा सकता है। आप श्रेणी तत्व या सीरीज़ तत्व पर भी एनीमेशन इफ़ेक्ट लागू कर सकते हैं।

{{% alert color="primary" %}} 
और पढ़ें [**एनिमेटेड चार्ट्स के बारे में**](/slides/hi/cpp/animated-charts/).
{{% /alert %}}

## **एनिमेटेड टेक्स्ट**
एनिमेटेड टेक्स्ट के अलावा, पैराग्राफ पर भी एनीमेशन लागू करना संभव है।

{{% alert color="primary" %}} 
और पढ़ें [**एनिमेटेड टेक्स्ट के बारे में**](/slides/hi/cpp/animated-text/).
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एनीमेशन PDF में निर्यात करने पर संरक्षित रहेंगे?**

नहीं। PDF एक स्थैतिक फ़ॉर्मेट है, इसलिए एनीमेशन और [स्लाइड ट्रांज़िशन](/slides/hi/cpp/slide-transition/) नहीं चलते। यदि आपको गति चाहिए, तो इसके बजाय [HTML5](/slides/hi/cpp/export-to-html5/), [एनिमेटेड GIF](/slides/hi/cpp/convert-powerpoint-to-animated-gif/), या [वीडियो](/slides/hi/cpp/convert-powerpoint-to-video/) में निर्यात करें।

**क्या मैं एनिमेटेड प्रस्तुति को वीडियो में परिवर्तित कर फ्रेम रेट और फ्रेम आकार को नियंत्रित कर सकता हूँ?**

हाँ। आप [प्रस्तुति को फ्रेम्स के रूप में रेंडर](/slides/hi/cpp/convert-powerpoint-to-video/) कर सकते हैं और उन्हें वीडियो (उदा., ffmpeg के माध्यम से) में एन्कोड कर सकते हैं, FPS और रिज़ॉल्यूशन चुनते हुए। रेंडरिंग के दौरान एनीमेशन और स्लाइड ट्रांज़िशन चलाए जाते हैं।

**क्या ODP (केवल PPTX नहीं) के साथ काम करते समय एनीमेशन वही रहेंगी?**

PPT, PPTX, और ODP को [पढ़ने](/slides/hi/cpp/open-presentation/) और [लिखने](/slides/hi/cpp/save-presentation/) के लिए सपोर्ट किया जाता है, लेकिन फ़ॉर्मेट अंतर के कारण कुछ इफ़ेक्ट्स थोड़ा अलग दिख सकते हैं या व्यवहार कर सकते हैं। महत्वपूर्ण मामलों को वास्तविक नमूनों के साथ सत्यापित करें।