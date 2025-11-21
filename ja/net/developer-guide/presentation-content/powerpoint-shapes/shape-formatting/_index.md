---
title: PowerPoint の図形を .NET で書式設定
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/net/shape-formatting/
keywords:
- 図形の書式設定
- 線の書式設定
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して C# で PowerPoint の図形をフォーマットする方法を学びます—PPT および PPTX ファイルの塗りつぶし、線、エフェクト スタイルを正確かつ完全に制御できます。"
---

## **概要**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、輪郭を変更したりエフェクトを適用することで書式設定できます。また、図形の内部をどのように塗りつぶすかを指定することでも書式設定できます。

![PowerPoint での図形の書式設定](format-shape-powerpoint.png)

Aspose.Slides for .NET は、PowerPoint で利用できるのと同じオプションを使用して図形をフォーマットするためのインターフェイスとプロパティを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) を設定します。
1. 図形の線色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の C# コードは、矩形の `AutoShape` の線を書式設定する方法を示しています。
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 矩形シェイプの塗りつぶしカラーを設定します。
    shape.FillFormat.FillType = FillType.NoFill;

    // 矩形の線に書式設定を適用します。
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // 矩形の線の色を設定します。
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // PPTX ファイルをディスクに保存します。
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```


結果:

![プレゼンテーション内の書式設定された線](formatted-lines.png)

## **結合スタイルの書式設定**

結合タイプのオプションは次の 3 つです。

* Round
* Miter
* Bevel

既定では、PowerPoint は角度がある 2 本の線（図形のコーナーなど）を結合するときに **Round** 設定を使用します。ただし、鋭角の図形を描く場合は **Miter** オプションを選択した方が適しています。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

以下の C# コードは、上図のように Miter、Bevel、Round の結合タイプ設定を使用して 3 つの矩形を作成した例です。
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // Rectangle タイプのオートシェイプを 3 つ追加します。
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // 各矩形シェイプの塗りつぶしカラーを設定します。
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // 線幅を設定します。
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // 各矩形の線の色を設定します。
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // 結合スタイルを設定します。
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // 各矩形にテキストを追加します。
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // PPTX ファイルをディスクに保存します。
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```


## **グラデーション塗りつぶし**

PowerPoint のグラデーション塗りつぶしは、図形に連続した色のブレンドを適用できる書式設定オプションです。たとえば、2 色以上を徐々にフェードさせながら適用できます。

Aspose.Slides で図形にグラデーション塗りつぶしを適用する手順は次の通りです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を `Gradient` に設定します。
1. [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/) インターフェイスが提供するグラデーション ストップ コレクションの `Add` メソッドを使用して、希望する 2 色と位置を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の C# コードは、楕円にグラデーション塗りつぶし効果を適用する方法を示しています。
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // Ellipse タイプのオートシェイプを追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 楕円にグラデーション書式設定を適用します。
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // グラデーションの方向を設定します。
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // 2 つのグラデーションストップを追加します。
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // PPTX ファイルをディスクに保存します。
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```


結果:

![グラデーション塗りつぶしの楕円](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、2 色のデザイン（ドット、ストライプ、クロスハッチ、チェックなど）を図形に適用できる書式設定オプションです。パターンの前景色と背景色はカスタムで指定できます。

Aspose.Slides は、プレゼンテーションの視覚効果を高めるために、45 種類以上の事前定義パターン スタイルを提供します。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

Aspose.Slides で図形にパターン塗りつぶしを適用する手順は次の通りです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義オプションからパターンスタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の C# コードは、矩形にパターン塗りつぶしを適用する方法を示しています。
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 塗りつぶしタイプを Pattern に設定します。
    shape.FillFormat.FillType = FillType.Pattern;

    // パターンスタイルを設定します。
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // パターンの背景色と前景色を設定します。
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // PPTX ファイルをディスクに保存します。
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```


結果:

![パターン塗りつぶしの矩形](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、画像を図形の内部に挿入し、実質的に画像を図形の背景として使用できる書式設定オプションです。

Aspose.Slides を使用して図形に画像塗りつぶしを適用する手順は次の通りです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を `Picture` に設定します。
1. 画像の貼り付けモードを `Tile`（または他の希望モード）に設定します。
1. 使用する画像から [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) オブジェクトを作成します。
1. この画像を図形の `PictureFillFormat` の `Picture.Image` プロパティに割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

次の画像は「lotus.png」というファイルです。

![ロータスの画像](lotus.png)

以下の C# コードは、画像で図形を塗りつぶす方法を示しています。
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // 塗りつぶしタイプを Picture に設定します。
    shape.FillFormat.FillType = FillType.Picture;

    // ピクチャー塗りつぶしモードを設定します。
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // 画像を読み込み、プレゼンテーションのリソースに追加します。
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // ピクチャーを設定します。
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // PPTX ファイルをディスクに保存します。
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```


結果:

![画像塗りつぶしの図形](picture-fill.png)

### **テクスチャとしてタイル配置画像**

タイル配置画像をテクスチャとして設定し、タイルの動作をカスタマイズしたい場合は、[IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) クラスの次のプロパティを使用できます。

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): `Tile` または `Stretch` のいずれかで画像塗りつぶしモードを設定します。
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): 図形内のタイル配置の配置を指定します。
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): タイルを水平、垂直、または両方に反転するかを制御します。
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): 図形の基点からタイルの水平オフセット（ポイント）を設定します。
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): 図形の基点からタイルの垂直オフセット（ポイント）を設定します。
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): タイルの水平スケールをパーセンテージで定義します。
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): タイルの垂直スケールをパーセンテージで定義します。

以下のコードサンプルは、タイル画像塗りつぶし付きの矩形を追加し、タイルオプションを構成する方法を示しています。
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide firstSlide = presentation.Slides[0];

    // 矩形のオートシェイプを追加します。
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 図形の塗りつぶしタイプを Picture に設定します。
    shape.FillFormat.FillType = FillType.Picture;

    // 画像を読み込み、プレゼンテーションのリソースに追加します。
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // 画像を図形に割り当てます。
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // ピクチャー塗りつぶしモードとタイルプロパティを設定します。
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // PPTX ファイルをディスクに保存します。
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```


結果:

![タイルオプション](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。このシンプルな背景色は、グラデーション、テクスチャ、パターンなどを使用せずに適用されます。

Aspose.Slides で図形に単色塗りつぶしを適用する手順は次の通りです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の C# コードは、PowerPoint スライドの矩形に単色塗りつぶしを適用する方法を示しています。
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 塗りつぶしタイプを Solid に設定します。
    shape.FillFormat.FillType = FillType.Solid;

    // 塗りつぶしカラーを設定します。
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // PPTX ファイルをディスクに保存します。
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```


結果:

![単色塗りつぶしの図形](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、テクスチャのいずれかの塗りつぶしを適用する際に、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度が高いほど図形が透けて見え、背景や下のオブジェクトが部分的に表示されます。

Aspose.Slides では、塗りつぶしに使用する色のアルファ値を調整することで透明度を設定できます。手順は次の通りです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を `Solid` に設定します。
1. `Color.FromArgb(alpha, baseColor)` を使用して透明度付きの色を定義します（`alpha` が透明度を制御）。
1. プレゼンテーションを保存します。

以下の C# コードは、矩形に透明な塗りつぶし色を適用する方法を示しています。
```c#
const int alpha = 128;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // ソリッド矩形のオートシェイプを追加します。
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ソリッド形状の上に透明な矩形オートシェイプを追加します。
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // PPTX ファイルをディスクに保存します。
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```


結果:

![透明な図形](shape-transparency.png)

## **図形の回転**

Aspose.Slides は、PowerPoint プレゼンテーション内の図形を回転させる機能を提供します。特定の配置やデザイン要件に合わせてビジュアル要素を回転させる際に便利です。

スライド上の図形を回転させる手順は次の通りです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の `Rotation` プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

以下の C# コードは、図形を 5 度回転させる例です。
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 図形を 5 度回転させます。
    shape.Rotation = 5;

    // PPTX ファイルをディスクに保存します。
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```


結果:

![図形の回転](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) プロパティを設定することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次の通りです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスをインスタンス化します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) を構成してベベル設定を定義します。
1. プレゼンテーションを保存します。

以下の C# コードは、図形に 3D ベベル効果を適用する例です。
```c#
// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // スライドに図形を追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // 図形の ThreeDFormat プロパティを設定します。
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // プレゼンテーションを PPTX ファイルとして保存します。
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```


結果:

![3D ベベル効果](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) プロパティを設定することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次の通りです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) と [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) を設定して 3D 回転を定義します。
1. プレゼンテーションを保存します。

以下の C# コードは、図形に 3D 回転効果を適用する例です。
```c#
// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // プレゼンテーションを PPTX ファイルとして保存します。
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```


結果:

![3D 回転効果](3D-rotation-effect.png)

## **書式設定のリセット**

以下の C# コードは、スライドの書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) 上のプレースホルダーを含むすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示しています。
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // レイアウト上のプレースホルダーを持つスライド上のすべてのシェイプをリセットします。
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**形状の書式設定は最終的なプレゼンテーション ファイルのサイズに影響しますか？**

ほぼ影響はありません。埋め込み画像やメディアがファイル容量の大部分を占め、形状のパラメータ（色、エフェクト、グラデーションなど）はメタデータとして保存され、実質的にサイズは増えません。

**同様の書式設定を持つスライド上の形状を検出してグループ化するにはどうすればよいですか？**

各形状の主要な書式設定プロパティ（塗りつぶし、線、エフェクト）を比較し、すべての対応する値が一致すれば同一スタイルとして扱い、論理的にグループ化できます。これにより後のスタイル管理が容易になります。

**カスタム形状スタイルのセットを別ファイルに保存して、他のプレゼンテーションで再利用できますか？**

はい。希望するスタイルを備えたサンプル形状をテンプレート スライド デッキまたは .POTX テンプレート ファイルに保存しておく。