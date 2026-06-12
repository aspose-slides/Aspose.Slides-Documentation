---
title: Veelgestelde vragen
type: docs
weight: 340
url: /nl/net/faqs/
keywords:
- FAQ
- PowerPoint
- presentatieformaat
- out of memory-fout
- diaformaat
- tekst extraheren
- tekst ophalen
- alinea-grootte
- tabellen opmaken
- lettertype
- .NET
- C#
- Aspose.Slides
description: "Krijg antwoorden op veelgestelde vragen over Aspose.Slides voor .NET, met betrekking tot ondersteuning voor PowerPoint en OpenDocument, installatie-instructies, licenties en probleemoplossing."
---
## **Overzicht**

Deze FAQ biedt antwoorden op veelgestelde vragen over Aspose.Slides. Het behandelt ondersteunde bestandsformaten, het afhandelen van uitzonderingen bij het werken met grote presentaties, het wijzigen van de diaformaten, het bekijken van dia’s, het ophalen van tekst uit presentaties, het opmaken van tabelranden, het plaatsen van afbeeldingen en het oplossen van fontgerelateerde problemen bij het converteren van presentaties naar PDF of afbeeldingen.

## **Ondersteunde bestandsformaten**

**Q: Welke bestandsformaten ondersteunt Aspose.Slides voor .NET?**

**A**: Aspose.Slides voor .NET ondersteunt de bestandsformaten die beschreven staan in [Supported File Formats](/slides/nl/net/supported-file-formats/).

## **Uitzonderingen**

**Q: Ik krijg een OutOfMemoryException bij het laden van een groot PPT‑bestand met afbeeldingen. Is er een limiet in Aspose.Slides met betrekking tot de bestandsgrootte?**

**A**: Er is geen specifieke formule om de door Aspose.Slides ondersteunde presentatiegrootte te berekenen. Er moet voldoende geheugen beschikbaar zijn om de volledige presentatiestructuur en de afbeeldingen in het geheugen te kunnen opnemen. Normaal gezien nemen afbeeldingen in het geheugen meer ruimte in beslag dan op de harde schijf, met name wanneer de afbeeldingen extra-effecten hebben.

In het algemeen kan Aspose.Slides voor .NET gemakkelijk presentaties van ongeveer 300 MB verwerken op een server met 4 GB RAM.

## **Werken met dia's**

**Q: Kan ik de grootte van de dia’s in een presentatie wijzigen?**

**A**: Je kunt de eigenschap `SlideSize` gebruiken die wordt aangeboden door de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse om de grootte van de dia’s in een presentatie te definiëren.

**Q: Is er een manier om dia’s van verschillende afmetingen in één presentatie te definiëren?**

**A**: Aangezien de grootte van dia’s wordt vastgesteld op presentatieniveau in Microsoft PowerPoint‑documenten, is dit niet mogelijk.

**Q: Ondersteunt Aspose.Slides voor .NET het vooraf bekijken van een dia vóór het opslaan?**

**A**: Je kunt de presentatiedia’s renderen naar afbeeldingen en deze afbeeldingen gebruiken om de dia’s te bekijken.

## **Werken met tekst**

**Q: Is het mogelijk om alle tekst uit een presentatie op te halen?**

**A**: Aspose.Slides voor .NET biedt de [SlideUtil](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/)‑klasse in de namespace `Aspose.Slides.Util` die verschillende methoden bevat om de volledige tekst uit presentaties op te halen.

**Q: Waarom zijn alinea‑groottes verschillend op Windows‑ en Linux‑besturingssystemen?**

**A**: De berekening van alinea‑groottes is gebaseerd op de berekening van de tekengrootte die de betreffende alinea vertegenwoordigt. De tekengrootte wordt berekend op basis van de metriek van het lettertype dat in de PowerPoint‑presentatie is gespecificeerd. Als het opgegeven lettertype ontbreekt, wordt het vervangen door het meest vergelijkbare lettertype, maar dit lettertype heeft andere metrische waarden dan het origineel. Hierdoor leidt de berekening van alinea‑groottes op verschillende systemen tot verschillende resultaten, afhankelijk van de geïnstalleerde lettertypen. Om hetzelfde resultaat op verschillende besturingssystemen te krijgen, moet je dezelfde lettertypen op de systemen installeren of ze tijdens runtime laden als [external fonts](/slides/nl/net/custom-font/).

## **Opmaak en afbeeldingen**

**Q: Hoe kan ik de kleur van een tabelrand instellen?**

**A**: Je kunt de kleur van alle tabelranden wijzigen of alleen de rand rond de volledige tabel. Om alle randen te wijzigen, gebruik je de `CellFormat`‑eigenschap van de [ICell](https://reference.aspose.com/slides/nl/net/aspose.slides/icell/)‑interface. Voor de rand van de volledige tabel moet je de cellen doorlopen en de kleur van de buitenranden aanpassen.

**Q: Welke maat gebruikt Aspose.Slides voor .NET om afbeeldingen te plaatsen?**

**A**: De coördinaten en afmetingen van alle vormen op de dia’s worden gemeten in points (72 dpi).

## **Werken met lettertypen**

**Q: Waarom verschillen de lettertypen in de output‑documenten bij het converteren van PPT naar PDF of afbeeldingen?**

**A**: Dit probleem kan erop wijzen dat de in de presentatie gebruikte lettertypen ontbreken op het besturingssysteem waarop de code werd uitgevoerd. Je moet de lettertypen op het besturingssysteem installeren of ze laden als externe lettertypen met behulp van de [FontsLoader](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/)‑klasse, zoals hieronder getoond:
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```