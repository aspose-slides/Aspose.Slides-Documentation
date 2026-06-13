---
title: PowerPoint प्रस्तुतियों को .NET में एनीमेशनों के साथ बेहतर बनाएं
linktitle: PowerPoint एनीमेशन
type: docs
weight: 150
url: /hi/net/powerpoint-animation/
keywords:
- एनीमेशन जोड़ें
- एनीमेशन अपडेट करें
- एनीमेशन बदलें
- एनीमेशन हटाएं
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
- PowerPoint प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET की PowerPoint एनीमेशन को संभालने की क्षमताओं का अन्वेषण करें। यह सामान्य अवलोकन प्रमुख विशेषताओं को उजागर करता है और आपके प्रस्तुतियों को बेहतर बनाने के लिए अंतर्दृष्टि प्रदान करता है।"
---
## **परिचय**

चूँकि प्रस्तुतियों का उद्देश्य कुछ दर्शाना होता है, इसलिए निर्माण के दौरान उनकी दृश्य उपस्थिति और इंटरैक्टिव व्यवहार हमेशा ध्यान में रखा जाता है।

**PowerPoint एनीमेशन** प्रस्तुति को दर्शकों के लिए आकर्षक और रोचक बनाने में महत्वपूर्ण भूमिका निभाता है। Aspose.Slides for .NET PowerPoint प्रस्तुतियों में एनीमेशन जोड़ने के लिए विस्तृत विकल्प प्रदान करता है:

- विभिन्न प्रकार के PowerPoint एनीमेशन प्रभावों को आकारों, चार्ट, तालिकाओं, OLE वस्तुओं और अन्य प्रस्तुति तत्वों पर लागू करें।
- एक ही आकार पर कई PowerPoint एनीमेशन प्रभावों का उपयोग करें।
- एनीमेशन टाइमलाइन का उपयोग करके एनीमेशन प्रभावों को नियंत्रित करें।
- कस्टम एनीमेशन बनाएं।

Aspose.Slides for .NET में विभिन्न एनीमेशन प्रभावों को आकारों पर लागू किया जा सकता है। चूँकि स्लाइड पर प्रत्येक तत्व—पाठ, चित्र, OLE वस्तु, और तालिका—को एक आकार माना जाता है, इसलिए एनीमेशन प्रभाव स्लाइड पर किसी भी तत्व पर लागू किए जा सकते हैं।

[Aspose.Slides.Animation](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/) namespace PowerPoint एनीमेशन के साथ काम करने के लिए क्लास प्रदान करता है।

## **एनीमेशन प्रभाव**

Aspose.Slides **150+ एनीमेशन प्रभाव** का समर्थन करता है, जिसमें Bounce, PathFootball, Zoom जैसे बुनियादी प्रभाव और OLEObjectShow, OLEObjectOpen जैसे विशिष्ट प्रभाव शामिल हैं। आप पूरी एनीमेशन प्रभाव सूची [EffectType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effecttype) enumeration में पा सकते हैं।

इसके अतिरिक्त, इन एनीमेशन प्रभावों को निम्नलिखित के साथ संयोजन में उपयोग किया जा सकता है:

- [ColorEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/seteffect)

## **कस्टम एनीमेशन**

Aspose.Slides में आप अपने स्वयं के **कस्टम एनीमेशन** बना सकते हैं। यह कई व्यवहारों को मिलाकर एक नया कस्टम एनीमेशन बनाकर प्राप्त किया जा सकता है।

[Behaviour](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/behavior) किसी भी PowerPoint एनीमेशन प्रभाव का निर्माण ब्लॉक है। सभी एनीमेशन प्रभाव मूल रूप से व्यवहारों का एक सेट होते हैं जो एक रणनीति में संयोजित होते हैं। आप एक बार व्यवहारों को कस्टम एनीमेशन में जोड़ सकते हैं और उसे अन्य प्रस्तुतियों में पुन: उपयोग कर सकते हैं। यदि आप किसी मानक PowerPoint एनीमेशन प्रभाव में नया व्यवहार जोड़ते हैं, तो वह एक अन्य कस्टम एनीमेशन बन जाता है। उदाहरण के लिए, आप एनीमेशन में दोहराव व्यवहार जोड़ सकते हैं जिससे वह कुछ बार दोहराए।

[Animation Point](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/point) वह बिंदु है जहाँ व्यवहार लागू होना चाहिए।

## **एनीमेशन टाइम लाइन**

