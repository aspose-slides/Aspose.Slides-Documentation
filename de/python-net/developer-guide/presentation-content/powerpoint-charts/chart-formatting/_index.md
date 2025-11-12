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
- Diagrammeigenschaften
- Diagrammeinstellungen
- Diagrammoptionen
- Schriftarteigenschaften
- abgerundete Rahmen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides für Python via .NET formatieren und Ihre PowerPoint- oder OpenDocument-Präsentation mit professionellem, auffälligem Styling aufwerten."
---

## **Übersicht**

Dieses Handbuch zeigt, wie man PowerPoint‑Diagramme mithilfe von Aspose.Slides für Python formatieren kann. Es führt durch die Anpassung zentraler Diagrammelemente — wie Kategorien‑ und Werteachsen, Gitternetzlinien, Beschriftungen, Titel, Legenden und Sekundärachsen — und demonstriert, wie man Schriftarten, Zahlenformate, Füllungen, Konturen, Plot‑Bereich‑ und Rückwandfarben sowie abgerundete Diagrammecken mit prägnanten, ausführbaren Codebeispielen steuert. Durch die schrittweisen Beispiele erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), fügen ein Diagramm hinzu, konfigurieren es und speichern das Ergebnis als PPTX, während Sie genaue visuelle und typografische Einstellungen anwenden.

## **Diagrammelemente formatieren**

Aspose.Slides für Python ermöglicht Entwicklern das Hinzufügen benutzerdefinierter Diagramme zu Folien von Grund auf. Dieser Abschnitt erklärt, wie verschiedene Diagrammelemente, einschließlich der Kategorien‑ und Werteachsen, formatiert werden.

Aspose.Slides stellt eine einfache API zum Verwalten von Diagrammelementen und zum Anwenden benutzerdefinierter Formatierungen bereit:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Referenz zur Folie nach ihrem Index.  
3. Fügen Sie ein Diagramm mit Standarddaten des gewünschten Typs hinzu (in diesem Beispiel `ChartType.LINE_WITH_MARKERS`).  
4. Greifen Sie auf die Werteachse des Diagramms zu und setzen Sie Folgendes:  
   1. Das **Linienformat** für Hauptgitterlinien der Werteachse.  
   2. Das **Linienformat** für Neben­gitterlinien der Werteachse.  
   3. Das **Zahlenformat** für die Werteachse.  
   4. **Min‑, Max‑, Haupt‑ und Nebeneinheiten** für die Werteachse.  
   5. Die **Texteigenschaften** für Achsenbeschriftungen.  
   6. Den **Titel** für die Werteachse.  
   7. Das **Linienformat** für die Werteachse.  
5. Greifen Sie auf die Kategorienachse des Diagramms zu und setzen Sie Folgendes:  
   1. Das **Linienformat** für Hauptgitterlinien der Kategorienachse.  
   2. Das **Linienformat** für Neben­gitterlinien der Kategorienachse.  
   3. Die **Texteigenschaften** für Kategorienachsen‑Beschriftungen.  
   4. Den **Titel** für die Kategorienachse.  
   5. Die **Positionierung der Beschriftungen** für die Kategorienachse.  
   6. Den **Drehwinkel** für Kategorienachsen‑Beschriftungen.  
6. Greifen Sie auf die Diagramm‑Legende zu und setzen Sie deren **Texteigenschaften**.  
7. Zeigen Sie die Diagramm‑Legende ohne Überlappung des Diagramms an.  
8. Greifen Sie auf die **sekundäre Werteachse** des Diagramms zu und setzen Sie Folgendes:  
   1. Aktivieren Sie die sekundäre **Werteachse**.  
   2. Das **Linienformat** für die sekundäre Werteachse.  
   3. Das **Zahlenformat** für die sekundäre Werteachse.  
   4. **Min‑, Max‑, Haupt‑ und Nebeneinheiten** für die sekundäre Werteachse.  
