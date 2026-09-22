---
title: Hämta och uppdatera presentationsvyns egenskaper i Java
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/java/presentation-view-properties/
keywords:
- vyegenskaper
- normal vy
- dispositionsinnehåll
- dispositionsikoner
- snappa vertikal delare
- ensam vy
- fältets tillstånd
- dimensionens storlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Upptäck Aspose.Slides för Java vyegenskaper för att anpassa PPT-, PPTX- och ODP-formatens bilder - justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som rör placeringen av de olika innehållsområdena. Denna information gör att programmet kan spara sitt visningsläge i filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) har lagts till för att ge åtkomst till normalvyns egenskaper för en presentation. 

[INormalViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewRestoredProperties) gränssnitt och deras efterföljare, [SplitterBarStateType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType) enum har lagts till.

## **Om INormalViewProperties**

Representerar normalvyns egenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) anger om programmet ska visa ikoner när dispositionens innehåll visas i något av innehållsområdena i normalvyläget.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) anger om den vertikala delaren ska fästas i ett minimerat tillstånd när sidoregionen är tillräckligt liten.

Egenskapen [getPreferSingleView](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) och [setPreferSingleView](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) anger om användaren föredrar att se ett enda innehållsområde i hela fönstret istället för den vanliga normalvyn med tre innehållsområden. Om den är aktiverad kan programmet välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) anger vilket tillstånd den horisontella eller vertikala delaren ska visas i. En horisontell delare separerar bilden från innehållsområdet under bilden, en vertikal delare separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Maximized) och [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) och [getRestoredTop](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificerar storleken på den övre eller sidogenererade bildregionen i normalvyn, när värdet [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Restored) tillämpas för [getVerticalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) därefter.

## **Om återställning av INormalViewProperties** 

Anger storleken på bildregionen (bredd när den är ett underobjekt till [getRestoredTop](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), höjd när den är ett underobjekt till [getRestoredLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximiserad). 

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) anger storleken på bildregionen (bredd när den är ett underobjekt till restoredTop, höjd när den är ett underobjekt till restoredLeft).

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) anger om storleken på sidoinnehållsområdet ska anpassas till den nya storleken när fönstret som innehåller vyn i programmet ändras i storlek.

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

Aspose.Slides for Java stöder nu att ställa in standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att ange [ViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) kan ställas in programmässigt. I detta avsnitt kommer vi med ett exempel att visa hur man ställer in [View Properties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) i Aspose.Slides.

{{% /alert %}} 

För att ställa in vyegenskaperna. Följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
1. Ange [View Properties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
1. Spara presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.
   I exemplet nedan har vi ställt in zoomvärdet för bildvyn samt notvyn.

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

## **Ställ in rutnätets avstånd**

Använd [Presentation.getViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getViewProperties--) för att komma åt presentationsomfattande vyinställningar. Metoderna [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iviewproperties/#getGridSpacing--) och [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller hela presentationen, inte enskilda bilder. Rutnätsavstånd anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde, enligt API‑dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut dess nuvarande rutnätsavstånd, sätter ett fjärdedels tum‑intervall och sparar resultatet.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rutnätet skiljer sig från [drawing guides](/slides/sv/java/drawing-guides/). Rutnätsavstånd styr ett regelbundet intervall, medan ritningsguider är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritningsguider ändrar inte rutnätsavståndet.

Både rutnätet och ritningsguiderna är redigeringshjälpmedel. De renderas inte som bildinnehåll i PDF, bilder, SVG eller en bildspelsvisning. Att lagra rutnätsavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror även på visarens eller redigerarens inställningar.

## **FAQ**

**Varför är inte rutnätet synligt efter att jag öppnat presentationen igen?**

Filen lagrar rutnätsavståndet, men redigeraren styr om rutnätet visas. Kontrollera redigerarens inställningar för rutnätsynlighet.

**Är det så att rensning av ritningsguider ändrar rutnätsavståndet?**

Nej. Ritningsguider och rutnätsavstånd är oberoende inställningar. Att rensa guider lämnar det lagrade rutnätsintervallet oförändrat.

**Kan jag ange olika vyinställningar för olika sektioner i en presentation?**

Vyinställningar definieras på presentationsnivå (Normal View/Slide View), inte per sektion, så ett enda parameteruppsättning gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vytilstånd för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visarprogram kan respektera användarpreferenser, men filen själv innehåller endast en uppsättning vyegenskaper.

**Kan jag förbereda en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom vyegenskaper lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.