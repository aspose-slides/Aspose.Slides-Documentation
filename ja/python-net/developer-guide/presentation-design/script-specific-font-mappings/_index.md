---
title: Pythonでスクリプト固有のテーマフォントを管理する
linktitle: スクリプト固有のテーマフォント
type: docs
weight: 15
url: /ja/python-net/script-specific-font-mappings/
keywords:
- スクリプト固有フォント
- テーマフォントマッピング
- 多言語プレゼンテーション
- 記述システム
- キリル文字フォント
- アラビア文字フォント
- 日本語フォント
- ジョージア文字フォント
- タアナ文字フォント
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "PowerPoint テーマにおけるスクリプト固有フォントマッピングを、Aspose.Slides for Python via .NET を使用して検査、追加、置換、削除します。"
---
## **概要**

プレゼンテーションテーマは、異なる記述システムごとに異なるフォントファミリを選択できます。これにより、テーマフォントを使用し続ける多言語テキストでも、キリル文字、アラビア文字、日本語、ジョージア文字、タアナ文字、およびその他のスクリプトに適したフォントを使用しつつ、統一されたフォントスキームに従うことができます。

テーマの[FontScheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/fontscheme/)には、見出しに通常使用されるメジャーフォントコレクションと、本文に通常使用されるマイナーフォントコレクションが含まれます。ラテン文字と東アジア文字のフォントプロパティに加えて、両方のコレクションは[Fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fonts/)クラスを通じて、記述システムタグからフォントファミリ名へのマッピングを公開します。

この記事では、プレゼンテーションのマスターテーマ内のこれらのマッピングを検査および変更し、変更が保存と再読み込みのサイクルで保持されることを確認する方法を示します。

## **スクリプトタグの理解**

スクリプトフォントメソッドは、4文字の BCP 47 スクリプトサブタグを使用して記述システムを識別します。一般的な値は以下のとおりです。

| スクリプトタグ | 記述システム |
|---|---|
| `Cyrl` | キリル文字 |
| `Arab` | アラビア文字 |
| `Hans` | 簡体字中国語 |
| `Jpan` | 日本語 |
| `Geor` | ジョージア文字 |
| `Thaa` | タアナ文字 |

これらのマッピングはテーマフォントスキームに属し、個々のテキスト部分には属しません。プレゼンテーションは、メジャーおよびマイナーコレクションに対して異なるマッピングを定義でき、いくつかのスクリプトに対するマッピングを省略することもあります。

## **スクリプトフォントマッピングへのアクセスと検査**

[Presentation.master_theme](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/master_theme/) を使用してプレゼンテーションレベルのテーマにアクセスします。[FontScheme.major](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/fontscheme/major/) と [FontScheme.minor](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/fontscheme/minor/) プロパティは、2つの [Fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fonts/) コレクションを返します。

[Fonts.get_script_font_map](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fonts/get_script_font_map/) を呼び出して、コレクションからすべてのマッピングを取得します。特定の記述システムを検索するには、スクリプトタグを指定して [Fonts.get_script_font](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fonts/get_script_font/) を呼び出します。`get_script_font` は、そのコレクションに要求されたマッピングが定義されていない場合に `None` を返します。

## **マッピングの変更と永続性の検証**

[Fonts.set_script_font](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fonts/set_script_font/) を使用してマッピングを作成するか、現在のフォントファミリを置き換えます。[Fonts.remove_script_font](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fonts/remove_script_font/) を使用してマッピングを削除します。

以下のエンドツーエンドの例は、既存のすべてのメジャーおよびマイナーマッピングを読み取り、メジャーの日本語フォントを検索し、キリル文字のメジャーフォントを変更し、マイナーのタアナマッピングを削除し、プレゼンテーションを保存して再度開き、両方の変更を検証します。削除ステップを初期テーマに依存しないようにするため、例ではタアナマッピングがまだ定義されていない場合にのみ作成します。

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

検証は、通常の検索と同じ `None` 動作を使用します。削除が保存された後、`get_script_font("Thaa")` はマイナーコレクションに対して `None` を返します。

## **テーママッピングと他のフォント設定の区別**

