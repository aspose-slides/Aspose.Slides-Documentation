---
title: Beschränken Sie Präsentationsbearbeitungen mit Form‑Sperren auf Android
linktitle: Beschränken Sie Präsentationsbearbeitungen
type: docs
weight: 60
url: /de/androidjava/applying-protection-to-presentation/
keywords:
- Bearbeitungen verhindern
- Vor Bearbeitung schützen
- Form sperren
- Position sperren
- Auswahl sperren
- Größenänderung sperren
- Gruppierung sperren
- PowerPoint
- PPTX
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PPTX‑Präsentationen mit Aspose.Slides for Android via Java sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung zu beschränken."
---
## **Übersicht**

Ein häufiger Anwendungsfall von Aspose.Slides for Android via Java besteht darin, PowerPoint (PPTX)-Präsentationen im Rahmen eines automatisierten Workflows zu erstellen, zu aktualisieren und zu speichern. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen dabei helfen, das beabsichtigte Layout und den Inhalt zu bewahren.

## **Zusammensetzung einer Folie**

Eine Folie einer Präsentation besteht aus Komponenten wie Autoformen, Tabellen, OLE-Objekten, gruppierten Formen, Bildrahmen, Video‑Frames, Verbindungsobjekten und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides for Android via Java wird jedes Element einer Folie durch ein Objekt dargestellt, das das Interface [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) implementiert oder von einer Klasse erbt, die dies tut.

Verschiedene Formtypen bieten unterschiedliche Sperroptionen. Das Interface [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) ist die Basisschnittstelle für Form‑Sperren. Aspose.Slides for Android via Java stellt die folgenden Sperr‑Interfaces bereit:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) sperrt Autoformen.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) sperrt Verbindungsformen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) sperrt grafische Objekte.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) sperrt Gruppenformen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) sperrt Bildrahmen.  

Um Sperren auf eine [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) anzuwenden, iterieren Sie durch deren Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Schutz anwenden und entfernen**

Form‑Sperren beschränken Vorgänge wie das Auswählen, Verschieben und Ändern der Größe von Formen. Sie machen die gesamte Präsentation nicht unveränderlich.

### **Schutz für PPTX‑Formen anwenden**

Aspose.Slides for Android via Java bietet das Interface [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) zur Arbeit mit Formen auf einer Folie.

Das Beispiel ruft [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-) , [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) und [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) mit `true` für Autoformen auf, sowie entsprechende Sperren für Gruppenformen, Verbinder und Bildrahmen. Verbinder verwenden [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) für Bewegungen; Gruppen verwenden zudem [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) um Gruppierungen zu beschränken.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Formen in der Form‑Sammlung jeder Folie und speichert eine Kopie mit den angewendeten Einschränkungen. Formen, die nicht zu den vier behandelten Typen gehören, bleiben unverändert. Die Schleife durchläuft nicht die untergeordneten Formen innerhalb einer Gruppe.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Schutz entfernen**

Um eine Form‑Sperre zu entfernen, setzen Sie ihren Wert auf `false`. Das folgende Beispiel lädt eine Präsentation mit Form‑Sperren und entfernt die Auswahl‑, Bewegungs‑ und Größenänderungs‑Einschränkungen über [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) und [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Es entfernt zudem die Gruppierungs‑Einschränkung, indem `false` an [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) übergeben wird, und speichert eine Kopie der Präsentation. Andere Sperreinstellungen bleiben unverändert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Fazit**

Aspose.Slides for Android via Java ermöglicht es Ihnen, bestimmte Bearbeitungsvorgänge für einzelne Formen zu beschränken oder dieselben Einschränkungen über Folien hinweg anzuwenden. Wählen Sie die von jedem Formtyp unterstützten Sperren und setzen Sie deren Werte auf `false`, wenn Sie diese Einschränkungen entfernen möchten.

## **FAQ**

**Kann ich Form‑Sperren und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Form‑Sperren beschränken bestimmte Bearbeitungsvorgänge, während [Passwortschutz](/slides/de/androidjava/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Sie können beide in derselben Datei verwenden.

**Kann ich die Bearbeitung bestimmter Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Sperren nur auf die Formen der ausgewählten Folien an. Dies ändert die Sperreinstellungen auf anderen Folien nicht.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie über die Sammlung, die von der Methode [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) der Gruppe zurückgegeben wird, und wenden Sie die entsprechenden Sperren auf jede untergeordnete Form an. Wiederholen Sie dies für verschachtelte Gruppen. Die obigen Beispiele verarbeiten nur die Form‑Sammlung der Folie, sodass sie keine Sperren für einzelne Gruppenmitglieder setzen.