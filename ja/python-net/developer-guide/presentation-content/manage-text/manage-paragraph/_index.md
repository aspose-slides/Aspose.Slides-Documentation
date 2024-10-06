---
title: PythonでのPowerPoint段落の管理
type: docs
weight: 40
url: /ja/python-net/manage-paragraph/
keywords: "PowerPoint段落の追加, 段落の管理, 段落のインデント, 段落のプロパティ, HTMLテキスト, 段落テキストのエクスポート, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションの段落、テキスト、インデント、およびプロパティを作成および管理する"
---

Aspose.Slidesは、PythonでPowerPointのテキスト、段落、および部分を操作するために必要なすべてのインターフェイスとクラスを提供します。

* Aspose.Slidesは、段落を表すオブジェクトを追加するための[ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)インターフェイスを提供します。`ITextFame`オブジェクトは1つまたは複数の段落を持つことができます（各段落はキャリッジリターンを通じて作成されます）。
* Aspose.Slidesは、部分を表すオブジェクトを追加するための[IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/)インターフェイスを提供します。`IParagraph`オブジェクトは1つまたは複数の部分（iPortionsオブジェクトのコレクション）を持つことができます。
* Aspose.Slidesは、テキストとその書式プロパティを表すオブジェクトを追加するための[IPortion](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/)インターフェイスを提供します。

`IParagraph`オブジェクトは、その基盤となる`IPortion`オブジェクトを通じて、異なる書式プロパティを持つテキストを処理することができます。

## **複数の部分を含む複数の段落の追加**

これらのステップでは、3つの段落を含むテキストフレームを追加し、各段落には3つの部分が含まれる方法を示します：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じて関連するスライドの参照にアクセスします。
3. スライドに長方形の[IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)に関連付けられたITextFrameを取得します。
5. 2つの[IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/)オブジェクトを作成し、それらを[ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)の`IParagraphs`コレクションに追加します。
6. 各新しい`IParagraph`のために3つの[IPortion](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/)オブジェクトを作成し、それぞれの`IParagraph`のIPortionコレクションに各`IPortion`オブジェクトを追加します。
7. 各部分のテキストを設定します。
8. `IPortion`オブジェクトによって公開された書式プロパティを使用して、各部分にお気に入りの書式設定機能を適用します。
9. 修正されたプレゼンテーションを保存します。

このPythonコードは、部分を含む段落を追加するためのステップの実装です：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すPresentationクラスのインスタンスを作成
with slides.Presentation() as pres:
    # 最初のスライドにアクセス
    slide = pres.slides[0]

    # 長方形タイプのAutoShapeを追加
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # AutoShapeのTextFrameにアクセス
    tf = ashp.text_frame

    # 異なるテキスト形式を持つ段落と部分を作成
    para0 = tf.paragraphs[0]
    port01 = slides.Portion()
    port02 = slides.Portion()
    para0.portions.add(port01)
    para0.portions.add(port02)

    para1 = slides.Paragraph()
    tf.paragraphs.add(para1)
    port10 = slides.Portion()
    port11 = slides.Portion()
    port12 = slides.Portion()
    para1.portions.add(port10)
    para1.portions.add(port11)
    para1.portions.add(port12)

    para2 = slides.Paragraph()
    tf.paragraphs.add(para2)
    port20 = slides.Portion()
    port21 = slides.Portion()
    port22 = slides.Portion()
    para2.portions.add(port20)
    para2.portions.add(port21)
    para2.portions.add(port22)

    for i in range(3):
        for j in range(3):
            tf.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                tf.paragraphs[i].portions[j].portion_format.font_bold = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                tf.paragraphs[i].portions[j].portion_format.font_italic = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 18

    # PPTXをディスクに書き込む
    pres.save("multiParaPort_out.pptx", slides.export.SaveFormat.PPTX)
