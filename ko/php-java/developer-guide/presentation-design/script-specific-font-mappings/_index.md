---
title: "PHP에서 스크립트별 테마 글꼴 관리"
linktitle: "스크립트별 테마 글꼴"
type: docs
weight: 15
url: /ko/php-java/script-specific-font-mappings/
keywords:
- 스크립트별 글꼴
- 테마 글꼴 매핑
- 다국어 프레젠테이션
- 쓰기 시스템
- 키릴 글꼴
- 아랍 글꼴
- 일본어 글꼴
- 조지아 글꼴
- 타나 글꼴
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 사용하여 Java를 통해 PowerPoint 테마에서 스크립트별 글꼴 매핑을 검사, 추가, 교체 및 제거합니다."
---
## **개요**

프레젠테이션 테마는 서로 다른 쓰기 시스템에 대해 서로 다른 글꼴 패밀리를 선택할 수 있습니다. 이를 통해 테마 글꼴을 사용하면서도 다국어 텍스트가 하나의 일관된 글꼴 체계를 따르고, 키릴어, 아랍어, 일본어, 조지아어, 타나어 및 기타 스크립트에 적합한 글꼴을 사용할 수 있습니다.

테마의 [FontScheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontscheme/)에는 일반적으로 제목에 사용되는 메이저 폰트 컬렉션과 본문에 사용되는 마이너 폰트 컬렉션이 포함됩니다. 라틴어 및 동아시아 글꼴 설정 외에도 두 [Fonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fonts/) 컬렉션은 쓰기 시스템 태그와 글꼴 패밀리 이름 간의 매핑을 노출합니다.

이 문서에서는 프레젠테이션 마스터 테마에서 해당 매핑을 검사하고 수정한 다음, 저장·재로드 사이클에서도 변경 사항이 유지되는지 확인하는 방법을 보여줍니다.

## **스크립트 태그 이해**

스크립트 글꼴 메서드는 네 글자 BCP 47 스크립트 서브태그를 사용해 쓰기 시스템을 식별합니다. 일반적인 값은 다음과 같습니다:

| 스크립트 태그 | 쓰기 시스템 |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

이 매핑은 개별 텍스트 부분이 아니라 테마 글꼴 스키마에 속합니다. 프레젠테이션은 메이저와 마이너 컬렉션에 대해 서로 다른 매핑을 정의할 수 있으며, 일부 스크립트에 대한 매핑을 생략할 수도 있습니다.

## **스크립트 글꼴 매핑에 접근하고 검사하기**

