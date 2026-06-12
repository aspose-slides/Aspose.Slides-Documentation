---
title: Beheer grafiekgegevensseries in presentaties op Android
linktitle: Gegevensseries
type: docs
url: /nl/androidjava/chart-series/
keywords:
- grafiekserie
- serieoverlapping
- seriekleur
- categoriakleur
- serienaam
- gegevenspunt
- seriegap
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe je grafiekseries beheert op Android voor PowerPoint (PPT/PPTX) met praktische Java-codevoorbeelden en best practices om je datarapresentaties te verbeteren."
---
## **Overzicht**

Dit artikel beschrijft de rol van [ChartSeries](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartseries/) in Aspose.Slides, met de nadruk op hoe gegevens worden gestructureerd en weergegeven in presentaties. Deze objecten vormen de fundamentele elementen die individuele sets van gegevenspunten, categorieën en weergave‑parameters in een diagram definiëren. Door met [ChartSeries](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartseries/) te werken, kunnen ontwikkelaars moeiteloos onderliggende gegevensbronnen integreren en volledige controle behouden over hoe informatie wordt getoond, resulterend in dynamische, data‑gedreven presentaties die duidelijk inzichten en analyses overbrengen.

Een serie is een rij of kolom van getallen die in een diagram worden geplot.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Instellen van de overlapping van de diagramserie**

