---
title: Python via Java を使用してプレゼンテーションの箇条書きリストと番号付きリストを管理する
linktitle: リストの管理
type: docs
weight: 60
url: /ja/python-java/manage-lists/
keywords:
- 箇条書き
- 箇条書きリスト
- 番号付きリスト
- シンボル箇条書き
- 画像箇条書き
- カスタム箇条書き
- 多層リスト
- 箇条書きの作成
- 箇条書きの追加
- リストの追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint と OpenDocument のプレゼンテーションで箇条書きリスト、画像箇条書き、多層リスト、番号付きリストを作成および書式設定する方法を学びます。"
---
## **概要**

Aspose.Slides for Python via Java を使用すると、PowerPoint および OpenDocument プレゼンテーションで箇条書きリストや番号付きリストを作成および書式設定できます。リスト項目は段落であり、その箇条書き設定は段落の書式設定を通じて制御されます。

段落レベルのリスト設定にアクセスするには、[Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) メソッドを使用します。主なエントリーポイントは [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) で、[BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/) オブジェクトを返します。このオブジェクトを使って、箇条書きの種類、シンボル、画像、色、サイズ、番号付けスタイル、開始番号を設定できます。

本稿では以下を示します。

- カスタムシンボルによる箇条書きリストの作成
- 画像箇条書きの作成
- 段落の深さを設定して多層リストを作成
- 番号付きリストの作成
- 既存のプレゼンテーションでリスト書式を検査および変更する方法
- 段落テキストとともに実際のリストマーカーと番号を取得する方法

## **箇条書きリストの作成**

箇条書きリストを作成するには、[Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) オブジェクトを [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) に追加し、[BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) を [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol) に設定します。その後、[BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar)、[BulletFormat.getColor](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getColor)、[BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) を使用して箇条書きの外観を制御できます。

以下の Python コードは、スライド上に箇条書きリストを作成する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![シンボル箇条書き](symbol_bullets.png)

## **番号付きリストの作成**

項目の順序が重要な場合は、番号付きリストを使用します。[BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) を [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered) に設定します。また、[BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) で番号付け形式を選択したり、リストの開始番号を 1 以外にしたい場合は [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) を使用できます。

以下の Python コードは、スライド上に番号付きリストを作成する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![番号付き箇条書き](numbered_bullets.png)

## **画像箇条書きの作成**

Aspose.Slides では、通常の箇条書きシンボルを画像に置き換えることができます。画像箇条書きは、アイコンや小さな透過 PNG など、サイズが小さくても読みやすいシンプルな画像で最適に機能します。

{{% alert color="info" title="Note" %}}
通常の箇条書きシンボルを画像に置き換える場合は、透過背景を持つシンプルなグラフィックを選んでください。そのような画像はカスタム箇条書きシンボルとしてうまく機能します。

画像は非常に小さいサイズに縮小されます。そのため、リストの箇条書きとして使用したときに鮮明さと視認性を保てる画像を選択することを強く推奨します。
{{% /alert %}}

画像箇条書きを作成するには、[Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) に画像を追加し、返された画像オブジェクトを [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) に割り当てます。画像を割り当てる前に、[BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) を [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture) に設定してください。

例として、"image.png" という名前の画像があるとします。

![箇条書き用の画像](picture_for_bullets.png)

以下の Python コードは、スライド上に画像箇条書きを作成する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![画像箇条書き](picture_bullets.png)

## **多層リストの作成**

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) を使用して、リスト項目を異なるレベルに配置します。レベル 0 が最上位レベル、レベル 1 がその下位にネストされる、といった具合です。

以下の Python コードは、多層箇条書きリストを作成する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![多層リスト](multilevel_list.png)

## **既存リストの変更**

既存のプレゼンテーションでリスト書式を変更するには、対象の段落にアクセスし、[ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) 設定を更新します。リスト作成時に使用したプロパティは、PPT、PPTX、ODP ファイルから読み込んだリストを検査または修正する際にも使用できます。

以下の Python コードは、テキストフレーム内の最初の段落を番号付きリストスタイルに変更します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **実際の箇条書き値の取得**

プレゼンテーションの内容を抽出する際は、リストマーカーを段落テキストとともに保持します。[ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective) を呼び出し、`getBullet` にアクセスして有効な箇条書き書式を取得します。`getType` を確認した上で `getActualBulletValue` を読み取ります。

番号付きリストの場合、次の 3 つの値を区別します。

- `getNumberedBulletStyle` は、例えばピリオド付きのアラビア数字や小文字のアルファベットなど、形式を決定します。
- `getNumberedBulletStartWith` は、番号付き段落のグループの開始番号を指定します。
- `getActualBulletValue` は、特定の段落に対してフォーマットされたマーカーを返します。例として、開始番号が 5 のリストの 2 番目の項目は `6.` を返します。

