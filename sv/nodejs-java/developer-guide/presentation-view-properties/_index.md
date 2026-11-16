---
title: Hämta och uppdatera presentationsvyegenskaper i JavaScript
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/nodejs-java/presentation-view-properties/
keywords:
- vyegenskaper
- normalläge
- dispositionsinnehåll
- dispositionsikoner
- snäppa vertikal splitter
- enkel vy
- stapeltillstånd
- dimensionsstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Använd Aspose.Slides för Node.js via Java för att konfigurera normallägets layout, bild- och notzoom, rutnätsavstånd och kommentarssynlighet i PowerPoint-presentationer."
---
## **Introduktion**

I PowerPoints normalläge visas bilden mellan en sidopanel för miniatyrer eller en disposition och en anteckningspanel nedanför. Aspose.Slides för Node.js via Java exponerar presentationens sparade redigeringsinställningar via [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties). Dessa inkluderar panelens layout, zoomnivåer, rutnätsavstånd och kommentarssynlighet.

## **Om NormalViewProperties**

Använd [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) för att komma åt klassen [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) kontrollerar om ikoner visas bredvid bildtitlar i dispositionen. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) låter sidopanelen fästa vid sitt minimerade läge när användaren minskar den. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) anger en preferens för att visa en panel i hela fönstret.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) styr avdelaren mellan sidopanelen och bilden. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) styr avdelaren ovanför anteckningspanelen. Båda accepterar ett [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/)‑värde av `Minimized`, `Maximized` eller `Restored`.

## **Om återställning av NormalViewProperties**

När en avdelare återställs, tillhandahåller [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) den sparade storleken på sidopanelen och [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) den sparade storleken på det övre bildområdet. Båda exponerar [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/). Dess [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize)‑metod accepterar en procentandel från 0 till 100, och [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) styr om editorn justerar storleken när fönstret ändras storlek.

Detta exempel uppdaterar en befintlig presentation. Det återställer den horisontella avdelaren, sätter storleken som returneras av [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) till 80 % med automatisk justering aktiverad, och maximerar den vertikala avdelaren. Det anropar också [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) för att visa ikoner i dispositionsvyn.

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

## **Ange standardzoomvärdet**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) och [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) lagrar oberoende zoominställningar för editorn. Dessa inställningar påverkar inte bilddimensioner, bildspelets uppspelning eller bildexportens upplösning.

Detta exempel öppnar en befintlig presentation och anropar [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) för att anpassa bilden till redigeringsfönstret. För notssidan inaktiverar det automatisk skalning och anropar [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) för att ställa in en fast zoom på 80 %.

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

## **Ange rutnätsavståndet**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) anger avståndet mellan redigeringsrutnätslinjer i hela presentationen. Den tar ett positivt värde i punkter, med 72 punkter per tum. Detta exempel skriver ut det aktuella avståndet i en befintlig presentation och sparar ett fjärdedelstums rutnät genom att sätta intervallet till 18 punkter.

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

Rutnätet upprepas med ett fast intervall. [Ritningsguider](/slides/sv/nodejs-java/drawing-guides/) markerar individuella horisontella eller vertikala positioner. Båda är redigeringshjälpmedel och visas endast i editörer som visar dem. Bildspel och export till PDF, bilder eller SVG utelämnar dem.

## **Visa eller dölja kommentarer när en presentation öppnas**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) lagrar en preferens som kompatibla editörer använder när de öppnar presentationen. För en befintlig presentation med kommentarer skriver detta exempel ut den aktuella inställningen och sparar en kopia med kommentarer dolda. Det anropar också [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) med [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) så att kopian öppnas i bildvyn.

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

Att dölja kommentarer bevarar deras text, författare, positioner, svar och statusar. För att ändra kommentarerna själva, se [Presentation Comments](/slides/sv/nodejs-java/presentation-comments/). Exportinställningar styr om kommentarer visas i PDF, HTML, bilder, anteckningar eller handouts.

## **Vanliga frågor**

**Varför är rutnätet dolt när jag öppnar presentationen igen?**

Presentationen sparar rutnätsintervallet. För att se rutnätet, aktivera rutnätsynlighet i editorn.

**Ändrar rensa ritningsguider rutnätsavståndet?**

Nej. Att lägga till, flytta eller rensa en guide lämnar rutnätsintervallet oförändrat.

**Kan olika avsnitt av en presentation ha olika vyinställningar?**

Nej. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) gäller för hela presentationen.

**Kan jag spara olika vyinställningar för olika användare?**

Filen lagrar ett enda set av vyegenskaper för alla. En editor kan också tillämpa en användares lokala preferenser.

**Kan jag spara vyinställningar i en mall?**

Ja. Presentationer som skapats från mallen ärver dess sparade vyinställningar.