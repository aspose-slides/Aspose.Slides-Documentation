---
title: Hämta och uppdatera presentationsvyegenskaper i PHP
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/php-java/presentation-view-properties/
keywords:
- vyegenskaper
- normalläge
- dispositionsinnehåll
- dispositionsikoner
- fäst vertikal splitter
- ensam vy
- stapeltillstånd
- dimensionsstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Använd Aspose.Slides för PHP via Java för att konfigurera layouten för normalläget, bild- och anteckningszoom, rutnätsavstånd samt kommentarers synlighet i PowerPoint-presentationer."
---
## **Introduktion**

I PowerPoints normalläge visas bilden mellan ett sidopanel för miniatyrer eller en disposition och ett anteckningspanel nedanför. Aspose.Slides för PHP via Java exponerar presentationens sparade redigeringsinställningar via [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). Dessa inkluderar panellayouten, zoomnivåer, rutnätsavstånd och synlighet för kommentarer.

## **Om NormalViewProperties**

Använd [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) för att komma åt klassen [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) styr om ikoner visas bredvid bildrubriker i dispositionen. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) låter sidopanelen fästa sig i sitt minimerade tillstånd när användaren smalnar av den. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) indikerar en preferens för att visa en panel i hela fönstret.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) styr delaren mellan sidopanelen och bilden. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) styr delaren ovanför anteckningspanelen. Båda accepterar ett [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/)‑värde av `Minimized`, `Maximized` eller `Restored`.

## **Om återställning av NormalViewProperties**

När en delare återställs, tillhandahåller [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) den sparade storleken på sidopanelen och [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) den sparade storleken på den övre bildytan. Båda exponeras via [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/). Dess [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/)‑metod accepterar en procentandel från 0 till 100, och [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) styr om redigeraren justerar storleken när fönstret ändras i storlek.

Detta exempel uppdaterar en befintlig presentation. Det återställer den horisontella delaren, sätter storleken som returneras av [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) till 80 % med automatisk justering aktiverad, och maximerar den vertikala delaren. Det anropar också [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) för att visa ikoner i dispositionsvyn.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ställ in standardzoomvärdet**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) och [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) lagrar oberoende zoominställningar för redigeraren. Dessa inställningar påverkar inte bildens dimensioner, bildspelsuppspelning eller bildexportens upplösning.

Detta exempel öppnar en befintlig presentation och anropar [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) för att anpassa bilden till redigeringsfönstret. För anteckningssidan inaktiveras automatisk skalning och [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) anropas för att sätta en fast zoom på 80 %.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ställ in rutnätsavståndet**

Metoden `setGridSpacing` i [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) anger avståndet mellan redigeringsrutnätslinjer i hela presentationen. Den tar ett positivt värde i punkter, med 72 punkter per tum. Detta exempel skriver ut det aktuella avståndet i en befintlig presentation och sparar ett ett‑fjärdedels‑tum rutnät genom att sätta intervallet till 18 punkter.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Rutnätet upprepas med ett fast intervall. [Drawing guides](/slides/sv/php-java/drawing-guides/) markerar enskilda horisontella eller vertikala positioner. Båda är redigeringshjälpmedel och visas endast i redigerare som visar dem. Bildspel och export till PDF, bilder eller SVG utelämnar dem.

## **Visa eller dölj kommentarer vid öppning av en presentation**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) lagrar en preferens som kompatibla redigerare använder när de öppnar presentationen. För en befintlig presentation med kommentarer skriver detta exempel ut den aktuella inställningen och sparar en kopia med kommentarer dolda. Det anropar också [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) med [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) så att kopian öppnas i bildvyn.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Att dölja kommentarer bevarar deras text, författare, positioner, svar och statusar. För att ändra kommentarerna själva, se [Presentation Comments](/slides/sv/php-java/presentation-comments/). Exportinställningar styr om kommentarer visas i PDF, HTML, bilder, anteckningar eller handouts.

## **Vanliga frågor**

**Varför är rutnätet dolt när jag öppnar presentationen igen?**

Presentationens lagrar rutnätsintervallet. För att se rutnätet, aktivera rutnätsvisning i redigeraren.

**Ändrar rensning av ritguider rutnätsavståndet?**

Nej. Att lägga till, flytta eller rensa en guide ändrar inte rutnätsintervallet.

**Kan olika sektioner i en presentation ha olika visningsinställningar?**

Nej. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) gäller hela presentationen.

**Kan jag spara olika visningsinställningar för olika användare?**

Filen lagrar ett set av visningsinställningar för alla. En redigerare kan också tillämpa en användares lokala preferenser.

**Kan jag spara visningsinställningar i en mall?**

Ja. Presentationer som skapas från mallen ärver dess sparade visningsinställningar.