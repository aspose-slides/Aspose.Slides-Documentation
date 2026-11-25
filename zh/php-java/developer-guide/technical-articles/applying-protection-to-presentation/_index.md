---
title: 使用形状锁在 PHP 中限制演示文稿编辑
linktitle: 限制演示文稿编辑
type: docs
weight: 60
url: /zh/php-java/applying-protection-to-presentation/
keywords:
- 防止编辑
- 防止更改
- 锁定形状
- 锁定位置
- 锁定选择
- 锁定大小调整
- 锁定分组
- PowerPoint
- PPTX
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PPTX 演示文稿中锁定和解锁形状，以限制选择、移动、大小调整和分组。"
---
## **概述**

Aspose.Slides for PHP via Java 的常见用例是作为自动化工作流的一部分创建、更新和保存 PowerPoint (PPTX) 演示文稿。当用户接收这些演示文稿时，限制对形状的更改可以帮助保留预期的布局和内容。

本文说明了形状在幻灯片上的组织方式以及如何在 PPTX 演示文稿中应用和移除形状锁。通过这些锁，您可以限制对单个形状的特定编辑操作。

## **幻灯片的组成**

演示文稿的幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及用于构建演示文稿的其他元素等组件组成。在 Aspose.Slides for PHP via Java 中，幻灯片上的每个元素都由继承自 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 类的对象表示。

不同的形状类型提供不同的锁定选项。[BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) 类是形状锁的基类。Aspose.Slides for PHP via Java 提供以下锁定类：

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) 锁定自动形状。  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) 锁定连接线形状。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) 锁定图形对象。  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) 锁定组合形状。  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) 锁定图片框。  

要在整个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 中应用锁定，遍历其幻灯片并对每个受支持的形状设置相应的锁定。

## **应用和移除保护**

兼容的演示文稿编辑器使用形状锁来限制单独的编辑操作。文件加密和文档级写保护是单独的 [演示文稿保护设置](/slides/zh/php-java/password-protected-presentation/)。

### **对 PPTX 形状应用保护**

Aspose.Slides for PHP via Java 提供了用于处理幻灯片上形状的 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 类。

示例使用 `true` 调用 [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) 和 [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) 来锁定自动形状，对组合形状、连接线和图片框使用等效的锁定。连接线使用 [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) 来限制移动；组合形状也使用 [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) 来限制分组。

示例加载现有的 PPTX 演示文稿，检查每个幻灯片的形状集合中的形状，并保存一个应用了这些限制的副本。四种处理类型之外的形状保持不变。循环不会遍历组内的子形状。

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

### **移除保护**

要移除形状锁，只需将其值设为 `false`。以下示例加载一个带有形状锁的演示文稿，并通过 [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) 和 [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) 清除选择、移动和大小调整限制。它还通过将 `false` 传递给 [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) 移除分组限制，并保存演示文稿的副本。其他锁定设置保持不变。

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

### **保留图片裁剪**

将名为 `photo.jpg` 的照片放在工作目录中。示例从左侧裁剪 12%，右侧裁剪 8%，然后对图片框的锁调用 [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked)。传入 `true` 可限制后续裁剪并保留现有裁剪。

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

`PictureLocked.pptx` 将裁剪锁存为 `true`。在 PowerPoint 中，选中照片时 **Crop** 命令被禁用。

### **保持图表分组**

示例将一个矩形和一条箭头组合，然后对组的锁调用 [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) 以保持图表组件在一起。其他编辑操作，如移动组合或更改组件的填充，仍然可用。

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

`DiagramLocked.pptx` 将取消分组锁存为 `true`。在 PowerPoint 中，选中整个图表时 **Ungroup** 命令被禁用。

### **报告现有形状锁**

要审查模板，打开它并读取每个形状的锁对象。[getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) 方法在该对象的所有标志均被禁用时返回 `true`，只要至少有一个标志被启用就返回 `false`。组合及其子形状拥有各自的锁对象，因此即使组合本身没有锁，也要检查其子形状。

此示例检查自动形状、图片框和组合的移动。它还检查图片的裁剪以及组合的取消分组。报告列出它能识别的已启用标志，并标记未检查的形状类型。

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

假设 `Sample.pptx` 的第 1 张幻灯片包含一个名为 `Layout`、已锁定取消分组的组合，一个内部名为 `Photo`、已锁定裁剪的图片，以及一个未锁定的矩形 `Free`。报告会跳过 `Free`，并输出以下两行：

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

报告读取存储的形状级编辑标志而不更改它们或保存演示文稿。文档级写保护是单独的设置，每个标志的强制执行取决于编辑器。

### **结论**

Aspose.Slides for PHP via Java 让您可以限制单个形状的特定编辑操作，或在整套幻灯片中应用相同的限制。选择每种形状类型支持的锁，并在需要移除限制时将其值设为 `false`。

## **常见问题**

**我可以在同一演示文稿中同时使用形状锁和密码保护吗？**

是的。形状锁限制特定的编辑操作，而 [密码保护](/slides/zh/php-java/password-protected-presentation/) 可以限制打开或修改演示文稿。您可以在同一个文件中同时使用两者。

**我可以仅在特定幻灯片上限制编辑而不影响其他幻灯片吗？**

可以。仅对所选幻灯片上的形状应用锁定。这不会更改其他幻灯片的锁定设置。

**如何对组内的单个形状应用锁定？**

遍历组的 [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) 方法返回的集合，对每个子形状应用相应的锁定。对任何嵌套组重复此操作，遵循报告示例中的遍历方式。