---
title: Python を使用したプレゼンテーションでのコネクタ管理
linktitle: コネクタ
type: docs
weight: 10
url: /ja/python-net/connector/
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint の直線、曲げ、曲線コネクタを追加、接続、再ルーティング、調整、検査する方法を学びます。"
---
## **概要**

コネクタは、いずれかの図形が移動しても 2 つの図形に接続されたままにできる線です。端は接続サイトに接続され、PowerPoint では緑の点で表されます。曲がったり曲線状のコネクタの中には、オレンジの点で表される調整ポイントが公開されており、個々のコネクタ セグメントの位置を制御します。

Aspose.Slides はコネクタを [IConnector](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iconnector/) インターフェイスで表します。コネクタの作成、端を図形に接続、接続サイトの選択、再ルーティング、調整ポイントを持つコネクタのジオメトリの変更が可能です。

## **コネクタの種類**

[ShapeType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapetype/) 列挙には、直線、曲げ、曲線のコネクタ プリセットが含まれます。以下の表は利用可能なコネクタ ジオメトリと各プリセットで定義される調整ポイントの数を示しています。

| コネクタ | 画像 | 調整ポイントの数 |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

調整ポイントの数と意味は選択されたコネクタ プリセットの一部です。異なるコネクタ タイプが同じコレクション レイアウトを公開するとは限りません。

## **2 つの図形を接続する**

[IShapeCollection.add_connector](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ishapecollection/add_connector/) を使用してコネクタを追加し、[start_shape_connected_to](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iconnector/start_shape_connected_to/) と [end_shape_connected_to](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iconnector/end_shape_connected_to/) プロパティに割り当てます。両端が接続されたら、[IConnector.reroute](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iconnector/reroute/) が図形間の最短経路を選択します。

以下の例は、楕円と長方形を曲げコネクタで接続します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`reroute` を呼び出すと [start_shape_connection_site_index](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) および [end_shape_connection_site_index](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iconnector/end_shape_connection_site_index/) の値が変わる可能性があります。これらのサイトを固定したままにする必要がある場合は、再ルーティング後に特定の接続サイトを割り当ててください。
{{% /alert %}}

## **接続サイトを選択する**

