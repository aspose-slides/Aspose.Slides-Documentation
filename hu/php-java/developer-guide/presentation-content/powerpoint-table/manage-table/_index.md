---
title: PowerPoint táblázatok kezelése PHP-ben
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
- szöveg formázása
- táblázat stílusa
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Hozzon létre és szerkesszen táblázatokat PowerPoint diákon az Aspose.Slides for PHP segítségével Java-n keresztül. Fedezzen fel egyszerű kódrészleteket, hogy hatékonyabbá tegye a táblázati munkafolyamatait."
---
## **Bevezetés**

A PowerPoint táblázat egy hatékony módja az információk megjelenítésének és ábrázolásának. A cellák rácsában (sorok és oszlopok szerint rendezve) lévő információ egyértelmű és könnyen érthető.

Az Aspose.Slides a [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Table) osztályt, a [Cell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cell/) osztályt és egyéb típusokat biztosít, amelyek lehetővé teszik táblázatok létrehozását, módosítását és kezelését mindenféle prezentációban.

## **Táblázat létrehozása nulláról**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Definiáljon egy `columnWidth` tömböt.  
4. Definiáljon egy `rowHeight` tömböt.  
5. Adjon egy [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/table/) objektumot a diára a [addTable](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addtable/) metódussal.  
6. Iteráljon végig minden [Cell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cell/) elemen, hogy alkalmazza a felső, alsó, jobb és bal szegélyek formázását.  
7. Egyesítse a táblázat első sorának első két celláját.  
8. Érje el egy [Cell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cell/) [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) objektumát.  
9. Adjon szöveget a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) objektumhoz.  
10. Mentse a módosított prezentációt.

Ez a PHP kód bemutatja, hogyan hozhat létre táblázatot egy prezentációban:

