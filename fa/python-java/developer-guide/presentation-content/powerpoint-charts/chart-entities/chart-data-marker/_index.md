---
title: مدیریت نشانگرهای دادهٔ نمودار در ارائه‌ها با استفاده از Python
linktitle: نشانگر داده
type: docs
url: /fa/python-java/chart-data-marker/
keywords:
- نمودار
- نقطه داده
- نشانگر
- گزینه‌های نشانگر
- اندازه نشانگر
- نوع پرکردن
- PowerPoint
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه نشانگرهای دادهٔ نمودار را در Aspose.Slides برای Python از طریق Java سفارشی کنید، تا تاثیر ارائه را در فرمت‌های PPT و PPTX با مثال‌های واضح کد پایتون افزایش دهید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با نشانگرهای دادهٔ نمودار در Aspose.Slides کار کنید. نحوهٔ ایجاد یک نمودار، دسترسی به یک سری و نقاط دادهٔ آن، اعمال پرکردن با تصویر بر نشانگرها در سطح نقطهٔ داده، تنظیم اندازهٔ نشانگر و ذخیرهٔ ارائهٔ بروز رسانی‌شده را نشان می‌دهد. همچنین اشاره می‌کند که اشکال استاندارد نشانگر از طریق شمارش‌گر [MarkerStyleType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markerstyletype/) در دسترس هستند و ظاهر نشانگر هنگام صادر کردن نمودارها به فرمت‌های رستر یا SVG حفظ می‌شود.

## **تنظیم گزینه‌های نشانگر نمودار**
می‌توان نشانگرها را بر نقاط دادهٔ نمودار در یک سری خاص تنظیم کرد. برای تنظیم گزینه‌های نشانگر نمودار، این مراحل را دنبال کنید:

- یک شی از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
- نمودار پیش‌فرض را بسازید.
- تصاویر را تنظیم کنید.
- به اولین سری نمودار دسترسی پیدا کنید.
- نقاط دادهٔ جدید اضافه کنید.
- ارائه را بر روی دیسک بنویسید.

مثال زیر گزینه‌های نشانگر نمودار را در سطح نقطهٔ داده تنظیم می‌کند.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# یک ارائهٔ خالی ایجاد کنید.
presentation = Presentation()
try:
    # دسترسی به اولین اسلاید
    slide = presentation.getSlides().get_Item(0)

    # ایجاد نمودار پیش‌فرض
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # دریافت شاخص ورق کاری داده‌های نمودار پیش‌فرض.
    default_worksheet_index = 0

    # دریافت کتاب کار داده‌های نمودار.
    workbook = chart.getChartData().getChartDataWorkbook()

    # حذف سری نمونه
    chart.getChartData().getSeries().clear()

    # اضافه کردن سری جدید
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # بارگذاری تصویر اول.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # بارگذاری تصویر دوم.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # دسترسی به اولین سری نمودار.
    series = chart.getChartData().getSeries().get_Item(0)

    # افزودن نقاط داده.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # تغییر اندازهٔ نشانگر سری نمودار.
    series.getMarker().setSize(15)

    # ذخیرهٔ ارائه با نمودار
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**کدام اشکال نشانگر به‌صورت پیش‌فرض در دسترس هستند؟**

اشکال استاندارد (دایره، مربع، الماس، مثلث و غیره) در دسترس هستند؛ لیست توسط کلاس [MarkerStyleType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/markerstyletype/) تعریف شده است. اگر به شکل غیراستاندارد نیاز دارید، می‌توانید از نشانگری با پرکردن تصویر برای شبیه‌سازی ظاهر سفارشی استفاده کنید.

**آیا نشانگرها هنگام صادر کردن یک نمودار به تصویر یا SVG حفظ می‌شوند؟**

بله. هنگام رندر نمودارها به [raster formats](/slides/fa/python-java/convert-powerpoint-to-png/) یا ذخیرهٔ [shapes as SVG](/slides/fa/python-java/render-a-slide-as-an-svg-image/)، نشانگرها ظاهر و تنظیمات خود، از جمله اندازه، پرکردن و خط حاشیه را حفظ می‌کنند.