---
title: C++에서 사용자 지정 애니메이션 동작 만들기 및 수정
linktitle: 사용자 지정 애니메이션
type: docs
weight: 151
url: /ko/cpp/custom-animation/
keywords:
- 사용자 지정 애니메이션
- 애니메이션 동작
- 모션 경로
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "PowerPoint 프레젠테이션에서 Aspose.Slides for C++를 사용하여 사용자 지정 애니메이션 동작 및 편집 가능한 모션 경로를 만들고, 검사하고, 수정합니다."
---
## **개요**

사용자 지정 애니메이션 동작을 통해 색상 변경, 도형 회전 또는 편집 가능한 모션 경로 따라 움직임 등 애니메이션 효과 내 개별 작업을 제어할 수 있습니다. 이 가이드에서는 동작을 만들고 결합하는 방법, 타이밍을 구성하는 방법, 기존 애니메이션을 검사·수정하는 방법, 그리고 속성이 프레젠테이션을 저장하고 다시 열 때 유지되는지 확인하는 방법을 보여줍니다.

미리 정의된 효과와 클릭 트리거에 대해서는 [도형 애니메이션](/slides/ko/cpp/shape-animation/)을 참고하십시오.

## **애니메이션 모델 이해하기**

애니메이션은 **타임라인 → 시퀀스 → 효과 → 동작** 구조로 구성됩니다:

- 슬라이드의 [get_Timeline](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslide/get_timeline/)에는 주요 시퀀스와 인터랙티브 시퀀스가 포함됩니다.
- [ISequence](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/)은 효과들을 포함하며, 대상 도형이 서로 다를 수 있습니다.
- [IEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/)은 대상 도형, 프리셋, 서브타입 및 효과 타이밍을 식별합니다.
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/get_behaviors/)에는 색상 변경, 이동, 회전, 속성 설정 등 효과를 구현하는 작업이 들어 있습니다.

## **개별 동작 만들기**

[ISequence::AddEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/addeffect/)를 호출하여 효과를 만들고 해당 효과의 [get_Behaviors](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/get_behaviors/) 컬렉션에 접근합니다. 프리셋을 사용하면 이 컬렉션이 자동으로 채워집니다. 프리셋을 확장할 때는 기존 작업을 유지하고, 의도적으로 교체할 경우에는 [Clear](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorcollection/clear/)을 사용하십시오.

