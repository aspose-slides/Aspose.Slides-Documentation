---
title: Einschränkung von Präsentationsbearbeitungen mit Form‑Sperren in Java
linktitle: Einschränkung von Präsentationsbearbeitungen
type: docs
weight: 60
url: /de/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PPTX‑Präsentationen mit Aspose.Slides für Java sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung zu beschränken."
---
## **Hintergrund**

Eine häufige Verwendung von Aspose.Slides für Java besteht darin, PowerPoint (PPTX)-Präsentationen zu erstellen, zu aktualisieren und zu speichern, Teil eines automatisierten Workflows. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen helfen, das beabsichtigte Layout und den Inhalt zu erhalten.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie Form‑Sperren in einer PPTX‑Präsentation angewendet und entfernt werden. Diese Sperren ermöglichen es, bestimmte Bearbeitungsoperationen für einzelne Formen einzuschränken.

## **Zusammensetzung einer Folie**

Eine Folie einer Präsentation besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, gruppierten Formen, Bildrahmen, Videorahmen, Verbindern und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides für Java wird jedes Element auf einer Folie durch ein Objekt repräsentiert, das das [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)‑Interface implementiert oder von einer Klasse erbt, die dies tut.

Verschiedene Formtypen bieten unterschiedliche Sperroptionen. Das [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/)‑Interface ist das Basisschnittstelle für Form‑Sperren. Aspose.Slides für Java stellt die folgenden Sperr‑Interfaces bereit:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) sperrt Autoformen.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) sperrt Verbinderformen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) sperrt grafische Objekte.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) sperrt Gruppenformen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) sperrt Bildrahmen.  

Um Sperren über eine [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) anzuwenden, iterieren Sie durch deren Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Schutz anwenden und entfernen**

Form‑Sperren schränken Vorgänge wie Auswählen, Verschieben und Ändern der Größe von Formen ein. Sie machen die gesamte Präsentation nicht uneditierbar.

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides für Java bietet das [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)‑Interface, um mit Formen auf einer Folie zu arbeiten.

Das Beispiel ruft [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-) , [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) und [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) mit `true` für Autoformen auf, mit entsprechenden Sperren für Gruppenformen, Verbinder und Bildrahmen. Verbinder verwenden [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) für die Bewegung; Gruppen verwenden zudem [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) um das Gruppieren zu beschränken.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Formen in der Form‑Sammlung jeder Folie und speichert eine Kopie mit den angewendeten Einschränkungen. Formen außerhalb der vier behandelten Typen bleiben unverändert. Die Schleife durchläuft nicht die Kindformen innerhalb einer Gruppe.

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

Um eine Form‑Sperre zu entfernen, setzen Sie deren Wert auf `false`. Das folgende Beispiel lädt eine Präsentation mit Form‑Sperren und entfernt die Auswahl‑, Bewegungs‑ und Größenänderungs‑Einschränkungen über [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) , [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) , [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) und [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Es entfernt außerdem die Gruppierungs‑Einschränkung, indem `false` an [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) übergeben wird, und speichert eine Kopie der Präsentation. Andere Sperreinstellungen bleiben unverändert.

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

Aspose.Slides für Java ermöglicht es, bestimmte Bearbeitungsoperationen für einzelne Formen einzuschränken oder dieselben Einschränkungen über Folien hinweg anzuwenden. Wählen Sie die für jeden Formtyp unterstützten Sperren und setzen Sie deren Werte auf `false`, wenn Sie diese Einschränkungen entfernen müssen.

## **FAQ**

**Kann ich Form‑Sperren und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Form‑Sperren schränken bestimmte Bearbeitungsoperationen ein, während [Passwortschutz](/slides/de/java/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Sie können beide in derselben Datei verwenden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Sperren nur auf Formen der ausgewählten Folien an. Dadurch werden die Sperreinstellungen auf anderen Folien nicht geändert.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie durch die Sammlung, die von der Methode [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) der Gruppe zurückgegeben wird, und wenden Sie die entsprechenden Sperren auf jede Kindform an. Wiederholen Sie dies für verschachtelte Gruppen. Die obigen Beispiele verarbeiten nur die Form‑Sammlung der Folie, sodass sie keine Sperren für einzelne Gruppenmitglieder setzen.