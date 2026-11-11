---
title: PythonでPowerPointテキスト段落を管理する
linktitle: 段落の管理
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
- HTMLをインポート
- テキストからHTMLへ
- 段落からHTMLへ
- 段落から画像へ
- テキストから画像へ
- 段落をエクスポート
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、段落、ポーション、箇条書き、番号付きリスト、インデント、HTML コンテンツ、段落画像の作成と書式設定方法を学びます。"
---
## **概要**

Aspose.Slides for Python via .NET は、テキストをテキストフレーム、段落、ポーションの階層で表します:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) シェイプ内のテキストコンテナを表し、段落コレクションへのアクセスを提供します。
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) テキストフレーム内の 1 つの段落を表し、ポーションと段落レベルの書式設定へのアクセスを提供します。
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 段落内のテキストランを表します。各ポーションは独自のテキストと文字レベルの書式設定を持つことができます。

したがって、段落は複数のポーションを使用することで、フォント、色、サイズ、その他の書式設定が異なるテキストを含めることができます。

## **段落の作成と書式設定**

シェイプのテキストフレーム内で段落を作成し、ポーションを使用して個々のテキストランを書式設定します。このセクションでは、各段落内で複数のポーションを組み合わせ、異なる色、フォントサイズ、スタイルを適用する方法を示します。

### **複数のポーションを持つ段落の作成**

次の Python サンプルは、3 つの段落を作成し、各段落の [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/) コレクションに 3 つのテキストランを含めます。既定の段落と空のポーションを再利用し、残りの段落とポーションを追加します。書式設定は [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/) を通じて行われます。各段落の最初のポーションは赤・太字・15pt、2 番目は青・斜体・18pt、3 番目は既定の書式設定のままです:

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

段落テキストを記号、番号、またはカスタム画像を使用したリストに整理します。このセクションの例は、箇条書き書式設定、多層リスト、カスタム開始番号をカバーしています。

### **箇条書きまたは番号付きリストの作成**

箇条書きと番号付けにより、関連項目のスキャンが容易になります。Aspose.Slides では、リスト設定は [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) を介して定義されます。

この Python サンプルは、同じテキストフレームに記号箇条書きと番号項目を追加します。[BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) で箇条書きタイプを選択し、[BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) で記号を指定し、[BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) で番号スタイルを選択します。両方の項目は高さ 100% の黒い箇条書きを使用し、段落インデントは 25ptです:

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

画像箇条書きを使用すると、記号や番号の代わりにカスタム画像を使用できます。

この例では作業ディレクトリに `bullets.png` が必要です。この Python サンプルは、プレゼンテーションの画像コレクションに [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) として画像を追加し、段落箇条書きとして使用します。[BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) を画像箇条書きに設定し、画像は [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) で割り当てます。[BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) は箇条書きを段落テキストに対して相対的にサイズ付けするため 100% に設定します:

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

### **多層リストの作成**

[ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) を設定して、リスト内の段落を異なるレベルに配置します。最上位レベルの深さは `0` です。

この Python サンプルは、[ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) の値を 0〜3 に割り当てて 4 つの段落を作成し、1 つのテキストフレーム内に階層を作ります。各段落は記号箇条書きを使用し、[BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) が丸い箇条書きとハイフンを交互に設定して隣接レベルを区別します:

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

### **カスタム開始番号で番号付きリスト項目を開始する**

[BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) を使用して、番号付き段落の最初に表示される番号を設定します。

この Python サンプルは、3 つの段落に対して [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) を番号付けに設定し、[BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) の値をそれぞれ 2、3、7 に設定します。開始値は段落ごとに個別に構成でき、表示番号をスキップさせることが可能です:

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

## **段落レイアウトと末尾プロパティの制御**

段落の余白とインデントを調整して、最初の行と折り返し行の位置を制御します。また、段落末尾マークを可視テキストのポーションとは別に書式設定できます。

### **1 行目インデントの設定**

[ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) プロパティを使用して段落の 1 行目インデントを制御します。このプロパティは段落左余白に対して最初の行だけを移動させます。正の値は 1 行目を右にシフトし、残りの行は段落本文に揃ったままです。

全体の段落を移動したい場合は [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) を使用し、1 行目だけを移動したい場合は [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) を使用します。

