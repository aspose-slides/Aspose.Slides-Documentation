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
- कोमल किनारे प्रभाव
- प्रभाव प्रारूप
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python का उपयोग करके उन्नत आकार प्रभावों के साथ अपनी PPT, PPTX और ODP फ़ाइलों को बदलें—सेकंडों में आकर्षक, पेशेवर स्लाइड्स बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, लेकिन ये [भरण](/slides/hi/python-net/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फैलाने आदि कर सकते हैं।

![आकार प्रभाव](shape-effect.png)

PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक या अधिक प्रभाव एक आकार पर लागू कर सकते हैं।

कुछ प्रभाव संयोजन अन्य की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प मूलतः दो या अधिक प्रभावों का एक ज्ञात अच्छा संयोजन होता है। इस तरह, एक प्रीसेट चयन करके आपको विभिन्न प्रभावों का परीक्षण या संयोजन करने में समय नहीं बर्बाद करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) वर्ग के तहत गुण और विधियाँ प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान प्रभाव लागू करने की अनुमति देती हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for Python via .NET आकारों के लिए बाहरी और आंतरिक छायाएँ समर्थन करता है। आप उनका रंग, दिशा, दूरी और ब्लर त्रिज्या को अपने प्रस्तुतीकरण की डिज़ाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

बाहरी छाया का उपयोग करके कोई कार्ड या पैनल स्लाइड पृष्ठभूमि के विरुद्ध प्रमुख बनता है। छाया आकार की किनारों से बाहर तक विस्तृत होती है, जिससे ऐसा प्रभाव उत्पन्न होता है कि आकार स्लाइड के ऊपर उठा हुआ है। अपने टेम्प्लेट की प्रकाश व्यवस्था और शैली से मेल खाने के लिए इसका रंग, दिशा, दूरी और ब्लर त्रिज्या समायोजित करें।

यह Python कोड दिखाता है कि कैसे एक आयत पर [outer shadow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) लागू किया जाए:

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

![छाया प्रभाव](shadow_effect.png)

### **आंतरिक छाया लागू करें**

टेम्प्लेट की दृश्य शैली को पुनः बनाते समय, किसी कार्ड या पैनल को अंतर्निहित रूप से ढँका दिखाने के लिए आंतरिक छाया का उपयोग करें। बाहरी छाया आकार के बाहर तक विस्तृत होती है और इसे उठी हुई बनाती है, जबकि आंतरिक छाया उसके किनारों के अंदर को शेड करती है।

[enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) को कॉल करें, फिर [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) को कॉन्फ़िगर करें। बड़ी ब्लर‑त्रिज्या मान धीमी किनारें बनाते हैं।

यह Python उदाहरण हल्का नीला कार्ड डार्क ग्रे आंतरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है:

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

![आंतरिक छाया के साथ हल्का नीला आयत](inner_shadow_effect.png)

आंतरिक छाया हटाने के लिए, आकार के effect format पर [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) को कॉल करें।

### **प्रीसेट छाया लागू करें, बदलें और हटाएँ**

[enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) को कॉल करें और छाया की [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) गुण को एक [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) मान पर सेट करें। शैली बदलने के लिए, उसी आकार पर प्रीसेट को बदलें। छाया को हटाने के लिए, जबकि भराव और रूपरेखा को बरकरार रखें, [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) को कॉल करें।

यह उदाहरण एक स्लाइड पर चार चरणों को एक साथ दिखाता है। यह प्रत्येक परिवर्तन से पहले आयत को क्लोन करता है ताकि आप परिणामों की तुलना कर सकें। दोनों छायाएँ 10 पॉइंट से ऑफ़सेट हैं। 225° की दिशा पहली छाया को आयत के ऊपर और बाएँ रखती है, और 45° की दिशा दूसरी छाया को नीचे और दाएँ रखती है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| मूल | पहला प्रीसेट | दूसरा प्रीसेट | हटाने के बाद |
| :---: | :---: | :---: | :---: |
| ![कोई छाया नहीं](preset_shadow_original.png) | ![ऊपर-बाएँ ड्रॉप छाया](preset_shadow_top_left.png) | ![नीचे‑दाएँ ड्रॉप छाया](preset_shadow_bottom_right.png) | ![हटाने के बाद कोई छाया नहीं](preset_shadow_removed.png) |

## **परावर्तन प्रभाव लागू करें**

Aspose.Slides for Python via .NET में परावर्तन प्रभाव लागू करने के लिए, आप आकारों में एक दर्पण‑समान परावर्तन जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे मानकों को समायोजित कर सकते हैं। यह प्रभाव आपके प्रस्तुतियों की सौंदर्यशास्त्र को बेहतर बनाता है, आकारों को अधिक चमकदार और परिष्कृत लुक देता है। यह सरल कोड के साथ आसानी से लागू किया जा सकता है, जिससे कई तत्वों पर समान डिज़ाइन शीघ्रता से लागू हो जाता है।

