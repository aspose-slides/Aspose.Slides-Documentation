---
title: "واجهة برمجة تطبيقات عامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 16.1.0"
linktitle: "Aspose.Slides لـ .NET 16.1.0"
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
description: "راجع تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP الخاصة بك."
---
{{% alert color="info" %}}

هذه الصفحة تسرد جميع الفئات أو الأساليب أو الخصائص التي تم [added](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) أو [removed](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) وإلخ، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 16.1.0 API.

{{% /alert %}}
## **تغييرات API العامة**

#### **تمت إضافة خاصية RotationAngle إلى واجهتي IChartTextBlockFormat و ITextFrameFormat**
تمت إضافة خاصية RotationAngle إلى الواجهات Aspose.Slides.Charts.IChartTextBlockFormat و Aspose.Slides.ITextFrameFormat.  
تحدد هذه الخاصية الدوران المخصص الذي يتم تطبيقه على النص داخل الصندوق الحدودي.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


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
#### **تم نقل OdpException من Aspose.Slides.Odp إلى مساحة الأسماء Aspose.Slides**