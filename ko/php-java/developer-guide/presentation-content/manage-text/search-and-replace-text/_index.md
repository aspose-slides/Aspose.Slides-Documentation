---
title: PHP에서 PowerPoint 프레젠테이션의 텍스트 검색 및 교체
linktitle: 텍스트 검색 및 교체
type: docs
weight: 55
url: /ko/php-java/search-and-replace-text/
keywords:
- 텍스트 검색
- 텍스트 강조
- 텍스트 교체
- 정규 표현식
- 결과 콜백
- 텍스트 프레임
- 감사 보고서
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에서 텍스트를 검색, 강조 및 교체하면서 모든 일치를 수집합니다."
---
## **개요**

Aspose.Slides for PHP via Java는 개별 텍스트 프레임이나 프레젠테이션 전체에서 텍스트를 검색, 강조 및 교체할 수 있습니다. 각 작업은 결과 콜백을 통해 일치하는 모든 항목에 대해 애플리케이션에 알릴 수 있습니다. 이를 통해 프레젠테이션을 업데이트하면서 일치한 텍스트, 해당 컨텍스트, 위치, 텍스트 프레임, 슬라이드 번호를 포함하는 감사 추적을 동시에 구축할 수 있습니다.

이러한 기능은 검토, 검열, 용어 확인, 템플릿 정리 및 자동화된 보고 워크플로에 유용합니다.

아래 첫 번째 예제에서는 첫 번째 슬라이드에 단일 텍스트 상자가 포함된 "sample.pptx" 파일을 사용하며, 해당 텍스트는 다음과 같습니다:

![Sample text](sample_text.png)

## **검색 범위 선택**

하나의 텍스트 프레임에만 작업을 제한하려면 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/) 메서드를 사용하십시오. 프레젠테이션 전체의 모든 적용 가능한 텍스트를 처리하려면 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 메서드를 사용하십시오.

