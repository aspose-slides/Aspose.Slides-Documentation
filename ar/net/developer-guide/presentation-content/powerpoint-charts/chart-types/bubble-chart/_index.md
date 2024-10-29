---
title: مخطط الفقاعات
type: docs
url: /ar/net/bubble-chart/
keywords: "مخطط الفقاعات، حجم المخطط، عرض باوربوينت، C#، Csharp، Aspose.Slides for .NET"
description: "حجم مخطط الفقاعات في عروض باوربوينت في C# أو .NET"
---

## **تعديل حجم مخطط الفقاعات**
توفر Aspose.Slides for .NET دعمًا لتعديل حجم مخطط الفقاعات. تمت إضافة خصائص **IChartSeries.BubbleSizeScale** و **IChartSeriesGroup.BubbleSizeScale** في Aspose.Slides for .NET. يُعطى أدناه مثال نموذجي.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **تمثيل البيانات كأحجام لمخطط الفقاعات**
تمت إضافة خاصية **BubbleSizeRepresentation** إلى واجهات IChartSeries و IChartSeriesGroup والفئات ذات الصلة. تُحدد **BubbleSizeRepresentation** كيف يتم تمثيل قيم حجم الفقاعات في مخطط الفقاعات. القيم الممكنة هي: **BubbleSizeRepresentationType.Area** و **BubbleSizeRepresentationType.Width**. وبناءً عليه، تمت إضافة تعداد **BubbleSizeRepresentationType** لتحديد الطرق الممكنة لتمثيل البيانات كأحجام لمخطط الفقاعات. يُعطى أدناه كود نموذجي.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```