---
title: 管理 Java 中的演示文稿形状
linktitle: 形状操作
type: docs
weight: 40
url: /zh/java/shape-manipulations/
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
- 形状转 SVG
- 对齐形状
- 翻转形状
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 识别、调整、克隆、删除、隐藏、重新排序、导出、对齐和翻转演示文稿中的形状。"
---
## **概述**

Aspose.Slides for Java 将幻灯片上的形状表示为有序的 [IShapeCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapecollection/)。该集合既是查找和修改形状的地点，也是它们堆叠顺序的来源：索引 `0` 为最底层形状，最后一个索引为最前层形状。

本文遵循该模型。首先解释如何可靠地识别形状并修改预设的形状调整点，然后展示如何克隆、删除、隐藏和重新排序形状。最后的章节涉及布局级别的格式化、SVG 导出、对齐以及翻转设置。每个示例都是独立的，您可以仅使用工作流所需的操作。

## **识别并查找形状**

在处理已知文件时，集合索引很方便，但它们不是稳定的标识符。添加、删除或重新排序形状都会改变其索引。请根据演示文稿的创建和维护方式选择标识符：

- [Name](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getName--) 对于受开发者控制的模板有用，并且可以在 PowerPoint 的“选择窗格”中轻松检查。名称可以编辑，但不保证唯一，因此如果代码依赖名称，请制定命名约定。
- [AlternativeText](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getAlternativeText--) 在已有可访问性描述或作者提供的标签已经标识形状时有用。该文本对用户可见，可能会本地化或为可访问性重写，且不保证唯一。不要在不知情的情况下将有意义的可访问性文本用作数据库键。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) 是只读标识符，在同一幻灯片内唯一，对应 PowerPoint 互操作使用的形状 ID。将其用于与 PowerPoint 集成或在形状生命周期内需要明确引用的场景。克隆或重新创建的形状是不同的形状，会获得自己的 ID。

相关的 [getUniqueId](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getUniqueId--) 方法返回演示文稿范围的标识符，但该标识符面向插件，可能会被重新分配，不应视为永久的外部键。如果长期身份至关重要，请在应用程序数据中保持映射并验证预期形状仍然存在。

下面的示例使用精确比较按名称搜索，并报告幻灯片范围的互操作 ID。当模板不包含预期形状时，代码会报告该结果而不是继续使用错误对象。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

当操作特定于形状类型时，请在使用类型特定成员前检查接口。此示例仅在命名对象是 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/) 时更新文本和替代文本。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **识别并修改预设形状调整**

