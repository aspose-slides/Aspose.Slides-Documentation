---
title: Python में PowerPoint आकार फ़ॉर्मेट करें
linktitle: आकार फ़ॉर्मेटिंग
type: docs
weight: 20
url: /hi/python-net/shape-formatting/
keywords:
- आकार फ़ॉर्मेट
- रेखा फ़ॉर्मेट
- स्केच प्रभाव
- स्केच आकार रेखा
- जॉइन शैली फ़ॉर्मेट
- ग्रेडिएंट फ़िल
- पैटर्न फ़िल
- चित्र फ़िल
- टेक्सचर फ़िल
- सॉलिड रंग फ़िल
- आकार पारदर्शिता
- काली-और-सफ़ेद आकार रेंडरिंग
- ग्रेस्केल आकार रेंडरिंग
- आकार घुमाएँ
- 3D बीवेल प्रभाव
- 3D रोटेशन प्रभाव
- फ़ॉर्मेट रीसेट करें
- PowerPoint
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Python में PowerPoint आकारों को फ़ॉर्मेट करना सीखें—PPT, PPTX और ODP फ़ाइलों के लिए भराव, रेखा और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में आप स्लाइड्स में आकार (shapes) जोड़ सकते हैं। चूंकि आकार रेखाओं से बने होते हैं, आप उनके आउटलाइन में बदलाव या प्रभाव लागू करके उन्हें स्वरूपित कर सकते हैं। अतिरिक्त रूप से, आप उनके अंदरुनी भाग को भरने वाले सेटिंग्स को निर्दिष्ट करके आकार को स्वरूपित कर सकते हैं।

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python ऐसे क्लास और प्रॉपर्टी प्रदान करता है जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके आकारों को स्वरूपित करने की अनुमति देते हैं।

## **रेखा स्वरूपण**

