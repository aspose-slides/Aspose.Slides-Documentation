---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام بايثون
linktitle: محور المخطط
type: docs
url: /ar/python-java/chart-axis/
keywords:
- محور المخطط
- المحور الرأسي
- المحور الأفقي
- تخصيص المحور
- معالجة المحور
- إدارة المحور
- خصائص المحور
- القيمة القصوى
- القيمة الدنيا
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides for Python via Java لتخصيص محاور المخططات في عروض PowerPoint التقديمية للتقارير والتصورات."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص محاور المخطط باستخدام Aspose.Slides for Python via Java. تغطي القيم المحسوبة للمحاور، تبديل صفوف وأعمدة المخطط، إظهار/إخفاء المحاور، فواصل تسميات الفئات وعلامات التقطيع، الفئات التاريخية وتنسيقها، تدوير العنوان، موضع المحور، وحدات العرض، والتدرج اللوغاريتمي.

## **الحصول على القيم القصوى على المحور العمودي للمخطط**

أنشئ [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) وأضف مخططًا مساحيًا ببيانات افتراضية. استدعِ [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) قبل قراءة القيم المحسوبة للمحاور لضمان تحديث تخطيط المخطط.

اقرأ [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) و [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) للحصول على حدود المحور، و [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) و [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) لفواصل العلامات. توفر [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) و [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) مقاييس وحدة الوقت، وهي ذات صلة بمحاور التاريخ. يخزن المثال هذه القيم في متغيرات محلية ويحفظ المخطط.

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

