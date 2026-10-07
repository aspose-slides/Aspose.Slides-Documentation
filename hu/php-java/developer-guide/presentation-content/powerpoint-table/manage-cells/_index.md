---
title: Táblacellák kezelése prezentációkban PHP használatával
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/php-java/manage-cells/
keywords:
- táblacella
- cellák egyesítése
- szegély eltávolítása
- cellák felosztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "PowerPoint táblacellák kezelése PHP-ben: összeolvasztott cellák azonosítása, szegélyek eltávolítása, cellák felosztása, valamint háttérszínek és képek beállítása az Aspose.Slides segítségével PHP számára Java-on keresztül."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a táblacellák elérését és módosítását PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan azonosíthatók az összeolvadt táblacellák, hogyan távolíthatók el a cellaszegélyek, hogyan kezelhető a cellaszámozás összeolvasztás vagy szétbontás után, hogyan változtatható meg egy cella háttérszíne, és hogyan adható kép a táblacellán belül. A példák bemutatják, hogyan hozhatunk létre vagy nyithatunk meg egy prezentációt, hogyan szerezzünk be egy táblát egy diáról, hogyan frissítsük a cella formázását a cella tulajdonságain keresztül, és hogyan menthetjük el a módosított prezentációt PPTX fájlként.

Az Aspose.Slides nullával kezdődő indexeket használ a táblacellák eléréséhez a `(oszlop, sor)` sorrendben.

## **Összeolvadt táblacella azonosítása**

A példa megnyit egy meglévő prezentációt, és az első dia első alakzatát táblaként használja. Feltételezi, hogy a dia és az alakzat létezik, valamint hogy az alakzat egy tábla. Ezután végigiterál az összes soron és oszlopon, és a [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) segítségével azonosítja az összeolvadt területeket. Minden egyezésnél kiírja a cella koordinátáit `sor;oszlop` sorrendben, a [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), a [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), valamint a régió kezdőkoordinátáit a [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) és a [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) segítségével.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Táblacella szegélyek eltávolítása**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) objektumot, és adjon egy táblát az első diájához az [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) segítségével. Az oszlopszélességek, sormagasságok és a tábla pozíciója pontban van megadva. A példa mind a négy cellaszegélyt a [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) értékre állítja, így láthatatlanok.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Táblacellák egyesítése**

Használja a [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) metódust egy téglalap alakú cellatartomány egy cellává egyesítéséhez. Adja meg a tartomány bal‑felső és jobb‑alsó sarkának celláit. Az utolsó argumentum határozza meg, hogy az egyesítés tartalmazhat‑e a megadott tartományon kívüli cellákat; a `false` érték a tartományon belül tartja az egyesítést.

A példa egy 4‑by‑4 táblát hoz létre 70 pont széles oszlopokkal és sorokkal, majd egyesíti a négy középső cellát `(1, 1)`‑től `(2, 2)`‑ig. Az eredményül kapott cella két oszlopot és két sort fed le, míg a tábla alaprácsa négy oszlopot és négy sort tartalmaz továbbra is. Az egyesített cella tartalmának vagy formázásának eléréséhez használja a bal‑felső pozíciót: `$table->get_Item(1, 1)` ebben a példában. A többi pozíció a egyesített tartományban a tábla rácsának része marad, ezért a tartományon kívüli cellák indexei nem változnak.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Táblacellák felosztása**

Az előző példában az egyesítés megőrzi a tábla rácsát. Egy cella felosztása új rácsoloszlopot hozhat létre, és megváltoztathatja a jobbra lévő cellák oszlopindexeit. Az Aspose.Slides a PowerPoint táblarács‑modelljét követi.

Ez a példa egy 4‑by‑4 táblát hoz létre 70 pont széles oszlopokkal és sorokkal, és a `[splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/)` metódust hívja a `(1, 1)` cellán. A cella 70 pont szélességének felét adja át két egyenlő szélességű cella létrehozásához.

