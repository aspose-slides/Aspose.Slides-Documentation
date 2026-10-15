---
title: Diagrammachsen in Präsentationen mit Python anpassen
linktitle: Diagrammachse
type: docs
url: /de/python-net/chart-axis/
keywords:
- Diagrammachse
- vertikale Achse
- horizontale Achse
- Achse anpassen
- Achse manipulieren
- Achse verwalten
- Achseneigenschaften
- Maximalwert
- Minimalwert
- Achsenlinie
- Datumsformat
- Achsentitel
- Achsenposition
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie, wie Sie Aspose.Slides für Python über .NET verwenden, um Diagrammachsen in PowerPoint- und OpenDocument-Präsentationen für Berichte und Visualisierungen anzupassen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Diagrammachsen mit Aspose.Slides für Python über .NET angepasst werden können. Er behandelt berechnete Achsenwerte, das Tauschen von Diagrammzeilen und -spalten, Achsensichtbarkeit, Kategorie‑Beschriftungs‑ und Tick‑Mark‑Intervalle, Datums­kategorien und -formatierung, Titelrotation, Achsenpositionierung, Anzeigeeinheiten und logarithmische Skalierung.

## **Ermitteln der Maximalwerte auf der vertikalen Achse von Diagrammen**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und fügen Sie ein Flächendiagramm mit Standarddaten hinzu. Rufen Sie [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) auf, bevor Sie berechnete Achsenwerte lesen, damit das Diagrammlayout aktuell ist.

Lesen Sie [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) und [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) für die Achsenbegrenzungen sowie [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) und [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) für die Tick‑Intervalle. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) und [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) liefern Zeiteinheiten‑Skalen, die für Datumsachsen relevant sind. Das Beispiel speichert diese Werte in lokalen Variablen und speichert das Diagramm.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Daten zwischen Achsen austauschen**

Verwenden Sie [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/), um die Rollen von Reihen und Spalten in Diagrammdaten zu vertauschen. Jede frühere Kategorie wird zu einer Reihe und jede frühere Reihe zu einer Kategorie. Dies ändert die Daten‑Gruppierung; es tauscht nicht die horizontale und vertikale Achse aus. Das Beispiel verwendet [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/), um die Standarddaten an `Sheet1!A1:D5` (einschließlich Kopfzeile und Kategorien‑Spalte) zu binden, bevor Zeilen und Spalten getauscht werden. Es speichert ein Diagramm mit vier Reihen und drei Kategorien.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Reihenfolge der Darstellung einer Achse umkehren**

Verwenden Sie [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/), um eine Kategorie‑ oder Werteachse umzukehren. Zum Beispiel kann ein horizontales Balkendiagramm Projektphasen von oben nach unten in derselben Reihenfolge wie das Arbeitsblatt anzeigen: Planung, Entwicklung, Testen. Das Umkehren einer Achse ändert die Zeichen­richtung; sie sortiert oder rearrangiert nicht die Arbeitsblattdaten. Im Vergleich dazu tauscht [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) die Rollen von Reihen und Kategorien.

Das folgende Beispiel erstellt ein horizontales Balkendiagramm mit drei Phasen und einer Reihe. Es speichert eine Präsentation mit drei Folien: normale Reihenfolge, umgekehrte Kategorien und umgekehrte Werte. Jede Kopie verwendet denselben Datensatz, und nur eine Achse ist in jeder Kopie umgekehrt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # Folie 2: die erste Kategorie oben anzeigen.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Behalte die horizontale Werteachse unten.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Folie 3: nur die horizontale numerische Skala umkehren.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Das Umkehren einer Achse kann auch die senkrechte Achse auf die gegenüber­liegende Seite des Diagramms verschieben. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) steuert, wo die andere Achse die konfigurierbare Achse schneidet. In Folie 2 wird sie bei `MAXIMUM` auf der umgekehrten Kategorienachse gesetzt, sodass die horizontale Werteachse unten bleibt. Für einen bestimmten Schnittpunkt verwenden Sie [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Prüfen Sie die Schnitt‑Einstellungen, wenn Sie die Richtung ändern, besonders wenn das Diagramm bereits einen benutzerdefinierten Schnittpunkt hat. Setzen Sie `is_plot_order_reversed` zurück auf `False`, um die normale Zeichen­richtung wiederherzustellen; die Schnitt‑Einstellungen sind separat.

