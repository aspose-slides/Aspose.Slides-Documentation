---
title: Diagrammdatenreihen in Präsentationen mit Python verwalten
linktitle: Datenreihen
type: docs
url: /de/python-java/chart-series/
keywords:
- Diagrammreihe
- Serienüberlappung
- Serienfarbe
- Serienname
- Datenpunkt
- Arbeitsmappenzelle
- Serienabstand
- Negativer Wert
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: Erfahren Sie, wie Sie Diagrammserien, Datenpunkte, Arbeitsmappenzellen, Formatierungen, Überlappungen, Lückenbreiten und negative Werte in Präsentationen mit Aspose.Slides für Python über Java verwalten.
---
## **Übersicht**

Ein Diagramm speichert seine geplotteten Daten in einer Diagrammdaten‑Arbeitsmappe. Eine [ChartSeries](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/) stellt einen Satz zusammengehöriger Werte dar, und jeder [ChartDataPoint](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/) in der Serie bezieht sich auf eine oder mehrere Zellen der Arbeitsmappe. [ChartCategory](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartcategory/)‑Objekte liefern die Bezeichnungen oder Gruppierungswerte, die von der Serie gemeinsam genutzt werden. Der Serienname, die Kategorien und die Punktwerte sind daher mit [ChartDataCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/)‑Objekten verknüpft und nicht nur als Anzeigetext gespeichert.

