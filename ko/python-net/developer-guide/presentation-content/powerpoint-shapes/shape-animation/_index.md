---
title: Python을 사용한 프레젠테이션의 도형 애니메이션 적용
linktitle: 도형 애니메이션
type: docs
weight: 60
url: /ko/python-net/shape-animation/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 도형 애니메이션, 타이밍, 사운드, 애니메이션 후 동작 및 텍스트 애니메이션을 추가, 검사 및 사용자 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Python via .NET는 슬라이드 애니메이션을 슬라이드 타임라인의 효과로 나타냅니다. 효과에는 대상 도형, 애니메이션 유형 및 하위 유형, 트리거, 타이밍 설정, 그리고 사운드나 애니메이션 후 동작과 같은 선택적 속성이 있습니다.

타임라인에는 두 종류의 시퀀스가 있습니다:

- **주 시퀀스**는 슬라이드가 진행될 때 재생됩니다.
- **대화형 시퀀스**는 트리거 도형이 클릭될 때 시작됩니다.

텍스트 상자, 그림, 차트, 표 및 기타 슬라이드 개체는 모두 [IShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ishape/)을 구현하므로 대부분의 슬라이드 콘텐츠에 대해 동일한 [Sequence.add_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/add_effect/) 메서드를 사용합니다. 사용 가능한 효과는 [EffectType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effecttype/) 열거형에 나열되어 있습니다.

## **도형 애니메이션 추가**

애니메이션을 추가하려면 슬라이드의 주 시퀀스를 가져온 다음 대상 도형, 효과 유형, 하위 유형 및 트리거와 함께 [Sequence.add_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/add_effect/)를 호출합니다. 다른 도형을 클릭했을 때 효과가 시작되도록 하려면 해당 도형을 트리거로 하는 대화형 시퀀스를 생성합니다.

다음 예제는 두 종류의 애니메이션을 모두 생성하고 결과를 `shape-animations.pptx` 파일로 저장합니다.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

트리거는 효과가 시작되는 시점을 제어합니다:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effecttriggertype/)은 주 시퀀스에서는 클릭을 기다리며, 대화형 시퀀스에서는 트리거 도형의 클릭을 기다립니다.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effecttriggertype/)은 이전 효과와 동시에 시작합니다.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effecttriggertype/)은 이전 효과가 끝난 후 시작합니다.

그림, 차트 또는 기타 도형 유형에 애니메이션을 적용하려면 `target_shape` 대신 해당 객체를 [Sequence.add_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/add_effect/)에 전달합니다. 차트 전용 그룹 옵션은 [Animated Charts](/slides/ko/python-net/animated-charts/)를 참조하십시오.

## **도형 애니메이션 읽기**

대상 도형을 알고 있을 때는 [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/get_effects_by_shape/)를 사용합니다. 모든 효과를 확인하려면 주 시퀀스와 모든 대화형 시퀀스를 순회합니다. 순회를 사용하면 시퀀스가 인덱스 `0`에 효과를 포함한다고 가정하는 일을 피할 수 있습니다.

다음 예제는 주‑시퀀스와 대화형 효과가 모두 적용된 도형을 만들고, 해당 도형을 대상으로 하는 효과를 가져온 다음, 슬라이드의 모든 시퀀스를 순회합니다.

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

하나의 도형에 대한 효과만 필요하다면 먼저 이름, 플레이스홀더 유형 또는 다른 안정적인 속성으로 도형을 식별한 뒤 [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/get_effects_by_shape/)를 호출하십시오. 인덱스 `0`에 있는 도형이 항상 원하는 객체라고 가정하지 마세요.

## **상속된 플레이스홀더 효과 작업**

일반 슬라이드의 플레이스홀더는 레이아웃 슬라이드와 마스터 슬라이드에 있는 해당 플레이스홀더로부터 애니메이션 동작을 상속받을 수 있습니다. [Shape.get_base_placeholder](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/get_base_placeholder/)는 상위 플레이스홀더를 반환하며, 상위가 없을 경우 `None`을 반환합니다.

다음 예제 프레젠테이션에서 바닥글은 일반 슬라이드에서는 **Random Bars**, 레이아웃 슬라이드에서는 **Split**, 마스터 슬라이드에서는 **Fly In** 효과를 가지고 있습니다.

![일반 슬라이드의 바닥글 애니메이션 효과](slide-shape-animation.png)

