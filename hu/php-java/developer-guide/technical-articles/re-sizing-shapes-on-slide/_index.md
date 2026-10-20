---
title: Alakzatok átméretezése a bemutatódiákon PHP-ben
type: docs
weight: 130
url: /hu/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/alkalmazasok-átméretezése-dián/
  - /hu/php-java/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- bemutató
- PHP
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for PHP via Java segítségével — automatizálja a diaelrendezés módosítását és növelje a termelékenységet."
---
## **Áttekintés**

Amikor megváltoztatja egy bemutató diák méretét, előfordulhat, hogy át kell méreteznie és újra kell pozícionálnia az alakzatokat, hogy illeszkedjenek az új méretekhez. Ez a cikk bemutatja, hogyan lehet kézzel méretezni az alakzatokat, és hogyan kell kezelni a táblázatokat a diákon, a mesterdiákon és az elrendezéseken.

## **Alakzatok átméretezése**

Az egyes alakzatok relatív pozíciójának és méretének megőrzéséhez szorozza meg a vízszintes koordinátákat és a szélességet az új dia szélességének és az eredeti szélességnek arányával. A megfelelő magasságarányt alkalmazza a függőleges koordinátákra és a magasságra.

Az első példa betölti azt a bemutatót, amelynek diái nem tartalmaznak táblázatot, A4-es méretre változtatja a diák méretét, majd elmenti az eredményt. A [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) és a [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) használatával a későbbi ciklus szabályozza a méretezést. Az arányok egység nélküli értékek; az alakzatok pozíciói és méretei pontban vannak megadva. A különböző szélesség- és magasságarányok torzíthatják az alakzatokat, és az alakzat méretének módosítása nem méretezi át a betűméreteket.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Számolja ki a független vízszintes és függőleges méretezési tényezőket.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
A táblázatok külön kezelést igényelnek: a táblázat teljes szélességét és magasságát nem kell hozzárendelni, hanem az oszlopszélességeket és sormagasságokat kell méretezni. A sormagasságok nagyobbak maradhatnak a kért méretnél, ha a cella tartalma több helyet igényel.
{{% /alert %}}

A második példa támogatja a táblázatokat, és a mesterdiákon, az elrendezéseken valamint az egyedi diákon is feldolgozza az alakzatokat, mielőtt elmentené a méretezett bemutatót. A segédprogram minden [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) elemet úgy kezel, hogy az oszlopszélességeket a [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) és a minimális sormagasságokat a [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) segítségével méretezi. Ezután a táblázat pozícióját méretezi anélkül, hogy külön méretezné a teljes méreteket.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // A táblázat méreteit az oszlopszélességek és sormagasságok szabályozzák.
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    // Számolja ki a független vízszintes és függőleges méretezési tényezőket.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Átméretezze a mester- és elrendezésdiákokon, valamint az egyéni diákokon definiált alakzatokat.
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Gyakran Ismételt Kérdések**

**Miért torzulnak vagy vágódnak le az alakzatok egy dia átméretezése után?**

Ha a diák méretét átméretezés nélkül változtatja meg, az alakzatok megtartják eredeti pozíciójukat és méretüket, és a dia határain túl is kijuthatnak. A szélesség és magasság különböző arányokkal történő méretezése szintén torzíthatja az alakzatokat.

**Működik a megadott kód minden alakzattípussal?**

Az első példa közvetlenül módosítja az alakzat határait, és olyan diákra vonatkozik, amelyek nem tartalmaznak táblázatot. A második példa külön kezeli a táblázatokat. Ellenőrizze a kapott elrendezést, különösen a szöveget és a táblázatokat, mivel ezek a példák nem méretezik át a betűméreteket, és a táblázat tartalma korlátozhatja a sormagasságokat.

**Hogyan méretezhetem át a táblázatokat egy dia átméretezésekor?**

Az oszlopszélességeket a szélességarány, a minimális sormagasságokat a magasságarány alapján méretezzük, majd a táblázat pozícióját méretezzük, ahogyan a második példában látható.

**Működik ez a méretezés mesterdiákon és elrendezésdiákon is?**

Igen. A második példa végigiterál a [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) és az egyes mesterek [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) elemein, és ugyanazt a méretezési logikát alkalmazza az alakzataikra.

**Módosíthatom a dia tájolását (álló/fekvő) a méretezés mellett?**

Igen. Hívja meg a [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) metódust a diák méretének megváltoztatása után és a célnyomatok beolvasása előtt, hogy a méretezési tényezők a végleges tájolást tükrözzék.

**Van korlátja a beállítható diák méretének?**

Egyéni diákméreteket a [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) segítségével adhat meg. A támogatott méretek a bemutató formátumától és a fájlt megnyitó alkalmazástól is függenek.

**Hogyan akadályozhatom meg, hogy a fix képarányú alakzatok torzuljanak?**

Használja ugyanazt a méretezési tényezőt a szélességhez és a magassághoz. Az eredeti elrendezés új diákméretekbe való illesztéséhez a szélesség- és magasságarányok közül a kisebbet alkalmazza mindkét méretnél és pozíciónál. Ez megőrzi az arányokat, de előfordulhat, hogy az egyik szélen üres hely marad.