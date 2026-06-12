---
title: Správa buněk tabulky v prezentacích pomocí PHP
linktitle: Správa buněk
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
description: "Jednoduše spravujte buňky tabulky v PowerPointu pomocí Aspose.Slides pro PHP. Ovládněte rychlý přístup, úpravy a stylování buněk pro plynulou automatizaci snímků."
---
## **Přehled**

Aspose.Slides vám umožňuje přistupovat k buňkám tabulky a upravovat je v prezentacích PowerPoint. Tento článek vysvětluje, jak identifikovat sloučené buňky tabulky, odstranit okraje buněk, pracovat s číslováním buněk po sloučení nebo rozdělení buněk, změnit barvu pozadí buňky a přidat obrázek do buňky tabulky. Příklady ukazují, jak vytvořit nebo otevřít prezentaci, získat tabulku ze snímku, aktualizovat formátování buňky prostřednictvím vlastností buňky a uložit upravenou prezentaci jako soubor PPTX.

## **Identifikace sloučené buňky tabulky**
1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
2. Získejte tabulku z prvního snímku. 
3. Procházejte řádky a sloupce tabulky a najděte sloučené buňky.
4. Vytiskněte zprávu, když jsou nalezeny sloučené buňky.

Tento kód v PHP vám ukazuje, jak identifikovat sloučené buňky tabulky v prezentaci:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// předpokládá se, že Slide#0.Shape#0 je tabulka

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Odstranění okrajů buněk tabulky**
1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Definujte pole sloupců s šířkou.
4. Definujte pole řádků s výškou.
5. Přidejte tabulku na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addTable).
6. Procházejte každou buňku a odstraňte horní, dolní, pravý a levý okraj.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód v PHP vám ukazuje, jak odstranit okraje z buněk tabulky:

```php
  # Vytvoří instanci třídy Presentation, která reprezentuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přistupuje k prvnímu snímku
    $sld = $pres->getSlides()->get_Item(0);
    # Definuje sloupce s šířkami a řádky s výškami
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Přidá tvar tabulky na snímek
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Nastaví formát okraje pro každou buňku
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # Zapíše soubor PPTX na disk
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Číslování ve sloučených buňkách**
Pokud sloučíme 2 páry buněk (1, 1) x (2, 1) a (1, 2) x (2, 2), výsledná tabulka bude očíslovaná. Tento kód v PHP demonstruje postup:

```php
  # Vytvoří instanci třídy Presentation, která reprezentuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přistupuje k prvnímu snímku
    $sld = $pres->getSlides()->get_Item(0);
    # Definuje sloupce s šířkami a řádky s výškami
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Přidá tvar tabulky na snímek
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Nastaví formát okraje pro každou buňku
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Sloučí buňky (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Sloučí buňky (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Poté dále sloučíme buňky sloučením (1, 1) a (1, 2). Výsledkem je tabulka obsahující velkou sloučenou buňku uprostřed: 

```php
  # Vytvoří instanci třídy Presentation, která reprezentuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přistupuje k prvnímu snímku
    $sld = $pres->getSlides()->get_Item(0);
    # Definuje sloupce s šířkami a řádky s výškami
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Přidá tvar tabulky na snímek
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Nastaví formát okraje pro každou buňku
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Sloučí buňky (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Sloučí buňky (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Sloučí buňky (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Zapíše soubor PPTX na disk
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Číslování v rozdělené buňce**
V předchozích příkladech, když byly buňky tabulky sloučeny, číslování nebo číselný systém v ostatních buňkách se nezměnil. 

Tentokrát vezmeme běžnou tabulku (tabulku bez sloučených buněk) a pak se pokusíme rozdělit buňku (1,1), abychom získali speciální tabulku. Možná budete chtít věnovat pozornost číslování této tabulky, které může působit podivně. Nicméně takto Microsoft PowerPoint čísluje buňky tabulky a Aspose.Slides dělá totéž.

Tento kód v PHP demonstruje popsaný postup:

```php
  # Vytvoří instanci třídy Presentation, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přistupuje k prvnímu snímku
    $sld = $pres->getSlides()->get_Item(0);
    # Definuje sloupce s šířkami a řádky s výškami
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Přidá tvar tabulky na snímek
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Nastaví formát okraje pro každou buňku
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Sloučí buňky (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Sloučí buňky (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Rozdělí buňku (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Zapíše soubor PPTX na disk
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Změna barvy pozadí buňky tabulky**

Tento kód v PHP vám ukazuje, jak změnit barvu pozadí buňky tabulky:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # vytvoří novou tabulku
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # nastaví barvu pozadí buňky
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Přidání obrázku do buňky tabulky**

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Definujte pole sloupců s šířkou.
4. Definujte pole řádků s výškou.
5. Přidejte tabulku na snímek pomocí metody [AddTable](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addTable).
6. Vytvořte objekt `Images` pro uložení souboru obrázku.
7. Přidejte obrázek `IImage` do objektu `IPPImage`.
8. Nastavte pro buňku tabulky `FillFormat` na `Picture`.
9. Přidejte obrázek do první buňky tabulky.
10. Uložte upravenou prezentaci jako soubor PPTX

Tento kód v PHP vám ukazuje, jak umístit obrázek do buňky tabulky při vytváření tabulky:

```php
  # Vytvoří instanci třídy Presentation, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přistupuje k prvnímu snímku
    $islide = $pres->getSlides()->get_Item(0);
    # Definuje sloupce s šířkami a řádky s výškami
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Přidá tvar tabulky na snímek
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Vytvoří objekt IPPImage ze souboru obrázku
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Přidá obrázek do první buňky tabulky
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Uloží soubor PPTX na disk
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Mohu nastavit různou tloušťku a styl čar pro různé strany jedné buňky?**

Ano. Okraje [top](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cellformat/getborderright/) mají samostatné vlastnosti, takže tloušťka a styl každé strany se mohou lišit. To logicky vyplývá z řízení okrajů po stranách buňky, které bylo v článku demonstrováno.

**Co se stane s obrázkem, pokud po nastavení obrázku jako pozadí buňky změníme velikost sloupce/řádku?**

Chování závisí na [fill mode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillmode/). Při natáhnutí se obrázek přizpůsobí nové buňce; při dlaždicování se dlaždice přepočítají. V článku jsou zmíněny režimy zobrazení obrázku v buňce.

**Mohu přiřadit hypertextový odkaz na celý obsah buňky?**

[Hyperlinks](/slides/cs/php-java/manage-hyperlinks/) se nastavují na úrovni textu (části) uvnitř textového rámce buňky nebo na úrovni celé tabulky/objektu. V praxi odkaz přiřadíte buď části, nebo celému textu v buňce.

**Mohu nastavit různá písma v jedné buňce?**

Ano. Textový rámec buňky podporuje [portions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/) (běhy) s nezávislým formátováním — rodinu písma, styl, velikost a barvu.