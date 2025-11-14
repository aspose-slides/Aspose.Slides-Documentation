---
title: Diagrammformatierung
type: docs
weight: 60
url: /de/python-net/chart-formatting/
keywords: "Diagrammobjekte, Diagrammeigenschaften, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Formatieren Sie Diagrammobjekte in PowerPoint-Präsentationen in Python"
---

## **Diagrammobjekte formatieren**
Aspose.Slides für Python über .NET ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. In diesem Artikel wird erklärt, wie man verschiedene Diagrammobjekte einschließlich der Kategorie- und Werteachsen formatiert.

Aspose.Slides für Python über .NET bietet eine einfache API zur Verwaltung verschiedener Diagrammobjekte und deren Formatierung mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der **Presentation**-Klasse.
1. Erhalten Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten und jedem gewünschten Typ hinzu (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).
1. Greifen Sie auf die Werteachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Einstellung des **Linienformats** für die Hauptgitternetzlinien der Werteachse
   1. Einstellung des **Linienformats** für die Nebengitternetzlinien der Werteachse
   1. Einstellung des **Zahlenformats** für die Werteachse
   1. Einstellung der **Min-, Max-, Haupt- und Nebeneinheiten** für die Werteachse
   1. Einstellung der **Textattribute** für die Werteachsendaten
   1. Einstellung des **Titels** für die Werteachse
   1. Einstellung des **Linienformats** für die Werteachse
1. Greifen Sie auf die Kategoriesachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Einstellung des **Linienformats** für die Hauptgitternetzlinien der Kategoriesachse
   1. Einstellung des **Linienformats** für die Nebengitternetzlinien der Kategoriesachse
   1. Einstellung der **Textattribute** für die Kategoriesachdaten
   1. Einstellung des **Titels** für die Kategoriesachse
   1. Einstellung der **Etikettensetzung** für die Kategoriesachse
   1. Einstellung des **Drehwinkels** für die Etiketten der Kategoriesachse
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Textattribute** für sie
1. Stellen Sie die Anzeige der Diagrammlegenden ohne Überlappungen mit dem Diagramm ein
1. Greifen Sie auf die **Sekundäre Werteachse** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren Sie die sekundäre **Werteachse**
   1. Einstellung des **Linienformats** für die sekundäre Werteachse
   1. Einstellung des **Zahlenformats** für die sekundäre Werteachse
   1. Einstellung der **Min-, Max-, Haupt- und Nebeneinheiten** für die sekundäre Werteachse
