---
title: الارتباط التشعبي
type: docs
weight: 130
url: /ar/python-net/examples/elements/hyperlink/
keywords:
- الارتباط التشعبي
- إضافة ارتباط تشعبي
- الوصول إلى ارتباط تشعبي
- إزالة ارتباط تشعبي
- تحديث ارتباط تشعبي
- أمثلة على الأكواد
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إضافة وتحرير وإزالة الروابط التشعبية في بايثون باستخدام Aspose.Slides: نص الرابط، الأشكال، الشرائح، عناوين URL والبريد الإلكتروني؛ تعيين الأهداف والإجراءات لـ PPT و PPTX و ODP."
---
يوضح إضافة، الوصول، إزالة، وتحديث الروابط التشعبية على الأشكال باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة ارتباط تشعبي**

إنشاء شكل مستطيل يحتوي على ارتباط تشعبي يشير إلى موقع ويب خارجي.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى ارتباط تشعبي**

قراءة معلومات الارتباط التشعبي من جزء النص في الشكل.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **إزالة ارتباط تشعبي**

مسح الارتباط التشعبي من نص الشكل.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **تحديث ارتباط تشعبي**

تغيير هدف الارتباط التشعبي الموجود. استخدم `HyperlinkManager` لتعديل النص الذي يحتوي بالفعل على ارتباط تشعبي، مما يحاكي طريقة تحديث PowerPoint للارتباطات التشعبية بأمان.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # يجب تعديل ارتباط تشعبي داخل النص الموجود عبر
        # HyperlinkManager بدلاً من ضبط الخاصية مباشرةً.
        # هذا يحاكي طريقة تحديث PowerPoint للروابط التشعبية بأمان.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```