---
title: Java에서 사용자 정의 애니메이션 동작 만들기 및 수정
linktitle: 사용자 정의 애니메이션
type: docs
weight: 151
url: /ko/java/custom-animation/
keywords:
- 사용자 정의 애니메이션
- 애니메이션 동작
- 모션 경로
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에서 사용자 정의 애니메이션 동작 및 편집 가능한 모션 경로를 만들고, 검사하고, 수정합니다."
---
## **개요**

사용자 지정 애니메이션 동작을 사용하면 색상 변경, 도형 회전 또는 편집 가능한 움직임 경로 따라가기와 같은 애니메이션 효과 내의 개별 작업을 제어할 수 있습니다. 이 가이드에서는 동작을 만들고 결합하는 방법, 타이밍을 구성하는 방법, 기존 애니메이션을 검사·수정하는 방법, 그리고 프레젠테이션을 저장·다시 열었을 때 속성이 유지되는지 확인하는 방법을 보여줍니다.

미리 정의된 효과와 클릭 트리거에 대해서는 [도형 애니메이션](/slides/ko/java/shape-animation/)을 참조하십시오.

## **애니메이션 모델 이해**

애니메이션은 **Timeline → Sequence → Effect → Behaviors** 형태로 구성됩니다:

- [getTimeline](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseslide/#getTimeline--) 메서드는 슬라이드 타임라인을 반환하며, 여기에는 메인 시퀀스와 인터랙티브 시퀀스가 포함됩니다.
- [ISequence](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isequence/) 은 효과들을 포함하며, 서로 다른 도형을 대상으로 할 수 있습니다.
- [IEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/) 은 대상 도형, 프리셋, 서브타입 및 효과 타이밍을 식별합니다.
- [IEffect.getBehaviors](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#getBehaviors--) 가 반환하는 컬렉션에는 색상 변경, 이동, 회전, 속성 설정 등 효과를 구현하는 작업이 들어 있습니다.

## **개별 동작 만들기**

[ISequence.addEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 를 호출해 효과를 만든 뒤 [getBehaviors](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#getBehaviors--) 컬렉션에 접근합니다. 프리셋을 사용하면 이 컬렉션이 자동으로 채워집니다. 프리셋을 확장할 때는 기존 작업을 유지하고, 의도적으로 교체할 경우에는 [clear](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorcollection/#clear--) 를 사용하십시오.

[IBehaviorFactory](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorfactory/) 는 아래에 예시된 8가지 동작 유형을 생성합니다. 움직임은 [Build a Motion Path](#build-a-motion-path)에서 다룹니다. 각 스니펫에는 import 문이 포함되어 있으며, 실행 가능한 문장은 메서드 내부에 배치합니다. 이후 편집 예제는 어떤 출력 파일을 사용하는지 명시합니다.

### **회전**

[createRotationEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) 로 회전 효과를 생성합니다. [getBy](https://reference.aspose.com/slides/ko/java/com.aspose.slides/irotationeffect/#getBy--) 는 상대 각도를 도 단위로 지정하고, [getFrom](https://reference.aspose.com/slides/ko/java/com.aspose.slides/irotationeffect/#getFrom--) 와 [getTo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/irotationeffect/#getTo--) 은 시작·끝 지점을 지정합니다.

예제는 Spin 효과를 시작으로, 프리셋 작업을 하나의 회전 동작으로 교체하고 해당 동작에 2초 지속 시간을 부여합니다. 90도 상대 각도는 도형의 초기 방향에서 ¼ 회전을 의미하므로 명시적인 시작 각도는 필요하지 않습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` 에는 하나의 도형과 하나의 회전 동작이 들어 있습니다. 아래 컬렉션, 타이밍 및 회전 편집 예제는 이 파일을 사용합니다.

### **크기 조정**

[createScaleEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) 를 X/Y 백분율과 함께 사용합니다. [getFrom](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iscaleeffect/#getFrom--) 와 [getTo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iscaleeffect/#getTo--) 은 시작·끝 크기를 설명하고, [getBy](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iscaleeffect/#getBy--) 은 상대 변화를 설명합니다. 여기서 100은 원본 크기를 의미합니다.

예제는 두 차원을 100%에서 125% 로 2초 동안 확대합니다. 가로·세로 비율을 동일하게 유지하면 도형의 비율이 보존되고, 비율이 다르면 한 차원이 더 늘어납니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **색상**

[createColorEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) 로 채우기 색을 파란색에서 주황색으로 변경합니다. [getFrom](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icoloreffect/#getFrom--) 와 [getTo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icoloreffect/#getTo--) 은 색상이고, [getBy](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icoloreffect/#getBy--) 는 색상 오프셋입니다. [IBehavior.getProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehavior/#getProperties--) 는 애니메이션 대상 속성을 식별합니다.

도형의 단색 채우기는 파란색으로 초기화되어 애니메이션 시작 색과 일치합니다. 채우기 색 속성을 선택하면 동작이 어느 부분을 바꿔야 하는지 알려 주며, 색상 끝점만으로는 속성을 지정할 수 없습니다. 저장된 효과는 2초 동안 주황색으로 전환된다고 설명합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **필터**

[createFilterEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) 로 와이프 효과를 선택합니다. [getType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifiltereffect/#getSubtype--), [getReveal](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ifiltereffect/#getReveal--) 은 필터 종류, 방향, 그리고 도형을 표시할지 숨길지를 지정합니다.

이 예제는 오른쪽 방향 서브타입을 사용해 도형을 표시하는 2초 와이프를 구성합니다. 필터 설정은 효과 내부 동작에 속하므로 프리셋의 원래 작업을 제거한 뒤에 설정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **속성**

[createPropertyEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) 로 불투명도를 애니메이션합니다. [getFrom](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipropertyeffect/#getTo--), [getBy](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipropertyeffect/#getBy--) 은 문자열이며, [getValueType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipropertyeffect/#getValueType--) 과 [getCalcMode](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipropertyeffect/#getCalcMode--) 로 해석됩니다. 세 값을 모두 설정하기보다 끝점이나 상대 오프셋을 선택하십시오.

여기서는 속성으로 불투명도를 선택했고, 문자열은 25% 불투명도에서 완전 불투명도로 변함을 의미합니다. 선형 보간법은 두 값 사이를 점진적으로 변화시킵니다. 다른 속성에 적용할 경우 해당 속성에 맞는 값 유형과 끝점 값을 선택하십시오.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **설정**

[createSetEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) 로 [getTo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iseteffect/#getTo--) 를 사용해 가시성을 지정합니다. 설정 동작은 끝점 사이를 보간하지 않습니다.

예제는 가시성 속성을 선택하고 동작이 실행될 때 문자열 `visible` 을 할당합니다. 이 최소 프레젠테이션의 사각형은 이미 보이므로 단독으로는 눈에 띄는 변화가 없을 수 있습니다. 하지만 더 큰 효과의 일부로 도형을 숨기거나 표시하는 시점과 함께 사용할 때 유용합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **명령**

[createCommandEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) 를 사용하고 [getType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icommandeffect/#getCommandString--), [getShapeTarget](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icommandeffect/#getShapeTarget--) 를 구성합니다. 작업 디렉터리에 `sample.wav` 라는 WAV 파일을 배치하십시오. 이 예제는 [addAudioFrameEmbedded](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) 로 파일을 삽입하고 오디오 프레임에 재생 명령을 연결합니다.

오디오 프레임은 효과와 명령 모두의 대상이 됩니다. 이렇게 하면 삽입된 녹음에 대한 재생 요청이 연결되며, 명령 문자열만으로는 어떤 미디어 객체를 제어할지 알 수 없습니다. 효과는 슬라이드 쇼 중 클릭 시 시작하도록 구성됩니다.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

저장하면 `command.pptx` 에 명령이 저장되지만 녹음은 재생되지 않습니다. 재생하려면 해당 명령과 미디어 대상을 지원하는 슬라이드 쇼 플레이어가 필요합니다.

## **동작 컬렉션 관리**

[IBehaviorCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorcollection/) 은 [add](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), [removeAt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-) 를 지원합니다. 이 예제는 `rotation.pptx` 를 열어 스케일을 추가하고 회전 앞에 배치한 뒤 회전을 제거합니다. 동일 객체를 제거하고 다시 삽입하면 복제 없이 위치만 변경됩니다.

편집 순서는 컬렉션을 회전‑스케일 → 스케일‑회전 → 스케일만으로 변경합니다. 인덱스는 현재 컬렉션을 기준으로 하므로, 재정렬 후 회전의 새로운 인덱스를 사용해 제거합니다. 최종 열거를 통해 저장될 동작을 확인합니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

출력은 `ScaleEffect` 로, 스케일만 남습니다. 컬렉션 순서 자체가 동작을 연속 실행하게 하지는 않습니다. 모든 작업을 교체할 때만 컬렉션을 비우십시오.

## **동작 타이밍 구성**

[IBehavior.getTiming](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehavior/#getTiming--) 은 [ITiming](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/) 을 노출하며, 이는 [IEffect.getTiming](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#getTiming--) 과는 별개입니다. 효과 타이밍은 전체 효과를 스케줄링하고, 동작 타이밍은 그 안의 개별 작업을 스케줄링합니다.

### **지속 시간, 지연, 반복 및 가속 설정**

`rotation.pptx` 를 열어 지속 시간([getDuration](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getDuration--)) 과 트리거 지연([getTriggerDelayTime](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) 을 초 단위로 설정하고, [setRepeatCount](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#setRepeatCount-float-) 로 반복 횟수를 지정합니다. [getAccelerate](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getAccelerate--) 와 [getDecelerate](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getDecelerate--) 은 지속 시간의 비율이며, 두 값의 합은 1을 초과하지 않아야 합니다.

입력 파일은 회전 예제에서 만든 파일이며, 첫 번째 동작이 회전임이 알려져 있습니다. 이 예제는 해당 동작의 타이밍만 변경하고, 90도 회전 각도는 그대로 유지합니다. 각도와 타이밍을 분리하면 애니메이션 속도를 재구성 없이 조정하기가 쉽습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

동작은 2초 지속, 0.5초 지연, 반복 횟수 3을 사용합니다. 전체 지속 시간의 앞·뒤 20%는 가속·감속에 사용됩니다.

다른 반복 정책으로는 [getRepeatDuration](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), [getRepeatUntilNextClick](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--) 가 있으며, 모두를 동시에 활성화하지 말고 하나를 선택하십시오. [getAutoReverse](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getAutoReverse--) 은 전방 재생 후 역방향 재생을 실행합니다. 가속·감속은 연속적인 변화에만 적용되며, 이산적인 할당이나 명령에는 적용되지 않습니다.

## **움직임 경로 만들기**

[createMotionEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) 로 움직임을 생성합니다. [getFrom](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotioneffect/#getTo--), [getBy](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotioneffect/#getBy--) 은 백분율 기반 좌표 또는 오프셋을 설명합니다. 편집 가능한 경로를 만들려면 [MotionPath](https://reference.aspose.com/slides/ko/java/com.aspose.slides/motionpath/) 를 생성하고 [IMotionEffect.setPath](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) 로 할당합니다. [IMotionPath](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotionpath/) 는 경로 명령을 저장합니다.

[MotionCommandPathType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/motioncommandpathtype/) 은 동작을 선택합니다:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | 시작 위치를 설정합니다. |
| LineTo | One | 직선 구간을 끝점까지 이동합니다. |
| CurveTo | Three | 두 개의 제어점과 끝점으로 정의된 3차 곡선을 따릅니다. |
| CloseLoop | None | 시작 위치로 돌아갑니다. |
| End | None | 경로를 종료합니다. |

[MotionPathPointsType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/motionpathpointstype/) 은 코너 포인트·스무스 포인트 등 포인트 편집 특성을 설명합니다. 이는 명령 타입을 대체하지 않으며, 아래 곡선 예제에서는 곡선 포인트 타입을, 직선 구간에서는 코너 포인트 타입을 사용합니다.

경로 좌표는 슬라이드 크기에 정규화됩니다. X 이동 0.25 는 슬라이드 너비의 ¼을 의미하며, 0.25 포인트가 아닙니다. Y 좌표는 아래쪽이 양수입니다. 절대 명령은 경로 좌표계에서 위치를 지정하고, 상대 명령은 현재 위치에서의 오프셋을 지정합니다. 이는 [getOrigin](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotioneffect/#getOrigin--) 이 경로 기준 프레임을 선택하고, [getPathEditMode](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotioneffect/#getPathEditMode--) 가 도형 이동 시 경로가 어떻게 움직이는지를 제어하는 것과는 별개입니다.

### **직선 경로 만들기**

시작점, 하나의 직선 구간, 종료 명령을 가진 움직임 동작을 생성합니다. [IMotionPath.add](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) 은 명령 타입, 포인트 배열, 포인트 타입, 상대 좌표 플래그를 받습니다.

시작 명령은 (0, 0)을 설정하고, 직선은 (0.25, 0) 으로 끝나 슬라이드 너비의 ¼ 만큼 수평 이동합니다. 종료 명령은 좌표가 없습니다. 경로를 할당한 뒤 움직임 동작을 효과에 추가하면 해당 경로가 사각형에 연결됩니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` 에는 세 개의 경로 명령을 가진 하나의 움직임 동작이 포함됩니다. 아래 파일 편집 예제는 이 구조를 전제로 합니다.

### **절대 좌표와 상대 좌표 비교**

다음 두 경로 객체는 같은 경로를 나타냅니다. 절대 명령은 (0.3, 0.1) 에 끝나고, 상대 명령은 현재 위치에 (0.1, 0.1)을 더해 (0.2, 0) 로 이동합니다.

두 경로 모두 같은 시작 위치에서 시작합니다. 상대 직선의 경우 현재 위치에 X·Y 오프셋을 더해 끝점을 구하고, 절대 직선은 끝점을 직접 읽습니다. 좌표 변환 없이 플래그만 전환하면 다른 경로가 됩니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

경로를 움직임 동작에 할당하면 프레젠테이션에서 사용할 수 있습니다. 마지막 Boolean 인자는 해당 명령에 상대 좌표를 사용할지 여부를 선택합니다.

### **직선을 곡선으로 교체**

`motion.pptx` 를 열어 직선 명령을 3차 곡선으로 교체합니다. 먼저 두 개의 제어점을 제공하고 끝점을 지정합니다.

시작 위치는 앞선 명령이 제공합니다. 첫 두 포인트가 곡선을 만들고, 세 번째 포인트가 곡선의 목적지가 됩니다; 이것은 세 개의 연속 목적지가 아니라는 점을 기억하십시오. 명령 타입, 포인트 편집 타입, 포인트 배열을 함께 업데이트하면 새 기하학에 맞게 구간이 일관됩니다.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx` 의 경로는 여전히 세 개의 명령을 가지고 있지만, 중간 명령이 이제 곡선을 정의합니다.

## **저장된 경로 검사 및 편집**

각 [IMotionCmdPath](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotioncmdpath/) 은 [getPoints](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotioncmdpath/#getPointsType--), [isRelative](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotioncmdpath/#isRelative--) 를 제공한다. 아래 예제는 `motion.pptx` 에 있는 알려진 세 명령 경로를 사용한다. 임의 입력의 경우, 편집하기 전에 원하는 효과를 찾아 명령 타입과 포인트 수를 확인하고 인덱스로 접근한다.

### **명령과 좌표 읽기**

경로를 변경 없이 읽어들인다. 종료 및 닫힘 명령은 포인트가 필요 없으므로 null 포인트 배열을 허용한다.

출력은 각 숫자형 명령 타입과 상대 좌표 플래그를 쌍으로 표시하고, 그 뒤에 포인트를 나열한다. 이렇게 하면 경로를 수정하기 전에 끝점과 오프셋을 구분할 수 있다. 곡선은 세 개의 포인트를, 이 파일의 직선은 하나만 나열한다.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

목록에는 시작점, (0.25, 0) 에 끝나는 절대 직선, 그리고 종료 명령이 포함된다.

### **끝점 변경**

`motion.pptx` 를 열어 직선의 포인트 배열을 교체해 끝점을 이동시킨다.

입력 파일에서 인덱스 0 은 시작 명령, 인덱스 1 은 직선이다. 직선의 단일 포인트를 교체하면 명령 타입, 타이밍, 컬렉션 내 위치는 그대로 두고 목적지만 바뀐다. 명령이 절대 좌표를 사용하므로 새 쌍은 추가 오프셋이 아니라 위치를 지정한다.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx` 의 직선은 (0.4, 0.1) 에 끝나며 원본 파일은 변경되지 않는다.

### **구간 교체**

[insert](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) 와 [removeAt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imotionpath/#removeAt-int-) 를 사용해 `motion.pptx` 의 직선을 교체한다. 삽입 시 기존 직선은 인덱스 2 로 이동한다.

이는 기존 좌표를 편집하는 대신 명령 객체 자체를 교체한다는 것을 보여준다. 삽입 후 컬렉션은 일시적으로 시작 명령, 새 직선, 오래된 직선, 종료 명령 순으로 구성된다. 인덱스 2 를 제거하면 오래된 직선이 사라지고 새 경로가 남는다.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

저장된 경로는 여전히 세 개의 명령을 가지고 있으며, 새 직선은 (0.2, 0.1) 에 끝나고 종료 명령이 마지막에 있다.

## **기존 동작 수정 및 검증**

동작의 인덱스를 모를 경우 타입으로 선택한다. 이 예제는 `rotation.pptx` 를 열어 [IRotationEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/irotationeffect/) 를 찾고 각도를 변경한 뒤 다시 열어 저장된 값을 확인한다.

타입 검사를 통해 회전이 아닌 동작은 루프에서 건너뛰게 된다. 두 번째 로드는 저장된 파일을 별도 프레젠테이션 객체에 읽어 들여 메모리에 남아 있는 값이 아니라 지속된 데이터를 비교한다. 이 예제는 알려진 효과가 메인 시퀀스 첫 번째에 있다고 가정한다; 타입으로 동작을 선택한다고 해서 임의 프레젠테이션에서 정확한 효과를 찾을 수는 없다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

출력은 `Rotation preserved: true` 이다. 동일한 타입 검사 패턴을 다른 동작에도 적용한다. 완전한 보존 검증을 위해서는 대상 도형, 효과, 동작 타입 및 순서, 타이밍, 경로 명령을 비교하고 부동소수점 값은 수치적 허용오차를 사용한다. 애니메이션 레이아웃을 모르는 경우 [Read Shape Animations](/slides/ko/java/shape-animation/#read-shape-animations) 를 참고해 메인 및 인터랙티브 시퀀스를 순회한다.

## **동작 순서, 프리셋 및 재생**

[IBehaviorCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehaviorcollection/) 내 순서는 효과 작업의 저장 순서이며, 각각이 자동으로 앞의 동작을 기다리는 재생 목록이 아니다. 타이밍과 포함된 효과가 스케줄을 결정한다. 동작은 겹칠 수 있으며, 동일 속성에 대한 작업은 [getAdditive](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehavior/#getAdditive--) 와 [getAccumulate](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibehavior/#getAccumulate--) 로 상호 작용할 수 있다. “이동 후 회전” 과 같이 컬렉션 순서만으로 스케줄링하지 말고, [Shape Animation](/slides/ko/java/shape-animation/) 에 설명된 대로 명시적 타이밍이나 별도 효과를 사용한다.

효과의 [getType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#getType--) 와 [getSubtype](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#getSubtype--) 은 프리셋을 설명하지만, 편집된 동작 트리의 전체 설명은 아니다. 프리셋과 서브타입을 선택한 뒤 동작을 사용자 정의하고, 프리셋을 변경하면 컬렉션이 다시 구축되어 사용자 정의 작업이 사라질 수 있다. 예를 들어, 사용자 정의 Spin 효과를 Fade 로 바꾸면 회전 동작이 설정·필터 동작으로 교체된다. 프리셋이나 서브타입을 바꾼 뒤 컬렉션을 다시 검사한다. 프리셋 동작을 비우면 프리셋에 필요한 가시성 또는 초기화 작업도 사라질 수 있다. 예제는 가시적인 도형을 사용하고 동작을 교체했으며, 모든 프리셋 구현을 재구성하지는 않는다.

## **포맷 호환성**

보존된 동작 트리가 모든 뷰어나 내보내기 렌더러에서 동일하게 재생된다는 보장은 하지 않는다. 저장된 데이터와 실제 렌더링 결과를 별도로 확인한다.

| 포맷 또는 출력 | 확인 항목 |
| --- | --- |
| PPTX | 예제의 기본 포맷으로 사용한다. 다시 열어 편집 가능한 동작 트리를 검증한 뒤, 목표 PowerPoint 버전에서 재생을 확인한다. |
| PPT | 레거시 바이너리 형식은 PPTX 와 다를 수 있다. 별도의 저장·재열 및 재생 테스트를 수행하고, PPTX 출력만으로 모든 사용자 정의 조합이 지원된다고 추론하지 않는다. |
| PDF, PNG, JPEG 및 기타 정적 슬라이드 이미지 | 정적인 슬라이드 표현이며, 재생 가능한 동작 타임라인이나 최종 애니메이션 프레임을 보장하지 않는다. |
| [HTML5](/slides/ko/java/export-to-html5/) | 내보내기 옵션에서 도형 애니메이션을 활성화하면 지원되는 애니메이션을 재생할 수 있다. 브라우저에서 사용자 정의 조합을 테스트한다. |
| [Animated GIF](/slides/ko/java/convert-powerpoint-to-animated-gif/) | 렌더링된 프레임을 저장하지만, 편집 가능한 동작이나 클릭 트리거 인터랙션은 포함되지 않는다. 실제 렌더링된 움직임을 확인한다. |
| [Video](/slides/ko/java/convert-powerpoint-to-video/) | 애니메이션 프레임을 렌더링하고 비디오로 인코딩한다. 지원은 렌더러의 [supported animations and effects](/slides/ko/java/convert-powerpoint-to-video/#supported-animations-and-effects) 에 제한되며, 명령 및 인터랙티브 이벤트는 편집 가능한 타임라인이 되지 않는다. |

## **FAQ**

**내 효과에 동작이 추가된 이유가 무엇인가요?**

미리 정의된 효과를 만들면 기본 작업이 자동으로 생성될 수 있습니다. 프리셋을 확장하거나 동작을 교체할지 결정하기 전에 이를 확인하십시오.

**동작을 시작 부분으로 이동하면 먼저 재생되나요?**

반드시 그렇지는 않습니다. 컬렉션 순서는 타이밍을 대신하지 못합니다. 지연, 지속 시간 및 동일 속성에 대한 작업 간 상호 작용을 확인하십시오.

**종료 명령에 포인트가 없는 이유는?**

종료 명령은 경로의 끝을 표시하며 좌표가 필요하지 않습니다. 파일에서 경로를 읽을 때 null 포인트 배열을 검사하십시오.

**라운드 트립이 성공했다고 해서 재생이 보장되나요?**

아니요. 재열은 확인한 속성의 보존을 증명하지만, 슬라이드 쇼 플레이어나 애니메이션 내보내기로 시각적 동작을 별도 테스트해야 합니다.