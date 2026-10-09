---
title: JavaScript を使用したプレゼンテーションのシェイプ効果の適用
linktitle: シェイプ効果
type: docs
weight: 30
url: /ja/nodejs-java/shape-effect/
keywords:
- シェイプ効果
- 影効果
- 反射効果
- グロー効果
- ソフトエッジ効果
- エフェクト形式
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides for Node.js を使用して高度なシェイプ効果で PPT および PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **イントロダクション**

PowerPoint のエフェクトは図形を際立たせるために使用できますが、[塗りつぶし](/slides/ja/nodejs-java/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPoint のエフェクトを使用すると、図形にリアルな反射を作成したり、図形のグローを広げたりすることができます。

![形状エフェクト](shape-effect.png)

PowerPoint は図形に適用できる 6 つのエフェクトを提供しています。1 つまたは複数のエフェクトを図形に適用できます。

エフェクトの組み合わせによっては、他よりも見栄えが良くなります。そのため、PowerPoint は **Preset** の下にオプションを提供しています。Preset オプションは、見た目が良いと分かっている 2 つ以上のエフェクトの組み合わせです。これにより、プリセットを選択するだけで、さまざまなエフェクトをテストしたり組み合わせたりして適切な組み合わせを探す時間を浪費する必要がなくなります。

Aspose.Slides は、PowerPoint プレゼンテーションの図形に同じエフェクトを適用できるよう、[EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供します。

## **シャドウ効果の適用**

Aspose.Slides for Node.js via Java は、図形の外側シャドウと内側シャドウをサポートしています。色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側シャドウの適用**

外側シャドウを使用すると、カードやパネルをスライドの背景から際立たせることができます。シャドウは図形のエッジの外側に広がり、図形がスライド上に浮き上がっているように見せます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

この JavaScript コードは、矩形に[外側シャドウ効果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect)を適用する方法を示しています：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![シャドウ効果](shadow_effect.png)

### **内側シャドウの適用**

テンプレートのビジュアルスタイルを再現する際は、カードやパネルにくぼんだ外観を与えるために内側シャドウを使用します。外側シャドウは図形の外側に広がり、浮き上がって見えますが、内側シャドウはエッジの内側を陰影付けし、凹んだように見せます。

まず[enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect)を呼び出し、次に[getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect)が返すシャドウを構成します。ぼかし半径の値が大きいほど、エッジが柔らかくなります。

この JavaScript の例は、淡い青色のカードに濃い灰色の内側シャドウを作成し、PPTX ファイルとして保存します。シャドウの方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![内側シャドウ付きの淡い青い矩形](inner_shadow_effect.png)

内側シャドウを削除するには、図形の EffectFormat で[disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect)を呼び出します。

## **反射効果の適用**

Aspose.Slides for Node.js via Java で反射効果を適用するには、形状に鏡面のような反射を追加し、距離、透明度、サイズなどのパラメータを調整できます。この効果は、形状により洗練された外観を与えることで、プレゼンテーションの美観を向上させます。シンプルなコードで簡単に実装でき、複数の要素に素早く適用して一貫したデザインを実現できます。

この JavaScript コードは、形状に[反射効果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect)を適用する方法を示しています：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![反射効果](reflection_effect.png)

## **グロー効果の適用**

Aspose.Slides for Node.js via Java で形状にグロー効果を適用するには、形状の周囲に柔らかく光るオーラを追加し、色やサイズなどのプロパティを調整できます。この効果は形状を際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の見栄えを向上させます。

この JavaScript コードは、形状に[グロー効果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect)を適用する方法を示しています：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![グロー効果](glow_effect.png)

## **ソフトエッジ効果の適用**

Aspose.Slides for Node.js via Java でソフトエッジ効果を適用するには、形状のエッジ周辺に滑らかでぼやけたトランジションを作成できます。この効果は、より微妙で洗練された外観を加え、柔らかい外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな形状に望ましい効果を実現できます。

この JavaScript コードは、形状に[ソフトエッジ効果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect)を適用する方法を示しています：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ソフトエッジ効果](soft_edges_effect.png)

## **よくある質問**

**同じ図形に複数のエフェクトを適用できますか？**

はい、影、反射、グローなどの異なるエフェクトを単一の図形に組み合わせて、よりダイナミックな外観を作り出すことができます。

**どのような図形にエフェクトを適用できますか？**

自動図形、グラフ、表、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形にエフェクトを適用できます。

**グループ化された図形にエフェクトを適用できますか？**

はい、グループ化された図形にもエフェクトを適用できます。エフェクトはグループ全体に適用されます。