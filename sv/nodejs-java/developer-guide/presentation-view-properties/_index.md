---
title: Hämta och uppdatera presentationsvy‑egenskaper i JavaScript
linktitle: Vy‑egenskaper
type: docs
weight: 80
url: /sv/nodejs-java/presentation-view-properties/
keywords:
- vy‑egenskaper
- normal vy
- dispositions‑innehåll
- dispositionsikoner
- fäst vertikal delare
- enskild vy
- stapeltillstånd
- dimensionens storlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck Aspose.Slides för Node.js via Java vy‑egenskaper för att anpassa PPT-, PPTX- och ODP‑format; justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Den normala vyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som gäller placeringen av de olika innehållsområdena. Denna information gör det möjligt för applikationen att spara sitt visningsläge till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) har lagts till för att ge åtkomst till normal vy‑egenskaper för presentationen.  

[NormalViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewRestoredProperties) klass och dess avledda klasser, [SplitterBarStateType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType)‑enum har lagts till.

## **Om NormalViewProperties**

Representerar normal vy‑egenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) anger om applikationen ska visa ikoner när disposition av innehåll visas i något av innehållsområdena i normal vy‑läge.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) anger om den vertikala delaren ska fästa sig i ett minimerat tillstånd när sidregionen är tillräckligt liten.

Egenskapen [getPreferSingleView](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) och [setPreferSingleView](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) anger om användaren föredrar att se ett fullt fönster med ett enda innehållsområde istället för standard‑normalvyn med tre innehållsområden. Om detta är aktiverat kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) anger i vilket tillstånd den horisontella respektive vertikala delaren ska visas. En horisontell delare separerar bilden från innehållsområdet under bilden, en vertikal delare separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) och [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) och [getRestoredTop](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) anger storleken på den övre eller sidogallret i normalvyn när värdet [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType#Restored) tillämpas på [getVerticalBarState](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) därefter.

## **Om återställning av NormalViewProperties** 

Anger storleken på bildregionen (bredd när den är ett barn till [getRestoredTop](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), höjd när den är ett barn till [getRestoredLeft](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximerad).  

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) anger storleken på bildregionen (bredd när den är ett barn till restoredTop, höjd när den är ett barn till restoredLeft).

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) anger om storleken på sidoinnehållsområdet ska kompensera för den nya storleken när fönstret som innehåller vyn i applikationen ändras storlek.

Ett exempel nedan visar hur du kan komma åt [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--)‑egenskaper för en presentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Återställ vy‑egenskaperna för presentationen
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ange standardzoomvärde**

{{% alert color="info" %}} 

Aspose.Slides för Node.js via Java stöder nu att ange standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att ange [ViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) kan ställas in programmässigt. I detta avsnitt ser vi med ett exempel hur man ställer in [View Properties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) i Aspose.Slides.

{{% /alert %}} 

För att ange vy‑egenskaperna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
1. Ange [View Properties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
1. Spara presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)-fil.  
   I exemplet nedan har vi ställt in zoomvärdet för både bildvyn och anteckningsvyn.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Ställer in vy‑egenskaperna för presentationen
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomvärde i procent för bildvyn
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomvärde i procent för anteckningsvyn
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in rutnätsavståndet**

Använd [Presentation.getViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getViewProperties--) för att komma åt presentationsomfattande vy‑inställningar. Metoderna [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) och [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller hela presentationen, inte en enskild bild. Rutnätsavståndet anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde enligt API‑dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut det aktuella rutnätsavståndet, sätter ett kvart‑tum‑intervall och sparar resultatet.

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

Rutnätet skiljer sig från [drawing guides](/slides/sv/nodejs-java/drawing-guides/). Rutnätsavstånd styr ett regelbundet intervall, medan ritguider är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritguider ändrar inte rutnätsavståndet.

Både rutnätet och ritguiderna är redigeringshjälpmedel. De renderas inte som bildinnehåll i PDF, bilder, SVG eller ett bildspelsläge. Att lagra rutnätsavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror också på visarens eller redigerarens inställningar.

## **Visa eller dölja kommentarer när en presentation öppnas**

Använd [Presentation.getViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getViewProperties--) för att komma åt presentationsomfattande vy‑inställningar. Använd [ViewProperties.getShowComments](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/#getShowComments--) och [ViewProperties.setShowComments](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-) för att läsa eller ändra den lagrade preferensen för om kommentarer ska visas när presentationen öppnas i PowerPoint eller en annan kompatibel redigerare.

Denna inställning styr endast den lagrade visningspreferensen. Den lägger inte till, tar bort, redigerar eller löser kommentarer. Att dölja kommentarer bevarar deras innehåll, författare, positioner, svar och statusar. Se [Presentation Comments](/slides/sv/nodejs-java/presentation-comments/) för operationer som ändrar kommentarerna själva.

Exemplet nedan kräver en befintlig `comments.pptx` som innehåller kommentarer. Det skriver ut den aktuella synlighetsinställningen, begär att kommentarer ska döljas och sparar en ny PPTX utan att ta bort några kommentarer. Det använder också [ViewProperties.setLastView](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) med [ViewType.SlideView](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewtype/#SlideView) för att konfigurera den initiala redigeringsvyn tillsammans med kommentar‑synlighet.

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

Denna inställning avgör inte om kommentarer inkluderas i PDF-, HTML-, bild‑, antecknings‑ eller utskrifts‑exporter. Konfigurera de export‑specifika alternativen separat.

## **FAQ**

**Varför är rutnätet inte synligt när jag öppnar presentationen igen?**

Filen lagrar rutnätsavståndet, men redigeraren styr om rutnätet visas. Kontrollera redigerarens inställningar för rutnäts‑synlighet.

**Ändrar rensning av ritguider rutnätsavståndet?**

Nej. Ritguider och rutnätsavstånd är oberoende inställningar. Att rensa guider lämnar det lagrade rutnätsintervallet oförändrat.

**Kan jag ange olika vy‑inställningar för olika sektioner i en presentation?**

[Vy‑inställningar](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getviewproperties/) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), inte per sektion, så ett enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vy‑tillstånd för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan ta hänsyn till användarpreferenser, men filen innehåller endast en uppsättning vy‑egenskaper.

**Kan jag skapa en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getviewproperties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vy‑konfiguration.