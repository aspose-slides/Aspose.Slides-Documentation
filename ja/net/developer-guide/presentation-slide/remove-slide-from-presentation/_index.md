---
title: ".NET でプレゼンテーションからスライドを削除"
linktitle: "スライドを削除"
type: docs
weight: 30
url: /ja/net/remove-slide-from-presentation/
keywords:
- スライド削除
- スライドの削除
- 未使用スライドの削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint と OpenDocument のプレゼンテーションからスライドを手軽に削除できます。明確な C# コード例を取得し、ワークフローを向上させましょう。"
---

スライド（またはその内容）が不要になった場合は、削除できます。Aspose.Slides は、プレゼンテーション内のすべてのスライドのリポジトリである [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) をカプセル化する [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスを提供します。既知の [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) オブジェクトに対してポインタ（参照またはインデックス）を使用すると、削除したいスライドを指定できます。

## **参照でスライドを削除する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 削除したいスライドを ID またはインデックスで参照取得します。
1. 参照したスライドをプレゼンテーションから削除します。
1. 変更されたプレゼンテーションを保存します。

この C# コードは、参照を使用してスライドを削除する方法を示しています。
```c#
 // プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // スライド コレクション内のインデックスでスライドにアクセスします
    ISlide slide = pres.Slides[0];

    // 参照を使用してスライドを削除します
    pres.Slides.Remove(slide);

    // 変更されたプレゼンテーションを保存します
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **インデックスでスライドを削除する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックス位置を使用してプレゼンテーションからスライドを削除します。
1. 変更されたプレゼンテーションを保存します。

この C# コードは、インデックスを使用してスライドを削除する方法を示しています。
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // スライド インデックスを使用してスライドを削除します
    pres.Slides.RemoveAt(0);

    // 変更されたプレゼンテーションを保存します
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **未使用のレイアウトスライドを削除する**

Aspose.Slides は、不要なレイアウトスライドを削除できるようにする [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) クラスの [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) メソッドを提供します。この C# コードは、PowerPoint プレゼンテーションからレイアウトスライドを削除する方法を示しています。
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **未使用のマスタースライドを削除する**

Aspose.Slides は、不要なマスタースライドを削除できるようにする [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) クラスの [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) メソッドを提供します。この C# コードは、PowerPoint プレゼンテーションからマスタースライドを削除する方法を示しています。
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**スライドを削除した後、スライドインデックスはどうなりますか？**

削除後、[collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) は再インデックス化され、以降のすべてのスライドが左に1つずつシフトします。そのため、以前のインデックス番号は古くなります。安定した参照が必要な場合は、インデックスではなく各スライドの永続的な ID を使用してください。

**スライドの ID はインデックスと異なりますか？また、隣接するスライドが削除されたときに変わりますか？**

はい。インデックスはスライドの位置を示し、スライドが追加または削除されると変わります。一方、スライド ID は永続的な識別子であり、他のスライドが削除されても変わりません。

**スライドを削除すると、スライドセクションにどのような影響がありますか？**

スライドがセクションに属している場合、そのセクションのスライド数が1つ減ります。セクション構造はそのままで、セクションが空になった場合は、必要に応じて[セクションの削除または再編成](/slides/ja/net/slide-section/)が可能です。

**スライドが削除されたとき、スライドに付随するノートやコメントはどうなりますか？**

[Notes](/slides/ja/net/presentation-notes/) と [comments](/slides/ja/net/presentation-comments/) は特定のスライドに紐付いており、スライドと共に削除されます。他のスライドのコンテンツには影響しません。

**スライドを削除することと、未使用のレイアウト/マスターをクリーンアップすることはどう違いますか？**

削除はデッキから特定の通常スライドを取り除きます。未使用のレイアウト/マスターのクリーンアップは、参照されていないレイアウトスライドやマスタースライドを削除し、残りのスライド内容を変更せずにファイルサイズを削減します。これらの操作は補完的であり、通常は先に削除し、次にクリーンアップを行います。