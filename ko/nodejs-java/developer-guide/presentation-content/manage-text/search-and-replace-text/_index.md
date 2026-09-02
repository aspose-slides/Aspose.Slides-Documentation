---
title: JavaScript에서 PowerPoint 프레젠테이션의 텍스트 검색 및 교체
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
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 프레젠테이션의 텍스트를 검색, 강조 및 교체하면서 모든 매치를 수집합니다."
---
## **개요**

Aspose.Slides for Node.js via Java은 개별 텍스트 프레임 또는 전체 프레젠테이션에서 텍스트를 검색, 강조 및 교체할 수 있습니다. 각 작업은 결과 콜백을 통해 모든 매치에 대해 애플리케이션에 알릴 수 있습니다. 이를 통해 프레젠테이션을 업데이트하면서 매치된 텍스트, 컨텍스트, 위치, 텍스트 프레임 및 슬라이드 번호를 포함한 감사 추적을 동시에 구축할 수 있습니다.

이 기능은 검토, 민감 정보 삭제, 용어 검사, 템플릿 정리 및 자동 보고 워크플로에 유용합니다.

아래 첫 번째 예제에서는 첫 번째 슬라이드에 단일 텍스트 상자가 포함된 "sample.pptx" 파일을 사용합니다.

![샘플 텍스트](sample_text.png)

## **검색 범위 선택**

[TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/) 메서드를 사용하여 작업을 단일 텍스트 프레임에 제한하고, [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 메서드를 사용하여 프레젠테이션 전체의 적용 가능한 텍스트를 처리합니다.

| 작업 | 단일 텍스트 프레임 | 전체 프레젠테이션 |
|---|---|---|
| 리터럴 텍스트 강조 | [TextFrame.highlightText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 정규식 일치 강조 | [TextFrame.highlightRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| 리터럴 텍스트 교체 | [TextFrame.replaceText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 정규식 일치 교체 | [TextFrame.replaceRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **텍스트 일치 구성**

리터럴 텍스트 작업의 경우, [TextSearchOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/)을 사용하여 일치를 제어합니다.

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-)은 매치를 전체 단어에만 제한합니다.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-)은 대소문자 구분 여부를 제어합니다.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-)은 프레젠테이션 수준 검색, 교체 및 강조 작업에 슬라이드 노트를 포함합니다.

정규식 작업은 Java `Pattern`을 사용하므로, 대소문자 구분 및 단어 경계와 같은 일치 규칙은 표현식 및 플래그에 의해 정의됩니다.

## **텍스트 프레임 소유자 식별**

일반 텍스트 처리 워크플로는 종종 [TextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/)을 받아 검색, 교체, 검증 또는 내보내기를 수행합니다. [TextFrame.getParentShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getParentShape--)와 [TextFrame.getParentCell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getParentCell--)를 사용하여 텍스트 프레임을 소유한 프레젠테이션 개체를 확인합니다.

예상값은 소유자에 따라 달라집니다.

| 텍스트 프레임 소유자 | `getParentShape` | `getParentCell` |
|---|---|---|
| 자동 도형 또는 다른 텍스트 포함 도형 | 소유 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) | `null` |
| 표 셀 | `null` | 소유 [Cell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/cell/) |

두 메서드는 읽기 전용 탐색을 제공하며, 호출해도 텍스트 프레임이 이동하거나 소유자가 변경되지 않습니다. 일반 코드는 두 값을 모두 `null`인지 확인하고, 어느 소유자도 없을 가능성을 처리해야 합니다.

다음 예제는 [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-)을 사용해 프레젠테이션의 텍스트 프레임을 순회합니다. 도형에 대해선 도형 이름, Java 런타임 타입 및 포함 슬라이드를 보고, 표 셀에 대해선 0부터 시작하는 열 및 행 좌표와 포함 슬라이드를 보고합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideLabel(baseSlide) {
    if (java.instanceOf(baseSlide, "com.aspose.slides.Slide")) {
        return "slide " + baseSlide.getSlideNumber();
    }

    if (java.instanceOf(baseSlide, "com.aspose.slides.NotesSlide")) {
        return "notes for slide " + baseSlide.getParentSlide().getSlideNumber();
    }

    return baseSlide.getClass().getSimpleName();
}

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, false);

    for (let index = 0; index < textFrames.length; index++) {
        const textFrame = textFrames[index];
        const ownerShape = textFrame.getParentShape();
        if (ownerShape !== null) {
            const shapeName = ownerShape.getName() === "" ? "(unnamed)" : ownerShape.getName();
            const shapeType = ownerShape.getClass().getSimpleName();
            const slideLabel = getSlideLabel(ownerShape.getSlide());
            console.log("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        const ownerCell = textFrame.getParentCell();
        if (ownerCell !== null) {
            const slideLabel = getSlideLabel(ownerCell.getSlide());
            console.log("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        console.log("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

SmartArt 콘텐츠의 경우, [SmartArtNode.getShapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartartnode/#getShapes--)에서 도형을 순회하고 각 [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartartshape/#getTextFrame--)에 접근합니다. 텍스트 프레임은 [TextFrame.getParentShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getParentShape--)을 통해 연관된 도형으로 추적할 수 있으며, [TextFrame.getParentCell](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getParentCell--)은 `null`을 반환합니다. 따라서 예제의 도형 분기에서도 SmartArt 노드의 텍스트를 처리합니다.

## **콜백을 사용한 매치 정보 수집**

결과 콜백을 위한 Java 프록시를 생성하여 모든 매치에 대한 알림을 받습니다. 프록시 함수는 관련 텍스트 프레임, 원본 텍스트, 매치된 텍스트 및 매치 위치를 전달받습니다.

콜백은 슬라이드 번호를 직접 받지 않으며, 아래 구현에서는 텍스트 프레임의 소유 도형 또는 표 셀을 통해 슬라이드 번호를 파생하고, 대체 수단으로 [TextFrame.getSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getSlide--)를 사용합니다. 또한 슬라이드 노트에 있는 텍스트도 처리합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

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

교체 작업의 경우, `foundText`는 원본 매치된 텍스트를 포함하므로 콜백은 정확히 어떤 용어가 교체되었는지 기록할 수 있습니다.

## **텍스트 강조**

[TextFrame.highlightText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 메서드를 사용해 텍스트 프레임 내 리터럴 텍스트 매치를 강조합니다. 검색을 제어하려면 [TextSearchOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/)를 전달합니다.

아래 코드 예제는 **"try"** 문자 전체를 강조한 뒤, 전체 단어 **"to"**만 강조합니다.

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

    // 텍스트 프레임에서 "try"가 나타나는 모든 경우를 강조합니다.
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

[TextFrame.highlightRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) 메서드는 정규식으로 찾은 텍스트 매치를 강조합니다.

다음 코드는 7자 이상인 모든 단어를 강조합니다.

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

![정규식을 사용한 강조된 텍스트](highlighted_text_using_regex.png)

## **프레젠테이션 전체 텍스트 강조**

[Presentation.highlightText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)와 [Presentation.highlightRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)를 사용해 프레젠테이션의 모든 적용 가능한 텍스트 프레임을 검색하고 강조합니다. 아래 예제는 리터럴 용어와 모든 이메일 주소를 강조합니다.

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

리터럴 텍스트는 [TextFrame.replaceText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)를, 패턴 기반 교체는 [TextFrame.replaceRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)를 사용합니다. 이 메서드들은 기존 텍스트 프레임 내 매치된 텍스트를 업데이트하므로 주변 서식이 유지됩니다.

아래 예제는 철자 변형을 표준화하고 버전 레이블을 교체합니다.

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

하나의 매치가 서로 다른 서식이 적용된 부분을 포함하는 경우, 교체 텍스트에 적용할 서식을 확인하기 위해 출력을 검토하십시오.

## **프레젠테이션 전체 텍스트 교체**

[Presentation.replaceText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)와 [Presentation.replaceRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)를 사용해 프레젠테이션 전체에 동일한 작업을 적용합니다. 이는 템플릿 정리, 용어 업데이트 및 민감 정보 삭제에 유용합니다.

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

## **보고서를 위한 매치 그룹화**

각 수집된 결과는 슬라이드 번호와 텍스트 프레임을 저장하므로, 애플리케이션은 매치를 감사, 보고 또는 검토 워크플로에 맞게 그룹화할 수 있습니다. 아래 예제는 결과를 먼저 슬라이드별, 그 다음 텍스트 프레임별로 그룹화합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

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

**하나의 텍스트 상자만 검색하고 전체 프레젠테이션을 검색하지 않으려면 어떻게 해야 하나요?**

해당 도형의 텍스트 프레임을 가져와서 그 텍스트 프레임에 대해 [TextFrame.highlightText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), 또는 [TextFrame.replaceRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)를 호출합니다. 프레젠테이션 수준 메서드는 모든 적용 가능한 텍스트 프레임을 처리합니다.

**전체 단어를 정확한 대소문자로 매치하려면 어떻게 해야 하나요?**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-)와 [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-)를 `true`로 설정하고, 옵션을 리터럴 텍스트 강조 또는 교체 메서드에 전달합니다. 정규식의 경우 Java `Pattern` 자체에 단어 경계와 대소문자 구분을 정의합니다.

**검색 및 교체에 슬라이드 노트의 텍스트도 포함할 수 있나요?**

예. 프레젠테이션 수준 리터럴 텍스트 작업을 사용할 때 [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-)를 `true`로 설정합니다. 위 콜백 구현은 노트 슬라이드의 매치를 부모 슬라이드 번호에 매핑합니다.

**프레젠테이션을 두 번째로 스캔하지 않고 보고서를 만들려면 어떻게 해야 하나요?**

강조 또는 교체 작업에 Java 결과 콜백 프록시를 전달합니다. 콜백은 작업이 진행되는 동안 모든 매치를 수신하므로, 애플리케이션은 원본 텍스트, 매치된 텍스트, 위치, 텍스트 프레임 및 파생된 슬라이드 번호를 저장해 나중에 그룹화하거나 내보낼 수 있습니다.

**텍스트 교체 시 서식이 유지되나요?**

[TextFrame.replaceText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)와 [TextFrame.replaceRegex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)는 기존 텍스트 프레임 내 매치된 텍스트를 수정하고 주변 서식을 보존합니다. 매치가 서로 다른 서식이 적용된 부분을 포함하는 경우, 교체 텍스트가 원하는 스타일을 사용하는지 결과를 확인하십시오.