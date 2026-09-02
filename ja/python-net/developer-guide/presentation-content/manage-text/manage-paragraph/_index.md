---
title: Python で PowerPoint のテキスト段落を管理
linktitle: 段落の管理
type: docs
weight: 40
url: /ja/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- テキスト追加
- 段落追加
- テキスト管理
- 段落管理
- 箇条書き管理
- 段落インデント
- ハンギングインデント
- 段落箇条書き
- 番号リスト
- 箇条書きリスト
- 段落プロパティ
- HTML インポート
- テキストから HTML へ
- 段落から HTML へ
- 段落から画像へ
- テキストから画像へ
- 段落エクスポート
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python（.NET）を使用して段落の書式設定をマスターし、PowerPoint や OpenDocument のプレゼンテーションで配置、間隔、スタイルを最適化して、視聴者の関心を引きつけます。"
---
## **概要**

Aspose.Slides は、Python で PowerPoint のテキストを操作するために必要なクラスを提供します。

* Aspose.Slides はテキスト フレーム オブジェクトを作成するための [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) クラスを提供します。`TextFrame` オブジェクトは 1 つ以上の段落を含めることができ（各段落は改行で区切られます）。
* Aspose.Slides は段落オブジェクトを作成するための [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) クラスを提供します。`Paragraph` オブジェクトは 1 つ以上のテキスト部分（Portion）を含めることができます。
* Aspose.Slides はテキスト部分オブジェクトを作成し、その書式プロパティを指定するための [Portion](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/) クラスを提供します。

`Paragraph` オブジェクトは、基になる `Portion` オブジェクトを通じて異なる書式プロパティを持つテキストを処理できます。

## **インストール**

```bash
pip install aspose.slides
```

## **複数の段落に複数のポーションを含める**

以下の手順では、3 つの段落を持ち、各段落に 3 つのポーションが含まれるテキスト フレームの追加方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスで対象のスライドへの参照を取得します。
1. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) に関連付けられた [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) を取得します。
1. 2 つの [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) オブジェクトを作成し、[TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) の段落コレクションに追加します（デフォルトの段落と合わせて、合計で 3 段落になります）。
1. 各段落につき 3 つの [Portion](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/) オブジェクトを作成し、その段落のポーション コレクションに追加します。
1. 各ポーションのテキストを設定します。
1. [Portion](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/) が提供するプロパティを使用して、各テキスト ポーションに必要な書式を適用します。
1. 変更したプレゼンテーションを保存します。

以下の Python コードがこれらの手順を実装しています。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成し、新しい PPTX ファイルを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 矩形の AutoShape を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # AutoShape の TextFrame にアクセスします。
    text_frame = shape.text_frame

    # 段落とポーションを作成します；書式設定は以下で適用されます。
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # PPTX をディスクに保存します。
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **段落の箇条書きの管理**

箇条書きリストは情報を迅速かつ効率的に整理・提示するのに役立ちます。箇条書きされた段落は、読みやすく理解しやすいことが多いです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスで対象スライドにアクセスします。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. 形状の [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) からデフォルトの段落を削除します。
1. [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) クラスを使用して最初の段落を作成します。
1. 段落の箇条書きタイプを `SYMBOL` に設定し、箇条書き文字を指定します。
1. 段落のテキストを設定します。
1. 段落の箇条書きインデントを設定します。
1. 箇条書きの色を設定します。
1. 箇条書きのサイズ（高さ）を設定します。
1. [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) の段落コレクションに段落を追加します。
1. 2 番目の段落を追加し、手順 7〜12 を繰り返します。
1. プレゼンテーションを保存します。

