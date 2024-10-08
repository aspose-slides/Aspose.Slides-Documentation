---
title: 形状格式设置
type: docs
weight: 20
url: /zh/androidjava/shape-formatting/
keywords: "格式化形状, 格式化线条, 格式化连接样式, 渐变填充, 图案填充, 图片填充, 实色填充, 旋转形状, 3d 倒角效果, 3d 旋转效果, PowerPoint 演示文稿, Java, Aspose.Slides for Android via Java"
description: "在 Java 中格式化 PowerPoint 演示文稿中的形状"
---

在 PowerPoint 中，您可以向幻灯片添加形状。由于形状是由线条构成的，您可以通过修改或应用某些效果来格式化形状的组成线条。此外，您还可以通过指定设置来格式化形状，从而确定它们（形状内部区域）是如何填充的。

![format-shape-powerpoint](format-shape-powerpoint.png)



**Aspose.Slides for Android via Java** 提供了允许您根据 PowerPoint 中已知选项格式化形状的接口和属性。

## **格式化线条**

使用 Aspose.Slides，您可以为形状指定首选的线条样式。以下步骤概述了这样的过程：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)。
4. 为形状线条设置颜色。
5. 为形状线条设置宽度。
6. 为形状线条设置 [线条样式](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle)。
7. 为形状线条设置 [虚线样式](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle)。
8. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示了格式化矩形 `AutoShape` 的操作：

```java
// 实例化一个代表演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加矩形类型的自动形状
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 设置矩形形状的填充颜色
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.WHITE);

    // 对矩形的线条应用一些格式
    shp.getLineFormat().setStyle(LineStyle.ThickThin);
    shp.getLineFormat().setWidth(7);
    shp.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // 设置矩形的线条颜色
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // 将 PPTX 文件写入磁盘
    pres.save("RectShpLn_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **格式化连接样式**
以下是 3 种连接类型选项：

* 圆角
* 尖角
* 倒角

默认情况下，当 PowerPoint 在角度（或形状的角落）处连接两条线时，它使用 **圆角** 设置。然而，如果您希望绘制具有非常尖锐角度的形状，您可能想选择 **尖角**。

![join-style-powerpoint](join-style-powerpoint.png)

以下 Java 代码演示了使用尖角、倒角和圆角连接类型设置创建 3 个矩形（如上图）：

```java
// 实例化一个代表演示文稿文件的演示文稿类
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

    // 设置线条宽度
    shp1.getLineFormat().setWidth(15);
    shp2.getLineFormat().setWidth(15);
    shp3.getLineFormat().setWidth(15);

    // 设置矩形的线条颜色
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

    // 向每个矩形添加文本
    ((IAutoShape)shp1).getTextFrame().setText("尖角连接样式");
    ((IAutoShape)shp2).getTextFrame().setText("倒角连接样式");
    ((IAutoShape)shp3).getTextFrame().setText("圆角连接样式");

    // 将 PPTX 文件写入磁盘
    pres.save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **渐变填充**
在 PowerPoint 中，渐变填充是一种格式选项，允许您对形状应用颜色的连续混合。例如，您可以应用两种或多种颜色设置，其中一种颜色逐渐淡化并改变为另一种颜色。

以下是使用 Aspose.Slides 为形状应用渐变填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) 设置为 `Gradient`。
5. 使用与 `GradientFormat` 类相关的 `GradientStops` 集合中公开的 `Add` 方法添加您首选的 2 种颜色及其定义的位置。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示了在椭圆上使用渐变填充效果的操作：

