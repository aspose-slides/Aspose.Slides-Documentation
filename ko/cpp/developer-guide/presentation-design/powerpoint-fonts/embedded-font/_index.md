---
title: C++에서 프레젠테이션에 폰트 임베드
linktitle: 임베드된 폰트
type: docs
weight: 40
url: /ko/cpp/embedded-font/
keywords:
- 폰트 추가
- 폰트 임베드
- 폰트 임베딩
- 임베드된 폰트 가져오기
- 임베드된 폰트 추가
- 임베드된 폰트 제거
- 임베드된 폰트 압축
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint에서 임베드된 폰트를 관리합니다. 폰트를 추가, 가져오기, 제거 및 압축하여 텍스트 모양을 유지하고 파일 크기를 줄입니다."
---
## **소개**

임베드된 폰트는 글꼴 데이터를 PowerPoint 프레젠테이션 안에 저장합니다. 뷰어가 임베드된 폰트를 지원하면, 대상 시스템에 해당 폰트가 설치되지 않았더라도 해당 폰트를 사용해 텍스트를 표시할 수 있습니다. 이는 줄 바꿈, 텍스트 간격 및 슬라이드 레이아웃을 유지하는 데 도움이 됩니다.

Aspose.Slides for C++는 [Presentation::get_FontsManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_fontsmanager/) 메서드를 통해 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 에서 임베드된 폰트를 검색, 추가 및 제거할 수 있습니다. 또한 프레젠테이션에서 사용되지 않는 문자들을 제거하여 임베드된 폰트 데이터 크기를 줄일 수 있습니다.

아래 예제는 PPTX 파일을 대상으로 합니다. 폰트를 임베드하기 전에 해당 폰트 데이터가 Aspose.Slides에서 사용 가능하고, 라이선스가 임베드를 허용하는지 확인하십시오.

## **임베드된 폰트 가져오기 및 제거**

[IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) 를 사용해 프레젠테이션에 저장된 폰트 목록을 확인합니다. 폰트를 하나 제거하려면 해당 목록에서 폰트를 선택한 뒤 [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontsmanager/removeembeddedfont/) 에 전달하고, 프레젠테이션을 저장하면 됩니다.

다음 예제는 `EmbeddedFonts.pptx` 에 포함된 임베드된 폰트를 나열하고, Calibri가 존재하면 제거합니다:

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

임베드된 폰트를 제거하면 저장된 폰트 데이터가 삭제될 뿐, 텍스트에 할당된 폰트 자체는 변경되지 않습니다. 해당 폰트가 대상 시스템에 설치되어 있으면 텍스트는 계속 그 폰트를 사용합니다. 그렇지 않을 경우 렌더링 시 [font substitution](/slides/ko/cpp/font-substitution/)이 발생할 수 있으며, 이는 레이아웃에 영향을 줄 수 있습니다.

## **폰트 데이터 및 임베드 권한 검사**

임베드하기 전에 폰트를 검사하려면 [IFontsManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontsmanager/) 인터페이스를 사용합니다. [IFontsManager::GetFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontsmanager/getfonts/) 를 호출해 프레젠테이션에서 사용된 폰트를 가져옵니다. 각 폰트에 대해 [IFontData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontdata/) 객체와 필요한 [FontStyleType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontstyletype/) 값을 전달해 [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontsmanager/getfontbytes/) 를 호출합니다. 이 메서드는 해당 스타일에 대한 바이너리 데이터를 반환하거나, 요청한 폰트나 스타일이 없을 경우 `nullptr` 를 반환합니다. `nullptr` 결과를 [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/) 에 전달하면 안 됩니다. 해당 메서드는 바이트 배열이 필요합니다.

