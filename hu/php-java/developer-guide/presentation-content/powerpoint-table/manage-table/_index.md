---
title: PHP-ben a prezentációs táblák kezelése
linktitle: Táblázat kezelése
type: docs
weight: 10
url: /hu/php-java/manage-table/
keywords:
- táblázat hozzáadása
- táblázat létrehozása
- táblázat elérése
- képarány
- szöveg igazítása
- szövegformázás
- táblázat stílus
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Táblázatok létrehozása és szerkesztése PowerPoint diákon az Aspose.Slides for PHP via Java segítségével. Fedezzen fel egyszerű kódrészleteket, hogy felgyorsítsa a táblázat-munkafolyamatokat."
---
## **Bevezetés**

A PowerPoint táblázatai információkat sorokba és oszlopokba rendeznek, megkönnyítve a értékek olvasását és összehasonlítását.

Az Aspose.Slides a [Táblázat](https://reference.aspose.com/slides/php-java/aspose.slides/table/) osztályt, a [Cella](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) osztályt és egyéb típusokat biztosít, amelyek lehetővé teszik a táblázatok létrehozását, frissítését és kezelését a prezentációkban.

## **Táblázat létrehozása a semmiből**

Hozzon létre egy táblázatot a pozíció, az oszlopszélességek és a sormagasságok megadásával. A diára való beillesztés után formázhatja a cellák szegélyeit, egyesítheti a cellákat és szöveget szúrhat be.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát a diára az indexe alapján.
3. Határozzon meg egy oszlopszélesség‑tömböt pontokban.
4. Határozzon meg egy sormagasság‑tömböt pontokban.
5. Adjon hozzá egy [Táblázat](https://reference.aspose.com/slides/php-java/aspose.slides/table/) objektumot a diára a [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) metódus segítségével.
6. Iteráljon minden [Cella](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) elemen, hogy alkalmazza a felső, alsó, jobb és bal szegélyek formázását.
7. Egyesítse a táblázat első sorának első két celláját.
8. Érje el az egyesített cellát a [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) metódusával.
9. Állítsa be a szöveget az egyesített cellában.
10. Mentse el a módosított prezentációt.

Az alábbi példa három oszlopos és öt soros táblázatot hoz létre (100, 50) pont helyen. Piros szegélyeket alkalmaz 5 pont szélességgel, egyesíti az első sor első két celláját, és a végeredményt `table.pptx` néven menti.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cella indexek nullától indulnak és a (oszlop, sor) sorrendet használják. Az első cella indexe (0, 0).

Például egy 4 oszlopos és 4 soros táblázat cellái így vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a példa létrehozza a fent ábrázolt 4 × 4‑es táblázatot, oszlopszélességgel és sor magassággal 70 pont, és piros cellaszegélyekkel 5 pont szélességgel. A koordináták a cella indexeket mutatják; a példa üresen hagyja a cellákat, és a táblázatot `StandardTables_out.pptx` néven menti.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Meglévő táblázat elérése**

A táblázatokat a dia alakzatgyűjtésében tárolják. Iteráljon az alakzatokon, hogy megtalálja a táblázatot, majd használja a [Táblázat](https://reference.aspose.com/slides/php-java/aspose.slides/table/) osztályt a cellák olvasásához vagy frissítéséhez.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztály segítségével.
2. Szerezzen referenciát a táblázatot tartalmazó diára az indexe alapján.
3. Iteráljon a [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) objektumokon, és álljon meg, amikor táblázatot talál. Ha a dián több táblázat is van, használja a [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) metódust a szükséges azonosításához.
4. Frissítse a szöveget a célcellaban.
5. Mentse el a módosított prezentációt.

Az alábbi példa megnyitja a `UpdateExistingTable.pptx` fájlt, és megtalálja az első táblázatot az első dián. A 0. oszlop, 1. sor celláját `New` értékre állítja, és a végeredményt `table1_out.pptx` néven menti. A bemenetnek legalább egy diát kell tartalmaznia, és az első táblázatnak azon a dián legalább egy oszlop és két sor kell, hogy legyen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

A meglévő táblázat sorának átméretezéséhez és annak megértéséhez, hogy miért lehet a tényleges magasság nagyobb a kért minimumnál, lásd a [Sor magasságának vezérlése](/slides/hu/php-java/manage-rows-and-columns/#control-row-height) oldalt.

## **A szövegkeretet birtokló cella megtalálása**

Amikor egy általános szövegfeldolgozó kód egy [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) objektumot kap egy táblázatból, használja a [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) metódust a tulajdonos [Cella](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) lekéréséhez. Egy táblázatcella szövegkeret esetén a [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) visszaadja a tulajdonost, és a [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) `null` értéket ad, még akkor is, ha maga a táblázat alakzat.

A cellakoordináták a csak olvasható [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) és [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) metódusokkal érhetők el. A [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) szintén csak‑olvasás navigációt biztosít: visszaadja a tulajdonost, de nem változtatja meg a tulajdonjogot. Mindig ellenőrizze a visszakapott cellát a `java_is_null` használatával, mielőtt felhasználná.

A cella‑ és alakzat‑tulajdonosok azonosítását bemutató teljes példa, beleértve a SmartArt‑csomópontokhoz kapcsolódó alakzatokat, elérhető a [Szöveg keresése és cseréje](/slides/hu/php-java/search-and-replace-text/) oldalon.

## **Szöveg igazítása egy táblázatban**

Egyes táblázatcellák függőleges rögzítését és szövegirányát irányíthatja. A szakaszban lévő példa középre helyezi a szöveget az első cellában, és 270 fokkal elforgatja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát a diára az indexe alapján.
3. Adjon hozzá egy [Táblázat](https://reference.aspose.com/slides/php-java/aspose.slides/table/) objektumot a diára.
4. Érje el egy [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) objektumot a táblázatból.
5. Érje el az első [Bekezdés](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) elemet, és állítsa be a szövegét és színét.
6. Állítsa be a cella függőleges rögzítését és a szövegirányt a [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) és a [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/) használatával.
7. Mentse el a módosított prezentációt.

Ez a példa létrehozza a 4 × 4‑es táblázatot oszlopszélességgel 120 pont és sor magassággal 100 pont. Formázza a (0, 0) cella szövegét, értékeket ad a maradék cellákhoz az első sorban, és a végeredményt `Vertical_Align_Text_out.pptx` néven menti.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Szövegformázás beállítása táblázatszinten**

Használja a [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) metódust a szövegformázás alkalmazásához a táblázat összes cellájára. Az eltúlterhelések lehetővé teszik a rész, bekezdés és szövegkeret formázását, így ezek a tulajdonságok iterálás nélkül is beállíthatók.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztály segítségével.
2. Szerezzen referenciát a diára az indexe alapján.
3. Érje el egy [Táblázat](https://reference.aspose.com/slides/php-java/aspose.slides/table/) objektumot a diáról.
4. Állítsa be a betűméretet a [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) metódussal a szöveghez.
5. Állítsa be a bekezdés igazítását és a jobb margót a [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) és a [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) metódusokkal.
6. Állítsa be a szöveg irányát a [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) metódussal.
7. Mentse el a módosított prezentációt.

Az alábbi példa megnyitja a `table.pptx` fájlt, amelynek legalább egy diát kell tartalmaznia, ahol a táblázat az első alakzat. A betűméretet 25 pontra állítja, a bekezdéseket jobbra igazítja 20 pont jobb margóval, és a szöveget függőlegessé teszi. A formázott prezentációt `result.pptx` néven menti.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Táblázat stílus tulajdonságok lekérése**

Használja a [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) metódust a táblázat beállított stílusának olvasásához, és a [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) metódust a hozzárendeléshez. Ez a példa a [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) stílust alkalmaz egy táblázatra, kiírja a beállított értéket, majd ugyanazt a stílust a második táblázatra is alkalmazza. Mindkét táblázat a `table-style.pptx` fájlban mentődik.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Táblázat aránypontjainak zárolása**

Egy táblázat képaránya a szélesség és a magasság aránya. Használja a [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) metódust az arány zárolásához.

Az alábbi példa megnyitja a `pres.pptx` fájlt, amelynek legalább egy diát kell tartalmaznia, ahol a táblázat az első alakzat. Kiírja a jelenlegi zárolási állapotot, engedélyezi az arány zárolását, kiírja a frissített állapotot (`true`), és a végeredményt `pres-out.pptx` néven menti.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt egy teljes táblázat és a celláiban lévő szöveg számára?**

Igen. A táblázat rendelkezik egy [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) metódussal, és a bekezdéseknek is van egy [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/) metódusa. Mindkettő használata biztosítja a helyes RTL sorrendet és a megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg, hogy a felhasználók áthelyezzék vagy átméretezzék a táblázatot a végleges fájlban?**

Használja a [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) funkciót a mozgatás, átméretezés, kiválasztás stb. letiltásához. Ezek a zárolások a táblázatokra is érvényesek.

**Támogatott-e egy kép beillesztése egy cellába háttérként?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) kitöltést egy cellához; a kép a kiválasztott mód szerint (nyújtás vagy csempézés) lefedi a cella területét.