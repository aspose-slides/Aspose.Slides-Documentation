---
title: C++에서 프레젠테이션 테마 관리
linktitle: 프레젠테이션 테마
type: docs
weight: 10
url: /ko/cpp/presentation-theme/
keywords:
- PowerPoint 테마
- 프레젠테이션 테마
- 슬라이드 테마
- 테마 설정
- 테마 변경
- 테마 관리
- 테마 색상
- 추가 팔레트
- 테마 글꼴
- 테마 스타일
- 테마 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 프레젠테이션 테마를 마스터하여 일관된 브랜딩으로 PowerPoint 파일을 만들고, 맞춤화하고, 변환합니다."
---
## **소개**

프레젠테이션 테마는 디자인 요소의 속성을 정의합니다. 프레젠테이션 테마를 선택하면 본질적으로 특정 시각 요소와 해당 속성 집합을 선택하는 것입니다.

PowerPoint에서는 테마가 색상, [글꼴](/slides/ko/cpp/powerpoint-fonts/), [배경 스타일](/slides/ko/cpp/presentation-background/), 그리고 효과로 구성됩니다.

![theme-constituents](theme-constituents.png)

## **테마 색상 변경**

PowerPoint 테마는 슬라이드의 다양한 요소에 대해 특정 색상 집합을 사용합니다. 색상이 마음에 들지 않으면 새 색상을 적용하여 테마 색상을 변경합니다. 새로운 테마 색상을 선택할 수 있도록 Aspose.Slides는 [SchemeColor](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) 열거형에 정의된 값을 제공합니다.

이 C++ 코드는 테마의 강조 색상을 변경하는 방법을 보여줍니다:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

다음과 같이 결과 색상의 유효 값을 확인할 수 있습니다:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto fillEffective = shape->get_FillFormat()->GetEffective();

Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (색상 [A=255, R=128, G=100, B=162])
```

색상 변경 작업을 보다 명확히 보여주기 위해 다른 요소를 만들고 초기 연산에서 얻은 강조 색상을 할당한 뒤, 테마 색상을 다시 변경합니다:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();

auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);

otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

새 색상이 두 요소에 자동으로 적용됩니다.

### **추가 팔레트에서 테마 색상 설정**

주 테마 색상(1)에 밝기 변환을 적용하면 추가 팔레트(2)에서 색상이 생성됩니다. 그런 다음 해당 테마 색상을 설정하고 가져올 수 있습니다.

![additional-palette-colors](additional-palette-colors.png)

**1**- 메인 테마 색상

**2**- 추가 팔레트의 색상

이 C++ 코드는 메인 테마 색상에서 파생된 추가 팔레트 색상을 가져와 도형에 적용하는 예시를 보여줍니다:

```c++
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// 강조 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// 강조 4, 더 밝게 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// 강조 4, 더 밝게 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// 강조 4, 더 밝게 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// 강조 4, 더 어둡게 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// 강조 4, 더 어둡게 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **`SchemeColor`를 `IColorScheme` 색상에 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides.schemecolor/)를 사용할 때 다음과 같은 테마 색상 값이 포함되어 있음을 확인할 수 있습니다:

`Background1`, `Background2`, `Text1`, `Text2`.

하지만 `Presentation::get_MasterTheme()::get_ColorScheme()`은 [IColorScheme](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/icolorscheme/)을 반환하며, 해당 색상은 다음과 같이 노출됩니다:

`Dark1`, `Dark2`, `Light1`, `Light2`.

