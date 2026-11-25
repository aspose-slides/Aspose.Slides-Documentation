---
title: Einschränkung von Präsentationsbearbeitungen mit Form‑Sperren in Python
linktitle: Einschränkung von Präsentationsbearbeitungen
type: docs
weight: 70
url: /de/python-net/applying-protection-to-presentation/
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
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PPTX‑Präsentationen mit Aspose.Slides für Python via .NET sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung zu beschränken."
---
## **Hintergrund**

Eine häufige Verwendung von Aspose.Slides für Python via .NET besteht darin, PowerPoint‑Präsentationen (PPTX) zu erstellen, zu aktualisieren und zu speichern als Teil eines automatisierten Workflows. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen dabei helfen, das beabsichtigte Layout und den Inhalt beizubehalten.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie Form‑Sperren in einer PPTX‑Präsentation angewendet und entfernt werden. Diese Sperren ermöglichen es, bestimmte Bearbeitungsvorgänge für einzelne Formen einzuschränken.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, gruppierten Formen, Bildrahmen, Video‑Frames, Verbindungs‑Elementen und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides für Python via .NET wird jedes Element einer Folie durch ein Objekt repräsentiert, das von der [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)‑Klasse erbt.

Verschiedene Form‑typen bieten unterschiedliche Sperr‑Optionen. Die [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) Klasse ist die Basisklasse für Form‑Sperren. Aspose.Slides für Python via .NET stellt die folgenden Sperrklassen bereit:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) sperrt Autoformen.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) sperrt Verbindungsformen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) sperrt grafische Objekte.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) sperrt Gruppierungsformen.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) sperrt Bildrahmen.  

Um Sperren für eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) anzuwenden, iterieren Sie über deren Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Schutz anwenden und entfernen**

Kompatible Präsentationseditoren verwenden Form‑Sperren, um einzelne Bearbeitungsvorgänge einzuschränken. Dateiverschlüsselung und schreibgeschützte Dokumentebene sind separate [Präsentations‑Schutzeinstellungen](/slides/de/python-net/password-protected-presentation/).

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides für Python via .NET stellt die [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)‑Klasse bereit, um mit Formen auf einer Folie zu arbeiten.

Das Beispiel setzt [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) und [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) für Autoformen auf `True`, mit entsprechenden Sperren für Gruppierungsformen, Verbindungsformen und Bildrahmen. Verbindungsformen verwenden [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) für Bewegungen; Gruppen verwenden zudem [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) zum Einschränken der Gruppierung.

Das Beispiel lädt eine bestehende PPTX‑Präsentation, prüft die Formen in jeder Folien‑Form‑Sammlung und speichert eine Kopie mit den angewendeten Einschränkungen. Formen außerhalb der vier behandelten Typen bleiben unverändert. Die Schleife durchläuft nicht die Kindformen innerhalb einer Gruppe.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Schutz entfernen**

Um eine Form‑Sperre zu entfernen, setzen Sie deren Wert auf `False`. Das folgende Beispiel lädt eine Präsentation mit Form‑Sperren und löscht die Auswahl‑, Bewegungs‑ und Größenänderungs‑Einschränkungen über [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) und [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Außerdem wird [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) zurückgesetzt und eine Kopie der Präsentation gespeichert. Andere Sperreinstellungen bleiben unverändert.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Bildzuschnitt beibehalten**

Legen Sie ein Foto mit dem Namen `photo.jpg` im Arbeitsverzeichnis ab. Das Beispiel schneidet 12 % von links und 8 % von rechts ab und setzt anschließend [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) am Bildrahmen. Dieses Flag verhindert weitere Zuschnitte und bewahrt den bestehenden Zuschnitt.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` speichert die Zuschnitt‑Sperre als `True`. In PowerPoint ist der **Crop**‑Befehl deaktiviert, wenn das Foto ausgewählt ist.

### **Diagramm gruppiert halten**

Das Beispiel gruppiert ein Rechteck und einen Pfeil und setzt dann [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) an der Gruppe selbst, um die Komponenten des Diagramms zusammenzuhalten. Andere Bearbeitungen, wie das Verschieben der Gruppe oder das Ändern der Füllung eines Elements, bleiben verfügbar.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` speichert die Ungruppierungs‑Sperre als `True`. In PowerPoint ist der **Ungroup**‑Befehl deaktiviert, wenn das gesamte Diagramm ausgewählt ist.

### **Vorhandene Form‑Sperren melden**

Um eine Vorlage zu prüfen, öffnen Sie sie und lesen das Sperrobjekt jeder Form aus. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) ist `True`, wenn alle Flags dieses Objekts deaktiviert sind, und `False`, wenn mindestens eines aktiviert ist. Eine Gruppe und ihre Kinder besitzen separate Sperrobjekte, daher sollten Sie die Kinder auch dann inspizieren, wenn die Gruppe keine Sperren hat.

Dieses Beispiel prüft Bewegungen für Autoformen, Bildrahmen und Gruppen, Zuschnitte für Bilder und Ungruppierung für Gruppen. Es gibt die erkannten Flags aus und markiert Form‑Typen, die es nicht inspiziert.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

Angenommen, Folie 1 von `Sample.pptx` enthält eine Gruppe mit dem Namen `Layout`, bei der die Ungruppierungs‑Sperre aktiviert ist, ein Bild mit dem Namen `Photo` darin, bei dem der Zuschnitt gesperrt ist, und ein nicht gesperrtes Rechteck mit dem Namen `Free`. Der Bericht überspringt `Free` und gibt diese beiden Zeilen aus:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

Der Bericht liest die gespeicherten, form‑spezifischen Bearbeitungs‑Flags, ohne sie zu ändern oder die Präsentation zu speichern. Schreibschutz auf Dokumentebene ist eine separate Einstellung, und die Durchsetzung jedes Flags hängt vom Editor ab.

### **Fazit**

Aspose.Slides für Python via .NET ermöglicht es, bestimmte Bearbeitungsvorgänge für einzelne Formen einzuschränken oder dieselben Einschränkungen über Folien hinweg anzuwenden. Wählen Sie die von jedem Form‑Typ unterstützten Sperren und setzen Sie ihre Werte auf `False`, wenn Sie diese Einschränkungen entfernen müssen.

## **FAQ**

**Kann ich Form‑Sperren und Kennwortschutz in derselben Präsentation kombinieren?**

Ja. Form‑Sperren schränken bestimmte Bearbeitungsvorgänge ein, während [Kennwortschutz](/slides/de/python-net/password-protected-presentation/) das Öffnen oder Ändern der Präsentation beschränken kann. Sie können beide in derselben Datei verwenden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Sperren nur auf die Formen der ausgewählten Folien an. Dadurch werden die Sperreinstellungen anderer Folien nicht geändert.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie durch die [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)‑Sammlung der Gruppe und setzen die entsprechenden Sperren für jede Kind‑Form. Wiederholen Sie dies für verschachtelte Gruppen, analog zum Traversieren im Bericht‑Beispiel.