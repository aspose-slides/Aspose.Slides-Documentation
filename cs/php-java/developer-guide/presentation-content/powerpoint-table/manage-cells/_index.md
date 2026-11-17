---
title: Správa buněk tabulky v prezentacích pomocí PHP
linktitle: Správa buněk
type: docs
weight: 30
url: /cs/php-java/manage-cells/
keywords:
- buňka tabulky
- sloučení buněk
- odstranění okraje
- rozdělení buňky
- obrázek v buňce
- barva pozadí
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte buňky tabulky PowerPoint v PHP: identifikujte sloučené buňky, odstraňujte okraje, rozdělujte buňky a nastavujte barvy pozadí a obrázky pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides umožňuje přístup k buňkám tabulky a jejich úpravu v prezentacích PowerPoint. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit okraje buněk, pracovat s číslováním buněk po sloučení nebo rozdělení buněk, změnit barvu pozadí buňky a přidat obrázek do buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buněk pomocí vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

Aspose.Slides používá nulové indexování pro přístup k buňkám tabulky v pořadí `(column, row)`.

## **Identifikace sloučené buňky tabulky**

Příklad otevře existující prezentaci a přistoupí k prvnímu tvaru na prvním snímku jako k tabulce. Předpokládá, že snímek a tvar existují a že tvar je tabulka. Poté iteruje přes všechny řádky a sloupce a používá [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) k identifikaci buněk ve sloučených oblastech. Pro každou shodu vypíše souřadnice buňky v pořadí `row;column`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), a počáteční souřadnice oblasti, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) a [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

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

## **Odstranění okrajů buněk tabulky**

Vytvořte [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) a přidejte tabulku na jeho první snímek pomocí [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Šířky sloupců, výšky řádků a pozice tabulky jsou zadány v bodech. Příklad nastaví všechny čtyři okraje buňky na [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), čímž je učiní neviditelnými.

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

## **Přidání úhlopříčných okrajů buňky**

Použijte [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) k nakreslení čáry z levého horního rohu do pravého dolního a [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) k nakreslení čáry z levého dolního rohu do pravého horního. Úhlopříčka může označovat hlavičku rohu; obě úhlopříčky mohou vytvořit X pro označení buňky jako neplatné.

Každá úhlopříčka má svůj vlastní [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/). V jeho [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/), použijte [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) k výběru [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) a zvolte barvu pomocí [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/). Šířku čáry v bodech nastavte pomocí [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/).

Příklad vytvoří tři buňky v jednom řádku: červenou úhlopříčku směrem dolů, modrou úhlopříčku směrem nahoru a oba úhlopříčky. Horní, spodní, levý a pravý okraj buňky zůstane nezměněn.

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

Úhlopříčka mění pouze formátování buňky. Každá buňka si zachovává jediný textový rámec, který lze získat pomocí [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/). Oblasti na obou stranách úhlopříčky nelze upravovat samostatně.

Uložená tabulka, vykreslená v Microsoft PowerPoint:

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*Zleva doprava: úhlopříčka dolů (červená, 3 pt), úhlopříčka nahoru (modrá, 5 pt) a obě úhlopříčky.*

## **Sloučení buněk tabulky**

Použijte [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) k sloučení obdélníkového rozsahu buněk tabulky do jedné buňky. Určete buňky v levém horním a pravém dolním rohu rozsahu. Poslední argument řídí, zda sloučení může zahrnovat buňky mimo zadaný rozsah; `false` ponechá sloučení v rámci tohoto rozsahu.

Příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů, poté sloučí čtyři střední buňky od `(1, 1)` do `(2, 2)`. Výsledná buňka zasahuje dva sloupce a dva řádky, zatímco základní mřížka tabulky si zachová čtyři sloupce a čtyři řádky. Pro přístup k obsahu nebo formátování sloučené buňky použijte její levou horní pozici: `$table->get_Item(1, 1)` v tomto příkladu. Ostatní pozice ve sloučeném rozsahu zůstávají součástí mřížky tabulky, takže indexy buněk mimo rozsah se nezmění.

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

## **Rozdělení buněk tabulky**

Sloučení buněk v předchozím příkladu zachovává mřížku tabulky. Rozdělení buňky může zavést nový sloupec v mřížce a změnit indexy sloupců buněk vpravo od ní. Aspose.Slides se řídí modelem mřížky tabulky v PowerPointu.

Příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů a zavolá [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) na buňku `(1, 1)`. Polovina šířky buňky 70 bodů se použije k vytvoření dvou buněk se stejnou šířkou.

Po tomto rozdělení se k oběma polovinám přistupuje jako `$table->get_Item(1, 1)` a `$table->get_Item(2, 1)`. Mřížka tabulky nyní má pět sloupců: buňky původně ve sloupcích 2 a 3 se přesunou do sloupců 3 a 4. Indexy řádků zůstávají nezměněny. Používejte tyto aktualizované indexy sloupců při přístupu k buňkám po rozdělení.

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
[![An unmerged 70-point cell splits into two 35-point cells, adding a fifth grid column and shifting the indices to its right.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Rozdělení šířky postihuje buňku (1, 1) s nulovými indexy (column, row). Ostatní řádky si zachovávají buňku prostupující oba nové sloupce.*
<!-- visual-explanation:manage-cells:end -->

### **Rozdělení sloučených buněk podle řádkového nebo sloupcového rozpětí**

Pro přípravu sloučených šablonových buněk na naplnění dat použijte [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) k rozdělení podél existující řádkové hranice nebo [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) k rozdělení podél sloupcové hranice.

Argument `index` počítá řádky v horní části nebo sloupce v levé části rozdělení; je relativní k sloučenému regionu:

- Rozdělení řádku: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Rozdělení sloupce: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Příklad předpokládá, že prezentace má tabulku jako první tvar na prvním snímku, kde jsou buňky `(1, 2)` a `(1, 3)` sloučeny vertikálně. Začínaje od nižší pozice, používá [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) a [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) k nalezení počátku a kontroluje oba rozpětí. `splitByRowSpan(1)` pak oddělí řádky 2 a 3 pro názvy produktů. Pro vodorovné sloučení dvou sloupců použijte místo toho `splitByColSpan(1)`.

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

        // Získat výsledné buňky z tabulky po rozdělení.
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

Mřížka tabulky a okolní indexy buněk zůstávají nezměněny. Získejte výsledné buňky podle jejich souřadnic; zde mají obě rozpětí 1 a [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) vypíše `false`. Větší oblasti mohou po jednom rozdělení zůstat částečně sloučeny.

Původní text a jeho formátování zůstávají v horní (nebo levé) buňce; nová buňka je prázdná, ale dědí formátování buňky, jako je výplň, okraje a okraje. Po rozdělení buňky naplňte a explicitně nastavte požadované formátování textu.

Uložená prezentace obsahuje samostatné buňky „Product A“ a „Product B“ se zachovaným formátováním buněk šablony. Podrobnosti najdete v [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/).

### **Rozdělení buňky na konkrétní výšku**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) přijímá výšku horní části v bodech. [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) přijímá počet existujících řádků mřížky v horní části. Pro vycentrování 40‑bodové buňky ve pravém sloupci odečtěte 40 od skutečné výšky buňky a zbývající prostor rovnoměrně rozdělte nad a pod ní.

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

První rozdělení přidá řádek do mřížky a ponechá v buňce `(1, 1)` spodních 90 bodů. Druhé rozdělení rozdělí tuto buňku na střední buňku o výšce 40 bodů a spodní buňku o výšce 50 bodů. Pravý sloupec nyní obsahuje tři buňky s výškami 50, 40 a 50 bodů shora dolů. Levá buňka prostupuje všechny tři řádky a zachovává svou původní výšku 140 bodů.

![Levá buňka prostupuje celou výškou tabulky vedle tří buněk se střední buňkou uprostřed.](split-by-height.png)

## **Změna barvy pozadí buňky tabulky**

Příklad vytvoří tabulku se sloupci o šířce 150 bodů a řádky o výšce 50 bodů. Použije [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) k výběru plné výplně a nastaví barvu vrácenou metodou [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) na červenou pro buňku `(2, 3)`, ve třetím sloupci a čtvrtém řádku.

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

## **Přidání obrázku do buňky tabulky**

Umístěte vstupní obrázek do pracovního adresáře před spuštěním tohoto příkladu. Načte obrázek pomocí [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile), a přidá jej do kolekce obrázků prezentace pomocí [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Poté přiřadí obrázek jako výplň obrázku buňky `(0, 0)`, první buňky v tabulce.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) roztáhne obrázek tak, aby vyplnil buňku, což může změnit poměr stran. Šířky sloupců a výšky řádků jsou v bodech. Načtený obrázek je uvolněn v bloku `finally` poté, co je přidán do prezentace.

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

## **Často kladené otázky**

**Mohu nastavit různé tloušťky a styly čar pro různé strany jedné buňky?**

Ano. Okraje [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit.

**Co se stane s obrázkem, pokud po nastavení obrázku jako pozadí buňky změníte velikost sloupce/řádku?**

Chování závisí na [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). Při roztahování se obrázek přizpůsobí nové buňce; při dlaždicování se dlaždice přepočítají.

**Mohu přiřadit hypertextový odkaz k veškerému obsahu buňky?**

[Hyperlinks](/slides/cs/php-java/manage-hyperlinks/) se nastavují na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/tvaru. V praxi přiřadíte odkaz buď k části, nebo ke všemu textu v buňce.

**Mohu nastavit různé fonty v jedné buňce?**

Ano. Textový rámec buňky podporuje [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (úseky) s nezávislým formátováním – rodinu písma, styl, velikost a barvu.