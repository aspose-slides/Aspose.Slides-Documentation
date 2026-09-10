---
title: Diagramok létrehozása vagy frissítése PowerPoint prezentációkban Androidon
linktitle: Diagramok létrehozása vagy frissítése
type: docs
weight: 10
url: /hu/androidjava/create-chart/
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
- doboz és szakáll diagram
- tölcsér diagram
- napkitörés diagram
- hisztogram diagram
- radar diagram
- többkategóriás diagram
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Diagramok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for Android segítségével. Diagramok hozzáadása, formázása és szerkesztése gyakorlati Java kódpéldákkal."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt arról, hogyan hozhatunk létre és testreszabhatunk diagramokat az Aspose.Slides segítségével. Megtanulja, hogyan adhat programozott módon diagramot egy diára, hogyan töltheti fel adatokal, és hogyan alkalmazhat különféle formázási lehetőségeket a specifikus tervezési követelményeknek megfelelően. A cikk során részletes kódrészletek illusztrálják az egyes lépéseket, a prezentáció és a diagramobjektum inicializálásától a sorok, tengelyek és jelmagyarázatok konfigurálásáig. Ezen útmutató követésével alaposan megértheti, hogyan integrálhat dinamikus diagramgenerálást alkalmazásaiba, egyszerűsítve az adat‑vezérelt prezentációk létrehozását.

## **Diagram létrehozása**

A diagramok segítenek az embereknek gyorsan megérteni az adatokat, és betekintést nyújtanak, ami egy táblázatból vagy számolaptábla‑lapból nem feltétlenül látható.

**Miért hozunk létre diagramokat?**

Diagramok használatával:

* nagymennyiségű adatot összegyűjthet, tömöríthet vagy összefoglalhat egyetlen dián a prezentációban
* mintákat és trendeket fedhet fel az adatokban
* meghatározhatja az adatok irányát és lendületét időben vagy egy adott mérőegységhez viszonyítva
* felismerheti az outliereket, eltéréseket, hibákat, értelmetlen adatokat stb.
* komplex adatokat kommunikálhat vagy prezentálhat

PowerPointban a *Insert* (Beszúrás) funkcióval hozhat létre diagramokat, amely különböző típusú diagramok sablonjait kínálja. Az Aspose.Slides használatával mind szabványos diagramokat (népszerű diagramtípusok alapján), mind egyedi diagramokat hozhat létre.

{{% alert color="info" title="Note" %}}
Diagramok létrehozásához használja a [ChartType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/) osztályt. Az osztály mezői a különböző diagramtípusoknak felelnek meg.
{{% /alert %}}

### **Csoportosított oszlopdiagramok létrehozása**

Ez a rész ismerteti, hogyan hozhat létre csoportosított oszlopdiagramot az Aspose.Slides segítségével. Megtanulja, hogyan inicializáljon egy prezentációt, adjon hozzá diagramot, és testre szabja annak elemeit, például a címet, az adatokat, a sorozatokat, a kategóriákat és a stílust. Kövesse az alábbi lépéseket a standard csoportosított oszlopdiagram generálásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy diagramot némi adattal, és adja meg a `ChartType.ClusteredColumn` típust.
1. Adjon a diagramnak címet.
1. Hozzáférés a diagram adatlapjához.
1. Törölje az összes alapértelmezett sorozatot és kategóriát.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a diagram sorozathoz.
1. Alkalmazzon kitöltőszínt a diagram sorozatra.
1. Adjon címkéket a diagram sorozathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozhat létre csoportosított oszlopdiagramot:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Diagramot ad hozzá alapértelmezett adataival
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Beállítja a diagram címét
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Beállítja a diagram adatlapjának indexét
    int defaultWorksheetIndex = 0;
    
    // Lekéri a diagram adatlapját
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Törli az alapértelmezett generált sorozatokat és kategóriákat
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
    
    // Most feltölti a sorozat adatait
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Beállítja a sorozat kitöltőszínét
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // A második diagram sorozatot veszi
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Feltölti a sorozat adatait
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Beállítja a sorozat kitöltőszínét
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // Egyéni címkéket hoz létre az új sorozat minden kategóriájához
    // Beállítja az első címkét, hogy a kategórianév jelenjen meg
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Megjeleníti az értéket a harmadik címkén
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Mentse a prezentációt diagrammal
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Szórt diagramok létrehozása**

A szórt diagramok (más néven scatter plot vagy x‑y grafikon) gyakran használatosak minták keresésére vagy két változó közötti korreláció bemutatására.

Használjon szórt diagramot, ha:

