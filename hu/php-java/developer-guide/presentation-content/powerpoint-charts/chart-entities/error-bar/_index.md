---
title: Hibasávok testreszabása prezentációs diagramokban PHP használatával
linktitle: Hibasáv
type: docs
url: /hu/php-java/error-bar/
keywords:
- hibasáv
- egyéni érték
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és testreszabhat hibasávokat a diagramokban az Aspose.Slides for PHP via Java segítségével — optimalizálja az adatmegjelenítést PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet hibasávokkal dolgozni a prezentációs diagramokban az Aspose.Slides használatával. Megmutatja, hogyan adhatunk hibasávokat egy diagram sorozathoz, hogyan konfigurálhatjuk az X és Y hibasáv beállításokat, valamint hogyan alkalmazhatunk különböző értéktípusokat, például rögzített, százalékos és egyéni értékeket.

A cikk azt is bemutatja, hogyan rendelhetünk egyéni hibasáv értékeket egy sorozat egyes adatpontjaihoz a megfelelő adatpontgyűjtemény használatával. Ezen felül rövid megjegyzéseket tartalmaz arról, hogy a hibasávok hogyan viselkednek exportálás közben, kompatibilitásukról a jelölőkkel és adatcímkékkel, valamint arról, hol találhatók a kapcsolódó API referenciaklasszok és felsorolások.

## **Hibasávok hozzáadása**
Az Aspose.Slides for PHP via Java egyszerű API-t biztosít a hibasáv értékek kezeléséhez. A példakód akkor érvényes, ha egy egyéni értéktípust használunk. Az érték megadásához használja a **ErrorBarCustomValues** tulajdonságot a sorozat [**adatpontok**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriescollection/) gyűjteményének egy adott adatpontján:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Adjon hozzá egy buborékdiagramot a kívánt diára.  
3. Érje el a diagram első sorozatát, és állítsa be a hibasáv X formátumát.  
4. Érje el a diagram első sorozatát, és állítsa be a hibasáv Y formátumát.  
5. Állítsa be a sávok értékeit és formátumát.  
6. Írja a módosított prezentációt egy PPTX fájlba.

```php
  # Hozzon létre egy példányt a Presentation osztályból
  $pres = new Presentation();
  try {
    # Buborékdiagram létrehozása
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Hibasávok hozzáadása és formátumuk beállítása
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # Prezentáció mentése
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Egyéni hibasáv értékek hozzáadása**
Az Aspose.Slides for PHP via Java egyszerű API-t biztosít az egyéni hibasáv értékek kezeléséhez. A példakód akkor érvényes, amikor a [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/errorbarsformat/#getValueType) metódus **Custom** értéket ad vissza. Az érték megadásához használja a **ErrorBarCustomValues** tulajdonságot a sorozat [**adatpontok**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriescollection/) gyűjteményének egy adott adatpontján:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Adjon hozzá egy buborékdiagramot a kívánt diára.  
3. Érje el a diagram első sorozatát, és állítsa be a hibasáv X formátumát.  
4. Érje el a diagram első sorozatát, és állítsa be a hibasáv Y formátumát.  
5. Érje el a diagram sorozat egyedi adatpontjait, és állítsa be az egyes sorozat adatpontok hibasáv értékeit.  
6. Állítsa be a sávok értékeit és formátumát.  
7. Írja a módosított prezentációt egy PPTX fájlba.

```php
  # Hozzon létre egy példányt a Presentation osztályból
  $pres = new Presentation();
  try {
    # Buborékdiagram létrehozása
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Egyéni hibasávok hozzáadása és formátumuk beállítása
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Diagram sorozat adatpontjának elérése és hibasáv értékek beállítása
    # egyedi ponthoz
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Hibasávok beállítása a diagram sorozat pontjaihoz
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Prezentáció mentése
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Mi történik a hibasávokkal, amikor a prezentációt PDF‑re vagy képekre exportálják?**  
A hibasávok a diagram részeként kerülnek renderelésre, és a konverzió során megmaradnak a diagram többi formázásával együtt, feltéve hogy kompatibilis verzió vagy renderelő áll rendelkezésre.

**Kombinálhatók a hibasávok jelölőkkel és adatcímkékkel?**  
Igen. A hibasávok különálló elemek, és kompatibilisek a jelölőkkel és adatcímkékkel; ha az elemek átfednek, előfordulhat, hogy a formázást módosítani kell.

**Hol találhatom meg a hibasávokkal kapcsolatos API tulajdonságok és osztályok listáját?**  
Az API referenciában: a [ErrorBarsFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/errorbarsformat/) osztály és a kapcsolódó osztályok [ErrorBarType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/errorbartype/) és [ErrorBarValueType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/errorbarvaluetype/).