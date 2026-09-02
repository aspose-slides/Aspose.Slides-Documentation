---
title: .NET でプレゼンテーションにシェイプ アニメーションを適用する
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/net/shape-animation/
keywords:
- シェイプ
- アニメーション
- エフェクト
- アニメーション シェイプ
- アニメーション テキスト
- アニメーションの追加
- アニメーションの取得
- アニメーションの抽出
- エフェクトの追加
- エフェクトの取得
- エフェクトの抽出
- エフェクト サウンド
- アニメーションの適用
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、シェイプ アニメーション、タイミング、サウンド、アフター アニメーションの動作、アニメーション テキストの追加、検査、カスタマイズ方法を学びます。"
---
## **概要**

Aspose.Slides for .NET はスライド アニメーションをスライド タイムライン上のエフェクトとして表現します。エフェクトには対象シェイプ、アニメーション タイプとサブタイプ、トリガー、タイミング設定、そしてサウンドやアフター アニメーション動作などのオプション プロパティがあります。

タイムラインには次の 2 種類のシーケンスがあります。

- **メイン シーケンス** はスライドが進むと再生されます。  
- **インタラクティブ シーケンス** はトリガー シェイプがクリックされたときに開始します。

テキスト ボックス、画像、チャート、表などのスライド オブジェクトはすべて [IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) を実装しているため、ほとんどのスライド コンテンツに対して同じ [ISequence.AddEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/isequence/addeffect/) メソッドを使用します。利用可能なエフェクトは [EffectType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/effecttype/) 列挙体に一覧化されています。

## **シェイプ アニメーションの追加**

アニメーションを追加するには、スライドのメイン シーケンスを取得し、対象シェイプ、エフェクト タイプ、サブタイプ、トリガーを指定して [ISequence.AddEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/isequence/addeffect/) を呼び出します。他のシェイプをクリックしたときに開始するエフェクトを作成する場合は、対象シェイプをトリガーとするインタラクティブ シーケンスを作成します。

以下の例は 2 種類のアニメーションを作成し、結果を `shape-animations.pptx` に保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

トリガーはエフェクトの開始タイミングを制御します。

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/effecttriggertype/) はメイン シーケンスではクリック待ち、インタラクティブ シーケンスではトリガー シェイプのクリック待ちです。  
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/effecttriggertype/) は直前のエフェクトと同時に開始します。  
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/effecttriggertype/) は直前のエフェクトが終了したときに開始します。

画像、チャート、その他のシェイプをアニメーション化する場合は、`targetShape` の代わりに対象オブジェクトを [ISequence.AddEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/isequence/addeffect/) に渡します。チャート固有のグルーピング オプションについては、[Animated Charts](/slides/ja/net/animated-charts/) を参照してください。

## **シェイプ アニメーションの取得**

対象シェイプが分かっている場合は、[ISequence.GetEffectsByShape](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/isequence/geteffectsbyshape/) を使用します。すべてのエフェクトを調べるには、メイン シーケンスとすべてのインタラクティブ シーケンスを列挙します。列挙時にインデックス `0` にエフェクトが必ず存在するという前提は避けてください。

以下の例はメインシーケンスとインタラクティブ シーケンスを持つシェイプを作成し、そのシェイプを対象とするエフェクトを取得したうえで、スライド上のすべてのシーケンスを列挙します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

1 つのシェイプだけのエフェクトが必要な場合は、名前、プレースホルダー タイプ、またはその他の安定したプロパティでシェイプを特定してから、[ISequence.GetEffectsByShape](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/isequence/geteffectsbyshape/) を呼び出します。インデックス `0` の [IShapeCollection.Item](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/item/) が常に目的のオブジェクトであるとは限らないことに注意してください。

## **継承プレースホルダー エフェクトの操作**

通常スライド上のプレースホルダーは、レイアウト スライドやマスタースライド上の対応するプレースホルダーからアニメーション 動作を継承できます。[IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/getbaseplaceholder/) は親プレースホルダーを返します。親が存在しない場合は `null` が返ります。

