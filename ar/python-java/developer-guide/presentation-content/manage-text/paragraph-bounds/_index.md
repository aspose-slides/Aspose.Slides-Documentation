---
title: الحصول على حدود الفقرة من العروض التقديمية في Python عبر Java
linktitle: حدود الفقرة
type: docs
weight: 43
url: /ar/python-java/paragraph-bounds/
keywords:
- حدود الفقرة
- إحداثيات الفقرة
- حجم الفقرة
- إطار النص
- PowerPoint
- العرض التقديمي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود الفقرة في Aspose.Slides للبايثون عبر Java لتحسين تموضع النص في عروض PowerPoint."
---
## **نظرة عامة**

توضح هذه المقالة كيفية الحصول على حدود وحجم وإحداثيات الفقرات في Aspose.Slides. توضح كيفية استرجاع مستطيل الفقرة من [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) باستخدام [Paragraph.getRect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/#getRect)، وكيفية الحصول على إحداثيات الفقرة داخل إطار نص خلية جدول، وتبرز تفاصيل مهمة مثل وحدات القياس، تأثير التفاف النص على الحدود، تحويل النقاط إلى بكسلات، وقيم تنسيق الفقرة الفعالة.

## **الحصول على إحداثيات المستطيل للفقرة**

استخدم [Paragraph.getRect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/#getRect) للحصول على المستطيل المحيط بالفقرة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **الحصول على حجم الفقرة داخل إطار نص خلية الجدول**

للحصول على حجم وإحداثيات [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) في إطار نص خلية جدول، استخدم [Paragraph.getRect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/#getRect). المستطيل المرجع يكون نسبياً إلى إطار نص خلية الجدول، لذا أضف موقع الجدول وإزاحة الخلية عندما تحتاج إلى إحداثيات على مستوى الشريحة.

المثال التالي يحصل على حدود الفقرة داخل خلية جدول ويرسم مستطيلات على الشريحة لتصوير تلك الحدود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**بأي وحدات يتم قياس إحداثيات الفقرة؟**

يتم قياسها بالنقاط، حيث إن البوصة الواحدة تساوي 72 نقطة. هذا ينطبق على جميع الإحداثيات والأبعاد في الشريحة.

**هل يؤثر التفاف النص على حدود الفقرة؟**

نعم. إذا تم تمكين [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframeformat/#setWrapText) للـ[TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/)، ينكسر النص ليتناسب مع عرض المنطقة، مما يغيّر الحدود الفعلية للفقرة.

**هل يمكن تعيين إحداثيات الفقرة إلى بكسلات في الصورة المصدرة بشكل موثوق؟**

نعم. حوّل النقاط إلى بكسلات باستخدام الصيغة التالية: pixels = points x (DPI / 72). النتيجة تعتمد على DPI المختار للتصيير أو التصدير.

**كيف يمكنني الحصول على معلمات تنسيق الفقرة "الفعالة" مع اعتبار وراثة الأنماط؟**

استخدم [effective paragraph formatting data structure](/slides/ar/python-java/shape-effective-properties/); تُعيد القيم النهائية المجمعة للهوامش والمسافات والالتفاف وRTL والمزيد.