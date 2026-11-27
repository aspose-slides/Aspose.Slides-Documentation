---
title: تنسيق مخططات العرض التقديمي في Python
linktitle: تنسيق المخططات
type: docs
weight: 60
url: /ar/python-java/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخططات
- كيان المخطط
- خصائص المخطط
- إعدادات المخطط
- خيارات المخطط
- خصائص الخط
- حد مستدير
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides للغة Python عبر Java وارتقِ بعرض PowerPoint الخاص بك باستخدام محاور مخصصة، خطوط، تنسيقات رقمية، وحدود مخطط مستديرة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق المخططات في عروض PowerPoint باستخدام Aspose.Slides. تُظهر كيفية تخصيص العناصر الأساسية للمخطط مثل المحاور وخطوط الشبكة والعناوين والأساطير ومنطقة الرسم وتعبئة الجدران لتحسين مظهر البيانات وقابليتها للقراءة.

كما توضح كيفية تعيين خصائص الخط لنص المخطط، وتطبيق تنسيقات عددية مسبقة على بيانات المخطط، وتمكين الزوايا المستديرة لمنطقة المخطط. تُظهر هذه الأمثلة معًا كيفية التحكم في كل من النمط البصري وعرض البيانات للمخططات في العرض التقديمي.

للتعبئات والخطوط المنفصلة للفواصل الصاعدة والهابطة، راجع [مثال مخطط الأسهم](/slides/ar/python-java/create-chart/#create-stock-charts).

## **تنسيق كيانات المخطط**

استخدم [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) لتنسيق عناوين المخطط، والمحاور، وخطوط الشبكة، والأساطير، ومنطقة الرسم. يُنشئ هذا المثال مخططًا خطيًا مع مؤشرات وبيانات افتراضية، ثم يطبق أنماط نصية وخطية منفصلة على محوري القيم والفئات. يتم تحديد أحجام الخطوط وعرض الخطوط بالنقاط؛ ويتم تدوير تسميات الفئات بزاوية 45 درجة.

يستخدم محور القيم الدالة [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) بشكل مستقل عن خلايا المصدر. يمتد مقياسه من -2 إلى 15، مع فواصل رئيسية مقدارها 2 وفواصل فرعية مقدارها 0.5. يجمع المثال أيضًا بين تنسيق النسبة المئوية والدالة [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) المضبوطة على الآلاف، لذا قم بتكييف هذه الإعدادات مع معنى وحجم بياناتك. يبقى الأسطورة خارج منطقة الرسم لأن الدالة [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) تُستدعى بالقيمة `False`. يتم تكوين تعبئة الجدار الخلفي والأرضية عبر [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) و[getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor)، لكن هذه السطوح لا تظهر إلا في المخططات ثلاثية الأبعاد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(NullableBool.True_)
    chart_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(NullableBool.True_)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(NullableBool.True_)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    value_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    category_grid_color = Color(0, 128, 0)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(category_grid_color)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(NullableBool.True_)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(NullableBool.True_)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    category_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(NullableBool.True_)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(NullableBool.True_)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    chart.getLegend().setOverlay(False)

    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    back_wall_color = Color(255, 165, 0)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(back_wall_color)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين خصائص الخط لمخطط**

عيّن حجم الخط الافتراضي لنص المخطط عبر [Chart.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat). ينشئ المثال مخطط أعمدة مجمّع بحجم خط 20 نقطة ويفعل تسميات القيم للسلسلة الأولى عبر [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). يمكن لعناصر النص التي لديها إعدادات خط صريحة أن تتجاوز الإعداد الافتراضي للمخطط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إعادة استخدام تنسيق إطار النص لأسطورة المخطط**

لمطابقة الأسطورة مع عنوان الشريحة، عيّن خط العنوان عبر [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) في الفقرة الأولى. استدعِ [copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyFrom) على التنسيق الذي تُرجعه الدالة [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) الخاصة بالأسطورة. هذه العملية تنسخ إعدادات إطار النص، وتنسيق الفقرة الأولى، وخصائص الخط الافتراضية لتلك الفقرة. يظل التنسيق المطبق مباشرةً على أجزاء معينة أو على فقرات لاحقة محليًا بالنسبة للمصدر.

يستخدم المثال عنوانًا بخط Calibri غامق بحجم 26 نقطة ولون أزرق داكن كالقالب. بعد تنسيق الأسطورة، يستدعي [copyTo](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyTo) لتطبيق نفس التنسيق على تسمية توضيحية منفصلة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LegendPositionType, NullableBool, Presentation, SaveFormat, ShapeType, StyleType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, False)
    source_text_frame = heading.addTextFrame("Quarterly sales")
    paragraph = source_text_frame.getParagraphs().get_Item(0)
    font = paragraph.getParagraphFormat().getDefaultPortionFormat()
    font.setLatinFont(FontData("Calibri"))
    font.setFontHeight(26)
    font.setFontBold(NullableBool.True_)
    font.getFillFormat().setFillType(FillType.Solid)
    font.getFillFormat().getSolidFillColor().setColor(Color(32, 64, 96))

    chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360)
    chart.setStyle(StyleType.Style3)
    workbook = chart.getChartData().getChartDataWorkbook()
    for column, series_name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.getCell(0, 0, column).setValue(series_name)
    for quarter in range(1, 5):
        workbook.getCell(0, quarter, 0).setValue(f"Q{quarter}")

    chart.setLegend(True)
    legend = chart.getLegend()
    legend.setPosition(LegendPositionType.Bottom)
    legend_format = legend.getTextFormat()
    legend_format.copyFrom(source_text_frame)

    caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, False)
    caption_text_frame = caption.addTextFrame("Sales in millions of dollars")
    legend_format.copyTo(caption_text_frame)

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

