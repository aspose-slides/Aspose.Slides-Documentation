---
title: Python でプレゼンテーションにフォントを埋め込む
linktitle: フォント埋め込み
type: docs
weight: 40
url: /ja/python-net/developer-guide/presentation-design/powerpoint-fonts/embedded-font/
keywords:
- フォント追加
- フォント埋め込み
- フォント埋め込み処理
- 埋め込みフォント取得
- 埋め込みフォント追加
- 埋め込みフォント削除
- 埋め込みフォント圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションに TrueType フォントを埋め込み、すべてのプラットフォームで正確に表示できるようにします。"
---

## **概要**

**PowerPoint でフォントを埋め込む**ことで、プレゼンテーションは異なるシステムでも意図した外観を保つことができます。独自のフォントを使用して創造的に作成した場合でも、標準フォントを使用した場合でも、フォントを埋め込むことでテキストやレイアウトの乱れを防げます。

クリエイティブな作品のためにサードパーティ製や非標準フォントを使用した場合は、特に埋め込む理由が増えます。埋め込みフォントがない場合、スライド上のテキストや数値、レイアウト、スタイリングなどが変化したり、意味不明な矩形に置き換わったりすることがあります。

[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)、[FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/)、および [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) クラスを利用して、埋め込みフォントを管理しましょう。

## **埋め込みフォントの取得と削除**

プレゼンテーションから埋め込みフォントを簡単に取得または削除するには、[get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) および [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/) メソッドを使用します。

以下の Python コードは、プレゼンテーションから埋め込みフォントを取得し、削除する方法を示しています。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # 埋め込み済みの 'FunSized' フォントを使用したテキストフレームを含むスライドをレンダリングします。
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # すべての埋め込みフォントを取得します。
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # 'Calibri' フォントを検索します。
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # 'Calibri' フォントを削除します。
    fonts_manager.remove_embedded_font(font_data)

    # スライドを再レンダリングします。'Calibri' フォントは既存のフォントに置き換えられます。
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # 埋め込み 'Calibri' フォントなしのプレゼンテーションをディスクに保存します。
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **埋め込みフォントの追加**

[EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) 列挙体と [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/) メソッドの 2 つのオーバーロードを使用して、プレゼンテーションにフォントを埋め込むためのルールを選択できます。以下の Python コードは、フォントを埋め込み、プレゼンテーションに追加する方法を示しています。

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

[compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) を使用して埋め込みフォントを圧縮し、ファイルサイズを最適化します。

圧縮のサンプルコード:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**埋め込みフォントがあるにもかかわらず、レンダリング時に特定のフォントが置き換えられる可能性があるかどうかを確認するにはどうすればよいですか？**

フォントマネージャーの [置換情報](/slides/ja/python-net/font-substitution/) と [フォールバック/置換ルール](/slides/ja/python-net/fallback-font/) を確認してください。フォントが利用できない、または制限されている場合はフォールバックが使用されます。

**Arial や Calibri といった「システム」フォントを埋め込む価値はありますか？**

通常はありません — これらのフォントはほぼ常に利用可能です。ただし、Docker コンテナやフォントが事前にインストールされていない Linux サーバーなど「軽量」環境での完全な移植性が必要な場合は、システムフォントを埋め込むことで予期しない置換リスクを排除できます。