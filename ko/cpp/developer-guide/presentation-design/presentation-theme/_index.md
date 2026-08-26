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
- 외부 테마
- THMX
- 테마 색상
- 추가 팔레트
- 테마 폰트
- 테마 스타일
- 테마 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 마스터 프레젠테이션 테마를 사용하여 일관된 브랜딩으로 PowerPoint 파일을 생성, 사용자 정의 및 변환합니다."
---
## **소개**

프레젠테이션 테마는 색상, 폰트, 배경 스타일, 채우기, 선, 효과 등으로 구성된 조정된 집합을 정의합니다. 테마 인식 객체는 각 시각 속성을 고정값으로 저장하는 대신 이러한 공유 정의를 참조하므로 테마를 변경하면 여러 객체를 한 번에 업데이트할 수 있습니다.

Aspose.Slides에서는 프레젠테이션 수준 테마를 [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_mastertheme/)를 통해 사용할 수 있습니다. 프레젠테이션은 낮은 수준에서도 테마 재정의를 포함할 수 있습니다. 마스터는 [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/)를 통해 프레젠테이션 테마를 재정의할 수 있으며, 레이아웃이나 개별 슬라이드는 [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/)를 사용할 수 있습니다. 실제로 슬라이드에 적용되는 테마는 다음 상속 체인을 통해 해결됩니다: 프레젠테이션 테마 → 마스터 재정의 → 레이아웃 재정의 → 슬라이드 재정의.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

아래 섹션에서는 가장 일반적인 테마 작업 흐름을 보여줍니다: 테마 검사, 색상 및 폰트 변경, 테마 복사 또는 적용, 배경 및 효과 스타일 업데이트, 그리고 상속 및 재정의가 해결된 후 실제 값을 읽는 방법.

## **테마 검사**

[MasterTheme](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/mastertheme/) 객체는 테마의 [get_ColorScheme()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), [get_FormatScheme()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) 메서드를 노출합니다. 이러한 컬렉션을 변경하기 전에 검사하면 외부 소스에서 가져온 프레젠테이션의 경우 스타일 항목 수와 내용이 다양할 수 있기 때문에 특히 유용합니다.

다음 예제는 주요 테마 속성을 읽고 테마에 저장된 배경, 채우기, 선, 효과 스타일의 개수를 보고합니다:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

파일에 여러 마스터가 사용된 경우 모든 슬라이드가 동일한 실제 테마를 가진다고 가정해서는 안 됩니다. 슬라이드와 연결된 마스터를 검사하고 레이아웃 또는 슬라이드 재정의가 있을 수 있을 때 아래에 표시된 실제 테마 작업 흐름을 사용하십시오.

## **테마 색상 변경**

테마 인식 채우기, 선, 텍스트는 [SchemeColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides/schemecolor/) 열거형의 논리적 색상을 참조할 수 있습니다. 테마의 [IColorScheme](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/icolorscheme/)에서 해당 항목을 변경하면 해당 테마 색상을 계속 참조하는 모든 객체가 새 값으로 적용됩니다. 직접 RGB 색상을 사용하는 객체는 테마 색상 업데이트의 영향을 받지 않습니다.

다음 엔드‑투‑엔드 예제는 `Accent4`를 사용하는 도형을 만든 뒤 테마의 `Accent4` 색상을 빨간색으로 변경하고, 프레젠테이션을 저장·재열고, 실제 채우기 색상을 출력합니다:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

직사각형이 `Accent4`에 계속 연결돼 있기 때문에 테마가 변경되면 표시 색상이 빨간색으로 바뀝니다. 도형에 직접 색을 지정하면 이후 `Accent4` 변경이 해당 채우기에 영향을 주지 않게 됩니다.

### **추가 팔레트 색상 사용**

PowerPoint는 테마 색상에 색상 변환을 적용해 밝고 어두운 변형을 생성합니다. Aspose.Slides는 이러한 변환을 [ColorTransformOperation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/colortransformoperation/)을 통해 제공한다.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - 주요 테마 색상.  
**2** - 주요 테마 색상에서 파생된 밝고 어두운 변형.

다음 예제는 `Accent4`를 기반으로 여섯 개의 직사각형을 만들고, 그 중 다섯 개에 밝기 변환을 적용한 뒤 결과를 저장합니다:

