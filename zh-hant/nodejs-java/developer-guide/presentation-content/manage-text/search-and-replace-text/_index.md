---
title: 在 JavaScript 中搜尋與取代 PowerPoint 簡報的文字
linktitle: 搜尋與取代文字
type: docs
weight: 55
url: /zh-hant/nodejs-java/search-and-replace-text/
keywords:
- 搜尋文字
- 標註文字
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
description: "使用 Aspose.Slides for Node.js via Java，在 PowerPoint 簡報中搜尋、標註與取代文字，同時收集每一次匹配。"
---
## **概述**

Aspose.Slides for Node.js via Java 能夠在單一文字框或整個簡報中搜尋、標註與取代文字。每項操作也可以透過結果回呼通知應用程式每一次匹配。這使得在更新簡報的同時，能同時建立包含匹配文字、其上下文、位置、文字框與投影片編號的稽核追蹤。

這些功能可用於審閱、編輯、術語檢查、範本清理與自動化報告工作流程。

在以下第一組範例中，我們使用名為「sample.pptx」的檔案，該檔案在第一張投影片上有一個文字方塊，文字內容如下：

![範例文字](sample_text.png)

## **選擇搜尋範圍**

使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 上的方法將操作限制於單一文字框。使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 上的方法則會處理簡報中全部適用的文字。

| 操作 | 單一文字框 | 整份簡報 |
|---|---|---|
| 標註字面文字 | [TextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 標註正規表示式匹配項目 | [TextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| 取代字面文字 | [TextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 取代正規表示式匹配項目 | [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **設定文字匹配方式**

對於字面文字操作，使用 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/) 來控制匹配行為：

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) 僅限完整單詞匹配。
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) 控制是否必須符合大小寫。
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) 包含投影片備註於簡報層級的搜尋、取代與標註作業。

正規表示式作業使用 Java `Pattern`，因此大小寫敏感度與單詞邊界等規則皆由表達式本身及其旗標定義。

## **辨識文字框的擁有者**

通用的文字處理工作流程在搜尋、取代、驗證或匯出文字時，常會收到一個 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。使用 [TextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#getParentShape--) 與 [TextFrame.getParentCell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#getParentCell--) 來判斷是哪個簡報物件擁有此文字框。

預期的返回值取決於擁有者：

| 文字框擁有者 | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape 或其他含文字的圖形 | 其擁有的 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) | `null` |
| 表格儲存格 | `null` | 其擁有的 [Cell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cell/) |

兩個方法均提供唯讀的導覽。呼叫它們不會移動文字框或改變其擁有者。通用程式碼應檢查兩個返回值是否為 `null`，並處理兩者均不可用的情況。

以下範例使用 [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) 迭代簡報中的所有文字框。對於圖形，它會回報圖形名稱、Java 執行時類型與所屬投影片；對於表格儲存格，則回報零基礎的欄與列座標以及所屬投影片。

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

對於 SmartArt 內容，請迭代 [SmartArtNode.getShapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartartnode/#getShapes--) 中的圖形，並存取每個 [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartartshape/#getTextFrame--)。文字框可透過 [TextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#getParentShape--) 追溯至其關聯的圖形，而 [TextFrame.getParentCell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#getParentCell--) 會返回 `null`。因此，範例中的圖形分支同樣處理 SmartArt 節點的文字。

## **使用回呼收集匹配資訊**

建立一個 Java 代理作為結果回呼，以接收每一次匹配的通知。代理函式會取得相關的文字框、來源文字、匹配文字以及匹配位置。

回呼不會直接收到投影片編號。下方實作透過文字框的擁有圖形或表格儲存格推導投影片編號，若無則以 [TextFrame.getSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#getSlide--) 作為備援。它也會處理投影片備註中的文字。

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

對於取代作業，`foundText` 內含原始匹配文字，回呼因此可記錄到底替換了哪些詞彙。

## **標註文字**

使用 [TextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 方法在文字框中標註字面文字匹配項目。傳入 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/) 以控制搜尋行為。

以下程式碼示範先標註所有 **"try"** 字元出現，然後僅標註完整單詞 **"to"**。

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

    // 在文字框中標註每一次出現的 "try"。
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // 僅標註完整單詞 "to"。
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![已標註的文字](highlighted_text.png)

## **使用正規表示式標註文字**

[TextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) 方法會標註文字框中符合正規表示式的文字匹配項目。

以下程式碼標註所有長度不少於七個字元的單詞：

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

![使用正規表示式標註的文字](highlighted_text_using_regex.png)

## **跨簡報標註文字**

使用 [Presentation.highlightText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 與 [Presentation.highlightRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) 來搜尋並標註簡報中所有適用的文字框。以下範例同時標註一個字面詞彙與所有電子郵件地址：

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

使用 [TextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 處理字面文字，使用 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 處理模式取代。這些方法會在既有文字框內直接更新匹配文字，保留周圍文字的格式，而非以純文字重新建立文字框。

以下範例先統一拼寫變體，接著取代版本標籤：

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

如果一次匹配跨越不同格式的區段，請檢查輸出以確認替換文字應使用哪種格式。

## **跨簡報取代文字**

使用 [Presentation.replaceText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 與 [Presentation.replaceRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 於整個簡報執行相同操作。此功能適用於範本清理、術語更新與編輯遮蔽。

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

## **將匹配結果分組以供報告**

由於每筆收集的結果都儲存了投影片編號與文字框，應用程式可以依此將匹配項目分組，用於稽核、報告或審閱工作流程。以下範例先依投影片再依文字框分組結果：

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

## **常見問題**

**如何只搜尋單一文字方塊而非整份簡報？**

取得圖形的文字框，然後對該文字框呼叫 [TextFrame.highlightText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、[TextFrame.highlightRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)、[TextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 或 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)。簡報層級的方法則會處理所有適用的文字框。

**如何在匹配完整單詞時同時保留正確的大小寫？**

將 [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) 與 [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) 設為 `true`，並將選項傳入字面文字的標註或取代方法。對於正規表示式，請在 Java `Pattern` 本身中定義單詞邊界與大小寫敏感度。

**搜尋與取代可以包含投影片備註中的文字嗎？**

可以。於簡報層級的字面文字作業中，將 [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) 設為 `true`。上述的回呼實作會將備註投影片中的匹配映射回其父投影片編號。

**如何在不重新掃描簡報的情況下產生報告？**

將 Java 結果回呼代理傳入標註或取代作業。回呼會在作業執行期間收到每一次匹配，因而讓應用程式即時儲存來源文字、匹配文字、位置、文字框與衍生的投影片編號，以供之後分組或匯出。

**取代文字時會保留原有格式嗎？**

[TextFrame.replaceText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 與 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 會在既有文字框內直接修改匹配文字，並保留其周圍部分的格式。如果一次匹配跨越不同格式的區段，請檢查結果以確保替換文字使用期望的樣式。