![레이아웃 슬라이드의 바닥글 플레이스홀더 애니메이션 효과](layout-shape-animation.png)

![마스터 슬라이드의 바닥글 플레이스홀더 애니메이션 효과](master-shape-animation.png)

다음 예제는 플레이스홀더 계층 구조 자체를 구축합니다. 마스터 플레이스홀더, 레이아웃 플레이스홀더 및 일반 슬라이드의 해당 플레이스홀더에 효과를 추가합니다. [Shape.get_base_placeholder](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/get_base_placeholder/)를 호출한 후 반환된 도형이 `None`이 아닌지 확인하고 사용합니다.

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **애니메이션 타이밍 변경**

PowerPoint **Timing** 대화상자는 [Timing](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/) 속성과 매핑됩니다.

![애니메이션 효과에 대한 PowerPoint 타이밍 대화상자](shape-animation.png)

- **시작**은 [Timing.trigger_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/trigger_type/)에 매핑됩니다.
- **기간**은 [Timing.duration](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/duration/)에 매핑되며, 초 단위입니다.
- **지연**은 [Timing.trigger_delay_time](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/trigger_delay_time/)에 매핑되며, 초 단위입니다.
- **반복**은 [Timing.repeat_count](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/repeat_until_next_click/) 또는 [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/repeat_until_end_slide/)에 매핑됩니다.
- **재생이 끝난 후 되감기**는 [Timing.rewind](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/rewind/)에 매핑됩니다.

이 독립 예제는 효과를 추가하고, [Sequence.add_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/add_effect/)가 반환한 객체를 통해 타이밍을 변경한 뒤 결과를 저장합니다. 반환된 [Effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effect/) 참조를 유지하면 불필요한 컬렉션 인덱스를 피할 수 있습니다.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

반복 모드를 하나만 사용하십시오. 반복 횟수와 “until” 플래그를 함께 사용하면 뷰어마다 혼란스러운 결과가 나타날 수 있습니다. 반복 모드를 변경할 때는 [Timing.repeat_until_next_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/repeat_until_next_click/)와 [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/repeat_until_end_slide/)를 먼저 설정하고, 마지막에 [Timing.repeat_count](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/repeat_count/)를 설정하십시오. 플래그를 설정하면 활성 반복 모드도 변경되기 때문입니다.

## **애니메이션 사운드 추가 및 추출**

애니메이션 효과는 [Effect.sound](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effect/sound/)을 통해 임베드된 오디오를 참조할 수 있습니다. [Effect.stop_previous_sound](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effect/stop_previous_sound/)는 이전 효과가 시작한 오디오를 중지하도록 효과에 지시합니다.

### **효과에 사운드 추가**

다음 예제는 `animation-sound.wav`라는 로컬 오디오 파일이 존재한다는 전제하에 동작합니다. 두 개의 효과를 만들고 첫 번째 효과에 해당 파일을 사운드로 임베드하며, 두 번째 효과는 사운드를 중지하도록 구성합니다. [Sequence.add_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/add_effect/)가 반환한 객체를 사용하므로 시퀀스 인덱스가 필요하지 않습니다.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **임베드된 효과 사운드 추출**

다음 예제는 `presentation-with-animation-sounds.pptx`라는 로컬 프레젠테이션 파일이 존재한다는 전제하에 동작합니다. 주 시퀀스와 대화형 시퀀스를 모두 스캔하여 모든 임베드된 효과 사운드를 `extracted-animation-sounds` 디렉터리에 저장합니다. 파일 확장자는 [Audio.content_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audio/content_type/)에서 제공된 오디오 MIME 타입을 기반으로 선택됩니다.

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

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
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

대용량 오디오 객체의 경우 [Audio.get_stream](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audio/get_stream/)을 사용해 스트림을 파일에 복사하는 것이 전체 객체를 바이트 배열로 로드하는 것보다 효율적입니다.

## **애니메이션 후 동작 설정**

**After animation** 옵션은 효과가 끝난 후 도형에 적용되는 동작을 제어합니다.

![PowerPoint 효과 옵션 대화상자에 표시된 After animation 설정](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/afteranimationtype/) 열거형은 도형을 그대로 두는 경우, 색상을 변경하는 경우, 애니메이션 후 도형을 숨기는 경우, 또는 다음 클릭 시 숨기는 경우를 지원합니다. 유형이 [AfterAnimationType.COLOR](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/afteranimationtype/)인 경우에는 [Effect.after_animation_color](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effect/after_animation_color/)도 함께 설정해야 합니다.