```cpp
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
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

이 변형은 여전히 테마 색상을 기반으로 합니다. 나중에 `Accent4`가 변경되면 변환된 색상도 새로운 `Accent4` 값으로 다시 계산됩니다.

### **`SchemeColor` 값을 `IColorScheme` 슬롯에 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides/schemecolor/) 열거형은 `Text1`, `Background1`, `Text2`, `Background2`를 사용하고, [IColorScheme](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/icolorscheme/)은 동일한 테마 슬롯을 `Dark1`, `Light1`, `Dark2`, `Light2`로 노출합니다. 매핑은 고정됩니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

이는 동일한 테마 슬롯에 대한 다른 이름일 뿐이며, 한 형태에서 다른 형태로 동적으로 변환되는 값이 아닙니다.

## **테마 폰트 변경**

테마 폰트 스키마는 제목용 주요 폰트 세트와 본문용 부폰트 세트를 포함합니다. [FontScheme::get_Major()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/fontscheme/get_major/)와 [FontScheme::get_Minor()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/fontscheme/get_minor/) 메서드가 각각의 세트를 노출합니다.

PowerPoint 호환 테마 폰트 식별자는 텍스트 서식에 사용할 수 있습니다:

* `+mn-lt` - 본문 라틴 폰트 (Minor Latin Font)
* `+mj-lt` - 제목 라틴 폰트 (Major Latin Font)
* `+mn-ea` - 본문 동아시아 폰트 (Minor East Asian Font)
* `+mj-ea` - 제목 동아시아 폰트 (Major East Asian Font)

다음 예제는 주요 라틴 테마 폰트를 사용하는 제목 한 개와 부 라틴 테마 폰트를 사용하는 본문 한 줄을 만든 뒤, 테마 폰트를 변경하고 결과를 저장합니다:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

제목은 주요 폰트를, 본문은 부폰트를 따릅니다. 명시적으로 폰트 이름을 지정한 텍스트는 테마 폰트 스키마가 변경돼도 자동으로 전환되지 않습니다.

주요 및 부 폰트 컬렉션에는 키릴 문자, 아라비아 문자, 일본어, 조지아 문자, 타아나 문자 등 개별 쓰기 시스템에 대한 폰트 매핑도 포함될 수 있습니다. 이러한 매핑을 검사, 추가, 교체 또는 제거하려면 [Script‑Specific Theme Fonts](/slides/ko/cpp/script-specific-font-mappings/)를 참조하십시오.

{{% alert color="info" title="Tip" %}}
프레젠테이션 폰트에 대한 자세한 내용은 [PowerPoint Fonts](/slides/ko/cpp/powerpoint-fonts/)를 확인하십시오.
{{% /alert %}}

## **테마 복사 또는 적용**

아래 작업 흐름은 다양한 테마 관련 문제를 해결합니다.

### **외부 테마를 마스터 종속 슬라이드에 적용**

PowerPoint 테마 파일(`.thmx`)이 있고 해당 마스터에 종속된 모든 슬라이드의 스타일을 바꾸려면 [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/)를 사용합니다. [Presentation::get_Masters](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_masters/) 컬렉션에서 마스터를 선택하고, 해당 마스터는 [IMasterSlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslidecollection/)을 구현합니다. 그런 다음 테마 파일 경로를 메서드에 전달합니다.

메서드는 다음 작업을 수행합니다:

1. 선택한 마스터를 기반으로 새 마스터 슬라이드를 생성합니다.
2. 새 마스터에 외부 테마를 적용합니다.
3. 이전에 선택한 마스터에 종속된 모든 슬라이드에 새 마스터를 할당합니다.
4. 새로 만든 [IMasterSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslide/)을 반환합니다.

다음 예제는 첫 번째 마스터에 종속된 슬라이드에 외부 테마를 적용하고 프레젠테이션을 저장합니다:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);
auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");

Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());
presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

잘못되었거나 손상되었거나 지원되지 않는 테마는 [PptxException](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pptxexception/) 또는 해당 서브클래스를 발생시킬 수 있습니다. 사용자가 제공한 경로를 검증하고, 파일 시스템 접근 오류를 처리하며, 테마 적용이 성공적으로 완료된 후에만 프레젠테이션을 저장하십시오.

선택한 마스터에 종속된 슬라이드만 재배정됩니다. 다른 마스터와 연결된 슬라이드는 기존 마스터와 테마를 유지합니다. 테마 인식 색상, 폰트, 채우기, 선, 배경, 효과는 외부 테마를 기준으로 해결됩니다. 직접 지정된 색상, 폰트, 채우기 등은 변경되지 않을 수 있습니다. 레이아웃 수준 및 슬라이드 수준 재정의는 새 마스터에서 상속된 값보다 우선할 수 있습니다.

테마는 실행 환경에 없는 폰트를 참조할 수 있습니다. 일관된 렌더링 및 내보내기를 위해 필요한 폰트를 설치하거나 [custom font sources](/slides/ko/cpp/custom-font/)를 통해 제공하거나 [font substitution](/slides/ko/cpp/font-substitution/)을 구성하십시오.

이 방법은 파일 경로만 전달하면 되며 슬라이드‑레벨이나 레이아웃‑레벨 테마 재정의를 수동으로 만들 필요가 없는 직접적인 마스터‑레벨 작업 흐름입니다.

### **다중 마스터 프레젠테이션에서 서로 다른 외부 테마 적용**

대상 마스터를 미리 알 수 없는 경우, [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/get_layoutslide/)와 [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslide/get_masterslide/)를 통해 대표 슬라이드에서 마스터를 가져옵니다. 테마 적용 전에 원본 마스터 참조를 저장하십시오. 각 호출은 프레젠테이션에 새로운 마스터를 생성합니다.

다음 예제는 두 섹션의 슬라이드에서 마스터를 찾아 각각 다른 외부 테마를 적용합니다:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());
        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

첫 번째 호출은 `firstGroupMaster`에 종속된 슬라이드만, 두 번째 호출은 `secondGroupMaster`에 종속된 슬라이드만 영향을 줍니다. 다른 마스터에 속한 슬라이드는 재스타일링되지 않습니다.

### **슬라이드 이동 시 원본 테마 보존**

슬라이드를 다른 프레젠테이션으로 이동하면서 원본 디자인을 유지하려면 [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslidecollection/addclone/)으로 소스 마스터를 대상 프레젠테이션에 복제한 뒤, [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)으로 해당 마스터와 함께 슬라이드를 복제합니다. 이렇게 하면 마스터와 레이아웃, 연관된 테마가 함께 복사됩니다.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

대상 프레젠테이션에서 내용만 복제하고 마스터가 무관하면 테마‑기반 색상, 폰트, 배경, 효과가 변경될 수 있기 때문에, 이 방법이 가장 권장되는 흐름입니다.

### **기존 슬라이드에 테마 값 적용**

대상 슬라이드가 현재 마스터와 레이아웃을 유지해야 할 경우, 소스 테마에서 슬라이드‑레벨 재정의를 초기화합니다. [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/), [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) 메서드가 세 가지 주요 테마 구성 요소를 재정의 테마에 복사합니다.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

이렇게 하면 해당 슬라이드에만 테마가 변경되고 다른 슬라이드가 상속하는 테마는 그대로 유지됩니다. 로컬 재정의를 제거하고 상속값으로 되돌리려면 [OverrideTheme::Clear()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/overridetheme/clear/)를 호출하십시오.

### **레이아웃에 테마 재정의 적용**

레이아웃‑레벨 재정의는 해당 레이아웃을 사용하는 슬라이드에 적용되며, 개별 슬라이드에 별도 재정의가 없는 경우에만 적용됩니다. 동일한 초기화 메서드를 레이아웃의 [IOverrideThemeManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/ioverridethememanager/)를 통해 사용할 수 있습니다:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

많은 레이아웃과 슬라이드가 동일한 기본 디자인을 공유해야 한다면 마스터 또는 프레젠테이션 수준 테마를 사용하고, 특정 레이아웃군에 다른 스타일링이 필요하면 레이아웃 재정의를, 진정한 예외에만 슬라이드 재정의를 적용하십시오. 과도한 슬라이드‑레벨 재정의는 이후 전체 테마 변경을 예측하기 어렵게 만들 수 있습니다.

## **테마 배경 스타일 업데이트**

테마의 배경 채우기는 [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/)에 저장됩니다. PowerPoint UI는 테마 채우기와 테마 색상 및 기타 스타일 참조를 결합할 수 있기 때문에 실제 컬렉션에 저장된 채우기 정의보다 더 많은 배경 옵션을 제공할 수 있습니다.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

배경 스타일을 사용하기 전에 저장된 컬렉션과 현재 [Background::get_StyleIndex()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/background/get_styleindex/)를 확인하십시오. `StyleIndex`가 `0`이면 테마 채우기가 없으며, 양수 값은 테마 배경‑스타일 참조입니다. 이는 `idx_get(0)`이 첫 번째 저장 항목을 의미하는 C++ 컬렉션 인덱싱과 다릅니다. 모든 프레젠테이션이 동일한 배경 채우기 스타일 수를 가지고 있다고 가정하지 마십시오.

다음 예제는 사용 가능한 배경 채우기 수를 보고하고, 첫 번째 마스터에 테마 배경 참조를 할당한 뒤 프레젠테이션을 저장합니다:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

시각적인 결과는 마스터가 참조하는 테마 항목과 레이아웃·슬라이드 수준의 배경 재정의 여부에 따라 달라집니다. 슬라이드가 자체 배경을 사용하고 있다면 마스터 배경만 변경해도 해당 슬라이드는 변하지 않을 수 있습니다. 최종 배경을 알고 싶을 때는 [Background::GetEffective()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/background/geteffective/)를 사용하십시오.

{{% alert color="warning" title="Warning" %}}
`StyleIndex`를 0 기반 컬렉션 인덱스로 오해하지 마십시오. 또한 한 파일에서 스타일 번호를 하드코딩하고 다른 파일에서도 동일한 모양을 기대하지 마십시오. 테마 스타일 정의는 프레젠테이션마다 다릅니다.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
직접 배경 서식 및 배경 상속에 대해서는 [Presentation Background](/slides/ko/cpp/presentation-background/)를 참고하십시오.
{{% /alert %}}

## **테마 효과 업데이트**

테마 포맷 스키마는 별도의 [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/formatscheme/get_linestyles/), [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) 컬렉션을 포함합니다. 일반적인 Office 테마는 미묘함, 보통, 강렬한 서식을 시각적으로 대응시키는 세 개의 주요 스타일 항목을 포함하지만, 코드는 고정된 개수를 가정하지 말고 각 컬렉션을 검사해야 합니다.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

C++에서 이러한 컬렉션에 접근하면 인덱스는 0 기반입니다: `idx_get(0)`은 첫 번째 저장 스타일, `idx_get(2)`는 세 번째 스타일입니다. 도형의 스타일‑참조 인덱스는 별개의 개념으로, [IShapeStyle](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapestyle/)을 통해 노출됩니다. 테마 스타일을 수정하면 해당 테마 스타일을 참조하는 도형에 영향을 주지만, 직접 서식이 적용된 도형은 변하지 않을 수 있습니다.

다음 예제는 필요한 스타일 항목이 존재하는지 확인하고, 첫 번째 선 스타일을 변경하며, 세 번째 채우기 스타일을 변경하고, 세 번째 효과 스타일에 외부 그림자를 적용한 뒤 결과를 저장합니다:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
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
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

해당 슬롯을 참조하는 도형의 경우, 첫 번째 테마 선 스타일은 빨간색이 되고, 세 번째 테마 채우기 스타일은 실선 포레스트 그린이 되며, 세 번째 효과 스타일은 거리 10포인트의 외부 그림자를 얻게 됩니다. 정확한 시각적 결과는 각 도형이 어떤 슬롯을 참조하는지와 직접 서식이 테마를 오버라이드하는지 여부에 따라 달라집니다.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **실제 테마 값 읽기**

원시 테마 객체는 특정 레벨에 정의된 내용을 알려줍니다. 실제 값은 상속 및 로컬 재정의가 모두 적용된 후 슬라이드 또는 도형이 실제로 사용하는 값을 알려줍니다. 슬라이드의 경우 [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)를 호출합니다. 배경은 [Background::GetEffective()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/background/geteffective/)를, 채우기는 [FillFormat::GetEffective()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fillformat/geteffective/)를 사용합니다.

다음 예제는 슬라이드에서 실제 테마, 배경 및 첫 번째 도형 채우기를 읽습니다:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

렌더링 진단, 검증, 비교 등에 실제 데이터를 사용하십시오. [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_mastertheme/)만 검사하면 마스터, 레이아웃, 슬라이드 또는 도형 재정의로 인해 최종 외관이 달라지는 경우를 놓칠 수 있습니다.

## **FAQ**

**외부 테마를 적용하면 프레젠테이션의 모든 슬라이드에 영향을 줍니까?**

아니요. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/)는 선택한 마스터에 종속된 슬라이드만 재할당합니다. 다른 마스터를 사용하는 슬라이드는 기존 테마를 유지합니다.

**마스터를 변경하지 않고 단일 슬라이드에만 테마를 적용할 수 있나요?**

가능합니다. 슬라이드의 [IOverrideThemeManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/ioverridethememanager/)를 사용해 재정의 테마를 초기화하십시오. 변경 사항은 해당 슬라이드에만 적용되고 다른 슬라이드는 기존 테마를 상속합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 테마를 안전하게 전달하려면 어떻게 해야 하나요?**

슬라이드를 이동하면서 원본 외관을 보존하려면 [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslidecollection/addclone/)로 소스 마스터를 대상에 복제하고, [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)로 해당 마스터와 함께 슬라이드를 복제하십시오. 이렇게 하면 마스터, 레이아웃 및 테마가 함께 유지됩니다.

**상속 및 재정의 후 실제 값을 어떻게 확인할 수 있나요?**

슬라이드 또는 레이아웃 테마에 대해서는 [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)를 사용하고, 포맷 객체(예: [Background::GetEffective()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/background/geteffective/), [FillFormat::GetEffective()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fillformat/geteffective/))에 대해서는 해당 실제‑데이터 메서드를 사용하십시오. 이러한 API는 상속 및 재정의가 적용된 후 해결된 값을 반환합니다.