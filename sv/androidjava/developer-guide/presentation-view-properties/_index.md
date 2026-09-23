---
title: Hämta och uppdatera presentationsvyeegenskaper på Android
linktitle: Visningsegenskaper
type: docs
weight: 80
url: /sv/androidjava/presentation-view-properties/
keywords:
- visningsegenskaper
- normalvy
- översiktsinnehåll
- översiktsikoner
- fäst vertikal delare
- enkelvy
- balktillstånd
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck Aspose.Slides för Android via Java visningsegenskaper för att anpassa format PPT, PPTX och ODP-bilder — justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalläget består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som gäller positioneringen av de olika innehållsområdena. Denna information gör att applikationen kan spara sitt vytilstånd till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) har lagts till för att ge åtkomst till normalvyegenskaper för presentationen. 

[INormalViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewRestoredProperties) gränssnitt och deras efterföljare, [SplitterBarStateType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType) enum har lagts till.

## **Om INormalViewProperties**

Representerar normalvyegenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) anger om applikationen ska visa ikoner när dispositionsinnehåll visas i något av innehållsområdena i normalvyläget.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) anger om den vertikala delaren ska fästa i ett minimerat läge när sidområdet är tillräckligt litet.

Egenskapen [getPreferSingleView](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) och [setPreferSingleView](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) anger om användaren föredrar att se ett enda innehållsområde i hela fönstret istället för den vanliga normalvyn med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) specificerar vilket tillstånd den horisontella eller vertikala delarbalken ska visas i. En horisontell delarbalk separerar bilden från innehållsområdet under bilden, en vertikal delarbalk separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) och [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) och [getRestoredTop](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificerar storleken på det övre eller sidogående bildområdet i normalvyn, när värdet [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SplitterBarStateType#Restored) tillämpas för [getVerticalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) i enlighet med detta.

## **Om att återställa INormalViewProperties**

Anger storleken på bildområdet (bredd när det är ett barn till [getRestoredTop](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), höjd när det är ett barn till [getRestoredLeft](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) i normalvyn, när området har en variabel återställd storlek (varken minimerad eller maximerad). 

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specificerar storleken på bildområdet (bredd när det är ett barn till restoredTop, höjd när det är ett barn till restoredLeft).

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) anger om storleken på sidoinnehållsområdet ska justeras för den nya storleken när fönstret som innehåller vyn ändras storlek i applikationen.

Ett exempel ges nedan som visar hur du kan komma åt [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) egenskaper för en presentation.

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

Aspose.Slides för Android via Java stöder nu att ange standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att ställa in [ViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) kan sättas programatiskt. I detta ämne kommer vi med ett exempel att visa hur man ställer in [View Properties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) i Aspose.Slides.

{{% /alert %}} 

För att ange vyegenskaperna. Följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
1. Ställ in [View Properties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
1. Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/) fil.
   I exempel nedan har vi ställt in zoomvärdet för bildvyn såväl som för notvyn.

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

Använd [Presentation.getViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getViewProperties--) för att komma åt vyinställningar för hela presentationen. Metoderna [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) och [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller hela presentationen, inte en enskild bild. Rutnätavstånd anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde, enligt API-dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut dess aktuella rutnätavstånd, ställer in ett fjärdedels tum-intervall och sparar resultatet.

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

Rutnätet skiljer sig från [ritningsguider](/slides/sv/androidjava/drawing-guides/). Rutnätavstånd styr ett regelbundet intervall, medan ritningsguider är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritningsguider förändrar inte rutnätavståndet.

Både rutnätet och ritningsguiderna är redigeringshjälpmedel. De renderas inte som bildinnehåll i PDF, bilder, SVG eller en bildspelsvisning. Att lagra rutnätavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror också på visarens eller redigerarens preferenser.

## **Visa eller gömma kommentarer när en presentation öppnas**

Använd [Presentation.getViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getViewProperties--) för att komma åt vyinställningar för hela presentationen. Använd [IViewProperties.getShowComments](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) och [IViewProperties.setShowComments](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) för att läsa eller ändra den lagrade preferensen för om kommentarer ska visas när presentationen öppnas i PowerPoint eller en annan kompatibel redigerare.

Denna inställning styr endast den lagrade vypreferensen. Den lägger inte till, tar bort, redigerar eller löser kommentarer. Att gömma kommentarer bevarar deras innehåll, författare, positioner, svar och status. Se [Presentation Comments](/slides/sv/androidjava/presentation-comments/) för operationer som ändrar själva kommentarerna.

Följande exempel kräver en befintlig `comments.pptx` som innehåller kommentarer. Det skriver ut den aktuella synlighetsinställningen, begär att kommentarer ska gömmas och sparar en ny PPTX utan att ta bort några kommentarer. Det använder också [IViewProperties.setLastView](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) med [ViewType.SlideView](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewtype/#SlideView) för att konfigurera den initiala redigeringsvyn tillsammans med kommentarens synlighet.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Denna inställning bestämmer inte om kommentarer inkluderas i PDF-, HTML-, bild-, antecknings- eller handout-exporter. Konfigurera de relevanta exportspecifika alternativen separat.

## **FAQ**

**Varför är rutnätet inte synligt när jag öppnar presentationen igen?**

Filen lagrar rutnätavståndet, men redigeraren styr om rutnätet visas. Kontrollera redigerarens inställningar för rutnätsynlighet.

**Ändrar rensning av ritningsguider rutnätavståndet?**

Nej. Ritningsguider och rutnätavstånd är oberoende inställningar. Att rensa guider lämnar det lagrade rutnätsintervallet oförändrat.

**Kan jag ställa in olika vyinställningar för olika avsnitt i en presentation?**

Vyinställningarna([View settings](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getViewProperties--)) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), inte per avsnitt, så ett enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vylägen för olika användare?**

Nej. Inställningarna sparas i filen och delas. Visningsprogram kan respektera användarpreferenser, men själva filen innehåller endast en uppsättning vyegenskaper.

**Kan jag förbereda en mall med fördefinierade vyegenskaper så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getViewProperties--) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.