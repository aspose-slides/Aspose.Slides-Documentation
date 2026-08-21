---
title: PowerPoint の図形を .NET でフォーマットする
linktitle: 図形の書式設定
type: docs
weight: 20
url: /ja/net/shape-formatting/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して C# で PowerPoint の図形をフォーマットする方法を学びます。PPT および PPTX ファイルの塗りつぶし、線、エフェクトスタイルを正確かつ完全にコントロールできます。"
---
## **概要**

PowerPoint では、スライドに図形を追加できます。図形は線で構成されているため、アウトラインの変更やエフェクトの適用で線の書式設定が可能です。さらに、図形の内部をどのように塗りつぶすかを制御する設定を指定して、図形の書式設定を行うこともできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET は、PowerPoint で利用可能なオプションと同様の方法で図形をフォーマットできるインターフェイスとプロパティを提供します。

## **線の書式設定**

Aspose.Slides を使用すると、図形にカスタムの線スタイルを指定できます。以下の手順で実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. 図形の [line style](https://reference.aspose.com/slides/ja/net/aspose.slides/linestyle/) を設定します。
5. 線の幅を設定します。
6. 線の [dash style](https://reference.aspose.com/slides/ja/net/aspose.slides/linedashstyle/) を設定します。
7. 図形の線の色を設定します。
8. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の C# コードは、四角形の `AutoShape` の線を書式設定する例です。

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // Rectangle タイプのオートシェイプを追加します。
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

![プレゼンテーション内の書式設定された線](formatted-lines.png)

## **図形線にスケッチ効果を適用する**

スケッチ効果は、図形の線を手描き風に見せます。`[IShape.LineFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/lineformat/)` で線設定にアクセスし、`[ILineFormat.SketchFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ilineformat/sketchformat/)` でスケッチ設定にアクセスし、`[ISketchFormat.SketchType](https://reference.aspose.com/slides/ja/net/aspose.slides/isketchformat/sketchtype/)` で `[LineSketchType](https://reference.aspose.com/slides/ja/net/aspose.slides/linesketchtype/)` 列挙体から値を選択します。

以下の C# コードは、`[LineSketchType.Curved](https://reference.aspose.com/slides/ja/net/aspose.slides/linesketchtype/)` 効果を適用し、明示的に設定された値を取得し、`[LineSketchType.None](https://reference.aspose.com/slides/ja/net/aspose.slides/linesketchtype/)` で効果を削除する例です。

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

`ISketchFormat.SketchType` が返す値は、図形に直接割り当てられた設定を表します。テーマ、マスタースライド、またはレイアウトスライドから線の書式が継承される可能性がある場合は、`[ILineFormat.GetEffective](https://reference.aspose.com/slides/ja/net/aspose.slides/ilineformat/geteffective/)` を使用し、`[ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ilineformateffectivedata/sketchformat/)` にアクセスして、`[ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/ja/net/aspose.slides/isketchformateffectivedata/sketchtype/)` を読み取ります。効果的な値は、継承が解決された後に実際に適用される書式を反映します。

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

PowerPoint では、2 本の線を角度で結合する際（図形のコーナーなど）既定で **Round** が使用されます。ただし、鋭角の図形を描く場合は **Miter** を選択したくなることがあります。

![プレゼンテーション内の結合スタイル](join-style-powerpoint.png)

以下の C# コードは、上図のように Miter、Bevel、Round の結合タイプ設定で作成された 3 つの四角形を示します。

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // Rectangle タイプのオートシェイプを 3 つ追加します。
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

PowerPoint のグラデーション塗りつぶしは、図形に連続的な色のブレンドを適用できる書式オプションです。たとえば、2 色以上を徐々にフェードさせる形で適用できます。

Aspose.Slides で図形にグラデーション塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. 図形の [FillType](https://reference.aspose.com/slides/ja/net/aspose.slides/filltype/) を `Gradient` に設定します。
5. [IGradientFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/igradientformat/) インターフェイスが公開するグラデーションストップコレクションの `Add` メソッドを使用し、位置を指定した 2 つの好みの色を追加します。
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の C# コードは、楕円にグラデーション塗りつぶし効果を適用する例です。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // Ellipse タイプのオートシェイプを追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 楕円にグラデーション書式を適用します。
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

![グラデーション塗りつぶしが適用された楕円](gradient-fill.png)

## **パターン塗りつぶし**

PowerPoint のパターン塗りつぶしは、点、ストライプ、クロスハッチ、チェッカーなどの 2 色デザインを図形に適用できる書式オプションです。パターンの前景色と背景色は任意に設定できます。

Aspose.Slides では、45 種類以上の事前定義パターンスタイルを図形に適用して、プレゼンテーションの視覚効果を高められます。事前定義パターンを選択した後でも、使用する正確な色を指定できます。

Aspose.Slides で図形にパターン塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. 図形の [FillType](https://reference.aspose.com/slides/ja/net/aspose.slides/filltype/) を `Pattern` に設定します。
5. 事前定義オプションからパターンスタイルを選択します。
6. パターンの [Background Color](https://reference.aspose.com/slides/ja/net/aspose.slides/ipatternformat/backcolor/) を設定します。
7. パターンの [Foreground Color](https://reference.aspose.com/slides/ja/net/aspose.slides/ipatternformat/forecolor/) を設定します。
8. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の C# コードは、四角形にパターン塗りつぶしを適用する例です。

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![パターン塗りつぶしが適用された四角形](pattern-fill.png)

## **画像塗りつぶし**

PowerPoint の画像塗りつぶしは、画像を図形の内部に挿入し、実質的に画像を図形の背景として使用できる書式オプションです。

Aspose.Slides で図形に画像塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. 図形の [FillType](https://reference.aspose.com/slides/ja/net/aspose.slides/filltype/) を `Picture` に設定します。
5. 画像塗りつぶしモードを `Tile`（または他の好みのモード）に設定します。
6. 使用する画像から [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) オブジェクトを作成します。
7. この画像を図形の `PictureFillFormat` の `Picture.Image` プロパティに割り当てます。
8. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下は「lotus.png」というファイルの画像例です。

![ロータスの画像](lotus.png)

以下の C# コードは、図形に画像塗りつぶしを適用する例です。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // 塗りつぶしタイプを Picture に設定します。
    shape.FillFormat.FillType = FillType.Picture;

    // 画像塗りつぶしモードを設定します。
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

![画像塗りつぶしが適用された図形](picture-fill.png)

### **テクスチャとしてタイル画像を設定する**

タイル画像をテクスチャとして設定し、タイルの動作をカスタマイズしたい場合は、[IPictureFillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/) インターフェイスと [PictureFillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/picturefillformat/) クラスの次のプロパティを使用します。

- [PictureFillMode](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/picturefillmode/): 画像塗りつぶしモード（`Tile` または `Stretch`）を設定します。
- [TileAlignment](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/tilealignment/): 図形内のタイル配置を指定します。
- [TileFlip](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/tileflip/): タイルを水平方向、垂直方向、または両方で反転させるかを制御します。
- [TileOffsetX](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/tileoffsetx/): 図形の原点からタイルの水平方向オフセット（ポイント）を設定します。
- [TileOffsetY](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/tileoffsety/): 図形の原点からタイルの垂直方向オフセット（ポイント）を設定します。
- [TileScaleX](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/tilescalex/): タイルの水平方向スケール（パーセンテージ）を定義します。
- [TileScaleY](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/tilescaley/): タイルの垂直方向スケール（パーセンテージ）を定義します。

以下のコードサンプルは、タイル画像塗りつぶし付きの四角形を追加し、タイルオプションを構成する方法を示します。

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

![タイルオプションのプレビュー](tile-options.png)

## **単色塗りつぶし**

PowerPoint の単色塗りつぶしは、図形を単一の均一な色で塗りつぶす書式オプションです。グラデーション、テクスチャ、パターンなどを使用せず、純粋な背景色が適用されます。

Aspose.Slides で図形に単色塗りつぶしを適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. 図形の [FillType](https://reference.aspose.com/slides/ja/net/aspose.slides/filltype/) を `Solid` に設定します。
5. 好みの塗りつぶし色を図形に割り当てます。
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の C# コードは、スライド上の四角形に単色塗りつぶしを適用する例です。

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // Rectangle タイプのオートシェイプを追加します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 塗りつぶしタイプを Solid に設定します。
    shape.FillFormat.FillType = FillType.Solid;

    // 塗りつぶし色を設定します。
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // PPTX ファイルをディスクに保存します。
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

結果:

![単色塗りつぶしが適用された図形](solid-color-fill.png)

## **透明度の設定**

PowerPoint では、図形に単色、グラデーション、画像、またはテクスチャ塗りつぶしを適用する際に、透明度レベルを設定して塗りつぶしの不透明度を制御できます。透明度が高いほど図形が透けて見え、背景や下にあるオブジェクトが部分的に表示されます。

Aspose.Slides では、塗りつぶしに使用する色のアルファ値を調整することで透明度を設定できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. [FillType](https://reference.aspose.com/slides/ja/net/aspose.slides/filltype/) を `Solid` に設定します。
5. `Color.FromArgb(alpha, baseColor)` を使用して透明度付きの色を定義します（`alpha` が透明度を制御します）。
6. プレゼンテーションを保存します。

以下の C# コードは、四角形に透明な塗りつぶし色を適用する例です。

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

    // ソリッド形状の上に透明な矩形オートシェイプを追加します。
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // PPTX ファイルをディスクに保存します。
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

結果:

![透明度が設定された図形](shape-transparency.png)

## **図形の回転**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内の図形を回転させることができます。特定の配置やデザイン要件に合わせてビジュアル要素を位置決めする際に便利です。

スライド上の図形を回転させる手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. 図形の `Rotation` プロパティに目的の角度を設定します。
5. プレゼンテーションを保存します。

以下の C# コードは、図形を 5 度回転させる例です。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

![図形の回転結果](shape-rotation.png)

## **3D ベベル効果の追加**

Aspose.Slides では、図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/threedformat/) プロパティを構成することで、3D ベベル効果を適用できます。

図形に 3D ベベル効果を追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスをインスタンス化します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. 図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/threedformat/) を構成してベベル設定を定義します。
5. プレゼンテーションを保存します。

以下の C# コードは、図形に 3D ベベル効果を適用する例です。

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

![3D ベベル効果のプレビュー](3D-bevel-effect.png)

## **3D 回転効果の追加**

Aspose.Slides では、図形の [ThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/threedformat/) プロパティを構成することで、3D 回転効果を適用できます。

図形に 3D 回転を適用する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. 図形の [CameraType](https://reference.aspose.com/slides/ja/net/aspose.slides/icamera/cameratype/) と [LightType](https://reference.aspose.com/slides/ja/net/aspose.slides/ilightrig/lighttype/) を設定して 3D 回転を定義します。
5. プレゼンテーションを保存します。

以下の C# コードは、図形に 3D 回転効果を適用する例です。

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

![3D 回転効果のプレビュー](3D-rotation-effect.png)

## **図形の白黒表示の制御**

[IShape.BlackWhiteMode](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/blackwhitemode/) プロパティは、プレゼンテーションが白黒モードで表示または処理される際に、個々の図形がどのように描画されるかを指定します。このプロパティだけで白黒表示が有効になるわけではなく、通常カラー表示時の図形の塗り、線、その他の書式設定は変更されません。

[BlackWhiteMode](https://reference.aspose.com/slides/ja/net/aspose.slides/blackwhitemode/) 列挙体の値を使用して目的の動作を選択します。例として、`Automatic` はレンダリング アプリケーションに変換を任せ、`Gray` や `LightGray` はグレイ調に、`BlackWhite` は黒と白のみ、`Black` と `White` は単一色、`Color` は通常のカラーを保持し、`Hidden` は白黒モードで図形を除外します。`NotDefined` は図形レベルでモードが割り当てられていないことを意味します。

以下の C# コードは、カラー図形を作成し、白黒表示モードで灰色として表示させる例です。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// カラー モードではオレンジの塗りつぶしを保持し、白黒モードでは図形を灰色で描画します。
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

通常カラー モードでは四角形はオレンジ色の塗りつぶしが保持されますが、白黒表示ワークフローでは `Gray` に設定されているため灰色で表示されます。これにより、印刷やプレビューなど、プレゼンテーションの白黒表示設定を尊重するワークフロー向けに、フルカラー スライドを保持しつつ別の外観を定義できます。

## **書式設定のリセット**

以下の C# コードは、スライドの書式設定をリセットし、[LayoutSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutslide/) 上のプレースホルダーを含むすべての図形の位置、サイズ、書式設定をデフォルトに戻す方法を示します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // レイアウト上にプレースホルダーがあるスライド上の各図形をリセットします。
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**図形の書式設定は最終的なプレゼンテーション ファイルのサイズに影響しますか？**

ほとんど影響しません。埋め込まれた画像やメディアがファイル容量の大部分を占め、色やエフェクト、グラデーションなどの図形パラメータはメタデータとして保存されるため、実質的なサイズ増加はほぼありません。

**同じ書式設定を持つスライド上の図形を検出してグループ化するにはどうすればよいですか？**

各図形の主要な書式プロパティ（塗り、線、エフェクト設定）を比較します。すべての対応する値が一致すれば、スタイルが同一とみなし、論理的にグループ化します。これにより、後のスタイル管理が簡素化されます。

**カスタム図形スタイルのセットを別ファイルに保存し、他のプレゼンテーションで再利用できますか？**

できます。目的のスタイルを持つサンプル図形をテンプレート スライド デックまたは .POTX テンプレート ファイルに保存します。新規プレゼンテーション作成時にテンプレートを開き、必要なスタイル付き図形をクローンして、必要に応じて書式設定を再適用します。