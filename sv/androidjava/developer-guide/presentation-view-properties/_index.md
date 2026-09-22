---
title: Hämta och uppdatera presentationsvy‑egenskaper på Android
linktitle: Vy‑egenskaper
type: docs
weight: 80
url: /sv/androidjava/presentation-view-properties/
keywords:
- vy‑egenskaper
- normal vy
- konturinnehåll
- konturikoner
- fäst vertikal delare
- ensam vy
- fälttillstånd
- dimensionsstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck Aspose.Slides för Android via Java vy‑egenskaper för att anpassa PPT, PPTX och ODP‑bilder—justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som rör placeringen av de olika innehållsområdena. Denna information gör det möjligt för programmet att spara vy‑tillståndet till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) har lagts till för att ge åtkomst till normalvyns egenskaper för en presentation.  

[INormalViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewRestoredProperties) gränssnitt och deras nedärvda typer, [SplitterBarStateType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType)‑enum har lagts till.

## **Om INormalViewProperties**

Representerar normalvy‑egenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) anger om programmet ska visa ikoner när det visar kontursinnehåll i någon av innehållsområdena i normalvyläget.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) anger om den vertikala delaren ska fästa i ett minimerat läge när sidoregionen är tillräckligt liten.

Egenskapen [getPreferSingleView](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) och [setPreferSingleView](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) anger om användaren föredrar att se ett full‑fönster‑enkel‑innehållsområde istället för den vanliga normalvyn med tre innehållsområden. Om den är aktiverad kan programmet välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) specificerar vilket tillstånd den horisontella eller vertikala delarbalken ska visas i. En horisontell delarbalk separerar bilden från innehållsområdet under bilden, en vertikal delarbalk separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) och [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) och [getRestoredTop](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificerar storleken på den övre eller sidogren av bilden i normalvyn, när värdet [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Restored) används för [getVerticalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) respektive.

## **Om återställning av INormalViewProperties**

Anger storleken på bildregionen (bredd när den är ett barn till [getRestoredTop](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), höjd när den är ett barn till [getRestoredLeft](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximerad).

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specificerar storleken på bildregionen (bredd när den är ett barn till restoredTop, höjd när den är ett barn till restoredLeft).

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) anger om storleken på sidoinnehållsområdet ska kompensera för den nya storleken när fönstret som innehåller vyn i programmet ändras i storlek.

Ett exempel visas nedan som visar hur du kan komma åt [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--)‑egenskaper för en presentation.

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

Aspose.Slides för Android via Java stöder nu att ange standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att ställa in [ViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) kan sättas programatiskt. I detta avsnitt ser vi med ett exempel hur man ställer in [View Properties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) i Aspose.Slides.

{{% /alert %}} 

För att ställa in vy‑egenskaperna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
1. Ställ in [View Properties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
1. Spara presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)-fil.  
   I exemplet nedan har vi ställt in zoomvärdet för bildvyn samt för notvyn.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Ställer in vyegenskaperna för presentationen
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Zoomvärde i procent för bildvyn
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Zoomvärde i procent för notvyn 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in rutnätavståndet**

Använd [Presentation.getViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getViewProperties--) för att komma åt vy‑inställningarna för hela presentationen. Metoderna [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) och [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller för hela presentationen, inte för en enskild bild. Rutnätavståndet anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde enligt API‑dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut det aktuella rutnätavståndet, anger ett kvart‑tum‑intervall och sparar resultatet.

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

Rutnätet skiljer sig från [drawing guides](/slides/sv/androidjava/drawing-guides/). Rutnätavståndet styr ett regelbundet intervall, medan ritningsguider är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritningsguider ändrar inte rutnätavståndet.

Både rutnätet och ritningsguiderna är hjälpmedel för redigering. De renderas inte som bildinnehåll i PDF, bilder, SVG eller ett bildspel. Att lagra rutnätavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror också på visnings‑ eller redigerarens inställningar.

## **FAQ**

**Varför är rutnätet inte synligt när jag öppnar presentationen igen?**

Filen lagrar rutnätavståndet, men redigeraren styr om rutnätet visas. Kontrollera redigerarens inställningar för rutnätsynlighet.

**Ändrar rensning av ritningsguider rutnätavståndet?**

Nej. Ritningsguider och rutnätavstånd är oberoende inställningar. Att rensa guider lämnar det lagrade rutnätsintervallet oförändrat.

**Kan jag ange olika vy‑inställningar för olika sektioner i en presentation?**

[View settings](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getViewProperties--) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), inte per sektion, så ett enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vy‑tillstånd för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan ta hänsyn till användarens preferenser, men filen själv innehåller bara en uppsättning vy‑egenskaper.

**Kan jag förbereda en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getViewProperties--) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vy‑konfiguration.