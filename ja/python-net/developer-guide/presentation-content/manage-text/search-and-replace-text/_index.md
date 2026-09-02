---
title: Python で PowerPoint プレゼンテーション内のテキストを検索・置換
linktitle: テキストの検索と置換
type: docs
weight: 55
url: /ja/python-net/search-and-replace-text/
keywords:
- テキスト検索
- テキストハイライト
- テキスト置換
- 正規表現
- テキストフレーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint プレゼンテーション内のテキストを検索、ハイライト、置換します。"
---
## **概要**

Aspose.Slides for Python via .NET は、個々のテキストフレームまたはプレゼンテーション全体でテキストの検索、ハイライト、置換を行うことができます。これらの機能は、レビュー、編集、用語チェック、テンプレートの整理、その他の自動化された文書処理ワークフローに役立ちます。

以下の最初の例では、"sample.pptx" という名前のファイルを使用します。このファイルは、最初のスライドに次のテキストを含む単一のテキストボックスがあります。

![サンプルテキスト](sample_text.png)

## **検索スコープの選択**

操作を単一のテキストフレームに限定するには、[TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) のメソッドを使用します。プレゼンテーション内のすべての対象テキストを処理するには、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) のメソッドを使用します。

| 操作 | 単一テキストフレーム | プレゼンテーション全体 |
|---|---|---|
| リテラルテキストをハイライト | [TextFrame.highlight_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/highlight_text/) |
| 正規表現マッチをハイライト | [TextFrame.highlight_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/highlight_regex/) |
| リテラルテキストを置換 | [TextFrame.replace_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/replace_text/) |
| 正規表現マッチを置換 | [TextFrame.replace_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/replace_regex/) |

## **テキストマッチングの構成**

リテラルテキスト操作では、[TextSearchOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/) を使用してマッチングを制御します：

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/whole_words_only/) は完全な単語のみを対象にマッチを制限します。
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/case_sensitive/) は文字の大小が一致するかどうかを制御します。
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/include_notes/) はプレゼンテーションレベルの検索、置換、ハイライト操作にスライドノートを含めます。

正規表現操作はパターン文字列を使用するため、大小文字の区別や単語境界などのマッチングルールは式で定義されます。

## **テキストフレームの所有者を特定する**

一般的なテキスト処理ワークフローでは、検索、置換、検証、またはテキストのエクスポート中に [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) を取得することがあります。[TextFrame.parent_shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/parent_shape/) と [TextFrame.parent_cell](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/parent_cell/) を使用して、どのプレゼンテーションオブジェクトがテキストフレームを所有しているかを判断します。

所有者に応じて期待される値は異なります：

| テキストフレームの所有者 | `parent_shape` | `parent_cell` |
|---|---|---|
| AutoShape または他のテキストを含むシェイプ | 所有する [Shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/) | `None` |
| テーブルのセル | `None` | 所有する [Cell](https://reference.aspose.com/slides/ja/python-net/aspose.slides/cell/) |

両方のプロパティは読み取り専用のナビゲーションプロパティです。これらを読み取ってもテキストフレームは移動せず、所有者も変更されません。汎用コードでは両方の値が `None` であるかを確認し、所有者がいない可能性に対処すべきです。

以下の例では、[SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/ja/python-net/aspose.slides.util/slideutil/get_all_text_frames/) を使用してプレゼンテーション内のテキストフレームを列挙します。シェイプの場合、シェイプ名、Python ランタイム型、所属スライドを報告します。テーブルセルの場合、0 基準の列と行の座標、および所属スライドを報告します。

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

SmartArt コンテンツの場合、[SmartArtNode.shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/smartartnode/shapes/) のシェイプを列挙し、各 [ISmartArtShape.text_frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/ismartartshape/text_frame/) にアクセスします。テキストフレームは [TextFrame.parent_shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/parent_shape/) を介して関連付けられたシェイプに追跡でき、[TextFrame.parent_cell](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/parent_cell/) は `None` です。したがって、例のシェイプ分岐は SmartArt ノードからのテキストも処理します。

## **テキストをハイライトする**

[TextFrame.highlight_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/highlight_text/) メソッドを使用して、テキストフレーム内のリテラルテキストの一致をハイライトします。[TextSearchOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/) を渡して検索を制御します。

以下のコード例は、文字列 **"try"** のすべての出現箇所をハイライトし、続いて完全な単語 **"to"** のみをハイライトします。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # テキストフレーム内の "try" のすべての出現箇所をハイライトします。
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # 完全な単語 "to" のみをハイライトします。
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用してテキストをハイライトする**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/highlight_regex/) メソッドは、テキストフレーム内で正規表現によって見つかったテキストの一致をハイライトします。

以下のコードは、7 文字以上を含むすべての単語をハイライトします：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

結果：

![正規表現を使用したハイライトテキスト](highlighted_text_using_regex.png)

## **プレゼンテーション全体でテキストをハイライトする**

[Presentation.highlight_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/highlight_text/) と [Presentation.highlight_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/highlight_regex/) を使用して、プレゼンテーション内のすべての対象テキストフレームを検索します。以下の例は、リテラル用語とすべてのメールアドレスをハイライトします：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **テキストフレーム内のテキストを置換する**

リテラルテキストには [TextFrame.replace_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_text/) を、パターンベースの置換には [TextFrame.replace_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_regex/) を使用します。これらのメソッドは既存のテキストフレーム内の一致したテキストを更新し、プレーン文字列からテキストフレームを再構築するのではなく、周囲の書式設定を保持します。

以下の例は、綴りのバリエーションを標準化し、続いてバージョンラベルを置換します：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

一致が異なる書式の部分にまたがる場合、出力を確認して置換テキストに適用すべき書式を確認してください。

## **プレゼンテーション全体でテキストを置換する**

[Presentation.replace_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/replace_text/) と [Presentation.replace_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/replace_regex/) を使用して、プレゼンテーション全体に同じ操作を適用します。これはテンプレートの整理、用語の更新、編集に役立ちます。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **FAQ**

**プレゼンテーション全体ではなく、単一のテキストボックスだけを検索するにはどうすればよいですか？**

シェイプのテキストフレームを取得し、そのテキストフレーム上で [TextFrame.highlight_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/highlight_text/)、[TextFrame.highlight_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/highlight_regex/)、[TextFrame.replace_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_text/)、または [TextFrame.replace_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_regex/) を呼び出します。プレゼンテーションレベルのメソッドは、代わりにすべての対象テキストフレームを処理します。

**正しい大文字小文字で完全な単語に一致させるにはどうすればよいですか？**

[TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/whole_words_only/) と [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/case_sensitive/) を `True` に設定し、そのオプションをリテラルテキストのハイライトまたは置換メソッドに渡します。正規表現の場合は、パターン自体で単語境界と大文字小文字の区別を定義します。

**検索および置換でスライドノートのテキストも含めることはできますか？**

はい。プレゼンテーションレベルのリテラルテキスト操作を使用する際に、[TextSearchOptions.include_notes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/include_notes/) を `True` に設定します。

**テキストの置換は書式を保持しますか？**

[TextFrame.replace_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_text/) と [TextFrame.replace_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_regex/) は既存のテキストフレーム内の一致したテキストを変更し、周囲の部分の書式設定を保持します。一致が異なる書式の部分にまたがる場合、置換が希望のスタイルになるよう結果を確認してください。