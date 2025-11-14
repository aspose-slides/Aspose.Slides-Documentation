---
title: Python でプレゼンテーションにフォントを埋め込む
linktitle: フォントの埋め込み
type: docs
weight: 40
url: /ja/python-net/embedded-font/
keywords:
- フォントを追加
- フォントを埋め込む
- フォントの埋め込み
- 埋め込みフォントを取得
- 埋め込みフォントを追加
- 埋め込みフォントを削除
- 埋め込みフォントを圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して、PowerPoint および OpenDocument プレゼンテーションに TrueType フォントを埋め込み、あらゆるプラットフォームで正確にレンダリングされるようにする方法をご紹介します。"
---

**PowerPointにおける埋め込まれたフォント**は、プレゼンテーションがどのシステムやデバイスで開かれても正しく表示されるようにするために便利です。創造的な作業のためにサードパーティ製または非標準のフォントを使用した場合、フォントを埋め込む理由はさらに増えます。そうでない場合（埋め込まれたフォントがない場合）、スライド上のテキストや数字、レイアウト、スタイリングなどが変更されたり、混乱を引き起こす長方形に変わる可能性があります。

[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)クラス、[FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/)クラス、[Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)クラス、およびそれらのインターフェイスには、PowerPointプレゼンテーションで埋め込まれたフォントを操作するために必要なほとんどのプロパティとメソッドが含まれています。

## **プレゼンテーションから埋め込まれたフォントを取得または削除する**

Aspose.Slidesは、プレゼンテーションに埋め込まれているフォントを取得（または調べる）ことを可能にする`get_embedded_fonts()`メソッド（[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)クラスによって公開）を提供しています。フォントを削除するには、同じクラスによって公開されている`remove_embedded_font(font_data)`メソッドを使用します。

このPythonコードは、プレゼンテーションから埋め込まれたフォントを取得および削除する方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
with slides.Presentation(path + "EmbeddedFonts.pptx") as presentation:
    # 埋め込まれた"FunSized"を使用するテキストフレームを含むスライドをレンダリング
    with presentation.slides[0].get_image(draw.Size(960, 720)) as img:
        img.save("picture1_out.png", slides.ImageFormat.PNG)

    fontsManager = presentation.fonts_manager

    # すべての埋め込まれたフォントを取得
    embeddedFonts = fontsManager.get_embedded_fonts()

    # "Calibri"フォントを見つける
    
    funSizedEmbeddedFont = list(filter(lambda data : data.font_name == "Calibri", embeddedFonts))[0]

    # "Calibri"フォントを削除
    fontsManager.remove_embedded_font(funSizedEmbeddedFont)

    # プレゼンテーションをレンダリング; "Calibri"フォントは既存のものに置き換えられる
    with presentation.slides[0].get_image(draw.Size(960, 720)) as img:
        img.save("picture2_out.png", slides.ImageFormat.PNG)

    # 埋め込まれた"Calibri"フォントなしでプレゼンテーションをディスクに保存
    presentation.save("WithoutManageEmbeddedFonts_out.ppt", slides.export.SaveFormat.PPT)
```

## **プレゼンテーションに埋め込まれたフォントを追加する**

[EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/)列挙体と`add_embedded_font(font_data, embed_font_rule)`メソッドの2つのオーバーロードを使用することで、プレゼンテーションに埋め込むフォントの好みの（埋め込み）ルールを選択できます。このPythonコードは、プレゼンテーションにフォントを埋め込んで追加する方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションを読み込む
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 置き換えるソースフォントを読み込む
    sourceFont = slides.FontData("Arial")

    allFonts = presentation.fonts_manager.get_fonts()
    embeddedFonts = presentation.fonts_manager.get_embedded_fonts()
    for font in allFonts:
        if font not in embeddedFonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # プレゼンテーションをディスクに保存
    presentation.save("AddEmbeddedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

## **埋め込まれたフォントを圧縮する**

プレゼンテーションに埋め込まれたフォントを圧縮し、そのファイルサイズを減らすことを可能にするために、Aspose.Slidesは`compress_embedded_fonts`メソッド（[Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)クラスによって公開）を提供しています。

このPythonコードは、埋め込まれたPowerPointフォントを圧縮する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:

    slides.lowcode.Compress.compress_embedded_fonts(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```