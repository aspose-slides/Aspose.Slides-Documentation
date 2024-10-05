---
title: 上付き文字と下付き文字
type: docs
weight: 80
url: /python-net/superscript-and-subscript/
keywords: "上付き文字, 下付き文字, 上付き文字のテキスト追加, 下付き文字のテキスト追加, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションに上付き文字と下付き文字のテキストを追加する"
---

## **上付き文字と下付き文字のテキストを管理する**
任意の段落部分に上付き文字と下付き文字のテキストを追加できます。Aspose.Slidesのテキストフレームに上付き文字または下付き文字のテキストを追加するには、**Escapement**プロパティを使用する必要があります。

このプロパティは、上付き文字または下付き文字のテキストを取得または設定します（値は-100%（下付き文字）から100%（上付き文字）までです）。例えば：

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに長方形型のIAutoShapeを追加します。
- IAutoShapeに関連付けられたITextFrameにアクセスします。
- 既存の段落をクリアします。
- 上付き文字のテキストを保持するための新しい段落オブジェクトを作成し、ITextFrameのIParagraphsコレクションに追加します。
- 新しいポーションオブジェクトを作成します。
- 上付き文字を追加するためにポーションのEscapementプロパティを0から100に設定します。（0は上付き文字なしを意味します）
- ポーションにテキストを設定し、それを段落のポーションコレクションに追加します。
- 下付き文字のテキストを保持するための新しい段落オブジェクトを作成し、ITextFrameのIParagraphsコレクションに追加します。
- 新しいポーションオブジェクトを作成します。
- 下付き文字を追加するためにポーションのEscapementプロパティを0から-100に設定します。（0は下付き文字なしを意味します）
- ポーションにテキストを設定し、それを段落のポーションコレクションに追加します。
- プレゼンテーションをPPTXファイルとして保存します。

上記の手順の実装は以下に示します。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # スライドを取得
    slide = presentation.slides[0]

    # テキストボックスを作成
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    textFrame = shape.text_frame
    textFrame.paragraphs.clear()

    # 上付き文字のための段落を作成
    superPar = slides.Paragraph()

    # 通常のテキストを持つポーションを作成
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superPar.portions.add(portion1)

    # 上付き文字のテキストを持つポーションを作成
    superPortion = slides.Portion()
    superPortion.portion_format.escapement = 30
    superPortion.text = "TM"
    superPar.portions.add(superPortion)

    # 下付き文字のための段落を作成
    paragraph2 = slides.Paragraph()

    # 通常のテキストを持つポーションを作成
    portion2 = slides.Portion()
    portion2.text = "a"
    paragraph2.portions.add(portion2)

    # 下付き文字のテキストを持つポーションを作成
    subPortion = slides.Portion()
    subPortion.portion_format.escapement = -25
    subPortion.text = "i"
    paragraph2.portions.add(subPortion)

    # テキストボックスに段落を追加
    textFrame.paragraphs.add(superPar)
    textFrame.paragraphs.add(paragraph2)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```