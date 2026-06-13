---
title: PHP में एनीमेशन के साथ PowerPoint प्रस्तुतियों को बेहतर बनाएं
linktitle: PowerPoint एनीमेशन
type: docs
weight: 150
url: /hi/php-java/powerpoint-animation/
keywords:
- एनीमेशन जोड़ें
- एनीमेशन अपडेट करें
- एनीमेशन बदलें
- एनीमेशन हटाएँ
- एनीमेशन प्रबंधित करें
- एनीमेशन नियंत्रित करें
- एनीमेशन इफ़ेक्ट
- PowerPoint एनीमेशन
- एनीमेशन टाइमलाइन
- इंटरैक्टिव एनीमेशन
- कस्टम एनीमेशन
- आकृति एनीमेशन
- एनिमेटेड चार्ट
- एनिमेटेड टेक्स्ट
- एनिमेटेड आकृति
- एनिमेटेड OLE ऑब्जेक्ट
- एनिमेटेड इमेज
- एनिमेटेड टेबल
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP के लिए Aspose.Slides via Java की PowerPoint एनीमेशन को संभालने की क्षमताओं का अन्वेषण करें। आपकी प्रस्तुतियों को बेहतर बनाने के लिए प्रमुख विशेषताएँ और जानकारी।"
---
## **परिचय**

क्योंकि प्रस्तुतियों का उद्देश्य कुछ प्रस्तुत करना होता है, इसलिए उन्हें बनाते समय उनका दृश्य स्वरूप और इंटरैक्टिव व्यवहार हमेशा विचार में रखा जाता है।

**PowerPoint animation** प्रस्तुति को दर्शकों के लिए आकर्षक और आकर्षक बनाने में एक महत्वपूर्ण भूमिका निभाता है। Aspose.Slides for PHP via Java PowerPoint प्रस्तुति में एनीमेशन जोड़ने के लिए विविध विकल्प प्रदान करता है:

- shapes, charts, tables, OLE Objects और अन्य प्रस्तुति तत्वों पर विभिन्न प्रकार के PowerPoint एनीमेशन इफ़ेक्ट लागू करें।
- एक shape पर कई PowerPoint एनीमेशन इफ़ेक्ट्स का उपयोग करें।
- एनीमेशन इफ़ेक्ट्स को नियंत्रित करने के लिए एनीमेशन टाइमलाइन का उपयोग करें।
- कस्टम एनीमेशन बनाएं।

Aspose.Slides for PHP via Java में विभिन्न एनीमेशन इफ़ेक्ट्स को shapes पर लागू किया जा सकता है। स्लाइड पर प्रत्येक तत्व, जिसमें टेक्स्ट, चित्र, OLE Object, टेबल आदि शामिल हैं, को shape माना जाता है, जिसका अर्थ है कि हम स्लाइड के प्रत्येक तत्व पर एनीमेशन इफ़ेक्ट लगा सकते हैं।

## **एनीमेशन इफ़ेक्ट्स**
Aspose.Slides **150+ एनीमेशन इफ़ेक्ट्स** का समर्थन करता है, जिसमें बुनियादी एनीमेशन इफ़ेक्ट्स जैसे Bounce, PathFootball, Zoom इफ़ेक्ट और विशिष्ट एनीमेशन इफ़ेक्ट्स जैसे OLEObjectShow, OLEObjectOpen शामिल हैं। आप एनीमेशन इफ़ेक्ट्स की पूरी सूची [**EffectType**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effecttype/) एनेमरेशन में पा सकते हैं।

इसके अतिरिक्त, इन एनीमेशन इफ़ेक्ट्स को एक साथ उपयोग किया जा सकता है:
- [ColorEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/SetEffect)

## **कस्टम एनीमेशन**
Aspose.Slides में आप अपनी स्वयं की **कस्टम एनीमेशन** बना सकते हैं। यह तब संभव होता है जब आप कई व्यवहारों को मिलाकर एक नया कस्टम एनीमेशन बनाते हैं।

[**Behavior**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Behavior) किसी भी PowerPoint एनीमेशन इफ़ेक्ट की बुनियादी इकाई है। सभी एनीमेशन इफ़ेक्ट्स वास्तव में व्यवहारों का एक सेट होते हैं जो एक रणनीति में संयोजित होते हैं। आप व्यवहारों को एक बार कस्टम एनीमेशन में जोड़ सकते हैं और इसे अन्य प्रस्तुतियों में पुन: उपयोग कर सकते हैं। यदि आप किसी मानक PowerPoint एनीमेशन इफ़ेक्ट में नया व्यवहार जोड़ते हैं - तो वह एक और कस्टम एनीमेशन बन जाता है। उदाहरण के लिए, आप एनीमेशन में रिपीट व्यवहार जोड़ सकते हैं ताकि वह कुछ बार दोहराए।

