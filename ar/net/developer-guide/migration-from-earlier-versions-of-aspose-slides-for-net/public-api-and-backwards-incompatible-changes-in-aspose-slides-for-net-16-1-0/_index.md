---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET 16.1.0
linktitle: Aspose.Slides لـ .NET 16.1.0
type: docs
weight: 220
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- ترقية
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
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عروض PowerPoint PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات، الطرق، الخصائص وما إلى ذلك التي تم [مضاف](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) أو [مُزال](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)ها، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 16.1.0 API.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**


#### **تم إضافة الخاصية RotationAngle إلى واجهتي IChartTextBlockFormat و ITextFrameFormat**
تمت إضافة الخاصية RotationAngle إلى الواجهات Aspose.Slides.Charts.IChartTextBlockFormat و Aspose.Slides.ITextFrameFormat.
تحدد الدوران المخصص المطبق على النص داخل صندوق الحدود.

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