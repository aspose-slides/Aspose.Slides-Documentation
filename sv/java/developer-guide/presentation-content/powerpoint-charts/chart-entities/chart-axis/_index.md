---
title: Anpassa diagramaxlar i presentationer med Java
linktitle: Diagramaxel
type: docs
url: /sv/java/chart-axis/
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
- axeltitel
- axelposition
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Upptäck hur du använder Aspose.Slides för Java för att anpassa diagramaxlar i PowerPoint-presentationer för rapporter och visualiseringar."
---
## **Översikt**

Denna artikel förklarar hur du anpassar diagramaxlar i Aspose.Slides. Den visar hur du hämtar faktiska axelvärden, byter data mellan axlar, döljer den vertikala eller horisontella axeln för linjediagram, ändrar kategoriaxelns typ, ställer in datumformatet för kategoriaxelvärden, roterar en axeltitel, ställer in axelns position och visar en enhetsetikett på värdeaxeln.

## **Hämta maxvärdena på den vertikala axeln i diagram**

Aspose.Slides för Java låter dig hämta de minsta och största värdena på en vertikal axel. Följ dessa steg:

1. Skapa en instans av klassen[Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Hämta den första bilden.
1. Lägg till ett diagram med standarddata.
1. Hämta det faktiska maximivärdet på axeln.
1. Hämta det faktiska minimivärdet på axeln.
1. Hämta den faktiska huvudenheten för axeln.
1. Hämta den faktiska underenheten för axeln.
1. Hämta den faktiska skalningen för huvudenheten på axeln.
1. Hämta den faktiska skalningen för underenheten på axeln.

Denna exempelkod—en implementation av stegen ovan—visar hur du hämtar de nödvändiga värdena i Java:

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

Aspose.Slides låter dig snabbt byta data mellan axlar—datat som visas på den vertikala axeln (y-axeln) flyttas till den horisontella axeln (x-axeln) och vice versa.

Denna Java‑kod visar hur du utför datautbytesuppgiften mellan axlar i ett diagram:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Byter rader och kolumner
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

## **Ändra en kategori‑axel**

Genom att använda egenskapen **CategoryAxisType** kan du ange din föredragna kategori‑axeltyp (**date** eller **text**). Denna Java‑kod demonstrerar operationen:

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

## **Ange datumformat för kategori‑axelvärden**

Aspose.Slides för Java låter dig ange datumformatet för ett kategori‑axelvärde. Operationen demonstreras i denna Java‑kod:

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

## **Ange en rotationsvinkel för en diagramaxeltitel**

Aspose.Slides för Java låter dig ange rotationsvinkeln för en diagramaxeltitel. Denna Java‑kod demonstrerar operationen:

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

## **Ange axelposition på en kategori‑ eller värdeaxel**

Aspose.Slides för Java låter dig ange axelns position i en kategori‑ eller värdeaxel. Denna Java‑kod visar hur du utför uppgiften:

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

Aspose.Slides för Java låter dig konfigurera ett diagram så att det visar en enhetsetikett på dess värdeaxel. Denna Java‑kod demonstrerar operationen:

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

Axlarna erbjuder en [crossing setting](https://reference.aspose.com/slides/sv/java/com.aspose.slides/axis/#setCrossType-int-): du kan välja att korsa vid noll, vid den maximala kategori-/värdet eller vid ett specifikt numeriskt värde. Detta är användbart för att flytta X‑axeln upp eller ner eller för att markera en baslinje.

**Hur kan jag placera tick‑etiketter relativt axeln (bredvid, ute, inne)?**

Ställ in [label position](https://reference.aspose.com/slides/sv/java/com.aspose.slides/axis/#setMajorTickMark-int-) till "cross", "outside" eller "inside". Detta påverkar läsbarheten och hjälper till att spara utrymme, särskilt i små diagram.