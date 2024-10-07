---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 16.1.0
type: docs
weight: 220
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع [الإضافات](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) أو [الإزالات](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) من الفئات والطرق والخصائص وما إلى ذلك، والتغييرات الأخرى التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ .NET 16.1.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**


#### **تمت إضافة خاصية RotationAngle إلى واجهات IChartTextBlockFormat وITextFrameFormat**
تمت إضافة خاصية RotationAngle إلى واجهات Aspose.Slides.Charts.IChartTextBlockFormat وAspose.Slides.ITextFrameFormat.
تحدد الدوران المخصص الذي يتم تطبيقه على النص داخل الصندوق المحيط.

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("عنوان مخصص").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **تم نقل OdpException من Aspose.Slides.Odp إلى مساحة أسماء Aspose.Slides**