이 독립 예제는 효과를 생성하고, 반환된 효과 객체를 통해 애니메이션 후 동작을 설정한 뒤 결과를 저장합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

[AfterAnimationType.COLOR](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/afteranimationtype/) 유형을 다른 값으로 변경하면 애니메이션 후 색상 설정이 자동으로 지워집니다.

## **텍스트 애니메이션**

텍스트 애니메이션에는 두 가지 관련 제어 항목이 있습니다:

- [TextAnimation.build_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/textanimation/build_type/)은 단락을 동시에 표시할지 단락 수준별로 표시할지를 결정합니다.
- [Effect.animate_text_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effect/animate_text_type/)은 텍스트가 한 번에, 단어별로 또는 글자별로 표시될지를 결정합니다. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effect/delay_between_text_parts/)은 단어 혹은 글자 사이의 지연을 설정합니다. 양수 값은 효과 기간에 대한 백분율이며, 음수 값은 초 단위 지연을 의미합니다.

다음 독립 예제는 텍스트 상자 안의 단어들을 순차적으로 애니메이션화합니다. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/buildtype/)를 사용하면 단락별 빌드가 비활성화되어 단어 설정이 전체 텍스트 프레임에 적용됩니다.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

단락별로 텍스트 상자를 빌드하려면 [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/buildtype/)(또는 다른 단락 레벨)를 설정하십시오. 단일 단락에 자체 효과를 적용하려면 [IParagraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iparagraph/)를 인수로 받는 [Sequence.add_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/add_effect/) 오버로드를 사용합니다. 단락 수준 예제는 [Animated Text](/slides/ko/python-net/animated-text/)를 참고하세요.

## **내보내기 및 호환성 참고 사항**

- PPT 또는 PPTX로 저장하면 애니메이션 모델이 보존되지만 최종 재생은 프레젠테이션 뷰어에 의해 제어됩니다.
- PDF와 정적 이미지 형식은 애니메이션을 재생하지 않습니다. 모션을 보여야 할 경우 [HTML5 export](/slides/ko/python-net/export-to-html5/), 애니메이트 GIF 또는 [비디오 변환](/slides/ko/python-net/convert-powerpoint-to-video/)을 사용하십시오.
- HTML5에서는 [Html5Options.animate_shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/html5options/animate_shapes/)를 활성화하고 필요에 따라 [Html5Options.animate_transitions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/html5options/animate_transitions/)도 활성화하십시오.
- 비디오 렌더링은 일반적인 입장, 강조, 종료 및 움직임 경로 효과를 많이 지원하지만 모든 PowerPoint 효과를 지원하지는 않습니다. 현재 지원되는 [애니메이션 및 효과](/slides/ko/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) 목록을 확인하고 대상 Aspose.Slides 버전으로 중요한 프레젠테이션을 테스트하십시오.
- 고급 사용자 정의 효과 및 다른 프레젠테이션 형식에서 가져온 효과는 파일에 보존될 수 있으나 PowerPoint, HTML5 또는 비디오에서 다르게 렌더링될 수 있습니다. 효과 이름만 믿지 말고 내보낸 결과를 반드시 검증하십시오.

## **FAQ**

**PowerPoint에서는 애니메이션이 보이지만 PDF에서는 보이지 않는 이유는 무엇인가요?**

PDF는 정적 형식이므로 애니메이션과 슬라이드 전환이 재생되지 않습니다. 모션을 유지해야 할 경우 HTML5, 애니메이트 GIF 또는 비디오로 내보내십시오.

**비디오에서 효과가 다르게 재생되는 이유는 무엇인가요?**

비디오 내보내기는 원본 PowerPoint 동작을 저장하는 것이 아니라 애니메이션을 렌더링합니다. 일부 고급 효과는 지원되지 않거나 근사치로 처리됩니다. 지원되는 효과 표를 검토하고 실제 프레젠테이션을 테스트하십시오.

**도형을 앞이나 뒤로 이동하면 애니메이션 순서가 바뀌나요?**

아니요. 도형의 Z‑order는 겹침을 제어하고, 시퀀스 순서와 트리거가 애니메이션 재생 순서를 제어합니다. 재생 순서를 바꾸려면 타임라인을 수정하십시오.