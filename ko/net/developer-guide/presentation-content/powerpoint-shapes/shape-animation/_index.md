---
title: .NET에서 프레젠테이션에 모양 애니메이션 적용하기
linktitle: 모양 애니메이션
type: docs
weight: 60
url: /ko/net/shape-animation/
keywords:
- 모양
- 애니메이션
- 효과
- 애니메이션된 모양
- 애니메이션 텍스트
- 애니메이션 추가
- 애니메이션 가져오기
- 애니메이션 추출
- 효과 추가
- 효과 가져오기
- 효과 추출
- 효과 사운드
- 애니메이션 적용
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 모양 애니메이션, 타이밍, 사운드, 애니메이션 후 동작 및 애니메이션 텍스트를 추가, 검사 및 사용자 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for .NET은 슬라이드 애니메이션을 슬라이드 타임라인의 효과로 나타냅니다. 효과에는 대상 모양, 애니메이션 유형 및 하위 유형, 트리거, 타이밍 설정, 그리고 선택적 속성(예: 사운드 또는 애니메이션 후 동작)이 포함됩니다.

타임라인에는 두 가지 종류의 시퀀스가 있습니다:

- **메인 시퀀스**는 슬라이드가 진행될 때 재생됩니다.
- **대화형 시퀀스**는 트리거 모양을 클릭하면 시작됩니다.

텍스트 상자, 그림, 차트, 표 및 기타 슬라이드 개체는 모두 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/)을 구현하므로 대부분의 슬라이드 콘텐츠에 대해 동일한 [ISequence.AddEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/isequence/addeffect/) 메서드를 사용합니다. 사용 가능한 효과는 [EffectType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effecttype/) 열거형에 나열되어 있습니다.

## **모양 애니메이션 추가**

애니메이션을 추가하려면 슬라이드의 메인 시퀀스를 가져와 대상 모양, 효과 유형, 하위 유형 및 트리거와 함께 [ISequence.AddEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/isequence/addeffect/)를 호출합니다. 다른 모양을 클릭할 때 시작되는 효과의 경우, 해당 모양을 트리거로 하는 대화형 시퀀스를 생성합니다.

다음 예제는 두 종류의 애니메이션을 모두 생성하고 결과를 `shape-animations.pptx` 파일로 저장합니다.

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

트리거는 효과가 언제 시작되는지를 제어합니다:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effecttriggertype/)은 메인 시퀀스에서는 클릭을, 대화형 시퀀스에서는 트리거 모양을 클릭할 때까지 대기합니다.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effecttriggertype/)은 이전 효과와 동시에 시작합니다.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effecttriggertype/)은 이전 효과가 끝난 후 시작합니다.

그림, 차트 또는 다른 모양 유형을 애니메이션하려면 `targetShape` 대신 해당 객체를 [ISequence.AddEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/isequence/addeffect/)에 전달합니다. 차트 전용 그룹 옵션은 [Animated Charts](/slides/ko/net/animated-charts/)를 참고하십시오.

## **모양 애니메이션 읽기**

대상 모양을 알고 있는 경우 [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/isequence/geteffectsbyshape/)를 사용합니다. 모든 효과를 확인하려면 메인 시퀀스와 모든 대화형 시퀀스를 열거합니다. 열거를 사용하면 인덱스 `0`에 효과가 있다고 가정하는 오류를 피할 수 있습니다.

다음 예제는 메인 시퀀스와 대화형 효과를 가진 모양을 만든 뒤, 해당 모양을 대상으로 하는 효과를 가져와 슬라이드의 모든 시퀀스를 열거합니다.

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

하나의 모양에 대한 효과만 필요하다면 먼저 이름, 자리표시자 유형 또는 다른 안정적인 속성으로 모양을 식별한 다음 [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/isequence/geteffectsbyshape/)를 호출합니다. 인덱스 `0`에 있는 [IShapeCollection.Item](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/item/)이 항상 원하는 객체라고 가정하지 마십시오.

## **상속된 자리표시자 효과 작업**

일반 슬라이드의 자리표시자는 레이아웃 슬라이드와 마스터 슬라이드의 해당 자리표시자로부터 애니메이션 동작을 상속할 수 있습니다. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/getbaseplaceholder/)는 상위 자리표시자를 반환하며, 상위가 없을 경우 `null`을 반환합니다.