[Presentation::getMasterTheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getMasterTheme)를 사용해 프레젠테이션 수준의 테마에 접근합니다. [MasterTheme::getFontScheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontscheme/#getMajor) 및 [FontScheme::getMinor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontscheme/#getMinor) 메서드는 두 개의 [Fonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fonts/) 컬렉션에 대한 접근을 제공합니다.

[Fonts::getScriptFontMap](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fonts/#getScriptFontMap)를 호출하면 컬렉션의 모든 매핑을 가져올 수 있습니다. 특정 쓰기 시스템을 찾으려면 해당 스크립트 태그와 함께 [Fonts::getScriptFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fonts/#getScriptFont)를 호출합니다. `Fonts::getScriptFont`는 해당 컬렉션에 요청된 매핑이 정의되지 않은 경우 `null`을 반환합니다.

## **매핑 수정 및 지속성 확인**

[Fonts::setScriptFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fonts/#setScriptFont)를 사용해 매핑을 만들거나 현재 글꼴 패밀리를 교체합니다. [Fonts::removeScriptFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fonts/#removeScriptFont)를 사용해 매핑을 제거합니다.

다음 엔드‑투‑엔드 예제는 기존 메이저 및 마이너 매핑을 모두 읽고, 일본어 메이저 글꼴을 조회한 뒤, 키릴어 메이저 글꼴을 변경하고, 타나어 마이너 매핑을 제거합니다. 그런 다음 프레젠테이션을 저장하고 다시 열어 두 변경이 모두 적용되었는지 확인합니다. 초기 테마와 무관하게 제거 단계를 독립적으로 만들기 위해, 예제는 타나어 매핑이 아직 정의되지 않은 경우에만 해당 매핑을 생성합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

검증은 일반 조회와 동일한 `null` 동작을 사용합니다. 제거가 저장된 뒤 `Fonts::getScriptFont("Thaa")`는 마이너 컬렉션에 대해 `null`을 반환합니다.

## **테마 매핑과 다른 글꼴 설정 구분**

스크립트 전용 테마 매핑은 글꼴 선택에 참여하지만, 직접 텍스트 서식, 대체 및 폴백과는 다른 문제를 해결합니다:

| 메커니즘 | 목적 | 테마 매핑 변경 시 효과 |
|---|---|---|
| 스크립트 전용 테마 글꼴 매핑 | 쓰기 시스템에 대해 메이저 또는 마이너 테마 글꼴을 선택합니다. | 해당 테마 글꼴을 계속 사용하는 텍스트는 새 매핑된 패밀리로 해석될 수 있습니다. |
| 텍스트 부분에 명시적으로 할당된 글꼴 | 테마에 의존하지 않고 해당 부분에 요청된 글꼴 패밀리를 고정합니다. | 직접 서식이 테마 선택을 우선시하므로 해당 부분은 변경되지 않을 수 있습니다. |
| 글꼴 대체 | 요청된 글꼴이 없거나 대체 규칙이 적용될 때 해당 글꼴을 교체합니다. | 글꼴이 요청된 후에 작동하며, 테마의 스크립트 매핑을 재정의하지 않습니다. |
| 글꼴 폴백 | 선택된 글꼴에 포함되지 않은 글리프를 제공하며, 주로 특정 유니코드 범위에 사용됩니다. | 누락된 글리프를 보완하지만, 저장된 테마 매핑을 변경하지는 않습니다. |

마지막 두 메커니즘에 대한 자세한 내용은 [Font Substitution](/slides/ko/php-java/font-substitution/) 및 [Fallback Fonts](/slides/ko/php-java/fallback-font/)를 참조하십시오.

[Presentation::getMasterTheme](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getMasterTheme)에서 매핑을 변경하면 실제 서식이 여전히 해당 테마에 의존하는 콘텐츠에만 영향을 미칩니다. 텍스트는 마스터, 레이아웃 또는 슬라이드에서 테마 오버라이드를 상속하거나 명시적으로 할당된 글꼴을 사용할 수 있습니다. 표시 결과가 프레젠테이션‑레벨 매핑을 따르지 않을 경우 이러한 수준을 검사하십시오.

## **매핑된 글꼴을 사용 가능하게 하고 결과 검증**

스크립트 매핑은 글꼴 패밀리 이름만 저장하며, 해당 글꼴 파일을 설치하거나 로드하지는 않습니다. 일관된 렌더링 및 내보내기를 위해서는 매핑된 모든 글꼴을 환경에 설치하거나 [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsloader/#loadExternalFonts) 또는 [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources)와 같은 사용자 지정 소스를 통해 Aspose.Slides에 제공해야 합니다. 사용 가능한 로딩 옵션은 [Custom Fonts](/slides/ko/php-java/custom-font/)를 참조하십시오.

저장된 매핑을 검증하는 것은 테마 정의가 보존되었음을 확인할 뿐이며, 글꼴이 실제로 사용 가능하고 모든 필요한 글리프를 포함하거나 의도한 레이아웃을 생성한다는 것을 증명하지는 않습니다. 각 필요 쓰기 시스템에 대한 대표 텍스트를 이미지나 PDF로 렌더링하고 출력을 검사하십시오. 이렇게 하면 누락된 글꼴, 불완전한 글리프 커버리지, 폴백 동작 및 레이아웃 변화를 프레젠테이션 배포 전부터 발견할 수 있습니다. 렌더링 및 내보내기 예제는 [Convert PowerPoint Presentations](/slides/ko/php-java/convert-powerpoint/)를 참고하십시오.

## **FAQ**

**`Fonts::getScriptFont`가 스크립트가 매핑되지 않았을 때 반환하는 값은?**

[Fonts::getScriptFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fonts/#getScriptFont)은 해당 메이저 또는 마이너 폰트 컬렉션에 요청된 스크립트 매핑이 정의되지 않은 경우 `null`을 반환합니다.

**`Fonts::setScriptFont`가 이미 존재하는 스크립트에 대해 두 번째 매핑을 추가합니까?**

아니요. [Fonts::setScriptFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fonts/#setScriptFont)은 매핑이 없을 때 생성하고, 동일한 스크립트 태그가 이미 존재하면 매핑된 글꼴 패밀리를 교체합니다.

**테마 매핑을 변경했는데 일부 텍스트가 바뀌지 않은 이유는?**

텍스트에 명시적으로 할당된 글꼴이 있거나, 오버라이드를 통해 다른 테마를 상속받았거나, 렌더링 중 대체 또는 폴백에 의해 영향을 받았을 수 있습니다. 프레젠테이션‑레벨 스크립트 매핑은 실제 서식이 해당 테마 글꼴 컬렉션을 계속 참조하는 텍스트에만 적용됩니다.

**저장 후 재열기로 다국어 출력이 검증되나요?**

아니요. 재열기는 테마 데이터의 지속성을 확인할 뿐입니다. 또한 각 필요 쓰기 시스템에 대한 대표 텍스트를 렌더링하여 매핑된 글꼴이 사용 가능하고 필요한 글리프를 포함하는지 확인해야 합니다.