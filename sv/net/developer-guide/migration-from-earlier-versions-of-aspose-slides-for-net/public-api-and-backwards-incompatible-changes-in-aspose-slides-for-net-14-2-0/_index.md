---
title: Offentlig API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 14.2.0
linktitle: Aspose.Slides för .NET 14.2.0
type: docs
weight: 40
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- migration
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT, PPTX och ODP-presentationer."
---
## **Offentlig API och bakåtinkompatibla förändringar**
{{% alert color="info" %}} 

Vi har gjort vissa ändringar i Aspose.Slides för .NET 14.2.0 API. Vissa egenskaper och metoder har tagits bort och vissa har flyttats till en annan namnrymd.

{{% /alert %}} 
### **Metoder Aspose.Slides.IPresentation.Write(…) borttagna**
Dessa metoder skrev endast Presentation‑objekt till PPTX‑formatfil. I det nya API‑et är Presentation‑klassen avsedd för att arbeta med alla format. Det är möjligt att använda Presentation.Save(…)‑metoderna för att spara Presentation‑objekten i alla stödjade format.
### **Klasser relaterade till temastilar har flyttats till Aspose.Slides.Theme‑namnrymden**
Följande klasser har flyttats från Aspose.Slides‑namnrymden till Aspose.Slides.Theme‑namnrymden.

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
Aspose.Slides för .NET 8.4-funktioner har lagts till i Aspose.Slides för .NET 14.2.0