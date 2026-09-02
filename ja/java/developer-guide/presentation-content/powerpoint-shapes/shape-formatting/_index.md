---
title: JavaでPowerPoint図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/java/shape-formatting/
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
- 3D ベベル効果
- 3D 回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java で PowerPoint の図形をフォーマットする方法を学び、PPT、PPTX、ODP ファイルに対して塗りつぶし、線、効果のスタイルを正確かつ完全にコントロールできるようにします。"
---
## **概要**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、輪郭を変更したり効果を適用したりして書式設定できます。また、内部の塗りつぶしを制御する設定を指定して図形をフォーマットすることもできます。

![PowerPoint の図形書式設定](format-shape-powerpoint.png)

Aspose.Slides for Java は、PowerPoint で使用できるのと同じオプションを使用して図形をフォーマットするためのインターフェイスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [線のスタイル](https://reference.aspose.com/slides/ja/java/com.aspose.slides/linestyle/) を設定します。
1. 線幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/ja/java/com.aspose.slides/linedashstyle/) を設定します。
1. 図形の線色を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

次のコードは、長方形の `AutoShape` を書式設定する方法を示しています。

```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 長方形シェイプの塗りつぶし色を設定します。
    shape.getFillFormat().setFillType(FillType.NoFill);

    // 長方形の線に書式設定を適用します。
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // 長方形の線の色を設定します。
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // PPTX ファイルをディスクに保存します。
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![プレゼンテーション内の書式設定された線](formatted-lines.png)

## **図形の線へのスケッチ効果の適用**

スケッチ効果は、図形の線を手描きのように見せます。[IShape.getLineFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) で線設定にアクセスし、[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilineformat/) でスケッチ設定にアクセスし、[ISketchFormat.setSketchType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isketchformat/) で [LineSketchType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/linesketchtype/) 列挙体から値を選択します。

次の Java コードは、[LineSketchType.Curved](https://reference.aspose.com/slides/ja/java/com.aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てられた値を読み取り、[LineSketchType.None](https://reference.aspose.com/slides/ja/java/com.aspose.slides/linesketchtype/) で効果を削除する方法を示しています。

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // シェイプの線フォーマットとそのスケッチフォーマットにアクセスします。
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // スケッチ効果を適用します。
    sketchFormat.setSketchType(LineSketchType.Curved);

    // シェイプに直接割り当てられたスケッチ効果を読み取ります。
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // スケッチ効果を削除します。
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isketchformat/) が返す値は、図形に直接割り当てられた設定を表します。テーマ、マスタースライド、またはレイアウトスライドから線の書式設定が継承される可能性がある場合は、[ILineFormat.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilineformat/) を使用し、[ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilineformateffectivedata/) にアクセスし、[ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isketchformateffectivedata/) を読み取ります。実効値は、継承が解決された後に実際に適用される書式設定を反映します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **結合スタイルの書式設定**

結合タイプのオプションは次の 3 つです。

* Round
* Miter
* Bevel

デフォルトでは、PowerPoint は 2 本の線を角度で結合する際に **Round** 設定を使用します。ただし、鋭角の形状を描く場合は **Miter** オプションが好ましいことがあります。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

次の Java コードは、上の画像に示された 3 つの長方形が Miter、Bevel、Round 結合タイプ設定で作成された方法を示しています。

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

    // 各長方形シェイプの塗りつぶし色を設定します。
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // 線幅を設定します。
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // 各長方形の線の色を設定します。
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

    // 各長方形にテキストを追加します。
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

PowerPoint のグラデーション塗りつぶしは、図形に連続的な色のブレンドを適用できる書式設定オプションです。たとえば、2 つ以上の色を徐々に変化させながら適用できます。

Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/filltype/) を `Gradient` に設定します。
1. [IGradientFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/igradientformat/) インターフェイスが公開するグラデーション ストップ コレクションの `add` メソッドを使用して、位置を指定した 2 つ以上の色を追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

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

    // 2 つのグラデーションストップを追加します。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // PPTX ファイルをディスクに保存します。
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![グラデーション塗りつぶしの楕円](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、ドット、ストライプ、クロスハッチ、チェックなどの 2 色デザインを図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムで選択できます。

Aspose.Slides は、プレゼンテーションの視覚的魅力を高めるために図形に適用できる 45 以上の事前定義パターン スタイルを提供します。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

Aspose.Slides を使用して図形にパターン塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義オプションからパターンスタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/ja/java/com.aspose.slides/patternformat/#getBackColor--) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/ja/java/com.aspose.slides/patternformat/#getForeColor--) を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

次の Java コードは、長方形にパターン塗りつぶしを適用する方法を示しています。

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

![パターン塗りつぶしの長方形](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、画像を図形の内部に挿入し、画像を図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して図形に画像塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または他の好みのモード）に設定します。
1. 使用する画像から [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) オブジェクトを作成します。
1. 画像を `ISlidesPicture.setImage` メソッドに渡します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

次の画像は「lotus.png」ファイルの例です。

![蓮の画像](lotus.png)

次の Java コードは、画像で図形を塗りつぶす方法を示しています。

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

    // 画像塗りつぶしモードを設定します。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // 画像をロードし、プレゼンテーションのリソースに追加します。
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

![画像塗りつぶしの図形](picture-fill.png)

### **テクスチャとしてタイル画像を設定**

タイル画像をテクスチャとして設定し、タイルの動作をカスタマイズしたい場合は、[IPictureFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/) インターフェイスおよび [PictureFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [setPictureFillMode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): 画像塗りつぶしモードを `Tile` または `Stretch` に設定します。
- [setTileAlignment](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): 図形内のタイルの配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): タイルを水平、垂直、または両方に反転するかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): 図形の原点からタイルの水平オフセット（ポイント単位）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): 図形の原点からタイルの垂直オフセット（ポイント単位）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): タイルの水平スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): タイルの垂直スケールをパーセンテージで定義します。

次のコード サンプルは、タイル画像塗りつぶし付きの長方形を追加し、タイルオプションを構成する方法を示しています。

```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 長方形のオートシェイプを追加します。
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 図形の塗りつぶしタイプを Picture に設定します。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 画像をロードし、プレゼンテーションのリソースに追加します。
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 画像を図形に割り当てます。
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

