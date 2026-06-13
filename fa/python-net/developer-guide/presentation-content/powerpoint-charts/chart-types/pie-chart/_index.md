---
title: سفارشی‌سازی نمودارهای پای در ارائه‌ها با پایتون
linktitle: نمودار پای
type: docs
url: /fa/python-net/pie-chart/
keywords:
- نمودار پای
- مدیریت نمودار
- سفارشی‌سازی نمودار
- گزینه‌های نمودار
- تنظیمات نمودار
- گزینه‌های ترسیم
- رنگ قطعه
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "بیاموزید چگونه نمودارهای پای را در پایتون با Aspose.Slides ایجاد و سفارشی کنید، قابل صادرات به PowerPoint و OpenDocument، و در چند ثانیه روایت داده‌های خود را تقویت کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با نمودارهای پای در Aspose.Slides کار کنیم. نحوه پیکربندی گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie و همچنین فعال‌سازی رنگ‌آمیزی خودکار قطعات برای یک نمودار پای استاندارد نشان داده می‌شود.

مثال‌ها بر گام‌های عملی سفارشی‌سازی نمودار متمرکز هستند، مانند افزودن نمودار به یک اسلاید، تنظیم سری‌ها و برچسب‌ها، جایگزینی داده‌های پیش‌فرض نمودار با دسته‌ها و مقادیر سفارشی، و ذخیره ارائه به‌روز شده.

## **گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie**
Aspose.Slides برای Python از طریق .NET اکنون گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie یا Bar of Pie را پشتیبانی می‌کند. در این بخش، با مثال نشان می‌دهیم چگونه این گزینه‌ها را با استفاده از Aspose.Slides مشخص کنیم. برای مشخص کردن ویژگی‌ها، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از شی کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. نمودار را به اسلاید اضافه کنید.  
3. گزینه‌های نمودار ثانویه را مشخص کنید.  
4. ارائه را روی دیسک ذخیره کنید.  

در مثال زیر، ویژگی‌های مختلفی از نمودار Pie of Pie را تنظیم کرده‌ایم.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید
with slides.Presentation() as presentation:
    # افزودن نمودار به اسلاید
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # تنظیم ویژگی‌های مختلف
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # ذخیره ارائه روی دیسک
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم خودکار رنگ قطعات نمودار پای**
Aspose.Slides برای Python از طریق .NET یک API ساده برای تنظیم رنگ‌های خودکار قطعات نمودار پای فراهم می‌کند. کد نمونه تنظیم ویژگی‌های مذکور را اعمال می‌کند.

1. یک نمونه از کلاس Presentation ایجاد کنید.  
2. به اولین اسلاید دسترسی پیدا کنید.  
3. نمودار را با داده پیش‌فرض اضافه کنید.  
4. عنوان نمودار را تنظیم کنید.  
5. سری اول را برای نمایش مقادیر تنظیم کنید.  
6. نمایه‌ی برگه داده‌های نمودار را تنظیم کنید.  
7. دریافت برگه کاری داده‌های نمودار.  
8. سری‌ها و دسته‌های پیش‌فرض ایجاد شده را حذف کنید.  
9. دسته‌های جدید اضافه کنید.  
10. سری‌های جدید اضافه کنید.  

ارائهٔ اصلاح‌شده را در یک فایل PPTX ذخیره کنید.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# ایجاد یک نمونه از کلاس Presentation که فایل PPTX را نشان می‌دهد
with slides.Presentation() as presentation:
	# دسترسی به اولین اسلاید
	slide = presentation.slides[0]

	# افزودن نمودار با داده‌های پیش‌فرض
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# تنظیم عنوان نمودار
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# تنظیم سری اول برای نمایش مقادیر
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# تنظیم شاخص برگه داده‌های نمودار
	defaultWorksheetIndex = 0

	# دریافت برگه کاری داده‌های نمودار
	fact = chart.chart_data.chart_data_workbook

	# حذف سری‌ها و دسته‌های پیش‌فرض تولید شده
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# افزودن دسته‌های جدید
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# افزودن سری جدید
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# حالا پرکردن داده‌های سری
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤال‌های متداول**

**آیا انواع 'Pie of Pie' و 'Bar of Pie' پشتیبانی می‌شوند؟**

بله، کتابخانه از نمودار ثانویه برای نمودارهای پای، شامل انواع 'Pie of Pie' و 'Bar of Pie' پشتیبانی می‌کند.

**آیا می‌توانم فقط نمودار را به‌ عنوان تصویر (مثلاً PNG) صادرات کنم؟**

بله، می‌توانید خود نمودار را به‌ عنوان تصویر (مانند PNG) بدون کل ارائه صادر کنید.