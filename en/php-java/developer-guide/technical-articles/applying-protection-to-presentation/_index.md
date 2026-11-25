---
title: Restrict Presentation Edits with Shape Locks in PHP
linktitle: Restrict Presentation Edits
type: docs
weight: 60
url: /php-java/applying-protection-to-presentation/
keywords:
- prevent edits
- protect from editing
- lock shape
- lock position
- lock select
- lock resizing
- lock grouping
- PowerPoint
- PPTX
- presentation
- PHP
- Aspose.Slides
description: "Learn how to lock and unlock shapes in PPTX presentations with Aspose.Slides for PHP via Java to restrict selection, movement, resizing, and grouping."
---

## **Overview**

A common use for Aspose.Slides for PHP via Java is to create, update, and save PowerPoint (PPTX) presentations as part of an automated workflow. When users receive these presentations, restricting changes to shapes can help preserve the intended layout and content.

This article explains how shapes are organized on slides and how to apply and remove shape locks in a PPTX presentation. These locks let you restrict specific editing operations on individual shapes.

## **Composition of a Slide**

A presentation slide is composed of components such as autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors, and other elements used to build a presentation. In Aspose.Slides for PHP via Java, each element on a slide is represented by an object that inherits from the [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) class.

Different shape types expose different locking options. The [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) class is the base class for shape locks. Aspose.Slides for PHP via Java provides the following lock classes:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) locks autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) locks connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) locks graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) locks group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) locks picture frames.  

To apply locks across a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), iterate through its slides and set the appropriate locks on each supported shape.

## **Apply and Remove Protection**

Compatible presentation editors use shape locks to restrict individual editing operations. File encryption and document-level write protection are separate [presentation protection settings](/slides/php-java/password-protected-presentation/).

### **Apply Protection to PPTX Shapes**

Aspose.Slides for PHP via Java provides the [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) class to work with shapes on a slide.

The example calls [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked), and [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) with `true` for autoshapes, with equivalent locks for group shapes, connectors, and picture frames. Connectors use [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) for movement; groups also use [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) to restrict grouping.

The example loads an existing PPTX presentation, checks the shapes in each slide's shape collection, and saves a copy with these restrictions applied. Shapes outside the four handled types are left unchanged. The loop does not traverse the child shapes inside a group.

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

### **Remove Protection**

To remove a shape lock, set its value to `false`. The following example loads a presentation with shape locks and clears the selection, movement, and resizing restrictions through [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), and [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). It also removes the grouping restriction by passing `false` to [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) and saves a copy of the presentation. Other lock settings are left unchanged.

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

### **Preserve a Picture Crop**

Place a photo named `photo.jpg` in the working directory. The example crops 12% from the left and 8% from the right, then calls [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) on the picture frame's lock. Passing `true` restricts further cropping and preserves the existing crop.

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

`PictureLocked.pptx` stores the crop lock as `true`. In PowerPoint, the **Crop** command is disabled when the photo is selected.

### **Keep a Diagram Grouped**

The example groups a rectangle and an arrow, then calls [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) on the group's lock to keep the diagram's components together. Other edits, such as moving the group or changing a component's fill, remain available.

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

`DiagramLocked.pptx` stores the ungrouping lock as `true`. In PowerPoint, the **Ungroup** command is disabled when the whole diagram is selected.

### **Report Existing Shape Locks**

To review a template, open it and read the lock object for each shape. The [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) method returns `true` when all flags on that object are disabled and `false` when at least one is enabled. A group and its children have separate lock objects, so inspect the children even when the group has no locks.

This example checks movement for autoshapes, picture frames, and groups. It also checks cropping for pictures and ungrouping for groups. The report lists the enabled flags it recognizes and marks shape types it does not inspect.

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

Suppose slide 1 of `Sample.pptx` contains a group named `Layout` with ungrouping locked, a picture named `Photo` inside it with cropping locked, and an unlocked rectangle named `Free`. The report skips `Free` and prints these two lines:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

The report reads the stored shape-level editing flags without changing them or saving the presentation. Document-level write protection is a separate setting, and enforcement of each flag depends on the editor.

### **Conclusion**

Aspose.Slides for PHP via Java lets you restrict specific editing operations on individual shapes or apply the same restrictions across slides. Choose the locks supported by each shape type, and set their values to `false` when you need to remove those restrictions.

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

Yes. Shape locks restrict specific editing operations, while [password protection](/slides/php-java/password-protected-presentation/) can restrict opening or modifying the presentation. You can use both in the same file.

**Can I restrict editing on specific slides without affecting others?**

Yes. Apply locks only to shapes on the selected slides. This does not change the lock settings on other slides.

**How can I apply locks to individual shapes inside a group?**

Iterate through the collection returned by the group's [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) method and apply the appropriate locks to each child shape. Repeat this for any nested groups, following the traversal in the reporting example.

