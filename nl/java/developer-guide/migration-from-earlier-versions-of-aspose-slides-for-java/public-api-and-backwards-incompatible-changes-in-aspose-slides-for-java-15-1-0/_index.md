---
title: Openbare API en achterwaartse incompatibele wijzigingen in Aspose.Slides voor Java 15.1.0
linktitle: Aspose.Slides voor Java 15.1.0
type: docs
weight: 100
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- migratie
- verouderde code
- moderne code
- verouderde aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de openbare API-updates en brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT, PPTX en ODP presentatieoplossingen soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft een overzicht van alle [toegevoegd](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) klassen, methoden, eigenschappen enz., eventuele nieuwe beperkingen en andere [wijzigingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) die zijn geïntroduceerd met de Aspose.Slides for Java 15.1.0 API.

{{% /alert %}} {{% alert color="primary" %}} 

Er zijn bekende problemen met sommige afbeeldingskogelpunten en WordArt-objecten die worden opgelost in Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Openbare API-wijzigingen**
### **Lettertypevervangingsfunctionaliteit is toegevoegd**
De mogelijkheid om lettertypen globaal in de volledige presentatie en tijdelijk voor weergave te vervangen, is toegevoegd.

De nieuwe methode getFontsManager() van de Presentation‑klasse is geïntroduceerd. De FontsManager‑klasse heeft de volgende leden:

**IFontSubstRuleCollection getFontSubstRuleList**() method

Dit is de verzameling IFontSubstRule‑instanties die worden gebruikt om lettertypen tijdens het renderen te vervangen. IFontSubstRule bevat de methoden getSourceFont() en getDestFont() die de IFontData‑interface implementeren, en de methode getReplaceFontCondition() waarmee de vervangingsconditie kan worden gekozen ('WhenInaccessible' of 'Always').

**IFontData[] getFonts**() method kan worden gebruikt om alle in de huidige presentatie gebruikte lettertypen op te halen.

**replaceFont(...)** methods kunnen worden gebruikt om een lettertype blijvend in een presentatie te vervangen. 

Het volgende voorbeeld toont hoe een lettertype in een presentatie kan worden vervangen:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Een ander voorbeeld toont lettertypevervanging voor weergave wanneer het niet toegankelijk is:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Arial-lettertype wordt gebruikt in plaats van SomeRareFont wanneer het niet toegankelijk is

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```