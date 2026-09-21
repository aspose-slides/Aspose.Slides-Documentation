---
title: PythonでPDFドキュメントを編集
linktitle: PDFを編集
type: docs
weight: 65
url: /ja/python-net/edit-pdf/
keywords:
- PDFを編集
- PDFテキストの置換
- PDFからPPTXへ
- PPTXからPDFへ
- Python
- Aspose.Slides
description: "PythonでPDFドキュメントをAspose.Slidesにインポートし、テキストを置換して、変更したプレゼンテーションをPDFとして保存します。"
---
## **概要**

Aspose.Slides for Python via .NET を使用すると、PDF のページをスライドとしてインポートし、プレゼンテーションを変更して、PDF にエクスポートすることで、PDF コンテンツを編集できます。この記事では簡単なテキスト置換を示します。プレゼンテーションはメモリ上に保持されるため、中間の PPTX ファイルを保存する必要は任意です。

## **PDF のテキスト置換**

ページをインポートするには [add_from_pdf](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_from_pdf/)、テキストを更新するには [replace_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/replace_text/)、結果をエクスポートするには [save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) を使用します。

次の例では、インポート後に `input.pdf` に編集可能なテキストとして「Draft」という単語が含まれていることを想定しています。この単語を「Final」に置換し、`edited.pdf` として書き出します。インポート前に最初のスライドをクリアすると、出力に余分な空白ページができるのを防げます。検索は大文字小文字を区別した完全一致の単語にマッチします。`None` は結果コールバックが不要であることを意味します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

その他のオプションについては、[テキストの検索と置換](/slides/ja/python-net/search-and-replace-text/) と [PowerPoint を PDF に変換](/slides/ja/python-net/convert-powerpoint-to-pdf/) を参照してください。

{{% alert color="info" title="Note" %}}
テキスト置換はインポートされたテキストに対してのみ機能し、スキャンされた画像内のテキストには適用されません。変換によりレイアウトや書式が変わる可能性があるため、特に置換後のテキストが元のテキストより長い場合は、出力を確認してください。
{{% /alert %}}

## **FAQ**

**PDF にエクスポートする前に PPTX ファイルを保存する必要がありますか？**

いいえ。プレゼンテーションはメモリ上で編集およびエクスポートできます。PowerPoint で引き続き編集したい場合のみ PPTX のコピーを保存してください。詳しくは [プレゼンテーションの保存](/slides/ja/python-net/save-presentation/) を参照してください。

**なぜ一部のテキストが変更されないままになることがありますか？**

この例では、大文字小文字を完全に一致させた単語「Draft」にマッチします。画像としてインポートされたテキストや、別々のテキストフレームに分割されたテキストは検索に一致しない可能性があります。インポートされた内容を確認し、ドキュメントに合わせて検索条件を調整してください。