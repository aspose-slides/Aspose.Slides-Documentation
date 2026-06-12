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

Aby vám umožnil spravovat řádky a sloupce tabulky v prezentaci PowerPoint, poskytuje Aspose.Slides třídu [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/table/) a mnoho dalších typů.

## **Nastavit první řádek jako záhlaví**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a načtěte prezentaci.  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Vytvořte objekt [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Table) a nastavte jej na null.  
4. Projděte všechny objekty [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/) a najděte požadovanou tabulku.  
5. Nastavte první řádek tabulky jako její záhlaví.  

Tento PHP kód ukazuje, jak nastavit první řádek tabulky jako její záhlaví:

```php
  # Vytvoří instanci třídy Presentation
  $pres = new Presentation("table.pptx");
  try {
    # Přistupuje k prvnímu snímku
    $sld = $pres->getSlides()->get_Item(0);
    # Inicializuje proměnnou TableEx na null
    $tbl = null;
    # Prochází tvary a nastaví odkaz na tabulku
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Nastavuje první řádek tabulky jako její záhlaví
        $tbl->setFirstRow(true);
      }
    }
    # Ukládá prezentaci na disk
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Klonovat řádek nebo sloupec tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a načtěte prezentaci,  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Definujte pole `columnWidth`.  
4. Definujte pole `rowHeight`.  
5. Přidejte objekt [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Table) na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addtable/).  
6. Zklonujte řádek tabulky.  
7. Zklonujte sloupec tabulky.  
8. Uložte upravenou prezentaci.  

Tento PHP kód ukazuje, jak klonovat řádek nebo sloupec tabulky PowerPoint:

```php
  # Vytvoří instanci třídy Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # Přistupuje k prvnímu snímku
    $sld = $pres->getSlides()->get_Item(0);
    # Definuje sloupce s šířkami a řádky s výškami
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Přidá tvar tabulky na snímek
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Přidá text do buňky řádku 1, sloupce 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Přidá text do buňky řádku 1, sloupce 2
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Zklonuje řádek 1 na konec tabulky
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Přidá text do buňky řádku 2, sloupce 1
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Přidá text do buňky řádku 2, sloupce 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Zklonuje řádek 2 jako 4. řádek tabulky
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Zklonuje první sloupec na konec
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Zklonuje druhý sloupec na index 4
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Uloží prezentaci na disk
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Odstranit řádek nebo sloupec z tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a načtěte prezentaci,  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Definujte pole `columnWidth`.  
4. Definujte pole `rowHeight`.  
5. Přidejte objekt [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Table) na snímek pomocí metody [addTable](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addtable/).  
6. Odstraňte řádek tabulky.  
7. Odstraňte sloupec tabulky.  
8. Uložte upravenou prezentaci.  

Tento PHP kód ukazuje, jak odstranit řádek nebo sloupec z tabulky:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavit formátování textu na úrovni řádku tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a načtěte prezentaci,  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Získejte požadovaný objekt [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Table) ze snímku.  
4. Nastavte buňkám v prvním řádku [setFontHeight(float value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Nastavte buňkám v prvním řádku [setAlignment(int value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setalignment/) a [setMarginRight(float value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. Nastavte buňkám ve druhém řádku [setTextVerticalType(byte value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Uložte upravenou prezentaci.  

Tento PHP kód demonstruje operaci.

```php
  # Vytvoří instanci třídy Presentation
  $pres = new Presentation();
  try {
    # Předpokládejme, že první tvar na prvním snímku je tabulka
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Nastavuje výšku písma buněk prvního řádku
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Nastavuje zarovnání textu a pravý okraj buněk prvního řádku
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Nastavuje vertikální typ textu buněk druhého řádku
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Ukládá prezentaci na disk
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavit formátování textu na úrovni sloupce tabulky**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a načtěte prezentaci,  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Získejte požadovaný objekt [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Table) ze snímku.  
4. Nastavte buňkám v prvním sloupci [setFontHeight(float value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Nastavte buňkám v prvním sloupci [setAlignment(int value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setalignment/) a [setMarginRight(float value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. Nastavte buňkám ve druhém sloupci [setTextVerticalType(byte value)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Uložte upravenou prezentaci.  

Tento PHP kód demonstruje operaci:

```php
  # Vytvoří instanci třídy Presentation
  $pres = new Presentation();
  try {
    # Předpokládejme, že první tvar na prvním snímku je tabulka
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Nastavuje výšku písma buněk prvního sloupce
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Nastavuje zarovnání textu a pravý okraj buněk prvního sloupce v jednom volání
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Nastavuje vertikální typ textu buněk druhého sloupce
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Získat vlastnosti stylu tabulky**

Aspose.Slides vám umožňuje získat vlastnosti stylu tabulky, abyste je mohli použít pro jinou tabulku nebo kdekoli jinde. Tento PHP kód ukazuje, jak získat vlastnosti stylu z přednastaveného stylu tabulky:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// změní výchozí přednastavený styl motivu

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Mohu použít motivy/styly PowerPoint na již vytvořenou tabulku?**

Ano. Tabulka dědí motiv snímku/layoutu/masteru a můžete nad tímto motivem stále přepsat výplně, okraje a barvy textu.

**Mohu řadit řádky tabulky jako v Excelu?**

Ne, tabulky Aspose.Slides nemají vestavěné řazení ani filtry. Seřaďte svá data v paměti nejprve a pak znovu naplňte řádky tabulky v tomto pořadí.

**Mohu mít pruhované (proužkované) sloupce a zároveň si zachovat vlastní barvy v konkrétních buňkách?**

Ano. Zapněte pruhované sloupce a pak přepište konkrétní buňky lokálním formátováním; formátování na úrovni buňky má přednost před stylem tabulky.