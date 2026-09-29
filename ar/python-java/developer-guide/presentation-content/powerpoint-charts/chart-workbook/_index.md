---
title: "إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام Python عبر Java"
linktitle: "دفتر عمل المخطط"
type: docs
weight: 70
url: /ar/python-java/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- ملصق البيانات
- ورقة عمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة مخطط مؤقتة
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ Python عبر Java: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات عرضك التقديمي."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع دفاتر العمل الخاصة بالمخططات في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كملصقات بيانات للمخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر العمل الخارجية كمصادر بيانات للمخططات. تُظهر الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر العمل الخارجي المرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

لخلايا دفتر العمل التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/python-java/chart-series/) لمعرفة الفرق بين خلية فارغة وصفر، ومقارنة مخطط خطي لأوضاع العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) للتحكم فيما إذا كان المخطط يرسم البيانات من صفوف وأعمدة ورقة العمل المخفية. اضبطه على `True` لرسم الخلايا المرئية فقط، أو على `False` لتضمين كلًا من الخلايا المرئية والمخفية. هذه الإعدادات تتحكم في رسم المخطط؛ ولا تُخفِ أو تُظهر صفوف أو أعمدة ورقة العمل.

حمّل الملف [hidden-source-data.pptx](hidden-source-data.pptx) وضعه في دليل العمل. يحتوي الشريحة الأولى على مخطط عمودي كأول شكل. ورقة العمل المضمّنة، `Sheet1`، تحتوي على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما ما زالت تحتوي على قيم.

