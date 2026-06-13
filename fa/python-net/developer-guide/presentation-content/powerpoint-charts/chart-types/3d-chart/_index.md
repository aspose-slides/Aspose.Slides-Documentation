---
title: سفارشی‌سازی نمودارهای سه‌بعدی در ارائه‌ها با پایتون
linktitle: نمودار 3D
type: docs
url: /fa/python-net/3d-chart/
keywords:
- نمودار سه‌بعدی
- چرخش
- عمق
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای سه‌بعدی را در Aspose.Slides برای Python از طریق .NET ایجاد و سفارشی کنید، با پشتیبانی از فایل‌های PPT، PPTX و ODP—امروزه ارائه‌های خود را بهبود ببخشید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه یک نمودار سه‌بعدی در Aspose.Slides را با پیکربندی تنظیمات `rotation_3d` مانند `rotation_x`، `rotation_y`، `depth_percents` و `right_angle_axes` سفارشی کنیم. این مقاله مراحل ایجاد یک ارائه، افزودن یک نمودار سه‌بعدی با داده‌های پیش‌فرض، اعمال تنظیمات نمای سه‌بعدی مورد نیاز و ذخیره ارائه اصلاح‌شده به صورت فایل PPTX را مرور می‌کند.

## **تنظیم خصوصیات RotationX، RotationY و DepthPercents نمودار سه‌بعدی**
Aspose.Slides برای Python از طریق .NET یک API ساده برای تنظیم این خصوصیات فراهم می‌کند. مقاله زیر به شما کمک می‌کند تا چگونگی تنظیم خصوصیات مختلفی مانند چرخش X، Y، **DepthPercents** و غیره را بیاموزید. کد نمونه تنظیم خصوصیات ذکرشده در بالا را اجرا می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. نمودار را با داده‌های پیش‌فرض اضافه کنید.
1. خصوصیات Rotation3D را تنظیم کنید.
1. ارائه اصلاح‌شده را به یک فایل PPTX بنویسید.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# ایجاد یک نمونه از کلاس Presentation
with slides.Presentation() as presentation:
            
    # دسترسی به اولین اسلاید
    slide = presentation.slides[0]

    # افزودن نمودار با داده‌های پیش‌فرض
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # تنظیم شاخص صفحه‌کاری داده‌های نمودار
    defaultWorksheetIndex = 0

    # دریافت صفحه‌کار داده‌های نمودار
    fact = chart.chart_data.chart_data_workbook

    # افزودن سری‌ها
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # افزودن دسته‌ها
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # تنظیم خصوصیات Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # گرفتن سری دوم نمودار
    series = chart.chart_data.series[1]

    # اکنون پر کردن داده‌های سری
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # تنظیم مقدار OverLap
    series.parent_series_group.overlap = 100         

    # نوشتن ارائه به دیسک
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**کدام انواع نمودارها حالت سه‌بعدی را در Aspose.Slides پشتیبانی می‌کنند؟**

Aspose.Slides انواع سه‌بعدی نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به همراه انواع سه‌بعدی مرتبط که از طریق شمارش‌گر [ChartType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/charttype/) در دسترس هستند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/charttype/) را در مرجع API نسخه نصب شده خود بررسی کنید.

**آیا می‌توانم یک تصویر رستری از یک نمودار سه‌بعدی برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید یک نمودار را از طریق [chart API](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/get_image/) به تصویر صادر کنید یا [کل اسلاید را رندر کنید](/slides/fa/python-net/convert-powerpoint-to-png/) به قالب‌هایی مانند PNG یا JPEG. این کار زمانی مفید است که به پیش‌نمایش پیکسل‑در‑پیکسل نیاز دارید یا می‌خواهید نمودار را بدون نیاز به پاورپوینت در اسناد، داشبوردها یا صفحات وب جاسازی کنید.

**ساخت و رندر نمودارهای بزرگ سه‌بعدی چقدر کارآمد است؟**

عملکرد به حجم داده و پیچیدگی بصری بستگی دارد. برای بدست آوردن بهترین نتیجه، اثرات سه‌بعدی را به حداقل برسانید، از استفاده از بافت‌های سنگین بر روی دیوارها و نواحی نمودار پرهیز کنید، در صورت امکان تعداد نقاط داده در هر سری را محدود کنید و خروجی را با وضوح و ابعاد مناسب برای نمایش یا چاپ هدف رندر کنید.