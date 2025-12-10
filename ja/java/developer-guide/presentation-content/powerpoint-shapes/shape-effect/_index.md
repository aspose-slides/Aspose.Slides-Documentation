---
title: Java を使用したプレゼンテーションでのシェイプ効果の適用
linktitle: シェイプ効果
type: docs
weight: 30
url: /ja/java/shape-effect/
keywords:
- シェイプ効果
- シャドウ効果
- 反射効果
- 光彩効果
- ソフトエッジ効果
- エフェクト形式
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PPT および PPTX ファイルに高度なシェイプ効果を適用し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---

PowerPoint の効果はシェイプを目立たせるために使用できますが、[fills](/slides/ja/java/shape-formatting/#gradient-fill) やアウトラインとは異なります。PowerPoint の効果を使用すると、シェイプにリアルな反射を作成したり、シェイプの光彩を広げたりできます。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint はシェイプに適用できる 6 つの効果を提供します。1 つまたは複数の効果をシェイプに適用できます。  
* 効果の組み合わせの中には、他より見栄えが良いものがあります。そのため、PowerPoint の **Preset** オプションがあります。Preset オプションは、実質的に見栄えの良い 2 つ以上の効果の組み合わせです。プリセットを選択することで、さまざまな効果をテストしたり組み合わせて良い組み合わせを見つける時間を無駄にしなくてすみます。

Aspose.Slides は、[EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat) クラスの下にプロパティとメソッドを提供し、PowerPoint プレゼンテーションのシェイプに同じ効果を適用できます。

## **シャドウ効果の適用**

この Java コードは、外部シャドウ効果 ([OuterShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) を四角形に適用する方法を示します:
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

この Java コードは、シェイプに反射効果を適用する方法を示します:
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

この Java コードは、シェイプに光彩効果を適用する方法を示します:
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

この Java コードは、シェイプにソフトエッジ効果を適用する方法を示します:
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


## **FAQ**

**同じシェイプに複数の効果を適用できますか？**

はい、影、反射、光彩など、異なる効果を単一のシェイプに組み合わせて、よりダイナミックな外観を作成できます。

**どのようなシェイプに効果を適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまなシェイプに効果を適用できます。

**グループ化されたシェイプに効果を適用できますか？**

はい、グループ化されたシェイプにも効果を適用できます。効果はグループ全体に適用されます。