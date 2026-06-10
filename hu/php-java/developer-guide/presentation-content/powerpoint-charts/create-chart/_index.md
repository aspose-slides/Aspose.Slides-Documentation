---
title: PowerPoint-prezentáció diagramjainak létrehozása vagy frissítése PHP-ben
linktitle: Diagramok létrehozása vagy frissítése
type: docs
weight: 10
url: /hu/php-java/create-chart/
keywords:
- diagram hozzáadása
- diagram létrehozása
- diagram szerkesztése
- diagram módosítása
- diagram frissítése
- szórt diagram
- kördiagram
- vonaldiagram
- fa térkép diagram
- részvény diagram
- doboz és szárnydiagram
- tölcsér diagram
- napfény diagram
- hisztogram diagram
- radar diagram
- többkategóriás diagram
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Diagramok létrehozása és testreszabása PowerPoint-prezentációkban az Aspose.Slides for PHP Java-on keresztül. Diagramok hozzáadása, formázása és szerkesztése gyakorlati kódrészletekkel."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt arról, hogyan hozhatunk létre és testreszabhatunk diagramokat az Aspose.Slides segítségével. Megtanulja, hogyan adhat programozott módon diagramot egy diára, hogyan töltheti fel adatokkal, és hogyan alkalmazhat különféle formázási lehetőségeket a tervezési követelményeknek megfelelően. A cikkben részletes kódrészletek szemléltetik az egyes lépéseket, a prezentáció és a diagramobjektum inicializálásától a sorok, tengelyek és jelmagyarázatok konfigurálásáig. Az útmutató követésével alapos megértést szerezhet a dinamikus diagramgenerálás integrálásáról alkalmazásaiba, megkönnyítve az adatvezérelt prezentációk létrehozását.

## **Diagram létrehozása**

A diagramok segítenek az embereknek gyorsan megjeleníteni az adatokat és felismerni az összefüggéseket, amelyek egy táblázatból vagy táblázatkezelőből nem azonnal láthatók. 

**Miért hozzunk létre diagramokat?**

A diagramok használatával

* nagy mennyiségű adatot aggregálhat, sűríthet vagy összefoglalhat egyetlen dián egy prezentációban
* mintákat és trendeket tárhat fel az adatokban
* meghatározhatja az adat időbeli vagy egy adott mérőegységhez viszonyított irányát és lendületét
* feltárhatja a kiugró, rendellenes, eltérő, hibás vagy értelmetlen adatokat
* összetett adatokat kommunikálhat vagy mutathat be

PowerPointban a beszúrás funkcióval hozhatunk létre diagramokat, amely sablonokat biztosít számos diagramtípus megtervezéséhez. Az Aspose.Slides segítségével normál (népszerű diagramtípusokon alapuló) és egyedi diagramokat egyaránt létrehozhat. 

{{% alert color="primary" %}} 

A diagramok létrehozásához az Aspose.Slides a [ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ChartType) osztályt biztosítja. Ennek az osztálynak a mezői a különböző diagramtípusoknak felelnek meg.

{{% /alert %}} 

### **Normál diagramok létrehozása**

_Lépések: Diagram létrehozása_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Lépések:</em> PowerPoint-diagram létrehozása </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Lépések:</em> Prezentáció-diagram létrehozása </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Lépések:</em> PowerPoint-prezentáció-diagram létrehozása </strong></a>

_Kódlépések:_

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia hivatkozását a sorszám alapján.
3. Adjon hozzá egy diagramot némi adatokkal, és adja meg a kívánt diagramtípust. 
4. Adjon címet a diagramnak. 
5. Hozzon hozzáférést a diagram adatlapjához. 
6. Törölje az összes alapértelmezett sorozatot és kategóriát. 
7. Adjon hozzá új sorozatokat és kategóriákat. 
8. Adjon hozzá új diagramadatokat a sorozathoz. 
9. Állítson be kitöltőszínt a sorozathoz. 
10. Adjon címkéket a sorozathoz. 
11. Írja a módosított prezentációt PPTX fájlként. 

Ez a PHP-kód bemutatja, hogyan hozhat létre egy normál diagramot:

