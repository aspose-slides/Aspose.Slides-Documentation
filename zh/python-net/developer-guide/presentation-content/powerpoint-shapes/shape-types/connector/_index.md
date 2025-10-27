---
title: 使用 Python 管理演示文稿中的连接线
linktitle: 连接线
type: docs
weight: 10
url: /zh/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/connector/
keywords:
- 连接线
- 连接线类型
- 连接点
- 连接线
- 连接角度
- 连接形状
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "为 Python 应用提供在 PowerPoint 和 OpenDocument 幻灯片中绘制、连接和自动路由线条的能力——全面控制直线、拐角线和曲线连接线。"
---

## **简介**

PowerPoint 连接线是一种专门的线段，用于链接两个形状，并在形状移动或在幻灯片上重新定位时保持粘附。连接线附着在形状上的 **连接点**（绿色点）上。将指针靠近时会显示连接点。某些连接线提供的 **调整手柄**（黄色点）可让您修改连接线的位置和形状。

## **连接线类型**

在 PowerPoint 中，您可以使用三种类型的连接线：直线、拐角线（有角度）和曲线。

Aspose.Slides 支持以下连接线类型：

| 连接线类型                      | 图片                                                       | 调整点数量 |
| ------------------------------- | ---------------------------------------------------------- | ---------- |
| `ShapeType.LINE`                | ![直线连接线](shapetype-lineconnector.png)                | 0          |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![直线连接线 1](shapetype-straightconnector1.png)         | 0          |
| `ShapeType.BENT_CONNECTOR2`     | ![弯曲连接线 2](shapetype-bent-connector2.png)            | 0          |
| `ShapeType.BENT_CONNECTOR3`     | ![弯曲连接线 3](shapetype-bentconnector3.png)             | 1          |
| `ShapeType.BENT_CONNECTOR4`     | ![弯曲连接线 4](shapetype-bentconnector4.png)             | 2          |
| `ShapeType.BENT_CONNECTOR5`     | ![弯曲连接线 5](shapetype-bentconnector5.png)             | 3          |
| `ShapeType.CURVED_CONNECTOR2`   | ![曲线连接线 2](shapetype-curvedconnector2.png)            | 0          |
| `ShapeType.CURVED_CONNECTOR3`   | ![曲线连接线 3](shapetype-curvedconnector3.png)            | 1          |
| `ShapeType.CURVED_CONNECTOR4`   | ![曲线连接线 4](shapetype-curvedconnector4.png)            | 2          |
| `ShapeType.CURVED_CONNECTOR5`   | ![曲线连接线 5](shapetype.curvedconnector5.png)            | 3          |

## **使用连接线连接形状**

本节演示如何在 Aspose.Slides 中使用连接线链接形状。您将向幻灯片添加一个连接线，并将其起点和终点分别连接到目标形状。使用连接点可确保即使形状移动或调整大小，连接线仍然“粘附”在形状上。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片的引用。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象的 `add_auto_shape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象的 `add_connector` 方法添加一个连接线，并指定连接线类型。  
1. 将形状通过连接线连接起来。  
1. 调用 `reroute` 方法以应用最短的连接路径。  
1. 保存演示文稿。

以下 Python 代码展示了如何在两个形状（椭圆和矩形）之间添加一个弯曲连接线：

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

    # 向幻灯片添加一个连接线。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # 将形状通过连接线连接。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 调用 reroute 设置最短路径。
    connector.reroute()

    # 保存演示文稿。
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}}

`connector.reroute` 方法会重新路由连接线，强制其在形状之间走最短路径。为实现此目的，方法可能会更改 `start_shape_connection_site_index` 和 `end_shape_connection_site_index` 的值。

{{% /alert %}}

## **指定连接点**

本节解释如何在 Aspose.Slides 中将连接线附着到形状的特定连接点。通过定位精确的连接站点，您可以控制连接线的路由和布局，从而在演示文稿中生成整洁、可预测的图表。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片的引用。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 的 `add_auto_shape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 的 `add_connector` 方法添加一个连接线，并指定连接线类型。  
1. 将形状通过连接线连接。  
1. 在形状上设置首选的连接点。  
1. 保存演示文稿。

以下 Python 代码演示如何指定首选的连接点：

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

    # 向幻灯片的形状集合添加一个连接线。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # 将形状通过连接线连接。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 为椭圆设置首选的连接站点索引。
    site_index = 6

    # 检查首选索引是否在可用站点数量范围内。
    if ellipse.connection_site_count > site_index:
        # 为椭圆 AutoShape 分配首选的连接站点。
        connector.start_shape_connection_site_index = site_index

    # 保存演示文稿。
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **调整连接线点**