| صف ورقة العمل | A: الشهر | B: التجزئة | C: الجملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى خلايا المصدر من خلال [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getChartDataWorkbook) وقراءة [ChartDataCell.isHidden](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatacell/#isHidden) لفحص حالة الإخفاء. تُظهر هذه الطريقة حالة الإخفاء دون تغييرها. في هذا الملف، B2 مرئي، B3 ينتمي إلى الصف المخفي، وC2 ينتمي إلى العمود المخفي؛ تُظهر الأمثلة القيم `False`، `True`، و`True` على التوالي.

للتجربة، قم بتحديث بيانات المخطط بعد تغيير إعداد الرسم: احتفظ بدفتر العمل المضمّن باستخدام [readWorkbookStream](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#readWorkbookStream) وأعد تحميله باستخدام [writeWorkbookStream](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#writeWorkbookStream). عند تضمين كل الخلايا، استخدم أيضًا [setRange](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#setRange) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. مجرد تغيير العلامة لا يكفي لتحديث بيانات المخطط المخزّنة مؤقتًا وتصنيفات الفئات في هذه العينة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # تحديث بيانات المخطط من دفتر العمل المضمن.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # استعادة النطاق المصدر الكامل، بما في ذلك الفئات المخفية.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

تحفظ العينة `hidden_cells_True.pptx` بالقيم التجزئة المرئية فقط (10 و20)، و`hidden_cells_False.pptx` بكل القيم الستة. توضح الصور أدناه وضعَي الرسم. يظل الصف 3 والعمود C مخفيين في كلا دفترَي العمل المضمّنين.

| الخلايا المرئية فقط (`True`) | كل الخلايا (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#setDisplayBlanksAs) في طريقة عرض القيم المفقودة؛ ولا يضيف أو يحذف بيانات مصدر مخفية. راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/python-java/chart-series/#control-the-display-of-empty-cells) للحصول على مثال.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides for Python via Java طريقتي [readWorkbookStream](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#readWorkbookStream) و[writeWorkbookStream](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#writeWorkbookStream) اللتين تتيحان قراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو أن تكون لها بنية مشابهة للمصدر.

يفتح هذا المثال الملف `chart.pptx`، والذي يجب أن يحتوي على مخطط كأول شكل في شريحته الأولى. يقرأ دفتر العمل المضمّن إلى مصفوفة بايت، يمسح السلاسل والفئات الموجودة، ثم يكتب نفس دفتر العمل مرة أخرى. تظل التغييرات في الذاكرة؛ لا يقوم المثال بحفظ العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **تحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مضمّن بآخر معدّل، يحتفظ المخطط بسلاسل الفئات الأصلية. هذا الاختلاف يمكن أن يسبب فشل [Chart.validateChartLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#validateChartLayout) مع خطأ “index out of range”. امسح السلاسل والفئات الموجودة قبل كتابة دفتر العمل المحدث مرة أخرى إلى المخطط. يتطلب هذا المثال وجود `chart.pptx` يحتوي على مخطط كأول شكل في شريحته الأولى. يوضح التعليق مكان تحرير دفتر العمل؛ يكتب المثال دفتر العمل الأصلي مرة أخرى ويُصادق على التخطيط في الذاكرة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # عدّل بايتات دفتر العمل هنا، على سبيل المثال، باستخدام Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

مسح المجموعات يُزيل مراجع البيانات القديمة قبل كتابة دفتر العمل. أعد بناء أي سلاسل أو تعيينات فئات مطلوبة لدفتر العمل المحدث قبل استخدام المخطط.

## **تعيين خلية دفتر العمل كملصق بيانات للمخطط**

يمكنك استخدام النص من خلايا دفتر العمل كملصقات بيانات للمخطط. تُظهر الخطوات التالية كيفية ربط الملصقات في مخطط الفقاعات بالخلايا في دفتر بياناته.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. الوصول إلى الشريحة الأولى باستخدام فهرسها الصفري.
1. إضافة مخطط فقاعات ببيانات افتراضية.
1. الوصول إلى سلسلة المخطط.
1. تعيين خلية دفتر العمل كملصق بيانات.
1. حفظ العرض التقديمي.

يفتح هذا المثال الملف `chart2.pptx`، والذي يجب أن يحتوي على شريحة واحدة على الأقل، ويضيف مخطط فقاعات ببيانات افتراضية. يستخدم الخلايا A10:A12 في ورقة العمل 0 للملصقات الثلاث الأولى في السلسلة الأولى، يُفعِّل الملصقات من الخلايا، ويحفظ النتيجة إلى `resultchart.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إدارة أوراق العمل**

توفر الطريقة [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/#getWorksheets) إمكانية الوصول إلى أوراق العمل في دفتر عمل المخطط. يُنشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **تحديد نوع مصدر البيانات**

ينشئ هذا المثال مخططًا عموديًا ثلاثي الأبعاد ببيانات افتراضية ويضبط اسمي سلسلتين باستخدام مصادر بيانات مختلفة. الاسم الأول يستخدم قيمة نصية ثابتة؛ الاسم الثاني يستخدم الخلية C1 في ورقة العمل 0. تُحدِّد تعداد [DataSourceType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/datasourcetype/) المصدر لكل اسم. تُحفظ النتيجة إلى `pres.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **كشف صيغ دفاتر العمل المضمّنة غير المدعومة**

لا تدعم Aspose.Slides صيغة دفتر العمل الثنائي Excel (.xlsb) التي يمكن تضمينها في بعض المخططات. يمكنك استخدام طريقة [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) على [ChartData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/workbooktype/) لاكتشاف الصيغ غير المدعومة وتخطي تلك المخططات. تفحص هذه العينة الأشكال في الشريحة الأولى من `sample.pptx`، وتُهمل الأشكال غير المخططات، وتطبع رسالة تشخيص لكل مخطط يحتوي على دفتر عمل .xlsb مضمّن.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # قراءة أو تعديل بيانات دفتر عمل المخطط المدعومة هنا.
finally:
    presentation.dispose()
```

## **دفتر عمل خارجي**

تدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

استخدم [readWorkbookStream](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#readWorkbookStream) و[setExternalWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#setExternalWorkbook) لتصدير دفتر عمل مخطط مضمّن إلى ملف وربط المخطط بذلك الدفتر الخارجي.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية، يكتب دفتر عمله إلى `externalWorkbook1.xlsx`، وينتظر إكمال كتابة الملف قبل تعيينه كمصدر بيانات للمخطط. يحفظ العرض التقديمي المرتبط إلى `externalWorkbook.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تعيين دفتر عمل خارجي**

باستخدام طريقة [setExternalWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#setExternalWorkbook) يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الملف).

على الرغم من عدم إمكانية تحرير البيانات في دفاتر العمل المخزّنة في مواقع أو موارد بعيدة، لا يزال بإمكانك استخدامها كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يُحوَّل تلقائيًا إلى مسار كامل.

يتطلب هذا المثال وجود `externalWorkbook.xlsx` في دليل العمل. يجب أن تحتوي ورقة العمل المسماة `Sheet1` على اسم سلسلة في B1، وأسماء فئات في A2:A4، وقيم عددية في B2:B4. ينشئ المثال مخططًا دائريًا، يربط دفتر العمل، ويستخدم [setRange](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#setRange) لتعيين A1:B4 إلى سلسلة واحدة وثلاث فئات. يحفظ النتيجة إلى `Presentation_with_externalWorkbook.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

معامل `updateChartData` لطريقة [setExternalWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#setExternalWorkbook) يتحكم فيما إذا كان دفتر العمل يتم تحميله.

* عندما يكون `updateChartData` مساويًا لـ `False`، يتم تحديث مسار دفتر العمل فقط. لا يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل المستهدف، وبالتالي يمكن أن يكون دفتر العمل غير متاح.
* عندما يكون `updateChartData` مساويًا لـ `True`، تُحدَّث بيانات المخطط من دفتر العمل المستهدف.

تُظهر العينة التالية تعيين عنوان URL نائب مع `updateChartData` = `False`. يحتفظ بالمخطط الدائري ببياناته الافتراضية ويحفظ العرض التقديمي دون تحميل دفتر العمل غير المتاح.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **الحصول على مسار دفتر العمل الخارجي لمصدر البيانات لمخطط**

لتحديد دفتر العمل المرتبط بمخطط، تحقق أولاً ما إذا كان المخطط يستخدم مصدر بيانات خارجي. إذا كان كذلك، يمكنك استرجاع مسار دفتر العمل عبر الخطوات التالية.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. الوصول إلى الشريحة الأولى باستخدام فهرسها الصفري.
1. التأكد أن الشكل الأول هو مخطط.
1. قراءة نوع مصدر بيانات المخطط.
1. إذا كان المصدر دفتر عمل خارجي، قراءة مساره.

يفتح هذا المثال الملف `externalWorkbook.pptx`، الذي تم إنشاؤه في المثال السابق، ويفحص الشكل الأول في الشريحة الأولى. إذا كان مخططًا مرتبطًا بدفتر عمل خارجي، يطبع المثال [getExternalWorkbookPath](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) إلى وحدة التحكم. ثم يحفظ نسخة من العرض التقديمي إلى `Result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تُجري بها تغييرات على محتوى دفاتر العمل الداخلية. عند عدم إمكانية تحميل دفتر عمل خارجي، تُرفع استثناء.

يتطلب هذا المثال وجود `presentation.pptx` يحتوي على مخطط كأول شكل في شريحته الأولى ودفتر عمل خارجي يمكن الوصول إليه. يحدد قيمة النقطة البيانات الأولى في السلسلة الأولى إلى 100 ويحفظ العرض التقديمي إلى `presentation_out.pptx`. تحرير قيم الخلايا يمكن أن يُحدِّث ملف XLSX المرتبط، لذا استخدم نسخة إذا رغبت في الحفاظ على دفتر العمل الأصلي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **استعادة دفتر عمل من ذاكرة مخطط التخزين المؤقت**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزَّنة مؤقتًا في العرض التقديمي. أنشئ كائنًا من [LoadOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/)، استدعِ [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions)، واضبط [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) على `True` قبل فتح العرض التقديمي.

يفتح المثال التالي بلغة Python الملف `presentation.pptx`، حيث يجب أن يكون الشكل الأول في الشريحة الأولى مخططًا يشير إلى دفتر عمل خارجي غير متاح، ويصل إلى البيانات المستعادة عبر [Chart.getChartData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#getChartData) و[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # قراءة أو تعديل بيانات دفتر العمل المستعاد هنا.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، تُرفع Aspose.Slides استثناء. فعّل الاستعادة فقط عندما تكون الاستفادة من بيانات المخطط المخزَّنة مؤقتًا مقبولة، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط محدد مرتبط بدفتر عمل خارجي أو مضمّن؟**  
نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getDataSourceType) و[مسار دفتر عمل خارجي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية لدفاتر العمل الخارجية، وكيف تُخزَّن؟**  
نعم. إذا حددت مسارًا نسبيًا، يتحول تلقائيًا إلى مسار مطلق. يخزّن العرض التقديمي المسار المطلق في ملف PPTX، لذا قد يتطلب نقل دفتر العمل تحديث الارتباط.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد شبكة/مشاركات؟**  
نعم، يمكن استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يُدعم تحرير دفاتر العمل البعيدة مباشرةً من Aspose.Slides—they can only be used as a source.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**  
يخزّن العرض التقديمي [ارتباطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). قد يؤدي تحرير بيانات المخطط المستندة إلى الخلايا إلى تحديث ملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان الأصل يجب أن يبقى دون تغيير.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**  
لا تقبل Aspose.Slides كلمة مرور عند الربط. يفضَّل إزالة الحماية مسبقًا أو إعداد نسخة غير مشفَّرة (على سبيل المثال باستخدام [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) وربط تلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**  
نعم. كل مخطط يخزن ارتباطه الخاص. إذا أشار جميعها إلى نفس الملف، فإن تحديث هذا الملف سينعكس على كل مخطط عند تحميل البيانات مرة أخرى.