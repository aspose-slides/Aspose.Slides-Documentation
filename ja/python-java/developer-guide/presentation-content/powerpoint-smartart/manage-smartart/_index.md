---
title: Python を使用して PowerPoint プレゼンテーションの SmartArt を管理する
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt テキスト
- レイアウトタイプ
- 非表示プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、明確なコードサンプルで PowerPoint SmartArt の構築と編集を学び、スライドのデザインと自動化を高速化します。"
---
## **概要**

SmartArt はノード、ノードシェイプ、およびレイアウトで構成される PowerPoint の図です。Aspose.Slides for Python via Java を使用すると、SmartArt の作成、ノードからのテキスト取得、レイアウトの変更、非表示ノードの検査、組織図レイアウトの構成、画像組織図の作成が可能です。

## **SmartArt オブジェクトからテキストを取得する**

SmartArt ノードは 1 つ以上のシェイプを含むことができます。ノードシェイプのテキストを取得するには、[SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes) を反復処理し、次に [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame) が返す [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) を読み取ります。

このサンプルは、少なくとも 1 枚のスライドとそのスライド上の最初のシェイプとして SmartArt オブジェクトが配置されたプレゼンテーションが必要です。利用可能なテキストフレームをコンソールに出力します。

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

## **SmartArt オブジェクトのレイアウトタイプを変更する**

SmartArt のレイアウトはノードの配置と接続方法を制御します。次の例は、[SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 値で SmartArt オブジェクトを作成し、`BasicProcess` 値に変更してプレゼンテーションを保存します。[ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) に渡す位置とサイズはポイント単位で測定されます。レイアウトを変更するには [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) を使用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt ノードが非表示かどうかを確認する**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) はノードが SmartArt データモデルで非表示かどうかを示します。選択したレイアウトが可視的な図要素として表示しなくても、非表示ノードは構造内に存在する可能性があります。

以下の例は、[SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` 値を使用する SmartArt オブジェクトにノードを追加し、追加したノードの非表示状態を確認します。ノードが非表示の場合はメッセージを出力し、図を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **組織図レイアウトの取得または設定**

組織図レイアウトを使用する SmartArt 図の場合、[SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) と [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) によって、子ノードが親ノードの下でどのように配置されるかを定義します。たとえば、選択した [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) に応じて、子ノードを左側、右側、または両側に吊り下げることができます。

以下の例は組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` に設定します。ゼロベースインデックス `0` が最上位ノードを指し、その子ノードは選択された配置を使用します。変更後のプレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **画像組織図の作成**

画像組織図は、画像プレースホルダーを含む階層図向けに設計された SmartArt レイアウトです。スライドに SmartArt オブジェクトを追加する際に [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 値を使用します。この例は画像プレースホルダー付きの図を保存しますが、プレースホルダーに画像は設定しません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **レガシーダイアグラムをシェイプのグループに変換する**

既存のプレゼンテーションをモダナイズする際、PowerPoint 97‑2003 で作成された組織図を更新する必要がある場合があります。Aspose.Slides はこれらのレガシーダイアグラムを [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) オブジェクトとして表します。[LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) を使用してダイアグラムをシェイプのグループに変換し、個々の視覚要素を編集できるようにします。詳細は [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) を参照してください。

変換によりシェイプコレクションに新しいグループが追加され、元のダイアグラムは削除されません。変換が正常に完了したら、[ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) で元のダイアグラムを削除し、重複コンテンツを防ぎます。変換前にレガシーダイアグラムをリストに集めておくと、シェイプの追加・削除がイテレーションを乱さないようにできます。

以下の例はプレゼンテーションを開き、すべてのスライドを検索し、ダイアグラムをシェイプのグループに変換して、更新されたプレゼンテーションを PPTX として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

保存されたプレゼンテーションには、変換されたレガシーダイアグラムの代わりに編集可能なシェイプのグループが配置され、元のダイアグラムは残っていません。PowerPoint で PPTX を開くと、各グループ内のテキスト、塗りつぶし、位置などの個別要素を編集できます。

## **よくある質問**

**SmartArt は RTL 言語向けのミラーリングまたは反転をサポートしていますか？**

はい。[SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) メソッドは、選択された SmartArt レイアウトが反転をサポートしている場合に、図の方向を左から右へ、または右から左へ、あるいは元に戻すことができます。

**書式設定を保持したまま、同じスライドまたは別のプレゼンテーションに SmartArt をコピーするにはどうすればよいですか？**

[ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) を使用して SmartArt シェイプを [クローン](/slides/ja/python-java/shape-manipulations/) するか、SmartArt を含むスライド全体を [クローン](/slides/ja/python-java/clone-slides/) してください。どちらの方法でもサイズ、位置、書式設定が保持されます。

**SmartArt をプレビューや Web エクスポート用のラスタ画像にレンダリングするにはどうすればよいですか？**

[スライドをレンダリング](/slides/ja/python-java/convert-powerpoint-to-png/) するか、プレゼンテーション全体を PNG または JPEG に変換します。SmartArt はスライドの一部としてレンダリングされます。

**複数の SmartArt オブジェクトがある場合、特定のオブジェクトをスライド上で見つけるにはどうすればよいですか？**

[Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) または [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) を使用して SmartArt シェイプに固有の代替テキストまたは名前を割り当て、[BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) でその値を検索し、一致するシェイプが [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) であることを確認します。