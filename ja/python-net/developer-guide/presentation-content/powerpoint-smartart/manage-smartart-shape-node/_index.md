---
title: Python でプレゼンテーションの SmartArt シェイプ ノードを管理する
linktitle: SmartArt シェイプ ノード
type: docs
weight: 30
url: /ja/python-net/manage-smartart-shape-node/
keywords:
- SmartArt ノード
- 子ノード
- ノードの追加
- ノードの位置
- ノードへのアクセス
- ノードの削除
- カスタム位置
- アシスタントノード
- 塗りつぶし形式
- ノードのレンダリング
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PPT、PPTX、ODP の SmartArt シェイプ ノードを管理します。プレゼンテーションを効率化するための明確なコードサンプルとヒントをご提供します。"
---

## **SmartArt ノードの追加**
Aspose.Slides for Python via .NET は、SmartArt シェイプを最も簡単に管理できるシンプルな API を提供しています。以下のサンプルコードは、SmartArt シェイプ内にノードおよび子ノードを追加する方法を示します。

- Create an instance of [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Add a new Node in SmartArt shape NodeCollection and set the text in TextFrame.
- Now, Add a Child Node in newly added SmartArt Node and set the text in TextFrame.
- Save the Presentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 目的のプレゼンテーションをロードする
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # 最初のスライド内のすべてのシェイプを走査する
    for shape in pres.slides[0].shapes:

        # シェイプが SmartArt タイプかどうかチェックする
        if type(shape) is art.SmartArt:
            # 新しい SmartArt ノードを追加する
            node1 = shape.all_nodes.add_node()
            # テキストを追加する
            node1.text_frame.text = "Test"

            # 親ノードに新しい子ノードを追加する。コレクションの末尾に追加される
            new_node = node1.child_nodes.add_node()

            # テキストを追加する
            new_node.text_frame.text = "New Node Added"

    # プレゼンテーションを保存する
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **特定の位置に SmartArt ノードを追加**
In the following sample code we have explained how to add the child nodes belonging to respective nodes of SmartArt shape at particular position.

- Create an instance of `Presentation` class.
- Obtain the reference of first slide by using its Index.
- Add a StackedList type SmartArt shape in accessed slide.
- Access the first node in added SmartArt shape.
- Now, add the Child Node for selected Node at position 2 and set its text.
- Save the Presentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# プレゼンテーションインスタンスを作成する
with slides.Presentation() as pres:
    # プレゼンテーションのスライドにアクセスする
    slide = pres.slides[0]

    # Smart Art IShape を追加する
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # インデックス 0 の SmartArt ノードにアクセスする
    node = smart.all_nodes[0]

    # 親ノードの位置 2 に新しい子ノードを追加する
    chNode = node.child_nodes.add_node_by_position(2)

    # テキストを追加する
    chNode.text_frame.text = "Sample text Added"

    # プレゼンテーションを保存する
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **SmartArt ノードへのアクセス**
The following sample code will help to access nodes inside SmartArt shape. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the SmartArt shape is added.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Traverse through all Nodes inside SmartArt Shape.
- Access and display information like SmartArt Node position, level and Text.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 必要なプレゼンテーションをロードする
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # 最初のスライド内のすべてのシェイプを走査する
    for shape in pres.slides[0].shapes:
        # シェイプが SmartArt タイプかどうか確認する
        if type(shape) is art.SmartArt:
            # SmartArt 内のすべてのノードを走査する
            for i in range(len(shape.all_nodes)):
                # インデックス i の SmartArt ノードにアクセスする
                node = shape.all_nodes[i]

                # SmartArt ノードのパラメータを出力する
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```


## **SmartArt 子ノードへのアクセス**
The following sample code will help to access the child nodes belonging to respective nodes of SmartArt shape.

- Create an instance of PresentationEx class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArtEx if it is SmartArt.
- Traverse through all Nodes inside SmartArt Shape.
- For every selected SmartArt shape Node, traverse through all Child Nodes inside particular node.
- Access and display information like Child Node position, level and Text.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 対象のプレゼンテーションをロードする
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # 最初のスライド内のすべてのシェイプを走査する
    for shape in pres.slides[0].shapes:
        # シェイプが SmartArt タイプかどうか確認する
        if type(shape) is art.SmartArt:
            # SmartArt 内のすべてのノードを走査する
            for node0 in shape.all_nodes:
                # 子ノードを走査する
                for j in range(len(node0.child_nodes)):
                    # SmartArt ノード内の子ノードにアクセスする
                    node = node0.child_nodes[j]

                    # SmartArt 子ノードのパラメータを出力する
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))
```


## **特定の位置にある SmartArt 子ノードへのアクセス**
In this example, we will learn to access the child nodes at some particular position belonging to respective nodes of SmartArt shape.

- Create an instance of `Presentation` class.
- Obtain the reference of first slide by using its Index.
- Add a StackedList type SmartArt shape.
- Access the added SmartArt shape.
- Access the node at index 0 for accessed SmartArt shape.
- Now, access the Child Node at position 1 for accessed SmartArt node using GetNodeByPosition() method.
- Access and display information like Child Node position, level and Text.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# プレゼンテーションをインスタンス化する
with slides.Presentation() as pres:
    # 最初のスライドにアクセスする
    slide = pres.slides[0]
    # 最初のスライドに SmartArt シェイプを追加する
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # インデックス 0 の SmartArt ノードにアクセスする
    node = smart.all_nodes[0]
    # 親ノードの位置 1 にある子ノードにアクセスする
    position = 1
    chNode = node.child_nodes[position] 
    # SmartArt 子ノードのパラメータを出力する
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))
```


## **SmartArt ノードの削除**
In this example, we will learn to remove the nodes inside SmartArt shape.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Check if the SmartArt has more than 0 nodes.
- Select the SmartArt node to be deleted.
- Now, remove the selected node using RemoveNode() method* Save the Presentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 目的のプレゼンテーションをロードする
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # 最初のスライド内のすべてのシェイプを走査する
    for shape in pres.slides[0].shapes:
        # シェイプが SmartArt タイプかどうか確認する
        if type(shape) is art.SmartArt:
            # シェイプを SmartArtEx に型キャストする
            if len(shape.all_nodes) > 0:
                # インデックス 0 の SmartArt ノードにアクセスする
                node = shape.all_nodes[0]

                # 選択したノードを削除する
                shape.all_nodes.remove_node(node)

    # プレゼンテーションを保存する
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **特定の位置にある SmartArt ノードの削除**
In this example, we will learn to remove the nodes inside SmartArt shape at particular position.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Select the SmartArt shape node at index 0.
- Now, check if the selected SmartArt node has more than 2 child nodes.
- Now, remove the node at Position 1 using RemoveNodeByPosition() method.
- Save the Presentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 目的のプレゼンテーションをロードする
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # 最初のスライド内のすべてのシェイプを走査する
    for shape in pres.slides[0].shapes:
        # シェイプが SmartArt タイプかどうか確認する
        if type(shape) is art.SmartArt:
            # シェイプを SmartArt に型キャストする
            if len(shape.all_nodes) > 0:
                # インデックス 0 の SmartArt ノードにアクセスする
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # 位置 1 の子ノードを削除する
                    node.child_nodes.remove_node(1)

    # プレゼンテーションを保存する
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **SmartArt の子ノードにカスタム位置を設定**
Now Aspose.Slides for Python via .NET support for setting SmartArtShape X and Y properties. The code snippet below shows how to set custom SmartArtShape position, size and rotation also please note that adding new nodes causes a recalculation of the positions and sizes of all nodes.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 目的のプレゼンテーションをロードする
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# SmartArt シェイプを新しい位置に移動する
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# SmartArt シェイプの幅を変更する
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# SmartArt シェイプの高さを変更する
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# SmartArt シェイプの回転を変更する
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```


