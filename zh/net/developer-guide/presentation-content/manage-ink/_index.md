---
title: 在 .NET 中管理演示文稿墨迹对象
linktitle: 管理墨迹
type: docs
weight: 95
url: /zh/net/manage-ink/
keywords:
- 墨迹
- 墨迹对象
- 墨迹轨迹
- 管理墨迹
- 绘制墨迹
- 绘图
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "管理 PowerPoint 墨迹对象——使用 Aspose.Slides for .NET 创建、编辑和样式化数字墨迹。获取轨迹、画笔颜色和大小的代码示例。"
---

PowerPoint 提供了墨迹功能，允许您绘制非标准图形，可用于突出显示其他对象、展示连接和流程，以及吸引幻灯片上特定项目的注意。

Aspose.Slides 提供了 [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/) 接口，包含创建和管理墨迹对象所需的类型。

## **常规对象与墨迹对象的区别**

PowerPoint 幻灯片上的对象通常由形状对象表示。形状对象在最简单的形式下是一个容器，定义对象本身的区域（即其框架）以及其属性。后者包括容器区域大小、容器形状、容器背景等。有关信息，请参阅 [形状布局格式](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape)。

然而，当 PowerPoint 处理墨迹对象时，它会忽略对象框架（容器）的所有属性，只保留其大小。容器区域的大小由标准的 `width` 和 `height` 值决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape 轨迹**

轨迹是记录用户书写数字墨迹时笔尖轨迹的基本元素或标准。轨迹是描述一系列连接点的记录。

最简单的编码形式指定每个采样点的 X 和 Y 坐标。当所有连接点渲染完成时，会产生如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## 用于绘图的画笔属性

您可以使用画笔绘制连接轨迹元素点的线条。画笔具有自己的颜色和大小，对应于 `Brush.Color` 和 `Brush.Size` 属性。

### **设置墨迹画笔颜色**

下面的 C# 代码演示如何设置画笔颜色：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```


### **设置墨迹画笔大小**

下面的 C# 代码演示如何设置画笔大小：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```


通常，画笔的宽度和高度不相等，PowerPoint 不会显示画笔大小（数据区域呈灰色）。但当画笔宽度和高度相等时，PowerPoint 会以如下方式显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为便于说明，我们将墨迹对象的高度增加，并检查重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑画笔的大小——它始终假定线条厚度为零（见最后一张图）。

因此，要确定整个墨迹对象的可见区域，必须考虑轨迹对象的画笔大小。此处，目标对象（手写文本轨迹对象）已按容器（框架）大小进行缩放。当容器（框架）大小变化时，画笔大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 在处理文本时也表现出相同的行为：

![ink_powerpoint6](ink_powerpoint6.png)

**进一步阅读**

* 想了解一般形状，请参阅 [PowerPoint 形状](https://docs.aspose.com/slides/net/powerpoint-shapes/) 部分。 
* 有关有效值的更多信息，请参阅 [形状有效属性](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value)。