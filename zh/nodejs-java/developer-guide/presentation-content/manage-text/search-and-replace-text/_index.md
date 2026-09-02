---
title: 在 JavaScript 中搜索和替换 PowerPoint 演示文稿中的文本
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
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 演示文稿中搜索、突出显示和替换文本，同时收集每一次匹配。"
---
## **概述**

Aspose.Slides for Node.js via Java 可以在单个文本框或整个演示文稿中搜索、突出显示和替换文本。每个操作还可以通过结果回调通知应用程序每一次匹配。这使得在更新演示文稿的同时能够构建包含匹配文本、其上下文、位置、文本框以及幻灯片编号的审计轨迹。

这些功能对于审阅、编辑、术语检查、模板清理以及自动化报告工作流非常有用。

在下面的首个示例中，我们使用名为 “sample.pptx” 的文件，该文件的第一张幻灯片上包含一个文本框，文本内容如下：

![Sample text](sample_text.png)

## **选择搜索范围**

使用 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 的方法将操作限制在单个文本框内。使用 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 的方法可处理演示文稿中所有适用的文本。

| 操作 | 单个文本框 | 整个演示文稿 |
|---|---|---|
| 突出显示文字字面量 | [TextFrame.highlightText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 突出显示正则表达式匹配 | [TextFrame.highlightRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| 替换文字字面量 | [TextFrame.replaceText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 替换正则表达式匹配 | [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **配置文本匹配**

对于字面量文本操作，使用 [TextSearchOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textsearchoptions/) 来控制匹配行为：

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) 将匹配限制为完整单词。
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) 控制是否必须匹配字符大小写。
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) 在演示文稿级别的搜索、替换和突出显示操作中包含幻灯片备注。

正则表达式操作使用 Java `Pattern`，因此大小写敏感性和单词边界等匹配规则由表达式本身及其标志决定。

## **识别文本框的所属对象**

通用的文本处理工作流在搜索、替换、验证或导出文本时经常收到一个 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)。使用 [TextFrame.getParentShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#getParentShape--) 和 [TextFrame.getParentCell](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#getParentCell--) 可以确定是哪一个演示文稿对象拥有该文本框。

预期的返回值取决于所有者：

| 文本框所有者 | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape 或其他包含文本的形状 | 所属的 [Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/) | `null` |
| 表格单元格 | `null` | 所属的 [Cell](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/cell/) |

两种方法均提供只读导航。调用它们不会移动文本框或改变其所有者。通用代码应同时检查两个返回值是否为 `null`，并处理两者均不可用的情况。

以下示例使用 [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) 遍历演示文稿中的所有文本框。对于形状，它会报告形状名称、Java 运行时类型以及所在幻灯片；对于表格单元格，它会报告零基的列行坐标以及所在幻灯片。

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

对于 SmartArt 内容，遍历 [SmartArtNode.getShapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/smartartnode/#getShapes--) 中的形状，并访问每个 [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/smartartshape/#getTextFrame--)。文本框可通过 [TextFrame.getParentShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#getParentShape--) 追溯到其关联的形状，而 [TextFrame.getParentCell](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#getParentCell--) 返回 `null`。因此，示例中的形状分支也会处理来自 SmartArt 节点的文本。

## **使用回调收集匹配信息**

为结果回调创建一个 Java 代理，以便在每次匹配时收到通知。代理函数会接收相关的文本框、源文本、匹配文本以及匹配位置。

回调不会直接收到幻灯片编号。下面的实现通过文本框所属的形状或表格单元格推导出幻灯片编号，若都不存在则使用 [TextFrame.getSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#getSlide--) 作为后备。它还会处理在幻灯片备注中找到的文本。

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

对于替换操作，`foundText` 包含原始匹配的文本，因此回调可以准确记录哪些词被替换。

## **突出显示文本**

使用 [TextFrame.highlightText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 方法在文本框中突出显示字面量匹配的文本。通过传入 [TextSearchOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textsearchoptions/) 来控制搜索行为。

下面的代码示例先突出显示所有出现的字符 **"try"**，随后仅突出显示完整单词 **"to"**。

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

    // 突出显示文本框中每一次出现的 "try"。
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

![The highlighted text](highlighted_text.png)

## **使用正则表达式突出显示文本**

[TextFrame.highlightRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) 方法可在文本框中突出显示通过正则表达式找到的文本匹配项。

以下代码示例突出显示所有包含七个或更多字符的单词：

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **在整个演示文稿中突出显示文本**

使用 [Presentation.highlightText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 和 [Presentation.highlightRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) 对演示文稿中所有适用的文本框进行搜索。下面的示例同时突出显示一个字面量词和所有电子邮件地址：

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

使用 [TextFrame.replaceText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 进行字面量文本替换，使用 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 进行基于模式的替换。这些方法在现有文本框内更新匹配的文本，保留周围部分的格式，而不是用纯字符串重建文本框。

下面的示例统一拼写变体并随后替换版本标签：

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

如果一次匹配跨越了格式不同的片段，请检查输出以确认替换文本应使用哪种格式。

## **在整个演示文稿中替换文本**

使用 [Presentation.replaceText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 和 [Presentation.replaceRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 在演示文稿范围内执行相同操作。这对于模板清理、术语更新和编辑脱敏非常有用。

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

## **对匹配结果进行分组以生成报告**

因为每条收集的结果都保存了幻灯片编号和文本框，应用程序可以根据这些信息对匹配项进行分组，以便审计、报告或复核工作流。下面的示例先按幻灯片再按文本框对结果进行分组：

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

## **常见问题解答**

**如何只搜索单个文本框而不是整个演示文稿？**

获取该形状的文本框，然后在该文本框上调用 [TextFrame.highlightText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、[TextFrame.highlightRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)、[TextFrame.replaceText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、或 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)。演示文稿级别的方法会处理所有适用的文本框。

**如何匹配完整单词且区分大小写？**

将 [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) 和 [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) 均设为 `true`，并将这些选项传递给字面量文本的突出显示或替换方法。对于正则表达式，在 Java `Pattern` 本身中使用单词边界和大小写敏感标志即可。

**搜索和替换是否可以包括幻灯片备注中的文本？**

可以。使用演示文稿级别的字面量文本操作时，将 [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) 设置为 `true`。上面示例中的回调实现会将备注幻灯片中的匹配映射回其父幻灯片编号。

**如何在不二次扫描演示文稿的情况下生成报告？**

向突出显示或替换操作传入 Java 结果回调代理。回调在操作执行期间会收到每一次匹配，应用程序可以即时存储源文本、匹配文本、位置、文本框以及派生的幻灯片编号，以供后续分组或导出使用。

**替换文本时是否会保留其格式？**

[TextFrame.replaceText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 和 [TextFrame.replaceRegex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) 在现有文本框内部修改匹配的文本，并保留周围部分的格式。如果一次匹配跨越了格式不同的片段，请检查结果以确保替换使用了期望的样式。