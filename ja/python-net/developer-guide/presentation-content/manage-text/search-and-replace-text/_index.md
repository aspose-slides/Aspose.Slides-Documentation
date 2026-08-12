---
title: PythonでPowerPointプレゼンテーションのテキストを検索および置換
linktitle: テキストの検索と置換
type: docs
weight: 55
url: /ja/python-net/search-and-replace-text/
keywords:
- 検索テキスト
- ハイライトテキスト
- 置換テキスト
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

Aspose.Slides for Python via .NET は、個々のテキスト フレームまたはプレゼンテーション全体でテキストの検索、ハイライト、置換を行うことができます。これらの機能は、レビュー、編集、用語チェック、テンプレートのクリーンアップ、その他の自動文書処理ワークフローに役立ちます。

以下の最初の例では、"sample.pptx" という名前のファイルを使用します。このファイルは、最初のスライドに次のテキストが含まれた単一のテキスト ボックスを持っています。

![サンプルテキスト](sample_text.png)

## **検索範囲の選択**

[TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) のメソッドを使用して操作を単一のテキスト フレームに限定します。[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) のメソッドを使用してプレゼンテーション内のすべての対象テキストを処理します。

| 操作 | 1つのテキスト フレーム | プレゼンテーション全体 |
|---|---|---|
| リテラルテキストをハイライト | [TextFrame.highlight_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/highlight_text/) |
| 正規表現の一致をハイライト | [TextFrame.highlight_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/highlight_regex/) |
| リテラルテキストを置換 | [TextFrame.replace_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/replace_text/) |
| 正規表現の一致を置換 | [TextFrame.replace_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/replace_regex/) |

## **テキストマッチングの構成**

リテラルテキスト操作では、[TextSearchOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/) を使用してマッチングを制御します：

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/whole_words_only/) は一致を完全な単語に限定します。
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/case_sensitive/) は文字の大文字小文字が一致する必要があるかどうかを制御します。
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/include_notes/) はスライドノートをプレゼンテーションレベルの検索、置換、ハイライト操作に含めます。

正規表現操作はパターン文字列を使用するため、ケースセンシティブや単語境界などのマッチングルールは式自体で定義されます。

## **テキストのハイライト**

[TextFrame.highlight_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/highlight_text/) メソッドを使用して、テキスト フレーム内のリテラルテキストの一致をハイライトします。検索を制御するために [TextSearchOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/) を渡します。

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

結果:
![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用したテキストのハイライト**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/highlight_regex/) メソッドは、テキスト フレーム内で正規表現で見つかったテキストの一致をハイライトします。

以下のコードは、7文字以上を含むすべての単語をハイライトします。

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

結果:
![正規表現を使用したハイライトテキスト](highlighted_text_using_regex.png)

## **プレゼンテーション全体のテキストハイライト**

[Presentation.highlight_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/highlight_text/) および [Presentation.highlight_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/highlight_regex/) を使用して、プレゼンテーション内のすべての対象テキスト フレームを検索します。以下の例は、リテラル用語とすべてのメールアドレスをハイライトします。

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

## **テキスト フレーム内のテキスト置換**

リテラルテキストには [TextFrame.replace_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_text/) を、パターンベースの置換には [TextFrame.replace_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_regex/) を使用します。これらのメソッドは、既存のテキスト フレーム内の一致したテキストを更新し、プレーン文字列からテキスト フレームを再構築するのではなく、周囲の書式を保持します。

以下の例は、スペルのバリエーションを標準化し、続いてバージョンラベルを置換します。

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

一致が異なる書式の部分にまたがる場合、置換テキストに適用すべき書式を確認するために出力を確認してください。

## **プレゼンテーション全体のテキスト置換**

[Presentation.replace_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/replace_text/) と [Presentation.replace_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/replace_regex/) を使用して、プレゼンテーション全体に同じ操作を適用します。これはテンプレートのクリーンアップ、用語の更新、編集に役立ちます。

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

## **よくある質問**

**プレゼンテーション全体ではなく、1つのテキスト ボックスだけを検索するにはどうすればよいですか？**

シェイプのテキスト フレームを取得し、そのテキスト フレームに対して [TextFrame.highlight_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_text/), または [TextFrame.replace_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_regex/) を呼び出します。プレゼンテーションレベルのメソッドは、代わりにすべての対象テキスト フレームを処理します。

**正しい大文字小文字で完全な単語をマッチさせるにはどうすればよいですか？**

[TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/whole_words_only/) と [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/case_sensitive/) を `True` に設定し、リテラルテキストのハイライトまたは置換メソッドにオプションを渡します。正規表現の場合は、パターン自体で単語境界とケースセンシティブを定義します。

**検索および置換にスライドノートのテキストを含めることはできますか？**

はい。プレゼンテーションレベルのリテラルテキスト操作を使用する際に、[TextSearchOptions.include_notes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textsearchoptions/include_notes/) を `True` に設定します。

**テキストを置換すると書式は保持されますか？**

[TextFrame.replace_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_text/) と [TextFrame.replace_regex](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/replace_regex/) は、既存のテキスト フレーム内の一致したテキストを変更し、周囲の書式を保持します。もし一致が異なる書式の部分にまたがる場合、置換が希望のスタイルを使用しているか結果を確認してください。