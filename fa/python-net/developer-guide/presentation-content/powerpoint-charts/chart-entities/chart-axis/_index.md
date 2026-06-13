---
title: سفارشی‌سازی محورها در نمودارهای ارائه‌ها با Python
linktitle: محور نمودار
type: docs
url: /fa/python-net/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دست‌کاری محور
- مدیریت محور
- خصوصیات محور
- حداکثر مقدار
- حداقل مقدار
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "کشف کنید چگونه از Aspose.Slides برای Python از طریق .NET برای سفارشی‌سازی محورها در نمودارهای PowerPoint و ارائه‌های OpenDocument برای گزارش‌ها و تجسم‌ها استفاده کنید."
---
## **بررسی کلی**

این مقاله نحوهٔ سفارشی‌سازی محورهای نمودار در Aspose.Slides را توضیح می‌دهد. در این مقاله نشان داده می‌شود چگونه مقادیر واقعی محور را به‌دست آورید، داده‌ها را بین محورها جابجا کنید، محور عمودی یا افقی نمودار خطی را مخفی کنید، نوع محور دسته‌بندی را تغییر دهید، قالب تاریخ برای مقادیر محور دسته‌بندی را تنظیم کنید، عنوان محور را چرخانید، موقعیت محور را تنظیم کنید و برچسب واحد را در محور مقدار نمایش دهید.

## **دریافت بیشترین مقدارها در محور عمودی نمودارها**
Aspose.Slides برای Python از طریق .NET امکان دریافت مقادیر حداقل و حداکثر در یک محور عمودی را فراهم می‌کند. این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. یک نمودار با دادهٔ پیش‌فرض اضافه کنید.
1. مقدار حداکثری واقعی محور را به‌دست آورید.
1. مقدار حداقل واقعی محور را به‌دست آورید.
1. واحد اصلی واقعی محور را به‌دست آورید.
1. واحد فرعی واقعی محور را به‌دست آورید.
1. مقیاس واحد اصلی واقعی محور را به‌دست آورید.
1. مقیاس واحد فرعی واقعی محور را به‌دست آورید.

این کد نمونه—یک پیاده‌سازی از مراحل بالا—نحوهٔ دریافت مقادیر مورد نیاز را در Python نشان می‌دهد:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# ارائه را ذخیره می‌کند
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **جابه‌جایی داده‌ها بین محورها**
Aspose.Slides به شما اجازه می‌دهد به‌سرعت داده‌ها را بین محورها جابه‌جا کنید—داده‌های نمایش‌داده‌شده در محور عمودی (محور y) به محور افقی (محور x) منتقل می‌شوند و بالعکس.

این کد Python نشان می‌دهد چطور عملیات جابه‌جایی داده‌ها بین محورها را در یک نمودار انجام دهید:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# ارائه خالی ایجاد می‌کند
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    # سطرها و ستون‌ها را جابجا می‌کند
    chart.chart_data.switch_row_column()
            
    # ارائه را ذخیره می‌کند
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **غیرفعال‌سازی محور عمودی برای نمودارهای خطی**

این کد Python نشان می‌دهد چگونه محور عمودی یک نمودار خطی را مخفی کنید:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **غیرفعال‌سازی محور افقی برای نمودارهای خطی**

این کد نشان می‌دهد چگونه محور افقی یک نمودار خطی را مخفی کنید:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **تغییر محور دسته‌بندی**

با استفاده از ویژگی **CategoryAxisType** می‌توانید نوع محور دسته‌بندی مورد نظر خود (**date** یا **text**) را مشخص کنید. این کد در Python عملیات را نشان می‌دهد:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم قالب تاریخ برای مقدار محور دسته‌بندی**
Aspose.Slides برای Python از طریق .NET به شما امکان تنظیم قالب تاریخ برای مقدار محور دسته‌بندی را می‌دهد. عبارت زیر این عملیات را در کد Python نشان می‌دهد:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم زاویهٔ چرخش برای عنوان محور نمودار**
Aspose.Slides برای Python از طریق .NET به شما اجازه می‌دهد زاویهٔ چرخش برای عنوان محور نمودار را تنظیم کنید. این کد Python عملیات را نشان می‌دهد:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم موقعیت محور در یک محور دسته‌بندی یا مقدار**
Aspose.Slides برای Python از طریق .NET به شما امکان تنظیم موقعیت محور در یک محور دسته‌بندی یا مقدار را می‌دهد. این کد Python نشان می‌دهد چطور این کار را انجام دهید:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **فعال‌سازی نمایش برچسب واحد در محور مقدار نمودار**
Aspose.Slides برای Python از طریق .NET به شما امکان پیکربندی یک نمودار برای نمایش برچسب واحد در محور مقدار نمودار را می‌دهد. این کد Python عملیات را نشان می‌دهد:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر (axis crossing) را تنظیم کنم؟**

محورها یک [crossing setting](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/axis/cross_type/) دارند: می‌توانید انتخاب کنید که در صفر، در حداکثر دسته/مقدار یا در یک مقدار عددی خاص تقاطع کنند. این گزینه برای جابه‌جا کردن محور X به بالا یا پایین یا برای برجسته کردن یک خط پایه مفید است.

**چگونه برچسب‌های تیک را نسبت به محور موقعیت دهی کنم (در کنار، خارج، داخل)؟**

[label position](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/axis/major_tick_mark/) را بر روی "cross"، "outside" یا "inside" تنظیم کنید. این تنظیم بر خوانایی اثر می‌گذارد و به صرفه‌جویی در فضا، به‌ویژه در نمودارهای کوچک، کمک می‌کند.