---
title: JavaScript를 사용한 프레젠테이션의 폰트 대체 구성
linktitle: 폰트 대체
type: docs
weight: 70
url: /ko/nodejs-java/font-substitution/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint 및 OpenDocument 프레젠테이션을 렌더링하거나 변환할 때 Java를 통해 Node.js용 Aspose.Slides에서 폰트 대체 규칙을 구성하고 대체된 폰트를 검사합니다."
---
## **개요**

폰트 대체는 Aspose.Slides가 프레젠테이션이 렌더링되거나 변환될 때 접근할 수 없는 폰트를 대신 사용할 수 있는 폰트를 사용하도록 합니다. 대체는 렌더링된 출력에만 영향을 미치며, 프레젠테이션 콘텐츠에 할당된 폰트를 변경하지 않습니다.

특정 폰트를 사용할 수 없을 때 사용할 폰트를 정의할 수 있으며, 렌더링 중 Aspose.Slides가 수행하는 대체를 검사할 수 있습니다. 이는 설치된 폰트가 다른 환경에서도 출력 일관성을 유지하는 데 도움이 됩니다.

## **폰트 대체 가져오기**

프레젠테이션이 렌더링될 때 대체될 폰트를 결정하려면 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 메서드를 사용합니다. 이 메서드는 원본 및 대체 폰트 이름을 식별하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsubstitutioninfo/) 객체를 반환합니다.

다음 JavaScript 예제는 프레젠테이션에 대해 모든 폰트 대체를 나열합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **선택된 슬라이드에 대한 폰트 대체 가져오기**

특정 슬라이드를 렌더링하는 데 필요한 대체만 검사하려면 슬라이드 인덱스 배열과 함께 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 오버로드를 사용합니다. 이는 프레젠테이션의 일부만 렌더링하거나 내보낼 때, 대형 프레젠테이션을 단계적으로 확인할 때, 사용 불가능한 폰트에 의존하는 슬라이드를 찾을 때, 서버나 컨테이너에 최소 폰트 패키지를 준비할 때, 관련 없는 슬라이드를 처리하지 않고 렌더링 차이를 진단할 때 유용합니다.

오버로드는 Java 원시형 `int[]`를 기대합니다. `java.newArray("int", [...])`로 생성합니다; 일반 JavaScript 배열은 `Integer[]`로 변환되어 이 오버로드와 일치하지 않습니다.

배열에는 1부터 시작하는 슬라이드 인덱스가 포함됩니다: `1`은 첫 번째 슬라이드를 나타냅니다. 반면에 [Presentation.getSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getslides/) 컬렉션 접근자는 0부터 시작하므로 동일한 슬라이드는 `presentation.getSlides().get_Item(0)`으로 접근합니다. 배열을 만들 때 이 차이를 기억해 오프바이원 오류를 방지하십시오.

[Presentation.getFontsManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getfontsmanager/)를 통해 오버로드를 호출합니다. 선택된 슬라이드를 렌더링하는 동안 결정된 대체만 반환합니다. 각 결과는 원본 및 대체 폰트 이름을 포함하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsubstitutioninfo/) 객체입니다. 결과는 현재 폰트 환경, 구성된 폰트 대체 규칙, [FontSubstRuleCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsubstrulecollection/)에 저장된 대체 규칙, 그리고 [외부 로드 폰트](/slides/ko/nodejs-java/custom-font/)를 반영합니다.

같은 대체가 둘 이상의 선택된 슬라이드에서 필요할 수 있습니다. 폰트 인벤토리나 사전 검사 보고서를 생성할 때 결과를 중복 제거하십시오. 다음 예제는 반환된 모든 대체를 보고한 다음 고유한 폰트 매핑의 정렬된 목록을 생성합니다:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

[FontsManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/) 클래스는 두 오버로드를 모두 제공합니다. 렌더링 작업 범위에 따라 선택하십시오:

| 오버로드 | 사용 시기 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) (인수 없음) | 프레젠테이션 전체에 대한 대체가 필요할 때 |
| [getSubstitutions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) (슬라이드 인덱스 `int[]`) | 선택된 범위, 단계적 검사 또는 부분 내보내기가 필요할 때 |

## **폰트 대체 규칙 설정**

소스 폰트를 사용할 수 없을 때 Aspose.Slides가 사용할 폰트를 지정하려면:

