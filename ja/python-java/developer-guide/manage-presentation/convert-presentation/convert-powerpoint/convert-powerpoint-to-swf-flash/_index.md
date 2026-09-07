---
title: Python via Java で PowerPoint プレゼンテーションを SWF Flash に変換
linktitle: PowerPoint から SWF へ
type: docs
weight: 80
url: /ja/python-java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint から SWF へ
- プレゼンテーションから SWF へ
- スライドから SWF へ
- PPT から SWF へ
- PPTX から SWF へ
- PowerPoint から Flash へ
- プレゼンテーションから Flash へ
- スライドから Flash へ
- PPT から Flash へ
- PPTX から Flash へ
- PPT を SWF として保存
- PPTX を SWF として保存
- PPT を SWF にエクスポート
- PPTX を SWF にエクスポート
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Python via Java で PowerPoint プレゼンテーションを SWF Flash に変換します。ビューア、ノート、非表示スライド、圧縮、フォントを構成できます。"
---
## **概要**

Aspose.Slides for Python via Java を使用すると、Microsoft PowerPoint を使用せずに PowerPoint プレゼンテーションを SWF に変換できます。[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) を使用してプレゼンテーションをエクスポートし、[SwfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/swfoptions/) でビューア設定、画像品質、ノートやコメントのレイアウトを構成します。

## **プレゼンテーションを Flash に変換**

[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) を使用してソースファイルを読み込み、[SwfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/swfoptions/) を構成し、[SaveFormat.Swf](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Swf) を使用して保存します。

次の例は `presentation.pptx` を `presentation.swf` にエクスポートします。埋め込みビューアは [setViewerIncluded](https://reference.aspose.com/slides/ja/python-java/aspose.slides/swfoptions/#setViewerIncluded) で無効化し、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/) を使用してスライド下部にスピーカーノートを含めます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

例を実行する前に、[Aspose.Slides for Python via Java のインストール](/slides/ja/python-java/installation/) を行い、作業ディレクトリに `presentation.pptx` を配置します。JVM は Python プロセスごとに一度起動されます。

例では、[NotesPositions.BottomFull](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notespositions/#BottomFull) を [setNotesPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) で適用し、レイアウトを [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions) に渡します。コメントも含めるには、エクスポート前に [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) を設定します。

## **よくある質問**

**SWF に非表示スライドを含めることはできますか？**

はい。`True` を渡して [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) を呼び出します。デフォルトでは、非表示スライドはエクスポートされません。

**圧縮と最終的な SWF サイズはどのように制御できますか？**

圧縮の有無は [SwfOptions.setCompressed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/swfoptions/#setCompressed) で制御し、JPEG 画像品質は [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/ja/python-java/aspose.slides/swfoptions/#setJpegQuality) で調整します。JPEG 品質を下げると画像の忠実度は低下しますが、ファイルサイズを削減できます。

**埋め込みビューアの用途は何ですか、またいつ無効にすべきですか？**

生成された SWF にビューアを含めるかは [SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/ja/python-java/aspose.slides/swfoptions/#setViewerIncluded) で制御します。例のように埋め込みビューアなしでスライドだけが必要な場合は `False` を渡します。

**エクスポート先マシンに元フォントが存在しない場合はどうなりますか？**

デフォルトの標準フォントは [setDefaultRegularFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) で指定でき、[SwfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/swfoptions/) が継承します。エクスポートプロセスで利用可能なフォントを選択してください。フォント置換によりテキストの外観やレイアウトが変わる可能性があります。