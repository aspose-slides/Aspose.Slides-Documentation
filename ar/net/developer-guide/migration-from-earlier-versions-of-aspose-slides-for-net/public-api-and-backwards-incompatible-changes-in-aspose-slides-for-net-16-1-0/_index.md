---
title: API العامة والتغييرات غير المتوافقة إلى الخلف في Aspose.Slides لـ .NET 16.1.0
linktitle: Aspose.Slides لـ .NET 16.1.0
type: docs
weight: 220
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- الهجرة
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
description: "مراجعة تحديثات API العامة والتغييرات المتكسرة في Aspose.Slides لـ .NET لتسهيل نقل حلول عروض PowerPoint PPT و PPTX و ODP الخاصة بك."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع [مضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) أو [تمت إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) من الفئات، الطرق، الخصائص وما إلى ذلك، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 16.1.0 API.

{{% /alert %}} 
## **التغييرات العامة في API**


#### **تمت إضافة الخاصية RotationAngle إلى واجهات IChartTextBlockFormat و ITextFrameFormat**
تمت إضافة الخاصية RotationAngle إلى الواجهات Aspose.Slides.Charts.IChartTextBlockFormat و Aspose.Slides.ITextFrameFormat.
تحدد هذه الخاصية الدوران المخصص الذي يُطبق على النص داخل المربع المحدد.

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