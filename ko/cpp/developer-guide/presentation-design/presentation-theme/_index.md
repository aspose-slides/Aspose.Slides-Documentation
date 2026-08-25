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
description: "Aspose.Slides for C++에서 일관된 브랜딩으로 PowerPoint 파일을 만들고, 맞춤화하고, 변환하기 위한 마스터 프레젠테이션 테마."
---
## **소개**

프레젠테이션 테마는 색상, 글꼴, 배경 스타일, 채우기, 선 및 효과의 조정된 집합을 정의합니다. 테마 인식 객체는 각 시각 속성을 고정값으로 저장하는 대신 이러한 공유 정의를 참조하므로 테마를 변경하면 많은 객체를 한 번에 업데이트할 수 있습니다.

Aspose.Slides에서는 프레젠테이션 수준의 테마를 [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_mastertheme/)를 통해 사용할 수 있습니다. 프레젠테이션에는 하위 수준에서 테마를 재정의할 수 있는 옵션도 포함될 수 있습니다. 마스터는 [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/)를 통해 프레젠테이션 테마를 재정의할 수 있고, 레이아웃이나 개별 슬라이드는 [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/)를 사용할 수 있습니다. 실제로 슬라이드에 적용되는 테마는 다음과 같은 상속 체인을 통해 결정됩니다: 프레젠테이션 테마 → 마스터 재정의 → 레이아웃 재정의 → 슬라이드 재정의.

![테마 구성 요소: 색상, 글꼴, 배경 스타일 및 효과](theme-constituents.png)

아래 섹션에서는 가장 일반적인 테마 작업 흐름을 보여줍니다. 테마를 검사하고, 색상 및 글꼴을 변경하고, 테마를 복사하거나 적용하고, 배경 및 효과 스타일을 업데이트하며, 상속 및 재정의가 해결된 후의 실제 값을 읽는 방법을 다룹니다.

## **테마 검사**

[MasterTheme](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/mastertheme/) 객체는 테마의 [get_ColorScheme()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), [get_FormatScheme()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) 메서드를 제공합니다. 변경하기 전에 이러한 컬렉션을 검사하면 프레젠테이션이 외부 소스에서 가져온 경우 스타일 항목의 수와 내용이 다양할 수 있기 때문에 특히 유용합니다.

다음 예제는 기본 테마 속성을 읽고 테마에 저장된 배경, 채우기, 선 및 효과 스타일이 각각 몇 개 있는지 보고합니다:

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

파일에 여러 마스터가 존재하는 경우 모든 슬라이드가 동일한 실제 테마를 갖는다고 가정하지 마세요. 슬라이드와 연결된 마스터를 검사하고, 레이아웃이나 슬라이드 재정의가 존재할 수 있는 경우 이 문서 후반에 소개되는 실제 테마 작업 흐름을 사용하십시오.

## **테마 색상 변경**

테마 인식 채우기, 선 및 텍스트는 [SchemeColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides/schemecolor/) 열거형의 논리적 색상을 참조할 수 있습니다. 테마의 [IColorScheme](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/icolorscheme/)에서 해당 항목을 변경하면 해당 테마 색상을 계속 참조하는 모든 객체가 새로운 값으로 다시 계산됩니다. 직접 RGB 색상을 사용하는 객체는 테마 색상 업데이트의 영향을 받지 않습니다.

다음 엔드투엔드 예제는 `Accent4`를 사용하는 도형을 만든 뒤 테마의 `Accent4` 색상을 빨강으로 변경하고, 프레젠테이션을 저장한 뒤 다시 열어 실제 채우기 색상을 출력합니다:

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

사각형이 `Accent4`에 여전히 연결되어 있기 때문에 테마가 변경되면 보이는 색상이 빨강으로 바뀝니다. 도형에 직접 색상을 지정하면 이후 `Accent4`가 변경되더라도 해당 채우기는 영향을 받지 않습니다.

### **추가 팔레트의 색상 사용**