Met de [IChartSeries.getOverlap](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartseries/#getOverlap--) methode kun je bepalen hoeveel balken en kolommen elkaar moeten overlappen in een 2D‑diagram (bereik: -100 tot 100). Deze eigenschap is van toepassing op alle series van de bovenliggende seriesgroep: dit is een projectie van de overeenkomstige groepseigenschap. Daarom is deze eigenschap alleen‑lezen. 

Gebruik de `getParentSeriesGroup().setOverlap()` schrijf‑methode om je gewenste overlappingswaarde in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
1. Voeg een gegroepeerde kolomgrafiek toe aan een dia.  
1. Toegang tot de eerste diagramserie.  
1. Toegang tot de `ParentSeriesGroup` van de diagramserie en stel je gewenste overlappingswaarde in voor de serie.  
1. Schrijf de gewijzigde presentatie weg naar een PPTX‑bestand.  

Deze Java‑code laat zien hoe je de overlapping voor een diagramserie instelt:

```java
Presentation pres = new Presentation();
try {
    // Voeg diagram toe
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Stelt serie-overlapping in
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Schrijft het presentatiebestand naar schijf
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **De kleur van de serie wijzigen**

Aspose.Slides voor Android via Java stelt je in staat om de kleur van een serie op deze manier te wijzigen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
1. Voeg een diagram toe aan de dia.  
1. Toegang tot de serie waarvan je de kleur wilt wijzigen.  
1. Stel je gewenste opvultype en opvulkleur in.  
1. Sla de gewijzigde presentatie op.  

Deze Java‑code laat zien hoe je de kleur van een serie wijzigt:

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **De kleur van de seriecategorie wijzigen**

Aspose.Slides voor Android via Java stelt je in staat om de kleur van een seriecategorie op deze manier te wijzigen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
1. Voeg een diagram toe aan de dia.  
1. Toegang tot de seriecategorie waarvan je de kleur wilt wijzigen.  
1. Stel je gewenste opvultype en opvulkleur in.  
1. Sla de gewijzigde presentatie op.  

Deze code in Java laat zien hoe je de kleur van een seriecategorie wijzigt:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **De naam van de serie wijzigen**

Standaard zijn de legendaramen voor een diagram de inhoud van de cellen boven elke kolom of rij met gegevens. 

In ons voorbeeld (voorbeeldafbeelding),

* de kolommen zijn *Series 1, Series 2,* en *Series 3*;  
* de rijen zijn *Category 1, Category 2, Category 3,* en *Category 4.*  

Aspose.Slides voor Android via Java maakt het mogelijk om een serienaam te updaten of te wijzigen in de diagramgegevens en de legende.

Deze Java‑code laat zien hoe je de naam van een serie wijzigt in de diagramgegevens `ChartDataWorkbook`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Deze Java‑code laat zien hoe je een serienaam wijzigt in de legende via `Series`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **De opvulkleur van de diagramserie instellen**

Aspose.Slides voor Android via Java stelt je in staat om de automatische opvulkleur voor diagramseries binnen een plotgebied op deze manier in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
1. Verkrijg een referentie naar een dia op basis van zijn index.  
1. Voeg een diagram toe met standaardgegevens op basis van je gewenste type (in het onderstaande voorbeeld gebruikten we `ChartType.ClusteredColumn`).  
1. Toegang tot de diagramserie en stel de opvulkleur in op Automatic.  
1. Sla de presentatie op naar een PPTX‑bestand.  

Deze Java‑code laat zien hoe je de automatische opvulkleur voor een diagramserie instelt:

```java
Presentation pres = new Presentation();
try {
    // Maakt een gegroepeerde kolomgrafiek
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Stelt de vulopmaak van de series in op automatisch
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Schrijft het presentatiebestand naar schijf
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Omgekeerde opvulkleur voor een diagramserie instellen**

Aspose.Slides maakt het mogelijk om de omgekeerde opvulkleur voor diagramseries binnen een plotgebied op deze manier in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
1. Verkrijg een referentie naar een dia op basis van zijn index.  
1. Voeg een diagram toe met standaardgegevens op basis van je gewenste type (in het onderstaande voorbeeld gebruikten we `ChartType.ClusteredColumn`).  
1. Toegang tot de diagramserie en stel de opvulkleur in op invert.  
1. Sla de presentatie op naar een PPTX‑bestand.  

Deze Java‑code toont de werking:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Voegt nieuwe series en categorieën toe
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Neemt de eerste grafiekserie en vult de seriedata
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een serie laten omkeren wanneer de waarde negatief is**

Aspose.Slides maakt het mogelijk om inversies in te stellen via de `IChartDataPoint.InvertIfNegative` en `ChartDataPoint.InvertIfNegative` eigenschappen. Wanneer een inversie is ingesteld met deze eigenschappen, keert het gegevenspunt zijn kleuren om zodra het een negatieve waarde krijgt. 

Deze Java‑code toont de werking:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Specifieke puntgegevens wissen**

Aspose.Slides voor Android via Java maakt het mogelijk om de `DataPoints`‑gegevens van een specifieke diagramserie op deze manier te wissen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Verkrijg de referentie van een dia via zijn index.  
3. Verkrijg de referentie van een diagram via zijn index.  
4. Itereer door alle `DataPoints` van het diagram en stel `XValue` en `YValue` in op null.  
5. Wis alle `DataPoints` voor de specifieke diagramserie.  
6. Schrijf de gewijzigde presentatie weg naar een PPTX‑bestand.  

Deze Java‑code toont de werking:

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Instellen van de Gap Width van de serie**

Aspose.Slides voor Android via Java maakt het mogelijk om de Gap Width van een serie in te stellen via de **`GapWidth`**‑eigenschap op deze manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
1. Toegang tot de eerste dia.  
1. Voeg een diagram toe met standaardgegevens.  
1. Toegang tot een willekeurige diagramserie.  
1. Stel de `GapWidth`‑eigenschap in.  
1. Schrijf de gewijzigde presentatie weg naar een PPTX‑bestand.  

Deze code in Java laat zien hoe je de Gap Width van een serie instelt:

```java
// Maakt lege presentatie 
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia van de presentatie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Voegt een diagram toe met standaarddata
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Stelt de index van het diagramgegevensblad in
    int defaultWorksheetIndex = 0;
    
    // Haalt het diagramgegevensblad op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Voegt series toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Voegt categorieën toe
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Neemt de tweede diagramserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Vult de seriedata
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Stelt GapWidth‑waarde in
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Slaat presentatie op naar schijf
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Veelgestelde vragen**

**Is er een limiet aan het aantal series dat één diagram kan bevatten?**

Aspose.Slides legt geen vaste limiet op aan het aantal series dat je toevoegt. De praktische bovengrens wordt bepaald door de leesbaarheid van het diagram en door het beschikbare geheugen van je applicatie.

**Wat als de kolommen binnen een cluster te dicht bij elkaar staan of te ver uit elkaar liggen?**

Pas de `GapWidth`‑instelling aan voor die serie (of de bovenliggende seriesgroep). Een hogere waarde vergroot de ruimte tussen de kolommen, een lagere waarde verkleint die ruimte.