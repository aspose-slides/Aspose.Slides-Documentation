---
title: Einschränken von Präsentationsbearbeitungen mit Formensperren unter Android
linktitle: Einschränken von Präsentationsbearbeitungen
type: docs
weight: 60
url: /de/androidjava/applying-protection-to-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PPTX‑Präsentationen mit Aspose.Slides für Android via Java sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung zu beschränken."
---
## **Übersicht**

Eine häufige Verwendung von Aspose.Slides für Android via Java besteht darin, PowerPoint‑ (PPTX‑) Präsentationen im Rahmen eines automatisierten Workflows zu erstellen, zu aktualisieren und zu speichern. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen dazu beitragen, das beabsichtigte Layout und den Inhalt beizubehalten.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie Formensperren in einer PPTX‑Präsentation angewendet und entfernt werden. Diese Sperren erlauben es, bestimmte Bearbeitungsvorgänge für einzelne Formen zu beschränken.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, gruppierten Formen, Bildrahmen, Video‑Frames, Verbindern und anderen Elementen, die zum Aufbau einer Präsentation verwendet werden. In Aspose.Slides für Android via Java wird jedes Element auf einer Folie durch ein Objekt repräsentiert, das das [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)‑Interface implementiert oder von einer entsprechenden Klasse erbt.

Verschiedene Formtypen bieten unterschiedliche Sperroptionen. Das [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/)‑Interface ist das Basisschnittstelle für Formensperren. Aspose.Slides für Android via Java stellt die folgenden Sperr‑Interfaces bereit:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) sperrt Autoformen.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) sperrt Verbinderformen.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) sperrt grafische Objekte.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) sperrt Gruppenformen.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) sperrt Bildrahmen.  

Um Sperren für eine gesamte [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) anzuwenden, iterieren Sie über deren Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Schutz anwenden und entfernen**

Kompatible Präsentationseditoren verwenden Formensperren, um einzelne Bearbeitungsvorgänge zu beschränken. Dateiverschlüsselung und schreibgeschützter Dokumentschutz sind separate [presentation protection settings](/slides/de/androidjava/password-protected-presentation/).

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides für Android via Java stellt das [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)‑Interface zum Arbeiten mit Formen auf einer Folie bereit.

Das Beispiel ruft [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) und [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) mit `true` für Autoformen auf, sowie die entsprechenden Sperren für Gruppenformen, Verbinder und Bildrahmen. Verbinder verwenden [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) für die Bewegung; Gruppen verwenden zusätzlich [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-), um die Gruppierung zu sperren.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Formen in der Formensammlung jeder Folie und speichert eine Kopie mit diesen angewendeten Einschränkungen. Formen, die nicht zu den vier behandelten Typen gehören, bleiben unverändert. Die Schleife traversiert nicht die Kindformen innerhalb einer Gruppe.

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

Um eine Formensperre zu entfernen, setzen Sie ihren Wert auf `false`. Das folgende Beispiel lädt eine Präsentation mit Formensperren und löscht die Auswahl‑, Bewegungs‑ und Größenänderungs‑Beschränkungen über [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) und [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Es entfernt zudem die Gruppierungsbeschränkung, indem `false` an [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) übergeben wird, und speichert eine Kopie der Präsentation. Andere Sperreinstellungen bleiben unverändert.

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

### **Bildzuschnitt beibehalten**

Platzieren Sie ein Foto mit dem Namen `photo.jpg` im Arbeitsverzeichnis. Das Beispiel schneidet 12 % von links und 8 % von rechts ab und ruft dann [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) auf der Sperre des Bildrahmens auf. Das Setzen von `true` beschränkt weitere Zuschnitte und bewahrt den vorhandenen Zuschnitt.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

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

`PictureLocked.pptx` speichert die Zuschnittsperre als `true`. In PowerPoint ist der **Zuschneiden**‑Befehl deaktiviert, wenn das Bild ausgewählt ist.

### **Diagramm gruppiert halten**

Das Beispiel gruppiert ein Rechteck und einen Pfeil und ruft anschließend [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) auf der Sperre der Gruppe auf, um die Komponenten des Diagramms zusammenzuhalten. Andere Bearbeitungen, wie das Verschieben der Gruppe oder das Ändern einer Füllung eines Elements, bleiben verfügbar.

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

`DiagramLocked.pptx` speichert die Entgruppierungssperre als `true`. In PowerPoint ist der **Gruppierung aufheben**‑Befehl deaktiviert, wenn das gesamte Diagramm ausgewählt ist.

### **Vorhandene Formensperren melden**

Um eine Vorlage zu überprüfen, öffnen Sie sie und lesen das Sperrobjekt jeder Form aus. Die Methode [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) liefert `true`, wenn alle Flags dieses Objekts deaktiviert sind, und `false`, wenn mindestens eines aktiviert ist. Eine Gruppe und ihre Kinder besitzen separate Sperrobjekte, daher sollten Sie die Kinder auch dann inspizieren, wenn die Gruppe keine Sperren hat.

Dieses Beispiel prüft die Bewegung für Autoformen, Bildrahmen und Gruppen. Außerdem prüft es den Zuschnitt für Bilder und die Entgruppierung für Gruppen. Der Bericht listet die erkannten aktivierten Flags auf und markiert Formtypen, die nicht untersucht werden.

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
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
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
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

Angenommen, Folie 1 von `Sample.pptx` enthält eine Gruppe namens `Layout` mit gesperrter Entgruppierung, ein Bild namens `Photo` darin mit gesperrtem Zuschnitt und ein nicht gesperrtes Rechteck namens `Free`. Der Bericht überspringt `Free` und gibt diese beiden Zeilen aus:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Der Bericht liest die gespeicherten, formbezogenen Bearbeitungsflags, ohne sie zu ändern oder die Präsentation zu speichern. Der dokumentweite Schreibschutz ist eine separate Einstellung, und die Durchsetzung jedes Flags hängt vom Editor ab.

### **Fazit**

Aspose.Slides für Android via Java ermöglicht es, bestimmte Bearbeitungsvorgänge für einzelne Formen einzuschränken oder dieselben Einschränkungen über mehrere Folien hinweg anzuwenden. Wählen Sie die für jeden Formtyp unterstützten Sperren aus und setzen Sie ihre Werte auf `false`, wenn Sie diese Beschränkungen entfernen müssen.

## **FAQ**

**Kann ich Formensperren und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Formensperren beschränken bestimmte Bearbeitungsvorgänge, während [password protection](/slides/de/androidjava/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Sie können beides in derselben Datei verwenden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie die Sperren nur auf Formen der ausgewählten Folien an. Dadurch werden die Sperreinstellungen auf anderen Folien nicht geändert.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Iterieren Sie über die Sammlung, die von der Gruppen‑Methode [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) zurückgegeben wird, und setzen Sie die entsprechenden Sperren für jede Kindform. Wiederholen Sie dies für verschachtelte Gruppen, indem Sie dem Traversal‑Verfahren im Berichtsexempel folgen.