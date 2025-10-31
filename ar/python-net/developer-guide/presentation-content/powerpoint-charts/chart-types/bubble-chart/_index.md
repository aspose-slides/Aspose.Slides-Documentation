---
title: تخصيص مخططات الفقاعات في العروض التقديمية باستخدام Python
linktitle: مخطط الفقاعات
type: docs
url: /ar/python-net/bubble-chart/
keywords:
- مخطط الفقاعات
- حجم الفقاعة
- تحجيم الحجم
- تمثيل الحجم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: أنشئ وقم بتخصيص مخططات الفقاعات القوية في PowerPoint و OpenDocument باستخدام Aspose.Slides للـ Python عبر .NET لتحسين تصور البيانات بسهولة.
---

## **تحجيم حجم مخطط الفقاعات**
Aspose.Slides للـ Python عبر .NET يوفر دعمًا لتحجيم حجم مخطط الفقاعات. في Aspose.Slides للـ Python عبر .NET تم إضافة خصائص **ChartSeries.bubble_size_scale** و **ChartSeriesGroup.bubble_size_scale**. يُعطى المثال التالي.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **تمثيل البيانات كأحجام مخطط الفقاعات**
تم إضافة الخاصية **bubble_size_representation** إلى الفئات ChartSeries و ChartSeriesGroup. تحدد **bubble_size_representation** كيف يتم تمثيل قيم حجم الفقاعات في المخطط. القيم الممكنة هي: **BubbleSizeRepresentationType.AREA** و **BubbleSizeRepresentationType.WIDTH**. بناءً على ذلك، تم إضافة تعداد **BubbleSizeRepresentationType** لتحديد الطرق الممكنة لتمثيل البيانات كأحجام مخطط الفقاعات. يُعطى الكود التالي.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يتم دعم "مخطط الفقاعات مع تأثير ثلاثي الأبعاد"، وكيف يختلف عن المخطط العادي؟**

نعم. هناك نوع مخطط منفصل، "الفقاعة مع ثلاثي الأبعاد". يطبق تنسيق ثلاثي الأبعاد على الفقاعات لكنه لا يضيف محورًا إضافيًا؛ البيانات تظل X-Y-S (الحجم). النوع متاح في تعداد [نوع المخطط](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

**هل هناك حد لعدد السلاسل والنقاط في مخطط الفقاعات؟**

ليس هناك حد ثابت على مستوى الـ API؛ يتم تحديد القيود بناءً على الأداء وإصدار PowerPoint المستهدف. يُنصح بالحفاظ على عدد النقاط معقولًا لضمان قابلية القراءة وسرعة العرض.

**كيف سيؤثر التصدير على مظهر مخطط الفقاعات (PDF، صور)؟**

التصدير إلى الصيغ المدعومة يحافظ على مظهر المخطط؛ يتم تنفيذ العرض بواسطة محرك Aspose.Slides. بالنسبة لصيغ الرسوم النقطية/الخطية، تُطبق قواعد عرض الرسوم العامة للمخططات (الدقة، مكافحة التعرجات)، لذا اختر DPI كافٍ للطباعة.