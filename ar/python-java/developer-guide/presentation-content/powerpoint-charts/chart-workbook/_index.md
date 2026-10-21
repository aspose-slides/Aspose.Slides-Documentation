---
title: إدارة مصنفات المخططات في العروض التقديمية باستخدام Python عبر Java
linktitle: مصنف المخطط
type: docs
weight: 70
url: /ar/python-java/chart-workbook/
keywords:
- مصنف مخطط
- بيانات المخطط
- خلية المصنف
- ملصق البيانات
- ورقة العمل
- مصدر البيانات
- مصنف خارجي
- بيانات خارجية
- ذاكرة مخبأة للمخطط
- استعادة المصنف
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "اكتشف Aspose.Slides for Python via Java: إدارة مصنفات المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات العرض التقديمي الخاصة بك."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع مصنفات المخطط في Aspose.Slides. توضح كيفية قراءة بيانات المخطط وكتابتها عبر تدفقات المصنف، واستخدام خلايا المصنف كملصقات بيانات للمخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع المصنفات الخارجية كمصادر بيانات للمخطط. توضح الأمثلة كيفية إنشاء وتعيين مصنف خارجي، واسترداد مسار مصنف خارجي مرتبط بمخطط، وتحرير بيانات المخطط عندما يتوفر المصنف.

للتعامل مع خلايا المصنف التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/python-java/chart-series/) لمعرفة الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خط للأنماط المتاحة للعرض.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) للتحكم فيما إذا كان المخطط يرسم بيانات من صفوف وأعمدة ورقة العمل المخفية. اضبطه على `True` لرسم الخلايا المرئية فقط، أو `False` لتضمين كل من الخلايا المرئية والمخفية. هذه الإعدادات تتحكم في رسم المخطط؛ لا تقوم بإخفاء أو إظهار صفوف أو أعمدة ورقة العمل.

يحتوي [عرض توضيحي](hidden-source-data.pptx) على مخطط عمودي كأول شكل في شريحةه الأولى. الورقة المدمجة، `Sheet1`، تحتوي على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما لا تزال تحتوي على قيم.

| صف ورقة العمل | A: الشهر | B: التجزئة | C: الجملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

يمكن الوصول إلى خلايا المصدر عبر [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) وقراءة [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) لفحص حالة الإخفاء الخاصة بها. تُعيد هذه الطريقة حالة الإخفاء دون تغييرها. في هذا الملف، B2 مرئية، B3 تنتمي إلى الصف المخفي، وC2 تنتمي إلى العمود المخفي؛ يطبع المثال `False`، `True`، و`True` على التوالي.

في هذا المثال، قم بتحديث بيانات المخطط بعد تغيير إعداد الرسم: احتفظ بالمصنف المدمج باستخدام [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) وأعيد تحميله باستخدام [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). عند تضمين جميع الخلايا، استخدم أيضًا [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. مجرد تغيير العلامة غير كافٍ لتحديث بيانات المخطط المخبأة وفئات الملصقات في هذا المثال.

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

            # تحديث بيانات المخطط من المصنف المدمج.
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

يحفظ المثال نسختين من العرض التقديمي: واحدة تحتوي فقط على قيم التجزئة المرئية (10 و 20)، وأخرى تحتوي على جميع القيم الستة. توضح الصور أدناه وضعيت الرسم. يظل الصف 3 والعمود C مخفيين في كلا المصنفين المدمجين.

| الخلايا المرئية فقط (`True`) | جميع الخلايا (`False`) |
| --- | --- |
| ![الخلايا المرئية فقط: قيم التجزئة 10 و 20 لشهري يناير ومارس.](hidden_cells_True.png) | ![جميع الخلايا: قيم التجزئة والجملة لشهري يناير، فبراير، ومارس.](hidden_cells_False.png) |

خلية مخفية تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) في كيفية عرض القيم المفقودة؛ لا يتضمن أو يستبعد بيانات المصدر المخفية. راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/python-java/chart-series/#control-the-display-of-empty-cells) للحصول على مثال.

## **استرجاع نطاق بيانات المخطط**

