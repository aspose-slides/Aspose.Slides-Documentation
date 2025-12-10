---
title: 在 Java 中格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/java/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 格式化连接样式
- 渐变填充
- 图案填充
- 图片填充
- 纹理填充
- 纯色填充
- 形状透明度
- 旋转形状
- 3D 倒角效果
- 3D 旋转效果
- 重置格式
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何在 Java 中使用 Aspose.Slides 对 PowerPoint 形状进行格式化——精确且全面地为 PPT、PPTX 和 ODP 文件设置填充、线条和效果样式。"
---

## **概述**

在 PowerPoint 中，您可以向幻灯片添加形状。由于形状由线组成，您可以通过修改或应用效果到其轮廓来格式化它们。此外，您还可以通过指定控制内部填充方式的设置来格式化形状。

![PowerPoint 中的形状格式化](format-shape-powerpoint.png)

Aspose.Slides for Java 提供接口和方法，允许您使用 PowerPoint 中相同的选项来格式化形状。

## **线条格式化**

使用 Aspose.Slides，您可以为形状指定自定义线条样式。以下步骤概述了该过程：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。  
4. 设置形状的 [线条样式](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/)。  
5. 设置线宽。  
6. 设置线条的 [虚线样式](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/)。  
7. 设置形状的线条颜色。  
8. 将修改后的演示文稿保存为 PPTX 文件。

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

    // 对矩形的线条应用格式设置。
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


结果如下：

![演示文稿中格式化的线条](formatted-lines.png)

## **连接样式的格式化**

以下是三种连接类型选项：

* 圆形  
* 斜切  
* 倒角  

默认情况下，PowerPoint 在以角度连接两条线（例如在形状的拐角处）时使用 **Round** 设置。然而，如果您绘制的是具有尖锐角度的形状，可能更倾向于使用 **Miter** 选项。

![演示文稿中的连接样式](join-style-powerpoint.png)

以下 Java 代码演示了如何使用 Miter、Bevel 和 Round 连接类型设置创建上述图示的三个矩形：
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

在 PowerPoint 中，渐变填充是一种格式化选项，允许您对形状应用连续的颜色混合。例如，您可以以一种颜色逐渐淡入另一种颜色的方式应用两种或更多颜色。

以下是使用 Aspose.Slides 对形状应用渐变填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。  
4. 将形状的 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 设置为 `Gradient`。  
5. 使用 [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/) 接口公开的渐变停止集合的 `add` 方法，按定义的位置添加您首选的两种颜色。  
6. 将修改后的演示文稿保存为 PPTX 文件。

以下 Java 代码演示了如何对椭圆应用渐变填充效果：
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


结果如下：

![具有渐变填充的椭圆](gradient-fill.png)

## **图案填充**

在 PowerPoint 中，图案填充是一种格式化选项，允许您对形状应用两色设计（如点、条纹、交叉阴影或格子），并可自行选择图案的前景色和背景色。

Aspose.Slides 提供超过 45 种预定义图案样式，您可以将其应用于形状以增强演示文稿的视觉效果。即使选择了预定义图案，仍可指定其使用的确切颜色。

以下是使用 Aspose.Slides 对形状应用图案填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。  
4. 将形状的 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 设置为 `Pattern`。  
5. 从预定义选项中选择一种图案样式。  
6. 设置图案的 [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--)。  
7. 设置图案的 [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--)。  
8. 将修改后的演示文稿保存为 PPTX 文件。

以下 Java 代码演示了如何对矩形应用图案填充：
```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个矩形类型的自动形状。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 将填充类型设置为图案。
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


结果如下：

![具有图案填充的矩形](pattern-fill.png)

## **图片填充**

在 PowerPoint 中，图片填充是一种格式化选项，允许您在形状内部插入图像——相当于将图像用作形状的背景。

以下是使用 Aspose.Slides 对形状应用图片填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。  
4. 将形状的 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 设置为 `Picture`。  
5. 将图片填充模式设置为 `Tile`（或其他首选模式）。  
6. 从所需图像创建一个 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) 对象。  
7. 将图像传递给 `ISlidesPicture.setImage` 方法。  
8. 将修改后的演示文稿保存为 PPTX 文件。

假设我们有一个名为 “lotus.png” 的文件，内容如下：

![莲花图片](lotus.png)

以下 Java 代码演示了如何用图片填充形状：
```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个矩形类型的自动形状。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 将填充类型设置为图片。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 设置图片填充模式。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // 加载图片并将其添加到演示文稿资源中。
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


结果如下：

![具有图片填充的形状](picture-fill.png)

### **将图片平铺为纹理**

