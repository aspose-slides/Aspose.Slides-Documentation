---
title: 在 PHP 中搜索和替换 PowerPoint 演示文稿的文本
linktitle: 搜索和替换文本
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

这些功能可用于审阅、编辑、术语检查、模板清理和自动化报告工作流。

在下面的第一个示例中，我们使用名为“sample.pptx”的文件，该文件在第一张幻灯片上包含一个带有以下文本的单个文本框：

![Sample text](sample_text.png)

## **选择搜索范围**

使用 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/) 上的方法将操作限制在一个文本框内。使用 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 上的方法处理演示文稿中所有适用的文本。

| 操作 | 单个文本框 | 整个演示文稿 |
|---|---|---|
| 突出显示文字字面值 | [TextFrame::highlightText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#highlightText) |
| 突出显示正则表达式匹配项 | [TextFrame::highlightRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#highlightRegex) |
| 替换文字字面值 | [TextFrame::replaceText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#replaceText) |
| 替换正则表达式匹配项 | [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#replaceRegex) |

## **配置文本匹配**

对于文字字面值操作，使用 [TextSearchOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/) 控制匹配方式：

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 将匹配限制为完整单词。
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) 控制是否必须匹配字符大小写。
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) 在演示文稿级别的搜索、替换和突出显示操作中包含幻灯片备注。

正则表达式操作使用 Java `Pattern`，因此大小写敏感性和单词边界等匹配规则由表达式及其标志定义。

## **确定文本框的所有者**

通用的文本处理工作流在搜索、替换、验证或导出文本时通常会接收到一个 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)。使用 [TextFrame::getParentShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#getParentShape) 和 [TextFrame::getParentCell](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#getParentCell) 可确定哪个演示文稿对象拥有该文本框。

预期值取决于所有者：

| 文本框所有者 | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape 或其他包含文本的形状 | 拥有者 [Shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/) | `null` |
| 表格单元格 | `null` | 拥有者 [Cell](https://reference.aspose.com/slides/zh/php-java/aspose.slides/cell/) |

两种方法都提供只读导航。调用它们不会移动文本框或更改其所有者。通用代码应使用 `java_is_null` 检查两个值，并处理两者都不可用的情况。

以下示例使用 [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideutil/#getAllTextFrames) 迭代演示文稿中的文本框。对于形状，它报告形状名称、Java 运行时类型和所在幻灯片；对于表格单元格，它报告零基的列行坐标以及所在幻灯片。

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

对于 SmartArt 内容，遍历 [SmartArtNode::getShapes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/smartartnode/#getShapes) 中的形状，并访问每个 [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/smartartshape/#getTextFrame)。文本框可通过 [TextFrame::getParentShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#getParentShape) 追溯到其关联的形状，而 [TextFrame::getParentCell](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#getParentCell) 返回 `null`。因此，示例中的形状分支也处理来自 SmartArt 节点的文本。

## **使用回调收集匹配信息**

向突出显示或替换方法传递 Java 代理回调，以便在每次匹配时接收通知。回调方法接收相关的文本框、源文本、匹配文本以及匹配位置。

回调不会直接接收幻灯片编号。下面的实现从父幻灯片中推导出编号，并且还能处理幻灯片备注中的文本。结果数组在文本关联到其他幻灯片类型时使用 `null`。

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
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

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

在将该 PHP 对象传递给操作之前为其创建代理：

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

对于替换操作，`foundText` 包含原始匹配文本，因此回调可以准确记录被替换的词语。

## **突出显示文本**

使用 [TextFrame::highlightText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#highlightText) 方法在文本框中突出显示文字字面值匹配项。传入 [TextSearchOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/) 以控制搜索。

下面的代码示例首先突出显示所有出现的 **"try"**，然后仅突出显示完整单词 **"to"**。

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

    // 在文本框中突出显示所有出现的 "try"。
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

    // 仅突出显示完整单词 "to"。
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

![The highlighted text](highlighted_text.png)

## **使用正则表达式突出显示文本**

[TextFrame::highlightRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#highlightRegex) 方法在文本框中突出显示正则表达式找到的匹配文本。

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **跨演示文稿突出显示文本**

使用 [Presentation::highlightText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#highlightText) 和 [Presentation::highlightRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#highlightRegex) 在演示文稿中搜索所有适用的文本框。下面的示例突出显示一个文字字面值和所有电子邮件地址：

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

使用 [TextFrame::replaceText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceText) 进行文字字面值替换，使用 [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceRegex) 进行基于模式的替换。这些方法在现有文本框内更新匹配文本，保留周围部分的格式，而不是从纯字符串重新构建文本框。

下面的示例先统一一种拼写变体，然后替换版本标签：

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

如果一次匹配跨越不同格式的部分，请检查输出以确认替换文本应采用哪种格式。

## **跨演示文稿替换文本**

使用 [Presentation::replaceText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#replaceText) 和 [Presentation::replaceRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#replaceRegex) 在整个演示文稿中应用相同操作。这对于模板清理、术语更新和编辑非常有用。

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

## **将匹配项分组用于报告**

因为每个结果都存储了幻灯片编号和文本框，应用程序可以将匹配项按审计、报告或审阅工作流分组。下面的示例先按幻灯片再按文本框对收集的结果进行分组：

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

**如何只搜索单个文本框而不是整个演示文稿？**

获取形状的文本框，然后在该文本框上调用 [TextFrame::highlightText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#highlightText)、[TextFrame::highlightRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#highlightRegex)、[TextFrame::replaceText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceText) 或 [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceRegex)。演示文稿级别的方法会处理所有适用的文本框。

**如何匹配完整单词并保持正确的大小写？**

将 [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 和 [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) 设置为 `true`，并将选项传递给文字字面值的突出显示或替换方法。对于正则表达式，在 Java `Pattern` 本身中定义单词边界和大小写敏感性。

**搜索和替换可以包含幻灯片备注中的文本吗？**

可以。使用演示文稿级别的文字字面值操作时，将 [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) 设置为 `true`。

**如何在不二次扫描演示文稿的情况下生成报告？**

向突出显示或替换操作传递 Java 代理回调。它在操作运行期间接收每一次匹配，应用程序可以存储源文本、匹配文本、位置、文本框以及推导出的幻灯片编号，以便后续分组或导出。

**替换文本时是否保留其格式？**

[TextFrame::replaceText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceText) 和 [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/#replaceRegex) 在现有文本框内修改匹配文本并保留周围部分的格式。如果匹配跨越不同格式的段落，请检查结果以确保替换使用所需的样式。