---
title: Aspose.Slides for .NET 14.10.0 में सार्वजनिक API और पीछे की ओर असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 14.10.0
type: docs
weight: 120
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- माइग्रेशन
- पुरानी कोड
- आधुनिक कोड
- पुराना दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रेज़ेंटेशन समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) या [removed](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) क्लासेज़, मेथड्स, प्रॉपर्टीज़ आदि, और Aspose.Slides for .NET 14.10.0 API के साथ पेश किए गए अन्य परिवर्तन सूचीबद्ध करता है।

{{% /alert %}} 
## **पब्लिक API परिवर्तन**
#### **Aspose.Slides.FieldType.Footer फ़ील्ड टाइप जोड़ा गया है**
#### **Enum एलिमेंट ShapeElementFillSource.Own हटा दिया गया है**
#### **चार्ट डेटा पॉइंट्स और श्रेणियों को हटाने के लिए मेथड्स जोड़े गए हैं**
निचे दिए गए मेथड्स, जो चार्ट डेटा पॉइंट कलेक्शन से चार्ट डेटा पॉइंट को हटाने की अनुमति देते हैं, जोड़े गए हैं:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

निचे दिया गया मेथड, जो कंटेनिंग कलेक्शन से चार्ट कैटेगरी को हटाने की अनुमति देता है, जोड़ा गया है:

IChartCategory.Remove()

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //ChartCategory.Remove() का उपयोग करके हटाएँ

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //ChartCategoryCollection.Remove() का उपयोग करके हटाएँ

    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//ChartDataPoint.Remove() का उपयोग करके हटाएँ

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
``` 
#### **Obsolete Aspose.Slides.ParagraphFormat प्रॉपर्टीज़ हटा दी गई हैं**
BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle प्रॉपर्टीज़ हटा दी गई हैं। इन्हें बहुत समय पहले ही अप्रचलित (obsolete) घोषित किया गया था।
#### **अप्रयुक्त और Obsolete कन्स्ट्रक्टर्स हटा दिए गए हैं**
निचे दिए गए कन्स्ट्रक्टर्स हटा दिए गए हैं:

- Aspose.Slides.Effects.AlphaBiLevel(System.Single)
- Aspose.Slides.Effects.AlphaModulateFixed(System.Single)
- Aspose.Slides.Effects.AlphaReplace(System.Single)
- Aspose.Slides.Effects.BiLevel(System.Single)
- Aspose.Slides.Effects.Blur(System.Double,System.Boolean)
- Aspose.Slides.Effects.HSL(System.Single,System.Single,System.Single)
- Aspose.Slides.Effects.ImageTransformOperation(Aspose.Slides.Effects.ImageTransformOperationCollection)
- Aspose.Slides.Effects.Luminance(System.Single,System.Single)
- Aspose.Slides.Effects.Tint(System.Single,System.Single)
- Aspose.Slides.PortionFormat(Aspose.Slides.ParagraphFormat)
- Aspose.Slides.PortionFormat(Aspose.Slides.Portion)
- Aspose.Slides.PortionFormat(Aspose.Slides.PortionFormat)