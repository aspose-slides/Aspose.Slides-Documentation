---
title: إنشاء أو تحديث مخططات عروض PowerPoint التقديمية باستخدام بايثون
linktitle: إنشاء أو تحديث المخططات
type: docs
weight: 10
url: /ar/python-java/create-chart/
keywords:
- إضافة مخطط
- إنشاء مخطط
- تحرير مخطط
- تغيير مخطط
- تحديث مخطط
- مخطط مبعثر
- مخطط دائري
- مخطط خطي
- مخطط شجرة خريطة
- مخطط أسهم
- مخطط صندوق وشارب
- مخطط قمع
- مخطط شمسي
- مخطط مدرج تكراري
- مخطط رادار
- مخطط متعدد الفئات
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء وتخصيص المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides لبايثون عبر جافا. إضافة وتنسيق وتحرير المخططات مع أمثلة شفرة عملية في بايثون."
---
## **نظرة عامة**

توفر هذه المقالة دليلًا شاملاً حول كيفية إنشاء المخططات وتخصيصها باستخدام Aspose.Slides. ستتعلم كيفية إضافة مخطط برمجيًا إلى شريحة، وتعبئته بالبيانات، وتطبيق خيارات تنسيق مختلفة لتتناسب مع متطلبات التصميم الخاصة بك. سيتضمن المقال أمثلة شفرة مفصلة توضح كل خطوة، بدءًا من تهيئة العرض والكائن المخطط إلى تكوين السلاسل والمحاور والأساطير. باتباع هذا الدليل، ستحصل على فهم قوي لكيفية دمج إنشاء المخططات الديناميكية في تطبيقاتك، مما يسهل عملية إنشاء عروض تقديمية مدفوعة بالبيانات.

## **إنشاء مخطط**

تساعد المخططات الأشخاص على تصور البيانات بسرعة واستخلاص رؤى قد لا تكون واضحة فورًا من جدول أو ورقة عمل.

**لماذا نُنشئ مخططات؟**

باستخدام المخططات، يمكنك:

* تجميع أو تلخيص كميات كبيرة من البيانات في شريحة واحدة من العرض
* إظهار الأنماط والاتجاهات في البيانات
* استنتاج اتجاه وزخم البيانات عبر الوقت أو بالنسبة لوحدة قياس معينة
* اكتشاف القيم الشاذة أو الأخطاء أو البيانات غير المنطقية، إلخ
* توصيل أو عرض بيانات معقدة

في PowerPoint، يمكنك إنشاء المخططات عبر وظيفة *Insert* التي توفر قوالب لتصميم العديد من أنواع المخططات. باستخدام Aspose.Slides، يمكنك إنشاء مخططات عادية (بناءً على أنواع المخططات الشائعة) ومخططات مخصصة.

{{% alert color="info" title="ملاحظة" %}}
لإنشاء المخططات، استخدم الفئة [ChartType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/) . الحقول في هذه الفئة تمثل أنواع مخططات مختلفة.
{{% /alert %}}

### **إنشاء مخططات عمودية متجمعة**

تشرح هذه الفقرة كيفية إنشاء مخططات عمودية متجمعة باستخدام Aspose.Slides. ستتعلم تهيئة عرض تقديمي، إضافة مخطط، وتخصيص عناصره مثل العنوان والبيانات والسلاسل والفئات والتنسيق. اتبع الخطوات أدناه لرؤية كيفية إنشاء مخطط عمودي متجمع قياسي:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا به بعض البيانات وحدد النوع `ChartType.ClusteredColumn` .
4. أضف عنوانًا للمخطط.
5. الوصول إلى ورقة بيانات المخطط.
6. مسح جميع السلاسل والفئات الافتراضية.
7. إضافة سلاسل وفئات جديدة.
8. إضافة بيانات مخطط جديدة لسلسلة المخطط.
9. تطبيق لون تعبئة على سلسلة المخطط.
10. إضافة تسميات إلى سلسلة المخطط.
11. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود C# كيفية إنشاء مخطط عمودي متجمع:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# ينشئ كائن فئة عرض تقديمي تمثل ملف PPTX.
presentation = Presentation()
try:
    # الوصول إلى الشريحة الأولى
    slide = presentation.getSlides().get_Item(0)

    # إضافة مخطط ببياناته الافتراضية
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # تعيين عنوان المخطط
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # تحديد الفهرس لورقة بيانات المخطط
    default_worksheet_index = 0

    # الحصول على ورقة عمل بيانات المخطط
    workbook = chart.getChartData().getChartDataWorkbook()

    # حذف السلاسل والفئات المولدة افتراضيًا
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # إضافة سلاسل جديدة
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # إضافة فئات جديدة
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # أخذ السلسلة الأولى للمخطط
    series = chart.getChartData().getSeries().get_Item(0)

    # الآن يتم تعبئة بيانات السلسلة
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # تعيين لون التعبئة للسلسلة
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # أخذ السلسلة الثانية للمخطط
    series = chart.getChartData().getSeries().get_Item(1)

    # تعبئة بيانات السلسلة
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # تعيين لون التعبئة للسلسلة
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

