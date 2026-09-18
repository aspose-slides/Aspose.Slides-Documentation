---
title: Python에서 사용자 지정 애니메이션 동작 만들기 및 수정
linktitle: 사용자 지정 애니메이션
type: docs
weight: 151
url: /ko/python-net/custom-animation/
keywords:
- 맞춤 애니메이션
- 애니메이션 동작
- 움직임 경로
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 프레젠테이션에서 사용자 지정 애니메이션 동작 및 편집 가능한 움직임 경로를 만들고, 검사하고, 수정합니다."
---
## **개요**

사용자 지정 애니메이션 동작을 사용하면 색상 변경, 도형 회전 또는 편집 가능한 움직임 경로 따위와 같이 애니메이션 효과 내 개별 작업을 제어할 수 있습니다. 이 가이드에서는 동작을 만들고 결합하는 방법, 타이밍을 구성하는 방법, 기존 애니메이션을 검사·수정하는 방법, 그리고 프레젠테이션을 저장하고 다시 열었을 때 속성이 유지되는지를 확인하는 방법을 보여 줍니다.

미리 정의된 효과와 클릭 트리거에 대해서는 [Shape Animation](/slides/ko/python-net/shape-animation/)을 참조하세요.

## **애니메이션 모델 이해하기**

애니메이션은 **Timeline → Sequence → Effect → Behaviors** 로 구성됩니다:

- 슬라이드의 [timeline](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslide/timeline/)에는 메인 시퀀스와 인터랙티브 시퀀스가 포함됩니다.
- [Sequence](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/)는 서로 다른 도형을 대상으로 할 수 있는 효과들을 포함합니다.
- [Effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effect/)는 대상 도형, 프리셋, 서브타입 및 효과 타이밍을 식별합니다.
- [Effect.behaviors](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effect/behaviors/)는 색상 변경, 이동, 회전, 속성 설정 등 효과를 구현하는 작업들을 포함합니다.

## **개별 동작 만들기**

[Sequence.add_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/add_effect/)을 호출하여 효과를 만든 뒤 해당 효과의 [behaviors](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effect/behaviors/) 컬렉션에 접근합니다. 프리셋은 이 컬렉션을 자동으로 채울 수 있습니다. 프리셋을 확장할 때는 기존 작업을 유지하고, 의도적으로 교체할 경우에는 [clear](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorcollection/clear/)를 사용합니다.

