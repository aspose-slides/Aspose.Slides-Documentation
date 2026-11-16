---
title: Hämta och uppdatera vyegenskaper för presentation i Java
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/java/presentation-view-properties/
keywords:
- vyegenskaper
- normalvy
- dispositionsinnehåll
- dispositionsikoner
- fäst vertikal delare
- enkelvy
- stapelstatus
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Använd Aspose.Slides för Java för att konfigurera normalvylayout, zoom för bild och anteckningar, rutnätsavstånd och kommentarsynlighet i PowerPoint-presentationer."
---
## **Introduktion**

I PowerPoints normalvy visas bilden mellan ett sidopanel för miniatyrer eller en översikt och ett noteringspanel nedanför. Aspose.Slides för Java exponerar presentationens sparade redigeringsinställningar via [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--). Dessa inkluderar panelens layout, zoomnivåer, rutnätsavstånd och kommentarsynlighet.

## **Om INormalViewProperties**

Använd [getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNormalViewProperties--) för att komma åt [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/)‑gränssnittet. [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) styr om ikoner visas bredvid bildtitlar i översikten. [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) låter sidopanelen fästa sig i sitt minimerade läge när användaren gör den smalare. [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) indikerar en preferens för att visa en panel i hela fönstret.

[setVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) styr avdelaren mellan sidopanelen och bilden. [setHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) styr avdelaren ovanför noteringspanelen. Båda accepterar ett [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/splitterbarstatetype/)‑värde av `Minimized`, `Maximized` eller `Restored`.

## **Om återställning av INormalViewProperties**

När en avdelare återställs tillhandahåller [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) den sparade storleken på sidopanelen och [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) den sparade storleken på det övre bildområdet. Båda exponerar [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/). Dess [setDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-)‑metod accepterar en procentsats från 0 till 100, och [setAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) styr om redigeraren justerar storleken när fönstret ändras.

Detta exempel uppdaterar en befintlig presentation. Det återställer den horisontella avdelaren, sätter storleken som returneras av [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) till 80% med automatisk justering aktiverad, och maximerar den vertikala avdelaren. Det anropar även [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) för att visa ikoner i översiktsvyn.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in standardzoomvärdet**

[getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getSlideViewProperties--) och [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNotesViewProperties--) lagrar oberoende zoominställningar för redigeraren. Dessa inställningar påverkar inte bilddimensioner, bildspelsuppspelning eller upplösning vid bildexport.

Detta exempel öppnar en befintlig presentation och anropar [setVariableScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) för att anpassa bilden till redigeringsfönstret. För noteringssidan inaktiveras automatisk skalning och [setScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setScale-int-) anropas för att sätta en fast 80% zoom.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in rutnätsavståndet**

[setGridSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) anger avståndet mellan redigeringsrutnätslinjer i hela presentationen. Den tar ett positivt värde i punkter, med 72 punkter per tum. Detta exempel skriver ut det aktuella avståndet i en befintlig presentation och sparar ett fjärdedel‑tum rutnät genom att sätta intervallet till 18 punkter.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);
    
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rutnätet upprepas med ett fast intervall. [Ritningsguider](/slides/sv/java/drawing-guides/) markerar enskilda horisontella eller vertikala positioner. Båda är redigeringshjälpmedel och visas bara i redigerare som stödjer dem. Bildspel och export till PDF, bilder eller SVG utelämnar dem.

## **Visa eller dölj kommentarer vid öppning av en presentation**

[setShowComments](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) lagrar en preferens som kompatibla redigerare använder när de öppnar presentationen. För en befintlig presentation med kommentarer skriver detta exempel ut den aktuella inställningen och sparar en kopia med kommentarer dolda. Det anropar även [setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setLastView-int-) med [ViewType.SlideView](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/#SlideView) så att kopian öppnas i bildvyn.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Att dölja kommentarer bevarar deras text, författare, positioner, svar och status. För att ändra kommentarerna själva, se [Presentation kommentarer](/slides/sv/java/presentation-comments/). Exportinställningar styr om kommentarer visas i PDF, HTML, bilder, noteringar eller handouts.

## **Vanliga frågor**

**Varför är rutnetet dolt när jag öppnar om presentationen?**  
Presentationen sparar rutnätsintervallet. För att se rutnetet, aktivera rutnätsvisning i redigeraren.

**Ändrar rensning av ritningsguider rutnätsavståndet?**  
Nej. Att lägga till, flytta eller rensa en guide lämnar rutnätsintervallet oförändrat.

**Kan olika delar av en presentation ha olika visningsinställningar?**  
Nej. [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) gäller för hela presentationen.

**Kan jag spara olika visningsinställningar för olika användare?**  
Filen sparar en uppsättning visningsegenskaper för alla. En redigerare kan också tillämpa en användares lokala preferenser.

**Kan jag spara visningsinställningar i en mall?**  
Ja. Presentationer skapade från mallen ärver dess sparade visningsinställningar.