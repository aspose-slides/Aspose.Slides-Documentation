---
title: 形の効果
type: docs
weight: 30
url: /ja/java/shape-effect
keywords: "形の効果, PowerPoint プレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaでPowerPointの形に効果を適用する"
---

PowerPointの効果は形を目立たせるために使用できますが、[塗りつぶし](/slides/ja/java/shape-formatting/#gradient-fill)や輪郭とは異なります。PowerPointの効果を使用して、形の convincing な反射を作成したり、形の輝きを広げたりできます。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPointは形に適用できる6つの効果を提供します。1つまたは複数の効果を形に適用できます。

* 効果の組み合わせによっては他より良く見えるものもあります。このため、PowerPointの**プリセット**オプションがあります。プリセットオプションは、基本的に2つ以上の効果の見栄えの良い組み合わせです。この方法でプリセットを選択すれば、さまざまな効果をテストまたは組み合わせて素敵な組み合わせを見つけるために時間を無駄にする必要がありません。

Aspose.Slidesは、PowerPointプレゼンテーションの形に同じ効果を適用できる[EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat)クラスのプロパティとメソッドを提供します。

## **影効果を適用する**

このJavaコードは、長方形に外側の影効果 ([OuterShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) を適用する方法を示しています：

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

## **反射効果を適用する**

このJavaコードは、形に反射効果を適用する方法を示しています：

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

## **光彩効果を適用する**

このJavaコードは、形に光彩効果を適用する方法を示しています：

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

## **ソフトエッジ効果を適用する**

このJavaコードは、形にソフトエッジを適用する方法を示しています：

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