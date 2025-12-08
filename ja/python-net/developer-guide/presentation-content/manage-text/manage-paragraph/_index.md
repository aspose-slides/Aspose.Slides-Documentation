---
title: Python で PowerPoint のテキスト段落を管理する
linktitle: 段落の管理
type: docs
weight: 40
url: /ja/python-net/manage-paragraph/
keywords:
- テキストの追加
- 段落の追加
- テキストの管理
- 段落の管理
- 箇条書きの管理
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
description: "Aspose.Slides for Python (via .NET) を使用して段落の書式設定をマスターし、Python で PowerPoint と OpenDocument プレゼンテーションの配置、間隔、スタイルを最適化して視聴者を引き付けます。"
---

## **概要**

Aspose.Slides は、Python で PowerPoint のテキストを操作するために必要なクラスを提供します。

* Aspose.Slides は、テキストフレームオブジェクトを作成するための [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) クラスを提供します。`TextFrame` オブジェクトは、1 つ以上の段落を含むことができ（各段落は改行で区切られます）。
* Aspose.Slides は、段落オブジェクトを作成するための [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) クラスを提供します。`Paragraph` オブジェクトは、1 つ以上のテキストポーションを含むことができます。
* Aspose.Slides は、テキストポーションオブジェクトを作成し、その書式プロパティを指定するための [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) クラスを提供します。

`Paragraph` オブジェクトは、基礎となる `Portion` オブジェクトを介して、異なる書式プロパティを持つテキストを扱うことができます。

## **複数のポーションを含む複数の段落を追加する**

この手順は、3 つの段落を持ち、各段落に 3 つのポーションが含まれるテキストフレームを追加する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスで対象のスライドへの参照を取得します。  
1. スライドに長方形の [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。  
1. [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) に関連付けられた [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) を取得します。  
1. 2 つの [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) オブジェクトを作成し、[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) の段落コレクションに追加します（デフォルトの段落と合わせて合計 3 段落になります）。  
1. 各段落について、3 つの [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) オブジェクトを作成し、その段落のポーションコレクションに追加します。  
1. 各ポーションにテキストを設定します。  
1. 必要に応じて、[Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) が公開するプロパティを使用して各テキストポーションの書式を適用します。  
1. 変更されたプレゼンテーションを保存します。

以下の Python コードがこれらの手順を実装しています:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

    # Presentation クラスのインスタンスを作成して新しい PPTX ファイルを生成します。
    with slides.Presentation() as presentation:

        # 最初のスライドにアクセスします。
        slide = presentation.slides[0]

        # 四角形の AutoShape を追加します。
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

        # AutoShape の TextFrame にアクセスします。
        text_frame = shape.text_frame

        # 段落とポーションを作成します。書式設定は以下で適用されます。
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
                    text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                    text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
                elif j == 1:
                    text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                    text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                    text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                    text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

        # PPTX をディスクに保存します。
        presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```


## **段落の箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。箇条書き段落は、読みやすく理解しやすいことが多いです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスで対象のスライドにアクセスします。  
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。  
1. シェイプの [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。  
1. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) からデフォルトの段落を削除します。  
1. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) クラスを使用して最初の段落を作成します。  
1. 段落の `bullet_type` を `SYMBOL` に設定し、箇条書き文字を指定します。  
1. 段落のテキストを設定します。  
1. 段落のインデントを設定します。  
1. 箇条書きの色を設定します。  
1. 箇条書きのサイズ（高さ）を設定します。  
1. 段落を [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) の段落コレクションに追加します。  
1. 2 番目の段落を追加し、手順 7–12 を繰り返します。  
1. プレゼンテーションを保存します。

この Python コードは、箇条書き段落を追加する方法を示しています:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーション インスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # AutoShape を追加してアクセスします。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 作成した AutoShape のテキストフレームにアクセスします。
    text_frame = shape.text_frame

    # デフォルトの段落を削除します。
    text_frame.paragraphs.remove_at(0)

    # 段落を作成します。
    paragraph = slides.Paragraph()

    # 段落の箇条書きスタイルと記号を設定します。
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # 段落のテキストを設定します。
    paragraph.text = "Welcome to Aspose.Slides"

    # 箇条書きのインデントを設定します。
    paragraph.paragraph_format.indent = 25

    # 箇条書きの色を設定します。
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # 箇条書きの高さを設定します。
    paragraph.paragraph_format.bullet.height = 100

    # 段落をテキストフレームに追加します。
    text_frame.paragraphs.add(paragraph)

    # 2 番目の段落を作成します。
    paragraph2 = slides.Paragraph()

    # 段落の箇条書きタイプとスタイルを設定します。
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # 段落のテキストを設定します。
    paragraph2.text = "This is numbered bullet"

    # 箇条書きのインデントを設定します。
    paragraph2.paragraph_format.indent = 25

    # 箇条書きの色を設定します。
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # 箇条書きの高さを設定します。
    paragraph2.paragraph_format.bullet.height = 100

    # 段落をテキストフレームに追加します。
    text_frame.paragraphs.add(paragraph2)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **画像箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。画像箇条書きは読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスで対象のスライドにアクセスします。  
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。  
1. シェイプの [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。  
1. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) からデフォルトの段落を削除します。  
1. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) クラスを使用して最初の段落を作成します。  
1. [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) に画像を読み込みます。  
1. 箇条書きのタイプを [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) に設定し、画像を割り当てます。  
1. 段落のテキストを設定します。  
1. 箇条書きのインデントを段落に設定します。  
1. 箇条書きの色を設定します。  
1. 箇条書きの高さを設定します。  
1. 新しい段落を [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) の段落コレクションに追加します。  
1. 2 番目の段落を追加し、手順 8–12 を繰り返します。  
1. プレゼンテーションを保存します。

この Python コードは、画像箇条書きを追加および管理する方法を示しています:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 箇条書き画像を読み込みます。
    image = draw.Bitmap("bullets.png")
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

    # 段落をテキストフレームに追加します。
    text_frame.paragraphs.add(paragraph)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # プレゼンテーションを PPT ファイルとして保存します。
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```


## **多層箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。多層箇条書きは読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスで対象のスライドにアクセスします。  
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。  
1. [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) の [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。  
1. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) からデフォルトの段落を削除します。  
1. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) クラスを使用して最初の段落を作成し、その depth を 0 に設定します。  
1. 同様に、depth を 1 に設定した第2段落を作成します。  
1. 同様に、depth を 2 に設定した第3段落を作成します。  
1. 同様に、depth を 3 に設定した第4段落を作成します。  
1. 新しい段落を [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) の段落コレクションに追加します。  
1. プレゼンテーションを保存します。