各段落に対して [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDepth) を保持し、ネストレベルを保持します。実際のマーカーは完全な階層をエンコードしません。ネストされた項目は `c.` のように返すことがあり、`6.c.` のような結合ラベルは返しません。

以下の自己完結型サンプルは、リストを作成しプレゼンテーションに保存した後、プレゼンテーションを再読込みして各段落のテキスト、深さ、箇条書きタイプ、実際の値を報告します。小さな青色の画像マーカーはインライン SVG から作成されています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, SvgImage
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # 外部画像ファイルを使用せずに画像マーカーを作成します。
    svg = SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.getImages().addImage(svg)

    def add_paragraph(text, depth, bullet_type, start, style):
        paragraph = Paragraph()
        paragraph.setText(text)

        paragraph_format = paragraph.getParagraphFormat()
        paragraph_format.setDepth(depth)
        paragraph_format.setMarginLeft(30 + depth * 40)
        paragraph_format.setIndent(-28)
        paragraph_format.setSpaceAfter(8)
        paragraph_format.getDefaultPortionFormat().setFontHeight(22)
        paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        paragraph_format.getBullet().setType(bullet_type)
        paragraph_format.getBullet().setBulletHardColor(NullableBool.True_)
        paragraph_format.getBullet().getColor().setColor(Color.BLACK)
        if bullet_type == BulletType.Numbered:
            paragraph_format.getBullet().setNumberedBulletStyle(style)
            paragraph_format.getBullet().setNumberedBulletStartWith(start)
        elif bullet_type == BulletType.Symbol:
            paragraph_format.getBullet().setChar('\u2022')
        elif bullet_type == BulletType.Picture:
            paragraph_format.getBullet().getPicture().setImage(bullet_image)

        text_frame.getParagraphs().add(paragraph)

    add_paragraph("First item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Second item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod)
    add_paragraph("Back to top level", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Symbol marker", 0, BulletType.Symbol, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("No bullet", 0, BulletType.None_, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Picture marker", 0, BulletType.Picture, 1, NumberedBulletStyle.BulletArabicPeriod)
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

loaded_presentation = Presentation("actual_bullet_values.pptx")
try:
    loaded_shape = loaded_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    type_names = {
        BulletType.Numbered: "Numbered",
        BulletType.Symbol: "Symbol",
        BulletType.None_: "None",
        BulletType.Picture: "Picture",
    }
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.getTextFrame().getParagraphs():
        bullet = paragraph.getParagraphFormat().getEffective().getBullet()
        bullet_type = bullet.getType()
        if bullet_type in (BulletType.Numbered, BulletType.Symbol):
            marker = bullet.getActualBulletValue()
        elif bullet_type == BulletType.None_:
            marker = f"{bullet.getActualBulletValue()} (no bullet)"
        elif bullet_type == BulletType.Picture:
            marker = f"{bullet.getActualBulletValue()} (image required)"
        else:
            marker = "unsupported bullet type"
        type_name = type_names.get(bullet_type, "Unknown")
        print(f"{paragraph.getText()} | {paragraph.getParagraphFormat().getDepth()} | {type_name} | {marker}")
finally:
    loaded_presentation.dispose()
```

ソースリストは以下に示されています。

![5 から開始し、入れ子になった文字とローマ数字の項目、シンボルマーカー、箇条書きなし段落、青い画像マーカーを含むリスト](actual_bullet_values.png)

レポートは PowerPoint に表示されるマーカーと一致します。

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | None (no bullet)
Picture marker | 0 | Picture | None (image required)
```

[BulletType.None_ と BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/) の場合、`getActualBulletValue` は `None`（Java の `null`）を返し、空文字列は返しません。これらのタイプは別々に処理してください：前者はマーカーがなく、後者は箇条書き画像を別途抽出する必要があります。画像箇条書きはテキストマーカーだけを抽出して再現することはできません。

## **FAQ**

**箇条書きおよび番号付きリストは PDF や画像にエクスポートできますか？**

はい。Aspose.Slides は、対象フォーマットが対応するテキストレイアウトおよび箇条書き機能をサポートしている場合、リスト書式を保持します。

**既存のプレゼンテーションでリストを編集できますか？**

はい。プレゼンテーションを読み込み、対象の段落にアクセスし、[ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) 設定を検査または更新して、プレゼンテーションを保存できます。

**リストに非ラテン文字を含めることは可能ですか？**

はい。リスト項目のテキストは Unicode 文字を含めることができるため、多言語プレゼンテーションでリストを作成できます。使用するフォントが必要な文字をサポートしていることを確認してください。