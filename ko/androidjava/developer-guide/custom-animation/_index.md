---
title: Android에서 사용자 지정 애니메이션 동작 만들기 및 수정
linktitle: 사용자 지정 애니메이션
type: docs
weight: 151
url: /ko/androidjava/custom-animation/
keywords:
- 맞춤 애니메이션
- 애니메이션 동작
- 모션 경로
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint 프레젠테이션에서 맞춤 애니메이션 동작 및 편집 가능한 모션 경로를 만들고, 검사하고, 수정합니다."
---
## **개요**

맞춤 애니메이션 동작을 사용하면 색상 변경, 도형 회전 또는 편집 가능한 모션 경로 따위와 같은 애니메이션 효과의 개별 작업을 제어할 수 있습니다. 이 가이드는 동작을 만들고 결합하는 방법, 타이밍을 구성하는 방법, 기존 애니메이션을 검사·수정하는 방법, 그리고 프레젠테이션을 저장하고 다시 열었을 때 속성이 유지되는지 확인하는 방법을 보여줍니다.

미리 정의된 효과와 클릭 트리거에 대해서는 [도형 애니메이션](/slides/ko/androidjava/shape-animation/)을 참고하십시오.

## **애니메이션 모델 이해**

애니메이션은 **Timeline → Sequence → Effect → Behaviors** 로 구성됩니다:

- [getTimeline](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) 메서드는 슬라이드 타임라인을 반환하며, 여기에는 기본 시퀀스와 인터랙티브 시퀀스가 포함됩니다.
- [ISequence](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isequence/) 은 다양한 도형을 대상으로 할 수 있는 효과들을 포함합니다.
- [IEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ieffect/) 은 대상 도형, 프리셋, 서브타입 및 효과 타이밍을 식별합니다.
- [IEffect.getBehaviors](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ieffect/#getBehaviors--) 가 반환하는 컬렉션에는 색상 변경, 이동, 회전, 속성 설정 등 효과를 구현하는 작업이 들어 있습니다.

## **개별 동작 만들기**

[ISequence.addEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 를 호출하여 효과를 만들고 [getBehaviors](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ieffect/#getBehaviors--) 컬렉션에 접근합니다. 프리셋을 사용하면 이 컬렉션이 자동으로 채워집니다. 프리셋을 확장할 때는 해당 작업을 유지하거나, 의도적으로 교체할 경우 [clear](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) 를 사용하십시오.

[IBehaviorFactory](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorfactory/) 는 아래에 나타낸 여덟 가지 동작 유형을 생성합니다. 모션에 대해서는 [모션 경로 만들기](#build-a-motion-path) 를 참고하십시오. 각 스니펫에는 필요한 import 문이 포함되어 있으며, 실행 가능한 구문은 메서드 내부에 배치합니다. 이후 편집 예제에서는 사용한 출력 파일명을 명시합니다. Android에서는 샘플 파일명을 앱이 접근 가능한 디렉터리(예: 앱의 files 디렉터리)의 전체 경로로 교체하십시오.

### **회전**

[createRotationEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) 로 회전 효과를 생성합니다. [getBy](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/irotationeffect/#getBy--) 은 상대 각도를 도(°) 단위로 지정하고, [getFrom](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/irotationeffect/#getFrom--) 과 [getTo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/irotationeffect/#getTo--) 은 시작점과 끝점을 지정합니다.

예제는 Spin 효과를 시작점으로 하여 프리셋 작업을 하나의 회전 동작으로 교체하고, 해당 동작에 2초 지속 시간을 부여합니다. 90도라는 상대 각도는 도형의 시작 방향에서 1/4회전임을 의미하므로 명시적인 시작 각도를 지정할 필요가 없습니다.

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

`rotation.pptx`에는 하나의 도형과 하나의 회전 동작이 들어 있습니다. 아래의 컬렉션, 타이밍 및 회전 편집 예제는 이 파일을 사용합니다.

### **크기 조절**

[X/Y 백분율]을 사용하려면 [createScaleEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) 를 이용합니다. [getFrom](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) 와 [getTo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iscaleeffect/#getTo--) 은 시작 및 종료 크기를 설명하고, [getBy](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iscaleeffect/#getBy--) 은 상대 변화를 나타냅니다. 여기서 100은 원래 크기를 의미합니다.

예제는 두 차원을 100%에서 125%까지 2초에 걸쳐 확대합니다. 가로·세로 비율을 동일하게 지정하면 도형의 비율이 유지되며, 비율을 다르게 지정하면 한 차원이 더 늘어나게 됩니다.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **색상**

[createColorEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) 를 사용하여 채우기 색을 파랑에서 주황색으로 변경합니다. [getFrom](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icoloreffect/#getFrom--) 와 [getTo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icoloreffect/#getTo--) 은 색상이며, [getBy](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icoloreffect/#getBy--) 은 색상 오프셋입니다. [IBehavior.getProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehavior/#getProperties--) 은 애니메이션되는 속성을 식별합니다.

도형의 단색 채우기는 파랑으로 초기화되며, 이는 애니메이션 시작 색과 일치합니다. 채우기 색 속성을 선택하면 동작이 어떤 부분을 변경해야 하는지 지정할 수 있습니다; 색상 끝점만으로는 해당 속성을 알 수 없습니다. 저장된 효과는 2초에 걸쳐 주황색으로 전환하는 것을 설명합니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **필터**

[createFilterEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) 로 와이프 필터를 선택합니다. [getType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--), [getReveal](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) 은 각각 필터 종류, 방향, 도형을 나타낼지 숨길지를 지정합니다.

이 예제는 오른쪽 방향 서브타입을 사용하여 2초 동안 도형을 나타내는 와이프를 구성합니다. 필터 설정은 효과 내부 동작에 속하므로 프리셋의 원래 작업을 제거한 뒤에 구성합니다.

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

[createPropertyEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) 로 불투명도를 애니메이션합니다. [getFrom](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipropertyeffect/#getTo--), [getBy](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) 은 문자열이며, [getValueType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) 와 [getCalcMode](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--) 로 해석됩니다. 세 값을 모두 무분별하게 설정하기보다는 끝점이나 상대 오프셋을 선택하십시오.

여기서는 대상 속성이 불투명도이며, 문자열은 25% 불투명도에서 완전 불투명도로 변경됨을 나타냅니다. 선형 보간은 해당 값들 사이의 점진적 변화를 의미합니다. 다른 속성에 적용할 경우 해당 속성에 맞는 값 타입과 끝점 값을 선택하십시오.

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

[createSetEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) 로 [getTo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iseteffect/#getTo--) 를 통해 가시성을 지정합니다. 설정 동작은 끝점 사이를 보간하지 않습니다.

예제는 가시성 속성을 선택하고 동작이 실행될 때 문자열 `visible` 을 할당합니다. 최소 예제이므로 사각형은 이미 보이므로 자체적으로 눈에 띄는 변화가 없을 수 있습니다. 이러한 동작은 도형이 숨겨지거나 표시되는 시점을 제어하는 더 큰 효과의 일부로 유용합니다.

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

[createCommandEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) 를 사용하고 [getType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icommandeffect/#getCommandString--), [getShapeTarget](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--) 를 구성합니다. 작업 디렉터리에 `sample.wav` 라는 WAV 녹음을 두십시오. 이 예제는 [addAudioFrameEmbedded](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) 로 파일을 삽입하고 재생 명령을 오디오 프레임에 연결합니다.

오디오 프레임은 효과의 대상이자 명령의 대상입니다. 이는 재생 요청을 삽입된 녹음에 연결합니다; 명령 문자열만으로는 어떤 미디어 객체를 제어할지 알 수 없습니다. 이 효과는 슬라이드쇼 중 클릭으로 시작하도록 구성됩니다.

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

저장은 명령을 `command.pptx` 에 저장하지만 녹음을 재생하지는 않습니다. 재생하려면 명령과 미디어 대상을 지원하는 슬라이드쇼 플레이어가 필요합니다.

## **동작 컬렉션 관리**

[IBehaviorCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorcollection/) 은 [add](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), [removeAt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-) 를 지원합니다. 이 예제는 `rotation.pptx` 를 열어 크기 조절을 추가하고, 회전 앞에 삽입한 뒤 회전을 제거합니다. 동일 객체를 제거하고 다시 삽입하면 복사본을 만들지 않고 저장된 위치만 변경됩니다.

편집 순서는 컬렉션을 회전‑크기조절 → 크기조절‑회전 → 크기조절만 남도록 변경합니다. 인덱스는 현재 컬렉션을 기준으로 하므로 재정렬 후 회전의 새로운 인덱스를 사용합니다. 최종 열거는 저장될 동작을 확인합니다.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
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

출력은 `ScaleEffect` 로, 크기조절만 남습니다. 컬렉션 순서는 자체적으로 동작을 순차적으로 실행하도록 예약하지 않습니다. 모든 작업을 교체할 때만 컬렉션을 비우십시오.

## **동작 타이밍 구성**

[IBehavior.getTiming](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehavior/#getTiming--) 은 [IEffect.getTiming](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ieffect/#getTiming--) 와 독립적으로 [ITiming](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiming/) 을 노출합니다. 효과 타이밍은 외부 효과를 예약하고, 동작 타이밍은 그 내부 작업을 설명합니다.

### **지속 시간, 지연, 반복, 가속 설정**

`rotation.pptx` 를 열어 지속 시간([getDuration](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiming/#getDuration--)) 과 트리거 지연([getTriggerDelayTime](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) 을 초 단위로 설정하고, [setRepeatCount](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) 로 반복 횟수를 지정합니다. [getAccelerate](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiming/#getAccelerate--) 와 [getDecelerate](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiming/#getDecelerate--) 은 지속 시간의 비율이며, 두 값의 합은 1 이하로 유지하십시오.

입력 파일은 회전 예제에서 만든 파일이며, 첫 번째 동작이 회전임이 알려져 있습니다. 이 예제는 해당 동작의 타이밍만 변경하고, 90도 각도는 그대로 유지합니다. 각도와 타이밍을 분리하면 애니메이션을 재구성하지 않고도 속도를 조정하기가 쉽습니다.

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

이 동작은 2초 지속, 0.5초 지연, 반복 횟수 3을 사용합니다. 지속 시간의 처음과 마지막 20%는 가속 및 감속에 사용됩니다.

다른 반복 정책으로는 [getRepeatDuration](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), [getRepeatUntilNextClick](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--) 가 있으며, 모든 옵션을 동시에 켜는 대신 하나를 선택하십시오. [getAutoReverse](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itiming/#getAutoReverse--) 은 앞쪽 재생이 끝난 뒤 역방향으로 애니메이션을 재생합니다. 가속·감속은 연속적인 변화에만 적용되며, 이산 할당이나 명령에는 적용되지 않습니다.

## **모션 경로 만들기**

[createMotionEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) 로 모션을 생성합니다. [getFrom](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotioneffect/#getTo--), [getBy](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotioneffect/#getBy--) 은 백분율 기반 좌표 또는 오프셋을 설명합니다. 편집 가능한 경로를 만들려면 [MotionPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/motionpath/) 를 생성하고 [IMotionEffect.setPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) 로 할당합니다. [IMotionPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotionpath/) 은 경로 명령을 저장합니다.

[MotionCommandPathType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/motioncommandpathtype/) 은 작업을 선택합니다:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | 시작 위치를 설정합니다. |
| LineTo | One | 직선 구간을 따라 끝점까지 이동합니다. |
| CurveTo | Three | 두 제어점과 끝점으로 정의된 3차 곡선을 따릅니다. |
| CloseLoop | None | 시작 위치로 되돌아갑니다. |
| End | None | 경로를 종료합니다. |

[MotionPathPointsType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/motionpathpointstype/) 은 코너 포인트 또는 부드러운 포인트와 같은 점 편집 특성을 설명합니다. 이는 명령 유형을 대체하지 않으며, 아래 곡선 예제에서는 곡선 포인트 유형을, 직선 구간에서는 코너 포인트 유형을 사용하십시오.

경로 좌표는 슬라이드 크기에 정규화됩니다. X 변위 0.25는 슬라이드 너비의 1/4을 의미하고, 0.25 포인트가 아닙니다. Y 좌표는 아래쪽이 양수입니다. 절대 명령은 경로 좌표계의 위치를 지정하고, 상대 명령은 현재 위치에서의 오프셋을 지정합니다. 이는 [getOrigin](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotioneffect/#getOrigin--) 이 선택하는 경로 기준 프레임 및 [getPathEditMode](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--) 이 도형 이동 시 경로가 어떻게 움직이는지를 제어하는 것과 별개입니다.

### **직선 경로 만들기**

시작점, 한 개의 직선 구간, 종료 명령으로 구성된 모션 동작을 생성합니다. [IMotionPath.add](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) 은 명령 유형, 해당 점들, 점 유형, 상대 좌표 플래그를 받습니다.

시작 명령은 (0, 0) 을 설정하고, 선 명령은 (0.25, 0) 으로 끝나 슬라이드 너비의 1/4 만큼 수평 이동합니다. 종료 명령은 좌표 점이 없습니다. 경로를 할당한 뒤 효과에 모션 동작을 추가하면 해당 경로가 사각형에 연결됩니다.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx`에는 세 개의 경로 명령을 가진 하나의 모션 동작이 들어 있습니다. 아래 파일 편집 예제는 이 구조를 전제로 합니다.

### **절대 좌표와 상대 좌표 비교**

두 경로 객체는 동일한 경로를 설명합니다. 절대 명령은 (0.3, 0.1) 에 끝나고, 상대 명령은 현재 위치에 (0.1, 0.1) 을 추가하여 (0.2, 0) 로 이동합니다.

두 경로 모두 동일한 시작 위치에서 시작합니다. 상대 선의 경우 현재 위치에 X·Y 오프셋을 더해 끝점을 구하고, 절대 선은 끝점을 그대로 읽습니다. 좌표 변환 없이 플래그만 전환하면 다른 경로가 됩니다.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

어느 경로든 모션 동작에 할당하면 프레젠테이션에서 사용할 수 있습니다. 마지막 Boolean 인자는 해당 명령에 상대 좌표를 사용할지 여부를 선택합니다.

### **선을 곡선으로 교체**

`motion.pptx` 를 열어 선 명령을 3차 곡선으로 교체합니다. 먼저 두 제어점을 제공하고, 이어서 끝점을 지정합니다.

시작 위치는 앞선 명령이 제공합니다. 첫 두 점이 곡선을 형성하고, 세 번째 점이 목적지입니다; 이는 연속적인 목적지가 아니라 하나의 곡선 정의입니다. 명령 유형, 점 편집 유형, 점 배열을 함께 업데이트하면 새 기하학에 맞게 구간이 일관됩니다.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx`의 경로는 여전히 세 개의 명령을 가지고 있으며, 가운데 명령이 이제 곡선을 정의합니다.

## **저장된 경로 검사 및 편집**

각 [IMotionCmdPath](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotioncmdpath/) 은 [getPoints](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--), [isRelative](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--) 를 노출합니다. 아래 예제는 `motion.pptx` 의 알려진 세 명령 경로를 사용합니다. 임의 입력의 경우, 편집하기 전에 대상 효과를 찾고 명령 유형과 점 개수를 확인하십시오.

### **명령 및 좌표 읽기**

경로를 변경 없이 읽습니다. 종료 및 닫기 루프 명령은 점이 필요 없으므로 null 점 배열을 허용합니다.

출력은 각 숫자 명령 유형과 상대 좌표 플래그를 쌍으로 표시한 뒤 점들을 나열합니다. 이를 통해 경로를 수정하기 전에 끝점과 오프셋을 구분할 수 있습니다. 곡선은 세 점을, 여기 파일의 직선은 한 점만 나열합니다.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

목록에는 시작점, (0.25, 0) 에 끝나는 절대 선, 그리고 종료 명령이 포함됩니다.

### **끝점 변경**

`motion.pptx` 를 열고 선의 점 배열을 교체하여 끝점을 이동합니다.

입력 파일에서 인덱스 0은 시작 명령, 인덱스 1은 선입니다. 선의 단일 점을 교체하면 명령 유형, 타이밍, 컬렉션 내 위치는 바뀌지 않고 목적지만 변경됩니다. 명령이 절대 좌표를 사용하므로 새 쌍은 오프셋이 아니라 위치를 지정합니다.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx` 의 선은 (0.4, 0.1) 에 끝나며, 원본 파일은 그대로 유지됩니다.

### **구간 교체**

[insert](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) 와 [removeAt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) 를 사용해 `motion.pptx` 의 선을 교체합니다. 삽입 시 기존 선이 인덱스 2 로 이동합니다.

이는 기존 좌표를 편집하는 대신 명령 객체 자체를 교체하는 방법을 보여줍니다. 삽입 후 컬렉션은 일시적으로 시작 명령, 새 선, 기존 선, 종료 명령을 포함합니다. 인덱스 2 를 제거하면 기존 선이 사라지고 새 경로가 남습니다.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

저장된 경로는 여전히 세 개의 명령을 가지고 있으며, 새 선은 (0.2, 0.1) 에 끝나고 종료 명령이 마지막에 위치합니다.

## **기존 동작 수정 및 확인**

동작 인덱스를 모를 경우 타입으로 선택합니다. 이 예제는 `rotation.pptx` 를 열어 [IRotationEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/irotationeffect/) 를 찾고 각도를 변경한 뒤 다시 열어 저장된 값을 확인합니다.

타입 검사를 통해 회전이 아닌 동작을 건너뛸 수 있습니다. 두 번째 로드에서는 저장된 파일을 별도 프레젠테이션 객체에 읽어 들여 메모리에 남아 있는 값이 아니라 지속된 데이터를 비교합니다. 이 예제는 알려진 효과가 기본 시퀀스의 첫 번째에 있다고 가정합니다; 타입으로 동작을 선택한다고 해서 임의 프레젠테이션에서 올바른 효과를 찾는 것은 아닙니다.

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

출력은 `Rotation preserved: true` 입니다. 동일한 타입 검사 패턴을 다른 동작에도 적용하십시오. 전체 보존 검사를 위해서는 대상 도형, 효과, 동작 타입 및 순서, 타이밍, 경로 명령을 비교하고 부동소수점 값은 수치 허용오차를 사용하십시오. 애니메이션 레이아웃을 알 수 없는 프레젠테이션에 대해서는 [도형 애니메이션 읽기](/slides/ko/androidjava/shape-animation/#read-shape-animations) 를 참고해 기본 및 인터랙티브 시퀀스를 순회하십시오.

## **동작 순서, 프리셋 및 재생**

[IBehaviorCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehaviorcollection/) 의 순서는 효과 작업의 저장 순서이며, 각 동작이 자동으로 앞의 동작을 기다리는 재생 목록이 아닙니다. 타이밍과 외부 효과가 스케줄을 결정합니다. 동작은 겹칠 수 있으며, 같은 속성에 대한 작업은 [getAdditive](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehavior/#getAdditive--) 와 [getAccumulate](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibehavior/#getAccumulate--) 로 상호 작용할 수 있습니다. 컬렉션 순서만으로 “이동 후 회전”을 예약하지 말고, [도형 애니메이션](/slides/ko/androidjava/shape-animation/) 에 설명된 대로 명시적인 타이밍이나 별도 효과를 사용하십시오.

효과의 [getType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ieffect/#getType--) 과 [getSubtype](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ieffect/#getSubtype--) 은 프리셋을 설명합니다. 이는 편집된 동작 트리의 전체 설명이 아니므로, 동작을 사용자 정의하기 전에 프리셋과 서브타입을 선택하십시오. 프리셋을 변경하면 컬렉션이 재구성되어 사용자 정의 작업이 사라질 수 있습니다. 예를 들어, 사용자 정의 Spin 효과를 Fade 로 변경하면 회전 동작이 설정·필터 동작으로 교체됩니다. 프리셋이나 서브타입을 변경한 뒤 컬렉션을 다시 검사하십시오. 프리셋 동작을 비우면 프리셋이 필요로 하는 가시성·초기화 작업도 제거될 수 있습니다. 예제에서는 가시적인 도형을 사용하고 동작을 교체했으며, 모든 프리셋 구현을 재구성하지는 않습니다.

## **포맷 호환성**

보존된 동작 트리가 모든 뷰어나 출력 렌더러에서 동일한 재생을 보장하지는 않습니다. 저장된 데이터와 렌더링 결과를 별도로 확인하십시오.

| Format or output | What to verify |
| --- | --- |
| PPTX | 이 예제의 기본 포맷으로 사용합니다. 파일을 다시 열어 수정 가능한 동작 트리를 확인한 뒤, 원하는 PowerPoint 버전에서 재생을 체크하십시오. |
| PPT | 레거시 바이너리 형식은 PPTX와 다를 수 있습니다. 별도 저장‑재열 사이클과 재생을 테스트하십시오; PPTX 출력이 성공했다고 해서 모든 사용자 정의 조합이 지원된다고 추론하지 마십시오. |
| PDF, PNG, JPEG 및 기타 정적 슬라이드 이미지 | 정적 슬라이드 표현이며, 재생 가능한 동작 타임라인이나 최종 애니메이션 프레임을 보장하지 않습니다. |
| [HTML5](/slides/ko/androidjava/export-to-html5/) | 도형 애니메이션이 내보내기 옵션에서 활성화된 경우 지원되는 애니메이션을 재생할 수 있습니다. 브라우저에서 사용자 정의 조합을 테스트하십시오. |
| [Animated GIF](/slides/ko/androidjava/convert-powerpoint-to-animated-gif/) | 렌더링된 프레임을 저장하며, 편집 가능한 동작이나 클릭 트리거 인터랙션은 포함하지 않습니다. 실제 렌더링된 모션을 확인하십시오. |
| [Video](/slides/ko/androidjava/convert-powerpoint-to-video/) | 애니메이션 프레임을 렌더링하고 비디오로 인코딩합니다. 지원은 렌더러의 [지원 애니메이션 및 효과](/slides/ko/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) 에 제한되며, 명령 및 인터랙티브 이벤트는 편집 가능한 타임라인이 되지 않습니다. |

## **FAQ**

**내 효과에 동작이 없는데도 동작이 포함되어 있는 이유는?**

미리 정의된 효과를 생성하면 기본 작업이 자동으로 생성될 수 있습니다. 프리셋을 확장할지 교체할지 결정하기 전에 이를 확인하십시오.

**동작을 처음으로 이동하면 먼저 재생되나요?**

반드시 그렇지는 않습니다. 컬렉션 순서는 타이밍을 대신하지 못합니다. 지연, 지속 시간 및 같은 속성에 대한 작업 간 상호 작용을 확인하십시오.

**끝점 명령에 점이 없는 이유는?**

끝점 명령은 경로의 종료를 표시하며 좌표가 필요하지 않습니다. 파일에서 경로를 읽을 때 null 점 배열을 검사하십시오.

**라운드 트립이 성공했다고 해서 재생이 보장되나요?**

아니요. 재열은 확인한 속성 보존만 입증합니다. 슬라이드쇼 플레이어나 애니메이션 내보내기를 별도로 테스트하여 시각적 동작을 확인하십시오.