A felosztás után a két felét a `$table->get_Item(1, 1)` és a `$table->get_Item(2, 1)` segítségével érhetjük el. A tábla rácsa most öt oszlopot tartalmaz: az eredetileg a 2‑ és 3‑as oszlopokban lévő cellák a 3‑as és 4‑es oszlopokba kerülnek. A sorindexek változatlanok maradnak. A felosztás után a cellák elérésénél használja ezeket a frissített oszlopindexeket.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Összeolvadt cellák felosztása sor‑ vagy oszlop‑kiterjedés szerint**

Az összeolvadt sabloncellák adatkitöltéshez való előkészítéséhez használja a [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) metódust egy meglévő sorhatár mentén, vagy a [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) metódust oszlophatár mentén.

Az `index` argumentum a felosztás felső részében lévő sorokat vagy a bal részben lévő oszlopokat számolja; a megadott szám a összeolvadt régióra vonatkozik:

- Sor‑felosztás: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Oszlop‑felosztás: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

A példa feltételezi, hogy a prezentáció első diáján az első alakzat egy tábla, ahol a `(1, 2)` és `(1, 3)` cellák függőlegesen össze vannak olvasztva. Az alsó pozícióból a [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) és a [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) segítségével meghatározza a kiindulási pontot, és ellenőrzi mindkét kiterjedést. A `splitByRowSpan(1)` ezután szétválasztja a 2‑es és 3‑as sorokat a terméknevekhez. Vízszintes kétszintes oszlop‑összeolvasztáshoz használja a `splitByColSpan(1)`-et.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // A felosztás után a táblából származó cellák lekérése.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

A táblarács és a környező cellaindexek változatlanok maradnak. A keletkezett cellákat a koordinátáik alapján érje el; itt mindkettő 1‑es kiterjedéssel rendelkezik, és a [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) `false` értéket ad vissza. Nagyobb régiók egy felosztás után is maradhatnak részben összeolvasztva.

Az eredeti szöveg és formázás a felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, például a kitöltést, a szegélyeket és a margókat. A felosztás után töltse fel a cellákat, és állítsa be a szükséges szövegformázást explicit módon.

A mentett prezentáció külön „Product A” és „Product B” cellákat tartalmaz, a sablon cellaformázása megtartva. Tekintse meg a [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) részleteit.

## **A táblacella háttérszínének módosítása**

Ez a példa egy 150 pont széles oszlopokkal és 50 pont magas sorokkal rendelkező táblát hoz létre. A [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) segítségével szilárd kitöltést választ, majd a [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) által visszaadott színt pirosra állítja a `(2, 3)` cellához, ami a harmadik oszlopban és a negyedik sorban található.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kép hozzáadása a táblacellába**

A bemeneti képet helyezze a munkakönyvtárba a példa futtatása előtt. A képet a [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) töltik be, és a prezentáció képgyűjteményéhez az [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) segítségével adják hozzá. Ezután a képet a `(0, 0)` cella képkitöltéséhez rendeli, amely a tábla első cellája.

A [PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) a képet a cellába nyújtja, ami megváltoztathatja az arányait. Az oszlopszélességek és sor‑magasságok pontban vannak megadva. A betöltött képet egy `finally` blokkban szabadítják fel, miután hozzáadták a prezentációhoz.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**Beállíthatok különböző vonalvastagságot és stílust a cella egyes oldalaihoz?**

Igen. A [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) szegélyeknek külön‑külön tulajdonságaik vannak, így minden oldal vastagsága és stílusa eltérő lehet.

**Mi történik a képpel, ha a képet egy cella háttérként beállítva módosítom az oszlop/sor méretét?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile) függvénye. Nyújtás esetén a kép a új cellához igazodik, csempézés esetén a csempéket újraszámolják.

**Hozzá tudok-e rendelni hiperhivatkozást a cella teljes tartalmához?**

A [Hyperlinks](/slides/hu/php-java/manage-hyperlinks/) beállíthatók a cella szövegkeretén belüli szövegrész (portion) szintjén, vagy a teljes táblához/alakzathoz. Gyakorlati szempontból a linket vagy egy részhez, vagy a cella teljes szövegéhez rendeli.

**Beállíthatok-e különböző betűtípusokat egy cellán belül?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (futtatások) független formázását – betűcsalád, stílus, méret és szín.