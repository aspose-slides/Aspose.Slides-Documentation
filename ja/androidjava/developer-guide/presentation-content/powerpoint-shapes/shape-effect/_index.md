---
title: 形状効果
type: docs
weight: 30
url: /androidjava/shape-effect
keywords: "形状効果, PowerPoint プレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "JavaでPowerPointの形状に効果を適用する"
---

PowerPointの効果は形状を目立たせるために使用できますが、[フィル](/slides/androidjava/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPointの効果を使用すると、形状に説得力のある反射を作成したり、形状の光を広げたりできます。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPointでは、形状に適用できる6つの効果を提供しています。1つまたは複数の効果を形状に適用できます。

* 効果の組み合わせによっては、他の組み合わせよりもより良く見えるものがあります。このため、PowerPointのオプションには**プリセット**があります。プリセットオプションは、2つ以上の効果の間で知られている見栄えの良い組み合わせです。このようにして、プリセットを選択すれば、素敵な組み合わせを見つけるために異なる効果をテストまたは組み合わせる時間を無駄にすることはありません。

Aspose.Slidesは、PowerPointプレゼンテーションの形状に同じ効果を適用するための[EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectFormat)クラスのプロパティとメソッドを提供します。

## **影効果の適用**

このJavaコードは、矩形に外側の影効果（[OuterShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)）を適用する方法を示しています：

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

## **反射効果の適用**

このJavaコードは、形状に反射効果を適用する方法を示しています：

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

## **光彩効果の適用**

このJavaコードは、形状に光彩効果を適用する方法を示しています：

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

## **ソフトエッジ効果の適用**

このJavaコードは、形状にソフトエッジ効果を適用する方法を示しています：

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