Aspose.Slides का उपयोग करके आप किसी आकार के लिए एक कस्टम लाइन स्टाइल निर्दिष्ट कर सकते हैं। नीचे दिए गए चरण इस प्रक्रिया की रूपरेखा प्रस्तुत करते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनायें।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार की [रेखा शैली](https://reference.aspose.com/slides/hi/python-net/aspose.slides/linestyle/) सेट करें।
1. रेखा की चौड़ाई सेट करें।
1. आकार की [डैश शैली](https://reference.aspose.com/slides/hi/python-net/aspose.slides/linedashstyle/) सेट करें।
1. आकार के लिए रेखा का रंग सेट करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python कोड दिखाता है कि कैसे एक आयत `AutoShape` की रेखा स्वरूपित की जाती है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

    # प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
    with slides.Presentation() as presentation:

        # पहली स्लाइड प्राप्त करें।
        slide = presentation.slides[0]

        # Rectangle प्रकार का ऑटो शैप जोड़ें।
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

        # आयत आकार से फ़िल हटाएँ ताकि केवल इसकी रेखाएँ दिखें।
        shape.fill_format.fill_type = slides.FillType.NO_FILL

        # आयत की रेखाओं पर फ़ॉर्मेटिंग लागू करें।
        shape.line_format.style = slides.LineStyle.THICK_THIN
        shape.line_format.width = 7
        shape.line_format.dash_style = slides.LineDashStyle.DASH

        # आयत की रेखा का रंग सेट करें।
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

        # PPTX फ़ाइल को डिस्क पर सहेजें।
        presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![प्रेज़ेंटेशन में स्वरूपित रेखाएँ](formatted-lines.png)

## **आकार रेखाओं पर स्केच प्रभाव लागू करें**

एक स्केच प्रभाव आकार की रेखा को हाथ से खींची हुई जैसा बनाता है। `Shape.line_format` का उपयोग करके रेखा सेटिंग्स तक पहुंचें, `LineFormat.sketch_format` का उपयोग करके स्केच सेटिंग्स तक पहुंचें, और `SketchFormat.sketch_type` का उपयोग करके `LineSketchType` एनेमरेशन से मान चुनें।

निम्न Python कोड दिखाता है कि कैसे `[LineSketchType.CURVED](https://reference.aspose.com/slides/hi/python-net/aspose.slides/linesketchtype/)` प्रभाव लागू किया जाता है, स्पष्ट रूप से असाइंड किया गया मान पढ़ा जाता है, और `[LineSketchType.NONE](https://reference.aspose.com/slides/hi/python-net/aspose.slides/linesketchtype/)` के साथ प्रभाव हटाया जाता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # आकार की रेखा फ़ॉर्मेट और उसकी स्केच फ़ॉर्मेट तक पहुँचें।
    sketch_format = shape.line_format.sketch_format

    # स्केच प्रभाव लागू करें।
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # आकार को सीधे असाइन किए गए स्केच प्रभाव को पढ़ें।
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # स्केच प्रभाव हटाएँ।
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

`SketchFormat.sketch_type` द्वारा लौटाया गया मान सीधे आकार पर असाइंड किए गए सेटिंग को दर्शाता है। यदि लाइन फ़ॉर्मेटिंग थीम, मास्टर स्लाइड, या लेआउट स्लाइड से विरासत में मिल सकती है, तो `[LineFormat.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/lineformat/get_effective/)` का उपयोग करें, प्राप्त ऑब्जेक्ट की `sketch_format` प्रॉपर्टी तक पहुंचें, और उसकी `sketch_type` प्रॉपर्टी पढ़ें। प्रभावी मान उन विरासतों को हल करने के बाद वास्तव में लागू किए गए फ़ॉर्मेटिंग को दर्शाता है:

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

## **जॉइन शैली स्वरूपित करें**

तीन जॉइन प्रकार विकल्प हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोण पर जोड़ता है (जैसे आकार के कोने पर), यह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोण वाले आकार बना रहे हैं, तो आप **Miter** विकल्प को पसंद कर सकते हैं।

![प्रेज़ेंटेशन में जॉइन शैली](join-style-powerpoint.png)

निम्न Python कोड दिखाता है कि कैसे ऊपर की छवि में दिखाए गए तीन आयतें Miter, Bevel, और Round जॉइन प्रकार सेटिंग्स का उपयोग करके बनाई गईं:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# एक प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation() as presentation:

	# पहली स्लाइड प्राप्त करें।
	slide = presentation.slides[0]

	# Rectangle प्रकार के तीन ऑटो शैप जोड़ें।
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# प्रत्येक आयत आकार के फ़िल रंग को सेट करें।
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

	# प्रत्येक आयत की रेखा का रंग सेट करें।
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# जॉइन शैली सेट करें।
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# प्रत्येक आयत में टेक्स्ट जोड़ें।
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# PPTX फ़ाइल को डिस्क पर सहेजें।
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **ग्रेडिएंट फ़िल**

PowerPoint में ग्रेडिएंट फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार पर निरंतर रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंग ऐसे लागू कर सकते हैं कि एक धीरे-धीरे दूसरे में मिल जाए।

Aspose.Slides का उपयोग करके आकार पर ग्रेडिएंट फ़िल लागू करने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनायें।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `GRADIENT` पर सेट करें।
1. `gradient_stops` संग्रह पर `add` मेथड्स का उपयोग करके दो पसंदीदा रंगों को परिभाषित स्थितियों के साथ जोड़ें, जो [GradientFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/gradientformat/) क्लास द्वारा एक्सपोज़ किए गए हैं।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न Python कोड दिखाता है कि कैसे एक अण्डाकार पर ग्रेडिएंट फ़िल प्रभाव लागू किया जाता है:

```python
import aspose.slides as slides

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Ellipse प्रकार का एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # अण्डाकार पर ग्रेडिएंट फ़ॉर्मेटिंग लागू करें।
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

परिणाम:

![ग्रेडिएंट फ़िल वाला अण्डाकार](gradient-fill.png)

## **पैटर्न फ़िल**

PowerPoint में पैटर्न फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको दो-रंगीन डिज़ाइन—जैसे बिंदु, धारी, क्रॉसहैच, या चेक—आकार पर लागू करने देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियाँ प्रदान करता है जिन्हें आप आकारों पर लागू करके अपनी प्रेज़ेंटेशन की दृश्य अपील बढ़ा सकते हैं। एक पूर्वनिर्धारित पैटर्न चुनने के बाद भी आप उसके उपयोग होने वाले सटीक रंग निर्दिष्ट कर सकते हैं।

पैटर्न फ़िल लागू करने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनायें।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `PATTERN` पर सेट करें।
1. पूर्वनिर्धारित विकल्पों में से एक पैटर्न शैली चुनें।
1. पैटर्न के `back_color` को सेट करें।
1. पैटर्न के `fore_color` को सेट करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न Python कोड दिखाता है कि कैसे एक आयत पर पैटर्न फ़िल लागू किया जाता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # फ़िल टाइप को Pattern पर सेट करें।
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # पैटर्न शैली सेट करें।
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # पैटर्न पृष्ठभूमि और अग्रभूमि रंग सेट करें।
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैटर्न फ़िल वाला आयत](pattern-fill.png)

## **पिक्चर फ़िल**

PowerPoint में पिक्चर फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार के भीतर एक छवि डालने की अनुमति देता है—वास्तव में छवि को आकार की पृष्ठभूमि के रूप में उपयोग करता है।

Aspose.Slides का उपयोग करके पिक्चर फ़िल लागू करने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनायें।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `PICTURE` पर सेट करें।
1. पिक्चर फ़िल मोड को `TILE` (या कोई अन्य पसंदीदा मोड) पर सेट करें।
1. उपयोग करने वाली छवि से एक [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) ऑब्जेक्ट बनायें।
1. इस छवि को आकार के `picture_fill_format` की `picture.image` प्रॉपर्टी में असाइन करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

मान लीजिए हमारे पास "lotus.png" फ़ाइल है जिसमें नीचे दिया गया चित्र है:

![कमल चित्र](lotus.png)

निम्न Python कोड दिखाता है कि कैसे आकार को चित्र से भरते हैं:

```python
import aspose.slides as slides

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # फ़िल टाइप को Picture पर सेट करें।
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # चित्र फ़िल मोड सेट करें।
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # एक छवि लोड करें और उसे प्रेज़ेंटेशन संसाधनों में जोड़ें।
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # चित्र सेट करें।
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पिक्चर फ़िल वाला आकार](picture-fill.png)

### **टाइल चित्र को टेक्सचर के रूप में सेट करें**

यदि आप टाइल की गई छवि को टेक्सचर के रूप में सेट करना और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [PictureFillFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/) क्लास की निम्न प्रॉपर्टी का उपयोग कर सकते हैं:

- [picture_fill_mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/picture_fill_mode/): चित्र फ़िल मोड सेट करता है—`TILE` या `STRETCH`।
- [tile_alignment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_alignment/): आकार के भीतर टाइलों की संरेखण निर्दिष्ट करता है।
- [tile_flip](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_flip/): नियंत्रित करता है कि टाइल को क्षैतिज, लंबवत या दोनों दिशा में फ्लिप किया जाए।
- [tile_offset_x](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_offset_x/): आकार के मूल बिंदु से टाइल के क्षैतिज ऑफसेट (पॉइंट में) सेट करता है।
- [tile_offset_y](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_offset_y/): आकार के मूल बिंदु से टाइल के लंबवत ऑफसेट (पॉइंट में) सेट करता है।
- [tile_scale_x](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_scale_x/): टाइल के क्षैतिज स्केल को प्रतिशत में परिभाषित करता है।
- [tile_scale_y](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_scale_y/): टाइल के लंबवत स्केल को प्रतिशत में परिभाषित करता है।

निम्न कोड उदाहरण दर्शाता है कि कैसे एक आयत आकार को टाइल्ड पिक्चर फ़िल के साथ जोड़ा जाता है और टाइल विकल्प कॉन्फ़िगर किए जाते हैं:

```py
import aspose.slides as slides

# एक प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    first_slide = presentation.slides[0]

    # एक आयत ऑटो शैप जोड़ें।
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # आकार के फ़िल टाइप को Picture पर सेट करें।
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # छवि लोड करें और उसे प्रेज़ेंटेशन संसाधनों में जोड़ें।
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # छवि को आकार को असाइन करें।
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # चित्र फ़िल मोड और टाइलिंग प्रॉपर्टी को कॉन्फ़िगर करें।
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

परिणाम:

![टाइल विकल्प](tile-options.png)

## **सॉलिड कलर फ़िल**

PowerPoint में सॉलिड कलर फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आकार को एक समान, एकरंगीन रंग से भरता है। यह साधारण पृष्ठभूमि रंग कोई ग्रेडिएंट, टेक्सचर या पैटर्न के बिना लागू किया जाता है।

Aspose.Slides का उपयोग करके आकार पर सॉलिड कलर फ़िल लागू करने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनायें।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `SOLID` पर सेट करें।
1. आकार को अपनी पसंद का फ़िल रंग असाइन करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न Python कोड दिखाता है कि कैसे PowerPoint स्लाइड में एक आयत पर सॉलिड कलर फ़िल लागू किया जाता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # फ़िल टाइप को Solid पर सेट करें।
    shape.fill_format.fill_type = slides.FillType.SOLID

    # फ़िल रंग सेट करें।
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![सॉलिड कलर फ़िल वाला आकार](solid-color-fill.png)

## **पारदर्शिता सेट करें**

PowerPoint में, जब आप आकार पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता को नियंत्रित करने के लिए एक पारदर्शिता स्तर भी सेट कर सकते हैं। उच्च पारदर्शिता मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे के वस्तु आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फ़िल के लिए उपयोग किए गए रंग में अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने की अनुमति देता है। इस प्रकार करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनायें।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. फ़िल टाइप को `SOLID` पर सेट करें।
1. `Color.from_argb` का उपयोग करके एक पारदर्शी रंग परिभाषित करें (अल्फा घटक पारदर्शिता को नियंत्रित करता है)।
1. प्रेज़ेंटेशन को सहेजें।

निम्न Python कोड दिखाता है कि कैसे एक आयत पर पारदर्शी फ़िल रंग लागू किया जाता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]
    
    # एक ठोस आयत ऑटो शैप जोड़ें।
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # ठोस आकार के ऊपर एक पारदर्शी आयत ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पारदर्शी आकार](shape-transparency.png)

## **आकार घुमाएँ**

Aspose.Slides आपको PowerPoint प्रेज़ेंटेशन में आकारों को घूमाने की सुविधा देता है। यह विशेष संरेखण या डिजाइन आवश्यकताओं के साथ दृश्य तत्वों को स्थित करने में उपयोगी हो सकता है।

स्लाइड पर किसी आकार को घुमाने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनायें।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार के `rotation` प्रॉपर्टी को इच्छित कोण पर सेट करें।
1. प्रेज़ेंटेशन को सहेजें।

निम्न Python कोड दिखाता है कि कैसे आकार को 5 डिग्री से घुमाया जाता है:

```python
import aspose.slides as slides

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
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

परिणाम:

![आकार घुमाव](shape-rotation.png)

## **3D बीवेल इफ़ेक्ट्स जोड़ें**

Aspose.Slides आपको आकारों पर 3D बीवेल इफ़ेक्ट्स लागू करने की अनुमति देता है, इसके लिए आप उनके `[ThreeDFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/)` प्रॉपर्टी को कॉन्फ़िगर करते हैं।

आकार पर 3D बीवेल इफ़ेक्ट्स जोड़ने के चरण:

1. एक `[Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/)` क्लास को इंस्टैंसिएट करें।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक `[AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/)` जोड़ें।
1. आकार की `[ThreeDFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/)` को बीवेल सेटिंग्स निर्धारित करने के लिए कॉन्फ़िगर करें।
1. प्रेज़ेंटेशन को सहेजें।

निम्न Python कोड दिखाता है कि कैसे आकार पर 3D बीवेल इफ़ेक्ट्स लागू किए जाते हैं:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation क्लास का एक इंस्टेंस बनाएँ।
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # स्लाइड में एक आकार जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # आकार की ThreeDFormat प्रॉपर्टीज़ सेट करें।
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![3D बीवेल प्रभाव](3D-bevel-effect.png)

## **3D रोटेशन इफ़ेक्ट्स जोड़ें**

Aspose.Slides आपको आकारों पर 3D रोटेशन इफ़ेक्ट्स लागू करने की अनुमति देता है, इसके लिए आप उनके `[ThreeDFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/)` प्रॉपर्टी को कॉन्फ़िगर करते हैं।

आकार पर 3D रोटेशन लागू करने के चरण:

1. एक `[Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/)` क्लास का उदाहरण बनायें।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक `[AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/)` जोड़ें।
1. आकार के `[camera_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/camera/camera_type/)` और `[light_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/lightrig/light_type/)` को सेट करके 3D रोटेशन परिभाषित करें।
1. प्रेज़ेंटेशन को सहेजें।

निम्न Python कोड दिखाता है कि कैसे आकार पर 3D रोटेशन इफ़ेक्ट्स लागू किए जाते हैं:

```python
import aspose.slides as slides

# Presentation क्लास का एक इंस्टेंस बनाएँ।
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![3D रोटेशन प्रभाव](3D-rotation-effect.png)

## **आकारों के लिए काले-और-सफ़ेद रेंडरिंग नियंत्रित करें**

`[Shape.black_white_mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/black_white_mode/)` प्रॉपर्टी यह निर्दिष्ट करती है कि जब कोई प्रेज़ेंटेशन काले-और-सफ़ेद मोड में देखा या प्रोसेस किया जाता है, तो व्यक्तिगत आकार कैसे रेंडर किया जाता है। यह स्वयं काले-और-सफ़ेद डिस्प्ले को सक्षम नहीं करता, और यह सामान्य रंग मोड में आकार के फ़िल, रेखा या अन्य फ़ॉर्मेटिंग को नहीं बदलता।

इच्छित व्यवहार चुनने के लिए `[BlackWhiteMode](https://reference.aspose.com/slides/hi/python-net/aspose.slides/blackwhitemode/)` एनेमरेशन से एक मान उपयोग करें। उदाहरण के लिए, `AUTOMATIC` रेंडरिंग एप्लिकेशन को परिवर्तन चुनने देता है, `GRAY` और `LIGHT_GRAY` धूसर रंग उपयोग करते हैं, `BLACK_WHITE` केवल काला‑सफ़ेद उपयोग करता है, `BLACK` और `WHITE` एकल रंग को मजबूर करते हैं, `COLOR` सामान्य रंग को बनाए रखता है, और `HIDDEN` काले‑और‑सफ़ेद मोड में आकार को हटाता है। `NOT_DEFINED` का अर्थ है कि कोई आकार‑स्तर मोड असाइन नहीं किया गया है।

निम्न Python कोड एक रंगीन आकार बनाता है और उसे काले‑और‑सफ़ेद डिस्प्ले मोड में ग्रे दिखाता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # रंग मोड में नारंगी भराव रखें, लेकिन काले-और-सफ़ेद मोड में आकार को ग्रे रंग में रेंडर करें।
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

सामान्य रंग मोड में, आयत अपने नारंगी फ़िल को बनाए रखता है। काले‑और‑सफ़ेद डिस्प्ले वर्कफ़्लो में, इसका मोड `GRAY` पर सेट होने के कारण ग्रे रंग उपयोग करता है। यह आपको पूरे‑रंग स्लाइड को संरक्षित रखने की अनुमति देता है, जबकि प्रिंटिंग, प्रीव्यू या अन्य वर्कफ़्लो के लिए अलग प्रस्तुति प्रदान करता है जो प्रेज़ेंटेशन की काले‑और‑सफ़ेद डिस्प्ले सेटिंग को सम्मानित करते हैं।

## **फ़ॉर्मेट रीसेट करें**

निम्न Python कोड दिखाता है कि कैसे स्लाइड की फ़ॉर्मेटिंग को रीसेट किया जाता है और `[LayoutSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/)` पर सभी प्लेसहोल्डरों के साथ सभी आकारों की स्थिति, आकार और फ़ॉर्मेटिंग को उनके डिफ़ॉल्ट सेटिंग्स पर लाया जाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # लेआउट पर प्लेसहोल्डर वाले प्रत्येक आकार को स्लाइड पर रीसेट करें।
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या आकार का फ़ॉर्मेटिंग अंतिम प्रेज़ेंटेशन फ़ाइल आकार को प्रभावित करता है?**

केवल न्यूनतम रूप से। एम्बेडेड छवियां और मीडिया फ़ाइलें अधिकांश फ़ाइल स्थान लेती हैं, जबकि रंग, इफ़ेक्ट और ग्रेडिएंट जैसी आकार पैरामीटर मेटा‑डेटा के रूप में संग्रहीत होते हैं और व्यावहारिक रूप से कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे पता लगा सकता हूँ कि स्लाइड पर कौन‑से आकार समान फ़ॉर्मेटिंग साझा करते हैं ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक आकार के प्रमुख फ़ॉर्मेटिंग प्रॉपर्टी—फ़िल, रेखा और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके स्टाइल को समान मानें और उन आकारों को तार्किक रूप से समूहित करें, जिससे बाद में स्टाइल प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम आकार शैलियों का एक सेट अलग फ़ाइल में सहेज कर अन्य प्रेज़ेंटेशन में पुन: उपयोग कर सकता हूँ?**

हां। इच्छित शैलियों वाले नमूना आकारों को एक टेम्प्लेट स्लाइड डेक या .POTX टेम्प्लेट फ़ाइल में स्टोर करें। नई प्रेज़ेंटेशन बनाते समय टेम्प्लेट खोलें, आवश्यक शैली वाले आकारों को क्लोन करें, और जहाँ‑जहाँ आवश्यकता हो फ़ॉर्मेटिंग पुनः लागू करें।