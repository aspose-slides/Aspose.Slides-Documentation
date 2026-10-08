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
description: "PowerPoint 및 OpenDocument 프레젠테이션을 렌더링하거나 변환할 때 Node.js용 Aspose.Slides에서 Java를 통해 폰트 대체 규칙을 구성하고 대체된 폰트를 검사합니다."
---
## **개요**

폰트 대체는 Aspose.Slides가 프레젠테이션이 렌더링되거나 변환될 때 액세스할 수 없는 폰트 대신 사용 가능한 폰트를 사용하도록 허용합니다. 대체는 렌더링된 출력에만 영향을 미치며, 프레젠테이션 콘텐츠에 지정된 폰트를 변경하지는 않습니다.

특정 폰트를 사용할 수 없을 때 사용할 폰트를 정의할 수 있으며, Aspose.Slides가 렌더링 중에 수행할 대체를 검사할 수 있습니다. 이는 설치된 폰트가 다른 환경에서도 출력이 일관되도록 도와줍니다.

[전용 굵은 서체가 없는 폰트 처리](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) 를 참조하십시오. 그 섹션에서는 PDF 내보내기 중 영향을 받는 텍스트를 래스터화하는 방법과 텍스트 선택, 검색, 스케일링에 대한 결과를 설명합니다.

## **폰트 대체 가져오기**

프레젠테이션이 렌더링될 때 어떤 폰트가 대체될지 확인하려면 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 메서드를 사용합니다. 이 메서드는 원본 및 대체 폰트 이름을 식별하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) 객체를 반환합니다.

다음 JavaScript 예제는 프레젠테이션에 대한 모든 폰트 대체를 나열합니다:

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

특정 슬라이드를 렌더링하는 데 필요한 대체만 검사하려면 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 오버로드에 슬라이드 인덱스 배열을 사용하십시오. 이는 프레젠테이션의 일부를 렌더링하거나 내보낼 때, 대규모 프레젠테이션을 단계적으로 확인할 때, 사용 불가능한 폰트에 의존하는 슬라이드를 찾을 때, 서버나 컨테이너용 최소 폰트 패키지를 준비할 때, 또는 연관되지 않은 슬라이드를 처리하지 않고 렌더링 차이를 진단할 때 유용합니다.

오버로드는 Java 기본형 `int[]`를 기대합니다. `java.newArray("int", [...])` 로 생성하십시오; 일반 JavaScript 배열은 `Integer[]` 로 변환되며 이 오버로드와 일치하지 않습니다.

배열에는 1부터 시작하는 슬라이드 인덱스가 포함됩니다: `1`은 첫 번째 슬라이드를 나타냅니다. 대조적으로, [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) 컬렉션 접근자는 0부터 시작하는 인덱싱을 사용하므로 같은 슬라이드는 `presentation.getSlides().get_Item(0)` 로 접근합니다. 배열을 만들 때 이 차이를 기억하여 오프바이원 오류를 방지하십시오.

[Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/) 를 통해 오버로드를 호출하십시오. 이는 선택된 슬라이드를 렌더링하는 동안 결정된 대체만 반환합니다. 각 결과는 원본 및 대체 폰트 이름을 포함하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) 객체입니다. 결과는 현재 폰트 환경, 구성된 폰트 대체 규칙, [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/)에 저장된 대체 규칙, 및 [externally loaded fonts](/slides/ko/nodejs-java/custom-font/) 을 반영합니다.

같은 대체가 둘 이상의 선택된 슬라이드에서 필요할 수 있습니다. 폰트 인벤토리나 프리플라이트 보고서를 만들 때 결과를 중복 제거하십시오. 다음 예제는 반환된 모든 대체를 보고한 뒤 고유한 폰트 매핑의 정렬된 목록을 생성합니다:

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

[FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) 클래스는 두 오버로드를 모두 제공합니다. 렌더링 작업의 범위에 따라 하나를 선택하십시오:

| 오버로드 | 사용 상황 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | 전체 프레젠테이션에 대한 대체가 필요합니다. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | 선택된 범위, 단계적 검사 또는 부분 내보내기에 대한 대체가 필요합니다. |

## **폰트 대체 규칙 설정**

소스 폰트를 사용할 수 없을 때 Aspose.Slides가 사용할 폰트를 지정하려면:

1. 프레젠테이션을 로드합니다.
2. 소스 폰트와 대체 폰트에 대한 폰트 정의를 생성합니다.
3. [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/) 조건을 사용하여 [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) 을 생성합니다.
4. 규칙을 [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/)에 추가합니다.
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) 메서드를 사용하여 컬렉션을 할당합니다.
6. 프레젠테이션을 렌더링하거나 변환합니다.

다음 JavaScript 예제는 `SomeRareFont` 가 사용 불가능할 때 `Arial` 로 대체하고, 결과를 확인하기 위해 첫 번째 슬라이드를 렌더링합니다. 대체 폰트는 Aspose.Slides에서 사용할 수 있어야 합니다.

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
프레젠테이션 전체에 사용되는 폰트를 무조건 변경하려면 [폰트 교체](/slides/ko/nodejs-java/font-replacement/) 를 참고하십시오.
{{% /alert %}}

## **수식 폰트에 대한 제한 사항**

폰트 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 폰트 선택 프로세스의 일부입니다. 이는 Aspose.Slides가 규칙에 지정된 사용 가능한 폰트로 접근 불가능한 폰트를 교체할 수 있을 때 일반 텍스트에 적용됩니다.

Office Math 수식에는 추가 요구 사항이 있습니다. 수식이 **Cambria Math** 를 사용하면 Aspose.Slides가 해당 정확한 폰트를 필요로 할 수 있습니다. **STIX Two Math** 와 같이 다른 수학 폰트를 대체하는 규칙은 이 목적을 위해 **Cambria Math** 를 대신할 수 없으며, 렌더링 시 여전히 **Cambria Math** 가 필요하다고 보고될 수 있습니다.

이러한 프레젠테이션을 렌더링하거나 변환하려면 **Cambria Math** 를 Aspose.Slides에서 사용할 수 있도록 해야 합니다. 운영 체제에 설치하거나 [외부 폰트](/slides/ko/nodejs-java/custom-font/) 로 로드하십시오.

이 제한은 수식 레이아웃에만 적용됩니다. 위에서 설명한 대체 규칙은 일반 프레젠테이션 텍스트에 여전히 적용됩니다.

## **FAQ**

**폰트 교체와 폰트 대체의 차이점은 무엇인가요?**

[폰트 교체](/slides/ko/nodejs-java/font-replacement/) 은 프레젠테이션 전체에서 하나의 폰트를 다른 폰트로 의도적으로 변경합니다. 폰트 대체는 원본 폰트를 사용할 수 없는 경우와 같이 설정된 조건이 충족될 때 렌더링된 출력에 사용할 폰트를 선택합니다.

**대체 규칙은 언제 적용되나요?**

규칙은 렌더링 및 변환 중에 [font selection sequence](/slides/ko/nodejs-java/font-selection-sequence/) 에 참여합니다. `WhenInaccessible` 를 사용할 경우, Aspose.Slides가 소스 폰트에 접근할 수 없을 때만 규칙이 적용됩니다.

**폰트가 없고 대체 규칙이 구성되지 않은 경우 어떻게 되나요?**

Aspose.Slides는 폰트 선택 프로세스에 따라 가장 가까운 사용 가능한 폰트를 선택합니다. 결과는 런타임 환경에 설치된 폰트에 따라 달라집니다.

**대체를 방지하기 위해 외부 폰트를 로드할 수 있나요?**

네. [외부 폰트를 로드](/slides/ko/nodejs-java/custom-font/) 하면 Aspose.Slides가 렌더링 및 변환 중에 해당 폰트를 사용할 수 있습니다.

**Aspose가 라이브러리와 함께 폰트를 배포하나요?**

아니요. 폰트를 제공하고 해당 라이선스를 준수할 책임은 사용자에게 있습니다.

**대체 결과가 Windows, Linux, macOS 간에 다를 수 있나요?**

예. 운영 체제마다 설치된 폰트와 폰트 검색 위치가 다르므로, 한 머신에서 사용할 수 있는 폰트가 다른 머신에서는 대체가 필요할 수 있습니다.

**배치 변환에서 폰트 선택을 일관되게 하려면 어떻게 해야 하나요?**

모든 머신이나 컨테이너에서 동일한 폰트 파일과 버전을 사용하고, [필요한 외부 폰트를 로드](/slides/ko/nodejs-java/custom-font/) 하며, 라이선스가 허용되는 경우 [폰트 포함](/slides/ko/nodejs-java/embedded-font/) 하세요. 또한 내보내기 전에 [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 를 호출하여 예상치 못한 대체를 식별할 수 있습니다.