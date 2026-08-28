---
title: Python で PowerPoint テキスト段落を管理する
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
  - HTML をインポート
  - テキストを HTML に変換
  - 段落を HTML に変換
  - 段落を画像に変換
  - テキストを画像に変換
  - 段落をエクスポート
  - PowerPoint
  - プレゼンテーション
  - Python
  - Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、段落、ポーション、箇条書き、番号付きリスト、インデント、HTML コンテンツ、段落画像の作成と書式設定の方法を学びます。"
---
## **概要**

Aspose.Slides for Python via .NET はテキストをテキストフレーム、段落、およびポーションの階層として表します。

* [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) はシェイプ内のテキストコンテナを表し、段落コレクションへのアクセスを提供します。
* [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) はテキストフレーム内の 1 つの段落を表し、ポーションと段落レベルの書式設定へのアクセスを提供します。
* [Portion](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/) は段落内のテキストランを表します。各ポーションは独自のテキストと文字レベルの書式設定を持つことができます。

したがって、段落は複数のポーションを使用して、フォント、色、サイズ、その他の書式設定が異なるテキストを含めることができます。

## **段落の作成と書式設定**

### **複数のポーションを持つ段落の作成**

次の手順は、3 つの段落を持つテキストフレームを作成し、各段落に 3 つのポーションを含めます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使って対象のスライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。
5. デフォルトの段落を使用し、テキストフレームにさらに 2 つの [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) オブジェクトを追加します。
6. 各段落に 3 つのポーションが入るように十分な [Portion](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/) オブジェクトを追加します。デフォルトの段落にはすでに空のポーションが 1 つ含まれています。
7. 各ポーションのテキストを設定します。
8. [Portion.portion_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/portion_format/) を使って文字レベルの書式設定を適用します。
9. 修正したプレゼンテーションを保存します。

この Python の例が手順を実装しています:

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

### **箇条書きまたは番号付きリストの作成**

箇条書きや番号付けは、関連項目を視認しやすくします。Aspose.Slides では、リスト設定は [BulletFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/) を通じて定義されます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使って対象のスライドにアクセスします。
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。
5. テキストフレームからデフォルトの段落を削除します。
6. 記号箇条書き用に [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) を作成します。
7. [BulletFormat.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/type/) を [BulletType.SYMBOL](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bullettype/) に設定し、箇条書き文字を指定します。
8. 段落のテキスト、インデント、箇条書きの色、箇条書きの高さを設定します。
9. 段落をテキストフレームに追加します。
10. 2 番目の段落を作成し、[BulletFormat.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/type/) を [BulletType.NUMBERED](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bullettype/) に設定します。
11. 番号付き箇条書きのスタイルを構成し、段落をテキストフレームに追加します。
12. プレゼンテーションを保存します。

この Python の例が記号箇条書きと番号付き箇条書きを作成します:

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

