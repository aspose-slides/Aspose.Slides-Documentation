---
title: Aspose.Slides for .NET 15.11.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 15.11.0
type: docs
weight: 210
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- स्थलांतरण
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
description: "Aspose.Slides for .NET में सार्वजनिक API अद्यतन और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) या [removed](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) क्लास, मेथड, प्रॉपर्टी आदि, और Aspose.Slides for .NET 15.11.0 API द्वारा प्रस्तुत अन्य परिवर्तन सूचीबद्ध करता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**

#### **DataLabelCollection क्लास में अप्रचलित प्रॉपर्टी हटाई गई हैं**
DataLabelCollection क्लास में अप्रचलित प्रॉपर्टी को हटा दिया गया है:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **Presentation क्लास में नया प्रॉपर्टी FirstSlideNumber जोड़ दिया गया है**
Presentation में जोड़ा गया नया प्रॉपर्टी FirstSlideNumber प्रस्तुति में पहली स्लाइड की संख्या प्राप्त करने या सेट करने की अनुमति देता है।

जब नया FirstSlideNumber मान निर्दिष्ट किया जाता है तो सभी स्लाइड नंबरों की पुनर्गणना की जाती है।

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```