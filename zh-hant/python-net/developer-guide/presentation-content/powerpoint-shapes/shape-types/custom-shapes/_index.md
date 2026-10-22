---
title: 在 Python 中自訂簡報形狀
linktitle: 自訂形狀
type: docs
weight: 20
url: /zh-hant/python-net/custom-shape/
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
- 弧形角
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 透過 .NET 在 PowerPoint 簡報中建立並自訂形狀：幾何路徑、弧形角、合成形狀。"
---
## **概述**

本文說明如何透過編輯點與幾何路徑來編輯形狀幾何，從而自訂 Aspose.Slides 簡報中的圖形。示範如何使用 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 來修改現有圖形、執行基本路徑編輯操作、增加或移除點，並將更新後的幾何套用回圖形。

同時也展示如何建立自訂與合成圖形、建構帶有圓角的圖形、判斷圖形幾何是否為閉合，以及提取圖形元素以進行輪廓分析。

## **使用編輯點變更圖形**

在 PowerPoint 中，您可以使用 **編輯點** 來修改正方形：

* 向內或向外移動角落。
* 調整某點的曲率。
* 新增點。

編輯點讓您能修改圖形的輪廓，或以現有圖形為基礎建立新圖形。

## **圖形編輯技巧**

![overview_image](custom_shape_0.png)

編輯 PowerPoint 圖形時，請記住下列概念：

* 圖形（或其路徑）可以是閉合的或開放的。
* 圖形的路徑由以線段相連的錨點組成。
* 線段可以是直的或曲的。錨點與控制手柄決定其形狀。
* 錨點分為角點、直點與平滑點：
  * 角點處，相鄰線段可以形成角度。
  * 平滑點處，兩個控制手柄對齊且與錨點的距離相等。
  * 直點處，兩個控制手柄對齊但與錨點的距離可以不同。
* 移動錨點或調整其手柄會改變圖形的輪廓。

為了透過編輯點編輯 PowerPoint 圖形，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 類別。

* 一個 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 實例代表 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 物件的幾何路徑。
* 若要從 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 取得 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)，可使用 [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) 方法。
* 若要為圖形設定 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)，可使用以下方法：對於只有單一路徑的圖形使用 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)，對於具有多條路徑的圖形使用 [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/)。
* 若要新增線段，可使用 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 下的各種方法。
* 透過 [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) 與 [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) 屬性，可設定幾何路徑的外觀。
* 使用 [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) 屬性，可將 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 的幾何路徑以路徑線段陣列形式取得。

## **簡單的編輯操作**

使用以下方法編輯幾何路徑。接受索引的重載會在路徑的線段陣列中於該零基位置插入線段。

| 操作 | 方法 |
| --- | --- |
| 附加或插入直線。 | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| 附加或插入具有兩個控制點與終點的三次貝茲曲線。 | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| 附加或插入具有一個控制點與終點的二次貝茲曲線。 | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| 附加具有指定尺寸與角度（以度為單位）的橢圓弧。 | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| 透過將終點連回起點來關閉目前圖形。 | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| 設定圖形的起始點。 | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| 移除位於零基索引的線段。 | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **為圖形新增自訂點**

此範例使用 [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) 在矩形圖形中插入兩個點，並以 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 套用編輯後的路徑。座標是相對於圖形的本地座標：兩個新點位於圖形中心，左側距離 100 點、上方距離 50 點。線段索引 1 與 4 分別將它們放在上緣與下緣，將這兩條邊向內拉伸。

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

![example1_image](custom_shape_1.png)

## **從圖形移除點**

此範例透過使用 [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) 移除零基索引 2 處的線段，來更改心形輪廓。再以 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 套用修改後的路徑，即可更新圖形的輪廓。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **建立自訂圖形**

此範例使用 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 建立一個五角星。外徑與內徑交替分別為 100 點與 50 點，以定義星尖與凹陷；每 72 度的步進將五個星尖均勻分布。路徑最後以 [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) 關閉，並透過 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 套用至矩形圖形，取代其原有輪廓。

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
![example3_image](custom_shape_3.png)

## **建立合成自訂圖形**

