---  
title: PowerPoint táblázatok sorainak és oszlopainak kezelése PHP használatával  
linktitle: Sorok és oszlopok  
type: docs  
weight: 20  
url: /hu/php-java/manage-rows-and-columns/  
keywords:  
- táblázat sor  
- táblázat oszlop  
- első sor  
- táblázat fejléc  
- sor klónozása  
- oszlop klónozása  
- sor másolása  
- oszlop másolása  
- sor eltávolítása  
- oszlop eltávolítása  
- sor szövegformázás  
- oszlop szövegformázás  
- táblázat stílus  
- PowerPoint  
- prezentáció  
- PHP  
- Aspose.Slides  
description: "Kezelje a táblázat sorait és oszlopait PowerPointban az Aspose.Slides for PHP via Java segítségével, és gyorsítsa fel a prezentáció szerkesztését és az adatok frissítését."  
---
## **Bevezetés**

Annak érdekében, hogy kezelhesse egy táblázat sorait és oszlopait egy PowerPoint‑prezentációban, az Aspose.Slides biztosítja a [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/table/) osztályt és számos más típust.

## **Az első sor beállítása fejlécként**

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztálypéldányt, és töltse be a prezentációt.  
2. Szerezze meg a dia referenciáját az indexe alapján.  
3. Hozzon létre egy [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Table) objektumot, és állítsa null‑ra.  
4. Iteráljon végig az összes [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) objektumon, hogy megtalálja a megfelelő táblázatot.  
5. Állítsa be a táblázat első sorát fejlécként.  

Ez a PHP kód bemutatja, hogyan állíthatja be egy táblázat első sorát fejlécként:

```php
  # Példányosítja a Presentation osztályt
  $pres = new Presentation("table.pptx");
  try {
    # Eléri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Inicializálja a null TableEx-et
    $tbl = null;
    # Végigiterál a shape-eken, és beállítja a táblázatra való hivatkozást
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Beállítja a táblázat első sorát fejlécként
        $tbl->setFirstRow(true);
      }
    }
    # Elmenti a prezentációt a lemezre
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Táblázatsor vagy -oszlop klónozása**

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztálypéldányt, és töltse be a prezentációt,  
2. Szerezze meg a dia referenciáját az indexe alapján.  
3. Határozzon meg egy `columnWidth` tömböt.  
4. Határozzon meg egy `rowHeight` tömböt.  
5. Adjon egy [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Table) objektumot a diára a [addTable](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addtable/) metódus segítségével.  
6. Klónozza a táblázat sorát.  
7. Klónozza a táblázat oszlopát.  
8. Mentse el a módosított prezentációt.  

Ez a PHP kód bemutatja, hogyan klónozhatja egy PowerPoint táblázat sorát vagy oszlopát:

```php
  # Példányosítja a Presentation osztályt
  $pres = new Presentation("Test.pptx");
  try {
    # Eléri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Definiálja az oszlopokat szélességekkel és a sorokat magasságokkal
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Hozzáad egy táblázat alakzatot a diához
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Hozzáad némi szöveget az 1. sor 1. cellájához
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Hozzáad némi szöveget az 1. sor 2. cellájához
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Klónozza az 1. sort a táblázat végén
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Hozzáad némi szöveget a 2. sor 1. cellájához
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Hozzáad némi szöveget a 2. sor 2. cellájához
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Klónozza a 2. sort a táblázat 4. soraként
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Klónozza az első oszlopot a végén
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Klónozza a 2. oszlopot a 4. oszlop indexén
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Elmenti a prezentációt a lemezre
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sor vagy oszlop eltávolítása a táblázatból**

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztálypéldányt, és töltse be a prezentációt,  
2. Szerezze meg a dia referenciáját az indexe alapján.  
3. Határozzon meg egy `columnWidth` tömböt.  
4. Határozzon meg egy `rowHeight` tömböt.  
5. Adjon egy [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Table) objektumot a diára a [addTable](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addtable/) metódus segítségével.  
6. Távolítsa el a táblázat sorát.  
7. Távolítsa el a táblázat oszlopát.  
8. Mentse el a módosított prezentációt.  

Ez a PHP kód bemutatja, hogyan távolíthat el egy sort vagy oszlopot egy táblázatból:

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

## **Szövegformázás beállítása táblázatsoros szinten**

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztálypéldányt, és töltse be a prezentációt,  
2. Szerezze meg a dia referenciáját az indexe alapján.  
3. Érje el a megfelelő [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Table) objektumot a diáról.  
4. Állítsa be az első sor celláinak [setFontHeight(float value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Állítsa be az első sor celláinak [setAlignment(int value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setalignment/) és [setMarginRight(float value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setmarginright/) értékeit.  
6. Állítsa be a második sor celláinak [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Mentse el a módosított prezentációt.  

Ez a PHP kód demonstrálja a műveletet.

```php
  # Létrehozza a Presentation osztály példányát
  $pres = new Presentation();
  try {
    # Tegyük fel, hogy az első dia első alakzata egy táblázat
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Beállítja az első sor celláinak betűméreteit
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Beállítja az első sor celláinak szövegigazítását és jobb margóját
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Beállítja a második sor celláinak függőleges szövegtípusát
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Elmenti a prezentációt a lemezre
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Szövegformázás beállítása táblázatoszlopos szinten**

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztálypéldányt, és töltse be a prezentációt,  
2. Szerezze meg a dia referenciáját az indexe alapján.  
3. Érje el a megfelelő [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Table) objektumot a diáról.  
4. Állítsa be az első oszlop celláinak [setFontHeight(float value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Állítsa be az első oszlop celláinak [setAlignment(int value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setalignment/) és [setMarginRight(float value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/setmarginright/) értékeit.  
6. Állítsa be a második oszlop celláinak [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Mentse el a módosított prezentációt.  

Ez a PHP kód demonstrálja a műveletet:

```php
  # Létrehozza a Presentation osztály példányát
  $pres = new Presentation();
  try {
    # Tegyük fel, hogy az első dia első alakzata egy táblázat
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Beállítja az első oszlop celláinak betűmagasságát
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Beállítja az első oszlop celláinak szövegigazítását és jobb margóját egy hívásban
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Beállítja a második oszlop celláinak függőleges szövegtípusát
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

## **Táblázat stílus tulajdonságok lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy táblázat stílus tulajdonságait, hogy azokat egy másik táblázathoz vagy máshová felhasználhassa. Ez a PHP kód bemutatja, hogyan kaphatja meg a stilus tulajdonságokat egy táblázat előre beállított stílusából:

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

## **FAQ**

**Alkalmazhatok PowerPoint témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/összeállítás/mester téma beállításait, és továbbra is felülírhatja a kitöltéseket, szegélyeket és szövegszíneket ezen téma felett.

**Rendezhetem a táblázat sorait, mint az Excelben?**

Nem, az Aspose.Slides táblázatok nem rendelkeznek beépített rendezéssel vagy szűrőkkel. Először rendezze az adatokat a memóriában, majd töltse újra a táblázat sorait ebben a sorrendben.

**Lehetnek csíkozott (csíkos) oszlopok, miközben egyes cellákra egyedi színeket tartok fenn?**

Igen. Kapcsolja be a csíkozott oszlopokat, majd felülírja a specifikus cellákat helyi formázással; a cellaszintű formázás felülírja a táblázat stílusát.