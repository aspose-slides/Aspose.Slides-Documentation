---
title: Aspose.Slides for .NET 15.2.0 में सार्वजनिक API और पीछे की असंगत बदलाव
linktitle: Aspose.Slides .NET 15.2.0 के लिए
type: docs
weight: 140
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- स्थानांतरण
- विरासत कोड
- आधुनिक कोड
- विरासत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग बदलावों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुतियों की समाधान को सहजता से माइग्रेट कर सकें।
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [जोड़ें](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) या [हटाएँ](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) क्लासेस, मेथड्स, प्रॉपर्टीज़ आदि की सूची देता है, और Aspose.Slides for .NET 15.2.0 API के साथ प्रस्तुत किए गए अन्य बदलावों को दिखाता है। 

{{% /alert %}} 
## **सार्वजनिक API बदलाव**
#### **AddDataPointForDoughnutSeries मेथड्स जोड़े गए हैं**
IChartDataPointCollection.AddDataPointForDoughnutSeries() मेथड के दो ओवरलोड्स जोड़े गए हैं जो Doughnut चार्ट प्रकार की सीरीज़ में डेटा पॉइंट्स जोड़ने के लिए उपयोग किए जाते हैं।
#### **Aspose.Slides.SmartArt.SmartArtShape क्लास को Aspose.Slides.GeometryShape क्लास से इनहेरिट किया गया है**
Aspose.Slides.SmartArt.SmartArtShape क्लास को Aspose.Slides.GeometryShape क्लास से इनहेरिट किया गया है। इस बदलाव से Aspose.Slides ऑब्जेक्ट मॉडल में सुधार हुआ है और SmartArtShape क्लास में नई सुविधाएँ जोड़ी गई हैं।
#### **इंडेक्स द्वारा चार्ट डेटा पॉइंट और चार्ट कैटेगरी को हटाने के मेथड्स जोड़े गए हैं**
IChartDataPointCollection.RemoveAt(int index) मेथड को चार्ट डेटा पॉइंट को इसके इंडेक्स से हटाने के लिए जोड़ा गया है।  
IChartCategoryCollection.RemoveAt(int index) मेथड को चार्ट कैटेगरी को इसके इंडेक्स से हटाने के लिए जोड़ा गया है।
#### **PptXPptY मान को Aspose.Slides.Animation.PropertyType एनेमरेशन में जोड़ा गया है**
PptXPptY मान को Aspose.Slides.Animation.PropertyType एनेमरेशन में सीरियलाइज़ेशन समस्या को ठीक करने के संदर्भ में जोड़ा गया है।
#### **System.Drawing.Color GetAutomaticSeriesColor() मेथड को Aspose.Slides.Charts.IChartSeries में जोड़ा गया है**
GetAutomaticSeriesColor मेथड सीरीज़ के इंडेक्स और चार्ट स्टाइल के आधार पर स्वचालित रंग लौटाता है। यदि FillType NotDefined के बराबर हो तो यह रंग डिफ़ॉल्ट रूप से उपयोग किया जाता है।

``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}

```