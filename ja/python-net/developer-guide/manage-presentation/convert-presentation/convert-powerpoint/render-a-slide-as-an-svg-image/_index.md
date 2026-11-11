---
title: PythonでプレゼンテーションスライドをSVG画像としてレンダリング
linktitle: スライドをSVGへ
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
description: PythonでPowerPointスライドをSVG画像としてエクスポートし、Aspose.Slidesでフォント、テキスト、画像を制御します。
---
## **概要**

SVG は、Web 公開、スライドビューア、アクセシビリティ ワークフロー、そして自動ポストプロセッシングに適した、スケーラブルな XML ベースの画像フォーマットです。Aspose.Slides は各スライドを個別の SVG ファイルとしてエクスポートし、テキスト、フォント、画像、SVG 要素の書き出し方法を制御できます。

エクスポートされた SVG がコンパクトで、ブラウザ間で予測可能、またはインタラクティブな使用に適している必要がある場合は[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/)を使用します。

## **スライドを SVG としてエクスポート**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成し、スライドを選択して、ストリームに書き込みます。以下の例はプレゼンテーション内のすべてのスライドを個別の SVG ファイルとしてエクスポートします。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

ファイル名はループインデックスではなく[Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/)を使用します。スライドビューアやウェブページが特定のシェイプだけを必要とする場合は、[Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/)で個別シェイプをエクスポートすることもできます。

## **SVG 出力の構成**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) は SVG のレンダリングを制御します。テキストフレームについては、[SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) がテキストフレームをレンダリング領域に含め、[SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) がフレーム回転の適用を決定します。テキストをリガチャなしで描画する必要がある場合は、[SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) を `True` に設定します。

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

## **矢じりにおけるラインエンドクロッピングの制御**

SVG 1.1 には矢じりの下でラインを停止させるマーカーインセット設定がありません。デフォルトでは、Aspose.Slides はエクスポートされたラインを短くして、ストロークがマーカーを突き抜けないようにします。[SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) を `True` に設定すると、ストロークが元のエンドポイントまで描画されます。この設定は SVG 出力にのみ影響し、スライド上のラインの位置と長さは保持されます。

例では、2 ポイントと 10 ポイント幅のラインに三角形とダイヤモンドの矢じりを描画します。同じスライドを 2 回エクスポートし、クロッピングオプションだけを変更します。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

比較では、10 ポイントラインの三角形矢じりが示されます。クロッピングが有効な場合は先端が鋭く、無効な場合はストロークがマーカーの斜辺を突き抜けて平坦な端になります。

![クロッピングが有効なときは先端が鋭い拡大された 10 ポイント三角形、無効なときは平坦な端になる](line-end-cropping.png)

他の例のラインでは、2 ポイント三角形では突き抜けたストロークが目立ちにくく、幅がどちらでも塗りつぶしダイヤモンドがストロークの端をカバーします。

## **テキストとフォントの制御**

スライドを SVG にエクスポートする際、テキストをテキストのまま保持するかベクタ画像に変換するか、外部フォントをどのように含めるかまたは参照するかを制御できます。以下のオプションは、エクスポートされた SVG の視覚的一貫性、テキスト選択、フォント依存性のバランスを取るのに役立ちます。

### **すべてのテキストをベクタライズ**

[SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) を `True` に設定すると、スライドのすべてのテキストがベクタ画像として書き出されます。これによりフォント依存がなくなり、ブラウザ間での視覚結果がより一貫しますが、テキストは SVG テキストとして選択や検索ができなくなります。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **外部フォントの処理方法の選択**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) は外部から読み込まれるフォントに対して[SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) の値を使用します。`ADD_LINKS_TO_FONT_FILES` を選択すると別個のフォントファイルへの参照となり、`EMBED` を選択するとフォントデータが SVG に埋め込まれ、`VECTORIZE` を選択すると外部フォントを使用するテキストだけがグラフィックとして描画されます。埋め込み前にフォントのライセンスを確認してください。

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

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) を使用して埋め込み画像の解像度を下げ、[SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) で切り取られた元領域を除外し、[SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) で JPEG エンコード品質を制御します。これらの設定は画像の忠実度や保持データを犠牲にしてファイルサイズを縮小します。

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

## **メタファイルラスタリゼーション解像度の制御**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) は SVG エクスポート時にメタファイルをラスタライズする下限解像度を設定します。EMF や WMF 画像をラスタライズする際のディテールとファイルサイズのバランスを取るために使用します。これは SVG 全体の DPI を定義するものでも、スライド上のすべてのオブジェクトがラスタ画像になることを強制するものでもありません。

[metafile-rasterization.pptx](metafile-rasterization.pptx) をダウンロードしてください。このプレゼンテーションには対角線が密に配置された EMF 画像が含まれています。以下の例は [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/) を使用して、最初のスライドを 3 つのラスタリゼーション解像度でエクスポートします。他のエクスポート設定はすべて同一に保たれ、結果を比較できるようにしています。

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

出力では、EMF が各 SVG に 1 つの埋め込み PNG として変換されます。以下の測定値はサンプルプレゼンテーションに対するもので、DPI をピクセル寸法に変換する一般的な式ではありません。

| メタファイル ラスタリゼーション DPI | 埋め込み PNG の寸法 | SVG ファイル サイズ（バイト） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下の比較は、同じ拡大表示サイズで埋め込みラスタの同一領域を示しています。対角線は 72 DPI でピクセル化が目立ち、解像度が高くなるにつれてエッジが滑らかになり、同時に SVG ファイルが大きくなります。値を上げてもすべてのディテールが改善されるわけでも、すべてのエクスポート画像が変わるわけでもありません。

![72、150、300 DPI で拡大された対角線ディテール](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) は画像解像度の削減を制御し、メタファイルラスタリゼーション解像度の変更効果を隠すことがあります。[SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) は JPEG エンコード品質を制御し、メタファイルラスタリゼーション解像度とは無関係です。

## **FAQ**

**[SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) を [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) の代わりに使用すべき場面は？**

すべてのテキストをフォントに依存しない形で出力したい場合は[SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) を使用します。外部フォントを使用するテキストだけをグラフィックに変換したい場合は[SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) を使用します。

**SVG を小さくする最善の方法は？**

まず埋め込み画像を圧縮し、切り取られた画像領域を削除し、ターゲット環境で提供可能な場合はリンクしたフォントファイルを選択します。画像解像度の低下、JPEG 品質の低下、テキストのベクタライズはそれぞれ品質とサイズのトレードオフがあるため、結果をテストしてください。