```php
  # Példányosít egy Presentation osztályt, amely egy PPTX fájlt reprezentál
  $pres = new Presentation();
  try {
    # Eléri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Diagramot ad hozzá alapértelmezett adatokkal
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Beállítja a diagram címét
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Az első sorozatot beállítja, hogy értékeket mutasson
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Beállítja a diagram adatlap indexét
    $defaultWorksheetIndex = 0;
    # Megkapja a diagram adatlapot
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Törli az alapértelmezett létrehozott sorozatokat és kategóriákat
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Új sorozatokat ad hozzá
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Új kategóriákat ad hozzá
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Az első diagram sorozatot veszi
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Most feltölti a sorozat adataival
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Beállítja a sorozat kitöltőszínét
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # A második diagram sorozatot veszi
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Feltölti a sorozat adataival
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Beállítja a sorozat kitöltőszínét
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Egyéni címkéket hoz létre az új sorozat minden kategóriájához
    # Az első címkét beállítja, hogy a kategória nevét mutassa
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # A harmadik címkén értéket mutat
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Mentse a prezentációt diagrammal
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Szórt diagramok létrehozása**
A szórt diagramok (más néven szórt ábrák vagy x‑y grafikonok) gyakran használatosak minták keresésére vagy két változó közötti korreláció bemutatására. 

Szórt diagramra akkor lehet szüksége, ha

* párosított numerikus adatokat tartalmaz
* két változó jól párosítható egymással
* meg akarja határozni, hogy a két változó összefügg-e
* van egy független változó, amelynek több értéke van egy függő változóhoz képest

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Lépések:</em> Szórt diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Lépések:</em> PowerPoint-szórt diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Lépések:</em> PowerPoint-prezentáció-szórt diagram létrehozása </strong></a>

1. Kövesse a fenti lépéseket a [Normál diagramok létrehozása](#creating-normal-charts) résznél.
2. A harmadik lépésnél adjon hozzá egy diagramot némi adatokkal, és a diagramtípust válassza az alábbiak közül  
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Szórt diagram pontokkal._  
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Szórt diagram sima vonalakkal és pontokkal._  
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Szórt diagram sima vonalakkal, pontok nélkül._  
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Szórt diagram egyenes vonalakkal és pontokkal._  
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Szórt diagram egyenes vonalakkal, pontok nélkül._  

Ez a PHP-kód bemutatja, hogyan hozhat létre szórt diagramokat különböző pontozási sorozatokkal:

```php
  # Példányosít egy presentation class-t, amely egy PPTX fájlt reprezentál
  $pres = new Presentation();
  try {
    # Eléri az első diát
    $slide = $pres->getSlides()->get_Item(0);
    # Létrehozza az alapértelmezett diagramot
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Lekéri az alapértelmezett diagram adatlap indexét
    $defaultWorksheetIndex = 0;
    # Lekéri a diagram adatlapját
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Törli a demó sorozatot
    $chart->getChartData()->getSeries()->clear();
    # Új sorozatokat ad hozzá
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Az első diagram sorozatot veszi
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Új pontot (1:3) ad a sorozathoz
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Új pontot (2:10) ad
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Megváltoztatja a sorozat típusát
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Megváltoztatja a diagram sorozat jelölőjét
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # A második diagram sorozatot veszi
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Ott egy új pontot (5:2) ad
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Új pontot (3:1) ad
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Új pontot (2:2) ad
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Új pontot (5:1) ad
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Megváltoztatja a diagram sorozat jelölőjét
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Kördiagramok létrehozása**

A kördiagramok leginkább a teljes egészhez viszonyított részek megjelenítésére alkalmasak, különösen, ha a adatok kategóriákat tartalmaznak numerikus értékekkel. Ha azonban túl sok rész vagy címke van, érdemes oszlopdiagramot használni. 

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Lépések:</em> Kördiagram létrehozása </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Lépések:</em> PowerPoint-kördiagram létrehozása </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Lépések:</em> PowerPoint-prezentáció kördiagram létrehozása </strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia hivatkozását a sorszám alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal és a kívánt típussal (jelen esetben a [ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ChartType).Pie).
4. Hozzon hozzáférést a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) objektumhoz.
5. Törölje az alapértelmezett sorozatot és kategóriát.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a sorozathoz.
8. Adjon új pontokat a diagramhoz, és állítson be egyedi színeket a kördiagram szektoraihoz.
9. Állítson be címkéket a sorozathoz.
10. Állítson be mutatóvonalakat a sorozatcímkékhez.
11. Állítsa be a forgási szöget a kördiagram diákhoz.
12. Mentse a módosított prezentációt PPTX fájlként. 

Ez a PHP-kód bemutatja, hogyan hozhat létre egy kördiagramot:

