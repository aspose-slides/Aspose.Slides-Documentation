---
title: .NET でスクリプト固有のテーマフォントを管理
linktitle: スクリプト固有のテーマフォント
type: docs
weight: 15
url: /ja/net/script-specific-font-mappings/
keywords:
- スクリプト固有のフォント
- テーマフォントマッピング
- 多言語プレゼンテーション
- 文字体系
- キリル文字フォント
- アラビア文字フォント
- 日本語フォント
- ジョージア文字フォント
- タナ文字フォント
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides で PowerPoint テーマのスクリプト固有フォントマッピングを検査、追加、置換、削除します。"
---
## **概要**

プレゼンテーションのテーマは、異なる文字体系ごとに異なるフォントファミリーを選択できます。これにより、テーマフォントを使用し続ける多言語テキストでも、キリル文字、アラビア文字、日本語、ジョージア文字、タナ文字、その他のスクリプトに適したフォントを使用しながら、統一されたフォントスキームに従うことができます。

テーマの[IFontScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/ifontscheme/)には、主に見出しに使用されるメジャーフォントコレクションと、主に本文に使用されるマイナーフォントコレクションが含まれます。これらのコレクションは、ラテン文字および東アジア文字のフォントプロパティに加えて、[IFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/ifonts/)インターフェイスを通じて文字体系タグからフォントファミリー名へのマッピングを公開します。

この記事では、プレゼンテーションのマスターテーマ内でこれらのマッピングを検査および変更し、変更が保存と再読み込みのサイクルを経ても維持されることを確認する方法を示します。

## **スクリプトタグの理解**

スクリプトフォントメソッドは、4文字の BCP 47 スクリプトサブタグを使用して文字体系を識別します。一般的な値は以下の通りです：

| スクリプトタグ | 文字体系 |
|---|---|
| `Cyrl` | キリル文字 |
| `Arab` | アラビア文字 |
| `Hans` | 簡体字中国語 |
| `Jpan` | 日本語 |
| `Geor` | ジョージア文字 |
| `Thaa` | タナ文字 |

これらのマッピングはテーマフォントスキームに属し、個々のテキスト部分には属しません。プレゼンテーションはメジャーとマイナーのコレクションで異なるマッピングを定義でき、特定のスクリプトのマッピングを省略することもあります。

## **スクリプトフォントマッピングへのアクセスと検査**

プレゼンテーションレベルのテーマにアクセスするには[Presentation.MasterTheme](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/mastertheme/)を使用します。[FontScheme.Major](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/fontscheme/major/)および[FontScheme.Minor](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/fontscheme/minor/)プロパティは、2つの[IFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/ifonts/)コレクションを返します。

