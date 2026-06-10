---
title: PowerPoint prezentáció diagramok létrehozása vagy frissítése JavaScriptben
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
- fa térkép diagram
- részvény diagram
- doboz és szárnyas diagram
- tölcsér diagram
- napkitörés diagram
- hisztogram diagram
- radar diagram
- többkategóriás diagram
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Diagramok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for Node.js segítségével. Diagramok hozzáadása, formázása és szerkesztése gyakorlati JavaScript kódpéldákkal."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt a diagramok létrehozásához és testreszabásához az Aspose.Slides segítségével. Megtanulhatja, hogyan adjon programozottan diagramot egy diára, töltse fel adatokal, és alkalmazzon különféle formázási beállításokat a tervezési követelményeknek megfelelően. A cikk során részletes kódpéldák szemléltetik az egyes lépéseket, a bemutató és diagramobjektum inicializálásától a sorozatok, tengelyek és jelmagyarázatok konfigurálásáig. Az útmutató követésével alaposan megismerheti a dinamikus diagramgenerálás integrálását az alkalmazásaiba, megkönnyítve az adat‑vezérelt prezentációk létrehozását.

## **Diagram létrehozása**
A diagramok segítik az embereket az adatok gyors megjelenítésében és az értelmezésben, ami egy táblázatból vagy munkalapból nem feltétlenül nyilvánvaló.

**Miért érdemes diagramokat létrehozni?**

A diagramok segítségével

* nagy mennyiségű adatot aggregálhat, sűríthet vagy összefoglalhat egyetlen dián egy prezentációban
* mintákat és trendeket tárhat fel az adatokban
* meghatározhatja az adatok időbeli vagy egy adott mérőegység szerinti irányát és lendületét
* felismerhet kiugró értékeket, rendellenességeket, eltéréseket, hibákat, értelmetlen adatokat stb.
* összetett adatokat kommunikálhat vagy mutathat be

PowerPointban a diagramok a Beszúrás funkcióval hozhatók létre, amely számos diagramtípushoz sablonokat biztosít. Az Aspose.Slides segítségével szabványos diagramokat (népszerű diagramtípusokon alapuló) és egyedi diagramokat is létrehozhat.

{{% alert color="primary" %}} 

A diagramok létrehozásához az Aspose.Slides a [ChartType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartType) osztályt biztosítja. Ennek az osztálynak a mezői a különböző diagramtípusoknak felelnek meg.

{{% /alert %}} 

### **Normál diagramok létrehozása**

*_Lépések: Diagram létrehozása_*
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Lépések:</em> PowerPoint diagram létrehozása JavaScriptben</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Lépések:</em> Prezentáció diagram létrehozása JavaScriptben</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Lépések:</em> PowerPoint prezentáció diagram létrehozása JavaScriptben</strong></a>

**Kód lépései:**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia referenciáját az indexe alapján.
3. Adjon hozzá egy diagramot némi adattal, és adja meg a kívánt diagramtípust. 
4. Adjon címet a diagramnak. 
5. Hozzáférés a diagram adatlapjához.
6. Törölje az összes alapértelmezett sorozatot és kategóriát.
7. Adjon hozzá új sorozatokat és kategóriákat.
8. Adjon hozzá új diagramadatokat a diagram sorozathoz.
9. Állítson be kitöltőszínt a diagram sorozathoz.
10. Állítson be címkéket a diagram sorozathoz. 
11. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript kód bemutatja, hogyan hozhat létre egy normál diagramot:

