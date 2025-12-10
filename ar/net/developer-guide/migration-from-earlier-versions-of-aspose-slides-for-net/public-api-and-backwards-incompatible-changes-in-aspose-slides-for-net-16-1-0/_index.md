---
title: تغييرات API العامة والتغييرات غير المتوافقة للخلف في Aspose.Slides ل .NET 16.1.0
linktitle: Aspose.Slides ل .NET 16.1.0
type: docs
weight: 220
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
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
description: "استعراض تحديثات API العامة والتغييرات المتعارضة في Aspose.Slides ل .NET لتسهيل ترحيل حلول عروض PowerPoint PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات والطرق والخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)، والتغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 16.1.0 API.

{{% /alert %}} 
## **تغييرات API العامة**


#### **تم إضافة خاصية RotationAngle إلى واجهات IChartTextBlockFormat و ITextFrameFormat**
تم إضافة خاصية RotationAngle إلى الواجهات Aspose.Slides.Charts.IChartTextBlockFormat و Aspose.Slides.ITextFrameFormat. تحدد هذه الخاصية الدوران المخصص الذي يُطبق على النص داخل مربع الحدود.

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **تم نقل OdpException من Aspose.Slides.Odp إلى مساحة الاسم Aspose.Slides**