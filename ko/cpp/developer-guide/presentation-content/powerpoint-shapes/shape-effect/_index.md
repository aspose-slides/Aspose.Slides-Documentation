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
- 발광 효과
- 부드러운 가장자리 효과
- 효과 서식
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 고급 도형 효과로 PPT 및 PPTX 파일을 변환하고, 몇 초 만에 눈에 띄고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/cpp/shape-formatting/#gradient-fill)이나 외곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 사실적인 반사 효과를 만들거나, 도형의 발광을 퍼뜨리는 등 다양한 연출을 할 수 있습니다.

<img src="shape-effect.png" alt="모양-효과" style="zoom:50%;" />

* PowerPoint는 도형에 적용할 수 있는 여섯 가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.  
* 일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint에는 **Preset** 옵션이 있습니다. Preset 옵션은 기본적으로 두 개 이상의 효과를 조합한 보기 좋은 조합을 제공합니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 조합해 보는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 [EffectFormat](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.effect_format/) 클래스 아래에 속성 및 메서드를 제공하여 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있게 합니다.

## **그림자 효과 적용**

다음 C++ 코드에서는 사각형에 외부 그림자 효과([OuterShadowEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028))를 적용하는 방법을 보여줍니다.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(System::Drawing::Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **반사 효과 적용**

다음 C++ 코드에서는 도형에 반사 효과를 적용하는 방법을 보여줍니다.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(55);
reflectionEffect->set_BlurRadius(4);

pres->Save(u"reflection.pptx", SaveFormat::Pptx);
```

## **발광 효과 적용**

다음 C++ 코드에서는 도형에 발광 효과를 적용하는 방법을 보여줍니다.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(System::Drawing::Color::get_Magenta());
glowEffect->set_Radius(15);

pres->Save(u"glow.pptx", SaveFormat::Pptx);
```

## **부드러운 가장자리 효과 적용**

다음 C++ 코드에서는 도형에 부드러운 가장자리 효과를 적용하는 방법을 보여줍니다.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(15);

pres->Save(u"softEdges.pptx", SaveFormat::Pptx);
```

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 발광 등 다양한 효과를 하나의 도형에 결합하여 보다 역동적인 모습을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 이미지, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에도 효과를 적용할 수 있나요?**

예, 그룹화된 도형 전체에 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.