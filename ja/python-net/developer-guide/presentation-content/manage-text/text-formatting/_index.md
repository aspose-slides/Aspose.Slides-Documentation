---
title: Pythonでプレゼンテーションテキストをフォーマット
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/python-net/text-formatting/
keywords:
- 段落の配置
- テキストスタイル
- テキスト背景
- テキスト透明度
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for Python via .NET を使用して PowerPoint および OpenDocument プレゼンテーションのテキストを書式設定する方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブストップ、言語設定について解説します。

特に記載がない限り、例では [sample.pptx](sample.pptx) を使用します。最初のスライドの最初のシェイプはテキストボックスで、最初の段落には以下に示すテキストが含まれています。スライドとシェイプのインデックスは 0 から始まります。太字部分を選択する例は、継承された太字書式を含む実効書式を使用しています：

![サンプルテキスト](sample_text.png)

文字列リテラルや正規表現による一致箇所を検索してハイライトする方法については、[Search and Replace Text](/slides/ja/python-net/search-and-replace-text/) を参照してください。

## **テキストの背景色を設定**

段落のデフォルトハイライト色を設定するには [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) を使用し、個別のテキスト部分のハイライト色を設定するには [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) を使用します。

以下の例は、最初の段落のデフォルトハイライトとして薄いグレーを設定します。個別の部分に対する明示的なハイライト色はこのデフォルトより優先されます：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 段落全体のハイライト色を設定します。
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![グレイ段落](gray_paragraph.png)

次のコード例は **太字フォントを持つテキスト部分** の背景色を設定する方法を示します：

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

![グレイテキスト部分](gray_text_portions.png)

## **段落のテキストを配置**

テキストフレーム内の段落配置を設定するには [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) を使用します。値はセンタリング、左揃え、右揃え、均等割付などが可能です。

以下のコード例は段落を **中央** に配置する方法を示します：

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

![配置された段落](aligned_paragraph.png)

## **行内のフォントを配置**

異なるフォントサイズのテキスト部分を同一行内で垂直方向に揃えるには [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) を使用します。この設定は段落全体に適用され、各行内の配置を制御します。

以下の自己完結型例は、1 つのスライドに 4 つのラベル付きテキストボックスを作成します。各段落は 18、36、54 ポイントの同一テキストを含み、フォント配置が異なります。Arial を使用し、オートフィットと折り返しを無効にし、テキストフレームは単一行が収まるだけのサイズにしています。

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

![ベースライン、上部、中央、下部のフォント配置比較](font_alignment.png)

フォント配置はフォントメトリクスに基づくため、個々の文字の可視エッジが完全に一致するわけではありません。この例には大文字とディセンダが含まれ、ベースラインと下部配置の違いを示しています。フォントの可用性や置換、使用文字、フォントサイズの違いが結果に影響します。フレームのサイズ、余白、行間、折り返し、オートフィットもレイアウトに影響するため、モード比較時は同じフォントとレイアウト設定を使用してください。

この設定は水平段落配置を制御する [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) およびシェイプ内でテキストブロックを垂直方向に配置する [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) とは異なります。[BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) による上付き・下付き書式は、ベースラインに対する個々の部分のシフトを行い、段落行のフォント配置を設定するものではありません。

## **テキストの透明度を設定**

テキストの透明度は [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) に割り当てた色のアルファ成分で制御します。以下の例では `alpha = 50` は 0〜255 のスケールでの ARGB アルファチャンネル値であり、透明度のパーセンテージではありません。

次のコード例は **段落全体** に透明度を適用する方法を示します：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # テキストの半透明黒フィルを設定します。
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![透明段落](transparent_paragraph.png)

以下のコード例は **太字フォントを持つテキスト部分** に透明度を適用する方法を示します：

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

![透明テキスト部分](transparent_text_portions.png)

## **テキストの文字間隔を設定**

テキストボックス内の文字間隔を拡大または縮小するには [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) を使用します。例では 3 ポイントの間隔を追加しています。負の値を指定すると文字が縮まります。

