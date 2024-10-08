---
title: 形状格式化
type: docs
weight: 20
url: /java/shape-formatting/
keywords: "格式化形状, 格式化线条, 格式化连接样式, 渐变填充, 图案填充, 图片填充, 实色填充, 旋转形状, 3d 内凹效果, 3d 旋转效果, PowerPoint 演示, Java, Aspose.Slides for Java"
description: "在 Java 的 PowerPoint 演示中格式化形状"
---

在 PowerPoint 中，您可以向幻灯片添加形状。由于形状是由线条构成的，因此您可以通过修改或应用某些效果到它们的组成线条来格式化形状。此外，您还可以通过指定设置来格式化形状，这些设置决定它们（形状内部的区域）如何填充。

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides for Java** 提供了接口和属性，允许您基于 PowerPoint 中已知的选项格式化形状。

## **格式化线条**

使用 Aspose.Slides，您可以为形状指定首选线条样式。以下步骤概述了这种过程：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)。
4. 为形状的线条设置颜色。
5. 为形状的线条设置宽度。
6. 为形状的线条设置 [线条样式](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle)。
7. 为形状的线条设置 [虚线样式](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle)。
8. 将修改后的演示文稿作为 PPTX 文件写入。

此 Java 代码演示了我们格式化矩形 `AutoShape` 的操作：

```java
// 实例化表示演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加矩形类型的自动形状
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 设置矩形形状的填充颜色
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.WHITE);

    // 在矩形的线条上应用一些格式
    shp.getLineFormat().setStyle(LineStyle.ThickThin);
    shp.getLineFormat().setWidth(7);
    shp.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // 设置矩形线条的颜色
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // 将 PPTX 文件写入磁盘
    pres.save("RectShpLn_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **格式化连接样式**
这些是 3 种连接类型选项：

* 圆角
* 斜接
* 内凹

默认情况下，当 PowerPoint 在角度（或形状的角落）连接两条线时，使用 **圆角** 设置。然而，如果您希望绘制一个有非常尖锐角度的形状，您可能想选择 **斜接**。

![join-style-powerpoint](join-style-powerpoint.png)

这段 Java 代码演示了一项操作，其中创建了 3 个矩形（上图）并使用斜接、内凹和圆角连接类型设置：

```java
// 实例化表示演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {

    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加 3 个矩形自动形状
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
    IShape shp3 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

    // 设置矩形形状的填充颜色
    shp1.getFillFormat().setFillType(FillType.Solid);
    shp1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp3.getFillFormat().setFillType(FillType.Solid);
    shp3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // 设置线条的宽度
    shp1.getLineFormat().setWidth(15);
    shp2.getLineFormat().setWidth(15);
    shp3.getLineFormat().setWidth(15);

    // 设置矩形线条的颜色
    shp1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shp3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // 设置连接样式
    shp1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shp2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shp3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // 在每个矩形上添加文本
    ((IAutoShape)shp1).getTextFrame().setText("斜接连接样式");
    ((IAutoShape)shp2).getTextFrame().setText("内凹连接样式");
    ((IAutoShape)shp3).getTextFrame().setText("圆角连接样式");

    // 将 PPTX 文件写入磁盘
    pres.save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **渐变填充**
在 PowerPoint 中，渐变填充是一个格式选项，允许您对形状应用颜色的连续混合。例如，您可以在一个设置中应用两种或多种颜色，其中一种颜色逐渐淡化并变成另一种颜色。

这就是如何使用 Aspose.Slides 对形状应用渐变填充：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) 设置为 `Gradient`。
5. 使用与 `GradientFormat` 类相关的 `GradientStops` 集合公开的 `Add` 方法添加 2 种首选颜色及其定义位置。
6. 将修改后的演示文稿作为 PPTX 文件写入。

此 Java 代码演示了一项操作，其中在椭圆形上使用了渐变填充效果：

```java
// 实例化表示演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加椭圆形自动形状
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // 应用渐变格式到椭圆
    shp.getFillFormat().setFillType(FillType.Gradient);
    shp.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // 设置渐变的方向
    shp.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // 添加 2 个渐变停靠点
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // 将 PPTX 文件写入磁盘
    pres.save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **图案填充**
在 PowerPoint 中，图案填充是一个格式选项，允许您对形状应用由点、条纹、交叉图案或棋格构成的双色设计。此外，您可以选择图案前景和背景的首选颜色。

Aspose.Slides 提供了超过 45 种预定义样式，可用于格式化形状并丰富演示文稿。即使在选择了预定义图案后，您仍然可以指定图案必须包含的颜色。

这就是如何使用 Aspose.Slides 对形状应用图案填充：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) 设置为 `Pattern`。
5. 设置形状的首选图案样式。
6. 设置 [PatternFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getBackColor--) 的 [背景颜色](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getBackColor--)。
7. 设置 [前景颜色](https://reference.aspose.com/slides/java/com.aspose.slides/PatternFormat#getForeColor--)。
8. 将修改后的演示文稿作为 PPTX 文件写入。

此 Java 代码演示了一项操作，其中使用图案填充美化矩形：

```java
// 实例化表示演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加矩形自动形状
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 设置填充类型为图案
    shp.getFillFormat().setFillType(FillType.Pattern);

    // 设置图案样式
    shp.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // 设置图案的背景和前景颜色
    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // 将 PPTX 文件写入磁盘
    pres.save("RectShpPatt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **图片填充**
在 PowerPoint 中，图片填充是一个格式选项，允许您在形状内放置图片。换句话说，您可以使用图片作为形状的背景。

这就是如何使用 Aspose.Slides 用图片填充形状：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) 设置为 `Picture`。
5. 设置图片填充模式为 Tile。
6. 使用将用于填充形状的图片创建 `IPPImage` 对象。
7. 将 `PictureFillFormat` 对象的 `Picture.Image` 属性设置为最近创建的 `IPPImage`。
8. 将修改后的演示文稿作为 PPTX 文件写入。

