---
title: Aspose.Slides for .NET 16.1.0 में सार्वजनिक API और पिछड़ी असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 16.1.0
type: docs
weight: 220
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- स्थलांतर
- पुराना कोड
- आधुनिक कोड
- पुराना दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और टूटने वाले परिवर्तनों की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट करें।"
---
{{% alert color="info" %}} 
यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) या [removed](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) क्लासेस, मेथड्स, प्रॉपर्टीज़ आदि, और Aspose.Slides for .NET 16.1.0 API के साथ प्रस्तुत किए गए अन्य परिवर्तन सूचीबद्ध करता है।
{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**


#### **प्रॉपर्टी RotationAngle को IChartTextBlockFormat और ITextFrameFormat इंटरफ़ेस में जोड़ा गया है**
प्रॉपर्टी RotationAngle को इंटरफ़ेस Aspose.Slides.Charts.IChartTextBlockFormat और Aspose.Slides.ITextFrameFormat में जोड़ा गया है।
यह बॉक्स के भीतर लागू किए जा रहे टेक्स्ट की कस्टम रोटेशन को निर्दिष्ट करता है।

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
#### **OdpException को Aspose.Slides.Odp से Aspose.Slides नेमस्पेस में स्थानांतरित किया गया**