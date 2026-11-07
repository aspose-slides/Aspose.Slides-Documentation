---
title: Presentaties comprimeren
description: Verminder de grootte van presentaties door afbeeldingen te comprimeren en ongebruikte inhoud te verwijderen.
type: docs
url: /nl/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operaties
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Overzicht**

Comprimeer afbeeldingen, verwijder bijgesneden afbeeldinggebieden wanneer ze niet meer nodig zijn, en kies compressie‑instellingen voor de presentatie vóór het opslaan. Dit is handig voor presentaties met grote foto’s of herhaald media. Het bespaarde aantal hangt af van de inhoud en de door u gekozen instellingen.

## **Voorbeeld van gebruik**

Dit C#‑voorbeeld laadt `input.pptx`, comprimeert de presentatie en slaat deze op als `compressed.pptx`.

Gebruik Aspose.Slides for .NET 26.11 of nieuwer. Voor de installatie, zie [Installeer Aspose.Slides for .NET](/slides/nl/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **Veelgestelde vragen**

### **Is dit een enkele optimalisatieschakelaar voor het volledige bestand?**

Aspose.Slides for .NET 26.11 voegt [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) toe, dat het verwijderen van ongebruikte lay-outs/masters, het subsetten van ingesloten lettertypen en 150‑DPI afbeeldingscompressie combineert. Het verwijdert permanent bijgesneden afbeeldinggebieden. Voor alleen‑afbeeldingsverwerking, gebruik [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); voor fijnere controle, zie het [voorbeeld van individuele‑afbeeldingscompressie](/slides/nl/net/examples/optimization-batch/compression/). Deze nieuwe helpers zijn specifiek voor de genoemde .NET‑versie; raadpleeg de overeenkomstige gids voor andere SDK’s.

### **Verandert afbeeldingscompressie bewerkbare tekst of grafieken?**

Afbeeldingscompressie richt zich op afbeeldingsgegevens, niet op bewerkbare tekst of diagramgegevens. Controleer de afbeeldingen omdat schalen of opnieuw comprimeren de details kan verminderen.

### **Hoe kies ik een resolutie voor presentatie‑afbeeldingen?**

Kies een doelresolutie op basis van de weergegeven afbeeldingsgrootte en het beoogde scherm‑ of afdrukgebruik. Behoud meer resolutie voor grote displays, afdrukken en gedetailleerde diagrammen, en vergelijk de gerenderde output voordat u het origineel verwijdert.

## **Gidsen**

- [Comprimeer de volledige presentatie in .NET](/slides/nl/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optimaliseer afbeeldingbeheer in presentaties in .NET](/slides/nl/net/image/)

Gerelateerde functie: [Verwijder ongebruikte masters, lay-outs en media](/slides/nl/features/remove-unused-content/).

## Uitvoerbare .NET‑voorbeelden

- [Presentatiegrootte verkleinen](/slides/nl/net/examples/optimization-batch/compression/)