---
title: JavaScript を使用してプレゼンテーションの図形効果を適用する
linktitle: 図形効果
type: docs
weight: 30
url: /ja/nodejs-java/shape-effect/
keywords:
- 図形効果
- 影効果
- 反射効果
- 光彩効果
- ソフトエッジ効果
- 効果フォーマット
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides for Node.js を使用して高度な図形効果で PPT および PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **導入**

PowerPoint の効果は図形を際立たせるために使用できますが、[塗りつぶし](/slides/ja/nodejs-java/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPoint の効果を使用すると、図形にリアルな反射を作成したり、図形の光彩を広げたりできます。

![図形効果](shape-effect.png)

PowerPoint は図形に適用できる 6 つの効果を提供しています。1 つまたは複数の効果を図形に適用できます。

効果の組み合わせの中には他より見栄えが良いものがあります。そのため、PowerPoint は **プリセット** のオプションを提供しています。プリセットは、2 つ以上の効果の組み合わせで、見栄えが良いことが確認されています。プリセットを選択すれば、さまざまな効果をテストしたり組み合わせたりして最適な組み合わせを探す時間を無駄にする必要がありません。

Aspose.Slides は、PowerPoint プレゼンテーションの図形に同じ効果を適用できるように、[EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供しています。

## **影効果を適用する**

Aspose.Slides for Node.js via Java は、図形に対して外側および内側の影をサポートしています。色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側の影を適用する**

外側の影を使用すると、カードやパネルをスライドの背景から際立たせることができます。影は図形のエッジの外側まで広がり、図形がスライド上で持ち上げられているように見えます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

この JavaScript コードは、矩形に [外側の影効果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) を適用する方法を示しています:

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

![影効果](shadow_effect.png)

### **内側の影を適用する**

テンプレートのビジュアルスタイルを再現する際は、内側の影を使用してカードやパネルに凹んだ外観を与えます。外側の影は図形の外側に広がり、持ち上げられたように見せますが、内側の影はエッジの内部を陰影付けします。

[enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) を呼び出し、次に [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) が返す影を設定します。ぼかし半径の値が大きいほど、エッジが柔らかくなります。

この JavaScript の例は、淡い青色のカードにダークグレーの内側の影を付け、PPTX ファイルとして保存します。影の方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです:

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

![淡い青色の矩形（内側の影付き）](inner_shadow_effect.png)

内側の影を削除するには、図形の EffectFormat で [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) を呼び出します。

### **プリセット影を適用、変更、削除する**

[enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) を呼び出し、[setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) を使用して [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/) を選択します。スタイルを切り替えるには、同じ図形のプリセットを変更します。[disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) を呼び出すと、塗りつぶしとアウトラインは保持したまま影を削除できます。

この例は、1 枚のスライド上で 4 つの段階を横に並べて示しています。両方の影は 10 ポイントオフセットされています。方向が 225° の場合、最初の影は矩形の左上に配置され、45° の場合、2 番目の影は右下に配置されます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, aspose.slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const shape = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    const shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(aspose.slides.PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(aspose.slides.PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 元 | 最初のプリセット | 2 番目のプリセット | 削除後 |
| :---: | :---: | :---: | :---: |
| ![影なし](preset_shadow_original.png) | ![左上ドロップシャドウ](preset_shadow_top_left.png) | ![右下ドロップシャドウ](preset_shadow_bottom_right.png) | ![削除後の影なし](preset_shadow_removed.png) |

## **反射効果を適用する**

Aspose.Slides for Node.js via Java で反射効果を適用するには、図形に鏡のような反射を追加し、距離、透明度、サイズなどのパラメータを調整できます。この効果により、図形がより洗練された外観になり、プレゼンテーションの美観が向上します。シンプルなコードで簡単に実装でき、複数の要素に迅速に適用してデザインの一貫性を保つことができます。

この JavaScript コードは、図形に [反射効果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) を適用する方法を示しています:

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

## **光彩効果を適用する**

Aspose.Slides for Node.js via Java で図形に光彩効果を適用するには、図形の周囲に柔らかく光るオーラを追加し、色やサイズなどのプロパティを調整します。この効果は図形を際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の外観が向上します。

この JavaScript コードは、図形に [光彩効果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) を適用する方法を示しています:

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

![光彩効果](glow_effect.png)

## **ソフトエッジ効果を適用する**

Aspose.Slides for Node.js via Java でソフトエッジ効果を適用するには、図形のエッジ周辺に滑らかでぼかされた遷移を作成できます。この効果は、より控えめで洗練された外観を加え、柔らかく穏やかな外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな図形に目的の効果を実現できます。

この JavaScript コードは、図形に [ソフトエッジ効果](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) を適用する方法を示しています:

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

## **ぼかし効果を適用する**

形状ブラーを使用すると、形状の塗りとアウトラインをソフトにしながら、形状を編集可能なままにできます。形状の EffectFormat で [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) を呼び出します。半径はポイント (1/72 インチ) で測定され、非負の値を使用し、値が大きいほどブラーが強くなります。半径が 0 の場合、外観は変わりません。

[getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) 設定は効果の表示範囲を制御します。`false` の場合、ブラーは元の描画範囲（アウトラインを含む）にクリップされます。`true` の場合、ブラーはその範囲を超えて拡張できます。どちらの設定も形状の位置やサイズは変更しません。

以下の比較では、全体で同じ塗り、アウトライン、形状サイズを使用しています。上段は `grow = false`、下段は `grow = true` を使用しています。

![ぼかし半径 5 と 15 ポイント、grow 無効／有効の元の矩形比較](shape_blur_comparison.png)

この JavaScript の例は、オレンジ色の矩形にダークブルーのアウトラインを付け、5 ポイントのブラーを適用し、再度 [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) を呼び出して 15 ポイントのブラーに更新します。両方のブラー状態を保存し、次に [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) を呼び出してブラーなしの形状を保存します。

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

形状ブラーは塗りとアウトラインの両方に影響します。ソフトエッジ効果は形状のエッジをフェードさせ、影ブラーは影だけをソフトにします。画像変換効果は画像コンテンツに対して適用されますが、この例は形状を画像に変換せずに、直接形状の EffectFormat にブラーを適用しています。

## **よくある質問**

**同じ図形に複数の効果を適用できますか？**

はい、影、反射、光彩などの異なる効果を組み合わせて、1 つの図形に適用し、よりダイナミックな外観を作成できます。

**どのような図形に効果を適用できますか？**

自動図形、チャート、表、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形に効果を適用できます。

**グループ化された図形に効果を適用できますか？**

はい、グループ化された図形にも効果を適用できます。効果はグループ全体に適用されます。