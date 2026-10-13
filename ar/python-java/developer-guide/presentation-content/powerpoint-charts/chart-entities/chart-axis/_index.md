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
- التلاعب بالمحور
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
description: "اكتشف كيفية استخدام Aspose.Slides للغة بايثون عبر Java لتخصيص محاور المخططات في عروض PowerPoint التقديمية للتقارير والتصوير البياني."
---
## **نظرة عامة**

هذا المقال يشرح كيفية تخصيص محاور المخطط باستخدام Aspose.Slides للغة Python عبر Java. يغطي القيم المحسوبة للمحاور، تبديل صفوف وأعمدة المخطط، رؤية المحور، فواصل تسميات الفئة وعلامات القسمة، الفئات التاريخية وتنسيقها، تدوير العنوان، موضع المحور، وحدات العرض، والقياس اللوغاريتمي.

## **الحصول على القيم القصوى على المحور الرأسي للمخطط**

إنشاء [العرض التقديمي](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) وإضافة مخطط مساحي ببيانات افتراضية. استدعاء [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) قبل قراءة القيم المحسوبة للمحور لضمان تحديث تخطيط المخطط.

قراءة [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) و[ getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) لحدود المحور، و[ getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) و[ getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) لفواصل العلامات. [ getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) و[ getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) توفر مقاييس الوحدات الزمنية، وهي ذات صلة بمحاور التاريخ. المثال يخزن هذه القيم في متغيرات محلية ويحفظ المخطط.

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

استخدم [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) لتبادل أدوار السلاسل والفئات في بيانات المخطط. كل فئة سابقة تصبح سلسلة، وكل سلسلة سابقة تصبح فئة. هذا يغير طريقة تجميع البيانات؛ ولا يبدل المحاور الأفقية والرأسية. المثال يستخدم [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) لربط البيانات الافتراضية بـ`Sheet1!A1:D5`، بما في ذلك صف العنوان وعمود الفئة، قبل تبديل الصفوف والأعمدة. يحفظ مخططًا بأربع سلاسل وثلاث فئات.

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

## **تعطيل المحور الرأسي للمخططات الخطية**

استدعاء [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) بـ`False` على المحور الرأسي لإخفائه. المثال ينشئ مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الرأسي.

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

## **تعطيل المحور الأفقي للمخططات الخطية**

استدعاء [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) بـ`False` على المحور الأفقي لإخفائه. المثال ينشئ مخططًا خطيًا ببيانات افتراضية ويحفظه مع إخفاء المحور الأفقي.

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

استخدم [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) لاختيار محور فئة تاريخي أو نصي. يتطلب هذا المثال ملف `ExistingChart.pptx`، مع مخطط كأول شكل في الشريحة الأولى وخلايا فئة تحتوي على قيم تاريخية من Excel رقمية. يغيّر المحور الأفقي إلى محور تاريخ. استدعاء [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) بـ`False`، و[setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) بـ`1`، و[setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) بـ[TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) يضع العلامات الرئيسية بفواصل شهر واحد.

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

عند وجود many categories في مخطط، قلل عدد التسميات الظاهرة للمحور دون إزالة الفئات أو نقاط البيانات. استدعاء [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) بـ`False`، ثم مرّر الفاصل المطلوب إلى [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). بالنسبة للفئات النصية بترتيبها الطبيعي، يبدأ العد من الفئة الأولى:

| الفاصل | التسميات المعروضة في المثال |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

فاصل `3` يعرض كل تسمية ثالثة، مع إخفاء اثنتين بينهما. لا يزيل الأعمدة المقابلة. الاختيار التلقائي للفاصل يحدده وفق المساحة المتاحة؛ ولا يضمن عرض كل تسمية.

علامات القسمة لها تحكم منفصل. استدعاء [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) بـ`False` واستخدام [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) لتحديد فاصلها. على سبيل المثال، `1` يحافظ على علامة قسمة عند كل فاصل فئة بينما تظهر التسميات كل فئة ثالثة فقط. استخدم [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) بنمط مرئي لتلاحظ النتيجة. استدعاء أحد مُعدّلات التباعد التلقائي بـ`True` مرة أخرى يسمح للمخطط باختيار الفاصل تلقائيًا مرة أخرى.

