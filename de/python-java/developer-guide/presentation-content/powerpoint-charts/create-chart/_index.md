---
title: Erstellen oder Aktualisieren von PowerPoint-Präsentationsdiagrammen in Python
linktitle: Diagramme erstellen oder aktualisieren
type: docs
weight: 10
url: /de/python-java/create-chart/
keywords:
- Diagramm hinzufügen
- Diagramm erstellen
- Diagramm bearbeiten
- Diagramm ändern
- Diagramm aktualisieren
- Streudiagramm
- Kuchendiagramm
- Liniendiagramm
- Tree-Map-Diagramm
- Börsendiagramm
- Box- und Whisker-Diagramm
- Trichterdiagramm
- Sunburst-Diagramm
- Histogramm-Diagramm
- Radar-Diagramm
- Mehrkategorien-Diagramm
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erstellen und Anpassen von Diagrammen in PowerPoint-Präsentationen mithilfe von Aspose.Slides für Python über Java. Diagramme hinzufügen, formatieren und bearbeiten mit praktischen Codebeispielen in Python."
---
## **Überblick**

Dieser Artikel bietet eine umfassende Anleitung zum Erstellen und Anpassen von Diagrammen mit Aspose.Slides. Sie lernen, wie Sie programmgesteuert ein Diagramm zu einer Folie hinzufügen, es mit Daten füllen und verschiedene Formatierungsoptionen anwenden, um Ihre spezifischen Designanforderungen zu erfüllen. Im gesamten Artikel illustrieren detaillierte Codebeispiele jeden Schritt, von der Initialisierung der Präsentation und des Diagrammobjekts bis zur Konfiguration von Reihen, Achsen und Legenden. Durch Befolgen dieser Anleitung erhalten Sie ein solides Verständnis dafür, wie Sie die dynamische Diagrammerstellung in Ihre Anwendungen integrieren und den Prozess der Erstellung datengesteuerter Präsentationen optimieren können.

## **Diagramm erstellen**

Diagramme helfen Menschen, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder einem Spreadsheet nicht sofort ersichtlich sind.

**Warum Diagramme erstellen?**

Durch Diagramme können Sie:

* große Datenmengen auf einer einzigen Folie einer Präsentation zusammenfassen, kondensieren oder zusammenfassen
* Muster und Trends in Daten sichtbar machen
* die Richtung und das Momentum von Daten über die Zeit oder in Bezug auf eine spezifische Maßeinheit ableiten
* Ausreißer, Abweichungen, Fehler, unsinnige Daten usw. erkennen
* komplexe Daten kommunizieren oder präsentieren

In PowerPoint können Sie Diagramme über die *Einfügen*-Funktion erstellen, die Vorlagen für die Gestaltung vieler Diagrammtypen bereitstellt. Mit Aspose.Slides können Sie sowohl reguläre Diagramme (basierend auf gängigen Diagrammtypen) als auch benutzerdefinierte Diagramme erstellen.

{{% alert color="info" title="Hinweis" %}}

Um Diagramme zu erstellen, verwenden Sie die [ChartType](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/)‑Klasse. Die Felder in dieser Klasse entsprechen verschiedenen Diagrammtypen.

{{% /alert %}}

### **Gruppierte Säulendiagramme erstellen**

Dieser Abschnitt erläutert, wie Sie gruppierte Säulendiagramme mit Aspose.Slides erstellen. Sie lernen, wie Sie eine Präsentation initialisieren, ein Diagramm hinzufügen und seine Elemente wie Titel, Daten, Reihen, Kategorien und Stil anpassen. Folgen Sie den untenstehenden Schritten, um zu sehen, wie ein Standard‑Gruppiertes‑Säulendiagramm erzeugt wird:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über deren Index.
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie den Typ `ChartType.ClusteredColumn` an.
1. Fügen Sie dem Diagramm einen Titel hinzu.
1. Greifen Sie auf das Daten‑Worksheet des Diagramms zu.
1. Löschen Sie alle Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Wenden Sie eine Füllfarbe auf die Diagramm‑Reihen an.
1. Fügen Sie Beschriftungen zu den Diagramm‑Reihen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code demonstriert, wie ein gruppiertes Säulendiagramm erstellt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt.
presentation = Presentation()
try:
    # Greift auf die erste Folie zu
    slide = presentation.getSlides().get_Item(0)

    # Fügt ein Diagramm mit den Standarddaten hinzu
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # Setzt den Diagrammtitel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Setzt den Index für das Diagrammdatenblatt
    default_worksheet_index = 0

    # Holt das Diagrammdaten‑Worksheet
    workbook = chart.getChartData().getChartDataWorkbook()

    # Löscht die standardmäßig erzeugten Reihen und Kategorien
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Fügt neue Reihen hinzu
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # Fügt neue Kategorien hinzu
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # Nimmt die erste Diagrammreihe
    series = chart.getChartData().getSeries().get_Item(0)

    # Füllt jetzt die Daten der Reihe
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Setzt die Füllfarbe für die Reihe
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # Nimmt die zweite Diagrammreihe
    series = chart.getChartData().getSeries().get_Item(1)

    # Füllt die Daten der Reihe
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Setzt die Füllfarbe für die Reihe
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

    #Erstellt benutzerdefinierte Beschriftungen für jede Kategorie für die neue Reihe
    # Setzt die erste Beschriftung, um den Kategorienamen anzuzeigen
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # Zeigt den Wert für die dritte Beschriftung
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # Speichert die Präsentation mit Diagramm
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Streudiagramme erstellen**
Streudiagramme (auch Scatter‑Plots oder X‑Y‑Diagramme genannt) werden häufig verwendet, um Muster zu prüfen oder Korrelationen zwischen zwei Variablen zu zeigen.

