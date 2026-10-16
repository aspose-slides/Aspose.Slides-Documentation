---
title: PowerPoint-Präsentationsdiagramme in Python erstellen oder aktualisieren
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
- Scatterdiagramm
- Kreisdiagramm
- Liniendiagramm
- Tree-Map-Diagramm
- Börsendiagramm
- Box-and-Whisker-Diagramm
- Trichterdiagramm
- Sunburst-Diagramm
- Histogramm-Diagramm
- Radar-Diagramm
- Mehrkategorie-Diagramm
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erstellen und Anpassen von Diagrammen in PowerPoint-Präsentationen mit Aspose.Slides für Python via Java. Diagramme hinzufügen, formatieren und bearbeiten mit praktischen Code-Beispielen in Python."
---
## **Übersicht**

Dieser Artikel bietet eine umfassende Anleitung, wie man Diagramme mit Aspose.Slides für Python via Java erstellt und anpasst. Sie lernen, wie man programmgesteuert ein Diagramm zu einer Folie hinzufügt, es mit Daten füllt und verschiedene Formatierungsoptionen anwendet, um Ihre speziellen Designanforderungen zu erfüllen. Im gesamten Artikel veranschaulichen detaillierte Codebeispiele jeden Schritt, vom Initialisieren der Präsentation und des Diagramm‑Objekts bis hin zur Konfiguration von Serien, Achsen und Legenden. Durch Befolgen dieser Anleitung erhalten Sie ein solides Verständnis dafür, wie Sie die dynamische Diagrammerstellung in Ihre Python‑Anwendungen integrieren und den Prozess der Erstellung datengetriebener Präsentationen optimieren.

## **Diagramm erstellen**

Diagramme helfen Personen, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder einem Spreadsheet nicht sofort ersichtlich sind.

**Warum Diagramme erstellen?**

Mit Diagrammen können Sie:

* große Datenmengen auf einer einzigen Folie in einer Präsentation aggregieren, kondensieren oder zusammenfassen;
* Muster und Trends in den Daten aufdecken;
* die Richtung und das Momentum der Daten über die Zeit oder in Bezug auf eine bestimmte Maßeinheit ableiten;
* Ausreißer, Aberrationen, Abweichungen, Fehler und unsinnige Daten erkennen;
* komplexe Daten kommunizieren oder präsentieren.

In PowerPoint können Sie Diagramme über die *Einfügen*-Funktion erstellen, die Vorlagen für die Gestaltung vieler Diagrammtypen bereitstellt. Mit Aspose.Slides können Sie sowohl reguläre Diagramme (basierend auf gängigen Diagrammtypen) als auch benutzerdefinierte Diagramme erzeugen.

