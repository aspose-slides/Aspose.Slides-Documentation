---
title: Diagrammlegenden in Präsentationen mit Python anpassen
linktitle: Diagrammlegende
type: docs
url: /de/python-net/chart-legend/
keywords:
- diagrammlegende
- legendenposition
- schriftgröße
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Diagrammlegenden mit Aspose.Slides für Python über .NET anpassen, um PowerPoint- und OpenDocument-Präsentationen mit maßgeschneiderter Legendenformatierung zu optimieren."
---

## **Übersicht**

Aspose.Slides for Python bietet volle Kontrolle über Diagrammlegenden, sodass Sie Datenbeschriftungen klar und präsentationsfertig gestalten können. Sie können die Legende ein- oder ausblenden, ihre Position auf der Folie wählen und das Layout so anpassen, dass es nicht mit dem Plotbereich überlappt. Die API ermöglicht das Stylen von Text und Markern, das feine Einstellen von Abstand und Hintergrund sowie das Formatieren von Rahmen und Füllungen, um Ihrem Design zu entsprechen. Entwickler können zudem einzelne Legendeinträge abrufen, um sie umzubenennen oder zu filtern, sodass nur die relevantesten Serien angezeigt werden. Mit diesen Möglichkeiten bleiben Ihre Diagramme lesbar, konsistent und im Einklang mit den Designstandards Ihrer Präsentation.

## **Legendenpositionierung**

Mit Aspose.Slides können Sie schnell steuern, wo die Diagrammlegende erscheint und wie sie in Ihr Folienlayout passt. Erfahren Sie, wie Sie die Legende präzise platzieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz zur Folie.
3. Fügen Sie ein Diagramm zur Folie hinzu.
4. Setzen Sie die Legenden‑Eigenschaften.
5. Speichern Sie die Präsentation als PPTX‑Datei.

Im folgenden Beispiel setzen wir die Position und Größe der Diagrammlegende:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Erstellen Sie eine Instanz der Presentation-Klasse.
with slides.Presentation() as presentation:

    # Holen Sie sich eine Referenz zur Folie.
    slide = presentation.slides[0]

    # Fügen Sie der Folie ein gruppiertes Säulendiagramm hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Legen Sie die Legenden-Eigenschaften fest.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```


## **Schriftgröße der Legende festlegen**

Die Legende eines Diagramms sollte genauso gut lesbar sein wie die Daten, die sie erklärt. Dieser Abschnitt zeigt, wie Sie die Schriftgröße der Legende anpassen, um die Typografie Ihrer Präsentation zu entsprechen und die Zugänglichkeit zu verbessern.

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Erstellen Sie ein Diagramm.
3. Setzen Sie die Schriftgröße.
4. Speichern Sie die Präsentation auf dem Datenträger.
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

Aspose.Slides ermöglicht es Ihnen, das Aussehen von Diagrammlegenden zu verfeinern, indem Sie einzelne Einträge formatieren. Das folgende Beispiel zeigt, wie Sie einen bestimmten Legendeeintrag ansprechen und dessen Eigenschaften festlegen, ohne den Rest der Legende zu ändern.

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Erstellen Sie ein Diagramm.
3. Greifen Sie auf einen Legendeeintrag zu.
4. Setzen Sie die Eigenschaften des Eintrags.
5. Speichern Sie die Präsentation auf dem Datenträger.
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

Ja. Verwenden Sie den Nicht‑Overlay‑Modus ([overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`); in diesem Fall wird der Plotbereich verkleinert, um die Legende aufzunehmen.

**Kann ich mehrzeilige Legendenbeschriftungen erstellen?**

Ja. Lange Beschriftungen werden automatisch umbrochen, wenn nicht genug Platz vorhanden ist; erzwungene Zeilenumbrüche werden über Zeilenumbruchszeichen im Seriennamen unterstützt.

**Wie bringe ich die Legende dazu, dem Farbschema des Präsentationsthemas zu folgen?**

Setzen Sie keine expliziten Farben/Füllungen/Schriften für die Legende oder deren Text. Sie erben dann vom Thema und werden bei einer Designänderung korrekt aktualisiert.