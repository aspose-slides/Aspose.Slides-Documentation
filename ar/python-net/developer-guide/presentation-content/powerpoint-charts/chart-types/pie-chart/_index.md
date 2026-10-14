---
title: "تخصيص المخططات الدائرية في العروض التقديمية باستخدام بايثون"
linktitle: "مخطط دائري"
type: docs
url: /ar/python-net/pie-chart/
keywords:
- "مخطط دائري"
- "إدارة المخطط"
- "تخصيص المخطط"
- "خيارات المخطط"
- "إعدادات المخطط"
- "خيارات الرسم"
- "لون الشريحة"
- "PowerPoint"
- "عرض تقديمي"
- "Python"
- "Aspose.Slides"
description: "إنشاء وتخصيص المخططات الدائرية في بايثون باستخدام Aspose.Slides. تكوين المخططات الثانوية، عرض تسميات البيانات، وتطبيق ألوان الشرائح التلقائية في PowerPoint."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع المخططات الدائرية في Aspose.Slides. تعرض كيفية تكوين خيارات المخطط الثانوي لمخططي Pie of Pie و Bar of Pie، وكيفية تمكين تلوين الشرائح تلقائيًا لمخطط دائري قياسي.

تركز الأمثلة على مهام تخصيص المخطط مثل إضافة مخطط إلى شريحة، ضبط إعدادات السلاسل والملصقات، استبدال بيانات المخطط الافتراضية بفئات وقيم مخصصة، وحفظ العرض التقديمي المحدث.

## **خيارات المخطط الثانوي لمخططي Pie of Pie و Bar of Pie**

يدعم Aspose.Slides for Python via .NET خيارات المخطط الثانوي لمخططي Pie of Pie و Bar of Pie. تتحكم هذه الخيارات في حجم المخطط الثانوي وكيفية تقسيم نقاط البيانات بين المخططين.

المثال التالي ينشئ مخطط Pie of Pie في عرض تقديمي جديد ويظهر قيم نقاط البيانات كملصقات. الخاصية [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) تحدد حجم المخطط الثانوي بنسبة 149 ٪ من المخطط الرئيسي. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) يختار التقسيم القائم على النسبة المئوية، و[pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) يحدد العتبة عند 53 ٪.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # عرض القيم وتكوين المخطط الثانوي.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **تحديد الفئات للمخطط الثانوي**

استخدم التقسيم المخصص عندما تريد تجميع فئات معينة في المخطط الثانوي بغض النظر عن قيم النسبة المئوية الخاصة بها. على سبيل المثال، قد يعرض تقرير المبيعات فئتي Online وEvents معًا حتى يتمكن القراء من مقارنة هذين القنَين، رغم أنهما تمثلان 35 ٪ و10 ٪ من إجمالي المبيعات.

عيّن [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) إلى [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) واختر النقاط عبر [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). طريقة [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) في المجموعة تقبل إما فهرسًا بصفر أساس في السلسلة أو كائن نقطة بيانات. في هذا المثال، الفهرس 1 يختار Online، والفهرس 3 يختار Events. يتم إضافة Partners مؤقتًا، ثم استثناؤها باستخدام [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # استبدال البيانات الافتراضية بالمبيعات حسب القناة.
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

    # اختيار Online حسب فهرسه الصفري و Events حسب كائن نقطة البيانات.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # استبعاد Partners من الاختيار دون حذف بيانات المصدر الخاصة به.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

تظهر Online (35) وEvents (10) كشرائح منفصلة في المخطط الثانوي. في المخطط الأساسي، يتم تمثيلهما بشريحة موحدة بقيمة 45، إلى جانب Retail (40) وPartners (15). إزالة Partners من الاختيار المخصص يبقيها في المخطط الأساسي؛ ولا تُزيل الفئة أو قيمتها من بيانات المصدر للمخطط.

الصورة التالية تُظهر العرض التقديمي المحفوظ في PowerPoint:

![مخطط Pie of Pie مع Online وEvents في المخطط الثانوي وقيمتهما المجمعة 45 في المخطط الأساسي](pie_of_pie_custom.png)

## **تعيين ألوان شرائح المخطط الدائري تلقائيًا**

يمكن لـ Aspose.Slides for Python via .NET تعيين ألوان مختلفة تلقائيًا لشرائح المخطط الدائري. المثال التالي ينشئ مخططًا دائريًا بعنوان مركزي ويستبدل البيانات الافتراضية بثلاث فئات ربع سنوية وقيمها. الخاصية [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) تعرض القيم 20 و50 و30 كملصقات، بينما تُفعّل الخاصية [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) لونًا مميزًا لكل شريحة.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # إضافة عنوان مخطط مركزي.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # استبدال البيانات الافتراضية باستخدام ورقة العمل الأولى.
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

    # عرض القيم وتعيين ألوان مختلفة للشرائح.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يتم دعم تنويعات Pie of Pie و Bar of Pie؟**

نعم، المكتبة [supports](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) مخططًا ثانويًا للمخططات الدائرية، بما في ذلك نوعي Pie of Pie و Bar of Pie.

**هل يمكنني تصدير المخطط فقط كصورة (مثلاً PNG)؟**

نعم، يمكنك [export the chart itself as an image](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (مثل PNG) دون تصدير العرض التقديمي بأكمله.