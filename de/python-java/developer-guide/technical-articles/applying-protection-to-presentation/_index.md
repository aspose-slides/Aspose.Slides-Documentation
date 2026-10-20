---
title: Einschränken von Präsentationsbearbeitungen mit Form‑Sperren in Python
linktitle: Einschränken von Präsentationsbearbeitungen
type: docs
weight: 60
url: /de/python-java/applying-protection-to-presentation/
keywords:
- Bearbeitungen verhindern
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

Ein gängiger Anwendungsfall für Aspose.Slides for Python via Java ist das Erstellen, Aktualisieren und Speichern von PowerPoint (PPTX)-Präsentationen im Rahmen eines automatisierten Workflows. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen helfen, das beabsichtigte Layout und den Inhalt zu erhalten.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie man Form‑Sperren in einer PPTX‑Präsentation anwendet und entfernt. Diese Sperren ermöglichen es, bestimmte Bearbeitungsoperationen für einzelne Formen einzuschränken.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, gruppierten Formen, Bildrahmen, Video‑Frames, Verbindern und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides for Python via Java wird jedes Element einer Folie durch ein Objekt repräsentiert, das von der [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)-Klasse erbt.

Verschiedene Formtypen bieten unterschiedliche Sperroptionen. Die [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/)-Klasse ist die Basisklasse für Form‑Sperren. Aspose.Slides for Python via Java stellt die folgenden Sperrklassen bereit:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) sperrt Autoformen.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) sperrt Verbinderformen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) sperrt grafische Objekte.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) sperrt Gruppierungen von Formen.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) sperrt Bildrahmen.  

Um Sperren für eine gesamte [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) anzuwenden, iterieren Sie über ihre Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Schutz anwenden und entfernen**

Form‑Sperren beschränken Vorgänge wie das Auswählen, Verschieben und Ändern der Größe von Formen. Sie machen die gesamte Präsentation nicht uneditierbar.

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides for Python via Java stellt die [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)-Klasse zur Arbeit mit Formen auf einer Folie bereit.

Das Beispiel ruft [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) und [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) mit `True` für Autoformen auf, sowie gleichwertige Sperren für Gruppierungsformen, Verbinder und Bildrahmen. Verbinder verwenden [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) für Bewegungen; Gruppen verwenden zudem [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked), um die Gruppierung zu beschränken.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Formen in der Form‑Sammlung jeder Folie und speichert eine Kopie mit den angewendeten Beschränkungen. Formen, die nicht zu den vier behandelten Typen gehören, bleiben unverändert. Die Schleife durchläuft nicht die Kindformen innerhalb einer Gruppe.

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

### **Schutz entfernen**

Um eine Form‑Sperre zu entfernen, setzen Sie ihren Wert auf `False`. Das folgende Beispiel lädt eine Präsentation mit Form‑Sperren und löscht die Auswahl‑, Bewegungs‑ und Größenänderungs‑Beschränkungen über [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) und [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Sie entfernt zudem die Gruppierungsbeschränkung, indem `False` an [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) übergeben wird, und speichert eine Kopie der Präsentation. Andere Sperreinstellungen bleiben unverändert.

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

### **Fazit**

Aspose.Slides for Python via Java ermöglicht es, bestimmte Bearbeitungsoperationen für einzelne Formen einzuschränken oder dieselben Beschränkungen über mehrere Folien hinweg anzuwenden. Wählen Sie die für jeden Formtyp unterstützten Sperren aus und setzen Sie deren Werte auf `False`, wenn Sie diese Beschränkungen entfernen müssen.

## **FAQ**

**Kann ich Form‑Sperren und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Form‑Sperren beschränken bestimmte Bearbeitungsoperationen, während [Passwortschutz](/slides/de/python-java/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Sie können beide in derselben Datei verwenden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Sperren nur auf die Formen der ausgewählten Folien an. Dies ändert die Sperreinstellungen anderer Folien nicht.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie über die Sammlung, die von der [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes)-Methode der Gruppe zurückgegeben wird, und wenden Sie die entsprechenden Sperren auf jede Kindform an. Wiederholen Sie dies für verschachtelte Gruppen. Die obigen Beispiele verarbeiten nur die Form‑Sammlung der Folie, daher setzen sie keine Sperren für einzelne Gruppenmitglieder.