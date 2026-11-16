---
title: Presentatie‑weergave‑eigenschappen ophalen en bijwerken in JavaScript
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/nodejs-java/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- structuurinhoud
- structuur‑pictogrammen
- verticaal splitter vastklikken
- enkele weergave
- balkstatus
- dimensiegrootte
- automatisch aanpassen
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Gebruik Aspose.Slides for Node.js via Java om de indeling van de normale weergave, de zoom voor dia's en notities, de rasterafstand en de zichtbaarheid van opmerkingen in PowerPoint‑presentaties te configureren."
---
## **Introductie**

In de normale weergave van PowerPoint, verschijnt de dia tussen een zijpaneel voor miniaturen of een structuur en een notitiepaneel hieronder. Aspose.Slides for Node.js via Java maakt de opgeslagen bewerkingsvoorkeuren van de presentatie beschikbaar via [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties). Deze omvatten de paneelindeling, zoomniveaus, rasterafstand en zichtbaarheid van opmerkingen.

## **Over NormalViewProperties**

Gebruik [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) om toegang te krijgen tot de klasse [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) bepaalt of er pictogrammen naast dia‑titels worden weergegeven in de structuur. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) laat het zijpaneel naar de geminimaliseerde toestand snapen wanneer de gebruiker het verkleint. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) geeft een voorkeur aan om één paneel in het volledige venster weer te geven.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) regelt de scheidingslijn tussen het zijpaneel en de dia. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) regelt de scheidingslijn boven het notitiepaneel. Beide accepteren een waarde van het type [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized`, of `Restored`.

## **Over het herstellen van NormalViewProperties**

Wanneer een scheidingslijn wordt hersteld, geeft [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) de opgeslagen grootte van het zijpaneel terug en geeft [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) de opgeslagen grootte van het bovenste diapaneel terug. Beide onthullen [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/). De methode [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) accepteert een percentage van 0 tot 100, en [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) bepaalt of de editor de grootte aanpast wanneer het venster wordt gewijzigd.

Dit voorbeeld werkt een bestaande presentatie bij. Het herstelt de horizontale scheidingslijn, stelt de grootte die door [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) wordt geretourneerd in op 80% met automatische aanpassing ingeschakeld, en maximaliseert de verticale scheidingslijn. Het roept ook [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) aan om pictogrammen weer te geven in de structuurweergave.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel de standaard zoomwaarde in**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) en [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) slaan onafhankelijke zoominstellingen op voor de editor. Deze instellingen hebben geen invloed op de afmetingen van de dia, de weergave van de diavoorstelling, of de resolutie bij export van afbeeldingen.

Dit voorbeeld opent een bestaande presentatie en roept [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) aan om de dia passend te maken aan het bewerkingsvenster. Voor de notitiepagina schakelt het automatische schaalvergroting uit en roept [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) aan om een vaste zoom van 80% in te stellen.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel de rasterafstand in**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) bepaalt de afstand tussen bewerkingsrasterlijnen in de gehele presentatie. Het neemt een positieve waarde in points, met 72 points per inch. Dit voorbeeld geeft de huidige afstand weer in een bestaande presentatie en slaat een raster van een kwart‑inch op door het interval in te stellen op 18 points.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het raster herhaalt zich met een vast interval. [Drawing guides](/slides/nl/nodejs-java/drawing-guides/) markeren individuele horizontale of verticale posities. Beide zijn hulpmiddelen bij het bewerken en verschijnen alleen in editors die ze weergeven. Diavoorstellingen en export naar PDF, afbeeldingen of SVG laten ze weg.

## **Toon of verberg opmerkingen bij het openen van een presentatie**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) slaat een voorkeur op die compatibele editors gebruiken bij het openen van de presentatie. Voor een bestaande presentatie met opmerkingen geeft dit voorbeeld de huidige instelling weer en slaat een kopie op met verborgen opmerkingen. Het roept ook [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) aan met [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) zodat de kopie wordt geopend in de diaweergave.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het verbergen van opmerkingen behoudt hun tekst, auteurs, posities, antwoorden en statussen. Om de opmerkingen zelf te wijzigen, zie [Presentation Comments](/slides/nl/nodejs-java/presentation-comments/). Exportinstellingen bepalen of opmerkingen verschijnen in PDF, HTML, afbeeldingen, notities of hand‑outs.

## **FAQ**

**Waarom is het raster verborgen wanneer ik de presentatie opnieuw open?**

De presentatie slaat het rasterinterval op. Om het raster te zien, schakel de rasterzichtbaarheid in de editor in.

**Verandert het wissen van tekenrichtlijnen de rasterafstand?**

Nee. Het toevoegen, verplaatsen of wissen van een richtlijn laat het rasterinterval ongewijzigd.

**Kunnen verschillende secties van een presentatie verschillende weergave‑instellingen hebben?**

Nee. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) geldt voor de gehele presentatie.

**Kan ik verschillende weergave‑instellingen opslaan voor verschillende gebruikers?**

Het bestand slaat één set weergave‑eigenschappen op voor iedereen. Een editor kan ook de lokale voorkeuren van een gebruiker toepassen.

**Kan ik weergave‑instellingen opslaan in een sjabloon?**

Ja. Presentaties die op basis van het sjabloon worden gemaakt, erven de daarin opgeslagen weergave‑instellingen.