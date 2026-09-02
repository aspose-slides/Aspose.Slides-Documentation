---
title: PHPでスクリプト固有のテーマフォントを管理する
linktitle: スクリプト固有のテーマフォント
type: docs
weight: 15
url: /ja/php-java/script-specific-font-mappings/
keywords:
- スクリプト固有フォント
- テーマフォントマッピング
- 多言語プレゼンテーション
- 記述システム
- キリル文字フォント
- アラビア文字フォント
- 日本語フォント
- ジョージア文字フォント
- ターハン文字フォント
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java経由でPHP用Aspose.Slidesを使用し、PowerPointテーマのスクリプト固有フォントマッピングを検査、追加、置換、削除します。"
---
## **概要**

プレゼンテーションのテーマは、異なる記述システムごとに異なるフォントファミリーを選択できます。これにより、テーマフォントを使用し続ける多言語テキストでも、キリル文字、アラビア文字、日本語、ジョージア文字、ターハン文字、その他のスクリプトに適したフォントを使用しながら、統一されたフォントスキームに従うことができます。

テーマの[FontScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontscheme/)には、見出しに通常使用されるメジャーフォントコレクションと、本文に通常使用されるマイナーフォントコレクションが含まれます。Latin と東アジアのフォント設定に加えて、両方の[Fonts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fonts/)コレクションは、記述システムタグからフォントファミリー名へのマッピングを公開します。

この記事では、プレゼンテーションのマスターテーマ内のこれらのマッピングを検査・変更し、保存と再読込のサイクルで変更が保持されることを確認する方法を示します。

## **スクリプトタグを理解する**

スクリプトフォントメソッドは、4文字の BCP 47 スクリプトサブタグを使用して記述システムを識別します。一般的な値は以下のとおりです。

| スクリプトタグ | 記述システム |
|---|---|
| `Cyrl` | キリル文字 |
| `Arab` | アラビア文字 |
| `Hans` | 簡体字中国語 |
| `Jpan` | 日本語 |
| `Geor` | ジョージア文字 |
| `Thaa` | ターハン文字 |

これらのマッピングはテーマフォントスキームに属し、個々のテキスト部分には属しません。プレゼンテーションは、メジャーとマイナーのコレクションに対して異なるマッピングを定義でき、いくつかのスクリプトのマッピングを省略することもあります。

## **スクリプトフォントマッピングへのアクセスと検査**