接続可能な図形は [connection_site_count](https://reference.aspose.com/slides/ja/python-net/aspose.slides/igeometryshape/connection_site_count/) でサイト数を報告します。図形ジオメトリによってサイト数は異なるため、コネクタ端に割り当てる前にゼロベースのインデックスを検証してください。

この例は、楕円に特定のサイトが存在する場合にそのサイトへコネクタを接続します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **コネクタ ポイントを調整する**

調整ポイントを持つコネクタは [IGeometryShape.adjustments](https://reference.aspose.com/slides/ja/python-net/aspose.slides/igeometryshape/adjustments/) で公開されます。各 [IAdjustValue](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iadjustvalue/) を検査し、`type` を確認してから `raw_value` を変更してください。一般的な図形操作については [Shape Manipulation](/slides/ja/python-net/shape-manipulations/) を参照してください。

コネクタの調整はプリセットに依存し、`type` プロパティは読み取り専用、調整値は書き込み可能です。複数の同一セマンティック タイプが存在する場合は、読み取り専用の [name](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iadjustvalue/name/) プロパティが追加識別情報を提供します。

### **障害物の回り込み**

次のレイアウトでは、`ShapeType.BENT_CONNECTOR5` コネクタが 2 つの図形間で 3 番目の図形を通過しています。

![connector-obstruction](connector-obstruction.png)

このコードは障害物があるコネクタを作成します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

垂直方向の曲げを移動すると、コネクタが障害物を回避するように経路が変更されます。

![connector-obstruction-fixed](connector-obstruction-fixed.png)

コレクション インデックス `1` が常に垂直曲げを表すと仮定せず、`ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` を検索し、期待されるセマンティック タイプが存在する場合にのみ変更します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

`ShapeType.BENT_CONNECTOR5` には `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` が 2 つ、`ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` が 1 つあります。同じタイプが複数回出現する場合は、`name` とそのプリセットの既知ジオメトリを確認してから選択してください。調整が [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapeadjustmenttype/) を返す場合、その意味と範囲はプリセット固有とみなし、契約が明確になるまで変更しないでください。

## **調整値とコネクタ ジオメトリの関係付け**

曲げコネクタでは、調整値を使用して個々のセグメントの位置を推定できます。これらの計算はコネクタ プリセット固有です。

- `ShapeType.BENT_CONNECTOR4` は通常、`ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` と `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` を各 1 つ公開します。
- これらの曲げ位置については、`raw_value / 100000` がコネクタ フレームの幅または高さに対する割合となります（以下の例参照）。
- コネクタ フレームは回転または反転できるため、フレーム座標はスライド座標と比較する前に変換する必要があります。

以下の例はまず `type` で調整を識別し、コレクション インデックスを可搬的な識別子として扱いません。

### **回転していないコネクタ**

初期レイアウトには、`ShapeType.BENT_CONNECTOR4` で接続された 2 つのテキスト図形があります。

![connector-shape-complex](connector-shape-complex.png)

この例はコネクタを検査し、水平および垂直曲げ調整を取得します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

両方の曲げを変更するには、期待されるタイプをそれぞれ見つけた後に値を変更します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

結果として水平および垂直セグメントが移動したコネクタが得られます。

![connector-adjusted-1](connector-adjusted-1.png)

セマンティック タイプが分かれば、その値はコネクタ フレーム座標に変換できます。この例では、2 つの曲げ調整で制御される垂直セグメント上に細い長方形を描画します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

ガイド図形が計算されたセグメントを示します。

![connector-adjusted-2](connector-adjusted-2.png)

### **回転または反転したコネクタ**

同じコネクタ ジオメトリを垂直に配置した場合、[frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iconnector/frame/)、[flip_h](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ishapeframe/flip_h/)、[flip_v](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ishapeframe/flip_v/) の値がコネクタ フレーム座標からスライド座標への変換に影響します。

この例は垂直方向に配置されたコネクタを作成し、調整します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

調整されたコネクタは図形間に垂直に表示されます。

![connector-adjusted-3](connector-adjusted-3.png)

任意の回転角 `alpha` に対して、コネクタ フレーム点 `(x, y)` をフレーム中心 `(x0, y0)` 周りで回転させる式は次のとおりです。

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

以下のコードはこの例で使用した 90 度向きの変換を処理し、対応するコネクタ セグメント上に赤いガイドを描画します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

赤いガイドは座標変換後の計算セグメントを示します。

![connector-adjusted-4](connector-adjusted-4.png)

これらの式は例で使用したプリセットを説明しており、普遍的なコネクタ モデルを表すものではありません。別のプリセットに同じ計算を適用する前に、調整タイプ、フレームの向き、値の範囲を必ず検証してください。

## **コネクタ方向角度の取得**

直線コネクタの方向は幅と高さから計算でき、水平・垂直のフリップが適用されます。以下の例はスライド座標系で正の水平軸からの時計回り角度を報告します。

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **FAQ**

**コネクタが図形に接続できるかどうかはどう判断すればよいですか？**

図形の [connection_site_count](https://reference.aspose.com/slides/ja/python-net/aspose.slides/igeometryshape/connection_site_count/) を確認してください。正のカウントがある場合、その図形は接続サイトを公開しています。コネクタ端に割り当てる前に、選択したサイト インデックスを検証してください。

**コネクタの調整をコレクション インデックスで識別できますか？**

インデックスは既知のコネクタ プリセットとコレクション レイアウトに対してのみ意味があります。値を変更する前に [IAdjustValue.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iadjustvalue/type/) を確認し、同一セマンティック タイプが複数存在する場合は [IAdjustValue.name](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iadjustvalue/name/) を追加情報として使用してください。

**接続された図形が削除された場合はどうなりますか？**

対応するコネクタ端は切り離されます。コネクタはスライド上に残り、削除したり、フリー ラインとして配置したり、別の図形に再接続したりできます。

**スライドをコピーしたときにコネクタのバインディングは保持されますか？**

接続された図形がスライドとともにコピーされる場合、バインディングは通常保持されます。コネクタだけがコピーされ、対象図形が欠けている場合は、影響を受けた端を再度接続する必要があります。