如果您想将平铺的图片设为纹理并自定义平铺行为，可以使用 [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) 接口和 [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) 类的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-)：设置图片填充模式——`Tile` 或 `Stretch`。  
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-)：指定平铺在形状内的对齐方式。  
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-)：控制平铺是水平翻转、垂直翻转还是同时翻转。  
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-)：设置平铺相对于形状原点的水平偏移（以点为单位）。  
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-)：设置平铺相对于形状原点的垂直偏移（以点为单位）。  
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-)：以百分比定义平铺的水平缩放。  
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-)：以百分比定义平铺的垂直缩放。

以下代码示例展示了如何添加一个带平铺图片填充的矩形并配置平铺选项：
```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 添加一个矩形自动形状。
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 将形状的填充类型设置为图片。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 加载图片并将其添加到演示文稿资源中。
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 将图片分配给形状。
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


结果如下：

![平铺选项](tile-options.png)

## **纯色填充**

在 PowerPoint 中，纯色填充是一种格式化选项，将形状填充为单一、统一的颜色。这种纯背景颜色不包含任何渐变、纹理或图案。

使用 Aspose.Slides 对形状应用纯色填充的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。  
4. 将形状的 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 设置为 `Solid`。  
5. 为形状指定您首选的填充颜色。  
6. 将修改后的演示文稿保存为 PPTX 文件。

以下 Java 代码演示了如何对 PowerPoint 幻灯片中的矩形应用纯色填充：
```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个矩形类型的自动形状。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 将填充类型设置为纯色。
    shape.getFillFormat().setFillType(FillType.Solid);

    // 设置填充颜色。
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // 将 PPTX 文件保存到磁盘。
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


结果如下：

![具有纯色填充的形状](solid-color-fill.png)

## **设置透明度**

在 PowerPoint 中，当您对形状应用纯色、渐变、图片或纹理填充时，还可以设置透明度级别以控制填充的不透明度。更高的透明度值会使形状更透，让背景或底层对象部分可见。

Aspose.Slides 通过调整用于填充的颜色的 alpha 值来设置透明度。操作步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。  
4. 将 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 设置为 `Solid`。  
5. 使用 `Color` 定义带透明度的颜色（`alpha` 分量控制透明度）。  
6. 保存演示文稿。

以下 Java 代码演示了如何对矩形应用透明填充颜色：
```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个实心矩形自动形状。
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 在实心形状上方添加一个透明矩形自动形状。
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // 将 PPTX 文件保存到磁盘。
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


结果如下：

![透明形状](shape-transparency.png)

## **旋转形状**

Aspose.Slides 允许您在 PowerPoint 演示文稿中旋转形状。这在需要特定对齐或设计需求的可视元素定位时非常有用。

旋转幻灯片上的形状的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。  
4. 将形状的 rotation 属性设置为所需角度。  
5. 保存演示文稿。

以下 Java 代码演示了如何将形状旋转 5 度：
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


结果如下：

![形状旋转](shape-rotation.png)

## **添加 3D 倒角效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) 属性来对形状应用 3D 倒角效果。

添加 3D 倒角效果的步骤如下：

1. 实例化 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。  
4. 配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) 以定义倒角设置。  
5. 保存演示文稿。

以下 Java 代码展示了如何对形状应用 3D 倒角效果：
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


结果如下：

![3D 倒角效果](3D-bevel-effect.png)

## **添加 3D 旋转效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) 属性来对形状应用 3D 旋转效果。

应用 3D 旋转的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。  
4. 使用 [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) 和 [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) 定义 3D 旋转。  
5. 保存演示文稿。

以下 Java 代码演示了如何对形状应用 3D 旋转效果：
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


结果如下：

![3D 旋转效果](3D-rotation-effect.png)

## **重置格式**

以下 Java 代码展示了如何重置幻灯片的格式，并将 [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) 上所有带占位符的形状的位置、大小和格式恢复为默认设置：
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 重置幻灯片上在布局中具有占位符的每个形状。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **常见问题**

**形状格式化会影响最终演示文稿的文件大小吗？**

影响很小。嵌入的图片和媒体占用了文件的大部分空间，而形状的颜色、效果和渐变等参数作为元数据存储，几乎不增加额外大小。

**如何检测幻灯片上具有相同格式的形状以便将它们分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应的值匹配，则可视为样式相同，并在逻辑上将这些形状分组，从而简化后续的样式管理。

**是否可以将一组自定义形状样式保存到单独的文件，以便在其他演示文稿中复用？**

可以。将带有所需样式的示例形状存储在模板幻灯片或 .POTX 模板文件中。创建新演示文稿时，打开该模板，克隆需要的已样式化形状，并在需要的地方重新应用其格式。