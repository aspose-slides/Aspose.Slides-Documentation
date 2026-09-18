---
title: JavaScript에서 맞춤 애니메이션 동작 생성 및 수정
linktitle: 맞춤 애니메이션
type: docs
weight: 151
url: /ko/nodejs-java/custom-animation/
keywords:
- 맞춤 애니메이션
- 애니메이션 동작
- 모션 경로
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js용 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에서 맞춤 애니메이션 동작 및 편집 가능한 모션 경로를 생성, 검사 및 수정합니다."
---
## **개요**

사용자 지정 애니메이션 동작을 사용하면 색상 변경, 도형 회전, 편집 가능한 움직임 경로 따르기와 같은 애니메이션 효과 내 개별 작업을 제어할 수 있습니다. 이 가이드는 동작을 생성하고 결합하는 방법, 타이밍을 구성하는 방법, 기존 애니메이션을 검사 및 수정하는 방법, 그리고 속성이 프레젠테이션을 저장하고 다시 열 때 유지되는지 확인하는 방법을 보여줍니다.

미리 정의된 효과 및 클릭 트리거에 대해서는 [도형 애니메이션](/slides/ko/nodejs-java/shape-animation/)을 참조하십시오.

## **애니메이션 모델 이해**

애니메이션은 **타임라인 → 시퀀스 → 이펙트 → 동작**으로 구성됩니다:

- `getTimeline` 메서드는 슬라이드 타임라인을 반환하며, 여기에는 기본 시퀀스와 대화형 시퀀스가 포함됩니다.
- `Sequence`는 효과를 포함하며, 서로 다른 도형을 대상으로 할 수 있습니다.
- `Effect`는 대상 도형, 프리셋, 서브타입 및 효과 타이밍을 식별합니다.
- `Effect.getBehaviors`가 반환하는 컬렉션에는 효과를 구현하는 작업이 들어 있습니다: 색상 변경, 이동, 회전, 속성 설정 등.

## **개별 동작 만들기**

`Sequence.addEffect`를 호출하여 효과를 만들고 `getBehaviors` 컬렉션에 접근합니다. 프리셋은 이 컬렉션을 자동으로 채울 수 있습니다. 프리셋을 확장할 때는 기존 작업을 유지하고, 의도적으로 교체할 경우 `clear`를 사용하십시오.

