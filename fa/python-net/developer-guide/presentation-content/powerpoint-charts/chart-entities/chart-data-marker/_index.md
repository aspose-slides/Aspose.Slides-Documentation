---
title: مدیریت نشانگرهای داده نمودار در ارائه‌ها با پایتون
linktitle: نشانگر داده
type: docs
url: /fa/python-net/chart-data-marker/
keywords:
- نمودار
- نقطه داده
- نشانگر
- گزینه‌های نشانگر
- اندازه نشانگر
- نوع پرکردن
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "نحوه سفارشی‌سازی نشانگرهای داده نمودار در Aspose.Slides را بیاموزید و با مثال‌های کد واضح، تأثیر ارائه را در فرمت‌های PPT، PPTX و ODP افزایش دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با نشانگرهای داده نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه یک نمودار ایجاد کنید، به یک سری و نقاط داده آن دسترسی پیدا کنید، پر کردن تصویر را بر روی نشانگرها در سطح نقطه داده اعمال کنید، اندازه نشانگر را تنظیم کنید و ارائه به‌روز شده را ذخیره کنید. همچنین اشاره می‌کند که شکل‌های استاندارد نشانگر از طریق enumeration `MarkerStyleType` در دسترس هستند و ظاهر نشانگر هنگام صادرات نمودارها به فرمت‌های رستری یا SVG حفظ می‌شود.

## **تنظیم گزینه‌های نشانگر نمودار**
نشانگرها می‌توانند بر روی نقاط داده نمودار در سری‌های خاص تنظیم شوند. برای تنظیم گزینه‌های نشانگر نمودار، لطفاً مراحل زیر را دنبال کنید:

- نمونه‌سازی کلاس [ارائه](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/).
- ایجاد نمودار پیش‌فرض.
- تنظیم تصویر.
- دریافت اولین سری نمودار.
- افزودن نقطه داده جدید.
- نوشتن ارائه به دیسک.

در مثال زیر، گزینه‌های نشانگر نمودار را در سطح نقاط داده تنظیم کرده‌ایم.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# ایجاد یک نمونه از کلاس Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # ایجاد نمودار پیش‌فرض
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # دریافت شاخص کاربرگ داده نمودار پیش‌فرض
    defaultWorksheetIndex = 0

    # دریافت کاربرگ داده نمودار
    fact = chart.chart_data.chart_data_workbook

    # حذف سری‌های نمونه
    chart.chart_data.series.clear()

    # افزودن سری جدید
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # تنظیم تصویر
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # تنظیم تصویر
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # دریافت اولین سری نمودار
    series = chart.chart_data.series[0]

    # افزودن نقطه جدید (1:3) در آنجا.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # تغییر نشانگر سری نمودار
    series.marker.size = 15

    # نوشتن ارائه در دیسک
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**کدام شکل‌های نشانگر به‌صورت پیش‌فرض در دسترس هستند؟**

شکل‌های استاندارد (دایره، مربع، الماس، مثلث و غیره) در دسترس هستند؛ این فهرست توسط enumeration [MarkerStyleType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/markerstyletype/) تعریف شده است. اگر به شکل غیر استاندارد نیاز دارید، می‌توانید از نشانگری با پرکردن تصویر استفاده کنید تا ظاهر سفارشی را شبیه‌سازی کنید.

**آیا نشانگرها هنگام صادرات نمودار به تصویر یا SVG حفظ می‌شوند؟**

بله. هنگام رندر نمودارها به [فرمت‌های رستری](/slides/fa/python-net/convert-powerpoint-to-png/) یا ذخیره‌سازی [شکل‌ها به‌صورت SVG](/slides/fa/python-net/render-a-slide-as-an-svg-image/)، نشانگرها ظاهر و تنظیمات خود شامل اندازه، پرکردن و خطوط حاشیه را حفظ می‌کنند.