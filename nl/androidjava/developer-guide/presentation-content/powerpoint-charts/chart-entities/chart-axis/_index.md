---
title: Diagramassen aanpassen in presentaties op Android
linktitle: Grafiekas
type: docs
url: /nl/androidjava/chart-axis/
keywords:
- grafiekas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as eigenschappen
- maximumwaarde
- minimumwaarde
- aslijn
- datumnotatie
- as titel
- aspositie
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides for Android via Java kunt gebruiken om diagramassen in PowerPoint‑presentaties aan te passen voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u diagramassen kunt aanpassen in Aspose.Slides. Het laat zien hoe u de werkelijke aswaarden kunt verkrijgen, gegevens tussen assen kunt verwisselen, de verticale of horizontale as voor lijndiagrammen kunt verbergen, het type categorische as kunt wijzigen, de datumnotatie voor categorische aswaarden kunt instellen, een as‑titel kunt roteren, de aspositie kunt bepalen en een eenheidslabel op de waardenas kunt weergeven.

## **Maximumwaarden op de verticale as van diagrammen ophalen**
Aspose.Slides for Android via Java stelt u in staat de minimum‑ en maximumwaarden op een verticale as te verkrijgen. Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Open de eerste dia.
3. Voeg een diagram toe met standaardgegevens.
4. Haal de werkelijke maximumwaarde van de as op.
5. Haal de werkelijke minimumwaarde van de as op.
6. Haal de werkelijke hoofd eenheid van de as op.
7. Haal de werkelijke subeenheid van de as op.
8. Haal de werkelijke schaal van de hoofd eenheid van de as op.
9. Haal de werkelijke schaal van de subeenheid van de as op.

Deze voorbeeldcode—een implementatie van de bovenstaande stappen—laat zien hoe u de vereiste waarden in Java kunt verkrijgen:

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
Aspose.Slides stelt u in staat om snel de gegevens tussen assen te verwisselen — de gegevens die op de verticale as (y‑as) worden weergegeven, worden verplaatst naar de horizontale as (x‑as) en omgekeerd. 

Deze Java‑code laat zien hoe u de gegevensverwisseling tussen assen in een diagram uitvoert:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Wisselt rijen en kolommen
	chart.getChartData().switchRowColumn();

	// Slaat de presentatie op
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Verticale as voor lijndiagrammen uitschakelen**

Deze Java‑code laat zien hoe u de verticale as voor een lijndiagram kunt verbergen:

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

## **Horizontale as voor lijndiagrammen uitschakelen**

Deze code laat zien hoe u de horizontale as voor een lijndiagram kunt verbergen:

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

## **Categorische as wijzigen**

Met de eigenschap **CategoryAxisType** kunt u het gewenste type categorische as instellen (**date** of **text**). Deze Java‑code demonstreert de bewerking: 

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

## **Datumnotatie voor categorische aswaarden instellen**
Aspose.Slides for Android via Java stelt u in staat de datumnotatie voor een categorische aswaarde in te stellen. De bewerking wordt gedemonstreerd in deze Java‑code:

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

## **Rotatiehoek voor een diagramas‑titel instellen**
Aspose.Slides for Android via Java stelt u in staat de rotatiehoek voor een diagramas‑titel in te stellen. Deze Java‑code demonstreert de bewerking:

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

## **Aspositie op een categorische of waardenas instellen**
Aspose.Slides for Android via Java stelt u in staat de positie van de as in een categorische of waardenas in te stellen. Deze Java‑code laat zien hoe u deze taak uitvoert:

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

## **Eenheidslabel op de waardenas van het diagram inschakelen**
Aspose.Slides for Android via Java stelt u in staat een diagram zó te configureren dat een eenheidslabel op de waardenas wordt getoond. Deze Java‑code demonstreert de bewerking:

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

**Hoe stel ik de waarde in waarop één as de andere kruist (as kruising)?**

Assen bieden een [crossing setting](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/axis/#setCrossType-int-): u kunt kiezen om te kruisen bij nul, bij de maximale categorie/waarde, of bij een specifieke numerieke waarde. Dit is handig om de X‑as omhoog of omlaag te verschuiven of om een basislijn te accentueren.

**Hoe kan ik de tick‑labels ten opzichte van de as positioneren (naast, buiten, binnen)?**

Stel de [label position](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) in op "cross", "outside" of "inside". Dit beïnvloedt de leesbaarheid en bespaart ruimte, vooral bij kleine diagrammen.