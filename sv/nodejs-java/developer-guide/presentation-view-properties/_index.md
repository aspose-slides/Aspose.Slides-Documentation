---
title: Hämta och uppdatera presentationsvyegenskaper i JavaScript
linktitle: Vyeegenskaper
type: docs
weight: 80
url: /sv/nodejs-java/presentation-view-properties/
keywords:
- vyeegenskaper
- normalvy
- konturinnehåll
- konturikoner
- fäst vertikal delare
- enkelvy
- barstatus
- dimensionsstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck Aspose.Slides för Node.js via Java vyegenskaper för att anpassa PPT-, PPTX- och ODP-formatens bilder — justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som gäller placeringen av de olika innehållsområdena. Denna information gör att applikationen kan spara vyns tillstånd till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) har lagts till för att ge åtkomst till normalvyns egenskaper för en presentation.

Klasserna [NormalViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewRestoredProperties) och deras avkommor, samt enumet [SplitterBarStateType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType) har lagts till.

## **Om NormalViewProperties**

Representerar normalvyns egenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) anger om applikationen ska visa ikoner när konturens innehåll visas i något av innehållsområdena i normalvyläget.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) anger om den vertikala splittern ska låsas till ett minimerat tillstånd när sidoregionen är tillräckligt liten.

Egenskapen [getPreferSingleView](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) och [setPreferSingleView](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) anger om användaren föredrar att se ett enskilt innehållsområde i hela fönstret istället för den vanliga normalvyn med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) specificerar vilket tillstånd den horisontella respektive vertikala splittringsbaren ska visas i. En horisontell splittringsbar separerar bilden från innehållsområdet under bilden, en vertikal splittringsbar separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) och [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) och [getRestoredTop](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) specificerar storleken på det övre eller sidogränssnittet i normalvyn, när värdet [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SplitterBarStateType#Restored) har tillämpats för [getVerticalBarState](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) respektive [getHorizontalBarState](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) .

## **Om återställning av NormalViewProperties**

Anger storleken på bildområdet (bredd när det är ett underobjekt till [getRestoredTop](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), höjd när det är ett underobjekt till [getRestoredLeft](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) i normalvyn, när området har en variabel återställd storlek (varken minimerat eller maximerat).

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) specificerar storleken på bildområdet (bredd när det är ett underobjekt till restoredTop, höjd när det är ett underobjekt till restoredLeft).

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) anger om storleken på sidoinnehållsområdet ska anpassas till den nya storleken vid ändring av fönstrets storlek som innehåller vyn i applikationen.

Ett exempel ges nedan som visar hur du kan få åtkomst till egenskaperna för [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) för en presentation.

```javascript

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

## **Ange standardzoomvärde**

{{% alert color="primary" %}} 

Aspose.Slides för Node.js via Java stöder nu att ange standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att sätta [ViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) kan ställas in programatiskt. I det här avsnittet kommer vi med ett exempel att visa hur man sätter [View Properties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) i [Aspose.Slides](/slides/sv/).

{{% /alert %}} 

För att ställa in vyinställningarna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
1. Ställ in [View Properties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
1. Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)-fil.
   I exemplet nedan har vi ställt in zoomvärdet för bildvyn såväl som notvyn.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Inställer vyegenskaperna för presentationen
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomvärde i procent för bildvyn
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomvärde i procent för notvyn
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan jag ange olika vyinställningar för olika avsnitt i en presentation?**

[View settings](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getviewproperties/) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), inte per avsnitt, så ett enda set av parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vytilstånd för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan ta hänsyn till användarens preferenser, men filen själv innehåller endast ett set av vyegenskaper.

**Kan jag förbereda en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getviewproperties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.