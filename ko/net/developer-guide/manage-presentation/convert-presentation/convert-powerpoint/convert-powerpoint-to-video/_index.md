---
title: ".NET에서 PowerPoint 프레젠테이션을 비디오로 변환하기"
linktitle: "PowerPoint를 비디오로"
type: docs
weight: 130
url: /ko/net/convert-powerpoint-to-video/
keywords:
- "PowerPoint 변환"
- "프레젠테이션 변환"
- "PPT 변환"
- "PPTX 변환"
- "PowerPoint를 비디오로"
- "프레젠테이션을 비디오로"
- "PPT를 비디오로"
- "PPTX를 비디오로"
- "PowerPoint를 MP4로"
- "프레젠테이션을 MP4로"
- "PPT를 MP4로"
- "PPTX를 MP4로"
- "PPT를 MP4로 저장"
- "PPTX를 MP4로 저장"
- "PPT를 MP4로 내보내기"
- "PPTX를 MP4로 내보내기"
- "비디오 변환"
- "파워포인트"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET에서 PowerPoint 프레젠테이션을 비디오로 변환하는 방법을 배웁니다. 워크플로우를 간소화하기 위한 C# 샘플 코드와 자동화 기술을 확인하세요."
---
## **소개**

PowerPoint 또는 OpenDocument 프레젠테이션을 비디오로 변환하면 다음과 같은 이점을 얻을 수 있습니다:

**접근성 향상:** 모든 기기에 기본적으로 비디오 플레이어가 탑재되어 있어 전통적인 프레젠테이션 애플리케이션보다 사용자가 비디오를 열거나 재생하기가 더 쉽습니다.

**도달 범위 확대:** 비디오는 더 많은 청중에게 다가가고 정보를 더 매력적인 형식으로 제공할 수 있게 합니다. 설문조사와 통계에 따르면 사람들은 다른 형태보다 비디오 콘텐츠를 시청하고 소비하는 것을 선호하여 메시지의 효과가 높아집니다.

{{% alert color="primary" %}} 

