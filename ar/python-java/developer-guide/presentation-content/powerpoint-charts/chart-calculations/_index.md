---
title: تحسين حسابات المخطط للعروض التقديمية في Python عبر Java
linktitle: حسابات المخطط
type: docs
weight: 50
url: /ar/python-java/chart-calculations/
keywords:
- حسابات المخطط
- عناصر المخطط
- موضع العنصر
- الموضع الفعلي
- عنصر فرعي
- العنصر الأصلي
- قِيَم المخطط
- القيمة الفعلية
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "فهم حسابات المخطط، وتحديثات البيانات، والتحكم في الدقة في Aspose.Slides للـ Python عبر Java لملفات PPT و PPTX، مع أمثلة عملية على كود Python."
---
## **نظرة عامة**

Aspose.Slides تزودك بواجهات برمجة التطبيقات للعمل مع حسابات الرسوم البيانية وبيانات التخطيط في العروض التقديمية. توضح هذه المقالة كيفية استرجاع القيم الفعلية لعناصر المخطط، بما في ذلك الموضع الفعلي وحجم العناصر والقيم الفعلية لمحاور المخطط. كما تشرح أن هذه القيم تُملأ بعد إجراء التحقق من صحة تخطيط المخطط.

بالإضافة إلى ذلك، تُظهر المقالة كيفية الحصول على الموضع الفعلي لعناصر المخطط الأصلية وكيفية إخفاء مكونات المخطط مثل العنوان والمحاور والوسيلة التوضيحية وخطوط الشبكة. معًا، تساعدك هذه الأمثلة على فحص معلومات تخطيط المخطط والتحكم في رؤية عناصر المخطط في عروض PowerPoint برمجيًا.

## **حساب القيم الفعلية لعناصر المخطط**
Aspose.Slides for Python via Java يوفر واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر طرق فئة [Axis](https://reference.aspose.com/slides/ar/python-java/aspose.slides/axis/) معلومات حول القيم الفعلية لمحاور المخطط ([getActualMaxValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/ar/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/ar/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/ar/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/ar/python-java/aspose.slides/axis/#getActualMinorUnitScale)). استدعِ طريقة [Chart.validateChartLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#validateChartLayout) أولاً لملء هذه الخصائص بالقيم الفعلية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **حساب الموضع الفعلي لعناصر المخطط الأصلية**
Aspose.Slides for Python via Java يوفر واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر طرق فئة [ChartPlotArea](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartplotarea/) معلومات حول الموضع الفعلي وحجم منطقة رسم المخطط ([getActualX](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartplotarea/#getActualHeight)). استدعِ طريقة [Chart.validateChartLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#validateChartLayout) أولاً لملء هذه الخصائص بالقيم الفعلية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **إخفاء عناصر المخطط**
تشرح هذه الفقرة كيفية إخفاء المعلومات من المخطط. باستخدام Aspose.Slides for Python via Java، يمكنك إخفاء **Title, Vertical Axis, Horizontal Axis** و**Grid Lines**. يوضح المثال البرمجي التالي كيفية استخدام هذه الخصائص.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # إخفاء عنوان المخطط.
    chart.setTitle(False)

    # إخفاء محور القيم.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # إخفاء محور الفئات.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # إخفاء الوسيلة التوضيحية.
    chart.setLegend(False)

    # إخفاء خطوط الشبكة الرئيسية.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # الاحتفاظ بالسلسلة الأولى فقط. الإزالة من النهاية تحافظ على صلاحية الفهارس المتبقية.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # تعيين لون خط السلسلة.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل تعمل دفاتر عمل Excel الخارجية كمصدر للبيانات، وكيف يؤثر ذلك على إعادة الحساب؟**

نعم. يمكن للمخطط الإشارة إلى دفتر عمل خارجي: عند الاتصال أو تحديث المصدر الخارجي، تُؤخذ المعادلات والقيم من ذلك الدفتر، ويعكس المخطط التغييرات أثناء عمليات الفتح/التحرير. تتيح لك الواجهة برمجة التطبيقات [تحديد دفتر العمل الخارجي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#setExternalWorkbook) والمسار وإدارة البيانات المرتبطة.

**هل يمكنني حساب وعرض خطوط الاتجاه دون تنفيذ الانحدار بنفسي؟**

نعم. [خطوط الاتجاه](/slides/ar/python-java/trend-line/) (خطية، أسية، وغيرها) تُضاف وتُحدَّث تلقائيًا بواسطة Aspose.Slides؛ يتم إعادة حساب معلماتها من بيانات السلاسل تلقائيًا، لذا لا تحتاج إلى تنفيذ حساباتك الخاصة.

**إذا كان العرض التقديمي يحتوي على مخططات متعددة بروابط خارجية، هل يمكنني التحكم في دفتر العمل الذي يستخدمه كل مخطط للقيم المحسوبة؟**

نعم. يمكن لكل مخطط الإشارة إلى [دفتر عمل خارجي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#setExternalWorkbook) خاص به، أو يمكنك إنشاء/استبدال دفتر عمل خارجي لكل مخطط بشكل مستقل عن الآخرين.