---
title: Search and Replace Text in PowerPoint Presentations in PHP
linktitle: Search and Replace Text
type: docs
weight: 55
url: /php-java/search-and-replace-text/
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
- PHP
- Aspose.Slides
description: "Search, highlight, and replace text in PowerPoint presentations while collecting every match with Aspose.Slides for PHP via Java."
---

## **Overview**

Aspose.Slides for PHP via Java can search, highlight, and replace text in an individual text frame or across an entire presentation. Each operation can also notify an application about every match through a result callback. This makes it possible to update a presentation and simultaneously build an audit trail containing the matched text, its context, position, text frame, and slide number.

These capabilities are useful for review, redaction, terminology checks, template cleanup, and automated reporting workflows.

In the first examples below, we use a file named "sample.pptx", which contains a single text box on the first slide with the following text:

![Sample text](sample_text.png)

## **Choose the Search Scope**

Use methods on [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) to limit an operation to one text frame. Use methods on [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) to process all applicable text in the presentation.

| Operation | One text frame | Entire presentation |
|---|---|---|
| Highlight literal text | [TextFrame::highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#highlightText) |
| Highlight regular-expression matches | [TextFrame::highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#highlightRegex) |
| Replace literal text | [TextFrame::replaceText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#replaceText) |
| Replace regular-expression matches | [TextFrame::replaceRegex](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#replaceRegex) |

## **Configure Text Matching**

For literal-text operations, use [TextSearchOptions](https://reference.aspose.com/slides/php-java/aspose.slides/textsearchoptions/) to control matching:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) limits matches to complete words.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) controls whether character case must match.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) includes slide notes in presentation-level search, replacement, and highlighting operations.

Regular-expression operations use a Java `Pattern`, so matching rules such as case sensitivity and word boundaries are defined by the expression and its flags.

## **Collect Match Information with a Callback**

Pass a Java proxy callback to a highlighting or replacement method to receive a notification for every match. The callback method receives the related text frame, the source text, the matched text, and the match position.

The callback does not receive a slide number directly. The implementation below derives it from the parent slide and also handles text found in slide notes. The result array uses `null` when text is associated with another slide type.

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

Create a proxy for this PHP object before passing it to an operation:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

For replacement operations, `foundText` contains the original matched text, so the callback can record exactly which terms were replaced.

## **Highlight Text**

Use the [TextFrame::highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#highlightText) method to highlight literal-text matches in a text frame. Pass [TextSearchOptions](https://reference.aspose.com/slides/php-java/aspose.slides/textsearchoptions/) to control the search.

The code example below highlights all occurrences of the characters **"try"** and then highlights only the complete word **"to"**.

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

    // Highlight every occurrence of "try" in the text frame.
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

    // Highlight only the complete word "to".
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

The result:

![The highlighted text](highlighted_text.png)

## **Highlight Text Using Regular Expressions**

The [TextFrame::highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#highlightRegex) method highlights text matches found by a regular expression in a text frame.

The following code highlights all words containing seven or more characters:

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

The result:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Highlight Text Across a Presentation**

Use [Presentation::highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#highlightText) and [Presentation::highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#highlightRegex) to search all applicable text frames in a presentation. The following example highlights a literal term and all email addresses:

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

## **Replace Text in a Text Frame**

Use [TextFrame::replaceText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#replaceText) for literal text and [TextFrame::replaceRegex](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#replaceRegex) for pattern-based replacement. These methods update matched text within the existing text frame, which retains the surrounding portion formatting instead of rebuilding the text frame from a plain string.

The following example standardizes a spelling variant and then replaces version labels:

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

If one match spans portions with different formatting, review the output to confirm which formatting should apply to the replacement text.

## **Replace Text Across a Presentation**

Use [Presentation::replaceText](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#replaceText) and [Presentation::replaceRegex](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#replaceRegex) to apply the same operations across the presentation. This is useful for template cleanup, terminology updates, and redaction.

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

## **Group Matches for Reporting**

Because every result stores its slide number and text frame, applications can group matches for audit, reporting, or review workflows. The following example groups the collected results first by slide and then by text frame:

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

**How can I search only one text box instead of the entire presentation?**

Get the shape's text frame and call [TextFrame::highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#replaceText), or [TextFrame::replaceRegex](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#replaceRegex) on that text frame. Presentation-level methods process all applicable text frames instead.

**How can I match complete words with the correct capitalization?**

Set [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) and [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) to `true`, and pass the options to a literal-text highlighting or replacement method. For regular expressions, define word boundaries and case sensitivity in the Java `Pattern` itself.

**Can search and replacement include text in slide notes?**

Yes. Set [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) to `true` when using a presentation-level literal-text operation.

**How can I create a report without scanning the presentation a second time?**

Pass a Java proxy callback to the highlighting or replacement operation. It receives every match while the operation runs, so the application can store the source text, matched text, position, text frame, and derived slide number for later grouping or export.

**Does replacing text preserve its formatting?**

[TextFrame::replaceText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#replaceText) and [TextFrame::replaceRegex](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#replaceRegex) modify matched text within the existing text frame and retain the surrounding portion formatting. If a match spans portions with different formatting, inspect the result to ensure the replacement uses the desired style.
