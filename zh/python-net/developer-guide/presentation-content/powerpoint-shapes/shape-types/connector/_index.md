---
title: 在 PowerPoint 中使用 Python 管理连接器
linktitle: 连接器
type: docs
weight: 10
url: /zh/python-net/connector/
keywords:
- 连接器
- 连接器类型
- 连接点
- 连接线
- 连接角度
- 连接形状
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "让 Python 应用在 PowerPoint 与 OpenDocument 幻灯片中绘制、连接并自动路由线条——全面控制直线、折线和曲线连接器。"
---

## **介绍**

PowerPoint 连接器是一种专用线条，用于链接两个形状，并在形状移动或重新定位时保持附着。连接器附着在形状的**连接点**（绿色点）上。将指针靠近时会显示连接点。某些连接器提供的**调整手柄**（黄色点），可用于修改连接器的位置和形状。

## **连接器类型**

在 PowerPoint 中，可以使用三种连接器：直线、折线（有角度）和曲线。

Aspose.Slides 支持以下连接器类型：

| 连接器类型                     | 图片                                                         | 调整点数 |
| ------------------------------ | ------------------------------------------------------------ | -------- |
| `ShapeType.LINE`               | ![直线连接器](shapetype-lineconnector.png)                 | 0        |
| `ShapeType.STRAIGHT_CONNECTOR1`| ![直线连接器 1](shapetype-straightconnector1.png)           | 0        |
| `ShapeType.BENT_CONNECTOR2`    | ![折线连接器 2](shapetype-bent-connector2.png)              | 0        |
| `ShapeType.BENT_CONNECTOR3`    | ![折线连接器 3](shapetype-bentconnector3.png)               | 1        |
| `ShapeType.BENT_CONNECTOR4`    | ![折线连接器 4](shapetype-bentconnector4.png)               | 2        |
| `ShapeType.BENT_CONNECTOR5`    | ![折线连接器 5](shapetype-bentconnector5.png)               | 3        |
| `ShapeType.CURVED_CONNECTOR2`  | ![曲线连接器 2](shapetype-curvedconnector2.png)             | 0        |
| `ShapeType.CURVED_CONNECTOR3`  | ![曲线连接器 3](shapetype-curvedconnector3.png)             | 1        |
| `ShapeType.CURVED_CONNECTOR4`  | ![曲线连接器 4](shapetype-curvedconnector4.png)             | 2        |
| `ShapeType.CURVED_CONNECTOR5`  | ![曲线连接器 5](shapetype.curvedconnector5.png)             | 3        |

## **使用连接器连接形状**

本节演示如何在 Aspose.Slides 中使用连接器链接形状。您将向幻灯片添加一个连接器，并将其起点和终点分别附着到目标形状上。使用连接点可确保即使形状移动或调整大小，连接器也会“粘住”。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。  
1. 按索引获取幻灯片的引用。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象的 `add_auto_shape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象。  
1. 使用同一对象的 `add_connector` 方法并指定连接器类型来添加连接器。  
1. 用连接器将形状连接起来。  
1. 调用 `reroute` 方法以应用最短连接路径。  
1. 保存演示文稿。

下面的 Python 代码演示了如何在两个形状（椭圆和矩形）之间添加折线连接器：

```python
import aspose.slides as slides

# 实例化 Presentation 类以创建 PPTX 文件。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片的形状集合。
    shapes = presentation.slides[0].shapes

    # 添加椭圆 AutoShape。
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 添加矩形 AutoShape。
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # 向幻灯片添加连接器。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # 用连接器连接形状。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 调用 reroute 设定最短路径。
    connector.reroute()

    # 保存演示文稿。
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

`connector.reroute` 方法会重新路由连接器，使其在形状之间走最短路径。为实现此目的，方法可能会更改 `start_shape_connection_site_index` 和 `end_shape_connection_site_index` 的值。

{{% /alert %}}

## **指定连接点**

本节说明如何在 Aspose.Slides 中将连接器附着到形状的特定连接点。通过精准选择连接点，可控制连接器的路由和布局，使演示文稿中的图形保持整洁、可预期。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。  
1. 按索引获取幻灯片的引用。  
1. 使用 `add_auto_shape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
1. 使用 `add_connector` 方法并指定类型来添加连接器。  
1. 用连接器将形状连接。  
1. 在形状上设置首选的连接点。  
1. 保存演示文稿。

下面的 Python 示例演示如何指定首选的连接点：

```python
import aspose.slides as slides

