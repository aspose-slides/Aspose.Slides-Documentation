---
title: Python으로 PowerPoint 프레젠테이션을 비디오로 변환
linktitle: PowerPoint를 비디오로
type: docs
weight: 130
url: /ko/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint 비디오 변환
- PowerPoint를 비디오로 변환
- 프레젠테이션을 비디오로
- 프레젠테이션을 비디오로 변환
- PPT 비디오 변환
- PPT를 비디오로 변환
- PPTX 비디오 변환
- PPTX를 비디오로 변환
- ODP 비디오 변환
- ODP를 비디오로 변환
- PowerPoint MP4 변환
- PowerPoint를 MP4로 변환
- 프레젠테이션 MP4 변환
- 프레젠테이션을 MP4로 변환
- PPT MP4 변환
- PPT를 MP4로 변환
- PPTX MP4 변환
- PPTX를 MP4로 변환
- PowerPoint 비디오 변환
- 프레젠테이션 비디오 변환
- PPT 비디오 변환
- PPTX 비디오 변환
- ODP 비디오 변환
- Python 비디오 변환
- PowerPoint
- Python
- Aspose.Slides
description: "Python을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 비디오로 변환하는 방법을 배웁니다. 샘플 코드와 자동화 기술을 찾아 워크플로를 효율화하세요."
---
## **소개**

PowerPoint 또는 OpenDocument 프레젠테이션을 비디오로 변환하면 다음과 같은 이점을 얻을 수 있습니다:

**접근성 향상:** 플랫폼에 관계없이 모든 장치에 기본적으로 비디오 플레이어가 탑재되어 있어 전통적인 프레젠테이션 애플리케이션에 비해 사용자가 비디오를 열거나 재생하기가 더 쉽습니다.

**도달 범위 확대:** 비디오는 더 넓은 청중에게 다가가고 정보를 보다 매력적인 형식으로 제시할 수 있게 합니다. 설문 조사와 통계에 따르면 사람들은 다른 형태보다 비디오 콘텐츠를 시청하고 소비하는 것을 선호하여 메시지의 효과가 높아집니다.

{{% alert color="primary" %}} 

여기에서 설명한 프로세스를 실시간으로 효과적으로 구현하는 [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/ko/video) 를 확인해 보세요.

{{% /alert %}} 

[Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/ko/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/) 에서 프레젠테이션을 비디오로 변환하는 지원을 구현했습니다.

* Aspose.Slides for Python을 사용하여 지정된 프레임 레이트(FPS)로 프레젠테이션 슬라이드에서 프레임을 생성합니다.
* 그런 다음 ffmpeg와 같은 타사 유틸리티를 사용하여 이러한 프레임을 비디오로 컴파일합니다.

## **PowerPoint 프레젠테이션을 비디오로 변환**

