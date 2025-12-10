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
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides for .NET للترحيل السلس لحلول عروض PowerPoint PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات والطرق والخصائص وما إلى ذلك التي تم [added](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) أو [removed](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/)، وغيرها من التغييرات التي تم إدخالها مع Aspose.Slides for .NET 15.8.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تمت إضافة خاصية DoughnutHoleSize إلى IChartSeries و ChartSeries**
تحدد حجم الفتحة في مخطط الدونات.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```