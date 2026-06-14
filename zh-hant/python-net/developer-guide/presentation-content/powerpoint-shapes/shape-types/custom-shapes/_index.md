---
title: 使用 Python 自訂簡報中的圖形
linktitle: 自訂圖形
type: docs
weight: 20
url: /zh-hant/python-net/custom-shape/
keywords:
- 自訂圖形
- 新增圖形
- 建立圖形
- 變更圖形
- 圖形幾何
- 幾何路徑
- 路徑點
- 編輯點
- 新增點
- 移除點
- 編輯操作
- 曲線角
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 透過 .NET，在 PowerPoint 與 OpenDocument 簡報中建立與自訂圖形：幾何路徑、曲線角、組合圖形。"
---
## **簡介**

考慮一個正方形。在 PowerPoint 中，使用 **編輯點**，您可以：

* 將正方形的角向內或向外移動，
* 調整角或點的曲率，
* 向正方形添加新點，
* 操作其點。

您可以將這些操作套用到任何形狀。使用 **編輯點**，您可以修改形狀或從現有形狀建立新形狀。

## **形狀編輯提示**

!["編輯點" 命令](custom_shape_0.png)

在使用 **編輯點** 編輯 PowerPoint 形狀之前，請先留意以下關於形狀的說明：

* 形狀（或其路徑）可以是 **封閉** 的或 **開放** 的。
* 封閉形狀沒有起點或終點；開放形狀有起點與終點。
* 每個形狀至少有兩個由線段連接的錨點。
* 線段可以是直線或曲線；錨點決定線段的性質。
* 錨點可以是 **角點**、**平滑** 或 **直線**：
  * **角點** 是兩條直線段以角度相交的點。
  * **平滑** 點有兩個共線的控制手柄，且相鄰的線段形成平滑的曲線。此時，兩個手柄距離錨點相等。
  * **直線** 點同樣有兩個共線的控制手柄，且相鄰的線段形成平滑的曲線。但此時，手柄距離錨點不必相等。
* 透過移動或編輯錨點（從而改變線段角度），您可以改變形狀的外觀。

要編輯 PowerPoint 形狀，Aspose.Slides 提供了 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/) 類別。

* 一個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/) 實例代表 [GeometryShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometryshape/) 物件的幾何路徑。
* 若要從 [GeometryShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometryshape/) 實例取得 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/)，請使用 [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometryshape/get_geometry_paths/) 方法。
* 若要為形狀設定 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/)，請對 *實心形狀* 使用 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometryshape/set_geometry_path/)，對 *組合形狀* 使用 [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometryshape/set_geometry_paths/)。
* 若要新增線段，請使用 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/) 上的方法。
* 使用 [GeometryPath.stroke](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/stroke/) 與 [GeometryPath.fill_mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/fill_mode/) 屬性來控制幾何路徑的外觀。
* 使用 [GeometryPath.path_data](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/path_data/) 屬性可取得形狀的幾何路徑，作為路徑線段陣列。

## **簡單編輯操作**

以下方法用於簡單的編輯操作。

**在路徑末端新增直線**：

```py
line_to(point)
line_to(x, y)
```

**在路徑的指定位置新增直線**：

```py    
line_to(point, index)
line_to(x, y, index)
```

**在路徑末端新增立方貝塞爾曲線**：

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**在路徑的指定位置新增立方貝塞爾曲線**：

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**在路徑末端新增二次貝塞爾曲線**：

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**在路徑的指定位置新增二次貝塞爾曲線**：

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**在路徑中附加弧線**：

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**關閉路徑中的目前圖形**：

```py
close_figure()
```

**設定下一個點的位置**：

```py
move_to(point)
move_to(x, y)
```

**移除指定索引的路徑線段**：

```py
remove_at(index)
```

## **向形狀新增自訂點**

本節說明如何透過新增自訂點序列來定義自由形式的形狀。藉由指定有序點與線段類型（直線或曲線）並可選擇性關閉路徑，您可以直接在投影片上繪製精確的自訂圖形—多邊形、圖示、標註或標誌。

1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometryshape/) 類別的實例，並設定其 [ShapeType.RECTANGLE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapetype/)。
2. 從形狀取得 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/) 實例。
3. 在路徑的兩個上方點之間插入新點。
4. 在路徑的兩個下方點之間插入新點。
5. 將更新後的路徑套用至形狀。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![自訂點](custom_shape_1.png)

## **從形狀移除點**

有時自訂形狀包含不必要的點，會使幾何結構變得複雜或影響渲染效果。本節說明如何從形狀的路徑中移除特定點，以簡化輪廓並取得更乾淨、精確的結果。

1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometryshape/) 類別的實例，並設定其 [ShapeType.HEART](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapetype/) 類型。
2. 從形狀取得 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/) 實例。
3. 從路徑中移除一個線段。
4. 將更新後的路徑套用至形狀。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![已移除的點](custom_shape_2.png)

## **建立自訂形狀**

透過定義 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/) 並以直線、弧線與貝塞爾曲線組合，可建立專屬的向量形狀。本節示範如何從頭開始建構自訂幾何，並將產生的形狀加入投影片。

1. 計算形狀的點。
2. 建立 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/) 類別的實例。
3. 將點填入路徑。
4. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometryshape/) 類別的實例。
5. 將路徑套用至形狀。

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![自訂形狀](custom_shape_3.png)

## **建立組合自訂形狀**

建立組合自訂形狀可將多個幾何路徑合併為投影片上的單一可重用形狀。定義並合併這些路徑，即可打造超越標準形狀集的複雜視覺效果。

1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometryshape/) 類別的實例。
2. 建立第一個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/) 類別的實例。
3. 建立第二個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometrypath/) 類別的實例。
4. 將兩條路徑同時套用至形狀。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![組合形狀](custom_shape_4.png)

## **建立帶有曲線角的自訂形狀**

本節說明如何使用幾何路徑繪製帶有平滑曲線角的自訂形狀。您將結合直線段與圓弧以形成輪廓，並將完成的形狀加入投影片。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![曲線角](custom_shape_6.png)

## **判斷形狀的幾何是否封閉**

封閉形狀指其所有邊緣均相連，形成一個沒有間隙的單一邊界。此類形狀可為簡單的幾何圖形，也可為複雜的自訂輪廓。以下程式碼示例說明如何檢查形狀的幾何是否為封閉：

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **常見問題**

**取代幾何後，填色與輪廓會怎樣？**

樣式仍保留在形狀上，只有輪廓會改變。填色與輪廓會自動套用到新的幾何上。

**如何正確地同時旋轉自訂形狀與其幾何？**

使用形狀的 [rotation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/geometryshape/rotation/) 屬性；因為幾何繫結於形狀自身的座標系統，會隨形狀一起旋轉。

**我可以將自訂形狀轉換為影像以「鎖定」結果嗎？**

可以。將所需的 [slide](/slides/zh-hant/python-net/convert-powerpoint-to-png/) 區域或 [shape](/slides/zh-hant/python-net/create-shape-thumbnails/) 本身匯出為點陣圖格式，這樣可簡化對大型幾何的後續處理。