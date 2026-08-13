---
title: PowerPoint प्रस्तुतियों को .NET में एनिमेशन के साथ सुधारें
linktitle: PowerPoint एनीमेशन
type: docs
weight: 150
url: /hi/net/powerpoint-animation/
keywords:
- एनिमेशन जोड़ें
- एनिमेशन अपडेट करें
- एनिमेशन बदलें
- एनिमेशन हटाएँ
- एनिमेशन प्रबंधित करें
- एनिमेशन नियंत्रित करें
- एनीमेशन प्रभाव
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
- PowerPoint प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET की PowerPoint एनीमेशन को संभालने की क्षमताओं का अन्वेषण करें। यह सामान्य अवलोकन मुख्य सुविधाओं को उजागर करता है और आपकी प्रस्तुतियों को बेहतर बनाने के लिए अंतर्दृष्टि प्रदान करता है।"
---
## **परिचय**

चूंकि प्रस्तुतियों का उद्देश्य कुछ प्रस्तुत करना है, इसलिए उनकी दृश्य उपस्थिति और इंटरैक्टिव व्यवहार को निर्माण के दौरान हमेशा ध्यान में रखा जाता है।

**PowerPoint animation** एक प्रस्तुति को दर्शकों के लिए आकर्षक और दिलचस्प बनाने में महत्वपूर्ण भूमिका निभाता है। Aspose.Slides for .NET PowerPoint प्रस्तुतियों में एनिमेशन जोड़ने के लिए विविध विकल्प प्रदान करता है:
- Shapes, charts, tables, OLE objects और अन्य प्रस्तुति तत्वों पर विभिन्न प्रकार के PowerPoint एनीमेशन इफ़ेक्ट लागू करें।
- एक ही shape पर कई PowerPoint एनीमेशन इफ़ेक्ट का उपयोग करें।
- एनीमेशन प्रभावों को नियंत्रित करने के लिए एनीमेशन टाइमलाइन का उपयोग करें।
- कस्टम एनीमेशन बनाएं।

Aspose.Slides for .NET में, विभिन्न एनीमेशन इफ़ेक्ट्स को shapes पर लागू किया जा सकता है। चूंकि स्लाइड पर प्रत्येक तत्व, जैसे टेक्स्ट, चित्र, OLE objects और टेबल, को एक shape माना जाता है, इसलिए एनीमेशन इफ़ेक्ट्स स्लाइड के किसी भी तत्व पर लागू किए जा सकते हैं।

[Aspose.Slides.Animation](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/) namespace PowerPoint एनीमेशन के साथ काम करने के लिए क्लासेस प्रदान करता है।

## **एनीमेशन प्रभाव**

Aspose.Slides **150+ एनीमेशन इफ़ेक्ट्स** का समर्थन करता है, जिसमें Bounce, PathFootball, और Zoom जैसे मूलभूत इफ़ेक्ट्स, साथ ही OLEObjectShow और OLEObjectOpen जैसे विशिष्ट इफ़ेक्ट्स शामिल हैं। आप [EffectType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effecttype) enumeration में एनीमेशन इफ़ेक्ट्स की पूरी सूची पा सकते हैं।

इसके अतिरिक्त, इन एनीमेशन इफ़ेक्ट्स को निम्नलिखित के साथ संयोजन में उपयोग किया जा सकता है:
- [ColorEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/seteffect)

## **कस्टम एनीमेशन**

Aspose.Slides में आप अपने खुद के **कस्टम एनीमेशन** बना सकते हैं। इसे कई व्यवहारों को मिलाकर एक नया कस्टम एनीमेशन बनाकर प्राप्त किया जा सकता है।

[Behaviour](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/behavior) किसी भी PowerPoint एनीमेशन इफ़ेक्ट का निर्माण खंड है।

सभी एनीमेशन इफ़ेक्ट मूलतः एक सेट व्यवहारों के होते हैं जो एक रणनीति में संयोजित किए जाते हैं।

आप एक बार व्यवहारों को कस्टम एनीमेशन में मिलाकर इसे अन्य प्रस्तुतियों में पुन: उपयोग कर सकते हैं।

यदि आप एक मानक PowerPoint एनीमेशन इफ़ेक्ट में नया व्यवहार जोड़ते हैं, तो वह एक और कस्टम एनीमेशन बन जाएगा।

उदाहरण के लिए, आप एनीमेशन में एक repeat व्यवहार जोड़ सकते हैं जिससे वह कुछ बार दोहराया जा सके।

[Animation Point](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/point) वह बिंदु है जहाँ एक व्यवहार लागू किया जाना चाहिए।

