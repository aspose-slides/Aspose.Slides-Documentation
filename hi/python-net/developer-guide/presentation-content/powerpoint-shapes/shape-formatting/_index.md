---
title: "Python में PowerPoint आकार स्वरूपित करें"
linktitle: "आकृति स्वरूपण"
type: docs
weight: 20
url: /hi/python-net/shape-formatting/
keywords:
- "आकार स्वरूपित"
- "रेखा स्वरूपित"
- "स्केच प्रभाव"
- "स्केच आकार रेखा"
- "जोड़ शैली स्वरूपित"
- "ग्रेडिएंट भराव"
- "पैटर्न भराव"
- "चित्र भराव"
- "टेक्सचर भराव"
- "ठोस रंग भराव"
- "आकार पारदर्शिता"
- "काली-सफ़ेद आकार रेंडरिंग"
- "ग्रेस्केल आकार रेंडरिंग"
- "आकार घुमाएँ"
- "3डी बिवेल प्रभाव"
- "3डी घूर्णन प्रभाव"
- "फ़ॉर्मेट रीसेट करें"
- "PowerPoint"
- "प्रस्तुति"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides का उपयोग करके Python में PowerPoint आकार को स्वरूपित करना सीखें—PPT, PPTX, और ODP फ़ाइलों के लिए भराव, रेखा, और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड में आकार जोड़ सकते हैं। चूँकि आकार रेखाओं से बनते हैं, आप उनकी रूपरेखा को संशोधित करके या प्रभाव लागू करके उन्हें स्वरूपित कर सकते हैं। अतिरिक्त रूप से, आप आकारों को उनके अंतरिक भाग को कैसे भरा जाए, इसे नियंत्रित करने वाली सेटिंग्स निर्दिष्ट करके स्वरूपित कर सकते हैं।

![फ़ॉर्मेट‑शेप‑पावरपॉइंट](format-shape-powerpoint.png)

Aspose.Slides for Python क्लास और प्रॉपर्टी प्रदान करता है जो आपको PowerPoint में उपलब्ध वही विकल्पों का उपयोग करके आकारों को स्वरूपित करने की अनुमति देती हैं।

## **रेखा स्वरूपित करें**

Aspose.Slides का उपयोग करके, आप एक आकार के लिए कस्टम रेखा शैली निर्दिष्ट कर सकते हैं। नीचे दिए गए चरण प्रक्रिया का विवरण देते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स के द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार की [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) सेट करें।
1. रेखा की चौड़ाई सेट करें।
1. आकार की [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) सेट करें।
1. आकार के लिए रेखा का रंग सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # आयत आकार से भराव हटाएँ ताकि केवल उसकी रेखाएँ दिखाई दें।
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # आयत की रेखाओं पर स्वरूपण लागू करें।
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # आयत की रेखा के लिए रंग सेट करें।
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

![प्रस्तुति में स्वरूपित रेखाएँ](formatted-lines.png)

## **आकार रेखाओं पर स्केच प्रभाव लागू करें**

एक स्केच प्रभाव आकार की रेखा को हाथ से लिखी हुई जैसा दिखाता है। [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) का उपयोग करके रेखा सेटिंग्स को एक्सेस करें, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) का उपयोग करके स्केच सेटिंग्स को एक्सेस करें, तथा [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) का उपयोग करके [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) एन्नुमरेशन से मान चुनें।

निम्नलिखित Python कोड दिखाता है कि कैसे [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) प्रभाव लागू किया जाए, स्पष्ट रूप से निर्धारित मान पढ़ा जाए, और [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) के साथ प्रभाव हटाया जाए।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # आकार की रेखा फ़ॉर्मेट और उसके स्केच फ़ॉर्मेट तक पहुँचें।
    sketch_format = shape.line_format.sketch_format

    # एक स्केच प्रभाव लागू करें।
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # आकार को सीधे सौंपे गये स्केच प्रभाव को पढ़ें।
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # स्केच प्रभाव हटाएँ।
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

`SketchFormat.sketch_type` द्वारा वापस किया गया मान सीधे आकार को सौंपा गया सेटिंग दर्शाता है। यदि रेखा स्वरूपण थीम, मास्टर स्लाइड, या लेआउट स्लाइड से विरासत में प्राप्त हो सकता है, तो [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/) का उपयोग करें, लौटाई गई ऑब्जेक्ट की `sketch_format` प्रॉपर्टी एक्सेस करें, और उसकी `sketch_type` प्रॉपर्टी पढ़ें। प्रभावी मान वह स्वरूपण दर्शाता है जो विरासत समाधान के बाद वास्तव में लागू किया गया है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **जोड़ शैली स्वरूपित करें**

यहाँ तीन जोड़ प्रकार विकल्प हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोण पर जोड़ता है (जैसे आकार के कोने पर), यह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीक्ष्ण कोण वाले आकार बना रहे हैं, तो आप **Miter** विकल्प को पसंद कर सकते हैं।

