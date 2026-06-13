---
title: .NET에서 프레젠테이션에 도형 애니메이션 적용
linktitle: 도형 애니메이션
type: docs
weight: 60
url: /ko/net/shape-animation/
keywords:
- 도형
- 애니메이션
- 효과
- 애니메이션 도형
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
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 프레젠테이션에서 도형 애니메이션을 만들고 맞춤화하는 방법을 알아보세요. 돋보이세요!"
---
## **소개**

애니메이션은 텍스트, 이미지, 도형 또는 [차트](/slides/ko/net/animated-charts/)에 적용할 수 있는 시각 효과입니다. 프레젠테이션이나 그 구성 요소에 생동감을 부여합니다. 

## **프레젠테이션에서 애니메이션을 사용하는 이유**

애니메이션을 사용하면 

* 정보 흐름을 제어합니다
* 중요한 포인트를 강조합니다
* 청중의 관심이나 참여를 높입니다
* 콘텐츠를 더 쉽게 읽고 이해하거나 처리할 수 있게 합니다
* 청중이 프레젠테이션의 중요한 부분에 주목하도록 유도합니다

PowerPoint는 **입장**, **퇴장**, **강조**, 그리고 **동작 경로** 범주에 걸쳐 애니메이션 및 애니메이션 효과에 대한 다양한 옵션과 도구를 제공합니다. 

## **Aspose.Slides의 애니메이션**

* Aspose.Slides는 애니메이션 작업에 필요한 클래스와 형식을 [Aspose.Slides.Animation](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/) 네임스페이스에 제공합니다,
* Aspose.Slides는 [EffectType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effecttype) 열거형에 **150개 이상**의 애니메이션 효과를 제공합니다. 이러한 효과는 기본적으로 PowerPoint에서 사용되는 효과와 동일하거나 동등합니다.

## **텍스트 상자에 애니메이션 적용**

Aspose.Slides for .NET을 사용하면 도형의 텍스트에 애니메이션을 적용할 수 있습니다. 

1. [Presentation](http://www.aspose.com/api/net/slides/ko/aspose.slides/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape)를 추가합니다. 
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/properties/textframe)에 텍스트를 추가합니다.
5. 메인 효과 시퀀스를 가져옵니다.
6. [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape)에 애니메이션 효과를 추가합니다.
7. [TextAnimation.BuildType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/textanimation/properties/buildtype) 속성을 [BuildType Enumeration](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/buildtype)에서 가져온 값으로 설정합니다.
8. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.

이 C# 코드는 `Fade` 효과를 AutoShape에 적용하고 텍스트 애니메이션을 *By 1st Level Paragraphs* 값으로 설정하는 방법을 보여줍니다:

