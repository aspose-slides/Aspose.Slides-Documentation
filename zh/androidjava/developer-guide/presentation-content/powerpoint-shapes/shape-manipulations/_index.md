---
title: 管理 Android 上的演示文稿形状
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 识别、调整、克隆、删除、隐藏、重新排序、导出、对齐和翻转演示文稿中的形状。"
---
## **概述**

Aspose.Slides for Android via Java 将幻灯片上的形状表示为有序的[IShapeCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/)。该集合既是查找和修改形状的地点，也是它们堆叠顺序的来源：索引 `0` 为最底层形状，而最后的索引为最前面的形状。

本文遵循该模型。它首先解释如何可靠地识别形状并修改预设的形状调整点，然后展示如何克隆、删除、隐藏和重新排序形状。最后几节涵盖布局级别的格式化、SVG 导出、对齐和翻转设置。每个示例都是独立的，您可以只使用工作流所需的操作。

## **识别和查找形状**

在处理已知文件时，集合索引很方便，但它们不是稳定的标识符。添加、删除或重新排序形状都会改变其索引。请根据演示文稿的创作和维护方式选择标识符：

- [Name](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getName--) 对于开发者控制的模板很有用，并且在 PowerPoint 的“选择窗格”中易于检查。名称可以编辑，但不保证唯一，因此如果代码依赖它们，需要制定命名约定。
- [AlternativeText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getAlternativeText--) 当可访问性描述或作者提供的标签已经标识形状时很有用。它对用户可见，可能会本地化或为可访问性重写，并且不保证唯一。不要悄悄将有意义的可访问性文本用作数据库键。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) 是只读标识符，在幻灯片范围内唯一，并对应 PowerPoint 互操作使用的形状 ID。将其用于与 PowerPoint 集成或在形状生命周期内需要明确引用的场景。克隆或重新创建的形状是不同的形状，并会获得自己的 ID。

相关的[getUniqueId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getUniqueId--) 方法返回一个演示文稿范围的标识符，但该标识符面向插件，可能会被重新分配。不要将其视为永久的外部键。如果长期身份至关重要，请在应用程序数据中保持映射并验证预期的形状仍然存在。

以下示例使用精确比较按名称搜索，并报告幻灯片范围的互操作 ID。当模板不包含预期形状时，代码会报告该结果而不是继续使用错误的对象。

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

当操作特定于某种形状类型时，请在使用类型特定成员之前检查接口。此示例仅在命名对象是[IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)时才更新文本和替代文本。

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

## **识别和修改预设形状调整**

预设几何形状可以公开调整点，用于控制角大小、箭头比例或弧度等特性。通过只读的[IGeometryShape.getAdjustments](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--)集合访问它们。该集合由形状提供，但每个[IAdjustValue](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iadjustvalue/)包含一个可更改的值。

