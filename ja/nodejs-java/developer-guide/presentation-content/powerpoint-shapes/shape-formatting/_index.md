---
title: JavaScript で PowerPoint の図形をフォーマットする
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
description: "Aspose.Slides を使用して JavaScript で PowerPoint の図形をフォーマットします—PPT、PPTX、ODP ファイルの塗りつぶし、線、効果スタイルを正確かつ完全に制御できます。"
---
## **導入**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、輪郭の効果を変更または適用して書式設定できます。さらに、内部の塗りつぶし方法を制御する設定を指定して図形を書式設定できます。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java は、PowerPoint で利用できる同じオプションを使用して図形を書式設定できるクラスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。手順は以下のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [線のスタイル](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 線の [ダッシュ スタイル](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) を設定します。
1. 図形の線の色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次のコードは、矩形 `AutoShape` の線を書式設定する方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation クラスのインスタンスを作成します（プレゼンテーション ファイルを表す）。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
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

    // Save the PPTX file to disk.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![プレゼンテーション内の書式設定された線](formatted-lines.png)

## **図形の線にスケッチ効果を適用**

スケッチ効果は、図形の線を手描き風に見せます。[Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) で線の設定にアクセスし、[LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) でスケッチ設定にアクセスし、[SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) で [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) 列挙体から値を選択します。

次の JavaScript コードは、[LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てられた値を読み取り、[LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) で効果を削除する方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // 形状の線フォーマットとそのスケッチフォーマットにアクセスします。
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // スケッチ効果を適用します。
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // 形状に直接割り当てられたスケッチ効果を読み取ります。
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // スケッチ効果を削除します。
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) が返す値は、図形に直接割り当てられた設定を表します。線の書式設定がテーマ、マスタースライド、またはレイアウトスライドから継承される場合は、[LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) を使用し、返されたオブジェクトで `getSketchFormat` を呼び出し、さらにその `getSketchType` メソッドを呼び出します。実際の継承が解決された後に適用される書式設定を示す有効な値が取得できます。

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

* 丸め
* 斜め
* ベベル

デフォルトでは、PowerPoint は角度が付いた 2 本の線（図形のコーナーなど）を結合するときに **丸め** 設定を使用します。ただし、鋭い角度の図形を描く場合は **斜め** オプションを選択した方が適しています。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

次の JavaScript コードは、上の画像に示された 3 つの矩形がそれぞれ Miter、Bevel、Round 結合スタイル設定で作成された方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantiate the Presentation class that represents a presentation file.
let presentation = new aspose.slides.Presentation();
try {
    // Get the first slide.
    let slide = presentation.getSlides().get_Item(0);

    // Add three auto shapes of the Rectangle type.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Set the fill color for each rectangle shape.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Set the line width.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Set the color for each rectangle's line.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Set the join style.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Add text to each rectangle.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Save the PPTX file to disk.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **グラデーション塗りつぶし**

PowerPoint では、グラデーション塗りつぶしは、図形に連続した色のブレンドを適用できる書式設定オプションです。たとえば、2 色以上を使用して、ある色が徐々に別の色へフェードするように適用できます。

Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を `Gradient` に設定します。
1. [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/) クラスが公開するグラデーション ストップ コレクションの `add` メソッドを使用し、位置を指定した 2 つ以上の好みの色を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の JavaScript コードは、楕円にグラデーション塗りつぶし効果を適用する方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

//    プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    //    最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    //    Ellipse タイプのオートシェイプを追加します。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    //    楕円にグラデーション書式設定を適用します。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    //    グラデーションの方向を設定します。
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    //    2 つのグラデーション ストップを追加します。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    //    PPTX ファイルをディスクに保存します。
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![グラデーション塗りつぶしの楕円](gradient-fill.png)

エクスポートした画像でグラデーションの見え方が PowerPoint と異なる場合は、[Choose a Gradient Rendering Style](/slides/ja/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。プレゼンテーションに保存されているグラデーション塗りつぶしを変更せずに、レンダリング スタイルを選択できます。

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、点、ストライプ、クロスハッチ、チェックなどの 2 色デザインを図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムカラーで選択できます。

Aspose.Slides は、プレゼンテーションの視覚的魅力を高めるために、図形に適用できる 45 以上のプリセット パターン スタイルを提供します。プリセット パターンを選択した後でも、使用する正確な色を指定できます。

Aspose.Slides を使用して図形にパターン塗りつぶしを適用する手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を `Pattern` に設定します。
1. プリセット オプションからパターン スタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の JavaScript コードは、矩形にパターン塗りつぶしを適用する方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 塗りつぶしタイプを Pattern に設定します。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // パターン スタイルを設定します。
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

PowerPoint の画像塗りつぶしは、画像を図形の内部に挿入し、実質的に図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して図形に画像塗りつぶしを適用する手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または他の好みのモード）に設定します。
1. 使用する画像から [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) オブジェクトを作成します。
1. 画像を `ISlidesPicture.setImage` メソッドに渡します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

    // Rectangle タイプのオートシェイプを追加します。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 塗りつぶしタイプを Picture に設定します。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // 画像塗りつぶしモードを設定します。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // 画像をロードし、プレゼンテーションのリソースに追加します。
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

### **テクスチャとしてタイル画像を使用**

タイル画像をテクスチャとして設定し、タイルの動作をカスタマイズしたい場合は、[PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): 画像塗りつぶしモードを `Tile` または `Stretch` に設定します。
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): 図形内でのタイルの配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): タイルを水平、垂直、または両方に反転するかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): 図形の原点からタイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): 図形の原点からタイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): タイルの水平スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): タイルの垂直スケールをパーセンテージで定義します。

