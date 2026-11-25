---
title: "Präsentationsbearbeitung mit Form‑Sperren in Node.js beschränken"
linktitle: "Präsentationsbearbeitung einschränken"
type: docs
weight: 60
url: /de/nodejs-java/applying-protection-to-presentation/
keywords:
- "Bearbeitung verhindern"
- "vor Bearbeitung schützen"
- "Form sperren"
- "Position sperren"
- "Auswahl sperren"
- "Größenänderung sperren"
- "Gruppierung sperren"
- PowerPoint
- PPTX
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PPTX‑Präsentationen mit Aspose.Slides for Node.js via Java sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung zu beschränken."
---
## **Übersicht**

Ein häufiger Anwendungsfall für Aspose.Slides for Node.js via Java ist das Erstellen, Aktualisieren und Speichern von PowerPoint (PPTX)-Präsentationen im Rahmen eines automatisierten Workflows. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen dazu beitragen, das beabsichtigte Layout und den Inhalt zu bewahren.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie man Form‑Sperren in einer PPTX‑Präsentation anwendet und entfernt. Diese Sperren ermöglichen es, bestimmte Bearbeitungsoperationen für einzelne Formen zu beschränken.

## **Aufbau einer Folie**

Eine Folie einer Präsentation besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, gruppierten Formen, Bildrahmen, Video‑Frames, Verbindungslinien und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides for Node.js via Java wird jedes Element einer Folie durch ein Objekt dargestellt, das von der [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)‑Klasse erbt.

Verschiedene Formtypen bieten unterschiedliche Sperroptionen. Die Klasse [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) ist die Basisklasse für Form‑Sperren. Aspose.Slides for Node.js via Java stellt die folgenden Sperrklassen bereit:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) sperrt Autoformen.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) sperrt Verbindungslinien.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) sperrt grafische Objekte.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) sperrt gruppierte Formen.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) sperrt Bildrahmen.  

Um Sperren für eine [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) anzuwenden, iterieren Sie über deren Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Schutz anwenden und entfernen**

Kompatible Präsentationseditoren verwenden Form‑Sperren, um einzelne Bearbeitungsvorgänge zu beschränken. Dateiverschlüsselung und schreibgeschützte Dokumentebene sind separate [Präsentationsschutz‑Einstellungen](/slides/de/nodejs-java/password-protected-presentation/).

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides for Node.js via Java stellt die Klasse [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) zur Arbeit mit Formen auf einer Folie bereit.

Das Beispiel ruft [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) und [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) mit `true` für Autoformen auf, ebenso entsprechende Sperren für gruppierte Formen, Verbindungslinien und Bildrahmen. Verbindungslinien verwenden [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) für Bewegungen; Gruppen nutzen außerdem [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked), um das Gruppieren zu beschränken.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Formen in jeder Folien‑Formensammlung und speichert eine Kopie mit den angewendeten Beschränkungen. Formen außerhalb der vier behandelten Typen bleiben unverändert. Die Schleife durchläuft nicht die Kindformen innerhalb einer Gruppe.

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

Um eine Form‑Sperre zu entfernen, setzen Sie deren Wert auf `false`. Das folgende Beispiel lädt eine Präsentation mit Form‑Sperren und löst die Auswahl-, Bewegungs- und Größenänderungsbeschränkungen über [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) und [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) auf. Ebenso wird die Gruppierungsbeschränkung entfernt, indem `false` an [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) übergeben wird, und eine Kopie der Präsentation gespeichert. Andere Sperreinstellungen bleiben unverändert.

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

### **Bildausschnitt beibehalten**

Legen Sie ein Foto mit dem Namen `photo.jpg` im Arbeitsverzeichnis ab. Das Beispiel schneidet 12 % von links und 8 % von rechts zu und ruft dann [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) auf der Sperre des Bildrahmens auf. Das Übergeben von `true` beschränkt weiteres Zuschneiden und bewahrt den bestehenden Ausschnitt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const photoStream = java.newInstanceSync("java.io.FileInputStream", "photo.jpg");
    let photo;
    try {
        photo = presentation.getImages().addImage(photoStream);
    } finally {
        photoStream.close();
    }

    const pictureFrame = shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    const pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` speichert die Ausschnitt‑Sperre als `true`. In PowerPoint ist der Befehl **Crop** deaktiviert, wenn das Foto ausgewählt ist.

### **Diagramm gruppiert halten**

Das Beispiel gruppiert ein Rechteck und einen Pfeil und ruft dann [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) auf der Sperre der Gruppe auf, um die Komponenten des Diagramms zusammenzuhalten. Andere Bearbeitungen, wie das Verschieben der Gruppe oder das Ändern der Füllung einer Komponente, bleiben verfügbar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    
    const groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` speichert die Gruppierungslösend‑Sperre als `true`. In PowerPoint ist der Befehl **Ungroup** deaktiviert, wenn das gesamte Diagramm ausgewählt ist.