Für ein typisches Kategoriediagramm verwendet die Standardsarbeitsmappe Zeile 0 für Seriennamen, Spalte 0 für Kategorienamen und die übrigen Zellen für Serienwerte. Arbeitsblatt‑, Zeilen‑ und Spaltenindizes, die an [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/#getCell) übergeben werden, beginnen bei Null. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, aber Sie dürfen nicht davon ausgehen, dass jedes bereits vorhandene Diagramm es verwendet. Bei einer geladenen Präsentation sollten Sie die von den Serien, Kategorien und Datenpunkten referenzierten Zellen prüfen, bevor Sie Arbeitsmappeneinträge ändern.

Diagrammeinstellungen haben drei verschiedene Ebenen:

- Auf Serienebene festgelegte Einstellungen, wie [ChartSeries.getFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getFormat), bestimmen das Standard‑Aussehen aller Punkte einer Serie.
- Datenpunkt‑Einstellungen, wie [ChartDataPoint.getFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/#getFormat), überschreiben das Serien‑Aussehen für einen einzelnen Punkt.
- Gruppeneinstellungen gelten für kompatible Serien, die zur selben [ChartSeriesGroup](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/) gehören. Greifen Sie über [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getParentSeriesGroup) auf die Gruppe zu, wenn Sie Optionen wie Überlappung oder Lückenbreite festlegen müssen.

Wenn weder ein expliziter Punkt‑ noch ein Serien‑Füllstil festgelegt ist, bestimmen Diagrammstil und -thema das automatische Aussehen. Sind sowohl Serien‑ als auch Punktformatierungen vorhanden, hat die Punktformatierung für diesen Punkt Vorrang.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Überlappung der Diagrammserie festlegen**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getOverlap) gibt an, wie stark Balken oder Säulen in einem 2‑D‑Diagramm überlappen, von -100 bis 100 Prozent. Es ist eine schreibgeschützte Projektion der Einstellung auf die übergeordnete Seriengruppe. Verwenden Sie [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/#setOverlap), um jede kompatible Serie in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Säulen darstellen; sie beeinflusst nicht nicht verwandte Seriengruppen in einem Kombinationsdiagramm.

Das folgende Beispiel setzt die Überlappung für die Gruppe, die die erste Serie enthält:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # Das neue Diagramm enthält Beispielserien, Kategorien und Werte.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The series overlap](series_overlap.png)

## **Füllfarbe der Serie ändern**

Verwenden Sie [ChartSeries.getFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getFormat), um die Standard‑Füllung für eine ganze Serie festzulegen. Hat ein Punkt bereits eine explizite Füllung, überschreibt dessen [ChartDataPoint.getFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/#getFormat)-Einstellung die Serien‑Füllung für diesen Punkt.

Das folgende Beispiel wendet eine einfarbige blaue Füllung auf die erste Serie an:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The color of the series](series_color.png)

## **Seriennamen ändern**

Ein Serienname wird in der Diagrammdaten‑Arbeitsmappe gespeichert und normalerweise in der Legende angezeigt. In der Standard‑Arbeitsmappe, die für ein gruppiertes Säulendiagramm erstellt wird, befindet sich Zelle B1 in Zeile 0, Spalte 1 und enthält den Namen der ersten Serie. Die benannten Variablen im folgenden Beispiel machen diese Struktur explizit:

```python
import jpile
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sie können zudem die bereits von [ChartSeries.getName](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getName) referenzierte Zelle aktualisieren. Dieser Ansatz vermeidet Annahmen über eine bestimmte Zeile und Spalte in einem vorhandenen Diagramm:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The series name](series_name.png)

## **Automatische Füllfarbe der Serie abrufen**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) gibt die aus dem Serienindex und dem Diagrammstil berechnete Farbe zurück. Dies ist die Farbe, die verwendet wird, wenn die Serien‑Füllung nicht explizit definiert wurde. Der Aufruf der Methode liest die berechnete Farbe; er weist keine neue Füllung zu.

Das folgende Beispiel gibt die automatische Farbe jeder Standardserie aus:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Beispielausgabe für den Standard‑Diagrammstil:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Die genauen Farben hängen vom Diagrammstil und -thema ab.

## **Umgekehrte Füllfarbe für eine Diagrammserie festlegen**

Für Balken-, Säulen- und Blasensereien kann [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#setInvertIfNegative) negative Werte mit einer anderen Füllung anzeigen. Stellen Sie die reguläre Serien‑Füllung auf einfarbig, aktivieren Sie die Invertierung und weisen Sie die Farbe für negative Werte über [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) zu. Negative Zahlen bleiben in der Arbeitsmappe unverändert; nur ihre Anzeige­farbe ändert sich.

Das folgende Beispiel ersetzt die Standard‑Diagrammdaten durch eine Serie. Zeile 0 des Arbeitsblatts enthält den Seriennamen, Spalte 0 die Kategorienamen und Spalte 1 die Werte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The inverted solid fill color](inverted_solid_fill_color.png)

Sie können die Invertierung für einen Punkt über [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) aktivieren. Im folgenden Beispiel ist die Invertierung für die Serie deaktiviert und nur für den ausgewählten Punkt aktiviert. Dem Punkt wird außerdem ein negativer Wert zugewiesen, damit der Effekt sichtbar wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Einen bestimmten Datenpunktwert löschen**

Um einen Punkt leer zu machen, ohne die anderen Punkte zu entfernen, setzen Sie die zugehörige Arbeitsmappen‑Zelle auf `None`. Bei einem Säulendiagramm ist der geplottete Wert über [ChartDataPoint.getValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/#getValue) verfügbar. Der Datenpunkt bleibt an derselben Kategorienposition, das Diagramm behandelt seinen Wert jedoch als leer gemäß den Leere‑Wert‑Einstellungen des Diagramms.

Das folgende Beispiel löscht nur den zweiten Punkt in der ersten Serie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Scatter‑Diagramme verwenden separate X‑ und Y‑Zellen, und Blasendiagramme nutzen zudem eine Größen‑Zelle. Löschen Sie nur die Zelle, die den zu entfernenden Wert repräsentiert. Rufen Sie [ChartDataPointCollection.clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapointcollection/#clear) nicht auf, wenn Sie die anderen Punkte behalten möchten, da diese Methode alle Datenpunkte aus der Sammlung entfernt.

## **Anzeige leerer Zellen steuern**

Eine leere Arbeitsmappen‑Zelle steht für fehlende Daten; eine Zelle mit `0` steht für einen bekannten numerischen Wert. Rufen Sie [ChartDataCell.setValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/#setValue) mit `None` auf, um eine Zelle leer zu machen. Eine numerische Null bleibt eine Null, unabhängig von der Einstellung für leere Zellen.

Verwenden Sie [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#setDisplayBlanksAs), um zu wählen, wie das Diagramm leere Zellen darstellt. Diese Einstellung gilt für das gesamte Diagramm. Sie ändert die Darstellung der Lücken, ohne die leere Arbeitsmappen‑Zelle mit Null oder einem interpolierten Wert zu füllen.

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit einer Serie, löscht den Wert für Tag 3 und speichert das gleiche Diagramm in jedem Modus. Eine Eingabedatei ist nicht erforderlich. Die [ChartDataWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/) verwendet Arbeitsblatt 0, Spalte 0 für Kategorienamen und Spalte 1 für Werte; Zeile 0 enthält den Seriennamen. Die finalen Daten sind `10, 20, empty, 30, 40`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Lassen Sie Tag 3 wirklich leer, während Sie seine Kategorie und den Datenpunkt beibehalten.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jede Ausgabedatei speichert den vor dem Speichern zugewiesenen Modus: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` und `empty_cells_Span.pptx`. Um nur eine Version zu speichern, weisen Sie den gewünschten Modus zu und speichern die Präsentation einmal, anstatt über die Modi zu iterieren.

Der Vergleich unten zeigt dieselben Daten in allen drei Dateien. Tag 3 ist in der Arbeitsmappe in jedem Fall leer:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Der sichtbare Effekt hängt vom Diagrammtyp ab. Ein Liniendiagramm macht alle drei Modi leicht vergleichbar. Balken- und Säulendiagramme haben keine Linie, die über eine fehlende Kategorie hinweg verbindet, sodass `Span` nicht das oben gezeigte Verbindungssegment erzeugen kann; eine fehlende Säule und eine Säule mit Höhe 0 können ebenfalls ähnlich aussehen. Ähnlich hat ein Scatter‑Diagramm mit nur Markern keine verbindende Linie. Erwarten Sie nicht für jeden Diagrammtyp drei unterschiedliche Ergebnisse; prüfen Sie die Ausgabe für den von Ihnen verwendeten Typ.

## **Lückenbreite der Serie festlegen**

Die Lückenbreite ist der Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, ausgedrückt als Prozentsatz der Balken‑ bzw. Säulenbreite. Wie die Überlappung gehört sie zur übergeordneten Seriengruppe und nicht zu einer einzelnen Serie. Rufen Sie [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/#setGapWidth) einmal für die Gruppe auf. Ein größerer Wert erzeugt mehr Abstand zwischen den Clustern; ein kleinerer Wert macht sie dichter.

Das folgende Beispiel ändert die Lückenbreite und speichert nur die endgültige Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![The gap width](gap_width.png)

## **FAQ**

**Welche Diagrammtypen unterstützen Datenserien?**

Alle Diagrammtypen, die durch die Aufzählung [ChartType](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/) repräsentiert werden, verwenden Diagrammdaten, aber ihre Serien haben nicht alle dieselbe Wertstruktur oder dieselben Einstellungen. Beispielsweise verwenden Kategoriediagramme Kategorien und Werte, Scatter‑Diagramme X‑ und Y‑Werte und Blasendiagramme zusätzlich die Blasengrößen. Verwenden Sie die Datenpunkt‑Erstellungsmethode, die zum Serientyp passt. Optionen wie Überlappung und Lückenbreite gelten nur für kompatible Balken‑ oder Säulengruppen.

**Was ist eine Diagramm‑Seriengruppe?**

Eine [ChartSeriesGroup](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/) enthält kompatible Serien, die gruppenbezogene Darstellungseinstellungen teilen. Ein Kombinationsdiagramm kann mehr als eine Gruppe enthalten, sodass das Ändern der über eine Serie erreichbaren Gruppe nicht unbedingt alle Serien im Diagramm beeinflusst.

**Enthält ein neu erstelltes Diagramm Standarddaten?**

Ja. Standardmäßig erzeugt [ShapeCollection.addChart](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addChart) Beispielserien, -kategorien und -werte. Sie können diese Zellen bearbeiten oder sowohl die Serien‑ als auch die Kategorien‑Sammlungen löschen, bevor Sie einen komplett benutzerdefinierten Datensatz hinzufügen. Eine Überladung kann zudem ein Diagramm ohne Standarddaten erzeugen.

**Wie sind Diagrammobjekte mit Arbeitsmappen‑Zellen verknüpft?**

Seriennamen, Kategorielabels und Datenpunktwerte referenzieren Zellen in einer [ChartDataWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das entsprechende Diagrammelement. Wenn Sie benutzerdefinierte Daten erstellen, halten Sie Kategorie‑Zeilen und Serien‑Wert‑Zeilen ausgerichtet, sodass jeder Punkt unter der beabsichtigten Kategorie geplottet wird.

**Wie lösche ich einen einzelnen Punkt statt der ganzen Serie?**

Setzen Sie die relevante Wert‑Zelle auf `None`, um die Kategorienposition des Punktes als leeren Punkt beizubehalten. Verwenden Sie [ChartDataPointCollection.clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapointcollection/#clear) nur, wenn Sie alle Punkte dieser Serie entfernen möchten. Entfernen Sie zudem Kategorien, aktualisieren Sie jede Serie, sodass ihre Werte weiterhin mit der Kategorien‑Sammlung ausgerichtet bleiben.

**Wie werden leere Punkte dargestellt?**

Das Ergebnis hängt vom Diagrammtyp und dem über [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#setDisplayBlanksAs) konfigurierten Wert ab. Unterstützte Diagramme können Lücken als Lücken, als Nullwerte oder durch Verbinden benachbarter Punkte darstellen. Wählen Sie die Einstellung, die der Bedeutung fehlender Daten in Ihrer Präsentation entspricht. Siehe [Anzeige leerer Zellen steuern](#control-the-display-of-empty-cells) für ein vollständiges Beispiel und einen visuellen Vergleich.

**Wie werden negative Werte formatiert?**

Für unterstützte Balken‑, Säulen‑ und Blasensereien rufen Sie [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#setInvertIfNegative) auf und setzen die über [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) zurückgegebene Farbe. Sie können das Verhalten für einen einzelnen Punkt mit [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) überschreiben. Diese Methoden beeinflussen die Formatierung, nicht die gespeicherten numerischen Werte.

**Welche Formatierung gewinnt, wenn sowohl eine Serie als auch ein Punkt formatiert sind?**

Explizite Datenpunkt‑Formatierung hat für diesen Punkt Vorrang. Andere Punkte verwenden weiterhin das explizite Serienformat oder, wenn das Serienformat nicht definiert ist, den automatischen Diagrammstil und das Theme. Gruppeneinstellungen wie Überlappung und Lückenbreite steuern das Layout und sind keine Formatierungsüberschreibungen auf Punktebene.

**Gibt es ein Limit, wie viele Serien ein Diagramm enthalten kann?**

Aspose.Slides legt kein separates festes Limit für die Anzahl der Serien fest. In der Praxis bestimmen Datei‑Beschränkungen, verfügbarer Speicher, Renderzeit und die Lesbarkeit des Diagramms ein sinnvolles Limit.

**Was sollte ich ändern, wenn Säulen zu eng beieinander oder zu weit auseinander liegen?**

Rufen Sie [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/#setGapWidth) für die entsprechende übergeordnete Seriengruppe auf. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenzubringen.