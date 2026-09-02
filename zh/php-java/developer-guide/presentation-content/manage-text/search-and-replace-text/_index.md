---
title: 在 PHP 中搜索并替换 PowerPoint 演示文稿的文本
linktitle: 搜索并替换文本
type: docs
weight: 55
url: /zh/php-java/search-and-replace-text/
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
- PHP
- Aspose.Slides
description: "在 PowerPoint 演示文稿中搜索、突出显示和替换文本，同时使用 Aspose.Slides for PHP via Java 收集每一次匹配。"
---
## **概述**

Aspose.Slides for PHP via Java 可以在单个文本框或整个演示文稿中搜索、突出显示和替换文本。每个操作还可以通过结果回调通知应用程序每一次匹配。这使得在更新演示文稿的同时能够构建包含匹配文本、其上下文、位置、文本框和幻灯片编号的审计跟踪。

这些功能可用于审阅、编辑、术语检查、模板清理以及自动化报告工作流。

在下面的第一个示例中，我们使用名为“sample.pptx”的文件，该文件在第一页上包含一个单独的文本框，文本如下：

![示例文本](sample_text.png)

## **选择搜索范围**

使用 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/) 上的方法将操作限制为单个文本框。使用 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 上的方法处理演示文稿中所有适用的文本。

| 操作 | 单个文本框 | 整个演示文稿 |
|---|---|---|
| Highlight literal text | [TextFrame::highlightText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#highlightText) |
| Highlight regular-expression matches | [TextFrame::highlightRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#highlightRegex) |
| Replace literal text | [TextFrame::replaceText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#replaceText) |
| Replace regular-expression matches | [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#replaceRegex) |

## **配置文本匹配**

对于文字匹配操作，使用 [TextSearchOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/) 来控制匹配：

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 限制匹配仅为完整单词。
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) 控制字符大小写是否必须匹配。
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) 在演示文稿级别的搜索、替换和突出显示操作中包括幻灯片备注。

正则表达式操作使用 Java `Pattern`，因此诸如大小写敏感性和单词边界之类的匹配规则由表达式及其标志决定。

## **使用回调收集匹配信息**

将 Java 代理回调传递给突出显示或替换方法，以获取每次匹配的通知。回调方法会接收相关的文本框、源文本、匹配文本以及匹配位置。

回调不会直接接收幻灯片编号。下面的实现从父幻灯片中推导出编号，并且还能处理幻灯片备注中的文本。当文本关联到其他幻灯片类型时，结果数组使用 `null`。

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

在将其传递给操作之前，为此 PHP 对象创建一个代理：

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

对于替换操作，`foundText` 包含原始匹配文本，因此回调可以准确记录被替换的词汇。

## **突出显示文本**

使用 [TextFrame::highlightText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#highlightText) 方法在文本框中突出显示文字匹配。传入 [TextSearchOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/) 以控制搜索。

下面的代码示例突出显示所有字符 **"try"** 的出现，然后仅突出显示完整单词 **"to"**。

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

    // 突出显示文本框中每一次出现的 "try".
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

    // 仅突出显示完整单词 "to".
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

结果：

![突出显示的文本](highlighted_text.png)

## **使用正则表达式突出显示文本**

[TextFrame::highlightRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#highlightRegex) 方法突出显示文本框中通过正则表达式找到的文本匹配。

下面的代码突出显示所有包含七个或更多字符的单词：

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

结果：

![使用正则表达式突出显示的文本](highlighted_text_using_regex.png)

## **跨演示文稿突出显示文本**

使用 [Presentation::highlightText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#highlightText) 和 [Presentation::highlightRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#highlightRegex) 在演示文稿中搜索所有适用的文本框。下面的示例突出显示一个文字词汇和所有电子邮件地址：

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

## **在文本框中替换文本**

对于文字文本使用 [TextFrame::replaceText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceText)，对于基于模式的替换使用 [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceRegex)。这些方法在现有文本框内更新匹配的文本，保留周围部分的格式，而不是从普通字符串重新构建文本框。

下面的示例将拼写变体标准化，然后替换版本标签：

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

如果一个匹配跨越了不同格式的部分，请检查输出以确认应对替换文本使用哪种格式。

## **跨演示文稿替换文本**

使用 [Presentation::replaceText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#replaceText) 和 [Presentation::replaceRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#replaceRegex) 在整个演示文稿中执行相同的操作。这对于模板清理、术语更新和编辑非常有用。

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

## **对匹配结果进行分组以生成报告**

由于每个结果都存储了其幻灯片编号和文本框，应用程序可以对匹配进行分组，以用于审计、报告或审阅工作流。下面的示例首先按幻灯片，然后按文本框对收集的结果进行分组：

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

## **常见问题**

**如何仅搜索单个文本框而不是整个演示文稿？**

获取形状的文本框，然后对该文本框调用 [TextFrame::highlightText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#highlightText)、[TextFrame::highlightRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#highlightRegex)、[TextFrame::replaceText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceText) 或 [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceRegex)。演示文稿级别的方法会处理所有适用的文本框。

**如何匹配完整单词且区分大小写？**

将 [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 和 [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) 设置为 `true`，并将这些选项传递给文字匹配的突出显示或替换方法。对于正则表达式，在 Java `Pattern` 本身中定义单词边界和大小写敏感性。

**搜索和替换可以包含幻灯片备注中的文本吗？**

可以。使用演示文稿级别的文字操作时，将 [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) 设置为 `true`。

**如何在不二次扫描演示文稿的情况下生成报告？**

将 Java 代理回调传递给突出显示或替换操作。它在操作运行期间接收每一次匹配，从而使应用程序能够存储源文本、匹配文本、位置、文本框以及推导出的幻灯片编号，以便后续分组或导出。

**替换文本会保留其格式吗？**

[TextFrame::replaceText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceText) 和 [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceRegex) 在现有文本框内修改匹配的文本并保留周围部分的格式。如果匹配跨越不同格式的部分，请检查结果以确保替换使用所需的样式。