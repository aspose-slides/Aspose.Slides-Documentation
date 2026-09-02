---
title: JavaScript でスクリプト固有のテーマフォントを管理する
linktitle: スクリプト固有のテーマフォント
type: docs
weight: 15
url: /ja/nodejs-java/script-specific-font-mappings/
keywords:
- スクリプト固有フォント
- テーマフォントマッピング
- 多言語プレゼンテーション
- 書記体系
- キリルフォント
- アラビアフォント
- 日本語フォント
- ジョージアフォント
- サーナフォント
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、PowerPoint テーマ内のスクリプト固有フォントマッピングを検査、追加、置換、削除します。"
---
## **概要**

プレゼンテーションテーマは、異なる書記体系に対して異なるフォントファミリーを選択できます。これにより、テーマフォントを使用し続ける多言語テキストでも、キリル文字、アラビア文字、日本語、ジョージア文字、サーナ文字などのスクリプトに適したフォントを使用しつつ、統一されたフォントスキームに従うことができます。

テーマの[FontScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontscheme/)には、見出しに主に使用されるメジャーフォントコレクションと、本文に主に使用されるマイナーフォントコレクションが含まれます。ラテン文字および東アジア文字の設定に加えて、両コレクションは[Fonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fonts/)クラスを介して、書記体系タグからフォントファミリー名へのマッピングを公開します。

本記事では、プレゼンテーションのマスターテーマにあるこれらのマッピングを確認・変更する方法と、保存と再読み込みのサイクルで変更が維持されることを検証する方法を示します。

## **スクリプトタグを理解する**

スクリプトフォントメソッドは、4 文字の BCP 47 スクリプトサブタグを使用して書記体系を識別します。一般的な値は次のとおりです。

| スクリプトタグ | 書記体系 |
|---|---|
| `Cyrl` | キリル文字 |
| `Arab` | アラビア文字 |
| `Hans` | 簡体字中国語 |
| `Jpan` | 日本語 |
| `Geor` | ジョージア文字 |
| `Thaa` | サーナ文字 |

これらのマッピングはテーマフォントスキームに属し、個々のテキスト部分には属しません。プレゼンテーションはメジャーコレクションとマイナーコレクションで別々のマッピングを定義でき、いくつかのスクリプトのマッピングを省略することもあります。

## **スクリプトフォントマッピングへのアクセスと検査**

[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getmastertheme/) を使用してプレゼンテーションレベルのテーマにアクセスします。[FontScheme.getMajor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontscheme/) および [FontScheme.getMinor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontscheme/) メソッドは、2 つの [Fonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fonts/) コレクションを返します。

[Fonts.getScriptFontMap](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fonts/) を呼び出すと、コレクション内のすべてのマッピングを取得できます。特定の書記体系を調べるには、スクリプトタグを指定して [Fonts.getScriptFont](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fonts/) を呼び出します。要求されたマッピングがそのコレクションに定義されていない場合、`getScriptFont` は `null` を返します。

## **マッピングの変更と永続性の検証**

[Fonts.setScriptFont](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fonts/) を使用してマッピングを作成するか、現在のフォントファミリーを置き換えます。[Fonts.removeScriptFont](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fonts/) でマッピングを削除できます。

以下のエンドツーエンド例は、既存のメジャーおよびマイナーマッピングをすべて読み取り、メジャーの日本語フォントを検索し、メジャーのキリル文字フォントを変更し、マイナーのサーナ文字マッピングを削除し、プレゼンテーションを保存して再度開き、両方の変更が保持されていることを検証します。削除ステップを初期テーマに依存させないよう、例ではサーナマッピングが未定義の場合にのみ作成します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

検証は通常の検索と同じ `null` 挙動を使用します。削除が保存された後、`getScriptFont("Thaa")` はマイナーコレクションで `null` を返します。

## **テーママッピングと他のフォント設定の区別**

スクリプト固有のテーママッピングはフォント選択に参加しますが、直接テキスト書式設定、置換、フォールバックとは別の問題を解決します。

