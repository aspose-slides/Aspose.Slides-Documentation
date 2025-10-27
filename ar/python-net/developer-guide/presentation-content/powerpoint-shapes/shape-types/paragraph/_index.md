---
title: Get Paragraph Bounds from Presentations in Python
linktitle: Paragraph
type: docs
weight: 60
url: /ar/python-net/paragraph/
keywords:
- paragraph bounds
- text portion bounds
- paragraph coordinate
- portion coordinate
- paragraph size
- text portion size
- text frame
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to retrieve paragraph and text-portion bounds in Aspose.Slides for Python via .NET to optimize text positioning in PowerPoint and OpenDocument presentations."
---

## **الحصول على إحداثيات الفقرة والجزء في TextFrame**
باستخدام Aspose.Slides for Python via .NET، يستطيع المطورون الآن الحصول على إحداثيات المستطيل للفقرة داخل مجموعة الفقرات في TextFrame. كما يسمح بالحصول على إحداثيات الجزء داخل مجموعة الأجزاء لفقرة معينة. في هذا الموضوع، سنظهر من خلال مثال كيفية الحصول على إحداثيات المستطيل للفقرة مع موقع الجزء داخل الفقرة.

## **الحصول على إحداثيات المستطيل للفقرة**
تمت إضافة الطريقة الجديدة **GetRect()**. تسمح بالحصول على مربع حدود الفقرة.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **الحصول على حجم الفقرة والجزء داخل إطار نص خلية الجدول** ##

للحصول على حجم وإحداثيات [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) أو [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) داخل إطار نص خلية جدول، يمكنك استخدام الطريقتين [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) و[IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).

هذا المثال يوضح العملية الموصوفة:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **FAQ**

**ما هي الوحدات التي تُرجع بها إحداثيات الفقرة وأجزاء النص؟**

تُقاس بوحدات النقاط، حيث إن 1 بوصة = 72 نقطة. ينطبق ذلك على جميع الإحداثيات والأبعاد على الشريحة.

**هل يؤثر التفاف النص على حدود الفقرة؟**

نعم. إذا كان [wrapping](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) مفعلاً في الـ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، ينكسر النص ليتناسب مع عرض المنطقة، مما يغيّر الحدود الفعلية للفقرة.

**هل يمكن ربط إحداثيات الفقرة بوضوح بالبكسل في الصورة المصدرة؟**

نعم. حوّل النقاط إلى بكسل باستخدام: pixels = points × (DPI / 72). تعتمد النتيجة على DPI المختار للتصوير/التصدير.

**كيف أحصل على معاملات تنسيق الفقرة "الفعّالة" مع مراعاة وراثة الأنماط؟**

استخدم [effective paragraph formatting data structure](/slides/ar/python-net/shape-effective-properties/); فإنه يُعيد القيم النهائية المجمّعة للمسافات البادئة، التباعد، الالتفاف، RTL، وأكثر.