此範例為圖形的上三分之一與下三分之一各定義一個閉合的 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)。再以 [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) 同時套用兩條路徑，即可產生一個在中間三分之一留有空隙的單一合成圖形。

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
![example4_image](custom_shape_4.png)

## **建立帶有圓角的自訂圖形**

此範例結合直線段與 [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) 以建立具有內彎圓角的圖形。每個角的尺寸以點為單位設定弧的寬度與高度，-90 度的掃描角則繪製逆時針四分之一橢圓。完成的路徑使用 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 套用，然後將簡報另存為 PPTX 格式。

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

## **判斷圖形幾何是否為閉合**

以下輔助程式會檢查每個非空幾何路徑是否以閉合線段結尾。它會讀取 [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) 並將最後一個線段的 [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) 與 [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/) 進行比較。若不存在非空路徑則返回 false。此檢查僅針對每條路徑的最終指令，並不會檢查路徑內部的每個子圖形。範例會對矩形輸出 `True`。

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

## **提取並檢查圖形元素**

使用 [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) 可將現有圖形檢視為包含路徑點與點類型的元素集合。每個回傳的 [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) 皆會公開其 [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) 與 [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) 陣列。此表示方式對於輪廓分析或將幾何傳遞給自訂繪圖工具相當有用。

範例會開啟簡報、直接在第一張投影片上找到第一個幾何圖形，並列印其路徑線段。請使用包含直線與曲線段的圖形來觀察兩種輸出。此方法不會搜尋群組內部。

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

陣列以索引對應：`points[i]` 為一個點，`types[i]` 描述其角色。類型 `0` 表示開始一個圖形，類型 `1` 表示從前一點畫線到當前點。三次貝茲線段從前一終點開始，使用連續三個類型為 `3` 的項目：兩個控制點加上新的終點。迴圈會一次消費這三個項目，並檢查終點是否閉合。

點類型也包含旗標。以 `0x07` 掩碼可辨識線段類型，另以 `0x80` 判斷是否為閉合子路徑。例如 `129`（`0x81`）代表一個會閉合子路徑的線段終點，`131`（`0x83`）代表會閉合的貝茲終點。僅以 `1` 或 `3` 直接比較原始值會遺漏這些情況。其他旗標，如虛線 (`0x10`) 與標記 (`0x20`)，不會改變基礎線段類型。

**座標與變換。** 點的單位為點 (1/72 英吋)，X 向右增加、Y 向下增加。對於未群組的圖形，提取的座標已包含其 [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) 與 [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) 位置，且反映其當前寬度與高度。例如，未旋轉的矩形位於 `(100, 200)`、尺寸為 `120 × 80`，其輪廓界限為 `(100, 200)`–`(220, 280)`。請勿再次加上圖形的位置。若要取得相對於未旋轉框架的座標，請減去其 X 與 Y。

提取的點不會套用圖形的 [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) 或水平、垂直翻轉。若要復原顯示的輪廓，請在圖形中心周圍套用這些變換。對於群組圖形，亦需考慮群組座標映射與變換；切勿假設提取的點即為最終渲染在投影片上的座標，或在已於子圖形框架中反映的情況下再次套用平移或縮放。

**檢查 vs. 編輯。** 提取的陣列僅描述輪廓，修改它們不會更新原始圖形。當您的分析或繪圖程式需要點/類型陣列時，請使用此方式。若需要在圖形本地座標系統中取得幾何指令或想要編輯其幾何，請使用 [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/)。編輯完成後，請透過 [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 或 [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) 套用。

## **常見問題**

**取代幾何後，填色與輪廓會怎樣？**

樣式仍屬於圖形本身，僅輪廓會改變。填色與輪廓會自動套用至新幾何。

**如何正確旋轉自訂圖形及其幾何？**

使用圖形的 [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) 屬性；幾何會隨圖形一起旋轉，因為它綁定於圖形的座標系統。

**我可以將自訂圖形轉換成影像以「鎖定」結果嗎？**

可以。將所需的 [slide](/slides/zh-hant/python-net/convert-powerpoint-to-png/) 區域或 [shape](/slides/zh-hant/python-net/create-shape-thumbnails/) 本身匯出為點陣圖格式；這樣可簡化後續處理複雜幾何的工作。