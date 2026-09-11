---
title: Ellipsen zu Präsentationen in Python via Java hinzufügen
linktitle: Ellipse
type: docs
weight: 30
url: /de/python-java/ellipse/
keywords:
- Ellipse
- Form
- Ellipse hinzufügen
- Ellipse erstellen
- Ellipse zeichnen
- formatierte Ellipse
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Ellipsenformen in Aspose.Slides für Python über Java in PPT- und PPTX-Präsentationen erstellen, formatieren und manipulieren – inklusive Python-Codebeispielen."
---
## **Übersicht**

Dieser Artikel zeigt, wie Sie mit Aspose.Slides Ellipsenformen zu PowerPoint‑Folien hinzufügen. Er behandelt das Erstellen einer einfachen Ellipse, das Erstellen einer formatierten Ellipse und das Speichern der aktualisierten Präsentation als PPTX‑Datei. Außerdem werden verwandte Fragen behandelt, z. B. die Arbeit mit Position und Größe einer Ellipse, das Steuern der Stapelreihenfolge und das Anwenden von Animationseffekten.

## **Ellipse erstellen**

Um einer ausgewählten Folie der Präsentation eine einfache Ellipse hinzuzufügen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
- Holen Sie eine Referenz zu einer Folie über deren Index.
- Fügen Sie eine Ellipse mit der Methode [addAutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addAutoShape) der [ShapeCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/)-Objekt hinzu.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Das folgende Beispiel fügt der ersten Folie eine Ellipse hinzu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instanziieren Sie die Presentation‑Klasse, die die PPTX‑Datei repräsentiert.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Fügen Sie eine Ellipsenform hinzu.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Schreiben Sie die PPTX‑Datei auf die Festplatte.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formatierten Ellipse erstellen**

Um einer Folie eine formatierte Ellipse hinzuzufügen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
- Holen Sie eine Referenz zu einer Folie über deren Index.
- Fügen Sie eine Ellipse mit der Methode [addAutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addAutoShape) der [ShapeCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/)-Objekt hinzu.
- Setzen Sie den Fülltyp der Ellipse auf Solid.
- Setzen Sie die Füllfarbe der Ellipse über [getSolidFillColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/#getSolidFillColor) im [FillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/)-Objekt, das dem [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/)-Objekt zugeordnet ist.
- Setzen Sie die Farbe der Kontur der Ellipse.
- Setzen Sie die Breite der Kontur der Ellipse.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Das folgende Beispiel fügt der ersten Folie der Präsentation eine formatierte Ellipse hinzu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Instanziieren Sie die Presentation-Klasse, die die PPTX-Datei repräsentiert.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Fügen Sie eine Ellipsenform hinzu.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Formatieren Sie die Füllung der Ellipse.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Formatieren Sie die Kontur der Ellipse.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # Schreiben Sie die PPTX-Datei auf die Festplatte.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Wie lege ich die genaue Position und Größe einer Ellipse in Bezug auf die Folieneinheiten fest?**

Koordinaten und Größen werden typischerweise **in Punkten** angegeben. Für vorhersehbare Ergebnisse basieren Sie Ihre Berechnungen auf der Foliengröße und wandeln Sie erforderliche Millimeter oder Zoll vor der Zuweisung in Punkte um.

**Wie kann ich eine Ellipse über oder unter anderen Objekten platzieren (Staplereihenfolge steuern)?**

Passen Sie die Zeichenreihenfolge des Objekts an, indem Sie es nach vorne bringen oder nach hinten senden. So kann die Ellipse andere Objekte überlappen oder jene darunter sichtbar machen.

**Wie animiere ich das Auftreten oder die Hervorhebung einer Ellipse?**

[Anwenden](/slides/de/python-java/shape-animation/) von Eingangs‑, Betonungs‑ oder Ausgangseffekten auf die Form und konfigurieren Sie Trigger und Zeitpläne, um zu bestimmen, wann und wie die Animation abgespielt wird.