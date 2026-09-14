---
title: Zeichenhilfen in Präsentationen verwalten in Python
linktitle: Zeichenhilfen
type: docs
weight: 85
url: /de/python-java/drawing-guides/
keywords:
- Zeichenhilfe
- horizontale Hilfslinie
- vertikale Hilfslinie
- Ausrichtungshilfe
- Folienansicht
- Masterfolie
- Layoutfolie
- Notiz-Master
- Handzettel-Master
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Fügen Sie horizontale und vertikale Zeichenhilfen in PowerPoint-Präsentationen hinzu, greifen Sie darauf zu und entfernen Sie sie mithilfe von Aspose.Slides für Python via Java."
---
## **Übersicht**

Zeichenhilfen sind einstellbare horizontale und vertikale Linien, die Benutzern helfen, Formen beim Bearbeiten einer PowerPoint-Präsentation konsequent auszurichten. Sie sind besonders nützlich, wenn eine Anwendung eine Präsentation erzeugt, die anschließend manuell verfeinert wird: Die Anwendung kann dieselben Ausrichtungs­hilfen speichern, denen Autoren beim Hinzufügen oder Verschieben von Inhalten folgen sollten.

Zeichenhilfen sind Bearbeitungshilfen, keine Folieninhalte. Sie erscheinen nicht in einer Bildschirmpräsentation oder gerenderten Ausgabe. Aspose.Slides for Python via Java stellt sie über die Klasse [DrawingGuidesCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/drawingguidescollection/) bereit. Eine Hilfslinie wird durch [DrawingGuide](https://reference.aspose.com/slides/de/python-java/aspose.slides/drawingguide/) repräsentiert und besitzt eine Ausrichtung, eine Position und eine Farbe.

Die Position wird in Punkten vom oberen linken Rand der entsprechenden Folie oder des Masters gemessen. Eine vertikale Hilfslinie verwendet eine horizontale Koordinate, typischerweise zwischen Null und der Folienbreite. Eine horizontale Hilfslinie verwendet eine vertikale Koordinate, typischerweise zwischen Null und der Folienhöhe.

## **Hilfslinien zur Folienansicht hinzufügen**

Verwenden Sie [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/de/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides), um die während der Bearbeitung normaler Folien angezeigten Hilfslinien zu verwalten. Rufen Sie [DrawingGuidesCollection.add](https://reference.aspose.com/slides/de/python-java/aspose.slides/drawingguidescollection/#add) mit einem [Orientation](https://reference.aspose.com/slides/de/python-java/aspose.slides/orientation/)-Wert und einer Position in Punkten auf.

Das folgende Beispiel fügt eine vertikale Hilfslinie rechts von der Folienmitte und eine horizontale Hilfslinie darunter hinzu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zugriff auf Zeichenhilfen**

Die Methoden [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/de/python-java/aspose.slides/drawingguidescollection/#getCount) und [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/de/python-java/aspose.slides/drawingguidescollection/#get_Item) ermöglichen den Zugriff auf vorhandene Hilfslinien. Die Methoden [DrawingGuide.getOrientation](https://reference.aspose.com/slides/de/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/de/python-java/aspose.slides/drawingguide/#getPosition) und [DrawingGuide.getColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/drawingguide/#getColor) geben Werte zurück, die ebenfalls über die entsprechenden Setter-Methoden geändert werden können.

Das folgende Beispiel liest die Folienansichts‑Hilfslinien aus der oben erstellten Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Hilfslinien zu Master- und Layout-Folien hinzufügen**

Ein Folien-Master und jede seiner Layout-Folien können eigene Zeichenhilfen-Sammlungen besitzen. Verwenden Sie [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterslide/#getDrawingGuides) für einen Master‑Slide und [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/de/python-java/aspose.slides/layoutslide/#getDrawingGuides) für einen Layout‑Slide.

Das folgende Beispiel fügt einer ersten Master‑Folie eine vertikale Hilfslinie und einer ersten Layout‑Folie eine horizontale Hilfslinie hinzu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hilfslinien zu Notiz- und Handzettel-Mastern hinzufügen**

Notiz-Master und Handzettel-Master unterstützen ebenfalls Zeichenhilfen. Verwenden Sie [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/de/python-java/aspose.slides/masternotesslide/#getDrawingGuides) und [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/de/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides), um auf deren Sammlungen zuzugreifen. Enthält eine Präsentation keinen dieser Master, erzeugt `MasterNotesSlideManager.setDefaultMasterNotesSlide` bzw. `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` den Standard-Master und gibt ihn zurück.

Das folgende Beispiel fügt einem Notiz-Master eine horizontale Hilfslinie und einem Handzettel-Master eine vertikale Hilfslinie hinzu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zeichenhilfen löschen**

Rufen Sie [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/drawingguidescollection/#clear) auf, um alle Hilfslinien aus einer bestimmten Sammlung zu entfernen. Das Löschen einer Sammlung wirkt sich nicht auf in einem anderen Bereich gespeicherte Hilfslinien aus.

Das folgende Beispiel löscht die Folienansichts‑Hilfslinien sowie alle Hilfslinien auf Folien-Mastern, Layout-Folien, dem Notiz-Master und dem Handzettel-Master, ohne fehlende Master zu erzeugen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Erscheinen Zeichenhilfen in einer Bildschirmpräsentation oder exportierten Bildern?**

Nein. Zeichenhilfen sind Ausrichtungshilfen für die Bearbeitung und werden nicht als Präsentationsinhalt gerendert.

**Kann eine Zeichenhilfe direkt zu einer einzelnen normalen Folie hinzugefügt werden?**

Bearbeitungs‑Hilfslinien für normale Folien werden in den Folienansichts‑Eigenschaften der Präsentation gespeichert. Separate Hilfslinien‑Sammlungen stehen für Folien‑Master, Layout‑Folien, Notiz‑Master und Handzettel‑Master zur Verfügung.

**Welche Einheiten werden für die Positionen von Hilfslinien verwendet?**

Positionen werden in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Vertikale Positionen werden vom linken Rand gemessen, horizontale Positionen vom oberen Rand.

**Entfernt das Löschen von Zeichenhilfen Formen oder ändert den Folieninhalt?**

Nein. Die Methode [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/drawingguidescollection/#clear) entfernt nur die Hilfslinien in der ausgewählten Sammlung. Formen und sonstiger Folieninhalt bleiben unverändert.