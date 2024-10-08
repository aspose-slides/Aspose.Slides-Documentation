---
title: 连接器
type: docs
weight: 10
url: /python-net/connector/
keywords: "连接形状，连接器，PowerPoint 形状，PowerPoint 演示文稿，Python，Aspose.Slides for Python via .NET"
description: "在 Python 中连接 PowerPoint 形状"
---

PowerPoint 连接器是一种特殊的线，连接或链接两个形状，并在移动或重新定位时依然保持与形状的附着。

连接器通常连接到 *连接点*（绿色点），这些点在所有形状上默认存在。当光标靠近时，连接点会出现。

*调整点*（橙色点）仅存在于某些连接器上，用于修改连接器的位置和形状。

## **连接器的类型**

在 PowerPoint 中，您可以使用直线、肘部（带角度）和曲线连接器。

Aspose.Slides 提供这些连接器：

| 连接器                              | 图像                                                         | 调整点数量               |
| ----------------------------------- | ------------------------------------------------------------ | --------------------- |
| `ShapeType.LINE`                    | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                     |
| `ShapeType.STRAIGHT_CONNECTOR1`     | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                     |
| `ShapeType.BENT_CONNECTOR2`         | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                     |
| `ShapeType.BENT_CONNECTOR3`         | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                     |
| `ShapeType.BENT_CONNECTOR4`         | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                     |
| `ShapeType.BENT_CONNECTOR5`         | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                     |
| `ShapeType.CURVED_CONNECTOR2`       | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                     |
| `ShapeType.CURVED_CONNECTOR3`       | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                     |
| `ShapeType.CURVED_CONNECTOR4`       | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                     |
| `ShapeType.CURVED_CONNECTOR5`       | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                     |

## **使用连接器连接形状**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过其索引获取幻灯片的引用。
1. 使用 `Shapes` 对象公开的 `add_auto_shape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 通过定义连接器类型使用 `Shapes` 对象公开的 `add_auto_shape` 方法添加连接器。
1. 使用连接器连接形状。
1. 调用 `reroute` 方法应用最短连接路径。
1. 保存演示文稿。

以下 Python 代码展示如何在两个形状（一个椭圆和一个矩形）之间添加一个连接器（一个弯曲连接器）：

```python
import aspose.slides as slides

# 实例化表示 PPTX 文件的演示文稿类
with slides.Presentation() as input:
    # 访问特定幻灯片的形状集合
    shapes = input.slides[0].shapes

    # 添加一个椭圆自定义形状
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # 添加一个矩形自定义形状
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 300, 100, 100)

    # 向幻灯片形状集合添加一个连接器形状
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # 使用连接器连接形状
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 调用 reroute 设置形状之间的自动最短路径
    connector.reroute()

    # 保存演示文稿
    input.save("使用连接器连接形状_out.pptx", slides.export.SaveFormat.PPTX)

```

{{%  alert title="注意"  color="warning"   %}}

`connector.reroute` 方法重新路由连接器，强制其采用最短可能的路径连接形状。为了实现该目标，该方法可能会更改 `start_shape_connection_site_index` 和 `end_shape_connection_site_index` 点。

{{% /alert %}}

## **指定连接点**

如果您希望连接器在形状上使用特定点进行连接，您必须以这种方式指定首选连接点：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过其索引获取幻灯片的引用。
1. 使用 `Shapes` 对象公开的 `add_auto_shape` 方法向幻灯片添加两个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 通过定义连接器类型使用 `add_connector` 方法公开的 `Shapes` 对象添加连接器。
1. 使用连接器连接形状。
1. 设置形状上的首选连接点。
1. 保存演示文稿。

以下 Python 代码演示了一个指定首选连接点的操作：

```python
import aspose.slides as slides

# 实例化表示 PPTX 文件的演示文稿类
with slides.Presentation() as presentation:
    # 访问特定幻灯片的形状集合
    shapes = presentation.slides[0].shapes

    # 向幻灯片的形状集合添加一个连接器形状
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # 添加一个椭圆自定义形状
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # 添加一个矩形自定义形状
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 100, 100)

    # 使用连接器连接形状
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # 设置椭圆形状上首选连接点索引
    wantedIndex = 6

    # 检查首选索引是否小于最大连接点索引计数
    if  ellipse.connection_site_count > wantedIndex:
        # 在椭圆自定义形状上设置首选连接点
        connector.start_shape_connection_site_index = wantedIndex

    # 保存演示文稿
    presentation.save("在所需连接点上连接形状_out.pptx", slides.export.SaveFormat.PPTX)

```

## **调整连接器点**

您可以通过其调整点来调整现有连接器。只有具有调整点的连接器才能以这种方式进行更改。请参见 **[连接器的类型.](/slides/python-net/connector/#types-of-connectors)** 下的表格。

#### **简单案例**

考虑两个形状（A 和 B）之间的连接器穿过第三个形状（C）的情况：

![connector-obstruction](connector-obstruction.png)

代码：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    sld = pres.slides[0]
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shapeFrom
    connector.end_shape_connected_to = shapeTo
    connector.start_shape_connection_site_index = 2
```

