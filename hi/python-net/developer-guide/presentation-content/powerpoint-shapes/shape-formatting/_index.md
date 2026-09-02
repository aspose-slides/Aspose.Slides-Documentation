---
title: Python में PowerPoint आकारों को फ़ॉर्मेट करें
linktitle: आकार फ़ॉर्मेटिंग
type: docs
weight: 20
url: /hi/python-net/shape-formatting/
keywords:
- आकार फ़ॉर्मेट
- रेखा फ़ॉर्मेट
- स्केच इफ़ेक्ट
- आकार रेखा स्केच
- जॉइन स्टाइल फ़ॉर्मेट
- ग्रेडिएंट फ़िल
- पैटर्न फ़िल
- पिक्चर फ़िल
- टेक्सचर फ़िल
- सॉलिड कलर फ़िल
- आकार ट्रांसपैरेंसी
- आकार घुमाएँ
- 3D बिवेल इफ़ेक्ट
- 3D रोटेशन इफ़ेक्ट
- फ़ॉर्मेट रीसेट
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Python में PowerPoint आकारों को फ़ॉर्मेट करना सीखें—PPT, PPTX, और ODP फ़ाइलों के लिए फ़िल, रेखा और इफ़ेक्ट स्टाइल को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में आकार जोड़ सकते हैं। चूंकि आकार रेखाओं से बना होता है, आप उनके बाहरी किनारों को संशोधित करके या प्रभाव लागू करके उनका फॉर्मेट बदल सकते हैं। इसके अलावा, आप आकारों को इस तरह सेटिंग्स निर्दिष्ट करके फॉर्मेट कर सकते हैं जो यह नियंत्रित करती हैं कि उनका आंतरिक भाग कैसे भरा गया है।

![PowerPoint में आकार का फ़ॉर्मेट](format-shape-powerpoint.png)

Aspose.Slides for Python प्रदान करता है क्लासेज़ और प्रॉपर्टीज़ जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके आकारों को फॉर्मेट करने की अनुमति देती हैं।

## **रेखाओं का स्वरूप**

Aspose.Slides का उपयोग करके आप किसी आकार के लिए एक कस्टम लाइन स्टाइल निर्दिष्ट कर सकते हैं। नीचे प्रक्रिया के चरण दिए गए हैं:

