---
title: إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام Python عبر Java
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/python-java/chart-workbook/
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
- Java
- Aspose.Slides
description: "اكتشف Aspose.Slides for Python عبر Java: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات العرض التقديمي الخاصة بك."
---
## **نظرة عامة**

هذه المقالة توضح كيفية العمل مع دفاتر عمل المخطط في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر العمل الخارجية كمصادر بيانات للمخططات. تُظهر الأمثلة كيفية إنشاء دفتر عمل خارجي وتعيينه، واسترجاع مسار دفتر عمل خارجي مرتبط بمخطط، وتحرير بيانات المخطط عندما يكون دفتر العمل متوفرًا.

لخلايا دفتر العمل التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/python-java/chart-series/) للفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خط بين أوضاع العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) للتحكم فيما إذا كان المخطط يرسم البيانات من الصفوف والأعمدة المخفية في ورقة العمل. عيّنها إلى `True` لرسم الخلايا المرئية فقط، أو إلى `False` لتضمين كل من الخلايا المرئية والمخفية. هذه الإعدادات تتحكم في رسم المخطط؛ لا تقوم بإخفاء أو إظهار صفوف أو أعمدة ورقة العمل.

[عينة العرض التقديمي](hidden-source-data.pptx) يحتوي على مخطط عمودي كأول شكل في شغلته الأولى. ورقة العمل المدمجة، `Sheet1`، تحتوي على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما لا تزال تحتوي على قيم.

| صف ورقة العمل | A: الشهر | B: التجزئة | C: الجملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى خلايا المصدر عبر [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) وقراءة [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) لفحص حالة الإخفاء. تُعيد هذه الطريقة حالة الإخفاء دون تعديلها. في هذا الملف، B2 مرئية، B3 تنتمي إلى الصف المخفي، وC2 تنتمي إلى العمود المخفي؛ المثال يطبع `False`، `True`، و`True` على التوالي.

