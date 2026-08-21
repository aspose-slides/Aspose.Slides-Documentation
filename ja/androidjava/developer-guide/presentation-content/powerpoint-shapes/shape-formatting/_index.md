---
title: Android で PowerPoint 図形を書式設定する
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/androidjava/shape-formatting/
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
- 図形の透過性
- 白黒図形レンダリング
- グレースケール図形レンダリング
- 図形の回転
- 3Dベベル効果
- 3D回転効果
- 書式設定のリセット
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Android で PowerPoint の図形を書式設定する方法を学びます—PPT、PPTX、ODP ファイルの塗りつぶし、線、エフェクトスタイルを正確かつ完全に制御できます。"
---
## **概要**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、輪郭を変更したりエフェクトを適用したりして書式設定できます。さらに、内部の塗りつぶし方法を制御する設定を指定して図形をフォーマットすることもできます。

![PowerPoint での図形書式設定](format-shape-powerpoint.png)

Aspose.Slides for Android via Java は、PowerPoint で利用できるのと同じオプションを使用して図形を書式設定できるインターフェイスとメソッドを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。以下の手順で手順を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/linedashstyle/) を設定します。
1. 図形の線色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下のコードは、長方形 `AutoShape` の線を書式設定する方法を示しています：

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

    // 矩形シェイプの塗りつぶしを削除し、線だけが表示されるようにします。
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

結果：

![プレゼンテーション内の書式設定された線](formatted-lines.png)

## **図形の線にスケッチ効果を適用**

スケッチ効果により、図形の線が手描きのように見えます。[IShape.getLineFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) で線設定にアクセスし、[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilineformat/) でスケッチ設定にアクセスし、[ISketchFormat.setSketchType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isketchformat/) で [LineSketchType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/linesketchtype/) 列挙体から値を選択します。

以下の Java コードは、[LineSketchType.Curved](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/linesketchtype/) 効果を適用し、明示的に割り当てられた値を取得し、[LineSketchType.None](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/linesketchtype/) で効果を削除する方法を示します：

```java
import com.aspose.slides.*;

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

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isketchformat/) が返す値は、図形に直接割り当てられた設定を表します。テーマ、マスタースライド、またはレイアウトスライドから線の書式が継承される場合は、[ILineFormat.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilineformat/) を使用し、[ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilineformateffectivedata/) にアクセスし、[ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isketchformateffectivedata/) を読み取ります。実効値は継承が解決された後に実際に適用される書式を反映します：

```java
import com.aspose.slides.*;

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

次の 3 つの結合タイプオプションがあります：

* 丸め
* ミタース
* ベベル

デフォルトでは、PowerPoint は角度で 2 本の線（たとえば図形のコーナー）を結合するときに **丸め** 設定を使用します。ただし、鋭い角度の図形を描く場合は **ミタース** オプションを好むことがあります。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

以下の Java コードは、上図のようにミタース、ベベル、丸めの結合タイプ設定を使用して 3 つの長方形が作成された方法を示しています：

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
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

PowerPoint でのグラデーション塗りつぶしは、図形に連続した色のブレンドを適用できる書式設定オプションです。たとえば、2 つ以上の色を徐々にフェードさせて適用できます。

Aspose.Slides を使用して図形にグラデーション塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/filltype/) を `Gradient` に設定します。
1. [IGradientFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/igradientformat/) インターフェイスが公開するグラデーションストップコレクションの `add` メソッドを使用して、位置を指定した 2 つの好みの色を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Java コードは、楕円にグラデーション塗りつぶし効果を適用する方法を示しています：

```java
import com.aspose.slides.*;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
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

結果：

![楕円のグラデーション塗りつぶし](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、点、ストライプ、クロスハッチ、チェックなどの 2 色デザインを図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムで選択できます。

Aspose.Slides は、プレゼンテーションの視覚的魅力を高めるために、45 以上の事前定義パターンスタイルを図形に適用できます。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

以下は、Aspose.Slides を使用して図形にパターン塗りつぶしを適用する手順です。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義オプションからパターンスタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/patternformat/#getBackColor--) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/patternformat/#getForeColor--) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Java コードは、長方形にパターン塗りつぶしを適用する方法を示しています：

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
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

結果：

![パターン塗りつぶしの長方形](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、画像を図形の内部に挿入し、実質的に画像を図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して図形に画像塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または他の好みのモード）に設定します。
1. 使用したい画像から [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) オブジェクトを作成します。
1. 画像を `ISlidesPicture.setImage` メソッドに渡します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の画像は「lotus.png」ファイルの例です：

![ロータスの画像](lotus.png)

以下の Java コードは、画像で図形を塗りつぶす方法を示しています：

```java
import com.aspose.slides.*;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
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

結果：

![画像塗りつぶしの図形](picture-fill.png)

### **テクスチャとしてタイル画像を使用**

タイル画像をテクスチャとして設定し、タイル化の動作をカスタマイズする場合は、[IPictureFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/picturefillformat/) クラスの次のメソッドを使用できます。

- [setPictureFillMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): 画像塗りつぶしモードを `Tile` または `Stretch` に設定します。
- [setTileAlignment](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): 図形内のタイルの配置を指定します。
- [setTileFlip](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): タイルを水平、垂直、または両方に反転するかを制御します。
- [setTileOffsetX](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): 図形の原点からタイルの水平オフセット（ポイント）を設定します。
- [setTileOffsetY](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): 図形の原点からタイルの垂直オフセット（ポイント）を設定します。
- [setTileScaleX](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): タイルの水平スケールをパーセンテージで定義します。
- [setTileScaleY](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): タイルの垂直スケールをパーセンテージで定義します。

