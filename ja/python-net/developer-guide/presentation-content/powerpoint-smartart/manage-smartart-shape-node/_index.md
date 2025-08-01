---
title: プレゼンテーションで SmartArt 形状ノードを Python で管理する
linktitle: SmartArt 形状ノード
type: docs
weight: 30
url: /ja/python-net/manage-smartart-shape-node/
keywords:
- SmartArt ノード
- 子ノード
- ノード追加
- ノード位置
- ノードアクセス
- ノード削除
- カスタム位置
- アシスタントノード
- 塗りつぶし形式
- ノードレンダリング
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PPT、PPTX、ODP の SmartArt 形状ノードを管理します。明確なコードサンプルとヒントを入手して、プレゼンテーションを効率化しましょう。"
---

## **SmartArtノードの追加**
Aspose.Slides for Python via .NETは、SmartArt図形を最も簡単に管理するためのシンプルなAPIを提供しています。以下のサンプルコードは、SmartArt図形内にノードと子ノードを追加するのに役立ちます。

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべての図形を走査します。
- 図形がSmartArtタイプであるかどうかを確認し、SmartArtであれば選択した図形をSmartArtに型キャストします。
- SmartArt図形のNodeCollectionに新しいノードを追加し、TextFrameにテキストを設定します。
- 次に、新しく追加したSmartArtノードに子ノードを追加し、TextFrameにテキストを設定します。
- プレゼンテーションを保存します。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# プレゼンテーションの読み込み
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # 最初のスライド内のすべての図形を走査
    for shape in pres.slides[0].shapes:

        # 図形がSmartArtタイプかどうかを確認
        if type(shape) is art.SmartArt:
            # 新しいSmartArtノードを追加
            node1 = shape.all_nodes.add_node()
            # テキストを追加
            node1.text_frame.text = "テスト"

            # 親ノードに新しい子ノードを追加します。これはコレクションの最後に追加されます
            new_node = node1.child_nodes.add_node()

            # テキストを追加
            new_node.text_frame.text = "新しいノードが追加されました"

    # プレゼンテーションを保存
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **特定の位置にSmartArtノードを追加**
以下のサンプルコードでは、特定の位置に各SmartArt図形に属する子ノードを追加する方法を説明しています。

- `Presentation`クラスのインスタンスを作成する。
- インデックスを使用して最初のスライドの参照を取得します。
- アクセスしたスライドにスタックリストタイプのSmartArt図形を追加します。
- 追加したSmartArt図形の最初のノードにアクセスします。
- 次に、選択したノードの位置2に子ノードを追加し、そのテキストを設定します。
- プレゼンテーションを保存します。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# プレゼンテーションインスタンスの作成
with slides.Presentation() as pres:
    # プレゼンテーションスライドにアクセス
    slide = pres.slides[0]

    # SmartArt IShapeを追加
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # 追加したSmartArtのノードにアクセス
    node = smart.all_nodes[0]

    # 親ノードの位置2に新しい子ノードを追加
    chNode = node.child_nodes.add_node_by_position(2)

    # テキストを追加
    chNode.text_frame.text = "サンプルテキストが追加されました"

    # プレゼンテーションを保存
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```




## **SmartArtノードにアクセス**
以下のサンプルコードは、SmartArt図形内のノードにアクセスするのに役立ちます。SmartArtのLayoutTypeは読み取り専用であり、SmartArt図形が追加されたときにのみ設定されることに注意してください。

- `Presentation`クラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。

- インデックスを使用して最初のスライドの参照を取得します。

- 最初のスライド内のすべての図形を走査します。

- 図形がSmartArtタイプであるかどうかを確認し、SmartArtであれば選択した図形をSmartArtに型キャストします。

- SmartArt図形内のすべてのノードを走査します。

- SmartArtノードの位置、レベル、およびテキストなどの情報にアクセスして表示します。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# プレゼンテーションの読み込み
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # 最初のスライド内のすべての図形を走査
    for shape in pres.slides[0].shapes:
        # 図形がSmartArtタイプかどうかを確認
        if type(shape) is art.SmartArt:
            # SmartArt内のすべてのノードを走査
            for i in range(len(shape.all_nodes)):
                # インデックスiのSmartArtノードにアクセス
                node = shape.all_nodes[i]

                # SmartArtノードのパラメータを印刷
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
  ```

  


