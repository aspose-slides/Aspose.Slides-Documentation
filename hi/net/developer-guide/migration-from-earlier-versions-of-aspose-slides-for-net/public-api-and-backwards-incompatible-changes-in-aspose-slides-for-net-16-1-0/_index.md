---
title: Aspose.Slides for .NET 16.1.0 में सार्वजनिक API और पिछड़े असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 16.1.0
type: docs
weight: 220
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- स्थांतरण
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

यह पृष्ठ Aspose.Slides for .NET 16.1.0 API के साथ पेश किए गए सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) या [हटाए गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) क्लास, मेथड, प्रॉपर्टी आदि, और अन्य बदलावों की सूची देता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**


#### **Property RotationAngle को IChartTextBlockFormat और ITextFrameFormat इंटरफ़ेस में जोड़ा गया है**
Property RotationAngle को इंटरफ़ेस Aspose.Slides.Charts.IChartTextBlockFormat और Aspose.Slides.ITextFrameFormat में जोड़ा गया है। यह बॉन्डिंग बॉक्स के भीतर टेक्स्ट पर लागू किए जा रहे कस्टम रोटेशन को निर्दिष्ट करता है।

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
#### **OdpException को Aspose.Slides.Odp से Aspose.Slides नेमस्पेस में स्थानांतरित किया गया**