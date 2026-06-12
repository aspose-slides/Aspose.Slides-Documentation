---
title: Správa tabulek v prezentacích v PHP
linktitle: Spravovat tabulku
type: docs
weight: 10
url: /cs/php-java/manage-table/
keywords:
- přidat tabulku
- vytvořit tabulku
- přístup k tabulce
- poměr stran
- zarovnat text
- formátování textu
- styl tabulky
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v prezentacích PowerPoint pomocí Aspose.Slides pro PHP přes Java. Objevte jednoduché příklady kódu, které zjednoduší vaše workflow s tabulkami."
---
## **Úvod**

Tabulka v PowerPointu je efektivní způsob, jak zobrazit a vyjádřit informace. Informace v mřížce buněk (uspořádaných v řádcích a sloupcích) jsou přehledné a snadno pochopitelné.

Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Table) třídu [Cell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cell/) a další typy, které vám umožní vytvářet, aktualizovat a spravovat tabulky ve všech druzích prezentací.

## **Vytvoření tabulky od nuly**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Definujte pole `columnWidth`.
4. Definujte pole `rowHeight`.
5. Přidejte objekt [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/table/) na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addtable/).
6. Procházejte každou [Cell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cell/) , abyste použili formátování na horní, dolní, pravý a levý okraj.
7. Sloučte první dvě buňky první řady tabulky.
8. Získejte přístup k [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) buňky [Cell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cell/).
9. Přidejte text do [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/).
10. Uložte upravenou prezentaci.

Tento kód PHP vám ukazuje, jak vytvořit tabulku v prezentaci:

```php
  # Instancuje třídu Presentation, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přistupuje k prvnímu snímku
    $sld = $pres->getSlides()->get_Item(0);
    # Definuje sloupce s šířkami a řádky s výškami
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Přidá tvar tabulky na snímek
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Nastaví formát okrajů pro každou buňku
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # Sloučí buňky 1 a 2 v řádku 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Přidá text do sloučené buňky
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Uloží prezentaci na disk
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Číslování ve standardní tabulce**

Ve standardní tabulce je číslování buněk přímé a začíná od nuly. První buňka v tabulce má index 0,0 (sloupec 0, řádek 0).

Například buňky v tabulce se 4 sloupci a 4 řádky jsou číslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento kód PHP vám ukazuje, jak určit číslování buněk v tabulce:

```php
  # Instancuje třídu Presentation, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přistupuje k prvnímu snímku
    $sld = $pres->getSlides()->get_Item(0);
    # Definuje sloupce s šířkami a řádky s výškami
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Přidá tvar tabulky na snímek
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Nastaví formát okrajů pro každou buňku
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
    # Uloží prezentaci na disk
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přístup k existující tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
2. Získejte referenci na snímek obsahující tabulku pomocí jeho indexu.
3. Vytvořte objekt [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Table) a nastavte jej na null.
4. Procházejte všechny objekty [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/) , dokud není tabulka nalezena.

   Pokud předpokládáte, že snímek, se kterým pracujete, obsahuje jedinou tabulku, můžete jednoduše zkontrolovat všechny jeho tvary. Když je tvar rozpoznán jako tabulka, můžete jej přetypovat na objekt [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Table). Pokud však snímek obsahuje několik tabulek, je lepší hledat požadovanou tabulku pomocí jejího [setAlternativeText(String value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/setalternativetext/).

5. Použijte objekt [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Table), abyste pracovali s tabulkou. V níže uvedeném příkladu jsme přidali nový řádek do tabulky.
6. Uložte upravenou prezentaci.

Tento kód PHP vám ukazuje, jak přistupovat k existující tabulce a s ní pracovat:

```php
  # Vytvoří instanci třídy Presentation, která představuje soubor PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Přistupuje k prvnímu snímku
    $sld = $pres->getSlides()->get_Item(0);
    # Inicializuje null TableEx
    $tbl = null;
    # Prochází tvary a nastaví referenci na nalezenou tabulku
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Nastaví text pro první sloupec druhého řádku
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Uloží upravenou prezentaci na disk
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zarovnání textu v tabulce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte objekt [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Table) na snímek.
4. Získejte objekt [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) z tabulky.
5. Získejte [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/).
6. Zarovnejte text vertikálně.
7. Uložte upravenou prezentaci.

Tento kód PHP vám ukazuje, jak zarovnat text v tabulce:

```php
  # Vytvoří instanci třídy Presentation
  $pres = new Presentation();
  try {
    # Získá první snímek
    $slide = $pres->getSlides()->get_Item(0);
    # Definuje sloupce s šířkami a řádky s výškami
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Přidá tvar tabulky na snímek
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Přistupuje k textovému rámci
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Vytvoří objekt Paragraph pro textový rámec
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Vytvoří objekt Portion pro odstavec
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Zarovná text vertikálně
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Uloží prezentaci na disk
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavení formátování textu na úrovni tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Získejte objekt [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Table) ze snímku.
4. Nastavte [setFontHeight(float value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setFontHeight) pro text.
5. Nastavte [setAlignment(int value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setalignment/) a [setMarginRight(float value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Nastavte [setTextVerticalType(byte value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Uložte upravenou prezentaci.

Tento kód PHP vám ukazuje, jak použít požadované možnosti formátování na text v tabulce:

```php
  # Vytvoří instanci třídy Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # Předpokládejme, že první tvar na první snímku je tabulka
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Nastaví výšku fontu buněk tabulky
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Nastaví zarovnání textu buněk tabulky a pravý okraj v jednom volání
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Nastaví vertikální typ textu buněk tabulky
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Získání vlastností stylu tabulky**

Aspose.Slides vám umožňuje získat vlastnosti stylu tabulky, abyste je mohli použít pro jinou tabulku nebo jinde. Tento kód PHP vám ukazuje, jak získat vlastnosti stylu z přednastaveného stylu tabulky:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// změnit výchozí přednastavený styl

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Uzamčení poměru stran tabulky**

Poměr stran geometrického tvaru je poměr jeho velikostí v různých rozměrech. Aspose.Slides poskytuje metodu [setAspectRatioLocked](https://reference.aspose.com/slides/cs/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) , která vám umožní uzamknout nastavení poměru stran pro tabulky a další tvary.

Tento kód PHP vám ukazuje, jak uzamknout poměr stran pro tabulku:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku a text v jejích buňkách?**

Ano. Tabulka poskytuje metodu [setRightToLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/table/setrighttoleft/) , a odstavce mají [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setrighttoleft/) . Použitím obou zajišťujete správné RTL pořadí a vykreslování uvnitř buněk.

**Jak mohu zabránit uživatelům v přesouvání nebo změně velikosti tabulky v konečném souboru?**

Použijte zamykání tvarů k zakázání přesunu, změny velikosti, výběru atd. Tato zamknutí platí i pro tabulky.

**Je podporováno vložení obrázku uvnitř buňky jako pozadí?**

Ano. Můžete nastavit [picture fill](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/) , aby buňka měla obrázek jako výplň; obrázek pokryje oblast buňky podle zvoleného režimu (roztažení nebo dlaždice).