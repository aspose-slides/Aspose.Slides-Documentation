---
title: プレゼンテーションのスライドにアクセス
type: docs
weight: 20
url: /ja/net/access-slide-in-presentation/
keywords: "PowerPoint プレゼンテーションにアクセス, スライドにアクセス, スライドのプロパティを編集, スライドの位置を変更, スライド番号を設定, インデックス, ID, 位置, C#, Csharp, .NET, Aspose.Slides"
description: "C# または .NET でインデックス、ID、または位置で PowerPoint スライドにアクセスします。スライドのプロパティを編集"
---

Aspose.Slides では、スライドに 2 つの方法でアクセスできます: インデックスによる方法と ID による方法です。

## **インデックスでスライドにアクセス**

プレゼンテーション内のすべてのスライドは、スライド位置に基づいて 0 から始まる数値で配置されます。最初のスライドはインデックス 0 で、2 番目のスライドはインデックス 1 で、というようにアクセスできます。

プレゼンテーション ファイルを表す Presentation クラスは、すべてのスライドを [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) コレクション（[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) オブジェクトのコレクション）として公開します。この C# コードは、インデックスを使用してスライドにアクセスする方法を示しています:
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation presentation = new Presentation("AccessSlides.pptx");

// インデックスを使用してスライドの参照を取得します
ISlide slide = presentation.Slides[0];
```


## **IDでスライドにアクセス**

プレゼンテーション内の各スライドには、固有の ID が付与されています。その ID を対象にするには、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスが提供する [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) メソッドを使用できます。この C# コードは、有効なスライド ID を指定し、[GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) メソッドでそのスライドにアクセスする方法を示しています:
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation presentation = new Presentation("AccessSlides.pptx");

// スライドの ID を取得します
uint id = presentation.Slides[0].SlideId;

// ID を使用してスライドにアクセスします
IBaseSlide slide = presentation.GetSlideById(id);
```


## **スライド位置の変更**
Aspose.Slides では、スライドの位置を変更できます。たとえば、最初のスライドを 2 番目のスライドにすることができます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用して、位置を変更したいスライドの参照を取得します。
1. [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) プロパティを使用して、スライドの新しい位置を設定します。
1. 変更されたプレゼンテーションを保存します。

この C# コードは、位置 1 のスライドを位置 2 に移動する操作を示しています:
```c#
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // 位置を変更するスライドを取得します
    ISlide sld = pres.Slides[0];

    // スライドの新しい位置を設定します
    sld.SlideNumber = 2;

    // 変更されたプレゼンテーションを保存します
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```


最初のスライドが 2 番目になり、2 番目のスライドが最初になりました。スライドの位置を変更すると、他のスライドは自動的に調整されます。

## **スライド番号の設定**
[FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) プロパティ（[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスが提供）を使用すると、プレゼンテーションの最初のスライドに新しい番号を指定できます。この操作により、他のスライド番号が再計算されます。

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


最初のスライドをスキップしたい場合は、2 番目のスライドから番号付けを開始し（最初のスライドの番号は非表示に）以下のように設定できます:
```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // 最初のプレゼンテーション スライドの番号を設定します
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

**ユーザーが見るスライド番号はコレクションの 0 ベース インデックスと一致しますか？**

スライドに表示される番号は任意の値（例: 10）から開始でき、インデックスと一致する必要はありません。この関係は、プレゼンテーションの [first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) 設定によって制御されます。

**非表示のスライドはインデックス付けに影響しますか？**

はい。非表示のスライドはコレクション内に残り、インデックス計算に含まれます。「非表示」は表示状態を指すもので、コレクション内の位置には影響しません。

**他のスライドが追加・削除されたときにスライドのインデックスは変わりますか？**

はい。インデックスは常にスライドの現在の順序を反映しており、挿入、削除、移動操作が行われるたびに再計算されます。