PowerPoint는 테마 색상에서 색상 변환을 적용하여 밝거나 어두운 변형을 생성합니다. Aspose.Slides는 이러한 변환을 [ColorTransformOperation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/colortransformoperation/)을 통해 노출합니다.

![추가 팔레트에서 생성된 기본 테마 색상 및 밝고 어두운 변형](additional-palette-colors.png)

**1** - 기본 테마 색상.

**2** - 기본 테마 색상에서 파생된 밝고 어두운 변형.

다음 예제는 `Accent4`를 기반으로 여섯 개의 사각형을 만들고, 그 중 다섯 개에 밝기 변환을 적용한 뒤 결과를 저장합니다:

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

이러한 변형은 테마 색상을 기반으로 유지됩니다. 나중에 `Accent4`가 변경되면 변환된 색상은 새로운 `Accent4` 값으로 다시 계산됩니다.

### **`SchemeColor` 값을 `IColorScheme` 슬롯에 매핑**

[SchemeColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides/schemecolor/) 열거형은 `Text1`, `Background1`, `Text2`, `Background2`를 사용하고, [IColorScheme](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/icolorscheme/)은 동일한 테마 슬롯을 `Dark1`, `Light1`, `Dark2`, `Light2`로 노출합니다. 매핑은 다음과 같이 고정됩니다:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

이는 동일한 테마 슬롯에 대한 다른 이름일 뿐이며, 한 형태에서 다른 형태로 동적으로 변환되는 값이 아닙니다.

## **테마 글꼴 변경**

테마 글꼴 스키마에는 제목용 주요 글꼴 집합과 본문용 보조 글꼴 집합이 포함됩니다. [FontScheme::get_Major()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/fontscheme/get_major/) 및 [FontScheme::get_Minor()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/fontscheme/get_minor/) 메서드를 통해 해당 집합에 접근할 수 있습니다.

PowerPoint 호환 테마 글꼴 식별자는 텍스트 서식에 사용할 수 있습니다:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

다음 예제는 주요 라틴 테마 글꼴을 사용하는 제목 하나와 보조 라틴 테마 글꼴을 사용하는 본문 라인 하나를 만든 뒤, 테마 글꼴을 변경하고 결과를 저장합니다:

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

제목은 주요 글꼴을 따르고 본문 텍스트는 보조 글꼴을 따릅니다. 테마 식별자가 아닌 명시적 글꼴 이름을 사용한 텍스트는 테마 글꼴 스키마가 변경돼도 자동으로 전환되지 않습니다.

주요·보조 글꼴 컬렉션에는 키릴 문자, 아랍어, 일본어, 그루지야 문자, 타나와 같은 개별 쓰기 시스템에 대한 글꼴 매핑도 포함될 수 있습니다. 이러한 매핑을 검사, 추가, 교체 또는 제거하려면 [스크립트별 테마 글꼴](/slides/ko/cpp/script-specific-font-mappings/)을 참조하십시오.

{{% alert color="info" title="Tip" %}}
프레젠테이션 글꼴에 대한 자세한 내용은 [PowerPoint Fonts](/slides/ko/cpp/powerpoint-fonts/)를 확인하세요.
{{% /alert %}}

## **테마 복사 또는 적용**

두 가지 일반적인 작업 흐름이 있으며, 해결하는 문제가 다릅니다.

### **슬라이드 이동 시 원본 테마 유지**

슬라이드를 다른 프레젠테이션으로 이동하면서 원래 디자인을 유지하려면 [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslidecollection/addclone/)을 사용해 원본 마스터를 대상 프레젠테이션에 복제하고, 이후 [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)을 사용해 슬라이드와 복제된 마스터를 복제합니다. 이렇게 하면 마스터와 레이아웃, 관련 테마가 함께 이동됩니다.

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

대상 슬라이드가 동일하게 보이도록 해야 할 때 권장되는 작업 흐름입니다. 관련 없는 대상 마스터에 콘텐츠만 복제하면 테마 기반 색상, 글꼴, 배경 및 효과가 변경될 수 있습니다.

