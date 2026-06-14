---
title: 使用 Python 在簡報中管理連接線
linktitle: 連接線
type: docs
weight: 10
url: /zh-hant/python-net/connector/
keywords:
- 連接線
- 連接線類型
- 連接點
- 連接線
- 連接線角度
- 連接圖形
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "賦能 Python 應用程式在 PowerPoint 與 OpenDocument 投影片中繪製、連接與自動路由線條——全面掌控直線、彎角與曲線連接線。"
---
## **簡介**

PowerPoint 連接線是一種專門用來連結兩個圖形的線條，當圖形在投影片上移動或重新定位時，連接線會保持附著。連接線會附著在圖形的 **連接點**（綠點）上。當指標靠近連接點時會顯示。某些連接線提供 **調整手柄**（黃點），可讓您修改連接線的位置與形狀。

## **連接線類型**

在 PowerPoint 中，您可以使用三種連接線：直線、彎角（斜角）與曲線。

Aspose.Slides 支援以下連接線類型：

| 連接線類型                     | 圖片                                                         | 調整點數量 |
| ------------------------------ | ------------------------------------------------------------ | ---------- |
| `ShapeType.LINE`               | ![直線連接線](shapetype-lineconnector.png)                 | 0          |
| `ShapeType.STRAIGHT_CONNECTOR1`| ![直線連接線 1](shapetype-straightconnector1.png)           | 0          |
| `ShapeType.BENT_CONNECTOR2`    | ![彎曲連接線 2](shapetype-bent-connector2.png)              | 0          |
| `ShapeType.BENT_CONNECTOR3`    | ![彎曲連接線 3](shapetype-bentconnector3.png)               | 1          |
| `ShapeType.BENT_CONNECTOR4`    | ![彎曲連接線 4](shapetype-bentconnector4.png)               | 2          |
| `ShapeType.BENT_CONNECTOR5`    | ![彎曲連接線 5](shapetype-bentconnector5.png)               | 3          |
| `ShapeType.CURVED_CONNECTOR2`  | ![曲線連接線 2](shapetype-curvedconnector2.png)             | 0          |
| `ShapeType.CURVED_CONNECTOR3`  | ![曲線連接線 3](shapetype-curvedconnector3.png)             | 1          |
| `ShapeType.CURVED_CONNECTOR4`  | ![曲線連接線 4](shapetype-curvedconnector4.png)             | 2          |
| `ShapeType.CURVED_CONNECTOR5`  | ![曲線連接線 5](shapetype.curvedconnector5.png)             | 3          |

## **以連接線連結圖形**

本節示範如何在 Aspose.Slides 中使用連接線連結圖形。您將在投影片中加入連接線，並將其起點與終點附著到目標圖形。使用連接點可確保即使圖形移動或調整大小，連接線仍保持「黏貼」狀態。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。  
1. 依索引取得投影片的參考。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/) 物件的 `add_auto_shape` 方法，將兩個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 加入投影片。  
1. 透過 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/) 物件的 `add_connector` 方法新增連接線，並指定連接線類型。  
1. 用連接線連結兩個圖形。  
1. 呼叫 `reroute` 方法以套用最短的連接路徑。  
1. 儲存投影片。

以下 Python 程式碼示範如何在兩個圖形（橢圓與矩形）之間加入彎曲連接線：

```python
import aspose.slides as slides

# 初始化 Presentation 類別以建立 PPTX 檔案。
with slides.Presentation() as presentation:

    # 取得第一張投影片的 shapes 集合。
    shapes = presentation.slides[0].shapes

    # 新增橢圓 AutoShape。
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 新增矩形 AutoShape。
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # 在投影片上新增連接線。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # 使用連接線將圖形連接起來。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 呼叫 reroute 設定最短路徑。
    connector.reroute()

    # 儲存簡報。
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
`connector.reroute` 方法會重新導向連接線，強制其在圖形之間走最短路徑。為此，該方法可能會變更 `start_shape_connection_site_index` 與 `end_shape_connection_site_index` 的值。  
{{% /alert %}}

## **指定連接點**

本節說明如何在 Aspose.Slides 中將連接線附著到圖形的特定連接點。透過精準指定連接點，您可以控制連接線的路徑與版面配置，讓簡報中的圖表保持整潔且可預測。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。  
1. 依索引取得投影片的參考。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/) 物件的 `add_auto_shape` 方法，將兩個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 加入投影片。  
1. 透過 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/) 物件的 `add_connector` 方法新增連接線，並指定連接線類型。  
1. 用連接線連結兩個圖形。  
1. 在圖形上設定您偏好的連接點。  
1. 儲存投影片。

以下 Python 程式碼示範如何指定首選的連接點：

```python
import aspose.slides as slides

# 初始化 Presentation 類別以建立 PPTX 檔案。
with slides.Presentation() as presentation:

    # 取得第一張投影片的 shapes 集合。
    shapes = presentation.slides[0].shapes

    # 新增橢圓 AutoShape。
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 新增矩形 AutoShape。
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # 在投影片的 shape 集合中新增連接線。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # 使用連接線將圖形連接起來。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 設定橢圓的首選連接點索引。
    site_index = 6

    # 檢查首選索引是否在可用的連接點數量內。
    if  ellipse.connection_site_count > site_index:
        # 指定橢圓 AutoShape 上的首選連接點。
        connector.start_shape_connection_site_index = site_index

    # 儲存簡報。
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **調整連接點**

