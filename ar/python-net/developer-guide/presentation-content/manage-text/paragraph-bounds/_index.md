---
title: الحصول على حدود الفقرات من العروض التقديمية في بايثون
linktitle: حدود الفقرات
type: docs
weight: 43
url: /ar/python-net/paragraph-bounds/
keywords:
- حدود الفقرة
- إحداثيات الفقرة
- حجم الفقرة
- إطار النص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود الفقرات في Aspose.Slides لبايثون عبر .NET لتحسين موضع النص في عروض PowerPoint وOpenDocument التقديمية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية الحصول على حدود الفقرات وحجمها وإحداثياتها في Aspose.Slides. توضح كيفية استرجاع مستطيل الفقرة من [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) باستخدام [Paragraph.get_rect](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/get_rect/)، وكيفية الحصول على إحداثيات الفقرة داخل إطار نص خلية جدول، وتبرز تفاصيل هامة مثل وحدات القياس، تأثير تغليف النص على الحدود، تحويل البكسل، وقيم تنسيق الفقرة الفعّالة.

## **الحصول على إحداثيات مستطيلة للفقرة**

استخدم [Paragraph.get_rect](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/get_rect/) للحصول على المستطيل الحدودي لفقرة.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **الحصول على حجم الفقرة داخل TextFrame لخلية جدول**

للحصول على حجم وإحداثيات [Paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/) داخل إطار نص خلية جدول، استخدم [Paragraph.get_rect](https://reference.aspose.com/slides/ar/python-net/aspose.slides/paragraph/get_rect/). المستطيل المعاد يكون نسبياً إلى إطار نص خلية الجدول، لذا أضف موضع الجدول وإزاحة الخلية عندما تحتاج إلى إحداثيات على مستوى الشريحة.

المثال التالي يحصل على حدود الفقرة داخل خلية جدول ويرسم مستطيلات على الشريحة لتصوير تلك الحدود:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**بأي وحدات يتم قياس إحداثيات الفقرة؟**

يتم قياسها بالنقاط، حيث أن البوصة الواحدة تعادل 72 نقطة. ينطبق ذلك على جميع الإحداثيات والأبعاد على الشريحة.

**هل يؤثر تغليف الكلمات على حدود الفقرة؟**

نعم. إذا تم تمكين [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframeformat/wrap_text/) لإطار النص [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/)، يتم كسر النص ليتناسب مع عرض المنطقة، مما يغيّر الحدود الفعلية للفقرة.

**هل يمكن ربط إحداثيات الفقرة بشكل موثوق بالبكسل في الصورة المصدرة؟**

نعم. قم بتحويل النقاط إلى بكسل باستخدام الصيغة التالية: البكسل = النقاط × (DPI ÷ 72). النتيجة تعتمد على DPI المختار للتصوير أو التصدير.

**كيف أحصل على معلمات تنسيق الفقرة "الفعّالة" مع مراعاة وراثة الأنماط؟**

استخدم [effective paragraph formatting data structure](/slides/ar/python-net/shape-effective-properties/); تُرجع القيم النهائية المجمّعة للمسافات البادئة، الفواصل، التغليف، الاتجاه من اليمين إلى اليسار، والمزيد.