यह Python कोड दिखाता है कि कैसे एक आकार पर [reflection effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) लागू किया जाए:

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

![परावर्तन प्रभाव](reflection_effect.png)

## **चमक प्रभाव लागू करें**

Aspose.Slides for Python via .NET में कोई आकार पर चमक प्रभाव लागू करने के लिए, आप आकारों के चारों ओर एक नरम, प्रकाशमान आभा जोड़ सकते हैं, रंग और आकार जैसे गुणों को समायोजित कर सकते हैं। यह प्रभाव आकारों को प्रमुख बनाता है और आपके प्रस्तुतीकरण में आकर्षक दृश्य तत्व जोड़ता है। न्यूनतम कोड के साथ इसे आसानी से लागू किया जा सकता है, जिससे आपकी स्लाइड्स का समग्र दृश्य बेहतर होता है।

यह Python कोड दिखाता है कि कैसे एक आकार पर [glow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) लागू किया जाए:

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

![चमक प्रभाव](glow_effect.png)

## **कोमल किनारे प्रभाव लागू करें**

Aspose.Slides for Python via .NET में कोमल किनारे प्रभाव लागू करने के लिए, आप आकार के किनारों के आसपास एक स्मूद, धुंधला संक्रमण बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत लुक जोड़ता है, जो उन डिज़ाइनों के लिए उपयुक्त है जिन्हें कोमल, हल्का रूप चाहिए। आप विभिन्न आकारों में वांछित प्रभाव प्राप्त करने के लिए त्रिज्या जैसे मानकों को आसानी से समायोजित कर सकते हैं।

यह Python कोड दिखाता है कि कैसे एक आकार पर [soft edges](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) लागू किया जाए:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![कोमल किनारे प्रभाव](soft_edges_effect.png)

## **ब्लर प्रभाव लागू करें**

आकार ब्लर का उपयोग करके आप आकार की भराव और रूपरेखा को नरम बना सकते हैं जबकि आकार संपादन योग्य बना रहता है। आकार के effect format पर [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) को कॉल करें। त्रिज्या पॉइंट में मापी जाती है (1/72 इंच): एक गैर‑नकारात्मक मान उपयोग करें, जहाँ बड़े मान अधिक तेज़ ब्लर उत्पन्न करते हैं। शून्य त्रिज्या आकार को अपरिवर्तित छोड़ देती है।

[grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) सेटिंग प्रभाव की दृश्यमान सीमा को नियंत्रित करती है। `False` होने पर, ब्लर मूल पेंट की सीमाओं तक सीमित रहता है, जिसमें रूपरेखा भी शामिल है। `True` होने पर, ब्लर उन सीमाओं से परे भी विस्तारित हो सकता है। कोई भी सेटिंग आकार की स्थिति या आयामों को नहीं बदलती।

नीचे दिया गया तुलना समान भराव, रूपरेखा और आकार आयामों के साथ किया गया है। शीर्ष पंक्ति में `grow = False`; नीचे की पंक्ति में `grow = True`।

![मूल आयत की तुलना 5 और 15 पॉइंट ब्लर त्रिज्या के साथ, जहाँ grow निष्क्रिय और सक्षम है](shape_blur_comparison.png)

यह Python उदाहरण एक नारंगी आयत को डार्क ब्लू रूपरेखा के साथ बनाता है, 5‑पॉइंट ब्लर लागू करता है, फिर फिर से [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) को कॉल करके 15‑पॉइंट ब्लर में अपडेट करता है। यह दोनों ब्लर किए हुए स्थितियों को सहेजता है, फिर [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) को कॉल करके ब्लर के बिना आकार को सहेजता है।

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

आकार ब्लर भराव और रूपरेखा को एक साथ प्रभावित करता है। कोमल किनारे प्रभाव आकार की किनारों को धुंधला करता है, जबकि छाया ब्लर केवल छाया को नरम करता है। छवि रूपांतरण प्रभाव छवि सामग्री पर कार्य करते हैं; यह उदाहरण आकार को प्रतिमा में परिवर्तित किए बिना सीधे आकार के effect format पर ब्लर लागू करता है।

## **FAQ**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हां, आप एक ही आकार पर विभिन्न प्रभावों, जैसे छाया, परावर्तन और चमक, को मिलाकर अधिक गतिशील स्वरूप बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लगा सकते हैं, जिनमें ऑटॉशेप्स, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अधिक शामिल हैं।

**क्या मैं समूहित आकारों पर प्रभाव लगा सकता हूँ?**

हां, आप समूहित आकारों पर प्रभाव लगा सकते हैं। प्रभाव पूरे समूह पर लागू होगा।