您可以使用调整点来修改连接线。只有公开了调整点的连接线才能以此方式编辑。有关哪些连接线支持调整，请参阅 [连接线类型](/slides/zh/python-net/connector/#connector-types) 表。

### **简单案例**

考虑一种情况：两个形状（A 与 B）之间的连接线穿过第三个形状（C）：

![连接线阻塞](connector-obstruction.png)

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

为了避免第三个形状的阻塞，将连接线的垂直段向左移动进行调整：

![已修复的连接线阻塞](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **复杂案例** 

对于更高级的调整，请考虑以下内容：

- 连接线的可调点受到公式的约束，公式决定其位置。更改该点会改变整个连接线的形状。  
- 连接线的调整点存储在严格有序的数组中，编号从连接线的起点到终点。  
- 调整点的值表示连接线形状宽度/高度的百分比。  
  - 形状的边界由连接线的起点和终点决定，并按 1000 缩放。  
  - 第一个、第二个和第三个调整点分别表示：宽度百分比、高度百分比、再次的宽度百分比。  
- 在计算调整点坐标时，需要考虑连接线的旋转和翻转。**注意：** 对于 [连接线类型](/slides/zh/python-net/connector/#connector-types) 中列出的所有连接线，旋转角度均为 0。

#### **案例 1**

考虑两个文本框对象通过连接线链接的情况：

![已链接形状](connector-shape-complex.png)

代码示例：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化 Presentation 类以创建 PPTX 文件。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加第一个矩形并设置文本。
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # 添加一个连接线。
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # 设置连接线的方向。
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # 设置连接线的颜色。
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # 设置连接线的线宽。
    connector.line_format.width = 3

    # 将形状通过连接线链接。
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # 获取连接线的调整点。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**调整**

将连接线的调整点数值分别增加 20% 的宽度百分比和 200% 的高度百分比：

```python
    # 更改调整点的数值。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

效果如下：

![连接线调整 1](connector-adjusted-1.png)

为了定义一个模型，以确定连接线段的坐标和形状，创建一个对应于 `connector.adjustments[0]` 处垂直组件的形状：

```python
    # 绘制连接线的垂直组件。
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

效果如下：

![连接线调整 2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我们展示了使用基本原理进行的简单连接线调整。实际场景中，您必须考虑连接线的旋转以及其显示设置（由 `connector.rotation`、`connector.frame.flip_h` 和 `connector.frame.flip_v` 控制）。下面说明具体过程。

首先，在幻灯片上添加一个新的文本框对象（**To 1**）用于连接，并创建一个新的绿色连接线将其与现有对象链接。

```python
    # 创建一个新的目标对象。
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # 创建一个新的连接线。
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # 使用新建的连接线连接对象。
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # 获取连接线的调整点。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # 更改调整点的数值。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

效果如下：

![连接线调整 3](connector-adjusted-3.png)

其次，创建一个对应于 **水平** 段的形状，该段穿过新的连接线调整点 `connector.adjustments[0]`。使用 `connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v` 的值，并按照围绕点 `x0` 旋转的标准坐标转换公式：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在本例中，对象的旋转角度为 90 度且连接线垂直显示，对应代码如下：

```python
    # 保存连接线坐标。
    x = connector.x
    y = connector.y
    
    # 若已翻转，则校正坐标。
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # 使用调整点的数值作为坐标。
    x += connector.width * adjValue_0.raw_value / 100000
    
    # 因为 sin(90°) = 1 且 cos(90°) = 0，进行坐标转换。
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # 使用第二个调整点的数值确定水平段的宽度。
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

效果如下：

![连接线调整 4](connector-adjusted-4.png)

我们展示了涉及简单调整和更复杂（考虑旋转）的调整点的计算。利用这些知识，您可以自行构建模型或编写代码，以获取 `GraphicsPath` 对象，甚至根据特定幻灯片坐标设置连接线的调整点数值。

## **查找连接线角度**

使用下面的示例，可在 Aspose.Slides 中确定幻灯片上连接线的角度。您将学习如何读取连接线的端点并计算其方向，以便精确对齐箭头、标签和其他形状。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片的引用。  
1. 访问连接线形状。  
1. 使用线的宽度与高度以及形状框架的宽度与高度计算角度。

以下 Python 代码演示如何为连接线形状计算角度：

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

**如何判断某个连接线是否可以“粘附”到特定形状上？**

检查该形状是否公开了 [connection sites](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/)。如果没有或计数为零，则无法粘附；此时请使用自由端点并手动定位。建议在附着前先检查站点计数。

**如果删除了已连接的形状之一，连接线会怎样？**

其两端将被分离；连接线仍会保留在幻灯片上，表现为普通的自由起止线。您可以删除它，或重新指定连接并在需要时调用 [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/)。

**在将幻灯片复制到另一个演示文稿时，连接线的绑定会保留吗？**

通常会保留，前提是目标形状也被一起复制。如果幻灯片被插入到不包含已连接形状的文件中，连接线的两端会变为自由端，需要重新附着。