---
title: Tillämpa eller ändra bildlayouter i PHP
linktitle: Bildlayout
type: docs
weight: 60
url: /sv/php-java/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationsdesign
- bilddesign
- oanvänd layout
- sidfotssynlighet
- titelsida
- titel och innehåll
- sektionstitel
- två innehåll
- jämförelse
- endast titel
- tom layout
- innehåll med bildtext
- bild med bildtext
- titel och vertikal text
- vertikal titel och text
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Tillämpa, skapa och modifiera bildlayouter i Aspose.Slides för PHP via Java, lägg till platshållare, ta bort oanvända layouter och styr sidfotssynlighet."
---
## **Översikt**

En bildlayout definierar positionerna och formateringen av platshållare såsom titlar, text, bilder, diagram och tabeller. Genom att använda en layout får bilder en konsekvent struktur samtidigt som varje bild kan innehålla sitt eget innehåll.

De vanligaste layouterna är:

- **Title Slide**: Innehåller platshållare för titel och undertitel.
- **Title and Content**: Innehåller en platshållare för titel och en allmän innehållsplats.
- **Blank**: Innehåller inga innehållsplatshållare och är användbar när varje form placeras manuellt.

## **Förstå ärvning av layout**

En presentation har tre relaterade nivåer:

1. En [master‑bild](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/) definierar tema, delad formatering, bakgrunder och gemensamma objekt.
1. En [layout‑bild](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/) tillhör en master och definierar en specifik placering av platshållare.
1. En [normal‑bild](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/) använder en layout och lagrar innehållet som anges för den bilden.

En normal‑bild ärver tema och formatering från sin layout, och layouten ärver från sin master. Ett värde som sätts direkt på en normal‑bild åsidosätter det ärvda värdet på den nivån. När en normal‑bild skapas genereras dess platshållarformer från den valda layouten, medan innehållet som skrivs in i dessa platshållare tillhör den normala bilden.

Lägg till nödvändiga platshållare i en layout innan du skapar bilder från den. Att senare lägga till en ny platshållare i en layout lägger inte automatiskt till motsvarande platshållarform i befintliga normala bilder.

Detta förhållande har två viktiga konsekvenser:

- Att ändra ärvd formatering eller befintlig platshållargeometri i en layout kan uppdatera varje bild som beror på den. Innan du redigerar en layout som redan används, inspektera dess beroende bilder och granska den resulterande presentationen.
- En layout som fortfarande används av en bild kan inte tas bort. Tilldela dess beroende bilder till en annan layout först, eller ta bara bort oanvända layouter.

För mer information om den översta nivån i hierarkin, se [Bildmaster](/slides/sv/php-java/slide-master/).

## **Välj och tillämpa en bildlayout**

Använd en layouttyp när presentationen följer standarddefinitioner för PowerPoint‑layouter. Layoutnamn kan redigeras av användaren och kan lokalanpassas, så namnbaserad urval är mindre pålitligt om du inte kontrollerar källmallen.