スクリプト固有のテーママッピングはフォント選択に関与しますが、直接的なテキスト書式設定、代替、フォールバックとは別の問題を解決します。

| メカニズム | 目的 | テーママッピング変更時の影響 |
|---|---|---|
| スクリプト固有のテーマフォントマッピング | 記述システムに対してメジャーまたはマイナーテーマフォントを選択します。 | 対応するテーマフォントを使用し続けるテキストは、新しいマッピングされたファミリに解決されます。 |
| テキスト部分に明示的に割り当てられたフォント | テーマに依存せず、その部分の要求されたフォントファミリを固定します。 | 直接書式設定がテーマの選択を上書きするため、その部分は変更されない場合があります。 |
| フォント代替 | フォントが利用できない、または代替ルールが適用される場合に要求されたフォントを置き換えます。 | フォントが要求された後に実行され、テーマのスクリプトマッピングを再定義するわけではありません。 |
| フォントフォールバック | 選択されたフォントに含まれないグリフを提供します。特定の Unicode 範囲に対して使用されます。 | 不足しているグリフを補完しますが、保存されたテーママッピングは変更しません。 |

最後の2つのメカニズムについての詳細は、[Font Substitution](/slides/ja/python-net/font-substitution/) および [Fallback Fonts](/slides/ja/python-net/fallback-font/) を参照してください。

[Presentation.master_theme](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/master_theme/) のマッピングを変更すると、効果的な書式設定がそのテーマに依存しているコンテンツのみに影響します。テキストは、マスター、レイアウト、またはスライドからテーマのオーバーライドを継承したり、明示的に割り当てられたフォントを使用したりすることがあります。表示結果がプレゼンテーションレベルのマッピングに従わない場合は、これらのレベルを検査してください。

## **マッピングされたフォントを利用可能にし結果を検証**

スクリプトマッピングはフォントファミリ名を保存しますが、対応するフォントファイルをインストールまたはロードするわけではありません。一貫したレンダリングとエクスポートのために、マッピングされたすべてのフォントは環境にインストールされているか、[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsloader/load_external_fonts/) や [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/document_level_font_sources/) などのカスタムソースを通じて Aspose.Slides に提供されている必要があります。利用可能なロードオプションについては、[Custom Fonts](/slides/ja/python-net/custom-font/) を参照してください。

保存されたマッピングを検証すると、テーマ定義が保持されたことだけが確認されます。フォントが利用可能であること、すべての必要なグリフを含んでいること、意図したレイアウトが生成されることは保証されません。各記述システムごとに代表的なテキストを画像または PDF にレンダリングし、出力を確認してください。これにより、フォントの欠如、グリフカバレッジの不完全、フォールバック動作、レイアウト変更がプレゼンテーション配布前に検出できます。[Convert PowerPoint Presentations](/slides/ja/python-net/convert-powerpoint/) でレンダリングとエクスポートの例をご覧ください。

## **よくある質問**

**スクリプトがマッピングされていない場合、`get_script_font` は何を返しますか？**

[Fonts.get_script_font](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fonts/get_script_font/) は、要求されたスクリプトマッピングがそのメジャーまたはマイナー フォントコレクションで定義されていない場合に `None` を返します。

**スクリプトがすでに存在する場合、`set_script_font` は2つ目のマッピングを追加しますか？**

いいえ。[Fonts.set_script_font](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fonts/set_script_font/) は、マッピングが存在しない場合に作成し、同じスクリプトタグがすでに存在する場合はマッピングされたフォントファミリを置き換えます。

**テーママッピングを変更しても一部のテキストが変わらなかったのはなぜですか？**

テキストには明示的にフォントが割り当てられている、オーバーライドによって異なるテーマを継承している、またはレンダリング時に代替やフォールバックの影響を受けている可能性があります。プレゼンテーションレベルのスクリプトマッピングは、効果的な書式設定がまだそのテーマフォントコレクションを参照しているテキストだけを制御します。

**保存して再度開くだけで多言語出力を検証するのに十分ですか？**

いいえ。再度開くことでテーマデータの永続性は確認できますが、各必要な記述システムから代表的なテキストをレンダリングして、マッピングされたフォントが利用可能であり、必要なグリフを含んでいることを確認する必要があります。