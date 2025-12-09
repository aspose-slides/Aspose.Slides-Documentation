---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للعودة في Aspose.Slides for .NET 15.8.0
linktitle: Aspose.Slides for .NET 15.8.0
type: docs
weight: 190
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- ترحيل
- شفرة قديمة
- شفرة حديثة
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

تُظهر هذه الصفحة جميع الفئات، الطرق، الخصائص وما إلى ذلك التي تم إضافتها أو إزالتها، وغيرها من التغييرات التي تم تقديمها مع واجهة برمجة تطبيقات Aspose.Slides for .NET 15.8.0.

{{% /alert %}} 
## **تغييرات API العامة**
#### **تمت إضافة الخاصية DoughnutHoleSize إلى IChartSeries و ChartSeries**
تحدد حجم الفتحة في مخطط الدونات.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```