Följande exempel letar efter **Title and Content** på den första master‑bilden. Om den layouten inte finns, faller den medvetet tillbaka till **Blank**. Den andra null‑kontrollen är nödvändig eftersom en presentation kan innehålla endast anpassade layouter. Den valda layouten tillämpas sedan på den första normala bilden via metoden [Slide.setLayoutSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#setLayoutSlide).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Att ändra en bilds layout tar inte bort vanliga former som lagts till direkt på bilden. Dock kan platshållarpositioner, ärvd formatering och motsvarigheten mellan befintliga platshållare och den nya layouten ändras, så inspektera resultatet när du byter mellan väsentligt olika layouter.

## **Lägg till en layout‑bild**

Urval och skapande är separata operationer. Det föregående exemplet väljer en befintlig layout; det skapar ingen ny. För att skapa en layout, anropa metoden [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterlayoutslidecollection/#add) på mål‑masterens layoutsamling.

Följande exempel lägger alltid till en ny **Title and Content**‑layout med namnet `Report Title and Content`, och lägger sedan till en normal bild baserad på den. Layoutnamn måste vara unika inom samlingen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Lägg bara till en layout när mallen verkligen behöver en ytterligare återanvändbar struktur. Om en lämplig layout redan finns, välj och återanvänd den i stället för att skapa en duplikat.

## **Lägg till platshållare i en layout‑bild**

Metoden [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#getPlaceholderManager) tillhandahåller en [LayoutPlaceholderManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/) för att lägga till platshållarformer i en layout.

| PowerPoint‑platshållare            | `LayoutPlaceholderManager`‑metod |
| ---------------------------------- | --------------------------------- |
| ![Content](content.png)            | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                  | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)      | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)            | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)          | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)   | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Följande exempel verifierar att **Blank**‑layouten finns, lägger till fyra platshållare i den och skapar sedan en normal bild som använder den modifierade layouten. Ordningen är avsiktlig: platshållarna läggs till innan den normala bilden skapas, så att Aspose.Slides kan generera motsvarande platshållarformer på den bilden.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Resultatet:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Varning" %}}

Att ändra ärvd formatering eller geometrin för befintliga layout‑platshållare kan påverka beroende bilder. En nyligen tillagd layout‑platshållare fylls inte retroaktivt i befintliga normala bilder. Testa layout‑ändringar på en kopia av presentationen och inspektera varje beroende bild.

{{% /alert %}}

## **Ta bort oanvända layout‑bilder**

Använd metoden [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) för att ta bort layouter som ingen normal bild refererar till. Metoden låter intakta de layouter som fortfarande är i bruk.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

För att ta bort en specifik layout, använd först dess [hasDependingSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#hasDependingSlides) eller [getDependingSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#getDependingSlides)‑metod. Tilldela eventuella beroende bilder innan du anropar [LayoutSlide.remove](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#remove). Att försöka ta bort en layout som används kastar en [PptxEditException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxeditexception/).

## **Styr synlighet för sidfot på en layout‑bild**

En layout har egna sidfot-, bildnummer‑ och datum‑tid‑platshållare. Använd metoden [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) för att kontrollera dessa platshållare för en layout. Detta är användbart när till exempel innehållslayouter ska visa sidfot men titel‑layouter inte ska göra det.

Följande exempel väljer en layout på ett säkert sätt och gör dess sidfotelement synliga:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Styr synlighet för sidfot på en master och dess underliggande layouter**

För att tillämpa enhetliga sidfotinställningar över en master‑hierarki, använd metoden [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Spridningsmetoderna i [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslideheaderfootermanager/) verkar på master‑bilden samt dess beroende layout‑bilder och normala bilder; de riktar sig inte bara mot en enskild normal bild.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Vad är skillnaden mellan en master‑bild och en layout‑bild?**

En master‑bild definierar presentationens tema och delad formatering. En layout‑bild tillhör en master och definierar en återanvändbar placering av platshållare. Normala bilder använder dessa layouter och lagrar bildspecifikt innehåll.

**Kan jag kopiera en layout‑bild från en presentation till en annan?**

Ja. Lägg till en kopia i destinationssamlingen med metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/globallayoutslidecollection/#addClone). Vid kopiering mellan presentationer, verifiera också teckensnitt, teman, bilder och andra resurser som används av käll‑layouten.

**Vad händer när jag modifierar en layout som redan används?**

Beroende bilder ärver layout‑ändringarna såvida de inte har åsidosatt den påverkade formateringen eller objekten lokalt. Platshållargeometri och ärvd stil kan därför förändras på många bilder samtidigt. Använd [getDependingSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#getDependingSlides) för att identifiera de påverkade bilderna innan du redigerar layouten.

**Vad händer om jag tar bort en layout som fortfarande är i bruk?**

Aspose.Slides kastar en [PptxEditException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxeditexception/). Tilldela de beroende bilderna först, eller använd [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) för att enbart ta bort referenslösa layouter.