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
- ग्लो प्रभाव
- नरम किनारे प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT, PPTX और ODP फ़ाइलों को परिवर्तित करें—सेकंडों में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग किसी आकार को उभारने के लिए किया जा सकता है, लेकिन वे [भरण](/slides/hi/python-net/shape-formatting/#gradient-fill) या रूपरेखा से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक को फैलाने आदि कर सकते हैं।

![आकार प्रभाव](shape-effect.png)

PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक या अधिक प्रभाव किसी आकार पर लागू कर सकते हैं।

कुछ प्रभावों के संयोजन अन्य की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प मूलतः दो या अधिक प्रभावों के ज्ञात सुंदर संयोजन होते हैं। इस प्रकार, एक प्रीसेट चुनकर आपको विभिन्न प्रभावों को आज़माने या संयोजित करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides प्रदान करता है गुण और विधियाँ जो [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) वर्ग के अंतर्गत उपलब्ध हैं और आपको PowerPoint प्रस्तुतियों में आकारों पर समान प्रभाव लागू करने की अनुमति देती हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for Python via .NET आकारों के लिए बाहरी और भीतरी छायाएँ समर्थन करता है। आप उनके रंग, दिशा, दूरी और ब्लर त्रिज्या को अपनी प्रस्तुति के डिज़ाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

एक बाहरी छाया का उपयोग करके कार्ड या पैनल को स्लाइड पृष्ठभूमि के खिलाफ उभरते हुए दिखाएँ। छाया आकार के किनारों से बाहर तक फैली होती है, जिससे यह दिखता है कि आकार स्लाइड से ऊपर उठाया गया है। इसका रंग, दिशा, दूरी और ब्लर त्रिज्या को अपने टेम्प्लेट की रोशनी और शैली के अनुसार समायोजित करें।

यह Python कोड दिखाता है कि कैसे आयत पर [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) लागू किया जाए:

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

#### **जब आकार घुमता है तो छाया की दिशा नियंत्रित करें**

डिफ़ॉल्ट रूप से, [OuterShadow.rotate_shadow_with_shape](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/rotate_shadow_with_shape/) `True` होता है, इसलिए छाया आकार के साथ घूमती है। विभिन्न घूर्णन वाले आकारों को समान दिशा से प्रकाशित दिखाने के लिए, इस गुण को `False` सेट करें और उनकी छायाओं को समान [दिशा](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/direction/) दें।

यह उदाहरण दो तीर बनाता है जिनकी धूसर छायाएँ 42 पॉइंट दाईं ओर (`direction = 0`) ऑफ़सेट होती हैं। फिर यह स्लाइड की प्रतिलिपि बनाता है और दोनों तीरों को 90° घड़ी की दिशा में घुमाता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    before = presentation.slides[0]

    left = before.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 55, 130, 110, 60)
    left.fill_format.fill_type = slides.FillType.SOLID
    left.fill_format.solid_fill_color.color = slides.Color.steel_blue
    left.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    left.effect_format.enable_outer_shadow_effect()
    shadow = left.effect_format.outer_shadow_effect
    shadow.shadow_color.color = slides.Color.gray
    shadow.direction = 0
    shadow.distance = 42
    shadow.blur_radius = 0
    shadow.rotate_shadow_with_shape = True

    right = before.shapes.add_clone(left)
    right.x = 395
    right.effect_format.outer_shadow_effect.rotate_shadow_with_shape = False

    after = presentation.slides.add_clone(before)
    for arrow in after.shapes:
        arrow.rotation = 90

    presentation.save("arrow_shadows.pptx", slides.export.SaveFormat.PPTX)