{{% alert color="info" title="Note" %}}
Verwenden Sie die [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/)‑Aufzählung im [asposeslides.api](https://reference.aspose.com/slides/python-java/aspose.slides/)‑Paket. Die Werte dieser Aufzählung entsprechen verschiedenen Diagrammtypen.
{{% /alert %}}

### **Gestapelte Säulendiagramme erstellen**

Dieses Beispiel verwendet [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart), um ein gruppiertes Säulendiagramm zu erstellen, das zwei Serien über drei Kategorien vergleicht. Die Serien verwenden rote bzw. grüne Füllungen, und einzelne Beschriftungen zeigen Kategorienamen, Seriennamen und Werte an. Der Arbeitsblatt‑Index 0 bezieht sich auf das erste Blatt im eingebetteten Diagramm‑Arbeitsbuch.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())
    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    category_cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().get_Item(0)

    value_cell = workbook.getCell(worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    series = chart.getChartData().getSeries().get_Item(1)

    value_cell = workbook.getCell(worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    series.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    series.getFormat().getFill().getSolidFillColor().setColor(color)

    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The Clustered Column chart](clustered_column_chart.png)

### **Scatter‑Diagramme erstellen**

Scatter‑Diagramme (auch Punkt‑Diagramme oder X‑Y‑Grafiken genannt) werden häufig verwendet, um Muster zu prüfen oder Korrelationen zwischen zwei Variablen zu zeigen.

Verwenden Sie ein Scatter‑Diagramm, wenn:

* Sie gepaarte numerische Daten haben.
* Sie zwei Variablen besitzen, die gut zusammenpassen.
* Sie bestimmen möchten, ob die beiden Variablen miteinander verbunden sind.
* Sie eine unabhängige Variable haben, die für eine abhängige Variable mehrere Werte liefert.

Dieses Beispiel zeichnet zwei Sätze von X‑Y‑Werten. Die erste Serie verwendet gerade Linien mit Stern‑Markern, während die zweite glatte Linien mit Kreis‑Markern nutzt; beide verwenden eine Marker‑Größe von 10, konfiguriert mit [setSize](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSize). Die [setSymbol](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSymbol)‑Methode steuert die Form des Markers.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()

    series_name_cell = workbook.getCell(worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())
    series_name_cell = workbook.getCell(worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    x_value_cell = workbook.getCell(worksheet_index, 2, 1, 1)
    y_value_cell = workbook.getCell(worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 3, 1, 2)
    y_value_cell = workbook.getCell(worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    series = chart.getChartData().getSeries().get_Item(1)

    x_value_cell = workbook.getCell(worksheet_index, 2, 3, 5)
    y_value_cell = workbook.getCell(worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 3, 3, 3)
    y_value_cell = workbook.getCell(worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 4, 3, 2)
    y_value_cell = workbook.getCell(worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 5, 3, 5)
    y_value_cell = workbook.getCell(worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The Scatter chart](scatter_chart.png)

### **Kreisdiagramme erstellen**

Kreisdiagramme eignen sich am besten, um das Teil‑zu‑Ganz‑Verhältnis in Daten darzustellen, insbesondere wenn die Daten kategoriale Beschriftungen mit numerischen Werten enthalten. Wenn Ihre Daten jedoch viele Teile oder Beschriftungen besitzen, sollten Sie stattdessen ein Balkendiagramm in Erwägung ziehen.

Dieses Beispiel erstellt ein Kreisdiagramm mit drei Quartalswerten. Jeder Abschnitt hat eine benutzerdefinierte Füllung und Rand, und die Beschriftungen zeigen verschiedene Kombinationen von Werten, Prozentanteilen und Serieninformationen. Die [setFirstSliceAngle](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setFirstSliceAngle)‑Methode setzt den ersten Abschnitt auf einen Startwinkel von 180 Grad.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 20, 20, 500, 300)

    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    category_cell = workbook.getCell(0, 1, 0, "1st Qtr")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    value_cell = workbook.getCell(worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(value_cell)

    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    first_slice = series.getDataPoints().get_Item(0)
    first_slice.getFormat().getFill().setFillType(FillType.Solid)
    first_slice.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    first_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    first_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    first_slice.getFormat().getLine().setWidth(3.0)
    first_slice.getFormat().getLine().setStyle(LineStyle.ThinThick)
    first_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDash)

    second_slice = series.getDataPoints().get_Item(1)
    second_slice.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(165, 42, 42)
    second_slice.getFormat().getFill().getSolidFillColor().setColor(color)

    second_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_slice.getFormat().getLine().setWidth(3.0)
    second_slice.getFormat().getLine().setStyle(LineStyle.Single)
    second_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_slice = series.getDataPoints().get_Item(2)
    third_slice.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(255, 127, 80)
    third_slice.getFormat().getFill().getSolidFillColor().setColor(color)

    third_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_slice.getFormat().getLine().setWidth(2.0)
    third_slice.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    first_label = series.getDataPoints().get_Item(0).getLabel()
    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    presentation.save("PieChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The Pie chart](pie_chart.png)

Um die Lesbarkeit von Beschriftungen außerhalb des Kreises zu verbessern, siehe [Format Leader Lines](/slides/de/python-java/chart-data-label/#format-leader-lines) für ein Beispiel, das Beschriftungen positioniert und Linienfarbe, -breite, -transparenz und Strichstil anpasst.

### **Liniendiagramme erstellen**

Liniendiagramme (auch Liniendiagramme genannt) eignen sich am besten, wenn Sie Änderungen von Werten über die Zeit demonstrieren möchten. Mit einem Liniendiagramm können Sie eine große Datenmenge auf einmal vergleichen, Veränderungen und Trends über die Zeit verfolgen, Anomalien in Datenreihen hervorheben und vieles mehr.

Dieses Beispiel verwendet [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart), um ein Liniendiagramm mit den Standard‑Serien und -Kategorien zu erstellen und speichert die Präsentation als PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    line_chart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Standardmäßig werden Punkte in einem Liniendiagramm durch gerade, durchgezogene Linien verbunden. Wenn Sie die Punkte stattdessen mit Strichen verbinden möchten, rufen Sie [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) mit einem Wert aus [LineDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) auf:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    line_chart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The Line chart](line_chart.png)

### **Tree‑Map‑Diagramme erstellen**

Tree‑Map‑Diagramme eignen sich am besten für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien zeigen und schnell die Elemente hervorheben wollen, die große Beiträge innerhalb einer Kategorie leisten.

Dieses Beispiel erstellt eine Tree‑Map mit acht Blättern, gruppiert in vier Stämmen und zwei Ästen. Die [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem)‑Methode ordnet Stämme Ebene 1 und Äste Ebene 2 zu. Werte bestimmen die relative Rechteckgröße, während Kategoriebeschriftungen und überlappende Eltern‑Beschriftungen die Hierarchie kennzeichnen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Treemap, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Zweig 1
    category_cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    category_cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    category_cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(category_cell)

    # Zweig 2
    category_cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    category_cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    category_cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    value_cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The Treemap chart](treemap_chart.png)

### **Wasserfall‑Diagramme erstellen**

Ein Wasserfall‑Diagramm zeigt, wie positive und negative Änderungen zu einem Endwert beitragen. Zum Beispiel kann eine Gewinn‑Aufschlüsselung mit Umsatz beginnen, Kosten abziehen und andere Einnahmen hinzufügen. Änderungs‑Spalten schweben zwischen dem vorherigen und dem neuen laufenden Wert, während Gesamtsäulen von Null bis zum akkumulierten Wert reichen.

Das folgende Beispiel verwendet Beträge in Tausend US‑Dollar:

| Kategorie | Arbeitsbuchwert | Spaltentyp |
| --- | ---: | --- |
| Umsatz | 1000 | Increase |
| Produktionskosten | -400 | Decrease |
| Bruttogewinn | 600 | Intermediate total |
| Betriebskosten | -200 | Decrease |
| Sonstige Erträge | 50 | Increase |
| Nettoergebnis | 450 | Final total |

Um einen Punkt als Zwischensumme oder Endsumme zu kennzeichnen, rufen Sie dessen [setSetAsTotal](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setSetAsTotal)‑Methode mit `True` auf. Geben Sie den tatsächlichen akkumulierten Betrag in der Arbeitsbuchzelle dieses Punktes an: `600` für den Bruttogewinn (`1000 - 400`) und `450` für das Nettoergebnis (`600 - 200 + 50`). Die Methode markiert die Spalte als Summe; sie berechnet oder füllt den Zellenwert nicht. Verwenden Sie nicht Null als Platzhalter und geben Sie keinen anderen Änderungswert für einen Summen‑Punkt an. Eine Gesamtsäule zeigt den akkumulierten Wert ohne ihn erneut zum laufenden Wert hinzuzufügen.

Dieses vollständige Python‑Beispiel erstellt ein Diagramm mit dem `Waterfall`‑Mitglied von [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/), löscht die Standarddaten und füllt das eingebettete Arbeitsbuch. Der Arbeitsblatt‑Index `0` wählt das erste Arbeitsblatt; Spalte A enthält Kategorienamen und Spalte B die Werte. Jede Wertzelle wird mit [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#addDataPointForWaterfallSeries) hinzugefügt. Die nullbasierten Punktindizes `2` und `5` identifizieren die Zwischensumme bzw. die Endsumme. Durch Aufruf von [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) mit `True` werden die Beträge auf den Spalten angezeigt. Es wird keine Eingabe‑Präsentation oder kein Arbeitsbuch benötigt.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Waterfall, 20, 20, 680, 200)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Profit breakdown (USD thousands)")
    chart.getChartTitle().setOverlay(False)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    workbook.clear(worksheet_index)

    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Profit")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Waterfall)
    categories = ["Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit"]
    values = [1000, -400, 600, -200, 50, 450]

    for i in range(len(categories)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, categories[i])
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(worksheet_index, i + 1, 1, values[i])
        series.getDataPoints().addDataPointForWaterfallSeries(value_cell)

    # Die dritten und sechsten Punkte repräsentieren Summen, nicht zusätzliche Änderungen.
    series.getDataPoints().get_Item(2).setSetAsTotal(True)
    series.getDataPoints().get_Item(5).setSetAsTotal(True)
    series.setShowConnectorLines(True)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("WaterfallChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Rufen Sie die Serien‑Methode [setShowConnectorLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setShowConnectorLines) mit `True` auf, um Linien zwischen aufeinanderfolgenden Spalten anzuzeigen und den laufenden Wert leichter nachvollziehbar zu machen. Um diese Linien auszublenden, ersetzen Sie den Methodenaufruf im Beispiel durch `series.setShowConnectorLines(False)` vor dem Speichern. Dies ändert nur die Sichtbarkeit der Linien, nicht die Daten oder Summen.

Die gespeicherte Präsentation zeigt einen Bruttogewinn von 600 und ein Nettoergebnis von 450, wobei beide Summen von 0 ausgehend gezeichnet werden:

![Waterfall chart showing revenue, costs, gross profit of 600, and net profit of 450, with value labels and connector lines](waterfall_chart.png)

### **Börsen‑Diagramme erstellen**

Börsen‑Diagramme werden verwendet, um Finanzdaten wie Eröffnungs‑, Hoch‑, Tief‑ und Schlusskurse darzustellen und Markttrends sowie Volatilität zu analysieren. Sie bieten wesentliche Einblicke in die Kursentwicklung und unterstützen Investoren und Analysten bei fundierten Entscheidungen.

Dieses Beispiel erstellt ein Open‑High‑Low‑Close‑Diagramm mit vier Serien in dieser Reihenfolge und drei Kategorien. Die [setUpDownBars](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#setUpDownBars)‑Methode aktiviert Auf‑/Ab‑Balken, und [getHiLowLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getHiLowLinesFormat) steuert die Hoch‑Tief‑Linien, die die Preisbereiche anzeigen, während die einzelnen Serien‑Linien und die feinen horizontalen Gitternetzlinien ausgeblendet werden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, False)

    workbook = chart.getChartData().getChartDataWorkbook()

    category_cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)

    series = chart.getChartData().getSeries().get_Item(0)
    value_cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(1)
    value_cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(2)
    value_cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(3)
    value_cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for stock_series in chart.getChartData().getSeries():
        stock_series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("Stock-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The Stock chart](stock_chart.png)

### **Box‑and‑Whisker‑Diagramme erstellen**

Box‑and‑Whisker‑Diagramme werden verwendet, um die Verteilung von Daten durch Zusammenfassung wichtiger statistischer Kennzahlen wie Median, Quartile und mögliche Ausreißer darzustellen. Sie sind besonders nützlich in der explorativen Datenanalyse und bei statistischen Studien, um die Datenvariabilität schnell zu verstehen und Anomalien zu identifizieren.

Dieses Beispiel erstellt ein Box‑and‑Whisker‑Diagramm aus sechs Werten. Die [setQuartileMethod](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setQuartileMethod)‑Methode wählt die exklusive Quartilsberechnung. Das Beispiel aktiviert außerdem Mittelwert‑Linien, Mittelwert‑Marker, innere Punkte und Ausreißer‑Punkte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.BoxAndWhisker, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    value_cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Trichter‑Diagramme erstellen**

Trichter‑Diagramme werden verwendet, um Prozesse mit sequenziellen Stufen zu visualisieren, bei denen das Datenvolumen von einem Schritt zum nächsten abnimmt. Sie sind besonders hilfreich zur Analyse von Konversionsraten, zur Identifizierung von Engpässen und zur Verfolgung der Effizienz von Vertriebs‑ oder Marketing‑Prozessen.

Dieses Beispiel verwendet [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart), um einem bestehenden Präsentations‑Slide ein Trichter‑Diagramm hinzuzufügen. Es ersetzt die Standarddaten durch sechs Kategorien und Werte von 50 bis 500 und speichert die aktualisierte Präsentation. Die Eingabe‑Präsentation muss mindestens eine Folie enthalten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    value_cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The Funnel chart](funnel_chart.png)

### **Sunburst‑Diagramme erstellen**

Sunburst‑Diagramme werden verwendet, um hierarchische Daten zu visualisieren, wobei Ebenen als konzentrische Ringe dargestellt werden. Sie veranschaulichen Teil‑zu‑Ganz‑Beziehungen und eignen sich ideal zur Darstellung verschachtelter Kategorien und Unterkategorien in einem klaren, kompakten Format.

Dieses Beispiel erstellt ein Sunburst‑Diagramm mit acht Blättern, gruppiert in vier Stämmen und zwei Ästen. Die [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem)‑Methode ordnet Stämme Ebene 1 und Äste Ebene 2 zu. Kategoriebeschriftungen identifizieren die Segmente, und die Werte bestimmen ihre relative Größe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Sunburst, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Zweig 1
    category_cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    category_cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    category_cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(category_cell)

    # Zweig 2
    category_cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    category_cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    category_cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    value_cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The Sunburst chart](sunburst_chart.png)

### **Histogramm‑Diagramme erstellen**

Histogramm‑Diagramme zeigen, wie numerische Werte über Intervalle (Bins) verteilt sind. Für Monatsberichte über Bearbeitungszeiten von Aufträgen verwenden Sie dieselbe Bin‑Breite und dieselben Schwellenwerte, um Intervalle konsistent zu halten und Verteilungen leichter vergleichen zu können.

Rufen Sie [setAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAggregationType) für die horizontale Achse mit einem Modus aus [AxisAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axisaggregationtype/) auf. [setBinWidth](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setBinWidth) gilt nur für `ByBinWidth`; [setNumberOfBins](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberOfBins) gilt nur für `ByNumberOfBins`. Verwenden Sie `Automatic`, damit das Diagramm die Bins selbst wählt.

#### **Feste Bin‑Breite verwenden**

Dieses Beispiel gruppiert Bearbeitungszeiten in 10‑Minuten‑Intervalle, mit separaten Bins für Zeiten ≤ 10 Minuten und > 40 Minuten. Aktivieren Sie diese Bins mit [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) und [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin). Wenn Sie explizite Schwellenwerte über [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) und [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin) angeben, rufen Sie [setAutomaticUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticUnderflowBin) und [setAutomaticOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticOverflowBin) mit `False` auf.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200)

    chart.setLegend(False)
    chart.setTitle(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.getCell(0, i, 0, float(value))
        series.getDataPoints().addDataPointForHistogramSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setAggregationType(AxisAggregationType.ByBinWidth)
    axis.setBinWidth(10.0)
    axis.setUnderflowBin(True)
    axis.setAutomaticUnderflowBin(False)
    axis.setUnderflowBin(10.0)
    axis.setOverflowBin(True)
    axis.setAutomaticOverflowBin(False)
    axis.setOverflowBin(40.0)

    presentation.save("Histogram-bin-width.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die in PowerPoint dargestellte Präsentation zeigt Bin‑Anzahlen von **3, 4, 4, 4 und 2**. Der Unterlauf‑Bin enthält `5, 10, 10`, daher ist seine Schwelle inklusiv. Der Überlauf‑Bin enthält nur `41, 50`, daher ist seine Schwelle exklusiv; beide Werte gleich `40` verbleiben im vorherigen Intervall. Die Innen‑Bins enthalten Werte größer als ihre untere Grenze und kleiner‑gleich ihrer oberen Grenze.

![Histogram with 10-minute bins and explicit underflow and overflow thresholds](histogram_bin_width.png)

#### **Anzahl der Bins festlegen**

Für ein festes Detailniveau statt fester Intervalle fordern Sie fünf Bins für dieselben Daten an. Dieses Beispiel lässt Unter‑ und Überlauf‑Bins deaktiviert. Das Diagramm ermittelt die Breite aus dem Datenbereich, sodass Grenzen zwischen Berichten variieren können.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200)

    chart.setLegend(False)
    chart.setTitle(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.getCell(0, i, 0, float(value))
        series.getDataPoints().addDataPointForHistogramSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setAggregationType(AxisAggregationType.ByNumberOfBins)
    axis.setNumberOfBins(5)

    presentation.save("Histogram-bin-count.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die fünf Bins haben Anzahlen von **4, 4, 4, 4 und 1**. Vergleichen Sie diese Verteilung mit dem Ergebnis der festen Breite oben: Die Eingabewerte sind identisch, die Grenzen jedoch unterschiedlich.

![Histogram with five bins calculated from the same data](histogram_bin_count.png)

### **Radar‑Diagramme erstellen**

Radar‑Diagramme werden verwendet, um multivariate Daten in einem zweidimensionalen Format darzustellen, wodurch ein einfacher Vergleich mehrerer Variablen gleichzeitig möglich ist. Sie sind besonders nützlich, um Muster, Stärken und Schwächen über mehrere Leistungskennzahlen oder Attribute hinweg zu erkennen.

Dieses Beispiel verwendet [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart), um ein Radar‑Diagramm mit den Standard‑Serien und -Kategorien zu erstellen, und speichert die Präsentation als PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addChart(ChartType.Radar, 20, 20, 500, 300)

    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The Radar chart](radar_chart.png)

### **Mehrkategorie‑Diagramme erstellen**

Mehrkategorie‑Diagramme werden verwendet, um Daten darzustellen, die mehr als eine kategoriale Gruppierung umfassen, sodass Werte über mehrere Dimensionen gleichzeitig verglichen werden können. Sie sind besonders hilfreich, wenn Sie Trends und Zusammenhänge in komplexen, mehrschichtigen Datensätzen analysieren müssen.

Dieses Beispiel erstellt ein gruppiertes Säulendiagramm mit acht Kategorien, angeordnet in vier Paaren. Die [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem)‑Methode gibt jedem Paar ein gemeinsames Label auf Ebene 1, wodurch die Kategorienachse sowohl einzelne als auch Gruppen‑Labels enthält.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    worksheet_index = 0

    category_cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    category_cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    category_cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    category_cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    category_cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    value_cell = workbook.getCell(worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The multi category chart](multi_category_chart.png)

### **Karten‑Diagramme erstellen**

Karten‑Diagramme werden verwendet, um geografische Daten zu visualisieren, indem Informationen bestimmten Standorten wie Ländern, Bundesländern oder Städten zugeordnet werden. Sie eignen sich besonders zur Analyse regionaler Trends, demografischer Daten und räumlicher Verteilungen in einer klaren, visuell ansprechenden Art.

Dieses Beispiel verwendet [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart), um ein Karten‑Diagramm mit den Standard‑Geodaten zu erzeugen und speichert es zur Ansicht in PowerPoint.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Map, 20, 20, 500, 300)

    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The Map chart](map_chart.png)

{{% alert color="info" title="Note" %}}
Das obige Bild zeigt die gespeicherte Präsentation, die in PowerPoint geöffnet wurde. Aspose.Slides schreibt das Karten‑Diagramm und seine Daten korrekt, zeichnet jedoch selbst keine Karten‑Diagramme: Wird eine Folie, die ein solches Diagramm enthält, zu einem Bild oder in PDF bzw. SVG konvertiert, bleibt der Diagrammbereich leer. Andere Formen auf derselben Folie sind davon nicht betroffen.
{{% /alert %}}

### **Kombinations‑Diagramme erstellen**

Ein Kombinations‑Diagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Diagramm. Dieses Diagramm ermöglicht es Ihnen, Unterschiede zwischen zwei oder mehreren Datensätzen hervorzuheben, zu vergleichen oder zu untersuchen und so Beziehungen zwischen ihnen zu erkennen.

![The combination chart](combination_chart.png)

Dieses Beispiel kombiniert zwei gruppierte Säulen‑Serien mit einer Linien‑Serie über vier Kategorien. Die Säulen nutzen die primäre vertikale Achse, während [setPlotOnSecondAxis](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setPlotOnSecondAxis) die Linie auf einer sekundären vertikalen Achse rechts platziert. Hilfsfunktionen konfigurieren Titel, Legende, Achsenbeschriftungen und Gitternetzlinien.

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

    # Diagrammtitel festlegen.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Legende des Diagramms festlegen.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # Standardgenerierte Serien und Kategorien löschen.
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

    # Erste Serie hinzufügen.
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
    # Horizontale Achse festlegen.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # Vertikale Achse festlegen.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # Farbe der vertikalen Hauptgitterlinien festlegen.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # Sekundäre horizontale Achse festlegen.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Sekundäre vertikale Achse festlegen.
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

Aspose.Slides für Python via Java ermöglicht es Ihnen, PowerPoint‑Diagramme zu aktualisieren, indem Sie Diagrammdaten, Formatierungen und Stile ändern. Diese Funktion vereinfacht das Aktualisieren von Präsentationen mit dynamischem Inhalt und stellt sicher, dass Diagramme aktuelle Daten und visuelle Standards exakt wiedergeben.

Dieses Beispiel aktualisiert das Diagramm mit dem Namen „My chart“ auf der ersten Folie einer bestehenden Präsentation. Es erfordert zwei Spalten‑Serien mit je drei Datenpunkten, wobei Kategorienamen in Spalte A und Seriennamen in der ersten Zeile des ersten Arbeitsblatts stehen. Das Beispiel verwendet [getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell), um Arbeitsbuchzellen zu ändern, aktualisiert Serienwerte, fügt eine dritte Serie hinzu und ändert das Diagramm zu gruppierten Zylindern über [setType](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartType, Presentation, SaveFormat

chart_name = "My chart"

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, Chart) and chart_name == shape.getName():
            chart = shape
            worksheet_index = 0

            workbook = chart.getChartData().getChartDataWorkbook()

            workbook.getCell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.getCell(worksheet_index, 2, 0, "Modified Category 2")

            series = chart.getChartData().getSeries().get_Item(0)

            workbook.getCell(worksheet_index, 0, 1, "New_Series 1")
            series.getDataPoints().get_Item(0).getValue().setData(90)
            series.getDataPoints().get_Item(1).getValue().setData(123)
            series.getDataPoints().get_Item(2).getValue().setData(44)

            series = chart.getChartData().getSeries().get_Item(1)

            workbook.getCell(worksheet_index, 0, 2, "New_Series 2")
            series.getDataPoints().get_Item(0).getValue().setData(23)
            series.getDataPoints().get_Item(1).getValue().setData(67)
            series.getDataPoints().get_Item(2).getValue().setData(99)

            series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
            series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

            value_cell = workbook.getCell(worksheet_index, 1, 3, 20)
            series.getDataPoints().addDataPointForBarSeries(value_cell)
            value_cell = workbook.getCell(worksheet_index, 2, 3, 50)
            series.getDataPoints().addDataPointForBarSeries(value_cell)
            value_cell = workbook.getCell(worksheet_index, 3, 3, 30)
            series.getDataPoints().addDataPointForBarSeries(value_cell)

            chart.setType(ChartType.ClusteredCylinder)

    presentation.save("AsposeChartModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Datenbereich für ein Diagramm festlegen**

Um den bereits von einem bestehenden Diagramm genutzten Bereich zu prüfen, siehe [Retrieve a Chart's Data Range](/slides/de/python-java/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides für Python via Java bietet die Flexibilität, einen spezifischen Datenbereich aus einem Arbeitsblatt als Quelle für die Diagrammdaten festzulegen. Das bedeutet, dass Sie einen Teil Ihres Arbeitsblatts direkt dem Diagramm zuordnen können, wodurch Sie steuern, welche Zellen zu den Serien und Kategorien des Diagramms beitragen. So können Sie Ihre Diagramme leicht mit den neuesten Änderungen im Arbeitsblatt aktualisieren und synchronisieren, sodass Ihre PowerPoint‑Präsentationen aktuelle und genaue Informationen widerspiegeln.

Dieses Beispiel verwendet [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange), um die Datenquelle des Diagramms mit dem Namen „My chart“ auf der ersten Folie einer bestehenden Präsentation auf `Sheet1!A1:B4` zu setzen. Das Diagramm‑Arbeitsbuch muss dieses Arbeitsblatt und einen befüllten Bereich mit einer Serien‑Überschrift in der ersten Zeile, Kategorienamen in Spalte A und drei Werten in Spalte B enthalten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

chart_name = "My chart"

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, Chart) and chart_name == shape.getName():
            chart = shape
            chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Standard‑Marker in Diagrammen verwenden**

Wenn Sie Standard‑Marker in Diagrammen einsetzen, erhält jede Diagramm‑Serie automatisch ein unterschiedliches Standard‑Marker‑Symbol.

Dieses Beispiel verwendet [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart), um ein Diagramm mit zwei Linien‑Serien und einer Legende zu erstellen. Die über [getMarker](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getMarker) abgerufenen Marker‑Einstellungen behalten die automatisch zugewiesenen Marker‑Symbole bei. Die erste Serie enthält einen negativen Wert und einen fehlenden Wert, dargestellt durch `None`, während die zweite für jede Kategorie einen Wert hat.

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

    series_name_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    category_cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    series_name_cell = workbook.getCell(0, 0, 2, "Series 2")
    second_series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    value_cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Welche Diagrammtypen werden von Aspose.Slides für Python via Java unterstützt?**

Aspose.Slides für Python via Java unterstützt eine breite Palette von Diagrammtypen, darunter Balken, Linien, Kreis, Fläche, Scatter, Histogramm, Radar und viele mehr. Diese Flexibilität ermöglicht es Ihnen, den für Ihre Datenvisualisierung am besten geeigneten Diagrammtyp auszuwählen.

**Wie füge ich ein neues Diagramm zu einer Folie hinzu?**

Um ein Diagramm hinzuzufügen, erstellen Sie zunächst eine Instanz der [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑Klasse, rufen die gewünschte Folie über ihren Index ab und rufen dann die Methode zum Hinzufügen eines Diagramms auf, wobei Sie den Diagrammtyp und die Anfangsdaten angeben. Dieser Vorgang integriert das Diagramm direkt in Ihre Präsentation.

**Wie kann ich die in einem Diagramm angezeigten Daten aktualisieren?**

Sie können die Daten eines Diagramms aktualisieren, indem Sie auf dessen Daten‑Arbeitsbuch ([ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)) zugreifen, Standard‑Serien und -Kategorien löschen und anschließend Ihre benutzerdefinierten Daten hinzufügen. So können Sie das Diagramm programmgesteuert aktualisieren, sodass es die neuesten Daten widerspiegelt.

**Ist es möglich, das Aussehen des Diagramms anzupassen?**

Ja, Aspose.Slides für Python via Java bietet umfangreiche Anpassungsoptionen. Sie können Farben, Schriftarten, Beschriftungen, Legenden und weitere Formatierungselemente ändern, um das Diagramm an Ihre spezifischen Designanforderungen anzupassen.