[**Animation Point**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Point) वह बिंदु है जहाँ व्यवहार लागू किया जाना चाहिए।

## **एनीमेशन टाइमलाइन**
[**Sequence**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Sequence) एक निश्चित shape पर लागू एनीमेशन इफ़ेक्ट्स का संग्रह है।

[**Timeline**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/AnimationTimeLine) एक निश्चित स्लाइड में उपयोग किए जाने वाले Sequences का सेट है। यह PowerPoint 2002 से मौजूद एनीमेशन इंजन है। पिछले PowerPoint संस्करणों में प्रस्तुति में एनीमेशन इफ़ेक्ट्स जोड़ना चुनौतीपूर्ण था, जिसे केवल विभिन्न वर्कअराउंड्स से ही संभव था। टाइमलाइन पुराने AnimationSettings क्लास को बदलने और PowerPoint एनीमेशन के लिए अधिक स्पष्ट ऑब्जेक्ट मॉडल प्रदान करने के लिए आई है। एक स्लाइड में केवल एक एनीमेशन टाइमलाइन हो सकती है।

## **इंटरैक्टिव एनीमेशन**
[**Trigger**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/EffectTriggerType) उपयोगकर्ता क्रियाओं (जैसे बटन क्लिक) को परिभाषित करने की अनुमति देता है, जिससे कोई विशेष एनीमेशन शुरू हो सके। ट्रिगर केवल नवीनतम PowerPoint संस्करण में जोड़े गए हैं।

## **शेप एनीमेशन**
Aspose.Slides shapes पर एनीमेशन लागू करने की अनुमति देता है, जो वास्तव में टेक्स्ट, आयत, रेखा, फ्रेम, OLE Object आदि हो सकते हैं।

{{% alert color="primary" %}} 
और पढ़ें [**शेप एनीमेशन के बारे में**](/slides/hi/php-java/shape-animation/).
{{% /alert %}}

## **एनिमेटेड चार्ट्स**
एनिमेटेड चार्ट्स बनाने के लिए, आपको shapes की तरह ही सभी क्लासेज़ का उपयोग करना चाहिए। हालांकि, PowerPoint एनीमेशन केवल चार्ट श्रेणियों या चार्ट सीरीज़ पर ही लागू करना संभव है। आप श्रेणी तत्व या सीरीज़ तत्व पर भी एनीमेशन इफ़ेक्ट लागू कर सकते हैं।

{{% alert color="primary" %}} 
और पढ़ें [**एनिमेटेड चार्ट्स के बारे में**](/slides/hi/php-java/animated-charts/).
{{% /alert %}}

## **एनिमेटेड टेक्स्ट**
एनिमेटेड टेक्स्ट के अलावा, आप पैराग्राफ पर भी एनीमेशन लागू कर सकते हैं।

{{% alert color="primary" %}} 
और पढ़ें [**एनिमेटेड टेक्स्ट के बारे में**](/slides/hi/php-java/animated-text/).
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एनीमेशन PDF में एक्सपोर्ट करते समय संरक्षित रहेंगे?**

नहीं। PDF एक स्थिर फ़ॉर्मेट है, इसलिए एनीमेशन और [slide transitions](/slides/hi/php-java/slide-transition/) नहीं चलेंगे। यदि आपको गति चाहिए, तो इसके बजाय [HTML5](/slides/hi/php-java/export-to-html5/), [animated GIF](/slides/hi/php-java/convert-powerpoint-to-animated-gif/), या [video](/slides/hi/php-java/convert-powerpoint-to-video/) में एक्सपोर्ट करें।

**क्या मैं एक एनिमेटेड प्रस्तुति को वीडियो में बदल सकता हूँ और फ्रेम रेट तथा फ्रेम साइज़ को नियंत्रित कर सकता हूँ?**

हाँ। आप प्रस्तुति को [render the presentation as frames](/slides/hi/php-java/convert-powerpoint-to-video/) कर सकते हैं और उन्हें वीडियो में एन्कोड कर सकते हैं (जैसे ffmpeg के माध्यम से), FPS और रिज़ॉल्यूशन चुनते हुए। रेंडरिंग के दौरान एनीमेशन और स्लाइड ट्रांज़िशन चलाए जाते हैं।

**क्या ODP (केवल PPTX नहीं) के साथ काम करते समय एनीमेशन बरकरार रहेंगे?**

PPT, PPTX, और ODP को [reading](/slides/hi/php-java/open-presentation/) और [writing](/slides/hi/php-java/save-presentation/) के लिए सपोर्ट किया जाता है, लेकिन फ़ॉर्मेट अंतर के कारण कुछ इफ़ेक्ट्स थोड़े अलग दिखाई या व्यवहार कर सकते हैं। महत्वपूर्ण मामलों को वास्तविक नमूनों से वैलिडेट करें।