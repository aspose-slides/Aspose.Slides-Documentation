---
title: 在 JavaScript 中搜索和替换 PowerPoint 演示文稿的文本
linktitle: 搜索和替换文本
type: docs
weight: 55
url: /zh/nodejs-java/search-and-replace-text/
keywords:
- 搜索文本
- 突出显示文本
- 替换文本
- 正则表达式
- 结果回调
- 文本框
- 审计报告
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 PowerPoint 演示文稿中搜索、突出显示和替换文本，同时使用 Aspose.Slides for Node.js via Java 收集每一次匹配。"
---
## **概述**

Aspose.Slides for Node.js via Java 可以在单个文本框或整个演示文稿中搜索、突出显示和替换文本。每个操作还可以通过结果回调通知应用程序每一次匹配。这使得在更新演示文稿的同时能够创建包含匹配文本、其上下文、位置、文本框和幻灯片编号的审计日志。

这些功能对于审阅、编辑、术语检查、模板清理和自动化报告工作流非常有用。

在下面的第一个示例中，我们使用名为 **"sample.pptx"** 的文件，该文件在第一页上包含一个带有以下文本的单个文本框：

![示例文本](sample_text.png)

## **选择搜索范围**

使用 [TextFrame]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/）上的方法将操作限制在一个文本框内。使用 [Presentation]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/）上的方法处理演示文稿中所有适用的文本。

| 操作 | 单个文本框 | 整个演示文稿 |
|---|---|---|
| 突出显示字面文本 | [TextFrame.highlightText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 突出显示正则表达式匹配 | [TextFrame.highlightRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| 替换字面文本 | [TextFrame.replaceText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 替换正则表达式匹配 | [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **配置文本匹配**

对于字面文本操作，请使用 [TextSearchOptions]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textsearchoptions/）来控制匹配方式：

- [TextSearchOptions.setWholeWordsOnly]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-）限制仅匹配完整单词。
- [TextSearchOptions.setCaseSensitive]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-）控制是否必须匹配字符大小写。
- [TextSearchOptions.setIncludeNotes]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-）在演示文稿级别的搜索、替换和突出显示操作中包含幻灯片备注。

正则表达式操作使用 Java `Pattern`，因此诸如大小写敏感性和单词边界等匹配规则由表达式本身及其标志决定。

## **使用回调收集匹配信息**

为结果回调创建一个 Java 代理，以便在每次匹配时收到通知。代理函数会接收相关的文本框、源文本、匹配文本以及匹配位置。

回调不会直接收到幻灯片编号。下面的实现通过 [TextFrame.getSlide]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#getSlide--）、[Slide.getSlideNumber]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#getSlideNumber--）和 [NotesSlide.getParentSlide]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notesslide/#getParentSlide--）获得它，并且还能处理幻灯片备注中的文本。

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

对于替换操作，`foundText` 包含原始匹配文本，回调因此可以准确记录被替换的术语。

## **突出显示文本**

使用 [TextFrame.highlightText]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-）方法在文本框中突出显示字面文本匹配。通过传入 [TextSearchOptions] 来控制搜索行为。

下面的代码示例首先突出显示所有 **"try"** 字符，然后仅突出显示完整单词 **"to"**。

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

    // 在文本框中突出显示每一次出现的 "try"。
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // 仅突出显示完整单词 "to"。
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![突出显示的文本](highlighted_text.png)

## **使用正则表达式突出显示文本**

[TextFrame.highlightRegex]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-）方法可以在文本框中突出显示正则表达式找到的文本匹配。

下面的代码突出显示所有包含七个或以上字符的单词：

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

结果：

![使用正则表达式突出显示的文本](highlighted_text_using_regex.png)

## **跨演示文稿突出显示文本**

使用 [Presentation.highlightText]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-）和 [Presentation.highlightRegex]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-）在演示文稿的所有适用文本框中进行搜索。以下示例突出显示一个字面词汇以及所有电子邮件地址：

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

## **在文本框中替换文本**

使用 [TextFrame.replaceText]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-）处理字面文本，使用 [TextFrame.replaceRegex]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-）进行基于模式的替换。这些方法在现有文本框内更新匹配的文本，保留周围文本的格式，而不是从纯字符串重新构建文本框。

下面的示例统一了拼写变体，然后替换了版本标签：

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

如果一次匹配跨越了格式不同的部分，请检查输出以确认应该对替换文本使用哪种格式。

## **跨演示文稿替换文本**

使用 [Presentation.replaceText]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-）和 [Presentation.replaceRegex]（https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-）在整个演示文稿中执行相同的操作。这对于模板清理、术语更新和编辑非常有用。

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

## **将匹配项分组用于报告**

因为每个收集的结果都会存储其幻灯片编号和文本框，应用程序可以将匹配项按幻灯片再按文本框进行分组，以便审计、报告或审阅工作流使用。下面的示例先按幻灯片再按文本框对结果进行分组：

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

## **常见问题**

**如何只搜索单个文本框而不是整个演示文稿？**

获取形状的文本框并在该文本框上调用 [TextFrame.highlightText]、[TextFrame.highlightRegex]、[TextFrame.replaceText] 或 [TextFrame.replaceRegex]。演示文稿级别的方法会处理所有适用的文本框。

**如何匹配完整单词并保持正确的大小写？**

将 [TextSearchOptions.setWholeWordsOnly] 和 [TextSearchOptions.setCaseSensitive] 均设置为 `true`，并将选项传递给字面文本的突出显示或替换方法。对于正则表达式，在 Java `Pattern` 本身中定义单词边界和大小写敏感性。

**搜索和替换是否可以包括幻灯片备注中的文本？**

可以。使用演示文稿级别的字面文本操作时，将 [TextSearchOptions.setIncludeNotes] 设置为 `true`。上面示例中的回调实现会将备注幻灯片中的匹配映射回其父幻灯片编号。

**如何在不二次扫描演示文稿的情况下生成报告？**

向突出显示或替换操作传递一个 Java 结果回调代理。回调在操作运行期间收到每一次匹配，应用程序可以存储源文本、匹配文本、位置、文本框以及派生的幻灯片编号，以便后续分组或导出。

**替换文本时是否会保留其格式？**

[TextFrame.replaceText] 和 [TextFrame.replaceRegex] 在现有文本框内修改匹配的文本并保留周围部分的格式。如果一次匹配跨越了格式不同的片段，请检查结果以确保替换使用所需的样式。