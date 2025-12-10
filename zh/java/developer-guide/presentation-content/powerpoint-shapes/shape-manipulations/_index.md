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
- 获取 Interop 形状 ID
- 形状替代文本
- 形状布局格式
- 形状为 SVG
- 形状转 SVG
- 对齐形状
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中创建、编辑和优化形状，并交付高性能的 PowerPoint 演示文稿。"
---

## **在幻灯片上查找形状**
本主题将描述一种简便技术，帮助开发人员在不使用内部 Id 的情况下查找幻灯片上的特定形状。需要了解的是，PowerPoint 演示文稿文件除内部唯一 Id 外，无法以其他方式标识幻灯片上的形状。开发人员使用内部唯一 Id 查找形状往往比较困难。所有添加到幻灯片的形状都有一些替代文本。我们建议开发人员使用替代文本来查找特定形状。您可以使用 MS PowerPoint 为以后可能更改的对象定义替代文本。

在为任意所需形状设置了替代文本后，您可以使用 Aspose.Slides for Java 打开该演示文稿，并遍历幻灯片中添加的所有形状。在每次遍历时，检查形状的替代文本，匹配的替代文本对应的形状即为您需要的形状。为了更好地演示此技术，我们创建了一个方法，[findShape](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-)，它可以在幻灯片中查找特定形状并返回该形状。
```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // 要查找的形状的替代文本
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
// 方法实现：使用替代文本在幻灯片中查找形状
public static IShape findShape(ISlide slide, String alttext)
{
    // 遍历幻灯片内的所有形状
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // 如果幻灯片的替代文本与所需的匹配则
        // 返回该形状
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```


## **克隆形状**
要使用 Aspose.Slides for Java 将形状克隆到幻灯片：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 访问源幻灯片的形状集合。
1. 向演示文稿中添加新幻灯片。
1. 将形状从源幻灯片的形状集合克隆到新幻灯片。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例向幻灯片添加了一个组合形状。
```java
// 实例化 Presentation 类
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // 将 PPTX 文件写入磁盘
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **移除形状**
Aspose.Slides for Java 允许开发人员移除任何形状。要从任意幻灯片中移除形状，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定 AlternativeText 的形状。
1. 移除该形状。
1. 将文件保存到磁盘。
```java
// 创建 Presentation 对象
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加矩形类型的自动形状
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // 将演示文稿保存到磁盘
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **隐藏形状**
Aspose.Slides for Java 允许开发人员隐藏任何形状。要从任意幻灯片中隐藏形状，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定 AlternativeText 的形状。
1. 隐藏该形状。
1. 将文件保存到磁盘。
```java
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加矩形类型的自动形状
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // 保存演示文稿到磁盘
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **更改形状顺序**
Aspose.Slides for Java 允许开发人员重新排序形状。重新排序可决定哪个形状位于前面或后面。要对任意幻灯片的形状进行重新排序，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加一个形状。
1. 在形状的文本框中添加一些文本。
1. 添加另一个具有相同坐标的形状。
1. 重新排序这些形状。
1. 将文件保存到磁盘。
```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **获取 Interop Shape ID**
Aspose.Slides for Java 允许开发人员获取幻灯片范围内的唯一形状标识符，与 [getUniqueId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getUniqueId--) 方法在演示文稿范围内获取唯一标识符不同。方法 [getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) 已被添加到 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) 接口和 [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) 类中。该方法返回的值对应 Microsoft.Office.Interop.PowerPoint.Shape 对象的 Id 值。下面给出示例代码。
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 获取幻灯片范围内唯一的形状标识符
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **为形状设置替代文本**
Aspose.Slides for Java 允许开发人员设置任意形状的 AlternateText。演示文稿中的形状可以通过 [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) 或 [Shape Name](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setName-java.lang.String-) 方法进行区分。使用 Aspose.Slides 以及 Microsoft PowerPoint，都可以读取或设置 [setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) 和 [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--) 方法。通过此方法，您可以标记形状并执行诸如移除形状、隐藏形状或重新排序形状等操作。