不要仅依赖固定的集合索引。遍历调整项并检查只读的[getType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iadjustvalue/#getType--) 方法，其[ShapeAdjustmentType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shapeadjustmenttype/)值描述了该调整控制的内容。只读的[getName](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iadjustvalue/#getName--) 方法提供了额外的标识信息，当预设包含多个具有相同语义类型的调整时特别有用。

使用与调整意义匹配的值方法：

| 调整类型 | 用途 | 要更改的值 |
|---|---|---|
| `CornerSize` | 圆角的大小 | [setRawValue](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | 箭头尾部的粗细 | `setRawValue` |
| `ArrowheadLength` | 箭头头部的长度 | `setRawValue` |
| `ArrowheadWidth` | 箭头头部的宽度 | `setRawValue` |
| `StartAngle` | 饼形或弧形的起始角度 | [setAngleValue](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | 饼形或弧形的结束角度 | `setAngleValue` |

`getType` 和 `getName` 返回只读信息。`getRawValue` 与 `setRawValue` 使用预设本地几何单位的整数，而 `getAngleValue` 与 `setAngleValue` 使用度数。调整的数量、顺序、含义和有效范围取决于预设的[ShapeType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/igeometryshape/#getShapeType--)。对一种预设有效的值可能对另一种预设无效或产生不同效果。

当`getType` 返回`ShapeAdjustmentType.Custom` 时，API 未识别标准语义。检查`getName`、预设类型以及现有值，除非已知预期的意义和范围，否则保持调整不变。即使是已识别的类型，也要在选择值之前检查同一类型是否出现多次。[Connector](/slides/zh/androidjava/connector/) 文章展示了连接器弯曲调整的情形。

下面的完整示例创建三个预设形状的默认和修改版本。它遍历每个调整，报告其名称和类型，通过`setRawValue` 更改尺寸相关的值，通过`setAngleValue` 更改角度，并保存结果。左列保留默认几何；右列显示已调整的圆角矩形、四向箭头和饼形。

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

在更改值之前检查语义类型，使代码对意图明确，并避免假设特定集合索引在不同预设形状之间具有相同含义。

## **修改形状集合**

添加、克隆、删除和重新排序方法会立即作用于集合。如果操作改变了形状的数量或顺序，请不要继续依赖之前捕获的索引。

### **克隆形状**

[addClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) 创建一个独立的副本并将其追加到目标集合。[insertClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) 也创建副本，但将其放置在指定的 Z 顺序索引。接受坐标的重载在不改变大小的情况下移动克隆；接受宽度和高度的重载可以同时调整大小。

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

克隆会复制形状的内容和格式，包括名称和替代文本。当这些值必须唯一时，请为克隆分配新的逻辑标识符。复杂形状使用的资源由演示文稿处理，但克隆仍然是集合中的新项目，拥有新的形状标识。

### **删除形状**

[remove](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 从其集合中删除特定的形状对象。在索引迭代期间删除多个匹配项时，请从末尾向前遍历，以保证剩余索引仍然有效。

此示例删除所有具有指定名称的形状。它读取当前索引处的形状，而不是固定的集合项，并且没有不必要地进行类型转换。

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

删除后，形状计数以及后续形状的索引会改变。对未受影响的形状的引用比保存的索引更可靠。同时考虑连接器、动画和其他可能引用被删除对象的演示功能；删除可见形状可能会影响幻灯片的外观以外的内容。

### **隐藏形状**

将[Hidden](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) 设置为 `true` 可将形状保留在集合中，但阻止其在普通放映中出现。其索引、格式和内容仍可供代码使用，因此隐藏适用于可能稍后恢复的可选元素。

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

隐藏不是删除，也不是安全措施。对象仍可被用户或代码发现并取消隐藏，且仍是演示文稿文件的一部分。

### **更改 Z 顺序**

重叠的形状按照集合顺序绘制。[reorder](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 将现有形状移动到目标索引，而不进行克隆。索引 `0` 为最底层；`size() - 1` 为最前层。

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

矩形先被创建，最初位于椭圆后面。将其移动到最终索引后位于前面。在添加或克隆所有相关形状后再最终确定 Z 顺序，因为这些操作会追加或插入新集合项，可能会改变预期的堆叠。

## **检查布局幻灯片上的形状**

普通幻灯片、布局幻灯片和母版幻灯片拥有各自的形状集合。布局集合中的形状并不是普通幻灯片上同位置形状的同一对象。需要了解或更改布局提供的格式时，请检查布局形状。

下面的示例读取每个布局形状的[FillFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getFillFormat--)和[LineFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getLineFormat--)，而不假设每个形状都是`AutoShape`。

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

编辑布局可能影响使用该布局的多个幻灯片。在更改布局形状之前，请确定普通幻灯片是继承该对象还是拥有本地覆盖，并对使用该布局的每张幻灯片进行测试。

## **将形状导出为 SVG**

[writeAsSvg](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) 将单个形状的渲染内容写入流。结果仅包含该形状，而不包括整个幻灯片背景或相邻形状。

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

渲染时请保持演示文稿打开。输出取决于形状的格式以及字体、图像等资源。如果需要整个组合，请导出幻灯片而不是单个形状。调用方拥有流的所有权并必须关闭它。

## **对齐形状**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) 重载可对全部形状或选定的集合索引进行对齐。[ShapesAlignmentType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shapesalignmenttype/) 指定边缘、中心线或分布模式。将 `alignToSlide` 设置为 `true` 使用幻灯片边缘；设置为 `false` 则相对选定形状进行对齐。

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

对齐会改变位置，而不是 Z 顺序。相对对齐通常需要至少两个形状，而水平或垂直分布则需要足够的形状来定义间距。如果在调用方法前修改了集合，请重新计算索引。

## **翻转形状**

[ShapeFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shapeframe/) 类存储位置、大小、水平和垂直翻转设置以及旋转。其 `getFlipH` 和 `getFlipV` 值使用[NullableBool](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/nullablebool/)：`True` 启用翻转，`False` 禁用，`NotDefined` 保持未指定/默认状态。

以下输入演示文稿包含一个未翻转的形状。

![翻转前的形状](shape_to_be_flipped.png)

示例保留其它所有帧属性，仅替换两个翻转设置。这一点很重要，因为为[Frame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) 赋新值会替换完整帧。

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

**我应该使用集合索引作为形状标识符吗？**

仅在短期处理且在使用索引之前集合不会改变的情况下使用。对于作者编写的模板，首选经过验证的 `Name` 或 `AlternativeText` 约定；对于幻灯片范围的互操作工作，使用 `OfficeInteropShapeId`。

**隐藏形状会从 Z 顺序中移除吗？**

不会。隐藏的形状仍然保留在集合的相同索引处。它可以被找到、重新排序、编辑或再次设为可见。

**为什么克隆的形状会出现在另一个形状的前面？**

`addClone` 将克隆追加到集合的末尾，即 Z 顺序的最前面。使用 `insertClone` 可以指定初始索引，或在所有形状添加完毕后使用 `reorder`。

**我可以使用固定索引来识别预设形状的调整吗？**

只能在明确验证了确切的预设和集合布局后才可以。更推荐遍历 `IGeometryShape.getAdjustments` 并检查 `IAdjustValue.getType`；当相同语义类型出现多次时，使用 `IAdjustValue.getName` 作为额外信息。