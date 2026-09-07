---
title: Python（Java経由）でPowerPointプレゼンテーションをWord文書に変換
linktitle: PowerPoint から Word へ
type: docs
weight: 110
url: /ja/python-java/convert-powerpoint-to-word/
keywords:
- PowerPoint を変換
- プレゼンテーション を変換
- PowerPoint から Word へ
- プレゼンテーション から Word へ
- PPT を Word へ
- PPTX を Word へ
- ODP を Word へ
- PowerPoint を DOCX へ
- PPT を DOCX へ
- PPTX を DOCX へ
- PowerPoint を DOC へ
- PPT を DOCX として保存
- PPTX を DOCX として保存
- PPT を DOCX にエクスポート
- PPTX を DOCX にエクスポート
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides と Aspose.Words を使用し、Python（Java 経由）で PowerPoint および OpenDocument のプレゼンテーションを Word に変換し、スライド画像と編集可能なテキストを組み合わせます。"
---
## **概要**

本記事では、Aspose.Slides for Python via Java と Aspose.Words for Java を組み合わせて、PowerPoint および OpenDocument のプレゼンテーションを Word 文書に変換する方法を説明します。Aspose.Slides が各スライドをレンダリングしテキストを取得し、Aspose.Words が JPype を介して Word 文書を作成します。Microsoft Office は不要です。

生成される文書は、スライド画像の後にそのスライドのトップレベル自動シェイプから抽出された編集可能なテキストが続きます。画像はスライドの視覚的外観を保持しますが、個々のシェイプ、チャート、テーブルは編集可能な Word オブジェクトに変換されません。抽出されたテキストは元の書式や位置情報を保持しません。

## **PowerPointをWordに変換**

1. [Aspose.Slides for Python via Java](/slides/ja/python-java/installation/) と互換性のある Java ランタイムをインストールします。
2. [Aspose.Words for Java](https://releases.aspose.com/words/java/) をダウンロードします。メインの JAR ファイルをスクリプトと同じディレクトリの `lib` フォルダーに配置し、`aspose-words.jar` にリネームするか、サンプルのパスをダウンロードしたファイルに合わせて調整します。
3. 入力プレゼンテーション `sample.pptx` を作業ディレクトリに配置します。`lib/aspose-words.jar` のパスも同ディレクトリを基準とします。
4. 以下の Python コードを実行して `output.docx` を作成します。

サンプルは [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) でソースを読み込み、[Slide.getImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) でスライドをレンダリングします。Aspose.Words の [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) を使用して画像とテキストを Word 文書に挿入します。

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # スライド画像をテキスト領域の幅に合わせ、アスペクト比を保持します。
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # トップレベルの自動シェイプ（テキストボックスを含む）からプレーンテキストを追加します。
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

各スライドは新しいページで開始されます。抽出されたテキストが長い場合やスライド画像が異常に高い場合は、追加のページが必要になることがあります。コードはスライド間にのみ改ページを挿入し、`finally` ブロックでプレゼンテーションとレンダリング画像を解放します。JVM は同じ Python プロセス内での後続変換に利用可能なままです。

## **FAQ**

**必要なライブラリは何ですか？**

Aspose.Slides for Python via Java、JPype、互換性のある Java ランタイム、そして Aspose.Words for Java を使用します。両方の Aspose ライブラリは同一の JVM 上で動作します。Aspose.Slides がプレゼンテーションを処理し、Aspose.Words が Word 文書を書き出します。

**PPT や ODP ファイルも PPTX と同様に変換できますか？**

はい。`sample.pptx` を PPT または ODP ファイルに置き換えてください。プレゼンテーションの入力形式については [Supported File Formats](/slides/ja/python-java/supported-file-formats/) を参照してください。

**スライドのすべてのコンテンツが Word で編集可能ですか？**

いいえ。各スライドは静的画像として挿入され、トップレベル自動シェイプから抽出されたプレーンテキストが下に追加されます。グループ内、テーブル、SmartArt、チャート、スピーカーノート内のテキストはこのサンプルでは抽出されません。アニメーションやトランジションも Word 文書には再現されません。

**DOC 形式で保存することはできますか（DOCX の代わりに）？**

はい。出力ファイル名を `output.doc` に変更してください。この保存オーバーロードでは、Aspose.Words がファイル名拡張子から出力形式を自動的に判定します。