---
title: 管理墨水
type: docs
weight: 95
url: /java/manage-ink/
keywords: "PowerPoint中的墨水, 墨水工具, Java墨水, 在PowerPoint中绘制, PowerPoint演示文稿, Java, Aspose.Slides for Java"
description: "使用墨水工具在PowerPoint Java中绘制对象"
---

PowerPoint提供墨水功能，让您可以绘制非标准图形，这可以用来突出其他对象，显示连接和过程，并引起观众对幻灯片中特定项目的关注。

Aspose.Slides提供您创建和管理墨水对象所需的所有墨水类型（例如，[Ink](https://reference.aspose.com/slides/java/com.aspose.slides/ink/)类）。

## **常规对象与墨水对象之间的区别**

PowerPoint幻灯片上的对象通常由形状对象表示。形状对象在最简单的形式中是一个容器，它定义了对象自身的区域（框架）及其属性。后者包括容器区域大小、容器的形状、容器的背景等。有关信息，请参见[形状布局格式](https://docs.aspose.com/slides/java/shape-manipulations/#access-layout-formats-for-shape)。

但是，当PowerPoint处理墨水对象时，它忽略对象框架（容器）的所有属性，除了其大小。容器区域的大小由标准的`width`和`height`值确定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨水轨迹**

轨迹是记录用户书写数字墨水时笔迹的基本元素或标准。轨迹是描述连接点序列的记录。

编码的最简单形式指定了每个采样点的X和Y坐标。当所有连接的点被渲染时，它们会产生这样的图像：

![ink_powerpoint2](ink_powerpoint2.png)

## 绘制的笔刷属性

您可以使用笔刷绘制连接轨迹元素点的线。笔刷具有其自己的颜色和大小，分别对应于`Brush.Color`和`Brush.Size`属性。

### **设置墨水笔刷颜色**

以下Java代码向您展示如何设置笔刷的颜色：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **设置墨水笔刷大小** 

以下Java代码向您展示如何设置笔刷的大小：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

一般而言，笔刷的宽度和高度不匹配，因此PowerPoint不会显示笔刷大小（数据部分呈灰色）。但是当笔刷宽度和高度匹配时，PowerPoint会以这种方式显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为了清楚起见，让我们增加墨水对象的高度并查看重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑笔刷的大小——它总是假设线的厚度为零（见最后一张图片）。

因此，为了确定整个墨水对象的可见区域，我们必须考虑轨迹对象的笔刷大小。在这里，目标对象（手写文本轨迹对象）已缩放到容器（框架）大小。当容器（框架）的大小变化时，笔刷大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint在处理文本时表现出相同的行为：

![ink_powerpoint6](ink_powerpoint6.png)

**进一步阅读**

* 要了解形状的一般信息，请参见[PowerPoint形状](https://docs.aspose.com/slides/java/powerpoint-shapes/)部分。
* 有关有效值的更多信息，请参见[形状有效属性](https://docs.aspose.com/slides/java/shape-effective-properties/#getting-effective-font-height-value)。