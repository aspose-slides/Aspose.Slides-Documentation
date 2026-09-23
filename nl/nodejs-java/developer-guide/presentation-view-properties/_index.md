---
title: Presentatieweergave-eigenschappen ophalen en bijwerken in JavaScript
linktitle: Weergave-eigenschappen
type: docs
weight: 80
url: /nl/nodejs-java/presentation-view-properties/
keywords:
- weergave-eigenschappen
- normale weergave
- schetsinhoud
- schets-iconen
- verticale splitter vastzetten
- enkele weergave
- balk-status
- dimensiegrootte
- automatische aanpassing
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Node.js via Java-weergave-eigenschappen om PPT-, PPTX- en ODP-dia's aan te passen—lay-outs, zoomniveaus en weergave-instellingen te wijzigen."
---
## **Introductie**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zijinhoudsgebied en een onderinhoudsgebied. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavestatus op te slaan in het bestand, zodat bij het opnieuw openen de weergave zich in dezelfde staat bevindt als toen de presentatie voor het laatst werd opgeslagen.

Methode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie. 

[NormalViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewRestoredProperties) klasse en haar afstammelingen, [SplitterBarStateType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType) enum zijn toegevoegd.

## **Over NormalViewProperties**

Stelt normale weergave‑eigenschappen voor.

De methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) geven aan of de applicatie pictogrammen moet weergeven bij het tonen van overzichtsinhoud in een van de inhoudsgebieden van de normale weergavemodus.

De methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) geven aan of de verticale scheidingsbalk moet “snappen” naar een geminimaliseerde toestand wanneer het zijgebied voldoende klein is.

De eigenschap [getPreferSingleView](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) en [setPreferSingleView](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) geeft aan of de gebruiker de voorkeur geeft aan een enkel‑inhoudsgebied dat het volledige venster vult boven de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie ervoor kiezen één van de inhoudsgebieden over het gehele venster weer te geven.

De methoden [getVerticalBarState](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) geven de staat aan waarin de horizontale of verticale scheidingsbalk moet worden weergegeven. Een horizontale scheidingsbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale scheidingsbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) en [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

De methoden [getRestoredLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) en [getRestoredTop](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) geven de afmetingen op van respectievelijk het zij- of boven‑dia‑gebied van de normale weergave, wanneer de waarde [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType#Restored) wordt toegepast op [getVerticalBarState](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) overeenkomstig.

## **Over het herstellen van NormalViewProperties** 

Geeft de afmetingen van het dia‑gebied (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) van de normale weergave aan, wanneer het gebied een variabele herstelde grootte heeft (niet geminimaliseerd of gemaximaliseerd). 

Methode [getDimensionSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) geeft de grootte van het dia‑gebied aan (breedte wanneer een kind van restoredTop, hoogte wanneer een kind van restoredLeft).

Methode [getAutoAdjust](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) geeft aan of de grootte van het zij‑inhoudsgebied moet worden aangepast aan de nieuwe grootte bij het wijzigen van de venstergrootte waarin de weergave zich bevindt binnen de applicatie.

Een voorbeeld hieronder toont hoe u de eigenschappen van [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) voor een presentatie kunt benaderen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Herstel de weergave-eigenschappen van de presentatie
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Standaardzoomwaarde instellen**

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java ondersteunt nu het instellen van de standaard zoomwaarde voor een presentatie, zodat bij het openen van de presentatie de zoom al is ingesteld. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties) van een presentatie in te stellen. [getSlideViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) en [getNotesViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) kunnen programmatisch worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe de [View Properties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties) van [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) in Aspose.Slides kunnen worden ingesteld.

{{% /alert %}} 

Om de weergave‑eigenschappen in te stellen, volg de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) aan.
1. Stel de [View Properties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties) van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) in.
1. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand. In het voorbeeld hieronder hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Instellen van de weergave‑eigenschappen van de presentatie
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwaarde in percentages voor diaweergave
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwaarde in percentages voor notitie‑weergave
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rasterafstand instellen**

Gebruik [Presentation.getViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getViewProperties--) om de weergave‑instellingen voor de volledige presentatie te benaderen. De methoden [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) en [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) lezen of wijzigen het interval van het onderliggende bewerkingsraster. Deze instelling is van toepassing op de gehele presentatie, niet op een individuele dia. Rasterafstand wordt gespecificeerd in points, waarbij 72 points gelijk zijn aan één inch. Gebruik een positieve waarde, zoals vereist in de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, geeft de huidige rasterafstand weer, stelt een kwart‑inch‑interval in en slaat het resultaat op.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het raster verschilt van [drawing guides](/slides/nl/nodejs-java/drawing-guides/). Rasterafstand regelt een regelmatig interval, terwijl tekenrichtlijnen individuele horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of wissen van tekenrichtlijnen verandert de rasterafstand niet.

Zowel het raster als de tekenrichtlijnen zijn bewerkingshulpmiddelen. Ze worden niet gerenderd als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster weergeeft: de zichtbaarheid hangt ook af van de voorkeuren van de viewer of editor.

## **Opmerkingen weergeven of verbergen bij het openen van een presentatie**

Gebruik [Presentation.getViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getViewProperties--) om de weergave‑instellingen voor de volledige presentatie te benaderen. Gebruik [ViewProperties.getShowComments](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/#getShowComments--) en [ViewProperties.setShowComments](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-) om de opgeslagen voorkeur te lezen of te wijzigen of opmerkingen moeten worden weergegeven wanneer de presentatie wordt geopend in PowerPoint of een andere compatibele editor.

Deze instelling regelt alleen de opgeslagen weergavevoorkeur. Het voegt geen opmerkingen toe, verwijdert, bewerkt of lost ze op. Het verbergen van opmerkingen behoudt hun inhoud, auteurs, posities, antwoorden en statussen. Zie [Presentation Comments](/slides/nl/nodejs-java/presentation-comments/) voor bewerkingen die de opmerkingen zelf wijzigen.

Het volgende voorbeeld vereist een bestaande `comments.pptx` met opmerkingen. Het geeft de huidige zichtbaarheid weer, vraagt de opmerkingen te verbergen en slaat een nieuwe PPTX op zonder opmerkingen te verwijderen. Het gebruikt ook [ViewProperties.setLastView](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) met [ViewType.SlideView](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewtype/#SlideView) om de initiële bewerkingsweergave samen met de zichtbaarheid van opmerkingen te configureren.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Deze instelling bepaalt niet of opmerkingen worden meegenomen in exporten naar PDF, HTML, afbeelding, notities of hand‑outs. Configureer de relevante export‑specifieke opties afzonderlijk.

## **Veelgestelde vragen**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw heb geopend?**

Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheidsinstellingen van de editor.

**Verandert het wissen van tekenrichtlijnen de rasterafstand?**

Nee. Tekenrichtlijnen en rasterafstand zijn onafhankelijke instellingen. Het wissen van richtlijnen laat het opgeslagen rasterinterval onveranderd.

**Kan ik verschillende weergave‑instellingen instellen voor verschillende secties van een presentatie?**

[View settings](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getviewproperties/) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), niet per sectie, dus één set parameters is van toepassing op het volledige document wanneer het wordt geopend.

**Kan ik vooraf verschillende weergave‑toestanden definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en gedeeld. Viewer‑applicaties kunnen gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde View Properties zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getviewproperties/) op presentatieniveau worden opgeslagen, kun je ze in een sjabloon opnemen en nieuwe documenten vanuit dat sjabloon maken met dezelfde initiële weergave‑configuratie.