#إنشاء تسميات مخصصة لكل فئة للسلسلة الجديدة
    # تعيين التسمية الأولى لإظهار اسم الفئة
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # إظهار القيمة للتسمية الثالثة
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # حفظ العرض التقديمي مع المخطط
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إنشاء مخططات تبعثر**

تُستخدم مخططات التبعثر (المعروفة أيضًا بمخططات النقاط أو مخططات x‑y) غالبًا للتحقق من الأنماط أو إظهار الارتباطات بين متغيرين.

استخدم مخطط تبعثر عندما:

* يكون لديك بيانات عددية مزدوجة
* يكون لديك متغيران يرتبطان جيدًا معًا
* تريد تحديد ما إذا كان المتغيران مرتبطين
* لديك متغير مستقل له قيم متعددة للمتغير التابع

1. اتبع الخطوات في [إنشاء مخططات عمودية متجمعة](#إنشاء-مخططات-عمودية-متجمعة).
2. في الخطوة الثالثة، أضف مخططًا به بعض البيانات وحدد نوع المخطط كواحد مما يلي:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _يمثل مخطط تبعثر._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _يمثل مخطط تبعثر متصل بمنحنيات، مع علامات بيانات._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _يمثل مخطط تبعثر متصل بمنحنيات، بدون علامات بيانات._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _يمثل مخطط تبعثر متصل بخطوط، مع علامات بيانات._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _يمثل مخطط تبعثر متصل بخطوط، بدون علامات بيانات._

يعرض هذا الكود Python كيفية إنشاء مخطط تبعثر مع علامات مختلفة لكل سلسلة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

    # ينشئ كائن فئة عرض تقديمي يمثل ملف PPTX.
    presentation = Presentation()
try:
    # الوصول إلى الشريحة الأولى
    slide = presentation.getSlides().get_Item(0)

    # إنشاء المخطط الافتراضي
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # الحصول على فهرس ورقة عمل بيانات المخطط الافتراضي
    default_worksheet_index = 0

    # الحصول على ورقة عمل بيانات المخطط
    workbook = chart.getChartData().getChartDataWorkbook()

    # حذف السلسلة التجريبية
    chart.getChartData().getSeries().clear()

    # إضافة سلاسل جديدة
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # أخذ السلسلة الأولى للمخطط
    series = chart.getChartData().getSeries().get_Item(0)

    # إضافة نقطة جديدة (1:3) إلى السلسلة
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # إضافة نقطة جديدة (2:10)
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # تغيير نوع السلسلة
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # تغيير علامة سلسلة المخطط
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # أخذ السلسلة الثانية للمخطط
    series = chart.getChartData().getSeries().get_Item(1)

    # إضافة نقطة جديدة (5:2) هناك
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # إضافة نقطة جديدة (3:1)
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # إضافة نقطة جديدة (2:2)
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # إضافة نقطة جديدة (5:1)
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # تغيير علامة سلسلة المخطط
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إنشاء مخططات دائرية**

تُستخدم المخططات الدائرية لإظهار علاقة الجزء بالكل في البيانات، خاصةً عندما تحتوي البيانات على تسميات فئوية مع قيم رقمية. إذا كان لدى بياناتك العديد من الأجزاء أو التسميات، قد تفضل استخدام مخطط شريطي بدلاً من ذلك.

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Pie](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#Pie) .
4. الوصول إلى دفتر بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة للسلسلة.
8. إضافة نقاط جديدة للمخطط وتطبيق ألوان مخصصة لقطاعات المخطط الدائري.
9. تعيين تسميات للسلسلة.
10. تمكين خطوط القادة لتسميات السلسلة.
11. ضبط زاوية الدوران لقطاعات المخطط الدائري.
12. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود Python كيفية إنشاء مخطط دائري:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

    # ينشئ كائن فئة عرض تقديمي يمثل ملف PPTX.
    presentation = Presentation()
try:
    # الوصول إلى الشريحة الأولى
    slide = presentation.getSlides().get_Item(0)

    # إضافة مخطط ببيانات افتراضية
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # تعيين عنوان المخطط
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # تعيين الفهرس لورقة بيانات المخطط
    default_worksheet_index = 0

    # الحصول على ورقة عمل بيانات المخطط
    workbook = chart.getChartData().getChartDataWorkbook()

    # حذف السلاسل والفئات المولدة افتراضيًا
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # إضافة فئات جديدة
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # إضافة سلاسل جديدة
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    #تعبئة بيانات السلسلة
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # إضافة نقاط جديدة وتعيين لون القطاع
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # تعيين حد القطاع
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # تعيين حد القطاع
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # تعيين حد القطاع
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # إنشاء تسميات مخصصة لكل فئة من الفئات للسلسلة الجديدة
    first_label = series.getDataPoints().get_Item(0).getLabel()
    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # إظهار خطوط القادة للمخطط
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # تعيين زاوية الدوران لقطاعات المخطط الدائري
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # حفظ العرض التقديمي مع مخطط
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إنشاء مخططات خطية**

تُستخدم المخططات الخطية (المعروفة أيضًا بالمخططات البيانية) عندما تريد إظهار تغير القيم عبر الزمن. باستخدام مخطط خطي، يمكنك مقارنة كمية كبيرة من البيانات في وقت واحد، تتبع التغيرات والاتجاهات بمرور الوقت، إبراز الشذوذ في سلاسل البيانات، وأكثر من ذلك.

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Line](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#Line) .
4. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود Python كيفية إنشاء مخطط خطي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

بشكل افتراضي، يتم ربط نقاط المخطط الخطي بخطوط مستقيمة مستمرة. إذا كنت تريد ربط النقاط بشرطات بدلاً من ذلك، يمكنك تحديد نوع الشريحة المفضلة كما يلي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إنشاء مخططات شجرة الخريطة**

تُستخدم مخططات شجرة الخريطة لبيانات المبيعات عندما تريد إظهار الحجم النسبي للفئات بسرعة وجذب الانتباه إلى العناصر التي تساهم بأكبر قدر في كل فئة.

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Treemap](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#Treemap) .
4. الوصول إلى دفتر بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة للسلسلة.
8. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود Python كيفية إنشاء مخطط شجرة الخريطة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #الفرع 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #الفرع 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إنشاء مخططات الأسهم**

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#OpenHighLowClose) .
4. الوصول إلى دفتر بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة للسلسلة.
8. تحديد تنسيق خطوط الارتفاع‑الانخفاض.
9. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود Python كيفية إنشاء مخطط أسهم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(1)
    cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(2)
    cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(3)
    cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for series in chart.getChartData().getSeries():
        series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إنشاء مخططات الصندوق والشارب**

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#BoxAndWhisker) .
4. الوصول إلى دفتر بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة للسلسلة.
8. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود Python كيفية إنشاء مخطط صندوق وشارب:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 1")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إنشاء مخططات القمع**

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Funnel](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#Funnel) .
4. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود Python كيفية إنشاء مخطط قمع:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إنشاء مخططات شمسية**

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Sunburst](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#Sunburst) .
4. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود Python كيفية إنشاء مخطط شمسي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #الفرع 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #الفرع 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إنشاء مخططات Histogram**

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.Histogram](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#Histogram) .
4. الوصول إلى دفتر بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود Python كيفية إنشاء مخطط Histogram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    cell = workbook.getCell(0, "A1", 15)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A2", -41)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A3", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A4", 10)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A5", -23)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A6", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic)

    presentation.save("Histogram.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إنشاء مخططات رادار**

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببعض البيانات وحدد نوع المخطط المفضل لديك ([ChartType.Radar](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#Radar) في هذه الحالة).
4. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود Python كيفية إنشاء مخطط رادار:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300)
    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إنشاء مخططات متعددة الفئات**

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. أضف مخططًا ببيانات افتراضية وحدد النوع [ChartType.ClusteredColumn](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/#ClusteredColumn) .
4. الوصول إلى دفتر بيانات المخطط [ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/) .
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات مخطط جديدة للسلسلة.
8. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود Python كيفية إنشاء مخطط متعدد الفئات:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450)
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)
    default_worksheet_index = 0

    cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(cell)

    # إضافة سلسلة
    cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(cell, ChartType.ClusteredColumn)

    cell = workbook.getCell(default_worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # حفظ العرض التقديمي مع المخطط
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إنشاء مخططات خريطة**

تُظهر مخططات الخريطة البيانات الجغرافية وتساعد على مقارنة القيم عبر المناطق.

يعرض هذا الكود Python كيفية إنشاء مخطط خريطة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400)
    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إنشاء مخططات مركبة**

المخطط المركب (أو مخطط الجمع) يجمع نوعين أو أكثر من المخططات في رسم بياني واحد. يتيح لك هذا المخطط إبراز أو مقارنة أو فحص الفروق بين مجموعتين أو أكثر من البيانات، مما يساعدك على تحديد العلاقات بينها.

![The combination chart](combination_chart.png)

يعرض الكود Python التالي كيفية إنشاء المخطط المركب الموضح أعلاه في عرض PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # تعيين عنوان المخطط.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # تعيين مفتاح المخطط.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # حذف السلاسل والفئات المولدة تلقائيًا.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # إضافة فئات جديدة.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # إضافة السلسلة الأولى.
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # تعيين المحور الأفقي.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # تعيين المحور العمودي.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # تعيين لون خطوط الشبكة العمودية الرئيسية.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # تعيين المحور الأفقي الثانوي.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # تعيين المحور العمودي الثانوي.
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    # تعيين عنوان المحور.
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **تحديث المخططات**

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي تمثل العرض الذي يحتوي على المخطط الذي تريد تحديثه.
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. تجول عبر جميع الأشكال للعثور على المخطط المطلوب.
4. الوصول إلى ورقة بيانات المخطط.
5. تعديل سلسلة بيانات المخطط بتغيير قيم السلسلة.
6. إضافة سلسلة جديدة وتعبئة بياناتها.
7. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود Python كيفية تحديث مخطط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# يفتح العرض التقديمي الذي يحتوي على المخطط لتحديثه
presentation = Presentation("ExistingChart.pptx")
try:
    # الوصول إلى الشريحة الأولى
    slide = presentation.getSlides().get_Item(0)

    # الحصول على المخطط من الشريحة
    chart = slide.getShapes().get_Item(0)

    # تعيين فهرس ورقة بيانات المخطط
    default_worksheet_index = 0

    # الحصول على ورقة عمل بيانات المخطط
    workbook = chart.getChartData().getChartDataWorkbook()

    # تغيير اسم فئة المخطط
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # أخذ السلسلة الأولى للمخطط
    series = chart.getChartData().getSeries().get_Item(0)

    # تحديث بيانات السلسلة الآن
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# تعديل اسم السلسلة
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # أخذ السلسلة الثانية للمخطط
    series = chart.getChartData().getSeries().get_Item(1)

    # تحديث بيانات السلسلة الآن
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# تعديل اسم السلسلة
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # الآن، إضافة سلسلة جديدة
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # أخذ السلسلة الثالثة للمخطط
    series = chart.getChartData().getSeries().get_Item(2)

    # الآن تعبئة بيانات السلسلة
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # حفظ العرض التقديمي مع المخطط
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين نطاق البيانات لمخطط**

لتعيين نطاق البيانات لمخطط، اتبع الخطوات التالية:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي تمثل العرض الذي يحتوي على المخطط.
2. احصل على مرجع إلى شريحة باستخدام فهرستها.
3. تجول عبر جميع الأشكال للعثور على المخطط المطلوب.
4. الوصول إلى بيانات المخطط وتعيين النطاق.
5. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود Python كيفية تعيين نطاق البيانات لمخطط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# يفتح العرض التقديمي الذي يحتوي على المخطط
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استخدام العلامات الافتراضية في المخططات**

عند استخدام العلامات الافتراضية في المخططات، يحصل كل سلسلة مخطط تلقائيًا على رمز علامة مختلف.

يعرض هذا الكود Python كيفية تعيين علامة سلسلة مخطط تلقائيًا:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(cell)

    cell = workbook.getCell(0, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())
#أخذ السلسلة الثانية للمخطط
    second_series = chart.getChartData().getSeries().get_Item(1)

#الآن تعبئة بيانات السلسلة
    cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**ما هي أنواع المخططات التي يدعمها Aspose.Slides؟**

يدعم Aspose.Slides مجموعة واسعة من [أنواع المخططات](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/)، بما في ذلك المخططات الشريطية، الخطية، الدائرية، المساحية، التبعثر، Histogram، Radar، والعديد غيرها. هذه المرونة تسمح لك باختيار النوع الأنسب لاحتياجات تصور البيانات الخاصة بك.

**كيف يمكنني إضافة مخطط جديد إلى شريحة؟**

لإضافة مخطط، أولًا أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) ، استرجع الشريحة المطلوبة باستخدام فهرستها، ثم استدع طريقة إضافة مخطط مع تحديد نوع المخطط والبيانات الأولية. يدمج هذا العملية المخطط مباشرة في العرض.

**كيف يمكنني تحديث البيانات المعروضة في مخطط؟**

يمكنك تحديث بيانات المخطط بالوصول إلى دفتر بياناته ([ChartDataWorkbook](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdataworkbook/))، مسح أي سلاسل وفئات افتراضية، ثم إضافة بياناتك المخصصة. يتيح لك ذلك إ刷新 المخطط ليعكس أحدث البيانات.

**هل يمكن تخصيص مظهر المخطط؟**

نعم، يوفر Aspose.Slides خيارات تخصيص واسعة. يمكنك تعديل الألوان، الخطوط، التسميات، الأساطير، وعناصر [التنسيق](/slides/ar/python-java/chart-entities/) الأخرى لتلائم التصميم المطلوب.