```


## **段落の箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理し提示するのに役立ちます。箇条書きの段落は常に読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じて関連するスライドの参照にアクセスします。
3. 選択したスライドに[autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)にアクセスします。 
5. `TextFrame`のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き`Type`を`Symbol`に設定し、箇条書き文字を設定します。
8. 段落の`Text`を設定します。
9. 箇条書きのための段落の`Indent`を設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を`TextFrame`の段落コレクションに追加します。
13. 2番目の段落を追加し、ステップ7から13で示されたプロセスを繰り返します。
14. プレゼンテーションを保存します。

このPythonコードは、段落の箇条書きを追加する方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーションインスタンスを作成
with slides.Presentation() as pres:
    # 最初のスライドにアクセス
    slide = pres.slides[0]

    # AutoShapeを追加しアクセス
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 作成したautoshapeのテキストフレームにアクセス
    txtFrm = aShp.text_frame

    # デフォルトの既存の段落を削除する
    txtFrm.paragraphs.remove_at(0)

    # 段落を作成する
    para = slides.Paragraph()

    # 段落の箇条書きスタイルとシンボルを設定
    para.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para.paragraph_format.bullet.char = chr(8226)

    # 段落テキストを設定
    para.text = "Aspose.Slidesへようこそ"

    # 箇条書きのインデントを設定
    para.paragraph_format.indent = 25

    # 箇条書きの色を設定
    para.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para.paragraph_format.bullet.color.color = draw.Color.black
    para.paragraph_format.bullet.is_bullet_hard_color = 1 

    # 箇条書きの高さを設定
    para.paragraph_format.bullet.height = 100

    # テキストフレームに段落を追加
    txtFrm.paragraphs.add(para)

    # 2番目の段落を作成
    para2 = slides.Paragraph()

    # 段落の箇条書きタイプとスタイルを設定
    para2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    para2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # 段落テキストを追加
    para2.text = "これは番号付きの箇条書きです"

    # 箇条書きのインデントを設定
    para2.paragraph_format.indent = 25

    para2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para2.paragraph_format.bullet.color.color = draw.Color.black
    para2.paragraph_format.bullet.is_bullet_hard_color = 1

    # 箇条書きの高さを設定
    para2.paragraph_format.bullet.height = 100

    # テキストフレームに段落を追加
    txtFrm.paragraphs.add(para2)

    # PPTXファイルとしてプレゼンテーションを書き込む
    pres.save("bullet_out.pptx", slides.export.SaveFormat.PPTX)
```


## **画像箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理し提示するのに役立ちます。画像段落は読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じて関連するスライドの参照にアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)にアクセスします。 
5. `TextFrame`のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)に画像を読み込みます。
8. 箇条書きのタイプを[Picture](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)に設定し、画像を設定します。
9. 段落の`Text`を設定します。
10. 箇条書きのための段落の`Indent`を設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を`TextFrame`の段落コレクションに追加します。
14. 2番目の段落を追加し、以前の手順に基づいてプロセスを繰り返します。
15. 修正されたプレゼンテーションを保存します。

このPythonコードは、画像箇条書きを追加および管理する方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # 最初のスライドにアクセス
    slide = presentation.slides[0]

    # 箇条書き用の画像をインスタンス化
    image = draw.Bitmap(path + "bullets.png")
    ippxImage = presentation.images.add_image(image)

    # AutoShapeを追加しアクセス
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 作成したautoshapeのテキストフレームにアクセス
    textFrame = autoShape.text_frame

    # デフォルトの既存の段落を削除する
    textFrame.paragraphs.remove_at(0)

    # 新しい段落を作成
    paragraph = slides.Paragraph()
    paragraph.text = "Aspose.Slidesへようこそ"

    # 段落の箇条書きスタイルと画像を設定
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = ippxImage

    # 箇条書きの高さを設定
    paragraph.paragraph_format.bullet.height = 100

    # テキストフレームに段落を追加
    textFrame.paragraphs.add(paragraph)

    # PPTXファイルとしてプレゼンテーションを書き込む
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", slides.export.SaveFormat.PPTX)
    # PPTファイルとしてプレゼンテーションを書き込む
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", slides.export.SaveFormat.PPT)
```


## **多段階の箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理し提示するのに役立ちます。多段階の箇条書きは読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じて関連するスライドの参照にアクセスします。
3. 新しいスライドに[autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)にアクセスします。 
5. `TextFrame`のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成し、深さを0に設定します。
7. [Paragraph]クラスを使用して2番目の段落インスタンスを作成し、深さを1に設定します。
8. [Paragraph]クラスを使用して3番目の段落インスタンスを作成し、深さを2に設定します。
9. [Paragraph]クラスを使用して4番目の段落インスタンスを作成し、深さを3に設定します。
10. 新しい段落を`TextFrame`の段落コレクションに追加します。
11. 修正されたプレゼンテーションを保存します。

このPythonコードは、多段階の箇条書きを追加および管理する方法を示しています：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーションインスタンスを作成
with slides.Presentation() as pres:
    # 最初のスライドにアクセス
    slide = pres.slides[0]
    
    # AutoShapeを追加しアクセス
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 作成したautoshapeのテキストフレームにアクセス
    text = aShp.add_text_frame("")
    
    # デフォルトの段落をクリア
    text.paragraphs.clear()

    # 最初の段落を追加
    para1 = slides.Paragraph()
    para1.text = "コンテンツ"
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 箇条書きのレベルを設定
    para1.paragraph_format.depth = 0

    # 2番目の段落を追加
    para2 = slides.Paragraph()
    para2.text = "第2レベル"
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = '-'
    para2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 箇条書きのレベルを設定
    para2.paragraph_format.depth = 1

    # 3番目の段落を追加
    para3 = slides.Paragraph()
    para3.text = "第3レベル"
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 箇条書きのレベルを設定
    para3.paragraph_format.depth = 2

    # 4番目の段落を追加
    para4 = slides.Paragraph()
    para4.text = "第4レベル"
    para4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para4.paragraph_format.bullet.char = '-'
    para4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 箇条書きのレベルを設定
    para4.paragraph_format.depth = 3

    # 段落をコレクションに追加
    text.paragraphs.add(para1)
    text.paragraphs.add(para2)
    text.paragraphs.add(para3)
    text.paragraphs.add(para4)

    # PPTXファイルとしてプレゼンテーションを書き込む
    pres.save("MultilevelBullet.pptx", slides.export.SaveFormat.PPTX)
```


