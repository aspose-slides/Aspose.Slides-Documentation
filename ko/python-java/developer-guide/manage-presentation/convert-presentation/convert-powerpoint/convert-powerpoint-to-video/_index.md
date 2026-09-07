---
title: Python에서 PowerPoint 프레젠테이션을 비디오로 변환
linktitle: PowerPoint를 비디오로
type: docs
weight: 130
url: /ko/python-java/convert-powerpoint-to-video/
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
- 파워포인트
- 파이썬
- 자바
- Aspose.Slides
description: "Python을 통해 Java에서 PowerPoint 프레젠테이션을 MP4 비디오로 변환합니다. Aspose.Slides로 프레임을 생성하고 FFmpeg으로 인코딩하며, 애니메이션과 전환을 포함합니다."
---
## **개요**

PowerPoint 또는 OpenDocument 프레젠테이션을 비디오로 변환하면 프레젠테이션 애플리케이션을 열지 않고도 비디오 플레이어에서 내용을 시청할 수 있습니다. Aspose.Slides for Python via Java은 프레젠테이션 애니메이션 및 전환을 이미지 프레임으로 렌더링합니다. FFmpeg과 같은 별도의 인코더가 이러한 프레임을 비디오 파일로 결합합니다.

{{% alert color="info" title="참고" %}}
온라인 [PowerPoint to Video converter](https://products.aspose.app/slides/ko/video)을 사용해 프레젠테이션을 비디오로 변환하는 작업을 직접 확인해 보세요.
{{% /alert %}}

## **PowerPoint를 비디오로 변환**

변환은 두 단계로 진행됩니다. 선택한 프레임 속도로 PNG 프레임을 생성한 뒤 이미지 시퀀스를 MP4로 인코딩합니다. 두 단계에서 동일한 프레임 속도를 사용해야 애니메이션 타이밍이 유지됩니다.

예제를 실행하기 전에:

1. [Aspose.Slides for Python via Java](/slides/ko/python-java/installation/)를 설정합니다.
2. [FFmpeg](https://ffmpeg.org/download.html)을 다운로드하고 실행 파일을 `PATH`에 추가합니다. 예제에서는 `libx264` 인코더가 포함된 빌드를 사용합니다.
3. 쓰기 가능한 디렉터리에서 다음 Python 코드를 실행합니다.

예제는 입장 및 퇴장 애니메이션이 있는 웃는 모양을 만들고, 30 FPS로 프레임을 렌더링한 뒤 FFmpeg을 호출해 `output.mp4`를 생성합니다. 새 프레임 디렉터리를 사용하면 이전 실행의 프레임이 비디오에 포함되는 것을 방지할 수 있습니다.

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

기존 파일을 변환하려면 경로와 함께 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)을 초기화하고 모양 및 애니메이션 생성 문장을 생략하면 됩니다.

FFmpeg 명령은 번호가 매겨진 [image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2)를 읽고, 홀수 차원을 짝수 값으로 패딩한 뒤 `yuv420p` 픽셀 포맷으로 H.264 비디오를 기록합니다. `-n` 옵션은 기존 출력 파일을 덮어쓰는 것을 방지합니다. 생성된 PNG 파일은 프레임 디렉터리에 남아 있으며, 더 이상 필요하지 않을 때 삭제하십시오.

{{% alert color="info" title="참고" %}}
이 예제는 이미지 프레임만 인코드합니다. 내레이션이나 포함된 프레젠테이션 오디오가 출력 비디오에 추가되지 않습니다.
{{% /alert %}}

## **비디오 효과**

애니메이션은 슬라이드 개체가 나타나고, 이동하고, 사라지는 방식을 제어합니다. 전환은 슬라이드 간 전환을 제어합니다. 비디오 프레임을 생성하기 전에 이러한 효과를 추가하십시오.

[PowerPoint Animation](/slides/ko/python-java/powerpoint-animation/), [Shape Animation](/slides/ko/python-java/shape-animation/), [Shape Effects](/slides/ko/python-java/shape-effect/), 및 [Slide Transitions](/slides/ko/python-java/slide-transition/)을 참조하십시오.

### **슬라이드 전환 추가**

다음 독립형 예제는 두 개의 슬라이드가 있는 프레젠테이션을 생성합니다. 두 번째 슬라이드에는 마젠타 배경과 푸시 전환이 적용됩니다. 프레젠테이션을 저장한 뒤 위의 프레임 생성 예제 입력으로 사용하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **단락 애니메이션**

텍스트는 단락별로 나타날 수 있습니다. 이 예제는 순차적인 페이드 입장 효과가 적용된 세 개의 단락을 만들고, 각 효과는 이전 효과 이후 1초씩 지연됩니다. 저장된 `paragraphs.pptx` 파일을 비디오 변환 예제의 입력으로 사용하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **비디오 변환 클래스**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationanimationsgenerator/)는 슬라이드에 대한 애니메이션 이벤트를 생성합니다. 프레젠테이션에서 생성하면 슬라이드 크기가 프레임에 사용됩니다. 기본 지연을 밀리초 단위로 설정하려면 [setDefaultDelay](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay)를 사용하십시오.