次のコードサンプルは、タイル画像塗りつぶし付きの矩形図形を追加し、タイルオプションを構成する方法を示しています。

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

    // 画像をロードし、プレゼンテーションのリソースに追加します。
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

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。この単色の背景色は、グラデーション、テクスチャ、パターンなどなしで適用されます。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の JavaScript コードは、PowerPoint スライド上の矩形に単色塗りつぶしを適用する方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
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

![単色塗りつぶしの図形](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、テクスチャのいずれかの塗りつぶしを適用する際に、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度の値が高いほど図形は透けて見え、背景や下にあるオブジェクトが部分的に表示されます。

Aspose.Slides では、塗りつぶしに使用する色のアルファ値を調整することで透明度レベルを設定できます。手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透明度を含む色を定義します（ `alpha` コンポーネントが透明度を制御します）。
1. プレゼンテーションを保存します。

次の JavaScript コードは、矩形に透明な塗りつぶし色を適用する方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // ソリッド矩形のオートシェイプを追加します。
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // ソリッド形状の上に透明な矩形オートシェイプを追加します。
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

Aspose.Slides は、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件がある場合に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の回転プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

次の JavaScript コードは、図形を 5 度回転させる方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
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

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) プロパティを構成することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスをインスタンス化します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) を構成してベベル設定を定義します。
1. プレゼンテーションを保存します。

次の JavaScript コードは、図形に 3D ベベル効果を適用する方法を示しています。

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

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) プロパティを構成することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) と [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) を使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

次の JavaScript コードは、図形に 3D 回転効果を適用する方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// プレゼンテーション クラスのインスタンスを作成します。
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

## **図形の白黒レンダリング制御**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) メソッドは、プレゼンテーションを白黒モードで表示または処理する際に、個々の図形がどのようにレンダリングされるかを指定します。このメソッド自体が白黒表示を有効にするわけではなく、通常のカラー モードでの図形の塗りつぶし、線、その他の書式設定も変更しません。

[BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) 列挙体の値を使用して目的の動作を選択します。たとえば、`Automatic` はレンダリング アプリケーションに変換を任せ、`Gray` と `LightGray` はグレー表示、`BlackWhite` は黒と白のみ、`Black` と `White` は単一色、`Color` は通常のカラーを保持、`Hidden` は白黒モードで図形を非表示にします。`NotDefined` は図形レベルのモードが設定されていないことを意味します。

次の JavaScript コードは、カラー図形を作成し、白黒表示モードで灰色に表示させる例です。

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

通常のカラー モードでは、矩形はオレンジの塗りつぶしが保持されます。白黒表示ワークフローでは、モードが `Gray` に設定されているため灰色で表示されます。これにより、フルカラーのスライドを保持しつつ、印刷やプレビューなど、プレゼンテーションの白黒表示設定を尊重するワークフローのために別の外観を定義できます。

## **書式設定のリセット**

次の JavaScript コードは、スライドの書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) 上のプレースホルダーを含むすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示しています。

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

**図形の書式設定は最終的なプレゼンテーション ファイルのサイズに影響しますか？**

ほとんど影響はありません。埋め込み画像やメディアがファイル容量の大部分を占め、色や効果、グラデーションなどの図形パラメータはメタデータとして保存され、実質的なサイズ増加はほとんどありません。

**同じ書式設定を持つ図形をスライド上で検出し、グループ化するにはどうすればよいですか？**

各図形の主要な書式設定プロパティ（塗りつぶし、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にグループ化できます。これにより、後のスタイル管理が容易になります。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

できます。目的のスタイルを持つサンプル図形をテンプレート スライド デッキまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成するときにテンプレートを開き、必要なスタイル済み図形をクローンし、必要な場所で書式設定を再適用します。