![प्रस्तुति में जोड़ शैली](join-style-powerpoint.png)

निम्नलिखित Python कोड दर्शाता है कि ऊपर की छवि में दिखाए गए तीन आयतों को Miter, Bevel, और Round जोड़ प्रकार सेटिंग्स का उपयोग करके कैसे बनाया गया।

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएँ।
with slides.Presentation() as presentation:

	# पहली स्लाइड प्राप्त करें।
	slide = presentation.slides[0]

	# Rectangle प्रकार के तीन ऑटो शेप जोड़ें।
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# प्रत्येक आयत आकार के लिए भरने का रंग सेट करें।
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# रेखा की चौड़ाई सेट करें।
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# प्रत्येक आयत की रेखा के लिए रंग सेट करें।
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# जोड़ शैली सेट करें।
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# प्रत्येक आयत में पाठ जोड़ें।
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# PPTX फ़ाइल को डिस्क पर सहेजें।
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **ग्रेडिएंट फ़िल**

PowerPoint में, Gradient Fill एक स्वरूपण विकल्प है जो आपको एक आकार में लगातार रंगों का मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंगों को इस प्रकार लागू कर सकते हैं कि एक धीरे-धीरे दूसरे में मिल जाए।

यहाँ Aspose.Slides का उपयोग करके एक आकार पर ग्रेडिएंट फ़िल लागू करने का तरीका दिया गया है:

1. एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार के [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) को `GRADIENT` सेट करें।
1. अपनी दो पसंदीदा रंगों को परिभाषित स्थितियों के साथ जोड़ें, `gradient_stops` संग्रह के `add` तरीकों का उपयोग करके, जो [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) क्लास द्वारा प्रदर्शित है।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```python
import aspose.slides as slides

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Ellipse प्रकार का एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # दीर्घवृत्त पर ग्रेडिएंट स्वरूपण लागू करें।
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # ग्रेडिएंट की दिशा सेट करें।
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # दो ग्रेडिएंट स्टॉप जोड़ें।
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

![ग्रेडिएंट फ़िल के साथ दीर्घवृत्त](gradient-fill.png)

यदि एक ग्रेडिएंट निर्यातित छवि में PowerPoint की तुलना में अलग दिखता है, तो देखें [ग्रेडिएंट रेंडरिंग शैली चुनें](/slides/hi/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)। आप प्रस्तुति में संग्रहीत ग्रेडिएंट फ़िल को बदले बिना एक रेंडरिंग शैली चुन सकते हैं।

## **पैटर्न भराव**

PowerPoint में, Pattern Fill एक स्वरूपण विकल्प है जो आपको दो‑रंग वाली डिज़ाइन—जैसे बिन्दु, धारियाँ, क्रॉसहैच, या चेक—एक आकार पर लागू करने देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियाँ प्रदान करता है जिन्हें आप आकारों पर लागू करके अपनी प्रस्तुतियों की दृश्य आकर्षण बढ़ा सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी आप इसे उपयोग करने वाले सटीक रंग निर्दिष्ट कर सकते हैं।

यहाँ Aspose.Slides का उपयोग करके एक आकार पर पैटर्न भराव लागू करने का तरीका दिया गया है:

1. एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार के [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) को `PATTERN` सेट करें।
1. पूर्वनिर्धारित विकल्पों में से एक पैटर्न शैली चुनें।
1. पैटर्न का [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) सेट करें।
1. पैटर्न का [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # भरण प्रकार को Pattern सेट करें।
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # पैटर्न शैली सेट करें।
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # पैटर्न की पृष्ठभूमि और अग्रभूमि के रंग सेट करें।
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

![पैटर्न भराव के साथ आयत](pattern-fill.png)

## **चित्र भराव**

PowerPoint में, Picture Fill एक स्वरूपण विकल्प है जो आपको एक आकार के भीतर एक चित्र डालने की अनुमति देता है—प्रभावी रूप से चित्र को आकार की पृष्ठभूमि के रूप में उपयोग करता है।

यहाँ Aspose.Slides का उपयोग करके एक आकार पर चित्र भराव लागू करने का तरीका दिया गया है:

1. एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार के [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) को `PICTURE` सेट करें।
1. चित्र भराव मोड को `TILE` (या कोई अन्य पसंदीदा मोड) सेट करें।
1. जिस छवि का आप उपयोग करना चाहते हैं, उससे एक [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) ऑब्जेक्ट बनाएँ।
1. इस छवि को आकार के `picture_fill_format` के `picture.image` प्रॉपर्टी में असाइन करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

मान लीजिए हमारे पास "lotus.png" नाम की फ़ाइल निम्नलिखित चित्र के साथ है:

![लोटस चित्र](lotus.png)

```python
import aspose.slides as slides

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # भराव प्रकार को Picture सेट करें।
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # चित्र भराव मोड सेट करें।
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # एक चित्र लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # चित्र सेट करें।
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

