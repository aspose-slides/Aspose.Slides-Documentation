---
title: إدارة دفاتر عمل المخطط في العروض التقديمية باستخدام Python
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/python-net/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- علامة البيانات
- ورقة عمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة مخبئ المخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف Aspose.Slides للغة Python عبر .NET: إدارة دفاتر عمل المخطط بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات العرض التقديمي الخاصة بك."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية التعامل مع دفاتر العمل الخاصة بالمخططات في Aspose.Slides. وتوضح كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات للمخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر العمل الخارجية كمصادر بيانات للمخططات. توضح الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر العمل الخارجي المرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides أساليب لقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة:** يجب تنظيم بيانات المخطط بنفس الطريقة أو أن تكون لها بنية مشابهة للمصدر.

يعرض الكود التالي بلغة Python عملية نموذجية:

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

### **التحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر العمل المضمن بآخر معدل، يحتفظ المخطط بسلسلة الفئات والمجموعات الأصلية. قد يؤدي هذا الاختلاف إلى فشل [IChart.validate_chart_layout](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/ichart/validate_chart_layout/) مع خطأ "فهرس خارج النطاق". قم بمسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدث مرة أخرى إلى المخطط.

```python
# بعد تعديل تدفق دفتر العمل (مثلاً باستخدام Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# مسح مراجع البيانات الحالية.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

ضمان مسح المجموعات يضمن تناسق بنية بيانات المخطط مع دفتر العمل الجديد، مما يسمح لـ `validate_chart_layout` بالاكتمال دون أخطاء.

## **تعيين خلية دفتر عمل كعنوان بيانات للمخطط**

في بعض الأحيان تحتاج إلى عناوين مخطط تُستمد مباشرةً من خلايا دفتر العمل الأساسي. يسمح Aspose.Slides بربط عناوين البيانات بخلايا دفتر عمل محددة بحيث يعكس نص العنوان دائمًا قيمة الخلية. يوضح المثال أدناه كيفية تمكين عناوين القيم من الخلية وتوجيه العناوين المحددة إلى خلايا مخصصة في دفتر عمل المخطط.

1. إنشاء كائن من فئة [Presentation](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة حسب الفهرس.
1. إضافة مخطط فقاعي مع بيانات نموذجية.
1. الوصول إلى سلاسل المخطط.
1. استخدام خلية دفتر عمل كعنوان بيانات.
1. حفظ العرض التقديمي.

يعرض الكود التالي بلغة Python كيفية تعيين خلية دفتر عمل كعنوان بيانات للمخطط:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
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

يعرض الكود التالي بلغة Python كيفية استخدام خاصية `worksheets` للوصول إلى مجموعة أوراق العمل:

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

يعرض الكود التالي بلغة Python كيفية تحديد نوع مصدر البيانات:

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

## **اكتشاف تنسيقات دفاتر العمل المضمنة غير المدعومة**

لا تدعم Aspose.Slides تنسيق دفتر العمل الثنائي Excel (.xlsb) الذي يمكن تضمينه في بعض المخططات. يمكنك استخدام خاصية `embedded_workbook_type` على [ChartData](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/workbooktype/) لاكتشاف التنسيقات غير المدعومة وتجاوز تلك المخططات.

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
            # دفتر العمل المضمن بتنسيق .xlsb غير مدعوم.
            continue

        # اقرأ أو عدّل بيانات دفتر عمل المخطط هنا.
```

## **دفاتر العمل الخارجية**

تدعم Aspose.Slides استخدام دفاتر العمل الخارجية كمصدر بيانات للمخططات.

### **تعيين دفاتر العمل الخارجية**

باستخدام طريقة [ChartData.set_external_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/set_external_workbook/)، يمكنك تعيين دفتر عمل خارجي للمخطط كمصدر بيانات له. يمكن لهذه الطريقة أيضًا تحديث مسار دفتر العمل الخارجي إذا تم نقله.

على الرغم من أنك لا تستطيع تحرير البيانات في دفاتر العمل المخزنة على مواقع أو موارد بعيدة، إلا أنه لا يزال بإمكانك استخدام تلك الدفاتر كمصادر بيانات خارجية. إذا قدمت مسارًا نسبيًا لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

يعرض الكود التالي بلغة Python كيفية تعيين دفتر عمل خارجي:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # مرّر False حتى يتم تخزين المسار فقط: لا يلزم أن يكون دفتر العمل الهدف موجودًا بعد.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

