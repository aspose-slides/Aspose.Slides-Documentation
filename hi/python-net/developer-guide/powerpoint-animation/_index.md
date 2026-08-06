---
title: Python में एनीमेशन के साथ PowerPoint प्रस्तुतियों को उन्नत बनाएं
linktitle: PowerPoint एनीमेशन
type: docs
weight: 150
url: /hi/python-net/powerpoint-animation/
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
- आकृति एनीमेशन
- एनिमेटेड चार्ट
- एनिमेटेड टेक्स्ट
- एनिमेटेड आकृति
- एनिमेटेड OLE ऑब्जेक्ट
- एनिमेटेड इमेज
- एनिमेटेड टेबल
- PowerPoint प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET की PowerPoint एनीमेशन को संभालने की क्षमताओं का अन्वेषण करें। यह सामान्य अवलोकन प्रमुख सुविधाओं को उजागर करता है और आपके प्रस्तुतियों को बेहतर बनाने के लिए अंतर्दृष्टि प्रदान करता है।"
---
## **परिचय**

प्रेज़ेंटेशन जानकारी पहुँचाने के लिए बनाए जाते हैं, इसलिए उनका दृश्य रूप और इंटरैक्टिव व्यवहार निर्माण के दौरान मुख्य विचार होते हैं।

**PowerPoint एनीमेशन** प्रेज़ेंटेशन को दर्शकों के लिए आकर्षक और दर्शनीय बनाने में महत्वपूर्ण भूमिका निभाता है। Aspose.Slides for Python via .NET कई विकल्प प्रदान करता है जिससे आप PowerPoint प्रेज़ेंटेशन में एनीमेशन जोड़ सकते हैं। आप कर सकते हैं:

- आकृतियों, चार्ट, तालिकाओं, OLE ऑब्जेक्ट्स और अन्य तत्वों पर विभिन्न एनीमेशन प्रभाव लागू करना।
- एक ही आकृति पर कई एनीमेशन प्रभाव उपयोग करना।
- एनीमेशन टाइमलाइन के माध्यम से प्रभावों को नियंत्रित करना।
- कस्टम एनीमेशन बनाना।

Aspose.Slides for Python via .NET में, एनीमेशन प्रभाव आकृतियों पर लागू किए जा सकते हैं। क्योंकि स्लाइड पर प्रत्येक तत्व—टेक्स्ट, चित्र, OLE ऑब्जेक्ट या तालिका—एक आकृति के रूप में माना जाता है, आप स्लाइड पर किसी भी तत्व पर एनीमेशन प्रभाव लागू कर सकते हैं।

[aspose.slides.animation](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/) नेमस्पेस PowerPoint एनीमेशन के साथ काम करने के लिए क्लासेस प्रदान करता है।

## **इंस्टॉलेशन**

```bash
pip install aspose.slides
```

## **Python में एक आकृति पर एनीमेशन प्रभाव जोड़ना**

एनीमेशन प्रभाव स्लाइड के मुख्य क्रम (main sequence) में होते हैं। एक आकृति जोड़ें, फिर `slide.timeline.main_sequence` पर `add_effect` कॉल करें, जिसमें प्रभाव प्रकार, उसका उपप्रकार और ट्रिगर पास करें जो उसे शुरू करता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

सेव की गई फ़ाइल में पहले स्लाइड पर एक प्रभाव मौजूद है: आयत बाईं ओर से दो सेकंड में उड़ती है जब प्रस्तुतकर्ता क्लिक करता है। इसे पुनः खोलने और `slide.timeline.main_sequence` पढ़ने पर वही प्रभाव मिलता है, इसलिए एनीमेशन मेमोरी में केवल रहने के बजाय राउंड ट्रिप में सुरक्षित रहता है।

## **एनीमेशन प्रभाव**

Aspose.Slides **150+ एनीमेशन प्रभाव** का समर्थन करता है, जिसमें Bounce, PathFootball, Zoom जैसे बुनियादी प्रभाव और OLEObjectShow, OLEObjectOpen जैसे विशेष प्रभाव शामिल हैं। पूरी सूची आप [EffectType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttype/) एन्नुमरेशन में पा सकते हैं।

इसके अतिरिक्त, इन एनीमेशन प्रभावों को निम्नलिखित प्रभावों के साथ जोड़ा जा सकता है:

- [ColorEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/seteffect/)

## **कस्टम एनीमेशन**

Aspose.Slides में आप कई व्यवहारों को एकल प्रभाव में सम्मिलित करके **कस्टम एनीमेशन** बना सकते हैं।

[Behavior](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behavior/) किसी भी PowerPoint एनीमेशन प्रभाव की मूल निर्माण इकाई है। प्रत्येक एनीमेशन प्रभाव मूलतः व्यवहारों का एक सेट होता है जिसे एक रणनीति या टाइमलाइन में व्यवस्थित किया जाता है। आप एक बार कस्टम एनीमेशन के रूप में व्यवहारों को संयोजित कर सकते हैं और इसे अन्य प्रेज़ेंटेशन में पुन: उपयोग कर सकते हैं। यदि आप एक मानक PowerPoint एनीमेशन प्रभाव में नया व्यवहार जोड़ते हैं, तो वह कस्टम एनीमेशन बन जाता है—उदाहरण के लिए, दोहराव (repeat) व्यवहार जोड़कर एनीमेशन को कई बार चलाया जा सकता है।

