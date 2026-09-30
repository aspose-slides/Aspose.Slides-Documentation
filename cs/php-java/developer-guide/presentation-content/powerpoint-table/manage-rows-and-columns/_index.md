---
title: Správa řádků a sloupců v tabulkách PowerPoint pomocí PHP
linktitle: Řádky a sloupce
type: docs
weight: 20
url: /cs/php-java/manage-rows-and-columns/
keywords:
- řádek tabulky
- sloupec tabulky
- první řádek
- záhlaví tabulky
- klonovat řádek
- klonovat sloupec
- kopírovat řádek
- kopírovat sloupec
- odstranit řádek
- odstranit sloupec
- formátování textu řádku
- formátování textu sloupce
- styl tabulky
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte řádky a sloupce tabulky v PowerPointu pomocí Aspose.Slides pro PHP přes Java a zrychlete úpravy prezentací a aktualizace dat."
---
## **Úvod**

Aspose.Slides for PHP via Java vám umožňuje spravovat strukturu a formátování tabulek v prezentacích PowerPoint pomocí třídy [Tabulka](https://reference.aspose.com/slides/php-java/aspose.slides/table/) . Můžete označit řádek záhlaví, klonovat nebo odstraňovat řádky a sloupce a použít formátování textu na celý řádek nebo sloupec.

Tento článek vysvětluje tyto operace s příklady v PHP. Také ukazuje, jak získat přednastavený styl tabulky, abyste jej mohli znovu použít. Indexy řádků a sloupců tabulky jsou nulové.

## **Ovládání výšky řádku**

Použijte [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) k nastavení minimální výšky řádku v bodech. Jedná se o dolní mez, nikoli pevnou výšku. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) vrací skutečnou výšku. Přístup k řádku získáte přes [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/).

Příklad načte [row-height-input.pptx](row-height-input.pptx), který má tabulku jako první objekt na první snímku. Jeho první řádek začíná na 70 bodech. Buňky používají text Arial 18 bodů, zalamování a horní a dolní okraje po 6 bodech; delší text ve druhém sloupci se zalamuje do více řádků. Příklad zvýší minimum na 100 bodů, potom ho sníží na 20 bodů, vytiskne skutečnou výšku po každé změně a uloží oba výsledky.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

U poskytnuté prezentace zvýšení minima přidá řádku prostor. Snížení ho odstraní tento dodatečný prostor, ale skutečná výška zůstane větší než 20 bodů, protože text a okraje buňky potřebují více místa. Pouhé snížení minima nemůže řádek donutit pod prostor požadovaný jeho obsahem.

Na skutečnou výšku má vliv několik faktorů:

- **Text a velikost písma:** delší text, explicitní zalomení řádku nebo větší písmo může vyžadovat více vertikálního prostoru.
- **Zalamování a šířka sloupce:** při povoleném zalamování může snížení šířky sloupce pomocí [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) vytvořit více řádků. Širší sloupec může snížit potřebný vertikální prostor.
- **Okraje buňky:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) a [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) přidávají vertikální prostor. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) a [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) snižují šířku dostupnou pro text a mohou způsobit další zalamování.

Pro tuto tabulku bez sloučených buněk buňka, která potřebuje nejvíce vertikálního prostoru, určuje obsahově řízený dolní limit pro celý řádek. Pro zkrácení řádku možná budete muset zkrátit text, snížit velikost písma nebo okraje, nebo rozšířit sloupec.

Obrázky níže ukazují stejnou tabulku ve stejném měřítku. Ve znázorněných výsledcích byly skutečné výšky 70, 100 a 55,2 bodu: poslední řádek zůstával vyšší než jeho minimum 20 bodů. Přesná měření textu se mohou lišit podle dostupných písem ve vašem prostředí. Stáhněte si uložené výsledky: [zvýšené minimum](row-height-increased.pptx) a [snížené minimum](row-height-decreased.pptx).

| Původní: minimum 70 pt, skutečná 70 pt | Zvýšené: minimum 100 pt, skutečná 100 pt | Snížené: minimum 20 pt, skutečná 55,2 pt |
| --- | --- | --- |
| ![Původní tabulka s prvním řádkem 70 bodů.](row-height-before.png) | ![Tabulka po zvýšení minima prvního řádku na 100 bodů.](row-height-increased.png) | ![Tabulka po snížení minima prvního řádku na 20 bodů; zalomený text udržuje řádek vyšší než minimum.](row-height-decreased.png) |

## **Nastavit první řádek jako záhlaví**

Použijte metodu [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) k označení prvního řádku pro formátování záhlaví. Jeho vzhled závisí na stylu tabulky aplikovaném na tabulku.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Získejte první snímek.
3. Získejte tabulku uloženou jako první objekt na snímku.
4. Povolte formátování záhlaví pro její první řádek.
5. Uložte upravenou prezentaci.

