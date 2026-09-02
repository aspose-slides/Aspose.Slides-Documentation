---
title: Java でスクリプト固有のテーマフォントを管理する
linktitle: スクリプト固有のテーマフォント
type: docs
weight: 15
url: /ja/java/script-specific-font-mappings/
keywords:
- スクリプト固有フォント
- テーマフォントマッピング
- 多言語プレゼンテーション
- 記述システム
- キリル文字フォント
- アラビア文字フォント
- 日本語フォント
- ジョージア文字フォント
- ターナ文字フォント
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint テーマ内のスクリプト固有フォントマッピングを検査、追加、置換、削除します。"
---
## **概要**

プレゼンテーションテーマは、異なる記述システムごとに異なるフォントファミリを選択できます。これにより、テーマフォントを使用し続ける多言語テキストが、キリル文字、アラビア文字、日本語、ジョージア文字、ターナ文字などのスクリプトに適したフォントを使用しながら、統一されたフォントスキームに従うことができます。

テーマの[IFontScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontscheme/)には、主に見出しに使用されるメジャーフォントコレクションと、本文に使用されるマイナーフォントコレクションが含まれています。これらのコレクションは、ラテン文字と東アジア文字の設定に加えて、[IFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifonts/)インターフェイスを通じて、記述システムタグからフォントファミリ名へのマッピングを公開します。

この記事では、プレゼンテーションのマスターテーマでこれらのマッピングを検査および変更し、変更が保存と再読み込みのサイクルで保持されることを確認する方法を示します。

## **スクリプトタグの理解**

スクリプトフォントメソッドは、4 文字の BCP 47 スクリプトサブタグを使用して記述システムを識別します。一般的な値は以下の通りです。

| Script tag | 書記体系 |
|---|---|
| `Cyrl` | キリル文字 |
| `Arab` | アラビア文字 |
| `Hans` | 簡体字中国語 |
| `Jpan` | 日本語 |
| `Geor` | ジョージア文字 |
| `Thaa` | ターナ文字 |

これらのマッピングはテーマフォントスキームに属し、個々のテキスト部分には属しません。プレゼンテーションはメジャーとマイナーのコレクションに対して異なるマッピングを定義でき、特定のスクリプトのマッピングを省略することもできます。

## **スクリプトフォントマッピングへのアクセスと検査**

