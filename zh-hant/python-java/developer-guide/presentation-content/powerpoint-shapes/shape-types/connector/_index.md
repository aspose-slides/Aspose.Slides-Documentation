---
title: 在 Python（透過 Java）中管理簡報的連接線
linktitle: 連接線
type: docs
weight: 10
url: /zh-hant/python-java/connector/
keywords:
- 連接線
- 連接線類型
- 連接點
- 連接線
- 連接角度
- 連接點
- 調整點
- 連接形狀
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PowerPoint 中新增、附加、重新路由、調整與檢查直線、彎曲與曲線連接線。"
---
## **概觀**

連接線是一條在任一形狀移動時仍可保持連接到兩個形狀的線。它的兩端連接到連接點，這些連接點在 PowerPoint 中以綠色點表示。某些彎曲與曲線連接線還會顯示調整點，以橙色點表示，可控制個別連接線段的位置。

Aspose.Slides 透過 [Connector](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/connector/) 類別表示連接線。您可以建立連接線、將其兩端連接到形狀、選擇連接點、重新路由，並修改具有調整點的連接線的幾何形狀。

## **連接線類型**

[ShapeType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/) 類別包含直線、彎曲與曲線連接線的預設樣式。下表列出可用的連接線幾何形狀以及每個預設樣式所定義的調整點數量。

| 連接線 | 圖片 | 調整點數 |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

調整點的數量與意義屬於所選的連接線預設樣式。請勿假設兩種不同的連接線類型會公開相同的集合布局。

## **連接兩個形狀**

