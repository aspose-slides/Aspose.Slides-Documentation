---
title: Diagramadat-sorozatok kezelése bemutatókban PHP használatával
linktitle: Adatsorozatok
type: docs
url: /hu/php-java/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- kategória szín
- sorozat név
- adatpont
- sorozat hézag
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan kezelje a diagram adat sorozatokat PHP-ben a PowerPoint (PPT/PPTX) számára gyakorlati kódpéldákkal és legjobb gyakorlatokkal, hogy javítsa adatbemutatóit."
---
## **Áttekintés**

Ez a cikk leírja a [ChartSeries](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/) szerepét az Aspose.Slides-ben, és arra összpontosít, hogyan van felépítve és megjelenítve az adat a bemutatókban. Ezek az objektumok alapvető elemeket biztosítanak, amelyek meghatározzák az egyes adatpontkészletek, kategóriák és megjelenési paraméterek halmazát egy diagramon. A [ChartSeries](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/) használatával a fejlesztők zökkenőmentesen integrálhatják az alaprendszer adatforrásait, és teljes kontrollt gyakorolhatnak az információ megjelenítése felett, így dinamikus, adat‑vezérelt bemutatókat hoznak létre, amelyek egyértelműen közvetítik a betekintéseket és elemzéseket.

Egy sorozat egy sor vagy oszlop számokból, amelyeket egy diagramon ábrázolnak.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Állítsa be a diagram sorozat átfedését**

Az [getParentSeriesGroup](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getParentSeriesGroup) metódussal megadhatja, hogy a sávok és oszlopok milyen mértékben fedjék át egymást egy 2D diagramon (tartomány: -100‑tól 100‑ig). Ez a tulajdonság a szülő sorozatcsoport összes sorozatára érvényes: ez a megfelelő csoporttulajdonság leképezése. Ennek következtében a tulajdonság csak olvasható.

Használja a `ChartSeriesGroup::setOverlap` metódust, hogy beállítsa a kívánt `Overlap` értéket.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
1. Adjon hozzá egy csoportosított oszlopdiagramot egy diára.  
1. Érje el az első diagram sorozatot.  
1. Érje el a diagram sorozat `ParentSeriesGroup` tulajdonságát, és állítsa be a kívánt átfedési értéket a sorozatra.  
1. Írja a módosított bemutatót egy PPTX fájlba.  

This PHP code shows you how to set the overlap for a chart series:

