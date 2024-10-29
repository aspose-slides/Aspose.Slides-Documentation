---
title: 形状效果
type: docs
weight: 30
url: /zh/androidjava/shape-effect
keywords: "形状效果, PowerPoint 演示文稿, Java, Aspose.Slides for Android via Java"
description: "在 Java 中对 PowerPoint 形状应用效果"
---

在 PowerPoint 中，效果可以使形状更突出，但它们与[填充](/slides/zh/androidjava/shape-formatting/#gradient-fill)或轮廓不同。使用 PowerPoint 效果，您可以在形状上创建逼真的反射，扩展形状的光晕等。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint 提供六种可以应用于形状的效果。您可以对一个形状应用一种或多种效果。

* 一些效果的组合效果比其他效果更好。因此，PowerPoint 在 **预设** 下提供选项。预设选项本质上是两种或多种效果的已知好看组合。通过选择预设，您无需浪费时间测试或组合不同效果以找到一个好的组合。

Aspose.Slides 提供了[EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectFormat)类下的属性和方法，允许您将相同的效果应用于 PowerPoint 演示文稿中的形状。

## **应用阴影效果**

以下 Java 代码显示了如何将外部阴影效果（[OuterShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--))应用于矩形：

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

## **应用反射效果**

以下 Java 代码显示了如何将反射效果应用于形状：

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

## **应用光晕效果**

以下 Java 代码显示了如何将光晕效果应用于形状：

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

## **应用柔和边缘效果**

以下 Java 代码显示了如何将柔和边缘应用于形状：

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