قبل تحديث بيانات المصنف في عرض تقديمي موجود، افحص نطاقات المصدر لتحديد خلايا ورقة العمل التي يستخدمها كل مخطط. تُعيد الطريقة [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) النطاق الحالي كصيغة مؤهلة للورقة، مثل `Sheet1!$A$1:$D$5`. هنا، `Sheet1` هو اسم الورقة، `!` يفصلها عن نطاق الخلايا، و`$A$1:$D$5` يحدّد الخلايا من A1 إلى D5 شاملًا. تشير علامات الدولار إلى مراجع صف وعمود مطلقة.

تقرأ الطريقة النطاق الحالي دون تغيير المخطط أو مصنفه. إذا لم يستخدم المخطط مصنفًا كمصدر للبيانات، فإنها تُثير استثناء `InvalidOperationException`. لمزيد من المعلومات، راجع [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

يفتح هذا المثال عرضًا تقديميًا ويفحص الأشكال مباشرة على كل شريحة للعثور على المخططات. يطبع اسم كل مخطط ونطاق المصدر. إذا لم يستخدم المخطط مصنفًا، يطبع رسالة ويتابع إلى المخطط التالي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **قراءة وكتابة بيانات المخطط من مصنف**

توفر Aspose.Slides for Python via Java طرق [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) و[writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) التي تسمح بقراءة وكتابة مصنفات بيانات المخطط (التي تحتوي على بيانات مخطط تم تعديلها باستخدام Aspose.Cells). **ملاحظة** يجب تنظيم بيانات المخطط بنفس الطريقة أو أن تكون لها بنية مشابهة للمصدر.

يستخدم هذا المثال عرضًا تقديميًا يحتوي على مخطط كأول شكل في شريحته الأولى. يقرأ المصنف المدمج إلى مصفوفة بايت، يمسح السلاسل والفئات الحالية، ويعيد كتابة المصنف نفسه. تبقى التغييرات في الذاكرة؛ لا يحفظ المثال العرض التقديمي.

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

### **التحقق من تخطيط المخطط بعد تعديل المصنف**

عند استبدال مصنف مدمج بآخر معدّل، يحتفظ المخطط بسلاسل الفئات ومجموعات الفئات الأصلية. هذا التفاوت قد يتسبب في فشل [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) مع خطأ "فهرس خارج النطاق". امسح السلاسل والفئات الحالية قبل كتابة المصنف المُحدّث مرة أخرى إلى المخطط. يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى. العلامة التعليقية تُظهر موضع تعديل المصنف؛ يكتب المثال القابل للتنفيذ المصنف الأصلي مرة أخرى ويتحقق من التخطيط في الذاكرة.

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

        # عدل بايتات المصنف هنا، على سبيل المثال باستخدام Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

إزالة المجموعات تُزيل مراجع البيانات البالية قبل كتابة المصنف مرة أخرى. أعد بناء أي سلاسل وفئات مطلوبة للمصنف المحدّث قبل استخدام المخطط.

## **ضبط تنسيقات الأرقام المخصصة لخلايا المصنف**

استخدم [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) للتحكم في طريقة ظهور القيم الرقمية في مصنف المخطط المدمج. على سبيل المثال، قد يحتاج تقرير إلى عرض معدل التحويل كنسبة مئوية بأربعة منازل عشرية ومعامل بخمسة منازل عشرية. حافظ على كلا القيمتين رقميًا بحيث تظل متاحة للحسابات ورسم المخطط.

تغير تنسيق الرقم العرض فقط، وليس القيمة المخزنة. يعرض التنسيق `0.0000%` القيمة `0.125` كـ `12.5000%`؛ لا يستبدل الرقم المخزن بـ `12.5`. بالمثل، يعرض التنسيق `0.00000` القيمة `0.1234567` كـ `0.12346` دون تقريب القيمة المخزنة. إذا كان التنسيق المخصص سلسلة فارغة (`""`)، يُستَخدم التنسيق الذي تُعيده [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) بدلاً منه.

ينشئ المثال التالي مخططًا عموديًا ويصل إلى خلاياه عبر [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook). في ورقة العمل 0، يحتوي B2 على معدل التحويل وC2 على المعامل. كلا الخليتين تزودان المخطط بالقيم. يُمكّن المثال أيضًا ملصقات القيم المرتبطة بالتنسيقات المصدرية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تنسيقات خلايا المصنف منفصلة عن التنسيقات المضبوطة مباشرة على محاور المخطط أو ملصقات البيانات. في هذا المثال، تعرض chaque ملصق قيمة خلية المصدر لأن [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) مُعيَّن إلى `True`، ويتبع تنسيق الرقم المصدر لأن [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) مُعيَّن إلى `True`. بعد حفظ وإعادة فتح العرض التقديمي، تُظهر الملصقات `12.5000%` و`0.12346` كما هو موضح أدناه. يستخدم المحور العمودي تنسيق عدد خاص به، يتم تعيينه بواسطة [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) كـ `0.00`، مع [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) مُعيَّن إلى `False`.

لتنسيق ملصق بيانات بشكل مستقل، عيّن علم ربط المصدر إلى `False` وعيّن تنسيقًا باستخدام [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat). لا يغيّر ذلك تنسيق خلية المصنف. على سبيل المثال، يُظهر تنسيق ملصق مستقل `0.00` القيمة الأولى كـ `0.13`، بينما لا يزال B2 يعرض `12.5000%`. راجع [ملصقات بيانات المخطط](/slides/ar/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) لتنسيق الملصق مباشرة.

الصورة أدناه تم توليدها من العرض التقديمي المحفوظ بعد إعادة فتحه:

![مخطط عمودي مع ملصقات مرتبطة بالمصدر تُظهر 12.5000% و 0.12346 ومحور عددٍ منسق بشكل مستقل.](custom-cell-formats.png)

## **استخدام خلية مصنف كملصق بيانات للمخطط**

يمكنك استخدام النص من خلايا المصنف كملصقات بيانات للمخطط.

يضيف هذا المثال مخطط فقاعي مع بيانات افتراضية إلى الشريحة الأولى من عرض تقديمي موجود. يستخدم الخلايا A10:A12 في ورقة العمل 0 للملصقات الثلاث الأولى في السلسلة الأولى، يُمكّن الملصقات من الخلايا، ويحفظ العرض المحدث.

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

توفر الطريقة [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) إمكانية الوصول إلى أوراق العمل في مصنف المخطط. ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

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

ينشئ هذا المثال مخططًا عموديًا ثلاثي الأبعاد ببيانات افتراضية ويعيّن اسمين للسلسلتين باستخدام مصادر بيانات مختلفة. يستخدم الاسم الأول قيمة نصية ثابتة؛ يستخدم الاسم الثاني الخلية C1 في ورقة العمل 0. يختار تعداد [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) المصدر لكل اسم. يحفظ المثال العرض التقديمي بالأسماء المحدثة للسلاسل.

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

## **كشف تنسيقات المصنف المدمجة غير المدعومة**

لا يدعم Aspose.Slides تنسيق المصنف الثنائي Excel (.xlsb) الذي يمكن دمجه في بعض المخططات. يمكنك استخدام طريقة [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) على [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) لاكتشاف التنسيقات غير المدعومة وتخطي تلك المخططات. يفحص هذا المثال الأشكال في الشريحة الأولى من عرض تقديمي موجود، يتخطى الأشكال غير المخططات، ويطبع رسالة تشخيصية لكل مخطط يحتوي على مصنف .xlsb مدمج.

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
        # قراءة أو تعديل بيانات مصنف المخطط المدعومة هنا.
finally:
    presentation.dispose()
```

## **مصنف خارجي**

يدعم Aspose.Slides استخدام المصنفات الخارجية كمصدر بيانات للمخططات.

### **إنشاء مصنف خارجي**

استخدم [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) و[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) لتصدير مصنف مخطط مدمج إلى ملف وربط المخطط بذلك المصنف الخارجي.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويصدر مصنفه. يكمل كتابة الملف قبل تعيين المصنف الخارجي كمصدر بيانات للمخطط، ثم يحفظ العرض المرتبط.

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

### **تعيين مصنف خارجي**

باستخدام طريقة [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) يمكنك تعيين مصنف خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار المصنف الخارجي (في حال تم نقل الأخير).

على الرغم من أنه لا يمكنك تحرير البيانات في المصنفات المخزنة في مواقع أو موارد بعيدًا، يمكنك الاستمرار في استخدام هذه المصنفات كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لمصنف خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

يستخدم هذا المثال مصنفًا خارجيًا تحتوي ورقة العمل المسماة `Sheet1` فيه على اسم سلسلة في B1، وأسماء فئات في A2:A4، وقيم رقمية في B2:B4. ينشئ المثال مخططًا دائريًا، يربط المصنف، ويستخدم [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) لتعيين A1:B4 إلى سلسلة واحدة وثلاث فئات. يحفظ العرض بالمخطط المرتبط.

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

معامل `updateChartData` في طريقة [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) يتحكم فيما إذا كان يتم تحميل المصنف.

* عندما يكون `updateChartData` مساويًا لـ `False`، يُحدَّث مسار المصنف فقط. لا يتم تحميل بيانات المخطط أو تحديثها من المصنف الهدف، وبالتالي يمكن أن يكون المصنف غير متاح.
* عندما يكون `updateChartData` مساويًا لـ `True`، تُحدَّث بيانات المخطط من المصنف الهدف.

يعين المثال التالي عنوان URL نائب مع `updateChartData` مضبوطًا على `False`. يحتفظ بالبيانات الافتراضية للمخطط الدائري ويحفظ العرض دون تحميل المصنف غير المتاح.

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

### **الحصول على مسار مصنف مصدر البيانات الخارجي لمخطط**

لتحديد المصنف المرتبط بمخطط، تحقق مما إذا كان المخطط يستخدم مصدر بيانات خارجي واستخرج مسار المصنف.

يفحص هذا المثال الشكل الأول في الشريحة الأولى من عرض تقديمي يحتوي على مصنف خارجي مرتبط. إذا كان مخططًا مرتبطًا بمصنف خارجي، يطبع [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) إلى وحدة التحكم. ثم يحفظ نسخة من العرض التقديمي.

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

يمكنك تحرير البيانات في المصنفات الخارجية بنفس الطريقة التي تجري بها تغييرات على محتويات المصنفات الداخلية. عندما لا يمكن تحميل مصنف خارجي، يُطرح استثناء.

يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى ومربوطًا بمصنف خارجي متاح. يعين قيمة الخلية للنقطة البيانات الأولى في السلسلة الأولى إلى 100 ويحفظ العرض المحدث. يمكن لتحرير قيم الخلايا تحديث ملف XLSX الخارجي المرتبط، لذا يُنصح باستخدام نسخة إذا كنت بحاجة للحفاظ على المصنف الأصلي.

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

### **استعادة مصنف من ذاكرة التخزين المؤقت للمخطط**

إذا كان المخطط يستخدم مصنفًا خارجيًا مفقودًا أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء مصنف المخطط من البيانات المخزنة مؤقتًا في العرض. أنشئ كائنًا من [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/)، استدعِ [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions)، واضبط [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) إلى `True` قبل فتح العرض.

يستعيد المثال التالي بلغة Python بيانات المصنف لمخطط هو الشكل الأول في الشريحة الأولى ويشير إلى مصنف خارجي غير متاح. يصل إلى البيانات المستعادة عبر [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) و[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        # قراءة أو تعديل بيانات المصنف المستعاد هنا.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

إذا كان المصنف الخارجي غير متاح وتم تعطيل الاستعادة، تُطرح Aspose.Slides استثناء. فعِّل الاستعادة فقط عندما يكون استخدام البيانات المخزنة مؤقتًا كحل مقبول، لأن الذاكرة المؤقتة قد لا تحتوي على تغييرات أُجريت على المصنف الخارجي بعد آخر تحديث للعرض.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بمصنف خارجي أو مدمج؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) و[مسار إلى مصنف خارجي](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)؛ إذا كان المصدر مصنفًا خارجيًا، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية للمصنفات الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. يخزن العرض المسار المطلق في ملف PPTX، لذا قد يتطلب نقل المصنف تحديث الرابط.

**هل يمكنني استخدام مصنفات موجودة على موارد/مشاركات شبكة؟**

نعم، يمكن استخدام مثل هذه المصنفات كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير المصنفات البعيدة مباشرةً—يمكن استخدامها فقط كمصدر.

**هل يقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض؟**

يخزن العرض [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). يمكن لتعديل بيانات المخطط المرتبطة بالخلية أيضًا تحديث ملف XLSX المحلي المرتبط. استخدم نسخة من المصنف إذا كان من الضروري إبقاء الأصلي دون تغيير.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

Aspose.Slides لا يقبل كلمة مرور عند الربط. عادةً ما يتم إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (مثلاً باستخدام [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) وربط تلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس المصنف الخارجي؟**

نعم. يخزن كل مخطط رابطه الخاص. إذا كانت جميع الروابط تشير إلى نفس الملف، سيظهر أي تعديل لهذا الملف في كل مخطط في المرة التالية التي يتم فيها تحميل البيانات.