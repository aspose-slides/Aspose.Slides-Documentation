---
title: C++에서 스크립트별 테마 글꼴 관리
linktitle: 스크립트별 테마 글꼴
type: docs
weight: 15
url: /ko/cpp/script-specific-font-mappings/
keywords:
- 스크립트별 글꼴
- 테마 글꼴 매핑
- 다국어 프레젠테이션
- 작성 시스템
- 시릴릭 글꼴
- 아랍어 글꼴
- 일본어 글꼴
- 그루지야어 글꼴
- 타아나 글꼴
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 테마에서 스크립트별 글꼴 매핑을 검사하고, 추가하고, 교체하고, 제거합니다."
---
## **개요**

프레젠테이션 테마는 서로 다른 쓰기 시스템에 대해 서로 다른 글꼴 패밀리를 선택할 수 있습니다. 이를 통해 테마 글꼴을 사용하면서도 다국어 텍스트가 시릴릭, 아랍어, 일본어, 그루지야어, 타아나 등 다양한 스크립트에 적합한 글꼴을 사용하면서 하나의 조화된 글꼴 스키마를 따를 수 있습니다.

테마의 [IFontScheme](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/ifontscheme/)에는 일반적으로 제목에 사용되는 주요 글꼴 컬렉션과 본문에 사용되는 부차적 글꼴 컬렉션이 포함됩니다. 라틴 및 동아시아 글꼴 속성에 추가로, 두 컬렉션 모두 [IFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifonts/) 인터페이스를 통해 쓰기 시스템 태그와 글꼴 패밀리 이름 사이의 매핑을 노출합니다.

이 문서는 프레젠테이션 마스터 테마에서 해당 매핑을 검사하고 수정하는 방법을 보여주며, 변경 사항이 저장‑재로드 사이클에서도 유지되는지 확인하는 방법을 설명합니다.

## **스크립트 태그 이해하기**

스크립트 글꼴 메서드는 네 글자 BCP 47 스크립트 서브태그를 사용하여 쓰기 시스템을 식별합니다. 일반적인 값은 다음과 같습니다:

| 스크립트 태그 | 작성 시스템 |
|---|---|
| `Cyrl` | 시릴릭 |
| `Arab` | 아랍어 |
| `Hans` | 간체 중국어 |
| `Jpan` | 일본어 |
| `Geor` | 그루지야어 |
| `Thaa` | 타아나 |

이 매핑은 테마 글꼴 스키마에 속하며 개별 텍스트 부분에는 적용되지 않습니다. 프레젠테이션은 주요 컬렉션과 부차적 컬렉션에 대해 서로 다른 매핑을 정의할 수 있으며, 일부 스크립트에 대한 매핑을 생략할 수도 있습니다.

## **스크립트 글꼴 매핑 접근 및 검사**

