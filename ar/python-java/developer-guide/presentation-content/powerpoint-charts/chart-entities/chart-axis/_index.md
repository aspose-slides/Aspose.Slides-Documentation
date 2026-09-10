---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام Python
linktitle: محور المخطط
type: docs
url: /ar/python-java/chart-axis/
keywords:
- محور المخطط
- المحور العمودي
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
description: "اكتشف كيف تستخدم Aspose.Slides for Python via Java لتخصيص محاور المخططات في عروض PowerPoint التقديمية للتقارير والتصورات."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تخصيص محاور المخطط في Aspose.Slides. تُظهر كيفية الحصول على قيم المحاور الفعلية، تبديل البيانات بين المحاور، إخفاء المحور العمودي أو الأفقي للمخططات الخطية، تغيير نوع محور الفئة، ضبط تنسيق التاريخ لقيم محور الفئة، تدوير عنوان المحور، ضبط موضع المحور، وضبط وحدة العرض لمحور القيمة.

## **الحصول على القيم القصوى على المحور العمودي لمخطط**

يتيح Aspose.Slides for Python via Java إمكانية الحصول على القيم الدنيا والعظمى على المحور العمودي. اتبع الخطوات التالية:

1. إنشاء نسخة من الصنف [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. الحصول على القيمة القصوى الفعلية على المحور.
1. الحصول على القيمة الدنيا الفعلية على المحور.
1. الحصول على الوحدة الرئيسية الفعلية للمحور.
1. الحصول على الوحدة الفرعية الفعلية للمحور.
1. الحصول على مقياس الوحدة الرئيسية الفعلية للمحور.
1. الحصول على مقياس الوحدة الفرعية الفعلية للمحور.

هذا مثال على الشيفرة—تنفيذ الخطوات أعلاه—يوضح كيفية الحصول على القيم المطلوبة في Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # يحفظ العرض التقديمي
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تبديل البيانات بين المحاور**

يتيح Aspose.Slides تبديل البيانات بسرعة بين المحاور—تنتقل البيانات الموجودة على المحور العمودي (y‑axis) إلى المحور الأفقي (x‑axis) والعكس بالعكس.

تُظهر هذه الشيفرة Python كيفية إجراء عملية تبديل البيانات بين المحاور في مخطط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # يحمل البيانات الافتراضية للمخطط إلى دفتر العمل — switchRowColumn ينقل دفتر العمل، لذا يجب تعبئته أولاً
    workbook = chart.getChartData().getChartDataWorkbook()

    # يبدل الصفوف والأعمدة
    chart.getChartData().switchRowColumn()

    # يحفظ العرض التقديمي
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعطيل المحور العمودي للمخططات الخطية**

تُظهر هذه الشيفرة Python كيفية إخفاء المحور العمودي لمخطط خطي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعطيل المحور الأفقي للمخططات الخطية**

تُظهر هذه الشيفرة كيفية إخفاء المحور الأفقي لمخطط خطي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تغيير محور الفئة**

باستخدام الطريقة [setCategoryAxisType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/axis/#setCategoryAxisType) يمكنك تحديد نوع محور الفئة المفضل لديك (**date** أو **text**). تُظهر هذه الشيفرة في Python العملية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **ضبط تنسيق التاريخ لقيم محور الفئة**

يتيح Aspose.Slides for Python via Java ضبط تنسيق التاريخ لقيمة محور الفئة. تُظهر الشيفرة Python العملية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ضبط زاوية الدوران لعنوان محور المخطط**

يتيح Aspose.Slides for Python via Java ضبط زاوية الدوران لعنوان محور المخطط. تُظهر هذه الشيفرة Python العملية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ضبط موضع المحور على محور الفئة أو القيمة**

يتيح Aspose.Slides for Python via Java ضبط موضع المحور على محور الفئة أو القيمة. تُظهر هذه الشيفرة Python كيفية تنفيذ المهمة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ضبط وحدة العرض على محور قيمة المخطط**

يتيح Aspose.Slides for Python via Java ضبط وحدة العرض لمحور قيمة المخطط. عندها يقوم المحور بتكبير تسميات العلامات وفقًا لتلك الوحدة: مع [DisplayUnitType.Millions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/displayunittype/#Millions)، يُسَمّى المحور الذي يمتد إلى 60,000,000 بـ 0 إلى 60. تُظهر هذه الشيفرة Python العملية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها محور واحد مع الآخر (تقاطع المحاور)؟**

توفر المحاور إعدادًا لـ [crossing](https://reference.aspose.com/slides/ar/python-java/aspose.slides/axis/#setCrossType): يمكنك اختيار التقاطع عند الصفر، عند الحد الأقصى للفئة/القيمة، أو عند قيمة عددية محددة. هذا مفيد لتحريك محور X للأعلى أو الأسفل أو لتأكيد خط أساس.

**كيف يمكنني وضع علامات الفواصل بالنسبة للمحور (التقاطع، الخارج، الداخل)؟**

قم بتعيين [tick mark position](https://reference.aspose.com/slides/ar/python-java/aspose.slides/axis/#setMajorTickMark) إلى "cross" أو "outside" أو "inside". يؤثر ذلك على القابلية للقراءة ويساعد على توفير مساحة، خاصةً في المخططات الصغيرة.