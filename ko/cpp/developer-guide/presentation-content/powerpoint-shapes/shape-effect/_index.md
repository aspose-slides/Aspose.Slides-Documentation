---
title: C++를 사용하여 프레젠테이션에 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/cpp/shape-effect/
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 광채 효과
- 부드러운 가장자리 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환하고 몇 초 만에 눈에 띄고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/cpp/shape-formatting/#gradient-fill) 또는 테두리와는 다릅니다. PowerPoint 효과를 사용하면 도형에 설득력 있는 반사, 빛 번짐 등을 만들 수 있습니다.

![도형 효과](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 여섯 가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint에는 **Preset** 옵션이 있습니다. 프리셋 옵션은 보기 좋은 두 개 이상의 효과 조합을 미리 정의한 것입니다. 프리셋을 선택하면 다양한 효과를 시험하거나 조합하는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) 클래스 아래에 있는 속성과 메서드를 통해 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있도록 지원합니다.

## **그림자 효과 적용**

Aspose.Slides for C++은 도형에 외부 및 내부 그림자를 지원합니다. 색상, 방향, 거리 및 흐림 반경을 사용자 지정하여 프레젠테이션 디자인에 맞출 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드나 패널이 슬라이드 배경에 대비되어 돋보이게 할 수 있습니다. 그림자는 도형 가장자리 밖으로 확장되어 도형이 슬라이드 위에 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 흐림 반경을 조정하여 템플릿의 조명 및 스타일에 맞추세요.

다음 C++ 코드는 사각형에 [외부 그림자 효과](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/)를 적용하는 방법을 보여줍니다:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

presentation->Save(u"shadow_effect.pptx", SaveFormat::Pptx);
```

![그림자 효과](shadow_effect.png)

### **내부 그림자 적용**

템플릿의 시각적 스타일을 재현할 때, 내부 그림자를 사용하면 카드나 패널에 움푹 들어간 모습을 부여할 수 있습니다. 외부 그림자는 도형 외부에 그림자를 만들고 도형을 띄워 보이게 하는 반면, 내부 그림자는 가장자리 안쪽을 어둡게 합니다.

[EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/)을 호출한 뒤 [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/)를 구성합니다. 흐림 반경 값이 클수록 가장자리가 부드러워집니다.

다음 C++ 예제는 연한 파란색 카드를 만들고 어두운 회색 내부 그림자를 적용한 뒤 PPTX 파일로 저장합니다:

```cpp
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_LightBlue());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

shape->get_EffectFormat()->EnableInnerShadowEffect();
auto shadow = shape->get_EffectFormat()->get_InnerShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_DimGray());
shadow->set_Direction(225);
shadow->set_Distance(7);
shadow->set_BlurRadius(6);

presentation->Save(u"inner_shadow_effect.pptx", SaveFormat::Pptx);
```

![내부 그림자가 있는 연한 파란색 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 EffectFormat에서 [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/)를 호출하십시오.

## **반사 효과 적용**

Aspose.Slides for C++에서 반사 효과를 적용하려면 도형에 거울처럼 반사되는 효과를 추가하고 거리, 투명도, 크기와 같은 매개변수를 조정하면 됩니다. 이 효과는 도형에 보다 세련되고 정교한 외관을 부여하여 프레젠테이션의 미적 품질을 높입니다. 간단한 코드로 쉽게 구현할 수 있어 여러 요소에 일관된 디자인을 빠르게 적용할 수 있습니다.

다음 C++ 코드는 도형에 [반사 효과](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/)를 적용하는 방법을 보여줍니다:

```cpp
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(40);
reflectionEffect->set_BlurRadius(2);

presentation->Save(u"reflection_effect.pptx", SaveFormat::Pptx);
```

![반사 효과](reflection_effect.png)

## **광채 효과 적용**

Aspose.Slides for C++에서 도형에 광채 효과를 적용하려면 도형 주변에 부드러운 빛나는 오라를 추가하고 색상 및 크기와 같은 속성을 조정하면 됩니다. 이 효과는 도형을 돋보이게 하며 프레젠테이션에 매력적이고 눈길을 끄는 시각 요소를 추가합니다. 최소한의 코드로 쉽게 구현할 수 있어 슬라이드 전체의 외관을 향상시킵니다.

다음 C++ 코드는 도형에 [광채 효과](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/)를 적용하는 방법을 보여줍니다:

```cpp
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Magenta());
glowEffect->set_Radius(15);

presentation->Save(u"glow_effect.pptx", SaveFormat::Pptx);
```

![광채 효과](glow_effect.png)

## **부드러운 가장자리 효과 적용**

Aspose.Slides for C++에서 부드러운 가장자리 효과를 적용하려면 도형 가장자리 주변에 부드럽고 흐린 전환을 만들 수 있습니다. 이 효과는 섬세하고 정제된 모습을 제공하며, 부드러운 외관이 필요한 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션의 다양한 도형에 원하는 효과를 적용할 수 있습니다.

다음 C++ 코드는 도형에 [부드러운 가장자리](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/)를 적용하는 방법을 보여줍니다:

```cpp
#include <DOM/Effects/ISoftEdge.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(8);

presentation->Save(u"soft_edges_effect.pptx", SaveFormat::Pptx);
```

![부드러운 가장자리 효과](soft_edges_effect.png)

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 광채 등 다양한 효과를 하나의 도형에 결합하여 보다 역동적인 외관을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

예, 그룹화된 도형 전체에 효과가 적용됩니다.