---
title: Diagrammachsen in Präsentationen mit Python anpassen
linktitle: Diagrammachse
type: docs
url: /de/python-java/chart-axis/
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
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aspose.Slides für Python über Java verwenden, um Diagrammachsen in PowerPoint-Präsentationen für Berichte und Visualisierungen anzupassen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Diagrammachsen mit Aspose.Slides für Python über Java anpassen. Er behandelt berechnete Achsenwerte, das Vertauschen von Diagrammzeilen und -spalten, die Sichtbarkeit von Achsen, Kategorienbezeichnungs‑ und Tick‑Mark‑Intervalle, Datums‑kategorien und -Formatierung, die Drehung von Achsentiteln, die Positionierung von Achsen, Anzeige­einheiten und die logarithmische Skalierung.

## **Maximale Werte auf der vertikalen Achse eines Diagramms ermitteln**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) und fügen Sie ein Flächendiagramm mit Standarddaten hinzu. Rufen Sie [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) auf, bevor Sie berechnete Achsenwerte lesen, damit das Diagrammlayout aktuell ist.

Lesen Sie [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) und [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) für die Achsen­grenzen sowie [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) und [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) für die Tick‑Intervalle. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) und [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) liefern Zeit­einheits‑Skalen, die für Datumsachsen relevant sind. Das Beispiel speichert diese Werte in lokalen Variablen und speichert das Diagramm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Daten zwischen Achsen austauschen**

Verwenden Sie [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn), um die Rollen von Reihen und Kategorien in Diagrammdaten zu vertauschen. Jede frühere Kategorie wird zu einer Reihe, und jede frühere Reihe wird zu einer Kategorie. Dadurch ändert sich die Gruppierung der Daten; die horizontalen und vertikalen Achsen werden nicht vertauscht. Das Beispiel verwendet [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange), um die Standarddaten an `Sheet1!A1:D5` zu binden, einschließlich der Kopfzeile und der Kategoriespalte, bevor Zeilen und Spalten getauscht werden. Es speichert ein Diagramm mit vier Reihen und drei Kategorien.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Plot‑Reihenfolge einer Achse umkehren**

Verwenden Sie [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed), um eine Kategorien‑ oder Werteachse umzukehren. Beispielsweise kann ein horizontales Balkendiagramm Projektphasen von oben nach unten in derselben Reihenfolge wie das Arbeitsblatt anzeigen: Planung, Entwicklung, Testen. Das Umkehren einer Achse ändert die Plot‑Richtung; es sortiert oder ordnet die Arbeitsblattdaten nicht neu. Im Vergleich dazu tauscht [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) die Rollen von Reihen und Kategorien.

Das folgende Beispiel erstellt ein horizontales Balkendiagramm mit drei Phasen und einer Reihe. Es speichert eine Präsentation mit drei Folien: normale Reihenfolge, umgekehrte Kategorien und umgekehrte Werte. Jede Kopie verwendet denselben Datensatz, und auf jeder Kopie ist nur eine Achse umgekehrt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Folie 2: die erste Kategorie oben anzeigen.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # Die horizontale Werteachse unten belassen.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # Folie 3: nur die horizontale numerische Skala umkehren.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Umkehren einer Achse kann auch die senkrechte Achse auf die gegenüber­liegende Seite des Plots verschieben. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) steuert, wo die andere Achse die zu konfigurierende Achse kreuzt. In Folie 2 wird sie mit [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) auf der umgekehrten Kategorienachse aufgerufen, sodass die horizontale Werteachse unten bleibt. Für einen bestimmten Kreuzungspunkt verwenden Sie [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Überprüfen Sie die Kreuzungseinstellungen, wenn Sie die Richtung ändern, insbesondere wenn das Diagramm bereits einen benutzerdefinierten Kreuzungspunkt hat. Rufen Sie [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) mit `False` auf, um die normale Plot‑Richtung wiederherzustellen; Kreuzungseinstellungen sind separat.

