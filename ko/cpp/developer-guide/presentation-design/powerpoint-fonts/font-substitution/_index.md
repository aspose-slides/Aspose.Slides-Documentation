---
title: C++ 프레젠테이션에서 폰트 대체 구성
linktitle: 폰트 대체
type: docs
weight: 70
url: /ko/cpp/font-substitution/
keywords:
- 폰트
- 대체 폰트
- 폰트 대체
- 폰트 교체
- 폰트 교체
- 대체 규칙
- 교체 규칙
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "PowerPoint 및 OpenDocument 프레젠테이션을 렌더링하거나 변환할 때 C++용 Aspose.Slides에서 폰트 대체 규칙을 구성하고 대체된 폰트를 검사합니다."
---
## **개요**

폰트 대체를 사용하면 프레젠테이션이 렌더링되거나 변환될 때 접근할 수 없는 폰트를 대신 사용할 수 있는 폰트를 Aspose.Slides가 사용할 수 있습니다. 대체는 렌더링된 출력에만 영향을 미치며 프레젠테이션 내용에 할당된 폰트를 변경하지 않습니다.

특정 폰트를 사용할 수 없을 때 사용할 폰트를 정의할 수 있으며, 렌더링 중에 Aspose.Slides가 수행할 대체를 확인할 수 있습니다. 이를 통해 설치된 폰트가 다른 환경에서도 출력이 일관되도록 할 수 있습니다.

폰트가 사용 가능하지만 전용 볼드체가 없는 경우, [전용 볼드체가 없는 글꼴 처리](/slides/ko/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)를 참조하십시오. 해당 섹션에서는 PDF 내보내기 시 영향을 받는 텍스트를 래스터화하는 방법과 텍스트 선택, 검색 및 스케일링에 미치는 결과를 설명합니다.

## **폰트 대체 가져오기**

[IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) 메서드를 사용하여 프레젠테이션이 렌더링될 때 대체될 폰트를 확인합니다. 이 메서드는 원본 및 대체 폰트 이름을 식별하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) 객체를 반환합니다.

다음 C++ 예제는 프레젠테이션에 대한 모든 폰트 대체를 나열합니다:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **선택된 슬라이드에 대한 폰트 대체 가져오기**

`System::ArrayPtr<int32_t> slides` 매개변수를 사용하는 [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) 오버로드를 사용하면 특정 슬라이드만 렌더링할 때 필요한 대체만 확인할 수 있습니다. 이는 프레젠테이션의 일부를 렌더링하거나 내보낼 때, 큰 프레젠테이션을 점진적으로 검사할 때, 사용할 수 없는 폰트에 의존하는 슬라이드를 찾을 때, 서버 또는 컨테이너용 최소 폰트 패키지를 준비할 때, 또는 관련 없는 슬라이드를 처리하지 않고 렌더링 차이를 진단할 때 유용합니다.

`slides` 배열은 1부터 시작하는 슬라이드 인덱스를 포함합니다: `1`은 첫 번째 슬라이드를 나타냅니다. 반면에 [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) 메서드는 0부터 시작하는 인덱스를 사용하므로 동일한 슬라이드는 `presentation->get_Slide(0)`으로 접근합니다. 배열을 만들 때 이 차이를 기억하여 오프 바이 원 오류를 방지하십시오.

[Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) 메서드를 통해 오버로드를 호출합니다. 선택된 슬라이드를 렌더링하는 동안 결정된 대체만 반환합니다. 각 결과는 원본 및 대체 폰트 이름을 포함하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) 객체입니다. 결과는 현재 폰트 환경, 구성된 대체 규칙, [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/)에 저장된 대체 규칙 및 [외부 로드된 폰트](/slides/ko/cpp/custom-font/)를 반영합니다.

동일한 대체가 둘 이상의 선택된 슬라이드에서 필요할 수 있습니다. 폰트 인벤토리 또는 사전점검 보고서를 만들 때 결과를 중복 제거하십시오. 다음 예제는 반환된 모든 대체를 보고한 다음 고유한 폰트 매핑의 정렬된 목록을 생성합니다:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

[IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) 인터페이스는 두 오버로드를 모두 제공합니다. 렌더링 작업의 범위에 따라 하나를 선택하십시오:

| 오버로드 | 사용 시기 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) (인수 없음) | 전체 프레젠테이션에 대한 대체가 필요할 때 |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) `System::ArrayPtr<int32_t> slides` 사용 | 선택된 범위, 점진적 검사 또는 부분 내보내기가 필요할 때 |

## **폰트 대체 규칙 설정**

