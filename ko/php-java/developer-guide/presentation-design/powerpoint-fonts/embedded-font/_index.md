---
title: PHP를 사용한 프레젠테이션에 폰트 삽입
linktitle: 삽입된 폰트
type: docs
weight: 40
url: /ko/php-java/embedded-font/
keywords:
- 폰트 추가
- 폰트 삽입
- 폰트 삽입
- 삽입된 폰트 가져오기
- 삽입된 폰트 추가
- 삽입된 폰트 제거
- 삽입된 폰트 압축
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides로 PowerPoint에서 삽입된 폰트를 관리합니다. 폰트를 추가, 조회, 제거 및 압축하여 텍스트 모양을 유지하고 파일 크기를 줄입니다."
---
## **소개**

폰트를 삽입하면 폰트 데이터가 PowerPoint 프레젠테이션 내부에 저장됩니다. 뷰어가 삽입된 폰트를 지원하면 대상 시스템에 해당 폰트가 설치되어 있지 않더라도 해당 폰트를 사용해 텍스트를 표시할 수 있습니다. 이는 줄 바꿈, 텍스트 간격 및 슬라이드 레이아웃을 유지하는 데 도움이 됩니다.

Aspose.Slides for PHP via Java를 사용하면 [FontsManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/) 클래스를 통해 삽입된 폰트를 조회, 추가 및 제거할 수 있으며, 이 클래스는 [Presentation::getFontsManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#getFontsManager) 메서드가 반환합니다. 또한 프레젠테이션에서 사용되지 않는 문자들을 제거하여 삽입된 폰트 데이터의 크기를 줄일 수 있습니다.

아래 예제는 PPTX 파일을 대상으로 합니다. 폰트를 삽입하기 전에 해당 폰트 데이터가 Aspose.Slides에서 사용 가능하고 라이선스가 삽입을 허용하는지 확인하십시오.

## **삽입된 폰트 가져오기 및 제거**

프레젠테이션에 저장된 폰트를 나열하려면 [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) 를 사용합니다. 폰트를 하나 제거하려면 해당 목록에서 폰트를 [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) 에 전달한 뒤 프레젠테이션을 저장합니다.

다음 예제는 `EmbeddedFonts.pptx` 에서 삽입된 폰트를 나열하고 Calibri가 존재하면 제거합니다:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

삽입된 폰트를 제거하면 저장된 폰트 데이터가 삭제되지만 텍스트에 할당된 폰트 자체가 변경되지는 않습니다. 대상 시스템에 해당 폰트가 설치되어 있으면 텍스트는 여전히 해당 폰트를 사용할 수 있습니다. 그렇지 않은 경우 렌더링 시 [font substitution](/slides/ko/php-java/font-substitution/) 이 필요할 수 있으며, 이는 레이아웃에 영향을 줄 수 있습니다.

## **폰트 데이터 및 삽입 권한 검사**

삽입하기 전에 폰트를 검사하려면 [FontsManager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/) 클래스를 사용합니다. 프레젠테이션에서 사용된 폰트를 가져오려면 [FontsManager::getFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/#getFonts) 를 호출합니다. 각 폰트마다 [FontData](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontdata/) 객체와 필요한 [FontStyleType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontstyletype/) 값을 [FontsManager::getFontBytes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/#getFontBytes) 에 전달합니다. 이 메서드는 해당 폰트 스타일에 대한 바이너리 데이터를 반환하며, 요청된 폰트 또는 스타일이 없을 경우 `null` 을 반환합니다. `null` 결과를 [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) 에 전달하지 마세요. 해당 메서드는 바이트 배열을 필요로 합니다.

[EmbeddingLevel](https://reference.aspose.com/slides/ko/php-java/aspose.slides/embeddinglevel/) 은 폰트에 저장된 삽입 제한을 보고하는 플래그 열거형입니다:
- `Installable` 은 폰트 라이선스에 따라 다른 시스템에 삽입 및 영구 설치를 허용합니다.
- `Restricted` 은 유일한 사용 권한 플래그인 경우, 폰트 소유자의 허가 없이 삽입을 금지합니다.
- `PreviewPrint` 은 보기 및 인쇄를 위한 일시적 사용을 허용하며, 폰트를 포함한 문서는 읽기 전용이어야 합니다.
- `Editable` 은 일시적 사용을 허용하고 문서를 편집 및 저장할 수 있게 합니다.
- `NoSubsetting` 은 추가 제한으로, 글리프의 일부만 삽입하는 것을 금지합니다. 이 플래그가 있으면 모든 문자를 삽입합니다.
- `BitmapOnly` 은 추가 제한으로, 아웃라인 데이터가 아닌 비트맵 스트라이크만 삽입을 허용합니다. 폰트에 비트맵 스트라이크가 없으면 삽입할 수 없습니다.

첫 번째 네 값은 사용 권한을 설명하고, `NoSubsetting` 및 `BitmapOnly` 은 이들과 결합될 수 있습니다. 비트 연산을 사용하여 수정자를 확인하세요. `Installable` 은 0이므로 사용 권한 비트를 마스크한 뒤 결과를 `Installable` 과 비교해야 플래그로 확인하는 대신 올바르게 동작합니다. 현재 폰트는 최대 하나의 사용 권한 비트만 설정해야 합니다. 하나 이상 설정된 오래된 폰트와의 호환성을 위해 아래 도우미는 가장 제한이 낮은 권한을 선택합니다: `Editable`, 다음으로 `PreviewPrint`, 마지막으로 `Restricted`.

다음 예제는 `FontsManager::getFonts` 로 반환된 각 폰트에 대해 일반, 굵게, 기울임, 굵게기울임 스타일 데이터를 감사합니다. 사용 불가능한 스타일, 제한된 폰트, bitmap‑only 폰트, 미리 보기와 인쇄만 가능한 폰트(출력이 편집 가능하게 유지되므로) 및 이미 삽입된 폰트를 건너뜁니다. 사용 가능한 스타일 중 `NoSubsetting` 이 있는 경우 해당 폰트 패밀리의 모든 문자를 삽입합니다.
```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

이 검사는 각 폰트 파일에 인코딩된 제한을 보고합니다. 이는 라이선스를 부여하거나, 폰트를 합법적으로 취득했음을 증명하거나, 삽입된 복사본을 배포하기 전에 폰트 라이선스 계약을 확인하는 절차를 대신하지 못합니다.

## **삽입된 폰트 추가**

[FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) 를 사용하여 폰트를 삽입합니다. 해당 오버로드는 [FontData](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontdata/) 객체 또는 폰트 데이터를 포함하는 바이트 배열을 받을 수 있습니다. [EmbedFontCharacters](https://reference.aspose.com/slides/ko/php-java/aspose.slides/embedfontcharacters/) 열거형은 포함할 문자를 제어합니다:
- [All](https://reference.aspose.com/slides/ko/php-java/aspose.slides/embedfontcharacters/) 은 폰트의 모든 문자를 삽입합니다. 수신자가 프레젠테이션을 편집하고 새로운 텍스트를 입력해야 하는 경우 이 옵션을 사용하십시오.
- [OnlyUsed](https://reference.aspose.com/slides/ko/php-java/aspose.slides/embedfontcharacters/) 은 프레젠테이션에서 사용된 문자만 삽입하여 파일 크기를 줄입니다. 주로 보기용인 완성된 프레젠테이션에 이 옵션을 선택하십시오.

다음 예제는 `Fonts.pptx` 에서 사용된 폰트를 가져오기 위해 [FontsManager::getFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/#getFonts) 를 사용하고, 아직 삽입되지 않은 폰트를 삽입합니다. 추가할 폰트는 코드를 실행하는 머신에 존재해야 합니다. 기존에 삽입된 폰트는 현재 문자 집합을 유지합니다.
```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **삽입된 폰트 압축**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/compress/#compressEmbeddedFonts) 은 사용되지 않는 문자를 제거하여 삽입된 폰트 데이터를 감소시킵니다. 이미 삽입된 폰트를 대상으로 작동하므로 크기 감소는 프레젠테이션에 포함된 사용되지 않은 폰트 데이터 양에 따라 달라집니다.

다음 예제는 `EmbeddedFonts.pptx` 에 있는 폰트를 압축하고 결과를 별도 파일로 저장합니다:
```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

수신자가 나중에 텍스트를 추가해야 할 가능성이 있다면 원본 파일을 보관하십시오. 압축 중에 제거된 문자는 원래 모든 문자를 삽입했더라도 삽입된 폰트에서 더 이상 사용할 수 없습니다.

## **FAQ**

**렌더링 시 삽입된 폰트가 여전히 대체되는지 어떻게 확인할 수 있나요?**

프레젠테이션을 렌더링하는 환경에서 [FontsManager::getSubstitutions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/#getSubstitutions) 을 호출하면 Aspose.Slides가 교체할 폰트를 확인할 수 있습니다. 또한 [font substitution](/slides/ko/php-java/font-substitution/) 설정과 [font fallback](/slides/ko/php-java/fallback-font/) 규칙을 확인하십시오. 폰트 대체는 누락된 문자를 처리하므로, 폰트를 삽입해도 해당 폰트 자체에 포함되지 않은 문자는 해결되지 않습니다.

**Arial 및 Calibri와 같은 일반 폰트를 삽입해야 할까요?**

결정은 대상 환경을 기준으로 해야 합니다. 필요한 폰트가 프레젠테이션을 열거나 렌더링하는 모든 컴퓨터에 이미 설치되어 있다면 삽입은 불필요한 파일 크기를 늘릴 수 있습니다. 수신자나 서버에 해당 폰트가 없을 가능성이 있다면, 라이선스가 허용하는 범위 내에서 삽입함으로써 의도한 외형을 유지할 수 있습니다.