Verwenden Sie ein Streudiagramm, wenn:

* Sie paarweise numerische Daten haben
* Sie zwei Variablen haben, die gut zusammenpassen
* Sie bestimmen möchten, ob zwei Variablen miteinander verbunden sind
* Sie eine unabhängige Variable haben, die für eine abhängige Variable mehrere Werte besitzt

1. Folgen Sie den Schritten in [Create Clustered Column Charts](#create-clustered-column-charts).
2. Für den dritten Schritt fügen Sie ein Diagramm mit einigen Daten hinzu und geben Ihren Diagrammtyp als einen der folgenden an:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _Stellt ein Streudiagramm dar._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Stellt ein Streudiagramm dar, das durch Kurven verbunden ist, mit Daten‑Markern._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Stellt ein Streudiagramm dar, das durch Kurven verbunden ist, ohne Daten‑Marker._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Stellt ein Streudiagramm dar, das durch gerade Linien verbunden ist, mit Daten‑Markern._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Stellt ein Streudiagramm dar, das durch gerade Linien verbunden ist, ohne Daten‑Marker._

Dieser Python‑Code zeigt, wie man ein Streudiagramm mit unterschiedlichen Markern für jede Reihe erstellt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

# Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt.
presentation = Presentation()
try:
    # Greift auf die erste Folie zu
    slide = presentation.getSlides().get_Item(0)

    # Erstellt das Standarddiagramm
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # Ermittelt den Index des Standard‑Diagrammdaten‑Worksheets
    default_worksheet_index = 0

    # Holt das Diagrammdaten‑Worksheet
    workbook = chart.getChartData().getChartDataWorkbook()

    # Löscht die Demo‑Reihe
    chart.getChartData().getSeries().clear()

    # Fügt neue Reihen hinzu
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Nimmt die erste Diagrammreihe
    series = chart.getChartData().getSeries().get_Item(0)

    # Fügt der Reihe einen neuen Punkt (1:3) hinzu
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Fügt einen neuen Punkt (2:10) hinzu
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Ändert den Reihen‑Typ
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # Ändert den Diagrammreihen‑Marker
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # Nimmt die zweite Diagrammreihe
    series = chart.getChartData().getSeries().get_Item(1)

    # Fügt dort einen neuen Punkt (5:2) hinzu
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Fügt einen neuen Punkt (3:1) hinzu
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Fügt einen neuen Punkt (2:2) hinzu
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Fügt einen neuen Punkt (5:1) hinzu
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Ändert den Diagrammreihen‑Marker
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kuchendiagramme erstellen**

Kuchendiagramme eignen sich am besten, um das Teil‑zu‑Ganzes‑Verhältnis in Daten darzustellen, insbesondere wenn die Daten kategoriale Beschriftungen mit numerischen Werten enthalten. Sollten Ihre Daten jedoch viele Teile oder Beschriftungen enthalten, sollten Sie stattdessen ein Balkendiagramm in Betracht ziehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben den Typ [ChartType.Pie](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#Pie) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
8. Fügen Sie neue Punkte für das Diagramm hinzu und wenden benutzerdefinierte Farben für die Sektoren des Kuchendiagramms an.
9. Setzen Sie Beschriftungen für die Reihen.
10. Aktivieren Sie Führungslinien für die Reihenbeschriftungen.
11. Setzen Sie den Rotationswinkel für die Sektoren des Kuchendiagramms.
12. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Kuchendiagramm erstellt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt.
presentation = Presentation()
try:
    # Greift auf die erste Folie zu
    slide = presentation.getSlides().get_Item(0)

    # Fügt ein Diagramm mit Standarddaten hinzu
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Setzt den Diagrammtitel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Setzt den Index für das Diagrammdaten‑Blatt
    default_worksheet_index = 0

    # Holt das Diagrammdaten‑Worksheet
    workbook = chart.getChartData().getChartDataWorkbook()

    # Löscht die standardmäßig erzeugten Reihen und Kategorien
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Fügt neue Kategorien hinzu
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # Fügt neue Reihen hinzu
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    #Füllt die Reihen‑Daten
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # Neue Punkte hinzufügen und Sektorfarbe festlegen
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # Setzt den Sektorrand
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # Setzt den Sektorrand
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # Setzt den Sektorrand
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # Erstellt benutzerdefinierte Beschriftungen für jede Kategorie der neuen Reihe
    first_label = series.getDataPoints().get_Item(0).getLabel()
    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # Zeigt Führungs-Linien für das Diagramm
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # Setzt den Rotationswinkel für Kuchendiagramm‑Sektoren
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # Speichert die Präsentation mit einem Diagramm
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Liniendiagramme erstellen**

Liniendiagramme (auch Liniendiagramme genannt) eignen sich am besten, wenn Sie Änderungen des Werts über die Zeit darstellen möchten. Mit einem Liniendiagramm können Sie große Datenmengen gleichzeitig vergleichen, Änderungen und Trends über die Zeit verfolgen, Anomalien in Datenreihen hervorheben und mehr.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über deren Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben den Typ [ChartType.Line](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#Line) an.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Liniendiagramm erstellt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Standardmäßig werden Punkte in einem Liniendiagramm durch gerade kontinuierliche Linien verbunden. Wenn Sie stattdessen gestrichelte Linien wünschen, können Sie den gewünschten Strich‑Typ wie folgt angeben:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tree‑Map‑Diagramme erstellen**

Tree‑Map‑Diagramme eignen sich am besten für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien darstellen und schnell auf Elemente aufmerksam machen möchten, die innerhalb jeder Kategorie große Beiträge leisten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben den Typ [ChartType.Treemap](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#Treemap) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
8. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Tree‑Map‑Diagramm erstellt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #Zweig 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #Zweig 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Börsendiagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben den Typ [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#OpenHighLowClose) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
8. Geben Sie das Format für Hoch‑Niedrig‑Linien an.
9. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Börsendiagramm erstellt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(1)
    cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(2)
    cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(3)
    cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for series in chart.getChartData().getSeries():
        series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Box‑ und Whisker‑Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben den Typ [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#BoxAndWhisker) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
8. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Box‑ und Whisker‑Diagramm erstellt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 1")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Trichter‑Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben den Typ [ChartType.Funnel](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#Funnel) an.
4. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Trichter‑Diagramm erstellt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Sunburst‑Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben den Typ [ChartType.Sunburst](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#Sunburst) an.
4. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Sunburst‑Diagramm erstellt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #Zweig 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #Zweig 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Histogramm‑Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben den Typ [ChartType.Histogram](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#Histogram) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Histogramm‑Diagramm erstellt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    cell = workbook.getCell(0, "A1", 15)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A2", -41)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A3", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A4", 10)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A5", -23)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A6", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic)

    presentation.save("Histogram.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Radar‑Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Ihren bevorzugten Diagrammtyp ([ChartType.Radar](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#Radar) in diesem Fall) an.
4. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Radar‑Diagramm erstellt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300)
    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Multi‑Kategorien‑Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben den Typ [ChartType.ClusteredColumn](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#ClusteredColumn) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
8. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Multi‑Kategorien‑Diagramm erstellt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450)
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)
    default_worksheet_index = 0

    cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(cell)

    # Reihen hinzufügen
    cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(cell, ChartType.ClusteredColumn)

    cell = workbook.getCell(default_worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Präsentation mit Diagramm speichern
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Karten‑Diagramme erstellen**

Karten‑Diagramme visualisieren geografische Daten und helfen, Werte über Regionen hinweg zu vergleichen.

Dieser Python‑Code zeigt, wie ein Karten‑Diagramm erstellt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400)
    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kombinations‑Diagramme erstellen**

Ein Kombinations‑Diagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Diagramm. Dieses Diagramm ermöglicht es Ihnen, Unterschiede zwischen zwei oder mehr Datensätzen hervorzuheben, zu vergleichen oder zu untersuchen und so Beziehungen zwischen ihnen zu erkennen.

![The combination chart](combination_chart.png)

Der folgende Python‑Code zeigt, wie das oben gezeigte Kombinations‑Diagramm in einer PowerPoint‑Präsentation erstellt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # Setze den Diagrammtitel.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Setze die Diagrammlegende.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # Lösche die standardmäßig erzeugten Reihen und Kategorien.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # Neue Kategorien hinzufügen.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # Die erste Reihe hinzufügen.
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # Setze die horizontale Achse.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # Setze die vertikale Achse.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # Setze die Farbe der vertikalen Hauptgitterlinien.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # Setze die sekundäre horizontale Achse.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Setze die sekundäre vertikale Achse.
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **Diagramme aktualisieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse, die die Präsentation mit dem zu aktualisierenden Diagramm darstellt.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Durchsuchen Sie alle Shapes, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf das Daten‑Worksheet des Diagramms zu.
5. Ändern Sie die Werte der Diagramm‑Reihen, um die Daten zu modifizieren.
6. Fügen Sie eine neue Reihe hinzu und füllen Sie deren Daten.
7. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Diagramm aktualisiert wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Öffnet die Präsentation, die das zu aktualisierende Diagramm enthält
presentation = Presentation("ExistingChart.pptx")
try:
    # Greift auf die erste Folie zu
    slide = presentation.getSlides().get_Item(0)

    # Holt das Diagramm von der Folie
    chart = slide.getShapes().get_Item(0)

    # Setzt den Index des Diagrammdatenblatts
    default_worksheet_index = 0

    # Holt das Diagrammdaten‑Worksheet
    workbook = chart.getChartData().getChartDataWorkbook()

    # Ändert den Diagramm‑Kategorienamen
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # Nimmt die erste Diagrammreihe
    series = chart.getChartData().getSeries().get_Item(0)

    # Aktualisiert nun die Daten der Reihe
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# Ändert den Reihen-Namen
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # Nimmt die zweite Diagrammreihe
    series = chart.getChartData().getSeries().get_Item(1)

    # Aktualisiert nun die Daten der Reihe
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# Ändert den Reihen-Namen
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # Fügt nun eine neue Reihe hinzu
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Nimmt die dritte Diagrammreihe
    series = chart.getChartData().getSeries().get_Item(2)

    # Befüllt nun die Daten der Reihe
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # Speichert die Präsentation mit dem Diagramm
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Datenbereich für ein Diagramm festlegen**

Um den Datenbereich für ein Diagramm festzulegen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse, die die Präsentation mit dem Diagramm darstellt.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Durchsuchen Sie alle Shapes, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf die Diagrammdaten zu und setzen Sie den Bereich.
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie der Datenbereich für ein Diagramm festgelegt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Öffnet die Präsentation, die das Diagramm enthält
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Standard‑Marker in Diagrammen verwenden**

Wenn Sie Standard‑Marker in Diagrammen verwenden, erhält jede Diagramm‑Reihe automatisch ein unterschiedliches Markersymbol.

Dieser Python‑Code zeigt, wie ein Diagramm‑Reihen‑Marker automatisch gesetzt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(cell)

    cell = workbook.getCell(0, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())
    #Nimm die zweite Diagrammreihe
    second_series = chart.getChartData().getSeries().get_Item(1)

    #Jetzt fülle die Daten der Reihe
    cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Welche Diagrammtypen werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt eine breite Palette von [Diagrammtypen](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/), darunter Balken, Linien, Kuchen, Flächen, Streu, Histogramm, Radar und viele mehr. Diese Flexibilität ermöglicht die Auswahl des am besten geeigneten Diagrammtyps für Ihre Datenvisualisierungsanforderungen.

**Wie füge ich ein neues Diagramm zu einer Folie hinzu?**

Um ein Diagramm hinzuzufügen, erstellen Sie zunächst eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse, holen die gewünschte Folie über deren Index und rufen dann die Methode zum Hinzufügen eines Diagramms auf, wobei Sie den Diagrammtyp und die Anfangsdaten angeben. Dieser Vorgang integriert das Diagramm direkt in Ihre Präsentation.

**Wie kann ich die in einem Diagramm angezeigten Daten aktualisieren?**

Sie können die Diagrammdaten aktualisieren, indem Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/)) zugreifen, alle Standard‑Reihen und -Kategorien löschen und anschließend Ihre eigenen Daten hinzufügen. So können Sie das Diagramm aktualisieren, um die neuesten Daten wiederzugeben.

**Ist es möglich, das Aussehen des Diagramms anzupassen?**

Ja, Aspose.Slides bietet umfangreiche Anpassungsoptionen. Sie können Farben, Schriftarten, Beschriftungen, Legenden und andere [Formatierungselemente](/slides/de/python-java/chart-entities/) ändern, um das Aussehen des Diagramms an Ihre spezifischen Designanforderungen anzupassen.