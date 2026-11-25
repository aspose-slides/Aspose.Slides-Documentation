---
title: Einschränken von Präsentationsbearbeitungen mit Form-Sperren in PHP
linktitle: Einschränken von Präsentationsbearbeitungen
type: docs
weight: 60
url: /de/php-java/applying-protection-to-presentation/
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
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen in PPTX-Präsentationen mit Aspose.Slides for PHP via Java sperren und entsperren, um Auswahl, Bewegung, Größenänderung und Gruppierung zu beschränken."
---
## **Übersicht**

Ein häufiger Anwendungsfall von Aspose.Slides for PHP via Java besteht darin, PowerPoint‑Präsentationen (PPTX) zu erstellen, zu aktualisieren und zu speichern, als Teil eines automatisierten Workflows. Wenn Benutzer diese Präsentationen erhalten, kann das Einschränken von Änderungen an Formen helfen, das beabsichtigte Layout und den Inhalt beizubehalten.

Dieser Artikel erklärt, wie Formen auf Folien organisiert sind und wie Form‑Sperren in einer PPTX‑Präsentation angewendet und entfernt werden. Diese Sperren ermöglichen es, bestimmte Bearbeitungsoperationen für einzelne Formen zu beschränken.

## **Aufbau einer Folie**

Eine Präsentationsfolie besteht aus Komponenten wie Autoformen, Tabellen, OLE‑Objekten, gruppierten Formen, Bildrahmen, Video‑Frames, Verbindern und anderen Elementen, die zum Erstellen einer Präsentation verwendet werden. In Aspose.Slides for PHP via Java wird jedes Element einer Folie durch ein Objekt dargestellt, das von der Klasse [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) erbt.

Verschiedene Formtypen bieten unterschiedliche Sperroptionen. Die Klasse [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) ist die Basisklasse für Form‑Sperren. Aspose.Slides for PHP via Java stellt die folgenden Sperrklassen bereit:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) sperrt Autoformen.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) sperrt Connector‑Formen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) sperrt grafische Objekte.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) sperrt Gruppenformen.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) sperrt Bildrahmen.  

Um Sperren für eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) anzuwenden, durchlaufen Sie ihre Folien und setzen die entsprechenden Sperren für jede unterstützte Form.

## **Schutz anwenden und entfernen**

Kompatible Präsentationseditoren verwenden Form‑Sperren, um einzelne Bearbeitungsoperationen einzuschränken. Dateiverschlüsselung und schreibgeschützte Dokumentebene sind separate [Kennwortschutz](/slides/de/php-java/password-protected-presentation/).

### **Schutz auf PPTX‑Formen anwenden**

Aspose.Slides for PHP via Java stellt die Klasse [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) bereit, um mit Formen auf einer Folie zu arbeiten.

Das Beispiel ruft [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) und [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) mit `true` für Autoformen auf, sowie entsprechende Sperren für Gruppenformen, Verbinder und Bildrahmen. Verbinder verwenden [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) für Bewegungen; Gruppen verwenden zudem [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked), um das Gruppieren zu beschränken.

Das Beispiel lädt eine vorhandene PPTX‑Präsentation, prüft die Formen in der Form‑Sammlung jeder Folie und speichert eine Kopie mit den angewendeten Einschränkungen. Formen außerhalb der vier behandelten Typen bleiben unverändert. Die Schleife durchläuft nicht die Kindformen innerhalb einer Gruppe.

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

Um eine Form‑Sperre zu entfernen, setzen Sie ihren Wert auf `false`. Das folgende Beispiel lädt eine Präsentation mit Form‑Sperren und löst die Auswahl‑, Bewegungs‑ und Größenänderungs‑Einschränkungen über [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) und [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) auf. Es entfernt außerdem die Gruppierungs‑Einschränkung, indem `false` an [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) übergeben wird, und speichert eine Kopie der Präsentation. Andere Sperreinstellungen bleiben unverändert.

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

### **Bildzuschnitt beibehalten**

