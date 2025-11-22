---
title: 形状效果
type: docs
weight: 30
url: /zh/nodejs-java/shape-effect
keywords: "形状效果, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "在 JavaScript 中为 PowerPoint 形状应用效果"
---

虽然 PowerPoint 中的效果可以用来突出形状，但它们与[填充](/slides/zh/nodejs-java/shape-formatting/#gradient-fill)或轮廓不同。使用 PowerPoint 效果，您可以为形状创建逼真的反射、展开形状的发光等。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint 提供六种可应用于形状的效果。您可以对形状应用一种或多种效果。

* 某些效果组合比其他组合更好看。因此，PowerPoint 在 **Preset** 下提供选项。Preset 选项本质上是两种或更多效果的已知好看组合。通过选择预设，您无需浪费时间测试或组合不同效果来寻找合适的组合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EffectFormat) 类下提供属性和方法，允许您在 PowerPoint 演示文稿中对形状应用相同的效果。

## **应用阴影效果**

以下 JavaScript 代码展示如何将外部阴影效果（[getOuterShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)）应用于矩形：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "DARK_GRAY"));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **应用反射效果**

以下 JavaScript 代码展示如何将反射效果应用于形状：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);
    pres.save("reflection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **应用发光效果**

以下 JavaScript 代码展示如何将发光效果应用于形状：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    shape.getEffectFormat().getGlowEffect().setRadius(15);
    pres.save("glow.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **应用柔和边缘效果**

以下 JavaScript 代码展示如何将柔和边缘应用于形状：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);
    pres.save("softEdges.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**我可以对同一形状应用多个效果吗？**

可以，您可以在同一形状上组合阴影、反射和发光等不同效果，以实现更动感的外观。

**哪些形状可以应用效果？**

几乎所有形状都可以应用效果，包括自动形状、图表、表格、图片、SmartArt 对象、OLE 对象等。

**我可以对组合形状应用效果吗？**

可以，效果会应用于整个组合。