---
title: Apply Shape Effects in Presentations on Android
linktitle: Shape Effect
type: docs
weight: 30
url: /androidjava/shape-effect/
keywords:
- shape effect
- shadow effect
- reflection effect
- glow effect
- soft edges effect
- effect format
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Transform your PPT and PPTX files with advanced shape effects using Aspose.Slides for Android via Java—create striking, professional slides in seconds."
---

While effects in PowerPoint can be used to make a shape stand out, they differ from [fills](/slides/androidjava/shape-formatting/#gradient-fill) or outlines. Using PowerPoint effects, you can create convincing reflections on a shape, spread a shape's glow, etc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint provides six effects that can be applied to shapes. You can apply one or more effects to a shape. 

* Some combinations of effects look better than others. For this reason, PowerPoint options under **Preset**. The Preset options are essentially a known good-looking combination of two or more effects. This way, by selecting a preset, you won't have to waste time testing or combining different effects to find a nice combination.

Aspose.Slides provides properties and methods under the [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectFormat) class that allow you to apply the same effects to shapes in PowerPoint presentations.

## **Apply Shadow Effect**

This Java code shows you how to apply the outer shadow effect ([OuterShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) to a rectangle:

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

## **Apply Reflection Effect**

This Java code shows you how to apply the reflection effect to a shape:

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

## **Apply Glow Effect**

This Java code shows you how to apply the glow effect to a shape:

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

## **Apply Soft Edges Effect**

This Java code shows you how to apply the soft edges to a shape:

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
