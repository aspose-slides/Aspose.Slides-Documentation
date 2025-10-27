---
title: إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام Python
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/python-net/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- تسمية البيانات
- ورقة عمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف Aspose.Slides للـ Python عبر .NET: إدارة دفاتر عمل المخططات في صيغ PowerPoint و OpenDocument بسهولة لتبسيط بيانات عرضك التقديمي."
---

## **تعيين بيانات المخطط من دفتر عمل**

توفر Aspose.Slides طرقًا لقراءة وكتابة دفاتر بيانات المخططات (التي تحتوي على بيانات المخطط المعدلة باستخدام Aspose.Cells). **ملاحظة:** يجب تنظيم بيانات المخطط بنفس الطريقة أو أن يكون لديها بنية مشابهة للمصدر.

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

## **تعيين خلية دفتر العمل ك تسمية بيانات مخطط**

في بعض الأحيان تحتاج إلى تسميات المخطط التي تأتي مباشرةً من خلايا دفتر البيانات الأساسي. تتيح لك Aspose.Slides ربط تسميات البيانات بخلايا دفتر محددة بحيث يعكس نص التسمية دائمًا قيمة الخلية. يوضح المثال أدناه كيفية تمكين تسميات القيم من الخلية وتوجيه التسميات المختارة إلى خلايا مخصصة في دفتر المخطط.

1. إنشاء مثيل من الفئة [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة حسب الفهرس.
3. إضافة مخطط فقاعة ببيانات نموذجية.
4. الوصول إلى سلسلة المخطط.
5. استخدام خلية دفتر العمل كتسمية بيانات.
6. حفظ العرض التقديمي.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instantiate the Presentation class that represents a presentation file.
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

## **إدارة أوراق العمل**

الكود التالي بلغة Python يوضح كيفية استخدام خاصية `worksheets` للوصول إلى مجموعة أوراق العمل:

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

## **دفاتر العمل الخارجية**

تدعم Aspose.Slides استخدام دفاتر العمل الخارجية كمصدر بيانات للمخططات.

### **تعيين دفاتر العمل الخارجية**

باستخدام طريقة [ChartData.set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ، يمكنك تعيين دفتر عمل خارجي إلى مخطط كمصدر بيانات له. يمكن لهذه الطريقة أيضًا تحديث المسار إلى دفتر العمل الخارجي إذا تم نقلها.

على الرغم من أنك لا تستطيع تعديل البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، يمكنك الاستمرار في استخدام تلك الدفاتر كمصادر بيانات خارجية. إذا قدمت مسارًا نسبيًا لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

معامل `update_chart_data` في طريقة [set_external_workbook] يحدد ما إذا كان سيتم تحميل دفتر Excel.

- عند تعيين `update_chart_data` إلى `False`، يتم تحديث مسار دفتر العمل فقط؛ ولا يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل الهدف. استخدم هذا الإعداد عندما لا يكون دفتر العمل الهدف موجودًا أو غير متاح.
- عند تعيين `update_chart_data` إلى `True`، يتم تحميل بيانات المخطط وتحديثها من دفتر العمل الهدف.

### **إنشاء دفاتر عمل خارجية**

باستخدام طرق [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى خارجي.

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

في بعض الأحيان تكون بيانات المخطط مرتبطة بدفتر Excel خارجي بدلاً من بيانات العرض المدمجة. باستخدام Aspose.Slides، يمكنك فحص مصدر بيانات المخطط، وإذا كان دفترًا خارجيًا، قراءة المسار الكامل للدفتر.

1. إنشاء مثيل من الفئة [Presentation].
2. الحصول على مرجع إلى الشريحة حسب الفهرس.
3. الحصول على مرجع إلى شكل المخطط.
4. الحصول على المصدر ([ChartDataSourceType]) الذي يمثل مصدر بيانات المخطط.
5. التحقق مما إذا كان نوع المصدر يتطابق مع نوع مصدر دفتر العمل الخارجي.

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

يمكنك تعديل البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تعدل بها البيانات في دفاتر العمل الداخلية. إذا تعذر تحميل دفتر عمل خارجي، يتم إلقاء استثناء.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مدمج؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات] و[مسار إلى دفتر عمل خارجي]؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا قمت بتحديد مسار نسبي، فإنه يُحوَّل تلقائيًا إلى مسار مطلق. هذا مفيد لتوحيد المشروع؛ ومع ذلك، يجب أن تعلم أن العرض سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر العمل الموجودة على موارد/مشاركات الشبكة؟**

نعم، يمكن استخدام هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تعديل دفاتر العمل البعيدة مباشرةً — يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يقوم العرض بتخزين [رابط إلى الملف الخارجي] ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي نفسه عند حفظ العرض.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا يقبل Aspose.Slides كلمة مرور عند الربط. النهج الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة مفكوكة (على سبيل المثال باستخدام [Aspose.Cells]) وربطها بتلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا كانت جميعها تشير إلى نفس الملف، سيتم عكس تحديث ذلك الملف في كل مخطط في المرة التالية التي تُحمَّل فيها البيانات.