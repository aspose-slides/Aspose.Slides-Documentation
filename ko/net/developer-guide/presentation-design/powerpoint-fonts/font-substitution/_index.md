---
title: ".NET에서 프레젠테이션의 폰트 대체 구성"
linktitle: "폰트 대체"
type: docs
weight: 70
url: /ko/net/font-substitution/
keywords:
- 폰트
- 대체 폰트
- 폰트 대체
- 폰트 교체
- 폰트 교체
- 대체 규칙
- 교체 규칙
- 파워포인트
- 오픈문서
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 PowerPoint 및 OpenDocument 프레젠테이션을 렌더링하거나 변환할 때 폰트 대체 규칙을 구성하고 대체된 폰트를 검사합니다."
---
## **개요**

폰트 대체를 사용하면 Aspose.Slides가 프레젠테이션을 렌더링하거나 변환할 때 접근할 수 없는 폰트를 사용할 수 있는 폰트로 대신 사용합니다. 대체는 렌더링 결과에만 영향을 미치며 프레젠테이션 내용에 할당된 폰트를 변경하지는 않습니다.

특정 폰트를 사용할 수 없을 때 사용할 폰트를 정의할 수 있으며, Aspose.Slides가 렌더링 중에 수행할 대체를 확인할 수 있습니다. 이를 통해 서로 다른 설치된 폰트를 가진 환경에서도 출력이 일관되게 유지됩니다.

## **폰트 대체 가져오기**

[IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) 메서드를 사용하여 프레젠테이션이 렌더링될 때 어떤 폰트가 대체되는지 확인할 수 있습니다. 이 메서드는 원본 폰트와 대체 폰트 이름을 식별하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) 객체를 반환합니다.

다음 C# 예제는 프레젠테이션의 모든 폰트 대체를 나열합니다:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **선택된 슬라이드에 대한 폰트 대체 가져오기**

`int[] slides` 인수를 사용하는 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) 오버로드를 호출하면 특정 슬라이드에만 필요한 대체를 검사할 수 있습니다. 이는 프레젠테이션의 일부를 렌더링하거나 내보낼 때, 대규모 프레젠테이션을 점진적으로 확인할 때, 사용 불가능한 폰트에 의존하는 슬라이드를 찾을 때, 서버 또는 컨테이너용 최소 폰트 패키지를 준비할 때, 또는 관련 없는 슬라이드를 처리하지 않고 렌더링 차이를 진단할 때 유용합니다.

`slides` 배열은 1부터 시작하는 슬라이드 인덱스를 포함합니다: `1` 은 첫 번째 슬라이드를 나타냅니다. 반면에 [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) 컬렉션 인덱서는 0부터 시작하므로 동일한 슬라이드는 `presentation.Slides[0]` 로 접근합니다. 배열을 만들 때 이 차이를 염두에 두어 1씩 차이 나는 실수를 방지하십시오.

[Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) 속성을 통해 오버로드를 호출합니다. 선택한 슬라이드를 렌더링하는 동안 결정된 대체만 반환합니다. 각 결과는 원본 및 대체 폰트 이름을 포함하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) 객체이며, 현재 폰트 환경 및 [외부 로드된 폰트](/slides/ko/net/custom-font/)를 반영합니다. [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/)에 저장된 대체 규칙은 렌더링 결과에 영향을 주지만 결과에는 나타나지 않습니다.

동일한 대체가 여러 선택 슬라이드에서 필요할 수 있습니다. 폰트 인벤토리 또는 프리플라이트 보고서를 만들 때 결과를 중복 제거하십시오. 다음 예제는 반환된 모든 대체를 보고한 뒤 고유한 폰트 매핑의 정렬된 목록을 생성합니다:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

[IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) 인터페이스는 두 오버로드를 모두 제공합니다. 렌더링 작업의 범위에 따라 선택하십시오:

| 오버로드 | 사용 상황 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) (인자 없음) | 전체 프레젠테이션에 대한 대체가 필요할 때 |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | 선택된 범위, 점진적 검사 또는 부분 내보내기에 대한 대체가 필요할 때 |

## **폰트 대체 규칙 설정**

원본 폰트를 사용할 수 없을 때 Aspose.Slides가 사용할 폰트를 지정하려면:

