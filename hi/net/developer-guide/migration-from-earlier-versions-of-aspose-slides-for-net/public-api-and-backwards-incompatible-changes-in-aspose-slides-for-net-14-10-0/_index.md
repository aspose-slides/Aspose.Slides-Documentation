---
title: Aspose.Slides for .NET 14.10.0 में सार्वजनिक API और पिछड़े असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 14.10.0
type: docs
weight: 120
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
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
description: "Aspose.Slides for .NET में सार्वजनिक API अद्यतन और तुटते परिवर्तनों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}}

यह पृष्ठ सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) या [हटाए गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) क्लास, मेथड, प्रॉपर्टी आदि, तथा Aspose.Slides for .NET 14.10.0 API के साथ प्रस्तुत किए गए अन्य परिवर्तनों की सूची देता है।

{{% /alert %}}
## **Public API परिवर्तन**
#### **Aspose.Slides.FieldType.Footer फ़ील्ड प्रकार जोड़ा गया**
फ़ुटर फ़ील्ड प्रकार को इस प्रकार जोड़ दिया गया है कि इस प्रकार के फ़ील्ड बनाने की संभावना लागू की जा सके और वैध प्रेजेंटेशन सीरियलाइज़ेशन हो सके।
#### **Enum तत्व ShapeElementFillSource.Own हटा दिया गया**
Enum तत्व ShapeElementFillSource.Own को डुप्लीकेट होने के कारण हटा दिया गया है। ShapeElementFillSource.Own के बजाय ShapeElementFillSource.Shape का उपयोग करें।
#### **चार्ट डेटा पॉइंट और कैटेगरी हटाने के लिए मेथड जोड़े गए**
चार्ट डेटा पॉइंट संग्रह से डेटा पॉइंट हटाने की अनुमति देने वाले निम्नलिखित मेथड जोड़े गए हैं:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

कंटेनिंग संग्रह से चार्ट कैटेगरी हटाने की अनुमति देने वाला निम्नलिखित मेथड जोड़ा गया है:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);
    chart.ChartData.Categories[0].Remove(); //ChartCategory.Remove() के साथ हटाएँ
    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //ChartCategoryCollection.Remove() के साथ हटाएँ
    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//ChartDataPoint.Remove() के साथ हटाएँ
        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }
    pres.Save(outPath, SaveFormat.Pptx);
}
```
#### **Obsolete Aspose.Slides.ParagraphFormat प्रॉपर्टीज़ हटा दी गईं**
BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle प्रॉपर्टीज़ हटा दी गई हैं। इन्हें बहुत पहले अप्रचलित के रूप में चिह्नित किया गया था।
#### **अनुपयोगी और अप्रचलित कंस्ट्रक्टर्स हटा दिए गए**
निम्नलिखित कंस्ट्रक्टर्स हटा दिए गए हैं:

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