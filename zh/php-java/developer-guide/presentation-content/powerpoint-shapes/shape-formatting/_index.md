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
- 格式化接合样式
- 渐变填充
- 图案填充
- 图片填充
- 纹理填充
- 纯色填充
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
description: "了解如何使用 Aspose.Slides 在 PHP 中格式化 PowerPoint 形状——精准且全面地为 PPT 和 PPTX 文件设置填充、线条和效果样式。"
---
## **介绍**

通过调整轮廓、填充和效果来格式化 PowerPoint 中的形状。Aspose.Slides for PHP via Java 允许您以编程方式控制这些设置，包括透明度、旋转和 3D 格式化。

![PowerPoint 中的形状格式选项](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java 提供类和方法，使您能够使用 PowerPoint 中可用的相同选项来格式化形状。

## **格式化线条**

使用 [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) 控制形状的轮廓。此示例创建一个未填充的矩形，使用蓝色、虚线轮廓。[LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) 选择粗细复合线，而 [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) 将宽度设置为 7 磅，且 [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) 选择虚线模式。

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![演示文稿中的已格式化线条](formatted-lines.png)

### **设置自定义线条虚线模式**

当预定义的线条样式无法提供所需的虚线长度和间隙时（例如品牌轮廓或技术图表），使用 [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern)。分配模式会自动将线条虚线样式更改为 [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/)。

数组条目在虚线和间隙长度之间交替，始于虚线。每个值都是线宽的倍数：在宽度为 3 磅时 `[4, 2]` 产生 12 磅的虚线，随后是 6 磅的间隙。使用成对的有限、非负值来定义完整的虚线‑间隙段。示例使用正值以保持每段虚线和间隙可见。

此示例创建了五条相同长度、平头的蓝色线条。前三条在宽度为 3 磅时比较不同的模式。第四条使用第一次模式但宽度加倍，从而将虚线和间隙长度都加倍。第五条从自定义模式切换为实线。

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // 将最后一条线恢复为实线样式。
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

若要返回预定义的虚线样式，请向 [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) 传递 [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/)。所选样式决定线条的外观。

PowerPoint 中的结果（从上到下）：**{4, 2}, 3 pt**；**{1, 2}, 3 pt**；**{6, 2, 1, 2}, 3 pt**；**{4, 2}, 6 pt**；以及 **Solid, 3 pt**。

![PowerPoint 中的三种自定义虚线模式、使用第一种模式的更宽线条以及实线](custom-dash-patterns.png)

### **设置线端点样式**

使用 [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) 为打开的线条设置端点。[LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) 类提供三种显式端点样式：

- `Flat`：笔画在端点处停止。
- `Round`：半圆形端点延伸至端点之外，长度为线宽的一半。
- `Square`：方形端点延伸至端点之外，长度为线宽的一半。

该类还包含 `NotDefined`，表示未显式分配端点样式。

端点不同于箭头（在端点添加符号）和接合（控制线段之间的拐角）。此示例通过 [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) 和 [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) 禁用箭头，以便仅比较端点形状。

以下示例创建三条除端点外完全相同的水平线，宽度为 20 磅。自上而下分别使用平头、圆头和方头。它们的端点具有相同的水平坐标；圆头和方头在每个端点之外延伸 10 磅。

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint 中的结果（从上到下）：**Flat**、**Round** 和 **Square**。

![PowerPoint 中相同粗细线条的平头、圆头和方头](line-caps.png)

## **为形状线条应用素描效果**

素描效果使形状线条看起来像手绘。使用 [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) 访问线条设置，使用 [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) 访问素描设置，使用 [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) 从 [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) 类中选择值。

下面的 PHP 代码演示如何应用 [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) 效果，读取显式分配的值，并使用 [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) 移除该效果：

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

通过 [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) 返回的值表示直接分配给形状的设置。如果线条格式可以从主题、母版幻灯片或布局幻灯片继承，请使用 [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective)，访问返回对象的 `getSketchFormat` 方法，并读取其 `getSketchType` 值。有效值反映在继承解析后实际应用的格式。此示例需要一个包含至少一个形状的现有演示文稿的第一张幻灯片，并打印两个值：

```php
use aspose\slides\Presentation;

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

## **格式化接合样式**

以下是三种接合类型选项：

* Round
* Miter
* Bevel

接合样式控制两个轮廓段在拐角处的连接方式。使用 **Round** 获得圆角，使用 **Miter** 获得尖角，使用 **Bevel** 获得平坦的拐角。

![演示文稿中的接合样式](join-style-powerpoint.png)

此示例创建三个黑色矩形，蓝色轮廓宽度为 15 磅。分别将 [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) 设置为 [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) 的斜接、斜面和圆形值，以比较拐角的绘制方式。

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **在尖锐拐角处限制斜接接合**

使用 [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) 并将 [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) 设置为 [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) 来限制尖锐拐角的延伸距离。

该限制是接合内、外拐角之间的距离与线宽的比率。例如，值 `8` 允许斜接长度最多为线宽的八倍；它不是以点为单位的度量。如果拐角超过限制，PowerPoint 会在该拐角使用斜面接合。更大的限制会产生更尖锐的点。此设置仅影响斜接接合，在拐角仍在限制范围内时更改它不会产生可见效果。

此示例创建两个相同的未填充三角形，轮廓宽度为 20 磅。左侧三角形使用限制 `2`，右侧使用 `8`。每个三角形宽 80 磅、高 160 磅，使其顶部拐角的斜接长度与线宽比约为 `4.12`。因此，PowerPoint 对左侧顶点使用斜面，而保持右侧顶点尖锐。

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint 中的结果：左侧 **Miter limit 2**，右侧 **miter limit 8**。

![PowerPoint 中斜接限制为 2 的斜面顶点和斜接限制为 8 的尖锐顶点](miter-limits.png)

## **渐变填充**

渐变填充在形状上混合颜色。此示例使用 [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) 将椭圆填充为 45 度角的线性渐变，从红色到紫色。通过 [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) 方法将颜色停止点放在 0 和 1（渐变的开始和结束）。清除现有停止点可确保仅使用这两种颜色。

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![带有渐变填充的椭圆](gradient-fill.png)

如果导出图像中的渐变与 PowerPoint 中显示的不同，请参阅 [Choose a Gradient Rendering Style](/slides/zh/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不更改演示文稿中存储的渐变填充的情况下选择渲染样式。

### **设置线性渐变角度**

使用 [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) 控制 [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) 填充的方向。角度以度为单位，顺时针递增：`0` 表示从左到右，`90` 表示从上到下，`180` 表示从右到左，`270` 表示从下到上。支持小数角度。超出 `[0, 360)` 的有限角度会规范化为一次完整旋转；例如 `-45` 变为 `315`，`360` 变为 `0`。

此示例创建六个矩形，红、绿、蓝三种停止点位置分别为 `0`、`0.5`、`1`。禁用缩放，以便在不受矩形比例影响的情况下比较角度。左到右的角度分别为第一行的 `0`、`45`、`90`，第二行的 `135`、`180`、`270`。

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint 中的结果：

![顶部行的 0、45、90 度线性渐变，底部行的 135、180、270 度线性渐变](linear-gradient-angles.png)

### **使用形状缩放线性渐变**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) 接受一个 [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) 值。显式设为 `False` 可在形状比例变化时保持几何渐变角度不变，设为 `True` 可随形状的宽高缩放渐变。启用缩放后，在非正方形形状上可见角度可能与分配的角度不同。

下面的示例使用 `45` 度角和与角度比较相同的颜色停止点。左列使用 `False`，右列使用 `True`。每列包含一个宽矩形上方一个高矩形。两者均从相同的宽尺寸开始；改变第二个矩形的宽高演示在不更改渐变设置的情况下填充如何响应大小调整。

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint 中的结果，左侧缩放已禁用，右侧已启用：

![宽矩形和高矩形的 45 度渐变，左侧 LinearGradientScaled 为 False，右侧为 True](linear-gradient-scaling.png)

禁用缩放时，斜向颜色带在两个矩形中保持相同方向。启用缩放后，颜色带随着形状比例拉伸。这有助于在将形状适配为不同尺寸时复制模板的渐变。在正方形形状上，启用缩放不会改变此 `45` 度渐变的外观。

角度和缩放设置均适用于线性渐变。它们不控制 [GradientShape::Radial] 或 [GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) 填充。

### **将角度与渐变方向结合**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) 从 [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/) 类中选择渐变样式；它并非数值角度的替代品。对于线性渐变，角落样式可以在不更改通过 [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) 分配的角度的情况下，改变颜色分布的区域。比较角度或缩放时请保持方向不变。

下面的示例以相反的顺序应用相同的设置。两个矩形的外观相同：先设置方向后设置角度或相反顺序都不会改变结果。

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **图案填充**

图案填充应用两种颜色的设计，例如点、条纹或格子。此示例使用 [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) 选择格子图案。使用 [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) 提供浅灰色背景，使用 [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) 提供黄色图案颜色。

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![带有图案填充的矩形](pattern-fill.png)

## **图片填充**

图片填充在形状内部使用图像。此示例需要本地图片，并使用 [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) 将其加载到演示文稿的图像集合中。将 [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) 设置为平铺模式，使图像在矩形内重复。下面显示使用的源图片：

![莲花图片](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![带有图片填充的形状](picture-fill.png)

### **将图片平铺为纹理**

如果要将平铺图片设为纹理并自定义平铺行为，可使用 [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) 类的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode)：设置图片填充模式——`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平铺在形状内的对齐方式。
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip)：控制平铺是否水平翻转、垂直翻转或两者都翻转。
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX)：设置平铺相对于形状原点的水平偏移（以磅为单位）。
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY)：设置平铺相对于形状原点的垂直偏移（以磅为单位）。
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX)：以百分比定义水平缩放比例。
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY)：以百分比定义垂直缩放比例。

