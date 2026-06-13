---
title: जावास्क्रिप्ट में एनीमेशन के साथ PowerPoint प्रस्तुतियों को सुधारें
linktitle: PowerPoint एनीमेशन
type: docs
weight: 150
url: /hi/nodejs-java/powerpoint-animation/
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
- आकार एनीमेशन
- एनिमेटेड चार्ट
- एनिमेटेड टेक्स्ट
- एनिमेटेड आकार
- एनिमेटेड OLE ऑब्जेक्ट
- एनिमेटेड इमेज
- एनिमेटेड टेबल
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint एनीमेशन को संभालने के लिए Java के माध्यम से Node.js के लिए Aspose.Slides का उपयोग करें। यह अवलोकन प्रमुख विशेषताओं को उजागर करता है और आपकी प्रस्तुतियों को सुधारने के लिए अंतर्दृष्टि प्रदान करता है।"
---
## **परिचय**

चूंकि प्रस्तुतियों का उद्देश्य कुछ प्रस्तुत करना है, इसलिए उन्हें बनाते समय उनकी दृश्य उपस्थिति और इंटरैक्टिव व्यवहार को हमेशा ध्यान में रखा जाता है।

**PowerPoint एनीमेशन** दर्शकों के लिए प्रस्तुति को आकर्षक और आकर्षक बनाने के लिए महत्वपूर्ण भूमिका निभाता है। Aspose.Slides for Node.js via Java PowerPoint प्रस्तुति में एनीमेशन जोड़ने के लिए विभिन्न विकल्प प्रदान करता है:

- विभिन्न प्रकार के PowerPoint एनीमेशन प्रभावों को आकारों, चार्ट, टेबल, OLE ऑब्जेक्ट्स और अन्य प्रस्तुति तत्वों पर लागू करें।
- एक आकार पर कई PowerPoint एनीमेशन प्रभावों का उपयोग करें।
- एनीमेशन टाइमलाइन का उपयोग करके एनीमेशन प्रभावों को नियंत्रित करें।
- कस्टम एनीमेशन बनाएं।

Aspose.Slides for Node.js via Java में, विभिन्न एनीमेशन प्रभावों को आकारों पर लागू किया जा सकता है। स्लाइड पर प्रत्येक तत्व, जिसमें टेक्स्ट, चित्र, OLE ऑब्जेक्ट, टेबल आदि शामिल हैं, को आकार माना जाता है, जिसका अर्थ है कि हम स्लाइड के प्रत्येक तत्व पर एनीमेशन प्रभाव लागू कर सकते हैं।

## **एनीमेशन प्रभाव**

Aspose.Slides **150+ एनीमेशन प्रभाव** का समर्थन करता है, जिसमें Bounce, PathFootball, Zoom प्रभाव जैसी बुनियादी एनीमेशन प्रभाव और OLEObjectShow, OLEObjectOpen जैसे विशिष्ट एनीमेशन प्रभाव शामिल हैं। आप एनीमेशन प्रभावों की पूर्ण सूची [**EffectType**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effecttype/) enumeration में पा सकते हैं।

इसके अतिरिक्त, इन एनीमेशन प्रभावों को इनके साथ संयोजन में भी उपयोग किया जा सकता है:

- [ColorEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SetEffect)

## **कस्टम एनीमेशन**

Aspose.Slides में अपनी खुद की **कस्टम एनीमेशन** बनाना संभव है। यह तब प्राप्त किया जा सकता है जब आप कई व्यवहारों को एक नई कस्टम एनीमेशन में मिलाते हैं।

[**Behavior**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Behavior) किसी भी PowerPoint एनीमेशन प्रभाव की निर्माण इकाई है। सभी एनीमेशन प्रभाव वास्तव में एक रणनीति में संयुक्त कई व्यवहारों का सेट होते हैं। आप व्यवहारों को एक बार कस्टम एनीमेशन में मिलाकर इसे अन्य प्रस्तुतियों में पुनः उपयोग कर सकते हैं। यदि आप एक मानक PowerPoint एनीमेशन प्रभाव में नया व्यवहार जोड़ते हैं — तो वह एक और कस्टम एनीमेशन बन जाएगा। उदाहरण के लिए, आप एनीमेशन में दोहराव व्यवहार जोड़ सकते हैं ताकि वह कई बार दोहराया जाए।

[**Animation Point**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Point) वह बिंदु है जहाँ व्यवहार लागू किया जाना चाहिए।

## **एनीमेशन टाइमलाइन**

[**Sequence**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Sequence) एनीमेशन प्रभावों का एक संग्रह है, जो किसी विशिष्ट आकार पर लागू होता है।

