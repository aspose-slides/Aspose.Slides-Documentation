---
title: JavaScript で PowerPoint の図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/nodejs-java/shape-formatting/
keywords:
- 図形のフォーマット
- 線のフォーマット
- スケッチ効果
- スケッチ図形線
- 結合スタイルのフォーマット
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- 図形の透明度
- 白黒図形レンダリング
- グレースケール図形レンダリング
- 図形の回転
- 3D ベベル効果
- 3D 回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides を使用して JavaScript で PowerPoint の図形をフォーマットし、PPT、PPTX、ODP ファイルの塗りつぶし、線、効果スタイルを正確かつ完全に制御します。"
---
## **はじめに**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、輪郭の線を変更したり効果を適用したりして書式設定できます。また、図形の内部をどのように塗りつぶすかを制御する設定を指定して書式設定することもできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java は、PowerPoint で利用できるのと同じオプションを使用して図形を書式設定できるクラスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形に対してカスタムの線スタイルを指定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/linedashstyle/) を設定します。
1. 図形の線の色を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

次のコードは矩形 `AutoShape` の書式設定方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを追加します。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // 矩形シェイプから塗りつぶしを削除します。
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

スケッチ効果は、図形の線を手書き風に見せます。[Shape.getLineFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/) で線設定にアクセスし、[LineFormat.getSketchFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/lineformat/) でスケッチ設定にアクセスし、[SketchFormat.setSketchType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sketchformat/) で [LineSketchType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/linesketchtype/) 列挙体の値を選択します。

次の JavaScript コードは、[LineSketchType.Curved](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てられた値を取得し、[LineSketchType.None](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/linesketchtype/) で効果を削除する方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // シェイプの線の書式とそのスケッチ書式にアクセスします。
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // スケッチ効果を適用します。
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // シェイプに直接割り当てられたスケッチ効果を読み取ります。
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // スケッチ効果を削除します。
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sketchformat/) が返す値は、図形に直接割り当てられた設定を表します。線の書式設定がテーマ、マスタースライド、またはレイアウトスライドから継承される場合は、[LineFormat.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/lineformat/) を呼び出し、返されたオブジェクトで `getSketchFormat` を呼び、その後 `getSketchType` メソッドを呼び出します。実効値は継承が解決された後に実際に適用される書式設定を示します。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

* Round
* Miter
* Bevel

デフォルトでは、PowerPoint は角度で 2 本の線を結合する際（図形のコーナーなど）に **Round** 設定を使用します。ただし、鋭角の図形を描く場合は **Miter** オプションを選択した方が適しています。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

次の JavaScript コードは、上図のように Miter、Bevel、Round の結合タイプ設定を使用して 3 つの矩形を作成した例です。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを 3 つ追加します。
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // 各矩形シェイプの塗りつぶしカラーを設定します。
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

PowerPoint のグラデーション塗りつぶしは、図形に連続した色のブレンドを適用できる書式設定オプションです。例えば、2 色以上を徐々に変化させながら適用できます。

Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/filltype/) を `Gradient` に設定します。
1. [GradientFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/gradientformat/) クラスが公開するグラデーション ストップ コレクションの `add` メソッドを使用して、位置を指定した 2 つ以上の色を追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

次の JavaScript コードは、楕円にグラデーション塗りつぶし効果を適用する例です。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // 楕円タイプのオートシェイプを追加します。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // 楕円にグラデーション書式を適用します。
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

![グラデーション塗りつぶしが適用された楕円](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、ドット、ストライプ、クロスハッチ、チェックなどの 2 色デザインを図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムで選択できます。

Aspose.Slides は、プレゼンテーションの視覚効果を高めるために図形に適用できる 45 以上の事前定義パターン スタイルを提供します。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

Aspose.Slides を使用して図形にパターン塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義オプションからパターンスタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/patternformat/#getBackColor--) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/patternformat/#getForeColor--) を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

次の JavaScript コードは、矩形にパターン塗りつぶしを適用する例です。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
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

![パターン塗りつぶしが適用された矩形](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、図形の内部に画像を挿入し、画像を図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して図形に画像塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または他の希望モード）に設定します。
1. 使用する画像から [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) オブジェクトを作成します。
1. 画像を `ISlidesPicture.setImage` メソッドに渡します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

次の画像は「lotus.png」ファイルの例です。

![ロータスの画像](lotus.png)

次の JavaScript コードは、画像で図形を塗りつぶす方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
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

![画像塗りつぶしが適用された図形](picture-fill.png)

### **テクスチャとしてタイル画像を設定する**

タイル画像をテクスチャとして設定し、タイルの動作をカスタマイズするには、[PictureFillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/) クラスの次のメソッドを使用します。

- [setPictureFillMode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): 画像塗りつぶしモード（`Tile` または `Stretch`）を設定します。
- [setTileAlignment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): 図形内のタイルの配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): タイルを水平、垂直、または両方に反転させるかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): 図形の原点からタイルの水平方向オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): 図形の原点からタイルの垂直方向オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): タイルの水平方向スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): タイルの垂直方向スケールをパーセンテージで定義します。

