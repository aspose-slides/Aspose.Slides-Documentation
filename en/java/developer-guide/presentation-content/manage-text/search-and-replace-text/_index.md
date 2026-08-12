---
title: Search and Replace Text in PowerPoint Presentations in Java
linktitle: Search and Replace Text
type: docs
weight: 55
url: /java/search-and-replace-text/
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
- Java
- Aspose.Slides
description: "Search, highlight, and replace text in PowerPoint presentations while collecting every match with Aspose.Slides for Java."
---

## **Overview**

Aspose.Slides for Java can search, highlight, and replace text in an individual text frame or across an entire presentation. Each operation can also notify an application about every match through a result callback. This makes it possible to update a presentation and simultaneously build an audit trail containing the matched text, its context, position, text frame, and slide number.

These capabilities are useful for review, redaction, terminology checks, template cleanup, and automated reporting workflows.

In the first examples below, we use a file named "sample.pptx", which contains a single text box on the first slide with the following text:

![Sample text](sample_text.png)

## **Choose the Search Scope**

Use methods on [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) to limit an operation to one text frame. Use methods on [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) to process all applicable text in the presentation.

| Operation | One text frame | Entire presentation |
|---|---|---|
| Highlight literal text | [ITextFrame.highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [ITextFrame.replaceText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configure Text Matching**

For literal-text operations, use [TextSearchOptions](https://reference.aspose.com/slides/java/com.aspose.slides/textsearchoptions/) to control matching:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limits matches to complete words.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) controls whether character case must match.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) includes slide notes in presentation-level search, replacement, and highlighting operations.

Regular-expression operations use a Java `Pattern`, so matching rules such as case sensitivity and word boundaries are defined by the expression and its flags.

## **Collect Match Information with a Callback**

Implement [IFindResultCallback](https://reference.aspose.com/slides/java/com.aspose.slides/ifindresultcallback/) to receive a notification for every match. Its [IFindResultCallback.foundResult](https://reference.aspose.com/slides/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) method provides the related text frame, the source text, the matched text, and the match position.

The callback does not receive a slide number directly. The implementation below derives it from the parent slide and also handles text found in slide notes. A nullable `Integer` allows the same result model to represent text associated with other slide types.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private static Integer getSlideNumber(ITextFrame textFrame) {
        if (!(textFrame instanceof TextFrame)) {
            return null;
        }

        IBaseSlide parentSlide = ((TextFrame) textFrame).getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

For replacement operations, `foundText` contains the original matched text, so the callback can record exactly which terms were replaced.

## **Highlight Text**

Use the [ITextFrame.highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) method to highlight literal-text matches in a text frame. Pass [TextSearchOptions](https://reference.aspose.com/slides/java/com.aspose.slides/textsearchoptions/) to control the search and a callback to collect match details.

The code example below highlights all occurrences of the characters **"try"** and then highlights only the complete word **"to"**. Both searches report their matches to the same callback.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    Color substringHighlightColor = new Color(173, 216, 230);

    // Highlight every occurrence of "try" in the text frame.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Highlight only the complete word "to".
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The result:

![The highlighted text](highlighted_text.png)

## **Highlight Text Using Regular Expressions**

The [ITextFrame.highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) method highlights text matches found by a regular expression in a text frame.

The following code highlights all words containing seven or more characters and collects each match:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The result:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Highlight Text Across a Presentation**

Use [Presentation.highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) and [Presentation.highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) to search all applicable text frames in a presentation. The following example highlights a literal term and all email addresses while keeping separate result collections for the two searches.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    presentation.highlightText("confidential", Color.ORANGE, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Replace Text in a Text Frame**

Use [ITextFrame.replaceText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) for literal text and [ITextFrame.replaceRegex](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) for pattern-based replacement. These methods update matched text within the existing text frame, which retains the surrounding portion formatting instead of rebuilding the text frame from a plain string.

The following example standardizes a spelling variant and then replaces version labels. The same callback records the original terms matched by both operations.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

If one match spans portions with different formatting, review the output to confirm which formatting should apply to the replacement text.

## **Replace Text Across a Presentation**

Use [Presentation.replaceText](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) and [Presentation.replaceRegex](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) to apply the same operations across the presentation. This is useful for template cleanup, terminology updates, and redaction.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Group Matches for Reporting**

Because every result stores its slide number and text frame, applications can group matches for audit, reporting, or review workflows. The following example groups the collected results first by slide and then by text frame:

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **FAQ**

**How can I search only one text box instead of the entire presentation?**

Get the shape's text frame and call [ITextFrame.highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), or [ITextFrame.replaceRegex](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) on that text frame. Presentation-level methods process all applicable text frames instead.

**How can I match complete words with the correct capitalization?**

Set [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) and [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) to `true`, and pass the options to a literal-text highlighting or replacement method. For regular expressions, define word boundaries and case sensitivity in the Java `Pattern` itself.

**Can search and replacement include text in slide notes?**

Yes. Set [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) to `true` when using a presentation-level literal-text operation. The callback implementation shown above maps a match in a notes slide back to its parent slide number.

**How can I create a report without scanning the presentation a second time?**

Pass an [IFindResultCallback](https://reference.aspose.com/slides/java/com.aspose.slides/ifindresultcallback/) implementation to the highlighting or replacement operation. The callback receives every match while the operation runs, so the application can store the source text, matched text, position, text frame, and derived slide number for later grouping or export.

**Does replacing text preserve its formatting?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) and [ITextFrame.replaceRegex](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modify matched text within the existing text frame and retain the surrounding portion formatting. If a match spans portions with different formatting, inspect the result to ensure the replacement uses the desired style.
