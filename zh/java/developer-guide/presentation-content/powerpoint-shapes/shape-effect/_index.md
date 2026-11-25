---
title: 使用 Java 在演示文稿中应用形状效果
linktitle: 形状效果
type: docs
weight: 30
url: /zh/java/shape-effect/
keywords:
- 形状效果
- 阴影效果
- 反射效果
- 辉光效果
- 柔边效果
- 效果格式
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 将您的 PPT 和 PPTX 文件转换为高级形状效果——几秒钟内创建引人注目、专业的幻灯片。"
---
## **简介**

虽然 PowerPoint 中的效果可用于使形状突出，但它们不同于[填充](/slides/zh/java/shape-formatting/#gradient-fill)或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射，扩散形状的光晕等。

![形状效果](shape-effect.png)

PowerPoint 提供六种可应用于形状的效果。您可以对形状应用一个或多个效果。

某些效果组合比其他的更好看。因此，PowerPoint 在 **预设** 下提供了选项。预设选项是两种或更多效果的组合，已知效果良好。这样，选择预设后，您无需浪费时间测试或组合不同的效果来找到合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) 类下提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for Java 支持形状的外部和内部阴影。您可以自定义其颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影可以使卡片或面板在幻灯片背景上突出。阴影延伸到形状的边缘之外，产生形状悬浮在幻灯片上的印象。调整其颜色、方向、距离和模糊半径，以匹配模板的光照和样式。

下面的 Java 代码展示了如何对矩形应用 [外部阴影效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--)：

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

### **应用内部阴影**

在复现模板的视觉样式时，使用内部阴影可为卡片或面板提供凹陷的外观。外部阴影延伸到形状外部，使其看起来凸起，而内部阴影则在其边缘内部产生阴影。

调用 [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--)，然后配置由 [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) 返回的阴影。较大的模糊半径值会产生更柔和的边缘。

下面的 Java 示例创建了一个带有深灰色内部阴影的淡蓝色卡片，并将其保存为 PPTX 文件。阴影方向为 225 度，距离为 7 磅，模糊半径为 6 磅：

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

![带内部阴影的淡蓝色矩形](inner_shadow_effect.png)

要移除内部阴影，请在形状的 EffectFormat 上调用 [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--)。

### **应用、更改和移除预设阴影**

调用 [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) 并使用 [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) 选择一个 [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/)。要切换样式，可在同一形状上更改预设。调用 [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) 可移除阴影，同时保留填充和轮廓。

此示例在同一幻灯片上并排显示四个阶段。两个阴影均偏移 10 磅。225° 的方向将第一个阴影放置在矩形的左上方，45° 的方向则将第二个放在右下方。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 原始 | 第一个预设 | 第二个预设 | 移除后 |
| :---: | :---: | :---: | :---: |
| ![无阴影](preset_shadow_original.png) | ![左上投影](preset_shadow_top_left.png) | ![右下投影](preset_shadow_bottom_right.png) | ![移除后的无阴影](preset_shadow_removed.png) |

## **应用反射效果**

要在 Aspose.Slides for Java 中应用反射效果，您可以为形状添加类似镜面的反射，并调整距离、透明度和大小等参数。此效果通过为形状提供更精致、专业的外观来提升演示文稿的美感。使用简短代码即可轻松实现，可在多个元素之间快速应用，以保持设计的一致性。

下面的 Java 代码展示了如何对形状应用 [反射效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--)：

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

## **应用辉光效果**

要在 Aspose.Slides for Java 中为形状应用辉光效果，您可以在形状周围添加柔和的光晕，并调整颜色和大小等属性。此效果有助于突出形状，并为演示文稿增添吸引人的视觉元素。只需少量代码即可实现，提升幻灯片的整体外观。

下面的 Java 代码展示了如何对形状应用 [辉光效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--)：

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

![辉光效果](glow_effect.png)

## **应用柔边效果**

要在 Aspose.Slides for Java 中应用柔边效果，您可以在形状的边缘创建平滑、模糊的过渡。此效果增添更细腻、精致的外观，适用于需要柔和外观的设计。您可以轻松调整半径等参数，以在演示文稿的各种形状上实现所需效果。

下面的 Java 代码展示了如何对形状应用 [柔边效果](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--)：

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

![柔边效果](soft_edges_effect.png)

## **应用模糊效果**

使用形状模糊可在保持形状可编辑的同时软化其填充和轮廓。调用 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) 在形状的 EffectFormat 上。半径以点为单位（1/72 英寸）：使用非负值，较大值产生更强的模糊。半径为零时外观保持不变。

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) 设置控制效果的可见边界。设为 `false` 时，模糊被裁剪到原始绘制边界（包括轮廓）。设为 `true` 时，模糊可延伸超出这些边界。两种设置都不会改变形状的位置或尺寸。

以下比较在整个过程中使用相同的填充、轮廓和形状尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![比较原始矩形在模糊半径为5和15点时的效果（grow 禁用和启用）](shape_blur_comparison.png)

下面的 Java 示例创建了一个橙色矩形并带有深蓝色轮廓，先应用 5 点模糊，然后通过再次调用 [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) 将其更新为 15 点模糊。它保存了两个模糊状态，然后调用 [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) 并保存无模糊的形状。

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

形状模糊同时影响填充和轮廓。柔边效果会淡化形状的边缘，而阴影模糊仅软化阴影本身。图像变换效果作用于图像内容；本例直接对形状的 EffectFormat 应用模糊，而不将形状转换为图像。

## **常见问题**

**我可以对同一形状应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，例如阴影、反射和辉光，以创建更具动感的外观。

**我可以对哪些形状应用效果？**

您可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

是的，您可以对组合形状应用效果。效果将应用于整个组。