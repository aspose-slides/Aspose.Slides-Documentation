---
title: Diagramok létrehozása vagy frissítése PowerPoint prezentációkban Java-ban
linktitle: Diagramok létrehozása vagy frissítése
type: docs
weight: 10
url: /hu/java/create-chart/
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
- részvénydiagram
- doboz-és-szárnyas diagram
- tölcsér diagram
- napfény diagram
- hisztogram diagram
- radar diagram
- többkategóriás diagram
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Diagramok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for Java segítségével. Diagramok hozzáadása, formázása és szerkesztése gyakorlati Java kódrészletekkel."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt a diagramok létrehozásához és testreszabásához az Aspose.Slides segítségével. Megtanulhatja, hogyan adjon programozottan diagramot egy diára, töltse fel adatokal, és alkalmazzon különféle formázási beállításokat a specifikus tervezési igényekhez igazodva. A cikk során részletes kódrészletek illusztrálják az egyes lépéseket, a bemutató és a diagramobjektum inicializálásától a sorok, tengelyek és jelmagyarázatok konfigurálásáig. A útmutató követésével stabil megértést szerez a dinamikus diagramgenerálás integrálásáról alkalmazásaiban, egyszerűsítve a adatvezérelt prezentációk készítését.

## **Diagram létrehozása**

A diagramok segítenek az embereknek gyorsan megjeleníteni az adatokat és olyan meglátásokat nyerni, amelyek egy táblázatból vagy számolaptáblázatból nem azonnal nyilvánvalóak.

**Miért készítsünk diagramokat?**

A diagramok használatával:

* nagymennyiségű adatot aggregálhat, tömöríthet vagy összefoglalhat egyetlen dián egy prezentációban
* mintákat és trendeket tárhat fel az adatokban
* meghatározhatja az adat időbeli vagy egy adott mérőegység szerinti irányát és lendületét
* észlelheti a kiugró értékeket, anomáliákat, eltéréseket, hibákat, értelmetlen adatokat stb.
* kommunikálhat vagy bemutathat komplex adatokat

PowerPointban a *Beszúrás* funkcióval hozhat létre diagramokat, amely számos sablont kínál a különféle diagramtípusok tervezéséhez. Az Aspose.Slides használatával mind szabványos diagramokat (népszerű diagramtípusokon alapuló) mind egyéni diagramokat hozhat létre.

{{% alert color="info" title="Note" %}}
Diagramok létrehozásához használja a [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) osztályt. Ennek az osztálynak a mezői a különböző diagramtípusoknak felelnek meg.
{{% /alert %}}

### **Halmozott oszlopdiagramok létrehozása**