```c#
 // 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // 텍스트가 있는 새로운 AutoShape를 추가합니다
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // 슬라이드의 메인 시퀀스를 가져옵니다.
    ISequence sequence = sld.Timeline.MainSequence;

    // 도형에 Fade 애니메이션 효과를 추가합니다
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 도형 텍스트를 1단계 단락별로 애니메이션합니다
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // PPTX 파일을 디스크에 저장합니다
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

텍스트에 애니메이션을 적용하는 것 외에도 단일 [Paragraph](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph)에 애니메이션을 적용할 수 있습니다. [**Animated Text**](/slides/ko/net/animated-text/)를 확인하세요.

{{% /alert %}} 

## **PictureFrame에 애니메이션 적용**

1. [Presentation](http://www.aspose.com/api/net/slides/ko/aspose.slides/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. 슬라이드에 [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe)을 추가하거나 가져옵니다. 
5. 메인 효과 시퀀스를 가져옵니다.
6. [PictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe)에 애니메이션 효과를 추가합니다.
8. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.

이 C# 코드는 `Fly` 효과를 picture frame에 적용하는 방법을 보여줍니다:

```c#
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
using (Presentation pres = new Presentation())
{
    // 프레젠테이션 이미지 컬렉션에 추가할 이미지를 로드합니다
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 슬라이드에 그림 프레임을 추가합니다
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // 슬라이드의 메인 시퀀스를 가져옵니다.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // picture frame에 Fly from Left 애니메이션 효과를 추가합니다
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX 파일을 디스크에 저장합니다
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **도형에 애니메이션 적용**

1. [Presentation](http://www.aspose.com/api/net/slides/ko/aspose.slides/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape)를 추가합니다. 
4. `Bevel` [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape) (이 개체를 클릭하면 애니메이션이 재생됩니다)를 추가합니다.
5. bevel 도형에 대한 효과 시퀀스를 생성합니다.
6. 사용자 정의 `UserPath`를 생성합니다.
7. `UserPath`로 이동하기 위한 명령을 추가합니다.
8. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.

이 C# 코드는 `PathFootball` (경로 풋볼) 효과를 도형에 적용하는 방법을 보여줍니다:

```c#
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // 기존 도형에 대해 처음부터 PathFootball 효과를 생성합니다.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // PathFootBall 애니메이션 효과를 추가합니다.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 일종의 "버튼"을 생성합니다.
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // 버튼에 대한 효과 시퀀스를 생성합니다.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // 사용자 정의 경로를 생성합니다. 객체는 버튼이 클릭된 후에만 이동합니다.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // 생성된 경로가 비어 있으므로 이동 명령을 추가합니다.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // PPTX 파일을 디스크에 저장합니다
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **도형에 적용된 애니메이션 효과 가져오기**

다음 예제에서는 [ISequence](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/isequence/) 인터페이스의 `GetEffectsByShape` 메서드를 사용하여 도형에 적용된 모든 애니메이션 효과를 가져오는 방법을 보여줍니다.

**예제 1: 일반 슬라이드에서 도형에 적용된 애니메이션 효과 가져오기**

이전에, PowerPoint 프레젠테이션에 도형에 애니메이션 효과를 추가하는 방법을 배웠습니다. 다음 샘플 코드는 프레젠테이션 `AnimExample_out.pptx`의 첫 번째 일반 슬라이드에 있는 첫 번째 도형에 적용된 효과를 가져오는 방법을 보여줍니다.

```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // 슬라이드의 메인 애니메이션 시퀀스를 가져옵니다.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // 첫 번째 슬라이드의 첫 번째 도형을 가져옵니다.
    IShape shape = firstSlide.Shapes[0];

    // 도형에 적용된 애니메이션 효과를 가져옵니다.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**예제 2: 자리 표시자에서 상속된 효과를 포함한 모든 애니메이션 효과 가져오기**

일반 슬라이드의 도형에 레이아웃 슬라이드 및/또는 마스터 슬라이드에 있는 자리 표시자가 있고, 해당 자리 표시자에 애니메이션 효과가 추가된 경우, 슬라이드 쇼 동안 도형의 모든 효과가 재생되며, 여기에는 자리 표시자로부터 상속된 효과도 포함됩니다.

예를 들어, `sample.pptx`라는 PowerPoint 프레젠테이션 파일에 하나의 슬라이드가 있으며, 해당 슬라이드에는 텍스트가 "Made with Aspose.Slides"인 푸터 도형만 포함되어 있고, **Random Bars** 효과가 도형에 적용되어 있다고 가정해 보겠습니다.

![슬라이드 도형 애니메이션 효과](slide-shape-animation.png)

또한 레이아웃 슬라이드의 푸터 자리 표시자에 **Split** 효과가 적용되었다고 가정합니다.

![레이아웃 도형 애니메이션 효과](layout-shape-animation.png)

마지막으로 마스터 슬라이드의 푸터 자리 표시자에 **Fly In** 효과가 적용되었습니다.

![마스터 도형 애니메이션 효과](master-shape-animation.png)

다음 샘플 코드는 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/) 인터페이스의 `GetBasePlaceholder` 메서드를 사용하여 도형 자리 표시자에 접근하고 레이아웃 및 마스터 슬라이드에 위치한 자리 표시자로부터 상속된 효과를 포함한 푸터 도형에 적용된 애니메이션 효과를 가져오는 방법을 보여줍니다.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 일반 슬라이드에 있는 도형의 애니메이션 효과를 가져옵니다.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // 레이아웃 슬라이드에 있는 자리 표시자의 애니메이션 효과를 가져옵니다.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // 마스터 슬라이드에 있는 자리 표시자의 애니메이션 효과를 가져옵니다.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```
```cs
static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **애니메이션 효과 타이밍 속성 변경**

Aspose.Slides for .NET을 사용하면 애니메이션 효과의 타이밍 속성을 변경할 수 있습니다.

다음은 Microsoft PowerPoint의 애니메이션 타이밍 창 및 확장 메뉴입니다:

![example1_image](shape-animation.png)

PowerPoint 타이밍 **Start** 드롭다운 목록은 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/properties/triggertype) 속성과 일치합니다. 
PowerPoint 타이밍 **Duration**는 [Effect.Timing.Duration](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/properties/duration) 속성과 일치합니다. 애니메이션 지속시간(초)은 애니메이션이 한 사이클을 완료하는 총 시간입니다. 
PowerPoint 타이밍 **Delay**는 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/properties/triggerdelaytime) 속성과 일치합니다. 
PowerPoint 타이밍 **Repeat** 드롭다운 목록은 다음 속성과 일치합니다: 
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/repeatcount) 속성은 효과가 반복되는 *횟수*를 정의합니다;
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/repeatuntilendslide) 플래그는 효과가 슬라이드 끝까지 반복되는지 여부를 지정합니다;
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/repeatuntilnextclick) 플래그는 효과가 다음 클릭까지 반복되는지 여부를 지정합니다.
PowerPoint 타이밍 **Rewind when done playing** 체크박스는 [Effect.Timing.Rewind](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/rewind/) 속성과 일치합니다. 

Effect 타이밍 속성을 변경하는 방법은 다음과 같습니다:

1. [적용](#apply-animation-to-shape)하거나 애니메이션 효과를 가져옵니다.
2. 필요한 [Effect.Timing](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effect/properties/timing) 속성에 대한 새 값을 설정합니다. 
3. 수정된 PPTX 파일을 저장합니다.

```c#
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // 슬라이드의 메인 시퀀스를 가져옵니다.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 메인 시퀀스의 첫 번째 효과를 가져옵니다.
    IEffect effect = sequence[0];

    // 효과의 TriggerType을 클릭 시 시작하도록 변경합니다
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // 효과의 Duration을 변경합니다
    effect.Timing.Duration = 3f;

    // 효과의 TriggerDelayTime을 변경합니다
    effect.Timing.TriggerDelayTime = 0.5f;

    // 효과 Repeat 값이 "none"인 경우
    if (effect.Timing.RepeatCount == 1f)
    {
        // 효과 Repeat을 "다음 클릭까지"로 변경합니다
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // 효과 Repeat을 "슬라이드 끝까지"로 변경합니다
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // 효과 Rewind를 켭니다
        effect.Timing.Rewind = true;
    
    // PPTX 파일을 디스크에 저장합니다
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **애니메이션 효과 사운드**

Aspose.Slides는 애니메이션 효과에 사운드를 사용할 수 있도록 다음 속성을 제공합니다: 
- [IEffect.Sound](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effect/stopprevioussound/) 

### **애니메이션 효과 사운드 추가**

이 C# 코드는 애니메이션 효과 사운드를 추가하고 다음 효과가 시작될 때 사운드를 중지하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// 프레젠테이션 오디오 컬렉션에 오디오를 추가합니다
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// 슬라이드의 메인 시퀀스를 가져옵니다.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// 메인 시퀀스의 첫 번째 효과를 가져옵니다.
	IEffect firstEffect = sequence[0];

	// 효과에 "소리 없음"인지 확인합니다
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// 첫 번째 효과에 소리를 추가합니다
		firstEffect.Sound = effectSound;
	}

	// 슬라이드의 첫 번째 인터랙티브 시퀀스를 가져옵니다.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// 효과의 "이전 소리 중지" 플래그를 설정합니다
	interactiveSequence[0].StopPreviousSound = true;

	// PPTX 파일을 디스크에 저장합니다
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **애니메이션 효과 사운드 추출**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
3. 메인 효과 시퀀스를 가져옵니다. 
4. 각 애니메이션 효과에 내장된 [Sound](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effect/sound/)을 추출합니다. 

이 C# 코드는 애니메이션 효과에 내장된 사운드를 추출하는 방법을 보여줍니다:

```c#
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 슬라이드의 메인 시퀀스를 가져옵니다.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // 효과 사운드를 바이트 배열로 추출합니다
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **애니메이션 이후**

Aspose.Slides for .NET을 사용하면 애니메이션 효과의 After animation 속성을 변경할 수 있습니다.

다음은 Microsoft PowerPoint의 애니메이션 효과 창 및 확장 메뉴입니다:

![example1_image](shape-after-animation.png)

PowerPoint 효과 **After animation** 드롭다운 목록은 다음 속성과 일치합니다: 

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/afteranimationtype/) 속성은 After animation 유형을 설명합니다 :
  * PowerPoint **More Colors**는 [AfterAnimationType.Color](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/afteranimationtype/) 유형과 일치합니다;
  * PowerPoint **Don't Dim** 항목은 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/afteranimationtype/) 유형과 일치합니다 (기본 after animation 유형);
  * PowerPoint **Hide After Animation** 항목은 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/afteranimationtype/) 유형과 일치합니다;
  * PowerPoint **Hide on Next Mouse Click** 항목은 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/afteranimationtype/) 유형과 일치합니다;
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/afteranimationcolor/) 속성은 After animation 색상 형식을 정의합니다. 이 속성은 [AfterAnimationType.Color](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/afteranimationtype/) 유형과 함께 작동합니다. 유형을 다른 것으로 변경하면 After animation 색상이 지워집니다.

이 C# 코드는 after animation 효과를 변경하는 방법을 보여줍니다:

```c#
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 메인 시퀀스의 첫 번째 효과를 가져옵니다.
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // After animation 타입을 Color로 변경합니다.
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // After animation 색조 색상을 설정합니다.
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // PPTX 파일을 디스크에 저장합니다.
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **텍스트 애니메이션**

Aspose.Slides는 애니메이션 효과의 *Animate text* 블록을 다룰 수 있도록 다음 속성을 제공합니다: 

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/animatetexttype/) 속성은 효과의 텍스트 애니메이션 유형을 설명합니다. 도형 텍스트는 다음과 같이 애니메이션될 수 있습니다:
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/animatetexttype/) 타입)
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/animatetexttype/) 타입)
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/animatetexttype/) 타입)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/delaybetweentextparts/)는 애니메이션된 텍스트 부분(단어 또는 글자) 사이의 지연을 설정합니다. 양수 값은 효과 지속시간의 백분율을 지정하고, 음수 값은 초 단위 지연을 지정합니다.