| 작업 | 단일 텍스트 프레임 | 전체 프레젠테이션 |
|---|---|---|
| 리터럴 텍스트 강조 | [TextFrame::highlightText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#highlightText) |
| 정규식 일치 강조 | [TextFrame::highlightRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#highlightRegex) |
| 리터럴 텍스트 교체 | [TextFrame::replaceText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#replaceText) |
| 정규식 일치 교체 | [TextFrame::replaceRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#replaceRegex) |

## **텍스트 매칭 구성**

리터럴 텍스트 작업에 대해서는 [TextSearchOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/)를 사용하여 매칭을 제어합니다:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 전체 단어만 일치하도록 제한합니다.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) 대소문자 구분 여부를 제어합니다.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) 프레젠테이션 수준 검색, 교체 및 강조 작업에 슬라이드 노트를 포함합니다.

정규식 작업은 Java `Pattern`을 사용하므로 대소문자 구분 및 단어 경계와 같은 매칭 규칙은 표현식 및 해당 플래그에 의해 정의됩니다.

## **콜백으로 일치 정보 수집**

하이라이팅 또는 교체 메서드에 Java 프록시 콜백을 전달하여 각 일치에 대한 알림을 받을 수 있습니다. 콜백 메서드는 관련 텍스트 프레임, 원본 텍스트, 일치된 텍스트 및 일치 위치를 전달받습니다.

콜백은 슬라이드 번호를 직접 받지 않습니다. 아래 구현은 부모 슬라이드에서 이를 유도하고 슬라이드 노트에서 찾은 텍스트도 처리합니다. 결과 배열은 텍스트가 다른 슬라이드 유형에 연결된 경우 `null`을 사용합니다.

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentSlide = $textFrame->getSlide();
        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

이 PHP 객체에 대한 프록시를 생성한 다음 작업에 전달하십시오:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

교체 작업의 경우 `foundText`에 원본 일치 텍스트가 포함되므로 콜백에서 정확히 어떤 용어가 교체되었는지 기록할 수 있습니다.

## **텍스트 강조**

[TextFrame::highlightText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#highlightText) 메서드를 사용하여 텍스트 프레임에서 리터럴 텍스트 일치를 강조합니다. 검색을 제어하려면 [TextSearchOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/)를 전달하십시오.

아래 코드 예제는 문자 **"try"**의 모든 발생을 강조하고, 이어서 완전한 단어 **"to"**만을 강조합니다.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // 텍스트 프레임에서 "try"의 모든 발생을 강조합니다.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // 완전한 단어 "to"만 강조합니다.
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

결과:

![The highlighted text](highlighted_text.png)

## **정규 표현식을 사용한 텍스트 강조**

[TextFrame::highlightRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#highlightRegex) 메서드는 텍스트 프레임에서 정규식을 통해 찾은 텍스트 일치를 강조합니다.

다음 코드는 길이가 7자 이상인 모든 단어를 강조합니다:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

결과:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **프레젠테이션 전체 텍스트 강조**

[Presentation::highlightText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#highlightText) 및 [Presentation::highlightRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#highlightRegex)를 사용하여 프레젠테이션의 모든 적용 가능한 텍스트 프레임을 검색합니다. 다음 예제는 리터럴 용어와 모든 이메일 주소를 강조합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **텍스트 프레임에서 텍스트 교체**

리터럴 텍스트 교체에는 [TextFrame::replaceText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceText)를, 패턴 기반 교체에는 [TextFrame::replaceRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceRegex)를 사용하십시오. 이러한 메서드는 기존 텍스트 프레임 내에서 일치 텍스트만 업데이트하므로 전체 문자열을 새로 만들지 않고 주변 서식이 유지됩니다.

다음 예제는 철자 변형을 표준화하고 버전 레이블을 교체합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

일치가 서로 다른 서식이 적용된 부분에 걸쳐 있는 경우, 교체 텍스트에 적용할 서식을 확인하기 위해 출력 결과를 검토하십시오.

## **프레젠테이션 전체 텍스트 교체**

[Presentation::replaceText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#replaceText) 및 [Presentation::replaceRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#replaceRegex)를 사용하여 프레젠테이션 전체에 동일한 작업을 적용합니다. 이는 템플릿 정리, 용어 업데이트 및 검열에 유용합니다.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **보고를 위한 일치 그룹화**

각 결과가 슬라이드 번호와 텍스트 프레임을 저장하므로, 애플리케이션은 일치를 감사, 보고 또는 검토 워크플로에 따라 그룹화할 수 있습니다. 다음 예제는 수집된 결과를 먼저 슬라이드별, 그 다음 텍스트 프레임별로 그룹화합니다:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **FAQ**

**전체 프레젠테이션이 아니라 하나의 텍스트 상자만 검색하려면 어떻게 해야 하나요?**

셰이프의 텍스트 프레임을 가져온 다음 해당 텍스트 프레임에서 [TextFrame::highlightText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceText) 또는 [TextFrame::replaceRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceRegex)를 호출하십시오. 프레젠테이션 수준 메서드는 모든 적용 가능한 텍스트 프레임을 처리합니다.

**정확한 대소문자를 사용하여 전체 단어를 매칭하려면 어떻게 해야 하나요?**

[TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly)와 [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/#setCaseSensitive)를 `true`로 설정하고, 해당 옵션을 리터럴 텍스트 강조 또는 교체 메서드에 전달하십시오. 정규식의 경우 Java `Pattern` 자체에 단어 경계와 대소문자 구분을 정의합니다.

**검색 및 교체에 슬라이드 노트의 텍스트도 포함할 수 있나요?**

예. 프레젠테이션 수준 리터럴 텍스트 작업을 사용할 때 [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/#setIncludeNotes)를 `true`로 설정하십시오.

**프레젠테이션을 두 번 스캔하지 않고 보고서를 만들려면 어떻게 해야 하나요?**

하이라이팅 또는 교체 작업에 Java 프록시 콜백을 전달하십시오. 작업 실행 중에 모든 일치를 받으며, 애플리케이션은 원본 텍스트, 일치 텍스트, 위치, 텍스트 프레임 및 유도된 슬라이드 번호를 저장해 나중에 그룹화하거나 내보낼 수 있습니다.

**텍스트 교체 시 서식이 유지되나요?**

[TextFrame::replaceText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceText)와 [TextFrame::replaceRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceRegex)는 기존 텍스트 프레임 내에서 일치 텍스트를 수정하고 주변 부분의 서식을 유지합니다. 일치가 서로 다른 서식이 적용된 영역에 걸쳐 있는 경우, 교체가 원하는 스타일을 사용하도록 결과를 확인하십시오.