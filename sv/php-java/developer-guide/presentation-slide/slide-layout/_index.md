---
title: Använda eller ändra bildlayouter i PHP
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
- fotnotssynlighet
- titelsida
- titel och innehåll
- sektionrubrik
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
description: "Använda, skapa och modifiera bildlayouter i Aspose.Slides för PHP via Java, lägga till platshållare, ta bort oanvända layouter och styra fotnotssynlighet."
---
## **Översikt**

En bildlayout definierar positionerna och formateringen av platshållare såsom titlar, text, bilder, diagram och tabeller. Att tillämpa en layout ger bilder en enhetlig struktur samtidigt som varje bild kan innehålla sitt eget innehåll.

De vanligaste layouterna inkluderar:

- **Titelbild**: Innehåller platshållare för titel och undertitel.
- **Titel och innehåll**: Innehåller en platshållare för titel och en generell innehållsplatshållare.
- **Tom**: Innehåller inga innehållsplatshållare och är användbar när varje form placeras manuellt.

## **Förstå layoutarv**

En presentation har tre relaterade nivåer:

1. En [master‑bild](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/) definierar temat, delad formatering, bakgrunder och vanliga objekt.
2. En [layout‑bild](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/) tillhör en master och definierar ett specifikt arrangemang av platshållare.
3. En [normal bild](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/) använder en layout och lagrar innehållet som matats in för den bilden.

En normal bild ärver tema och formatering från sin layout, och layouten ärver från sin master. Ett värde som sätts direkt på en normal bild åsidosätter det ärvda värdet på den nivån. När en normal bild skapas, genereras dess platshållarformer från den valda layouten, medan innehållet som matas in i dessa platshållare tillhör den normala bilden.

Lägg till nödvändiga platshållare i en layout innan du skapar bilder från den. Att lägga till en ytterligare platshållare i en layout senare lägger inte automatiskt till en motsvarande platshållarform i befintliga normala bilder.

Detta förhållande har två viktiga konsekvenser:

- Att ändra ärvd formatering eller befintlig platshållargeometri i en layout kan uppdatera varje bild som beror på den. Innan du redigerar en layout som redan används, inspektera dess beroende bilder och granska den resulterande presentationen.
- En layout som fortfarande används av en bild kan inte tas bort. Tilldela om dess beroende bilder till en annan layout först, eller ta bara bort oanvända layouter.

För mer information om den översta nivån i detta hierarki, se [Slide Master](/slides/sv/php-java/slide-master/).

För att dölja ärvda logotyper eller dekorativa master‑former på en bild eller via en delad layout, se [Control the Visibility of Master Graphics](/slides/sv/php-java/slide-master/). Exemplet jämför två bilder som använder samma master.

## **Välj och tillämpa en bildlayout**

Använd en layouttyp när presentationen följer standard PowerPoint‑layoutdefinitioner. Layoutnamn kan redigeras av användaren och kan lokaliseras, så namn‑baserad urval är mindre pålitligt om du inte styr källmallen.

