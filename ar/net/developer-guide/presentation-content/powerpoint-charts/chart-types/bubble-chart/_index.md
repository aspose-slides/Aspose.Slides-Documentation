---
title: مخطط الفقاعات
type: docs
url: /ar/net/bubble-chart/
keywords: "مخطط الفقاعات، حجم المخطط، عرض تقديمي PowerPoint، C#، Csharp، Aspose.Slides for .NET"
description: "حجم مخطط الفقاعات في عروض PowerPoint بلغة C# أو .NET"
---

## **تحجيم حجم مخطط الفقاعات**
توفر Aspose.Slides للـ .NET دعمًا لتحجيم حجم مخطط الفقاعات. تمّت إضافة خصائص **IChartSeries.BubbleSizeScale** و **IChartSeriesGroup.BubbleSizeScale** في Aspose.Slides للـ .NET. في ما يلي مثال نموذجي.  
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **تمثيل البيانات بأحجام مخطط الفقاعات**
تمّت إضافة الخاصية **BubbleSizeRepresentation** إلى واجهات IChartSeries و IChartSeriesGroup والفئات ذات الصلة. **BubbleSizeRepresentation** تحدد كيفية تمثيل قيم حجم الفقاعات في مخطط الفقاعات. القيم الممكنة هي: **BubbleSizeRepresentationType.Area** و **BubbleSizeRepresentationType.Width**. وبناءً على ذلك، تمّت إضافة تعداد **BubbleSizeRepresentationType** لتحديد الطرق الممكنة لتمثيل البيانات بأحجام مخطط الفقاعات. في ما يلي عينة من الشيفرة.  
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
نعم. هناك نوع مخطط منفصل، "Bubble with 3-D". يطبق نمطًا ثلاثي الأبعاد على الفقاعات دون إضافة محور إضافي؛ تظل البيانات X-Y-S (الحجم). النوع متاح في تعداد [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

**هل هناك حد لعدد السلاسل والنقاط في مخطط الفقاعات؟**  
ليس هناك حد ثابت على مستوى API؛ تتحدد القيود بالأداء وإصدار PowerPoint المستهدف. يُنصح بالحفاظ على عدد النقاط في حدود معقولة لضمان قابلية القراءة وسرعة العرض.

**كيف سيؤثر التصدير على مظهر مخطط الفقاعات (PDF، صور)؟**  
يحافظ التصدير إلى الصيغ المدعومة على مظهر المخطط؛ يتم تنفيذ التصيير بواسطة محرك Aspose.Slides. بالنسبة إلى صيغ الرستر/الفيكتور، تُطبق قواعد التصيير العامة (الدقة، مضاد التسنين)، لذا يُنصح باختيار DPI كافٍ للطباعة.