---
title: Pythonでプレゼンテーションテキストをフォーマット
linktitle: テキストフォーマット
type: docs
weight: 50
url: /ja/python-net/text-formatting/
keywords:
- 段落の配置
- テキストスタイル
- テキストの背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリー
- テキストの回転
- 回転角度
- テキストフレーム
- 行間隔
- オートフィットプロパティ
- テキストフレームアンカー
- テキストのタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: ".NET経由のPython用Aspose.Slidesを使用して、PowerPointおよびOpenDocumentプレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for Python via .NET を使用して PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットする方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブ位置、言語設定などをカバーしています。

特に記載がない限り、例では [sample.pptx](sample.pptx) を使用します。最初のスライドの最初のシェイプはテキストボックスで、最初の段落には以下に示すテキストが含まれています。スライドとシェイプのインデックスはゼロベースです。太字部分を選択する例は、継承された太字書式を含む有効な書式設定を使用します。

![サンプルテキスト](sample_text.png)

リテラルテキストや正規表現の一致を検索してハイライトする方法については、[Search and Replace Text](/slides/ja/python-net/search-and-replace-text/) を参照してください。

## **テキストの背景色を設定**

[ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/default_portion_format/) を使用して段落のデフォルトハイライト色を設定するか、個々のテキスト部分には [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseportionformat/highlight_color/) を使用します。

次の例は、最初の段落のデフォルトハイライトとして薄いグレーを設定します。個々の部分に明示的に設定されたハイライト色はこのデフォルトより優先されます。

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

![グレーの段落](gray_paragraph.png)

以下のコード例は、**太字フォント** のテキスト部分の背景色を設定する方法を示します。

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

[ParagraphFormat.alignment](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/alignment/) を使用してテキストフレーム内の段落配置を設定します。値は中央揃え、左揃え、右揃え、両端揃えなどがあります。

次のコード例は、段落を **中央** に揃える方法を示します。

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

![揃えた段落](aligned_paragraph.png)

## **テキストの透明度を設定**

テキストの透明度は、[BasePortionFormat.fill_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseportionformat/fill_format/) に割り当てられた色のアルファ成分で制御します。以下の例では `alpha = 50` は 0〜255 スケールの ARGB アルファ値であり、透明度のパーセンテージではありません。

次のコード例は、**段落全体** に透明度を適用する方法を示します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # テキストに半透明の黒塗りを設定します。
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![透明な段落](transparent_paragraph.png)

次のコード例は、**太字フォント** のテキスト部分に透明度を適用する方法を示します。

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

[BasePortionFormat.spacing](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseportionformat/spacing/) を使用してテキストボックス内の文字間隔を広げたり縮めたりします。例では 3 ポイントの間隔を追加しています。負の値は文字を詰めます。

次の Python コードは、**段落全体** の文字間隔を広げる方法を示します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 注: 文字間隔を縮めるには負の値を使用します。
    paragraph.paragraph_format.default_portion_format.spacing = 3  # 文字間隔を拡張します。

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォント** のテキスト部分の文字間隔を広げる方法を示します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 注: 文字間隔を縮めるには負の値を使用します。
            portion.portion_format.spacing = 3  # 文字間隔を拡張します。

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効化**

場合によっては、Aspose.Slides が生成するテキストが PowerPoint の表示と比べてやや詰まって見えることがあります。これは PowerPoint が特定フォントのカーニング情報を無視するためです。

このようなケースでは、影響を受けるフォントを使用しているテキスト部分のカーニングを無効にできます。`[BasePortionFormat.kerning_minimal_size]` を実際のフォントサイズより大きい値に設定します。以下の例は、最初のスライドの最初のシェイプがテキストボックスである "presentation.pptx" を使用し、効果的なフォント名を確認し、Roboto を使用している部分に対して 100 ポイントを閾値とします。この閾値未満のフォントサイズの部分はカーニングが無効になります。

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

閾値以下の該当テキストに対して、この設定はカーニングを防止し、PowerPoint 固有の動作に起因するレンダリング差異を減らすのに役立ちます。

