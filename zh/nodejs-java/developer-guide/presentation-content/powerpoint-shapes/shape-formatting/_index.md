---
title: 在 JavaScript 中格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/nodejs-java/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 素描效果
- 素描形状线条
- 格式化连接样式
- 渐变填充
- 图案填充
- 图片填充
- 纹理填充
- 纯色填充
- 形状透明度
- 旋转形状
- 3D 凸面效果
- 3D 旋转效果
- 重置格式
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中格式化 PowerPoint 形状——精确且完整地设置 PPT、PPTX 和 ODP 文件的填充、线条和效果样式。"
---
## **简介**

在 PowerPoint 中，你可以向幻灯片添加形状。由于形状由线条组成，你可以通过修改或应用效果来格式化它们的轮廓。此外，你还可以通过指定控制内部填充方式的设置来格式化形状。

![格式化形状 PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java 提供的类和方法，使你能够使用 PowerPoint 中的相同选项对形状进行格式化。

## **格式化线条**

使用 Aspose.Slides，你可以为形状指定自定义线条样式。以下步骤概述了操作流程：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
1. 设置形状的 [line style](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/linestyle/)。
1. 设置线宽。
1. 设置线条的 [dash style](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/linedashstyle/)。
1. 为形状设置线条颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下代码演示了如何格式化一个矩形 `AutoShape`：

```js
// 实例化表示演示文稿文件的 Presentation 类。
let presentation = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片。
    let slide = presentation.getSlides().get_Item(0);

    // 添加一个矩形类型的自动形状。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // 设置矩形形状的填充颜色。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // 对矩形的线条应用格式化。
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // 设置矩形线条的颜色。
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // 将 PPTX 文件保存到磁盘。
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![演示文稿中已格式化的线条](formatted-lines.png)

## **对形状线条应用素描效果**

素描效果使形状线条看起来像手绘。使用 [Shape.getLineFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/) 访问线条设置，使用 [LineFormat.getSketchFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/lineformat/) 访问素描设置，并使用 [SketchFormat.setSketchType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sketchformat/) 从 [LineSketchType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/linesketchtype/) 枚举中选择值。

以下 JavaScript 代码展示了如何应用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/linesketchtype/) 效果，读取显式分配的值，以及使用 [LineSketchType.None](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/linesketchtype/) 删除该效果：

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // 访问形状的线条格式及其素描格式。
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // 应用素描效果。
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // 读取直接分配给形状的素描效果。
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // 移除素描效果。
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sketchformat/) 返回的值表示直接分配给形状的设置。如果线条格式可以从主题、母版幻灯片或布局幻灯片继承，请使用 [LineFormat.getEffective](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/lineformat/)，对返回的对象调用 `getSketchFormat`，然后调用其 `getSketchType` 方法。有效值反映了解决继承后实际应用的格式：

```js
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **格式化连接样式**

以下是三种连接类型选项：

* 圆角
* 斜接
* 斜角

默认情况下，当 PowerPoint 在角度处（例如形状的拐角）连接两条线时，使用 **Round** 设置。但如果你绘制的是锐角形状，可能更喜欢 **Miter** 选项。

![演示文稿中的连接样式](join-style-powerpoint.png)

以下 JavaScript 代码演示了如何使用斜接、斜角和圆角连接类型设置创建文中所示的三个矩形：

```js
// 实例化表示演示文稿文件的 Presentation 类。
let presentation = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片。
    let slide = presentation.getSlides().get_Item(0);

    // 添加三个矩形类型的自动形状。
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // 为每个矩形形状设置填充颜色。
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // 设置线宽。
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // 为每个矩形的线条设置颜色。
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // 设置连接样式。
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // 为每个矩形添加文本。
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // 将 PPTX 文件保存到磁盘。
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **渐变填充**

在 PowerPoint 中，渐变填充是一种格式化选项，允许你对形状应用连续的颜色混合。例如，你可以以一种颜色逐渐淡入另一种颜色的方式应用两种或多种颜色。

以下是使用 Aspose.Slides 对形状应用渐变填充的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/filltype/) 设置为 `Gradient`。
1. 使用由 [GradientFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/gradientformat/) 类公开的渐变停靠集合的 `add` 方法，添加两个首选颜色并定义位置。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 JavaScript 代码演示了如何对椭圆应用渐变填充效果：

```js
// 实例化表示演示文稿文件的 Presentation 类。
let presentation = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片。
    let slide = presentation.getSlides().get_Item(0);

    // 添加一个椭圆类型的自动形状。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // 对椭圆应用渐变格式。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // 设置渐变的方向。
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // 添加两个渐变停止点。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // 将 PPTX 文件保存到磁盘。
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![带有渐变填充的椭圆](gradient-fill.png)

## **图案填充**

在 PowerPoint 中，图案填充是一种格式化选项，允许你对形状应用由两种颜色组成的图案——如点、条纹、交叉线或方格。你可以为图案的前景色和背景色自定义颜色。

Aspose.Slides 提供超过 45 种预定义图案样式，可用于提升演示文稿的视觉效果。即使选择了预定义图案，你仍然可以指定其使用的确切颜色。

以下是使用 Aspose.Slides 对形状应用图案填充的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/filltype/) 设置为 `Pattern`。
1. 从预定义选项中选择一种图案样式。
1. 设置图案的 [Background Color](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/patternformat/#getBackColor--)。
1. 设置图案的 [Foreground Color](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/patternformat/#getForeColor--)。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 JavaScript 代码演示了如何对矩形应用图案填充：

```js
// 实例化表示演示文稿文件的 Presentation 类。
let presentation = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片。
    let slide = presentation.getSlides().get_Item(0);

    // 添加一个矩形类型的自动形状。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 将填充类型设置为 Pattern。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // 设置图案样式。
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // 设置图案的背景色和前景色。
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // 将 PPTX 文件保存到磁盘。
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![带有图案填充的矩形](pattern-fill.png)

## **图片填充**

在 PowerPoint 中，图片填充是一种格式化选项，允许你在形状内部插入图像——实际上将图像用作形状的背景。

以下是使用 Aspose.Slides 对形状应用图片填充的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/filltype/) 设置为 `Picture`。
1. 将图片填充模式设置为 `Tile`（或其他首选模式）。
1. 使用要使用的图像创建一个 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/) 对象。
1. 将图像传递给 `ISlidesPicture.setImage` 方法。
1. 将修改后的演示文稿保存为 PPTX 文件。

假设我们有一个名为 “lotus.png” 的文件，其图片如下：

![莲花图片](lotus.png)

以下 JavaScript 代码演示了如何使用图片填充形状：

```js
// 实例化表示演示文稿文件的 Presentation 类。
let presentation = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片。
    let slide = presentation.getSlides().get_Item(0);

    // 添加一个矩形类型的自动形状。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 将填充类型设置为 Picture。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // 设置图片填充模式。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // 加载图像并将其添加到演示文稿资源。
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // 设置图片。
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 将 PPTX 文件保存到磁盘。
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![带有图片填充的形状](picture-fill.png)

### **将图片平铺为纹理**

如果你想将平铺的图片设置为纹理并自定义平铺行为，可以使用 [PictureFillFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/) 类的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode)：设置图片填充模式——`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平铺在形状内部的对齐方式。
- [setTileFlip](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#setTileFlip)：控制平铺是水平翻转、垂直翻转还是两者皆翻转。
- [setTileOffsetX](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX)：设置平铺相对于形状原点的水平偏移（以点为单位）。
- [setTileOffsetY](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY)：设置平铺相对于形状原点的垂直偏移（以点为单位）。
- [setTileScaleX](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX)：定义平铺的水平比例（百分比）。
- [setTileScaleY](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY)：定义平铺的垂直比例（百分比）。

以下代码示例展示了如何添加一个带有平铺图片填充的矩形形状并配置平铺选项：

```js
// 实例化表示演示文稿文件的 Presentation 类。
let presentation = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片。
    let firstSlide = presentation.getSlides().get_Item(0);

    // 添加一个矩形自动形状。
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // 将形状的填充类型设置为 Picture。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // 加载图像并将其添加到演示文稿资源。
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 将图像分配给形状。
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // 配置图片填充模式和铺砖属性。
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // 将 PPTX 文件保存到磁盘。
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![平铺选项](tile-options.png)

## **纯色填充**

在 PowerPoint 中，纯色填充是一种格式化选项，用单一、均匀的颜色填充形状。这种纯色背景不包含任何渐变、纹理或图案。

使用 Aspose.Slides 对形状应用纯色填充的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/filltype/) 设置为 `Solid`。
1. 为形状分配你首选的填充颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 JavaScript 代码演示了如何对 PowerPoint 幻灯片中的矩形应用纯色填充：

