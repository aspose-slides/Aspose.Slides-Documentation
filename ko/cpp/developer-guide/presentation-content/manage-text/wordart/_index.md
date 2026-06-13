---
title: C++에서 WordArt 효과 만들기 및 적용
linktitle: WordArt
type: docs
weight: 110
url: /ko/cpp/wordart/
keywords:
- WordArt
- WordArt 만들기
- WordArt 템플릿
- WordArt 효과
- 그림자 효과
- 디스플레이 효과
- 글로우 효과
- WordArt 변환
- 3D 효과
- 외부 그림자 효과
- 내부 그림자 효과
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 WordArt 효과를 만들고 사용자 지정합니다. 이 단계별 가이드는 개발자가 C++에서 전문적인 텍스트로 프레젠테이션을 향상시키는 데 도움이 됩니다."
---
## **개요**

WordArt 효과를 사용하면 PowerPoint 프레젠테이션에 시각적으로 매력적이고 스타일화된 텍스트를 추가할 수 있습니다. Aspose.Slides를 이용하면 개발자가 Microsoft PowerPoint와 동일하게 WordArt를 프로그래밍 방식으로 생성, 사용자 지정 및 관리할 수 있으며 Office가 설치되어 있을 필요가 없습니다. 이 문서는 WordArt 작업에 대한 개요를 제공하며, 텍스트 변환, 채우기 스타일, 윤곽선, 그림자 및 기타 서식 옵션을 적용하여 프레젠테이션 내용이 보다 풍부하고 매력적으로 만드는 방법을 다룹니다. WordArt는 텍스트를 그래픽 객체처럼 취급할 수 있게 해 줍니다. 텍스트에 적용되는 효과 또는 특수 수정으로 텍스트를 더 매력적이거나 눈에 띄게 만들 수 있습니다.

## **간단한 WordArt 템플릿 만들기 및 텍스트에 적용하기**

**Aspose.Slides 사용** 

먼저, 다음 C++ 코드를 사용하여 간단한 텍스트를 만듭니다. 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

이제 다음 코드를 통해 텍스트의 폰트 높이를 더 크게 설정하여 효과를 눈에 띄게 합니다. 

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Microsoft PowerPoint 사용**

Microsoft PowerPoint에서 WordArt 효과 메뉴로 이동합니다: 

![todo:image_alt_text](image-20200930113926-1.png)

오른쪽 메뉴에서 미리 정의된 WordArt 효과를 선택할 수 있습니다. 왼쪽 메뉴에서는 새 WordArt에 대한 설정을 지정할 수 있습니다. 

다음은 사용 가능한 일부 매개변수 또는 옵션입니다: 

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides 사용**

여기서는 SmallGrid 패턴 색상을 텍스트에 적용하고 이 코드를 사용하여 1 너비의 검은색 텍스트 테두리를 추가합니다: 

``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

결과 텍스트: 

![todo:image_alt_text](image-20200930114108-4.png)

## **다른 WordArt 효과 적용**

**Microsoft PowerPoint 사용**

프로그램 인터페이스에서 텍스트, 텍스트 블록, 도형 또는 유사 요소에 이러한 효과를 적용할 수 있습니다: 

![todo:image_alt_text](image-20200930114129-5.png)

예를 들어, 그림자, 반사 및 글로우 효과는 텍스트에 적용할 수 있고, 3D 형식 및 3D 회전 효과는 텍스트 블록에 적용할 수 있으며, 소프트 엣지 속성은 도형 객체에 적용할 수 있습니다(3D 형식 속성이 설정되지 않은 경우에도 효과가 있습니다). 

### **텍스트에 그림자 효과 적용**

여기서는 텍스트에만 해당하는 속성을 설정하려고 합니다. 다음 C++ 코드를 사용하여 텍스트에 그림자 효과를 적용합니다: 

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

Aspose.Slides API는 OuterShadow, InnerShadow 및 PresetShadow의 세 가지 유형의 그림자를 지원합니다. 

 PresetShadow를 사용하면 사전 정의된 값을 이용해 텍스트에 그림자를 적용할 수 있습니다. 

