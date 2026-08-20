---
title: 在 PHP 中管理演示文稿形状
linktitle: 形状操作
type: docs
weight: 40
url: /zh/php-java/shape-manipulations/
keywords:
- PowerPoint 形状
- 演示文稿形状
- 幻灯片上的形状
- 查找形状
- 克隆形状
- 删除形状
- 隐藏形状
- 更改形状顺序
- 获取互操作形状 ID
- 形状替代文本
- 形状布局格式
- 形状为 SVG
- 形状转 SVG
- 对齐形状
- 翻转形状
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 识别、克隆、删除、隐藏、重新排序、导出、对齐和翻转演示文稿形状。"
---
## **概述**

Aspose.Slides for PHP via Java 将幻灯片上的形状表示为有序的 [ShapeCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/)。该集合既是查找和修改形状的地方，也是它们堆叠顺序的来源：索引 `0` 为最靠后（最底层）的形状，最后一个索引为最靠前（最顶层）的形状。

本文遵循该模型。首先解释如何可靠地识别形状，然后展示如何克隆、删除、隐藏和重新排序形状。最后的章节覆盖布局级别的格式化、SVG 导出、对齐和翻转设置。每个示例都是独立的，您可以仅使用工作流所需的操作。

## **识别和查找形状**

在处理已知文件时，集合索引很方便，但它们不是稳定的标识符。添加、删除或重新排序形状都会改变其索引。请根据演示文稿的编写和维护方式选择标识符：

- [Name](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getname/) 对于受开发者控制的模板很有用，并且可以在 PowerPoint 的“选择窗格”中轻松检查。名称可以编辑，但不保证唯一，因此如果代码依赖名称，请建立命名约定。
- [AlternativeText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getalternativetext/) 当可访问性描述或作者提供的标签已经标识形状时很有用。它对用户可见，可能会本地化或为可访问性重写，且不保证唯一。不要在不知情的情况下将有意义的可访问性文本作为数据库键。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getofficeinteropshapeid/) 是只读标识符，在幻灯片内唯一，对应 PowerPoint 互操作使用的形状 ID。需要在 PowerPoint 集成或在形状生命周期内需要明确引用时使用。克隆或重新创建的形状是不同的形状，会获得自己的 ID。

相关的 [Shape::getUniqueId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getuniqueid/) 方法返回演示文稿范围内的标识符，但该标识符用于加载项，可能会被重新分配。它不应被视为永久的外部键。如果长期身份至关重要，请在应用程序数据中保持映射并验证预期的形状仍然存在。

以下示例使用精确比较按名称搜索，并报告幻灯片范围的互操作 ID。当模板不包含预期形状时，代码会报告该结果而不是继续使用错误对象。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

当操作特定于某种形状类型时，请在使用特定成员之前检查运行时类。此示例仅在命名对象是 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/) 时更新文本和替代文本。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **修改形状集合**

add、clone、remove 和 reorder 方法会立即作用于集合。如果操作改变了形状的数量或顺序，请勿继续依赖操作前捕获的索引。

### **克隆形状**

[ShapeCollection::addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addclone/) 创建一个独立的副本并将其追加到目标集合。[ShapeCollection::insertClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/insertclone/) 也创建副本，但将其放置在指定的 Z 顺序索引处。接受坐标的重载在不改变大小的情况下移动克隆；接受宽度和高度的重载还可以对其进行缩放。

示例创建目标幻灯片，将带标签的矩形克隆到前面，并在后面插入第二个克隆。对任一克隆的更改都不会修改源形状。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

克隆会复制形状的内容和格式，包括名称和替代文本。当这些值必须唯一时，请为克隆分配新的逻辑标识符。复杂形状使用的资源由演示文稿处理，但克隆仍是具有新形状标识的新集合项。

### **删除形状**

[ShapeCollection::remove](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/remove/) 从其集合中删除特定形状对象。在索引迭代期间删除多个匹配项时，请从末尾向前遍历，以确保每个剩余索引仍然有效。

此示例删除所有具有指定名称的形状。它读取当前索引处的形状，而不是固定的集合项，并且没有不必要地强制转换形状。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

