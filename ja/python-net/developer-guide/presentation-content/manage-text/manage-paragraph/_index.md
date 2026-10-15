---
title: Python で PowerPoint のテキスト段落を管理する
linktitle: 段落を管理する
type: docs
weight: 40
url: /ja/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- テキストを追加
- 段落を追加
- テキストを管理
- 段落を管理
- 箇条書きを管理
- 段落インデント
- ハンギングインデント
- 段落箇条書き
- 番号付きリスト
- 箇条書きリスト
- 段落プロパティ
- HTML のインポート
- テキストから HTML へ
- 段落から HTML へ
- 段落から画像へ
- テキストから画像へ
- 段落のエクスポート
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、段落、ポーション、箇条書き、番号付きリスト、インデント、HTML コンテンツ、段落画像の作成と書式設定方法を学びます。"
---
## **概要**

Aspose.Slides for Python via .NET は、テキストをテキストフレーム、段落、およびポーションの階層として表します:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) は、シェイプ内のテキスト コンテナを表し、その段落コレクションへのアクセスを提供します。
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) は、テキストフレーム内の 1 つの段落を表し、そのポーションと段落レベルの書式設定へのアクセスを提供します。
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) は、段落内のテキスト ランを表します。各ポーションは独自のテキストと文字レベルの書式設定を持つことができます。

したがって、段落は複数のポーションを使用することで、異なるフォント、色、サイズ、その他の書式設定を持つテキストを含めることができます。

## **段落の作成と書式設定**

シェイプのテキストフレーム内に段落を作成し、ポーションを使用して個々のテキスト ランの書式設定を行います。このセクションでは、各段落内で複数のポーションを組み合わせ、異なる色、フォント サイズ、スタイルを適用する方法を示します。

### **複数のポーションを使用した段落の作成**

以下の Python の例は、3 つの段落を作成し、それぞれの [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/) コレクションに 3 つのテキスト ランを含めます。デフォルトの段落と空のポーションを再利用し、残りの段落とポーションを追加します。書式設定は [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/) を介して適用され、各段落の最初のポーションは赤で太字、15 ポイント; 2 番目は青で斜体、18 ポイントです。3 番目のポーションはデフォルトの書式設定のままです。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **箇条書きおよび番号付きリストの作成**

段落テキストをシンボル、番号、またはカスタム画像を使ったリストに整理します。このセクションの例は、箇条書きの書式設定、階層リスト、カスタム開始番号をカバーしています。

### **箇条書きまたは番号付きリストの作成**

箇条書きと番号付けにより、関連項目をより簡単に閲覧できます。Aspose.Slides では、リスト設定は [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) で定義されます。

この Python の例は、同じテキストフレームにシンボル箇条書きと番号付き項目を追加します。[BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) は箇条書きのタイプを選択し、[BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) がシンボルを提供し、[BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) が番号付スタイルを選択します。両方の項目は、黒い箇条書きを高さ 100% と段落インデント 25 ポイントで使用します:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **画像箇条書きの使用**

画像箇条書きを使用すると、シンボルや番号の代わりにカスタム画像を使用できます。

この例では、作業ディレクトリに `bullets.png` が必要です。この Python の例は、画像を [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) としてプレゼンテーションの画像コレクションに追加し、段落箇条書きとして使用します。[BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) を画像箇条書きに設定し、画像は [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) で割り当てます。[BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) を 100% に設定して、段落テキストに対する箇条書きのサイズを決定します:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **階層リストの作成**

[ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) を設定して、段落をリストの異なるレベルに配置します。最上位レベルの深さは `0` です。

この Python の例では、[ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) の値を 0 から 3 まで 4 つの段落に割り当て、1 つのテキストフレーム内に階層を作成します。各段落はシンボル箇条書きを使用し、[BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) が丸い箇条書きとハイフンを交互に使用して隣接レベルを区別します:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **番号付きリスト項目をカスタム値で開始**

[BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) を使用して、番号付き段落に表示される開始番号を設定します。

この Python の例は、[BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) を設定して 3 つの段落で番号付けを使用し、[BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) の値をそれぞれ 2、3、7 に割り当てます。開始値は段落ごとに個別に設定でき、表示される番号を飛ばすことができます:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **段落レイアウトと終了プロパティの制御**

段落の余白とインデントを調整して、最初の行と折り返し行の位置を制御します。また、段落終了マークを可視テキスト ポーションとは別に書式設定できます。

### **最初の行インデントの設定**

[ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) プロパティを使用して、段落の最初の行インデントを制御します。このプロパティは段落の左余白に対して最初の行のみを移動させます。正の値は最初の行を右にシフトし、残りの行は段落本文に揃ったままです。

段落全体を移動させたい場合は [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) を使用します。最初の行だけを移動させたい場合は [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) を使用します。

