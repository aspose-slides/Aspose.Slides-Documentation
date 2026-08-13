---
title: Hämta och uppdatera presentationsvyegenskaper i Java
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/java/presentation-view-properties/
keywords:
- vyegenskaper
- normalvy
- dispositionsinnehåll
- dispositionsikoner
- snäpp vertikal splitter
- enkel vy
- fältstatus
- dimensionsstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Upptäck vyegenskaperna i Aspose.Slides för Java för att anpassa PPT-, PPTX- och ODP‑formatens bilder—justera layout, zoomnivåer och displayinställningar."
---
## **Introduktion**

Normalläget består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett nedre innehållsområde. Egenskaper som rör placeringen av de olika innehållsområdena. Denna information gör att applikationen kan spara sitt visningsläge till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) har lagts till för att ge åtkomst till normalvyns egenskaper för en presentation. 

[INormalViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewRestoredProperties) gränssnitt och dess avkomlingar, [SplitterBarStateType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType)‑enum har lagts till.

## **Om INormalViewProperties**

Representerar normalvyns egenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) anger om applikationen ska visa ikoner när dispositionen visas i något av innehållsområdena i normalvyläget.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) anger om den vertikala splittern ska snäppas till ett minimerat tillstånd när sidoregionen är tillräckligt liten.

Egenskapen [getPreferSingleView](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) och [setPreferSingleView](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) anger om användaren föredrar att se ett enda innehållsområde som fyller hela fönstret istället för den standardmässiga normalvyn med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) anger det tillstånd som den horisontella eller vertikala splittern ska visas i. En horisontell splitter skiljer bilden från innehållsområdet under bilden, en vertikal splitter skiljer bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Maximized) och [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) och [getRestoredTop](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificerar storleken på den övre eller sidogestaltade bilden i normalvyn när värdet [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Restored) har tillämpats för [getVerticalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) enligt.

## **Om återställning av INormalViewProperties**

Anger storleken på bildområdet (bredd när det är ett underordnat element till [getRestoredTop](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), höjd när det är ett underordnat element till [getRestoredLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) i normalvyn, när området har en variabel återställd storlek (varken minimerad eller maximerad). 

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specificerar storleken på bildområdet (bredd när det är ett underordnat element till restoredTop, höjd när det är ett underordnat element till restoredLeft).

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) anger om storleken på sidoinnehållsområdet ska kompensera för den nya storleken när fönstret som innehåller vyn i applikationen ändras i storlek.

Ett exempel ges nedan som visar hur du kan komma åt [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) egenskaper för en presentation.

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

Aspose.Slides för Java stöder nu att sätta standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att ställa in [ViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) kan sättas programatiskt. I detta avsnitt kommer vi med ett exempel att visa hur man sätter [View Properties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) i [Aspose.Slides](/slides/sv/).

{{% /alert %}} 

För att ställa in vyegenskaperna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
1. Ange [View Properties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
1. Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.
   I exemplet nedan har vi satt zoomvärdet för både bildvyn och notevyn.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Ställer in vyegenskaperna för presentationen
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomvärde i procent för bildvyn
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomvärde i procent för notervyn 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Kan jag ställa in olika vyinställningar för olika sektioner i en presentation?

[View settings](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getViewProperties--) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/sv/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), inte per sektion, så ett enda parameteruppsättning gäller för hela dokumentet när det öppnas.

### Kan jag fördefiniera olika vytilstånd för olika användare?

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan respektera användarpreferenser, men själva filen innehåller endast ett set av vyegenskaper.

### Kan jag förbereda en mall med fördefinierade vyegenskaper så att nya presentationer öppnas på samma sätt?

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getViewProperties--) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.