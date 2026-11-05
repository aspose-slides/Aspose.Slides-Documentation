---
title: JavaScript で PowerPoint シェイプをフォーマットする
linktitle: シェイプの書式設定
type: docs
weight: 20
url: /ja/nodejs-java/shape-formatting/
keywords:
- シェイプの書式設定
- 線の書式設定
- スケッチ効果
- スケッチシェイプ線
- 結合スタイルの書式設定
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- シェイプの透明度
- 白黒シェイプレンダリング
- グレースケールシェイプレンダリング
- シェイプの回転
- 3D ベベル効果
- 3D 回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides を使用して JavaScript で PowerPoint のシェイプをフォーマットする方法を学びます。PPT および PPTX ファイルの塗りつぶし、線、効果のスタイルを正確かつ完全にコントロールできます。"
---
## **はじめに**

PowerPoint でシェイプの輪郭、塗りつぶし、効果を調整してフォーマットします。Aspose.Slides for Node.js via Java を使用すると、透過性、回転、3D フォーマットなどの設定をプログラムで制御できます。

![PowerPoint のシェイプ書式設定オプション](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java は、PowerPoint で利用できる同じオプションを使用してシェイプをフォーマットできるクラスとメソッドを提供します。

## **線の書式設定**

シェイプの輪郭を制御するには [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) を使用します。この例では、塗りつぶしなしの長方形に青色の破線輪郭を作成します。[LineFormat.setStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setStyle) は太い‑細い複合線を選択し、[LineFormat.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setWidth) で幅を 7 ポイントに設定し、[LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) で破線パターンを選択します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![プレゼンテーション内のフォーマットされた線](formatted-lines.png)

### **カスタム線破線パターンの設定**

事前定義された線スタイルで必要な破線の長さや間隔が提供されない場合は、[LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCustomDashPattern) を使用します。たとえばブランド輪郭や技術図のためです。パターンを割り当てると、線の破線スタイルが自動的に [LineDashStyle.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) に変更されます。

配列要素は破線と間隔の長さを交互に並べ、破線から始まります。各値は線幅の倍数です。`[4, 2]` を幅 3 ポイントで使用すると、12 ポイントの破線の後に 6 ポイントの間隔が続きます。有限で非負の値のペアを使用して完全な破線‑間隔セグメントを定義します。例ではすべての破線と間隔が見えるよう正の値を使用しています。

この例は同じ長さでフラットキャップの青い線を 5 本作成します。最初の 3 本は幅 3 ポイントでパターンを比較し、4 本目は最初のパターンを幅 2 倍にして破線と間隔の長さを倍にします。5 本目はカスタムパターンから実線に切り替えます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];

    for (let i = 0; i < patterns.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setCapStyle(java.newByte(aspose.slides.LineCapStyle.Flat));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        let pattern = java.newArray("float", patterns[i]);
        line.getLineFormat().setCustomDashPattern(pattern);
    }

    // 最後の線を実線スタイルに戻す。
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));

    presentation.save("custom_dash_patterns.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

事前定義された破線スタイルに戻す場合は、[LineDashStyle.Dash](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) を [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) に渡します。選択されたスタイルが線の外観を制御します。

結果（上から順に）: **{4, 2}, 3 pt**、**{1, 2}, 3 pt**、**{6, 2, 1, 2}, 3 pt**、**{4, 2}, 6 pt**、および **Solid, 3 pt**。

![3 つのカスタム破線パターン、最初のパターンを使用した太い線、実線](custom-dash-patterns.png)

### **線のキャップ設定**

[LineFormat.setCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCapStyle) を使用して開いた線の端を設定します。[LineCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linecapstyle/) クラスは次の 3 つの明示的なキャップスタイルを提供します。

- `Flat`: 線は端点で止まります。
- `Round`: 半円形のキャップが線幅の半分だけ端点を超えて伸びます。
- `Square`: 正方形のキャップが線幅の半分だけ端点を超えて伸びます。

クラスには `NotDefined` も含まれ、明示的にキャップスタイルが割り当てられていないことを示します。

キャップは線端にシンボルを付加する矢印ヘッドや、線セグメント間の角を制御するジョインとは異なります。この例では [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setBeginArrowheadStyle) と [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setEndArrowheadStyle) で矢印ヘッドを無効にし、キャップ形状だけを比較します。

次の例は同一の水平線を 3 本作成します。幅は 20 ポイントです。上から順に、フラット、ラウンド、スクエアのキャップを使用します。端点の水平座標は同じですが、ラウンドとスクエアのキャップは各端点から 10 ポイント伸びます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let capStyles = [aspose.slides.LineCapStyle.Flat, aspose.slides.LineCapStyle.Round, aspose.slides.LineCapStyle.Square];

    for (let i = 0; i < capStyles.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));
        line.getLineFormat().setCapStyle(java.newByte(capStyles[i]));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
    }

    presentation.save("line_caps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果（上から順に）: **Flat**、**Round**、**Square**。

![同一太線にフラット、ラウンド、スクエアのキャップを適用](line-caps.png)

## **シェイプ線へのスケッチ効果の適用**

スケッチ効果はシェイプの線を手描きのように見せます。[Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) で線設定にアクセスし、[LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getSketchFormat) でスケッチ設定にアクセスし、[SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#setSketchType) で [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) クラスから値を選択します。

次の JavaScript コードは [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) 効果の適用、明示的に設定された値の取得、[LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) で効果を除去する方法を示します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    let sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#getSketchType) が返す値はシェイプに直接割り当てられた設定を表します。線書式がテーマ、マスタースライド、レイアウトスライドから継承される可能性がある場合は、[LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective) を呼び出し、返されたオブジェクトで `getSketchFormat` を呼び、さらに `getSketchType` を呼び出します。有効な値は継承が解決された後に実際に適用される書式を反映します。この例は最初のスライドに少なくとも 1 つのシェイプがある既存のプレゼンテーションを使用し、両方の値を出力します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    let lineFormat = shape.getLineFormat();
    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **結合スタイルの書式設定**

* Round
* Miter
* Bevel

結合スタイルは 2 つの輪郭セグメントが角でどのように接続されるかを制御します。**Round** は丸みを帯びた角、**Miter** は鋭い角、**Bevel** は平らな角にします。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

この例は幅 15 ポイントの青い輪郭を持つ 3 つの黒い長方形を作成します。[LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) を使用して、[LineJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) のミーター、ベベル、ラウンドの値をそれぞれ適用し、角の描画方法を比較します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let miterShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let bevelShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let roundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    bevelShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    roundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    bevelShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    roundShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    miterShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    bevelShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    roundShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **鋭角でのミーター結合の制限**

[LineFormat.setMiterLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setMiterLimit) と、[LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) を [LineJoinStyle.Miter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) に設定して、鋭角がどれだけ伸びるかを制限します。

制限は結合の内側と外側の角間距離を線幅で割った比率です。たとえば `8` はミーター長さが線幅の最大 8 倍まで許容されることを意味し、ポイント単位の測定ではありません。角が制限を超える場合、PowerPoint はその角でベベル結合を使用します。制限を大きくするとより鋭い点になります。この設定はミーター結合にのみ影響し、角が両方の制限内に収まる場合は視覚的な変化はありません。

この例は幅 20 ポイントの輪郭を持つ 2 つの同一の塗りなし三角形を作成します。左側の三角形は制限 `2`、右側は `8` を使用します。各三角形は幅 80 ポイント、高さ 160 ポイントで、上部の角のミーター長さ‑線幅比は約 `4.12` です。その結果、PowerPoint は左側の頂点をベベルし、右側の頂点は保持します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let miterLimits = [2, 8];

    for (let i = 0; i < miterLimits.length; i++) {
        let triangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        triangle.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
        triangle.getLineFormat().setMiterLimit(java.newFloat(miterLimits[i]));
    }

    presentation.save("miter_limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果（上から順に）: 左側は **Miter limit 2**、右側は **miter limit 8**。

![ミーター制限 2 のベベル頂点とミーター制限 8 の尖った頂点](miter-limits.png)

## **グラデーション塗りつぶし**

グラデーション塗りつぶしはシェイプ全体に色をブレンドします。この例は楕円を左下から右上へ 45 度の線形グラデーションで赤から紫へ塗りつぶします。[FillFormat.getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat) を使用し、[GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientstopcollection/#addPresetColor) で 0 と 1 の位置（グラデーションの開始と終了）に色止点を配置します。既存の止点をクリアしてこの 2 色だけが使用されるようにします。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, aspose.slides.PresetColor.Red);

    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![グラデーション塗りつぶしされた楕円](gradient-fill.png)

エクスポートされた画像でグラデーションの見え方が PowerPoint と異なる場合は、[Choose a Gradient Rendering Style](/slides/ja/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。レンダリングスタイルを変更してもプレゼンテーションに保存されたグラデーション塗りつぶしは変更されません。

### **線形グラデーション角度の設定**

[GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) を使用して、[GradientShape.Linear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/) 塗りつぶしの向きを制御します。角度は度単位で時計回りに増加し、`0` は左から右、`90` は上から下、`180` は右から左、`270` は下から上です。小数の角度もサポートされます。`[0, 360)` 之外の有限角度は 1 回転で正規化されます。例: `-45` は `315`、`360` は `0` になります。

この例は 6 つの長方形を作成し、位置 `0`、`0.5`、`1` に同一の赤・緑・青の止点を設定します。スケーリングは無効にして、角度を長方形の比例に依存せず比較できるようにします。左から右への角度は、1 行目が `0`、`45`、`90`、2 行目が `135`、`180`、`270` です。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let angles = [0, 45, 90, 135, 180, 270];

    for (let i = 0; i < angles.length; i++) {
        let x = 30 + (i % 3) * 230;
        let y = 30 + Math.floor(i / 3) * 190;

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.False));
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果（上から順に）:

![上段 0°, 45°, 90°、下段 135°, 180°, 270° の線形グラデーション](linear-gradient-angles.png)

### **シェイプで線形グラデーションをスケーリング**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientScaled) は [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) を受け取ります。`False` に設定するとシェイプのサイズ変更時に幾何学的なグラデーション角度が保持され、`True` に設定するとシェイプの幅と高さに合わせてグラデーションがスケーリングされます。スケーリングが有効な非正方形シェイプでは、見た目の角度が割り当てた角度と異なる場合があります。

以下の例は `45` 度の角度と同じ色止点を使用します。左列は `False`、右列は `True` です。各列は上に横長矩形、下に縦長矩形を配置します。最初は同一の横幅で、2 番目の矩形の幅と高さを変更して、塗りつぶしがリサイズにどのように応答するかを示します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let scalingOptions = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.True];

    for (let column = 0; column < scalingOptions.length; column++) {
        for (let row = 0; row < 2; row++) {
            let x = 30 + column * 360;
            let y = row == 0 ? 30 : 150;

            let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

            let gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
            gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
            gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(java.newByte(scalingOptions[column]));

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果（左側はスケーリング無効、右側は有効）:

![左側は LinearGradientScaled=False、右側は True の 45° グラデーションを持つ横長・縦長矩形](linear-gradient-scaling.png)

スケーリングを無効にすると、対角の色帯は両矩形で同じ向きを保ちます。スケーリングを有効にすると、帯はシェイプの比例に合わせて伸縮します。これにより、テンプレートのグラデーションを別サイズのシェイプに適用するときに再現しやすくなります。正方形の場合、スケーリングを有効にしてもこの `45` 度グラデーションの見た目は変わりません。

線形グラデーションにのみ角度とスケーリング設定が適用され、[GradientShape.Radial] や [GradientShape.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/) の塗りつぶしは制御しません。

### **角度とグラデーション方向の組み合わせ**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setGradientDirection) は [GradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientdirection/) クラスからスタイルを選択しますが、数値角度の代替ではありません。線形グラデーションの場合、角度を [setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) で設定したまま、コーナースタイルで色が分布する領域を変更できます。角度やスケーリングを比較するときは方向を変更しないでください。

以下の例は同じ設定を逆順で適用します。2 つの矩形は同一の外観になり、方向を角度の前後に設定しても結果は変わりません。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < 2; i++) {
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.True));

        if (i == 0) {
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **パターン塗りつぶし**

パターン塗りつぶしはドット、ストライプ、チェックなどの 2 色デザインを適用します。この例は [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#setPatternStyle) でトレリスパターンを選択し、[PatternFormat.getBackColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor) で薄いグレーの背景色、[PatternFormat.getForeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor) で黄色のパターン色を設定します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![パターン塗りつぶしされた矩形](pattern-fill.png)

## **画像塗りつぶし**

画像塗りつぶしはシェイプ内に画像を使用します。この例はローカル画像を必要とし、[Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) でプレゼンテーションの画像コレクションにロードします。[PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) をタイルモードに設定すると、画像が矩形内で繰り返し表示されます。使用したソース画像は以下です。

![蓮の画像](lotus.png)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![画像塗りつぶしされたシェイプ](picture-fill.png)

### **テクスチャとして画像をタイル表示**

タイル画像をテクスチャとして設定し、タイル動作をカスタマイズしたい場合は、[PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): 画像の塗りつぶしモードを `Tile` または `Stretch` に設定します。
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): シェイプ内でタイルの配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): タイルを水平方向、垂直方向、または両方に反転するか制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): シェイプの原点からタイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): シェイプの原点からタイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): タイルの水平スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): タイルの垂直スケールをパーセンテージで定義します。

