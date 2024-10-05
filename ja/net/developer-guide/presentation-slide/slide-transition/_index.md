---
title: スライド トランジション
type: docs
weight: 90
url: /net/slide-transition/
keywords: "スライド トランジションを追加, PowerPoint スライド トランジション, モーフ トランジション, 高度なスライド トランジション, トランジション エフェクト, C#, Csharp, .NET, Aspose.Slides"
description: "C# または .NET で PowerPoint スライド トランジションとトランジション エフェクトを追加"
---

## **スライド トランジションを追加**
理解しやすくするために、Aspose.Slides for .NET を使用してシンプルなスライド トランジションの管理方法を示しました。開発者は、スライドに異なるスライド トランジション エフェクトを適用するだけでなく、これらのトランジション エフェクトの動作をカスタマイズすることもできます。シンプルなスライド トランジション エフェクトを作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. TransitionType 列挙体を介して、Aspose.Slides for .NET が提供するトランジション エフェクトのいずれかからスライドにスライド トランジション タイプを適用します。
1. 修正されたプレゼンテーションファイルを書き込みます。

```c#
// ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // スライド 1 にサークル タイプのトランジションを適用
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // スライド 2 にコンボ タイプのトランジションを適用
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // プレゼンテーションをディスクに保存
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

## **高度なスライド トランジションを追加**
上記のセクションでは、スライドにシンプルなトランジションエフェクトを適用しました。次に、そのシンプルなトランジションエフェクトをさらに優れたものにし、制御するために、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. Aspose.Slides for .NET が提供するトランジションエフェクトのいずれかからスライドにスライドトランジションタイプを適用します。
1. クリック時、特定の時間経過後、またはその両方で進むようにトランジションを設定できます。
1. スライドトランジションが クリック時の進行を有効にすると、誰かがマウスをクリックしたときにのみトランジションが進行します。さらに、Advance After Time プロパティが設定されている場合、指定された進行時間が経過するとトランジションが自動的に進行します。
1. 修正されたプレゼンテーションをプレゼンテーションファイルとして書き込みます。

```c#
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{
    // スライド 1 にサークル タイプのトランジションを適用
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // 3 秒のトランジション時間を設定
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // スライド 2 にコンボ タイプのトランジションを適用
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // 5 秒のトランジション時間を設定
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // スライド 3 にズーム タイプのトランジションを適用
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    // 7 秒のトランジション時間を設定
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // プレゼンテーションをディスクに保存
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

さらに、[AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) プロパティを使用すると、スライドトランジションが次のスライドに移動するように設定されているか、設定が無効になっているかを確認できます。

この C# コードは操作を示しています：

```c#
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // スライドのトランジションを取得
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Advance After Time 設定が有効かどうかを確認
        if (slideTransition.AdvanceAfter)
        {
            // Advance After Time 値を出力
            Console.WriteLine("スライド #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // AdvancedAfterTime 値が 2 秒を超える場合、特定の時間後にトランジションを無効にする
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **モーフ トランジション**
Aspose.Slides for .NET では、[モーフ トランジション](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition)がサポートされるようになりました。これは、PowerPoint 2019 で導入された新しいモーフ トランジションを表しています。モーフ トランジションを使用すると、一つのスライドから次のスライドへの滑らかな動きをアニメーション化できます。この記事では、概念とモーフ トランジションの使用方法を説明します。モーフ トランジションを効果的に使用するには、少なくとも一つの共通オブジェクトを持つ2つのスライドが必要です。最も簡単な方法は、スライドを複製し、2番目のスライドでオブジェクトを別の場所に移動することです。

以下のコードスニペットは、テキストを含むスライドのクローンをプレゼンテーションに追加し、2番目のスライドに[モーフタイプ](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype)のトランジションを設定する方法を示しています。

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "PowerPoint プレゼンテーションのモーフ トランジション";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **モーフ トランジション タイプ**
新しい[Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype) 列挙体が追加されました。これは、異なるタイプのモーフ スライド トランジションを表します。

TransitionMorphType 列挙体には 3 つのメンバーがあります：

- ByObject: モーフ トランジションは、シェイプを不可分なオブジェクトとして考慮して実行されます。
- ByWord: モーフ トランジションは、可能な場合、単語ごとにテキストを移動させることで実行されます。
- ByChar: モーフ トランジションは、可能な場合、文字ごとにテキストを移動させることで実行されます。

以下のコードスニペットは、スライドにモーフ トランジションを設定し、モーフ タイプを変更する方法を示しています：

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **トランジション エフェクトの設定**
Aspose.Slides for .NET では、ブラックから、左から、右からなどのトランジション エフェクトを設定することをサポートしています。トランジション エフェクトを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
- スライドの参照を取得します。
- トランジション エフェクトを設定します。
- プレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルとして書き込みます。

以下の例では、トランジション エフェクトを設定しています。

```c#
// Presentation クラスのインスタンスを作成
Presentation presentation = new Presentation("AccessSlides.pptx");

// エフェクトを設定
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// プレゼンテーションをディスクに保存
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```