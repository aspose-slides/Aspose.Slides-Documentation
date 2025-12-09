---
title: تخصيص مخططات الفطيرة في العروض التقديمية باستخدام Python
linktitle: مخطط الفطيرة
type: docs
url: /ar/python-net/pie-chart/
keywords:
- مخطط الفطيرة
- إدارة المخطط
- تخصيص المخطط
- خيارات المخطط
- إعدادات المخطط
- خيارات الرسم
- لون الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية إنشاء وتخصيص مخططات الفطيرة باستخدام Python مع Aspose.Slides، وقابلة للتصدير إلى PowerPoint وOpenDocument، مما يعزز سرد البيانات الخاص بك في ثوانٍ."
---

## **خيارات الرسم الثانوي لفطيرة الفطيرة وبار الفطيرة**
Aspose.Slides for Python via .NET الآن يدعم خيارات الرسم الثانوي لمخطط Pie of Pie أو Bar of Pie. في هذا الموضوع، سنستعرض مثالاً يوضح كيفية تحديد هذه الخيارات باستخدام Aspose.Slides. لتحديد الخصائص، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من فئة [العرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. إضافة مخطط إلى الشريحة.
1. تحديد خيارات الرسم الثانوي للمخطط.
1. كتابة العرض إلى القرص.

في المثال أدناه، قمنا بتعيين خصائص مختلفة لمخطط Pie of Pie.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation
with slides.Presentation() as presentation:
    # إضافة مخطط إلى الشريحة
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # تعيين خصائص مختلفة
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # كتابة العرض إلى القرص
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```





## **تعيين ألوان شرائح مخطط الفطيرة تلقائيًا**
Aspose.Slides for Python via .NET توفر واجهة برمجة تطبيقات بسيطة لتعيين ألوان شرائح مخطط الفطيرة تلقائيًا. يطبق رمز العينة الإعدادات المذكورة أعلاه.

1. إنشاء نسخة من فئة Presentation.
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. تعيين عنوان المخطط.
1. تعيين السلسلة الأولى لعرض القيم.
1. تعيين فهرس ورقة بيانات المخطط.
1. الحصول على ورقة بيانات المخطط.
1. حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا.
1. إضافة فئات جديدة.
1. إضافة سلسلة جديدة.

اكتب العرض المعدل إلى ملف PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as presentation:
	# الوصول إلى الشريحة الأولى
	slide = presentation.slides[0]

	# إضافة مخطط ببيانات افتراضية
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# تعيين عنوان المخطط
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# تعيين السلسلة الأولى لعرض القيم
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# تعيين فهرس ورقة بيانات المخطط
	defaultWorksheetIndex = 0

	# الحصول على ورقة عمل بيانات المخطط
	fact = chart.chart_data.chart_data_workbook

	# حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# إضافة فئات جديدة
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# إضافة سلسلة جديدة
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# الآن يتم ملء بيانات السلسلة
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**هل يتم دعم تنويعات 'Pie of Pie' و 'Bar of Pie'؟**

نعم، المكتبة [تدعم](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) مخططًا ثانويًا لمخططات الفطيرة، بما في ذلك نوعي 'Pie of Pie' و 'Bar of Pie'.

**هل يمكنني تصدير المخطط فقط كصورة (على سبيل المثال PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (مثل PNG) دون تصدير العرض بالكامل.