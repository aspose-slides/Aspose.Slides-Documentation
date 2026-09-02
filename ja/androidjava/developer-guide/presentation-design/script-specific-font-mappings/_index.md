---
title: Androidでスクリプト固有テーマフォントを管理
linktitle: スクリプト固有テーマフォント
type: docs
weight: 15
url: /ja/androidjava/script-specific-font-mappings/
keywords:
- スクリプト固有フォント
- テーマフォントマッピング
- 多言語プレゼンテーション
- 書記体系
- キリルフォント
- アラビアフォント
- 日本語フォント
- ジョージアフォント
- ターナフォント
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "PowerPointテーマでスクリプト固有フォントマッピングを検査、追加、置換、削除する（Android向けAspose.SlidesをJavaで使用）。"
---
## **概要**

プレゼンテーションテーマは、異なる書記体系ごとに異なるフォントファミリーを選択できます。これにより、テーマフォントを使用し続ける多言語テキストでも、キリル文字、アラビア文字、日本語、ジョージア文字、ターナ文字などのスクリプトに適したフォントを使用しながら、統一されたフォントスキームに従うことができます。

テーマの[IFontScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontscheme/)には、見出しに通常使用されるメジャーフォントコレクションと、本文に通常使用されるマイナーフォントコレクションが含まれます。ラテン文字および東アジア文字の設定に加えて、両コレクションは[IFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifonts/)インターフェイスを通じて、書記体系タグからフォントファミリ名へのマッピングを公開します。

この記事では、プレゼンテーションのマスターテーマ内のこれらのマッピングを検査および変更し、変更が保存と再読み込みのサイクルで保持されることを確認する方法を示します。

## **スクリプトタグの理解**

スクリプトフォントメソッドは、4文字の BCP 47 スクリプトサブタグを使用して書記体系を識別します。一般的な値は以下のとおりです。

| スクリプトタグ | 書記体系 |
|---|---|
| `Cyrl` | キリル文字 |
| `Arab` | アラビア文字 |
| `Hans` | 簡体字中国語 |
| `Jpan` | 日本語 |
| `Geor` | ジョージア文字 |
| `Thaa` | ターナ文字 |

これらのマッピングはテーマフォントスキームに属し、個々のテキスト部分には属しません。プレゼンテーションはメジャーとマイナーのコレクションで異なるマッピングを定義でき、いくつかのスクリプトのマッピングを省略することもあります。

## **スクリプトフォントマッピングへのアクセスと検査**

