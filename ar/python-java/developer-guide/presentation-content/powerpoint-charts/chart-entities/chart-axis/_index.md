---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام بايثون
linktitle: محاور المخطط
type: docs
url: /ar/python-java/chart-axis/
keywords:
- محور المخطط
- المحور العمودي
- المحور الأفقي
- تخصيص المحور
- تعديل المحور
- إدارة المحور
- خصائص المحور
- القيمة القصوى
- القيمة الدنيا
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides للغة بايثون عبر Java لتخصيص محاور المخططات في عروض PowerPoint للتقارير والتصوير البصري."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تخصيص محاور المخططات باستخدام Aspose.Slides للغة Python عبر Java. وتغطي القيم المحسوبة للمحور، وتبديل صفوف وأعمدة المخطط، وإظهار المحور أو إخفائه، وفواصل تسميات الفئة وعلامات الفواصل، وفئات التاريخ وتنسيقها، وتدوير العنوان، وتحديد موضع المحور، ووحدات العرض، وكذلك التدرج اللوغاريتمي.

## **الحصول على القيم القصوى على المحور العمودي للمخطط**

إنشاء [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) وإضافة مخطط منطقة ببيانات افتراضية. استدعاء [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) قبل قراءة القيم المحسوبة للمحور لضمان أن تخطيط المخطط محدث.

قراءة [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) و [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) للحصول على حدود المحور، و [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) و [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) لفواصل العلامات. توفر [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) و [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) مقاييس الوحدات الزمنية، وهي ذات صلة بمحاور التاريخ. يخزن المثال هذه القيم في متغيرات محلية ويحفظ المخطط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تبديل البيانات بين المحاور**

