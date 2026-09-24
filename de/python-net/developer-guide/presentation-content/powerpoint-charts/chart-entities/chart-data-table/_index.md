---
title: Diagramm-Datentabellen in Präsentationen in Python anpassen
linktitle: Datentabelle
type: docs
url: /de/python-net/chart-data-table/
keywords:
- Diagrammdaten
- Datentabelle
- Schrifteigenschaften
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Schriftarten, Rahmen und Legendenzeichen der Diagramm-Datentabelle in PowerPoint-Präsentationen mit Aspose.Slides for Python via .NET anpassen."
---
## **Übersicht**

Aspose.Slides for Python via .NET ermöglicht das Anzeigen einer Datentabelle eines Diagramms und das Anpassen von Textformatierung, Rahmen und Legendenzeichen. Dieser Artikel erklärt, wie die Tabelle aktiviert, ihr Text formatiert, jeder Rahmentyp gesteuert und Legendenzeichen ein‑ oder ausgeblendet werden. Die Beispiele speichern die konfigurierten Diagramme in PPTX‑Dateien.

## **Schrifteigenschaften festlegen**

Um die Datentabelle eines Diagramms anzuzeigen, setzen Sie [has_data_table](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/has_data_table/) auf `True`. Verwenden Sie [chart_data_table](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/chart_data_table/), um auf die Tabelle zuzugreifen und ihre Textformatierung zu konfigurieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/).
1. Fügen Sie ein gruppiertes Säulendiagramm zur ersten Folie hinzu.
1. Aktivieren Sie die Datentabelle des Diagramms.
1. Aktivieren Sie fetten Text mit [font_bold](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/font_bold/) und setzen Sie [font_height](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/font_height/) auf `20` für 20‑Punkt‑Text.
1. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel erfordert `test.pptx` im Arbeitsverzeichnis mit mindestens einer Folie. Es fügt ein Diagramm mit Standarddaten an Position (50, 50) ein, mit einer Breite von 600 Punkten und einer Höhe von 400 Punkten. Die gespeicherte `output.pptx` enthält das Diagramm mit aktivierter Datentabelle und den angegebenen Schriftarteinstellungen.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Datentabelle‑Rahmen anpassen**

Aktivieren Sie die Tabelle mit [Chart.has_data_table](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/has_data_table/) und greifen Sie über [Chart.chart_data_table](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/chart_data_table/) darauf zu. Sie können drei Arten von Rahmen unabhängig steuern:

- [has_border_horizontal](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datatable/has_border_horizontal/) steuert die horizontalen Zellenrahmen.
- [has_border_vertical](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datatable/has_border_vertical/) steuert die vertikalen Zellenrahmen.
- [has_border_outline](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datatable/has_border_outline/) steuert den äußeren Rahmen der Tabelle.

Setzen Sie jede Eigenschaft auf `True`, um deren Rahmen anzuzeigen, oder auf `False`, um sie zu verbergen. Das folgende Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten, zeigt horizontale Rahmen und den äußeren Rahmen an und blendet vertikale Rahmen aus. Es benötigt keine Eingabedatei. Position und Größe des Diagramms werden in Punkten angegeben.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

Der Vergleich unten verwendet dieselben Diagrammdaten und dieselbe Legendenzeicheneinstellung in allen vier Fällen. Beginnend mit aktivierten allen Rahmen, deaktiviert jede weitere Variante genau eine Rahmeneigenschaft. Die Variante unten links entspricht den Rahmeneinstellungen im Beispiel.

![Diagramm‑Datentabellen mit allen Rahmen aktiviert, ohne horizontale Rahmen, ohne vertikale Rahmen und ohne äußeren Rahmen](data-table-borders.png)

## **Legendenzeichen anzeigen oder ausblenden**

Legendenzeichen sind kleine farbige Markierungen neben den Seriennamen in der Datentabelle. Sie helfen den Lesern, jede Tabellenzeile einer Diagrammserie zuzuordnen. Setzen Sie [show_legend_key](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datatable/show_legend_key/) auf `True`, um diese Markierungen anzuzeigen, oder auf `False`, um sie zu verbergen.

Die separate Legende des Diagramms wird über [Chart.has_legend](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/has_legend/) gesteuert. Diese Einstellungen sind unabhängig: Das Ausblenden der separaten Legende verbirgt nicht die Schlüssel in der Datentabelle, und das Ausblenden der Tabellenschlüssel verbirgt nicht die separate Legende.

Das folgende Beispiel erstellt ein Diagramm mit Standarddaten, aktiviert dessen Datentabelle und zeigt Legendenzeichen darin an, während die separate Legende ausgeblendet wird. Alle Tabellengrenzen werden explizit aktiviert. Es wird keine Eingabepräsentation benötigt. Um nur die Tabellenschlüssel zu verbergen, ändern Sie `data_table.show_legend_key` auf `False`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

Der Vergleich unten zeigt dieselbe Tabelle mit aktivierten und deaktivierten Legendenzeichen. Alle Rahmen bleiben aktiviert, und die separate Diagrammlegende ist in beiden Fällen ausgeblendet.

![Diagramm‑Datentabellen mit Legendenzeichen links angezeigt und rechts ausgeblendet](data-table-legend-keys.png)

## **FAQ**

**Kann ich Legendenzeichen in der Datentabelle eines Diagramms anzeigen?**

Ja. Setzen Sie [show_legend_key](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datatable/show_legend_key/) auf `True`, um Legendenzeichen anzuzeigen, oder auf `False`, um sie zu verbergen.

**Wird die Datentabelle beim Export der Präsentation nach PDF, HTML oder Bildern beibehalten?**

Ja. Aspose.Slides rendert das Diagramm und seine angezeigte Datentabelle als Teil der Folie beim Export nach [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/) oder [Bilder](/slides/de/python-net/convert-powerpoint-to-png/).

**Kann ich mit Datentabellen in Diagrammen arbeiten, die aus einer Vorlage geladen wurden?**

Ja. Für ein Diagramm, das aus einer vorhandenen Präsentation oder Vorlage geladen wurde, verwenden Sie [has_data_table](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/has_data_table/), um zu prüfen oder zu ändern, ob seine Datentabelle angezeigt wird.

**Wie kann ich Diagramme finden, bei denen die Datentabelle aktiviert ist?**

Durchlaufen Sie die Formen auf jeder Folie, ermitteln Sie die Diagramme und prüfen Sie deren [has_data_table](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/has_data_table/)-Eigenschaft. Ein Wert von `True` zeigt an, dass die Datentabelle aktiviert ist.