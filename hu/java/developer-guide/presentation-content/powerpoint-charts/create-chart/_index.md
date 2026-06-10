---
title: PowerPoint prezentáció diagramok létrehozása vagy frissítése Java-ban
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
- doboz- és szárnydiagram
- tölcsérdiagram
- sugárdiagram
- hisztogram diagram
- radar diagram
- többkategóriás diagram
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "PowerPoint prezentációkban diagramok létrehozása és testreszabása Aspose.Slides for Java segítségével. Diagramok hozzáadása, formázása és szerkesztése gyakorlati Java kódrészletekkel."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt a diagramok létrehozásához és testreszabásához az Aspose.Slides használatával. Megtanulja, hogyan lehet programozott módon diagramot hozzáadni egy diára, adatokat feltölteni, és különböző formázási beállításokat alkalmazni a konkrét tervezési követelményekhez igazodva. A cikk során részletes kódrészletek mutatják be az egyes lépéseket, a bemutató és a diagramobjektum inicializálásától a sorozatok, tengelyek és jelmagyarázatok konfigurálásáig. Az útmutató követésével szilárd megértést szerez a dinamikus diagramgenerálás integrálásáról az alkalmazásokba, egyszerűsítve az adatalapú bemutatók létrehozásának folyamatát.

## **Diagram létrehozása**

A diagramok segítenek az embereknek gyorsan megjeleníteni az adatokat és betekintést nyerni, ami egy táblázatból vagy elektronikus táblázatból nem feltétlenül nyerhető könnyen.  

**Miért érdemes diagramokat készíteni?**

* nagyszámú adat aggregálása, tömörítése vagy összegzése egyetlen dián a bemutatóban  
* minták és trendek feltárása az adatokban  
* az adatok irányának és lendületének meghatározása időben vagy egy adott mérőegység vonatkozásában  
* kitűnik a kiugró értékek, hibák, eltérések, értelmetlen adatok stb.  
* összetett adatok kommunikálása vagy bemutatása  

A PowerPoint-ban diagramokat hozhat létre a Beszúrás funkción keresztül, amely számos diagramtípus tervezéséhez sablonokat biztosít. Az Aspose.Slides használatával rendszeres diagramokat (népszerű diagramtípusokon alapuló) és egyedi diagramokat hozhat létre.

{{% alert color="primary" %}} 
A diagramok létrehozásához az Aspose.Slides biztosítja a [ChartType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ChartType) osztályt. Ennek az osztálynak a mezői a különböző diagramtípusoknak felelnek meg.
{{% /alert %}} 

### **Normál diagramok létrehozása**

_Lépések: Diagram létrehozása_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Lépések:</em> PowerPoint-diagram létrehozása Java-ban</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Lépések:</em> Prezentáció-diagram létrehozása Java-ban</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Lépések:</em> PowerPoint prezentáció-diagram létrehozása Java-ban</strong></a>

_Kódlépések:_

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy diagramot némi adattal, és adja meg a kívánt diagramtípust.  
4. Adjon a diagramnak címet.  
5. Érje el a diagram adat munkalapját.  
6. Törölje az összes alapértelmezett sorozatot és kategóriát.  
7. Adjon hozzá új sorozatokat és kategóriákat.  
8. Adjon hozzá némi új diagramadatot a diagram sorozathoz.  
9. Adjon kitöltőszínt a diagram sorozatnak.  
10. Adjon címkéket a diagram sorozathoz.  
11. Írja a módosított bemutatót PPTX fájlba.  

