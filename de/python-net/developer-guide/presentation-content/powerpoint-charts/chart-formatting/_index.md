---
title: Diagramme in Präsentationen mit Python formatieren
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/python-net/chart-formatting/
keywords:
- Diagramm formatieren
- Diagrammformatierung
- Diagrammelement
- Diagrammeigenschaften
- Diagrammeinstellungen
- Diagrammoptionen
- Schrifteigenschaften
- abgerundete Rahmen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides für Python via .NET formatieren und Ihre PowerPoint‑Präsentation mit benutzerdefinierten Achsen, Schriften, Zahlenformaten und abgerundeten Diagrammrahmen aufwerten."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Diagramme in PowerPoint‑Präsentationen mit Aspose.Slides formatiert. Er zeigt, wie wichtige Diagrammelemente wie Achsen, Gitternetzlinien, Titel, Legenden, der Zeichenbereich und Wandfüllungen angepasst werden können, um das Erscheinungsbild und die Lesbarkeit der Diagrammdaten zu verbessern.

Er demonstriert zudem, wie Schriftarteigenschaften für Diagrammtext festgelegt, vordefinierte Zahlenformate auf Diagrammdaten angewendet und runde Ecken für den Diagrammbereich aktiviert werden. Zusammen zeigen diese Beispiele, wie sowohl der visuelle Stil als auch die Datenpräsentation von Diagrammen in einer Präsentation gesteuert werden können.

