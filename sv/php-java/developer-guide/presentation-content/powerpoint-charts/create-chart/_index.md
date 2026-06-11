---
title: Skapa eller uppdatera PowerPoint-presentationdiagram i PHP
linktitle: Skapa eller uppdatera diagram
type: docs
weight: 10
url: /sv/php-java/create-chart/
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
- börsdiagram
- låda-och-whisker-diagram
- trattdiagram
- solstråle-diagram
- histogramdiagram
- radardiagram
- flerkategoridiagram
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Skapa och anpassa diagram i PowerPoint-presentationer med Aspose.Slides för PHP via Java. Lägg till, formatera och redigera diagram med praktiska kodexempel."
---
## **Översikt**

Den här artikeln ger en omfattande guide om hur du skapar och anpassar diagram med Aspose.Slides. Du kommer att lära dig hur du programatiskt lägger till ett diagram på en bild, fyller det med data och tillämpar olika formateringsalternativ för att matcha dina specifika designkrav. Genom hela artikeln illustrerar detaljerade kodexempel varje steg, från att initiera presentationen och diagramobjektet till att konfigurera serier, axlar och förklaringar. Genom att följa denna guide får du en solid förståelse för hur du integrerar dynamisk diagramgenerering i dina applikationer, vilket effektiviserar processen att skapa datadrivna presentationer.

## **Skapa ett diagram**

Diagram hjälper människor att snabbt visualisera data och få insikter, vilket kanske inte är omedelbart uppenbart från en tabell eller kalkylblad. 

**Varför skapa diagram?**

Genom diagram får du möjlighet att

* sammanfatta, komprimera eller summera stora mängder data på en enda bild i en presentation
* avslöja mönster och trender i data
* sluta dig på riktning och momentum för data över tid eller i förhållande till en specifik mätenhet 
* upptäcker avvikande värden, avvikelser, fel, nonsensisk data etc. 
* kommunicera eller presentera komplex data

I PowerPoint kan du skapa diagram via infogningsfunktionen, som tillhandahåller mallar för att designa många typer av diagram. Med Aspose.Slides kan du skapa vanliga diagram (baserade på populära diagramtyper) och anpassade diagram. 

{{% alert color="primary" %}} 

För att du ska kunna skapa diagram tillhandahåller Aspose.Slides klassen [ChartType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ChartType) . Fälten under den här klassen motsvarar olika diagramtyper.

{{% /alert %}} 

### **Skapa vanliga diagram**

_Steg: Skapa diagram_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Steg:</em> Skapa PowerPoint-diagram </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Steg:</em> Skapa Presentation-diagram </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation-diagram </strong></a>

_Kodsteg:_

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) .
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med viss data och ange din föredragna diagramtyp. 
4. Lägg till en titel för diagrammet. 
5. Kom åt diagrammets dataarbetsblad.
6. Rensa alla standardserier och -kategorier.
7. Lägg till nya serier och kategorier.
8. Lägg till ny diagramdata för diagramserierna.
9. Lägg till en fyllningsfärg för diagramserierna.
10. Lägg till etiketter för diagramserierna. 
11. Spara den modifierade presentationen som en PPTX-fil.

Den här PHP-koden visar hur du skapar ett vanligt diagram:

