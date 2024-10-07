---
title: Diagrammachse
type: docs
url: /java/chart-axis/
keywords: "PowerPoint Diagrammachse, Präsentationsdiagramme, Java, Diagrammachse manipulieren, Diagrammdaten"
description: "Wie man die Diagrammachse von PowerPoint in Java bearbeitet"
---


## **Maximalwerte der vertikalen Achse in Diagrammen erhalten**
Aspose.Slides für Java ermöglicht es Ihnen, die Minimal- und Maximalwerte einer vertikalen Achse zu erhalten. Gehen Sie diese Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Holen Sie den tatsächlichen Maximalwert der Achse.
1. Holen Sie den tatsächlichen Minimalwert der Achse.
1. Holen Sie die tatsächliche Hauptintervalleinheit der Achse.
1. Holen Sie die tatsächliche Nebenintervalleinheit der Achse.
1. Holen Sie den tatsächlichen Hauptintervallmaßstab der Achse.
1. Holen Sie den tatsächlichen Nebenintervallmaßstab der Achse.

Dieser Beispielcode—eine Implementierung der obigen Schritte—zeigt Ihnen, wie Sie die erforderlichen Werte in Java erhalten:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Speichert die Präsentation
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Daten zwischen Achsen tauschen**
Aspose.Slides ermöglicht es Ihnen, die Daten zwischen Achsen schnell zu tauschen—die auf der vertikalen Achse (y-Achse) dargestellten Daten wechseln zur horizontalen Achse (x-Achse) und umgekehrt.

Dieser Java-Code zeigt Ihnen, wie Sie die Datentauschaufgabe zwischen den Achsen eines Diagramms durchführen:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Wechselt Zeilen und Spalten
	chart.getChartData().switchRowColumn();

	// Speichert die Präsentation
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Die vertikale Achse für Liniendiagramme deaktivieren**

Dieser Java-Code zeigt Ihnen, wie Sie die vertikale Achse für ein Liniendiagramm ausblenden:

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

## **Die horizontale Achse für Liniendiagramme deaktivieren**

Dieser Code zeigt Ihnen, wie Sie die horizontale Achse für ein Liniendiagramm ausblenden:

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

## **Kategoriewechsel der Achse**

Mit der **CategoryAxisType**-Eigenschaft können Sie Ihren bevorzugten Kategorietyp für die Achse angeben (**Datum** oder **Text**). Dieser Code in Java demonstriert die Funktion:

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

## **Das Datumsformat für den Kategoriewert der Achse festlegen**
Aspose.Slides für Java ermöglicht es Ihnen, das Datumsformat für einen Kategoriewert der Achse festzulegen. Die Operation wird in diesem Java-Code demonstriert:

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

## **Den Rotationswinkel für den Titel der Diagrammachse festlegen**
Aspose.Slides für Java ermöglicht es Ihnen, den Rotationswinkel für den Titel einer Diagrammachse festzulegen. Dieser Java-Code demonstriert die Operation:

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

## **Die Position der Achse in einer Kategorie- oder Wertachse festlegen**
Aspose.Slides für Java ermöglicht es Ihnen, die Position der Achse in einer Kategorie- oder Wertachse festzulegen. Dieser Java-Code zeigt, wie die Aufgabe durchgeführt wird:

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

## **Aktivieren des Anzeigeeinheitslabels auf der Diagrammwertachse**
Aspose.Slides für Java ermöglicht es Ihnen, ein Diagramm so zu konfigurieren, dass es ein Einheitsetikett auf seiner Diagrammwertachse anzeigt. Dieser Java-Code demonstriert die Operation:

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