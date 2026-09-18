---
title: .NET에서 사용자 정의 애니메이션 동작 만들기 및 수정
linktitle: 사용자 정의 애니메이션
type: docs
weight: 151
url: /ko/net/custom-animation/
keywords:
- 사용자 정의 애니메이션
- 애니메이션 동작
- 모션 경로
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에서 사용자 정의 애니메이션 동작 및 편집 가능한 모션 경로를 만들고, 검사하고, 수정합니다."
---
## **개요**

맞춤 애니메이션 동작을 사용하면 색상 변경, 도형 회전 또는 편집 가능한 움직임 경로 추적과 같은 애니메이션 효과 내 개별 작업을 제어할 수 있습니다. 이 가이드에서는 동작을 만들고 결합하는 방법, 타이밍을 구성하는 방법, 기존 애니메이션을 검사·수정하는 방법, 그리고 프레젠테이션을 저장하고 다시 열어도 속성이 유지되는지 확인하는 방법을 보여줍니다.

미리 정의된 효과와 클릭 트리거에 대해서는 [모양 애니메이션](/slides/ko/net/shape-animation/)을 참조하세요.

## **애니메이션 모델 이해하기**

애니메이션은 **Timeline → Sequence → Effect → Behaviors** 로 조직됩니다:

- 슬라이드의 [Timeline](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseslide/timeline/)에는 기본 시퀀스와 인터랙티브 시퀀스가 포함됩니다.
- [ISequence](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/isequence/)는 효과를 포함하며, 서로 다른 도형을 대상으로 할 수 있습니다.
- [IEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/)는 대상 도형, 프리셋, 서브타입 및 효과 타이밍을 식별합니다.
- [IEffect.Behaviors](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/behaviors/)는 색상 변경, 이동, 회전, 속성 설정 등 효과를 구현하는 작업을 포함합니다.

## **개별 동작 만들기**

[ISequence.AddEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/isequence/addeffect/)를 호출하여 효과를 생성하고 해당 효과의 [Behaviors](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/behaviors/) 컬렉션에 접근합니다. 프리셋은 이 컬렉션을 자동으로 채울 수 있습니다. 프리셋을 확장할 때는 기존 작업을 유지하거나, 의도적으로 교체할 경우 [Clear](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorcollection/clear/)를 사용하십시오.

