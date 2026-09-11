---
title: Linienformen zu Präsentationen in Python via Java hinzufügen
linktitle: Linie
type: docs
weight: 50
url: /de/python-java/line/
keywords:
- Linie
- Linie erstellen
- Linie hinzufügen
- einfache Linie
- Linie konfigurieren
- Linie anpassen
- Strichstil
- Pfeilspitze
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie die Linienformatierung in PowerPoint-Präsentationen mit Aspose.Slides für Python via Java manipulieren. Entdecken Sie Eigenschaften, Methoden und Beispiele."
---
## **Überblick**

Aspose.Slides ermöglicht das programmgesteuerte Hinzufügen von Linienformen zu PowerPoint‑Folien. Dieser Artikel zeigt, wie man eine einfache Linie erstellt und wie man eine Linie anpasst, sodass sie als Pfeil dargestellt wird.

Sie lernen, wie man eine Linienform zu einer Folie hinzufügt, ihr Aussehen anpasst und die aktualisierte Präsentation speichert. Die Beispiele konzentrieren sich auf praktische Formatierungseinstellungen für Linien wie Stil, Breite, Strichmuster, Pfeilspitzenoptionen und Füllfarbe.

## **Einfache Linie erstellen**

Um einer ausgewählten Folie der Präsentation eine einfache Linie hinzuzufügen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
- Holen Sie eine Referenz auf eine Folie anhand ihres Index.
- Fügen Sie eine Linienform hinzu, indem Sie die Methode [addAutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addAutoShape) des Objekts [ShapeCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/) aufrufen.
- Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Das folgende Beispiel fügt der ersten Folie der Präsentation eine Linie hinzu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instanziieren Sie die Presentation-Klasse, die die PPTX-Datei repräsentiert.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Eine Linienform hinzufügen.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Die PPTX-Datei auf die Festplatte schreiben.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Pfeilförmige Linie erstellen**

Aspose.Slides for Python via Java ermöglicht es Entwicklern zudem, Linieneigenschaften zu konfigurieren, damit eine Linie ansprechender wirkt. Um eine Linie wie einen Pfeil aussehen zu lassen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
- Holen Sie eine Referenz auf eine Folie anhand ihres Index.
- Fügen Sie eine Linienform hinzu, indem Sie die Methode [addAutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addAutoShape) des Objekts [ShapeCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/) aufrufen.
- Setzen Sie den [Linienstil](https://reference.aspose.com/slides/de/python-java/aspose.slides/linestyle/) auf einen der von Aspose.Slides for Python via Java angebotenen Stile.
- Setzen Sie die Breite der Linie.
- Setzen Sie das [Strichmuster](https://reference.aspose.com/slides/de/python-java/aspose.slides/linedashstyle/) auf einen der von Aspose.Slides for Python via Java angebotenen Stile.
- Setzen Sie den [Pfeilspitzenstil](https://reference.aspose.com/slides/de/python-java/aspose.slides/linearrowheadstyle/) und die [Länge](https://reference.aspose.com/slides/de/python-java/aspose.slides/linearrowheadlength/) am Anfang der Linie.
- Setzen Sie den [Pfeilspitzenstil](https://reference.aspose.com/slides/de/python-java/aspose.slides/linearrowheadstyle/) und die [Länge](https://reference.aspose.com/slides/de/python-java/aspose.slides/linearrowheadlength/) am Ende der Linie.
- Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Instanziieren Sie die Presentation-Klasse, die die PPTX-Datei repräsentiert.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Eine Linienform hinzufügen.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Formatierung auf die Linie anwenden.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Die PPTX-Datei auf die Festplatte schreiben.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich eine gewöhnliche Linie in einen Connector umwandeln, damit sie sich an Formen „einrastet“?**

Nein. Eine gewöhnliche Linie (ein [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/)) wird nicht automatisch zu einem Connector. Um sie an Formen einrasten zu lassen, verwenden Sie den dedizierten Typ [Connector](https://reference.aspose.com/slides/de/python-java/aspose.slides/connector/) und die [corresponding APIs](/slides/de/python-java/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Theme geerbt werden und es schwierig ist, die endgültigen Werte zu ermitteln?**

Lesen Sie die [effektiven Eigenschaften](/slides/de/python-java/shape-effective-properties/) der Linie und ihrer Füllung — diese berücksichtigen bereits Vererbung und Theme‑Stile.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Größenänderung) sperren?**

Ja. Formen stellen [Sperrobjekte](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/#getAutoShapeLock) bereit, mit denen Sie [Bearbeitungsoperationen](/slides/de/python-java/applying-protection-to-presentation/) untersagen können.