次のコード サンプルは、タイル画像塗りつぶし付きの矩形図形を追加し、タイルオプションを構成する方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let firstSlide = presentation.getSlides().get_Item(0);

    // 矩形のオートシェイプを追加します。
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

    // 画像塗りつぶしモードとタイル設定プロパティを構成します。
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

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。このシンプルな背景色は、グラデーション、テクスチャ、パターンなしで適用されます。

Aspose.Slides で図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

次の JavaScript コードは、PowerPoint スライドの矩形に単色塗りつぶしを適用する例です。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを追加します。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 塗りつぶしタイプを Solid に設定します。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // 塗りつぶし色を設定します。
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX ファイルをディスクに保存します。
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![単色塗りつぶしが適用された図形](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、またはテクスチャ塗りつぶしを適用する際に、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度が高いほど図形が透けて見え、背景や下のオブジェクトが部分的に表示されます。

Aspose.Slides は、塗りつぶしに使用する色のアルファ値を調整することで透明度を設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透明度付きの色を定義します（`alpha` コンポーネントが透明度を制御します）。
1. プレゼンテーションを保存します。

次の JavaScript コードは、矩形に透明な塗りつぶし色を適用する例です。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // 塗りつぶしが設定された矩形オートシェイプを追加します。
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 塗りつぶしが設定された図形の上に透明な矩形オートシェイプを追加します。
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

Aspose.Slides は、PowerPoint プレゼンテーション内の図形を回転させることができます。これは、特定の配置やデザイン要件がある視覚要素の位置決めに便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の回転プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

次の JavaScript コードは、図形を 5 度回転させる例です。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
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

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/) プロパティを構成することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/) を構成してベベル設定を定義します。
1. プレゼンテーションを保存します。

次の JavaScript コードは、図形に 3D ベベル効果を適用する例です。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/) プロパティを構成することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
1. [setCameraType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/camera/#setCameraType) と [setLightType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/lightrig/#setLightType) を使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

次の JavaScript コードは、図形に 3D 回転効果を適用する例です。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **図形の白黒表示の制御**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) メソッドは、プレゼンテーションを白黒モードで表示または処理する際に、個々の図形がどのようにレンダリングされるかを指定します。このメソッド単体では白黒表示を有効にせず、通常のカラー モードでの図形の塗りつぶし、線、その他の書式設定も変更しません。

[BlackWhiteMode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/blackwhitemode/) 列挙体の値を使用して目的の動作を選択します。例として、`Automatic` はレンダリング アプリケーションに変換を任せ、`Gray` と `LightGray` はグレイ カラー、`BlackWhite` は黒と白のみ、`Black` と `White` は単一色、`Color` は通常のカラーを保持し、`Hidden` は白黒モードで図形を除外します。`NotDefined` は図形レベルのモードが割り当てられていないことを意味します。

次の JavaScript コードは、カラーの図形を作成し、白黒表示モードでグレーに表示させる例です。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // カラー モードではオレンジの塗りつぶしを保持し、白黒モードでは図形をグレーで表示します。
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

通常のカラー モードでは、矩形はオレンジの塗りつぶしが保持されます。白黒表示のワークフローでは、モードが `Gray` に設定されているためグレーで表示されます。これにより、フルカラーのスライドを保持しつつ、印刷やプレビュー、その他の白黒表示設定を尊重するワークフローで異なる外観を定義できます。

## **書式設定のリセット**

次の JavaScript コードは、スライドの書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/) 上のプレースホルダーを含むすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示します。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // レイアウト上にプレースホルダーがあるスライド上の各シェイプをリセットします。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Does shape formatting affect the final presentation file size?**

ほとんど影響しません。埋め込まれた画像やメディアがファイルサイズの大部分を占め、色、効果、グラデーションなどの図形パラメータはメタデータとして保存され、実質的に余分なサイズは増えません。

**How can I detect shapes on a slide that share identical formatting so I can group them?**

各図形の主要な書式設定プロパティ（塗りつぶし、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にそれらの図形をグループ化します。これにより、後のスタイル管理が簡素化されます。

**Can I save a set of custom shape styles to a separate file for reuse in other presentations?**

はい。目的のスタイルを持つサンプル図形をテンプレート スライド デックまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成する際にテンプレートを開き、必要なスタイル化された図形をクローンし、必要な場所で書式設定を再適用します。