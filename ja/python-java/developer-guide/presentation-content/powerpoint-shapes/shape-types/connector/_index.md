---
title: Python（Java）でプレゼンテーションのコネクタを管理
linktitle: コネクタ
type: docs
weight: 10
url: /ja/python-java/connector/
keywords:
- コネクタ
- コネクタ タイプ
- コネクタ ポイント
- コネクタ ライン
- コネクタ 角度
- 接続サイト
- 調整ポイント
- 図形を接続
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint の直線、ベンド、曲線コネクタを追加、接続、再ルーティング、調整、検査する方法を学びます。"
---
## **概要**

コネクタは、いずれかの図形が移動したときでも 2 つの図形に付着したままにできる線です。その端は接続サイトに接続され、PowerPoint では緑のドットで表されます。曲がったり曲線状のコネクタの一部には、オレンジのドットで表される調整ポイントがあり、個々のコネクタセグメントの位置を制御できます。

Aspose.Slides はコネクタを [Connector](https://reference.aspose.com/slides/ja/python-java/aspose.slides/connector/) クラスで表します。コネクタを作成し、端を図形に接続し、接続サイトを選択し、再ルーティングし、調整ポイントを持つコネクタのジオメトリを変更できます。

## **コネクタのタイプ**

[ShapeType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/) クラスには、直線、ベンド、曲線コネクタのプリセットが含まれます。以下の表は、利用可能なコネクタジオメトリと各プリセットで定義される調整ポイントの数を示しています。

| コネクタ | 画像 | 調整ポイントの数 |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

調整ポイントの数と意味は、選択されたコネクタプリセットの一部です。2 つの異なるコネクタタイプが同じコレクションレイアウトを提供すると想定しないでください。

## **2つの図形を接続する**

[ShapeCollection.addConnector](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addConnector) を使用してコネクタを追加し、[Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/connector/#setStartShapeConnectedTo) と [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/connector/#setEndShapeConnectedTo) を使用して端を接続します。両端が接続された後、[Connector.reroute](https://reference.aspose.com/slides/ja/python-java/aspose.slides/connector/#reroute) が図形間の最短経路を選択します。

次の例は、楕円と矩形をベンドコネクタで接続します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
[reroute](https://reference.aspose.com/slides/ja/python-java/aspose.slides/connector/#reroute) を呼び出すと、[setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ja/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) と [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ja/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex) の値が変更される可能性があります。再ルーティング後に特定の接続サイトが固定されている必要がある場合は、再度サイトを割り当ててください。
{{% /alert %}}

## **接続サイトを選択する**

各接続可能な図形は、[Shape.getConnectionSiteCount](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getConnectionSiteCount) を通じてサイト数を報告します。図形ジオメトリによりサイト数は異なるため、コネクタ端に割り当てる前にゼロベースのインデックスを検証してください。

この例は、対象のサイトが存在する場合に楕円上の特定のサイトにコネクタを接続します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **コネクタポイントを調整する**

調整ポイントを持つコネクタは、[GeometryShape.getAdjustments](https://reference.aspose.com/slides/ja/python-java/aspose.slides/geometryshape/#getAdjustments) を介してそれらを公開します。各 [AdjustValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/) を調べ、[getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getType) の値を確認してから、[setRawValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#setRawValue) で変更してください。プリセット形状の調整の特定方法は、[Shape Manipulation](/slides/ja/python-java/shape-manipulations/) に記載されています。

コネクタ調整の数、順序、意味、および有効な値範囲はコネクタプリセットに依存します。調整タイプは読み取り専用で、調整値は書き込み可能です。複数の同一意味タイプが存在する場合、読み取り専用の [getName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getName) メソッドが追加の識別情報を提供します。

### **障害物の回り道**

以下のレイアウトでは、2 つの図形間の [BentConnector5](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#BentConnector5) が 3 番目の図形を通過しています。

![connector-obstruction](connector-obstruction.png)

このコードが障害物のあるコネクタを作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

垂直ベンドを移動すると、コネクタが障害物を回避するように経路が変更されます。

![connector-obstruction-fixed](connector-obstruction-fixed.png)

コレクションインデックス `1` が常に垂直ベンドを表すと想定せず、[ConnectorBendPositionY](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) を検索し、期待される意味タイプが存在する場合にのみ変更します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[BentConnector5](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#BentConnector5) には、[ConnectorBendPositionX](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) が 2 つ、[ConnectorBendPositionY](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) が 1 つあります。必要なタイプが複数回出現する場合は、[getName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getName) とそのプリセットの既知ジオメトリを確認してから選択してください。調整が [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeadjustmenttype/#Custom) を返した場合、その意味と範囲はプリセット固有とみなし、契約が明確になるまで変更しないでください。

## **調整値をコネクタジオメトリに関連付ける**

ベンドコネクタの場合、調整値を使用して個々のセグメント位置を推定できます。これらの計算はコネクタプリセット固有です。

- [BentConnector4](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#BentConnector4) は通常、[ConnectorBendPositionX](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) と [ConnectorBendPositionY](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) を各 1 つずつ公開します。
- これらのベンド位置については、[getRawValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getRawValue) が返す値を `100000.0` で除算すると、以下の例で使用されるコネクタフレームの幅または高さの割合が得られます。
- コネクタフレームは回転または反転できるため、フレーム座標はスライド座標と比較する前に変換する必要があります。

以下の例では、まず [getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getType) で調整を識別し、コレクションインデックスをポータブルな識別子として扱いません。

### **回転していないコネクタ**

最初のレイアウトには、[BentConnector4](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#BentConnector4) で接続された 2 つのテキスト図形があります。

![connector-shape-complex](connector-shape-complex.png)

この例はコネクタを調べ、水平および垂直ベンド調整を取得します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

両方のベンドを変更するには、期待されるタイプをそれぞれ検索し、両方が見つかった後に値を変更します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果として、水平セグメントと垂直セグメントが移動したコネクタが得られます。

![connector-adjusted-1](connector-adjusted-1.png)

意味タイプが判明したら、その値をコネクタフレーム座標に変換できます。この例では、2 つのベンド調整で制御される垂直セグメント上に細長い矩形を描画します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ガイド形状が計算されたセグメントを示します。

![connector-adjusted-2](connector-adjusted-2.png)

### **回転または反転したコネクタ**

同じジオメトリが垂直方向に配置される場合、[Shape.getFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getFrame)、[ShapeFrame.getFlipH](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeframe/#getFlipH) および [ShapeFrame.getFlipV](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapeframe/#getFlipV) の値が、コネクタフレーム座標からスライド座標への変換に影響します。

この例は、垂直方向に配置されたコネクタを作成し、調整します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

調整後のコネクタは図形間に垂直に表示されます。

![connector-adjusted-3](connector-adjusted-3.png)

任意の回転角 `alpha` に対して、フレーム中心 `(x0, y0)` 周りのコネクタフレーム点 `(x, y)` を回転させる式は次のとおりです。

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

以下のコードはこの例で使用された 90 度回転を処理し、対応するコネクタセグメント上に赤いガイドを描画します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

座標変換後、赤いガイドが計算されたセグメントを示します。

![connector-adjusted-4](connector-adjusted-4.png)

これらの式は例で使用されたプリセットを説明したものであり、汎用的なコネクタモデルを示すものではありません。別のプリセットに同じ計算を適用する前に、調整タイプ、フレームの向き、および値範囲を必ず検証してください。

## **コネクタの方向角を求める**

直線コネクタの方向は、幅と高さから計算でき、水平・垂直の反転が適用されます。以下の例は、スライド座標系で正の水平軸から時計回りの角度をレポートします。

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **FAQ**

**コネクタが図形に接続できるかどうかはどうやって判断しますか？**

図形の [getConnectionSiteCount](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getConnectionSiteCount) の値を確認してください。正の数であれば、図形は接続サイトを公開しています。コネクタ端に割り当てる前に、選択したサイトインデックスを必ず検証してください。

**コネクタ調整をコレクションインデックスで特定できますか？**

インデックスは既知のコネクタプリセットとコレクションレイアウトに対してのみ意味があります。値を変更する前に [AdjustValue.getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getType) を確認し、同一意味タイプが複数ある場合は [AdjustValue.getName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/adjustvalue/#getName) を追加情報として使用してください。

**接続された図形が削除された場合はどうなりますか？**

対応するコネクタの端は切り離されます。コネクタ自体はスライド上に残り、削除したり、フリーラインとして位置調整したり、別の図形に再接続したりできます。

**スライドをコピーしたときにコネクタのバインディングは保持されますか？**

接続された図形と共にスライドをコピーすると、バインディングは通常保持されます。コネクタだけがコピーされ、対象図形のいずれかが欠落している場合は、該当する端を再度接続する必要があります。