---
title: "تخصيص مخططات الدائرة في العروض التقديمية باستخدام Python عبر Java"
linktitle: "مخطط الدائرة"
type: docs
url: /ar/python-java/pie-chart/
keywords:
- مخطط الدائرة
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
description: "تعلم كيفية إنشاء وتخصيص مخططات الدائرة في Python عبر Java باستخدام Aspose.Slides، قابلة للتصدير إلى PowerPoint، مما يعزز رواية بياناتك في ثوانٍ."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع مخططات الدائرة في Aspose.Slides. توضح كيفية تكوين خيارات المخطط الثانوي لمخططات Pie of Pie و Bar of Pie، وكيفية تمكين تلوين الشرائح تلقائيًا لمخطط دائرة قياسي.

تركز الأمثلة على خطوات عملية لتخصيص المخطط مثل إضافة مخطط إلى شريحة، تعديل إعدادات السلاسل والتسميات، استبدال بيانات المخطط الافتراضية بفئات وقيم مخصصة، وحفظ العرض التقديمي المحدث.

## **خيارات المخطط الثانوي لمخططات Pie of Pie و Bar of Pie**

تدعم Aspose.Slides for Python via Java خيارات المخطط الثانوي لمخططات Pie of Pie و Bar of Pie. يوضح هذا القسم كيفية تحديد هذه الخيارات باستخدام Aspose.Slides. اتبع الخطوات التالية:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. إضافة مخطط إلى الشريحة.
1. تحديد خيارات المخطط الثانوي للمخطط.
1. كتابة العرض التقديمي إلى القرص.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# إنشاء نسخة من فئة Presentation.
presentation = Presentation()
try:
    # إضافة مخطط إلى الشريحة.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # تعيين خصائص مختلفة.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # كتابة العرض التقديمي إلى القرص.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين ألوان شرائح مخطط الدائرة تلقائيًا**

توفر Aspose.Slides for Python via Java واجهة برمجة تطبيقات بسيطة لتعيين ألوان شرائح مخطط الدائرة تلقائيًا. يوضح المثال التالي كيفية تطبيق هذه الإعدادات.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط مع بيانات افتراضية.
1. تعيين عنوان المخطط.
1. تعيين فهرس ورقة عمل بيانات المخطط.
1. الحصول على دفتر عمل بيانات المخطط.
1. حذف السلاسل والفئات الافتراضية.
1. إضافة فئات جديدة.
1. إضافة سلسلة جديدة.
1. تعيين السلسلة الجديدة لعرض القيم.

كتابة العرض التقديمي المعدل إلى ملف PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# إنشاء نسخة من فئة Presentation.
presentation = Presentation()
try:
    # إضافة مخطط ببيانات افتراضية.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # تعيين عنوان المخطط.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # تعيين فهرس ورقة عمل بيانات المخطط.
    default_worksheet_index = 0

    # الحصول على دفتر عمل بيانات المخطط.
    workbook = chart.getChartData().getChartDataWorkbook()

    # حذف السلاسل والفئات الافتراضية.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # إضافة فئات جديدة.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # إضافة سلسلة جديدة.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # ملء بيانات السلسلة.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # تعيين السلسلة الجديدة لعرض القيم.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يتم دعم تنويعات 'Pie of Pie' و 'Bar of Pie'؟**

نعم، المكتبة [تدعم](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/) مخططًا ثانويًا لمخططات الدائرة، بما في ذلك النوعين 'Pie of Pie' و 'Bar of Pie'.

**هل يمكنني تصيد المخطط فقط كصورة (على سبيل المثال، PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage) (مثل PNG) دون الحاجة إلى تصدير العرض التقديمي بالكامل.