---
title: グループ
type: docs
weight: 40
url: /ja/net/group/
keywords: "グループ図形, PowerPoint図形, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションにグループ図形を追加する"
---

## **グループ図形の追加**
Aspose.Slidesはスライド上のグループ図形を扱うことをサポートしています。この機能は、開発者がよりリッチなプレゼンテーションをサポートするのに役立ちます。Aspose.Slides for .NETはグループ図形の追加またはアクセスをサポートしています。追加したグループ図形に図形を追加して内容を充填したり、グループ図形の任意のプロパティにアクセスしたりすることができます。Aspose.Slides for .NETを使用してスライドにグループ図形を追加する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにグループ図形を追加します。
1. 追加したグループ図形に図形を追加します。
1. 修正したプレゼンテーションをPPTXファイルとして保存します。

以下の例では、スライドにグループ図形を追加します。

```c#
// Presentationクラスをインスタンス化
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得
    ISlide sld = pres.Slides[0];

    // スライドの図形コレクションにアクセス
    IShapeCollection slideShapes = sld.Shapes;

    // スライドにグループ図形を追加
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // 追加されたグループ図形内に図形を追加
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // グループ図形のフレームを追加
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // PPTXファイルをディスクに書き込み
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```

## **AltTextプロパティへのアクセス**
このトピックでは、スライド上のグループ図形を追加し、AltTextプロパティにアクセスするための簡単な手順を、コード例を交えて示します。Aspose.Slides for .NETを使用してスライドのグループ図形のAltTextにアクセスする手順は以下の通りです。

1. PPTXファイルを表す`Presentation`クラスをインスタンス化します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドの図形コレクションにアクセスします。
1. グループ図形にアクセスします。
1. AltTextプロパティにアクセスします。

以下の例では、グループ図形の代替テキストにアクセスします。

```c#
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation("AltText.pptx");

// 最初のスライドを取得
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // スライドの図形コレクションにアクセス
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // グループ図形にアクセス
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // AltTextプロパティにアクセス
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```