以下の Python コードは、箇条書き段落の追加方法を示しています。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーションインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # AutoShape を追加してアクセスします。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 作成した AutoShape のテキスト フレームにアクセスします。
    text_frame = shape.text_frame

    # デフォルトの段落を削除します。
    text_frame.paragraphs.remove_at(0)

    # 段落を作成します。
    paragraph = slides.Paragraph()

    # 段落の箇条書きスタイルとシンボルを設定します。
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # 段落のテキストを設定します。
    paragraph.text = "Welcome to Aspose.Slides"

    # 箇条書きのインデントを設定します。
    paragraph.paragraph_format.indent = 25

    # 箇条書きの色を設定します。
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # 箇条書きの高さを設定します。
    paragraph.paragraph_format.bullet.height = 100

    # 段落をテキスト フレームに追加します。
    text_frame.paragraphs.add(paragraph)

    # 2 番目の段落を作成します。
    paragraph2 = slides.Paragraph()

    # 段落の箇条書きタイプとスタイルを設定します。
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN

    # 段落のテキストを設定します。
    paragraph2.text = "This is numbered bullet"

    # 箇条書きのインデントを設定します。
    paragraph2.paragraph_format.indent = 25

    # 箇条書きの色を設定します。
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # 箇条書きの高さを設定します。
    paragraph2.paragraph_format.bullet.height = 100

    # 段落をテキスト フレームに追加します。
    text_frame.paragraphs.add(paragraph2)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **画像箇条書きの管理**

箇条書きリストは情報を迅速かつ効率的に整理・提示するのに役立ちます。画像箇条書きは読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスで対象スライドにアクセスします。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. 形状の [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) からデフォルトの段落を削除します。
1. [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) クラスを使用して段落を作成し、テキストを設定します。
1. 画像を読み込み、プレゼンテーションの画像コレクションに [PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) として追加します。
1. 箇条書きタイプを `PICTURE` に設定し、[PPImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ppimage/) を箇条書きに割り当てます。
1. 箇条書きの高さを設定します。
1. 新しい段落を [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) の段落コレクションに追加します。
1. プレゼンテーションを保存します。

以下の Python コードは、画像箇条書きの追加と管理方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 箇条書き画像を読み込みます。
    with slides.Images.from_file("bullets.png") as image:
        pp_image = presentation.images.add_image(image)

    # AutoShape を追加してアクセスします。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 作成した AutoShape の TextFrame にアクセスします。
    text_frame = auto_shape.text_frame

    # デフォルトの段落を削除します。
    text_frame.paragraphs.remove_at(0)

    # 新しい段落を作成します。
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # 段落の箇条書きタイプを Picture に設定し、画像を割り当てます。
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # 箇条書きの高さを設定します。
    paragraph.paragraph_format.bullet.height = 100

    # 段落をテキスト フレームに追加します。
    text_frame.paragraphs.add(paragraph)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # プレゼンテーションを PPT ファイルとして保存します。
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **階層付き箇条書きの管理**

箇条書きリストは情報を迅速かつ効率的に整理・提示するのに役立ちます。階層付き箇条書きは読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスで対象スライドにアクセスします。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) の [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) からデフォルトの段落を削除します。
1. [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) クラスを使用して最初の段落を作成し、depth を 0 に設定します。
1. 同クラスで 2 番目の段落を作成し、depth を 1 に設定します。
1. 同クラスで 3 番目の段落を作成し、depth を 2 に設定します。
1. 同クラスで 4 番目の段落を作成し、depth を 3 に設定します。
1. 新しい段落を [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) の段落コレクションに追加します。
1. プレゼンテーションを保存します。

以下の Python コードは、階層付き箇条書きの追加と管理方法を示しています。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーションインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]
    
    # AutoShape を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 作成した AutoShape の TextFrame にアクセスします。
    text_frame = shape.text_frame
    
    # デフォルトの段落をクリアします。
    text_frame.paragraphs.clear()

    # 最初の段落を追加します。
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 箇条書きレベルを設定します。
    paragraph1.paragraph_format.depth = 0

    # 2 番目の段落を追加します。
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 箇条書きレベルを設定します。
    paragraph2.paragraph_format.depth = 1

    # 3 番目の段落を追加します。
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 箇条書きレベルを設定します。
    paragraph3.paragraph_format.depth = 2

    # 4 番目の段落を追加します。
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 箇条書きレベルを設定します。
    paragraph4.paragraph_format.depth = 3

    # 段落をコレクションに追加します。
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **カスタム番号付きリストで段落を管理**

[BulletFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/bulletformat/) クラスは、段落のカスタム番号付けと書式設定を制御するための `numbered_bullet_start_with` プロパティ（他にも多数）を提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 段落を配置するスライドにアクセスします。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. 形状の [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) からデフォルトの段落を削除します。
1. 最初の [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) を作成し、`numbered_bullet_start_with` を 2 に設定します。
1. 2 番目の [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) を作成し、`numbered_bullet_start_with` を 3 に設定します。
1. 3 番目の [Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) を作成し、`numbered_bullet_start_with` を 7 に設定します。
1. 段落を [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) のコレクションに追加します。
1. プレゼンテーションを保存します。

