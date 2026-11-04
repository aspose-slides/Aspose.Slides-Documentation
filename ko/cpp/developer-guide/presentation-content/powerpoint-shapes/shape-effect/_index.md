---
title: C++를 사용한 프레젠테이션에서 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/cpp/shape-effect/
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 글로우 효과
- 소프트 에지 효과
- 효과 형식
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환하세요 — 몇 초 만에 눈에 띄고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/cpp/shape-formatting/#gradient-fill) 또는 윤곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 설득력 있는 반사를 만들거나, 도형의 글로우를 퍼뜨리는 등 다양한 효과를 적용할 수 있습니다.

![도형 효과](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 6가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint는 **프리셋** 옵션을 제공합니다. 프리셋 옵션은 함께 사용하면 좋은 두 개 이상의 효과를 조합한 것입니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 조합하는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있도록 [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) 클래스에 속성 및 메서드를 제공합니다.

## **그림자 효과 적용**

Aspose.Slides for C++는 도형에 대한 외부 및 내부 그림자를 지원합니다. 색상, 방향, 거리 및 블러 반경을 사용자 프레젠테이션 디자인에 맞게 사용자 지정할 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드나 패널을 슬라이드 배경에 대비해 돋보이게 할 수 있습니다. 그림자는 도형 가장자리를 넘어 확장되어 도형이 슬라이드 위로 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 블러 반경을 템플릿의 조명 및 스타일에 맞게 조정하십시오.

다음 C++ 코드는 [외부 그림자 효과](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/)를 사각형에 적용하는 방법을 보여줍니다:

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

템플릿의 시각적 스타일을 재현할 때, 내부 그림자를 사용하면 카드나 패널에 움푹 들어간 모습을 부여할 수 있습니다. 외부 그림자는 도형 외부로 확장되어 도형이 떠 보이게 하며, 내부 그림자는 가장자리 내부를 음영 처리합니다.

먼저 [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/)를 호출한 다음 [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/)를 구성합니다. 블러 반경 값이 클수록 가장자리가 부드러워집니다.

다음 C++ 예제는 연한 파란색 카드에 진한 회색 내부 그림자를 적용하고 PPTX 파일로 저장합니다:

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

![내부 그림자가 적용된 연한 파란색 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 효과 형식에서 [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/)를 호출합니다.

## **반사 효과 적용**

Aspose.Slides for C++에서 반사 효과를 적용하려면 도형에 거울과 같은 반사를 추가하고 거리, 투명도 및 크기와 같은 매개변수를 조정하면 됩니다. 이 효과는 도형에 더욱 세련되고 정교한 모습을 부여하여 프레젠테이션의 미적 감각을 향상시킵니다. 간단한 코드로 쉽게 구현할 수 있어 여러 요소에 빠르게 적용하여 일관된 디자인을 만들 수 있습니다.

다음 C++ 코드는 [반사 효과](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/)를 도형에 적용하는 방법을 보여줍니다:

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

## **글로우 효과 적용**

Aspose.Slides for C++에서 도형에 글로우 효과를 적용하려면 색상 및 크기와 같은 속성을 조정하여 도형 주변에 부드럽고 빛나는 오라를 추가할 수 있습니다. 이 효과는 도형을 돋보이게 하고 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 추가합니다. 최소한의 코드로 쉽게 구현할 수 있어 슬라이드 전체의 외관을 향상시킵니다.

다음 C++ 코드는 [글로우 효과](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/)를 도형에 적용하는 방법을 보여줍니다:

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

![글로우 효과](glow_effect.png)

## **소프트 에지 효과 적용**

Aspose.Slides for C++에서 소프트 에지 효과를 적용하려면 도형 가장자리에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 섬세하고 정교한 외관을 제공하여 부드러운 모양이 필요한 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션의 다양한 도형에 원하는 효과를 적용할 수 있습니다.

다음 C++ 코드는 [소프트 에지](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/)를 도형에 적용하는 방법을 보여줍니다:

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

![소프트 에지 효과](soft_edges_effect.png)

## **블러 효과 적용**

도형 블러를 사용하면 도형을 편집 가능한 상태로 유지하면서 채우기와 윤곽선을 부드럽게 만들 수 있습니다. 도형의 효과 형식에서 [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/)를 호출하십시오. 반경은 포인트(1/72인치) 단위이며, 음수가 아닌 값을 사용하고 값이 클수록 블러가 강해집니다. 반경이 0이면 외관이 변하지 않습니다.

[Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) 설정은 효과의 표시 경계를 제어합니다. `false`인 경우 블러가 윤곽선을 포함한 원래 그려진 경계에 잘라집니다. `true`인 경우 블러가 해당 경계를 넘어 확장될 수 있습니다. 이 설정은 도형의 위치나 크기를 변경하지 않습니다.

아래 비교는 전체에 동일한 채우기, 윤곽선 및 도형 크기를 사용합니다. 상단 행은 `grow = false`를, 하단 행은 `grow = true`를 사용합니다.

![블러 반경 5와 15 포인트, grow 비활성/활성 상태의 원래 사각형 비교](shape_blur_comparison.png)

다음 C++ 예제는 주황색 사각형에 진한 파란색 윤곽선을 적용하고 5포인트 블러를 적용한 뒤, 다시 [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/)를 호출하여 15포인트 블러로 업데이트합니다. 두 블러 상태를 저장한 다음 [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/)를 호출하고 블러가 없는 도형을 저장합니다.

```cpp
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 80.0f, 160.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
shape->get_LineFormat()->set_Width(8);

shape->get_EffectFormat()->SetBlurEffect(5, false);
presentation->Save(u"shape_blur_5.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->SetBlurEffect(15, true);
presentation->Save(u"shape_blur_15.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->DisableBlurEffect();
presentation->Save(u"shape_blur_removed.pptx", SaveFormat::Pptx);
```

도형 블러는 채우기와 윤곽선을 동시에 영향을 줍니다. 소프트 에지 효과는 도형 가장자리를 흐리게 하는 반면, 그림자 블러는 그림자만 부드럽게 합니다. 이미지 변환 효과는 이미지 콘텐츠에 적용되며, 이 예제는 도형을 이미지로 변환하지 않고 도형의 효과 형식에 직접 블러를 적용합니다.

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 글로우와 같은 다양한 효과를 하나의 도형에 결합하여 보다 역동적인 외관을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 이미지, SmartArt 객체, OLE 객체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

예, 그룹화된 도형에도 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.