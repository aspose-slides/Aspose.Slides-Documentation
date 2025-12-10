---
title: ".NET でプレゼンテーション スライドにアクセスする"
linktitle: "スライドにアクセス"
type: docs
weight: 20
url: /ja/net/access-slide-in-presentation/
keywords:
- "スライドにアクセス"
- "スライド インデックス"
- "スライド ID"
- "スライド位置"
- "位置の変更"
- "スライド プロパティ"
- "スライド番号"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションでスライドにアクセスし管理する方法を学びます。コード例で生産性を向上させましょう。"
---

Aspose.Slides では、スライドに 2 つの方法でアクセスできます: インデックスによる方法と ID による方法です。

## **インデックスでスライドにアクセス**

プレゼンテーション内のすべてのスライドは、スライド位置に基づいて 0 から始まる数値で並べられます。最初のスライドはインデックス 0 でアクセスでき、2 番目のスライドはインデックス 1 でアクセスでき、以下同様です。

Presentation クラスはプレゼンテーション ファイルを表し、すべてのスライドを [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) コレクション（[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) オブジェクトのコレクション）として公開します。この C# コードは、インデックスを使用してスライドにアクセスする方法を示しています:
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation presentation = new Presentation("AccessSlides.pptx");

// インデックスでスライドの参照を取得します
ISlide slide = presentation.Slides[0];
```


## **IDでスライドにアクセス**

プレゼンテーション内の各スライドには一意の ID が割り当てられています。その ID を対象とするには、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスで公開されている [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) メソッドを使用できます。この C# コードは、有効なスライド ID を指定して [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) メソッドでスライドにアクセスする方法を示しています:
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation presentation = new Presentation("AccessSlides.pptx");

// スライド ID を取得します
uint id = presentation.Slides[0].SlideId;

// ID でスライドにアクセスします
IBaseSlide slide = presentation.GetSlideById(id);
```


## **スライド位置の変更**

Aspose.Slides では、スライドの位置を変更できます。たとえば、最初のスライドを 2 番目のスライドにすることができます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用して、位置を変更したいスライドの参照を取得します。
1. [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) プロパティを使用してスライドの新しい位置を設定します。
1. 変更されたプレゼンテーションを保存します。

この C# コードは、位置 1 のスライドが位置 2 に移動する操作を示しています:
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // 位置が変更されるスライドを取得します
    ISlide sld = pres.Slides[0];

    // スライドの新しい位置を設定します
    sld.SlideNumber = 2;

    // 変更されたプレゼンテーションを保存します
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```


最初のスライドは 2 番目になり、2 番目のスライドは最初になりました。スライドの位置を変更すると、他のスライドは自動的に調整されます。

## **スライド番号の設定**

[FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) プロパティ（[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスで公開）を使用すると、プレゼンテーションの最初のスライドに新しい番号を指定できます。この操作により、他のスライド番号が再計算されます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. スライド番号を取得します。
1. スライド番号を設定します。
1. 変更されたプレゼンテーションを保存します。

この C# コードは、最初のスライド番号を 10 に設定する操作を示しています:
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // スライド番号を取得します
    int firstSlideNumber = presentation.FirstSlideNumber;

    // スライド番号を設定します
    presentation.FirstSlideNumber=10;
    
    // 変更されたプレゼンテーションを保存します
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```


最初のスライドをスキップしたい場合は、2 番目のスライドから番号付けを開始し（最初のスライドの番号付けは非表示に）次のように設定できます:
```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // 最初のプレゼンテーションスライドの番号を設定します
    presentation.FirstSlideNumber = 0;

    // すべてのスライドのスライド番号を表示します
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // 最初のスライドのスライド番号を非表示にします
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // 変更されたプレゼンテーションを保存します
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**ユーザーが見るスライド番号は、コレクションのゼロベースインデックスと一致しますか？**

スライドに表示される番号は任意の値（例: 10）から開始でき、インデックスと一致する必要はありません。この関係はプレゼンテーションの [first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) 設定によって制御されます。

**非表示スライドはインデックスに影響しますか？**

はい。非表示スライドはコレクション内に残り、インデックスのカウントに含まれます。「非表示」は表示上の状態を指すもので、コレクション内の位置には影響しません。

**スライドが追加または削除されたときに、スライドのインデックスは変わりますか？**

はい。インデックスは常にスライドの現在の順序を反映し、挿入、削除、移動操作が行われるたびに再計算されます。