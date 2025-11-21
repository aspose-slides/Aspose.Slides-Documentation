---
title: 在 Python 中管理演示文稿的连接线
linktitle: 连接线
type: docs
weight: 10
url: /zh/python-net/connector/
keywords:
- 连接线
- 连接线类型
- 连接点
- 连接线段
- 连接角度
- 连接形状
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "让 Python 应用程序在 PowerPoint 和 OpenDocument 幻灯片中绘制、连接并自动路由线条——全面控制直线、折线和曲线连接线。"
---

## **介绍**

PowerPoint 连接线是一种专用线条，用于链接两个形状，并在形状在幻灯片上移动或重新定位时保持附着。连接线附着在形状上的 **连接点**（绿色点）上。当指针靠近时会出现连接点。某些连接线提供的 **调整手柄**（黄色点）可让您修改连接线的位置和形状。

## **连接线类型**

在 PowerPoint 中，您可以使用三种类型的连接线：直线、折线（有角度）和曲线。

Aspose.Slides 支持以下连接线类型：

| 连接线类型                  | Image                                                     | 调整点数量 |
| ------------------------------- | --------------------------------------------------------- | --------------------------- |
| `ShapeType.LINE`                | ![Line connector](shapetype-lineconnector.png)            | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Straight connector 1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BENT_CONNECTOR2`     | ![Bent connector 2](shapetype-bent-connector2.png)        | 0                           |
| `ShapeType.BENT_CONNECTOR3`     | ![Bent connector 3](shapetype-bentconnector3.png)         | 1                           |
| `ShapeType.BENT_CONNECTOR4`     | ![Bent connector 4](shapetype-bentconnector4.png)         | 2                           |
| `ShapeType.BENT_CONNECTOR5`     | ![Bent connector 5](shapetype-bentconnector5.png)         | 3                           |
| `ShapeType.CURVED_CONNECTOR2`   | ![Curved connector 2](shapetype-curvedconnector2.png)     | 0                           |
| `ShapeType.CURVED_CONNECTOR3`   | ![Curved connector 3](shapetype-curvedconnector3.png)     | 1                           |
| `ShapeType.CURVED_CONNECTOR4`   | ![Curved connector 4](shapetype-curvedconnector4.png)     | 2                           |
| `ShapeType.CURVED_CONNECTOR5`   | ![Curved connector 5](shapetype.curvedconnector5.png)     | 3                           |

## **使用连接线连接形状**

本节演示如何在 Aspose.Slides 中使用连接线链接形状。您将在幻灯片上添加一条连接线，并将其起点和终点附着到目标形状。使用连接点可确保连接线在形状移动或调整大小时仍然“粘附”。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 根据索引获取幻灯片的引用。  
3. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象公开的 `add_auto_shape` 方法，向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象。  
4. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象公开的 `add_connector` 方法添加连接线，并指定连接线类型。  
5. 使用该连接线连接形状。  
6. 调用 `reroute` 方法以应用最短的连接路径。  
7. 保存演示文稿。

以下 Python 代码展示了如何在两个形状（椭圆和矩形）之间添加弯曲连接线：
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

    # 使用连接线将形状连接起来。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 调用 reroute 以设置最短路径。
    connector.reroute()

    # 保存演示文稿。
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="NOTE" color="warning" %}}
`connector.reroute` 方法会重新路由连接线，强制其在形状之间走最短路径。为此，该方法可能会更改 `start_shape_connection_site_index` 和 `end_shape_connection_site_index` 的值。
{{% /alert %}}

## **指定连接点**

本节说明如何在 Aspose.Slides 中将连接线附着到形状的特定连接点。通过定位精确的连接点，您可以控制连接线的路由和布局，在演示文稿中生成清晰、可预期的图表。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 根据索引获取幻灯片的引用。  
3. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象公开的 `add_auto_shape` 方法，向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象。  
4. 使用 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象的 `add_connector` 方法添加连接线，并指定其类型。  
5. 使用该连接线连接形状。  
6. 在形状上设置您偏好的连接点。  
7. 保存演示文稿。

以下 Python 代码演示了如何指定偏好的连接点：
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

    # 向幻灯片的形状集合添加连接线。
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # 使用连接线连接形状。
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 设置椭圆的首选连接站点索引。
    site_index = 6

    # 检查首选索引是否在可用站点计数范围内。
    if  ellipse.connection_site_count > site_index:
        # 为椭圆 AutoShape 分配首选连接站点。
        connector.start_shape_connection_site_index = site_index

    # 保存演示文稿。
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```


## **调整连接线点**

