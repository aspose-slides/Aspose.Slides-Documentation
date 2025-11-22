---
title: JavaScript で PowerPoint の図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/nodejs-java/shape-formatting/
keywords:
- 図形のフォーマット
- 線のフォーマット
- 結合スタイルのフォーマット
- グラデーション塗りつぶし
- パターン塗りつぶし
- 画像塗りつぶし
- テクスチャ塗りつぶし
- 単色塗りつぶし
- 図形の透過性
- 図形の回転
- 3D ベベル効果
- 3D 回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して JavaScript で PowerPoint の図形をフォーマットする方法を学びます—PPT、PPTX、ODP ファイルの塗りつぶし、線、効果スタイルを正確かつ完全に制御できます。"
---

## **概要**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、輪郭線に対して効果を変更または適用することで書式設定が可能です。さらに、内部の塗りつぶし設定を指定して図形の書式設定を行うこともできます。

![図形の書式設定 (PowerPoint)](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java は、PowerPoint で利用できるのと同じオプションを使用して図形をフォーマットできるクラスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスです。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) を設定します。
1. 線幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) を設定します。
1. 図形の線の色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次のコードは、矩形 AutoShape の線をフォーマットする方法を示しています。
```js
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
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

## **結合スタイルの設定**

次の 3 つの結合タイプがあります。

* ラウンド
* ミーター
* ベベル

デフォルトでは、PowerPoint は角度のある2本の線（図形のコーナーなど）を結合するときに **ラウンド** 設定を使用します。ただし、鋭い角度の図形を描く場合は **ミーター** オプションを選択した方が良いでしょう。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

次の JavaScript コードは、上図のようにミーター、ベベル、ラウンドの結合タイプ設定を使用して 3 つの矩形を作成した例です。
```js
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを 3 つ追加します。
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

PowerPoint のグラデーション塗りつぶしは、図形に連続的な色のブレンドを適用できる書式設定オプションです。たとえば、2 つ以上の色を徐々にフェードさせながら適用できます。

Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスです。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を `Gradient` に設定します。
1. [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/) クラスが公開するグラデーションストップコレクションの `add` メソッドを使用し、位置を指定した 2 つの色を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の JavaScript コードは、楕円にグラデーション塗りつぶし効果を適用する方法を示しています。
```js
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // Ellipse タイプのオートシェイプを追加します。
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // 楕円にグラデーション書式設定を適用します。
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // グラデーションの方向を設定します。
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // 2 つのグラデーションストップを追加します。
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

PowerPoint のパターン塗りつぶしは、点、ストライプ、交差ハッチ、チェックなどの 2 色デザインを図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムカラーで指定できます。

Aspose.Slides には、プレゼンテーションの視覚効果を高めるために図形に適用できる 45 以上の定義済みパターンスタイルが用意されています。定義済みパターンを選択した後でも、使用する正確な色を指定できます。

Aspose.Slides を使用して図形にパターン塗りつぶしを適用する手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスです。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を `Pattern` に設定します。
1. 定義済みオプションからパターンスタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の JavaScript コードは、矩形にパターン塗りつぶしを適用する方法を示しています。
```js
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
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

PowerPoint の画像塗りつぶしは、画像を図形の内部に挿入し、図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して図形に画像塗りつぶしを適用する手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスです。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または他の希望モード）に設定します。
1. 使用する画像から [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) オブジェクトを作成します。
1. 画像を `ISlidesPicture.setImage` メソッドに渡します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の画像は「lotus.png」というファイルの例です。

![ロータスの画像](lotus.png)

次の JavaScript コードは、図形に画像を塗りつぶす方法を示しています。
```js
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
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

    // 画像をロードし、プレゼンテーションリソースに追加します。
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

### **テクスチャとして画像をタイル配置**

タイル状の画像をテクスチャとして設定し、タイル配置の動作をカスタマイズしたい場合は、[PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): 画像塗りつぶしモード（`Tile` または `Stretch`）を設定します。
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): 図形内でのタイルの配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): タイルを水平方向、垂直方向、または両方に反転させるかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): 図形の原点からタイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): 図形の原点からタイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): タイルの水平スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): タイルの垂直スケールをパーセンテージで定義します。

次のコード例は、矩形図形にタイル画像塗りつぶしを追加し、タイルオプションを構成する方法を示しています。
```js
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
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

![タイルオプションのプレビュー](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。このシンプルな背景色は、グラデーション、テクスチャ、パターンなしで適用されます。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスです。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の JavaScript コードは、PowerPoint スライドの矩形に単色塗りつぶしを適用する方法を示しています。
```js
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
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

![単色塗りつぶしが適用された図形](solid-color-fill.png)

## **透過性の設定**

PowerPoint では、図形に単色、グラデーション、画像、テクスチャ塗りつぶしを適用するときに、透過性レベルを設定して塗りつぶしの不透明度を制御できます。透過性の値が高いほど、図形が透けて見え、背景や下にあるオブジェクトが部分的に表示されます。

Aspose.Slides は、塗りつぶしに使用するカラーのアルファ値を調整することで透過性レベルを設定できます。手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスです。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透過性を持つ色（alpha コンポーネントで透過性を制御）を定義します。
1. プレゼンテーションを保存します。

次の JavaScript コードは、矩形に透過塗りつぶしカラーを適用する方法を示しています。
```js
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
let presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // ソリッド矩形オートシェイプを追加します。
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

![透過設定が適用された図形](shape-transparency.png)

## **図形の回転**

Aspose.Slides は、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件に合わせてビジュアル要素を調整する際に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスです。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の回転プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

次の JavaScript コードは、図形を 5 度回転させる例です。
```js
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
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

![図形の回転結果](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) プロパティを設定することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスです。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) を構成し、ベベル設定を定義します。
1. プレゼンテーションを保存します。

次の JavaScript コードは、図形に 3D ベベル効果を適用する例です。
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

![3D ベベル効果のプレビュー](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) プロパティを設定することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスです。
1. インデックスでスライドへの参照を取得します。
1. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) と [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) を使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

次の JavaScript コードは、図形に 3D 回転効果を適用する例です。
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

![3D 回転効果のプレビュー](3D-rotation-effect.png)

## **書式設定のリセット**

次の Java コードは、[LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) 上のプレースホルダーを含むすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示しています。
```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // レイアウトにプレースホルダーがあるスライド上の各シェイプをリセットします。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**形状の書式設定は最終的なプレゼンテーションのファイルサイズに影響しますか？**

影響は最小限です。埋め込み画像やメディアがファイルサイズの大部分を占め、色や効果、グラデーションなどの形状パラメータはメタデータとして保存され、実質的にサイズを増加させません。

**同じ書式設定を持つスライド上の図形を検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式設定プロパティ（塗りつぶし、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にグループ化します。これにより、後続のスタイル管理が簡素化されます。

**カスタムの図形スタイルセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

はい。希望するスタイルを持つサンプル図形をテンプレートスライドや .POTX テンプレートファイルに保存します。新しいプレゼンテーションを作成する際にテンプレートを開き、必要なスタイル付き図形をクローンして、必要な場所で書式設定を再適用します。