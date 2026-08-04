---
title: JavaScriptでPowerPointの図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/nodejs-java/shape-formatting/
keywords:
- 図形の書式設定
- 線の書式設定
- スケッチ効果
- 図形線のスケッチ
- 結合スタイルの書式設定
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- 図形の透明度
- 図形の回転
- 3Dベベル効果
- 3D回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides を使用して JavaScript で PowerPoint の図形をフォーマットします—PPT、PPTX、ODP ファイルに対して、塗りつぶし、線、エフェクトのスタイルを正確かつ完全に制御できます。"
---
## **イントロダクション**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、輪郭を変更したりエフェクトを適用したりして書式設定できます。また、内部の塗りつぶしを制御する設定を指定することで、図形の書式設定も行えます。

![PowerPoint の図形書式設定](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java は、PowerPoint で利用できる同じオプションを使用して図形をフォーマットするクラスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。手順は以下の通りです。

1. Presentation クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに AutoShape を追加します。
1. 図形の線のスタイルを設定します。
1. 線幅を設定します。
1. 線の破線スタイルを設定します。
1. 図形の線の色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下のコードは、矩形 AutoShape の線をフォーマットする方法を示しています。

```js
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを追加します。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // 矩形シェイプの塗りつぶし色を設定します。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // 矩形の線に書式設定を適用します。
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // 矩形の線の色を設定します。
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // PPTX ファイルをディスクに保存します。
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![プレゼンテーション内の書式設定された線](formatted-lines.png)

## **図形の線にスケッチ効果を適用する**

スケッチ効果は、図形の線を手描き風に見せます。`Shape.getLineFormat` で線の設定にアクセスし、`LineFormat.getSketchFormat` でスケッチ設定にアクセスし、`SketchFormat.setSketchType` で `LineSketchType` 列挙体から値を選択します。

以下の JavaScript コードは、`LineSketchType.Curved` 効果を適用し、明示的に設定した値を取得し、`LineSketchType.None` で効果を削除する方法を示しています。

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // 図形のライン形式とそのスケッチ形式にアクセスします。
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // スケッチ効果を適用します。
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // 図形に直接割り当てられたスケッチ効果を読み取ります。
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // スケッチ効果を削除します。
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

`SketchFormat.getSketchType` が返す値は、図形に直接割り当てられた設定を表します。線の書式設定がテーマ、マスタースライド、レイアウトスライドから継承される可能性がある場合は、`LineFormat.getEffective` を呼び出し、戻り値のオブジェクトで `getSketchFormat` を呼び、その後 `getSketchType` メソッドを呼びます。Effective 値は、継承が解決された後に実際に適用される書式設定を示します。

```js
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

結合タイプのオプションは次の 3 つです。

* Round（丸み）
* Miter（斜め切り）
* Bevel（面取り）

デフォルトでは、PowerPoint は角度で 2 本の線を結合するときに **Round** 設定を使用します。ただし、鋭角の図形を描く場合は **Miter** オプションを好むことがあります。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

以下の JavaScript コードは、上図のように Miter、Bevel、Round の結合タイプ設定で 3 つの矩形が作成された様子を示しています。

```js
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを 3 つ追加します。
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // 各矩形シェイプの塗りつぶし色を設定します。
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // 線幅を設定します。
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // 各矩形の線の色を設定します。
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // 結合スタイルを設定します。
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // 各矩形にテキストを追加します。
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // PPTX ファイルをディスクに保存します。
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **グラデーション塗りつぶし**

PowerPoint のグラデーション塗りつぶしは、図形に連続した色のブレンドを適用できる書式設定オプションです。たとえば、2 つ以上の色を徐々に変化させながら適用できます。

Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに AutoShape を追加します。
1. 図形の FillType を `Gradient` に設定します。
1. GradientFormat クラスが提供するグラデーションストップ コレクションの `add` メソッドを使用して、位置を指定した 2 つの好みの色を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の JavaScript コードは、楕円にグラデーション塗りつぶし効果を適用する方法を示しています。

```js
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // 楕円タイプのオートシェイプを追加します。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // 楕円にグラデーションの書式設定を適用します。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // グラデーションの方向を設定します。
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // 2 つのグラデーション ストップを追加します。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // PPTX ファイルをディスクに保存します。
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![グラデーション塗りつぶしの楕円](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、2 色のデザイン（点、ストライプ、クロスハッチ、チェックなど）を図形に適用できる書式設定オプションです。パターンの前景色と背景色を自由に選択できます。

Aspose.Slides には、プレゼンテーションの視覚効果を高めるために図形に適用できる 45 以上の事前定義パターン スタイルが用意されています。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

Aspose.Slides を使用して図形にパターン塗りつぶしを適用する手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに AutoShape を追加します。
1. 図形の FillType を `Pattern` に設定します。
1. 事前定義オプションからパターン スタイルを選択します。
1. パターンの背景色を設定します。
1. パターンの前景色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の JavaScript コードは、矩形にパターン塗りつぶしを適用する方法を示しています。

```js
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを追加します。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 塗りつぶしタイプを Pattern に設定します。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // パターンスタイルを設定します。
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // パターンの背景色と前景色を設定します。
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX ファイルをディスクに保存します。
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![パターン塗りつぶしの矩形](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、画像を図形の背景として挿入できる書式設定オプションです。

Aspose.Slides を使用して図形に画像塗りつぶしを適用する手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに AutoShape を追加します。
1. 図形の FillType を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または他の希望モード）に設定します。
1. 使用する画像から PPImage オブジェクトを作成します。
1. その画像を `ISlidesPicture.setImage` メソッドに渡します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

たとえば、次の画像「lotus.png」を使用するとします。

![ロータスの画像](lotus.png)

以下の JavaScript コードは、図形に画像塗りつぶしを適用する方法を示しています。

```js
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを追加します。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 塗りつぶしタイプを Picture に設定します。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // 画像塗りつぶしモードを設定します。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // 画像を読み込み、プレゼンテーションのリソースに追加します。
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // 画像を設定します。
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX ファイルをディスクに保存します。
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![画像塗りつぶしの図形](picture-fill.png)

### **テクスチャとしてタイル画像を設定する**

タイル画像をテクスチャとして設定し、タイルの動作をカスタマイズしたい場合は、PictureFillFormat クラスの次のメソッドを使用します。

- `setPictureFillMode`：画像塗りつぶしモードを `Tile` または `Stretch` に設定します。
- `setTileAlignment`：図形内のタイル配置を指定します。
- `setTileFlip`：タイルを水平、垂直、または両方に反転させるかを制御します。
- `setTileOffsetX`：図形の原点からタイルの水平方向オフセット（ポイント）を設定します。
- `setTileOffsetY`：図形の原点からタイルの垂直方向オフセット（ポイント）を設定します。
- `setTileScaleX`：タイルの水平方向スケールをパーセンテージで定義します。
- `setTileScaleY`：タイルの垂直方向スケールをパーセンテージで定義します。

以下のコード例は、タイル画像塗りつぶし付きの矩形を追加し、タイルオプションを構成する方法を示しています。

```js
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let firstSlide = presentation.getSlides().get_Item(0);

    // 矩形オートシェイプを追加します。
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // 図形の塗りつぶしタイプを Picture に設定します。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // 画像を読み込み、プレゼンテーションのリソースに追加します。
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 画像を図形に割り当てます。
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // 画像塗りつぶしモードとタイル設定を構成します。
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // PPTX ファイルをディスクに保存します。
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![タイルオプション](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。この単純な背景色は、グラデーション、テクスチャ、パターンなどを使用せずに適用されます。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに AutoShape を追加します。
1. 図形の FillType を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の JavaScript コードは、PowerPoint のスライド上の矩形に単色塗りつぶしを適用する方法を示しています。

```js
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを追加します。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 塗りつぶしタイプを Solid に設定します。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // 塗りつぶしの色を設定します。
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX ファイルをディスクに保存します。
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![単色塗りつぶしの図形](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、テクスチャのいずれかの塗りつぶしを適用する際に、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度の数値が高いほど、図形は背景や下にあるオブジェクトが透けて見えるようになります。

Aspose.Slides は、塗りつぶしに使用する色のアルファ値を調整することで透明度レベルを設定できます。手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに AutoShape を追加します。
1. FillType を `Solid` に設定します。
1. `Color` を使用して透明度を持つ色を定義します（アルファ成分が透明度を制御します）。
1. プレゼンテーションを保存します。

以下の JavaScript コードは、矩形に透明塗りつぶし色を適用する方法を示しています。

```js
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // ソリッド矩形オートシェイプを追加します。
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // ソリッドシェイプの上に透明な矩形オートシェイプを追加します。
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // PPTX ファイルをディスクに保存します。
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![透明な図形](shape-transparency.png)

## **図形の回転**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件に合わせて視覚要素を調整する際に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに AutoShape を追加します。
1. 図形の回転プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

以下の JavaScript コードは、図形を 5 度回転させる方法を示しています。

```js
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを追加します。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 図形を 5 度回転させます。
    shape.setRotation(5);

    // PPTX ファイルをディスクに保存します。
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![図形の回転](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、ThreeDFormat プロパティを設定することで図形に 3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに AutoShape を追加します。
1. 図形の ThreeDFormat を構成してベベル設定を定義します。
1. プレゼンテーションを保存します。

以下の JavaScript コードは、図形に 3D ベベル効果を適用する方法を示しています。

```js
// Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // スライドに図形を追加します。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // 図形の ThreeDFormat プロパティを設定します。
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![3D ベベル効果](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、ThreeDFormat プロパティを設定することで図形に 3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに AutoShape を追加します。
1. `setCameraType` と `setLightType` を使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

以下の JavaScript コードは、図形に 3D 回転効果を適用する方法を示しています。

```js
// Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![3D 回転効果](3D-rotation-effect.png)

## **書式設定のリセット**

以下の Java コードは、レイアウト スライド上のプレースホルダーを含むすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示しています。

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // レイアウト上にプレースホルダーがあるスライドの各シェイプをリセットします。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**形状の書式設定は最終的なプレゼンテーション ファイルのサイズに影響しますか？**

影響は最小限です。埋め込まれた画像やメディアがファイルサイズの大部分を占め、色、エフェクト、グラデーションなどの形状パラメータはメタデータとして保存され、ほとんどサイズを増やしません。

**同じ書式設定を持つスライド上の図形を検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式設定プロパティ（塗りつぶし、線、エフェクト）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にグループ化できます。これにより後続のスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存して、他のプレゼンテーションで再利用できますか？**

できます。目的のスタイルを持つサンプル図形をテンプレート スライド デッキまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成するときはテンプレートを開き、必要なスタイルの図形をクローンして、必要な場所に書式設定を再適用します。