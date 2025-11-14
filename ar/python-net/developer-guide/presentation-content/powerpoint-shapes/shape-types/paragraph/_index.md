---
title: فقرة
type: docs
weight: 60
url: /ar/python-net/paragraph/
keywords: "فقرة، جزء، إحداثيات الفقرة، إحداثيات الجزء، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "الفقرة والجزء في عرض PowerPoint باستخدام بايثون"
---

## **احصل على إحداثيات الفقرة والجزء في TextFrame**
باستخدام Aspose.Slides لبايثون عبر .NET، يمكن للمطورين الآن الحصول على الإحداثيات المستطيلة للفقرة داخل مجموعة الفقرات في TextFrame. كما يتيح لك الحصول على إحداثيات الجزء داخل مجموعة الأجزاء في فقرة. في هذا الموضوع، سنوضح بمساعدة مثال كيفية الحصول على الإحداثيات المستطيلة للفقرة مع موضع الجزء داخل الفقرة.

## **الحصول على إحداثيات مستطيلة للفقرة**
تمت إضافة الطريقة الجديدة **GetRect()**. تتيح الحصول على مستطيل حدود الفقرة.

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **الحصول على حجم الفقرة والجزء داخل إطار نص خلية الجدول** ##

للحصول على حجم و[جزء](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) أو [فقرة](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وإحداثياتها في إطار نص خلية الجدول، يمكنك استخدام [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) و[IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) الأساليب.

يظهر هذا الكود المعني العملية الموصوفة:

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