---
title: Pythonでプレゼンテーションテキストをフォーマットする
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/python-net/text-formatting/
keywords:
- 段落の配置
- テキストスタイル
- テキスト背景
- テキスト透過性
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキスト回転
- 回転角度
- テキストフレーム
- 行間隔
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、カラー、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for Python via .NET を使用して PowerPoint および OpenDocument プレゼンテーションのテキストを書式設定する方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブストップ、言語設定などをカバーしています。

特に記載がない限り、例では [sample.pptx](sample.pptx) を使用します。最初のスライドの最初のシェイプはテキスト ボックスで、その最初の段落には以下に示すテキストが含まれています。スライドとシェイプのインデックスはゼロベースです。太字部分を選択する例は、効果的な書式設定（継承された太字書式を含む）を使用します。

![サンプルテキスト](sample_text.png)

文字列や正規表現の一致箇所を検索してハイライトするには、[テキストの検索と置換](/slides/ja/python-net/search-and-replace-text/) を参照してください。

## **テキストの背景色を設定**

Paragraph のデフォルトハイライト色を設定するには [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) を使用し、個々のテキスト部分のハイライト色を設定するには [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) を使用します。

以下の例は、最初の段落のデフォルトとして薄いグレーのハイライトを設定します。個々の部分で明示的に設定されたハイライト色はこのデフォルトより優先されます。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 段落全体のハイライトカラーを設定します。
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![グレーの段落](gray_paragraph.png)

