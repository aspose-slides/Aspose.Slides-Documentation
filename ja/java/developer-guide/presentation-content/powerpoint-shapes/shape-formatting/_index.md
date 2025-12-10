---
title: Java で PowerPoint の図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/java/shape-formatting/
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
description: "Aspose.Slides を使用して Java で PowerPoint の図形をフォーマットする方法を学びます。PPT、PPTX、ODP ファイルに対して、塗りつぶし、線、効果のスタイルを正確かつ完全に制御できます。"
---

## **概要**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、輪郭の効果を変更または適用して線をフォーマットできます。また、図形の内部を塗りつぶす設定を指定してフォーマットすることもできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java は、PowerPoint で使用できる同じオプションを使用して図形をフォーマットするインターフェイスとメソッドを提供します。

## **線のフォーマット**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) を設定します。
1. 図形の線色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次のコードは、矩形の `AutoShape` の線をフォーマットする方法を示しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 矩形シェイプの塗りつぶしカラーを設定します。
    shape.getFillFormat().setFillType(FillType.NoFill);

    // 矩形の線に書式設定を適用します。
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // 矩形の線の色を設定します。
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTX ファイルをディスクに保存します。
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果:

![The formatted lines in the presentation](formatted-lines.png)

## **結合スタイルのフォーマット**

結合タイプのオプションは次の 3 つです。

* Round
* Miter
* Bevel

デフォルトでは、PowerPoint は角度のある 2 本の線（図形のコーナーなど）を結合するときに **Round** 設定を使用します。ただし、鋭角の図形を描く場合は **Miter** オプションが好ましいことがあります。

![The join style in the presentation](join-style-powerpoint.png)

次の Java コードは、上図のように Miter、Bevel、Round の結合タイプ設定を使用して 3 つの矩形を作成した例です。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを 3 つ追加します。
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // 各矩形シェイプの塗りつぶし色を設定します。
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // 線の幅を設定します。
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // 各矩形の線の色を設定します。
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // 結合スタイルを設定します。
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // 各矩形にテキストを追加します。
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // PPTX ファイルをディスクに保存します。
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **グラデーション塗りつぶし**

PowerPoint のグラデーション塗りつぶしは、図形に連続した色のブレンドを適用できるフォーマットオプションです。たとえば、2 色以上を徐々にフェードさせながら適用できます。

Aspose.Slides で図形にグラデーション塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を `Gradient` に設定します。
1. [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/) インターフェイスが提供するグラデーションストップコレクションの `add` メソッドを使用して、位置を指定した 2 つの色を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の Java コードは、楕円にグラデーション塗りつぶし効果を適用する方法を示しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipse タイプのオートシェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 楕円にグラデーション書式設定を適用します。
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // グラデーションの方向を設定します。
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // グラデーションストップを 2 つ追加します。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // PPTX ファイルをディスクに保存します。
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果:

![The ellipse with gradient fill](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、点・ストライプ・クロスハッチ・チェックなどの 2 色デザインを図形に適用できるフォーマットオプションです。パターンの前景色と背景色はカスタムで選択できます。

Aspose.Slides は、45 以上の事前定義パターンスタイルを提供し、プレゼンテーションの見栄えを向上させます。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

Aspose.Slides で図形にパターン塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義オプションからパターンスタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の Java コードは、矩形にパターン塗りつぶしを適用する例です。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 塗りつぶしタイプを Pattern に設定します。
    shape.getFillFormat().setFillType(FillType.Pattern);

    // パターンスタイルを設定します。
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // パターンの背景色と前景色を設定します。
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // PPTX ファイルをディスクに保存します。
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果:

![The rectangle with pattern fill](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、図形の内部に画像を挿入し、画像を図形の背景として使用できるフォーマットオプションです。

Aspose.Slides で画像塗りつぶしを図形に適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または他の好みのモード）に設定します。
1. 使用したい画像から [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) オブジェクトを作成します。
1. 画像を `ISlidesPicture.setImage` メソッドに渡します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の画像は「lotus.png」ファイルの例です。

![The lotus picture](lotus.png)

次の Java コードは、図形に画像塗りつぶしを適用する例です。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 塗りつぶしタイプを Picture に設定します。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 画像の塗りつぶしモードを設定します。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // 画像を読み込み、プレゼンテーションのリソースに追加します。
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // 画像を設定します。
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX ファイルをディスクに保存します。
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果:

![The shape with picture fill](picture-fill.png)

### **テクスチャとしてタイル画像を使用**

タイル画像をテクスチャとして設定し、タイルの動作をカスタマイズしたい場合は、[IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): 画像塗りつぶしモードを `Tile` または `Stretch` に設定します。
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): 図形内のタイル配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): タイルを水平、垂直、または両方に反転させるかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): 図形の原点からタイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): 図形の原点からタイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): タイルの水平スケール（パーセンテージ）を定義します。
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): タイルの垂直スケール（パーセンテージ）を定義します。

