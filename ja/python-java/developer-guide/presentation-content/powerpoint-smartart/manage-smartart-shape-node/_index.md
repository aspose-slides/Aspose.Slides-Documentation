---
title: プレゼンテーションで Python を使用して SmartArt シェイプ ノードを管理する
linktitle: SmartArt シェイプ ノード
type: docs
weight: 30
url: /ja/python-java/manage-smartart-shape-node/
keywords:
- SmartArt ノード
- 子ノード
- ノードの追加
- ノードの位置
- ノードへのアクセス
- ノードの削除
- カスタム位置
- アシスタント ノード
- 塗りつぶし形式
- ノードのレンダリング
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して PPT および PPTX の SmartArt シェイプ ノードを管理します。コードサンプルとヒントでプレゼンテーションを効率化してください。"
---
## **概要**

PowerPoint のプレゼンテーションにおける SmartArt グラフィックは、テキストを含むノードで構成され、図の構造を定義します。Aspose.Slides を使用すると、これらの SmartArt ノードをプログラムで操作できます。新しいノードや子ノードの追加、特定の位置への子ノードの挿入、既存ノードへのアクセス、テキスト、レベル、位置の取得が可能です。

この記事では、SmartArt シェイプ ノードの管理方法について説明します。ノードの削除、インデックスまたは位置による子ノードの操作、アシスタント ノードを通常ノードに変更、SmartArt ノード シェイプの位置・サイズ・回転の調整、ノードの塗りつぶし形式の設定、SmartArt 子ノードのサムネイル画像生成方法を示します。

## **SmartArt ノードの追加**
Aspose.Slides for Python via Java は SmartArt シェイプを管理する API を提供します。以下の例は、SmartArt シェイプにノードと子ノードを追加します。

