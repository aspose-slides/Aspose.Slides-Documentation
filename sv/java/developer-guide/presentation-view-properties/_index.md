---
title: Hämta och uppdatera presentationsvyegenskaper i Java
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/java/presentation-view-properties/
keywords:
- vyegenskaper
- normal vy
- dispositionsinnehåll
- dispositionsikoner
- fästa vertikal delare
- enkel vy
- fältstatus
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Upptäck Aspose.Slides för Java vyegenskaper för att anpassa PPT-, PPTX- och ODP-formatens bilder — justera layouter, zoomnivåer och displayinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som rör placeringen av de olika innehållsområdena. Denna information gör att applikationen kan spara sitt visningsläge till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) har lagts till för att ge åtkomst till normalvyns egenskaper för presentationen. 

[INormalViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewRestoredProperties) gränssnitt och deras avkommor, [SplitterBarStateType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType)‑enum har lagts till.

## **Om INormalViewProperties**

Representerar normalvyns egenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) anger om applikationen ska visa ikoner när den visar dispositionsinnehåll i något av innehållsområdena i normalvyläget.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) anger om den vertikala delaren ska låsas till ett minimerat läge när sidoregionen är tillräckligt liten.

Egenskapen [getPreferSingleView](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) och [setPreferSingleView](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) anger om användaren föredrar att se ett enda innehållsområde i hela fönstret istället för den vanliga normalvyn med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) specificerar i vilket tillstånd den horisontella eller vertikala delarbalken ska visas. En horisontell delarbalk separerar bilden från innehållsområdet under bilden, en vertikal delarbalk separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Maximized) och [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) och [getRestoredTop](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificerar storleken på den övre eller sidogående bildregionen i normalvyn när värdet [SplitterBarStateType.Restored](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SplitterBarStateType#Restored) har tillämpats på [getVerticalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) respektive.

## **Om återställning av INormalViewProperties**

Anger storleken på bildregionen (bredd när den är ett barn till [getRestoredTop](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), höjd när den är ett barn till [getRestoredLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximerad). 

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specificerar storleken på bildregionen (bredd när den är ett barn till restoredTop, höjd när den är ett barn till restoredLeft).

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

Aspose.Slides for Java stöder nu att ställa in standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att sätta [ViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) kan sättas programatiskt. I detta ämne kommer vi att med ett exempel visa hur man sätter [View Properties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) i Aspose.Slides.

{{% /alert %}} 

För att ställa in visningsinställningarna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
1. Ställ in [View Properties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
1. Skriv presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.
   I exemplet nedan har vi ställt in zoomvärdet för bildvyn samt notvyn.

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

## **Ställ in rutnätsavstånd**

Använd [Presentation.getViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getViewProperties--) för att komma åt vyinställningarna på presentationsnivå. Metoderna [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iviewproperties/#getGridSpacing--) och [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller hela presentationen, inte en enskild bild. Rutnätsavståndet anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde enligt API‑dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut dess aktuella rutnätsavstånd, sätter ett kvarts tum‑intervall och sparar resultatet.

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

Rutnätet skiljer sig från [ritningsguider](/slides/sv/java/drawing-guides/). Rutnätsavståndet styr ett regelbundet intervall, medan ritningsguider är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritningsguider ändrar inte rutnätsavståndet.

Både rutnätet och ritningsguiderna är hjälpmedel för redigering. De renderas inte som bildinnehåll i PDF, bilder, SVG eller ett bildspel. Att lagra rutnätsavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror även på visnings‑ eller redigerarens inställningar.

## **Visa eller dölja kommentarer när en presentation öppnas**

Använd [Presentation.getViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getViewProperties--) för att komma åt vyinställningarna på presentationsnivå. Använd [IViewProperties.getShowComments](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iviewproperties/#getShowComments--) och [IViewProperties.setShowComments](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) för att läsa eller ändra den lagrade preferensen för om kommentarer ska visas när presentationen öppnas i PowerPoint eller en annan kompatibel redigerare.

Denna inställning styr endast den lagrade vypreferensen. Den lägger inte till, tar bort, redigerar eller löser kommentarer. Att dölja kommentarer bevarar deras innehåll, författare, positioner, svar och statusar. Se [Presentation Comments](/slides/sv/java/presentation-comments/) för operationer som ändrar kommentarerna själva.

Följande exempel kräver en befintlig `comments.pptx` som innehåller kommentarer. Det skriver ut den aktuella synlighetsinställningen, begär att kommentarer ska döljas och sparar en ny PPTX utan att ta bort några kommentarer. Det använder också [IViewProperties.setLastView](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iviewproperties/#setLastView-int-) tillsammans med [ViewType.SlideView](https://reference.aspose.com/slides/sv/java/com.aspose.slides/viewtype/#SlideView) för att konfigurera den initiala redigeringsvyn tillsammans med kommentarsynlighet.

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

Denna inställning avgör inte om kommentarer inkluderas i PDF-, HTML‑, bild‑, not- eller handout‑export. Konfigurera de relevanta export‑specifika alternativen separat.

## **FAQ**

**Varför är rutnätet inte synligt när jag öppnar presentationen igen?**

Filen lagrar rutnätsavståndet, men redigeraren styr om rutnätet visas. Kontrollera redigerarens inställningar för rutnätsynlighet.

**Är det så att rensning av ritningsguider ändrar rutnätsavståndet?**

Nej. Ritningsguider och rutnätsavstånd är oberoende inställningar. Att rensa guider lämnar det lagrade rutnätsintervallet oförändrat.

**Kan jag ställa in olika vyinställningar för olika sektioner i en presentation?**

[Vyinställningar](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getViewProperties--) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/sv/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), inte per sektion, så ett enda parameter‑set gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vylägen för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan ta hänsyn till användarpreferenser, men filen själv innehåller bara ett set av vyegenskaper.

**Kan jag förbereda en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getViewProperties--) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.