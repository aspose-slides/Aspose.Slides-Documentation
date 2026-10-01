---
title: Diagrammachsen in Präsentationen mit Python anpassen
linktitle: Diagrammachse
type: docs
url: /de/python-net/chart-axis/
keywords:
- Diagrammachse
- vertikale Achse
- horizontale Achse
- Achsen anpassen
- Achsen manipulieren
- Achsen verwalten
- Achsen-Eigenschaften
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
description: "Erfahren Sie, wie Sie Aspose.Slides für Python via .NET verwenden, um Diagrammachsen in PowerPoint- und OpenDocument-Präsentationen für Berichte und Visualisierungen anzupassen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Diagrammachsen mit Aspose.Slides für Python via .NET angepasst werden können. Er behandelt berechnete Achsenwerte, das Vertauschen von Diagrammzeilen und -spalten, Achsensichtbarkeit, Kategorie‑Beschriftungs‑ und Ticks‑Abstände, Datums‑Kategorien und -Formatierung, Titelrotation, Achsenpositionierung und Anzeige­einheiten.

## **Maximalwerte auf der vertikalen Achse von Diagrammen ermitteln**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und fügen Sie ein Flächendiagramm mit Standarddaten hinzu. Rufen Sie [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) auf, bevor Sie berechnete Achsenwerte lesen, damit das Diagrammlayout aktuell ist.

Lesen Sie [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) und [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) für die Achsenbegrenzungen, sowie [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) und [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) für die Tick‑Abstände. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) und [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) liefern Zeiteinheitsskalen, die für Datumsachsen relevant sind. Das Beispiel speichert diese Werte in lokalen Variablen und speichert das Diagramm.

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

Verwenden Sie [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) , um die Rollen von Reihen und Kategorien in Diagrammdaten zu vertauschen. Jede frühere Kategorie wird zu einer Serie und jede frühere Serie zu einer Kategorie. Dies ändert die Gruppierung der Daten; es tauscht nicht die horizontale und vertikale Achse aus. Das Beispiel verwendet [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) , um die Standarddaten an `Sheet1!A1:D5` zu binden, einschließlich der Kopfzeile und der Kategorien‑Spalte, bevor Zeilen und Spalten vertauscht werden. Es speichert ein Diagramm mit vier Serien und drei Kategorien.

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

## **Kategorieachse ändern**

