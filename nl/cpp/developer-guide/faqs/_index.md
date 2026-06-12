---
title: Veelgestelde vragen
type: docs
weight: 340
url: /nl/cpp/faqs/
keywords:
- FAQ
- presentatieformaat
- out-of-memory-fout
- diaformaat
- tekst extraheren
- tekst ophalen
- alineaformaat
- tabellen opmaken
- lettertype
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Krijg antwoorden op veelgestelde vragen over Aspose.Slides voor C++, met aandacht voor ondersteuning van PowerPoint en OpenDocument, installatie‑instructies, licenties en probleemoplossing."
---
## **Overzicht**

Deze FAQ geeft antwoorden op veelgestelde vragen over Aspose.Slides. Het behandelt ondersteunde bestandsindelingen, het afhandelen van uitzonderingen bij het werken met grote presentaties, het wijzigen van diaformaten, het bekijken van dia's, het ophalen van tekst uit presentaties, het opmaken van tabelranden, het plaatsen van afbeeldingen en het oplossen van lettertypegerelateerde problemen bij het converteren van presentaties naar PDF of afbeeldingen.

## **Ondersteunde bestandsindelingen**

**Q:** Welke bestandsindelingen ondersteunt Aspose.Slides voor C++?

**A:** Aspose.Slides voor C++ ondersteunt de bestandsindelingen die beschreven staan in [Supported File Formats](/slides/nl/cpp/supported-file-formats/).

## **Uitzonderingen**

**Q:** Ik krijg een out‑of‑memory‑uitzondering bij het laden van een groot PPT‑bestand met afbeeldingen. Is er een limiet in Aspose.Slides met betrekking tot de bestandsgrootte?

**A:** Er bestaat geen specifieke formule om de grootte van een presentatie die door Aspose.Slides wordt ondersteund te berekenen. Er moet voldoende geheugen beschikbaar zijn om de volledige presentatiestructuur en afbeeldingen in het geheugen op te slaan. Normaal gesproken nemen afbeeldingen in het geheugen meer ruimte in dan op de harde schijf, vooral wanneer afbeeldingen extra effecten hebben.

Over het algemeen kan Aspose.Slides voor C++ gemakkelijk presentaties van ongeveer 300 MB verwerken op een server met 4 GB RAM.

## **Werken met dia's**

**Q:** Kan ik de grootte van de dia's in een presentatie wijzigen?

**A:** U kunt de `get_SlideSize`‑methode gebruiken die wordt blootgesteld door de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse om de grootte van de dia's in een presentatie te definiëren.

**Q:** Is er een manier om dia's van verschillende grootte in een presentatie te definiëren?

**A:** Aangezien de grootte van dia's op presentatieniveau wordt gedefinieerd in Microsoft PowerPoint‑documenten, is er geen mogelijkheid om dit te doen.

**Q:** Ondersteunt Aspose.Slides voor C++ het bekijken van een dia vóór het opslaan?

**A:** U kunt de presentatiedia's renderen naar afbeeldingen en deze afbeeldingen gebruiken om de dia's vooraf te bekijken.

## **Werken met tekst**

**Q:** Is het mogelijk om alle tekst uit een presentatie op te halen?

**A:** Aspose.Slides voor C++ biedt de [SlideUtil](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/)‑klasse onder de `Aspose::Slides::Util`‑namespace die verschillende methoden biedt om de volledige tekst uit de presentaties op te halen.

**Q:** Waarom zijn alinea‑groottes verschillend op Windows‑ en Linux‑besturingssystemen?

**A:** De berekening van alinea‑groottes is gebaseerd op de berekening van de tekengrootte die de betreffende alinea vertegenwoordigt. De berekening van de tekengrootte is gebaseerd op de metriek van het lettertype dat in de PowerPoint‑presentatie is gespecificeerd. Als het opgegeven lettertype ontbreekt, wordt het vervangen door het meest vergelijkbare lettertype, maar dit lettertype heeft metriek die verschilt van de oorspronkelijke. Als gevolg hiervan leidt de berekening van alinea‑groottes op verschillende systemen tot verschillende resultaten, afhankelijk van de geïnstalleerde lettertypes. Om op verschillende besturingssystemen hetzelfde resultaat te behalen, moet u dezelfde lettertypes op de systemen installeren of ze tijdens runtime laden als [external fonts](/slides/nl/cpp/custom-font/).

## **Opmaak en afbeeldingen**

**Q:** Hoe kan ik de kleur van een tabelrand instellen?

**A:** U kunt de kleur van alle tabelranden of alleen de rand rondom de gehele tabel wijzigen. Voor het wijzigen van alle randen, gebruik alstublieft de `get_CellFormat`‑methode van de [ICell](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icell/)‑interface. Voor de rand van de gehele tabel moet u door de cellen itereren en de kleur van de buitenranden aanpassen.

**Q:** Welke eenheid gebruikt Aspose.Slides voor C++ om afbeeldingen te plaatsen?

**A:** De coördinaten en afmetingen van alle vormen op de dia's worden gemeten in punten (72 dpi).

## **Werken met lettertypen**

**Q:** Waarom zijn de lettertypen verschillend in de uitvoerdocumenten bij het converteren van PPT naar PDF of afbeeldingen?

**A:** Dit probleem kan erop wijzen dat de in de presentatie gebruikte lettertypen ontbreken op het besturingssysteem waarop de code werd uitgevoerd. U moet de lettertypen op het besturingssysteem installeren of ze als externe lettertypen laden met behulp van de [FontsLoader](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/)‑klasse, zoals hieronder weergegeven:
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```