---
title: Diagrammachse
type: docs
url: /androidjava/chart-axis/
keywords: "PowerPoint Diagrammachse, Präsentationsdiagramme, Java, Diagrammachse manipulieren, Diagrammdaten"
description: "So bearbeiten Sie die Diagrammachse in PowerPoint mit Java"
---


## **Maximale Werte auf der vertikalen Achse von Diagrammen ermitteln**
Aspose.Slides für Android über Java ermöglicht es Ihnen, die minimalen und maximalen Werte auf einer vertikalen Achse zu erhalten. Folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Holen Sie sich den aktuellen maximalen Wert auf der Achse.
1. Holen Sie sich den aktuellen minimalen Wert auf der Achse.
1. Holen Sie sich die tatsächliche Hauptgröße der Achse.
1. Holen Sie sich die tatsächliche Nebenhöhe der Achse.
1. Holen Sie sich den aktuellen Hauptmaßstab der Achse.
1. Holen Sie sich den aktuellen Nebenmaßstab der Achse.

Dieser Beispielcode—eine Implementierung der oben genannten Schritte—zeigt Ihnen, wie Sie die erforderlichen Werte in Java abrufen:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Präsentation speichern
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Daten zwischen Achsen tauschen**
Aspose.Slides ermöglicht es Ihnen, die Daten zwischen Achsen schnell zu tauschen—die auf der vertikalen Achse (y-Achse) dargestellten Daten werden auf die horizontale Achse (x-Achse) verschoben und umgekehrt.

Dieser Java-Code zeigt Ihnen, wie Sie die Datentauschaufgabe zwischen Achsen in einem Diagramm ausführen:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Zeilen und Spalten tauschen
	chart.getChartData().switchRowColumn();

	// Präsentation speichern
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Vertikale Achse für Liniendiagramme deaktivieren**

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

## **Horizontale Achse für Liniendiagramme deaktivieren**

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

## **Kategoriedachse ändern**

Mit der **CategoryAxisType**-Eigenschaft können Sie Ihren bevorzugten Typ der Kategoriewerteachse angeben (**Datum** oder **Text**). Dieser Code in Java demonstriert die Operation:

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

## **Datumformat für den Wert der Kategoriewerteachse festlegen**
Aspose.Slides für Android über Java ermöglicht es Ihnen, das Datumformat für den Wert der Kategoriewerteachse festzulegen. Die Operation wird in diesem Java-Code demonstriert:

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

## **Rotationswinkel für den Titel der Diagrammachse festlegen**
Aspose.Slides für Android über Java ermöglicht es Ihnen, den Rotationswinkel für den Titel der Diagrammachse festzulegen. Dieser Java-Code demonstriert die Operation:

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

## **Achsenposition in einer Kategorie- oder Werteachse festlegen**
Aspose.Slides für Android über Java ermöglicht es Ihnen, die Achsenposition in einer Kategorie- oder Werteachse festzulegen. Dieser Java-Code zeigt, wie Sie die Aufgabe ausführen:

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

## **Aktivieren der Anzeigeeinheit für die Werteachse im Diagramm**
Aspose.Slides für Android über Java ermöglicht es Ihnen, ein Diagramm so zu konfigurieren, dass es ein Einheitenschild auf seiner Werteachse anzeigt. Dieser Java-Code demonstriert die Operation:

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