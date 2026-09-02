---
title: C++에서 프레젠테이션 현지화 자동화
linktitle: 프레젠테이션 현지화
type: docs
weight: 100
url: /ko/cpp/presentation-localization/
keywords:
- 언어 변경
- 맞춤법 검사
- 맞춤법 검사 억제
- 교정 언어
- 언어 ID
- 다국어 텍스트
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++와 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션 텍스트에 교정 언어를 설정하고 기본값과 다국어 단락을 포함합니다."
---
## **개요**

Aspose.Slides for C++는 개별 텍스트 부분에 대한 교정 메타데이터를 구성할 수 있게 합니다. 교정 언어를 지정하려면 [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseportionformat/set_languageid/)를 사용하고, 철자 검사를 허용하거나 억제하려면 [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_spellcheck/)를 사용하며, 더 넓은 무교정 상태를 제어하려면 [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_proofdisabled/)를 사용합니다. 이러한 설정은 부분 수준에서 적용되므로 하나의 단락에 여러 언어와 서로 다른 교정 규칙을 포함할 수 있습니다.

이 문서에서는 특정 텍스트에 언어를 지정하는 방법, [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/)를 사용하여 새 텍스트에 대한 기본 언어를 설정하는 방법, 다국어 단락을 만드는 방법, `SpellCheck`와 `ProofDisabled` 중에서 선택하는 방법, 그리고 [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/joinportionswithsameformatting/)을 사용할 때 의도한 설정을 보존하는 방법을 설명합니다. 이러한 속성은 프레젠테이션 애플리케이션용 메타데이터를 저장하며, 텍스트를 번역하거나 사전 기반 철자 검사를 수행하거나 오타 단어를 반환하지 않습니다.

## **텍스트에 대한 교정 언어 설정**

[Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)을 만들거나 로드하고, [IPortion::get_PortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/get_portionformat/)을 통해 필요한 텍스트 부분에 접근한 다음 언어 식별자를 지정합니다. 다음 예제는 도형을 만들고, 영국 영어를 교정 언어로 설정한 뒤, [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/)으로 결과를 저장합니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **새 텍스트에 대한 기본 언어 설정**

[ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/)을 사용하면 Aspose.Slides가 새로 만든 텍스트에 자동으로 할당할 교정 언어를 지정할 수 있습니다. 프레젠테이션의 대부분 또는 전체 새 텍스트가 동일한 언어를 사용할 경우에 유용합니다. 이미 명시적인 언어가 지정된 텍스트의 메타데이터는 변경되지 않습니다.

다음 예제는 새 텍스트에 독일어 교정 규칙을 적용하는 프레젠테이션을 생성합니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **한 단락에서 여러 언어 사용**

[IParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iparagraph/)은 텍스트 부분 컬렉션을 포함합니다. 각 언어마다 별도의 [Portion](https://reference.aspose.com/slides/ko/cpp/aspose.slides/portion/)을 생성하고 `LanguageId`를 독립적으로 설정합니다.

다음 예제는 영어와 프랑스어 부분을 포함하는 하나의 단락을 생성합니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **개별 부분에 대한 철자 검사 활성화 또는 억제**

[IPortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportionformat/)은 [IBasePortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseportionformat/)이 정의한 공통 텍스트 속성을 상속합니다. [IPortion::get_PortionFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iportion/get_portionformat/)을 통해 부분의 형식에 접근하고, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_spellcheck/)을 호출하여 해당 부분에 대해 프레젠테이션 애플리케이션이 맞춤법 검사를 수행할 수 있는지 제어합니다. 기본값은 `false`이며, `true`는 맞춤법 검사를 허용하고 `false`는 억제합니다.

이 설정은 개별 텍스트 부분에 적용됩니다. 같은 단락 내의 다른 부분은 서로 다른 값을 가질 수 있습니다. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_languageid/)와 `SpellCheck`는 보완적인 역할을 합니다: `LanguageId`는 교정 언어를 식별하고, `SpellCheck`는 해당 부분에 맞춤법 검사가 허용되는지를 결정합니다.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseportionformat/set_proofdisabled/) 역시 교정을 제어하지만, 이는 [NullableBool](https://reference.aspose.com/slides/ko/cpp/aspose.slides/nullablebool/)으로 표현되는 더 넓은 “교정 안 함” 상태를 나타냅니다. 맞춤법 검사를 위한 직접적인 Boolean 스위치가 필요하면 `SpellCheck`를 사용하고, 프레젠테이션의 무교정 메타데이터(예: `NullableBool::NotDefined` 상태)를 보존하거나 명시적으로 제어하려면 `ProofDisabled`를 사용하십시오. 두 속성을 모두 설정하는 경우 값이 일치하도록 유지하고, `SpellCheck = true`와 `ProofDisabled = NullableBool::True`를 동시에 사용하는 것은 피하십시오.

이러한 속성은 PowerPoint 및 기타 프레젠테이션 애플리케이션에서 사용하는 교정 메타데이터를 구성합니다. Aspose.Slides는 이를 사용해 사전 기반 철자 검사를 수행하거나 오타 단어 목록을 반환하지 않습니다.

다음 완전한 예제는 입력 프레젠테이션을 만들고, 로드한 뒤, 같은 단락 내 두 부분에 서로 다른 철자 검사 설정 및 교정 언어를 할당하고, 결과를 저장한 후 다시 열어 저장된 값을 검증합니다.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/joinportionswithsameformatting/)은 동일한 서식을 가진 인접한 부분을 결합합니다. `SpellCheck` 값만 다르면 이러한 부분은 별도로 유지되지 않으며, 결합된 후 결과 부분은 첫 번째 부분의 `SpellCheck` 값을 유지합니다. 부분마다 다른 철자 검사 설정이 필요하면 해당 설정을 할당하기 전에 `JoinPortionsWithSameFormatting`을 호출하거나, 결합 후 결과 부분 경계를 검사하고 설정을 다시 적용하십시오. `LanguageId` 값이 다른 경우에는 교정 언어 서식이 다르기 때문에 부분이 별도로 유지됩니다.

## **FAQ**

**언어 ID가 텍스트를 번역합니까?**

아니요. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseportionformat/set_languageid/)는 맞춤법 및 문법 교정을 위한 메타데이터를 저장하며 텍스트 내용을 변경하지 않습니다. 텍스트는 별도로 번역한 뒤, 각 번역된 부분에 적절한 언어 식별자를 설정하십시오.

**교정 언어가 글꼴, 하이픈 삽입 또는 줄 바꿈을 제어합니까?**

아니요. 언어 식별자는 교정을 위한 것이며, 텍스트 렌더링 및 레이아웃은 사용 가능한 [fonts](/slides/ko/cpp/powerpoint-fonts/), 쓰기 시스템 및 텍스트 프레임 설정에 따라 달라집니다. 안정적인 렌더링을 위해 필요한 글꼴을 제공하고, [font substitution](/slides/ko/cpp/font-substitution/)을 구성하거나 프레젠테이션에 [embed fonts](/slides/ko/cpp/embedded-font/)를 포함하십시오.

**한 단락에 여러 교정 언어를 사용할 수 있습니까?**

예. 다국어 단락 예제와 같이 각 언어를 별도의 부분에 할당하면 됩니다.

**`DefaultTextLanguage`와 `LanguageId` 중 어느 것을 사용해야 합니까?**

새로 만든 텍스트에 대한 기본값을 지정하려면 [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/)를 사용하십시오. 특정 부분에 명시적인 교정 언어가 필요하거나 단락에 여러 언어가 포함된 경우에는 [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseportionformat/set_languageid/)를 사용하십시오.