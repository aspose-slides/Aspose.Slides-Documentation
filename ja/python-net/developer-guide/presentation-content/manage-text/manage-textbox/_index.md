---
title: Pythonでプレゼンテーションのテキストボックスを管理する
linktitle: テキストボックスの管理
type: docs
weight: 20
url: /ja/python-net/manage-textbox/
keywords:
- テキストボックス
- テキストフレーム
- テキストの追加
- テキストの更新
- テキストボックスの作成
- テキストボックスの確認
- テキスト列の追加
- ハイパーリンクの追加
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用すると、PowerPoint および OpenDocument ファイル内のテキストボックスを簡単に作成、編集、クローンでき、プレゼンテーションの自動化が向上します。"
---

## **概要**

スライド上のテキストは通常、テキストボックスまたはシェイプに格納されています。そのため、スライドにテキストを追加するには、まずテキストボックスを追加し、その中にテキストを入れる必要があります。Aspose.Slides for Python は、テキストを含むシェイプを追加できる [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) クラスを提供します。

{{% alert title="情報" color="info" %}}

Aspose.Slides には [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスもありますが、すべてのシェイプがテキストを保持できるわけではありません。

{{% /alert %}}

{{% alert title="注意" color="warning" %}}

そのため、テキストを追加したいシェイプを扱う際は、まずそれが [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) クラスにキャストされているか確認したいでしょう。そうすれば、[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) のプロパティである [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) を利用できます。このページの [テキストの更新](/slides/ja/python-net/manage-textbox/#update-text) セクションを参照してください。

{{% /alert %}}

## **スライド上にテキストボックスを作成する**

スライドにテキストボックスを作成する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. 最初のスライドへの参照を取得します。  
3. スライド上の目的の位置に `ShapeType.RECTANGLE` の [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。  
4. シェイプの [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にテキストを設定します。  
5. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python サンプルがこれらの手順を実装しています。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを生成。
with slides.Presentation() as presentation:

    # プレゼンテーションの最初のスライドを取得。
    slide = presentation.slides[0]

    # RECTANGLE タイプの AutoShape を追加。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # プレゼンテーションをディスクに保存。
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **シェイプがテキストボックスかどうかを確認する**

Aspose.Slides は [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) クラスに `is_text_box` プロパティを提供しており、シェイプがテキストボックスかどうかを判定できます。

![テキストボックスとシェイプ](istextbox.png)

この Python の例は、シェイプがテキストボックスとして作成されたかどうかをチェックする方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

`ShapeCollection` クラスを使用して [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加した場合、`is_text_box` プロパティは `False` を返します。ただし、`add_text_frame` メソッドまたは `text` プロパティでテキストを設定した後は、`is_text_box` が `True` になります。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box は false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box は true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box は false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box は true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box は false
    shape3.add_text_frame("")
    # shape3.is_text_box は false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box は false
    shape4.text_frame.text = ""
    # shape4.is_text_box は false
```

## **テキストボックスに列を追加する**

Aspose.Slides は [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) クラスの `column_count` と `column_spacing` プロパティを提供し、テキストボックスに列を追加できます。列数と列間の間隔（ポイント単位）を指定できます。

以下の Python コードがこの操作を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# プレゼンテーションの最初のスライドを取得。
	slide = presentation.slides[0]

	# RECTANGLE タイプの AutoShape を追加。
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# 矩形にテキストフレームを追加。
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# TextFrame のテキスト書式を取得。
	format = shape.text_frame.text_frame_format

	# 列数を指定。
	format.column_count = 3

	# 列間の間隔を指定。
	format.column_spacing = 10

	# プレゼンテーションを保存。
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **テキストの更新**

Aspose.Slides を使用すると、単一のテキストボックスまたはプレゼンテーション全体のテキストを更新できます。

以下の Python の例は、プレゼンテーション内のすべてのテキストを置換する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # 変更後のプレゼンテーションを保存。
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **ハイパーリンク付きテキストボックスの追加** 

テキストボックス内にリンクを埋め込むことができます。テキストボックスをクリックするとリンクが開きます。

ハイパーリンク付きテキストボックスを追加する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. 最初のスライドへの参照を取得します。  
3. スライド上の目的の位置に `ShapeType.RECTANGLE` の [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。  
4. シェイプの [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にテキストを設定します。  
5. [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/) への参照を取得します。  
6. `hyperlink_manager` プロパティを使用して外部クリックハイパーリンクを設定します。  
7. プレゼンテーションを PPTX ファイルとして保存します。

この Python の例は、ハイパーリンク付きテキストボックスをスライドに追加する方法を示しています。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを生成。
with slides.Presentation() as presentation:

    # プレゼンテーションの最初のスライドを取得。
    slide = presentation.slides[0]

    # RECTANGLE タイプの AutoShape を追加。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # フレームにテキストを追加。
    text_portion.text = "Aspose.Slides"

    # ポーションテキストにハイパーリンクを設定。
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # プレゼンテーションを PPTX ファイルとして保存。
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**マスタースライドでテキストボックスとテキストプレースホルダーの違いは何ですか？**

[プレースホルダー](/slides/ja/python-net/manage-placeholder/) は [マスター](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) からスタイルと位置を継承し、[レイアウト](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) で上書き可能です。一方、通常のテキストボックスは特定のスライド上の独立したオブジェクトであり、レイアウトを切り替えても変わりません。

**チャート、テーブル、SmartArt 内のテキストを除外して、プレゼンテーション全体でテキスト置換を一括で行うにはどうすればよいですか？**

テキストフレームを持つ AutoShape のみを列挙し、埋め込みオブジェクト（[チャート](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)、[テーブル](https://reference.aspose.com/slides/python-net/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)）は別々のコレクションで走査するか、対象外の型をスキップしてください。