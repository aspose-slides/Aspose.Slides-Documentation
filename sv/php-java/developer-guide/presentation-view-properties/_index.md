---
title: Hämta och uppdatera vyegenskaper för presentation i PHP
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/php-java/presentation-view-properties/
keywords:
- vyegenskaper
- normalvy
- dispositionens innehåll
- dispositionsikoner
- fästa vertikal splitter
- enkel vy
- stapelstatus
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Upptäck Aspose.Slides för PHP via Java vyegenskaper för att anpassa PPT-, PPTX- och ODP‑bilder — justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Det normala vyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som rör placeringen av de olika innehållsområdena. Denna information gör det möjligt för applikationen att spara vyns tillstånd till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) har lagts till för att ge åtkomst till normala vyegenskaper för en presentation.

Klasserna [NormalViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewRestoredProperties) samt deras underklasser, enumen [SplitterBarStateType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType) har lagts till.

## **Om INormalViewProperties**

Representerar normala vyegenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) anger om applikationen ska visa ikoner när konturens innehåll visas i något av innehållsområdena i normalvyläget.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) anger om den vertikala splittern ska fästa i ett minimerat läge när sidområdet är tillräckligt litet.

Egenskapen [getPreferSingleView](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) och [setPreferSingleView](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) anger om användaren föredrar att se ett fullskärmsinnehållsregion istället för standardnormalvyn med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) anger i vilket tillstånd den horisontella eller vertikala splittern ska visas. En horisontell splittern separerar bilden från innehållsområdet under bilden, en vertikal splittern separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType/#Maximized) och [SplitterBarStateType::Restored](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType/#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) och [getRestoredTop](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties#getRestoredTop) anger storleken på den övre eller sidobildregionen i normalvyn när värdet [SplitterBarStateType::Restored](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType/#Restored) har tillämpats på [getVerticalBarState](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) respektive.

## **Om återställning av INormalViewProperties**

Anger storleken på bildregionen (bredd när den är ett barn till [getRestoredTop](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), höjd när den är ett barn till [getRestoredLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximiserad).

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) anger storleken på bildregionen (bredd när den är ett barn till restoredTop, höjd när den är ett barn till restoredLeft).

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) anger om storleken på sidoinnehållsområdet ska kompensera för den nya storleken när fönstret som innehåller vyn i applikationen ändras storlek.

Ett exempel ges nedan som visar hur du kan komma åt [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) för en presentation.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Återställ vyegenskaperna för presentationen
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Ställ in standardzoomvärdet**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java stöder nu att ange standardzoomvärde för en presentation så att när presentationen öppnas är zoomen redan satt. Detta kan göras genom att ställa in [ViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) kan ställas in programatiskt. I detta avsnitt ser vi med ett exempel hur man ställer in [View Properties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) i Aspose.Slides.

{{% /alert %}} 

För att ställa in vyegenskaperna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
1. Ställ in [View Properties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
1. Spara presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.  
   I exemplet nedan har vi ställt in zoomvärdet för både bildvyn och notevyn.

```php
  $presentation = new Presentation();
  try {
    # Ställer in vyegenskaperna för presentationen
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Zoomvärde i procent för bildvyn
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Zoomvärde i procent för notervyn

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Ställ in rutnätsavstånd**

Använd [Presentation::getViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getViewProperties) för att komma åt vyinställningar på presentationsnivå. Metoderna [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/#getGridSpacing) och [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/#setGridSpacing) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller hela presentationen, inte en enskild bild. Rutnätsavståndet anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde enligt API‑dokumentationen.

Följande exempel öppnar befintlig `demo.pptx`, skriver ut det aktuella rutnätsavståndet, sätter ett kvart‑tum‑intervall och sparar resultatet.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Rutnätet skiljer sig från [drawing guides](/slides/sv/php-java/drawing-guides/). Rutnätsavstånd styr ett regelbundet intervall, medan ritlinjer är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritlinjer ändrar inte rutnätsavståndet.

Både rutnät och ritlinjer är hjälpmedel för redigering. De renderas inte som bildinnehåll i PDF, bilder, SVG eller bildspel. Att lagra rutnätsavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror också på visare‑ eller redigerarens inställningar.

## **Vanliga frågor**

**Varför är rutnätet inte synligt efter att jag har öppnat presentationen igen?**

Filen lagrar rutnätsavståndet, men redigeraren bestämmer om rutnätet visas. Kontrollera redigerarens inställningar för rutnätsynlighet.

**Ändrar rensning av ritlinjer rutnätsavståndet?**

Nej. Ritlinjer och rutnätsavstånd är oberoende inställningar. Att rensa linjer lämnar det lagrade rutnätsintervallet oförändrat.

**Kan jag ange olika vyinställningar för olika avsnitt i en presentation?**

[Vyinställningar](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getviewproperties/) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/getslideviewproperties/)), inte per avsnitt, så ett enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vylägen för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visar‑applikationer kan ta hänsyn till användarens preferenser, men själva filen innehåller bara en uppsättning vyegenskaper.

**Kan jag skapa en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getviewproperties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.