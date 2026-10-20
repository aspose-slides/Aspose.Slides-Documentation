---
title: Einschränken von Präsentationsbearbeitungen mit Form‑Sperren in Python
linktitle: Einschränken von Präsentationsbearbeitungen
type: docs
weight: 70
url: /de/python-net/applying-protection-to-presentation/
keywords:
- Bearbeitung verhindern
- Schutz vor Bearbeitung
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
description: "Erfahren Sie, wie Sie Formen in PPTX‑Präsentationen mit Aspose.Slides für Python über .NET sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung zu beschränken."
---
## **Hintergrund**

Eine häufige Verwendung von Aspose.Slides für Python über .NET besteht darin, PowerPoint‑Präsentationen (PPTX) zu erstellen, zu aktualisieren und zu speichern, um sie in einen automatisierten Workflow einzubinden. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen dabei helfen, das beabsichtigte Layout und den Inhalt zu erhalten.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie Form‑Sperren in einer PPTX‑Präsentation angewendet und entfernt werden. Diese Sperren ermöglichen es, bestimmte Bearbeitungsaktionen für einzelne Formen einzuschränken.

## **Zusammensetzung einer Folie**

Eine Folie einer Präsentation besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, Gruppierten Formen, Bildrahmen, Video‑rahmen, Verbindern und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides für Python über .NET wird jedes Element einer Folie durch ein Objekt dargestellt, das von der Klasse [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) erbt.

Verschiedene Formtypen bieten unterschiedliche Sperroptionen. Die Klasse [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) ist die Basisklasse für Form‑Sperren. Aspose.Slides für Python über .NET stellt die folgenden Sperrklassen bereit:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) sperrt Autoformen.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) sperrt Verbinderformen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) sperrt grafische Objekte.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) sperrt Gruppierte Formen.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) sperrt Bildrahmen.  

Um Sperren über eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) hinweg anzuwenden, iterieren Sie durch deren Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Schutz anwenden und entfernen**

Form‑Sperren beschränken Vorgänge wie das Auswählen, Verschieben und Ändern der Größe von Formen. Sie machen die gesamte Präsentation nicht uneditierbar.

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides für Python über .NET stellt die Klasse [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) zur Verfügung, um mit Formen auf einer Folie zu arbeiten.

Das Beispiel setzt [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) und [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) für Autoformen auf `True`, mit entsprechenden Sperren für Gruppierte Formen, Verbinder und Bildrahmen. Verbinder verwenden [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) für die Bewegung; Gruppen verwenden zudem [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) , um das Gruppieren zu beschränken.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Formen in der Form‑Sammlung jeder Folie und speichert eine Kopie mit den angewendeten Einschränkungen. Formen, die nicht zu den vier behandelten Typen gehören, bleiben unverändert. Die Schleife durchläuft nicht die Kindformen innerhalb einer Gruppe.

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

Um eine Form‑Sperre zu entfernen, setzen Sie deren Wert auf `False`. Das folgende Beispiel lädt eine Präsentation mit Form‑Sperren und entfernt die Auswahl‑, Bewegungs‑ und Größenänderungs‑Einschränkungen über [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) und [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Zusätzlich wird [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) zurückgesetzt und eine Kopie der Präsentation gespeichert. Andere Sperreinstellungen bleiben unverändert.

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

### **Fazit**

Aspose.Slides für Python über .NET ermöglicht es, bestimmte Bearbeitungsaktionen für einzelne Formen einzuschränken oder dieselben Einschränkungen über Folien hinweg anzuwenden. Wählen Sie die von jedem Formtyp unterstützten Sperren aus und setzen Sie deren Werte auf `False`, wenn Sie diese Einschränkungen entfernen möchten.

## **FAQ**

**Kann ich Form‑Sperren und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Form‑Sperren beschränken bestimmte Bearbeitungsaktionen, während [password protection](/slides/de/python-net/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Sie können beide in derselben Datei verwenden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Sperren nur auf die Formen der ausgewählten Folien an. Dadurch werden die Sperreinstellungen anderer Folien nicht verändert.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie durch die [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)‑Sammlung der Gruppe und wenden Sie die entsprechenden Sperren auf jede Kindform an. Wiederholen Sie dies für verschachtelte Gruppen. Die obigen Beispiele verarbeiten nur die Form‑Sammlung der Folie, sodass sie keine Sperren für einzelne Gruppenmitglieder setzen.