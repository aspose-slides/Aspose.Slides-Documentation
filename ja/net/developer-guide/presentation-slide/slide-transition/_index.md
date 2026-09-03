---
title: .NET でプレゼンテーションのスライド遷移を管理する
linktitle: スライド遷移
type: docs
weight: 90
url: /ja/net/slide-transition/
keywords:
- スライド遷移
- スライド遷移の追加
- スライド遷移の適用
- 高度なスライド遷移
- モーフ遷移
- 遷移タイプ
- 遷移効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してスライド遷移を適用し、自動スライド進行を設定し、Morph などの遷移効果をカスタマイズします。"
---
## **概要**

スライド遷移は、スライドショー中にスライドがどのように表示されるかを制御します。Aspose.Slides for .NET を使用すると、各スライドに遷移効果を選択でき、マウスクリックまたはタイマーによる進行を設定し、効果固有のオプションを調整できます。本記事では C# のサンプルを使って遷移を適用し、正確な遷移時間を設定し、スライドのタイミングを管理し、2 枚のスライド間で Morph 遷移を作成する方法を示します。また、設定を PPTX ファイルに保存する方法も紹介します。

## **スライド遷移の追加**

遷移を適用するには、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスでプレゼンテーションを読み込み、スライドの [SlideShowTransition](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseslide/slideshowtransition/) プロパティにアクセスします。その [Type](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/type/) を [TransitionType](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/transitiontype/) 列挙体の値に設定し、プレゼンテーションを保存します。

以下の例は、最初のスライドに Circle 遷移を、2 番目のスライドに Comb 遷移を適用します。2 枚以上のスライドを含む `input.pptx` ファイルを使用してください。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **高度なスライド遷移の追加**

スライドが画面に表示され続ける時間や、マウスクリックでスライドショーを進めるかどうかを構成できます。以下のプロパティがこの動作を制御します。

- [AdvanceOnClick](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/advanceonclick/) は、マウスクリックで進められるかを指定します。
- [AdvanceAfter](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/advanceafter/) は自動進行を有効にします。
- [AdvanceAfterTime](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/advanceaftertime/) は自動進行までの遅延時間（ミリ秒）を指定します。

クリックとタイマーの両方を有効にすれば、クリックでもタイマーでも次へ進められます。タイマーだけを使用したい場合は、[AdvanceOnClick](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/advanceonclick/) を `false` に設定します。遅延はスライドショーの進行タイミングを制御しますが、視覚的な遷移効果の長さを設定するものではありません。

この例では、最初の 3 枚のスライドに異なる効果を割り当て、3 秒、5 秒、7 秒後に自動進行するように設定します。マウスクリックでもスライドは進められます。3 枚以上のスライドを含む `input.pptx` ファイルを使用してください。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

タイマーが有効かどうかを確認するには、[AdvanceAfter](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/advanceafter/) を読み取ります。遅延が保存されているだけでは、タイマーがアクティブであることを示すわけではありません。

次の例では、上記で保存したファイルを開き、2 秒以上の遅延が設定されているスライドの自動進行を無効にし、クリックでの進行を有効にして設定を保存します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **遷移タイミングの正確な制御**

[Duration](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/slideshowtransition/duration/) を使用して、遷移効果自体の長さ（ミリ秒）を正確に指定できます。スライドの [SlideShowTransition](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseslide/slideshowtransition/) プロパティは、[ISlideShowTransition](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/) を介してこれらの設定を公開します。