次の例は、3 つの段落に同じ 20 ポイントの [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) と、[ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) の値をそれぞれ 0、20、40 ポイントに設定します。最初の行は徐々に大きなオフセットで開始し、折り返し行は同じ左余白を保ちます:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

結果:
![段落の最初の行インデント](first_line_indent.png)

### **ハンギングインデントの設定**

ハンギングインデントは、最初の行が残りの行の左側から開始する段落レイアウトです。Aspose.Slides では、[ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) プロパティでこの効果を作成します。`indent` を負の値に設定すると、段落本文に対して最初の行が左に移動します。

実際には、[ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) が段落本文の左位置を定義し、[ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、正の `margin_left` 値と負の `indent` 値を設定します。

この書式設定は、文献リスト、参考文献、用語集エントリなど、折り返し行が最初の文字ではなく段落本文の下に揃える必要がある段落で便利です。

次の Python の例では、[ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) の値を 40 と 60 ポイントに、[ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) の値をそれぞれ -20 と -30 ポイントに組み合わせています。各段落で最初の行は折り返し行の左側から開始し、2 番目の段落はより深いハンギングインデントになります:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

結果:
![段落のハンギングインデント](hanging_indent.png)

### **段落終了ランのプロパティ設定**

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) プロパティは段落終了マークの書式設定を制御します。例では少なくとも 1 枚のスライドを含む `Test.pptx` を読み込み、[PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) を作成し、[PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) を 48 ポイント、[PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) を Times New Roman に設定します。この書式を第 2 段落の終了マークに割り当て、可視テキスト ポーションは変更しません:

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **レンダリングされた行数のカウント**

