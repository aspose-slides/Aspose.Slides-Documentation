---
title: .NET에서 프레젠테이션의 글꼴 대체 구성
linktitle: 글꼴 대체
type: docs
weight: 70
url: /ko/net/font-substitution/
keywords:
- 글꼴
- 대체 글꼴
- 글꼴 대체
- 글꼴 교체
- 글꼴 교체
- 대체 규칙
- 교체 규칙
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "PowerPoint 및 OpenDocument 프레젠테이션을 렌더링하거나 변환할 때 Aspose.Slides for .NET에서 글꼴 대체 규칙을 구성하고 대체된 글꼴을 검사합니다."
---
## **개요**

Font substitution을 사용하면 Aspose.Slides가 프레젠테이션이 렌더링되거나 변환될 때 접근할 수 없는 글꼴 대신 사용 가능한 글꼴을 사용할 수 있습니다. 대체는 렌더링된 출력에만 영향을 미치며, 프레젠테이션 콘텐츠에 지정된 글꼴은 변경되지 않습니다.

특정 글꼴을 사용할 수 없을 때 사용할 글꼴을 정의할 수 있으며, Aspose.Slides가 렌더링 중에 수행할 대체를 검사할 수 있습니다. 이를 통해 서로 다른 글꼴이 설치된 환경에서도 출력 결과를 일관되게 유지할 수 있습니다.

## **글꼴 대체 가져오기**

[IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsmanager/getsubstitutions/) 메서드를 사용하여 프레젠테이션이 렌더링될 때 어떤 글꼴이 대체되는지 확인할 수 있습니다. 이 메서드는 원본 및 대체된 글꼴 이름을 식별하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsubstitutioninfo/) 객체를 반환합니다.

다음 C# 예제는 프레젠테이션에 대한 모든 글꼴 대체를 나열합니다:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **선택한 슬라이드에 대한 글꼴 대체 가져오기**

[int[] slides] 인수를 사용한 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsmanager/getsubstitutions/) 오버로드를 사용하면 특정 슬라이드만 렌더링할 때 필요한 대체를 검사할 수 있습니다. 이는 프레젠테이션의 일부를 렌더링하거나 내보낼 때, 대형 프레젠테이션을 점진적으로 검사할 때, 사용 불가능한 글꼴에 의존하는 슬라이드를 찾아낼 때, 서버나 컨테이너용 최소 글꼴 패키지를 준비할 때, 또는 관련 없는 슬라이드를 처리하지 않고 렌더링 차이를 진단할 때 유용합니다.

`slides` 배열은 1부터 시작하는 슬라이드 인덱스를 포함합니다: `1`은 첫 번째 슬라이드를 나타냅니다. 반면 [Presentation.Slides](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/slides/ko/) 컬렉션 인덱서는 0부터 시작하므로 같은 슬라이드는 `presentation.Slides[0]`으로 접근합니다. 배열을 만들 때 이 차이를 기억하여 오프바이원 오류를 방지하십시오.

[Presentation.FontsManager](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/fontsmanager/) 속성을 통해 오버로드를 호출합니다. 선택한 슬라이드를 렌더링하면서 결정된 대체만 반환합니다. 각 결과는 원본 및 대체된 글꼴 이름을 포함하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsubstitutioninfo/) 객체입니다. 결과는 현재 글꼴 환경, 구성된 대체 규칙, [IFontSubstRuleCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsubstrulecollection/)에 저장된 대체 규칙, 그리고 [externally loaded fonts](/slides/ko/net/custom-font/)을 반영합니다.

동일한 대체가 여러 선택된 슬라이드에서 필요할 수 있습니다. 글꼴 인벤토리나 사전 검사 보고서를 만들 때 결과를 중복 제거하십시오. 다음 예제는 반환된 모든 대체를 보고한 다음 고유한 글꼴 매핑의 정렬된 목록을 생성합니다:

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

[IFontsManager](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsmanager/) 인터페이스는 두 오버로드를 모두 제공합니다. 렌더링 작업의 범위에 따라 선택하십시오:

| 오버로드 | 사용 상황 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsmanager/getsubstitutions/) (인수 없음) | 전체 프레젠테이션에 대한 대체가 필요할 때 |
| [GetSubstitutions](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsmanager/getsubstitutions/) `int[] slides` 사용 | 선택된 범위, 점진적 검사 또는 부분 내보내기에 대한 대체가 필요할 때 |

## **글꼴 대체 규칙 설정**

소스 글꼴을 사용할 수 없을 때 Aspose.Slides가 사용할 글꼴을 지정하려면:

1. 프레젠테이션을 로드합니다.  
2. 소스 및 대체 글꼴에 대한 정의를 생성합니다.  
3. [WhenInaccessible](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsubstcondition/) 조건을 사용하여 [FontSubstRule](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsubstrule/)을 생성합니다.  
4. 규칙을 [FontSubstRuleCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsubstrulecollection/)에 추가합니다.  
5. 컬렉션을 [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/fontsubstrulelist/) 속성에 할당합니다.  
6. 프레젠테이션을 렌더링하거나 변환합니다.

다음 C# 예제는 `SomeRareFont`를 사용할 수 없을 때 `Arial`을 대체 글꼴로 지정하고, 첫 번째 슬라이드를 렌더링하여 결과를 확인합니다. 대체 글꼴은 Aspose.Slides에서 사용할 수 있어야 합니다.

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
프레젠테이션 전체에 사용되는 글꼴을 무조건 변경하려면 [Font Replacement](/slides/ko/net/font-replacement/)을 참조하십시오.
{{% /alert %}}

## **수식 글꼴 제한 사항**

글꼴 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 글꼴 선택 프로세스의 일부입니다. 규칙은 Aspose.Slides가 접근할 수 없는 글꼴을 규칙으로 지정된 사용 가능한 글꼴로 교체할 수 있을 때 일반 텍스트에 대해 작동합니다.

Office Math 방정식에는 추가 요구 사항이 있습니다. 방정식에 **Cambria Math**가 사용된 경우, Aspose.Slides는 방정식 레이아웃을 계산하고 렌더링하기 위해 정확히 해당 글꼴이 필요할 수 있습니다. **STIX Two Math**와 같은 다른 수식 글꼴로 대체하는 규칙은 **Cambria Math**를 대신할 수 없으며, 여전히 **Cambria Math**가 필요하다는 오류가 발생할 수 있습니다.

이러한 프레젠테이션을 렌더링하거나 변환하려면 **Cambria Math**를 Aspose.Slides에서 사용할 수 있게 하십시오. 운영 체제에 설치하거나 [external font](/slides/ko/net/custom-font/)로 로드하십시오.

이 제한은 방정식 레이아웃에만 적용됩니다. 위에서 설명한 대체 규칙은 일반 프레젠테이션 텍스트에는 계속 적용됩니다.

## **FAQ**

**[Font replacement](/slides/ko/net/font-replacement/)와 글꼴 대체의 차이점은 무엇인가요?**  
[Font replacement](/slides/ko/net/font-replacement/)는 프레젠테이션 전체에서 한 글꼴을 다른 글꼴로 의도적으로 변경합니다. 글꼴 대체는 원본 글꼴이 사용할 수 없을 때와 같이 구성된 조건이 충족될 경우 렌더링된 출력에 사용할 글꼴을 선택합니다.

**대체 규칙은 언제 적용되나요?**  
규칙은 렌더링 및 변환 중에 [font selection sequence](/slides/ko/net/font-selection-sequence/)에 참여합니다. `WhenInaccessible`를 사용하면 Aspose.Slides가 소스 글꼴에 접근할 수 없을 때만 규칙이 적용됩니다.

**글꼴이 없고 대체 규칙이 설정되지 않은 경우 어떻게 되나요?**  
Aspose.Slides는 글꼴 선택 프로세스에 따라 가장 가까운 사용 가능한 글꼴을 선택합니다. 결과는 런타임 환경에 설치된 글꼴에 따라 달라집니다.

**외부 글꼴을 로드하여 대체를 방지할 수 있나요?**  
예, [external fonts](/slides/ko/net/custom-font/)를 로드하면 Aspose.Slides가 렌더링 및 변환 중에 해당 글꼴을 사용할 수 있습니다.

**Aspose는 라이브러리와 함께 글꼴을 배포하나요?**  
아니요. 글꼴 제공 및 라이선스 준수는 사용자 책임입니다.

**Windows, Linux, macOS 간에 대체 결과가 다를 수 있나요?**  
예, 운영 체제마다 설치된 글꼴 및 검색 위치가 다르므로 한 머신에서 사용 가능한 글꼴이 다른 머신에서는 대체가 필요할 수 있습니다.

**배치 변환에서 글꼴 선택을 일관되게 하려면 어떻게 해야 하나요?**  
모든 머신이나 컨테이너에 동일한 글꼴 파일과 버전을 사용하고, 필요 시 [required external fonts](/slides/ko/net/custom-font/)를 로드하며, 라이선스가 허용되는 경우 [embed fonts](/slides/ko/net/embedded-font/)를 사용하십시오. 또한 내보내기 전에 [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ko/net/aspose.slides/ifontsmanager/getsubstitutions/)를 호출하여 예상치 못한 대체를 식별할 수 있습니다.