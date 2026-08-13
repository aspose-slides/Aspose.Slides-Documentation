---
title: Aspose.Slides for .NET 15.5.0 में सार्वजनिक API और पिछड़ी असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 15.5.0
type: docs
weight: 160
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- माइग्रेशन
- लेगेसी कोड
- आधुनिक कोड
- लेगेसी दृष्टिकोण
- आधुनिक दृष्टिकोण
- पावरपॉइंट
- ओपनडॉक्युमेंट
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और तोड़ने वाले परिवर्तन की समीक्षा करके अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट करें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [added](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) या [removed](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) क्लासेज़, मेथड्स, प्रॉपर्टीज़ आदि की सूची प्रस्तुत करता है, और Aspose.Slides for .NET 15.5.0 API में प्रस्तुत अन्य परिवर्तन।

{{% /alert %}} 
## **Public API Changes**
#### **CommonSlideViewProperties क्लास और ICommonSlideViewProperties इंटरफ़ेस जोड़े गये हैं**
Aspose.Slides.CommonSlideViewProperties क्लास और Aspose.Slides.ICommonSlideViewProperties इंटरफ़ेस सामान्य स्लाइड व्यू प्रॉपर्टीज़ का प्रतिनिधित्व करते हैं (वर्तमान में व्यू स्केल विकल्प)।
#### **IAxis.LabelOffset प्रॉपर्टी जोड़ी गयी है**
IAxis.LabelOffset प्रॉपर्टी लेबल्स की अक्ष से दूरी निर्धारित करती है। यह श्रेणी या तिथि अक्ष पर लागू होती है।
#### **IChartTextBlockFormat.AutofitType प्रॉपर्टी जोड़ी गयी है**
इस प्रॉपर्टी को बदलने से केवल इन चार्ट भागों पर ही कुछ प्रभाव पड़ता है: DataLabel और DataLabelFormat (PowerPoint 2013 में पूर्ण समर्थन; PowerPoint 2007 में रेंडरिंग पर कोई प्रभाव नहीं)।
#### **IChartTextBlockFormat.WrapText प्रॉपर्टी जोड़ी गयी है**
इस प्रॉपर्टी को बदलने से केवल इन चार्ट भागों पर ही कुछ प्रभाव पड़ता है: DataLabel और DataLabelFormat (PowerPoint 2007/2013 में पूर्ण समर्थन)।
#### **Margin प्रॉपर्टीज़ IChartTextBlockFormat में जोड़ी गई हैं**
इन प्रॉपर्टीज़ को बदलने से केवल इन चार्ट भागों पर ही कुछ प्रभाव पड़ता है: DataLabel और DataLabelFormat (PowerPoint 2013 में पूर्ण समर्थन; PowerPoint 2007 में रेंडरिंग पर कोई प्रभाव नहीं)।
#### **ViewProperties.NotesViewProperties प्रॉपर्टी जोड़ी गयी है**
Aspose.Slides.ViewProperties.NotesViewProperties प्रॉपर्टी जोड़ी गई है। यह नोट्स व्यू मोड से जुड़ी सामान्य व्यू प्रॉपर्टीज़ को निर्दिष्ट करती है।
#### **ViewProperties.SlideViewProperties प्रॉपर्टी जोड़ी गयी है**
Aspose.Slides.ViewProperties.SlideViewProperties प्रॉपर्टी जोड़ी गई है। यह स्लाइड व्यू मोड से जुड़ी सामान्य व्यू प्रॉपर्टीज़ को निर्दिष्ट करती है।