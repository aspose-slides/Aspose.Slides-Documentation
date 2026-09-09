---
title: Python के माध्यम से Java में एनीमेशन के साथ PowerPoint प्रस्तुतियों को बेहतर बनाएं
linktitle: PowerPoint एनीमेशन
type: docs
weight: 150
url: /hi/python-java/powerpoint-animation/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java की PowerPoint एनीमेशन संभालने की क्षमताओं का अन्वेषण करें। यह सामान्य अवलोकन मुख्य विशेषताओं को उजागर करता है और आपकी प्रस्तुतियों को बेहतर बनाने के लिए अंतर्दृष्टि प्रदान करता है।"
---
## **परिचय**

जब प्रस्तुतियां बनाई जाती हैं तो दृश्य रूप और इंटरैक्टिव व्यवहार दोनों को माना जाता है।

**PowerPoint एनीमेशन** दर्शकों के लिए एक प्रस्तुति को आकर्षक और संलग्न बनाने में महत्वपूर्ण भूमिका निभाता है। Aspose.Slides PowerPoint प्रस्तुतियों में एनीमेशन जोड़ने के लिए व्यापक विकल्प प्रदान करता है:

- आकृतियों, चार्ट, तालिकाओं, OLE ऑब्जेक्ट्स और अन्य प्रस्तुति तत्वों पर विभिन्न प्रकार के PowerPoint एनीमेशन प्रभाव लागू करें।
- एक ही आकृति पर कई PowerPoint एनीमेशन प्रभावों का प्रयोग करें।
- एनीमेशन टाइमलाइन का उपयोग करके एनीमेशन प्रभावों को नियंत्रित करें।
- कस्टम एनीमेशन बनाएं।

Aspose.Slides में विभिन्न एनीमेशन प्रभावों को आकृतियों पर लागू किया जा सकता है। चूंकि स्लाइड पर प्रत्येक तत्व, जिसमें पाठ, चित्र, OLE ऑब्जेक्ट और तालिकाएँ शामिल हैं, को एक आकृति माना जाता है, इसलिए एनीमेशन प्रभाव स्लाइड के किसी भी तत्व पर लागू किए जा सकते हैं।

## **एनीमेशन प्रभाव**
Aspose.Slides **150+ एनीमेशन प्रभाव** का समर्थन करता है, जिसमें बाउंस, PathFootball, और ज़ूम जैसे बुनियादी प्रभाव, साथ ही OLEObjectShow और OLEObjectOpen जैसे विशेष प्रभाव शामिल हैं। आप पूर्ण सूची [EffectType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effecttype/) enumeration में देख सकते हैं।

इसके अतिरिक्त, नीचे दिए गए एनीमेशन प्रभावों को ऊपर सूचीबद्ध प्रभावों के साथ संयोजन में उपयोग किया जा सकता है:

- [ColorEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/seteffect/)

## **कस्टम एनीमेशन**
Aspose.Slides में आप अपना **कस्टम एनीमेशन** बना सकते हैं। आप कई व्यवहारों को मिलाकर एक नया कस्टम एनीमेशन बना सकते हैं।

[Behavior](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behavior/) किसी भी PowerPoint एनीमेशन प्रभाव की निर्माण इकाई है। प्रत्येक एनीमेशन प्रभाव व्यवहारों के समूह से मिलकर बनता है जिसे एक रणनीति में संयोजित किया जाता है। आप एक बार व्यवहारों को कस्टम एनीमेशन में मिलाकर उसे अन्य प्रस्तुतियों में पुन: उपयोग कर सकते हैं। मानक PowerPoint एनीमेशन प्रभाव में नया व्यवहार जोड़ने से एक और कस्टम एनीमेशन बनता है। उदाहरण के लिए, आप दोहराव व्यवहार जोड़ सकते हैं जिससे एनीमेशन कई बार दोहराया जा सके।

