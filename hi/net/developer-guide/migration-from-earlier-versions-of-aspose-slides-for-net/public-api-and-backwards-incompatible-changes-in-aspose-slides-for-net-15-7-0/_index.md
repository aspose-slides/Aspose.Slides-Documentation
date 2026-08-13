---
title: Aspose.Slides for .NET 15.7.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 15.7.0
type: docs
weight: 180
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- स्थलीकरण
- पुरानी कोड
- आधुनिक कोड
- परंपरागत दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और टूटने वाले परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) या [removed](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) वर्ग, विधि, गुण आदि की सूची प्रस्तुत करता है, और Aspose.Slides for .NET 15.7.0 API के साथ प्रस्तुत किए गए अन्य परिवर्तन।  

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **Enum ImagePixelFormat जोड़ा गया है**
Enum Aspose.Slides.Export.ImagePixelFormat जनरेट की गई छवियों के लिए पिक्सेल फॉर्मेट निर्दिष्ट करने हेतु जोड़ा गया है।  
#### **IChartDataPoint.GetAutomaticDataPointColor() मेथड जोड़ा गया है**
सीरीज़ इंडेक्स, डेटा पॉइंट इंडेक्स, ParentSeriesGroup, IsColorVaried प्रॉपर्टी और चार्ट शैली के आधार पर डेटा पॉइंट का स्वचालित रंग लौटाता है। यदि FillType NotDefined के बराबर है तो यह रंग डिफ़ॉल्ट रूप से उपयोग होता है।  
#### **Method RenderToGraphics Slide में जोड़ा गया है**
Aspose.Slides.Slide में स्लाइड को Graphics ऑब्जेक्ट में रेंडर करने के लिए Method RenderToGraphics (और इसके ओवरलोड) जोड़ा गया है।  
#### **Property PixelFormat ITiffOptions और TiffOptions में जोड़ा गया है**
जनरेट की गई TIFF छवियों के लिए पिक्सेल फॉर्मेट निर्दिष्ट करने हेतु Aspose.Slides.Export.ITiffOptions और Aspose.Slides.Export.TiffOptions में Property PixelFormat जोड़ा गया है।