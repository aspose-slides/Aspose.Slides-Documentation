---
title: Skapa eller uppdatera PowerPoint‑presentation‑diagram i Java
linktitle: Skapa eller uppdatera diagram
type: docs
weight: 10
url: /sv/java/create-chart/
keywords:
- lägga till diagram
- skapa diagram
- redigera diagram
- ändra diagram
- uppdatera diagram
- spridningsdiagram
- cirkeldiagram
- linjediagram
- trädkartsdiagram
- aktiediagram
- låda‑och‑vispeldiagram
- tratt‑diagram
- sol‑burst‑diagram
- histogramdiagram
- radardiagram
- flerkategori‑diagram
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Skapa och anpassa diagram i PowerPoint‑presentationer med Aspose.Slides för Java. Lägg till, formatera och redigera diagram med praktiska kodexempel i Java."
---
## **Översikt**

Den här artikeln ger en omfattande guide om hur du skapar och anpassar diagram med Aspose.Slides. Du lär dig hur du programatiskt lägger till ett diagram på en bild, fyller det med data och tillämpar olika formateringsalternativ för att matcha dina specifika designkrav. Genom artikeln illustreras varje steg med detaljerade kodexempel, från initiering av presentationen och diagramobjektet till konfigurering av serier, axlar och förklaringar. Genom att följa guiden får du en solid förståelse för hur du integrerar dynamisk diagramgenerering i dina applika­tioner och förenklar processen att skapa datadrivna presentationer.

## **Skapa diagram**
Diagram hjälper människor att snabbt visualisera data och få insikter som kanske inte är omedelbart uppenbara från en tabell eller ett kalkylblad. 


**Varför skapa diagram?**

Genom att använda diagram får du

* samla, komprimera eller sammanfatta stora mängder data på en enda bild i en presentation
* avslöja mönster och trender i data
* dra slutsatser om riktning och momentum för data över tid eller i förhållande till en specifik mätenhet 
* upptäcka avvikelser, fel, nonsensdata osv. 
* kommunicera eller presentera komplex data

I PowerPoint kan du skapa diagram via infogningsfunktionen, som erbjuder mallar för att designa många diagramtyper. Med Aspose.Slides kan du skapa vanliga diagram (baserade på populära diagramtyper) och anpassade diagram. 

{{% alert color="primary" %}} 

För att låta dig skapa diagram tillhandahåller Aspose.Slides klassen [ChartType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ChartType). Fälten under denna klass motsvarar olika diagramtyper. 

{{% /alert %}} 

### **Skapa vanliga diagram**

_Steg: Skapa diagram_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Steg:</em> Skapa PowerPoint-diagram i Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Steg:</em> Skapa presentations‑diagram i Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Steg:</em> Skapa PowerPoint‑presentations‑diagram i Java</strong></a>

_Kodsteg:_

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med någon data och ange önskad diagramtyp. 
4. Lägg till en titel för diagrammet. 
5. Åtkom diagrammets datablad. 
6. Rensa alla standardserier och -kategorier. 
7. Lägg till nya serier och kategorier. 
8. Lägg till ny diagramdata för diagramserierna. 
9. Lägg till en fyllnadsfärg för diagramserierna. 
10. Lägg till etiketter för diagramserierna. 
11. Skriv den ändrade presentationen som en PPTX‑fil. 

Denna Java‑kod visar hur du skapar ett vanligt diagram:

