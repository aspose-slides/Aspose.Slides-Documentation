---
title: Python में एनीमेशन के साथ PowerPoint प्रस्तुतियों को उन्नत करें
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
description: "Aspose.Slides for Python via .NET की PowerPoint एनीमेशन को संभालने की क्षमताओं का अन्वेषण करें। यह सामान्य अवलोकन प्रमुख विशेषताओं को उजागर करता है और आपके प्रस्तुतियों को बेहतर बनाने के लिए अंतर्दृष्टि प्रदान करता है।"
---
## **परिचय**

प्रजेंटेशन जानकारी पहुँचाने के लिए डिज़ाइन किए जाते हैं, इसलिए उनके दृश्य रूप और इंटरैक्टिव व्यवहार निर्माण के दौरान प्रमुख विचार होते हैं।

**PowerPoint animation** प्रस्तुति को दर्शकों के लिए आकर्षक और संलग्न बनाने में महत्वपूर्ण भूमिका निभाता है। Aspose.Slides for Python via .NET PowerPoint प्रस्तुति में एनीमेशन जोड़ने के लिए कई विकल्प प्रदान करता है। आप:

- विभिन्न एनीमेशन इफ़ेक्ट्स को आकारों, चार्ट्स, तालिकाओं, OLE ऑब्जेक्ट्स, और अन्य तत्वों पर लागू करें।
- एक ही आकार पर कई एनीमेशन इफ़ेक्ट्स का उपयोग करें।
- एनीमेशन टाइमलाइन के माध्यम से इफ़ेक्ट्स को नियंत्रित करें।
- कस्टम एनीमेशन बनाएं।

Aspose.Slides for Python via .NET में, एनीमेशन इफ़ेक्ट्स को आकारों पर लागू किया जा सकता है। क्योंकि स्लाइड पर प्रत्येक तत्व—टेक्स्ट, चित्र, OLE ऑब्जेक्ट्स, और तालिकाएँ—को आकार माना जाता है, आप स्लाइड पर किसी भी तत्व पर एनीमेशन इफ़ेक्ट्स लागू कर सकते हैं।

[aspose.slides.animation](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/) नेमस्पेस PowerPoint एनीमेशन के साथ काम करने के लिए क्लासेज़ प्रदान करता है।

## **स्थापना**

```bash
pip install aspose.slides
```

## **Python में आकार पर एनीमेशन इफ़ेक्ट जोड़ना**

एनीमेशन इफ़ेक्ट्स स्लाइड की मुख्य अनुक्रम में रहते हैं। एक आकार जोड़ें, फिर `slide.timeline.main_sequence` पर `add_effect` कॉल करें, जिसमें इफ़ेक्ट प्रकार, उसका सबटाइप, और वह ट्रिगर पास करें जो इसे शुरू करता है।

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

सहेजी गई फ़ाइल में पहले स्लाइड पर एक इफ़ेक्ट है: जब प्रस्तुतकर्ता क्लिक करता है तो आयत बाएँ से दो सेकंड में उड़कर आती है। इसे फिर से खोलने और `slide.timeline.main_sequence` पढ़ने पर वही इफ़ेक्ट मिलता है, इसलिए एनीमेशन मेमोरी में केवल मौजूद रहने के बजाय राउंड ट्रिप में बना रहता है।

## **एनीमेशन इफ़ेक्ट्स**

Aspose.Slides **150+ एनीमेशन इफ़ेक्ट्स** का समर्थन करता है, जिसमें बाउंस, PathFootball, और ज़ूम जैसी बुनियादी इफ़ेक्ट्स, साथ ही OLEObjectShow और OLEObjectOpen जैसी विशिष्ट इफ़ेक्ट्स शामिल हैं। आप पूरी सूची [EffectType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttype/) एनाक्रिया में पा सकते हैं।

- [ColorEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/seteffect/)

## **कस्टम एनीमेशन**

Python में पूर्ण उदाहरणों के लिए जो व्यवहार और संपादन योग्य मोशन पाथ बनाते, निरीक्षण करते और संशोधित करते हैं, देखें [Custom Animation](/slides/hi/python-net/custom-animation/)।

आप Aspose.Slides में कई व्यवहारों को एक इफ़ेक्ट में मिलाकर अपनी स्वयं की **कस्टम एनीमेशन** बना सकते हैं।

[Behavior](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behavior/) PowerPoint एनीमेशन इफ़ेक्ट का निर्माण ब्लॉक है। प्रभाव को अनुकूलित करने के लिए व्यवहारों को मिलाएं, या पूर्वपरिभाषित प्रभाव को विस्तारित करने के लिए एक व्यवहार जोड़ें। पुनरावृत्ति को अलग रेपीट व्यवहार की बजाय टाइमिंग सेटिंग्स के माध्यम से कॉन्फ़िगर किया जाता है।

