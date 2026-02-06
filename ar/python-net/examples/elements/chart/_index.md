---
title: مخطط
type: docs
weight: 60
url: /ar/python-net/examples/elements/chart/
keywords:
- مخطط
- إضافة مخطط
- الوصول إلى مخطط
- إزالة مخطط
- تحديث مخطط
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتخصيص المخططات في Python باستخدام Aspose.Slides: إضافة البيانات، تنسيق السلاسل والمحاور والتسميات، تغيير الأنواع، وتصدير—يعمل مع PPT و PPTX و ODP."
---
أمثلة لإضافة، الوصول، إزالة وتحديث أنواع مختلفة من المخططات باستخدام **Aspose.Slides for Python via .NET**. توضح المقاطع البرمجية أدناه عمليات المخطط الأساسية.

## **إضافة مخطط**

تضيف هذه الطريقة مخطط منطقة بسيط إلى الشريحة الأولى.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # أضف مخطط عمود بسيط إلى الشريحة الأولى.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى مخطط**

الشفرة التالية تسترجع مخططًا من مجموعة الأشكال.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # الوصول إلى أول مخطط على الشريحة.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **إزالة مخطط**

الشفرة التالية تزيل مخططًا من شريحة.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # بافتراض أن الشكل الأول هو مخطط.
        chart = slide.shapes[0]

        # إزالة المخطط.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **تحديث بيانات المخطط**

يمكنك تغيير خصائص المخطط مثل العنوان.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # بافتراض أن الشكل الأول هو مخطط.
        chart = slide.shapes[0]

        # تغيير عنوان المخطط.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```