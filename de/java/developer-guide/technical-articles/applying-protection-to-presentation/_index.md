---
title: Einschränken von Präsentationsbearbeitungen mit Form‑Sperren in Java
linktitle: Einschränken von Präsentationsbearbeitungen
type: docs
weight: 60
url: /de/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PPTX‑Präsentationen mit Aspose.Slides for Java sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung einzuschränken."
---
## **Hintergrund**

Ein häufiges Einsatzszenario von Aspose.Slides for Java ist das Erstellen, Aktualisieren und Speichern von PowerPoint‑(PPTX‑)Präsentationen im Rahmen eines automatisierten Workflows. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen dabei helfen, das beabsichtigte Layout und den Inhalt zu erhalten.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie Form‑Sperren in einer PPTX‑Präsentation angewendet und entfernt werden. Diese Sperren ermöglichen es, bestimmte Bearbeitungsoperationen für einzelne Formen zu beschränken.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, gruppierten Formen, Bildrahmen, Video‑Frames, Verbindern und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides for Java wird jedes Element einer Folie durch ein Objekt repräsentiert, das das [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)‑Interface implementiert oder von einer Klasse erbt, die dies tut.

Verschiedene Formtypen bieten unterschiedliche Sperroptionen. Das [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/)‑Interface ist das Basisschnittstelle für Form‑Sperren. Aspose.Slides for Java stellt die folgenden Sperr‑Interfaces bereit:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) sperrt Autoformen.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) sperrt Connector‑Formen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) sperrt grafische Objekte.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) sperrt Gruppenformen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) sperrt Bildrahmen.  

Um Sperren über eine [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) hinweg anzuwenden, iterieren Sie über deren Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Schutz anwenden und entfernen**

Kompatible Präsentationseditoren verwenden Form‑Sperren, um einzelne Bearbeitungsoperationen zu beschränken. Dateiverschlüsselung und schreibgeschützte Dokumentebene sind separate [Präsentationsschutz‑Einstellungen](/slides/de/java/password-protected-presentation/).

### **Schutz auf PPTX-Formen anwenden**

Aspose.Slides for Java stellt das [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)‑Interface bereit, um mit Formen auf einer Folie zu arbeiten.

Das Beispiel ruft [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) und [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) mit `true` für Autoformen auf, mit entsprechenden Sperren für Gruppenformen, Connectoren und Bildrahmen. Connectoren verwenden [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) für Bewegungen; Gruppen nutzen zudem [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-), um das Gruppieren zu beschränken.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Formen in der Form‑Sammlung jeder Folie und speichert eine Kopie mit den angewendeten Einschränkungen. Formen außerhalb der vier behandelten Typen bleiben unverändert. Die Schleife durchläuft nicht die untergeordneten Formen innerhalb einer Gruppe.

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

Um eine Form‑Sperre zu entfernen, setzen Sie deren Wert auf `false`. Das folgende Beispiel lädt eine Präsentation mit Form‑Sperren und löscht die Auswahl‑, Bewegungs‑ und Größenänderungs‑Einschränkungen über [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) und [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Es entfernt außerdem die Gruppierungs‑Einschränkung, indem `false` an [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) übergeben wird, und speichert eine Kopie der Präsentation. Andere Sperreinstellungen bleiben unverändert.

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

### **Bildausschnitt erhalten**

Legen Sie ein Foto mit dem Namen `photo.jpg` im Arbeitsverzeichnis ab. Das Beispiel schneidet 12 % von links und 8 % von rechts ab und ruft dann [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) auf der Sperre des Bildrahmens auf. Die Übergabe von `true` verhindert weitere Zuschnitte und bewahrt den vorhandenen Zuschnitt.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);
    
    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` speichert die Zuschnitt‑Sperre als `true`. In PowerPoint ist der **Crop**‑Befehl deaktiviert, wenn das Foto ausgewählt ist.

### **Diagramm gruppiert halten**

Das Beispiel gruppiert ein Rechteck und einen Pfeil und ruft anschließend [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) auf der Sperre der Gruppe auf, um die Komponenten des Diagramms zusammenzuhalten. Andere Bearbeitungen, wie das Verschieben der Gruppe oder das Ändern der Füllung einer Komponente, bleiben verfügbar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` speichert die Auflösung‑Sperre als `true`. In PowerPoint ist der **Ungroup**‑Befehl deaktiviert, wenn das gesamte Diagramm ausgewählt ist.

### **Vorhandene Form‑Sperren melden**

Um eine Vorlage zu prüfen, öffnen Sie sie und lesen das Sperr‑Objekt jeder Form aus. Die Methode [getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--) gibt `true` zurück, wenn alle Flags dieses Objekts deaktiviert sind, und `false`, wenn mindestens eines aktiviert ist. Eine Gruppe und ihre Kinder besitzen separate Sperr‑Objekte, daher sollten Sie die Kinder prüfen, selbst wenn die Gruppe keine Sperren hat.

Dieses Beispiel prüft die Bewegung von Autoformen, Bildrahmen und Gruppen. Es prüft außerdem den Zuschnitt von Bildern und das Auflösen von Gruppen. Der Bericht listet die erkannten aktivierten Flags auf und markiert Formtypen, die nicht geprüft werden.

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Angenommen, Folie 1 von `Sample.pptx` enthält eine Gruppe namens `Layout` mit gesperrtem Auflösen, ein Bild namens `Photo` darin mit gesperrtem Zuschnitt und ein entsperrtes Rechteck namens `Free`. Der Bericht überspringt `Free` und gibt diese beiden Zeilen aus:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Der Bericht liest die gespeicherten, formbezogenen Bearbeitungsflags, ohne sie zu ändern oder die Präsentation zu speichern. Der schreibgeschützte Dokumentenschutz ist eine separate Einstellung, und die Durchsetzung jedes Flags hängt vom Editor ab.

### **Fazit**

Aspose.Slides for Java ermöglicht es, bestimmte Bearbeitungsoperationen für einzelne Formen zu beschränken oder dieselben Einschränkungen über Folien hinweg anzuwenden. Wählen Sie die von jedem Formtyp unterstützten Sperren und setzen Sie deren Werte auf `false`, wenn Sie diese Einschränkungen entfernen möchten.

## **FAQ**

**Kann ich Form‑Sperren und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Form‑Sperren beschränken bestimmte Bearbeitungsoperationen, während [Passwortschutz](/slides/de/java/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Sie können beide in derselben Datei verwenden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Sie wenden Sperren nur auf die Formen der ausgewählten Folien an. Dadurch werden die Sperreinstellungen anderer Folien nicht geändert.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie über die Sammlung, die von der Gruppe über die Methode [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) zurückgegeben wird, und wenden Sie die entsprechenden Sperren auf jede untergeordnete Form an. Wiederholen Sie dies für verschachtelte Gruppen und folgen Sie dabei der Durchlauf‑Logik im Bericht‑Beispiel.