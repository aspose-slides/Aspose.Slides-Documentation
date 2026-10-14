---
title: JavaでPowerPointの図形をフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/java/shape-formatting/
keywords:
- 図形の書式設定
- 線の書式設定
- スケッチ効果
- スケッチ図形線
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
- 3Dベベル効果
- 3D回転効果
- 書式のリセット
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java で PowerPoint の図形をフォーマットする方法を学びます。PPT、PPTX、ODP ファイルに対して、塗り、線、効果のスタイルを正確に、完全に制御して設定できます。"
---
## **はじめに**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、アウトラインに対して変更や効果の適用で書式設定できます。また、内部の塗りつぶし方法を指定して図形をフォーマットすることもできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java は、PowerPoint で利用できるオプションと同じ方法で図形をフォーマットするインターフェイスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) を設定します。
1. 図形の線の色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次のコードは、矩形 `AutoShape` の書式設定方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを追加します。
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

## **図形の線にスケッチ効果を適用する**

スケッチ効果は、図形の線を手描き風に見せます。`[IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)` で線設定にアクセスし、`[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/)` でスケッチ設定にアクセスし、`[ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/)` で [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) 列挙体から値を選択します。

次の Java コードは、[LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てられた値を取得し、[LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) で効果を削除する方法を示しています。

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // 図形の線書式とそのスケッチ書式にアクセスします。
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

`[ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/)` が返す値は、図形に直接割り当てられた設定を表します。テーマ、マスタースライド、レイアウトスライドから継承できる場合は、`[ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/)` を使用し、`[ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/)` にアクセスして、`[ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/)` を読み取ります。継承が解決された後に実際に適用される書式が有効値として返されます。

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

次の 3 つの結合タイプオプションがあります。

* Round
* Miter
* Bevel

PowerPoint では、2 本の線を角度で結合するとき（図形の隅など）デフォルトで **Round** が使用されます。ただし、鋭角の図形を描く場合は **Miter** を選択した方が適しています。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

次の Java コードは、上図のように Miter、Bevel、Round の結合タイプ設定で 3 つの矩形を作成した例です。

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを 3 つ追加します。
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

## **グラデーション 塗りつぶし**

PowerPoint のグラデーション 塗りつぶしは、図形に連続的な色のブレンドを適用できる書式オプションです。たとえば、2 色以上を徐々に変化させながら適用できます。

Aspose.Slides を使用して図形にグラデーション 塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を `Gradient` に設定します。
1. [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/) インターフェイスが提供するグラデーション ストップ コレクションの `add` メソッドを使用し、位置を指定した 2 色以上を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の Java コードは、楕円にグラデーション 塗りつぶし効果を適用する例です。

```java
import com.aspose.slides.*;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 楕円タイプのオートシェイプを追加します。
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

![グラデーション塗りつぶしされた楕円](gradient-fill.png)

エクスポートした画像でグラデーションが PowerPoint と異なる場合は、[Choose a Gradient Rendering Style](/slides/ja/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。プレゼンテーションに保存されたグラデーション 塗りつぶしを変更せずに、レンダリング スタイルを選択できます。

## **パターン 塗りつぶし**

PowerPoint のパターン 塗りつぶしは、2 色のデザイン（ドット、ストライプ、クロスハッチ、チェックなど）を図形に適用できる書式オプションです。パターンの前景色と背景色をカスタムで設定できます。

Aspose.Slides は、45 以上の事前定義パターン スタイルを提供し、プレゼンテーションの視覚的魅力を高めるために図形に適用できます。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

次の手順で Aspose.Slides を使用して図形にパターン 塗りつぶしを適用します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義オプションからパターン スタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の Java コードは、矩形にパターン 塗りつぶしを適用する例です。

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを追加します。
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

![パターン塗りつぶしされた矩形](pattern-fill.png)

## **画像 塗りつぶし**

PowerPoint の画像 塗りつぶしは、図形の内部に画像を挿入し、画像を図形の背景として使用できる書式オプションです。

Aspose.Slides を使用して図形に画像 塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または他の希望モード）に設定します。
1. 使用したい画像から [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) オブジェクトを作成します。
1. 画像を `ISlidesPicture.setImage` メソッドに渡します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下は「lotus.png」という画像を使用した例です。

![ロータスの画像](lotus.png)

次の Java コードは、画像で図形を塗りつぶす方法を示しています。

```java
import com.aspose.slides.*;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを追加します。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 塗りつぶしタイプを Picture に設定します。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 画像塗りつぶしモードを設定します。
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

![画像塗りつぶしされた図形](picture-fill.png)

### **テクスチャとしてタイル状画像を使用する**

タイル状の画像をテクスチャとして設定し、タイルの動作をカスタマイズしたい場合は、[IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): 画像塗りつぶしモード（`Tile` または `Stretch`）を設定します。
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): 図形内のタイルの配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): タイルを水平、垂直、または両方に反転させるかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): 図形の基準点からタイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): 図形の基準点からタイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): タイルの水平スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): タイルの垂直スケールをパーセンテージで定義します。