[BehaviorFactory](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorfactory/)는 아래에 나타낸 8가지 동작 유형을 생성합니다. 움직임에 관한 내용은 [Build a Motion Path](#build-a-motion-path)에서 다룹니다. 각 생성 예제는 완전한 프로그램이며, 이후 편집 예제는 사용되는 출력 파일을 명시합니다.

### **회전**

[create_rotation_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/)를 사용하여 회전을 생성합니다. [by](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/rotationeffect/by/)는 회전 각도를 (도)로 지정하고, [from_address](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/rotationeffect/from_address/)와 [to](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/rotationeffect/to/)는 시작·종료 지점을 지정합니다.

이 예제는 Spin 효과를 시작으로, 프리셋 작업을 하나의 회전 동작으로 교체하고 해당 동작에 2초 지속시간을 부여합니다. 90도라는 상대 각도는 도형의 시작 방향으로부터 ¼ 회전을 의미하므로 명시적인 시작 각도는 필요하지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx`에는 하나의 도형과 하나의 회전 동작이 포함됩니다. 아래의 컬렉션, 타이밍 및 회전‑편집 예제는 이 파일을 사용합니다.

### **크기 조절**

[X/Y 퍼센트]를 사용하여 [create_scale_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/)를 호출합니다. [from_address](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/scaleeffect/from_address/)와 [to](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/scaleeffect/to/)는 시작·끝 크기를 설명하고, [by](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/scaleeffect/by/)는 상대 변화를 설명합니다. 여기서 100은 원래 크기를 의미합니다.

예제는 두 차원을 100%에서 125%로 2초 동안 확대합니다. 가로·세로 퍼센트를 동일하게 지정하면 도형 비율을 유지하고, 차이가 있으면 한 차원이 더 늘어납니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **색상**

[create_color_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/)를 사용하여 채우기 색을 파란색에서 주황색으로 변경합니다. [from_address](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/coloreffect/from_address/)와 [to](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/coloreffect/to/)는 색상이며, [by](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/coloreffect/by/)는 색상 오프셋입니다. [Behavior.properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behavior/properties/)는 애니메이션 대상 속성을 식별합니다.

도형의 단색 채우기는 파란색으로 초기화되어 애니메이션 시작 색과 일치합니다. 채우기‑색상 속성을 선택함으로써 동작이 도형의 어느 부분을 변경할지 지정합니다; 색상 끝점만으로는 해당 속성을 식별할 수 없습니다. 저장된 효과는 2초에 걸쳐 주황색으로 전환한다는 정보를 담고 있습니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **필터**

[create_filter_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/)를 사용하여 와이프를 선택합니다. [type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/filtereffect/subtype/), [reveal](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/filtereffect/reveal/)은 필터 종류, 방향 및 도형을 표시하거나 숨길지를 지정합니다.

이 예제는 오른쪽 방향 서브타입을 사용하여 도형을 표시하는 2초 와이프를 구성합니다. 필터 설정은 효과 내부 동작에 속하므로 프리셋의 원래 작업을 제거한 뒤에 설정합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **속성**

[create_property_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/)를 사용하여 불투명도를 애니메이션합니다. [from_address](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/propertyeffect/to/), [by](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/propertyeffect/by/)는 문자열이며, 각각 [value_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/propertyeffect/value_type/)과 [calc_mode](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/propertyeffect/calc_mode/)에 따라 해석됩니다. 세 값을 모두 무작위로 설정하기보다 끝점이나 상대 오프셋을 선택하십시오.

여기서는 선택된 속성이 불투명도이며, 문자열은 25% 불투명도에서 완전 불투명도로 변화함을 나타냅니다. 선형 보간은 해당 값들 사이의 점진적 변화를 의미합니다. 다른 속성에 적용할 경우 해당 속성에 맞는 값 유형과 끝점 값을 선택합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **설정**

[to](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/seteffect/to/)를 사용하여 가시성을 할당하는 [create_set_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/)를 이용합니다. 설정 동작은 끝점 사이를 보간하지 않습니다.

예제는 가시성 속성을 선택하고 동작이 실행될 때 문자열 `visible`을 할당합니다. 이 최소 프레젠테이션의 사각형은 이미 보이므로 할당만으로는 눈에 띄는 변화를 만들지 않을 수 있습니다. 이러한 작업은 도형이 숨겨지거나 보이게 되는 시점을 제어하는 보다 큰 효과의 일부로 유용합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **명령**

[create_command_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/)를 사용하고 [type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/commandeffect/command_string/), [shape_target](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/commandeffect/shape_target/)를 구성합니다. 작업 디렉터리에 `sample.wav`라는 WAV 녹음을 배치하십시오. 이 예제는 [add_audio_frame_embedded](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/)를 사용해 파일에 삽입하고, 오디오 프레임에 재생 명령을 연결합니다.

오디오 프레임은 효과와 명령 모두의 대상이 됩니다. 이렇게 하면 재생 요청이 삽입된 녹음과 연결되며, 명령 문자열만으로는 어떤 미디어 객체를 제어할지 알 수 없습니다. 효과는 슬라이드쇼 중 클릭 시 시작하도록 구성됩니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

저장은 `command.pptx`에 명령을 저장하지만 녹음을 재생하지는 않습니다. 재생하려면 해당 명령과 미디어 대상을 지원하는 슬라이드쇼 플레이어가 필요합니다.

## **동작 컬렉션 관리**

[BehaviorCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorcollection/)은 [add](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorcollection/remove/), [remove_at](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorcollection/remove_at/)을 지원합니다. 이 예제는 `rotation.pptx`를 열어 크기 조절을 추가하고, 회전 앞에 삽입한 뒤 회전을 제거합니다. 동일 객체를 제거하고 다시 삽입하면 복사본을 만들지 않고 저장 위치만 바뀝니다.

편집 순서는 컬렉션을 회전‑크기조절 → 크기조절‑회전 → 크기조절만 남도록 변경합니다. 인덱스는 현재 컬렉션을 기준으로 하므로 재정렬 후 회전의 새 인덱스를 사용해 제거합니다. 최종 열거를 통해 저장될 동작을 확인합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

출력은 `ScaleEffect`만 남습니다. 컬렉션 순서 자체가 동작을 순차적으로 실행하도록 예약하지는 않습니다. 모든 작업을 교체할 때만 컬렉션을 비우십시오.

## **동작 타이밍 구성**

[Behavior.timing](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behavior/timing/)은 [Effect.timing](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effect/timing/)과 독립적으로 [Timing](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/)을 노출합니다. 효과 타이밍은 전체 효과를 예약하고, 동작 타이밍은 그 안의 개별 작업을 설명합니다.

### **지속시간, 지연, 반복, 가속 설정**

`rotation.pptx`를 연 뒤 초 단위로 [duration](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/duration/)와 [trigger_delay_time](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/trigger_delay_time/)을 설정하고, [repeat_count](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/repeat_count/)을 구성합니다. [accelerate](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/accelerate/)와 [decelerate](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/decelerate/)는 지속시간의 비율이며, 두 값의 합은 1 이하이어야 합니다.

입력 파일은 회전 예제에서 만든 파일이며, 첫 번째 동작이 회전임이 알려져 있습니다. 이 예제는 해당 동작의 타이밍만 변경하고, 90도 회전 각도는 그대로 유지합니다. 각도와 타이밍을 분리하면 애니메이션을 재구성하지 않고도 속도를 조정하기가 쉽습니다.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

동작은 2초 지속, 0.5초 지연, 반복 횟수 3을 사용합니다. 지속시간의 처음과 끝 20%는 가속 및 감속에 사용됩니다.

다른 반복 정책으로는 [repeat_duration](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), [repeat_until_next_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/repeat_until_next_click/)이 있으며, 모두를 동시에 활성화하지 말고 하나만 선택하십시오. [auto_reverse](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/timing/auto_reverse/)는 전방 재생 후 역방향 재생을 수행합니다. 가속·감속은 연속적인 변화에만 적용되며, 이산 할당이나 명령에는 적용되지 않습니다.

## **움직임 경로 만들기**

[create_motion_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/)를 사용하여 움직임을 생성합니다. [from_address](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motioneffect/to/), [by](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motioneffect/by/)는 백분율 기반 좌표 또는 오프셋을 설명합니다. 편집 가능한 경로를 만들려면 [MotionPath](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motionpath/)를 생성하고 이를 [MotionEffect.path](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motioneffect/path/)에 할당합니다. [MotionPath](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motionpath/)는 경로 명령을 저장합니다.

[MotionCommandPathType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motioncommandpathtype/)은 작업을 선택합니다:

| Command | Points | Meaning |
| --- | --- | --- |
| MOVE_TO | One | 시작 위치 설정 |
| LINE_TO | One | 직선 구간을 따라 끝점까지 이동 |
| CURVE_TO | Three | 두 개의 제어점과 끝점으로 정의된 3차 곡선 따라 이동 |
| CLOSE_LOOP | None | 시작 위치로 돌아감 |
| END | None | 경로 종료 |

[MotionPathPointsType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motionpathpointstype/)은 코너 포인트·스무스 포인트 등 점 편집 특성을 설명하며, 명령 유형을 대체하지는 않습니다. 아래 곡선 예제에서는 곡선 포인트 유형을, 직선 구간에서는 코너 포인트 유형을 사용합니다.

경로 좌표는 슬라이드 크기에 대해 정규화됩니다. X 이동 0.25는 슬라이드 너비의 ¼을 의미하며, 0.25 포인트가 아닙니다. Y는 아래쪽이 양수입니다. 절대 명령은 경로 좌표계에서 위치를 지정하고, 상대 명령은 현재 위치에서 오프셋을 지정합니다. 이는 [origin](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motioneffect/origin/)과 [path_edit_mode](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motioneffect/path_edit_mode/)와 별개이며, 뒤의 옵션은 도형이 이동할 때 경로가 어떻게 움직이는지를 제어합니다.

### **직선 경로 만들기**

시작점, 하나의 직선 구간 및 종료 명령으로 움직임 동작을 생성합니다. [MotionPath.add](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motionpath/add/)은 명령 유형, 해당 점들, 점 유형, 그리고 상대 좌표 플래그를 받습니다.

시작 명령은 (0, 0)을 설정하고, 직선은 (0.25, 0)에서 끝나 슬라이드 너비의 ¼ 만큼 수평 변위를 제공합니다. 종료 명령에는 좌표가 없습니다. 경로를 할당하고 움직임 동작을 효과에 추가하면 해당 경로가 사각형에 연결됩니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx`에는 세 개의 경로 명령을 가진 하나의 움직임 동작이 들어 있습니다. 아래 파일 편집 예제는 이 구조를 기반으로 합니다.

### **절대 좌표와 상대 좌표 비교**

두 경로 객체는 동일한 경로를 나타냅니다. 절대 명령은 (0.3, 0.1)에서 끝나고, 상대 명령은 현재 위치에 (0.1, 0.1)을 더해 (0.2, 0)에서 끝납니다.

두 경로 모두 같은 위치에서 시작합니다. 상대 직선의 경우 현재 위치에 X·Y 오프셋을 더해 끝점을 얻고, 절대 직선의 경우 바로 끝점을 읽습니다. 변환 없이 플래그만 바꾸면 다른 경로가 됩니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

경로를 동작에 할당하면 프레젠테이션에서 사용할 수 있습니다. 마지막 Boolean 인자는 해당 명령에 상대 좌표를 사용할지 여부를 선택합니다.

### **직선을 곡선으로 교체**

`motion.pptx`를 열고 직선 명령을 3차 곡선으로 교체합니다. 먼저 두 제어점을 제공하고 마지막에 끝점을 제공합니다.

시작 위치는 이전 명령이 제공하며, 첫 두 점은 곡선을 형성하고 세 번째는 목적지입니다; 이들은 연속된 목적지가 아니라 곡선의 기하학을 정의합니다. 명령 유형, 점 편집 유형 및 점 배열을 동시에 업데이트하면 새 기하학에 맞게 구간이 일관성을 유지합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

`curve.pptx`의 경로는 여전히 세 개의 명령을 가지고 있으며, 중간 명령이 이제 곡선을 정의합니다.

## **저장된 경로 검사 및 편집**

각 [MotionCmdPath](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motioncmdpath/)는 [points](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motioncmdpath/points_type/), [is_relative](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motioncmdpath/is_relative/)를 노출합니다. 아래 예제는 `motion.pptx`에 있는 알려진 3‑명령 경로를 사용합니다. 임의 입력의 경우 효과를 찾아 명령 유형·점 개수를 확인한 뒤 인덱스로 편집하십시오.

### **명령 및 좌표 읽기**

경로를 변경하지 않고 읽습니다. 종료·닫기‑루프 명령은 점이 필요 없으므로 `None` 배열을 허용합니다.

출력은 각 명령과 상대 좌표 플래그를 쌍으로 표시한 뒤 점들을 나열합니다. 이를 통해 경로를 수정하기 전 끝점과 오프셋을 구분할 수 있습니다. 곡선은 세 점을, 여기의 직선은 한 점만을 표시합니다.

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

목록에는 시작점, (0.25, 0)에서 끝나는 절대 직선, 그리고 종료 명령이 포함됩니다.

### **끝점 변경**

`motion.pptx`를 열고 직선의 점 배열을 교체하여 끝점을 이동합니다.

입력 파일에서 인덱스 0은 시작 명령, 인덱스 1은 직선입니다. 직선의 단일 점을 교체하면 명령 유형·타이밍·컬렉션 내 위치는 그대로 두고 목적지만 바뀝니다. 명령이 절대 좌표를 사용하므로 새 쌍은 위치를 지정합니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

`motion-endpoint.pptx`의 직선은 (0.4, 0.1)에서 끝나며, 원본 파일은 변경되지 않습니다.

### **구간 교체**

[insert](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motionpath/insert/)와 [remove_at](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motionpath/remove_at/)를 사용해 `motion.pptx`의 직선을 교체합니다. 삽입 시 기존 직선은 인덱스 2로 이동합니다.

이는 기존 좌표를 편집하는 대신 명령 객체 자체를 교체함을 보여 줍니다. 삽입 후 컬렉션은 시작 명령, 새 직선,旧 직선, 종료 명령 순으로 일시적으로 구성됩니다. 인덱스 2를 제거하면旧 직선이 사라지고 새 경로가 남습니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

저장된 경로는 여전히 세 개의 명령을 가지고 있으며, 새 직선은 (0.2, 0.1)에서 끝나고 종료 명령이 마지막에 위치합니다.

## **기존 동작 수정 및 확인**

동작 인덱스를 모를 때는 유형으로 선택합니다. 이 예제는 `rotation.pptx`를 열어 [RotationEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/rotationeffect/)을 찾고, 각도를 변경한 뒤 다시 열어 저장된 값을 확인합니다.

유형 검사는 루프가 회전이 아닌 동작을 건너뛰게 합니다. 두 번째 로드에서는 파일을 별도 프레젠테이션 객체에 읽어 들여, 메모리에 남아 있는 값이 아니라 지속된 데이터를 비교합니다. 이 예제는 효과가 메인 시퀀스 첫 번째에 있다고 가정하며, 유형으로 동작을 선택하는 방식은 임의 프레젠테이션에서 올바른 효과를 찾지 못할 수 있습니다.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

출력은 `Rotation preserved: True` 입니다. 다른 동작에도 동일한 유형 검사 패턴을 적용하십시오. 완전한 보존 확인을 위해서는 대상 도형, 효과, 동작 유형·순서, 타이밍, 경로 명령을 모두 비교하고, 부동소수점 값은 수치적 허용오차를 두어 비교합니다. 애니메이션 레이아웃이 알려지지 않은 프레젠테이션은 [Read Shape Animations](/slides/ko/python-net/shape-animation/#read-shape-animations)에서 메인·인터랙티브 시퀀스를 순회하는 방법을 참조하세요.

## **동작 순서, 프리셋 및 재생**

[BehaviorCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behaviorcollection/)의 순서는 효과 작업의 저장 순서일 뿐, 각 동작이 앞의 동작을 자동으로 기다리는 재생 목록이 아닙니다. 타이밍과 포함 효과가 스케줄을 결정합니다. 동작은 겹칠 수 있으며, 동일 속성에 대한 작업은 [additive](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behavior/additive/)·[accumulate](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behavior/accumulate/)를 통해 상호 작용할 수 있습니다. “이동 후 회전”과 같이 컬렉션 순서만으로 스케줄링하지 말고, 앞서 설명한 대로 명시적 타이밍이나 별도 효과를 사용하십시오.

효과의 [type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effect/type/)과 [subtype](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effect/subtype/)은 프리셋을 설명합니다. 이는 편집된 동작 트리의 완전한 설명이 아니므로, 동작을 커스터마이즈하기 전에 프리셋·서브타입을 선택하십시오. 프리셋을 변경하면 컬렉션이 재구성되고 사용자 정의 작업이 사라질 수 있습니다. 예를 들어, 사용자 정의 Spin 효과를 Fade로 바꾸면 회전 동작이 설정·필터 동작으로 교체됩니다. 프리셋·서브타입을 변경한 뒤 컬렉션을 다시 검사하십시오. 프리셋 동작을 비우면 프리셋이 필요로 하는 가시성·초기화 작업도 제거될 수 있습니다. 예제는 가시적인 도형을 사용하고 동작을 교체하도록 설계되었으며, 모든 프리셋 구현을 재구성하지는 않습니다.

## **포맷 호환성**

보존된 동작 트리가 모든 뷰어·내보내기 렌더러에서 동일한 재생을 보장하지는 않습니다. 저장된 데이터와 렌더링 결과를 각각 확인하십시오.

| 포맷 또는 출력 | 확인 항목 |
| --- | --- |
| PPTX | 예제의 기본 포맷으로 사용합니다. 재열어 편집 가능한 동작 트리를 확인한 뒤, 목표 PowerPoint 버전에서 재생을 검사하십시오. |
| PPT | 레거시 바이너리 형식은 PPTX와 다를 수 있습니다. 별도 저장‑재열기·재생 사이클을 테스트하고, PPTX 출력만으로 모든 사용자 정의 조합이 지원된다고 추론하지 마십시오. |
| PDF, PNG, JPEG 및 기타 정적 슬라이드 이미지 | 정적 슬라이드 표현이며, 재생 가능한 동작 타임라인이나 최종 애니메이션 프레임을 보장하지 않습니다. |
| [HTML5](/slides/ko/python-net/export-to-html5/) | 내보내기 옵션에서 shape animation을 활성화하면 지원되는 애니메이션을 재생할 수 있습니다. 브라우저에서 사용자 정의 조합을 테스트하십시오. |
| [Animated GIF](/slides/ko/python-net/convert-powerpoint-to-animated-gif/) | 렌더링된 프레임을 저장하며, 편집 가능한 동작이나 클릭 트리거 인터랙션을 포함하지 않습니다. 실제 렌더링된 움직임을 확인하십시오. |
| [Video](/slides/ko/python-net/convert-powerpoint-to-video/) | 애니메이션 프레임을 렌더링하여 비디오로 인코딩합니다. 지원 범위는 렌더러의 [supported animations and effects](/slides/ko/python-net/convert-powerpoint-to-video/#supported-animations-and-effects)로 제한되며, 명령 및 인터랙티브 이벤트는 편집 가능한 타임라인이 되지 않습니다. |

## **FAQ**

**내 효과에 동작이 사전에 포함되어 있는 이유는?**

프리셋 효과를 만들면 기본 작업이 자동으로 생성될 수 있습니다. 프리셋을 확장할지 교체할지 결정하기 전에 이를 검사하십시오.

**동작을 처음으로 이동하면 먼저 재생되나요?**

반드시 그렇지는 않습니다. 컬렉션 순서는 타이밍을 대체하지 않습니다. 지연·지속시간·같은 속성에 대한 작업 간 상호 작용을 확인하십시오.

**종료 명령에 점이 없는 이유는?**

경로의 끝을 표시하며 좌표가 필요 없습니다. 파일에서 경로를 읽을 때 `None` 점 배열을 검사하십시오.

**라운드 트립이 재생 확인에 충분한가요?**

아니요. 재열기는 확인한 속성 보존을 증명하지만, 슬라이드쇼 플레이어나 애니메이션 내보내기를 별도로 테스트하여 실제 시각적 동작을 확인해야 합니다.