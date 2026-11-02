---
title: "Pythonでプレゼンテーションの箇条書きと番号付きリストを管理する"
linktitle: "リストの管理"
type: docs
weight: 70
url: /ja/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
- "箇条書き"
- "箇条書きリスト"
- "番号付きリスト"
- "シンボル箇条書き"
- "画像箇条書き"
- "カスタム箇条書き"
- "階層リスト"
- "箇条書きの作成"
- "箇条書きの追加"
- "リストの追加"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションで箇条書き、画像、階層、番号付きリストを作成および書式設定する方法を学びます。"
---
## **概要**

Aspose.Slides for Python via .NET を使用すると、PowerPoint および OpenDocument プレゼンテーションで箇条書きリストと番号付きリストを作成および書式設定できます。リスト項目は、段落書式で箇条書き設定が制御される段落です。

段落レベルのリスト設定にアクセスするには、[Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) プロパティを使用します。主なエントリポイントは [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) で、[BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) オブジェクトを返します。このオブジェクトを使用して、箇条書きの種類、シンボル、画像、色、サイズ、番号付スタイル、開始番号を設定できます。

この記事では、以下の方法を示します：

- カスタムシンボルを使用した箇条書きリストを作成する
- 画像箇条書きを作成する
- 段落の深さを設定して階層リストを作成する
- 番号付きリストを作成する
- 既存のプレゼンテーションでリストの書式を検査および変更する
- 段落テキストとともに実際のリストマーカーと番号を読み取る

## **箇条書きリストの作成**

箇条書きリストを作成するには、[Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) オブジェクトを [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) に追加し、[BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) を [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) に設定します。その後、[BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/)、[BulletFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/color/)、[BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) を設定して箇条書きの外観を制御できます。

以下の Python コードは、スライドで箇条書きリストを作成する方法を示します：

