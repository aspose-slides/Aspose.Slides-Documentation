---
title: PHPでPowerPointプレゼンテーションのテキストを検索・置換する
linktitle: テキストの検索と置換
type: docs
weight: 55
url: /ja/php-java/search-and-replace-text/
keywords:
- テキスト検索
- テキストハイライト
- テキスト置換
- 正規表現
- 結果コールバック
- テキストフレーム
- 監査レポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PowerPointプレゼンテーションのテキストを検索、ハイライト、置換し、Aspose.Slides for PHP via Javaで一致をすべて収集します。"
---
## **概要**

Aspose.Slides for PHP via Java は、個々のテキストフレームまたはプレゼンテーション全体でテキストの検索、ハイライト、置換を行うことができます。各操作は結果コールバックを通じて各一致についてアプリケーションに通知することもできます。これにより、プレゼンテーションを更新しながら、一致したテキスト、そのコンテキスト、位置、テキストフレーム、スライド番号を含む監査トレイルを同時に作成することが可能です。

これらの機能は、レビュー、編集、用語チェック、テンプレートのクリーンアップ、および自動レポート作成ワークフローに役立ちます。

以下の最初の例では、最初のスライドに単一のテキストボックスがあり、次のテキストが含まれる「sample.pptx」ファイルを使用します。

![サンプルテキスト](sample_text.png)

## **検索範囲の選択**

テキストフレーム単位で操作を制限するには [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) のメソッドを使用します。プレゼンテーション全体のテキストを処理するには [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) のメソッドを使用します。

| 操作 | 単一テキストフレーム | プレゼンテーション全体 |
|---|---|---|
| リテラルテキストのハイライト | [TextFrame::highlightText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#highlightText) |
| 正規表現マッチのハイライト | [TextFrame::highlightRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#highlightRegex) |
| リテラルテキストの置換 | [TextFrame::replaceText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#replaceText) |
| 正規表現マッチの置換 | [TextFrame::replaceRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#replaceRegex) |

## **テキストマッチングの構成**

リテラルテキスト操作では、[TextSearchOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textsearchoptions/) を使用してマッチングを制御します。

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) は完全な単語に対してのみ一致させます。
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) は文字の大文字小文字が一致するかどうかを制御します。
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) はスライドのノートをプレゼンテーションレベルの検索、置換、ハイライト操作に含めます。

正規表現操作は Java の `Pattern` を使用するため、ケースセンシティブや単語境界などのマッチングルールは式とそのフラグで定義されます。

## **コールバックで一致情報を収集**

ハイライトまたは置換メソッドに Java プロキシコールバックを渡すと、すべての一致について通知を受け取れます。コールバックメソッドは対象のテキストフレーム、元のテキスト、一致したテキスト、そして一致位置を受け取ります。

コールバックはスライド番号を直接受け取りません。以下の実装では親スライドから番号を取得し、スライドノート内のテキストも処理します。テキストが別のスライド種別に関連付けられている場合、結果配列は `null` を使用します。

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

この PHP オブジェクトのプロキシを作成し、操作に渡す前に使用してください：

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

置換操作の場合、`foundText` には元の一致テキストが含まれるため、コールバックは正確にどの語句が置換されたかを記録できます。

## **テキストのハイライト**

[TextFrame::highlightText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#highlightText) メソッドを使用して、テキストフレーム内のリテラルテキストの一致をハイライトします。検索を制御するために [TextSearchOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textsearchoptions/) を渡します。

以下のコード例では、文字列 **"try"** のすべての出現をハイライトし、その後完全な単語 **"to"** のみをハイライトします。

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

    // テキストフレーム内の「try」のすべての出現をハイライトします。
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

    // 完全な単語「to」だけをハイライトします。
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

![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用したテキストのハイライト**

正規表現で見つかったテキストの一致をテキストフレーム内でハイライトするには、[TextFrame::highlightRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#highlightRegex) メソッドを使用します。

以下のコードは、7文字以上の単語すべてをハイライトします：

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

![正規表現を使用したハイライトテキスト](highlighted_text_using_regex.png)

## **プレゼンテーション全体でテキストをハイライト**

[Presentation::highlightText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#highlightText) および [Presentation::highlightRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#highlightRegex) を使用して、プレゼンテーション内の対象テキストフレームすべてを検索します。以下の例では、リテラル用語とすべてのメールアドレスをハイライトします：

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

## **テキストフレーム内のテキストを置換**

リテラルテキストには [TextFrame::replaceText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#replaceText) 、パターンベースの置換には [TextFrame::replaceRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#replaceRegex) を使用します。これらのメソッドは既存のテキストフレーム内の一致テキストを更新し、プレーン文字列からテキストフレームを再構築するのではなく、周囲の書式設定を保持します。

以下の例では、綴りのバリエーションを標準化し、その後バージョンラベルを置換します：

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

1 つの一致が異なる書式設定の部分にまたがる場合、置換テキストに適用すべき書式を確認するために出力をレビューしてください。

## **プレゼンテーション全体でテキストを置換**

[Presentation::replaceText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#replaceText) および [Presentation::replaceRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#replaceRegex) を使用して、プレゼンテーション全体に同じ操作を適用します。テンプレートのクリーンアップ、用語の更新、編集に役立ちます。

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

## **レポート用に一致をグループ化**

各結果がスライド番号とテキストフレームを保持しているため、アプリケーションは監査、レポート、レビューのワークフロー向けに一致をグループ化できます。以下の例では、収集した結果をまずスライドごとに、次にテキストフレームごとにグループ化します：

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

**プレゼンテーション全体ではなく、1 つのテキストボックスだけを検索するにはどうすればよいですか？**

シェイプのテキストフレームを取得し、そのテキストフレームで [TextFrame::highlightText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#highlightText)、[TextFrame::highlightRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#highlightRegex)、[TextFrame::replaceText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#replaceText)、または [TextFrame::replaceRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#replaceRegex) を呼び出します。プレゼンテーションレベルのメソッドは、すべての対象テキストフレームを処理します。

**正しい大文字小文字で完全な単語にマッチさせるにはどうすればよいですか？**

[TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) と [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) を `true` に設定し、リテラルテキストのハイライトまたは置換メソッドにオプションを渡します。正規表現の場合は、Java の `Pattern` 自体で単語境界と大文字小文字を定義します。

**検索および置換でスライドノートのテキストも含めることはできますか？**

はい。プレゼンテーションレベルのリテラルテキスト操作を使用する際に、[TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) を `true` に設定します。

**プレゼンテーションを再度スキャンせずにレポートを作成するにはどうすればよいですか？**

ハイライトまたは置換操作に Java プロキシコールバックを渡します。操作実行中にすべての一致を受け取るため、アプリケーションは元のテキスト、一致テキスト、位置、テキストフレーム、導出されたスライド番号を保存し、後でグループ化またはエクスポートできます。

**テキストの置換は書式を保持しますか？**

[TextFrame::replaceText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#replaceText) と [TextFrame::replaceRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#replaceRegex) は既存のテキストフレーム内の一致テキストを変更し、周囲の書式設定を保持します。もし一致が異なる書式の部分にまたがる場合、置換が希望のスタイルになるよう結果を確認してください。