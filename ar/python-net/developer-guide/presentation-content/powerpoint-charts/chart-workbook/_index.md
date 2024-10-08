---
title: دفتر عمل الرسم البياني
type: docs
weight: 70
url: /ar/python-net/chart-workbook/
keywords: "دفتر عمل الرسم البياني، بيانات الرسم البياني، عرض تقديمي باور بوينت، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "دفتر عمل الرسم البياني في عرض تقديمي باور بوينت في بايثون"
---

## **تعيين بيانات الرسم البياني من دفتر العمل**

يوفر Aspose.Slides بعض الطرق التي تتيح لك قراءة وكتابة دفاتر عمل بيانات الرسم البياني (التي تحتوي على بيانات الرسم البياني المعدلة باستخدام Aspose.Cells). **ملاحظة** أن بيانات الرسم البياني يجب أن تكون منظمة بنفس الطريقة أو يجب أن تحتوي على بنية مشابهة للمصدر.

يوضح هذا الكود بلغة بايثون عملية نموذجية:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# يقوم بإنشاء فئة عرض تقديمي تمثل ملف عرض تقديمي
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series

    series[0].labels.default_data_label_format.show_label_value_from_cell = True

    wb = chart.chart_data.chart_data_workbook

    series[0].labels[0].value_from_cell = wb.get_cell(0, "A10", "قيمة خلية التصنيف 0")
    series[0].labels[1].value_from_cell = wb.get_cell(0, "A11", "قيمة خلية التصنيف 1")
    series[0].labels[2].value_from_cell = wb.get_cell(0, "A12", "قيمة خلية التصنيف 2")

    pres.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين خلية دفتر العمل كعلامة بيانات الرسم البياني**

1. إنشاء مثيل من فئة [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) .
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة رسم بياني من نوع الفقاعة ببعض البيانات.
1. الوصول إلى سلسلة الرسم البياني.
1. تعيين خلية دفتر العمل كعلامة بيانات.
1. حفظ العرض التقديمي.

يوضح هذا الكود بلغة بايثون كيفية تعيين خلية دفتر العمل كعلامة بيانات لرسم بياني: xxx

```python

```

## **إدارة أوراق العمل**

يوضح هذا الكود بلغة بايثون عملية حيث يتم استخدام خاصية `worksheets` للوصول إلى مجموعة أوراق العمل:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
   chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
   wb =  chart.chart_data.chart_data_workbook
   for i in range(len(wb.worksheets)):
      print(wb.worksheets[i].name)
```

## **تحديد نوع مصدر البيانات**

يوضح هذا الكود بلغة بايثون كيفية تحديد نوع لمصدر البيانات: 

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    val = chart.chart_data.series[0].name

    val.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    val.data = "سلسلة حرفية"

    val = chart.chart_data.series[0].name
    val.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "خلية جديدة")

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **دفتر العمل الخارجي**

{{% alert color="primary" %}} 
في [Aspose.Slides لـ .NET 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/)، قمنا بتنفيذ دعم دفاتر العمل الخارجية كمصدر بيانات للرسم البياني.
{{% /alert %}} 

### **إنشاء دفتر عمل خارجي**

باستخدام بعض الطرق من **`IChartData`**، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو جعل دفتر العمل الداخلي خارجي.

يوضح هذا الكود بلغة بايثون عملية إنشاء دفتر العمل الخارجي:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:

    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.chart_data_workbook.clear(0)

    chart.chart_data.set_external_workbook(path + "externalWorkbook.xlsx")

    chart.chart_data.set_range("Sheet1!$A$2:$B$5")
    series = chart.chart_data.series[0]
    series.parent_series_group.is_color_varied = True
    pres.save("response2.pptx", slides.export.SaveFormat.PPTX)
```

### **تعيين دفتر عمل خارجي**

باستخدام طريقة **`chartData.set_external_workbook`**، يمكنك تعيين دفتر عمل خارجي كرسم بياني كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث المسار إلى دفتر العمل الخارجي (إذا تم نقل الأخير).

بينما لا يمكنك تعديل البيانات في دفاتر العمل المخزنة في مواقع أو موارد بعيدة، لا يزال بإمكانك استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير المسار النسبي لدفتر العمل الخارجي، فسيتم تحويله تلقائيًا إلى مسار كامل.

يوضح هذا الكود بلغة بايثون كيفية تعيين دفتر عمل خارجي:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

# المسار إلى دليل الوثائق.
with slides.Presentation() as pres:

    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data
                    
    chartData.set_external_workbook(path + "externalWorkbook.xlsx")
                  

    chartData.series.add(chartData.chart_data_workbook.get_cell(0, "B1"), charts.ChartType.PIE)
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B2"))
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B3"))
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B4"))

    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A2"))
    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A3"))
    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A4"))
    pres.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

المعلمة `chart_data` (تحت طريقة `set_external_workbook`) تُستخدم لتحديد ما إذا كان سيتم تحميل دفتر العمل excel أم لا. 

* عندما يتم تعيين قيمة `chart_data` إلى `false`، يتم تحديث مسار دفتر العمل فقط—لن يتم تحميل بيانات الرسم البياني أو تحديثها من دفتر العمل المستهدف. قد ترغب في استخدام هذا الإعداد في حالة عدم وجود دفتر العمل المستهدف أو عدم توفره. 
* عندما يتم تعيين قيمة `chart_data` إلى `true`، يتم تحديث بيانات الرسم البياني من دفتر العمل المستهدف.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data

    chartData.set_external_workbook("http://path/doesnt/exists", False)

    pres.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **الحصول على مسار مصدر بيانات الرسم البياني الخارجي**

1. إنشاء مثيل من فئة [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) .
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إنشاء كائن لشكل الرسم البياني.
1. إنشاء كائن لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات الرسم البياني.
1. تحديد الشرط المناسب بناءً على كون نوع المصدر هو نفسه نوع مصدر بيانات دفتر العمل الخارجي.

يوضح هذا الكود بلغة بايثون العملية:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("response2.pptx") as pres:
    chart = pres.slides[0].shapes[0]
    sourceType = chart.chart_data.data_source_type
    if sourceType == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **تعديل بيانات الرسم البياني**

يمكنك تعديل البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تجري بها تغييرات على محتويات دفاتر العمل الداخلية. عند عدم إمكانية تحميل دفتر العمل الخارجي، يتم طرح استثناء.

هذا الكود بلغة بايثون هو تنفيذ للعملية الموصوفة:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "presentation.pptx") as pres:
    pres.slides[0].shapes[0].chart_data.series[0].data_points[0].value.as_cell.value = 100
    pres.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
```