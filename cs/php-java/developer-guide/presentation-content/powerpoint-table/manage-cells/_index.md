---
title: Spravovat buňky tabulky v prezentacích pomocí PHP
linktitle: Spravovat buňky
type: docs
weight: 30
url: /cs/php-java/manage-cells/
keywords:
- buňka tabulky
- sloučit buňky
- odstranit okraj
- rozdělit buňku
- obrázek v buňce
- barva pozadí
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte buňky tabulky PowerPoint v PHP: identifikujte sloučené buňky, odstraňte okraje, rozdělte buňky a nastavte barvy pozadí a obrázky pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides vám umožňuje přistupovat k buňkám tabulky a měnit je v prezentacích PowerPoint. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit okraje buněk, pracovat s číslováním buněk po sloučení nebo rozdělení buněk, změnit barvu pozadí buňky a přidat obrázek uvnitř buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buňky pomocí vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

Aspose.Slides používá nulové indexy pro přístup k buňkám tabulky v pořadí `(column, row)`.

## **Identifikovat sloučenou buňku tabulky**

Příklad otevře existující prezentaci a přistoupí k prvnímu tvaru na prvním snímku jako k tabulce. Předpokládá, že snímek a tvar existují a že tvar je tabulka. Poté prochází všechny řádky a sloupce a používá [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) k identifikaci buněk ve sloučených oblastech. Pro každou shodu vypíše souřadnice buňky v pořadí `row;column`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), a počáteční souřadnice oblasti, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) a [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

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

## **Odstranit okraje buňky tabulky**

Vytvořte [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) a přidejte tabulku na jeho první snímek pomocí [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Šířky sloupců, výšky řádků a umístění tabulky jsou zadány v bodech. Příklad nastaví všechny čtyři okraje buňky na [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), čímž je učiní neviditelnými.

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

## **Sloučit buňky tabulky**

Použijte [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) k sloučení obdélníkového rozsahu buněk tabulky do jedné buňky. Zadejte buňky v levém horním a pravém dolním rohu rozsahu. Poslední argument určuje, zda sloučení může zahrnovat buňky mimo zadaný rozsah; `false` udrží sloučení uvnitř tohoto rozsahu.

Příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů, poté sloučí čtyři centrální buňky od `(1, 1)` po `(2, 2)`. Výsledná buňka rozkládá přes dva sloupce a dva řádky, zatímco základní mřížka tabulky si zachová čtyři sloupce a čtyři řádky. Pro přístup k obsahu nebo formátování sloučené buňky použijte její pozici v levém horním rohu: `$table->get_Item(1, 1)` v tomto příkladu. Ostatní pozice ve sloučeném rozsahu zůstávají součástí mřížky tabulky, takže indexy buněk mimo rozsah se nemění.

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

## **Rozdělit buňky tabulky**

Sloučení buněk v předchozím příkladu zachovává mřížku tabulky. Rozdělení buňky může zavést nový sloupec v mřížce a změnit indexy sloupců buněk vpravo od ní. Aspose.Slides se řídí modelem mřížky tabulky v PowerPointu.

Tento příklad vytvoří tabulku 4 × 4 se sloupci a řádky o šířce 70 bodů a zavolá [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) na buňku `(1, 1)`. Polovina šířky buňky 70 bodů je použita k vytvoření dvou buněk stejné šířky.

Po tomto rozdělení jsou dvě poloviny přístupné jako `$table->get_Item(1, 1)` a `$table->get_Item(2, 1)`. Mřížka tabulky nyní má pět sloupců: buňky původně ve sloupcích 2 a 3 se přesunou na sloupce 3 a 4, respektive. Indexy řádků zůstávají nezměněny. Používejte tyto aktualizované indexy sloupců při přístupu k buňkám po rozdělení.

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

### **Rozdělit sloučené buňky podle řádku nebo sloupce**

Pro přípravu sloučených buněk šablony na naplnění dat použijte [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) k rozdělení podél existující hranice řádku, nebo [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) k rozdělení podél hranice sloupce.

Argument `index` počítá řádky v horní části nebo sloupce v levé části rozdělení; je relativní k sloučenému regionu:

- Rozdělení řádku: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Rozdělení sloupce: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Příklad předpokládá, že prezentace má tabulku jako první tvar na prvním snímku, přičemž `(1, 2)` a `(1, 3)` jsou sloučeny vertikálně. Začínaje od spodní pozice, používá [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) a [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) k nalezení počátku a kontroluje oba rozsahy. `splitByRowSpan(1)` pak oddělí řádky 2 a 3 pro názvy produktů. Pro horizontální sloučení dvou sloupců použijte místo toho `splitByColSpan(1)`.

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

        // Získejte vzniklé buňky z tabulky po rozdělení.
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

Mřížka tabulky a okolní indexy buněk zůstávají nezměněny. Získejte výsledné buňky podle jejich souřadnic; zde mají obě rozsahy 1 a [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) vypíše `false`. Větší oblasti mohou po jednom rozdělení zůstat částečně sloučené.

Původní text a jeho formátování zůstává v horní (nebo levé) buňce; nová buňka je prázdná, ale dědí formátování buňky, jako je výplň, okraje a okraje. Naplňte buňky po rozdělení a nastavení požadovaného formátování textu proveďte explicitně.

Uložená prezentace obsahuje samostatné buňky „Product A“ a „Product B“ s zachovaným formátováním buněk šablony. Viz [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) pro podrobnosti.

## **Změnit barvu pozadí buňky tabulky**

Tento příklad vytvoří tabulku se sloupci o šířce 150 bodů a řádky o výšce 50 bodů. Používá [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) k výběru plné výplně a nastavuje barvu vrácenou metodou [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) na červenou pro buňku `(2, 3)`, ve třetím sloupci a čtvrtém řádku.

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

## **Přidat obrázek do buňky tabulky**

Umístěte vstupní obrázek do pracovního adresáře před spuštěním tohoto příkladu. Načte obrázek pomocí [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) a přidá jej do kolekce obrázků prezentace pomocí [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Poté přiřadí obrázek k výplni obrázku buňky `(0, 0)`, první buňky v tabulce.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) roztahuje obrázek tak, aby vyplnil buňku, což může změnit jeho poměr stran. Šířky sloupců a výšky řádků jsou v bodech. Načtený obrázek je uvolněn v bloku `finally` po jeho přidání do prezentace.

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

## **FAQ**

**Mohu nastavit různé tloušťky a styly čar pro různé strany jedné buňky?**

Ano. Okraje [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit.

**Co se stane s obrázkem, pokud po nastavení obrázku jako pozadí buňky změníme velikost sloupce/řádku?**

Chování závisí na [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). Při roztahování se obrázek přizpůsobí nové buňce; při dlaždicování se dlaždice přepočítají.

**Mohu přiřadit hyperodkaz k celému obsahu buňky?**

[Hyperlinks](/slides/cs/php-java/manage-hyperlinks/) jsou nastaveny na úrovni textu (portion) uvnitř textového rámce buňky nebo na úrovni celé tabulky/tvaru. V praxi přiřadíte odkaz k části nebo k veškerému textu v buňce.

**Mohu nastavit různé fonty v jedné buňky?**

Ano. Textový rámec buňky podporuje [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (běhy) s nezávislým formátováním – rodinu písma, styl, velikost a barvu.