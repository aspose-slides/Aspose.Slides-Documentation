---
title: Python でノート付き PowerPoint プレゼンテーションを PDF に変換
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
  - プレゼンテーションを PDF に変換
  - PPT を PDF に変換
  - PPTX を PDF に変換
  - プレゼンテーションを PDF として保存
  - PPT を PDF にエクスポート
  - PPTX を PDF にエクスポート
  - スライドノート
  - ノート付き PDF
  - Python
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PPT および PPTX プレゼンテーションをスライドノート付きで PDF に変換します。ノートの配置を設定し、長いノートを保持します。"
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーションをスライドノート付きの PDF に変換する方法を説明します。各スライドの下にノートを配置でき、長いノートは追加ページに続けて表示できます。他の PDF エクスポート設定については、[Convert PowerPoint to PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/) を参照してください。

## **スライドノート付きで PowerPoint を PDF に変換**

[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスの[save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save)メソッドを使用して、PPT または PPTX プレゼンテーションを PDF にエクスポートします。スライドノートを含めるには、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/) オブジェクトを作成し、その[setNotesPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)メソッドでノートの配置を設定します。このレイアウトを[PdfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/) に[setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions)で割り当てます。

以下の例は `sample.pptx` を読み込み、スライドの下にノートを付けて `output.pdf` にエクスポートします:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # スピーカー ノートを描画するための PDF オプションを設定します。
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # スピーカーノート付きでプレゼンテーションを PDF に保存します。
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="注意" %}}

[Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ja/conversion) もお試しください。

{{% /alert %}}

## **FAQ**

**長いスライドノートが切り捨てられないようにするにはどうすればよいですか？**

上記の例と同様に [NotesPositions.BottomFull](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notespositions/#BottomFull) を使用します。この設定により、必要に応じて追加ページを使用してノート全体が表示されます。

**各スライドとそのノートを 1 ページに収めることはできますか？**

[NotesPositions.BottomTruncated](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notespositions/#BottomTruncated) を使用します。この設定はノートを 1 ページに制限し、収まらない部分は切り捨てられます。

**スライドノートなしでスライドをエクスポートするにはどうすればよいですか？**

ノートレイアウトの設定を省略し、[Convert PowerPoint to PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/) に記載されている標準の PDF エクスポートを使用します。