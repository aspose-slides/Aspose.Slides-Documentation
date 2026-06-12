---
title: Veelgestelde vragen
type: docs
weight: 340
url: /nl/python-net/faq/
keywords:
- FAQ
- presentatieformaat
- geheugen fout
- diaformaat
- tekst extraheren
- tekst ophalen
- paragraafgrootte
- tabellen opmaken
- lettertype
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Ontvang antwoorden op veelgestelde vragen over Aspose.Slides voor Python via .NET, met informatie over ondersteuning voor PowerPoint en OpenDocument, installatie-instructies, licentiëring en probleemoplossing."
---
## **Overzicht**

Deze FAQ geeft antwoorden op veelgestelde vragen over Aspose.Slides. Het behandelt ondersteunde bestandsformaten, het afhandelen van uitzonderingen bij grote presentaties, het wijzigen van diaformaten, het voorvertonen van dia's, het ophalen van tekst uit presentaties, het opmaken van tabelranden, het plaatsen van afbeeldingen en het oplossen van font‑gerelateerde problemen bij het converteren van presentaties naar PDF of afbeeldingen.

## **Ondersteunde bestandsformaten**

**Q:** Welke bestandsformaten ondersteunt Aspose.Slides for Python via .NET?

**A:** Aspose.Slides for Python via .NET ondersteunt de bestandsformaten die worden beschreven in [Ondersteunde bestandsformaten](/slides/nl/python-net/supported-file-formats/).

## **Uitzonderingen**

**Q:** Ik krijg een out of memory‑uitzondering bij het laden van een grote PPT‑file met afbeeldingen. Is er een limiet in Aspose.Slides wat betreft bestandsgrootte?

**A:** Er bestaat geen specifieke formule om de presentatiegrootte die door Aspose.Slides wordt ondersteund te berekenen. Er moet voldoende geheugen beschikbaar zijn om de volledige presentatiestructuur en de afbeeldingen in het geheugen te kunnen plaatsen. Normaal gezien nemen afbeeldingen in het geheugen meer ruimte in dan op de harde schijf, vooral wanneer ze extra effecten hebben.

Over het algemeen kan Aspose.Slides for Python via .NET gemakkelijk presentaties van ongeveer 300 MB verwerken op een server met 4 GB RAM.

## **Werken met dia's**

**Q:** Kan ik de grootte van de dia's in een presentatie wijzigen?

**A:** Je kunt de eigenschap `slide_size` gebruiken die wordt aangeboden door de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse om de grootte van de dia's in een presentatie te definiëren.

**Q:** Is er een manier om dia's van verschillende grootte in één presentatie te definiëren?

**A:** Omdat de grootte van dia's op presentatieniveau wordt vastgesteld in Microsoft PowerPoint‑documenten, is dit niet mogelijk.

**Q:** Ondersteunt Aspose.Slides for Python via .NET het voorvertonen van een dia vóór het opslaan?

**A:** Je kunt de presentatiedia's renderen naar afbeeldingen en deze afbeeldingen gebruiken voor een voorvertoning van de dia's.

## **Werken met tekst**

**Q:** Is het mogelijk om alle tekst uit een presentatie op te halen?

**A:** Aspose.Slides for Python via .NET biedt de [SlideUtil](https://reference.aspose.com/slides/nl/python-net/aspose.slides.util/slideutil/)‑klasse onder de `aspose.slides.util`‑namespace die diverse methoden bevat om de volledige tekst uit presentaties te extraheren.

**Q:** Waarom verschillen de alineagroottes tussen Windows‑ en Linux‑besturingssystemen?

**A:** De berekening van alineagroottes is gebaseerd op de berekening van de tekstgrootte van de betreffende alinea. De tekstgrootte wordt berekend op basis van de metriek van het font dat in de PowerPoint‑presentatie is gespecificeerd. Als het opgegeven font ontbreekt, wordt het vervangen door het meest op het origineel gelijkende font, maar dit font heeft andere metrische gegevens. Hierdoor leidt de berekening van alineagroottes op verschillende systemen tot verschillende uitkomsten, afhankelijk van de geïnstalleerde fonts. Om op verschillende besturingssystemen hetzelfde resultaat te krijgen, moet je dezelfde fonts installeren of ze tijdens runtime laden als [externe fonts](/slides/nl/python-net/custom-font/).

## **Opmaak en afbeeldingen**

**Q:** Hoe kan ik de kleur van een tabelrand instellen?

**A:** Je kunt de kleur van alle tabelranden of alleen de rand rond de volledige tabel wijzigen. Voor het wijzigen van alle randen, gebruik je de eigenschap `cell_format` van de [Cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/)‑klasse. Voor de rand van de volledige tabel moet je de cellen itereren en de kleur van de buitenranden aanpassen.

**Q:** Welke eenheid gebruikt Aspose.Slides for Python via .NET om afbeeldingen te plaatsen?

**A:** De coördinaten en afmetingen van alle vormen op de dia's worden gemeten in points (72 dpi).

## **Werken met fonts**

**Q:** Waarom verschillen de fonts in de uitvoerbestanden bij het converteren van PPT naar PDF of afbeeldingen?

**A:** Dit probleem kan erop wijzen dat de fonts die in de presentatie worden gebruikt, ontbreken op het besturingssysteem waarop de code wordt uitgevoerd. Installeer de fonts op het besturingssysteem of laad ze als externe fonts met behulp van de [FontsLoader](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsloader/)‑klasse zoals hieronder wordt getoond:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```