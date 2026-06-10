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
- méretarány
- szöveg igazítása
- szövegformázás
- táblázat stílusa
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "Hozzon létre és szerkesszen táblázatokat PowerPoint diákon az Aspose.Slides for PHP (Java) segítségével. Fedezzen fel egyszerű kódrészleteket, amelyek egyszerűsítik a táblázatkezelési folyamatait."
---
## **Bevezetés**

A táblázat a PowerPointban hatékony módja az információ megjelenítésének és ábrázolásának. Az információ egy cellahálón (sorokba és oszlopokba rendezve) egyszerű és könnyen érthető.

Az Aspose.Slides biztosítja a [Table] osztályt, a [Cell] osztályt, és egyéb típusokat, amelyekkel létrehozhat, frissíthet és kezelhet táblázatokat mindenféle bemutatóban.

## **Táblázat létrehozása az elejétől**

1. Hozzon létre egy példányt a [Presentation] osztályból.
2. Szerezze be egy dia hivatkozását az indexén keresztül. 
3. Határozzon meg egy `columnWidth` tömböt.
4. Határozzon meg egy `rowHeight` tömböt.
5. Adjon egy [Table] objektumot a diára a [addTable] metódus segítségével.
6. Iteráljon végig minden [Cell] objektumon, hogy alkalmazza a formázást a felső, alsó, jobb és bal szegélyekre.
7. Egyesítse a táblázat első sorának első két celláját. 
8. Érje el egy [Cell] [TextFrame] objektumát.
9. Adjon szöveget a [TextFrame] objektumhoz.
10. Mentse el a módosított bemutatót.

Ez a PHP kód bemutatja, hogyan hozhat létre táblázatot egy bemutatóban:

```php
  # Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
  $pres = new Presentation();
  try {
    # Eléri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Definiálja az oszlopokat szélességekkel és a sorokat magasságokkal
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Táblázat alakzatot ad hozzá a diához
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Beállítja a keret formátumát minden cellához
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
    # Egyesíti az 1. sor 1. és 2. celláját
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Szöveget ad a egyesített cellához
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Elmenti a bemutatót a lemezre
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cellák számozása egyszerű és nullától indul. Az első cella indexe 0,0 (oszlop 0, sor 0). 

Például egy 4 oszlopos és 4 soros táblázat cellái ilyen módon vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a PHP kód bemutatja, hogyan adhatja meg a cellák számozását egy táblázatban:

```php
  # Előállít egy Presentation osztályt, amely egy PPTX fájlt képvisel
  $pres = new Presentation();
  try {
    # Eléri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Definiálja az oszlopokat szélességekkel és a sorokat magasságokkal
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Egy táblázat alakzatot ad hozzá a diához
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Beállítja a keret formátumát minden cellához
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
    # Elmenti a bemutatót a lemezre
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Létező táblázat elérése**

1. Hozzon létre egy példányt a [Presentation] osztályból.

2. Szerezze meg a táblázatot tartalmazó dia hivatkozását az indexén keresztül. 

3. Hozzon létre egy [Table] objektumot, és állítsa null-ra.

4. Iteráljon végig az összes [Shape] objektumon, amíg a táblázat meg nem található.  
   Ha úgy gondolja, hogy a kezelendő dia egyetlen táblázatot tartalmaz, egyszerűen ellenőrizheti az összes benne lévő alakzatot. Ha egy alakzatot táblázatként azonosítanak, típuskonvertálhatja [Table] objektummá. Ha a dián több táblázat található, akkor célszerűbb a szükséges táblázatot a [setAlternativeText(String value)] metódus segítségével keresni.

5. Használja a [Table] objektumot a táblázattal való munka során. Az alábbi példában egy új sort adtunk a táblázathoz.

6. Mentse el a módosított bemutatót.

Ez a PHP kód bemutatja, hogyan érheti el és dolgozhat egy meglévő táblázattal:

```php
  # Előállítja a Presentation osztályt, amely egy PPTX fájlt képvisel
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Eléri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Inicializálja a null TableEx-et
    $tbl = null;
    # Végigiterál a alakzatokon, és beállítja a megtalált táblázatra mutató hivatkozást
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Beállítja a szöveget a második sor első oszlopához
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Elmenti a módosított bemutatót a lemezre
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Szöveg igazítása egy táblázatban**

1. Hozzon létre egy példányt a [Presentation] osztályból.
2. Szerezze meg egy dia hivatkozását az indexén keresztül. 
3. Adjon egy [Table] objektumot a diára.
4. Érje el a táblázat [TextFrame] objektumát.
5. Érje el a [Paragraph] objektumot.
6. Igazítsa a szöveget függőlegesen.
7. Mentse el a módosított bemutatót.

Ez a PHP kód bemutatja, hogyan igazítható a szöveg egy táblázatban:

```php
  # Létrehozza a Presentation osztály példányát
  $pres = new Presentation();
  try {
    # Eléri az első diát
    $slide = $pres->getSlides()->get_Item(0);
    # Definiálja az oszlopokat szélességekkel és a sorokat magasságokkal
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Hozzáadja a táblázat alakzatot a diára
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Eléri a szövegkeretet
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Létrehozza a Paragraph objektumot a szövegkerethez
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Létrehozza a Portion objektumot a bekezdéshez
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Függőlegesen igazítja a szöveget
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Elmenti a bemutatót a lemezre
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Szövegformázás beállítása a táblázat szintjén**

1. Hozzon létre egy példányt a [Presentation] osztályból.
2. Szerezze meg egy dia hivatkozását az indexén keresztül. 
3. Érje el a [Table] objektumot a diáról.
4. Állítsa be a szöveg [setFontHeight(float value)] metódusával.
5. Állítsa be a [setAlignment(int value)] és a [setMarginRight(float value)] értékeket.
6. Állítsa be a [setTextVerticalType(byte value)] értéket.
7. Mentse el a módosított bemutatót. 

Ez a PHP kód bemutatja, hogyan alkalmazhatja a kívánt formázási beállításokat a táblázat szövegére:

```php
  # Létrehozza a Presentation osztály példányát
  $pres = new Presentation("simpletable.pptx");
  try {
    # Tegyük fel, hogy az első dia első alakzata egy táblázat
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
    # Beállítja a táblázat celláinak szöveg függőleges típusát
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

## **Táblázat stílus tulajdonságok lekérése**

Az Aspose.Slides lehetővé teszi egy táblázat stílustulajdonságainak lekérését, hogy ezeket a részleteket egy másik táblázathoz vagy máshová felhasználhassa. Ez a PHP kód bemutatja, hogyan szerezhetők meg a stílustulajdonságok egy táblázat előre beállított stílusából:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// módosítja az alapértelmezett stílus előre beállított témát

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Táblázat méretarányának zárolása**

A geometriai alakzat méretaránya a méretek aránya különböző dimenziókban. Az Aspose.Slides biztosítja a [setAspectRatioLocked] metódust, amely lehetővé teszi a táblázatok és egyéb alakzatok méretarányának zárolását.

Ez a PHP kód bemutatja, hogyan zárolható a táblázat méretarány:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// megfordítja

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt egy teljes táblázat és annak celláiban lévő szöveg számára?**

Igen. A táblázat rendelkezik egy [setRightToLeft] metódussal, a bekezdések pedig a [ParagraphFormat::setRightToLeft] módszerrel. Mindkettő használata biztosítja a helyes RTL sorrendet és a cellákon belüli megjelenítést.

**Hogyan akadályozhatom meg a felhasználókat, hogy a végleges fájlban a táblázatot áthelyezzék vagy átméretezzék?**

Használjon alakzatzárolásokat a mozgatás, átméretezés, kiválasztás stb. letiltásához. Ezek a zárolások a táblázatokra is vonatkoznak.

**Támogatott-e egy kép beillesztése egy cellába háttérként?**

Igen. Beállíthat egy [picture fill] kitöltést a cellához; a kép a választott mód (nyújtás vagy csempezés) szerint lefedi a cella területét.