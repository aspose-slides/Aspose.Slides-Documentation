---
title: Diagramme in Präsentationen mit Python formatieren
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/python-net/chart-formatting/
keywords:
- Diagramm formatieren
- Diagrammformatierung
- Diagramm-Entität
- Diagramm-Eigenschaften
- Diagramm-Einstellungen
- Diagramm-Optionen
- Schrifteigenschaften
- Abgerundete Rahmen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides für Python über .NET formatieren und verleihen Sie Ihrer PowerPoint- oder OpenDocument-Präsentation ein professionelles, ansprechendes Design."
---

## **Übersicht**

Dieser Leitfaden zeigt, wie Diagramme in PowerPoint mit Aspose.Slides für Python formatiert werden. Er führt durch die Anpassung von Kern-Diagrammelementen – wie Kategorien‑ und Werte‑Achsen, Gitternetzlinien, Beschriftungen, Titeln, Legenden und sekundären Achsen – und demonstriert, wie Schriftarten, Zahlenformate, Füllungen, Konturen, Plot‑Bereichs‑ und Hintergrundwand‑Farben sowie abgerundete Diagrammecken mit knappen, ausführbaren Code‑Beispielen gesteuert werden. Durch die schrittweise Vorgehensweise erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), fügen ein Diagramm hinzu und konfigurieren es und speichern das Ergebnis als PPTX, wobei präzise visuelle und typografische Einstellungen angewendet werden.

## **Diagrammelemente formatieren**

Aspose.Slides für Python ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Abschnitt erklärt, wie verschiedene Diagrammelemente formatiert werden, einschließlich der Kategorien‑ und Werte‑Achsen.

Aspose.Slides bietet eine einfache API zum Verwalten von Diagrammelementen und zum Anwenden benutzerdefinierter Formatierungen:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf die Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten des gewünschten Typs hinzu (in diesem Beispiel `ChartType.LINE_WITH_MARKERS`).
1. Greifen Sie auf die Werte‑Achse des Diagramms zu und setzen Sie Folgendes:
   1. Setzen Sie das **Linienformat** für die Hauptgitternetzlinien der Werte‑Achse.
   1. Setzen Sie das **Linienformat** für die Hilfsgitternetzlinien der Werte‑Achse.
   1. Setzen Sie das **Zahlenformat** für die Werte‑Achse.
   1. Setzen Sie die **Min‑, Max‑, Haupt‑ und Hilfs‑Einheiten** für die Werte‑Achse.
   1. Setzen Sie die **Texteigenschaften** für die Werte‑Achsen‑Beschriftungen.
   1. Setzen Sie den **Titel** für die Werte‑Achse.
   1. Setzen Sie das **Linienformat** für die Werte‑Achse.
1. Greifen Sie auf die Kategorien‑Achse des Diagramms zu und setzen Sie Folgendes:
   1. Setzen Sie das **Linienformat** für die Hauptgitternetzlinien der Kategorien‑Achse.
   1. Setzen Sie das **Linienformat** für die Hilfsgitternetzlinien der Kategorien‑Achse.
   1. Setzen Sie die **Texteigenschaften** für die Kategorien‑Achsen‑Beschriftungen.
   1. Setzen Sie den **Titel** für die Kategorien‑Achse.
   1. Setzen Sie die **Beschriftungsposition** für die Kategorien‑Achse.
   1. Setzen Sie den **Rotationswinkel** für die Kategorien‑Achsen‑Beschriftungen.
1. Greifen Sie auf die Diagramm‑Legende zu und setzen Sie deren **Texteigenschaften**.
1. Zeigen Sie die Diagramm‑Legende an, ohne das Diagramm zu überlappen.
1. Greifen Sie auf die **sekundäre Werte‑Achse** des Diagramms zu und setzen Sie Folgendes:
   1. Aktivieren Sie die sekundäre **Werte‑Achse**.
   1. Setzen Sie das **Linienformat** für die sekundäre Werte‑Achse.
   1. Setzen Sie das **Zahlenformat** für die sekundäre Werte‑Achse.
   1. Setzen Sie die **Min‑, Max‑, Haupt‑ und Hilfs‑Einheiten** für die sekundäre Werte‑Achse.
