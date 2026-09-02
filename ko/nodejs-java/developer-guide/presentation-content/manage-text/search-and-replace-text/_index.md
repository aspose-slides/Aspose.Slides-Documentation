---
title: JavaScript를 사용한 PowerPoint 프레젠테이션에서 텍스트 검색 및 교체
linktitle: 텍스트 검색 및 교체
type: docs
weight: 55
url: /ko/nodejs-java/search-and-replace-text/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 프레젠테이션에서 텍스트를 검색, 강조 및 교체하고 각 일치를 수집합니다."
---
## **개요**

Aspose.Slides for Node.js via Java는 개별 텍스트 프레임 또는 전체 프레젠테이션에서 텍스트를 검색, 강조 및 교체할 수 있습니다. 각 작업은 결과 콜백을 통해 일치 항목마다 애플리케이션에 알릴 수 있습니다. 이를 통해 프레젠테이션을 업데이트하면서 일치한 텍스트, 컨텍스트, 위치, 텍스트 프레임 및 슬라이드 번호를 포함한 감사 추적을 동시에 작성할 수 있습니다.

이러한 기능은 검토, 삭제, 용어 확인, 템플릿 정리 및 자동 보고 워크플로에 유용합니다.

아래 첫 번째 예제에서는 첫 슬라이드에 단일 텍스트 상자가 포함된 "sample.pptx" 파일을 사용합니다. 텍스트는 다음과 같습니다:

![샘플 텍스트](sample_text.png)

## **검색 범위 선택**

[TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/) 메서드를 사용하여 작업을 하나의 텍스트 프레임으로 제한합니다. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 메서드를 사용하여 프레젠테이션 내 모든 적용 가능한 텍스트를 처리합니다.

