---
title: 在 Android 上管理演示文稿形状
linktitle: 形状操作
type: docs
weight: 40
url: /zh/androidjava/shape-manipulations/
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 识别、克隆、删除、隐藏、重新排序、导出、对齐以及翻转演示文稿形状。"
---
## **概述**

Aspose.Slides for Android via Java 将幻灯片中的形状表示为有序的[IShapeCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/)。该集合既是查找和修改形状的所在，也是它们堆叠顺序的来源：索引 `0` 为最靠后 的形状，最后一个索引为最靠前 的形状。

本文遵循该模型。首先解释如何可靠地识别形状，然后展示如何克隆、删除、隐藏和重新排序形状。最后的章节涵盖布局级别的格式化、SVG 导出、对齐以及翻转设置。每个示例都是独立的，您可以只使用工作流所需的操作。

## **识别和查找形状**

在处理已知文件时，集合索引很方便，但它们并不是稳定的标识符。添加、删除或重新排序形状都会改变其索引。请根据演示文稿的创建和维护方式选择标识符：

- [Name](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getName--) 对于受开发者控制的模板很有用，并且可以在 PowerPoint 的“选择窗格”中轻松查看。名称可以编辑，但不保证唯一，因此如果代码依赖名称，请建立命名约定。
- [AlternativeText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getAlternativeText--) 在可访问性描述或作者提供的标签已经标识形状时很有用。它对用户可见，可能会本地化或为可访问性而重写，也不保证唯一。不要在不知情的情况下将有意义的可访问性文本用作数据库键。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) 是只读标识符，在同一幻灯片内唯一，并对应 PowerPoint 互操作使用的形状 ID。将在与 PowerPoint 集成或在形状生命周期内需要明确引用时使用。克隆或重新创建的形状是不同的形状，会获得自己的 ID。

相关的[getUniqueId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getUniqueId--) 方法返回演示文稿范围内的标识符，但该标识符面向插件，可能会被重新分配。不要将其视为永久的外部键。如果长期身份至关重要，请在应用数据中维护映射，并验证预期的形状仍然存在。

下面的示例使用精确比较按名称搜索，并报告幻灯片范围内的互操作 ID。当模板不包含预期形状时，代码会报告该结果，而不是继续使用错误的对象。

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

当操作特定于某种形状类型时，在使用特定成员之前请检查接口。此示例仅在命名对象是[IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/) 时更新文本和替代文本。

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

## **修改形状集合**

add、clone、remove 和 reorder 方法会立即作用于集合。如某操作改变了形状数量或顺序，请勿继续依赖该操作前捕获的索引。

### **克隆形状**

[addClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) 创建一个独立副本并将其附加到目标集合。[insertClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) 也创建副本，但将其放置在指定的 Z 顺序索引处。接受坐标的重载在不改变大小的情况下移动克隆；接受宽度和高度的重载还能对其进行缩放。

示例创建目标幻灯片，将标注矩形克隆到前面，并在后面插入第二个克隆。对任一克隆的更改都不会影响源形状。

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

克隆会复制形状的内容和格式，包括名称和替代文本。当这些值必须唯一时，请为克隆分配新的逻辑标识符。复杂形状使用的资源由演示文稿处理，但克隆仍然是具有新形状身份的集合新项。

### **删除形状**

