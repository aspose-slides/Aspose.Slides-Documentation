---
title: C++ でスクリプト固有のテーマフォントを管理する
linktitle: スクリプト固有のテーマフォント
type: docs
weight: 15
url: /ja/cpp/script-specific-font-mappings/
keywords:
- スクリプト固有フォント
- テーマフォントマッピング
- 多言語プレゼンテーション
- 文字体系
- キリル文字フォント
- アラビア文字フォント
- 日本語フォント
- グルジア文字フォント
- ターハ文字フォント
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint テーマ内のスクリプト固有フォントマッピングを検査、追加、置換、削除します。"
---
## **概要**

プレゼンテーションのテーマは、異なる書記体系ごとに異なるフォントファミリーを選択できます。これにより、テーマフォントを使用しつつ多言語テキストが、キリル文字、アラビア文字、日本語、グルジア文字、ターハ文字、その他のスクリプトに適したフォントを用いて、統一されたフォントスキームに従うことができます。

テーマの[IFontScheme](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/ifontscheme/)には、主に見出しに使用されるメジャーフォントコレクションと、本文に使用されるマイナーフォントコレクションが含まれます。ラテン文字と東アジア文字のプロパティに加えて、両コレクションは[IFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifonts/)インターフェイスを介して、書記体系タグからフォントファミリー名へのマッピングを公開しています。

この記事では、プレゼンテーションのマスターテーマでこれらのマッピングを検査・変更し、保存と再読み込みのサイクルで変更が保持されることを確認する方法を示します。

## **スクリプトタグの理解**

スクリプトフォントメソッドは、4 文字の BCP 47 スクリプトサブタグを使用して書記体系を識別します。一般的な値は以下の通りです。

| スクリプトタグ | 文字体系 |
|---|---|
| `Cyrl` | キリル文字 |
| `Arab` | アラビア文字 |
| `Hans` | 簡体字中国語 |
| `Jpan` | 日本語 |
| `Geor` | グルジア文字 |
| `Thaa` | ターハ文字 |

これらのマッピングは個々のテキスト部分ではなく、テーマフォントスキームに属します。プレゼンテーションはメジャーとマイナーのコレクションで異なるマッピングを定義でき、いくつかのスクリプトについてはマッピングを省略することもあります。

## **スクリプトフォントマッピングへのアクセスと検査**