![चित्र भराव के साथ आकार](picture-fill.png)

### **टाइल चित्र को टैक्सचर के रूप में सेट करें**

यदि आप टाइलयुक्त चित्र को टैक्सचर के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) क्लास की निम्नलिखित प्रॉपर्टी का उपयोग कर सकते हैं:

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): चित्र भराव मोड सेट करता है—`TILE` या `STRETCH`।
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): आकार के भीतर टाइलों की संरेखण निर्दिष्ट करता है।
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): टाइल को क्षैतिज, ऊर्ध्वाधर या दोनों दिशा में फ़्लिप करने को नियंत्रित करता है।
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): आकार की मूल बिंदु से टाइल का क्षैतिज ऑफ़सेट (पॉइंट में) सेट करता है।
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): आकार की मूल बिंदु से टाइल का ऊर्ध्वाधर ऑफ़सेट (पॉइंट में) सेट करता है।
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): टाइल के क्षैतिज स्केल को प्रतिशत में परिभाषित करता है।
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): टाइल के ऊर्ध्वाधर स्केल को प्रतिशत में परिभाषित करता है।

```py
import aspose.slides as slides

# एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    first_slide = presentation.slides[0]

    # एक आयताकार ऑटो आकार जोड़ें।
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # आकार का भराव प्रकार Picture सेट करें।
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # चित्र लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें।
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # चित्र को आकार को असाइन करें।
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # चित्र भराव मोड और टाइलिंग गुण सेट करें।
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

![टाइल विकल्प](tile-options.png)

## **ठोस रंग भराव**

PowerPoint में, Solid Color Fill एक स्वरूपण विकल्प है जो आकार को एकल, समान रंग से भरता है। यह साधारण पृष्ठभूमि रंग किसी ग्रेडिएंट, टैक्सचर या पैटर्न के बिना लागू किया जाता है।

Aspose.Slides का उपयोग करके एक आकार पर ठोस रंग भराव लागू करने के लिए, निम्न चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार के [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) को `SOLID` सेट करें।
1. आकार को अपनी पसंदीदा भराव रंग असाइन करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # भराव प्रकार को Solid सेट करें।
    shape.fill_format.fill_type = slides.FillType.SOLID

    # भराव रंग सेट करें।
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

![ठोस रंग भराव के साथ आकार](solid-color-fill.png)

## **पारदर्शिता सेट करें**

PowerPoint में, जब आप आकारों पर ठोस रंग, ग्रेडिएंट, चित्र या टैक्सचर भराव लागू करते हैं, तो आप पारदर्शिता स्तर भी सेट कर सकते हैं जिससे भराव की अपारदर्शिता नियंत्रित होती है। उच्च पारदर्शिता मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या अंतर्निहित वस्तुएँ आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको भराव में उपयोग किए गए रंग के अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने की अनुमति देता है। इसे करने का तरीका इस प्रकार है:

1. एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) जोड़ें।
1. भराव प्रकार को `SOLID` सेट करें।
1. `Color.from_argb` का उपयोग करके पारदर्शिता वाले रंग को परिभाषित करें (अल्फा घटक पारदर्शिता को नियंत्रित करता है)।
1. प्रस्तुति को सहेजें।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]
    
    # एक ठोस आयताकार ऑटो शैप जोड़ें।
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # ठोस आकार के ऊपर एक पारदर्शी आयताकार ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

![पारदर्शी आकार](shape-transparency.png)

## **आकार घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकारों को घुमाने की अनुमति देता है। यह विशेष रूप से दृश्य तत्वों को विशिष्ट संरेखण या डिज़ाइन आवश्यकता के साथ स्थित करने में उपयोगी हो सकता है।

एक आकार को स्लाइड पर घुमाने के लिए निम्न चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार के `rotation` प्रॉपर्टी को इच्छित कोण पर सेट करें।
1. प्रस्तुति को सहेजें।

```python
import aspose.slides as slides

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # आकार को 5 डिग्री घुमाएँ।
    shape.rotation = 5

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![आकार का घूर्णन](shape-rotation.png)

## **3D बिवेल प्रभाव जोड़ें**

Aspose.Slides आपको आकारों पर 3D बिवेल प्रभाव लागू करने की सुविधा देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करते हैं।

3D बिवेल प्रभाव जोड़ने के लिए नीचे दिए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार के [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) को बिवेल सेटिंग्स परिभाषित करने के लिए कॉन्फ़िगर करें।
1. प्रस्तुति को सहेजें।

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation क्लास का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # स्लाइड में एक आकार जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # आकार के ThreeDFormat गुण सेट करें।
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