此示例需要本地图片，并将 [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) 配置为在原始尺寸的 50% 处重复。`-32` 磅的偏移在水平和垂直方向上移动平铺；右下对齐并在两个方向上翻转决定了重复纹理的排列方式。

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![平铺选项](tile-options.png)

## **纯色填充**

纯色填充为形状提供单一、均匀的颜色。此示例将 [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) 设置为纯色填充模式，并通过 [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) 分配黄色，然后将矩形保存到演示文稿中。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![带有纯色填充的形状](solid-color-fill.png)

### **在保留主题引用的同时复制颜色**

使用 [ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom) 复制颜色定义，包括其颜色类型、主题引用和转换。当在应继续遵循演示文稿主题的形状之间传递填充颜色时，这非常有用。该方法仅复制颜色本身；它不会复制填充类型、轮廓或其他形状格式。使用 [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) 明确设置目标的填充类型。

此示例创建三个矩形，左到右分别为：源、主题感知的复制和固定 RGB 复制。源使用 [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor) 引用第一强调色，并通过 [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add) 添加色调。RGB 复制使用源的有效填充颜色，因此最初这三者看起来相同。调用 [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) 设置固定的 RGB 值并清除任何现有的颜色转换。

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // 主题引用遵循新的强调色；固定的 RGB 值则不受影响。
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