## **एनीमेशन टाइमलाइन**

[Sequence](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/sequence) एक विशिष्ट shape पर लागू एनीमेशन इफ़ेक्ट्स का संग्रह है।

[Timeline](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/animationtimeline) एक विशिष्ट स्लाइड में उपयोग किए जाने वाले सीक्वेंसेज़ का सेट है। यह PowerPoint 2002 में प्रस्तुत किया गया एनीमेशन इंजन है। PowerPoint के पुराने संस्करणों में प्रस्तुतियों में एनीमेशन इफ़ेक्ट जोड़ना चुनौतीपूर्ण था और केवल विभिन्न वर्कअराउंड के माध्यम से संभव था। टाइमलाइन ने पुराने AnimationSettings क्लास को प्रतिस्थापित किया और PowerPoint एनीमेशन के लिए एक स्पष्ट ऑब्जेक्ट मॉडल प्रदान करता है। एक स्लाइड में केवल एक एनीमेशन टाइमलाइन हो सकता है।

## **इंटरएक्टिव एनीमेशन**

[Trigger](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effecttriggertype) आपको उपयोगकर्ता क्रियाओं (जैसे, बटन क्लिक) को परिभाषित करने की अनुमति देता है जो एक विशिष्ट एनीमेशन को शुरू करेगा। ट्रिगर्स नवीनतम PowerPoint संस्करण में पेश किए गए थे।

## **शेप एनीमेशन**

Aspose.Slides आपको shapes पर एनीमेशन लागू करने की अनुमति देता है, जहाँ टेक्स्ट, आयत, रेखाएँ, फ्रेम, OLE objects आदि शामिल हो सकते हैं।

{{% alert color="info" %}} 
और पढ़ें [**Shape एनीमेशन के बारे में**](/slides/hi/net/shape-animation/).
{{% /alert %}}

## **एनिमेटेड चार्ट्स**

एनिमेटेड चार्ट बनाने के लिए, आपको शेप्स के समान क्लासेस का उपयोग करना चाहिए। हालांकि, PowerPoint एनीमेशन केवल चार्ट श्रेणियों या चार्ट सीरीज़ पर ही लागू किए जा सकते हैं। आप एक श्रेणी तत्व या एक सीरीज़ तत्व पर भी एनीमेशन इफ़ेक्ट लागू कर सकते हैं।

{{% alert color="info" %}} 
और पढ़ें [**एनिमेटेड चार्ट्स के बारे में**](/slides/hi/net/animated-charts/).
{{% /alert %}}

## **एनिमेटेड टेक्स्ट**

एनिमेटेड टेक्स्ट के अलावा, पैराग्राफ पर भी एनीमेशन लागू करना संभव है।

{{% alert color="info" %}} 
और पढ़ें [**एनिमेटेड टेक्स्ट के बारे में**](/slides/hi/net/animated-text/).
{{% /alert %}}

## **FAQ**

### क्या एनीमेशन PDF में निर्यात करने पर संरक्षित रहेंगे?

नहीं। PDF एक स्थिर प्रारूप है, इसलिए एनीमेशन और [slide transitions](/slides/hi/net/slide-transition/) नहीं चलते। यदि आपको गति चाहिए, तो इसके बजाय [HTML5](/slides/hi/net/export-to-html5/), [animated GIF](/slides/hi/net/convert-powerpoint-to-animated-gif/), या [video](/slides/hi/net/convert-powerpoint-to-video/) में निर्यात करें।

### क्या मैं एनीमेटेड प्रस्तुति को वीडियो में बदल सकता हूँ और फ्रेम दर व फ्रेम आकार को नियंत्रित कर सकता हूँ?

हां। आप [render the presentation as frames](/slides/hi/net/convert-powerpoint-to-video/) कर सकते हैं और उन्हें वीडियो में एन्कोड कर सकते हैं (जैसे ffmpeg द्वारा), FPS और रिज़ॉल्यूशन चुनते हुए। रेंडरिंग के दौरान एनीमेशन और स्लाइड ट्रांज़िशन चलाए जाते हैं।

### क्या ODP (केवल PPTX नहीं) के साथ काम करने पर एनीमेशन वही रहेंगे?

PPT, PPTX, और ODP को [reading](/slides/hi/net/open-presentation/) और [writing](/slides/hi/net/save-presentation/) के लिए समर्थन दिया गया है, लेकिन फ़ॉर्मैट अंतर के कारण कुछ इफ़ेक्ट्स थोड़ा अलग दिख सकते हैं या अलग व्यवहार कर सकते हैं। महत्वपूर्ण मामलों को वास्तविक नमूनों के साथ सत्यापित करें।