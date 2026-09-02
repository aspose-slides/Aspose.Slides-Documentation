---
title: PythonでプレゼンテーションスライドをSVG画像としてレンダリング
linktitle: スライドからSVGへ
type: docs
weight: 50
url: /ja/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPointからSVGへ
- プレゼンテーションからSVGへ
- スライドからSVGへ
- PPTからSVGへ
- PPTXからSVGへ
- SVGエクスポートオプション
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "PythonでPowerPointスライドをSVG画像としてエクスポートし、Aspose.Slidesでフォント、テキスト、画像を制御します。"
---
## **概要**

SVG は、Web 発行、スライドビューア、アクセシビリティ ワークフロー、そして自動後処理に適した、スケーラブルな XML ベースの画像フォーマットです。Aspose.Slides は各スライドを個別の SVG ファイルとしてエクスポートし、テキスト、フォント、画像、SVG 要素の書き出し方法を制御できます。

エクスポートされた SVG をコンパクトに、ブラウザ間で予測可能に、またはインタラクティブに使用できるようにしたい場合は、[SVGOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgoptions/) を使用します。

## **スライドを SVG としてエクスポート**

[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) を作成し、スライドを選択してストリームに書き込みます。以下の例は、プレゼンテーション内のすべてのスライドを個別の SVG ファイルとしてエクスポートします。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

ファイル名はループ インデックスではなく [Slide.slide_number](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/slide_number/) を使用します。また、スライドビューアやウェブページが特定のシェイプだけを必要とする場合は、[Shape.write_as_svg](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/write_as_svg/) を使用して個別のシェイプをエクスポートすることもできます。

## **SVG 出力の構成**

[SVGOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgoptions/) は SVG のレンダリングを制御します。テキストフレームの場合、[SVGOptions.use_frame_size](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgoptions/use_frame_size/) はレンダリング領域にテキストフレームを含め、[SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) はフレームの回転を適用するかどうかを決定します。テキストをリガチャなしで描画する必要がある場合は、[SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) を `True` に設定します。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **テキストとフォントの制御**

### **すべてのテキストをベクトル化**

[SVGOptions.vectorize_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgoptions/vectorize_text/) を `True` に設定すると、スライドのすべてのテキストがベクトルグラフィックとして書き出されます。これによりフォント依存がなくなり、ブラウザ間で視覚的結果がより一貫しますが、テキストは SVG テキストとして選択や検索ができなくなります。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **外部フォントの処理方法を選択**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) は、外部からロードされるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgexternalfontshandling/) の値を使用します。`ADD_LINKS_TO_FONT_FILES` を選択すると別個のフォントファイルへの参照が作成され、`EMBED` を選択するとフォントデータが SVG に埋め込まれ、`VECTORIZE` を選択すると外部フォントを使用するテキストのみがグラフィックとして描画されます。フォントを埋め込む前に、フォントのライセンスを確認してください。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **埋め込み画像サイズの削減**

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgoptions/pictures_compression/) を使用して埋め込み画像の解像度を下げ、[SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) でトリミングされた元画像領域を省略し、[SVGOptions.jpeg_quality](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgoptions/jpeg_quality/) で JPEG エンコード品質を制御します。これらの設定は、画像の忠実度や保持される画像データを犠牲にしてファイルサイズを削減します。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **FAQ**

**[SVGOptions.vectorize_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgoptions/vectorize_text/) を [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgexternalfontshandling/) の代わりに使用すべきタイミングはいつですか？**

すべてのテキストをフォントに依存しない形にしたい場合は、[SVGOptions.vectorize_text] を使用します。外部フォントを使用するテキストだけをグラフィックに変換したい場合は、[SvgExternalFontsHandling.VECTORIZE] を使用します。

**SVG を小さくする最良の方法は何ですか？**

まず、埋め込み画像の圧縮、トリミングされた画像領域の削除、そして対象環境で提供可能な場合はリンクされたフォントファイルを選択します。画像解像度の低下、JPEG 品質の低下、テキストのベクトル化はそれぞれ品質とサイズのトレードオフが異なるため、結果をテストしてください。