此 Java 代码向您展示了如何用图片填充形状：

```java
// 实例化表示演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加矩形自动形状
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    
    // 设置填充类型为图片
    shp.getFillFormat().setFillType(FillType.Picture);

    // 设置图片填充模式
    shp.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // 设置图片
    IPPImage picture;
    IImage image = Images.fromFile("Tulips.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    shp.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 将 PPTX 文件写入磁盘
    pres.save("RectShpPic_out.pptx", SaveFormat.Pptx);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **实色填充**
在 PowerPoint 中，实色填充是一个格式选项，允许您用单一颜色填充形状。所选颜色通常是纯色。该颜色将应用于形状背景，带有任何特殊效果或修改。

这就是如何使用 Aspose.Slides 对形状应用实色填充：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) 设置为 `Solid`。
5. 为形状设置首选颜色。
6. 将修改后的演示文稿作为 PPTX 文件写入。

此 Java 代码向您展示了如何在 PowerPoint 中应用实色填充到一个框中：

```java
// 实例化表示演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加矩形自动形状
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 设置填充类型为实色
    shape.getFillFormat().setFillType(FillType.Solid);

    // 设置矩形的颜色
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // 将 PPTX 文件写入磁盘
    pres.save("RectShpSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置透明度**

在 PowerPoint 中，当您用实色、渐变、图片或纹理填充形状时，可以指定透明度级别，以确定填充的透明度。例如，如果您设置一个较低的透明度级别，则幻灯片对象或背景（形状）将透过显示。

Aspose.Slides 允许您以以下方式为形状设置透明度级别：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)。
4. 使用 `new Color` 设置 alpha 组件。
5. 将对象另存为 PowerPoint 文件。

此 Java 代码演示了该过程：

```java
// 实例化表示演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加实形
    IShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // 在实形上添加一个透明形状
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(204, 102, 0, 128));
    
    // 将 PPTX 文件写入磁盘
    pres.save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **旋转形状**
Aspose.Slides 允许您以以下方式旋转添加到幻灯片的形状：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)。
4. 按所需度数旋转形状。
5. 将修改后的演示文稿作为 PPTX 文件写入。

此 Java 代码向您展示了如何将形状旋转 90 度：

```java
// 实例化表示演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加矩形自动形状
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 将形状旋转 90 度
    shp.setRotation(90);

    // 将 PPTX 文件写入磁盘
    pres.save("RectShpRot_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **添加 3D 内凹效果**
Aspose.Slides 允许您通过修改其 [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) 属性，以此方式为形状添加 3D 内凹效果：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)。
3. 为形状的 [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) 属性设置首选参数。
4. 将演示文稿写入磁盘。

此 Java 代码向您展示了如何为形状添加 3D 内凹效果：

```java
// 创建演示文稿类的实例
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // 向幻灯片添加一个形状
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    ILineFillFormat format = shape.getLineFormat().getFillFormat();
    format.setFillType(FillType.Solid);
    format.getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // 设置形状的 ThreeDFormat 属性
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // 将演示文稿作为 PPTX 文件写入
    pres.save("Bavel_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **添加 3D 旋转效果**
Aspose.Slides 允许您通过修改其 [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) 属性，以此方式为形状应用 3D 旋转效果：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)。
3. 为 [CameraType](https://reference.aspose.com/slides/java/com.aspose.slides/ICamera#getCameraType--) 和 [LightType](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRig#getLightType--) 指定首选参数。
4. 将演示文稿写入磁盘。

此 Java 代码向您展示了如何为形状应用 3D 旋转效果：

```java
// 创建演示文稿类的实例
Presentation pres = new Presentation();
try {
    IShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(0, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // 将演示文稿作为 PPTX 文件写入
    pres.save("Rotation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **重置格式**

此 Java 代码向您展示了如何重置幻灯片中的格式，并将每个在 [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutSlide) 上有占位符的形状的位置、大小和格式恢复为默认值：

```java
Presentation pres = new Presentation();
try {
    for (ISlide slide : pres.getSlides())
    {
        // 幻灯片中每个在布局上有占位符的形状将被还原
        slide.reset();
    }
} finally {
    if (pres != null) pres.dispose();
}
```