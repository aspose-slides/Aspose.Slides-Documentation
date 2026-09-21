---
title: Python via Java で PDF ドキュメントを編集
linktitle: PDF を編集
type: docs
weight: 65
url: /ja/python-java/edit-pdf/
keywords:
- PDF を編集
- PDF テキストを置換
- PDF から PPTX へ
- PPTX から PDF へ
- Python
- Java
- Aspose.Slides
description: "Python via Java で PDF ドキュメントを Aspose.Slides にインポートし、テキストを置換して、変更したプレゼンテーションを PDF として保存します。"
---
## **概要**

Aspose.Slides for Python via Java を使用すると、PDF のページをスライドとしてインポートし、プレゼンテーションを変更して、再び PDF としてエクスポートすることで、PDF コンテンツを編集できます。この記事では、簡単なテキスト置換を示します。プレゼンテーションはメモリ上に保持されるため、中間の PPTX ファイルを保存する必要はありません（任意です）。

## **PDF のテキストを置換する**

[addFromPdf](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addFromPdf) を使用してページをインポートし、[replaceText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#replaceText) を使用してテキストを更新し、[save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) を使用して結果をエクスポートします。

以下の例では、インポート後に `input.pdf` に編集可能なテキストとして「Draft」という単語が含まれていることを想定しています。この単語を「Final」に置換し、`edited.pdf` として書き出します。インポート前に最初のスライドをクリアすることで、出力に余分な空白ページが入るのを防ぎます。検索は同じ大文字小文字で完全一致する単語を対象とします。`None` は結果コールバックが不要であることを意味します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

詳しいオプションについては、[Search and Replace Text](/slides/ja/python-java/search-and-replace-text/) と [Convert PowerPoint to PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/) をご覧ください。

{{% alert color="info" title="Note" %}}
テキストの置換はインポートされたテキストに対してのみ機能し、スキャンされた画像内のテキストには適用されません。変換によりレイアウトや書式が影響を受ける可能性があるため、特に置換後のテキストが元のテキストより長い場合は、出力結果を確認してください。
{{% /alert %}}

## **よくある質問**

**PDF をエクスポートする前に PPTX ファイルを保存する必要がありますか？**

いいえ。メモリ上の同じプレゼンテーションを編集してエクスポートできます。PowerPoint で引き続き編集したい場合のみ、PPTX のコピーを保存してください。詳細は [Save Presentations](/slides/ja/python-java/save-presentation/) を参照してください。

**なぜ一部のテキストが変更されないままになることがありますか？**

この例では、正確な大文字小文字で完全一致する単語「Draft」のみを対象としています。画像としてインポートされたテキストや、別々のテキストフレームに分割されたテキストは検索に一致しない可能性があります。インポートされたコンテンツを確認し、ドキュメントに合わせて検索条件を調整してください。