## **カスタム番号付きリストでの段落の管理**

[IBulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformat/#ibulletformat/)インターフェイスは、`NumberedBulletStartWith`プロパティなどを提供し、カスタム番号付けまたは書式設定の段落を管理できるようにします。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 段落を含むスライドにアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)にアクセスします。 
5. `TextFrame`のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成し、`NumberedBulletStartWith`を2に設定します。
7. [Paragraph]クラスを使用して2番目の段落インスタンスを作成し、`NumberedBulletStartWith`を3に設定します。
8. [Paragraph]クラスを使用して3番目の段落インスタンスを作成し、`NumberedBulletStartWith`を7に設定します。
9. 新しい段落を`TextFrame`の段落コレクションに追加します。
10. 修正されたプレゼンテーションを保存します。

このPythonコードは、カスタム番号付けや書式設定のある段落を追加および管理する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 作成したautoshapeのテキストフレームにアクセス
    textFrame = shape.text_frame

    # デフォルトの既存の段落を削除する
    textFrame.paragraphs.remove_at(0)

    # 最初のリスト
    paragraph1 = slides.Paragraph()
    paragraph1.text = "箇条書き 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.text = "箇条書き 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    textFrame.paragraphs.add(paragraph2)


    paragraph5 = slides.Paragraph()
    paragraph5.text = "箇条書き 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph5)

    presentation.save("SetCustomBulletsNumber-slides.pptx", slides.export.SaveFormat.PPTX)
```


## **段落インデントの設定**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じて関連するスライドの参照にアクセスします。
3. スライドに長方形の[autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)を追加します。
4. 長方形のautoshapeに3つの段落を持つ[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)を追加します。
5. 長方形の線を非表示にします。
6. 各[Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)のBulletOffsetプロパティを介してインデントを設定します。
7. 修正されたプレゼンテーションを書き込みます。

このPythonコードは、段落のインデントを設定する方法を示しています：

```python
import aspose.slides as slides

# Presentationクラスをインスタンス化
with slides.Presentation() as pres:

    # 最初のスライドを取得
    sld = pres.slides[0]

    # 長方形の形状を追加
    rect = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # 長方形にTextFrameを追加
    tf = rect.add_text_frame("これは最初の行です \rこれは2行目です \rこれは3行目です")

    # 形状にフィットするテキストを設定
    tf.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # 長方形の線を非表示にする
    rect.line_format.fill_format.fill_type = slides.FillType.SOLID

    # TextFrameの最初の段落を取得し、そのインデントを設定
    para1 = tf.paragraphs[0]
    # 段落の箇条書きスタイルとシンボルを設定
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.alignment = slides.TextAlignment.LEFT

    para1.paragraph_format.depth = 2
    para1.paragraph_format.indent = 30

    # TextFrameの2番目の段落を取得し、そのインデントを設定
    para2 = tf.paragraphs[1]
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = chr(8226)
    para2.paragraph_format.alignment = slides.TextAlignment.LEFT
    para2.paragraph_format.depth = 2
    para2.paragraph_format.indent = 40

    # TextFrameの3番目の段落を取得し、そのインデントを設定
    para3 = tf.paragraphs[2]
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.alignment = slides.TextAlignment.LEFT
    para3.paragraph_format.depth = 2
    para3.paragraph_format.indent = 50

    # プレゼンテーションをディスクに書き込む
    pres.save("InOutDent_out.pptx", slides.export.SaveFormat.PPTX)
```

## **段落に対するハンギングインデントの設定**

このPythonコードは、段落のハンギングインデントを設定する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    auto_shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 550, 150)

    para1 = slides.Paragraph()
    para1.text = "サンプル"
    para2 = slides.Paragraph()
    para2.text = "段落にハンギングインデントを設定"
    para3 = slides.Paragraph()
    para3.text = "このC#コードは、段落のハンギングインデントを設定する方法を示しています："

    para2.paragraph_format.margin_left = 10
    para3.paragraph_format.margin_left = 20

    paragraphs = auto_shape.text_frame.paragraphs
    paragraphs.add(para1)
    paragraphs.add(para2)
    paragraphs.add(para3)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **段落の End プロパティの管理**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. その位置を通じて段落を含むスライドの参照を取得します。
3. スライドに長方形の[autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)を追加します。
4. 長方形に2つの段落を持つ[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)を追加します。
5. 段落のフォント高さとフォントタイプを設定します。
6. 段落のEndプロパティを設定します。
7. プレゼンテーションをPPTXファイルとして書き込みます。

このPythonコードは、PowerPointで段落のEndプロパティを設定する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
	shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	para1 = slides.Paragraph()
	para1.portions.add(slides.Portion("サンプルテキスト"))

	para2 = slides.Paragraph()
	para2.portions.add(slides.Portion("サンプルテキスト2"))
	endParagraphPortionFormat = slides.PortionFormat()
	endParagraphPortionFormat.font_height = 48
	endParagraphPortionFormat.latin_font = slides.FontData("Times New Roman")
	para2.end_paragraph_portion_format = endParagraphPortionFormat

	shape.text_frame.paragraphs.add(para1)
	shape.text_frame.paragraphs.add(para2)

	pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```


## **HTMLテキストを段落にインポート**

Aspose.Slidesは、HTMLテキストを段落にインポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じて関連するスライドの参照にアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)に追加しアクセスします。
5. `ITextFrame`のデフォルト段落を削除します。
6. テキストリーダーでソースHTMLファイルを読み込みます。
7. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
8. 読み取ったTextReaderにHTMLファイルの内容を追加し、TextFrameの[ParagraphCollection](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/)に追加します。
9. 修正されたプレゼンテーションを保存します。

