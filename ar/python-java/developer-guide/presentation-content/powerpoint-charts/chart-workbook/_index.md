---
title: إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام بايثون عبر جافا
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/python-java/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- ملصق البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة مخبأة للمخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "اكتشف Aspose.Slides لبايثون عبر جافا: إدارة سهلة لدفاتر عمل المخططات في صيغ PowerPoint وOpenDocument لتبسيط بيانات عرضك التقديمي."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع دفاتر العمل الخاصة بالمخططات في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كملصقات بيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر عمل خارجية كمصادر بيانات للمخططات. توضح الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر العمل الخارجي المرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

لخلايا دفتر العمل التي تمثل بيانات مفقودة، راجع [Control the Display of Empty Cells](/slides/ar/python-java/chart-series/) لمعرفة الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خطي لأوضاع العرض المتاحة.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**
توفر Aspose.Slides طرقًا هي [readWorkbookStream](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#readWorkbookStream) و[writeWorkbookStream](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#writeWorkbookStream) التي تتيح لك قراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو أن يكون لها بنية مشابهة للمصدر.

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

### **التحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مضمّن بآخر معدل، يحتفظ المخطط بمجموعات السلاسل والفئات الأصلية. هذا التناقض قد يتسبب في أن تقوم [Chart.validateChartLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#validateChartLayout) بإثارة `ArgumentOutOfRangeException` (parameter: index). لتجنب الاستثناء، امسح السلاسل والفئات الحالية **قبل** كتابة دفتر العمل المحدث مرة أخرى إلى المخطط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# قراءة دفتر العمل بعد تعديله (مثلاً باستخدام Aspose.Cells).
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

إفراغ المجموعات يضمن أن بنية بيانات المخطط تتطابق مع دفتر العمل الجديد، مما يسمح لـ[validateChartLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#validateChartLayout) بالانتهاء دون أخطاء.

## **تعيين خلية دفتر عمل كملصق بيانات المخطط**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة مخطط فقاعة مع بعض البيانات.
4. الوصول إلى سلاسل المخطط.
5. تعيين خلية دفتر العمل كملصق بيانات.
6. حفظ العرض التقديمي.

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

يوضح هذا الكود بايثون عملية يستخدم فيها طريقة [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/#getWorksheets) للوصول إلى مجموعة أوراق العمل:

```python
import jpython
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

يوضح هذا الكود بايثون كيفية تحديد نوع لمصدر البيانات:

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

## **اكتشاف صيغ دفاتر العمل المضمنة غير المدعومة**

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
            # المصنف المضمن بتنسيق .xlsb غير مدعوم.
            continue
        # قراءة أو تعديل بيانات مصنف المخطط هنا.
finally:
    presentation.dispose()
```

## **دفتر عمل خارجي**

تدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

باستخدام طرق [readWorkbookStream](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#readWorkbookStream) و[setExternalWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#setExternalWorkbook)، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو جعل دفتر عمل داخلي خارجيًا.

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

باستخدام طريقة [setExternalWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#setExternalWorkbook) يمكنك ربط دفتر عمل خارجي بمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

في حين لا يمكنك تعديل البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بعد، يمكنك الاستمرار في استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير المسار النسبي لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

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

* عندما تكون قيمته `False`، يتم تحديث مسار دفتر العمل فقط — لن يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل الهدف. قد ترغب في استخدام هذا الإعداد عندما يكون دفتر العمل الهدف غير موجود أو غير متاح.
* عندما تكون قيمته `True`، يتم تحديث بيانات المخطط من دفتر العمل الهدف.

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

### **الحصول على مسار دفتر العمل الخارجي لمصدر بيانات المخطط**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إنشاء كائن لشكل المخطط.
4. إنشاء كائن لنوع المصدر ([ChartDataSourceType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatasourcetype/)) الذي يمثل مصدر بيانات المخطط.
5. تحديد الشرط المناسب بناءً على كون نوع المصدر هو نفسه نوع مصدر دفتر العمل الخارجي.

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

يمكنك تحرير البيانات في دفاتر عمل خارجية بنفس الطريقة التي تقوم بها بتعديل محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يُثير استثناء.

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

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـAspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/)، وضعه مع [SpreadsheetOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/spreadsheetoptions/)، واستدعِ [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) مع `True` قبل فتح العرض التقديمي.

المثال التالي في بايثون يفتح عرضًا تقديميًا يرتبط مخططه بدفتر عمل خارجي غير متاح ويوصل إلى البيانات المستعادة عبر [Chart.getChartData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#getChartData) و[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

    # قراءة أو تعديل بيانات المصنف المستعاد هنا.
finally:
    presentation.dispose()
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، تُثير Aspose.Slides استثناءً. فعّل الاستعادة فقط عندما يكون استخدام بيانات المخطط المخزنة مؤقتًا كحل احتياطي مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مضمّن؟**

نعم. يمتلك المخطط [نوع مصدر بيانات](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getDataSourceType) و[مسار إلى دفتر عمل خارجي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية إلى دفاتر عمل خارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. هذا يُسهّل نقل المشروع؛ ومع ذلك، يجب أن تكون على علم بأن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكة؟**

نعم، يمكن استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير الدفاتر البعيدة مباشرةً—يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي نفسه عند حفظ العرض التقديمي.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند الربط. يُفضَّل إزالة الحماية مسبقًا أو تحضير نسخة غير مشفّرة (مثلاً باستخدام [Aspose.Cells](/cells/python-java/)) والربط بتلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. يخزن كل مخطط رابطه الخاص. إذا أشارت جميعها إلى نفس الملف، فإن تحديث ذلك الملف سينعكس في كل مخطط في المرة التالية التي يتم فيها تحميل البيانات.