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
- عنوان البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة مخبأة للمخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف Aspose.Slides for Python عبر .NET: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات عرضك التقديمي."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع دفاتر عمل المخططات في Aspose.Slides. توضح كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات المخطط، والوصول إلى مجموعة أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر عمل خارجية كمصادر بيانات للمخططات. توضح الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترداد مسار دفتر العمل الخارجي المرتبط بالمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides طرقًا لقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات المخطط التي تم تعديلها باستخدام Aspose.Cells). **ملاحظة:** يجب تنظيم بيانات المخطط بنفس الطريقة أو أن تكون له بنية مشابهة للمصدر.

يعرض رمز Python التالي عملية نموذجية:

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

## **تعيين خلية دفتر عمل كعنوان بيانات المخطط**

في بعض الأحيان تحتاج إلى عناوين مخطط تُستخرج مباشرةً من خلايا دفتر العمل الأساسي. يسمح لك Aspose.Slides بربط عناوين البيانات بخلايا دفتر عمل محددة بحيث يعكس نص العنوان دائمًا قيمة الخلية. تُظهر المثال أدناه كيفية تمكين عناوين «القيمة من الخلية» وتوجيه العناوين المختارة إلى خلايا مخصصة في دفتر عمل المخطط.

1. إنشاء كائن من الفئة [العرض التقديمي](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة بواسطة الفهرس.
3. إضافة مخطط فقاعي ببيانات نموذجية.
4. الوصول إلى سلسلة المخطط.
5. استخدام خلية دفتر عمل كعنوان للبيانات.
6. حفظ العرض التقديمي.

يعرض رمز Python التالي كيفية تعيين خلية دفتر عمل كعنوان بيانات المخطط:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
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

يعرض رمز Python التالي كيفية استخدام خاصية `worksheets` للوصول إلى مجموعة أوراق العمل:

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

يعرض رمز Python التالي كيفية تحديد نوع مصدر البيانات:

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

## **الكشف عن تنسيقات دفتر العمل المدمجة غير المدعومة**

لا تدعم Aspose.Slides تنسيق دفتر العمل الثنائي Excel (.xlsb) الذي يمكن أن يُدمج في بعض المخططات. يمكنك استخدام خاصية `embedded_workbook_type` على فئة [ChartData](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/workbooktype/) للكشف عن التنسيقات غير المدعومة وتجاوز تلك المخططات.

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
            # دفتر العمل المدمج بتنسيق .xlsb، وهو غير مدعوم.
            continue

        # اقرأ أو عدل بيانات دفتر عمل المخطط هنا.
```

## **دفاتر العمل الخارجية**

تدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **تعيين دفاتر عمل خارجية**

باستخدام طريقة [ChartData.set_external_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/set_external_workbook/)، يمكنك تعيين دفتر عمل خارجي للمخطط كمصدر بيانات له. يمكن لهذه الطريقة أيضًا تحديث مسار دفتر العمل الخارجي إذا تم نقله.

على الرغم من أنك لا تستطيع تعديل البيانات في دفاتر العمل المخزنة في مواقع أو موارد بعيدًا، إلا أنه لا يزال بإمكانك استخدام تلك الدفاتر كمصادر بيانات خارجية. إذا قدمت مسارًا نسبيًا لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

يعرض رمز Python التالي كيفية تعيين دفتر عمل خارجي:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

تُحدد معلمة `update_chart_data` للطريقة [set_external_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ما إذا كان سيتم تحميل دفتر عمل Excel.

- عندما تكون `update_chart_data` مساوية لـ `False`، يتم تحديث مسار دفتر العمل فقط؛ لا يتم تحميل أو تحديث بيانات المخطط من دفتر العمل الهدف. استخدم هذا الإعداد عندما لا يكون دفتر العمل الهدف موجودًا أو غير متاح.
- عندما تكون `update_chart_data` مساوية لـ `True`، تُحمَّل بيانات المخطط وتُحدَّث من دفتر العمل الهدف.

### **إنشاء دفاتر عمل خارجية**

باستخدام طريقتي [read_workbook_stream](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و[set_external_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/set_external_workbook/)، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى خارجي.

يوضح رمز Python التالي عملية إنشاء دفتر عمل خارجي:

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

### **الحصول على مسار دفتر العمل المصدر الخارجي لمخطط**

في بعض الأحيان تكون بيانات المخطط مرتبطة بدفتر عمل Excel خارجي بدلاً من البيانات المدمجة في العرض التقديمي. مع Aspose.Slides، يمكنك فحص مصدر بيانات المخطط، وإذا كان دفتر عملًا خارجيًا، قراءة المسار الكامل له.

1. إنشاء كائن من الفئة [العرض التقديمي](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة عبر فهرسها.
3. الحصول على مرجع إلى شكل المخطط.
4. الحصول على المصدر ([ChartDataSourceType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatasourcetype/)) الذي يمثل مصدر بيانات المخطط.
5. التحقق مما إذا كان نوع المصدر يطابق نوع مصدر دفتر العمل الخارجي.

يعرض رمز Python التالي العملية:

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

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تحرر بها البيانات في الدفاتر الداخلية. إذا تعذر تحميل دفتر عمل خارجي، يُطرح استثناء.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **استعادة دفتر عمل من ذاكرة التخزين المؤقت للمخطط**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ كائنًا من [LoadOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/)، ثم فعل الخاصية [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/ar/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) عبر [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/spreadsheet_options/) قبل فتح العرض التقديمي.

يعرض المثال التالي فتح عرض تقديمي يشير مخططه إلى دفتر عمل خارجي غير متاح والوصول إلى البيانات المستعادة عبر [Chart.chart_data](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/chart_data/) و[ChartData.chart_data_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # قراءة أو تعديل بيانات دفتر العمل المستعاد هنا.
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، ستُطلِق Aspose.Slides استثناءً. فعل الاستعادة فقط عندما يكون استخدام البيانات المخزنة مؤقتًا كحل احتياطي مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أو مدمج؟**

نعم. يمتلك المخطط [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/data_source_type/) و[مسار إلى دفتر عمل خارجي](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/external_workbook_path/); إذا كان المصدر دفتر عمل خارجيًا، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية لدفاتر العمل الخارجية، وكيف تُخزن؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مفيد لنقلية المشروع؛ ومع ذلك، يجب أن تكون على علم بأن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكة؟**

نعم، يمكن استخدام تلك الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يُدعم تحرير دفاتر العمل البعيدة مباشرةً من Aspose.Slides – يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي نفسه عند حفظ العرض التقديمي.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند الربط. يفضل إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](/cells/python-net/)) والربط بهذه النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. يخزن كل مخطط رابطه الخاص. إذا كانت جميعها تشير إلى نفس الملف، فإن تحديث ذلك الملف سيظهر في كل مخطط في المرة التالية التي تُحمَّل فيها البيانات.