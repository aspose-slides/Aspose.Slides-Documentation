---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
---

## **Public API and Backwards Incompatible Changes**
{{% alert color="primary" %}} 

We have made some changes in the Aspose.Slides for .NET 14.2.0 API. Some properties and methods have been removed and some have been moved to other namespace.

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
Aspose.Slides for .NET 8.4 features are added to Aspose.Slides for .NET 14.2.0
