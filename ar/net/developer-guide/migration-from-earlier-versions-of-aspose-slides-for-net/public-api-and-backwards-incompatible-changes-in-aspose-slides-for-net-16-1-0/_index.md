---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للوراء في Aspose.Slides لـ .NET 16.1.0
linktitle: Aspose.Slides لـ .NET 16.1.0
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
- مستند مفتوح
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "راجع تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتقطعة في Aspose.Slides لـ .NET لتتمكن من ترحيل حلول عروض PowerPoint PPT و PPTX و ODP بسلاسة."
---

{{% alert color="primary" %}} 

تُظهر هذه الصفحة جميع الفئات [added](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) أو [removed](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) المُضافة أو المُزالة، والطرق، والخصائص وما إلى ذلك، وغيرها من التغييرات التي تم تقديمها مع واجهة برمجة تطبيقات Aspose.Slides لـ .NET 16.1.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**


#### **تمت إضافة الخاصية RotationAngle إلى واجهتي IChartTextBlockFormat و ITextFrameFormat**
تمت إضافة الخاصية RotationAngle إلى الواجهات Aspose.Slides.Charts.IChartTextBlockFormat و Aspose.Slides.ITextFrameFormat. تحدد هذه الخاصية الدوران المخصص الذي يتم تطبيقه على النص داخل الصندوق المحدد.

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