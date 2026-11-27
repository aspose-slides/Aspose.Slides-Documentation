---
title: 在演示文稿中使用 PHP 应用形状效果
linktitle: 形状效果
type: docs
weight: 30
url: /zh/php-java/shape-effect/
keywords:
- 形状效果
- 阴影效果
- 反射效果
- 发光效果
- 柔化边缘效果
- 效果格式
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 将高级形状效果应用于您的 PPT 和 PPTX 文件——在几秒钟内创建引人注目、专业的幻灯片。"
---
## **简介**

虽然 PowerPoint 中的效果可用于让形状突出，但它们不同于[填充](/slides/zh/php-java/shape-formatting/#gradient-fill)或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的倒影、扩散形状的发光等。

![形状效果](shape-effect.png)

PowerPoint 提供了六种可应用于形状的效果。您可以对形状应用一种或多种效果。

某些效果组合看起来比其他组合更佳。因此，PowerPoint 在**预设**下提供选项。预设选项是已知看起来不错的两种或多种效果的组合。这样，通过选择预设，您无需浪费时间测试或组合不同效果来寻找合适的组合。

Aspose.Slides 在[EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) 类下提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for PHP via Java 支持形状的外部和内部阴影。您可以自定义颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影使卡片或面板在幻灯片背景上突出。阴影延伸到形状边缘之外，营造形状悬浮在幻灯片上的视觉效果。调整颜色、方向、距离和模糊半径，以匹配模板的光照和样式。

此 PHP 代码演示如何将[外部阴影效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect)应用于矩形：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![阴影效果](shadow_effect.png)

#### **在形状旋转时控制阴影方向**

默认情况下，外部阴影会随形状旋转。要使不同旋转角度的形状看起来光源方向一致，请将[setRotateShadowWithShape](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setRotateShadowWithShape)设为`false`，并使用[setDirection](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setDirection)为阴影指定相同的方向。

示例创建了两个蓝色箭头，带有向右偏移 42 点（0°）的灰色阴影。随后复制幻灯片并将两个箭头顺时针旋转 90°。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $before = $presentation->getSlides()->get_Item(0);
    
    $left = $before->getShapes()->addAutoShape(ShapeType::RightArrow, 55, 130, 110, 60);
    $left->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $left->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $left->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $left->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $left->getEffectFormat()->getOuterShadowEffect();
    $shadow->getShadowColor()->setColor(java("java.awt.Color")->GRAY);
    $shadow->setDirection(0);
    $shadow->setDistance(42);
    $shadow->setBlurRadius(0);
    $shadow->setRotateShadowWithShape(true);

    $right = $before->getShapes()->addClone($left);
    $right->setX(395);
    $right->getEffectFormat()->getOuterShadowEffect()->setRotateShadowWithShape(false);

    $after = $presentation->getSlides()->addClone($before);
    foreach ($after->getShapes()->toArray() as $arrow) {
        $arrow->setRotation(90);
    }

    $presentation->save("arrow_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在第二张幻灯片中，左侧箭头的阴影向下投射，而右侧箭头的阴影仍向右投射。两者的方向均保持为 0°。

![PowerPoint 渲染前后 90° 旋转的对比。两个阴影起始都在右侧。旋转后，左侧箭头的阴影移至下方，右侧箭头的阴影仍在右侧。](arrow-shadow-rotation.png)

### **应用内部阴影**

在复现模板的视觉样式时，使用内部阴影为卡片或面板营造凹陷效果。外部阴影在形状外部延伸，使其看起来凸起，而内部阴影则在形状边缘内部投射阴影。

调用[enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect)，然后配置[getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect)返回的阴影。较大的模糊半径值会产生更柔和的边缘。

此 PHP 示例创建一个浅蓝色卡片，带有深灰色内部阴影，并将其保存为 PPTX 文件。阴影方向为 225 度，距离为 7 点，模糊半径为 6 点：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![带内部阴影的浅蓝色矩形](inner_shadow_effect.png)

要移除内部阴影，请在形状的效果格式上调用[disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect)。

### **应用、修改和移除预设阴影**

调用[enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect)启用预设阴影。使用[setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset)选择[PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/)或在同一形状上切换到其他样式。调用[disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect)可在保留填充和轮廓的同时移除阴影。

此 PHP 示例在每个前三级别后克隆矩形，以便在同一张幻灯片上并排比较四个阶段。两个阴影均偏移 10 点。225° 的方向将第一个阴影放在矩形左上方，45° 的方向将第二个阴影放在右下方。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\PresetShadowType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(800, 120, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $shape = $shapes->addAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $lineFill = $shape->getLineFormat()->getFillFormat();
    $lineFill->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $lineFill->getSolidFillColor()->setColor($lineColor);
    $shape->getTextFrame()->setText("No shadow");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
    $shapes->addClone($shape);

    $shape->setX(215);
    $effects = $shape->getEffectFormat();
    $effects->enablePresetShadowEffect();
    $shadow = $effects->getPresetShadowEffect();
    $shadow->setPreset(PresetShadowType::TopLeftDropShadow);
    $shadow->setDistance(10);
    $shadow->setDirection(225);
    $shape->getTextFrame()->setText("TopLeftDropShadow");
    $shapes->addClone($shape);

    $shape->setX(415);
    $shadow->setPreset(PresetShadowType::BottomRightDropShadow);
    $shadow->setDirection(45);
    $shape->getTextFrame()->setText("BottomRightDropShadow");
    $shapes->addClone($shape);

    $shape->setX(615);
    $effects->disablePresetShadowEffect();
    $shape->getTextFrame()->setText("No shadow");

    $presentation->save("preset_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 原始 | 第一个预设 | 第二个预设 | 移除后 |
| :---: | :---: | :---: | :---: |
| ![无阴影](preset_shadow_original.png) | ![左上投影阴影](preset_shadow_top_left.png) | ![右下投影阴影](preset_shadow_bottom_right.png) | ![移除后无阴影](preset_shadow_removed.png) |

## **应用反射效果**

要在 Aspose.Slides for PHP via Java 中应用反射效果，您可以为形状添加镜面反射，并调整距离、透明度和大小等参数。此效果通过为形状增添更精致的外观来提升演示文稿的美感。实现简单，代码少，可快速在多个元素上统一应用。

此 PHP 代码演示如何将[反射效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect)应用于形状：

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![反射效果](reflection_effect.png)

## **应用发光效果**

要在 Aspose.Slides for PHP via Java 中为形状应用发光效果，您可以在形状周围添加柔和的光晕，并调整颜色和大小等属性。此效果有助于突出形状，使演示文稿更具吸引力。实现简便，只需少量代码即可提升幻灯片的整体视觉效果。

此 PHP 代码演示如何将[发光效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect)应用于形状：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![发光效果](glow_effect.png)

## **应用柔化边缘效果**

要在 Aspose.Slides for PHP via Java 中应用柔化边缘效果，您可以为形状的边缘创建平滑的模糊过渡。此效果为设计增添更细腻、柔和的外观，适用于需要柔和呈现的场景。您可以轻松调整半径等参数，以在演示文稿的各种形状上实现所需效果。

此 PHP 代码演示如何将[柔化边缘效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect)应用于形状：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![柔化边缘效果](soft_edges_effect.png)

## **应用模糊效果**

使用形状模糊可在保持形状可编辑的同时软化其填充和轮廓。对形状的效果格式调用[setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect)。半径以点为单位（1/72 英寸），使用非负值，值越大模糊程度越强。半径为零时外观保持不变。

[getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) 设置控制效果的可见范围。设为 `false` 时，模糊被裁剪到原始绘制边界（包括轮廓）；设为 `true` 时，模糊可延伸超出该边界。无论哪种设置，都不会改变形状的位置或尺寸。

下图比较了相同填充、轮廓和尺寸的矩形在不同模糊半径下的效果。上排使用 `grow = false`，下排使用 `grow = true`。

![原始矩形与模糊半径为 5 和 15 点、grow 已禁用和已启用的对比](shape_blur_comparison.png)

此 PHP 示例创建一个橙色矩形，配深蓝色轮廓，先应用 5 点模糊，然后再次调用[setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect)将模糊半径改为 15 点，并保存两种模糊状态。随后调用[disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect)并保存未模糊的形状。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

形状模糊同时影响填充和轮廓。柔化边缘效果仅淡化形状的边缘，而阴影模糊仅软化阴影本身。图像变换效果作用于图像内容；本示例直接对形状的效果格式应用模糊，而不将形状转换为图像。

## **常见问题**

**我可以对同一形状应用多个效果吗？**

可以，您可以在单个形状上组合阴影、反射、发光等不同效果，以实现更动态的外观。

**哪些形状可以应用效果？**

您可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

可以，效果会应用于整个组合。