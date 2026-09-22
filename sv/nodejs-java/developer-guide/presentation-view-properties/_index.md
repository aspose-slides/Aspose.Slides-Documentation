---
title: Hämta och uppdatera presentationsvyegenskaper i JavaScript
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/nodejs-java/presentation-view-properties/
keywords:
- vyegenskaper
- normal vy
- dispositionsinnehåll
- dispositionsikoner
- fäst vertikal delare
- enda vy
- listtillstånd
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck Aspose.Slides för Node.js via Java vyegenskaper för att anpassa format PPT, PPTX och ODP‑bilder—justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som gäller placeringen av de olika innehållsområdena. Denna information gör att applikationen kan spara sitt visningsläge till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) har lagts till för att ge åtkomst till normalvyegenskaperna för en presentation.

[NormalViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewRestoredProperties) klass och dess underklasser, samt [SplitterBarStateType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType) enum har lagts till.

## **Om NormalViewProperties**

Representerar normalvyegenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) anger om applikationen ska visa ikoner när dispositionens innehåll visas i någon av innehållsområdena i normalvyläget.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) anger om den vertikala delaren ska fästas i ett minimerat tillstånd när sidoregionen är tillräckligt liten.

Egenskapen [getPreferSingleView](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) och [setPreferSingleView](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) anger om användaren föredrar att se ett enda innehållsområde i hela fönstret istället för den vanliga normalvyn med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) anger vilket tillstånd den horisontella eller vertikala delningslisten ska visas i. En horisontell delningslist separerar bilden från innehållsområdet under bilden, en vertikal delningslist separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) och [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) och [getRestoredTop](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) specificerar storleken på den övre eller sidogående slide‑regionen i normalvyn, när värdet [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType#Restored) har tillämpats för [getVerticalBarState](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) respektive.

## **Om återställning av NormalViewProperties**

Anger storleken på slide‑regionen (bredd när den är ett barn till [getRestoredTop](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), höjd när den är ett barn till [getRestoredLeft](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximerad).

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) specificerar storleken på slide‑regionen (bredd när den är ett barn till restoredTop, höjd när den är ett barn till restoredLeft).

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) anger om storleken på sidoinnehållsområdet ska justeras för den nya storleken när fönstret som innehåller vyn i applikationen ändras storlek.

Ett exempel ges nedan som visar hur du kan komma åt [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) egenskaperna för en presentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Återställ vyegenskaperna för presentationen
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```
## **Ställ in standard zoomvärde**

{{% alert color="info" %}} 

Aspose.Slides för Node.js via Java stödjer nu att ange standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att ställa in [ViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) kan sättas programatiskt. I detta avsnitt kommer vi med ett exempel att visa hur man ställer in [View Properties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) i Aspose.Slides.

{{% /alert %}} 

För att ställa in vyegenskaperna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
2. Ställ in [View Properties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
3. Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/) fil.
   I exemplet nedan har vi ställt in zoomvärdet för bildvyn såväl som för notvyn.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Anger vyegenskaperna för presentationen
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomvärde i procent för bildvyn
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomvärde i procent för notvyn
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Ställ in rutnätets avstånd**

Använd [Presentation.getViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getViewProperties--) för att komma åt vyinställningarna för hela presentationen. Metoderna [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) och [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller för hela presentationen, inte för en enskild bild. Rutnätsavstånd anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde enligt API‑dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut dess aktuella rutnätsavstånd, ställer in ett kvart‑tum intervall och sparar resultatet.

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

Rutnätet skiljer sig från [ritningsguider](/slides/sv/nodejs-java/drawing-guides/). Rutnätsavstånd styr ett regelbundet intervall, medan ritningsguider är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritningsguider förändrar inte rutnätsavståndet.

Både rutnätet och ritningsguider är hjälpmedel för redigering. De renderas inte som bildinnehåll i PDF, bilder, SVG eller ett bildspel. Att lagra rutnätsavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror också på visnings‑ eller redigerarens preferenser.

## **FAQ**

**Varför är rutnätet inte synligt efter att jag har öppnat presentationen igen?**

Filen lagrar rutnätsavståndet, men redigeraren bestämmer om rutnätet visas. Kontrollera redigerarens inställningar för rutnätsynlighet.

**Ändrar rensning av ritningsguider rutnätsavståndet?**

Nej. Ritningsguider och rutnätsavstånd är oberoende inställningar. Att rensa guider lämnar det lagrade rutnätsintervallet oförändrat.

**Kan jag ställa in olika vyinställningar för olika sektioner i en presentation?**

[Vyinställningar](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getviewproperties/) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), inte per sektion, så ett enda set av parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vytilstånd för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan ta hänsyn till användarpreferenser, men själva filen innehåller endast ett set av vyegenskaper.

**Kan jag skapa en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getviewproperties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.