この例はローカル画像を使用し、元のサイズの 50% に縮小して繰り返すように [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) を構成します。オフセットを −32 ポイントに設定してタイルを水平・垂直にシフトし、右下揃えと両方向の反転で繰り返しテクスチャの配置を決定します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![タイルオプションのプレビュー](tile-options.png)

## **単色塗りつぶし**

単色塗りつぶしはシェイプに単一の均一な色を付けます。この例は [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) で単色塗りつぶしモードを選択し、[FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) で黄色を割り当て、矩形をプレゼンテーションに保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![単色塗りつぶしされたシェイプ](solid-color-fill.png)

### **テーマ参照を保持したまま色をコピー**

[ColorFormat.copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#copyFrom) を使用すると、色の種類、テーマ参照、変換を含む色定義全体をコピーできます。これは、塗りつぶし色を別のシェイプに転送する際に、プレゼンテーションのテーマに従い続ける必要がある場合に便利です。このメソッドは色のみをコピーし、塗りタイプ、輪郭、その他のシェイプ書式設定はコピーしません。宛先の塗りタイプは [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) で明示的に設定してください。

この例は左から右へ 3 つの矩形を作成します：ソース、テーマ対応コピー、固定 RGB コピーです。ソースは [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setSchemeColor) で最初のアクセント色を参照し、[ColorOperationCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/coloroperationcollection/#add) でティントを追加します。RGB コピーはソースの有効塗り色を使用するため、最初はすべて同一の青色に見えます。[ColorFormat.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setColor) を呼び出すと固定 RGB 値が設定され、既存のカラー変換がクリアされます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 65, 105, 225));

    let source = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 40, 180, 140);
    let themeCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 240, 40, 180, 140);
    let rgbCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 450, 40, 180, 140);

    for (let shape of [source, themeCopy, rgbCopy]) {
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    let sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(aspose.slides.SchemeColor.Accent1);
    sourceColor.getColorTransform().add(aspose.slides.ColorTransformOperation.Tint, java.newFloat(0.75));

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    let before = slide.getImage(1, 1);
    try {
        before.save("color-copy-before.png", aspose.slides.ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // テーマ参照は新しいアクセントカラーに従いますが、固定 RGB 値は従いません。
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 255, 69, 0));

    let after = slide.getImage(1, 1);
    try {
        after.save("color-copy-after.png", aspose.slides.ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

テーマ変更前、3 つの塗りはすべて一致しています:

![ソース、copyFrom 宛先、固定 RGB 宛先が同一の青塗り](color-copy-before.png)

テーマ変更後、ソースとテーマ対応コピーは新しいアクセント色とティントを保持し、固定 RGB コピーは青のままです:

![ソースと copyFrom 宛先がオレンジ塗り、固定 RGB 宛先は青のまま](color-copy-after.png)

コピーされた定義はソースから独立しています。その後ソースのテーマ参照や色の割り当て、変換の追加・削除を変更しても宛先は影響を受けません。テーマの変更は両シェイプに影響しますが、各シェイプは同じテーマ色を個別に参照しているためです。

プレゼンテーションを保存して再度開くと、[ColorFormat.getColorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorType) が返す色種別、テーマ参照、[ColorFormat.getColorTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorTransform) が返す変換コレクションが保持され、RGB へ平坦化されません。

異なるテーマコンテキスト（例: アクセント パレットが異なるプレゼンテーション）間でコピーすると、コピーされた参照は宛先のテーマに対して解決されます。同じ参照と変換でも、見える色が異なる場合があります。テーマカラーの構成方法の詳細は [Presentation Theme](/slides/ja/nodejs-java/presentation-theme/) を参照してください。

## **スライドの背景をシェイプの塗りつぶしとして使用**

シェイプがスライドの背景と一致させたい場合は、[AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#setUseBackgroundFill) を使用します。最初に [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) で [FillType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を設定して明示的な塗りつぶしを削除します。この組み合わせにより、シェイプはスタイル塗りつぶしではなくスライドの背景を使用します。フラグだけを有効にしても既存の明示的な塗りは削除されません。

これは [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) とは異なります。NoFill はシェイプの背後にあるオブジェクトをスライド背景で覆い隠しませんが、BackgroundFill はシェイプの背後にあるオブジェクトを背景領域で覆います。グラデーションは各シェイプ内で再開せず、スライド全体と同様に配置されます。

以下の例は、マスタで定義された背景をスライドが継承し、3 つの矩形の背後にマゼンタ帯を配置します。左矩形は背景を使用し、中央は塗りなし、右は背景塗りつぶしから明示的なオレンジ塗りつぶしに切り替えます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    // マスターからグラデーションを継承します。
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    slide.getLayoutSlide().getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    let background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    let gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, java.newInstanceSync("java.awt.Color", 0, 0, 139));
    gradient.getGradientStops().add(1, java.newInstanceSync("java.awt.Color", 135, 206, 250));

    // このオブジェクトを最初に追加すると矩形の背後に表示されます。
    let band = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    band.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    band.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let backgroundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    backgroundShape.setUseBackgroundFill(true);

    let noFillShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let explicitShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    explicitShape.setUseBackgroundFill(true);

    // 明示的な塗りつぶしを適用する前に背景塗りつぶしを無効にします。
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    explicitShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    presentation.save("background_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果（左から右へ）: **背景塗りつぶし**、**塗りつぶしなし**、**明示的な塗りつぶし**。マゼンタ帯は左と右の矩形で隠れますが、中央の矩形では見えます。

![背景塗りつぶし、塗りつぶしなし、明示的なオレンジ塗りつぶしがマゼンタ帯の上に表示される様子](background-fill.png)

同じ動作はスライドに直接定義された背景やレイアウトから継承された背景でも適用されます。シェイプはスライドの解決済み背景を使用します。この例ではスライドとレイアウトの背景を未定義にし、マスタがそれを供給するようにしています。

## **透明度の設定**

単色塗りつぶしの場合、色のアルファ成分が不透明度を制御します。0 が完全に透明、255 が完全に不透明です。この例は黄色の矩形にアルファ値 128 を使用し、約 50% の透明度にして下の矩形が見えるようにします。色は [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) で割り当てます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![透明なシェイプのプレビュー](shape-transparency.png)

## **シェイプの回転**

[Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) を使用してスライド平面上でシェイプを回転させます。角度は度単位で、時計回りが正です。この例は矩形を 5 度時計回りに回転させてプレゼンテーションを保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![シェイプの回転プレビュー](shape-rotation.png)

## **3D ベベル効果の追加**

[Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) を使用してシェイプに奥行きとベベルエッジを付けます。この例は緑の楕円にオレンジの輪郭を付け、[ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) で奥行きを 4 ポイントに設定し、[ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) を使用して幅と高さが 6 ポイントの円形上ベベルを適用します。正面向きの正射投影カメラと三点照明によりベベルが見えるようになります。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![3D ベベル効果のプレビュー](3D-bevel-effect.png)

## **3D 回転効果の追加**

シェイプの 3D 表示はカメラ設定で制御されます。この例は [Camera.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) に緯度 40°、経度 35°、回転 20° を設定します。[Camera.setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) で等角カメラを選択し、[LightRig.setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) でバランスの取れた照明を設定して、フォーマットされた矩形を保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![3D 回転効果のプレビュー](3D-rotation-effect.png)

## **シェイプの白黒レンダリングの制御**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) メソッドは、プレゼンテーションが白黒モードで表示または処理されるときに個々のシェイプがどのようにレンダリングされるかを指定します。このメソッドだけで白黒表示が有効になるわけではなく、通常のカラー表示時のシェイプの塗りや線、他の書式設定も変更しません。

[BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) クラスの値を使用して目的の動作を選択します。例: `Automatic` はアプリケーションに変換を委ね、`Gray` と `LightGray` は灰色で、`BlackWhite` は黒白のみ、`Black` と `White` は単一色、`Color` は通常のカラーを保持、`Hidden` は白黒モードでシェイプを除外します。`NotDefined` はシェイプレベルのモードが設定されていないことを意味します。

この例はオレンジの矩形を作成し、[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) で灰色表示を選択します。保存されたシェイプは通常のカラー表示ではオレンジの塗りを保持し、黒白表示をサポートするアプリケーションでは灰色で表示されます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

通常のカラー表示では矩形はオレンジの塗りを保持します。黒白表示のワークフローでは `Gray` が設定されているため灰色で表示されます。これにより、フルカラーのスライドを保持しつつ、印刷やプレビューなど黒白表示を尊重するワークフロー用に別の外観を定義できます。

## **書式設定のリセット**

[Slide.reset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#reset) を使用して、スライドプレースホルダーの位置、サイズ、書式設定を対応するレイアウトプレースホルダーから復元します。この例はレイアウトにリンクされたプレースホルダーを持つ既存のプレゼンテーションを必要とし、保存前にすべてのスライドをリセットします。対応するレイアウトプレースホルダーがないシェイプはリセットされません。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Does shape formatting affect the final presentation file size?**

シェイプの書式設定は、埋め込まれた画像やメディアに比べてほとんどデータを増やしません。画像塗りつぶしは画像がプレゼンテーションに保存されるため、ファイルサイズが増加する可能性があります。

**How can I detect shapes on a slide that share identical formatting so I can group them?**

各シェイプの主要な書式プロパティ（塗り、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルは同一とみなし、論理的にグループ化できます。これにより後のスタイル管理が簡素化されます。

**Can I save a set of custom shape styles to a separate file for reuse in other presentations?**

はい。目的のスタイルを持つサンプルシェイプをテンプレートスライド デッキまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成するときにテンプレートを開き、必要なスタイル付きシェイプをクローンして、必要な場所に書式設定を再適用します。