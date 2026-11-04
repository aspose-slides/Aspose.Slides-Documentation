---
title: 在演示文稿中使用 Java 应用形状效果
linktitle: 形状效果
type: docs
weight: 30
url: /zh/java/shape-effect/
keywords:
- 形状效果
- 阴影效果
- 反射效果
- 发光效果
- 柔化边缘效果
- 效果格式
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 对 PPT 和 PPTX 文件进行高级形状效果转换——在几秒钟内创建引人注目、专业的幻灯片。"
---
## **简介**

虽然在 PowerPoint 中可以使用效果使形状突出，但它们不同于 [填充](/slides/zh/java/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射、扩散形状的光晕等。

![形状效果](shape-effect.png)

PowerPoint 提供了六种可应用于形状的效果。您可以对一个形状应用一个或多个效果。

某些效果组合比其他组合更好看。基于此，PowerPoint 在 **Preset** 下提供了选项。Preset 选项是已知外观良好的两种或多种效果的组合。这样，通过选择预设，您无需浪费时间测试或组合不同的效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) 类下提供属性和方法，允许您将相同的效果应用于 PowerPoint 演示文稿中的形状。

## **应用阴影效果**

Aspose.Slides for Java 支持形状的外阴影和内阴影。您可以自定义它们的颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外阴影**

使用外阴影可以使卡片或面板相对于幻灯片背景更突出。阴影延伸到形状边缘之外，营造出形状悬浮在幻灯片上的效果。调整其颜色、方向、距离和模糊半径，以匹配模板的光照和样式。

以下 Java 代码展示了如何将 [外阴影效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) 应用于矩形：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![阴影效果](shadow_effect.png)

### **应用内阴影**

在复现模板的视觉样式时，使用内阴影可为卡片或面板营造凹陷的效果。外阴影延伸到形状外部，使其看起来凸起，而内阴影则对其边缘内部进行着色。

调用 [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--)，然后配置由 [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) 返回的阴影。更大的模糊半径值会产生更柔和的边缘。

以下 Java 示例创建了一个带有深灰色内阴影的浅蓝色卡片并将其保存为 PPTX 文件。阴影方向为 225 度，距离为 7 点，模糊半径为 6 点：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![带内阴影的浅蓝色矩形](inner_shadow_effect.png)

要移除内阴影，请在形状的 effect format 上调用 [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--)。

## **应用反射效果**

在 Aspose.Slides for Java 中应用反射效果时，您可以为形状添加镜面反射，并调整距离、透明度和大小等参数。此效果通过为形状提供更精致、专业的外观来提升演示文稿的美感。使用简短代码即可轻松实现，可快速在多个元素上应用，实现一致的设计。

以下 Java 代码展示了如何将 [反射效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) 应用于形状：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![反射效果](reflection_effect.png)

## **应用发光效果**

在 Aspose.Slides for Java 中为形状应用发光效果时，您可以在形状周围添加柔和、发光的光晕，并调整颜色和大小等属性。此效果有助于突显形状，并为演示文稿增添吸引人、引人注目的视觉元素。只需少量代码即可轻松实现，提升幻灯片的整体外观。

以下 Java 代码展示了如何将 [发光效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) 应用于形状：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![发光效果](glow_effect.png)

## **应用柔化边缘效果**

在 Aspose.Slides for Java 中应用柔化边缘效果时，您可以在形状的边缘创建平滑、模糊的过渡。此效果增添更细腻、精致的外观，适用于需要柔和外观的设计。您可以轻松调整半径等参数，以在演示文稿中的各种形状上实现所需效果。

以下 Java 代码展示了如何将 [柔化边缘效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) 应用于形状：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![柔化边缘效果](soft_edges_effect.png)

## **应用模糊效果**

使用形状模糊可在保持形状可编辑的同时软化其填充和轮廓。对形状的 effect format 调用 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)。半径以点为单位（1/72 英寸）：使用非负值，较大的值会产生更强的模糊。半径为零时外观保持不变。

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) 设置控制效果的可见范围。设为 `false` 时，模糊被裁剪到原始绘制范围（包括轮廓）。设为 `true` 时，模糊可以超出该范围。两种设置都不会改变形状的位置或尺寸。

以下比较使用了相同的填充、轮廓和形状尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![原始矩形对比模糊半径为 5 和 15 点，grow 分别禁用和启用的情况](shape_blur_comparison.png)

以下 Java 示例创建了一个带深蓝色轮廓的橙色矩形，先应用 5 点模糊，然后再次调用 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) 将模糊更新为 15 点。它保存了两种模糊状态，随后调用 [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) 并保存未模糊的形状。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

形状模糊同时影响填充和轮廓。柔化边缘效果会淡化形状的边缘，而阴影模糊仅软化阴影。图像转换效果作用于图像内容；本例直接对形状的 effect format 应用模糊，而不将形状转换为图像。

## **常见问题**

**我可以对同一个形状应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，例如阴影、反射和发光，以创建更具动感的外观。

**我可以对哪些形状应用效果？**

您可以对多种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

是的，您可以对组合形状应用效果。该效果将作用于整个组。