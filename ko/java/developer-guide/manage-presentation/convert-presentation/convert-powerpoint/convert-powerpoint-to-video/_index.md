---
title: Java에서 PowerPoint 프레젠테이션을 비디오로 변환
linktitle: PowerPoint를 비디오로
type: docs
weight: 130
url: /ko/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "Java에서 PowerPoint 프레젠테이션을 비디오로 변환하는 방법을 배우세요. 샘플 코드와 자동화 기술을 확인하여 작업 흐름을 간소화할 수 있습니다."
---
## **소개**

**접근성 향상:** 모든 디바이스는 기본적으로 비디오 플레이어를 탑재하고 있어, 전통적인 프레젠테이션 애플리케이션보다 비디오를 열거나 재생하기가 더 쉽습니다.

**도달 범위 확대:** 비디오는 더 큰 청중에게 도달하고 정보를 보다 매력적인 형식으로 전달할 수 있게 합니다. 설문 조사와 통계에 따르면 사람들은 다른 형태보다 비디오 콘텐츠를 시청하고 소비하는 것을 선호하므로 메시지 전달 효과가 높아집니다.

{{% alert color="primary" %}} 
다음의 [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/ko/conversion/ppt-to-word)를 확인해 보시기 바랍니다. 본 문서에 설명된 프로세스를 실시간으로 효과적으로 구현한 예시입니다.
{{% /alert %}} 

## **Aspose.Slides에서 PowerPoint를 비디오로 변환**