以下の Python コードが、多層箇条書きを追加および管理する方法を示しています:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーション インスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]
    
    # AutoShape を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 作成した AutoShape の TextFrame にアクセスします。
    text_frame = auto_shape.text_frame
    
    # デフォルトの段落をクリアします。
    text_frame.paragraphs.clear()

    # 最初の段落を追加します。
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 箇条書きのレベルを設定します。
    paragraph1.paragraph_format.depth = 0

    # 2 番目の段落を追加します。
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 箇条書きのレベルを設定します。
    paragraph2.paragraph_format.depth = 1

    # 3 番目の段落を追加します。
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 箇条書きのレベルを設定します。
    paragraph3.paragraph_format.depth = 2

    # 4 番目の段落を追加します。
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 箇条書きのレベルを設定します。
    paragraph4.paragraph_format.depth = 3

    # 段落をコレクションに追加します。
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **カスタム番号付きリスト付き段落の管理**

[BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) クラスは、`numbered_bullet_start_with` プロパティ（他にも多数）を提供し、段落のカスタム番号付けと書式設定を制御できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. 段落を配置するスライドにアクセスします。  
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。  
1. シェイプの [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。  
1. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) からデフォルトの段落を削除します。  
1. 最初の [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) を作成し、`numbered_bullet_start_with` を 2 に設定します。  
1. 2 番目の [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) を作成し、`numbered_bullet_start_with` を 3 に設定します。  
1. 3 番目の [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) を作成し、`numbered_bullet_start_with` を 7 に設定します。  
1. これらの段落を [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) のコレクションに追加します。  
1. プレゼンテーションを保存します。

