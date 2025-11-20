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
description: "Aspose.Slides for Python via .NET を使用すると、PowerPoint および OpenDocument ファイルでテキストボックスの作成、編集、クローンが簡単になり、プレゼンテーションの自動化が強化されます。"
---

## **概要**

スライド上のテキストは通常、テキストボックスまたは図形に存在します。そのため、スライドにテキストを追加するには、テキストボックスを追加し、そのテキストボックス内にテキストを配置する必要があります。Aspose.Slides for Python は、テキストを含む図形を追加できる[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)クラスを提供します。

{{% alert title="情報" color="info" %}}
Aspose.Slides は[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)クラスも提供します。ただし、すべての図形がテキストを保持できるわけではありません。
{{% /alert %}}

{{% alert title="注意" color="warning" %}}
したがって、テキストを追加したい図形を扱う場合は、その図形が[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)クラスにキャストされているか確認したいでしょう。その場合のみ、[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)のプロパティである[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)を使用できます。このページの[Update Text](/slides/ja/python-net/manage-textbox/#update-text)セクションをご覧ください。
{{% /alert %}}

## **スライド上にテキスト ボックスを作成する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。  
2. 最初のスライドへの参照を取得します。  
3. スライド上の目的の位置に`ShapeType.RECTANGLE`を指定して[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)を追加します。  
4. 図形の[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)にテキストを設定します。  
5. プレゼンテーションをPPTXファイルとして保存します。

以下の Python サンプルがこれらの手順を実装しています。
```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # プレゼンテーションの最初のスライドを取得します。
    slide = presentation.slides[0]

    # タイプ RECTANGLE の AutoShape を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # プレゼンテーションをディスクに保存します。
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```


## **図形がテキスト ボックスかどうかを確認する**

Aspose.Slides は、[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)クラスの[is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/)プロパティを提供し、図形がテキスト ボックスかどうかを判定できます。

![テキスト ボックスと図形](istextbox.png)

この Python サンプルは、図形がテキスト ボックスとして作成されたかどうかを確認する方法を示します。
```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```


注意: [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)クラスを使用して[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)を追加した場合、図形の`is_text_box`プロパティは`False`を返します。ただし、`add_text_frame`メソッドでテキストを追加するか、`text`プロパティを設定すると、`is_text_box`は`True`を返します。
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


## **テキスト ボックスに列を追加する**

Aspose.Slides は、[TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)クラスの[column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/)と[column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/)プロパティを提供し、テキスト ボックスに列を追加できます。列数を指定し、列間の間隔（ポイント単位）を設定できます。

以下の Python コードはこの操作を示しています。
```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# プレゼンテーションの最初のスライドを取得します。
	slide = presentation.slides[0]

	# タイプ RECTANGLE の AutoShape を追加します。
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# 四角形に TextFrame を追加します。
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# TextFrame のテキスト形式を取得します。
	format = shape.text_frame.text_frame_format

	# TextFrame の列数を指定します。
	format.column_count = 3

	# 列間の間隔を指定します。
	format.column_spacing = 10

	# プレゼンテーションを保存します。
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```



## **テキストを更新する**

Aspose.Slides を使用すると、単一のテキスト ボックスまたはプレゼンテーション全体のテキストを更新できます。

以下の Python サンプルは、プレゼンテーション内のすべてのテキストを更新する方法を示しています。
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
  
    # 修正したプレゼンテーションを保存します。
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```


## **ハイパーリンク付きテキスト ボックスを追加する**

テキスト ボックスにリンクを挿入できます。テキスト ボックスをクリックすると、リンクが開きます。

テキスト ボックスにハイパーリンクを含めるには、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。  
2. 最初のスライドへの参照を取得します。  
3. スライド上の目的の位置に`ShapeType.RECTANGLE`を指定して[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)を追加します。  
4. 図形の[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)にテキストを設定します。  
5. [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/)への参照を取得します。  
6. `hyperlink_manager`プロパティを使用して外部クリック ハイパーリンクを設定します。  
7. プレゼンテーションをPPTXファイルとして保存します。

この Python サンプルは、スライドにハイパーリンク付きテキスト ボックスを追加する方法を示しています。
```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # プレゼンテーションの最初のスライドを取得します。
    slide = presentation.slides[0]

    # タイプ RECTANGLE の AutoShape を追加します。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # フレームにテキストを追加します。
    text_portion.text = "Aspose.Slides"

    # ポーションのテキストにハイパーリンクを設定します。
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**マスタースライドで作業するときのテキスト ボックスとテキスト プレースホルダーの違いは何ですか？**

[placeholder](/slides/ja/python-net/manage-placeholder/)は[master](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/)からスタイル/位置を継承し、[layouts](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/)でオーバーライドできます。一方、通常のテキスト ボックスは特定のスライド上の独立したオブジェクトで、レイアウトを切り替えても変更されません。

**チャート、テーブル、SmartArt 内のテキストに触れずに、プレゼンテーション全体で大量のテキスト置換を実行するにはどうすればよいですか？**

テキスト フレームを持つオート シェイプに対してだけ繰り返し処理を行い、埋め込みオブジェクト（[charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)、[tables](https://reference.aspose.com/slides/python-net/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)）は別々にコレクションを走査するか、それらのオブジェクト タイプをスキップして除外してください。