[Sequence](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/sequence) एक विशिष्ट आकार पर लागू एनीमेशन प्रभावों का संग्रह है।

[Timeline](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/animationtimeline) विशिष्ट स्लाइड में उपयोग की जाने वाली अनुक्रमों का समूह है। यह PowerPoint 2002 में पेश किया गया एनीमेशन इंजन है। पुराने PowerPoint संस्करणों में प्रस्तुतियों में एनीमेशन प्रभाव जोड़ना कठिन था और केवल विविध कार्यक्षमताओं से ही संभव था। टाइमलाइन ने पुरानी AnimationSettings क्लास को बदल दिया और PowerPoint एनीमेशन के लिए स्पष्ट ऑब्जेक्ट मॉडल प्रदान किया। एक स्लाइड में केवल एक एनीमेशन टाइमलाइन हो सकती है।

## **इंटरैक्टिव एनीमेशन**

[Trigger](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effecttriggertype) आपको उपयोगकर्ता क्रियाएँ (जैसे बटन क्लिक) निर्धारित करने की अनुमति देता है जो किसी विशिष्ट एनीमेशन को शुरू करेंगे। ट्रिगर नवीनतम PowerPoint संस्करण में प्रस्तुत किए गए हैं।

## **आकार एनीमेशन**

Aspose.Slides आपको आकारों पर एनीमेशन लागू करने देता है, जिसमें पाठ, आयत, रेखाएँ, फ्रेम, OLE वस्तुएँ और अधिक शामिल हो सकते हैं।

{{% alert color="primary" %}} 
और पढ़ें [**आकार एनीमेशन के बारे में**](/slides/hi/net/shape-animation/)।
{{% /alert %}}

## **एनिमेटेड चार्ट**

एनिमेटेड चार्ट बनाने के लिए आपको आकारों के समान क्लासों का उपयोग करना चाहिए। हालांकि, PowerPoint एनीमेशन केवल चार्ट श्रेणियों या चार्ट सीरीज़ पर लागू किए जा सकते हैं। आप श्रेणी तत्व या सीरीज़ तत्व पर भी एनीमेशन प्रभाव लागू कर सकते हैं।

{{% alert color="primary" %}} 
और पढ़ें [**एनिमेटेड चार्ट के बारे में**](/slides/hi/net/animated-charts/)।
{{% /alert %}}

## **एनिमेटेड टेक्स्ट**

एनिमेटेड टेक्स्ट के अलावा, पैराग्राफ पर भी एनीमेशन लागू करना संभव है।

{{% alert color="primary" %}} 
और पढ़ें [**एनिमेटेड टेक्स्ट के बारे में**](/slides/hi/net/animated-text/)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PDF में निर्यात करने पर एनीमेशन सुरक्षित रहते हैं?**

नहीं। PDF एक स्थिर स्वरूप है, इसलिए एनीमेशन और [स्लाइड ट्रांज़िशन](/slides/hi/net/slide-transition/) नहीं चलते। यदि आपको गति चाहिए, तो निर्यात के लिए [HTML5](/slides/hi/net/export-to-html5/), [एनिमेटेड GIF](/slides/hi/net/convert-powerpoint-to-animated-gif/) या [वीडियो](/slides/hi/net/convert-powerpoint-to-video/) का उपयोग करें।

**क्या मैं एनिमेटेड प्रस्तुति को वीडियो में बदल सकता हूँ और फ्रेम रेट तथा फ्रेम आकार को नियंत्रित कर सकता हूँ?**

हां। आप प्रस्तुति को फ्रेमों के रूप में [रेंडर](/slides/hi/net/convert-powerpoint-to-video/) कर सकते हैं और उन्हें वीडियो में (जैसे ffmpeg के माध्यम से) एन्कोड कर सकते हैं, जिससे FPS और रिज़ॉल्यूशन चुना जा सके। रेंडरिंग के दौरान एनीमेशन और स्लाइड ट्रांज़िशन चलाए जाते हैं।

**क्या ODP (केवल PPTX नहीं) के साथ काम करते समय एनीमेशन समान रहते हैं?**

PPT, PPTX, और ODP को [पढ़ने](/slides/hi/net/open-presentation/) और [लिखने](/slides/hi/net/save-presentation/) के लिए समर्थित किया गया है, लेकिन स्वरूप अंतर के कारण कुछ प्रभाव थोड़ा अलग दिख सकते हैं या अलग व्यवहार कर सकते हैं। महत्वपूर्ण मामलों को वास्तविक नमूनों से सत्यापित करें।