このPythonコードは、段落内にHTMLテキストをインポートするステップの実装です：

```python
import aspose.slides as slides

# 空のプレゼンテーションインスタンスを作成
with slides.Presentation() as pres:
    # プレゼンテーションのデフォルトの最初のスライドにアクセス
    slide = pres.slides[0]

    # HTMLコンテンツを収めるためのAutoShapeを追加
    ashape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, pres.slide_size.size.width - 20, pres.slide_size.size.height - 10)

    ashape.fill_format.fill_type = slides.FillType.NO_FILL

    # 形状にテキストフレームを追加
    ashape.add_text_frame("")

    # 追加したテキストフレームのすべての段落をクリア
    ashape.text_frame.paragraphs.clear()

    # ストリームリーダーを使用してHTMLファイルを読み込む
    with open(path + "file.html", "rt") as tr:
        # HTMLストリームリーダーからテキストフレームにテキストを追加
        ashape.text_frame.paragraphs.add_from_html(tr.read())

    # プレゼンテーションを保存
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **段落テキストをHTMLにエクスポート**

Aspose.Slidesは、段落内に含まれるテキストをHTMLにエクスポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、目的のプレゼンテーションを読み込みます。
2. インデックスを通じて関連するスライドの参照にアクセスします。
3. HTMLにエクスポートするテキストを含む形状にアクセスします。
4. 形状の[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)にアクセスします。
5. `StreamWriter`のインスタンスを作成し、新しいHTMLファイルを追加します。
6. StreamWriterに開始インデックスを提供し、好みの段落をエクスポートします。

このPythonコードは、PowerPointの段落テキストをHTMLにエクスポートする方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションファイルを読み込む
with slides.Presentation(path + "ExportingHTMLText.pptx") as pres:
    # プレゼンテーションのデフォルトの最初のスライドにアクセス
    slide = pres.slides[0]

    # 希望するインデックス
    index = 0

    # 追加した形状にアクセス
    ashape = slide.shapes[index]

    with open("output_out.html", "w") as sw:
        # 段落の開始インデックス、コピーする総段落の数を提供してHTMLにデータを書き込む
        sw.write(ashape.text_frame.paragraphs.export_to_html(0, ashape.text_frame.paragraphs.count, None))
```