行末の自動折り返しや句読点に影響する段落ルールについては、[Control Line Breaking](/slides/ja/python-net/text-formatting/#control-line-breaking) と [Control Hanging Punctuation](/slides/ja/python-net/text-formatting/#control-hanging-punctuation) を参照してください。

[Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) を使用して、テキストレイアウト後に段落が占める行数（自動折り返しを含む）をカウントします。これは、プレゼンテーションテンプレートでテキストの長さとレイアウトをチェックする際に便利です。

段落は [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/) の 1 アイテムであり、複数のレンダリング行を占めることがあります。段落内の明示的な改行は新しい行を強制しますが、別の段落は作成しません。自動折り返しはテキストに明示的な改行を挿入せず、利用可能な幅に基づいて行を生成します。そのため、段落数や改行文字を数えてもレンダリングされた行数は得られません。

次の例はテキスト シェイプを作成し、行数をカウントし、シェイプを狭め、そしてテキストを短い文字列に置き換えます。例では [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) を有効にし、[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) を無効にして、シェイプの幅が折り返しを制御し、テキストやシェイプの自動縮小を行わないようにしています。各測定は [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) を使用します。シェイプのサイズはポイント単位です。最後に、別の段落を追加し、テキストフレーム全体の行数を合計します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

このテキストとこれらのサイズでシェイプを狭めると行数が増加し、短い文字列に置き換えると減少します。正確なカウントはフォントの利用可否と代替、フォントサイズ、余白、インデント、折り返し、オートフィット設定により変わります。テンプレートをチェックするときは、対象環境で使用するフォントとレイアウト設定を使用してください。

行数だけではテキストがコンテナからはみ出すかどうかは判断できません。利用可能な高さ、行の高さ、段落と行の間隔、オートフィットの動作も重要です。折り返しが無効の場合、1 行だけでも利用可能な幅を超えることがあります。

## **段落コンテンツのインポートとエクスポート**

HTML を使用してテキストをプレゼンテーションに取り込んだり、既存の段落を外部で使用できるようにエクスポートしたりします。このセクションでは、テーブルセル内の段落を含む、個々の段落を画像としてレンダリングする方法も示します。

### **HTML テキストを段落にインポート**

[ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) を使用して、HTML マークアップをテキストフレーム内の段落およびポーションに変換します。

この Python の例は、作業ディレクトリの `file.html` から HTML を読み取り、マークアップを [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) に渡します。テキストフレームのデフォルト段落をクリアし、フレームにインポートされたコンテンツのみが含まれるようにします。四角形のシェイプはスライドの各側に 10 ポイントの余白を残します:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **段落テキストを HTML にエクスポート**

[ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) を使用して、選択した段落範囲を HTML としてエクスポートします。ウェブサイトでプレゼンテーションのテキストを再利用する場合、プレゼンテーションのフォント、サイズ、テキスト ボックス スタイルを持ち込まずにローカルの強調表示を保持したいことがあります。[TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) を設定して、エクスポート側が書式継承をどこまでたどるかを制御します。

[the sample presentation](text-inheritance.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置します。最初のスライドには「Inherited text; explicit red 18pt」というテキストを含む 1 つのテキスト シェイプがあります。入力は意図的に複数の書式レベルを使用しています:

- プレゼンテーションのデフォルトテキストスタイルは Calibri と 28 pt のサイズを提供します。
- テキストフレームの第一レベルテキストスタイルは青いテキストと斜体を提供します。
- 段落は明示的に太字テキストを設定します。
- 第二のポーション "explicit red 18pt" は赤いテキストと 18 pt のサイズを明示的に設定します。

以下の完全な例は同じ段落を 3 回エクスポートします。[TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) をエクスポート メソッドに渡し、各結果を個別の UTF-8 HTML ファイルとして書き出します:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

生成された HTML には最初のポーション「Inherited text; 」のための以下の CSS が含まれます。表は関連する宣言を一覧表示し、他の生成プロパティは簡潔さのために省略しています。

| 出力 | 最初のポーションの関連 CSS | 表示 |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | 青色、太字、斜体のテキスト、28 pt、Calibri フォント（フォントが利用可能な場合） |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 青色、太字、斜体のテキスト；フォントファミリーとサイズは周囲のページまたはブラウザが提供します。 |
| `ParagraphOnly.html` | `font-weight:bold` | 太字のテキスト；フォントファミリー、サイズ、色、斜体は周囲のページまたはブラウザが提供します。 |

第二のポーションはすべての出力で `color:#ff0000`、`font-size:18pt`、`font-weight:bold` を保持します。`ALL` と `TEXT_BOX` ではイタリックも保持されますが、`PARAGRAPH_ONLY` では保持されません。継承を制限しても、段落やポーションに明示的に割り当てられた書式は削除されません。

同じブラウザでファイルを開いて比較してください。2 つの制限モードでは、省略された CSS プロパティは宛先ページのスタイルやブラウザのデフォルトで解決されるため、最終的な外観は HTML が使用される場所に依存します。

### **段落を画像としてレンダリング**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) は個々の段落を直接レンダリングし、[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) を返します。結果は [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) でファイルまたはストリームに保存できます。包含シェイプをレンダリングしたり、ビットマップを手動で切り取る必要はありません。

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) は、段落が親コレクション内に見つからない、または有効なレンダリング境界がない、またはレンダリングできない場合に `None` を返すことがあります。保存する前に結果を確認し、使用後は返された画像を破棄してください。

#### **デフォルトスケールで段落をレンダリング**

例では `sample.pptx` を使用します。これは 1 枚のスライドを持ち、最初のシェイプが 3 段落を含むテキスト ボックスです。

![3 つの段落を含むテキスト ボックス](paragraph_to_image_input.png)

以下の例はインデックス 1 の第 2 段落を選択し、スケール パラメータなしで [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) を呼び出します。シェイプに必要な段落が含まれていることと、レンダリングが画像を返すことを確認した上で、[IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) を使用して PNG 形式で保存します。コンテキスト マネージャーは使用後に画像リソースを解放します。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

結果:
![段落画像](paragraph_to_image_output.png)

#### **テーブルセル内の段落をスケーリングしてレンダリング**

`scale_x` と `scale_y` パラメータを受け取る [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) のオーバーロードを使用して、水平および垂直スケール係数を設定します。次の例はテーブルを作成し、最初のセル内の段落をデフォルト幅と高さの 2 倍でレンダリングし、結果を PNG 画像として保存します。

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

スケール係数 `1` はその軸をデフォルトのピクセルサイズに保ちます。たとえば、両方の係数を `2` にすると、幅と高さが約 2 倍になり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力でテキストをより鮮明にしますが、メモリ使用量とファイルサイズも増加します。`1` 未満の係数は詳細の少ない小さい画像を生成します。アスペクト比を保つには等しい係数を使用し、水平と垂直で異なる係数を設定すると出力が個別に伸びます。

全体のシェイプを [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) でレンダリングすることは、シェイプの塗り、枠線、その他の視覚コンテキストを含める必要がある場合に有用です。段落のみの画像が必要な場合は、[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) を使用してください。

## **FAQ**

**テキストフレーム内で行の折り返しを完全に無効にできますか？**

はい。[TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) を設定して折り返しを無効にすると、行はテキストフレームの端で改行しなくなります。

**特定の段落のスライド上の正確な境界を取得するにはどうすればよいですか？**

[Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) を使用して段落の境界矩形を取得します。[Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) は個々のポーションの境界を提供します。

**段落の配置（左揃え、右揃え、中央揃え、両端揃え）はどこで制御されますか？**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) は段落レベルの設定であり、個々のポーションの書式設定に関係なく、段落全体に適用されます。

行内で異なるフォントサイズのポーションを垂直方向に揃えるには、[Align Fonts Within a Line](/slides/ja/python-net/text-formatting/#align-fonts-within-a-line) を参照してください。

**段落の一部に校正言語を設定できますか？**

はい。個々のポーションに対して [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) を設定すれば、1 つの段落に複数の言語のテキストを含めることができます。