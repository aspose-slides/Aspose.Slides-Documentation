---
title: プレゼンテーション内のスライドにアクセス
type: docs
weight: 20
url: /net/access-slide-in-presentation/
keywords: "Access PowerPoint Presentation, Access slide, Edit slide properties, Change slide position, Set slide number, index, ID, position  C#, Csharp, .NET, Aspose.Slides"
description: "C#または.NETでインデックス、ID、または位置によってPowerPointスライドにアクセスします。スライドのプロパティを編集します。"
---

Aspose.Slidesを使用すると、インデックスまたはIDによってスライドにアクセスできます。

## **インデックスによるスライドのアクセス**

プレゼンテーション内のすべてのスライドは、0から始まるスライドの位置に基づいて数字で配置されています。最初のスライドはインデックス0を介してアクセスでき、2番目のスライドはインデックス1を介してアクセスできます。

Presentationクラスは、プレゼンテーションファイルを表現し、すべてのスライドを[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)コレクション（[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)オブジェクトのコレクション）として公開しています。このC#コードは、インデックスを介してスライドにアクセスする方法を示しています：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation presentation = new Presentation("AccessSlides.pptx");

// インデックスを介してスライドの参照を取得
ISlide slide = presentation.Slides[0];
```

## **IDによるスライドのアクセス**

プレゼンテーション内の各スライドには、それに関連付けられた一意のIDがあります。[GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid)メソッド（[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスによって公開）を使用して、そのIDをターゲットにできます。このC#コードは、有効なスライドIDを提供し、[GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid)メソッドを介してそのスライドにアクセスする方法を示しています：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation presentation = new Presentation("AccessSlides.pptx");

// スライドIDを取得
uint id = presentation.Slides[0].SlideId;

// IDを介してスライドにアクセス
IBaseSlide slide = presentation.GetSlideById(id);
```

## **スライドの位置を変更する**
Aspose.Slidesでは、スライドの位置を変更できます。たとえば、最初のスライドを2番目のスライドにすることができます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. 位置を変更したいスライドの参照をインデックスを介して取得します。
1. [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/)プロパティを介してスライドに新しい位置を設定します。
1. 修正したプレゼンテーションを保存します。

このC#コードは、位置1のスライドを位置2に移動する操作を示します：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // 位置が変更されるスライドを取得
    ISlide sld = pres.Slides[0];

    // スライドの新しい位置を設定
    sld.SlideNumber = 2;

    // 修正したプレゼンテーションを保存
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

最初のスライドは2番目になり、2番目のスライドは最初になりました。スライドの位置を変更すると、他のスライドは自動的に調整されます。

## **スライド番号を設定する**
[FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/)プロパティ（[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスによって公開）を使用すると、プレゼンテーション内の最初のスライドの新しい番号を指定できます。この操作により、他のスライド番号が再計算されます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライド番号を取得します。
1. スライド番号を設定します。
1. 修正したプレゼンテーションを保存します。

このC#コードは、最初のスライド番号を10に設定する操作を示します：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // スライド番号を取得
    int firstSlideNumber = presentation.FirstSlideNumber;

    // スライド番号を設定
    presentation.FirstSlideNumber=10;
    
    // 修正したプレゼンテーションを保存
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

最初のスライドをスキップしたい場合は、次のように2番目のスライドから番号付けを開始し（最初のスライドの番号付けを隠す）、実行できます：

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // 最初のプレゼンテーションスライドの番号を設定
    presentation.FirstSlideNumber = 0;

    // すべてのスライドのスライド番号の可視性を表示
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // 最初のスライドのスライド番号の可視性を隠す
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // 修正したプレゼンテーションを保存
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```