[**Timeline**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AnimationTimeLine) एक विशिष्ट स्लाइड में उपयोग किए गए Sequences का सेट है। यह PowerPoint 2002 से प्रस्तुत किया गया एनीमेशन इंजन है। पिछले PowerPoint संस्करणों में प्रस्तुति में एनीमेशन प्रभाव जोड़ना चुनौतीपूर्ण था, जिसे केवल विभिन्न वर्कअराउंड्स से ही किया जा सकता था। Timeline पुराने AnimationSettings क्लास को प्रतिस्थापित करता है और PowerPoint एनीमेशन के लिए अधिक स्पष्ट ऑब्जेक्ट मॉडल प्रदान करता है। एक स्लाइड में केवल एक एनीमेशन टाइमलाइन हो सकती है।

## **इंटरैक्टिव एनीमेशन**

[**Trigger**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/EffectTriggerType) उपयोगकर्ता क्रियाओं (जैसे बटन क्लिक) को परिभाषित करने की अनुमति देता है, जिससे कोई विशेष एनीमेशन शुरू हो सके। ट्रिगर्स केवल नवीनतम PowerPoint संस्करण में जोड़े गए हैं।

## **आकार एनीमेशन**

Aspose.Slides आकारों पर एनीमेशन लागू करने की अनुमति देता है, जो वास्तव में टेक्स्ट, आयत, रेखा, फ्रेम, OLE ऑब्जेक्ट आदि हो सकते हैं।

{{% alert color="primary" %}} 
और पढ़ें [**Shape एनीमेशन के बारे में**](/slides/hi/nodejs-java/shape-animation/).
{{% /alert %}}

## **एनिमेटेड चार्ट**

एनिमेटेड चार्ट बनाने के लिए, आपको आकारों के समान सभी क्लासेस का उपयोग करना चाहिए। हालांकि, PowerPoint एनीमेशन को केवल चार्ट श्रेणियों या चार्ट सीरीज पर ही उपयोग किया जा सकता है। आप श्रेणी तत्व या सीरीज़ तत्व पर भी एनीमेशन प्रभाव लागू कर सकते हैं।

{{% alert color="primary" %}} 
और पढ़ें [**एनिमेटेड चार्ट के बारे में**](/slides/hi/nodejs-java/animated-charts/).
{{% /alert %}}

## **एनिमेटेड टेक्स्ट**

एनिमेटेड टेक्स्ट के अलावा, पैराग्राफ पर भी एनीमेशन लागू करना संभव है।

{{% alert color="primary" %}} 
और पढ़ें [**एनिमेटेड टेक्स्ट के बारे में**](/slides/hi/nodejs-java/animated-text/).
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एनीमेशन को PDF में निर्यात करने पर संरक्षित रखा जाएगा?**

नहीं। PDF एक स्थिर फ़ॉर्मेट है, इसलिए एनीमेशन और [slide transitions](/slides/hi/nodejs-java/slide-transition/) चलते नहीं हैं। यदि आपको गति चाहिए, तो इसके बजाय [HTML5](/slides/hi/nodejs-java/export-to-html5/), [animated GIF](/slides/hi/nodejs-java/convert-powerpoint-to-animated-gif/), या [video](/slides/hi/nodejs-java/convert-powerpoint-to-video/) में निर्यात करें।

**क्या मैं एक एनिमेटेड प्रस्तुति को वीडियो में बदल सकता हूँ और फ़्रेम रेट एवं फ़्रेम आकार को नियंत्रित कर सकता हूँ?**

हां। आप प्रस्तुति को [render the presentation as frames](/slides/hi/nodejs-java/convert-powerpoint-to-video/) के रूप में रेंडर कर सकते हैं और उन्हें वीडियो (जैसे ffmpeg के माध्यम से) में एन्कोड कर सकते हैं, जिससे FPS और रिज़ॉल्यूशन चुन सकते हैं। एनीमेशन और स्लाइड ट्रांज़िशन रेंडरिंग के दौरान चलाए जाते हैं।

**क्या ODP (सिर्फ PPTX नहीं) के साथ काम करने पर एनीमेशन अपरिवर्तित रहेंगे?**

PPT, PPTX, और ODP को [reading](/slides/hi/nodejs-java/open-presentation/) और [writing](/slides/hi/nodejs-java/save-presentation/) के लिए समर्थन प्राप्त है, लेकिन फ़ॉर्मेट मतभेदों के कारण कुछ प्रभाव थोड़ा अलग दिख सकते हैं या अलग व्यवहार कर सकते हैं। महत्वपूर्ण मामलों को वास्तविक नमूनों के साथ सत्यापित करें।