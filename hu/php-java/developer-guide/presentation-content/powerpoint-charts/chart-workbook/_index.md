---
title: Diagram munkafüzetek kezelése prezentációkban PHP használatával
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/php-java/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adat
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagram gyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for PHP-t Java segítségével: egyszerűen kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy optimalizálja a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhat a diagram munkafüzetekkel az Aspose.Slides‑ban. Bemutatja, hogyan olvashat és írhat diagramadatokat munkafüzet adatfolyamokon keresztül, hogyan használhatja a munkafüzet cellákat diagramadatcímkéként, hogyan érheti el a munkalap‑gyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagramértékekhez.

Emellett tárgyalja a külső munkafüzetek diagramadat‑forrásként való használatát. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérheti le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesztheti a diagramadatokat, ha a munkafüzet elérhető.

Hiányzó adatot ábrázoló munkafüzet cellák esetén lásd az [Az üres cellák megjelenítésének szabályozása](/slides/hu/php-java/chart-series/) oldalt, ahol megtalálható a különbség az üres cella és a nulla között, valamint egy vonaldiagram‑összehasonlítás a rendelkezésre álló megjelenítési módokról.

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides a [readWorkbookStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#readWorkbookStream) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#writeWorkbookStream) metódusokat biztosítja, amelyek lehetővé teszik a diagramadat‑munkafüzetek (az Aspose.Cells‑kel szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés:** a diagramadatoknak ugyanúgy kell felépülniük, vagy hasonló szerkezettel kell rendelkezniük, mint a forrás.

Ez a PHP‑kód egy mintaműveletet mutat be:

```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Diagramelrendezés ellenőrzése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosítottra cserél, a diagram megtartja az eredeti sorozat‑ és kategóriagyűjteményeit. Ez az eltérés a [Chart::validateChartLayout](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/validatechartlayout/) hibához vezethet, amely index‑túl‑tartomány hibát jelez. Írja ki a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagramba.

```php
// A munkafüzet adatfolyam módosítása után (pl. az Aspose.Cells használatával)
$updatedWorkbook = $chartData->readWorkbookStream();

// A meglévő adat-hivatkozások törlése.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

A gyűjtemények törlése biztosítja, hogy a diagram adatstruktúrája egyezzen az új munkafüzettel, így a `validateChartLayout` hibamentesen befejeződik.

## **Munkafüzetcellát beállítása diagramadatcímkének**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.  
2. Szerezze be egy dia referenciáját az indexe alapján.  
3. Adjon hozzá egy buborékdiagramot némi adattal.  
4. Érje el a diagram sorozatát.  
5. Állítsa be a munkafüzetcellát adatcímkének.  
6. Mentse a prezentációt.

Ez a PHP‑kód bemutatja, hogyan állíthat be egy munkafüzetcellát diagramadatcímkének:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Létrehozza a prezentáció osztályt, amely egy prezentációs fájlt képvisel
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Munkalapok kezelése**

Ez a PHP‑kód egy olyan műveletet mutat be, ahol a [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#getWorksheets) metódust használják a munkalap‑gyűjtemény eléréséhez:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Az adatforrás típusának megadása**

Ez a PHP‑kód arra mutat példát, hogyan adhat meg egy típust egy adatforrásnak:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nem támogatott beágyazott munkafüzetformátumok észlelése**

Az Aspose.Slides nem támogatja a néhány diagramhoz beágyazható Excel bináris munkafüzet (.xlsb) formátumot. A [ChartData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/) `getEmbeddedWorkbookType` metódusával és a [WorkbookType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/workbooktype/) felsorolással felismerheti a nem támogatott formátumokat, és kihagyhatja az érintett diagramokat.

```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # A beágyazott munkafüzet .xlsb formátumban van, amely nem támogatott.
      continue;
    }

    # Itt olvashatja vagy módosíthatja a diagram munkafüzet adatait.
  }
} finally {
  $presentation->dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzeteket diagramok adatforrásaként.

### **Külső munkafüzet létrehozása**

A **`readWorkbookStream`** és a **`setExternalWorkbook`** metódusok segítségével akár egy külső munkafüzetet hozhat létre a semmiből, akár egy belső munkafüzetet tehet külsővé.

Ez a PHP‑kód bemutatja a külső munkafüzet létrehozási folyamatát:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Külső munkafüzet beállítása**

A **`setExternalWorkbook`** metódus használatával egy külső munkafüzetet rendelhet a diagramhoz adatforrásként. Ezzel a metódussal frissíthető a külső munkafüzet elérési útja is (ha az át lett helyezve).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti közvetlenül, továbbra is használhatja ezeket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, azt automatikusan átalakítja teljes útvonallá.

Ez a PHP‑kód megmutatja, hogyan állíthat be egy külső munkafüzetet:

```php
  # Létrehozza a Presentation osztály példányát
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

A `ChartData` paraméter (a `setExternalWorkbook` metódus alatt) azt jelzi, hogy egy Excel‑munkafüzetet be kell‑tölteni vagy sem.

* Ha a `ChartData` értéke **false**, csak a munkafüzet útvonala frissül – a diagram adatai nem töltődnek be, és nem frissülnek a célmunkafüzetről. Ezt a beállítást akkor érdemes használni, ha a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha a `ChartData` értéke **true**, a diagram adatai frissülnek a célmunkafüzetből.

```php
  # Létrehozza a Presentation osztály példányát
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Diagram külső adatforrás‑munkafüzetének útvonalának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.  
2. Szerezze be egy dia referenciáját az indexe alapján.  
3. Hozzon létre egy objektumot a diagram alakzathoz.  
4. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típusához, amely a diagram adatforrását képviseli.  
5. Adja meg a megfelelő feltételt attól függően, hogy a forrás típusa megegyezik‑e a külső munkafüzet adatforrás típusával.

Ez a PHP‑kód bemutatja a műveletet:

```php
  # Létrehozza a Presentation osztály egy példányát
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Elmenti a prezentációt
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Diagram adatainak szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetekét. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a PHP‑kód a leírt folyamat megvalósítását mutatja:

```php
  # Létrehozza a Presentation osztály egy példányát
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides helyre tudja állítani a diagram munkafüzetét a prezentációban tárolt gyorsítótár‑adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/) objektumot, konfigurálja egy [SpreadsheetOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/spreadsheetoptions/)‑sal, és a megnyitás előtt hívja meg a [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) metódust **true** értékkel.

A következő PHP‑példa megnyit egy olyan prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat a [Chart::getChartData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/#getChartData) és a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével éri el:

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Olvassa vagy módosítsa a helyreállított munkafüzet adatokat itt.
} finally {
    $presentation->dispose();
}
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárban tárolt diagramadat a kívánt tartalék, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzet legutóbbi módosításait a prezentáció legutóbeli frissítése óta.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzetre hivatkozik?**  
Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getdatasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getexternalworkbookpath/) tulajdonsággal; ha a forrás külső munkafüzet, a teljes útvonalból megállapítható, hogy külső fájlt használ.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**  
Igen. Ha relatív útvonalat ad meg, azt automatikusan átalakítja abszolút útvonallá. Ez kényelmes a projekt hordozhatósága szempontjából; azonban a prezentáció az abszolút útvonalat tárolja a PPTX‑ben.

**Használhatok hálózati erőforrások/ megosztásokon található munkafüzeteket?**  
Igen, az ilyen munkafüzetek használhatók külső adatforrásként. A távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként alkalmazhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**  
Nem. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getexternalworkbookpath/) tárol, és azt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**  
Az Aspose.Slides nem fogad el jelszót a hivatkozáskor. Általános megoldás, hogy előre eltávolítja a védelmet, vagy egy visszafejtett másolatot készít (például az [Aspose.Cells](/cells/php-java/) segítségével), majd arra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**  
Igen. Minden diagram a saját linkjét tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramnál megjelenik a következő adatbetöltéskor.