```php
  # Instansierar en presentationsklass som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Hämtar den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Lägger till ett diagram med dess standarddata
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Ställer in diagrammets titel
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Ställer in att den första serien visar värden
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Ställer in indexet för diagrammets datablad
    $defaultWorksheetIndex = 0;
    # Hämtar diagrammets dataarbetsblad
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Tar bort de standardgenererade serierna och kategorierna
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Lägger till nya serier
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Lägger till nya kategorier
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Hämtar den första diagramserien
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Fyller nu i seriedatan
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Ställer in fyllningsfärgen för serien
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Hämtar den andra diagramserien
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Fyller i seriedatan
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Ställer in fyllningsfärgen för serien
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Skapa anpassade etiketter för varje kategori för den nya serien
    # Ställer in den första etiketten att visa kategorinamn
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Visar värde för den tredje etiketten
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Sparar presentationen med diagrammet
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Skapa spridda diagram**

Spridda diagram (även kända som spridningsdiagram eller x‑y‑grafer) används ofta för att kontrollera mönster eller demonstrera korrelationer mellan två variabler. 

Du kan vilja använda ett spritt diagram när 

* du har parade numeriska data
* du har 2 variabler som passar bra ihop
* du vill avgöra om 2 variabler är relaterade
* du har en oberoende variabel som har flera värden för en beroende variabel

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Steg:</em> Skapa spritt diagram </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Steg:</em> Skapa PowerPoint spritt diagram </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation spritt diagram </strong></a>

1. Följ stegen som nämns ovan i [Skapa vanliga diagram](#creating-normal-charts)
2. För tredje steget, lägg till ett diagram med viss data och ange din diagramtyp som någon av följande
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/sv/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Representerar spritt diagram._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/sv/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Representerar spritt diagram som är kopplat med kurvor, med data‑markörer._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/sv/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Representerar spritt diagram kopplat med kurvor, utan data‑markörer._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/sv/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Representerar spritt diagram kopplat med raka linjer, med data‑markörer._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/sv/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Representerar spritt diagram kopplat med raka linjer, utan data‑markörer._

Den här PHP-koden visar hur du skapar spridda diagram med olika markörserier:

```php
  # Instansierar en presentationsklass som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Hämtar den första bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Skapar standarddiagrammet
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Hämtar standarddiagrammets dataarbetsbladsindex
    $defaultWorksheetIndex = 0;
    # Hämtar diagrammets dataarbetsblad
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Tar bort demo-serien
    $chart->getChartData()->getSeries()->clear();
    # Lägger till nya serier
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Hämtar den första diagramserien
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Lägger till en ny punkt (1:3) i serien
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Lägger till en ny punkt (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Ändrar serietypen
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Ändrar diagramseriens markör
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Hämtar den andra diagramserien
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Lägger till en ny punkt (5:2) där
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Lägger till en ny punkt (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Lägger till en ny punkt (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Lägger till en ny punkt (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Ändrar diagramseriens markör
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Skapa pajdiagram**

Pajdiagram används bäst för att visa del‑till‑helhet‑relationen i data, särskilt när data innehåller kategoriska etiketter med numeriska värden. Om dina data innehåller många delar eller etiketter kan du istället överväga att använda ett stapeldiagram.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Steg:</em> Skapa pajdiagram </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Steg:</em> Skapa PowerPoint pajdiagram </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation pajdiagram </strong></a>

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) .
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata samt önskad typ (i detta fall, [ChartType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ChartType).Pie).
4. Kom åt [ChartDataWorkbook](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/) .
5. Rensa de standardserier och -kategorier.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Lägg till nya punkter för diagrammen och lägg till anpassade färger för sektorerna i pajdiagrammet.
9. Ange etiketter för serier.
10. Ange ledarlinjer för serieetiketter.
11. Ange rotationsvinkeln för pajdiagrambilder.
12. Spara den modifierade presentationen till en PPTX-fil

Den här PHP-koden visar hur du skapar ett pajdiagram:

```php
  # Instansierar en presentationsklass som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Hämtar den första bilden
    $slides = $pres->getSlides()->get_Item(0);
    # Lägger till ett diagram med standarddata
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Ställer in diagrammets titel
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Ställer in att den första serien visar värden
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Ställer in indexet för diagrammets dataark
    $defaultWorksheetIndex = 0;
    # Hämtar diagrammets dataarbetsblad
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Tar bort de standardgenererade serierna och kategorierna
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Lägger till nya kategorier
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Lägger till nya serier
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Fyller i seriedatan
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Fungerar inte i ny version
    # Adding new points and setting sector color
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Ställer in sektorns kant
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Ställer in sektorns kant
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Ställer in sektorns kant
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # Skapar anpassade etiketter för varje kategori för den nya serien
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
    # Visar förklaringslinjer för diagrammet
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Ställer in rotationsvinkeln för pajdiagrammets sektorer
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Sparar presentationen med ett diagram
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Skapa linjediagram**

Linjediagram (även kända som linjediagram) används bäst i situationer där du vill visa förändringar i värde över tid. Med ett linjediagram kan du jämföra mycket data på en gång, spåra förändringar och trender över tid, framhäva avvikelser i dataserier, etc.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) .
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata samt önskad typ (i detta fall, `ChartType::Line`).
1. Kom åt diagramdata IChartDataWorkbook.
1. Rensa de standardserier och -kategorier.
1. Lägg till nya serier och kategorier.
1. Lägg till ny diagramdata för diagramserierna.
1. Spara den modifierade presentationen till en PPTX-fil

Den här PHP-koden visar hur du skapar ett linjediagram:

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

Som standard är punkterna på ett linjediagram förenade med raka kontinuerliga linjer. Om du vill att punkterna ska förenas med streck istället kan du ange din föredragna strecktyp på följande sätt:

```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```

### **Skapa trädkartsdiagram**

Trädkartsdiagram är bäst för försäljningsdata när du vill visa den relativa storleken på datakategorier och samtidigt snabbt rikta uppmärksamhet mot poster som är stora bidragsgivare till varje kategori. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Steg:</em> Skapa trädkartsdiagram </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Steg:</em> Skapa PowerPoint trädkartsdiagram </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation trädkartsdiagram </strong></a>

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) klass.
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata samt önskad typ (i detta fall, [ChartType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ChartType).TreeMap).
4. Kom åt [ChartDataWorkbook](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/) .
5. Rensa de standardserier och -kategorier.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Spara den modifierade presentationen till en PPTX-fil

Den här PHP-koden visar hur du skapar ett trädkartsdiagram:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # gren 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # gren 2
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

### **Skapa börsdiagram**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Steg:</em> Skapa börsdiagram </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Steg:</em> Skapa PowerPoint börsdiagram </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation börsdiagram </strong></a>

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) klass.
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata samt önskad typ ([ChartType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ChartType).OpenHighLowClose).
4. Kom åt [ChartDataWorkbook](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/) .
5. Rensa de standardserier och -kategorier.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Ange HiLowLines‑format.
9. Spara den modifierade presentationen till en PPTX-fil

Exempel på PHP‑kod som används för att skapa ett börsdiagram:

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

### **Skapa låd- och whisker-diagram**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Steg:</em> Skapa låd- och whisker-diagram </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Steg:</em> Skapa PowerPoint låd- och whisker-diagram </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation låd- och whisker-diagram </strong></a>

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) klass.
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata samt önskad typ ([ChartType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ChartType).BoxAndWhisker).
4. Kom åt [ChartDataWorkbook](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/) .
5. Rensa de standardserier och -kategorier.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Spara den modifierade presentationen till en PPTX-fil

Den här PHP-koden visar hur du skapar ett låd‑ och whisker‑diagram:

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

### **Skapa trattdiagram**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Steg:</em> Skapa trattdiagram </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Steg:</em> Skapa PowerPoint trattdiagram </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation trattdiagram </strong></a>


1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) klass.
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata samt önskad typ ([ChartType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ChartType).Funnel).
4. Spara den modifierade presentationen till en PPTX-fil

PHP‑koden visar hur du skapar ett trattdiagram:

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

### **Skapa solstråle‑diagram**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Steg:</em> Skapa solstråle‑diagram </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Steg:</em> Skapa PowerPoint solstråle‑diagram </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation solstråle‑diagram </strong></a>

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) klass.
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata samt önskad typ (i detta fall,[ChartType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ChartType).sunburst).
4. Spara den modifierade presentationen till en PPTX-fil

Den här PHP‑koden visar hur du skapar ett solstråle‑diagram:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # gren 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # gren 2
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

### **Skapa histogramdiagram**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Steg:</em> Skapa histogramdiagram </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Steg:</em> Skapa PowerPoint histogramdiagram </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation histogramdiagram </strong></a>

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) klass.
2. Hämta en bilds referens via dess index.
3. Lägg till ett diagram med standarddata samt önskad typ ([ChartType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ChartType).Histogram).
4. Kom åt [ChartDataWorkbook](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/) .
5. Rensa de standardserier och -kategorier.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Spara den modifierade presentationen till en PPTX-fil

Den här PHP‑koden visar hur du skapar ett histogram‑diagram:

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

### **Skapa radardiagram**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Steg:</em> Skapa radardiagram </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Steg:</em> Skapa PowerPoint radardiagram </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation radardiagram </strong></a>

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) klass.
2. Hämta en bilds referens via dess index. 
3. Lägg till ett diagram med viss data och ange din föredragna diagramtyp (`ChartType::Radar` i detta fall).
4. Spara den modifierade presentationen till en PPTX-fil

Den här PHP‑koden visar hur du skapar ett radardiagram:

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

### **Skapa flerkategoridiagram**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Steg:</em> Skapa flerkategoridiagram </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Steg:</em> Skapa PowerPoint flerkategoridiagram </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation flerkategoridiagram </strong></a>

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) klass.
2. Hämta en bilds referens via dess index. 
3. Lägg till ett diagram med standarddata samt önskad typ ([ChartType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ChartType).ClusteredColumn).
4. Kom åt [ChartDataWorkbook](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/) .
5. Rensa de standardserier och -kategorier.
6. Lägg till nya serier och kategorier.
7. Lägg till ny diagramdata för diagramserierna.
8. Spara den modifierade presentationen till en PPTX-fil.

Den här PHP‑koden visar hur du skapar ett flerkategoridiagram:

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
    # Lägger till serie
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # Spara presentation med diagram
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Skapa kartdiagram**

Ett kartdiagram är en visualisering av ett område som innehåller data. Kartdiagram är bäst för att jämföra data eller värden över geografiska regioner.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Steg:</em> Skapa kartdiagram </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Steg:</em> Skapa PowerPoint kartdiagram </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Steg:</em> Skapa PowerPoint Presentation kartdiagram </strong></a>

Den här PHP‑koden visar hur du skapar ett kartdiagram:

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

### **Skapa kombinationsdiagram**

Ett kombinationsdiagram (eller kombidiagram) kombinerar två eller fler diagramtyper i ett enda diagram. Detta diagram låter dig framhäva, jämföra eller undersöka skillnader mellan två eller fler datamängder, vilket hjälper dig att identifiera relationer mellan dem.

![Kombinationsdiagrammet](combination_chart.png)

Följande PHP‑kod visar hur du skapar kombinationsdiagrammet som visas ovan i en PowerPoint‑presentation:

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

    // Ställ in diagramrubrik.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Ställ in diagramförklaring.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Ta bort de standardgenererade serierna och kategorierna.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Lägg till nya kategorier.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Lägg till den första serien.
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
    // Ställ in den horisontella axeln.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Ställ in den vertikala axeln.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Ställ in färgen på de vertikala huvudgallerlinjerna.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Ställ in den sekundära horisontella axeln.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Ställ in den sekundära vertikala axeln.
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

## **Uppdatera diagram**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Steg:</em> Uppdatera PowerPoint-diagram </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Steg:</em> Uppdatera Presentation-diagram </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Steg:</em> Uppdatera PowerPoint Presentation-diagram </strong></a>

1. Instansiera en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) klass som representerar presentationen som innehåller diagrammet du vill uppdatera.
2. Hämta referensen till en bild genom att använda dess Index.
3. Traversera alla former för att hitta önskat diagram.
4. Kom åt diagrammets dataarbetsblad.
5. Modifiera diagrammets dataserier genom att ändra serievärden.
6. Lägg till en ny serie och fyll i data i den.
7. Spara den modifierade presentationen som en PPTX‑fil.

Denna PHP‑kod visar hur du uppdaterar ett diagram:

```php
  $pres = new Presentation();
  try {
    # Hämta första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Hämta diagrammet med standarddata
    $chart = $sld->getShapes()->get_Item(0);
    # Ställer in indexet för diagrammets dataark
    $defaultWorksheetIndex = 0;
    # Hämtar diagrammets dataarbetsblad
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Ändrar diagrammets kategorinamn
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Hämta den första diagramserien
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Uppdaterar nu seriedata
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Ändrar seriens namn

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Hämta den andra diagramserien
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Uppdaterar nu seriedata
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Ändrar seriens namn

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Lägger nu till en ny serie
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Hämta den tredje diagramserien
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Fyller nu i seriedata
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Spara presentationen med diagrammet
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange dataområde för ett diagram**

1. Instansiera en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) klass som representerar presentationen som innehåller diagrammet.
2. Hämta en bilds referens via dess index.
3. Traversera alla former för att hitta önskat diagram.
4. Kom åt diagramdata och ange intervallet.
5. Spara den modifierade presentationen som en PPTX‑fil.

Denna PHP‑kod visar hur du anger dataområdet för ett diagram:

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

## **Använd standardmarkörer i diagram**

När du använder en standardmarkör i diagram får varje diagramserie automatiskt olika standardmarkörsymboler.

Denna PHP‑kod visar hur du automatiskt ställer in en diagramserie‑markör:

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
    # Ta den andra diagramserien
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Nu fyller seriedata
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

## **FAQ**

**Vilka diagramtyper stöds av Aspose.Slides?**

Aspose.Slides stödjer ett brett utbud av [diagramtyper](https://reference.aspose.com/slides/sv/php-java/aspose.slides/charttype/), inklusive stapel, linje, paj, area, spritt, histogram, radar och många fler. Denna flexibilitet låter dig välja den mest lämpliga diagramtypen för dina behov av datavisualisering.

**Hur lägger jag till ett nytt diagram på en bild?**

För att lägga till ett diagram skapar du först en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) , hämtar den önskade bilden med dess index och anropar sedan metoden för att lägga till ett diagram, där du specificerar diagramtyp och initial data. Detta integrerar diagrammet direkt i din presentation.

**Hur kan jag uppdatera data som visas i ett diagram?**

Du kan uppdatera ett diagrams data genom att komma åt dess dataarbetsbok ([ChartDataWorkbook](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdataworkbook/)), rensa eventuella standardserier och -kategorier och sedan lägga till dina egna data. Detta gör att du kan uppdatera diagrammet så att det reflekterar de senaste uppgifterna.

**Är det möjligt att anpassa diagrammets utseende?**

Ja, Aspose.Slides erbjuder omfattande anpassningsalternativ. Du kan ändra färger, typsnitt, etiketter, förklaringar och andra [formateringselement](/slides/sv/php-java/chart-entities/) för att anpassa diagrammets utseende efter dina specifika designkrav.