次の Python コードは **段落全体** の文字間隔を拡大する方法を示します：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 注意: 文字間隔を縮めるには負の値を使用します。
    paragraph.paragraph_format.default_portion_format.spacing = 3  # 文字間隔を拡張します。

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は **太字フォントを持つテキスト部分** の文字間隔を拡大する方法を示します：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 注意: 文字間隔を縮めるには負の値を使用します。
            portion.portion_format.spacing = 3  # 文字間隔を拡張します。

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効化**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint の表示と比べてやや詰まって見えることがあります。これは PowerPoint が特定フォントのカーニング情報を無視することが原因です（フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効でも同様です）。

このようなケースで PowerPoint の出力に近づけるには、該当フォントを使用するテキスト部分のカーニングを無効にします。[BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) に実際のフォントサイズより大きい値を設定します。この例は、最初のスライドの最初のシェイプがテキストボックスである「presentation.pptx」を使用します。継承フォントを含む実効フォント名をチェックし、Roboto を使用する部分に対して 100 ポイントをしきい値として設定します。これにより、100 ポイント未満のフォントサイズの該当部分のカーニングが無効になります：

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

しきい値以下の該当テキストについては、この設定によりカーニングが抑制され、PowerPoint 固有の動作の影響を受けたフォントの表示結果を Aspose.Slides のレンダリングと合わせることができます。

## **テキストのフォントプロパティを管理**

フォントプロパティは、[ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) を使用して段落レベルで設定するか、[PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) を使用して個別の部分で設定できます。

次の例は、最初の段落のデフォルトフォントを 12 ポイントの Times New Roman に設定し、太字・斜体・点線下線を適用します。個別部分の明示的な書式はこれらのデフォルトより優先されます：

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

次の例は、実効書式が太字である部分に対して 13 ポイントの Times New Roman、斜体、点線下線を適用します：

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

## **テキストの回転を設定**

テキストの向きをシェイプ内で事前定義されたものに設定するには [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) を使用します。

次のコード例はテキストの向きを [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) に設定し、テキストを **90 度反時計回り** に回転させます：

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

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) を使用して、[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) のカスタム回転角度を設定できます。

次のコード例はシェイプ内のテキストフレームを時計回りに 3 度回転させます：

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

## **段落の行間を設定**

Aspose.Slides は [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/)、[ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/)、[ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) を提供し、段落の間隔を制御します。これらのプロパティは次のように使用します。

* 正の値は行高さのパーセンテージとして行間を指定します。
* 負の値はポイント数として行間を指定します。

次の例は最初の段落の行間を行高さの 200%（二重行）に設定します：

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

![段落内の行間](line_spacing.png)

## **改行を制御**

段落の改行規則は、狭いテキストブロックやラテン文字と東アジア文字が混在するプレゼンテーションで有用です。以下のプロパティはすべて [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) に属し、段落全体に適用されます。

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) はラテン文字の改行規則を制御します。混在テキストでは、これを変更すると隣接する東アジア文字や句読点の折り返し位置も変わることがあります。
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) は東アジア文字の改行規則を制御し、行頭・行末の文字制限などを含みます。

これらの規則は、テキストフレーム内で自動折り返しを有効にする [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) の代わりになるものではありません。折り返しが発生したときのレイアウトに影響しますが、改行文字を挿入するわけではありません。明示的な改行は、利用可能幅に関係なく段落内で新しい行を強制します。

次の自己完結型例は、中国語とラテン文字を含む狭いテキストブロックを作成し、両方の改行プロパティを明示的に設定して「line_breaking.pptx」として保存します。ルールを試す際は、片方のプロパティだけを変更し、もう片方は固定したままにしてください。例では 24 ポイントの Arial と SimSun を使用し、フレーム幅 160 ポイント、水平余白 0 に設定しています。[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) は [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) に設定し、テキストサイズとフレームサイズを固定しています。

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

## **ハンギング句読点を制御**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) を使用すると、対象となる句読点がテキスト行の右端を越えて伸び、次の行を占有しなくなります。段落全体に適用され、ハンギングインデントとは異なります。

