---
title: تخصيص مخططات الدونات في العروض التقديمية باستخدام Python عبر Java
linktitle: مخطط الدونات
type: docs
weight: 30
url: /ar/python-java/doughnut-chart/
keywords:
- مخطط الدونات
- الفجوة المركزية
- حجم الفتحة
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص مخططات الدونات في Aspose.Slides للـ Python عبر Java، مع دعم صيغ PowerPoint للعروض التقديمية الديناميكية."
---
## **نظرة عامة**

هذا المقال يوضح طريقة العمل مع مخطط الدونات في Aspose.Slides عن طريق إضافة المخطط إلى شريحة، ضبط حجم الفتحة المركزية، وحفظ العرض التقديمي. يركز على الطريقة [setDoughnutHoleSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) ويظهر الخطوات الأساسية المطلوبة لتخصيص هذا النوع من المخططات برمجيًا.

كما يتضمن أسئلة شائعة قصيرة تغطي سيناريوهات ذات صلة بمخطط الدونات، مثل استخدام سلاسل متعددة لإنشاء عدة حلقات، العمل مع مخططات الدونات المتفجرة، وتصدير المخطط كصورة نقطية أو SVG.

## **تحديد الفجوة المركزية في مخطط الدونات**

{{% alert color="info" title="Note" %}}

يدعم Aspose.Slides for Python via Java تحديد حجم الفتحة في مخطط الدونات. يوضح هذا القسم كيفية تحديد حجم الفتحة من خلال مثال.

{{% /alert %}}

لتحديد حجم الفتحة في مخطط الدونات، اتبع الخطوات التالية:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. إضافة مخطط دونات إلى الشريحة.
1. تحديد حجم الفتحة في مخطط الدونات.
1. كتابة العرض التقديمي إلى القرص.

المثال التالي يحدد حجم الفتحة في مخطط الدونات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# إنشاء مثيل لفئة Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # كتابة العرض التقديمي إلى القرص.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يمكنني إنشاء دونات متعددة المستويات مع عدة حلقات؟**

نعم. أضف عدة سلاسل إلى مخطط دونات واحد—كل سلسلة تصبح حلقة منفصلة. يتم تحديد ترتيب الحلقات بناءً على ترتيب السلاسل في المجموعة.

**هل يدعم الدونات "المتفجرة" (شرائح منفصلة)؟**

نعم. هناك نوع مخطط [Exploded Doughnut](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/) وخصية الانفجار على نقاط البيانات؛ يمكنك فصل الشرائح الفردية.

**كيف يمكنني الحصول على صورة لمخطط الدونات (PNG/SVG) لتقرير؟**

المخطط هو [shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/); يمكنك تحويله إلى [raster image](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage) أو تصديره كصورة SVG.