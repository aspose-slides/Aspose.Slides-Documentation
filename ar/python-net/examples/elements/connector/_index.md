---
title: موصل
type: docs
weight: 190
url: /ar/python-net/examples/elements/connector/
keywords:
- موصل
- إضافة موصل
- الوصول إلى موصل
- إزالة موصل
- إعادة ربط الأشكال
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "ارسم وتحكم في الموصلات باستخدام بايثون مع Aspose.Slides: أضف، وامر، وأعد توجيه، حدد نقاط الاتصال، الأسهم والأنماط لربط الأشكال في ملفات PPT و PPTX و ODP."
---
يعرض كيفية ربط الأشكال بالموصلات وتغيير أهدافها باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة موصل**
أدرج شكل موصّل بين نقطتين على الشريحة.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # إضافة شكل موصل معقوف.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى موصل**
استرجع أول شكل موصّل تم إضافته إلى شريحة.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # الوصول إلى أول موصل على الشريحة.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **إزالة موصل**
احذف موصلاً من الشريحة.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # افتراض أن الشكل الأول هو موصل.
        connector = slide.shapes[0]

        # إزالة الموصل.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **إعادة ربط الأشكال**
أرفق موصلاً إلى شكلين عن طريق تعيين أهداف البداية والنهاية.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # إضافة الشكل المستطيل الأول.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # إضافة الشكل المستطيل الثاني.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # إضافة شكل موصل معقوف.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # ربط بداية الموصل بالشكل الأول.
        connector.start_shape_connected_to = shape1
        # ربط نهاية الموصل بالشكل الثاني.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```