以下の Python コードが、カスタム番号付けと書式設定を持つ段落の追加と管理を示します。
```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # AutoShape を追加してアクセスします。
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 作成した AutoShape の TextFrame にアクセスします。
    text_frame = shape.text_frame

    # 既存のデフォルト段落を削除します。
    text_frame.paragraphs.remove_at(0)

    # 最初の番号付き項目を作成します (開始番号 2、レベル 4)。
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # 2 番目の番号付き項目を作成します (開始番号 3、レベル 4)。
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # 3 番目の番号付き項目を作成します (開始番号 7、レベル 4)。
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **段落インデントの設定**

段落インデントは、スライド上での読みやすい階層構造を確立し、テキスト配置を微調整するのに役立ちます。以下の例は、[ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) のプロパティを使用して、全体インデントと最初の行インデントの両方を設定する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスで対象のスライドにアクセスします。  
1. スライドに長方形の [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。  
1. [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) に 3 つの段落を持つ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) を追加します。  
1. 長方形のアウトラインを非表示にします。  
1. 各 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) の `paragraph_format` プロパティを使用してインデントを設定します。  
1. 修正されたプレゼンテーションを PPT ファイルとして保存します。

以下の Python コードが段落インデントの設定方法を示します:
```python
import aspose.slides as slides

# Presentation クラスのインスタンスを生成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 四角形のシェイプを追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # 四角形に TextFrame を追加します。
    text_frame = shape.add_text_frame("This is first line \rThis is second line \rThis is third line")

    # テキストをシェイプに合わせて自動調整します。
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # 四角形の外枠を実線に設定します。
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    # TextFrame の最初の段落を取得し、箇条書きとインデントを設定します。
    paragraph1 = text_frame.paragraphs[0]
    # 段落の箇条書きスタイルと記号を設定します。
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.alignment = slides.TextAlignment.LEFT

    paragraph1.paragraph_format.depth = 2
    paragraph1.paragraph_format.indent = 30

    # TextFrame の2番目の段落を取得し、箇条書きとインデントを設定します。
    paragraph2 = text_frame.paragraphs[1]
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = chr(8226)
    paragraph2.paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph2.paragraph_format.depth = 2
    paragraph2.paragraph_format.indent = 40

    # TextFrame の3番目の段落を取得し、箇条書きとインデントを設定します。
    paragraph3 = text_frame.paragraphs[2]
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph3.paragraph_format.depth = 2
    paragraph3.paragraph_format.indent = 50

    # プレゼンテーションをディスクに保存します。
    presentation.save("indent_out.pptx", slides.export.SaveFormat.PPTX)
```


## **段落のハンギングインデントの設定**

この Python コードは、段落にハンギングインデントを設定する方法を示します:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 550, 150)

    paragraph1 = slides.Paragraph()
    paragraph1.text = "Example"
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Set Hanging Indent for Paragraphs"
    paragraph3 = slides.Paragraph()
    paragraph3.text = "This Python code shows how to set a hanging indent for a paragraph: "

    paragraph2.paragraph_format.margin_left = 10
    paragraph3.paragraph_format.margin_left = 20

    paragraphs = auto_shape.text_frame.paragraphs
    paragraphs.add(paragraph1)
    paragraphs.add(paragraph2)
    paragraphs.add(paragraph3)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **段落末尾ポーション書式の管理**

段落の「末尾」（最後のテキストポーションの後に適用される書式）を制御する必要がある場合は、`end_paragraph_portion_format` プロパティを使用します。以下の例は、2 番目の段落の末尾に大きな Times New Roman フォントを適用しています。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ファイルを作成または開きます。  
1. インデックスで対象のスライドを取得します。  
1. スライドに長方形の [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。  
1. シェイプの [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) を使用し、2 つの段落を作成します。  
1. 48pt の Times New Roman に設定した [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) を作成し、段落の末尾ポーション書式として適用します。  
1. それを段落の `end_paragraph_portion_format` に割り当てます（2 番目の段落の末尾に適用）。  
1. 修正されたプレゼンテーションを PPTX ファイルとして書き出します。

この Python コードは、2 番目の段落に対して段落末尾書式を設定する方法を示します:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

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


## **HTML テキストを段落にインポートする**

Aspose.Slides は、HTML テキストを段落にインポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスで対象のスライドにアクセスします。  
1. スライドに [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。  
1. [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) の [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。  
1. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) からデフォルトの段落を削除します。  
1. ソースの HTML ファイルを読み取ります。  
1. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) クラスを使用して最初の段落を作成します。  
1. HTML コンテンツを [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) の段落コレクションに追加します。  
1. 修正されたプレゼンテーションを保存します。

以下の Python コードが、HTML テキストを段落にインポートする手順を実装しています。
```python
import aspose.slides as slides