```js
// 实例化表示演示文稿文件的 Presentation 类。
let presentation = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片。
    let slide = presentation.getSlides().get_Item(0);

    // 添加一个矩形类型的自动形状。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 将填充类型设置为 Solid。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // 设置填充颜色。
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // 将 PPTX 文件保存到磁盘。
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![带有纯色填充的形状](solid-color-fill.png)

## **设置透明度**

在 PowerPoint 中，对形状应用纯色、渐变、图片或纹理填充时，你还可以设置透明度级别以控制填充的不透明度。更高的透明度值会使形状更加半透明，从而部分显示背景或下层对象。

Aspose.Slides 通过调整用于填充的颜色的 alpha 值来设置透明度。操作步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
1. 将 [FillType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/filltype/) 设置为 `Solid`。
1. 使用 `Color` 定义具有透明度的颜色（`alpha` 分量控制透明度）。
1. 保存演示文稿。

以下 JavaScript 代码演示了如何对矩形应用透明填充颜色：

```js
// 实例化表示演示文稿文件的 Presentation 类。
let presentation = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片。
    let slide = presentation.getSlides().get_Item(0);

    // 添加一个实心矩形自动形状。
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 在实心形状上添加一个透明矩形自动形状。
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // 将 PPTX 文件保存到磁盘。
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![透明形状](shape-transparency.png)