以下の例のプレゼンテーションでは、フッターが通常スライドで **Random Bars**、レイアウト スライドで **Split**、マスタースライドで **Fly In** というアニメーションを持っています。

![通常スライド上のフッター アニメーション効果](slide-shape-animation.png)

![レイアウト スライド上のフッター プレースホルダー アニメーション効果](layout-shape-animation.png)

![マスタースライド上のフッター プレースホルダー アニメーション効果](master-shape-animation.png)

次の例はプレースホルダー階層自体を構築します。マスタープレースホルダー、レイアウトプレースホルダー、および対応する通常スライド上のプレースホルダーにエフェクトを追加します。[IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/getbaseplaceholder/) の呼び出し結果が `null` でないことを確認してからシェイプを使用します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **アニメーション タイミングの変更**

PowerPoint の **タイミング** ダイアログは [ITiming](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/) のプロパティに対応しています。

![アニメーション エフェクトの PowerPoint タイミング ダイアログ](shape-animation.png)

- **開始** は [ITiming.TriggerType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/triggertype/) にマップされます。  
- **期間** は秒単位で [ITiming.Duration](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/duration/) にマップされます。  
- **遅延** は秒単位で [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/triggerdelaytime/) にマップされます。  
- **繰り返し** は [ITiming.RepeatCount](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/repeatcount/)、[ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/repeatuntilnextclick/) または [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/repeatuntilendslide/) のいずれかにマップされます。  
- **再生が完了したら巻き戻す** は [ITiming.Rewind](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/rewind/) にマップされます。

この独立した例はエフェクトを追加し、[ISequence.AddEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/isequence/addeffect/) が返すオブジェクトでタイミングを変更してから結果を保存します。返された [IEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/) 参照を保持することで不要なコレクション インデックス取得を回避できます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

1 つの繰り返しモードだけを意図的に使用してください。繰り返し回数と「until」フラグを組み合わせると、ビューアーによっては混乱を招く結果になることがあります。繰り返しモードを変更する際は、[ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/repeatuntilnextclick/) および [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/repeatuntilendslide/) を先に設定し、最後に [ITiming.RepeatCount](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itiming/repeatcount/) を設定してください。フラグを設定するとアクティブな繰り返しモードも変更されます。

## **アニメーション サウンドの追加と抽出**

エフェクトは [IEffect.Sound](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/sound/) を介して埋め込みオーディオを参照できます。[IEffect.StopPreviousSound](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/stopprevioussound/) は、以前のエフェクトで開始されたサウンドを停止するよう指示します。

### **エフェクトにサウンドを追加する**

以下の例はローカルの audio ファイル `animation-sound.wav` を想定しています。2 つのエフェクトを作成し、最初のエフェクトにサウンドとして埋め込み、2 番目のエフェクトでサウンドを停止するよう構成します。シーケンス インデックスは不要で、[ISequence.AddEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/isequence/addeffect/) が返すオブジェクトを使用します。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **埋め込みエフェクト サウンドの抽出**

