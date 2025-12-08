---
title: تخصيص مخططات الفقاعات في العروض التقديمية باستخدام بايثون
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
description: "إنشاء وتخصيص مخططات فقاعات قوية في PowerPoint وOpenDocument باستخدام Aspose.Slides for Python via .NET لتعزيز تصور البيانات بسهولة."
---

## **تحجيم حجم مخطط الفقاعات**
توفر Aspose.Slides for Python via .NET دعمًا لتحجيم حجم مخطط الفقاعات. في Aspose.Slides for Python via .NET تم إضافة خصائص **ChartSeries.bubble_size_scale** و **ChartSeriesGroup.bubble_size_scale**. أدناه مثال توضيحي.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```





## **تمثيل البيانات كأحجام مخطط الفقاعات**
تمت إضافة الخاصية **bubble_size_representation** إلى فئات ChartSeries و ChartSeriesGroup. تحدد **bubble_size_representation** كيفية تمثيل قيم حجم الفقاعات في مخطط الفقاعات. القيم المحتملة هي: **BubbleSizeRepresentationType.AREA** و **BubbleSizeRepresentationType.WIDTH**. بناءً على ذلك، تمت إضافة تعداد **BubbleSizeRepresentationType** لتحديد الطرق المحتملة لتمثيل البيانات كأحجام مخطط الفقاعات. تم توفير عينة من الشيفرة أدناه.
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

نعم. هناك نوع مخطط منفصل يسمى "Bubble with 3-D". يطبق تنسيقًا ثلاثي الأبعاد على الفقاعات لكنه لا يضيف محورًا إضافيًا؛ تبقى البيانات X-Y-S (الحجم). النوع متاح في تعداد [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

**هل هناك حد لعدد السلاسل والنقاط في مخطط الفقاعات؟**

ليس هناك حد صارم على مستوى واجهة برمجة التطبيقات؛ يتم تحديد القيود بناءً على الأداء وإصدار PowerPoint المستهدف. يُنصح بالحفاظ على عدد النقاط معقولًا لتسهيل القراءة وسرعة العرض.

**كيف سيؤثر التصدير على مظهر مخطط الفقاعات (PDF، صور)؟**

يحافظ التصدير إلى الصيغ المدعومة على مظهر المخطط؛ يتم عملية العرض بواسطة محرك Aspose.Slides. بالنسبة إلى الصيغ النقطية/الخطية، تُطبق قواعد العرض العامة للرسومات (الدقة، مضاد التعرجات)، لذا اختر DPI كافي للطباعة.