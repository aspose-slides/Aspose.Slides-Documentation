---
title: Haal presentatieweergave‑eigenschappen op en werk ze bij in JavaScript
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/nodejs-java/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- schetsinhoud
- schets‑iconen
- verticale splitter vastklikken
- enkele weergave
- balk‑status
- dimensie‑grootte
- automatisch aanpassen
- standaard‑zoom
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Node.js via Java‑weergave‑eigenschappen om PPT-, PPTX- en ODP‑dia’s te personaliseren—lay‑outs, zoomniveaus en weergave‑instellingen aan te passen."
---
## **Introductie**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zij-inhoudsgebied en een onder-inhoudsgebied. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavestatus op te slaan in het bestand, zodat bij het opnieuw openen de weergave in dezelfde staat is als toen de presentatie voor het laatst werd opgeslagen.

Methode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie.  

[NormalViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewRestoredProperties) klasse en de afgeleiden, [SplitterBarStateType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType) enum zijn toegevoegd.

## **Over NormalViewProperties**

Stelt de normale weergave‑eigenschappen voor.

Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) geven aan of de applicatie pictogrammen moet tonen bij het weergeven van outline‑inhoud in een van de inhoudsgebieden van de normale weergavemodus.

Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) geven aan of de verticale splitter moet vastklikken in een geminimaliseerde toestand wanneer het zij‑gebied voldoende klein wordt.

Eigenschap [getPreferSingleView](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) en [setPreferSingleView](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) geeft aan of de gebruiker de voorkeur geeft aan een enkel‑inhoudsgebied over het volledige venster in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie ervoor kiezen om één van de inhoudsgebieden in het volledige venster weer te geven.

Methoden [getVerticalBarState](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) geven de toestand aan waarin de horizontale of verticale splitter‑balk moet worden weergegeven. Een horizontale splitter‑balk scheidt de dia van het inhoudsgebied onder de dia, een verticale splitter‑balk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) en [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Methoden [getRestoredLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) en [getRestoredTop](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) bepalen de afmetingen van respectievelijk het boven‑ of zij‑dia‑gebied van de normale weergave, wanneer de waarde [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType#Restored) wordt toegepast op [getVerticalBarState](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) dienovereenkomstig.

## **Over het herstellen van NormalViewProperties**

Bepaalt de afmetingen van het dia‑gebied (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (niet geminimaliseerd of gemaximaliseerd).

Methode [getDimensionSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) geeft de grootte van het dia‑gebied aan (breedte wanneer een kind van restoredTop, hoogte wanneer een kind van restoredLeft).

Methode [getAutoAdjust](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) geeft aan of de grootte van het zij‑inhoudsgebied gecompenseerd moet worden voor de nieuwe grootte bij het wijzigen van de grootte van het venster dat de weergave bevat binnen de applicatie.

Een voorbeeld hieronder laat zien hoe u toegang krijgt tot de eigenschappen van [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) voor een presentatie.

```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Herstel de weergave‑eigenschappen van de presentatie
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Standaard zoomwaarde instellen**

{{% alert color="primary" %}} 

Aspose.Slides voor Node.js via Java ondersteunt nu het instellen van de standaard zoomwaarde voor een presentatie, zodat bij het openen van de presentatie de zoom al is ingesteld. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties) van een presentatie in te stellen. [getSlideViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) evenals [getNotesViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) kunnen programmatisch worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe de [View Properties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties) van een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) in [Aspose.Slides](/slides/nl/) kunnen worden ingesteld.

{{% /alert %}} 

Om de weergave‑eigenschappen in te stellen, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation).
1. Stel de [View Properties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties) in van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation).
1. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.  
   In het voorbeeld hieronder hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Instellen van de weergave‑eigenschappen van de presentatie
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwaarde in percentages voor dia‑weergave
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwaarde in percentages voor notitie‑weergave
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan ik verschillende weergave‑instellingen definiëren voor verschillende secties van een presentatie?**

[Weergave‑instellingen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getviewproperties/) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), niet per sectie, dus een enkele set parameters geldt voor het hele document wanneer het wordt geopend.

**Kan ik vooraf verschillende weergave‑staten definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en zijn gedeeld. Viewer‑applicaties kunnen rekening houden met gebruikersvoorkeuren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde View Properties zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getviewproperties/) worden opgeslagen op presentatieniveau, kunt u ze in een sjabloon opnemen en nieuwe documenten ervan maken met dezelfde initiële weergave‑configuratie.