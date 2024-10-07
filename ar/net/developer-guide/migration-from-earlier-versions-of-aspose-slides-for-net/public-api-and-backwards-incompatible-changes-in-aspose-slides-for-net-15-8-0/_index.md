---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 15.8.0
type: docs
weight: 190
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
---

{{% alert color="primary" %}} 

تقوم هذه الصفحة بسرد جميع [المضاف](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) أو [المزال](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) من الفئات، والأساليب، والخصائص، وما إلى ذلك، والتغييرات الأخرى التي تم إدخالها مع واجهة برمجة التطبيقات Aspose.Slides لـ .NET 15.8.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تم إضافة خاصية DoughnutHoleSize إلى IChartSeries و ChartSeries**
تحدد حجم الثقب في مخطط الدونات.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

``` 