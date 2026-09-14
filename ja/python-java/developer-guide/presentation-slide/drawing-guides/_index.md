---
title: Python でプレゼンテーションの描画ガイドを管理する
linktitle: 描画ガイド
type: docs
weight: 85
url: /ja/python-java/drawing-guides/
keywords:
- 描画ガイド
- 水平ガイド
- 垂直ガイド
- 配置ガイド
- スライドビュー
- マスタースライド
- レイアウトスライド
- ノートマスター
- ハンドアウトマスター
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーションに水平および垂直の描画ガイドを追加、アクセス、クリアします。"
---
## **概要**

描画ガイドは、PowerPoint でプレゼンテーションを編集する際に、ユーザーが図形を一貫して配置できるようにする、調整可能な水平および垂直の線です。特に、アプリケーションがプレゼンテーションを生成し、後で手動で調整する場合に便利です。アプリケーションは、コンテンツを追加または移動するときに作者が従うべき同じ配置補助ツールを保存できます。

描画ガイドは編集用の補助ツールであり、スライドのコンテンツではありません。スライドショーやレンダリングされた出力には表示されません。Aspose.Slides for Python via Java は、これらを [DrawingGuidesCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/drawingguidescollection/) クラスで公開します。ガイドは [DrawingGuide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/drawingguide/) によって表され、向き、位置、カラーを持ちます。

位置は、対象のスライドまたはマスターの左上隅からのポイントで測定されます。垂直ガイドは水平座標を使用し、通常は0からスライド幅までの範囲です。水平ガイドは垂直座標を使用し、通常は0からスライド高さまでの範囲です。

## **スライドビューにガイドを追加**

通常のスライドを編集している間に表示されるガイドを管理するには、[CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) を使用します。[DrawingGuidesCollection.add](https://reference.aspose.com/slides/ja/python-java/aspose.slides/drawingguidescollection/#add) を呼び出し、[Orientation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/orientation/) の値とポイント単位の位置を指定します。

次の例は、スライドの中心の右側に垂直ガイドを 1 本、下側に水平ガイドを 1 本追加します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **描画ガイドへのアクセス**

[DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ja/python-java/aspose.slides/drawingguidescollection/#getCount) と [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ja/python-java/aspose.slides/drawingguidescollection/#get_Item) メソッドは、既存のガイドへのアクセスを提供します。[DrawingGuide.getOrientation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/drawingguide/#getOrientation)、[DrawingGuide.getPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/drawingguide/#getPosition)、[DrawingGuide.getColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/drawingguide/#getColor) メソッドは値を返し、対応するセッターメソッドで変更することもできます。

次の例は、上記で作成したプレゼンテーションからスライドビューのガイドを読み取ります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **マスタースライドとレイアウトスライドにガイドを追加**

スライドマスターおよびその各レイアウトスライドは、それぞれ独自の描画ガイドコレクションを持つことができます。マスタースライドには [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#getDrawingGuides) を、レイアウトスライドには [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#getDrawingGuides) を使用します。

次の例は、最初のマスタースライドに垂直ガイドを、最初のレイアウトスライドに水平ガイドを追加します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ノートマスターとハンドアウトマスターにガイドを追加**

ノートマスターとハンドアウトマスターも描画ガイドをサポートしています。これらのコレクションにアクセスするには、[MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masternotesslide/#getDrawingGuides) と [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) を使用します。プレゼンテーションにこれらのマスターが含まれていない場合、`MasterNotesSlideManager.setDefaultMasterNotesSlide` または `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` がデフォルトのマスターを作成し、返します。

次の例は、ノートマスターに水平ガイドを、ハンドアウトマスターに垂直ガイドを追加します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **描画ガイドのクリア**

特定のコレクションからすべてのガイドを削除するには、[DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/drawingguidescollection/#clear) を呼び出します。1 つのコレクションをクリアしても、別のスコープに保存されているガイドには影響しません。

次の例は、スライドビューのガイドと、スライドマスター、レイアウトスライド、ノートマスター、ハンドアウトマスター上のすべてのガイドを、欠落しているマスターを作成せずにクリアします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**描画ガイドはスライドショーやエクスポートされた画像に表示されますか？**  
いいえ。描画ガイドは編集用の配置補助ツールであり、プレゼンテーションのコンテンツとして描画されません。

**描画ガイドを個々の通常スライドに直接追加できますか？**  
通常スライドの編集用ガイドはプレゼンテーションのスライドビュー プロパティに保存されます。スライドマスター、レイアウトスライド、ノートマスター、ハンドアウトマスター用の別個のガイドコレクションが用意されています。

**ガイドの位置にはどの単位が使用されますか？**  
位置はポイントで指定され、72 ポイントが 1 インチに相当します。垂直位置は左端から、水平位置は上端から測定されます。

**描画ガイドをクリアすると、シェイプが削除されたりスライドのコンテンツが変更されたりしますか？**  
いいえ。[DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/drawingguidescollection/#clear) メソッドは、選択されたコレクション内のガイドのみを削除します。シェイプやその他のスライドコンテンツは変更されません。