[Aspose.Slides 22.11](https://docs.aspose.com/slides/ko/java/aspose-slides-for-java-22-11-release-notes/)에서 프레젠테이션을 비디오로 변환하는 기능을 구현했습니다. 

* **Aspose.Slides**를 사용하여 프레젠테이션 슬라이드에서 특정 FPS(초당 프레임 수)에 해당하는 프레임 세트를 생성합니다.  
* **ffmpeg**와 같은 서드파티 유틸리티([java용](https://github.com/bramp/ffmpeg-cli-wrapper))를 사용해 프레임을 기반으로 비디오를 만듭니다. 

### **PowerPoint를 비디오로 변환**

1. POM 파일에 아래 내용을 추가합니다:  
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

    // ffmpeg 바이너리 폴더를 설정합니다. 이 페이지를 참조하세요: https://github.com/rosenbjerg/FFMpegCore#installation
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

슬라이드의 객체에 애니메이션을 적용하고 슬라이드 간 전환을 사용할 수 있습니다. 

{{% alert color="primary" %}} 
다음 기사들을 확인해 보시기 바랍니다: [PowerPoint Animation](https://docs.aspose.com/slides/ko/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/ko/java/shape-animation/), 그리고 [Shape Effect](https://docs.aspose.com/slides/ko/java/shape-effect/).
{{% /alert %}} 

애니메이션과 전환은 슬라이드 쇼를 더 매력적이고 흥미롭게 만들며, 비디오에서도 동일한 효과를 제공합니다. 이전 프레젠테이션 코드에 또 다른 슬라이드와 전환을 추가해 보겠습니다:  
```java
// 스마일 모양을 추가하고 애니메이션을 적용합니다

// ...

// 새 슬라이드를 추가하고 애니메이션 전환을 설정합니다

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides는 텍스트에 대한 애니메이션도 지원합니다. 따라서 객체의 단락을 애니메이션화하여 1초 간격으로 순차적으로 표시하도록 할 수 있습니다:  
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

    // ffmpeg 바이너리 폴더를 설정합니다. 이 페이지를 참조하세요: https://github.com/rosenbjerg/FFMpegCore#installation
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

PowerPoint를 비디오로 변환하는 작업을 수행할 수 있도록 Aspose.Slides는 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationanimationsgenerator/)와 [PresentationPlayer](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationplayer/) 클래스를 제공합니다.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationanimationsgenerator/)는 생성자를 통해 비디오(나중에 생성될)의 프레임 크기를 설정할 수 있습니다. 프레젠테이션 인스턴스를 전달하면 `Presentation.SlideSize`가 사용되며, 이 클래스가 생성한 애니메이션을 [PresentationPlayer](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationplayer/)가 사용합니다. 

애니메이션이 생성될 때마다 각 후속 애니메이션에 대해 `NewAnimation` 이벤트가 발생하며, 여기에는 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationanimationplayer/) 매개변수가 전달됩니다. 후자는 별도 애니메이션에 대한 플레이어를 나타내는 클래스입니다.

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationanimationplayer/)와 작업하려면 [Duration](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (애니메이션 전체 지속 시간) 속성과 [SetTimePosition](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) 메서드를 사용합니다. 각 애니메이션 위치는 *0부터 duration* 범위 내에 설정되며, 이후 `GetFrame` 메서드는 해당 시점의 애니메이션 상태에 해당하는 BufferedImage를 반환합니다:  
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

프레젠테이션의 모든 애니메이션을 동시에 재생하려면 [PresentationPlayer](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationplayer/) 클래스를 사용합니다. 이 클래스는 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationanimationsgenerator/) 인스턴스와 FPS 값을 생성자에 전달한 뒤, 모든 애니메이션에 대해 `FrameTick` 이벤트를 호출하여 재생합니다:  
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

그런 다음 생성된 프레임을 합쳐 비디오를 만들 수 있습니다. 자세한 내용은 [Convert PowerPoint to Video](https://docs.aspose.com/slides/ko/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) 섹션을 참고하십시오.

## **지원되는 애니메이션 및 효과**

**진입**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![지원 안 함](x.png) | ![지원](v.png) |
| **Fade** | ![지원](v.png) | ![지원](v.png) |
| **Fly In** | ![지원](v.png) | ![지원](v.png) |
| **Float In** | ![지원](v.png) | ![지원](v.png) |
| **Split** | ![지원](v.png) | ![지원](v.png) |
| **Wipe** | ![지원](v.png) | ![지원](v.png) |
| **Shape** | ![지원](v.png) | ![지원](v.png) |
| **Wheel** | ![지원](v.png) | ![지원](v.png) |
| **Random Bars** | ![지원](v.png) | ![지원](v.png) |
| **Grow & Turn** | ![지원 안 함](x.png) | ![지원](v.png) |
| **Zoom** | ![지원](v.png) | ![지원](v.png) |
| **Swivel** | ![지원](v.png) | ![지원](v.png) |
| **Bounce** | ![지원](v.png) | ![지원](v.png) |

**강조**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![지원 안 함](x.png) | ![지원](v.png) |
| **Color Pulse** | ![지원 안 함](x.png) | ![지원](v.png) |
| **Teeter** | ![지원](v.png) | ![지원](v.png) |
| **Spin** | ![지원](v.png) | ![지원](v.png) |
| **Grow/Shrink** | ![지원 안 함](x.png) | ![지원](v.png) |
| **Desaturate** | ![지원 안 함](x.png) | ![지원](v.png) |
| **Darken** | ![지원 안 함](x.png) | ![지원](v.png) |
| **Lighten** | ![지원 안 함](x.png) | ![지원](v.png) |
| **Transparency** | ![지원 안 함](x.png) | ![지원](v.png) |
| **Object Color** | ![지원 안 함](x.png) | ![지원](v.png) |
| **Complementary Color** | ![지원 안 함](x.png) | ![지원](v.png) |
| **Line Color** | ![지원 안 함](x.png) | ![지원](v.png) |
| **Fill Color** | ![지원 안 함](x.png) | ![지원](v.png) |

**퇴장**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![지원 안 함](x.png) | ![지원](v.png) |
| **Fade** | ![지원](v.png) | ![지원](v.png) |
| **Fly Out** | ![지원](v.png) | ![지원](v.png) |
| **Float Out** | ![지원](v.png) | ![지원](v.png) |
| **Split** | ![지원](v.png) | ![지원](v.png) |
| **Wipe** | ![지원](v.png) | ![지원](v.png) |
| **Shape** | ![지원](v.png) | ![지원](v.png) |
| **Random Bars** | ![지원](v.png) | ![지원](v.png) |
| **Shrink & Turn** | ![지원 안 함](x.png) | ![지원](v.png) |
| **Zoom** | ![지원](v.png) | ![지원](v.png) |
| **Swivel** | ![지원](v.png) | ![지원](v.png) |
| **Bounce** | ![지원](v.png) | ![지원](v.png) |

**동작 경로**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![지원](v.png) | ![지원](v.png) |
| **Arcs** | ![지원](v.png) | ![지원](v.png) |
| **Turns** | ![지원](v.png) | ![지원](v.png) |
| **Shapes** | ![지원](v.png) | ![지원](v.png) |
| **Loops** | ![지원](v.png) | ![지원](v.png) |
| **Custom Path** | ![지원](v.png) | ![지원](v.png) |

## **자주 묻는 질문**

**비밀번호로 보호된 프레젠테이션을 변환할 수 있나요?**

예, Aspose.Slides는 [비밀번호로 보호된 프레젠테이션](/slides/ko/java/password-protected-presentation/) 작업을 지원합니다. 해당 파일을 처리할 때 올바른 비밀번호를 제공해야 라이브러리가 프레젠테이션 내용을 액세스할 수 있습니다.

**Aspose.Slides가 클라우드 솔루션에서 사용을 지원하나요?**

예, Aspose.Slides는 클라우드 애플리케이션 및 서비스에 통합될 수 있습니다. 이 라이브러리는 서버 환경에서 동작하도록 설계되어 파일 일괄 처리 시 높은 성능과 확장성을 보장합니다.

**변환 중 프레젠테이션 크기에 제한이 있나요?**

Aspose.Slides는 사실상 모든 크기의 프레젠테이션을 처리할 수 있습니다. 다만 매우 큰 파일을 다룰 경우 추가 시스템 리소스가 필요할 수 있으며, 성능 향상을 위해 프레젠테이션을 최적화하는 것이 권장되는 경우도 있습니다.