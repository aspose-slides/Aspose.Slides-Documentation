---
title: Publieke API en achterwaarts incompatibele wijzigingen in Aspose.Slides for .NET 14.2.0
linktitle: Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- migratie
- legacy-code
- moderne code
- legacy-aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de updates van de publieke API en brekende wijzigingen in Aspose.Slides for .NET om uw PowerPoint PPT, PPTX en ODP presentatie-oplossingen soepel te migreren."
---
## **Publieke API en achterwaarts incompatibele wijzigingen**
{{% alert color="info" %}} 

We hebben enkele wijzigingen aangebracht in de Aspose.Slides for .NET 14.2.0 API. Sommige eigenschappen en methoden zijn verwijderd en sommige zijn verplaatst naar een andere namespace.

{{% /alert %}} 
### **Methoden Aspose.Slides.IPresentation.Write(…) verwijderd**
Deze methoden schreven Presentation‑objecten uitsluitend naar een PPTX‑bestand. In de nieuwe API is de Presentation‑klasse bedoeld voor het werken met alle formaten. Het is mogelijk om de Presentation.Save(…)‑methoden te gebruiken om de Presentation‑objecten op te slaan in alle ondersteunde formaten.
### **Klassen gerelateerd aan themastijlen verplaatst naar de Aspose.Slides.Theme namespace**
De volgende klassen zijn verplaatst van de Aspose.Slides namespace naar de Aspose.Slides.Theme namespace.

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
### **Wijzigingen vanaf Aspose.Slides for .NET 8.X.0**
Aspose.Slides for .NET 8.4‑functies zijn toegevoegd aan Aspose.Slides for .NET 14.2.0