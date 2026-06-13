---
title: Python में PowerPoint शैप्स को फ़ॉर्मेट करें
linktitle: शैप फ़ॉर्मेटिंग
type: docs
weight: 20
url: /hi/python-net/shape-formatting/
keywords:
- शैप फ़ॉर्मेट
- लाइन फ़ॉर्मेट
- जॉइन स्टाइल फ़ॉर्मेट
- ग्रेडिएंट फ़िल
- पैटर्न फ़िल
- पिक्चर फ़िल
- टेक्सचर फ़िल
- सॉलिड कलर फ़िल
- शैप ट्रांसपैरेंसी
- शैप घुमाएँ
- 3D बेवेल इफ़ेक्ट
- 3D रोटेशन इफ़ेक्ट
- फ़ॉर्मेट रीसेट
- PowerPoint
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Python में PowerPoint शैप्स को फ़ॉर्मेट करना सीखें—PPT, PPTX और ODP फ़ाइलों के लिए फ़िल, लाइन और इफ़ेक्ट शैलियाँ सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में शैप्स जोड़ सकते हैं। चूंकि शैप्स लाइनों से बने होते हैं, आप उनकी रूपरेखा को संशोधित करके या प्रभाव लागू करके फ़ॉर्मेट कर सकते हैं। अतिरिक्त रूप से, आप शैप के अंदरूनी भाग को कैसे भरा जाए, इसे नियंत्रित करने वाले सेटिंग्स निर्दिष्ट करके शैप को फ़ॉर्मेट कर सकते हैं।

![फ़ॉर्मेट-शेप-पावरपॉइंट](format-shape-powerpoint.png)

Aspose.Slides for Python क्लासेज़ और प्रॉपर्टीज़ प्रदान करता है जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके शैप्स को फ़ॉर्मेट करने की अनुमति देता है।

## **लाइन फ़ॉर्मेट**