为了避免或绕过第三个形状，我们可以通过将其垂直线向左移动来调整连接器：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```python
    adj2 = connector.adjustments[1]
    adj2.raw_value += 10000
```

### **复杂案例**

要进行更复杂的调整，您必须考虑以下几点：

* 连接器的可调整点与计算和确定其位置的公式强烈相关。因此，改变点的位置可能会改变连接器的形状。
* 连接器的调整点在数组中以严格顺序定义。从连接器的起点到终点对调整点进行编号。
* 调整点值反映连接器形状宽度/高度的百分比。
  * 该形状由连接器的起点和终点乘以 1000 进行界定。
  * 第一点、第二点和第三点分别定义宽度的百分比、高度的百分比和宽度的百分比（再次）。
* 对于确定连接器的调整点坐标的计算，您必须考虑连接器的旋转和反射。**注意**，所有在 **[连接器的类型](/slides/python-net/connector/#types-of-connectors)** 下显示的连接器的旋转角度为 0。

#### **案例 1**

考虑两个文本框对象通过连接器连接在一起的情况：

![connector-shape-complex](connector-shape-complex.png)

代码：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 文件的演示文稿类
with slides.Presentation() as pres:
    # 获取演示文稿中的第一张幻灯片
    sld = pres.slides[0]
    # 添加将通过连接器连接在一起的形状
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shapeFrom.text_frame.text = "从"
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shapeTo.text_frame.text = "到"
    # 添加连接器
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # 指定连接器的方向
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # 指定连接器的颜色
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # 指定连接器线的厚度
    connector.line_format.width = 3

    # 将形状连接在一起
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shapeTo
    connector.end_shape_connected_to = shapeTo
    connector.end_shape_connection_site_index = 2

    # 获取连接器的调整点
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
```

**调整**

我们可以通过将相应的宽度和高度百分比分别增加 20% 和 200% 来更改连接器的调整点值：

```python
    # 更改调整点的值
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

结果：

![connector-adjusted-1](connector-adjusted-1.png)

为了定义一个模型，使我们能够确定连接器个别部分的坐标和形状，让我们创建一个形状，对应于连接器在 connector.adjustments[0] 点的水平部分：

```python
    # 绘制连接器的垂直部分

    x = connector.x + connector.width * adjValue_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjValue_1.raw_value / 100000
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

结果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我们使用基本原则演示了简单的连接器调整操作。在正常情况下，您需要考虑连接器的旋转以及其显示（由 connector.rotation、connector.frame.flip_h 和 connector.frame.flip_v 设置）。我们现在将演示这一过程。

首先，让我们向幻灯片添加一个新的文本框对象（**到 1**），用于连接，并创建一个新的（绿色）连接器，将其连接到我们已创建的对象。

```python
    # 创建一个新的绑定对象
    shapeTo_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shapeTo_1.text_frame.text = "到 1"
    # 创建一个新的连接器
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    # 使用新创建的连接器连接对象
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shapeTo_1
    connector.end_shape_connection_site_index = 3
    # 获取连接器的调整点
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
    # 更改调整点的值 
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

结果：

![connector-adjusted-3](connector-adjusted-3.png)

其次，让我们创建一个形状，该形状对应于通过新连接器的调整点 connector.adjustments[0] 的水平部分。我们将使用来自连接器数据的连接器的旋转、connector.frame.flip_h 和 connector.frame.flip_v 的值，并应用流行的坐标转换公式，用于围绕给定点 x0 的旋转：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在我们的例子中，物体的旋转角度为 90 度，连接器垂直显示，因此这是对应的代码：

```python
    # 保存连接器坐标
    x = connector.x
    y = connector.y
    # 在连接器出现的情况下校正连接器坐标
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # 将调整点值作为坐标使用
    x += connector.width * adjValue_0.raw_value / 100000
    
    # 由于 Sin(90) = 1 和 Cos(90) = 0，因此进行坐标转换
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # 使用第二个调整点值确定水平部分的宽度
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

结果：

![connector-adjusted-4](connector-adjusted-4.png)

我们演示了涉及简单调整和复杂调整点（具有旋转角度的调整点）的计算。利用获得的知识，您可以开发自己的模型（或编写代码）以获取 `GraphicsPath` 对象，甚至根据特定幻灯片坐标设置连接器的调整点值。

## **查找连接器线的角度**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过其索引获取幻灯片的引用。
1. 访问连接器线形状。
1. 使用线宽、高度、形状框高度和形状框宽度来计算角度。

以下 Python 代码演示了一个计算连接器线形状角度的操作：

```python
import aspose.slides as slides
import math

def get_direction(w, h, flipH, flipV):
    endLineX = w * (-1 if flipH else 1)
    endLineY = h * (-1 if flipV else 1)
    endYAxisX = 0
    endYAxisY = h
    angle = math.atan2(endYAxisY, endYAxisX) - math.atan2(endLineY, endLineX)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation(path + "ConnectorLineAngle.pptx") as pres:
    slide = pres.slides[0]
    for i in range(len(slide.shapes)):
        dir = 0.0
        shape = slide.shapes[i]
        if (type(shape) is slides.AutoShape):
            if shape.shape_type == slides.ShapeType.LINE:
                dir = get_direction(shape.width, shape.Height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            dir = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)

        print(dir)

```