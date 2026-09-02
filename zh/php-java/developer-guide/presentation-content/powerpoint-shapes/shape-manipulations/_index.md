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
- 形状调整点
- 预设形状调整
- 形状几何
- 形状布局格式
- 形状为 SVG
- 将形状导出为 SVG
- 对齐形状
- 翻转形状
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for PHP via Java 识别、调整、克隆、删除、隐藏、重新排序、导出、对齐和翻转演示文稿中的形状。"
---
## **概述**

Aspose.Slides for PHP via Java 将幻灯片上的形状表示为有序的 [ShapeCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/)。该集合既是查找和修改形状的地方，也是它们堆叠顺序的来源：索引 `0` 是最靠后的形状，而最后一个索引是最前面的形状。

本文遵循该模型。首先说明如何可靠地识别形状并修改预设形状的调整点，然后展示如何克隆、删除、隐藏和重新排序形状。最后的章节覆盖布局级格式设置、SVG 导出、对齐和翻转设置。每个示例都是独立的，您可以只使用工作流所需的操作。

## **识别和查找形状**

在处理已知文件时，集合索引很方便，但它们不是稳定的标识符。添加、删除或重新排序形状都会改变其索引。根据演示文稿的创建和维护方式选择标识符：

- [Name](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getname/) 对于开发者控制的模板很有用，并且可以在 PowerPoint 的“选择窗格”中查看。名称可以编辑，但不保证唯一，如果代码依赖名称，需要制定命名约定。
- [AlternativeText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getalternativetext/) 在已有可访问性描述或作者提供的标签已经标识形状时很有用。它对用户可见，可能会本地化或为可访问性重写，但也不保证唯一。不要将有意义的可访问性文本悄悄用作数据库键。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getofficeinteropshapeid/) 是只读标识符，在同一幻灯片内唯一，映射到 PowerPoint 互操作使用的形状 ID。将其用于与 PowerPoint 集成或在形状生命周期内需要明确引用的场景。克隆或重新创建的形状是不同的形状，会获得自己的 ID。

相关的 [Shape::getUniqueId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getuniqueid/) 方法返回演示文稿范围的标识符，但该标识符面向插件，可能会被重新分配，不应视为永久的外部键。如果长期身份至关重要，请在应用程序数据中维护映射并验证预期形状仍然存在。

下面的示例使用精确比较按名称搜索，并报告幻灯片范围的互操作 ID。当模板不包含预期形状时，代码会报告该结果而不是继续使用错误对象。

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

当操作特定于某种形状类型时，在使用类型特定成员之前检查运行时类。此示例仅在命名对象是 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/) 时更新文本和替代文本。

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

## **识别和修改预设形状调整**

