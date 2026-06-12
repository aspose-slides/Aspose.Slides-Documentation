---
title: Grafiekassen aanpassen in presentaties met Java
linktitle: Grafiekas
type: docs
url: /nl/java/chart-axis/
keywords:
- grafiekas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as-eigenschappen
- max waarde
- min waarde
- aslijn
- datumformaat
- as-titel
- as-positie
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Ontdek hoe je Aspose.Slides voor Java kunt gebruiken om grafiekassen in PowerPoint‑presentaties aan te passen voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe je de assen van een diagram in Aspose.Slides kunt aanpassen. Het toont hoe je de werkelijke aswaarden kunt ophalen, gegevens tussen assen kunt verwisselen, de verticale of horizontale as voor lijndiagrammen kunt verbergen, het type van de categorische as kunt wijzigen, het datumformaat voor categorische aswaarden kunt instellen, een as‑titel kunt roteren, de positie van de as kunt bepalen en een eenheidslabel op de waardenas kunt weergeven.

## **Maximale waarden op de verticale as van grafieken ophalen**
Aspose.Slides for Java maakt het mogelijk de minimum‑ en maximumwaarden op een verticale as te verkrijgen. Volg deze stappen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse.
2. Open de eerste dia.
3. Voeg een diagram toe met standaardgegevens.
4. Haal de werkelijke maximale waarde van de as op.
5. Haal de werkelijke minimale waarde van de as op.
6. Haal de werkelijke hoofd‑eenheid van de as op.
7. Haal de werkelijke sub‑eenheid van de as op.
8. Haal de werkelijke schaal van de hoofd‑eenheid van de as op.
9. Haal de werkelijke schaal van de sub‑eenheid van de as op.

Deze voorbeeldcode—een implementatie van de bovenstaande stappen—toont hoe je de benodigde waarden in Java kunt verkrijgen:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Slaat de presentatie op
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Gegevens tussen assen verwisselen**
Aspose.Slides maakt het eenvoudig om de gegevens tussen assen te verwisselen; de gegevens die op de verticale as (y‑as) staan, worden naar de horizontale as (x‑as) verplaatst en omgekeerd.

Deze Java‑code laat zien hoe je de verwisseling van gegevens tussen assen in een diagram uitvoert:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Wisselt rijen en kolommen
	// Slaat presentatie op
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Verticale as voor lijndiagrammen verbergen**

Deze Java‑code laat zien hoe je de verticale as voor een lijndiagram kunt verbergen:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getVerticalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Horizontale as voor lijndiagrammen verbergen**

Deze code laat zien hoe je de horizontale as voor een lijndiagram kunt verbergen:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getHorizontalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Categorieas wijzigen**

Met de **CategoryAxisType**‑eigenschap kun je het gewenste type categorische as opgeven (**date** of **text**). Deze Java‑code demonstreert de bewerking:

```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
	IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
	chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
	chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
	chart.getAxes().getHorizontalAxis().setMajorUnit(1);
	chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
	presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

## **Datumformaat voor categorische aswaarden instellen**
Aspose.Slides for Java maakt het mogelijk het datumformaat voor een categorische aswaarde in te stellen. De bewerking wordt gedemonstreerd in deze Java‑code:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
	
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```

## **Rotatiehoek voor een diagram‑as‑titel instellen**
Aspose.Slides for Java maakt het mogelijk een rotatiehoek voor een diagram‑as‑titel in te stellen. Deze Java‑code demonstreert de bewerking:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Positie van de as op een categorische of waardenas instellen**
Aspose.Slides for Java maakt het mogelijk de positie van een as op een categorische of waardenas in te stellen. Deze Java‑code toont hoe je de taak uitvoert:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Weergave‑eenheidslabel op de waardenas van een diagram inschakelen**
Aspose.Slides for Java maakt het mogelijk een diagram te configureren zodat er een eenheidslabel op de waardenas wordt weergegeven. Deze Java‑code demonstreert de bewerking:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Hoe stel ik de waarde in waarop de ene as de andere kruist (as‑kruising)?**

Assen bieden een [kruisinginstelling](https://reference.aspose.com/slides/nl/java/com.aspose.slides/axis/#setCrossType-int-): je kunt kiezen om te kruisen op nul, op de maximale categorie/waarde, of op een specifiek numeriek getal. Dit is handig om de X‑as omhoog of omlaag te schuiven of om een basislijn te benadrukken.

**Hoe kan ik de positie van de tic‑labels ten opzichte van de as bepalen (naast, buiten, binnen)?**

Stel de [labelpositie](https://reference.aspose.com/slides/nl/java/com.aspose.slides/axis/#setMajorTickMark-int-) in op "cross", "outside" of "inside". Dit beïnvloedt de leesbaarheid en helpt ruimte te besparen, vooral bij kleine diagrammen.