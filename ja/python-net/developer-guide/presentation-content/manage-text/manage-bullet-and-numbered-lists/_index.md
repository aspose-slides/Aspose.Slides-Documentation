---
title: Pythonでプレゼンテーションの箇条書きと番号付きリストを管理する
linktitle: リスト管理
type: docs
weight: 70
url: /ja/python-net/manage-bullet-and-numbered-lists/
keywords:
- 箇条書き
- 箇条書きリスト
- 番号付きリスト
- シンボル箇条記号
- 画像箇条記号
- カスタム箇条記号
- 階層リスト
- 箇条記号の作成
- 箇条記号の追加
- リストの追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument のプレゼンテーションで箇条書きおよび番号付きリストを管理する方法を学びます。コード例を交えたステップバイステップのガイドで、すぐに始められます。"
---

## **概要**

インパクトのあるプレゼンテーションを作成する際、箇条書きおよび番号付きリストを効果的に管理することは重要です。Aspose.Slides for Python を使用すれば、スライド内のリスト書式設定をプログラムで簡単に自動化できます。本記事では、Python を使って箇条書きおよび番号付きリストを作成、変更、カスタマイズする方法をわかりやすい例で解説します。インデント、スタイル、番号付けスキーム、箇条記号の制御方法をシンプルかつ強力に学び、プレゼンテーションを常にプロフェッショナルで一貫した見た目にしましょう。

**箇条書きを使用する理由は？**

箇条書きは情報を整理し、明確に提示するのに役立ち、可読性とエンゲージメントを向上させます。通常、箇条書きは次の3つの重要な目的を果たします：

- 重要な情報を強調し、すぐに注意を引きます。
- 読者が素早くスキャンし、主要なポイントを把握できるようにします。
- 簡潔な形式で重要な詳細を効率的に伝えます。

**番号付きリストを使用する理由は？**

番号付きリストは、コンテンツを明確に整理・提示するためのもう一つの有用なツールです。項目の順序や階層が重要な場合に特に役立ちます。手順や項目が特定の順序に従う必要がある場合（例：*ステップ 1、ステップ 2、ステップ 3* など）や、テキスト内で後で特定のステップを参照する必要がある場合（例：*ステップ 3 を参照*）に、箇条書きの代わりに番号付きリストを使用します。これにより、指示や説明がより明確で追従しやすくなり、読者がコンテンツを容易にナビゲートし参照できるようになります。

## **シンボル箇条記号の作成**

箇条書きリストを作成するには、以下の手順に従います：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドコレクションから、[ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) オブジェクトを使用して、箇条書きリストを追加したいスライドにアクセスします。
1. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。
1. テキストフレーム内のデフォルトの段落を削除します。
1. 最初の段落を [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) クラスを使用して作成します。
1. 箇条記号の種類を `SYMBOL` に設定し、記号文字を定義します。
1. 段落テキストを設定します。
1. 段落インデントを設定して箇条記号の位置を制御します。
1. 箇条記号の色を設定します。
1. 箇条記号の高さを設定します。
1. 作成した段落をテキストフレームの段落コレクションに追加します。
1. 2番目の段落を追加し、手順 7～12 を繰り返します。
1. プレゼンテーションを保存します。

以下の Python コードは、スライドに箇条書きリストを作成する方法を示しています：
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


結果：

![シンボル箇条記号](symbol_bullets.png)

## **画像箇条記号の作成**

Aspose.Slides for Python via .NET を使用すると、箇条書きリストの箇条記号をカスタマイズできます。標準の箇条記号をカスタムシンボルや画像に置き換えることができます。リストに視覚的な興味を加えたり、特定の項目に注目させたい場合は、独自の画像を箇条記号として使用できます。

{{% alert color="primary" %}}
理想的には、通常の箇条記号を画像に置き換える場合、透明な背景を持つシンプルなグラフィックを選択するのが最適です。そのような画像はカスタム箇条記号としてうまく機能します。

画像は非常に小さなサイズに縮小されることに留意してください。そのため、リストの箇条記号として使用した際にも鮮明で視覚的に効果的な画像を選択することを強く推奨します。
{{% /alert %}}

