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
- ぶら下げインデント
- 段落箇条書き
- 番号付きリスト
- 箇条書きリスト
- 段落プロパティ
- HTML をインポート
- テキストから HTML へ
- 段落から HTML へ
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

Aspose.Slides for Python via .NET は、テキストをテキスト フレーム、段落、ポーションの階層として表します。

* [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) はシェイプ内のテキスト コンテナを表し、段落コレクションへのアクセスを提供します。
* [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) はテキスト フレーム内の 1 つの段落を表し、ポーションと段落レベルの書式設定へのアクセスを提供します。
* [Portion](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/) は段落内のテキスト ランを表します。各ポーションは独自のテキストと文字レベルの書式設定を持つことができます。

このように、段落は複数のポーションを使用することで、フォント、色、サイズ、その他の書式設定が異なるテキストを含めることができます。

## **段落の作成と書式設定**

### **複数のポーションで段落を作成する**

次の手順は、3 つの段落を持ち、各段落に 3 つのポーションを含むテキスト フレームを作成します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。
5. デフォルトの段落を使用し、テキスト フレームにさらに 2 つの [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) オブジェクトを追加します。
6. 各段落が 3 つのポーションを含むように十分な数の [Portion](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/) オブジェクトを追加します。デフォルトの段落にはすでに空のポーションが 1 つ含まれています。
7. 各ポーションのテキストを設定します。
8. [Portion.portion_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/portion_format/) を使用して文字レベルの書式設定を適用します。
9. 変更したプレゼンテーションを保存します。

この Python の例は上記手順を実装しています：

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

箇条書きや番号付けは、関連項目をすばやく把握できるようにします。Aspose.Slides では、リスト設定は [BulletFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/) で定義します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。
5. テキスト フレームからデフォルトの段落を削除します。
6. 記号箇条書き用に [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) を作成します。
7. [BulletFormat.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/type/) を [BulletType.SYMBOL](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bullettype/) に設定し、箇条書き文字を指定します。
8. 段落のテキスト、インデント、箇条書きの色、箇条書きの高さを設定します。
9. 段落をテキスト フレームに追加します。
10. 2 番目の段落を作成し、[BulletFormat.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/type/) を [BulletType.NUMBERED](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bullettype/) に設定します。
11. 番号付き箇条書きのスタイルを構成し、段落をテキスト フレームに追加します。
12. プレゼンテーションを保存します。

この Python の例は記号箇条書きと番号付き箇条書きを作成します：

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

画像箇条書きでは、記号や番号の代わりにカスタム画像を使用できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加し、その [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。
4. テキスト フレームからデフォルトの段落を削除します。
5. 箇条書き画像を読み込み、[PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) としてプレゼンテーションの画像コレクションに追加します。
6. [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) を作成し、テキストを設定します。
7. [BulletFormat.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/type/) を [BulletType.PICTURE](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bullettype/) に設定します。
8. [BulletFormat.picture](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/picture/) で画像を割り当て、箇条書きの高さを設定します。
9. 段落をテキスト フレームに追加します。
10. 変更したプレゼンテーションを保存します。

この Python の例は画像箇条書きを作成します：

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

[ParagraphFormat.depth](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/depth/) を設定して、リストの異なる階層に段落を配置します。最上位レベルの深さは `0` です。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) を作成し、スライドにアクセスします。
2. [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加し、そのテキスト フレームからデフォルトの段落をクリアします。
3. 4 つの段落を作成し、箇条書きシンボルを設定します。
4. それぞれの [ParagraphFormat.depth](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/depth/) 値を `0`, `1`, `2`, `3` に設定します。
5. 段落をテキスト フレームに追加し、プレゼンテーションを保存します。

この Python の例は 4 レベルの箇条書きリストを作成します：

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

### **番号付きリスト項目の開始番号をカスタム値に設定する**

[BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) を使用して、番号付き段落の最初に表示される番号を設定します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) を作成し、スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
2. シェイプのテキスト フレームからデフォルトの段落をクリアします。
3. 3 つの番号付き段落を作成します。
4. 各段落に対して [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) をそれぞれ `2`, `3`, `7` に設定します。
5. 段落をテキスト フレームに追加し、プレゼンテーションを保存します。

