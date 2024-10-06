---
title: シェイプサムネイルの作成
type: docs
weight: 70
url: /ja/net/create-shape-thumbnails/
keywords: 
- シェイプサムネイル
- シェイプ画像
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C# または .NET で PowerPoint プレゼンテーションからシェイプサムネイルを抽出する"
---

Aspose.Slides for .NET は、各ページがスライドであるプレゼンテーションファイルを作成するために使用されます。これらのスライドは、Microsoft PowerPointを使用してプレゼンテーションファイルを開くことによって表示できます。しかし、時には開発者が画像ビューアでシェイプの画像を別々に表示する必要がある場合があります。そのような場合、Aspose.Slides for .NET はスライドシェイプのサムネイル画像を生成するのに役立ちます。この機能の使用方法については、この記事で説明します。
この記事では、異なる方法でスライドサムネイルを生成する方法を説明します：

- スライド内にシェイプサムネイルを生成します。
- ユーザー定義の寸法でスライドシェイプのシェイプサムネイルを生成します。
- シェイプの外観の範囲内でシェイプサムネイルを生成します。
- SmartArt 子ノードのサムネイルを生成します。


## **スライドからシェイプサムネイルを生成する**
Aspose.Slides for .NETを使用して、任意のスライドからシェイプサムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 参照されたスライドのシェイプサムネイル画像をデフォルトスケールで取得します。
1. サムネイル画像を任意の希望する画像形式で保存します。

以下の例はシェイプサムネイルを生成します。

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


## **ユーザー定義スケーリング係数サムネイルを生成する**
Aspose.Slides for .NETを使用して、任意のスライドシェイプのシェイプサムネイルを生成するには：

1. `Presentation` クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. シェイプの範囲を持つ参照されたスライドのサムネイル画像を取得します。
1. サムネイル画像を任意の希望する画像形式で保存します。

以下の例はユーザー定義のスケーリング係数でサムネイルを生成します。

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // X軸およびY軸に沿ったスケーリング。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```


## **形状の外観に基づいたサムネイルを作成する**
このシェイプのサムネイルを作成するためのメソッドでは、開発者がシェイプの外観の範囲内でサムネイルを生成できるようにします。すべてのシェイプ効果を考慮に入れます。生成されたシェイプサムネイルはスライドの境界によって制限されます。任意のスライドシェイプの外観の範囲内でサムネイルを生成するには、以下のサンプルコードを使用します：

1. `Presentation` クラスのインスタンスを作成します。
1. ID またはインデックスを使用して任意のスライドの参照を取得します。
1. 外観としてシェイプの境界を持つ参照されたスライドのサムネイル画像を取得します。
1. サムネイル画像を任意の希望する画像形式で保存します。

以下の例はユーザー定義のスケーリング係数でサムネイルを生成します。

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // X軸およびY軸に沿ったスケーリング。

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```