[remove](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 从其集合中删除指定的形状对象。对索引迭代期间删除多个匹配项时，请从末尾向前遍历，以保持剩余索引有效。

本示例删除所有具有指定名称的形状。它读取当前索引处的形状，而不是固定的集合项，并且没有不必要地进行类型转换。

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

删除后，形状计数以及后续形状的索引会改变。对未受影响的形状的引用比保存的索引更可靠。同时请考虑连接线、动画以及可能引用已删除对象的其他演示功能；删除可见形状可能会影响幻灯片的多方面表现。

### **隐藏形状**

将[Hidden](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) 设置为 `true` 会保留形状在集合中，但阻止其在普通幻灯片放映中出现。其索引、格式和内容仍可供代码使用，因此隐藏适用于可能稍后恢复的可选元素。

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

隐藏并非删除或安全措施。对象仍可被用户或代码发现并取消隐藏，且仍是演示文稿文件的一部分。

### **更改 Z 顺序**

重叠的形状按照集合顺序绘制。[reorder](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 将现有形状移动到目标索引而不进行克隆。索引 `0` 为最靠后，`size() - 1` 为最靠前。

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

矩形先创建，最初位于椭圆后面。将其移动到最终索引后会出现在前面。添加或克隆所有相关形状后再确定 Z 顺序，因为这些操作会追加或插入新集合项，可能会改变预期的堆叠。

## **检查布局幻灯片上的形状**

普通幻灯片、布局幻灯片和母版幻灯片拥有各自的形状集合。布局集合中的形状并不是普通幻灯片中同位置形状的同一对象。需要了解或更改布局提供的格式时，请检查布局形状。

下面的示例读取每个布局形状的[FillFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getFillFormat--) 和 [LineFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getLineFormat--)，并未假设每个形状都是 `AutoShape`。

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

编辑布局可能会影响使用该布局的多个幻灯片。在更改布局形状之前，请确定普通幻灯片是继承该对象还是包含本地覆盖，并测试所有使用该布局的幻灯片。

## **将形状导出为 SVG**

[writeAsSvg](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) 将单个形状的渲染内容写入流。结果仅包含该形状，不包含整个幻灯片背景或相邻形状。

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

渲染时请保持演示文稿打开。输出受形状格式以及字体、图像等资源的影响。如果需要整个组合，请导出幻灯片而不是单个形状。调用方拥有该流并必须关闭它。

## **对齐形状**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) 重载可以对齐全部形状或选定的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shapesalignmenttype/) 指定边缘、中心线或分布模式。将 `alignToSlide` 设置为 `true` 使用幻灯片边缘；设为 `false` 则相对选定形状进行对齐。

本示例将三个形状对齐到幻灯片的顶部边缘。返回的形状引用在对齐前立即转换为当前索引。

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

对齐会改变位置，而不是 Z 顺序。相对对齐通常至少需要两个形状，水平或垂直分布则需要足够的形状来确定间距。如果在调用方法前修改了集合，请重新计算索引。

## **翻转形状**

[ShapeFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shapeframe/) 类存储位置、大小、水平和垂直翻转设置以及旋转。其 `getFlipH` 和 `getFlipV` 值使用[NullableBool](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/nullablebool/)：`True` 启用翻转，`False` 禁用翻转，`NotDefined` 保持未指定/默认状态。

下面的输入演示文稿包含一个未翻转的形状。

![翻转前的形状](shape_to_be_flipped.png)

示例保留其他所有帧属性，仅替换两个翻转设置。这很重要，因为为 [Frame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) 赋新值会替换完整的帧。

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

保存后的形状在水平和垂直方向上均被镜像，同时保持其位置、大小和旋转。

![翻转后的形状](flipped_shape.png)

## **常见问题解答**

**应该将集合索引用作形状标识符吗？**

仅在短期处理且在使用索引前集合不会改变的情况下可以。对于受控模板请优先使用经过验证的 `Name` 或 `AlternativeText` 约定，针对幻灯片范围的互操作工作请使用 `OfficeInteropShapeId`。

**隐藏形状会从 Z 顺序中移除吗？**

不会。隐藏的形状仍保留在集合的同一索引处。它仍然可以被查找、重新排序、编辑或再次设为可见。

**为什么克隆的形状会出现在另一形状前面？**

`addClone` 将克隆追加到集合末尾，而集合末尾对应 Z 顺序的前端。使用 `insertClone` 可指定初始索引，或在全部形状添加完后使用 `reorder`。