删除后，形状计数以及后续形状的索引会改变。对未受影响形状的引用比保存的索引更可靠。还需考虑连接器、动画以及其他可能引用已删除对象的演示文稿特性；删除可见形状可能会改变幻灯片的不止外观。

### **隐藏形状**

将 [Shape::setHidden](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/sethidden/) 设置为 `true` 会保留形状在集合中，但阻止其在普通幻灯片放映中出现。其索引、格式和内容仍可供代码使用，因此隐藏适用于可能稍后恢复的可选元素。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

隐藏不是删除或安全措施。对象仍可以被用户或代码发现并取消隐藏，并且仍是演示文稿文件的一部分。

### **更改 Z 顺序**

重叠的形状按集合顺序绘制。[ShapeCollection::reorder](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/reorder/) 将现有形状移动到目标索引而不进行克隆。索引 `0` 为后面；`size() - 1` 为前面。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

矩形最先创建，最初位于椭圆之后。将其移动到最终索引后会出现在前面。添加或克隆所有相关形状后再确定 Z 顺序，因为这些操作会追加或插入新集合项，从而改变预期的堆叠。

## **检查布局幻灯片上的形状**

普通幻灯片、布局幻灯片和母版幻灯片拥有各自的形状集合。布局集合中的形状并不是普通幻灯片上同位置形状的同一对象。需要了解或更改布局提供的格式时，请检查布局形状。

以下示例读取每个布局形状的 [FillFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getfillformat/) 和 [LineFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getlineformat/)，并未假设每个形状都是 `AutoShape`。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

编辑布局可能会影响使用该布局的多个幻灯片。在更改布局形状之前，确定普通幻灯片是继承该对象还是包含本地覆盖，并测试所有使用该布局的幻灯片。

## **将形状导出为 SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/writeassvg/) 将单个形状的渲染内容写入流。结果只包含该形状，不包含整张幻灯片的背景或相邻形状。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

渲染时保持演示文稿打开。输出取决于形状的格式以及字体、图像等资源。如果需要整个组合，请导出幻灯片而不是单个形状。调用方拥有该流并必须关闭它。

## **对齐形状**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideutil/alignshapes/) 的重载可以对齐所有形状或选定的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapesalignmenttype/) 指定边缘、中心线或分布模式。将 `alignToSlide` 设置为 `true` 使用幻灯片边缘；设置为 `false` 则相对于选定形状进行对齐。

此示例将三个形状对齐到幻灯片的顶部边缘。返回的形状引用在对齐前立即转换为当前索引。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

对齐会改变位置，而不是 Z 顺序。相对对齐通常需要至少两个形状，而水平或垂直分布则需要足够的形状来定义间距。如果在调用方法前修改了集合，请重新计算索引。

## **翻转形状**

[ShapeFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapeframe/) 类存储位置、大小、水平和垂直翻转设置以及旋转。其 `getFlipH` 和 `getFlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh/php-java/aspose.slides/nullablebool/)：`True` 启用翻转，`False` 禁用，`NotDefined` 保持未指定/默认状态。

下面的输入演示文稿包含一个未翻转的形状。

![翻转前的形状](shape_to_be_flipped.png)

示例保留其他所有帧值，仅替换两个翻转设置。这一点很重要，因为为 [Frame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/setframe/) 赋新值会替换完整帧。

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

保存的形状在保持位置、大小和旋转的同时实现水平和垂直镜像。

![翻转后的形状](flipped_shape.png)

## **常见问题解答**

**是否应该使用集合索引作为形状标识符？**

仅在短期处理且集合在使用索引前不会改变的情况下使用。对作者模板优先使用经过验证的 `Name` 或 `AlternativeText` 约定，对幻灯片范围的互操作工作使用 `OfficeInteropShapeId`。

**隐藏形状会从 Z 顺序中移除吗？**

不会。隐藏的形状仍保留在集合中且索引不变。它仍然可以被查找、重新排序、编辑或再次显示。

**为什么克隆的形状会出现在另一个形状前面？**

`addClone` 将克隆追加到集合末尾，即 Z 顺序的前面。使用 `insertClone` 可以选择初始索引，或在所有形状添加后使用 `reorder` 调整顺序。