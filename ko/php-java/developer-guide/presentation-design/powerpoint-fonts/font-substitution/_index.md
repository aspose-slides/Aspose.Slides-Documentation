---
title: PHP를 사용한 프레젠테이션에서 글꼴 대체 구성
linktitle: 글꼴 대체
type: docs
weight: 70
url: /ko/php-java/font-substitution/
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
- PHP
- Aspose.Slides
description: "PowerPoint 및 OpenDocument 프레젠테이션을 렌더링하거나 변환할 때 Java를 통해 PHP용 Aspose.Slides에서 글꼴 대체 규칙을 구성하고 대체된 글꼴을 검사합니다."
---
## **개요**

글꼴 대체를 사용하면 Aspose.Slides가 프레젠테이션을 렌더링하거나 변환할 때 접근할 수 없는 글꼴 대신 사용 가능한 글꼴을 사용할 수 있습니다. 대체는 렌더링된 출력에만 영향을 미치며 프레젠테이션 콘텐츠에 할당된 글꼴을 변경하지는 않습니다.

특정 글꼴을 사용할 수 없을 때 사용할 글꼴을 정의할 수 있으며, 렌더링 중 Aspose.Slides가 수행할 대체를 검사할 수 있습니다. 이를 통해 설치된 글꼴이 다른 환경에서도 출력 일관성을 유지할 수 있습니다.

글꼴이 사용 가능하지만 전용 굵은 글꼴이 없는 경우, [전용 굵은 글꼴이 없는 글꼴 처리](/slides/ko/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)를 참조하십시오. 해당 섹션에서는 PDF 내보내기 시 영향을 받는 텍스트를 래스터화하는 방법과 텍스트 선택, 검색 및 스케일링에 대한 영향을 설명합니다.

## **글꼴 대체 가져오기**

[FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) 메서드를 사용하여 프레젠테이션이 렌더링될 때 어떤 글꼴이 대체되는지 확인할 수 있습니다. 이 메서드는 원본 및 대체 글꼴 이름을 식별하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) 개체를 반환합니다.

다음 PHP 예제는 프레젠테이션에 대한 모든 글꼴 대체를 나열합니다:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **선택한 슬라이드에 대한 글꼴 대체 가져오기**

`int[] slides` 매개변수를 사용한 [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) 오버로드를 활용하면 특정 슬라이드에 필요한 대체만 검사할 수 있습니다. 이는 프레젠테이션의 일부를 렌더링하거나 내보낼 때, 대규모 프레젠테이션을 점진적으로 확인할 때, 사용 불가능한 글꼴에 의존하는 슬라이드를 찾을 때, 서버 또는 컨테이너용 최소 글꼴 패키지를 준비할 때, 혹은 관련 없는 슬라이드를 처리하지 않고 렌더링 차이를 진단할 때 유용합니다.

`slides` 배열은 1부터 시작하는 슬라이드 인덱스를 포함합니다: `1`은 첫 번째 슬라이드를 나타냅니다. 반면에 [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) 컬렉션 접근자는 0부터 시작하는 인덱스를 사용하므로 동일한 슬라이드는 `$presentation->getSlides()->get_Item(0)`로 접근합니다. 배열을 만들 때 이 차이를 염두에 두어 인덱스 오류를 방지하십시오.

[Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/) 메서드를 통해 오버로드를 호출하십시오. 이 메서드는 선택된 슬라이드를 렌더링하는 동안 결정된 대체만 반환합니다. 각 결과는 원본 및 대체 글꼴 이름을 포함하는 [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) 개체이며, 현재 글꼴 환경, 구성된 대체 규칙, [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/)에 저장된 대체 규칙 및 [외부 로드된 글꼴](/slides/ko/php-java/custom-font/)을 반영합니다.

동일한 대체가 여러 선택된 슬라이드에서 필요할 수 있습니다. 글꼴 인벤토리나 사전 검증 보고서를 만들 때 결과를 중복 제거하십시오. 다음 예제는 반환된 모든 대체를 출력한 뒤 고유한 글꼴 매핑의 정렬된 목록을 생성합니다:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) 클래스는 두 가지 오버로드를 제공합니다. 렌더링 작업 범위에 따라 하나를 선택하십시오:

| 오버로드 | 사용 시기 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | 전체 프레젠테이션에 대한 대체가 필요합니다. |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | 선택 범위, 증분 검사 또는 부분 내보내기에 대한 대체가 필요합니다. |

## **글꼴 대체 규칙 설정**

소스 글꼴을 사용할 수 없을 때 Aspose.Slides가 사용할 글꼴을 지정하려면:

