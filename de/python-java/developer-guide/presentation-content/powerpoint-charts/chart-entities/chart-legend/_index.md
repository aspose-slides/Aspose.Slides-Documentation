---
title: Diagrammlegenden in Präsentationen mit Python anpassen
linktitle: Diagrammlegende
type: docs
url: /de/python-java/chart-legend/
keywords:
- Diagrammlegende
- Legendenposition
- Schriftgröße
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Passen Sie Diagrammlegenden mit Aspose.Slides für Python via Java an, um PowerPoint-Präsentationen mit individuell formatierter Legende zu optimieren."
---
## **Übersicht**

Aspose.Slides bietet Optionen zum Anpassen von Diagrammlegenden in PowerPoint‑Präsentationen. Dieser Artikel zeigt, wie man eine Legende positioniert und dimensioniert, die Schriftgröße für die gesamte Legende festlegt und die Formatierung eines einzelnen Legendeintrags anwendet.

Er behandelt außerdem mehrere verwandte Verhaltensweisen im FAQ, einschließlich der Verwendung des Nicht‑Overlay‑Modus, sodass der Plot‑Bereich Platz für die Legende schafft, das Umbrechen langer Legendenbeschriftungen oder die Verwendung von Zeilenumbrüchen zu ermöglichen und die Legendenformatierung vom Präsentationsthema erben zu lassen, wenn keine expliziten Text‑ und Füll‑Einstellungen angewendet werden.

## **Positionierung der Legende**

Um die Legenden‑Eigenschaften festzulegen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.  
1. Holen Sie eine Referenz zur Folie.  
1. Fügen Sie der Folie ein Diagramm hinzu.  
1. Setzen Sie die Legenden‑Eigenschaften.  
1. Speichern Sie die Präsentation als PPTX‑Datei.

Das folgende Beispiel legt die Position und Größe einer Diagrammlegende fest.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Erstelle eine leere Präsentation.
presentation = Presentation()
try:
    # Hole eine Referenz zur Folie.
    slide = presentation.getSlides().get_Item(0)

    # Füge der Folie ein gruppiertes Säulendiagramm hinzu.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Setze die Legenden-Eigenschaften.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Speichere die Präsentation auf dem Datenträger.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Schriftgröße einer Legende festlegen**

Aspose.Slides für Python via Java ermöglicht das Festlegen der Schriftgröße einer Legende. Gehen Sie wie folgt vor:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.  
1. Erstellen Sie das Standarddiagramm.  
1. Setzen Sie die Schriftgröße.  
1. Setzen Sie den minimalen Achsenwert.  
1. Setzen Sie den maximalen Achsenwert.  
1. Speichern Sie die Präsentation auf dem Datenträger.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Erstelle eine leere Präsentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Schriftgröße eines einzelnen Legendeintrags festlegen**

Aspose.Slides für Python via Java ermöglicht das Festlegen der Schriftgröße einzelner Legendeinträge. Gehen Sie wie folgt vor:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.  
1. Erstellen Sie das Standarddiagramm.  
1. Greifen Sie auf einen Legendeintrag zu.  
1. Setzen Sie die Schriftgröße.  
1. Speichern Sie die Präsentation auf dem Datenträger.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Erstelle eine leere Präsentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich die Legende aktivieren, damit das Diagramm automatisch Platz dafür einräumt, anstatt sie zu überlagern?**  
Ja. Verwenden Sie [setOverlay](https://reference.aspose.com/slides/de/python-java/aspose.slides/legend/#setOverlay) mit `False`, um den Nicht‑Overlay‑Modus zu aktivieren; in diesem Fall wird der Plot‑Bereich verkleinert, um die Legende aufzunehmen.

**Kann ich mehrzeilige Legendenbeschriftungen erstellen?**  
Ja. Lange Beschriftungen werden automatisch umgebrochen, wenn nicht genügend Platz vorhanden ist; erzwungene Zeilenumbrüche werden über Newline‑Zeichen im Seriennamen unterstützt.

**Wie bringe ich die Legende dazu, dem Farbschema des Präsentationsthemas zu folgen?**  
Setzen Sie keine expliziten Farben, Füllungen oder Schriften für die Legende oder deren Text. Sie erben dann vom Thema und werden bei einer Designänderung korrekt aktualisiert.