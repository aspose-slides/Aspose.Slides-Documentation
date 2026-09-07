---
title: PowerPoint プレゼンテーションをノート付き PDF に変換（Python）
linktitle: ノート付き PowerPoint から PDF へ
type: docs
weight: 50
url: /ja/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PPT を変換
- PPTX を変換
- PowerPoint から PDF へ
- プレゼンテーションから PDF へ
- PPT から PDF へ
- PPTX から PDF へ
- プレゼンテーションを PDF として保存
- PPT を PDF にエクスポート
- PPTX を PDF にエクスポート
- スピーカーノート
- ノート付き PDF
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PPT および PPTX プレゼンテーションをスピーカーノート付き PDF に変換します。ノートの配置を設定し、長いノートを保持できます。"
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーションをスライド ノート付き PDF に変換する方法を説明します。各スライドの下にノートを含め、長いノートは追加ページに続けることができます。他の PDF エクスポート設定については、[Convert PowerPoint to PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/) を参照してください。

## **ノート付きで PowerPoint を PDF に変換**

[save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドと [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスを使用して、PPT または PPTX プレゼンテーションを PDF にエクスポートします。スピーカーノートを含めるには、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/) オブジェクトを作成し、その [setNotesPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) メソッドを設定します。このレイアウトを [PdfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/) に、[setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) を使用して割り当てます。

次の例は `sample.pptx` を読み込み、スライドの下にスピーカーノートを付けて `output.pdf` にエクスポートします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # スピーカーノートのレンダリング用に PDF オプションを設定します。
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # スピーカーノート付きでプレゼンテーションを PDF に保存します。
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[オンライン PowerPoint to PDF コンバータ](https://products.aspose.app/slides/ja/conversion) もお試しください。
{{% /alert %}}

## **よくある質問**

**長いスピーカーノートが切り捨てられるのを防ぐにはどうすればよいですか？**

上記の例のように [NotesPositions.BottomFull](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notespositions/#BottomFull) を使用します。この設定により、必要に応じて追加ページを使用してノート全体が表示されます。

**各スライドとそのノートを1ページにまとめることはできますか？**

[NotesPositions.BottomTruncated](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notespositions/#BottomTruncated) を使用します。この設定ではノートは1ページに制限され、収まりきらないノートは切り捨てられます。

**スピーカーノートなしでスライドをエクスポートするにはどうすればよいですか？**

ノートレイアウトの設定を省略し、[Convert PowerPoint to PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/) に記載された標準の PDF エクスポートを使用します。