```java
    // Létrehozza a prezentáció osztályt, amely egy PPTX fájlt képvisel
    Presentation pres = new Presentation();
    try {
        // Hozzáfér az első diához
        ISlide sld = pres.getSlides().get_Item(0);
        
        // Diagramot ad hozzá az alapértelmezett adatokkal
        IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
        
        // Beállítja a diagram címét
        chart.getChartTitle().addTextFrameForOverriding("Sample Title");
        chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
        chart.getChartTitle().setHeight(20);
        chart.hasTitle();
        
        // Beállítja az első sorozatot, hogy megjelenítse az értékeket
        chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
        
        // Beállítja a diagram adatlapjának indexét
        int defaultWorksheetIndex = 0;
        
        // Lekéri a diagram adat munkalapját
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
        
        // Kiválasztja az első diagram sorozatot
        IChartSeries series = chart.getChartData().getSeries().get_Item(0);
        
        // Most feltölti a sorozat adatait
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
        
        // Beállítja a sorozat kitöltőszínét
        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
        
        // Kiválasztja a második diagram sorozatot
        series = chart.getChartData().getSeries().get_Item(1);
        
        // Feltölti a sorozat adatait
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
        series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
        
        // Beállítja a sorozat kitöltőszínét
        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
        
        // Egyéni címkéket hoz létre minden kategóriához az új sorozatban
        // Beállítja az első címkét, hogy megjelenítse a kategória nevét
        IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
        lbl.getDataLabelFormat().setShowCategoryName(true);
        
        lbl = series.getDataPoints().get_Item(1).getLabel();
        lbl.getDataLabelFormat().setShowSeriesName(true);
        
        // Megjeleníti az értéket a harmadik címkén
        lbl = series.getDataPoints().get_Item(2).getLabel();
        lbl.getDataLabelFormat().setShowValue(true);
        lbl.getDataLabelFormat().setShowSeriesName(true);
        lbl.getDataLabelFormat().setSeparator("/");
        
        // Elmenti a prezentációt diagrammal
        pres.save("output.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
```

### **Szórt diagramok létrehozása**

A szórt diagramok (más néven szórt ábrák vagy x‑y grafikonok) gyakran használatosak minták keresésére vagy két változó közötti korrelációk bemutatására.

Szórt diagramot a következő esetekben érdemes használni  

* párosított numerikus adataink vannak  
* két változó, amely jól párosítható  
* meg szeretnénk határozni, hogy a két változó kapcsolódik‑e  
* független változónk több értékkel rendelkezik egy függő változóhoz  

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Lépések:</em> Szórt diagram létrehozása Java-ban</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Lépések:</em> PowerPoint szórt diagram létrejezása Java-ban</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Lépések:</em> PowerPoint prezentáció szórt diagram létrejezása Java-ban</strong></a>