다음 예제 프레젠테이션에서 바닥글은 일반 슬라이드에서는 **Random Bars**, 레이아웃 슬라이드에서는 **Split**, 마스터 슬라이드에서는 **Fly In** 효과를 가지고 있습니다.

![일반 슬라이드의 바닥글 애니메이션 효과](slide-shape-animation.png)

![레이아웃 슬라이드의 바닥글 자리표시자 애니메이션 효과](layout-shape-animation.png)

![마스터 슬라이드의 바닥글 자리표시자 애니메이션 효과](master-shape-animation.png)

다음 예제는 자리표시자 계층 구조를 직접 구축합니다. 마스터 자리표시자, 레이아웃 자리표시자 및 일반 슬라이드의 해당 자리표시자에 효과를 추가하고, 각 호출 전에 [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/getbaseplaceholder/) 결과가 `null`이 아닌지 확인합니다.

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

## **애니메이션 타이밍 변경**

PowerPoint **Timing** 대화상자는 [ITiming](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/) 속성과 매핑됩니다.

![애니메이션 효과에 대한 PowerPoint 타이밍 대화상자](shape-animation.png)

- **Start**는 [ITiming.TriggerType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/triggertype/)과 매핑됩니다.
- **Duration**은 [ITiming.Duration](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/duration/)에 매핑되며, 초 단위입니다.
- **Delay**는 [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/triggerdelaytime/)에 매핑되며, 초 단위입니다.
- **Repeat**는 [ITiming.RepeatCount](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/repeatuntilnextclick/) 또는 [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/repeatuntilendslide/)와 매핑됩니다.
- **Rewind when done playing**은 [ITiming.Rewind](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/rewind/)과 매핑됩니다.

다음 독립 예제는 효과를 추가하고, [ISequence.AddEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/isequence/addeffect/)가 반환한 객체를 통해 타이밍을 변경한 뒤 결과를 저장합니다. 반환된 [IEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/) 참조를 유지하면 불필요한 컬렉션 인덱스 접근을 피할 수 있습니다.

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

반복 모드를 하나만 사용하십시오. 반복 횟수와 “until” 플래그를 동시에 지정하면 뷰어마다 혼란스러운 결과가 나타날 수 있습니다. 반복 모드를 변경할 때는 [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/repeatuntilnextclick/)과 [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/repeatuntilendslide/)를 먼저 설정하고, 그다음에 [ITiming.RepeatCount](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/repeatcount/)를 설정하십시오. 두 플래그 중 하나를 설정하면 활성 반복 모드가 변경됩니다.

## **애니메이션 사운드 추가 및 추출**

애니메이션 효과는 [IEffect.Sound](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/sound/)을 통해 임베드된 오디오를 참조할 수 있습니다. [IEffect.StopPreviousSound](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/stopprevioussound/)은 이전 효과가 시작한 오디오를 정지하도록 지시합니다.

### **효과에 사운드 추가**

다음 예제는 `animation-sound.wav`라는 로컬 오디오 파일이 존재한다고 가정합니다. 두 개의 효과를 만들고 첫 번째 효과의 사운드로 해당 파일을 임베드하며, 두 번째 효과는 사운드를 정지하도록 구성합니다. [ISequence.AddEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/isequence/addeffect/)가 반환한 객체를 사용하므로 시퀀스 인덱스가 필요하지 않습니다.

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

### **임베드된 효과 사운드 추출**

다음 예제는 `presentation-with-animation-sounds.pptx`라는 로컬 프레젠테이션이 존재한다고 가정합니다. 메인 및 대화형 시퀀스를 모두 스캔하고 모든 임베드된 효과 사운드를 `extracted-animation-sounds` 디렉터리에 기록합니다. 확장자는 [IAudio.ContentType](https://reference.aspose.com/slides/ko/net/aspose.slides/iaudio/contenttype/)에서 제공하는 오디오 MIME 유형에 따라 선택됩니다.

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

대용량 오디오 객체의 경우 [IAudio.GetStream](https://reference.aspose.com/slides/ko/net/aspose.slides/iaudio/getstream/)을 사용하여 스트림을 파일에 복사하고, 전체 객체를 바이트 배열로 로드하는 것을 피하십시오.

## **애니메이션 후 동작 설정**

**After animation** 옵션은 효과가 끝난 후 모양에 어떤 일이 발생할지를 제어합니다.

![After animation 설정을 보여주는 PowerPoint 효과 옵션 대화상자](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/afteranimationtype/) 열거형은 모양을 그대로 두거나 색상을 변경하거나, 애니메이션 후 숨기거나, 다음 클릭 시 숨기는 옵션을 지원합니다. 유형이 [AfterAnimationType.Color](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/afteranimationtype/)인 경우 [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/afteranimationcolor/)도 설정해야 합니다.

다음 독립 예제는 효과를 만든 뒤 반환된 효과 객체를 통해 애니메이션 후 동작을 설정하고 결과를 저장합니다.

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

[AfterAnimationType.Color](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/afteranimationtype/) 외의 유형으로 변경하면 애니메이션 후 색상 설정이 지워집니다.

## **텍스트 애니메이션**

텍스트 애니메이션에는 두 가지 관련 제어가 있습니다:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itextanimation/buildtype/)은 단락을 한 번에 나타낼지 단락별로 나타낼지를 제어합니다.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/animatetexttype/)은 텍스트가 한 번에, 단어 단위로, 혹은 글자 단위로 나타날지를 제어합니다. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/delaybetweentextparts/)는 단어 또는 글자 사이의 지연을 설정합니다. 양수 값은 효과 지속 시간의 백분율이며, 음수 값은 초 단위 지연을 나타냅니다.