1. 프레젠테이션을 로드합니다.  
2. 소스와 대체 폰트에 대한 정의를 생성합니다.  
3. [WhenInaccessible](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsubstcondition/) 조건으로 [FontSubstRule](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsubstrule/)을 만듭니다.  
4. 해당 규칙을 [FontSubstRuleCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsubstrulecollection/)에 추가합니다.  
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) 메서드를 사용해 컬렉션을 할당합니다.  
6. 프레젠테이션을 렌더링하거나 변환합니다.

다음 JavaScript 예제는 `SomeRareFont`가 사용 불가능할 때 `Arial`을 대체 폰트로 지정하고 첫 번째 슬라이드를 렌더링해 결과를 확인합니다. 대체 폰트는 Aspose.Slides에서 사용할 수 있어야 합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
프레젠테이션 전체에 사용되는 폰트를 무조건 변경하려면 [폰트 교체](/slides/ko/nodejs-java/font-replacement/)를 참조하십시오.
{{% /alert %}}

## **수학 방정식 폰트에 대한 제한 사항**

폰트 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 폰트 선택 프로세스의 일부이며, 접근할 수 없는 폰트를 규칙에 지정된 사용 가능한 폰트로 교체할 수 있는 일반 텍스트에 대해 작동합니다.

Office Math 방정식에는 추가 요구 사항이 있습니다. 방정식에 **Cambria Math**가 사용되는 경우, Aspose.Slides는 방정식 레이아웃을 계산하고 렌더링하기 위해 정확히 해당 폰트가 필요할 수 있습니다. **STIX Two Math**와 같은 다른 수학 폰트로 대체하는 규칙은 **Cambria Math**를 대신할 수 없으며, 렌더링 시 여전히 **Cambria Math**가 필요하다고 보고될 수 있습니다.

이러한 프레젠테이션을 렌더링하거나 변환하려면 **Cambria Math**를 Aspose.Slides에서 사용할 수 있도록 해야 합니다. 운영 체제에 설치하거나 [외부 폰트](/slides/ko/nodejs-java/custom-font/)로 로드하십시오.

이 제한은 방정식 레이아웃에만 적용됩니다. 위에서 설명한 대체 규칙은 일반 프레젠테이션 텍스트에는 계속 적용됩니다.

## **FAQ**

**폰트 교체와 폰트 대체의 차이점은 무엇인가요?**

[폰트 교체](/slides/ko/nodejs-java/font-replacement/)는 프레젠테이션 전체에 걸쳐 한 폰트를 다른 폰트로 의도적으로 변경합니다. 폰트 대체는 원본 폰트를 사용할 수 없을 때와 같은 구성된 조건이 충족될 경우 렌더링된 출력에 사용할 폰트를 선택합니다.

**대체 규칙은 언제 적용되나요?**

규칙은 렌더링 및 변환 중에 [폰트 선택 순서](/slides/ko/nodejs-java/font-selection-sequence/)에 참여합니다. `WhenInaccessible`인 경우, Aspose.Slides가 소스 폰트에 접근할 수 없을 때만 규칙이 사용됩니다.

**폰트가 없고 대체 규칙이 설정되지 않은 경우 어떻게 되나요?**

Aspose.Slides는 폰트 선택 프로세스에 따라 가장 근접한 사용 가능한 폰트를 선택합니다. 결과는 런타임 환경에 설치된 폰트에 따라 달라집니다.

**외부 폰트를 로드하여 대체를 방지할 수 있나요?**

예. [외부 폰트 로드](/slides/ko/nodejs-java/custom-font/)를 통해 Aspose.Slides가 렌더링 및 변환 중에 사용할 수 있도록 할 수 있습니다.

**Aspose는 라이브러리와 함께 폰트를 배포하나요?**

아니요. 폰트 제공 및 라이선스 준수는 사용자가 책임져야 합니다.

**Windows, Linux, macOS 간에 대체 결과가 다를 수 있나요?**

예. 운영 체제마다 설치된 폰트와 폰트 검색 위치가 다르기 때문에 한 머신에서는 사용 가능한 폰트가 다른 머신에서는 대체가 필요할 수 있습니다.

**배치 변환에서 폰트 선택을 일관되게 유지하려면 어떻게 해야 하나요?**

모든 머신이나 컨테이너에 동일한 폰트 파일과 버전을 사용하고, 필요한 [외부 폰트](/slides/ko/nodejs-java/custom-font/)를 로드하며, 라이선스가 허용될 경우 [폰트 포함](/slides/ko/nodejs-java/embedded-font/)을 수행하십시오. 또한 내보내기 전에 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)를 호출해 예상치 못한 대체를 확인할 수 있습니다.