### **기존 슬라이드에 테마 값 적용**

대상 슬라이드가 현재 마스터와 레이아웃에 머물러야 하는 경우, 원본 테마에서 슬라이드 수준 재정의를 초기화합니다. [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/), [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) 메서드는 세 가지 주요 테마 구성 요소를 재정의에 복사합니다.

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

이렇게 하면 다른 슬라이드가 상속받는 테마는 변경하지 않고 해당 슬라이드에만 테마가 적용됩니다. 로컬 재정의를 제거하고 상속값으로 되돌리려면 [OverrideTheme::Clear()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/overridetheme/clear/)를 호출하십시오.

### **레이아웃에 테마 재정의 적용**

레이아웃 수준 재정의는 해당 레이아웃을 사용하는 모든 슬라이드에 적용되며, 개별 슬라이드에 자체 재정의가 있는 경우에는 예외가 됩니다. 동일한 초기화 메서드를 레이아웃의 [IOverrideThemeManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/ioverridethememanager/)를 통해 사용할 수 있습니다.

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

다수의 레이아웃·슬라이드가 동일한 기본 디자인을 공유해야 할 때는 마스터·프레젠테이션 수준 테마를 사용하고, 하나의 레이아웃군에 다른 스타일링이 필요할 때는 레이아웃 재정의를, 진정한 예외 상황에만 슬라이드 재정의를 사용하십시오. 과도한 슬라이드 수준 재정의는 이후 전역 테마 변경 시 예측을 어렵게 만듭니다.

## **테마 배경 스타일 업데이트**

테마의 배경 채우기는 [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/)에 저장됩니다. PowerPoint UI는 테마 채우기와 테마 색상 및 기타 스타일 참조를 조합할 수 있기 때문에 실제 컬렉션에 저장된 채우기 정의 수보다 더 많은 배경 선택지를 UI에 표시할 수 있습니다.

![프레젠테이션 테마에 대한 PowerPoint 배경 스타일 갤러리](presentation-design_8.png)

배경 스타일을 사용하기 전에 저장된 컬렉션과 현재 [Background::get_StyleIndex()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/background/get_styleindex/)를 검사하십시오. `StyleIndex`가 `0`이면 테마 채우기가 없으며, 양수 값은 테마 배경‑스타일 참조입니다. 이는 C++ 컬렉션을 `idx_get(0)`으로 직접 인덱싱할 때 `0`이 첫 번째 저장 항목을 의미하는 것과는 다릅니다. 모든 프레젠테이션에 동일한 수의 배경 채우기 스타일이 포함된다고 가정하지 마세요.

다음 예제는 사용 가능한 배경 채우기 개수를 보고, 첫 번째 마스터에 테마 배경 참조를 할당하고 프레젠테이션을 저장합니다:

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

보이는 결과는 마스터가 참조하는 테마 항목과 레이아웃·슬라이드 레벨의 배경 재정의 여부에 따라 달라집니다. 슬라이드가 자체 배경을 사용하고 있다면 마스터 배경만 변경해도 해당 슬라이드에는 영향을 주지 않을 수 있습니다. 최종 배경을 확인하려면 [Background::GetEffective()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/background/geteffective/)를 사용하십시오.

{{% alert color="warning" title="Warning" %}}
`StyleIndex`를 0부터 시작하는 컬렉션 인덱스로 오해하지 마세요. 또한 하나의 파일에서 스타일 번호를 하드코딩하고 다른 파일에서도 동일한 모습을 기대하지 마십시오. 테마 스타일 정의는 프레젠테이션마다 다릅니다.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
직접 배경 서식 및 배경 상속에 대한 내용은 [Presentation Background](/slides/ko/cpp/presentation-background/)를 참고하십시오.
{{% /alert %}}

## **테마 효과 업데이트**

