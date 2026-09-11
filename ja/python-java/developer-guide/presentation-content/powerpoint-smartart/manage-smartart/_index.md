---
title: Python を使用した PowerPoint プレゼンテーションでの SmartArt の管理
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt テキスト
- レイアウト タイプ
- 非表示 プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint の SmartArt を構築および編集する方法を学び、スライド デザインと自動化を高速化する明確なコードサンプルを提供します。"
---
## **概要**

SmartArt は、ノード、ノード シェイプ、レイアウトで構成された PowerPoint の図です。Aspose.Slides for Python via Java を使用すると、SmartArt を作成し、ノードからテキストを読み取り、レイアウトを変更し、非表示ノードを検査し、組織図のレイアウトを構成し、画像組織図を作成できます。

## **SmartArt オブジェクトからテキストを取得する**

SmartArt のノードは 1 つ以上のシェイプを含むことができます。表示されているテキストを取得するには、[SmartArt.getAllNodes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/#getAllNodes) を反復処理し、次に [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartshape/#getTextFrame) が返す [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) を読み取ります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape

        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **SmartArt オブジェクトのレイアウト タイプを変更する**

SmartArt のレイアウトは、ノードの配置と接続方法を制御します。次の例は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartlayouttype/) の `BasicBlockList` 値で SmartArt オブジェクトを作成し、`BasicProcess` 値に変更してプレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt ノードが非表示かどうかを確認する**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartnode/#isHidden) は、ノードが SmartArt データ モデルで非表示かどうかを示します。選択されたレイアウトがノードを可視の図要素として表示しなくても、非表示ノードは構造内に存在する可能性があります。

次の例は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartlayouttype/) の `RadialCycle` 値を使用する SmartArt オブジェクトにノードを追加し、そのノードの非表示状態を確認します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **組織図レイアウトの取得または設定**

組織図レイアウトを使用する SmartArt 図では、[SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) と [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) により、親ノードの下に子ノードが配置される方法が定義されます。たとえば、選択された [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/organizationchartlayouttype/) に応じて、子ノードを左側、右側、または両側からハングさせることができます。

次の例は、組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/organizationchartlayouttype/) の `LeftHanging` 値に設定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **画像組織図の作成**

画像組織図は、画像プレースホルダーを含む階層図向けに設計された SmartArt レイアウトです。スライドに SmartArt オブジェクトを追加する際は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartartlayouttype/) の `PictureOrganizationChart` 値を使用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**SmartArt は RTL 言語向けのミラーリングや反転をサポートしていますか？**

はい。選択された SmartArt レイアウトが反転をサポートしている場合、[SmartArt.setReversed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/#setReversed) メソッドは図の方向を左から右へから右から左へ、またはその逆に切り替えます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーして書式を保持するにはどうすればよいですか？**

SmartArt を含むスライド上で、[ShapeCollection.addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addClone) を使用して [SmartArt シェイプをクローン](/slides/ja/python-java/shape-manipulations/) するか、SmartArt を含むスライド全体を [クローン](/slides/ja/python-java/clone-slides/) することができます。どちらの方法もサイズ、位置、書式設定を保持します。

**SmartArt をプレビューや Web エクスポート用のラスタ画像にレンダリングするにはどうすればよいですか？**

[スライドをレンダリング](/slides/ja/python-java/convert-powerpoint-to-png/) またはプレゼンテーション全体を PNG または JPEG に変換します。SmartArt はスライドの一部としてレンダリングされます。

**複数の SmartArt がある場合、スライド上で特定の SmartArt オブジェクトを見つけるにはどうすればよいですか？**

SmartArt シェイプに固有の [Shape.getAlternativeText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getAlternativeText) または [Shape.getName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getName) の値を設定し、[BaseSlide.getShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getShapes) でその値を検索し、該当するシェイプが [SmartArt](https://reference.aspose.com/slides/ja/python-java/aspose.slides/smartart/) であることを確認します。