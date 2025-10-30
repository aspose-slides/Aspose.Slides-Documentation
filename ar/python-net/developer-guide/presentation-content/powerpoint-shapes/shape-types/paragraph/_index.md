---
title: الحصول على حدود الفقرة من العروض التقديمية في بايثون
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
description: "تعلم كيفية استرداد حدود الفقرة وجزء النص في Aspose.Slides لبايثون عبر .NET لتحسين تموضع النص في عروض PowerPoint وOpenDocument."
---

## **الحصول على إحداثيات الفقرة والجزء في إطار النص**
باستخدام Aspose.Slides لبايثون عبر .NET، يمكن للمطورين الآن الحصول على إحداثيات المستطيل للفقرة داخل مجموعة فقرات إطار النص. كما يسمح بالحصول على إحداثيات الجزء داخل مجموعة أجزاء الفقرة. في هذا الموضوع، سنعرض مثالًا يوضح كيفية الحصول على إحداثيات المستطيل للفقرة مع موضع الجزء داخل الفقرة.

## **الحصول على إحداثيات المستطيل للفقرة**
تمت إضافة الطريقة الجديدة **GetRect()**. تسمح بالحصول على مستطيل حدود الفقرة.

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **الحصول على حجم الفقرة والجزء داخل إطار النص لخلية الجدول** ##

للحصول على حجم [الجزء](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) أو [الفقرة](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) وإحداثياتهما في إطار نص خلية جدول، يمكنك استخدام طريقتي [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) و[IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).

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

## **الأسئلة المتكررة**

**بأي وحدات يتم إرجاع الإحداثيات للفقرة وأجزاء النص؟**

بالنقاط، حيث إن 1 بوصة = 72 نقطة. ينطبق هذا على جميع الإحداثيات والأبعاد على الشريحة.

**هل يؤثر التفاف الكلمات على حدود الفقرة؟**

نعم. إذا تم تمكين [الالتفاف](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) في [إطار النص](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)، فإن النص يُكسر ليناسب عرض المنطقة، مما يغيّر الحدود الفعلية للفقرة.

**هل يمكن تعيين إحداثيات الفقرة إلى بكسلات في الصورة المصدرة بشكل موثوق؟**

نعم. تحويل النقاط إلى بكسلات باستخدام: pixels = points × (DPI / 72). النتيجة تعتمد على قيمة DPI المختارة للعرض/التصدير.

**كيف يمكنني الحصول على معاملات تنسيق الفقرة "الفعّالة" مع مراعاة وراثة الأنماط؟**

استخدم [بنية بيانات تنسيق الفقرة الفعّالة](/slides/ar/python-net/shape-effective-properties/); تُعيد القيم النهائية المدمجة للمسافات البادئة، والتباعد، والالتفاف، والكتابة من اليمين إلى اليسار، وغير ذلك.