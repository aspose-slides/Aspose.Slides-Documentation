---
title: "Diagrammunkafüzetek kezelése prezentációkban PHP használatával"
linktitle: "Diagrammunkafüzet"
type: docs
weight: 70
url: /hu/php-java/chart-workbook/
keywords:
- "diagrammunkafüzet"
- "diagramadat"
- "munkafüzet cella"
- "adatcímke"
- "munkalap"
- "adatforrás"
- "külső munkafüzet"
- "külső adat"
- "diagram gyorsítótár"
- "munkafüzet helyreállítás"
- "PowerPoint"
- "prezentáció"
- "PHP"
- "Aspose.Slides"
description: "Fedezze fel az Aspose.Slides-ot PHP-hoz Java-n keresztül: könnyedén kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációi adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagrammunkafüzetekkel az Aspose.Slides-ban. Megmutatja, hogyan olvashat és írhat diagramadatokat munkafüzetfolyamokon keresztül, hogyan használhatja a munkafüzet cellákat diagramadatcímkeként, hogyan érheti el a munkalap-gyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagramértékekhez.  
A cikk szintén bemutatja, hogyan dolgozhat külső munkafüzetekkel diagramadatforrásként. A példák azt mutatják be, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérheti le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesztheti a diagramadatakat, ha a munkafüzet elérhető.

## **Olvasás és írás diagramadatok munkafüzetből**

Az Aspose.Slides biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#readWorkbookStream) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#writeWorkbookStream) metódusokat, amelyek lehetővé teszik diagramadat-munkafüzetelek olvasását és írását (amelyek Aspose.Cells segítségével szerkesztett diagramadatokat tartalmaznak). **Megjegyzés**: a diagramadatoknak ugyanolyan módon kell szerveződnie, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.  

Ez a PHP kód egy példa műveletet mutat be:

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

## **Munkafüzet cella beállítása diagramadatcímkének**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy buborékdiagramot némi adattal.  
4. Érje el a diagram sorozatát.  
5. Állítsa be a munkafüzet cellát adatcímkeként.  
6. Mentse a prezentációt.  

Ez a PHP kód bemutatja, hogyan állíthat be egy munkafüzet cellát diagramadatcímkének:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Példányosít egy prezentáció osztályt, amely egy prezentációfájlt reprezentál
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

Ez a PHP kód egy műveletet mutat be, ahol a [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#getWorksheets) metódust használják a munkalap-gyűjtemény eléréséhez:

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

Ez a PHP kód megmutatja, hogyan adhat meg egy típust egy adatforrásnak:

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

## **Nem támogatott beágyazott munkafüzetformátumok felismerése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumát, amelyet egyes diagramokba be lehet ágyazni. A `[ChartData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/)` `getEmbeddedWorkbookType` metódusát a [WorkbookType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/workbooktype/) felsorolással együtt használhatja a nem támogatott formátumok felismerésére és az ilyen diagramok kihagyására.

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
      # Beágyazott munkafüzet .xlsb formátumban van, amely nem támogatott.
      continue;
    }

    # Olvassa vagy módosítsa a diagram munkafüzet adatokat itt.
  }
} finally {
  $presentation->dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzeteket adatforrásként a diagramokhoz.

### **Külső munkafüzet létrehozása**

A **`readWorkbookStream`** és a **`setExternalWorkbook`** metódusok használatával egy külső munkafüzetet hozhat létre a semmiből, vagy egy belső munkafüzetet tehet külsővé.

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

A **`setExternalWorkbook`** metódus használatával egy külső munkafüzetet rendelhet egy diagram adatforrásaként. Ez a metódus arra is felhasználható, hogy frissítse a külső munkafüzet útvonalát (ha az át lett helyezve).  

Bár a távol helyezkedő vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, továbbra is használhatja ezeket a munkafüzeteket külső adatforrásként. Ha egy külső munkafüzet relatív útvonala van megadva, az automatikusan teljes útvonallá alakul.  

Ez a PHP kód bemutatja, hogyan állíthat be egy külső munkafüzetet:

```php
  # Létrehoz egy példányt a Presentation osztályból
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

A `ChartData` paraméter (a `setExternalWorkbook` metódus alatt) azt határozza meg, hogy egy Excel munkafüzet betöltődjön-e vagy sem.  

* Ha a `ChartData` értéke `false`, csak a munkafüzet útvonala frissül – a diagramadatok nem töltődnek be, és nem frissülnek a célmunkafüzetről. Ezt a beállítást akkor érdemes használni, ha a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha a `ChartData` értéke `true`, a diagramadatok a célmunkafüzetről frissülnek.

```php
  # Létrehoz egy példányt a Presentation osztályból
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

### **Diagram külső adatforrás munkafüzetének útvonalának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Hozzon létre egy objektumot a diagram alakzatához.  
4. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típushoz, amely a diagram adatforrását képviseli.  
5. Adja meg a megfelelő feltételt a forrástípus és a külső munkafüzet adatforrástípus egyezősége alapján.  

Ez a PHP kód bemutatja a műveletet:

```php
  # Létrehoz egy példányt a Presentation osztályból
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

### **Diagramadatok szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogyan a belső munkafüzetek tartalmát módosítja. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

```php
  # Létrehoz egy példányt a Presentation osztályból
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

Ha egy diagram egy hiányzó vagy elérhetetlen külső munkafüzetet használ, az Aspose.Slides helyreállíthatja a diagram munkafüzettét a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/) objektumot, konfigurálja [SpreadsheetOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/spreadsheetoptions/) segítségével, és a prezentáció megnyitása előtt hívja meg a [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) metódust `true` értékkel.  

A következő PHP példa megnyit egy prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat a [Chart::getChartData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/#getChartData) és a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével éri el:

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

Ha a külső munkafüzet nem érhető el és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Csak akkor engedélyezze a helyreállítást, ha a gyorsítótárazott diagramadatok használata elfogadható megoldás, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzet legutóbbi frissítése után történt módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van-e kapcsolva?**  
Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getdatasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getexternalworkbookpath/) . Ha a forrás egy külső munkafüzet, akkor leolvashatja a teljes útvonalat, hogy biztosan külső fájlt használ.

**Támogatottak a relatív útvonalak külső munkafüzetekhez, és hogyan tárolódnak?**  
Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. Ez a projekt hordozhatóságát segíti; azonban vegye figyelembe, hogy a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatok munkafüzetet hálózati erőforrásokon/megosztásokon?**  
Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides-ból nem támogatott – csak forrásként használhatók.

**Felülírja az Aspose.Slides a külső XLSX-et a prezentáció mentésekor?**  
Nem. A prezentáció egy [hivatkozás a külső fájlra](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getexternalworkbookpath/) tárolja, és ezt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit kell tennem, ha a külső fájl jelszóval védett?**  
Az Aspose.Slides nem fogad jelszót a kapcsolódáskor. Általános megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat (például a [Aspose.Cells](/cells/php-java/) használatával) előkészítése, és ehhez a másolathoz való csatolás.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**  
Igen. Minden diagram saját hivatkozást tárol. Ha mind ugyanarra a fájlra mutatnak, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.