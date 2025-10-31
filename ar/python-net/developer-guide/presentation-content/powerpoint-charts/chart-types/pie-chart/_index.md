---
title: تخصيص المخططات الدائرية في العروض التقديمية باستخدام بايثون
linktitle: مخطط دائري
type: docs
url: /ar/python-net/pie-chart/
keywords:
- مخطط دائري
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
description: "تعرّف على كيفية إنشاء وتخصيص المخططات الدائرية في بايثون باستخدام Aspose.Slides، القابلة للتصدير إلى PowerPoint وOpenDocument، مما يعزز سرد البيانات الخاصة بك في ثوانٍ."
---

## **خيارات الرسم الثانوية للمخطط الدائري داخل مخطط دائري ومخطط شريطي داخل مخطط دائري**
Aspose.Slides for Python via .NET الآن يدعم خيارات الرسم الثانوية للمخطط الدائري داخل مخطط دائري أو مخطط شريطي داخل مخطط دائري. في هذا الموضوع، سنرى مع مثال كيف نحدد هذه الخيارات باستخدام Aspose.Slides. لتحديد الخصائص، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. إضافة مخطط إلى الشريحة.
3. تحديد خيارات الرسم الثانوي للمخطط.
4. حفظ العرض التقديمي إلى القرص.

في المثال المرفق أدناه، قمنا بتعيين خصائص مختلفة للمخطط الدائري داخل مخطط دائري.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء نسخة من فئة Presentation
with slides.Presentation() as presentation:
    # إضافة مخطط إلى الشريحة
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # تعيين خصائص مختلفة
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # حفظ العرض التقديمي إلى القرص
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```




## **تعيين ألوان شرائح المخطط الدائري تلقائيًا**
Aspose.Slides for Python via .NET يوفر واجهة برمجة تطبيقات بسيطة لتعيين ألوان شرائح المخطط الدائري تلقائيًا. يطبق الكود النموذجي إعداد الخصائص المذكورة أعلاه.

1. إنشاء نسخة من فئة Presentation.
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. تعيين عنوان المخطط.
5. تعيين السلسلة الأولى لتظهر القيم.
6. تعيين فهرس ورقة بيانات المخطط.
7. الحصول على ورقة بيانات المخطط.
8. حذف السلاسل والفئات المولدة افتراضيًا.
9. إضافة فئات جديدة.
10. إضافة سلاسل جديدة.

احفظ العرض التقديمي المعدل إلى ملف PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء نسخة من فئة Presentation التي تمثل ملف PPTX
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

	# تعيين السلسلة الأولى لتظهر القيم
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# تعيين فهرس ورقة بيانات المخطط
	defaultWorksheetIndex = 0

	# الحصول على ورقة بيانات المخطط
	fact = chart.chart_data.chart_data_workbook

	# حذف السلاسل والفئات المولدة افتراضيًا
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# إضافة فئات جديدة
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# إضافة سلاسل جديدة
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# الآن تعبئة بيانات السلسلة
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**هل يتم دعم تنويعات 'Pie of Pie' و 'Bar of Pie'؟**

نعم، المكتبة [تدعم](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) رسمًا ثانويًا للمخططات الدائرية، بما في ذلك النوعين 'Pie of Pie' و 'Bar of Pie'.

**هل يمكنني تصدير المخطط نفسه كصورة (مثال، PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (مثل PNG) دون الحاجة إلى تصدير العرض التقديمي بالكامل.