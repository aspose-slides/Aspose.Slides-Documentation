---
title: Python を使用した Java 経由でのプレゼンテーション ローカリゼーションの自動化
linktitle: プレゼンテーション ローカリゼーション
type: docs
weight: 100
url: /ja/python-java/presentation-localization/
keywords:
- 言語の変更
- スペルチェック
- スペルチェックの抑制
- 校正言語
- 言語 ID
- 多言語テキスト
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用し、Python 経由で Java で PowerPoint および OpenDocument プレゼンテーション テキストの校正言語を設定し、デフォルトや多言語段落を含めます。"
---
## **概要**

Aspose.Slides for Python via Java は、個々のテキスト部分に対して校正メタデータを構成できます。校正言語を指定するには[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setLanguageId)を、スペルチェックの有無を設定するには[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setSpellCheck)を、より広範な校正しない状態を制御するには[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setProofDisabled)を使用します。これらの設定は部分レベルで適用されるため、1 つの段落に複数の言語や異なる校正ルールを含めることができます。

この記事では、特定のテキストに言語を割り当てる方法、[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) を使用して新規テキストのデフォルト言語を設定する方法、多言語段落の作成方法、[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setSpellCheck) と [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setProofDisabled) の選択、そして [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) 使用時に意図した設定を保持する方法を説明します。これらのプロパティはプレゼンテーション アプリケーション向けのメタデータを格納しますが、テキストの翻訳や辞書ベースのスペルチェック、誤字の返却は行いません。

## **テキストの校正言語を設定する**

[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) を作成またはロードし、[Portion.getPortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#getPortionFormat) で対象のテキスト部分にアクセスして言語識別子を割り当てます。以下の例はシェイプを作成し、英国英語を校正言語として設定し、[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) で結果を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **新規テキストのデフォルト言語を設定する**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) を使用して、Aspose.Slides が新規に作成するテキストに割り当てる校正言語を指定できます。この設定は、プレゼンテーション内のほとんどまたはすべての新規テキストが同一言語を使用する場合に便利です。既に明示的な言語が設定されているテキストのメタデータは変更されません。

以下の例は、新規テキストにドイツ語の校正ルールを使用するプレゼンテーションを作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **1 段落で複数言語を使用する**

[Paragraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/) はテキスト部分のコレクションを保持します。言語ごとに別々の [Portion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/) を作成し、各 Portion の [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setLanguageId) を個別に設定します。

この例は英語とフランス語の部分を持つ 1 つの段落を作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **個別の部分でスペルチェックを有効または無効にする**

[PortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/) は [BasePortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/) で定義された共通テキストプロパティを継承します。[Portion.getPortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#getPortionFormat) で部分の書式にアクセスし、[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setSpellCheck) を使用してプレゼンテーション アプリケーションがその部分のスペルチェックを行うかどうかを制御します。デフォルト値は `False` で、`True` にするとスペルチェックが有効になり、`False` にすると抑制されます。

この設定は個々のテキスト部分に適用されます。同一段落内の異なる部分はそれぞれ異なる値を持つことができます。[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setLanguageId) と [setSpellCheck](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setSpellCheck) は補完的な役割を果たします：`setLanguageId` は校正言語を識別し、`setSpellCheck` はその部分でスペルチェックを許可するかどうかを決定します。

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setProofDisabled) も校正を制御しますが、これは [NullableBool](https://reference.aspose.com/slides/ja/python-java/aspose.slides/nullablebool/) として「校正しない」状態全体を表します。スペルチェックだけのオン/オフを直接制御したい場合は `setSpellCheck` を使用し、プレゼンテーション の「校正しない」メタデータ（[NullableBool.NotDefined](https://reference.aspose.com/slides/ja/python-java/aspose.slides/nullablebool/#NotDefined) 状態を含む）を明示的に保持または制御したい場合は `setProofDisabled` を使用してください。両方のプロパティを設定する場合は、値を一貫させてください。`setSpellCheck` を `True` にし、`setProofDisabled` を [NullableBool.True](https://reference.aspose.com/slides/ja/python-java/aspose.slides/nullablebool/#True) に設定する組み合わせは避けてください。

これらのプロパティは PowerPoint や他のプレゼンテーション アプリケーションが使用する校正メタデータを構成しますが、Aspose.Slides はそれらを用いて辞書ベースのスペルチェックを実行したり、誤字リストを返したりはしません。

以下の完全な例は、入力プレゼンテーションを作成し、ロードして、同一段落内の 2 つの部分に異なるスペルチェック設定と校正言語を割り当て、結果を保存し、再度開いて保存された値を検証します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) は、同一書式を持つ隣接する部分を結合します。[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setSpellCheck) のみが異なる場合でも、結合後の部分は最初の部分の `setSpellCheck` 値を保持します。部分ごとに異なるスペルチェック設定が必要な場合は、設定を割り当てる前に `joinPortionsWithSameFormatting` を呼び出すか、結合後の部分境界を確認して設定を再適用してください。`setLanguageId` の値が異なる部分は、校正言語の書式が異なるため、結合されずに別々に残ります。

## **FAQ**

**言語 ID はテキストを翻訳しますか？**

いいえ。[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setLanguageId) はスペルチェックや文法チェック用の校正メタデータを格納するだけで、テキストコンテンツ自体は変更しません。テキストは別途翻訳し、翻訳後の各部分に適切な言語識別子を設定してください。

**校正言語はフォント、ハイフネーション、改行を制御しますか？**

いいえ。言語識別子は校正用です。テキストの描画やレイアウトは、利用可能な[フォント](/slides/ja/python-java/powerpoint-fonts/)、文字体系、テキスト フレーム設定に主に依存します。確実な描画のためには、必要なフォントを提供するか、[フォント置換](/slides/ja/python-java/font-substitution/) を構成するか、プレゼンテーションに[フォントを埋め込む](/slides/ja/python-java/embedded-font/) 必要があります。

**1 段落で複数の校正言語を使用できますか？**

はい。多言語段落の例に示すように、各言語を別々の部分に割り当てます。

**[setDefaultTextLanguage] と [setLanguageId] のどちらを使うべきですか？**

新規に作成するテキストに対してデフォルトを設定したい場合は[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) を使用します。特定の部分に明示的な校正言語を設定したい、または段落内に複数言語が混在する場合は[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setLanguageId) を使用してください。