---
title: إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام Python عبر Java
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/python-java/chart-workbook/
keywords:
- دفتر عمل مخطط
- بيانات مخطط
- خلية دفتر عمل
- ملصق بيانات
- ورقة عمل
- مصدر بيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة مخطط مؤقتة
- استعادة دفتر عمل
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ Python عبر Java: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات العرض التقديمي."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع دفاتر العمل الخاصة بالمخططات في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كملصقات بيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر العمل الخارجية كمصادر بيانات للمخطط. توضح الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر العمل الخارجي المرتبط بمخطط، وتحرير بيانات المخطط عندما يكون دفتر العمل متاحًا.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides طريقة [readWorkbookStream](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#readWorkbookStream) وطريقة [writeWorkbookStream](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#writeWorkbookStream) التي تسمح لك بقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات المخطط التي تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو يجب أن يكون لها هيكل مشابه للمصدر.

هذا الكود بلغة Python يوضح عملية نموذجية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **تحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مدمج بآخر معدل، يحتفظ المخطط بسلسلاته ومجموعات الفئات الأصلية. قد يتسبب هذا التناقض في حدوث خطأ في [Chart.validateChartLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#validateChartLayout) يطرح استثناء `ArgumentOutOfRangeException` (المعامل: index). لتجنب الاستثناء، يجب مسح السلاسل والفئات الحالية **قبل** كتابة دفتر العمل المحدَّث مرة أخرى إلى المخطط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# قراءة دفتر العمل بعد تعديلها (مثلاً باستخدام Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # مسح مراجع البيانات الحالية.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

يمكّن مسح المجموعات من ضمان توافق بنية بيانات المخطط مع دفتر العمل الجديد، مما يسمح لـ[validateChartLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#validateChartLayout) بالانتهاء دون أخطاء.

## **تعيين خلية دفتر عمل كملصق بيانات المخطط**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة مخطط فقاعة مع بعض البيانات.
1. الوصول إلى سلسلة المخطط.
1. تعيين خلية دفتر العمل كملصق بيانات.
1. حفظ العرض التقديمي.

هذا الكود بلغة Python يوضح كيفية تعيين خلية دفتر عمل كملصق بيانات المخطط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
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

هذا الكود بلغة Python يوضح عملية حيث يتم استخدام طريقة [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/#getWorksheets) للوصول إلى مجموعة أوراق العمل:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **تحديد نوع مصدر البيانات**

هذا الكود بلغة Python يوضح كيفية تحديد نوع لمصدر البيانات:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **اكتشاف صيغ دفاتر العمل المضمّنة غير المدعومة**

لا تدعم Aspose.Slides صيغة دفتر العمل الثنائي Excel (.xlsb) التي يمكن تضمينها في بعض المخططات. يمكنك استخدام طريقة [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) على [ChartData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/workbooktype/) لاكتشاف الصيغ غير المدعومة وتخطي تلك المخططات.

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
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # دفتر العمل المدمج بتنسيق .xlsb غير مدعوم.
            continue
        # اقرأ أو عدّل بيانات دفتر عمل المخطط هنا.
finally:
    presentation.dispose()
```

### **إنشاء دفتر عمل خارجي**

باستخدام طريقة [readWorkbookStream](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#readWorkbookStream) وطريقة [setExternalWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#setExternalWorkbook)، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى خارجي.

هذا الكود بلغة Python يوضح عملية إنشاء دفتر عمل خارجي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تعيين دفتر عمل خارجي**

باستخدام طريقة [setExternalWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#setExternalWorkbook) يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

في حين لا يمكنك تعديل البيانات في دفاتر العمل المخزنة في مواقع بعيدة أو موارد، لا يزال بإمكانك استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر العمل الخارجي، يتم تحويله إلى مسار كامل تلقائيًا.

هذا الكود بلغة Python يوضح كيفية تعيين دفتر عمل خارجي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

المعامل الثاني (`bool`) لطريقة [setExternalWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#setExternalWorkbook) يُستخدم لتحديد ما إذا كان سيتم تحميل دفتر عمل Excel أم لا.

* عندما تكون قيمته `False`، يتم فقط تحديث مسار دفتر العمل—لن يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل المستهدف. قد تحتاج إلى هذا الإعداد عندما يكون دفتر العمل المستهدف غير موجود أو غير متاح.
* عندما تكون قيمته `True`، يتم تحديث بيانات المخطط من دفتر العمل المستهدف.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **الحصول على مسار دفتر عمل مصدر البيانات الخارجي لمخطط**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إنشاء كائن لشكل المخطط.
1. إنشاء كائن لنوع المصدر ([ChartDataSourceType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatasourcetype/)) الذي يمثل مصدر بيانات المخطط.
1. تحديد الشرط المناسب بناءً على كون نوع المصدر هو نفسه نوع مصدر البيانات لدفتر العمل الخارجي.

هذا الكود بلغة Python يوضح العملية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تعدل بها محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر العمل الخارجي، يُطرح استثناء.

هذا الكود بلغة Python هو تنفيذ للعملية الموضحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **استعادة دفتر عمل من ذاكرة التخزين المؤقت للمخطط**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متوفر، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ كائنًا من [LoadOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/)، واضبطه باستخدام [SpreadsheetOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/spreadsheetoptions/)، ثم استدعِ [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) بالقيمة `True` قبل فتح العرض التقديمي.

المثال التالي بلغة Python يفتح عرضًا تقديميًا يرتبط مخططه بدفتر عمل خارجي غير متاح، ويصل إلى البيانات المستعادة عبر [Chart.getChartData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#getChartData) و[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # قراءة أو تعديل بيانات دفتر العمل المستعاد هنا.
finally:
    presentation.dispose()
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، تُطرح Aspose.Slides استثناء. فعّل الاستعادة فقط عندما يكون استخدام البيانات المخزنة مؤقتًا للمخطط خيارًا مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتداولة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مضمن؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getDataSourceType) و[مسار إلى دفتر عمل خارجي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا قمت بتحديد مسار نسبي، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مفيد لقابلية نقل المشروع؛ ومع ذلك، يجب الانتباه إلى أن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر العمل الموجودة على موارد/مشاركات الشبكة؟**

نعم، يمكن استخدام هذه الدفاتر كمصدر بيانات خارجي. غير أن تحرير الدفاتر البعيدة مباشرةً من Aspose.Slides غير مدعوم—يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي نفسه عند حفظ العرض التقديمي.

**ماذا يجب أن أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

Aspose.Slides لا تقبل كلمة مرور عند الربط. النهج الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](/cells/python-java/)) وربط تلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا أشار جميعها إلى نفس الملف، فإن تحديث ذلك الملف سيظهر في كل مخطط عند تحميل البيانات في المرة التالية.