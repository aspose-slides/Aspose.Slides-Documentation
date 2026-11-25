---
title: 在 Android 上的演示文稿中应用形状效果
linktitle: 形状效果
type: docs
weight: 30
url: /zh/androidjava/shape-effect/
keywords:
- 形状效果
- 阴影效果
- 反射效果
- 发光效果
- 柔和边缘效果
- 效果格式
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 将高级形状效果应用于您的 PPT 和 PPTX 文件——在几秒钟内创建引人注目、专业的幻灯片。"
---
## **简介**

虽然 PowerPoint 中的效果可用于使形状突出，但它们不同于 [fills](/slides/zh/androidjava/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射，扩展形状的发光等。

![形状效果](shape-effect.png)

PowerPoint 提供六种可应用于形状的效果。您可以对形状应用一个或多个效果。

某些效果组合看起来比其他的更好。因此，PowerPoint 在 **Preset** 下提供选项。这些预设选项是已知看起来不错的两种或多种效果的组合。通过选择预设，您无需花时间测试或组合不同的效果来寻找合适的组合。

Aspose.Slides provides properties and methods under the [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) class that allow you to apply the same effects to shapes in PowerPoint presentations.

## **应用阴影效果**

Aspose.Slides for Android via Java 支持形状的外阴影和内阴影。您可以自定义其颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影使卡片或面板在幻灯片背景中脱颖而出。阴影延伸到形状边缘之外，产生形状悬浮在幻灯片上的效果。调整颜色、方向、距离和模糊半径以匹配模板的光照和样式。

此 Java 代码展示了如何对矩形应用 [outer shadow effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--)：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![阴影效果](shadow_effect.png)

### **应用内部阴影**

在复现模板的视觉样式时，使用内部阴影为卡片或面板提供凹陷外观。外部阴影在形状外部延伸，使其看起来被抬起，而内部阴影则在其边缘内部进行着色。

调用 [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--)，然后配置由 [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) 返回的阴影。较大的模糊半径值会产生更柔和的边缘。

此 Java 示例创建了一个浅蓝色卡片并添加深灰色内部阴影，然后将其保存为 PPTX 文件。阴影方向为 225 度，距离为 7 点，模糊半径为 6 点：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![带内部阴影的浅蓝色矩形](inner_shadow_effect.png)

要删除内部阴影，请对形状的 effect format 调用 [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--)。

### **应用、修改和删除预设阴影**

调用 [enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) 并使用 [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) 选择一个 [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/)。要切换样式，只需在同一形状上更改预设。调用 [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) 可在保留填充和轮廓的同时删除阴影。

此示例在一张幻灯片上并排显示四个阶段。两个阴影均偏移 10 点。225° 的方向将第一个阴影放在矩形的左上方，45° 将第二个放在右下方。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

| 原始 | 第一个预设 | 第二个预设 | 删除后 |
| :---: | :---: | :---: | :---: |
| ![无阴影](preset_shadow_original.png) | ![左上投影阴影](preset_shadow_top_left.png) | ![右下投影阴影](preset_shadow_bottom_right.png) | ![删除后无阴影](preset_shadow_removed.png) |

## **应用反射效果**

要在 Aspose.Slides for Android via Java 中应用反射效果，您可以为形状添加类似镜面的反射，并调整距离、透明度和大小等参数。此效果通过为形状提供更精致、专业的外观来提升演示文稿的美感。实现简单，代码少，能够快速在多个元素上统一应用以保持设计一致性。

此 Java 代码展示了如何对形状应用 [reflection effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--)：

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

要在 Aspose.Slides for Android via Java 中对形状应用发光效果，您可以在形状周围添加柔和的光晕，并调节颜色和大小等属性。此效果帮助形状突出显示，并为演示文稿增添吸引人、醒目的视觉元素。实现简便，代码量少，能够提升幻灯片整体观感。

此 Java 代码展示了如何对形状应用 [glow effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--)：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **应用柔和边缘效果**

要在 Aspose.Slides for Android via Java 中应用柔和边缘效果，您可以在形状的边缘创建平滑、模糊的过渡。这一效果为设计增添更细腻、精致的外观，适合需要柔和外观的设计。您可以轻松调节半径等参数，以在演示文稿中的各种形状上实现所需效果。

此 Java 代码展示了如何对形状应用 [soft edges effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--)：

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

![柔和边缘效果](soft_edges_effect.png)

## **应用模糊效果**

使用形状模糊可在保持形状可编辑的前提下柔化其填充和轮廓。对形状的 effect format 调用 [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)。半径以点为单位（1/72 英寸），使用非负值，值越大模糊越强。半径为零时外观保持不变。

[getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) 设置控制效果的可见边界。`false` 时，模糊被裁剪到原始绘制边界（包括轮廓）；`true` 时，模糊可延伸超出这些边界。两种设置都不会改变形状的位置或尺寸。

下面的比较使用了相同的填充、轮廓和形状尺寸。顶部行使用 `grow = false`；底部行使用 `grow = true`。

![原始矩形与模糊半径为 5 点和 15 点的比较，分别在禁用和启用 grow 时](shape_blur_comparison.png)

此 Java 示例创建了一个橙色矩形并配以深蓝色轮廓，先应用 5 点模糊，然后再次调用 [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) 将其更新为 15 点模糊，并保存两个模糊状态。随后调用 [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) 并保存无模糊的形状。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

形状模糊同时影响填充和轮廓。柔和边缘效果淡化形状边缘，而阴影模糊仅软化阴影。图像转换效果作用于图像内容；本例直接在形状的 effect format 上应用模糊，而不将形状转换为图像。

## **常见问题**

**我可以对同一个形状应用多个效果吗？**

可以，您可以将阴影、反射、发光等不同效果组合在同一个形状上，以实现更具动感的外观。

**我可以对哪些形状应用效果？**

您可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

可以，您可以对组合形状应用效果，效果将作用于整个组合。