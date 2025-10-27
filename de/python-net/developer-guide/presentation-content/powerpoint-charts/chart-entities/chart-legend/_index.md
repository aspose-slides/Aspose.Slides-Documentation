---
title: Customize Chart Legends in Presentations with Python
linktitle: Chart Legend
type: docs
url: /de/python-net/chart-legend/
keywords:
- chart legend
- legend position
- font size
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Customize chart legends with Aspose.Slides for Python via .NET to optimize PowerPoint and OpenDocument presentations with tailored legend formatting."
---

## **Übersicht**

Aspose.Slides für Python bietet vollständige Kontrolle über Diagrammlegenden, sodass Sie Datenbeschriftungen klar und präsentationsfertig gestalten können. Sie können die Legende ein- oder ausblenden, ihre Position auf der Folie wählen und das Layout anpassen, um Überlappungen mit dem Plot‑Bereich zu vermeiden. Die API ermöglicht das Stylen von Text und Markern, das Feinabstimmen von Abständen und Hintergrund sowie das Formatieren von Rahmen und Füllungen, um Ihrem Design zu entsprechen. Entwickler können zudem einzelne Legendeneinträge ansprechen, um sie umzubenennen oder zu filtern, sodass nur die relevantesten Serien angezeigt werden. Mit diesen Möglichkeiten bleiben Ihre Diagramme lesbar, konsistent und im Einklang mit den Design‑Standards Ihrer Präsentation.

## **Legendenpositionierung**

Mit Aspose.Slides können Sie schnell steuern, wo die Diagrammlegende angezeigt wird und wie sie in Ihr Folienlayout passt. Erfahren Sie, wie Sie die Legende präzise platzieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
1. Holen Sie sich eine Referenz zur Folie.
1. Fügen Sie der Folie ein Diagramm hinzu.
1. Setzen Sie die Legenden‑Eigenschaften.
1. Speichern Sie die Präsentation als PPTX‑Datei.

Im folgenden Beispiel setzen wir die Position und Größe der Diagrammlegende:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Get a reference to the slide.
    slide = presentation.slides[0]

    # Add a clustered column chart to the slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Set the legend properties.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Save the presentation to disk.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Legenden‑Schriftgröße festlegen**

Die Legende eines Diagramms sollte genauso gut lesbar sein wie die dargestellten Daten. Dieser Abschnitt zeigt, wie Sie die Schriftgröße der Legende anpassen, um die Typografie Ihrer Präsentation zu treffen und die Barrierefreiheit zu verbessern.

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
1. Erstellen Sie ein Diagramm.
1. Setzen Sie die Schriftgröße.
1. Speichern Sie die Präsentation auf dem Datenträger.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Schriftgröße für einen Legendeeintrag festlegen**

Aspose.Slides ermöglicht das Feintuning der Darstellung von Diagrammlegenden, indem einzelne Einträge formatiert werden. Das nachfolgende Beispiel zeigt, wie Sie einen bestimmten Legendeneintrag ansprechen und dessen Eigenschaften ändern, ohne die übrige Legende zu beeinflussen.

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
1. Erstellen Sie ein Diagramm.
1. Greifen Sie auf einen Legendeneintrag zu.
1. Setzen Sie die Eintrags‑Eigenschaften.
1. Speichern Sie die Präsentation auf dem Datenträger.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich die Legende aktivieren, sodass das Diagramm automatisch Platz dafür reserviert, anstatt sie zu überlagern?**

Ja. Verwenden Sie den Nicht‑Overlay‑Modus ([overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`); in diesem Fall verkleinert sich der Plot‑Bereich, um die Legende aufzunehmen.

**Kann ich mehrzeilige Legendeneinträge erstellen?**

Ja. Lange Beschriftungen umbrechen automatisch, wenn nicht genügend Platz vorhanden ist; erzwungene Zeilenumbrüche werden über Newline‑Zeichen im Seriennamen unterstützt.

**Wie bringe ich die Legende dazu, dem Farbschema des Präsentationsthemas zu folgen?**

Setzen Sie keine expliziten Farben/Füllungen/Schriften für die Legende oder ihren Text. Sie erben dann das Theme und passen sich automatisch an, wenn das Design geändert wird.