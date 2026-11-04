---
title: JavaScript を使用したプレゼンテーションの図形効果の適用
linktitle: 図形効果
type: docs
weight: 30
url: /ja/nodejs-java/shape-effect/
keywords:
- 図形効果
- 影効果
- 反射効果
- グロー効果
- ソフトエッジ効果
- 効果フォーマット
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides for Node.js を使用して高度な図形効果で PPT と PPTX ファイルを変換し、数秒でインパクトのあるプロフェッショナルなスライドを作成します。"
---
## **はじめに**

PowerPoint の効果は図形を目立たせるために使用できますが、[塗りつぶし](/slides/ja/nodejs-java/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPoint の効果を使用すると、図形にリアルな反射を作成したり、図形のグローを広げたりすることができます。

![Shape effect](shape-effect.png)

PowerPoint には図形に適用できる 6 つの効果が用意されています。1 つまたは複数の効果を図形に適用できます。

効果の組み合わせによっては他より見栄えが良くなります。このため、PowerPoint では **Preset** の下にオプションが用意されています。Preset オプションは、見栄えが良いと判明している 2 つ以上の効果の組み合わせです。このように、プリセットを選択すれば、さまざまな効果をテストしたり組み合わせたりして良い組み合わせを見つける時間を節約できます。

Aspose.Slides は、PowerPoint プレゼンテーションの図形に同じ効果を適用できるよう、[EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) クラスのプロパティおよびメソッドを提供します。

## **影効果の適用**

Aspose.Slides for Node.js via Java は、図形に対して外側および内側の影をサポートしています。影の色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側の影の適用**

外側の影を使用すると、カードやパネルがスライドの背景に対して際立ちます。影は図形のエッジの外側に広がり、図形がスライド上に浮き上がっているように見えます。影の色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

この JavaScript コードは、矩形に[外側の影効果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) を適用する方法を示しています：
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

![Shadow effect](shadow_effect.png)

### **内側の影の適用**

テンプレートのビジュアルスタイルを再現する場合は、内側の影を使用してカードやパネルに凹んだ外観を付けます。外側の影は図形の外側に広がり、浮き上がって見えるのに対し、内側の影はエッジの内側を陰影で表現します。

[enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) を呼び出し、次に [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) が返す影を設定します。ぼかし半径の値が大きいほど、エッジが柔らかくなります。

この JavaScript の例は、薄い青色のカードに濃い灰色の内側の影を付け、PPTX ファイルとして保存します。影の方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです：
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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

内側の影を削除するには、図形の EffectFormat で [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) を呼び出します。

## **反射効果の適用**

Aspose.Slides for Node.js via Java で反射効果を適用するには、図形に鏡面のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。この効果は図形により洗練された外観を与えることで、プレゼンテーションの美的感覚を高めます。シンプルなコードで簡単に実装でき、複数の要素に迅速に適用してデザインの一貫性を保つことができます。

この JavaScript コードは、図形に[反射効果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) を適用する方法を示しています：
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

![Reflection effect](reflection_effect.png)

## **グロー効果の適用**

Aspose.Slides for Node.js via Java で図形にグロー効果を適用するには、図形の周囲に柔らかな光のオーラを追加し、色やサイズなどのプロパティを調整します。この効果は図形を目立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の外観を向上させます。

この JavaScript コードは、図形に[グロー効果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) を適用する方法を示しています：
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

![Glow effect](glow_effect.png)

## **ソフトエッジ効果の適用**

Aspose.Slides for Node.js via Java でソフトエッジ効果を適用するには、図形のエッジ周辺に滑らかでぼやけた遷移を作成できます。この効果はより微妙で洗練された外観を加え、柔らかく穏やかな外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな図形に望ましい効果を実現できます。

この JavaScript コードは、図形に[ソフトエッジ効果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) を適用する方法を示しています：
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

![Soft edges effect](soft_edges_effect.png)

## **ぼかし効果の適用**

形状のぼかしを使用して、形状の塗りとアウトラインを柔らかくしながら、形状は編集可能なままにします。形状の EffectFormat で [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) を呼び出します。半径はポイント (1/72 インチ) 単位で測定され、負の値は使用できません。半径が大きくなるほどぼかしが強くなります。半径 0 は外観に変化を与えません。

[getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) 設定は効果の表示範囲を制御します。`false` の場合、ぼかしは元の描画範囲（アウトラインを含む）に切り取られます。`true` の場合、ぼかしはその範囲を超えて広がることができます。いずれの設定も形状の位置や寸法を変更しません。

以下の比較では、全体で同じ塗り、アウトライン、形状のサイズを使用しています。上段は `grow = false`、下段は `grow = true` を使用しています。

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

この JavaScript の例は、オレンジ色の矩形に濃い青のアウトラインを付け、5 ポイントのぼかしを適用し、さらに [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) を再度呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存し、次に [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) を呼び出してぼかしなしの形状を保存します。
```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

形状のぼかしは塗りとアウトラインの両方に影響します。ソフトエッジ効果は図形のエッジをフェードさせ、影のぼかしは影だけを柔らかくします。画像変換効果は画像コンテンツに対して適用されますが、この例では形状を画像に変換せず、直接 shape の EffectFormat にぼかしを適用しています。

## **よくある質問**

**同じ図形に複数の効果を適用できますか？**

はい、影、反射、グローなど、さまざまな効果を単一の図形に組み合わせて、より動的な外観を作り出すことができます。

**どのような図形に効果を適用できますか？**

自動図形、チャート、表、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形に効果を適用できます。

**グループ化された図形に効果を適用できますか？**

はい、グループ化された図形全体に効果を適用できます。効果はグループ全体に適用されます。