في هذا المثال، يُحديث بيانات المخطط بعد تغيير إعداد الرسم: احتفظ بدفتر العمل المدمج باستخدام [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) وأعد تحميله بـ [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). عند تضمين كل الخلايا، استخدم أيضًا [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. مجرد تغيير العلامة غير كافٍ لتحديث بيانات المخطط المخزنة مؤقتًا وتسميات الفئات في هذا العينة.

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

            # تحديث بيانات المخطط من دفتر العمل المدمج.
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

يحفظ المثال نسختين من العرض التقديمي: واحدة تحتوي فقط على قيم التجزئة المرئية (10 و20)، والأخرى تحتوي على جميع القيم الست. توضح الصور أدناه وضعتي الرسم. يظل الصف 3 والعمود C مخفيين في كل من دفاتر العمل المدمجة.

| الخلايا المرئية فقط (`True`) | كل الخلايا (`False`) |
| --- | --- |
| ![الخلايا المرئية فقط: قيم التجزئة 10 و 20 لشهري يناير ومارس.](hidden_cells_True.png) | ![كل الخلايا: قيم التجزئة والجملة لشهري يناير، فبراير، ومارس.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) في كيفية عرض القيم المفقودة؛ لا يتضمن أو يستبعد البيانات المصدر المخفية. راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/python-java/chart-series/#control-the-display-of-empty-cells) لمثال.

## **استخراج نطاق بيانات المخطط**

قبل تحديث بيانات دفتر العمل في عرض تقديمي موجود، افحص نطاقات المصدر لتحديد خلايا ورقة العمل التي يستخدمها كل مخطط. تُعيد طريقة [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) النطاق الحالي للبيانات كصيغة مؤهلة بورقة العمل، مثل `Sheet1!$A$1:$D$5`. هنا، `Sheet1` هو اسم ورقة العمل، `!` يفصلها عن نطاق الخلايا، و`$A$1:$D$5` يحدد الخلايا من A1 إلى D5 شاملًا. تشير علامات الدولار إلى مراجع مطلقة للصف والعمود.

تقرأ الطريقة النطاق الحالي دون تغيير المخطط أو دفتر العمل الخاص به. إذا لم يستخدم المخطط دفتر عمل كمصدر للبيانات، فإنها تُطلق استثناء `InvalidOperationException`. لمزيد من المعلومات، راجع [مرجع API لChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

هذا المثال يفتح عرضًا تقديميًا ويفحص الأشكال مباشرةً على كل شريحة بحثًا عن المخططات. يطبع اسم كل مخطط ونطاق المصدر. إذا لم يستخدم مخطط دليل عمل، يطبع رسالة ويستمر إلى المخطط التالي.

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

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides for Python via Java طرق [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) و[writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) التي تسمح بقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تُنظم بنفس الطريقة أو يجب أن يكون لها بنية مشابهة للمصدر.

يستخدم هذا المثال عرضًا تقديميًا يحتوي على مخطط كأول شكل في شغلته الأولى. يقرأ دفتر العمل المدمج إلى مصفوفة بايت، يمسح السلاسل والفئات الحالية، ثم يكتب دفتر العمل نفسه مرة أخرى. تبقى التغييرات في الذاكرة؛ لا يقوم المثال بحفظ العرض التقديمي.

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

### **التحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مدمج بآخر معدل، يحتفظ المخطط بسلسلاته ومجموعات فئاته الأصلية. هذا التناقض قد يسبب فشل [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) مع خطأ خارج النطاق. امسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدث مرة أخرى إلى المخطط. يستخدم هذا المثال مخططًا كأول شكل على الشريحة الأولى. العلامة في التعليق توضح مكان تعديل دفتر العمل؛ المثال القابل للتنفيذ يكتب دفتر العمل الأصلي مرة أخرى وي validates التخطيط في الذاكرة.

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

        # قم بتعديل بايتات دفتر العمل هنا، على سبيل المثال، باستخدام Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

إزالة المجموعات تُزيل مراجع البيانات القديمة قبل كتابة دفتر العمل مرة أخرى. أعد بناء أي سلاسل أو تخطيطات فئات مطلوبة لدفتر العمل المحدث قبل استخدام المخطط.

## **تعيين صيغ أرقام مخصصة لخلايا دفتر العمل**

استخدم [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) للتحكم في كيفية ظهور القيم الرقمية في دفتر عمل المخطط المدمج. على سبيل المثال، قد يحتاج تقرير إلى عرض معدل تحويل كنسبة مئوية بأربعة منازل عشرية ومعامل بخمسة منازل عشرية. احتفظ بالقيمتين كأرقام لتظل متاحة للحسابات ورسم المخطط.

صيغة الرقم تُغيّر العرض فقط، لا القيم المخزنة. الصيغة `0.0000%` تعرض `0.125` كـ `12.5000%`؛ لا تستبدل العدد المخزن بـ `12.5`. بالمثل، `0.00000` تُظهر `0.1234567` كـ `0.12346` دون تقريب القيمة المخزنة. إذا كانت الصيغة المخصصة سلسلة فارغة (`""`)، تُستخدم الصيغة التي تُرجعها [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) بدلاً منها.

المثال التالي يُنشئ مخططًا عموديًا ويصل إلى خلاياه عبر [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook). في ورقة العمل 0، B2 يحتوي على معدل التحويل وC2 يحتوي على المعامل. كلتا الخليتين تُزودان المخطط بالقيم. يُمكّن المثال أيضًا تسميات القيم المرتبطة بصيغ المصدر.

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

تنسيقات خلايا دفتر العمل منفصلة عن التنسيقات المطبقة مباشرةً على محاور المخطط أو تسميات البيانات. في هذا المثال، كل تسمية تعرض قيمة خلية المصدر لأن [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) مُعيَّنة إلى `True`، وتتبع صيغة الرقم المصدر لأن [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) مُعيَّنة إلى `True`. بعد حفظ وإعادة فتح العرض التقديمي، تُظهر التسميات `12.5000%` و`0.12346` كما هو موضح أدناه. يستخدم المحور العمودي صيغة رقم خاصة به، مُعينة بـ [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) كـ `0.00`، مع [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) مُعيَّنة إلى `False`.

لتنسيق تسمية بيانات بشكل مستقل، عيّن علم الارتباط بالمصدر إلى `False` وعيّن صيغة باستخدام [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat). لا يُغيّر هذا تنسيق خلية دفتر العمل. على سبيل المثال، صيغة تسمية مستقلة `0.00` تُظهر القيمة الأولى كـ `0.13`، بينما لا يزال B2 يُظهر `12.5000%`. راجع [تسميات بيانات المخطط](/slides/ar/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) لتنسيق التسميات مباشرةً.

![مخطط عمودي بتسميات مرتبطة بالمصدر تُظهر 12.5000% و0.12346 ومحور رقمي بتنسيق مستقل.](custom-cell-formats.png)

## **تعيين خلية دفتر العمل كعنوان بيانات للمخطط**

يمكنك استخدام النص من خلايا دفتر العمل كعناوين بيانات للمخطط.

يضيف هذا المثال مخطط فقاعات ببيانات افتراضية إلى الشريحة الأولى من عرض تقديمي موجود. يستخدم الخلايا A10:A12 في ورقة العمل 0 كالعناوين الثلاثة الأولى في السلسلة الأولى، يمكّن العناوين من الخلايا، ويحفظ العرض التقديمي المحدث.

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

توفر طريقة [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) إمكانية الوصول إلى أوراق العمل في دفتر عمل مخطط. ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

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

يمكن أيضًا تخزين قيم نقاط السلسلة مباشرةً كقوامير رقمية. راجع [Set Series Values Using Numeric Literals](/slides/ar/python-java/chart-series/#set-series-values-using-numeric-literals) لمثال كامل يحفظ القيم ويقرأها. نوع مصدر قيم النقاط منفصل عن تكوين دفتر العمل الداخلي أو الخارجي للمخطط؛ استخدام القوامير الرقمية لا يزيل دفتر العمل المدمج بحد ذاته.

هذا المثال يُنشئ مخططًا عموديًا ثلاثي الأبعاد ببيانات افتراضية ويُعيّن اسمين للسلسلتين باستخدام مصادر بيانات مختلفة. الاسم الأول يستخدم قوامٍ نصي؛ الثاني يستخدم الخلية C1 في ورقة العمل 0. يختار تعداد [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) المصدر لكل اسم. يحفظ المثال العرض التقديمي بأسماء السلاسل المحدثة.

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

## **اكتشاف تنسيقات دفاتر العمل المدمجة غير المدعومة**

لا تدعم Aspose.Slides تنسيق دفتر العمل الثنائي Excel (.xlsb) الذي يمكن تضمينه في بعض المخططات. يمكنك استخدام طريقة [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) على [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) لاكتشاف التنسيقات غير المدعومة وتخطي تلك المخططات. يفحص هذا المثال الأشكال على الشريحة الأولى من عرض تقديمي موجود، يتخطى الأشكال غير المخططة، ويطبع رسالة تشخيص لكل مخطط يحتوي على دفتر عمل .xlsb مدمج.

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
        # اقرأ أو عدّل بيانات دفتر العمل المدعومة للمخطط هنا.
finally:
    presentation.dispose()
```

## **دفتر عمل خارجي**

يدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

استخدم [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) و[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) لتصدير دفتر عمل مخطط مدمج إلى ملف وربط المخطط بذلك الدفتر الخارجي.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويصدر دفتر عمله. يُكمل كتابة الملف قبل تعيين دفتر العمل الخارجي كمصدر بيانات للمخطط، ثم يحفظ العرض التقديمي المرتبط.

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

باستخدام طريقة [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook)، يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

على الرغم من أنه لا يمكنك تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، لا يزال بإمكانك استخدامها كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتحول تلقائيًا إلى مسار كامل.

يستخدم هذا المثال دفتر عمل خارجي تحتوي ورقة عمله المسماة `Sheet1` على اسم سلسلة في B1، وأسماء فئات في A2:A4، وقيم رقمية في B2:B4. يُنشئ المثال مخططًا دائريًا، يربط دفتر العمل، ويستخدم [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) لتعيين A1:B4 لسلسلة واحدة وثلاث فئات. يحفظ العرض التقديمي بالمخطط المرتبط.

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

معامل `updateChartData` في [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) يتحكم فيما إذا كان دفتر العمل يُحمَّل.

* عندما يكون `updateChartData` مساويًا لـ `False`، يتم تحديث مسار دفتر العمل فقط. لا تُحمَّل بيانات المخطط أو تُحدَّث من دفتر العمل الهدف، لذا يمكن أن يكون دفتر العمل غير متوفر.
* عندما يكون `updateChartData` مساويًا لـ `True`، تُحدَّث بيانات المخطط من دفتر العمل الهدف.

المثال التالي يعيّن عنوان URL نائب مع `updateChartData` مُعيَّن إلى `False`. يحتفظ بالبيانات الافتراضية للمخطط الدائري ويحفظ العرض التقديمي دون تحميل دفتر العمل غير المتوفر.

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

### **الحصول على مسار دفتر عمل مصدر البيانات الخارجي للمخطط**

لتحديد دفتر العمل المرتبط بمخطط، تحقق مما إذا كان المخطط يستخدم مصدرًا خارجيًا واسترجع مسار دفتر العمل.

يفحص هذا المثال أول شكل على الشريحة الأولى من عرض تقديمي مرتبط بدفتر عمل خارجي. إذا كان مخططًا مرتبطًا بدفتر عمل خارجي، يطبع [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) إلى وحدة التحكم. ثم يحفظ نسخة من العرض التقديمي.

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

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تُجري بها تغييرات على محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يُلقى استثناء.

يستخدم هذا المثال مخططًا كأول شكل على الشريحة الأولى ومربوطًا بدفتر عمل خارجي يمكن الوصول إليه. يعيّن القيمة المدعومة بالخلية للنقطة البيانات الأولى في السلسلة الأولى إلى 100 ويحفظ العرض التقديمي المحدث. تحرير قيم الخلايا يمكن أن يحدث ملف XLSX الخارجي المرتبط، لذا استعمل نسخة إذا كنت بحاجة للاحتفاظ بالدفتر الأصلي.

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

### **استعادة دفتر عمل من ذاكرة مخطط**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متوفر، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/)، استدعِ [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions)، وعين [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) إلى `True` قبل فتح العرض التقديمي.

المثال التالي بلغة Python يستعيد بيانات دفتر العمل لمخطط هو الشكل الأول على الشريحة الأولى ويشير إلى دفتر عمل خارجي غير متوفر. يصل إلى البيانات المستعادة عبر [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) و[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        # اقرأ أو عدل بيانات دفتر العمل المستعاد هنا.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

إذا كان دفتر العمل الخارجي غير متوفر وتم تعطيل الاستعادة، تُطلق Aspose.Slides استثناء. فعل الاستعادة فقط عندما يكون استخدام بيانات المخطط المخزنة مؤقتًا كحل مقبول، لأن الذاكرة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني معرفة ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مدمج؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) و[مسار إلى دفتر عمل خارجي](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. يخزن العرض التقديمي المسار المطلق في ملف PPTX، لذا قد يتطلب نقل دفتر العمل تحديث الرابط.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكة؟**

نعم، يمكن استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يُدعم تحرير دفاتر العمل البعيدة مباشرةً من Aspose.Slides—يمكن فقط استخدامها كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). يمكن لتحرير بيانات المخطط المدعومة بالخلية أيضًا تحديث ملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان الأصلي يجب أن يبقى دون تغيير.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند الربط. يُنصح بإزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) وربطها بهذه النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. يخزن كل مخطط رابطًا خاصًا به. إذا كان جميعها يشير إلى نفس الملف، سيُعكس أي تحديث لهذا الملف في كل مخطط عند تحميل البيانات مرة أخرى.