다음의 [**PowerPoint to Video 온라인 변환기**](https://products.aspose.app/slides/ko/video)를 확인해 보세요. 여기에서 설명한 프로세스를 실시간으로 효과적으로 구현하고 있습니다.

{{% /alert %}} 

Aspose.Slides for .NET에서는 프레젠테이션을 비디오로 변환하는 기능을 구현했습니다.

* Aspose.Slides for .NET를 사용하여 지정된 프레임 속도(FPS)로 프레젠테이션 슬라이드에서 프레임을 생성합니다.
* 그런 다음 ffmpeg와 같은 타사 유틸리티를 사용하여 이러한 프레임을 비디오로 컴파일합니다.

## **PowerPoint 프레젠테이션을 비디오로 변환하기**

1. `dotnet add package` 명령을 사용하여 프로젝트에 Aspose.Slides와 FFMpegCore 라이브러리를 추가합니다:
   * run `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * run `dotnet add package FFMpegCore --version 4.8.0`
2. ffmpeg를 [here](https://ffmpeg.org/download.html)에서 다운로드합니다.
3. FFMpegCore는 다운로드한 ffmpeg의 경로를 지정해야 합니다(예: "C:\tools\ffmpeg"에 추출됨):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. PowerPoint-비디오 변환 코드를 실행합니다.

이 C# 코드는 모양과 두 개의 애니메이션 효과가 포함된 프레젠테이션을 비디오로 변환하는 방법을 보여줍니다:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // 추출한 C:\tools\ffmpeg에 있는 FFmpeg 바이너리를 사용합니다.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 웃는 얼굴 모양을 추가하고 애니메이션을 적용합니다.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // ffmpeg 바이너리 폴더를 설정합니다. 이 페이지를 참고하세요: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // 프레임을 webm 비디오로 변환합니다.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **비디오 효과**

Aspose.Slides for .NET를 사용하여 PowerPoint 프레젠테이션을 비디오로 변환할 때 다양한 비디오 효과를 적용하여 출력물의 시각적 품질을 향상시킬 수 있습니다. 이러한 효과는 부드러운 전환, 애니메이션 및 기타 시각 요소를 추가하여 최종 비디오에서 슬라이드의 모습을 제어할 수 있게 합니다. 이 섹션에서는 사용 가능한 비디오 효과 옵션을 설명하고 적용 방법을 보여줍니다.

{{% alert color="primary" %}} 

참조:
- [Enhancing PowerPoint Presentations with Animations in C#](https://docs.aspose.com/slides/ko/net/powerpoint-animation/)
- [Shape Animation](https://docs.aspose.com/slides/ko/net/shape-animation/)
- [Apply Shape Effects in PowerPoint Using C#](https://docs.aspose.com/slides/ko/net/shape-effect/)

{{% /alert %}} 

애니메이션과 전환은 슬라이드쇼를 더 매력적이고 흥미롭게 만들며, 비디오에도 동일하게 적용됩니다. 이전 프레젠테이션 코드에 또 다른 슬라이드와 전환을 추가해 보겠습니다:

```c#
// 웃는 모양을 추가하고 애니메이션을 적용합니다.
// ...

// 새 슬라이드를 추가하고 애니메이션 전환을 적용합니다.
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides는 텍스트 애니메이션도 지원합니다. 이 예제에서는 개체의 단락을 순차적으로 나타나도록 애니메이션을 적용하며, 각 단락 사이에 1초 지연을 둡니다:

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 텍스트와 애니메이션을 추가합니다.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // ffmpeg 바이너리 폴더를 설정합니다. 이 페이지를 참고하세요: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // 프레임을 webm 비디오로 변환합니다.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **비디오 변환 클래스**

PowerPoint를 비디오로 변환하는 작업을 수행하기 위해 Aspose.Slides for .NET는 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/net/aspose.slides.export/presentationanimationsgenerator/) 및 [PresentationPlayer](https://reference.aspose.com/slides/ko/net/aspose.slides.export/presentationplayer/) 클래스를 제공합니다.

`PresentationAnimationsGenerator`는 생성자를 통해 비디오의 프레임 크기(나중에 생성될)와 FPS(초당 프레임) 값을 지정할 수 있습니다. 프레젠테이션 인스턴스를 전달하면 해당 `Presentation.SlideSize`가 사용되며, [PresentationPlayer](https://reference.aspose.com/slides/ko/net/aspose.slides.export/presentationplayer/)가 사용할 애니메이션을 생성합니다.

애니메이션이 생성될 때마다 각 후속 애니메이션에 대해 `NewAnimation` 이벤트가 트리거되며, 여기에는 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ipresentationanimationplayer/) 매개변수가 포함됩니다. 이 클래스는 개별 애니메이션에 대한 플레이어를 나타냅니다.

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ipresentationanimationplayer/)를 사용하려면 전체 애니메이션 길이를 제공하는 [Duration](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ipresentationanimationplayer/duration/) 속성과 [SetTimePosition](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) 메서드를 활용합니다. 각 애니메이션 위치는 *0 to duration* 범위 내에서 설정되며, `GetFrame` 메서드는 해당 시점의 애니메이션 상태를 나타내는 Bitmap을 반환합니다.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 웃는 모양을 추가하고 애니메이션을 적용합니다.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);          // 초기 애니메이션 상태.
            Bitmap bitmap = animationPlayer.GetFrame();  // 초기 애니메이션 상태 비트맵.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // 애니메이션의 최종 상태.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // 애니메이션의 마지막 프레임.
            lastBitmap.Save("last.png");
        };
    }
}
```

프레젠테이션의 모든 애니메이션을 동시에 재생하려면 [PresentationPlayer](https://reference.aspose.com/slides/ko/net/aspose.slides.export/presentationplayer/) 클래스를 사용합니다. 이 클래스는 생성자에 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/net/aspose.slides.export/presentationanimationsgenerator/) 인스턴스와 효과용 FPS 값을 전달받고, 모든 애니메이션에 대해 `FrameTick` 이벤트를 호출하여 재생합니다:

```c#
using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```

그런 다음 생성된 프레임을 컴파일하여 비디오를 만들 수 있습니다. [PowerPoint 프레젠테이션을 비디오로 변환](/slides/ko/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) 섹션을 참고하십시오.

## **지원되는 애니메이션 및 효과**

PowerPoint 프레젠테이션을 비디오로 변환할 때 출력물에서 지원되는 애니메이션 및 효과를 이해하는 것이 중요합니다. Aspose.Slides는 페이드, 플라이 인, 줌, 스핀 등 일반적인 입장, 종료, 강조 효과를 폭넓게 지원합니다. 그러나 일부 고급 또는 사용자 정의 애니메이션은 완전히 보존되지 않거나 최종 비디오에서 다르게 표시될 수 있습니다. 이 섹션에서는 지원되는 애니메이션 및 효과를 정리합니다.

**입장:**

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**강조:**

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**종료:**

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**모션 경로:**

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **지원되는 슬라이드 전환 효과**

슬라이드 전환 효과는 비디오에서 슬라이드 간의 부드럽고 시각적으로 매력적인 변화를 만드는 데 중요한 역할을 합니다. Aspose.Slides for .NET는 원본 프레젠테이션의 흐름과 스타일을 보존하기 위해 일반적으로 사용되는 다양한 전환 효과를 지원합니다. 이 섹션에서는 변환 과정에서 지원되는 전환 효과를 강조합니다.

**미묘:**

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**흥미로운:**

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**동적 콘텐츠:**

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**암호로 보호된 프레젠테이션을 변환할 수 있나요?**

예, Aspose.Slides for .NET는 암호로 보호된 프레젠테이션 작업을 지원합니다. 이러한 파일을 처리할 때는 올바른 비밀번호를 제공하여 라이브러리가 프레젠테이션 내용을 액세스할 수 있도록 해야 합니다.

**Aspose.Slides for .NET가 클라우드 솔루션에서 사용을 지원합니까?**

예, Aspose.Slides for .NET는 클라우드 애플리케이션 및 서비스에 통합될 수 있습니다. 이 라이브러리는 서버 환경에서 고성능 및 확장성을 보장하도록 설계되어 파일 배치 처리에 적합합니다.

**변환 중 프레젠테이션에 크기 제한이 있나요?**

Aspose.Slides for .NET는 사실상 모든 크기의 프레젠테이션을 처리할 수 있습니다. 그러나 매우 큰 파일을 다룰 때는 추가적인 시스템 리소스가 필요할 수 있으며, 성능 향상을 위해 프레젠테이션을 최적화하는 것이 권장됩니다.