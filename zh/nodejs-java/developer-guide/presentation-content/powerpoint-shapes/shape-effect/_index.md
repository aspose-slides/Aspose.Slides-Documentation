---
title: 使用 JavaScript 在演示文稿中应用形状效果
linktitle: 形状效果
type: docs
weight: 30
url: /zh/nodejs-java/shape-effect/
keywords:
- 形状效果
- 阴影效果
- 反射效果
- 发光效果
- 柔化边缘效果
- 效果格式
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 和 Aspose.Slides for Node.js 的高级形状效果，转换您的 PPT 和 PPTX 文件——在几秒钟内创建引人注目、专业的幻灯片。"
---
## **介绍**

虽然 PowerPoint 中的效果可用于使形状突出，但它们不同于[填充](/slides/zh/nodejs-java/shape-formatting/#gradient-fill)或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射、扩展形状的发光等。

![形状效果](shape-effect.png)

PowerPoint 提供六种可应用于形状的效果。您可以对一个形状应用一个或多个效果。

某些效果组合看起来比其他组合更好。为此，PowerPoint 在 **预设** 下提供选项。预设选项是已知效果良好的两种或多种效果的组合。这样，选择预设后，您无需花时间测试或组合不同的效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) 类中提供属性和方法，使您能够在 PowerPoint 演示文稿中的形状上应用相同的效果。

## **应用阴影效果**

Aspose.Slides for Node.js via Java 支持形状的外部和内部阴影。您可以自定义它们的颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影可使卡片或面板在幻灯片背景上突出。阴影延伸超出形状边缘，营造出形状悬浮在幻灯片上的感觉。调整其颜色、方向、距离和模糊半径，以匹配模板的光照和样式。

此 JavaScript 代码展示了如何将[外部阴影效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect)应用于矩形：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![阴影效果](shadow_effect.png)

### **应用内部阴影**

在复现模板的视觉样式时，使用内部阴影为卡片或面板提供凹陷感。外部阴影延伸到形状外部，使其看起来凸起，而内部阴影则在其边缘内部着色。

调用[enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect)，然后配置由[getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect)返回的阴影。较大的模糊半径值会产生更柔和的边缘。

此 JavaScript 示例创建了一个浅蓝色卡片，带有深灰色内部阴影，并将其保存为 PPTX 文件。阴影方向为 225 度，距离为 7 点，模糊半径为 6 点：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![带内部阴影的浅蓝矩形](inner_shadow_effect.png)

要移除内部阴影，请在形状的 effect format 上调用[disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect)。

## **应用反射效果**

在 Aspose.Slides for Node.js via Java 中应用反射效果，您可以为形状添加类似镜面的反射，并可调整距离、透明度和大小等参数。此效果通过为形状增添更精致、时尚的外观来提升演示文稿的美感。实现简便，代码少，能够快速在多个元素上统一应用，实现一致的设计。

此 JavaScript 代码展示了如何将[反射效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect)应用于形状：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![反射效果](reflection_effect.png)

## **应用发光效果**

在 Aspose.Slides for Node.js via Java 中为形状应用发光效果，您可以在形状周围添加柔和的光晕，并可调节颜色和大小等属性。此效果帮助形状突出显示，为演示文稿增添吸引人的视觉元素。实现简单，代码量少，能提升整体幻灯片的观感。

此 JavaScript 代码展示了如何将[发光效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect)应用于形状：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![发光效果](glow_effect.png)

## **应用柔化边缘效果**

在 Aspose.Slides for Node.js via Java 中应用柔化边缘效果，您可以在形状边缘创建平滑、模糊的过渡。这种效果为设计增添更细腻、精致的外观，适用于需要柔和外观的设计。您可以轻松调节半径等参数，在演示文稿的各种形状上实现所需效果。

此 JavaScript 代码展示了如何将[柔化边缘效果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect)应用于形状：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![柔化边缘效果](soft_edges_effect.png)

## **应用模糊效果**

使用形状模糊可在保持形状可编辑的同时软化其填充和轮廓。对形状的 effect format 调用[setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect)。半径以点为单位（1/72 英寸）：使用非负值，较大的值会产生更强的模糊。半径为零则保持外观不变。

[getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) 设置控制效果的可见边界。设置为 `false` 时，模糊被限制在原始绘制边界（包括轮廓）内；设置为 `true` 时，模糊可超出这些边界。两种设置均不改变形状的位置或尺寸。

下表比较使用相同填充、轮廓和形状尺寸的情况。首行使用 `grow = false`，次行使用 `grow = true`。

![原始矩形比较，模糊半径分别为 5 和 15 点，grow 为 false 和 true 时的对比](shape_blur_comparison.png)

此 JavaScript 示例创建了一个橙色矩形，带深蓝色轮廓，先应用 5 点模糊，然后再次调用[setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect)将其更新为 15 点模糊。它保存了两种模糊状态，然后调用[disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect)并保存未模糊的形状。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

形状模糊同时影响填充和轮廓。柔化边缘效果淡化形状的边缘，而阴影模糊仅软化阴影。图像变换效果作用于图像内容；本例直接对形状的 effect format 应用模糊，而无需将形状转换为图像。

## **常见问题**

**我可以对同一形状应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，例如阴影、反射和发光，以创建更具动感的外观。

**我可以对哪些形状应用效果？**

您可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

可以，您可以对组合形状应用效果。该效果将作用于整个组合。