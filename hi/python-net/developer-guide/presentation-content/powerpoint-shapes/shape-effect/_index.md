---
title: Python के साथ प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/python-net/shape-effect
keywords:
- आकार प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- चमक प्रभाव
- नरम किनारे प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT, PPTX और ODP फ़ाइलों को बदलें—सेकंडों में आकर्षक, पेशेवर स्लाइड्स बनाएं।"
---
## **परिचय**

जबकि PowerPoint में इफ़ेक्ट्स को किसी आकार को उभारने के लिए इस्तेमाल किया जा सकता है, वे [fills](/slides/hi/python-net/shape-formatting/#gradient-fill) या outlines से भिन्न होते हैं। PowerPoint इफ़ेक्ट्स का उपयोग करके आप किसी आकार पर भरोसेमंद प्रतिबिंब, आकार की चमक को फैलाना आदि बना सकते हैं।

![Shape effect](shape-effect.png)

PowerPoint छह इफ़ेक्ट्स प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक या अधिक इफ़ेक्ट्स को किसी आकार पर लागू कर सकते हैं।

इफ़ेक्ट्स के कुछ संयोजन दूसरों से बेहतर दिखते हैं। इस कारण से, PowerPoint के पास **Preset** नामक विकल्प है। प्रीसेट विकल्प मूल रूप से दो या अधिक इफ़ेक्ट्स के एक अच्छी दिखने वाले संयोजन होते हैं। इस तरह, प्रीसेट चुन कर आपको विभिन्न इफ़ेक्ट्स को आज़माने या मिलाने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides प्रदान करता है प्रॉपर्टीज़ और मेथड्स [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) क्लास के तहत, जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान इफ़ेक्ट्स लागू करने की अनुमति देते हैं।

## **शैडो इफ़ेक्ट लागू करें**

Aspose.Slides for Python via .NET आकारों के लिए बाहरी और आंतरिक शैडो का समर्थन करता है। आप उनके रंग, दिशा, दूरी और ब्लर रेडियस को अपनी प्रस्तुति के डिज़ाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी शैडो लागू करें**

बाहरी शैडो का उपयोग करके किसी कार्ड या पैनल को स्लाइड बैकग्राउंड के खिलाफ उभारा जा सकता है। शैडो आकार की किनारों से बाहर तक फैलता है, जिससे ऐसा प्रभाव बनता है कि आकार स्लाइड पर उठा हुआ है। इसके रंग, दिशा, दूरी और ब्लर रेडियस को अपने टेम्पलेट की लाइटिंग और शैली के अनुसार समायोजित करें।

यह Python कोड दिखाता है कि कैसे [outer shadow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) को एक आयत पर लागू किया जाए:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Shadow effect](shadow_effect.png)

### **आंतरिक शैडो लागू करें**

किसी टेम्पलेट की दृश्य शैली को दोहराते समय, आंतरिक शैडो का उपयोग करके कार्ड या पैनल को सम्मिलित दिखाया जा सकता है। बाहरी शैडो आकार के बाहर तक विस्तारित होता है और उसे उठाया हुआ दिखाता है, जबकि आंतरिक शैडो किनारों के अंदर भाग को छाया देता है।

[enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) को कॉल करें, फिर [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) को कॉन्फ़िगर करें। बड़े ब्लर-रेडियस मान नरम किनारे उत्पन्न करते हैं।

यह Python उदाहरण एक हल्के नीले कार्ड को गहरे ग्रे आंतरिक शैडो के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

आंतरिक शैडो को हटाने के लिए, आकार की इफ़ेक्ट फ़ॉर्मेट पर [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) को कॉल करें।

## **रिफ्लेक्शन इफ़ेक्ट लागू करें**

Aspose.Slides for Python via .NET में रिफ्लेक्शन इफ़ेक्ट लागू करने के लिए, आप आकारों में दर्पण जैसी प्रतिबिंब जोड़ सकते हैं, दूरी, ट्रांसपेरेंसी और साइज जैसे पैरामीटर समायोजित कर सकते हैं। यह इफ़ेक्ट आपकी प्रस्तुतियों की सौंदर्यता को बढ़ाता है, आकारों को अधिक पॉलिश्ड और परिष्कृत रूप देता है। इसे सरल कोड के साथ आसानी से लागू किया जा सकता है, जिससे कई तत्वों पर लगातार डिज़ाइन लागू करना तेज़ हो जाता है।

यह Python कोड दिखाता है कि कैसे [reflection effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) को एक आकार पर लागू किया जाए:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Reflection effect](reflection_effect.png)

## **ग्लो इफ़ेक्ट लागू करें**