Legen Sie ein Foto mit dem Namen `photo.jpg` im Arbeitsverzeichnis ab. Das Beispiel schneidet 12 % von links und 8 % von rechts zu und ruft dann [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) auf der Sperre des Bildrahmens auf. Die Übergabe von `true` beschränkt weitere Zuschnitte und bewahrt den vorhandenen Zuschnitt.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` speichert die Zuschnitt‑Sperre als `true`. In PowerPoint ist der Befehl **Zuschneiden** deaktiviert, wenn das Foto ausgewählt ist.

### **Diagramm gruppiert halten**

Das Beispiel gruppiert ein Rechteck und einen Pfeil und ruft dann [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) auf der Sperre der Gruppe auf, um die Komponenten des Diagramms zusammenzuhalten. Andere Bearbeitungen, wie das Verschieben der Gruppe oder das Ändern der Füllung einer Komponente, bleiben verfügbar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` speichert die Entgruppierungs‑Sperre als `true`. In PowerPoint ist der Befehl **Ungroup** deaktiviert, wenn das gesamte Diagramm ausgewählt ist.

### **Vorhandene Form‑Sperren melden**

Um eine Vorlage zu prüfen, öffnen Sie sie und lesen das Sperrobjekt jeder Form aus. Die Methode [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) gibt `true` zurück, wenn alle Flags dieses Objekts deaktiviert sind, und `false`, wenn mindestens eines aktiviert ist. Eine Gruppe und ihre Kinder besitzen separate Sperrobjekte, daher sollten Sie die Kinder untersuchen, selbst wenn die Gruppe keine Sperren hat.

Dieses Beispiel prüft die Bewegung für Autoformen, Bildrahmen und Gruppen. Es prüft zudem den Zuschnitt für Bilder und die Entgruppierung für Gruppen. Der Bericht listet die aktivierten Flags auf, die er erkennt, und markiert Formtypen, die nicht untersucht werden.

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

Angenommen, Folie 1 von `Sample.pptx` enthält eine Gruppe mit dem Namen `Layout`, bei der die Entgruppierung gesperrt ist, ein Bild mit dem Namen `Photo` darin, bei dem der Zuschnitt gesperrt ist, und ein nicht gesperrtes Rechteck mit dem Namen `Free`. Der Bericht überspringt `Free` und gibt diese beiden Zeilen aus:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Der Bericht liest die gespeicherten bearbeitungsbezogenen Form‑Flags, ohne sie zu ändern oder die Präsentation zu speichern. Der schreibgeschützte Dokumentschutz ist eine separate Einstellung, und die Durchsetzung jedes Flags hängt vom Editor ab.

### **Fazit**

Aspose.Slides for PHP via Java ermöglicht es, bestimmte Bearbeitungsoperationen für einzelne Formen einzuschränken oder dieselben Einschränkungen über Folien hinweg anzuwenden. Wählen Sie die für jeden Formtyp unterstützten Sperren und setzen Sie deren Werte auf `false`, wenn Sie diese Einschränkungen entfernen möchten.

## **FAQ**

**Kann ich Form‑Sperren und Kennwortschutz in derselben Präsentation kombinieren?**

Ja. Form‑Sperren beschränken bestimmte Bearbeitungsoperationen, während [Kennwortschutz](/slides/de/php-java/password-protected-presentation/) das Öffnen oder Ändern der Präsentation einschränken kann. Sie können beide in derselben Datei verwenden.

**Kann ich die Bearbeitung auf bestimmten Folien einschränken, ohne andere zu beeinflussen?**

Ja. Wenden Sie Sperren nur auf die Formen der ausgewählten Folien an. Dadurch werden die Sperreinstellungen anderer Folien nicht geändert.

**Wie kann ich Sperren auf einzelne Formen innerhalb einer Gruppe anwenden?**

Durchlaufen Sie die Sammlung, die von der Methode [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) der Gruppe zurückgegeben wird, und wenden Sie die entsprechenden Sperren auf jede Kindform an. Wiederholen Sie dies für verschachtelte Gruppen, wobei Sie der Traversierung im Bericht‑Beispiel folgen.