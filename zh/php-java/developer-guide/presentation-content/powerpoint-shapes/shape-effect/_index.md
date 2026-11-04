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
- 辉光效果
- 柔和边缘效果
- 效果格式
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 将您的 PPT 和 PPTX 文件转化为高级形状效果——在几秒钟内创建引人注目、专业的幻灯片。"
---
## **介绍**

虽然 PowerPoint 中的效果可以用于让形状突出，但它们不同于 [填充](/slides/zh/php-java/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射，扩展形状的辉光等。

![形状效果](shape-effect.png)

PowerPoint 提供六种可应用于形状的效果。您可以对一个形状应用一种或多种效果。

某些效果组合看起来比其他组合更好。因此，PowerPoint 在 **Preset** 下提供选项。Preset 选项是已知外观良好的两种或更多效果的组合。通过选择预设，您无需浪费时间测试或组合不同的效果来找到合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) 类中提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for PHP via Java 支持形状的外部和内部阴影。您可以自定义其颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影使卡片或面板在幻灯片背景上突出。阴影延伸到形状边缘之外，营造形状在幻灯片上方的提升感。调整其颜色、方向、距离和模糊半径，以匹配模板的光照和样式。

以下 PHP 代码演示如何将 [外部阴影效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) 应用于矩形：

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

### **应用内部阴影**

在复现模板的视觉样式时，使用内部阴影为卡片或面板提供凹陷外观。外部阴影延伸到形状外部，使其看起来升起，而内部阴影则在其边缘内部投射阴影。

调用 [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect)，然后配置由 [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) 返回的阴影。较大的模糊半径值会产生更柔和的边缘。

以下 PHP 示例创建一个浅蓝色卡片，带有深灰色内部阴影，并将其保存为 PPTX 文件。阴影方向为 225 度，距离为 7 点，模糊半径为 6 点：

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

要移除内部阴影，请在形状的 EffectFormat 上调用 [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect)。

## **应用反射效果**

在 Aspose.Slides for PHP via Java 中应用反射效果时，您可以为形状添加类似镜面的反射，并调整距离、透明度和大小等参数。此效果通过为形状提供更光滑、更精致的外观来提升演示文稿的美感。只需简单代码即可轻松实现，可在多个元素之间快速应用，实现一致的设计。

以下 PHP 代码展示如何将 [反射效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) 应用于形状：

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

## **应用辉光效果**

在 Aspose.Slides for PHP via Java 中为形状应用辉光效果时，您可以在形状周围添加柔和、发光的光环，调整颜色和大小等属性。此效果有助于突出形状，并为演示文稿增添吸引人、引人注目的视觉元素。只需少量代码即可轻松实现，提升幻灯片的整体外观。

以下 PHP 代码展示如何将 [辉光效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) 应用于形状：

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

![辉光效果](glow_effect.png)

## **应用柔和边缘效果**

在 Aspose.Slides for PHP via Java 中应用柔和边缘效果时，您可以在形状的边缘创建平滑、模糊的过渡。此效果增添更微妙、精致的外观，非常适合需要柔和外观的设计。您可以轻松调整半径等参数，以在演示文稿中的各种形状上实现理想效果。

以下 PHP 代码展示如何将 [柔和边缘效果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) 应用于形状：

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

![柔和边缘效果](soft_edges_effect.png)

## **应用模糊效果**

使用形状模糊可在保持形状可编辑的同时柔化其填充和轮廓。对形状的 EffectFormat 调用 [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect)。半径以点为单位（1/72 英寸），使用非负值，值越大模糊越强。半径为零时外观保持不变。

[getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) 设置控制效果的可见边界。`false` 时，模糊被裁剪到原始绘制边界，包括轮廓。`true` 时，模糊可以超出这些边界。两种设置都不改变形状的位置或尺寸。

下面的对比使用相同的填充、轮廓和形状尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![原始矩形与模糊半径 5 和 15 点的对比（grow 关闭和开启）](shape_blur_comparison.png)

以下 PHP 示例创建一个橙色矩形，带深蓝色轮廓，先应用 5 点模糊，然后再次调用 [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) 将其更新为 15 点模糊。它保存两个模糊状态，然后调用 [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) 并保存无模糊的形状。

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

形状模糊同时影响填充和轮廓。柔和边缘效果使形状的边缘渐隐，而阴影模糊仅柔化阴影。图像转换效果作用于图像内容；本示例直接对形状的 EffectFormat 应用模糊，而不将形状转换为图像。

## **常见问题**

**我可以对同一形状应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，如阴影、反射和辉光，以创建更具动态感的外观。

**可以对哪些形状应用效果？**

您可以对各种形状应用效果，包括自动作图形、图表、表格、图片、SmartArt 对象、OLE 对象等。

**可以对组合形状应用效果吗？**

是的，您可以对组合形状应用效果。效果将应用于整个组。