```php
  # PPTX fájlt képviselő Presentation osztály példányosítása
  $pres = new Presentation();
  try {
    # Első dia elérése
    $sld = $pres->getSlides()->get_Item(0);
    # Oszlopok definiálása szélességekkel és sorok magasságokkal
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Táblázat alakzat hozzáadása a diára
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # A cellák szegélyformátumának beállítása
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
    # Az első sor első és második cellájának egyesítése
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Szöveg hozzáadása az egyesített cellához
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # A prezentáció mentése a lemezre
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cellák számozása egyszerű és nulláral kezdődik. A táblázat első cellájának indexe 0,0 (oszlop 0, sor 0).

Például egy 4 oszlopos és 4 soros táblázat cellái a következő módon vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a PHP kód bemutatja, hogyan adhatja meg a cellák számozását egy táblázatban:

```php
  # PPTX fájlt képviselő Presentation osztály példányosítása
  $pres = new Presentation();
  try {
    # Első dia elérése
    $sld = $pres->getSlides()->get_Item(0);
    # Oszlopok definiálása szélességekkel és sorok magasságokkal
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Táblázat alakzat hozzáadása a diára
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # A cellák szegélyformátumának beállítása
    $rows = $tbl->getRows();
    foreach($rows as $row) {
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
    # A prezentáció mentése a lemezre
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Létező táblázat elérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  

2. Szerezze meg a táblázatot tartalmazó dia hivatkozását az indexe alapján.  

3. Hozzon létre egy [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Table) objektumot, és állítsa null-ra.  

4. Iteráljon végig az összes [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) objektumon, amíg meg nem találja a táblázatot.  

   Ha úgy gondolja, hogy a dia csak egy táblázatot tartalmaz, egyszerűen ellenőrizze az összes benne lévő alakzatot. Amikor egy alakzatot táblázatként azonosít, típuskonvertálhatja [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Table) objektummá. Ha a dia több táblázatot tartalmaz, érdemes a kívánt táblázatot a [setAlternativeText(String value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/setalternativetext/) segítségével keresni.  

5. Használja a [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Table) objektumot a táblázattal való munkához. Az alábbi példában egy új sort adtunk a táblázathoz.  

6. Mentse a módosított prezentációt.

Ez a PHP kód bemutatja, hogyan érheti el és dolgozhat egy létező táblázattal:

```php
  # PPTX fájlt képviselő Presentation osztály példányosítása
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Első dia elérése
    $sld = $pres->getSlides()->get_Item(0);
    # null TableEx inicializálása
    $tbl = null;
    # Az alakzatok iterálása és a megtalált táblázatra mutató hivatkozás beállítása
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # A második sor első oszlopának szövegének beállítása
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # A módosított prezentáció mentése a lemezre
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **A szövegkeretet tartalmazó cella megtalálása**

Amikor általános szövegfeldolgozó kód egy [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) objektumot kap egy táblázatból, használja a [TextFrame::getParentCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getParentCell) metódust a tulajdonos [Cell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cell/) lekérdezéséhez. Egy táblázatcella szövegkeret esetén a [TextFrame::getParentCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getParentCell) visszaadja a tulajdonost, a [TextFrame::getParentShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getParentShape) pedig `null` értéket, annak ellenére, hogy a táblázat maga egy alakzat.

A cella koordinátái a csak olvasható [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cell/#getFirstColumnIndex) és [Cell::getFirstRowIndex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cell/#getFirstRowIndex) metódusokon keresztül érhetők el. A [TextFrame::getParentCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/#getParentCell) szintén csak olvasható navigációt biztosít: visszaadja a tulajdonost, de nem változtatja meg a tulajdonjogot. Mindig ellenőrizze a visszakapott cellát `java_is_null` segítségével, mielőtt használná.

A teljes példáért, amely azonosítja a táblázatcella és alakzat tulajdonosait, beleértve a SmartArt csomópontokhoz tartozó alakzatokat, lásd a [Search and Replace Text](/slides/hu/php-java/search-and-replace-text/) oldalt.

## **Szöveg igazítása egy táblázatban**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon egy [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Table) objektumot a diára.  
4. Érje el a táblázatból egy [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) objektumot.  
5. Hozzáférjen a [Paragraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraph/) objektumhoz.  
6. Igazítsa a szöveget függőlegesen.  
7. Mentse a módosított prezentációt.

Ez a PHP kód bemutatja, hogyan igazíthatja a szöveget egy táblázatban:

```php
  # Példányosítja a Presentation osztályt
  $pres = new Presentation();
  try {
    # Első dia lekérése
    $slide = $pres->getSlides()->get_Item(0);
    # Oszlopok definiálása szélességekkel és sorok magasságokkal
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # A táblázat alakzat hozzáadása a diára
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # A szövegkeret elérése
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Létrehozza a Paragraph objektumot a szövegkerethez
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Létrehozza a Portion objektumot a bekezdéshez
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Függőleges szövegigazítás
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # A prezentáció mentése a lemezre
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Szövegformázás beállítása a táblázati szinten**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Érje el a [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Table) objektumot a diáról.  
4. Állítsa be a szöveg [setFontHeight(float value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setFontHeight) értékét.  
5. Állítsa be a [setAlignment(int value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setalignment/) és [setMarginRight(float value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setmarginright/) értékeket.  
6. Állítsa be a [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/settextverticaltype/) értéket.  
7. Mentse a módosított prezentációt.

Ez a PHP kód bemutatja, hogyan alkalmazhatja a kívánt formázási beállításokat a táblázat szövegére:

```php
  # Létrehozza a Presentation osztály egy példányát
  $pres = new Presentation("simpletable.pptx");
  try {
    # Tegyük fel, hogy az első dián az első alakzat egy táblázat
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Beállítja a táblázat celláinak betűmagasságát
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Beállítja a táblázat celláinak szövegigazítását és jobb margóját egy hívással
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Beállítja a táblázat celláinak függőleges szöveg típusát
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

## **Táblázat stílus tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a táblázat stílus tulajdonságainak lekérését, hogy ezeket a részleteket felhasználhassa egy másik táblázathoz vagy máshová. Ez a PHP kód megmutatja, hogyan kérhető le egy táblázat előre definiált stílusának tulajdonságai:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// megváltoztatja az alapértelmezett stílus előbeállított témát

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **A táblázat képarányának zárolása**

A geometriai alakzat képaránya a különböző dimenziók méretének aránya. Az Aspose.Slides a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) metódust biztosítja, amely lehetővé teszi a képarány beállításának zárolását táblázatok és egyéb alakzatok esetén.

Ez a PHP kód bemutatja, hogyan zárolható a képarány egy táblázathoz:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invertálja

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Engedélyezhetek jobbról balra (RTL) olvasási irányt egy teljes táblázat és annak celláiban lévő szöveg számára?**

Igen. A táblázat rendelkezik a [setRightToLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/table/setrighttoleft/) metódussal, a bekezdések pedig a [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setrighttoleft/) metódussal. Mindkettő használata biztosítja a helyes RTL sorrendet és a megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg a felhasználókat, hogy a végső fájlban mozogassák vagy átméretezzék a táblázatot?**

Használjon alakzatzárakat a mozgatás, átméretezés, kijelölés stb. letiltásához. Ezek a zárak a táblázatokra is vonatkoznak.

**Támogatott-e egy kép beillesztése cellába háttérként?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/) formátumot egy cellához; a kép a választott módnak megfelelően (nyújtás vagy mozaik) fogja kitölteni a cellát.