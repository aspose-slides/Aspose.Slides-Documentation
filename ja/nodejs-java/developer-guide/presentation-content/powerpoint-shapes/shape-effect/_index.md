---
title: JavaScript を使用したプレゼンテーションでの図形効果の適用
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
- エフェクト形式
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides for Node.js を使用して高度な図形効果で PPT および PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **導入**

PowerPoint の効果は図形を目立たせるために使用できますが、[塗りつぶし](/slides/ja/nodejs-java/shape-formatting/#gradient-fill)や輪郭線とは異なります。PowerPoint の効果を使用すると、図形にリアルな反射を作成したり、光彩を広げたりできます。

![形状の効果](shape-effect.png)

PowerPoint には図形に適用できる 6 種類の効果があります。1 つまたは複数の効果を図形に適用できます。

効果の組み合わせの中には、他より見栄えが良いものがあります。そのため、PowerPoint では **プリセット** オプションを提供しています。プリセットは、見栄えが良いと判断された 2 個以上の効果の組み合わせです。プリセットを選択すれば、効果の組み合わせを試行錯誤する手間を省けます。

Aspose.Slides は、[EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) クラスのプロパティとメソッドを通じて、PowerPoint プレゼンテーションの図形に同じ効果を適用できるようにしています。

## **影効果の適用**

Aspose.Slides for Node.js via Java は、図形の外側影と内側影をサポートしています。色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせられます。

### **外側の影を適用**

外側の影を使用すると、カードやパネルがスライドの背景から浮き上がって見えます。影が図形のエッジの外側に伸び、図形がスライド上に持ち上げられたように感じさせます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

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

#### **図形が回転したときの影の方向を制御する**

既定では、外側の影は図形とともに回転します。同じ方向から光が当たっているように見せたい場合は、`false` を指定して [setRotateShadowWithShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setRotateShadowWithShape) を呼び出し、[setDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setDirection) で影の方向を統一します。

この例では、右に 42 ポイントオフセットした灰色の影を持つ青い矢印を 2 本作成します。次にスライドを複製し、両方の矢印を時計回りに 90° 回転させます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const before = presentation.getSlides().get_Item(0);
    
    const left = before.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    left.getFillFormat().getSolidFillColor().setColor(fillColor);
    left.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    left.getEffectFormat().enableOuterShadowEffect();
    const shadow = left.getEffectFormat().getOuterShadowEffect();
    const shadowColor = java.getStaticFieldValue("java.awt.Color", "GRAY");
    shadow.getShadowColor().setColor(shadowColor);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    const right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    const after = presentation.getSlides().addClone(before);
    const arrows = after.getShapes();
    for (let i = 0; i < arrows.size(); i++) {
        arrows.get_Item(i).setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

2 番目のスライドでは、左側の矢印の影は下向きに、右側の矢印の影は依然として右向きです。設定した方向は両方の影とも 0° のままです。

![90° 回転前後の PowerPoint レンダリング。両方の影は右側から開始し、回転後は左矢印の下に、右矢印の右側に残ります。](arrow-shadow-rotation.png)

### **内側の影を適用**

テンプレートのビジュアルスタイルを再現する際は、内側の影を使用してカードやパネルにくぼんだ外観を付与します。外側の影は図形外側に伸びて浮き上がって見えるのに対し、内側の影はエッジ内側を暗くします。

[enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) を呼び出し、[getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) が返す影を構成します。ぼかし半径が大きいほどエッジは柔らかくなります。

この JavaScript の例は、薄い青のカードに濃い灰色の内側影を付けて PPTX ファイルとして保存します。影の方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです:

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

![内側影付きの薄い青の矩形](inner_shadow_effect.png)

内側影を削除するには、図形の effect format に対して [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) を呼び出します。

### **プリセット影の適用、変更、削除**

[enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) を呼び出し、[setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) で [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/) を選択します。同じ図形でスタイルを切り替えるには、プリセットを変更します。影だけを除去したい場合は、[disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) を呼び出し、塗りつぶしと輪郭は残します。

この例は、1 枚のスライド上で 4 つの段階を横並びで示しています。両方の影は 10 ポイントオフセットです。方向 225° は最初の影を矩形の左上に、45° は二番目の影を右下に配置します。

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

| 元の状態 | 最初のプリセット | 二番目のプリセット | 削除後 |
| :---: | :---: | :---: | :---: |
| ![影なし](preset_shadow_original.png) | ![左上ドロップ影](preset_shadow_top_left.png) | ![右下ドロップ影](preset_shadow_bottom_right.png) | ![削除後の影なし](preset_shadow_removed.png) |

## **反射効果の適用**

Aspose.Slides for Node.js via Java で反射効果を適用するには、図形に鏡面のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。この効果は、図形に洗練された外観を与えてプレゼンテーションを美しくします。簡単なコードで実装でき、複数要素に一貫したデザインを迅速に適用できます。

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

## **光彩効果の適用**

Aspose.Slides for Node.js via Java で光彩効果を適用すると、図形の周囲に柔らかく光るオーラを追加でき、色やサイズなどのプロパティを調整できます。この効果は図形を際立たせ、プレゼンテーションに目を引く視覚要素を加えます。最小限のコードで実装でき、スライド全体の外観を向上させます。

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

## **ソフトエッジ効果の適用**

Aspose.Slides for Node.js via Java でソフトエッジ効果を適用すると、図形のエッジ周辺に滑らかでぼやけた遷移が作成できます。この効果は、より繊細で洗練された外観を提供し、柔らかい印象が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな図形に適用できます。

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

## **ぼかし効果の適用**

形状のぼかしを使用すると、図形の塗りつぶしと輪郭をソフト化しながら、図形は編集可能なままです。図形の effect format に対して [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) を呼び出します。半径はポイント (1/72 インチ) で測定し、負の値は使用できません。値が大きいほど強いぼかしになります。半径が 0 の場合、外観は変更されません。

[getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) 設定は効果の可視範囲を制御します。`false` の場合、ぼかしは元の描画範囲（輪郭を含む）にクリップされます。`true` の場合、ぼかしはその範囲を超えて広がります。どちらの場合も図形の位置やサイズは変わりません。

以下の比較は、全体で同じ塗りつぶし、輪郭、図形サイズを使用しています。上段は `grow = false`、下段は `grow = true` です。

![元の矩形と 5 ポイントおよび 15 ポイントのぼかし半径、grow 停止と有効の比較](shape_blur_comparison.png)

この JavaScript の例は、オレンジの矩形に濃い青の輪郭を付け、5 ポイントのぼかしを適用し、続いて [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) を再度呼び出して 15 ポイントに更新します。両方のぼかし状態を保存し、最後に [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) を呼び出してぼかしなしの図形を保存します。

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

形状のぼかしは塗りつぶしと輪郭を同時に影響します。ソフトエッジ効果は図形のエッジをフェードさせ、影のぼかしは影だけを柔らかくします。画像変換効果は画像コンテンツに対して適用されますが、この例は図形を画像に変換せず、直接 shape の effect format にぼかしを適用しています。

## **FAQ**

**同じ図形に複数の効果を適用できますか？**

はい、影、反射、光彩など異なる効果を組み合わせて、1 つの図形に動的な外観を作れます。

**どの図形に効果を適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形に適用できます。

**グループ化された図形に効果を適用できますか？**

はい、グループ化された図形全体に効果が適用されます。