## **SmartArt子ノードにアクセス**
以下のサンプルコードは、SmartArt図形の各ノードに属する子ノードにアクセスするのに役立ちます。

- PresentationExクラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべての図形を走査します。
- 図形がSmartArtタイプであるかどうかを確認し、SmartArtであれば選択した図形をSmartArtExに型キャストします。
- SmartArt図形内のすべてのノードを走査します。
- 選択したSmartArt図形のノードごとに、特定のノード内のすべての子ノードを走査します。
- 子ノードの位置、レベル、およびテキストなどの情報にアクセスして表示します。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# プレゼンテーションの読み込み
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # 最初のスライド内のすべての図形を走査
    for shape in pres.slides[0].shapes:
        # 図形がSmartArtタイプかどうかを確認
        if type(shape) is art.SmartArt:
            # SmartArt内のすべてのノードを走査
            for node0 in shape.all_nodes:
                # 子ノードを走査
                for j in range(len(node0.child_nodes)):
                    # SmartArtノード内の子ノードにアクセス
                    node = node0.child_nodes[j]

                    # SmartArt子ノードのパラメータを印刷
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```



## **特定の位置のSmartArt子ノードにアクセス**
この例では、SmartArt図形のそれぞれのノードに属する特定の位置にある子ノードにアクセスする方法を学びます。

- `Presentation`クラスのインスタンスを作成する。
- インデックスを使用して最初のスライドの参照を取得します。
- スタックリストタイプのSmartArt図形を追加します。
- 追加されたSmartArt図形にアクセスします。
- アクセスしたSmartArt図形のインデックス0のノードにアクセスします。
- 次に、GetNodeByPosition()メソッドを使用してアクセスしたSmartArtノードの位置1の子ノードにアクセスします。
- 子ノードの位置、レベル、およびテキストなどの情報にアクセスして表示します。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# プレゼンテーションのインスタンス化
with slides.Presentation() as pres:
    # 最初のスライドにアクセス
    slide = pres.slides[0]
    # 最初のスライドにSmartArt図形を追加
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # アクセスしたSmartArtノードのインデックス0にアクセス
    node = smart.all_nodes[0]
    # アクセスしたSmartArtノードの親ノードの位置1の子ノードにアクセス
    position = 1
    chNode = node.child_nodes[position] 
    # SmartArt子ノードのパラメータを印刷
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```



## **SmartArtノードを削除**
この例では、SmartArt図形内のノードを削除する方法を学びます。

- `Presentation`クラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべての図形を走査します。
- 図形がSmartArtタイプであるかどうかを確認し、SmartArtであれば選択した図形をSmartArtに型キャストします。
- SmartArtが0以上のノードを持っているかどうかを確認します。
- 削除するSmartArtノードを選択します。
- 次に、RemoveNode()メソッドを使用して選択したノードを削除します。プレゼンテーションを保存します。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# プレゼンテーションの読み込み
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # 最初のスライド内のすべての図形を走査
    for shape in pres.slides[0].shapes:
        # 図形がSmartArtタイプかどうかを確認
        if type(shape) is art.SmartArt:
            # SmartArtExに型キャスト
            if len(shape.all_nodes) > 0:
                # インデックス0のSmartArtノードにアクセス
                node = shape.all_nodes[0]

                # 選択したノードを削除
                shape.all_nodes.remove_node(node)

    # プレゼンテーションを保存
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **特定の位置のSmartArtノードを削除**
この例では、特定の位置でSmartArt図形内のノードを削除する方法を学びます。

