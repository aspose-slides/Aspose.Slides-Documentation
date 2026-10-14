---
title: سفارشی‌سازی نمودارهای دایره‌ای در ارائه‌ها با پایتون
linktitle: نمودار دایره‌ای
type: docs
url: /fa/python-net/pie-chart/
keywords:
- نمودار دایره‌ای
- مدیریت نمودار
- سفارشی‌سازی نمودار
- گزینه‌های نمودار
- تنظیمات نمودار
- گزینه‌های ترسیم
- رنگ برش
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "نمودارهای دایره‌ای را در پایتون با Aspose.Slides ایجاد و سفارشی کنید. نمودارهای ثانویه را پیکربندی کنید، برچسب‌های داده را نمایش دهید و رنگ‌های خودکار برش‌ها را در PowerPoint اعمال کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با نمودارهای دایره‌ای در Aspose.Slides کار کنید. این مقاله نشان می‌دهد که چگونه گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie را پیکربندی کنید و چگونه رنگ‌آمیزی خودکار برش‌ها را برای یک نمودار دایره‌ای استاندارد فعال کنید.

مثال‌ها بر روی وظایف سفارشی‌سازی نمودار مانند افزودن نمودار به یک اسلاید، تنظیم سری و ویژگی‌های برچسب، جایگزینی داده‌های پیش‌فرض نمودار با دسته‌ها و مقادیر سفارشی، و ذخیره ارائه به‌روز شده متمرکز هستند.

## **گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie**

Aspose.Slides for Python via .NET از گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie پشتیبانی می‌کند. این گزینه‌ها اندازه نمودار ثانویه و نحوه تقسیم نقاط داده بین دو نمودار را کنترل می‌کنند.

مثال زیر یک نمودار Pie of Pie در یک ارائه جدید ایجاد می‌کند و مقادیر نقاط داده را به‌صورت برچسب نمایش می‌دهد. ویژگی [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) اندازه نمودار ثانویه را به 149٪ از نمودار اصلی تنظیم می‌کند. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) تقسیم بر پایه درصد را انتخاب می‌کند و [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) آستانه را روی 53٪ تنظیم می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # نمایش مقادیر و پیکربندی نمودار ثانویه.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **انتخاب دسته‌ها برای نمودار ثانویه**

از تقسیم سفارشی استفاده کنید زمانی که می‌خواهید دسته‌های خاصی را در نمودار ثانویه گروه‌بندی کنید بدون توجه به مقادیر درصدی آنها. به عنوان مثال، یک گزارش فروش ممکن است Online و Events را کنار هم نشان دهد تا خوانندگان بتوانند این دو کانال را مقایسه کنند، حتی اگر هرکدام 35٪ و 10٪ از کل فروش را تشکیل دهند.

[pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) را روی [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) تنظیم کنید و نقاط را از طریق [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/) انتخاب کنید. متد [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) این مجموعه می‌تواند یا یک ایندکس صفر‑پایه در سری یا یک شیء نقطه داده را بپذیرد. در این مثال، ایندکس 1 Online را انتخاب می‌کند و نقطه‌ای با ایندکس 3 Events را. Partners نیز به‌صورت موقت اضافه می‌شود، سپس با استفاده از [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/) حذف می‌شود.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # جایگزین کردن داده‌های پیش‌فرض با فروش بر اساس کانال.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # انتخاب Online با ایندکس صفر‑پایه و Events با شیء نقطه داده.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # حذف Partners از انتخاب بدون حذف داده منبع آن.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) و Events (10) به‌صورت برش‌های جداگانه در نمودار ثانویه ظاهر می‌شوند. در نمودار اصلی، آن‌ها توسط یک برش ترکیبی با مقدار 45 نشان داده می‌شوند، همراه با Retail (40) و Partners (15). حذف Partners از انتخاب سفارشی آن را در نمودار اصلی نگه می‌دارد؛ این عمل دسته یا مقدار آن را از داده منبع نمودار حذف نمی‌کند.

تصویر زیر ارائه ذخیره‌شده را در PowerPoint نشان می‌دهد:

![نمودار Pie of Pie با Online و Events در نمودار ثانویه و مقدار ترکیبی آنها 45 در نمودار اصلی](pie_of_pie_custom.png)

## **تنظیم رنگ خودکار برش‌های نمودار دایره‌ای**

Aspose.Slides for Python via .NET می‌تواند به‌صورت خودکار رنگ‌های متفاوتی به برش‌های نمودار دایره‌ای اختصاص دهد. مثال زیر یک نمودار دایره‌ای با عنوان مرکزی ایجاد می‌کند و داده‌های پیش‌فرض را با سه دسته فصلی و مقادیرشان جایگزین می‌کند. ویژگی [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) مقادیر 20، 50 و 30 را به‌عنوان برچسب نمایش می‌دهد، در حالی که [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) رنگ متمایزی برای هر برش فعال می‌کند.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # افزودن عنوان نمودار در مرکز.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # جایگزین کردن داده‌های پیش‌فرض با استفاده از اولین برگه کاری.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # نمایش مقادیر و اختصاص رنگ‌های متفاوت به برش‌ها.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا انواع Pie of Pie و Bar of Pie پشتیبانی می‌شوند؟**

بله، کتابخانه [پشتیبانی می‌کند](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) از نمودار ثانویه برای نمودارهای دایره‌ای، شامل انواع Pie of Pie و Bar of Pie.

**آیا می‌توانم فقط نمودار را به‌صورت تصویر (مثلاً PNG) صادرات کنم؟**

بله، می‌توانید [نمودار را به‌عنوان تصویر صادر کنید](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (مانند PNG) بدون اینکه کل ارائه را صادر کنید.