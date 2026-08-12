---
title: JavaScript で PowerPoint プレゼンテーションのテキストを検索および置換
linktitle: テキストの検索と置換
type: docs
weight: 55
url: /ja/nodejs-java/search-and-replace-text/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint プレゼンテーションのテキストを検索、ハイライト、置換し、すべてのマッチを収集します。"
---
## **概要**

Aspose.Slides for Node.js via Java は、個々のテキストフレームまたはプレゼンテーション全体でテキストの検索、ハイライト、置換が可能です。各操作は結果コールバックを通じてマッチごとにアプリケーションに通知することもできます。これにより、プレゼンテーションを更新しながら、マッチしたテキスト、そのコンテキスト、位置、テキストフレーム、スライド番号を含む監査トレイルを同時に構築できます。

これらの機能は、レビュー、情報削除、用語チェック、テンプレートのクリーンアップ、および自動レポート作成ワークフローに役立ちます。

以下の最初の例では、"sample.pptx" というファイルを使用します。このファイルは、最初のスライドに 1 つのテキストボックスがあり、次のテキストが含まれています:
![サンプルテキスト](sample_text.png)

## **検索範囲の選択**

[TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) のメソッドを使用して操作を 1 つのテキストフレームに限定します。[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) のメソッドを使用してプレゼンテーション内のすべての対象テキストを処理します。

| 操作 | 単一テキストフレーム | プレゼンテーション全体 |
|---|---|---|
| リテラルテキストのハイライト | [TextFrame.highlightText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 正規表現マッチのハイライト | [TextFrame.highlightRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| リテラルテキストの置換 | [TextFrame.replaceText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 正規表現マッチの置換 | [TextFrame.replaceRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **テキストマッチングの構成**

リテラルテキスト操作では、[TextSearchOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/) を使用してマッチングを制御します。

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) はマッチを完全な単語のみに制限します。
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) は文字の大小が一致するかどうかを制御します。
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) はプレゼンテーションレベルの検索、置換、ハイライト操作にスライドノートを含めます。

正規表現操作は Java の `Pattern` を使用するため、大小文字の区別や単語境界などのマッチングルールは式とそのフラグで定義されます。

## **コールバックによるマッチ情報の収集**

結果コールバック用の Java プロキシを作成し、すべてのマッチについて通知を受け取ります。プロキシ関数は関連するテキストフレーム、元テキスト、マッチしたテキスト、マッチ位置を受け取ります。

コールバックはスライド番号を直接受け取りません。以下の実装は [TextFrame.getSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getSlide--)、[Slide.getSlideNumber](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#getSlideNumber--)、[NotesSlide.getParentSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notesslide/#getParentSlide--) を通じて取得します。また、スライドノート内のテキストも処理します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

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

置換操作では、`foundText` に元のマッチテキストが含まれるため、コールバックは正確にどの語句が置換されたかを記録できます。

## **テキストのハイライト**

[TextFrame.highlightText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) メソッドを使用して、テキストフレーム内のリテラルテキストのマッチをハイライトします。[TextSearchOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/) を渡して検索を制御します。

以下のコード例は、文字列 **"try"** のすべての出現をハイライトし、その後、完全な単語 **"to"** のみをハイライトします。

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

    // テキストフレーム内の "try" のすべての出現をハイライトします。
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // 完全な単語 "to" のみをハイライトします。
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:
![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用したテキストのハイライト**

[TextFrame.highlightRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) メソッドは、テキストフレーム内で正規表現によって見つかったテキストマッチをハイライトします。

以下のコードは、7 文字以上を含むすべての単語をハイライトします。

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

結果:
![正規表現を使用したハイライトテキスト](highlighted_text_using_regex.png)

## **プレゼンテーション全体のテキストハイライト**

[Presentation.highlightText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [Presentation.highlightRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) を使用して、プレゼンテーション内のすべての対象テキストフレームを検索します。以下の例は、リテラル語とすべてのメールアドレスをハイライトします。

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

## **テキストフレーム内のテキスト置換**

リテラルテキストには [TextFrame.replaceText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、パターンベースの置換には [TextFrame.replaceRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を使用します。これらのメソッドは既存のテキストフレーム内のマッチしたテキストを更新し、プレーン文字列からテキストフレームを再構築するのではなく、周囲の書式設定を保持します。

以下の例は、綴りのバリエーションを標準化し、その後バージョンラベルを置換します。

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

マッチが異なる書式の部分にまたがる場合、出力を確認して置換テキストに適用すべき書式を確認してください。

## **プレゼンテーション全体のテキスト置換**

[Presentation.replaceText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [Presentation.replaceRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を使用して、プレゼンテーション全体に同じ操作を適用します。これはテンプレートのクリーンアップ、用語の更新、情報削除に役立ちます。

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

## **レポート用のマッチグループ化**

収集された各結果はスライド番号とテキストフレームを保持するため、アプリケーションは監査、レポート、またはレビューのワークフロー向けにマッチをグループ化できます。以下の例は、結果をまずスライドごとに、次にテキストフレームごとにグループ化します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

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

## **よくある質問**

**プレゼンテーション全体ではなく、1 つのテキストボックスだけを検索するにはどうすればよいですか？**

シェイプのテキストフレームを取得し、そのテキストフレーム上で [TextFrame.highlightText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、[TextFrame.highlightRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)、[TextFrame.replaceText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、または [TextFrame.replaceRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を呼び出します。プレゼンテーションレベルのメソッドは、すべての対象テキストフレームを処理します。

**正しい大文字小文字で完全な単語にマッチさせるにはどうすればよいですか？**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) と [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) を `true` に設定し、リテラルテキストのハイライトまたは置換メソッドにオプションを渡します。正規表現の場合は、Java の `Pattern` 自体で単語境界と大文字小文字の区別を定義します。

**検索および置換にスライドノート内のテキストを含めることはできますか？**

はい。プレゼンテーションレベルのリテラルテキスト操作を使用する際に、[TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) を `true` に設定します。上記のコールバック実装は、ノートスライド内のマッチを親スライド番号にマッピングします。

**プレゼンテーションを二度スキャンせずにレポートを作成するにはどうすればよいですか？**

ハイライトまたは置換操作に Java の結果コールバックプロキシを渡します。コールバックは操作実行中にすべてのマッチを受け取り、アプリケーションは元テキスト、マッチテキスト、位置、テキストフレーム、導出されたスライド番号を保存して、後でグループ化またはエクスポートできるようにします。

**テキストの置換は書式を保持しますか？**

[TextFrame.replaceText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [TextFrame.replaceRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) は既存のテキストフレーム内のマッチしたテキストを変更し、周囲の部分の書式を保持します。マッチが異なる書式の部分にまたがる場合、置換が期待するスタイルになるよう結果を確認してください。