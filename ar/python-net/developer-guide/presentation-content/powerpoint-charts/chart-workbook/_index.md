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
- تسمية البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة مخطط مؤقتة
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف Aspose.Slides لبايثون عبر .NET: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات عرضك التقديمي."
---
## **نظرة عامة**

هذه المقالة تشرح كيفية التعامل مع مصنفات المخططات في Aspose.Slides. توضح كيفية قراءة وكتابة بيانات المخطط عبر تدفقات المصنف، واستخدام خلايا المصنف كملصقات لبيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع المصنفات الخارجية كمصادر بيانات للمخططات. توضح الأمثلة كيفية إنشاء مصنف خارجي وتعيينه، استرجاع مسار المصنف الخارجي المرتبط بمخطط، وتعديل بيانات المخطط عندما يتوفر المصنف.

لخلايا المصنف التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/python-net/chart-series/) لمعرفة الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط الخطوط لأوضاع العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) للتحكم فيما إذا كان المخطط يرسم بيانات من صفوف وأعمدة ورقة العمل المخفية. اضبطه على `True` لرسم الخلايا الظاهرة فقط، أو `False` لتضمين كلًا من الخلايا الظاهرة والمخفية. هذا الإعداد يتحكم في رسم المخطط؛ ولا يخفي أو يُظهر صفوف أو أعمدة ورقة العمل.

العرض [sample presentation](hidden-source-data.pptx) يحتوي على مخطط عمودي كأول شكل في شريحته الأولى. ورقة العمل المضمّنة، `Sheet1`، تحتوي على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما لا تزال تحتوي على قيم.

| صف ورقة العمل | A: شهر | B: بيع بالتجزئة | C: جملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى الخلايا المصدرية عبر [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) وقراءة [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) لفحص حالتها المخفية. هذه الخاصية للقراءة فقط. في هذا الملف، B2 ظاهر، B3 ينتمي إلى الصف المخفي، وC2 ينتمي إلى العمود المخفي؛ المثال يطبع `False`، `True`، و`True` على الترتيب.

