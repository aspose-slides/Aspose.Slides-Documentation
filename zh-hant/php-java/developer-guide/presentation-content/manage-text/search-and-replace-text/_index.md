---
title: 在 PHP 中搜尋與取代 PowerPoint 簡報文字
linktitle: 搜尋與取代文字
type: docs
weight: 55
url: /zh-hant/php-java/search-and-replace-text/
keywords:
- 搜尋文字
- 標示文字
- 取代文字
- 正規表達式
- 結果回呼
- 文字框
- 稽核報告
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 PowerPoint 簡報中搜尋、標示與取代文字，同時使用 Aspose.Slides for PHP via Java 收集每一個匹配項目。"
---
## **概觀**

Aspose.Slides for PHP via Java 可以在單一文字框或整份簡報中搜尋、標示及取代文字。每項操作也能透過結果回呼通知應用程式每一個符合項目。這使得在更新簡報的同時，能同時建立包含符合文字、其上下文、位置、文字框與投影片編號的稽核追蹤。

這些功能對於審閱、遮蔽、術語檢查、模板清理以及自動化報告工作流程非常有用。

在下列第一個範例中，我們使用名為 **"sample.pptx"** 的檔案，該檔案於第一張投影片上只有一個文字方塊，文字內容如下：

![範例文字](sample_text.png)

## **選擇搜尋範圍**

使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 上的方法將操作限制於單一文字框。使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 上的方法則會處理簡報中所有適用的文字。

| 操作 | 單一文字框 | 整份簡報 |
|---|---|---|
| 標示文字字面值 | [TextFrame::highlightText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#highlightText) |
| 標示正則表達式匹配 | [TextFrame::highlightRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#highlightRegex) |
| 取代文字字面值 | [TextFrame::replaceText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#replaceText) |
| 取代正則表達式匹配 | [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#replaceRegex) |

## **設定文字匹配**

對於文字字面值操作，使用 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/) 來控制匹配方式：

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 限制匹配僅限完整單字。  
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) 控制是否必須匹配字元大小寫。  
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) 將投影片備註納入簡報層級的搜尋、取代與標示操作。

正則表達式操作使用 Java `Pattern`，因此大小寫敏感度與單字邊界等規則皆由表達式本身及其旗標定義。

## **識別文字框的擁有者**

一般的文字處理工作流程常在搜尋、取代、驗證或匯出文字時接收到一個 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。使用 [TextFrame::getParentShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#getParentShape) 與 [TextFrame::getParentCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#getParentCell) 可判斷是哪個簡報物件擁有此文字框。

預期值取決於擁有者：

| 文字框擁有者 | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape 或其他包含文字的形狀 | 擁有的 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) | `null` |
| 表格儲存格 | `null` | 擁有的 [Cell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cell/) |

兩個方法皆提供唯讀導覽。呼叫它們不會移動文字框或變更其擁有者。通用程式碼應同時檢查 `java_is_null`，並處理兩者皆不為可用的情況。

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

對於 SmartArt 內容，請遍歷 [SmartArtNode::getShapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartnode/#getShapes) 中的形狀，並存取每個 [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartshape/#getTextFrame)。文字框可透過 [TextFrame::getParentShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#getParentShape) 追溯到其關聯形狀，而 [TextFrame::getParentCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#getParentCell) 會傳回 `null`。因此，範例中的形狀分支同時處理來自 SmartArt 節點的文字。

## **使用回呼收集匹配資訊**

將 Java 代理回呼傳遞給標示或取代方法，以接收每一次匹配的通知。回呼方法會收到相關的文字框、來源文字、匹配文字以及匹配位置。

回呼不會直接取得投影片編號。以下實作會從父投影片推算編號，並同時處理投影片備註中的文字。結果陣列在文字屬於其他投影片類型時使用 `null`。

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

在將物件傳遞給操作之前，先為此 PHP 物件建立代理：

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

對於取代操作，`foundText` 包含原始的匹配文字，回呼因此能精確記錄哪些詞彙被取代。

## **標示文字**

使用 [TextFrame::highlightText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#highlightText) 方法在文字框中標示文字字面值匹配。傳入 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/) 以控制搜尋行為。

以下程式碼範例會先標示所有 **"try"** 字元的出現，然後僅標示完整單字 **"to"**。

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

    // 強調文字框中每個 "try" 的出現。
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

    // 僅強調完整單字 "to"。
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

結果：

![已標示的文字](highlighted_text.png)

## **使用正則表達式標示文字**

[TextFrame::highlightRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#highlightRegex) 方法會在文字框中標示符合正則表達式的文字。

以下程式碼會標示所有包含七個或以上字元的單字：

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

結果：

![使用正則表達式標示的文字](highlighted_text_using_regex.png)

## **在簡報中標示文字**

使用 [Presentation::highlightText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#highlightText) 與 [Presentation::highlightRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#highlightRegex) 來搜尋簡報中所有適用的文字框。以下範例同時標示一個字面詞彙與所有電子郵件地址：

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

## **在文字框中取代文字**

使用 [TextFrame::replaceText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceText) 處理文字字面值，使用 [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceRegex) 處理模式取代。這些方法會在現有文字框內直接更新匹配的文字，保留周圍文字的格式，而不是以純文字重新建立文字框。

以下範例先統一一個拼寫變體，然後取代版本標籤：

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

如果一個匹配跨越了具有不同格式的區段，請檢查輸出以確認替換文字應套用哪種格式。

## **在整份簡報中取代文字**

使用 [Presentation::replaceText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#replaceText) 與 [Presentation::replaceRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#replaceRegex) 在整份簡報執行相同的操作。這對於模板清理、術語更新與遮蔽非常有用。

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

## **分組匹配結果以供報告**

因為每個結果都儲存了投影片編號與文字框，應用程式可以將匹配結果依投影片再依文字框分組，以支援稽核、報告或審查工作流程。以下範例先依投影片分組，然後依文字框分組：

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

## **常見問題**

**如何只搜尋單一文字方塊而非整份簡報？**

取得形狀的文字框，然後在該文字框上呼叫 [TextFrame::highlightText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#highlightText)、[TextFrame::highlightRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#highlightRegex)、[TextFrame::replaceText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceText) 或 [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceRegex)。簡報層級的方法則會處理所有適用的文字框。

**如何以正確的大小寫匹配完整單字？**

將 [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 與 [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) 設為 `true`，並將這些選項傳遞給文字字面值的標示或取代方法。對於正則表達式，請在 Java `Pattern` 本身定義單字邊界與大小寫敏感度。

**搜尋與取代是否可以包含投影片備註中的文字？**

可以。使用簡報層級的文字字面值操作時，將 [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) 設為 `true`。

**如何在不再次掃描簡報的情況下建立報告？**

將 Java 代理回呼傳遞給標示或取代操作。它會在操作執行期間即時收到每一次匹配，讓應用程式能儲存來源文字、匹配文字、位置、文字框與推算出的投影片編號，以供之後分組或匯出。

**取代文字是否會保留其格式？**

[TextFrame::replaceText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceText) 與 [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceRegex) 會在現有文字框內修改匹配的文字，並保留其周圍區段的格式。如果匹配跨越了不同格式的區段，請檢查結果以確保替換使用了期望的樣式。