[IBehaviorFactory](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorfactory/)는 아래에 표시된 8가지 동작 유형을 생성합니다. 움직임은 [Build a Motion Path](#build-a-motion-path)에서 다룹니다. 각 생성 예제는 완전한 프로그램이며, 이후 편집 예제는 어떤 출력 파일을 사용하는지 명시합니다.

### **회전**

[CreateRotationEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/)를 사용하여 회전을 생성합니다. [By](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/irotationeffect/by/)는 상대 각도를 도(degree) 단위로 지정하고, [From](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/irotationeffect/from/)과 [To](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/irotationeffect/to/)는 시작점과 끝점을 지정합니다.

예제는 Spin 효과를 시작점으로 하고, 프리셋 작업을 하나의 회전 동작으로 교체하며, 해당 동작에 2초 지속 시간을 부여합니다. 90도 상대 각도는 도형의 시작 방향에서 1/4 회전을 의미하므로 별도의 시작 각도를 지정할 필요가 없습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx`에는 하나의 도형과 하나의 회전 동작이 포함됩니다. 아래 컬렉션, 타이밍 및 회전 편집 예제는 이 파일을 사용합니다.

### **크기 조정**

[X/Y 백분율]을 사용하여 [CreateScaleEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/)를 호출합니다. [From](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/iscaleeffect/from/)과 [To](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/iscaleeffect/to/)는 시작 및 종료 크기를 설명하고, [By](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/iscaleeffect/by/)는 상대 변화를 설명합니다. 여기서 100은 원래 크기를 의미합니다.

예제는 두 차원을 100%에서 125%로 2초 동안 확대합니다. 가로·세로 비율을 동일하게 유지하면 도형 비율이 보존되고, 비율이 다르면 한 차원이 더 늘어납니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **색상**

[CreateColorEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/)를 사용하여 채우기 색을 파랑에서 주황으로 변경합니다. [From](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/icoloreffect/from/)과 [To](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/icoloreffect/to/)는 색상이지만, [By](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/icoloreffect/by/)는 색상 오프셋입니다. [IBehavior.Properties](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehavior/properties/)는 애니메이션 대상 속성을 식별합니다.

도형의 솔리드 채우기 색상이 파랑으로 초기화되어 애니메이션 시작 색과 일치합니다. 채우기 색상 속성을 선택하면 어떤 부분을 변경할지 동작에 알려줍니다. 저장된 효과는 2초에 걸쳐 주황색으로 전환된다는 정보를 담고 있습니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **필터**

[CreateFilterEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/)를 사용하여 와이프를 선택합니다. [Type](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ifiltereffect/subtype/), [Reveal](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ifiltereffect/reveal/)은 필터 종류, 방향 및 도형을 드러낼지 숨길지를 지정합니다.

예제는 오른쪽 방향 서브타입을 사용하여 도형을 드러내는 2초 와이프를 구성합니다. 필터 설정은 효과 내부 동작에 속하므로 프리셋의 원래 작업을 제거한 뒤에 설정합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **속성**

[CreatePropertyEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/)를 사용하여 불투명도를 애니메이션합니다. [From](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ipropertyeffect/to/), [By](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ipropertyeffect/by/)는 문자열이며, [ValueType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ipropertyeffect/valuetype/) 및 [CalcMode](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ipropertyeffect/calcmode/)에 따라 해석됩니다. 세 값을 모두 무작위로 설정하기보다 끝점 또는 상대 오프셋을 선택하십시오.

여기서는 대상 속성이 불투명도이며, 문자열 “25%”에서 “100%”로 변화합니다. 선형 보간을 사용하면 값 사이가 점진적으로 변합니다. 다른 속성에 적용할 경우 해당 속성에 맞는 값 유형과 끝값을 선택해야 합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **설정**

[CreateSetEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorfactory/createseteffect/)를 사용하여 [To](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/iseteffect/to/) 로 가시성을 지정합니다. 설정 동작은 끝점 사이를 보간하지 않습니다.

예제는 가시성 속성을 선택하고 동작 실행 시 문자열 `visible`을 할당합니다. 최소 프레젠테이션에서 사각형은 이미 보이므로 이 할당만으로는 눈에 띄는 변화가 없을 수 있습니다. 그러나 다른 동작과 결합하면 도형이 언제 숨겨지거나 보이게 할지 제어하는 데 유용합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **명령**

[CreateCommandEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/)를 사용하고 [Type](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/icommandeffect/commandstring/), [ShapeTarget](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/icommandeffect/shapetarget/)을 설정합니다. 작업 디렉터리에 `sample.wav` 파일을 두고, [AddAudioFrameEmbedded](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addaudioframeembedded/)로 삽입한 뒤 재생 명령을 오디오 프레임에 연결합니다.

오디오 프레임은 효과와 명령 모두의 대상이 됩니다. 이렇게 하면 삽입된 녹음 파일을 재생하도록 요청이 연결됩니다. 명령 문자열만으로는 어떤 미디어 객체를 제어할지 알 수 없습니다. 이 효과는 슬라이드쇼 진행 중 클릭 시 시작하도록 설정됩니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

저장은 `command.pptx`에 명령을 저장하지만 녹음은 재생되지 않습니다. 재생하려면 명령과 미디어 대상을 지원하는 슬라이드쇼 플레이어가 필요합니다.

## **동작 컬렉션 관리**

[IBehaviorCollection](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorcollection/)는 [Add](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorcollection/remove/), [RemoveAt](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorcollection/removeat/)를 지원합니다. 이 예제는 `rotation.pptx`를 열어 크기 조정을 추가하고 회전 앞에 삽입한 뒤 회전을 제거합니다. 동일 객체를 제거하고 다시 삽입하면 복사본을 만들지 않고 저장된 위치만 바뀝니다.

편집 순서는 컬렉션을 회전‑크기에서 크기‑회전으로, 이어서 크기만 남도록 변경합니다. 인덱스는 현재 컬렉션을 기준으로 하므로 재정렬 후 회전의 새로운 인덱스를 사용합니다. 최종 열거를 통해 저장될 동작을 확인합니다.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

출력은 `ScaleEffect`이며, 크기 조정만 남습니다. 컬렉션 순서 자체가 동작을 순차적으로 실행하도록 예약하지는 않습니다. 모든 작업을 교체할 때만 컬렉션을 비우십시오.

## **동작 타이밍 구성**

[IBehavior.Timing](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehavior/timing/)은 [ITiming](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/)을 노출하며, 이는 [IEffect.Timing](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/timing/)과 독립적입니다. 효과 타이밍은 전체 효과의 스케줄을 잡고, 동작 타이밍은 그 안의 개별 작업을 제어합니다.

### **지속 시간·지연·반복·가속 설정**

`rotation.pptx`를 열고, 초 단위로 [Duration](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/duration/)과 [TriggerDelayTime](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/triggerdelaytime/)을 설정한 뒤 [RepeatCount](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/repeatcount/)를 구성합니다. [Accelerate](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/accelerate/)와 [Decelerate](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/decelerate/)는 지속 시간의 비율이며, 두 값의 합은 1 이하이어야 합니다.

입력 파일은 회전 예제에서 만든 파일이며, 첫 번째 동작이 회전임을 알고 있습니다. 이 예제는 해당 동작의 타이밍만 변경하고, 90도 각도는 그대로 유지합니다. 각도와 타이밍을 분리하면 애니메이션을 다시 만들 필요 없이 속도만 조정하기가 쉽습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

이 동작은 2초 지속, 0.5초 지연, 반복 횟수 3을 사용합니다. 전체 지속 시간의 앞 20%와 뒤 20%가 각각 가속 및 감속에 사용됩니다.

다른 반복 정책으로는 [RepeatDuration](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/repeatuntilendslide/), [RepeatUntilNextClick](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/repeatuntilnextclick/)이 있습니다. 모두를 켜는 대신 하나를 선택하십시오. [AutoReverse](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/itiming/autoreverse/)는 앞쪽 재생이 끝난 뒤 역방향으로 애니메이션을 재생합니다. 가속·감속은 연속적인 변화를 대상으로 하며, 이산적인 할당이나 명령에는 적용되지 않습니다.

## **움직임 경로 만들기**

[CreateMotionEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/)를 사용하여 움직임을 생성합니다. [From](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotioneffect/to/), [By](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotioneffect/by/)는 백분율 기반 좌표 또는 오프셋을 설명합니다. 편집 가능한 경로를 만들려면 [MotionPath](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/motionpath/)를 생성하고 이를 [IMotionEffect.Path](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotioneffect/path/)에 할당합니다. [IMotionPath](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotionpath/)는 경로 명령을 저장합니다.

[MotionCommandPathType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/motioncommandpathtype/)은 작업을 선택합니다:

| 명령 | 포인트 | 의미 |
| --- | --- | --- |
| MoveTo | One | 시작 위치를 설정합니다. |
| LineTo | One | 직선 구간을 따라 끝점까지 이동합니다. |
| CurveTo | Three | 두 개의 제어점과 끝점으로 정의된 삼차 곡선을 따릅니다. |
| CloseLoop | None | 시작 위치로 돌아갑니다. |
| End | None | 경로를 종료합니다. |

[MotionPathPointsType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/motionpathpointstype/)은 코너 포인트나 스무스 포인트와 같은 점 편집 특성을 설명합니다. 이는 명령 유형을 대체하지 않으며, 아래 곡선 예제에서는 곡선 포인트 유형을, 직선 구간에서는 코너 포인트 유형을 사용합니다.

경로 좌표는 슬라이드 크기에 정규화됩니다. X 변위 0.25는 슬라이드 너비의 1/4을 의미하며, 0.25 포인트가 아닙니다. Y는 아래쪽이 양수입니다. 절대 명령은 경로 좌표계에서 위치를 지정하고, 상대 명령은 현재 위치에서 오프셋을 지정합니다. 이는 [Origin](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotioneffect/origin/)과는 별개이며, [PathEditMode](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotioneffect/patheditmode/)는 도형 이동 시 경로가 어떻게 움직이는지를 제어합니다.

### **직선 경로 만들기**

시작점, 하나의 직선 구간, 종료 명령을 가진 움직임 동작을 생성합니다. [IMotionPath.Add](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotionpath/add/)는 명령 유형, 포인트 배열, 포인트 유형 및 상대 좌표 플래그를 받습니다.

시작 명령은 (0, 0)을 설정하고, 라인 명령은 (0.25, 0)으로 끝나 슬라이드 너비의 1/4을 수평 이동합니다. 종료 명령은 좌표가 없습니다. 경로를 할당한 뒤 움직임 동작을 효과에 추가하면 해당 경로가 사각형에 연결됩니다.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx`에는 세 개의 경로 명령을 가진 하나의 움직임 동작이 들어 있습니다. 아래 파일 편집 예제는 이 구조를 기준으로 합니다.

### **절대 좌표와 상대 좌표 비교**

다음 두 경로 객체는 동일한 경로를 나타냅니다. 절대 명령은 (0.3, 0.1)에서 끝나고, 상대 명령은 현재 위치 (0.2, 0)에 (0.1, 0.1)을 더해 끝점이 됩니다.

두 경로 모두 동일한 시작 위치에서 시작합니다. 상대 라인의 경우 현재 위치에 X·Y 오프셋을 더해 끝점을 구하고, 절대 라인의 경우 직접 끝점을 읽습니다. 좌표를 변환하지 않고 플래그만 바꾸면 다른 경로가 됩니다.

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

두 경로 중 하나를 움직임 동작에 할당하여 프레젠테이션에서 사용할 수 있습니다. 마지막 Boolean 인자는 해당 명령에 대해 상대 좌표를 사용할지를 선택합니다.

### **라인을 곡선으로 교체**

`motion.pptx`를 열고 라인 명령을 삼차 곡선으로 교체합니다. 먼저 두 개의 제어점을 제공하고 마지막에 끝점을 제공합니다.

시작 위치는 앞선 명령이 제공하며, 첫 두 포인트가 곡선을 형성하고 세 번째가 목적지입니다; 세 포인트가 연속된 목적지를 의미하지는 않습니다. 명령 유형, 포인트 편집 유형, 포인트 배열을 동시에 업데이트하면 새 기하학에 맞게 구간이 일관됩니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

`curve.pptx`의 경로는 여전히 세 개 명령을 가지며, 중간 명령이 곡선으로 정의됩니다.

## **저장된 경로 검사 및 편집**

각 [IMotionCmdPath](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotioncmdpath/)는 [Points](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotioncmdpath/pointstype/), [IsRelative](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotioncmdpath/isrelative/)을 노출합니다. 아래 예제는 `motion.pptx`의 알려진 세 명령 경로를 사용합니다. 임의 입력에 대해서는 효과를 찾아 인덱스로 편집하기 전에 명령 유형과 포인트 수를 확인하십시오.

### **명령 및 좌표 읽기**

경로를 변경 없이 읽습니다. 종료와 닫힘 명령은 포인트가 필요 없으므로 null 포인트 배열을 허용합니다.

출력은 각 명령과 상대 좌표 플래그를 짝지은 뒤 포인트를 나열합니다. 이렇게 하면 경로를 수정하기 전에 끝점과 오프셋을 구분할 수 있습니다. 곡선은 세 개 포인트를, 직선은 하나만 나열합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

목록에는 시작점, (0.25, 0)에서 끝나는 절대 라인, 그리고 종료 명령이 포함됩니다.

### **끝점 변경**

`motion.pptx`를 열고 라인의 포인트 배열을 교체하여 끝점을 이동합니다.

입력 파일에서 인덱스 0은 시작 명령, 인덱스 1은 라인입니다. 라인의 단일 포인트를 교체하면 명령 유형, 타이밍 또는 컬렉션 내 위치를 바꾸지 않고 목적지만 바뀝니다. 명령이 절대 좌표를 사용하므로 새 좌표는 위치를 지정합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

`motion-endpoint.pptx`의 라인은 (0.4, 0.1)에서 끝나며, 원본 파일은 변경되지 않습니다.

### **구간 교체**

[Insert](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotionpath/insert/)와 [RemoveAt](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/imotionpath/removeat/)를 사용해 `motion.pptx`의 라인을 교체합니다. 삽입 시 기존 라인은 인덱스 2로 이동합니다.

이는 기존 좌표를 편집하는 것이 아니라 명령 객체 자체를 교체하는 예시입니다. 삽입 후 컬렉션은 일시적으로 시작 명령, 새로운 라인, 기존 라인, 종료 명령 순으로 구성됩니다. 인덱스 2를 제거하면 기존 라인이 사라지고 새 경로가 남습니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

저장된 경로는 여전히 세 개 명령을 가지며, 새로운 라인은 (0.2, 0.1)에서 끝나고 종료 명령이 마지막에 위치합니다.

## **기존 동작 수정 및 검증**

동작의 인덱스를 모를 때는 유형으로 선택합니다. 이 예제는 `rotation.pptx`를 열어 [IRotationEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/irotationeffect/)를 찾고 각도를 변경한 뒤 다시 열어 저장된 값을 확인합니다.

유형 검사는 회전이 아닌 동작을 건너뛰게 합니다. 두 번째 로드에서는 파일을 별도의 프레젠테이션 객체에 읽어 들여 메모리에 남아 있는 값이 아니라 실제 저장된 데이터를 비교합니다. 이 예제는 알려진 효과가 기본 시퀀스의 첫 번째에 있다고 가정합니다; 유형으로 동작을 선택한다고 해서 임의 프레젠테이션에서 올바른 효과를 찾는 것은 아닙니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

출력은 `Rotation preserved: True`입니다. 다른 동작에도 동일한 유형 검사 패턴을 적용하십시오. 전체 보존 검사를 원한다면 대상 도형, 효과, 동작 유형 및 순서, 타이밍, 경로 명령을 모두 비교하고 부동소수점 값은 수치 허용 오차를 적용하십시오. 애니메이션 레이아웃을 알 수 없는 프레젠테이션의 경우 [Read Shape Animations](/slides/ko/net/shape-animation/#read-shape-animations)에서 메인 및 인터랙티브 시퀀스를 탐색하는 방법을 확인하십시오.

## **동작 순서·프리셋·재생**

[IBehaviorCollection](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehaviorcollection/)의 순서는 효과 작업의 저장 순서이며, 모두 자동으로 앞 동작이 끝날 때까지 기다리는 재생 목록이 아닙니다. 타이밍과 포함된 효과가 스케줄을 결정합니다. 동작은 겹칠 수 있으며, 동일 속성에 대한 작업은 [Additive](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehavior/additive/)와 [Accumulate](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ibehavior/accumulate/)를 통해 상호 작용할 수 있습니다. “이동 → 회전”과 같이 컬렉션 순서만으로 스케줄링하지 말고, [Shape Animation](/slides/ko/net/shape-animation/)에 설명된 대로 명시적 타이밍 또는 별도 효과를 사용하십시오.

효과의 [Type](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/type/)과 [Subtype](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/ieffect/subtype/)은 프리셋을 설명하지만 편집된 동작 트리 전체를 설명하지는 않습니다. 프리셋과 서브타입을 선택한 뒤에 동작을 사용자 정의하십시오; 프리셋을 변경하면 컬렉션이 재구성되어 사용자 정의 작업이 사라질 수 있습니다. 예를 들어, 맞춤 Spin 효과를 Fade 로 바꾸면 회전 동작이 설정·필터 동작으로 교체됩니다. 프리셋이나 서브타입을 바꾼 후 컬렉션을 다시 검사하십시오. 프리셋 동작을 비우면 프리셋이 필요로 하는 가시성·초기화 작업도 제거될 수 있습니다. 예제는 가시적인 도형을 사용하고 동작을 교체했으며, 모든 프리셋 구현을 재구성하지는 않았습니다.

## **포맷 호환성**

보존된 동작 트리가 모든 뷰어나 내보내기 렌더러에서 동일한 재생을 보장하지는 않습니다. 저장된 데이터와 렌더링 결과를 각각 확인하십시오.

| 포맷 또는 출력 | 확인 내용 |
| --- | --- |
| PPTX | 예제의 기본 포맷으로 사용합니다. 다시 열어 편집 가능한 동작 트리를 확인한 뒤, 대상 PowerPoint 버전에서 재생을 검증합니다. |
| PPT | 레거시 바이너리 형식은 PPTX와 다를 수 있습니다. 별도로 저장·재열 사이클과 재생을 테스트하며, PPTX 성공만으로 모든 사용자 정의 조합이 지원된다고 추정하지 마십시오. |
| PDF, PNG, JPEG 및 기타 정적 슬라이드 이미지 | 정적인 슬라이드 표현이며, 재생 가능한 동작 타임라인이나 최종 애니메이션 프레임을 보장하지 않습니다. |
| [HTML5](/slides/ko/net/export-to-html5/) | 도형 애니메이션이 내보내기 옵션에서 활성화된 경우 지원되는 애니메이션을 재생할 수 있습니다. 브라우저에서 사용자 정의 조합을 테스트하십시오. |
| [Animated GIF](/slides/ko/net/convert-powerpoint-to-animated-gif/) | 렌더링된 프레임을 저장하며, 편집 가능한 동작이나 클릭 트리거 인터랙션은 포함되지 않습니다. 실제 렌더링된 움직임을 확인하십시오. |
| [Video](/slides/ko/net/convert-powerpoint-to-video/) | 애니메이션 프레임을 렌더링하고 비디오로 인코딩합니다. 지원은 렌더러의 [supported animations and effects](/slides/ko/net/convert-powerpoint-to-video/#supported-animations-and-effects)에 한정되며, 명령 및 인터랙티브 이벤트는 편집 가능한 타임라인이 되지 않습니다. |

## **FAQ**

**왜 아무 동작도 추가하지 않았는데도 효과에 동작이 포함되어 있나요?**

미리 정의된 효과를 만들면 기본 작업이 자동으로 생성될 수 있습니다. 프리셋을 확장할지 교체할지 결정하기 전에 이 작업을 검사하십시오.

**동작을 처음으로 이동하면 먼저 재생되나요?**

반드시 그렇지는 않습니다. 컬렉션 순서는 타이밍을 대체하지 못합니다. 지연, 지속 시간 및 동일 속성에 대한 작업 간 상호 작용을 확인하십시오.

**끝 명령에 포인트가 없는 이유는?**

끝 명령은 경로의 종료를 표시하며 좌표가 필요 없습니다. 파일에서 경로를 읽을 때 null 포인트 배열을 확인하십시오.

**라운드 트립이 성공하면 재생이 보장되나요?**

아니요. 다시 열어 속성 보존을 확인하는 것만으로는 충분하지 않습니다. 슬라이드쇼 플레이어나 애니메이션 내보내기를 별도로 테스트하여 실제 시각적 동작을 확인하십시오.