[Point](https://reference.aspose.com/slides/hi/python-java/aspose.slides/point/) वह बिंदु है जहाँ व्यवहार लागू किया जाना चाहिए।

## **एनीमेशन टाइमलाइन**
[Sequence](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/) कोई विशिष्ट आकृति पर लागू एनीमेशन प्रभावों का संग्रह है।

[AnimationTimeLine](https://reference.aspose.com/slides/hi/python-java/aspose.slides/animationtimeline/) वह अनुक्रमों का सेट है जो एक विशिष्ट स्लाइड पर उपयोग होते हैं। यह PowerPoint 2002 में प्रस्तुत एनीमेशन इंजन को दर्शाता है। पूर्व PowerPoint संस्करणों में प्रस्तुति में एनीमेशन प्रभाव जोड़ना कठिन था और वर्कअराउंड्स की आवश्यकता होती थी। टाइमलाइन ने पुरानी AnimationSettings क्लास की जगह ली और PowerPoint एनीमेशन के लिए एक स्पष्ट ऑब्जेक्ट मॉडल प्रदान किया। एक स्लाइड में केवल एक एनीमेशन टाइमलाइन हो सकती है।

## **इंटरैक्टिव एनीमेशन**
[EffectTriggerType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effecttriggertype/) आपको उपयोगकर्ता क्रियाएँ (जैसे बटन क्लिक) परिभाषित करने की अनुमति देता है जो किसी विशिष्ट एनीमेशन को शुरू करती हैं। ट्रिगर्स केवल नवीनतम PowerPoint संस्करण में जोड़े गए थे।

## **आकृति एनीमेशन**
Aspose.Slides आपको आकृतियों पर एनीमेशन लागू करने की अनुमति देता है, जो पाठ, आयत, रेखाएँ, फ्रेम, OLE ऑब्जेक्ट और अन्य तत्वों का प्रतिनिधित्व कर सकते हैं।

{{% alert color="info" title="नोट" %}}
अधिक पढ़ें [About Shape Animation](/slides/hi/python-java/shape-animation/)।
{{% /alert %}}

## **एनिमेटेड चार्ट**
एनिमेटेड चार्ट बनाने के लिए, आप आकृतियों के समान कक्षाओं का उपयोग कर सकते हैं। हालांकि, PowerPoint एनीमेशन केवल चार्ट श्रेणियों या चार्ट श्रृंखलाओं पर लागू किया जा सकता है। आप किसी श्रेणी तत्व या श्रृंखला तत्व पर भी एनीमेशन प्रभाव लागू कर सकते हैं।

{{% alert color="info" title="नोट" %}}
अधिक पढ़ें [About Animated Charts](/slides/hi/python-java/animated-charts/)।
{{% /alert %}}

## **एनिमेटेड टेक्स्ट**
पाठ को एनीमेट करने के अलावा, आप पैराग्राफ पर भी एनीमेशन लागू कर सकते हैं।

{{% alert color="info" title="नोट" %}}
अधिक पढ़ें [About Animated Text](/slides/hi/python-java/animated-text/)।
{{% /alert %}}

## **FAQ**

**क्या एनीमेशन PDF में निर्यात करने पर सुरक्षित रहेंगे?**

नहीं। PDF एक स्थिर प्रारूप है, इसलिए एनीमेशन और [slide transitions](/slides/hi/python-java/slide-transition/) नहीं चलते। यदि आपको गति चाहिए, तो PDF के बजाय [HTML5](/slides/hi/python-java/export-to-html5/), [animated GIF](/slides/hi/python-java/convert-powerpoint-to-animated-gif/) या [video](/slides/hi/python-java/convert-powerpoint-to-video/) निर्यात करें।

**क्या मैं एनीमेटेड प्रस्तुति को वीडियो में बदल सकता हूँ और फ्रेम रेट तथा फ्रेम आकार को नियंत्रित कर सकता हूँ?**

हाँ। आप प्रस्तुति को फ्रेम्स के रूप में [render the presentation as frames](/slides/hi/python-java/convert-powerpoint-to-video/) कर सकते हैं और उन्हें वीडियो (जैसे ffmpeg के माध्यम से) में एन्कोड कर सकते हैं, FPS और रिज़ॉल्यूशन चुनते हुए। रेंडरिंग के दौरान एनीमेशन और स्लाइड ट्रांज़िशन चलाए जाते हैं।

**क्या ODP (केवल PPTX नहीं) के साथ काम करते समय एनीमेशन समान रहेंगे?**

PPT, PPTX, और ODP को [reading](/slides/hi/python-java/open-presentation/) और [writing](/slides/hi/python-java/save-presentation/) दोनों के लिए समर्थित किया गया है, लेकिन प्रारूप अंतर के कारण कुछ प्रभाव थोड़ा अलग दिख या व्यवहार कर सकते हैं। महत्वपूर्ण मामलों को वास्तविक नमूनों के साथ सत्यापित करें।