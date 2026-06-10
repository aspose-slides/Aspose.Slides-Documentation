---
title: Optimalizálja a diagram számításokat prezentációkhoz PHP-ben
linktitle: Diagram számítások
type: docs
weight: 50
url: /hu/php-java/chart-calculations/
keywords:
- diagram számítások
- diagram elemek
- elem pozíció
- tényleges pozíció
- gyermek elem
- szülő elem
- diagram értékek
- tényleges érték
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Értsd meg a diagram számításokat, az adatok frissítését és a pontosság szabályozását az Aspose.Slides for PHP via Java-ban PPT és PPTX esetén, gyakorlati kódpéldákkal."
---
## **Áttekintés**

Aspose.Slides API-kat biztosít a diagramok számításaihoz és elrendezési adatainak kezeléséhez a prezentációkban. Ez a cikk bemutatja, hogyan lehet lekérni a diagramelemek tényleges értékeit, beleértve az elemek valós pozícióját és méretét, valamint a diagramtengelyek tényleges értékeit. Az is kifejti, hogy ezek az értékek a diagramelrendezés ellenőrzése után töltődnek fel.

Továbbá a cikk bemutatja, hogyan lehet lekérni a szülő diagramelemek tényleges pozícióját, valamint hogyan lehet elrejteni a diagram komponenseit, például a címet, tengelyeket, jelmagyarázatot és rácsvonalakat. Ezek a példák segítenek a diagramelrendezési információk ellenőrzésében és a diagramelemek láthatóságának programozott vezérlésében a PowerPoint-prezentációkban.

## **A diagramelemek tényleges értékeinek kiszámítása**
Aspose.Slides for PHP via Java egy egyszerű API-t biztosít ezeknek a tulajdonságoknak a lekérdezéséhez. Az [Axis](https://reference.aspose.com/slides/hu/php-java/aspose.slides/axis/) osztály metódusai információt nyújtanak a tengely diagramelem tényleges pozíciójáról ([getActualMaxValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/hu/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/hu/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/hu/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/hu/php-java/aspose.slides/axis/getactualminorunitscale/)). A tulajdonságok tényleges értékekkel való feltöltéséhez először meg kell hívni a [Chart.validateChartLayout](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/validatechartlayout/) metódust.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **A szülő diagramelemek tényleges pozíciójának kiszámítása**
Aspose.Slides for PHP via Java egy egyszerű API-t biztosít ezeknek a tulajdonságoknak a lekérdezéséhez. Az `ActualLayout` osztály metódusai információt nyújtanak a szülő diagramelem tényleges pozíciójáról (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). A tulajdonságok tényleges értékekkel való feltöltéséhez először meg kell hívni a [Chart.validateChartLayout](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/validatechartlayout/) metódust.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Diagramelemek elrejtése**
Ez a téma segít megérteni, hogyan lehet elrejteni az információkat a diagramból. Az Aspose.Slides for PHP via Java segítségével elrejtheti a **Cím, Függőleges tengely, Vízszintes tengely** és **Rácsvonalak** elemeket a diagramról. Az alábbi kódrészlet bemutatja, hogyan használhatók ezek a tulajdonságok.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # A diagram címének elrejtése
    $chart->setTitle(false);
    # /Az érték tengely elrejtése
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Kategória tengely láthatósága
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Jelmagyarázat elrejtése
    $chart->setLegend(false);
    # Fő rácsvonalak elrejtése
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Sorvonal színének beállítása
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Működnek-e külső Excel munkafüzetek adatforrásként, és ez hogyan befolyásolja az újraszámítást?**

Igen. A diagram hivatkozhat külső munkafüzetre: amikor csatlakozik vagy frissíti a külső forrást, a képletek és értékek a munkafüzetről kerülnek be, és a diagram a nyitási/szerkesztési műveletek során tükrözi a frissítéseket. Az API lehetővé teszi, hogy [specify the external workbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/setexternalworkbook/) útvonalat adjon meg, és kezelje a kapcsolt adatokat.

**Számíthatok és jeleníthetek meg trendvonalakat anélkül, hogy saját regressziót implementálnék?**

Igen. A [Trendlines](/slides/hu/php-java/trend-line/) (lineáris, exponenciális és egyéb) vonalakat az Aspose.Slides adja hozzá és frissíti; paramétereiket a sorozat adataiból számítja újra automatikusan, így nincs szükség saját számítások implementálására.

**Ha egy prezentáció több diagrammal rendelkezik, amelyek külső hivatkozásokat tartalmaznak, szabályozhatom-e, hogy melyik munkafüzetet használja a diagram a számított értékekhez?**

Igen. Minden diagram hivatkozhat a saját [external workbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/setexternalworkbook/) munkafüzeteire, vagy létrehozhat/lecserélhet egy külső munkafüzetet diagramonként függetlenül a többitől.