1. Plottieren Sie nun die erste Diagrammreihe auf der sekundären Werteachse
1. Stellen Sie die Füllfarbe der hinteren Wand des Diagramms ein
1. Stellen Sie die Füllfarbe des Diagrammbereichs ein
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren der Präsentation
with slides.Presentation() as pres:

    # Zugriff auf die erste Folie
    slide = pres.slides[0]

    # Hinzufügen des Beispieldiagramms
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Einstellung des Diagrammtitels
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chartTitle = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chartTitle.text = "Beispiel-Diagramm"
    chartTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chartTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chartTitle.portion_format.font_height = 20
    chartTitle.portion_format.font_bold = 1
    chartTitle.portion_format.font_italic = 1

    # Einstellung des Formats für Hauptgitternetzlinien der Werteachse
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Einstellung des Formats für Nebengitternetzlinien der Werteachse
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Einstellung des Zahlenformats der Werteachse
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Einstellung der maximalen und minimalen Werte des Diagramms
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Einstellung der Textattribute der Werteachse
    txtVal = chart.axes.vertical_axis.text_format.portion_format
    txtVal.font_bold = 1
    txtVal.font_height = 16
    txtVal.font_italic = 1
    txtVal.fill_format.fill_type = slides.FillType.SOLID 
    txtVal.fill_format.solid_fill_color.color = draw.Color.dark_green
    txtVal.latin_font = slides.FontData("Times New Roman")

    # Einstellung des Titels der Werteachse
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    valtitle = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    valtitle.text = "Primäre Achse"
    valtitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    valtitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    valtitle.portion_format.font_height = 20
    valtitle.portion_format.font_bold = 1
    valtitle.portion_format.font_italic = 1

    # Einstellung des Formats für Hauptgitternetzlinien der Kategoriesachse
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Einstellung des Formats für Nebengitternetzlinien der Kategoriesachse
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Einstellung der Textattribute der Kategoriesachse
    txtCat = chart.axes.horizontal_axis.text_format.portion_format
    txtCat.font_bold = 1
    txtCat.font_height = 16
    txtCat.font_italic = 1
    txtCat.fill_format.fill_type = slides.FillType.SOLID 
    txtCat.fill_format.solid_fill_color.color = draw.Color.blue
    txtCat.latin_font = slides.FontData("Arial")

    # Einstellung des Titels der Kategoriesachse
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    catTitle = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    catTitle.text = "Beispiel-Kategorie"
    catTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    catTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    catTitle.portion_format.font_height = 20
    catTitle.portion_format.font_bold = 1
    catTitle.portion_format.font_italic = 1

    # Einstellung der Positionierung der Kategoriesachsenbeschriftungen
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Einstellung des Drehwinkels der Kategoriesachsenbeschriftungen
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Einstellung der Textattribute der Legenden
    txtleg = chart.legend.text_format.portion_format
    txtleg.font_bold = 1
    txtleg.font_height = 16
    txtleg.font_italic = 1
    txtleg.fill_format.fill_type = slides.FillType.SOLID 
    txtleg.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Diagrammlegenden ohne Überlappung mit dem Diagramm anzeigen

    chart.legend.overlay = True
                
    # Einstellung der Füllfarbe der hinteren Wand des Diagramms
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red
    # Einstellung der Füllfarbe des Plotsbereichs
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Präsentation speichern
    pres.save("FormattedChart_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Schriftart-Eigenschaften für Diagramm einstellen**
Aspose.Slides für Python über .NET unterstützt die Einstellung der schriftenbezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den folgenden Schritten, um die Schriftart-Eigenschaften für das Diagramm festzulegen.

- Instanziieren Sie ein Presentation-Objekt.
- Fügen Sie ein Diagramm auf der Folie hinzu.
- Stellen Sie die Schriftart-Höhe ein.
- Speichern Sie die modifizierte Präsentation.

Ein Beispiel wird unten gegeben.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    pres.save("FontPropertiesForChart.pptx", slides.export.SaveFormat.PPTX)
```




## **Zahlenformat einstellen**
Aspose.Slides für Python über .NET bietet eine einfache API zur Verwaltung des Diagrammdatenformats:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Erhalten Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten und jedem gewünschten Typ hinzu (dieses Beispiel verwendet **ChartType.ClusteredColumn**).
1. Stellen Sie das vordefinierte Zahlenformat aus den möglichen vordefinierten Werten ein.
1. Durchlaufen Sie jede Datenzelle in jeder Diagrammreihe und setzen Sie das Zahlenformat der Diagrammdaten.
1. Speichern Sie die Präsentation.
1. Stellen Sie das benutzerdefinierte Zahlenformat ein.
1. Durchlaufen Sie jede Datenzelle in jeder Diagrammreihe und setzen Sie ein anderes Zahlenformat für die Diagrammdaten.
1. Speichern Sie die Präsentation.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instanziieren der Präsentation
with slides.Presentation() as pres:
    # Zugriff auf die erste Präsentationsfolie
    slide = pres.slides[0]

    # Hinzufügen eines standardmäßigen gruppierten Säulendiagramms
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Zugriff auf die Diagrammreihe-Sammlung
    series = chart.chart_data.series

    # Einstellung des vordefinierten Zahlenformats
    # Durchlaufen Sie jede Diagrammreihe
    for ser in series:
        # Durchlaufen Sie jede Datenzelle in der Reihe
        for cell in ser.data_points:
            # Einstellung des Zahlenformats
            cell.value.as_cell.preset_number_format = 10 #0.00%

    # Speichern der Präsentation
    pres.save("PresetNumberFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

Die möglichen vordefinierten Zahlenformatwerte sowie deren vordefinierte Indizes, die verwendet werden können, sind unten angegeben:

|**0**|Allgemein|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Rot$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Rot$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/jj|
|**15**|d-mmm-jj|
|**16**|d-mmm|
|**17**|mmm-jj|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/jj h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Rot-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Rot-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Ecken des Diagrammbereichs abrunden**
Aspose.Slides für Python über .NET bietet Unterstützung für die Einstellung des Diagrammbereichs. **IChart.HasRoundedCorners** und **Chart.HasRoundedCorners**-Eigenschaften wurden in Aspose.Slides hinzugefügt. 

1. Instanziieren Sie ein `Presentation`-Objekt.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Stellen Sie den Fülltyp und die Füllfarbe des Diagramms ein.
1. Stellen Sie die Eigenschaft für abgerundete Ecken auf True ein.
1. Speichern Sie die modifizierte Präsentation.

Ein Beispiel wird unten gegeben. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("out.pptx", slides.export.SaveFormat.PPTX)
```