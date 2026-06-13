---
title: Python में एनीमेशन के साथ PowerPoint प्रस्तुतियों को बेहतर बनाएं
linktitle: PowerPoint एनीमेशन
type: docs
weight: 150
url: /hi/python-net/powerpoint-animation/
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
- PowerPoint प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET की PowerPoint एनीमेशन को संभालने की क्षमताओं की खोज करें। यह सामान्य अवलोकन प्रमुख विशेषताओं को उजागर करता है और आपके प्रस्तुतियों को बेहतर बनाने के लिए अंतर्दृष्टि प्रदान करता है।"
---
## **परिचय**

प्रस्तुतियों को जानकारी संप्रेषित करने के लिए डिज़ाइन किया गया है, इसलिए उनका दृश्य स्वरूप और इंटरैक्टिव व्यवहार निर्माण के दौरान मुख्य विचार हैं।

**PowerPoint एनीमेशन** प्रस्तुति को दर्शकों के लिए आकर्षक और रोचक बनाने में महत्वपूर्ण भूमिका निभाता है। Aspose.Slides for Python via .NET कई विकल्प प्रदान करता है जिससे आप PowerPoint प्रस्तुति में एनीमेशन जोड़ सकते हैं। आप:

- आकारों, चार्ट, तालिकाओं, OLE वस्तुओं और अन्य तत्वों पर विभिन्न एनीमेशन इफ़ेक्ट लागू करें।
- एक ही आकार पर कई एनीमेशन इफ़ेक्ट्स का उपयोग करें।
- एनीमेशन टाइमलाइन के माध्यम से इफ़ेक्ट्स को नियंत्रित करें।
- कस्टम एनीमेशन बनाएं।

Aspose.Slides for Python via .NET में एनीमेशन इफ़ेक्ट्स को आकारों पर लागू किया जा सकता है। क्योंकि स्लाइड पर हर तत्व—टेक्स्ट, चित्र, OLE वस्तुएँ, और तालिकाएँ—को एक आकार माना जाता है, आप स्लाइड के किसी भी तत्व पर एनीमेशन इफ़ेक्ट लागू कर सकते हैं।

The [aspose.slides.animation](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/) namespace provides the classes for working with PowerPoint animations.

## **एनीमेशन इफ़ेक्ट्स**

Aspose.Slides **150+ एनीमेशन इफ़ेक्ट्स** का समर्थन करता है, जिसमें बाउंस, PathFootball, और ज़ूम जैसे बुनियादी इफ़ेक्ट्स और OLEObjectShow और OLEObjectOpen जैसे विशेष इफ़ेक्ट्स शामिल हैं। आप पूरी सूची [EffectType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttype/) एनेमरेशन में पा सकते हैं।

इसके अतिरिक्त, इन एनीमेशन इफ़ेक्ट्स को निम्नलिखित इफ़ेक्ट्स के साथ जोड़ा जा सकता है:

- [ColorEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/seteffect/)

## **कस्टम एनीमेशन**

आप Aspose.Slides में कई व्यवहारों को एक ही प्रभाव में मिलाकर अपनी खुद की **कस्टम एनीमेशन** बना सकते हैं।

[Behavior](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behavior/) कोई भी PowerPoint एनीमेशन इफ़ेक्ट का मूल निर्माण खंड है। प्रत्येक एनीमेशन इफ़ेक्ट मूलतः व्यवहारों का एक सेट है जो एक रणनीति या टाइमलाइन में व्यवस्थित होते हैं। आप व्यवहारों को एक बार कस्टम एनीमेशन में संयोजित कर सकते हैं और अन्य प्रस्तुतियों में पुन: उपयोग कर सकते हैं। यदि आप एक मानक PowerPoint एनीमेशन इफ़ेक्ट में नया व्यवहार जोड़ते हैं, तो वह एक कस्टम एनीमेशन बन जाता है—उदाहरण के लिए, दोहराव व्यवहार जोड़ने से एनीमेशन कई बार चलाया जा सकता है।

[Animation Point](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/point/) वह क्षण या स्थान दर्शाता है जहाँ व्यवहार लागू किया जाता है (कीफ़्रेम)।

## **एनीमेशन टाइमलाइन**

[Sequence](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/) एक विशिष्ट आकार पर लागू किए गए एनीमेशन इफ़ेक्ट्स का संग्रह है।

