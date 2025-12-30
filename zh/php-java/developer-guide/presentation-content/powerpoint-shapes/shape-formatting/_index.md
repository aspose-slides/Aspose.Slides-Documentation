---
title: 在 PHP 中格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/php-java/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 格式化连接样式
- 渐变填充
- 图案填充
- 图片填充
- 纹理填充
- 实色填充
- 形状透明度
- 旋转形状
- 3D 凸缘效果
- 3D 旋转效果
- 重置格式
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 PHP 中格式化 PowerPoint 形状——为 PPT、PPTX 和 ODP 文件精确且完全控制地设置填充、线条和效果样式。"
---

## **概述**

在 PowerPoint 中，您可以向幻灯片添加形状。由于形状由线条组成，您可以通过修改或应用效果来格式化它们的轮廓。此外，您还可以通过指定内部填充方式来格式化形状。

![PowerPoint 中的形状格式化](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java 提供的类和方法使您能够使用 PowerPoint 中相同的选项来格式化形状。

## **格式化线条**

使用 Aspose.Slides，您可以为形状指定自定义线条样式。以下步骤概述了该过程：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
1. 设置形状的 [line style](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/)。
1. 设置线宽。
1. 设置线的 [dash style](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/)。
1. 设置形状的线条颜色。
1. 将修改后的演示文稿另存为 PPTX 文件。

以下 PHP 代码演示如何格式化矩形 `AutoShape`：
```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 添加一个矩形类型的自动形状。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // 设置矩形形状的填充颜色。
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // 对矩形的线条应用格式设置。
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // 设置矩形线条的颜色。
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // 将 PPTX 文件保存到磁盘。
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


结果：

![演示文稿中格式化的线条](formatted-lines.png)

## **格式化连接样式**

下面是三种连接类型选项：

* Round（圆形）
* Miter（斜角）
* Bevel（斜面）

默认情况下，当 PowerPoint 在角度处（例如形状的拐角）连接两条线时，使用 **Round** 设置。但是，如果您绘制的是锐角形状，可能更倾向于使用 **Miter** 选项。

![演示文稿中的连接样式](join-style-powerpoint.png)

以下 PHP 代码演示如何使用 Miter、Bevel 和 Round 连接类型设置创建上图所示的三个矩形：
```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 添加三个矩形类型的自动形状。
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // 为每个矩形形状设置填充颜色。
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // 设置线宽。
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // 为每个矩形的线条设置颜色。
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // 设置连接样式。
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // 为每个矩形添加文本。
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // 将 PPTX 文件保存到磁盘。
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **渐变填充**

在 PowerPoint 中，渐变填充是一种格式化选项，允许您对形状应用连续的颜色混合。例如，您可以以一种颜色逐渐淡入另一种颜色的方式应用两种或多种颜色。

以下是使用 Aspose.Slides 对形状应用渐变填充的方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 设置为 `Gradient`。
1. 使用 [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/) 类公开的渐变停止集合的 `add` 方法，按定义的位置添加您偏好的两种颜色。
1. 将修改后的演示文稿另存为 PPTX 文件。

以下 PHP 代码演示如何为椭圆应用渐变填充效果：
```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 添加一个椭圆类型的自动形状。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // 对椭圆应用渐变格式。
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // 设置渐变的方向。
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // 添加两个渐变停止点。
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // 将 PPTX 文件保存到磁盘。
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


结果：

![具有渐变填充的椭圆](gradient-fill.png)

## **图案填充**

在 PowerPoint 中，图案填充是一种格式化选项，允许您对形状应用双色设计——如点、条纹、交叉线或方格。您可以为图案的前景色和背景色选择自定义颜色。

Aspose.Slides 提供超过 45 种预定义图案样式，您可以将其应用于形状以提升演示文稿的视觉效果。即使选择了预定义图案，仍可指定其使用的精确颜色。

以下是使用 Aspose.Slides 对形状应用图案填充的步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 设置为 `Pattern`。
1. 从预定义选项中选择图案样式。
1. 设置图案的 [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor)。
1. 设置图案的 [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor)。
1. 将修改后的演示文稿另存为 PPTX 文件。

以下 PHP 代码演示如何为矩形应用图案填充：
```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 添加一个矩形类型的自动形状。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 将填充类型设为 Pattern。
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // 设置图案样式。
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // 设置图案的背景色和前景色。
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // 将 PPTX 文件保存到磁盘。
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


结果：

![具有图案填充的矩形](pattern-fill.png)

## **图片填充**

在 PowerPoint 中，图片填充是一种格式化选项，允许您在形状内部插入图像——相当于将该图像用作形状的背景。

以下是使用 Aspose.Slides 对形状应用图片填充的方法：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 设置为 `Picture`。
1. 将图片填充模式设置为 `Tile`（或其他首选模式）。
1. 使用您想要的图像创建一个 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 对象。
1. 将该图像传递给 `SlidesPicture.setImage` 方法。
1. 将修改后的演示文稿另存为 PPTX 文件。

假设我们有一个名为 “lotus.png” 的文件，其图片如下：

![莲花图片](lotus.png)

以下 PHP 代码演示如何使用图片填充形状：
```php
    // 实例化表示演示文稿文件的 Presentation 类。
    $presentation = new Presentation();
    try {
        // 获取第一张幻灯片。
        $slide = $presentation->getSlides()->get_Item(0);

        // 添加一个矩形类型的自动形状。
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

        // 将填充类型设为 Picture。
        $shape->getFillFormat()->setFillType(FillType::Picture);

        // 设置图片填充模式。
        $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

        // 加载图像并将其添加到演示文稿资源。
        $image = Images::fromFile("lotus.png");
        $picture = $presentation->getImages()->addImage($image);
        $image->dispose();

        // 设置图片。
        $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

        // 将 PPTX 文件保存到磁盘。
        $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
```


结果：

![具有图片填充的形状](picture-fill.png)

### **将图片平铺为纹理**

如果您想将平铺的图片设为纹理并自定义平铺行为，可以使用 [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) 类的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode)：设置图片填充模式——`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平铺在形状内的对齐方式。
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip)：控制平铺是否水平、垂直或同时翻转。
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX)：设置平铺相对于形状原点的水平偏移（单位：磅）。
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY)：设置平铺相对于形状原点的垂直偏移（单位：磅）。
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX)：以百分比定义平铺的水平缩放。
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY)：以百分比定义平铺的垂直缩放。

以下代码示例展示如何添加一个带平铺图片填充的矩形并配置平铺选项：
```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // 添加一个矩形自动形状。
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // 将形状的填充类型设置为 Picture。
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // 加载图像并将其添加到演示文稿资源。
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // 将图像分配给形状。
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // 配置图片填充模式和平铺属性。
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // 将 PPTX 文件保存到磁盘。
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


