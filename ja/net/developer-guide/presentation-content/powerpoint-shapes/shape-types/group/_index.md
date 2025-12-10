---
title: .NET のグループ プレゼンテーション シェイプ
linktitle: シェイプ グループ
type: docs
weight: 40
url: /ja/net/group/
keywords:
- グループ シェイプ
- シェイプ グループ
- グループの追加
- 代替テキスト
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint デックでシェイプをグループ化およびグループ解除する方法を学びます - 高速でステップバイステップのガイド、無料の C# コード付き。"
---

## **グループ シェイプの追加**
Aspose.Slides はスライド上のグループシェイプの操作をサポートします。この機能により、開発者はよりリッチなプレゼンテーションを実現できます。Aspose.Slides for .NET はグループシェイプの追加またはアクセスをサポートしています。追加したグループシェイプにシェイプを追加して内容を構成したり、グループシェイプの任意のプロパティにアクセスしたりすることが可能です。Aspose.Slides for .NET を使用してスライドにグループシェイプを追加するには、次の手順を実行します:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにグループシェイプを追加します。
1. 追加したグループシェイプにシェイプを追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例はスライドにグループシェイプを追加します。
```c#
// Presentation クラスをインスタンス化
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得
    ISlide sld = pres.Slides[0];

    // スライドのシェイプコレクションにアクセス
    IShapeCollection slideShapes = sld.Shapes;

    // スライドにグループシェイプを追加
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // 追加したグループシェイプ内にシェイプを追加
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // グループシェイプのフレームを設定
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // PPTX ファイルをディスクに保存
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```


## **AltText プロパティへのアクセス**
このトピックでは、グループシェイプの追加とスライド上のグループシェイプの AltText プロパティへのアクセスを示すシンプルな手順とコード例を紹介します。Aspose.Slides for .NET を使用してスライド内のグループシェイプの AltText にアクセスするには、次の手順を実行します:

1. `Presentation` クラスのインスタンスを作成します（PPTX ファイルを表します）。
1. インデックスを使用してスライドの参照を取得します。
1. スライドのシェイプコレクションにアクセスします。
1. グループシェイプにアクセスします。
1. AltText プロパティにアクセスします。

以下の例はグループシェイプの代替テキストにアクセスします。
```c#
// PPTX ファイルを表す Presentation クラスをインスタンス化
Presentation pres = new Presentation("AltText.pptx");

// 最初のスライドを取得
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // スライドのシェイプコレクションにアクセス
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // グループシェイプにアクセス。
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // AltText プロパティにアクセス
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```


## **FAQ**

**入れ子のグループ化（グループ内のグループ）はサポートされていますか？**

はい。[GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) には [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/) プロパティがあり、階層サポート（あるグループが別のグループの子になること）が直接示されています。

**スライド上の他のオブジェクトに対するグループの Z オーダーをどのように制御しますか？**

[GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) の [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) プロパティを使用して、表示スタック内での位置を確認します。

**移動/編集/グループ解除を防止できますか？**

はい。グループのロックセクションは [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/) で公開されており、オブジェクトに対する操作を制限できます。