[Timeline](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/animationtimeline/) एक विशिष्ट स्लाइड पर उपयोग किए जाने वाले सीक्वेंस का सेट है। इसे PowerPoint 2002 में प्रस्तुत किया गया था। पहले के PowerPoint संस्करणों में एनीमेशन इफ़ेक्ट जोड़ना कठिन था और अक्सर कार्यवाही समाधान की आवश्यकता होती थी। टाइमलाइन ने पुराने `AnimationSettings` वर्ग को बदल दिया और PowerPoint एनीमेशन के लिए एक स्पष्ट ऑब्जेक्ट मॉडल प्रदान करता है। प्रत्येक स्लाइड पर केवल एक एनीमेशन टाइमलाइन हो सकती है।

## **इंटरैक्टिव एनीमेशन**

[Trigger](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttriggertype/) आपको उपयोगकर्ता क्रियाएँ (जैसे बटन क्लिक) परिभाषित करने देता है जो एक विशिष्ट एनीमेशन को शुरू करती हैं। ट्रिगर्स केवल PowerPoint के नवीनतम संस्करणों में जोड़े गए थे।

## **आकार एनीमेशन**

Aspose.Slides आपको आकारों—जैसे टेक्स्ट, आयत, रेखाएँ, फ़्रेम, OLE वस्तुएँ और अधिक—पर एनीमेशन लागू करने की अनुमति देता है।

{{% alert color="primary" %}}

अधिक पढ़ें [**Shape Animation के बारे में**](/slides/hi/python-net/shape-animation/).

{{% /alert %}}

## **एनिमेटेड चार्ट**

एनिमेटेड चार्ट बनाने के लिए, आकारों के लिए जिस तरह की कक्षाओं का प्रयोग करते हैं, वही उपयोग करें। हालांकि, PowerPoint एनीमेशन केवल चार्ट श्रेणियों या चार्ट सीरीज़ पर लागू किए जा सकते हैं। आप एक व्यक्तिगत श्रेणी तत्व या सीरीज़ तत्व पर भी एनीमेशन इफ़ेक्ट लागू कर सकते हैं।

{{% alert color="primary" %}}

अधिक पढ़ें [**Animated Charts के बारे में**](/slides/hi/python-net/animated-charts/).

{{% /alert %}}

## **एनिमेटेड टेक्स्ट**

टेक्स्ट को एनीमेट करने के अलावा, आप एक पैराग्राफ पर भी एनीमेशन लागू कर सकते हैं।

{{% alert color="primary" %}}

अधिक पढ़ें [**Animated Text के बारे में**](/slides/hi/python-net/animated-text/).

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एनीमेशन PDF निर्यात करने पर संरक्षित रहेंगे?**

नहीं। PDF एक स्थिर फ़ॉर्मेट है, इसलिए एनीमेशन और [slide transitions](/slides/hi/python-net/slide-transition/) नहीं चलते हैं। यदि आपको मोशन चाहिए, तो निर्यात को [HTML5](/slides/hi/python-net/export-to-html5/), [animated GIF](/slides/hi/python-net/convert-powerpoint-to-animated-gif/), या [video](/slides/hi/python-net/convert-powerpoint-to-video/) में बदलें।

**क्या मैं एनीमेटेड प्रस्तुति को वीडियो में बदल सकता हूँ और फ्रेम रेट व फ्रेम आकार को नियंत्रित कर सकता हूँ?**

हाँ। आप प्रस्तुति को फ़्रेम्स के रूप में [render the presentation as frames](/slides/hi/python-net/convert-powerpoint-to-video/) कर सकते हैं और उन्हें एक वीडियो (उदाहरण के लिए ffmpeg के माध्यम से) में एन्कोड कर सकते हैं, FPS और रिज़ॉल्यूशन चुनते हुए। रेंडरिंग के दौरान एनीमेशन और स्लाइड ट्रांज़िशन चलाए जाते हैं।

**क्या ODP (केवल PPTX नहीं) के साथ काम करते समय एनीमेशन बरकरार रहेंगे?**

PPT, PPTX, और ODP को [reading](/slides/hi/python-net/open-presentation/) और [writing](/slides/hi/python-net/save-presentation/) के लिये समर्थन है, लेकिन फ़ॉर्मेट अंतर के कारण कुछ इफ़ेक्ट्स थोड़ा अलग दिख या व्यवहार कर सकते हैं। महत्वपूर्ण मामलों को वास्तविक नमूनों के साथ सत्यापित करें।