## **テキストフォントプロパティを管理**

フォントプロパティは、[ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/default_portion_format/) で段落レベルに設定でき、個々の部分は [PortionFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portionformat/) で設定できます。

次の例は、最初の段落のデフォルトフォントを 12 ポイントの Times New Roman に設定し、太字・イタリック・点線下線を適用します。個々の部分に対する明示的な書式設定はこれらのデフォルトより優先されます。

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

次の例は、効果的に太字となっている部分に対して 13 ポイントの Times New Roman、イタリック、点線下線を適用します。

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

[TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/text_vertical_type/) を使用してシェイプ内のテキストの事前定義された向きを設定します。

次のコード例は、シェイプ内のテキスト向きを [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textverticaltype/) に設定し、テキストを **90 度反時計回り** に回転させます。

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

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/rotation_angle/) を使用して [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) のカスタム回転角度を設定します。

以下のコード例は、シェイプ内のテキストフレームを時計回りに 3 度回転させます。

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

Aspose.Slides は [ParagraphFormat.space_after](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/space_after/)、[ParagraphFormat.space_before](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/space_before/)、[ParagraphFormat.space_within](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/space_within/) を提供し、段落間隔を制御します。これらのプロパティは次のように使用します。

* 正の値は行の高さのパーセンテージとして行間隔を指定します。  
* 負の値はポイント単位で行間隔を指定します。

次の例は、最初の段落の行間隔を行の高さの 200%（二重行間）に設定します。

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

段落の改行規則は、狭いテキストブロックやラテン文字と東アジア文字が混在するプレゼンテーションで有用です。以下のプロパティは [ParagraphFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/) に属し、段落全体に適用されます。

- [latin_line_break](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/latin_line_break/) はラテン文字の改行規則を制御します。混在テキストでは、これを変更すると隣接する東アジア文字や句読点の折り返し位置も変わることがあります。  
- [east_asian_line_break](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/east_asian_line_break/) は東アジア文字の改行規則を制御し、行頭や行末に置けない文字の制限を含みます。

これらの規則は [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/wrap_text/) の代わりになるものではなく、テキストフレーム内で自動折り返しを有効にします。折り返しが発生したときのレイアウトに影響しますが、改行文字は挿入しません。明示的な改行は、幅に関係なく段落内で新しい行を強制します。

次のセルフコンテインド例は、中国語とラテン文字を含む狭いテキストブロックを作成し、両方の改行プロパティを明示的に設定して "line_breaking.pptx" に保存します。どちらか一方の規則だけを試したい場合は、もう一方の設定はそのままにして値を変更してください。例では 24 ポイントの Arial と SimSun を使用し、フレーム幅 160 ポイント、水平余白ゼロに設定しています。[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/autofit_type/) は [TextAutofitType.NONE](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textautofittype/) にしてテキストサイズとフレームサイズを固定しています。

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

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/hanging_punctuation/) を使用すると、対象となる句読点がテキスト行の右端を超えて表示され、次の行に占有されません。段落全体に適用され、ハンギングインデントとは異なります。