以下のコード例は、**太字フォントを持つテキスト部分** の背景色を設定する方法を示します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # テキスト部分のハイライト色を設定します。
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![グレーのテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

テキスト フレーム内の段落配置を設定するには [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) を使用します。値は中央揃え、左揃え、右揃え、両端揃えなどに設定できます。

以下のコード例は、段落を **中央** に揃える方法を示します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 段落の配置を中央に設定します。
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![揃えられた段落](aligned_paragraph.png)

## **行内のフォントの配置**

行内の異なるフォントサイズのテキスト部分を垂直に揃えるには [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) を使用します。この設定は段落全体に適用され、各行内の配置を制御します。

以下のセルフコンテインド例は、1 スライド上に 4 つのラベル付きテキスト ボックスを作成します。各段落は 18、36、54 ポイントの同一テキストを含み、フォント配置が異なります。Arial を使用し、オートフィットと折り返しを無効にし、テキスト フレームは 1 行分だけ十分なサイズに保ちます。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![ベースライン、上部、中央、下部のフォント配置の比較（混在フォントサイズ）](font_alignment.png)

フォント配置はフォントメトリクスに基づくため、個々の文字の可視エッジが完全に一致するわけではありません。例では大文字とディセンダーの両方を含め、ベースラインと下部配置の違いを示しています。フォントの可用性と置換、使用文字、フォントサイズの違いが結果に影響します。フレームサイズ、余白、行間、折り返し、オートフィットもレイアウトに影響するため、モード比較時は同じフォントとレイアウト設定を使用してください。

この設定は水平段落配置を制御する [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) や、シェイプ内でテキスト ブロックを垂直に配置する [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) とは異なります。上付き・下付き書式は [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) を使用してベースラインに対して個々の部分をシフトし、段落行のフォント配置を設定する代わりに使用されます。

## **テキストの透明度を設定**

テキストの透明度は、[BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) に割り当てられた色のアルファ成分で制御します。以下の例では `alpha = 50` は 0〜255 のスケールの ARGB アルファチャネル値であり、透明率ではありません。

以下のコード例は、**段落全体** に透明度を適用する方法を示します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # テキストに半透明の黒塗りつぶしを設定します。
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![透明な段落](transparent_paragraph.png)

以下のコード例は、**太字フォントを持つテキスト部分** に透明度を適用する方法を示します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # テキスト部分の透明度を設定します。
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![透明なテキスト部分](transparent_text_portions.png)

## **テキストの文字間隔を設定**

テキスト ボックス内の文字間隔を拡大または縮小するには [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) を使用します。例では 3 ポイントの間隔を追加しています。負の値はテキストを縮めます。

以下の Python コードは、**段落全体** の文字間隔を拡大する方法を示します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 注: 文字間隔を縮めるには負の値を使用します。
    paragraph.paragraph_format.default_portion_format.spacing = 3  # 文字間隔を拡大します。

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![段落の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントを持つテキスト部分** の文字間隔を拡大する方法を示します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 注: 文字間隔を縮めるには負の値を使用します。
            portion.portion_format.spacing = 3  # 文字間隔を拡大します。

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効化**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint の同一テキストより若干詰まって見えることがあります。これは、PowerPoint が特定フォントのカーニングデータを無視することが原因で、フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっていても起こります。

このようなケースでレンダリング結果を PowerPoint に近づけるには、対象フォントを使用するテキスト部分のカーニングを無効にできます。[BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) を実際のフォントサイズより大きい値に設定します。この例は、最初のスライドの最初のシェイプがテキスト ボックスである "presentation.pptx" を前提とします。継承フォントを含む効果的なフォント名をチェックし、Roboto を使用する部分に 100 ポイントの閾値を設定します。これにより、100 ポイント未満のサイズで Roboto を使用する該当部分のカーニングが無効になります。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

閾値未満の該当テキストでは、この設定によりカーニングが抑制され、PowerPoint 固有の挙動で影響を受けるフォントの視覚的出力に Aspose.Slides のレンダリングを合わせやすくなります。

## **テキストフォントプロパティの管理**

フォントプロパティは、[ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) を通じて段落レベルで、または [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) を使用して個々の部分で設定できます。

以下の例は、最初の段落のデフォルトフォントを 12 ポイントの Times New Roman に設定し、太字・斜体・点線下線を適用します。個々の部分への明示的な書式設定はこれらのデフォルトより優先されます。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 段落のフォントプロパティを設定します。
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![段落のフォントプロパティ](font_properties_for_paragraph.png)

以下の例は、効果的な書式が太字である部分に対し、13 ポイントの Times New Roman、斜体、点線下線を適用します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # テキスト部分のフォントプロパティを設定します。
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![テキスト部分のフォントプロパティ](font_properties_for_text_portions.png)

## **テキスト高さ正規化の制御**

テンプレート版式の再現や文字高さの違いを調査する際に、[BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) を使用します。PowerPoint では、正規化を有効にすると、テキスト部分内の個々の文字が垂直方向に伸縮し、可視高さが均一になります。ただし、フォント間でテキスト高さが等しくなることは保証されません。

プロパティを [NullableBool.TRUE or FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) に設定して正規化を明示的に有効または無効にします。`NullableBool.NOT_DEFINED` はローカル設定を未定義のままにし、段落の [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) などから継承させます。`False` を意味するわけではありません。解決された Boolean 値を取得するには、[PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) と [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) を使用してください。

以下のセルフコンテインド例は、**Arial** がインストールされていることが前提です。54 ポイントで同一の大文字・小文字・ディセンダー・アクセント文字を含む 2 つのテキスト ブロックを作成します。両段落はデフォルトで正規化を有効にしています。上部の部分は明示的に無効化し、下部は継承します。フレームサイズ、余白、段落間隔は同一で、折り返しとオートフィットは無効にして比較を一貫させています。例は `FALSE: False` と `NOT_DEFINED: True` を出力し、"text_height_normalization.pptx" として保存します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

以下の比較は保存されたプレゼンテーションからエクスポートしたものです。上段は正規化が無効 (`FALSE`) で、下段は有効設定を継承しています (`NOT_DEFINED` → `True`)。再現するには Arial をインストールしたままにしてください。

![Arial 54ポイントテキスト（上部は正規化無効、下部は継承された正規化有効）](text_height_normalization.png)

正規化は割り当てられた [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) 値（ポイント単位のフォントサイズ）を変更せずに文字高さを変化させます。段落の [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) は行間を制御し、テキストフレームの [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) はテキストやコンテナのサイズ調整方法を制御します。これらの設定は目的が異なり、レイアウト全体に独立して影響します。段落書式設定と継承の詳細は、[段落の管理](/slides/ja/python-net/manage-paragraph/) を参照してください。

## **取り消し線の適用と削除**

テキスト部分に対して [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) を使用すると、元のテキストを削除せずに訂正、取消語、以前の価格などを表す取り消し線を表示できます。テキストに 1 本または 2 本の線を引くには、[TextStrikethroughType.SINGLE or DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) を設定します。

取り消し線を削除するには `TextStrikethroughType.NONE` を割り当てます。これにより、周囲の書式で取り消し線が指定されていても効果が明示的に無効化されます。対照的に、`TextStrikethroughType.NOT_DEFINED` はローカル設定を未定義のままにし、段落などから継承できるようにします。これが取り消し線の削除を保証するわけではありません。結果の書式（継承値を含む）を確認するには、[PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) を使用してください。

以下のセルフコンテインド例は、3 つの価格比較を作成します。各段落はラベル、以前の価格、現在の価格の別々の部分に分かれており、影響を受けるのは以前の価格のみです。最上段は取り消し線を適用してから削除し、他の段落は単一と二重の取り消し線を保持します。このプロパティを変更しても、太字の以前価格を含むテキストと他の書式は保持されます。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # 取り消し線を適用し、最初の以前価格から明示的に取り消し線を削除します。
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

結果（上から順に）: 取り消し線なし、単一取り消し線、二重取り消し線。

![取り消し線なし、単一取り消し線、二重取り消し線の以前の価格](strikethrough.png)

## **テキストの回転を設定**

シェイプ内で事前定義されたテキスト方向を設定するには [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) を使用します。

以下のコード例は、シェイプ内のテキスト方向を [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) に設定します。これによりテキストは **90 度反時計回り** に回転します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![テキストの回転](text_rotation.png)

## **テキストフレームのカスタム回転を設定**

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) を使用して、[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) のカスタム回転角度を設定します。

以下のコード例は、シェイプ内のテキストフレームを **3 度時計回り** に回転させます。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![カスタムテキスト回転](custom_text_rotation.png)

## **段落の行間隔を設定**

Aspose.Slides は、段落間隔を制御するために [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/)、[ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/)、[ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) を提供します。これらのプロパティは次のように使用します。

* 正の値を使用して、行間隔を行の高さのパーセンテージで指定します。
* 負の値を使用して、行間隔をポイントで指定します。

以下の例は、最初の段落の内部間隔を行の高さの 200%（二倍行間）に設定します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![段落内の行間隔](line_spacing.png)

## **改行の制御**

狭いテキスト ブロックやラテン文字と東アジア文字が混在するプレゼンテーションで、段落の改行規則は便利です。これらのプロパティは [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) に属し、段落全体に適用されます。

* [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) はラテン文字の改行規則を制御します。混在テキストでは、これを変更すると隣接する東アジア文字や句読点の折り返し位置も変わることがあります。
* [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) は東アジア文字の改行規則を制御し、行頭や行末に置ける文字の制限を含みます。

これらの規則は、テキスト フレーム内の自動折り返しを有効にする [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) を置き換えるものではありません。折り返しが発生したときのレイアウトに影響しますが、改行文字を挿入するわけではありません。明示的な改行は、利用可能な幅に関係なく段落内で新しい行を強制します。

以下のセルフコンテインド例は、中国語とラテン文字を含む狭いテキスト ブロックを作成します。両方の改行プロパティを明示的に設定し、"line_breaking.pptx" として保存します。どちらかの規則を試すには、もう一方の設定を固定したままそのプロパティ値を変更してください。例は 24 ポイントの Arial と SimSun、フレーム幅 160 ポイント、水平テキストフレーム余白ゼロで実行します。[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) は [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) に設定し、テキストサイズとフレーム寸法を固定しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **ハンギング句読点の制御**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) は、対象となる句読点がテキスト行の右端を超えて伸びることを許可し、次の行に占有させません。段落全体に適用され、ハンギングインデントとは異なります。