この Python の例は各段落にカスタム開始番号を割り当てます：

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

## **段落のレイアウトと末尾プロパティの制御**

### **先頭行インデントの設定**

[ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) プロパティを使用して、段落の先頭行インデントを制御します。このプロパティは段落の左余白に対して最初の行だけを移動させます。正の値は先頭行を右にシフトし、残りの行は段落本文に揃ったままです。

全体の段落を移動したい場合は [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/margin_left/) を使用し、先頭行だけを移動したい場合は [ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) を使用します。

以下の例は複数の段落を作成し、異なる [ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) 値を適用して先頭行インデントが段落レイアウトに与える影響を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスし、デフォルトの段落を削除します。
5. 複数の段落を作成し、それぞれに異なる [ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) 値を設定します。
6. 段落をテキスト フレームに追加します。
7. 変更したプレゼンテーションを保存します。

このコードは段落インデントの設定方法を示します：

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

結果：

![段落の先頭行インデント](first_line_indent.png)

### **ぶら下げインデントの設定**

ぶら下げインデントは、最初の行が残りの行より左に開始する段落レイアウトです。Aspose.Slides では、[ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) プロパティに負の値を設定して実現します。

実際には、[ParagraphFormat.margin_left](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/margin_left/) が段落本文の左位置を定義し、[ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) がその余白に対する最初の行の位置を定義します。ぶら下げインデントを作成するには、正の `margin_left` 値と負の `indent` 値を設定します。

この書式は、文献リスト、参考文献、用語集エントリなど、折り返し行が段落本文の下に揃える必要がある場合に便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) のインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスし、デフォルトの段落を削除します。
5. 各段落に対して正の [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/margin_left/) 値を設定します。
6. 負の [ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) 値を設定してぶら下げインデント効果を作り出します。
7. 段落をテキスト フレームに追加します。
8. 変更したプレゼンテーションを保存します。

このコードは段落のぶら下げインデントの設定方法を示します：

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

結果：

![段落のぶら下げインデント](hanging_indent.png)

