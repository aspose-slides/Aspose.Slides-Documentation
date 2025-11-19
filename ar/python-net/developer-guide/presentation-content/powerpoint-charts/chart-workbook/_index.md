---
title: "إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام بايثون"
linktitle: "دفتر عمل المخطط"
type: docs
weight: 70
url: /ar/python-net/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- تسمية البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- باوربوينت
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "اكتشف Aspose.Slides لبايثون عبر .NET: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات العرض التقديمي الخاص بك."
---

## **تعيين بيانات المخطط من دفتر عمل**

تقدم Aspose.Slides طرقًا لقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات المخطط التي تم تحريرها باستخدام Aspose.Cells). **ملاحظة:** يجب تنظيم بيانات المخطط بنفس الطريقة أو أن تكون ذات بنية مشابهة للمصدر.

الكود التالي بلغة Python يوضح عملية نموذجية:
```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```


## **تعيين خلية دفتر العمل كملصق بيانات المخطط**

في بعض الأحيان تحتاج إلى ملصقات مخطط تُستمد مباشرةً من خلايا دفتر البيانات الأساسي. يتيح لك Aspose.Slides ربط ملصقات البيانات بخلايا دفتر عمل محددة بحيث يعكس نص الملصق دائمًا قيمة الخلية. يوضح المثال أدناه كيفية تمكين الملصقات المستمدة من القيم في الخلايا وتوجيه الملصقات المحددة إلى خلايا مخصصة في دفتر عمل المخطط.

1. إنشاء مثيل لفئة [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة بواسطة الفهرس.
1. إضافة مخطط فقاعي مع بيانات مثال.
1. الوصول إلى سلسلة المخطط.
1. استخدام خلية دفتر العمل كملصق بيانات.
1. حفظ العرض التقديمي.

الكود التالي بلغة Python يوضح كيفية تعيين خلية دفتر عمل كملصق بيانات المخطط:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

# إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```


## **إدارة ورقات العمل**

الكود التالي بلغة Python يوضح كيفية استخدام الخاصية `worksheets` للوصول إلى مجموعة ورقات العمل:
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```


## **تحديد نوع مصدر البيانات**

الكود التالي بلغة Python يوضح كيفية تحديد نوع مصدر البيانات:
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **دفاتر عمل خارجية**

تدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **تعيين دفاتر عمل خارجية**

باستخدام طريقة [ChartData.set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) يمكنك إسناد دفتر عمل خارجي إلى مخطط كمصدر بيانات له. يمكن لهذه الطريقة أيضًا تحديث المسار إلى دفتر العمل الخارجي إذا تم نقل الملف.

على الرغم من أنك لا تستطيع تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، يمكنك لا يزال استخدام هذه الدفاتر كمصادر بيانات خارجية. إذا قمت بتوفير مسار نسبي لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

الكود التالي بلغة Python يوضح كيفية تعيين دفتر عمل خارجي:
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```


معامل `update_chart_data` في طريقة [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) يحدد ما إذا كان سيتم تحميل دفتر Excel.

- عند ضبط `update_chart_data` على `False`، يتم تحديث مسار دفتر العمل فقط؛ لا يتم تحميل أو تحديث بيانات المخطط من دفتر العمل المستهدف. استخدم هذا الإعداد عندما لا يكون دفتر العمل المستهدف موجودًا أو غير متاح.
- عند ضبط `update_chart_data` على `True`، يتم تحميل بيانات المخطط وتحديثها من دفتر العمل المستهدف.

### **إنشاء دفاتر عمل خارجية**

باستخدام طريقتي [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى خارجي.

الكود التالي بلغة Python يوضح عملية إنشاء دفتر عمل خارجي:
```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```


### **الحصول على مسار دفتر العمل لمصدر البيانات الخارجي لمخطط**

في بعض الأحيان تكون بيانات المخطط مرتبطة بدفتر Excel خارجي بدلاً من البيانات المدمجة في العرض التقديمي. باستخدام Aspose.Slides يمكنك فحص مصدر بيانات المخطط، وإذا كان مصدرًا خارجيًا، قراءة المسار الكامل للدفتر.

1. إنشاء مثيل لفئة [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة بواسطة الفهرس.
1. الحصول على مرجع إلى شكل المخطط.
1. الحصول على المصدر ([ChartDataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/)) الذي يمثل مصدر بيانات المخطط.
1. التحقق مما إذا كان نوع المصدر يطابق نوع مصدر دفتر العمل الخارجي.

الكود التالي بلغة Python يوضح العملية:
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```


### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تحرر بها البيانات في دفاتر العمل الداخلية. إذا تعذر تحميل دفتر عمل خارجي، يتم إثارة استثناء.
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أو مدمج؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) و[مسار دفتر العمل الخارجي](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية لدفاتر العمل الخارجية، وكيف تُخزن؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مفيد لنقلية المشروع؛ ومع ذلك، يجب أن تكون على علم بأن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد شبكية/مشاركة؟**

نعم، يمكن استخدام هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم تعديل دفاتر العمل البعيدة مباشرةً من Aspose.Slides؛ يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي عند حفظ العرض التقديمي.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند الربط. النهج الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](/cells/python-net/)) والربط بتلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن ارتباطه الخاص. إذا أشارت جميعها إلى نفس الملف، ستنعكس أي تحديثات لهذا الملف في كل مخطط في المرة التالية التي يتم فيها تحميل البيانات.