コレクションからすべてのマッピングを取得するには[IFonts.GetScriptFontMap](https://reference.aspose.com/slides/ja/net/aspose.slides/fonts/getscriptfontmap/)を呼び出します。特定の文字体系を検索するには、そのスクリプトタグを指定して[IFonts.GetScriptFont](https://reference.aspose.com/slides/ja/net/aspose.slides/fonts/getscriptfont/)を呼び出します。`GetScriptFont`は、コレクションが要求されたマッピングを定義していない場合に`null`を返します。

## **マッピングの変更と永続性の検証**

[IFonts.SetScriptFont](https://reference.aspose.com/slides/ja/net/aspose.slides/fonts/setscriptfont/)を使用してマッピングを作成するか、現在のフォントファミリーを置き換えます。[IFonts.RemoveScriptFont](https://reference.aspose.com/slides/ja/net/aspose.slides/fonts/removescriptfont/)を使用してマッピングを削除します。

以下のエンドツーエンドの例では、既存のすべてのメジャーおよびマイナーマッピングを読み取り、日本語のメジャーフォントを検索し、キリル文字のメジャーフォントを変更し、タナ文字のマイナーマッピングを削除し、プレゼンテーションを保存して再度開き、両方の変更を検証します。削除ステップを初期テーマに依存しないようにするため、例ではタナマッピングがまだ定義されていない場合にのみ作成します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

検証は通常の検索と同じ`null`動作を使用します。削除が保存された後、`GetScriptFont("Thaa")`はマイナーコレクションに対して`null`を返します。

## **テーママッピングと他のフォント設定の区別**

スクリプト固有のテーママッピングはフォント選択に関与しますが、直接的なテキスト書式設定、置換、フォールバックとは別の問題を解決します。

| メカニズム | 目的 | テーママッピング変更の影響 |
|---|---|---|
| スクリプト固有のテーマフォントマッピング | 文字体系のメジャーまたはマイナーテーマフォントを選択します。 | 対応するテーマフォントを使用し続けるテキストは、新しいマッピングされたファミリーに解決されます。 |
| テキスト部分に明示的に割り当てられたフォント | テーマに依存せず、その部分の要求されたフォントファミリーを固定します。 | 直接の書式設定がテーマの選択を上書きするため、部分は変更されないままになる可能性があります。 |
| フォント置換 | フォントが利用できない場合や置換ルールが適用される場合に、要求されたフォントを置き換えます。 | フォントが要求された後に作用し、テーマのスクリプトマッピングを再定義するものではありません。 |
| フォントフォールバック | 選択されたフォントに含まれないグリフを提供します（特定の Unicode 範囲など）。 | 欠けているグリフを補完しますが、保存されたテーママッピングは変更しません。 |

最後の2つのメカニズムの詳細については、[Font Substitution](/slides/ja/net/font-substitution/) と [Fallback Fonts](/slides/ja/net/fallback-font/) を参照してください。

[Presentation.MasterTheme](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/mastertheme/)でマッピングを変更すると、実際の書式設定がまだそのテーマに依存しているコンテンツにのみ影響します。テキストは代わりにマスター、レイアウト、スライドからテーマのオーバーライドを継承したり、明示的に割り当てられたフォントを使用したりすることがあります。表示結果がプレゼンテーションレベルのマッピングに従わない場合は、これらのレベルを検査してください。

## **マッピングされたフォントを利用可能にし結果を検証する**

スクリプトマッピングはフォントファミリー名を保存しますが、対応するフォントファイルをインストールまたはロードするわけではありません。一貫したレンダリングとエクスポートのために、マッピングされたすべてのフォントは環境にインストールされているか、[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsloader/loadexternalfonts/) や [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/documentlevelfontsources/) などのカスタムソースを介して Aspose.Slides に提供されなければなりません。利用可能なロードオプションについては、[Custom Fonts](/slides/ja/net/custom-font/) を参照してください。

保存されたマッピングを検証すると、テーマ定義が保持されたことだけが確認されます。フォントが利用可能であるか、必要なすべてのグリフを含んでいるか、意図したレイアウトを生成するかは証明されません。各必要な文字体系の代表的なテキストを画像または PDF にレンダリングし、出力を検査してください。これにより、フォントの欠落、グリフカバレッジの不完全、フォールバックの動作、レイアウトの変更がプレゼンテーション配布前に検出できます。[Convert PowerPoint Presentations](/slides/ja/net/convert-powerpoint/) でレンダリングとエクスポートの例をご覧ください。

## **FAQ**

**スクリプトがマッピングされていない場合、`GetScriptFont`は何を返しますか？**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/ja/net/aspose.slides/fonts/getscriptfont/)は、要求されたスクリプトマッピングがそのメジャーまたはマイナーフォントコレクションに定義されていない場合に`null`を返します。

**スクリプトが既に存在する場合、`SetScriptFont`は2つ目のマッピングを追加しますか？**

いいえ。[IFonts.SetScriptFont](https://reference.aspose.com/slides/ja/net/aspose.slides/fonts/setscriptfont/)は、マッピングが存在しない場合に作成し、同じスクリプトタグが既に存在する場合はマッピングされたフォントファミリーを置き換えます。

**テーママッピングを変更しても一部のテキストが変わらなかった理由は何ですか？**

テキストは明示的にフォントが割り当てられているか、オーバーライドによって別のテーマを継承しているか、レンダリング時に置換やフォールバックの影響を受けている可能性があります。プレゼンテーションレベルのスクリプトマッピングは、実際の書式設定がまだそのテーマフォントコレクションを参照しているテキストにのみ影響します。

**保存して再度開くだけで多言語出力を検証するのに十分ですか？**

いいえ。再度開くことでテーマデータの永続性は確認できますが、各必要な文字体系から代表的なテキストをレンダリングし、マッピングされたフォントが利用可能で必要なグリフを含んでいることを確認する必要があります。