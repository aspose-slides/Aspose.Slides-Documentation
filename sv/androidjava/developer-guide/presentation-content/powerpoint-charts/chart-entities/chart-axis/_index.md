---
title: Anpassa diagramaxlar i presentationer på Android
linktitle: Diagramaxel
type: docs
url: /sv/androidjava/chart-axis/
keywords:
- diagramaxel
- vertikal axel
- horisontell axel
- anpassa axel
- manipulera axel
- hantera axel
- axelns egenskaper
- maxvärde
- minvärde
- axellinje
- datumformat
- axelrubrik
- axelposition
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck hur du använder Aspose.Slides för Android via Java för att anpassa diagramaxlar i PowerPoint-presentationer för rapporter och visualiseringar."
---
## **Översikt**

Denna artikel förklarar hur du anpassar diagramaxlar i Aspose.Slides. Den visar hur du hämtar faktiska axiella värden, byter data mellan axlar, döljer den vertikala eller horisontella axeln för linjediagram, ändrar kategoriaxeltyp, anger datumformat för kategoriaxiellvärden, roterar en axelrubrik, ställer in axelposition och visar en enhetsetikett på värdeaxeln.

## **Hämta maxvärdena på den vertikala axeln i diagram**
Aspose.Slides for Android via Java låter dig hämta minimi- och maximivärden på en vertikal axel. Följ dessa steg:

1. Skapa en instans av klassen[Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
1. Få åtkomst till den första bilden.
1. Lägg till ett diagram med standarddata.
1. Hämta det faktiska maximivärdet på axeln.
1. Hämta det faktiska minimivärdet på axeln.
1. Hämta den faktiska huvudenheten för axeln.
1. Hämta den faktiska delenheten för axeln.
1. Hämta den faktiska huvudenhetsskalan för axeln.
1. Hämta den faktiska delenhetsskalan för axeln.

Den här exempelkoden—en implementation av stegen ovan—visar hur du hämtar de nödvändiga värdena i Java:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Sparar presentationen
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Byt data mellan axlarna**
Aspose.Slides gör det enkelt att snabbt byta data mellan axlarna—data som visas på den vertikala axeln (y‑axeln) flyttas till den horisontella axeln (x‑axeln) och vice versa.

Denna Java‑kod visar hur du utför datautbytesuppgiften mellan axlar i ett diagram:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Växlar rader och kolumner
	chart.getChartData().switchRowColumn();

	// Sparar presentationen
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Inaktivera den vertikala axeln för linjediagram**

Denna Java‑kod visar hur du döljer den vertikala axeln för ett linjediagram:

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

## **Inaktivera den horisontella axeln för linjediagram**

Denna kod visar hur du döljer den horisontella axeln för ett linjediagram:

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

## **Ändra en kategoriaxel**

Genom att använda egenskapen **CategoryAxisType** kan du ange din föredragna typ av kategoriaxel (**date** eller **text**). Denna Java‑kod demonstrerar operationen:

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

## **Ställ in datumformatet för kategoriaxelvärden**
Aspose.Slides för Android via Java låter dig ange datumformatet för ett kategoriaxelvärde. Operationen demonstreras i denna Java‑kod:

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

## **Ställ in en roteringsvinkel för ett diagramaxelrubrik**
Aspose.Slides för Android via Java låter dig ange roteringsvinkeln för ett diagramaxelrubrik. Denna Java‑kod demonstrerar operationen:

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

## **Ställ in axelpositionen på en kategori‑ eller värdeaxel**
Aspose.Slides för Android via Java låter dig ange positionsaxeln i en kategori‑ eller värdeaxel. Denna Java‑kod visar hur du utför uppgiften:

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

## **Aktivera visning av enhetsetikett på diagrammets värdeaxel**
Aspose.Slides för Android via Java låter dig konfigurera ett diagram så att det visar en enhetsetikett på dess värdeaxel. Denna Java‑kod demonstrerar operationen:

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

**Hur ställer jag in värdet där en axel korsar den andra (axelkorsning)?**

Axlarna erbjuder en [crossing setting](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/axis/#setCrossType-int-): du kan välja att korsas vid noll, vid den maximala kategori‑/värdet, eller vid ett specifikt numeriskt värde. Detta är användbart för att flytta X‑axeln upp eller ner eller för att framhäva en baslinje.

**Hur kan jag positionera tick‑etiketterna i förhållande till axeln (intill, utanför, innanför)?**

Ställ in [label position](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) till "cross", "outside" eller "inside". Detta påverkar läsbarheten och hjälper till att spara utrymme, särskilt i små diagram.