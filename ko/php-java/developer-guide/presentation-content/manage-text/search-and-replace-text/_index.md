---
title: PHP에서 PowerPoint 프레젠테이션 텍스트 검색 및 교체
linktitle: 텍스트 검색 및 교체
type: docs
weight: 55
url: /ko/php-java/search-and-replace-text/
keywords:
- 텍스트 검색
- 텍스트 강조
- 텍스트 교체
- 정규식
- 결과 콜백
- 텍스트 프레임
- 감사 보고서
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션에서 텍스트를 검색, 강조 및 교체하고 모든 일치를 수집합니다."
---
## **개요**

Aspose.Slides for PHP via Java는 개별 텍스트 프레임 또는 전체 프레젠테이션에서 텍스트를 검색, 강조 및 교체할 수 있습니다. 각 작업은 결과 콜백을 통해 모든 일치를 애플리케이션에 알릴 수 있습니다. 이를 통해 프레젠테이션을 업데이트하면서 일치한 텍스트, 해당 컨텍스트, 위치, 텍스트 프레임 및 슬라이드 번호를 포함하는 감사 로그를 동시에 구축할 수 있습니다.

이러한 기능은 검토, 검열, 용어 확인, 템플릿 정리 및 자동 보고 워크플로에 유용합니다.

아래 첫 번째 예시에서는 **sample.pptx**라는 파일을 사용합니다. 이 파일은 첫 번째 슬라이드에 단일 텍스트 상자가 있으며 다음과 같은 텍스트를 포함하고 있습니다:

![샘플 텍스트](sample_text.png)

## **검색 범위 선택**

[TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)의 메서드를 사용하여 작업을 단일 텍스트 프레임에 제한합니다. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/)의 메서드를 사용하면 프레젠테이션의 모든 적용 가능한 텍스트를 처리합니다.