```php
  # Példányosít egy presentation class-t, amely egy PPTX fájlt reprezentál
  $pres = new Presentation();
  try {
    # Eléri az első diát
    $slides = $pres->getSlides()->get_Item(0);
    # Alapértelmezett adatokkal ad hozzá egy diagramot
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Beállítja a diagram címét
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Az első sorozatot beállítja, hogy értékeket mutasson
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Beállítja a diagram adatlap indexét
    $defaultWorksheetIndex = 0;
    # Lekéri a diagram adatlapját
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Törli az alapértelmezett generált sorozatokat és kategóriákat
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Új kategóriákat ad hozzá
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Új sorozatot ad hozzá
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Feltölti a sorozat adataival
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Nem működik az új verzióban
    # Új pontok hozzáadása és a szektor színének beállítása
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Beállítja a szektor szegélyét
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Beállítja a szektor szegélyét
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Beállítja a szektor szegélyét
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # Egyéni címkéket hoz létre az új sorozat minden kategóriájához
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # Megjeleníti a vezetővonalakat a diagramhoz
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Beállítja a kördiagram szektorok forgatási szögét
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Mentse a prezentációt diagrammal
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven vonalgrafikonok) leginkább olyan helyzetekben használatosak, ahol az értékek időbeli változását szeretné bemutatni. A vonaldiagram segítségével egyszerre sok adatot hasonlíthat össze, nyomon követheti az időbeli változásokat és trendeket, kiemelheti a sorozatokban előforduló anomáliákat stb.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia hivatkozását a sorszám alapján.  
1. Adjon hozzá egy diagramot alapértelmezett adatokkal és a kívánt típussal (jelen esetben `ChartType::Line`).  
1. Hozzon hozzáférést a diagram adatainak IChartDataWorkbook-hez.  
1. Törölje az alapértelmezett sorozatot és kategóriát.  
1. Adjon hozzá új sorozatokat és kategóriákat.  
1. Adjon hozzá új diagramadatokat a sorozathoz.  
1. Mentse a módosított prezentációt PPTX fájlként.  

Ez a PHP-kód bemutatja, hogyan hozhat létre egy vonaldiagramot:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Alapértelmezés szerint a vonaldiagram pontjait egyenes folytonos vonalak kötik össze. Ha pontokat kötődjön helyettük szaggatott vonal, megadhatja a kívánt vonaltípust a következő módon:

```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```

### **Fa térkép diagramok létrehozása**

A fa térkép diagramok leginkább értékesítési adatok esetén hasznosak, amikor a kategóriák relatív méretét szeretné megjeleníteni, és egyben gyorsan fel akarja hívni a figyelmet az egyes kategóriák nagy hozzájáruló elemeire. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Lépések:</em> Fa térkép diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Lépések:</em> PowerPoint-fa térkép diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Lépések:</em> PowerPoint-prezentáció fa térkép diagram létrehozása </strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását a sorszám alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal és a kívánt típussal (jelen esetben a [ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ChartType).TreeMap).  
4. Hozzon hozzáférést a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) objektumhoz.  
5. Törölje az alapértelmezett sorozatot és kategóriát.  
6. Adjon hozzá új sorozatokat és kategóriákat.  
7. Adjon hozzá új diagramadatokat a sorozathoz.  
8. Mentse a módosított prezentációt PPTX fájlként.  

Ez a PHP-kód bemutatja, hogyan hozhat létre egy fa térkép diagramot:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # ág 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # ág 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Részvény diagramok létrehozása**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Lépések:</em> Részvény diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Lépések:</em> PowerPoint-részvény diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Lépések:</em> PowerPoint-prezentáció részvény diagram létrehozása </strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását a sorszám alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal és a kívánt típussal ([ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ChartType).OpenHighLowClose).  
4. Hozzon hozzáférést a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) objektumhoz.  
5. Törölje az alapértelmezett sorozatot és kategóriát.  
6. Adjon hozzá új sorozatokat és kategóriákat.  
7. Adjon hozzá új diagramadatokat a sorozathoz.  
8. Adja meg a HiLowLines formátumát.  
9. Mentse a módosított prezentációt PPTX fájlként.  

A részvény diagram létrehozásához használt minta PHP-kód:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    foreach($chart->getChartData()->getSeries() as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Doboz‑ és szárnydiagramok létrehozása**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Lépések:</em> Doboz‑ és szárnydiagram létrehozása </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Lépések:</em> PowerPoint-doboz‑ és szárnydiagram létrehozása </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Lépések:</em> PowerPoint-prezentáció doboz‑ és szárnydiagram létrehozása </strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását a sorszám alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal és a kívánt típussal ([ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ChartType).BoxAndWhisker).  
4. Hozzon hozzáférést a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) objektumhoz.  
5. Törölje az alapértelmezett sorozatot és kategóriát.  
6. Adjon hozzá új sorozatokat és kategóriákat.  
7. Adjon hozzá új diagramadatokat a sorozathoz.  
8. Mentse a módosított prezentációt PPTX fájlként.  

Ez a PHP-kód bemutatja, hogyan hozhat létre egy doboz‑ és szárnydiagramot:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### ** tölcsér diagramok létrehozása**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Lépések:</em> Tölcsér diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Lépések:</em> PowerPoint-tölcsér diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Lépések:</em> PowerPoint-prezentáció tölcsér diagram létrehozása </strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását a sorszám alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal és a kívánt típussal ([ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ChartType).Funnel).  
4. Mentse a módosított prezentációt PPTX fájlként.  

A tölcsér diagram létrehozását bemutató PHP-kód:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Napfény‑diagramok (Sunburst) létrehozása**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Lépések:</em> Napfény‑diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Lépések:</em> PowerPoint-napfény diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Lépések:</em> PowerPoint-prezentáció napfény diagram létrehozása </strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását a sorszám alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal és a kívánt típussal (jelen esetben a [ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ChartType).sunburst).  
4. Mentse a módosított prezentációt PPTX fájlként.  

Ez a PHP-kód bemutatja, hogyan hozhat létre egy napfény diagramot:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # ág 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # ág 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Hisztogram diagramok létrehozása**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Lépések:</em> Hisztogram diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Lépések:</em> PowerPoint-hisztogram diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Lépések:</em> PowerPoint-prezentáció hisztogram diagram létrehozása </strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását a sorszám alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal és a kívánt típussal ([ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ChartType).Histogram).  
4. Hozzon hozzáférést a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) objektumhoz.  
5. Törölje az alapértelmezett sorozatot és kategóriát.  
6. Adjon hozzá új sorozatokat és kategóriákat.  
7. Mentse a módosított prezentációt PPTX fájlként.  

Ez a PHP-kód bemutatja, hogyan hozhat létre egy hisztogram diagramot:

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **Radar diagramok létrehozása**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Lépések:</em> Radar diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Lépések:</em> PowerPoint-radar diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Lépések:</em> PowerPoint-prezentáció radar diagram létrehozása </strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását a sorszám alapján.  
3. Adjon hozzá egy diagramot némi adatokkal, és adja meg a kívánt diagramtípust (`ChartType::Radar`).  
4. Mentse a módosított prezentációt PPTX fájlként.  

Ez a PHP-kód bemutatja, hogyan hozhat létre egy radar diagramot:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Többkategóriás diagramok létrehozása**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Lépések:</em> Többkategóriás diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Lépések:</em> PowerPoint-többkategóriás diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Lépések:</em> PowerPoint-prezentáció többkategóriás diagram létrehozása </strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását a sorszám alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal és a kívánt típussal ([ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ChartType).ClusteredColumn).  
4. Hozzon hozzáférést a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) objektumhoz.  
5. Törölje az alapértelmezett sorozatot és kategóriát.  
6. Adjon hozzá új sorozatokat és kategóriákat.  
7. Adjon hozzá új diagramadatokat a sorozathoz.  
8. Mentse a módosított prezentációt PPTX fájlként.  

Ez a PHP-kód bemutatja, hogyan hozhat létre egy többkategóriás diagramot:

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # Sorozatok hozzáadása
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # A prezentáció mentése diagrammal
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Térképi diagramok létrehozása**

A térképi diagram egy olyan megjelenítés, amely egy területen belüli adatokat ábrázolja. A térképi diagramok leginkább adat- vagy értékösszehasonlításra alkalmasak földrajzi régiók között.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Lépések:</em> Térképi diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Lépések:</em> PowerPoint-térképi diagram létrehozása </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Lépések:</em> PowerPoint-prezentáció térképi diagram létrehozása </strong></a>

Ez a PHP-kód bemutatja, hogyan hozhat létre egy térképi diagramot:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Kombinált diagramok létrehozása**

A kombinált diagram (vagy combo diagram) egyetlen grafikonon több diagramtípust egyesít. Ez a diagram lehetővé teszi, hogy kiemeljük, összehasonlítsuk vagy vizsgáljuk a különböző adatcsoportok közti eltéréseket, segítve a köztük lévő kapcsolatok feltárását.

![The combination chart](combination_chart.png)

Az alábbi PHP-kód mutatja, hogyan hozható létre a fenti kombinált diagram PowerPoint‑prezentációban:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Állítsa be a diagram címét.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Állítsa be a diagram jelmagyarázatát.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Törölje az alapértelmezés szerint létrehozott sorozatokat és kategóriákat.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Új kategóriákat ad hozzá.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Az első sorozatot adja hozzá.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // Állítsa be a vízszintes tengelyt.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Állítsa be a függőleges tengelyt.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Állítsa be a függőleges fő rácsvonalak színét.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Állítsa be a másodlagos vízszintes tengelyt.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Állítsa be a másodlagos függőleges tengelyt.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **Diagramok frissítése**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Lépések:</em> PowerPoint-diagram frissítése </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Lépések:</em> Prezentáció-diagram frissítése </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Lépések:</em> PowerPoint-prezentáció-diagram frissítése </strong></a>

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) példányt, amely a frissíteni kívánt diagramot tartalmazó prezentációt képviseli.  
2. Szerezze meg egy dia hivatkozását a Index használatával.  
3. Járja be az összes alakzatot, hogy megtalálja a kívánt diagramot.  
4. Hozzon hozzáférést a diagram adatlapjához.  
5. Módosítsa a diagram sorozatadatait a sorozatértékek megváltoztatásával.  
6. Adjon hozzá egy új sorozatot, és töltse fel adatokkal.  
7. Mentse a módosított prezentációt PPTX fájlként.  

Ez a PHP-kód bemutatja, hogyan frissíthet egy diagramot:

```php
  $pres = new Presentation();
  try {
    # Első dia elérése
    $sld = $pres->getSlides()->get_Item(0);
    # Diagram lekérése alapértelmezett adatokkal
    $chart = $sld->getShapes()->get_Item(0);
    # A diagram adatlap indexének beállítása
    $defaultWorksheetIndex = 0;
    # A diagram adatlapjának lekérése
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # A diagram kategória nevének módosítása
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Az első diagram sorozatának kivétele
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Sorozat adatainak frissítése
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Sorozat nevének módosítása

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # A második diagram sorozatának kivétele
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Sorozat adatainak frissítése
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Sorozat nevének módosítása

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Új sorozat hozzáadása
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # A harmadik diagram sorozatának kivétele
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Sorozat adatainak feltöltése
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Prezentáció mentése diagrammal
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Adattartomány beállítása egy diagramhoz**

Az adattartomány beállításához egy diagramhoz tegye a következőket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) példányt, amely a diagramot tartalmazó prezentációt képviseli.  
2. Szerezze meg egy dia hivatkozását a sorszám alapján.  
3. Járja be az összes alakzatot, hogy megtalálja a kívánt diagramot.  
4. Hozzon hozzáférést a diagram adatainak és állítsa be a tartományt.  
5. Mentse a módosított prezentációt PPTX fájlként.  

