---
title: تخصيص مخططات الفطيرة في العروض التقديمية باستخدام بايثون عبر جافا
linktitle: مخطط الفطيرة
type: docs
url: /ar/python-java/pie-chart/
keywords:
- مخطط فطيرة
- إدارة المخطط
- تخصيص المخطط
- خيارات المخطط
- إعدادات المخطط
- خيارات الرسم
- لون الشريحة
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء وتخصيص مخططات الفطيرة في بايثون عبر جافا باستخدام Aspose.Slides. تكوين الرسوم الثانوية، عرض تسميات البيانات، وتطبيق ألوان شرائح تلقائية في PowerPoint."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع مخططات الفطيرة في Aspose.Slides. توضح كيفية تكوين خيارات الرسم الثانوي لمخططات Pie of Pie و Bar of Pie، وكيفية تمكين تلوين الشرائح تلقائيًا لمخطط الفطيرة القياسي.

تركز الأمثلة على مهام تخصيص المخطط مثل إضافة مخطط إلى شريحة، وضبط إعدادات السلسلة والتسمية، واستبدال بيانات المخطط الافتراضية بفئات وقيم مخصصة، وحفظ العرض التقديمي المحدث.

## **خيارات الرسم الثانوي لمخططات Pie of Pie و Bar of Pie**

يدعم Aspose.Slides for Python via Java خيارات الرسم الثانوي لمخططات Pie of Pie و Bar of Pie. تتحكم هذه الخيارات في حجم الرسم الثانوي وكيفية تقسيم نقاط البيانات بين الرسمين.

المثال التالي ينشئ مخطط Pie of Pie في عرض تقديمي جديد ويعرض قيم نقاط البيانات كملصقات. طريقة [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) تحدد حجم الرسم الثانوي إلى 149٪ من الرسم الرئيسي. [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) تختار التقسيم بنسب مئوية، و[setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) تحدد العتبة إلى 53٪.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # عرض القيم وتكوين الرسم الثانوي.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **اختر الفئات للرسم الثانوي**

استخدم التقسيم المخصص عندما تريد تجميع فئات معينة في الرسم الثانوي بغض النظر عن قيم النسبة المئوية الخاصة بها. على سبيل المثال، قد يظهر تقرير المبيعات Online وEvents معًا حتى يتمكن القارئ من مقارنة القناتين، على الرغم من أن كلًا منهما يمثل 35٪ و10٪ من إجمالي المبيعات.

استدعِ [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) مع [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) وحدد النقاط عبر [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). تقبل طريقة المجموعة [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) فهرسًا يبدأ من الصفر في السلسلة؛ استخدم [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) لإضافة كائن نقطة بيانات. في هذا المثال، يختار الفهرس 1 Online، وتختار النقطة في الفهرس 3 Events. يتم إضافة Partners مؤقتًا، ثم استثناؤه باستخدام [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # استبدل البيانات الافتراضية بمبيعات حسب القناة.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # اختر Online حسب الفهرس الصفري وEvents حسب كائن نقطة البيانات.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # استبعد Partners من الاختيار دون حذف بيانات المصدر الخاصة به.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تظهر Online (35) وEvents (10) كشرائح منفصلة في الرسم الثانوي. في الرسم الأساسي، يتم تمثيلهما بشريحة مجمعة قيمة 45، إلى جانب Retail (40) وPartners (15). إزالة Partners من الاختيار المخصص تبقيها في الرسم الأساسي؛ لا تُزيل الفئة أو قيمتها من بيانات مصدر المخطط.

الصورة التالية تُظهر العرض التقديمي المحفوظ في PowerPoint:

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **تعيين ألوان شرائح مخطط الفطيرة تلقائيًا**

يمكن لـ Aspose.Slides for Python via Java تعيين ألوان مختلفة تلقائيًا لشرائح مخطط الفطيرة. المثال التالي ينشئ مخطط فطيرة بعنوان مركزي ويستبدل البيانات الافتراضية بثلاث فئات ربع سنوية وقيمها. طريقة [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) تعرض القيم 20 و50 و30 كملصقات، بينما تمكن طريقة [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) من لون مميز لكل شريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # أضف عنوانًا مركزيًا للمخطط.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # استبدل البيانات الافتراضية باستخدام ورقة العمل الأولى.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # اعرض القيم وعيّن ألوانًا مختلفة للشرائح.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل يتم دعم تنويعات Pie of Pie و Bar of Pie؟**

نعم، المكتبة [supports](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) رسمًا ثانويًا لمخططات الفطيرة، بما في ذلك أنواع Pie of Pie وBar of Pie.

**هل يمكنني تصدير المخطط فقط كصورة (مثلاً PNG)؟**

نعم، يمكنك [export the chart itself as an image](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (مثل PNG) بدون تصدير العرض التقديمي بأكمله.