Ez a szakasz bemutatja, hogyan hozhat létre halmozott oszlopdiagramokat az Aspose.Slides használatával. Megtanulja, hogyan inicializáljon egy prezentációt, adjon hozzá egy diagramot, és testreszabja annak elemeit, például a címet, adatokat, sorokat, kategóriákat és a stílust. Kövesse az alábbi lépéseket, hogy lássa, hogyan jön létre egy szabványos halmozott oszlopdiagram:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy diagramot némi adattal, és adja meg a `ChartType.ClusteredColumn` típust.
1. Adjon címet a diagramhoz.
1. Hozzáférés a diagram adatmunkaablakához.
1. Törölje az összes alapértelmezett sorozatot és kategóriát.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a diagram sorozatához.
1. Alkalmazzon kitöltőszínt a diagram sorozatára.
1. Adjon címkéket a diagram sorozatához.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozható létre egy halmozott oszlopdiagram:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Létrehozza a PPTX fájlt képviselő prezentációosztályt
Presentation pres = new Presentation();
try {
    // Az első diát érinti
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Diagramot ad hozzá alapértelmezett adataival
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Beállítja a diagram címét
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Beállítja a diagram adatlap indexét
    int defaultWorksheetIndex = 0;
    
    // Lekéri a diagram adat munkalapját
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Törli az alapértelmezett létrehozott sorozatokat és kategóriákat
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Új sorozatokat ad hozzá
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Új kategóriákat ad hozzá
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Az első diagram sorozatot veszi
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Most a sorozat adatokat tölti fel
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Beállítja a sorozat kitöltőszínét
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // A második diagram sorozatot veszi
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Sorozat adatokat tölt fel
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Beállítja a sorozat kitöltőszínét
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // Egyedi címkéket hoz létre minden kategóriához az új sorozatban
    // Beállítja az első címkét, hogy a kategória nevét mutassa
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Megjeleníti az értéket a harmadik címkén
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Saves the presentation with chart
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Szórási diagramok létrehozása**

A szórási diagramok (más néven szóráspont diagramok vagy x‑y grafikonok) gyakran használatosak minták keresésére vagy két változó közötti korrelációk bemutatására.

Használjon szórási diagramot, ha:

* párosított numerikus adatokkal rendelkezik
* két változó jól párosítható egymással
* meg szeretné határozni, hogy a két változó összefügg-e
* van egy független változó, amely több értékkel rendelkezik egy függő változóhoz képest

1. Kövesse a [Halmozott oszlopdiagramok létrehozása](#create-clustered-column-charts) lépéseit.
2. A harmadik lépésnél adjon hozzá egy diagramot némi adattal, és adja meg diagramtípusát az alábbiak közül:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Egy szórási diagramot képvisel._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Egy szórási diagramot képvisel, amely görbékkel van összekötve, adatjelölőkkel._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Egy szórási diagramot képvisel, amely görbékkel van összekötve, adatjelölők nélkül._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Egy szórási diagramot képvisel, amely egyenes vonalakkal van összekötve, adatjelölőkkel._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Egy szórási diagramot képvisel, amely egyenes vonalakkal van összekötve, adatjelölők nélkül._

Ez a Java kód bemutatja, hogyan hozható létre egy szórási diagram különböző jelölőkkel minden egyes sorozathoz:

```java
import com.aspose.slides.*;

// Létrehozza a PPTX fájlt képviselő prezentáció osztályt
Presentation pres = new Presentation();
try {
    // Az első diát érinti
    ISlide slide = pres.getSlides().get_Item(0);

    // Létrehozza az alapértelmezett diagramot
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Lekéri az alapértelmezett diagram adat munkalap indexét
    int defaultWorksheetIndex = 0;
    
    // Lekéri a diagram adat munkalapját
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Törli a demó sorozatot
    chart.getChartData().getSeries().clear();
    
    // Új sorozatokat ad hozzá
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Az első diagram sorozatot veszi
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Új pontot (1:3) ad a sorozathoz
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Új pontot (2:10) ad hozzá
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Megváltoztatja a sorozat típusát
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Megváltoztatja a diagram sorozat jelölőjét
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // A második diagram sorozatot veszi
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Új pontot (5:2) ad ott
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Új pontot (3:1) ad hozzá
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Új pontot (2:2) ad hozzá
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Új pontot (5:1) ad hozzá
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Megváltoztatja a diagram sorozat jelölőjét
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Kördiagramok létrehozása**

A kördiagramok leginkább a rész‑egész viszonyok bemutatására alkalmasak, különösen akkor, ha az adatok kategóriákat és numerikus értékeket tartalmaznak. Ha azonban az adataiban sok rész vagy címke van, fontolja meg egy sávdiagram használatát.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Pie](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#Pie) típust.
4. Hozzáférés a diagram adatkönyvtárához [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozatához.
8. Adjon hozzá új pontokat a diagramhoz, és alkalmazzon egyéni színeket a kördiagram szektoraira.
9. Állítson be címkéket a sorozatokhoz.
10. Engedélyezze a vezető vonalakat a sorozatcímkékhez.
11. Állítsa be a forgási szöget a kördiagram szektorokhoz.
12. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód bemutatja, hogyan hozható létre egy kördiagram:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Létrehozza a PPTX fájlt képviselő prezentáció osztályt
Presentation pres = new Presentation();
try {
    // Az első diát érinti
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Diagramot ad hozzá alapértelmezett adatokkal
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Beállítja a diagram címét
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Beállítja a diagram adatlap indexét
    int defaultWorksheetIndex = 0;
    
    // Lekéri a diagram adat munkalapját
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Törli az alapértelmezett létrehozott sorozatokat és kategóriákat
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Új kategóriákat ad hozzá
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Új sorozatokat ad hozzá
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    // Feltölti a sorozat adatokat
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Nem működik az új verzióban
    // Új pontok hozzáadása és a szektor színének beállítása
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Beállítja a szektor szegélyét
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Beállítja a szektor szegélyét
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Beállítja a szektor szegélyét
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Egyedi címkéket hoz létre az új sorozat kategóriáihoz
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // Megjeleníti a vezető vonalakat a diagramon
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Beállítja a kördiagram szektorok forgási szögét
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Mentés a diagrammal együtt
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven vonalgrafikonok) leginkább olyan helyzetekben használandók, ahol az értékek időbeli változását szeretné bemutatni. Egy vonaldiagramot használva egyszerre összehasonlíthat nagy mennyiségű adatot, nyomon követheti a változásokat és trendeket, kiemelheti az anomáliákat az adat sorozatokban, és így tovább.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Line](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#Line) típust.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód bemutatja, hogyan hozható létre egy vonaldiagram:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Alapértelmezés szerint a vonaldiagram pontjai egyenes, folytonos vonalakkal vannak összekötve. Ha pontjait szaggatott vonalak kapcsolnák, a kívánt szaggatott vonaltípust az alábbiak szerint adhatja meg:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Fa térkép diagramok létrehozása**

A fa térkép diagramok a legjobbak értékesítési adatok esetén, amikor a kategóriák relatív méretét szeretné megjeleníteni, és gyorsan felhívni a figyelmet az egyes kategóriák nagy hozzájáruló elemeire.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Treemap](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#Treemap) típust.
4. Hozzáférés a diagram adatkönyvtárához [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozatához.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód bemutatja, hogyan hozható létre egy fa térkép diagram:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //ág 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //ág 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Részvénydiagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#OpenHighLowClose) típust.
4. Hozzáférés a diagram adatkönyvtárához [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozatához.
8. Adja meg a magas‑alacsony vonalak formátumát.
9. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód bemutatja, hogyan hozható létre egy részvénydiagram:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Box és whisker diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#BoxAndWhisker) típust.
4. Hozzáférés a diagram adatkönyvtárához [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozatához.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód bemutatja, hogyan hozható létre egy box és whisker diagram:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
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

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tölcsér diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Funnel](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#Funnel) típust.
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód bemutatja, hogyan hozható létre egy tölcsér diagram:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Sunburst diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Sunburst](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#Sunburst) típust.
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód bemutatja, hogyan hozható létre egy sunburst diagram:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //ág 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //ág 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Hisztogram diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Histogram](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#Histogram) típust.
4. Hozzáférés a diagram adatkönyvtárához [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód bemutatja, hogyan hozható létre egy hisztogram diagram:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Radar diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot némi adattal, és adja meg a kívánt diagramtípust ([ChartType.Radar](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#Radar) ebben az esetben).
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód bemutatja, hogyan hozható létre egy radar diagram:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Többkategóriás diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.ClusteredColumn](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ClusteredColumn) típust.
4. Hozzáférés a diagram adatkönyvtárához [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozatához.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód bemutatja, hogyan hozható létre egy többkategóriás diagram:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Prezentáció mentése diagrammal
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Térkép diagramok létrehozása**

A térkép diagramok földrajzi adatokat jelenítenek meg, és segítenek az értékek összehasonlításában a különböző régiók között.

Ez a Java kód bemutatja, hogyan hozható létre egy térkép diagram:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Kombináció diagramok létrehozása**

A kombinációs diagram (vagy combo diagram) több diagramtípust egyesít egyetlen grafikonban. Ez a diagram lehetővé teszi, hogy kiemelje, összehasonlítsa vagy megvizsgálja a két vagy több adathalmaz közötti különbségeket, segítve ezzel a közti kapcsolatok felismerését.

![A kombinációs diagram](combination_chart.png)

Az alábbi Java kód mutatja, hogyan hozható létre a fenti kombinációs diagram egy PowerPoint prezentációban:

```java
import com.aspose.slides.*;
import java.awt.Color;

static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Állítsa be a diagram címét.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Állítsa be a diagram jelmagyarázatát.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Törölje az alapértelmezett létrehozott sorozatokat és kategóriákat.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Új kategóriákat ad hozzá.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Az első sorozatot adja hozzá.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // Állítsa be a vízszintes tengelyt.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Állítsa be a függőleges tengelyt.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Állítsa be a függőleges fő rácsvonalak színét.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Állítsa be a másodlagos vízszintes tengelyt.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Állítsa be a másodlagos függőleges tengelyt.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```

## **Diagramok frissítése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból, amely a frissíteni kívánt diagramot tartalmazó prezentációt képviseli.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Járja be az összes alakzatot, hogy megtalálja a kívánt diagramot.
4. Hozzáférés a diagram adatmunkaablakához.
5. Módosítsa a diagram adat sorozatát a sorozatértékek megváltoztatásával.
6. Adjon hozzá egy új sorozatot, és töltse fel adatával.
7. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan frissíthető egy diagram:

```java
import com.aspose.slides.*;

// Megnyitja a frissítendő diagramot tartalmazó prezentációt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Az első dia elérése
    ISlide sld = pres.getSlides().get_Item(0);

    // Lekéri a diagramot a diáról
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // A diagram adatlapjának indexének beállítása
    int defaultWorksheetIndex = 0;

    // A diagram adatmunkaablakának lekérése
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // A diagram kategórianév módosítása
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Az első diagram sorozat lekérése
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Most frissíti a sorozat adatait
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Sorozatnév módosítása
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // A második diagram sorozat lekérése
    series = chart.getChartData().getSeries().get_Item(1);

    // Most frissíti a sorozat adatait
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Sorozatnév módosítása
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Most új sorozat hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // A harmadik diagram sorozat lekérése
    series = chart.getChartData().getSeries().get_Item(2);

    // Most a sorozat adatainak feltöltése
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Prezentáció mentése diagrammal
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Diagram adatintervallumának beállítása**

A már meglévő diagram által használt tartomány megtekintéséhez lásd a [Diagram adatintervallumának lekérdezése](/slides/hu/java/chart-workbook/#retrieve-a-charts-data-range) szakaszt.

A diagram adatintervallumának beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból, amely a diagramot tartalmazó prezentációt képviseli.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Járja be az összes alakzatot, hogy megtalálja a kívánt diagramot.
4. Hozzáférés a diagram adataihoz, és állítsa be a tartományt.
5. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan állítható be a diagram adatintervalluma:

```java
import com.aspose.slides.*;

// Megnyitja a diagramot tartalmazó prezentációt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alapértelmezett jelölők használata diagramokban**

Alapértelmezett jelölők használatakor a diagram minden sorozata automatikusan különböző jelölőszimbólumot kap.

Ez a Java kód mutatja, hogyan állítható be a diagram sorozat jelölője automatikusan:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    //Vegye a második diagram sorozatot
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    //Most a sorozat adatait tölti fel
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Milyen diagramtípusokat támogat az Aspose.Slides?**

Az Aspose.Slides széles körű [diagramtípusokat](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) támogat, beleértve az oszlop, vonal, kör, terület, szórás, hisztogram, radar és még sok más típust. Ez a rugalmasság lehetővé teszi, hogy a legmegfelelőbb diagramtípust válassza adatvizualizációs igényeihez.

**Hogyan adhatok hozzá új diagramot egy diához?**

Diagram hozzáadásához először hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból, szerezze be a kívánt diát az indexe alapján, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagramtípust és a kezdeti adatokat. Ez a folyamat közvetlenül beilleszti a diagramot a prezentációba.

**Hogyan frissíthetem a diagramon megjelenített adatokat?**

A diagram adatait a diagram adatkönyvtárához ([IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/)) való hozzáféréssel, az alapértelmezett sorozatok és kategóriák törlésével, majd saját adatainak hozzáadásával frissítheti. Ez lehetővé teszi, hogy a diagram a legújabb adatokat tükrözze.

**Lehetőség van a diagram megjelenésének testreszabására?**

Igen, az Aspose.Slides kiterjedt testreszabási lehetőségeket biztosít. Módosíthatja a színeket, betűtípusokat, címkéket, jelmagyarázatokat és más [formázási elemek](/slides/hu/java/chart-entities/) megjelenését, hogy a diagramot a specifikus tervezési követelményeihez illesse.