Ez a PHP-kód bemutatja, hogyan állíthatja be egy diagram adattartományát:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alapértelmezett jelölők használata diagramokon**
Alapértelmezett jelölő használatakor a diagram minden sorozata automatikusan különböző alapértelmezett jelölőszimbólumot kap.

Ez a PHP-kód bemutatja, hogyan állíthatja be automatikusan a diagram sorozatának jelölőjét:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # A második diagram sorozatának kivétele
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Most a sorozat adatait töltjük fel
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Milyen diagramtípusokat támogat az Aspose.Slides?**

Az Aspose.Slides számos [diagramtípust](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/) támogat, beleértve az oszlop-, vonal-, kör-, terület-, szórt-, hisztogram-, radar- és még sok más típust. Ez a rugalmasság lehetővé teszi, hogy a legmegfelelőbb diagramtípust válassza adatvizualizációs igényeihez.

**Hogyan adhatok hozzá új diagramot egy diához?**

Diagram hozzáadásához először hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt, kérje le a kívánt diát a sorszám alapján, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagramtípust és a kezdeti adatokat. Ez a folyamat közvetlenül a prezentációba illeszti be a diagramot.

**Hogyan frissíthetem a diagramon megjelenített adatokat?**

A diagram adatait a diagram adatkönyvtárához ([ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/)) való hozzáféréssel, az alapértelmezett sorozatok és kategóriák törlésével, majd a saját adatainak hozzáadásával frissítheti. Így a diagram naprakész adatokat tükröz.

**Lehetséges-e a diagram megjelenésének testreszabása?**

Igen, az Aspose.Slides kiterjedt testreszabási lehetőségeket kínál. Módosíthatja a színeket, betűtípusokat, címkéket, jelmagyarázatokat és egyéb [formázási elemeket](/slides/hu/php-java/chart-entities/), hogy a diagram megjelenését az Ön tervezési követelményeihez igazítsa.