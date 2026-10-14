---
title: PowerPoint の図形を .NET で書式設定する
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/net/shape-formatting/
keywords:
- 図形の書式設定
- 線の書式設定
- スケッチ効果
- 図形線のスケッチ効果
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
- 書式のリセット
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して C# で PowerPoint の図形を書式設定する方法を学びます。PPT および PPTX ファイルの塗りつぶし、線、エフェクトスタイルを正確かつ完全にコントロールできます。"
---
## **イントロダクション**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、輪郭線の書式設定やエフェクトの適用で変更できます。また、図形の内部を塗りつぶす設定で書式設定することもできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET は、PowerPoint と同じオプションで図形をフォーマットするためのインターフェイスとプロパティを提供します。

## **ラインの書式設定**

Aspose.Slides を使用すると、図形にカスタムラインスタイルを指定できます。手順は以下のとおりです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) を設定します。
1. 線の幅を設定します。
1. 線の [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) を設定します。
1. 図形の線色を設定します。
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

次の C# コードは、矩形の `AutoShape` の線をフォーマットする例です。

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // 矩形タイプのオートシェイプを追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 矩形シェイプの塗りつぶし色を設定します。
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

![The formatted lines in the presentation](formatted-lines.png)

## **図形線へのスケッチ効果の適用**

スケッチ効果は、図形の線を手描き風にします。`[IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/)` で線設定にアクセスし、`[ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/)` でスケッチ設定にアクセスし、`[ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/)` で `[LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/)` 列挙体の値を選択します。

次の C# コードは、`[LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/)` 効果を適用し、明示的に割り当てられた値を読み取り、`[LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/)` で効果を削除する方法を示しています。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

`ISketchFormat.SketchType` が返す値は、図形に直接割り当てられた設定を表します。テーマ、マスタースライド、レイアウトスライドから継承される場合は、`[ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/)` を使用し、`[ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/)` にアクセスし、`[ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/)` を読み取ります。実効値は継承が解決された後に実際に適用される書式を示します。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **結合スタイルの書式設定**

結合タイプのオプションは次の 3 つです。

* Round
* Miter
* Bevel

デフォルトでは、PowerPoint は角度のある 2 本の線を結合する際に **Round** 設定を使用します。ただし、鋭い角の図形を描く場合は **Miter** を選択した方が好ましいことがあります。

![The join style in the presentation](join-style-powerpoint.png)

次の C# コードは、上図のように Miter、Bevel、Round の結合タイプ設定で 3 つの矩形を作成した例です。

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // 矩形タイプのオートシェイプを 3 つ追加します。
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // 各矩形シェイプの塗りつぶし色を設定します。
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // 線の幅を設定します。
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

PowerPoint のグラデーション塗りつぶしは、図形に連続した色のブレンドを適用できる書式設定オプションです。たとえば、2 色以上を徐々に変化させながら適用できます。

Aspose.Slides で図形にグラデーション塗りつぶしを適用する手順:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を `Gradient` に設定します。
1. [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/) インターフェイスが提供するグラデーション ストップ コレクションの `Add` メソッドを使用し、位置を指定して 2 つの好みの色を追加します。
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

次の C# コードは、楕円にグラデーション塗りつぶし効果を適用する例です。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // 楕円タイプのオートシェイプを追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 楕円にグラデーション書式設定を適用します。
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // グラデーションの方向を設定します。
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // 2 つのグラデーション ストップを追加します。
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // PPTX ファイルをディスクに保存します。
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

結果:

![The ellipse with gradient fill](gradient-fill.png)

エクスポートした画像でグラデーションが PowerPoint と異なる場合は、[Choose a Gradient Rendering Style](/slides/ja/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) を参照してください。プレゼンテーションに保存されたグラデーション塗りつぶしは変更せずに、レンダリング スタイルだけを選択できます。

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、2 色のデザイン（ドット、ストライプ、クロスハッチ、チェッカーなど）を図形に適用できる書式設定オプションです。パターンの前景色と背景色をカスタムで選択できます。

