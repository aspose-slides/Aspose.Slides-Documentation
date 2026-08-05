---
title: "Pythonでプレゼンテーションの箇条書きおよび番号付きリストを管理する"
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
  - "記号箇条書き"
  - "画像箇条書き"
  - "カスタム箇条書き"
  - "多層リスト"
  - "箇条書き作成"
  - "箇条書き追加"
  - "リスト追加"
  - "PowerPoint"
  - "OpenDocument"
  - "プレゼンテーション"
  - "Python"
  - "Aspose.Slides"
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションで、箇条書き、画像箇条書き、多層リスト、番号付きリストを作成および書式設定する方法を学びます。"
---
## **概要**

Aspose.Slides for Python via .NET を使用すると、PowerPoint および OpenDocument プレゼンテーションで、箇条書きリストや番号付きリストを作成および書式設定できます。リスト項目は、段落形式で箇条書き設定が制御される段落です。

段落レベルのリスト設定にアクセスするには、[Paragraph.paragraph_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/paragraph_format/) プロパティを使用します。メインエントリーポイントは [ParagraphFormat.bullet](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/bullet/) で、[BulletFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/) オブジェクトが返されます。このオブジェクトを使用して、箇条書きの種類、記号、画像、色、サイズ、番号付スタイル、開始番号を設定できます。

本稿では、以下を示します。

- カスタム記号による箇条書きリストの作成
- 画像箇条書きの作成
- 段落の深さを設定して多層リストを作成
- 番号付きリストの作成
- 既存のプレゼンテーションでリスト書式を検査・変更

## **箇条書きリストの作成**

箇条書きリストを作成するには、[Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) オブジェクトを [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) に追加し、[BulletFormat.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/type/) を [BulletType.SYMBOL](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bullettype/) に設定します。その後、[BulletFormat.char](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/char/)、[BulletFormat.color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/color/)、[BulletFormat.height](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/height/) を設定して箇条書きの外観を制御できます。

以下の Python コードは、スライドで箇条書きリストを作成する方法を示しています。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
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

![記号の箇条書き](symbol_bullets.png)

## **番号付きリストの作成**

項目の順序が重要な場合は、番号付きリストを使用します。[BulletFormat.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/type/) を [BulletType.NUMBERED](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bullettype/) に設定します。また、[BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/numbered_bullet_style/) で番号形式を選択したり、リストの開始番号を 1 以外にしたい場合は [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) を設定できます。

以下の Python コードは、スライドで番号付きリストを作成する方法を示しています。

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

Aspose.Slides では、通常の箇条書き記号を画像に置き換えることができます。画像箇条書きは、小さなサイズでも読みやすいシンプルな画像（アイコンや透明 PNG など）で使用するのが最適です。

{{% alert color="primary" %}}
画像を箇条書き記号として使用する場合、透明な背景を持つシンプルなグラフィックを選択することを推奨します。このような画像はカスタム箇条書き記号として適しています。

画像は非常に小さく縮小されるため、リスト内の箇条書きとして使用しても鮮明で視覚的に効果的な画像を選択することを強く推奨します。
{{% /alert %}}

画像箇条書きを作成するには、[Presentation.images](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/images/) に画像を追加し、返された画像オブジェクトを [BulletFormat.picture](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/picture/) に割り当てます。画像を割り当てる前に、[BulletFormat.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/type/) を [BulletType.PICTURE](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bullettype/) に設定してください。

例として「image.png」を使用します:

![箇条書き用画像](picture_for_bullets.png)

以下の Python コードは、スライドで画像箇条書きを作成する方法を示しています。

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

## **多層リストの作成**

[ParagraphFormat.depth](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/depth/) を使用して、リスト項目を異なるレベルに配置します。レベル 0 が最上位レベル、レベル 1 がその下位にネストされるというように階層化されます。

以下の Python コードは、多層箇条書きリストを作成する方法を示しています。

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

![多層リスト](multilevel_list.png)

## **既存リストの変更**

既存のプレゼンテーションでリスト書式を変更するには、対象の段落にアクセスし、[ParagraphFormat.bullet](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/bullet/) 設定を更新します。リスト作成時に使用したプロパティは、PPT、PPTX、ODP ファイルから読み込んだリストを検査または変更する際にも使用できます。

以下の Python コードは、テキストフレーム内の最初の段落を番号付きリストスタイルに変更します。

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

## **FAQ**

**箇条書きと番号付きリストは PDF や画像にエクスポートできますか？**

はい。Aspose.Slides は、対象フォーマットが対応するテキストレイアウトと箇条書き機能をサポートしている場合、リストの書式を保持します。

**既存のプレゼンテーションでリストを編集できますか？**

はい。プレゼンテーションをロードし、対象の段落にアクセスして、[ParagraphFormat.bullet](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/bullet/) 設定を検査または更新し、プレゼンテーションを保存します。

**リストにラテン文字以外のテキストを含められますか？**

はい。リスト項目のテキストは Unicode 文字を含めることができるため、多言語プレゼンテーションでリストを作成できます。使用するフォントが必要な文字をサポートしていることを確認してください。