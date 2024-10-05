---
title: 箇条書きと番号付きリストの管理
type: docs
weight: 70
url: /python-net/manage-bullet-and-numbered-lists/
keywords: "箇条書き, 箇条書きリスト, 番号, 番号付きリスト, 画像の箇条書き, 多段階箇条書き, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションに箇条書きと番号付きリストを作成する"
---

**Microsoft PowerPoint**では、Wordや他のテキストエディタと同じ方法で箇条書きと番号付きリストを作成できます。**Aspose.Slides for Python via .NET**も、プレゼンテーションのスライドで箇条書きや番号を使用することを可能にします。

### なぜ箇条書きを使うのか？

箇条書きは、情報を迅速かつ効率的に整理し、提示するのに役立ちます。

**箇条書きの例**

ほとんどの場合、箇条書きは以下の3つの主要な機能を果たします：

- 読者や視聴者の重要な情報への関心を引く
- 読者や視聴者が重要なポイントを簡単にスキャンできるようにする
- 重要な詳細を効率的に伝達し、提供する。

### なぜ番号付きリストを使うのか？

番号付きリストも、情報を整理し、提示するのに役立ちます。理想的には、項目の順序（例えば、*ステップ1、ステップ2*など）が重要な場合や、項目が参照される必要がある場合（例えば、*ステップ3を参照*）には番号（箇条書きの代わりに）を使用すべきです。

**番号付きリストの例**

以下の**箇条書き作成**手順の手順（ステップ1からステップ15）の要約です：

1. プレゼンテーションクラスのインスタンスを作成する。
2. いくつかの作業を実行する（ステップ3からステップ14）。
3. プレゼンテーションを保存する。

## 箇条書きの作成

箇条書きを作成するには、以下の手順に従います：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)オブジェクトを使用して、箇条書きリストを追加したいスライドをスライドコレクションからアクセスします。
3. 選択したスライドに[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)を追加します。
4. 追加したシェイプの[text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)にアクセスします。
5. [text_frame]()の既定の段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
8. 箇条書きの種類を記号に設定し、次に箇条書きの文字を設定します。
9. 段落のテキストを設定します。
10. 箇条書きを設定するために段落のインデントを設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 作成した段落を[text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)の段落コレクションに追加します。
14. 2番目の段落を追加し、手順7-12を繰り返します。
15. プレゼンテーションを保存します。

以下のPythonのサンプルコードは、上記の手順の実装であり、スライドに箇条書きを作成する方法を示しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1
    paragraph.paragraph_format.bullet.color.color = draw.Color.red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "私のテキスト"

    textFrame.paragraphs.add(paragraph)
    
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

 

## 画像の箇条書きの作成

Aspose.Slides for Python via .NETでは、箇条書きリストの箇条書きを変更することができます。箇条書きをカスタム記号や画像に置き換えることができます。リストに視覚的な興味を加えたり、リスト上の項目にさらに注目を集めたりするために、独自の画像を箇条書きとして使用することができます。

 {{% alert color="primary" %}} 

理想的には、通常の箇条書き記号を画像に置き換えるつもりであれば、透明な背景を持つシンプルなグラフィック画像を選択することをお勧めします。そのような画像は、カスタム箇条書き記号として最適に機能します。

いずれにしても、選択した画像は非常に小さいサイズに縮小されるため、リスト内の箇条書き記号の代わりに見栄えが良い画像を選択することを強くお勧めします。

{{% /alert %}} 

画像の箇条書きを作成するには、以下の手順に従います：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)オブジェクトを使用して、スライドコレクションの中から目的のスライドにアクセスします。
3. 選択したスライドに[add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)を追加します。
4. 追加したシェイプの[text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)にアクセスします。
5. [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)の既定の段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
7. ディスクから画像を読み込み、[Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)に追加し、[add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/)メソッドから返された[IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)インスタンスを使用します。
8. 箇条書きの種類を画像に設定し、次に画像を設定します。
9. 段落のテキストを設定します。
10. 箇条書きを設定するために段落のインデントを設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 作成した段落を[text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)の段落コレクションに追加します。
14. 2番目の段落を追加し、手順7-13を繰り返します。
15. プレゼンテーションを保存します。

  このPythonコードは、スライドに画像の箇条書きを作成する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "私のテキスト"

    textFrame.paragraphs.add(paragraph)
    
    pres.save("pres-bullets.pptx", slides.export.SaveFormat.PPTX)
```

 

## 多段階箇条書きの作成

異なるレベルの項目を含む箇条書きリストを作成するには—主な箇条書きリストの下に追加のリストを作成するため—以下の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)オブジェクトを使用して、スライドコレクションの中から目的のスライドにアクセスします。
3. 選択したスライドに[auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)を追加します。
4. 追加したシェイプの[text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)にアクセスします。
5. [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)の既定の段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成し、深さを0に設定します。
7. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)クラスを使用して2番目の段落インスタンスを作成し、深さを1に設定します。
8. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)クラスを使用して3番目の段落インスタンスを作成し、深さを2に設定します。
9. [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)クラスを使用して4番目の段落インスタンスを作成し、深さを3に設定します。
10. 作成した段落を[text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)の段落コレクションに追加します。
11. プレゼンテーションを保存します。

以下のコードは、上記の手順の実装であり、多段階箇条書きリストをPythonで作成する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 300, 300)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.depth = 0
    paragraph.text = "私のテキスト 深さ0"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 0
    paragraph2.text = "私のテキスト 深さ1"
    textFrame.paragraphs.add(paragraph2)
    
    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "私のテキスト 深さ2"
    textFrame.paragraphs.add(paragraph3)
    
    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "私のテキスト 深さ3"
    textFrame.paragraphs.add(paragraph4)
    
    pres.save("pres-bullets2.pptx", slides.export.SaveFormat.PPTX)
```

 

## 数字の作成

このPythonコードは、スライドに番号付きリストを作成する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.text = "私のテキスト 1"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "私のテキスト 2"
    textFrame.paragraphs.add(paragraph2)
    
    pres.save("pres-bullets3.pptx", slides.export.SaveFormat.PPTX)
```