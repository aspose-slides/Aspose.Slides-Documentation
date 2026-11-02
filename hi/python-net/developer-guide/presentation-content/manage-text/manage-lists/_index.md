---
title: "Python में प्रस्तुतियों में बुलेटेड और क्रमांकित सूचियों का प्रबंधन"
linktitle: "सूचियों का प्रबंधन"
type: docs
weight: 70
url: /hi/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
  - बुलेट
  - बुलेटेड सूची
  - क्रमांकित सूची
  - प्रतीक बुलेट
  - चित्र बुलेट
  - कस्टम बुलेट
  - बहु-स्तरीय सूची
  - बुलेट बनाएं
  - बुलेट जोड़ें
  - सूची जोड़ें
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - Python
  - Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड, चित्र, बहु-स्तरीय और क्रमांकित सूचियों को बनाने और फ़ॉर्मेट करने के तरीके सीखें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET आपको PowerPoint और OpenDocument प्रस्तुतियों में बुलेटेड और नंबरेड सूचियाँ बनाने और फ़ॉर्मेट करने की अनुमति देता है। एक सूची आइटम एक पैराग्राफ होता है जिसका बुलेट सेटिंग्स उसके पैराग्राफ फॉर्मेट के माध्यम से नियंत्रित होते हैं।

Use the [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) property to access paragraph-level list settings. The main entry point is [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/), which returns a [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) object. With this object, you can set the bullet type, symbol, picture, color, size, numbering style, and starting number.

This article shows how to:

- एक कस्टम प्रतीक के साथ बुलेटेड सूची बनाना
- चित्र बुलेट बनाना
- पैराग्राफ गहराई सेट करके मल्टीलेवल सूची बनाना
- नंबरेड सूची बनाना
- मौजूदा प्रस्तुति में सूची फ़ॉर्मेटिंग की जांच और परिवर्तन करना
- पैराग्राफ टेक्स्ट के साथ वास्तविक सूची चिह्न और नंबर पढ़ना

## **बुलेटेड सूची बनाना**

To create a bulleted list, add [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) objects to a [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) and set [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) to [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/). You can then set [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/color/), and [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) to control the bullet appearance.

The following Python code demonstrates how to create a bulleted list in a slide:

