---
title: Beschränken Sie die Bearbeitung von Präsentationen mit Form‑Sperren in Node.js
linktitle: Präsentationsbearbeitung einschränken
type: docs
weight: 60
url: /de/nodejs-java/applying-protection-to-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PPTX‑Präsentationen mit Aspose.Slides for Node.js via Java sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung zu beschränken."
---
## **Übersicht**

Ein häufiger Anwendungsfall für Aspose.Slides for Node.js via Java ist das Erstellen, Aktualisieren und Speichern von PowerPoint (PPTX)-Präsentationen im Rahmen eines automatisierten Workflows. Wenn Nutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen helfen, das beabsichtigte Layout und den Inhalt zu bewahren.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie Form‑Sperren in einer PPTX‑Präsentation angewendet und entfernt werden. Diese Sperren ermöglichen es, bestimmte Bearbeitungsvorgänge für einzelne Formen einzuschränken.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, gruppierten Formen, Bildrahmen, Video‑Frames, Verbindern und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides for Node.js via Java wird jedes Element einer Folie durch ein Objekt dargestellt, das von der [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)‑Klasse erbt.

Verschiedene Formtypen bieten unterschiedliche Sperroptionen. Die Klasse [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) ist die Basisklasse für Form‑Sperren. Aspose.Slides for Node.js via Java stellt die folgenden Sperrklassen bereit:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) sperrt Autoformen.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) sperrt Verbinderformen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) sperrt grafische Objekte.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) sperrt gruppierte Formen.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) sperrt Bildrahmen.  

Um Sperren für eine [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) anzuwenden, iterieren Sie über deren Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Schutz anwenden und entfernen**

Form‑Sperren beschränken Vorgänge wie das Auswählen, Verschieben und Ändern der Größe von Formen. Sie machen die gesamte Präsentation nicht unveränderlich.

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides for Node.js via Java stellt die Klasse [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) zur Arbeit mit Formen auf einer Folie bereit.

Im Beispiel werden [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) und [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) mit `true` für Autoformen aufgerufen, ebenso entsprechende Sperren für gruppierte Formen, Verbinder und Bildrahmen. Verbinder verwenden [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) für die Bewegung; Gruppen verwenden zudem [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked), um das Gruppieren zu beschränken.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Formen in der Form‑Sammlung jeder Folie und speichert eine Kopie mit den angewendeten Einschränkungen. Formen, die nicht zu den vier behandelten Typen gehören, bleiben unverändert. Die Schleife durchläuft nicht die Kindformen innerhalb einer Gruppe.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Schutz entfernen**

Um eine Form‑Sperre zu entfernen, setzen Sie ihren Wert auf `false`. Das folgende Beispiel lädt eine Präsentation mit Form‑Sperren und löscht die Auswahl‑, Bewegungs‑ und Größenänderungs‑Einschränkungen über [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) und [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Es entfernt zudem die Gruppierungs‑Einschränkung, indem `false` an [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) übergeben wird, und speichert eine Kopie der Präsentation. Andere Sperreinstellungen bleiben unverändert.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Fazit**

Aspose.Slides for Node.js via Java ermöglicht es, bestimmte Bearbeitungsvorgänge für einzelne Formen einzuschränken oder dieselben Einschränkungen für mehrere Folien anzuwenden. Wählen Sie die für den jeweiligen Formtyp unterstützten Sperren und setzen Sie deren Werte auf `false`, wenn Sie diese Einschränkungen entfernen möchten.

## **FAQ**

**Kann ich Form‑Sperren und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Form‑Sperren beschränken bestimmte Bearbeitungsvorgänge, während [Passwortschutz](/slides/de/nodejs-java/password-protected-presentation/) das Öffnen oder Ändern der Präsentation beschränken kann. Sie können beides in derselben Datei verwenden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie die Sperren nur auf Formen der ausgewählten Folien an. Dadurch werden die Sperreinstellungen auf anderen Folien nicht geändert.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie über die Sammlung, die von der [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes)-Methode der Gruppe zurückgegeben wird, und wenden Sie die entsprechenden Sperren auf jede Kindform an. Wiederholen Sie dies für verschachtelte Gruppen. Die obigen Beispiele verarbeiten nur die Form‑Sammlung der Folie, sodass sie keine Sperren für einzelne Gruppenmitglieder setzen.