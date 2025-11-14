---
title: مخطط دائري
type: docs
url: /ar/python-net/pie-chart/
keywords: "مخطط دائري، خيارات المخطط، ألوان الشرائح، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "خيارات مخطط دائري وألوان الشرائح في عرض PowerPoint باستخدام بايثون"
---

## **خيارات المخطط الثانية لمخطط دائري من دائري ومخطط دائري من شريطي**
يدعم Aspose.Slides لبايثون عبر .NET الآن خيارات المخطط الثانية لمخطط دائري من دائري أو مخطط دائري من شريطي. في هذا الموضوع، سنرى مع مثال كيفية تحديد هذه الخيارات باستخدام Aspose.Slides. من أجل تحديد الخصائص، يرجى اتباع الخطوات أدناه:

1. أنشئ كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. أضف المخطط إلى الشريحة.
1. حدد خيارات المخطط الثانية للمخطط.
1. احفظ العرض على القرص.

في المثال المقدم أدناه، قمنا بتعيين خصائص مختلفة لمخطط دائري من دائري.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:
    # Add chart on slide
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Set different properties
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Write presentation to disk
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```


## **ضبط ألوان شرائح المخطط الدائري التلقائية**
يوفر Aspose.Slides لبايثون عبر .NET واجهة برمجة تطبيقات بسيطة لضبط ألوان شرائح المخطط الدائري التلقائية. يقوم الرمز التجريبي بتطبيق إعداد الخصائص المذكورة أعلاه.

1. أنشئ كائن من فئة Presentation.
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط مع البيانات الافتراضية.
1. تعيين عنوان المخطط.
1. تعيين السلسلة الأولى لعرض القيم.
1. تعيين فهرس ورقة بيانات المخطط.
1. الحصول على ورقة بيانات المخطط.
1. حذف السلاسل والفئات المُولَّدة تلقائيًا.
1. إضافة فئات جديدة.
1. إضافة سلاسل جديدة.

احفظ العرض المعدل في ملف PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Presentation class that represents PPTX file
with slides.Presentation() as presentation:
	# Access first slide
	slide = presentation.slides[0]

	# Add chart with default data
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Setting chart Title
	chart.chart_title.add_text_frame_for_overriding("عنوان عينة")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Set first series to Show Values
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Setting the index of chart data sheet
	defaultWorksheetIndex = 0

	# Getting the chart data worksheet
	fact = chart.chart_data.chart_data_workbook

	# Delete default generated series and categories
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Adding new categories
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "الربع الأول"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "الربع الثاني"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "الربع الثالث"))

	# Adding new series
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "السلسلة 1"), chart.type)

	# Now populating series data
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```