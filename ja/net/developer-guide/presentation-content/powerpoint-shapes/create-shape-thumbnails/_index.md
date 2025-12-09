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

Aspose.Slides for .NET は、各ページがスライドとなるプレゼンテーションファイルを作成するために使用されます。これらのスライドは Microsoft PowerPoint でプレゼンテーションファイルを開くことで表示できます。ただし、開発者が形状の画像を別の画像ビューアで個別に表示したい場合があります。そのような場合、Aspose.Slides for .NET はスライド形状のサムネイル画像を生成するのに役立ちます。この機能の使用方法はこの記事で説明します。

この記事では、スライドのサムネイルをさまざまな方法で生成する方法を説明します：

- スライド内の形状サムネイルを生成する。
- ユーザー定義のサイズでスライド形状のサムネイルを生成する。
- 形状の外観の境界内でサムネイルを生成する。
- SmartArt 子ノードのサムネイルを生成する。

## **スライドから形状サムネイルを生成**
Aspose.Slides for .NET を使用して任意のスライドから形状サムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. ID またはインデックスを使用して任意のスライドへの参照を取得します。
3. 参照されたスライドの形状サムネイル画像をデフォルトスケールで取得します。
4. サムネイル画像を任意の画像形式で保存します。

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


## **ユーザー定義スケーリング係数サムネイルを生成**
Aspose.Slides for .NET を使用して任意のスライド形状の形状サムネイルを生成するには：

1. `Presentation` クラスのインスタンスを作成します。
2. ID またはインデックスを使用して任意のスライドへの参照を取得します。
3. 形状の境界を使用して参照されたスライドのサムネイル画像を取得します。
4. サムネイル画像を任意の画像形式で保存します。

以下の例は、ユーザー定義のスケーリング係数を使用してサムネイルを生成します。
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // X軸およびY軸方向のスケーリング。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```


## **形状の外観境界サムネイルを作成**
このメソッドは、形状の外観の境界内でサムネイルを生成できるようにします。すべての形状効果を考慮し、生成された形状サムネイルはスライドの境界に制限されます。外観の境界内で任意のスライド形状のサムネイルを生成するには、以下のサンプルコードを使用します：

1. `Presentation` クラスのインスタンスを作成します。
2. ID またはインデックスを使用して任意のスライドへの参照を取得します。
3. 外観として形状の境界を使用して参照されたスライドのサムネイル画像を取得します。
4. サムネイル画像を任意の画像形式で保存します。

以下の例は、外観の境界内でサムネイルを作成します。
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // X軸およびY軸方向のスケーリング。

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

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)、その他があります。形状は、形状のコンテンツを SVG として保存することで、[ベクター SVG としてエクスポートする](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)こともできます。

**サムネイルをレンダリングする際の Shape と Appearance の境界の違いは何ですか？**

`Shape` は形状のジオメトリを使用します。`Appearance` は[視覚効果](/slides/ja/net/shape-effect/)（影、光彩など）を考慮します。

**形状が非表示としてマークされている場合はどうなりますか？サムネイルとしてレンダリングされますか？**

非表示の形状はモデルの一部として残り、レンダリング可能です。非表示フラグはスライドショーの表示に影響しますが、形状の画像生成を妨げることはありません。

**グループ形状、チャート、SmartArt、その他の複雑なオブジェクトはサポートされていますか？**

はい。[Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) として表現できるすべてのオブジェクト（[GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)、[SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/) を含む）は、サムネイルや SVG として保存できます。

**システムにインストールされたフォントはテキスト形状のサムネイル品質に影響しますか？**

はい。不要なフォールバックやテキストのリフローを防ぐために、[必要なフォントを提供する](/slides/ja/net/custom-font/)（または[フォント置換を構成する](/slides/ja/net/font-substitution/)）必要があります。