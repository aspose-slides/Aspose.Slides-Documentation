---
title: "PowerPoint-diagramok létrehozása vagy frissítése Androidon"
linktitle: "Diagramok létrehozása vagy frissítése"
type: docs
weight: 10
url: /hu/androidjava/create-chart/
keywords:
- diagram hozzáadása
- diagram létrehozása
- diagram szerkesztése
- diagram módosítása
- diagram frissítése
- szórásdiagram
- tortadiagram
- vonaldiagram
- fa térképe diagram
- részvénydiagram
- doboz‑ és bajuszdiagram
- tölcsérdiagram
- napfénytérkép diagram
- hisztogram diagram
- radar diagram
- többkategóriás diagram
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "PowerPoint-prezentációkban diagramok létrehozása és testreszabása az Aspose.Slides for Android segítségével. Diagramok hozzáadása, formázása és szerkesztése gyakorlati Java kódrészletekkel."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt a diagramok létrehozásához és testreszabásához az Aspose.Slides segítségével. Megtanulhatja, hogyan adjon programozottan diagramot egy diára, hogyan töltse fel adatokal, és hogyan alkalmazzon különféle formázási beállításokat a konkrét tervezési igényekhez. A cikk során részletes kódpéldák mutatják be az egyes lépéseket, az előadás és a diagramobjektum inicializálásától a sorok, tengelyek és jelmagyarázatok konfigurálásáig. Az útmutató követésével alaposan megértheti, hogyan integrálhat dinamikus diagramgenerálást alkalmazásaiba, egyszerűsítve az adat‑vezérelt prezentációk létrehozását.

## **Diagram létrehozása**

A diagramok segítenek gyorsan megjeleníteni az adatokat és olyan betekintéseket nyújtanak, amelyek egy táblázatból vagy munkafüzetből nem azonnal láthatók.

**Miért érdemes diagramokat készíteni?**

Diagramok használatával:

* nagy mennyiségű adatot összegezhet, tömöríthet vagy összefoglalhat egyetlen dián
* mintákat és tendenciákat tárhat fel az adatokban
* meghatározhatja az adatok irányát és lendületét időben vagy egy adott mértékegységhez képest
* észlelhet kiugró értékeket, rendellenességeket, eltéréseket, hibákat, érthetetlen adatokat stb.
* összetett adatokat kommunikálhat vagy mutathat be

A PowerPointban diagramokat a *Beszúrás* funkcióval hozhat létre, amely számos diagramtípus sablonját kínálja. Az Aspose.Slides segítségével hagyományos diagramokat (népszerű diagramtípusok alapján) és egyéni diagramokat is készíthet.

{{% alert color="info" title="Megjegyzés" %}}

Diagramok létrehozásához használja a [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) osztályt. Ennek az osztálynak a mezői a különböző diagramtípusoknak felelnek meg.

{{% /alert %}}

### **Csoportosított oszlopdiagramok létrehozása**

Ez a szakasz bemutatja, hogyan készítsen csoportosított oszlopdiagramot az Aspose.Slides segítségével. Megtanulja, hogyan inicializáljon egy prezentációt, adjon hozzá egy diagramot, és hogyan testreszabja annak elemeit, például a címet, az adatokat, a sorokat, a kategóriákat és a stílusokat. Kövesse az alábbi lépéseket, hogy lássa, hogyan jön létre egy szabványos csoportosított oszlopdiagram:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy diagramot némi adattal, és adja meg a `ChartType.ClusteredColumn` típust.
1. Adjon címet a diagramnak.
1. Érje el a diagram adat munkalapját.
1. Törölje az összes alapértelmezett sort és kategóriát.
1. Adjon hozzá új sorokat és kategóriákat.
1. Adjon hozzá új diagramadatot a diagram sorokhoz.
1. Alkalmazzon kitöltőszínt a diagram sorokra.
1. Adjon címkéket a diagram sorokhoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozhat létre csoportosított oszlopdiagramot:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Létrehozza a prezentáció osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Hozzáad egy diagramot az alapértelmezett adataival
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Beállítja a diagram címét
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Beállítja az indexet a diagram adatlaphoz
    int defaultWorksheetIndex = 0;
    
    // Lekéri a diagram adat munkalapot
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Törli az alapértelmezett generált sorokat és kategóriákat
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Új sorok hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Új kategóriák hozzáadása
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Az első diagram sort veszi
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Most feltölti a sor adatait
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Beállítja a sor kitöltő színét
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // A második diagram sort veszi
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Feltölti a sor adatait
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Beállítja a sor kitöltő színét
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // Egyéni címkék létrehozása az új sor minden kategóriájához
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
    
    // Elmenti a diagrammal együtt a prezentációt
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Szórádiagramok létrehozása**