![タイルオプション](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。この単純な背景色は、グラデーション、テクスチャ、パターンなどなしで適用されます。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

次の Java コードは、PowerPoint スライドの長方形に単色塗りつぶしを適用する方法を示しています。

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

    // 塗りつぶしの色を設定します。
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // PPTX ファイルをディスクに保存します。
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![単色塗りつぶしの図形](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、テクスチャの塗りつぶしを適用する際に、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度の値が高いほど、図形が透過し、背景や下にあるオブジェクトが部分的に見えるようになります。

Aspose.Slides は、塗りつぶしに使用する色のアルファ値を調整することで透明度レベルを設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透明度付きの色を定義します（`alpha` 成分が透明度を制御します）。
1. プレゼンテーションを保存します。

次の Java コードは、長方形に透明な塗りつぶし色を適用する方法を示しています。

```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 実体となる長方形オートシェイプを追加します。
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 実体の上に透明な長方形オートシェイプを追加します。
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

![透明な図形](shape-transparency.png)

## **図形の回転**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内の図形を回転できます。これは、特定の配置やデザイン要件に合わせてビジュアル要素を配置する際に便利です。

スライド上の図形を回転する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の回転プロパティを目的の角度に設定します。
1. プレゼンテーションを保存します。

次の Java コードは、図形を 5 度回転させる方法を示しています。

```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 図形を 5 度回転させます。
    shape.setRotation(5);

    // PPTX ファイルをディスクに保存します。
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![図形の回転](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/threedformat/) プロパティを構成することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/threedformat/) を構成してベベル設定を定義します。
1. プレゼンテーションを保存します。

次の Java コードは、図形に 3D ベベル効果を適用する方法を示しています。

```java
// Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // スライドにシェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // シェイプの ThreeDFormat プロパティを設定します。
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

![3D ベベル効果](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/threedformat/) プロパティを構成することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. [setCameraType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icamera/#setCameraType-int-) と [setLightType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilightrig/#setLightType-int-) を使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

次の Java コードは、図形に 3D 回転効果を適用する方法を示しています。

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

![3D 回転効果](3D-rotation-effect.png)

## **書式設定のリセット**

次の Java コードは、スライドの書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/layoutslide/) 上のプレースホルダー付きすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // レイアウト上のプレースホルダーを持つスライド上の各シェイプをリセットします。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**形状の書式設定は最終的なプレゼンテーション ファイル サイズに影響しますか？**

影響は最小限です。埋め込まれた画像やメディアがファイル容量の大部分を占め、色や効果、グラデーションなどの形状パラメータはメタデータとして保存され、ほとんどサイズを増加させません。

**同じ書式設定を共有するスライド上の図形を検出してグループ化する方法は？**

各図形の主要な書式プロパティ（塗りつぶし、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルは同一とみなし、論理的にグループ化できます。これにより後のスタイル管理が簡素化されます。

**カスタム形状スタイルのセットを別ファイルに保存して他のプレゼンテーションで再利用できますか？**

はい。目的のスタイルを持つサンプル図形をテンプレートスライド デッキまたは .POTX テンプレート ファイルに保存します。新規プレゼンテーション作成時にテンプレートを開き、必要なスタイル付き図形をクローンし、必要な場所で書式設定を再適用します。