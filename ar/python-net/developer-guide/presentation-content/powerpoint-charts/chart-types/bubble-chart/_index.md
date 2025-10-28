---
title: تخصيص الرسوم البيانية الفقاعية في العروض التقديمية باستخدام بايثون
linktitle: مخطط الفقاعات
type: docs
url: /ar/python-net/bubble-chart/
keywords:
- مخطط فقاعي
- حجم الفقاعة
- تحجيم الحجم
- تمثيل الحجم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتخصيص مخططات فقاعية قوية في PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET لتحسين تصور البيانات بسهولة."
---

## **تحجيم حجم المخطط الفقاعي**
توفر Aspose.Slides للبايثون عبر .NET دعمًا لتحجيم حجم المخطط الفقاعي. تم إضافة الخصائص **ChartSeries.bubble_size_scale** و **ChartSeriesGroup.bubble_size_scale** في Aspose.Slides للبايثون عبر .NET. يُعطى المثال النموذجي أدناه.  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **تمثيل البيانات كأحجام مخطط فقاعي**
تمت إضافة الخاصية **bubble_size_representation** إلى الفئات ChartSeries و ChartSeriesGroup. تُحدد **bubble_size_representation** كيفية تمثيل قيم حجم الفقاعة في المخطط الفقاعي. القيم الممكنة هي: **BubbleSizeRepresentationType.AREA** و **BubbleSizeRepresentationType.WIDTH**. بناءً على ذلك، تمت إضافة تعداد **BubbleSizeRepresentationType** لتحديد الطرق الممكنة لتمثيل البيانات كأحجام مخطط فقاعي. يُعطى شفرة العينة أدناه.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يتم دعم "مخطط فقاعي مع تأثير ثلاثي الأبعاد"، وكيف يختلف عن المخطط العادي؟**

نعم. هناك نوع مخطط منفصل يُسمى "Bubble with 3-D". يطبّق نمطًا ثلاثي الأبعاد على الفقاعات لكنه لا يضيف محورًا إضافيًا؛ تبقى البيانات X-Y-S (الحجم). يتوفر هذا النوع في تعداد [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

**هل هناك حد لعدد السلاسل والنقاط في المخطط الفقاعي؟**

لا يوجد حد صارم على مستوى API؛ يتم تحديد القيود وفقًا للأداء وإصدار PowerPoint المستهدف. يُنصح بالحفاظ على عدد النقاط معقولًا لضمان القابلية للقراءة وسرعة العرض.

**كيف سيؤثر التصدير على مظهر المخطط الفقاعي (PDF، صور)؟**

يحافظ التصدير إلى الصيغ المدعومة على مظهر المخطط؛ يتم التعامل مع الرسم بواسطة محرك Aspose.Slides. بالنسبة للصيغ النقطية/المتجهة، تُطبق قواعد عرض الرسوم البيانية العامة (الدقة، مضاد التعرجات)، لذا اختر DPI كافي للطباعة.