# 实例化 Presentation 类以创建 PPTX 文件。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片的形状集合。
    shapes = presentation.slides[0].shapes

    # 添加椭圆 AutoShape。
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 添加矩形 AutoShape。
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # 向形状集合添加连接器。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # 用连接器连接形状。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 为椭圆设置首选的连接点索引。
    site_index = 6

    # 检查首选索引是否在可用连接点数范围内。
    if ellipse.connection_site_count > site_index:
        # 将首选连接点分配给椭圆 AutoShape。
        connector.start_shape_connection_site_index = site_index

    # 保存演示文稿。
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **调整连接器点**

您可以通过调整点来修改连接器。仅那些公开调整点的连接器才能以此方式编辑。有关哪些连接器支持调整，请参阅 【Connector Types】(/slides/zh/python-net/connector/#connector-types) 表。

### **简单案例**

设想一个场景：两个形状（A 与 B）之间的连接器与第三个形状（C）相交：

![Connector obstruction](connector-obstruction.png)

代码示例：

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

为避免穿过第三个形状，可将连接器的垂直段向左移动：

![Fixed connector obstruction](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **复杂案例**

更高级的调整请参考以下要点：

- 连接器的可调点受公式支配，改变该点会影响整体形状。  
- 调整点存放在严格有序的数组中，编号从起点到终点。  
- 调整点的数值表示连接器形状宽/高的百分比。  
  - 形状以连接器的起止点为边界，比例以 1000 为基准。  
  - 第一次、第二次、第三次调整分别表示：宽度百分比、高度百分比、再次的宽度百分比。  
- 计算调整点坐标时需考虑连接器的旋转和翻转。**注意：** 对于所有在 【Connector Types】 中列出的连接器，旋转角度均为 0。

#### **案例 1**

两个文本框通过连接器相连的示例：

![Linked shapes](connector-shape-complex.png)

代码示例：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化 Presentation 类以创建 PPTX 文件。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # 添加连接器。
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # 设置连接器的箭头方向。
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # 设置颜色。
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # 设置线宽。
    connector.line_format.width = 3

    # 用连接器链接形状。
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # 获取连接器的调整点。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**调整**

将宽度百分比提升 20%，高度百分比提升 200%：

```python
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

结果：

![Connector adjustment 1](connector-adjusted-1.png)

为了定义一个模型来确定连接器段的坐标与形状，创建一个对应于 `connector.adjustments[0]` 的垂直组件：

```python
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

结果：

![Connector adjustment 2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我们展示了基于基本原理的简易调整。实际使用时，需要考虑连接器的旋转及其显示设置（由 `connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v` 控制）。下面演示完整过程。

首先，向幻灯片添加一个新的文本框对象（**To 1**），并创建一个新的绿色连接器将其与已有对象相连。

```python
    # 创建新的目标对象。
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # 创建新的连接器。
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # 用新建的连接器连接对象。
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # 获取连接器的调整点。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # 调整数值。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

结果：

![Connector adjustment 3](connector-adjusted-3.png)

其次，创建一个对应于通过新连接器的 **水平** 段的形状，该段经过 `connector.adjustments[0]`。利用 `connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v` 的数值，并按以下公式进行坐标转换（绕点 `x0` 旋转）：

```
X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;
```

在本例中，对象的旋转角度为 90°，且连接器垂直显示，代码如下：

```python
    x = connector.x
    y = connector.y
    
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    x += connector.width * adjValue_0.raw_value / 100000
    
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

结果：

![Connector adjustment 4](connector-adjusted-4.png)

我们展示了涉及简单调整和更复杂（考虑旋转）的调整点的计算方法。基于这些知识，您可以自行构建模型或编写代码，以获取 `GraphicsPath` 对象，或根据特定幻灯片坐标设置连接器的调整点数值。

## **获取连接线角度**

使用下面的示例，可在 Aspose.Slides 中计算幻灯片上连接线的角度。您将学习如何读取连接器的端点并计算其方向，从而精确对齐箭头、标签及其他形状。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。  
1. 按索引获取幻灯片。  
1. 访问连接线形状。  
1. 结合线的宽高以及形状框的宽高来计算角度。

以下 Python 代码演示如何计算连接线形状的角度：

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

## **常见问题**

**如何判断连接器是否可以“粘住”特定形状？**

检查该形状是否公开了[连接点](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/)。如果没有或计数为零，则无法粘附，此时请使用自由端点并手动定位。建议在附着前先检查计数。

**如果删除了已连接的形状，连接器会怎样？**

其两端将被分离，连接器会以普通线条形式留在幻灯片上，拥有自由的起止点。您可以删除它，或重新分配连接并在需要时调用 [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/)。

**复制幻灯片到另一份演示文稿时，连接器的绑定会保留吗？**

通常会保留，前提是目标形状也被一起复制。如果在未复制相应形状的情况下插入幻灯片，连接器的两端会变为自由端点，需要重新附着。