```javascript
// Létrehoz egy prezentáció osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Eléri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Diagramot ad hozzá alapértelmezett adatokkal
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Beállítja a diagram címét
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // Beállítja, hogy az első sorozat mutassa az értékeket
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Beállítja a diagram adatlap indexét
    var defaultWorksheetIndex = 0;
    // Lekéri a diagram adat munkalapját
    var fact = chart.getChartData().getChartDataWorkbook();
    // Törli az alapértelmezett generált sorozatokat és kategóriákat
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Új sorozatokat ad hozzá
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Új kategóriákat ad hozzá
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Az első diagram sorozatot veszi
    var series = chart.getChartData().getSeries().get_Item(0);
    // Most feltölti a sorozat adatait
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Beállítja a sorozat kitöltőszínét
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // A második diagram sorozatot veszi
    series = chart.getChartData().getSeries().get_Item(1);
    // Feltölti a sorozat adatait
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Beállítja a sorozat kitöltőszínét
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Egyéni címkéket hoz létre minden kategóriához az új sorozathoz
    // Beállítja, hogy az első címke mutassa a kategória nevét
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Értéket mutat a harmadik címkében
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Mentse a prezentációt a diagrammal
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Szórt diagramok létrehozása**
A szórt diagramok (más néven szórt pontdiagramok vagy x‑y grafikonok) gyakran használatosak minták keresésére vagy két változó közötti korreláció bemutatására. 

Szórt diagramra akkor lehet szüksége, ha

* párosított numerikus adat rendelkezésre áll
* két változó jól párosítható egymással
* meg szeretné határozni, hogy a két változó összefügg‑e
* van egy független változó, amely több értékkel rendelkezik egy függő változó esetén

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Lépések:</em> Szórt diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Lépések:</em> PowerPoint szórt diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Lépések:</em> PowerPoint prezentáció szórt diagram létrehozása JavaScriptben</strong></a>

1. Kövesse a fentebb leírt lépéseket a [Normál diagramok létrehozása](#creating-normal-charts) részben.
2. A harmadik lépésnél adjon hozzá egy diagramot némi adattal, és a diagramtípust állítsa az alábbiak egyikére:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Szórt diagramot reprezentál._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Szórt diagramot reprezentál íves vonalakkal és adatelőjelekkel._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Szórt diagramot reprezentál íves vonalakkal, adatjelölők nélkül._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Szórt diagramot reprezentál egyenes vonalakkal és adatjelölőkkel._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Szórt diagramot reprezentál egyenes vonalakkal, adatjelölők nélkül._

Ez a JavaScript kód bemutatja, hogyan hozhat létre különböző jelölőkkel rendelkező szórt diagramot:

```javascript
// Létrehoz egy prezentáció osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Eléri az első diát
    var slide = pres.getSlides().get_Item(0);
    // Létrehozza az alapértelmezett diagramot
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Lekéri az alapértelmezett diagram adatlap indexét
    var defaultWorksheetIndex = 0;
    // Lekéri a diagram adat munkalapját
    var fact = chart.getChartData().getChartDataWorkbook();
    // Törli a demo sorozatot
    chart.getChartData().getSeries().clear();
    // Új sorozatot ad hozzá
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Az első diagram sorozatot veszi
    var series = chart.getChartData().getSeries().get_Item(0);
    // Új pontot (1:3) ad a sorozathoz
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Új pontot (2:10) ad
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Megváltoztatja a sorozat típusát
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Módosítja a diagram sorozat jelölőjét
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // A második diagram sorozatot veszi
    series = chart.getChartData().getSeries().get_Item(1);
    // Új pontot (5:2) ad hozzá ott
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Új pontot (3:1) ad
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Új pontot (2:2) ad
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Új pontot (5:1) ad
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Módosítja a diagram sorozat jelölőjét
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

A kördiagramok leginkább a rész‑egész arányok ábrázolására alkalmasak, különösen, ha az adatok kategóriákat és numerikus értékeket tartalmaznak. Ha az adatok sok részt vagy címkét tartalmaznak, érdemes inkább oszlopdiagramot használni.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Lépések:</em> Kördiagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Lépések:</em> PowerPoint kördiagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Lépések:</em> PowerPoint prezentáció kördiagram létrehozása JavaScriptben</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia referenciáját az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típussal (jelen esetben a [ChartType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartType).Pie).
4. Hozzáférés a diagram adat [ChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataWorkbook) objektumához.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozathoz.
8. Adjon hozzá új pontokat a diagramhoz, és állítson be egyedi színeket a kördiagram szeleteihez.
9. Állítson be címkéket a sorozatokhoz.
10. Állítson be vezetővonalakat a sorozatcímkékhez.
11. Állítsa be a forgásszöget a kördiagram diákhoz.
12. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript kód bemutatja, hogyan hozhat létre egy kördiagramot:

```javascript
// Létrehoz egy prezentáció osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Eléri az első diát
    var slides = pres.getSlides().get_Item(0);
    // Alapértelmezett adatokat tartalmazó diagramot ad hozzá
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Beállítja a diagram címét
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Beállítja, hogy az első sorozat mutassa az értékeket
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Beállítja a diagram adatlap indexét
    var defaultWorksheetIndex = 0;
    // Lekéri a diagram adat munkalapját
    var fact = chart.getChartData().getChartDataWorkbook();
    // Törli az alapértelmezett generált sorozatokat és kategóriákat
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Új kategóriákat ad hozzá
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Új sorozatot ad hozzá
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Feltölti a sorozat adatait
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Nem működik az új verzióban
    // Új pontok hozzáadása és a szektor színének beállítása
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Beállítja a szektor szegélyét
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Beállítja a szektor szegélyét
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Beállítja a szektor szegélyét
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // Egyéni címkéket hoz létre minden kategóriához az új sorozathoz
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
    // Megjeleníti a vezetővonalakat a diagramon
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Beállítja a kördiagram szektorok forgásszögét
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Mentse a prezentációt diagrammal
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven vonalgrafikonok) leginkább akkor hasznosak, ha az értékek időbeli változását akarja bemutatni. Egy vonaldiagram segítségével egyszerre sok adatot hasonlíthat össze, nyomon követheti az időbeli változásokat és trendeket, kiemelheti az anomáliákat az adatcsaládokban, stb.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Szerezze meg egy dia referenciáját az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típussal (jelen esetben `ChartType.Line`).
1. Hozzáférés a diagram adat IChartDataWorkbook-hez.
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a diagram sorozathoz.
1. Mentse a módosított prezentációt PPTX fájlként

Ez a JavaScript kód bemutatja, hogyan hozhat létre egy vonaldiagramot:

```javascript
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

Alapértelmezés szerint a vonaldiagram pontjai egyenes, folytonos vonalakkal kapcsolódnak. Ha a pontokat vonal‑szaggatott módon szeretné összekötni, a kívánt szaggatási típust a következőképpen adhatja meg:

```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```

### **Fa térkép diagramok létrehozása**

A fa térkép diagramok leginkább értékesítési adatok megjelenítésére alkalmasak, amikor a kategóriák relatív méretét és egyben a legnagyobb hozzájáruló elemeket szeretné kiemelni.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Lépések:</em> Fa térkép diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Lépések:</em> PowerPoint fa térkép diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Lépések:</em> PowerPoint prezentáció fa térkép diagram létrehozása JavaScriptben</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia referenciáját az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típussal (jelen esetben a [ChartType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartType).TreeMap).
4. Hozzáférés a diagram adat [ChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataWorkbook) objektumához.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozathoz.
8. Mentse a módosított prezentációt PPTX fájlként

Ez a JavaScript kód bemutatja, hogyan hozhat létre egy fa térkép diagramot:

```javascript
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

### **Részvény diagramok létrehozása**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Lépések:</em> Részvény diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Lépések:</em> PowerPoint részvény diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Lépések:</em> PowerPoint prezentáció részvény diagram létrehozása JavaScriptben</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia referenciáját az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típussal ([ChartType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartType).OpenHighLowClose).
4. Hozzáférés a diagram adat [ChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataWorkbook) objektumához.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozathoz.
8. Adja meg a HiLowLines formátumát.
9. Mentse a módosított prezentációt PPTX fájlként

A részvény diagram létrehozásához használt JavaScript példa:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
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

### **Doboz‑ és szárnyas diagramok létrehozása**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Lépések:</em> Doboz‑ és szárnyas diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Lépések:</em> PowerPoint doboz‑ és szárnyas diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Lépések:</em> PowerPoint prezentáció doboz‑ és szárnyas diagram létrehozása JavaScriptben</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia referenciáját az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típussal ([ChartType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartType).BoxAndWhisker).
4. Hozzáférés a diagram adat [ChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataWorkbook) objektumához.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozathoz.
8. Mentse a módosított prezentációt PPTX fájlként

Ez a JavaScript kód bemutatja, hogyan hozhat létre egy doboz‑ és szárnyas diagramot:

```javascript
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