1. 프레젠테이션을 로드합니다.
2. 소스와 대체 글꼴에 대한 정의를 만듭니다.
3. [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/) 조건을 사용하여 [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/)을 생성합니다.
4. 규칙을 [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/)에 추가합니다.
5. [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) 메서드를 사용하여 컬렉션을 할당합니다.
6. 프레젠테이션을 렌더링하거나 변환합니다.

다음 PHP 예제는 `SomeRareFont`가 없을 때 `Arial`로 대체하고 첫 번째 슬라이드를 렌더링하여 결과를 확인합니다. 대체 글꼴은 Aspose.Slides에서 사용할 수 있어야 합니다.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
프레젠테이션 전체에서 글꼴을 무조건 변경하려면, [글꼴 교체](/slides/ko/php-java/font-replacement/)를 참조하십시오.
{{% /alert %}}

## **수식 글꼴에 대한 제한사항**

글꼴 대체 규칙은 렌더링 및 변환 중에 사용되는 표준 글꼴 선택 프로세스의 일부입니다. 접근할 수 없는 글꼴을 규칙에 지정된 사용 가능한 글꼴로 교체할 수 있는 일반 텍스트에 적용됩니다.

Office Math 수식에는 추가 요구 사항이 있습니다. 수식에 **Cambria Math**가 사용된 경우, Aspose.Slides는 수식 레이아웃을 계산하고 렌더링하기 위해 정확히 해당 글꼴이 필요할 수 있습니다. **STIX Two Math**와 같은 다른 수식 글꼴로 대체하는 규칙은 이 목적을 대신할 수 없으며, 여전히 **Cambria Math**가 필요하다고 보고될 수 있습니다.

이러한 프레젠테이션을 렌더링하거나 변환하려면 **Cambria Math**를 Aspose.Slides에서 사용할 수 있도록 해야 합니다. 운영 체제에 설치하거나 [외부 글꼴](/slides/ko/php-java/custom-font/)로 로드하십시오.

이 제한은 수식 레이아웃에만 적용됩니다. 위에서 설명한 대체 규칙은 일반 프레젠테이션 텍스트에는 계속 적용됩니다.

## **FAQ**

**글꼴 교체와 글꼴 대체의 차이점은 무엇인가요?**

[Font replacement](/slides/ko/php-java/font-replacement/)은 프레젠테이션 전체에서 하나의 글꼴을 다른 글꼴로 의도적으로 변경합니다. 글꼴 대체는 원본 글꼴을 사용할 수 없을 때와 같이 구성된 조건이 충족될 경우 렌더링된 출력에 사용할 글꼴을 선택합니다.

**대체 규칙은 언제 적용되나요?**

규칙은 렌더링 및 변환 중 [글꼴 선택 순서](/slides/ko/php-java/font-selection-sequence/)에 참여합니다. `WhenInaccessible`가 지정된 경우, Aspose.Slides가 소스 글꼴에 접근할 수 없을 때만 규칙이 사용됩니다.

**글꼴이 없고 대체 규칙이 구성되지 않은 경우 어떻게 되나요?**

Aspose.Slides는 글꼴 선택 프로세스에 따라 가장 가까운 사용 가능한 글꼴을 선택합니다. 결과는 런타임 환경에 설치된 글꼴에 따라 달라집니다.

**외부 글꼴을 로드하여 대체를 방지할 수 있나요?**

예. [외부 글꼴](/slides/ko/php-java/custom-font/)을 로드하면 Aspose.Slides가 렌더링 및 변환 중에 해당 글꼴을 사용할 수 있습니다.

**Aspose가 라이브러리와 함께 글꼴을 배포하나요?**

아니요. 글꼴 제공 및 라이선스 준수는 사용자의 책임입니다.

**Windows, Linux, macOS 간에 대체 결과가 다를 수 있나요?**

예. 설치된 글꼴 및 글꼴 검색 위치가 운영 체제마다 다르기 때문에 한 머신에서 사용 가능한 글꼴이 다른 머신에서는 대체가 필요할 수 있습니다.

**대량 변환 시 글꼴 선택을 일관되게 하려면 어떻게 해야 하나요?**

모든 머신이나 컨테이너에 동일한 글꼴 파일과 버전을 사용하고, [외부 글꼴](/slides/ko/php-java/custom-font/)을 로드하며, 라이선스가 허용되는 경우 [글꼴 포함](/slides/ko/php-java/embedded-font/)을 수행하십시오. 또한 내보내기 전에 [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/)을 호출하여 예상치 못한 대체를 식별할 수 있습니다.