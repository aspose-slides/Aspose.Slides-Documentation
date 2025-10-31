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
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: اكتشف Aspose.Slides لـ Python عبر .NET: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات العرض التقديمي الخاص بك.
---

## **تحديد بيانات المخطط من دفتر عمل**

Aspose.Slides توفر طرقًا لقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات المخطط التي تم تحريرها باستخدام Aspose.Cells). **ملاحظة:** يجب تنظيم بيانات المخطط بنفس الطريقة أو أن يكون لها بنية مشابهة للمصدر.

الكود التالي بلغة Python يوضح عملية مثال:

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

## **تعيين خلية دفتر العمل كعلامة بيانات للمخطط**

في بعض الأحيان تحتاج إلى تسميات المخطط التي تأتي مباشرةً من خلايا دفتر البيانات الأساسي. Aspose.Slides يتيح لك ربط تسميات البيانات بخلايا دفتر محددة بحيث يعكس نص التسمية دائمًا قيمة الخلية. يوضح المثال أدناه كيفية تمكين التسميات المستقاة من الخلية وتوجيه تسميات النقاط المختارة إلى خلايا مخصصة في دفتر المخطط.

1. إنشاء نسخة من فئة [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة بحسب الفهرس.
3. إضافة مخطط فقاعة مع بيانات نموذجية.
4. الوصول إلى سلسلة المخطط.
5. استخدام خلية من دفتر العمل كعلامة بيانات.
6. حفظ العرض التقديمي.

الكود التالي بلغة Python يوضح كيفية تعيين خلية دفتر العمل كعلامة بيانات للمخطط:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# إنشاء نسخة من فئة Presentation التي تمثل ملف عرض تقديمي.
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

الكود التالي بلغة Python يوضح كيفية استخدام الخاصية `worksheets` للوصول إلى مجموعة أوراق العمل:

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

Aspose.Slides تدعم استخدام دفاتر عمل خارجية كمصدر للبيانات للمخططات.

### **تعيين دفاتر عمل خارجية**

باستخدام الطريقة [ChartData.set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) يمكنك تعيين دفتر عمل خارجي للمخطط كمصدر بياناته. يمكن لهذه الطريقة أيضًا تحديث مسار دفتر العمل الخارجي إذا تم نقله.

على الرغم من أنك لا يمكنك تحرير البيانات في دفاتر العمل المخزنة على مواقع أو موارد عن بُعد، لا يزال بإمكانك استخدام تلك الدفاتر كمصادر بيانات خارجية. إذا وفرت مسارًا نسبيًا لدفتر عمل خارجي، فإنه يُحوَّل تلقائيًا إلى مسار كامل.

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

معامل `update_chart_data` في طريقة [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) يحدد ما إذا كان سيتم تحميل دفتر عمل Excel.

- عندما يتم تعيين `update_chart_data` إلى `False`، يتم تحديث مسار دفتر العمل فقط؛ ولا يتم تحميل أو تحديث بيانات المخطط من دفتر العمل المستهدف. استخدم هذا الإعداد عندما لا يكون دفتر العمل المستهدف موجودًا أو غير متاح.
- عندما يتم تعيين `update_chart_data` إلى `True`، يتم تحميل بيانات المخطط وتحديثها من دفتر العمل المستهدف.

### **إنشاء دفاتر عمل خارجية**

باستخدام الطرق [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى خارجي.

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

### **الحصول على مسار مصدر البيانات الخارجي لدفتر العمل الخاص بالمخطط**

في بعض الأحيان تكون بيانات المخطط مرتبطة بدفتر عمل Excel خارجي بدلاً من البيانات المدمجة في العرض التقديمي. باستخدام Aspose.Slides يمكنك فحص مصدر بيانات المخطط، وإذا كان دفتر عملًا خارجيًا، قراءة مسار دفتر العمل الكامل.

1. إنشاء نسخة من فئة [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة بحسب فهرسها.
3. الحصول على مرجع إلى شكل المخطط.
4. الحصول على المصدر ([ChartDataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/)) الذي يمثل مصدر بيانات المخطط.
5. التحقق مما إذا كان نوع المصدر يطابق نوع مصدر دفتر العمل الخارجي.

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

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تُحرّرك بها في الدفاتر الداخلية. إذا تعذر تحميل دفتر عمل خارجي، يتم رفع استثناء.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أو مدمج؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) و[مسار إلى دفتر عمل خارجي](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مفيد لقابلية نقل المشروع؛ ومع ذلك، يجب العلم أن العرض التقديمي سيخزن المسار المطلق داخل ملف PPTX.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكة؟**

نعم، يمكن استخدام تلك الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم تحرير دفاتر العمل عن بُعد مباشرةً من Aspose.Slides—يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي عندما يُحفظ العرض التقديمي.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

Aspose.Slides لا تقبل كلمة مرور عند الربط. يُنصح بإزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](/cells/python-net/)) وربطها بذلك.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. يخزن كل مخطط رابطه الخاص. إذا أشارت جميعها إلى نفس الملف، فإن تحديث ذلك الملف سيظهر في كل مخطط في المرة التالية التي تُحمَّل فيها البيانات.