| Normale Reihenfolge (Folie 1) | Umgekehrte Kategorien (Folie 2) | Umgekehrte Werte (Folie 3) |
| --- | --- | --- |
| ![Horizontales Balkendiagramm mit normaler Reihenfolge von Kategorien- und Werteachse](axis-order-normal.png) | ![Horizontales Balkendiagramm mit von oben nach unten angezeigten Kategorien](axis-order-categories-reversed.png) | ![Horizontales Balkendiagramm mit umgekehrter Werteachse und Null auf der rechten Seite](axis-order-values-reversed.png) |
| Kategorien laufen von unten nach oben; Werte steigen von links nach rechts. | Planung, Entwicklung und Testen laufen von oben nach unten. Werte und Zeilenreihenfolge der Arbeitsmappe bleiben unverändert. | Kategorien behalten ihre normale Reihenfolge; Werte steigen von rechts nach links. Die Kategorienachse schneidet bei Null auf der rechten Seite. |

## **Vertikale Achse für Liniendiagramme deaktivieren**

Setzen Sie [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) auf `False` bei der vertikalen Achse, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter vertikaler Achse.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Horizontale Achse für Liniendiagramme deaktivieren**

Setzen Sie [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) auf `False` bei der horizontalen Achse, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter horizontaler Achse.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Kategorienachse ändern**

