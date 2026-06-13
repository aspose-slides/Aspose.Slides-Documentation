---
title: JavaScript에서 PowerPoint 프레젠테이션을 비디오로 변환하기
linktitle: PowerPoint를 비디오로
type: docs
weight: 130
url: /ko/nodejs-java/convert-powerpoint-to-video/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript에서 PowerPoint 프레젠테이션을 비디오로 변환하는 방법을 배우세요. 샘플 코드와 자동화 기술을 활용하여 작업 흐름을 간소화할 수 있습니다."
---
## **소개**

PowerPoint 프레젠테이션을 비디오로 변환하면 다음과 같은 이점을 얻을 수 있습니다

* **접근성 향상:** 모든 장치(플랫폼에 관계없이)는 기본적으로 비디오 플레이어가 탑재되어 있어 프레젠테이션 열기 애플리케이션보다 비디오를 열거나 재생하기가 더 쉽습니다.
* **도달 범위 확대:** 비디오를 통해 많은 청중에게 도달하고 프레젠테이션에서는 지루하게 느껴질 수 있는 정보를 전달할 수 있습니다. 대부분의 설문 조사와 통계에 따르면 사람들은 다른 형태의 콘텐츠보다 비디오를 더 많이 시청하고 소비하며, 일반적으로 이러한 콘텐츠를 선호합니다.

{{% alert color="primary" %}} 

아래의 [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/ko/conversion/ppt-to-word)를 확인해 보세요. 이 도구는 여기서 설명한 프로세스를 실시간으로 구현한 효과적인 솔루션입니다.

{{% /alert %}} 

## **Aspose.Slides에서 PowerPoint를 비디오로 변환하기**

Aspose.Slides는 프레젠테이션을 비디오로 변환하는 기능을 지원합니다.