```

दूसरी स्लाइड पर, बाएँ तीर की छाया नीचे की ओर गिरती है, जबकि दाएँ तीर की छाया अभी भी दाएँ की ओर रहती है। दोनों छायाओं की कॉन्फ़िगर की गई दिशा 0° बनी रहती है।

![90° घुमाने से पहले और बाद में PowerPoint रेंडरिंग। दोनों छायाएँ दाएँ से शुरू होती हैं। घुमाने के बाद, छाया बाएँ तीर के नीचे जा जाती है और दाएँ तीर के दाएँ बनी रहती है।](arrow-shadow-rotation.png)

### **भीतर की छाया लागू करें**

यदि आप किसी टेम्प्लेट की दृश्य शैली को दोहराना चाहते हैं, तो भीतर की छाया का उपयोग करके कार्ड या पैनल को रिकॉस्ड दिखा सकते हैं। बाहरी छाया आकार के बाहर विस्तारित होती है और उसे उठाया हुआ दिखाती है, जबकि भीतर की छाया किनारों के भीतर को शेड करती है।

[enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) को कॉल करें, फिर [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) को कॉन्फ़िगर करें। बड़ी ब्लर-त्रिज्या मान मुलायम किनारे उत्पन्न करते हैं।

यह Python उदाहरण एक हल्के नीले कार्ड को गहरे ग्रे भीतर छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है:

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

![भीतर की छाया के साथ हल्का नीला आयत](inner_shadow_effect.png)

भीतर की छाया हटाने के लिए, आकार की इफ़ेक्ट फ़ॉर्मेट पर [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) को कॉल करें।

### **एक प्रीसेट छाया लागू करें, बदलें और हटाएं**

[enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) को कॉल करें और छाया की [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) गुण को एक [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) मान पर सेट करें। शैली बदलने के लिए, उसी आकार पर प्रीसेट बदलें। छाया को हटाने के लिए, जबकि भरण और रूपरेखा बनी रहे, [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) को कॉल करें।

यह उदाहरण एक स्लाइड पर चार चरणों को बगल में दिखाता है। प्रत्येक परिवर्तन से पहले आयत की प्रतिलिपि बनाता है ताकि आप परिणामों की तुलना कर सकें। दोनों छायाएँ 10 पॉइंट ऑफ़सेट हैं। 225° दिशा पहली छाया को आयत के ऊपर और बाएँ रखती है, जबकि 45° दिशा दूसरी छाया को नीचे और दाएँ रखती है।

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
| ![कोई छाया नहीं](preset_shadow_original.png) | ![ऊपरी-बायाँ ड्रॉप शैडो](preset_shadow_top_left.png) | ![नीचा-दायाँ ड्रॉप शैडो](preset_shadow_bottom_right.png) | ![हटाने के बाद कोई छाया नहीं](preset_shadow_removed.png) |

## **परावर्तन प्रभाव लागू करें**

परावर्तन प्रभाव को Aspose.Slides for Python via .NET में लागू करने के लिए, आप आकारों पर दर्पण जैसी परावर्तन जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर को समायोजित कर सकते हैं। यह प्रभाव आपकी प्रस्तुतियों की सौंदर्यशास्त्र को बेहतर बनाता है, आकारों को अधिक परिष्कृत और आकर्षक लुक देता है। इसे सरल कोड के साथ आसानी से लागू किया जा सकता है, जिससे कई तत्वों पर लगातार डिजाइन लागू किया जा सके।

यह Python कोड दिखाता है कि कैसे आकार पर [परावर्तन प्रभाव](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) लागू किया जाए:

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

## **ग्लो प्रभाव लागू करें**

Aspose.Slides for Python via .NET में आकार पर ग्लो प्रभाव लागू करने के लिए, आप आकार के चारों ओर एक नरम, चमकीला आभा जोड़ सकते हैं, रंग और आकार जैसी विशेषताओं को समायोजित कर सकते हैं। यह प्रभाव आकारों को उभारा करता है और आपकी प्रस्तुति में आकर्षक दृश्य तत्व जोड़ता है। इसे न्यूनतम कोड के साथ आसानी से लागू किया जा सकता है, जिससे स्लाइड का समग्र रूप सुधरता है।

यह Python कोड दिखाता है कि कैसे आकार पर [ग्लो प्रभाव](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) लागू किया जाए:

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

![ग्लो प्रभाव](glow_effect.png)

## **नरम किनारे प्रभाव लागू करें**

Aspose.Slides for Python via .NET में नरम किनारे प्रभाव लागू करने के लिए, आप आकार के किनारों के चारों ओर एक स्मूद, धुंधला ट्रांज़िशन बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत लुक जोड़ता है, जो उन डिज़ाइनों के लिए उपयुक्त है जिन्हें हल्का, नरम रूप चाहिए। आप विभिन्न आकारों में समान प्रभाव प्राप्त करने के लिए त्रिज्या जैसे पैरामीटर को आसानी से समायोजित कर सकते हैं।

यह Python कोड दिखाता है कि कैसे आकार पर [नरम किनारे](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) लागू किया जाए:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![नरम किनारे प्रभाव](soft_edges_effect.png)

## **ब्लर प्रभाव लागू करें**

आकार ब्लर का उपयोग करके आप आकार की भरण और रूपरेखा को नरम बना सकते हैं जबकि आकार को संपादन योग्य रख सकते हैं। आकार की इफ़ेक्ट फ़ॉर्मेट पर [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) को कॉल करें। त्रिज्या पॉइंट में मापी जाती है (1/72 इंच): एक गैर‑नकारात्मक मान उपयोग करें, बड़ी मान अधिक तेज़ ब्लर बनाते हैं। शून्य त्रिज्या आकृति को अपरिवर्तित रखती है।

[grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) सेटिंग प्रभाव की दृश्यमान सीमा को नियंत्रित करती है। `False` के साथ, ब्लर मूल पेंट की गई सीमा तक सीमित रहता है, जिसमें रूपरेखा भी शामिल है। `True` के साथ, ब्लर उन सीमाओं से बाहर भी विस्तारित हो सकता है। कोई भी सेटिंग आकार की स्थिति या आयाम नहीं बदलती।

नीचे का तुलना समान भरण, रूपरेखा और आकार आयामों का उपयोग करता है। शीर्ष पंक्ति `grow = False` उपयोग करती है; नीचे की पंक्ति `grow = True` उपयोग करती है।

![मूल आयत की तुलना 5 और 15 पॉइंट ब्लर त्रिज्या, grow निष्क्रिय और सक्रिय के साथ](shape_blur_comparison.png)

यह Python उदाहरण एक नारंगी आयत को गहरे नीले रूपरेखा के साथ बनाता है, 5‑पॉइंट ब्लर लागू करता है, फिर इसे फिर से [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) को कॉल करके 15‑पॉइंट ब्लर में अपडेट करता है। यह दोनों ब्लर अवस्थाओं को सहेजता है, फिर [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) को कॉल करता है और ब्लर के बिना आकार को सहेजता है।

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

आकार ब्लर भरण और रूपरेखा दोनों को प्रभावित करता है। नरम किनारे प्रभाव आकार के किनारों को फीका करता है, जबकि छाया ब्लर केवल छाया को नरम करता है। छवि परिवर्तन प्रभाव छवि सामग्री पर काम करते हैं; यह उदाहरण आकार को छवि में परिवर्तित किए बिना सीधे आकार की इफ़ेक्ट फ़ॉर्मेट पर ब्लर लागू करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप एकल आकार पर छाया, परावर्तन और ग्लो जैसे विभिन्न प्रभावों को संयोजित करके अधिक गतिशील उपस्थिति बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लागू कर सकते हैं, जिसमें ऑटोहैश, चार्ट, तालिका, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट आदि शामिल हैं।

**क्या मैं समूहित आकारों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरे समूह पर लागू होगा।