次の自己完結型例は、幅 100 ポイントのテキストフレームでハンギング句読点を有効にし、「hanging_punctuation.pptx」として保存します。24 ポイントの Arial と水平余白 0 の条件下で、最終ピリオドは「sentence」の後に残り、右端を越えて表示されます。プロパティを [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) に設定すると比較できます。この設定ではピリオドが別行に配置されます。折り返しは有効、オートフィットは無効で幅は固定されています。

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

すべての句読点がハンギングできるわけではありません。可視結果は [フォントとレイアウト条件](#control-line-breaking) に依存し、フォント、利用幅、余白、オートフィット設定を変更すると差異が消えることがあります。

## **テキストフレームのオートフィットタイプを設定**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) は、テキストがコンテナの境界を超えたときの挙動を決定します。テキストを縮小するか、はみ出すか、シェイプを自動的にリサイズするかを制御できます。次の例はシェイプをテキストに合わせてリサイズし、結果を「autofit_type.pptx」として保存します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

自動折り返し後の行数をカウントし、テキストやシェイプ幅の変更が結果に与える影響を確認するには、[Count Rendered Lines](/slides/ja/python-net/manage-paragraph/) を参照してください。行数だけではテキストがコンテナをはみ出しているかどうかは判断できません。

## **テキストフレームのアンカーを設定**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) は、シェイプ内でテキストを垂直方向に配置する方法（上部、中央、下部など）を定義します。次の例はテキストを最初のシェイプの下部にアンカーし、結果を「text_anchor.pptx」として保存します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **テキストのタブ設定**

[ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) と [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) を使用して段落のタブストップを構成します。次の例はデフォルトタブ間隔を 100 ポイントに設定し、30 ポイントに左揃えタブストップを追加します。これらの設定はタブ文字を含むテキストに影響します。

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

Aspose.Slides は [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックや文法チェックに使用される言語を決定します。

次の例は、最初のスライドの最初のシェイプがテキストボックスである「presentation.pptx」を使用し、少なくとも 1 段落があることを前提とします。最初の段落の内容を「1。」に置き換え、フォントを SimSun に設定し、校正言語を簡体字中国語 (`zh-CN`) に割り当てます。結果は「proofing_language.pptx」として保存します。

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

    # 校正言語を簡体字中国語に設定します。
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **デフォルト言語を設定**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義します。次の例はデフォルトテキスト言語を米国英語に設定したプレゼンテーションを作成し、テキストボックスを追加し、最初のテキスト部分の言語として `en-US` を出力します。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # テキスト付きの新しい矩形シェイプを追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # 最初の部分の言語を確認します。
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **デフォルトテキストスタイルを設定**

プレゼンテーションレベルでデフォルトのテキスト書式を適用するには、[Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) を使用します。

次の例は新規プレゼンテーションのトップレベル段落に 14 ポイントの太字フォントをデフォルトとして設定し、結果を「default_text_style.pptx」として保存します。テキストはこれらのデフォルトを継承しますが、より具体的な書式が上書きします。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # トップレベルの段落書式を取得します。
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **全大文字効果でテキストを抽出**

PowerPoint では、**All Caps** フォント効果を適用すると、スライド上では大文字で表示されますが、元のテキストは小文字のままです。Aspose.Slides でそのテキスト部分を取得すると、入力されたままの文字列が返されます。表示されたテキストと合わせるには、[TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) を確認し、値が `ALL` の場合に取得文字列を大文字に変換します。

この例は「sample2.pptx」の最初のスライドの最初のシェイプがテキストボックスであることを前提とし、最初の段落の最初の部分に All Caps 効果が適用された「Hello, Aspose!」が含まれています（下図参照）。

![All Caps 効果](all_caps_effect.png)

次のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示します：

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

## **FAQ**

**スライド上の表のテキストを変更するにはどうすればよいですか？**

表のテキストを変更するには [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) を使用します。セルを走査し、各セルを [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) で取得し、段落書式を [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) を通じて更新します。

**PowerPoint スライドのテキストにグラデーションカラーを適用するにはどうすればよいですか？**

グラデーションカラーを適用するには [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) を使用します。[FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) を [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) に設定し、グラデーションストップ、方向、透明度を構成します。