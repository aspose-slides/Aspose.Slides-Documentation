---
title: Java에서 PowerPoint 프레젠테이션을 비디오로 변환하기
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
description: "Java에서 PowerPoint 프레젠테이션을 비디오로 변환하는 방법을 배웁니다. 샘플 코드와 자동화 기술을 통해 작업 흐름을 효율화하십시오."
---
## **Introduction**

PowerPoint 또는 OpenDocument 프레젠테이션을 비디오로 변환하면 다음과 같은 이점을 얻을 수 있습니다:

**접근성 향상:** 모든 장치는 기본적으로 비디오 플레이어를 탑재하고 있어, 전통적인 프레젠테이션 응용 프로그램보다 비디오를 열거나 재생하기가 더 쉽습니다.

**도달 범위 확대:** 비디오는 더 많은 청중에게 도달하고 정보를 보다 매력적인 형식으로 제공할 수 있게 해 줍니다. 설문 조사와 통계에 따르면 사람들은 다른 형태보다 비디오 콘텐츠를 시청하고 소비하는 것을 선호하므로 메시지 전달 효과가 높아집니다.

{{% alert color="info" %}} 
아래의 [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/ko/video) 를 확인해 보세요. 이 도구는 여기서 설명한 프로세스의 실시간 및 효과적인 구현입니다.
{{% /alert %}} 

## **Aspose.Slides에서 PowerPoint를 비디오로 변환**