Följande exempel söker efter **Titel och innehåll** på den första master. Om den layouten inte finns, faller det medvetet tillbaka till **Tom**. Den andra null‑kontrollen är nödvändig eftersom en presentation kan innehålla endast anpassade layouter. Den valda layouten tillämpas sedan på den första normala bilden via metoden [Slide.setLayoutSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#setLayoutSlide).

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

Att ändra en bilds layout tar inte bort vanliga former som lagts till direkt på bilden. Däremot kan platshållarpositioner, ärvd formatering och korrespondensen mellan befintliga platshållare och den nya layouten förändras, så inspektera resultatet när du växlar mellan väsentligt olika layouter.

## **Lägg till en layout‑bild**

Urval och skapande är separata operationer. Det föregående exemplet väljer en befintlig layout; det skapar ingen. För att skapa en layout, anropa metoden [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterlayoutslidecollection/#add) på mål‑masterns layoutsamling.

Följande exempel lägger alltid till en ny **Titel och innehåll**‑layout med namnet `Report Title and Content`, och lägger sedan till en normal bild baserad på den. Layoutnamn måste vara unika inom samlingen.

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

Lägg till en layout endast när mallen verkligen behöver en ytterligare återanvändbar struktur. Om en lämplig layout redan finns, välj och återanvänd den istället för att skapa en dubblett.

## **Lägg till platshållare i en layout‑bild**

Metoden [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#getPlaceholderManager) ger en [LayoutPlaceholderManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/) för att lägga till platshållarformer i en layout.

| PowerPoint‑platshållare | `LayoutPlaceholderManager`‑metod |
| ----------------------- | --------------------------------- |
| ![Innehåll](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Innehåll (vertikal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (vertikal)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Bild](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagram](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabell](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online‑bild](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Följande exempel verifierar att **Tom**‑layouten finns, lägger till fyra platshållare i den och skapar sedan en normal bild som använder den modifierade layouten. Ordningen är avsiktlig: platshållarna läggs till innan den normala bilden skapas, så att Aspose.Slides kan generera motsvarande platshållarformer på den bilden.

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

![Platshållarna på layout‑bilden](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Att ändra ärvd formatering eller geometrin för befintliga layout‑platshållare kan påverka beroende bilder. En nygjord layout‑platshållare fylls inte retroaktivt in i befintliga normala bilder. Testa layout‑ändringar på en kopia av presentationen och inspektera varje beroende bild.
{{% /alert %}}

## **Ta bort oanvända layout‑bilder**

Använd metoden [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) för att ta bort layouter som ingen normal bild refererar till. Metoden lämnar layouter som fortfarande är i bruk intakta.

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

För att ta bort en specifik layout, använd först dess [hasDependingSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#hasDependingSlides) eller [getDependingSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#getDependingSlides) metod. Tilldela om eventuella beroende bilder innan du anropar [LayoutSlide.remove](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#remove). Att försöka ta bort en layout som används kastar en [PptxEditException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxeditexception/).

## **Styr fotnotssynlighet på en layout‑bild**

En layout har sina egna fotnot‑, bildnummer‑ och datum‑tid‑platshållare. Använd metoden [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) för att styra dessa platshållare för en layout. Detta är användbart när t.ex. innehållslayouter ska visa fotnoter men titel‑layouter inte ska.

Följande exempel väljer en layout på ett säkert sätt och gör dess fotnotselement synliga:

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

## **Styr fotnotssynlighet på en master och dess underlayouter**

För att tillämpa enhetliga fotnotinställningar över en master‑hierarki, använd metoden [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Spridningsmetoderna i [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslideheaderfootermanager/) verkar på mastern samt dess beroende layout‑bilder och normala bilder; de riktar sig inte bara mot en normal bild.

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

En master‑bild definierar presentationens tema och delad formatering. En layout‑bild tillhör en master och definierar ett återanvändbart arrangemang av platshållare. Normala bilder använder dessa layouter och lagrar bildspecifikt innehåll.

**Kan jag kopiera en layout‑bild från en presentation till en annan?**

Ja. Lägg till en kopia i destinationssamlingen med metoden [addClone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/globallayoutslidecollection/#addClone). Vid kopiering mellan presentationer, verifiera även typsnitt, teman, bilder och andra resurser som används av käll‑layouten.

**Vad händer när jag modifierar en layout som redan används?**

Beroende bilder ärver layout‑ändringarna såvida de inte åsidosätter den påverkade formateringen eller objekten lokalt. Platshållargeometri och ärvd stil kan därför ändras på många bilder samtidigt. Använd [getDependingSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#getDependingSlides) för att identifiera de berörda bilderna innan du redigerar layouten.

**Vad händer om jag tar bort en layout som fortfarande är i bruk?**

Aspose.Slides kastar en [PptxEditException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxeditexception/). Tilldela först om de beroende bilderna, eller använd [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) för att bara ta bort orefererade layouter.