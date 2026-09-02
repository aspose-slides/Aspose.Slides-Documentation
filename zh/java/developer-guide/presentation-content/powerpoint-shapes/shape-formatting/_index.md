---
title: 在 Java 中格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/java/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 素描效果
- 形状线条素描
- 格式化连接样式
- 渐变填充
- 图案填充
- 图片填充
- 纹理填充
- 纯色填充
- 形状透明度
- 旋转形状
- 3D 倾斜效果
- 3D 旋转效果
- 重置格式
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Java 中格式化 PowerPoint 形状——精确且完全控制地为 PPT、PPTX 和 ODP 文件设置填充、线条和效果样式。"
---
## **简介**

In PowerPoint，你可以向幻灯片添加形状。由于形状由线条组成，你可以通过修改或应用效果到轮廓来格式化它们。此外，你还可以通过指定控制内部填充方式的设置来格式化形状。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java 提供了接口和方法，允许你使用 PowerPoint 中相同的选项来格式化形状。

## **格式化线条**

使用 Aspose.Slides，你可以为形状指定自定义线条样式。以下步骤概述了操作过程：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
1. 设置形状的 [line style](https://reference.aspose.com/slides/zh/java/com.aspose.slides/linestyle/)。
1. 设置线宽。
1. 设置线条的 [dash style](https://reference.aspose.com/slides/zh/java/com.aspose.slides/linedashstyle/)。
1. 为形状设置线条颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下代码演示了如何格式化矩形 `AutoShape`：

```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个矩形类型的自动形状。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 设置矩形形状的填充颜色。
    shape.getFillFormat().setFillType(FillType.NoFill);

    // 为矩形的线条应用格式化。
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // 设置矩形线条的颜色。
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // 将 PPTX 文件保存到磁盘。
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The formatted lines in the presentation](formatted-lines.png)

## **对形状线条应用素描效果**

素描效果可以让形状线条看起来像手绘。使用 [IShape.getLineFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/) 访问线条设置，使用 [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilineformat/) 访问素描设置，并使用 [ISketchFormat.setSketchType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isketchformat/) 从 [LineSketchType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/linesketchtype/) 枚举中选择一个值。

以下 Java 代码展示了如何应用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh/java/com.aspose.slides/linesketchtype/) 效果，读取显式分配的值，以及如何使用 [LineSketchType.None](https://reference.aspose.com/slides/zh/java/com.aspose.slides/linesketchtype/) 移除该效果：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // 访问形状的线条格式及其素描格式。
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // 应用素描效果。
    sketchFormat.setSketchType(LineSketchType.Curved);

    // 读取直接分配给形状的素描效果。
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // 移除素描效果。
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isketchformat/) 返回的值表示直接分配给形状的设置。如果线条格式可以从主题、母版幻灯片或布局幻灯片继承，请使用 [ILineFormat.getEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilineformat/)，访问 [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilineformateffectivedata/)，并读取 [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isketchformateffectivedata/)。有效值反映在解析继承后实际应用的格式：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **格式化连接样式**

以下是三种连接类型选项：

* Round
* Miter
* Bevel

默认情况下，PowerPoint 在以角度连接两条线（例如形状的角点）时使用 **Round** 设置。不过，如果绘制的形状具有锐角，你可能更倾向于 **Miter** 选项。

![The join style in the presentation](join-style-powerpoint.png)

以下 Java 代码演示了如何使用 Miter、Bevel 和 Round 连接类型设置创建图中所示的三个矩形：

```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加三个矩形类型的自动形状。
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // 为每个矩形形状设置填充颜色。
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // 设置线宽。
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // 为每个矩形的线条设置颜色。
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // 设置连接样式。
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // 为每个矩形添加文本。
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // 将 PPTX 文件保存到磁盘。
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **渐变填充**

In PowerPoint，渐变填充是一种格式化选项，允许你对形状应用连续的颜色渐变。例如，你可以以一种颜色逐渐淡入另一种颜色的方式应用两种或多种颜色。

以下是使用 Aspose.Slides 对形状应用渐变填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/filltype/) 设置为 `Gradient`。
1. 使用 [IGradientFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/igradientformat/) 接口暴露的渐变停止集合的 `add` 方法，添加两个首选颜色并指定位置。
1. 将修改后的演示文稿保存为 PPTX 文件。

```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个椭圆类型的自动形状。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 对椭圆应用渐变格式化。
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // 设置渐变的方向。
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // 添加两个渐变停止点。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // 将 PPTX 文件保存到磁盘。
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The ellipse with gradient fill](gradient-fill.png)

## **图案填充**

In PowerPoint，图案填充是一种格式化选项，允许你对形状应用两种颜色的设计——如点、条纹、交叉线或方格。你可以为图案的前景色和背景色自定义颜色。

Aspose.Slides 提供超过 45 种预定义的图案样式，可应用于形状以提升演示文稿的视觉效果。即使选择了预定义图案，你仍然可以指定其使用的精确颜色。

以下是使用 Aspose.Slides 对形状应用图案填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/filltype/) 设置为 `Pattern`。
1. 从预定义选项中选择一种图案样式。
1. 设置图案的 [Background Color](https://reference.aspose.com/slides/zh/java/com.aspose.slides/patternformat/#getBackColor--)。
1. 设置图案的 [Foreground Color](https://reference.aspose.com/slides/zh/java/com.aspose.slides/patternformat/#getForeColor--)。
1. 将修改后的演示文稿保存为 PPTX 文件。

```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个矩形类型的自动形状。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 将填充类型设置为 Pattern。
    shape.getFillFormat().setFillType(FillType.Pattern);

    // 设置图案样式。
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // 设置图案的背景色和前景色。
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // 将 PPTX 文件保存到磁盘。
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The rectangle with pattern fill](pattern-fill.png)

