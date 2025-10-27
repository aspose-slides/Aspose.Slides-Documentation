---
title: Python を使用したプレゼンテーションのテキストボックスの管理
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
- テキストボックスのチェック
- テキスト列の追加
- ハイパーリンクの追加
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用すると、PowerPoint および OpenDocument ファイル内のテキストボックスを簡単に作成、編集、コピーでき、プレゼンテーションの自動化が向上します。"
---

## **概要**

スライド上のテキストは通常、テキストボックスまたはシェイプに存在します。そのため、スライドにテキストを追加するには、テキストボックスを追加し、その中にテキストを入れる必要があります。Aspose.Slides for Python は、テキストを含むシェイプを追加できる [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) クラスを提供します。

{{% alert title="情報" color="info" %}}

Aspose.Slides は [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) クラスも提供しますが、すべてのシェイプがテキストを保持できるわけではありません。

{{% /alert %}}

{{% alert title="注記" color="warning" %}}

したがって、テキストを追加したいシェイプを扱う場合、[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) クラスにキャストされたことを確認したいでしょう。その後でのみ、[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) のプロパティである [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) を操作できます。このページの [Update Text](/slides/ja/python-net/manage-textbox/#update-text) セクションをご参照ください。

{{% /alert %}}

## **スライドにテキストボックスを作成する**

テキストボックスをスライドに作成する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 最初のスライドへの参照を取得します。
3. スライド上の目的位置に `ShapeType.RECTANGLE` の [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にテキストを設定します。
5. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python の例でこれらの手順を実装しています。

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide in the presentation.
    slide = presentation.slides[0]

    # Add an AutoShape of type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Save the presentation to disk.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **シェイプがテキストボックスかどうかを確認する**

Aspose.Slides は [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) クラスに `is_text_box` プロパティを提供しており、シェイプがテキストボックスかどうかを判定できます。

![テキストボックスとシェイプ](istextbox.png)

この Python の例は、シェイプがテキストボックスとして作成されたかどうかを確認する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

なお、[ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) クラスを使用して [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加した場合、`is_text_box` プロパティは `False` を返します。ただし、`add_text_frame` メソッドまたは `text` プロパティでテキストを追加すると、`is_text_box` は `True` になります。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box is false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box is true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box is false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box is true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box is false
    shape3.add_text_frame("")
    # shape3.is_text_box is false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box is false
    shape4.text_frame.text = ""
    # shape4.is_text_box is false
```

## **テキストボックスに列を追加する**

Aspose.Slides は [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) クラスの `column_count` と `column_spacing` プロパティを提供し、テキストボックスに列を追加できます。列数と列間のスペース（ポイント単位）を指定できます。

以下の Python コードはこの操作を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Get the first slide in the presentation.
	slide = presentation.slides[0]

	# Add an AutoShape of type RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Add a TextFrame to the rectangle.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Get the text format of the TextFrame.
	format = shape.text_frame.text_frame_format

	# Specify the number of columns in the TextFrame.
	format.column_count = 3

	# Specify the spacing between columns.
	format.column_spacing = 10

	# Save the presentation.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **テキストを更新する**

Aspose.Slides を使用すると、単一のテキストボックスまたはプレゼンテーション全体のテキストを更新できます。

以下の Python の例は、プレゼンテーション内のすべてのテキストを更新する方法を示しています。

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
  
    # Save the modified presentation.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **ハイパーリンク付きテキストボックスの追加** 

テキストボックスにリンクを挿入できます。テキストボックスをクリックするとリンクが開きます。

ハイパーリンクを含むテキストボックスを追加する手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 最初のスライドへの参照を取得します。
3. スライド上の目的位置に `ShapeType.RECTANGLE` の [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にテキストを設定します。
5. [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/) への参照を取得します。
6. `hyperlink_manager` プロパティを使用して外部クリックハイパーリンクを設定します。
7. プレゼンテーションを PPTX ファイルとして保存します。

この Python の例は、スライドにハイパーリンク付きテキストボックスを追加する方法を示しています。

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide in the presentation.
    slide = presentation.slides[0]

    # Add an AutoShape of type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Add text to the frame.
    text_portion.text = "Aspose.Slides"

    # Set a hyperlink for the portion text.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Save the presentation as a PPTX file.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**マスタースライドで作業する際、テキストボックスとテキストプレースホルダーの違いは何ですか？**

テキストプレースホルダーは、[マスタ](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) からスタイル/位置を継承し、[レイアウト](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) で上書きできるのに対し、通常のテキストボックスは特定のスライド上の独立したオブジェクトであり、レイアウトを切り替えても変わりません。

**チャート、テーブル、SmartArt 内のテキストは除外し、プレゼンテーション全体でテキストを一括置換するにはどうすればよいですか？**

テキストフレームを持つオートシェイプだけを反復処理し、埋め込みオブジェクト（[チャート](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)、[テーブル](https://reference.aspose.com/slides/python-net/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)）はそれぞれ別のコレクションで走査するか、対象のオブジェクト種別をスキップして除外してください。