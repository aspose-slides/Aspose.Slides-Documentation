---
title: تخصيص مخططات الفقاعات في العروض التقديمية باستخدام Python
linktitle: مخطط فقعات
type: docs
url: /ar/python-java/bubble-chart/
keywords:
- مخطط فقعات
- حجم الفقعة
- تحجيم الحجم
- تمثيل الحجم
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء وتخصيص مخططات فقعات قوية في PowerPoint باستخدام Aspose.Slides للـ Python عبر Java لتعزيز تصورك للبيانات بسهولة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع مخططات الفقاعات في Aspose.Slides. تغطي خيارين محددين للتخصيص: تحجيم أحجام الفقاعات من خلال طريقة [setBubbleSizeScale](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) والتحكم في كيفية تمثيل قيم حجم الفقاعات من خلال طريقة [setBubbleSizeRepresentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation).

تظهر الأمثلة كيفية إنشاء مخطط فقاعات، وضبط تحجيم حجمه، وتبديل تمثيل حجم الفقاعة لاستخدام العرض. تتضمن المقالة أيضاً قسم أسئلة متكررة قصير يوضح دعم نوع المخطط “Bubble with 3-D”، ويشير إلى أن حدود المخطط العملية تعتمد على الأداء وإصدار PowerPoint المستهدف، ويشرح أن عملية التصدير تحافظ على مظهر المخطط عبر محرك العرض Aspose.Slides.

## **تحجيم حجم مخطط الفقاعات**
تدعم Aspose.Slides للغة Python عبر Java تحجيم حجم مخطط الفقاعات من خلال طرق [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/#getBubbleSizeScale)، [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale)، و[ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale). يوضح المثال التالي كيفية تحجيم أحجام الفقاعات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تمثيل البيانات كأحجام مخطط الفقاعات**
الطرق [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) و[**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) متوفرة في فئة [ChartSeriesGroup](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseriesgroup/). تحدد تمثيلات حجم الفقاعات كيفية تمثيل قيم حجم الفقاعات في مخطط الفقاعات. القيم الممكنة هي [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bubblesizerepresentationtype/#Area) و[**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bubblesizerepresentationtype/#Width). تعداد [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/ar/python-java/aspose.slides/bubblesizerepresentationtype/) يحدد الطرق الممكنة لتمثيل البيانات كأحجام مخطط الفقاعات. يوضح المثال التالي كيفية تمثيل أحجام الفقاعات باستخدام العرض.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يتم دعم "مخطط الفقاعات مع تأثير ثلاثي الأبعاد"، وكيف يختلف عن المخطط العادي؟**

نعم. هناك نوع مخطط منفصل يُدعى "Bubble with 3-D". يضيف تأثير ثلاثي الأبعاد إلى الفقاعات دون إضافة محور إضافي؛ تبقى البيانات X‑Y‑S (الحجم). النوع متوفر في فئة [نوع المخطط](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/).

**هل هناك حد لعدد السلاسل والنقاط في مخطط الفقاعات؟**

ليس هناك حد صريح على مستوى API؛ يتم تحديد القيود وفقاً للأداء وإصدار PowerPoint المستهدف. يُنصح بالحفاظ على عدد النقاط معقولاً لضمان قابلية القراءة وسرعة العرض.

**كيف سيؤثر التصدير على مظهر مخطط الفقاعات (PDF، صور)؟**

التصدير إلى الصيغ المدعومة يحافظ على مظهر المخطط؛ يتم التنفيذ بواسطة محرك Aspose.Slides. بالنسبة للصور النقطية أو المتجهة، تُطبق قواعد العرض العامة للمخططات (الدقة، مكافحة التعرجات)، لذا يُنصح باختيار DPI كافٍ للطباعة.