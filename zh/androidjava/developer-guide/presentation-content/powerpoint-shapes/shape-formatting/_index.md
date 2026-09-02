---
title: 在 Android 上格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/androidjava/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 草图效果
- 形状线条草图
- 格式化连接样式
- 渐变填充
- 图案填充
- 图片填充
- 纹理填充
- 纯色填充
- 形状透明度
- 黑白形状渲染
- 灰度形状渲染
- 旋转形状
- 3D 倾角效果
- 3D 旋转效果
- 重置格式
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何在 Android 上使用 Aspose.Slides 格式化 PowerPoint 形状——精确且完全控制地为 PPT、PPTX 和 ODP 文件设置填充、线条和效果样式。"
---
## **简介**

在 PowerPoint 中，您可以向幻灯片中添加形状。由于形状由线组成，您可以通过修改或应用效果到其轮廓来格式化它们。此外，您还可以通过指定控制内部填充方式的设置来格式化形状。

![PowerPoint 中的形状格式](format-shape-powerpoint.png)

Aspose.Slides for Android via Java 提供的接口和方法，使您能够使用 PowerPoint 中相同的选项来格式化形状。

## **格式化线条**

使用 Aspose.Slides，您可以为形状指定自定义线条样式。以下步骤概述了该过程：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
1. 设置形状的 [line style](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/linestyle/)。
1. 设置线宽。
1. 设置线条的 [dash style](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/linedashstyle/)。
1. 设置形状的线条颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

```java
import com.aspose.slides.*;
import java.awt.Color;

// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个矩形类型的自动形状。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 移除矩形形状的填充，以便仅显示其线条。
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

![演示文稿中格式化的线条](formatted-lines.png)

## **为形状线条应用草图效果**

草图效果使形状线条看起来像手绘。使用 [IShape.getLineFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/) 访问线条设置，使用 [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilineformat/) 访问草图设置，并使用 [ISketchFormat.setSketchType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isketchformat/) 从 [LineSketchType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/linesketchtype/) 枚举中选择值。

以下 Java 代码演示如何应用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/linesketchtype/) 效果，读取明确分配的值，以及使用 [LineSketchType.None](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/linesketchtype/) 删除该效果：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // 访问形状的线条格式及其草图格式。
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // 应用草图效果。
    sketchFormat.setSketchType(LineSketchType.Curved);

    // 读取直接分配给形状的草图效果。
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // 移除草图效果。
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

由 [ISketchFormat.getSketchType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isketchformat/) 返回的值表示直接分配给形状的设置。如果线条格式可以从主题、母版幻灯片或布局幻灯片继承，请使用 [ILineFormat.getEffective](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilineformat/)，访问 [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilineformateffectivedata/)，并读取 [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isketchformateffectivedata/)。有效值反映在解决继承后实际应用的格式：

```java
import com.aspose.slides.*;

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

* 圆形
* 斜接
* 倒角

默认情况下，PowerPoint 在将两条线在角度处（例如形状的拐角）连接时使用 **Round** 设置。但是，如果您绘制的是具有尖锐角度的形状，可能更倾向于 **Miter** 选项。

![演示文稿中的连接样式](join-style-powerpoint.png)

以下 Java 代码演示如何使用 Miter、Bevel 和 Round 连接类型设置创建图中所示的三个矩形：

```java
import com.aspose.slides.*;
import java.awt.Color;

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

在 PowerPoint 中，渐变填充是一种格式化选项，允许您对形状应用连续的颜色渐变。例如，您可以以一种颜色逐渐淡入另一个颜色的方式应用两种或多种颜色。

以下是使用 Aspose.Slides 对形状应用渐变填充的方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/filltype/) 设置为 `Gradient`。
1. 使用 [IGradientFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/igradientformat/) 接口公开的渐变停止集合的 `add` 方法，添加您偏好的两种颜色并指定位置。
1. 将修改后的演示文稿保存为 PPTX 文件。

```java
import com.aspose.slides.*;

// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个椭圆类型的自动形状。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 对椭圆应用渐变格式。
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

![带渐变填充的椭圆](gradient-fill.png)

## **图案填充**

在 PowerPoint 中，图案填充是一种格式化选项，允许您对形状应用双颜色设计，例如点、条纹、交叉线或格子。您可以为图案的前景色和背景色自定义颜色。

Aspose.Slides 提供超过 45 种预定义的图案样式，您可以将其应用于形状以增强演示文稿的视觉效果。即使选择了预定义图案，仍可指定其使用的精确颜色。

以下是使用 Aspose.Slides 对形状应用图案填充的方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/filltype/) 设置为 `Pattern`。
1. 从预定义选项中选择一种图案样式。
1. 设置图案的 [Background Color](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/patternformat/#getBackColor--)。
1. 设置图案的 [Foreground Color](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/patternformat/#getForeColor--)。
1. 将修改后的演示文稿保存为 PPTX 文件。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![带图案填充的矩形](pattern-fill.png)

## **图片填充**

在 PowerPoint 中，图片填充是一种格式化选项，允许您在形状内部插入图像——实际上将图像用作形状的背景。

以下是使用 Aspose.Slides 对形状应用图片填充的方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/filltype/) 设置为 `Picture`。
1. 将图片填充模式设置为 `Tile`（或其他首选模式）。
1. 使用要使用的图像创建一个 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/) 对象。
1. 将图像传递给 `ISlidesPicture.setImage` 方法。
1. 将修改后的演示文稿保存为 PPTX 文件。