次のコード サンプルは、タイル状画像塗りつぶしを持つ矩形を追加し、タイルオプションを構成する方法を示しています。

```java
import com.aspose.slides.*;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 矩形オートシェイプを追加します。
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 図形の塗りつぶしタイプを Picture に設定します。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 画像を読み込み、プレゼンテーションのリソースに追加します。
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

![タイルオプションの設定](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式オプションです。グラデーション、テクスチャ、パターンなどを使用せず、単色の背景色が適用されます。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の Java コードは、スライド上の矩形に単色塗りつぶしを適用する例です。

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを追加します。
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

![単色塗りつぶしされた図形](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、テクスチャのいずれかの塗りつぶしを適用する際に、透明度を設定して塗りつぶしの不透明度を制御できます。透明度の値が高いほど図形が透けて見え、背景や下のオブジェクトが部分的に表示されます。

Aspose.Slides は、塗りつぶしに使用する色のアルファ値を調整することで透明度を設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透明度を持つ色を定義します（`alpha` 成分が透明度を制御します）。
1. プレゼンテーションを保存します。

次の Java コードは、矩形に透明な塗りつぶし色を適用する例です。

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // ソリッド矩形オートシェイプを追加します。
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

Aspose.Slides は、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件に合わせて視覚要素を回転させる際に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の回転プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

次の Java コードは、図形を 5 度回転させる例です。

```java
import com.aspose.slides.*;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを追加します。
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

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) プロパティを構成することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) を設定してベベル設定を定義します。
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

![3D ベベル効果](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) プロパティを構成することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. `[setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-)` と `[setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-)` を使用して 3D 回転を定義します。
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

![3D 回転効果](3D-rotation-effect.png)

## **図形の白黒レンダリング制御**

`[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-)` メソッドは、プレゼンテーションが白黒モードで表示または処理されるときに個々の図形のレンダリング方法を指定します。このメソッドだけで白黒表示が有効になるわけではなく、通常のカラー表示時の塗り、線、その他の書式設定は変更されません。

`[BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/)` クラスの値を使用して目的の動作を選択します。例として、`Automatic` はレンダリング アプリケーションに変換を委ね、`Gray` と `LightGray` は灰色で、`BlackWhite` は黒と白のみ、`Black` と `White` は単一色、`Color` は通常のカラーを保持し、`Hidden` は白黒モードで図形を省略します。`NotDefined` は図形レベルのモードが割り当てられていないことを意味します。

次の Java コードは、カラー図形を作成し、白黒表示モードで灰色に表示させる例です。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // カラーモードではオレンジの塗りつぶしを保持し、白黒モードでは図形をグレーカラーでレンダリングします。
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

通常カラー表示では矩形はオレンジの塗りつぶしを保持しますが、白黒表示のワークフローではモードが `Gray` に設定されているため灰色で表示されます。これにより、フルカラーのスライドを保持しつつ、印刷やプレビューなどの白黒表示設定を尊重するワークフローで別の外観を定義できます。

## **書式のリセット**

次の Java コードは、スライドの書式をリセットし、[LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) 上のプレースホルダーを持つすべての図形の位置、サイズ、書式をデフォルト設定に戻す方法を示します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // レイアウト上にプレースホルダーがあるスライド上の各図形をリセットします。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**図形の書式設定は最終的なプレゼンテーション ファイルサイズに影響しますか？**

影響は最小限です。埋め込まれた画像やメディアがファイルサイズの大部分を占め、色や効果、グラデーションなどの図形パラメータはメタデータとして保存され、実質的なサイズ増加はほとんどありません。

**同一の書式設定を共有するスライド上の図形を検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗り、線、効果設定）を比較します。すべての対応する値が一致すれば、そのスタイルは同一とみなし、論理的にグループ化します。これにより、後のスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

可能です。目的のスタイルを持つサンプル図形をテンプレート スライド デッキまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成する際にテンプレートを開き、必要なスタイルの図形をクローンして、必要な場所で書式を再適用します。