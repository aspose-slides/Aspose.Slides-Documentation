---
title: Beheer grafiekgegevensreeksen in presentaties met Java
linktitle: Gegevensreeksen
type: docs
url: /nl/java/chart-series/
keywords:
- grafiekreeksen
- reeks-overlap
- reeks-kleur
- categorie-kleur
- reeksnaam
- datapunt
- reeksafstand
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u grafiekreeksen in Java voor PowerPoint (PPT/PPTX) kunt beheren met praktische codevoorbeelden en best practices om uw datapresentaties te verbeteren."
---
## **Overzicht**

Dit artikel beschrijft de rol van [ChartSeries](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartseries/) in Aspose.Slides, met de nadruk op hoe gegevens worden gestructureerd en gevisualiseerd in presentaties. Deze objecten vormen de fundamentele elementen die individuele verzamelingen van gegevenspunten, categorieën en weergave‑parameters in een diagram definiëren. Door met ChartSeries te werken, kunnen ontwikkelaars onderliggende gegevensbronnen naadloos integreren en volledige controle behouden over hoe informatie wordt weergegeven, wat leidt tot dynamische, data‑gedreven presentaties die duidelijk inzichten en analyses overbrengen.

Een reeks is een rij of kolom met getallen die in een diagram worden uitgezet.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Instellen van de overlaptijd van de grafiekreeks**

Met de [IChartSeriesOverlap](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/properties/overlap) eigenschap kun je opgeven hoeveel balken en kolommen moeten overlappen in een 2D‑diagram (bereik: -100 tot 100). Deze eigenschap geldt voor alle reeksen van de bovenliggende seriesgroep: dit is een projectie van de juiste groepseigenschap. Daarom is deze eigenschap alleen‑lezen. 

Gebruik de `ParentSeriesGroup.Overlap` lees‑/schrijfeigenschap om je gewenste waarde voor `Overlap` in te stellen. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
1. Voeg een gegroepeerde kolomgrafiek toe aan een dia.
1. Toegang tot de eerste grafiekreeks.
1. Toegang tot de `ParentSeriesGroup` van de grafiekreeks en stel de gewenste overlaptijdwaarde voor de reeks in.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze Java‑code toont hoe je de overlaptijd voor een grafiekreeks instelt:

```java
Presentation pres = new Presentation();
try {
    // Voeg grafiek toe
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Stel reeks-overlap in
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Schrijf het presentatiebestand naar schijf
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kleur van de reeks wijzigen**

Aspose.Slides for Java stelt je in staat de kleur van een reeks op deze manier te wijzigen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
1. Voeg een diagram toe aan de dia.
1. Toegang tot de reeks waarvan je de kleur wilt wijzigen.
1. Stel het gewenste opvultype en de opvulkleur in.
1. Sla de gewijzigde presentatie op.

Deze Java‑code toont hoe je de kleur van een reeks wijzigt:

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

## **Kleur van de reeks‑categorie wijzigen**

Aspose.Slides for Java stelt je in staat de kleur van een reeks‑categorie op deze manier te wijzigen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
1. Voeg een diagram toe aan de dia.
1. Toegang tot de reeks‑categorie waarvan je de kleur wilt wijzigen.
1. Stel het gewenste opvultype en de opvulkleur in.
1. Sla de gewijzigde presentatie op.

Deze code in Java toont hoe je de kleur van een reeks‑categorie wijzigt:

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

## **Naam van de reeks wijzigen** 

Standaard zijn de legenda‑namen voor een diagram de inhoud van de cellen boven elke kolom of rij met gegevens. 

In ons voorbeeld (voorbeeldafbeelding), 

* de kolommen zijn *Series 1, Series 2,* en *Series 3*;
* de rijen zijn *Category 1, Category 2, Category 3,* en *Category 4.* 

Aspose.Slides for Java stelt je in staat een reeksnaam bij te werken of te wijzigen in de diagramgegevens en de legenda. 

Deze Java‑code toont hoe je de naam van een reeks wijzigt in de diagramgegevens `ChartDataWorkbook`:

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

Deze Java‑code toont hoe je de naam van een reeks wijzigt in de legenda via `Series`:

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

## **Vulkleur van de grafiekreeks instellen**

Aspose.Slides for Java stelt je in staat de automatische vulkleur voor grafiekreeksen binnen een plotgebied op deze manier in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
1. Verkrijg een referentie naar een dia via de index.
1. Voeg een diagram toe met standaardgegevens op basis van je gewenste type (in het onderstaande voorbeeld gebruikten we `ChartType.ClusteredColumn`).
1. Toegang tot de grafiekreeks en stel de vulkleur in op Automatic.
1. Sla de presentatie op naar een PPTX‑bestand.

Deze Java‑code toont hoe je de automatische vulkleur voor een grafiekreeks instelt:

```java
Presentation pres = new Presentation();
try {
    // Creëert een gegroepeerde kolomgrafiek
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Stelt vulopmaak van de reeks in op automatisch
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

## **Omgekeerde vulkleur voor een grafiekreeks instellen**

Aspose.Slides stelt je in staat de omgekeerde vulkleur voor grafiekreeksen binnen een plotgebied op deze manier in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
1. Verkrijg een referentie naar een dia via de index.
1. Voeg een diagram toe met standaardgegevens op basis van je gewenste type (in het onderstaande voorbeeld gebruikten we `ChartType.ClusteredColumn`).
1. Toegang tot de grafiekreeks en stel de vulkleur in op invert.
1. Sla de presentatie op naar een PPTX‑bestand.

Deze Java‑code toont de bewerking:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Voeg nieuwe reeksen en categorieën toe
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Neem de eerste grafiekreeks en vul de gegevens ervan
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

## **Een reeks laten omkeren wanneer de waarde negatief is**

Aspose.Slides stelt je in staat omkeringen in te stellen via de `IChartDataPoint.InvertIfNegative` en `ChartDataPoint.InvertIfNegative` eigenschappen. Wanneer een omkering is ingesteld via deze eigenschappen, draait het gegevenspunt zijn kleuren om wanneer het een negatieve waarde krijgt. 

Deze Java‑code toont de bewerking:

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

Aspose.Slides for Java stelt je in staat de `DataPoints`‑gegevens voor een specifieke grafiekreeks op deze manier te wissen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
2. Verkrijg de referentie van een dia via de index.
3. Verkrijg de referentie van een diagram via de index.
4. Loop door alle `DataPoints` van het diagram en stel `XValue` en `YValue` in op null.
5. Wis alle `DataPoints` voor de specifieke grafiekreeks.
6. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze Java‑code toont de bewerking:

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

## **Tussenafstand van de reeks instellen**

Aspose.Slides for Java stelt je in staat de **`GapWidth`** eigenschap van een reeks op deze manier in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
1. Open de eerste dia.
1. Voeg een diagram toe met standaardgegevens.
1. Toegang tot een willekeurige grafiekreeks.
1. Stel de `GapWidth` eigenschap in.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze code in Java toont hoe je de tussenafstand van een reeks instelt:

```java
// Creëert lege presentatie 
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia van de presentatie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Voeg een grafiek toe met standaarddata
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Stelt de index van het diagramgegevensblad in
    int defaultWorksheetIndex = 0;
    
    // Haalt het diagramgegevenswerkblad op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Voeg reeksen toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Voeg categorieën toe
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Neemt de tweede grafiekreeks
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Vul de gegevens van de reeks
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Stelt de GapWidth-waarde in
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Slaat de presentatie op naar schijf
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Is er een limiet aan het aantal reeksen dat één diagram kan bevatten?**

Aspose.Slides stelt geen vaste limiet aan het aantal reeksen dat je kunt toevoegen. De praktische beperking wordt bepaald door de leesbaarheid van het diagram en door het geheugen dat jouw applicatie beschikbaar heeft.

**Wat als de kolommen binnen een cluster te dicht opeen liggen of te ver uit elkaar staan?**

Pas de `GapWidth`‑instelling voor die reeks (of de bijbehorende seriesgroep) aan. Het verhogen van de waarde vergroot de ruimte tussen de kolommen, terwijl het verlagen ervan de kolommen dichter bij elkaar brengt.