المثال المتكامل التالي يخلق 24 فئة وسلسلة واحدة، ثم يحفظ ثلاث شرائح في `CategoryAxisIntervals.pptx`: تباعد تلقائي، تباعد يدوي للتسمية مع علامات قسمة مستقلة، واستعادة التباعد التلقائي. النسختان تحتفظان ببيانات المخطط الأصلية. لا يلزم عرض تقديمي إدخال. نص التسمية الأفقي يُظهر الفرق في الكثافة بوضوح.

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

    # Slide 2: إظهار كل تسمية ثالثة، مع الحفاظ على علامة قسمة لكل فئة.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Slide 3: السماح للمخطط باختيار كلا الفاصلين مرة أخرى.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**تباعد تلقائي (الشريحة 1):** في هذا العرض، تُعرض كل تسمية فئة ثانية وتلتف إلى سطرين. النتيجة التلقائية قد تختلف حسب حجم المخطط، الخطوط، والمُظهر.

![تباعد تلقائي لتسميات الفئة مع إظهار جميع الأعمدة الـ24](category-axis-automatic.png)

**تباعد يدوي (الشريحة 2):** تُعرض كل تسمية ثالثة على سطر واحد، بينما تبقى علامات القسمة عند كل فاصل فئة. جميع الأعمدة الـ24، بما فيها تلك بدون تسميات، تظل مرئية بنفس القيم. الشريحة 3 تستعيد المظهر التلقائي المعروض أعلاه.

![تباعد يدوي لتسميات الفئة ثلاثة مع إظهار جميع الأعمدة الـ24](category-axis-manual.png)

### **اختر المحور والفاصل الصحيح**

استخدم هذا الفاصل العددي لمحور فئة نصية، مثل محور الفئة في مخطط عمودي، خطي، مساحي، أو شريطي. في مخطط عمودي، هو المحور الأفقي. في مخطط شريطي أفقي، يكون محور الفئة عموديًا، لذا طبّق هذه الإعدادات على المحور الذي تُرجعه [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). فاصل علامات القسمة ينطبق أيضًا على محور السلسلة في المخططات التي لديها واحد.

لا تستخدم فاصل تسميات الفئة لتعيين مقياس رقمي لمحور القيمة. على محور القيمة، يحدد [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) فرق القيم: على سبيل المثال، وحدة رئيسية `10` تنتج علامات عند 0، 10، 20، وهكذا عندما يبدأ المحور من الصفر. فاصل تسمية الفئة `3` يعد مواضع الفئات بغض النظر عن قيمها. مخططات التناثر والفقاعات تستخدم محاور قيمة بدلًا من محور فئة نصية. بالنسبة لمحور تاريخ، استخدم وحدات زمنية رئيسية ومقاييس كما هو موضح في [تغيير محور الفئة](#change-a-category-axis).

## **تعيين تنسيق التاريخ لقيم محور الفئة**

يستبدل المثال بيانات المخطط الافتراضية بأربعة قيم سنوية. تُخزن التواريخ كأرقام تسلسلية OLE Automation في الورقة الأولى (الفهرس `0`)، محسوبة كعدد الأيام منذ 30 ديسمبر 1899. استخدم [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) مع [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date)، استدعِ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) بـ`False`، ومرّر `yyyy` إلى [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) ليعرض تسميات الفئة أربع سنوات بأرقام ثابتة بغض النظر عن تنسيق الخلية.

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

استدعِ [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) بـ`True` على المحور الرأسي، قدم نص العنوان، واضبط زاوية الدوران في تنسيق كتلة نص العنوان. الزاوية تُقاس بالدرجات؛ المثال يحفظ مخطط عمودي مع دوران عنوان محور القيمة بزاوية 90 درجة.

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

استخدم [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) للتحكم فيما إذا كان محور القيمة يعبر محور الفئة بين الفئات أو عند علامات الفئات. هذا الإعداد يخص محاور الفئة. المثال يضبطه على `True` على محور الفئة الأفقي لمخطط عمودي ويحفظ النتيجة.

