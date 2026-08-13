---
title: Aspose.Slides for .NET 15.11.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 15.11.0
type: docs
weight: 210
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- माइग्रेशन
- पुराना कोड
- आधुनिक कोड
- पुरानी विधि
- आधुनिक विधि
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग बदलावों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) या [हटाए गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) क्लास, मेथड, प्रॉपर्टी आदि, और Aspose.Slides for .NET 15.11.0 API के साथ प्रस्तुत किए गए अन्य परिवर्तन सूचीबद्ध करता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**

#### **DataLabelCollection क्लास में अप्रचलित प्रॉपर्टीज़ हटा दी गई हैं**
DataLabelCollection क्लास में अप्रचलित प्रॉपर्टीज़ हटा दी गई हैं:
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

#### **Presentation क्लास में नया प्रॉपर्टी FirstSlideNumber जोड़ा गया है**
Presentation में जोड़ा गया नया प्रॉपर्टी FirstSlideNumber प्रस्तुति में पहली स्लाइड की संख्या प्राप्त करने या सेट करने की सुविधा देता है।

जब नया FirstSlideNumber मान निर्दिष्ट किया जाता है तो सभी स्लाइड नंबरों की पुनर्गणना की जाती है।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string path = "sample.pptx";
string newPath = "output.pptx";

using (var pres = new Presentation(path))
{
    int firstSlideNumber = pres.FirstSlideNumber;

    pres.FirstSlideNumber = 10;

    pres.Save(newPath, SaveFormat.Pptx);
}
```