以下のコードサンプルは、タイル画像塗りつぶし付きの長方形を追加し、タイルオプションを構成する方法を示しています：

```java
import com.aspose.slides.*;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 長方形のオートシェイプを追加します。
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

    // 画像塗りつぶしモードとタイルプロパティを構成します。
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

結果：

![タイルオプション](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。この単純な背景色は、グラデーション、テクスチャ、パターンなしで適用されます。

Aspose.Slides を使用して図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Java コードは、PowerPoint スライドの長方形に単色塗りつぶしを適用する方法を示しています：

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
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

結果：

![単色塗りつぶしの図形](solid-color-fill.png)

## **透過性の設定**

PowerPoint では、図形に単色、グラデーション、画像、テクスチャ塗りつぶしを適用する際に、透過性レベルを設定して塗りつぶしの不透明度を制御できます。透過性の値が高いほど、図形が透けて見え、背景や下にあるオブジェクトが部分的に表示されます。

Aspose.Slides は、塗りつぶしに使用する色のアルファ値を調整することで透過性レベルを設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/filltype/) を `Solid` に設定します。
1. `Color` を使用して透過性を含む色を定義します（`alpha` コンポーネントが透過性を制御します）。
1. プレゼンテーションを保存します。

以下の Java コードは、長方形に透過塗りつぶし色を適用する方法を示しています：

```java
import com.aspose.slides.*;
import java.awt.Color;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation();
try {
    // 最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // ソリッドな長方形オートシェイプを追加します。
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ソリッドシェイプの上に透明な長方形オートシェイプを追加します。
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // PPTX ファイルをディスクに保存します。
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![透過した図形](shape-transparency.png)

## **図形の回転**

Aspose.Slides は、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件に合わせて視覚要素の位置調整に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
1. 図形の回転プロパティを目的の角度に設定します。
1. プレゼンテーションを保存します。

以下の Java コードは、図形を 5 度回転させる方法を示しています：

```java
import com.aspose.slides.*;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
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

結果：

![図形の回転](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/threedformat/) プロパティを構成することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/threedformat/) を構成してベベル設定を定義します。
1. プレゼンテーションを保存します。

以下の Java コードは、図形に 3D ベベル効果を適用する方法を示しています：

```java
import com.aspose.slides.*;
import java.awt.Color;

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

結果：

![3D ベベル効果](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/threedformat/) プロパティを構成することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
1. [setCameraType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icamera/#setCameraType-int-) と [setLightType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) を使用して 3D 回転を定義します。
1. プレゼンテーションを保存します。

以下の Java コードは、図形に 3D 回転効果を適用する方法を示しています：

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

結果：

![3D 回転効果](3D-rotation-effect.png)

## **図形の白黒表示制御**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) メソッドは、プレゼンテーションが白黒モードで表示または処理される際に個々の図形がどのようにレンダリングされるかを指定します。これは白黒表示を有効にするものではなく、通常のカラー表示モードでの図形の塗り、線、その他の書式設定を変更しません。

[BlackWhiteMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/blackwhitemode/) クラスの値を使用して目的の動作を選択します。例として、`Automatic` はレンダリング アプリケーションに変換を任せ、`Gray` と `LightGray` はグレー表示、`BlackWhite` は黒白のみ、`Black` と `White` は単一色、`Color` は通常のカラーを保持、`Hidden` は白黒モードで図形を省略します。`NotDefined` は図形レベルのモードが割り当てられていないことを意味します。

以下の Java コードは、色付き図形を作成し、白黒表示モードでグレーに表示させる方法を示しています：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // カラーモードではオレンジの塗りを保持し、白黒モードでは図形をグレーで表示します。
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

通常のカラー モードでは、長方形はオレンジの塗りつぶしを保持します。白黒表示のワークフローでは、モードが `Gray` に設定されているためグレー表示になります。これにより、フルカラーのスライドを保持しつつ、印刷やプレビューなど、プレゼンテーションの白黒表示設定を尊重するワークフローで別の外観を定義できます。

## **書式設定のリセット**

以下の Java コードは、[LayoutSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/layoutslide/) 上のプレースホルダー付きすべての図形の位置、サイズ、書式設定をデフォルトにリセットする方法を示しています：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // レイアウト上にプレースホルダーを持つスライド上の各シェイプをリセットします。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**図形の書式設定は最終的なプレゼンテーション ファイル サイズに影響しますか？**

影響は最小限です。埋め込み画像やメディアがファイル容量の大部分を占め、色やエフェクト、グラデーションなどの図形パラメータはメタデータとして保存され、実質的なサイズ増加はほとんどありません。

**同一の書式設定を共有するスライド上の図形を検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗り、線、エフェクト設定）を比較します。すべての対応する値が一致すれば、スタイルが同一と見なし、論理的にグループ化します。これにより、後のスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

できます。希望するスタイルを持つサンプル図形をテンプレート スライド デッキまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成する際にテンプレートを開き、必要なスタイルの図形をクローンして、必要な場所で書式設定を再適用します。