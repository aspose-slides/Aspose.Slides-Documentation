---
title: JavaでPowerPointの図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/java/shape-formatting/
keywords:
- 図形のフォーマット
- 線のフォーマット
- スケッチ効果
- 図形線のスケッチ
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
- 3Dベベル効果
- 3D回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java で PowerPoint の図形をフォーマットする方法を学びます—PPT、PPTX、ODP ファイル向けに塗りつぶし、線、効果のスタイルを正確に、完全にコントロールして設定できます。"
---
## **概要**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、アウトラインを変更したり効果を適用したりして線の書式設定が可能です。また、内部の塗りつぶし方法を指定して図形をフォーマットすることもできます。

![PowerPointの図形書式設定](format-shape-powerpoint.png)

Aspose.Slides for Java は、PowerPoint で利用できるのと同じオプションを使用して図形の書式設定を行うためのインターフェイスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/ja/java/com.aspose.slides/linestyle/) を設定します。
1. 線幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/ja/java/com.aspose.slides/linedashstyle/) を設定します。
1. 図形の線色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次のコードは、矩形の `AutoShape` の線を書式設定する方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 矩形シェイプの塗りつぶし色を設定します。
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

![プレゼンテーション内の書式設定された線](formatted-lines.png)

## **図形の線にスケッチ効果を適用**

スケッチ効果を使用すると、図形の線を手描き風に見せることができます。`[IShape.getLineFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/)` で線設定にアクセスし、`[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilineformat/)` でスケッチ設定にアクセスし、`[ISketchFormat.setSketchType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isketchformat/)` で `[LineSketchType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/linesketchtype/)` 列挙体の値を選択します。

次の Java コードは、`[LineSketchType.Curved](https://reference.aspose.com/slides/ja/java/com.aspose.slides/linesketchtype/)` 効果を適用し、明示的に設定された値を取得し、`[LineSketchType.None](https://reference.aspose.com/slides/ja/java/com.aspose.slides/linesketchtype/)` で効果を削除する方法を示しています。

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // 図形の線の書式とそのスケッチ書式にアクセスします。
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // スケッチ効果を適用します。
    sketchFormat.setSketchType(LineSketchType.Curved);

    // 図形に直接割り当てられたスケッチ効果を読み取ります。
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // スケッチ効果を削除します。
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

`[ISketchFormat.getSketchType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isketchformat/)` が返す値は、図形に直接割り当てられた設定を表します。線の書式設定がテーマ、マスタースライド、あるいはレイアウトスライドから継承される可能性がある場合は、`[ILineFormat.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilineformat/)` を使用して `[ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilineformateffectivedata/)` にアクセスし、`[ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isketchformateffectivedata/)` を読み取ります。実効値は、継承が解決された後に実際に適用される書式設定を反映します。

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

PowerPoint では、2 本の線を角度のある位置（例えば図形のコーナー）で結合する場合、デフォルトで **Round** が使用されます。ただし、鋭角の形状を描く場合は **Miter** の方が好ましいことがあります。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

次の Java コードは、上図のように Miter、Bevel、Round の結合タイプ設定を使用して 3 つの矩形を作成した例です。

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを3つ追加します。
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

    // 線幅を設定します。
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

PowerPoint のグラデーション塗りつぶしは、形状に連続した色のブレンドを適用できる書式設定オプションです。たとえば、2 色以上を徐々にフェードさせる形で適用できます。

Aspose.Slides を使用して形状にグラデーション塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/filltype/) を `Gradient` に設定します。
1. `[IGradientFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/igradientformat/)` インターフェイスが提供するグラデーション ストップ コレクションの `add` メソッドを使用して、位置を指定した 2 つ以上の色を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の Java コードは、楕円にグラデーション塗りつぶし効果を適用する例です。

