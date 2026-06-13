---
title: Aspose.Slides for .NET 14.2.0 में सार्वजनिक API और पिछले संस्करणों के साथ असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
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
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और टूटने वाले बदलावों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
## **सार्वजनिक API और पूर्ववर्ती असंगत परिवर्तन**
{{% alert color="primary" %}} 

हमने Aspose.Slides for .NET 14.2.0 API में कुछ परिवर्तन किए हैं। कुछ प्रॉपर्टी और मेथड हटाए गए हैं और कुछ को अन्य नेमस्पेस में स्थानांतरित किया गया है।

{{% /alert %}} 
### **Methods Aspose.Slides.IPresentation.Write(…) हटाए गए**
इन मेथड्स ने Presentation ऑब्जेक्ट को केवल PPTX फ़ॉर्मेट फ़ाइल में लिखा था। नए API में, Presentation क्लास सभी फ़ॉर्मेटों के साथ काम करने के लिए है। Presentation.Save(…) मेथड्स का उपयोग करके Presentation ऑब्जेक्ट को सभी समर्थित फ़ॉर्मेट में सहेजा जा सकता है।
### **Theme Styles से संबंधित क्लासेस को Aspose.Slides.Theme नेमस्पेस में स्थानांतरित किया गया**
निम्नलिखित क्लासेस को Aspose.Slides नेमस्पेस से Aspose.Slides.Theme नेमस्पेस में स्थानांतरित किया गया है।

- Types ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **Aspose.Slides for .NET 8.X.0 से परिवर्तन**
Aspose.Slides for .NET 8.4 की सुविधाएँ Aspose.Slides for .NET 14.2.0 में जोड़ी गई हैं।