---
title: 形状サムネイルの作成
type: docs
weight: 70
url: /ja/net/create-shape-thumbnails/
keywords:
- 形状サムネイル
- 形状画像
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "PowerPointプレゼンテーションからC#または.NETで形状サムネイルを抽出する"
---

Aspose.Slides for .NET は、各ページがスライドとなるプレゼンテーション ファイルの作成に使用されます。これらのスライドは Microsoft PowerPoint でプレゼンテーション ファイルを開くことで表示できます。ただし、開発者が形状の画像を画像ビューアで個別に確認したい場合があります。そのような場合、Aspose.Slides for .NET はスライド形状のサムネイル画像を生成するのに役立ちます。この機能の使用方法はこの記事で説明します。

この記事では、スライドのサムネイルをさまざまな方法で生成する方法を説明します：

- スライド内の形状サムネイルを生成する。
- ユーザー定義のサイズでスライド形状のサムネイルを生成する。
- 形状の外観の境界内でサムネイルを生成する。
- SmartArt の子ノードのサムネイルを生成する。

## **スライドから形状サムネイルを生成**
Aspose.Slides for .NET を使用して任意のスライドから形状サムネイルを生成するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 参照されたスライドの形状サムネイル画像をデフォルトのスケールで取得します。
1. サムネイル画像を任意の画像フォーマットで保存します。

以下の例は形状サムネイルを生成するものです。
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


## **ユーザー定義スケーリング係数サムネイルを生成**
Aspose.Slides for .NET を使用して任意のスライド形状の形状サムネイルを生成するには、次の手順を実行します：

1. `Presentation` クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 参照されたスライドの形状境界付きサムネイル画像を取得します。
1. サムネイル画像を任意の画像フォーマットで保存します。

以下の例は、ユーザー定義のスケーリング係数でサムネイルを生成するものです。
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // X 軸と Y 軸のスケーリング。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```


## **形状外観の境界サムネイルを作成**
この形状サムネイル作成メソッドを使用すると、開発者は形状の外観の境界内でサムネイルを生成できます。すべての形状効果が考慮されます。生成された形状サムネイルはスライドの境界で制限されます。外観の境界内で任意のスライド形状のサムネイルを生成するには、以下のサンプルコードを使用します：

1. `Presentation` クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 参照されたスライドの形状境界を外観としてサムネイル画像を取得します。
1. サムネイル画像を任意の画像フォーマットで保存します。

以下の例は、ユーザー定義のスケーリング係数でサムネイルを作成するものです。
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // X軸とY軸に沿ったスケーリング。

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

**形状サムネイルを保存する際に使用できる画像フォーマットは何ですか？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)、その他があります。形状は、形状のコンテンツを SVG として保存することで、[ベクタ SVG としてエクスポート](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) することもできます。

**サムネイルをレンダリングする際の Shape 境界と Appearance 境界の違いは何ですか？**

`Shape` は形状のジオメトリを使用します。`Appearance` は[ビジュアル効果](/slides/ja/net/shape-effect/)（影、発光など）を考慮します。

**形状が非表示としてマークされている場合はどうなりますか？サムネイルとしてレンダリングされますか？**

非表示の形状はモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショーの表示に影響しますが、形状の画像生成を妨げることはありません。

**グループ形状、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) として表現されるオブジェクト（[GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)、[SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/) を含む）は、サムネイルまたは SVG として保存できます。

**システムにインストールされたフォントは、テキスト形状のサムネイル品質に影響しますか？**

はい。不要なフォールバックやテキストの再配置を防ぐために、[必要なフォントを提供](/slides/ja/net/custom-font/)（または[フォント置換を設定](/slides/ja/net/font-substitution/)）する必要があります。