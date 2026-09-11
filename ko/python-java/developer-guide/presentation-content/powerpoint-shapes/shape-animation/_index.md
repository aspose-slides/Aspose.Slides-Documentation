---
title: Python via Java를 사용하여 프레젠테이션에 모양 애니메이션 적용
linktitle: 모양 애니메이션
type: docs
weight: 60
url: /ko/python-java/shape-animation/
keywords:
- 모양
- 애니메이션
- 효과
- 애니메이션 모양
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 모양 애니메이션, 타이밍, 사운드, 애니메이션 후 동작 및 애니메이션 텍스트를 추가, 검사 및 사용자 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Python via Java는 슬라이드 애니메이션을 슬라이드 타임라인의 효과로 나타냅니다. 효과에는 대상 모양, 애니메이션 유형 및 하위 유형, 트리거, 타이밍 설정, 그리고 사운드나 애니메이션 후 동작과 같은 선택적 속성이 있습니다.

타임라인에는 두 종류의 시퀀스가 포함됩니다:
- **주 시퀀스**는 슬라이드가 진행될 때 재생됩니다.
- **대화형 시퀀스**는 트리거 모양을 클릭했을 때 시작됩니다.

텍스트 상자, 그림, 차트, 표 및 기타 슬라이드 개체는 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/)에서 파생되므로 대부분의 슬라이드 콘텐츠에 대해 동일한 [Sequence.addEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sequence/#addEffect) 메서드를 사용합니다. 사용 가능한 효과는 [EffectType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effecttype/) 클래스에 나열되어 있습니다.

## **모양 애니메이션 추가**

애니메이션을 추가하려면 슬라이드의 주 시퀀스를 가져오고 대상 모양, 효과 유형, 하위 유형 및 트리거와 함께 [Sequence.addEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sequence/#addEffect)를 호출합니다. 다른 모양을 클릭했을 때 시작되는 효과의 경우 해당 다른 모양을 트리거로 하는 대화형 시퀀스를 생성합니다.

다음 예제는 두 유형의 애니메이션을 모두 생성하고 결과를 `shape-animations.pptx`에 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

트리거는 효과가 시작되는 시점을 제어합니다:
- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effecttriggertype/#OnClick)은 주 시퀀스에서 클릭을 기다리거나 대화형 시퀀스에서 트리거 모양을 클릭할 때 작동합니다.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effecttriggertype/#WithPrevious)은 이전 효과와 함께 시작합니다.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effecttriggertype/#AfterPrevious)은 이전 효과가 끝났을 때 시작합니다.

그림, 차트 또는 다른 모양 유형을 애니메이션하려면 `target_shape` 대신 해당 객체를 [Sequence.addEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sequence/#addEffect)에 전달합니다. 차트 전용 그룹 옵션에 대해서는 [Animated Charts](/slides/ko/python-java/animated-charts/)를 참조하세요.

## **모양 애니메이션 읽기**

대상 모양을 알고 있는 경우 [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sequence/#getEffectsByShape)를 사용합니다. 모든 효과를 검사하려면 주 시퀀스와 모든 대화형 시퀀스를 열거하십시오. 열거를 사용하면 시퀀스가 인덱스 `0`에 효과가 있다고 가정하는 것을 방지합니다.

다음 예제는 주 시퀀스 및 대화형 효과가 있는 모양을 만들고, 해당 모양을 대상으로 하는 효과를 가져온 뒤 슬라이드의 모든 시퀀스를 열거합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

하나의 모양에 대한 효과만 필요하면 먼저 이름, 플레이스홀더 유형 또는 다른 안정적인 속성으로 모양을 식별한 다음 [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sequence/#getEffectsByShape)을 호출하십시오. [ShapeCollection.get_Item](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#get_Item)을 인덱스 `0`에서 항상 의도된 객체라고 가정하지 마세요.

## **상속된 플레이스홀더 효과 작업**

일반 슬라이드의 플레이스홀더는 레이아웃 슬라이드와 마스터 슬라이드에 해당하는 플레이스홀더로부터 애니메이션 동작을 상속받을 수 있습니다. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getBasePlaceholder)은 해당 부모 플레이스홀더를 반환하며, 부모가 없을 경우 `None`을 반환합니다.

다음 예제 프레젠테이션에서는 푸터가 일반 슬라이드에서는 **Random Bars**, 레이아웃 슬라이드에서는 **Split**, 마스터 슬라이드에서는 **Fly In** 효과를 가지고 있습니다.

![일반 슬라이드의 푸터 애니메이션 효과](slide-shape-animation.png)

![레이아웃 슬라이드의 푸터 플레이스홀더 애니메이션 효과](layout-shape-animation.png)

![마스터 슬라이드의 푸터 플레이스홀더 애니메이션 효과](master-shape-animation.png)

다음 예제는 새 프레젠테이션의 플레이스홀더 계층 구조를 사용합니다. 마스터 플레이스홀더, 레이아웃 플레이스홀더 및 일반 슬라이드의 해당 플레이스홀더에 효과를 추가합니다. 반환된 도형을 사용하기 전에 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getBasePlaceholder)에 대한 모든 호출을 확인합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **애니메이션 타이밍 변경**

PowerPoint **Timing** 대화 상자는 [Timing](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/) 속성과 매핑됩니다.

![애니메이션 효과에 대한 PowerPoint 타이밍 대화 상자](shape-animation.png)

- **Start**는 [Timing.getTriggerType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getTriggerType)에 매핑됩니다.
- **Duration**은 [Timing.getDuration](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getDuration)에 매핑되며, 초 단위입니다.
- **Delay**는 [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getTriggerDelayTime)에 매핑되며, 초 단위입니다.
- **Repeat**는 [Timing.getRepeatCount](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getRepeatUntilNextClick) 또는 [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getRepeatUntilEndSlide)에 매핑됩니다.
- **Rewind when done playing**은 [Timing.getRewind](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getRewind)에 매핑됩니다.

이 독립적인 예제는 효과를 추가하고, [Sequence.addEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sequence/#addEffect)가 반환한 객체를 통해 타이밍을 변경한 뒤 결과를 저장합니다. 반환된 [Effect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effect/) 참조를 유지하면 불필요한 컬렉션 인덱스를 피할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

반복 모드를 하나만 명시적으로 사용하십시오. 반복 횟수와 "until" 플래그를 함께 사용하면 뷰어마다 혼란스러운 결과가 나올 수 있습니다. 반복 모드를 변경할 때는 [Timing.setRepeatCount](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#setRepeatCount)를 호출하기 전에 [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#setRepeatUntilNextClick)와 [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#setRepeatUntilEndSlide)를 설정하세요. 두 플래그 중 하나를 설정하면 활성 반복 모드도 변경됩니다.

## **애니메이션 사운드 추가 및 추출**

애니메이션 효과는 [Effect.getSound](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effect/#getSound)을 통해 내장 오디오를 참조할 수 있습니다. [Effect.setStopPreviousSound](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effect/#setStopPreviousSound)은 이전 효과에 의해 시작된 오디오를 정지하도록 효과에 지시합니다.

### **효과에 사운드 추가**

다음 예제는 `animation-sound.wav`라는 로컬 오디오 파일이 있다고 가정합니다. 두 개의 효과를 생성하고 해당 파일을 첫 번째 효과의 사운드로 내장하며, 두 번째 효과가 사운드를 정지하도록 구성합니다. [Sequence.addEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sequence/#addEffect)가 반환한 객체를 사용하므로 시퀀스 인덱스가 필요하지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **내장된 효과 사운드 추출**

다음 예제는 `presentation-with-animation-sounds.pptx`라는 로컬 프레젠테이션이 있다고 가정합니다. 주 시퀀스와 대화형 시퀀스를 모두 스캔하고 모든 내장 효과 사운드를 `extracted-animation-sounds` 디렉터리에 기록합니다. 확장자는 [Audio.getContentType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/audio/#getContentType)가 제공하는 오디오 MIME 유형에서 선택됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"
    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

대용량 오디오 객체의 경우 전체 객체를 바이트 배열로 로드하는 대신 [Audio.getStream](https://reference.aspose.com/slides/ko/python-java/aspose.slides/audio/#getStream)을 사용하고 스트림을 파일에 복사하십시오.

## **애니메이션 후 동작 설정**

**After animation** 옵션은 효과가 끝난 후 모양에 대해 어떤 일이 발생하는지 제어합니다.

![After animation 설정을 표시하는 PowerPoint 효과 옵션 대화 상자](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/afteranimationtype/) 클래스는 모양을 변경하지 않음, 색상을 변경함, 애니메이션 후에 숨김, 다음 클릭 시 숨김을 지원합니다. 유형이 [AfterAnimationType.Color](https://reference.aspose.com/slides/ko/python-java/aspose.slides/afteranimationtype/#Color)인 경우 [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effect/#getAfterAnimationColor)도 설정합니다.

이 독립적인 예제는 효과를 생성하고 반환된 효과 객체를 통해 애니메이션 후 동작을 설정한 뒤 결과를 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/ko/python-java/aspose.slides/afteranimationtype/#Color) 유형을 다른 것으로 변경하면 애니메이션 후 색상 설정이 삭제됩니다.

## **텍스트 애니메이션**

텍스트 애니메이션에는 두 가지 관련 제어가 있습니다:
- [TextAnimation.getBuildType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textanimation/#getBuildType)은 단락이 함께 표시될지 단락 수준별로 표시될지를 제어합니다.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effect/#getAnimateTextType)은 텍스트가 한 번에 전체, 단어별, 문자별로 표시될지를 제어합니다. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effect/#getDelayBetweenTextParts)은 단어 또는 문자 사이의 지연을 설정합니다. 양수 값은 효과 기간의 백분율이며, 음수 값은 초 단위 지연입니다.

다음 독립적인 예제는 텍스트 상자 안의 단어들을 애니메이션합니다. [BuildType.AsOneObject](https://reference.aspose.com/slides/ko/python-java/aspose.slides/buildtype/#AsOneObject)은 단락별 빌드를 비활성화하여 단어 설정이 전체 텍스트 프레임에 적용되도록 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

단락별로 텍스트 상자를 빌드하려면 [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ko/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (또는 다른 단락 수준)를 설정하십시오. 단일 단락에 자체 효과를 적용하려면 [Paragraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraph/)을 받아들이는 [Sequence.addEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sequence/#addEffect) 오버로드를 사용하세요. 단락 수준 예제는 [Animated Text](/slides/ko/python-java/animated-text/)를 참고하십시오.

## **내보내기 및 호환성 참고 사항**

- PPT 또는 PPTX로 저장하면 애니메이션 모델이 보존되지만 최종 재생은 프레젠테이션 뷰어에 의해 제어됩니다.
- PDF 및 정적 이미지는 애니메이션을 재생하지 않습니다. 출력에 움직임이 필요할 경우 [HTML5 export](/slides/ko/python-java/export-to-html5/), 애니메이션 GIF 또는 [video conversion](/slides/ko/python-java/convert-powerpoint-to-video/)를 사용하십시오.
- HTML5의 경우 [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/html5options/#setAnimateShapes)를 활성화하고 필요에 따라 [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/html5options/#setAnimateTransitions)를 사용하십시오.
- 비디오 렌더링은 일반적인 입장, 강조, 종료 및 모션 경로 효과를 많이 지원하지만 모든 PowerPoint 효과를 지원하지는 않습니다. 현재 [supported animations and effects](/slides/ko/python-java/convert-powerpoint-to-video/#supported-animations-and-effects)를 확인하고 대상 Aspose.Slides 버전으로 중요한 프레젠테이션을 테스트하십시오.
- 고급 사용자 정의 효과 및 다른 프레젠테이션 형식에서 가져온 효과는 파일에 보존될 수 있지만 PowerPoint, HTML5 또는 비디오에서 다르게 렌더링될 수 있습니다. 효과 이름에만 의존하지 말고 내보낸 결과를 검증하십시오.

## **FAQ**

**왜 애니메이션은 PowerPoint에서는 보이지만 PDF에서는 보이지 않나요?**

PDF는 정적 형식이므로 애니메이션 및 슬라이드 전환이 재생되지 않습니다. 움직임을 유지해야 할 경우 HTML5, 애니메이션 GIF 또는 비디오로 내보내십시오.

**왜 효과가 비디오에서 다르게 재생되나요?**

비디오 내보내기는 원본 PowerPoint 동작을 저장하는 것이 아니라 애니메이션을 렌더링합니다. 일부 고급 효과는 지원되지 않거나 근사치로 처리됩니다. 지원되는 효과 표를 검토하고 실제 프레젠테이션을 생산에 사용하기 전에 테스트하십시오.

**모양을 앞으로 또는 뒤로 이동하면 애니메이션 순서가 변경되나요?**

아니요. 모양의 Z‑order는 겹침을 제어하고, 시퀀스 순서와 트리거는 애니메이션 재생을 제어합니다. 다른 재생 순서가 필요하면 타임라인을 변경하십시오.