1. 프레젠테이션을 로드합니다.
2. 원본 폰트와 대체 폰트에 대한 정의를 만듭니다.
3. [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/) 조건을 사용하여 [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/)을 생성합니다.
4. 해당 규칙을 [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/)에 추가합니다.
5. 컬렉션을 [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/) 속성에 할당합니다.
6. 프레젠테이션을 렌더링하거나 변환합니다.

다음 C# 예제는 `SomeRareFont`를 사용할 수 없을 때 `Arial`을 대신 사용하고, 첫 번째 슬라이드를 렌더링하여 결과를 확인합니다. 대체 폰트는 Aspose.Slides에서 사용할 수 있어야 합니다.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="참고" %}}
프레젠테이션 전체에 사용되는 폰트를 무조건 변경하려면 [Font Replacement](/slides/ko/net/font-replacement/)을 참조하십시오.
{{% /alert %}}

## **수식 폰트에 대한 제한 사항**

폰트 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 폰트 선택 프로세스의 일부입니다. 접근할 수 없는 폰트를 규칙에서 지정한 사용 가능한 폰트로 교체할 수 있는 일반 텍스트에는 적용됩니다.

Office Math 수식에는 추가 요구 사항이 있습니다. 수식이 **Cambria Math**을 사용하면 Aspose.Slides는 레이아웃을 계산하고 렌더링하기 위해 정확히 해당 폰트가 필요할 수 있습니다. **STIX Two Math**와 같은 다른 수학 폰트로 대체하는 규칙은 이 목적을 대신할 수 없으며, 렌더링 시 여전히 **Cambria Math**이 필요하다고 보고될 수 있습니다.

이러한 프레젠테이션을 렌더링하거나 변환하려면 **Cambria Math**을 Aspose.Slides에서 사용할 수 있게 하십시오. 운영 체제에 설치하거나 [외부 폰트](/slides/ko/net/custom-font/)로 로드하십시오.

이 제한은 수식 레이아웃에만 적용됩니다. 위에서 설명한 대체 규칙은 일반 프레젠테이션 텍스트에 여전히 적용됩니다.

## **FAQ**

**폰트 교체와 폰트 대체의 차이점은 무엇인가요?**

[Font replacement](/slides/ko/net/font-replacement/)은 프레젠테이션 전체에서 하나의 폰트를 다른 폰트로 의도적으로 변경합니다. 폰트 대체는 원본 폰트를 사용할 수 없을 때와 같이 구성된 조건이 충족되면 렌더링 결과에 사용할 폰트를 선택합니다.

**대체 규칙은 언제 적용됩니까?**

규칙은 렌더링 및 변환 중에 [폰트 선택 순서](/slides/ko/net/font-selection-sequence/)에 참여합니다. `WhenInaccessible` 조건을 사용하면 Aspose.Slides가 원본 폰트에 접근하지 못할 때만 규칙이 적용됩니다.

**폰트가 없고 대체 규칙이 구성되지 않은 경우 어떻게 됩니까?**

Aspose.Slides는 폰트 선택 프로세스에 따라 가장 가까운 사용 가능한 폰트를 선택합니다. 결과는 런타임 환경에 설치된 폰트에 따라 달라집니다.

**외부 폰트를 로드해서 대체를 피할 수 있나요?**

예. [외부 폰트를 로드](/slides/ko/net/custom-font/)하면 Aspose.Slides가 렌더링 및 변환 중에 해당 폰트를 사용할 수 있습니다.

**Aspose가 라이브러리와 함께 폰트를 배포합니까?**

아니오. 폰트와 해당 라이선스는 고객이 직접 제공해야 합니다.

**Windows, Linux, macOS 간에 대체 결과가 달라질 수 있나요?**

예. 운영 체제마다 설치된 폰트와 폰트 검색 위치가 다르므로 한 머신에서 사용 가능한 폰트가 다른 머신에서는 대체가 필요할 수 있습니다.

**배치 변환 시 폰트 선택을 일관되게 유지하려면 어떻게 해야 하나요?**

모든 머신 또는 컨테이너에 동일한 폰트 파일 및 버전을 사용하고, [필요한 외부 폰트를 로드](/slides/ko/net/custom-font/)하며, 라이선스가 허용되는 경우 [폰트를 포함](/slides/ko/net/embedded-font/)하십시오. 또한 내보내기 전에 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/)을 호출하여 예상치 못한 대체를 식별할 수 있습니다.