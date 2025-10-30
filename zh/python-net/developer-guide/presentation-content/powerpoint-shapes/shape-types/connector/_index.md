---
title: 在 Python 中管理演示文稿的连接器
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
description: "为 Python 应用提供在 PowerPoint 与 OpenDocument 幻灯片中绘制、连接和自动路由线条的能力——全面控制直线、折线和曲线连接器。"
---

## **简介**

PowerPoint 连接器是一种专用线条，用于链接两个形状，并在形状移动或重新定位时保持粘附。连接器附着在形状的**连接点**（绿色点）上。当指针靠近时会显示连接点。某些连接器提供的**调整手柄**（黄色点）可用于修改连接器的位置和形状。

## **连接器类型**

在 PowerPoint 中，你可以使用三种连接器：直线、折线（有角度）和曲线。

Aspose.Slides 支持以下连接器类型：

| 连接器类型                     | 图片                                                       | 调整点数量 |
| ------------------------------ | ---------------------------------------------------------- | ---------- |
| `ShapeType.LINE`               | ![Line connector](shapetype-lineconnector.png)            | 0          |
| `ShapeType.STRAIGHT_CONNECTOR1`| ![Straight connector 1](shapetype-straightconnector1.png) | 0          |
| `ShapeType.BENT_CONNECTOR2`    | ![Bent connector 2](shapetype-bent-connector2.png)        | 0          |
| `ShapeType.BENT_CONNECTOR3`    | ![Bent connector 3](shapetype-bentconnector3.png)         | 1          |
| `ShapeType.BENT_CONNECTOR4`    | ![Bent connector 4](shapetype-bentconnector4.png)         | 2          |
| `ShapeType.BENT_CONNECTOR5`    | ![Bent connector 5](shapetype-bentconnector5.png)         | 3          |
| `ShapeType.CURVED_CONNECTOR2`  | ![Curved connector 2](shapetype-curvedconnector2.png)     | 0          |
| `ShapeType.CURVED_CONNECTOR3`  | ![Curved connector 3](shapetype-curvedconnector3.png)     | 1          |
| `ShapeType.CURVED_CONNECTOR4`  | ![Curved connector 4](shapetype-curvedconnector4.png)     | 2          |
| `ShapeType.CURVED_CONNECTOR5`  | ![Curved connector 5](shapetype.curvedconnector5.png)     | 3          |

## **使用连接器连接形状**

本节演示如何在 Aspose.Slides 中使用连接器链接形状。你将向幻灯片添加连接器，并将其起点和终点分别附着到目标形状。使用连接点可确保在形状移动或调整大小时，连接器仍然“粘”在形状上。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。  
1. 按索引获取幻灯片引用。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象的 `add_auto_shape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象的 `add_connector` 方法添加连接器并指定类型。  
1. 使用连接器连接形状。  
1. 调用 `reroute` 方法以使用最短连接路径。  
1. 保存演示文稿。

下面的 Python 代码展示如何在两个形状（椭圆和矩形）之间添加折线连接器：

```python
import aspose.slides as slides

# 实例化 Presentation 类以创建 PPTX 文件。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片的形状集合。
    shapes = presentation.slides[0].shapes

    # 添加一个椭圆 AutoShape。
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 添加一个矩形 AutoShape。
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # 向幻灯片添加一个连接器。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # 使用连接器连接形状。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 调用 reroute 方法设置最短路径。
    connector.reroute()

    # 保存演示文稿。
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}}

`connector.reroute` 方法重新路由连接器，使其在形状之间采用可能的最短路径。为此，方法可能会更改 `start_shape_connection_site_index` 和 `end_shape_connection_site_index` 的值。

{{% /alert %}}

## **指定连接点**

本节说明如何在 Aspose.Slides 中将连接器附着到形状的特定连接点。通过定位精确的连接点，可控制连接器的路由和布局，实现演示文稿中整洁、可预期的图示。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。  
1. 按索引获取幻灯片引用。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象的 `add_auto_shape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象的 `add_connector` 方法添加连接器并指定类型。  
1. 使用连接器连接形状。  
1. 在形状上设置首选的连接点。  
1. 保存演示文稿。

下面的 Python 示例演示如何指定首选连接点：

```python
import aspose.slides as slides

# 实例化 Presentation 类以创建 PPTX 文件。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片的形状集合。
    shapes = presentation.slides[0].shapes

    # 添加一个椭圆 AutoShape。
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # 添加一个矩形 AutoShape。
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # 向幻灯片的形状集合添加一个连接器。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # 使用连接器连接形状。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 设置椭圆的首选连接点索引。
    site_index = 6

    # 检查首选索引是否在可用连接点数量范围内。
    if ellipse.connection_site_count > site_index:
        # 将首选连接点分配给椭圆 AutoShape。
        connector.start_shape_connection_site_index = site_index

    # 保存演示文稿。
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **调整连接器点**

