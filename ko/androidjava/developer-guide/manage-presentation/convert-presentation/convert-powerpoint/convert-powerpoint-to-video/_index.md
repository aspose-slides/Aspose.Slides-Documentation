---
title: Android에서 PowerPoint 프레젠테이션을 비디오로 변환
linktitle: PowerPoint를 비디오로
type: docs
weight: 130
url: /ko/androidjava/convert-powerpoint-to-video/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 비디오로
- 프레젠테이션을 비디오로
- PPT를 비디오로
- PPTX를 비디오로
- PowerPoint를 MP4로
- 프레젠테이션을 MP4로
- PPT를 MP4로
- PPTX를 MP4로
- PPT를 MP4로 저장
- PPTX를 MP4로 저장
- PPT를 MP4로 내보내기
- PPTX를 MP4로 내보내기
- 비디오 변환
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "Java에서 PowerPoint 프레젠테이션을 비디오로 변환하는 방법을 배우세요. 샘플 코드와 자동화 기술을 통해 작업 흐름을 효율화할 수 있습니다."
---
## **소개**

PowerPoint 프레젠테이션을 비디오로 변환하면 다음과 같은 이점을 얻을 수 있습니다.

* **접근성 향상:** 프레젠테이션을 여는 애플리케이션에 비해 모든 장치(플랫폼과 관계없이)가 기본적으로 비디오 플레이어를 갖추고 있어 사용자가 비디오를 열거나 재생하기가 더 쉽습니다.
* **도달 범위 확대:** 비디오를 통해 더 많은 청중에게 도달하고, 프레젠테이션에서는 지루하게 느껴질 수 있는 정보를 전달할 수 있습니다. 대부분의 설문 조사와 통계에 따르면 사람들은 다른 형태의 콘텐츠보다 비디오를 더 많이 시청하고 소비하며, 일반적으로 이러한 콘텐츠를 선호합니다.

{{% alert color="primary" %}} 
다음의 [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/ko/conversion/ppt-to-word) 를 확인해 보시기 바랍니다. 이 도구는 여기서 설명한 프로세스를 실시간으로 구현한 효과적인 솔루션입니다.
{{% /alert %}} 

## **Aspose.Slides에서 PowerPoint를 비디오로 변환**

Aspose.Slides는 프레젠테이션을 비디오로 변환하는 기능을 지원합니다.

