---
title: PowerPoint-diagramok létrehozása vagy módosítása JavaScriptben
linktitle: Diagramok létrehozása vagy frissítése
type: docs
weight: 10
url: /hu/nodejs-java/create-chart/
keywords:
- diagram hozzáadása
- diagram létrehozása
- diagram szerkesztése
- diagram módosítása
- diagram frissítése
- szórt diagram
- kördiagram
- vonaldiagram
- fa térképes diagram
- részvénydiagram
- doboz és ívháromszög diagram
- tölcsérdiagram
- napraforgó diagram
- hisztogram diagram
- radar diagram
- többkategóriás diagram
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Diagramok létrehozása és testreszabása PowerPoint-prezentációkban az Aspose.Slides for Node.js segítségével. Diagramok hozzáadása, formázása és szerkesztése gyakorlati JavaScript kódpéldákkal."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt a diagramok létrehozásához és testreszabásához az Aspose.Slides használatával. Megtanulja, hogyan adhat programozott módon egy diagramot egy diára, hogyan töltheti fel adatokal, és különféle formázási lehetőségeket alkalmazhat a konkrét tervezési igényeknek megfelelően. A cikk során részletes kódpéldák illusztrálják az egyes lépéseket, a prezentáció és a diagramobjektum inicializálásától a sorok, tengelyek és jelmagyarázatok konfigurálásáig. Az útmutató követésével mélyrehatóan megértheti a dinamikus diagramgenerálás integrálását alkalmazásaiba, ezzel egyszerűsítve az adat‑vezérelt prezentációk létrehozását.

## **Diagram létrehozása**

A diagramok lehetővé teszik, hogy az emberek gyorsan vizualizálják az adatokat, és olyan betekintéseket nyerjenek, amelyek táblázatból vagy munkafüzetből nem látszanak azonnal.

**Miért érdemes diagramokat létrehozni?**

Diagramok segítségével:

* nagy mennyiségű adatot összegyűjthet, tömöríthet vagy összefoglalhat egyetlen dián belül
* mintákat és trendeket tárhat fel az adatokban
* meghatározhatja az adatok irányát és lendületét időben vagy egy adott mérőegységhez viszonyítva
* felfedezhet kiugró, rendellenes, eltérő vagy hibás adatokat
* komplex adatokat kommunikálhat vagy prezentálhat

A PowerPointban a *Beszúrás* funkcióval hozhat létre diagramokat, amely számos sablont biztosít különböző diagramtípusok tervezéséhez. Az Aspose.Slides segítségével mind szabványos, mind egyedi diagramokat hozhat létre.

{{% alert color="info" title="Note" %}}

Diagramok létrehozásához használja a [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) osztályt. Ennek az osztálynak a mezői a különböző diagramtípusoknak felelnek meg.

{{% /alert %}}

### **Csoportosított oszlopdiagramok létrehozása**

