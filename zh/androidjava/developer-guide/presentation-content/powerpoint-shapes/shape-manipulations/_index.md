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
- 获取 Interop 形状 ID
- 形状替代文本
- 形状布局格式
- 形状为 SVG
- 形状转为 SVG
- 对齐形状
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Android via Java 中创建、编辑和优化形状，并交付高性能的 PowerPoint 演示文稿。"
---

## **在幻灯片上查找形状**
本主题将介绍一种简单技术，使开发人员更容易在幻灯片上查找特定形状，而无需使用其内部 Id。需要了解的是，PowerPoint 演示文稿文件除了内部唯一 Id 之外，无法通过其他方式标识幻灯片上的形状。开发人员使用内部唯一 Id 查找形状往往比较困难。所有添加到幻灯片的形状都有一些 Alt Text。我们建议开发人员使用替代文本来查找特定形状。您可以使用 MS PowerPoint 为以后计划更改的对象定义替代文本。

在为任意所需形状设置替代文本后，您可以使用 Aspose.Slides for Android via Java 打开该演示文稿，并遍历幻灯片中添加的所有形状。在每次迭代时，检查形状的替代文本，匹配的替代文本即为您需要的形状。为更好地演示此技术，我们创建了一个方法，[findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-)，该方法可在幻灯片中查找特定形状并返回该形状。
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
// 使用替代文本在幻灯片中查找形状的方法实现
public static IShape findShape(ISlide slide, String alttext)
{
    // 遍历幻灯片中的所有形状
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // 如果幻灯片的替代文本与所需的匹配，则
        // 返回该形状
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```


## **克隆形状**
要使用 Aspose.Slides for Android via Java 将形状克隆到幻灯片：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 访问源幻灯片的形状集合。
1. 向演示文稿添加新幻灯片。
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


## **删除形状**
Aspose.Slides for Android via Java 允许开发人员删除任意形状。要从任意幻灯片中删除形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定 AlternativeText 的形状。
1. 删除该形状。
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
Aspose.Slides for Android via Java 允许开发人员隐藏任意形状。要隐藏任意幻灯片中的形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
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

    // 将演示文稿保存到磁盘
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **更改形状顺序**
Aspose.Slides for Android via Java 允许开发人员重新排序形状。重新排序决定了形状是在前面还是在后面。要重新排序任意幻灯片中的形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加一个形状。
1. 在形状的文本框中添加一些文本。
1. 再添加一个具有相同坐标的形状。
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


## **获取 Interop 形状 ID**
Aspose.Slides for Android via Java 允许开发人员获取幻灯片范围内的唯一形状标识符，这与 [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--) 方法在演示文稿范围内获取唯一标识符不同。方法 [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) 已在 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) 接口和 [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) 类中添加。该方法返回的值对应于 Microsoft.Office.Interop.PowerPoint.Shape 对象的 Id。下面给出示例代码。
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 获取幻灯片范围内的唯一形状标识符
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **为形状设置替代文本**
Aspose.Slides for Android via Java 允许开发人员设置任意形状的 AlternateText。演示文稿中的形状可以通过 [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) 或 [Shape Name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-) 方法进行区分。[setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) 和 [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) 方法既可以在 Aspose.Slides 中使用，也可以在 Microsoft PowerPoint 中使用。使用此方法，您可以为形状打标签，并执行删除形状、隐藏形状或在幻灯片上重新排序形状等不同操作。要设置形状的 AlternateText，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
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

    // 保存演示文稿到磁盘
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **访问形状的布局格式**
Aspose.Slides for Android via Java 提供了简洁的 API 来访问形状的布局格式。本文演示了如何访问布局格式。

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
现在 Aspose.Slides for Android via Java 支持将形状渲染为 svg。方法 [writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-)（及其重载）已添加到 [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) 类和 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) 接口。此方法允许将形状的内容保存为 SVG 文件。下面的代码片段展示了如何将幻灯片的形状导出为 SVG 文件。
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
Aspose.Slides 允许将形状相对于幻灯片边距或相互之间对齐。为此，已添加重载方法 [SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)。[ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) 枚举定义了可能的对齐选项。

**示例 1**

下面的源代码将索引为 1、2 和 4 的形状对齐到幻灯片的上边缘。
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

下面的示例展示了如何将整个形状集合相对于集合中最底部的形状对齐。
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **翻转属性**
在 Aspose.Slides 中，[ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) 类通过其 `flipH` 和 `flipV` 属性提供对形状水平和垂直镜像的控制。这两个属性的类型为 `byte`，`1` 表示翻转，`0` 表示不翻转，`-1` 表示使用默认行为。这些值可通过形状的 [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) 访问。

要修改翻转设置，可构造一个新的 [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) 实例，将形状的当前位置和大小、期望的 `flipH`、`flipV` 值以及旋转角度传入。将此实例分配给形状的 [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) 并保存演示文稿，即可应用镜像转换并写入输出文件。

假设我们有一个 sample.pptx 文件，其中第一张幻灯片包含一个默认翻转设置的单一形状，如下所示。

![要翻转的形状](shape_to_be_flipped.png)

下面的代码示例获取形状当前的翻转属性，并同时水平和垂直翻转它。
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


结果：

![已翻转的形状](flipped_shape.png)

## **常见问题**

**我可以像桌面编辑器一样在幻灯片上对形状进行合并（联合/相交/相减）吗？**

目前没有内置的布尔操作 API。您可以通过自行构建所需轮廓来近似实现——例如计算结果几何形状（通过 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)），然后使用该轮廓创建新形状，并可选择删除原始形状。

**如何控制堆叠顺序（z‑order），使形状始终位于“顶部”？**

更改幻灯片的 [shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) 集合中的插入/移动顺序。为获得可预测的结果，请在完成所有其他幻灯片修改后最终确定 z‑order。

**我可以“锁定”形状以防止用户在 PowerPoint 中编辑它吗？**

可以。设置形状级别的保护标志（例如锁定选择、移动、大小调整、文本编辑）。如有需要，还可以在母版或版式上镜像限制。请注意，这属于 UI 级别的保护而非安全特性；如需更强的保护，可结合文件级限制，例如 [只读建议或密码](/slides/zh/androidjava/password-protected-presentation/)。