Aspose.Slides は、45 種類以上の事前定義パターン スタイルを提供し、プレゼンテーションの視覚的魅力を高めます。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

Aspose.Slides で図形にパターン塗りつぶしを適用する手順:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を `Pattern` に設定します。
1. 事前定義されたオプションからパターン スタイルを選択します。
1. パターンの [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) を設定します。
1. パターンの [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) を設定します。
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

次の C# コードは、矩形にパターン塗りつぶしを適用する例です。

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // 矩形タイプのオートシェイプを追加します。
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

![The rectangle with pattern fill](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、図形の内部に画像を挿入し、画像を図形の背景として使用できる書式設定オプションです。

Aspose.Slides で画像塗りつぶしを図形に適用する手順:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を `Picture` に設定します。
1. 画像塗りつぶしモードを `Tile`（または他の好みのモード）に設定します。
1. 使用する画像から [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) オブジェクトを作成します。
1. この画像を図形の `Picture.Image` プロパティ（`PictureFillFormat`）に割り当てます。
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

次の画像は「lotus.png」というファイルの例です。

![The lotus picture](lotus.png)

次の C# コードは、画像で図形を塗りつぶす例です。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // 矩形タイプのオートシェイプを追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // 塗りつぶしタイプを Picture に設定します。
    shape.FillFormat.FillType = FillType.Picture;

    // 画像の塗りつぶしモードを設定します。
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // 画像を読み込み、プレゼンテーションのリソースに追加します。
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 画像を設定します。
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // PPTX ファイルをディスクに保存します。
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

結果:

![The shape with picture fill](picture-fill.png)

### **テクスチャとしてタイル画像を使用**

タイル画像をテクスチャとして設定し、タイルの動作をカスタマイズしたい場合は、[IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) クラスの次のプロパティを使用します。

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): `Tile` または `Stretch` を設定します。
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): タイルの配置を指定します。
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): タイルを水平、垂直、または両方に反転するかを制御します。
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): 図形の原点からタイルの水平方向オフセット（ポイント）を設定します。
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): 図形の原点からタイルの垂直方向オフセット（ポイント）を設定します。
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): タイルの水平方向スケールをパーセンテージで定義します。
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): タイルの垂直方向スケールをパーセンテージで定義します。

次のコード例は、矩形図形にタイル画像塗りつぶしを追加し、タイルオプションを構成する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

    // 画像塗りつぶしモードとタイル設定を構成します。
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