[Presentation::getMasterTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getMasterTheme) を使用してプレゼンテーションレベルのテーマにアクセスします。[MasterTheme::getFontScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mastertheme/#getFontScheme)、[FontScheme::getMajor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontscheme/#getMajor) および [FontScheme::getMinor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontscheme/#getMinor) メソッドは、2 つの[Fonts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fonts/)コレクションへのアクセスを提供します。

[Fonts::getScriptFontMap](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fonts/#getScriptFontMap) を呼び出すと、コレクション内のすべてのマッピングが取得できます。特定の記述システムを検索するには、対応するスクリプトタグを使って [Fonts::getScriptFont](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fonts/#getScriptFont) を呼び出します。`Fonts::getScriptFont` は、対象のコレクションに要求されたマッピングが定義されていない場合に `null` を返します。

## **マッピングの変更と永続性の確認**

[Fonts::setScriptFont](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fonts/#setScriptFont) を使用してマッピングを作成または現在のフォントファミリーを置き換えます。[Fonts::removeScriptFont](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fonts/#removeScriptFont) を使用してマッピングを削除します。

以下のエンドツーエンド例は、既存のメジャーおよびマイナーのすべてのマッピングを読み取り、日本語メジャーフォントを検索し、キリル文字メジャーフォントを変更し、ターハン文字マイナーマッピングを削除し、プレゼンテーションを保存して再度開き、両方の変更が反映されていることを検証します。削除ステップを初期テーマに依存させないため、例では、ターハンのマッピングがまだ定義されていない場合にのみ作成します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

検証は普通の検索と同じ `null` 動作を使用します。削除が保存された後、`Fonts::getScriptFont("Thaa")` はマイナーコレクションに対して `null` を返します。

## **テーママッピングと他のフォント設定の違い**

スクリプト固有のテーママッピングはフォント選択に参加しますが、直接のテキスト書式設定、置換、フォールバックとは別の問題を解決します。

| メカニズム | 目的 | テーママッピング変更時の影響 |
|---|---|---|
| スクリプト固有のテーマフォントマッピング | 記述システムに対してメジャーまたはマイナーテーマフォントを選択する | 対応するテーマフォントを使用し続けるテキストは、新しいマッピングされたファミリーに解決できる |
| テキスト部分に明示的に割り当てられたフォント | テーマに依存せず、その部分に要求されたフォントファミリーを固定する | 直接の書式設定がテーマ選択を上書きするため、部分は変わらないままになる可能性がある |
| フォント置換 | 要求されたフォントが利用できない場合、または置換規則が適用される場合にフォントを置き換える | フォントが要求された後に作用し、テーマのスクリプトマッピングを再定義しない |
| フォントフォールバック | 選択されたフォントに含まれないグリフを、特定の Unicode 範囲向けに提供する | 欠落したグリフのカバレッジを埋めるだけで、保存されたテーママッピングは変更されない |

最後の 2 つのメカニズムの詳細については、[フォント置換](/slides/ja/php-java/font-substitution/) と [フォールバックフォント](/slides/ja/php-java/fallback-font/) を参照してください。

[Presentation::getMasterTheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getMasterTheme) でマッピングを変更しても、実際の書式設定がまだそのテーマに依存しているコンテンツにのみ影響します。テキストは、マスター、レイアウト、スライドからのテーマオーバーライドを継承したり、明示的に割り当てられたフォントを使用したりすることがあります。表示結果がプレゼンテーションレベルのマッピングに従わない場合は、これらのレベルを検査してください。

## **マッピングされたフォントを利用可能にし結果を検証する**

スクリプトマッピングはフォントファミリー名を保存しますが、対応するフォントファイルをインストールまたはロードするわけではありません。一貫したレンダリングとエクスポートのため、マッピングされたすべてのフォントは環境にインストールするか、[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsloader/#loadExternalFonts) や [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) などのカスタムソースを介して Aspose.Slides に提供する必要があります。利用可能なロードオプションについては、[カスタムフォント](/slides/ja/php-java/custom-font/) を参照してください。

保存されたマッピングの検証は、テーマ定義が保持されたことだけを確認します。フォントが利用可能か、必要なすべてのグリフを含んでいるか、意図したレイアウトが生成されるかは証明できません。各記述システムに対して代表的なテキストを画像または PDF にレンダリングし、出力を検査してください。これにより、欠落フォント、グリフカバレッジの不完全、フォールバック動作、レイアウト変更などをプレゼンテーション配布前に検出できます。[PowerPoint プレゼンテーションの変換](/slides/ja/php-java/convert-powerpoint/) でレンダリングとエクスポートの例をご確認ください。

## **FAQ**

**`Fonts::getScriptFont` はスクリプトがマッピングされていない場合に何を返しますか？**

`[Fonts::getScriptFont](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fonts/#getScriptFont)` は、要求されたスクリプトマッピングがそのメジャーまたはマイナーのフォントコレクションに定義されていないとき `null` を返します。

**`Fonts::setScriptFont` は、スクリプトが既に存在する場合に2つ目のマッピングを追加しますか？**

いいえ。`[Fonts::setScriptFont](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fonts/#setScriptFont)` は、マッピングが存在しないときに作成し、同じスクリプトタグが既に存在する場合はマッピングされたフォントファミリーを置き換えます。

**テーママッピングを変更してもテキストが変わらなかった理由は何ですか？**

テキストが明示的にフォントを割り当てられている、別のテーマオーバーライドを継承している、またはレンダリング時に置換やフォールバックの影響を受けている可能性があります。プレゼンテーションレベルのスクリプトマッピングは、実効書式設定がそのテーマフォントコレクションに依存しているテキストにのみ作用します。

**保存して再度開くだけで多言語出力の検証は十分ですか？**

いいえ。再読込はテーマデータの永続性を確認するだけです。各記述システムの代表テキストを実際にレンダリングし、マッピングされたフォントが利用可能で必要なグリフを含んでいることを確認する必要があります。