[PresentationPlayer](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationplayer/)는 생성된 애니메이션을 생성자에 전달된 프레임 속도로 샘플링합니다. JPype를 통해 [setFrameTick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationplayer/#setFrameTick)으로 Python 콜백을 등록한 뒤, [run](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationanimationsgenerator/#run)을 호출해 프레임을 생성합니다. 첫 번째 예제는 파일 이름이 FFmpeg 입력 시퀀스와 일치하도록 자체 0 기반 카운터를 사용합니다.

개별 애니메이션 상태에 대해서는 [setNewAnimation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation)으로 콜백을 등록하십시오. 콜백은 선택한 시간에 위치시킬 수 있는 애니메이션 플레이어를 받습니다. 다음 예제는 각 생성된 애니메이션의 첫 번째와 마지막 프레임을 고유 파일 이름으로 저장합니다:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **지원되는 애니메이션 및 효과**

다음 표는 Java 변환 문서에 설명된 렌더링 지원을 요약합니다. 프레젠테이션이 지원되지 않는 효과를 사용할 경우 생성된 프레임을 미리 확인하십시오.

**입장**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | 아니오 | 예 |
| **Fade** | 예 | 예 |
| **Fly In** | 예 | 예 |
| **Float In** | 예 | 예 |
| **Split** | 예 | 예 |
| **Wipe** | 예 | 예 |
| **Shape** | 예 | 예 |
| **Wheel** | 예 | 예 |
| **Random Bars** | 예 | 예 |
| **Grow & Turn** | 아니오 | 예 |
| **Zoom** | 예 | 예 |
| **Swivel** | 예 | 예 |
| **Bounce** | 예 | 예 |

**강조**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | 아니오 | 예 |
| **Color Pulse** | 아니오 | 예 |
| **Teeter** | 예 | 예 |
| **Spin** | 예 | 예 |
| **Grow/Shrink** | 아니오 | 예 |
| **Desaturate** | 아니오 | 예 |
| **Darken** | 아니오 | 예 |
| **Lighten** | 아니오 | 예 |
| **Transparency** | 아니오 | 예 |
| **Object Color** | 아니오 | 예 |
| **Complementary Color** | 아니오 | 예 |
| **Line Color** | 아니오 | 예 |
| **Fill Color** | 아니오 | 예 |

**퇴장**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | 아니오 | 예 |
| **Fade** | 예 | 예 |
| **Fly Out** | 예 | 예 |
| **Float Out** | 예 | 예 |
| **Split** | 예 | 예 |
| **Wipe** | 예 | 예 |
| **Shape** | 예 | 예 |
| **Random Bars** | 예 | 예 |
| **Shrink & Turn** | 아니오 | 예 |
| **Zoom** | 예 | 예 |
| **Swivel** | 예 | 예 |
| **Bounce** | 예 | 예 |

**모션 경로**:

| 애니메이션 유형 | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | 예 | 예 |
| **Arcs** | 예 | 예 |
| **Turns** | 예 | 예 |
| **Shapes** | 예 | 예 |
| **Loops** | 예 | 예 |
| **Custom Path** | 예 | 예 |

## **FAQ**

**Aspose.Slides가 MP4 파일을 직접 생성합니까?**

아니오. Aspose.Slides는 프레젠테이션 프레임을 생성합니다. FFmpeg과 같은 비디오 인코더를 사용해 프레임을 MP4 파일로 결합해야 합니다.

**비디오가 예상보다 빠르거나 느리게 재생되는 이유는 무엇인가요?**

프레임 생성과 인코더 입력 프레임 속도를 동일하게 사용하십시오. 속도가 일치하지 않으면 이미지 시퀀스의 재생 시간이 변합니다.

**비밀번호로 보호된 프레젠테이션을 변환할 수 있나요?**

예. [보호된 프레젠테이션 로드](/slides/ko/python-java/password-protected-presentation/) 시 올바른 비밀번호를 제공한 뒤, 로드된 콘텐츠에서 프레임을 생성하십시오.

**이 워크플로우가 프레젠테이션 오디오를 보존합니까?**

예제는 이미지 프레임만 내보내므로 결과 비디오는 무음입니다. 오디오를 포함하려면 비디오 인코딩 중에 별도로 오디오 트랙을 제공하십시오.

**임시 디스크 사용량을 줄이는 방법은?**

프레임 크기를 작게 하거나 FPS를 낮추고, 인코딩이 성공하면 임시 PNG 파일을 삭제하십시오. 설정을 낮출 때 비디오 품질을 확인하십시오.