다음 독립 예제는 텍스트 상자 안의 단어들을 애니메이션합니다. [BuildType.AsOneObject](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/buildtype/)을 사용하면 단락별 빌드를 비활성화하여 단어 설정이 전체 텍스트 프레임에 적용됩니다.

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

단락별로 텍스트 상자를 빌드하려면 [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/buildtype/)(또는 다른 단락 수준)을 설정하십시오. 개별 단락에 자체 효과를 적용하려면 [ISequence.AddEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/isequence/addeffect/)의 [IParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/) 오버로드를 사용합니다. 단락 수준 예제는 [Animated Text](/slides/ko/net/animated-text/)를 참고하십시오.

## **내보내기 및 호환성 참고사항**

- PPT 또는 PPTX로 저장하면 애니메이션 모델이 보존되지만 최종 재생은 프레젠테이션 뷰어에 의해 제어됩니다.
- PDF 및 정적 이미지는 애니메이션을 재생하지 않습니다. 모션을 보여야 할 경우 [HTML5 export](/slides/ko/net/export-to-html5/), 애니메이션 GIF 또는 [video conversion](/slides/ko/net/convert-powerpoint-to-video/)을 사용하십시오.
- HTML5에서는 [Html5Options.AnimateShapes](https://reference.aspose.com/slides/ko/net/aspose.slides.export/html5options/animateshapes/)을 활성화하고, 필요에 따라 [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/html5options/animatetransitions/)도 활성화하십시오.
- 비디오 렌더링은 일반적인 들어오기, 강조, 나가기 및 움직임 경로 효과를 많이 지원하지만 모든 PowerPoint 효과를 지원하는 것은 아닙니다. 현재 [supported animations and effects](/slides/ko/net/convert-powerpoint-to-video/#supported-animations-and-effects)를 확인하고 대상 Aspose.Slides 버전에서 중요한 프레젠테이션을 테스트하십시오.
- 고급 사용자 정의 효과 및 다른 프레젠테이션 형식에서 가져온 효과는 파일에 보존될 수 있지만 PowerPoint, HTML5 또는 비디오에서 다르게 렌더링될 수 있습니다. 효과 이름만을 기준으로 하지 말고 내보낸 결과를 반드시 검증하십시오.

## **FAQ**

**왜 애니메이션은 PowerPoint에서는 보이지만 PDF에서는 보이지 않나요?**

PDF는 정적 형식이므로 애니메이션과 슬라이드 전환이 재생되지 않습니다. 모션을 보존해야 할 경우 HTML5, 애니메이션 GIF 또는 비디오로 내보내십시오.

**왜 비디오에서 효과가 다르게 재생되나요?**

비디오 내보내기는 애니메이션을 실제로 렌더링하므로 원본 PowerPoint 동작을 저장하지 않습니다. 일부 고급 효과는 지원되지 않거나 근사값으로 처리됩니다. 지원되는 효과 표를 검토하고 실제 프레젠테이션을 테스트한 후에 사용하십시오.

**모양을 앞으로 또는 뒤로 이동하면 애니메이션 순서가 바뀌나요?**

아니요. 모양의 z-순서는 겹침을 제어하고, 시퀀스 순서와 트리거가 애니메이션 재생을 제어합니다. 재생 순서를 변경하려면 타임라인 자체를 수정하십시오.