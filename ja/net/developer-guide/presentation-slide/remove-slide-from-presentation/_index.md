---
title: "プレゼンテーションからスライドを削除"
type: docs
weight: 30
url: /ja/net/remove-slide-from-presentation/
keywords: "スライドの削除, スライドの除去, PowerPoint, プレゼンテーション, C#, Csharp, .NET, Aspose.Slides"
description: "C#または.NETで参照またはインデックスを使用してPowerPointのスライドを削除する"
---

スライド（またはその内容）が不要になった場合は、削除できます。Aspose.Slides は、プレゼンテーション内のすべてのスライドのリポジトリである[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) をカプセル化する[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスを提供します。既知の[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) オブジェクトに対してポインタ（参照またはインデックス）を使用することで、削除したいスライドを指定できます。

## **参照によるスライドの削除**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 削除したいスライドの ID または Index を使用して、その参照を取得します。
1. プレゼンテーションから参照されたスライドを削除します。
1. 変更されたプレゼンテーションを保存します。

この C# コードは、参照を使用してスライドを削除する方法を示しています：
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // スライド コレクション内のインデックスを使用してスライドにアクセスします
    ISlide slide = pres.Slides[0];

    // 参照を使用してスライドを削除します
    pres.Slides.Remove(slide);

    // 変更されたプレゼンテーションを保存します
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **インデックスによるスライドの削除**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックス位置を使用して、プレゼンテーションからスライドを削除します。
1. 変更されたプレゼンテーションを保存します。

この C# コードは、インデックスを使用してスライドを削除する方法を示しています：
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


## **未使用レイアウトスライドの削除**

Aspose.Slides は、不要で未使用のレイアウトスライドを削除できるように、[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) クラスの[RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) メソッドを提供します。この C# コードは、PowerPoint プレゼンテーションからレイアウトスライドを削除する方法を示しています：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **未使用マスタースライドの削除**

Aspose.Slides は、不要で未使用のマスタースライドを削除できるように、[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) クラスの[RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) メソッドを提供します。この C# コードは、PowerPoint プレゼンテーションからマスタースライドを削除する方法を示しています：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **よくある質問**

**スライドを削除した後、スライドインデックスはどうなりますか？**

削除後、[collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) は再インデックス化され、以降のすべてのスライドが左に1つずつシフトするため、以前のインデックス番号は古くなります。安定した参照が必要な場合は、インデックスではなく各スライドの永続的な ID を使用してください。

**スライドの ID はインデックスと異なりますか？隣接するスライドが削除されたときに変わりますか？**

はい。インデックスはスライドの位置を示し、スライドが追加または削除されると変わります。スライド ID は永続的な識別子であり、他のスライドが削除されても変わりません。

**スライドを削除するとスライドセクションにどのような影響がありますか？**

スライドがセクションに属している場合、そのセクションは単にスライドが1つ減ります。セクション構造はそのままで、セクションが空になった場合は、必要に応じて[セクションの削除または再編成](/slides/ja/net/slide-section/) を行えます。

**スライドが削除された場合、付随するノートやコメントはどうなりますか？**

[Notes](/slides/ja/net/presentation-notes/) と [comments](/slides/ja/net/presentation-comments/) はそのスライドに紐付いており、スライドとともに削除されます。他のスライドのコンテンツには影響しません。

**スライドの削除と未使用レイアウト/マスターのクリーンアップはどう違いますか？**

削除はデッキから特定の通常スライドを取り除きます。未使用のレイアウトやマスターのクリーンアップは、参照されていないレイアウトスライドやマスタースライドを削除し、残りのスライド内容を変更せずにファイルサイズを削減します。これらの操作は補完的で、通常はまずスライドを削除し、その後クリーンアップを行います。