```php
  $pres = new Presentation();
  try {
    # Diagramot ad hozzá
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Sorozat átfedést állít be
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # A bemutató fájlt a lemezre írja
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **A sorozat színének módosítása**

Aspose.Slides for PHP via Java lehetővé teszi a sorozat színének módosítását a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
1. Adjon hozzá egy diagramot a diára.  
1. Érje el azt a sorozatot, amelynek a színét módosítani szeretné.  
1. Állítsa be a kívánt kitöltéstípust és kitöltési színt.  
1. Mentse el a módosított bemutatót.  

This PHP code shows you how to change a series' color:

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **A sorozat kategória színének módosítása**

Aspose.Slides for PHP via Java lehetővé teszi a sorozatkategória színének módosítását a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
1. Adjon hozzá egy diagramot a diára.  
1. Érje el azt a sorozatkategóriát, amelynek a színét módosítani szeretné.  
1. Állítsa be a kívánt kitöltéstípust és kitöltési színt.  
1. Mentse el a módosított bemutatót.  

This code  shows you how to change a series category's color:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **A sorozat nevének módosítása** 

Alapértelmezés szerint egy diagram jelmagyarázatának nevei az egyes oszlopok vagy sorok feletti cellák tartalma.

In our example (sample image),

* az oszlopok a *Series 1, Series 2* és *Series 3*;  
* a sorok a *Category 1, Category 2, Category 3* és *Category 4*.

Az Aspose.Slides for PHP via Java lehetővé teszi a sorozat nevének frissítését vagy módosítását a diagram adatában és a jelmagyarázatban.

This PHP code shows you how to change a series' name in its chart data `ChartDataWorkbook`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

This PHP code shows you how to change a series name in its legend through`Series`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **A diagram sorozat kitöltőszínének beállítása**

Aspose.Slides for PHP via Java lehetővé teszi a diagram sorozat automatikus kitöltőszínének beállítását a diagramterületen a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia referenciáját indexe alapján.  
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típus alapján (az alábbi példában a `ChartType::ClusteredColumn`-t használtuk).  
1. Érje el a diagram sorozatát, és állítsa a kitöltőszínt Automatikusra.  
1. Mentse el a bemutatót egy PPTX fájlba.  

This PHP code shows you how to set the automatic fill color for a chart series:

```php
  $pres = new Presentation();
  try {
    # Létrehoz egy csoportosított oszlopdiagramot
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Beállítja a sorozat kitöltési formátumát automatikusra
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # A bemutató fájlt a lemezre írja
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Invertált kitöltőszín beállítása diagram sorozathoz**

Aspose.Slides lehetővé teszi az invertált kitöltőszín beállítását diagram sorozatban a diagramterületen a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia referenciáját indexe alapján.  
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típus alapján (az alábbi példában a `ChartType::ClusteredColumn`-t használtuk).  
1. Érje el a diagram sorozatát, és állítsa a kitöltőszínt invertáltra.  
1. Mentse el a bemutatót egy PPTX fájlba.  

This PHP code demonstrates the operation:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Új sorozatokat és kategóriákat ad hozzá
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # Az első diagram sorozatot veszi és feltölti annak sorozatadatait.
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sorozat beállítása invertálásra negatív érték esetén**

Az Aspose.Slides lehetővé teszi az invertálás beállítását az `IChartDataPoint.InvertIfNegative` és a `ChartDataPoint.InvertIfNegative` tulajdonságokon keresztül. Ha az invertálás ezen tulajdonságokkal van beállítva, az adatpont színei invertálódnak, amikor negatív értéket kap. 

This PHP code demonstrates the operation:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Speciális pont adatainak törlése**

Aspose.Slides for PHP via Java lehetővé teszi a `DataPoints` adatainak törlését egy adott diagram sorozatban a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia referenciáját indexe alapján.  
3. Szerezze meg egy diagram referenciáját indexe alapján.  
4. Iteráljon végig a diagram összes `DataPoints` értékén, és állítsa az `XValue` és `YValue` értékeket nullára.  
5. Törölje az összes `DataPoints`-ot a specifikus diagram sorozatra.  
6. Írja a módosított bemutatót egy PPTX fájlba.  

This PHP code demonstrates the operation:

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **A sorozat hézag szélességének beállítása**

Aspose.Slides for PHP via Java lehetővé teszi a sorozat `GapWidth` értékének beállítását a **`GapWidth`** tulajdonságon keresztül a következő módon:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
1. Érje el az első diát.  
1. Adjon hozzá egy diagramot alapértelmezett adatokkal.  
1. Érjen el bármelyik diagram sorozatot.  
1. Állítsa be a `GapWidth` tulajdonságot.  
1. Írja a módosított bemutatót egy PPTX fájlba.  

This code  shows you how to set a series' Gap Width:

```php
  # Üres bemutatót hoz létre
  $pres = new Presentation();
  try {
    # A bemutató első diájához fér hozzá
    $slide = $pres->getSlides()->get_Item(0);
    # Alapértelmezett adatokkal diagramot ad hozzá
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Beállítja a diagram adatlapjának indexét
    $defaultWorksheetIndex = 0;
    # Lekéri a diagram adat munkalapot
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Sorozatokat ad hozzá
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Kategóriákat ad hozzá
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # A második diagram sorozatot veszi
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Feltölti a sorozat adatait
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Beállítja a GapWidth értékét
    $series->getParentSeriesGroup()->setGapWidth(50);
    # A bemutatót lemezre menti
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Van korlát arra, hogy egy diagram hány sorozatot tartalmazhat?**

Az Aspose.Slides nem szab ki fix határt a hozzáadott sorozatok számára. A gyakorlati felső határt a diagram olvashatósága és az alkalmazás rendelkezésére álló memória korlátozza.

**Mi van, ha a csoporton belüli oszlopok túl közel vagy túl távol vannak egymástól?**

Állítsa be a `GapWidth` értékét az adott sorozatra (vagy annak szülő sorozatcsoportjára). Az érték növelése növeli az oszlopok közötti távolságot, a csökkentése közelebb hozza őket egymáshoz.