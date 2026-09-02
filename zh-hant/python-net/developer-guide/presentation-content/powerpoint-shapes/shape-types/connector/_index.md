---
title: 管理 Python 簡報中的連接線
linktitle: 連接線
type: docs
weight: 10
url: /zh-hant/python-net/connector/
keywords:
- 連接線
- 連接線類型
- 連接點
- 連接線條
- 連接角度
- 連接位置
- 調整點
- 連接形狀
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 中新增、附加、重新路由、調整與檢查直線、彎曲與曲線連接線。"
---
## **概觀**

連接線是一條在任一形狀移動時仍可保持連接兩個形狀的線。其兩端會連接到連接點，這些連接點在 PowerPoint 中以綠點顯示。某些彎曲和曲線連接線還會顯示調整點，以橙點表示，用於控制各連接線段的位置。

Aspose.Slides 透過 [IConnector](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iconnector/) 介面表示連接線。您可以建立連接線、將兩端連接到形狀、選擇連接點、重新路由，並修改具有調整點的連接線的幾何形狀。

## **連接線類型**

[ShapeType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapetype/) 列舉包含直線、彎曲和曲線連接線預設。下表顯示可用的連接線幾何形狀以及每個預設定義的調整點數量。

| 連接線 | 圖片 | 調整點數量 |
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

調整點的數量與意義屬於所選連接線預設的一部份。不要假設兩種不同的連接線類型會暴露相同的集合布局。

## **將兩個形狀連接起來**

使用 [IShapeCollection.add_connector](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ishapecollection/add_connector/) 新增連接線，並指定其 [start_shape_connected_to](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iconnector/start_shape_connected_to/) 與 [end_shape_connected_to](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iconnector/end_shape_connected_to/) 屬性。兩端都連接後，呼叫 [IConnector.reroute](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iconnector/reroute/) 會在形狀之間選擇最短路徑。

以下範例使用彎曲連接線將橢圓與矩形連接：

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

{{% alert color="warning" title="警告" %}}
呼叫 `reroute` 可能會變更 [start_shape_connection_site_index](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) 與 [end_shape_connection_site_index](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iconnector/end_shape_connection_site_index/) 的值。若必須固定這些連接點，請在重新路由後再指定具體的連接點。
{{% /alert %}}

## **選擇連接點**

每個可連接的形狀會透過 [connection_site_count](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/igeometryshape/connection_site_count/) 報告其連接點數量。在指派給連接線端點之前，先驗證所選的零基索引；不同形狀的幾何會導致連接點數量不同。

此範例在橢圓上存在的特定連接點上附加連接線：

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

## **調整連接點**

具有調整點的連接線會透過 [IGeometryShape.adjustments](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/igeometryshape/adjustments/) 暴露。檢查每個 [IAdjustValue](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iadjustvalue/) 並在變更其 [raw_value](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iadjustvalue/raw_value/) 前先確認其 [type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iadjustvalue/type/)。有關一般形狀操作，請參閱 [Shape Manipulation](/slides/zh-hant/python-net/shape-manipulations/)。

調整點的數量、順序、意義與有效值範圍取決於連接線預設。`type` 屬性為唯讀，調整值則可寫。唯讀的 [name](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iadjustvalue/name/) 屬性在同一語意類型出現多次時提供額外辨識。

### **繞過障礙物**

在下圖中，`ShapeType.BENT_CONNECTOR5` 連接線在兩個形狀之間穿過第三個形狀：

![connector-obstruction](connector-obstruction.png)

以下程式碼建立受阻的連接線：

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

移動垂直彎曲點會改變路徑，使連接線繞過障礙物：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

此範例不假設集合索引 `1` 必定代表垂直彎曲點，而是搜尋 `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`，僅在語意類型符合時才變更：

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

`ShapeType.BENT_CONNECTOR5` 具有兩個 `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` 調整點與一個 `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` 調整點。若需要的類型出現多次，請檢查 `name` 並依據已知的幾何預設選擇。若調整點回報 [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapeadjustmenttype/)，視其意義與範圍為預設特有，且在未了解合約前不要變更。

## **將調整值對應至連接線幾何**

對於彎曲連接線，調整值可用來估算各段的座標。以下計算皆針對特定連接線預設：

- `ShapeType.BENT_CONNECTOR4` 通常暴露一個 `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` 與一個 `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` 調整點。
- 對於這些彎曲位置，`raw_value / 100000` 產生相對於連接線框寬或高的比例。
- 連接線框可能被旋轉或翻轉，故在與投影片座標比較前必須先轉換框座標。

以下範例先使用 `type` 辨識調整點，並不以集合索引作為可移植的辨識子。

### **未旋轉的連接線**

初始版面包含兩個文字形狀，由 `ShapeType.BENT_CONNECTOR4` 連接：

![connector-shape-complex](connector-shape-complex.png)

此範例檢查連接線並取得水平與垂直彎曲的調整點：

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

若要同時變更兩個彎曲，先找到每個預期的類型，確保兩者皆被找到後再修改其值：

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

結果是水平與垂直段都已移動的連接線：

![connector-adjusted-1](connector-adjusted-1.png)

一旦得知語意類型，即可將其值轉換為連接線框座標。此範例在由兩個彎曲調整點控制的垂直段上繪製一個細長矩形：

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

指示形狀標示出計算後的段落：

![connector-adjusted-2](connector-adjusted-2.png)

### **旋轉或翻轉的連接線**

當相同的連接線幾何垂直排列時，其 [frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iconnector/frame/)、[flip_h](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ishapeframe/flip_h/) 與 [flip_v](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ishapeframe/flip_v/) 會影響從連接線框座標到投影片座標的轉換。

此範例建立並調整垂直方向的連接線：

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

調整後的連接線垂直顯示於兩個形狀之間：

![connector-adjusted-3](connector-adjusted-3.png)

對於任意旋轉角度 `alpha`，將連接線框點 `(x, y)` 圍繞框中心 `(x0, y0)` 旋轉：

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

以下程式碼處理本例中使用的 90° 方向，並在相應的連接線段上繪製紅色指示：

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

紅色指示標示出座標轉換後計算的段落：

![connector-adjusted-4](connector-adjusted-4.png)

這些公式描述的是範例所用的預設，而非通用的連接線模型。套用相同計算於其他預設前，請先驗證調整類型、框方向與值範圍。

## **取得連接線方向角度**

直線連接線的方向可由其寬度與高度計算，並考慮水平與垂直翻轉。以下範例回報投影片座標系中正水平軸的順時針角度：

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

## **常見問題**

**如何判斷連接線是否能附著於形狀？**

檢查形狀的 [connection_site_count](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/igeometryshape/connection_site_count/)。正值表示形狀提供連接點。指派給任一連接線端之前，先驗證所選的站點索引。

**我能以集合索引辨識連接線調整點嗎？**

索引僅在已知的連接線預設與集合布局下才有意義。修改值前先檢查 [IAdjustValue.type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iadjustvalue/type/)，若同一語意類型出現多次，請使用 [IAdjustValue.name](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iadjustvalue/name/) 作為補充資訊。

**當所連接的形狀被刪除時會發生什麼？**

相應的連接線端會變為未附著狀態。連接線仍保留在投影片上，您可以刪除、作為自由線定位，或重新附著到其他形狀。

**複製投影片時會保留連接線的綁定嗎？**

一般情況下，當連接的形狀與投影片一起被複製時，綁定會保留。如果僅複製了連接線而未複製其目標形狀，則必須重新附著受影響的端點。