1. Kövesse a fent említett lépéseket a [Normál diagramok létrehozása](#creating-normal-charts) részben.  
2. A harmadik lépéshez adjon hozzá egy diagramot némi adattal, és adja meg a diagramtípusát a következők egyikeként  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Szórt diagramot képvisel._  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Szórt diagramot ábrázol, amelyet íves vonalak kötnek össze, adatjelölőkkel._  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Szórt diagramot ábrázol, amelyet íves vonalak kötnek össze, adatjelölők nélkül._  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Szórt diagramot ábrázol, amelyet egyenes vonalak kötnek össze, adatjelölőkkel._  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Szórt diagramot ábrázol, amelyet egyenes vonalak kötnek össze, adatjelölők nélkül._

Ez a Java kód bemutatja, hogyan hozhat létre különböző jelölőkkel ellátott szórt diagramokat: 

```java
// Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Hozzáfér az első diára
    ISlide slide = pres.getSlides().get_Item(0);

    // Létrehozza az alapértelmezett diagramot
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Lekéri az alapértelmezett diagram adat munkalap indexét
    int defaultWorksheetIndex = 0;
    
    // Lekéri a diagram adat munkalapját
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Törli a bemutató sorozatot
    chart.getChartData().getSeries().clear();
    
    // Új sorozatokat ad hozzá
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Kiválasztja az első diagram sorozatot
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Új pontot (1:3) ad a sorozathoz
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Új pontot (2:10) ad hozzá
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Módosítja a sorozat típusát
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Módosítja a diagram sorozat jelölőjét
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Kiválasztja a második diagram sorozatot
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Új pontot (5:2) ad hozzá
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Új pontot (3:1) ad hozzá
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Új pontot (2:2) ad hozzá
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Új pontot (5:1) ad hozzá
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Módosítja a diagram sorozat jelölőjét
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Kördiagramok létrehozása**

A kördiagramok leginkább a rész‑egész arány bemutatására alkalmasak, különösen akkor, ha az adat kategóriákat tartalmaz numerikus értékekkel. Ha azonban az adatok sok részt vagy címkét tartalmaznak, érdemes inkább oszlopdiagramot használni.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Lépések:</em> Kördiagram létrehozása Java-ban</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Lépések:</em> PowerPoint kördiagram létrejezása Java-ban</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Lépések:</em> PowerPoint prezentáció kördiagram létrejezása Java-ban</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal (ebben az esetben a [ChartType].Pie).  
4. Érje el a diagram adat [IChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataWorkbook).  
5. Törölje az alapértelmezett sorozatokat és kategóriákat.  
6. Adjon hozzá új sorozatokat és kategóriákat.  
7. Adjon hozzá új diagramadatot a diagram sorozathoz.  
8. Adjon hozzá új pontokat a diagramhoz, és egyedi színeket a kördiagram szektoraihoz.  
9. Állítsa be a sorozatok címkéit.  
10. Állítson be vezetővonalakat a sorozatelimékezetekhez.  
11. Állítsa be a forgatás szöget a kördiagram diákhoz.  
12. Írja a módosított bemutatót PPTX fájlba.  

```java
// Példányosít egy prezentáció osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Hozzáfér az első diára
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Hozzáad egy diagramot az alapértelmezett adatokkal
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Beállítja a diagram címét
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Beállítja az első sorozatot, hogy megjelenítse az értékeket
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Beállítja a diagram adatlapjának indexét
    int defaultWorksheetIndex = 0;
    
    // Lekéri a diagram adat munkalapját
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Törli az alapértelmezett generált sorozatokat és kategóriákat
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Új kategóriákat ad hozzá
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Új sorozatokat ad hozzá
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Sorozat adatait tölt fel
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
    
    // Egyéni címkéket hoz létre minden kategóriához az új sorozathoz
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
    
    // Beállítja a kördiagram szektorok forgatásszögét
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Elmenti a prezentációt diagrammal
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven vonalgráfok) leginkább akkor alkalmasak, ha az értékek időbeli változását szeretné bemutatni. Vonaldiagram segítségével egyszerre több adatot hasonlíthat össze, nyomon követheti az időbeli változásokat és trendeket, kiemelheti az adat sorozatok anomáliáit stb.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal (ebben az esetben a `ChartType.Line`).  
4. Érje el a diagram adat IChartDataWorkbook.  
5. Törölje az alapértelmezett sorozatokat és kategóriákat.  
6. Adjon hozzá új sorozatokat és kategóriákat.  
7. Adjon hozzá új diagramadatot a diagram sorozathoz.  
8. Írja a módosított bemutatót PPTX fájlba  

```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Alapértelmezés szerint a vonaldiagram pontjai egyenes, folytonos vonallal vannak összekötve. Ha szeretné, hogy a pontok pontvonalak helyett szaggatott vonallal legyenek összekötve, a kívánt szaggatottsági típust a következő módon adhatja meg:  

```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```

### **Fa térkép diagramok létrehozása**

A fa térkép diagramok leginkább értékesítési adatokhoz alkalmasak, amikor a kategóriák relatív méretét szeretné megjeleníteni, és egyben gyorsan felhívni a figyelmet a nagy hozzájáruló elemekre.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Lépések:</em> Fa térkép diagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Lépések:</em> PowerPoint fa térkép diagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Lépések:</em> PowerPoint prezentáció fa térkép diagram létrejezése Java-ban</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal (ebben az esetben a [ChartType].TreeMap).  
4. Érje el a diagram adat [IChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataWorkbook).  
5. Törölje az alapértelmezett sorozatokat és kategóriákat.  
6. Adjon hozzá új sorozatokat és kategóriákat.  
7. Adjon hozzá új diagramadatot a diagram sorozathoz.  
8. Írja a módosított bemutatót PPTX fájlba  

```java
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

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Lépések:</em> Részvénydiagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Lépések:</em> PowerPoint részvénydiagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Lépések:</em> PowerPoint prezentáció részvénydiagram létrejezése Java-ban</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal ([ChartType].OpenHighLowClose).  
4. Érje el a diagram adat [IChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataWorkbook).  
5. Törölje az alapértelmezett sorozatokat és kategóriákat.  
6. Adjon hozzá új sorozatokat és kategóriákat.  
7. Adjon hozzá új diagramadatot a diagram sorozathoz.  
8. Adja meg a HiLowLines formátumot.  
9. Írja a módosított bemutatót PPTX fájlba  

