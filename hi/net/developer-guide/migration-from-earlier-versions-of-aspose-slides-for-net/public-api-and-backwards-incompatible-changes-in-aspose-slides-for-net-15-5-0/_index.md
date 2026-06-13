---
title: Aspose.Slides for .NET 15.5.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 15.5.0
type: docs
weight: 160
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- स्थानांतरण
- पुराने कोड
- आधुनिक कोड
- पुरानी पद्धति
- आधुनिक पद्धति
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रेजेंटेशन समाधान को सहजता से माइग्रेट करें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) या [हटाए गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) क्लासेस, मेथड्स, प्रॉपर्टीज़ आदि, और Aspose.Slides for .NET 15.5.0 API के साथ पेश किए गए अन्य बदलावों की सूची देता है।

{{% /alert %}} 
## **सार्वजनिक API बदलाव**
#### **CommonSlideViewProperties क्लास और ICommonSlideViewProperties इंटरफ़ेस जोड़े गए हैं**
Aspose.Slides.CommonSlideViewProperties क्लास और Aspose.Slides.ICommonSlideViewProperties इंटरफ़ेस सामान्य स्लाइड व्यू प्रॉपर्टीज़ (वर्तमान में व्यू स्केल विकल्प) का प्रतिनिधित्व करते हैं।
#### **IAxis.LabelOffset प्रॉपर्टी जोड़ी गई है**
IAxis.LabelOffset प्रॉपर्टी लेबल्स की धुरी से दूरी निर्धारित करती है। यह श्रेणी या तिथि धुरी पर लागू होती है।
#### **IChartTextBlockFormat.AutofitType प्रॉपर्टी जोड़ी गई है**
इस प्रॉपर्टी को बदलने से केवल इन चार्ट भागों पर विशेष प्रभाव पड़ता है: DataLabel और DataLabelFormat (PowerPoint 2013 में पूर्ण समर्थन; PowerPoint 2007 में रेंडरिंग पर कोई प्रभाव नहीं)।
#### **IChartTextBlockFormat.WrapText प्रॉपर्टी जोड़ी गई है**
इस प्रॉपर्टी को बदलने से केवल इन चार्ट भागों पर विशेष प्रभाव पड़ता है: DataLabel और DataLabelFormat (PowerPoint 2007/2013 में पूर्ण समर्थन)।
#### **IChartTextBlockFormat में मार्जिन प्रॉपर्टीज़ जोड़ी गई हैं**
इन प्रॉपर्टीज़ को बदलने से केवल इन चार्ट भागों पर विशेष प्रभाव पड़ता है: DataLabel और DataLabelFormat (PowerPoint 2013 में पूर्ण समर्थन; PowerPoint 2007 में रेंडरिंग पर कोई प्रभाव नहीं)।
#### **ViewProperties.NotesViewProperties प्रॉपर्टी जोड़ी गई है**
Aspose.Slides.ViewProperties.NotesViewProperties प्रॉपर्टी जोड़ी गई है। यह नोट्स व्यू मोड से संबंधित सामान्य व्यू प्रॉपर्टीज़ निर्दिष्ट करती है।
#### **ViewProperties.SlideViewProperties प्रॉपर्टी जोड़ी गई है**
Aspose.Slides.ViewProperties.SlideViewProperties प्रॉपर्टी जोड़ी गई है। यह स्लाइड व्यू मोड से संबंधित सामान्य व्यू प्रॉपर्टीज़ निर्दिष्ट करती है।