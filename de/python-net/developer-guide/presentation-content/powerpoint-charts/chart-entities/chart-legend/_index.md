---
title: Diagrammlegende
type: docs
url: /python-net/chart-legend/
keywords: "Diagrammlegende, Schriftgröße der Legende, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Positionierung und Schriftgröße für die Diagrammlegende in PowerPoint-Präsentationen in Python festlegen"
---

## **Positionierung der Legende**
Um die Eigenschaften der Legende festzulegen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
- Holen Sie sich die Referenz zur Folie.
- Fügen Sie ein Diagramm auf der Folie hinzu.
- Setzen Sie die Eigenschaften der Legende.
- Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir die Position und Größe für die Diagrammlegende festgelegt.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Erstellen Sie eine Instanz der Präsentationsklasse
with slides.Presentation() as presentation:

    # Holen Sie sich die Referenz zur Folie
    slide = presentation.slides[0]

    # Fügen Sie ein gruppiertes Säulendiagramm auf der Folie hinzu
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Legende Eigenschaften festlegen
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Präsentation auf die Festplatte speichern
    presentation.save("Legend_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Schriftgröße der Legende festlegen**
Aspose.Slides für Python über .NET ermöglicht Entwicklern, die Schriftgröße der Legende festzulegen. Bitte befolgen Sie die folgenden Schritte:

- Instanziieren Sie die `Presentation` Klasse.
- Erstellen Sie das Standarddiagramm.
- Setzen Sie die Schriftgröße.
- Setzen Sie den minimalen Achsenwert.
- Setzen Sie den maximalen Achsenwert.
- Schreiben Sie die Präsentation auf die Festplatte.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.legend.text_format.portion_format.font_height = 20
	chart.axes.vertical_axis.is_automatic_min_value = False
	chart.axes.vertical_axis.min_value = -5
	chart.axes.vertical_axis.is_automatic_max_value = False
	chart.axes.vertical_axis.max_value = 10

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Schriftgröße der einzelnen Legende festlegen**
Aspose.Slides für Python über .NET ermöglicht Entwicklern, die Schriftgröße der einzelnen Legendeeinträge festzulegen. Bitte befolgen Sie die folgenden Schritte:

- Instanziieren Sie die `Presentation` Klasse.
- Erstellen Sie das Standarddiagramm.
- Greifen Sie auf den Legendeeintrag zu.
- Setzen Sie die Schriftgröße.
- Setzen Sie den minimalen Achsenwert.
- Setzen Sie den maximalen Achsenwert.
- Schreiben Sie die Präsentation auf die Festplatte.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw
 
 
with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	tf = chart.legend.entries[1].text_format

	tf.portion_format.font_bold = 1
	tf.portion_format.font_height = 20
	tf.portion_format.font_italic = 1
	tf.portion_format.fill_format.fill_type = slides.FillType.SOLID 
	tf.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```