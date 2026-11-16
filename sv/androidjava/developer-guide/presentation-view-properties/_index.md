---
title: Hämta och uppdatera presentationsvyegenskaper på Android
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/androidjava/presentation-view-properties/
keywords:
- vyegenskaper
- normal vy
- dispositionsinnehåll
- dispositionsikoner
- snäpp vertikal splitter
- enkel vy
- stapelstatus
- dimensionsstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Använd Aspose.Slides för Android via Java för att konfigurera normalvylayout, bild- och anteckningszoom, rutnätsavstånd och kommentarssynlighet i PowerPoint-presentationer."
---
## **Introduktion**

I PowerPoints normala vy visas bilden mellan en sidopanel för miniatyrer eller en disposition och en anteckningspanel nedanför. Aspose.Slides för Android via Java exponerar presentationens sparade redigeringspreferenser via [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--). Dessa inkluderar panelens layout, zoomnivåer, rutnätsavstånd och kommentarers synlighet.

## **Om INormalViewProperties**

Använd [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) för att komma åt gränssnittet [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) styr om ikoner visas bredvid bildrubriker i dispositionen. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) låter sidopanelen fästa i sitt minimerade tillstånd när användaren gör den smalare. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) indikerar en preferens för att visa en panel i hela fönstret.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) styr avdelaren mellan sidopanelen och bilden. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) styr avdelaren ovanför anteckningspanelen. Båda accepterar ett [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/)-värde av `Minimized`, `Maximized` eller `Restored`.

## **Om återställning av INormalViewProperties**

När en avdelare återställs ger [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) den sparade storleken på sidopanelen och [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) den sparade storleken på det övre bildområdet. Båda exponerar [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/). Dess [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) metod accepterar en procentandel från 0 till 100, och [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) styr om redigeraren justerar storleken när fönstret ändras.

Det här exemplet uppdaterar en befintlig presentation. Det återställer den horisontella avdelaren, sätter storleken som returneras av [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) till 80% med automatisk justering aktiverad, och maximerar den vertikala avdelaren. Det anropar också [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) för att visa ikoner i dispositionsvyn.

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

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) och [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) lagrar oberoende zoominställningar för redigeraren. Dessa inställningar påverkar inte bildens dimensioner, bildspelsuppspelning eller bildexportens upplösning.

Det här exemplet öppnar en befintlig presentation och anropar [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) för att anpassa bilden till redigeringsfönstret. För anteckningssidan inaktiveras automatisk skalning och [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) anropas för att sätta en fast zoom på 80%.

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

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) anger avståndet mellan redigeringsrutnätslinjer i hela presentationen. Den tar ett positivt värde i punkter, med 72 punkter per tum. Detta exempel skriver ut det aktuella avståndet i en befintlig presentation och sparar ett kvartal-tums rutnät genom att sätta intervallet till 18 punkter.

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

Rutnätet upprepas med ett fast intervall. [Drawing guides](/slides/sv/androidjava/drawing-guides/) markerar enskilda horisontella eller vertikala positioner. Båda är redigeringshjälpmedel och visas endast i redigerare som visar dem. Bildspel och export till PDF, bilder eller SVG utelämnar dem.

## **Visa eller dölj kommentarer vid öppning av en presentation**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) lagrar en preferens som kompatibla redigerare använder när de öppnar presentationen. För en befintlig presentation med kommentarer skriver detta exempel ut den aktuella inställningen och sparar en kopia med kommentarer dolda. Det anropar också [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) med [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) så att kopian öppnas i bildvyn.

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

Att dölja kommentarer bevarar deras text, författare, positioner, svar och statusar. För att ändra kommentarerna själva, se [Presentation Comments](/slides/sv/androidjava/presentation-comments/). Exportinställningarna styr om kommentarer visas i PDF, HTML, bilder, anteckningar eller handouts.

## **FAQ**

**Varför är rutnätet dolt när jag öppnar presentationen igen?**

Presentationen sparar rutnätsintervallet. För att se rutnätet, aktivera rutnätsvisning i redigeraren.

**Ändrar rensning av ritguider rutnätsavståndet?**

Nej. Att lägga till, flytta eller rensa en guide ändrar inte rutnätsintervallet.

**Kan olika sektioner i en presentation ha olika vyinställningar?**

Nej. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) gäller för hela presentationen.

**Kan jag spara olika vyinställningar för olika användare?**

Filen lagrar en uppsättning vyegenskaper för alla. En redigerare kan också tillämpa en användares lokala preferenser.

**Kan jag spara vyinställningar i en mall?**

Ja. Presentationer skapade från mallen ärver dess sparade vyinställningar.