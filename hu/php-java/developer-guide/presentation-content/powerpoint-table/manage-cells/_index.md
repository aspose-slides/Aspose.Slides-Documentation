---
title: Táblázatcellák kezelése prezentációkban PHP használatával
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/php-java/manage-cells/
keywords:
- táblázatcella
- cellák egyesítése
- szegély eltávolítása
- cella felosztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Kezelje a PowerPoint táblázatcellákat PHP-ben: azonosítsa az összevont cellákat, távolítsa el a szegélyeket, bontsa szét a cellákat, és állítsa be a háttérszíneket és képeket az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi, hogy hozzáférjünk és módosítsuk a táblázat celláit a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan lehet azonosítani az összevont (összevonott) táblázatcellákat, eltávolítani a cella kereteit, a cellák számozásával dolgozni az egyesítés vagy szétválasztás után, megváltoztatni egy cella háttérszínét, és képet hozzáadni egy táblázatcellához. A példák azt mutatják, hogyan hozhatunk létre vagy nyithatunk meg egy prezentációt, hogyan szerezhetünk be egy táblát egy diából, hogyan frissíthetjük a cella formázását a cella tulajdonságain keresztül, és hogyan menthetjük el a módosított prezentációt PPTX‑fájlként.

Az Aspose.Slides nullától induló indexeket használ a táblázatcellák eléréséhez a `(oszlop, sor)` sorrendben.

## **Összevont táblázatcellák azonosítása**

A példa megnyit egy meglévő prezentációt, és az első dián az első alakzatot táblaként érinti. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat táblázat. Ezután végig iterál az összes soron és oszlopon, és a [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) használatával azonosítja az összevont régiók celláit. Minden egyezésnél kiírja a cella koordinátáit `sor;oszlop` sorrendben, valamint a [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), és a régió kezdő koordinátáit a [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) és [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) segítségével.

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

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) objektumot, és a [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) segítségével adjon egy táblát az első diájához. Az oszlopszélességek, sormagasságok és a táblázat pozíciója pontban van megadva. A példa négy cellaszegélyt is [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) értékre állít, így láthatatlanok lesznek.

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

## **Átlós cellaszegélyek hozzáadása**

A [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) segítségével vonalat húzhat a bal felső sarokból a jobb alsó felé, a [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) segítségével pedig a bal alsó sarokból a jobb felső felé. Egy átló megjelölhet egy sarokfejlécet; mindkét átló X‑et alkothat, jelezve, hogy a cella nem alkalmazható.

Minden átlónak saját [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) van. Az [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) segítségével a [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) használatával válassza a [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) értéket, és egy színt a [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) segítségével. A vonal vastagságát pontban a [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) segítségével állítsa be.

A példa egy sorban három cellát hoz létre: egy piros lefelé mutató átlót, egy kék felfelé mutató átlót és mindkét átlót. A felső, alsó, bal és jobb cellaszegélyeket változatlanul hagyja.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az átló csak a cella formázását módosítja. Minden cella egyetlen szövegkeretet őriz meg, amely a [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) segítségével érhető el. Az átló mindkét oldalán lévő területek nem szerkeszthetők külön-külön.

A mentett tábla, a Microsoft PowerPoint-ben megjelenítve:
![Három táblacella, amely piros átlót mutat a bal felső saroktól a jobb alsóig, kék átlót a bal alsó saroktól a jobb felsőig, és mindkét átló X‑et alkot.](diagonal-cell-borders.png)

*Balról jobbra: lefelé mutató átló (piros, 3 pt), felfelé mutató átló (kék, 5 pt), és mindkét átló.*

## **Táblacellák egyesítése**

A [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) segítségével egy téglalap alakú táblacellatartományt egy cellává egyesíthetünk. Adja meg a tartomány bal felső és jobb alsó celláit. Az utolsó argumentum meghatározza, hogy az egyesítés magában foglalhat-e a megadott tartományon kívüli cellákat; a `false` érték az egyesítést a tartományon belül tartja.

A példa egy 4‑by‑4 táblát hoz létre 70‑pontos oszlopokkal és sorokkal, majd egyesíti a négy középső cellát a `(1, 1)`‑től `(2, 2)`‑ig tartó tartományban. Az eredményül kapott cella két oszlopot és két sort fed le, míg a tábla alaprácsa négy oszlopot és négy sort tartalmaz továbbra is. Az egyesített cella tartalmához vagy formázásához az első bal pozíciót használja: `$table->get_Item(1, 1)` ebben a példában. A tartományon belüli többi pozíció a tábla rácsának része marad, ezért a tartományon kívüli cellák indexei nem változnak.

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

Az előző példában a cellák egyesítése megőrzi a tábla rácsát. Egy cella felosztása új rácsoszlopot hozhat létre, és megváltoztathatja a jobb oldali cellák oszlopszámait. Az Aspose.Slides a PowerPoint táblarács modelljét követi.

Ez a példa egy 4‑by‑4 táblát hoz létre 70‑pontos oszlopokkal és sorokkal, és a `(1, 1)` cellán meghívja a [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) metódust. A cella 70‑pontos szélességének felét adja át, hogy két egyenlő szélességű cellát hozzon létre.

A felosztás után a két felét `$table->get_Item(1, 1)` és `$table->get_Item(2, 1)` módon érhetjük el. A táblarács most öt oszlopot tartalmaz: az eredetileg a 2‑ és 3‑as oszlopban lévő cellák a 3‑as és 4‑es oszlopba kerülnek. A sorindexek változatlanok maradnak. A felosztás utáni cellák eléréséhez használja ezeket a frissített oszlopszámokat.

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