في العرض التقديمي المحفوظ، تتطابق الأسطورة والتسمية التوضيحية مع العنوان من حيث الحجم والوزن واللون. لا تزال الأسطورة تعرض أسماء السلاسل، وتحتفظ التسمية التوضيحية بنصها الخاص. إذا كان هناك جزء في التسمية التوضيحية يحتوي بالفعل على حجم خط صريح، فإن ذلك الحجم يتفوق على حجم الفقرة المنسوخ.

| قبل النسخ | بعد النسخ |
| --- | --- |
| ![مخطط مبيعات ربع سنوي مع تسميات أسطورة سوداء عادية وتسمية توضيحية سوداء](legend-formatting-before.png) | ![نفس المخطط مع تسميات أسطورة زرقاء داكنة غامقة أكبر وتسمية توضيحية متطابقة](legend-formatting.png) |

## **تعيين التنسيق الرقمي**

استخدم [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat) لتطبيق تنسيق رقم مدمج على خلايا دفاتر العمل الخاصة بالمخطط. يُنشئ هذا المثال مخطط أعمدة مجمّع ببيانات افتراضية مدعومة بالخلايا ويُطبق الفهرس 10 (`0.00%`) على كل خلية قيمة للسلسلة. يغيّر ذلك طريقة عرض القيم في دفتر العمل دون تعديل الأرقام الأساسية؛ على سبيل المثال، يُعرض 0.25 كـ 25.00٪. يمكن تكوين تنسيقات المحور وتنسيقات تسميات البيانات بشكل منفصل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)
    chart_series_collection = chart.getChartData().getSeries()

    for chart_series in chart_series_collection:
        for data_point in chart_series.getDataPoints():
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الجدول التالي يسرد فهارس تنسيقات الأرقام المدمجة مع صيغ Excel ممثلة للغة الإنجليزية (الولايات المتحدة). قد تختلف سلاسل التنسيق الدقيقة وعرضها بحسب التطبيق واللغة، خاصة للعملات والتواريخ. بعض صيغ Excel تختلف أيضًا عن القيم الافتراضية في معيار OOXML، كما هو موضح في [ملاحظات مايكروسوفت حول تنفيذ تنسيق الأرقام](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| الفهرس | التنسيق |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **تعيين حدود مستديرة لمنطقة المخطط**

استدعِ الدالة [Chart.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners) مع القيمة `True` لتقويس زوايا منطقة المخطط. يُنشئ المثال مخطط أعمدة مجمّع ويستخدم [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) لإعطاء حدوده لونًا رماديًا صلبًا ونمط خط أحادي قبل حفظ العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تحرير التعليقات التوضيحية للمخطط الموجودة**

يمكن للمخطط أن يحتوي على أشكال مخصصة، مثل تعليق نصي يوضح حالة تقرير. وَصُل إلى هذه الأشكال عبر [Chart.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes). المجموعة التي تُرجعها الدالة [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) تحتوي على الأشكال المملوكة للمخطط.

مربع نص عادي موضوع فوق المخطط ينتمي إلى الشريحة، حتى لو بدا كجزء من المخطط. يَكتشف الاستعراض عبر [Slide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) المخطط والأشكال العادية في الشريحة، لكنه لا يعدّ الأشكال الفردية داخل المخطط. عناوين المخطط وتسميات البيانات هي عناصر مخطط منفصلة، وليست تعليقات مخصصة في هذه المجموعة.

حمّل الملف [chart-annotations.pptx](chart-annotations.pptx) وضعه في دليل عمل التطبيق. يحتوي الشريحة الأولى على مخطط مع تعليق غير مجمع يُظهر النص "Preliminary results"، وخط مملوك للمخطط، ومربع نص عادي في الشريحة يُظهر النص "Slide overlay". يجد المثال أول مخطط على تلك الشريحة ويغيّر التعليق إلى "Final results" عندما يصبح التقرير جاهزًا للنشر. يتحقق من وجود مجموعة فارغة ولا يحرّر سوى [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ذو إطار نص غير `None` تُرجعه الدالة [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame)، ويتأكد من النص المتوقع.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Chart, Presentation, SaveFormat

presentation = Presentation("chart-annotations.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = None
    for shape in slide.getShapes():
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is None or chart.getUserShapes().getShapes().size() == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.getUserShapes().getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None and text_frame.getText() == "Preliminary results":
                    text_frame.setText("Final results")
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx)
        else:
            print("No matching text annotation found.")
finally:
    presentation.dispose()
```

يبقى الخط ومربع النص في الشريحة دون تغيير. تُظهر الصور التالية الإدخال والنتيجة المحفوظة عند إعادة الفتح:

| قبل التحرير | بعد التحرير |
| --- | --- |
| ![تعليق مخطط يقرأ Preliminary results](chart-annotations-before.png) | ![تعليق مخطط يقرأ Final results](chart-annotations-after.png) |

{{% alert color="info" title="ملاحظة" %}}

يفحص المثال فقط الأشكال المملوكة للمخطط على المستوى الأعلى. إذا كان التعليق داخل [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/)، فافحص مجموعة تلك الأشكال عبر الدالة [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) كذلك. كرّر ذلك بصورة متكررة للمجموعات المتداخلة، مطبقًا نفس فحوصات النص على الأشكال الفرعية. المجموعة نفسها حاوية؛ لا تُعامِلها كصندوق نص.

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تعيين تعبئات نصف شفافة للأعمدة/المساحات مع الحفاظ على حد غير شفاف؟**

نعم. يتم تكوين شفافية التعبئة والخط الخارجي بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، عطل المكونات غير الضرورية للتسمية (مثل الفئات)، عدّل موضع التسمية، اعرض التسميات فقط للنقاط المختارة إذا لزم الأمر، أو غيّر التنسيق إلى "القيمة + الأسطورة".

**هل يمكنني تطبيق تعبئات تدرجية أو نمطية على السلاسل؟**

نعم. تدعم السلاسل تعبئات صلبة، وتدرجية، ونمطية. في الممارسة العملية، استخدم التدرجات باعتدال وتجنب الجمعات التي تقلل التباين مع الشبكة والنص.