次のセルフコンテインド例は、幅 100 ポイントのテキストフレームでハンギング句読点を有効にし、"hanging_punctuation.pptx" に保存します。24 ポイントの Arial と水平余白ゼロの設定で、最後の句点は "sentence" の後に残り、右端を超えて表示されます。比較のためにプロパティを [NullableBool.FALSE](https://reference.aspose.com/slides/ja/python-net/aspose.slides/nullablebool/) に設定すると、句点が別行に配置されます。折り返しは有効、オートフィットは無効にして幅を固定しています。

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

すべての句読点がハングできるわけではありません。見た目はフォントやレイアウト条件（フォント変更、幅、余白、オートフィット設定など）に依存します。

## **テキストフレームのオートフィットタイプを設定**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/autofit_type/) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストが縮小するか、はみ出すか、シェイプが自動的にサイズ変更されるかを制御します。次の例は、シェイプがテキストに合わせてサイズ変更されるように設定し、結果を "autofit_type.pptx" に保存します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

自動折り返し後の行数をカウントし、テキストまたはシェイプ幅の変更が結果に与える影響を確認するには、[Count Rendered Lines](/slides/ja/python-net/manage-paragraph/) を参照してください。行数だけではテキストがコンテナをはみ出しているかどうかは判断できません。

## **テキストフレームのアンカーを設定**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/anchoring_type/) は、テキストがシェイプ内で垂直方向にどこに配置されるか（上部、中央、下部など）を定義します。次の例はテキストを最初のシェイプの下部にアンカーし、結果を "text_anchor.pptx" に保存します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **テキストのタブ設定**

[ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/default_tab_size/) と [ParagraphFormat.tabs](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/tabs/) を使用して段落のタブ位置を構成します。次の例はデフォルトタブ間隔を 100 ポイントに設定し、30 ポイントに左揃えタブ位置を追加します。これらの設定はタブ文字を含むテキストに影響します。

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

![段落のタブ](paragraph_tabs.png)

## **校正言語を設定**

Aspose.Slides は [BasePortionFormat.language_id](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseportionformat/language_id/) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックや文法チェックに使用される言語を決定します。

次の例は "presentation.pptx"（最初のスライドにテキストボックスがある）を使用し、最初の段落の内容を "1。" に置き換え、フォントを SimSun に設定し、校正言語を簡体字中国語 (`zh-CN`) に割り当てます。結果は "proofing_language.pptx" に保存されます。

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

[LoadOptions.default_text_language](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/default_text_language/) を使用して、プレゼンテーションのロードまたは作成時に作成されるテキストのデフォルト言語を定義します。次の例はデフォルトテキスト言語を米国英語に設定し、テキストボックスを追加して最初のテキスト部分の言語コードとして `en-US` を出力します。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # テキスト付きの新しい長方形シェイプを追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # 最初のテキスト部分の言語を確認します。
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **デフォルトテキストスタイルを設定**

プレゼンテーションレベルでデフォルトのテキスト書式を適用するには、[Presentation.default_text_style](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/default_text_style/) を使用します。

次の例は、新しいプレゼンテーションのトップレベル段落に対して 14 ポイントの太字フォントをデフォルトとして設定し、"default_text_style.pptx" に保存します。テキストはこれらのデフォルトを継承しますが、より具体的な書式設定が上書きします。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # トップレベルの段落フォーマットを取得します。
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **全大文字効果でテキストを抽出**

PowerPoint では **All Caps** フォント効果を適用すると、スライド上では大文字で表示されますが、元の入力は小文字のままです。Aspose.Slides でそのテキスト部分を取得すると、入力されたままの文字列が返されます。表示テキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textcaptype/) を確認し、値が `ALL` のときは取得した文字列を大文字に変換します。

この例は "sample2.pptx"（最初のスライドにテキストボックスがある）を使用し、最初の段落の最初の部分に All Caps 効果が適用された "Hello, Aspose!" が含まれています。

![All Caps 効果](all_caps_effect.png)

以下のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示します。

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

**スライド上のテーブルのテキストを変更するにはどうすればよいですか？**

スライド上のテーブルのテキストを変更するには、[Table](https://reference.aspose.com/slides/ja/python-net/aspose.slides/table/) を使用します。セルを反復処理し、各セルを [Cell.text_frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/cell/text_frame/) で更新し、段落書式を [Paragraph.paragraph_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/paragraph_format/) で設定します。

**PowerPoint スライドのテキストにグラデーションカラーを適用するにはどうすればよいですか？**

グラデーションカラーをテキストに適用するには、[BasePortionFormat.fill_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseportionformat/fill_format/) を使用します。[FillFormat.fill_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fillformat/fill_type/) を [FillType.GRADIENT](https://reference.aspose.com/slides/ja/python-net/aspose.slides/filltype/) に設定し、グラデーションストップ、方向、透明度を構成します。