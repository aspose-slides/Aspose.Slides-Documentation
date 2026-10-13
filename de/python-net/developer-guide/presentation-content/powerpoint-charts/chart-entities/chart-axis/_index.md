---
title: Diagrammachsen in Präsentationen mit Python anpassen
linktitle: Diagrammachse
type: docs
url: /de/python-net/chart-axis/
keywords:
- Diagrammachse
- Vertikale Achse
- Horizontale Achse
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
description: "Erfahren Sie, wie Sie Aspose.Slides für Python über .NET verwenden, um Diagrammachsen in PowerPoint- und OpenDocument-Präsentationen für Berichte und Visualisierungen anzupassen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Diagrammachsen mit Aspose.Slides für Python über .NET angepasst werden können. Er behandelt berechnete Achsenwerte, das Vertauschen von Diagrammzeilen und -spalten, die Sichtbarkeit von Achsen, Intervall von Kategorienbeschriftungen und Teilstrichmarken, Datums‑Kategorien und Formatierung, Titelrotation, Achsenpositionierung, Anzeige‑Einheiten und logarithmische Skalierung.

## **Maximalwerte auf der vertikalen Achse in Diagrammen abrufen**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und fügen Sie ein Flächendiagramm mit Standarddaten hinzu. Rufen Sie [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) auf, bevor Sie berechnete Achsenwerte lesen, damit das Diagrammlayout aktuell ist.

Lesen Sie [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) und [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) für die Achsenbegrenzungen sowie [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) und [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) für die Teilstrich‑Abstände. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) und [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) liefern Zeiteinheitsskalen, die für Datumsachsen relevant sind. Das Beispiel speichert diese Werte in lokalen Variablen und speichert das Diagramm.

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

Verwenden Sie [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/), um die Rollen von Reihen und Kategorien in Diagrammdaten zu vertauschen. Jede frühere Kategorie wird zu einer Reihe und jede frühere Reihe zu einer Kategorie. Dies ändert, wie die Daten gruppiert werden; es tauscht nicht die horizontale und vertikale Achse aus. Das Beispiel nutzt [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) , um die Standarddaten an `Sheet1!A1:D5` zu binden, einschließlich der Kopfzeile und der Kategoriespalte, bevor Zeilen und Spalten vertauscht werden. Es speichert ein Diagramm mit vier Reihen und drei Kategorien.

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

## **Vertikale Achse bei Liniendiagrammen deaktivieren**

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

## **Horizontale Achse bei Liniendiagrammen deaktivieren**

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

## **Eine Kategorienachse ändern**

