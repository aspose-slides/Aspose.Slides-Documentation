---
title: Python でプレゼンテーションにフォントを埋め込む
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
description: ".NET 経由で Python 用 Aspose.Slides を使用して、PowerPoint と OpenDocument のプレゼンテーションに TrueType フォントを埋め込み、すべてのプラットフォームで正確にレンダリングできるようにします。"
---

## **概要**

**PowerPoint へのフォント埋め込み** は、プレゼンテーションが異なるシステムでも意図した外観を保つことを保証します。独自のフォントでクリエイティブに表現する場合でも、標準フォントを使用する場合でも、フォントを埋め込むことでテキストやレイアウトの乱れを防げます。

作品で創造的に作業したためにサードパーティ製や非標準フォントを使用した場合、さらにフォントを埋め込む理由が増えます。埋め込みフォントがない場合、スライド上のテキストや数字、レイアウト、スタイルなどが変更されたり、意味不明な四角形に置き換わったりする可能性があります。

埋め込みフォントを管理するには、[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)、[FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/)、および [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) クラスを活用してください。

## **埋め込みフォントの取得と削除**

プレゼンテーションから埋め込みフォントを簡単に取得または削除するには、[get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) および [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/) メソッドを使用します。

この Python コードは、プレゼンテーションから埋め込みフォントを取得および削除する方法を示しています。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Render the slide containing a text frame that uses the embedded 'FunSized' font.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Get all embedded fonts.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Find the 'Calibri' font.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Remove the 'Calibri' font.
    fonts_manager.remove_embedded_font(font_data)

    # Render the slide; the 'Calibri' font will be replaced with an existing one.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Save the presentation without the embedded 'Calibri' font to disk.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **埋め込みフォントの追加**

[EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) 列挙体と [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/) メソッドの 2 つのオーバーロードを使用して、プレゼンテーションにフォントを埋め込む際の好みの（埋め込み）ルールを選択できます。この Python コードは、フォントを埋め込み、プレゼンテーションに追加する方法を示しています。

```python
import aspose.slides as slides

# Load a presentation.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Save the presentation to disk.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **埋め込みフォントの圧縮**

[compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) を使用して埋め込みフォントを圧縮し、ファイル サイズを最適化します。

圧縮の例コードは以下の通りです。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

**埋め込み済みでも、プレゼンテーション内の特定のフォントがレンダリング時に置き換えられるかどうかはどう確認できますか？**

フォントマネージャの [置換情報](/slides/ja/python-net/font-substitution/) と [フォールバック/置換ルール](/slides/ja/python-net/fallback-font/) を確認してください。フォントが利用できない、または制限されている場合はフォールバックが使用されます。

**Arial や Calibri のような「システム」フォントを埋め込む価値はありますか？**

通常は不要です。これらのフォントはほぼ常に利用可能です。ただし、Docker などの「軽量」環境や、フォントが事前にインストールされていない Linux サーバーなど、完全なポータビリティが必要な場合は、システムフォントを埋め込むことで予期しない置換のリスクを排除できます。