| プロパティ | 用途 |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/slideshowtransition/duration/) | 遷移効果そのものの長さ（ミリ秒）を設定します。 |
| [AdvanceAfterTime](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | スライドが自動的に進むまでの遅延（ミリ秒）を設定します。[AdvanceAfter](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/advanceafter/) を有効にするとタイマーが作動します。 |
| [Speed](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/slideshowtransition/speed/) | [TransitionSpeed](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/transitionspeed/) 列挙体から「Slow」「Medium」「Fast」のいずれかの速度カテゴリを選択します。明示的な Duration が指定されていない場合に使用されます。 |

[Duration](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/slideshowtransition/duration/) は遷移効果のみを制御し、スライドが表示され続ける時間は決定しません。自動進行の遅延は別途設定してください。明示的な Duration が設定されていない場合、Aspose.Slides は遷移タイプと [Speed](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/slideshowtransition/speed/) の値から効果の長さを自動的に決定します。

### **すべてのスライドに同じ Duration を適用する**

一定のペースを保つために、すべてのスライドに同じ効果と正確な Duration を適用します。この例では `input.pptx` を読み込み、[TransitionType](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/transitiontype/) から Fade を選択し、各遷移に 750 ミリ秒の Duration を設定します。また自動進行を 5,000 ミリ秒後に有効にし、マウスクリックによる進行は無効にして PPTX として保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // エフェクトの期間とは別に自動進行を設定します。
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **スライドごとに異なる Duration を設定する**

スライドごとに異なる効果時間を使用できます。たとえば、タイトルスライドには短い遷移、セクション紹介スライドには長い遷移を設定します。この例では 1 枚目に 500 ミリ秒、2 枚目に 1,200 ミリ秒の Duration を設定します。2 枚以上のスライドを含む `input.pptx` を使用してください。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **アニメーション出力と遷移を調整する**

[animated GIF](/slides/ja/net/convert-powerpoint-to-animated-gif/)、[HTML5 プレゼンテーション](/slides/ja/net/export-to-html5/)、または [video](/slides/ja/net/convert-powerpoint-to-video/) を作成する場合、エクスポート前に正確な遷移 Duration を設定して意図したテンポに合わせます。たとえばシーン間のフェードに 600 ミリ秒を使用し、各スライドの進行遅延も個別に調整してナレーションやコンテンツの時間を確保します。

GIF や動画では、効果時間に合わせてフレームレートを調整します。600 ミリ秒は 30 fps の場合 18 フレームに相当します。HTML5 ではエクスポート設定でアニメーション遷移を有効にします。使用するエクスポート形式がサポートする効果とタイミングオプションを確認し、プレビューで同期を確認してください。

### **既存の遷移 Duration を読み取る**

遷移を変更する前に [Duration](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/slideshowtransition/duration/) を読み取り、明示的な値が保存されているか確認します。`-1` は明示的な Duration が設定されていないことを意味し、非負の値はミリ秒単位で保存された Duration を示します。未設定の値は再生時間の計算結果ではなく、Aspose.Slides が遷移タイプと [Speed](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/slideshowtransition/speed/) から算出します。遷移タイプを設定すると Duration が初期化されることがあるため、まず元の設定を調べてください。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Morph 遷移**

Morph 遷移は、連続するスライド間でオブジェクトの変更をアニメーション化します。簡単な Morph 効果を作成するには、スライドを複製し、複製スライド上のオブジェクトを移動またはサイズ変更し、2 枚目のスライドに Morph 遷移を適用します。これにより、元の状態と変更後の状態の間で対応するオブジェクトがアニメーションします。

以下の例では、テキスト矩形を含むスライドを作成し、それを複製して矩形の位置とサイズを変更します。続いて 2 枚目のスライドの [TransitionType](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/transitiontype/) 列挙体から Morph を選択します。Morph をサポートするプレゼンテーションビューアで保存ファイルを開くと、スライドショー中に効果が確認できます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Morph 遷移の種類**

[TransitionMorphType](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/transitionmorphtype/) 列挙体は、Morph がコンテンツをどのようにマッチさせてアニメーション化するかを制御します。

- [ByObject](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/transitionmorphtype/) は各シェイプ全体をオブジェクトとして扱います。
- [ByWord](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/transitionmorphtype/) は可能な場合に単語単位でテキストをアニメーション化します。
- [ByChar](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/transitionmorphtype/) は可能な場合に文字単位でテキストをアニメーション化します。

遷移の [Type](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/type/) を Morph に設定した後、[Value](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/value/) から取得できる [IMorphTransition](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/imorphtransition/) インターフェイスの [MorphType](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/imorphtransition/morphtype/) プロパティでマッチングモードを選択します。

この例では、前節で作成したプレゼンテーションを開き、2 枚目のスライドに単語ベースの Morph アニメーションを設定します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **遷移効果の設定**

一部の遷移は方向や黒画面から開始するかどうかなど、追加オプションを提供します。利用できるオプションは選択した遷移の [Type](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/type/) に依存します。まずタイプを設定し、次にその [Value](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/value/) から適切なインターフェイスを使用します。

以下の例は `input.pptx` の最初のスライドに Cut 遷移を適用し、[IOptionalBlackTransition](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/ioptionalblacktransition/) を介して [FromBlack](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) を設定し、黒画面から開始するようにします。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**スライド遷移の再生速度を制御できますか？**

はい。ミリ秒単位で正確な効果時間が必要な場合は [Duration](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/slideshowtransition/duration/) を使用してください。事前定義された [TransitionSpeed](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/transitionspeed/)（Slow、Medium、Fast）のカテゴリで十分で、明示的な Duration を設定しない場合は [Speed](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/slideshowtransition/speed/) を使用します。これらの設定は自動進行遅延とは独立して遷移効果を制御します。

**遷移に音声を添付してループさせることはできますか？**

はい。[Sound](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/sound/) に埋め込み音声を割り当て、[TransitionSoundMode](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/transitionsoundmode/) 列挙体の StartSound を [SoundMode](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/soundmode/) に設定し、[SoundLoop](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/soundloop/) を有効にします。音声は次のサウンドイベントが発生するまでループします。

**すべてのスライドに同じ遷移を適用する最速の方法は？**

プレゼンテーションの [Slides](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/slides/ja/) コレクションをループし、各スライドの遷移 [Type](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/type/) を同じ値に設定します。同じループ内でタイミングや効果オプションも設定すれば、スライド間で動作を統一できます。

**スライドに現在設定されている遷移を確認する方法は？**

スライドの [SlideShowTransition](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseslide/slideshowtransition/) から [Type](https://reference.aspose.com/slides/ja/net/aspose.slides/islideshowtransition/type/) プロパティを読み取ります。返されるのは [TransitionType](https://reference.aspose.com/slides/ja/net/aspose.slides.slideshow/transitiontype/) 列挙体の値です。None が返された場合、遷移効果は設定されていません。