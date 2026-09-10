---
title: سفارشی‌سازی نمودارهای دایره‌ای در ارائه‌ها با استفاده از Python از طریق Java
linktitle: نمودار دایره‌ای
type: docs
url: /fa/python-java/pie-chart/
keywords:
- نمودار دایره‌ای
- مدیریت نمودار
- سفارشی‌سازی نمودار
- گزینه‌های نمودار
- تنظیمات نمودار
- گزینه‌های رسم
- رنگ برش
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای دایره‌ای را با Python از طریق Java و Aspose.Slides ایجاد و سفارشی‌سازی کنید، قابل صادرات به PowerPoint، و داستان‌سرایی داده‌های خود را در ثانیه‌ها ارتقا دهید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با نمودارهای دایره‌ای در Aspose.Slides کار کنید. همچنین نشان می‌دهد چگونه گزینه‌های نمودار ثانویه را برای نمودارهای Pie of Pie و Bar of Pie پیکربندی کنید و چگونه رنگ‌آمیزی خودکار برش‌های یک نمودار دایره‌ای استاندارد را فعال کنید.

مثال‌ها بر روی گام‌های عملی سفارشی‌سازی نمودار تمرکز دارند؛ از جمله افزودن نمودار به یک اسلاید، تنظیم سری‌ها و برچسب‌ها، جایگزینی داده‌های پیش‌فرض نمودار با دسته‌ها و مقادیر سفارشی، و ذخیره ارائه به‌روز شده.

## **گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie**

Aspose.Slides for Python via Java از گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie پشتیبانی می‌کند. این بخش نشان می‌دهد چگونه این گزینه‌ها را با استفاده از Aspose.Slides مشخص کنید. مراحل زیر را دنبال کنید:

1. یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک نمودار به اسلاید اضافه کنید.
1. گزینه‌های نمودار ثانویه را مشخص کنید.
1. ارائه را روی دیسک بنویسید.

مثال زیر ویژگی‌های مختلف یک نمودار Pie of Pie را تنظیم می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# یک نمونه از کلاس Presentation ایجاد کنید.
presentation = Presentation()
try:
    # یک نمودار به اسلاید اضافه کنید.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # ویژگی‌های مختلف را تنظیم کنید.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # ارائه را روی دیسک بنویسید.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم رنگ خودکار برش‌های نمودار دایره‌ای**

Aspose.Slides for Python via Java یک API ساده برای تنظیم رنگ خودکار برش‌های نمودار دایره‌ای فراهم می‌کند. مثال زیر نحوه اعمال این تنظیمات را نشان می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید.
1. عنوان نمودار را تنظیم کنید.
1. اندیس کاربرگ داده‌های نمودار را تنظیم کنید.
1. کاربرگ داده‌های نمودار را دریافت کنید.
1. سری‌ها و دسته‌های پیش‌فرض را حذف کنید.
1. دسته‌های جدید اضافه کنید.
1. یک سری جدید اضافه کنید.
1. سری جدید را طوری تنظیم کنید که مقادیر را نشان دهد.

نسخه‌ی اصلاح‌شده ارائه را به یک فایل PPTX بنویسید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# یک نمونه از کلاس Presentation ایجاد کنید.
presentation = Presentation()
try:
    # یک نمودار با داده‌های پیش‌فرض اضافه کنید.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # عنوان نمودار را تنظیم کنید.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # اندیس کاربرگ داده‌های نمودار را تنظیم کنید.
    default_worksheet_index = 0

    # Workbook داده‌های نمودار را دریافت کنید.
    workbook = chart.getChartData().getChartDataWorkbook()

    # سری‌ها و دسته‌های پیش‌فرض را حذف کنید.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # دسته‌های جدید اضافه کنید.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # یک سری جدید اضافه کنید.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # داده‌های سری را پر کنید.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # سری جدید را طوری تنظیم کنید که مقادیر را نشان دهد.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**آیا انواع 'Pie of Pie' و 'Bar of Pie' پشتیبانی می‌شوند؟**

بله، کتابخانه [پشتیبانی می‌کند](https://reference.aspose.com/slides/fa/python-java/aspose.slides/charttype/) یک نمودار ثانویه برای نمودارهای دایره‌ای، از جمله انواع 'Pie of Pie' و 'Bar of Pie'.

**آیا می‌توانم فقط نمودار را به‌عنوان تصویر (مثلاً PNG) صادر کنم؟**

بله، می‌توانید [نمودار را به‌عنوان تصویر صادر کنید](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) (مانند PNG) بدون اینکه کل ارائه را صادر کنید.