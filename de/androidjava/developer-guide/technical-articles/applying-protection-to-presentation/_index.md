---
title: Einschränken von Präsentationsänderungen mit Shape‑Locks auf Android
linktitle: Einschränken von Präsentationsänderungen
type: docs
weight: 60
url: /de/androidjava/applying-protection-to-presentation/
keywords:
- Bearbeitung verhindern
- vor Bearbeitung schützen
- Shape sperren
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
description: "Erfahren Sie, wie Sie Shapes in PPTX‑Präsentationen mit Aspose.Slides für Android via Java sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung einzuschränken."
---
## **Übersicht**

Ein häufiger Anwendungsfall von Aspose.Slides für Android via Java besteht darin, PowerPoint‑Präsentationen (PPTX) zu erstellen, zu aktualisieren und zu speichern, als Teil eines automatisierten Workflows. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Shapes helfen, das beabsichtigte Layout und den Inhalt beizubehalten.

Dieser Artikel erklärt, wie Shapes auf Folien organisiert sind und wie Shape‑Locks in einer PPTX‑Präsentation angewendet und entfernt werden. Diese Locks ermöglichen es, bestimmte Bearbeitungsoperationen für einzelne Shapes einzuschränken.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie AutoShapes, Tabellen, OLE‑Objekten, gruppierten Shapes, Bildrahmen, Video‑Frames, Verbindern und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides für Android via Java wird jedes Element auf einer Folie durch ein Objekt repräsentiert, das das [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)‑Interface implementiert oder von einer entsprechenden Klasse erbt.

Verschiedene Shape‑Typen bieten unterschiedliche Sperroptionen. Das [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/)‑Interface ist das Basisschnittstelle für Shape‑Locks. Aspose.Slides für Android via Java stellt die folgenden Lock‑Interfaces bereit:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) sperrt AutoShapes.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) sperrt Connector‑Shapes.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) sperrt grafische Objekte.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) sperrt Gruppen‑Shapes.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) sperrt Bildrahmen.  

Um Locks für eine [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) anzuwenden, iterieren Sie über deren Folien und setzen die entsprechenden Locks für jedes unterstützte Shape.

## **Schutz anwenden und entfernen**

Kompatible Präsentationseditoren verwenden Shape‑Locks, um einzelne Bearbeitungsoperationen einzuschränken. Dateiverschlüsselung und schreibgeschützte Dokumentebene sind separate [Passwortschutz](/slides/de/androidjava/password-protected-presentation/).

### **Schutz auf PPTX‑Shapes anwenden**

Aspose.Slides für Android via Java stellt das [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)‑Interface zur Arbeit mit Shapes auf einer Folie bereit.

Im Beispiel werden [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-) , [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) und [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) mit `true` für AutoShapes aufgerufen, ebenso entsprechende Locks für Gruppen‑Shapes, Connectoren und Bildrahmen. Connectoren verwenden [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) für die Bewegung; Gruppen verwenden zudem [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) , um das Gruppieren einzuschränken.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Shapes in der Shape‑Collection jeder Folie und speichert eine Kopie mit den angewandten Einschränkungen. Shapes außerhalb der vier behandelten Typen bleiben unverändert. Die Schleife traversiert nicht die Child‑Shapes innerhalb einer Gruppe.

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

Um einen Shape‑Lock zu entfernen, setzen Sie dessen Wert auf `false`. Das folgende Beispiel lädt eine Präsentation mit Shape‑Locks und löscht die Auswahl‑, Bewegungs‑ und Größenänderungs‑Einschränkungen über [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) , [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) , [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) und [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) . Es entfernt außerdem die Gruppierungs­einschränkung, indem `false` an [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) übergeben wird, und speichert eine Kopie der Präsentation. Andere Lock‑Einstellungen bleiben unverändert.

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

### **Bildausschnitt beibehalten**

Legen Sie ein Foto mit dem Namen `photo.jpg` im Arbeitsverzeichnis ab. Das Beispiel schneidet 12 % von links und 8 % von rechts zu und ruft dann [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) auf dem Lock des Bildrahmens auf. Das Übergeben von `true` schränkt weiteres Zuschneiden ein und bewahrt den bestehenden Ausschnitt.

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

`PictureLocked.pptx` speichert den Crop‑Lock als `true`. In PowerPoint ist der Befehl **Zuschneiden** deaktiviert, wenn das Foto ausgewählt ist.

### **Diagramm gruppiert halten**

Das Beispiel gruppiert ein Rechteck und einen Pfeil und ruft dann [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) auf dem Lock der Gruppe auf, um die Komponenten des Diagramms zusammenzuhalten. Andere Bearbeitungen, wie das Verschieben der Gruppe oder das Ändern der Füllung eines Elements, bleiben verfügbar.

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

`DiagramLocked.pptx` speichert den Ungroup‑Lock als `true`. In PowerPoint ist der Befehl **Gruppierung aufheben** deaktiviert, wenn das gesamte Diagramm ausgewählt ist.

### **Fazit**

Aspose.Slides für Android via Java ermöglicht es, bestimmte Bearbeitungsoperationen für einzelne Shapes einzuschränken oder dieselben Einschränkungen über alle Folien hinweg anzuwenden. Wählen Sie die von jedem Shape‑Typ unterstützten Locks und setzen Sie deren Werte auf `false`, wenn Sie diese Einschränkungen entfernen möchten.

## **FAQ**

**Kann ich Shape‑Locks und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Shape‑Locks schränken bestimmte Bearbeitungsoperationen ein, während [Passwortschutz](/slides/de/androidjava/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Sie können beides in derselben Datei verwenden.

**Kann ich die Bearbeitung bestimmter Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Locks nur auf Shapes der ausgewählten Folien an. Dies ändert die Lock‑Einstellungen auf anderen Folien nicht.

**Wie kann ich Locks auf einzelne Shapes innerhalb einer Gruppe anwenden?**

Iterieren Sie durch die von der Gruppe zurückgegebene Collection via [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--)‑Methode und wenden Sie die entsprechenden Locks auf jedes Child‑Shape an. Wiederholen Sie dies für verschachtelte Gruppen. Die obigen Beispiele verarbeiten nur die Shape‑Collection der Folie, sodass sie keine Locks für einzelne Gruppenmitglieder setzen.