[Aspose.Slides 22.11](https://docs.aspose.com/slides/ko/java/aspose-slides-for-java-22-11-release-notes/)에서 프레젠테이션을 비디오로 변환하는 기능을 구현했습니다. 

* **Aspose.Slides**를 사용하여 프레젠테이션 슬라이드에서 일정 FPS(초당 프레임)로 대응되는 프레임 집합을 생성합니다.
* **ffmpeg**와 같은 써드파티 유틸리티([for java](https://github.com/bramp/ffmpeg-cli-wrapper))를 사용하여 프레임을 기반으로 비디오를 생성합니다. 

### **Convert PowerPoint to Video**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Download ffmpeg [here](https://ffmpeg.org/download.html).

4. Run the PowerPoint to video Java code.

This Java code shows you how to convert a presentation (containing a figure and two animation effects) to a video:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // 웃는 얼굴 모양을 추가하고 애니메이션을 적용합니다
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

    // ffmpeg 바이너리 폴더를 구성합니다. 이 페이지를 참고하세요: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **Video Effects**

슬라이드의 개체에 애니메이션을 적용하고 슬라이드 간 전환을 사용할 수 있습니다.

{{% alert color="info" %}} 
다음 문서를 참고하세요: [PowerPoint Animation](https://docs.aspose.com/slides/ko/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/ko/java/shape-animation/), 및 [Shape Effect](https://docs.aspose.com/slides/ko/java/shape-effect/).
{{% /alert %}} 

애니메이션과 전환은 슬라이드 쇼를 더 매력적이고 흥미롭게 만들며, 비디오에서도 동일한 효과를 제공합니다. 이전 프레젠테이션 코드에 또 다른 슬라이드와 전환을 추가해 보겠습니다:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // 웃는 얼굴 모양을 추가하고 애니메이션을 적용합니다

    // ...

    // 새 슬라이드를 추가하고 전환 효과를 애니메이션화합니다

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides는 텍스트에 대한 애니메이션도 지원합니다. 따라서 객체의 단락을 순차적으로 나타나게(지연 시간을 1초로 설정) 애니메이션화합니다:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

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

    // ffmpeg 바이너리 폴더를 구성합니다. 이 페이지를 참고하세요: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **Video Conversion Classes**

PowerPoint를 비디오로 변환하는 작업을 수행할 수 있도록 Aspose.Slides는 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationanimationsgenerator/)와 [PresentationPlayer](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationplayer/) 클래스를 제공합니다.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationanimationsgenerator/)는 생성자를 통해 나중에 생성될 비디오의 프레임 크기를 설정할 수 있습니다. 프레젠테이션 인스턴스를 전달하면 `Presentation.SlideSize`가 사용되며, 이 클래스는 [PresentationPlayer](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationplayer/)가 사용할 애니메이션을 생성합니다. 

애니메이션이 생성될 때마다 `NewAnimation` 이벤트가 발생하며, 여기에는 [IPresentationAnimationPlayer](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationanimationplayer/) 매개변수가 전달됩니다. 후자는 개별 애니메이션의 플레이어를 나타내는 클래스입니다.

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationanimationplayer/)와 작업하려면 [Duration](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (애니메이션 전체 지속 시간) 속성과 [SetTimePosition](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) 메서드를 사용합니다. 각 애니메이션 위치는 *0부터 duration* 범위 내에 설정되며, `getFrame` 메서드는 해당 순간의 애니메이션 상태에 해당하는 [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/)을 반환합니다:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // 웃는 얼굴 모양을 추가하고 애니메이션을 적용합니다
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
            // 초기 애니메이션 상태 비트맵
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // 애니메이션 최종 상태
            // 애니메이션의 마지막 프레임
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // 애니메이션을 생성합니다 - 위에서 처리된 이벤트를 발생시키는 부분입니다
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

프레젠테이션의 모든 애니메이션을 한 번에 재생하려면 [PresentationPlayer](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationplayer/) 클래스를 사용합니다. 이 클래스는 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationanimationsgenerator/) 인스턴스와 FPS 값을 생성자에 전달하고, 모든 애니메이션에 대해 `FrameTick` 이벤트를 호출하여 재생합니다:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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

그 후 생성된 프레임을 컴파일하여 비디오를 만들 수 있습니다. 자세한 내용은 [Convert PowerPoint to Video](https://docs.aspose.com/slides/ko/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) 섹션을 참조하세요.

## **Supported Animations and Effects**

**입장**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **나타내기** | ![not supported](x.png) | ![supported](v.png) |
| **페이드** | ![supported](v.png) | ![supported](v.png) |
| **날아오기** | ![supported](v.png) | ![supported](v.png) |
| **떠오르기** | ![supported](v.png) | ![supported](v.png) |
| **분할** | ![supported](v.png) | ![supported](v.png) |
| **와이프** | ![supported](v.png) | ![supported](v.png) |
| **모양** | ![supported](v.png) | ![supported](v.png) |
| **휠** | ![supported](v.png) | ![supported](v.png) |
| **무작위 막대** | ![supported](v.png) | ![supported](v.png) |
| **증가 및 회전** | ![not supported](x.png) | ![supported](v.png) |
| **줌** | ![supported](v.png) | ![supported](v.png) |
| **스위블** | ![supported](v.png) | ![supported](v.png) |
| **바운스** | ![supported](v.png) | ![supported](v.png) |

**강조**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **펄스** | ![not supported](x.png) | ![supported](v.png) |
| **색상 펄스** | ![not supported](x.png) | ![supported](v.png) |
| **흔들림** | ![supported](v.png) | ![supported](v.png) |
| **스핀** | ![supported](v.png) | ![supported](v.png) |
| **크기 조절** | ![not supported](x.png) | ![supported](v.png) |
| **채도 감소** | ![not supported](x.png) | ![supported](v.png) |
| **어둡게** | ![not supported](x.png) | ![supported](v.png) |
| **밝게** | ![not supported](x.png) | ![supported](v.png) |
| **투명도** | ![not supported](x.png) | ![supported](v.png) |
| **객체 색상** | ![not supported](x.png) | ![supported](v.png) |
| **보색** | ![not supported](x.png) | ![supported](v.png) |
| **선 색상** | ![not supported](x.png) | ![supported](v.png) |
| **채우기 색상** | ![not supported](x.png) | ![supported](v.png) |

**퇴장**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **사라짐** | ![not supported](x.png) | ![supported](v.png) |
| **페이드** | ![supported](v.png) | ![supported](v.png) |
| **날아가기** | ![supported](v.png) | ![supported](v.png) |
| **떠나기** | ![supported](v.png) | ![supported](v.png) |
| **분할** | ![supported](v.png) | ![supported](v.png) |
| **와이프** | ![supported](v.png) | ![supported](v.png) |
| **모양** | ![supported](v.png) | ![supported](v.png) |
| **무작위 막대** | ![supported](v.png) | ![supported](v.png) |
| **축소 및 회전** | ![not supported](x.png) | ![supported](v.png) |
| **줌** | ![supported](v.png) | ![supported](v.png) |
| **스위블** | ![supported](v.png) | ![supported](v.png) |
| **바운스** | ![supported](v.png) | ![supported](v.png) |

**모션 경로**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **선** | ![supported](v.png) | ![supported](v.png) |
| **호** | ![supported](v.png) | ![supported](v.png) |
| **회전** | ![supported](v.png) | ![supported](v.png) |
| **도형** | ![supported](v.png) | ![supported](v.png) |
| **루프** | ![supported](v.png) | ![supported](v.png) |
| **사용자 지정 경로** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### 프레젠테이션이 암호로 보호되어 있는 경우 변환이 가능한가요?

예, Aspose.Slides는 [암호로 보호된 프레젠테이션](/slides/ko/java/password-protected-presentation/) 작업을 지원합니다. 이러한 파일을 처리하려면 올바른 비밀번호를 제공하여 라이브러리가 프레젠테이션 내용을 액세스할 수 있도록 해야 합니다.

### Aspose.Slides를 클라우드 솔루션에서 사용할 수 있나요?

예, Aspose.Slides는 클라우드 애플리케이션 및 서비스에 통합할 수 있습니다. 이 라이브러리는 서버 환경에서 작동하도록 설계되어 파일 배치 처리 시 높은 성능과 확장성을 보장합니다.

### 변환 중 프레젠테이션 크기에 제한이 있나요?

Aspose.Slides는 사실상 모든 크기의 프레젠테이션을 처리할 수 있습니다. 다만, 매우 큰 파일을 작업할 때는 추가 시스템 리소스가 필요할 수 있으며, 성능 향상을 위해 프레젠테이션을 최적화하는 것이 권장되기도 합니다.