[Animation Point](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/point/) वह क्षण या स्थिति को दर्शाता है जिस पर व्यवहार लागू किया जाता है (कीफ़्रेम)।

## **एनीमेशन टाइमलाइन**

[Sequence](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/) विशिष्ट आकृति पर लागू एनीमेशन प्रभावों का संग्रह है।

[Timeline](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/animationtimeline/) विशिष्ट स्लाइड पर उपयोग की जाने वाली क्रम (sequence) का सेट है। इसे PowerPoint 2002 में पेश किया गया था। PowerPoint के पुराने संस्करणों में एनीमेशन प्रभाव जोड़ना कठिन था और अक्सर वर्कअराउंड की आवश्यकता होती थी। टाइमलाइन पुराने `AnimationSettings` क्लास को बदलता है और PowerPoint एनीमेशन के लिए स्पष्ट ऑब्जेक्ट मॉडल प्रदान करता है। प्रत्येक स्लाइड में केवल एक एनीमेशन टाइमलाइन हो सकती है।

## **इंटरैक्टिव एनीमेशन**

[Trigger](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttriggertype/) आपको उपयोगकर्ता क्रियाओं (जैसे बटन क्लिक) को परिभाषित करने देता है जो किसी विशिष्ट एनीमेशन को शुरू करती हैं। ट्रिगर केवल PowerPoint के नवीनतम संस्करणों में जोड़े गए हैं।

## **आकृति एनीमेशन**

Aspose.Slides आपको आकृतियों—जैसे टेक्स्ट, आयत, रेखा, फ्रेम, OLE ऑब्जेक्ट और अधिक—पर एनीमेशन लागू करने की अनुमति देता है।

{{% alert color="primary" %}}
Read more [**About Shape Animation**](/slides/hi/python-net/shape-animation/).
{{% /alert %}}

## **एनिमेटेड चार्ट**

एनिमेटेड चार्ट बनाने के लिए वही क्लासेस उपयोग करें जो आप आकृतियों के लिए इस्तेमाल करते हैं। हालांकि, PowerPoint एनीमेशन केवल चार्ट श्रेणियों या चार्ट श्रृंखलाओं पर लागू किए जा सकते हैं। आप व्यक्तिगत श्रेणी तत्व या श्रृंखला तत्व पर भी एनीमेशन प्रभाव लागू कर सकते हैं।

{{% alert color="primary" %}}
Read more [**About Animated Charts**](/slides/hi/python-net/animated-charts/).
{{% /alert %}}

## **एनिमेटेड टेक्स्ट**

टेक्स्ट को एनीमेट करने के अलावा, आप पैराग्राफ पर भी एनीमेशन लागू कर सकते हैं।

{{% alert color="primary" %}}
Read more [**About Animated Text**](/slides/hi/python-net/animated-text/).
{{% /alert %}}

## **FAQ**

### क्या PDF में निर्यात करते समय एनीमेशन संरक्षित रहेंगे?

नहीं। PDF एक स्थिर फ़ॉर्मेट है, इसलिए एनीमेशन और [स्लाइड ट्रांज़िशन](/slides/hi/python-net/slide-transition/) चल नहीं पाएंगे। यदि आपको मोशन चाहिए, तो इसके बजाय [HTML5](/slides/hi/python-net/export-to-html5/), [एनिमेटेड GIF](/slides/hi/python-net/convert-powerpoint-to-animated-gif/) या [वीडियो](/slides/hi/python-net/convert-powerpoint-to-video/) में निर्यात करें।

### क्या मैं एनीमेटेड प्रेज़ेंटेशन को वीडियो में बदल सकता हूँ और फ्रेम रेट तथा फ्रेम आकार नियंत्रित कर सकता हूँ?

हाँ। आप [प्रेज़ेंटेशन को फ्रेम्स में रेंडर](/slides/hi/python-net/convert-powerpoint-to-video/) कर सकते हैं और उन्हें वीडियो (जैसे ffmpeg के माध्यम से) में एनकोड कर सकते हैं, जिसमें FPS और रिज़ॉल्यूशन चुन सकते हैं। रेंडरिंग के दौरान एनीमेशन और स्लाइड ट्रांज़िशन चलाए जाते हैं।

### ODP (केवल PPTX नहीं) के साथ काम करते समय एनीमेशन वही रहेंगे?

PPT, PPTX, और ODP को [पढ़ने](/slides/hi/python-net/open-presentation/) और [लिखने](/slides/hi/python-net/save-presentation/) दोनों के लिए समर्थन किया जाता है, लेकिन फ़ॉर्मेट अंतर के कारण कुछ प्रभाव थोड़ा अलग दिख सकते हैं या अलग व्यवहार कर सकते हैं। महत्वपूर्ण मामलों को वास्तविक नमूनों के साथ वैध करें।