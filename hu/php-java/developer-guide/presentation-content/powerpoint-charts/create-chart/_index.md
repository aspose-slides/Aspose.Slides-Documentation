---
title: PowerPoint prezentáció diagramok létrehozása vagy frissítése PHP-ban
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
- tortadiagram
- vonaldiagram
- fa térképes diagram
- részvénydiagram
- doboz‑ és bajuszdiagram
- tölcsérdiagram
- sugárdiagram
- hisztogram diagram
- radar diagram
- többkategóriás diagram
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Diagramok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for PHP via Java használatával. Diagramok hozzáadása, formázása és szerkesztése gyakorlati kódrészletekkel."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt a diagramok létrehozásához és testreszabásához az Aspose.Slides segítségével. Megtanulja, hogyan adjon programozottan diagramot egy diára, hogyan töltse fel adatokka­l, és hogyan alkalmazzon különféle formázási beállításokat a konkrét tervezési követelményekhez. A cikk során részletes kódrészletek illusztrálják az egyes lépéseket, az előadás és a diagramobjektum inicializálásától a sorozatok, tengelyek és jelmagyarázatok konfigurálásáig. Az útmutató követésével alapos megértést szerez a dinamikus diagramgenerálás integrálásáról alkalmazásaiba, egyszerűsítve az adat‑vezérelt bemutatók létrehozásának folyamatát.

## **Diagram létrehozása**

A diagramok segítenek az embereknek gyorsan megjeleníteni az adatokat, és olyan betekintést nyerni, ami egy táblázatból vagy táblázatkezdőből nem feltétlenül látható.

**Miért hozunk létre diagramokat?**

Diagramok használatával:

* nagy mennyiségű adatot összefoglalhat vagy sűríthet egyetlen dián egy prezentációban
* mintákat és trendeket tárhat fel az adatokban
* meghatározhatja az adatok irányát és lendületét időben vagy egy adott mértékegységhez viszonyítva
* felfedezhet kiugró értékeket, eltéréseket, hibákat, nonszensz adatokat stb.
* bonyolult adatokat kommunikálhat vagy prezentálhat

PowerPointban a *Insert* (Beszúrás) funkcióval hozhat létre diagramokat, amely számos diagramtípus sablonját kínálja. Az Aspose.Slides segítségével létrehozhat mind szabványos diagramokat (népszerű diagramtípusok alapján), mind egyedi diagramokat.

{{% alert color="info" title="Megjegyzés" %}}
Diagramok létrehozásához használja a [ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/) osztályt. Ennek az osztálynak a mezői a különböző diagramtípusoknak felelnek meg.
{{% /alert %}}

### **Csoportosított oszlopdiagramok létrehozása**

Ez a rész bemutatja, hogyan hozhat létre csoportosított oszlopdiagramokat az Aspose.Slides használatával. Megtanulja, hogyan inicializáljon egy prezentációt, adjon hozzá diagramot, és testre szabja annak elemeit, például a címet, az adatokat, a sorozatokat, a kategóriákat és a stílusokat. Kövesse az alábbi lépéseket a szabványos csoportosított oszlopdiagram generálásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy diagramot némi adattal, és adja meg a `ChartType::ClusteredColumn` típust.
1. Adjon címet a diagramnak.
1. Érje el a diagram adatlapját.
1. Törölje az összes alapértelmezett sorozatot és kategóriát.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Alkalmazzon kitöltőszínt a diagram sorozatra.
1. Adjon címkéket a diagram sorozathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozhat létre egy csoportosított oszlopdiagramot:

```php
  # Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
  $pres = new Presentation();
  try {
    # Eléri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Hozzáad egy diagramot az alapértelmezett adataival
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Beállítja a diagram címét
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Beállítja, hogy az első sorozat értékeket jelenítsen meg
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Beállítja a diagram adatlap indexét
    $defaultWorksheetIndex = 0;
    # Lekéri a diagram adatlapját
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Törli az alapértelmezett generált sorozatokat és kategóriákat
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
    # Most feltölti a sorozat adatait
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Beállítja a sorozat kitöltőszínét
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # A második diagram sorozatot veszi
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Feltölti a sorozat adatait
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Beállítja a sorozat kitöltőszínét
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Egyéni címkéket hoz létre minden kategóriához az új sorozatban
    # Beállítja, hogy az első címke a kategória nevét mutassa
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Megjeleníti az értéket a harmadik címkén
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Mentse a prezentációt a diagrammal
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Szórási diagramok létrehozása**

A szórási diagramok (más néven szóráspont-diagramok vagy x‑y grafikonok) gyakran használatosak minták keresésére vagy két változó közötti korrelációk bemutatására.

Használjon szórási diagramot, ha:

* párosított numerikus adatai vannak
* két változó jól párosítható egymással
* meg szeretné határozni, hogy a két változó összefügg-e
* van egy független változó, amely több értéket vesz fel egy függő változóhoz

1. Kövesse a [Create Clustered Column Charts](#create-clustered-column-charts) lépéseit.
2. A harmadik lépésnél adjon hozzá egy diagramot némi adattal, és válassza a diagram típusát az alábbiak közül:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Szórási diagramot ábrázol._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Szórási diagram, amely görbékkel van összekötve, adatjelölőkkel._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Szórási diagram, amely görbékkel van összekötve, adatjelölők nélkül._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Szórási diagram, amely egyenes vonalakkal van összekötve, adatjelölőkkel._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Szórási diagram, amely egyenes vonalakkal van összekötve, adatjelölők nélkül._

Ez a PHP kód mutatja, hogyan hozhat létre szórási diagramot különböző jelölőkkel minden sorozathoz:

```php
  # Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
  $pres = new Presentation();
  try {
    # Eléri az első diát
    $slide = $pres->getSlides()->get_Item(0);
    # Létrehozza az alapértelmezett diagramot
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Lekéri az alapértelmezett diagram adatlap indexét
    $defaultWorksheetIndex = 0;
    # Lekéri a diagram adatlapot
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Törli a bemutató sorozatot
    $chart->getChartData()->getSeries()->clear();
    # Új sorozatokat ad hozzá
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Az első diagram sorozatot veszi
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Új pontot (1:3) ad a sorozathoz
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Új pontot (2:10) ad hozzá
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Módosítja a sorozat típusát
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Módosítja a diagram sorozat jelölőjét
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # A második diagram sorozatot veszi
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Új pontot (5:2) ad hozzá ott
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Új pontot (3:1) ad hozzá
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Új pontot (2:2) ad hozzá
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Új pontot (5:1) ad hozzá
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Módosítja a diagram sorozat jelölőjét
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tortadiagramok létrehozása**

A tortadiagramok leginkább a teljes adathalmaz részarányainak szemléltetésére alkalmasak, különösen, ha a adat kategóriákat numerikus értékekkel jelölik. Ha a adat sok részre vagy címkére oszlik, fontolja meg oszlopdiagram használatát.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType::Pie](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#Pie) típust.
4. Érje el a diagram adatkönyvtárát a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) segítségével.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a sorozathoz.
8. Adjon hozzá új pontokat a diagramhoz, és alkalmazzon egyedi színeket a torta szeletekre.
9. Állítson be címkéket a sorozathoz.
10. Engedélyezze a vezetővonalakat a sorozatcímkékhez.
11. Állítsa be a forgásszöget a torta szeletekhez.
12. Mentse a módosított prezentációt PPTX fájlként.

Ez a PHP kód mutatja, hogyan hozhat létre egy tortadiagramot:

```php
  # Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
  $pres = new Presentation();
  try {
    # Eléri az első diát
    $slides = $pres->getSlides()->get_Item(0);
    # Hozzáad egy diagramot alapértelmezett adatokkal
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Beállítja a diagram címét
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Beállítja, hogy az első sorozat értékeket mutasson
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Beállítja a diagram adatlap indexét
    $defaultWorksheetIndex = 0;
    # Lekéri a diagram adatlapot
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
    # Feltölti a sorozat adatait
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
    # Egyéni címkéket hoz létre minden kategóriához az új sorozatban
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
    # Beállítja a forgásszöget a tortadiagram szektoraihoz
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

A vonaldiagramok (más néven vonalgrafikonok) leginkább olyan helyzetekben használatosak, ahol az időbeli értékváltozást szeretné bemutatni. Egy vonaldiagram segítségével egyszerre összehasonlíthat nagy mennyiségű adatot, nyomon követheti az időbeli változásokat és trendeket, kiemelheti az anomáliákat az adat sorozatokban, és még sok mást.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType::Line](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#Line) típust.
1. Érje el a diagram adatkönyvtárát a ([ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/)) segítségével.
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a PHP kód mutatja, hogyan hozhat létre egy vonaldiagramot:

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

Alapértelmezés szerint a vonaldiagram pontjai egyenes, folyamatos vonallal vannak összekötve. Ha szeretné, hogy a pontok vonala szaggatott legyen, a kívánt vonaltípust az alábbi módon adhatja meg:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $seriesCollection = $lineChart->getChartData()->getSeries();
    foreach ($seriesCollection as $series) {
      $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Fa térképes diagramok létrehozása**

A fa térképes diagramok leginkább értékesítési adatok esetén használatosak, amikor a kategóriák relatív méretét akarja bemutatni, és gyorsan fel akarja hívni a figyelmet a nagy hozzájáruló elemekre az egyes kategóriákon belül.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType::Treemap](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#Treemap) típust.
4. Érje el a diagram adatkönyvtárát a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) segítségével.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a sorozathoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a PHP kód mutatja, hogyan hozhat létre egy fa térképes diagramot:

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

### **Részvénydiagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#OpenHighLowClose) típust.
4. Érje el a diagram adatkönyvtárát a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) segítségével.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a sorozathoz.
8. Adja meg a magas‑alacsony vonalak formátumát.
9. Mentse a módosított prezentációt PPTX fájlként.

Ez a PHP kód mutatja, hogyan hozhat létre egy részvénydiagramot:

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
    $seriesCollection = $chart->getChartData()->getSeries();
    foreach ($seriesCollection as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Doboz‑ és bajuszdiagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#BoxAndWhisker) típust.
4. Érje el a diagram adatkönyvtárát a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) segítségével.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a sorozathoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a PHP kód mutatja, hogyan hozhat létre egy doboz‑ és bajuszdiagramot:

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

### **Tölcsérdiagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType::Funnel](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#Funnel) típust.
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a PHP kód mutatja, hogyan hozhat létre egy tölcsérdiagramot:

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

### **Sugárdiagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType::Sunburst](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#Sunburst) típust.
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a PHP kód mutatja, hogyan hozhat létre egy sugárdiagramot:

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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType::Histogram](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#Histogram) típust.
4. Érje el a diagram adatkönyvtárát a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) segítségével.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Mentse a módosított prezentációt PPTX fájlként.

Ez a PHP kód mutatja, hogyan hozhat létre egy hisztogram diagramot:

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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot némi adattal, és válassza ki a kívánt diagram típust (ebben az esetben a [ChartType::Radar](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#Radar) típust).
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a PHP kód mutatja, hogyan hozhat létre egy radar diagramot:

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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType::ClusteredColumn](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/#ClusteredColumn) típust.
4. Érje el a diagram adatkönyvtárát a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) segítségével.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a sorozathoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a PHP kód mutatja, hogyan hozhat létre egy többkategóriás diagramot:

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
    # Sorozat hozzáadása
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # Prezentáció mentése diagrammal
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Térképi diagramok létrehozása**

A térképi diagramok földrajzi adatokat jelenítenek meg, és segítenek az értékek régiók szerinti összehasonlításában.

Ez a PHP kód mutatja, hogyan hozhat létre egy térképi diagramot:

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

A kombinált diagram (vagy combo diagram) több diagramtípust egyesít egy grafikonban. Ez a diagram lehetővé teszi, hogy kiemelje, összehasonlítsa vagy vizsgálja a különböző adatkészletek közti eltéréseket, segítve a kapcsolatok felismerését.

![The combination chart](combination_chart.png)

Az alábbi PHP kód mutatja, hogyan hozhatja létre a fenti kombinált diagramot egy PowerPoint prezentációban:

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

    // Törli az alapértelmezett generált sorozatokat és kategóriákat.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Új kategóriák hozzáadása.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Az első sorozat hozzáadása.
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

    // A függőleges fő rácsvonalak színének beállítása.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Másodlagos vízszintes tengely beállítása.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Másodlagos függőleges tengely beállítása.
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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból, amely a frissítendő diagramot tartalmazó prezentációt képviseli.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Járja be az összes alakzatot, hogy megtalálja a kívánt diagramot.
4. Érje el a diagram adatlapját.
5. Módosítsa a diagram adatsorait a sorozatértékek megváltoztatásával.
6. Adjon hozzá egy új sorozatot, és töltse fel az adatait.
7. Mentse a módosított prezentációt PPTX fájlként.

Ez a PHP kód mutatja, hogyan frissíthet egy diagramot:

```php
  $pres = new Presentation();
  try {
    # Az első dia elérése
    $sld = $pres->getSlides()->get_Item(0);
    # Lekéri a diagramot alapértelmezett adatokkal
    $chart = $sld->getShapes()->get_Item(0);
    # Beállítja a diagram adatlap indexét
    $defaultWorksheetIndex = 0;
    # Lekéri a diagram adatlapot
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Módosítja a diagram kategória nevét
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Az első diagram sorozatot veszi
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Most frissíti a sorozat adatait
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1"); // Sorozat nevének módosítása

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # A második diagram sorozatot veszi
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Most frissíti a sorozat adatait
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2"); // Sorozat nevének módosítása

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Most új sorozatot ad hozzá
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # A harmadik diagram sorozatot veszi
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Most feltölti a sorozat adatait
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Mentse a prezentációt diagrammal
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Adattartomány beállítása diagramhoz**

A diagram adattartományának beállításához kövesse az alábbiakat:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból, amely a diagramot tartalmazó prezentációt képviseli.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Járja be az összes alakzatot, hogy megtalálja a kívánt diagramot.
4. Érje el a diagram adatokat, és állítsa be a tartományt.
5. Mentse a módosított prezentációt PPTX fájlként.

Ez a PHP kód mutatja, hogyan állíthatja be a diagram adattartományát:

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

## **Alapértelmezett jelölők használata diagramokban**

Alapértelmezett jelölők használata esetén minden diagram sorozat automatikusan különböző jelölőszimbólumot kap.

Ez a PHP kód mutatja, hogyan állíthatja be automatikusan a diagram sorozat jelölőjét:

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
    # A második diagram sorozatot veszi
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Most feltölti a sorozat adatait
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

**Milyen diagramtípusok támogatottak az Aspose.Slides-ban?**

Az Aspose.Slides széles körű [diagramtípusokat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/) támogat, többek között oszlop, vonal, torta, terület, szórás, hisztogram, radar és még sok mást. Ez a rugalmasság lehetővé teszi, hogy az adatvizualizációs igényeinek legmegfelelőbb diagramtípust válassza.

**Hogyan adhatok új diagramot egy diához?**

Diagram hozzáadásához először hozza létre a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztály egy példányát, szerezze meg a kívánt diát az indexe alapján, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagram típusát és a kezdeti adatokat. Ezzel a folyamattal a diagram közvetlenül a prezentációba kerül.

**Hogyan frissíthetem a diagramon megjelenített adatokat?**

A diagram adatait a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) elérésével frissítheti: törölje az alapértelmezett sorozatokat és kategóriákat, majd adja hozzá saját egyedi adatait. Így a diagram naprakész adatokat fog megjeleníteni.

**Lehetőség van a diagram megjelenésének testreszabására?**

Igen, az Aspose.Slides kiterjedt testreszabási lehetőségeket biztosít. Módosíthatja a színeket, betűtípusokat, címkéket, jelmagyarázatokat és más [formázási elemek](/slides/hu/php-java/chart-entities/) megjelenését, hogy a diagramot a konkrét tervezési követelményeknek megfelelően alakítsa.