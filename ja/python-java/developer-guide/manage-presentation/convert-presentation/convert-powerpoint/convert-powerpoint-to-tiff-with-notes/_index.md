---
title: PowerPoint プレゼンテーションをノート付きで TIFF に変換 (Python)
linktitle: PowerPoint をノート付き TIFF に変換
type: docs
weight: 100
url: /ja/python-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を TIFF に変換
- プレゼンテーションを TIFF に変換
- スライドを TIFF に変換
- PPT を TIFF に変換
- PPTX を TIFF に変換
- PPT を TIFF として保存
- PPTX を TIFF として保存
- PPT を TIFF にエクスポート
- PPTX を TIFF にエクスポート
- ノート付き PowerPoint
- ノート付きプレゼンテーション
- ノート付きスライド
- ノート付き PPT
- ノート付き PPTX
- ノート付き TIFF
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、ノート付きの PowerPoint プレゼンテーションを TIFF に変換します。スピーカーノート付きスライドを効率的にエクスポートする方法をご紹介します。"
---
## **はじめに**

Aspose.Slides for Python via Java は、ノート付きの PowerPoint および OpenDocument プレゼンテーション（PPT、PPTX、ODP）を TIFF 形式に変換するシンプルなソリューションを提供します。この形式は高品質な画像保存、印刷、文書アーカイブに広く利用されています。[save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドと [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスを使用して、スライドとスピーカーノートを単一のマルチページ TIFF ファイルとしてエクスポートします。

## **ノート付きでプレゼンテーションを TIFF に変換する**

Aspose.Slides for Python via Java を使用して、ノート付きの PowerPoint または OpenDocument プレゼンテーションを TIFF に保存するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスをインスタンス化し、PowerPoint または OpenDocument ファイルを読み込みます。
2. 出力レイアウトオプションを構成します。[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/) クラスを使用して、ノートとコメントの表示方法を指定します。
3. プレゼンテーションを TIFF に保存します。構成したオプションを [save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドに渡します。

たとえば、"speaker_notes.pptx" というファイルに次のスライドがあるとします。

![ノート付きのプレゼンテーションスライド](slide_with_notes.png)

以下のコードスニペットは、[setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) メソッドを使用して、ノートスライドビューでプレゼンテーションを TIFF 画像に変換する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # 各スライドの下に完全なスピーカーノートを表示します。
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # TIFF の解像度とノートのレイアウトを構成します。
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # スピーカーノート付きでプレゼンテーションを TIFF に保存します。
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

結果:

![ノート付きの TIFF 画像](TIFF_with_notes.png)

{{% alert title="ヒント" color="success" %}}
Aspose の [無料 PowerPoint からポスターへのコンバータ](https://products.aspose.app/slides/ja/conversion/convert-ppt-to-poster-online) をチェックしてください。
{{% /alert %}}

## **FAQ**

**結果として得られる TIFF のノート領域の位置を制御できますか？**

はい。ノートを 1 ページに収めて必要に応じて切り詰める場合は [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notespositions/#BottomTruncated) を使用し、必要に応じて追加ページを使用してすべてのノートを表示する場合は [NotesPositions.BottomFull](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notespositions/#BottomFull) を使用して [setNotesPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) を構成します。ノートなしでスライドをエクスポートするには、[Convert PowerPoint to TIFF](/slides/ja/python-java/convert-powerpoint-to-tiff/) に示されているようにノートレイアウト構成を省略してください。

**画像品質を損なわずにノート付き TIFF ファイルのサイズを削減するにはどうすればよいですか？**

[setCompressionType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffoptions/#setCompressionType) を使用して、[LZW compression](https://reference.aspose.com/slides/ja/python-java/aspose.slides/tiffcompressiontypes/#LZW) のロスレス圧縮を適用します。解像度や色深度を下げることでもさらにサイズを減らすことができますが、画像品質やノートの可読性に影響する可能性があります。詳細は [TIFF export settings](/slides/ja/python-java/convert-powerpoint-to-tiff/) を参照してください。

**元のフォントがシステムに無い場合、ノートのフォントは結果に影響しますか？**

はい。フォントが見つからないと [font substitution](/slides/ja/python-java/font-selection-sequence/) が発生し、テキストのメトリクスや外観が変わる可能性があります。[Supply the required fonts](/slides/ja/python-java/custom-font/) で必要なフォントを提供すれば、意図した書体を保持できます。