以下の Python コードは、カスタム番号付けと書式設定を伴う段落の追加と管理方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # AutoShape を追加してアクセスします。
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 作成した AutoShape の TextFrame にアクセスします。
    text_frame = shape.text_frame

    # デフォルトの既存段落を削除します。
    text_frame.paragraphs.remove_at(0)

    # 最初の番号付き項目を作成します（開始番号 2、深さレベル 4）。
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # 2 番目の番号付き項目を作成します（開始番号 3、深さレベル 4）。
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # 3 番目の番号付き項目を作成します（開始番号 7、深さレベル 4）。
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **段落の先頭行インデントを設定**

[ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) プロパティを使用して段落の先頭行インデントを制御します。このプロパティは段落の左余白に対して最初の行だけを移動させます。正の値は先頭行を右にシフトし、残りの行は段落本文に合わせた位置に残ります。

段落全体を移動させたい場合は [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/margin_left/) を使用します。先頭行だけを移動させたい場合は [ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) を使用します。

以下の例では、複数の段落を作成し、異なる `indent` 値を適用して、先頭行インデントが段落のレイアウトに与える影響を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象のスライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
4. 形状に空の [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) を追加し、デフォルトの段落を削除します。
5. 複数の段落を作成し、[indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) の異なる値を設定します。
6. 段落をテキスト フレームに追加します。
7. 変更したプレゼンテーションを保存します。

このコードは段落インデントの設定方法を示しています。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![段落の先頭行インデント](first_line_indent.png)

## **段落のハンギングインデントを設定**

ハンギングインデントは、最初の行が残りの行より左側から始まる段落レイアウトです。Aspose.Slides では、[ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) プロパティを使用してこの効果を作り出します。`indent` を負の値に設定すると、段落本文に対して最初の行が左に移動します。

実際には、[ParagraphFormat.margin_left](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/margin_left/) が段落本文の左位置を定義し、[ParagraphFormat.indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、正の `margin_left` 値と負の `indent` 値を設定します。

この書式は、文献リスト、参考文献、用語集エントリなど、折り返し行が段落本文の下に揃う必要がある段落で便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象のスライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
4. 形状に空の [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) を追加し、デフォルトの段落を削除します。
5. 各段落に対して正の [margin_left](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/margin_left/) 値を設定します。
6. ハンギングインデント効果を作るために負の [indent](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/indent/) 値を設定します。
7. 段落をテキスト フレームに追加します。
8. 変更したプレゼンテーションを保存します。

このコードは段落のハンギングインデントの設定方法を示しています。

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![段落のハンギングインデント](hanging_indent.png)

## **段落末端のポーション書式を管理**

段落の「末端」（最後のテキスト ポーションの後に適用される書式）を制御する必要がある場合は、`end_paragraph_portion_format` プロパティを使用します。以下の例では、2 番目の段落の末端に大きめの Times New Roman フォントを適用しています。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) ファイルを作成または開きます。
1. インデックスで対象スライドを取得します。
1. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. 形状の [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) を使用し、2 つの段落を作成します。
1. 48 pt の Times New Roman に設定した [PortionFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portionformat/) を作成し、段落の末端ポーション書式として適用します。
1. それを段落の `end_paragraph_portion_format` に割り当てます（2 番目の段落の末端に適用）。
1. 修正したプレゼンテーションを書き出して PPTX ファイルに保存します。

この Python コードは、2 番目の段落に対して段落末端の書式を設定する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	# デフォルトの段落を削除します。
	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **HTML テキストを段落にインポート**