## **アシスタント ノードの確認**
In the following sample code we will investigate how to identify Assistant Nodes in the SmartArt nodes collection and changing them.

- Create an instance of PresentationEx class and load the presentation with SmartArt Shape.
- Obtain the reference of second slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArtEx if it is SmartArt.
- Traverse through all nodes inside SmartArt shape and check if they are Assistant Nodes.
- Change the status of Assistant Node to normal node.
- Save the Presentation.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# プレゼンテーションインスタンスを作成する
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # 最初のスライド内のすべてのシェイプを走査する
    for shape in pres.slides[0].shapes:
        # シェイプが SmartArt タイプかどうか確認する
        if type(shape) is art.SmartArt:
            # SmartArt シェイプのすべてのノードを走査する
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # ノードがアシスタントノードかどうか確認する
                if node.is_assistant:
                    # アシスタントノードを false に設定し、通常のノードにする
                    node.is_assistant = False
    # プレゼンテーションを保存する
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **ノードの塗りつぶし形式の設定**
Aspose.Slides for Python via .NET makes it possible to add custom SmartArt shapes and set their fill formats. This article explains how to create and access SmartArt shapes and set their fill format using Aspose.Slides for Python via .NET.

Please follow the steps below:

- Create an instance of the `Presentation` class.
- Obtain the reference of a slide using its index.
- Add a SmartArt shape by setting its LayoutType.
- Set the FillFormat for the SmartArt shape nodes.
- Write the modified presentation as a PPTX file.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # スライドにアクセスする
    slide = presentation.slides[0]

    # SmartArt シェイプとノードを追加する
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # ノードの塗りつぶし色を設定する
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # プレゼンテーションを保存する
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **SmartArt 子ノードのサムネイル生成**
Developers can generate a thumbnail of Child node of a SmartArt by following the steps below:

1. Instantiate `Presentation` class that represents the PPTX file.
2. Add SmartArt.
3. Obtain the reference of a node by using its Index
4. Get the thumbnail image.
5. Save the thumbnail image in any desired image format.

The example below generating a thumbnail of SmartArt child node
```py
import aspose.slides as slides
import aspose.slides.smartart as art

# PPTX ファイルを表す Presentation クラスをインスタンス化する
with slides.Presentation() as presentation: 
    # SmartArt を追加する
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # インデックスを使用してノードの参照を取得する
    node = smart.nodes[1]

    # サムネイルを取得する
    with node.shapes[0].get_image() as bmp:
        # サムネイルを保存する
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```


## **FAQ**

**SmartArt のアニメーションはサポートされていますか？**

Yes. SmartArt is treated as a regular shape, so you can [apply standard animations](/slides/ja/python-net/shape-animation/) (entrance, exit, emphasis, motion paths) and adjust timing. You can also animate shapes inside SmartArt nodes when needed.

**内部 ID が不明な場合、スライド上の特定の SmartArt を確実に見つける方法はありますか？**

Assign and search by [alternative text](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/). Setting a distinctive AltText on the SmartArt lets you find it programmatically without relying on internal identifiers.

**プレゼンテーションを PDF に変換するとき、SmartArt の外観は保持されますか？**

Yes. Aspose.Slides renders SmartArt with high visual fidelity during [PDF export](/slides/ja/python-net/convert-powerpoint-to-pdf/), preserving layout, colors, and effects.

**SmartArt 全体の画像（プレビューやレポート用）を抽出できますか？**

Yes. You can render a SmartArt shape to [raster formats](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/get_image/) or to [SVG](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/write_as_svg/) for scalable vector output, making it suitable for thumbnails, reports, or web use.