`BehaviorFactory`는 아래에 표시된 8가지 동작 유형을 생성합니다. 움직임은 [경로 만들기](#build-a-motion-path)에서 다룹니다. 각 스니펫에는 모듈 임포트가 포함되어 있으며 `aspose.slides.via.java` 및 `java` 패키지가 설치된 Node.js 스크립트로 실행할 수 있습니다. 출력 파일을 읽는 예제보다 파일 생성 예제를 먼저 실행하십시오. 이후 편집 예제에서는 사용되는 출력 파일을 명시합니다.

### **회전**

`createRotationEffect`를 사용하여 회전을 생성합니다. `getBy`는 상대 각도를 도 단위로 지정하고, `getFrom`과 `getTo`는 시작점과 끝점을 지정합니다.

예제는 Spin 효과로 시작하여 프리셋 작업을 하나의 회전 동작으로 교체하고 해당 작업에 2초 지속시간을 부여합니다. 90도의 상대 각도는 도형의 초기 방향에서 1/4 회전을 의미하므로 명시적인 시작 각도가 필요하지 않습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx`에는 하나의 도형과 하나의 회전 동작이 포함되어 있습니다. 아래의 컬렉션, 타이밍 및 회전 편집 예제는 이 파일을 사용합니다.

### **크기 조정**

`createScaleEffect`를 X/Y 백분율과 함께 사용합니다: `getFrom` 및 `getTo`는 시작 및 종료 크기를 나타내고, `getBy`는 상대적인 변화를 나타냅니다. 여기서 100은 원래 크기를 의미합니다.

예제는 두 차원을 100%에서 125%로 2초 동안 확대합니다. 가로와 세로 백분율을 동일하게 사용하면 도형의 비율이 유지되며, 서로 다르게 설정하면 한 차원이 다른 차원보다 더 늘어납니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **색상**

`createColorEffect`를 사용하여 채우기 색상을 파란색에서 주황색으로 변경합니다. `getFrom`과 `getTo`는 색상이며, `getBy`는 색상 오프셋입니다. `Behavior.getProperties`는 애니메이션되는 속성을 식별합니다.

도형의 단색 채우기는 파란색으로 초기화되어 애니메이션 시작 색상과 일치합니다. `fill-color` 속성을 선택하면 동작이 도형의 어떤 부분을 변경할지 알 수 있게 되며, 색상 끝점만으로는 해당 속성을 식별할 수 없습니다. 저장된 효과는 2초 동안 주황색으로 전환함을 설명합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **필터**

`createFilterEffect`를 사용하여 와이프를 선택합니다. `getType`, `getSubtype`, `getReveal`는 필터, 방향 및 도형을 표시하거나 숨길지를 지정합니다.

이 예제는 오른쪽 방향 서브타입을 사용하여 도형을 표시하는 2초 와이프를 구성합니다. 필터 설정은 효과 내부 동작에 속하므로 프리셋의 원래 작업을 제거한 후에 설정됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **속성**

`createPropertyEffect`를 사용하여 불투명도를 애니메이션합니다. `getFrom`, `getTo`, `getBy`는 문자열이며 `getValueType` 및 `getCalcMode`를 통해 해석됩니다. 세 값을 모두 무작위로 설정하기보다 끝점이나 상대 오프셋을 선택하십시오.

여기서 선택된 속성은 불투명도이며, 숫자 문자열은 25% 불투명도에서 완전한 불투명도로의 변화를 나타냅니다. 선형 보간은 해당 값들 사이의 점진적인 변화를 설명합니다. 이 예제를 다른 속성에 적용할 경우 해당 속성에 맞는 값 유형과 끝점 값을 선택하십시오.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **설정**

`createSetEffect`를 사용하여 `getTo`를 통해 가시성을 할당합니다. `set` 동작은 끝점 사이를 보간하지 않습니다.

예제는 가시성 속성을 선택하고 동작이 실행될 때 문자열 `visible`을 할당합니다. 이 최소 프레젠테이션에서 사각형은 이미 보이므로 할당만으로 눈에 띄는 시각적 변화가 없을 수 있습니다. 이러한 작업은 도형이 언제 숨겨지거나 보이게 할지를 제어하는 큰 효과의 일부로 유용합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **명령**

`createCommandEffect`를 사용하고 `getType`, `getCommandString`, `getShapeTarget`을 구성합니다. 작업 디렉터리에 `sample.wav`라는 WAV 녹음을 배치하십시오. 이 예제는 `addAudioFrameEmbedded`로 이를 삽입하고 오디오 프레임에 재생 명령을 연결합니다.

오디오 프레임은 효과와 명령 모두의 대상입니다. 이는 재생 요청을 삽입된 녹음에 연결하며, 명령 문자열만으로는 제어할 미디어 객체를 식별하지 못합니다. 효과는 슬라이드 쇼 중 클릭 시 시작하도록 구성됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

저장하면 `command.pptx`에 명령이 저장되며, 녹음은 재생되지 않습니다. 재생하려면 해당 명령과 미디어 대상을 지원하는 슬라이드 쇼 플레이어가 필요합니다.

## **동작 컬렉션 관리**

`BehaviorCollection`은 `add`, `insert`, `remove`, `removeAt`를 지원합니다. 이 예제는 `rotation.pptx`를 열어 크기 조정을 추가하고 회전 앞에 이동시킨 다음 회전을 제거합니다. 동일 객체를 제거하고 다시 삽입하면 복사하지 않고 저장된 위치가 바뀝니다.

편집 순서는 컬렉션을 `rotation–scale`에서 `scale–rotation`으로, 그리고 `scale`만 남도록 변경합니다. 인덱스는 현재 컬렉션을 기준하므로 재정렬 후 회전의 새로운 인덱스를 사용해 제거합니다. 최종 열거는 어떤 동작이 저장될지 확인합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

출력은 `ScaleEffect`이며, 크기 조정만 남습니다. 컬렉션 순서 자체만으로 동작을 연속적으로 예약하지는 않습니다. 모든 작업을 교체할 때만 컬렉션을 비우십시오.

## **동작 타이밍 구성**

`Behavior.getTiming`은 `Timing`을 노출하며, `Effect.getTiming`과 독립적입니다. 효과 타이밍은 전체 효과를 스케줄링하고, 동작 타이밍은 그 안의 작업을 설명합니다.

### **지속시간, 지연, 반복 및 가속 설정**

`rotation.pptx`를 열어 지속시간(`getDuration`)과 트리거 지연시간(`getTriggerDelayTime`)을 초 단위로 설정하고, `setRepeatCount`로 반복 횟수를 구성합니다. `getAccelerate`와 `getDecelerate`는 지속시간의 비율이며, 합계가 1을 초과하지 않도록 합니다.

입력 파일은 회전 예제에서 만든 파일이며, 첫 번째 동작이 회전임이 알려져 있습니다. 이 예제는 해당 동작의 타이밍만 변경하고 90도 각도는 그대로 유지합니다. 각도와 타이밍을 별도로 유지하면 애니메이션을 다시 만들지 않고도 속도를 조절하기 쉽습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

동작은 2초 지속시간, 0.5초 지연, 반복 횟수 3을 사용합니다. 지속시간의 앞과 뒤 20%가 가속 및 감속에 사용됩니다.

다른 반복 정책으로는 `getRepeatDuration`, `getRepeatUntilEndSlide`, `getRepeatUntilNextClick`이 있으며, 모두 동시에 활성화하기보다 하나를 선택하십시오. `getAutoReverse`는 순방향 재생 후 애니메이션을 역방향으로 재생합니다. 가속 및 감속은 연속적인 변화에 적용되며, 이산 할당이나 명령에는 적용되지 않습니다.

## **움직임 경로 만들기**

`createMotionEffect`를 사용하여 움직임을 생성합니다. `getFrom`, `getTo`, `getBy`는 백분율 기반 좌표 또는 오프셋을 설명합니다. 편집 가능한 경로를 만들려면 `MotionPath`를 생성하고 `MotionEffect.setPath`로 할당합니다. `MotionPath`는 경로 명령을 저장합니다.

`MotionCommandPathType`은 작업을 선택합니다:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | 시작 위치를 설정합니다. |
| LineTo | One | 직선 구간을 끝점까지 이동합니다. |
| CurveTo | Three | 두 개의 제어점과 끝점으로 정의된 3차 곡선을 따릅니다. |
| CloseLoop | None | 시작 위치로 돌아갑니다. |
| End | None | 경로를 종료합니다. |

`MotionPathPointsType`은 코너 혹은 스무스 포인트와 같은 점 편집 특성을 설명합니다. 이는 명령 유형을 대체하지 않습니다. 아래 곡선 예제에서는 곡선 포인트 유형을, 직선 구간에서는 코너 포인트 유형을 사용하십시오.

경로 좌표는 슬라이드 크기에 정규화됩니다: X 변위 0.25는 슬라이드 너비의 1/4을 의미하며, 0.25 포인트가 아닙니다. Y 양수는 아래쪽으로 진행합니다. 절대 명령은 경로 좌표계에서 위치를 지정하고, 상대 명령은 현재 위치에서의 오프셋을 지정합니다. 이는 `getOrigin`이 경로의 기준 프레임을 선택하고, `getPathEditMode`가 도형 이동 시 경로가 어떻게 움직이는지를 제어하는 것과는 별개입니다.

### **직선 경로 만들기**

시작점, 하나의 직선 구간, 종료 명령으로 움직임 동작을 만듭니다. `MotionPath.add`는 명령 유형, 점들, 점 유형, 상대 좌표 플래그를 받습니다.

시작 명령은 (0, 0)을 설정하고, 직선은 (0.25, 0)에서 끝나 슬라이드 폭의 1/4에 해당하는 수평 변위를 제공합니다. 종료 명령은 좌표 점이 없습니다. 경로를 할당한 후, 효과에 움직임 동작을 추가하면 해당 경로가 사각형에 연결됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx`에는 세 개의 경로 명령을 가진 하나의 움직임 동작이 포함됩니다. 아래 파일 편집 예제는 이 알려진 구조를 사용합니다.

### **절대 좌표와 상대 좌표 비교**

이 두 경로 객체는 동일한 경로를 설명합니다. 절대 명령은 (0.3, 0.1)에서 끝나고, 상대 명령은 현재 위치 (0.2, 0)에 (0.1, 0.1)을 더합니다.

두 경로 모두 같은 위치에서 시작합니다. 상대 직선의 경우 X와 Y 오프셋을 현재 위치에 더해 끝점을 얻고, 절대 직선은 직접 끝점을 읽습니다. 좌표를 변환하지 않고 플래그만 전환하면 다른 경로가 됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

두 경로 중 하나를 움직임 동작에 할당하여 프레젠테이션에서 사용할 수 있습니다. 마지막 Boolean 인자는 해당 명령에 상대 좌표를 선택합니다.

### **직선을 곡선으로 교체**

`motion.pptx`를 열어 직선 명령을 삼차 곡선으로 교체합니다. 먼저 두 개의 제어점을 제공하고 그 뒤에 끝점을 제공합니다.

시작 위치는 이전 명령에 의해 제공됩니다. 첫 두 점은 곡선을 형성하고, 세 번째는 목적지이며, 연속된 세 목적지가 아닙니다. 명령 유형, 점 편집 유형 및 점 배열을 함께 업데이트하면 세그먼트가 새로운 기하학에 일관됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx`의 경로는 여전히 세 개의 명령을 갖으며, 중간 명령이 이제 곡선을 정의합니다.

## **저장된 경로 검사 및 편집**

각 `MotionCmdPath`는 `getPoints`, `getCommandType`, `getPointsType`, `isRelative`를 노출합니다. 아래 예제는 `motion.pptx`에 있는 세 개 명령 경로를 사용합니다. 임의 입력의 경우, 효과를 찾고 인덱스로 편집하기 전 명령 유형 및 점 개수를 확인하십시오.

### **명령 및 좌표 읽기**

경로를 변경하지 않고 읽습니다. `End`와 `CloseLoop` 명령은 점이 필요 없으므로 null 점 배열을 허용합니다.

출력은 각 숫자형 명령 유형을 점 목록 전에 상대 좌표 플래그와 짝지어 표시합니다. 이는 경로를 수정하기 전에 끝점과 오프셋을 구분할 수 있게 합니다. 곡선은 세 개의 점을 나열하고, 이 파일의 직선은 하나만 나열합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

목록에는 시작점, (0.25, 0)에서 끝나는 절대 직선, 그리고 종료 명령이 포함됩니다.

### **끝점 변경**

`motion.pptx`를 열어 직선의 점 배열을 교체하여 끝점을 이동합니다.

입력 파일에서 인덱스 0은 시작 명령, 인덱스 1은 직선입니다. 직선의 단일 점을 교체하면 명령 유형, 타이밍, 컬렉션 내 위치를 변경하지 않고 목적지를 바꿉니다. 명령이 절대 좌표를 사용하므로 새 쌍은 추가 오프셋이 아닌 위치를 지정합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx`의 직선은 (0.4, 0.1)에서 끝나며, 원본 파일은 변경되지 않았습니다.

### **구간 교체**

`insert`와 `removeAt`를 사용하여 `motion.pptx`의 직선을 교체합니다. 삽입하면 기존 직선이 인덱스 2로 이동합니다.

이는 기존 좌표를 편집하는 대신 명령 객체를 교체함을 보여줍니다. 삽입 후 컬렉션은 일시적으로 시작 명령, 새로운 직선, 기존 직선, 종료 명령을 포함합니다. 인덱스 2를 제거하면 기존 직선이 삭제되고 새로운 경로가 남습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

저장된 경로는 여전히 세 개의 명령을 가지고 있으며, 새로운 직선은 (0.2, 0.1)에서 끝나고 마지막은 종료 명령입니다.

## **기존 동작 수정 및 확인**

동작의 인덱스를 모를 경우 유형으로 선택합니다. 이 예제는 `rotation.pptx`를 열어 `RotationEffect`를 찾고 각도를 변경한 후 다시 열어 저장된 값을 확인합니다.

유형 검사는 루프가 회전이 아닌 동작을 건너뛰게 합니다. 두 번째 로드에서는 저장된 파일을 별도 프레젠테이션 객체에 읽어 들여 비교가 메모리에 남은 값이 아니라 영구 저장된 데이터를 확인합니다. 이 예제는 알려진 효과가 메인 시퀀스의 첫 번째에 있다고 가정합니다; 유형으로 동작을 선택하는 것이 임의 프레젠테이션에서 올바른 효과를 찾는 것은 아닙니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

출력은 `Rotation preserved: true`입니다. 동일한 유형 검사 패턴을 다른 동작에도 적용하십시오. 전체 보존 검사를 위해 대상 도형, 효과, 동작 유형 및 순서, 타이밍, 경로 명령을 비교하십시오. 부동소수점 값은 숫자 오차를 사용하십시오. 애니메이션 레이아웃이 알려지지 않은 프레젠테이션의 경우, 메인 및 대화형 시퀀스 탐색을 위해 [도형 애니메이션 읽기](/slides/ko/nodejs-java/shape-animation/#read-shape-animations)를 참조하십시오.

## **동작 순서, 프리셋 및 재생**

`BehaviorCollection`의 순서는 효과 작업이 저장된 순서이며, 모든 동작이 자동으로 이전 동작을 기다리는 재생목록이 아닙니다. 타이밍과 포함된 효과가 스케줄을 결정합니다. 동작은 겹칠 수 있으며, 동일 속성에 대한 작업은 `getAdditive`와 `getAccumulate`를 통해 상호 작용할 수 있습니다. 단순히 컬렉션 순서를 바꾸어 “이동 후 회전”을 스케줄하지 말고, 명시적인 타이밍이나 별도 효과를 사용하십시오. 이는 [도형 애니메이션](/slides/ko/nodejs-java/shape-animation/)에 설명되어 있습니다.

`Effect`의 `getType`과 `getSubtype`은 프리셋을 설명합니다. 이는 편집된 동작 트리의 전체 설명이 아닙니다. 동작을 사용자 정의하기 전에 프리셋과 서브타입을 선택하십시오: 프리셋을 변경하면 컬렉션이 재구성되고 사용자 정의 작업이 삭제될 수 있습니다. 예를 들어, 사용자 정의 `Spin` 효과를 `Fade`로 바꾸면 회전 동작이 `set` 및 `filter` 동작으로 교체됩니다. 프리셋이나 서브타입을 변경한 후 컬렉션을 다시 검사하십시오. 프리셋 동작을 비우면 프리셋이 필요로 하는 가시성이나 초기화 작업도 삭제될 수 있습니다. 예제는 가시적인 도형을 사용하고 동작을 교체하도록 의도했으며, 모든 프리셋 구현을 재구성하지는 않습니다.

## **포맷 호환성**

보존된 동작 트리가 모든 뷰어나 내보내기 렌더러에서 동일한 재생을 보장하지는 않습니다. 저장된 데이터와 렌더링된 출력을 별도로 확인하십시오.

| Format or output | What to verify |
| --- | --- |
| PPTX | 주요 예제 형식으로 사용하십시오. 파일을 다시 열어 편집 가능한 동작 트리를 확인하고, 대상 PowerPoint 버전에서 재생을 점검하십시오. |
| PPT | 레거시 바이너리 표현은 PPTX와 다를 수 있습니다. 별도의 저장‑재열 사이클과 재생을 테스트하십시오; PPTX 출력이 성공했다고 모든 사용자 정의 조합이 지원된다고 추론하지 마십시오. |
| PDF, PNG, JPEG, and other static slide images | 정적 슬라이드 이미지이며, 재생 가능한 동작 타임라인이나 최종 애니메이션 프레임을 보장하지 않습니다. |
| [HTML5](/slides/ko/nodejs-java/export-to-html5/) | 지원되는 애니메이션이 활성화된 경우 애니메이션을 재생할 수 있습니다. 브라우저에서 사용자 정의 조합을 테스트하십시오. |
| [Animated GIF](/slides/ko/nodejs-java/convert-powerpoint-to-animated-gif/) | 렌더링된 프레임을 저장하며, 편집 가능한 동작이나 클릭 트리거 인터랙션을 포함하지 않습니다. 실제 렌더링된 움직임을 확인하십시오. |
| [Video](/slides/ko/nodejs-java/convert-powerpoint-to-video/) | 애니메이션 프레임을 렌더링하고 비디오로 인코딩합니다. 지원은 렌더러의 지원 애니메이션 및 효과에 제한됩니다; 명령 및 인터랙티브 이벤트는 편집 가능한 타임라인이 되지 않습니다. |

## **FAQ**

**왜 내 효과에 아무 것도 추가하기 전에 이미 동작이 포함되어 있나요?**

미리 정의된 효과를 생성하면 기본 작업이 생성될 수 있습니다. 동작을 확장하거나 교체하기 전에 이를 검사하십시오.

**동작을 앞쪽으로 이동하면 먼저 재생되나요?**

반드시 그렇지는 않습니다. 컬렉션 순서는 타이밍을 대체하지 못합니다. 지연, 지속시간 및 동일 속성에 대한 작업 간 상호 작용을 확인하십시오.

**왜 종료 명령에 점이 없나요?**

경로의 끝을 표시하며 좌표가 필요 없습니다. 파일에서 읽은 경로를 검사할 때 null 점 배열을 확인하십시오.

**성공적인 왕복이 재생을 확인하기에 충분한가요?**

아니요. 재열은 확인한 속성의 보존을 확인할 뿐입니다. 슬라이드 쇼 플레이어나 애니메이션 내보내기를 별도로 테스트해 시각적 동작을 확인하십시오.