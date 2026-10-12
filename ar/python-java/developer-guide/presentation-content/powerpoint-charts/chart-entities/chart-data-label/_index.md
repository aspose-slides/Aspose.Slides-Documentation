---
title: إدارة تسميات بيانات المخطط في العروض التقديمية باستخدام بايثون
linktitle: تسمية البيانات
type: docs
url: /ar/python-java/chart-data-label/
keywords:
- مخطط
- تسمية بيانات
- دقة البيانات
- نسبة مئوية
- مسافة التسمية
- موقع التسمية
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق تسميات بيانات المخطط في عروض PowerPoint التقديمية باستخدام Aspose.Slides للبايثون عبر Java للحصول على شرائح أكثر جاذبية."
---
## **المقدمة**

تظهر تسميات البيانات معلومات حول سلاسل المخطط ونقاط البيانات الفردية، مما يساعد القراء على تحديد القيم وفهم المخطط. تشرح هذه المقالة كيفية تنسيق القيم، وعرض النسب المئوية، وقراءة نص التسمية، والتحكم بالتسميات خارج الحد الأقصى للمحور، وضبط التباعد بين تسميات محور الفئات، وتحديد موضع تسميات مخطط الفطيرة.

## **ضبط دقة البيانات في تسميات مخطط البيانات**

استخدم [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) لتنسيق قيم السلسلة. يُنشئ هذا المثال مخططًا خطيًا ببيانات افتراضية، يعرض جدول البيانات الخاص به، ويفعل تسميات القيم للسلسلة الأولى. التنسيق `#,##0.00` يُظهر فاصل الآلاف ومكانين عشريين دون تغيير القيم الأساسية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **عرض النسبة المئوية كعناوين**

للمخطط العمودي المتجمع، احسب كل قيمة كنسبة مئوية من إجمالي الفئة الخاصة بها وعيّن النص لإطار النص الذي تُعيده [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). يستخدم هذا المثال بيانات المخطط الافتراضية ويعرض النسب المئوية بمكانين عشريين بخط 8 نقاط. تُجاهل الفئات التي يكون مجموعها صفرًا لتفادي القسمة على الصفر. أعد حساب نص التسمية المخصص إذا تغيرت بيانات المخطط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ضبط علامة النسبة المئوية في تسميات مخطط البيانات**

عند تخزين القيم ككسور، استخدم [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) لعرض النسب المئوية. مرّر `False` إلى [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) لتطبيق تنسيق التسمية بشكل مستقل عن الخلايا المصدر.

هذا المثال ينشئ مخططًا عموديًا متجمعًا بنسبة 100% مع سلاسل حمراء وزرقاء عبر أربع فئات. كل زوج من القيم يساوي 1. تنسيق التسمية `0.0%` يعرض 0.30 كـ30.0%، بينما يستخدم المحور الرأسي مكانين عشريين. تستخدم السلسلتان اللون الأبيض ونص تسمية بحجم 10 نقاط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **قراءة النص الفعلي لتسميات البيانات**

