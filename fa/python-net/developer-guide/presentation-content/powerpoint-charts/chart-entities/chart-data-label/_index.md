---
title: مدیریت برچسب‌های دادهٔ نمودار در ارائه‌ها با پایتون
linktitle: برچسب داده
type: docs
url: /fa/python-net/chart-data-label/
keywords:
- نمودار
- برچسب داده
- دقت داده
- درصد
- فاصله برچسب
- موقعیت برچسب
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌های دادهٔ نمودار را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق .NET اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **نمای کلی**

برچسب‌های داده در یک نمودار جزئیات مربوط به سری‌های داده یا نقاط دادهٔ فردی را نشان می‌دهند. این برچسب‌ها به خوانندگان کمک می‌کنند تا به‌سرعت سری‌های داده را شناسایی کنند و باعث می‌شوند نمودارها راحت‌تر قابل درک باشند. در Aspose.Slides for Python می‌توانید برچسب‌های داده را برای هر نموداری فعال، سفارشی و فرمت‌بندی کنید—انتخاب اینکه چه چیزی نمایش داده شود (مقدارها، درصدها، نام‌های سری یا دسته)، مکان قرارگیری برچسب‌ها و ظاهر آن‌ها (قلم، فرمت عدد، جداکننده‌ها، خطوط راهنما و غیره). این مقاله به APIهای اصلی و مثال‌هایی می‌پردازد که برای افزودن برچسب‌های واضح و اطلاعاتی به نمودارهای شما لازم است.

## **تنظیم دقت برچسب‌های داده**

برچسب‌های دادهٔ نمودار اغلب مقادیر عددی را نمایش می‌دهند که به دقت ثابت نیاز دارند. این بخش نشان می‌دهد چگونه می‌توانید تعداد رقم‌های اعشاری برچسب‌های داده را در Aspose.Slides با اعمال فرمت عددی مناسب کنترل کنید.

مثال زیر به زبان Python نشان می‌دهد چگونه دقت عددی برچسب‌های دادهٔ نمودار تنظیم می‌شود:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **نمایش درصدها به عنوان برچسب‌ها**

با Aspose.Slides می‌توانید درصدها را به‌عنوان برچسب‌های داده روی نمودارها نمایش دهید. مثال زیر سهم هر نقطه را در دستهٔ مربوطه محاسبه می‌کند و برچسب را طوری قالب‌بندی می‌کند که درصد نمایش داده شود.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # ارائه شامل نمودار را ذخیره کنید.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **نمایش علامت درصد با برچسب‌های داده نمودار**

این بخش نشان می‌دهد چگونه درصدها را در برچسب‌های دادهٔ نمودار نمایش دهید و علامت درصد را اضافه کنید با استفاده از Aspose.Slides. شما می‌آموزید چگونه مقادیر درصدی را برای یک سری کامل یا نقاط خاص فعال کنید (مناسب برای نمودارهای دایره‌ای، دونات و 100٪ انباشته) و چگونه قالب‌بندی را از طریق گزینه‌های برچسب یا یک فرمت عددی سفارشی کنترل کنید.

مثال زیر به زبان Python نشان می‌دهد چگونه علامت درصد را به برچسب دادهٔ یک نمودار اضافه کنید:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:

    # یک ارجاع به اسلاید را بر اساس اندیس دریافت کنید.
    slide = presentation.slides[0]

    # یک نمودار PercentsStackedColumn روی اسلاید ایجاد کنید.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # کتاب‌کار داده‌های نمودار را دریافت کنید.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # یک سری جدید اضافه کنید.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # رنگ پر کردن سری را تنظیم کنید.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # ویژگی‌های قالب‌بندی برچسب‌ها را تنظیم کنید.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # یک سری جدید اضافه کنید.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # نوع پر کردن و رنگ را تنظیم کنید.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # ارائه را ذخیره کنید.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم فاصله برچسب از محور**

این بخش نشان می‌دهد چگونه فاصله بین برچسب‌های داده و محور نمودار را در Aspose.Slides کنترل کنید. تنظیم این فاصله به جلوگیری از هم‌پوشانی کمک می‌کند و قابلیت خواندن در تصاویری که داده‌ها فشرده‌اند را بهبود می‌بخشد.

کد زیر به زبان Python نشان می‌دهد چگونه فاصله برچسب را از محور دسته‌بندی در یک نمودار مبتنی بر محور تنظیم کنید:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:
    # یک ارجاع به اسلاید دریافت کنید.
    slide = presentation.slides[0]

    # یک نمودار ستونی خوشه‌ای روی اسلاید ایجاد کنید.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # فاصله برچسب را از محور دسته (افقی) تنظیم کنید.
    chart.axes.horizontal_axis.label_offset = 500

    # ارائه را ذخیره کنید.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم موقعیت برچسب**

زمانی که نموداری ایجاد می‌کنید که از محور استفاده نمی‌کند، مانند نمودار دایره‌ای، برچسب‌های داده ممکن است نزدیک لبه باشند. در این حالت، موقعیت برچسب را تنظیم کنید تا خطوط راهنما به‌وضوح نمایش داده شوند.

کد زیر به زبان Python نشان می‌دهد چگونه موقعیت برچسب را در یک نمودار دایره‌ای تنظیم کنید:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![موقعیت برچسب تغییر یافته](changed_label_position.png)

## **پرسش‌های متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای پر تراکم جلوگیری کنم؟**

از قرارگیری خودکار برچسب‌ها، خطوط راهنما و کاهش اندازه قلم استفاده کنید؛ در صورت نیاز برخی فیلدها (مثلاً دسته) را مخفی کنید یا برچسب‌ها را فقط برای نقاط بحرانی/کلیدی نمایش دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

قبل از فعال کردن برچسب‌ها نقاط داده را فیلتر کنید و نمایش را برای مقادیر 0، مقادیر منفی یا مقادیر گمشده بر اساس قانونی که تعریف کرده‌اید، خاموش کنید.

**چگونه می‌توانم یک سبک برچسب ثابت هنگام خروجی به PDF/تصویر داشته باشم؟**

قلم‌ها (خانواده، اندازه) را به‌طور صریح تنظیم کنید و اطمینان حاصل کنید که قلم در سمت رندر موجود است تا از استفادهٔ قلم جایگزین جلوگیری شود.