### **段落末尾の実行プロパティの設定**

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) プロパティは段落末尾記号の書式設定を制御します。次の例は、2 番目の段落末尾記号にフォントサイズとラテン文字フォントを割り当てます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) をロードし、スライドにアクセスします。
2. [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加し、デフォルトの段落をクリアします。
3. 2 つの段落を作成し、テキスト ポーションを追加します。
4. 2 番目の段落末尾記号用に [PortionFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portionformat/) を作成します。
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

## **レンダリングされた行数の取得**

改行や行末句読点に影響する段落ルールについては、[Control Line Breaking](/slides/ja/python-net/text-formatting/#control-line-breaking) および [Control Hanging Punctuation](/slides/ja/python-net/text-formatting/#control-hanging-punctuation) を参照してください。

[Paragraph.get_lines_count](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/get_lines_count/) を使用すると、テキスト レイアウト後の段落が占める行数（自動折り返しを含む）を取得できます。これは、プレゼンテーション テンプレートでテキスト長やレイアウトをチェックする際に便利です。

段落は [TextFrame.paragraphs](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/paragraphs/) の 1 要素であり、複数のレンダリング行を占めることがあります。段落内の明示的な改行は新しい行を強制しますが、別の段落は作成しません。自動折り返しは、テキストに明示的な改行文字を挿入せずに利用可能な幅に基づいて行を生成します。そのため、段落数や改行文字の数を数えてもレンダリング行数は得られません。

以下の例はテキスト シェイプを作成し、行数を取得し、シェイプ幅を狭めてからテキストを短い文字列に置換します。折り返しは有効、オートフィットは無効に設定して、シェイプ幅が折り返しを制御し、テキストやシェイプが自動的に縮小されないようにします。シェイプのサイズはポイント単位です。最後に、別の段落を追加してテキスト フレーム全体の行数を合計します。

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

このテキストとサイズの場合、シェイプを狭めると行数が増加し、短い文字列に置換すると減少します。正確な行数はフォントの可用性と置換、フォントサイズ、余白、インデント、折り返し、オートフィット設定により変わります。テンプレートをチェックする際は、対象環境で使用するフォントとレイアウト設定を使用してください。

行数だけではテキストがコンテナを超えているかどうかは判断できません。利用可能な高さ、行の高さ、段落と行間隔、オートフィットの動作も重要です。折り返しが無効の場合、単一行でも利用可能な幅を超えることがあります。

## **段落コンテンツのインポートとエクスポート**

### **HTML テキストを段落にインポートする**

[ParagraphCollection.add_from_html](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphcollection/add_from_html/) を使用して、HTML マークアップをテキスト フレーム内の段落とポーションに変換できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドにアクセスし、[AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
3. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスし、デフォルトの段落をクリアします。
4. ソース HTML ファイルを読み取ります。
5. HTML 文字列を [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphcollection/add_from_html/) に渡します。
6. 変更したプレゼンテーションを保存します。

この Python の例は HTML をテキスト フレームにインポートします：

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

[ParagraphCollection.export_to_html](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphcollection/export_to_html/) を使用して、選択した段落範囲を HTML としてエクスポートできます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) のインスタンスを作成し、目的のプレゼンテーションをロードします。
2. スライドにアクセスし、テキストを含む [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を見つけます。
3. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。
4. 開始段落インデックスとエクスポートする段落数を指定して、[ParagraphCollection.export_to_html](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphcollection/export_to_html/) を呼び出します。
5. 返された HTML 文字列をファイルに書き込みます。

この Python の例は最初のテキスト シェイプからすべての段落をエクスポートします：

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

### **段落を画像としてレンダリングする**

[Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) は `get_image` メソッドを提供し、個々の段落を直接レンダリングできます。メソッドは [IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) を返し、[IImage.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/save/) でファイルまたはストリームに保存できます。包含シェイプ全体をレンダリングしたり、ビットマップを手動でトリミングする必要はありません。

`get_image` は、段落が親コレクションに見つからない、レンダリング境界が無効、またはレンダリングできない場合に `None` を返すことがあります。保存する前に結果を確認し、返された画像をコンテキスト マネージャとして使用してリソースを解放してください。

#### **デフォルトスケールで段落をレンダリングする**

サンプルとして `sample.pptx` というプレゼンテーション ファイルがあり、1 スライドに 3 段落を含むテキスト ボックスが最初のシェイプとして存在すると仮定します。

![3つの段落があるテキストボックス](paragraph_to_image_input.png)

以下の例は、通常のテキスト シェイプ内の 2 番目の段落をデフォルトスケールでレンダリングし、PNG 形式で画像を保存します：

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

結果：

![段落の画像](paragraph_to_image_output.png)

#### **テーブルセル内でスケーリングして段落をレンダリングする**

`get_image` に水平・垂直のスケール係数を渡すと、レンダリングされた段落のサイズを制御できます。以下の例はテーブルを作成し、最初のセル内の段落を幅と高さを 2 倍にしてレンダリングし、PNG 画像として保存します：

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

スケール係数 `1` はその軸をデフォルトのピクセルサイズに保ちます。たとえば、両方の係数を `2` にすると、幅と高さが約 2 倍になり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力時にテキストをより鮮明にしますが、メモリ使用量とファイルサイズも増加します。`1` 未満の係数は詳細が少ない小さな画像を生成します。段落のアスペクト比を保ちたい場合は同じ係数を使用し、異なる水平・垂直係数は出力を独立に伸縮させます。

シェイプ全体を画像化したい場合は [Shape.get_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/get_image/) が有用です。段落だけの画像が必要な場合は `Paragraph.get_image` を使用してください。

## **FAQ**

**テキスト フレーム内で改行を完全に無効にできますか？**

はい。[TextFrameFormat.wrap_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/wrap_text/) を設定して折り返しを無効にすれば、行はテキスト フレームの端で改行しません。

**特定の段落のスライド上での正確な境界を取得する方法は？**

[Paragraph.get_rect](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/get_rect/) を使用して段落の境界矩形を取得できます。[Portion.get_rect](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/get_rect/) は個々のポーションの境界を提供します。

**段落の配置（左揃え、右揃え、中央揃え、両端揃え）はどこで制御しますか？**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/alignment/) は段落レベルの設定であり、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部に校正言語を設定できますか？**

はい。個々のポーションに対して [PortionFormat.language_id](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portionformat/language_id/) を設定すれば、同じ段落内に複数の言語のテキストを含めることができます。