![莲花图片](lotus.png)

```java
import com.aspose.slides.*;

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

    // 加载图像并将其添加到演示文稿资源。
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

![带图片填充的形状](picture-fill.png)

### **将图片平铺为纹理**

如果您想将平铺的图片设为纹理并自定义平铺行为，可以使用 [IPictureFillFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/) 接口和 [PictureFillFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/picturefillformat/) 类的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): 设置图片填充模式——`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): 指定平铺在形状内的对齐方式。
- [setTileFlip](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): 控制平铺是水平翻转、垂直翻转还是两者都翻转。
- [setTileOffsetX](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): 设置平铺相对于形状原点的水平偏移（以点为单位）。
- [setTileOffsetY](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): 设置平铺相对于形状原点的垂直偏移（以点为单位）。
- [setTileScaleX](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): 定义平铺的水平缩放比例（百分比）。
- [setTileScaleY](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): 定义平铺的垂直缩放比例（百分比）。

```java
import com.aspose.slides.*;

// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 添加一个矩形自动形状。
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 将形状的填充类型设置为 Picture。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 加载图像并将其添加到演示文稿资源。
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

![平铺选项](tile-options.png)

## **纯色填充**

在 PowerPoint 中，纯色填充是一种格式化选项，用单一均匀的颜色填充形状。这种纯色背景不包含任何渐变、纹理或图案。

以下步骤演示如何使用 Aspose.Slides 对形状应用纯色填充：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/filltype/) 设置为 `Solid`。
1. 为形状分配您首选的填充颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![带纯色填充的形状](solid-color-fill.png)

## **设置透明度**

在 PowerPoint 中，当对形状应用纯色、渐变、图片或纹理填充时，您还可以设置透明度级别，以控制填充的透明度。更高的透明度值会使形状更透明，从而部分显示背景或下层对象。

Aspose.Slides 通过调整填充颜色的 alpha 值来设置透明度。操作步骤如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
1. 将 [FillType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/filltype/) 设置为 `Solid`。
1. 使用 `Color` 定义带透明度的颜色（`alpha` 分量控制透明度）。
1. 保存演示文稿。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![透明形状](shape-transparency.png)

## **旋转形状**

Aspose.Slides 允许您在 PowerPoint 演示文稿中旋转形状。这在对视觉元素进行特定对齐或设计需求的定位时非常有用。

要在幻灯片上旋转形状，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
1. 将形状的 rotation 属性设置为所需的角度。
1. 保存演示文稿。

```java
import com.aspose.slides.*;

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

![形状旋转](shape-rotation.png)

## **添加 3D 倾角效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat] 属性来应用 3D 倾角效果。

要为形状添加 3D 倾角效果，请按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
1. 配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/threedformat/) 以定义倾角设置。
1. 保存演示文稿。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![3D 倾角效果](3D-bevel-effect.png)

## **添加 3D 旋转效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat] 属性来应用 3D 旋转效果。

要对形状应用 3D 旋转：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
1. 使用 [setCameraType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icamera/#setCameraType-int-) 和 [setLightType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) 定义 3D 旋转。
1. 保存演示文稿。

```java
import com.aspose.slides.*;

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

![3D 旋转效果](3D-rotation-effect.png)

## **控制形状的黑白渲染**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) 方法指定在黑白模式下查看或处理演示文稿时，单个形状的呈现方式。该方法本身并不会启用黑白显示，也不会在正常彩色模式下改变形状的填充、线条或其他格式。

使用 [BlackWhiteMode](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/blackwhitemode/) 类中的值选择所需行为。例如，`Automatic` 让渲染应用决定转换方式，`Gray`、`LightGray` 使用灰度，`BlackWhite` 仅使用黑白，`Black`、`White` 强制单色，`Color` 保持正常着色，`Hidden` 在黑白模式下隐藏形状，`NotDefined` 表示未分配形状级别模式。

以下 Java 代码创建了一个彩色形状，并在黑白显示模式下使其呈现为灰色：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // 保持橙色填充在彩色模式下，但在黑白模式下将形状渲染为灰色。
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在正常彩色模式下，矩形保留其橙色填充。在黑白显示工作流中，由于模式设置为 `Gray`，它使用灰色呈现。这样您可以在保留全彩幻灯片的同时，为打印、预览或其他遵循黑白显示设置的工作流定义不同的外观。

## **重置格式**

以下 Java 代码展示如何重置幻灯片的格式，并将 [LayoutSlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/layoutslide/) 上所有带占位符的形状的位置、大小和格式恢复为默认设置：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 重置幻灯片上具有布局占位符的每个形状。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**形状格式化会影响最终的演示文稿文件大小吗？**

影响很小。嵌入的图像和媒体占据了大部分文件空间，而形状的参数如颜色、效果和渐变仅以元数据形式存储，几乎不增加额外大小。

**如何检测幻灯片上具有相同格式的形状以便对其进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值匹配，则视为相同样式，并在逻辑上将这些形状分组，这有助于后续的样式管理。

**我能否将一组自定义形状样式保存到单独的文件，以便在其他演示文稿中重复使用？**

可以。将带有所需样式的示例形状存放在模板幻灯片集或 .POTX 模板文件中。创建新演示文稿时，打开该模板，克隆所需的样式形状，并在需要的地方重新应用其格式。