في هذا المثال، قم بتحديث بيانات المخطط بعد تغيير إعداد الرسم: احتفظ بالمصنف المضمّن باستخدام [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) وأعد تحميله باستخدام [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). عند تضمين جميع الخلايا، استخدم أيضًا [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. مجرد تغيير العلامة غير كافٍ لتحديث بيانات المخطط المخزنة مؤقتًا وعناوين الفئات في هذا المثال.

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

            # تحديث بيانات المخطط من المصنف المضمّن.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # استعادة النطاق المصدر الكامل، بما في ذلك الفئات المخفية.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

يحفظ المثال نسختين من العرض: واحدة تحتوي فقط على قيم البيع بالتجزئة الظاهرة (10 و20)، وأخرى تحتوي على جميع القيم الست. تم إنشاء الصور أدناه من العروض المحفوظة بعد إعادة فتحها؛ كلا الملفين يحافظان على إعداد الرسم المحدد. يظل الصف 3 والعمود C مخفيين في كلا المصنفين المضمّنين.

| الخلايا المرئية فقط (`True`) | جميع الخلايا (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) في طريقة عرض القيم المفقودة؛ ولا يضيف أو يستثني البيانات المصدرية المخفية. راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/python-net/chart-series/#control-the-display-of-empty-cells) للحصول على مثال.

## **استرجاع نطاق بيانات المخطط**

قبل تحديث بيانات المصنف في عرض موجود، افحص النطاقات المصدرية لتحديد خلايا ورقة العمل التي يستخدمها كل مخطط. ترجع طريقة [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) النطاق الحالي للبيانات كصيغة مؤهلة لورقة العمل، مثل `Sheet1!$A$1:$D$5`. هنا، `Sheet1` هو اسم ورقة العمل، `!` يفصلها عن نطاق الخلايا، و`$A$1:$D$5` يحدد الخلايا من A1 إلى D5 بما فيها. تشير علامات الدولار إلى مراجع ثابتة للصف والعمود.

تقرأ الطريقة النطاق الحالي دون تغيير المخطط أو مصنفه. إذا لم يستخدم المخطط مصنفًا كمصدر للبيانات، فإنها تثير استثناءً. لمزيد من المعلومات، راجع [مرجع واجهة برمجة تطبيقات ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

يفتح هذا المثال عرضًا ويتفقد الأشكال مباشرةً في كل شريحة للبحث عن المخططات. يطبع اسم كل مخطط والنطاق المصدر. إذا تعذر استرجاع النطاق، يطبع رسالة تشخيصية ويستمر إلى المخطط التالي.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **قراءة وكتابة بيانات المخطط من مصنف**

توفر Aspose.Slides for Python via .NET طريقتي [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و[write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) التي تتيح لك قراءة وكتابة مصنفات بيانات المخطط (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط必须 أن تُنظم بنفس الطريقة أو يجب أن يكون لها بنية مشابهة للمصدر.

يستخدم هذا المثال عرضًا يحتوي على مخطط كأول شكل في شريحته الأولى. يقرأ المصنف المضمّن إلى تدفق، يمسح السلاسل والفئات الحالية، ويعيد كتابة المصنف نفسه. تبقى التغييرات في الذاكرة؛ لا يحفظ المثال العرض.

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

### **تحقق من تخطيط المخطط بعد تعديل المصنف**

عند استبدال مصنف مضمّن بآخر معدل، يحتفظ المخطط بسلسلته الأصلية ومجموعات الفئات. قد يتسبب هذا الازدواج في فشل [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) مع خطأ "index out of range". امسح السلاسل والفئات الحالية قبل كتابة المصنف المحدث إلى المخطط. يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى. العلامة التعليقية تشير إلى مكان تعديل المصنف؛ المثال القابل للتنفيذ يكتب المصنف الأصلي مرة أخرى ويُتحقق من التخطيط في الذاكرة.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # تعديل تدفق المصنف هنا، على سبيل المثال باستخدام Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

إزالة العناصر من المجموعات تحذف مراجع البيانات القديمة قبل كتابة المصنف مرة أخرى. أعد بناء أي سلاسل أو خرائط فئات ضرورية للمصنف المحدث قبل استخدام المخطط.

## **تعيين خلية مصنف كعلامة بيانات المخطط**

يمكنك استخدام النص الموجود في خلايا المصنف كعلامات بيانات للمخطط.

يضيف هذا المثال مخطط فقاعة مع بيانات افتراضية إلى الشريحة الأولى من عرض موجود. يستخدم الخلايا A10:A12 في ورقة العمل 0 لأول ثلاث علامات في السلسلة الأولى، يُفعّل العلامات من الخلايا، ويحفظ العرض المحدث.

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

توفر الخاصية [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) إمكانية الوصول إلى أوراق العمل في مصنف المخطط. ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

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

ينشئ هذا المثال مخطط عمودي ثلاثي الأبعاد ببيانات افتراضية ويضبط اسمين للسلاسل باستخدام مصادر بيانات مختلفة. الاسم الأول يستخدم قيمة نصية ثابتة؛ الاسم الثاني يستخدم الخلية C1 في ورقة العمل 0. يحدد تعداد [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) المصدر لكل اسم. يحفظ المثال العرض مع أسماء السلاسل المحدّثة.

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

## **كشف تنسيقات مصنفات مضمّنة غير مدعومة**

لا تدعم Aspose.Slides تنسيق المصنف الثنائي Excel (.xlsb) الذي يمكن تضمينه في بعض المخططات. يمكنك استخدام الخاصية [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) على [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) لاكتشاف التنسيقات غير المدعومة وتجاوز تلك المخططات. يفحص هذا المثال الأشكال في الشريحة الأولى من عرض موجود، يتخطى الأشكال غير المخططة، ويطبع رسالة تشخيصية لكل مخطط يحتوي على مصنف .xlsb مضمّن.

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

        # قراءة أو تعديل بيانات مصنف المخطط المدعومة هنا.
```

## **مصنف خارجي**

تدعم Aspose.Slides استخدام المصنفات الخارجية كمصدر بيانات للمخططات.

### **إنشاء مصنف خارجي**

استخدم [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) و[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) لتصدير مصنف مخطط مضمّن إلى ملف وربط المخطط بذلك المصنف الخارجي.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويصدّر مصنفه. يغلق تدفق الإخراج قبل تعيين المصنف الخارجي كمصدر بيانات للمخطط، ثم يحفظ العرض المرتبط.

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

### **تعيين مصنف خارجي**

باستخدام طريقة [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)، يمكنك تعيين مصنف خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار المصنف الخارجي (إذا تم نقل الملف).

على الرغم من أنك لا تستطيع تحرير البيانات في المصنفات المخزنة في مواقع أو موارد عن بُعد، إلا أنه لا يزال بإمكانك استخدام هذه المصنفات كمصدر بيانات خارجي. إذا تم تقديم المسار النسبي لمصنف خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

يستخدم هذا المثال مصنفًا خارجيًا تكون ورقة العمل المسماة `Sheet1` فيها اسم سلسلة في B1، وأسماء فئات في A2:A4، وقيم رقمية في B2:B4. ينشئ المخطط الدائري، يربط المصنف، ويستخدم [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) لتعيين النطاق A1:B4 إلى سلسلة واحدة وثلاث فئات. يحفظ العرض مع المخطط المرتبط.

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

معامل `update_chart_data` في طريقة [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) يتحكم فيما إذا كان سيتم تحميل المصنف.

* عندما يكون `update_chart_data` مساويًا لـ `False`، يتم تحديث مسار المصنف فقط. لا يتم تحميل بيانات المخطط أو تحديثها من المصنف الهدف، لذا يمكن أن يكون المصنف غير متاح.
* عندما يكون `update_chart_data` مساويًا لـ `True`، يتم تحديث بيانات المخطط من المصنف الهدف.

المثال التالي يعيّن عنوان URL نائب مع `update_chart_data` مضبوطًا على `False`. يحتفظ بالبيانات الافتراضية للمخطط الدائري ويحفظ العرض دون تحميل المصنف غير المتاح.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **الحصول على مسار مصنف مصدر البيانات الخارجي للمخطط**

لتحديد المصنف المرتبط بمخطط، تحقق مما إذا كان المخطط يستخدم مصدر بيانات خارجي واستخرج مسار المصنف.

يفحص هذا المثال الشكل الأول في الشريحة الأولى من عرض يحتوي على مصنف خارجي مرتبط. إذا كان المخطط مرتبطًا بمصنف خارجي، يطبع [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) إلى وحدة التحكم. ثم يحفظ نسخة من العرض.

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

### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في المصنفات الخارجية بنفس الطريقة التي تعدّل بها محتويات المصنفات الداخلية. عندما لا يمكن تحميل المصنف الخارجي، يتم طرح استثناء.

يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى ومربوطًا بمصنف خارجي يمكن الوصول إليه. يضبط قيمة النقطة البيانات الأولى في السلسلة الأولى إلى 100 ويحفظ العرض المحدث. تحرير قيم الخلايا يمكن أن يحدّث ملف XLSX الخارجي المرتبط، لذا استخدم نسخة إذا كنت بحاجة للحفاظ على المصنف الأصلي.

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

### **استعادة مصنف من ذاكرة المخطط المؤقتة**

إذا كان المخطط يستخدم مصنفًا خارجيًا مُفقودًا أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء مصنف المخطط من البيانات المخزنة مؤقتًا في العرض. أنشئ [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)، واضبط [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/)، وعين [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) إلى `True` قبل فتح العرض.

يعيد المثال التالي في Python استعادة بيانات المصنف لمخطط هو الشكل الأول في الشريحة الأولى ويشير إلى مصنف خارجي غير متاح. يصل إلى البيانات المستعادة عبر [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) و[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # قراءة أو تعديل بيانات المصنف المستعاد هنا.
    else:
        print("The first shape is not a chart.")
```

إذا كان المصنف الخارجي غير متاح وتم تعطيل الاستعادة، ترفع Aspose.Slides استثناءً. فعّل الاستعادة فقط عندما يكون الاعتماد على بيانات المخطط المخزنة مؤقتًا مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على تغييرات تم إجراؤها على المصنف الخارجي بعد آخر تحديث للعرض.

## **الأسئلة الشائعة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بمصنف خارجي أم مضمّن؟**

نعم. يحتوي المخطط على نوع مصدر البيانات [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) ومسار إلى مصنف خارجي [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); إذا كان المصدر مصنفًا خارجيًا، يمكنك قراءة المسار الكامل للتأكد من أن ملفًا خارجيًا يتم استخدامه.

**هل تدعم المسارات النسبية إلى المصنفات الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يُحوَّل تلقائيًا إلى مسار مطلق. يخزن العرض المسار المطلق في ملف PPTX، لذا قد يتطلب نقل المصنف تحديث الرابط.

**هل يمكنني استخدام المصنفات الموجودة على موارد الشبكة/المشاركات؟**

نعم، يمكن استخدام هذه المصنفات كمصدر بيانات خارجي. ومع ذلك، لا يدعم تحرير المصنفات البعيدة مباشرةً من Aspose.Slides—يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض؟**

يخزن العرض [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). يمكن لتعديل بيانات المخطط المستندة إلى الخلايا أيضًا تحديث ملف XLSX المحلي المرتبط. استخدم نسخة من المصنف إذا كان يجب أن يظل الأصل دون تغيير.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند الربط. من النهج الشائع إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) وربط تلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس المصنف الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا كانت جميع الروابط تشير إلى نفس الملف، فإن تحديث ذلك الملف سينعكس على كل مخطط عند تحميل البيانات مرة أخرى.