1. एक नया उदाहरण बनाएं [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का।
1. इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार की [लाइन शैली](https://reference.aspose.com/slides/hi/python-net/aspose.slides/linestyle/) सेट करें।
1. लाइन की चौड़ाई सेट करें।
1. आकार की [डैश शैली](https://reference.aspose.com/slides/hi/python-net/aspose.slides/linedashstyle/) सेट करें।
1. आकार के लिए लाइन रंग सेट करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python कोड दर्शाता है कि कैसे एक आयत `AutoShape` को फ़ॉर्मेट किया जाए:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

#    प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
with slides.Presentation() as presentation:

    #    पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    #    Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    #    Rectangle आकार के लिए फ़िल कलर सेट करें।
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    #    Rectangle की रेखाओं पर फ़ॉर्मेटिंग लागू करें।
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    #    Rectangle की रेखा का रंग सेट करें।
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    #    PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![प्रेजेंटेशन में स्वरूपित रेखाएँ](formatted-lines.png)

## **आकार रेखाओं पर स्केच इफ़ेक्ट लागू करें**

एक स्केच इफ़ेक्ट आकार की रेखा को हाथ से बने जैसा दिखाता है। [Shape.line_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/line_format/) का उपयोग करके लाइन सेटिंग्स तक पहुंचें, [LineFormat.sketch_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/lineformat/sketch_format/) का उपयोग करके स्केच सेटिंग्स तक पहुंचें, और [SketchFormat.sketch_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sketchformat/sketch_type/) का उपयोग करके [LineSketchType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/linesketchtype/) एन्नुमरेशन से एक मान चुनें।

निम्नलिखित Python कोड दर्शाता है कि कैसे [LineSketchType.CURVED](https://reference.aspose.com/slides/hi/python-net/aspose.slides/linesketchtype/) इफ़ेक्ट लागू किया जाए, स्पष्ट रूप से नियत मूल्य को पढ़ा जाए, और इफ़ेक्ट को [LineSketchType.NONE](https://reference.aspose.com/slides/hi/python-net/aspose.slides/linesketchtype/) के साथ हटाया जाए:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    #    आकार के लाइन फ़ॉर्मेट और उसके स्केच फ़ॉर्मेट तक पहुंचें।
    sketch_format = shape.line_format.sketch_format

    #    स्केच इफ़ेक्ट लागू करें।
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    #    आकार को सीधे असाइन किए गए स्केच इफ़ेक्ट को पढ़ें।
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    #    स्केच इफ़ेक्ट हटाएँ।
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

`SketchFormat.sketch_type` द्वारा लौटाया गया मान वह सेटिंग दर्शाता है जो सीधे आकार को असाइन की गई है। यदि लाइन फ़ॉर्मेटिंग थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में ली जा सकती है, तो [LineFormat.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/lineformat/get_effective/) का उपयोग करके लौटाए गए ऑब्जेक्ट की `sketch_format` प्रॉपर्टी तक पहुंचें और उसकी `sketch_type` प्रॉपर्टी पढ़ें। प्रभावी मान विरासत के समाधान के बाद वास्तव में लागू फ़ॉर्मेटिंग को दर्शाता है:

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

## **जॉइन स्टाइल्स का फॉर्मेट**

तीन जॉइन टाइप विकल्प हैं:

* राउंड
* मिटर
* बिवेल

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोण पर जोड़ता है (जैसे आकार के कोने पर), यह **राउंड** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीखे कोण वाले आकार बना रहे हैं, तो आप **मिटर** विकल्प को प्राथमिकता दे सकते हैं।

![प्रेजेंटेशन में जॉइन स्टाइल](join-style-powerpoint.png)

निम्नलिखित Python कोड दर्शाता है कि कैसे ऊपर चित्र में दिखाए अनुसार तीन आयतें मिटर, बिवेल और राउंड जॉइन टाइप सेटिंग्स का उपयोग करके बनाई गईं:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
with slides.Presentation() as presentation:

	# पहली स्लाइड प्राप्त करें।
	slide = presentation.slides[0]

	# Rectangle प्रकार के तीन ऑटो शेप जोड़ें।
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# प्रत्येक आयत आकार के लिए फ़िल रंग सेट करें।
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

PowerPoint में, ग्रेडिएंट फ़िल एक फ़ॉर्मेट विकल्प है जो आपको आकार पर निरंतर रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंगों को इस तरह लागू कर सकते हैं कि एक धीरे‑धीरे दूसरे में मिल जाता है।

Aspose.Slides का उपयोग करके आकार पर ग्रेडिएंट फ़िल लागू करने के चरण:

1. एक नया उदाहरण बनाएं [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का।
1. इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `GRADIENT` सेट करें।
1. [GradientFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/gradientformat/) क्लास द्वारा प्रदर्शित `gradient_stops` कलेक्शन की `add` विधियों का उपयोग करके परिभाषित स्थितियों के साथ दो पसंदीदा रंग जोड़ें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python कोड दर्शाता है कि कैसे एक दीर्घवृत्त पर ग्रेडिएंट फ़िल इफ़ेक्ट लागू किया जाए:

```python
import aspose.slides as slides

# प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Ellipse प्रकार का एक ऑटो शेप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Ellipse पर ग्रेडिएंट फ़ॉर्मेटिंग लागू करें।
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

![ग्रेडिएंट फ़िल वाले दीर्घवृत्त](gradient-fill.png)

## **पैटर्न फ़िल**

PowerPoint में, पैटर्न फ़िल एक फ़ॉर्मेट विकल्प है जो आपको दो‑रंगीय डिज़ाइन—जैसे बिंदु, धारियां, क्रॉसहैच या चेक—को आकार पर लागू करने देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न स्टाइल प्रदान करता है जिन्हें आप आकारों पर लागू करके अपने प्रेजेंटेशन की दृश्य अपील बढ़ा सकते हैं। यहां तक कि पूर्वनिर्धारित पैटर्न चुनने के बाद भी आप उन पर बिल्कुल वही रंग निर्दिष्ट कर सकते हैं जो आप चाहते हैं।

आकार पर पैटर्न फ़िल लागू करने के चरण:

1. एक नया उदाहरण बनाएं [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का।
1. इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `PATTERN` सेट करें।
1. पूर्वनिर्धारित विकल्पों में से एक पैटर्न स्टाइल चुनें।
1. पैटर्न की [back_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/patternformat/back_color/) सेट करें।
1. पैटर्न की [fore_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/patternformat/fore_color/) सेट करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python कोड दर्शाता है कि कैसे एक आयत पर पैटर्न फ़िल लागू किया जाए:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # फ़िल प्रकार को पैटर्न सेट करें।
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # पैटर्न स्टाइल सेट करें।
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # पैटर्न का बैकग्राउंड और फ़ोरग्राउंड रंग सेट करें।
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैटर्न फ़िल वाले आयत](pattern-fill.png)

## **पिक्चर फ़िल**

PowerPoint में, पिक्चर फ़िल एक फ़ॉर्मेट विकल्प है जो आपको आकार के भीतर एक छवि डालने की अनुमति देता है—अर्थात छवि को आकार की पृष्ठभूमि के रूप में उपयोग किया जाता है।

Aspose.Slides का उपयोग करके आकार पर पिक्चर फ़िल लागू करने के चरण:

1. एक नया उदाहरण बनाएं [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का।
1. इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `PICTURE` सेट करें।
1. पिक्चर फ़िल मोड को `TILE` (या अन्य पसंदीदा मोड) सेट करें।
1. उस छवि से एक [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं जिसे आप उपयोग करना चाहते हैं।
1. इस छवि को आकार के `picture_fill_format` की `picture.image` प्रॉपर्टी को असाइन करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

मान लीजिए हमारे पास "lotus.png" फ़ाइल है जिसमें निम्नलिखित चित्र है:

![लोतेस चित्र](lotus.png)

निम्नलिखित Python कोड दर्शाता है कि कैसे आकार को चित्र से भरा जाए:

```python
import aspose.slides as slides

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # फ़िल प्रकार को Picture सेट करें।
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # पिक्चर फ़िल मोड सेट करें।
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # एक इमेज लोड करें और उसे प्रेजेंटेशन रिसोर्सेज में जोड़ें।
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # पिक्चर सेट करें।
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पिक्चर फ़िल वाला आकार](picture-fill.png)

### **टाइल चित्र को टेक्सचर के रूप में**

यदि आप टाइल्ड चित्र को टेक्सचर के रूप में सेट करना और टाइलिंग व्यवहार को कस्टमाइज़ करना चाहते हैं, तो आप निम्नलिखित [PictureFillFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/) क्लास प्रॉपर्टीज़ का उपयोग कर सकते हैं:

- [picture_fill_mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/picture_fill_mode/): पिक्चर फ़िल मोड सेट करता है—या तो `TILE` या `STRETCH`।
- [tile_alignment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_alignment/): आकार के भीतर टाइलों की संरेखण निर्दिष्ट करता है।
- [tile_flip](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_flip/): नियंत्रित करता है कि टाइल क्षैतिज, लंबवत या दोनों दिशा में फ़्लिप हो।
- [tile_offset_x](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_offset_x/): आकार की मूल बिंदु से टाइल का क्षैतिज ऑफ़सेट (पॉइंट में) सेट करता है।
- [tile_offset_y](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_offset_y/): आकार की मूल बिंदु से टाइल का लंबवत ऑफ़सेट (पॉइंट में) सेट करता है।
- [tile_scale_x](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_scale_x/): टाइल के क्षैतिज स्केल को प्रतिशत में परिभाषित करता है।
- [tile_scale_y](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/tile_scale_y/): टाइल के लंबवत स्केल को प्रतिशत में परिभाषित करता है।

निम्नलिखित कोड उदाहरण दर्शाता है कि कैसे एक आयत आकार को टाइल्ड पिक्चर फ़िल के साथ जोड़ें और टाइल विकल्प कॉन्फ़िगर करें:

```py
import aspose.slides as slides

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    first_slide = presentation.slides[0]

    # एक Rectangle ऑटो शेप जोड़ें।
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # आकार का फ़िल टाइप Picture सेट करें।
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # इमेज लोड करें और उसे प्रेजेंटेशन रिसोर्सेज में जोड़ें।
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # इमेज को आकार को असाइन करें।
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # पिक्चर फ़िल मोड और टाइलिंग प्रॉपर्टीज़ को कॉन्फ़़िगर करें।
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

PowerPoint में, सॉलिड कलर फ़िल एक फ़ॉर्मेट विकल्प है जो आकार को एक समान, एकरंगी रंग से भरता है। यह साधारण पृष्ठभूमि रंग कोई ग्रेडिएंट, टेक्सचर या पैटर्न के बिना लागू किया जाता है।

Aspose.Slides का उपयोग करके आकार पर सॉलिड कलर फ़िल लागू करने के चरण:

1. एक नया उदाहरण बनाएं [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का।
1. इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) को `SOLID` सेट करें।
1. आकार को अपनी पसंद का फ़िल रंग असाइन करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित Python कोड दर्शाता है कि कैसे एक आयत पर सॉलिड कलर फ़िल लागू किया जाए:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # फ़िल टाइप को Solid सेट करें।
    shape.fill_format.fill_type = slides.FillType.SOLID

    # फ़िल रंग सेट करें।
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![सॉलिड कलर फ़िल वाला आकार](solid-color-fill.png)

## **ट्रांसपैरेंसी सेट करें**

PowerPoint में, जब आप आकारों पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता को नियंत्रित करने के लिए ट्रांसपैरेंसी लेवल भी सेट कर सकते हैं। उच्च ट्रांसपैरेंसी मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे की वस्तुएं आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फ़िल के लिए उपयोग किए गए रंग में अल्फा मान को समायोजित करके ट्रांसपैरेंसी लेवल सेट करने की सुविधा देता है। यह करने का तरीका:

1. एक नया उदाहरण बनाएं [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का।
1. इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. फ़िल टाइप को `SOLID` सेट करें।
1. `Color.from_argb` का उपयोग करके ट्रांसपैरेंसी के साथ एक रंग परिभाषित करें (अल्फा घटक ट्रांसपैरेंसी को नियंत्रित करता है)।
1. प्रेजेंटेशन सहेजें।

निम्नलिखित Python कोड दर्शाता है कि कैसे एक आयत पर ट्रांसपैरेंट फ़िल रंग लागू किया जाए:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]
    
    # एक ठोस आयताकार ऑटो शेप जोड़ें।
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # ठोस आकार के ऊपर एक पारदर्शी आयताकार ऑटो शेप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![ट्रांसपेरेंट आकार](shape-transparency.png)

## **आकार घुमाएँ**

Aspose.Slides आपको PowerPoint प्रेजेंटेशन में आकारों को घुमाने की सुविधा देता है। यह विशेष रूप से तब उपयोगी होता है जब आपको दृश्य तत्वों को विशिष्ट संरेखण या डिज़ाइन आवश्यकताओं के साथ स्थित करना होता है।

स्लाइड पर किसी आकार को घुमाने के चरण:

1. एक नया उदाहरण बनाएं [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का।
1. इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार की `rotation` प्रॉपर्टी को वांछित कोण पर सेट करें।
1. प्रेजेंटेशन सहेजें।

निम्नलिखित Python कोड दर्शाता है कि कैसे आकार को 5 डिग्री घुमाया जाए:

```python
import aspose.slides as slides

# प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # Rectangle प्रकार का एक ऑटो शेप जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # आकार को 5 डिग्री घुमाएँ।
    shape.rotation = 5

    # PPTX फ़ाइल को डिस्क पर सहेजें।
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![आकार का घुमाव](shape-rotation.png)

## **3D बिवेल इफ़ेक्ट जोड़ें**

Aspose.Slides आपको आकारों पर 3D बिवेल इफ़ेक्ट लागू करने की सुविधा देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करते हैं।

आकार पर 3D बिवेल इफ़ेक्ट जोड़ने के चरण:

1. एक नया उदाहरण बनाएं [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का।
1. इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार के [ThreeDFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/) को कॉन्फ़िगर करके बिवेल सेटिंग्स परिभाषित करें।
1. प्रेजेंटेशन सहेजें।

निम्नलिखित Python कोड दर्शाता है कि कैसे आकार पर 3D बिवेल इफ़ेक्ट लागू किया जाए:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation क्लास का एक इंस्टेंस बनाएं।
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

    # प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![3D बिवेल इफ़ेक्ट](3D-bevel-effect.png)

## **3D रोटेशन इफ़ेक्ट जोड़ें**

Aspose.Slides आपको आकारों पर 3D रोटेशन इफ़ेक्ट लागू करने की सुविधा देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करते हैं।

आकार पर 3D रोटेशन लागू करने के चरण:

1. एक नया उदाहरण बनाएं [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का।
1. इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्लाइड में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जोड़ें।
1. आकार के [camera_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/camera/camera_type/) और [light_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/lightrig/light_type/) को सेट करके 3D रोटेशन परिभाषित करें।
1. प्रेजेंटेशन सहेजें।

निम्नलिखित Python कोड दर्शाता है कि कैसे आकार पर 3D रोटेशन इफ़ेक्ट लागू किया जाए:

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

    # प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![3D रोटेशन इफ़ेक्ट](3D-rotation-effect.png)

## **फ़ॉर्मेट रीसेट करें**

निम्नलिखित Python कोड दर्शाता है कि कैसे किसी स्लाइड का फ़ॉर्मेट रीसेट किया जाए और [LayoutSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/) में प्लेसहोल्डर्स वाले सभी आकारों की स्थिति, आकार और फ़ॉर्मेट को उनकी डिफ़ॉल्ट सेटिंग्स पर लौटाया जाए:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # लेआउट में प्लेसहोल्डर वाले स्लाइड पर प्रत्येक आकार को रीसेट करें।
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या आकार फॉर्मेटिंग अंतिम प्रेजेंटेशन फ़ाइल आकार को प्रभावित करती है?**

केवल न्यूनतम रूप से। एंबेडेड इमेज और मीडिया फ़ाइलें फ़ाइल के अधिकांश स्थान लेती हैं, जबकि आकार पैरामीटर जैसे रंग, इफ़ेक्ट और ग्रेडिएंट मेटाडेटा के रूप में संग्रहीत होते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं स्लाइड पर ऐसे आकार कैसे पहचानूँ जो समान फ़ॉर्मेटिंग साझा करते हों ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक आकार की प्रमुख फ़ॉर्मेटिंग प्रॉपर्टीज़—फ़िल, लाइन और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके स्टाइल को समान मानें और उन आकारों को तार्किक रूप से समूहित करें, जिससे बाद में स्टाइल प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम आकार स्टाइल का एक सेट अलग फ़ाइल में सहेज सकता हूँ ताकि उसे अन्य प्रेजेंटेशनों में पुनः उपयोग किया जा सके?**

हां। इच्छित स्टाइल वाले नमूना आकारों को एक टेम्प्लेट स्लाइड डेक या .POTX टेम्प्लेट फ़ाइल में रखें। जब नया प्रेजेंटेशन बनाते हैं, तो टेम्प्लेट खोलें, आवश्यक शैली वाले आकारों को क्लोन करें, और जहां भी आवश्यक हो वहाँ उनका फ़ॉर्मेट पुनः लागू करें।