预设几何形状可以公开用于控制角大小、箭头比例或弧度等特性的调整点。通过只读的 [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/zh/java/com.aspose.slides/igeometryshape/#getAdjustments--) 集合访问它们。集合本身由形状提供，但每个 [IAdjustValue](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iadjustvalue/) 包含可更改的值。

不要仅依赖固定的集合索引。遍历所有调整并检查只读的 [getType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iadjustvalue/#getType--) 方法，其返回的 [ShapeAdjustmentType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shapeadjustmenttype/) 值描述该调整控制的内容。只读的 [getName](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iadjustvalue/#getName--) 方法提供额外的识别信息，尤其在同一预设包含多个相同语义类型的调整时非常有用。

使用与调整含义匹配的值方法：

| 调整类型 | 用途 | 要更改的值 |
|---|---|---|
| `CornerSize` | 圆角的大小 | [setRawValue](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | 箭尾的厚度 | `setRawValue` |
| `ArrowheadLength` | 箭头的长度 | `setRawValue` |
| `ArrowheadWidth` | 箭头的宽度 | `setRawValue` |
| `StartAngle` | 饼图或弧线的起始角度 | [setAngleValue](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | 饼图或弧线的结束角度 | `setAngleValue` |

`getType` 和 `getName` 返回只读信息。`getRawValue` 和 `setRawValue` 使用预设本身的几何单位的整数，而 `getAngleValue` 与 `setAngleValue` 使用度数。调整的数量、顺序、含义以及有效范围取决于预设的 [ShapeType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/igeometryshape/#getShapeType--)。对一种预设有效的值在另一种预设中可能无效或产生不同效果。

当 `getType` 返回 `ShapeAdjustmentType.Custom` 时，API 未识别标准语义含义。检查 `getName`、预设类型以及现有值，除非已知预期含义和范围，否则不要更改该调整。即使是已识别的类型，也要检查同类型是否出现多次后再选择值。[Connector](/slides/zh/java/connector/) 文章展示了连接器弯曲调整的情况。

下面的完整示例创建了三个预设形状的默认和修改版本。它遍历每个调整，报告其名称和类型，通过 `setRawValue` 更改尺寸相关值，通过 `setAngleValue` 更改角度，并保存结果。左列保留默认几何；右列显示调整后的圆角矩形、四向箭头和饼图。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 为默认和调整后的形状列添加标题。
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在更改值之前检查语义类型，使代码对意图明确，并避免假设相同集合索引在不同预设形状中具有相同含义。

## **修改形状集合**

add、clone、remove 和 reorder 方法会立即作用于集合。如果操作改变了形状数量或顺序，请不要继续依赖操作前捕获的索引。

### **克隆形状**

[addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) 创建一个独立副本并将其追加到目标集合。[insertClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) 也会创建副本，但将其放置在指定的 z 顺序索引处。接受坐标的重载会在不改变大小的情况下移动克隆；接受宽度和高度的重载则可以同时调整大小。

示例创建目标幻灯片，将标记矩形克隆到前面，并在后面插入第二个克隆。对任一克隆的更改不会影响源形状。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

克隆会复制形状的内容和格式，包括名称和替代文本。当这些值必须唯一时，请为克隆分配新的逻辑标识符。复杂形状使用的资源由演示文稿处理，但克隆仍是具有新形状标识的新集合项。

### **删除形状**

[remove](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 从其集合中删除指定的形状对象。在索引迭代期间删除多个匹配项时，请从末尾向前遍历，以保持剩余索引有效。

此示例删除所有具有指定名称的形状。它读取当前索引处的形状，而不是固定的集合项，且没有不必要的类型转换。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

删除后，形状计数以及后续形状的索引会改变。对未受影响形状的引用比保存的索引更可靠。同时考虑连接器、动画及其他可能引用已删除对象的演示文稿特性；删除可见形状可能会影响幻灯片的外观以外的内容。

### **隐藏形状**

将 [Hidden](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#setHidden-boolean-) 设置为 `true` 会保留形状在集合中，但阻止其在普通幻灯片放映中出现。其索引、格式和内容仍可供代码使用，因此隐藏适用于以后可能恢复的可选元素。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

隐藏并非删除或安全措施。对象仍可被用户或代码发现并取消隐藏，并且仍是演示文稿文件的一部分。

### **更改 Z 顺序**

重叠的形状按照集合顺序绘制。[reorder](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 将已有形状移动到目标索引而不进行克隆。索引 `0` 为最底层，`size() - 1` 为最前层。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

矩形最初创建后位于椭圆之后。将其移动到最后索引后会出现在前面。添加或克隆所有相关形状后再完成 z 顺序的最终确定，因为这些操作会追加或插入新集合项并可能改变预期的堆叠顺序。

## **检查布局幻灯片上的形状**

普通幻灯片、布局幻灯片和母版幻灯片各自拥有独立的形状集合。布局集合中的形状并非普通幻灯片中相同位置形状的同一对象。需要了解或更改布局提供的格式时，请检查布局形状。

下面的示例读取每个布局形状的 [FillFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getFillFormat--) 和 [LineFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getLineFormat--)，不假设每个形状都是 `AutoShape`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

编辑布局可能影响使用该布局的多个幻灯片。在更改布局形状之前，确定普通幻灯片是继承该对象还是包含本地覆盖，并测试所有使用该布局的幻灯片。

## **将形状导出为 SVG**

[writeAsSvg](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) 将单个形状的渲染内容写入流。结果仅包含该形状，而不包括整个幻灯片背景或相邻形状。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

渲染期间请保持演示文稿打开。输出取决于形状的格式以及字体、图像等资源。如果需要完整的合成，请导出幻灯片而非单个形状。调用方拥有流的所有权并必须关闭它。

## **对齐形状**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) 的重载可以对全部形状或选定的集合索引进行对齐。[ShapesAlignmentType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shapesalignmenttype/) 指定边缘、中心线或分布模式。将 `alignToSlide` 设置为 `true` 使用幻灯片边缘；设为 `false` 则相对选定形状进行对齐。

此示例将三个形状对齐到幻灯片的顶部边缘。返回的形状引用在对齐前立即转换为当前索引。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

对齐会改变位置，而非 Z 顺序。相对对齐通常至少需要两个形状，水平或垂直分布则需要足够的形状来定义间距。如果在调用方法前修改了集合，请重新计算索引。

## **翻转形状**

[ShapeFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shapeframe/) 类存储位置、大小、水平和垂直翻转设置以及旋转。其 `getFlipH` 和 `getFlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh/java/com.aspose.slides/nullablebool/)：`True` 启用翻转，`False` 禁用，`NotDefined` 保持未指定/默认状态。

下面的输入演示文稿仅包含一个未翻转的形状。

![The shape before flipping](shape_to_be_flipped.png)

示例保留其他所有框架值，仅替换两个翻转设置。这一点很重要，因为为 [Frame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) 赋新值会替换完整的框架。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存后的形状在水平和垂直方向上均为镜像，位置、大小和旋转保持不变。

![The shape after flipping](flipped_shape.png)

## **常见问题**

**我应该使用集合索引作为形状标识符吗？**

仅在短期处理且在使用索引之前集合不会改变的情况下使用。对于受控模板，请优先使用经过验证的 `Name` 或 `AlternativeText` 约定；对于幻灯片范围的互操作工作，请使用 `OfficeInteropShapeId`。

**隐藏形状会将其从 Z 顺序中移除吗？**

不会。隐藏的形状仍保留在集合的相同索引处。它仍可被查找、重新排序、编辑或再次显示。

**为什么克隆的形状会出现在另一形状前面？**

`addClone` 将克隆追加到集合的末尾，也就是 Z 顺序的前面。使用 `insertClone` 可选择初始索引，或在全部形状添加完后使用 `reorder` 调整顺序。

**我可以使用固定索引来标识预设形状调整吗？**

仅在已验证确切预设和集合布局后才可以。更推荐遍历 `IGeometryShape.getAdjustments` 并检查 `IAdjustValue.getType`；当同一语义类型出现多次时，可使用 `IAdjustValue.getName` 作为补充信息。