1. SmartArt シェイプを含むプレゼンテーションを読み込むために、[プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで最初のスライドを取得します。
3. 最初のスライド上のすべてのシェイプを反復処理します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) インスタンスかどうか確認します。
5. [新しいノードを追加](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartnodecollection/#addNode) して、SmartArt シェイプの [ノード コレクション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/#getAllNodes) に追加し、[TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) を介してテキストを設定します。
6. [追加](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartnodecollection/#addNode) a [子ノード](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartnode/#getChildNodes) を新しいノードに追加し、[TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) を介してテキストを設定します。
7. プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **特定の位置に SmartArt ノードを追加**
以下の例は、SmartArt ノード内の特定の位置に子ノードを追加します。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで最初のスライドを取得します。
3. スライドに [StackedList](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartlayouttype/#StackedList) レイアウトの [SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) シェイプを追加します。
4. 追加した SmartArt シェイプの最初のノードにアクセスします。
5. [addNodeByPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) を使用して位置 2 に子ノードを追加し、テキストを設定します。
6. プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt ノードへのアクセス**
以下の例は、SmartArt シェイプ内のノードにアクセスします。[getLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/#getLayout) が返すレイアウトは読み取り専用で、SmartArt シェイプが追加されたときに設定されます。

1. SmartArt シェイプを含むプレゼンテーションを読み込むために、[プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで最初のスライドを取得します。
3. 最初のスライド上のすべてのシェイプを反復処理します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) インスタンスかどうか確認します。
5. SmartArt シェイプ内のすべての [ノード](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/#getAllNodes) を反復処理します。
6. 各 SmartArt ノードの位置、レベル、テキストを読み取り表示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **SmartArt 子ノードへのアクセス**
以下の例は、SmartArt シェイプ内の各ノードの子ノードにアクセスします。

1. SmartArt シェイプを含むプレゼンテーションを読み込むために、[プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで最初のスライドを取得します。
3. 最初のスライド上のすべてのシェイプを反復処理します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) インスタンスかどうか確認します。
5. SmartArt シェイプ内のすべての [ノード](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/#getAllNodes) を反復処理します。
6. 各ノードについて、その [子ノード](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartnode/#getChildNodes) を反復処理します。
7. 子ノードの位置、レベル、テキストを読み取り表示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **特定の位置にある SmartArt 子ノードへのアクセス**
以下の例は、親ノードのコレクション内で特定のインデックスにある子ノードにアクセスします。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで最初のスライドを取得します。
3. [StackedList](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartlayouttype/#StackedList) レイアウトの SmartArt シェイプを追加します。
4. 追加した SmartArt シェイプにアクセスします。
5. SmartArt シェイプ内のインデックス 0 のノードにアクセスします。
6. [get_Item](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartnodecollection/#get_Item) を使用してインデックス 1 の子ノードにアクセスします。
7. 子ノードの位置、レベル、テキストを読み取り表示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **SmartArt ノードの削除**
以下の例は、SmartArt シェイプからノードを削除します。

1. SmartArt シェイプを含むプレゼンテーションを読み込むために、[プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで最初のスライドを取得します。
3. 最初のスライド上のすべてのシェイプを反復処理します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) インスタンスかどうか確認します。
5. SmartArt シェイプに少なくとも 1 つのノードが含まれていることを確認します。
6. 削除する SmartArt ノードを選択します。
7. [removeNode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartnodecollection/#removeNode) を使用して選択したノードを削除します。
8. プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **特定の位置にある SmartArt ノードからの削除**
以下の例は、SmartArt ノードのコレクション内で特定のインデックスにある子ノードを削除します。

1. SmartArt シェイプを含むプレゼンテーションを読み込むために、[プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで最初のスライドを取得します。
3. 最初のスライド上のすべてのシェイプを反復処理します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) インスタンスかどうか確認します。
5. インデックス 0 の SmartArt ノードが存在すればアクセスします。
6. 選択した SmartArt ノードが少なくとも 2 つの子ノードを持っていることを確認します。
7. [removeNode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartnodecollection/#removeNode) を使用してインデックス 1 の子ノードを削除します。
8. プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt オブジェクト内の子ノードにカスタム位置を設定**
Aspose.Slides for Python via Java は、[SmartArtShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartshape/) の位置を [setX](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#setX) と [setY](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#setY) で設定することをサポートします。以下の例は、SmartArt ノード シェイプのカスタム位置、サイズ、回転を設定します。新しいノードを追加すると、すべてのノードの位置とサイズが再計算されます。カスタム位置指定により、必要に応じてノードを配置できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **アシスタント ノードの確認**
{{% alert color="info" title="Note" %}} 
このセクションでは、Aspose.Slides for Python via Java を使用してプログラムからプレゼンテーションスライドに追加された SmartArt シェイプを検証します。 
{{% /alert %}} 

以下のソース SmartArt シェイプが例で使用されます。

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**図: スライド上のソース SmartArt シェイプ**|

以下の例は、SmartArt ノード コレクション内のアシスタント ノードを特定し、通常ノードに変更します。

1. SmartArt シェイプを含むプレゼンテーションを読み込むために、[プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで最初のスライドを取得します。
3. 最初のスライド上のすべてのシェイプを反復処理します。
4. シェイプが [SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) インスタンスかどうか確認します。
5. SmartArt シェイプ内のすべてのノードを反復処理し、[Assistant Nodes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartnode/#isAssistant) かどうかチェックします。
6. 各アシスタント ノードを通常ノードに変更します。
7. プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**図: スライド上の SmartArt シェイプでアシスタント ノードが変更された様子**|

## **ノードの塗りつぶし形式の設定**
Aspose.Slides for Python via Java は、カスタム SmartArt シェイプを追加し、その塗りつぶし形式を設定できるようにします。本記事では、SmartArt シェイプを作成およびアクセスし、塗りつぶし形式を設定する方法を説明します。

以下の手順に従ってください。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. [ClosedChevronProcess](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess) レイアウトの [SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) シェイプを追加します。
4. SmartArt シェイプ ノードの [FillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getFillFormat) を設定します。
5. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt 子ノードのサムネイル生成**
SmartArt 子ノードのサムネイルを生成する手順は次のとおりです。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. [SmartArt シェイプを追加](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addSmartArt) します。
3. インデックスでノードを取得します。
4. サムネイル画像を取得します。
5. 任意の画像形式でサムネイル画像を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**SmartArt アニメーションはサポートされていますか？**

はい。SmartArt は通常のシェイプとして扱われるため、[標準アニメーション](/slides/ja/python-java/shape-animation/)（入場、退出、強調、動きのパス）を適用し、タイミングを調整できます。必要に応じて、SmartArt ノード内のシェイプにもアニメーションを付与できます。

**内部 ID が不明な場合、スライド上の特定の SmartArt を確実に見つける方法はありますか？**

[代替テキスト](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getAlternativeText) を設定して検索します。SmartArt に固有の代替テキストを付与すれば、内部識別子に依存せずプログラムで取得できます。

**プレゼンテーションを PDF に変換したとき、SmartArt の外観は保持されますか？**

はい。Aspose.Slides は [PDF エクスポート](/slides/ja/python-java/convert-powerpoint-to-pdf/) 時に SmartArt を高い視覚忠実度でレンダリングし、レイアウト、色、効果を保持します。

**SmartArt 全体の画像を抽出してプレビューやレポートに使用できますか？**

はい。SmartArt シェイプを [ラスタ形式](/slides/ja/python-java/aspose.slides/shape/#getImage) または [SVG](/slides/ja/python-java/aspose.slides/shape/#writeAsSvgToBytes) にレンダリングでき、サムネイル、レポート、Web 用に適した形式で取得できます。