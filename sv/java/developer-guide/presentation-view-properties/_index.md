---
title: Hämta och uppdatera presentationsvyeegenskaper i Java
linktitle: Vyeegenskaper
type: docs
weight: 80
url: /sv/java/presentation-view-properties/
keywords:
- vyeegenskaper
- normal vy
- dispositionsinnehåll
- dispositionsikoner
- fästa vertikal splitter
- enda vy
- stapelfältstatus
- dimensionsstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Upptäck Aspose.Slides för Java vyeegenskaper för att anpassa PPT-, PPTX- och ODP‑formatets bildspel—justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvy består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som gäller placeringen av de olika innehållsområdena. Denna information gör att applikationen kan spara vyns tillstånd till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) har lagts till för att ge åtkomst till normalvyegenskaper för en presentation. 

[INormalViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewRestoredProperties)‑gränssnitten och deras underklasser, samt [SplitterBarStateType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType)‑enum har lagts till.

## **Om INormalViewProperties**

Representerar normalvyegenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) anger om applikationen ska visa ikoner när dispositionen visas i något av innehållsområdena i normalvyläget.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) anger om den vertikala splittern ska fästa i ett minimerat tillstånd när sidoregionen är tillräckligt liten.

Egenskaperna [getPreferSingleView](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) och [setPreferSingleView](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) anger om användaren föredrar att se ett enda innehållsområde i fullskärm framför den standardiserade normalvyn med tre innehållsområden. Om aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) specificerar vilket tillstånd den horisontella respektive vertikala splittern ska visas i. En horisontell splitterseparator separerar bilden från innehållsområdet under bilden, medan en vertikal splitterseparator separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Maximized) och [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) och [getRestoredTop](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificerar storleken på den övre eller sidovisa bildregionen i normalvyn, när värdet [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Restored) tillämpas för [getVerticalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) på motsvarande sätt.

## **Om återställning av INormalViewProperties**

Anger storleken på bildregionen (bredd när den är ett barn till [getRestoredTop](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), höjd när den är ett barn till [getRestoredLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximerad).  

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specificerar storleken på bildregionen (bredd när den är ett barn till restoredTop, höjd när den är ett barn till restoredLeft).  

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) anger om storleken på sidoinnehållsområdet ska kompensera för den nya storleken när fönstret som innehåller vyn i applikationen ändras i storlek.  

Ett exempel ges nedan som visar hur du kan komma åt [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) egenskaper för en presentation.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Återställ vyeegenskaperna för presentationen
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ställ in standardzoomvärdet**

{{% alert color="primary" %}} 

Aspose.Slides för Java stöder nu att ställa in standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att ange [ViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) kan ställas in programmässigt. I detta avsnitt kommer vi med ett exempel att visa hur man ställer in [View Properties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) i [Aspose.Slides](/slides/sv/).

{{% /alert %}} 

För att ställa in vyegenskaperna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
2. Ställ in [View Properties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
3. Spara presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil. I exemplet nedan har vi ställt in zoomvärdet för bildvyn såväl som notvy.

```java
Presentation presentation = new Presentation();
try {
    // Inställer vyeegenskaperna för presentationen
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomvärde i procent för bildvyn
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomvärde i procent för notvyn 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan jag ange olika vyinställningar för olika sektioner i en presentation?**

Vyinställningarna definieras på presentationsnivå (Normalvyn/[Normal View](https://reference.aspose.com/slides/sv/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/sv/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), inte per sektion, så ett enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vylägen för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan ta hänsyn till användarpreferenser, men filen i sig innehåller endast en uppsättning vyegenskaper.

**Kan jag förbereda en mall med fördefinierade vyegenskaper så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom vyegenskaper lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.