1. pip install 명령을 사용하여 Aspose.Slides for Python을 프로젝트에 추가합니다: `pip install aspose-slides==24.4.0`
2. ffmpeg를 [여기](https://ffmpeg.org/download.html)에서 다운로드하거나 패키지 관리자를 통해 설치합니다.
3. `ffmpeg`가 `PATH`에 있는지 확인합니다. 그렇지 않으면 전체 경로를 사용하여 ffmpeg를 실행합니다(예: Windows에서는 `C:\ffmpeg\ffmpeg.exe`, Linux에서는 `/opt/ffmpeg/ffmpeg`).
4. PowerPoint를 비디오로 변환하는 코드를 실행합니다.

다음 Python 코드는 모양과 두 개의 애니메이션 효과가 포함된 프레젠테이션을 비디오로 변환하는 방법을 보여줍니다:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```

## **비디오 효과**

Aspose.Slides for Python을 사용하여 PowerPoint 프레젠테이션을 비디오로 변환할 때 다양한 비디오 효과를 적용하여 출력의 시각적 품질을 향상시킬 수 있습니다. 이러한 효과는 부드러운 전환, 애니메이션 및 기타 시각 요소를 추가하여 최종 비디오에서 슬라이드의 모양을 제어할 수 있게 합니다. 이 섹션에서는 사용 가능한 비디오 효과 옵션을 설명하고 적용 방법을 보여줍니다.

{{% alert color="primary" %}} 

[PowerPoint 애니메이션](https://docs.aspose.com/slides/ko/python-net/powerpoint-animation/), [도형 애니메이션](https://docs.aspose.com/slides/ko/python-net/shape-animation/), 및 [도형 효과](https://docs.aspose.com/slides/ko/python-net/shape-effect/) 을 확인하십시오.

{{% /alert %}} 

애니메이션과 전환은 슬라이드쇼를 더욱 매력적이고 흥미롭게 만들며, 비디오에도 동일하게 적용됩니다. 이전 프레젠테이션 코드에 또 다른 슬라이드와 전환을 추가해 보겠습니다:

```python
import aspose.pydrawing as drawing

# 웃는 모양을 추가하고 애니메이션을 적용합니다.
# ...

# 새 슬라이드를 추가하고 애니메이션 전환을 적용합니다.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides for Python은 텍스트 애니메이션도 지원합니다. 이 예제에서는 객체의 단락을 순차적으로 표시하도록 애니메이션을 적용하며, 각 단락 사이에 1초 지연을 두었습니다:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 텍스트와 애니메이션을 추가합니다.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # 프레임을 비디오로 변환합니다.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **비디오 변환 클래스**

PowerPoint를 비디오로 변환하는 작업을 수행하려면 Aspose.Slides for Python이 [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/presentationenumerableframesgenerator/) 를 제공합니다.

`PresentationEnumerableFramesGenerator`는 생성자를 통해 비디오의 프레임 크기(나중에 생성될)와 FPS(초당 프레임) 값을 설정할 수 있게 합니다. 프레젠테이션 인스턴스를 전달하면 해당 프레젠테이션의 `Presentation.SlideSize`가 사용됩니다.

프레젠테이션의 모든 애니메이션을 동시에 재생하려면 `PresentationEnumerableFramesGenerator.enumerate_frames` 메서드를 사용합니다. 이 메서드는 슬라이드 컬렉션을 받아 순차적으로 [EnumerableFrameArgs](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/enumerableframeargs/) 를 반환합니다. 그런 다음 `EnumerableFrameArgs.get_frame()`을 사용하여 각 비디오 프레임을 얻습니다.

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

그런 다음 생성된 프레임을 비디오로 컴파일할 수 있습니다. 자세한 내용은 [Convert PowerPoint to Video](https://docs.aspose.com/slides/ko/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video) 섹션을 참조하십시오.

## **지원되는 애니메이션 및 효과**

Aspose.Slides for Python을 사용하여 PowerPoint 프레젠테이션을 비디오로 변환할 때 출력에서 지원되는 애니메이션 및 효과를 이해하는 것이 중요합니다. Aspose.Slides는 페이드, 플라이 인, 줌, 스핀과 같은 일반적인 입장, 종료, 강조 효과를 광범위하게 지원합니다. 그러나 일부 고급 또는 사용자 정의 애니메이션은 완전히 보존되지 않거나 최종 비디오에서 다르게 표시될 수 있습니다. 이 섹션에서는 지원되는 애니메이션 및 효과를 정리합니다.

**Entrance**:

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

**Emphasis**:

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

**Exit**:

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

**Motion Paths**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Arcs** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Turns** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Shapes** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Loops** | ![지원됨](v.png) | ![지원됨](v.png) |
| **Custom Path** | ![지원됨](v.png) | ![지원됨](v.png) |

## **지원되는 슬라이드 전환 효과**

슬라이드 전환 효과는 비디오에서 슬라이드 간의 부드럽고 시각적으로 매력적인 변화를 만드는 데 중요한 역할을 합니다. Aspose.Slides for Python은 원본 프레젠테이션의 흐름과 스타일을 유지하도록 다양한 일반 전환 효과를 지원합니다. 이 섹션에서는 변환 과정에서 지원되는 전환 효과를 강조합니다.

**섬세**:

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

**비밀번호로 보호된 프레젠테이션을 변환할 수 있나요?**

예, Aspose.Slides for Python은 비밀번호로 보호된 프레젠테이션을 처리할 수 있습니다. 이러한 파일을 처리할 때는 올바른 비밀번호를 제공하여 라이브러리가 프레젠테이션 콘텐츠에 접근할 수 있도록 해야 합니다.

**Aspose.Slides for Python이 클라우드 솔루션에서 사용을 지원하나요?**

예, Aspose.Slides for Python은 클라우드 애플리케이션 및 서비스에 통합할 수 있습니다. 이 라이브러리는 서버 환경에서 작동하도록 설계되어 파일 일괄 처리 시 높은 성능과 확장성을 보장합니다.

**변환 중 프레젠테이션 크기 제한이 있나요?**

Aspose.Slides for Python은 사실상 모든 크기의 프레젠테이션을 처리할 수 있습니다. 하지만 매우 큰 파일을 다룰 경우 추가 시스템 리소스가 필요할 수 있으며, 성능을 향상시키기 위해 프레젠테이션을 최적화하는 것이 권장될 때도 있습니다.