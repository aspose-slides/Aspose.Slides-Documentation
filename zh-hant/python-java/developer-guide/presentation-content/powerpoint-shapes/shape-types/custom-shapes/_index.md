---
title: 透過 Java 的 Python 版 Aspose.Slides 自訂簡報形狀
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
- 曲線角
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Java 的 Python 版 Aspose.Slides 在 PowerPoint 簡報中建立與自訂形狀：幾何路徑、曲線角、複合形狀。"
---
## **概觀**

本文說明如何透過編輯點與幾何路徑來編輯形狀幾何，以自訂 Aspose.Slides 簡報中的形狀。示範如何使用 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/) 變更現有形狀、執行基本的路徑編輯操作、加入或移除點，並將更新後的幾何套用回形狀。

同時也示範如何建立自訂與複合形狀、建構帶曲線角的形狀、判斷形狀幾何是否為封閉，以及在 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/) 與 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 之間互相轉換，以因應其他幾何自訂情境。

## **使用編輯點變更形狀**

以正方形為例。在 PowerPoint 中，使用 **edit points**，您可以  

* 將正方形的角向內或向外移動  
* 為角或點指定曲率  
* 在正方形上新增點  
* 操作正方形上的點，等等  

基本上，您可以對任何形狀執行上述工作。利用編輯點，您可以變更形狀或從現有形狀建立新形狀。

## **形狀編輯提示**

![overview_image](custom_shape_0.png)

在開始透過編輯點編輯 PowerPoint 形狀之前，您可能需要考慮以下關於形狀的要點：

* 形狀（或其路徑）可以是封閉的，也可以是開放的。  
* 封閉形狀沒有起點或終點；開放形狀則有開始與結束點。  
* 所有形狀至少由 2 個錨點組成，這些錨點透過線條相連。  
* 線條可以是直線或曲線。錨點決定線條的性質。  
* 錨點有角點、直點或平滑點：  
  * 角點是兩條直線以角度相交的點。  
  * 平滑點是兩個控制柄位於同一直線上，且線段以平滑曲線相接的點。在此情況下，兩個控制柄與錨點的距離相等。  
  * 直點是兩個控制柄位於同一直線上，且線段以平滑曲線相接的點。但此時控制柄與錨點的距離不一定相等。  
* 藉由移動或編輯錨點（會改變線條的角度），即可改變形狀的外觀。  

為了透過編輯點編輯 PowerPoint 形狀，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/) 類別。

* [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/) 實例表示 [GeometryShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/) 物件的幾何路徑。  
* 若要從 [GeometryShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/) 取得 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/)，可使用 [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/#getGeometryPaths) 方法。  
* 若要為形狀設定 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/)，可使用以下方法：對 *solid shapes* 使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/#setGeometryPath)，對 *composite shapes* 使用 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/#setGeometryPaths)。  
* 若要新增線段，可使用屬於 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/) 的各種方法。  
* 使用 [GeometryPath.setStroke](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/#setStroke) 與 [GeometryPath.setFillMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/#setFillMode) 方法，可設定幾何路徑的外觀。  
* 使用 [GeometryPath.getPathData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/#getPathData) 方法，可將 [GeometryShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/) 的幾何路徑以路徑段陣列形式取得。  
* 若要存取其他形狀幾何自訂選項，可將 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/) 轉換為 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)。  
* 使用來自 [ShapeUtil](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeutil/) 類別的 [geometryPathToGraphicsPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeutil/) 與 [graphicsPathToGeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeutil/) 方法，可在 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/) 與 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 之間來回轉換。

## **簡單編輯操作**

以下簽章示範基本的編輯操作：

**新增直線**至路徑末端：

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**新增直線**至路徑的指定位置：

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**新增三次貝塞爾曲線**至路徑末端：

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**新增三次貝塞爾曲線**至路徑的指定位置：

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**新增二次貝塞爾曲線**至路徑末端：

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**新增二次貝塞爾曲線**至路徑的指定位置：

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**將給定的弧段附加到路徑**：

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**關閉路徑的目前圖形**：

- `geometry_path.closeFigure()`

**設定下一個點的位置**：

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**移除指定索引處的路徑段**：

- `geometry_path.removeAt(index)`


## **向形狀添加自訂點**
1. 建立一個 [GeometryShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/) 類別的實例，並將類型設定為 [ShapeType.Rectangle](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#Rectangle)。  
2. 從形狀取得 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/) 類別的實例。  
3. 在路徑的兩個上方點之間新增一個點。  
4. 在路徑的兩個下方點之間新增一個點。  
5. 將路徑套用回形狀。  

以下 Python 程式碼示範如何向形狀添加自訂點：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example1_image](custom_shape_1.png)

## **從形狀移除點**

1. 建立一個 [GeometryShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/) 類別的實例，並將類型設定為 [ShapeType.Heart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#Heart)。  
2. 從形狀取得 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/) 類別的實例。  
3. 移除路徑的段。  
4. 將路徑套用回形狀。  

以下 Python 程式碼示範如何從形狀移除點：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **建立自訂形狀**

1. 計算形狀的各個點。  
2. 建立一個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/) 類別的實例。  
3. 使用點填充路徑。  
4. 建立一個 [GeometryShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/) 類別的實例。  
5. 將路徑套用回形狀。  

以下 Python 程式碼示範如何建立自訂形狀：

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
step = 72

for angle in range(-90, 270, step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + step / 2)
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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)


## **建立複合自訂形狀**

1. 建立一個 [GeometryShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/) 類別的實例。  
2. 建立第一個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/) 類別的實例。  
3. 建立第二個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/) 類別的實例。  
4. 將這兩條路徑套用回形狀。  

以下 Python 程式碼示範如何建立複合自訂形狀：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

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

## **建立具有曲線角的自訂形狀**

以下 Python 程式碼示範如何建立具有內收曲線角的自訂形狀：

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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)
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

## **判斷形狀幾何是否為封閉**

封閉形狀是指其所有邊皆相連，形成單一且無缺口的邊界。此類形狀可以是簡單的幾何圖形，也可以是複雜的自訂輪廓。以下程式碼示例說明如何檢查形狀幾何是否為封閉：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType

def is_geometry_closed(geometry_shape):
    is_closed = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        is_closed = last_segment.getPathCommand() == PathCommandType.Close
        if not is_closed:
            return False
    return is_closed
```

## **將 GeometryPath 轉換為 java.awt.Shape** 

1. 建立一個 [GeometryShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/) 類別的實例。  
2. 建立一個 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 類別的實例。  
3. 透過遍歷其 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 並在路徑上重播每個段落，將 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 實例轉換為 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometrypath/) 實例。  
4. 將路徑套用回形狀。  

以下 Python 程式碼實作上述步驟，將圖形路徑轉換為幾何路徑：

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    # 建立新形狀。
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # 取得形狀的幾何路徑。
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # 使用文字建立新的圖形路徑。
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
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

樣式仍保留在形狀上；僅輪廓會改變。填色與輪廓會自動套用到新的幾何上。

**如何正確地連同幾何一起旋轉自訂形狀？**

使用形狀的[setRotation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#setRotation) 方法；幾何會隨形狀一起旋轉，因為它綁定於形狀自身的座標系統。

**我可以將自訂形狀轉換為圖像以「鎖定」結果嗎？**

可以。將所需的[投影片](/slides/zh-hant/python-java/convert-powerpoint-to-png/)區域或[形狀](/slides/zh-hant/python-java/create-shape-thumbnails/)本身匯出為點陣圖格式；這可簡化對複雜幾何的後續處理。