Setzen Sie [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) um zwischen einer Datums‑ oder Text‑Kategorienachse zu wählen. Dieses Beispiel erfordert `ExistingChart.pptx`, wobei das Diagramm das erste Shape auf der ersten Folie ist und die Kategorie‑Zellen numerische Excel‑Datumswerte enthalten. Es ändert die horizontale Achse zu einer Datumsachse. Setzen Sie [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) auf `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) auf `1` und [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) auf Monate, um Haupt‑Ticks im Abstand von einem Monat zu platzieren.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Intervalle für Kategorienachsennamen steuern**

Wenn ein Diagramm viele Kategorien hat, reduzieren Sie die Anzahl sichtbarer Achsen‑Beschriftungen, ohne Kategorien oder Datenpunkte zu entfernen. Setzen Sie [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) auf `False` und dann [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) auf das gewünschte Kategorien‑Intervall. Für Textkategorien in ihrer normalen Reihenfolge beginnt die Zählung bei der ersten Kategorie:

| Intervall | Im Beispiel angezeigte Beschriftungen |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, ... Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, ... Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, ... Kategorie 22 |

Ein Intervall von `3` zeigt jede dritte Beschriftung an und lässt zwei Beschriftungen zwischen den angezeigten verborgen. Es entfernt nicht die entsprechenden Spalten. Automatischer Abstand wählt ein Intervall basierend auf dem verfügbaren Platz; er zeigt nicht unbedingt jede Beschriftung an.

Tick‑Marken haben separate Steuerungen. Setzen Sie [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) auf `False` und verwenden Sie [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/), um ihr Intervall festzulegen. Beispiel: `1` behält eine Tick‑Marke bei jedem Kategorien‑Intervall, während Beschriftungen nur bei jeder dritten Kategorie erscheinen. Setzen Sie [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) auf einen sichtbaren Stil, um das Ergebnis zu sehen. Das Zurücksetzen einer automatischen Abstand‑Eigenschaft auf `True` lässt das Diagramm das Intervall wieder automatisch wählen.

Das folgende eigenständige Beispiel erstellt 24 Kategorien und eine Reihe, speichert dann drei Folien in `CategoryAxisIntervals.pptx`: automatischer Abstand, manueller Beschriftungsabstand mit unabhängigen Tick‑Marken und wiederhergestellter automatischer Abstand. Die beiden Kopien behalten die ursprünglichen Diagrammdaten. Keine Eingabe‑Präsentation ist erforderlich. Horizontale Beschriftungstexte machen die Dichte‑Unterschiede leicht erkennbar.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # Folie 2: jede dritte Beschriftung anzeigen, aber für jede Kategorie eine Tick-Mark beibehalten.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Folie 3: das Diagramm die beiden Intervalle erneut wählen lassen.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatische Abstände (Folie 1):** In dieser Darstellung wird jede zweite Kategorien‑Beschriftung angezeigt und umbrechen auf zwei Zeilen. Das automatische Ergebnis kann je nach Diagrammgröße, Schriftarten und Renderer variieren.

![Automatischer Abstand der Kategorienbeschriftungen bei allen 24 Spalten sichtbar](category-axis-automatic.png)

**Manuelle Abstände (Folie 2):** Jede dritte Beschriftung wird in einer Zeile angezeigt, während Tick‑Marken bei jedem Kategorien‑Intervall verbleiben. Alle 24 Spalten, einschließlich derer ohne Beschriftungen, bleiben mit denselben Werten sichtbar. Folie 3 stellt das oben gezeigte automatische Aussehen wieder her.

![Manuelles Kategorienbeschriftungsintervall von drei bei allen 24 Spalten sichtbar](category-axis-manual.png)

### **Die richtige Achse und das richtige Intervall wählen**

Verwenden Sie dieses Intervall‑Beispiel für eine Text‑Kategorienachse, etwa die Kategorienachse eines Säulen‑, Linien‑, Flächen‑ oder Balkendiagramms. In einem Säulendiagramm ist es die horizontale Achse. In einem horizontalen Balkendiagramm ist die Kategorienachse vertikal, daher wenden Sie diese Einstellungen auf [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) an. Das Tick‑Mark‑Abstand‑Setting gilt auch für eine Reihen‑Achse in Diagrammen, die eine solche besitzen.

Verwenden Sie die Kategorien‑Beschriftungs‑Abstände nicht, um die numerische Skala einer Werteachse festzulegen. Auf einer Werteachse gibt [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) die Differenz der Werte an: ein Haupt‑Unit von `10` erzeugt Ticks bei 0, 10, 20 usw., wenn die Achse bei Null beginnt. Ein Kategorien‑Beschriftungs‑Intervall von `3` zählt stattdessen Kategorienpositionen, ungeachtet ihrer Werte. Streu‑ und Blasendiagramme verwenden Werteachsen statt einer Text‑Kategorienachse. Für eine Datumsachse verwenden Sie zeitbasierte Haupt‑Units und Skalen wie in [Kategorienachse ändern](#kategorienachse-ändern) beschrieben.

## **Datumsformat für Kategorienachsenzahlen festlegen**

Das Beispiel ersetzt die Standard‑Diagrammdaten durch vier Jahreswerte. Daten werden als OLE‑Automation‑Seriennummern im ersten Arbeitsblatt (Index `0`) gespeichert. Setzen Sie [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) auf eine Datumsachse, deaktivieren Sie [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) und weisen Sie `yyyy` [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) zu, damit die Kategorienbeschriftungen vierstellige Jahreszahlen unabhängig von der Zellformatierung anzeigen.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **Drehwinkel für einen Diagrammachsentitel festlegen**

Aktivieren Sie [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) auf der vertikalen Achse, geben Sie einen Titeltext an und setzen Sie [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) zur Drehung des Titels. Der Winkel wird in Grad gemessen; dieses Beispiel speichert ein Säulendiagramm mit um 90° gedrehtem Werteachsen‑Titel.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **Achsenposition für eine Kategorien- oder Werteachse festlegen**

Verwenden Sie [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/), um zu steuern, ob die Werteachse die Kategorienachse zwischen Kategorien oder an den Kategorien‑Ticks kreuzt. Diese Eigenschaft gilt für Kategorienachsen. Das Beispiel setzt sie auf `True` bei der horizontalen Kategorienachse eines Säulendiagramms und speichert das Ergebnis.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Anzeigeeinheit für eine Werteachse festlegen**

Setzen Sie [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) zur Skalierung der Beschriftungen einer Werteachse, ohne die zugrunde liegenden Daten zu ändern. Mit [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) auf `MILLIONS` wird ein Wert von 60 000 000 als 60 angezeigt. Das Beispiel erstellt ein Säulendiagramm und wendet die Anzeigeeinheit Millionen auf die vertikale Achse an.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Logarithmische Werteachse konfigurieren**

Eine logarithmische Werteachse ist nützlich, wenn positive Werte mehrere Größenordnungen umfassen. Zum Beispiel könnte ein Dienst in fünf Perioden 10, 100, 1 000, 10 000 und 100 000 Anfragen erhalten. Auf einer linearen Skala liegen die kleineren Werte dicht beieinander nahe Null. Eine logarithmische Skala macht ihr relatives Wachstum leichter vergleichbar: gleiche Abstände repräsentieren gleiche Verhältnisse statt gleiche Differenzen.

Setzen Sie [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) auf `True` bei der Werteachse und verwenden Sie [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/), um die Basis zu wählen. Dies ändert die Darstellung der bestehenden Werte; es ändert nicht die Daten oder fügt eine logarithmische Trendlinie hinzu. Eine Trendlinie stellt eine angepasste Beziehung in den Daten dar und ist ein separates Feature.

### **Werteachse und Basis wählen**

Für ein Linien‑ oder Säulendiagramm ist die Werteachse [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Für ein horizontales Balkendiagramm ist sie [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Streu‑ und Blasendiagramme besitzen zwei Werteachsen, daher wählen Sie die horizontale Achse für X‑Werte, die vertikale Achse für Y‑Werte oder beide. Wenden Sie keine logarithmische Skalierung auf eine Kategorienachse an.

Die Standard‑Logarithmus‑Basis ist `10`. Für PPTX‑Diagramme verwenden Sie eine Basis zwischen `2` und `1000`, inklusiv; Bruch‑Basen wie `2.5` werden ebenfalls unterstützt. Bei Basis `10` sind aufeinanderfolgende Potenzen wie 10, 100, 1 000 und 10 000 gleichmäßig verteilt.

### **Lineare und logarithmische Skalierung vergleichen**

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit den fünf Anfragenzahlen auf der ersten Folie, klont dann diese Folie und aktiviert eine logarithmische Werteachse zur Basis 10 auf der zweiten. Beide Folien behalten dieselben Daten.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Behalte die erste Folie linear und ändere nur die Skalierung der Werteachse der Kopie.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Lineare Skalierung (Folie 1):** Gleiche vertikale Abstände repräsentieren gleiche Unterschiede in den Anfragenzahlen. Der größte Wert dominiert das Diagramm, wodurch die kleineren Werte schwer zu unterscheiden sind.

![Liniendiagramm in PowerPoint, das fünf Anfragenzahlen auf einer linearen Werteachse zeigt](value-axis-linear.png)

**Logarithmische Skalierung (Folie 2):** Gleiche vertikale Abstände repräsentieren gleiche Verhältnisse. Jeder Zeitraum hat zehnmal so viele Anfragen wie der vorherige, sodass die Punkte auf der Basis‑10‑Skala eine gerade Aufwärtslinie bilden. Die Achsen‑Beschriftungen zeigen weiterhin die ursprünglichen Anfragenzahlen.

![Die gleichen fünf Anfragenzahlen in PowerPoint auf einer logarithmischen Werteachse zur Basis 10](value-axis-logarithmic.png)

### **Umgang mit Null- und Negativwerten**

Eine logarithmische Skala kann nur strikt positive Werte anzeigen. Überprüfen Sie die Daten, bevor Sie sie aktivieren. Wenn Null‑ oder Negativwerte bedeutungsvoll sind, behalten Sie eine lineare Skala bei oder zeigen Sie sie separat. Wenn das Ausschließen dieser Werte für die Analyse sinnvoll ist, erklären Sie das Weglassen. Ersetzen Sie sie nicht stillschweigend durch kleine positive Zahlen, da dies die Datenbedeutung ändert. Jeder manuell konfigurierte Minimal‑ oder Maximalwert für eine logarithmische Achse muss ebenfalls positiv sein.

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsschnittpunkt)?**

Verwenden Sie [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/), um das Schnitt‑Verhalten auszuwählen. Um einen numerischen Schnittwert zu bestimmen, setzen Sie [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Diese Einstellungen ermöglichen es, den Achsschnitt zu einer passenden Basislinie zu verschieben.

**Wie kann ich die Tick‑Beschriftungen relativ zur Achse positionieren?**

Setzen Sie [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) mit [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` oder `NONE`. Um die Tick‑Marken selbst zu steuern, verwenden Sie [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) oder [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); diese sind von der Beschriftungsposition getrennt.