次のサンプルコードは、タイル画像塗りつぶしを持つ矩形形状を追加し、タイルオプションを構成する方法を示しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 矩形のオートシェイプを追加します。
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // シェイプの塗りつぶしタイプを Picture に設定します。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 画像を読み込み、プレゼンテーションのリソースに追加します。
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 画像をシェイプに割り当てます。
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // 画像塗りつぶしモードとタイル設定を構成します。
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // PPTX ファイルをディスクに保存します。
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果:

![The tile options](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶすフォーマットオプションです。グラデーション、テクスチャ、パターンは使用されません。

Aspose.Slides で図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を `Solid` に設定します。
1. 図形に好みの塗りつぶし色を割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の Java コードは、PowerPoint スライド上の矩形に単色塗りつぶしを適用する例です。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 塗りつぶしタイプを Solid に設定します。
    shape.getFillFormat().setFillType(FillType.Solid);

    // 塗りつぶし色を設定します。
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTX ファイルをディスクに保存します。
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果:

![The shape with solid color fill](solid-color-fill.png)

## **透過性の設定**

PowerPoint では、図形に単色、グラデーション、画像、テクスチャのいずれかの塗りつぶしを適用する際に、透過性レベルを設定して塗りつぶしの不透明度を制御できます。透過性が高いほど図形が透けて見え、背景や下にあるオブジェクトが部分的に表示されます。

Aspose.Slides では、塗りつぶしに使用する色のアルファ値を調整することで透過性レベルを設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透過性を持つ色を定義します（`alpha` コンポーネントが透過性を制御します）。
1. プレゼンテーションを保存します。

次の Java コードは、矩形に透過塗りつぶし色を適用する例です。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 塗りつぶしが設定された矩形オートシェイプを追加します。
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 塗りつぶしが設定された矩形の上に透明な矩形オートシェイプを追加します。
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // PPTX ファイルをディスクに保存します。
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果:

![The transparent shape](shape-transparency.png)

## **図形の回転**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内の図形を回転できます。特定の配置やデザイン要件に合わせて視覚要素を調整するのに便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の回転プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

次の Java コードは、図形を 5 度回転させる例です。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 図形を5度回転させます。
    shape.setRotation(5);

    // PPTX ファイルをディスクに保存します。
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果:

![The shape rotation](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) プロパティを構成することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスをインスタンス化します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) を構成してベベル設定を定義します。
1. プレゼンテーションを保存します。

次の Java コードは、図形に 3D ベベル効果を適用する例です。
```java
// Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // スライドに図形を追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // 図形の ThreeDFormat プロパティを設定します。
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) プロパティを構成することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) と [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) を使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

次の Java コードは、図形に 3D 回転効果を適用する例です。
```java
// Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果:

![The 3D rotation effect](3D-rotation-effect.png)

## **書式設定のリセット**

次の Java コードは、スライドの書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) 上のプレースホルダーを含むすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示しています。
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // レイアウト上のプレースホルダーを持つスライド上の各形状をリセットします。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**図形の書式設定は最終的なプレゼンテーションのファイルサイズに影響しますか？**

影響は最小限です。埋め込み画像やメディアがファイルサイズの大半を占め、色や効果、グラデーションなどの図形パラメータはメタデータとして保存され、実質的なサイズ増加はほとんどありません。

**同じ書式設定を持つ図形をスライド上で検出し、グループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗りつぶし、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にグループ化できます。これにより後続のスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

可能です。目的のスタイルを持つサンプル図形をテンプレートスライド デッキまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成するときはテンプレートを開き、必要なスタイルの図形をクローンして、必要な場所で書式設定を再適用します。