---
title: 在 Python 中自訂簡報圖形
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
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 透過 .NET，在 PowerPoint 簡報中建立並自訂圖形：幾何路徑、曲線角、組合圖形。"
---
## **概觀**

本文說明如何透過編輯點與幾何路徑來自訂 Aspose.Slides 中的投影片圖形外觀。示範如何使用 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 修改既有圖形、執行基本路徑編輯操作、加入或移除點，並將更新後的幾何形狀套用回圖形。

同時展示如何建立自訂與組合圖形、建構帶有曲線角的圖形、判斷圖形幾何是否為封閉，以及擷取圖形元素以進行輪廓分析。

## **使用編輯點變更圖形**

在 PowerPoint 中，您可以使用 **編輯點** 來修改正方形：

* 向內或向外移動角點。
* 調整點的曲率。
* 新增點。

編輯點可讓您修改圖形的輪廓，或以既有圖形作為新圖形的基礎。

## **圖形編輯技巧**

![概觀圖](custom_shape_0.png)

編輯 PowerPoint 圖形時，請記住以下概念：

* 圖形（或其路徑）可以是封閉的或開放的。
* 圖形的路徑由錨點（anchor points）與段（segments）組成。
* 段可以是直線或曲線。錨點與控制手柄（control handles）決定其形狀。
* 錨點有三種型態：角點、直線點或平滑點：
  * 角點：相鄰段可在角度處相交。
  * 平滑點：兩個控制手柄對齊且與錨點等距。
  * 直線點：兩個控制手柄對齊，但與錨點的距離可能不同。
* 移動錨點或調整其手柄會改變圖形的輪廓。

欲透過編輯點編輯 PowerPoint 圖形，**Aspose.Slides** 提供 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 類別。

* 一個 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 實例代表 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 物件的幾何路徑。
* 若要從 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 取得 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)，可使用 [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) 方法。
* 若要為圖形設定 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)，可使用以下方法：單一路徑圖形使用 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)，多路徑圖形使用 [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/)。
* 若要加入段，可使用 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 下的各種方法。
* 使用 [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) 與 [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) 屬性，可設定幾何路徑的外觀。
* 使用 [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) 屬性，可將 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 的幾何路徑以路徑段陣列的形式取得。

## **簡易編輯操作**

使用下列方法編輯幾何路徑。接受索引的多載會在路徑的段陣列中於零基位置插入段。

| 操作 | 方法 |
| --- | --- |
| 追加或插入直線。 | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| 追加或插入具有兩個控制點與終點的三次貝茲曲線。 | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| 追加或插入具有一個控制點與終點的二次貝茲曲線。 | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| 以指定的尺寸與角度（以度為單位）追加橢圓弧。 | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| 透過將終點連回起始點來關閉目前圖形。 | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| 設定圖形的起始點。 | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| 移除零基索引處的段。 | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **向圖形加入自訂點**

以下範例使用 [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) 將兩個點插入矩形圖形，並使用 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 套用編輯後的路徑。座標為相對於圖形的局部座標：兩個新點位於圖形中心，左側距離 100 點、上側距離 50 點。段索引 1 與 4 分別將它們放在上邊與下邊，將這兩條邊向內拉。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![範例 1 圖片](custom_shape_1.png)

## **從圖形移除點**

以下範例使用 [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) 移除零基索引 2 處的段，以改變心形輪廓。再透過 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 套用修改後的路徑，即可更新圖形的輪廓。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![範例 2 圖片](custom_shape_2.png)

## **建立自訂圖形**

此範例使用 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 建立五角星。外徑與內徑分別為 100 點與 50 點，交替形成星尖與凹陷；以 72 度的間隔均勻分布五個星尖。路徑使用 [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) 關閉，並以 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 套用至矩形圖形，取代原本的輪廓。

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![範例 3 圖片](custom_shape_3.png)

## **建立組合自訂圖形**

此範例為圖形的上三分之一與下三分之一分別定義兩條封閉的 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 物件。透過 [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) 同時套用兩條路徑，即可在中間三分之一產生一個間隙的單一組合圖形。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![範例 4 圖片](custom_shape_4.png)

## **建立帶曲線角的自訂圖形**

此範例結合直線段與 [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) 產生內凹曲線角的圖形。每個角的大小決定弧形的寬度與高度（單位為點），-90 度的掃描角繪製逆時針四分之一橢圓。完成的路徑使用 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 套用，並以 PPTX 格式儲存簡報。