* **Aspose.Slides**를 사용하여 특정 FPS(초당 프레임 수)에 해당하는 일련의 프레임(프레젠테이션 슬라이드에서 추출)을 생성합니다
* **ffmpeg**와 같은 서드파티 유틸리티([for java](https://github.com/bramp/ffmpeg-cli-wrapper))를 사용하여 프레임을 기반으로 비디오를 생성합니다. 

### **PowerPoint를 비디오로 변환하기**

1. ffmpeg을 [여기](https://ffmpeg.org/download.html)에서 다운로드합니다.
2. PowerPoint를 비디오로 변환하는 JavaScript 코드를 실행합니다.

다음 JavaScript 코드는 그림과 두 개의 애니메이션 효과가 포함된 프레젠테이션을 비디오로 변환하는 방법을 보여줍니다:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 스마일 모양을 추가하고 애니메이션을 적용합니다
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // ffmpeg 바이너리 폴더를 설정합니다. 이 페이지를 참조하세요: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **비디오 효과**

슬라이드의 객체에 애니메이션을 적용하고 슬라이드 간 전환 효과를 사용할 수 있습니다.

{{% alert color="primary" %}} 

다음 문서를 참고해 보세요: [PowerPoint Animation](https://docs.aspose.com/slides/ko/nodejs-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/ko/nodejs-java/shape-animation/), 및 [Shape Effect](https://docs.aspose.com/slides/ko/nodejs-java/shape-effect/).

{{% /alert %}} 

애니메이션과 전환은 슬라이드 쇼를 더욱 매력적이고 흥미롭게 만들며, 비디오에도 동일하게 적용됩니다. 이전 프레젠테이션 코드에 또 다른 슬라이드와 전환을 추가해 보겠습니다:

```javascript
// 스마일 모양을 추가하고 애니메이션을 적용합니다
// ...
// 새 슬라이드를 추가하고 애니메이션 전환을 적용합니다
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides는 텍스트 애니메이션도 지원합니다. 따라서 객체에 있는 단락을 순차적으로(1초 지연으로) 나타나게 애니메이션을 적용합니다:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 텍스트와 애니메이션을 추가합니다
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // ffmpeg 바이너리 폴더를 설정합니다. 이 페이지를 참조하세요: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **비디오 변환 클래스**

PowerPoint를 비디오로 변환하는 작업을 수행할 수 있도록 Aspose.Slides는 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationanimationsgenerator/) 및 [PresentationPlayer](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationplayer/) 클래스를 제공합니다.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationanimationsgenerator/)는 생성될 비디오의 프레임 크기를 생성자에서 설정할 수 있게 해줍니다. 프레젠테이션 인스턴스를 전달하면 `Presentation.getSlideSize`가 사용되며, 이 클래스는 [PresentationPlayer](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationplayer/)가 사용하는 애니메이션을 생성합니다.

애니메이션이 생성될 때마다 `NewAnimation` 이벤트가 생성되며, 여기에는 프레젠테이션 애니메이션 플레이어 매개변수가 포함됩니다. 이 매개변수는 개별 애니메이션에 대한 플레이어를 나타내는 클래스입니다.

프레젠테이션 애니메이션 플레이어를 사용하려면 `getDuration`(애니메이션 전체 지속 시간) 메서드와 `setTimePosition` 메서드를 사용합니다. 각 애니메이션 위치는 *0에서 지속 시간* 범위 내에 설정되며, 이후 `getFrame` 메서드는 해당 순간의 애니메이션 상태에 해당하는 BufferedImage를 반환합니다:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 스마일 모양을 추가하고 애니메이션을 적용합니다
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// 초기 애니메이션 상태
            try {
                // 초기 애니메이션 상태 비트맵
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// 애니메이션 최종 상태
            try {
                // 애니메이션의 마지막 프레임
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

프레젠테이션의 모든 애니메이션을 동시에 재생하려면 [PresentationPlayer](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationplayer/) 클래스를 사용합니다. 이 클래스는 생성자에서 [PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationanimationsgenerator/) 인스턴스와 효과에 대한 FPS를 받아들인 후, 모든 애니메이션에 대해 `FrameTick` 이벤트를 호출하여 재생합니다:

```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

그런 다음 생성된 프레임을 컴파일하여 비디오를 만들 수 있습니다. 자세한 내용은 [Convert PowerPoint to Video](https://docs.aspose.com/slides/ko/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video) 섹션을 참고하세요.

## **지원되는 애니메이션 및 효과**

**입장**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **출현** | ![not supported](x.png) | ![supported](v.png) |
| **페이드** | ![supported](v.png) | ![supported](v.png) |
| **플라잉 인** | ![supported](v.png) | ![supported](v.png) |
| **플로트 인** | ![supported](v.png) | ![supported](v.png) |
| **분할** | ![supported](v.png) | ![supported](v.png) |
| **와이프** | ![supported](v.png) | ![supported](v.png) |
| **도형** | ![supported](v.png) | ![supported](v.png) |
| **휠** | ![supported](v.png) | ![supported](v.png) |
| **무작위 막대** | ![supported](v.png) | ![supported](v.png) |
| **확대 및 회전** | ![not supported](x.png) | ![supported](v.png) |
| **줌** | ![supported](v.png) | ![supported](v.png) |
| **스위블** | ![supported](v.png) | ![supported](v.png) |
| **바운스** | ![supported](v.png) | ![supported](v.png) |

**강조**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **펄스** | ![not supported](x.png) | ![supported](v.png) |
| **색상 펄스** | ![not supported](x.png) | ![supported](v.png) |
| **흔들림** | ![supported](v.png) | ![supported](v.png) |
| **회전** | ![supported](v.png) | ![supported](v.png) |
| **크기 증가/감소** | ![not supported](x.png) | ![supported](v.png) |
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
| **플라잉 아웃** | ![supported](v.png) | ![supported](v.png) |
| **플로트 아웃** | ![supported](v.png) | ![supported](v.png) |
| **분할** | ![supported](v.png) | ![supported](v.png) |
| **와이프** | ![supported](v.png) | ![supported](v.png) |
| **도형** | ![supported](v.png) | ![supported](v.png) |
| **무작위 막대** | ![supported](v.png) | ![supported](v.png) |
| **축소 및 회전** | ![not supported](x.png) | ![supported](v.png) |
| **줌** | ![supported](v.png) | ![supported](v.png) |
| **스위블** | ![supported](v.png) | ![supported](v.png) |
| **바운스** | ![supported](v.png) | ![supported](v.png) |

**동작 경로**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **선** | ![supported](v.png) | ![supported](v.png) |
| **호** | ![supported](v.png) | ![supported](v.png) |
| **회전** | ![supported](v.png) | ![supported](v.png) |
| **도형** | ![supported](v.png) | ![supported](v.png) |
| **루프** | ![supported](v.png) | ![supported](v.png) |
| **사용자 정의 경로** | ![supported](v.png) | ![supported](v.png) |

## **자주 묻는 질문**

**암호로 보호된 프레젠테이션을 변환할 수 있나요?**

예, Aspose.Slides는 암호로 보호된 프레젠테이션을 처리할 수 있습니다. 이러한 파일을 처리할 때는 올바른 비밀번호를 제공하여 라이브러리가 프레젠테이션 내용을 액세스할 수 있도록 해야 합니다.

**Aspose.Slides가 클라우드 솔루션에서 사용을 지원하나요?**

예, Aspose.Slides는 클라우드 애플리케이션 및 서비스에 통합될 수 있습니다. 이 라이브러리는 서버 환경에서 동작하도록 설계되어 파일의 배치 처리에 높은 성능과 확장성을 보장합니다.

**변환 시 프레젠테이션 크기에 제한이 있나요?**

Aspose.Slides는 사실상 모든 크기의 프레젠테이션을 처리할 수 있습니다. 하지만 매우 큰 파일을 작업할 경우 추가 시스템 리소스가 필요할 수 있으며, 성능 향상을 위해 프레젠테이션을 최적화하는 것이 권장되기도 합니다.