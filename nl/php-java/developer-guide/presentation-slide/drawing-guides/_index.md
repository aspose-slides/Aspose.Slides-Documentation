---
title: Beheer teken‑gidsen in presentaties in PHP
linktitle: Teken‑gidsen
type: docs
weight: 85
url: /nl/php-java/drawing-guides/
keywords:
- teken‑gids
- horizontale gids
- verticale gids
- uitlijningsgids
- diaweergave
- masterdia
- lay‑outdia
- notitiemaster
- handout‑master
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Voeg horizontale en verticale teken‑gidsen toe, krijg er toegang toe en wis ze in PowerPoint‑presentaties met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Teken‑gidsen zijn verstelbare horizontale en verticale lijnen die gebruikers helpen vormen consistent uit te lijnen tijdens het bewerken van een presentatie in PowerPoint. Ze zijn vooral nuttig wanneer een applicatie een presentatie genereert die later handmatig verfijnd wordt: de applicatie kan dezelfde uitlijningshulpmiddelen opslaan die auteurs moeten volgen bij het toevoegen of verplaatsen van inhoud.

Teken‑gidsen zijn hulpmiddelen voor bewerken, geen dia‑inhoud. Ze verschijnen niet in een diavoorstelling of gerenderde output. Aspose.Slides for PHP via Java maakt ze beschikbaar via de [DrawingGuidesCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/drawingguidescollection/)‑klasse. Een gids wordt weergegeven door [DrawingGuide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/drawingguide/) en heeft een oriëntatie, een positie en een kleur.

De positie wordt gemeten in punten vanaf de linkerbovenhoek van de betreffende dia of master. Een verticale gids gebruikt een horizontale coördinaat, doorgaans tussen nul en de dia‑breedte. Een horizontale gids gebruikt een verticale coördinaat, doorgaans tussen nul en de dia‑hoogte.

## **Gidsen toevoegen aan de diaweergave**

Gebruik [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) om gidsen te beheren die worden weergegeven tijdens het bewerken van normale dia’s. Roep [DrawingGuidesCollection::add](https://reference.aspose.com/slides/nl/php-java/aspose.slides/drawingguidescollection/#add) aan met een [Orientation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/orientation/)‑waarde en een positie in punten.

Het volgende voorbeeld voegt één verticale gids toe rechts van het midden van de dia en één horizontale gids eronder:

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

## **Toegang tot teken‑gidsen**

De methoden [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/nl/php-java/aspose.slides/drawingguidescollection/#getCount) en [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/nl/php-java/aspose.slides/drawingguidescollection/#get_Item) geven toegang tot bestaande gidsen. De methoden [DrawingGuide::getOrientation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/nl/php-java/aspose.slides/drawingguide/#getPosition) en [DrawingGuide::getColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/drawingguide/#getColor) retourneren waarden die ook kunnen worden gewijzigd via de overeenkomstige setter‑methoden.

Het volgende voorbeeld leest de gidsen van de diaweergave uit de hierboven gemaakte presentatie:

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

## **Gidsen toevoegen aan master‑ en lay‑outdia’s**

Een master‑dia en elk van zijn lay‑outdia’s kan eigen collecties met teken‑gidsen hebben. Gebruik [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/#getDrawingGuides) voor een master‑dia en [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#getDrawingGuides) voor een lay‑outdia.

Het volgende voorbeeld voegt een verticale gids toe aan de eerste master‑dia en een horizontale gids aan de eerste lay‑outdia:

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

## **Gidsen toevoegen aan notitie‑ en handout‑masters**

Notitie‑masters en handout‑masters ondersteunen eveneens teken‑gidsen. Gebruik [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masternotesslide/#getDrawingGuides) en [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) om hun collecties te benaderen. Als een presentatie geen van deze masters bevat, verkrijg dan de juiste manager via [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) of [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager), en creëer vervolgens de standaard‑master met `setDefaultMasterNotesSlide` of `setDefaultMasterHandoutSlide`.

Het volgende voorbeeld voegt een horizontale gids toe aan een notitie‑master en een verticale gids aan een handout‑master:

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

## **Gidsen wissen**

Roep [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/drawingguidescollection/#clear) aan om elke gids uit een bepaalde collectie te verwijderen. Het wissen van één collectie heeft geen invloed op gidsen die in een andere scope zijn opgeslagen.

Het volgende voorbeeld wist de gidsen van de diaweergave en alle gidsen op master‑dia’s, lay‑outdia’s, de notitie‑master en de handout‑master zonder missende masters aan te maken:

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

**Verschijnen teken‑gidsen in een diavoorstelling of geëxporteerde afbeeldingen?**

Nee. Teken‑gidsen zijn uitlijningshulpmiddelen voor bewerken en worden niet gerenderd als presentatie‑inhoud.

**Kan een teken‑gids rechtstreeks aan een individuele normale dia worden toegevoegd?**

Gidsen voor het bewerken van normale dia’s worden opgeslagen in de dia‑view‑eigenschappen van de presentatie. Aparte gids‑collecties zijn beschikbaar voor master‑dia’s, lay‑outdia’s, notitie‑masters en handout‑masters.

**Welke eenheden worden gebruikt voor gids‑posities?**

Posities worden gespecificeerd in punten, waarbij 72 punten gelijk zijn aan één inch. Verticale posities worden gemeten vanaf de linkerrand, en horizontale posities vanaf de bovengrand.

**Verwijdert het wissen van teken‑gidsen vormen of wijzigt het de dia‑inhoud?**

Nee. De methode [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/drawingguidescollection/#clear) verwijdert alleen de gidsen in de geselecteerde collectie. Vormen en andere dia‑inhoud blijven ongewijzigd.