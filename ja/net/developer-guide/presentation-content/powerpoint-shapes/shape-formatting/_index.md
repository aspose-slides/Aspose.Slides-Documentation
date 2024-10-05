---
title: 形の書式設定
type: docs
weight: 20
url: /net/shape-formatting/
keywords:
- 形の書式
- 線の書式
- ジョインスタイルの書式
- グラデーション塗り
- パターン塗り
- 画像塗り
- 単色塗り
- 形を回転
- 3D ベベル効果
- 3D 回転効果
- PowerPoint プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C# または .NET では PowerPoint プレゼンテーションの形をフォーマットします"
---

PowerPoint では、スライドに形を追加できます。形は線から構成されているため、その構成する線を変更したり特定の効果を適用することで形をフォーマットできます。また、形がどのように（その内部のエリアが）塗りつぶされるかを決定する設定を指定することで形をフォーマットすることもできます。

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides for .NET** は、PowerPoint の既知のオプションに基づいて形をフォーマットできるインターフェイスとプロパティを提供します。

## **ラインのフォーマット**

Aspose.Slides を使用すると、形の好みのラインスタイルを指定できます。これらのステップは、その手順を概説しています。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) を追加します。
4. 形のラインの色を設定します。
5. 形のラインの幅を設定します。
6. 形ラインの [ラインスタイル](https://reference.aspose.com/slides/net/aspose.slides/linestyle) を設定します。
7. 形ラインの [ダッシュスタイル](http://aspose.com/api/net/slides/aspose.slides/linedashstyle) を設定します。 
8. 修正されたプレゼンテーションを書き出します（PPTX ファイルとして）。

この C# コードは、長方形の `AutoShape` をフォーマットする操作を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // 四角形のタイプの自動形を追加します
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 四角形形の塗りつぶし色を設定します
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.White;

    // 四角形のラインにいくつかの書式を適用します
    shp.LineFormat.Style = LineStyle.ThickThin;
    shp.LineFormat.Width = 7;
    shp.LineFormat.DashStyle = LineDashStyle.Dash;

    // 四角形のラインの色を設定します
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // PPTX ファイルをディスクに保存します
    pres.Save("RectShpLn_out.pptx", SaveFormat.Pptx);
}
```

## **ジョインスタイルのフォーマット**
これらは 3 つのジョインタイプオプションです：

* ラウンド
* ミター
* ベベル

デフォルトでは、PowerPoint は 2 つの線を角度で接続する際に（または形のコーナーで）、**ラウンド**設定を使用します。しかし、非常に鋭角の形を描く場合は、**ミター**を選択することをお勧めします。

![join-style-powerpoint](join-style-powerpoint.png)

この C# コードは、ミター、ベベル、ラウンドジョインタイプ設定で作成された 3 つの長方形（上の画像）の操作を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します
using (Presentation pres = new Presentation())
{

	// 最初のスライドを取得します
	ISlide sld = pres.Slides[0];

	// 3 つの長方形の自動形を追加します
	IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
	IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
	IShape shp3 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

	// 四角形形の塗りつぶし色を設定します
	shp1.FillFormat.FillType = FillType.Solid;
	shp1.FillFormat.SolidFillColor.Color = Color.Black;
	shp2.FillFormat.FillType = FillType.Solid;
	shp2.FillFormat.SolidFillColor.Color = Color.Black;
	shp3.FillFormat.FillType = FillType.Solid;
	shp3.FillFormat.SolidFillColor.Color = Color.Black;

	// ラインの幅を設定します
	shp1.LineFormat.Width = 15;
	shp2.LineFormat.Width = 15;
	shp3.LineFormat.Width = 15;

	// 四角形のラインの色を設定します
	shp1.LineFormat.FillFormat.FillType = FillType.Solid;
	shp1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	shp2.LineFormat.FillFormat.FillType = FillType.Solid;
	shp2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	shp3.LineFormat.FillFormat.FillType = FillType.Solid;
	shp3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	// ジョインスタイルを設定します
	shp1.LineFormat.JoinStyle = LineJoinStyle.Miter;
	shp2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
	shp3.LineFormat.JoinStyle = LineJoinStyle.Round;

	// 各長方形にテキストを追加します
	((IAutoShape)shp1).TextFrame.Text = "ミタージョインスタイル";
	((IAutoShape)shp2).TextFrame.Text = "ベベルジョインスタイル";
	((IAutoShape)shp3).TextFrame.Text = "ラウンドジョインスタイル";

	// PPTX ファイルをディスクに保存します
	pres.Save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
}
```

## **グラデーション塗り**
PowerPoint では、グラデーション塗りは形に連続的な色のブレンドを適用できる書式オプションです。例えば、1 つの色が徐々に別の色に変わるように 2 色以上を設定に適用できます。

これが、Aspose.Slides を使用して形にグラデーション塗りを適用する方法です：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) を追加します。
4. 形の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) を `グラデーション` に設定します。
5. `GradientFormat` クラスに関連付けられた `GradientStops` コレクションによって公開された `Add` メソッドを使用して、定義された位置に 2 つの好みの色を追加します。
6. 修正されたプレゼンテーションを書き出します（PPTX ファイルとして）。

