---
title: سفارشی‌سازی نمودارهای 3D در ارائه‌ها با استفاده از Python
linktitle: نمودار 3D
type: docs
url: /fa/python-java/3d-chart/
keywords:
- نمودار 3D
- چرخش
- عمق
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای 3-بعدی را در Aspose.Slides برای Python از طریق Java ایجاد و سفارشی کنید، با پشتیبانی از فایل‌های PPT و PPTX—امروز ارائه‌های خود را ارتقا دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه یک نمودار 3D را در Aspose.Slides با پیکربندی تنظیمات [Rotation3D](https://reference.aspose.com/slides/fa/python-java/aspose.slides/rotation3d/) مانند [setRotationX](https://reference.aspose.com/slides/fa/python-java/aspose.slides/rotation3d/#setRotationX)، [setRotationY](https://reference.aspose.com/slides/fa/python-java/aspose.slides/rotation3d/#setRotationY)، [setDepthPercents](https://reference.aspose.com/slides/fa/python-java/aspose.slides/rotation3d/#setDepthPercents) و [setRightAngleAxes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/rotation3d/#setRightAngleAxes) سفارشی‌سازی کنیم. این مقاله مراحلی از ایجاد یک ارائه، افزودن یک نمودار 3D با داده‌های پیش‌فرض، اعمال تنظیمات نمای 3D مورد نیاز و ذخیره ارائه اصلاح‌شده به‌صورت فایل PPTX را شرح می‌دهد.

## **تنظیم چرخش X، چرخش Y و عمق یک نمودار 3D**

Aspose.Slides برای Python از طریق Java یک API ساده برای تنظیم این ویژگی‌ها فراهم می‌کند. مثال زیر نشان می‌دهد چگونه چرخش X، چرخش Y و عمق یک نمودار 3D را تنظیم کنیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید.
1. ویژگی‌های چرخش 3D را تنظیم کنید.
1. ارائه اصلاح‌شده را به یک فایل PPTX بنویسید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # دسترسی به اولین اسلاید.
    slide = presentation.getSlides().get_Item(0)

    # افزودن یک نمودار با داده‌های پیش‌فرض.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # تنظیم شاخص برگه کاری داده‌های نمودار.
    default_worksheet_index = 0

    # دریافت دفتر کار داده‌های نمودار.
    workbook = chart.getChartData().getChartDataWorkbook()

    # افزودن سری‌ها.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # افزودن دسته‌ها.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # تنظیم ویژگی‌های چرخش 3D.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # دسترسی به سری دوم نمودار.
    series = chart.getChartData().getSeries().get_Item(1)

    # تکمیل داده‌های سری.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # ذخیره ارائه.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**کدام نوع نمودارها از حالت 3D در Aspose.Slides پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3D نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به‌همراه انواع 3D مرتبط که از طریق کلاس [ChartType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/charttype/) در دسترس هستند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/charttype/) را در مرجع API نسخه نصب‌شده خود بررسی کنید.

**آیا می‌توانم تصویر رستر یک نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید یک نمودار را از طریق [chart API](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) به تصویر صادر کنید یا [کل اسلاید را رندر کنید](/slides/fa/python-java/convert-powerpoint-to-png/) به فرمت‌هایی مانند PNG یا JPEG. این کار زمانی مفید است که نیاز به پیش‌نمایش دقیق پیکسل‌به‌پیکسل دارید یا می‌خواهید نمودار را بدون نیاز به PowerPoint در اسناد، داشبوردها یا صفحات وب جاسازی کنید.

**عملکرد ساخت و رندر نمودارهای 3D بزرگ چقدر است؟**

عملکرد بستگی به حجم داده‌ها و پیچیدگی بصری دارد. برای بهترین نتایج، اثرات 3D را به حداقل برسانید، از بافت‌های سنگین در دیوارها و نواحی نمودار پرهیز کنید، در صورت امکان تعداد نقاط داده در هر سری را محدود کنید و رندر را به خروجی با ابعاد و وضوح مناسب برای نمایش یا چاپ هدف انجام دهید.