* párosított numerikus adatokat tartalmaz
* két olyan változója van, amely jól párosítható
* meg szeretné határozni, hogy a két változó összefügg‑e
* egy független változója több értéket tartalmaz egy függő változóhoz képest

1. Kövesse a [Create Clustered Column Charts](#create-clustered-column-charts) szakasz lépéseit.
2. A harmadik lépésben adjon hozzá egy diagramot némi adattal, és adja meg a diagramtípust a következők egyikeként:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) – _Szórt diagram pontokkal._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) – _Szórt diagram sima vonalakkal és pontokkal._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) – _Szórt diagram sima vonalakkal, pontok nélkül._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) – _Szórt diagram egyenes vonalakkal és pontokkal._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) – _Szórt diagram egyenes vonalakkal, pontok nélkül._

Ez a Java kód mutatja, hogyan hozhat létre szórt diagramot különböző jelölőkkel minden sorozathoz:

```java
import com.aspose.slides.*;

// Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide slide = pres.getSlides().get_Item(0);

    // Létrehozza az alapértelmezett diagramot
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Lekéri az alapértelmezett diagram adatlap indexét
    int defaultWorksheetIndex = 0;
    
    // Lekéri a diagram adatlapot
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Törli a demo sorozatot
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
    
    // Új pontot (5:2) ad hozzá ott
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

A kördiagramok leginkább a rész‑egész kapcsolat bemutatására alkalmasak, különösen akkor, ha az adatok kategóriákat tartalmazó numerikus értékekből állnak. Ha azonban sok rész vagy címke van, érdemes oszlopdiagramot használni.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Pie](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#Pie) típust.
4. Hozzáférés a diagram adatkönyvtárához: [IChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozathoz.
8. Adjon hozzá új pontokat a diagramhoz, és alkalmazzon egyedi színeket a kördiagram szektoraira.
9. Állítson be címkéket a sorozathoz.
10. Engedélyezze a vezetővonalakat a sorozatcímkékhez.
11. Állítsa be a forgatási szöget a kördiagram szektorainál.
12. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre kördiagramot:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Hozzáad egy diagramot alapértelmezett adatokkal
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Beállítja a diagram címét
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Beállítja a diagram adatlapjának indexét
    int defaultWorksheetIndex = 0;
    
    // Lekéri a diagram adatlapot
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Törli az alapértelmezett generált sorozatokat és kategóriákat
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Új kategóriákat ad hozzá
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Új sorozatot ad hozzá
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Feltölti a sorozat adatait
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Nem működik az új verzióban
    // Adding new points and setting sector color
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
    
    // Egyéni címkéket hoz létre az új sorozat minden kategóriájához
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
    
    // Megjeleníti a vezetővonalakat a diagramon
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Beállítja a kördiagram szektorok forgatási szögét
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Mentse a prezentációt diagrammal
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven vonalgrafikonok) leginkább akkor használandók, amikor az értékek időbeli változását kívánja bemutatni. Egy vonaldiagram segítségével egyszerre sok adatot összehasonlíthat, nyomon követheti az időbeli változásokat és trendeket, kiemelheti az anomáliákat az adat sorozatokban, és még sok mást.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Line](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#Line) típust.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre vonaldiagramot:

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

Alapértelmezés szerint a vonaldiagram pontjai egyenes, folytonos vonallal vannak összekötve. Ha pontok helyett szaggatott vonallal szeretné összekötni őket, adja meg a kívánt szaggatott típusát az alábbiak szerint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Fa térkép diagramok létrehozása**

A fa térkép diagramok leginkább értékesítési adatokhoz alkalmasak, amikor a kategóriák relatív méretét szeretné megjeleníteni, és gyorsan felhívni a figyelmet a nagy hozzájáruló tételekre minden kategóriában.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Treemap](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#Treemap) típust.
4. Hozzáférés a diagram adatkönyvtárához: [IChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozathoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre fa térkép diagramot:

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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#OpenHighLowClose) típust.
4. Hozzáférés a diagram adatkönyvtárához: [IChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozathoz.
8. Adja meg a magas‑alacsony vonalak formátumát.
9. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre részvénydiagramot:

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

### **Doboz‑ és szakáll diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#BoxAndWhisker) típust.
4. Hozzáférés a diagram adatkönyvtárához: [IChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozathoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre doboz‑ és szakáll diagramot:

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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Funnel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#Funnel) típust.
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre tölcsér diagramot:

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

### **Napkitörés diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Sunburst](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#Sunburst) típust.
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre napkitörés diagramot:

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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Histogram](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#Histogram) típust.
4. Hozzáférés a diagram adatkönyvtárához: [IChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre hisztogram diagramot:

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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot némi adattal, és adja meg a kívánt diagramtípust (ebben az esetben a [ChartType.Radar](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#Radar)).
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre radar diagramot:

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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.ClusteredColumn](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/#ClusteredColumn) típust.
4. Hozzáférés a diagram adatkönyvtárához: [IChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozathoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre többkategóriás diagramot:

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

### **Térképi diagramok létrehozása**

A térképi diagramok földrajzi adatokat jelenítenek meg, és segítenek az értékek régiók közti összehasonlításában.

Ez a Java kód mutatja, hogyan hozhat létre térképi diagramot:

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

### **Kombinált diagramok létrehozása**

A kombinált diagram (vagy combo diagram) több diagramtípust egyesít egyetlen grafikonba. Ez a diagram lehetővé teszi, hogy kiemelje, összehasonlítsa vagy elemezze a különböző adatkészletek közötti eltéréseket, ezáltal segítve a kapcsolatok feltárását.

![The combination chart](combination_chart.png)

Az alábbi Java kód mutatja, hogyan hozhatja létre a fenti kombinált diagramot egy PowerPoint‑prezentációban:

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

    // Törli az alapértelmezett generált sorozatokat és kategóriákat.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Új kategóriákat ad hozzá.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Hozza hozzá az első sorozatot.
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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból, amely a frissíteni kívánt diagramot tartalmazó prezentációt képviseli.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Járja be az összes alakzatot a kívánt diagram megtalálásához.
4. Hozzáférés a diagram adatlapjához.
5. Módosítsa a diagram adat-sorozatát a sorozatértékek megváltoztatásával.
6. Adjon hozzá egy új sorozatot, és töltse fel az adatait.
7. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan frissíthet egy diagramot:

```java
import com.aspose.slides.*;

