---
title: 在演示文稿中使用 Python 管理连接器
linktitle: 连接器
type: docs
weight: 10
url: /zh/python-net/connector/
keywords:
- connector
- connector type
- connector point
- connector line
- connector angle
- connect shapes
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "为 Python 应用提供在 PowerPoint 与 OpenDocument 幻灯片中绘制、连接和自动路由线条的能力——全面掌控直线、弯头和曲线连接器。"
---

## **简介**

PowerPoint 连接器是一种特殊的线条，用于链接两个形状，并在形状移动或重新定位时保持粘附。连接器附着在形状的 **连接点**（绿色点）上。当指针接近这些点时会显示出来。某些连接器提供的 **调整手柄**（黄色点）可让您修改连接器的位置和形状。

## **连接器类型**

在 PowerPoint 中，您可以使用三种类型的连接器：直线、弯头（带角度）和曲线。

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

本节演示如何在 Aspose.Slides 中使用连接器链接形状。您将在幻灯片中添加连接器，并将其起点和终点分别连接到目标形状。使用连接点可确保即使形状移动或改变大小，连接器仍保持“粘附”。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象的 `add_auto_shape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象的 `add_connector` 方法添加连接器并指定其类型。  
1. 将形状通过连接器连接起来。  
1. 调用 `reroute` 方法以获得最短的连接路径。  
1. 保存演示文稿。

下面的 Python 代码演示了如何在两个形状（椭圆和矩形）之间添加一个弯头连接器：

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

    # 将形状通过连接器连接。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 调用 reroute 设定最短路径。
    connector.reroute()

    # 保存演示文稿。
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}}

`connector.reroute` 方法会重新路由连接器，迫使其在形状之间走最短路径。为实现此目的，方法可能会更改 `start_shape_connection_site_index` 和 `end_shape_connection_site_index` 的值。

{{% /alert %}}

## **指定连接点**

本节说明如何在 Aspose.Slides 中将连接器附着到形状的特定连接点。通过精准定位连接点，您可以控制连接器的路由和布局，从而在演示文稿中生成整洁、可预期的图示。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 的 `add_auto_shape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象。  
1. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 的 `add_connector` 方法添加连接器并指定类型。  
1. 将形状通过连接器连接。  
1. 在形状上设置首选的连接点。  
1. 保存演示文稿。

下面的 Python 代码演示了如何指定首选的连接点：

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

    # 将形状通过连接器连接。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 为椭圆设置首选的连接站点索引。
    site_index = 6

    # 检查首选索引是否在可用站点数范围内。
    if  ellipse.connection_site_count > site_index:
        # 将首选连接站点分配给椭圆 AutoShape。
        connector.start_shape_connection_site_index = site_index

    # 保存演示文稿。
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **调整连接器点**

您可以通过调整点来修改连接器。仅那些公开调整点的连接器才可以这样编辑。有关哪些连接器支持调整，请参见 **连接器类型** 表。

### **简单案例**

考虑一种情况：两个形状（A 和 B）之间的连接器穿过第三个形状（C）：

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

为避免第三个形状，向左移动垂直段来调整连接器：

![Fixed connector obstruction](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **复杂案例**

更高级的调整请参考以下内容：

- 连接器的可调点受公式控制，改变该点会影响整个连接器的形状。  
- 调整点存放在严格有序的数组中，顺序从连接器起点到终点。  
- 调整点的数值表示连接器形状宽度/高度的百分比。  
  - 形状的边界由连接器的起点和终点决定，比例以 1000 为基准。  
  - 第一个、第二个和第三个调整点分别表示：宽度百分比、高度百分比、再次的宽度百分比。  
- 计算调整点坐标时，需要考虑连接器的旋转和翻转。**注意：** 对于所有在 **连接器类型** 中列出的连接器，旋转角度均为 0。

#### **案例 1**

两个文本框对象通过连接器相连：

![Linked shapes](connector-shape-complex.png)

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

    # 添加连接器。
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # 设置连接器的箭头方向。
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # 设置连接器颜色。
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
    # 修改调整点的数值。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

效果如下：

![Connector adjustment 1](connector-adjusted-1.png)

为了定义一个模型，以确定连接器各段的坐标和形状，创建一个对应于 `connector.adjustments[0]` 的垂直组件形状：

```python
    # 绘制连接器的垂直组件。
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

效果如下：

![Connector adjustment 2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我们展示了使用基础原理进行的简单连接器调整。在实际场景中，需要考虑连接器的旋转和显示设置（由 `connector.rotation`、`connector.frame.flip_h` 与 `connector.frame.flip_v` 控制）。下面演示完整过程。

首先，向幻灯片添加一个新的文本框对象（**To 1**）并创建一个新的绿色连接器将其与已有对象相连。

```python
    # 创建新目标对象。
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # 创建新连接器。
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # 用新连接器连接对象。
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # 获取连接器的调整点。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # 修改调整点数值。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

效果如下：

![Connector adjustment 3](connector-adjusted-3.png)

其次，创建一个对应于通过新的调整点 `connector.adjustments[0]` 的 **水平** 段的形状。使用 `connector.rotation`、`connector.frame.flip_h`、`connector.frame.flip_v` 的值，并利用围绕坐标点 `x0` 的标准旋转公式：

```
X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;
```

在本例中，对象的旋转角度为 90 度且连接器垂直显示，对应代码如下：

```python
    # 保存连接器坐标。
    x = connector.x
    y = connector.y
    
    # 如果被翻转，校正坐标。
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # 使用调整点数值作为坐标。
    x += connector.width * adjValue_0.raw_value / 100000
    
    # 由于 sin(90°)=1 且 cos(90°)=0，进行坐标转换。
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # 使用第二个调整点数值确定水平段宽度。
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

效果如下：

![Connector adjustment 4](connector-adjusted-4.png)

我们展示了涉及简单调整以及考虑旋转的更复杂调整点的计算方法。利用这些知识，您可以构建自己的模型，或编写代码获取 `GraphicsPath` 对象，甚至根据特定幻灯片坐标设置连接器的调整点数值。

## **获取连接线角度**

使用下面的示例可以在 Aspose.Slides 中确定幻灯片上连接线的角度。您将学习如何读取连接器的端点并计算其方向，以便精确对齐箭头、标签等形状。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 访问连接线形状。  
1. 使用线的宽高以及形状框架的宽高来计算角度。

以下 Python 代码演示了如何计算连接线形状的角度：

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

**如何判断某个连接器是否可以“粘附”到特定形状上？**

检查该形状是否公开了[连接站点](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/)。如果没有或数量为零，则无法粘附；此时请使用自由端点并手动定位。在附加前检查站点数量是明智的做法。

**如果删除已连接的形状，连接器会怎样？**

其两端会被分离，连接器会以普通线的形式保留在幻灯片上，起点/终点为自由状态。您可以选择删除它，或重新分配连接并在需要时调用 [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/)。

**将幻灯片复制到另一份演示文稿时，连接器的绑定是否会被保留？**

通常会保留，只要对应的目标形状也一起复制。如果在不包含已连接形状的情况下插入幻灯片，连接器的两端会变为自由状态，需要手动重新附着。