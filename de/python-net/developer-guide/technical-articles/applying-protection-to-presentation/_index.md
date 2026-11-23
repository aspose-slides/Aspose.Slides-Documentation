---
title: Beschränken von Präsentationsbearbeitungen mit Formschlössern in Python
linktitle: Beschränken von Präsentationsbearbeitungen
type: docs
weight: 70
url: /de/python-net/applying-protection-to-presentation/
keywords:
- Bearbeitung verhindern
- Vor Bearbeitung schützen
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

Ein häufiger Anwendungsfall für Aspose.Slides for Python via .NET ist das Erstellen, Aktualisieren und Speichern von PowerPoint (PPTX)-Präsentationen als Teil eines automatisierten Workflows. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen helfen, das beabsichtigte Layout und den Inhalt zu bewahren.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie man Formschlösser in einer PPTX-Präsentation anwendet und entfernt. Diese Schlösser ermöglichen es, bestimmte Bearbeitungsoperationen für einzelne Formen zu beschränken.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, gruppierten Formen, Bildrahmen, Videorahmen, Verbindern und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides for Python via .NET wird jedes Element auf einer Folie durch ein Objekt repräsentiert, das von der [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) Klasse erbt.

Verschiedene Formtypen bieten unterschiedliche Sperroptionen. Die [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) Klasse ist die Basisklasse für Formschlösser. Aspose.Slides for Python via .NET stellt die folgenden Sperrklassen bereit:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) sperrt Autoformen.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) sperrt Connector‑Formen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) sperrt grafische Objekte.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) sperrt Gruppenformen.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) sperrt Bildrahmen.  

Um Schlösser über eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) zu setzen, iterieren Sie durch ihre Folien und setzen die entsprechenden Schlösser auf jede unterstützte Form.

## **Schutz anwenden und entfernen**

Kompatible Präsentationseditoren verwenden Formschlösser, um einzelne Bearbeitungsoperationen einzuschränken. Dateiverschlüsselung und schreibgeschützter Dokumentschutz sind separate [Präsentationsschutz‑Einstellungen](/slides/de/python-net/password-protected-presentation/).

### **Schutz für PPTX-Formen anwenden**

Aspose.Slides for Python via .NET stellt die [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) Klasse zur Arbeit mit Formen auf einer Folie bereit.

Das Beispiel setzt [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) und [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) auf `True` für Autoformen, mit entsprechenden Schlössern für gruppierte Formen, Connectoren und Bildrahmen. Connectoren benutzen [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) für Bewegung; Gruppen verwenden außerdem [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) um die Gruppierung zu beschränken.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Formen in jeder Folie‑Formsammlung und speichert eine Kopie mit diesen angewendeten Einschränkungen. Formen außerhalb der vier behandelten Typen bleiben unverändert. Die Schleife durchläuft nicht die untergeordneten Formen innerhalb einer Gruppe.

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

Um ein Formschloss zu entfernen, setzen Sie dessen Wert auf `False`. Das folgende Beispiel lädt eine Präsentation mit Formschlössern und löscht die Auswahl‑, Bewegungs‑ und Größenbeschränkungen über [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) und [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Es löscht außerdem [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) und speichert eine Kopie der Präsentation. Andere Schlusseinstellungen bleiben unverändert.

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

### **Bildausschnitt beibehalten**

Legen Sie ein Foto namens `photo.jpg` im Arbeitsverzeichnis ab. Das Beispiel schneidet 12 % von links und 8 % von rechts zu, dann setzt es [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) am Bildrahmen, um den Zuschnitt beizubehalten.

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

`PictureLocked.pptx` speichert das Zuschnittschloss als `True`. In PowerPoint ist der **Crop**‑Befehl deaktiviert, wenn das Foto ausgewählt ist.

### **Diagramm gruppiert halten**

Das Beispiel gruppiert ein Rechteck und einen Pfeil und setzt dann [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) am Gruppenobjekt, um die Komponenten des Diagramms zusammenzuhalten. Andere Bearbeitungen, wie das Verschieben der Gruppe oder das Ändern der Füllung einer Komponente, bleiben verfügbar.

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

`DiagramLocked.pptx` speichert das Ungruppierungsschloss als `True`. In PowerPoint ist der **Ungroup**‑Befehl deaktiviert, wenn das gesamte Diagramm ausgewählt ist.

### **Fazit**

Aspose.Slides for Python via .NET ermöglicht es, bestimmte Bearbeitungsoperationen für einzelne Formen einzuschränken oder die gleichen Einschränkungen über Folien hinweg anzuwenden. Wählen Sie die von jedem Formtyp unterstützten Schlösser und setzen Sie deren Werte auf `False`, wenn Sie diese Einschränkungen entfernen möchten.

## **FAQ**

**Kann ich Formschlösser und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Formschlösser beschränken bestimmte Bearbeitungsoperationen, während [Passwortschutz](/slides/de/python-net/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Sie können beide in derselben Datei verwenden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Schlösser nur auf Formen der ausgewählten Folien an. Dies ändert die Schlusseinstellungen nicht auf anderen Folien.

**Wie kann ich Schlösser auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie durch die [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) Sammlung der Gruppe und wenden Sie die entsprechenden Schlösser auf jede untergeordnete Form an. Wiederholen Sie dies für verschachtelte Gruppen. Die obigen Beispiele verarbeiten nur die Formsammlung der Folie, sodass sie keine Schlösser auf einzelne Gruppenmitglieder setzen.