预设几何形状可能公开控制角大小、箭头比例或弧度等特性的调整点。通过只读的 [GeometryShape::getAdjustments](https://reference.aspose.com/slides/zh/php-java/aspose.slides/geometryshape/#getAdjustments) 集合访问它们。该集合由形状提供，但每个 [AdjustValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/adjustvalue/) 包含可更改的值。

不要仅依赖固定的集合索引。遍历调整项并检查只读的 [AdjustValue::getType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/adjustvalue/#getType) 方法，其 [ShapeAdjustmentType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapeadjustmenttype/) 值描述了该调整控制的内容。只读的 [AdjustValue::getName](https://reference.aspose.com/slides/zh/php-java/aspose.slides/adjustvalue/getname/) 方法提供额外的识别信息，尤其在预设包含多个相同语义类型的调整时非常有用。

使用与调整意义相匹配的值方法：

| 调整类型 | 用途 | 要更改的值 |
|---|---|---|
| `CornerSize` | 圆角大小 | [setRawValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | 箭尾粗细 | `setRawValue` |
| `ArrowheadLength` | 箭头长度 | `setRawValue` |
| `ArrowheadWidth` | 箭头宽度 | `setRawValue` |
| `StartAngle` | 饼图或弧线的起始角度 | [setAngleValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | 饼图或弧线的结束角度 | `setAngleValue` |

`getType` 和 `getName` 返回只读信息。`getRawValue` 与 `setRawValue` 使用预设本身的几何单位的整数，而 `getAngleValue` 与 `setAngleValue` 使用角度（度）。调整的数量、顺序、含义以及有效范围取决于预设的 [GeometryShape::getShapeType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/geometryshape/#getShapeType)。对一种预设有效的值可能对另一种预设无效或产生不同效果。

当 `getType` 返回 `ShapeAdjustmentType::Custom` 时，API 未识别标准语义。检查 `getName`、预设类型和现有值，除非已知预期意义和范围，否则保持调整不变。即使是已识别的类型，也要检查同一类型是否出现多次后再选择值。[Connector](/slides/zh/php-java/connector/) 文章展示了连接器弯曲调整的此类情况。

下面的完整示例创建了三个预设形状的默认和修改版本。它遍历每个调整，报告其名称和类型，通过 `setRawValue` 更改尺寸相关值，通过 `setAngleValue` 更改角度，并保存结果。左列保留默认几何，右列显示调整后的圆角矩形、四向箭头和饼图。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 为默认和调整后的形状列添加标题。
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在更改值之前检查语义类型，使代码对意图更加明确，避免假设特定集合索引在不同预设形状中具有相同含义。

## **修改形状集合**

添加、克隆、删除和重新排序方法会立即作用于集合。如果某个操作改变了形状的数量或顺序，请不要继续依赖该操作前捕获的索引。

### **克隆形状**

[ShapeCollection::addClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addclone/) 创建一个独立副本并将其追加到目标集合。[ShapeCollection::insertClone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/insertclone/) 也会创建副本，但将其放置在指定的 z 顺序索引。接受坐标的重载在不改变大小的情况下移动克隆；接受宽度和高度的重载还能对其进行缩放。

示例创建目标幻灯片，将标记矩形克隆到前面，并在后面插入第二个克隆。对任一克隆的更改都不会影响源形状。

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

克隆会复制形状的内容和格式，包括名称和替代文本。当这些值必须唯一时，请为克隆分配新的逻辑标识符。复杂形状使用的资源由演示文稿管理，但克隆仍然是具有新形状标识的新集合项。

### **删除形状**

[ShapeCollection::remove](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/remove/) 从其集合中删除特定形状对象。在索引遍历期间删除多个匹配项时，请从末尾向前遍历，以保持每个剩余索引仍然有效。

此示例删除所有具有指定名称的形状。它读取当前索引处的形状，而不是固定的集合项，并且不会不必要地进行类型转换。

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

删除后，形状计数以及后续形状的索引会改变。对未受影响的形状的引用比保存的索引更可靠。还需考虑连接器、动画及其他可能引用被删除对象的演示文稿特性；删除可见形状可能会改变幻灯片外观以外的内容。

### **隐藏形状**

将 [Shape::setHidden](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/sethidden/) 设置为 `true` 可保留形状在集合中，但阻止其在普通幻灯片放映中出现。其索引、格式和内容仍可供代码使用，因此隐藏适用于可能稍后恢复的可选元素。

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

隐藏并非删除或安全措施。用户或代码仍可发现并取消隐藏该对象，它仍然是演示文稿文件的一部分。

### **更改 Z 顺序**

重叠的形状按照集合顺序绘制。[ShapeCollection::reorder](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/reorder/) 将现有形状移动到目标索引而不克隆。索引 `0` 为最底层；`size() - 1` 为最前层。

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

矩形最先创建，最初位于椭圆之后。将其移动到最终索引后会位于前面。添加或克隆所有相关形状后再确定 Z 顺序，因为这些操作会追加或插入新集合项，从而改变预期的堆叠。

## **检查布局幻灯片上的形状**

普通幻灯片、布局幻灯片和母版幻灯片拥有各自独立的形状集合。布局集合中的形状并非普通幻灯片上同位置形状的同一对象。需要了解或更改布局提供的格式时，请检查布局形状。

下面的示例读取每个布局形状的 [FillFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getfillformat/) 和 [LineFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/getlineformat/)，而不假设每个形状都是 `AutoShape`。

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

编辑布局会影响使用该布局的多个幻灯片。更改布局形状前，先确定普通幻灯片是继承该对象还是包含本地覆盖，并测试所有使用该布局的幻灯片。

## **将形状导出为 SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/writeassvg/) 将单个形状的渲染内容写入流。结果仅包含该形状，不包括整个幻灯片背景或相邻形状。

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

渲染时保持演示文稿打开。输出受形状格式以及字体、图像等资源的影响。如果需要完整的组合，请导出整张幻灯片而不是单个形状。调用方拥有流的所有权并必须关闭它。

## **对齐形状**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideutil/alignshapes/) 的重载可对全部形状或选定的集合索引进行对齐。[ShapesAlignmentType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapesalignmenttype/) 指定对齐的边缘、中心线或分布模式。将 `alignToSlide` 设置为 `true` 使用幻灯片边缘；设置为 `false` 则相对于选定形状进行对齐。

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

对齐会改变位置，而不是 Z 顺序。相对对齐通常至少需要两个形状，而水平或垂直分布则需要足够的形状来定义间距。如果在调用方法前修改了集合，请重新计算索引。

## **翻转形状**

[ShapeFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapeframe/) 类存储位置、大小、水平和垂直翻转设置以及旋转。其 `getFlipH` 和 `getFlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh/php-java/aspose.slides/nullablebool/)：`True` 启用翻转，`False` 禁用，`NotDefined` 保持未指定/默认状态。

下方的输入演示文稿包含一个未翻转的形状。

![翻转前的形状](shape_to_be_flipped.png)

示例保留其他所有帧值，仅替换两个翻转设置。这一点很重要，因为为形状分配新的 [Frame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/setframe/) 会替换完整的帧。

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

保存后的形状在水平和垂直方向上均为镜像，同时保持位置、大小和旋转不变。

![翻转后的形状](flipped_shape.png)

## **常见问题解答**

**我应该使用集合索引作为形状标识符吗？**

仅在短期处理且集合在使用索引前不会改变的情况下使用。对经过编写的模板推荐使用经过验证的 `Name` 或 `AlternativeText` 约定，对幻灯片范围的互操作工作使用 `OfficeInteropShapeId`。

**隐藏形状会从 Z 顺序中移除吗？**

不会。隐藏的形状仍保留在集合中，索引不变。它仍可被发现、重新排序、编辑或再次显示。

**为何克隆的形状出现在另一形状前面？**

`addClone` 将克隆追加到集合末尾，即 Z 顺序的前面。使用 `insertClone` 可指定初始索引，或在所有形状添加完毕后使用 `reorder`。

**我可以使用固定索引来标识预设形状的调整吗？**

只能在确认确切预设和集合布局后使用。更推荐遍历 `GeometryShape::getAdjustments` 并检查 `AdjustValue::getType`；当同一语义类型出现多次时，使用 `AdjustValue::getName` 作为补充信息。