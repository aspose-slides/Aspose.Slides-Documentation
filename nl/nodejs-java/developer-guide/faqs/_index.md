---
title: FAQ
type: docs
weight: 340
url: /nl/nodejs-java/faqs/
keywords:
- FAQ
- presentatieformaat
- out-of-memory-fout
- diaformaat
- tekst extraheren
- tekst ophalen
- alinea-grootte
- tabellen opmaken
- lettertype
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Krijg antwoorden op veelgestelde vragen over Aspose.Slides voor Node.js via Java, met betrekking tot ondersteuning voor PowerPoint en OpenDocument, installatie-instructies, licenties en probleemoplossing."
---
## **Overzicht**

Deze FAQ geeft antwoorden op veelgestelde vragen over Aspose.Slides. Het behandelt ondersteunde bestandsformaten, het afhandelen van uitzonderingen bij het werken met grote presentaties, het wijzigen van de grootte van dia's, het voorvertonen van dia's, het ophalen van tekst uit presentaties, het opmaken van tabelranden, het plaatsen van afbeeldingen, en het oplossen van fontgerelateerde problemen bij het converteren van presentaties naar PDF of afbeeldingen.

## **Ondersteunde bestandsformaten**

**Q:** Welke bestandsformaten ondersteunt Aspose.Slides voor Node.js via Java?

**A:** Aspose.Slides voor Node.js via Java ondersteunt de bestandsformaten die worden beschreven in [Ondersteunde bestandsformaten](/slides/nl/nodejs-java/supported-file-formats/).

## **Uitzonderingen**

**Q:** Ik krijg een out of memory‑exception bij het laden van een groot PPT‑bestand met afbeeldingen. Is er een limiet in Aspose.Slides met betrekking tot de bestandsgrootte?

**A:** Er bestaat geen specifieke formule om de presentatiegrootte die door Aspose.Slides wordt ondersteund te berekenen. Er moet voldoende geheugen beschikbaar zijn om de volledige presentatie‑structuur en afbeeldingen in het geheugen op te slaan. Normaal gezien nemen afbeeldingen in het geheugen meer ruimte in beslag dan op de harde schijf, vooral wanneer afbeeldingen extra effecten hebben.

In het algemeen kan Aspose.Slides voor Node.js via Java gemakkelijk presentatie‑bestanden van ongeveer 300 MB verwerken op een server met 4 GB RAM.

## **Werken met dia's**

**Q:** Kan ik de grootte van de dia's in een presentatie wijzigen?

**A:** U kunt de `getSlideSize`‑methode gebruiken die wordt blootgesteld door de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse om de grootte van de dia's in een presentatie te definiëren.

**Q:** Is er een manier om dia's van verschillende grootte in één presentatie te definiëren?

**A:** Aangezien de grootte van dia's op presentatieniveau wordt gedefinieerd in Microsoft PowerPoint‑documenten, is er geen mogelijkheid om dit te doen.

**Q:** Ondersteunt Aspose.Slides voor Node.js via Java het voorvertonen van een dia vóór het opslaan?

**A:** U kunt de presentatiedia's renderen naar afbeeldingen en deze afbeeldingen gebruiken om de dia's te previewen.

## **Werken met tekst**

**Q:** Is het mogelijk om alle tekst uit een presentatie op te halen?

**A:** Aspose.Slides voor Node.js via Java biedt de [SlideUtil](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideutil/)‑klasse die diverse methoden levert om de volledige tekst uit presentaties op te halen.

**Q:** Waarom zijn de alinea‑groottes verschillend op Windows‑ en Linux‑besturingssystemen?

**A:** De berekening van alinea‑groottes is gebaseerd op de berekening van de tekstgrootte die de betreffende alinea vertegenwoordigt. De tekstgrootte‑berekening is gebaseerd op de metriek van het lettertype dat in de PowerPoint‑presentatie is opgegeven. Als het opgegeven lettertype ontbreekt, wordt het vervangen door het meest vergelijkbare lettertype, maar dit lettertype heeft metriek die verschilt van de oorspronkelijke. Daardoor leidt de berekening van alinea‑groottes op verschillende systemen tot verschillende resultaten, afhankelijk van de geïnstalleerde lettertypen. Om hetzelfde resultaat op verschillende besturingssystemen te verkrijgen, moet u dezelfde lettertypen op de systemen installeren of ze tijdens runtime laden als [external fonts](/slides/nl/nodejs-java/custom-font/).

## **Opmaak en afbeeldingen**

**Q:** Hoe kan ik de kleur van een tabelrand instellen?

**A:** U kunt de kleur van alle tabelranden of alleen de rand rondom de hele tabel wijzigen. Voor het wijzigen van alle randen, gebruik de `getCellFormat`‑methode van de [Cell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cell/)‑klasse. Voor de rand van de gehele tabel moet u de cellen itereren en de kleur van de buitenranden wijzigen.

**Q:** Welke maat gebruikt Aspose.Slides voor Node.js via Java om afbeeldingen te plaatsen?

**A:** De coördinaten en afmetingen van alle vormen op de dia's worden gemeten in punten (72 dpi).

## **Werken met lettertypen**

**Q:** Waarom verschillen de lettertypen in de uitgangsdocumenten bij het converteren van PPT naar PDF of afbeeldingen?

**A:** Dit probleem kan erop wijzen dat de lettertypen die in de presentatie worden gebruikt, ontbreken op het besturingssysteem waarop de code werd uitgevoerd. U moet de lettertypen op het besturingssysteem installeren of ze laden als externe lettertypen met behulp van de [FontsLoader](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/)‑klasse zoals hieronder weergegeven:
```javascript
var folders = java.newArray("java.lang.String", ["path_to_a_folder_with_fonts"]));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", folders);
```