您可以使用調整點來修改連接線。僅有公開調整點的連接線才能以此方式編輯。欲了解哪些連接線支援調整，請參考 [連接線類型](/slides/zh-hant/python-net/connector/#connector-types) 表格。

### **簡單案例**

考慮一條連接兩個圖形（A 與 B）的連接線與第三個圖形（C）相交的情況：

![連接線阻礙](connector-obstruction.png)

程式碼範例：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

為避免與第三個圖形相交，將連接線的垂直段向左移動即可：

![已修正的連接線阻礙](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **複雜案例** 

對於較高階的調整，請參考以下說明：

- 連接線的可調整點受一個公式控制，決定其位置。變更此點會改變整條連接線的形狀。  
- 連接線的調整點以嚴格排序的陣列儲存，從起點到終點依序編號。  
- 調整點值代表連接線形狀寬度/高度的百分比。  
  - 該形狀由連接線的起點與終點界定，並以 1000 為基準縮放。  
  - 第一、二、三個調整點分別代表：寬度百分比、高度百分比、再次的寬度百分比。  
- 計算調整點座標時，需考慮連接線的旋轉與翻轉。**注意：**對於所有列於 [連接線類型](/slides/zh-hant/python-net/connector/#connector-types) 的連接線，旋轉角度皆為 0。

#### **案例 1**

考慮兩個文字框物件以連接線相連的情形：

![已連結的圖形](connector-shape-complex.png)

程式碼範例：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 建立 Presentation 類別以建立 PPTX 檔案。
with slides.Presentation() as presentation:

    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 取得第一張投影片。
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # 新增連接線。
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # 設定連接線的方向。
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # 設定連接線的顏色。
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # 設定連接線的線寬。
    connector.line_format.width = 3

    # 使用連接線將圖形連結。
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # 取得連接線的調整點。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**調整**

將連接線的調整點值分別將寬度百分比提升 20%，高度百分比提升 200%：

```python
    # 變更調整點的值。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

結果：

![連接線調整 1](connector-adjusted-1.png)

為了建立一個模型，使我們能夠算出連接線各段的座標與形狀，請建立一個對應於 `connector.adjustments[0]` 的垂直元件的圖形：

```python
    # 繪製連接線的垂直組件。
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

結果：

![連接線調整 2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我們示範了使用基本原理進行簡單的連接線調整。實際情況下，必須同時考慮連接線的旋轉與顯示設定（由 `connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v` 控制）。以下說明其運作方式。

首先，於投影片上新增一個文字框物件（**To 1**）作為連接點，並建立一條新的綠色連接線將其與既有物件相連：

```python
    # 建立新的目標物件。
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # 建立新的連接線。
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # 使用新建立的連接線連接物件。
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # 取得連接線的調整點。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # 變更調整點的值。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

結果：

![連接線調整 3](connector-adjusted-3.png)

其次，建立一個圖形對應於通過新連接線調整點 `connector.adjustments[0]` 的 **水平** 段。使用 `connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v` 的值，套用繞固定點 `x0` 旋轉的座標轉換公式：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在本例中，物件的旋轉角度為 90 度，且連接線以垂直方式顯示，對應的程式碼如下：

```python
    # 儲存連接線座標。
    x = connector.x
    y = connector.y
    
    # 如果連接線被翻轉，修正其座標。
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # 使用調整點的值作為座標。
    x += connector.width * adjValue_0.raw_value / 100000
    
    # 轉換座標，因為 sin(90°) = 1 且 cos(90°) = 0。
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # 使用第二個調整點的值決定水平段的寬度。
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

結果：

![連接線調整 4](connector-adjusted-4.png)

我們示範了涉及簡單調整與更複雜（考慮旋轉）的調整點計算。掌握此知識後，您可以自行開發模型，或編寫程式碼取得 `GraphicsPath` 物件，甚至根據特定投影片座標設定連接線的調整點值。

## **取得連接線角度**

使用以下範例可在 Aspose.Slides 中求得投影片上連接線的角度。您將學會讀取連接線的端點並計算其方向，從而精確對齊箭頭、標籤與其他圖形。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的執行個體。  
1. 依索引取得投影片的參考。  
1. 取得連接線形狀。  
1. 使用線條的寬度與高度，以及圖形框架的寬度與高度，計算角度。

以下 Python 程式碼示範如何計算連接線形狀的角度：

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **常見問題**

**如何判斷連接線是否能「黏貼」到特定圖形？**

請檢查該圖形是否公開 [connection sites](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/connection_site_count/)。如果沒有或計數為零，則無法黏貼；此時請使用自由端點並手動定位。建議在附著前先檢查 site 數量。

**若我刪除其中一個已連接的圖形，連接線會怎樣？**

其兩端會被分離，連接線會以普通線段的形式留在投影片上，擁有自由的起點與終點。您可以自行刪除，或重新指派連接，必要時再呼叫 [reroute](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/connector/reroute/)。

**在將投影片複製到另一個簡報時，連接線的綁定會被保留嗎？**

通常會保留，前提是目標圖形也一併被複製。如果投影片被插入到未包含連接圖形的檔案中，端點會變為自由狀態，需要重新附著。