Setzen Sie [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) , um eine Datums‑ oder Text‑Kategorieachse zu wählen. Dieses Beispiel erfordert `ExistingChart.pptx`, wobei das Diagramm die erste Form auf der ersten Folie ist und die Kategoriezellen numerische Excel‑Datumswerte enthalten. Es ändert die horizontale Achse zu einer Datumsachse. Durch Setzen von [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) auf `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) auf `1` und [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) auf Monate werden Hauptticks im Abstand von einem Monat platziert.

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

## **Intervall für Kategorieachsen‑Beschriftungen steuern**

Wenn ein Diagramm viele Kategorien hat, reduzieren Sie die Anzahl sichtbarer Achsenbeschriftungen, ohne Kategorien oder Datenpunkte zu entfernen. Setzen Sie [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) auf `False` und dann [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) auf das gewünschte Kategorienintervall. Bei Textkategorien in ihrer normalen Reihenfolge beginnt die Zählung bei der ersten Kategorie:

| Intervall | Im Beispiel angezeigte Beschriftungen |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Ein Intervall von `3` zeigt jede dritte Beschriftung an und lässt zwei Beschriftungen zwischen den angezeigten ausgeblendet. Es entfernt die entsprechenden Spalten nicht. Automatischer Abstand wählt ein Intervall basierend auf dem verfügbaren Platz; er zeigt nicht unbedingt jede Beschriftung an.

Ticken haben separate Steuerungen. Setzen Sie [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) auf `False` und verwenden Sie [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) , um ihr Intervall festzulegen. Zum Beispiel hält `1` einen Tick bei jedem Kategorienintervall, während Beschriftungen nur jede dritte Kategorie erscheinen. Setzen Sie [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) auf einen sichtbaren Stil, damit Sie das Ergebnis sehen können. Das Zurücksetzen einer der automatischen Abstandseigenschaften auf `True` lässt das Diagramm das Intervall erneut wählen.

Das folgende eigenständige Beispiel erstellt 24 Kategorien und eine Serie, speichert dann drei Folien in `CategoryAxisIntervals.pptx`: automatischer Abstand, manueller Beschriftungsabstand mit unabhängigen Ticken und wiederhergestellter automatischer Abstand. Die beiden Kopien behalten die Original‑Diagrammdaten bei. Es wird keine Eingabe‑Präsentation benötigt. Der horizontale Beschriftungstext macht den Unterschied in der Dichte leicht erkennbar.

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

    # Folie 2: jede dritte Beschriftung anzeigen, aber einen Tick‑Mark für jede Kategorie beibehalten.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Folie 3: das Diagramm beide Intervalle erneut wählen lassen.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatischer Abstand (Folie 1):** In dieser Darstellung wird jede zweite Kategorienbeschriftung angezeigt und auf zwei Zeilen umgebrochen. Das automatische Ergebnis kann je nach Diagrammgröße, Schriftart und Renderer variieren.

![Automatischer Kategorienbeschriftungsabstand bei allen 24 Spalten sichtbar](category-axis-automatic.png)

**Manueller Abstand (Folie 2):** Jede dritte Beschriftung wird in einer Zeile angezeigt, während Ticken bei jedem Kategorienintervall bleiben. Alle 24 Spalten, einschließlich derjenigen ohne Beschriftungen, bleiben mit den gleichen Werten sichtbar. Folie 3 stellt das oben gezeigte automatische Aussehen wieder her.

![Manuelles Kategorienbeschriftungsintervall von drei bei allen 24 Spalten sichtbar](category-axis-manual.png)

### **Den richtigen Achsen‑ und Intervall‑Wert wählen**

Verwenden Sie dieses Kategorie‑Zähl‑Intervall für eine Text‑Kategorieachse, z. B. die Kategorieachse eines Säulen‑, Linien‑, Flächen‑ oder Balkendiagramms. In einem Säulendiagramm ist sie die horizontale Achse. In einem horizontalen Balkendiagramm ist die Kategorieachse vertikal, weshalb diese Einstellungen auf [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) anzuwenden sind. Der Tick‑Abstand gilt auch für eine Serienachse in Diagrammen, die eine besitzen.

Verwenden Sie die Kategorie‑Beschriftungsabstände nicht, um die numerische Skalierung einer Wertachse festzulegen. Auf einer Wertachse gibt [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) eine Werte‑Differenz an: Zum Beispiel erzeugt eine Haupteinheit von `10` Ticks bei 0, 10, 20 usw., wenn die Achse bei Null beginnt. Ein Kategorien‑Beschriftungsintervall von `3` zählt stattdessen die Kategorienpositionen, unabhängig von deren Datenwerten. Streu‑ und Blasendiagramme verwenden Wertachsen anstelle einer Text‑Kategorieachse. Für eine Datumsachse verwenden Sie zeitbasierte Haupteinheiten und Skalen wie in [Change a Category Axis](#change-a-category-axis) beschrieben.

## **Datumsformat für Kategorieachsen‑Werte festlegen**

Das Beispiel ersetzt die Standarddaten des Diagramms durch vier Jahreswerte. Daten werden als OLE‑Automation‑Seriennummern im ersten Arbeitsblatt (Index `0`) gespeichert. Setzen Sie [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) auf eine Datumsachse, deaktivieren Sie [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) und weisen Sie `yyyy` [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) zu, sodass die Kategoriebeschriftungen vierstellige Jahreszahlen unabhängig von der Zellformatierung anzeigen.

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

Aktivieren Sie [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) auf der vertikalen Achse, geben Sie den Titelt​​ext an und setzen Sie [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) , um den Titel zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel speichert ein Säulendiagramm mit um 90 Grad gedrehtem Titel der Wertachse.

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

## **Achsenposition bei einer Kategorie‑ oder Wertachse festlegen**

Verwenden Sie [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) , um zu steuern, ob die Wertachse die Kategorieachse zwischen Kategorien oder an den Kategorien‑Tick‑Marken kreuzt. Diese Eigenschaft gilt für Kategorieachsen. Das Beispiel setzt sie auf `True` bei der horizontalen Kategorieachse eines Säulendiagramms und speichert das Ergebnis.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Anzeigeeinheit auf einer Diagramm‑Wertachse festlegen**

Setzen Sie [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) , um die Beschriftungen einer Wertachse zu skalieren, ohne die zugrunde liegenden Daten zu ändern. Mit [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) auf `MILLIONS` wird ein Wert von 60 000 000 als 60 angezeigt. Das Beispiel erstellt ein Säulendiagramm und wendet die Millionen‑Anzeigeeinheit auf die vertikale Achse an.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenschnitt)?**

Verwenden Sie [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) , um das Kreuzungs‑Verhalten auszuwählen. Um einen numerischen Kreuzungswert anzugeben, setzen Sie [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) . Diese Einstellungen ermöglichen es Ihnen, den Achsenschnitt zu einer geeigneten Basislinie zu verschieben.

**Wie kann ich Tick‑Beschriftungen relativ zur Achse positionieren?**

Setzen Sie [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) mit [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) : `LOW`, `HIGH`, `NEXT_TO` oder `NONE`. Um die Tick‑Marken selbst zu steuern, verwenden Sie [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) oder [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) ; diese sind von der Beschriftungspositionierung getrennt.