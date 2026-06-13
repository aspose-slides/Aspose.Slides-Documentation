---
title: सार्वजनिक API और Aspose.Slides for .NET 15.7.0 में प्रतिगामी असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 15.7.0
type: docs
weight: 180
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- स्थलांतरण
- पुरानी कोड
- आधुनिक कोड
- पुराना दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और तोड़े जाने वाले बदलावों की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट करें."
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) या [हटाए गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) क्लास, मेथड, प्रॉपर्टी आदि, और Aspose.Slides for .NET 15.7.0 API के साथ परिचय कराए गए अन्य परिवर्तन सूचीबद्ध करता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **Enum ImagePixelFormat जोड़ा गया है**
Enum Aspose.Slides.Export.ImagePixelFormat जोड़ा गया है ताकि उत्पन्न छवियों के लिए पिक्सेल फ़ॉर्मेट निर्दिष्ट किया जा सके।
#### **IChartDataPoint.GetAutomaticDataPointColor() मेथड जोड़ा गया है**
डेटा पॉइंट का स्वचालित रंग लौटाता है जो श्रृंखला सूचकांक, डेटा पॉइंट सूचकांक, ParentSeriesGroup, IsColorVaried प्रॉपर्टी और चार्ट शैली पर आधारित होता है।  
यदि FillType NotDefined के बराबर है तो यह रंग डिफ़ॉल्ट रूप से उपयोग किया जाता है।
#### **Method RenderToGraphics स्लाइड में जोड़ा गया है**
Method RenderToGraphics (और इसके ओवरलोड) Aspose.Slides.Slide में जोड़ा गया है ताकि स्लाइड को Graphics ऑब्जेक्ट में रेंडर किया जा सके।
#### **Property PixelFormat ITiffOptions और TiffOptions में जोड़ा गया है**
Property PixelFormat Aspose.Slides.Export.ITiffOptions और Aspose.Slides.Export.TiffOptions में जोड़ा गया है ताकि उत्पन्न TIFF छवियों के लिए पिक्सेल फ़ॉर्मेट निर्दिष्ट किया जा सके।