[Presentation::get_MasterTheme](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_mastertheme/) を使用してプレゼンテーションレベルのテーマにアクセスします。[FontScheme::get_Major](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/fontscheme/get_major/) と [FontScheme::get_Minor](https://reference.aspose.com/slides/ja/cpp/aspose.slides.theme/fontscheme/get_minor/) メソッドは、2 つの [IFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifonts/) コレクションを返します。

[Fonts::GetScriptFontMap](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fonts/getscriptfontmap/) を呼び出すと、コレクション内のすべてのマッピングを取得できます。特定の書記体系を検索するには、対応するスクリプトタグを指定して [Fonts::GetScriptFont](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fonts/getscriptfont/) を呼びます。`GetScriptFont` は、コレクションで要求されたマッピングが定義されていない場合に null 文字列を返します。

## **マッピングの変更と永続性の検証**

[Fonts::SetScriptFont](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fonts/setscriptfont/) を使用してマッピングを作成するか、現在のフォントファミリーを置き換えます。[Fonts::RemoveScriptFont](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fonts/removescriptfont/) を使用してマッピングを削除します。

以下のエンドツーエンド例は、既存のメジャーおよびマイナーのすべてのマッピングを読み取り、日本語のメジャーフォントを検索し、キリル文字のメジャーフォントを変更し、ターハ文字のマイナーマッピングを削除し、プレゼンテーションを保存して再度開き、両方の変更を検証します。削除ステップを初期テーマに依存させないように、例ではターハ文字のマッピングが未定義の場合にのみ作成します。

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

検証は通常の検索と同じ null 文字列の挙動を利用します。削除が保存された後、`GetScriptFont(u"Thaa")` はマイナーコレクションで null 文字列を返します。

## **テーママッピングと他のフォント設定の区別**

スクリプト固有のテーママッピングはフォント選択に参加しますが、直接的なテキスト書式設定、置換、フォールバックとは別の問題を解決します。

| メカニズム | 用途 | テーママッピングを変更した場合の影響 |
|---|---|---|
| スクリプト固有のテーマフォントマッピング | 書記体系に対してメジャーまたはマイナーテーマフォントを選択する | 対応するテーマフォントを使用し続けるテキストは、新しいマッピングされたファミリーに解決される |
| テキスト部分に明示的に割り当てられたフォント | テーマに依存せず、その部分のフォントファミリーを固定する | 直接書式設定がテーマ選択を上書きするため、変更が反映されないことがある |
| フォント置換 | 要求されたフォントが利用不可、または置換規則が適用されたときに別のフォントに置き換える | フォントが要求された後に適用され、テーマのスクリプトマッピングを再定義しない |
| フォントフォールバック | 選択されたフォントに含まれないグリフを、特定の Unicode 範囲向けに提供する | 欠損グリフを補完するだけで、保存されたテーママッピングは変更されない |

最後の 2 つのメカニズムの詳細は、[Font Substitution](/slides/ja/cpp/font-substitution/) と [Fallback Fonts](/slides/ja/cpp/fallback-font/) を参照してください。

[Presentation::get_MasterTheme](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_mastertheme/) でマッピングを変更しても、実効書式がそのテーマに依存しているコンテンツにしか影響しません。テキストはマスター、レイアウト、スライドからのテーマオーバーライドを継承したり、明示的にフォントが割り当てられている場合があります。見た目の結果がプレゼンテーションレベルのマッピングに従わないときは、これらのレベルを調べてください。

## **マッピングされたフォントを利用可能にし結果を検証する**

スクリプトマッピングはフォントファミリー名を保存するだけで、対応するフォントファイルをインストールしたり読み込んだりはしません。安定したレンダリングとエクスポートのため、すべてのマッピングフォントは環境にインストールするか、[FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsloader/loadexternalfonts/) や [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) などのカスタムソースを通じて Aspose.Slides に提供する必要があります。利用可能なロードオプションについては、[Custom Fonts](/slides/ja/cpp/custom-font/) を参照してください。

保存されたマッピングの検証は、テーマ定義が保持されたことだけを確認します。フォントが利用可能であるか、必要なすべてのグリフを含んでいるか、意図したレイアウトが生成されるかは証明できません。各必須書記体系の代表的なテキストを画像または PDF にレンダリングし、出力を確認してください。これにより、欠落フォント、グリフカバレッジの不完全、フォールバックの挙動、レイアウト変更などを、プレゼンテーション配布前に把握できます。[Convert PowerPoint Presentations](/slides/ja/cpp/convert-powerpoint/) でレンダリングとエクスポートの例を確認してください。

## **FAQ**

**`GetScriptFont` はスクリプトがマッピングされていない場合に何を返しますか？**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fonts/getscriptfont/) は、要求されたスクリプトマッピングがそのメジャーまたはマイナーコレクションに定義されていない場合に null 文字列を返します。

**`SetScriptFont` はスクリプトが既に存在する場合に2つ目のマッピングを追加しますか？**

いいえ。[Fonts::SetScriptFont](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fonts/setscriptfont/) は、マッピングが存在しないときに作成し、同じスクリプトタグが既に存在する場合はマッピングされたフォントファミリーを置き換えます。

**テーママッピングを変更してもテキストが変わらなかったのはなぜですか？**

テキストに明示的にフォントが割り当てられている、別のテーマオーバーライドを継承している、またはレンダリング時に置換やフォールバックが適用された可能性があります。プレゼンテーションレベルのスクリプトマッピングは、実効書式がそのテーマフォントコレクションに依存しているテキストにのみ影響します。

**保存と再オープンだけで多言語出力を検証できますか？**

できません。再オープンはテーマデータの永続性を確認しますが、マッピングされたフォントが利用可能であるか、必要なグリフをすべて含んでいるか、期待通りのレイアウトになるかは確認できません。各書記体系の代表テキストをレンダリングして、フォントの可用性と正しい表示を検証してください。