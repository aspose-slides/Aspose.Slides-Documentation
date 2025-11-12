---
title: Pythonでプレゼンテーションにフォントを埋め込む
linktitle: フォント埋め込み
type: docs
weight: 40
url: /ja/python-net/embedded-font/
keywords:
- フォント追加
- フォント埋め込み
- フォント埋め込み
- 埋め込みフォント取得
- 埋め込みフォント追加
- 埋め込みフォント削除
- 埋め込みフォント圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションに TrueType フォントを埋め込み、すべてのプラットフォームで正確にレンダリングできるようにします。
---

## **概要**

**PowerPoint へのフォント埋め込み** は、プレゼンテーションが異なるシステム間で意図した外観を保つことを保証します。独自のフォントを使用してクリエイティブに仕上げる場合でも、標準フォントを使用する場合でも、フォントを埋め込むことでテキストやレイアウトの乱れを防止します。

作業でクリエイティブに第三者製や非標準フォントを使用した場合、さらにフォントを埋め込む理由が増えます。埋め込みフォントがない場合、スライド上のテキストや数字、レイアウト、スタイリングなどが変更されたり、意味不明な四角形に置き換わったりする可能性があります。

埋め込みフォントを管理するには、[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)、[FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/)、および [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) クラスを活用します。

## **埋め込みフォントの取得と削除**

[get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) および [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/) メソッドを使用して、プレゼンテーションから埋め込みフォントを簡単に取得または削除できます。

以下の Python コードは、プレゼンテーションから埋め込みフォントを取得および削除する方法を示しています。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # 埋め込みフォント 'FunSized' を使用したテキスト フレームを含むスライドをレンダリングします。
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # すべての埋め込みフォントを取得します。
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # フォント 'Calibri' を検索します。
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # フォント 'Calibri' を削除します。
    fonts_manager.remove_embedded_font(font_data)

    # スライドをレンダリングします。'Calibri' フォントは既存のフォントに置き換えられます。
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # 埋め込み 'Calibri' フォントなしでプレゼンテーションをディスクに保存します。
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **埋め込みフォントの追加**

[EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) 列挙体と [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/) メソッドの 2 つのオーバーロードを使用して、プレゼンテーションにフォントを埋め込むための好みの（埋め込み）ルールを選択できます。以下の Python コードは、フォントを埋め込み、プレゼンテーションに追加する方法を示しています。

```python
import aspose.slides as slides

# プレゼンテーションをロードします。
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

[compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) を使用して埋め込みフォントを圧縮し、ファイルサイズを最適化します。

圧縮の例コードは以下の通りです。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**埋め込みが行われていても、プレゼンテーション内の特定のフォントがレンダリング時に置換されるかどうかは、どのように確認できますか？**

フォントマネージャの[置換情報](/slides/ja/python-net/font-substitution/)と[フォールバック/置換ルール](/slides/ja/python-net/fallback-font/) を確認してください。フォントが利用できない、または制限されている場合は、フォールバックが使用されます。

**Arial や Calibri などの「システム」フォントを埋め込む価値はありますか？**

通常は不要です。これらのフォントはほとんど常に利用可能だからです。ただし、Docker や事前にフォントがインストールされていない Linux サーバーなどの「薄い」環境で完全なポータビリティを確保したい場合は、システムフォントを埋め込むことで予期しない置換のリスクを排除できます。