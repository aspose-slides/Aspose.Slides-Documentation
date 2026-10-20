---
title: 在 PHP 中使用形状锁限制演示文稿编辑
linktitle: 限制演示文稿编辑
type: docs
weight: 60
url: /zh/php-java/applying-protection-to-presentation/
keywords:
- 防止编辑
- 保护免受编辑
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
## **概览**

Aspose.Slides for PHP via Java 的常见用途是创建、更新和保存 PowerPoint (PPTX) 演示文稿，作为自动化工作流的一部分。当用户收到这些演示文稿时，限制对形状的更改可以帮助保留原有的布局和内容。

本文说明了形状在幻灯片上的组织方式以及如何在 PPTX 演示文稿中应用和移除形状锁定。这些锁定允许您限制对单个形状的特定编辑操作。

## **幻灯片的组成**

演示文稿的幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及用于构建演示文稿的其他元素等组件组成。在 Aspose.Slides for PHP via Java 中，幻灯片上的每个元素都由继承自 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 类的对象表示。

不同的形状类型提供不同的锁定选项。[BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) 类是形状锁定的基类。Aspose.Slides for PHP via Java 提供以下锁定类：

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) 锁定自动形状。  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) 锁定连接线形状。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) 锁定图形对象。  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) 锁定组合形状。  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) 锁定图片框。  

要在整个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 上应用锁定，遍历其幻灯片并对每个受支持的形状设置相应的锁定。

## **应用和移除保护**

形状锁定限制诸如选择、移动和调整大小等操作。它们并不会使整个演示文稿不可编辑。

### **对 PPTX 形状应用保护**

Aspose.Slides for PHP via Java 提供 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 类，用于处理幻灯片上的形状。

示例对自动形状调用 [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) 和 [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) 并传入 `true`，对组合形状、连接线和图片框使用等效的锁定。连接线使用 [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) 来控制移动；组合形状还使用 [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) 来限制分组。

示例加载已有的 PPTX 演示文稿，检查每个幻灯片的形状集合中的形状，并保存一个已应用这些限制的副本。四种处理类型之外的形状保持不变。循环不会遍历组内部的子形状。

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

要移除形状锁定，只需将其值设为 `false`。下面的示例加载一个带有形状锁定的演示文稿，并通过 [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) 和 [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) 清除选择、移动和调整大小的限制。它还通过将 `false` 传递给 [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) 来移除分组限制，并保存演示文稿的副本。其他锁定设置保持不变。

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

### **结论**

Aspose.Slides for PHP via Java 允许您对单个形状限制特定的编辑操作，或在所有幻灯片上应用相同的限制。请选择每种形状类型支持的锁定，并在需要移除这些限制时将其值设为 `false`。

## **常见问题**

**我可以在同一个演示文稿中同时使用形状锁定和密码保护吗？**

可以。形状锁定限制特定的编辑操作，而 [密码保护](/slides/zh/php-java/password-protected-presentation/) 可以限制演示文稿的打开或修改。您可以在同一个文件中同时使用两者。

**我可以仅在特定幻灯片上限制编辑而不影响其他幻灯片吗？**

可以。仅在选中的幻灯片上的形状应用锁定。这不会改变其他幻灯片的锁定设置。

**如何对组内的单个形状应用锁定？**

遍历组的 [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) 方法返回的集合，并对每个子形状应用相应的锁定。对任何嵌套组重复此操作。上述示例仅处理幻灯片的形状集合，因此未对组内的单个成员设置锁定。