استخدم [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) لاسترجاع النص الذي ينتجه إعدادات تسمية البيانات. هذا مفيد عند استخراج التسميات للتقارير، أو البحث في محتوى العرض، أو التحقق من صحة المخططات المولدة. في المثال أدناه، يجمع [تنسيق تسمية البيانات](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) الافتراضي كل من اسم الفئة، اسم السلسلة، والقيمة. ينسق أحد النقاط قيمته كنسبة مئوية، وآخر يستخدم نصًا مخصصًا من [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

يظل الرقم المخزن في نقطة البيانات `0.75`، حتى عندما تُظهر تسميتها `75%` مع أسماء الفئة والسلسلة. النص المخصص يستبدل النص المُولد للتسمية. تُعيد [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) سلسلة التسمية الناتجة في الحالتين. افحص [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) بشكل منفصل، كما هو موضح أعلاه، عندما تريد استخراج التسميات الظاهرة فقط.

## **التحكم في تسميات البيانات خارج الحد الأقصى للمحور**

عند تحديد نطاق المحور يدويًا، قد تتجاوز بعض نقاط البيانات الحد الأقصى. استخدم [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) للتحكم فيما إذا كانت تسميات بياناتها تُعرض. يغيّر هذا الإعداد رؤية التسمية؛ ولا يغيّر نطاق المحور أو قيم البيانات الأساسية.

ينشئ المثال أدناه مخططًا عموديًا مجمعًا ثنائي الأبعاد بقيم 60 و120. يمرّر `False` إلى [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) ويضبط الحد الأقصى على 100 باستخدام [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) على المحور الرأسي. الشريحة الأولى تسمح بتسميات تتجاوز الحد الأقصى؛ نسخة تلك الشريحة تعطلها. تُحفظ كلتا الشريحتين في `DataLabelsOverMaximum.pptx`.

فعّل تسميات القيم باستخدام [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). لا يفعّل الإعداد على مستوى المخطط عرض القيم بحد ذاته ولا يتجاوز إلغاء تمكين عرض القيمة لتسمية فردية. يُظهر هذا المثال القيم للسلسلة بالكامل ويستخدم [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) لوضع التسميات في الطرف الخارجي لكل عمود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تُظهر الصور التالية الشرائح المحفوظة التي تم عرضها بواسطة Microsoft PowerPoint. مع `True` تكون التسمية **120** مرئية عند الحد العلوي؛ مع `False` تكون مخفية. تظل التسمية **60** مرئية، يبقى الحد الأقصى للمحور عند **100**، وتبقى نقطة البيانات الثانية **120** في الحالتين.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![مخطط PowerPoint يُظهر تسمية القيمة 120 بحد أقصى للمحور قدره 100](data-labels-over-maximum-true.png) | ![مخطط PowerPoint يُخفي تسمية القيمة 120 بحد أقصى للمحور قدره 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
هذا المثال يستخدم مخططًا عموديًا ثنائي الأبعاد مع محور قيم. المخططات التي لا تمتلك محور قيم، مثل مخططات الفطيرة والدوائر، لا تحتوي على حد أقصى للمحور لتقييده بهذه الطريقة.
{{% /alert %}}

## **ضبط مسافة التسمية من المحور**

استخدم [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) للتحكم في المسافة بين تسميات محور الفئات والمحور. القيمة هي نسبة مئوية من أقصى حجم خط لتسميات المحور. يُنشئ هذا المثال مخططًا عموديًا مجمعًا ويضبط إزاحة تسمية المحور الأفقي إلى 500. يؤثر هذا الإعداد على تسميات محور الفئات وليس على التسميات المرتبطة بنقاط البيانات الفردية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ضبط موقع التسمية**

في مخطط الفطيرة، عدّل مواضع تسميات البيانات لتحسين التباعد وإفساح المجال لخطوط الربط.

يعرض هذا المثال قيمة نقطة البيانات الأولى، يضع تسميتها خارج الشريحة، ويعدل إزاحتها الأفقية والرأسية باستخدام [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) و[setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY). هذه الإزاحات نسبية إلى عرض وارتفاع المخطط على الترتيب.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![مخطط فطيرة مع موضع تسمية بيانات مُعدَّل](pie-chart-adjusted-label.png)

## **إضافة عدة صفوف من تسميات البيانات فوق مخطط عمودي**

يُنشئ هذا المثال مخططًا عموديًا مع صفين من تسميات البيانات فوق مساحة الرسم. السلسلة A تُظهر الأعمدة الظاهرة، بينما السلسلتان B وC توفران التسميات الإضافية. تُخفى أعمدتهما بإزالة التعبئة والحدود. يضمن أسلوب [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) محاذاة جميع السلاسل الثلاثة مع مراكز الفئات نفسها.

تُخصِّص إعدادات [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) مساحة للصفوف التسميات. بعد أن يحسب [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) المواقع الافتراضية، يحافظ [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) و[DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) على المحاذاة الأفقية ويطبقان إزاحات عمودية لترتيب التسميات في صفين. تظل الأرقام تسميات بيانات مرتبطة بقيم السلسلة؛ فقط عناوين الصفوف هي أشكال نصية منفصلة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # إخفاء أعمدة B و C، مع الاحتفاظ بتسميات البيانات الخاصة بهم.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # محاذاة السلاسل الثلاثة مع نفس مراكز الفئات.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # استخدام خطوط شبكة أقل لهذا المثال المدمج.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # حجز مساحة فوق المنطقة المرسومة لصفين من تسميات البيانات.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # الإبقاء على الموضع الأفقي الافتراضي. Y هو إزاحة من
            # موضع التسمية الافتراضي، معبرًا عنه ككسر من ارتفاع المخطط.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # فقط عنوان الصف هو شكل نص منفصل.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![مخطط عمودي مع صفين من تسميات البيانات فوق منطقة الرسم](multiple-rows-of-labels.png)

## **الأسئلة المتكررة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات الكثيفة؟**  
اجمع بين وضع التسمية التلقائي، وخطوط الربط، وتقليل حجم الخط؛ إذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للقيم المتطرفة أو النقاط الرئيسية.

**كيف يمكنني تعطيل التسميات للقيم الصفرية أو السلبية أو الفارغة فقط؟**  
قم بترشيح نقاط البيانات قبل تمكين التسميات وأوقف العرض للقيم صفر أو القيم السلبية أو القيم الفارغة وفقًا لقاعدة محددة.

**كيف يمكنني ضمان نمط تسمية متسق عند التصدير إلى PDF/صور؟**  
حدد عائلة الخط وحجمه صراحةً وتأكد من توفر الخط في بيئة العرض لتجنب الاعتماد على الخط الافتراضي.