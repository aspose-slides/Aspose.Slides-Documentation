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
description: "使用 Aspose.Slides for Android via Java 将您的 PPT 和 PPTX 文件转换为高级形状效果——仅需几秒即可创建醒目、专业的幻灯片。"
---
## **介绍**

在 PowerPoint 中，效果可用于使形状凸显，但它们不同于 [填充](/slides/zh/androidjava/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射，扩展形状的发光等。

![形状效果](shape-effect.png)

PowerPoint 提供六种可应用于形状的效果。您可以对形状应用一个或多个效果。

某些效果组合看起来比其他组合更好。为此，PowerPoint 在 **预设** 下提供选项。预设选项是两种或更多已知效果良好的组合。这样，通过选择预设，您无需浪费时间测试或组合不同效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) 类下提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for Android via Java 支持形状的外部阴影和内部阴影。您可以自定义其颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影使卡片或面板在幻灯片背景前突出。阴影超出形状的边缘，形成形状悬浮于幻灯片之上的视觉效果。调整其颜色、方向、距离和模糊半径，以匹配模板的光照和样式。

下面的 Java 代码演示如何将 [外部阴影效果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) 应用于矩形：

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

在复现模板的视觉样式时，使用内部阴影为卡片或面板提供凹陷外观。外部阴影延伸至形状之外，使其看起来凸起，而内部阴影则为其边缘内部着色。

调用 [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--)，随后配置由 [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) 返回的阴影。更大的模糊半径值会产生更柔和的边缘。

下面的 Java 示例创建了一个浅蓝色卡片，带有深灰色内部阴影，并将其保存为 PPTX 文件。阴影方向为 225 度，距离为 7 磅，模糊半径为 6 磅：

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

要移除内部阴影，请在形状的 EffectFormat 上调用 [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--)。

## **应用反射效果**

在 Aspose.Slides for Android via Java 中应用反射效果时，您可以为形状添加类似镜面的反射，并调整距离、透明度和大小等参数。此效果通过赋予形状更精致、专业的外观来提升演示文稿的美感。使用简洁的代码即可轻松实现，能够快速在多个元素上统一应用，以保持设计的一致性。

下面的 Java 代码演示如何将 [反射效果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) 应用于形状：

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

在 Aspose.Slides for Android via Java 中为形状应用发光效果时，您可以在形状周围添加柔和、光亮的光环，并调整颜色和大小等属性。此效果有助于使形状突出，并为演示文稿增添吸引人、醒目的视觉元素。只需少量代码即可轻松实现，提升幻灯片的整体外观。

下面的 Java 代码演示如何将 [发光效果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) 应用于形状：

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

在 Aspose.Slides for Android via Java 中应用柔和边缘效果时，您可以在形状的边缘创建平滑、模糊的过渡。此效果增添更细腻、精致的外观，适用于需要柔和外形的设计。您可以轻松调整半径等参数，以在演示文稿中的各种形状上实现所需效果。

下面的 Java 代码演示如何将 [柔和边缘效果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) 应用于形状：

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

使用形状模糊来软化形状的填充和轮廓，同时保持形状可编辑。对形状的 EffectFormat 调用 [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-)。半径以点（1/72 英寸）为单位：使用非负值，较大的值会产生更强的模糊。半径为零时外观保持不变。

[getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) 设置控制效果的可见范围。`false` 时，模糊被裁剪到原始绘制范围（包括轮廓）。`true` 时，模糊可超出该范围。两种设置都不会改变形状的位置或尺寸。

下面的比较在整个过程中使用相同的填充、轮廓和形状尺寸。上排使用 `grow = false`；下排使用 `grow = true`。

![原始矩形对比模糊半径为 5 和 15 点的效果，分别在关闭和启用 grow 时](shape_blur_comparison.png)

下面的 Java 示例创建了一个橙色矩形，带有深蓝色轮廓，先应用 5 点模糊，然后再次调用 [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) 将其更新为 15 点模糊。它保存了两种模糊状态，然后调用 [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) 并保存无模糊的形状。

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

形状模糊同时影响填充和轮廓。柔和边缘效果会淡化形状的边缘，而阴影模糊仅软化阴影。图像转换效果作用于图像内容；本示例直接对形状的 EffectFormat 应用模糊，而无需将形状转换为图像。

## **常见问题**

**我可以对同一形状应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，如阴影、反射和发光，以创建更具动感的外观。

**我可以对哪些形状应用效果？**

您可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

是的，您可以对组合形状应用效果。该效果将作用于整个组。