请按以下步骤为形状设置 AlternateText：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 向幻灯片添加任意形状。
1. 对新添加的形状进行一些操作。
1. 遍历形状以查找目标形状。
1. 设置 AlternativeText。
1. 将文件保存到磁盘。
```java
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加矩形类型的自动形状
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // 将演示文稿保存到磁盘
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **访问形状的布局格式**
Aspose.Slides for Java 提供了简洁的 API 来访问形状的布局格式。本文演示了如何访问这些布局格式。

下面给出示例代码。
```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **将形状渲染为 SVG**
现在 Aspose.Slides for Java 支持将形状渲染为 SVG。方法 [writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-)（及其重载）已添加到 [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) 类和 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) 接口中。该方法允许将形状内容保存为 SVG 文件。下面的代码片段演示了如何将幻灯片中的形状导出为 SVG 文件。
```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **对齐形状**
Aspose.Slides 允许将形状相对于幻灯片边距或相互之间对齐。为此，已添加重载方法 [SlidesUtil.alignShape()](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)。[ShapesAlignmentType](https://reference.aspose.com/slides/java/com.aspose.slides/ShapesAlignmentType) 枚举定义了可能的对齐选项。

**示例 1**

以下源代码将索引为 1、2 和 4 的形状沿幻灯片顶部边缘对齐。
```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```


**示例 2**

下面的示例展示了如何将整个形状集合相对于集合中最底部的形状进行对齐。
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **翻转属性**
在 Aspose.Slides 中，[ShapeFrame](https://reference.aspose.com/slides/java/com.aspose.slides/shapeframe/) 类通过 `flipH` 和 `flipV` 属性提供对形状水平和垂直镜像的控制。这两个属性的类型为 `byte`，取值为 `1` 表示翻转，`0` 表示不翻转，`-1` 表示使用默认行为。可以通过形状的 [Frame](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getFrame--) 访问这些值。

要修改翻转设置，需要使用形状当前的位置、大小、期望的 `flipH`、`flipV` 值以及旋转角度构造一个新的 [ShapeFrame](https://reference.aspose.com/slides/java/com.aspose.slides/shapeframe/) 实例。将该实例分配给形状的 [Frame](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getFrame--) 并保存演示文稿后，即可将镜像变换写入输出文件。

假设我们有一个 sample.pptx 文件，其中第一张幻灯片包含一个默认翻转设置的单一形状，如下所示。

![要翻转的形状](shape_to_be_flipped.png)

下面的代码示例获取形状当前的翻转属性并同时在水平和垂直方向上进行翻转。
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // 检索形状的水平翻转属性。
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // 检索形状的垂直翻转属性。
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // 水平翻转。
    byte flipV = NullableBool.True; // 水平翻转。
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


效果如下：

![已翻转的形状](flipped_shape.png)

## **常见问题**

**我能像桌面编辑器那样在幻灯片上对形状进行合并（联合/交集/相减）吗？**

目前没有内置的布尔运算 API。您可以自行构造所需轮廓，例如使用 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 计算结果几何并创建具有该轮廓的新形状，同时可选择删除原始形状。

**如何控制堆叠顺序（z‑order），使某个形状始终位于“最上层”？**

在幻灯片的 [shapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) 集合中更改插入/移动顺序即可。为获得可预测的结果，建议在完成所有其他幻灯片修改后最后确定 z‑order。

**我能“锁定”形状，防止用户在 PowerPoint 中编辑它吗？**

可以。设置 [形状级别保护标志](/slides/zh/java/applying-protection-to-presentation/)（例如锁定选择、移动、大小调整、文本编辑）。如有需要，也可以在母版或布局上镜像相同限制。请注意，这属于 UI 级别的保护，而非安全特性；若需更强的保护，可结合文件级别的只读建议或密码等措施 [/slides/java/password-protected-presentation/]。