```java
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

### **Doboz- és szárnydiagramok létrehozása**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Lépések:</em> Doboz- és szárnydiagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Lépések:</em> PowerPoint doboz- és szárnydiagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Lépések:</em> PowerPoint prezentáció doboz- és szárnydiagram létrejezése Java-ban</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal ([ChartType].BoxAndWhisker).  
4. Érje el a diagram adat [IChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataWorkbook).  
5. Törölje az alapértelmezett sorozatokat és kategóriákat.  
6. Adjon hozzá új sorozatokat és kategóriákat.  
7. Adjon hozzá új diagramadatot a diagram sorozathoz.  
8. Írja a módosított bemutatót PPTX fájlba  

```java
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

### **Tölcsérdiagramok létrehozása**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Lépések:</em> Tölcsérdiagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Lépések:</em> PowerPoint tölcsérdiagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Lépések:</em> PowerPoint prezentáció tölcsérdiagram létrejezése Java-ban</strong></a>


1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal ([ChartType].Funnel).  
4. Írja a módosított bemutatót PPTX fájlba  

A Java kód mutatja, hogyan hozható létre egy tölcsérdiagram:  

```java
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

### **Sugárdiagramok létrehozása**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Lépések:</em> Sugárdiagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Lépések:</em> PowerPoint sugárdiagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Lépések:</em> PowerPoint prezentáció sugárdiagram létrejezése Java-ban</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal (ebben az esetben a [ChartType].sunburst).  
4. Írja a módosított bemutatót PPTX fájlba  

Ez a Java kód mutatja, hogyan hozható létre egy sugárdiagram:  

```java
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

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Lépések:</em> Hisztogram diagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Lépések:</em> PowerPoint hisztogram diagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Lépések:</em> PowerPoint prezentáció hisztogram diagram létrejezése Java-ban</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal ([ChartType].Histogram).  
4. Érje el a diagram adat [IChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataWorkbook).  
5. Törölje az alapértelmezett sorozatokat és kategóriákat.  
6. Adjon hozzá új sorozatokat és kategóriákat.  
7. Írja a módosított bemutatót PPTX fájlba  

Ez a Java kód mutatja, hogyan hozható létre egy hisztogram diagram:  

```java
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

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic;)

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Radar diagramok létrehozása**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Lépések:</em> Radar diagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Lépések:</em> PowerPoint radar diagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Lépések:</em> PowerPoint prezentáció radar diagram létrejezése Java-ban</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy diagramot némi adattal, és adja meg a kívánt diagramtípust (`ChartType.Radar` ebben az esetben).  
4. Írja a módosított bemutatót PPTX fájlba  

Ez a Java kód mutatja, hogyan hozható létre egy radar diagram:  

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Többkategóriás diagramok létrehozása**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Lépések:</em> Többkategóriás diagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Lépések:</em> PowerPoint többkategóriás diagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Lépések:</em> PowerPoint prezentáció többkategóriás diagram létrejezése Java-ban</strong></a>

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal ([ChartType].ClusteredColumn).  
4. Érje el a diagram adat [IChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataWorkbook).  
5. Törölje az alapértelmezett sorozatokat és kategóriákat.  
6. Adjon hozzá új sorozatokat és kategóriákat.  
7. Adjon hozzá új diagramadatot a diagram sorozathoz.  
8. Írja a módosított bemutatót PPTX fájlba.  

Ez a Java kód mutatja, hogyan hozható létre egy többkategóriás diagram:  

```java
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

### **Térképdiagramok létrehozása**

A térképdiagram egy adott terület adatainak vizualizációja. A térképdiagramok leginkább adat vagy értékek összehasonlítására alkalmasak földrajzi régiók között.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Lépések:</em> Térképdiagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Lépések:</em> PowerPoint térképdiagram létrejezése Java-ban</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Lépések:</em> PowerPoint prezentáció térképdiagram létrejezése Java-ban</strong></a>

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Kombinációs diagramok létrehozása**