以下の例はローカルのプレゼンテーション `presentation-with-animation-sounds.pptx` を想定しています。メイン シーケンスとインタラクティブ シーケンスの両方を走査し、埋め込まれたすべてのエフェクトサウンドを `extracted-animation-sounds` ディレクトリに書き出します。拡張子は [IAudio.ContentType](https://reference.aspose.com/slides/ja/net/aspose.slides/iaudio/contenttype/) が示すオーディオ MIME タイプから選択されます。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

大容量のオーディオ オブジェクトの場合は、[IAudio.GetStream](https://reference.aspose.com/slides/ja/net/aspose.slides/iaudio/getstream/) を使用してストリームをファイルにコピーし、全体をバイト配列としてロードしないようにしてください。

## **アフター アニメーション 動作の設定**

**After animation** オプションはエフェクトが終了した後にシェイプがどうなるかを制御します。

![PowerPoint エフェクト オプション ダイアログ (After animation 設定)](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/afteranimationtype/) 列挙体は、シェイプをそのまま残す、色を変える、アニメーション後に非表示にする、次のクリックで非表示にする、のいずれかをサポートします。タイプが [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/afteranimationtype/) の場合は、[IEffect.AfterAnimationColor](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/afteranimationcolor/) も設定してください。

この独立した例はエフェクトを作成し、返されたエフェクトオブジェクトでアフター アニメーション 動作を設定したうえで結果を保存します。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/afteranimationtype/) 以外のタイプに変更すると、アフター アニメーションの色設定はクリアされます。

## **テキストのアニメーション**

テキスト アニメーションには次の 2 つの関連設定があります。

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/itextanimation/buildtype/) は段落単位で表示するか、全体として表示するかを制御します。  
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/animatetexttype/) はテキストを一度にすべて、単語単位、または文字単位で表示するかを制御します。 [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/ieffect/delaybetweentextparts/) は単語または文字間の遅延を設定します。正の値はエフェクト期間のパーセンテージ、負の値は秒単位の遅延です。

以下の独立した例はテキスト ボックス内の単語を順にアニメーション化します。[BuildType.AsOneObject](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/buildtype/) を指定すると段落単位のビルドが無効になり、単語設定がテキスト フレーム全体に適用されます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

段落単位でテキスト ボックスをビルドしたい場合は、[BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/buildtype/)（または他の段落レベル）を指定してください。単一の段落に個別のエフェクトを適用するには、[ISequence.AddEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/isequence/addeffect/) のオーバーロードで [IParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/) を受け取るものを使用します。段落レベルの例は [Animated Text](/slides/ja/net/animated-text/) を参照してください。

## **エクスポートと互換性に関する注意事項**

- PPT または PPTX への保存はアニメーション モデルを保持しますが、最終的な再生はプレゼンテーション ビューアーが制御します。  
- PDF や静止画像はアニメーションを再生しません。モーションを保持する必要がある場合は、[HTML5 エクスポート](/slides/ja/net/export-to-html5/)、アニメーション GIF、または [ビデオ変換](/slides/ja/net/convert-powerpoint-to-video/) を使用してください。  
- HTML5 でアニメーション化されたシェイプを有効にするには、[Html5Options.AnimateShapes](https://reference.aspose.com/slides/ja/net/aspose.slides.export/html5options/animateshapes/) を設定し、必要に応じて [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/html5options/animatetransitions/) も有効にします。  
- ビデオレンダリングは多くの標準的な「入り」「強調」「抜け」「モーション パス」エフェクトをサポートしますが、すべての PowerPoint エフェクトがサポートされているわけではありません。現在の [サポートされているアニメーションとエフェクト](/slides/ja/net/convert-powerpoint-to-video/#supported-animations-and-effects) を確認し、対象の Aspose.Slides バージョンで重要なプレゼンテーションをテストしてください。  
- カスタム エフェクトや他のプレゼンテーション形式からインポートされたエフェクトは、ファイル内に保持されるものの、PowerPoint、HTML5、またはビデオでの描画が異なる場合があります。効果名だけに頼らず、エクスポート結果を必ず検証してください。

## **FAQ**

**PowerPoint では表示されるアニメーションが PDF では表示されないのはなぜですか？**

PDF は静的形式のため、アニメーションやスライド遷移は再生されません。モーションを保持したい場合は HTML5、アニメーション GIF、またはビデオにエクスポートしてください。

**ビデオでエフェクトの再生が異なるのはなぜですか？**

ビデオエクスポートは元の PowerPoint 動作を保存するのではなく、アニメーションをレンダリングします。高度なエフェクトの一部は未サポートまたは近似されます。サポート対象エフェクト表を確認し、実運用前に実際のプレゼンテーションでテストしてください。

**シェイプを前面または背面に移動するとアニメーション順序が変わりますか？**

変わりません。シェイプの Z オーダーは重なり順を制御し、シーケンス順序とトリガーがアニメーション再生順序を制御します。再生順序を変えたい場合はタイムラインを調整してください。