[Animation Point](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/point/) वह क्षण या स्थिति चिह्नित करता है जहाँ एक व्यवहार लागू होता है (एक कीफ़्रेम)।

## **एनीमेशन टाइमलाइन**

[Sequence](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/) विभिन्न आकारों को लक्षित करने वाले एनीमेशन इफ़ेक्ट्स का संग्रह है।

[Timeline](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/animationtimeline/) एक विशिष्ट स्लाइड पर उपयोग किए जाने वाले अनुक्रमों का सेट है। यह PowerPoint 2002 में प्रस्तुत किया गया था। PowerPoint के पहले संस्करणों में एनीमेशन इफ़ेक्ट्स जोड़ना कठिन था और अक्सर उपायों की आवश्यकता होती थी। टाइमलाइन पुराने `AnimationSettings` क्लास को प्रतिस्थापित करता है और PowerPoint एनीमेशन के लिए अधिक स्पष्ट ऑब्जेक्ट मॉडल प्रदान करता है। प्रत्येक स्लाइड में केवल एक एनीमेशन टाइमलाइन हो सकती है।

## **इंटरएक्टिव एनीमेशन**

[Trigger](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttriggertype/) आपको उपयोगकर्ता क्रियाएँ (जैसे बटन क्लिक) परिभाषित करने देता है जो एक विशिष्ट एनीमेशन शुरू करती हैं। ट्रिगर्स केवल PowerPoint के नवीनतम संस्करणों में जोड़े गए थे।

## **आकार एनीमेशन**

Aspose.Slides आपको आकारों—जैसे टेक्स्ट, आयत, रेखाएँ, फ्रेम, OLE ऑब्जेक्ट्स, और अधिक—पर एनीमेशन लागू करने देता है।

{{% alert color="info" title="Note" %}}
Read more [**Shape Animation के बारे में**](/slides/hi/python-net/shape-animation/).
{{% /alert %}}

## **एनिमेटेड चार्ट्स**

एनिमेटेड चार्ट्स बनाने के लिए, आकारों की तरह ही क्लासेज़ का उपयोग करें। लेकिन, PowerPoint एनीमेशन केवल चार्ट श्रेणियों या चार्ट सीरीज पर ही लागू किए जा सकते हैं। आप एक व्यक्तिगत श्रेणी तत्व या सीरीज़ तत्व पर भी एनीमेशन इफ़ेक्ट लगा सकते हैं।

{{% alert color="info" title="Note" %}}
Read more [**एनिमेटेड चार्ट्स के बारे में**](/slides/hi/python-net/animated-charts/).
{{% /alert %}}

## **एनिमेटेड टेक्स्ट**

टेक्स्ट को एनीमेट करने के अतिरिक्त, आप पैराग्राफ पर भी एनीमेशन लागू कर सकते हैं।

{{% alert color="info" title="Note" %}}
Read more [**एनिमेटेड टेक्स्ट के बारे में**](/slides/hi/python-net/animated-text/).
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PDF में निर्यात करने पर एनीमेशन संरक्षित रहते हैं?**

नहीं। PDF एक स्थिर स्वरूप है, इसलिए एनीमेशन और [slide transitions](/slides/hi/python-net/slide-transition/) नहीं चलते। यदि आपको मोशन चाहिए, तो इसके बजाय [HTML5](/slides/hi/python-net/export-to-html5/), [animated GIF](/slides/hi/python-net/convert-powerpoint-to-animated-gif/), या [video](/slides/hi/python-net/convert-powerpoint-to-video/) में निर्यात करें।

**क्या मैं एनिमेटेड प्रेजेंटेशन को वीडियो में बदल सकता हूँ और फ्रेम रेट तथा फ्रेम आकार नियंत्रित कर सकता हूँ?**

हाँ। आप प्रेजेंटेशन को [render the presentation as frames](/slides/hi/python-net/convert-powerpoint-to-video/) कर सकते हैं और उन्हें वीडियो में एन्कोड कर सकते हैं (जैसे ffmpeg के माध्यम से), FPS और रिज़ॉल्यूशन चुनते हुए। रेंडरिंग के दौरान एनीमेशन और स्लाइड ट्रांज़िशन चलाए जाते हैं।

**ODP (केवल PPTX नहीं) के साथ काम करने पर एनीमेशन बरकरार रहते हैं?**

PPT, PPTX, और ODP को [reading](/slides/hi/python-net/open-presentation/) और [writing](/slides/hi/python-net/save-presentation/) के लिए समर्थन किया जाता है, लेकिन यह एनीमेशन संरक्षित रहने की गारंटी नहीं देता। ODP में परिवर्तित करने पर कस्टम एनीमेशन डेटा खो सकता है। उदाहरण और फ़ॉर्मेट संगतता जाँचने के लिए [Custom Animation](/slides/hi/python-net/custom-animation/) देखें।