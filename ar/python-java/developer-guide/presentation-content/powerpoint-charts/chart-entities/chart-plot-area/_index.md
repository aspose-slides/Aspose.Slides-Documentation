---
title: تخصيص مساحات الرسم لمخططات العروض التقديمية في بايثون
linktitle: مساحة الرسم
type: docs
url: /ar/python-java/chart-plot-area/
keywords:
- مخطط
- مساحة الرسم
- عرض مساحة الرسم
- ارتفاع مساحة الرسم
- حجم مساحة الرسم
- وضع التخطيط
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "اكتشف كيفية تخصيص مساحات رسم المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides لبايثون عبر جافا. حسّن مظهر الشرائح بسهولة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية التعامل مع مساحة رسم المخطط في Aspose.Slides. تشرح كيفية الحصول على الموقع الفعلي وحجم مساحة الرسم من خلال التحقق من تخطيط المخطط ثم قراءة قيم X وY والعرض والارتفاع.

كما توضح كيفية تكوين وضع تخطيط مساحة الرسم عندما يتم تعيين التخطيط يدويًا، باستخدام [LayoutTargetType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layouttargettype/) لتحديد ما إذا كانت مساحة الرسم تحسب بمنطقتها الداخلية أو بمنطقتها الخارجية مع المحاور وتسميات المحاور.

## **الحصول على العرض والارتفاع لمساحة رسم المخطط**

Aspose.Slides for Python via Java يوفر واجهة برمجة تطبيقات بسيطة لقراءة الموقع الفعلي وحجم مساحة رسم المخطط.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. استدعاء الطريقة [Chart.validateChartLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#validateChartLayout) قبل الحصول على القيم الفعلية.
1. الحصول على موضع X الفعلي (يسار) لعنصر المخطط بالنسبة للزاوية العلوية اليسرى للمخطط.
1. الحصول على موضع Y الفعلي (أعلى) لعنصر المخطط بالنسبة للزاوية العلوية اليسرى للمخطط.
1. الحصول على العرض الفعلي لعنصر المخطط.
1. الحصول على الارتفاع الفعلي لعنصر المخطط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# إنشاء مثيل من فئة Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **تعيين وضع التخطيط لمساحة رسم المخطط**

Aspose.Slides for Python via Java يوفر واجهة برمجة تطبيقات بسيطة لتعيين وضع تخطيط مساحة رسم المخطط. الطريقتان [setLayoutTargetType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) و [getLayoutTargetType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) متاحتان في الفئة [ChartPlotArea](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartplotarea/). إذا تم تعريف تخطيط مساحة الرسم يدويًا، يحدد هذا الإعداد ما إذا كان يتم تخطيط مساحة الرسم من الداخل (باستثناء المحاور وتسميات المحاور) أو من الخارج (متضمنًا المحاور وتسميات المحاور). هناك قيمتان ممكنتان معرفة في تعداد [LayoutTargetType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layouttargettype/) .

- [Inner](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layouttargettype/#Inner) يعني أن حجم مساحة الرسم يستثني علامات الفواصل وتسميات المحاور.
- [Outer](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layouttargettype/#Outer) يعني أن حجم مساحة الرسم ي شامل علامات الفواصل وتسميات المحاور.

الكود النموذجي موضح أدناه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# إنشاء مثيل من فئة Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**بأي وحدات يتم إرجاع X الفعلي وY الفعلي والعرض الفعلي والارتفاع الفعلي؟**

بالنقاط؛ 1 بوصة = 72 نقطة. هذه هي وحدات إحداثيات Aspose.Slides.

**كيف تختلف مساحة الرسم عن مساحة المخطط من حيث المحتوى؟**

مساحة الرسم هي منطقة رسم البيانات (السلاسل، خطوط الشبكة، خطوط الاتجاه، إلخ)؛ بينما تشمل مساحة المخطط العناصر المحيطة (العنوان، الوسيلة الإيضاحية، إلخ). في المخططات ثلاثية الأبعاد، تشمل مساحة الرسم أيضًا الجدران/الأرضية والمحاور.

**كيف يتم تفسير قيم X وY والعرض والارتفاع لمساحة الرسم عندما يكون التخطيط يدويًا؟**

هي كسور (0–1) من الحجم الكلي للمخطط؛ في هذا الوضع يتم تعطيل التحديد التلقائي للموقع وتُستخدم الكسور التي تحددها.

**لماذا تغير موضع مساحة الرسم بعد إضافة أو نقل الوسيلة الإيضاحية؟**

تقع الوسيلة الإيضاحية في مساحة المخطط خارج مساحة الرسم لكنها تؤثر على التخطيط والمساحة المتاحة، لذا قد يتحرك مساحة الرسم عندما يكون التحديد التلقائي للموقع مفعلًا. (هذا سلوك قياسي لمخططات PowerPoint.)