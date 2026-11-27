---
title: Presentaties comprimeren
description: Verminder de grootte van presentaties door afbeeldingen te comprimeren en ongebruikte inhoud te verwijderen.
type: docs
url: /nl/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Overzicht**

Compress afbeeldingen, verwijder bijgesneden afbeeldingsterreinen wanneer ze niet meer nodig zijn, en kies compressie‑instellingen voor de presentatie voordat je opslaat. Dit is nuttig voor presentaties met grote foto’s of herhaald media. Het bespaarde bedrag hangt af van de inhoud en de door jou gekozen instellingen.

## **Voorbeeld van gebruik**

Dit C#‑voorbeeld laadt `input.pptx`, comprimeert de presentatie en slaat deze op als `compressed.pptx`.

Gebruik Aspose.Slides for .NET 26.11 of later. Voor installatie, zie [Installeer Aspose.Slides for .NET](/slides/nl/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![Identiek geschaalde afbeeldingen vóór en na compressie, gevolgd door gemeten PPTX‑bestandgroottebalken en opgeslagen afbeeldingsdimensies.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*Gemeten op één synthetische detailroosterfixture: 584,030 → 128,323 bytes. Beide weergaven gebruiken dezelfde schaal en een frame van 252 × 336 punten. Compressie verwijdert de bijgesneden marges en reduceert de opgeslagen afbeelding tot 525 × 700 pixels; de besparing hangt af van de invoer.*  
<!-- visual-explanation:compress-presentations:end -->

## **FAQ**

### **Is dit een enkele optimalisatie‑schakelaar voor het volledige bestand?**

Aspose.Slides for .NET 26.11 voegt [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) toe, die het verwijderen van ongebruikte lay‑out/master, ingesloten‑font‑subsetting en 150‑DPI‑afbeeldingscompressie combineert. Het verwijdert permanent bijgesneden afbeeldingsterreinen. Voor alleen‑afbeeldingsverwerking, gebruik [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); voor fijnere controle, zie het [voorbeeld van compressie per afbeelding](/slides/nl/net/examples/optimization-batch/compression/). Sinds versie 26.11 is dezelfde oproep voor de volledige presentatie ook beschikbaar in Java, Node.js via Java, Python via .NET en C++. Het voorbeeld en de links op deze pagina zijn voor .NET.

### **Verandert afbeeldingscompressie bewerkbare tekst of grafieken?**

Afbeeldingscompressie richt zich op afbeeldingsgegevens, niet op bewerkbare tekst of grafiekgegevens. Controleer de afbeeldingen omdat verkleinen of opnieuw comprimeren hun detail kan verminderen.

### **Hoe moet ik een resolutie kiezen voor afbeeldingen in de presentatie?**

Kies een doel op basis van de weergavegrootte van de afbeelding en het beoogde scherm‑ of afdrukgebruik. Houd meer resolutie voor grote schermen, afdrukken en gedetailleerde diagrammen, en vergelijk de gerenderde output voordat je het origineel verwijdert.

## **Gidsen**

- [Compress de volledige presentatie in .NET](/slides/nl/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optimaliseer beeldbeheer in presentaties in .NET](/slides/nl/net/image/)

Gerelateerde functie: [Verwijder ongebruikte masters, lay‑outs en media](/slides/nl/features/remove-unused-content/).

## .NET‑voorbeelden die je kunt uitvoeren

- [Verminder presentatiegrootte](/slides/nl/net/examples/optimization-batch/compression/)