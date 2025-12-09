---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET 15.8.0
linktitle: Aspose.Slides لـ .NET 15.8.0
type: docs
weight: 190
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- الترحيل
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
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides لـ .NET لإجراء ترحيل سلس لحلول عرض PowerPoint PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 
تُظهر هذه الصفحة جميع [المضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) أو [المزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) الفئات، والطرق، والخصائص وما إلى ذلك، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 15.8.0 API.
{{% /alert %}} 
## **التغييرات العامة لواجهة برمجة التطبيقات**
#### **تمت إضافة الخاصية DoughnutHoleSize إلى IChartSeries و ChartSeries**
تحدد حجم الفتحة في مخطط الدونت.

``` csharp
 using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;
   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);
}
```