[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getMasterTheme--)を使用してプレゼンテーションレベルのテーマにアクセスします。[IFontScheme.getMajor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontscheme/#getMajor--)および[IFontScheme.getMinor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontscheme/#getMinor--)メソッドは、2つの[IFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifonts/)コレクションを返します。

[IFonts.getScriptFontMap](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fonts/#getScriptFontMap--)を呼び出してコレクションからすべてのマッピングを取得します。特定の書記体系を検索するには、スクリプトタグを指定して[IFonts.getScriptFont](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-)を呼び出します。`getScriptFont`は、コレクションが要求されたマッピングを定義していない場合に`null`を返します。

## **マッピングの変更と永続性の検証**

[IFonts.setScriptFont](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-)を使用してマッピングを作成するか、現在のフォントファミリを置き換えます。[IFonts.removeScriptFont](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-)を使用してマッピングを削除します。

以下のエンドツーエンドの例は、既存のすべてのメジャーおよびマイナーマッピングを読み取り、日本語のメジャーフォントを検索し、キリル文字のメジャーフォントを変更し、ターナのマイナーマッピングを削除し、プレゼンテーションを保存して再度開き、両方の変更を検証します。削除ステップを初期テーマに依存しないようにするため、例ではターナのマッピングがまだ定義されていない場合にのみ作成します。

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

検証は通常の `null` 動作を使用します。削除が保存された後、`getScriptFont("Thaa")`はマイナーコレクションに対して`null`を返します。

## **テーママッピングとその他のフォント設定の区別**

スクリプト固有のテーママッピングはフォント選択に関与しますが、直接のテキスト書式設定、置換、フォールバックとは別の問題を解決します。

| メカニズム | 目的 | テーママッピングを変更した場合の影響 |
|---|---|---|
| スクリプト固有のテーマフォントマッピング | 書記体系のメジャーまたはマイナーテーマフォントを選択します。 | 対応するテーマフォントを使用し続けているテキストは、新しいマッピングされたファミリに解決されます。 |
| テキスト部分に明示的に割り当てられたフォント | テーマに依存せず、その部分の要求されたフォントファミリを固定します。 | 直接の書式設定がテーマの選択を上書きするため、部分は変更されないままになる可能性があります。 |
| フォント置換 | 要求されたフォントが利用できない場合や置換ルールが適用される場合にフォントを置き換えます。 | フォントが要求された後に作用し、テーマのスクリプトマッピングを再定義しません。 |
| フォントフォールバック | 選択されたフォントに含まれていないグリフ、特に特定の Unicode 範囲のグリフを提供します。 | 不足しているグリフカバレッジを補填しますが、保存されたテーママッピングは変更しません。 |

最後の2つのメカニズムの詳細については、[Font Substitution](/slides/ja/androidjava/font-substitution/) と [Fallback Fonts](/slides/ja/androidjava/fallback-font/) を参照してください。

[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getMasterTheme--)でマッピングを変更すると、そのテーマに依存した有効な書式設定が適用されているコンテンツにのみ影響します。テキストは、マスタ、レイアウト、スライドからテーマのオーバーライドを継承したり、明示的に割り当てられたフォントを使用したりすることがあります。表示結果がプレゼンテーションレベルのマッピングに従わない場合は、これらのレベルを検査してください。

## **マッピングされたフォントを利用可能にし結果を検証する**

スクリプトマッピングはフォントファミリ名を保存しますが、対応するフォントファイルをインストールまたはロードするわけではありません。一貫したレンダリングとエクスポートのためには、マッピングされたすべてのフォントが環境にインストールされているか、[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) や [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--) などのカスタムソースを介して Aspose.Slides に提供されている必要があります。利用可能なロードオプションについては、[Custom Fonts](/slides/ja/androidjava/custom-font/) を参照してください。

保存されたマッピングの検証は、テーマ定義が保持されたことのみを確認します。フォントが利用可能であるか、すべての必須グリフを含んでいるか、意図したレイアウトが生成されるかは証明できません。必要なすべての書記体系について代表的なテキストを画像または PDF にレンダリングし、出力を検査してください。これにより、フォントの欠如、グリフカバレッジの不完全、フォールバックの動作、レイアウトの変化をプレゼンテーション配布前に検出できます。[Convert PowerPoint Presentations](/slides/ja/androidjava/convert-powerpoint/) でレンダリングとエクスポートの例を確認してください。

## **FAQ**

**スクリプトがマッピングされていない場合、`getScriptFont`は何を返しますか？**

[IFonts.getScriptFont](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-)は、要求されたスクリプトマッピングがメジャーまたはマイナーのフォントコレクションに定義されていない場合に`null`を返します。

**`setScriptFont`は、スクリプトが既に存在する場合に2番目のマッピングを追加しますか？**

いいえ。[IFonts.setScriptFont](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-)は、マッピングが存在しない場合に作成し、同じスクリプトタグが既に存在する場合はマッピングされたフォントファミリを置き換えます。

**テーママッピングを変更してもテキストが変わらなかった理由は何ですか？**

テキストは明示的にフォントが割り当てられているか、オーバーライドにより別のテーマを継承しているか、レンダリング時に置換やフォールバックの影響を受けている可能性があります。プレゼンテーションレベルのスクリプトマッピングは、そのテーマフォントコレクションを参照したままの有効な書式設定が適用されているテキストのみを制御します。

**保存して再度開くだけで多言語出力を検証するのに十分ですか？**

いいえ。再度開くことでテーマデータの永続性は確認できますが、各必要な書記体系から代表的なテキストをレンダリングし、マッピングされたフォントが利用可能で必要なグリフを含んでいることを確認する必要があります。