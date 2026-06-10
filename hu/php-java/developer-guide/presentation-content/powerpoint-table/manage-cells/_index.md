---
title: Táblázatcellák kezelése prezentációkban PHP használatával
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/php-java/manage-cells/
keywords:
- táblacella
- cellák egyesítése
- szegély eltávolítása
- cella felosztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Könnyedén kezelheti a táblacellákat PowerPointban az Aspose.Slides for PHP segítségével. Gyorsan elsajátíthatja a cellák elérését, módosítását és formázását a zökkenőmentes diaautomatizálás érdekében."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy elérje és módosítsa a táblázatcellákat a PowerPoint‑prezentációkban. Ez a cikk elmagyarázza, hogyan azonosítsa az egyesített táblázatcellákat, hogyan távolítsa el a cellahatárokat, hogyan dolgozzon a cellaszámozással egyesítés vagy felosztás után, hogyan változtassa meg egy cella háttérszínét, és hogyan adjon hozzá egy képet egy táblázatcellába. A példák bemutatják, hogyan hozza létre vagy nyissa meg a prezentációt, hogyan szerezzen be egy táblát egy diáról, hogyan frissítse a cellaformázást a cella tulajdonságain keresztül, és hogyan mentse a módosított prezentációt PPTX fájlként.

## **Egyesített táblázatcellák azonosítása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg a táblát az első diáról. 
3. Iteráljon a tábla sorain és oszlopain, hogy megtalálja az egyesített cellákat.
4. Írjon ki üzenetet, amikor egyesített cellákat talál.

Ez a PHP kód megmutatja, hogyan azonosíthatók az egyesített táblázatcellák egy prezentációban:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// feltételezve, hogy a 0. dia 0. alakja egy táblázat

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

## **Táblacellahatárok eltávolítása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
2. Szerezzen be egy dia hivatkozását annak indexe alapján. 
3. Határozzon meg egy oszloptömböt szélességgel.
4. Határozzon meg egy soroktömböt magassággal.
5. Adjon hozzá egy táblát a diához a [addTable](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addTable) metóduson keresztül.
6. Iteráljon minden cellán, hogy törölje a felső, alsó, jobb és bal határokat.
7. Mentse a módosított prezentációt PPTX fájlként.

Ez a PHP kód megmutatja, hogyan távolíthatók el a táblacellák határai:

```php
  # Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
  $pres = new Presentation();
  try {
    # Eléri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Megadja az oszlopokat szélességekkel és a sorokat magasságokkal
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Táblázat alakzatot ad hozzá a diához
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Beállítja a szegély formátumát minden cellához
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # Kiírja a PPTX fájlt a lemezre
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Számozás egyesített cellákban**
Ha összefésüljük a 2 cellapárt (1, 1) x (2, 1) és (1, 2) x (2, 2), a kapott tábla számozott lesz. Ez a PHP kód bemutatja a folyamatot:

```php
  # Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
  $pres = new Presentation();
  try {
    # Eléri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Táblázat alakzatot ad hozzá a diára
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Beállítja a szegély formátumát minden cellához
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
    # Egyesíti a cellákat (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Egyesíti a cellákat (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ezután tovább egyesítjük a cellákat a (1, 1) és (1, 2) cellák egyesítésével. Az eredmény egy középen nagy egyesített cellát tartalmazó tábla:

```php
  # Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
  $pres = new Presentation();
  try {
    # Eléri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Táblázat alakzatot ad hozzá a diához
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Beállítja a szegély formátumát minden cellához
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
    # Egyesíti a cellákat (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Egyesíti a cellákat (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Egyesíti a cellákat (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Kiírja a PPTX fájlt a lemezre
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Számozás felosztott cellában**
Az előző példákban, amikor a táblacellákat egyesítették, a numeráció vagy számozási rendszer a többi cellában nem változott. 

Ezen alkalommal egy szabályos táblát (a merge nélküli táblát) veszünk, és megpróbáljuk felosztani a (1,1) cellát, hogy egy különleges táblát kapjunk. Érdemes lehet figyelni a tábla számozására, amely furcsának tűnhet. Ennek ellenére ez a módja annak, ahogy a Microsoft PowerPoint számozza a táblacellákat, és az Aspose.Slides is ugyanezt teszi. 

Ez a PHP kód bemutatja a leírt folyamatot:

```php
  # Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
  $pres = new Presentation();
  try {
    # Eléri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Táblázat alakzatot ad hozzá a diához
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Beállítja a szegély formátumát minden cellához
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
    # Egyesíti a cellákat (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Egyesíti a cellákat (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Felosztja a cellát (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Kiírja a PPTX fájlt a lemezre
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **A táblacellák háttérszínének módosítása**

Ez a PHP kód megmutatja, hogyan változtatható meg egy táblacella háttérszíne:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # új táblát hoz létre
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # beállítja a cella háttérszínét
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

## **Kép elhelyezése egy táblacellán belül**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
2. Szerezzen be egy dia hivatkozását annak indexe alapján.
3. Határozzon meg egy oszloptömböt szélességgel.
4. Határozzon meg egy soroktömböt magassággal.
5. Adjon hozzá egy táblát a diához a [AddTable](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addTable) metóduson keresztül.
6. Hozzon létre egy `Images` objektumot a képfájl tárolására.
7. Adja hozzá az `IImage` képet az `IPPImage` objektumhoz.
8. Állítsa be a `FillFormat` értékét a táblacellára `Picture`‑re.
9. Adja hozzá a képet a tábla első cellájához.
10. Mentse a módosított prezentációt PPTX fájlként

Ez a PHP kód megmutatja, hogyan helyezhet el egy képet egy táblacellában tábla létrehozásakor:

```php
  # Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
  $pres = new Presentation();
  try {
    # Eléri az első diát
    $islide = $pres->getSlides()->get_Item(0);
    # Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Táblázat alakzatot ad hozzá a diához
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Létrehozza az IPPImage objektumot a kép fájlból
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Hozzáadja a képet az első táblacellához
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Elmenti a PPTX fájlt a lemezre
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Beállíthatok különböző vonalvastagságot és stílust egy cella különböző oldalain?**

Igen. A [top](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellformat/getborderright/) határnak különálló tulajdonságai vannak, ezért minden oldal vastagsága és stílusa eltérhet. Ez logikailag következik a cella egyes oldalakra vonatkozó határvezérléséből, amelyet a cikk bemutat.

**Mi történik a képpel, ha megváltoztatom az oszlop/sor méretét, miután képet állítottam be a cella háttérként?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillmode/) (nyújtás/csempézés) beállításától függ. Nyújtás esetén a kép alkalmazkodik az új cellához; csempézésnél a csempéket újraszámolják. A cikk a képek megjelenítési módjait említi egy cellában.

**Megadhatok hiperhivatkozást a cella teljes tartalmára?**

A [Hyperlinks](/slides/hu/php-java/manage-hyperlinks/) a cella szövegkeretén belül szövegszint (rész) vagy a teljes táblán/alkotáson szintjén állítható be. Gyakorlatban a linket egy részre vagy a cella teljes szövegére alkalmazhatja.

**Beállíthatok különböző betűtípusokat egyetlen cellán belül?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portion/) (runok) független formázásával – betűcsalád, stílus, méret és szín.