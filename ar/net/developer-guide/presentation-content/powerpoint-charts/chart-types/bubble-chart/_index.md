---
title: تخصيص مخططات الفقاعات في العروض التقديمية في .NET
linktitle: مخطط الفقاعات
type: docs
url: /ar/net/bubble-chart/
keywords:
- مخطط الفقاعات
- حجم الفقاعة
- تحجيم الحجم
- تمثيل الحجم
- باوربوينت
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "أنشئ وقم بتخصيص مخططات فقاعات قوية في باوربوينت باستخدام Aspose.Slides لـ .NET لتعزيز تصور البيانات بسهولة."
---

## **تحجيم حجم مخطط الفقاعات**
يقدم Aspose.Slides for .NET دعمًا لتحجيم حجم مخطط الفقاعات. في Aspose.Slides for .NET تم إضافة الخصائص **IChartSeries.BubbleSizeScale** و **IChartSeriesGroup.BubbleSizeScale**. مثال العينة أدناه.
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **تمثيل البيانات كأحجام مخطط الفقاعات**
تمت إضافة الخاصية **BubbleSizeRepresentation** إلى الواجهات IChartSeries و IChartSeriesGroup، وإلى الفئات ذات الصلة. تحدد **BubbleSizeRepresentation** طريقة تمثيل قيم حجم الفقاع في مخطط الفقاعات. القيم الممكنة هي: **BubbleSizeRepresentationType.Area** و **BubbleSizeRepresentationType.Width**. بناءً على ذلك، تمت إضافة تعداد **BubbleSizeRepresentationType** لتحديد الطرق الممكنة لتمثيل البيانات كأحجام مخطط الفقاعات. مثال الشيفرة أدناه.
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**هل يتم دعم "مخطط الفقاعات مع تأثير ثلاثي الأبعاد"، وكيف يختلف عن المخطط العادي؟**

نعم. هناك نوع مخطط منفصل، "Bubble with 3-D". يطبق نمطًا ثلاثي الأبعاد على الفقاعات ولكنه لا يضيف محورًا إضافيًا؛ تبقى البيانات X-Y-S (الحجم). النوع متاح في تعداد [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

**هل هناك حد لعدد السلاسل والنقاط في مخطط الفقاعات؟**

ليس هناك حد ثابت على مستوى API؛ يتم تحديد القيود وفقًا للأداء وإصدار PowerPoint المستهدف. يُنصح بالحفاظ على عدد النقاط معقولًا لتحسين قابلية القراءة وسرعة العرض.

**كيف سيؤثر التصدير على مظهر مخطط الفقاعات (PDF، الصور)؟**

يحافظ التصدير إلى الصيغ المدعومة على مظهر المخطط؛ يتم إجراء العرض بواسطة محرك Aspose.Slides. بالنسبة للصيغ النقطية/المتجهة، تُطبق قواعد العرض العامة لرسومات المخططات (الدقة، مكافحة التسنين)، لذا يُنصح باختيار DPI كافية للطباعة.