| Normale Reihenfolge (Folie 1) | Umgekehrte Kategorien (Folie 2) | Umgekehrte Werte (Folie 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| Kategorien laufen von unten nach oben; Werte steigen von links nach rechts. | Planung, Entwicklung und Testen laufen von oben nach unten. Werte und Zeilenreihenfolge der Arbeitsmappe bleiben unverändert. | Kategorien behalten ihre normale Reihenfolge; Werte steigen von rechts nach links. Die Kategorienachse schneidet bei Null rechts. |

## **Vertikale Achse für Liniendiagramme deaktivieren**

Rufen Sie [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) mit `False` für die vertikale Achse auf, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter vertikaler Achse.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Horizontale Achse für Liniendiagramme deaktivieren**

Rufen Sie [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) mit `False` für die horizontale Achse auf, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter horizontaler Achse.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kategorienachse ändern**

Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType), um einen Datums‑ oder Text‑Kategorienachse zu wählen. Dieses Beispiel benötigt `ExistingChart.pptx`, wobei das Diagramm das erste Shape auf der ersten Folie ist und die Kategorienzellen numerische Excel‑Datumwerte enthalten. Es ändert die horizontale Achse zu einer Datumsachse. Das Aufrufen von [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) mit `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) mit `1` und [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) mit [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) legt Hauptticks im Abstand von einem Monat fest.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Intervall der Kategorienachsen‑Beschriftungen steuern**

Wenn ein Diagramm viele Kategorien hat, reduzieren Sie die Anzahl der sichtbaren Achsenbeschriftungen, ohne Kategorien oder Datenpunkte zu entfernen. Rufen Sie [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) mit `False` auf und übergeben Sie das gewünschte Kategorienintervall an [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). Für Textkategorien in ihrer normalen Reihenfolge beginnt die Zählung mit der ersten Kategorie:

| Intervall | Im Beispiel angezeigte Beschriftungen |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, ... Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, ... Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, ... Kategorie 22 |

Ein Intervall von `3` zeigt jede dritte Beschriftung an und lässt zwei Beschriftungen zwischen den angezeigten verborgen. Es entfernt nicht die entsprechenden Spalten. Automatisches Spacing wählt ein Intervall basierend auf dem verfügbaren Platz; es werden nicht zwingend alle Beschriftungen angezeigt.

Tick‑Marks haben separate Einstellungen. Rufen Sie [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) mit `False` auf und verwenden Sie [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) um ihr Intervall festzulegen. Zum Beispiel hält `1` einen Tick‑Mark bei jedem Kategorienintervall, während Beschriftungen nur alle dritten Kategorien erscheinen. Verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) mit einem sichtbaren Stil, damit Sie das Ergebnis sehen können. Das erneute Aufrufen eines automatischen Spacing‑Setters mit `True` lässt das Diagramm dieses Intervall wieder wählen.

Das folgende, eigenständige Beispiel erstellt 24 Kategorien und eine Reihe und speichert dann drei Folien in `CategoryAxisIntervals.pptx`: automatisches Spacing, manuelles Beschriftungs‑Spacing mit unabhängigen Tick‑Marks und wiederhergestelltes automatisches Spacing. Die beiden Kopien behalten die ursprünglichen Diagrammdaten. Keine Eingabepräsentation ist erforderlich. Der horizontale Beschriftungstext macht den Unterschied in der Dichte deutlich sichtbar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # Folie 2: jede dritte Beschriftung anzeigen, aber für jede Kategorie einen Tick‑Mark beibehalten.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Folie 3: das Diagramm wählt beide Intervalle erneut.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Automatisches Spacing (Folie 1):** In dieser Darstellung wird jede zweite Kategorienbeschriftung angezeigt und auf zwei Zeilen umgebrochen. Das automatische Ergebnis kann je nach Diagrammgröße, Schriftarten und Renderer variieren.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Manuelles Spacing (Folie 2):** Jede dritte Beschriftung wird in einer Zeile angezeigt, während Tick‑Marks bei jedem Kategorienintervall bleiben. Alle 24 Spalten, einschließlich der ohne Beschriftungen, bleiben mit denselben Werten sichtbar. Folie 3 stellt das oben gezeigte automatische Aussehen wieder her.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Den richtigen Achsentyp und das Intervall wählen**

Verwenden Sie dieses Kategorie‑Zähl‑Intervall für eine Text‑Kategorienachse, wie die Kategorienachse eines Säulen‑, Linien‑, Flächen‑ oder Balkendiagramms. In einem Säulendiagramm ist sie die horizontale Achse. In einem horizontalen Balkendiagramm ist die Kategorienachse vertikal, daher wenden Sie diese Einstellungen auf die Achse an, die von [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) zurückgegeben wird. Das Tick‑Mark‑Spacing gilt auch für eine Reihenachse in Diagrammen, die eine solche besitzen.

Verwenden Sie die Kategorien‑Beschriftungs‑Abstände nicht, um die numerische Skala einer Werteachse festzulegen. Auf einer Werteachse gibt [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) eine Differenz in Werten an: z. B. erzeugt ein Hauptintervall von `10` Ticks bei 0, 10, 20 usw., wenn die Achse bei Null beginnt. Ein Kategorien‑Beschriftungs‑Intervall von `3` zählt stattdessen Kategoriepositionen, unabhängig von deren Datenwerten. Streu‑ und Blasendiagramme verwenden Werteachsen statt einer Text‑Kategorienachse. Für eine Datumsachse verwenden Sie zeitbasierte Haupteinheiten und Skalen wie in [Kategorienachse ändern](#change-a-category-axis) beschrieben.

## **Datumsformat für Kategorienachsenwerte festlegen**

Das Beispiel ersetzt die Standard‑Diagrammdaten durch vier Jahreswerte. Daten werden als OLE‑Automation‑Seriennummern im ersten Arbeitsblatt (Index `0`) gespeichert und als Anzahl der Tage seit dem 30. Dezember 1899 für diese Daten berechnet. Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) mit [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), rufen Sie [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) mit `False` auf und übergeben Sie `yyyy` an [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat), sodass die Kategorienbeschriftungen vierstellige Jahreszahlen unabhängig von der Zellenformatierung anzeigen.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Drehwinkel für Diagrammachsentitel festlegen**

Rufen Sie [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) mit `True` für die vertikale Achse auf, geben Sie den Titeltext an und setzen Sie den Drehwinkel in der Textblock‑Formatierung des Titels. Der Winkel wird in Grad gemessen; dieses Beispiel speichert ein Säulendiagramm, bei dem der Titel der Werteachse um 90 Grad gedreht ist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Achsenposition bei einer Kategorien‑ oder Werteachse festlegen**

Verwenden Sie [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories), um zu steuern, ob die Werteachse die Kategorienachse zwischen den Kategorien oder an den Kategorien‑Tick‑Marks kreuzt. Diese Einstellung gilt für Kategorienachsen. Das Beispiel setzt sie auf `True` für die horizontale Kategorienachse eines Säulendiagramms und speichert das Ergebnis.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Anzeigeeinheit für eine Diagramm‑Werteachse festlegen**

Verwenden Sie [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit), um die Beschriftungen einer Werteachse zu skalieren, ohne die zugrunde liegenden Daten zu ändern. Mit [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) auf `Millions` gesetzt wird ein Wert von 60 000 000 als 60 angezeigt. Das Beispiel erstellt ein Säulendiagramm und wendet die Anzeigeeinheit Millionen auf seine vertikale Achse an.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Logarithmische Werteachse konfigurieren**

Eine logarithmische Werteachse ist nützlich, wenn positive Werte mehrere Größenordnungen umfassen. Beispielsweise kann ein Dienst in fünf Zeiträumen 10, 100, 1 000, 10 000 und 100 000 Anfragen erhalten. Auf einer linearen Skala liegen die kleineren Werte nahe beieinander nahe Null. Eine logarithmische Skala macht ihr relatives Wachstum leichter vergleichbar: gleiche Abstände repräsentieren gleiche Verhältnisse statt gleiche Differenzen.

Rufen Sie [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) mit `True` für die Werteachse auf und verwenden Sie [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase), um die Basis zu wählen. Dies ändert, wie die vorhandenen Werte angezeigt werden; es ändert nicht die Daten oder fügt eine logarithmische Trendlinie hinzu. Eine Trendlinie stellt eine angepasste Beziehung in den Daten dar und ist ein separates Feature.

### **Werteachse und Basis wählen**

Für ein Linien‑ oder Säulendiagramm wird die Werteachse von [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) zurückgegeben. Für ein horizontales Balkendiagramm von [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). Streu‑ und Blasendiagramme haben zwei Werteachsen, wählen Sie also die horizontale Achse für X‑Werte, die vertikale Achse für Y‑Werte oder beide. Wenden Sie keine logarithmische Skalierung auf eine Kategorienachse an.

Die Standard‑Logarithmus‑Basis ist `10`. Für PPTX‑Diagramme verwenden Sie eine Basis von `2` bis `1000` (einschließlich); Bruch‑Basen wie `2.5` werden ebenfalls unterstützt. Mit Basis `10` sind aufeinander folgende Potenzen wie 10, 100, 1 000 und 10 000 gleichmäßig verteilt.

### **Lineare und logarithmische Skalierung vergleichen**

Das folgende, eigenständige Beispiel erstellt ein Liniendiagramm mit den fünf Anfragenzahlen auf der ersten Folie, dupliziert diese Folie und aktiviert auf der zweiten eine Basis‑10‑logarithmische Werteachse. Beide Folien behalten dieselben Daten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Die erste Folie linear belassen und nur die Skala der Werteachse der Kopie ändern.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Lineare Skala (Folie 1):** Gleiche vertikale Abstände repräsentieren gleiche Unterschiede in den Anfragenzahlen. Der größte Wert dominiert das Diagramm, sodass die kleineren Werte schwer zu unterscheiden sind.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logarithmische Skala (Folie 2):** Gleiche vertikale Abstände repräsentieren gleiche Verhältnisse. Jede Periode hat zehnmal so viele Anfragen wie die vorherige, sodass die Punkte auf der Basis‑10‑Skala eine gerade steigende Linie bilden. Die Achsenbeschriftungen zeigen weiterhin die ursprünglichen Anfragenzahlen.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Umgang mit Null‑ und Negativwerten**

Eine logarithmische Skala kann nur streng positive Werte anzeigen. Überprüfen Sie die Daten, bevor Sie sie aktivieren. Wenn Null‑ oder Negativwerte eine Bedeutung haben, behalten Sie eine lineare Skala bei oder zeigen Sie sie separat. Wenn das Ausschließen dieser Werte für die Analyse sinnvoll ist, erklären Sie die Auslassung. Ersetzen Sie sie nicht stillschweigend durch kleine positive Zahlen, da dies die Bedeutung der Daten ändert. Jeder manuell konfigurierte Minimal‑ oder Maximalwert für eine logarithmische Achse muss ebenfalls positiv sein.

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achskreuzung)?**

Verwenden Sie [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType), um das Kreuzungsverhalten auszuwählen. Um einen numerischen Kreuzungswert anzugeben, verwenden Sie [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Diese Einstellungen ermöglichen es Ihnen, die Achskreuzung zu einer geeigneten Basislinie zu verschieben.

**Wie kann ich Tick‑Beschriftungen relativ zur Achse positionieren?**

Rufen Sie [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) mit [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` oder `None` auf. Um die Tick‑Marks selbst zu steuern, verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) oder [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark); diese stehen getrennt von der Beschriftungspositionierung.