이 차이는 단순히 명명 방식의 차이일 뿐이며, 값은 동일한 테마 색상 슬롯을 가리키고 매핑은 고정되어 있습니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background`와 `Dark`/`Light` 사이의 동적 변환은 존재하지 않으며, 동일한 테마 색상의 대체 이름일 뿐입니다.

이 명명 차이는 Microsoft Office 용어에서 비롯되었습니다. 이전 Office 버전에서는 `Dark 1`, `Light 1`, `Dark 2`, `Light 2`를 사용했으며, 최신 UI 버전에서는 동일한 슬롯을 `Text 1`, `Background 1`, `Text 2`, `Background 2`로 표시합니다.

## **테마 글꼴 변경**

테마 및 기타 목적을 위해 글꼴을 선택할 수 있도록 Aspose.Slides는 PowerPoint와 유사한 특수 식별자를 사용합니다:

* **+mn-lt** - 본문 글꼴 라틴 (Minor Latin Font)
* **+mj-lt** - 제목 글꼴 라틴 (Major Latin Font)
* **+mn-ea** - 본문 글꼴 동아시아 (Minor East Asian Font)
* **+mj-ea** - 제목 글꼴 동아시아 (Major East Asian Font)

이 C++ 코드는 라틴 글꼴을 테마 요소에 할당하는 방법을 보여줍니다:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

이 C++ 코드는 프레젠테이션 테마 글꼴을 변경하는 방법을 보여줍니다:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

모든 텍스트 상자의 글꼴이 업데이트됩니다.

{{% alert color="info" title="TIP" %}} 
PowerPoint 글꼴을 확인해 보시기 바랍니다. [PowerPoint 글꼴](/slides/ko/cpp/powerpoint-fonts/).
{{% /alert %}}

## **테마 배경 스타일 변경**

기본적으로 PowerPoint 앱은 12개의 미리 정의된 배경을 제공하지만, 일반 프레젠테이션에서는 그 중 3개만 저장됩니다.

![todo:image_alt_text](presentation-design_8.png)

예를 들어, PowerPoint 앱에서 프레젠테이션을 저장한 후 다음 C++ 코드를 실행하면 프레젠테이션에 포함된 미리 정의된 배경 수를 확인할 수 있습니다:

```c++
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Theme;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) 속성을 사용하면 [FormatScheme](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.theme.i_format_scheme/) 클래스에서 PowerPoint 테마의 배경 스타일을 추가하거나 접근할 수 있습니다. 
{{% /alert %}}

이 C++ 코드는 프레젠테이션의 배경을 설정하는 방법을 보여줍니다:

```c++
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**인덱스 안내**: 0은 채우기 없음에 사용됩니다. 인덱스는 1부터 시작합니다.

{{% alert color="info" title="TIP" %}} 
PowerPoint 배경에 대해 알아보시기 바랍니다. [PowerPoint 배경](/slides/ko/cpp/presentation-background/).
{{% /alert %}}

## **테마 효과 변경**

PowerPoint 테마는 일반적으로 각 스타일 배열에 대해 3개의 값을 포함합니다. 이러한 배열은 미묘, 보통, 강렬이라는 3가지 효과로 결합됩니다. 예를 들어, 특정 도형에 효과를 적용했을 때의 결과는 다음과 같습니다:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.theme.i_format_scheme/) 클래스의 3가지 속성([FillStyles](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58))을 사용하면 PowerPoint 옵션보다 더 유연하게 테마의 요소를 변경할 수 있습니다.

이 C++ 코드는 요소의 일부를 변경하여 테마 효과를 바꾸는 방법을 보여줍니다:

```c++
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");

pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

결과적인 채우기 색상, 채우기 유형, 그림자 효과 등의 변경 사항:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### 테마를 마스터를 변경하지 않고 단일 슬라이드에 적용할 수 있나요?

예. Aspose.Slides는 슬라이드 수준의 테마 재정의를 지원하므로, [SlideThemeManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/slidethememanager/)를 통해 마스터 테마는 그대로 두고 해당 슬라이드에 로컬 테마를 적용할 수 있습니다.

### 한 프레젠테이션에서 다른 프레젠테이션으로 테마를 가장 안전하게 옮기는 방법은?

[슬라이드 복제](/slides/ko/cpp/clone-slides/)와 함께 마스터를 대상 프레젠테이션에 복사하면 원본 마스터, 레이아웃 및 연결된 테마가 보존되어 외관이 일관됩니다.

### 모든 상속 및 재정의 후 “유효” 값을 어떻게 확인할 수 있나요?

테마/색상/글꼴/효과에 대한 API의 ["유효" 보기](/slides/ko/cpp/shape-effective-properties/)를 사용하십시오. 이는 마스터와 모든 로컬 재정의를 적용한 후 해결된 최종 속성을 반환합니다.