استخدم [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. هذا يغيّر طريقة تجميع البيانات؛ ولا يبدّل المحاور الأفقي والعمودي. يستخدم المثال [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف العنوان وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ المخطط بأربع سلاسل وثلاث فئات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **عكس ترتيب الرسم للمحور**

استخدم [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) لعكس محور فئة أو قيمة. على سبيل المثال، يمكن لمخطط شريطي أفقي عرض مراحل المشروع من الأعلى إلى الأسفل بنفس ترتيب ورقة العمل: التخطيط، التطوير، الاختبار. عكس المحور يغيّر اتجاه الرسم؛ ولا يرتب أو يعيد ترتيب بيانات المصنف. بالمقارنة، يقوم [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) بتبادل أدوار السلاسل والفئات.

المثال التالي ينشئ مخططًا شريطيًا أفقيًا بثلاث مراحل وسلسلة واحدة. يحفظ عرضًا تقديميًا بثلاث شرائح: الترتيب العادي، الفئات المعكوسة، والقيم المعكوسة. كل نسخة تستخدم نفس مجموعة البيانات، ويتم عكس محور واحد فقط في كل نسخة.

```python
import jpase
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # الشريحة 2: عرض الفئة الأولى في الأعلى.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # إبقاء محور القيمة الأفقي في الأسفل.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # الشريحة 3: عكس مقياس الأرقام الأفقي فقط.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يمكن أيضًا لعكس المحور أن ينقل المحور العمودي إلى الجانب المقابل من الرسم. يتحكم [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) في موضع تقاطع المحور الآخر مع المحور الجاري تهيئته. في الشريحة 2، استدعاؤه بـ [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) على محور الفئة المعكوس يبقي محور القيمة الأفقي في الأسفل. لنقطة تقاطع محددة، استخدم [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). راقب إعدادات التقاطع عند تغيير الاتجاه، خاصة إذا كان المخطط يمتلك نقطة تقاطع مخصصة سلفًا. استدعِ [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) مع `False` لاستعادة اتجاه الرسم الطبيعي؛ إعدادات التقاطع مستقلة.

| الترتيب العادي (الشريحة 1) | الفئات المعكوسة (الشريحة 2) | القيم المعكوسة (الشريحة 3) |
| --- | --- | --- |
| ![مخطط شريطي أفقي بترتيب عادي للفئة والمحور القيمي](axis-order-normal.png) | ![مخطط شريطي أفقي مع عرض الفئات من الأعلى إلى الأسفل](axis-order-categories-reversed.png) | ![مخطط شريطي أفقي مع محور قيمة معكوس والصفر على اليمين](axis-order-values-reversed.png) |
| الفئات تمتد من الأسفل إلى الأعلى؛ القيم تزداد من اليسار إلى اليمين. | التخطيط، التطوير، والاختبار تُعرض من أعلى إلى أسفل. القيم وترتيب صفوف المصنف لم يتغير. | الفئات تحتفظ بترتيبها الطبيعي؛ القيم تزداد من اليمين إلى اليسار. يتقاطع محور الفئة عند الصفر على اليمين. |

## **تعطيل المحور العمودي لمخططات الخط**

استدعِ [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) مع `False` على المحور العمودي لإخفائه. ينشئ المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور العمودي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعطيل المحور الأفقي لمخططات الخط**

استدعِ [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) مع `False` على المحور الأفقي لإخفائه. ينشئ المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الأفقي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إظهار أو إخفاء خطوط الشبكة في المخطط**

استدعِ [getShowMajorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMajorGridLines) و [getShowMinorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMinorGridLines) للتحقق من الخطوط التي يعرضها المحور. لعرض خطوط الشبكة الصغرى، استخدم [getMinorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMinorGridLinesFormat) واضبط تعبئة الخط إلى لون صلب مرئي. لإخفائها، اضبط التعبئة إلى [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/#NoFill). استخدم [getMajorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMajorGridLinesFormat) لتغيير تعبئة الخط للخطوط الكبرى بنفس الطريقة. الحفاظ على تعبئة الخط يحافظ على وضوح المحور وعلامات الفواصل.

المحور العمودي لهذا المخطط العمودي المجمّع في البداية يعرض الخطوط الكبرى فقط. يعرض المثال الخطوط الصغرى باللون البرتقالي الداكن، ثم يخفيها مرة أخرى قبل حفظ العرض التقديمي. يطبع حالة ظهور خطوط الشبكة في كل خطوة.

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

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230)
    axis = chart.getAxes().getVerticalAxis()
    print(f"Initial: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    minor_fill = axis.getMinorGridLinesFormat().getLine().getFillFormat()
    minor_fill.setFillType(FillType.Solid)
    minor_fill.getSolidFillColor().setColor(Color(255, 140, 0))
    print(f"Enabled: minor={axis.getShowMinorGridLines()}")

    minor_fill.setFillType(FillType.NoFill)
    print(f"Hidden: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| خطوط الشبكة الصغرى مفعلة | خطوط الشبكة الصغرى مخفية |
| --- | --- |
| ![خطوط شبكة صغرى برتقالية بين الخطوط الكبرى على المحور العمودي](minor-gridlines-enabled.png) | ![نفس المخطط العمودي مع إبراز الخطوط الكبرى فقط](minor-gridlines-hidden.png) |

## **تغيير محور الفئة**

استخدم [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) لاختيار محور فئة تاريخية أو نصية. يتطلب هذا المثال ملف `ExistingChart.pptx`، حيث يكون المخطط هو الشكل الأول في الشريحة الأولى وتحتوي خلايا الفئة على قيم تاريخية رقمية من Excel. يغيّر المحور الأفقي إلى محور تاريخ. استدعاء [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) مع `False`، ثم [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) مع `1`، وأخيرًا [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) مع [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) يضع العلامات الكبرى بفواصل شهرية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تحديد نوع محور الفئة من البيانات**

استدعِ [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisTypeAutomatically) بعد ملء الفئات، ثم اقرأ [getCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getCategoryAxisType) للتحقق من الاختيار. هذا مفيد عندما يتلقى المخطط إما تسميات نصية أو قيم تاريخية رقمية. تحدد الطريقة النوع عند الاستدعاء؛ ولا تتيح وضعًا مستمرًا يعيد التقييم عند تغيّر البيانات لاحقًا. استدعها مرة أخرى بعد استبدال الفئات.

المثال التالي ينشئ مخططًا بفئات نصية ويطبع `True` عندما يكون النوع المختار هو [CategoryAxisType.Text](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Text). ثم يستبدل قيم خلايا الفئة بالتواريخ ويستدعي الطريقة مرة أخرى، مطبعًا `True` عندما يكون النوع المختار هو [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date). تُخزن التواريخ كقيم رقمية من نوع OLE Automation، تُحسب كعدد الأيام منذ 30 ديسمبر 1899، وليس كسلاسل نصية. يتحكم [setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) في طريقة عرض تلك القيم؛ ولا يحول النص إلى تواريخ رقمية. لمزيد من المعلومات حول خلايا الفئة، راجع [Chart Workbook](/slides/ar/python-java/chart-workbook/).

استخدم التحديد التلقائي عندما يُعرف أن الإدخال يحتوي على فئات نصية أو تواريخ رقمية، كما في هذا المثال. بالنسبة للتسميات الرقمية الاعتيادية أو الفئات المختلطة أو البيانات الفارغة، استدعِ صراحةً [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) لمطابقة المعنى المقصود. القيم الرقمية وحدها لا تُثبت أن الفئات تمثل تواريخ.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CategoryAxisType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series_name = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.getCell(0, i + 1, 0, label)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Text)  # صحيح

    base_date = date(1899, 12, 30)
    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.getCell(0, i + 1, 0)
        category_cell.setValue(float((category_date - base_date).days))
        category_cell.setCustomNumberFormat("yyyy-mm-dd")

    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Date)  # صحيح

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **التحكم في فواصل تسميات محور الفئة**

عند وجود العديد من الفئات في مخطط، قلل عدد التسميات الظاهرة للمحور دون إزالة الفئات أو نقاط البيانات. استدعِ [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) مع `False`، ثم مرّر الفاصل المطلوب إلى [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1، الفئة 2، الفئة 3، … الفئة 24 |
| `2` | الفئة 1، الفئة 3، الفئة 5، … الفئة 23 |
| `3` | الفئة 1، الفئة 4، الفئة 7، … الفئة 22 |

الفاصل `3` يعرض كل تسمية ثالثة، ويخفي اثنتين بين كل تسمينتين معروضة. لا يزيل الأعمدة المقابلة. يختار التباعد التلقائي الفاصل بناءً على المساحة المتاحة؛ ولا يضمن عرض كل تسمية.

لـعلامات الفواصل تحكم منفصل. استدعِ [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) مع `False` واستخدم [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) لتعيين فاصلها. على سبيل المثال، `1` يبقي علامة فاصل عند كل فاصل فئة بينما تظهر التسميات كل فئة ثالثة فقط. استخدم [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) بنمط مرئي لتتمكن من رؤية النتيجة. إعادة استدعاء أي من السيتّرات التلقائية مع `True` يسمح للمخطط باختيار الفاصل مرة أخرى.

المثال التالي المستقل يُنشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: تباعد تلقائي، تباعد يدوي مع علامات فواصل مستقلة، واستعادة التباعد التلقائي. النسختان تحتفظان ببيانات المخطط الأصلية. لا يلزم أي عرض تقديمي مدخل. يجعل نص تسميات الفئات الأفقي الفرق في الكثافة واضحًا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # الشريحة 2: عرض كل تسمية ثالثة، مع الحفاظ على علامة فاصل لكل فئة.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # الشريحة 3: السماح للمخطط باختيار كلا الفاصلين مرة أخرى.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**الترصيف التلقائي (الشريحة 1):** في هذا العرض، تُعرض كل تسمية فئة ثانية وتلتف إلى سطرين. قد يختلف الناتج التلقائي بحسب حجم المخطط، الخطوط، ومُحرك العرض.

![تباعد تسميات الفئات تلقائيًا مع ظهور جميع الأعمدة الـ24](category-axis-automatic.png)

**الترصيف اليدوي (الشريحة 2):** تُعرض كل تسمية فئة ثالثة على سطر واحد، بينما تبقى علامات الفواصل عند كل فاصل فئة. جميع الأعمدة الـ24، بما فيها غير المعروضة، تبقى مرئية بنفس القيم. الشريحة 3 تستعيد المظهر التلقائي الموضح أعلاه.

![تباعد فئة يدوي بثلاثة مع ظهور جميع الأعمدة الـ24](category-axis-manual.png)

### **اختر المحور والفاصل الصحيحين**

استخدم هذا الفاصل لعدد الفئات لمحور فئة نصية، مثل محور الفئة في مخطط عمودي، خطي، مساحي، أو شريطي. في المخطط العمودي يكون هو المحور الأفقي. في المخطط الشريطي الأفقي يكون محور الفئة عموديًا، لذا طبّق هذه الإعدادات على المحور الذي تُعيده [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). يطبق تباعد علامات الفواصل أيضًا على محور السلسلة في المخططات التي تحتوي على واحد.

لا تستخدم تباعد تسميات الفئة لتحديد مقياس عددية لمحور القيمة. على محور القيمة، يحدد [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) فرق القيم: على سبيل المثال، وحدة رئيسية `10` تُنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسمية الفئة `3` يعدّ مواضع الفئات بغض النظر عن قيمها. تستخدم مخططات التبعثر والفقاعات محاور قيم بدلاً من محور فئة نصية. بالنسبة إلى محور التاريخ، استخدم الوحدات الكبرى المستندة إلى الوقت والمقاييس كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال بيانات المخطط الافتراضية بأربع قيم سنوية. تُخزن التواريخ كأرقام تسلسلية OLE Automation في ورقة العمل الأولى (الفهرس `0`)، محسوبة كعدد الأيام منذ 30 ديسمبر 1899. استخدم [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) مع [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date)، استدعِ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) مع `False`، ومرّر `yyyy` إلى [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) حتى تُظهر تسميات الفئة سنوات بأربعة أرقام بغض النظر عن تنسيق الخلية.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين زاوية الدوران لعنوان محور المخطط**

استدعِ [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) مع `True` على المحور العمودي، وزد نص العنوان، ثم اضبط زاوية الدوران في تنسيق كتلة نص العنوان. تُقاس الزاوية بالدرجات؛ يحفظ المثال مخططًا عموديًا مع تدوير عنوان محور القيمة بمقدار 90 درجة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين موضع المحور على محور الفئة أو القيمة**

استخدم [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) للتحكم فيما إذا كان محور القيمة يعبر محور الفئة بين الفئات أو عند علامات الفواصل. ينطبق هذا الإعداد على محاور الفئة. يضبط المثال القيمة إلى `True` على محور الفئة الأفقي في مخطط عمودي ويحفظ النتيجة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين وحدة العرض على محور قيمة المخطط**

استخدم [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) لتكبير أو تصغير تسميات محور القيمة دون تغيير البيانات الأصلية. مع ضبط [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) إلى `Millions`، يُعرض القيمة 60 000 000 كـ 60. يُنشئ المثال مخططًا عموديًا ويطبق وحدة العرض بالملايين على محوره العمودي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تهيئة محور قيمة لوغاريتمي**

محور قيمة لوغاريتمي مفيد عندما تمتد القيم الإيجابية عبر عدة أوامر من الحجم. على سبيل المثال، قد يتلقى خدمة 10، 100، 1 000، 10 000، و100 000 طلبًا على مدار خمس فترات. على مقياس خطي، تظهر القيم الصغيرة متقاربة قرب الصفر. يجعل المقياس اللوغاريتمي نموها النسبي أسهل للمقارنة: المسافات المتساوية تمثل نسبًا متساوية بدلاً من اختلافات متساوية.

استدعِ [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) مع `True` على محور القيمة، واستخدم [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) لاختيار القاعدة. يغيّر هذا طريقة عرض القيم الموجودة؛ ولا يغيّر البيانات أو يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة مُناسبة في البيانات وهو ميزة منفصلة.

### **اختر محور القيمة والأساس**

في مخطط خط أو عمودي، يُعاد محور القيمة بواسطة [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). في المخطط الشريطي الأفقي، يُعاد بواسطة [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). لمخططات التبعثر والفقاعات يوجد محوران للقيمة، لذا اختر المحور الأفقي لقيم X، والمحور العمودي لقيم Y، أو كلاهما. لا تطبق التدرج اللوغاريتمي على محور الفئة.

القيمة الافتراضية للقاعدة اللوغاريتمية هي `10`. لمخططات PPTX، يمكن استخدام قاعدة من `2` إلى `1000` شاملة؛ وتُدعم القواعد الكسرية مثل `2.5`. مع القاعدة `10`، تكون القوى المتتالية مثل 10، 100، 1 000، و10 000 متباعدة بالتساوي.

### **مقارنة بين التدرج الخطي واللوغاريتمي**

المثال التالي المستقل يُنشئ مخططًا خطيًا بخمس عدد طلبات في الشريحة الأولى، ثم ينسخ تلك الشريحة ويفعّل محور قيمة لوغاريتمي بقاعدة 10 في الشريحة الثانية. تحتفظ الشريحتان بنفس البيانات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # احتفظ بالشرحة الأولى خطيًا وغير مقياس محور القيمة للنسخة فقط.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**المقياس الخطي (الشريحة 1):** المسافات الرأسية المتساوية تمثّل اختلافات عددية متساوية في عدد الطلبات. تُهيمن القيمة الأكبر على المخطط، مما يصعّب تمييز القيم الأصغر.

![مخطط خطي في PowerPoint يُظهر خمسة طلبات على محور قيمة خطي](value-axis-linear.png)

**المقياس اللوغاريتمي (الشريحة 2):** المسافات الرأسية المتساوية تمثّل نسبًا متساوية. كل فترة تحتوي على عشرة أضعاف عدد الطلبات مقارنةً بالفترة السابقة، لذا تشكّل النقاط خطًا مستقيمًا صاعدًا على المقياس العشري 10. لا تزال تسميات المحور تُظهر أعداد الطلبات الأصلية.

![نفس الطلبات الخمسة في PowerPoint على محور قيمة لوغاريتمي بقاعدة 10](value-axis-logarithmic.png)

### **معالجة القيم الصفرية والسلبية**

يمكن للمقياس اللوغاريتمي عرض قيم موجبة فقط. تحقق من البيانات قبل تمكينه. إذا كانت القيم الصفرية أو السلبية ذات معنى، احتفظ بالمقياس الخطي أو أظهرها بشكل منفصل. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسر الإغفال. لا تستبدلها صمتًا بأرقام موجبة صغيرة، فهذا يغيّر معنى البيانات. يجب أن تكون أي حد أدنى أو أقصى مضبوط يدويًا للمحور اللوغاريتمي أيضًا قيمة موجبة.

## **الأسئلة الشائعة**

**كيف أقوم بتعيين القيمة التي يتقاطع فيها أحد المحاور مع الآخر (تقاطع المحور)؟**

استخدم [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) لتحديد سلوك التقاطع. لتحديد قيمة تقاطع عددية، استخدم [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). تسمح لك هذه الإعدادات بنقل تقاطع المحور إلى خط أساسي مناسب.

**كيف يمكنني وضع تسميات الفواصل بالنسبة للمحور؟**

استدعِ [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo`، أو `None`. للتحكم في علامات الفواصل نفسها، استخدم [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) أو [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark)؛ فهذه مستقلة عن وضعية التسميات.