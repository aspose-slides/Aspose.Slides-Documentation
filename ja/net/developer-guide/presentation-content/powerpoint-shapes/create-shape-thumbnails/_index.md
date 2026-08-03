---
title: .NET でプレゼンテーション シェイプのサムネイルを作成
linktitle: シェイプ サムネイル
type: docs
weight: 70
url: /ja/net/create-shape-thumbnails/
keywords:
- シェイプ サムネイル
- シェイプ 画像
- シェイプをレンダリング
- シェイプのレンダリング
- 視覚的境界
- シェイプ境界
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint スライドから高品質なシェイプサムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成およびエクスポートします。"
---
## **はじめに**

Aspose.Slides for .NET は、各ページがスライドになるプレゼンテーションファイルを作成するために使用されます。これらのスライドは Microsoft PowerPoint でプレゼンテーション ファイルを開くことで表示できます。しかし、開発者がシェイプの画像を別々に画像ビューアで確認したい場合があります。そのようなケースでは、Aspose.Slides for .NET がスライド シェイプのサムネイル画像を生成するのに役立ちます。本記事ではこの機能の使用方法を説明します。
本記事では、スライド サムネイルをさまざまな方法で生成する手順を解説します。

- スライド内のシェイプ サムネイルを生成する。
- ユーザー定義のサイズでスライド シェイプのサムネイルを生成する。
- シェイプの外観の境界内でシェイプ サムネイルを生成する。

## **スライドからシェイプ サムネイルを生成する**
Aspose.Slides for .NET を使用して任意のスライドからシェイプ サムネイルを生成する手順:

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 参照したスライドのシェイプ サムネイル画像をデフォルト スケールで取得します。
1. サムネイル画像を任意の画像フォーマットで保存します。

以下の例はシェイプ サムネイルを生成します。

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **ユーザー定義スケーリング ファクタ サムネイルの生成**
Aspose.Slides for .NET を使用して任意のスライド シェイプのサムネイルを生成する手順:

1. `Presentation` クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. シェイプの境界を指定して参照したスライドのサムネイル画像を取得します。
1. サムネイル画像を任意の画像フォーマットで保存します。

以下の例はユーザー定義スケーリング ファクタを使用してサムネイルを生成します。

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // X および Y 軸に沿ったスケーリング。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **境界ベースのシェイプ外観サムネイルの作成**
このメソッドは、シェイプの外観の境界内でサムネイルを生成できるようにします。すべてのシェイプ効果が考慮されます。生成されたシェイプ サムネイルはスライドの境界で制限されます。シェイプの外観の境界内で任意のスライド シェイプのサムネイルを生成するには、以下のサンプル コードを使用します。

1. `Presentation` クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 参照したスライドのシェイプ境界を外観として取得し、サムネイル画像を取得します。
1. サムネイル画像を任意の画像フォーマットで保存します。

以下の例はユーザー定義スケーリング ファクタを使用してサムネイルを生成します。

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // X 軸および Y 軸に沿ったスケーリング。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **シェイプの実際の視覚的境界を取得する**

[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) のフレーム プロパティ（`X`、`Y`、`Width`、`Height`）は、プレゼンテーション モデルに保存されている矩形を表します。実際に描画されるコンテンツは、そのフレームを超えて拡張したり、別の軸に合わせた矩形を占有したりすることがあります。回転、アウトライン、矢印ヘッド、テキストのレイアウトとオーバーフロー、生成された SmartArt のジオメトリ、その他の描画効果により、占有領域が変わります。

画像を作成せずに占有領域を計算するには、[GetVisualBounds](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/getvisualbounds/) を使用します。このメソッドはスライド座標系で [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) を返します。返される矩形はスライドにクリップされないため、コンテンツがスライドの原点を超える場合は座標が負になることがあります。

現在、[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) インターフェイスには [GetVisualBounds](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/getvisualbounds/) が宣言されていません。そのため、スライドのシェイプ コレクションから取得したシェイプをインターフェイス値として保持し、メソッド呼び出し時にキャストしてください。

以下の例はフレームと視覚的境界を取得し、比較します。

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

同じ [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) を使用して、近接するシェイプを `Left`、`Right`、`Top`、`Bottom` のいずれかのエッジに合わせたり、生成されたレイアウトで十分なスペースを確保したり、許可された領域外のコンテンツを検出したりできます。視覚的境界は、SmartArt、テキスト ボックス、矢印、画像、回転シェイプ、グループ シェイプなど、格納されたフレームが完全な描画結果を表さない場合に特に有用です。

レイアウトや検証のために座標が必要でビットマップが不要な場合は [GetVisualBounds](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/getvisualbounds/) を使用します。シェイプを実際に描画したい場合は [IShape.GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/getimage/) を使用します。[ShapeThumbnailBounds](https://reference.aspose.com/slides/ja/net/aspose.slides/shapethumbnailbounds/) を使用すると、`ShapeThumbnailBounds.Shape` はアウトライン設定を含むシェイプ境界から画像サイズを決定し、`ShapeThumbnailBounds.Appearance` はシェイプの外観からサイズを決定し、結果をスライド境界に制限します。対照的に、[GetVisualBounds](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/getvisualbounds/) は計算された矩形のみを返し、スライドにクリップしません。

## **FAQ**

**シェイプ サムネイルを保存する際に使用できる画像フォーマットは何ですか？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/ja/net/aspose.slides/imageformat/) などです。シェイプは、コンテンツを SVG として保存することで [ベクター SVG としてエクスポート](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/writeassvg/) することもできます。

**サムネイルをレンダリングする際の Shape と Appearance の境界の違いは何ですか？**

`Shape` はシェイプのジオメトリを使用し、`Appearance` は [視覚効果](/slides/ja/net/shape-effect/)（影、光彩など）を考慮します。

**シェイプが非表示としてマークされている場合、サムネイルは生成されますか？**

非表示のシェイプはモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショーの表示に影響しますが、シェイプの画像生成を妨げることはありません。

**グループ シェイプ、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/) として表現できるオブジェクト（[GroupShape](https://reference.aspose.com/slides/ja/net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chart/)、[SmartArt](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/smartart/) を含む）はサムネイルまたは SVG として保存できます。

**システムにインストールされているフォントは、テキスト シェイプのサムネイル品質に影響しますか？**

はい。不要なフォントフォールバックやテキストの再配置を防ぐために、[必要なフォントを提供](/slides/ja/net/custom-font/)（または [フォント置換を構成](/slides/ja/net/font-substitution/)）する必要があります。