您可以使用调整点来修改连接线。只有公开调整点的连接线才能以此方式编辑。有关哪些连接线支持调整的详细信息，请参阅 [Connector Types](/slides/zh/python-net/connector/#connector-types) 下的表格。

### **简单案例**

考虑一种情况，两个形状（A 和 B）之间的连接线穿过第三个形状（C）：

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


为避免第三个形状，调整连接线，将其垂直段向左移动：

![Fixed connector obstruction](connector-obstruction-fixed.png)
```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```


### **复杂案例**

对于更高级的调整，请考虑以下内容：

- 连接线的可调点受决定其位置的公式控制。更改此点会改变连接线的整体形状。  
- 连接线的调整点存储在严格有序的数组中，编号从连接线的起点到终点。  
- 调整点值表示连接线形状宽度/高度的百分比。  
  - 该形状由连接线的起点和终点限定，并按 1000 进行缩放。  
  - 第一、第二、第三个调整点分别表示：宽度百分比、高度百分比以及再次的宽度百分比。  
- 在计算调整点坐标时，需要考虑连接线的旋转和翻转。**注意：** 对于在 [Connector Types](/slides/zh/python-net/connector/#connector-types) 中列出的所有连接线，旋转角度为 0。

#### **案例 1**

考虑一种情况，两个文本框对象通过连接线链接在一起：

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

    # 添加一个连接线。
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # 设置连接线的方向。
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # 设置连接线的颜色。
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # 设置连接线的线宽。
    connector.line_format.width = 3

    # 使用连接线链接形状。
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # 获取连接线的调整点。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```


**Adjustment**

通过分别将宽度百分比增加 20% 和高度百分比增加 200%，来更改连接线的调整点值：
```python
    # 更改调整点的值。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```


结果：

![Connector adjustment 1](connector-adjusted-1.png)

为了定义一个模型，以便确定连接线段的坐标和形状，请创建一个对应于 `connector.adjustments[0]` 的垂直组件的形状：
```python
    # 绘制连接线的垂直部分。
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```


结果：

![Connector adjustment 2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我们演示了使用基本原理的简单连接线调整。在典型场景下，您必须考虑连接线的旋转及其显示设置（由 `connector.rotation`、`connector.frame.flip_h` 和 `connector.frame.flip_v` 控制）。以下是其工作过程。

首先，向幻灯片添加一个新的文本框对象（**To 1**，用于连接），并创建一条新的绿色连接线将其链接到已有对象。
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

    # 使用新创建的连接线连接对象。
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # 获取连接线的调整点。
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # 更改调整点的值。
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```


结果：

![Connector adjustment 3](connector-adjusted-3.png)

其次，创建一个形状对应于通过新连接线的调整点 `connector.adjustments[0]` 的 **水平** 段。使用 `connector.rotation`、`connector.frame.flip_h` 和 `connector.frame.flip_v` 的值，并应用围绕给定点 `x0` 进行旋转的标准坐标转换公式：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在我们的例子中，对象的旋转角度为 90 度，且连接线竖直显示，因此对应的代码如下：
```python
    # 保存连接线坐标。
    x = connector.x
    y = connector.y
    
    # 如果连接线被翻转，则校正坐标。
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # 使用调整点的值作为坐标。
    x += connector.width * adjValue_0.raw_value / 100000
    
    # 转换坐标，因为 sin(90°)=1 且 cos(90°)=0。
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # 使用第二个调整点的值确定水平段的宽度。
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```


结果：

![Connector adjustment 4](connector-adjusted-4.png)

我们演示了涉及简单调整和更复杂的（考虑旋转的）调整点的计算。利用这些知识，您可以自行开发模型或编写代码，获取 `GraphicsPath` 对象，甚至根据具体幻灯片坐标设置连接线的调整点值。

## **查找连接线角度**

使用下面的示例可确定幻灯片中连接线的角度。您将学习如何读取连接线的端点并计算其方向，以便精确对齐箭头、标签和其他形状。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 根据索引获取幻灯片的引用。  
3. 访问连接线形状。  
4. 使用该线的宽度和高度，以及形状框的宽度和高度来计算角度。

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

**如何判断连接线是否可以“粘附”到特定形状？**

检查该形状是否公开了 [connection sites](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/)。如果没有或计数为零，则无法粘附；此时请使用自由端点并手动定位。建议在附着前检查站点计数。

**如果删除已连接的形状，连接线会怎样？**

其两端将被分离；连接线仍然保留在幻灯片上，作为普通的自由起止线。您可以删除它，或重新分配连接，并在需要时使用 [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/)。

**将幻灯片复制到另一份演示文稿时，连接线的绑定会被保留吗？**

通常会保留，前提是目标形状也一并复制。如果幻灯片插入到不包含已连接形状的其他文件中，端点将变为自由状态，需重新附着。