A kombinációs diagram (vagy combo diagram) két vagy több diagramtípust egyesít egyetlen grafikonon. Ez a diagram lehetővé teszi, hogy kiemelje, összehasonlítsa vagy megvizsgálja a két vagy több adatkészlet közötti különbségeket, segítve a köztük lévő kapcsolatok azonosítását.

![The combination chart](combination_chart.png)

Az alábbi Java kód mutatja, hogyan hozható létre a fenti kombinációs diagram egy PowerPoint prezentációban:  

```java
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

    // Új kategóriák hozzáadása.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Az első sorozat hozzáadása.
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Lépések:</em> PowerPoint diagram frissítése Java-ban</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Lépések:</em> Prezentáció diagram frissítése Java-ban</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Lépések:</em> PowerPoint prezentáció diagram frissítése Java-ban</strong></a>

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztály példányt, amely a frissíteni kívánt diagramot tartalmazó bemutatót képviseli.  
2. Szerezze meg egy dia referenciaját az indexének használatával.  
3. Futassa végig az összes alakzatot a kívánt diagram megtalálásához.  
4. Érje el a diagram adat munkalapját.  
5. Módosítsa a diagram sorozat adatokat a sorozat értékek megváltoztatásával.  
6. Adjon hozzá egy új sorozatot és töltse fel az adatokat.  
7. Írja a módosított bemutatót PPTX fájlba.  

```java
Presentation pres = new Presentation();
try {
    // Első dia elérése
    ISlide sld = pres.getSlides().get_Item(0);

    // Alapértelmezett adatokkal rendelkező diagram lekérése
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Diagram adatlap indexének beállítása
    int defaultWorksheetIndex = 0;

    // Diagram adat munkalapjának lekérése
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Diagram kategória nevének módosítása
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Első diagram sorozat lekérése
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Sorozat adatainak frissítése
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Sorozat nevének módosítása
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Második diagram sorozat lekérése
    series = chart.getChartData().getSeries().get_Item(1);

    // Sorozat adatainak frissítése
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Sorozat nevének módosítása
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Új sorozat hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Harmadik diagram sorozat lekérése
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

## **Adattartomány beállítása egy diagramhoz**

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztály példányt, amely a diagramot tartalmazó bemutatót képviseli.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Futassa végig az összes alakzatot a kívánt diagram megtalálásához.  
4. Érje el a diagram adatokat és állítsa be a tartományt.  
5. Mentse a módosított bemutatót PPTX fájlként.  

```java
Presentation pres = new Presentation();
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

Amikor alapértelmezett jelölőt használ diagramokban, minden diagram sorozat automatikusan különböző alapértelmezett jelölőszimbólumot kap.  

```java
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
    //Második diagram sorozat lekérése
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    //Most töltjük fel a sorozat adatait
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

Az Aspose.Slides számos [diagramtípust](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/) támogat, beleértve az oszlop, vonal, kör, terület, szórt, hisztogram, radar és még sok más típusát. Ez a rugalmasság lehetővé teszi, hogy az adataik vizualizálásához a legmegfelelőbb diagramtípust válassza.

**Hogyan adhatok hozzá új diagramot egy diára?**

A diagram hozzáadásához először hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály példányt, szerezze meg a kívánt diát az indexe alapján, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagramtípust és a kezdeti adatokat. Ez a folyamat közvetlenül a diagramot integrálja a bemutatóba.

**Hogyan frissíthetem egy diagramon megjelenített adatokat?**

A diagram adatait a diagram adat munkafüzetének ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/)) elérésével frissítheti, törölheti az alapértelmezett sorozatokat és kategóriákat, majd hozzáadhatja saját egyedi adatait. Ez lehetővé teszi a diagram frissítését a legújabb adatokkal.

**Lehetőség van a diagram megjelenésének testreszabására?**

Igen, az Aspose.Slides kiterjedt testreszabási lehetőségeket kínál. Színeket, betűtípusokat, címkéket, jelmagyarázatokat és egyéb [formázási elemeket](/slides/hu/java/chart-entities/) módosíthat a diagram megjelenésének a konkrét tervezési követelmények szerint történő beállításához.