使用 [ShapeCollection.addConnector](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addConnector) 新增連接線，並使用 [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/connector/#setStartShapeConnectedTo) 與 [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/connector/#setEndShapeConnectedTo) 連接其兩端。當兩端皆已連接後，[Connector.reroute](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/connector/#reroute) 會在形狀之間選擇最短路徑。

以下範例使用彎曲連接線將橢圓與矩形相連：

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

{{% alert color="warning" title="警告" %}}
呼叫 [reroute](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/connector/#reroute) 可能會變更 [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) 與 [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex) 的值。若這些連接點必須保持固定，請在重新路由後再指定特定的連接點。
{{% /alert %}}

## **選擇連接點**

每個可連接的形狀會透過 [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getConnectionSiteCount) 回傳其連接點數量。將首選的零基索引驗證後再指派給連接線的端點；不同形狀的幾何形狀會有不同的連接點數量。

此範例在橢圓上存在的特定位點將連接線附著於該點：

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

## **調整連接線點**

具有調整點的連接線會透過 [GeometryShape.getAdjustments](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/#getAdjustments) 取得。檢查每個 [AdjustValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/) 並在變更前先確認其 [getType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getType) 值。一般的預設形狀調整說明請參考 [Shape Manipulation](/slides/zh-hant/python-java/shape-manipulations/)。

調整點的數量、順序、意義與有效值範圍取決於連接線的預設樣式。調整類型為唯讀，調整值則可寫入。唯讀的 [getName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getName) 方法在連接線包含多個相同語義類型的調整時，可提供額外的識別資訊。

### **繞過障礙物**

在下圖中，一條 [BentConnector5](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#BentConnector5) 連接線在兩個形狀之間經過第三個形狀：

![connector-obstruction](connector-obstruction.png)

此程式碼建立受阻的連接線：

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

將垂直彎曲點移動後，路徑會改變，讓連接線繞過障礙物：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

不要假設集合索引 `1` 總是代表垂直彎曲，以下範例會搜尋 [ConnectorBendPositionY](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) 並僅在預期的語義類型存在時才變更它：

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

[BentConnector5](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#BentConnector5) 含有兩個 [ConnectorBendPositionX](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) 調整與一個 [ConnectorBendPositionY](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) 調整。若您需要的類型出現多次，請在選擇前檢查 [getName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getName) 與該預設的已知幾何形狀。如果調整回報 [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeadjustmenttype/#Custom)，請視為預設特定的意義與範圍，除非已知其契約，否則不要變更。

## **將調整值與連接線幾何對應**

對於彎曲連接線，調整值可用來估算各段的相對位置。這些計算僅適用於特定的連接線預設樣式：

- [BentConnector4](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#BentConnector4) 通常會公開一個 [ConnectorBendPositionX](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) 與一個 [ConnectorBendPositionY](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) 調整。
- 對於這些彎曲位置，將 [getRawValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getRawValue) 回傳的值除以 `100000.0`，即可得到連接線框架寬度或高度的比例（如下例所示）。
- 連接線框架可能會旋轉或翻轉，故在與投影片座標比較前必須先轉換框架座標。

以下範例先使用 [getType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getType) 識別調整，再進行處理。它們不會把集合索引視為可移植的識別符號。

### **未旋轉的連接線**

初始版面包含兩個文字形狀，透過一條 [BentConnector4](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#BentConnector4) 連接：

![connector-shape-complex](connector-shape-complex.png)

此範例檢查連接線並取得水平與垂直彎曲的調整值：

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

若要同時變更兩個彎曲，請先找到每個預期的類型，且僅在兩者皆找到後才修改其值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

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

結果是一條水平與垂直段皆已移動的連接線：

![connector-adjusted-1](connector-adjusted-1.png)

一旦確定了語義類型，可將其值轉換為連接線框架座標。此範例在由兩個彎曲調整控制的垂直段上繪製一個細長矩形：

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

指示形狀標示出計算後的段落：

![connector-adjusted-2](connector-adjusted-2.png)

### **旋轉或翻轉的連接線**

當相同的連接線幾何以垂直方向呈現時，其 [Shape.getFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getFrame)、[ShapeFrame.getFlipH](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeframe/#getFlipH) 與 [ShapeFrame.getFlipV](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeframe/#getFlipV) 會影響從連接線框架座標到投影片座標的轉換。

此範例建立並調整垂直方向的連接線：

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

調整後的連接線垂直顯示在兩個形狀之間：

![connector-adjusted-3](connector-adjusted-3.png)

對於任意旋轉角度 `alpha`，可將連接線框架點 `(x, y)` 以框架中心 `(x0, y0)` 為中心旋轉：

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

以下程式碼處理本範例所使用的 90 度方向，並在相應的連接線段上繪製紅色指示線：

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

紅色指示線在座標轉換後標示出計算得到的段落：

![connector-adjusted-4](connector-adjusted-4.png)

上述公式僅描述範例中使用的預設樣式，並非通用的連接線模型。請在將相同計算套用至不同預設樣式前，先驗證調整類型、框架方向與值範圍。

## **尋找連接線方向角度**

直線連接線的方向可根據其寬度與高度計算，並考慮水平與垂直翻轉。以下範例報告在投影片座標系中，從正水平軸順時針測量的角度：

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

## **常見問題**

**如何判斷連接線是否能附著於形狀？**

檢查形狀的 [getConnectionSiteCount](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getConnectionSiteCount) 值。正值表示形狀提供連接點。在指派給任一連接線端點前，請先驗證所選的點索引。

**我可以僅依集合索引辨識連接線調整嗎？**

索引僅在已知的連接線預設樣式與集合布局下才有意義。在修改值之前，請先檢查 [AdjustValue.getType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getType)，且當同一語義類型出現多次時，可使用 [AdjustValue.getName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getName) 取得額外資訊。

**當已連接的形狀被刪除時會發生什麼？**

相應的連接線端點會變為未連接狀態。連接線仍保留在投影片上，您可以刪除它、將其作為自由線移動，或重新附著到其他形狀。

**複製投影片時，連接線的綁定會被保留嗎？**

當連接的形狀與投影片一起被複製時，綁定通常會被保留。如果僅複製了連接線而未複製其目標形狀，則必須再次將受影響的端點附著。