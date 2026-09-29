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
- ملصق البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة التخزين المؤقت للمخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف Aspose.Slides for Python via .NET: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات العرض التقديمي الخاص بك."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع دفاتر عمل الرسوم البيانية في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات الرسم البياني عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كملصقات بيانات للرسوم البيانية، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم الرسم البياني.

كما تغطي العمل مع دفاتر عمل خارجية كمصادر بيانات للرسوم البيانية. توضح الأمثلة كيفية إنشاء دفتر عمل خارجي وتعيينه، واسترجاع مسار دفتر عمل خارجي مرتبط بالرسم البياني، وتعديل بيانات الرسم البياني عندما يكون دفتر العمل متاحًا.

لخلايا دفتر العمل التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/python-net/chart-series/) لمعرفة الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خطي لأوضاع العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) للتحكم فيما إذا كان الرسم البياني يرسم البيانات من صفوف وأعمدة ورقة العمل المخفية. اضبطه على `True` لرسم الخلايا المرئية فقط، أو `False` لتضمين كل من الخلايا المرئية والمخفية. هذه الإعدادات تتحكم في رسم الرسم البياني؛ لا تقوم بإخفاء أو إظهار صفوف أو أعمدة ورقة العمل.

حمّل [hidden-source-data.pptx](hidden-source-data.pptx) وضعه في دليل العمل. يحتوي الشريحة الأولى على مخطط عمودي كأول شكل. ورقة العمل المضمنة، `Sheet1`، تحتوي على نطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما لا تزال تحتوي على قيم.

| صف ورقة العمل | A: الشهر | B: التجزئة | C: الجملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى خلايا المصدر عبر [ChartData.chart_data_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) وقراءة [ChartDataCell.is_hidden](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatacell/is_hidden/) لتفقد حالة الإخفاء الخاصة بها. هذه الخاصية للقراءة فقط. في هذا الملف، B2 مرئي، B3 ينتمي إلى الصف المخفي، وC2 ينتمي إلى العمود المخفي؛ المثال يطبع `False`، `True`، و`True` على التوالي.

لهذا المثال، قم بتحديث بيانات الرسم البياني بعد تغيير إعداد الرسم: احتفظ بدفتر العمل المضمن باستخدام [read_workbook_stream](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) وأعد تحميله باستخدام [write_workbook_stream](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). عند تضمين كل الخلايا، استخدم أيضًا [set_range](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/set_range/) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. مجرد تغيير العلامة غير كافٍ لتحديث بيانات الرسم المخزنة مؤقتًا وتسميات الفئات في هذا المثال.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # تجديد بيانات المخطط من دفتر العمل المضمّن.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # استعادة نطاق المصدر الكامل، بما في ذلك الفئات المخفية.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

يحفظ المثال `hidden_cells_True.pptx` مع قيم التجزئة المرئية فقط (10 و20)، و`hidden_cells_False.pptx` مع جميع القيم الست. تم تشغيل الصور أدناه من العروض المقدمة المحفوظة بعد إعادة فتحها؛ كلا الملفين يحافظان على إعداد الرسم المحدد. يظل الصف 3 والعمود C مخفيين في كلا دفترَي العمل المضمنين.

