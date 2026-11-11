---
title: Python でノート付き PowerPoint プレゼンテーションを PDF に変換
linktitle: ノート付き PowerPoint を PDF に変換
type: docs
weight: 50
url: /ja/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PPT を変換
- PPTX を変換
- PowerPoint を PDF に変換
- プレゼンテーションを PDF に変換
- PPT を PDF に変換
- PPTX を PDF に変換
- プレゼンテーションを PDF として保存
- PPT を PDF にエクスポート
- PPTX を PDF にエクスポート
- スピーカーノート
- ノート付き PDF
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PPT および PPTX プレゼンテーションをスピーカーノート付きの PDF に変換します。ノートの配置を設定し、長いノートを保持できます。"
---
## **概要**

本記事では、Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーションをスライドノート付きの PDF に変換する方法を説明します。各スライドの下にノートを追加し、長いノートは追加ページに続けることができます。その他の PDF エクスポート設定については、[PowerPoint を PDF に変換](/slides/ja/python-java/convert-powerpoint-to-pdf/) を参照してください。

エクスポート前にノートページのサイズと向きを設定するには、[ノートページサイズ](/slides/ja/python-java/notes-size/) を参照してください。

## **ノート付きで PowerPoint を PDF に変換**

[Presentation] クラスの [save] メソッドを使用して、PPT または PPTX プレゼンテーションを PDF にエクスポートします。スピーカーノートを含めるには、[NotesCommentsLayoutingOptions] オブジェクトを作成し、その [setNotesPosition] メソッドでノートの配置を設定します。このレイアウトを [PdfOptions] に、[setSlidesLayoutOptions] を使用して割り当てます。

以下の例は `sample.pptx` を読み込み、スライドの下にスピーカーノートを付けて `output.pdf` にエクスポートします。

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

**長いスピーカーノートが切り取られるのを防ぐには？**

上記の例と同様に、[NotesPositions.BottomFull] を使用します。この設定により、必要に応じて追加ページを使用してノート全体が表示されます。

**各スライドとそのノートを1ページに収めることはできますか？**

[NotesPositions.BottomTruncated] を使用します。この設定ではノートが1ページに制限されるため、収まりきらないノートは切り詰められます。

**スピーカーノートなしでスライドをエクスポートするには？**

ノートレイアウトの設定を省略し、[PowerPoint を PDF に変換](/slides/ja/python-java/convert-powerpoint-to-pdf/) に記載されている標準的な PDF エクスポートを使用します。