// Megnyitja a prezentációt, amely a frissítendő diagramot tartalmazza
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Első dia elérése
    ISlide sld = pres.getSlides().get_Item(0);

    // A diagram lekérése a diáról
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // A diagram adatlapjának indexének beállítása
    int defaultWorksheetIndex = 0;

    // A diagram adatlapjának lekérése
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Diagram kategórianév módosítása
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Az első diagram sorozatának kivétele
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Sorozat adatainak frissítése
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Sorozat nevének módosítása
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // A második diagram sorozatának kivétele
    series = chart.getChartData().getSeries().get_Item(1);

    // Sorozat adatainak frissítése
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Sorozat nevének módosítása
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Új sorozat hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // A harmadik diagram sorozatának kivétele
    series = chart.getChartData().getSeries().get_Item(2);

    // Sorozat adatainak feltöltése
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

## **Adattartomány beállítása diagramhoz**

A diagram adattartományának beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból, amely a diagramot tartalmazó prezentációt képviseli.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Járja be az összes alakzatot a kívánt diagram megtalálásához.
4. Hozzáférés a diagram adataihoz, és állítsa be a tartományt.
5. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan állíthatja be a diagram adattartományát:

```java
import com.aspose.slides.*;

// Megnyitja a prezentációt, amely a diagramot tartalmazza
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

Ez a Java kód mutatja, hogyan állíthatja be automatikusan a diagram sorozat jelölőjét:

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
    // A második diagram sorozatának kivétele
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Most sorozat adatainak feltöltése
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

Az Aspose.Slides számos [diagramtípust](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/) támogat, többek között oszlop, vonal, kör, terület, szórt, hisztogram, radar és még sok más. Ez a rugalmasság lehetővé teszi, hogy az adatvizualizációs igényeihez legmegfelelőbb diagramot válassza.

**Hogyan adhatok új diagramot egy diára?**

Új diagram hozzáadásához először hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból, szerezze meg a kívánt diát az indexe alapján, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagramtípust és a kezdeti adatokat. Ez a folyamat a diagramot közvetlenül a prezentációba ágyazza.

**Hogyan frissíthetem a diagramon megjelenített adatokat?**

A diagram adatait a diagram adatkönyvtárához ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/)) való hozzáféréssel frissítheti, törölheti az alapértelmezett sorozatokat és kategóriákat, majd hozzáadhatja saját egyéni adatait. Így a diagram mindig a legfrissebb adatokat tükrözi.

**Testreszabható-e a diagram megjelenése?**

Igen, az Aspose.Slides számos testreszabási lehetőséget kínál. Módosíthatja a színeket, betűtípusokat, címkéket, jelmagyarázatokat és egyéb [formatting elements](/slides/hu/androidjava/chart-entities/) elemeket, hogy a diagram megjelenése megfeleljen a tervezési követelményeinek.