この C# コードは、楕円形にグラデーション塗り効果を使用した操作を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // 楕円形の自動形を追加します
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // 楕円にグラデーション書式を適用します
    shp.FillFormat.FillType = FillType.Gradient;
    shp.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // グラデーションの方向を設定します
    shp.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // 2 つのグラデーションストップを追加します
    shp.FillFormat.GradientFormat.GradientStops.Add((float)1.0, PresetColor.Purple);
    shp.FillFormat.GradientFormat.GradientStops.Add((float)0, PresetColor.Red);

    // PPTX ファイルをディスクに保存します
    pres.Save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
}
```

## **パターン塗り**
PowerPoint では、パターン塗りは、形に点、ストライプ、クロスハッチ、チェックの 2 色デザインを適用できる書式オプションです。さらに、パターンの前景と背景の好みの色を選択できます。

Aspose.Slides は、形の書式を設定しプレゼンテーションを豊かにするために使用できる 45 を超える事前定義されたスタイルを提供しています。事前に定義されたパターンを選択した後でも、パターンに含める色を指定することができます。

これが、Aspose.Slides を使用して形にパターン塗りを適用する方法です：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) を追加します。
4. 形の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) を `パターン` に設定します。
5. 形の好みのパターンスタイルを設定します。 
6. [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat) の [背景色](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/backcolor) を設定します。
7. [前景色](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/forecolor) を設定します。
8. 修正されたプレゼンテーションを書き出します（PPTX ファイルとして）。

この C# コードは、長方形の美化にパターン塗りが使用された操作を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // 長方形の自動形を追加します
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 塗りつぶしタイプをパターンに設定します
    shp.FillFormat.FillType = FillType.Pattern;

    // パターンスタイルを設定します
    shp.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // パターンの背景色と前景色を設定します
    shp.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shp.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // PPTX ファイルをディスクに保存します
    pres.Save("RectShpPatt_out.pptx", SaveFormat.Pptx);
}
```

## **画像塗り**
PowerPoint では、画像塗りは、形の内部に画像を配置できる書式オプションです。基本的には、画像を形の背景として使用できます。

これが、Aspose.Slides を使用して形を画像で塗りつぶす方法です：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) を追加します。
4. 形の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) を `画像` に設定します。
5. 画像塗りモードをタイルに設定します。
6. 形を塗りつぶすために使用する画像を使用して `IPPImage` オブジェクトを作成します。
7. `PictureFillFormat` オブジェクトの `Picture.Image` プロパティを最近作成された `IPPImage` に設定します。
8. 修正されたプレゼンテーションを書き出します（PPTX ファイルとして）。

