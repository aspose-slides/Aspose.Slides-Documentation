---
title: Alakzatok átméretezése a prezentáció diáin PHP-ben
type: docs
weight: 130
url: /hu/php-java/resizing-shapes-on-slide/
aliases:
  - /hu/php-java/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for PHP Java‑on keresztül—automatizálja a diaelrendezés módosítását és növelje a hatékonyságot."
---
## **Áttekintés**

Amikor megváltoztatja egy prezentáció diavetületének méretét, előfordulhat, hogy át kell méreteznie és újra kell helyeznie az alakzatokat, hogy illeszkedjenek az új dimenziókhoz. Ez a cikk bemutatja, hogyan lehet kézzel méretezni az alakzatokat, valamint hogyan kell kezelni a táblázatokat a diákon, mestereken és elrendezéseken.

## **Alakzatok átméretezése**

Az egyes alakzatok relatív helyzetének és méretének megőrzéséhez szorozza meg a vízszintes koordinátákat és a szélességet az új dia szélességének és az eredeti szélességnek a hányadosával. Alkalmazza a megfelelő magasságarányt a függőleges koordinátákra és a magasságra is.

Az első példa betölt egy prezentációt, amelynek diái nem tartalmaznak táblázatot, A4-re változtatja a dia méretét, majd elmenti az eredményt. A [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) metódust a [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) értékkel használja, hogy a későbbi ciklus szabályozza a méretezést. A hányadosok mértékegység nélküli értékek; az alakzatok pozíciói és méretei pontban vannak megadva. A különböző szélesség‑ és magasságarányok torzíthatják az alakzatokat, és az alakzat méretének megváltoztatása nem méretezi át a betűméreteket.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Számítsa ki a független vízszintes és függőleges méretezési tényezőket.
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

A táblázatok külön kezelést igényelnek: a teljes táblázat szélességét és magasságát helyett a oszlopszélességeket és sormagasságokat kell méretezni. A sormagasságok nagyobbak lehetnek a kért értéknél, ha a cellatartalom több helyet igényel.

{{% /alert %}}

A második példa támogatja a táblázatokat, és a mestereken és elrendezéseken, valamint az egyes diákon lévő alakzatokat is feldolgozza, mielőtt elmenti az átméretezett prezentációt. Segédfüggvénye minden [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) elemet úgy kezel, hogy az oszlopszélességeket a [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) metódussal, a minimális sormagasságokat pedig a [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) metódussal méretezi. Ezután a táblázat pozícióját méretezi, anélkül, hogy külön méretezné a teljes méreteket.

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
                // A táblázat méreteit az oszlopszélességek és a sormagasságok szabályozzák.
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
    // Számítsa ki a független vízszintes és függőleges méretezési tényezőket.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Átméretezze a mestereken és elrendezéseken, valamint az egyes diákon definiált alakzatokat.
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

## **GYIK**

**Miért torzulnak vagy vágódnak le az alakzatok a dia átméretezése után?**

Ha a dia méretét a alakzatok méretezése nélkül változtatja, azok megtartják eredeti pozíciójukat és méretüket, és a dia határain túl is kiterjedhetnek. A szélesség‑ és magasságarányok eltérő mértékre történő alkalmazása szintén torzíthatja az alakzatokat.

**Működik a megadott kód minden alakzattípusra?**

Az első példa közvetlenül módosítja az alakzat határait, és olyan diákra van szánva, amelyek nem tartalmaznak táblázatot. A második példa külön kezeli a táblázatokat. Ellenőrizze a kapott elrendezést, különösen a szöveget és a táblázatokat, mivel ezek a példák nem méretezik át a betűméreteket, és a táblázattartalom korlátozhatja a sormagasságokat.

**Hogyan kell átméretezni a táblázatokat a dia átméretezésekor?**

Méretezze az oszlopszélességeket a szélességarány, a minimális sormagasságokat a magasságarány szerint, majd méretezze a táblázat pozícióját, ahogy a második példában látható.

**Ez a méretezés működik-e a mester‑diákon és az elrendezés‑diákon?**

Igen. A második példa végigjárja a [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) elemeket, valamint minden mester [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) elemét, és ugyanazt az átméretezési logikát alkalmazza az azokban lévő alakzatokra.

**Megváltoztathatom a dia orientációját (álló/ fekvő) a méretezés során?**

Igen. Hívja meg a [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) metódust a dia méretének módosítása után, és még a célméretek beolvasása előtt, hogy a méretezési tényezők a végső orientációt tükrözzék.

**Van korlátozás a beállítható dia méretre?**

Egyéni dia méreteket adhat meg a [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) metódussal. A támogatott méretek függnek a prezentáció formátumától és az alkalmazástól, amelyben a fájlt megnyitja.

**Hogyan akadályozhatom meg, hogy a fix képarányú alakzatok torzuljanak?**

Használja ugyanazt a méretezési tényezőt a szélességre és a magasságra. Az eredeti elrendezés új dia mérethez való igazításához használja a kisebbik arányt mindkét dimenzióhoz és pozícióhoz. Ez megtartja az arányokat, de egy él mentén üres tér maradhat.