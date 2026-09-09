---
title: Python via Java を使用したプレゼンテーションでの上付き文字と下付き文字の管理
linktitle: 上付き文字と下付き文字
type: docs
weight: 80
url: /ja/python-java/superscript-and-subscript/
keywords:
- 上付き文字
- 下付き文字
- 上付き文字を追加
- 下付き文字を追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java で上付き文字と下付き文字をマスターし、プロフェッショナルなテキスト書式設定でプレゼンテーションを最大限に引き立てましょう。"
---
## **概要**

Aspose.Slides は、PowerPoint (PPT、PPTX) および OpenDocument (ODP) プレゼンテーションに上付き文字と下付き文字のテキストを組み込む機能を提供します。化学式や数式の強調、脚注による注釈など、特殊な書式設定により、明確さと正確さを維持できます。本稿では、上付き文字と下付き文字のスタイルをシームレスに適用し、すべてのスライドでプロフェッショナルな結果を得る方法を学びます。

## **上付き文字と下付き文字の管理**

段落の任意の部分に上付き文字と下付き文字のテキストを追加できます。Aspose.Slides のテキストフレームでこの書式を適用するには、[PortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/) クラスの[setEscapement](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/#setEscapement) メソッドを使用します。

エスケープメントの値は -100%（下付き）から 100%（上付き）までの範囲です。例:

- [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
- インデックスでスライドを取得します。
- スライドに [ShapeType.Rectangle](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#Rectangle) タイプの [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
- [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) に関連付けられた [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) にアクセスします。
- 既存の段落をクリアします。
- 上付き文字用の段落を作成し、テキストフレームの[paragraph collection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/#getParagraphs)に追加します。
- ポーションを作成します。
- [setEscapement](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/#setEscapement) を使用して、上付き文字の値を 0 から 100 の範囲で設定します（0 は上付きなし）。
- [Portion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/) のテキストを設定し、段落のポーションコレクションに追加します。
- 下付き文字用の段落を作成し、テキストフレームの[paragraph collection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/#getParagraphs)に追加します。
- ポーションを作成します。
- [setEscapement](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/#setEscapement) を使用して、下付き文字の値を -100 から 0 の範囲で設定します（0 は下付きなし）。
- [Portion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/) のテキストを設定し、段落のポーションコレクションに追加します。
- プレゼンテーションを PPTX ファイルとして保存します。

以下の例は、これらの手順を実装したものです。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# プレゼンテーションを作成します。
presentation = Presentation()
try:
    # スライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # テキスト ボックスを作成します。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # 上付き文字用の段落を作成します。
    superscript_paragraph = Paragraph()

    # 通常テキストのポーションを作成します。
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # 上付き文字のポーションを作成します。
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # 下付き文字用の段落を作成します。
    subscript_paragraph = Paragraph()

    # 通常テキストのポーションを作成します。
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # 下付き文字のポーションを作成します。
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # 段落をテキスト ボックスに追加します。
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**PDF やその他の形式にエクスポートしたときに、上付き文字と下付き文字は保持されますか？**

はい、Aspose.Slides はプレゼンテーションを PDF、PPT/PPTX、画像、その他のサポート対象形式にエクスポートする際、上付き文字と下付き文字の書式設定を正しく保持します。特殊な書式はすべての出力ファイルでそのまま維持されます。

**上付き文字と下付き文字を太字や斜体などの他の書式スタイルと組み合わせることはできますか？**

はい、Aspose.Slides は単一のポーション内でさまざまなテキストスタイルを混在させることができます。太字、斜体、下線を有効にしながら、[PortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/) の対応するプロパティを設定することで、同時に上付き文字または下付き文字を適用できます。

**テーブル、チャート、または SmartArt 内のテキストにも上付き文字と下付き文字の書式は適用できますか？**

はい、Aspose.Slides はテーブルやチャート要素を含むほとんどのオブジェクト内での書式設定をサポートしています。SmartArt を操作する場合は、適切な要素（例: [SmartArtNode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartnode/)）とそのテキストコンテナにアクセスし、同様に [PortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/) のプロパティを設定してください。