Aspose.Slides for Python via .NET में किसी आकार पर ग्लो इफ़ेक्ट लागू करने के लिए, आप आकारों के चारों ओर मुलायम, प्रकाशमान आभा जोड़ सकते हैं, रंग और साइज जैसी प्रॉपर्टीज़ को समायोजित कर सकते हैं। यह इफ़ेक्ट आकारों को उभारता है और आपकी प्रस्तुति में आकर्षक, आंखों को पकड़ने वाला दृश्य तत्व जोड़ता है। इसे न्यूनतम कोड के साथ आसानी से लागू किया जा सकता है, जिससे स्लाइड्स की कुल दिखावट सुधरती है।

यह Python कोड दिखाता है कि कैसे [glow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) को एक आकार पर लागू किया जाए:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Glow effect](glow_effect.png)

## **सॉफ्ट एजेज इफ़ेक्ट लागू करें**

Aspose.Slides for Python via .NET में सॉफ्ट एजेज इफ़ेक्ट लागू करने के लिए, आप आकार के किनारों के आसपास एक स्मूद, ब्लर ट्रांज़िशन बना सकते हैं। यह इफ़ेक्ट अधिक सूक्ष्म और परिष्कृत दिखावट जोड़ता है, उन डिज़ाइनों के लिए उपयुक्त है जिन्हें कोमल, नरम अभिव्यक्ति चाहिए। आप रेडियस जैसे पैरामीटर को आसानी से समायोजित कर विभिन्न आकारों में वांछित प्रभाव प्राप्त कर सकते हैं।

यह Python कोड दिखाता है कि कैसे [soft edges](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) को एक आकार पर लागू किया जाए:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Soft edges effect](soft_edges_effect.png)

## **ब्लर इफ़ेक्ट लागू करें**

शेप ब्लर का उपयोग करके आप आकार की भराव और आउटलाइन को नरम बना सकते हैं जबकि आकार को संपादित योग्य रख सकते हैं। आकार की इफ़ेक्ट फ़ॉर्मेट पर [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) को कॉल करें। रेडियस पॉइंट्स (1/72 इंच) में मापा जाता है: गैर-नकारात्मक मान उपयोग करें, बड़े मान अधिक तीव्र ब्लर पैदा करेंगे। शून्य रेडियस होने पर दिखाई देने वाला रूप वही रहता है।

[grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) सेटिंग इफ़ेक्ट की दृश्य सीमा को नियंत्रित करती है। `False` के साथ, ब्लर मूल पेंटेड सीमा तक सीमित रहता है, जिसमें आउटलाइन भी शामिल है। `True` के साथ, ब्लर उन सीमाओं से बाहर तक विस्तारित हो सकता है। दोनों सेटिंग्स आकार की स्थिति या आयामों को नहीं बदलतीं।

नीचे दिया गया तुलना समान भराव, आउटलाइन और आकार आयामों के साथ की गई है। शीर्ष पंक्ति में `grow = False`; नीचे की पंक्ति में `grow = True`।

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

यह Python उदाहरण एक नारंगी आयत को गहरे नीले आउटलाइन के साथ बनाता है, 5 पॉइंट ब्लर लागू करता है, फिर फिर से [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) को कॉल करके 15 पॉइंट ब्लर में अपडेट करता है। यह दोनों ब्लर किए हुए स्थितियों को सहेजता है, फिर [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) को कॉल करके बिना ब्लर के आकार को सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

Shape blur भराव और आउटलाइन दोनों को एक साथ प्रभावित करता है। सॉफ्ट एजेज इफ़ेक्ट आकार के किनारों को फीका करता है, जबकि शैडो ब्लर केवल शैडो को नरम बनाता है। इमेज ट्रांसफ़ॉर्मेशन इफ़ेक्ट्स इमेज कंटेंट पर काम करते हैं; यह उदाहरण आकार को इमेज में बदलें बिना सीधे आकार की इफ़ेक्ट फ़ॉर्मेट पर ब्लर लागू करता है।

## **FAQ**

**क्या मैं एक ही आकार पर कई इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप शैडो, रिफ्लेक्शन, ग्लो आदि विभिन्न इफ़ेक्ट्स को एक ही आकार पर मिलाकर अधिक गतिशील दिखावट बना सकते हैं।

**मैं किन आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

आप विभिन्न आकारों पर इफ़ेक्ट्स लागू कर सकते हैं, जिसमें ऑटोषेप्स, चार्ट, टेबल, तस्वीरें, SmartArt ऑब्जेक्ट्स, OLE ऑब्जेक्ट्स और अन्य शामिल हैं।

**क्या मैं ग्रुप किए गए आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप ग्रुप किए गए आकारों पर इफ़ेक्ट्स लागू कर सकते हैं। इफ़ेक्ट पूरे समूह पर लागू होगा।