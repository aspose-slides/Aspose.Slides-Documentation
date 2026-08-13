---
title: Aspose.Slides for .NET 14.2.0 में सार्वजनिक API और बैकवर्ड असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- माइग्रेशन
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
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधान को सुगमता से माइग्रेट कर सकें।"
---
## **सार्वजनिक API और बैकवर्ड असंगत परिवर्तन**
{{% alert color="info" %}} 

हमने Aspose.Slides for .NET 14.2.0 API में कुछ परिवर्तन किए हैं। कुछ प्रॉपर्टी और मेथड हटाए गए हैं और कुछ को अन्य नेमस्पेस में स्थानांतरित किया गया है।

{{% /alert %}} 
### **Methods Aspose.Slides.IPresentation.Write(…) Removed**
These methods wrote Presentation objects only to PPTX format file. In the new API, the Presentation class is for working with all formats. It is possible to use the Presentation.Save(…) methods to save the Presentation objects to all supported formats.
### **Classes Related to Theme Styles Moved to the Aspose.Slides.Theme Namespace**
The following classes have been moved from the Aspose.Slides namespace to the Aspose.Slides.Theme namespace.

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
### **Changes from Aspose.Slides for .NET 8.X.0**
Aspose.Slides for .NET 8.4 की विशेषताएँ Aspose.Slides for .NET 14.2.0 में जोड़ी गई हैं।