## **旋转形状**

Aspose.Slides 允许在 PowerPoint 演示文稿中旋转形状。这在需要特定对齐或设计需求的视觉元素定位时非常有用。

要在幻灯片上旋转形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
1. 将形状的旋转属性设置为所需的角度。
1. 保存演示文稿。

以下 JavaScript 代码演示了如何将形状旋转 5 度：

```js
// 实例化表示演示文稿文件的 Presentation 类。
let presentation = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片。
    let slide = presentation.getSlides().get_Item(0);

    // 添加一个矩形类型的自动形状。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 将形状旋转 5 度。
    shape.setRotation(5);

    // 将 PPTX 文件保存到磁盘。
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![形状旋转](shape-rotation.png)

## **添加 3D 凸面效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/) 属性来为形状添加 3D 凸面效果。

为形状添加 3D 凸面效果的步骤如下：

1. 实例化 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
1. 配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/) 以定义凸面设置。
1. 保存演示文稿。

以下 JavaScript 代码展示了如何对形状应用 3D 凸面效果：

```js
// 创建 Presentation 类的实例。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 向幻灯片添加形状。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // 设置形状的 ThreeDFormat 属性。
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // 将演示文稿保存为 PPTX 文件。
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![3D 凸面效果](3D-bevel-effect.png)

## **添加 3D 旋转效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/threedformat/) 属性来为形状添加 3D 旋转效果。

要对形状应用 3D 旋转：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。
1. 使用 [setCameraType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/camera/#setCameraType) 和 [setLightType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/lightrig/#setLightType) 定义 3D 旋转。
1. 保存演示文稿。

以下 JavaScript 代码演示了如何对形状应用 3D 旋转效果：

```js
// 创建 Presentation 类的实例。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // 将演示文稿保存为 PPTX 文件。
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![3D 旋转效果](3D-rotation-effect.png)

## **重置格式**

以下 Java 代码展示了如何重置幻灯片的格式，并将 [LayoutSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutslide/) 上所有占位符形状的位置、大小和格式恢复为默认设置：

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // 重置幻灯片上每个在布局中具有占位符的形状。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**形状格式化会影响最终演示文稿文件大小吗？**

影响极小。嵌入的图像和媒体占据了大部分文件空间，而颜色、效果和渐变等形状参数以元数据形式存储，几乎不增加额外大小。

**如何检测幻灯片上具有相同格式的形状以便对其进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值都匹配，则视为样式相同，可在逻辑上将这些形状分组，从而简化后续的样式管理。

**我可以将一组自定义形状样式保存到单独的文件，以在其他演示文稿中重复使用吗？**

可以。将带有所需样式的示例形状存放在模板幻灯片或 .POTX 模板文件中。创建新演示文稿时，打开该模板，克隆所需的已样式化形状，并在需要的地方重新应用其格式。