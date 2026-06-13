---
title: نمودار
type: docs
weight: 60
url: /fa/python-net/examples/elements/chart/
keywords:
- نمودار
- افزودن نمودار
- دسترسی به نمودار
- حذف نمودار
- به‌روزرسانی نمودار
- نمونه‌های کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "در Python با Aspose.Slides نمودارها را ایجاد و سفارشی‌سازی کنید: افزودن داده‌ها، قالب‌بندی سری‌ها، محورها و برچسب‌ها، تغییر نوع‌ها و خروجی‌گیری—قابلیت کار با PPT، PPTX و ODP را دارد."
---
مثال‌هایی برای افزودن، دسترسی، حذف و به‌روزرسانی انواع مختلف نمودارها با **Aspose.Slides for Python via .NET**. قطعه کدهای زیر عملیات پایه‌ای نمودارها را نشان می‌دهند.

## **Add a Chart**
این متد یک نمودار ناحیه ساده را به اولین اسلاید اضافه می‌کند.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # افزودن یک نمودار ستونی ساده به اولین اسلاید.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Chart**
کد زیر یک نمودار را از مجموعهٔ اشکال بازیابی می‌کند.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # دسترسی به اولین نمودار روی اسلاید.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Remove a Chart**
کد زیر یک نمودار را از یک اسلاید حذف می‌کند.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض بر این است که اولین شکل یک نمودار است.
        chart = slide.shapes[0]

        # حذف نمودار.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Update Chart Data**
می‌توانید ویژگی‌های نمودار مانند عنوان را تغییر دهید.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض بر این است که اولین شکل یک نمودار است.
        chart = slide.shapes[0]

        # تغییر عنوان نمودار.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```