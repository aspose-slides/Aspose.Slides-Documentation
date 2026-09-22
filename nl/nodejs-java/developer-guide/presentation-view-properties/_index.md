---
title: Ophalen en bijwerken van presentatieweergave‑eigenschappen in JavaScript
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/nodejs-java/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- outline‑inhoud
- outline‑iconen
- verticale splitter vastklikken
- enkele weergave
- balktoestand
- dimensiegrootte
- automatisch aanpassen
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Node.js via Java weergave‑eigenschappen om PPT-, PPTX- en ODP‑presentaties aan te passen — lay‑out, zoomniveaus en weergave‑instellingen te wijzigen."
---
## **Inleiding**

De normale weergave bestaat uit drie inhoudsregio's: de dia zelf, een zij‑inhoudsregio en een onder‑inhoudsregio. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsregio's. Deze informatie stelt de applicatie in staat om de weergavetoestand op te slaan in het bestand, zodat bij het opnieuw openen de weergave zich in dezelfde staat bevindt als toen de presentatie voor het laatst werd opgeslagen.

Methode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie.

[NormalViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewRestoredProperties) klasse en haar afstammelingen, [SplitterBarStateType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType) enum zijn toegevoegd.

## **Over NormalViewProperties**

Stelt de normale weergave‑eigenschappen voor.

Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) geven aan of de applicatie pictogrammen moet tonen bij het weergeven van de outline‑inhoud in een van de inhoudsregio's van de normale weergavemodus.

Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) geven aan of de verticale splitter moet vastklikken in een geminimaliseerde toestand wanneer de zij‑regio voldoende klein is.

Eigenschap [getPreferSingleView](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) en [setPreferSingleView](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) geven aan of de gebruiker de voorkeur geeft aan één enkel‑inhoudsgebied over het volledige venster boven de standaard normale weergave met drie inhoudsregio's. Indien ingeschakeld, kan de applicatie ervoor kiezen om een van de inhoudsregio's over het gehele venster weer te geven.

Methoden [getVerticalBarState](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) geven de toestand aan waarin de horizontale of verticale splitterbalk moet worden weergegeven. Een horizontale splitterbalk scheidt de dia van de inhoudsregio onder de dia, een verticale splitterbalk scheidt de dia van de zij‑inhoudsregio. Mogelijke waarden zijn: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) en [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Methoden [getRestoredLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) en [getRestoredTop](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) geven de grootte aan van respectievelijk de linkse of bovenste dia‑regio van de normale weergave, wanneer de waarde [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SplitterBarStateType#Restored) is toegepast op [getVerticalBarState](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) overeenkomstig.

## **Over het herstellen van NormalViewProperties**

Bepaalt de grootte van de dia‑regio (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) van de normale weergave, wanneer de regio een variabele herstelde grootte heeft (niet geminimaliseerd of gemaximaliseerd).

Methode [getDimensionSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) geeft de grootte van de dia‑regio aan (breedte wanneer een kind van restoredTop, hoogte wanneer een kind van restoredLeft).

Methode [getAutoAdjust](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) geeft aan of de grootte van de zij‑inhoudsregio moet worden aangepast aan de nieuwe grootte bij het wijzigen van de grootte van het venster dat de weergave binnen de applicatie bevat.

Een voorbeeld hieronder toont hoe u de eigenschappen van [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) voor een presentatie kunt benaderen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" %}} 

Aspose.Slides voor Node.js via Java ondersteunt nu het instellen van de standaard zoomwaarde voor een presentatie, zodat wanneer de presentatie wordt geopend de zoom reeds is ingesteld. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties) van een presentatie te configureren. [getSlideViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) en [getNotesViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) kunnen programmatically worden ingesteld. In dit onderwerp laten we aan de hand van een voorbeeld zien hoe de [View Properties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties) van [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) in Aspose.Slides kunnen worden ingesteld.

{{% /alert %}} 

Om de weergave‑eigenschappen in te stellen, volg de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) aan.  
1. Stel de [View Properties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ViewProperties) van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) in.  
1. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.  
   In het onderstaande voorbeeld hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Instellen van de weergave-eigenschappen van de presentatie
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomwaarde in procenten voor dia-weergave
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomwaarde in procenten voor notitie-weergave
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rasterafstand instellen**

Gebruik [Presentation.getViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getViewProperties--) om de weergave‑instellingen voor de hele presentatie te benaderen. De methoden [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) en [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) lezen of wijzigen het interval van het onderliggende bewerkingsraster. Deze instelling is van toepassing op de volledige presentatie, niet op een individuele dia. Rasterafstand wordt gespecificeerd in punten, waarbij 72 punten gelijk staan aan één inch. Gebruik een positieve waarde, zoals vereist door de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, geeft de huidige rasterafstand weer, stelt een kwart‑inch interval in en slaat het resultaat op.

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

Het raster verschilt van [drawing guides](/slides/nl/nodejs-java/drawing-guides/). Rasterafstand regelt een regelmatig interval, terwijl tekengidsen afzonderlijk gepositioneerde horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of wissen van tekengidsen verandert de rasterafstand niet.

Zowel het raster als tekengidsen zijn hulpmiddelen bij het bewerken. Ze worden niet weergegeven als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster toont: de zichtbaarheid hangt ook af van de voorkeuren van de viewer of editor.

## **Veelgestelde vragen**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw heb geopend?**  
Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheidsinstellingen van de editor.

**Verandert het wissen van tekengidsen de rasterafstand?**  
Nee. Tekengidsen en rasterafstand zijn onafhankelijke instellingen. Het wissen van gidsen laat het opgeslagen rasterinterval ongewijzigd.

**Kan ik verschillende weergave‑instellingen instellen voor verschillende secties van een presentatie?**  
[Weergave‑instellingen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getviewproperties/) worden gedefinieerd op presentatieniveau ([Normale weergave](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Dia‑weergave](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), niet per sectie, zodat één set parameters van toepassing is op het volledige document bij het openen.

**Kan ik verschillende weergave‑toestanden vooraf definiëren voor verschillende gebruikers?**  
Nee. De instellingen worden in het bestand opgeslagen en zijn gedeeld. Viewer‑applicaties kunnen rekening houden met gebruikersvoorkeuren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde weergave‑eigenschappen zodat nieuwe presentaties op dezelfde manier openen?**  
Ja. Omdat [weergave‑eigenschappen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getviewproperties/) op presentatieniveau worden opgeslagen, kunt u ze in een sjabloon opnemen en nieuwe documenten ervan maken met dezelfde initiële weergaveconfiguratie.