```java
// 实例化一个代表演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加一个椭圆自动形状
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // 将渐变格式应用于椭圆
    shp.getFillFormat().setFillType(FillType.Gradient);
    shp.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // 设置渐变的方向
    shp.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // 添加 2 个渐变停止点
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shp.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // 将 PPTX 文件写入磁盘
    pres.save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **图案填充**
在 PowerPoint 中，图案填充是一种格式选项，允许您对形状应用由点、条纹、交叉线或格子组成的两种颜色设计。此外，您可以选择图案前景和背景的首选颜色。

Aspose.Slides 提供了 45 种以上的预定义样式，可用于格式化形状并丰富演示文稿。即使在选择预定义图案后，您仍然可以指定图案必须包含的颜色。

以下是使用 Aspose.Slides 为形状应用图案填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) 设置为 `Pattern`。
5. 为形状设置您首选的图案样式。 
6. 为 [PatternFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat) 设置 [背景色](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat#getBackColor--)。
7. 为 [PatternFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat) 设置 [前景色](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternFormat#getForeColor--)。
8. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示了使用图案填充美化矩形的操作：

```java
// 实例化一个代表演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加一个矩形自动形状
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 设置填充类型为图案
    shp.getFillFormat().setFillType(FillType.Pattern);

    // 设置图案样式
    shp.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // 设置图案的背景色和前景色
    shp.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shp.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // 将 PPTX 文件写入磁盘
    pres.save("RectShpPatt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **图片填充**
在 PowerPoint 中，图片填充是一种格式选项，允许您在形状内部放置图片。实质上，您可以将一张图片作为形状的背景使用。

以下是使用 Aspose.Slides 用图片填充形状的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) 设置为 `Picture`。
5. 设置图片填充模式为 Tile。
6. 使用将用于填充形状的图片创建一个 `IPPImage` 对象。
7. 将 `Picture.Image` 属性设置为最近创建的 `IPPImage`。
8. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码显示了如何用图片填充形状：

```java
// 实例化一个代表演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加一个矩形自动形状
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
在 PowerPoint 中，实色填充是一种格式选项，允许您用单一的颜色填充形状。所选择的颜色通常是一种纯色。该颜色会应用于形状背景，并可包含任何特殊效果或修改。

以下是使用 Aspose.Slides 为形状应用实色填充的方法：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) 设置为 `Solid`。
5. 为形状设置您的首选颜色。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码显示了如何将实色填充应用于 PowerPoint 中的方框：

```java
// 实例化一个代表演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加一个矩形自动形状
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

在 PowerPoint 中，当您用实色、渐变、图片或纹理填充形状时，您可以指定透明度级别，以确定填充的透明度。例如，如果您设定一个较低的透明度级别，幻灯片对象或背景（形状）将透过显示。

Aspose.Slides 允许您以如下方式设置形状的透明度级别：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)。
4. 使用 `new Color` 设置 alpha 组件。
5. 将对象保存为 PowerPoint 文件。 

以下 Java 代码演示了该过程：

```java
// 实例化一个代表演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加一个实心形状
    IShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // 在实心形状上添加一个透明形状
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
Aspose.Slides 允许您按如下方式旋转添加到幻灯片中的形状： 

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)。
4. 按需要的度数旋转形状。 
5. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码显示了如何将形状旋转 90 度：

```java
// 实例化一个代表演示文稿文件的演示文稿类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加一个矩形自动形状
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 将形状旋转 90 度
    shp.setRotation(90);

    // 将 PPTX 文件写入磁盘
    pres.save("RectShpRot_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **添加 3D 倒角效果**
Aspose.Slides 允许您通过修改形状的 [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) 属性来为形状添加 3D 倒角效果，具体步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)。
4. 设置您首选的形状 [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) 属性的参数。
5. 将演示文稿写入磁盘。

以下 Java 代码显示了如何为形状添加 3D 倒角效果：

```java
// 创建一个 Presentation 类的实例
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

    // 将演示文稿保存为 PPTX 文件
    pres.save("Bavel_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **添加 3D 旋转效果**
Aspose.Slides 允许您通过修改形状的 [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) 属性来应用 3D 旋转效果，具体步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)。
4. 为 [CameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICamera#getCameraType--) 和 [LightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRig#getLightType--) 指定首选的数值。
5. 将演示文稿写入磁盘。 

以下 Java 代码显示了如何将 3D 旋转效果应用于形状：

```java
// 创建一个 Presentation 类的实例
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

    // 将演示文稿保存为 PPTX 文件
    pres.save("Rotation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **重置格式**

以下 Java 代码显示了如何在幻灯片中重置格式，并将每个具有占位符的形状的位置、大小和格式恢复到其默认值：

```java
Presentation pres = new Presentation();
try {
    for (ISlide slide : pres.getSlides())
    {
        // 每个具有布局的占位符的幻灯片上的形状将被恢复
        slide.reset();
    }
} finally {
    if (pres != null) pres.dispose();
}
```