## **图片填充**

In PowerPoint，图片填充是一种格式化选项，允许你在形状内部插入图像——实际上将图像用作形状的背景。

以下是使用 Aspose.Slides 对形状应用图片填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/filltype/) 设置为 `Picture`。
1. 将图片填充模式设置为 `Tile`（或其他首选模式）。
1. 从要使用的图像创建一个 [IPPImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ippimage/) 对象。
1. 将图像传递给 `ISlidesPicture.setImage` 方法。
1. 将修改后的演示文稿保存为 PPTX 文件。

假设我们有一个名为 "lotus.png" 的文件，其图片如下：

![The lotus picture](lotus.png)

```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个矩形类型的自动形状。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 将填充类型设置为 Picture。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 设置图片填充模式。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // 加载图像并将其添加到演示资源中。
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // 设置图片。
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 将 PPTX 文件保存到磁盘。
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The shape with picture fill](picture-fill.png)

### **将图片平铺为纹理**

如果你想将平铺的图片设为纹理并自定义平铺行为，可以使用 [IPictureFillFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipicturefillformat/) 接口和 [PictureFillFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/picturefillformat/) 类的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): 设置图片填充模式——`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): 指定平铺在形状内的对齐方式。
- [setTileFlip](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): 控制平铺是否水平翻转、垂直翻转或两者兼有。
- [setTileOffsetX](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): 设置平铺相对于形状原点的水平偏移（单位为点）。
- [setTileOffsetY](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): 设置平铺相对于形状原点的垂直偏移（单位为点）。
- [setTileScaleX](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): 定义平铺的水平比例，以百分比表示。
- [setTileScaleY](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): 定义平铺的垂直比例，以百分比表示。

以下代码示例展示了如何添加一个带有平铺图片填充的矩形形状并配置平铺选项：

