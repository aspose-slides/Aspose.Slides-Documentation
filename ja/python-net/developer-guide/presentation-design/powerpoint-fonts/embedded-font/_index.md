---
title: Pythonでプレゼンテーションにフォントを埋め込む
linktitle: フォントの埋め込み
type: docs
weight: 40
url: /ja/python-net/embedded-font/
keywords:
- フォントの追加
- フォントの埋め込み
- フォント埋め込み
- 埋め込みフォントの取得
- 埋め込みフォントの追加
- 埋め込みフォントの削除
- 埋め込みフォントの圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションに TrueType フォントを埋め込み、すべてのプラットフォームで正確なレンダリングを実現します。"
---

## **概要**

**PowerPoint へのフォント埋め込み** は、プレゼンテーションが異なるシステム間でも意図した外観を保つことを保証します。独自のフォントを使用してクリエイティブに仕上げる場合でも、標準フォントを使用する場合でも、フォントを埋め込むことでテキストやレイアウトの乱れを防げます。

作品をクリエイティブに仕上げるためにサードパーティ製や非標準フォントを使用した場合、フォントを埋め込む理由はさらに増えます。埋め込みフォントがない場合、スライド上のテキストや数字、レイアウト、スタイリングなどが変化したり、意味不明な矩形（四角形）になってしまうことがあります。

埋め込みフォントを管理するには、[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)、[FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/)、および [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) クラスを利用します。

## **埋め込みフォントの取得と削除**

プレゼンテーションから埋め込みフォントを簡単に取得または削除するには、[get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) および [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/) メソッドを使用します。

このPythonコードは、プレゼンテーションから埋め込みフォントを取得および削除する方法を示しています:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # 埋め込まれた 'FunSized' フォントを使用するテキスト フレームを含むスライドをレンダリングします。
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # すべての埋め込みフォントを取得します。
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # 'Calibri' フォントを検索します。
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # 'Calibri' フォントを削除します。
    fonts_manager.remove_embedded_font(font_data)

    # スライドをレンダリングします。'Calibri' フォントは既存のフォントに置き換えられます。
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # 埋め込まれた 'Calibri' フォントなしでプレゼンテーションをディスクに保存します。
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```


## **埋め込みフォントの追加**

[EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) 列挙体と [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/) メソッドの 2 つのオーバーロードを使用すると、プレゼンテーションにフォントを埋め込むための好みの（埋め込み）ルールを選択できます。このPythonコードは、フォントを埋め込み追加する方法を示しています:
```python
import aspose.slides as slides

# プレゼンテーションを読み込みます。
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # プレゼンテーションをディスクに保存します。
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```


## **埋め込みフォントの圧縮**

[compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) を使用して埋め込みフォントを圧縮することで、ファイル サイズを最適化できます。

圧縮の例コード:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**プレゼンテーション内の特定のフォントが埋め込みされていても、レンダリング時に置換される可能性があるかどうかはどう確認できますか？**

フォントマネージャーの[置換情報](/slides/ja/python-net/font-substitution/) と[フォールバック/置換ルール](/slides/ja/python-net/fallback-font/) を確認してください。フォントが利用できない、または制限されている場合、フォールバックが使用されます。

**Arial や Calibri などの「システム」フォントを埋め込む価値はありますか？**

通常はありません—これらのフォントはほぼ常に利用可能です。ただし、Docker コンテナやフォントが事前にインストールされていない Linux サーバーなど「薄い」環境での完全なポータビリティが必要な場合、システムフォントを埋め込むことで予期しない置換リスクを排除できます。