```java
import com.aspose.slides.*;

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

    // グラデーション ストップを2つ追加します。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // PPTX ファイルをディスクに保存します。
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![グラデーション塗りつぶしが適用された楕円](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、ドット、ストライプ、クロスハッチ、チェックなどの 2 色デザインを図形に適用できる書式設定オプションです。パターンの前景色と背景色はカスタムで指定できます。

Aspose.Slides は、プレゼンテーションの視覚的魅力を高めるために、45 種類以上の事前定義パターンスタイルを提供します。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

Aspose.Slides を使用して図形にパターン塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義オプションからパターンスタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/ja/java/com.aspose.slides/patternformat/#getBackColor--) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/ja/java/com.aspose.slides/patternformat/#getForeColor--) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の Java コードは、矩形にパターン塗りつぶしを適用する例です。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![パターン塗りつぶしが適用された矩形](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、画像を図形の内部に挿入し、画像を図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して図形に画像塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または他の希望モード）に設定します。
1. 使用したい画像から `[IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/)` オブジェクトを作成します。
1. 画像を `ISlidesPicture.setImage` メソッドに渡します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

例として、以下の「lotus.png」画像があります。

![ロータス画像](lotus.png)

次の Java コードは、図形に画像塗りつぶしを適用する例です。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 塗りつぶしタイプを Picture に設定します。
    shape.getFillFormat().setFillType(FillType.Picture);

    // ピクチャー塗りつぶしモードを設定します。
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

![画像塗りつぶしが適用された図形](picture-fill.png)

### **テクスチャとしてタイル画像を使用**

タイル画像をテクスチャとして設定し、タイル化の動作をカスタマイズしたい場合は、`[IPictureFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/)` インターフェイスおよび `[PictureFillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/picturefillformat/)` クラスの次のメソッドを使用します。

- `[setPictureFillMode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-)` : `Tile` または `Stretch` のいずれかで画像塗りつぶしモードを設定します。
- `[setTileAlignment](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-)` : 図形内でタイルの配置を指定します。
- `[setTileFlip](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-)` : タイルを水平、垂直、またはその両方で反転させるかを制御します。
- `[setTileOffsetX](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-)` : 図形の原点からタイルの水平オフセット（ポイント単位）を設定します。
- `[setTileOffsetY](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-)` : 図形の原点からタイルの垂直オフセット（ポイント単位）を設定します。
- `[setTileScaleX](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-)` : タイルの水平スケールをパーセンテージで定義します。
- `[setTileScaleY](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-)` : タイルの垂直スケールをパーセンテージで定義します。

次のコードは、タイル画像塗りつぶしを持つ矩形を追加し、タイルオプションを構成するサンプルです。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 矩形のオートシェイプを追加します。
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

![タイルオプションのプレビュー](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。グラデーション、テクスチャ、パターンなどは使用せず、純粋な背景色が適用されます。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の Java コードは、スライド上の矩形に単色塗りつぶしを適用する例です。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![単色塗りつぶしが適用された図形](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、単色、グラデーション、画像、テクスチャのいずれかで塗りつぶした図形に対して透明度を設定し、塗りつぶしの不透明度を調整できます。透明度の値が大きいほど、図形は透けて背景や下にあるオブジェクトが部分的に見えるようになります。

Aspose.Slides では、塗りつぶしに使用する色のアルファ値を調整することで透明度を設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透明度（アルファ成分）を持つ色を定義します。
1. プレゼンテーションを保存します。

次の Java コードは、矩形に透明塗りつぶし色を適用する例です。

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // ソリッドな矩形オートシェイプを追加します。
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ソリッドシェイプの上に透明な矩形オートシェイプを追加します。
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

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件に合わせてビジュアル要素を回転させる際に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の回転プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

次の Java コードは、図形を 5 度回転させる例です。

```java
import com.aspose.slides.*;

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

![図形の回転](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides では、図形の `[ThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/threedformat/)` プロパティを構成することで 3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. `[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/)` クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに `[IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/)` を追加します。
1. 図形の `[ThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/threedformat/)` を設定してベベルを定義します。
1. プレゼンテーションを保存します。

次の Java コードは、図形に 3D ベベル効果を適用する例です。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![3D ベベル効果のプレビュー](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides では、図形の `[ThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/threedformat/)` プロパティを構成することで 3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. `[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/)` クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに `[IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/)` を追加します。
1. `[setCameraType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icamera/#setCameraType-int-)` と `[setLightType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilightrig/#setLightType-int-)` を使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

次の Java コードは、図形に 3D 回転効果を適用する例です。

```java
import com.aspose.slides.*;

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

![3D 回転効果のプレビュー](3D-rotation-effect.png)

## **図形の白黒表示制御**

`[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-)` メソッドは、プレゼンテーションが白黒モードで表示または処理される際に、個々の図形がどのように描画されるかを指定します。このメソッドだけで白黒表示が有効になるわけではなく、通常のカラー表示時の塗りつぶし・線・その他の書式設定は変更されません。

`[BlackWhiteMode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/blackwhitemode/)` クラスの値を使用して動作を選択します。例として、`Automatic` はアプリケーションに変換を委任し、`Gray` と `LightGray` はグレー表示、`BlackWhite` は黒と白のみ、`Black` と `White` は単一色、`Color` はカラーを保持、`Hidden` は白黒モードで図形を非表示にします。`NotDefined` は図形レベルでモードが設定されていないことを意味します。

次の Java コードは、カラーの図形を作成し、白黒表示モードでグレーとして表示させる例です。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // カラーモードではオレンジの塗りつぶしを保持し、白黒モードでは図形をグレーで描画します。
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

通常のカラー表示では、矩形はオレンジの塗りつぶしが保持されます。白黒表示のワークフローでは、モードが `Gray` に設定されているためグレーで表示されます。これにより、フルカラー スライドを維持しつつ、印刷やプレビューなど黒白表示を尊重するワークフローで別の外観を定義できます。

## **書式設定のリセット**

次の Java コードは、スライドの書式設定をリセットし、`[LayoutSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/layoutslide/)` 上のプレースホルダー付きすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // レイアウトにプレースホルダーがあるスライド上の各シェイプをリセットします。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**図形の書式設定は最終的なプレゼンテーション ファイル サイズに影響しますか？**

ほとんど影響しません。埋め込み画像やメディアがファイルサイズの大部分を占め、色や効果、グラデーションなどの図形パラメータはメタデータとして保存されるため、実質的なサイズ増加はほぼありません。

**同じ書式設定を持つ図形をスライド上で検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗りつぶし、線、効果設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にグループ化できます。これにより、後続のスタイル管理が容易になります。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

可能です。目的のスタイルを持つサンプル図形をテンプレート スライド デックまたは .POTX テンプレート ファイルに保存します。新規プレゼンテーション作成時にテンプレートを開き、必要なスタイルの図形をクローンして、必要な場所で書式設定を再適用します。