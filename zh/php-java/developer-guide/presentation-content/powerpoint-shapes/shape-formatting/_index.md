---
title: 在 PHP 中格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/php-java/shape-formatting/
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
- 实色填充
- 形状透明度
- 黑白形状渲染
- 灰度形状渲染
- 旋转形状
- 3D 倒角效果
- 3D 旋转效果
- 重置格式
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "学习如何在 PHP 中使用 Aspose.Slides 格式化 PowerPoint 形状——精确且全方位地为 PPT、PPTX 和 ODP 文件设置填充、线条和效果样式。"
---
## **简介**

在 PowerPoint 中，您可以向幻灯片添加形状。由于形状由线条组成，您可以通过修改或应用效果来设置它们的轮廓。此外，您还可以通过指定控制内部填充方式的设置来格式化形状。

![格式形状-PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java 提供的类和方法，使您能够使用 PowerPoint 中相同的选项来格式化形状。

## **格式化线条**

使用 Aspose.Slides，您可以为形状指定自定义的线条样式。下面的步骤概述了该过程：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。  
4. 设置形状的 [line style](https://reference.aspose.com/slides/zh/php-java/aspose.slides/linestyle/)。  
5. 设置线宽。  
6. 设置线条的 [dash style](https://reference.aspose.com/slides/zh/php-java/aspose.slides/linedashstyle/)。  
7. 为形状设置线条颜色。  
8. 将修改后的演示文稿另存为 PPTX 文件。

以下 PHP 代码演示了如何为矩形 `AutoShape` 设置格式：

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

    // 对矩形的线条应用格式化。
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

![演示文稿中的格式化线条](formatted-lines.png)

## **对形状线条应用素描效果**

素描效果使形状线条看起来像手绘。使用 [Shape.getLineFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/) 访问线条设置，使用 [LineFormat.getSketchFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/lineformat/) 访问素描设置，并使用 [SketchFormat.setSketchType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sketchformat/) 从 [LineSketchType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/linesketchtype/) 枚举中选择值。

以下 PHP 代码展示了如何应用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh/php-java/aspose.slides/linesketchtype/) 效果，读取显式指定的值，以及使用 [LineSketchType.None](https://reference.aspose.com/slides/zh/php-java/aspose.slides/linesketchtype/) 删除该效果：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // 访问形状的线条格式及其素描格式。
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // 应用素描效果。
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // 读取直接分配给形状的素描效果。
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // 移除素描效果。
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/sketchformat/) 返回的值表示直接分配给形状的设置。如果线条格式可以从主题、母版幻灯片或布局幻灯片继承，请使用 [LineFormat.getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/lineformat/)，访问返回对象的 `getSketchFormat` 方法，并读取其 `getSketchType` 值。有效值反映了解决继承后实际应用的格式：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **格式化连接样式**

以下是三种连接类型选项：

* Round  
* Miter  
* Bevel  

默认情况下，PowerPoint 在一个角度（例如形状的拐角）连接两条线时使用 **Round** 设置。然而，如果您绘制的是尖角形状，可能更倾向于使用 **Miter** 选项。

![演示文稿中的连接样式](join-style-powerpoint.png)

以下 PHP 代码演示了如何使用 Miter、Bevel 和 Round 连接类型设置创建三个矩形（如上图所示）：

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

    // 设置线条宽度。
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

在 PowerPoint 中，渐变填充是一种格式化选项，允许您对形状应用连续的颜色混合。例如，您可以使用两种或多种颜色，使一种颜色逐渐淡入另一种颜色。

以下是使用 Aspose.Slides 为形状应用渐变填充的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。  
4. 将形状的 [FillType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/filltype/) 设置为 `Gradient`。  
5. 使用 [GradientFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/gradientformat/) 类公开的渐变停止集合的 `add` 方法，按定义的位置添加您喜欢的两种颜色。  
6. 将修改后的演示文稿另存为 PPTX 文件。

以下 PHP 代码演示了如何为椭圆形应用渐变填充效果：

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

![带渐变填充的椭圆形](gradient-fill.png)

## **图案填充**

在 PowerPoint 中，图案填充是一种格式化选项，允许您对形状应用两色图案——如点、条纹、交叉线或格子。您可以为图案的前景色和背景色自定义颜色。

Aspose.Slides 提供了超过 45 种预定义的图案样式，您可以将其应用于形状以增强演示文稿的视觉效果。即使选择了预定义图案，仍然可以指定其使用的确切颜色。

以下是使用 Aspose.Slides 对形状应用图案填充的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。  
4. 将形状的 [FillType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/filltype/) 设置为 `Pattern`。  
5. 从预定义选项中选择一种图案样式。  
6. 设置图案的 [Background Color](https://reference.aspose.com/slides/zh/php-java/aspose.slides/patternformat/#getBackColor)。  
7. 设置图案的 [Foreground Color](https://reference.aspose.com/slides/zh/php-java/aspose.slides/patternformat/#getForeColor)。  
8. 将修改后的演示文稿另存为 PPTX 文件。

以下 PHP 代码演示了如何为矩形应用图案填充：

```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 添加一个矩形类型的自动形状。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 将填充类型设置为 Pattern。
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

![带图案填充的矩形](pattern-fill.png)

## **图片填充**

在 PowerPoint 中，图片填充是一种格式化选项，允许您在形状内部插入图像——实际上将图像作为形状的背景。

以下是使用 Aspose.Slides 为形状应用图片填充的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。  
4. 将形状的 [FillType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/filltype/) 设置为 `Picture`。  
5. 将图片填充模式设置为 `Tile`（或其他首选模式）。  
6. 使用要使用的图像创建一个 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 对象。  
7. 将图像传递给 `SlidesPicture.setImage` 方法。  
8. 将修改后的演示文稿另存为 PPTX 文件。

假设我们有一个名为 “lotus.png” 的文件，其图片如下：

![莲花图片](lotus.png)

以下 PHP 代码演示了如何使用图片填充形状：

```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 添加一个矩形类型的自动形状。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // 将填充类型设置为 Picture。
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // 设置图片填充模式。
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // 加载图像并将其添加到演示文稿资源中。
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

![带图片填充的形状](picture-fill.png)

### **将图片平铺为纹理**

如果希望将平铺图片设置为纹理并自定义平铺行为，可使用 [PictureFillFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/) 类的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#setPictureFillMode)：设置图片填充模式，可为 `Tile` 或 `Stretch`。  
- [setTileAlignment](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平铺在形状内的对齐方式。  
- [setTileFlip](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#setTileFlip)：控制平铺水平、垂直或同时翻转。  
- [setTileOffsetX](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#setTileOffsetX)：设置平铺相对于形状原点的水平偏移（以点为单位）。  
- [setTileOffsetY](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#setTileOffsetY)：设置平铺相对于形状原点的垂直偏移（以点为单位）。  
- [setTileScaleX](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#setTileScaleX)：以百分比定义平铺的水平比例。  
- [setTileScaleY](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#setTileScaleY)：以百分比定义平铺的垂直比例。

以下代码示例展示了如何添加一个带平铺图片填充的矩形形状并配置平铺选项：

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

    // 加载图像并将其添加到演示文稿资源中。
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // 将图像分配给形状。
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // 配置图片填充模式和瓦片属性。
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

![平铺选项](tile-options.png)

## **实色填充**

在 PowerPoint 中，实色填充是一种格式化选项，可使用单一、均匀的颜色填充形状。这种纯色背景不会包含任何渐变、纹理或图案。

使用 Aspose.Slides 为形状应用实色填充的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。  
4. 将形状的 [FillType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/filltype/) 设置为 `Solid`。  
5. 为形状分配您喜欢的填充颜色。  
6. 将修改后的演示文稿另存为 PPTX 文件。

以下 PHP 代码演示了如何在 PowerPoint 幻灯片的矩形上应用实色填充：

```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation();
try {
    // 获取第一张幻灯片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 添加一个矩形类型的自动形状。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 将填充类型设置为 Solid。
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

![带实色填充的形状](solid-color-fill.png)

## **设置透明度**

在 PowerPoint 中，当您对形状应用实色、渐变、图片或纹理填充时，还可以设置透明度级别以控制填充的不透明度。更高的透明度值会使形状更加透视，从而部分显示背景或底层对象。

Aspose.Slides 通过调整用于填充的颜色的 alpha 值来设置透明度。操作步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。  
4. 将 [FillType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/filltype/) 设置为 `Solid`。  
5. 使用 `Color` 定义带有透明度的颜色（alpha 分量控制透明度）。  
6. 保存演示文稿。

以下 PHP 代码演示了如何为矩形应用透明填充颜色：

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

![透明形状](shape-transparency.png)

## **旋转形状**

Aspose.Slides 允许您在 PowerPoint 演示文稿中旋转形状。这在对视觉元素进行特定对齐或设计需求时非常有用。

要在幻灯片上旋转形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。  
4. 将形状的旋转属性设置为所需角度。  
5. 保存演示文稿。

以下 PHP 代码演示了如何将形状旋转 5 度：

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

![形状旋转](shape-rotation.png)

## **添加 3D 倒角效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/) 属性，允许您对形状应用 3D 倒角效果。

要为形状添加 3D 倒角效果，请按以下步骤操作：

1. 实例化一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。  
4. 配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/) 以定义倒角设置。  
5. 保存演示文稿。

以下 PHP 代码展示了如何对形状应用 3D 倒角效果：

```php
// 创建 Presentation 类的实例。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 向幻灯片添加一个形状。
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

![3D 倒角效果](3D-bevel-effect.png)

## **添加 3D 旋转效果**

Aspose.Slides 通过配置形状的 [ThreeDFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/threedformat/) 属性，允许您对形状应用 3D 旋转效果。

要对形状应用 3D 旋转，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。  
4. 使用 [setCameraType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/camera/#setCameraType) 和 [setLightType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/lightrig/#setLightType) 定义 3D 旋转。  
5. 保存演示文稿。

以下 PHP 代码演示了如何对形状应用 3D 旋转效果：

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

![3D 旋转效果](3D-rotation-effect.png)

## **控制形状的黑白渲染**

[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#setBlackWhiteMode) 方法指定在以黑白模式查看或处理演示文稿时，单个形状的渲染方式。它本身并不会启用黑白显示，也不会在正常彩色模式下更改形状的填充、线条或其他格式。

使用 [BlackWhiteMode](https://reference.aspose.com/slides/zh/php-java/aspose.slides/blackwhitemode/) 类中的值选择所需行为。例如，`Automatic` 让渲染应用程序自行决定转换方式，`Gray` 和 `LightGray` 使用灰色，`BlackWhite` 只使用黑白，`Black` 和 `White` 强制单色，`Color` 保持正常着色，`Hidden` 在黑白模式下隐藏形状，`NotDefined` 表示未为该形状分配模式。

以下 PHP 代码创建了一个彩色形状，并使其在黑白显示模式下呈现为灰色：

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // 在彩色模式下保持橙色填充，但在黑白模式下将形状渲染为灰色。
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在正常彩色模式下，矩形保留橙色填充；在黑白显示工作流中，因为模式被设置为 `Gray`，它采用灰色着色。这使您在保持全彩幻灯片的同时，为打印、预览或其他遵循黑白显示设置的工作流定义不同的外观。

## **重置格式**

以下 Java 代码展示了如何重置幻灯片的格式，并将 [LayoutSlide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/layoutslide/) 上带占位符的所有形状的位置、大小和格式恢复为默认设置：

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // 重置幻灯片上每个在布局中有占位符的形状。
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常见问题解答**

**形状格式化会影响最终演示文稿的文件大小吗？**

影响极小。嵌入的图像和媒体占据大部分文件空间，而颜色、效果和渐变等形状参数仅作为元数据存储，几乎不增加额外大小。

**如何检测幻灯片上具有相同格式的形状，以便对它们进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值均匹配，则视为样式相同，可在逻辑上将这些形状分组，从而简化后续的样式管理。

**我可以将一组自定义形状样式保存到单独的文件，以便在其他演示文稿中重复使用吗？**

可以。将带有所需样式的示例形状存放在模板幻灯片或 .POTX 模板文件中。创建新演示文稿时，打开该模板，克隆所需的已样式化形状，并在需要的地方重新应用其格式。