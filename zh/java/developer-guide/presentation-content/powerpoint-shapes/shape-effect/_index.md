---
title: 形状特效
type: docs
weight: 30
url: /zh/java/shape-effect
keywords: "形状特效, PowerPoint 演示文稿, Java, Aspose.Slides for Java"
description: "在 Java 中为 PowerPoint 形状应用特效"
---

虽然 PowerPoint 中的特效可以使形状更突出，但它们与 [填充](/slides/zh/java/shape-formatting/#gradient-fill) 或轮廓不同。使用 PowerPoint 特效，您可以在形状上创建逼真的反射，扩展形状的光辉等。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint 提供了六种可以应用于形状的特效。您可以将一个或多个特效应用于一个形状。

* 某些特效组合的效果比其他组合更好。因此，PowerPoint 在 **预设** 下提供选项。预设选项本质上是一种经过验证的好看的两种或多种特效组合。通过选择预设，您不必浪费时间测试或组合不同的特效来找到一个好的组合。

Aspose.Slides 提供了 [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat) 类下的属性和方法，允许您将相同的特效应用于 PowerPoint 演示文稿中的形状。

## **应用阴影特效**

以下 Java 代码展示了如何将外阴影特效 ([OuterShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) 应用于矩形：

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **应用反射特效**

以下 Java 代码展示了如何将反射特效应用于形状：

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **应用发光特效**

以下 Java 代码展示了如何将发光特效应用于形状：

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **应用柔和边缘特效**

以下 Java 代码展示了如何将柔和边缘特效应用于形状：

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```