**Microsoft PowerPoint 사용**

PowerPoint에서는 한 종류의 그림자만 사용할 수 있습니다. 예시는 다음과 같습니다: 

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides 사용**

Aspose.Slides는 실제로 두 종류의 그림자(InnerShadow 및 PresetShadow)를 동시에 적용할 수 있습니다. 

**참고:**

- OuterShadow와 PresetShadow를 함께 사용할 경우, OuterShadow 효과만 적용됩니다. 
- OuterShadow와 InnerShadow를 동시에 사용하면 적용되는 효과는 PowerPoint 버전에 따라 달라집니다. 예를 들어 PowerPoint 2013에서는 효과가 두 배가 되지만, PowerPoint 2007에서는 OuterShadow 효과만 적용됩니다. 

### **반사 효과 적용**

다음 C++ 코드 샘플을 통해 텍스트에 반사 효과를 추가합니다: 

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

### **글로우 효과 적용**

다음 코드를 사용하여 텍스트에 글로우 효과를 적용해 빛나거나 돋보이게 합니다: 

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

작업 결과: 

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

그림자, 디스플레이 및 글로우의 매개변수를 변경할 수 있습니다. 효과 속성은 텍스트의 각 부분에 별도로 설정됩니다. 

{{% /alert %}} 

### **WordArt에서 변환 사용**

다음 코드를 통해 전체 텍스트 블록에 내재된 set_Transform 메서드를 사용합니다: 

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

결과: 

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint와 Aspose.Slides for C++ 모두 일정 수의 미리 정의된 변환 유형을 제공합니다. 

{{% /alert %}} 

**PowerPoint 사용**

미리 정의된 변환 유형에 접근하려면 **Format** -> **TextEffect** -> **Transform** 순으로 이동합니다. 

**Aspose.Slides 사용**

변환 유형을 선택하려면 TextShapeType 열거형을 사용합니다. 

### **텍스트 및 도형에 3D 효과 적용**

다음 샘플 코드를 사용하여 텍스트 도형에 3D 효과를 설정합니다: 

``` cpp 
auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

결과 텍스트와 도형: 

![todo:image_alt_text](image-20200930114816-9.png)

다음 C++ 코드를 사용하여 텍스트에 3D 효과를 적용합니다: 

``` cpp 
auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

작업 결과: 

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

텍스트 또는 해당 도형에 3D 효과를 적용하고 효과 간 상호 작용은 특정 규칙에 따라 이루어집니다. 

텍스트와 해당 텍스트를 포함하는 도형에 대한 씬을 고려하십시오. 3D 효과는 3D 객체 표현과 객체가 배치된 씬을 포함합니다. 

- 도형과 텍스트 모두에 씬이 설정된 경우, 도형 씬이 더 높은 우선 순위를 갖고 텍스트 씬은 무시됩니다. 
- 도형에 자체 씬이 없지만 3D 표현이 있는 경우 텍스트 씬이 사용됩니다. 
- 그 외의 경우—도형에 원래 3D 효과가 없을 때—도형은 평면이며 3D 효과는 텍스트에만 적용됩니다. 

이러한 설명은 `ThreeDFormat.getLightRig()` 및 `ThreeDFormat.getCamera()` 메서드와 연결됩니다. 

{{% /alert %}} 

## **도형에 외부 그림자 효과 적용**
Aspose.Slides for C++는 텍스트가 포함된 TextFrame에 그림자 효과를 적용할 수 있도록 하는 [**IOuterShadow**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.effects.i_outer_shadow) 및 [**IInnerShadow**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.effects.i_inner_shadow) 클래스를 제공합니다. 다음 단계를 수행하십시오:

1. Presentation 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.  
3. 슬라이드에 사각형 형태의 AutoShape를 추가합니다.  
4. AutoShape와 연결된 TextFrame에 접근합니다.  
5. AutoShape의 FillType을 NoFill로 설정합니다.  
6. OuterShadow 클래스를 인스턴스화합니다.  
7. 그림자의 BlurRadius를 설정합니다.  
8. 그림자의 Direction을 설정합니다.  
9. 그림자의 Distance를 설정합니다.  
10. RectanglelAlign을 TopLeft로 설정합니다.  
11. 그림자의 PresetColor를 Black으로 설정합니다.  
12. 프레젠테이션을 PPTX 파일로 저장합니다.  

위 단계의 구현 예시인 C++ 샘플 코드는 텍스트에 외부 그림자 효과를 적용하는 방법을 보여줍니다: 

``` cpp
auto pres = System::MakeObject<Presentation>();
// 슬라이드에 대한 참조 가져오기
auto sld = pres->get_Slides()->idx_get(0);

// 사각형 유형의 AutoShape 추가
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// 사각형에 TextFrame 추가
ashp->AddTextFrame(u"Aspose TextBox");

// 텍스트 그림자를 얻기 위해 도형 채우기를 비활성화
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 외부 그림자를 추가하고 모든 필요한 매개변수를 설정
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// 프레젠테이션을 디스크에 저장
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **도형에 내부 그림자 효과 적용**
다음 단계를 수행하십시오:

1. Presentation 클래스의 인스턴스를 생성합니다.  
2. 슬라이드의 참조를 가져옵니다.  
3. 사각형 형태의 AutoShape를 추가합니다.  
4. InnerShadowEffect를 활성화합니다.  
5. 필요한 모든 매개변수를 설정합니다.  
6. ColorType을 Scheme으로 설정합니다.  
7. Scheme Color를 설정합니다.  
8. 프레젠테이션을 PPTX 파일로 저장합니다.  

위 단계에 기반한 샘플 코드는 C++에서 두 도형 사이에 커넥터를 추가하는 방법을 보여줍니다: 

``` cpp
auto presentation = System::MakeObject<Presentation>();
// 슬라이드에 대한 참조 가져오기
auto slide = presentation->get_Slides()->idx_get(0);

// 사각형 유형의 AutoShape 추가
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 사각형에 TextFrame 추가
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// 내부 그림자 효과 활성화    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// 필요한 모든 매개변수 설정
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// ColorType을 Scheme으로 설정
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Scheme 색상 설정
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// 프레젠테이션 저장
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**WordArt 효과를 다양한 글꼴이나 스크립트(예: 아랍어, 중국어)와 함께 사용할 수 있나요?**

네, Aspose.Slides는 Unicode를 지원하며 모든 주요 글꼴 및 스크립트와 함께 작동합니다. 언어에 관계없이 그림자, 채우기 및 윤곽선과 같은 WordArt 효과를 적용할 수 있지만, 글꼴 가용성 및 렌더링은 시스템에 설치된 글꼴에 따라 달라질 수 있습니다.

**WordArt 효과를 슬라이드 마스터 요소에 적용할 수 있나요?**

네, 마스터 슬라이드의 도형(제목 플레이스홀더, 바닥글, 배경 텍스트 등)에 WordArt 효과를 적용할 수 있습니다. 마스터 레이아웃에 적용한 변경 사항은 해당 슬라이드에 자동으로 반영됩니다.

**WordArt 효과가 프레젠테이션 파일 크기에 영향을 미치나요?**

약간 영향을 미칩니다. 그림자, 글로우 및 그라데이션 채우기와 같은 WordArt 효과는 추가 서식 메타데이터를 포함하므로 파일 크기가 약간 증가할 수 있지만 차이는 대부분 무시할 수 있는 수준입니다.

**프레젠테이션을 저장하지 않고 WordArt 효과 결과를 미리 볼 수 있나요?**

네, `IShape`[https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/] 또는 `ISlide`[https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/] 인터페이스의 `GetImage` 메서드를 사용하여 WordArt가 적용된 슬라이드를 이미지(PNG, JPEG 등)로 렌더링할 수 있습니다. 이를 통해 전체 프레젠테이션을 저장하거나 내보내기 전에 메모리 내 또는 화면에서 결과를 미리 확인할 수 있습니다.