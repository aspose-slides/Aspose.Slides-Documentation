---
title: Python via Java를 사용하여 사용자 정의 애니메이션 동작 만들기 및 수정
linktitle: 사용자 지정 애니메이션
type: docs
weight: 151
url: /ko/python-java/custom-animation/
keywords:
- 맞춤 애니메이션
- 애니메이션 동작
- 모션 경로
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션에서 맞춤 애니메이션 동작 및 편집 가능한 모션 경로를 만들고, 검사하며, 수정합니다."
---
## **개요**

사용자 정의 애니메이션 동작을 사용하면 색상 변경, 도형 회전 또는 편집 가능한 움직임 경로 따라가기와 같은 애니메이션 효과 내 개별 작업을 제어할 수 있습니다. 이 가이드는 동작을 만들고 결합하는 방법, 타이밍 구성, 기존 애니메이션 검사 및 수정, 프레젠테이션을 저장하고 다시 열 때 속성이 유지되는지 확인하는 방법을 보여줍니다.

미리 정의된 효과와 클릭 트리거에 대해서는 [Shape Animation](/slides/ko/python-java/shape-animation/)을 참조하세요.

## **애니메이션 모델 이해하기**

애니메이션은 **Timeline → Sequence → Effect → Behaviors** 로 구성됩니다:

- [getTimeline](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslide/#getTimeline) 메서드는 슬라이드 타임라인을 반환하며, 여기에는 메인 시퀀스와 인터랙티브 시퀀스가 포함됩니다.
- [Sequence](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sequence/) 은 서로 다른 도형을 대상으로 할 수 있는 효과들을 포함합니다.
- [Effect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effect/) 은 대상 도형, 프리셋, 하위 유형 및 효과 타이밍을 식별합니다.
- [Effect.getBehaviors](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effect/#getBehaviors) 가 반환하는 컬렉션에는 색상 변경, 이동, 회전, 속성 설정 등 효과를 구현하는 작업이 들어 있습니다.

## **개별 동작 만들기**

[Sequence.addEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sequence/#addEffect) 를 호출해 효과를 만들고 [getBehaviors](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effect/#getBehaviors) 컬렉션에 접근합니다. 프리셋을 사용하면 이 컬렉션이 자동으로 채워집니다. 프리셋을 확장할 때는 기존 작업을 유지하고, 의도적으로 교체할 경우 [clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorcollection/#clear) 를 사용합니다.

[BehaviorFactory](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorfactory/) 는 아래에示된 8가지 동작 유형을 생성합니다. 움직임은 [Build a Motion Path](#build-a-motion-path) 에서 다룹니다. 각 스니펫은 필요한 경우 import 구문과 JVM 시작 코드를 포함합니다. Java 포인트 객체와 배열은 JPype 를 통해 API가 요구하는 대로 생성됩니다. 이후 편집 예제에서는 사용되는 출력 파일을 명시합니다.

### **회전**

[createRotationEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorfactory/#createRotationEffect) 로 회전 효과를 만듭니다. [getBy](https://reference.aspose.com/slides/ko/python-java/aspose.slides/rotationeffect/#getBy) 는 회전 각도를 상대값(도)으로 지정하고, [getFrom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/rotationeffect/#getFrom) 과 [getTo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/rotationeffect/#getTo) 은 시작·끝 지점을 지정합니다.

예제는 Spin 효과를 시작점으로 삼아 프리셋 작업을 하나의 회전 동작으로 교체하고, 해당 동작에 2초 지속 시간을 지정합니다. 90도 상대 각도는 도형의 초기 방향에서 1/4 회전을 의미하므로 명시적인 시작 각도가 필요 없습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` 에는 하나의 도형과 하나의 회전 동작이 포함됩니다. 아래 컬렉션, 타이밍 및 회전 편집 예제는 이 파일을 사용합니다.

### **크기 조절**

[X/Y 퍼센트]를 사용해 [createScaleEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorfactory/#createScaleEffect) 를 호출합니다. [getFrom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/scaleeffect/#getFrom) 과 [getTo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/scaleeffect/#getTo) 은 시작·끝 크기를 설명하고, [getBy](https://reference.aspose.com/slides/ko/python-java/aspose.slides/scaleeffect/#getBy) 은 상대적인 변화를 나타냅니다. 여기서 100 은 원래 크기를 의미합니다.

예제는 두 축을 100%에서 125% 로 2초에 걸쳐 확대합니다. 가로·세로 비율을 동일하게 유지하면 도형 비율이 보존되고, 서로 다른 퍼센트를 사용하면 한 축이 더 많이 늘어납니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **색상**

[createColorEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorfactory/#createColorEffect) 로 채우기 색을 파란색에서 주황색으로 변경합니다. [getFrom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/coloreffect/#getFrom) 과 [getTo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/coloreffect/#getTo) 은 색상이며, [getBy](https://reference.aspose.com/slides/ko/python-java/aspose.slides/coloreffect/#getBy) 은 색상 오프셋을 나타냅니다. [Behavior.getProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behavior/#getProperties) 가 애니메이션 대상 속성을 식별합니다.

도형의 단색 채우기는 파란색으로 초기화되며, 이는 애니메이션 시작 색과 일치합니다. 채우기 색 속성을 선택하면 동작이 변경할 도형 부분을 지정하게 되며, 색상 끝점만으로는 어떤 속성을 바꾸는지 알 수 없습니다. 저장된 효과는 2초에 걸쳐 주황색으로 전환됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **필터**

[createFilterEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorfactory/#createFilterEffect) 로 와이프 필터를 선택합니다. [getType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/ko/python-java/aspose.slides/filtereffect/#getSubtype), [getReveal](https://reference.aspose.com/slides/ko/python-java/aspose.slides/filtereffect/#getReveal) 은 필터 종류, 방향 및 표시/숨김을 지정합니다.

예제는 오른쪽 방향 서브타입을 사용해 도형을 표시하는 2초 와이프를 구성합니다. 필터 설정은 효과 내부 동작에 속하므로 프리셋의 원래 작업을 제거한 뒤에 설정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **속성**

[createPropertyEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) 로 불투명도를 애니메이션합니다. [getFrom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/propertyeffect/#getTo), [getBy](https://reference.aspose.com/slides/ko/python-java/aspose.slides/propertyeffect/#getBy) 은 문자열이며, 각각 [getValueType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/propertyeffect/#getValueType) 와 [getCalcMode](https://reference.aspose.com/slides/ko/python-java/aspose.slides/propertyeffect/#getCalcMode) 에 의해 해석됩니다. 세 값을 모두 무분별하게 설정하기보다 끝점 또는 상대 오프셋을 선택하세요.

여기서는 대상 속성이 불투명도이며, 문자열 "25%" 에서 "100%" 로 변경되는 것을 나타냅니다. 선형 보간을 사용하면 값 사이가 점진적으로 변합니다. 다른 속성에 적용할 때는 해당 속성에 맞는 값 유형과 끝값을 선택합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **설정**

[createSetEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorfactory/#createSetEffect) 로 [getTo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/seteffect/#getTo) 를 이용해 가시성을 지정합니다. 설정 동작은 끝점 사이를 보간하지 않습니다.

예제는 가시성 속성을 선택하고 동작 실행 시 문자열 `visible` 을 할당합니다. 최소 프레젠테이션에서 사각형은 이미 보이기 때문에 이 할당만으로는 눈에 띄는 변화가 없을 수 있습니다. 그러나 다른 효과와 결합해 도형을 숨기거나 보이게 할 때 유용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **명령**

[createCommandEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorfactory/#createCommandEffect) 를 사용하고 [getType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/ko/python-java/aspose.slides/commandeffect/#getCommandString), [getShapeTarget](https://reference.aspose.com/slides/ko/python-java/aspose.slides/commandeffect/#getShapeTarget) 를 구성합니다. 작업 디렉터리에 `sample.wav` 라는 WAV 파일을 배치하세요. 예제는 이를 [addAudioFrameEmbedded](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) 로 삽입하고 재생 명령을 오디오 프레임에 연결합니다.

오디오 프레임은 효과와 명령 모두의 대상이 됩니다. 따라서 재생 요청이 삽입된 녹음 파일에 연결되며, 명령 문자열만으로는 어떤 미디어 객체를 제어할지 알 수 없습니다. 이 효과는 슬라이드 쇼 진행 중 클릭 시 시작하도록 설정됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

저장 시 `command.pptx` 에 명령이 저장되지만 녹음은 재생되지 않습니다. 재생하려면 해당 명령과 미디어 목표를 지원하는 슬라이드 쇼 플레이어가 필요합니다.

## **동작 컬렉션 관리**

[BehaviorCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorcollection/) 은 [add](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorcollection/#remove), [removeAt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorcollection/#removeAt) 를 지원합니다. 이 예제는 `rotation.pptx` 를 열어 스케일링을 추가하고, 회전 앞에 삽입한 뒤 회전을 제거합니다. 동일 객체를 제거하고 다시 삽입하면 복사본을 만들지 않고 저장된 위치가 바뀝니다.

편집 순서는 컬렉션을 회전‑스케일에서 스케일‑회전으로, 마지막으로 스케일만 남도록 변경합니다. 인덱스는 현재 컬렉션을 기준으로 하므로 재정렬 후 회전의 새 인덱스를 사용해 제거합니다. 최종 열거 결과 저장될 동작을 확인합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

출력은 `ScaleEffect` 만 남습니다. 컬렉션 순서는 자체적으로 동작을 연속 실행하도록 예약하지 않습니다. 모든 작업을 교체할 때만 컬렉션을 clear 하세요.

## **동작 타이밍 구성**

[Behavior.getTiming](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behavior/#getTiming) 은 [Effect.getTiming](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effect/#getTiming) 와 별개로 [Timing](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/) 정보를 제공합니다. Effect 타이밍은 전체 효과를 예약하고, 동작 타이밍은 그 안의 개별 작업을 설명합니다.

### **기간, 지연, 반복 및 가속 설정**

`rotation.pptx` 를 열고 지속 시간([getDuration](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getDuration)) 과 트리거 지연([getTriggerDelayTime](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getTriggerDelayTime)) 을 초 단위로 지정한 뒤, [setRepeatCount](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#setRepeatCount) 로 반복 횟수를 설정합니다. [getAccelerate](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getAccelerate) 와 [getDecelerate](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getDecelerate) 은 지속 시간의 비율이며, 두 값의 합은 1 이하로 유지합니다.

입력 파일은 회전 예제에서 만든 파일이며, 첫 번째 동작이 회전임이 알려져 있습니다. 이 예제는 해당 동작의 타이밍만 변경하고, 90도 각도는 그대로 유지합니다. 각도와 타이밍을 분리하면 애니메이션 속도를 재구성 없이 조정하기가 쉬워집니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

동작은 2초 지속, 0.5초 지연, 반복 횟수 3을 사용합니다. 지속 시간의 처음과 끝 20%가 가속·감속에 사용됩니다.

다른 반복 정책에는 [getRepeatDuration](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getRepeatUntilEndSlide), [getRepeatUntilNextClick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getRepeatUntilNextClick) 이 있으며, 모두를 동시에 활성화하지 말고 하나를 선택하세요. [getAutoReverse](https://reference.aspose.com/slides/ko/python-java/aspose.slides/timing/#getAutoReverse) 은 전방 재생 후 역방향 재생을 수행합니다. 가속·감속은 연속적인 변화에만 적용되며, 이산 할당이나 명령에는 적용되지 않습니다.

## **움직임 경로 만들기**

[createMotionEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorfactory/#createMotionEffect) 로 움직임을 생성합니다. 해당 효과의 [getFrom](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motioneffect/#getTo), [getBy](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motioneffect/#getBy) 은 퍼센트 기반 좌표 또는 오프셋을 설명합니다. 편집 가능한 경로가 필요하면 [MotionPath](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motionpath/) 를 만들고 [MotionEffect.setPath](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motioneffect/#setPath) 로 할당합니다. [MotionPath](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motionpath/) 에는 경로 명령이 저장됩니다.

[MotionCommandPathType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motioncommandpathtype/) 은 작업을 선택합니다:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | 시작 위치 설정 |
| LineTo | One | 직선 구간을 끝점까지 이동 |
| CurveTo | Three | 두 개의 제어점과 하나의 끝점으로 정의된 3차 곡선 따라 이동 |
| CloseLoop | None | 시작 위치로 돌아감 |
| End | None | 경로 종료 |

[MotionPathPointsType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motionpathpointstype/) 은 코너점 또는 스무스점 등 점 편집 특성을 설명하며, 명령 유형을 대체하지는 않습니다. 아래 곡선 예제에서는 곡선 점 유형을, 직선 구간 예제에서는 코너 점 유형을 사용합니다.

경로 좌표는 슬라이드 크기에 정규화됩니다. X 변위 0.25 는 슬라이드 너비의 1/4 을 의미하며, 0.25 포인트가 아닙니다. Y 값은 아래쪽이 양수입니다. 절대 명령은 경로 좌표계에서 위치를 지정하고, 상대 명령은 현재 위치에서의 오프셋을 지정합니다. 이는 [getOrigin](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motioneffect/#getOrigin) 과 [getPathEditMode](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motioneffect/#getPathEditMode) 와는 별개이며, 후자는 도형 이동 시 경로가 어떻게 움직이는지를 제어합니다.

### **직선 경로 만들기**

시작점, 하나의 직선 구간, 종료 명령을 가진 움직임 동작을 생성합니다. [MotionPath.add](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motionpath/#add) 은 명령 유형, 해당 점들, 점 유형, 상대 좌표 플래그를 받습니다.

시작 명령은 (0, 0) 을 설정하고, 라인은 (0.25, 0) 에서 끝나며 슬라이드 너비의 1/4 가로 이동을 나타냅니다. 종료 명령은 좌표가 없습니다. 경로를 할당한 뒤 효과에 움직임 동작을 추가하면 해당 경로가 사각형에 연결됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` 에는 세 개의 경로 명령을 가진 하나의 움직임 동작이 포함됩니다. 아래 파일 편집 예제는 이 구조를 사용합니다.

### **절대 좌표와 상대 좌표 비교**

아래 두 경로 객체는 동일한 루트를 나타냅니다. 절대 명령은 (0.3, 0.1) 에서 끝나고, 상대 명령은 현재 위치에 (0.1, 0.1) 을 더해 (0.2, 0) 로 이동합니다.

두 경로 모두 같은 위치에서 시작합니다. 상대 라인의 경우 현재 위치에 X·Y 오프셋을 더해 끝점을 얻고, 절대 라인의 경우 끝점을 바로 읽습니다. 플래그만 전환하고 좌표를 변환하지 않으면 다른 경로가 됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

任意의 경로를 움직임 동작에 할당해 프레젠테이션에서 사용할 수 있습니다. 마지막 Boolean 인자는 해당 명령에 대해 상대 좌표를 사용할지 결정합니다.

### **선분을 곡선으로 교체**

`motion.pptx` 를 열고 선분 명령을 3차 곡선으로 교체합니다. 먼저 두 개의 제어점을 제공하고, 그 뒤에 끝점을 제공합니다.

시작 위치는 이전 명령에서 공급됩니다. 첫 번째와 두 번째 점은 곡선을 형성하고, 세 번째 점은 목적지이며, 연속적인 목적지가 아닙니다. 명령 유형, 점 편집 유형, 점 배열을 동시에 업데이트하면 새로운 기하학에 맞게 구간이 일관되게 유지됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`curve.pptx` 의 경로는 여전히 세 개의 명령을 가지며, 중간 명령이 이제 곡선을 정의합니다.

## **저장된 경로 검사 및 편집**

각 [MotionCmdPath](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motioncmdpath/) 은 [getPoints](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motioncmdpath/#getPointsType), [isRelative](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motioncmdpath/#isRelative) 을 제공합니다. 아래 예제는 `motion.pptx` 에 있는 세 개 명령 경로를 사용합니다. 임의 파일을 다룰 때는 효과를 찾고, 편집 전에 명령 유형과 점 개수를 확인하세요.

### **명령 및 좌표 읽기**

경로를 변경 없이 읽어옵니다. 종료 및 닫기 명령은 점이 필요 없으므로 null 점 배열을 허용합니다.

출력은 각 숫자 명령 유형과 상대 좌표 플래그를 쌍으로 보여준 뒤 점들을 나열합니다. 이렇게 하면 점을 수정하기 전에 끝점과 오프셋을 구분할 수 있습니다. 곡선은 세 점을, 이 파일의 직선은 한 점만 나열합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

리스트에는 시작점, (0.25, 0) 에서 끝나는 절대 라인, 그리고 종료 명령이 포함됩니다.

### **끝점 변경**

`motion.pptx` 를 열고 라인의 점 배열을 교체해 끝점을 이동합니다.

입력 파일에서 인덱스 0은 시작 명령, 인덱스 1은 라인입니다. 라인의 단일 점을 교체하면 명령 유형, 타이밍, 컬렉션 내 위치는 그대로 두고 목적지만 바뀝니다. 명령이 절대 좌표이므로 새 쌍은 오프셋이 아니라 위치를 지정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion-endpoint.pptx` 의 라인은 (0.4, 0.1) 에서 끝나며, 원본 파일은 변경되지 않습니다.

### **구간 교체**

[insert](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motionpath/#insert) 와 [removeAt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motionpath/#removeAt) 을 사용해 `motion.pptx` 의 라인을 교체합니다. 삽입 시 기존 라인은 인덱스 2 로 이동합니다.

이는 기존 좌표를 수정하는 것이 아니라 명령 객체 자체를 교체하는 예시입니다. 삽입 후 컬렉션은 일시적으로 시작 명령, 새 라인, 이전 라인, 종료 명령을 포함합니다. 인덱스 2 를 제거하면 이전 라인이 사라지고 새 경로가 남습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

저장된 경로는 여전히 세 개 명령을 가지며, 새 라인은 (0.2, 0.1) 에서 끝나고 종료 명령이 마지막에 위치합니다.

## **기존 동작 수정 및 검증**

동작 인덱스를 모를 때는 타입으로 선택합니다. 이 예제는 `rotation.pptx` 를 열어 [RotationEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/rotationeffect/) 를 찾고 각도를 변경한 뒤 다시 열어 저장된 값을 확인합니다.

타입 검사를 통해 회전이 아닌 동작은 루프에서 건너뛰게 됩니다. 두 번째 로드는 파일을 별도 프레젠테이션 객체로 읽어 들이므로, 메모리에 남아 있는 값이 아니라 실제 저장된 데이터를 비교합니다. 이 예제는 알려진 효과가 메인 시퀀스 첫 번째에 있다고 가정합니다; 임의 프레젠테이션에서 타입으로 동작을 선택하면 올바른 효과를 찾지 못할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

출력은 `Rotation preserved: True` 입니다. 다른 동작에도 동일한 타입 검사 패턴을 적용하세요. 전체 보존 검사를 수행하려면 대상 도형, 효과, 동작 타입 및 순서, 타이밍, 경로 명령을 비교하고 부동소수점 값에는 수치 오차 허용 범위를 두세요. 애니메이션 레이아웃이 알려지지 않은 프레젠테이션에 대해서는 [Read Shape Animations](/slides/ko/python-java/shape-animation/#read-shape-animations) 를 참고해 메인 및 인터랙티브 시퀀스를 순회하세요.

## **동작 순서, 프리셋 및 재생**

[BehaviorCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behaviorcollection/) 의 순서는 효과 작업의 저장 순서이며, 앞 동작이 자동으로 끝날 때까지 기다리는 재생 목록이 아닙니다. 타이밍과 포함 효과가 예약을 결정합니다. 동작은 겹칠 수 있으며, 같은 속성에 대한 작업은 [getAdditive](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behavior/#getAdditive) 와 [getAccumulate](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behavior/#getAccumulate) 를 통해 상호 작용할 수 있습니다. “이동 후 회전”을 컬렉션 재정렬만으로 예약하지 말고, [Shape Animation](/slides/ko/python-java/shape-animation/) 에 설명된 것처럼 명시적인 타이밍이나 별도 효과를 사용하세요.

효과의 [getType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effect/#getType) 와 [getSubtype](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effect/#getSubtype) 은 프리셋을 설명합니다. 이는 편집된 동작 트리의 전체 설명이 아닙니다. 동작을 커스터마이징하기 전에 프리셋과 서브타입을 선택하세요; 프리셋을 변경하면 컬렉션이 재구성되어 사용자 정의 작업이 사라질 수 있습니다. 예를 들어, Spin 효과를 Fade 로 바꾸면 회전 동작이 설정 및 필터 동작으로 교체됩니다. 프리셋이나 서브타입을 바꾼 뒤 컬렉션을 다시 검사하세요. 프리셋 동작을 지우면 프리셋이 필요로 하는 가시성 또는 초기화 작업도 사라질 수 있습니다. 예제는 눈에 보이는 도형을 사용하고 동작을 교체했으며, 모든 프리셋 구현을 재구성하지는 않았습니다.

## **포맷 호환성**

보존된 동작 트리가 모든 뷰어나 내보내기 렌더러에서 동일하게 재생된다는 보장은 없습니다. 저장된 데이터와 렌더링 결과를 각각 확인하세요.

| 포맷 또는 출력 | 확인 항목 |
| --- | --- |
| PPTX | 예제의 기본 포맷으로 사용합니다. 다시 열어 편집 가능한 동작 트리를 확인한 뒤, 목표 PowerPoint 버전에서 재생을 확인하세요. |
| PPT | 레거시 바이너리 형태는 PPTX 와 다를 수 있습니다. 별도의 저장‑재열 사이클과 재생을 테스트하세요; 성공적인 PPTX 출력만으로 모든 커스텀 조합을 지원한다고 추정하지 마세요. |
| PDF, PNG, JPEG 및 기타 정적 슬라이드 이미지 | 정적 슬라이드 표현이며, 재생 가능한 동작 타임라인이나 최종 애니메이션 프레임을 보장하지 않습니다. |
| [HTML5](/slides/ko/python-java/export-to-html5/) | 내보내기 옵션에서 도형 애니메이션을 활성화하면 지원되는 애니메이션을 재생할 수 있습니다. 브라우저에서 커스텀 조합을 테스트하세요. |
| [Animated GIF](/slides/ko/python-java/convert-powerpoint-to-animated-gif/) | 렌더링된 프레임을 저장하며, 편집 가능한 동작이나 클릭 트리거 인터랙션은 포함하지 않습니다. 실제 렌더링된 움직임을 확인하세요. |
| [Video](/slides/ko/python-java/convert-powerpoint-to-video/) | 애니메이션 프레임을 렌더링해 비디오로 인코딩합니다. 지원 범위는 렌더러의 [supported animations and effects](/slides/ko/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) 에 제한되며, 명령 및 인터랙티브 이벤트는 편집 가능한 타임라인이 되지 않습니다. |

## **FAQ**

**왜 효과를 추가하기 전에 이미 동작이 포함되어 있나요?**

미리 정의된 효과를 만들면 기본 작업이 자동으로 생성될 수 있습니다. 프리셋을 확장할지 교체할지 결정하기 전에 이를 검사하세요.

**동작을 처음으로 이동하면 먼저 재생되나요?**

반드시 그렇지는 않습니다. 컬렉션 순서는 타이밍을 대신할 수 없습니다. 지연, 지속 시간 및 동일 속성에 대한 작업 간 상호 작용을 확인하세요.

**끝 명령에 점이 없는 이유는?**

끝 명령은 경로의 종료를 표시하며 좌표가 필요하지 않습니다. 파일에서 경로를 읽을 때 점 배열이 null인지 확인하세요.

**왕복 저장이 재생을 보장하나요?**

아니요. 재열은 확인한 속성의 보존만 확인합니다. 슬라이드 쇼 플레이어나 애니메이션 내보내기를 별도로 테스트해 시각적 동작을 확인해야 합니다.