[Presentation::get_MasterTheme](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_mastertheme/)을 사용하여 프레젠테이션 수준의 테마에 접근합니다. [FontScheme::get_Major](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/fontscheme/get_major/) 및 [FontScheme::get_Minor](https://reference.aspose.com/slides/ko/cpp/aspose.slides.theme/fontscheme/get_minor/) 메서드는 두 개의 [IFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifonts/) 컬렉션을 반환합니다.

[Fonts::GetScriptFontMap](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fonts/getscriptfontmap/)을 호출하면 컬렉션의 모든 매핑을 가져올 수 있습니다. 특정 쓰기 시스템을 조회하려면 해당 스크립트 태그와 함께 [Fonts::GetScriptFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fonts/getscriptfont/)를 호출합니다. `GetScriptFont`는 해당 컬렉션에 요청된 매핑이 정의되지 않은 경우 null 문자열을 반환합니다.

## **매핑 수정 및 지속성 확인**

[Fonts::SetScriptFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fonts/setscriptfont/)을 사용하여 매핑을 생성하거나 현재 글꼴 패밀리를 교체합니다. [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fonts/removescriptfont/)을 사용하여 매핑을 제거합니다.

다음은 기존 주요·부차 매핑을 모두 읽고, 일본어 주요 글꼴을 조회한 뒤, 시릴릭 주요 글꼴을 변경하고, 타아나 부차 매핑을 제거한 뒤 프레젠테이션을 저장하고 다시 열어 두 변경 사항을 검증하는 전체 예제입니다. 제거 단계를 초기 테마와 무관하게 만들기 위해, 예제는 타아나 매핑이 아직 정의되지 않은 경우에만 매핑을 생성합니다.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

검증은 일반 조회와 동일한 null‑string 동작을 사용합니다: 제거가 저장된 후 `GetScriptFont(u"Thaa")`는 부차 컬렉션에 대해 null 문자열을 반환합니다.

## **테마 매핑과 기타 글꼴 설정 구분하기**

스크립트‑특정 테마 매핑은 글꼴 선택에 참여하지만, 직접 텍스트 서식 지정, 대치 및 폰트 폴백과는 다른 문제를 해결합니다:

| 메커니즘 | 목적 | 테마 매핑 변경 시 효과 |
|---|---|---|
| 스크립트‑특정 테마 글꼴 매핑 | 쓰기 시스템에 대한 주요 또는 부차 테마 글꼴 선택 | 해당 테마 글꼴을 계속 사용하는 텍스트는 새 매핑된 패밀리로 해결될 수 있음 |
| 텍스트 부분에 명시적으로 할당된 글꼴 | 해당 부분에 요청된 글꼴 패밀리를 직접 지정해 테마에 의존하지 않음 | 직접 서식이 테마 선택을 우선하므로 해당 부분은 변하지 않을 수 있음 |
| 글꼴 대치 | 요청된 글꼴이 없거나 대치 규칙이 적용될 때 다른 글꼴로 교체 | 글꼴이 요청된 후에 작동하며, 테마의 스크립트 매핑을 재정의하지 않음 |
| 글꼴 폴백 | 선택된 글꼴에 포함되지 않은 글리프를 제공, 주로 특정 유니코드 범위에 사용 | 누락된 글리프를 채우지만 저장된 테마 매핑을 변경하지 않음 |

마지막 두 메커니즘에 대한 자세한 내용은 [Font Substitution](/slides/ko/cpp/font-substitution/) 및 [Fallback Fonts](/slides/ko/cpp/fallback-font/)을 참조하십시오.

[Presentation::get_MasterTheme](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_mastertheme/)에서 매핑을 변경하면 해당 테마에 여전히 의존하는 효과적인 서식에만 영향을 줍니다. 텍스트가 마스터, 레이아웃 또는 슬라이드에서 테마 오버라이드를 상속하거나 명시적으로 할당된 글꼴을 사용하는 경우, 보이는 결과가 프레젠테이션‑수준 매핑을 따르지 않을 수 있습니다. 이러한 경우 해당 레벨을 검사하십시오.

## **매핑된 글꼴 사용 가능 상태 확인 및 결과 검증**

스크립트 매핑은 글꼴 패밀리 이름만 저장하며, 해당 글꼴 파일을 설치하거나 로드하지는 않습니다. 일관된 렌더링 및 내보내기를 위해 매핑된 모든 글꼴은 환경에 설치되어 있거나 [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsloader/loadexternalfonts/) 또는 [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/)와 같은 사용자 지정 소스를 통해 Aspose.Slides에 제공되어야 합니다. 사용 가능한 로드 옵션은 [Custom Fonts](/slides/ko/cpp/custom-font/)를 참고하십시오.

저장된 매핑을 검증하는 것은 테마 정의가 보존되었는지만 확인합니다. 글꼴이 실제로 사용 가능한지, 모든 필요한 글리프를 포함하는지, 의도한 레이아웃을 생성하는지는 증명하지 못합니다. 각 필수 쓰기 시스템에 대해 대표 텍스트를 이미지 또는 PDF로 렌더링하고 출력을 검사하십시오. 이렇게 하면 누락된 글꼴, 불완전한 글리프 커버리지, 폴백 동작 및 레이아웃 변경을 프레젠테이션 배포 전에 발견할 수 있습니다. 렌더링 및 내보내기 예제는 [Convert PowerPoint Presentations](/slides/ko/cpp/convert-powerpoint/)를 참조하십시오.

## **FAQ**

**`GetScriptFont`가 매핑되지 않은 스크립트에 대해 반환하는 값은 무엇입니까?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fonts/getscriptfont/)은 요청된 스크립트 매핑이 해당 주요 또는 부차 글꼴 컬렉션에 정의되지 않은 경우 null 문자열을 반환합니다.

**`SetScriptFont`는 이미 존재하는 스크립트에 대해 두 번째 매핑을 추가합니까?**

아니오. [Fonts::SetScriptFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fonts/setscriptfont/)은 매핑이 없을 때 생성하고, 동일한 스크립트 태그가 이미 존재하면 매핑된 글꼴 패밀리를 교체합니다.

**왜 테마 매핑을 변경했는데 일부 텍스트가 바뀌지 않았습니까?**

텍스트에 명시적으로 할당된 글꼴이 있거나, 오버라이드를 통해 다른 테마를 상속했거나, 렌더링 중 대치 또는 폴백에 의해 영향을 받았을 수 있습니다. 프레젠테이션‑수준 스크립트 매핑은 해당 테마 글꼴 컬렉션에 여전히 의존하는 텍스트에만 적용됩니다.

**저장 후 재열기가 다국어 출력을 검증하기에 충분합니까?**

아니오. 재열기는 테마 데이터의 지속성을 확인하지만, 각 쓰기 시스템에 대해 대표 텍스트를 렌더링하여 매핑된 글꼴이 실제로 사용 가능하고 필요한 글리프를 포함하는지 확인해야 합니다.