画像箇条記号を作成するには、以下の手順に従います：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドコレクションから、[ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) オブジェクトを使用して、箇条書きリストを追加したいスライドにアクセスします。
1. `add_auto_shape` メソッドを使用して、選択したスライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。
1. テキストフレームからデフォルトの段落を削除します。
1. ディスクから画像をロードし、[Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/) に追加し、[add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/#methods) メソッドが返す [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) インスタンスを取得します。
1. 最初の段落を [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) クラスを使用して作成します。
1. 箇条記号の種類を `PICTURE` に設定し、画像を割り当てます。
1. 段落テキストを設定します。
1. 段落インデントを設定して箇条記号の位置を調整します。
1. 箇条記号の色を設定します。
1. 箇条記号の高さを設定します。
1. 段落をテキストフレームの段落コレクションに追加します。
1. 2番目の段落を追加し、手順 8～13 を繰り返します。
1. プレゼンテーションを保存します。

ここでは "image.png" があるとします：

![箇条記号用の画像](picture_for_bullets.png)

以下の Python コードは、スライドに画像箇条記号を作成する方法を示しています：
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


結果：

![画像箇条記号](picture_bullets.png)

## **階層リストの作成**

複数レベル（メインの箇条書きの下にサブリスト）の項目を含む箇条書きリストを作成するには、以下の手順に従います：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドコレクションから、[ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) オブジェクトを使用して、箇条書きリストを追加したいスライドにアクセスします。
1. `add_auto_shape` メソッドを使用して、選択したスライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。
1. テキストフレームからデフォルトの段落を削除します。
1. [Paragraph] インスタンスを最初に作成し、その深さを 0（メインレベル）に設定します。
1. 2番目の段落を作成し、深さを 1（第1サブレベル）に設定します。
1. 3番目の段落を作成し、深さを 2（第2サブレベル）に設定します。
1. 4番目の段落を作成し、深さを 3（第3サブレベル）に設定します。
1. 作成したすべての段落をテキストフレームの段落コレクションに追加します。
1. プレゼンテーションを保存します。

以下の Python コードは、多層箇条書きリストを作成する方法を示しています：
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


結果：

![多層リスト](multilevel_list.png)

## **番号付き箇条記号の作成**

明確で整理された番号付きリストの作成は、Aspose.Slides for Python で簡単に行えます。番号付きリストは可読性を大幅に向上させ、ステップや順序付き情報を観客に明確に導くのに役立ちます。教育用スライドの作成、プロセスの文書化、プレゼンテーションのアウトライン作成など、番号付きリストはメッセージを構造化し、わかりやすく保つことができます。

Aspose.Slides を使用すれば、プログラムで番号付きリストを簡単に追加、カスタマイズ、書式設定できます。数値 (1, 2, 3) やアルファベット (A, B, C)、ローマ数字 (I, II, III) など、さまざまな番号付スタイルを指定して、プレゼンテーションの文脈や希望するスタイルに合わせることができます。

以下の Python コードは、スライドに番号付きリストを作成する方法を示しています：
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


結果：

![番号付き箇条記号](numbered_bullets.png)

## **よくある質問**

**Aspose.Slidesで作成した箇条書きおよび番号付きリストは、PDFや画像などの他の形式にエクスポートできますか？**

はい、Aspose.Slides は、PDF、画像などの形式にプレゼンテーションをエクスポートする際、箇条書きおよび番号付きリストの書式と構造を完全に保持し、一貫した結果を保証します。

**既存のプレゼンテーションから箇条書きや番号付きリストをインポートできますか？**

はい、Aspose.Slides は既存のプレゼンテーションから箇条書きや番号付きリストをインポートして編集でき、元の書式や外観を保持します。

**Aspose.Slides は、多言語で作成されたプレゼンテーションの箇条書きや番号付きリストをサポートしていますか？**

はい、Aspose.Slides は多言語プレゼンテーションを完全にサポートし、任意の言語で箇条書きや番号付きリストを作成でき、特殊文字や非ラテン文字も使用可能です。