- `Presentation`クラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべての図形を走査します。
- 図形がSmartArtタイプであるかどうかを確認し、SmartArtであれば選択した図形をSmartArtに型キャストします。
- インデックス0のSmartArt図形ノードを選択します。
- 次に、選択したSmartArtノードに2つ以上の子ノードがあるかどうかを確認します。
- 次に、RemoveNodeByPosition()メソッドを使用して位置1のノードを削除します。
- プレゼンテーションを保存します。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# プレゼンテーションの読み込み
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # 最初のスライド内のすべての図形を走査
    for shape in pres.slides[0].shapes:
        # 図形がSmartArtタイプかどうかを確認
        if type(shape) is art.SmartArt:
            # SmartArtに型キャスト
            if len(shape.all_nodes) > 0:
                # インデックス0のSmartArtノードにアクセス
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # 位置1の子ノードを削除
                    node.child_nodes.remove_node(1)

    # プレゼンテーションを保存
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```



## **SmartArt内の子ノードのカスタム位置を設定**
Aspose.Slides for Python via .NETでは、SmartArtShapeのXおよびYプロパティを設定できます。以下のコードスニペットは、カスタムSmartArtShapeの位置、サイズ、回転を設定する方法を示しています。また、新しいノードを追加すると、すべてのノードの位置とサイズが再計算されることに注意してください。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# プレゼンテーションの読み込み
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
    smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

    # SmartArt図形を新しい位置に移動
    node = smart.all_nodes[1]
    shape = node.shapes[1]
    shape.x += (shape.width * 2)
    shape.y -= (shape.height / 2)

    # SmartArt図形の幅を変更
    node = smart.all_nodes[2]
    shape = node.shapes[1]
    shape.width += (shape.width / 2)

    # SmartArt図形の高さを変更
    node = smart.all_nodes[3]
    shape = node.shapes[1]
    shape.height += (shape.height / 2)

    # SmartArt図形の回転を変更
    node = smart.all_nodes[4]
    shape = node.shapes[1]
    shape.rotation = 90

    pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```



## **アシスタントノードの確認**
以下のサンプルコードでは、SmartArtノードコレクション内のアシスタントノードを特定し、変更する方法を調査します。

- PresentationExクラスのインスタンスを作成し、SmartArt図形を含むプレゼンテーションをロードします。
- インデックスを使用して2番目のスライドの参照を取得します。
- 最初のスライド内のすべての図形を走査します。
- 図形がSmartArtタイプであるかどうかを確認し、SmartArtであれば選択した図形をSmartArtExに型キャストします。
- SmartArt図形内のすべてのノードを走査し、それらがアシスタントノードであるかどうかを確認します。
- アシスタントノードのステータスを通常のノードに変更します。
- プレゼンテーションを保存します。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# プレゼンテーションインスタンスの作成
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # 最初のスライド内のすべての図形を走査
    for shape in pres.slides[0].shapes:
        # 図形がSmartArtタイプかどうかを確認
        if type(shape) is art.SmartArt:
            # SmartArt形状のすべてのノードを走査
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # ノードがアシスタントノードかどうかを確認
                if node.is_assistant:
                    # アシスタントノードをfalseに設定し、通常のノードにします
                    node.is_assistant = False
    # プレゼンテーションを保存
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **ノードの塗りつぶしフォーマットを設定**
Aspose.Slides for Python via .NETでは、カスタムSmartArt図形を追加し、その塗りつぶしフォーマットを設定することができます。この記事では、Aspose.Slides for Python via .NETを使用してSmartArt図形を作成およびアクセスし、それらの塗りつぶしフォーマットを設定する方法を説明します。

以下の手順に従ってください：

- `Presentation`クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- LayoutTypeを設定してSmartArt図形を追加します。
- SmartArt図形ノードのFillFormatを設定します。
- 修正されたプレゼンテーションをPPTXファイルに書き込みます。

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # スライドにアクセス
    slide = presentation.slides[0]

    # SmartArt図形とノードを追加
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "いくつかのテキスト"

    # ノードの塗りつぶし色を設定
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # プレゼンテーションを保存
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **SmartArt子ノードのサムネイルを生成**
開発者は以下の手順に従ってSmartArtの子ノードのサムネイルを生成できます。

1. PPTXファイルを表す`Presentation`クラスをインスタンス化します。
1. SmartArtを追加します。
1. インデックスを使用してノードの参照を取得します。
1. サムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

以下の例は、SmartArt子ノードのサムネイルを生成しています。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# PPTXファイルを表すPresentationクラスをインスタンス化 
with slides.Presentation() as presentation: 
    # SmartArtを追加 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # インデックスを使用してノードの参照を取得  
    node = smart.nodes[1]

    # サムネイルを取得
    with node.shapes[0].get_image() as bmp:
        # サムネイルを保存
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```