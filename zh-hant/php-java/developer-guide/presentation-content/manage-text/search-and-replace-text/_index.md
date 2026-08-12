---
title: 在 PHP 中搜尋與取代 PowerPoint 簡報中的文字
linktitle: 搜尋與取代文字
type: docs
weight: 55
url: /zh-hant/php-java/search-and-replace-text/
keywords:
- 搜尋文字
- 突顯文字
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
description: "在 PowerPoint 簡報中搜尋、突顯與取代文字，同時使用 Aspose.Slides for PHP via Java 收集每一次匹配。"
---
## **概觀**

Aspose.Slides for PHP via Java 可以在單一文字框或整個簡報中搜尋、突顯與取代文字。每項操作也能透過結果回呼通知應用程式每一次匹配。這使得在更新簡報的同時，能同時建立包含匹配文字、其上下文、位置、文字框與投影片編號的稽核追蹤。

這些功能對於審閱、刪除、術語檢查、範本清理與自動化報告工作流程都很有幫助。

在以下第一組範例中，我們使用名為 **"sample.pptx"** 的檔案，該檔案在第一張投影片上包含一個文字方塊，文字內容如下：

![範例文字](sample_text.png)

## **選擇搜尋範圍**

使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 上的方法將操作限制於單一文字框。使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 上的方法則會處理簡報中所有適用的文字。

| 操作 | 單一文字框 | 整個簡報 |
|---|---|---|
| Highlight literal text | [TextFrame::highlightText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#highlightText) |
| Highlight regular-expression matches | [TextFrame::highlightRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#highlightRegex) |
| Replace literal text | [TextFrame::replaceText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#replaceText) |
| Replace regular-expression matches | [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#replaceRegex) |

## **設定文字比對**

對於文字字面值操作，使用 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/) 來控制匹配行為：

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 只限完整單字匹配。
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) 控制是否必須符合大小寫。
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) 在簡報層級的搜尋、取代與突顯操作中包含投影片備註。

正規表達式操作使用 Java `Pattern`，因此大小寫敏感度與字邊界等規則由表達式本身及其旗標決定。

## **使用回呼收集匹配資訊**

將 Java 代理回呼傳遞給突顯或取代方法，即可在每次匹配時收到通知。回呼方法會取得相關的文字框、來源文字、匹配文字與匹配位置。

回呼本身不會直接收到投影片編號。以下實作從父投影片衍生編號，並同時處理投影片備註中的文字。結果陣列在文字屬於其他投影片類型時使用 `null`。

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

在將此 PHP 物件傳遞給操作之前，先為它建立代理：

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

對於取代操作，`foundText` 包含原始匹配文字，回呼因此能精確記錄哪個詞彙被取代。

## **突顯文字**

使用 [TextFrame::highlightText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#highlightText) 方法在文字框中突顯字面值匹配。傳入 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/) 以控制搜尋。

以下程式碼範例先突顯所有 **"try"** 字元，接著僅突顯完整單字 **"to"**。

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

    // 在文字框中突顯每一次出現的 "try"。
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

    // 僅突顯完整的單字 "to"。
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

![已突顯的文字](highlighted_text.png)

## **使用正規表達式突顯文字**

[TextFrame::highlightRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#highlightRegex) 方法會突顯在文字框中符合正規表達式的文字。

下列程式碼會突顯所有包含七個以上字元的單字：

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

![使用正規表達式突顯的文字](highlighted_text_using_regex.png)

## **跨簡報突顯文字**

使用 [Presentation::highlightText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#highlightText) 與 [Presentation::highlightRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#highlightRegex) 來搜尋簡報中所有適用的文字框。以下範例突顯一個字面詞彙與所有電子郵件地址：

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

對於字面文字使用 [TextFrame::replaceText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceText)，對於模式化取代使用 [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceRegex)。這些方法會在既有文字框內直接更新匹配文字，保留周圍段落的格式，而非以純字串重新建構文字框。

以下範例先統一拼寫變體，然後取代版本標籤：

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

如果單一次匹配跨越不同格式的區段，請檢查輸出以確認哪種格式應套用於取代文字。

## **跨簡報取代文字**

使用 [Presentation::replaceText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#replaceText) 與 [Presentation::replaceRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#replaceRegex) 在整個簡報中執行相同操作。此功能適用於範本清理、術語更新與刪除。

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

## **分組匹配以供報告**

因為每個結果都儲存其投影片編號與文字框，應用程式可以依照投影片或文字框分組匹配，以供稽核、報告或審閱工作流程使用。以下範例先依投影片再依文字框分組收集的結果：

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

**如何只搜尋單一文字方塊而不是整個簡報？**

取得圖形的文字框，然後在該文字框上呼叫 [TextFrame::highlightText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#highlightText)、[TextFrame::highlightRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#highlightRegex)、[TextFrame::replaceText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceText) 或 [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceRegex)。簡報層級的方法則會處理所有適用的文字框。

**如何以正確的大小寫匹配完整單字？**

將 [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) 與 [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) 設為 `true`，並將選項傳入字面值突顯或取代方法。若使用正規表達式，請在 Java `Pattern` 本身定義字邊界與大小寫敏感度。

**搜尋與取代可以包含投影片備註中的文字嗎？**

可以。使用簡報層級的字面值操作時，將 [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) 設為 `true`。

**如何在不再次掃描簡報的情況下產生報告？**

將 Java 代理回呼傳遞給突顯或取代操作。它會在操作執行期間收到每一次匹配，讓應用程式能儲存來源文字、匹配文字、位置、文字框與衍生的投影片編號，以供之後分組或匯出。

**取代文字時會保留其格式嗎？**

[TextFrame::replaceText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceText) 與 [TextFrame::replaceRegex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#replaceRegex) 會在既有文字框內修改匹配文字，並保留周圍區段的格式。如果匹配跨越具有不同格式的區段，請檢查結果以確保取代文字使用期望的樣式。