![The tile options](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式設定オプションです。グラデーション、テクスチャ、パターンなどは使用されません。

Aspose.Slides で単色塗りつぶしを図形に適用する手順:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を `Solid` に設定します。
1. 好みの塗りつぶし色を図形に割り当てます。
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

次の C# コードは、スライド上の矩形に単色塗りつぶしを適用する例です。

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // 矩形タイプのオートシェイプを追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 塗りつぶしタイプを Solid に設定します。
    shape.FillFormat.FillType = FillType.Solid;

    // 塗りつぶしの色を設定します。
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // PPTX ファイルをディスクに保存します。
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

結果:

![The shape with solid color fill](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、固体、グラデーション、画像、テクスチャのいずれかで塗りつぶした形状に対し、透明度を設定して不透明度を調整できます。透明度の値が高いほど、形状が透けて背景や下位オブジェクトが見えるようになります。

Aspose.Slides は、塗りつぶしに使用する色のアルファ値を調整することで透明度を設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を `Solid` に設定します。
1. `Color.FromArgb(alpha, baseColor)` を使用して、透明度を持つ色を定義します（`alpha` が透明度を制御）。
1. プレゼンテーションを保存します。

次の C# コードは、矩形に透明塗りつぶし色を適用する例です。

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // ソリッド矩形のオートシェイプを追加します。
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ソリッドシェイプの上に透明な矩形オートシェイプを追加します。
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // PPTX ファイルをディスクに保存します。
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

結果:

![The transparent shape](shape-transparency.png)

## **図形の回転**

Aspose.Slides は、PowerPoint プレゼンテーション内の図形を回転させる機能を提供します。特定の配置やデザイン要件に合わせてビジュアル要素を回転させる際に便利です。

スライド上の図形を回転させる手順:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の `Rotation` プロパティに目的の角度を設定します。
1. プレゼンテーションを保存します。

次の C# コードは、図形を 5 度回転させる例です。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // 矩形タイプのオートシェイプを追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 図形を 5 度回転させます。
    shape.Rotation = 5;

    // PPTX ファイルをディスクに保存します。
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

結果:

![The shape rotation](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) プロパティを構成することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) を設定し、ベベル設定を定義します。
1. プレゼンテーションを保存します。

次の C# コードは、図形に 3D ベベル効果を適用する例です。

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![The 3D bevel effect](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides は、図形の [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) プロパティを構成することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. スライドに [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 図形の [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) と [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) を設定して 3D 回転を定義します。
1. プレゼンテーションを保存します。

次の C# コードは、図形に 3D 回転効果を適用する例です。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // プレゼンテーションを PPTX ファイルとして保存します。
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

結果:

![The 3D rotation effect](3D-rotation-effect.png)

## **図形の白黒描画モードの制御**

[IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) プロパティは、プレゼンテーションが白黒モードで表示または処理される際に、個々の図形がどのように描画されるかを指定します。白黒表示自体を有効にするものではなく、通常のカラー表示時の図形の塗りや線などの書式設定も変更しません。

[BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) 列挙体の値を使用して動作を選択します。例として、`Automatic` はアプリケーションに変換を任せ、`Gray` や `LightGray` はグレイ調、`BlackWhite` は黒と白だけ、`Black` と `White` は単一色、`Color` は通常カラーを保持、`Hidden` は白黒モードで図形を非表示にします。`NotDefined` は図形レベルでモードが設定されていないことを意味します。

次の C# コードは、色付き図形を作成し、白黒表示モードで灰色として表示させる例です。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// カラーモードではオレンジの塗りつぶしを保持し、白黒モードでは図形をグレイで描画します。
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

通常のカラー表示では矩形はオレンジの塗りつぶしを保持しますが、白黒表示ワークフローでは `Gray` が設定されているため灰色で描画されます。これにより、フルカラーのスライドを保持しつつ、印刷やプレビューなど白黒表示が必要なシナリオで別の外観を定義できます。

## **書式のリセット**

次の C# コードは、スライドの書式をリセットし、[LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) 上のプレースホルダーを含むすべての図形の位置、サイズ、書式をデフォルト設定に戻す方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // レイアウト上のプレースホルダーを持つスライド上の各シェイプをリセットします。
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**形状の書式設定は最終的なプレゼンテーション ファイル サイズに影響しますか？**

影響は最小限です。埋め込まれた画像やメディアがファイル容量の大部分を占め、色やエフェクト、グラデーションなどの形状パラメータはメタデータとして保存され、実質的なサイズ増加はほとんどありません。

**同じ書式設定を持つスライド上の図形を検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗り、線、エフェクト設定）を比較します。すべての対応する値が一致した場合、スタイルが同一とみなし、論理的にグループ化します。これにより、後でのスタイル管理が簡素化されます。

**カスタム形状スタイルのセットを別ファイルに保存して、他のプレゼンテーションで再利用できますか？**

はい。希望するスタイルを持つサンプル図形をテンプレート スライド デッキまたは .POTX テンプレート ファイルに保存します。新しいプレゼンテーションを作成する際にテンプレートを開き、必要なスタイル付き図形をクローンして、必要な箇所で書式を再適用します。