| الخلايا المرئية فقط (`True`) | كل الخلايا (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [Chart.display_blanks_as](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/display_blanks_as/) في طريقة عرض القيم المفقودة؛ لا يضيف أو يستبعد بيانات المصدر المخفي. راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/python-net/chart-series/#control-the-display-of-empty-cells) للحصول على مثال.

## **قراءة وكتابة بيانات الرسم البياني من دفتر عمل**

توفر Aspose.Slides for Python via .NET طريقتي [read_workbook_stream](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و[write_workbook_stream](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) التي تسمح لك بقراءة وكتابة دفاتر عمل بيانات الرسم البياني (التي تحتوي على بيانات تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات الرسم البياني يجب أن تُنظم بنفس الطريقة أو أن يكون لها هيكل مشابه للمصدر.

يفتح هذا المثال `chart.pptx`، الذي يجب أن يحتوي على رسم بياني كأول شكل في شريحته الأولى. يقرأ دفتر العمل المضمن إلى تدفق، يمسح السلاسل والفئات الحالية، ويكتب دفتر العمل نفسه مرة أخرى. تظل التغييرات في الذاكرة؛ لا يقوم المثال بحفظ العرض التقديمي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **التحقق من تخطيط الرسم البياني بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مضمّن بآخر معدل، يحتفظ الرسم البياني بالمجموعات الأصلية من السلاسل والفئات. هذا الاختلاف قد يؤدي إلى فشل [Chart.validate_chart_layout](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/validate_chart_layout/) مع خطأ "فهرس خارج النطاق". امسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدث إلى الرسم البياني. يتطلب هذا المثال وجود `chart.pptx` مع رسم بياني كأول شكل في شريحته الأولى. العلامات التعليقات تُظهر مكان تحرير دفتر العمل؛ يكتب المثال دفتر العمل الأصلي مرة أخرى ويحقق من صحة التخطيط في الذاكرة.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # تعديل تدفق دفتر العمل هنا، على سبيل المثال باستخدام Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

يمسح مسح المجموعات مراجع البيانات القديمة قبل كتابة دفتر العمل مرة أخرى. أعد بناء أي تعيينات للسلاسل والفئات المطلوبة للدفتر المحدث قبل استخدام الرسم البياني.

## **تعيين خلية دفتر العمل كملصق بيانات الرسم البياني**

يمكنك استخدام النص من خلايا دفتر العمل كملصقات بيانات للرسم البياني. تُظهر الخطوات التالية كيفية ربط الملصقات في مخطط الفقاعات بخلايا دفتر البيانات الخاص به.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة الأولى باستخدام الفهرس الصفري.
3. إضافة مخطط فقاعات ببيانات افتراضية.
4. الوصول إلى سلسلة الرسم البياني.
5. تعيين خلية دفتر العمل كملصق بيانات.
6. حفظ العرض التقديمي.

يفتح هذا المثال `chart2.pptx`، الذي يجب أن يحتوي على شريحة واحدة على الأقل، ويضيف مخطط فقاعات ببيانات افتراضية. يستخدم الخلايا A10:A12 في ورقة العمل 0 للملصقات الثلاث الأولى في السلسلة الأولى، يفعّل الملصقات من الخلايا، ويحفظ النتيجة إلى `resultchart.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **إدارة أوراق العمل**

توفر الخاصية [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) إمكانية الوصول إلى أوراق العمل في دفتر عمل الرسم البياني. يخلق هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **تحديد نوع مصدر البيانات**

ينشئ هذا المثال مخطط أعمدة ثلاثي الأبعاد ببيانات افتراضية ويحدد اسمين للسلاسل باستخدام مصادر بيانات مختلفة. الاسم الأول يستخدم نصًا حرفيًا؛ الاسم الثاني يستخدم الخلية C1 في ورقة العمل 0. يختار تعداد [DataSourceType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datasourcetype/) المصدر لكل اسم. يتم حفظ النتيجة إلى `pres.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **اكتشاف صيغ دفتر العمل المضمن غير المدعومة**

لا تدعم Aspose.Slides صيغة دفتر العمل الثنائي Excel (.xlsb) التي يمكن تضمينها في بعض الرسوم البيانية. يمكنك استخدام خاصية [embedded_workbook_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) على [ChartData](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/workbooktype/) لاكتشاف الصيغ غير المدعومة وتخطي تلك الرسوم البيانية. يفحص هذا المثال الأشكال في الشريحة الأولى من `sample.pptx`، يتخطى الأشكال غير الرسومية، ويطبع رسالة تشخيص لكل رسم بياني يحتوي على دفتر عمل .xlsb مضمّن.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # قراءة أو تعديل بيانات دفتر عمل المخطط المدعومة هنا.
```

## **دفتر عمل خارجي**

تدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للرسوم البيانية.

### **إنشاء دفتر عمل خارجي**

استخدم [read_workbook_stream](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و[set_external_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/set_external_workbook/) لتصدير دفتر عمل الرسم البياني المضمن إلى ملف وربط الرسم البياني بذلك الدفتر الخارجي.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية، يكتب دفتر عمله إلى `externalWorkbook1.xlsx`، ويغلق تدفق الإخراج قبل تعيين الملف كمصدر بيانات للرسم البياني. يحفظ العرض التقديمي المرتبط إلى `externalWorkbook.pptx`.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)
    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **تعيين دفتر عمل خارجي**

باستخدام طريقة [set_external_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/set_external_workbook/) يمكنك تعيين دفتر عمل خارجي للرسم البياني كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الملف).

مع أنه لا يمكن تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، لا تزال تلك الدفاتر صالحة كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتحول تلقائيًا إلى مسار كامل.

يتطلب هذا المثال وجود `externalWorkbook.xlsx` في دليل العمل. يجب أن تحتوي ورقة العمل المسماة `Sheet1` على اسم سلسلة في B1، أسماء فئات في A2:A4، وقيم رقمية في B2:B4. ينشئ المثال مخططًا دائريًا، يربط الدفتر، ويستخدم [set_range](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/set_range/) لتعيين النطاق A1:B4 إلى سلسلة واحدة وثلاث فئات. يحفظ النتيجة إلى `Presentation_with_externalWorkbook.pptx`.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

معامل `update_chart_data` في طريقة [set_external_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/set_external_workbook/) يتحكم فيما إذا كان يتم تحميل دفتر العمل.

* عندما يكون `update_chart_data` مساويًا لـ `False`، يتم تحديث مسار دفتر العمل فقط. لا يتم تحميل أو تحديث بيانات الرسم البياني من دفتر العمل الهدف، وبالتالي يمكن أن يكون دفتر العمل غير متوفر.
* عندما يكون `update_chart_data` مساويًا لـ `True`، يتم تحديث بيانات الرسم البياني من دفتر العمل الهدف.

المثال التالي يعيّن عنوان URL نائب مع `update_chart_data` مضبوطًا على `False`. يحتفظ بالبيانات الافتراضية لمخطط الفطيرة ويحفظ العرض التقديمي دون تحميل دفتر العمل غير المتوفر.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **الحصول على مسار دفتر العمل الخارجي لمصدر البيانات للرسم البياني**

لتحديد دفتر العمل المرتبط بالرسم البياني، تحقق أولاً مما إذا كان الرسم يستخدم مصدر بيانات خارجي. إذا كان كذلك، يمكنك استرجاع مسار دفتر العمل باتباع الخطوات التالية.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
2. الوصول إلى الشريحة الأولى باستخدام الفهرس الصفري.
3. التأكد من أن الشكل الأول هو رسم بياني.
4. قراءة نوع مصدر بيانات الرسم البياني.
5. إذا كان المصدر دفتر عمل خارجي، قراءة مساره.

يفتح هذا المثال `externalWorkbook.pptx`، الذي تم إنشاؤه في المثال السابق، ويفحص الشكل الأول في الشريحة الأولى. إذا كان رسمًا بيانيًا مرتبطًا بدفتر عمل خارجي، يطبع المثال [external_workbook_path](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/external_workbook_path/) إلى وحدة التحكم. ثم يحفظ نسخة من العرض التقديمي إلى `Result.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **تحرير بيانات الرسم البياني**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تجري بها تغييرات على محتوى دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يتم رفع استثناء.

يتطلب هذا المثال وجود `presentation.pptx` مع رسم بياني كأول شكل في الشريحة الأولى ودفتر عمل خارجي يمكن الوصول إليه. يعيّن قيمة الخلية للنقطة البيانات الأولى في السلسلة الأولى إلى 100 ويحفظ العرض التقديمي إلى `presentation_out.pptx`. يمكن لتحرير قيم الخلايا تحديث ملف XLSX الخارجي المرتبط، لذا استخدم نسخة إذا كنت تحتاج إلى حفظ دفتر العمل الأصلي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **استعادة دفتر عمل من ذاكرة التخزين المؤقت للرسم البياني**

إذا كان الرسم البياني يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل الرسم البياني من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/)، اضبط [spreadsheet_options](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/spreadsheet_options/)، وضع [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/ar/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) إلى `True` قبل فتح العرض التقديمي.

يفتح المثال التالي بلغة Python `presentation.pptx`، والذي يجب أن يحتوي على الشكل الأول في الشريحة الأولى كرسوم بياني يشير إلى دفتر عمل خارجي غير متاح، ويصل إلى البيانات المستعادة عبر [Chart.chart_data](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/chart_data/) و[ChartData.chart_data_workbook](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # قراءة أو تعديل بيانات دفتر العمل المستعاد هنا.
    else:
        print("The first shape is not a chart.")
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاسترجاع، يرفع Aspose.Slides استثناء. فعّل الاسترجاع فقط عندما يكون استخدام البيانات المخزنة مؤقتًا خيارًا مقبولًا، لأن الذاكرة المؤقتة قد لا تشمل التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتداولة**

**هل يمكنني تحديد ما إذا كان رسم بياني معين مرتبط بدفتر عمل خارجي أم مضمّن؟**

نعم. يحتوي الرسم البياني على [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/data_source_type/) و[مسار دفتر العمل الخارجي](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/external_workbook_path/); إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تلقائيًا تحويله إلى مسار مطلق. يخزن العرض التقديمي المسار المطلق في ملف PPTX، لذا قد يتطلب نقل دفتر العمل تحديث الرابط.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكة؟**

نعم، يمكن استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير دفاتر العمل عن بُعد مباشرةً؛ يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

يحفظ العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/external_workbook_path/). يمكن أيضًا لتعديل بيانات الرسم المستندة إلى الخلايا تحديث ملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان الأصل يجب أن يبقى دون تغيير.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا يقبل Aspose.Slides كلمة مرور عند الربط. يُنصح بإزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (مثلاً باستخدام [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) وربط تلك النسخة.

**هل يمكن لعدة رسومات بيانية الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. يخزن كل رسم بياني رابطه الخاص. إذا كانت جميعها تشير إلى نفس الملف، فسيت reflected تحديث ذلك الملف في كل رسم بياني عند تحميل البيانات لاحقًا.