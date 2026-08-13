---
title: Aspose.Slides for .NET 15.8.0 में सार्वजनिक API और पिछड़ने योग्य असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 15.8.0
type: docs
weight: 190
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- स्थानांतरण
- लेगेसी कोड
- आधुनिक कोड
- परम्परागत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग बदलावों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}}

यह पृष्ठ Aspose.Slides for .NET 15.8.0 API में प्रस्तुत सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) या [हटाए गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) क्लास, मेथड, प्रॉपर्टी आदि और अन्य परिवर्तनों की सूची देता है।

{{% /alert %}}
## **सार्वजनिक API परिवर्तन**
#### **Property DoughnutHoleSize को IChartSeries और ChartSeries में जोड़ा गया है**
डोनट चार्ट में छेद के आकार को निर्दिष्ट करता है।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}
```