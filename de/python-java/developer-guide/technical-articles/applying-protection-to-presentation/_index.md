---
title: Einschränken von Präsentationsbearbeitungen mit Form‑Sperren in Python
linktitle: Einschränken von Präsentationsbearbeitungen
type: docs
weight: 60
url: /de/python-java/applying-protection-to-presentation/
keywords:
- Bearbeitung verhindern
- vor Bearbeitung schützen
- Form sperren
- Position sperren
- Auswahl sperren
- Größenänderung sperren
- Gruppierung sperren
- PowerPoint
- PPTX
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PPTX‑Präsentationen mit Aspose.Slides for Python via Java sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung zu beschränken."
---
## **Hintergrund**

Eine häufige Verwendung von Aspose.Slides for Python via Java besteht darin, PowerPoint‑Präsentationen (PPTX) im Rahmen eines automatisierten Workflows zu erstellen, zu aktualisieren und zu speichern. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen dazu beitragen, das beabsichtigte Layout und den Inhalt zu bewahren.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie Form‑Sperren in einer PPTX‑Präsentation angewendet und entfernt werden. Diese Sperren ermöglichen es, bestimmte Bearbeitungsoperationen für einzelne Formen zu beschränken.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, gruppierten Formen, Bildrahmen, Video‑Frames, Verbindungs‑Linien und anderen Elementen, die zum Aufbau einer Präsentation verwendet werden. In Aspose.Slides for Python via Java wird jedes Element auf einer Folie durch ein Objekt dargestellt, das von der [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)‑Klasse erbt.

Verschiedene Formtypen bieten unterschiedliche Sperr‑Optionen. Die Klasse [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) ist die Basisklasse für Form‑Sperren. Aspose.Slides for Python via Java stellt die folgenden Sperrklassen bereit:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) sperrt Autoformen.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) sperrt Verbindungs‑Linien.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) sperrt grafische Objekte.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) sperrt gruppierte Formen.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) sperrt Bildrahmen.  

Um Sperren für ein ganzes [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) anzuwenden, iterieren Sie über dessen Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Sperren anwenden und entfernen**

Kompatible Präsentations‑Editoren nutzen Form‑Sperren, um einzelne Bearbeitungsoperationen einzuschränken. Dateiverschlüsselung und schreibgeschützte Dokument‑Ebene sind separate [presentation protection settings](/slides/de/python-java/password-protected-presentation/).

### **Sperren auf PPTX‑Formen anwenden**

Aspose.Slides for Python via Java stellt die [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)‑Klasse zur Arbeit mit Formen auf einer Folie bereit.

Das Beispiel ruft [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) und [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) mit `True` für Autoformen auf, sowie gleichartige Sperren für gruppierte Formen, Verbindungs‑Linien und Bildrahmen. Verbindungs‑Linien verwenden [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) für die Bewegung; Gruppen verwenden zudem [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked), um das Gruppieren zu beschränken.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Formen in jeder Folien‑Form‑Sammlung und speichert eine Kopie mit den angewendeten Einschränkungen. Formen außerhalb der vier behandelten Typen bleiben unverändert. Die Schleife durchläuft nicht die Kindformen innerhalb einer Gruppe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Sperren entfernen**

Um eine Form‑Sperre zu entfernen, setzen Sie deren Wert auf `False`. Das folgende Beispiel lädt eine Präsentation mit Form‑Sperren und hebt die Auswahl‑, Bewegungs‑ und Größen‑Beschränkungen über [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) und [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) auf. Es entfernt zudem die Gruppierungs‑Beschränkung, indem `False` an [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) übergeben wird, und speichert eine Kopie der Präsentation. Andere Sperr‑Einstellungen bleiben unverändert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Bild‑Zuschneiden erhalten**

Platzieren Sie ein Foto mit dem Namen `photo.jpg` im Arbeitsverzeichnis. Das Beispiel schneidet 12 % von links und 8 % von rechts zu und ruft anschließend [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) mit `True` auf, um das Zuschneiden zu bewahren.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In `PictureLocked.pptx` deaktiviert PowerPoint den Befehl **Crop**, wenn Sie das Foto auswählen.

### **Diagramm gruppiert behalten**

Das Beispiel gruppiert ein Rechteck und einen Pfeil und ruft dann [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) mit `True` auf, um die beiden Formen zusammen zu halten. Sie können die Gruppe weiterhin verschieben oder die Füllung einer Komponente ändern.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In `DiagramLocked.pptx` deaktiviert PowerPoint den Befehl **Ungroup**, wenn Sie das gesamte Diagramm auswählen.

### **Bestehende Form‑Sperren melden**

Um eine Vorlage zu prüfen, öffnen Sie sie und lesen das Sperr‑Objekt jeder Form aus. Die Methode [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) gibt `True` zurück, wenn alle Flags dieses Objekts deaktiviert sind, und `False`, wenn mindestens eines aktiviert ist. Eine Gruppe und ihre Kinder besitzen separate Sperr‑Objekte, daher sollten Sie die Kinder ebenfalls untersuchen, selbst wenn die Gruppe keine Sperren hat.

Dieses Beispiel prüft die Bewegung von Autoformen, Bildrahmen und Gruppen. Es prüft zudem das Zuschneiden von Bildern und das Aufheben der Gruppierung für Gruppen. Der Bericht listet die erkannten aktivierten Flags auf und markiert Formtypen, die nicht untersucht werden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

Angenommen, Folie 1 von `Sample.pptx` enthält eine Gruppe namens `Layout` mit gesperrtem Aufheben der Gruppierung, ein Bild namens `Photo` darin mit gesperrtem Zuschneiden und ein nicht gesperrtes Rechteck namens `Free`. Der Bericht überspringt `Free` und gibt diese beiden Zeilen aus:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Der Bericht liest die gespeicherten Form‑bezogenen Bearbeitungs‑Flags, ohne sie zu ändern oder die Präsentation zu speichern. Der Schreibschutz auf Dokument‑Ebene ist eine separate Einstellung, und die Durchsetzung jedes Flags hängt vom Editor ab.

### **Fazit**

Aspose.Slides for Python via Java ermöglicht es, bestimmte Bearbeitungsoperationen für einzelne Formen zu beschränken oder dieselben Einschränkungen über mehrere Folien hinweg anzuwenden. Wählen Sie die für den jeweiligen Formtyp unterstützten Sperren und setzen Sie deren Werte auf `False`, wenn Sie die Einschränkungen entfernen möchten.

## **FAQ**

**Kann ich Form‑Sperren und Kennwortschutz in derselben Präsentation kombinieren?**

Ja. Form‑Sperren beschränken bestimmte Bearbeitungsoperationen, während [password protection](/slides/de/python-java/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Beide können in derselben Datei verwendet werden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Sperren nur auf die Formen der ausgewählten Folien an. Dies ändert die Sperr‑Einstellungen anderer Folien nicht.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie über die Sammlung, die von der Gruppen‑Methode [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) zurückgegeben wird, und setzen die entsprechenden Sperren für jede Kindform. Wiederholen Sie dies für verschachtelte Gruppen, indem Sie dem Traversierungs‑Ansatz aus dem Bericht‑Beispiel folgen.