| 작업 | 단일 텍스트 프레임 | 전체 프레젠테이션 |
|---|---|---|
| 리터럴 텍스트 강조 | [TextFrame.highlightText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 정규식 일치 강조 | [TextFrame.highlightRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| 리터럴 텍스트 교체 | [TextFrame.replaceText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 정규식 일치 교체 | [TextFrame.replaceRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **텍스트 매칭 구성**

리터럴 텍스트 작업에서는 일치를 제어하기 위해 [TextSearchOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/)를 사용합니다:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) 전체 단어만 일치하도록 제한합니다.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) 문자 대소문자를 일치시켜야 하는지를 제어합니다.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) 프레젠테이션 수준 검색, 교체 및 강조 작업에 슬라이드 노트를 포함합니다.

정규식 작업은 Java `Pattern`을 사용하므로 대소문자 구분 및 단어 경계와 같은 일치 규칙은 표현식 및 플래그에 의해 정의됩니다.

## **콜백을 사용한 일치 정보 수집**

결과 콜백에 대한 Java 프록시를 생성하여 모든 일치에 대한 알림을 받습니다. 프록시 함수는 관련 텍스트 프레임, 원본 텍스트, 일치한 텍스트 및 일치 위치를 전달받습니다.

콜백은 슬라이드 번호를 직접 제공하지 않습니다. 아래 구현은 [TextFrame.getSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/#getSlideNumber--), 및 [NotesSlide.getParentSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/notesslide/#getParentSlide--)을 통해 파생합니다. 또한 슬라이드 노트에 있는 텍스트도 처리합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

교체 작업의 경우 `foundText`에 원본 일치 텍스트가 포함되므로 콜백에서 정확히 어떤 용어가 교체되었는지 기록할 수 있습니다.

## **텍스트 강조**

[TextFrame.highlightText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 메서드를 사용하여 텍스트 프레임 내 리터럴 텍스트 일치를 강조합니다. 검색을 제어하려면 [TextSearchOptions]를 전달합니다.

아래 코드 예제는 **"try"** 문자를 모두 강조하고, 이어서 전체 단어 **"to"**만 강조합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // 텍스트 프레임에서 "try"의 모든 발생을 강조합니다.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // 전체 단어 "to"만 강조합니다.
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![강조된 텍스트](highlighted_text.png)

## **정규식을 사용한 텍스트 강조**

[TextFrame.highlightRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) 메서드는 정규식으로 찾은 텍스트 일치를 텍스트 프레임에서 강조합니다.

다음 코드는 7자 이상인 모든 단어를 강조합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![정규식을 사용한 강조 텍스트](highlighted_text_using_regex.png)

## **프레젠테이션 전체에서 텍스트 강조**

[Presentation.highlightText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 및 [Presentation.highlightRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)을 사용하여 프레젠테이션의 모든 적용 가능한 텍스트 프레임을 검색합니다. 다음 예제는 리터럴 용어와 모든 이메일 주소를 강조합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **텍스트 프레임에서 텍스트 교체**

리터럴 텍스트에는 [TextFrame.replaceText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)를, 패턴 기반 교체에는 [TextFrame.replaceRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)를 사용합니다. 이러한 메서드는 기존 텍스트 프레임 내에서 일치 텍스트를 업데이트하므로 주변 부분의 형식을 유지하면서 문자열을 다시 구성하지 않습니다.

다음 예제는 철자 변형을 표준화하고 버전 라벨을 교체합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

하나의 일치가 서로 다른 형식의 부분을 포함하는 경우, 교체 텍스트에 적용할 형식을 확인하기 위해 출력을 검토하십시오.

## **프레젠테이션 전체에서 텍스트 교체**

[Presentation.replaceText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 및 [Presentation.replaceRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)을 사용하여 프레젠테이션 전체에 동일한 작업을 적용합니다. 이는 템플릿 정리, 용어 업데이트 및 삭제에 유용합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **보고를 위한 일치 그룹화**

각 수집된 결과가 슬라이드 번호와 텍스트 프레임을 저장하므로 애플리케이션은 감사, 보고 또는 검토 워크플로를 위해 일치를 그룹화할 수 있습니다. 다음 예제는 결과를 먼저 슬라이드별로, 그 다음 텍스트 프레임별로 그룹화합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**전체 프레젠테이션이 아닌 단일 텍스트 상자만 검색하려면 어떻게 해야 하나요?**

해당 모양의 텍스트 프레임을 가져와서 그 텍스트 프레임에 대해 [TextFrame.highlightText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), 또는 [TextFrame.replaceRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 메서드를 호출합니다. 프레젠테이션 수준 메서드는 모든 적용 가능한 텍스트 프레임을 처리합니다.

**전체 단어를 정확한 대소문자로 매치하려면 어떻게 해야 하나요?**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-)와 [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-)를 `true`로 설정하고 옵션을 리터럴 텍스트 강조 또는 교체 메서드에 전달합니다. 정규식의 경우 Java `Pattern` 자체에 단어 경계와 대소문자 구분을 정의합니다.

**검색 및 교체에 슬라이드 노트의 텍스트도 포함할 수 있나요?**

예. 프레젠테이션 수준 리터럴 텍스트 작업을 사용할 때 [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-)를 `true`로 설정합니다. 위의 콜백 구현은 노트 슬라이드의 일치를 해당 부모 슬라이드 번호로 매핑합니다.

**프레젠테이션을 두 번 스캔하지 않고 보고서를 만들려면 어떻게 해야 하나요?**

강조 또는 교체 작업에 Java 결과 콜백 프록시를 전달합니다. 콜백은 작업이 실행되는 동안 모든 일치를 받으며, 애플리케이션은 원본 텍스트, 일치 텍스트, 위치, 텍스트 프레임 및 파생된 슬라이드 번호를 저장해 나중에 그룹화하거나 내보낼 수 있습니다.

**텍스트를 교체하면 형식이 유지되나요?**

[TextFrame.replaceText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)와 [TextFrame.replaceRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)는 기존 텍스트 프레임 내에서 일치 텍스트를 수정하고 주변 부분 형식을 유지합니다. 일치가 서로 다른 형식 영역을 아우르는 경우, 교체 텍스트에 원하는 스타일이 적용되는지 결과를 확인하십시오.