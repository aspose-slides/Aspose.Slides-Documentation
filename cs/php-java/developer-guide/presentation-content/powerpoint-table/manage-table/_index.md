---
title: Správa tabulek prezentací v PHP
linktitle: Spravovat tabulku
type: docs
weight: 10
url: /cs/php-java/manage-table/
keywords:
- přidat tabulku
- vytvořit tabulku
- přístup k tabulce
- poměr stran
- zarovnání textu
- formátování textu
- styl tabulky
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Vytvářejte a upravujte tabulky v PowerPoint snímcích pomocí Aspose.Slides pro PHP přes Java. Objevte jednoduché příklady kódu, které zjednoduší vaše pracovní postupy s tabulkami."
---
## **Úvod**

Tabulky v PowerPointu organizují informace do řádků a sloupců, což usnadňuje čtení a porovnávání hodnot.

Aspose.Slides poskytuje třídu [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) , třídu [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) a další typy, které vám umožňují vytvářet, aktualizovat a spravovat tabulky v prezentacích.

## **Vytvoření tabulky od začátku**

Vytvořte tabulku zadáním její pozice, šířek sloupců a výšek řádků. Po přidání na snímek můžete formátovat okraje buněk, sloučit buňky a vložit text.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Definujte pole šířek sloupců v bodech.
4. Definujte pole výšek řádků v bodech.
5. Přidejte objekt [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) do snímku pomocí metody [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
6. Procházejte každou [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) a aplikujte formátování na horní, dolní, pravý a levý okraj.
7. Sloučte první dvě buňky v první řadě tabulky.
8. Přistupte ke sloučené buňce pomocí její metody [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/).
9. Nastavte text ve sloučené buňce.
10. Uložte upravenou prezentaci.

Níže uvedený příklad vytvoří tabulku se třemi sloupci a pěti řádky na pozici (100, 50) bodů. Aplikuje červené okraje o šířce 5 bodů, sloučí první dvě buňky v první řadě a výsledek uloží jako `table.pptx`.

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

## **Číslování ve standardní tabulce**

Ve standardní tabulce jsou indexy buněk nulové a používají pořadí (sloupec, řádek). První buňka má index (0, 0).

Například buňky v tabulce se 4 sloupci a 4 řádky jsou číslovány takto:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Tento příklad vytvoří 4 × 4 tabulku zobrazenou výše, se šířkami sloupců a výškami řádků 70 bodů a červenými okraji buněk o šířce 5 bodů. Souřadnice ilustrují indexy buněk; příklad nechává buňky prázdné a uloží tabulku jako `StandardTables_out.pptx`.

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

## **Přístup k existující tabulce**

Tabulky jsou uloženy ve sbírce tvarů snímku. Procházejte tvary, abyste našli tabulku, a poté použijte třídu [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) k načtení nebo aktualizaci jejích buněk.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující tabulku podle jeho indexu.
3. Procházejte objekty [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) a zastavte se, když je nalezena tabulka. Pokud snímek obsahuje několik tabulek, použijte [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) k identifikaci té, kterou potřebujete.
4. Aktualizujte text v cílové buňce.
5. Uložte upravenou prezentaci.

Níže uvedený příklad otevře `UpdateExistingTable.pptx` a najde první tabulku na prvním snímku. Nastaví buňku ve sloupci 0, řádku 1 na `New` a výsledek uloží jako `table1_out.pptx`. Vstup musí obsahovat alespoň jeden snímek a první tabulka na tomto snímku musí mít alespoň jeden sloupec a dva řádky.

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

Pro změnu velikosti řádku v existující tabulce a pochopení, proč může jeho skutečná výška přesáhnout požadovanou minimální, viz [Řízení výšky řádku](/slides/cs/php-java/manage-rows-and-columns/#control-row-height).

## **Najděte buňku, která vlastní textový rámec**

Když obecný kód pro zpracování textu získá [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) z tabulky, použijte metodu [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) k získání vlastnické [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/). Pro textový rámec buňky tabulky metoda [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) vrací vlastníka a [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) vrací `null`, i když je tabulka sama o sobě tvarem.

Souřadnice buňky jsou dostupné přes jen pro čtení metody [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) a [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/). Metoda [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) také poskytuje jen pro čtení navigaci: vrací vlastníka, ale nezmění vlastnictví. Vždy před použitím zkontrolujte vrácenou buňku pomocí `java_is_null`.

Pro kompletní příklad, který identifikuje vlastníky buňky tabulky a tvaru, včetně tvarů spojených se SmartArt uzly, viz [Vyhledat a nahradit text](/slides/cs/php-java/search-and-replace-text/).

## **Zarovnání textu v tabulce**

Můžete řídit vertikální ukotvení a směr textu jednotlivých buněk tabulky. Příklad v této sekci vycentruje text v první buňce a otočí jej o 270 stupňů.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte objekt [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) do snímku.
4. Získejte objekt [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) z tabulky.
5. Získejte první [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) a nastavte jeho text a barvu.
6. Nastavte vertikální ukotvení buňky a směr textu pomocí [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) a [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/).
7. Uložte upravenou prezentaci.

Tento příklad vytvoří 4 × 4 tabulku se šířkami sloupců 120 bodů a výškami řádků 100 bodů. Naformátuje text v buňce (0, 0), přidá hodnoty do zbývajících buněk v první řadě a výsledek uloží jako `Vertical_Align_Text_out.pptx`.

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

## **Nastavení formátování textu na úrovni tabulky**

Použijte [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) k aplikaci formátování textu na všechny buňky v tabulce. Jeho přetížení akceptují formátování úseku, odstavce a textového rámce, takže můžete nastavit tyto vlastnosti bez procházení jednotlivých buněk.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte objekt [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) ze snímku.
4. Nastavte velikost písma pomocí [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) pro text.
5. Nastavte zarovnání odstavce a pravý okraj pomocí [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) a [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Nastavte směr textu pomocí [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Uložte upravenou prezentaci.

Níže uvedený příklad otevře `table.pptx`, který musí obsahovat alespoň jeden snímek s tabulkou jako jejím prvním tvarem. Nastaví velikost písma na 25 bodů, zarovná odstavce vpravo s pravým okrajem 20 bodů a nastaví text vertikálně. Formátovaná prezentace je uložena jako `result.pptx`.

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

## **Získání vlastností stylu tabulky**

Použijte [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) k načtení předdefinovaného stylu tabulky a [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) k jeho přiřazení. Tento příklad aplikuje [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) na jednu tabulku, vypíše hodnotu předvolby a přiřadí stejnou předvolbu druhé tabulce. Obě tabulky jsou uloženy v `table-style.pptx`.

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

## **Uzamčení poměru stran tabulky**

Poměr stran tabulky je poměr její šířky k výšce. Použijte [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) k uzamčení tohoto poměru pro tabulku.

Níže uvedený příklad otevře `pres.pptx`, který musí obsahovat alespoň jeden snímek s tabulkou jako jejím prvním tvarem. Vytiskne aktuální stav uzamčení, povolí uzamčení poměru stran, vytiskne aktualizovaný stav (`true`) a uloží výsledek jako `pres-out.pptx`.

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

## **Často kladené otázky**

**Mohu povolit směr čtení zprava doleva (RTL) pro celou tabulku i text v jejích buňkách?**

Ano. Tabulka poskytuje metodu [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/), a odstavce mají [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). Použití obou zajišťuje správné RTL pořadí a vykreslení uvnitř buněk.

**Jak mohu zabránit uživatelům v přesouvání nebo změně velikosti tabulky ve finálním souboru?**

Použijte [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) k zakázání přesouvání, změny velikosti, výběru atd. Tato zamknutí se vztahují i na tabulky.

**Je podporováno vložení obrázku do buňky jako pozadí?**

Ano. Můžete nastavit [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) pro buňku; obrázek pokryje oblast buňky podle zvoleného režimu (roztažení nebo dlaždice).