# 空の Presentation インスタンスを作成します。
with slides.Presentation() as presentation:

    # プレゼンテーションの最初のスライドにアクセスします。
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # HTML コンテンツを収める AutoShape を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # 追加したテキストフレームのすべての段落をクリアします。
    shape.text_frame.paragraphs.clear()

    # HTML ファイルを読み込みます。
    with open("file.html", "rt") as html_stream:
        # HTML ファイルからテキストをテキストフレームに追加します。
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # プレゼンテーションを保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **段落テキストを HTML にエクスポートする**

Aspose.Slides は、テキストを HTML にエクスポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、対象のプレゼンテーションを読み込みます。  
1. インデックスで目的のスライドにアクセスします。  
1. エクスポートするテキストを含むシェイプを選択します。  
1. シェイプの [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。  
1. HTML 出力を書き込むためにファイルストリームを開きます。  
1. 開始インデックスを指定し、必要な段落をエクスポートします。

この Python の例は、段落テキストを HTML にエクスポートする方法を示します。
```python
import aspose.slides as slides

# プレゼンテーションファイルをロードします。
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


## **段落を画像として保存する**

このセクションでは、[Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) クラスで表されるテキスト段落を画像として保存する 2 つの例を紹介します。どちらの例も、段落を含むシェイプの画像を取得するために [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスの `get_image` メソッドを使用し、シェイプ内の段落の境界を計算し、ビットマップ画像としてエクスポートします。これらの方法により、PowerPoint プレゼンテーションからテキストの特定部分を抽出し、別々の画像として保存でき、さまざまなシナリオでの再利用が可能になります。

サンプルとして、sample.pptx というファイルに 1 つのスライドがあり、最初のシェイプが 3 つの段落を含むテキスト ボックスであるとします。

![The text box with three paragraphs](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。そのために、プレゼンテーションの最初のスライドからシェイプの画像を抽出し、シェイプのテキストフレーム内の 2 番目の段落の境界を計算します。次に、段落を新しいビットマップ画像に再描画し、PNG 形式で保存します。この手法は、テキストの正確なサイズと書式を保持したまま、特定の段落を別画像として保存したい場合に特に有用です。
```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # 形状をメモリ内にビットマップとして保存します。
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # メモリから形状ビットマップを作成します。
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # 2番目の段落の境界を計算します。
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # 出力画像の座標とサイズを計算します（最小サイズは1×1ピクセル）。
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # 形状ビットマップを切り取って段落ビットマップのみを取得します。
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```


結果:

![The paragraph image](paragraph_to_image_output.png)

**例 2**

この例では、前述のアプローチに拡張として段落画像にスケーリング係数を追加します。シェイプを抽出し、スケーリング係数 `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が得られます。段落の境界はスケールを考慮して計算されます。スケーリングは、印刷物など高品質な画像が必要な場合に特に有用です。
```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # 形状をメモリ内にビットマップとして保存します。
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # メモリから形状ビットマップを作成します。
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # 2番目の段落の境界を計算します。
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # 出力画像の座標とサイズを計算します（最小サイズは1×1ピクセル）。
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # 形状ビットマップを切り取って段落ビットマップのみを取得します。
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```


## **FAQ**

**テキストフレーム内で改行（折り返し）を完全に無効にできますか？**

はい。テキストフレームの折り返し設定（[wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)）をオフにすれば、行はフレームの端で改行されません。

**特定の段落のスライド上での正確な境界を取得するにはどうすればよいですか？**

段落（あるいは単一のポーション）のバウンディング矩形を取得すれば、スライド上での正確な位置とサイズを知ることができます。

**段落の配置（左揃え/右揃え/中央揃え/均等割付）はどこで設定しますか？**

[Alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) は [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) の段落レベルの設定であり、個々のポーションの書式設定にかかわらず、段落全体に適用されます。

**段落の一部（例: 単語）だけにスペルチェック言語を設定できますか？**

はい。言語はポーションレベル（[PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/)）で設定されるため、1 つの段落内に複数の言語を共存させることが可能です。