테마 형식 스키마는 별도의 [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/formatscheme/get_linestyles/), [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) 컬렉션을 포함합니다. 일반적인 Office 테마는 미묘함, 보통, 강렬한 포맷에 시각적으로 대응하는 세 개의 주요 스타일 항목을 포함하지만, 코드는 고정된 개수를 가정하지 말고 각 컬렉션을 직접 검사해야 합니다.

![같은 도형에 적용된 미묘함, 보통, 강렬함 테마 효과](presentation-design_10.png)

C++에서 이러한 컬렉션에 접근할 때 컬렉션 인덱스는 0부터 시작합니다: `idx_get(0)`은 첫 번째 저장 스타일이고 `idx_get(2)`는 세 번째 스타일입니다. 도형의 스타일‑참조 인덱스는 별개의 개념으로, [IShapeStyle](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapestyle/)을 통해 노출됩니다. 테마 스타일을 수정하면 해당 스타일을 참조하는 도형에 영향을 주며, 직접 서식이 적용된 도형은 변경되지 않을 수 있습니다.

다음 예제는 필요한 스타일 항목이 존재하는지 확인하고, 첫 번째 선 스타일을 변경하고, 세 번째 채우기 스타일을 변경하며, 세 번째 효과 스타일에 외부 그림자를 활성화하고 결과를 저장합니다:

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

이 슬롯을 참조하는 도형에 대해 첫 번째 테마 선 스타일은 빨강으로, 세 번째 테마 채우기 스타일은 단단한 포레스트 그린으로, 세 번째 효과 스타일은 거리 10포인트의 외부 그림자를 갖게 됩니다. 정확한 시각적 결과는 각 도형이 어떤 슬롯을 참조하고 있는지, 그리고 직접 서식이 테마를 재정의했는지에 따라 달라집니다.

![선, 채우기 및 그림자 설정을 변경한 후의 테마 효과 스타일](presentation-design_11.png)

## **실제 테마 값 읽기**

원시 테마 객체는 특정 레벨에 정의된 내용을 알려줍니다. 실제 값은 상속 및 로컬 재정의가 해결된 후 슬라이드나 도형이 실제로 사용하는 값을 나타냅니다. 슬라이드에 대해서는 [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)를 호출합니다. 배경에 대해서는 [Background::GetEffective()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/background/geteffective/)를, 채우기에 대해서는 [FillFormat::GetEffective()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fillformat/geteffective/)를 사용합니다.

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

렌더링 진단, 검증 및 비교를 위해 실제 데이터를 사용하십시오. [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_mastertheme/)만 검사하면 마스터·레이아웃·슬라이드·도형 재정의 중 최종 모양을 바꾸는 항목을 놓칠 수 있습니다.

## **FAQ**

**단일 슬라이드에만 테마를 적용하고 마스터는 변경하지 않을 수 있나요?**

예. 슬라이드의 [IOverrideThemeManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/ioverridethememanager/)를 사용해 재정의 테마를 초기화하면 변경 내용이 해당 슬라이드에만 국한됩니다. 다른 슬라이드는 기존 테마를 그대로 상속합니다.

**프레젠테이션 간에 테마를 안전하게 전달하려면 어떻게 해야 하나요?**

슬라이드를 이동하면서 원본 외관을 보존하려면 원본 마스터를 대상에 복제하고, 그 마스터와 함께 [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslidecollection/addclone/)와 [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)을 사용해 슬라이드를 복제하십시오. 이렇게 하면 마스터, 레이아웃 및 테마가 함께 유지됩니다.

**상속 및 재정의 후 실제 값을 어떻게 확인할 수 있나요?**

슬라이드나 레이아웃 테마에 대해 [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)를 사용하고, [Background::GetEffective()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/background/geteffective/) 및 [FillFormat::GetEffective()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fillformat/geteffective/)와 같은 해당 포맷 객체의 실제 데이터 메서드를 사용하십시오. 이 API들은 상속 및 재정의가 적용된 후 해결된 값을 반환합니다.