画像箇条書きを使うと、記号や数字の代わりにカスタム画像を使用できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使って対象のスライドにアクセスします。
3. [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加し、その [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。
4. テキストフレームからデフォルトの段落を削除します。
5. 箇条書き画像を読み込み、プレゼンテーションの画像コレクションに [PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) として追加します。
6. [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) を作成し、テキストを設定します。
7. [BulletFormat.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/type/) を [BulletType.PICTURE](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bullettype/) に設定します。
8. [BulletFormat.picture](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/picture/) で画像を割り当て、箇条書きの高さを設定します。
9. 段落をテキストフレームに追加します。
10. 修正したプレゼンテーションを保存します。

この Python の例が画像箇条書きを作成します:

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

[ParagraphFormat.depth](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/depth/) を設定して、リストの異なるレベルに段落を配置します。最上位レベルの深さは `0` です。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) を作成し、スライドにアクセスします。
2. [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加し、そのテキストフレームからデフォルトの段落をクリアします。
3. 4 つの段落を作成し、箇条書きシンボルを構成します。
4. それらの [ParagraphFormat.depth](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/depth/) 値をそれぞれ `0`、`1`、`2`、`3` に設定します。
5. 段落をテキストフレームに追加し、プレゼンテーションを保存します。

この Python の例が 4 段階の箇条書きリストを作成します:

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

### **番号付きリスト項目の開始番号をカスタム値に設定**

[BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) を使用して、番号付き段落の最初に表示される番号を設定します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) を作成し、スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
2. シェイプのテキストフレームからデフォルトの段落をクリアします。
3. 3 つの番号付き段落を作成します。
4. 各段落に対して [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) をそれぞれ `2`、`3`、`7` に設定します。
5. 段落をテキストフレームに追加し、プレゼンテーションを保存します。

この Python の例が各段落にカスタム開始番号を割り当てます:

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

## **段落レイアウトと終端プロパティの制御**

### **最初の行インデントを設定**

[ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) プロパティを使用して段落の最初の行インデントを制御します。このプロパティは段落の左余白に対して最初の行だけを移動させます。正の値は最初の行を右にシフトし、残りの行は段落本文に揃ったままです。

テキスト全体を移動させる必要がある場合は [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/margin_left/) を使用し、最初の行だけを移動させる場合は [ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) を使用します。

以下の例は複数の段落を作成し、異なる [ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) 値を適用して最初の行インデントが段落レイアウトに与える影響を示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスし、デフォルトの段落を削除します。
5. 複数の段落を作成し、各段落に異なる [ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) 値を設定します。
6. 段落をテキストフレームに追加します。
7. 修正したプレゼンテーションを保存します。

このコードは段落インデントの設定方法を示しています:

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

![段落の先頭行インデント](first_line_indent.png)

### **ハンギングインデントを設定**

ハンギングインデントは、最初の行が残りの行より左に開始する段落レイアウトです。Aspose.Slides では、[ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) プロパティに負の値を設定して実現します。

実際には、[ParagraphFormat.margin_left](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/margin_left/) が段落本文の左位置を定義し、[ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、正の `margin_left` 値と負の `indent` 値を組み合わせます。

この書式設定は、参考文献、書誌、用語集エントリなど、折り返し行が段落本文の下に揃う必要がある場合に便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスし、デフォルトの段落を削除します。
5. 各段落に正の [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/margin_left/) 値を設定して作成します。
6. ハンギングインデント効果を作り出すために負の [ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) 値を設定します。
7. 段落をテキストフレームに追加します。
8. 修正したプレゼンテーションを保存します。

このコードは段落にハンギングインデントを設定する方法を示しています:

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

### **段落終端の書式プロパティを設定**

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) プロパティは段落終端マークの書式を制御します。次の例は、2 番目の段落の終端マークにフォントサイズとラテン文字フォントを割り当てます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) を読み込み、スライドにアクセスします。
2. [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加し、デフォルトの段落をクリアします。
3. 2 つの段落を作成し、テキストポーションを追加します。
4. 2 番目の段落終端マーク用に [PortionFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portionformat/) を作成します。
5. [PortionFormat.font_height](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portionformat/font_height/) と [PortionFormat.latin_font](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portionformat/latin_font/) を設定します。
6. フォーマットを [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) に割り当て、プレゼンテーションを保存します。

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

## **段落コンテンツのインポートとエクスポート**

### **HTML テキストを段落にインポート**

[ParagraphCollection.add_from_html](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphcollection/add_from_html/) を使用して、HTML マークアップをテキストフレーム内の段落およびポーションに変換します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドにアクセスし、[AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
3. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスし、デフォルトの段落をクリアします。
4. ソース HTML ファイルを読み取ります。
5. HTML 文字列を [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphcollection/add_from_html/) に渡します。
6. 修正したプレゼンテーションを保存します。

この Python の例が HTML をテキストフレームにインポートします:

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

[ParagraphCollection.export_to_html](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphcollection/export_to_html/) を使用して、選択した段落範囲を HTML としてエクスポートします。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) のインスタンスを作成し、目的のプレゼンテーションを読み込みます。
2. スライドにアクセスし、テキストを含む [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を検索します。
3. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。
4. 開始段落インデックスとエクスポートする段落数を指定して [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphcollection/export_to_html/) を呼び出します。
5. 返された HTML 文字列をファイルに書き込みます。

この Python の例が最初のテキストシェイプからすべての段落をエクスポートします:

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **段落を画像としてレンダリング**

[Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) は `get_image` メソッドを提供し、個々の段落を直接レンダリングできます。このメソッドは [IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) を返し、[IImage.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/save/) でファイルまたはストリームに保存できます。親シェイプ全体をレンダリングしたり、ビットマップを手動で切り取る必要はありません。

`get_image` は、段落が親コレクションに見つからない、レンダリング境界が無効、またはレンダリングできない場合に `None` を返すことがあります。保存する前に結果を確認し、返された画像をコンテキストマネージャとして使用してリソースを解放してください。

#### **デフォルトスケールで段落をレンダリング**

サンプルとして `sample.pptx` というプレゼンテーションファイルがあり、1 つのスライドに最初のシェイプが 3 段落を含むテキストボックスであるとします。

![3つの段落があるテキストボックス](paragraph_to_image_input.png)

以下の例は、デフォルトスケールでテキストシェイプ内の 2 番目の段落をレンダリングし、PNG 形式で画像を保存します:

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

![段落の画像](paragraph_to_image_output.png)

#### **テーブルセル内の段落をスケーリングしてレンダリング**

`get_image` に水平および垂直スケール係数を渡すことで、レンダリングされた段落のサイズを制御できます。以下の例はテーブルを作成し、最初のセル内の段落を幅と高さを 2 倍にしてレンダリングし、PNG 画像として保存します:

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

スケール係数 `1` はその軸をデフォルトのピクセルサイズのままにします。たとえば、両方の係数を `2` にすると、幅と高さが約 2 倍となり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力でテキストを鋭くしますが、メモリ使用量とファイルサイズも増加します。`1` 未満の係数は詳細が減少した小さい画像を生成します。アスペクト比を保つには同等の係数を使用し、異なる水平・垂直係数は出力を別々に伸縮させます。

シェイプ全体を画像化したい場合は [Shape.get_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/get_image/) が有用です。段落のみの画像が必要なときは `Paragraph.get_image` を使用してください。

## **FAQ**

**テキストフレーム内で行の折り返しを完全に無効にできますか？**

はい。`[TextFrameFormat.wrap_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/wrap_text/)` を設定して折り返しを無効にすれば、行はテキストフレームの端で改行しません。

**特定の段落のスライド上での正確な境界を取得するにはどうすればよいですか？**

`[Paragraph.get_rect](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/get_rect/)` を使用して段落の境界矩形を取得します。個々のポーションの境界は `[Portion.get_rect](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/get_rect/)` が提供します。

**段落の配置 (左揃え、右揃え、中央揃え、両端揃え) はどこで制御しますか？**

`[ParagraphFormat.alignment](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/alignment/)` は段落レベルの設定で、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部に校正言語を設定できますか？**

はい。個々のポーションに対して `[PortionFormat.language_id](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portionformat/language_id/)` を設定すれば、1 つの段落内で複数言語のテキストを扱えます。