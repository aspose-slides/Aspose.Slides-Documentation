---
title: Diagrammachsen in Präsentationen mit Java anpassen
linktitle: Diagrammachse
type: docs
url: /de/java/chart-axis/
keywords:
- Diagrammachse
- vertikale Achse
- horizontale Achse
- Achse anpassen
- Achse manipulieren
- Achse verwalten
- Achseneigenschaften
- maximaler Wert
- minimaler Wert
- Achsenlinie
- Datumsformat
- Achsentitel
- Achsenposition
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für Java verwenden, um Diagrammachsen in PowerPoint-Präsentationen für Berichte und Visualisierungen anzupassen."
---

## **Maximale Werte auf der vertikalen Achse in Diagrammen ermitteln**
Aspose.Slides für Java ermöglicht das Abrufen der Minimal- und Maximalwerte einer vertikalen Achse. Führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Ermitteln Sie den tatsächlichen Maximalwert der Achse.
5. Ermitteln Sie den tatsächlichen Minimalwert der Achse.
6. Ermitteln Sie die tatsächliche Haupteinheit der Achse.
7. Ermitteln Sie die tatsächliche Nebeneinheit der Achse.
8. Ermitteln Sie die tatsächliche Skalierung der Haupteinheit der Achse.
9. Ermitteln Sie die tatsächliche Skalierung der Nebeneinheit der Achse.

Dieser Beispielcode – eine Umsetzung der oben genannten Schritte – zeigt, wie Sie die erforderlichen Werte in Java erhalten:
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


## **Daten zwischen Achsen austauschen**
Aspose.Slides ermöglicht das schnelle Austauschen von Daten zwischen Achsen – die Daten, die auf der vertikalen Achse (Y‑Achse) dargestellt werden, werden auf die horizontale Achse (X‑Achse) verschoben und umgekehrt.

Dieser Java‑Code zeigt, wie Sie den Datenaustausch zwischen Achsen in einem Diagramm durchführen:
```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Wechselt Zeilen und Spalten
	// Speichert die Präsentation
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **Vertikale Achse für Liniendiagramme deaktivieren**
Dieser Java‑Code zeigt, wie Sie die vertikale Achse für ein Liniendiagramm ausblenden:
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
Dieser Code zeigt, wie Sie die horizontale Achse für ein Liniendiagramm ausblenden:
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


## **Kategorieachse ändern**
Mit der Eigenschaft **CategoryAxisType** können Sie den gewünschten Typ der Kategorieachse (**date** oder **text**) festlegen. Dieser Java‑Code demonstriert die Vorgehensweise:
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


## **Datumsformat für Werte der Kategorieachse festlegen**
Aspose.Slides für Java ermöglicht das Festlegen des Datumsformats für einen Wert der Kategorieachse. Die Vorgehensweise wird in diesem Java‑Code demonstriert:
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


## **Rotationswinkel für einen Diagrammachsentitel festlegen**
Aspose.Slides für Java ermöglicht das Festlegen des Rotationswinkels für einen Diagrammachsentitel. Dieser Java‑Code demonstriert die Vorgehensweise:
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


## **Achsenposition auf einer Kategorien‑ oder Werteachse festlegen**
Aspose.Slides für Java ermöglicht das Festlegen der Achsenposition in einer Kategorien‑ oder Werteachse. Dieser Java‑Code zeigt, wie die Aufgabe ausgeführt wird:
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


## **Anzeigeeinheits‑Beschriftung auf der Werteachse eines Diagramms aktivieren**
Aspose.Slides für Java ermöglicht die Konfiguration eines Diagramms, damit eine Einheit­beschriftung auf seiner Werteachse angezeigt wird. Dieser Java‑Code demonstriert die Vorgehensweise:
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

**Wie setze ich den Wert, an dem eine Achse die andere schneidet (Achsenkreuzung)?**

Achsen bieten eine [crossing setting](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-): Sie können wählen, bei Null, beim maximalen Kategorien‑/Wert‑Punkt oder bei einem bestimmten numerischen Wert zu kreuzen. Dies ist nützlich, um die X‑Achse nach oben oder unten zu verschieben oder eine Grundlinie hervorzuheben.

**Wie kann ich die Achsenbeschriftungen relativ zur Achse positionieren (neben, außen, innen)?**

Stellen Sie die [label position](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) auf "cross", "outside" oder "inside" ein. Dies beeinflusst die Lesbarkeit und hilft, Platz zu sparen, besonders bei kleinen Diagrammen.