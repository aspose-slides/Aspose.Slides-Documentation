---
title: Offentlig API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 14.2.0
linktitle: Aspose.Slides för .NET 14.2.0
type: docs
weight: 40
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammalt tillvägagångssätt
- modernt tillvägagångssätt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska uppdateringar av offentligt API och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationslösningar."
---
## **Offentlig API och bakåtinkompatibla förändringar**
{{% alert color="primary" %}} 

Vi har gjort vissa ändringar i Aspose.Slides för .NET 14.2.0 API. Vissa egenskaper och metoder har tagits bort och några har flyttats till en annan namnrymd.

{{% /alert %}} 
### **Metoder Aspose.Slides.IPresentation.Write(…) borttagna**
Dessa metoder skrev endast Presentation-objekt till PPTX-formatfil. I det nya API:et är Presentation-klassen avsedd för att arbeta med alla format. Det är möjligt att använda Presentation.Save(…)‑metoderna för att spara Presentation-objekten till alla stödda format.
### **Klasser relaterade till temastilar flyttade till Aspose.Slides.Theme‑namnrymden**
Följande klasser har flyttats från Aspose.Slides‑namespace till Aspose.Slides.Theme‑namespace.

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
### **Ändringar från Aspose.Slides för .NET 8.X.0**
Funktioner från Aspose.Slides för .NET 8.4 har lagts till i Aspose.Slides för .NET 14.2.0