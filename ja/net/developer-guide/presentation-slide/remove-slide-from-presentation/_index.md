---
title: プレゼンテーションからスライドを削除する
type: docs
weight: 30
url: /net/remove-slide-from-presentation/
keywords: "スライドを削除, スライドを消去, PowerPoint, プレゼンテーション, C#, Csharp, .NET, Aspose.Slides"
description: "C# または .NET で参照またはインデックスを使用して PowerPoint からスライドを削除します"

---

スライド（またはその内容）が冗長になる場合、削除することができます。Aspose.Slides では、プレゼンテーション内のすべてのスライドのリポジトリである [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) をカプセル化する [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスを提供しています。既知の [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) オブジェクトへのポインタ（参照またはインデックス）を使用して、削除したいスライドを指定できます。

## **参照によるスライドの削除**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを介して削除したいスライドの参照を取得します。
1. プレゼンテーションから参照されたスライドを削除します。
1. 修正されたプレゼンテーションを保存します。

この C# コードは、参照を介してスライドを削除する方法を示しています：

```c#
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // スライドコレクションのインデックスを介してスライドにアクセスします
    ISlide slide = pres.Slides[0];

    // 参照を介してスライドを削除します
    pres.Slides.Remove(slide);

    // 修正されたプレゼンテーションを保存します
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **インデックスによるスライドの削除**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックス位置を介してプレゼンテーションからスライドを削除します。
1. 修正されたプレゼンテーションを保存します。

この C# コードは、インデックスを介してスライドを削除する方法を示しています：

```c#
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // スライドインデックスを介してスライドを削除します
    pres.Slides.RemoveAt(0);

    // 修正されたプレゼンテーションを保存します
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **未使用のレイアウトスライドの削除**

Aspose.Slides では、不要な未使用のレイアウトスライドを削除できる [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) メソッド（[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) クラスから）を提供しています。この C# コードは、PowerPoint プレゼンテーションからレイアウトスライドを削除する方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **未使用のマスタースライドの削除**

Aspose.Slides では、不要な未使用のマスタースライドを削除できる [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) メソッド（[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) クラスから）を提供しています。この C# コードは、PowerPoint プレゼンテーションからマスタースライドを削除する方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```