Příklad vyžaduje `table.pptx` s tabulkou jako první objekt na první snímku. Povolení formátování záhlaví pro první řádek a uloží `First_row_header.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Klonování řádku nebo sloupce tabulky**

Klonujte řádky nebo sloupce pro opětovné použití jejich obsahu a formátování. Můžete přidat kopii na konec tabulky nebo ji vložit na konkrétní pozici.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Získejte první snímek.
3. Definujte šířky sloupců a výšky řádků.
4. Přidejte tabulku pomocí metody [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Klonujte požadované řádky.
6. Klonujte požadované sloupce.
7. Uložte upravenou prezentaci.

Příklad vyžaduje `Test.pptx` s alespoň jedním snímkem. Vytvoří tabulku se třemi sloupci a pěti řádky, s rozměry uvedenými v bodech. Přidá kopie prvního řádku a sloupce, poté vloží kopie druhého řádku a sloupce na index 3 (čtvrtá pozice). Výsledná tabulka má sedm řádků a pět sloupců. Argument `false` zakazuje klonování do sousedních sloučených řádků nebo sloupců; tato tabulka nemá sloučené buňky.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Odstranění řádku nebo sloupce z tabulky**

Odstraňte řádky nebo sloupce, které v tabulce již nejsou potřeba. Odstranění položky posune indexy řádků nebo sloupců, které po ní následují.

1. Vytvořte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Získejte první snímek.
3. Definujte šířky sloupců a výšky řádků.
4. Přidejte tabulku pomocí [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Odstraňte druhý řádek a druhý sloupec.
6. Uložte upravenou prezentaci.

Tento příklad vytvoří tabulku 3 × 3 a odstraní řádek a sloupec na indexu 1, což zanechá tabulku 2 × 2 v souboru `TestTable_out.pptx`. Rozměry jsou v bodech. Argument `false` zakazuje odstraňování sousedních sloučených řádků nebo sloupců; tato tabulka nemá sloučené buňky.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavení formátování textu na úrovni řádku tabulky**

Aplikujte formátování textu na celý řádek, aby buňky byly jednotné. Můžete nastavit vlastnosti písma, formátování odstavců a směr textu, aniž byste formátovali každou buňku zvlášť.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Získejte tabulku na prvním snímku.
3. Použijte [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) pro první řádek.
4. Použijte [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) a [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) pro první řádek.
5. Použijte [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) pro druhý řádek.
6. Uložte upravenou prezentaci.

Příklad vyžaduje `table.pptx` s tabulkou jako první objekt na první snímku a alespoň dvěma řádky. Aplikuje text o velikosti 25 bodů, zarovnání vpravo a pravý okraj odstavce 20 bodů na první řádek, poté nastaví vertikální text ve druhém řádku.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavení formátování textu na úrovni sloupce tabulky**

Aplikujte formátování textu na celý sloupec, aby buňky byly jednotné. Můžete nastavit vlastnosti písma, formátování odstavců a směr textu, aniž byste formátovali každou buňku zvlášť.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Získejte tabulku na prvním snímku.
3. Použijte [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) pro první sloupec.
4. Použijte [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) a [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) pro první sloupec.
5. Použijte [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) pro druhý sloupec.
6. Uložte upravenou prezentaci.

Příklad vyžaduje `table.pptx` s tabulkou jako první objekt na první snímku a alespoň dvěma sloupci. Aplikuje text o velikosti 25 bodů, zarovnání vpravo a pravý okraj odstavce 20 bodů na první sloupec, poté nastaví vertikální text ve druhém sloupci.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Získání vlastností stylu tabulky**

Použijte metodu [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) k získání přednastaveného stylu aplikovaného na tabulku a jeho opětovnému použití na jiné tabulce. To identifikuje předvolbu místo jednotlivých přepsání formátování buněk.

Příklad vytvoří tabulku, použije [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1), a načte předvolbu zpět. Vytiskne celočíselnou hodnotu odpovídající `DarkStyle1` a uloží tabulku do `table.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Často kladené otázky**

**Mohu použít motivy/styly PowerPointu na již vytvořenou tabulku?**

Ano. Tabulka dědí motiv snímku/podkladu/šablony a můžete stále přepsat výplně, ohraničení a barvy textu nad tímto motivem.

**Mohu třídit řádky tabulky jako v Excelu?**

Ne, tabulky Aspose.Slides nemají vestavěné řazení ani filtry. Seřaďte svá data v paměti nejprve a poté znovu naplňte řádky tabulky v tomto pořadí.

**Mohu mít proužkované sloupce a zároveň zachovat vlastní barvy ve specifických buňkách?**

Ano. Zapněte proužkované sloupce a poté přepište konkrétní buňky lokálním formátováním; formátování na úrovni buňky má přednost před stylem tabulky.