[EmbeddingLevel](https://reference.aspose.com/slides/ko/cpp/aspose.slides/embeddinglevel/) 은 폰트에 저장된 임베드 제한을 보고하는 플래그 열거형입니다:

- `Installable` 은 폰트 라이선스가 허용하는 한 임베드 및 다른 시스템에 영구 설치를 허용합니다.
- `Restricted` 은 단일 사용 권한 플래그인 경우 폰트 소유자의 허가 없이는 임베드를 금지합니다.
- `PreviewPrint` 은 보기 및 인쇄를 위한 일시적 사용을 허용하지만, 해당 문서는 읽기 전용이어야 합니다.
- `Editable` 은 일시적 사용을 허용하고 문서를 편집·저장할 수 있게 합니다.
- `NoSubsetting` 은 추가 제한으로, 글리프 서브셋만 임베드하는 것을 금지합니다. 이 플래그가 있으면 모든 문자를 임베드해야 합니다.
- `BitmapOnly` 은 추가 제한으로, 윤곽 데이터가 아닌 비트맵 스트라이크만 임베드할 수 있게 합니다. 폰트에 비트맵 스트라이크가 없으면 임베드할 수 없습니다.

첫 네 값은 사용 권한을 나타내며, `NoSubsetting` 와 `BitmapOnly` 는 이들과 조합될 수 있습니다. 비트 연산을 사용해 수정자를 확인하십시오. `Installable` 이 0이므로 사용 권한 비트를 마스크하고 결과를 `Installable` 과 비교합니다. 현재 폰트는 최대 하나의 사용 권한 비트를 설정해야 합니다. 여러 비트를 설정한 오래된 폰트와 호환성을 위해 아래 헬퍼는 가장 제한이 적은 권한을 선택합니다: `Editable` → `PreviewPrint` → `Restricted`.

다음 예제는 `GetFonts` 로 반환된 각 폰트에 대해 일반, 굵게, 기울임, 굵게‑기울임 스타일을 검사합니다. 사용 불가능한 스타일, 제한된 폰트, 비트맵 전용 폰트, 미리 보기·인쇄 전용 폰트(출력은 편집 가능하게 유지) 및 이미 임베드된 폰트는 건너뜁니다. 사용 가능한 스타일에 `NoSubsetting` 플래그가 있으면 해당 폰트 패밀리의 모든 문자를 임베드합니다.

```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

이 검사는 각 폰트 파일에 인코딩된 제한 정보를 보고합니다. 라이선스를 부여하거나, 폰트를 합법적으로 입수했음을 증명하거나, 임베드된 복사본을 배포하기 전에 폰트 라이선스 계약을 확인해야 함을 대체하지 않습니다.

## **임베드된 폰트 추가**

[IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontsmanager/addembeddedfont/) 를 사용해 폰트를 임베드합니다. 이 메서드의 오버로드는 [IFontData](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontdata/) 객체 또는 폰트 데이터를 포함한 바이트 배열을 받습니다. [EmbedFontCharacters](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/embedfontcharacters/) 열거형은 포함할 문자 범위를 제어합니다:

- [All](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/embedfontcharacters/) 은 폰트의 모든 문자를 임베드합니다. 수신자가 프레젠테이션을 편집하고 새 텍스트를 입력해야 할 경우 이 옵션을 사용하십시오.
- [OnlyUsed](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/embedfontcharacters/) 은 파일 크기를 줄이기 위해 프레젠테이션에서 실제 사용된 문자만 임베드합니다. 주로 보기 전용인 최종 프레젠테이션에 이 옵션을 선택하십시오.

다음 예제는 `Fonts.pptx` 에 사용된 폰트를 [IFontsManager::GetFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontsmanager/getfonts/) 로 가져와 아직 임베드되지 않은 폰트를 임베드합니다. 추가할 폰트는 코드를 실행하는 머신에 존재해야 합니다. 기존에 임베드된 폰트는 현재 문자 세트를 유지합니다.

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **임베드된 폰트 압축**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) 은 사용되지 않은 문자를 제거하여 임베드된 폰트 데이터를 줄입니다. 이미 임베드된 폰트에 대해서만 작동하므로, 감소량은 프레젠테이션에 포함된 사용되지 않은 폰트 데이터 양에 따라 달라집니다.

다음 예제는 `EmbeddedFonts.pptx` 의 폰트를 압축하고 결과를 별도 파일로 저장합니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

수신자가 나중에 텍스트를 추가해야 할 가능성이 있으면 원본 파일을 보관하십시오. 압축 과정에서 제거된 문자는 임베드된 폰트에서 더 이상 사용할 수 없습니다(원래 모든 문자를 임베드했더라도).

## **FAQ**

**임베드된 폰트가 렌더링 시 여전히 대체되는지 어떻게 확인할 수 있나요?**

프레젠테이션을 렌더링하는 환경에서 [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifontsmanager/getsubstitutions/) 를 호출하면 Aspose.Slides가 교체할 폰트를 확인할 수 있습니다. 또한 [font substitution](/slides/ko/cpp/font-substitution/) 설정 및 [font fallback](/slides/ko/cpp/fallback-font/) 규칙을 확인하십시오. 폰트 대체는 누락된 문자를 처리하므로, 폰트 자체에 없는 문자는 임베드해도 해결되지 않습니다.

**Arial이나 Calibri와 같은 일반 폰트를 임베드해야 하나요?**

대상 환경을 기준으로 결정하십시오. 필요한 폰트가 프레젠테이션을 여는 모든 머신에 이미 설치되어 있다면 임베드가 파일 크기를 불필요하게 늘릴 수 있습니다. 반대로 수신자나 서버에 해당 폰트가 없을 경우, 라이선스가 허용한다면 임베드가 의도된 외관을 유지하는 데 도움이 됩니다.