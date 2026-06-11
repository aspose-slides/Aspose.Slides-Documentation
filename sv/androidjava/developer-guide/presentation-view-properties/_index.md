---
title: "Hämta och uppdatera presentationsvisningsinställningar på Android"
linktitle: "Visningsegenskaper"
type: docs
weight: 80
url: /sv/androidjava/presentation-view-properties/
keywords:
- visningsegenskaper
- normalvy
- dispositionsinnehåll
- dispositionsikoner
- snappa vertikal delare
- enkel vy
- stapelstillstånd
- dimensionsstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck Aspose.Slides för Android via Java visningsegenskaper för att anpassa PPT-, PPTX- och ODP-formatens bilder — justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsområden: själva bildspelet, ett sidoinnehållsområde och ett nederst innehållsområde. Egenskaper som gäller positioneringen av de olika innehållsområdena. Denna information gör att applikationen kan spara sitt visningsläge i filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) har lagts till för att ge åtkomst till normalvyns egenskaper för presentationen.  

Gränssnitten [INormalViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewRestoredProperties) och deras avkommäsor, samt enumet [SplitterBarStateType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType) har lagts till.

## **Om INormalViewProperties**

Representerar normalvyns egenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) specificerar om applikationen ska visa ikoner vid visning av dispositionsinnehåll i något av innehållsområdena i normalvy.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) specificerar om den vertikala delaren ska låsas i ett minimerat läge när sidoregionen är tillräckligt liten.

Egenskapen [getPreferSingleView](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) och [setPreferSingleView](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) specificerar om användaren föredrar att se ett enskilt innehållsområde i helfönstret istället för standardnormalvyn med tre innehållsområden. Om aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) anger vilket tillstånd den horisontella respektive vertikala delarbalken ska visas i. En horisontell delarbalk separerar bilden från innehållsområdet under bilden, en vertikal delarbalk separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) och [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) och [getRestoredTop](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificerar storleken på den övre eller sidogrenen av normalvyn när värdet [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Restored) tillämpas för [getVerticalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) respektive [getHorizontalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--).

## **Om återställning av INormalViewProperties**

Anger storleken på bildområdet (bredd när det är ett barn till [getRestoredTop](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), höjd när det är ett barn till [getRestoredLeft](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximiserad).

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) anger storleken på bildområdet (bredd när det är ett barn till restoredTop, höjd när det är ett barn till restoredLeft).

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) specificerar om storleken på sidoinnehållsområdet ska kompensera för den nya storleken när fönstret som innehåller vyn i applikationen ändras storlek.

Ett exempel visas nedan som visar hur du kan komma åt egenskaperna [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) för en presentation.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Återställ visningsegenskaperna för presentationen
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

Aspose.Slides för Android via Java stöder nu att ange standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att sätta [ViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) kan sättas programatiskt. I detta avsnitt ser vi med ett exempel hur man ställer in [View Properties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties) för en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) i [Aspose.Slides](/slides/sv/).

{{% /alert %}} 

För att ställa in visningsegenskaperna. Följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
1. Ange [View Properties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
1. Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)-fil.  
   I exemplet nedan har vi satt zoomvärdet för bildvyn såväl som för notvyn.

```java
Presentation presentation = new Presentation();
try {
    // Ställer in visningsegenskaperna för presentationen
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomvärde i procent för bildvyn
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomvärde i procent för notervyn 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **FAQ**

**Kan jag ställa in olika visningsinställningar för olika avsnitt i en presentation?**

[Visningsinställningar](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getViewProperties--) är definierade på presentationsnivå ([Normalvy](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Bildvy](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), inte per avsnitt, så ett enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika visningslägen för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan respektera användarpreferenser, men själva filen innehåller endast ett set av visningsegenskaper.

**Kan jag förbereda en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [visningsegenskaper](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getViewProperties--) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala visningskonfiguration.