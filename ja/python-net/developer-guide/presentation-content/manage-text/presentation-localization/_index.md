---
title: Pythonでプレゼンテーションのローカリゼーションを自動化
linktitle: プレゼンテーション ローカリゼーション
type: docs
weight: 100
url: /ja/python-net/presentation-localization/
keywords:
- 言語を変更
- スペルチェック
- スペルチェックの抑制
- 校正言語
- 言語 ID
- 多言語テキスト
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python と Aspose.Slides を使用して PowerPoint および OpenDocument のプレゼンテーション テキストの校正言語を設定し、デフォルトや多言語段落も扱います。"
---
## **概要**

Aspose.Slides for Python via .NET は、個々のテキスト部分の校正メタデータを構成できるようにします。[BasePortionFormat.language_id] を使用して校正言語を識別し、[BasePortionFormat.spell_check] でスペルチェックの有無を制御し、[BasePortionFormat.proof_disabled] でより広範な「校正しない」状態を制御します。これらの設定は部分レベルで適用されるため、1つの段落に複数の言語や異なる校正ルールを含めることができます。

本記事では、特定のテキストに言語を割り当てる方法、[LoadOptions.default_text_language] を使用して新規テキストのデフォルト言語を設定する方法、多言語段落の作成、`spell_check` と `proof_disabled` の選択、および [Presentation.join_portions_with_same_formatting] を使用する際に意図した設定を保持する方法について説明します。これらのプロパティはプレゼンテーション アプリケーション用のメタデータを格納しますが、テキストの翻訳や辞書ベースのスペルチェック、誤字リストの取得は行いません。

## **テキストの校正言語を設定する**

[Presentation] を作成または読み込み、[Portion.portion_format] を介して対象のテキスト部分にアクセスし、その言語識別子を割り当てます。以下の例は、シェイプを作成し、校正言語としてイギリス英語を設定し、[Presentation.save] で結果を保存します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **新規テキストのデフォルト言語を設定する**

[LoadOptions.default_text_language] を使用して、Aspose.Slides が新規作成テキストに割り当てる校正言語を指定します。この設定は、プレゼンテーション内の新規テキストのほとんどまたはすべてが同じ言語を使用する場合に便利です。既に明示的な言語が設定されているテキストの言語メタデータは変更されません。

以下の例は、新規テキストがドイツ語の校正ルールを使用するプレゼンテーションを作成します。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **1つの段落で複数の言語を使用する**

[Paragraph] はテキスト部分のコレクションを保持します。各言語に対して別々の [Portion] を作成し、`language_id` を個別に設定します。

この例は、英語とフランス語の部分を持つ段落を作成します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **個別の部分に対してスペルチェックを有効または抑制する**

[PortionFormat] は、[BasePortionFormat] で定義された共通テキストプロパティを継承します。[Portion.portion_format] を介して部分の書式にアクセスし、[BasePortionFormat.spell_check] を設定して、プレゼンテーション アプリケーションがその部分のスペルチェックを行うかどうかを制御します。既定値は `False` で、`True` にするとスペルチェックが有効になり、`False` にすると抑制されます。

この設定は個々のテキスト部分に適用されます。同じ段落内の異なる部分はそれぞれ異なる値を使用できます。[BasePortionFormat.language_id] と `spell_check` は補完的な役割を果たします：`language_id` は校正言語を識別し、`spell_check` はその部分でスペルチェックを許可するかどうかを決定します。

[BasePortionFormat.proof_disabled] も校正を制御しますが、より広範な「校正しない」状態を [NullableBool] で表します。スペルチェック専用の直接的な Boolean スイッチが必要な場合は `spell_check` を使用してください。プレゼンテーションの「校正しない」メタデータ（`NOT_DEFINED` 状態を含む）を保持または明示的に制御したい場合は `proof_disabled` を使用します。両方のプロパティを設定する場合は、値を一貫させてください。`spell_check = True` と `proof_disabled = slides.NullableBool.TRUE` を組み合わせてはいけません。

これらのプロパティは、PowerPoint やその他のプレゼンテーション アプリケーションで使用される校正メタデータを構成します。Aspose.Slides はこれらを使用して辞書ベースのスペルチェックを実行したり、誤字のリストを返したりしません。

以下の完全な例は、入力プレゼンテーションを作成し、読み込み、同じ段落の 2 つの部分に異なるスペルチェック設定と校正言語を割り当て、結果を保存し、再度開いて保存された値を検証します。

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting] は、同じ書式を持つ隣接する部分を結合します。`spell_check` の違いだけでは部分が分離されたままにはなりません。結合後の部分は、最初の部分の `spell_check` 値を保持します。部分が異なるスペルチェック設定を必要とする場合は、設定を割り当てる前に `join_portions_with_same_formatting` を呼び出すか、結合後の部分境界を確認して設定を再適用してください。`language_id` が異なる部分は、校正言語の書式が異なるため、別々のまま残ります。

## **よくある質問**

**言語 ID はテキストを翻訳しますか？**

いいえ。[BasePortionFormat.language_id] はスペルおよび文法の校正メタデータを格納するだけで、テキスト内容は変更しません。テキストは別途翻訳し、翻訳された各部分に適切な言語識別子を設定してください。

**校正言語はフォント、ハイフネーション、改行を制御しますか？**

いいえ。言語識別子は校正用です。テキストの表示やレイアウトは主に利用可能な [fonts](/slides/ja/python-net/powerpoint-fonts/) や記述体系、テキスト フレームの設定に依存します。確実な表示のために、必要なフォントを用意し、[font substitution](/slides/ja/python-net/font-substitution/) を構成するか、プレゼンテーションに [embed fonts](/slides/ja/python-net/embedded-font/) を埋め込んでください。

**1つの段落で複数の校正言語を使用できますか？**

はい。多言語段落の例に示すように、各言語を別々の部分に割り当てます。

**`default_text_language` と `language_id` のどちらを使用すべきですか？**

新規作成テキストのデフォルトを設定したい場合は [LoadOptions.default_text_language] を使用してください。特定の部分に明示的な校正言語が必要な場合や、段落に複数の言語が含まれる場合は [BasePortionFormat.language_id] を使用します。