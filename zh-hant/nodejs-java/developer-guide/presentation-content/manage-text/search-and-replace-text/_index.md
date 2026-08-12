---
title: 在 JavaScript 中搜尋與取代 PowerPoint 簡報文字
linktitle: 搜尋與取代文字
type: docs
weight: 55
url: /zh-hant/nodejs-java/search-and-replace-text/
keywords:
- 搜尋文字
- 標示文字
- 取代文字
- 正規表示式
- 結果回呼
- 文字框
- 稽核報告
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 簡報中搜尋、標示與取代文字，並收集每一次匹配。"
---
## **概述**

Aspose.Slides for Node.js via Java 可以在單一文字框或整個簡報中搜尋、標示和取代文字。每項操作亦能透過結果回呼 (callback) 通知應用程式每一次匹配。這使得在更新簡報的同時，能建立包含匹配文字、其上下文、位置、文字框與投影片編號的稽核追蹤。

這些功能可用於審閱、塗銷、術語檢查、範本清理與自動化報告工作流程。

在以下的第一個範例中，我們使用名為「sample.pptx」的檔案，其在第一張投影片上包含一個單一文字方塊，文字內容如下：

![範例文字](sample_text.png)

## **選擇搜尋範圍**

使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 上的方法將操作限制於單一文字框。使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 上的方法處理簡報中所有適用的文字。

| 操作 | 單一文字框 | 整個簡報 |
|---|---|---|
| Highlight literal text | [TextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [TextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [TextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **設定文字匹配**

對於純文字操作，使用 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/) 來控制匹配方式：

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) 限制匹配僅為完整單詞。
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) 控制是否必須符合字元大小寫。
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) 包含投影片備註於簡報層級的搜尋、取代與標示操作中。

正規表達式操作使用 Java `Pattern`，因此大小寫敏感性與單詞邊界等匹配規則由表達式本身及其旗標決定。

## **使用回呼收集匹配資訊**

建立 Java 代理 (proxy) 以接收結果回呼，從而在每次匹配時收到通知。代理函式會取得相關的文字框、來源文字、匹配文字以及匹配位置。

回呼不會直接取得投影片編號。以下實作透過 [TextFrame.getSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getSlideNumber--), 與 [NotesSlide.getParentSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notesslide/#getParentSlide--) 推算出編號，並同時處理投影片備註中的文字。

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

對於取代操作，`foundText` 會包含原始匹配的文字，因此回呼能準確記錄哪些術語被取代。

## **標示文字**

使用 [TextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 方法在文字框中標示純文字匹配項。傳入 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/) 以控制搜尋行為。

以下程式碼範例會標示所有出現的字元 **"try"**，接著僅標示完整單詞 **"to"**。

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

    // 在文字框中標示所有出現的「try」字串。
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // 僅標示完整單詞「to」。
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![已標示的文字](highlighted_text.png)

## **使用正規表示式標示文字**

[TextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) 方法會在文字框中標示由正規表示式找到的文字匹配項。

以下程式碼會標示所有包含七個或以上字元的單詞：

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

結果：

![使用正規表示式標示的文字](highlighted_text_using_regex.png)

## **於整份簡報中標示文字**

使用 [Presentation.highlightText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 與 [Presentation.highlightRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) 來搜尋簡報中所有適用的文字框。以下範例會標示一個純文字詞彙以及所有電子郵件地址：

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

## **在文字框中取代文字**

使用 [TextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 取代純文字，使用 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 進行基於模式的取代。這些方法會在現有文字框內更新匹配的文字，保留周圍部分的格式，而不是從純文字重新建立文字框。

以下範例會將拼寫變體標準化，然後取代版本標籤：

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

如果單一匹配跨越不同格式的文字段落，請檢查輸出以確認應套用於取代文字的格式。

## **於整份簡報中取代文字**

使用 [Presentation.replaceText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 與 [Presentation.replaceRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 在簡報中執行相同的操作。這對於範本清理、術語更新與塗銷皆很有用。

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

## **分組匹配以產生報告**

由於每筆收集的結果皆保存其投影片編號與文字框，應用程式可將匹配項分組，以供稽核、報告或審閱工作流程使用。以下範例先依投影片，再依文字框分組結果：

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

## **常見問題**

**如何僅搜尋單一文字方塊而非整個簡報？**

取得形狀的文字框，然後在該文字框上呼叫 [TextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、[TextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)、[TextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 或 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)。簡報層級的方法則會處理所有適用的文字框。

**如何在匹配完整單詞時保留正確的大小寫？**

將 [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) 與 [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) 設為 `true`，並將這些選項傳遞給純文字的標示或取代方法。對於正規表示式，需在 Java `Pattern` 本身中定義單詞邊界與大小寫敏感性。

**搜尋與取代是否能包含投影片備註中的文字？**

可以。於使用簡報層級的純文字操作時，將 [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) 設為 `true`。上述的回呼實作會將備註投影片中的匹配映射回其母投影片的編號。

**如何在不再次掃描簡報的情況下產生報告？**

將 Java 結果回呼代理傳遞給標示或取代操作。回呼會在操作執行期間接收每一次匹配，讓應用程式能儲存來源文字、匹配文字、位置、文字框與推算出的投影片編號，以供後續分組或匯出。

**取代文字是否會保留其格式？**

[TextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 與 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 會在現有文字框內修改匹配文字，並保留周圍段落的格式。若匹配跨越不同格式的段落，請檢查結果以確保取代後的文字使用期望的樣式。