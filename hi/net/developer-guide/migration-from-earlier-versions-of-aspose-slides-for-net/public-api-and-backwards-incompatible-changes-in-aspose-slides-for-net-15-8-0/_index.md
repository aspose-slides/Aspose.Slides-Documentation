---
title: Aspose.Slides for .NET 15.8.0 में सार्वजनिक API और पीछे की असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 15.8.0
type: docs
weight: 190
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- स्थानांतरण
- पुरानी कोड
- आधुनिक कोड
- पुरानी पद्धति
- आधुनिक पद्धति
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) या [removed](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) क्लास, मेथड, प्रॉपर्टी और अन्य परिवर्तन की सूची देता है, जो Aspose.Slides for .NET 15.8.0 API के साथ पेश किए गए हैं।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **Property DoughnutHoleSize को IChartSeries और ChartSeries में जोड़ा गया है**
डोनट चार्ट में छेद के आकार को निर्दिष्ट करता है।

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```