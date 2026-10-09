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
- 柔边效果
- 效果格式
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 将您的 PPT 和 PPTX 文件转换为高级形状效果——瞬间创建引人注目、专业的幻灯片。"
---
## **简介**

在 PowerPoint 中，效果可用于使形状突出，但它们不同于 [填充](/slides/zh/androidjava/shape-formatting/#gradient-fill) 或轮廓。使用 PowerPoint 效果，您可以在形状上创建逼真的反射、扩展形状的发光等。

![形状效果](shape-effect.png)

PowerPoint 提供了六种可应用于形状的效果。您可以对形状应用一种或多种效果。

某些效果组合看起来比其他组合更佳。为此，PowerPoint 在 **Preset** 下提供了选项。Preset 选项是两个或多个已知外观良好的效果的组合。这样，通过选择预设，您无需花时间测试或组合不同的效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) 类中提供了属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

Aspose.Slides for Android via Java 支持形状的外部和内部阴影。您可以自定义其颜色、方向、距离和模糊半径，以匹配演示文稿的设计。

### **应用外部阴影**

使用外部阴影使卡片或面板在幻灯片背景上突出。阴影延伸到形状边缘之外，营造出形状悬浮在幻灯片上的印象。调整其颜色、方向、距离和模糊半径，以匹配模板的光照和样式。

下面的 Java 代码演示如何对矩形应用 [外部阴影效果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--)：

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

在复现模板的视觉样式时，使用内部阴影为卡片或面板提供凹陷外观。外部阴影延伸到形状外部，使其看起来凸起，而内部阴影则对其边缘内部进行着色。

调用 [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--)，然后配置由 [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) 返回的阴影。较大的模糊半径值会产生更柔和的边缘。

此 Java 示例创建了一个浅蓝色卡片，带有深灰色内部阴影，并将其保存为 PPTX 文件。阴影方向为 225 度，距离为 7 磅，模糊半径为 6 磅：

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

要移除内部阴影，请在形状的效果格式上调用 [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--)。

## **应用反射效果**

在 Aspose.Slides for Android via Java 中应用反射效果时，您可以为形状添加镜面反射，并调整距离、透明度和大小等参数。此效果通过为形状赋予更精致、专业的外观来提升演示文稿的美感。使用简单的代码即可轻松实现，能够快速在多个元素上应用，实现一致的设计。

下面的 Java 代码演示如何对形状应用 [反射效果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--)：

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

在 Aspose.Slides for Android via Java 中对形状应用发光效果时，您可以在形状周围添加柔和、发光的光晕，并调整颜色和大小等属性。此效果有助于突出形状，并为演示文稿添加吸引人、引人注目的视觉元素。只需少量代码即可轻松实现，提升幻灯片的整体外观。

下面的 Java 代码演示如何对形状应用 [发光效果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--)：

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

## **应用柔边效果**

在 Aspose.Slides for Android via Java 中应用柔边效果时，您可以在形状的边缘创建平滑、模糊的过渡。此效果增添更细腻、精致的外观，适合需要柔和外观的设计。您可以轻松调整半径等参数，以在演示文稿的各种形状上实现所需效果。

下面的 Java 代码演示如何对形状应用 [柔边效果](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--)：

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

## **常见问题**

**我可以对同一形状应用多个效果吗？**

是的，您可以在单个形状上组合不同的效果，例如阴影、反射和发光，以创建更具动感的外观。

**我可以对哪些形状应用效果？**

您可以对各种形状应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

是的，您可以对组合形状应用效果。该效果将作用于整个组。