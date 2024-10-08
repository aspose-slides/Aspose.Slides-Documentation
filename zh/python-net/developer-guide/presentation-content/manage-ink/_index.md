---
title: 管理墨水
type: docs
weight: 95
url: /zh/python-net/manage-ink/
keywords: "PowerPoint中的墨水，墨水工具，Python墨水，在PowerPoint中绘图，PowerPoint演示文稿，Python，Aspose.Slides for Python via .NET"
description: "使用墨水工具在PowerPoint Python中绘制对象"
---

PowerPoint提供了墨水功能，允许您绘制非标准图形，可用于突出显示其他对象，显示连接和过程，并吸引观众对幻灯片中特定项目的注意。

Aspose.Slides提供了[Aspose.Slides.Ink](https://reference.aspose.com/slides/python-net/aspose.slides.ink/)接口，包含创建和管理墨水对象所需的类型。

## **常规对象与墨水对象的区别**

PowerPoint幻灯片上的对象通常由形状对象表示。形状对象在其最简单的形式中，是一个定义对象自身区域（其框架）及其属性的容器。后者包括容器区域大小、容器形状、容器背景等。有关信息，请参见[形状布局格式](https://docs.aspose.com/slides/python-net/shape-manipulations/#access-layout-formats-for-shape)。

然而，当PowerPoint处理墨水对象时，它忽略对象框架（容器）的所有属性，除了其大小。容器区域的大小由标准的`width`和`height`值决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨水轨迹**

轨迹是记录用户书写数字墨水时笔的运动轨迹的基本元素或标准。轨迹是描述一系列连接点的记录。

编码的最简单形式指定每个样本点的X和Y坐标。当所有连接点被渲染时，它们会生成这样一个图像：

![ink_powerpoint2](ink_powerpoint2.png)

## 绘图用的笔刷属性

您可以使用笔刷来绘制连接轨迹元素点的线条。笔刷具有自己的颜色和大小，对应于`Brush.Color`和`Brush.Size`属性。

### **设置墨水笔刷颜色**

以下Python代码向您展示如何为笔刷设置颜色：

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

### **设置墨水笔刷大小**

以下Python代码向您展示如何为笔刷设置大小：

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

通常，笔刷的宽度和高度不匹配，因此PowerPoint不显示笔刷大小（数据部分为灰色）。但当笔刷的宽度和高度匹配时，PowerPoint会这样显示它的大小：

![ink_powerpoint3](ink_powerpoint3.png)

为了清楚起见，让我们增加墨水对象的高度并查看重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑笔刷的大小——它总是认为线条的厚度为零（见最后一张图像）。

因此，为了确定整个墨水对象的可见区域，我们必须考虑轨迹对象的笔刷大小。这里，目标对象（手写文本轨迹对象）已缩放到容器（框架）大小。当容器（框架）的大小变化时，笔刷大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint在处理文本时表现出相同的行为：

![ink_powerpoint6](ink_powerpoint6.png)

**进一步阅读**

* 要了解一般的形状，请参见[PowerPoint形状](https://docs.aspose.com/slides/python-net/powerpoint-shapes/)部分。
* 有关有效值的更多信息，请参见[形状有效属性](https://docs.aspose.com/slides/python-net/shape-effective-properties/#get-effective-font-height-value)。
