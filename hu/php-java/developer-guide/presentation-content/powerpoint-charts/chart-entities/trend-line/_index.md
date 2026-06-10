---
title: Trendvonalak hozzáadása a PowerPoint-diagramokhoz PHP-ben
linktitle: Trendvonal
type: docs
url: /hu/php-java/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgó átlag trendvonal
- polinomiális trendvonal
- hatvány trendvonal
- egyéni trendvonal
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Gyorsan adjon hozzá és testreszabjon trendvonalakat a PowerPoint-diagramokban az Aspose.Slides for PHP via Java segítségével — egy gyakorlati útmutató a közönség bevonásához."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet trendvonalakat hozzáadni a prezentáció diagramjaihoz az Aspose.Slides használatával. Megmutatja, hogyan kell diagramot létrehozni, trendvonalakat hozzáadni a diagram sorozataihoz, és többféle trendvonal típussal dolgozni, beleértve az exponenciális, lineáris, logaritmikus, mozgó átlag, polinomiális és hatvány trendvonalakat.

Leírja továbbá, hogyan lehet egy egyéni vonalat hozzáadni a diagramhoz egy vonal alakzat beszúrásával, és tartalmaz egy rövid GYIK-et a trendvonalak előre és hátra vetített értékeiről, valamint arról, hogy a trendvonalak megmaradnak-e a PDF vagy SVG formátumba exportáláskor, illetve a diagramok képként történő renderelésekor.

## **Trendvonal hozzáadása**
Aspose.Slides for PHP via Java egyszerű API-t biztosít a különböző diagram trendvonalak kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
1. Szerezze meg a diára mutató hivatkozást az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típus valamelyikével (ebben a példában a ChartType::ClusteredColumn típust használja).
1. Exponenciális trendvonal hozzáadása az 1. diagram sorozathoz.
1. Lineáris trendvonal hozzáadása az 1. diagram sorozathoz.
1. Logaritmikus trendvonal hozzáadása a 2. diagram sorozathoz.
1. Mozgó átlag trendvonal hozzáadása a 2. diagram sorozathoz.
1. Polinomiális trendvonal hozzáadása a 3. diagram sorozathoz.
1. Hatvány trendvonal hozzáadása a 3. diagram sorozathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

A következő kódot használják trendvonalakkal ellátott diagram létrehozásához.

```php
  # Presentation osztály egy példányának létrehozása
  $pres = new Presentation();
  try {
    # Csoportos oszlopdiagram létrehozása
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Exponenciális trendvonal hozzáadása az 1. diagram sorozathoz
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Lineáris trendvonal hozzáadása az 1. diagram sorozathoz
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Logaritmikus trendvonal hozzáadása a 2. diagram sorozathoz
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # Mozgó átlag trendvonal hozzáadása a 2. diagram sorozathoz
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # Polinomiális trendvonal hozzáadása a 3. diagram sorozathoz
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Hatvány trendvonal hozzáadása a 3. diagram sorozathoz
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # Prezentáció mentése
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Egyéni vonal hozzáadása**
Aspose.Slides for PHP via Java egyszerű API-t biztosít egyéni vonalak diagramhoz való hozzáadásához. Egyszerű egyenes vonal hozzáadásához a prezentáció kiválasztott diájához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból
- Szerezze meg egy dia hivatkozását az Index használatával
- Hozzon létre egy új diagramot a Shapes objektum által biztosított AddChart metódussal
- Adjon hozzá egy Line típusú AutoShape-et a Shapes objektum által biztosított AddAutoShape metódussal
- Állítsa be a forma vonalainak színét.
- Mentse a módosított prezentációt PPTX fájlként

A következő kódot használják egyéni vonalakkal ellátott diagram létrehozásához.

```php
  # Presentation osztály egy példányának létrehozása
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Mi jelent a 'forward' és a 'backward' egy trendvonalnál?**

Ezek a trendvonal előre/hátra kiterjesztett hosszai: szórt (XY) diagramok esetén a tengelyegységekben; nem szórt diagramok esetén a kategóriák számában. Csak nem negatív értékek megengedettek.

**Megmarad a trendvonal a prezentáció PDF vagy SVG formátumba exportálásakor, illetve a dia képként történő renderelésekor?**

Igen. Az Aspose.Slides a prezentációkat [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/hu/php-java/render-a-slide-as-an-svg-image/) formátumba konvertálja, és a diagramokat képekké rendereli; a trendvonalak, mint a diagram részei, megmaradnak ezek során. Egy módszer is elérhető a diagram [képének exportálásához](/slides/hu/php-java/create-shape-thumbnails/).