以下のセルフコンテインド例は、幅 100 ポイントのテキストフレームでハンギング句読点を有効にし、"hanging_punctuation.pptx" として保存します。24 ポイントの Arial と水平余白ゼロの条件下で、最後の句点は "sentence" の後に残り、右テキスト端を超えて表示されます。比較のためにプロパティを [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) に設定すると、句点が別行に占有されます。折り返しは有効、オートフィットは無効にして利用可能幅を固定しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

すべての句読点がハンギングできるわけではありません。可視結果は [フォントとレイアウト条件](#control-line-breaking) に依存し、フォント、利用可能幅、余白、オートフィット設定を変更すると差異が消えることがあります。

## **テキストフレームのオートフィットタイプを設定**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) は、テキストがコンテナの境界を超えたときの挙動を決定します。テキストを縮小するか、はみ出すか、シェイプを自動的にリサイズするかを制御できます。以下の例は、シェイプをテキストに合わせてリサイズするよう構成し、結果を "autofit_type.pptx" として保存します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

自動折り返し後の行数をカウントし、テキストまたはシェイプ幅の変化が結果に与える影響を確認するには、[描画された行数のカウント](/slides/ja/python-net/manage-paragraph/) を参照してください。行数だけではテキストがコンテナをはみ出しているかどうかは判断できません。

## **テキストフレームのアンカーを設定**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) は、テキストをシェイプ内で垂直に配置する方法（上部、中央、下部など）を定義します。以下の例は、最初のシェイプのテキストを下部にアンカーし、結果を "text_anchor.pptx" として保存します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **テキストのタブ設定**

段落内のタブストップを設定するには、[ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) と [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) を使用します。以下の例は、デフォルトタブ間隔を 100 ポイントに設定し、30 ポイント地点に左揃えタブストップを追加します。これらの設定はタブ文字を含むテキストに影響します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![段落タブ](paragraph_tabs.png)

## **校正言語を設定**

Aspose.Slides は、テキスト部分の校正言語を設定できる [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) を提供します。校正言語は PowerPoint のスペルチェックおよび文法チェックに使用される言語を決定します。

以下の例は、最初のスライドの最初のシェイプがテキスト ボックスである "presentation.pptx" を前提とし、少なくとも 1 段落が必要です。最初の段落の内容を "1。" に置き換え、フォントを SimSun に設定し、簡体字中国語校正言語 (`zh-CN`) を割り当てます。結果は "proofing_language.pptx" として保存します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # 簡体字中国語の校正言語を設定します。
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **言語メタデータのコピー**

テンプレートから多言語テキストをコピーする場合、[BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) と [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/) の両方を保持してください。以下のセルフコンテインド例は、ソース部分に米英語を言語、フランス語を代替言語として作成し、テキストと識別子を新しいプレゼンテーションの部分へコピーします。

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # ソースに代替言語が設定されていない場合、None は宛先の値をクリアします。
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

代替言語なしのソースを試すには、`"fr-FR"` の割り当てを省略してください。その場合、代替識別子は `None` となり、同じコピー文は目的側に代替言語が以前に設定されていてもデフォルト値を導入せずにその欠如を保持します。

これらの識別子は言語メタデータとして保存されます。保持しても、PowerPoint がどの辞書をスペルチェックや文法チェックに使用するかは決定しません。

## **デフォルト言語を設定**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義します。以下の例は、デフォルトテキスト言語を米英語に設定したプレゼンテーションを作成し、テキスト ボックスを追加し、最初のテキスト部分の言語として `en-US` を出力します。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # 新しい矩形シェイプにテキストを追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # 最初の部分の言語を確認します。
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **デフォルトテキストスタイルを設定**

プレゼンテーション レベルでデフォルトのテキスト書式を適用するには、[Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) を使用します。

以下の例は、新しいプレゼンテーションのトップレベル段落のデフォルトとして 14 ポイントの太字フォントを設定し、"default_text_style.pptx" として保存します。テキストはこれらのデフォルトを継承できますが、より具体的な書式が上書きします。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 上位レベルの段落書式を取得します。
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **全大文字効果でテキストを抽出**

PowerPoint で **All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上では大文字で表示されます。Aspose.Slides でそのようなテキスト部分を取得すると、ライブラリは入力されたままのテキストを返します。表示テキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) を確認し、値が `ALL` の場合は取得文字列を大文字に変換してください。

この例は、最初のスライドの最初のシェイプがテキスト ボックスである "sample2.pptx" を前提とします。最初の段落の最初の部分に **All Caps** 効果が適用された "Hello, Aspose!" が含まれており、以下に示します。

![全大文字効果](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示します。

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

出力:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **よくある質問**

**スライド上のテーブルのテキストを変更するにはどうすればよいですか？**

スライド上のテーブルのテキストを変更するには、[Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) を使用します。セルを反復処理し、各セルを [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) で更新し、段落書式は [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) で行います。

**PowerPoint スライド上のテキストにグラデーションカラーを適用するにはどうすればよいですか？**

テキストにグラデーションカラーを適用するには、[BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) を使用します。[FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) を [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透明度を構成します。

関連機能: [スライド内のテキスト書式設定](/slides/ja/features/text-formatting/)