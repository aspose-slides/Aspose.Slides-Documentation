---
title: 使用 Python 管理演示文稿中的墨迹对象
linktitle: 管理墨迹
type: docs
weight: 95
url: /zh/python-net/manage-ink/
keywords:
- 墨迹
- 墨迹对象
- 墨迹轨迹
- 管理墨迹
- 绘制墨迹
- 绘图
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 管理 PowerPoint 墨迹对象——创建、编辑和样式化数字墨迹。获取轨迹、画笔颜色和大小的代码示例。"
---

PowerPoint 提供了墨迹功能，允许您绘制非标准图形，可用于突出其他对象、显示连接和流程，以及在幻灯片上吸引对特定项目的注意。

Aspose.Slides 提供了 [aspose.slides.ink](https://reference.aspose.com/slides/python-net/aspose.slides.ink/) 命名空间，其中包含创建和管理墨迹对象所需的类型。

## **常规对象与墨迹对象的区别**

PowerPoint 幻灯片上的对象通常由形状对象表示。形状对象在最简单的形式下是一个容器，定义对象本身的区域（其框架）以及其属性。后者包括容器区域大小、容器形状、容器背景等。有关信息，请参阅 [Shape Layout Format](https://docs.aspose.com/slides/python-net/shape-manipulations/#access-layout-formats-for-shape)。

然而，当 PowerPoint 处理墨迹对象时，它会忽略对象框架（容器）的所有属性，仅保留其大小。容器区域的大小由标准的 `width` 和 `height` 值决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape 轨迹**

轨迹是记录用户书写数字墨迹时笔尖运动轨迹的基本元素或标准。轨迹是描述一系列相连点的记录。

最简单的编码形式指定每个采样点的 X 和 Y 坐标。当渲染所有相连点时，会产生如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## 绘图的画笔属性

您可以使用画笔绘制连接轨迹元素点的线条。画笔拥有自己的颜色和大小，对应 `Brush.color` 和 `Brush.size` 属性。

### **设置墨迹画笔颜色**

以下 Python 代码展示了如何为画笔设置颜色：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```


### **设置墨迹画笔大小**

以下 Python 代码展示了如何为画笔设置大小：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```


通常，画笔的宽度和高度不相等，PowerPoint 不会显示画笔大小（数据区域为灰色）。但当画笔的宽度和高度相等时，PowerPoint 会以如下方式显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为清晰起见，让我们增加墨迹对象的高度并查看重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑画笔的大小——它始终假定线条的粗细为零（见最后一张图）。

因此，要确定整个墨迹对象的可见区域，必须考虑轨迹对象的画笔大小。此处，目标对象（手写文字轨迹对象）已按容器（框架）大小进行缩放。当容器（框架）大小改变时，画笔大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 在处理文本时表现相同：

![ink_powerpoint6](ink_powerpoint6.png)

**进一步阅读**

* 欲了解一般形状，请参阅 [PowerPoint Shapes](https://docs.aspose.com/slides/python-net/powerpoint-shapes/) 部分。
* 欲获取有效值的更多信息，请参阅 [Shape Effective Properties](https://docs.aspose.com/slides/python-net/shape-effective-properties/#get-effective-font-height-value)。