结果：

![平铺选项示例](tile-options.png)

## **实色填充**

在 PowerPoint 中，实色填充是一种格式化选项，使用单一、统一的颜色填充形状。该背景颜色没有任何渐变、纹理或图案。

使用 Aspose.Slides 为形状应用实色填充的步骤如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
1. 将形状的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 设置为 `Solid`。
1. 为形状指定您偏好的填充颜色。
1. 将修改后的演示文稿另存为 PPTX 文件。

以下 PHP 代码演示如何在 PowerPoint 幻灯片的矩形上应用实色填充：
```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 添加一个矩形类型的自动形状。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 将填充类型设为 Solid。
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // 设置填充颜色。
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // 将 PPTX 文件保存到磁盘。
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


结果：

![具有实色填充的形状](solid-color-fill.png)

## **设置透明度**

在 PowerPoint 中，当您对形状应用实色、渐变、图片或纹理填充时，还可以设置透明度级别以控制填充的不透明度。更高的透明度值会使形状更透，从而部分显示背景或底层对象。

Aspose.Slides 通过在用于填充的颜色中调整 alpha 值来设置透明度。操作方法如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
1. 将 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 设置为 `Solid`。
1. 使用 `Color` 定义带有透明度的颜色（`alpha` 分量控制透明度）。
1. 保存演示文稿。

以下 PHP 代码演示如何为矩形应用透明填充颜色：
```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 添加一个实心矩形自动形状。
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 在实心形状上添加一个透明矩形自动形状。
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // 将 PPTX 文件保存到磁盘。
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


结果：

![具有透明度的形状](shape-transparency.png)

## **旋转形状**

Aspose.Slides 允许您在 PowerPoint 演示文稿中旋转形状。这在需要特定对齐或设计需求的视觉元素定位时非常有用。

旋转幻灯片上的形状的步骤如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
1. 将形状的 rotation 属性设置为所需的角度。
1. 保存演示文稿。

以下 PHP 代码演示如何将形状旋转 5 度：
```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 添加一个矩形类型的自动形状。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 将形状旋转 5 度。
    $shape->setRotation(5);

    // 将 PPTX 文件保存到磁盘。
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


结果：

![形状旋转示例](shape-rotation.png)

## **添加 3D 凸缘 效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) 属性来为形状添加 3D 凸缘效果。

添加 3D 凸缘效果的步骤如下：

1. 实例化 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
1. 配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) 以定义凸缘设置。
1. 保存演示文稿。

以下 PHP 代码展示如何为形状应用 3D 凸缘效果：
```php
// 创建 Presentation 类的实例。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 向幻灯片添加形状。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // 设置形状的 ThreeDFormat 属性。
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // 将演示文稿保存为 PPTX 文件。
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


结果：

![3D 凸缘效果示例](3D-bevel-effect.png)

## **添加 3D 旋转 效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) 属性来为形状添加 3D 旋转效果。

应用 3D 旋转的步骤如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
1. 使用 [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) 和 [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) 定义 3D 旋转。
1. 保存演示文稿。

以下 PHP 代码演示如何为形状应用 3D 旋转效果：
```php
// 创建 Presentation 类的实例。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // 将演示文稿保存为 PPTX 文件。
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


结果：

![3D 旋转效果示例](3D-rotation-effect.png)

## **重置格式**

以下 Java 代码展示如何重置幻灯片的格式，并将 [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) 上所有占位符形状的位置、大小和格式恢复为默认设置：
```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // 重置幻灯片上在布局中具有占位符的每个形状。
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**形状格式化会影响最终演示文稿的文件大小吗？**

影响极小。嵌入的图像和媒体占据了大部分文件空间，而形状的颜色、效果和渐变等参数以元数据形式存储，几乎不增加额外大小。

**如何检测幻灯片上具有相同格式的形状，以便对其进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值均相同，则视为样式相同，并可在逻辑上对这些形状进行分组，从而简化后续的样式管理。

**我可以将一套自定义形状样式保存到单独的文件，以便在其他演示文稿中复用吗？**

可以。将带有所需样式的示例形状保存到模板幻灯片或 .POTX 模板文件中。创建新演示文稿时，打开该模板，克隆所需的样式形状，并在需要的地方重新应用其格式。