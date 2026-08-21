---
title: Hantera ritningsguider i presentationer i PHP
linktitle: Ritningsguider
type: docs
weight: 85
url: /sv/php-java/drawing-guides/
keywords:
- ritningsguide
- horisontell guide
- vertikal guide
- justeringsguide
- bildvy
- masterbild
- layoutbild
- anteckningsmaster
- handout-master
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lägg till, hämta och rensa horisontella och vertikala ritningsguider i PowerPoint-presentationer med Aspose.Slides för PHP via Java."
---
## **Översikt**

Ritningsguider är justerbara horisontella och vertikala linjer som hjälper användare att justera former konsekvent när de redigerar en presentation i PowerPoint. De är särskilt användbara när en applikation genererar en presentation som senare ska finjusteras manuellt: applikationen kan spara samma justeringshjälpmedel som författare bör följa när de lägger till eller flyttar innehåll.

Ritningsguider är redigeringshjälpmedel, inte bildinnehåll. De visas inte i en bildspel eller i renderad output. Aspose.Slides för PHP via Java exponerar dem genom klassen [DrawingGuidesCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/drawingguidescollection/). En guide representeras av [DrawingGuide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/drawingguide/) och har en orientering, en position och en färg.

Positionen mäts i punkter från det övre vänstra hörnet på den aktuella bilden eller mastern. En vertikal guide använder en horisontell koordinat, vanligtvis mellan noll och bildens bredd. En horisontell guide använder en vertikal koordinat, vanligtvis mellan noll och bildens höjd.

## **Lägg till guider i bildvyn**

Använd [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) för att hantera guider som visas medan du redigerar vanliga bilder. Anropa [DrawingGuidesCollection::add](https://reference.aspose.com/slides/sv/php-java/aspose.slides/drawingguidescollection/#add) med ett [Orientation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/orientation/)‑värde och en position i punkter.

Följande exempel lägger till en vertikal guide till höger om bildens centrum och en horisontell guide under den:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Åtkomst till ritningsguider**

Metoderna [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/sv/php-java/aspose.slides/drawingguidescollection/#getCount) och [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/sv/php-java/aspose.slides/drawingguidescollection/#get_Item) ger åtkomst till befintliga guider. Metoderna [DrawingGuide::getOrientation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/sv/php-java/aspose.slides/drawingguide/#getPosition) och [DrawingGuide::getColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/drawingguide/#getColor) returnerar värden som också kan ändras via motsvarande setter‑metoder.

Följande exempel läser bild‑vyns guider från presentationen som skapades ovan:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Lägg till guider i master‑ och layout‑bilder**

En bildmaster och var och en av dess layout‑bilder kan ha sina egna ritningsguide‑samlingar. Använd [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslide/#getDrawingGuides) för en master‑bild och [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/#getDrawingGuides) för en layout‑bild.

Följande exempel lägger till en vertikal guide till den första master‑bilden och en horisontell guide till den första layout‑bilden:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lägg till guider i antecknings‑ och handout‑masterar**

Antecknings‑masterar och handout‑masterar stöder också ritningsguider. Använd [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masternotesslide/#getDrawingGuides) och [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) för att komma åt deras samlingar. Om en presentation inte innehåller någon av dessa masterar, hämta lämplig manager med [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) eller [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager), skapa sedan standard‑masteren med `setDefaultMasterNotesSlide` eller `setDefaultMasterHandoutSlide`.

Följande exempel lägger till en horisontell guide till en antecknings‑master och en vertikal guide till en handout‑master:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Rensa ritningsguider**

Anropa [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/sv/php-java/aspose.slides/drawingguidescollection/#clear) för att ta bort alla guider från en viss samling. Att rensa en samling påverkar inte guider som lagras i ett annat område.

Följande exempel rensar bild‑vyns guider och alla guider på bild‑masterar, layout‑bilder, antecknings‑mastern och handout‑mastern utan att skapa saknade masterar:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Visas ritningsguider i ett bildspel eller exporterade bilder?**

Nej. Ritningsguider är justeringshjälpmedel för redigering och renderas inte som presentationsinnehåll.

**Kan en ritningsguide läggas till direkt på en enskild normal bild?**

Redigeringsguider för normal‑bild lagras i presentationens bild‑vyns egenskaper. Separata guide‑samlingar finns för bild‑masterar, layout‑bilder, antecknings‑masterar och handout‑masterar.

**Vilken enhet används för guidepositioner?**

Positioner anges i punkter, där 72 punkter motsvarar en tum. Vertikala positioner mäts från vänstra kanten och horisontella positioner mäts från överkanten.

**Tar radering av ritningsguider bort former eller ändrar bildens innehåll?**

Nej. Metoden [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/sv/php-java/aspose.slides/drawingguidescollection/#clear) tar bara bort guiderna i den valda samlingen. Former och annat bildinnehåll förblir oförändrade.