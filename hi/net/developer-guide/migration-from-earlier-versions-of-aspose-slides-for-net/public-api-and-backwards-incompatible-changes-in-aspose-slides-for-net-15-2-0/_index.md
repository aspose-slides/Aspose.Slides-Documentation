---
title: Aspose.Slides for .NET 15.2.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 15.2.0
type: docs
weight: 140
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- स्थलांतरण
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
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट्स और ब्रेकिंग परिवर्तन की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सहजता से माइग्रेट करें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) या [removed](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) क्लासेज़, मेथड्स, प्रॉपर्टीज़ आदि को सूचीबद्ध करता है, और Aspose.Slides for .NET 15.2.0 API के साथ पेश किए गए अन्य बदलावों को दर्शाता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **AddDataPointForDoughnutSeries मेथड्स जोड़े गए हैं**
IChartDataPointCollection.AddDataPointForDoughnutSeries() मेथड के दो ओवरलोड जोड़े गए हैं ताकि Doughnut चार्ट प्रकार की सीरीज़ में डेटा पॉइंट्स जोड़े जा सकें।

#### **Aspose.Slides.SmartArt.SmartArtShape क्लास को Aspose.Slides.GeometryShape क्लास से विरासत में मिला है**
Aspose.Slides.SmartArt.SmartArtShape क्लास को Aspose.Slides.GeometryShape क्लास से विरासत में मिला है। यह परिवर्तन Aspose.Slides ऑब्जेक्ट मॉडल में सुधार करता है और SmartArtShape क्लास में नई सुविधाएँ जोड़ता है।

#### **इंडेक्स द्वारा चार्ट डेटा पॉइंट और चार्ट कैटेगरी हटाने के मेथड्स जोड़े गए हैं**
IChartDataPointCollection.RemoveAt(int index) मेथड जोड़ा गया है ताकि उसके इंडेक्स द्वारा चार्ट डेटा पॉइंट हटाया जा सके।  
IChartCategoryCollection.RemoveAt(int index) मेथड जोड़ा गया है ताकि उसके इंडेक्स द्वारा चार्ट कैटेगरी हटाई जा सके।

#### **PptXPptY मान Aspose.Slides.Animation.PropertyType एन्न्यूमरेशन में जोड़ा गया है**
PptXPptY मान को सीरियलाइज़ेशन समस्या समाधान के हिस्से के रूप में Aspose.Slides.Animation.PropertyType एन्न्यूमरेशन में जोड़ा गया है।

#### **System.Drawing.Color GetAutomaticSeriesColor() मेथड Aspose.Slides.Charts.IChartSeries में जोड़ा गया है**
GetAutomaticSeriesColor मेथड सीरीज़ इंडेक्स और चार्ट शैली के आधार पर सीरीज़ का स्वचालित रंग लौटाता है। यदि FillType NotDefined के बराबर हो तो यह रंग डिफ़ॉल्ट रूप से उपयोग किया जाता है।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```