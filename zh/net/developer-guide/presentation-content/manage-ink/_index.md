---
title: 管理墨水
type: docs
weight: 95
url: /zh/net/manage-ink/
keywords: "PowerPoint中的墨水，墨水工具，C#墨水，在PowerPoint中绘图，PowerPoint演示文稿，C#，Csharp，Aspose.Slides for .NET"
description: "使用墨水工具在PowerPoint C#中绘制对象"
---

PowerPoint提供了墨水功能，让您可以绘制非标准图形，这些图形可用于突出其他对象，展示连接和过程，并引起对幻灯片中特定项目的注意。

Aspose.Slides提供了[Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/)接口，其中包含您创建和管理墨水对象所需的类型。

## **常规对象与墨水对象的区别**

PowerPoint幻灯片上的对象通常由形状对象表示。形状对象在其最简单的形式上是一个容器，定义了对象本身（其框架）的区域以及其属性。后者包括容器区域大小、容器形状、容器背景等。有关信息，请参阅[Shape Layout Format](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape)。

然而，当PowerPoint处理墨水对象时，它忽略对象框架（容器）的所有属性，除了其大小。容器区域的大小由标准的`width`和`height`值决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨水轨迹**

轨迹是用于记录用户书写数字墨水时笔轨迹的基本元素或标准。轨迹是描述连接点序列的记录。

编码的最简单形式指定每个采样点的X和Y坐标。当渲染所有连接点时，它们会产生如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## 绘图的画笔属性

您可以使用画笔绘制连接轨迹元素点的线条。画笔有自己对应于`Brush.Color`和`Brush.Size`属性的颜色和大小。

### **设置墨水画笔颜色**

以下C#代码向您展示如何设置画笔的颜色：

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

### **设置墨水画笔大小** 

以下C#代码向您展示如何设置画笔的大小：

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

一般而言，画笔的宽度和高度不匹配，因此PowerPoint不显示画笔大小（数据部分是灰色的）。但当画笔的宽度和高度匹配时，PowerPoint会以这种方式显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为了清晰起见，让我们增加墨水对象的高度并回顾重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑画笔的大小——它总是假设线条的厚度为零（见最后一张图片）。

因此，要确定整个墨水对象的可见区域，我们必须考虑轨迹对象的画笔大小。在这里，目标对象（手写文本轨迹对象）已经缩放到容器（框架）大小。当容器（框架）大小变化时，画笔大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint在处理文本时表现出相同的行为：

![ink_powerpoint6](ink_powerpoint6.png)

**进一步阅读**

* 要阅读有关形状的一般信息，请参阅[PowerPoint Shapes](https://docs.aspose.com/slides/net/powerpoint-shapes/)部分。
* 有关有效值的更多信息，请参阅[Shape Effective Properties](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value)。 