この C# コードは、形を画像で塗りつぶす方法を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します
    ISlide slide = presentation.Slides[0];

    // 長方形の自動形を追加します
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 塗りつぶしタイプを画像に設定します
    shape.FillFormat.FillType = FillType.Picture;

    // 画像塗りモードを設定します
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // 画像を読み込み、プレゼンテーションリソースに追加します
    IImage image = Images.FromFile("Tulips.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 画像を設定します
    shape.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // PPTX ファイルをディスクに保存します
    presentation.Save("RectShpPic_out.pptx", SaveFormat.Pptx);
}
```

## **単色塗り**
PowerPoint では、単色塗りは、形を単一の色で塗りつぶすことを許可する書式オプションです。選択された色は通常、単色になります。色は形の背景に適用され、特別な効果や修正はありません。

これが、Aspose.Slides を使用して形に単色塗りを適用する方法です：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) を追加します。
4. 形の [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) を `単色` に設定します。
5. 形に対して好みの色を設定します。
6. 修正されたプレゼンテーションを書き出します（PPTX ファイルとして）。

この C# コードは、PowerPoint のボックスに単色塗りを適用する方法を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します
using (Presentation presentation = new Presentation())
{

// 最初のスライドを取得します
    ISlide slide = presentation.Slides[0];

// 長方形の自動形を追加します
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

// 塗りつぶしタイプを単色に設定します
    shape.FillFormat.FillType = FillType.Solid;

// 長方形の色を設定します
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

// PPTX ファイルをディスクに保存します
    presentation.Save("RectShpSolid_out.pptx", SaveFormat.Pptx);
}
```

## **透明度の設定**

PowerPoint では、形を単色、グラデーション、画像、またはテクスチャで塗りつぶすときに、塗りの不透明度を決定する透明度レベルを指定できます。これにより、例えば低い透明度レベルを設定すると、スライドオブジェクトまたは（形によって）背景が透けて見えます。

Aspose.Slides では、次のようにして形の透明度レベルを設定できます：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) を追加します。
4. アルファコンポーネントが設定された `Color.FromArgb` を使用します。
5. オブジェクトを PowerPoint ファイルとして保存します。 

この C# コードは、そのプロセスを示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // ソリッド形を追加します
    IShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // ソリッド形の上に透明な形を追加します
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 204, 102, 0);
    
    // PPTX ファイルをディスクに保存します
    presentation.Save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
}
```

## **形の回転**
Aspose.Slides では、スライドに追加された形を次の方法で回転させることができます：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) を追加します。
4. 必要な度数で形を回転させます。 
5. 修正されたプレゼンテーションを書き出します（PPTX ファイルとして）。

この C# コードは、形を 90 度回転させる方法を示しています：

```c#
// プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // 長方形の自動形を追加します
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // 形を 90 度回転させます
    shp.Rotation = 90;

    // PPTX ファイルをディスクに保存します
    pres.Save("RectShpRot_out.pptx", SaveFormat.Pptx);
}
```

## **3D ベベル効果の追加**
Aspose.Slides では、次の方法で形に 3D ベベル効果を追加できます。[ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) プロパティを修正します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) を追加します。
3. 形の [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) プロパティの好みのパラメータを設定します。 
4. プレゼンテーションをディスクに保存します。

この C# コードは、形に 3D ベベル効果を追加する方法を示しています：

```c#
// プレゼンテーションクラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    
    // スライドに形を追加します
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    ILineFillFormat format = shape.LineFormat.FillFormat;
    format.FillType = FillType.Solid;
    format.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;
    
    // 形の ThreeDFormat プロパティを設定します
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    
    // プレゼンテーションを PPTX ファイルとして保存します
    pres.Save("Bavel_out.pptx", SaveFormat.Pptx);
}
```

## **3D 回転効果の追加**
Aspose.Slides では、次の方法で形に 3D 回転効果を適用できます。[ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) プロパティを修正します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) を追加します。
3. [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/properties/cameratype) と [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/properties/lighttype) の好みの図形を指定します。
4. プレゼンテーションをディスクに保存します。 

この C# コードは、形に 3D 回転効果を適用する方法を示しています：

```c#
// プレゼンテーションクラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{
    IShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);
    
    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    
    autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(0, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    
    // プレゼンテーションを PPTX ファイルとして保存します
    pres.Save("Rotation_out.pptx", SaveFormat.Pptx);
}
```

## **書式のリセット**

この C# コードは、スライド内のプレースホルダーを持つすべての形状の位置、サイズ、および書式をデフォルトに戻す方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    foreach (ISlide slide in pres.Slides)
    {
        // レイアウト上のプレースホルダーを持つスライド上の各形状が元に戻されます
        slide.Reset();
    }
}
```