<!-- visual-explanation:manage-cells:start -->
[![Egy nem egyesített 70‑pontos cella két 35‑pontos cellára oszlik, hozzáadva egy ötödik rácsoszlopot és eltolva a jobb oldali indexeket.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*The width split affects cell (1, 1), using zero-based (column, row) indices. Other rows keep a cell spanning both new column positions.*
<!-- visual-explanation:manage-cells:end -->

### **Összevont cellák felosztása sor- vagy oszlopszélesség alapján**

Az összevont sabloncellák adatkitöltésre való előkészítéséhez használja a [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) metódust a meglévő sorhatár mentén történő felosztáshoz, vagy a [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) metódust az oszlophatár mentén történő felosztáshoz.

Az `index` argumentum a felosztás felső részében lévő sorok vagy a bal részben lévő oszlopok számát jelöli; a összevont területhez képest relatív:

- Sorfelosztás: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Oszlopfelosztás: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

A példa azt feltételezi, hogy a prezentáció első diájának első alakzata egy táblázat, amelyben a `(1, 2)` és `(1, 3)` cellák függőlegesen egyesültek. Az alsó pozíciótól kezdve a [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) és [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) segítségével határozza meg a kiindulópontot, és ellenőrzi mindkét átfedést. A `splitByRowSpan(1)` ekkor szétválasztja a 2‑es és 3‑as sorokat a terméknevekhez. Egy vízszintes kétoszlopos egyesítéshez használja a `splitByColSpan(1)`‑et.

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

        // A felosztás után lekérdezi a táblából származó cellákat.
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

A táblarács és a környező cella indexek változatlanok maradnak. A kapott cellákat a koordinátáik alapján lehet lekérni; itt mindkettő 1‑es átfedéssel rendelkezik, és a [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) `false`‑t ad vissza. Nagyobb területek egy felosztás után is részben összevonva maradhatnak.

Az eredeti szöveg és annak formázása az felső (vagy bal) cellában marad; az új cella üres, de örökli a cella formázását, például a kitöltést, a szegélyeket és a margókat. A felosztás után töltse fel a cellákat, és állítsa be a szükséges szövegformázást kifejezetten.

A mentett prezentáció külön "Product A" és "Product B" cellákat tartalmaz, a sablon cellaformázása megmarad. További részletekért lásd a [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) oldalt.

### **Cellát felosztás meghatározott magasságban**

A [splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) a felső rész magasságát pontban veszi. A [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) a felső részben lévő meglévő rácssorok számát veszi. Egy 40‑pontos cella jobb oszlopban való középre helyezéséhez vonja ki 40‑et a cella tényleges magasságából, és az így megmaradt teret egyenlő részre osztja fel felül és alul.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az első felosztás egy rácssort ad hozzá, és a `(1, 1)` cellában 90 pontot hagy alul. A második felosztás a cellát egy 40‑pontos középső cellára és egy 50‑pontos alsó cellára bontja. A jobb oszlop most három cellát tartalmaz, magasságuk felülről lefelé 50, 40 és 50 pont. A bal cella mindhárom sort lefedi, és megtartja az eredeti 140‑pontos magasságát.

![A bal cella a teljes táblamagasságot lefedi, mellette három cella van, a középső a középső cellával.](split-by-height.png)

## **Táblacella háttérszínének módosítása**

Ez a példa egy táblát hoz létre 150‑pontos oszlopokkal és 50‑pontos sorokkal. A [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) segítségével választ ki egy szilárd kitöltést, és a [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) által visszaadott színt pirosra állítja a `(2, 3)` cellában, ami a harmadik oszlopban és a negyedik sorban található.

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

## **Kép hozzáadása egy táblacellához**

A bemeneti képet helyezze a munkakönyvtárba, mielőtt futtatná ezt a példát. A [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) segítségével betölti a képet, és a [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) segítségével hozzáadja a prezentáció képgyűjteményéhez. Ezután a képet a `(0, 0)` cella (a tábla első cellája) képkitöltéséhez rendeli.

A [PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) a képet a cellába nyújtja, ami megváltoztathatja a képarányt. Az oszlopszélességek és sormagasságok pontban vannak megadva. A betöltött képet a `finally` blokkban szabadítja fel, miután hozzáadta a prezentációhoz.

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

**Beállíthatok különböző vonalvastagságokat és stílusokat egy cella különböző oldalaira?**

Igen. A [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) szegélyeknek külön tulajdonságaik vannak, így minden oldal vastagsága és stílusa különböző lehet.

**Mi történik a képpel, ha a képet a cella háttérképként beállítva megváltoztatom az oszlop/sor méretét?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/)‑tól függ (stretch/tile). Nyújtás esetén a kép az új cellához alkalmazkodik; csempézés esetén a csempéket újraszámítják.

**Hozzá tudok-e rendelni hiperhivatkozást a cella összes tartalmához?**

A [Hiperhivatkozások](/slides/hu/php-java/manage-hyperlinks/) a cella szövegkeretén belül szöveg (rész) szinten vagy a teljes táblázat/alakzat szintjén állítható be. Gyakorlatban a hivatkozást egy részhez vagy a cella teljes szövegéhez rendeli.

**Beállíthatok-e különböző betűtípusokat egyetlen cellában?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (szövegrészek) használatát, amelyeknek független a formázása – betűtípus, stílus, méret és szín.