```python
import jpade
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

استخدم [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) لتقليص تسميات محور القيمة دون تغيير البيانات الأساسية. مع [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) معينًا إلى `Millions`، تُعرض القيمة 60,000,000 كـ60. المثال ينشئ مخططًا عموديًا ويطبق وحدة العرض بالملايين على محوره الرأسي.

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

محور قيمة لوغاريتمي مفيد عندما تتراوح القيم الإيجابية عبر عدة مرتبات من الحجم. على سبيل المثال، قد يتلقى خدمة 10، 100، 1,000، 10,000، و100,000 طلبًا عبر خمس فترات. على مقياس خطي، تظهر القيم الصغيرة متقاربة بالقرب من الصفر. مقياس لوغاريتمي يجعل النمو النسبي أسهل للمقارنة: الفواصل المتساوية تمثل نسبًا متساوية بدلًا من فروق متساوية.

استدعِ [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) بـ`True` على محور القيمة واستخدم [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) لاختيار القاعدة. هذا يغيّر طريقة عرض القيم الحالية؛ ولا يغيّر البيانات أو يضيف خط اتجاه لوغاريتمي. خط الاتجاه يمثل علاقة مُركبة في البيانات وهو ميزة منفصلة.

### **اختر محور القيمة والقاعدة**

للمخطط الخطّي أو العمودي، يُرجع محور القيمة بواسطة [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). للمخطط الشريطي الأفقي، يُرجعه [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). مخططات التناثر والفقاعات لها محوران قيميان، لذا اختر المحور الأفقي لقيم X، والمحور الرأسي لقيم Y، أو كليهما. لا تُطبق القياس اللوغاريتمي على محور الفئة.

القاعدة اللوغاريتمية الافتراضية هي `10`. لمخططات PPTX، استخدم قاعدة من `2` إلى `1000` شاملًا؛ القواعد الكسرية مثل `2.5` مدعومة أيضًا. مع القاعدة `10`، تُوزع القوى المتتالية مثل 10، 100، 1,000، و10,000 بالتساوي.

### **قارن القياس الخطي واللوغاريتمي**

المثال المتكامل التالي ينشئ مخططًا خطيًا يحتوي على خمس عدد طلبات على الشريحة الأولى، ثم ينسخ تلك الشريحة ويفعل محور قيمة لوغاريتمي بالقاعدة 10 على الشريحة الثانية. كلا الشريحتين تحتفظان بنفس البيانات.

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

    # حافظ على أن تكون الشريحة الأولى خطية وغيّر فقط مقياس محور القيمة للنسخة.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**مقياس خطي (الشريحة 1):** المسافات العمودية المتساوية تمثل فروقًا متساوية في عدد الطلبات. القيمة الأكبر تهيمن على المخطط، مما يصعب تمييز القيم الصغيرة.

![مخطط خطي في PowerPoint يظهر خمس طلبات على محور قيمة خطي](value-axis-linear.png)

**مقياس لوغاريتمي (الشريحة 2):** المسافات العمودية المتساوية تمثل نسبًا متساوية. كل فترة لديها عشرة أضعاف الطلبات من السابقة، لذا تشكل النقاط خطًا مستقيمًا صاعدًا على مقياس القاعدة 10. لا تزال تسميات المحور تظهر عدد الطلبات الأصلية.

![نفس الخمس طلبات في PowerPoint على محور قيمة لوغاريتمي بالقاعدة 10](value-axis-logarithmic.png)

### **معالجة القيم الصفرية والسالبة**

المقياس اللوغاريتمي يمكنه عرض قيم إيجابية فقط. تحقق من البيانات قبل تفعيله. إذا كانت القيم صفرًا أو سالبة ذات معنى، احتفظ بالمقياس الخطي أو اعرضها بشكل منفصل. إذا كان استبعاد تلك القيم مناسبًا للتحليل، فسّر الإهمال. لا تستبدلها صمتًا بأعداد صغيرة موجبة، لأن ذلك يغيّر معنى البيانات. أي حد أدنى أو أقصى يُضبط يدويًا لمحور لوغاريتمي يجب أن يكون إيجابيًا أيضًا.

## **الأسئلة المتكررة**

**كيف يمكنني تحديد القيمة التي يتقاطع عندها محور مع الآخر (تقاطع المحور)؟**

استخدم [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) لتحديد سلوك التقاطع. لتحديد قيمة تقاطع رقمية، استخدم [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). هذه الإعدادات تسمح لك بتحريك تقاطع المحور إلى خط أساس مناسب.

**كيف يمكنني وضع تسميات العلامات بالنسبة إلى المحور؟**

استدعِ [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) باستخدام [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo`، أو `None`. للتحكم في علامات القسمة نفسها، استخدم [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) أو [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark)؛ هذه منفصلة عن وضع التسميات.