| メカニズム | 目的 | テーママッピング変更時の影響 |
|---|---|---|
| スクリプト固有のテーマフォントマッピング | 書記体系に対してメジャーまたはマイナーテーマフォントを選択する | 対応するテーマフォントを使用しているテキストは、新しいマッピングされたファミリーに解決される |
| テキスト部分に明示的に割り当てられたフォント | その部分のフォントファミリーをテーマに依存せず固定する | 直接書式設定がテーマ選択を上書きするため、変更が反映されないことがある |
| フォント置換 | 要求されたフォントが利用できない場合や置換ルールが適用される場合に置き換える | フォントが要求された後に実行され、テーマのスクリプトマッピング自体は再定義されない |
| フォントフォールバック | 選択したフォントに含まれないグリフを補う。特定の Unicode 範囲でよく使用される | 欠落したグリフを補うだけで、保存されたテーママッピングは変更されない |

最後の 2 つのメカニズムの詳細については、[Font Substitution](/slides/ja/nodejs-java/font-substitution/) と [Fallback Fonts](/slides/ja/nodejs-java/fallback-font/) を参照してください。

[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getmastertheme/) でマッピングを変更しても、実際の書式設定がそのテーマに依存しているコンテンツにのみ影響します。テキストがマスタ、レイアウト、スライドからテーマオーバーライドを継承している、または明示的にフォントが割り当てられている場合は、表示結果がプレゼンテーションレベルのマッピングに従わないことがあります。そのような場合は、これらのレベルも検査してください。

## **マッピングされたフォントを利用可能にし、結果を検証する**

スクリプトマッピングはフォントファミリー名を保存するだけで、対応するフォントファイルをインストールまたはロードするわけではありません。安定したレンダリングとエクスポートのためには、マッピングされたすべてのフォントを環境にインストールするか、[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) や [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/) などのカスタムソースを介して Aspose.Slides に提供する必要があります。利用可能なロードオプションについては、[Custom Fonts](/slides/ja/nodejs-java/custom-font/) を参照してください。

保存されたマッピングの検証は、テーマ定義が保持されたことのみを確認します。フォントが実際に利用可能か、必要なすべてのグリフを含んでいるか、意図したレイアウトが生成されるかは保証しません。各書記体系ごとに代表的なテキストを画像または PDF にレンダリングし、出力を確認してください。これにより、フォント不足、グリフカバレッジの不完全、フォールバック動作、レイアウトの変化などを、プレゼンテーション配布前に検出できます。[Convert PowerPoint Presentations](/slides/ja/nodejs-java/convert-powerpoint/) でレンダリングとエクスポートの例を確認してください。

## **FAQ**

**`getScriptFont` はスクリプトがマッピングされていない場合に何を返しますか？**

[Fonts.getScriptFont](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fonts/) は、要求されたスクリプトマッピングがそのメジャーまたはマイナーコレクションに定義されていない場合、`null` を返します。

**`setScriptFont` は既にスクリプトが存在する場合に二重にマッピングを追加しますか？**

いいえ。[Fonts.setScriptFont](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fonts/) は、マッピングが存在しないときに作成し、同じスクリプトタグが既に存在する場合はマッピングされたフォントファミリーを置き換えます。

**テーママッピングを変更してもテキストが変わらなかった理由は何ですか？**

テキストに明示的にフォントが割り当てられている、別のテーマからオーバーライドを継承している、またはレンダリング時に置換やフォールバックが適用された可能性があります。プレゼンテーションレベルのスクリプトマッピングは、効果的な書式設定がそのテーマフォントコレクションを参照しているテキストにのみ影響します。

**保存と再オープンだけで多言語出力を検証できますか？**

できません。再オープンはテーマデータの永続性を確認しますが、マッピングされたフォントが利用可能で必要なグリフを含んでいるかを確認するには、各書記体系の代表テキストを実際にレンダリングして検証する必要があります。