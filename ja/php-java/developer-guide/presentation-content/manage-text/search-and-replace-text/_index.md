---
title: PHP で PowerPoint プレゼンテーションのテキストを検索・置換
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
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーション内のテキストを検索、ハイライト、置換し、すべての一致を収集します。"
---
## **概要**

Aspose.Slides for PHP via Java は、個々のテキストフレームまたはプレゼンテーション全体でテキストの検索、ハイライト、置換を行うことができます。各操作は結果コールバックを通じて一致ごとにアプリケーションに通知することも可能です。これにより、プレゼンテーションを更新しながら、一致したテキスト、そのコンテキスト、位置、テキストフレーム、スライド番号を含む監査トレイルを同時に構築できます。

これらの機能は、レビュー、編集（赤字処理）、用語チェック、テンプレートのクリーンアップ、そして自動レポート作成ワークフローに役立ちます。

以下の最初の例では、最初のスライドに単一のテキストボックスがあり、次のテキストが含まれる "sample.pptx" というファイルを使用します。

![サンプルテキスト](sample_text.png)

## **検索範囲を選択**

操作を単一のテキストフレームに限定するには TextFrame のメソッドを使用します。プレゼンテーション全体の該当テキストを処理するには Presentation のメソッドを使用します。

| 操作 | 単一テキストフレーム | プレゼンテーション全体 |
|---|---|---|
| リテラルテキストをハイライト | [TextFrame::highlightText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#highlightText) |
| 正規表現の一致をハイライト | [TextFrame::highlightRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#highlightRegex) |
| リテラルテキストを置換 | [TextFrame::replaceText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#replaceText) |
| 正規表現の一致を置換 | [TextFrame::replaceRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#replaceRegex) |

## **テキスト一致の設定**

文字列リテラルの操作では、TextSearchOptions を使用してマッチングを制御します。

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) は一致を完全な単語のみに制限します。
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) は文字の大小が一致する必要があるかどうかを制御します。
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) はプレゼンテーションレベルの検索、置換、ハイライト操作にスライドノートを含めます。

正規表現の操作は Java の `Pattern` を使用するため、大小文字の区別や単語境界などのマッチング規則は式とそのフラグで定義されます。

## **テキストフレームの所有者を特定**

汎用的なテキスト処理ワークフローでは、検索、置換、検証、エクスポート時に TextFrame を取得することがよくあります。TextFrame::getParentShape と TextFrame::getParentCell を使用して、テキストフレームを所有しているプレゼンテーションオブジェクトを判定します。

所有者に応じて返される値は次のとおりです：

| テキストフレームの所有者 | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape または他のテキストを含むシェイプ | 所有する [Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) | `null` |
| テーブルセル | `null` | 所有する [Cell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cell/) |

両メソッドは読み取り専用のナビゲーションを提供します。呼び出してもテキストフレームは移動せず、所有者も変更されません。汎用コードでは java_is_null で両方の値を確認し、いずれの所有者も取得できない可能性に対応すべきです。

以下の例は SlideUtil::getAllTextFrames を使用してプレゼンテーション内のテキストフレームを列挙します。シェイプの場合はシェイプ名、Java ランタイム型、所属スライドを報告します。テーブルセルの場合は 0 起点の列・行座標と所属スライドを報告します。

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

SmartArt コンテンツの場合は、SmartArtNode::getShapes のシェイプを列挙し、各 SmartArtShape::getTextFrame にアクセスします。テキストフレームは TextFrame::getParentShape で関連シェイプにたどり、TextFrame::getParentCell は `null` を返します。したがって、例のシェイプ分岐は SmartArt ノードのテキストも処理します。

## **コールバックで一致情報を収集**

ハイライトまたは置換メソッドに Java プロキシコールバックを渡すと、すべての一致について通知を受け取れます。コールバックメソッドは対象のテキストフレーム、元テキスト、一致したテキスト、および一致位置を受け取ります。

コールバックはスライド番号を直接受け取らず、以下の実装では親スライドから取得し、スライドノート内のテキストも処理します。結果配列は、テキストが別のスライドタイプに関連付けられている場合に `null` を使用します。

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

操作に渡す前に、この PHP オブジェクトのプロキシを作成します：

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

置換操作の場合、foundText には元の一致テキストが含まれるため、コールバックは正確に置換された語句を記録できます。

## **テキストのハイライト**

TextFrame::highlightText メソッドを使用して、テキストフレーム内の文字列リテラルの一致をハイライトします。検索を制御するには TextSearchOptions を渡します。

以下のコード例では、文字列 **"try"** の全出現箇所をハイライトし、続いて完全な単語 **"to"** のみをハイライトします。

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

    // テキストフレーム内の "try" のすべての出現箇所をハイライトします。
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

    // 完全な単語 "to" のみをハイライトします。
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

TextFrame::highlightRegex メソッドは、正規表現で見つかったテキストの一致をテキストフレーム内でハイライトします。

以下のコードは、7 文字以上の単語すべてをハイライトします：

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

Presentation::highlightText と Presentation::highlightRegex を使用して、プレゼンテーション内のすべての該当テキストフレームを検索します。以下の例では、文字列リテラルとすべてのメールアドレスをハイライトします：

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

文字列リテラルの置換には TextFrame::replaceText、パターンベースの置換には TextFrame::replaceRegex を使用します。これらのメソッドは既存のテキストフレーム内の一致テキストを更新し、プレーン文字列からテキストフレームを再構築するのではなく、周囲のフォーマットを保持します。

以下の例は、綴りのバリエーションを統一し、続いてバージョンラベルを置換します：

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

一致が異なるフォーマットの部分にまたがる場合、置換テキストに適用すべきフォーマットを確認するために出力を確認してください。

## **プレゼンテーション全体でテキストを置換**

Presentation::replaceText と Presentation::replaceRegex を使用して、プレゼンテーション全体に同じ操作を適用します。これにより、テンプレートのクリーンアップ、用語の更新、編集（赤字処理）に便利です。

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

各結果はスライド番号とテキストフレームを保持しているため、アプリケーションは監査、レポート、レビューのワークフロー向けに一致をグループ化できます。以下の例は、収集した結果をまずスライドごとに、次にテキストフレームごとにグループ化します：

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

シェイプのテキストフレームを取得し、そのテキストフレームに対して TextFrame::highlightText、TextFrame::highlightRegex、TextFrame::replaceText、または TextFrame::replaceRegex を呼び出します。Presentation レベルのメソッドはすべての該当テキストフレームを処理します。

**正しい大文字小文字で完全な単語に一致させるにはどうすればよいですか？**

TextSearchOptions::setWholeWordsOnly と TextSearchOptions::setCaseSensitive を `true` に設定し、リテラルテキストのハイライトまたは置換メソッドにオプションを渡します。正規表現の場合は、Java の `Pattern` 自体で単語境界と大文字小文字の区別を定義します。

**検索および置換にスライドノートのテキストを含めることはできますか？**

はい。プレゼンテーションレベルのリテラルテキスト操作を使用する際に、TextSearchOptions::setIncludeNotes を `true` に設定します。

**プレゼンテーションを再度スキャンせずにレポートを作成するにはどうすればよいですか？**

ハイライトまたは置換操作に Java プロキシコールバックを渡します。操作実行中にすべての一致を受け取るため、アプリケーションは元テキスト、一致テキスト、位置、テキストフレーム、導出されたスライド番号を保存し、後でグループ化またはエクスポートできます。

**テキストを置換してもフォーマットは保持されますか？**

TextFrame::replaceText と TextFrame::replaceRegex は既存のテキストフレーム内の一致テキストを変更し、周囲のフォーマットを保持します。一致が異なるフォーマットの部分にまたがる場合は、置換が期待するスタイルになるよう結果を確認してください。