你可以通过调整点修改连接器。仅那些暴露调整点的连接器才能以此方式编辑。有关哪些连接器支持调整，请参阅 [连接器类型](/slides/zh/python-net/connector/#connector-types) 表。

### **简单案例**

考虑以下情形：两个形状 (A 和 B) 之间的连接器穿过第三个形状 (C)：

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

为避免第三个形状，向左移动垂直段以调整连接器：

![Fixed connector obstruction](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **复杂案例** 

更高级的调整请参考以下内容：

- 连接器的可调点受公式控制，改变该点会改变连接器整体形状。  
- 调整点存储在严格有序的数组中，编号从连接器起点到终点。  
- 调整点值表示连接器形状宽度/高度的百分比。  
  - 该形状由连接器的起止点界定，并按 1000 缩放。  
  - 第一次、第二次和第三次调整点分别表示：宽度百分比、高度百分比、再次的宽度百分比。  
- 计算调整点坐标时，需要考虑连接器的旋转与翻转。**注意：** 对于所有列在 [连接器类型](/slides/zh/python-net/connector/#connector-types) 中的连接器，旋转角度均为 0。

#### **案例 1**

两个文本框对象通过连接器链接：

![Linked shapes](connector-shape-complex.png)

代码示例：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化 Presentation 类以创建 PPTX 文件。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 获取第一张幻灯片。
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # 添加连接器。
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # 设置连接器的方向。
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # 设置连接器的颜色。
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # 设置连接器的线条粗细。
    connector.line_format.width = 3

    # 使用连接器链接形状。
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # 获取连接器的调整点。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Adjustment**

通过分别将宽度百分比增加 20% 和高度百分比增加 200% 来修改连接器的调整点数值：

```python
    # 更改调整点的数值。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

结果：

![Connector adjustment 1](connector-adjusted-1.png)

为定义一个模型以确定连接器各段的坐标和形状，创建一个对应于 `connector.adjustments[0]` 处垂直段的形状：

```python
    # 绘制连接器的垂直段。
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

结果：

![Connector adjustment 2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我们演示了使用基本原理的简单调整。实际场景中，需要考虑连接器的旋转以及显示设置（由 `connector.rotation`、`connector.frame.flip_h` 和 `connector.frame.flip_v` 控制）。下面展示其实现过程。

首先，向幻灯片添加一个新的文本框对象（**To 1**）作为目标，并创建一个新的绿色连接器将其链接到已有对象。

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

    # 使用新创建的连接器连接对象。
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # 获取连接器的调整点。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # 更改调整点的数值。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

结果：

![Connector adjustment 3](connector-adjusted-3.png)

其次，创建一个对应于通过新连接器的 **水平** 段的形状，使用 `connector.adjustments[0]` 的值，并结合 `connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v`，按照围绕给定点 `x0` 的旋转坐标转换公式：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在本例中，对象的旋转角度为 90°，且连接器垂直显示，代码如下：

```python
    # 保存连接器坐标。
    x = connector.x
    y = connector.y
    
    # 如果翻转，则校正连接器坐标。
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # 使用调整点的数值作为坐标。
    x += connector.width * adjValue_0.raw_value / 100000
    
    # 转换坐标，因为 sin(90°) = 1 且 cos(90°) = 0。
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # 使用第二个调整点的数值确定水平段的宽度。
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

结果：

![Connector adjustment 4](connector-adjusted-4.png)

我们展示了涉及简单调整和更复杂（考虑旋转）的调整点计算。基于这些知识，你可以自行构建模型，或编写代码获取 `GraphicsPath` 对象，甚至根据幻灯片坐标设置连接器的调整点值。

## **获取连接线角度**

使用下面的示例可在 Aspose.Slides 中确定幻灯片上连接线的角度。你将学习如何读取连接器的端点并计算其方向，以便精准对齐箭头、标签及其他形状。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。  
1. 按索引获取幻灯片。  
1. 访问连接线形状。  
1. 使用线的宽高以及形状框的宽高计算角度。

下面的 Python 代码演示如何计算连接线形状的角度：

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

**如何判断连接器是否可以“粘附”到特定形状？**

检查该形状是否公开了[连接点](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/)。如果没有或数量为零，则无法粘附；此时应使用自由端点并手动定位。在附着之前检查连接点数量是明智的做法。

**删除已连接的形状后会发生什么？**

其两端会被分离；连接器仍保留在幻灯片上，作为普通线段且起止点为自由状态。你可以删除它，或重新分配连接并在需要时调用[reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/)。

**复制幻灯片到另一份演示文稿时，连接器的绑定是否会保留？**

一般会保留，只要目标形状也被一起复制。如果将幻灯片插入到未包含已连接形状的文件中，端点会变为自由状态，需要重新附着。