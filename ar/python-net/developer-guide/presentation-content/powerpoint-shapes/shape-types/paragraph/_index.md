---
title: الحصول على حدود الفقرة من العروض التقديمية باستخدام بايثون
linktitle: الفقرة
type: docs
weight: 60
url: /ar/python-net/paragraph/
keywords:
- حدود الفقرة
- حدود جزء النص
- إحداثيات الفقرة
- إحداثيات الجزء
- حجم الفقرة
- حجم جزء النص
- إطار النص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرّف على كيفية استرجاع حدود الفقرة وجزء النص في Aspose.Slides للبايثون عبر .NET لتحسين موضع النص في عروض PowerPoint وOpenDocument."
---

## **الحصول على إحداثيات الفقرة والجزء داخل TextFrame**
باستخدام Aspose.Slides للبايثون عبر .NET، يمكن للمطورين الآن الحصول على إحداثيات المستطيل للفقرة داخل مجموعة الفقرات في TextFrame. كما يتيح لك الحصول على إحداثيات الجزء داخل مجموعة الأجزاء للفقرة. في هذا الموضوع، سوف نوضح من خلال مثال كيفية الحصول على إحداثيات المستطيل للفقرة مع موضع الجزء داخل الفقرة.

## **الحصول على إحداثيات المستطيل للفقرة**
تم إضافة الطريقة الجديدة **GetRect()**. تتيح لك الحصول على مستطيل حدود الفقرة.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **الحصول على حجم الفقرة والجزء داخل إطار نص خلية الجدول** ##

للحصول على حجم وإحداثيات [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) أو [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) داخل إطار نص خلية جدول، يمكنك استخدام طريقتي [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) و[IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).

يظهر هذا المثال الشيفرة التي توضح العملية المذكورة:

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

**بأي وحدات يتم إرجاع الإحداثيات للفقرة وأجزاء النص؟**

بالنقاط، حيث 1 بوصة = 72 نقطة. ينطبق ذلك على جميع الإحداثيات والأبعاد على الشريحة.

**هل يؤثر التفاف الكلمات على حدود الفقرة؟**

نعم. إذا تم تمكين [wrapping](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) في [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، يتم تقسيم النص ليتناسب مع عرض المنطقة، مما يغيّر حدود الفقرة الفعلية.

**هل يمكن ربط إحداثيات الفقرة بدقة بالبكسل في الصورة المصدرة؟**

نعم. حوّل النقاط إلى بكسل باستخدام: pixels = points × (DPI / 72). النتيجة تعتمد على الـ DPI المختار للتصوير/التصدير.

**كيف أحصل على معلمات تنسيق الفقرة "الفعّالة" مع مراعاة وراثة النمط؟**

استخدم [effective paragraph formatting data structure](/slides/ar/python-net/shape-effective-properties/); تُعيد القيم النهائية المجمعة للمسافات البادئة، التباعد، الالتفاف، RTL، وغيرها.