Effect Animate text 속성을 변경하는 방법은 다음과 같습니다:

1. [적용](#apply-animation-to-shape)하거나 애니메이션 효과를 가져옵니다.
2. [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itextanimation/buildtype/) 속성을 [BuildType.AsOneObject](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/buildtype/) 값으로 설정하여 *By Paragraphs* 애니메이션 모드를 끕니다.
3. [IEffect.AnimateTextType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/animatetexttype/) 및 [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 속성에 새 값을 설정합니다.
4. 수정된 PPTX 파일을 저장합니다.

```c#
// 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 메인 시퀀스의 첫 번째 효과를 가져옵니다.
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // 효과 텍스트 애니메이션 유형을 "As One Object" 로 변경합니다.
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // 효과 애니메이트 텍스트 유형을 "By word" 로 변경합니다.
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // 단어 사이의 지연을 효과 지속시간의 20%로 설정합니다.
    firstEffect.DelayBetweenTextParts = 20f;

    // PPTX 파일을 디스크에 저장합니다.
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**프레젠테이션을 웹에 게시할 때 애니메이션이 보존되도록 하려면 어떻게 해야 하나요?**

[Export to HTML5](/slides/ko/net/export-to-html5/)를 사용하고 [옵션](https://reference.aspose.com/slides/ko/net/aspose.slides.export/html5options/) 중에서 [shape](https://reference.aspose.com/slides/ko/net/aspose.slides.export/html5options/animateshapes/) 및 [transition](https://reference.aspose.com/slides/ko/net/aspose.slides.export/html5options/animatetransitions/) 애니메이션을 활성화합니다. 일반 HTML은 슬라이드 애니메이션을 재생하지 않지만 HTML5는 재생합니다.

**도형의 z-순서(레이어 순서)를 변경하면 애니메이션에 어떤 영향을 미칩니까?**

애니메이션과 그리기 순서는 독립적입니다: 효과는 나타나고 사라지는 타이밍과 유형을 제어하고, [z-order](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/zorderposition/)는 어떤 것이 무엇을 가리는지를 결정합니다. 두 요소의 조합으로 최종 결과가 정의됩니다. (이것은 일반적인 PowerPoint 동작이며, Aspose.Slides의 효과와 도형 모델도 동일한 논리를 따릅니다.)

**특정 효과를 비디오로 변환할 때 제한 사항이 있나요?**

일반적으로 [애니메이션은 지원됩니다](/slides/ko/net/convert-powerpoint-to-video/), 하지만 드물게 일부 효과가 다르게 렌더링될 수 있습니다. 사용하려는 효과와 라이브러리 버전으로 테스트하는 것이 권장됩니다.