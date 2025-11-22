---
title: シェイプ効果
type: docs
weight: 30
url: /ja/nodejs-java/shape-effect
keywords: "シェイプ効果, PowerPoint プレゼンテーション, Java, Aspose.Slides for Node.js via Java"
description: "JavaScript で PowerPoint のシェイプに効果を適用する"
---

PowerPoint の効果は図形を目立たせるために使用できますが、[fills](/slides/ja/nodejs-java/shape-formatting/#gradient-fill) やアウトラインとは異なります。PowerPoint の効果を使うと、図形にリアルな反射を付けたり、光彩を広げたりすることができます。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint は図形に適用できる 6 種類の効果を提供します。1 つまたは複数の効果を図形に適用できます。

* 効果の組み合わせには見栄えの良いものとそうでないものがあります。そのため、PowerPoint では **Preset** のオプションが用意されています。Preset は実質的に 2 つ以上の効果の見栄えの良い組み合わせを示しています。プリセットを選択すれば、さまざまな効果を試したり組み合わせて最適な組み合わせを探す手間が省けます。

Aspose.Slides は [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EffectFormat) クラスのプロパティとメソッドを提供し、PowerPoint プレゼンテーションの図形に同じ効果を適用できます。

## **Apply Shadow Effect**

この JavaScript コードは、外側の影効果 ([getOuterShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)) を矩形に適用する方法を示します:
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


## **Apply Reflection Effect**

この JavaScript コードは、反射効果を図形に適用する方法を示します:
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


## **Apply Glow Effect**

この JavaScript コードは、光彩効果を図形に適用する方法を示します:
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


## **Apply Soft Edges Effect**

この JavaScript コードは、ソフト エッジ効果を図形に適用する方法を示します:
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


## **FAQ**

**Can I apply multiple effects to the same shape?**

はい、影、反射、光彩など異なる効果を同じ図形に組み合わせて、より動的な外観にすることができます。

**What shapes can I apply effects to?**

オートシェイプ、グラフ、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形に効果を適用できます。

**Can I apply effects to grouped shapes?**

はい、グループ化された図形にも効果を適用できます。効果はグループ全体に適用されます。