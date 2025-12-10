---
title: .NET でプレゼンテーション形状のサムネイルを作成
linktitle: 形状サムネイル
type: docs
weight: 70
url: /ja/net/create-shape-thumbnails/
keywords:
- 形状サムネイル
- 形状画像
- 形状のレンダリング
- 形状レンダリング
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint スライドから高品質な形状サムネイルを生成し、プレゼンテーションのサムネイルを簡単に作成・エクスポートできます。"
---

Aspose.Slides for .NET は、各ページがスライドであるプレゼンテーション ファイルを作成するために使用されます。これらのスライドは Microsoft PowerPoint でプレゼンテーション ファイルを開くことで表示できます。ただし、開発者が形状の画像を別々の画像ビューアで表示する必要がある場合があります。そのようなケースでは、Aspose.Slides for .NET がスライド形状のサムネイル画像の生成を支援します。この機能の使用方法はこの記事で説明しています。

この記事では、スライドのサムネイルをさまざまな方法で生成する方法を説明します：

- スライド内の形状サムネイルを生成する。
- ユーザー定義の寸法でスライド形状のサムネイルを生成する。
- 形状の外観の境界内で形状サムネイルを生成する。
- SmartArt の子ノードのサムネイルを生成する。

## **スライドから形状サムネイルを生成する**
Aspose.Slides for .NET を使用して任意のスライドから形状サムネイルを生成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 参照したスライドの形状サムネイル画像をデフォルトのスケールで取得します。
1. サムネイル画像を任意の画像形式で保存します。

以下の例は形状サムネイルを生成します。
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


## **ユーザー定義のスケーリングファクターでサムネイルを生成する**
Aspose.Slides for .NET を使用して任意のスライド形状の形状サムネイルを生成するには、次の手順を実行します。

1. `Presentation` クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 参照したスライドの形状境界を使用したサムネイル画像を取得します。
1. サムネイル画像を任意の画像形式で保存します。

以下の例は、ユーザー定義のスケーリングファクターを使用してサムネイルを生成します。
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // X と Y 軸に沿ったスケーリング。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```


## **境界ベースの形状外観サムネイルを作成する**
この形状サムネイル作成方法により、開発者は形状の外観の境界内でサムネイルを生成できます。すべての形状効果が考慮されます。生成された形状サムネイルはスライドの境界で制限されます。外観の境界内で任意のスライド形状のサムネイルを生成するには、以下のサンプルコードを使用してください。

1. `Presentation` クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 参照したスライドの形状境界を外観として使用したサムネイル画像を取得します。
1. サムネイル画像を任意の画像形式で保存します。

以下の例は、ユーザー定義のスケーリングファクターを使用してサムネイルを作成します。
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // X と Y 軸に沿ったスケーリング。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```


## **FAQ**

**形状サムネイルを保存する際に使用できる画像形式は何ですか？**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)、その他があります。形状は、形状のコンテンツを SVG として保存することで、[ベクター SVG としてエクスポートできます](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)。

**サムネイルのレンダリング時に Shape と Appearance の境界の違いは何ですか？**  
`Shape` は形状のジオメトリを使用します。`Appearance` は[視覚効果](/slides/ja/net/shape-effect/)（影、グローなど）を考慮します。

**形状が非表示としてマークされている場合はどうなりますか？サムネイルとして表示されますか？**  
非表示の形状はモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショーの表示に影響しますが、形状の画像生成を妨げるものではありません。

**グループ形状、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**  
はい。 [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) として表現されるすべてのオブジェクト（[GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)、[SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/) を含む）は、サムネイルまたは SVG として保存できます。

**システムにインストールされたフォントは、テキスト形状のサムネイル品質に影響しますか？**  
はい。不要なフォールバックやテキストの再配置を防ぐために、[必要なフォントを提供する](/slides/ja/net/custom-font/)（または[フォント置換を設定する](/slides/ja/net/font-substitution/)）必要があります。