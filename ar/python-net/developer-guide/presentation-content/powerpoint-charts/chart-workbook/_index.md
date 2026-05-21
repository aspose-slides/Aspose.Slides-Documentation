---
title: إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام بايثون
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/python-net/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- علامة البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف Aspose.Slides للبايثون عبر .NET: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات العرض التقديمي الخاص بك."
---
## **نظرة عامة**

يشرح هذا المقال كيفية العمل مع دفاتر عمل المخططات في Aspose.Slides. يوضح كيفية قراءة وكتابة بيانات المخطط من خلال تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات للمخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما يغطي العمل مع دفاتر العمل الخارجية كمصادر بيانات للمخططات. تُظهر الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر العمل الخارجي المرتبط بمخطط، وتحرير بيانات المخطط عندما يكون دفتر العمل متاحًا.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides طرقًا لقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تعديلها باستخدام Aspose.Cells). **ملاحظة:** يجب أن تكون بيانات المخطط منظمة بنفس الطريقة أو ذات بنية مشابهة للمصدر.

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

## **تعيين خلية WorkBook كعلامة بيانات المخطط**

في بعض الأحيان تحتاج إلى عناوين مخطط تستند مباشرة إلى خلايا في دفتر البيانات الأساسي. يسمح Aspose.Slides بربط عناوين البيانات بخلايا دفتر عمل محددة بحيث يعكس نص العنوان دائمًا قيمة الخلية. يوضح المثال أدناه كيفية تمكين علامات القيم-من-خلية وتوجيه العناوين المختارة إلى خلايا مخصصة في دفتر عمل المخطط.

1. إنشاء مثيل من [Presentation](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/) class.
2. الحصول على مرجع إلى الشريحة حسب الفهرس.
3. إضافة مخطط فقاعة مع بيانات نموذجية.
4. الوصول إلى سلسلة المخطط.
5. استخدام خلية دفتر العمل كعلامة بيانات.
6. حفظ العرض.

الكود التالي بلغة Python يوضح كيفية تعيين خلية دفتر عمل كعلامة بيانات مخطط:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# إنشاء كائن فئة Presentation التي تمثل ملف عرض تقديمي.
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

## **اكتشاف صيغ دفاتر العمل المضمنة غير المدعومة**

لا تدعم Aspose.Slides تنسيق دفتر العمل الثنائي Excel (.xlsb) الذي يمكن تضمينه في بعض المخططات. يمكنك استخدام الخاصية `embedded_workbook_type` على [ChartData](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/workbooktype/) لاكتشاف الصيغ غير المدعومة وتجاوز تلك المخططات.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # دفتر العمل المضمن بصيغة .xlsb غير مدعوم.
            continue

        # قراءة أو تعديل بيانات دفتر عمل المخطط هنا.
```

## **دفاتر العمل الخارجية**

تدعم Aspose.Slides استخدام دفاتر العمل الخارجية كمصدر بيانات للمخططات.

### **تعيين دفاتر العمل الخارجية**

باستخدام طريقة [ChartData.set_external_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/set_external_workbook/) يمكنك تعيين دفتر عمل خارجي إلى مخطط كمصدر بيانات له. يمكن لهذه الطريقة أيضًا تحديث مسار دفتر العمل الخارجي إذا تم نقله.

على الرغم من أنك لا تستطيع تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد بعيدة، لا يزال بإمكانك استخدام تلك الدفاتر كمصادر بيانات خارجية. إذا قدمت مسارًا نسبيًا لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

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

معلمة `update_chart_data` للطريقة [set_external_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/set_external_workbook/) تحدد ما إذا كان سيتم تحميل دفتر عمل Excel.

- عندما تكون `update_chart_data` مساوية لـ `False`، يتم تحديث مسار دفتر العمل فقط؛ لا يتم تحميل أو تحديث بيانات المخطط من دفتر العمل الهدف. استخدم هذا الإعداد عندما لا يكون دفتر العمل الهدف موجودًا أو غير متاح.
- عندما تكون `update_chart_data` مساوية لـ `True`، يتم تحميل بيانات المخطط وتحديثها من دفتر العمل الهدف.

### **إنشاء دفاتر عمل خارجية**

باستخدام طريقة [read_workbook_stream](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) وطريقة [set_external_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/set_external_workbook/) يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى دفتر عمل خارجي.

هذا الكود بلغة Python يوضح عملية إنشاء دفتر عمل خارجي:

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

### **الحصول على مسار دفتر عمل مصدر البيانات الخارجي لمخطط**

في بعض الأحيان تكون بيانات مخطط مرتبطًا بدفتر عمل Excel خارجي بدلاً من البيانات المضمنة في العرض. باستخدام Aspose.Slides، يمكنك فحص مصدر بيانات المخطط، وإذا كان مصدرًا خارجيًا، قراءة المسار الكامل لدفتر العمل.

1. إنشاء مثيل من [Presentation](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/) class.
2. الحصول على مرجع إلى الشريحة حسب فهرسها.
3. الحصول على مرجع إلى شكل المخطط.
4. الحصول على المصدر ([ChartDataSourceType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatasourcetype/)) الذي يمثل مصدر بيانات المخطط.
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

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تحرر بها البيانات في دفاتر العمل الداخلية. إذا تعذر تحميل دفتر عمل خارجي، يتم رفع استثناء.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أو مدمج؟**

نعم. يحتوي المخطط على [data source type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/data_source_type/) و[path to an external workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/external_workbook_path/)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية إلى دفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتحول تلقائيًا إلى مسار مطلق. هذا مفيد لتنقل المشروع؛ ومع ذلك، يجب أن تكون على علم بأن العرض سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكية؟**

نعم، يمكن استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم تحرير دفاتر العمل البعيدة مباشرةً من Aspose.Slides—يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض؟**

لا. يخزن العرض [link to the external file](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي نفسه عند حفظ العرض.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

Aspose.Slides لا تقبل كلمة مرور عند الربط. النهج الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (مثلاً باستخدام [Aspose.Cells](/cells/python-net/)) والربط بتلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا كانت جميعها تشير إلى نفس الملف، فإن تحديث ذلك الملف سينعكس في كل مخطط في المرة التالية التي يتم فيها تحميل البيانات.