1. Plotten Sie die erste Diagramm‑Serie auf der sekundären Werte‑Achse.
1. Setzen Sie die Füllfarbe der Hintergrundwand des Diagramms.
1. Setzen Sie die Füllfarbe des Plot‑Bereichs des Diagramms.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse.
with slides.Presentation() as presentation:

    # Greifen Sie auf die erste Folie zu.
    slide = presentation.slides[0]

    # Fügen Sie ein Beispiel-Diagramm hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Setzen Sie den Diagrammtitel.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Setzen Sie das Hauptgitterlinienformat für die Werteachse.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Setzen Sie das Hilfsgitterlinienformat für die Werteachse.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Setzen Sie das Zahlenformat der Werteachse.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Setzen Sie den Maximalwert, Minimalwert, Haupteinheit und Hilfseinheit der Werteachse.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Setzen Sie die Texteigenschaften der Werteachse.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Setzen Sie den Titel der Werteachse.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Setzen Sie das Hauptgitterlinienformat für die Kategorienachse.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Setzen Sie das Hilfsgitterlinienformat für die Kategorienachse.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Setzen Sie die Texteigenschaften der Kategorienachse.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Setzen Sie den Titel der Kategorienachse.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Setzen Sie die Beschriftungsposition der Kategorienachse.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Setzen Sie den Rotationswinkel der Beschriftungen der Kategorienachse.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Setzen Sie die Texteigenschaften der Legende.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Zeigen Sie die Diagrammlegende überlappend zum Diagramm an.
    chart.legend.overlay = True
                
    # Setzen Sie die Farbe der Hintergrundwand des Diagramms.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Setzen Sie die Farbe des Plotbereichs.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Speichern Sie die Präsentation.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```


## **Diagramm‑Schrifteigenschaften festlegen**

Aspose.Slides für Python unterstützt das Festlegen von schriftbezogenen Eigenschaften für Diagramme. Befolgen Sie die nachstehenden Schritte, um Diagramm‑Schrifteigenschaften zu konfigurieren:

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekt.
1. Fügen Sie ein Diagramm zur Folie hinzu.
1. Setzen Sie die Schriftgröße.
1. Speichern Sie die modifizierte Präsentation.

Ein Beispielcode wird unten bereitgestellt.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```


## **Numerisches Format festlegen**

Aspose.Slides für Python bietet eine einfache API zum Verwalten von Diagrammdatenformaten:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf die Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten eines beliebigen gewünschten Typs hinzu.
1. Wählen Sie ein vordefiniertes Zahlenformat aus den verfügbaren Vorgabewerten.
1. Durchlaufen Sie die Diagrammdatenzellen jeder Serie und setzen Sie das Zahlenformat.
1. Speichern Sie die Präsentation.
1. Setzen Sie ein benutzerdefiniertes Zahlenformat.
1. Durchlaufen Sie die Diagrammdatenzellen jeder Serie und setzen Sie ein anderes Zahlenformat.
1. Speichern Sie die Präsentation.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse.
with slides.Presentation() as presentation:
    # Greifen Sie auf die erste Folie zu.
    slide = presentation.slides[0]

    # Fügen Sie ein standardmäßiges gruppiertes Säulendiagramm hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Setzen Sie das vordefinierte Zahlenformat.
    # Durchlaufen Sie jede Diagrammserie.
    for series in chart.chart_data.series:
        # Durchlaufen Sie jeden Datenpunkt in der Serie.
        for cell in series.data_points:
            # Setzen Sie das Zahlenformat.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Speichern Sie die Präsentation.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```


Die verfügbaren vordefinierten Zahlenformate und ihre jeweiligen Indizes sind unten aufgelistet.

|**0**|Allgemein|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Abgerundete Ränder für den Diagrammbereich festlegen**

Aspose.Slides für Python unterstützt die Konfiguration des Diagrammbereichs über die Eigenschaft `Chart.has_rounded_corners`.

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekt.
2. Fügen Sie ein Diagramm zur Folie hinzu.
3. Setzen Sie den Fülltyp und die Füllfarbe des Diagramms.
4. Setzen Sie die Eigenschaft für abgerundete Ecken auf `True`.
5. Speichern Sie die modifizierte Präsentation.

Ein Beispiel wird unten bereitgestellt.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich halbtransparente Füllungen für Spalten/Bereiche festlegen, während die Kontur undurchsichtig bleibt?**

Ja. Transparenz der Füllung und die Kontur werden separat konfiguriert. Das ist nützlich, um die Lesbarkeit von Gittern und Daten in dicht besetzten Visualisierungen zu verbessern.

**Wie gehe ich mit Datenbeschriftungen um, wenn sie sich überschneiden?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungselemente (z. B. Kategorien), setzen Sie den Beschriftungs‑Offset/‑Position, zeigen Sie Beschriftungen nur für ausgewählte Punkte an oder wechseln Sie zum Format „Wert + Legende“.

**Kann ich Farbverläufe oder Musterfüllungen auf Serien anwenden?**

Ja. Sowohl einfarbige als auch Verlauf‑/Musterfüllungen sind in der Regel verfügbar. In der Praxis sollten Verläufe sparsam eingesetzt und Kombinationen vermieden werden, die den Kontrast zu Gittern und Text verringern.