```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 添加一个矩形自动形状。
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 将形状的填充类型设置为 Picture。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 加载图像并将其添加到演示资源中。
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 将图像分配给形状。
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // 配置图片填充模式和瓦片属性。
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // 将 PPTX 文件保存到磁盘。
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The tile options](tile-options.png)

## **纯色填充**

In PowerPoint，纯色填充是一种格式化选项，它使用单一、统一的颜色填充形状。这种纯色背景没有任何渐变、纹理或图案。

使用 Aspose.Slides 对形状应用纯色填充，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/filltype/) 设置为 `Solid`。
1. 为形状分配你首选的填充颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个矩形类型的自动形状。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 将填充类型设置为 Solid。
    shape.getFillFormat().setFillType(FillType.Solid);

    // 设置填充颜色。
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // 将 PPTX 文件保存到磁盘。
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The shape with solid color fill](solid-color-fill.png)

## **设置透明度**

In PowerPoint，当你对形状应用纯色、渐变、图片或纹理填充时，也可以设置透明度级别以控制填充的透明度。更高的透明度值会使形状更透，从而部分显示背景或下方对象。

Aspose.Slides 通过调整用于填充的颜色的 alpha 值来设置透明度。操作方法如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
1. 将 [FillType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/filltype/) 设置为 `Solid`。
1. 使用 `Color` 定义带有透明度的颜色（`alpha` 分量控制透明度）。
1. 保存演示文稿。

```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个实心矩形自动形状。
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 在实心形状上添加一个透明矩形自动形状。
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // 将 PPTX 文件保存到磁盘。
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The transparent shape](shape-transparency.png)

## **旋转形状**

Aspose.Slides 允许在 PowerPoint 演示文稿中旋转形状。这在对视觉元素进行特定对齐或设计需求的定位时非常有用。

要在幻灯片上旋转形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
1. 将形状的旋转属性设置为所需角度。
1. 保存演示文稿。

```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个矩形类型的自动形状。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 将形状旋转 5 度。
    shape.setRotation(5);

    // 将 PPTX 文件保存到磁盘。
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The shape rotation](shape-rotation.png)

## **添加 3D 倾斜效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/threedformat/) 属性来对形状应用 3D 倾斜效果。

要为形状添加 3D 倾斜效果，请按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
1. 配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/threedformat/) 以定义倾斜设置。
1. 保存演示文稿。

```java
// 创建 Presentation 类的实例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 向幻灯片添加形状。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // 设置形状的 ThreeDFormat 属性。
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // 将演示文稿保存为 PPTX 文件。
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The 3D bevel effect](3D-bevel-effect.png)

## **添加 3D 旋转效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/threedformat/) 属性来对形状应用 3D 旋转效果。

要对形状应用 3D 旋转：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
1. 使用 [setCameraType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icamera/#setCameraType-int-) 和 [setLightType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilightrig/#setLightType-int-) 定义 3D 旋转。
1. 保存演示文稿。

```java
// 创建 Presentation 类的实例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // 将演示文稿保存为 PPTX 文件。
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The 3D rotation effect](3D-rotation-effect.png)

## **重置格式**

以下 Java 代码展示了如何重置幻灯片的格式，并将 [LayoutSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/layoutslide/) 上所有占位符形状的位置、大小和格式恢复到默认设置：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 重置幻灯片上每个在布局中有占位符的形状。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**形状格式化会影响最终的演示文件大小吗？**

影响极小。嵌入的图像和媒体占据了大部分文件空间，而形状参数如颜色、效果和渐变仅作为元数据存储，几乎不增加额外大小。

**如何检测幻灯片上具有相同格式的形状，以便将它们分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值相匹配，则视为样式相同，并在逻辑上将这些形状分组，这有助于后续的样式管理。

**是否可以将一套自定义形状样式保存到单独的文件，以便在其他演示文稿中重用？**

可以。将带有所需样式的示例形状存放在模板幻灯片或 .POTX 模板文件中。创建新演示文稿时，打开模板，克隆所需的已样式化形状，并在需要的地方重新应用其格式。