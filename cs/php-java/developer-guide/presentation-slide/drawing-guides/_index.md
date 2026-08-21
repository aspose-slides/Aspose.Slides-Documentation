---
title: Správa kreslicích vodítek v prezentacích v PHP
linktitle: Kreslicí vodítka
type: docs
weight: 85
url: /cs/php-java/drawing-guides/
keywords:
- kreslicí vodítko
- vodorovné vodítko
- svislé vodítko
- zarovnávací vodítko
- zobrazení snímku
- hlavní šablona
- rozložení snímku
- poznámková hlavní šablona
- podkladová hlavní šablona
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Přidávejte, přistupujte a odstraňujte vodorovná a svislá kreslicí vodítka v prezentacích PowerPoint pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Kreslicí vodítka jsou nastavitelná vodorovná a svislá čára, která pomáhají uživatelům konzistentně zarovnávat tvary při úpravě prezentace v PowerPointu. Jsou zvláště užitečná, když aplikace vytvoří prezentaci, která bude později ručně doladěna: aplikace může uložit stejné pomůcky pro zarovnání, které by autoři měli dodržovat při přidávání nebo přesouvání obsahu.

Kreslicí vodítka jsou pomůcky při úpravách, ne obsah snímku. Neobjevují se v režimu prezentace ani ve vykresleném výstupu. Aspose.Slides pro PHP přes Java je zpřístupňuje prostřednictvím třídy [DrawingGuidesCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/drawingguidescollection/) . Vodítko je reprezentováno třídou [DrawingGuide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/drawingguide/) , která má orientaci, pozici a barvu.

Pozice se měří v bodech od levého horního rohu příslušného snímku nebo hlavní šablony. Vertikální vodítko používá horizontální souřadnici, obvykle mezi nulou a šířkou snímku. Horizontální vodítko používá vertikální souřadnici, obvykle mezi nulou a výškou snímku.

## **Přidání vodítek do zobrazení snímku**

Použijte [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) k řízení vodítek zobrazených při úpravě běžných snímků. Zavolejte [DrawingGuidesCollection::add](https://reference.aspose.com/slides/cs/php-java/aspose.slides/drawingguidescollection/#add) s hodnotou [Orientation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/orientation/) a pozicí v bodech.

Následující příklad přidává jedno svislé vodítko napravo od středu snímku a jedno vodorovné vodítko pod ním:

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

## **Přístup ke kreslicím vodítkům**

Metody [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/cs/php-java/aspose.slides/drawingguidescollection/#getCount) a [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/cs/php-java/aspose.slides/drawingguidescollection/#get_Item) poskytují přístup k existujícím vodítkům. Metody [DrawingGuide::getOrientation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/cs/php-java/aspose.slides/drawingguide/#getPosition) a [DrawingGuide::getColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/drawingguide/#getColor) vracejí hodnoty, které lze také změnit pomocí odpovídajících setter metod.

Následující příklad čte vodítka ze zobrazení snímku v předchozí vytvořené prezentaci:

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

## **Přidání vodítek do hlavní šablony a rozložení snímků**

Hlavní šablona snímku a každá její rozložení snímků mohou mít vlastní kolekce kreslicích vodítek. Použijte [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/#getDrawingGuides) pro hlavní šablonu a [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/#getDrawingGuides) pro rozložení snímku.

Následující příklad přidává svislé vodítko do první hlavní šablony a vodorovné vodítko do první rozložení snímku:

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

## **Přidání vodítek do poznámkových a podkladových hlavních šablon**

Poznámkové hlavní šablony a podkladové hlavní šablony také podporují kreslicí vodítka. Použijte [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masternotesslide/#getDrawingGuides) a [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) k přístupu k jejich kolekcím. Pokud prezentace neobsahuje některou z těchto šablon, získejte odpovídající správce pomocí [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) nebo [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager), poté vytvořte výchozí šablonu pomocí `setDefaultMasterNotesSlide` nebo `setDefaultMasterHandoutSlide`.

Následující příklad přidává vodorovné vodítko do poznámkové hlavní šablony a svislé vodítko do podkladové hlavní šablony:

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

## **Vymazání kreslicích vodítek**

Zavolejte [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/drawingguidescollection/#clear) k odstranění všech vodítek z konkrétní kolekce. Vymazání jedné kolekce neovlivní vodítka uložená v jiné oblasti.

Následující příklad vymaže vodítka ze zobrazení snímku a všech vodítek na hlavních šablonách snímků, rozložení snímků, poznámkové hlavní šabloně a podkladové hlavní šabloně bez vytváření chybějících šablon:

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

**Objevují se kreslicí vodítka v prezentaci nebo exportovaných obrázcích?**

Ne. Kreslicí vodítka jsou pomůcky pro zarovnání při úpravách a nejsou vykreslována jako obsah prezentace.

**Lze kreslicí vodítko přidat přímo k jednotlivému normálnímu snímku?**

Vodítka pro úpravu normálních snímků jsou uložena v vlastnostech zobrazení snímku prezentace. Samostatné kolekce vodítek jsou k dispozici pro hlavní šablony snímků, rozložení snímků, poznámkové hlavní šablony a podkladové hlavní šablony.

**Jaké jednotky se používají pro pozice vodítek?**

Pozice jsou udávány v bodech, kde 72 bodů odpovídá jednomu palci. Vertikální pozice jsou měřeny od levého okraje a horizontální pozice jsou měřeny od horního okraje.

**Odstraní vymazání kreslicích vodítek tvary nebo změní obsah snímku?**

Ne. Metoda [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/drawingguidescollection/#clear) odstraňuje pouze vodítka ve vybrané kolekci. Tvary a další obsah snímku zůstávají nezměněny.