Ez a szakasz bemutatja, hogyan hozhat létre csoportosított oszlopdiagramokat az Aspose.Slides használatával. Megtanulja, hogyan inicializáljon egy prezentációt, adjon hozzá egy diagramot, és testreszabja annak elemeit, például a címet, az adatokat, a sorokat, a kategóriákat és a stílust. Kövesse az alábbi lépéseket a szabványos csoportosított oszlopdiagram létrehozásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) osztályból.
1. Szerezzen hivatkozást egy diára a sorszámával.
1. Adjon hozzá egy diagramot némi adattal, és adja meg a `ChartType.ClusteredColumn` típust.
1. Adjon címet a diagramnak.
1. Hozzáférés a diagram adatlapjához.
1. Távolítsa el az összes alapértelmezett sort és kategóriát.
1. Adjon hozzá új sorokat és kategóriákat.
1. Adjon hozzá új diagramadatot a diagram soraihoz.
1. Alkalmazzon kitöltőszínt a diagram soraira.
1. Adjon címkéket a diagram soraira.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript‑kód bemutatja, hogyan hozható létre egy csoportosított oszlopdiagram:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Pptx fájlt képviselő prezentáció osztály példányosítása
var pres = new aspose.slides.Presentation();
try {
    // Az első dia elérése
    var sld = pres.getSlides().get_Item(0);
    // Diagram hozzáadása az alapértelmezett adataival
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // A diagram címének beállítása
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    // Az első sorozat értékek megjelenítésének beállítása
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // A diagram adatlap indexének beállítása
    var defaultWorksheetIndex = 0;
    // A diagram adatlapjának lekérése
    var fact = chart.getChartData().getChartDataWorkbook();
    // Az alapértelmezett generált sorozatok és kategóriák törlése
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Új sorozatok hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Új kategóriák hozzáadása
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Az első diagram sorozat kivétele
    var series = chart.getChartData().getSeries().get_Item(0);
    // Most feltölti a sorozat adatokat
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Kitöltőszín beállítása a sorozathoz
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // A második diagram sorozat kivétele
    series = chart.getChartData().getSeries().get_Item(1);
    // Sorozat adatainak feltöltése
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Kitöltőszín beállítása a sorozathoz
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Egyéni címkék létrehozása az egyes kategóriákhoz az új sorozathoz
    // Az első címke beállítása a kategórianév megjelenítésére
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Az érték megjelenítése a harmadik címkén
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Prezentáció mentése diagrammal
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Szóródási diagramok létrehozása**

A szóródási diagramok (más néven szórásdiagramok vagy x‑y grafikonok) gyakran használatosak minták keresésére vagy két változó közötti korreláció bemutatására.

Használjon szóródási diagramot, ha:

* párosított numerikus adatokkal dolgozik
* két változó jól párosítható egymással
* meg szeretné határozni, hogy a két változó összefügg‑e
* egy független változó több értékkel rendelkezik egy függő változóhoz képest

1. Kövesse a [Csoportosított oszlopdiagramok létrehozása](#create-clustered-column-charts) lépéseit.
2. A harmadik lépésben adjon hozzá egy diagramot némi adattal, és válassza a diagramtípust az alábbiak közül:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Szóródási diagramot jelöl._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Szóródási diagram, amely görbékkel van összekötve, adatjelölőkkel._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Szóródási diagram, amely görbékkel van összekötve, adatjelölők nélkül._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Szóródási diagram, amely egyenes vonalakkal van összekötve, adatjelölőkkel._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Szóródási diagram, amely egyenes vonalakkal van összekötve, adatjelölők nélkül._

Ez a JavaScript‑kód megmutatja, hogyan hozható létre egy szóródási diagram különböző jelölőkkel minden sorhoz:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// PPTX fájlt képviselő prezentáció osztály példányosítása
var pres = new aspose.slides.Presentation();
try {
    // Az első dia elérése
    var slide = pres.getSlides().get_Item(0);
    // Alapértelmezett diagram létrehozása
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Az alapértelmezett diagram adatlap indexének lekérése
    var defaultWorksheetIndex = 0;
    // A diagram adatlapjának lekérése
    var fact = chart.getChartData().getChartDataWorkbook();
    // A demo sorozat törlése
    chart.getChartData().getSeries().clear();
    // Új sorozatok hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Az első diagram sorozat kivétele
    var series = chart.getChartData().getSeries().get_Item(0);
    // Új pont (1:3) hozzáadása a sorozathoz
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Új pont (2:10) hozzáadása
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // A sorozat típusának módosítása
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // A diagram sorozat jelölőjének módosítása
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // A második diagram sorozat kivétele
    series = chart.getChartData().getSeries().get_Item(1);
    // Új pont (5:2) hozzáadása ott
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Új pont (3:1) hozzáadása
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Új pont (2:2) hozzáadása
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Új pont (5:1) hozzáadása
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // A diagram sorozat jelölőjének módosítása
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Kördiagramok létrehozása**

A kördiagramok leginkább arra alkalmasak, hogy megmutassák az adat rész‑egész arányát, különösen, ha a adatok kategóriákat és numerikus értékeket tartalmaznak. Ha azonban sok rész vagy címke van, érdemes oszlopdiagramot használni.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára a sorszámával.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Pie](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#Pie) típust.
4. Hozzáférés a diagram adatkönyvtárához [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/).
5. Távolítsa el az alapértelmezett sorokat és kategóriákat.
6. Adjon hozzá új sorokat és kategóriákat.
7. Adjon hozzá új diagramadatot a diagram soraihoz.
8. Adjon hozzá új pontokat a diagramhoz, és alkalmazzon egyedi színeket a kördiagram szektoraira.
9. Állítson be címkéket a sorokhoz.
10. Engedélyezze a vezetővonalakat a sorcímkékhez.
11. Állítsa be a forgásszöget a kördiagram szektoraiban.
12. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript‑kód bemutatja, hogyan hozható létre egy kördiagram:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// PPTX fájlt képviselő prezentáció osztály példányosítása
var pres = new aspose.slides.Presentation();
try {
    // Az első dia elérése
    var slides = pres.getSlides().get_Item(0);
    // Diagram hozzáadása alapértelmezett adatokkal
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // A diagram címének beállítása
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Az első sorozat értékek megjelenítésének beállítása
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // A diagram adatlap indexének beállítása
    var defaultWorksheetIndex = 0;
    // A diagram adatlapjának lekérése
    var fact = chart.getChartData().getChartDataWorkbook();
    // Az alapértelmezett generált sorozatok és kategóriák törlése
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Új kategóriák hozzáadása
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Új sorozatok hozzáadása
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // A sorozat adatainak feltöltése
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Nem működik az új verzióban
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // A szektor keretének beállítása
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    point.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // A szektor keretének beállítása
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    point1.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // A szektor keretének beállítása
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    point2.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));
    // Egyéni címkék létrehozása az új sorozat minden kategóriájához
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Vezetővonalak megjelenítése a diagramhoz
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // A kördiagram szektorok forgásszögének beállítása
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Prezentáció mentése diagrammal
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven vonalgrafikonok) leginkább olyan esetekben hasznosak, amikor az értékek időbeli változását szeretné bemutatni. Vonaldiagram segítségével egy nagy mennyiségű adatot egyszerre hasonlíthat össze, nyomon követheti az időbeli változásokat és trendeket, kiemelheti az anomáliákat az adatcsoportokban, stb.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára a sorszámával.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Line](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#Line) típust.
1. Hozzáférés a diagram adatkönyvtárához ([ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/)).
1. Távolítsa el az alapértelmezett sorokat és kategóriákat.
1. Adjon hozzá új sorokat és kategóriákat.
1. Adjon hozzá új diagramadatot a diagram soraihoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript‑kód bemutatja, hogyan hozható létre egy vonaldiagram:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Alapértelmezés szerint a vonaldiagram pontjai egyenes, folytonos vonallal vannak összekötve. Ha pontokat szaggatott vonallal szeretne összekötni, a kívánt vonaltípust a következőképpen adhatja meg:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Fák térképe (Tree Map) diagramok létrehozása**

A fák térképe diagramok leginkább értékesítési adatoknál hasznosak, amikor a kategóriák relatív méretét szeretné megjeleníteni, és gyorsan rámutatni a nagy hozzájáruló tételekre az egyes kategóriákon belül.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára a sorszámával.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Treemap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#Treemap) típust.
4. Hozzáférés a diagram adatkönyvtárához [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/).
5. Távolítsa el az alapértelmezett sorokat és kategóriákat.
6. Adjon hozzá új sorokat és kategóriákat.
7. Adjon hozzá új diagramadatot a diagram soraihoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript‑kód bemutatja, hogyan hozható létre egy fák térképe diagram:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // ág 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // ág 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Részvény (Stock) diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára a sorszámával.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#OpenHighLowClose) típust.
4. Hozzáférés a diagram adatkönyvtárához [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/).
5. Távolítsa el az alapértelmezett sorokat és kategóriákat.
6. Adjon hozzá új sorokat és kategóriákat.
7. Adjon hozzá új diagramadatot a diagram soraihoz.
8. Adja meg a high‑low vonalak formátumát.
9. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript‑kód bemutatja, hogyan hozható létre egy részvénydiagram:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Doboz‑ és ívháromszög diagramok (Box and Whisker) létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára a sorszámával.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#BoxAndWhisker) típust.
4. Hozzáférés a diagram adatkönyvtárához [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/).
5. Távolítsa el az alapértelmezett sorokat és kategóriákat.
6. Adjon hozzá új sorokat és kategóriákat.
7. Adjon hozzá új diagramadatot a diagram soraihoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript‑kód bemutatja, hogyan hozható létre egy doboz‑ és ívháromszög diagram:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Tölcsér diagramok (Funnel) létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára a sorszámával.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Funnel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#Funnel) típust.
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript‑kód bemutatja, hogyan hozható létre egy tölcsérdiagram:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Napraforgó (Sunburst) diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára a sorszámával.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Sunburst](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#Sunburst) típust.
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript‑kód bemutatja, hogyan hozható létre egy napraforgódiagram:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // ág 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // ág 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Hisztogram diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára a sorszámával.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Histogram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#Histogram) típust.
4. Hozzáférés a diagram adatkönyvtárához [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/).
5. Távolítsa el az alapértelmezett sorokat és kategóriákat.
6. Adjon hozzá új sorokat és kategóriákat.
7. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript‑kód bemutatja, hogyan hozható létre egy hisztogram diagram:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **Radar diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára a sorszámával.
3. Adjon hozzá egy diagramot némi adattal, és adja meg a kívánt diagramtípust ([ChartType.Radar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#Radar) ebben az esetben).
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript‑kód bemutatja, hogyan hozható létre egy radar diagram:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Többkategóriás diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára a sorszámával.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.ClusteredColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ClusteredColumn) típust.
4. Hozzáférés a diagram adatkönyvtárához [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/).
5. Távolítsa el az alapértelmezett sorokat és kategóriákat.
6. Adjon hozzá új sorokat és kategóriákat.
7. Adjon hozzá új diagramadatot a diagram soraihoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript‑kód bemutatja, hogyan hozható létre egy többkategóriás diagram:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // Sorozat hozzáadása
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Prezentáció mentése diagrammal
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Térképi diagramok létrehozása**

A térképi diagramok földrajzi adatokat jelenítenek meg, és segítenek az értékek összehasonlításában régiók között.

Ez a JavaScript‑kód bemutatja, hogyan hozható létre egy térképi diagram:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Kombinált diagramok létrehozása**

A kombinált diagram (vagy combo diagram) két vagy több diagramtípust egyesít egy grafikonban. Ez a diagram lehetővé teszi, hogy kiemeljen, összehasonlítson vagy megvizsgáljon különböző adatcsoportok közti eltéréseket, ezáltal segítve a köztük lévő összefüggések felismerését.

![The combination chart](combination_chart.png)

Az alábbi JavaScript‑kód bemutatja, hogyan hozható létre a fenti kombinált diagram egy PowerPoint‑prezentációban:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Állítsa be a diagram címét.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Állítsa be a diagram jelmagyarázatát.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Törölje az alapértelmezett generált sorozatokat és kategóriákat.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Új kategóriák hozzáadása.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Az első sorozat hozzáadása.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // A vízszintes tengely beállítása.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // A függőleges tengely beállítása.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // A függőleges fő rácsvonalak színének beállítása.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // A másodlagos vízszintes tengely beállítása.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // A másodlagos függőleges tengely beállítása.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **Diagramok frissítése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból, amely a frissítendő diagramot tartalmazó prezentációt képviseli.
2. Szerezzen hivatkozást egy diára a sorszámával.
3. Járjon végig az összes alakzaton, hogy megtalálja a kívánt diagramot.
4. Hozzáférés a diagram adatlapjához.
5. Módosítsa a diagram adat sorait a sorértékek megváltoztatásával.
6. Adjon hozzá egy új sort, és töltse fel adataival.
7. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript‑kód bemutatja, hogyan frissíthető egy diagram:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Az első slideMarker elérése
    var sld = pres.getSlides().get_Item(0);
    // Diagram lekérése alapértelmezett adatokkal
    var chart = sld.getShapes().get_Item(0);
    // A diagram adatlap indexének beállítása
    var defaultWorksheetIndex = 0;
    // A diagram adatlapjának lekérése
    var fact = chart.getChartData().getChartDataWorkbook();
    // A diagram kategória nevének módosítása
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Az első diagram sorozat kivétele
    var series = chart.getChartData().getSeries().get_Item(0);
    // Sorozat adatainak frissítése
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Sorozat nevének módosítása
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // A második diagram sorozat kivétele
    series = chart.getChartData().getSeries().get_Item(1);
    // Sorozat adatainak frissítése
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Sorozat nevének módosítása
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Új sorozat hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // A harmadik diagram sorozat kivétele
    series = chart.getChartData().getSeries().get_Item(2);
    // Sorozat adatainak feltöltése
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Prezentáció mentése diagrammal
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adattartomány beállítása diagramhoz**

A már meglévő diagram által használt tartomány megtekintéséhez lásd a [Retrieve a Chart's Data Range](/slides/hu/nodejs-java/chart-workbook/#retrieve-a-charts-data-range) szakaszt.

Az adattartomány beállításához a diagramhoz kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból, amely a diagramot tartalmazó prezentációt képviseli.
2. Szerezzen hivatkozást egy diára a sorszámával.
3. Járjon végig az összes alakzaton, hogy megtalálja a kívánt diagramot.
4. Hozzáférés a diagram adataihoz, és állítsa be a tartományt.
5. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript‑kód bemutatja, hogyan állítható be egy diagram adattartománya:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alapértelmezett jelölők használata diagramokban**

Alapértelmezett jelölők használata esetén minden diagram sor automatikusan más‑más jelölőszimbólumot kap.

Ez a JavaScript‑kód bemutatja, hogyan állítható be egy diagram sorának jelölője automatikusan:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // A második diagram sorozat kivétele
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Sorozat adatainak feltöltése
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Milyen diagramtípusokat támogat az Aspose.Slides?**

Az Aspose.Slides széles körű [diagramtípusokat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) támogat, beleértve az oszlop-, vonal-, kör-, terület-, szórás-, hisztogram-, radar- és még sok más típust. Ez a rugalmasság lehetővé teszi, hogy a legmegfelelőbb diagramtípust válassza adatvizualizációs igényeihez.

**Hogyan adhatok hozzá egy új diagramot a diához?**

Diagram hozzáadásához először hozza létre a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztály egy példányát, szerezze meg a kívánt diát a sorszámával, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagram típusát és a kezdeti adatokat. Ez a folyamat közvetlenül a prezentációba integrálja a diagramot.

**Hogyan frissíthetem a diagramon megjelenő adatokat?**

A diagram adatait úgy frissítheti, hogy hozzáfér a diagram adatkönyvtárához ([ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/)), eltávolítja az alapértelmezett sorokat és kategóriákat, majd hozzáadja a saját egyedi adatait. Így programozott módon frissítheti a diagramot a legújabb adatokkal.

**Lehetőség van a diagram megjelenésének testreszabására?**

Igen, az Aspose.Slides kiterjedt testreszabási lehetőségeket kínál. Módosíthatja a színeket, betűtípusokat, címkéket, jelmagyarázatokat és egyéb [formázási elemeket](/slides/hu/nodejs-java/chart-entities/), hogy a diagram megjelenése megfeleljen az egyedi tervezési követelményeknek.