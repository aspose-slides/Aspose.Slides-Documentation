---
title: 使用 Java 在 Python 中自訂簡報形狀
linktitle: 自訂形狀
type: docs
weight: 20
url: /zh-hant/python-java/custom-shape/
keywords:
- 自訂形狀
- 新增形狀
- 建立形狀
- 變更形狀
- 形狀幾何
- 幾何路徑
- 路徑點
- 編輯點
- 新增點
- 移除點
- 編輯操作
- 圓角
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中建立與自訂形狀：幾何路徑、圓角、組合形狀。"
---
## **概述**

本文說明了如何透過編輯點與幾何路徑來編輯形狀的幾何結構，從而自訂 Aspose.Slides 中的投影片形狀。它展示了如何使用[GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 來修改既有形狀、執行基本的路徑編輯操作、加入或移除點，並將更新後的幾何套用回形狀。

同時也示範了如何建立自訂與組合形狀、建構具有圓角的形狀、判斷形狀幾何是否閉合、檢視形狀元素，以及將 Java AWT 文字輪廓轉換為幾何路徑。

## **使用編輯點變更形狀**

在 PowerPoint 中，你可以使用**編輯點**來修改方形：

* 向內或向外移動角落。
* 調整某一點的曲率。
* 新增點。

編輯點讓你可以修改形狀的外框，或以既有形狀為基礎建立新形狀。

## **形狀編輯技巧**

![overview_image](custom_shape_0.png)

編輯 PowerPoint 形狀時，請記住以下概念：

* 形狀（或其路徑）可以是閉合的也可以是開放的。
* 形狀的路徑由錨點與其間的線段組成。
* 線段可以是直線或曲線。錨點與控制手柄決定其形狀。
* 錨點分為角點、直線點與平滑點：
  * 角點：相鄰線段可以以角度相接。
  * 平滑點：兩個控制手柄共線且與錨點的距離相等。
  * 直線點：兩個控制手柄共線，但與錨點的距離可能不同。
* 移動錨點或調整其手柄會改變形狀的外框。

為了透過編輯點編輯 PowerPoint 形狀，**Aspose.Slides** 提供了[GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 類別。

* [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 例項代表[GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) 物件的幾何路徑。
* 若要從 [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) 例項取得 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)，可使用 [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) 方法。
* 若要為形狀設定 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)，可使用以下方法：單一路徑的形狀使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)；多路徑的形狀使用 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths)。
* 若要加入線段，可使用 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 下的相關方法。
* 使用 [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) 與 [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) 方法，可設定幾何路徑的外觀。
* 使用 [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) 方法，可將 [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) 的幾何路徑以路徑段陣列形式取得。
* 若要存取其他形狀幾何自訂選項，可透過 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 的 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 讀取，並在 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 上重播這些段。

## **簡易編輯操作**

使用下列方法編輯幾何路徑。接受索引的載入（overload）會在路徑的段陣列中，以零基索引插入段。

| 操作 | 方法 |
| --- | --- |
| 附加或插入直線。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| 附加或插入具有兩個控制點與終點的三次貝茲曲線。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 附加或插入具有一個控制點與終點的二次貝茲曲線。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 附加具有指定尺寸與角度（度數）的橢圓弧。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| 透過將終點連回起點，關閉目前的圖形。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| 設定圖形的起始點。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| 以零基索引移除段。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **向形狀加入自訂點**

此範例使用[GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) 在矩形形狀中插入兩個點，並以 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) 套用編輯後的路徑。座標以形狀本身為基準：兩個新點均位於形狀中心，左側距離 100 點，頂部距離 50 點。段索引 1 與 4 分別將它們放在上緣與下緣，將這兩條邊向內拉。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **從形狀中移除點**

此範例透過 [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) 移除零基索引 2 處的段，修改心形輪廓。以 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) 套用修改後的路徑，即可更新形狀外框。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **建立自訂形狀**

此範例使用[GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 建立五角星。交替的外徑與內徑分別為 100 點與 50 點，形成星尖與凹陷；每 72 度為一步，均勻分佈五個星尖。最後以 [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) 關閉路徑，並以 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) 套用至矩形形狀，取代原本的輪廓。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **建立組合自訂形狀**

此範例為形狀的上三分與下三分各定義一個閉合的 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 物件。使用 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) 同時套用兩條路徑，即可產生一個在中間三分處留有空隙的單一組合形狀。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **建立具有圓角的自訂形狀**

此範例將直線段與 [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) 結合，產生內凹圓角的形狀。每個角的大小以點數設定弧的寬度與高度，-90 度的掃描角則畫出逆時針四分之一橢圓。完成的路徑以 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) 套用，最後以 PPTX 格式儲存投影片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **判斷形狀幾何是否閉合**

以下輔助程式會檢查每個非空的幾何路徑是否以閉合段結束。它會讀取 [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) 並比較最後一段的 [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) 是否為 [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/)。若不存在非空路徑，則回傳 `False`。此檢查僅檢視每條路徑的最後指令，並不會檢查路徑內的每個子圖形。範例會對矩形印出 `True`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **檢視幾何路徑指令**

