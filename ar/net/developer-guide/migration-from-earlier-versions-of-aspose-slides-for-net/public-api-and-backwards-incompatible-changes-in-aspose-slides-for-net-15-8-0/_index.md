---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for .NET 15.8.0
linktitle: Aspose.Slides for .NET 15.8.0
type: docs
weight: 190
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides for .NET للترحيل السلس لحلول العروض التقديمية PowerPoint PPT و PPTX و ODP الخاصة بك."
---
{{% alert color="info" %}} 

هذه الصفحة تسرد جميع [مضاف](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) أو [مزال](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) من الفئات، والطرق، والخصائص، وما إلى ذلك، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع واجهة برمجة تطبيقات Aspose.Slides for .NET 15.8.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تمت إضافة الخاصية DoughnutHoleSize إلى IChartSeries و ChartSeries**
تحدد حجم الفتحة في مخطط الدونات.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```