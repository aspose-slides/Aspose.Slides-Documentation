---
title: 在 Java 中管理演示文稿墨水对象
linktitle: 管理墨水
type: docs
weight: 95
url: /zh/java/manage-ink/
keywords:
- 墨水
- 墨水对象
- 墨水轨迹
- 管理墨水
- 绘制墨水
- 绘图
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "管理 PowerPoint 墨水对象——使用 Aspose.Slides for Java 创建、编辑和样式化数字墨水。获取轨迹、画笔颜色和大小的代码示例。"
---

PowerPoint 提供墨水功能，允许您绘制非标准图形，可用于突出其他对象、显示连接和流程，以及在幻灯片上强调特定项目。

Aspose.Slides 提供所有所需的墨水类型（例如 [墨水](https://reference.aspose.com/slides/java/com.aspose.slides/ink/) 类），帮助您创建和管理墨水对象。

## **常规对象与墨水对象的区别**

PowerPoint 幻灯片上的对象通常由形状对象表示。形状对象在最简单的形式下是一个容器，定义对象本身的区域（其框架）以及其属性。后者包括容器区域大小、容器的形状、容器的背景等。有关信息，请参阅 [形状布局格式](https://docs.aspose.com/slides/java/shape-manipulations/#access-layout-formats-for-shape)。

但是，当 PowerPoint 处理墨水对象时，除大小外，它会忽略对象框架（容器）的所有属性。容器区域的大小由标准的 `width` 和 `height` 值决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨迹形状痕迹**

Trace 是一种基本元素或标准，用于记录用户书写数字墨水时笔的轨迹。Trace 是描述连接点序列的记录。

最简单的编码形式指定每个采样点的 X 和 Y 坐标。当所有连接点渲染完毕时，会产生如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## **绘图画笔属性**

您可以使用画笔绘制连接 Trace 元素点的线条。画笔具有自己的颜色和大小，对应于 `Brush.Color` 和 `Brush.Size` 属性。

### **设置墨水画笔颜色**

此 Java 代码演示如何设置画笔的颜色：
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


### **设置墨水画笔大小**

此 Java 代码演示如何设置画笔的大小：
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


通常，画笔的宽度和高度不匹配，PowerPoint 不会显示画笔大小（数据区为灰色）。但当画笔宽度和高度匹配时，PowerPoint 会如下显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为更清晰起见，我们将增加墨水对象的高度并查看重要维度：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑画笔的大小——它始终假定线条的粗细为零（见最后一图）。

因此，要确定整个墨水对象的可见区域，必须考虑 Trace 对象的画笔大小。此处，目标对象（手写文字 Trace 对象）已按容器（框架）大小进行缩放。当容器（框架）大小变化时，画笔大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 在处理文本时也表现出相同的行为：

![ink_powerpoint6](ink_powerpoint6.png)

**进一步阅读**

* 要了解一般形状，请参阅 [PowerPoint 形状](https://docs.aspose.com/slides/java/powerpoint-shapes/) 部分。 
* 有关有效值的更多信息，请参阅 [形状有效属性](https://docs.aspose.com/slides/java/shape-effective-properties/#getting-effective-font-height-value)。