---
title: Android でのプレゼンテーションにおけるシェイプエフェクトの適用
linktitle: シェイプエフェクト
type: docs
weight: 30
url: /ja/androidjava/shape-effect/
keywords:
- シェイプエフェクト
- 影エフェクト
- 反射エフェクト
- グローエフェクト
- ソフトエッジエフェクト
- エフェクト形式
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PPT および PPTX ファイルに高度なシェイプエフェクトを適用し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---

PowerPoint のエフェクトはシェイプを際立たせるために使用できますが、[fills](/slides/ja/androidjava/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPoint のエフェクトを使用すると、シェイプにリアルな反射を作成したり、シェイプのグローを広げたりできます。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint はシェイプに適用できる 6 つのエフェクトを提供しています。シェイプに 1 つまたは複数のエフェクトを適用できます。  
* エフェクトの組み合わせによっては、他よりも見栄えが良いものがあります。このため、PowerPoint の **Preset** オプションがあります。Preset オプションは実質的に 2 つ以上のエフェクトの見栄えが良い既知の組み合わせです。このように、プリセットを選択することで、異なるエフェクトをテストしたり組み合わせて、良い組み合わせを見つけるために時間を浪費する必要がなくなります。

Aspose.Slides は、[EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectFormat) クラスの下にプロパティとメソッドを提供しており、PowerPoint プレゼンテーションのシェイプに同じエフェクトを適用できます。

## **シャドウ効果を適用する**

この Java コードは、外部シャドウ効果（[OuterShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) を矩形に適用する方法を示しています:
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

この Java コードは、シェイプに反射効果を適用する方法を示しています:
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


## **グロー効果を適用する**

この Java コードは、シェイプにグロー効果を適用する方法を示しています:
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

この Java コードは、シェイプにソフトエッジを適用する方法を示しています:
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


## **よくある質問**

**同じシェイプに複数のエフェクトを適用できますか？**

はい、影、反射、グローなどの異なるエフェクトを単一のシェイプに組み合わせて、より動的な外観を作成できます。

**どのようなシェイプにエフェクトを適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまなシェイプにエフェクトを適用できます。

**グループ化されたシェイプにエフェクトを適用できますか？**

はい、グループ化されたシェイプにエフェクトを適用できます。エフェクトはグループ全体に適用されます。