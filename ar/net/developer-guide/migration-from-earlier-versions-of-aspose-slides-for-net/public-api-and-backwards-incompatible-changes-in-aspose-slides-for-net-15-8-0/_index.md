---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للوراء في Aspose.Slides لـ .NET 15.8.0"
linktitle: "Aspose.Slides لـ .NET 15.8.0"
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
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides لـ .NET لتحديث حلول العروض التقديمية PowerPoint PPT و PPTX و ODP بسلاسة."
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [مضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) أو [مخصومة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) الفئات والطرق والخصائص وما إلى ذلك، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 15.8.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تمت إضافة خاصية DoughnutHoleSize إلى IChartSeries و ChartSeries**
يحدد حجم الفتحة في مخطط الدونات.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```