| 작업 | 단일 텍스트 프레임 | 전체 프레젠테이션 |
|---|---|---|
| 리터럴 텍스트 강조 | [TextFrame::highlightText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#highlightText) |
| 정규식 일치 강조 | [TextFrame::highlightRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#highlightRegex) |
| 리터럴 텍스트 교체 | [TextFrame::replaceText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#replaceText) |
| 정규식 일치 교체 | [TextFrame::replaceRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#replaceRegex) |

## **텍스트 매칭 구성**

리터럴 텍스트 작업의 경우 [TextSearchOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/)을 사용하여 매칭을 제어합니다.

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 는 일치를 전체 단어로 제한합니다.  
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) 는 대소문자 일치를 제어합니다.  
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) 는 프레젠테이션 수준 검색, 교체 및 강조 작업에 슬라이드 노트를 포함합니다.

정규식 작업은 Java `Pattern`을 사용하므로 대소문자 구분 및 단어 경계와 같은 매칭 규칙은 표현식 및 플래그에 의해 정의됩니다.

## **텍스트 프레임 소유자 식별**

일반 텍스트 처리 워크플로는 검색, 교체, 검증 또는 내보내기 시 종종 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)을 받습니다. [TextFrame::getParentShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#getParentShape) 및 [TextFrame::getParentCell](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#getParentCell) 를 사용하여 텍스트 프레임을 소유한 프레젠테이션 객체를 확인합니다.

예상되는 값은 소유자에 따라 달라집니다:

| 텍스트 프레임 소유자 | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape 또는 다른 텍스트 포함 도형 | 소유하는 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) | `null` |
| 테이블 셀 | `null` | 소유하는 [Cell](https://reference.aspose.com/slides/ko/php-java/aspose.slides/cell/) |

두 메서드는 읽기 전용 탐색을 제공합니다. 호출해도 텍스트 프레임이 이동하거나 소유자가 변경되지 않습니다. 일반 코드는 `java_is_null` 로 두 값을 확인하고 두 소유자가 모두 없을 가능성을 처리해야 합니다.

다음 예시는 [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slideutil/#getAllTextFrames) 를 사용해 프레젠테이션의 텍스트 프레임을 순회합니다. 도형에 대해서는 도형 이름, Java 런타임 타입 및 포함 슬라이드를 보고합니다. 테이블 셀에 대해서는 0 기반 열·행 좌표와 포함 슬라이드를 보고합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

SmartArt 콘텐츠의 경우 [SmartArtNode::getShapes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartnode/#getShapes) 에서 도형을 순회하고 각 [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/smartartshape/#getTextFrame) 에 접근합니다. 텍스트 프레임은 [TextFrame::getParentShape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#getParentShape) 로 연결된 도형을 추적할 수 있으며, [TextFrame::getParentCell](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#getParentCell) 은 `null` 을 반환합니다. 따라서 예시의 도형 분기는 SmartArt 노드의 텍스트도 처리합니다.

## **콜백으로 일치 정보 수집**

강조 또는 교체 메서드에 Java 프록시 콜백을 전달하면 모든 일치에 대해 알림을 받을 수 있습니다. 콜백 메서드는 관련 텍스트 프레임, 원본 텍스트, 일치 텍스트 및 일치 위치를 매개변수로 받습니다.

콜백은 슬라이드 번호를 직접 받지 않으며, 아래 구현은 부모 슬라이드에서 번호를 유도하고 슬라이드 노트에 있는 텍스트도 처리합니다. 결과 배열은 텍스트가 다른 슬라이드 유형에 연결된 경우 `null` 을 사용합니다.

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
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

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

이 PHP 객체에 대한 프록시를 만든 후 작업에 전달하십시오:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

교체 작업의 경우 `foundText` 가 원본 일치 텍스트를 포함하므로 콜백에서 정확히 어떤 용어가 교체되었는지 기록할 수 있습니다.

## **텍스트 강조**

[TextFrame::highlightText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#highlightText) 메서드를 사용해 텍스트 프레임에서 리터럴 텍스트 일치를 강조합니다. 검색을 제어하려면 [TextSearchOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/) 를 전달합니다.

아래 코드 예시는 문자 **"try"** 의 모든 발생을 강조한 뒤, 전체 단어 **"to"** 만 강조합니다.

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

    // 텍스트 프레임에서 "try"가 나타나는 모든 경우를 강조합니다.
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

    // 전체 단어 "to"만 강조합니다.
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

![강조된 텍스트](highlighted_text.png)

## **정규식을 사용한 텍스트 강조**

[TextFrame::highlightRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#highlightRegex) 메서드는 정규식으로 찾은 텍스트 일치를 강조합니다.

다음 코드는 7자 이상인 모든 단어를 강조합니다:

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

![정규식을 사용한 강조된 텍스트](highlighted_text_using_regex.png)

## **프레젠테이션 전체에서 텍스트 강조**

[Presentation::highlightText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#highlightText) 와 [Presentation::highlightRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#highlightRegex) 를 사용해 프레젠테이션의 모든 적용 가능한 텍스트 프레임을 검색합니다. 다음 예시는 리터럴 용어와 모든 이메일 주소를 강조합니다:

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

리터럴 텍스트 교체에는 [TextFrame::replaceText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceText)를, 패턴 기반 교체에는 [TextFrame::replaceRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceRegex)를 사용합니다. 이러한 메서드는 기존 텍스트 프레임 내에서 일치 텍스트를 업데이트하므로 주변 부분 서식을 유지하고 전체 문자열로 프레임을 재구성하지 않습니다.

다음 예시는 철자 변형을 표준화한 뒤 버전 라벨을 교체합니다:

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

하나의 일치가 서로 다른 서식 구역에 걸쳐 있는 경우, 교체 텍스트에 적용할 서식을 확인하기 위해 출력을 검토하십시오.

## **프레젠테이션 전체에서 텍스트 교체**

[Presentation::replaceText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#replaceText) 와 [Presentation::replaceRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#replaceRegex) 를 사용해 프레젠테이션 전체에 동일한 작업을 적용합니다. 이는 템플릿 정리, 용어 업데이트 및 검열에 유용합니다.

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

각 결과가 슬라이드 번호와 텍스트 프레임을 저장하므로, 애플리케이션은 감사, 보고 또는 검토 워크플로를 위해 일치를 그룹화할 수 있습니다. 다음 예시는 수집된 결과를 먼저 슬라이드별, 다음 텍스트 프레임별로 그룹화합니다:

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

**전체 프레젠테이션이 아니라 단일 텍스트 상자만 검색하려면 어떻게 해야 하나요?**

텍스트 상자의 텍스트 프레임을 가져와 해당 프레임에서 [TextFrame::highlightText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceText) 또는 [TextFrame::replaceRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceRegex) 를 호출합니다. 프레젠테이션 수준 메서드는 모든 적용 가능한 텍스트 프레임을 처리합니다.

**전체 단어를 올바른 대소문자로 매치하려면 어떻게 해야 하나요?**

[TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 및 [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) 를 `true` 로 설정하고, 옵션을 리터럴 텍스트 강조 또는 교체 메서드에 전달합니다. 정규식의 경우 Java `Pattern` 자체에 단어 경계와 대소문자 구분을 정의합니다.

**검색 및 교체에 슬라이드 노트의 텍스트도 포함할 수 있나요?**

예. 프레젠테이션 수준 리터럴 텍스트 작업을 사용할 때 [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) 를 `true` 로 설정합니다.

**프레젠테이션을 두 번째로 스캔하지 않고 보고서를 만들려면 어떻게 해야 하나요?**

강조 또는 교체 작업에 Java 프록시 콜백을 전달하십시오. 작업이 실행되는 동안 모든 일치를 수신하므로 애플리케이션은 원본 텍스트, 일치 텍스트, 위치, 텍스트 프레임 및 유도된 슬라이드 번호를 저장해 나중에 그룹화하거나 내보낼 수 있습니다.

**텍스트 교체 시 서식이 유지되나요?**

[TextFrame::replaceText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceText) 와 [TextFrame::replaceRegex](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/#replaceRegex) 은 기존 텍스트 프레임 내에서 일치 텍스트를 수정하고 주변 부분 서식을 유지합니다. 일치가 서로 다른 서식 구역에 걸쳐 있는 경우, 교체 텍스트에 원하는 스타일이 적용되었는지 결과를 검사하십시오.