主题更改前，所有三个填充均匹配：

![源、copyFrom 目标以及具有相同蓝色填充的固定 RGB 目标](color-copy-before.png)

主题更改后，源和主题感知的复制遵循新的强调色并保留其色调。固定 RGB 复制仍保持蓝色：

![源和 copyFrom 目标呈橙色填充，而固定 RGB 目标保持蓝色](color-copy-after.png)

复制的定义与源独立。随后更改源的主题引用、分配其他颜色或添加/删除其转换都不会影响目标。主题更改仍会影响两个形状，因为它们各自独立引用相同的主题颜色。

保存并重新打开 PPTX 可保留通过 [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType) 返回的颜色类型、主题引用以及通过 [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform) 返回的转换集合；它不会将定义展平成 RGB。

在不同主题上下文之间复制（例如不同强调色调色板的演示文稿），复制的引用会根据目标主题解析。相同的引用和转换因此可能产生不同的可见颜色。有关配置主题颜色的更多信息，请参阅 [Presentation Theme](/slides/zh/php-java/presentation-theme/)。

## **使用幻灯片背景作为形状填充**

当形状应匹配幻灯片背景时（例如在演示文稿模板中），使用 [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill)。首先将填充类型使用 [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) 设置为 [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 以移除任何显式填充。通过此组合，形状使用幻灯片背景而不是其样式填充。仅启用该标志并不会移除现有的显式填充。

这与 [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 不同：背景填充会用对应的幻灯片背景区域覆盖形状后面的对象，而无填充则使这些对象保持可见。渐变仍与幻灯片对齐，而不是在每个形状内部重新启动。

以下示例创建一个被母版背景继承的幻灯片，并在三个矩形后面放置一条品红色带。左矩形使用背景，中央矩形无填充，右矩形从背景填充切换为显式橙色填充。

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // 从母版继承渐变。
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // 首先添加此对象，使其出现在矩形后面。
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // 在应用显式填充之前禁用背景填充。
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果（从左到右）：**背景填充**、**无填充** 和 **显式填充**。品红色带被左侧和右侧矩形遮挡，但通过中间矩形仍可见。

![背景填充、无填充和显式橙色填充覆盖在品红色带上](background-fill.png)

相同的行为适用于直接在幻灯片上定义的背景或从布局继承的背景。形状使用已解析的幻灯片背景；示例中幻灯片和布局背景均未定义，以便使用母版提供的背景。

## **设置透明度**

对于纯色填充，颜色的 alpha 分量控制不透明度：0 表示完全透明，255 表示完全不透明。此示例将 alpha 值设为 128，用于黄色矩形，使其约 50% 透明，从而底下的矩形仍可见。颜色通过 [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) 分配。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![透明形状](shape-transparency.png)

## **旋转形状**

使用 [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) 在幻灯片平面上旋转形状。角度以度为单位；此示例将矩形顺时针旋转 5 度并保存演示文稿。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![形状旋转](shape-rotation.png)

## **添加 3D 倒角效果**

使用 [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) 为形状添加深度和倒角。此示例创建一个绿色椭圆，橙色轮廓，将 [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) 设为 4 磅，并通过 [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) 将圆形顶部倒角的宽度和高度设为 6 磅。正视的正投影相机和三点光照使倒角可见。

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![3D 倒角效果](3D-bevel-effect.png)

## **添加 3D 旋转效果**

形状的 3D 视图由摄像机设置控制。此示例使用 [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) 将纬度、经度和翻转角度分别设为 40、35、20 度。通过 [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) 选择等轴摄像机，并通过 [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) 选择平衡光照，然后保存已格式化的矩形。

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![3D 旋转效果](3D-rotation-effect.png)

## **控制形状的黑白渲染**

[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) 方法指定在以黑白模式查看或处理演示文稿时，单个形状的渲染方式。它本身并不启用黑白显示，也不会在常规彩色模式下更改形状的填充、线条或其他格式。

使用来自 [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) 类的值来选择所需行为。例如，`Automatic` 让渲染应用自行选择转换，`Gray` 和 `LightGray` 使用灰度，`BlackWhite` 仅使用黑白，`Black` 和 `White` 强制单色，`Color` 保持常规彩色，`Hidden` 在黑白模式下省略该形状。`NotDefined` 表示未分配形状级模式。

此示例创建一个橙色矩形，并将 [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) 设置为灰色。保存的形状在常规彩色显示下保留橙色填充，在遵循黑白显示设置的应用程序中请求灰色渲染：

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
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在常规彩色模式下，矩形保持橙色填充；在黑白显示工作流中，由于模式设为 `Gray`，它会使用灰色渲染。这使您能够在保留全彩幻灯片的同时，为打印、预览或其他遵循黑白显示设置的工作流定义不同的外观。

## **重置格式**

使用 [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) 将幻灯片占位符的位置、大小和格式恢复为其对应布局占位符的设置。此示例需要一个已有布局链接占位符的演示文稿，并在保存前重置每张幻灯片。没有对应布局占位符的形状不会被重置。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常见问题解答**

**形状格式会影响最终演示文稿文件大小吗？**

颜色、线条样式和效果设置相比嵌入的图像和媒体通常只会增加很少的数据。图片填充可能会因其图像被存储在演示文稿中而增加文件大小。

**如何检测幻灯片上具有相同格式的形状以便对其进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值匹配，则视其样式为相同，并在逻辑上将这些形状分组，这有助于后续的样式管理。

**我能否将一套自定义形状样式保存到单独的文件，以便在其他演示文稿中复用？**

可以。将带有所需样式的示例形状存储在模板幻灯片文件或 .POTX 模板文件中。创建新演示文稿时，打开模板，克隆所需的样式形状，并在需要的地方重新应用其格式。