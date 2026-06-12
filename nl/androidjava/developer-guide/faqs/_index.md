---
title: FAQ
type: docs
weight: 340
url: /nl/androidjava/faqs/
keywords:
- FAQ
- presentatieformaat
- out of memory-fout
- diaformaat
- tekst extraheren
- tekst ophalen
- alinea-grootte
- tabellen opmaken
- lettertype
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Krijg antwoorden op veelgestelde vragen over Aspose.Slides voor Android via Java, met betrekking tot ondersteuning voor PowerPoint en OpenDocument, installatie-instructies, licenties en probleemoplossing."
---
## **Overzicht**

Deze FAQ geeft antwoorden op veelvoorkomende vragen over Aspose.Slides. Het behandelt ondersteunde bestandsformaten, het afhandelen van uitzonderingen bij het werken met grote presentaties, het wijzigen van diaformaten, het voorbeelden van dia’s, het ophalen van tekst uit presentaties, het opmaken van tabelranden, het plaatsen van afbeeldingen en het oplossen van fontgerelateerde problemen bij het converteren van presentaties naar PDF of afbeeldingen.

## **Ondersteunde bestandsformaten**

**Q:** Welke bestandsformaten ondersteunt Aspose.Slides voor Android via Java?

**A:** Aspose.Slides voor Android via Java ondersteunt de bestandsformaten die worden beschreven in [Supported File Formats](/slides/nl/androidjava/supported-file-formats/).

## **Uitzonderingen**

**Q:** Ik krijg een out of memory‑exception bij het laden van een groot PPT‑bestand met afbeeldingen. Is er een limiet in Aspose.Slides met betrekking tot de bestandsgrootte?

**A:** Er bestaat geen specifieke formule voor het berekenen van de presentatiegrootte die door Aspose.Slides wordt ondersteund. Er moet voldoende ruimte zijn om de volledige presentatiestructuur en afbeeldingen in het geheugen onder te brengen. Normaal gezien nemen afbeeldingen in het geheugen meer ruimte in dan op de harde schijf, vooral wanneer de afbeeldingen extra effecten hebben.

In het algemeen kan Aspose.Slides voor Android via Java eenvoudig presentaties van ongeveer 300 MB verwerken op een server met 4 GB RAM.

## **Werken met dia’s**

**Q:** Kan ik de grootte van de dia’s in een presentatie wijzigen?

**A:** U kunt de `getSlideSize`‑methode gebruiken die wordt blootgesteld door de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse om de grootte van de dia’s in een presentatie te definiëren.

**Q:** Is er een manier om dia’s van verschillende grootte in een presentatie te definiëren?

**A:** Omdat de grootte van dia’s op presentatieniveau wordt gedefinieerd in Microsoft PowerPoint‑documenten, is dit niet mogelijk.

**Q:** Ondersteunt Aspose.Slides voor Android via Java het voorbeelden van een dia vóór het opslaan?

**A:** U kunt de presentatiedia’s renderen naar afbeeldingen en deze afbeeldingen gebruiken voor het voorbeelden van de dia’s.

## **Werken met tekst**

**Q:** Is het mogelijk om alle tekst uit een presentatie op te halen?

**A:** Aspose.Slides voor Android via Java biedt de [SlideUtil](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideutil/)‑klasse die verschillende methoden heeft voor het ophalen van de volledige tekst uit de presentaties.

**Q:** Waarom zijn de alinea‑groottes anders op PC en Android?

**A:** De berekening van alinea‑groottes is gebaseerd op de berekening van de tekengrootte die de betreffende alinea weergeeft. De tekengrootte‑berekening is gebaseerd op de metriek van het lettertype dat in de PowerPoint‑presentatie is opgegeven. Als het opgegeven lettertype ontbreekt, wordt het vervangen door het meest vergelijkbare lettertype, maar dit lettertype heeft metriek die verschilt van de originele. Daardoor leidt de berekening van alinea‑groottes op verschillende systemen tot verschillende resultaten, afhankelijk van de set geïnstalleerde lettertypen. Om hetzelfde resultaat op verschillende besturingssystemen te bereiken, moet u dezelfde lettertypen op de systemen installeren of ze tijdens runtime laden als [external fonts](/slides/nl/androidjava/custom-font/).

## **Opmaak en afbeeldingen**

**Q:** Hoe kan ik de kleur van een tabelrand instellen?

**A:** U kunt de kleur van alle tabelranden of alleen de rand rondom de gehele tabel wijzigen. Voor het wijzigen van alle randen gebruikt u de `getCellFormat`‑methode van de [ICell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icell/)‑interface. Voor de rand van de gehele tabel moet u de cellen itereren en de kleur van de buitenranden aanpassen.

**Q:** Welke maat gebruikt Aspose.Slides voor Android via Java om afbeeldingen te plaatsen?

**A:** De coördinaten en afmetingen van alle vormen op de dia’s worden gemeten in points (72 dpi).

## **Werken met lettertypen**

**Q:** Waarom zijn de lettertypen verschillend in de uitvoerdocumenten bij het converteren van PPT naar PDF of afbeeldingen?

**A:** Dit probleem kan erop wijzen dat de in de presentatie gebruikte lettertypen ontbreken op het besturingssysteem waarop de code is uitgevoerd. U moet de lettertypen op het besturingssysteem installeren of ze laden als externe lettertypen met de [FontsLoader](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/)‑klasse, zoals hieronder wordt getoond:
```java
String[] folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```