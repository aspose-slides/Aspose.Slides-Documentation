---
title: グループ
type: docs
weight: 40
url: /ja/net/group/
keywords: "グループ シェイプ, PowerPoint シェイプ, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションにグループ シェイプを追加する"
---

## **グループ シェイプの追加**
Aspose.Slides はスライド上のグループ シェイプの操作をサポートします。この機能により、開発者はよりリッチなプレゼンテーションを実現できます。Aspose.Slides for .NET はグループ シェイプの追加または取得をサポートします。追加したグループ シェイプにシェイプを配置して内容を埋め込んだり、グループ シェイプの任意のプロパティにアクセスしたりできます。Aspose.Slides for .NET を使用してスライドにグループ シェイプを追加する手順は次のとおりです:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにグループ シェイプを追加します。
1. 追加したグループ シェイプにシェイプを追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例はスライドにグループ シェイプを追加するものです。
```c#
    // Presentation クラスのインスタンス化 
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
この項目では、グループ シェイプを追加し、スライド上のグループ シェイプの AltText プロパティにアクセスする手順を、コード例とともに示します。Aspose.Slides for .NET を使用してスライド内のグループ シェイプの AltText にアクセスする手順は次のとおりです:

1. PPTX ファイルを表す `Presentation` クラスをインスタンス化します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドのシェイプ コレクションにアクセスします。
1. グループ シェイプにアクセスします。
1. AltText プロパティにアクセスします。

以下の例はグループ シェイプの代替テキストにアクセスするものです。
```c#
// PPTX ファイルを表す Presentation クラスのインスタンス化
Presentation pres = new Presentation("AltText.pptx");

// 最初のスライドを取得
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // スライドのシェイプコレクションにアクセス
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // グループ シェイプにアクセス。
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

**ネストされたグルーピング（グループ内のグループ）はサポートされていますか？**

はい。[GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) には [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/) プロパティがあり、階層サポート（あるグループが別のグループの子になること）を直接示します。

**スライド上の他のオブジェクトに対するグループの Z オーダーをどのように制御しますか？**

[GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) の [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) プロパティを使用して、表示スタック内での位置を確認または変更できます。

**移動／編集／グループ解除を防止できますか？**

はい。グループのロック セクションは [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/) を通じて公開されており、オブジェクトに対する操作を制限できます。