معامل `update_chart_data` لطريقة [set_external_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/set_external_workbook/) يحدد ما إذا كان سيتم تحميل دفتر العمل Excel.

- عندما يُعيّن `update_chart_data` إلى `False`، يتم تحديث مسار دفتر العمل فقط؛ لا يتم تحميل أو تحديث بيانات المخطط من دفتر العمل المستهدف. استخدم هذا الإعداد عندما يكون دفتر العمل المستهدف غير موجود أو غير متاح.
- عندما يُعيّن `update_chart_data` إلى `True` (الإعداد الافتراضي)، يتم تحميل وتحديث بيانات المخطط من دفتر العمل المستهدف. إذا تعذر فتح ذلك دفتر العمل، يُرمى استثناء برسالة "External workbook is not available".

### **إنشاء دفاتر عمل خارجية**

باستخدام طريقتي [read_workbook_stream](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و[set_external_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/set_external_workbook/)، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى خارجي.

يعرض الكود التالي بلغة Python عملية إنشاء دفتر عمل خارجي:

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

### **الحصول على مسار دفتر العمل الخارجي لمصدر البيانات لمخطط**

في بعض الأحيان تكون بيانات المخطط مرتبطة بدفتر عمل Excel خارجي بدلاً من البيانات المضمنة في العرض التقديمي. باستخدام Aspose.Slides، يمكنك فحص مصدر بيانات المخططم، وإذا كان دفتر عملًا خارجيًا، قراءة مساره الكامل.

1. إنشاء كائن من فئة [Presentation](https://docs.aspose.com/slides/ar/python-net/api-reference/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة حسب الفهرس.
1. الحصول على مرجع إلى شكل المخطط.
1. الحصول على المصدر ([ChartDataSourceType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatasourcetype/)) الذي يمثل مصدر بيانات المخطط.
1. التحقق مما إذا كان نوع المصدر يطابق نوع مصدر دفتر العمل الخارجي.

يعرض الكود التالي بلغة Python العملية:

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

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تحرر بها البيانات في دفاتر العمل الداخلية. إذا تعذر تحميل دفتر عمل خارجي، يُرمى استثناء.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **استعادة دفتر عمل من ذاكرة التخزين المؤقت للمخطط**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. قم بإنشاء [LoadOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/)، ثم فعّل [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/ar/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) عبر [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/spreadsheet_options/) قبل فتح العرض التقديمي.

يعرض المثال التالي بلغة Python عرضًا تقديميًا يشير مخططه إلى دفتر عمل خارجي غير متاح ويصل إلى البيانات المستعادة عبر [Chart.chart_data](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/chart_data/) و[ChartData.chart_data_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # اقرأ أو عدّل بيانات دفتر العمل المستعاد هنا.
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، تُرمى Aspose.Slides استثناءً. فعّل الاستعادة فقط عندما تكون الاستفادة من البيانات المخزنة مؤقتًا مقبولة، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مضمّن؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/data_source_type/) و[مسار دفتر عمل خارجي](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/external_workbook_path/); إذا كان المصدر دفتر عمل خارجيًا، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية إلى دفاتر العمل الخارجية، وكيف تُخزن؟**

نعم. إذا حددت مسارًا نسبيًا، يتحول تلقائيًا إلى مسار مطلق. هذا مفيد لنقلية المشروع؛ ومع ذلك، يجب أن تكون على علم بأن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات الشبكة؟**

نعم، يمكن استخدام تلك الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يُدعم تحرير دفاتر العمل عن بُعد مباشرةً من Aspose.Slides؛ يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

فقط إذا قمت بتحرير بيانات المخطط. يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ويستخدمه لقراءة البيانات، لذا فإن فتح وحفظ العرض يترك دفتر العمل دون تعديل. ومع ذلك، القيم التي تغيرها عبر بيانات المخطط (انظر **تحرير بيانات المخطط** أعلاه) تُكتب مرة أخرى إلى دفتر العمل الخارجي عند حفظ العرض—اعمل على نسخة إذا كان الأصل يجب أن يبقى سليمًا.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند الربط. النهج الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](/cells/python-net/)) وربط تلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا كانت جميع الروابط تشير إلى نفس الملف، فإن تحديث ذلك الملف سينعكس في كل مخطط عند تحميل البيانات مرة أخرى.