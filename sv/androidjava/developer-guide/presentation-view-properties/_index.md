---
title: Hämta och uppdatera presentationsvyegenskaper på Android
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/androidjava/presentation-view-properties/
keywords:
- vyegenskaper
- normal vy
- outline‑innehåll
- outline‑ikoner
- snäppa vertikal splitter
- ensamvy
- stapelstatus
- dimensionens storlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck Aspose.Slides för Android via Java vyegenskaper för att anpassa format PPT, PPTX och ODP‑bilder—justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som gäller placeringen av de olika innehållsområdena. Denna information gör att applikationen kan spara vyns tillstånd till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) har lagts till för att ge åtkomst till normalvyns egenskaper för presentationen.  

[INormalViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewRestoredProperties) och deras underordnade, enum [SplitterBarStateType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType) har lagts till.

## **Om INormalViewProperties**

Representerar normalvyns egenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) specificerar om applikationen ska visa ikoner när outline‑innehåll visas i något av innehållsområdena i normalvyläget.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) specificerar om den vertikala splittern ska hakas fast i ett minimerat tillstånd när sidoregionen är tillräckligt liten.

Egenskapen [getPreferSingleView](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) och [setPreferSingleView](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) specificerar om användaren föredrar att se ett enskilt innehållsområde i helskärm över den standardmässiga normalvyn med tre innehållsområden. Om aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) specificerar i vilket tillstånd den horisontella eller vertikala splittern bör visas. En horisontell splittern separerar bilden från innehållsområdet under bilden, en vertikal splittern separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) och [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) och [getRestoredTop](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificerar storleken på det övre eller sidoläggningsområdet i normalvyn, när värdet [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Restored) har tillämpats för [getVerticalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) respektive [getHorizontalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) därefter.

## **Om återställning av INormalViewProperties**

Specificerar storleken på bildregionen (bredd när den är barn till [getRestoredTop](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), höjd när den är barn till [getRestoredLeft](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximiserad).

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specificerar storleken på bildregionen (bredd när den är barn till restoredTop, höjd när den är barn till restoredLeft).

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) specificerar om storleken på sidoinnehållsområdet ska kompensera för den nya storleken när fönstret som innehåller vyn i applikationen ändras storlek.

Ett exempel visas nedan som visar hur du kan komma åt egenskaperna [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) för en presentation.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Återställ vyegenskaperna för presentationen
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ställ in standardzoomvärdet**

{{% alert color="info" %}} 

Aspose.Slides för Android via Java stödjer nu att ange standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att ställa in [ViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) kan sättas programatiskt. I detta ämne kommer vi med ett exempel att visa hur man sätter View Properties för Presentation i [Aspose.Slides](/slides/sv/).

{{% /alert %}} 

För att ställa in vyegenskaperna. Följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
1. Ställ in [View Properties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
1. Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.  
   I exemplet nedan har vi satt zoomvärdet för bildvyn samt för anteckningsvyn.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Ställer in vyegenskaperna för presentationen
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomvärde i procent för bildvyn
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomvärde i procent för anteckningsvyn 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Kan jag ställa in olika vyinställningar för olika avsnitt i en presentation?

[View settings](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getViewProperties--) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), inte per avsnitt, så ett enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

### Kan jag fördefiniera olika vy‑tillstånd för olika användare?

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan ta hänsyn till användarpreferenser, men filen innehåller bara en uppsättning vy‑egenskaper.

### Kan jag förbereda en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?

Ja. Eftersom view properties lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.