![3D बिवेल प्रभाव](3D-bevel-effect.png)

## **3D घूर्णन प्रभाव जोड़ें**

Aspose.Slides आपको आकारों पर 3D घूर्णन प्रभाव लागू करने की सुविधा देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करते हैं।

3D घूर्णन लागू करने के लिए नीचे दिए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार के [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) और [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) को सेट करके 3D घूर्णन परिभाषित करें।
1. प्रस्तुति को सहेजें।

```python
import aspose.slides as slides

# Presentation क्लास का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

![3D घूर्णन प्रभाव](3D-rotation-effect.png)

## **आकारों के लिए काली‑सफ़ेद रेंडरिंग नियंत्रित करें**

[Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) प्रॉपर्टी निर्धारित करती है कि जब प्रस्तुति को काली‑सफ़ेद मोड में देखा या प्रोसेस किया जाए तो व्यक्तिगत आकार कैसे रेंडर होगा। यह स्वयं काली‑सफ़ेद डिस्प्ले को सक्रिय नहीं करता, और यह सामान्य रंग मोड में आकार की फ़िल, रेखा या अन्य स्वरूपण नहीं बदलता।

[BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) एन्नुमरेशन से मान का उपयोग करके इच्छित व्यवहार चुनें। उदाहरण के लिए, `AUTOMATIC` रेंडरिंग एप्लिकेशन को परिवर्तन चुनने देता है, `GRAY` और `LIGHT_GRAY` धूसर रंग का उपयोग करते हैं, `BLACK_WHITE` केवल काला और सफ़ेद उपयोग करता है, `BLACK` और `WHITE` एकल रंग को बाध्य करते हैं, `COLOR` सामान्य रंग को संरक्षित रखता है, और `HIDDEN` काली‑सफ़ेद मोड में आकार को छोड़ देता है। `NOT_DEFINED` का अर्थ है कि कोई आकार‑स्तर मोड असाइन नहीं किया गया है।

निम्नलिखित Python कोड एक रंगीन आकार बनाता है और इसे काली‑सफ़ेद डिस्प्ले मोड में ग्रे दिखाने के लिए सेट करता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # रंग मोड में नारंगी भराव रखें, लेकिन काली-सफ़ेद मोड में आकार को ग्रे रंग में रेंडर करें।
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

सामान्य रंग मोड में, आयत अपना नारंगी भराव बरकरार रखता है। काली‑सफ़ेद डिस्प्ले वर्कफ़्लो में, इसका मोड `GRAY` होने के कारण यह ग्रे रंग दिखाता है। यह आपको पूर्ण‑रंग स्लाइड को संरक्षित करने की अनुमति देता है, जबकि प्रिंटिंग, प्रीव्यू या अन्य वर्कफ़्लो के लिए एक विशिष्ट काली‑सफ़ेद उपस्थिति को परिभाषित करता है जो प्रस्तुति की काली‑सफ़ेद डिस्प्ले सेटिंग्स का सम्मान करता है।

## **फ़ॉर्मेट रीसेट करें**

निम्नलिखित Python कोड दर्शाता है कि कैसे स्लाइड का फ़ॉर्मेट रीसेट किया जाए और [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) पर प्लेसहोल्डर वाले सभी आकारों की स्थिति, आकार और फ़ॉर्मेट को उनके डिफ़ॉल्ट सेटिंग्स पर पुनर्स्थापित किया जाए:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # लेआउट में प्लेसहोल्डर वाला प्रत्येक आकार स्लाइड पर रीसेट करें।
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या आकार स्वरूपण अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करता है?**

केवल न्यूनतम रूप से। एम्बेडेड छवियों और मीडिया फ़ाइलों में अधिकांश स्थान होता है, जबकि आकार पैरामीटर जैसे रंग, प्रभाव और ग्रेडिएंट मेटाडेटा के रूप में संग्रहीत होते हैं और वास्तव में कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे पता लगा सकता हूँ कि स्लाइड पर कौन से आकार समान स्वरूपण साझा करते हैं ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक आकार की प्रमुख स्वरूपण प्रॉपर्टीज़—फ़िल, रेखा, और प्रभाव सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके शैलियों को समान मानें और उन रूपों को तार्किक रूप से समूहित करें, जिससे बाद में शैली प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम आकार शैलियों का एक सेट अलग फ़ाइल में सहेज सकता हूँ ताकि इसे अन्य प्रस्तुतियों में पुनः उपयोग किया जा सके?**

हां। वांछित शैलियों वाले नमूना आकारों को एक टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में सहेजें। नया प्रस्तुति बनाते समय, टेम्पलेट खोलें, आवश्यक स्टाइल्ड आकारों को क्लोन करें, और जहाँ भी आवश्यक हो उनका फ़ॉर्मेट पुनः लागू करें।