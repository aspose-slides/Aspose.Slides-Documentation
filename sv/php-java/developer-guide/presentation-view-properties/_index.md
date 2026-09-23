---
title: Hämta och uppdatera presentationsvyegenskaper i PHP
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/php-java/presentation-view-properties/
keywords:
- vyegenskaper
- normal vy
- dispositionsinnehåll
- dispositionsikoner
- fästa vertikal splitare
- enskild vy
- listtillstånd
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Upptäck Aspose.Slides för PHP via Java vyegenskaper för att anpassa PPT-, PPTX- och ODP-formatets bilder — justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett nederst innehållsområde. Egenskaper som gäller placeringen av de olika innehållsområdena. Denna information gör det möjligt för applikationen att spara vyns tillstånd till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) har lagts till för att ge åtkomst till normalvy‑egenskaper för en presentation. 

[NormalViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewRestoredProperties) klasser och deras nedärvda klasser, [SplitterBarStateType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType) enum har lagts till.

## **Om INormalViewProperties**

Representerar normalvy‑egenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) anger om applikationen ska visa ikoner när dispositionens innehåll visas i något av innehållsområdena i normalvy‑läget.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) anger om den vertikala delaren ska låsas i ett minimerat tillstånd när sidoregionen är tillräckligt liten.

Egenskapen [getPreferSingleView](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) och [setPreferSingleView](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) anger om användaren föredrar att se ett helfönster med ett enda innehållsområde istället för den standardmässiga normalvyn med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) anger det tillstånd som den horisontella eller vertikala delningslisten ska visas i. En horisontell delningslist separerar bilden från innehållsområdet under bilden, en vertikal delningslist separerar bilden från sidoinnehållsområdet. Möjliga värden är: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType/#Maximized) och [SplitterBarStateType::Restored](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType/#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) och [getRestoredTop](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties#getRestoredTop) anger storleken på det övre eller sidogenerade bildområdet i normalvyn när värdet [SplitterBarStateType::Restored](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType/#Restored) tillämpas för [getVerticalBarState](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) respektive.

## **Om återställning av INormalViewProperties**

Anger storleken på bildregionen (bredd när den är ett underobjekt till [getRestoredTop](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), höjd när den är ett underobjekt till [getRestoredLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximerad). 

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) anger storleken på bildregionen (bredd när den är ett underobjekt till restoredTop, höjd när den är ett underobjekt till restoredLeft).

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) anger om storleken på sidoinnehållsområdet ska kompensera för den nya storleken när fönstret som innehåller vyn i applikationen ändras storlek.

Ett exempel ges nedan som visar hur du kan komma åt [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties/#getNormalViewProperties)-egenskaper för en presentation.

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

Aspose.Slides för PHP via Java stöder nu att ställa in standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att ange [ViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) kan sättas programatiskt. I det här avsnittet visar vi med ett exempel hur man ställer in [View Properties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) i Aspose.Slides.

{{% /alert %}} 

För att ställa in vyegenskaperna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
1. Ställ in [View Properties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
1. Skriv presentationen som en [PPTX ](https://docs.fileformat.com/presentation/pptx/)fil.
   I exemplaret nedan har vi ställt in zoomvärdet för bildvyn samt notvyn.

```php
  $presentation = new Presentation();
  try {
    # Anger vyegenskaperna för presentationen
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Zoomvärde i procent för bildvyn
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Zoomvärde i procent för notervyn

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Ställ in rutnätsavståndet**

Använd [Presentation::getViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getViewProperties) för att komma åt vyinställningar för hela presentationen. Metoderna [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/#getGridSpacing) och [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/#setGridSpacing) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller för hela presentationen, inte för en enskild bild. Rutnätsavståndet anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde enligt API-dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut det aktuella rutnätsavståndet, sätter ett kvart tum‑interval och sparar resultatet.

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

Rutnätet är annorlunda än [drawing guides](/slides/sv/php-java/drawing-guides/). Rutnätsavståndet styr ett regelbundet intervall, medan ritningsguider är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritningsguider förändrar inte rutnätsavståndet.

Både rutnätet och ritningsguiderna är redigeringshjälpmedel. De renderas inte som bildinnehåll i PDF, bilder, SVG eller en bildspel. Att lagra rutnätsavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror också på tittarens eller redigerarens inställningar.

## **Visa eller dölja kommentarer när en presentation öppnas**

Använd [Presentation::getViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getviewproperties/) för att komma åt vyinställningar för hela presentationen. Använd [ViewProperties::getShowComments](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/getshowcomments/) och [ViewProperties::setShowComments](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/setshowcomments/) för att läsa eller ändra den lagrade preferensen för om kommentarer ska visas när presentationen öppnas i PowerPoint eller en annan kompatibel redigerare.

Denna inställning styr endast den lagrade vypreferensen. Den lägger inte till, tar bort, redigerar eller löser kommentarer. Att dölja kommentarer bevarar deras innehåll, författare, positioner, svar och statusar. Se [Presentation Comments](/slides/sv/php-java/presentation-comments/) för operationer som ändrar kommentarerna själva.

Följande exempel kräver en befintlig `comments.pptx` som innehåller kommentarer. Det skriver ut den aktuella synlighetsinställningen, begär att kommentarer ska döljas och sparar en ny PPTX utan att ta bort några kommentarer. Det använder också [ViewProperties::setLastView](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/setlastview/) tillsammans med [ViewType::SlideView](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewtype/#SlideView) för att konfigurera den initiala redigeringsvyn tillsammans med kommentarens synlighet.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Denna inställning bestämmer inte om kommentarer inkluderas i PDF-, HTML-, bild-, not- eller handouts-export. Konfigurera de relevanta export‑specifika alternativen separat.

## **FAQ**

**Varför är rutnetet inte synligt när jag öppnar presentationen igen?**

Filen lagrar rutnätsavståndet, men redigeraren styr om rutnätet visas. Kontrollera redigerarens inställningar för rutnätsynlighet.

**Ändrar rensning av ritningsguider rutnätsavståndet?**

Nej. Ritningsguider och rutnätsavstånd är oberoende inställningar. Att rensa guider lämnar det lagrade rutnätintervallet oförändrat.

**Kan jag ställa in olika vyinställningar för olika sektioner i en presentation?**

[View settings](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getviewproperties/) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/getslideviewproperties/)), inte per sektion, så ett enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vylägen för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan respektera användarpreferenser, men filen i sig innehåller ett enda set av vyegenskaper.

**Kan jag förbereda en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getviewproperties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.