A szórádiagramok (más néven pontdiagramok vagy x‑y grafikonok) gyakran használatosak minták keresésére vagy két változó közötti korreláció bemutatására.

Használjon szórádiagramot, ha:

* párosított numerikus adatokkal rendelkezik
* két változó jól párosítható egymással
* meg szeretné határozni, hogy a két változó összefügg-e
* egy független változó több értékkel rendelkezik egy függő változóhoz képest

1. Kövesse a [Create Clustered Column Charts](#create-clustered-column-charts) lépéseit.
2. A harmadik lépésben adjon hozzá egy diagramot némi adattal, és adja meg a diagram típusát az alábbiak közül:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Szórádiagramot jelenít meg markerekkel._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Szórádiagramot ívekkel összekötve, markerekkel._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Szórádiagramot ívekkel összekötve, markerek nélkül._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Szórádiagramot egyenes vonalakkal, markerekkel._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Szórádiagramot egyenes vonalakkal, markerek nélkül._

Ez a Java kód mutatja, hogyan hozhat létre szórádiagramot különböző markerekkel minden sorhoz:

```java
import com.aspose.slides.*;

// Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide slide = pres.getSlides().get_Item(0);

    // Létrehozza az alapértelmezett diagramot
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Lekéri az alapértelmezett diagram adat munkalap indexet
    int defaultWorksheetIndex = 0;
    
    // Lekéri a diagram adat munkalapot
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Törli a demó sorokat
    chart.getChartData().getSeries().clear();
    
    // Új sorok hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Az első diagram sort veszi
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Új pont hozzáadása (1:3) a sorhoz
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Új pont hozzáadása (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Módosítja a sor típusát
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Módosítja a diagram sor markerét
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // A második diagram sort veszi
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Új pont hozzáadása (5:2) ott
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Új pont hozzáadása (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Új pont hozzáadása (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Új pont hozzáadása (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Módosítja a diagram sor markerét
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Tortadiagramok létrehozása**

A tortadiagramok leginkább alkalmasak a rész‑teljes arány megjelenítésére, különösen akkor, ha az adatok kategóriákat és numerikus értékeket tartalmaznak. Ha azonban az adat sok részt vagy címkét tartalmaz, érdemes oszlopdiagramot használni.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Pie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Pie) típust.
4. Érje el a diagram adat munkafüzetét [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorokat és kategóriákat.
6. Adjon hozzá új sorokat és kategóriákat.
7. Adjon hozzá új diagramadatot a diagram sorokhoz.
8. Adjon új pontokat a diagramhoz, és alkalmazzon egyedi színeket a tortadiagram szeleteihez.
9. Állítson be címkéket a sorokhoz.
10. Engedélyezze a vezetővonalakat a sorcímkékhez.
11. Állítsa be a forgásszöget a tortadiagram szeleteihez.
12. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre tortadiagramot:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Hozzáad egy diagramot az alapértelmezett adatokkal
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Beállítja a diagram címét
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Beállítja a diagram adatlap indexét
    int defaultWorksheetIndex = 0;
    
    // Lekéri a diagram adat munkalapot
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Törli az alapértelmezett generált sorokat és kategóriákat
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Új kategóriák hozzáadása
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Új sorok hozzáadása
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Feltölti a sor adatait
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
    
    // Egyéni címkék létrehozása az új sor minden kategóriájához
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
    
    // Megjeleníti a vezetővonalakat a diagramhoz
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Beállítja a tortadiagram szektorok forgásszögét
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Elmenti a diagrammal együtt a prezentációt
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven vonalgrafikonok) leginkább olyan helyzetekben használatosak, amikor az értékek időbeli változását szeretné bemutatni. Egy vonaldiagram segítségével egyszerre összehasonlíthat nagy mennyiségű adatot, nyomon követheti az időbeli változásokat és tendenciákat, kiemelheti az anomáliákat az adat sorokban, és még sok mást.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Line) típust.
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

Alapértelmezés szerint a vonaldiagram pontjai egyenes folytonos vonalakkal kapcsolódnak. Ha szeretné, hogy a pontok szaggatott vonallal legyenek összekötve, adja meg a kívánt vonaltípust a következő módon:

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

### **Fák térképe diagramok létrehozása**

A fák térképe diagramok leginkább értékesítési adatok esetén hasznosak, amikor a kategóriák relatív méretét szeretné megjeleníteni, és gyorsan felhívni a figyelmet a nagy hozzájáruló tételekre az egyes kategóriákon belül.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Treemap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Treemap) típust.
4. Érje el a diagram adat munkafüzetét [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorokat és kategóriákat.
6. Adjon hozzá új sorokat és kategóriákat.
7. Adjon hozzá új diagramadatot a diagram sorokhoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre fák térképe diagramot:

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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#OpenHighLowClose) típust.
4. Érje el a diagram adat munkafüzetét [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorokat és kategóriákat.
6. Adjon hozzá új sorokat és kategóriákat.
7. Adjon hozzá új diagramadatot a diagram sorokhoz.
8. Adja meg a high‑low vonalak formátumát.
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

### **Doboz‑ és bajuszdiagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#BoxAndWhisker) típust.
4. Érje el a diagram adat munkafüzetét [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorokat és kategóriákat.
6. Adjon hozzá új sorokat és kategóriákat.
7. Adjon hozzá új diagramadatot a diagram sorokhoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre doboz‑ és bajuszdiagramot:

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

### **Trevelő diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Funnel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Funnel) típust.
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre trevelő diagramot:

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

### **Napfénytérkép diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Sunburst](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Sunburst) típust.
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan hozhat létre napfénytérkép diagramot:

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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Histogram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Histogram) típust.
4. Érje el a diagram adat munkafüzetét [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorokat és kategóriákat.
6. Adjon hozzá új sorokat és kategóriákat.
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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy diagramot némi adattal, és adja meg a kívánt diagramtípust ([ChartType.Radar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Radar) ebben az esetben).
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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.ClusteredColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ClusteredColumn) típust.
4. Érje el a diagram adat munkafüzetét [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Törölje az alapértelmezett sorokat és kategóriákat.
6. Adjon hozzá új sorokat és kategóriákat.
7. Adjon hozzá új diagramadatot a diagram sorokhoz.
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

    // Sorok hozzáadása
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

A térkép diagramok földrajzi adatokat jelenítenek meg, és segítenek az értékek összehasonlításában a régiók között.

Ez a Java kód mutatja, hogyan hozhat létre térkép diagramot:

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

A kombinált diagram (vagy combo diagram) két vagy több diagramtípust egyesít egyetlen grafikonba. Ez a diagram lehetővé teszi, hogy kiemelje, összehasonlítsa vagy vizsgálja a különböző adatcsoportok közötti különbségeket, segítve a köztük lévő kapcsolatok feltárását.

![The combination chart](combination_chart.png)

Az alábbi Java kód mutatja, hogyan hozhatja létre a fenti kombinált diagramot egy PowerPoint prezentációban:

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

    // Törli az alapértelmezett generált sorokat és kategóriákat.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Új kategóriák hozzáadása.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Az első sor hozzáadása.
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
    // A vízszintes tengely beállítása.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // A függőleges tengely beállítása.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // A függőleges fő rácsvonalak színének beállítása.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // A másodlagos vízszintes tengely beállítása.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // A másodlagos függőleges tengely beállítása.
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

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból, amely a frissítendő diagramot tartalmazza.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Járja be az összes alakzatot, hogy megtalálja a kívánt diagramot.
4. Érje el a diagram adat munkalapját.
5. Módosítsa a diagram adat sorait a sorértékek megváltoztatásával.
6. Adjon hozzá egy új sort, és töltse fel annak adatait.
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

    // A diagram adatlap indexének beállítása
    int defaultWorksheetIndex = 0;

    // A diagram adat munkalapjának lekérése
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Diagram kategória nevének módosítása
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Az első diagram sorának kivétele
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Sor adatainak frissítése most
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Sor nevének módosítása
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // A második diagram sorának kivétele
    series = chart.getChartData().getSeries().get_Item(1);

    // Sor adatainak frissítése most
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Sor nevének módosítása
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Új sor hozzáadása most
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // A harmadik diagram sorának kivétele
    series = chart.getChartData().getSeries().get_Item(2);

    // Sor adatainak feltöltése most
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

## **Diagram adat tartomány beállítása**

A már létező diagram által használt tartomány megtekintéséhez nézze meg a [Retrieve a Chart's Data Range](/slides/hu/androidjava/chart-workbook/#retrieve-a-charts-data-range) oldalt.

Az adat tartomány beállításához a diagramnál kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból, amely a diagramot tartalmazó prezentációt képviseli.
2. Szerezzen hivatkozást egy diára az indexe alapján.
3. Járja be az összes alakzatot, hogy megtalálja a kívánt diagramot.
4. Érje el a diagram adatot, és állítsa be a tartományt.
5. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód mutatja, hogyan állítható be a diagram adat tartománya:

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

## **Alapértelmezett markerek használata diagramokban**

Alapértelmezett markerek használatakor a diagram minden sorához automatikusan más‑mást jelölő szimbólum kerül.

Ez a Java kód mutatja, hogyan állítható be egy diagram sorjának marker automatikusan:

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
    //Második diagram sorának kivétele
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    //Most a sor adatainak feltöltése
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

Az Aspose.Slides számos [chart types](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) típust támogat, többek között oszlop, vonal, torta, terület, szórás, hisztogram, radar és még sok más. Ez a rugalmasság lehetővé teszi a legmegfelelőbb diagramtípus kiválasztását az adatvizualizációs igényeihez.

**Hogyan adhatok új diagramot egy diához?**

Diagram hozzáadásához először hozza létre a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztály egy példányát, szerezze be a kívánt diát az indexe alapján, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagram típusát és a kezdeti adatokat. Ez a folyamat közvetlenül beilleszti a diagramot a prezentációba.

**Hogyan frissíthetem a diagramon megjelenő adatokat?**

A diagram adatait a diagram adat munkafüzetének ([IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/)) elérésével, az alapértelmezett sorok és kategóriák törlésével, majd saját adatok hozzáadásával frissítheti. Így a diagram mindig a legújabb adatokat tükrözi.

**Lehet-e testre szabni a diagram megjelenését?**

Igen, az Aspose.Slides kiterjedt testreszabási lehetőségeket biztosít. Módosíthatja a színeket, betűtípusokat, címkéket, jelmagyarázatokat és egyéb [formatting elements](/slides/hu/androidjava/chart-entities/) elemeket, hogy a diagram kinézete megfeleljen a tervezési követelményeinek.