```py
import aspose.slides as slides

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = slides.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![シンボル箇条書き](symbol_bullets.png)

## **番号付きリストの作成**

項目の順序が重要な場合は、番号付きリストを使用します。[BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) を [BulletType.NUMBERED](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) に設定します。また、[BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) で番号形式を選択したり、リストを 1 以外の値から開始したい場合は [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) を設定できます。

以下の Python コードは、スライドで番号付きリストを作成する方法を示します：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![番号付き箇条書き](numbered_bullets.png)

## **画像箇条書きの作成**

Aspose.Slides を使用すると、通常の箇条書きシンボルを画像に置き換えることができます。画像箇条書きは、アイコンや小さな透過 PNG ファイルなど、サイズが小さくても読みやすいシンプルな画像で最適に機能します。

{{% alert color="info" title="Note" %}}
理想的には、通常の箇条書きシンボルを画像に置き換える予定がある場合は、透明な背景を持つシンプルなグラフィックを選択するのが最適です。そのような画像は、カスタム箇条書きシンボルとしてうまく機能します。
{{% /alert %}}

画像は非常に小さなサイズに縮小されることに注意してください。そのため、リストの箇条書きとして使用した際にも鮮明で視覚的に効果的な画像を選択することを強く推奨します。

画像箇条書きを作成するには、[Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/) に画像を追加し、返された画像オブジェクトを [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) に割り当てます。画像を割り当てる前に、[BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) を [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) に設定してください。

例えば、"image.png" があるとします:

![箇条書き用画像](picture_for_bullets.png)

以下の Python コードは、スライドで画像箇条書きを作成する方法を示します：

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![画像箇条書き](picture_bullets.png)

## **階層リストの作成**

[ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) を使用して、リスト項目を異なるレベルに配置します。レベル 0 が最上位レベル、レベル 1 がその下位にネストされる、というように続きます。Depth はインデントのみを制御します。レベルにも箇条書きを付けたい場合は、各段落で [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) を設定してください。

以下の Python コードは、階層リストを作成する方法を示します：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![階層リスト](multilevel_list.png)

## **既存リストの変更**

既存のプレゼンテーションでリストの書式を変更するには、対象の段落にアクセスし、その [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) 設定を更新します。リストの作成に使用したのと同じプロパティを使用して、PPT、PPTX、または ODP ファイルから読み込んだリストを検査または変更できます。

以下の Python コードは、テキストフレーム内の最初の段落を番号付きリストスタイルに変更します：

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **実際の箇条書き値の取得**

プレゼンテーションの内容を抽出する際は、段落テキストと一緒にリストマーカーを保持します。[ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/) を呼び出し、[IParagraphFormatEffectiveData.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformateffectivedata/bullet/) にアクセスして実際の箇条書き書式を取得します。[actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) を読み取る前に、その [type](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/type/) を確認してください。

番号付きリストでは、次の 3 つの値を区別します：

- [numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_style/) は形式を決定します。例えば、ピリオドで終わるアラビア数字や小文字の文字が該当します。
- [numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_start_with/) は、番号付き段落のグループの開始番号を指定します。
- [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) は特定の段落に対する書式化されたマーカーを返します。例として、5 から開始するリストの 2 番目の項目は `6.` を返します。

[depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) を各段落に保持して、ネストレベルを維持します。実際のマーカーは階層全体をエンコードしないため、ネストされた項目は `6.c.` のような結合ラベルではなく `c.` を返すことがあります。

以下の自己完結型サンプルは、リストを作成し、プレゼンテーションに保存し、プレゼンテーションを再読み込みして各段落のテキスト、depth、箇条書きタイプ、実際の値を報告します。小さな青い画像マーカーはインライン SVG から作成されます。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 440, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20, 660, 400)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    # 外部画像ファイルなしで画像マーカーを作成します。
    svg = slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.images.add_image(svg)

    def add_paragraph(text, depth, bullet_type, start=1, style=slides.NumberedBulletStyle.BULLET_ARABIC_PERIOD):
        paragraph = slides.Paragraph()
        paragraph.text = text

        paragraph_format = paragraph.paragraph_format
        paragraph_format.depth = depth
        paragraph_format.margin_left = 30 + depth * 40
        paragraph_format.indent = -28
        paragraph_format.space_after = 8
        paragraph_format.default_portion_format.font_height = 22
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = slides.Color.black
        paragraph_format.bullet.type = bullet_type
        paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
        paragraph_format.bullet.color.color = slides.Color.black
        if bullet_type == slides.BulletType.NUMBERED:
            paragraph_format.bullet.numbered_bullet_style = style
            paragraph_format.bullet.numbered_bullet_start_with = start
        elif bullet_type == slides.BulletType.SYMBOL:
            paragraph_format.bullet.char = "\u2022"
        elif bullet_type == slides.BulletType.PICTURE:
            paragraph_format.bullet.picture.image = bullet_image

        text_frame.paragraphs.add(paragraph)

    add_paragraph("First item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Second item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Next nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Deep item", 2, slides.BulletType.NUMBERED, 4, slides.NumberedBulletStyle.BULLET_ROMAN_LC_PERIOD)
    add_paragraph("Back to top level", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Symbol marker", 0, slides.BulletType.SYMBOL)
    add_paragraph("No bullet", 0, slides.BulletType.NONE)
    add_paragraph("Picture marker", 0, slides.BulletType.PICTURE)
    presentation.save("actual_bullet_values.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("actual_bullet_values.pptx") as loaded_presentation:
    loaded_shape = loaded_presentation.slides[0].shapes[0]
    bullet_type_names = {slides.BulletType.NUMBERED: "NUMBERED", slides.BulletType.SYMBOL: "SYMBOL", slides.BulletType.NONE: "NONE", slides.BulletType.PICTURE: "PICTURE"}
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.text_frame.paragraphs:
        bullet = paragraph.paragraph_format.get_effective().bullet
        if bullet.type in (slides.BulletType.NUMBERED, slides.BulletType.SYMBOL):
            marker = bullet.actual_bullet_value
        elif bullet.type == slides.BulletType.NONE:
            marker = f"{bullet.actual_bullet_value} (no bullet)"
        elif bullet.type == slides.BulletType.PICTURE:
            marker = f"{bullet.actual_bullet_value} (image required)"
        else:
            marker = "unsupported bullet type"
        bullet_type_name = bullet_type_names.get(bullet.type, "UNKNOWN")
        print(f"{paragraph.text} | {paragraph.paragraph_format.depth} | {bullet_type_name} | {marker}")
```

以下にソースリストを示します。

![5 から開始し、ネストされた文字とローマ数字項目、シンボルマーカー、箇条書きなしの段落、青い画像マーカーを含むリスト](actual_bullet_values.png)

レポートは PowerPoint に表示されるマーカーと一致します：

```text
Text | Depth | Type | Actual value
First item | 0 | NUMBERED | 5.
Second item | 0 | NUMBERED | 6.
Nested item | 1 | NUMBERED | c.
Next nested item | 1 | NUMBERED | d.
Deep item | 2 | NUMBERED | iv.
Back to top level | 0 | NUMBERED | 7.
Symbol marker | 0 | SYMBOL | •
No bullet | 0 | NONE | None (no bullet)
Picture marker | 0 | PICTURE | None (image required)
```

[BulletType.NONE と BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) に対して、[actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) は空文字列ではなく `None` を返します。これらのタイプは別々に処理してください。前者はマーカーがなく、後者は箇条書き画像を別途抽出する必要があります。画像箇条書きはテキストマーカーだけを抽出して再現することはできません。

## **よくある質問**

**箇条書きリストと番号付きリストは PDF や画像にエクスポートできますか？**

はい。対象の形式が対応するテキストレイアウトと箇条書き機能をサポートしている場合、Aspose.Slides はリストの書式を保持します。

**既存のプレゼンテーションでリストを編集できますか？**

はい。プレゼンテーションを読み込み、対象の段落にアクセスし、その [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) 設定を検査または更新して、プレゼンテーションを保存します。

**リストに非ラテン文字を含めることはできますか？**

はい。リスト項目のテキストは Unicode 文字を含めることができるため、マルチリンガルなプレゼンテーションでリストを作成できます。使用するフォントが必要な文字をサポートしていることを確認してください。