```java
// Instansierar en presentationsklass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Åtkommer den första bilden
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Lägger till ett diagram med standarddata
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Ställer in diagrammets titel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // Ställer in att den första serien visar värden
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Anger index för diagrammets dataark
    int defaultWorksheetIndex = 0;
    
    // Hämtar diagrammets dataarbetsblad
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Raderar de standardgenererade serierna och kategorierna
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Lägger till nya serier
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Lägger till nya kategorier
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Hämtar den första diagramserien
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Fyller nu i seriesdata
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Ställer in fyllnadsfärgen för serien
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Hämtar den andra diagramserien
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Fyller i seriesdata
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Ställer in fyllnadsfärgen för serien
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Skapa anpassade etiketter för varje kategori för den nya serien
    // Ställer in den första etiketten att visa kategorinamn
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Visar värde för den tredje etiketten
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Sparar presentationen med diagrammet
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Skapa spridningsdiagram**
Spridningsdiagram (även kallade scatter‑plot eller x‑y‑grafer) används ofta för att undersöka mönster eller demonstrera korrelationer mellan två variabler. 

Du kan vilja använda ett spridningsdiagram när 

* du har parade numeriska data
* du har två variabler som passar väl ihop
* du vill avgöra om två variabler är relaterade
* du har en oberoende variabel med flera värden för en beroende variabel

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Steg:</em> Skapa spridningsdiagram i Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Steg:</em> Skapa PowerPoint‑spridningsdiagram i Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Steg:</em> Skapa PowerPoint‑presentations‑spridningsdiagram i Java</strong></a>

1. Följ stegen som nämns ovan i [Create Normal Charts](#creating-normal-charts)
2. För tredje steget, lägg till ett diagram med någon data och ange diagramtypen som en av följande
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/sv/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Representerar ett spridningsdiagram._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/sv/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Representerar ett spridningsdiagram med kurva och datapunkter._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/sv/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Representerar ett spridningsdiagram med kurva utan datapunkter._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/sv/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Representerar ett spridningsdiagram med raka linjer och datapunkter._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/sv/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Representerar ett spridningsdiagram med raka linjer utan datapunkter._

Denna Java‑kod visar hur du skapar spridningsdiagram med olika markeringsserier: 

```java
// Instansierar en presentationsklass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Åtkommer den första bilden
    ISlide slide = pres.getSlides().get_Item(0);

    // Skapar standarddiagrammet
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Hämtar standarddiagrammets dataarbetsbladsindex
    int defaultWorksheetIndex = 0;
    
    // Hämtar diagrammets dataarbetsblad
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Tar bort demonstrationsserierna
    chart.getChartData().getSeries().clear();
    
    // Lägger till nya serier
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Hämtar den första diagramserien
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Lägger till en ny punkt (1:3) i serien
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Lägger till en ny punkt (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Ändrar serietypen
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Ändrar diagramseriens markör
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Hämtar den andra diagramserien
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Lägger till en ny punkt (5:2) där
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Lägger till en ny punkt (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Lägger till en ny punkt (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Lägger till en ny punkt (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Ändrar diagramseriens markör
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Skapa cirkeldiagram**

Cirkeldiagram är bäst för att visa förhållandet del‑till‑helhet i data, särskilt när data innehåller kategoriska etiketter med numeriska värden. Om dina data innehåller många delar eller etiketter kan ett stapeldiagram vara ett bättre alternativ. 

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Steg:</em> Skapa cirkeldiagram i Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Steg:</em> Skapa PowerPoint‑cirkeldiagram i Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Steg:</em> Skapa PowerPoint‑presentations‑cirkeldiagram i Java</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata och önskad typ (i det här fallet [ChartType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ChartType).Pie).
4. Åtkom diagramdatat [IChartDataWorkbook](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartDataWorkbook).
5. Rensa standardserierna och -kategorierna.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Lägg till nya punkter för diagrammet och anpassade färger för cirkelsektorerna.
9. Ställ in etiketter för serierna.
10. Ställ in ledarlinjer för serieetiketter.
11. Ställ in rotationsvinkeln för cirkeldiagramsliden.
12. Spara den ändrade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar ett cirkeldiagram:

```java
// Instansierar en presentationsklass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Åtkommer den första bilden
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Lägger till ett diagram med standarddata
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Ställer in diagrammets titel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Ställer in att den första serien visar värden
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Anger index för diagrammets dataark
    int defaultWorksheetIndex = 0;
    
    // Hämtar diagrammets dataarbetsblad
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Tar bort de standardgenererade serierna och kategorierna
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Lägger till nya kategorier
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Lägger till nya serier
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Fyller seriedatan
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Fungerar inte i ny version
    // Lägger till nya punkter och sätter sektorfärg
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Ställer in sektorkanten
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Ställer in sektorkanten
    point1.getFormat().getLine().setFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Ställer in sektorkanten
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Skapar anpassade etiketter för varje kategori för den nya serien
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
    
    // Visar ledarlinjer för diagrammet
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Ställer in rotationsvinkeln för cirkelsektorer
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Sparar presentationen med ett diagram
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Skapa linjediagram**

Linjediagram (även kända som linjediagram) är bäst när du vill demonstrera förändringar i värde över tid. Med ett linjediagram kan du jämföra mycket data samtidigt, spåra förändringar och trender över tid, markera avvikelser i dataserier osv.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata och önskad typ (i det här fallet `ChartType.Line`).
1. Åtkom diagramdatat IChartDataWorkbook.
1. Rensa standardserierna och -kategorierna.
1. Lägg till nya serier och kategorier.
1. Lägg till ny diagramdata för diagramserierna.
1. Spara den ändrade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar ett linjediagram:

```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Som standard är punkterna i ett linjediagram förenade med raka kontinuerliga linjer. Om du vill att punkterna ska förenas med streck kan du ange önskad strecktyp så här:

```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```

### **Skapa trädkartsdiagram**

Trädkartsdiagram är bäst för försäljningsdata när du vill visa den relativa storleken på datakategorier och samtidigt snabbt dra uppmärksamhet till de poster som bidrar mest till varje kategori. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Steg:</em> Skapa trädkartsdiagram i Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Steg:</em> Skapa PowerPoint‑trädkartsdiagram i Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Steg:</em> Skapa PowerPoint‑presentations‑trädkartsdiagram i Java</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata och önskad typ (i det här fallet [ChartType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ChartType).TreeMap).
4. Åtkom diagramdatat [IChartDataWorkbook](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartDataWorkbook).
5. Rensa standardserierna och -kategorierna.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Spara den ändrade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar ett trädkartsdiagram:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //gren 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //gren 2
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

### **Skapa aktiediagram**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Steg:</em> Skapa aktiediagram i Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Steg:</em> Skapa PowerPoint‑aktiediagram i Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Steg:</em> Skapa PowerPoint‑presentations‑aktiediagram i Java</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata och önskad typ ([ChartType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ChartType).OpenHighLowClose).
4. Åtkom diagramdatat [IChartDataWorkbook](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartDataWorkbook).
5. Rensa standardserierna och -kategorierna.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Specificera HiLowLines‑format.
9. Spara den ändrade presentationen som en PPTX‑fil.

Exempel på Java‑kod som skapar ett aktiediagram:

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

### **Skapa låda‑och‑vispeldiagram**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Steg:</em> Skapa låda‑och‑vispeldiagram i Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Steg:</em> Skapa PowerPoint‑låda‑och‑vispeldiagram i Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Steg:</em> Skapa PowerPoint‑presentations‑låda‑och‑vispeldiagram i Java</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata och önskad typ ([ChartType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ChartType).BoxAndWhisker).
4. Åtkom diagramdatat [IChartDataWorkbook](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartDataWorkbook).
5. Rensa standardserierna och -kategorierna.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Spara den ändrade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar ett låda‑och‑vispeldiagram:

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

### **Skapa tratt‑diagram**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Steg:</em> Skapa tratt‑diagram i Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Steg:</em> Skapa PowerPoint‑tratt‑diagram i Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Steg:</em> Skapa PowerPoint‑presentations‑tratt‑diagram i Java</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata och önskad typ ([ChartType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ChartType).Funnel).
4. Spara den ändrade presentationen som en PPTX‑fil.

Java‑koden visar hur du skapar ett tratt‑diagram:

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

### **Skapa sol‑klares diagram**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Steg:</em> Skapa sol‑klar‑diagram i Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Steg:</em> Skapa PowerPoint‑sol‑klar‑diagram i Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Steg:</em> Skapa PowerPoint‑presentations‑sol‑klar‑diagram i Java</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata och önskad typ (i det här fallet [ChartType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ChartType).sunburst).
4. Spara den ändrade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar ett sol‑klar‑diagram:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //gren 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //gren 2
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

### **Skapa histogram‑diagram**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Steg:</em> Skapa histogram‑diagram i Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Steg:</em> Skapa PowerPoint‑histogram‑diagram i Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Steg:</em> Skapa PowerPoint‑presentations‑histogram‑diagram i Java</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata och önskad typ ([ChartType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ChartType).Histogram).
4. Åtkom diagramdatat [IChartDataWorkbook](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartDataWorkbook).
5. Rensa standardserierna och -kategorierna.
6. Lägg till nya serier och kategorier.
7. Spara den ändrade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar ett histogram‑diagram:

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

### **Skapa radardiagram**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Steg:</em> Skapa radardiagram i Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Steg:</em> Skapa PowerPoint‑radardiagram i Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Steg:</em> Skapa PowerPoint‑presentations‑radardiagram i Java</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index. 
3. Lägg till ett diagram med någon data och ange önskad diagramtyp (`ChartType.Radar` i detta fall).
4. Spara den ändrade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar ett radardiagram:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Skapa flerkategori‑diagram**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Steg:</em> Skapa flerkategori‑diagram i Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Steg:</em> Skapa PowerPoint‑flerkategori‑diagram i Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Steg:</em> Skapa PowerPoint‑presentations‑flerkategori‑diagram i Java</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en bilds referens via dess index. 
3. Lägg till ett diagram med standarddata och önskad typ ([ChartType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ChartType).ClusteredColumn).
4. Åtkom diagramdatat [IChartDataWorkbook](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartDataWorkbook).
5. Rensa standardserierna och -kategorierna.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Spara den ändrade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du skapar ett flerkategori‑diagram:

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

    // Lägger till serier
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
    
    // Spara presentation med diagram
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Skapa kartdiagram**

Ett kartdiagram är en visualisering av ett område som innehåller data. Kartdiagram är bäst för att jämföra data eller värden över geografiska regioner.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Steg:</em> Skapa kartdiagram i Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Steg:</em> Skapa PowerPoint‑kartdiagram i Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Steg:</em> Skapa PowerPoint‑presentations‑kartdiagram i Java</strong></a>

Denna Java‑kod visar hur du skapar ett kartdiagram:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Skapa kombinationsdiagram**

Ett kombinationsdiagram (eller combo‑diagram) kombinerar två eller fler diagramtyper i ett enda diagram. Detta diagram låter dig lyfta fram, jämföra eller undersöka skillnader mellan två eller fler datamängder, vilket hjälper dig att identifiera relationer mellan dem.

![The combination chart](combination_chart.png)

Följande Java‑kod visar hur du skapar kombinationsdiagrammet som visas ovan i en PowerPoint‑presentation:

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

    // Ställ in diagrammets titel.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Ställ in diagrammets förklaring.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Ta bort de standardgenererade serierna och kategorierna.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Lägg till nya kategorier.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Lägg till den första serien.
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
    // Ställ in den horisontella axeln.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Ställ in den vertikala axeln.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Ställ in färgen på de vertikala huvudgridlinjerna.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Ställ in den sekundära horisontella axeln.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Ställ in den sekundära vertikala axeln.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().setFillType(FillType.NoFill);
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

## **Uppdatera diagram**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Steg:</em> Uppdatera PowerPoint‑diagram i Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Steg:</em> Uppdatera presentations‑diagram i Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Steg:</em> Uppdatera PowerPoint‑presentations‑diagram i Java</strong></a>

1. Instansiera en [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)-klass som representerar presentationen som innehåller diagrammet du vill uppdatera. 
2. Hämta referensen till en bild genom att använda dess index.
3. Gå igenom alla former för att hitta det önskade diagrammet.
4. Åtkom diagramdatats kalkylblad.
5. Ändra diagramseriens data genom att ändra serievärden.
6. Lägg till en ny serie och fyll i data i den.
7. Spara den ändrade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du uppdaterar ett diagram:

```java
Presentation pres = new Presentation();
try {
    // Åtkomst till första bildmarkören
    ISlide sld = pres.getSlides().get_Item(0);

    // Hämta diagram med standarddata
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Anger index för diagrammets dataark
    int defaultWorksheetIndex = 0;

    // Hämtar diagrammets dataarbetsblad
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Ändrar diagrammets kategorinamn
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Hämtar första diagramserien
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Uppdaterar nu seriedatan
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Modifierar serienamn
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Hämtar andra diagramserien
    series = chart.getChartData().getSeries().get_Item(1);

    // Uppdaterar nu seriedatan
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Modifierar serienamn
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Lägger nu till en ny serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Hämtar tredje diagramserien
    series = chart.getChartData().getSeries().get_Item(2);

    // Fyller nu i seriedatan
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Sparar presentation med diagram
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange dataområde för ett diagram**

För att ange dataområde för ett diagram gör du så här:

1. Instansiera en [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)-klass som representerar presentationen som innehåller diagrammet.
2. Hämta en bilds referens via dess index.
3. Gå igenom alla former för att hitta det önskade diagrammet.
4. Åtkom diagramdatat och ange intervallet.
5. Spara den ändrade presentationen som en PPTX‑fil.

Denna Java‑kod visar hur du anger dataområde för ett diagram:

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

## **Använd standardmarkörer i diagram**
När du använder en standardmarkör i diagram får varje diagramserie automatiskt en annan standardmarkörsymbol.

Denna Java‑kod visar hur du automatiskt anger en diagramserie‑markör:

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
    //Ta den andra diagramserien
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    //Nu fyller vi seriedata
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

## **FAQ**

**Vilka diagramtyper stöds av Aspose.Slides?**

Aspose.Slides stöder ett brett sortiment av [chart types](https://reference.aspose.com/slides/sv/java/com.aspose.slides/charttype/), inklusive stapel, linje, cirkel, area, spridning, histogram, radar och många fler. Denna flexibilitet låter dig välja den mest lämpliga diagramtypen för dina datavisualiseringsbehov.

**Hur lägger jag till ett nytt diagram på en bild?**

För att lägga till ett diagram skapar du först en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/), hämtar önskad bild med dess index och anropar sedan metoden för att lägga till ett diagram, där du anger diagramtyp och initial data. Detta integrerar diagrammet direkt i din presentation.

**Hur kan jag uppdatera data som visas i ett diagram?**

Du kan uppdatera ett diagrams data genom att åtkomma dess datarbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdataworkbook/)), rensa eventuella standardserier och -kategorier och sedan lägga till dina egna data. Detta gör att du kan uppdatera diagrammet så att det speglar de senaste data.

**Är det möjligt att anpassa diagrammets utseende?**

Ja, Aspose.Slides erbjuder omfattande anpassningsmöjligheter. Du kan ändra färger, typsnitt, etiketter, förklaringar och andra [formatting elements](/slides/sv/java/chart-entities/) för att skräddarsy diagrammets utseende efter dina specifika designkrav.