* **Aspose.Slides**를 사용하여 프레젠테이션 슬라이드에서 특정 FPS(초당 프레임 수)에 해당하는 일련의 프레임을 생성합니다.
* **ffmpeg**와 같은 서드파티 유틸리티([for java](https://github.com/bramp/ffmpeg-cli-wrapper))를 사용하여 프레임을 기반으로 비디오를 생성합니다. 

### **PowerPoint를 비디오로 변환**

1. POM 파일에 다음 내용을 추가합니다:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpeg을 [여기](https://ffmpeg.org/download.html)에서 다운로드합니다.

4. PowerPoint를 비디오로 변환하는 Java 코드를 실행합니다.

다음 Java 코드는 그림과 두 개의 애니메이션 효과가 포함된 프레젠테이션을 비디오로 변환하는 방법을 보여줍니다:
```java
Presentation presentation = new Presentation();
try {
    // 스마일 모양을 추가하고 애니메이션을 적용합니다
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // ffmpeg 바이너리 폴더를 설정합니다. 이 페이지를 참고하세요: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **비디오 효과**

슬라이드의 개체에 애니메이션을 적용하고 슬라이드 간 전환 효과를 사용할 수 있습니다.

{{% alert color="primary" %}} 
다음 문서를 참고하십시오: [PowerPoint Animation](https://docs.aspose.com/slides/ko/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/ko/androidjava/shape-animation/), 그리고 [Shape Effect](https://docs.aspose.com/slides/ko/androidjava/shape-effect/).
{{% /alert %}} 

애니메이션과 전환은 슬라이드쇼를 보다 흥미롭고 매력적으로 만들며, 비디오에도 동일하게 적용됩니다. 이전 프레젠테이션 코드에 또 다른 슬라이드와 전환을 추가해 보겠습니다:
```java
// 스마일 모양을 추가하고 애니메이션을 적용합니다

// ...

// 새 슬라이드를 추가하고 애니메이션 전환을 적용합니다

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides는 텍스트 애니메이션도 지원합니다. 따라서 개체의 단락을 애니메이션 처리하면 (딜레이를 1초로 설정하여) 하나씩 순차적으로 나타납니다:
```java
Presentation presentation = new Presentation();
try {
    // 텍스트와 애니메이션을 추가합니다
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // ffmpeg 바이너리 폴더를 설정합니다. 이 페이지를 참고하세요: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **비디오 변환 클래스**

PowerPoint를 비디오로 변환하는 작업을 수행할 수 있도록 Aspose.Slides는 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentationanimationsgenerator/)와 [PresentationPlayer](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentationplayer/) 클래스를 제공합니다.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentationanimationsgenerator/)는 생성자를 통해 비디오(추후 생성될)의 프레임 크기를 설정할 수 있게 해줍니다. 프레젠테이션 인스턴스를 전달하면 `Presentation.SlideSize`가 사용되며, 이 클래스는 [PresentationPlayer](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentationplayer/)가 사용할 애니메이션을 생성합니다.

애니메이션이 생성될 때마다 각 후속 애니메이션에 대해 `NewAnimation` 이벤트가 발생하며, 이 이벤트는 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationanimationplayer/) 매개변수를 가집니다. 후자는 별도 애니메이션을 재생하는 플레이어를 나타내는 클래스입니다.

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationanimationplayer/)를 사용하려면 [Duration](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (애니메이션 전체 지속 시간) 속성과 [SetTimePosition](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) 메서드를 사용합니다. 각 애니메이션 위치는 *0~duration* 범위 내에서 설정되며, 이후 `GetFrame` 메서드는 해당 순간의 애니메이션 상태에 해당하는 BufferedImage를 반환합니다:
```java
Presentation presentation = new Presentation();
try {
    // 스마일 모양을 추가하고 애니메이션을 적용합니다
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // 초기 애니메이션 상태
            try {
                // 초기 애니메이션 상태 비트맵
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // 애니메이션의 최종 상태
            try {
                // 애니메이션의 마지막 프레임
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

프레젠테이션의 모든 애니메이션을 동시에 재생하려면 [PresentationPlayer](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentationplayer/) 클래스를 사용합니다. 이 클래스는 생성자에서 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentationanimationsgenerator/) 인스턴스와 FPS 값을 받아들인 뒤, 모든 애니메이션에 대해 `FrameTick` 이벤트를 호출하여 재생합니다:
```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

그런 다음 생성된 프레임을 컴파일하여 비디오를 만들 수 있습니다. 자세한 내용은 [Convert PowerPoint to Video](https://docs.aspose.com/slides/ko/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) 섹션을 참조하십시오.

## **지원되는 애니메이션 및 효과**

**입장**:

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

**강조**:

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

**종료**:

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

**동작 경로**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**비밀번호로 보호된 프레젠테이션을 변환할 수 있나요?**

예, Aspose.Slides는 [password-protected presentations](/slides/ko/androidjava/password-protected-presentation/)를 지원합니다. 이러한 파일을 처리할 때는 올바른 비밀번호를 제공하여 라이브러리가 프레젠테이션 내용에 접근할 수 있도록 해야 합니다.

**Aspose.Slides를 클라우드 솔루션에서 사용할 수 있나요?**

예, Aspose.Slides는 클라우드 애플리케이션 및 서비스에 통합할 수 있습니다. 이 라이브러리는 서버 환경에서 동작하도록 설계되어 파일 배치 처리 시 높은 성능과 확장성을 보장합니다.

**변환 중 프레젠테이션 크기에 제한이 있나요?**

Aspose.Slides는 사실상 모든 크기의 프레젠테이션을 처리할 수 있습니다. 다만 매우 큰 파일을 다룰 경우 추가적인 시스템 리소스가 필요할 수 있으며, 성능 향상을 위해 프레젠테이션을 최적화하는 것이 권장되기도 합니다.