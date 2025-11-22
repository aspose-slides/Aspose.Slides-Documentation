---
title: スライド トランジション
type: docs
weight: 90
url: /ja/net/slide-transition/
keywords: "スライド トランジションを追加, PowerPoint スライド トランジション, モーフ トランジション, 高度なスライド トランジション, トランジション効果, C#, Csharp, .NET, Aspose.Slides"
description: "C#または.NETでPowerPointスライド トランジションとトランジション効果を追加"
---

## **スライド トランジションの追加**
理解しやすくするために、Aspose.Slides for .NET を使用してシンプルなスライド トランジションを管理する方法を示しました。開発者はスライドにさまざまなトランジション効果を適用できるだけでなく、これらの効果の挙動もカスタマイズできます。シンプルなスライド トランジション効果を作成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. TransitionType 列挙体で提供されるトランジション効果のいずれかを使用して、スライドにスライド トランジション タイプを適用します。  
3. 変更されたプレゼンテーション ファイルを書き出します。  
```c#
// ソースプレゼンテーションファイルを読み込むために Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // スライド 1 にサークルタイプのトランジションを適用します
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // スライド 2 にコンブタイプのトランジションを適用します
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // プレゼンテーションをディスクに保存します
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


## **高度なスライド トランジションの追加**
前節ではシンプルなトランジション効果をスライドに適用しました。ここでは、そのシンプルなトランジション効果をさらに高度かつ制御可能にする手順を示します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. Aspose.Slides for .NET が提供するトランジション効果のいずれかを使用して、スライドにスライド トランジション タイプを適用します。  
3. トランジションを「クリックで進む」か、特定の時間経過後、またはその両方で進むように設定できます。  
4. スライド トランジションが「クリックで進む」に設定されている場合、マウスクリック時にのみ次へ進みます。さらに、Advance After Time プロパティが設定されている場合、指定された時間が経過すると自動的に次へ進みます。  
5. 変更されたプレゼンテーションをプレゼンテーション ファイルとして書き出します。  
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // スライド 1 にサークルタイプのトランジションを適用します
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // トランジション時間を 3 秒に設定します
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // スライド 2 にコンブタイプのトランジションを適用します
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // トランジション時間を 5 秒に設定します
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // スライド 3 にズームタイプのトランジションを適用します
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // トランジション時間を 7 秒に設定します
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // プレゼンテーションをディスクに保存します
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


さらに、[AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) プロパティを使用して、スライド トランジションが次のスライドへ移動するように構成されているか、または設定が無効になっているかを確認できます。

以下の C# コードが操作を示しています。  
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // スライドのトランジションを取得します
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Advance After Time 設定が有効かどうかを確認します
        if (slideTransition.AdvanceAfter)
        {
            // Advance After Time の値を出力します
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // AdvancedAfterTime の値が 2 秒より大きい場合、指定時間後のトランジションを無効にします
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```


## **モーフ トランジション**
Aspose.Slides for .NET は現在、[Morph Transition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition) をサポートしています。これは PowerPoint 2019 で導入された新しいモーフ トランジションです。Morph トランジションにより、あるスライドから次のスライドへの滑らかな移動をアニメーション化できます。この記事では概念と Morph トランジションの使用方法を説明します。Morph トランジションを効果的に使用するには、少なくとも 1 つの共通オブジェクトを持つ 2 枚のスライドが必要です。最も簡単な方法はスライドを複製し、2 枚目のスライドでオブジェクトを別の位置に移動することです。

以下のコード スニペットは、プレゼンテーションにテキストを含むスライドのクローンを追加し、2 枚目のスライドに [morph type](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) のトランジションを設定する方法を示します。  
```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **モーフ トランジションのタイプ**
新しい [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype) 列挙体が追加されました。これはさまざまなタイプのモーフ スライド トランジションを表します。

TransitionMorphType 列挙体には 3 つのメンバーがあります。

- **ByObject**: 形状を分割不可能なオブジェクトとして扱い、モーフ トランジションを実行します。  
- **ByWord**: 可能な限り単語単位でテキストを転送しながらモーフ トランジションを実行します。  
- **ByChar**: 可能な限り文字単位でテキストを転送しながらモーフ トランジションを実行します。

以下のコード スニペットは、スライドにモーフ トランジションを設定し、モーフ タイプを変更する方法を示します。  
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **トランジション効果の設定**
Aspose.Slides for .NET は、黒から、左から、右から などのトランジション効果の設定をサポートしています。トランジション効果を設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
- スライドの参照を取得します。  
- トランジション効果を設定します。  
- プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き出します。

以下の例では、トランジション効果を設定しています。  
```c#
// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation("AccessSlides.pptx");

// エフェクトを設定します
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// プレゼンテーションをディスクに保存します
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**スライド トランジションの再生速度を制御できますか？**

はい。トランジションの [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) を [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) 設定（例: slow/medium/fast）で指定できます。

**トランジションにオーディオを添付してループさせることはできますか？**

はい。トランジション用にサウンドを埋め込み、Sound、SoundMode、SoundLoop などの設定や、SoundIsBuiltIn、SoundName といったメタデータで動作を制御できます。

**すべてのスライドに同じトランジションを適用する最速の方法は何ですか？**

各スライドのトランジション設定で目的のトランジション タイプを構成すれば、スライドごとに保存されるため、すべてのスライドに同一タイプを適用するだけで一貫した結果が得られます。

**現在のスライドに設定されているトランジションを確認する方法は？**

スライドの [transition settings](https://reference.aspose.com/slides/net/aspose.slides/baseslide/slideshowtransition/) を調べ、[transition type](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/type/) を取得します。その値が適用されているエフェクトを正確に示します。