소스 폰트를 사용할 수 없을 때 Aspose.Slides가 사용할 폰트를 지정하려면:

1. 프레젠테이션을 로드합니다.
2. 소스 폰트와 대체 폰트에 대한 정의를 생성합니다.
3. [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/) 조건을 사용하여 [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/)을 생성합니다.
4. 규칙을 [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/)에 추가합니다.
5. [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/) 메서드를 사용하여 컬렉션을 할당합니다.
6. 프레젠테이션을 렌더링하거나 변환합니다.

다음 C++ 예제는 `SomeRareFont`가 없을 때 `Arial`을 대체하고 첫 번째 슬라이드를 렌더링하여 결과를 확인합니다. 대체 폰트는 Aspose.Slides에서 사용 가능해야 합니다.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
전체 프레젠테이션에 사용되는 폰트를 무조건 교체하려면 [폰트 교체](/slides/ko/cpp/font-replacement/)를 참조하십시오.
{{% /alert %}}

## **수학 방정식 폰트에 대한 제한 사항**

폰트 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 폰트 선택 프로세스의 일부입니다. Aspose.Slides가 접근할 수 없는 폰트를 규칙에 지정된 사용 가능한 폰트로 교체할 수 있는 경우 일반 텍스트에 대해 작동합니다.

Office Math 방정식에는 추가 요구 사항이 있습니다. 방정식에 **Cambria Math**가 사용되는 경우 Aspose.Slides는 방정식 레이아웃을 계산하고 렌더링하기 위해 정확히 해당 폰트가 필요할 수 있습니다. **STIX Two Math**와 같은 다른 수학 폰트로 대체하는 규칙은 이 목적을 위해 **Cambria Math**를 대체할 수 없으며, 렌더링 시 여전히 **Cambria Math**가 필요하다고 보고될 수 있습니다.

이러한 프레젠테이션을 렌더링하거나 변환하려면 **Cambria Math**를 Aspose.Slides에 제공해야 합니다. 운영 체제에 설치하거나 [외부 폰트](/slides/ko/cpp/custom-font/)로 로드하십시오.

이 제한은 방정식 레이아웃에만 적용됩니다. 위에서 설명한 대체 규칙은 일반 프레젠테이션 텍스트에는 계속 적용됩니다.

## **FAQ**

**폰트 교체와 폰트 대체의 차이점은 무엇입니까?**

[Font replacement](/slides/ko/cpp/font-replacement/)은 프레젠테이션 전체에서 하나의 폰트를 다른 폰트로 의도적으로 변경합니다. 폰트 대체는 원본 폰트를 사용할 수 없을 때와 같이 구성된 조건이 충족될 때 렌더링된 출력에 사용할 폰트를 선택합니다.

**대체 규칙은 언제 적용됩니까?**

규칙은 렌더링 및 변환 중에 [폰트 선택 순서](/slides/ko/cpp/font-selection-sequence/)에 참여합니다. `WhenInaccessible`가 지정된 경우, 소스 폰트에 접근할 수 없을 때만 규칙이 사용됩니다.

**폰트가 없고 대체 규칙이 구성되지 않은 경우 어떻게 됩니까?**

Aspose.Slides는 폰트 선택 프로세스에 따라 가장 근접한 사용 가능한 폰트를 선택합니다. 결과는 런타임 환경에 설치된 폰트에 따라 달라집니다.

**대체를 피하기 위해 외부 폰트를 로드할 수 있습니까?**

예. [외부 폰트 로드](/slides/ko/cpp/custom-font/)를 통해 Aspose.Slides가 렌더링 및 변환 중에 사용할 수 있도록 할 수 있습니다.

**Aspose는 라이브러리와 함께 폰트를 배포합니까?**

아니요. 폰트 제공 및 라이선스 준수는 사용자 책임입니다.

**Windows, Linux, macOS 간에 대체 결과가 달라질 수 있습니까?**

예. 설치된 폰트와 폰트 검색 위치가 운영 체제마다 다르므로 한 머신에서 사용 가능한 폰트가 다른 머신에서는 대체가 필요할 수 있습니다.

**배치 변환에서 폰트 선택을 일관되게 하려면 어떻게 해야 합니까?**

모든 머신이나 컨테이너에 동일한 폰트 파일과 버전을 사용하고, [필요한 외부 폰트 로드](/slides/ko/cpp/custom-font/)와 라이선스가 허용되는 경우 [폰트 포함](/slides/ko/cpp/embedded-font/)을 수행하십시오. 또한 내보내기 전에 [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/)를 호출하여 예상치 못한 대체를 식별할 수 있습니다.