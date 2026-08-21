---
title: Rajzolási segédvonalak kezelése prezentációkban PHP-ben
linktitle: Rajzolási segédvonalak
type: docs
weight: 85
url: /hu/php-java/drawing-guides/
keywords:
- rajzolási segédvonal
- vízszintes segédvonal
- függőleges segédvonal
- igazítási segédvonal
- dia nézet
- mester dia
- elrendezési dia
- jegyzet mester
- szórólap mester
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Adj hozzá, érd el és töröld a vízszintes és függőleges rajzolási segédvonalakat PowerPoint prezentációkban az Aspose.Slides for PHP via Java használatával."
---
## **Áttekintés**

A rajzolási segédvonalak állítható vízszintes és függőleges vonalak, amelyek segítik a felhasználókat a formák következetes igazításában a PowerPoint‑ban végzett prezentációszerkesztés során. Különösen hasznosak, ha egy alkalmazás generál egy prezentációt, amelyet később kézzel finomítanak: az alkalmazás elmentheti ugyanazokat az igazítási segédleteket, amelyeket a szerzőknek követniük kell a tartalom hozzáadásakor vagy mozgatásakor.

A rajzolási segédvonalak szerkesztési segédeszközök, nem dia tartalom. Nem jelennek meg diavetítésben vagy a megjelenített kimenetben. Az Aspose.Slides for PHP via Java a [DrawingGuidesCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/drawingguidescollection/) osztályon keresztül teszi elérhetővé őket. Egy segédvonalat a [DrawingGuide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/drawingguide/) képvisel, és rendelkezik tájolással, pozícióval és színnel.

A pozíciót pontban mérik a megfelelő dia vagy mester bal felső sarkától számítva. A függőleges segédvonal vízszintes koordinátát használ, általában 0 és a dia szélessége között. A vízszintes segédvonal függőleges koordinátát használ, általában 0 és a dia magassága között.

## **Segédvonalak hozzáadása a dia nézethez**

Használja a [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) metódust a normál diák szerkesztése során megjelenő segédvonalak kezeléséhez. Hívja a [DrawingGuidesCollection::add](https://reference.aspose.com/slides/hu/php-java/aspose.slides/drawingguidescollection/#add) metódust egy [Orientation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/orientation/) értékkel és pontban megadott pozícióval.

Az alábbi példa egy függőleges segédvonalat ad a dia középpontja jobb oldalához, és egy vízszintes segédvonalat alá:
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

## **A rajzolási segédvonalak elérése**

A [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/drawingguidescollection/#getCount) és a [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/hu/php-java/aspose.slides/drawingguidescollection/#get_Item) metódusok hozzáférést biztosítanak a meglévő segédvonalakhoz. A [DrawingGuide::getOrientation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/drawingguide/#getOrientation), a [DrawingGuide::getPosition](https://reference.aspose.com/slides/hu/php-java/aspose.slides/drawingguide/#getPosition) és a [DrawingGuide::getColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/drawingguide/#getColor) metódusok értékeket adnak vissza, amelyeket a megfelelő setter metódusokkal is módosíthat.

Az alábbi példa beolvassa a fent létrehozott prezentáció dia‑nézetének segédvonalait:
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

## **Segédvonalak hozzáadása mester- és elrendezési diákhoz**

A diák mester és minden egyes elrendezési dia saját rajzolási segédvonal-gyűjteménnyel rendelkezhet. Használja a [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/#getDrawingGuides) metódust egy mester dia esetén, és a [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/#getDrawingGuides) metódust egy elrendezési dia esetén.

Az alábbi példa egy függőleges segédvonalat ad az első mester diához, és egy vízszintes segédvonalat az első elrendezési diához:
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

## **Segédvonalak hozzáadása jegyzet‑ és szórólap‑mesterekhez**

A jegyzet mesterek és a szórólap mesterek is támogatják a rajzolási segédvonalakat. Használja a [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masternotesslide/#getDrawingGuides) és a [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) metódusokat a gyűjteményeik eléréséhez. Ha a prezentáció nem tartalmazza ezeket a mestereket, a megfelelő kezelőt a [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) vagy a [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager) segítségével kérheti le, majd hozza létre az alapértelmezett mestert a `setDefaultMasterNotesSlide` vagy `setDefaultMasterHandoutSlide` segítségével.

Az alábbi példa egy vízszintes segédvonalat ad egy jegyzetmesterhez, és egy függőleges segédvonalat egy szórólapmesterhez:
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

## **Rajzolási segédvonalak törlése**

Hívja a [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/drawingguidescollection/#clear) metódust egy adott gyűjtemény minden segédvonalának eltávolításához. Egy gyűjtemény törlése nem befolyásolja a másik területen tárolt segédvonalakat.

Az alábbi példa törli a dia‑nézet segédvonalait, valamint minden segédvonalat a diák mesterekről, elrendezési diákról, a jegyzetmesterről és a szórólapmesterről, anélkül hogy hiányzó mestereket hozna létre:
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

## **GYIK**

**Megjelennek a rajzolási segédvonalak diavetítésben vagy exportált képeken?**

Nem. A rajzolási segédvonalak szerkesztési igazítási eszközök, és nem jelennek meg a prezentáció tartalmaként.

**Hozzáadható a rajzolási segédvonal közvetlenül egy egyedi normál diához?**

A normál diák szerkesztési segédvonalai a prezentáció dia‑nézet tulajdonságaiban tárolódnak. Külön segédvonal-gyűjtemények állnak rendelkezésre a diák mestereken, elrendezési diákon, jegyzetmestereken és szórólapmestereken.

**Milyen egységek használatosak a segédvonalak pozíciójához?**

A pozíciókat pontban adjuk meg, ahol 72 pont egy hüvelyknek felel meg. A függőleges pozíciókat a bal szélből, a vízszintes pozíciókat a felső szélből mérik.

**Eltávolítja-e a rajzolási segédvonalak törlése az alakzatokat vagy módosítja a dia tartalmát?**

Nem. A [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/drawingguidescollection/#clear) metódus csak a kiválasztott gyűjteményben lévő segédvonalakat távolítja el. Az alakzatok és a többi dia tartalma változatlan marad.