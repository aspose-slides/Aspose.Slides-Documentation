---
title: Manage Bulleted and Numbered Lists in Presentations in Python
linktitle: Manage Lists
type: docs
weight: 70
url: /python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
- bullet
- bulleted list
- numbered list
- symbol bullet
- picture bullet
- custom bullet
- multilevel list
- create bullet
- add bullet
- add list
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to create and format bulleted, picture, multilevel, and numbered lists in PowerPoint and OpenDocument presentations using Aspose.Slides for Python via .NET."
---

## **Overview**

Aspose.Slides for Python via .NET lets you create and format bulleted and numbered lists in PowerPoint and OpenDocument presentations. A list item is a paragraph whose bullet settings are controlled through its paragraph format.

Use the [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) property to access paragraph-level list settings. The main entry point is [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/), which returns a [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) object. With this object, you can set the bullet type, symbol, picture, color, size, numbering style, and starting number.

This article shows how to:

- create a bulleted list with a custom symbol
- create a picture bullet
- create a multilevel list by setting paragraph depth
- create a numbered list
- inspect and change list formatting in an existing presentation
- read actual list markers and numbers alongside paragraph text

## **Create a Bulleted List**

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

The result:

![The symbol bullets](symbol_bullets.png)

## **Create a Numbered List**

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

The result:

![The numbered bullets](numbered_bullets.png)

## **Create a Picture Bullet**

Aspose.Slides allows you to replace a regular bullet symbol with an image. Picture bullets work best with simple images that remain readable at a small size, such as icons or small transparent PNG files.

 {{% alert color="info" title="Note" %}}

Ideally, if you plan to replace the regular bullet symbol with an image, it's best to choose a simple graphic with a transparent background. Such images work well as custom bullet symbols.

Keep in mind that the image will be scaled down to a very small size. For that reason, we strongly recommend selecting an image that remains clear and visually effective when used as a bullet in a list.

{{% /alert %}}

To create a picture bullet, add an image to [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/) and assign the returned image object to [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). Set [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) to [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) before assigning the image.

Let's say we have an "image.png":

![A picture for the bullets](picture_for_bullets.png)

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

The result:

![The picture bullets](picture_bullets.png)

## **Create a Multilevel List**

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

The result:

![The multilevel list](multilevel_list.png)

## **Change an Existing List**

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

## **Read Actual Bullet Values**

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

    # Create a picture marker without an external image file.
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

![Lists starting at 5, nested letter and Roman-number items, a symbol marker, a paragraph without a bullet, and a blue picture marker](actual_bullet_values.png)

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

**Can bulleted and numbered lists be exported to PDF or images?**

Yes. Aspose.Slides preserves list formatting when the target format supports the corresponding text layout and bullet features.

**Can I edit lists in existing presentations?**

Yes. Load the presentation, access the target paragraph, inspect or update its [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) settings, and save the presentation.

**Can lists contain non-Latin text?**

Yes. List item text can contain Unicode characters, so you can create lists in multilingual presentations. Make sure the fonts used in the presentation support the characters you need.
