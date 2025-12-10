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
description: "使用 Aspose.Slides for .NET 管理 PowerPoint 墨迹对象——创建、编辑和设置数字墨迹的样式。获取有关轨迹、画笔颜色和大小的代码示例。"
---

PowerPoint提供墨迹功能，允许您绘制非标准图形，可用于突出其他对象、显示连接和流程，以及吸引幻灯片上特定项目的注意。 

Aspose.Slides提供[Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/)接口，包含创建和管理墨迹对象所需的类型。 

## **常规对象与墨迹对象的区别**

PowerPoint幻灯片上的对象通常由形状对象表示。形状对象在最简单的形式下是一个容器，定义对象本身的区域（即框架）以及其属性。后者包括容器区域大小、容器的形状、容器的背景等。有关信息，请参阅[Shape Layout Format](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape)。

然而，当PowerPoint处理墨迹对象时，它会忽略对象框架（容器）的所有属性，只保留其大小。容器区域的大小由标准的 `width` 和 `height` 值决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape 路径**

路径是记录用户书写数字墨迹时笔迹轨迹的基本元素或标准。路径是描述连接点序列的记录。 

最简单的编码形式指定每个采样点的 X 和 Y 坐标。当渲染所有连接点时，会生成如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## **绘图的画笔属性**

您可以使用画笔绘制连接路径元素点的线条。画笔拥有自己的颜色和大小，对应于 `Brush.Color` 和 `Brush.Size` 属性。 

### **设置 Ink 画笔颜色**

以下 C# 代码示例说明如何设置画笔颜色：
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


### **设置 Ink 画笔大小** 

以下 C# 代码示例说明如何设置画笔大小：
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


通常，画笔的宽度和高度不相等，PowerPoint 不会显示画笔大小（数据区域为灰色）。但当画笔宽度和高度相等时，PowerPoint 会以这种方式显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为更清晰起见，我们将增大墨迹对象的高度并查看重要尺寸： 

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑画笔的大小——它始终假定线的粗细为零（见最后一张图）。 

因此，要确定整个墨迹对象的可见区域，需要考虑路径对象的画笔大小。这里，目标对象（手写文本路径对象）已按容器（框架）大小进行缩放。当容器（框架）大小变化时，画笔大小保持不变，反之亦然。 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 在处理文本时表现相同：

![ink_powerpoint6](ink_powerpoint6.png)

**进一步阅读**

* 欲了解一般形状，请参阅[PowerPoint Shapes](https://docs.aspose.com/slides/net/powerpoint-shapes/)章节。 
* 有关有效值的更多信息，请参阅[Shape Effective Properties](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value)。