```python
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

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **判斷圖形幾何是否為封閉**

以下輔助程式會檢查每個非空幾何路徑是否以封閉段結尾。它會讀取 [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) 並將最後一段的 [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) 與 [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/) 做比較。若不存在非空路徑則回傳 false。此檢查僅針對每條路徑的最終指令，並不會檢查路徑內的每個子圖形。範例會對矩形印出 `True`。

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **檢視幾何路徑指令**

下載 [contour.pptx](contour.pptx) 並放置於工作目錄。第一張投影片的第一個圖形具有直線上緣、三次貝茲曲線與直線閉合邊緣。使用 [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) 讀取其路徑。對每條路徑，[GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) 會以繪製順序列出段。每段的 [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) 決定如何解讀其 [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/)。

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

圖形位於投影片上 (200, 100) 點的位置。報告的座標為相對於圖形的局部座標。左上角為 (0, 0)，X 向右遞增，Y 向下遞增。閉合段會返回起始點，且不會附帶其他座標。

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![PowerPoint 圖形：上緣為直線，右上至左下為曲線，左緣為直線](contour.png)

## **擷取並檢視圖形元素**

使用 [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) 可將現有圖形檢視為包含路徑點與點類型的元素。每個回傳的 [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) 會公開其 [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) 與 [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) 陣列。此表示方式適合用於輪廓分析或將幾何資訊傳遞給自訂繪圖工具。

範例會開啟簡報、在第一張投影片直接尋找第一個幾何圖形，並印出其路徑段。使用包含直線與曲線段的圖形以觀察兩種輸出。此程式不會搜尋群組內部。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
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

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

陣列以索引對應：`points[i]` 為座標點，`types[i]` 描述其角色。類型 `0` 表示開始圖形，類型 `1` 表示從前一點畫線至當前點。三次貝茲段會在前一終點之後使用連續三個類型 `3` 條目：兩個控制點接著新終點。迴圈會一次消耗這三條目，並檢查終點是否為閉合。

點類型同時包含旗標。以 `0x07` 掩碼可辨識段類型，另以 `0x80` 判斷是否為閉合子路徑。例如 `129`（`0x81`）代表閉合的線段終點，`131`（`0x83`）代表閉合的貝茲終點。若只與 `1` 或 `3` 比較會遺漏這些情況。其他旗標，如虛線 (`0x10`) 與標記 (`0x20`)，不會改變基礎段類型。

**座標與變換。** 點的單位為點 (1/72 吋)，X 向右遞增，Y 向下遞增。對於未群組的圖形，擷取的座標已經包含其 [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) 與 [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) 位置，並反映目前的寬度與高度。例如，位於 `(100, 200)`、尺寸為 `120 × 80` 的未旋轉矩形，其輪廓範圍為 `(100, 200)`–`(220, 280)`。請勿再次加上圖形的位置。若要取得相對於未旋轉框架的座標，請減去其 X 與 Y。

擷取的點不會套用圖形的 [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) 或水平、垂直翻轉。若要重現顯示的輪廓，需在圖形中心周圍套用這些變換。對於群組圖形，還必須考慮群組座標映射與變換；請勿假設擷取的點即為最終投影片座標，亦不要在已反映於子圖形框架的情況下再次進行平移或縮放。

**檢視 vs. 編輯。** 擷取的陣列僅描述輪廓，修改它們不會更新原始圖形。當您的分析或繪圖程式需要點/類型陣列時，請使用此方式。若需要在圖形的本地座標系統中取得幾何指令或想編輯其幾何，請使用 [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/)。編輯後的路徑請透過 [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 或 [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) 套用。

## **常見問答**

**取代幾何後，填色與輪廓會怎樣？**

樣式仍屬於圖形本身，只會改變輪廓。填色與輪廓會自動套用到新幾何上。

**如何正確地一起旋轉自訂圖形與其幾何？**

使用圖形的 [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) 屬性；幾何會隨圖形一起旋轉，因為它綁定於圖形自身的座標系統。

**我可以將自訂圖形轉成影像以「鎖定」結果嗎？**

可以。將所需的 [slide](/slides/zh-hant/python-net/convert-powerpoint-to-png/) 區域或 [shape](/slides/zh-hant/python-net/create-shape-thumbnails/) 本身匯出為點陣圖格式，這樣可簡化後續對複雜幾何的處理。