下載 [contour.pptx](contour.pptx) 並放置於應用程式的工作目錄中。第一張投影片的第一個形狀具有水平直線上緣、三次貝茲曲線以及水平直線閉合邊。使用 [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) 讀取形狀的路徑，並以 [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) 依繪製順序讀取每條路徑的段。對於每個段，[getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) 會指出指令類型，並決定如何解讀 [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData) 所回傳的值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

該形狀位於投影片上的 (200, 100) 點。報告的座標以形狀本身為基準，左上角為 (0, 0)，X 向右遞增，Y 向下遞增。閉合段會返回起始點，且不會帶有額外座標。

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **擷取與檢視形狀元素**

使用 [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) 可將既有形狀視為包含路徑點與點類型的元素。將每個回傳的元素以 `jpype.JObject` 轉型為 [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/)，即可透過 [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) 與 [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) 取得點與類型陣列。此表示方式適合用於輪廓分析或將幾何傳遞給自訂繪圖工具。

範例會開啟 input.pptx，找出第一張投影片上直接的第一個幾何形狀，並印出其路徑段。使用包含直線與曲線段的投影片即可同時看到兩種輸出。此程式不會搜尋群組內的形狀。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

陣列以索引對應：`points[i]` 為座標點，`types[i]` 描述其角色。類型 `0` 代表開始圖形，類型 `1` 表示從前一點畫直線至目前點。三次貝茲段會在前一終點之後，使用連續三個類型為 `3` 的條目：兩個控制點接著新的終點。迴圈會一次消耗這三個條目，並檢查終點是否為閉合。

點類型亦包含旗標。以 `0x07` 取得段類型，另外以 `0x80` 判斷是否為閉合子路徑。例如 `129` (`0x81`) 表示閉合的直線終點，`131` (`0x83`) 表示閉合的貝茲終點。Java 以有號位元組儲存這些旗標；使用遮罩可保留正確的位元值。僅比較原始值為 `1` 或 `3` 會遺漏這些情況。其他旗標，如虛線 (`0x10`) 與標記 (`0x20`)，不會改變基礎段類型。

**座標與變換。** 點的單位為點 (1/72 吋)，X 向右遞增，Y 向下遞增。對於未群組的形狀，擷取的座標已包含 [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) 與 [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) 回傳的位置，且反映其當前寬度與高度。例如，未旋轉的矩形在 `(100, 200)`，大小為 `120 × 80`，其輪廓界限為 `(100, 200)`–`(220, 280)`。請勿再次加上形狀的位置。若要取得相對於未旋轉框架的座標，請減去其 X 与 Y。

擷取的點不會套用形狀的旋轉 ([getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation)) 或水平/垂直翻轉。若要重現顯示的輪廓，必須在形狀中心周圍套用這些變換。對於群組形狀，亦需考慮群組座標映射與變換；切勿假設擷取的點已是最終投影片座標，或在已經反映於子框架的情況下再次平移或縮放。

**檢視 vs. 編輯。** 擷取的陣列僅描述輪廓，修改它們不會更新原始形狀。當你的分析或繪圖程式需要點/類型陣列時，請使用此方式。若需要在形狀的本地座標系統中取得幾何指令或想編輯其幾何，請使用 [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths)。編輯後的路徑可透過 [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) 或 [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) 套用。

## **將 Java AWT Shape 轉換為 GeometryPath**

此範例將矩形輪廓與文字輪廓結合。先以 [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) 使矩形輪廓不填色。接著使用 [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) 在 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 中產生文字輪廓。其 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 會提供移動、線段、二次、三次與閉合段，範例將這些段重新播放至 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)。

文字使用 40 點 Arial 字型。輪廓水平向右平移 20 點，且其視覺上方位於形狀上緣下方 10 點。文字路徑會被填色，而原始矩形則維持輪廓。最後以 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) 同時套用兩條路徑，產生包含矩形與文字的單一形狀。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # 取得形狀的幾何路徑。
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # 建立帶有文字的新圖形路徑。
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # 將圖形路徑轉換為幾何路徑。
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # 將文字路徑與原始幾何路徑一起套用。
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **常見問題**

**取代幾何後，填色與輪廓會發生什麼變化？**

樣式仍保留於形狀，只是輪廓改變。填色與輪廓會自動套用到新的幾何上。

**如何正確地同時旋轉自訂形狀與其幾何？**

使用形狀的 [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) 方法；幾何會因為綁定於形狀自身的座標系統而隨形狀一起旋轉。

**我可以將自訂形狀轉換成影像以「鎖定」結果嗎？**

可以。將所需的[投影片](/slides/zh-hant/python-java/convert-powerpoint-to-png/)區域或[圖形](/slides/zh-hant/python-java/create-shape-thumbnails/)本身匯出為點陣圖格式，這樣在處理複雜幾何時會更簡單。