### **Tölcsér diagramok létrehozása**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Lépések:</em> Tölcsér diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Lépések:</em> PowerPoint tölcsér diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Lépések:</em> PowerPoint prezentáció tölcsér diagram létrehozása JavaScriptben</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia referenciáját az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típussal ([ChartType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartType).Funnel).
4. Mentse a módosított prezentációt PPTX fájlként

A JavaScript kód bemutatja, hogyan hozhat létre egy tölcsér diagramot:

```javascript
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

### **Napkitörés diagramok létrehozása**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Lépések:</em> Napkitörés diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Lépések:</em> PowerPoint napkitörés diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Lépések:</em> PowerPoint prezentáció napkitörés diagram létrehozása JavaScriptben</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia referenciáját az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típussal (jelen esetben a [ChartType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartType).sunburst).
4. Mentse a módosított prezentációt PPTX fájlként

Ez a JavaScript kód bemutatja, hogyan hozhat létre egy napkitörés diagramot:

```javascript
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

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Lépések:</em> Hisztogram diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Lépések:</em> PowerPoint hisztogram diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Lépések:</em> PowerPoint prezentáció hisztogram diagram létrehozása JavaScriptben</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia referenciáját az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típussal ([ChartType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartType).Histogram).
4. Hozzáférés a diagram adat [ChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataWorkbook) objektumához.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Mentse a módosított prezentációt PPTX fájlként

Ez a JavaScript kód bemutatja, hogyan hozhat létre egy hisztogram diagramot:

```javascript
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

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Lépések:</em> Radar diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Lépések:</em> PowerPoint radar diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Lépések:</em> PowerPoint prezentáció radar diagram létrehozása JavaScriptben</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia referenciáját az indexe alapján. 
3. Adjon hozzá egy diagramot némi adattal, és állítsa be a kívánt diagramtípust (`ChartType.Radar` ebben az esetben).
4. Mentse a módosított prezentációt PPTX fájlként

Ez a JavaScript kód bemutatja, hogyan hozhat létre egy radar diagramot:

```javascript
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

### **Több kategóriás diagramok létrehozása**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Lépések:</em> Több kategóriás diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Lépések:</em> PowerPoint több kategóriás diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Lépések:</em> PowerPoint prezentáció több kategóriás diagram létrehozása JavaScriptben</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia referenciáját az indexe alapján. 
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típussal ([ChartType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartType).ClusteredColumn).
4. Hozzáférés a diagram adat [ChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataWorkbook) objektumához.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozathoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript kód bemutatja, hogyan hozhat létre egy többkategóriás diagramot:

```javascript
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

### **Térkép diagramok létrehozása**

A térkép diagram egy adatot tartalmazó terület vizualizációja. A térkép diagramok leginkább adat‑ vagy értékösszehasonlításra alkalmasak földrajzi régiók között.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Lépések:</em> Térkép diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Lépések:</em> PowerPoint térkép diagram létrehozása JavaScriptben</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Lépések:</em> PowerPoint prezentáció térkép diagram létrehozása JavaScriptben</strong></a>

Ez a JavaScript kód bemutatja, hogyan hozhat létre egy térkép diagramot:

```javascript
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

A kombinált diagram (vagy combo diagram) több diagramtípust egyesít egyetlen grafikonba. Ez a diagram lehetővé teszi két vagy több adatcsoport kiemelését, összehasonlítását vagy vizsgálatát, segítve a köztük lévő kapcsolatok felismerését.

![A kombinált diagram](combination_chart.png)

Az alábbi JavaScript kód mutatja, hogyan hozható létre a fenti kombinált diagram egy PowerPoint prezentációban:

```js
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

    // Új kategóriákat adjon hozzá.
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
    // Állítsa be a vízszintes tengelyt.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Állítsa be a függőleges tengelyt.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Állítsa be a függőleges fő hálóvonalak színét.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Állítsa be a másodlagos vízszintes tengelyt.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Állítsa be a másodlagos függőleges tengelyt.
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Lépések:</em> PowerPoint diagram frissítése JavaScriptben</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Lépések:</em> Prezentáció diagram frissítése JavaScriptben</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Lépések:</em> PowerPoint prezentáció diagram frissítése JavaScriptben</strong></a>

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztálypéldányt, amely a frissíteni kívánt diagramot tartalmazó prezentációt képviseli.
2. Szerezze meg egy dia referenciáját az Index használatával.
3. Járja be az összes alakzatot a kívánt diagram megtalálásához.
4. Hozzáférés a diagram adatlapjához.
5. Módosítsa a diagram sorozatának adatait a sorozat értékeinek megváltoztatásával.
6. Adjon hozzá egy új sorozatot, és töltse fel az adatokat.
7. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript kód bemutatja, hogyan frissíthet egy diagramot:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Első diához való hozzáférés
    var sld = pres.getSlides().get_Item(0);
    // Alapértelmezett adatokkal rendelkező diagram lekérése
    var chart = sld.getShapes().get_Item(0);
    // A diagram adatlap indexének beállítása
    var defaultWorksheetIndex = 0;
    // A diagram adat munkalapjának lekérése
    var fact = chart.getChartData().getChartDataWorkbook();
    // Diagram kategória nevének módosítása
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Az első diagram sorozat lekérése
    var series = chart.getChartData().getSeries().get_Item(0);
    // Most frissítjük a sorozat adatait
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Sorozat nevének módosítása
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // A második diagram sorozat lekérése
    series = chart.getChartData().getSeries().get_Item(1);
    // Most frissítjük a sorozat adatait
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Sorozat nevének módosítása
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Új sorozat hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // A harmadik diagram sorozat lekérése
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

## **Adattartomány beállítása diagramokhoz**

Diagram adattartományának beállításához tegye a következőket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztálypéldányt, amely a diagramot tartalmazó prezentációt képviseli.
2. Szerezze meg egy dia referenciáját az indexe alapján.
3. Járja be az összes alakzatot a kívánt diagram megtalálásához.
4. Hozzáférés a diagram adataihoz, és állítsa be a tartományt.
5. Mentse a módosított prezentációt PPTX fájlként.

Ez a JavaScript kód bemutatja, hogyan állíthatja be egy diagram adattartományát:

```javascript
var pres = new aspose.slides.Presentation();
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
Alapértelmezett jelölő használatakor a diagram sorozatai automatikusan különböző alapértelmezett jelölőszimbólumokat kapnak.

Ez a JavaScript kód bemutatja, hogyan állíthat be automatikusan egy diagram sorozat jelölőt:

```javascript
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
    // A második diagram sorozat lekérése
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Most feltöltjük a sorozat adatait
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

**Milyen diagramtípusok támogatottak az Aspose.Slides-ban?**

Az Aspose.Slides számos diagramtípust támogat, többek között oszlop, vonal, kör, terület, szórt, hisztogram, radar és még sok más. Ez a rugalmasság lehetővé teszi, hogy az adatmegjelenítés igényeihez legmegfelelőbb diagramtípust válassza.

**Hogyan adhatok hozzá új diagramot egy diához?**

Egy diagram hozzáadásához először hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztálypéldányt, szerezze be a kívánt diát az indexe alapján, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagramtípust és a kezdeti adatokat. Ez a folyamat közvetlenül beilleszti a diagramot a prezentációba.

**Hogyan frissíthetem a diagramon megjelenő adatokat?**

A diagram adatait a diagram adatkönyvtárához ([ChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/)) való hozzáféréssel, az alapértelmezett sorozatok és kategóriák törlésével, majd a saját adatok hozzáadásával frissítheti. Ez lehetővé teszi, hogy programozottan frissítse a diagramot a legújabb adatok megjelenítéséhez.

**Lehet-e testreszabni a diagram megjelenését?**

Igen, az Aspose.Slides átfogó testreszabási lehetőségeket kínál. Módosíthatja a színeket, betűtípusokat, címkéket, jelmagyarázatokat és egyéb formázási elemeket, hogy a diagram megjelenése megfeleljen a tervezési követelményeknek.