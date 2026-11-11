---
title: Python でプレゼンテーション スライドを SVG 画像としてレンダリング
linktitle: スライドから SVG へ
type: docs
weight: 50
url: /ja/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint から SVG へ
- プレゼンテーションから SVG へ
- スライドから SVG へ
- PPT から SVG へ
- PPTX から SVG へ
- SVG エクスポート オプション
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python で PowerPoint スライドを SVG 画像としてエクスポートし、Aspose.Slides を使用してフォント、テキスト、画像を制御します。"
---
## **概要**

SVGは、Web公開、スライドビューア、アクセシビリティワークフロー、そして自動ポストプロセッシングに適した、スケーラブルなXMLベースの画像フォーマットです。Aspose.Slidesは各スライドを個別のSVGファイルとしてエクスポートし、テキスト、フォント、画像、SVG要素の書き出し方法を制御できます。

エクスポートされたSVGをコンパクトに、ブラウザ間で予測可能に、またはインタラクティブに使用できるようにしたい場合は、[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/)を使用します。

## **スライドをSVGとしてエクスポートする**

まず[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)を作成し、スライドを選択してストリームに書き込みます。以下の例は、プレゼンテーション内のすべてのスライドを個別のSVGファイルとしてエクスポートします。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

ファイル名はループインデックスではなく、[Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/)を使用します。スライドビューアやウェブページが特定の形状だけを必要とする場合は、[Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/)で個別のシェイプをエクスポートすることもできます。

## **SVG出力の構成**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/)はSVGのレンダリングを制御します。テキストフレームの場合、[SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/)はテキストフレームをレンダリング領域に含め、[SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/)はフレームの回転が適用されるかどうかを決定します。テキストをリガチャなしでレンダリングする必要がある場合は、[SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/)を`True`に設定します。

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

スライドをSVGにエクスポートする際、テキストをテキストとして保持するかベクターグラフィックに変換するか、外部フォントをどのように含めるかまたは参照するかを制御できます。以下のオプションは、エクスポートされたSVGにおける視覚的一貫性、テキスト選択、フォント依存関係のバランスを取るのに役立ちます。

### **すべてのテキストをベクター化**

[SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/)を`True`に設定すると、スライド上のすべてのテキストがベクターグラフィックとして書き出されます。これによりフォント依存がなくなり、ブラウザ間で視覚的な結果がより一貫しますが、テキストはSVGテキストとして選択・検索できなくなります。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **外部フォントの取り扱い方法を選択**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/)は、外部からロードされるフォントに対して[SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)の値を使用します。別個のフォントファイルへのリンクを参照したい場合は`ADD_LINKS_TO_FONT_FILES`、SVGにフォントデータを埋め込みたい場合は`EMBED`、外部フォントを使用するテキストだけをグラフィックにレンダリングしたい場合は`VECTORIZE`を選択します。フォントを埋め込む前に、フォントのライセンスを確認してください。

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

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/)を使用して埋め込み画像の解像度を下げ、[SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/)でトリミングされた元領域を省略し、[SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/)でJPEGエンコード品質を制御します。これらの設定は画像の忠実度や保持データを犠牲にしてファイルサイズを削減します。

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

## **メタファイルのラスター化解像度の制御**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/)は、SVGエクスポート時にメタファイルをラスター化する際の最小解像度上限を設定します。EMF や WMF 画像がラスター化される際の詳細度とファイルサイズのバランスを取るために使用します。これは SVG 全体の DPI を定義したり、スライド上のすべてのオブジェクトをラスター画像に変換したりするものではありません。

[metafile-rasterization.pptx](metafile-rasterization.pptx) をダウンロードしてください。これは、密に配置された対角線を含む EMF 画像が入っています。以下の例は、[Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/) を使用して最初のスライドを 3 つのラスター化解像度でエクスポートします。他のすべてのエクスポート設定は同一のままなので、結果を比較できます。

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

出力では、EMF がそれぞれのSVGに埋め込まれた PNG として変換されます。以下の測定値は提供されたプレゼンテーションに対するもので、DPI をピクセル寸法に変換する一般的な式ではありません。

| メタファイル ラスター化 DPI | 埋め込み PNG の寸法 | SVG ファイルサイズ (バイト) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下の比較は、拡大表示サイズが同じで埋め込みラスターの同一領域を示しています。対角線は 72 DPI で目に見えるピクセル化が発生し、解像度が高くなるにつれてエッジが滑らかになりますが、SVG ファイルは大きくなります。値を上げてもすべてのディテールが向上したり、すべてのエクスポート画像が変わるわけではありません。

![拡大された対角線ディテール（72、150、300 DPI）](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/)は画像解像度の削減を制御し、メタファイルのラスター化解像度の変更の影響を隠すことがあります。[SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/)はJPEGエンコード品質を制御し、メタファイルのラスター化解像度は制御しません。

## **FAQ**

**[SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) を [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) の代わりに使用すべきタイミングは？**

[SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) は、すべてのテキストをフォントに依存しないようにしたい場合に使用します。[SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) は、外部フォントを使用するテキストのみをグラフィックに変換したい場合に使用します。

**SVG をより小さくする最良の方法は何ですか？**

まず、埋め込み画像を圧縮し、トリミングされた画像領域を削除し、ターゲット環境で提供可能な場合はリンクされたフォントファイルを選択します。画像解像度の低下、JPEG 品質の低下、ベクター化されたテキストはそれぞれ品質とサイズのトレードオフがあるため、結果をテストしてください。