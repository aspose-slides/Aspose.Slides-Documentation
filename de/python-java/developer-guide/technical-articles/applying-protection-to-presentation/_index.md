---
title: Verhindern von Präsentationsbearbeitungen mit Form‑Sperren
linktitle: Verhindern von Präsentationsbearbeitungen
type: docs
weight: 60
url: /de/python-java/applying-protection-to-presentation/
keywords:
- Bearbeitungen verhindern
- Schutz vor Bearbeitung
- Form sperren
- Position sperren
- Auswahl sperren
- Größe sperren
- Gruppierung sperren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Python über Java Formen in PPT-, PPTX- und ODP-Dateien sperrt oder entsperrt, Präsentationen sichert und gleichzeitig kontrollierte Bearbeitungen sowie eine schnellere Bereitstellung ermöglicht."
---
## **Hintergrund**

Eine häufige Verwendung von Aspose.Slides ist das Erstellen, Aktualisieren und Speichern von Microsoft PowerPoint (PPTX)-Präsentationen im Rahmen eines automatisierten Workflows. Benutzer von Anwendungen, die Aspose.Slides auf diese Weise einsetzen, haben Zugriff auf die erzeugten Präsentationen, sodass der Schutz vor Bearbeitung ein gängiges Anliegen ist. Es ist wichtig, dass automatisch erzeugte Präsentationen ihr ursprüngliches Format und ihren Inhalt beibehalten.

Dieser Artikel erklärt, wie Präsentationen und Folien strukturiert sind und wie Aspose.Slides für Python über Java Schutz auf eine Präsentation anwenden und später entfernen kann. Er bietet Entwicklern eine Möglichkeit, zu steuern, wie die von ihren Anwendungen erzeugten Präsentationen verwendet werden.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE-Objekten, Gruppierten Formen, Bildrahmen, Video‑Frames, Verbindern und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides für Python über Java wird jedes Element einer Folie durch ein Objekt dargestellt, das von der [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/)‑Klasse erbt.

Die Struktur von PPTX ist komplex, daher kann im Gegensatz zu PPT, wo ein generischer Sperrmechanismus für alle Formenarten verwendet werden kann, für verschiedene Formenarten unterschiedliche Sperren erforderlich sein. Die Klasse [BaseShapeLock](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseshapelock/) ist die generische Sperrklasse für PPTX. Die folgenden Sperrtypen werden in Aspose.Slides für Python über Java für PPTX unterstützt:

- [AutoShapeLock](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshapelock/) sperrt Autoformen.  
- [ConnectorLock](https://reference.aspose.com/slides/de/python-java/aspose.slides/connectorlock/) sperrt Verbindungselemente.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/de/python-java/aspose.slides/graphicalobjectlock/) sperrt grafische Objekte.  
- [GroupShapeLock](https://reference.aspose.com/slides/de/python-java/aspose.slides/groupshapelock/) sperrt Gruppenformen.  
- [PictureFrameLock](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframelock/) sperrt Bildrahmen.  

Jede Aktion, die an allen Formobjekten in einem [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Objekt durchgeführt wird, gilt für die gesamte Präsentation.

## **Schutz anwenden und entfernen**

Das Anwenden von Schutz stellt sicher, dass eine Präsentation nicht bearbeitet werden kann. Es ist eine nützliche Technik, um den Inhalt der Präsentation zu schützen.

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides für Python über Java stellt die [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/)‑Klasse zur Arbeit mit Formen auf einer Folie bereit.

Wie bereits erwähnt, hat jede Formklasse eine zugehörige Form‑Sperrklasse zum Schutz. Dieser Artikel konzentriert sich auf die Sperren NoSelect, NoMove und NoResize. Diese Sperren stellen sicher, dass Formen nicht ausgewählt (durch Mausklicks oder andere Auswahlmethoden) und nicht verschoben oder in der Größe geändert werden können.

Das folgende Codebeispiel wendet Schutz auf alle Formtypen in einer Präsentation an.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt.
presentation = Presentation("Sample.pptx")
try:
    # Durchlaufen Sie alle Folien in der Präsentation.
    for slide in presentation.getSlides():
        # Durchlaufen Sie alle Formen auf der Folie.
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

    # Speichern Sie die Präsentationsdatei.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Schutz entfernen**

Um eine Form zu entsperren, setzen Sie den Wert der angewendeten Sperre auf `False`. Das folgende Codebeispiel zeigt, wie Formen in einer gesperrten Präsentation entsperrt werden können.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt.
presentation = Presentation("ProtectedSample.pptx")
try:
    # Durchlaufen Sie alle Folien in der Präsentation.
    for slide in presentation.getSlides():
        # Durchlaufen Sie alle Formen in der Folie.
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

    # Speichern Sie die Präsentationsdatei.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Fazit**

Aspose.Slides bietet mehrere Möglichkeiten, Formen in einer Präsentation zu schützen. Sie können eine einzelne Form sperren oder alle Formen in einer Präsentation durchlaufen und jede einzeln sperren, um die gesamte Datei wirksam zu sichern. Sie können den Schutz entfernen, indem Sie den Sperrwert auf `False` setzen.

## **FAQ**

**Kann ich Form‑Sperren und Kennwortschutz in derselben Präsentation kombinieren?**

Ja. Sperren beschränken die Bearbeitung von Objekten innerhalb der Datei, während der [Kennwortschutz](/slides/de/python-java/password-protected-presentation/) den Zugriff auf das Öffnen und/oder das Speichern von Änderungen steuert. Diese Mechanismen ergänzen sich gegenseitig und arbeiten zusammen.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Sperren auf die Formen der ausgewählten Folien an; die übrigen Folien bleiben bearbeitbar.

**Gilt der Form‑Sperrmechanismus für gruppierte Objekte und Verbinder?**

Ja. Spezielle Sperrtypen werden für Gruppen, Verbinder, Grafikobjekte und andere Formarten unterstützt.