Für separate Füllungen und Konturen bei steigenden und fallenden Intervallen siehe das [Beispiel für Aktienchart](/slides/de/python-net/create-chart/#create-stock-charts).

## **Diagrammelemente formatieren**

Verwenden Sie [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), um Diagrammtitel, Achsen, Gitternetzlinien, Legenden und den Zeichenbereich zu formatieren. Dieses Beispiel erstellt ein Liniendiagramm mit Markern und Standarddaten und wendet dann separate Text‑ und Linien‑Stile auf seine Werte‑ und Kategorien‑Achsen an. Schriftgrößen und Linienstärken werden in Punkt angegeben; Kategorien‑Beschriftungen werden um 45 Grad gedreht.

Die Werte‑Achse verwendet [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) unabhängig von den Quellzellen. Ihr Wertebereich reicht von -2 bis 15, mit Hauptintervallen von 2 und Nebenintervallen von 0,5. Das Beispiel kombiniert außerdem Prozentformatierung mit [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) auf Tausend, sodass Sie diese Einstellungen an die Bedeutung und Größe Ihrer Daten anpassen sollten. Die Legende bleibt außerhalb des Zeichenbereichs, weil [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) deaktiviert ist. Hinter‑Wand‑ und Boden‑Füllungen werden über [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) bzw. [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) konfiguriert, diese Flächen sind jedoch nur in 3D‑Diagrammen sichtbar.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Schrifteigenschaften für ein Diagramm festlegen**

Stellen Sie die Standardschriftgröße für Diagrammtext über [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/) ein. Das Beispiel erstellt ein gruppiertes Säulendiagramm mit einer 20‑Punkt‑Schrift und aktiviert Wertbeschriftungen für die erste Serie über [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Textelemente mit eigenen expliziten Schrifteinstellungen können die Diagramm‑Standardwerte überschreiben.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Textfeldformatierung für eine Diagrammlegende wiederverwenden**

Um eine Legende an eine Folien‑Überschrift anzupassen, setzen Sie die Schriftart über [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) im ersten Absatz der Überschrift. Rufen Sie [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) auf dem [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) der Legende auf. Dabei werden die Einstellungen des Textfelds, die Formatierung des ersten Absatzes und die Standard‑Schrifteigenschaften dieses Absatzes kopiert. Auf einzelne Textteile oder spätere Absätze direkt angewendete Formatierungen bleiben nur für die Quelle lokal.

Das Beispiel verwendet eine fette, marineblaue Überschrift in 26‑Punkt‑Calibri als Vorlage. Nach der Gestaltung der Legende wird [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) verwendet, um dieselbe Formatierung auf eine separate Beschriftung anzuwenden.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

In der gespeicherten Präsentation stimmen Legende und Beschriftung in Größe, Stärke und Farbe mit der Überschrift überein. Die Legende zeigt weiterhin die Seriennamen an, und die Beschriftung behält ihren eigenen Text. Hat ein Teil der Beschriftung bereits eine explizite Schriftgröße, so hat diese Vorrang vor dem kopierten Absatz‑Standard.

| Vor dem Kopieren | Nach dem Kopieren |
| --- | --- |
| ![Quartalsverkaufsdiagramm mit normalen schwarzen Legendenbeschriftungen und einer schwarzen Beschriftung](legend-formatting-before.png) | ![Dasselbe Diagramm mit größeren, fetten, marineblauen Legendenbeschriftungen und einer passenden Beschriftung](legend-formatting.png) |

## **Numerisches Format festlegen**

Verwenden Sie [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/), um ein integriertes Zahlenformat auf Diagramm‑Arbeitsblattzellen anzuwenden. Dieses Beispiel erstellt ein gruppiertes Säulendiagramm mit Standard‑, zellbasierten Daten und wendet den Format‑Index 10 (`0.00%`) auf jede Serienwertzelle an. Dadurch wird die Anzeige der Werte im Arbeitsblatt geändert, ohne die zugrunde liegenden Zahlen zu verändern; zum Beispiel wird 0,25 als 25,00 % angezeigt. Achsen‑ und Datenbeschriftungsformate können getrennt konfiguriert werden.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Die folgende Tabelle listet integrierte Zahlenformatindizes mit repräsentativen Excel‑Formaten für das englische (Vereinigte Staaten) Gebietsschema auf. Die genauen Formatzeichenfolgen und deren Darstellung können je nach Anwendung und Gebietsschema variieren, insbesondere bei Währung und Datumsangaben. Einige Excel‑Formate unterscheiden sich zudem von den Vorgaben des OOXML‑Standards, wie in den [Hinweisen zur Implementierung von Zahlenformaten von Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) beschrieben.

| Index | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Abgerundete Ränder des Diagrammbereichs festlegen**

Aktivieren Sie [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/), um die Ecken des Diagrammbereichs abzurunden. Das Beispiel erstellt ein gruppiertes Säulendiagramm und verwendet [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/), um seiner Kontur eine durchgehend graue Farbe und einen einlinigen Stil zu geben, bevor die Präsentation gespeichert wird.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Vorhandene Diagramm‑Annotationen bearbeiten**

Ein Diagramm kann benutzerdefinierte Formen enthalten, z. B. eine Textannotation, die den Status eines Berichts erklärt. Greifen Sie über [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/) auf diese Formen zu. Seine [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)‑Sammlung enthält die dem Diagramm zugehörigen Formen.

Ein gewöhnliches Textfeld, das über einem Diagramm platziert wird, gehört zur Folie, auch wenn es wie ein Teil des Diagramms aussieht. Das Durchlaufen von [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) findet das Diagramm und die normalen Folienformen, enumeriert jedoch nicht die einzelnen Formen innerhalb des Diagramms. Diagrammtitel und Datenbeschriftungen sind separate Diagrammelemente, keine benutzerdefinierten Annotationen in dieser Sammlung.

Laden Sie [chart-annotations.pptx](chart-annotations.pptx) herunter und legen Sie sie im Arbeitsverzeichnis der Anwendung ab. Die erste Folie enthält ein Diagramm mit einer nicht gruppierten Annotation „Preliminary results“, einer dem Diagramm zugehörigen Linie und einem normalen Folientextfeld mit dem Text „Slide overlay“. Das Beispiel findet das erste Diagramm auf dieser Folie und ändert die Annotation zu „Final results“, wenn der Bericht veröffentlicht werden soll. Es prüft, ob die Sammlung leer ist, und bearbeitet nur ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) mit einem [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/), das nicht `None` ist und den erwarteten Text enthält.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

Die Linie und das Folientextfeld bleiben unverändert. Die folgenden Bilder zeigen die Eingabe sowie das gespeicherte, erneut geöffnete Ergebnis:

| Vor dem Bearbeiten | Nach dem Bearbeiten |
| --- | --- |
| ![Diagramm‑Annotation mit dem Text Preliminary results](chart-annotations-before.png) | ![Diagramm‑Annotation mit dem Text Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Das Beispiel untersucht nur die Diagramm‑formen auf oberster Ebene. Befindet sich eine Annotation innerhalb einer [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), prüfen Sie auch die [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)‑Sammlung dieser Gruppe. Wiederholen Sie dies rekursiv für verschachtelte Gruppen und wenden Sie dieselben Textprüfungen auf deren Kindformen an. Eine Gruppe selbst ist ein Container; behandeln Sie sie nicht als Textfeld.
{{% /alert %}}

## **FAQ**

**Kann ich halbtransparente Füllungen für Säulen/Flächen setzen, während die Kontur undurchsichtig bleibt?**

Ja. Fülltransparenz und Kontur werden separat konfiguriert. Das ist nützlich, um die Lesbarkeit des Gitternetzes und der Daten in dichten Visualisierungen zu verbessern.

**Wie kann ich mit Datenbeschriftungen umgehen, wenn sie sich überschneiden?**

Verkleinern Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungskomponenten (z. B. Kategorien), passen Sie die Beschriftungsposition an, zeigen Sie Beschriftungen nur für ausgewählte Punkte an, falls nötig, oder wechseln Sie das Format zu "Wert + Legende".

**Kann ich Farbverlauf‑ oder Musterfüllungen auf Serien anwenden?**

Ja. Serien unterstützen einfarbige, Farbverlauf‑ und Musterfüllungen. Verwenden Sie Farbverläufe jedoch sparsam und vermeiden Sie Kombinationen, die den Kontrast zum Gitter und Text verringern.