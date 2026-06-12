---
title: FAQ
type: docs
weight: 340
url: /nl/java/faqs/
keywords:
- FAQ
- presentatieformaat
- out of memory fout
- dia-grootte
- tekst extraheren
- tekst ophalen
- paragraafgrootte
- tabellen opmaken
- lettertype
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Krijg antwoorden op veelgestelde vragen over Aspose.Slides for Java, met betrekking tot ondersteuning voor PowerPoint en OpenDocument, installatie-instructies, licenties en probleemoplossing."
---
## **Overzicht**

Deze FAQ geeft antwoorden op veelgestelde vragen over Aspose.Slides. Het behandelt ondersteunde bestandsformaten, het afhandelen van uitzonderingen bij grote presentaties, het wijzigen van dia‑groottes, het previewen van dia's, het ophalen van tekst uit presentaties, het opmaken van tabelranden, het plaatsen van afbeeldingen en het oplossen van fontgerelateerde problemen bij het converteren van presentaties naar PDF of afbeeldingen.

## **Ondersteunde bestandsformaten**

**Q: Welke bestandsformaten ondersteunt Aspose.Slides for Java?**

**A**: Aspose.Slides for Java ondersteunt de bestandsformaten die worden beschreven in [Supported File Formats](/slides/nl/java/supported-file-formats/).

## **Uitzonderingen**

**Q: Ik krijg een out of memory‑uitzondering bij het laden van een grote PPT‑file met afbeeldingen. Is er een limiet in Aspose.Slides wat betreft bestandsgrootte?**

**A**: Er bestaat geen specifieke formule om de presentatie‑grootte die door Aspose.Slides wordt ondersteund te berekenen. Er moet voldoende geheugen beschikbaar zijn om de volledige presentatiestructuur en de afbeeldingen in het geheugen te plaatsen. Normaal gezien nemen afbeeldingen in het geheugen meer ruimte in dan op de harde schijf, vooral wanneer afbeeldingen extra effecten hebben.

Over het algemeen kan Aspose.Slides for Java gemakkelijk presentaties van ongeveer 300 MB verwerken op een server met 4 GB RAM.

## **Werken met dia's**

**Q: Kan ik de grootte van de dia's in een presentatie wijzigen?**

**A**: Je kunt de `getSlideSize`‑methode gebruiken die wordt aangeboden door de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse om de grootte van de dia's in een presentatie te definiëren.

**Q: Is er een manier om dia's van verschillende grootte in één presentatie te definiëren?**

**A**: Omdat de grootte van dia's wordt gedefinieerd op presentatieniveau in Microsoft PowerPoint‑documenten, is dit niet mogelijk.

**Q: Ondersteunt Aspose.Slides for Java het previewen van een dia vóór het opslaan?**

**A**: Je kunt de presentatiedia's renderen naar afbeeldingen en deze afbeeldingen gebruiken voor een preview van de dia's.

## **Werken met tekst**

**Q: Is het mogelijk om alle tekst uit een presentatie op te halen?**

**A**: Aspose.Slides for Java biedt de [SlideUtil](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideutil/)‑klasse die verschillende methoden bevat om de volledige tekst uit presentaties op te halen.

**Q: Waarom verschillen de paragrafengroottes tussen Windows‑ en Linux‑besturingssystemen?**

**A**: De berekening van de paragrafengrootte is gebaseerd op de berekening van de tekstgrootte die de betreffende paragraaf representeert. De tekstgrootte‑berekening is gebaseerd op de metriek van het font dat in de PowerPoint‑presentatie is opgegeven. Als het opgegeven font ontbreekt, wordt het vervangen door het meest vergelijkbare font, maar dit font heeft andere metrische waarden dan het originele. Daardoor leidt de berekening van paragrafengroottes op verschillende systemen tot verschillende resultaten, afhankelijk van de geïnstalleerde fonts. Om op verschillende besturingssystemen hetzelfde resultaat te krijgen, moet je dezelfde fonts op de systemen installeren of ze tijdens runtime laden als [external fonts](/slides/nl/java/custom-font/).

## **Opmaak en afbeeldingen**

**Q: Hoe kan ik de kleur van een tabelrand instellen?**

**A**: Je kunt de kleur van alle tabelranden wijzigen of alleen de rand rond de volledige tabel. Voor het wijzigen van alle randen, gebruik je de `getCellFormat`‑methode van de [ICell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icell/)‑interface. Voor de rand van de volledige tabel moet je de cellen itereren en de kleur van de buitenranden aanpassen.

**Q: Welke meeteenheid gebruikt Aspose.Slides for Java om afbeeldingen te plaatsen?**

**A**: De coördinaten en afmetingen van alle vormen op de dia's worden gemeten in points (72 dpi).

## **Werken met fonts**

**Q: Waarom verschillen de fonts in de uitvoer‑documenten bij het converteren van PPT naar PDF of afbeeldingen?**

**A**: Dit probleem kan erop wijzen dat de fonts die in de presentatie worden gebruikt, ontbreken op het besturingssysteem waarop de code wordt uitgevoerd. Je moet de fonts installeren op het besturingssysteem of ze laden als externe fonts met behulp van de [FontsLoader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/)‑klasse zoals hieronder weergegeven:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```