### **Bestehende Form‑Sperren melden**

Um eine Vorlage zu prüfen, öffnen Sie sie und lesen das Sperrobjekt jeder Form aus. Die Methode [getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks) gibt `true` zurück, wenn alle Flags dieses Objekts deaktiviert sind, und `false`, wenn mindestens eines aktiviert ist. Eine Gruppe und ihre Kinder besitzen separate Sperrobjekte, daher sollten Sie die Kinder untersuchen, selbst wenn die Gruppe keine Sperren hat.

Dieses Beispiel prüft die Bewegung für Autoformen, Bildrahmen und Gruppen. Es prüft außerdem das Zuschneiden für Bilder und das Aufheben der Gruppierung für Gruppen. Der Bericht listet die aktivierten Flags auf, die er erkennt, und markiert Formtypen, die er nicht untersucht.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function inspectShapes(shapes, slideNumber, prefix) {
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const path = prefix + shape.getName();
        const type = shape.getClass().getSimpleName();
        const label = `Slide ${slideNumber} | ${path} | ${type}`;
        const flags = [];
        const isGroup = java.instanceOf(shape, "com.aspose.slides.IGroupShape");
        let shapeLock;

        if (isGroup) {
            shapeLock = shape.getGroupShapeLock();
            if (shapeLock.getUngroupingLocked()) flags.push("UngroupingLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            shapeLock = shape.getPictureFrameLock();
            if (shapeLock.getCropLocked()) flags.push("CropLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shapeLock = shape.getAutoShapeLock();
        } else {
            console.log(`${label} | Uninspected`);
            continue;
        }

        if (!shapeLock.getNoLocks()) {
            if (shapeLock.getPositionLocked()) flags.push("PositionLocked");
            const restrictions = flags.length ? flags.join(", ") : "Active flag not identified";
            console.log(`${label} | ${restrictions}`);
        }

        if (isGroup) {
            inspectShapes(shape.getShapes(), slideNumber, path + "/");
        }
    }
}

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    const slides = presentation.getSlides();
    for (let i = 0; i < slides.size(); i++) {
        const slide = slides.get_Item(i);
        inspectShapes(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Angenommen, Folie 1 von `Sample.pptx` enthält eine Gruppe namens `Layout` mit gesperrtem Aufheben der Gruppierung, ein Bild namens `Photo` darin mit gesperrtem Zuschneiden und ein entsperrtes Rechteck namens `Free`. Der Bericht überspringt `Free` und gibt diese beiden Zeilen aus:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Der Bericht liest die gespeicherten bearbeitungsbezogenen Sperrflags auf Form‑Ebene, ohne sie zu ändern oder die Präsentation zu speichern. Der schreibgeschützte Dokumentschutz ist eine separate Einstellung, und die Durchsetzung jedes Flags hängt vom Editor ab.

## **Fazit**

Aspose.Slides for Node.js via Java ermöglicht es, bestimmte Bearbeitungsoperationen für einzelne Formen zu beschränken oder dieselben Beschränkungen über Folien hinweg anzuwenden. Wählen Sie die für jeden Formtyp unterstützten Sperren und setzen Sie deren Werte auf `false`, wenn Sie diese Beschränkungen entfernen müssen.

## **FAQ**

**Kann ich Form‑Sperren und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Form‑Sperren beschränken bestimmte Bearbeitungsvorgänge, während [Passwortschutz](/slides/de/nodejs-java/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Sie können beide in derselben Datei verwenden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Sperren nur auf Formen der ausgewählten Folien an. Dadurch werden die Sperreinstellungen auf anderen Folien nicht geändert.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie über die Sammlung, die von der Methode [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) der Gruppe zurückgegeben wird, und wenden Sie die entsprechenden Sperren auf jede Kindform an. Wiederholen Sie dies für verschachtelte Gruppen, indem Sie der Traversierung im Bericht‑Beispiel folgen.