プレゼンテーションレベルのテーマにアクセスするには、[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getMasterTheme--) を使用します。[IFontScheme.getMajor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontscheme/#getMajor--) および [IFontScheme.getMinor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontscheme/#getMinor--) メソッドは、2 つの [IFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifonts/) コレクションを返します。

コレクションからすべてのマッピングを取得するには、[IFonts.getScriptFontMap](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fonts/#getScriptFontMap--) を呼び出します。特定の記述システムを検索するには、そのスクリプトタグを指定して [IFonts.getScriptFont](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) を呼び出します。`getScriptFont` は、対象のコレクションで要求されたマッピングが定義されていない場合に `null` を返します。

## **マッピングの変更と永続性の検証**

[IFonts.setScriptFont](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) を使用してマッピングを作成するか、現在のフォントファミリを置き換えます。[IFonts.removeScriptFont](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) を使用してマッピングを削除します。

以下のエンドツーエンド例では、既存のすべてのメジャーおよびマイナーマッピングを読み取り、日本語のメジャーフォントを検索し、キリル文字のメジャーフォントを変更し、ターナのマイナーマッピングを削除し、プレゼンテーションを保存して再度開き、両方の変更を検証します。削除手順が初期テーマに依存しないように、例ではターナのマッピングがまだ定義されていない場合にのみターナマッピングを作成します。

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

検証は通常の検索と同じ `null` 動作を使用します。削除が保存された後、`getScriptFont("Thaa")` はマイナーコレクションに対して `null` を返します。

## **テーママッピングと他のフォント設定の区別**

スクリプト固有のテーママッピングはフォント選択に関与しますが、直接のテキスト書式設定、代替、フォールバックとは別の問題を解決します。

| メカニズム | 目的 | テーママッピング変更時の影響 |
|---|---|---|
| `Script-specific theme font mapping` | 書記体系のメジャーまたはマイナーテーマフォントを選択します。 | 対応するテーマフォントを使用し続けるテキストは、新しいマッピングされたファミリに解決されます。 |
| `Font assigned explicitly to a text portion` | テーマに依存せず、その部分に要求されたフォントファミリを固定します。 | 直接の書式設定がテーマ選択を上書きするため、該当部分は変更されない可能性があります。 |
| `Font substitution` | フォントが利用できない場合や置換ルールが適用される場合に、要求されたフォントを置き換えます。 | フォントが要求された後に実行され、テーマのスクリプトマッピングを再定義するものではありません。 |
| `Font fallback` | 選択されたフォントに含まれない文字（通常は特定の Unicode 範囲）に対してグリフを提供します。 | 欠落したグリフカバレッジを埋めますが、保存されたテーママッピングは変更しません。 |

最後の 2 つのメカニズムの詳細については、[Font Substitution](/slides/ja/java/font-substitution/) と [Fallback Fonts](/slides/ja/java/fallback-font/) を参照してください。

[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getMasterTheme--) でマッピングを変更しても、実際の書式設定がそのテーマに依存しているコンテンツにのみ影響します。テキストはマスター、レイアウト、スライドからテーマのオーバーライドを継承したり、明示的に割り当てられたフォントを使用したりすることがあります。表示結果がプレゼンテーションレベルのマッピングに従わない場合は、これらのレベルを確認してください。

## **マッピングされたフォントを利用可能にし結果を検証**

スクリプトマッピングはフォントファミリ名を保存しますが、対応するフォントファイルをインストールまたは読み込むわけではありません。一貫したレンダリングとエクスポートを実現するには、マッピングされたすべてのフォントが環境にインストールされているか、[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) や [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--) などのカスタムソースを介して Aspose.Slides に提供されている必要があります。利用可能な読み込みオプションについては、[Custom Fonts](/slides/ja/java/custom-font/) を参照してください。

保存されたマッピングの検証は、テーマ定義が保持されていることのみを確認します。フォントが利用可能であること、必要なすべてのグリフが含まれていること、意図したレイアウトが生成されることは証明できません。各必要な記述システムの代表的なテキストを画像または PDF にレンダリングし、出力を確認してください。これにより、フォントの欠如、グリフカバレッジの不完全、フォールバック動作、レイアウトの変更が、プレゼンテーション配布前に検出できます。[Convert PowerPoint Presentations](/slides/ja/java/convert-powerpoint/) でレンダリングとエクスポートの例をご覧ください。

## **FAQ**

**What does `getScriptFont` return when a script is not mapped?**

`[IFonts.getScriptFont](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-)` は、要求されたスクリプトマッピングがメジャーまたはマイナーのフォントコレクションに定義されていない場合に `null` を返します。

**Does `setScriptFont` add a second mapping when the script already exists?**

いいえ。`[IFonts.setScriptFont](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-)` は、マッピングが存在しない場合に作成し、同じスクリプトタグが既に存在する場合はマッピングされたフォントファミリを置き換えます。

**Why did changing a theme mapping not change some text?**

テキストが明示的にフォントを割り当てられている、オーバーライドにより別のテーマを継承している、またはレンダリング時に代替やフォールバックの影響を受けている可能性があります。プレゼンテーションレベルのスクリプトマッピングは、実際の書式設定がそのテーマフォントコレクションを参照しているテキストのみに影響します。

**Is saving and reopening enough to validate multilingual output?**

いいえ。再度開くことはテーマデータの永続性を確認するだけです。各必要な記述システムから代表的なテキストをレンダリングし、マッピングされたフォントが利用可能で必要なグリフを含んでいることも確認してください。