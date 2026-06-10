---
title: Diagram munkafüzetek kezelése prezentációkban PHP-val
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/php-java/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adatok
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for PHP Java-n keresztül: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet diagram munkafüzetekkel dolgozni az Aspose.Slides-ban. Megmutatja, hogyan olvassunk és írjunk diagram adatokat munkafüzet‑streameken keresztül, hogyan használjunk munkafüzet‑cellákat diagram adatcímkeként, hogyan érjük el a munkalap‑gyűjteményeket, és hogyan határozzuk meg az adatforrás típusát a diagram értékekhez.

A cikk Kitér arra is, hogyan használhatók külső munkafüzetek adatforrásként a diagramokhoz. A példák bemutatják, hogyan hozzunk létre és rendeljünk hozzá egy külső munkafüzetet, hogyan szerezzük meg egy diagramhoz kapcsolt külső munkafüzet elérési útját, és hogyan szerkesszünk diagram adatokat, ha a munkafüzet elérhető.

## **Olvasás és írás diagram adatok munkafüzetből**
Az Aspose.Slides biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#readWorkbookStream) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/#writeWorkbookStream) metódusokat, amelyek lehetővé teszik diagram adat munkafüzetek (az Aspose.Cells‑szel szerkesztett diagram adatokat tartalmazó) olvasását és írását. **Megjegyzés:** a diagram adatokat ugyanúgy kell szervezni, vagy hasonló szerkezettel kell rendelkezniük, mint a forrás.

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

## **Munkafüzet‑cellát beállítása diagram adatcímkeként**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
2. Szerezze meg egy dia hivatkozását az indexe alapján.
3. Adjon hozzá egy buborékdiagramot némi adattal.
4. Hozzáférjen a diagram sorozataihoz.
5. Állítsa be a munkafüzet‑cellát adatcímkeként.
6. Mentse a prezentációt.

Ez a PHP‑kód megmutatja, hogyan állítsunk be egy munkafüzet‑cellát diagram adatcímkeként:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Példányosít egy Presentation osztályt, amely egy prezentáció fájlt képvisel
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

Ez a PHP‑kód bemutat egy műveletet, amelyben a [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#getWorksheets) metódust használják egy munkalap‑gyűjtemény eléréséhez:

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

## **Az adatforrás típusának meghatározása**

Ez a PHP‑kód megmutatja, hogyan adjon meg egy típust egy adatforráshoz:

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

## **Nem támogatott beágyazott munkafüzet‑formátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely bizonyos diagramokba beágyazható. A `getEmbeddedWorkbookType` metódust a [ChartData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/) osztályon együtt a [WorkbookType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/workbooktype/) felsorolással használva felismerheti a nem támogatott formátumokat, és kihagyhatja azokat a diagramokat.

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
      # Beágyazott munkafüzet .xlsb formátumban van, ami nem támogatott.
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

A **`readWorkbookStream`** és a **`setExternalWorkbook`** metódusok használatával vagy egy külső munkafüzetet hozhatunk létre teljesen újra, vagy egy belső munkafüzetet tehetünk külsővé.

Ez a PHP‑kód demonstrálja a külső munkafüzet létrehozási folyamatát:

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

A **`setExternalWorkbook`** metódus segítségével egy külső munkafüzetet rendelhet a diagramhoz adatforrásként. Ezzel a metódussal frissíthető a külső munkafüzet elérési útja is (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkeszthetjük, továbbra is használhatók külső adatforrásként. Ha relatív elérési út kerül megadásra egy külső munkafüzethez, az automatikusan teljes úttá alakul.

Ez a PHP‑kód megmutatja, hogyan állítsunk be egy külső munkafüzetet:

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

A `ChartData` paraméter (a `setExternalWorkbook` metódus alatt) arra szolgál, hogy meghatározza, betöltődjön‑e egy Excel‑munkafüzet.

* Ha a `ChartData` értéke `false`, csak a munkafüzet útvonala frissül – a diagram adat nem töltődik be vagy frissül a célmunkafüzetből. Ezt a beállítást akkor érdemes használni, ha a célmunkafüzet nem létezik vagy nem érhető el.
* Ha a `ChartData` értéke `true`, a diagram adatai frissülnek a célmunkafüzetből.

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

### **A diagram külső adatforrás‑munkafüzetének elérési útjának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
2. Szerezze meg egy dia hivatkozását az indexe alapján.
3. Hozzon létre egy objektumot a diagram alakzatához.
4. Hozzon létre egy objektumot a forrást (`ChartDataSourceType`) reprezentáló típushoz, amely a diagram adatforrását jelöli.
5. Határozza meg a megfelelő feltételt, amely alapján a forrástípus egyezik a külső munkafüzet adatforrás‑típusával.

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
    # Elmenti a prezentációt
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Diagram adat szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát módosítaná. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

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

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van-e kapcsolva?**

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getdatasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getexternalworkbookpath/) tulajdonsággal; ha a forrás egy külső munkafüzet, kiolvashatja a teljes elérési utat, hogy megbizonyosodjon a külső fájl használatáról.

**Támogatottak a relatív utak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Relatív út megadása esetén automatikusan abszolút útra konvertálódik. Ez kényelmes a projekt hordozhatósága szempontjából; azonban a prezentáció a PPTX‑fájlban az abszolút utat tárolja.

**Használhatók hálózati erőforrásokon/megosztott helyeken lévő munkafüzetek?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. A távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

Nem. A prezentáció egy [linket a külső fájlhoz](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getexternalworkbookpath/) tárol, és ezt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a kapcsolódáskor. Általános megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat előkészítése (például a [Aspose.Cells](/cells/php-java/) segítségével), majd a másolathoz való kapcsolódás.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját linket tárol. Ha mind ugyanarra a fájlra mutatnak, a fájl frissítése minden diagramnál megjelenik a következő adatbetöltéskor.