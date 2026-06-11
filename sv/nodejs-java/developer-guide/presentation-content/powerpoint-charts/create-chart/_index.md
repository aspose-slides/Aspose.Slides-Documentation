---
title: Skapa eller uppdatera diagram i PowerPoint-presentationer med JavaScript
linktitle: Skapa eller uppdatera diagram
type: docs
weight: 10
url: /sv/nodejs-java/create-chart/
keywords:
- lägga till diagram
- skapa diagram
- redigera diagram
- ändra diagram
- uppdatera diagram
- spritt diagram
- pajdiagram
- linjediagram
- trädkartsdiagram
- aktiediagram
- låda- och whisker-diagram
- tratt-diagram
- soluppgångs-diagram
- histogramdiagram
- radardiagram
- multi-kategori-diagram
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa och anpassa diagram i PowerPoint-presentationer med Aspose.Slides för Node.js. Lägg till, formatera och redigera diagram med praktiska kodexempel i JavaScript."
---
## **Översikt**

Denna artikel ger en omfattande guide om hur du skapar och anpassar diagram med Aspose.Slides. Du får lära dig hur du programatiskt lägger till ett diagram på en bild, fyller det med data och tillämpar olika formateringsalternativ för att matcha dina specifika designkrav. Genom hela artikeln illustrerar detaljerade kodexempel varje steg, från initiering av presentationen och diagramobjektet till konfigurering av serier, axlar och förklaringar. Genom att följa denna guide får du en solid förståelse för hur du integrerar dynamisk diagramgenerering i dina applikationer, vilket förenklar processen att skapa datadrivna presentationer.

## **Skapa diagram**
Diagram hjälper personer att snabbt visualisera data och få insikter, vilket kanske inte är omedelbart uppenbart från en tabell eller kalkylblad. 


**Varför skapa diagram?**

Genom diagram får du

* samla, komprimera eller sammanfatta stora mängder data på en enda bild i en presentation
* avslöja mönster och trender i data
* avgöra riktning och dynamik i data över tid eller i förhållande till en specifik enhet
* upptäcker avvikande värden, avvikelser, fel, meningslösa data osv. 
* kommunicera eller presentera komplex data

I PowerPoint kan du skapa diagram via infogningsfunktionen, som erbjuder mallar för att designa många typer av diagram. Med Aspose.Slides kan du skapa vanliga diagram (baserade på populära diagramtyper) och anpassade diagram. 

{{% alert color="primary" %}} 

För att låta dig skapa diagram tillhandahåller Aspose.Slides klassen [ChartType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartType). Fälten under denna klass motsvarar olika diagramtyper.

{{% /alert %}} 

### **Skapa vanliga diagram**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Steg:</em> Skapa PowerPoint-diagram i JavaScript</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Steg:</em> Skapa Presentation-diagram i JavaScript</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation-diagram i JavaScript</strong></a>

_Code Steps:_

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med vissa data och ange önskad diagramtyp. 
4. Lägg till en titel för diagrammet. 
5. Åtkomst till diagrammets dataarbetsblad.
6. Rensa alla standardserier och -kategorier.
7. Lägg till nya serier och kategorier.
8. Lägg till ny diagramdata för diagramserierna.
9. Lägg till en fyllningsfärg för diagramserier.
10. Lägg till etiketter för diagramserier. 
11. Spara den modifierade presentationen som en PPTX-fil.

Denna JavaScript‑kod visar hur du skapar ett vanligt diagram:

```javascript
// Instansierar en presentationsklass som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Lägger till ett diagram med dess standarddata
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Ställer in diagrammets titel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // Ställer in att den första serien ska visa värden
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Ställer in indexet för diagrammets datasheet
    var defaultWorksheetIndex = 0;
    // Hämtar diagrammets dataarbetsblad
    var fact = chart.getChartData().getChartDataWorkbook();
    // Tar bort de standardgenererade serierna och kategorierna
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Lägger till nya serier
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Lägger till nya kategorier
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Tar den första diagramserien
    var series = chart.getChartData().getSeries().get_Item(0);
    // Populerar nu seriedatan
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Ställer in fyllningsfärgen för serien
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Tar den andra diagramserien
    series = chart.getChartData().getSeries().get_Item(1);
    // Populerar seriedata
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Ställer in fyllningsfärgen för serien
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Skapa anpassade etiketter för varje kategori för den nya serien
    // Ställer in att den första etiketten ska visa kategorinamn
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Visar värde för den tredje etiketten
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Sparar presentationen med diagram
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Skapa spridda diagram**
Spridda diagram (även kända som spridningsdiagram eller x‑y‑grafer) används ofta för att kontrollera mönster eller demonstrera korrelationer mellan två variabler. 

Du kan vilja använda ett spritt diagram när 

* du har parade numeriska data
* du har två variabler som passar bra ihop
* du vill avgöra om två variabler är relaterade
* du har en oberoende variabel som har flera värden för en beroende variabel

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Steg:</em> Skapa spritt diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Steg:</em> Skapa PowerPoint spritt diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation spritt diagram i JavaScript</strong></a>

1. Följ stegen som nämns ovan i [Creating Normal Charts](#creating-normal-charts)
2. För tredje steget, lägg till ett diagram med någon data och ange din diagramtyp som en av följande
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Representerar spridd diagram._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Representerar spridd diagram anslutet med kurvor, med datamarkörer._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Representerar spridd diagram anslutet med kurvor, utan datamarkörer._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Representerar spridd diagram anslutet med linjer, med datamarkörer._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Representerar spridd diagram anslutet med linjer, utan datamarkörer._

Denna JavaScript‑kod visar hur du skapar spridda diagram med olika markörserier:

```javascript
// Instansierar en presentationsklass som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    var slide = pres.getSlides().get_Item(0);
    // Skapar standarddiagrammet
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Hämtar index för standarddiagrammets dataarbetsblad
    var defaultWorksheetIndex = 0;
    // Hämtar diagrammets dataarbetsblad
    var fact = chart.getChartData().getChartDataWorkbook();
    // Tar bort demonstrationsserien
    chart.getChartData().getSeries().clear();
    // Lägger till nya serier
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Tar den första diagramserien
    var series = chart.getChartData().getSeries().get_Item(0);
    // Lägger till en ny punkt (1:3) till serien
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Lägger till en ny punkt (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Ändrar serietypen
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Ändrar diagramseriens markör
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Tar den andra diagramserien
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
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Skapa pajdiagram**

Pajdiagram är bäst för att visa förhållandet del‑till‑helhet i data, särskilt när data innehåller kategoriska etiketter med numeriska värden. Om dina data innehåller många delar eller etiketter kan du överväga att använda ett stapeldiagram istället.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Steg:</em> Skapa pajdiagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Steg:</em> Skapa PowerPoint pajdiagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation pajdiagram i JavaScript</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata samt önskad typ (i detta fall, [ChartType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartType).Pie).
4. Åtkomst till diagramdata [ChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Rensa standardserier och -kategorier.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Lägg till nya punkter för diagrammen och anpassa färger för pajdiagrammets sektorer.
9. Ställ in etiketter för serierna.
10. Ställ in ledarlinjer för serieetiketter.
11. Ställ in rotationsvinkeln för pajdiagrammets bilder.
12. Spara den modifierade presentationen som en PPTX‑fil

Denna JavaScript‑kod visar hur du skapar ett pajdiagram:

```javascript
// Instansierar en presentationsklass som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    var slides = pres.getSlides().get_Item(0);
    // Lägger till ett diagram med standarddata
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Ställer in diagrammets titel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Ställer in att den första serien ska visa värden
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Ställer in indexet för diagrammets dataark
    var defaultWorksheetIndex = 0;
    // Hämtar diagrammets dataarbetsblad
    var fact = chart.getChartData().getChartDataWorkbook();
    // Tar bort de standardgenererade serierna och kategorierna
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Lägger till nya kategorier
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Lägger till ny serie
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Fyller på seriedata
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Fungerar inte i den nya versionen
    // Lägger till nya punkter och anger sektionsfärg
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Ställer in sektionsramen
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Ställer in sektionsramen
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Ställer in sektionsramen
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // Skapar anpassade etiketter för varje kategori för den nya serien
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
    // Visar ledarlinjer för diagrammet
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Ställer in rotationsvinkeln för pajdiagrammets sektorer
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Sparar presentationen med ett diagram
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Skapa linjediagram**

Linjediagram (även kända som linjediagram) är bäst när du vill demonstrera förändringar i värde över tid. Med ett linjediagram kan du jämföra mycket data på en gång, spåra förändringar och trender över tid, markera anomalier i dataserier osv.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata samt önskad typ (i detta fall, `ChartType.Line`).
1. Åtkomst till diagramdata IChartDataWorkbook.
1. Rensa standardserier och -kategorier.
1. Lägg till nya serier och kategorier.
1. Lägg till ny diagramdata för diagramserierna.
1. Spara den modifierade presentationen som en PPTX‑fil

Denna JavaScript‑kod visar hur du skapar ett linjediagram:

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

Som standard är punkterna i ett linjediagram förenade med raka kontinuerliga linjer. Om du vill att punkterna ska förenas med streck istället kan du ange önskad strecktyp så här:

```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```

### **Skapa trädkartsdiagram**

Trädkartsdiagram är bäst för försäljningsdata när du vill visa den relativa storleken på datakategorier och samtidigt snabbt rikta uppmärksamheten mot objekt som är stora bidragsgivare till varje kategori. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Steg:</em> Skapa trädkartsdiagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Steg:</em> Skapa PowerPoint trädkartsdiagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation trädkartsdiagram i JavaScript</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) .
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata samt önskad typ (i detta fall, [ChartType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartType).TreeMap).
4. Åtkomst till diagramdata [ChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Rensa standardserier och -kategorier.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Spara den modifierade presentationen som en PPTX‑fil

Denna JavaScript‑kod visar hur du skapar ett trädkartsdiagram:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // gren 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // gren 2
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

### **Skapa aktiediagram**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Steg:</em> Skapa aktiediagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Steg:</em> Skapa PowerPoint aktiediagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation aktiediagram i JavaScript</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) .
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata samt önskad typ ([ChartType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartType).OpenHighLowClose).
4. Åtkomst till diagramdata [ChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Rensa standardserier och -kategorier.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Ange format för HiLowLines.
9. Spara den modifierade presentationen som en PPTX‑fil

Exempel på JavaScript‑kod som skapar ett aktiediagram:

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

### **Skapa låd- och whisker‑diagram**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Steg:</em> Skapa låd- och whisker‑diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Steg:</em> Skapa PowerPoint låd- och whisker‑diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation låd- och whisker‑diagram i JavaScript</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) .
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata samt önskad typ ([ChartType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartType).BoxAndWhisker).
4. Åtkomst till diagramdata [ChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Rensa standardserier och -kategorier.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Spara den modifierade presentationen som en PPTX‑fil

Denna JavaScript‑kod visar hur du skapar ett låd‑ och whisker‑diagram:

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

### **Skapa tratt‑diagram**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Steg:</em> Skapa tratt‑diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Steg:</em> Skapa PowerPoint tratt‑diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation tratt‑diagram i JavaScript</strong></a>


1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) .
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata samt önskad typ ([ChartType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartType).Funnel).
4. Spara den modifierade presentationen som en PPTX‑fil

JavaScript‑koden visar hur du skapar ett tratt‑diagram:

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

### **Skapa soluppgångs‑diagram**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Steg:</em> Skapa soluppgångs‑diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Steg:</em> Skapa PowerPoint soluppgångs‑diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation soluppgångs‑diagram i JavaScript</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) .
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata samt önskad typ (i detta fall,[ChartType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartType).sunburst).
4. Spara den modifierade presentationen som en PPTX‑fil

Denna JavaScript‑kod visar hur du skapar ett soluppgångs‑diagram:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // gren 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // gren 2
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

### **Skapa histogram‑diagram**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Steg:</em> Skapa histogram‑diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Steg:</em> Skapa PowerPoint histogram‑diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation histogram‑diagram i JavaScript</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) .
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata samt önskad typ ([ChartType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartType).Histogram).
4. Åtkomst till diagramdata [ChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Rensa standardserier och -kategorier.
6. Lägg till nya serier och kategorier.
7. Spara den modifierade presentationen som en PPTX‑fil

Denna JavaScript‑kod visar hur du skapar ett histogram‑diagram:

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

### **Skapa radar‑diagram**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Steg:</em> Skapa radar‑diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Steg:</em> Skapa PowerPoint radar‑diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation radar‑diagram i JavaScript</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) .
2. Hämta en bilds referens via dess index. 
3. Lägg till ett diagram med viss data och ange önskad diagramtyp (`ChartType.Radar` i detta fall).
4. Spara den modifierade presentationen som en PPTX‑fil

Denna JavaScript‑kod visar hur du skapar ett radar‑diagram:

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

### **Skapa multi‑kategori‑diagram**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Steg:</em> Skapa multi‑kategori‑diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Steg:</em> Skapa PowerPoint multi‑kategori‑diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation multi‑kategori‑diagram i JavaScript</strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) .
2. Hämta en bilds referens via dess index. 
3. Lägg till ett diagram med standarddata samt önskad typ ([ChartType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartType).ClusteredColumn).
4. Åtkomst till diagramdata [ChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Rensa standardserier och -kategorier.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Spara den modifierade presentationen som en PPTX‑fil.

Denna JavaScript‑kod visar hur du skapar ett multi‑kategori‑diagram:

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
    // Lägger till serier
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Spara presentation med diagram
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Skapa karta‑diagram**

Ett karta‑diagram är en visualisering av ett område som innehåller data. Karta‑diagram är bäst för att jämföra data eller värden över geografiska regioner.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Steg:</em> Skapa karta‑diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Steg:</em> Skapa PowerPoint karta‑diagram i JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation karta‑diagram i JavaScript</strong></a>

Denna JavaScript‑kod visar hur du skapar ett karta‑diagram:

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

### **Skapa kombinations‑diagram**

Ett kombinations‑diagram (eller combo‑diagram) kombinerar två eller fler diagramtyper i ett enda diagram. Detta diagram låter dig framhäva, jämföra eller undersöka skillnader mellan två eller fler dataserier, vilket hjälper dig att identifiera relationer mellan dem.

![The combination chart](combination_chart.png)

Följande JavaScript‑kod visar hur du skapar kombinations‑diagrammet som visas ovan i en PowerPoint‑presentation:

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

    // Ställ in diagrammets titel.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Ställ in diagrammets förklaring.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Ta bort de standardgenererade serierna och kategorierna.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Lägg till nya kategorier.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Lägg till den första serien.
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
    // Ställ in den horisontella axeln.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Ställ in den vertikala axeln.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Ställ in färgen för vertikala huvudnätlinjer.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Ställ in den sekundära horisontella axeln.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Ställ in den sekundära vertikala axeln.
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

## **Uppdatera diagram**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Steg:</em> Uppdatera PowerPoint-diagram i JavaScript</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Steg:</em> Uppdatera Presentation-diagram i JavaScript</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Steg:</em> Uppdatera PowerPoint Presentation-diagram i JavaScript</strong></a>

1. Instansiera en [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)‑klass som representerar presentationen som innehåller diagrammet du vill uppdatera.
2. Hämta referensen till en bild genom att använda dess Index.
3. Gå igenom alla former för att hitta önskat diagram.
4. Åtkomst till diagrammets dataarbetsblad.
5. Ändra diagramseriers data genom att ändra serievärden.
6. Lägg till en ny serie och fyll i data i den.
7. Spara den modifierade presentationen som en PPTX‑fil.

Denna JavaScript‑kod visar hur du uppdaterar ett diagram:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Åtkomst till den första bildmarkören
    var sld = pres.getSlides().get_Item(0);
    // Hämta diagram med standarddata
    var chart = sld.getShapes().get_Item(0);
    // Ställer in index för diagrammets dataark
    var defaultWorksheetIndex = 0;
    // Hämtar diagrammets dataarbetsblad
    var fact = chart.getChartData().getChartDataWorkbook();
    // Ändrar diagrammets kategorinamn
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Ta den första diagramserien
    var series = chart.getChartData().getSeries().get_Item(0);
    // Uppdaterar nu seriedata
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Modifierar serienamn
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Ta den andra diagramserien
    series = chart.getChartData().getSeries().get_Item(1);
    // Uppdaterar nu seriedata
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Modifierar serienamn
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Nu lägger vi till en ny serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Ta den tredje diagramserien
    series = chart.getChartData().getSeries().get_Item(2);
    // Fyller nu i seriedata
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Spara presentation med diagram
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ange dataområde för diagram**

För att ange dataområde för ett diagram, gör så här:

1. Instansiera en [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)‑klass som representerar presentationen som innehåller diagrammet.
2. Hämta en bilds referens via dess index.
3. Gå igenom alla former för att hitta önskat diagram.
4. Åtkomst till diagramdata och ange området.
5. Spara den modifierade presentationen som en PPTX‑fil.

Denna JavaScript‑kod visar hur du anger dataområde för ett diagram:

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

## **Använda standardmarkörer i diagram**
När du använder en standardmarkör i diagram får varje diagramserie automatiskt olika standardmarkörsymboler.

Denna JavaScript‑kod visar hur du automatiskt ställer in en diagramseriemarkör:

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
    // Ta den andra diagramserien
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Nu fyller vi i seriedata
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

## **FAQ**

**Vilka diagramtyper stöds av Aspose.Slides?**

Aspose.Slides stöder ett brett sortiment av diagramtyper, inklusive stapel, linje, paj, område, spridd, histogram, radar och många fler. Denna flexibilitet gör att du kan välja den mest lämpliga diagramtypen för ditt visualiseringsbehov.

**Hur lägger jag till ett nytt diagram på en bild?**

För att lägga till ett diagram skapar du först en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) , hämtar den önskade bilden via dess index och anropar sedan metoden för att lägga till ett diagram, där du specificerar diagramtyp och initial data. Detta integrerar diagrammet direkt i din presentation.

**Hur kan jag uppdatera data som visas i ett diagram?**

Du kan uppdatera ett diagrams data genom att komma åt dess dataarbetsbok ([ChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/)), rensa eventuella standardserier och -kategorier och sedan lägga till dina egna data. Detta gör att du programatiskt kan uppdatera diagrammet så att det speglar den senaste datan.

**Är det möjligt att anpassa diagrammets utseende?**

Ja, Aspose.Slides erbjuder omfattande anpassningsalternativ. Du kan ändra färger, teckensnitt, etiketter, förklaringar och andra formateringselement för att skräddarsy diagrammets utseende efter dina specifika designkrav.