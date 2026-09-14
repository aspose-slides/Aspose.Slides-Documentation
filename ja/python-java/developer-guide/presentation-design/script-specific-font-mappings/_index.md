---
title: Python（Java経由）でスクリプト固有のテーマフォントを管理
linktitle: スクリプト固有のテーマフォント
type: docs
weight: 15
url: /ja/python-java/script-specific-font-mappings/
keywords:
- スクリプト固有のフォント
- テーマフォントマッピング
- 多言語プレゼンテーション
- 書記体系
- キリル文字フォント
- アラビア文字フォント
- 日本語フォント
- ジョージア文字フォント
- サーナ文字フォント
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python（Java経由）で Aspose.Slides を使用して、PowerPoint テーマ内のスクリプト固有フォントマッピングを検査、追加、置換、削除します。"
---
## **概要**

プレゼンテーションテーマは、異なる書記体系ごとに異なるフォントファミリを選択できます。これにより、テーマフォントを使用し続ける多言語テキストでも、キリル文字、アラビア文字、日本語、ジョージア文字、サーナ文字などのスクリプトに適したフォントを使用しつつ、統一されたフォントスキームを維持できます。

テーマの[FontScheme](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontscheme/)には、見出しに主に使用されるメジャーフォントコレクションと、本文に主に使用されるマイナーフォントコレクションが含まれます。ラテン文字と東アジア文字の設定に加えて、両コレクションは[Fonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fonts/)クラスを通じて、書記体系タグとフォントファミリ名のマッピングを公開します。

本稿では、プレゼンテーションのマスターテーマでそれらのマッピングを検査・変更し、保存‑再読み込みサイクルでも変更が保持されることを確認する方法を示します。

## **スクリプトタグの理解**

スクリプトフォントメソッドは、4 文字の BCP 47 スクリプトサブタグで書記体系を識別します。主な値は次のとおりです。

| スクリプトタグ | 文字体系 |
|---|---|
| `Cyrl` | キリル文字 |
| `Arab` | アラビア文字 |
| `Hans` | 簡体字中国語 |
| `Jpan` | 日本語 |
| `Geor` | ジョージア文字 |
| `Thaa` | サーナ文字 |

これらのマッピングはテーマフォントスキームに属し、個々のテキスト部分には属しません。プレゼンテーションはメジャーとマイナーの両コレクションで異なるマッピングを定義でき、いくつかのスクリプトに対するマッピングを省略することも可能です。

## **スクリプトフォントマッピングへのアクセスと検査**

