---
title: JavaScript で PowerPoint プレゼンテーションのテキスト検索と置換
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
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint プレゼンテーション内のテキストを検索、ハイライト、置換し、すべてのマッチを収集します。"
---
## **概要**

Aspose.Slides for Node.js via Java は、個々のテキスト フレームまたはプレゼンテーション全体でテキストの検索、ハイライト、置換ができます。各操作は、結果コールバックを介してマッチごとにアプリケーションに通知することもできます。これにより、プレゼンテーションを更新しながら、マッチしたテキスト、そのコンテキスト、位置、テキスト フレーム、スライド番号を含む監査トレイルを同時に作成できます。

これらの機能は、レビュー、編集、用語チェック、テンプレートのクリーンアップ、そして自動レポート作成ワークフローに有用です。

以下の最初の例では、"sample.pptx" という名前のファイルを使用します。このファイルは、最初のスライドに 1 つのテキスト ボックスがあり、次のテキストが含まれています：

![サンプルテキスト](sample_text.png)

## **検索対象の選択**

[TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) のメソッドを使用して操作を 1 つのテキスト フレームに限定します。[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) のメソッドを使用してプレゼンテーション内のすべての該当テキストを処理します。

| 操作 | 単一テキストフレーム | プレゼンテーション全体 |
|---|---|---|
| リテラルテキストのハイライト | [TextFrame.highlightText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 正規表現マッチのハイライト | [TextFrame.highlightRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| リテラルテキストの置換 | [TextFrame.replaceText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 正規表現マッチの置換 | [TextFrame.replaceRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **テキストマッチングの構成**

リテラルテキストの操作では、[TextSearchOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/) を使用してマッチングを制御します。

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) は完全な単語に一致するように制限します。
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) は文字の大文字小文字が一致する必要があるかどうかを制御します。
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) はスライド ノートをプレゼンテーションレベルの検索、置換、ハイライト操作に含めます。

正規表現の操作は Java の `Pattern` を使用するため、大文字小文字の区別や単語境界などのマッチングルールは式とそのフラグで定義されます。

## **テキストフレームの所有者の特定**

汎用的なテキスト処理ワークフローでは、検索、置換、検証、またはテキストのエクスポート時にしばしば [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) が渡されます。[TextFrame.getParentShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getParentShape--) と [TextFrame.getParentCell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getParentCell--) を使用して、テキスト フレームを所有しているプレゼンテーション オブジェクトを特定します。

期待される値は所有者によって異なります：

| テキストフレームの所有者 | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape または他のテキストを含むシェイプ | 所有する [Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/) | `null` |
| テーブル セル | `null` | 所有する [Cell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cell/) |

両メソッドは読み取り専用のナビゲーションを提供します。呼び出してもテキストフレームは移動せず、所有者も変更されません。汎用コードでは両方の値が `null` かどうかを確認し、所有者がいない可能性に対処すべきです。

次の例は [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) を使用してプレゼンテーション内のテキストフレームを反復処理します。シェイプの場合はシェイプ名、Java ランタイム型、含まれるスライドを報告します。テーブルセルの場合は、0 ベースの列および行座標と含まれるスライドを報告します。

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

SmartArt コンテンツの場合は、[SmartArtNode.getShapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartartnode/#getShapes--) のシェイプを反復し、各 [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) にアクセスします。テキストフレームは [TextFrame.getParentShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getParentShape--) から関連シェイプへたどることができ、[TextFrame.getParentCell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getParentCell--) は `null` を返します。したがって、例のシェイプ分岐は SmartArt ノードからのテキストも処理します。

## **コールバックによるマッチ情報の収集**

結果コールバック用の Java プロキシを作成し、すべてのマッチについて通知を受け取ります。プロキシ関数は、関連するテキストフレーム、元テキスト、マッチしたテキスト、およびマッチ位置を受け取ります。

コールバックはスライド番号を直接受け取りません。以下の実装では、テキストフレームの所有シェイプまたはテーブルセルから取得し、フォールバックとして [TextFrame.getSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getSlide--) を使用しています。また、スライドノート内のテキストも処理します。

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

置換操作の場合、`foundText` には元のマッチテキストが含まれるため、コールバックは正確に置換された用語を記録できます。

## **テキストのハイライト**

[TextFrame.highlightText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) メソッドを使用して、テキストフレーム内のリテラルテキストのマッチをハイライトします。検索を制御するには [TextSearchOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/) を渡します。

以下のコード例は、文字列 **"try"** のすべての出現箇所をハイライトし、その後、完全な単語 **"to"** のみをハイライトします。

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

    // テキストフレーム内の "try" のすべての出現箇所をハイライトします。
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

結果：

![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用したテキストのハイライト**

[TextFrame.highlightRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) メソッドは、テキストフレーム内で正規表現に一致したテキストをハイライトします。

以下のコードは、7 文字以上を含むすべての単語をハイライトします：

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

結果：

![正規表現を使用したハイライトテキスト](highlighted_text_using_regex.png)

## **プレゼンテーション全体でのテキストハイライト**

[Presentation.highlightText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [Presentation.highlightRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) を使用して、プレゼンテーション内のすべての該当テキストフレームを検索します。次の例は、リテラル語句とすべてのメールアドレスをハイライトします：

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

リテラルテキストには [TextFrame.replaceText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) を、パターンベースの置換には [TextFrame.replaceRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を使用します。これらのメソッドは、既存のテキストフレーム内でマッチしたテキストを更新し、プレーン文字列からテキストフレームを再構築する代わりに、周囲の書式を保持します。

以下の例は、綴りのバリエーションを標準化し、続いてバージョンラベルを置換します：

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

マッチが異なる書式の部分にまたがる場合は、出力を確認し、置換テキストに適用すべき書式を確認してください。

## **プレゼンテーション全体でのテキスト置換**

[Presentation.replaceText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [Presentation.replaceRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を使用して、プレゼンテーション全体で同じ操作を適用します。これは、テンプレートのクリーンアップ、用語の更新、編集に有用です。

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

## **レポート用のマッチのグループ化**

収集されたすべての結果はスライド番号とテキストフレームを保持しているため、アプリケーションは監査、レポート、レビューのワークフロー向けにマッチをグループ化できます。以下の例は、結果をまずスライドで、次にテキストフレームでグループ化しています：

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

**プレゼンテーション全体ではなく、単一のテキストボックスだけを検索するにはどうすればよいですか？**

シェイプのテキストフレームを取得し、そのテキストフレームで [TextFrame.highlightText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、[TextFrame.highlightRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)、[TextFrame.replaceText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、または [TextFrame.replaceRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を呼び出します。プレゼンテーションレベルのメソッドは、すべての該当テキストフレームを処理します。

**正しい大文字小文字で完全な単語にマッチさせるにはどうすればよいですか？**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) と [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) を `true` に設定し、リテラルテキストのハイライトまたは置換メソッドにオプションを渡します。正規表現の場合は、Java の `Pattern` 自体で単語境界と大文字小文字の区別を定義します。

**検索および置換にスライドノートのテキストを含めることはできますか？**

はい。プレゼンテーションレベルのリテラルテキスト操作を使用する際に、[TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) を `true` に設定します。上記のコールバック実装は、ノートスライド内のマッチを親スライド番号にマッピングします。

**プレゼンテーションを2回スキャンせずにレポートを作成するにはどうすればよいですか？**

ハイライトまたは置換操作に Java の結果コールバックプロキシを渡します。コールバックは操作実行中にすべてのマッチを受け取るため、アプリケーションは元テキスト、マッチテキスト、位置、テキストフレーム、導出されたスライド番号を保存し、後でグループ化またはエクスポートできます。

**テキストの置換は書式を保持しますか？**

[TextFrame.replaceText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [TextFrame.replaceRegex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) は、既存のテキストフレーム内でマッチしたテキストを変更し、周囲の書式を保持します。マッチが異なる書式の部分にまたがる場合は、結果を確認して置換が期待通りのスタイルになるか確認してください。