9. Plotten Sie die erste Diagrammserie auf der sekundären Werteachse.  
10. Setzen Sie die Füllfarbe der Rückwand des Diagramms.  
11. Setzen Sie die Füllfarbe des Plot‑Bereichs des Diagramms.  
12. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziiere die Presentation‑Klasse.
with slides.Presentation() as presentation:

    # Greife auf die erste Folie zu.
    slide = presentation.slides[0]

    # Füge ein Beispiel‑Diagramm hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Setze den Diagrammtitel.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Setze das Hauptgitterlinien‑Format für die Werteachse.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Setze das Neben­gitterlinien‑Format für die Werteachse.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Setze das Zahlenformat der Werteachse.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Setze maximale, minimale, Haupt‑ und Nebeneinheit der Werteachse.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Setze die Texteigenschaften der Werteachse.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Setze den Titel der Werteachse.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Setze das Hauptgitterlinien‑Format für die Kategorienachse.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Setze das Neben­gitterlinien‑Format für die Kategorienachse.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Setze die Texteigenschaften der Kategorienachse.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Setze den Titel der Kategorienachse.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Setze die Position der Beschriftungen der Kategorienachse.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Setze den Drehwinkel der Beschriftungen der Kategorienachse.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Setze die Texteigenschaften der Legende.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Zeige die Diagramm‑Legende überlappend zum Diagramm an.
    chart.legend.overlay = True
                
    # Setze die Farbe der Rückwand des Diagramms.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Setze die Farbe des Plot‑Bereichs.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Speichere die Präsentation.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Diagramm‑Schriftarteigenschaften setzen**

Aspose.Slides für Python unterstützt das Festlegen von schriftbezogenen Eigenschaften für Diagramme. Befolgen Sie die nachfolgenden Schritte, um Diagramm‑Schriftarteigenschaften zu konfigurieren:

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt.  
2. Fügen Sie ein Diagramm zur Folie hinzu.  
3. Setzen Sie die Schriftgröße.  
4. Speichern Sie die modifizierte Präsentation.

Ein Beispielcode ist unten angegeben.

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

Aspose.Slides für Python bietet eine einfache API zum Verwalten von Diagrammdaten‑Formaten:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich eine Referenz zur Folie nach ihrem Index.  
3. Fügen Sie ein Diagramm mit Standarddaten des gewünschten Typs hinzu.  
4. Wählen Sie ein vordefiniertes Zahlenformat aus den verfügbaren Vorgaben.  
5. Durchlaufen Sie die Diagrammdatenzellen jeder Serie und setzen Sie das Zahlenformat.  
6. Speichern Sie die Präsentation.  
7. Definieren Sie ein benutzerdefiniertes Zahlenformat.  
8. Durchlaufen Sie erneut die Diagrammdatenzellen und setzen Sie ein alternatives Zahlenformat.  
9. Speichern Sie die Präsentation.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instanziiere die Presentation‑Klasse.
with slides.Presentation() as presentation:
    # Greife auf die erste Folie zu.
    slide = presentation.slides[0]

    # Füge ein Standard‑Clustered‑Column‑Diagramm hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Setze das vordefinierte Zahlenformat.
    # Durchlaufe jede Diagrammserie.
    for series in chart.chart_data.series:
        # Durchlaufe jeden Datenpunkt der Serie.
        for cell in series.data_points:
            # Setze das Zahlenformat.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Speichere die Präsentation.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Die verfügbaren vordefinierten Zahlenformate und ihre zugehörigen Indizes sind unten aufgeführt.

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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Abgerundete Rahmen für den Diagrammbereich festlegen**

Aspose.Slides für Python unterstützt die Konfiguration des Diagrammbereichs über die Eigenschaft `Chart.has_rounded_corners`.

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt.  
2. Fügen Sie ein Diagramm zur Folie hinzu.  
3. Setzen Sie den Füllungstyp und die Füllfarbe des Diagramms.  
4. Setzen Sie die Eigenschaft für abgerundete Ecken auf `True`.  
5. Speichern Sie die modifizierte Präsentation.

Ein Beispiel ist unten angegeben.

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

**Kann ich halbtransparente Füllungen für Spalten/Bereiche setzen, während der Rand undurchsichtig bleibt?**

Ja. Die Transparenz der Füllung und die Kontur werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Gitternetzes und der Daten in dichten Visualisierungen zu verbessern.

**Wie kann ich mit überlappenden Datenbeschriftungen umgehen?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungselemente (z. B. Kategorien), passen Sie den Beschriftungs‑Offset/die Position an, zeigen Sie Beschriftungen nur für ausgewählte Punkte an oder wechseln Sie zum Format „Wert + Legende“.

**Kann ich Farbverläufe oder Musterfüllungen auf Serien anwenden?**

Ja. Sowohl einfarbige als auch Verlauf‑/Muster‑Füllungen stehen in der Regel zur Verfügung. In der Praxis sollten Verläufe sparsam eingesetzt und Kombinationen vermieden werden, die den Kontrast zu Gittern und Text reduzieren.