[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getMasterTheme) を使用してプレゼンテーションレベルのテーマにアクセスします。[FontScheme.getMajor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontscheme/#getMajor) と [FontScheme.getMinor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontscheme/#getMinor) メソッドは、2 つの [Fonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fonts/) コレクションを返します。

[Fonts.getScriptFontMap](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fonts/#getScriptFontMap) を呼び出すと、コレクション内のすべてのマッピングを取得できます。特定の書記体系を調べるには、スクリプトタグを指定して [Fonts.getScriptFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fonts/#getScriptFont) を呼び出します。`getScriptFont` は、そのコレクションに要求されたマッピングが定義されていない場合に `None` を返します。

## **マッピングの変更と永続性の検証**

[Fonts.setScriptFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fonts/#setScriptFont) を使用してマッピングを作成または現在のフォントファミリを置き換えます。[Fonts.removeScriptFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fonts/#removeScriptFont) でマッピングを削除します。

以下のエンドツーエンド例は、既存のメジャーおよびマイナーのすべてのマッピングを読み取り、日本語のメジャーフォントを参照し、キリル文字のメジャーフォントを変更し、サーナ文字のマイナーマッピングを削除し、プレゼンテーションを保存して再度開き、両方の変更が保持されていることを確認します。削除ステップを初期テーマに依存させないため、サーナマッピングが未定義の場合にのみ作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

検証は通常の検索と同じ `None` 挙動を利用します。削除が保存された後、`getScriptFont("Thaa")` はマイナ―コレクションで `None` を返します。

## **テーママッピングと他のフォント設定の区別**

スクリプト固有のテーママッピングはフォント選択に関与しますが、直接のテキスト書式設定、置換、フォールバックとは別の問題を解決します。

| メカニズム | 目的 | テーママッピング変更の効果 |
|---|---|---|
| スクリプト固有のテーマフォントマッピング | 書記体系に対してメジャーまたはマイナーのテーマフォントを選択する | 対応するテーマフォントを使用しているテキストは新しいマッピングされたファミリに解決できる |
| テキスト部分に明示的に割り当てられたフォント | テーマに依存せず、その部分のフォントファミリを固定する | 直接書式設定がテーマ選択を上書きするため、変更が反映されないことがある |
| フォント置換 | 要求されたフォントが利用できないか置換ルールが適用されたときに別のフォントに置き換える | フォントが要求された後に作用し、テーマのスクリプトマッピングを再定義しない |
| フォントフォールバック | 選択したフォントに含まれない字形を補う（特定の Unicode 範囲向け） | 欠損した字形を補完するだけで、保存されたテーママッピングは変更しない |

最後の 2 つのメカニズムの詳細については、[Font Substitution](/slides/ja/python-java/font-substitution/) と [Fallback Fonts](/slides/ja/python-java/fallback-font/) を参照してください。

[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getMasterTheme) でマッピングを変更しても、実効書式がそのテーマに依存しているコンテンツにのみ影響します。テキストはマスタ、レイアウト、スライドからのテーマ上書きや明示的なフォント割り当てによって別のフォントを使用している場合があります。そのような場合は、可視結果がプレゼンテーションレベルのマッピングに従わない理由を調べるために、これらのレベルも検査してください。

## **マッピングされたフォントを利用可能にし結果を検証**

スクリプトマッピングはフォントファミリ名を保存するだけで、対応するフォントファイルをインストールまたは読み込むわけではありません。安定した描画とエクスポートのためには、マッピングされたすべてのフォントを環境にインストールするか、[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsloader/#loadExternalFonts) や [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) のようなカスタムソースで Aspose.Slides に供給する必要があります。利用可能な読み込みオプションについては、[Custom Fonts](/slides/ja/python-java/custom-font/) を参照してください。

保存されたマッピングの検証は、テーマ定義が保持されたことのみを確認します。フォントが利用可能か、すべての必須字形が含まれているか、意図したレイアウトが生成されるかは証明できません。各必須書記体系の代表的なテキストを画像または PDF にレンダリングし、出力を確認してください。これにより、欠落フォント、字形カバレッジ不足、フォールバック動作、レイアウト変更などを、プレゼンテーション配布前に検出できます。[Convert PowerPoint Presentations](/slides/ja/python-java/convert-powerpoint/) でレンダリングとエクスポートの例を参照してください。

## **FAQ**

**`getScriptFont` はスクリプトがマッピングされていない場合に何を返しますか？**

[Fonts.getScriptFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fonts/#getScriptFont) は、要求されたスクリプトマッピングがそのメジャーまたはマイナーのフォントコレクションに定義されていない場合に `None` を返します。

**`setScriptFont` は既にスクリプトが存在する場合に二重マッピングを追加しますか？**

いいえ。[Fonts.setScriptFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fonts/#setScriptFont) は、マッピングが欠如しているときに作成し、同じスクリプトタグが既に存在する場合はマッピングされたフォントファミリを置き換えます。

**テーママッピングを変更しても一部のテキストが変わらなかったのはなぜですか？**

そのテキストは明示的にフォントが割り当てられているか、別のテーマ上書きから継承している、またはレンダリング時に置換やフォールバックの影響を受けている可能性があります。プレゼンテーションレベルのスクリプトマッピングは、実効書式がそのテーマフォントコレクションに依存しているテキストにのみ作用します。

**保存して再度開くだけで多言語出力を検証できますか？**

できません。再開はテーマデータの永続性のみを確認します。各必須書記体系の代表テキストを実際にレンダリングして、マッピングされたフォントが利用可能で必要な字形を含んでいることを確認する必要があります。