Aspose.Slides は、HTML テキストを段落にインポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスで対象スライドにアクセスします。
1. スライドに [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加します。
1. [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) の [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) からデフォルトの段落を削除します。
1. ソースの HTML ファイルを読み込みます。
1. HTML コンテンツを [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) の段落コレクションに追加します。
1. 変更したプレゼンテーションを保存します。

以下の Python コードは、HTML テキストを段落にインポートする手順を実装しています。

```python
import aspose.slides as slides

# 空の Presentation インスタンスを作成します。
with slides.Presentation() as presentation:

    # プレゼンテーションの最初のスライドにアクセスします。
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # HTML コンテンツを収容するために AutoShape を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # 追加されたテキスト フレームのすべての段落をクリアします。
    shape.text_frame.paragraphs.clear()

    # HTML ファイルを読み込みます。
    with open("file.html", "rt") as html_stream:
        # HTML ファイルからテキストをテキスト フレームに追加します。
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # プレゼンテーションを保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **段落テキストを HTML にエクスポート**

Aspose.Slides は、テキストを HTML にエクスポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、対象のプレゼンテーションをロードします。
1. インデックスで目的のスライドにアクセスします。
1. エクスポートするテキストを含む形状を選択します。
1. 形状の [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。
1. HTML 出力を書き込むためにファイルストリームを開き、開始インデックスを指定して必要な段落をエクスポートします。

この Python の例は、段落テキストを HTML にエクスポートする方法を示しています。

```python
import aspose.slides as slides

# プレゼンテーション ファイルを読み込みます。
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # プレゼンテーションの最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 対象シェイプのインデックス。
    index = 0

    # インデックスでシェイプにアクセスします。
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # エクスポートする開始段落インデックスと総段落数を指定して、段落データを HTML に書き込みます。
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **段落を画像として保存**

このセクションでは、[Paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraph/) クラスで表現されるテキスト段落を画像として保存する 2 つの例を解説します。どちらの例も、[Shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/) クラスの `get_image` メソッドで段落を含むシェイプの画像を取得し、シェイプ内での段落の境界を計算してビットマップ画像としてエクスポートします。この手法により、PowerPoint プレゼンテーションからテキストの特定部分を抽出し、別個の画像として保存でき、さまざまなシナリオでの再利用が可能になります。

サンプルとして、sample.pptx という名前のプレゼンテーション ファイルが 1 枚のスライドを持ち、最初のシェイプが 3 段落を含むテキスト ボックスであると想定します。

![3 段落を含むテキスト ボックス](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。まずプレゼンテーションの最初のスライドからシェイプの画像を抽出し、次にシェイプのテキスト フレーム内で 2 番目の段落の境界を計算します。その後、段落を新しいビットマップ画像に再描画し、PNG 形式で保存します。この方法は、特定の段落を別画像として保存しつつ、テキストの正確な寸法と書式を保持したい場合に特に有用です。

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # 形状をメモリ内でビットマップとして保存します。
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # メモリからシェイプのビットマップを作成します。
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # 2 番目の段落の境界を計算します。
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # 出力画像の座標とサイズを計算します（最小サイズ - 1x1 ピクセル）。
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # シェイプのビットマップをトリミングして段落のビットマップだけを取得します。
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

結果：

![段落画像](paragraph_to_image_output.png)

**例 2**

この例では、前述のアプローチにスケーリング係数を加えて拡張します。シェイプを抽出し、スケール係数 `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が得られます。段落の境界はスケールを考慮して計算されます。高解像度画像が必要な場合、例えば高品質な印刷物での使用などに特に有用です。

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # 形状をメモリ内でビットマップとして保存します。
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # メモリからシェイプのビットマップを作成します。
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # 2 番目の段落の境界を計算します。
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # 出力画像の座標とサイズを計算します（最小サイズ - 1x1 ピクセル）。
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # シェイプのビットマップをトリミングして段落のビットマップだけを取得します。
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **よくある質問**

### テキスト フレーム内での改行を完全に無効にできますか？

はい。テキスト フレームの折り返し設定（[wrap_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/wrap_text/)）を使用して折り返しをオフにすれば、フレームの端で行が折り返されなくなります。

### 特定の段落のスライド上での正確な境界を取得するには？

段落（あるいは単一のポーション）のバウンディング矩形を取得することで、スライド上での正確な位置とサイズを知ることができます。

### 段落の配置（左揃え/右揃え/中央揃え/両端揃え）はどこで設定しますか？

[Alignment](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/alignment/) は [ParagraphFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/) の段落レベルの設定で、個々のポーションの書式設定に関係なく段落全体に適用されます。

### 段落の一部（例: 単語）だけにスペルチェック言語を設定できますか？

はい。言語はポーションレベル（[PortionFormat.language_id](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portionformat/language_id/)）で設定されるため、1 つの段落内で複数の言語を併存させることができます。