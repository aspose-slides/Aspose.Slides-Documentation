---
title: Search and Replace Text in PowerPoint Presentations in JavaScript
linktitle: Search and Replace Text
type: docs
weight: 55
url: /nodejs-java/search-and-replace-text/
keywords:
- search text
- highlight text
- replace text
- regular expression
- result callback
- text frame
- audit report
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Search, highlight, and replace text in PowerPoint presentations while collecting every match with Aspose.Slides for Node.js via Java."
---

## **Overview**

Aspose.Slides for Node.js via Java can search, highlight, and replace text in an individual text frame or across an entire presentation. Each operation can also notify an application about every match through a result callback. This makes it possible to update a presentation and simultaneously build an audit trail containing the matched text, its context, position, text frame, and slide number.

These capabilities are useful for review, redaction, terminology checks, template cleanup, and automated reporting workflows.

In the first examples below, we use a file named "sample.pptx", which contains a single text box on the first slide with the following text:

![Sample text](sample_text.png)

## **Choose the Search Scope**

Use methods on [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) to limit an operation to one text frame. Use methods on [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) to process all applicable text in the presentation.

| Operation | One text frame | Entire presentation |
|---|---|---|
| Highlight literal text | [TextFrame.highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [TextFrame.highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [TextFrame.replaceText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [TextFrame.replaceRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configure Text Matching**

For literal-text operations, use [TextSearchOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textsearchoptions/) to control matching:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limits matches to complete words.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) controls whether character case must match.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) includes slide notes in presentation-level search, replacement, and highlighting operations.

Regular-expression operations use a Java `Pattern`, so matching rules such as case sensitivity and word boundaries are defined by the expression and its flags.

## **Identify the Owner of a Text Frame**

Generic text-processing workflows often receive a [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) while searching, replacing, validating, or exporting text. Use [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) and [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) to determine which presentation object owns the text frame.

The expected values depend on the owner:

| Text frame owner | `getParentShape` | `getParentCell` |
|---|---|---|
| An AutoShape or another text-containing shape | The owning [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) | `null` |
| A table cell | `null` | The owning [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) |

Both methods provide read-only navigation. Calling them does not move the text frame or change its owner. Generic code should check both values for `null` and handle the possibility that neither owner is available.

The following example uses [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) to iterate through the text frames in a presentation. For shapes, it reports the shape name, Java runtime type, and containing slide. For table cells, it reports the zero-based column and row coordinates and the containing slide.

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

For SmartArt content, iterate through the shapes in [SmartArtNode.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/#getShapes--) and access each [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/#getTextFrame--). The text frame can be traced to its associated shape through [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--), while [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) returns `null`. Therefore, the shape branch in the example also handles text from SmartArt nodes.

## **Collect Match Information with a Callback**

Create a Java proxy for the result callback to receive a notification for every match. The proxy function receives the related text frame, the source text, the matched text, and the match position.

The callback does not receive a slide number directly. The implementation below derives it through the text frame's owning shape or table cell, with [TextFrame.getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getSlide--) as a fallback. It also handles text found in slide notes.

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

For replacement operations, `foundText` contains the original matched text, so the callback can record exactly which terms were replaced.

## **Highlight Text**

Use the [TextFrame.highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) method to highlight literal-text matches in a text frame. Pass [TextSearchOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textsearchoptions/) to control the search.

The code example below highlights all occurrences of the characters **"try"** and then highlights only the complete word **"to"**.

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

    // Highlight every occurrence of "try" in the text frame.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Highlight only the complete word "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The result:

![The highlighted text](highlighted_text.png)

## **Highlight Text Using Regular Expressions**

The [TextFrame.highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) method highlights text matches found by a regular expression in a text frame.

The following code highlights all words containing seven or more characters:

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

The result:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Highlight Text Across a Presentation**

Use [Presentation.highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) and [Presentation.highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) to search all applicable text frames in a presentation. The following example highlights a literal term and all email addresses:

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

## **Replace Text in a Text Frame**

Use [TextFrame.replaceText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) for literal text and [TextFrame.replaceRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) for pattern-based replacement. These methods update matched text within the existing text frame, which retains the surrounding portion formatting instead of rebuilding the text frame from a plain string.

The following example standardizes a spelling variant and then replaces version labels:

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

If one match spans portions with different formatting, review the output to confirm which formatting should apply to the replacement text.

## **Replace Text Across a Presentation**

Use [Presentation.replaceText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) and [Presentation.replaceRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) to apply the same operations across the presentation. This is useful for template cleanup, terminology updates, and redaction.

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

## **Group Matches for Reporting**

Because every collected result stores its slide number and text frame, applications can group matches for audit, reporting, or review workflows. The following example groups the results first by slide and then by text frame:

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

**How can I search only one text box instead of the entire presentation?**

Get the shape's text frame and call [TextFrame.highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), or [TextFrame.replaceRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) on that text frame. Presentation-level methods process all applicable text frames instead.

**How can I match complete words with the correct capitalization?**

Set [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) and [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) to `true`, and pass the options to a literal-text highlighting or replacement method. For regular expressions, define word boundaries and case sensitivity in the Java `Pattern` itself.

**Can search and replacement include text in slide notes?**

Yes. Set [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) to `true` when using a presentation-level literal-text operation. The callback implementation shown above maps a match in a notes slide back to its parent slide number.

**How can I create a report without scanning the presentation a second time?**

Pass a Java result-callback proxy to the highlighting or replacement operation. The callback receives every match while the operation runs, so the application can store the source text, matched text, position, text frame, and derived slide number for later grouping or export.

**Does replacing text preserve its formatting?**

[TextFrame.replaceText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) and [TextFrame.replaceRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modify matched text within the existing text frame and retain the surrounding portion formatting. If a match spans portions with different formatting, inspect the result to ensure the replacement uses the desired style.