استخدم [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. يغيّر هذا طريقة تجميع البيانات؛ ولا يبدّل المحاور الأفقية والرأسية. يستخدم المثال [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) لربط البيانات الافتراضية بـ `Sheet1!A1:D5`، بما في ذلك صف الرأس وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ مخططًا يحتوي على أربع سلاسل وثلاث فئات.

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

استخدم [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) لعكس محور فئة أو قيمة. على سبيل المثال، يمكن لمخطط شريطي أفقي عرض مراحل المشروع من الأعلى إلى الأسفل بنفس ترتيب ورقة العمل: التخطيط، التطوير، الاختبار. عكس المحور يغيّر اتجاه الرسم؛ ولا يفرز أو يعيد ترتيب بيانات المصنف. بالمقارنة، [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) يبدّل أدوار السلاسل والفئات.

النموذج التالي ينشئ مخطط شريطي أفقي بثلاث مراحل وسلسلة واحدة. يحفظ عرض تقديمي بثلاث شرائح: الترتيب العادي، الفئات المعكوسة، والقيم المعكوسة. كل نسخة تستخدم مجموعة البيانات نفسها، ويُعكس محور واحد فقط في كل نسخة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpapi.startJVM()

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
    # الحفاظ على محور القيمة الأفقي في الأسفل.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # الشريحة 3: عكس مقياس القيم الرقمي الأفقي فقط.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

عكس المحور يمكن أيضًا أن ينقل المحور العمودي إلى الجانب المقابل من المخطط. يتحكم [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) في مكان تقاطع المحور الآخر مع المحور الذي يتم تكوينه. في الشريحة 2، يتم استدعاؤه بـ [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) على محور الفئة المعكوس للحفاظ على محور القيمة الأفقي في الأسفل. لتحديد نقطة تقاطع معينة، استخدم [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). تحقق من إعدادات التقاطع عند تغيير الاتجاه، خاصة إذا كان المخطط يحتوي بالفعل على نقطة تقاطع مخصصة. استدعِ [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) مع `False` لاستعادة اتجاه الرسم الطبيعي؛ إعدادات التقاطع منفصلة.

| الترتيب العادي (الشريحة 1) | الفئات المعكوسة (الشريحة 2) | القيم المعكوسة (الشريحة 3) |
| --- | --- | --- |
| ![مخطط شريطي أفقي بترتيب الفئة والمحور القيمي العادي](axis-order-normal.png) | ![مخطط شريطي أفقي مع عرض الفئات من الأعلى إلى الأسفل](axis-order-categories-reversed.png) | ![مخطط شريطي أفقي مع محور قيم معكوس والصفر على اليمين](axis-order-values-reversed.png) |
| الفئات تبدأ من الأسفل إلى الأعلى؛ وتزداد القيم من اليسار إلى اليمين. | التخطيط، التطوير، والاختبار تُعرض من الأعلى إلى الأسفل. القيم وترتيب صفوف دفتر العمل لا يتغيران. | تحافظ الفئات على ترتيبها العادي؛ وتزداد القيم من اليمين إلى اليسار. يتقاطع محور الفئة عند الصفر على اليمين. |

## **تعطيل المحور العمودي لمخططات الخط**

استدعِ [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) مع `False` على المحور العمودي لإخفائه. يُنشئ المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور العمودي.

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

استدعِ [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) مع `False` على المحور الأفقي لإخفائه. يُنشئ المثال مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الأفقي.

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

## **تغيير محور الفئة**

استخدم [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) لاختيار محور فئة تاريخية أو نصية. يتطلب هذا المثال ملف `ExistingChart.pptx`، مع مخطط كأول شكل في الشريحة الأولى وخلايا الفئة التي تحتوي على قيم تاريخية رقمية من Excel. يغيّر المحور الأفقي إلى محور تاريخ. استدعِ [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) مع `False`، و [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) مع `1`، و [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) مع [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) لتحديد الفواصل الرئيسية على فواصل شهرية.

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

## **التحكم في فواصل تسميات محور الفئة**

عندما يحتوي المخطط على العديد من الفئات، قلل عدد تسميات المحور الظاهرة دون إزالة الفئات أو نقاط البيانات. استدعِ [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) مع `False`، ثم مرّر الفاصل الفئوي المطلوب إلى [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | الفئة 1، الفئة 2، الفئة 3، ... الفئة 24 |
| `2` | الفئة 1، الفئة 3، الفئة 5، ... الفئة 23 |
| `3` | الفئة 1، الفئة 4، الفئة 7، ... الفئة 22 |

فاصل `3` يعرض كل تسمية ثالثة، مع إخفاء تسميتين بين كل تسمية معروضة. لا يزيل هذا الأعمدة المقابلة. يختار التباعد التلقائي الفاصل بناءً على المساحة المتاحة؛ ولا يضمن عرض كل تسمية.

علامات التقطيع لها إعدادات منفصلة. استدعِ [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) مع `False` واستخدم [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) لتحديد فاصلها. على سبيل المثال، `1` يبقي علامة تقطع عند كل فاصل فئة بينما تظهر التسميات فقط كل فئة ثالثة. استخدم [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) بنمط مرئي لتتمكن من رؤية النتيجة. استدعاء أي من الضابطين التلقائيين مع `True` مرة أخرى يتيح للمخطط اختيار ذلك الفاصل مرة أخرى.

المثال التالي المستقل ينشئ 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: تباعد تلقائي، تباعد يدوي للتسميات مع علامات تقطع مستقلة، وإعادة تفعيل التباعد التلقائي. تحتفظ النسختان البيانات الأصلية للمخطط. لا يلزم عرض تقديمي إدخال. يجعل النص الأفقي للتسمية فرق الكثافة واضحًا.

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

    # الشريحة 2: عرض كل تسمية ثالثة، مع الحفاظ على علامة تقطع لكل فئة.
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

**التباعد التلقائي (الشريحة 1):** في هذا العرض، تُعرض كل تسمية فئة ثانية وتنتقل إلى سطرين. قد يختلف النتيجة التلقائية حسب حجم المخطط، الخطوط، والمُعالج.

![تباعد تسميات الفئة التلقائي مع جميع الأعمدة الـ24 مرئية](category-axis-automatic.png)

**التباعد اليدوي (الشريحة 2):** تُعرض كل تسمية ثالثة على سطر واحد، بينما تبقى علامات التقطيع عند كل فاصل فئة. جميع الأعمدة الـ24، بما في ذلك تلك التي لا تحتوي على تسميات، تظل مرئية بنفس القيم. الشريحة 3 تستعيد المظهر التلقائي المعروض أعلاه.

![فاصل تسميات الفئة يدويًا إلى ثلاثة مع جميع الأعمدة الـ24 مرئية](category-axis-manual.png)

### **اختيار المحور والفاصل الصحيحين**

استخدم هذا الفاصل بناءً على عدد الفئات لمحور الفئة النصية، مثل محور الفئة في مخطط عمودي أو خطي أو مساحي أو شريطي. في مخطط العمود، يكون المحور الأفقي. في مخطط شريطي أفقي، يكون محور الفئة عموديًا، لذا يُطبق هذا الإعداد على المحور الذي تُرجعه [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). كذلك يطبق تباعد علامات التقطيع على محور السلسلة في المخططات التي تحتوي على واحد.

لا تستخدم تباعد تسميات الفئة لتحديد مقياس رقمية لمحور القيمة. على محور القيمة، تحدد [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) فرق القيم: على سبيل المثال، وحدة رئيسية بقيمة `10` تُنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسميات الفئة `3` يعد مواضع الفئات بغض النظر عن قيمها. تستخدم مخططات التبعثر والفقاعات محاور قيم بدلاً من محور فئة نصية. بالنسبة لمحور التاريخ، استخدم وحدات زمنية رئيسية ومقاييس كما هو موضح في [Change a Category Axis](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال بيانات المخطط الافتراضية بأربعة قيم سنوية. تُخزن التواريخ كأرقام تسلسلية OLE Automation في ورقة العمل الأولى (الفهرس `0`)، محسوبة كعدد الأيام منذ 30 ديسمبر 1899. استخدم [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) مع [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date)، استدعِ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) مع `False`، ومرّر `yyyy` إلى [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) لتعرض تسميات الفئة سنوات بأربعة أرقام بشكل مستقل عن تنسيق الخلية.

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

## **تعيين زاوية دوران لعنوان محور المخطط**

استدعِ [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) مع `True` على المحور العمودي، قدم نص العنوان، وحدد زاوية الدوران في تنسيق كتلة نص العنوان. تُقاس الزاوية بالدرجات؛ يحفظ المثال مخطط عمودي بعنوان محور القيمة مدورًا بمقدار 90 درجة.

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

## **تحديد موضع المحور على محور الفئة أو القيمة**

استخدم [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) للتحكم بما إذا كان محور القيمة يعبر محور الفئة بين الفئات أو عند علامات الفئة. ينطبق هذا الإعداد على محاور الفئة. يضبط المثال هذه الخاصية إلى `True` على محور الفئة الأفقي في مخطط العمود ويحفظ النتيجة.

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

استخدم [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) لتكييف تسميات محور القيمة دون تعديل البيانات الأساسية. مع ضبط [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) إلى `Millions`، يُعرض القيمة 60,000,000 كـ 60. ينشئ المثال مخطط عمودي ويطبق وحدة العرض بالملايين على محوره العمودي.

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

## **تكوين محور قيمة لوغاريتمي**

محور قيمة لوغاريتمي مفيد عندما تمتد القيم الموجبة عبر عدة مرتاتب من القدر. على سبيل المثال، قد يتلقى خدمة 10، 100، 1,000، 10,000، و100,000 طلبًا خلال خمس فترات. على مقياس خطي، تظهر القيم الأصغر متقاربة قرب الصفر. يسهّل المقياس اللوغاريتمي مقارنة النمو النسبي: فالمسافات المتساوية تمثل نسبًا متساوية بدلاً من فروقًا متساوية.

استدعِ [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) مع `True` على محور القيمة واستخدم [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) لاختيار القاعدة. يغير هذا طريقة عرض القيم الحالية؛ ولا يغير البيانات ولا يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة ملائمة في البيانات وهو ميزة منفصلة.

### **اختيار محور القيمة والقاعدة**

في مخطط خطي أو عمودي، يُرجع محور القيمة بواسطة [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). في مخطط شريطي أفقي، يُرجع بواسطة [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). تحتوي مخططات التبعثر والفقاعات على محوري قيمة، لذا اختر المحور الأفقي لقيم X والمحور العمودي لقيم Y، أو كليهما. لا تُطبّق المقياس اللوغاريتمي على محور الفئة.

القاعدة اللوغاريتمية الافتراضية هي `10`. في مخططات PPTX، يمكن استخدام قاعدة من `2` إلى `1000` شاملة؛ وتدعم القواعد الكسرية مثل `2.5`. مع القاعدة `10`، تكون القوى المتتالية مثل 10، 100، 1,000، و10,000 متباعدة بصورة متساوية.

### **مقارنة التدرج الخطي واللوغاريتمي**

المثال التالي المستقل ينشئ مخططًا خطيًا يحتوي على عدد الطلبات الخمسة في الشريحة الأولى، ثم يستنسخ تلك الشريحة ويُفعّل محور قيمة لوغاريتمي بقاعدة 10 في الشريحة الثانية. تحتفظ كلتا الشريحتين بنفس البيانات.

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

    # احتفظ بالشريحة الأولى خطيًا وغيّر مقياس محور القيم في النسخة فقط.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**مقياس خطي (الشريحة 1):** المسافات الرأسية المتساوية تمثل اختلافات متساوية في عدد الطلبات. تهيمن القيمة الأكبر على المخطط، مما يصعّب تمييز القيم الأصغر.

![مخطط خطي في PowerPoint يُظهر خمس عدد طلبات على محور قيمة خطي](value-axis-linear.png)

**مقياس لوغاريتمي (الشريحة 2):** المسافات الرأسية المتساوية تمثل نسبًا متساوية. كل فترة بها عشرة أضعاف عدد الطلبات مقارنة بالفترة السابقة، لذا تتشكل النقاط كخط مستقيم صاعد على مقياس قاعدة 10. لا تزال تسميات المحور تُظهر عدد الطلبات الأصلي.

![نفس خمس عدد طلبات في PowerPoint على محور قيمة لوغاريتمي بقاعدة 10](value-axis-logarithmic.png)

### **معالجة القيم الصفرية والسالبة**

لا يمكن للمقياس اللوغاريتمي عرض إلا القيم الموجبة صراحة. تحقق من البيانات قبل تفعيل المقياس. إذا كانت القيم الصفرية أو السالبة ذات معنى، احتفظ بمقياس خطي أو اعرضها منفصلة. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسر الإقصاء. لا تستبدلها صامتًا بأرقام موجبة صغيرة، لأن ذلك يغيّر معنى البيانات. يجب أن تكون أي قيمة دنيا أو عظمى مُحددة يدويًا للمحور اللوغاريتمي موجبة également.

## **الأسئلة المتكررة**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها محور مع الآخر (تقاطع المحور)؟**  
استخدم [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) لتحديد سلوك التقاطع. لتحديد قيمة تقاطع رقمية، استخدم [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). تتيح لك هذه الإعدادات نقل تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني وضع تسميات العلامات بالنسبة للمحور؟**  
استدعِ [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`، `High`, `NextTo` أو `None`. للتحكم في علامات التقطيع نفسها، استخدم [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) أو [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark)؛ وهذه إعدادات مستقلة عن وضعية التسميات.