```py
import aspose.slides as slides

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = slides.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![प्रतीक बुलेट्स](symbol_bullets.png)

## **नंबरेड सूची बनाना**

Use numbered lists when the order of items matters. Set [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) to [BulletType.NUMBERED](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/). You can also choose a numbering format with [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) or set [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) when the list should start from a value other than 1.

The following Python code shows how to create a numbered list in a slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![नंबरेड बुलेट्स](numbered_bullets.png)

## **चित्र बुलेट बनाना**

Aspose.Slides आपको एक नियमित बुलेट प्रतीक को छवि से बदलने की अनुमति देता है। चित्र बुलेट सरल छवियों के साथ सबसे अच्छा काम करते हैं जो छोटे आकार पर भी पढ़ने योग्य रहें, जैसे आइकन या छोटे पारदर्शी PNG फ़ाइलें।

{{% alert color="info" title="Note" %}}
आदर्श रूप में, यदि आप नियमित बुलेट प्रतीक को छवि से बदलने की योजना बनाते हैं, तो पारदर्शी पृष्ठभूमि वाली एक सरल ग्राफ़िक चुनना सबसे अच्छा है। ऐसी छवियां कस्टम बुलेट प्रतीकों के रूप में अच्छी तरह काम करती हैं।

छवि को बहुत छोटे आकार तक स्केल किया जाएगा। इस कारण हम दृढ़ता से अनुशंसा करते हैं कि ऐसी छवि चुनें जो सूची में बुलेट के रूप में उपयोग होने पर भी स्पष्ट और दृश्य रूप से प्रभावी रहे।
{{% /alert %}}

To create a picture bullet, add an image to [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/) and assign the returned image object to [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). Set [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) to [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) before assigning the image.

मान लीजिए हमारे पास एक "image.png" है:

![बुलेट्स के लिए चित्र](picture_for_bullets.png)

The following Python code shows how to create picture bullets in a slide:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![चित्र बुलेट्स](picture_bullets.png)

## **मल्टीलेवल सूची बनाना**

Use [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) to place list items on different levels. Level 0 is the top level, level 1 is nested below it, and so on. Depth controls indentation only; set [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) on each paragraph when the levels should also carry bullets.

The following Python code shows how to create a multilevel list:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![मल्टीलेवल सूची](multilevel_list.png)

## **मौजूदा सूची बदलें**

To change list formatting in an existing presentation, access the target paragraph and update its [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) settings. The same properties used to create lists can be used to inspect or modify lists loaded from a PPT, PPTX, or ODP file.

The following Python code changes the first paragraph in a text frame to use a numbered list style:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **वास्तविक बुलेट मान पढ़ें**

When extracting presentation content, keep list markers alongside paragraph text. Call [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/) and access [IParagraphFormatEffectiveData.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformateffectivedata/bullet/) to obtain the effective bullet format. Check its [type](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/type/) before reading [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/).

For numbered lists, distinguish these three values:

- [numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_style/) determines the format, such as Arabic numbers followed by a period or lowercase letters followed by a period.
- [numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_start_with/) specifies the starting number for a group of numbered paragraphs.
- [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) returns the formatted marker for a particular paragraph. For example, the second item in a list starting at 5 returns `6.`.

Preserve [depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) with each paragraph to retain its nesting level. The actual marker does not encode the full hierarchy: a nested item can return `c.` rather than a combined label such as `6.c.`.

The following self-contained example creates lists, saves them to a presentation, and reloads the presentation to report each paragraph's text, depth, bullet type, and actual value. The small blue picture marker is created from inline SVG.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 440, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20, 660, 400)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    # बाहरी छवि फ़ाइल के बिना एक चित्र मार्कर बनाएं।
    svg = slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.images.add_image(svg)

    def add_paragraph(text, depth, bullet_type, start=1, style=slides.NumberedBulletStyle.BULLET_ARABIC_PERIOD):
        paragraph = slides.Paragraph()
        paragraph.text = text

        paragraph_format = paragraph.paragraph_format
        paragraph_format.depth = depth
        paragraph_format.margin_left = 30 + depth * 40
        paragraph_format.indent = -28
        paragraph_format.space_after = 8
        paragraph_format.default_portion_format.font_height = 22
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = slides.Color.black
        paragraph_format.bullet.type = bullet_type
        paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
        paragraph_format.bullet.color.color = slides.Color.black
        if bullet_type == slides.BulletType.NUMBERED:
            paragraph_format.bullet.numbered_bullet_style = style
            paragraph_format.bullet.numbered_bullet_start_with = start
        elif bullet_type == slides.BulletType.SYMBOL:
            paragraph_format.bullet.char = "\u2022"
        elif bullet_type == slides.BulletType.PICTURE:
            paragraph_format.bullet.picture.image = bullet_image

        text_frame.paragraphs.add(paragraph)

    add_paragraph("First item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Second item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Next nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Deep item", 2, slides.BulletType.NUMBERED, 4, slides.NumberedBulletStyle.BULLET_ROMAN_LC_PERIOD)
    add_paragraph("Back to top level", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Symbol marker", 0, slides.BulletType.SYMBOL)
    add_paragraph("No bullet", 0, slides.BulletType.NONE)
    add_paragraph("Picture marker", 0, slides.BulletType.PICTURE)
    presentation.save("actual_bullet_values.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("actual_bullet_values.pptx") as loaded_presentation:
    loaded_shape = loaded_presentation.slides[0].shapes[0]
    bullet_type_names = {slides.BulletType.NUMBERED: "NUMBERED", slides.BulletType.SYMBOL: "SYMBOL", slides.BulletType.NONE: "NONE", slides.BulletType.PICTURE: "PICTURE"}
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.text_frame.paragraphs:
        bullet = paragraph.paragraph_format.get_effective().bullet
        if bullet.type in (slides.BulletType.NUMBERED, slides.BulletType.SYMBOL):
            marker = bullet.actual_bullet_value
        elif bullet.type == slides.BulletType.NONE:
            marker = f"{bullet.actual_bullet_value} (no bullet)"
        elif bullet.type == slides.BulletType.PICTURE:
            marker = f"{bullet.actual_bullet_value} (image required)"
        else:
            marker = "unsupported bullet type"
        bullet_type_name = bullet_type_names.get(bullet.type, "UNKNOWN")
        print(f"{paragraph.text} | {paragraph.paragraph_format.depth} | {bullet_type_name} | {marker}")
```

The source lists are shown below.

![5 से शुरू होने वाली सूचियाँ, नेस्टेड अक्षर और रोमन नंबर आइटम, एक प्रतीक मार्कर, बुलेट के बिना पैराग्राफ, और नीला चित्र मार्कर](actual_bullet_values.png)

The report matches the markers displayed in PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | NUMBERED | 5.
Second item | 0 | NUMBERED | 6.
Nested item | 1 | NUMBERED | c.
Next nested item | 1 | NUMBERED | d.
Deep item | 2 | NUMBERED | iv.
Back to top level | 0 | NUMBERED | 7.
Symbol marker | 0 | SYMBOL | •
No bullet | 0 | NONE | None (no bullet)
Picture marker | 0 | PICTURE | None (image required)
```

For [BulletType.NONE and BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/), [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) returns `None`, not an empty string. Handle these types separately: the former has no marker, while the latter requires extracting the bullet image separately. A picture bullet cannot be reproduced solely by extracting a text marker.

## **FAQ**

**क्या बुलेटेड और नंबरेड सूचियाँ PDF या छवियों में निर्यात की जा सकती हैं?**

हां। Aspose.Slides सूची फ़ॉर्मेटिंग को बनाए रखता है जब लक्ष्य फ़ॉर्मेट संबंधित टेक्स्ट लेआउट और बुलेट सुविधाओं का समर्थन करता है।

**क्या मैं मौजूदा प्रस्तुतियों में सूचियों को संपादित कर सकता हूँ?**

हां। प्रस्तुति लोड करें, लक्ष्य पैराग्राफ तक पहुंचें, उसकी [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) सेटिंग्स की जांच या अपडेट करें, और प्रस्तुति को सहेजें।

**क्या सूचियों में गैर-लैटिन टेक्स्ट हो सकता है?**

हां। सूची आइटम टेक्स्ट Unicode अक्षर रख सकता है, इसलिए आप बहुभाषी प्रस्तुतियों में सूचियां बना सकते हैं। सुनिश्चित करें कि प्रस्तुति में उपयोग किए गए फ़ॉन्ट आवश्यक अक्षरों का समर्थन करते हैं।