以下の例は、3 つの段落に同じ [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 20pt を設定し、[ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) の値をそれぞれ 0、20、40pt に設定します。1 行目は徐々に大きなオフセットで開始し、折り返し行は同じ左余白を保持します:

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

ハンギングインデントは、最初の行が残りの行より左に開始する段落レイアウトです。Aspose.Slides では、[ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) プロパティでこの効果を作成します。`indent` に負の値を設定すると、段落本文に対して最初の行が左に移動します。

実際には、[ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) が段落本文の左位置を定義し、[ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、`margin_left` に正の値、`indent` に負の値を設定します。

この書式設定は、参考文献、引用、用語集エントリなど、折り返し行が段落本文の下に揃う必要がある段落に便利です。

以下の Python サンプルは、[ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) の値を 40 と 60pt、[ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) の値をそれぞれ -20 と -30pt に組み合わせます。各段落で最初の行は折り返し行の左に開始し、2 番目の段落はより深いハンギングインデントになります:

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

### **段落末尾ラン プロパティの設定**

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) プロパティは段落末尾マークの書式設定を制御します。例では `Test.pptx` をロードします（少なくとも 1 スライドが必要）。[PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) を作成し、[PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) を 48pt、[PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) を Times New Roman に設定します。この書式を第 2 段落の末尾マークに割り当て、可視テキストのポーションは変更しません:

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

## **レンダリングされた行数の取得**

行末の自動折り返しや句読点に影響する段落ルールについては、[Control Line Breaking](/slides/ja/python-net/text-formatting/#control-line-breaking) と [Control Hanging Punctuation](/slides/ja/python-net/text-formatting/#control-hanging-punctuation) を参照してください。

[Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) を使用して、テキストレイアウト後の段落が占める行数（自動折り返しを含む）を取得できます。これは、プレゼンテーションテンプレートでテキスト長とレイアウトを確認する際に便利です。

段落は [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/) の 1 アイテムであり、複数のレンダリング行を占めることがあります。段落内の明示的な改行は新しい段落を作成せずに新しい行を強制します。自動折り返しは利用可能な幅に基づいて行を生成し、テキストに明示的な改行文字を挿入しません。そのため、段落数や改行文字を数えてもレンダリング行数は得られません。

以下の例はテキストシェイプを作成し、行数をカウントし、シェイプを狭くしてからテキストを短い文字列に置き換えます。例では [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) を有効にし、[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) を無効にして、シェイプ幅が折り返しを制御し、テキストやシェイプの自動縮小を行わないようにします。各測定は [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) を使用します。シェイプ寸法はポイント単位です。最後に、別の段落を追加し、テキストフレーム全体の行数を合計します:

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

このテキストと寸法では、シェイプを狭めると行数が増加し、短い文字列に置き換えると行数が減少します。正確なカウントはフォントの可用性と置換、フォントサイズ、余白、インデント、折り返し、オートフィット設定により変わります。テンプレートをチェックする際は、対象環境で使用するフォントとレイアウト設定を使用してください。

行数だけではテキストがコンテナをはみ出すかどうかは判断できません。利用可能な高さ、行高、段落・行間、オートフィット動作も重要です。折り返しが無効の場合、1 行でも利用可能な幅を超えることがあります。

## **段落コンテンツのインポートとエクスポート**

HTML を使用してテキストをプレゼンテーションに取り込んだり、既存の段落を外部で使用できるようにエクスポートしたりします。このセクションでは、テーブルセル内の段落を含む、個々の段落を画像としてレンダリングする方法も示します。

### **HTML テキストを段落にインポートする**

[ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) を使用して、HTML マークアップをテキストフレーム内の段落とポーションに変換します。

この Python サンプルは作業ディレクトリの `file.html` から HTML を読み取り、[ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) に渡します。テキストフレームの既定段落をクリアして、フレームにインポートされたコンテンツのみが含まれるようにします。矩形シェイプはスライドの各側に 10pt の余白を残します:

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

### **段落テキストを HTML にエクスポートする**

[ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) を使用して、選択した段落範囲を HTML としてエクスポートします。プレゼンテーションのテキストを Web サイトで再利用する場合、フォント、サイズ、テキストボックススタイルを持ち込まずにローカルの強調だけを保持したいことがあります。その際は [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) を設定して、エクスポートがどこまで書式継承をたどるかを制御します。

[サンプルプレゼンテーション](text-inheritance.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置してください。最初のスライドにはテキスト "Inherited text; explicit red 18pt" を含む 1 つのテキストシェイプがあります。入力は意図的に複数の書式レベルを使用しています:

- プレゼンテーションの既定テキストスタイルは Calibri と 28pt を供給します。
- テキストフレームの第 1 レベルテキストスタイルは青文字と斜体を供給します。
- 段落は太字を明示的に設定します。
- 2 番目のポーション "explicit red 18pt" は赤文字と 18pt のサイズを明示的に設定します。

以下の完全な例は同じ段落を 3 回エクスポートします。[TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) をエクスポートメソッドに渡し、結果を別々の UTF-8 HTML ファイルとして書き出します:

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

生成された HTML には最初のポーション "Inherited text; " 用の次の CSS が含まれます。表は関連する宣言を示し、他の生成プロパティは簡潔さのため省略しています。

| 出力 | 最初のポーションの関連 CSS | 表示 |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Calibri が利用可能な場合、28pt の青・太字・斜体テキスト |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 青・太字・斜体テキスト；フォントファミリとサイズはページまたはブラウザが供給 |
| `ParagraphOnly.html` | `font-weight:bold` | 太字テキスト；フォントファミリ、サイズ、色、斜体はページまたはブラウザが供給 |

2 番目のポーションはすべての出力で `color:#ff0000`、`font-size:18pt`、`font-weight:bold` を保持します。また、`ALL` と `TEXT_BOX` では斜体を保持しますが、`PARAGRAPH_ONLY` では保持しません。継承制限により、段落やポーションに明示的に割り当てられた書式は削除されません。

同じブラウザでファイルを開いて比較してください。制限モードでは、省略された CSS プロパティは宛先ページのスタイルまたはブラウザのデフォルトで解決されるため、最終的な見た目は HTML の使用場所によって変わります。

### **HTML クリップボードフラグメントの生成**

[ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) は HTML 文字列を返します。[TextToHtmlConversionOptions.add_clipboard_fragment_header](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/add_clipboard_fragment_header/) を `False` に設定すると通常の HTML、`True` に設定すると Windows クリップボードヘッダーを含む HTML クリップボードフラグメントが生成されます。ヘッダーには周囲の HTML のバイトオフセット (`StartHTML` と `EndHTML`) と貼り付けフラグメントのオフセット (`StartFragment` と `EndFragment`) が含まれます。

この例は 2 つの書式付き段落を普通の HTML (`html`) と HTML クリップボードフラグメント (`clipboard_html`) としてエクスポートします。フラグメントをシステムクリップボードに書き込むには別のアプリケーション手順が必要です。クリップボード API が生バイトを期待する場合は、BOM なしの UTF-8 でエンコードしてください。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 400, 100)
    paragraphs = shape.text_frame.paragraphs
    paragraphs.clear()
    paragraphs.add_from_html("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>")

    options = slides.export.TextToHtmlConversionOptions()
    options.add_clipboard_fragment_header = False
    html = paragraphs.export_to_html(0, paragraphs.count, options)

    options.add_clipboard_fragment_header = True
    clipboard_html = paragraphs.export_to_html(0, paragraphs.count, options)
```

### **段落を画像としてレンダリングする**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) は個々の段落を直接レンダリングし、[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) を返します。取得した画像は [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) でファイルまたはストリームに保存できます。親シェイプ全体をレンダリングしたり、ビットマップを手動で切り取る必要はありません。

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) は、段落が親コレクションに見つからない、レンダリング境界が無効、またはレンダリングできない場合に `None` を返すことがあります。保存する前に結果を確認し、使用後は画像を破棄してください。

#### **デフォルト倍率で段落をレンダリングする**

例では、1 つのスライドに 3 段落を含むテキストボックスがある `sample.pptx` を使用します。

![3 段落を含むテキストボックス](paragraph_to_image_input.png)

以下の例はインデックス 1 の第 2 段落を選択し、スケールパラメータなしで [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) を呼び出します。シェイプに必要な段落が含まれていることと、レンダリングが画像を返すことを確認した上で、[IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) で PNG 形式で保存します。コンテキストマネージャは使用後に画像リソースを解放します。

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

#### **テーブルセル内の段落をスケーリングしてレンダリングする**

`scale_x` と `scale_y` パラメータを受け取る [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) のオーバーロードを使用して、横方向と縦方向のスケール係数を設定します。以下の例はテーブルを作成し、最初のセル内の段落をデフォルト幅と高さの 2 倍でレンダリングし、PNG 画像として保存します。

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

スケール係数 `1` はその軸をデフォルトのピクセルサイズのままにします。たとえば、両方の係数を `2` にすると、幅と高さが約 2 倍になり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力でテキストをより鮮明にしますが、メモリ使用量とファイルサイズも増加します。`1` 未満の係数は詳細が少ない小さな画像を生成します。段落のアスペクト比を保つには同じ係数を使用し、横・縦で異なる係数を使用すると出力が個別に伸びます。

シェイプ全体を画像化したい場合は、[Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) が有用です。段落のみの画像には [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) を使用してください。

## **FAQ**

**テキストフレーム内で行折り返しを完全に無効にできますか？**

はい。[TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) を設定して折り返しを無効にすると、行はテキストフレームの端で改行しなくなります。

**特定の段落のスライド上の正確な境界を取得するには？**

[Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) を使用して段落のバウンディング矩形を取得します。[Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) は個々のポーションの境界を提供します。

**段落の配置（左、右、中央、両端揃え）はどこで制御しますか？**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) は段落レベルの設定で、個々のポーション書式設定に関係なく段落全体に適用されます。

各行内でフォントサイズの異なるポーションを縦方向に揃える方法については、[Align Fonts Within a Line](/slides/ja/python-net/text-formatting/#align-fonts-within-a-line) を参照してください。

**段落の一部に校正言語を設定できますか？**

はい。個々のポーションに対して [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) を設定すると、1 段落内で複数の言語のテキストを含めることができます。