[IBehaviorFactory](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorfactory/)는 아래에 설명된 8가지 동작 유형을 생성합니다. 모션에 대해서는 [모션 경로 만들기](#build-a-motion-path)를 참고하세요. 각 생성 예제는 함수 내부에서 실행 가능한 독립된 코드이며, 이후 편집 예제는 사용되는 출력 파일을 명시합니다.

### **회전**

[CreateRotationEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/)를 사용하여 회전을 생성합니다. [get_By](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/irotationeffect/get_by/)는 상대 각도(도)를 지정하고, [get_From](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/irotationeffect/get_from/)과 [get_To](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/irotationeffect/get_to/)는 시작·종료 지점을 지정합니다.

예제는 Spin 효과를 시작점으로 하여 프리셋 작업을 하나의 회전 동작으로 교체하고, 해당 동작에 2초 지속 시간을 부여합니다. 90도라는 상대 각도는 도형의 초기 방향에서 ¼ 회전을 의미하므로 명시적 시작 각도가 필요하지 않습니다.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto rotation = factory->CreateRotationEffect();
rotation->set_By(90.0f);
rotation->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(rotation);

presentation->Save(u"rotation.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`rotation.pptx`에는 하나의 도형과 하나의 회전 동작이 포함됩니다. 아래의 컬렉션, 타이밍 및 회전 편집 예제는 이 파일을 사용합니다.

### **크기 조정**

[X/Y 비율]을 사용하여 [CreateScaleEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/)를 호출합니다. [get_From](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/iscaleeffect/get_from/)과 [get_To](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/iscaleeffect/get_to/)는 시작·종료 크기를 설명하고, [get_By](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/iscaleeffect/get_by/)는 상대 변화를 설명합니다. 여기서 100은 원래 크기를 의미합니다.

예제는 두 차원을 100%에서 125%로 2초에 걸쳐 확대합니다. 가로·세로 비율을 동일하게 유지하면 도형 비율이 유지되며, 비율이 다르면 한 차원이 더 늘어납니다.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_From(PointF(100, 100));
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(scale);

presentation->Save(u"scale.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **색상**

[CreateColorEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/)를 사용해 채우기 색을 파란색에서 주황색으로 변경합니다. [get_From](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/icoloreffect/get_from/)과 [get_To](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/icoloreffect/get_to/)는 색상이고, [get_By](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/icoloreffect/get_by/)는 색상 오프셋입니다. [IBehavior::get_Properties](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehavior/get_properties/)는 애니메이션 대상 속성을 식별합니다.

도형의 고정 채우기 색은 파란색으로 초기화되며, 이는 애니메이션 시작 색과 일치합니다. 채우기 색 속성을 선택하면 동작이 어떤 부분을 변경할지 알 수 있습니다. 저장된 효과는 2초간 주황색으로 전환되는 것을 설명합니다.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IColorEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/FillType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto color = factory->CreateColorEffect();
color->get_Properties()->Add(BehaviorProperty::get_FillColor()->get_Value());
color->get_From()->set_Color(Color::get_Blue());
color->get_To()->set_Color(Color::get_Orange());
color->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(color);

presentation->Save(u"color.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **필터**

[CreateFilterEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/)를 사용해 와이프 효과를 선택합니다. [get_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ifiltereffect/get_subtype/), [get_Reveal](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ifiltereffect/get_reveal/)는 필터 종류, 방향, 표시·숨김 여부를 지정합니다.

예제는 오른쪽 방향 서브타입을 사용해 도형을 표시하는 2초 와이프를 구성합니다. 필터 설정은 효과 내부 동작에 속하므로 프리셋의 원래 작업을 제거한 뒤 구성합니다.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/FilterEffectRevealType.h>
#include <DOM/Animation/FilterEffectSubtype.h>
#include <DOM/Animation/FilterEffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IFilterEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto filter = factory->CreateFilterEffect();
filter->set_Type(FilterEffectType::Wipe);
filter->set_Subtype(FilterEffectSubtype::Right);
filter->set_Reveal(FilterEffectRevealType::In);
filter->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(filter);

presentation->Save(u"filter.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **속성**

[CreatePropertyEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/)를 사용해 불투명도를 애니메이션합니다. [get_From](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ipropertyeffect/get_to/), [get_By](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ipropertyeffect/get_by/)는 문자열이며, [get_ValueType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/)와 [get_CalcMode](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/)에 따라 해석됩니다. 세 값을 모두 무작위로 지정하기보다 끝점 또는 상대 오프셋을 선택하십시오.

여기서는 대상 속성을 불투명도로 선택하고, 문자열 “25%”에서 “100%”로 변화한다는 의미입니다. 선형 보간을 사용해 점진적인 변화를 구현합니다. 다른 속성에 적용할 경우 해당 속성에 맞는 값 유형과 끝점 값을 선택하면 됩니다.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IPropertyEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/PropertyCalcModeType.h>
#include <DOM/Animation/PropertyValueType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto property = factory->CreatePropertyEffect();
property->get_Properties()->Add(BehaviorProperty::get_StyleOpacity()->get_Value());
property->set_ValueType(PropertyValueType::Number);
property->set_CalcMode(PropertyCalcModeType::Linear);
property->set_From(u"0.25");
property->set_To(u"1");
property->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(property);

presentation->Save(u"property.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **설정**

[CreateSetEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/)를 사용해 [get_To](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/iseteffect/get_to/)로 가시성을 지정합니다. Set 동작은 끝점 사이를 보간하지 않습니다.

예제는 가시성 속성을 선택하고, 동작 실행 시 문자열 `visible`을 할당합니다. C++에서는 문자열을 객체로 감싸서 Set 동작에 전달합니다. 최소 프레젠테이션에서는 사각형이 이미 보이므로 눈에 띄는 변화가 없을 수 있습니다. 이 동작은 다른 효과와 결합해 도형이 숨겨지거나 표시되는 시점을 제어할 때 유용합니다.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISetEffect.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto set = factory->CreateSetEffect();
set->get_Properties()->Add(BehaviorProperty::get_StyleVisibility()->get_Value());
auto visibility = ObjectExt::Box<String>(u"visible");
set->set_To(visibility);

effect->get_Behaviors()->Add(set);

presentation->Save(u"set.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **명령**

[CreateCommandEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/)를 사용하고, [get_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/icommandeffect/get_commandstring/), [get_ShapeTarget](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/)을 설정합니다. 작업 디렉터리에 `sample.wav` 파일을 두고, 예제에서는 이를 [AddAudioFrameEmbedded](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addaudioframeembedded/)으로 삽입한 뒤 재생 명령을 오디오 프레임에 연결합니다.

오디오 프레임은 효과와 명령 모두의 대상이 됩니다. 이렇게 하면 재생 요청이 삽입된 녹음 파일에 연결되며, 명령 문자열만으로는 제어할 미디어 개체를 알 수 없습니다. 이 효과는 슬라이드 쇼 재생 중 클릭 시 시작하도록 구성됩니다.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/CommandEffectType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/ICommandEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = IO::File::OpenRead(u"sample.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto command = factory->CreateCommandEffect();
command->set_Type(CommandEffectType::Call);
command->set_CommandString(u"play");
command->set_ShapeTarget(audioFrame);

effect->get_Behaviors()->Add(command);

presentation->Save(u"command.pptx", SaveFormat::Pptx);

audioStream->Close();

presentation->Dispose();
```

저장하면 `command.pptx`에 명령이 저장되지만 녹음은 재생되지 않습니다. 재생하려면 해당 명령과 미디어 대상을 지원하는 슬라이드 쇼 플레이어가 필요합니다.

## **동작 컬렉션 관리하기**

[IBehaviorCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorcollection/)은 [Add](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorcollection/remove/), [RemoveAt](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorcollection/removeat/)을 지원합니다. 이 예제는 `rotation.pptx`를 열어 스케일링을 추가하고, 회전 앞에 삽입한 뒤 회전을 제거합니다. 같은 객체를 제거하고 다시 삽입하면 복사본을 만들지 않고 저장된 위치만 변경됩니다.

편집 흐름은 컬렉션을 회전‑스케일에서 스케일‑회전, 그리고 결국 스케일만 남도록 바꿉니다. 인덱스는 현재 컬렉션을 기준으로 하므로 재정렬 후 회전의 새로운 인덱스를 사용해 제거합니다. 최종 열거 결과 저장될 동작을 확인합니다.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto behaviors = effect->get_Behaviors();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

behaviors->Add(scale);

behaviors->Remove(scale);
behaviors->Insert(0, scale);
behaviors->RemoveAt(1);

for (auto behavior : behaviors)
    Console::WriteLine(behavior->GetType().get_Name());

presentation->Save(u"collection-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

출력은 `ScaleEffect`만 남습니다. 컬렉션 순서는 자체적으로 동작을 연속 재생하도록 예약하지 않습니다. 전체 동작을 교체할 때만 Clear를 사용하십시오.

## **동작 타이밍 구성하기**

[IBehavior::get_Timing](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehavior/get_timing/)은 [ITiming](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/)을 노출하며, 이는 [IEffect::get_Timing](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/get_timing/)와 독립적입니다. 효과 타이밍은 전체 효과를 예약하고, 동작 타이밍은 그 안의 개별 작업을 설명합니다.

### **지속 시간·지연·반복·가속 설정**

`rotation.pptx`를 열고, 초 단위로 [get_Duration](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/get_duration/)과 [get_TriggerDelayTime](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/)을 설정한 뒤, [get_RepeatCount](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/get_repeatcount/)를 구성합니다. [get_Accelerate](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/get_accelerate/)와 [get_Decelerate](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/get_decelerate/)는 지속 시간의 비율이며, 합계는 1 이하로 유지합니다.

입력 파일은 회전 예제에서 만든 파일이며, 첫 번째 동작이 회전임이 알려져 있습니다. 이 예제는 해당 동작의 타이밍만 변경하고, 90도 회전 각도는 그대로 유지합니다. 각도와 타이밍을 별도로 관리하면 애니메이션을 다시 빌드하지 않고도 속도를 조정하기 쉽습니다.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto rotation = ExplicitCast<IRotationEffect>(effect->get_Behaviors()->idx_get(0));
rotation->get_Timing()->set_Duration(2.0f);
rotation->get_Timing()->set_TriggerDelayTime(0.5f);
rotation->get_Timing()->set_RepeatCount(3.0f);
rotation->get_Timing()->set_Accelerate(0.2f);
rotation->get_Timing()->set_Decelerate(0.2f);

presentation->Save(u"timing.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

동작은 2초 지속, 0.5초 지연, 반복 횟수 3을 사용합니다. 지속 시간의 앞·뒤 20%는 가속·감속에 사용됩니다.

다른 반복 정책으로는 [get_RepeatDuration](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), [get_RepeatUntilNextClick](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/)이 있으며, 모두를 동시에 활성화하지 말고 하나를 선택하십시오. [get_AutoReverse](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/itiming/get_autoreverse/)는 전방 재생 후 역방향 재생을 수행합니다. 가속·감속은 연속적인 변화에만 적용되며, 이산 할당이나 명령에는 적용되지 않습니다.

## **모션 경로 만들기**

[CreateMotionEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/)를 사용해 모션을 생성합니다. [get_From](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotioneffect/get_to/), [get_By](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotioneffect/get_by/)는 백분율 기반 좌표 또는 오프셋을 설명합니다. 편집 가능한 경로를 만들려면 [MotionPath](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/motionpath/)를 생성하고 이를 [IMotionEffect::get_Path](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotioneffect/get_path/)에 할당합니다. [IMotionPath](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotionpath/)는 경로 명령을 저장합니다.

[MotionCommandPathType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/motioncommandpathtype/)은 동작을 선택합니다:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | 시작 위치 설정 |
| LineTo | One | 직선 구간을 따라 끝점까지 이동 |
| CurveTo | Three | 두 개의 제어점과 끝점으로 정의된 3차 곡선 따라 이동 |
| CloseLoop | None | 시작 위치로 돌아감 |
| End | None | 경로 종료 |

[MotionPathPointsType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/motionpathpointstype/)은 코너 포인트·스무스 포인트 등 점 편집 특성을 나타내며, 명령 유형을 대체하지는 않습니다. 아래 곡선 예제에서는 곡선 포인트 유형을, 직선 구간에서는 코너 포인트 유형을 사용하십시오.

경로 좌표는 슬라이드 크기에 정규화됩니다. X 변위 0.25는 슬라이드 너비의 ¼을 의미하며, 0.25 포인트가 아닙니다. Y는 아래쪽이 양수입니다. 절대 명령은 경로 좌표계에서 위치를 지정하고, 상대 명령은 현재 위치에서 오프셋을 지정합니다. 이는 [get_Origin](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotioneffect/get_origin/)이 선택하는 경로 기준 프레임 및 [get_PathEditMode](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/)과는 별개이며, 도형 이동 시 경로가 어떻게 움직이는지를 제어합니다.

### **직선 경로 만들기**

시작점, 하나의 직선 구간, 그리고 종료 명령을 포함하는 모션 동작을 만듭니다. [IMotionPath::Add](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotionpath/add/)는 명령 유형, 해당 점들, 점 유형, 그리고 상대 좌표 플래그를 받습니다.

시작 명령은 (0, 0)을 설정하고, 직선은 (0.25, 0)으로 끝나면서 슬라이드 폭의 ¼에 해당하는 수평 변위를 만듭니다. 종료 명령은 좌표가 없습니다. 경로를 할당하고 모션 동작을 효과에 추가하면 해당 경로가 사각형에 연결됩니다.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionOriginType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto motion = factory->CreateMotionEffect();
motion->set_Origin(MotionOriginType::Layout);
motion->get_Timing()->set_Duration(2.0f);

auto path = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0, 0) });
path->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto linePoints = MakeArray<PointF>({ PointF(0.25f, 0) });
path->Add(MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
auto endPoints = MakeArray<PointF>(0);
path->Add(MotionCommandPathType::End, endPoints, MotionPathPointsType::None, false);

motion->set_Path(path);
effect->get_Behaviors()->Add(motion);

presentation->Save(u"motion.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion.pptx`에는 세 개의 경로 명령을 가진 하나의 모션 동작이 포함됩니다. 아래 파일 편집 예제는 이 구조를 전제로 합니다.

### **절대 좌표와 상대 좌표 비교**

다음 두 경로 객체는 동일한 경로를 설명합니다. 절대 명령은 (0.3, 0.1)에서 끝나고, 상대 명령은 현재 위치 (0.2, 0)에 (0.1, 0.1)을 더합니다.

두 경로 모두 동일한 시작 위치에서 시작합니다. 상대 직선의 경우 현재 위치에 X·Y 오프셋을 더해 끝점을 구하고, 절대 직선은 끝점을 직접 읽습니다. 좌표를 변환하지 않고 플래그만 전환하면 다른 경로가 됩니다.

```cpp
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::Drawing;

auto absolutePath = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
absolutePath->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto absoluteEndPoints = MakeArray<PointF>({ PointF(0.3f, 0.1f) });
absolutePath->Add(MotionCommandPathType::LineTo, absoluteEndPoints, MotionPathPointsType::Corner, false);

auto relativePath = MakeObject<MotionPath>();
auto relativeStartPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
relativePath->Add(MotionCommandPathType::MoveTo, relativeStartPoints, MotionPathPointsType::Auto, false);
auto relativeOffsets = MakeArray<PointF>({ PointF(0.1f, 0.1f) });
relativePath->Add(MotionCommandPathType::LineTo, relativeOffsets, MotionPathPointsType::Corner, true);
```

경로 중 하나를 모션 동작에 할당하면 프레젠테이션에서 사용할 수 있습니다. 마지막 Boolean 인자는 해당 명령에 대해 상대 좌표를 사용할지 선택합니다.

### **직선을 곡선으로 교체**

`motion.pptx`를 열고 직선 명령을 3차 곡선으로 교체합니다. 먼저 두 개의 제어점을 제공하고, 그 다음에 끝점을 제공합니다.

시작 위치는 앞선 명령에 의해 제공됩니다. 처음 두 점은 곡선을 형성하고, 세 번째는 목적지이며, 연속적인 목적지가 아니라는 점에 유의하십시오. 명령 유형, 점 편집 유형, 점 배열을 동시에 업데이트하면 새로운 기하학에 맞게 구간이 일관됩니다.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
path->idx_get(1)->set_CommandType(MotionCommandPathType::CurveTo);
path->idx_get(1)->set_PointsType(MotionPathPointsType::CurveSmooth);
auto curvePoints = MakeArray<PointF>({ PointF(0.1f, 0), PointF(0.2f, 0.1f), PointF(0.3f, 0.1f) });
path->idx_get(1)->set_Points(curvePoints);

presentation->Save(u"curve.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`curve.pptx`의 경로는 여전히 세 개의 명령을 가지고 있지만, 중간 명령이 이제 곡선을 정의합니다.

## **저장된 경로 검사 및 편집**

각 [IMotionCmdPath](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotioncmdpath/)는 [get_Points](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), [get_IsRelative](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/)를 노출합니다. 아래 예제는 `motion.pptx`에 알려진 세 명령 경로를 사용합니다. 임의 입력의 경우, 편집 전 인덱스로 접근하기 전에 목표 효과를 찾고 명령 유형·점 개수를 확인하십시오.

### **명령 및 좌표 읽기**

경로를 변경 없이 읽습니다. 종료·닫기 명령은 점이 필요 없으므로 null 점 배열을 허용합니다.

출력은 각 명령과 상대 좌표 플래그를 짝지은 뒤 점을 나열합니다. 이를 통해 경로를 수정하기 전에 끝점과 오프셋을 구분할 수 있습니다. 곡선은 세 점을, 이 파일의 직선은 하나의 점만 나열합니다.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
for (auto segment : path)
{
    Console::WriteLine(u"{0}, relative: {1}", segment->get_CommandType(), segment->get_IsRelative());
    if (segment->get_Points() != nullptr)
        for (auto point : segment->get_Points())
            Console::WriteLine(u"X={0}, Y={1}", point.get_X(), point.get_Y());
}

presentation->Dispose();
```

목록에는 시작점, (0.25, 0)에서 끝나는 절대 직선, 그리고 종료 명령이 포함됩니다.

### **끝점 변경**

`motion.pptx`를 열고 직선의 점 배열을 교체해 끝점을 이동합니다.

입력 파일에서 인덱스 0은 시작 명령, 인덱스 1은 직선입니다. 직선의 단일 점을 교체하면 명령 유형·타이밍·컬렉션 내 위치는 그대로 두고 목적지만 바뀝니다. 명령이 절대 좌표를 사용하므로 새로운 쌍은 오프셋이 아니라 위치를 지정합니다.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));
auto endpointPoints = MakeArray<PointF>({ PointF(0.4f, 0.1f) });
motion->get_Path()->idx_get(1)->set_Points(endpointPoints);

presentation->Save(u"motion-endpoint.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion-endpoint.pptx`의 직선은 (0.4, 0.1)에서 끝나며, 원본 파일은 변경되지 않습니다.

### **구간 교체**

[Insert](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotionpath/insert/)와 [RemoveAt](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/imotionpath/removeat/)를 사용해 `motion.pptx`의 직선을 교체합니다. 삽입 시 기존 직선은 인덱스 2로 이동합니다.

이 방법은 기존 좌표를 편집하는 대신 명령 객체 자체를 교체함을 보여줍니다. 삽입 후 컬렉션은 일시적으로 시작 명령, 새로운 직선, 기존 직선, 종료 명령 순서로 구성됩니다. 인덱스 2를 제거하면 기존 직선이 사라지고 새로운 경로가 남습니다.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
auto linePoints = MakeArray<PointF>({ PointF(0.2f, 0.1f) });
path->Insert(1, MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
path->RemoveAt(2);

presentation->Save(u"motion-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

저장된 경로는 여전히 세 개의 명령을 가지고 있으며, 새로운 직선은 (0.2, 0.1)에서 끝나고 종료 명령이 마지막에 위치합니다.

## **기존 동작 수정 및 검증**

동작 인덱스를 모를 경우 유형으로 선택합니다. 이 예제는 `rotation.pptx`를 열어 [IRotationEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/irotationeffect/)를 찾고 각도를 변경한 뒤, 다시 열어 저장된 값을 확인합니다.

형식 검사는 루프가 회전이 아닌 동작을 건너뛰게 합니다. 두 번째 로드는 저장된 파일을 별도의 프레젠테이션 객체에 읽어 들여, 메모리에 남아 있는 값이 아니라 영구 저장된 데이터를 비교합니다. 이 예제는 기본 시퀀스의 첫 번째 효과가 회전임을 전제로 하며, 유형으로 동작을 선택한다고 해서 임의 프레젠테이션에서 올바른 효과를 찾는 것은 아닙니다.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <cmath>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : effect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        rotation->set_By(180.0f);
}

presentation->Save(u"rotation-edited.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"rotation-edited.pptx");
auto savedEffect = reopened->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : savedEffect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        Console::WriteLine(u"Rotation preserved: {0}", std::abs(rotation->get_By() - 180.0f) < 0.001f);
}

presentation->Dispose();
reopened->Dispose();
```

출력은 `Rotation preserved: True`입니다. 다른 동작에도 동일한 유형 검사 패턴을 적용하십시오. 전체 보존 검사를 위해서는 대상 도형, 효과, 동작 유형·순서, 타이밍, 경로 명령을 모두 비교하고, 부동소수점 값은 수치 허용오차를 사용하십시오. 애니메이션 레이아웃이 알려지지 않은 프레젠테이션에 대해서는 [도형 애니메이션 읽기](/slides/ko/cpp/shape-animation/#read-shape-animations)를 참조해 기본·인터랙티브 시퀀스를 탐색하십시오.

## **동작 순서, 프리셋 및 재생**

[IBehaviorCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehaviorcollection/)의 순서는 효과 작업이 저장되는 순서이며, 앞선 동작이 자동으로 기다리는 재생 목록이 아닙니다. 타이밍과 포함 효과가 예약을 결정합니다. 동작은 겹칠 수 있고, 동일 속성에 대한 작업은 [get_Additive](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehavior/get_additive/)와 [get_Accumulate](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ibehavior/get_accumulate/)를 통해 상호 작용할 수 있습니다. 컬렉션 순서만으로 “이동 후 회전”을 예약하지 말고, 명시적인 타이밍이나 별도 효과를 사용하십시오. 자세한 내용은 [도형 애니메이션](/slides/ko/cpp/shape-animation/)을 참고하십시오.

효과의 [get_Type](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/get_type/)과 [get_Subtype](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/ieffect/get_subtype/)은 프리셋을 설명하지만, 편집된 동작 트리 전체를 설명하지는 못합니다. 프리셋·서브타입을 선택한 뒤 동작을 맞춤 설정하십시오. 프리셋을 변경하면 컬렉션이 재구성되어 사용자 정의 작업이 사라질 수 있습니다. 예를 들어, 사용자 정의 Spin 효과를 Fade로 바꾸면 회전 동작이 set·filter 동작으로 교체됩니다. 프리셋이나 서브타입을 바꾼 후 컬렉션을 다시 검사하고, 프리셋 동작을 제거하면 프리셋에 필요한 초기화·가시성 작업이 사라질 수 있습니다. 예제에서는 가시적인 도형을 사용하고 동작을 교체했으며, 모든 프리셋 구현을 재구성하지는 않았습니다.

## **포맷 호환성**

보존된 동작 트리가 모든 뷰어·내보내기 렌더러에서 동일한 재생을 보장하지는 않습니다. 저장된 데이터와 렌더링 결과를 각각 확인하십시오.

| 포맷 또는 출력 | 확인 내용 |
| --- | --- |
| PPTX | 예제의 기본 포맷입니다. 파일을 다시 열어 편집 가능한 동작 트리를 검증하고, 의도한 PowerPoint 버전에서 재생을 확인하십시오. |
| PPT | 레거시 바이너리 형식은 PPTX와 다를 수 있습니다. 별도의 저장‑재로드·재생 사이클을 테스트하고, PPTX 출력만으로 모든 사용자 정의 조합을 지원한다고 추정하지 마십시오. |
| PDF, PNG, JPEG 등 정적 슬라이드 이미지 | 정적인 슬라이드 표현이며, 재생 가능한 동작 타임라인이나 최종 애니메이션 프레임을 보장하지 않습니다. |
| [HTML5](/slides/ko/cpp/export-to-html5/) | 내보내기 옵션에서 도형 애니메이션을 활성화하면 지원되는 애니메이션을 재생할 수 있습니다. 브라우저에서 사용자 정의 조합을 테스트하십시오. |
| [Animated GIF](/slides/ko/cpp/convert-powerpoint-to-animated-gif/) | 렌더링된 프레임을 저장하며, 편집 가능한 동작이나 클릭 트리거 인터랙션은 포함되지 않습니다. 실제 렌더링된 움직임을 확인하십시오. |
| [Video](/slides/ko/cpp/convert-powerpoint-to-video/) | 애니메이션 프레임을 렌더링해 비디오로 인코딩합니다. 지원 범위는 렌더러의 [지원되는 애니메이션 및 효과](/slides/ko/cpp/convert-powerpoint-to-video/#supported-animations-and-effects)로 제한되며, 명령·인터랙티브 이벤트는 편집 가능한 타임라인이 되지 않습니다. |

## **FAQ**

**내 효과에 동작이 아무 것도 추가하지 않았는데도 이미 포함되어 있는 이유는?**

프리셋 효과를 만들면 기본 작업이 자동으로 생성될 수 있습니다. 프리셋을 확장하거나 교체하기 전에 이를 확인하십시오.

**동작을 처음 위치로 옮기면 먼저 재생되나요?**

반드시 그렇지는 않습니다. 컬렉션 순서는 타이밍을 대체하지 못합니다. 지연·지속 시간 및 동일 속성에 대한 작업 간 상호 작용을 확인하십시오.

**종료 명령에 점이 없는 이유는?**

종료 명령은 경로의 끝을 표시하며 좌표가 필요하지 않습니다. 파일에서 경로를 읽을 때 null 점 배열을 확인하십시오.

**라운드 트립이 성공했다고 해서 재생이 보장되나요?**

아니요. 재열기는 속성 보존을 확인하지만, 슬라이드 쇼 플레이어나 애니메이션 내보내기를 별도로 테스트해 시각적 동작을 확인해야 합니다.