---
title: ".NET에서 PowerPoint 프레젠테이션을 비디오로 변환하기"
linktitle: "PowerPoint 비디오 변환"
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
- "PowerPoint"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET에서 PowerPoint 프레젠테이션을 비디오로 변환하는 방법을 배우세요. 샘플 C# 코드와 자동화 기술을 확인하여 작업 흐름을 효율화할 수 있습니다."
---
## **소개**

PowerPoint 또는 OpenDocument 프레젠테이션을 비디오로 변환하면 다음과 같은 이점을 얻을 수 있습니다:

**접근성 향상:** 플랫폼에 관계없이 모든 장치는 기본적으로 비디오 플레이어를 갖추고 있어 전통적인 프레젠테이션 애플리케이션보다 비디오를 열거나 재생하기가 더 쉽습니다.

**도달 범위 확대:** 비디오를 사용하면 더 큰 청중에게 도달하고 정보를 보다 매력적인 형식으로 제공할 수 있습니다. 설문 조사와 통계에 따르면 사람들은 다른 형태보다 비디오 콘텐츠를 시청하고 소비하는 것을 선호하여 메시지 전달 효과가 높아집니다.

{{% alert color="info" %}} 
아래의 [**PowerPoint to Video 온라인 변환기**](https://products.aspose.app/slides/ko/video)를 확인해 보세요. 이 도구는 여기서 설명한 프로세스를 실시간으로 효과적으로 구현합니다.
{{% /alert %}} 

Aspose.Slides for .NET에서 프레젠테이션을 비디오로 변환하는 기능을 구현했습니다.

* 지정된 프레임 속도(FPS)로 프레젠테이션 슬라이드에서 프레임을 생성하려면 Aspose.Slides for .NET을 사용합니다.
* 그런 다음 ffmpeg와 같은 타사 유틸리티를 사용하여 이러한 프레임을 비디오로 합칩니다.

## **PowerPoint 프레젠테이션을 비디오로 변환하기**

1. `dotnet add package` 명령을 사용하여 Aspose.Slides와 FFMpegCore 라이브러리를 프로젝트에 추가합니다:
   * `dotnet add package Aspose.Slides.NET --version 22.11.0` 실행
   * `dotnet add package FFMpegCore --version 4.8.0` 실행
2. ffmpeg를 [여기](https://ffmpeg.org/download.html)에서 다운로드합니다.
3. FFMpegCore는 다운로드한 ffmpeg의 경로를 지정해야 합니다(예: "C:\tools\ffmpeg"에 압축 해제):
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. PowerPoint를 비디오로 변환하는 코드를 실행합니다.

다음 C# 코드는 모양과 두 개의 애니메이션 효과가 포함된 프레젠테이션을 비디오로 변환하는 방법을 보여줍니다:
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // 이전에 추출한 C:\tools\ffmpeg의 FFmpeg 바이너리를 사용합니다.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 웃음 모양을 추가하고 애니메이션을 적용합니다.
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

    // ffmpeg 바이너리 폴더를 구성합니다. 이 페이지를 참조하세요: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // 프레임을 webm 비디오로 변환합니다.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **비디오 효과**

Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션을 비디오로 변환할 때 다양한 비디오 효과를 적용하여 출력의 시각적 품질을 향상시킬 수 있습니다. 이러한 효과를 사용하면 매끄러운 전환, 애니메이션 및 기타 시각적 요소를 추가하여 최종 비디오의 슬라이드 모양을 제어할 수 있습니다. 이 섹션에서는 사용 가능한 비디오 효과 옵션을 설명하고 적용 방법을 보여줍니다.

{{% alert color="info" %}} 
참고:
- [C#에서 애니메이션으로 PowerPoint 프레젠테이션 향상하기](https://docs.aspose.com/slides/ko/net/powerpoint-animation/)
- [모양 애니메이션](https://docs.aspose.com/slides/ko/net/shape-animation/)
- [C#를 사용하여 PowerPoint에서 모양 효과 적용하기](https://docs.aspose.com/slides/ko/net/shape-effect/)
{{% /alert %}} 

애니메이션과 전환은 슬라이드쇼를 더 매력적이고 흥미롭게 만들며, 비디오에서도 동일하게 적용됩니다. 이전 프레젠테이션 코드에 또 다른 슬라이드와 전환을 추가해 보겠습니다:
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // 웃음 모양을 추가하고 애니메이션을 적용합니다 (위 코드를 참조).

    // 새 슬라이드를 추가하고 애니메이션 전환을 적용합니다.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Aspose.Slides는 텍스트 애니메이션도 지원합니다. 이 예제에서는 객체의 단락을 애니메이션 처리하여 각각이 차례대로 나타나도록 하며, 각 단락 사이에 1초 지연을 두었습니다:
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

    // ffmpeg 바이너리 폴더를 구성합니다. 이 페이지를 참고하세요: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // 프레임을 webm 비디오로 변환합니다.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **비디오 변환 클래스**

PowerPoint를 비디오로 변환하는 작업을 수행하려면 Aspose.Slides for .NET이 제공하는 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/net/aspose.slides.export/presentationanimationsgenerator/) 및 [PresentationPlayer](https://reference.aspose.com/slides/ko/net/aspose.slides.export/presentationplayer/) 클래스를 사용할 수 있습니다.

`PresentationAnimationsGenerator`는 생성자에서 비디오의 프레임 크기(나중에 생성될)와 FPS(초당 프레임) 값을 설정할 수 있게 합니다. 프레젠테이션 인스턴스를 전달하면 해당 `Presentation.SlideSize`가 사용되며, 이 클래스는 [PresentationPlayer](https://reference.aspose.com/slides/ko/net/aspose.slides.export/presentationplayer/)이 사용하는 애니메이션을 생성합니다.

애니메이션이 생성될 때마다 각 후속 애니메이션에 대해 `NewAnimation` 이벤트가 트리거되며, 여기에는 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ipresentationanimationplayer/) 매개변수가 포함됩니다. 이 클래스는 개별 애니메이션에 대한 플레이어를 나타냅니다.

[IPresentationAnimationPlayer]를 사용하려면 전체 애니메이션 지속 시간을 제공하는 `Duration` 속성과 `SetTimePosition` 메서드를 사용합니다. 각 애니메이션 위치는 *0부터 지속 시간* 범위 내에 설정되며, `GetFrame` 메서드는 해당 시점의 애니메이션 상태를 나타내는 Bitmap을 반환합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 웃음 모양을 추가하고 애니메이션을 적용합니다.
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

            animationPlayer.SetTimePosition(0);        // 초기 애니메이션 상태.
            IImage image = animationPlayer.GetFrame(); // 초기 애니메이션 상태 이미지.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // 애니메이션의 최종 상태.
            IImage lastImage = animationPlayer.GetFrame();             // 애니메이션의 마지막 프레임.
            lastImage.Save("last.png");
        };
    }
}
```

프레젠테이션의 모든 애니메이션을 한 번에 재생하려면 [PresentationPlayer](https://reference.aspose.com/slides/ko/net/aspose.slides.export/presentationplayer/) 클래스를 사용합니다. 이 클래스는 생성자에서 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/net/aspose.slides.export/presentationanimationsgenerator/) 인스턴스와 효과에 대한 FPS 값을 받아 모든 애니메이션에 대해 `FrameTick` 이벤트를 호출하여 재생합니다:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

그런 다음 생성된 프레임을 컴파일하여 비디오를 만들 수 있습니다. 자세한 내용은 [PowerPoint 프레젠테이션을 비디오로 변환하기](/slides/ko/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) 섹션을 참조하십시오.

## **지원되는 애니메이션 및 효과**

Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션을 비디오로 변환할 때 출력에서 지원되는 애니메이션 및 효과를 이해하는 것이 중요합니다. Aspose.Slides는 페이드, 플라이 인, 줌, 스핀 등 일반적인 진입, 종료 및 강조 효과를 폭넓게 지원합니다. 그러나 일부 고급 또는 사용자 정의 애니메이션은 완전히 보존되지 않거나 최종 비디오에서 다르게 표시될 수 있습니다. 이 섹션에서는 지원되는 애니메이션 및 효과를 정리합니다.

**진입**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Fade** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Fly In** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Float In** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Split** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Wipe** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Shape** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Wheel** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Random Bars** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Grow & Turn** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Zoom** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Swivel** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Bounce** | ![지원됨](v.png) | ![지원됨](v.png) |

**강조**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Color Pulse** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Teeter** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Spin** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Grow/Shrink** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Desaturate** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Darken** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Lighten** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Transparency** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Object Color** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Complementary Color** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Line Color** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Fill Color** | ![지원되지 않음](x.png) | ![지원됨](v.png) |

**종료**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Fade** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Fly Out** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Float Out** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Split** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Wipe** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Shape** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Random Bars** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Shrink & Turn** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Zoom** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Swivel** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Bounce** | ![지원됨](v.png) | ![지원됨](v.png) |

**움직임 경로:**

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Arcs** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Turns** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Shapes** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Loops** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Custom Path** | ![지원됨](v.png) | ![지원됨](v.png) |

## **지원되는 슬라이드 전환 효과**

슬라이드 전환 효과는 비디오에서 슬라이드 간의 부드럽고 시각적으로 매력적인 변화를 만드는 데 중요한 역할을 합니다. Aspose.Slides for .NET은 원본 프레젠테이션의 흐름과 스타일을 유지하는 데 도움이 되는 다양한 일반적인 전환 효과를 지원합니다. 이 섹션에서는 변환 과정에서 지원되는 전환 효과를 강조합니다.

**미묘한**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Fade** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Push** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Pull** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Wipe** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Split** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Reveal** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Random Bars** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Shape** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Uncover** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Cover** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Flash** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Strips** | ![지원됨](v.png) | ![지원됨](v.png) |

**흥미로운**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Drape** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Curtains** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Wind** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Prestige** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Fracture** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Crush** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Peel Off** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Page Curl** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Airplane** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Origami** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Dissolve** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Checkerboard** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Blinds** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Clock** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Ripple** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Honeycomb** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Glitter** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Vortex** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Shred** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Switch** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Flip** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Gallery** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Cube** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Doors** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Box** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Comb** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Zoom** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Random** | ![지원되지 않음](x.png) | ![지원됨](v.png) |

**동적 콘텐츠**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Ferris Wheel** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Conveyor** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Rotate** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Orbit** | ![지원되지 않음](x.png) | ![지원됨](v.png) |
| **Fly Through** | ![지원됨](v.png) | ![지원됨](v.png) |

## **FAQ**

### 비밀번호로 보호된 프레젠테이션을 변환할 수 있나요?

예, Aspose.Slides for .NET은 비밀번호로 보호된 프레젠테이션 작업을 지원합니다. 이러한 파일을 처리할 때 올바른 비밀번호를 제공해야 라이브러리가 프레젠테이션 내용을 액세스할 수 있습니다.

### Aspose.Slides for .NET이 클라우드 솔루션에서 사용을 지원하나요?

예, Aspose.Slides for .NET은 클라우드 애플리케이션 및 서비스에 통합될 수 있습니다. 이 라이브러리는 서버 환경에서 작동하도록 설계되어 파일 배치 처리 시 높은 성능과 확장성을 보장합니다.

### 변환 중 프레젠테이션 크기에 제한이 있나요?

Aspose.Slides for .NET은 사실상 모든 크기의 프레젠테이션을 처리할 수 있습니다. 하지만 매우 큰 파일을 다룰 경우 추가 시스템 리소스가 필요할 수 있으며, 성능 향상을 위해 프레젠테이션을 최적화하는 것이 권장되기도 합니다.