Setzen Sie [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) , um eine Datums‑ oder Text‑Kategorienachse auszuwählen. Dieses Beispiel erfordert `ExistingChart.pptx`, wobei das Diagramm die erste Form auf der ersten Folie ist und die Kategorienzellen numerische Excel‑Datumswerte enthalten. Es ändert die horizontale Achse zu einer Datumsachse. Das Setzen von [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) auf `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) auf `1` und [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) auf Monate legt Hauptteilstriche im Abstand von einem Monat fest.

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

## **Intervall für Kategorienachsenbeschriftungen steuern**

Wenn ein Diagramm viele Kategorien hat, kann die Anzahl sichtbarer Achsenbeschriftungen reduziert werden, ohne Kategorien oder Datenpunkte zu entfernen. Setzen Sie [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) auf `False` und anschließend [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) auf das gewünschte Kategorienintervall. Für Textkategorien in ihrer normalen Reihenfolge beginnt die Zählung bei der ersten Kategorie:

| Intervall | Im Beispiel angezeigte Beschriftungen |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, ... Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, ... Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, ... Kategorie 22 |

Ein Intervall von `3` zeigt jede dritte Beschriftung an und lässt zwischen den angezeigten Beschriftungen zwei ausgeblendet. Es entfernt nicht die entsprechenden Spalten. Die automatische Abstandsbestimmung wählt ein Intervall basierend auf dem verfügbaren Platz; sie zeigt nicht zwingend jede Beschriftung an.

Teilstrichmarken haben separate Einstellungen. Setzen Sie [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) auf `False` und verwenden Sie [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) , um ihr Intervall festzulegen. Zum Beispiel hält `1` eine Teilstrichmarke bei jedem Kategorienintervall, während Beschriftungen nur bei jeder dritten Kategorie erscheinen. Setzen Sie [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) auf einen sichtbaren Stil, damit Sie das Ergebnis sehen können. Das Zurücksetzen einer automatischen Abstandseigenschaft auf `True` lässt das Diagramm das Intervall erneut wählen.

Das folgende eigenständige Beispiel erstellt 24 Kategorien und eine Reihe, speichert dann drei Folien in `CategoryAxisIntervals.pptx`: automatischer Abstand, manuelle Beschriftungsabstände mit unabhängigen Teilstrichmarken und wiederhergestellter automatischer Abstand. Die beiden Kopien behalten die ursprünglichen Diagrammdaten. Keine Eingabedatei ist erforderlich. Der horizontale Beschriftungstext macht den Unterschied in der Dichte leicht sichtbar.

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

    # Folie 2: jede dritte Beschriftung anzeigen, aber für jede Kategorie eine Teilstrichmarke beibehalten.
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

**Automatischer Abstand (Folien 1):** In dieser Darstellung wird jede zweite Kategorienbeschriftung angezeigt und umbrechen in zwei Zeilen. Das automatische Ergebnis kann je nach Diagrammgröße, Schriftarten und Renderer variieren.

![Automatischer Kategorienbeschriftungsabstand bei allen 24 Spalten sichtbar](category-axis-automatic.png)

**Manueller Abstand (Folien 2):** Jede dritte Beschriftung wird in einer Zeile angezeigt, während Teilstrichmarken bei jedem Kategorienintervall bleiben. Alle 24 Spalten, einschließlich der ohne Beschriftungen, bleiben mit denselben Werten sichtbar. Folie 3 stellt das oben gezeigte automatische Erscheinungsbild wieder her.

![Manuelles Kategorienbeschriftungsintervall von drei bei allen 24 Spalten sichtbar](category-axis-manual.png)

### **Den korrekten Achsen- und Intervalltyp wählen**

Verwenden Sie dieses Kategorien‑Zähl‑Intervall für eine Text‑Kategorienachse, etwa die Kategorienachse eines Säulen‑, Linien‑, Flächen‑ oder Balkendiagramms. In einem Säulendiagramm ist sie die horizontale Achse. In einem horizontalen Balkendiagramm ist die Kategorienachse vertikal, daher wenden Sie diese Einstellungen auf [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) an. Der Abstand von Teilstrichmarken gilt auch für eine Reihenachse in Diagrammen, die eine besitzen.

Verwenden Sie die Kategorien‑Beschriftungsabstände nicht, um die numerische Skala einer Werteachse festzulegen. Auf einer Werteachse gibt [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) einen Werteunterschied an: Ein Hauptintervall von `10` erzeugt Teilstriche bei 0, 10, 20 usw., wenn die Achse bei Null beginnt. Ein Kategorien‑Beschriftungsintervall von `3` zählt stattdessen die Kategorienpositionen, unabhängig von deren Datenwerten. Streu‑ und Blasendiagramme verwenden Werteachsen statt einer Text‑Kategorienachse. Für eine Datumsachse verwenden Sie zeitbasierte Haupteinheiten und Skalen wie im Abschnitt [Eine Kategorienachse ändern](#eine-kategorienachse-ändern) beschrieben.

## **Datumsformat für Kategorienachsenwerte festlegen**

Das Beispiel ersetzt die Standarddiagrammdaten durch vier Jahreswerte. Daten werden als OLE‑Automation‑Seriennummern im ersten Arbeitsblatt (Index `0`) gespeichert. Setzen Sie [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) auf eine Datumsachse, deaktivieren Sie [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) und weisen Sie `yyyy` [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) zu, damit die Kategorienbeschriftungen unabhängig von der Zellformatierung vierstellige Jahreszahlen anzeigen.

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

## **Rotationswinkel für einen Diagrammachsentitel festlegen**

Aktivieren Sie [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) auf der vertikalen Achse, geben Sie den Titeltext an und setzen Sie [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) , um den Titel zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel speichert ein Säulendiagramm mit um 90 Grad gedrehtem Werteachsentitel.

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

## **Achsenposition auf einer Kategorien‑ oder Werteachse festlegen**

Verwenden Sie [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) , um zu steuern, ob die Werteachse die Kategorienachse zwischen Kategorien oder an den Kategorien‑Teilstrichmarken schneidet. Diese Eigenschaft gilt für Kategorienachsen. Das Beispiel setzt sie auf `True` bei der horizontalen Kategorienachse eines Säulendiagramms und speichert das Ergebnis.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Anzeigeeinheit auf einer Diagramm‑Werteachse festlegen**

Setzen Sie [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) , um die Beschriftungen einer Werteachse zu skalieren, ohne die zugrunde liegenden Daten zu ändern. Mit [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) auf `MILLIONS` wird ein Wert von 60 000 000 als 60 angezeigt. Das Beispiel erstellt ein Säulendiagramm und wendet die Millionen‑Anzeige‑Einheit auf seine vertikale Achse an.

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

Eine logarithmische Werteachse ist nützlich, wenn positive Werte mehrere Größenordnungen umfassen. Beispiel: Ein Dienst könnte über fünf Zeiträume 10, 100, 1 000, 10 000 und 100 000 Anfragen erhalten. Bei einer linearen Skala erscheinen die kleineren Werte nahe beieinander bei Null. Eine logarithmische Skala macht ihr relatives Wachstum leichter vergleichbar: Gleiche Abstände repräsentieren gleiche Verhältnisse statt gleicher Unterschiede.

Setzen Sie [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) auf `True` bei der Werteachse und verwenden Sie [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) , um die Basis zu wählen. Dies ändert, wie die vorhandenen Werte angezeigt werden; Daten werden nicht verändert und es wird keine logarithmische Trendlinie hinzugefügt. Eine Trendlinie stellt eine angepasste Beziehung in den Daten dar und ist ein separates Feature.

### **Wertachse und Basis auswählen**

Für ein Linien‑ oder Säulendiagramm ist die Werteachse [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Für ein horizontales Balkendiagramm ist sie [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Streu‑ und Blasendiagramme besitzen zwei Werteachsen, sodass Sie die horizontale Achse für X‑Werte, die vertikale Achse für Y‑Werte oder beide wählen. Logarithmische Skalierung darf nicht auf einer Kategorienachse angewendet werden.

Die Standard‑Logarithmus‑Basis ist `10`. Für PPTX‑Diagramme kann eine Basis von `2` bis `1000` verwendet werden; Bruchbasen wie `2.5` werden ebenfalls unterstützt. Mit Basis `10` sind aufeinanderfolgende Potenzen wie 10, 100, 1 000 und 10 000 gleichmäßig verteilt.

### **Lineare und logarithmische Skalierung vergleichen**

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit den fünf Anfragesummen auf der ersten Folie, dupliziert diese Folie und aktiviert auf der zweiten eine logarithmische Werteachse mit Basis 10. Beide Folien behalten dieselben Daten.

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

    # Behalte die erste Folie linear und ändere nur die Wertachsen-Skala der Kopie.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Lineare Skalierung (Folien 1):** Gleichmäßige vertikale Abstände repräsentieren gleiche Unterschiede in den Anfragesummen. Der höchste Wert dominiert das Diagramm, sodass die kleineren Werte schwer zu unterscheiden sind.

![Liniendiagramm in PowerPoint, das fünf Anfragesummen auf einer linearen Werteachse zeigt](value-axis-linear.png)

**Logarithmische Skalierung (Folien 2):** Gleichmäßige vertikale Abstände repräsentieren gleiche Verhältnisse. Jede Periode hat zehnmal so viele Anfragen wie die vorherige, sodass die Punkte auf einer Basis‑10‑Skala eine gerade Aufwärtslinie bilden. Die Achsenbeschriftungen zeigen weiterhin die ursprünglichen Anfragesummen.

![Die gleichen fünf Anfragesummen in PowerPoint auf einer logarithmischen Werteachse mit Basis 10](value-axis-logarithmic.png)

### **Umgang mit Null- und Negativwerten**

Eine logarithmische Skala kann nur strikt positive Werte darstellen. Prüfen Sie die Daten, bevor Sie sie aktivieren. Wenn Null‑ oder Negativwerte sinnvoll sind, behalten Sie eine lineare Skala bei oder zeigen Sie sie separat. Ist das Ausschließen dieser Werte für die Analyse angebracht, erklären Sie die Auslassung. Ersetzen Sie sie nicht stillschweigend durch kleine positive Zahlen, da dies die Bedeutung der Daten verändert. Jeder manuell konfigurierte Minimal‑ oder Maximalwert für eine logarithmische Achse muss ebenfalls positiv sein.

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsschnittpunkt)?**

Verwenden Sie [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/), um das Schneideverhalten auszuwählen. Um einen numerischen Schnittwert anzugeben, setzen Sie [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Mit diesen Einstellungen können Sie den Achsschnitt zu einer geeigneten Basis verschieben.

**Wie kann ich Teilstrich‑Beschriftungen relativ zur Achse positionieren?**

Setzen Sie [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) unter Verwendung von [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) auf `LOW`, `HIGH`, `NEXT_TO` oder `NONE`. Um die Teilstrichmarken selbst zu steuern, verwenden Sie [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) oder [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); diese sind unabhängig von der Beschriftungsposition.