Aspose.Slides का उपयोग करके, आप किसी शैप के लिए कस्टम लाइन स्टाइल निर्दिष्ट कर सकते हैं। निम्न चरण प्रक्रिया को दर्शाते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप की [line style](https://reference.aspose.com/slides/hi/python-net/aspose.slides/linestyle/) सेट करें।
1. लाइन की चौड़ाई सेट करें।
1. शैप की [dash style](https://reference.aspose.com/slides/hi/python-net/aspose.slides/linedashstyle/) सेट करें।
1. शैप के लिए लाइन का रंग सेट करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न Python कोड दिखाता है कि कैसे एक आयत `AutoShape` को फ़ॉर्मेट किया जाता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # आयत शैप के लिए फ़िल रंग सेट करें।
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # आयत की लाइनों पर फ़ॉर्मेटिंग लागू करें।
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # आयत की लाइन के लिए रंग सेट करें।
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![प्रेज़ेंटेशन में फ़ॉर्मेटेड लाइन्स](formatted-lines.png)

## **जॉइन स्टाइल फ़ॉर्मेट**

तीन जॉइन प्रकार विकल्प हैं:

* राउंड
* मिटर
* बीवेल

डिफ़ॉल्ट रूप से, जब PowerPoint दो लाइनों को एक कोण पर (जैसे शैप के कोने पर) जोड़ता है, तो यह **राउंड** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोणों वाला शैप बना रहे हैं, तो आप **मिटर** विकल्प को प्राथमिकता दे सकते हैं।

![प्रेज़ेंटेशन में जॉइन स्टाइल](join-style-powerpoint.png)

निम्न Python कोड दिखाता है कि कैसे ऊपर की चित्र में दिखाए गए तीन आयतों को मिटर, बीवेल, और राउंड जॉइन टाइप सेटिंग्स के साथ बनाया गया:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को बनाएं।
with slides.Presentation() as presentation:

	# पहली स्लाइड प्राप्त करें।
	slide = presentation.slides[0]

	# Rectangle प्रकार के तीन ऑटो शैप्स जोड़ें।
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# प्रत्येक आयत शैप के लिए फ़िल रंग सेट करें।
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# लाइन की चौड़ाई सेट करें।
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# प्रत्येक आयत की लाइन के लिए रंग सेट करें।
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# जॉइन स्टाइल सेट करें।
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

PowerPoint में, ग्रेडिएंट फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको शैप पर लगातार रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंग इस तरह लागू कर सकते हैं कि एक धीरे‑धीरे दूसरे में घुल जाए।

Aspose.Slides का उपयोग करके शैप पर ग्रेडिएंट फ़िल लागू करने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप की [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `GRADIENT` सेट करें।
1. `gradient_stops` कलेक्शन (जो [GradientFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/gradientformat/) क्लास द्वारा एक्सपोज़ किया गया है) की `add` मेथड्स का उपयोग करके दो पसंदीदा रंगों को परिभाषित स्थितियों के साथ जोड़ें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न Python कोड दिखाता है कि कैसे एक एलीप्स पर ग्रेडिएंट फ़िल इफ़ेक्ट लागू किया जाता है:

```python
import aspose.slides as slides

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Ellipse प्रकार का एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # एलीप्स पर ग्रेडिएंट फ़ॉर्मेटिंग लागू करें।
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

![ग्रेडिएंट फ़िल वाला एलीप्स](gradient-fill.png)

## **पैटर्न फ़िल**

PowerPoint में, पैटर्न फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको दो‑रंग डिज़ाइन—जैसे डॉट्स, स्ट्राइप्स, क्रॉसहैचेज़ या चेक्स—को शैप पर लागू करने देता है। आप पैटर्न की अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक प्री‑डिफ़ाइंड पैटर्न स्टाइल्स प्रदान करता है जिन्हें आप शैप्स पर लागू करके अपनी प्रेज़ेंटेशन की दृश्य आकर्षकता बढ़ा सकते हैं। प्री‑डिफ़ाइंड पैटर्न चुनने के बाद भी आप उपयोग किए जाने वाले सटीक रंग निर्दिष्ट कर सकते हैं।

Aspose.Slides का उपयोग करके शैप पर पैटर्न फ़िल लागू करने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप की [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `PATTERN` सेट करें।
1. प्री‑डिफ़ाइंड विकल्पों में से एक पैटर्न स्टाइल चुनें।
1. पैटर्न के [back_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/patternformat/back_color/) को सेट करें।
1. पैटर्न के [fore_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/patternformat/fore_color/) को सेट करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न Python कोड दिखाता है कि कैसे एक आयत पर पैटर्न फ़िल लागू किया जाता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को बनाएं।
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

PowerPoint में, पिक्चर फ़िल एक फ़ॉर्मेटिंग विकल्प है जो आपको शैप के अंदर चित्र सम्मिलित करने की अनुमति देता है—व्यावहारिक रूप से चित्र को शैप की पृष्ठभूमि के रूप में उपयोग करके।

Aspose.Slides का उपयोग करके शैप पर पिक्चर फ़िल लागू करने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप की [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `PICTURE` सेट करें।
1. पिक्चर फ़िल मोड को `TILE` (या कोई अन्य पसंदीदा मोड) सेट करें।
1. उपयोग करने वाले चित्र से एक [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) ऑब्जेक्ट बनाएँ।
1. इस चित्र को शैप के `picture_fill_format` की `picture.image` प्रॉपर्टी में असाइन करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

मान लीजिए हमारे पास "lotus.png" फ़ाइल है जिसमें नीचे का चित्र है:

![लोटस चित्र](lotus.png)

निम्न Python कोड दिखाता है कि कैसे शैप को चित्र फ़िल से भरा जाता है:

```python
import aspose.slides as slides

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # फ़िल टाइप को Picture पर सेट करें।
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # पिक्चर फ़िल मोड सेट करें।
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

![पिक्चर फ़िल वाला शैप](picture-fill.png)

### **टाइल पिक्चर को टेक्सचर के रूप में उपयोग करें**

यदि आप टाइल्ड पिक्चर को टेक्सचर के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप निम्न [PictureFillFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/) क्लास की प्रॉपर्टीज़ का उपयोग कर सकते हैं:

- [picture_fill_mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/picture_fill_mode/): पिक्चर फ़िल मोड सेट करता है—`TILE` या `STRETCH`।
- [tile_alignment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_alignment/): शैप के भीतर टाइल्स की अलाइनमेंट निर्दिष्ट करता है।
- [tile_flip](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_flip/): टाइल को क्षैतिज, लंबवत या दोनों दिशा में फ़्लिप करने को नियंत्रित करता है।
- [tile_offset_x](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_offset_x/): शैप के मूल बिंदु से टाइल के क्षैतिज ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [tile_offset_y](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_offset_y/): शैप के मूल बिंदु से टाइल के लंबवत ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [tile_scale_x](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_scale_x/): टाइल के क्षैतिज स्केल को प्रतिशत में परिभाषित करता है।
- [tile_scale_y](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_scale_y/): टाइल के लंबवत स्केल को प्रतिशत में परिभाषित करता है।

निम्न कोड सैंपल दिखाता है कि कैसे एक आयत शैप को टाइल्ड पिक्चर फ़िल के साथ जोड़ा जाए और टाइल विकल्पों को कॉन्फ़िगर किया जाए:

```py
import aspose.slides as slides

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    first_slide = presentation.slides[0]

    # एक आयत ऑटो शैप जोड़ें।
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # शैप का फ़िल टाइप Picture पर सेट करें।
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # छवि लोड करें और उसे प्रेज़ेंटेशन संसाधनों में जोड़ें।
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # छवि को शैप को असाइन करें।
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # पिक्चर फ़िल मोड और टाइलिंग प्रॉपर्टीज़ कॉन्फ़िगर करें।
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

PowerPoint में, सॉलिड कलर फ़िल एक फ़ॉर्मेटिंग विकल्प है जो शैप को एकसमान रंग से भरता है। यह स्पष्ट पृष्ठभूमि रंग कोई ग्रेडिएंट, टेक्सचर या पैटर्न के बिना लागू किया जाता है।

Aspose.Slides का उपयोग करके शैप पर सॉलिड कलर फ़िल लागू करने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप की [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `SOLID` सेट करें।
1. शैप को अपनी पसंद का फ़िल रंग असाइन करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न Python कोड दिखाता है कि कैसे PowerPoint स्लाइड में एक आयत पर सॉलिड कलर फ़िल लागू किया जाता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को बनाएं।
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

![सॉलिड कलर फ़िल वाला शैप](solid-color-fill.png)

## **ट्रांसपैरेंसी सेट करें**

PowerPoint में, जब आप शैप्स पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता को नियंत्रित करने के लिए ट्रांसपैरेंसी लेवल भी सेट कर सकते हैं। उच्च ट्रांसपैरेंसी मान शैप को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे के ऑब्जेक्ट्स कुछ हद तक दिखाई देते हैं।

Aspose.Slides आपको फ़िल में उपयोग किए गए रंग के अल्फा मान को समायोजित करके ट्रांसपैरेंसी लेवल सेट करने देता है। यह करने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. फ़िल टाइप को `SOLID` सेट करें।
1. `Color.from_argb` का उपयोग करके ट्रांसपैरेंट रंग परिभाषित करें (अल्फा घटक ट्रांसपैरेंसी को नियंत्रित करता है)।
1. प्रेज़ेंटेशन को सहेजें।

निम्न Python कोड दिखाता है कि कैसे एक आयत पर ट्रांसपैरेंट फ़िल कलर लागू किया जाता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]
    
    # एक ठोस आयत ऑटो शैप जोड़ें।
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # ठोस शैप के ऊपर एक पारदर्शी आयत ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![ट्रांसपैरेंट शैप](shape-transparency.png)

## **शैप्स को घुमाएँ**

Aspose.Slides PowerPoint प्रेज़ेंटेशन में शैप्स को घुमाने की सुविधा देता है। यह विशिष्ट एलाइनमेंट या डिज़ाइन आवश्यकताओं के साथ विज़ुअल एलिमेंट्स की पोज़िशनिंग में उपयोगी हो सकता है।

स्लाइड पर शैप को घुमाने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप की `rotation` प्रॉपर्टी को वांछित कोण पर सेट करें।
1. प्रेज़ेंटेशन को सहेजें।

निम्न Python कोड दिखाता है कि कैसे शैप को 5 डिग्री से घुमाया जाता है:

```python
import aspose.slides as slides

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को बनाएं।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # शैप को 5 डिग्री घुमाएँ।
    shape.rotation = 5

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![शैप घुमाव](shape-rotation.png)

## **3D बेवेल इफ़ेक्ट्स जोड़ें**

Aspose.Slides आपको शैप्स पर 3D बेवेल इफ़ेक्ट्स लागू करने की सुविधा देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करते हैं।

शैप में 3D बेवेल इफ़ेक्ट्स जोड़ने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास इंस्टैंशिएट करें।
1. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप के [ThreeDFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/) को बेवेल सेटिंग्स निर्धारित करने के लिए कॉन्फ़िगर करें।
1. प्रेज़ेंटेशन को सहेजें।

निम्न Python कोड दिखाता है कि कैसे शैप पर 3D बेवेल इफ़ेक्ट लागू किया जाता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation क्लास का एक इंस्टेंस बनाएं।
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # स्लाइड में एक शैप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # शैप के ThreeDFormat प्रॉपर्टीज़ सेट करें।
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

![3D बेवेल इफ़ेक्ट](3D-bevel-effect.png)

## **3D रोटेशन इफ़ेक्ट्स जोड़ें**

Aspose.Slides आपको शैप्स पर 3D रोटेशन इफ़ेक्ट्स लागू करने की सुविधा देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करते हैं।

शैप पर 3D रोटेशन लागू करने के चरण:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. शैप के [camera_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/camera/camera_type/) और [light_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/lightrig/light_type/) को सेट करके 3D रोटेशन परिभाषित करें।
1. प्रेज़ेंटेशन को सहेजें।

निम्न Python कोड दिखाता है कि कैसे शैप पर 3D रोटेशन इफ़ेक्ट लागू किया जाता है:

```python
import aspose.slides as slides

# Presentation क्लास का एक इंस्टेंस बनाएं।
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

![3D रोटेशन इफ़ेक्ट](3D-rotation-effect.png)

## **फ़ॉर्मेट रीसेट करें**

निम्न Python कोड दिखाता है कि कैसे स्लाइड का फ़ॉर्मेट रीसेट किया जाए और सभी शैप्स के साथ प्लेसहोल्डर्स वाली [LayoutSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/) की स्थिति, आकार और फ़ॉर्मेट को उनके डिफ़ॉल्ट सेटिंग्स पर वापस लाया जाए:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # स्लाइड पर प्रत्येक शैप को रीसेट करें जो लेआउट में प्लेसहोल्डर रखता है।
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या शैप फ़ॉर्मेटिंग अंतिम प्रेज़ेंटेशन फ़ाइल के आकार को प्रभावित करती है?**

बहुत कम। एम्बेडेड इमेजेज़ और मीडिया फ़ाइलें फ़ाइल के अधिकांश स्थान को घेरती हैं, जबकि शैप पैरामीटर जैसे रंग, इफ़ेक्ट और ग्रेडिएंट मेटा‑डेटा के रूप में संग्रहीत होते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे उन शैप्स को पहचान सकता हूँ जो समान फ़ॉर्मेटिंग साझा करती हैं ताकि मैं उन्हें ग्रुप कर सकूँ?**

प्रत्येक शैप की प्रमुख फ़ॉर्मेटिंग प्रॉपर्टीज़—फ़िल, लाइन और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान पूरी तरह मेल खाते हैं, तो उनके स्टाइल को समान मानें और उन शैप्स को तार्किक रूप से समूहित करें, जिससे बाद में स्टाइल प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम शैप स्टाइल्स का एक सेट अलग फ़ाइल में सहेज कर अन्य प्रेज़ेंटेशंस में पुनः उपयोग कर सकता हूँ?**

हां। इच्छित स्टाइल वाले सैंपल शैप्स को एक टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में रखें। नया प्रेज़ेंटेशन बनाते समय टेम्पलेट खोलें, आवश्यक स्टाइल वाले शैप्स को क्लोन करें, और जहाँ‑जहाँ आवश्यक हो फ़ॉर्मेटिंग दोबारा लागू करें।