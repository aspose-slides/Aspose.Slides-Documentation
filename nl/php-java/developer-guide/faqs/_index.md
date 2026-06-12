---
title: FAQ
type: docs
weight: 340
url: /nl/php-java/faqs/
keywords:
- FAQ
- presentatieformaat
- out of memory-fout
- diaformaat
- tekst extraheren
- tekst ophalen
- alineaformaat
- tabellen opmaken
- lettertype
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Krijg antwoorden op veelgestelde vragen over Aspose.Slides voor PHP via Java, met informatie over PowerPoint- en OpenDocument-ondersteuning, installatie-instructies, licenties en probleemoplossing."
---
## **Overzicht**

Deze FAQ biedt antwoorden op veelgestelde vragen over Aspose.Slides. Het behandelt ondersteunde bestandsformaten, het afhandelen van uitzonderingen bij het werken met grote presentaties, het wijzigen van de diaformaten, het voorvertonen van dia’s, het ophalen van tekst uit presentaties, het opmaken van tabelranden, het plaatsen van afbeeldingen, en het oplossen van fontgerelateerde problemen bij het converteren van presentaties naar PDF of afbeeldingen.

## **Ondersteunde bestandsformaten**

**V: Welke bestandsformaten ondersteunt Aspose.Slides for PHP via Java?**

**A**: Aspose.Slides for PHP via Java ondersteunt de bestandsformaten die beschreven staan in [Ondersteunde bestandsformaten](/slides/nl/php-java/supported-file-formats/).

## **Uitzonderingen**

**V: Ik krijg een out of memory‑uitzondering bij het laden van een groot PPT‑bestand met afbeeldingen. Is er een limiet in Aspose.Slides met betrekking tot de bestandsgrootte?**

**A**: Er bestaat geen specifieke formule om de door Aspose.Slides ondersteunde presentatiegrootte te berekenen. Er moet voldoende geheugen beschikbaar zijn om de hele presentatiestructuur en de afbeeldingen in het geheugen te kunnen plaatsen. Normaal gesproken nemen afbeeldingen in het geheugen meer ruimte in dan op de harde schijf, vooral wanneer afbeeldingen extra effecten hebben.

Over het algemeen kan Aspose.Slides for PHP via Java gemakkelijk presentatiebestanden van ongeveer 300 MB verwerken op een server met 4 GB RAM.

## **Werken met dia’s**

**V: Kan ik de grootte van de dia’s in een presentatie wijzigen?**

**A**: U kunt de `getSlideSize`‑methode gebruiken die beschikbaar is via de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse om de grootte van de dia’s in een presentatie te definiëren.

**V: Is er een manier om dia’s met verschillende groottes in één presentatie te definiëren?**

**A**: Aangezien de grootte van dia’s wordt gedefinieerd op presentatieniveau in Microsoft PowerPoint‑documenten, is er geen manier om dit te doen.

**V: Ondersteunt Aspose.Slides for PHP via Java het voorvertonen van een dia vóór het opslaan?**

**A**: U kunt de presentatiedia’s renderen naar afbeeldingen en deze afbeeldingen gebruiken om de dia’s te voorvertonen.

## **Werken met tekst**

**V: Is het mogelijk om alle tekst uit een presentatie op te halen?**

**A**: Aspose.Slides for PHP via Java biedt de [SlideUtil](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideutil/)‑klasse die verschillende methoden bevat om de volledige tekst uit presentaties op te halen.

**V: Waarom zijn alinea‑groottes verschillend op Windows‑ en Linux‑besturingssystemen?**

**A**: De berekening van alinea‑groottes is gebaseerd op de berekening van de tekstgrootte die de betreffende alinea representeert. De tekstgrootteberekening is gebaseerd op de metriek van het lettertype dat is gespecificeerd in de PowerPoint‑presentatie. Als het opgegeven lettertype ontbreekt, wordt het vervangen door het meest vergelijkbare lettertype, maar dit lettertype heeft metriek die verschilt van het origineel. Hierdoor leidt de berekening van alinea‑groottes op verschillende systemen tot verschillende resultaten, afhankelijk van de geïnstalleerde lettertype‑set. Om op verschillende besturingssystemen hetzelfde resultaat te verkrijgen, moet u dezelfde lettertypen op de systemen installeren of ze tijdens runtime laden als [externe lettertypen](/slides/nl/php-java/custom-font/).

## **Opmaak en afbeeldingen**

**V: Hoe kan ik de kleur van een tabelrand instellen?**

**A**: U kunt de kleur van alle tabelranden wijzigen of alleen de rand rond de volledige tabel. Voor het wijzigen van alle randen, gebruik de `getCellFormat`‑methode van de [Cell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cell/)‑klasse. Voor de rand van de volledige tabel moet u cellen itereren en de kleur van de buitenranden wijzigen.

**V: Welke eenheid gebruikt Aspose.Slides for PHP via Java om afbeeldingen te positioneren?**

**A**: De coördinaten en afmetingen van alle vormen op de dia’s worden gemeten in points (72 dpi).

## **Werken met lettertypen**

**V: Waarom zijn de lettertypen verschillend in de uitvoerdocumenten bij het converteren van PPT naar PDF of afbeeldingen?**

**A**: Dit probleem kan erop wijzen dat de in de presentatie gebruikte lettertypen ontbreken op het besturingssysteem waarop de code werd uitgevoerd. U moet de lettertypen op het besturingssysteem installeren of ze laden als externe lettertypen met behulp van de [FontsLoader](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/)‑klasse zoals hieronder weergegeven:
```php
$folders = ["path_to_a_folder_with_fonts"];
FontsLoader::loadExternalFonts($folders);
```