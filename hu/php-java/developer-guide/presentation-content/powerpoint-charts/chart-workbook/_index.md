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
description: "Fedezze fel az Aspose.Slides-t PHP-hez Java-n keresztül: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációja adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhatunk diagrammunnevkönyvekkel az Aspose.Slides-ban. Bemutatja, hogyan olvashatunk és írhatunk diagram adatokat munkafüzet áramlatokon keresztül, hogyan használhatjuk a munkafüzet cellákat diagram adatcímkeként, hogyan érhetjük el a munkalap-gyűjteményeket, és hogyan adhatjuk meg az adatforrás típusát a diagramértékekhez.

Emellett kitér a külső munkafüzetek diagram adatforrásként való használatára is. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolt külső munkafüzet útvonalát, illetve hogyan szerkeszthetjük a diagram adatokat, ha a munkafüzet elérhető.

## **Diagramadatok olvasása és írása munkafüzetből**
Az Aspose.Slides a [readWorkbookStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#readWorkbookStream) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#writeWorkbookStream) metódusokkal lehetővé teszi diagramadatok munkafüzetek (amelyek az Aspose.Cells‑el szerkesztett diagramadatokat tartalmazzák) olvasását és írását. **Megjegyzés**, hogy a diagramadatokat ugyanúgy kell szervezni, vagy hasonló szerkezettel kell rendelkezniük, mint a forrás.

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

### **Diagram elrendezésének ellenőrzése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosítottra cserélünk, a diagram megtartja az eredeti sorozat- és kategória‑gyűjteményeit. Ez az eltérés a [Chart::validateChartLayout](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/validatechartlayout/) hibáját okozhat, index‑hatókívülű hibaüzenettel. Írja felül a sorozat‑ és kategória‑gyűjteményeket, mielőtt a frissített munkafüzetet visszaírná a diagramba.

```php
// A munkafüzet adatfolyam módosítása után (pl. az Aspose.Cells használatával)
$updatedWorkbook = $chartData->readWorkbookStream();

// A meglévő adatreferenciák törlése.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

A gyűjtemények törlése biztosítja, hogy a diagram adatstruktúrája konzisztens legyen az új munkafüzettel, így a `validateChartLayout` hiba nélkül lefut.

## **Munkafüzet cellájának beállítása diagram adatcímkeként**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.  
2. Szerezzen be egy dia referenciáját az indexe alapján.  
3. Adjon hozzá egy buborék diagramot némi adattal.  
4. Hozzáférjen a diagram sorozatához.  
5. Állítsa be a munkafüzet celláját adatcímkének.  
6. Mentse el a prezentációt.

Ez a PHP‑kód megmutatja, hogyan állíthat be egy munkafüzet celláját diagram adatcímkeként:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Egy példányt hoz létre a prezentáció osztályból, amely egy prezentációs fájlt képvisel
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

Ez a PHP‑kód egy olyan műveletet mutat be, ahol a [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#getWorksheets) metódust használják a munkalap‑gyűjtemény elérésére:

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

## **Adatforrás típusának megadása**

Ez a PHP‑kód azt mutatja, hogyan adhatunk meg egy típust egy adatforráshoz:

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

Az Aspose.Slides nem támogatja a néhány diagramba beágyazható Excel bináris munkafüzet (.xlsb) formátumot. A `getEmbeddedWorkbookType` metódust a [ChartData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/)‑on és a [WorkbookType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/workbooktype/) felsorolással együtt használva fel tudja ismerni a nem támogatott formátumokat, és átléphet ezeket a diagramokat.

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
      # A beágyazott munkafüzet .xlsb formátumú, amely nem támogatott.
      continue;
    }

    # Olvassa vagy módosítsa a diagram munkafüzet adatait itt.
  }
} finally {
  $presentation->dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides külső munkafüzeteket támogat adatforrásként a diagramokhoz.

### **Külső munkafüzet létrehozása**

A **`readWorkbookStream`** és a **`setExternalWorkbook`** metódusok segítségével vagy teljesen új külső munkafüzetet hozhatunk létre, vagy egy belső munkafüzetet tehetünk külsővé.

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

A **`setExternalWorkbook`** metódus segítségével hozzárendelhet egy külső munkafüzetet egy diagramhoz adatforrásként. Ez a metódus arra is használható, hogy egy külső munkafüzet útvonalát frissítsük (ha az később áthelyezésre került).

Míg a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem lehet közvetlenül szerkeszteni, továbbra is használhatók külső adatforrásként. Ha relatív útvonalat adunk meg egy külső munkafüzethez, azt automatikusan teljes útvonallá konvertálja a rendszer.

Ez a PHP‑kód megmutatja, hogyan állíthat be egy külső munkafüzetet:

```php
  # Létrehozza a Presentation osztály egy példányát
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

A `ChartData` paraméter (a `setExternalWorkbook` metódus alatt) azt határozza meg, hogy egy Excel‑munkafüzet be lesz‑ vagy be nem lesz‑töltve.

* Ha a `ChartData` értéke **false**, csak a munkafüzet útvonala frissül – a diagramadat nem kerül betöltésre vagy frissítésre a célmunkafüzetről. Ezt a beállítást akkor érdemes használni, ha a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha a `ChartData` értéke **true**, a diagramadatok a célmunkafüzetről frissülnek.

```php
  # Létrehozza a Presentation osztály egy példányát
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

### **Diagram külső adatforrás‑munkafüzet útvonalának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.  
2. Szerezzen be egy dia referenciáját az indexe alapján.  
3. Készítsen egy objektumot a diagram alakzathoz.  
4. Hozzon létre egy objektumot a forrást (`ChartDataSourceType`) reprezentáló típushoz, amely a diagram adatforrását jelöli.  
5. Adja meg a megfelelő feltételt a forrástípusnak a külső munkafüzet adatforrás‑típusával megegyező módon.

Ez a PHP‑kód demonstrálja a műveletet:

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
    # A prezentáció mentése
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Diagramadatok szerkesztése**

Külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetek tartalmát. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a PHP‑kód a leírt folyamat megvalósítása:

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

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides a prezentációban gyorsítótárazott adatokból rekonstruálhatja a diagram munkafüzetét. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/)‑t, konfigurálja egy [SpreadsheetOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/spreadsheetoptions/)‑szal, és hívja meg a [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) metódust **true** értékkel, mielőtt megnyitná a prezentációt.

Az alábbi PHP‑példa megnyit egy prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat a [Chart::getChartData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/#getChartData) és a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével éri el:

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Olvassa vagy módosítsa a helyreállított munkafüzet adatait itt.
} finally {
    $presentation->dispose();
}
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható tartalék, mivel a gyorsítótár nem biztos, hogy tartalmazza a külső munkafüzetben a prezentáció legutóbbi mentése óta végrehajtott módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram egy külső vagy beágyazott munkafüzethez kapcsolódik‑e?**  
Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getdatasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getexternalworkbookpath/) tulajdonsággal; ha a forrás egy külső munkafüzet, akkor a teljes útvonalat leolvashatja, hogy megbizonyosodjon róla, hogy külső fájlt használ.

**Támogatottak a relatív útvonalak külső munkafüzetekhez, és hogyan tárolódnak?**  
Igen. Ha relatív útvonalat ad meg, azt a rendszer automatikusan abszolút útvonallá alakítja. Ez kényelmes a projekt hordozhatósága szempontjából; azonban a prezentáció az abszolút útvonalat tárolja a PPTX‑fájlban.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztott meghajtókon?**  
Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**  
Nem. A prezentáció egy [linket a külső fájlhoz](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getexternalworkbookpath/) tárol, és ezt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszó‑védett?**  
Az Aspose.Slides nem fogad jelszót a hivatkozáskor. Általános megoldás, hogy előre eltávolítja a védelmet, vagy egy visszafejtett másolatot készít (például a [Aspose.Cells](/cells/php-java/) segítségével), és ahhoz a másolathoz kapcsolódik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**  
Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.