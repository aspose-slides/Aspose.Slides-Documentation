---
title: Präsentationsbearbeitungen mit Shape‑Sperren in PHP einschränken
linktitle: Präsentationsbearbeitungen einschränken
type: docs
weight: 60
url: /de/php-java/applying-protection-to-presentation/
keywords:
- Bearbeitung verhindern
- Vor Bearbeitung schützen
- Shape sperren
- Position sperren
- Auswahl sperren
- Größenänderung sperren
- Gruppierung sperren
- PowerPoint
- PPTX
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Shapes in PPTX‑Präsentationen mit Aspose.Slides für PHP via Java sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung einzuschränken."
---
## **Übersicht**

Eine gängige Verwendung von Aspose.Slides for PHP via Java besteht darin, PowerPoint‑Präsentationen (PPTX) zu erstellen, zu aktualisieren und zu speichern, wobei dies Teil eines automatisierten Workflows ist. Wenn Benutzer diese Präsentationen erhalten, kann die Beschränkung von Änderungen an Shapes dazu beitragen, das beabsichtigte Layout und den Inhalt zu erhalten.

Dieser Artikel erklärt, wie Shapes auf Folien organisiert sind und wie Shape‑Sperren in einer PPTX‑Präsentation angewendet und entfernt werden. Diese Sperren ermöglichen es, bestimmte Bearbeitungsoperationen für einzelne Shapes einzuschränken.

## **Zusammensetzung einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie AutoShapes, Tabellen, OLE‑Objekten, gruppierten Shapes, Bildrahmen, Video‑Frames, Verbindungs‑Lines und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides for PHP via Java wird jedes Element einer Folie durch ein Objekt dargestellt, das von der Klasse [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) erbt.

Verschiedene Shape‑Typen bieten unterschiedliche Sperr‑Optionen. Die Klasse [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) ist die Basisklasse für Shape‑Sperren. Aspose.Slides for PHP via Java stellt die folgenden Sperrklassen bereit:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) sperrt AutoShapes.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) sperrt Connector‑Shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) sperrt Graphical‑Objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) sperrt Group‑Shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) sperrt Picture‑Frames.  

Um Sperren für eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) anzuwenden, iterieren Sie über deren Folien und setzen die entsprechenden Sperren für jedes unterstützte Shape.

## **Schutz anwenden und entfernen**

Shape‑Sperren schränken Vorgänge wie das Auswählen, Verschieben und Ändern der Größe von Shapes ein. Sie machen die gesamte Präsentation nicht unveränderlich.

### **Schutz für PPTX‑Shapes anwenden**

Aspose.Slides for PHP via Java stellt die Klasse [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) zur Arbeit mit Shapes auf einer Folie bereit.

Das Beispiel ruft [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) und [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) mit dem Wert `true` für AutoShapes auf und verwendet entsprechende Sperren für Gruppen‑Shapes, Connector‑Shapes und Picture‑Frames. Connector‑Shapes nutzen [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) für Bewegungen; Gruppen verwenden außerdem [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked), um das Gruppieren zu beschränken.

Das Beispiel lädt eine bestehende PPTX‑Präsentation, prüft die Shapes in der Shape‑Collection jeder Folie und speichert eine Kopie mit den angewendeten Einschränkungen. Shapes, die nicht zu den vier behandelten Typen gehören, bleiben unverändert. Die Schleife durchläuft nicht die Kind‑Shapes innerhalb einer Gruppe.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Schutz entfernen**

Um eine Shape‑Sperre zu entfernen, setzen Sie deren Wert auf `false`. Das folgende Beispiel lädt eine Präsentation mit Shape‑Sperren und leert die Auswahl‑, Bewegungs‑ und Größen‑Einschränkungen über [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) und [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Es entfernt außerdem die Gruppierungs‑Einschränkung, indem `false` an [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) übergeben wird, und speichert eine Kopie der Präsentation. Andere Sperreinstellungen bleiben unverändert.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Fazit**

Aspose.Slides for PHP via Java ermöglicht es, bestimmte Bearbeitungsoperationen für einzelne Shapes einzuschränken oder dieselben Einschränkungen über Folien hinweg anzuwenden. Wählen Sie die für den jeweiligen Shape‑Typ unterstützten Sperren aus und setzen Sie deren Werte auf `false`, wenn Sie diese Einschränkungen entfernen müssen.

## **FAQ**

**Kann ich Shape‑Sperren und Passwortschutz in derselben Präsentation kombinieren?**

Ja. Shape‑Sperren beschränken bestimmte Bearbeitungsoperationen, während [Passwortschutz](/slides/de/php-java/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Sie können beides in derselben Datei verwenden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Sperren nur auf die Shapes der ausgewählten Folien an. Dadurch werden die Sperreinstellungen auf anderen Folien nicht geändert.

**Wie kann ich Sperren auf einzelne Shapes innerhalb einer Gruppe anwenden?**

Iterieren Sie über die Sammlung, die die Methode [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) der Gruppe zurückgibt, und wenden Sie die entsprechenden Sperren auf jedes Kind‑Shape an. Wiederholen Sie dies für verschachtelte Gruppen. Die obigen Beispiele verarbeiten nur die Shape‑Collection der Folie, sodass keine Sperren für einzelne Gruppenmitglieder gesetzt werden.