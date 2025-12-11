---
title: 在 Android 上管理演示文稿墨水对象
linktitle: 管理墨水
type: docs
weight: 95
url: /zh/androidjava/manage-ink/
keywords:
- 墨水
- 墨水对象
- 墨水轨迹
- 管理墨水
- 绘制墨水
- 绘图
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 管理 PowerPoint 墨水对象——创建、编辑和设置数字墨水的样式。获取用于轨迹、笔刷颜色和大小的 Java 代码示例。"
---

PowerPoint 提供了墨水功能，允许您绘制非标准图形，可用于突出其他对象、展示连接和流程，以及吸引幻灯片上特定项目的注意。

Aspose.Slides 提供了创建和管理墨水对象所需的所有 Ink 类型（例如 [Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/) 类）。

## **常规对象与墨水对象的区别**

PowerPoint 幻灯片上的对象通常由形状对象表示。形状对象在最简单的形式下是一个容器，定义了对象本身的区域（其框架）以及其属性。后者包括容器区域大小、容器的形状、容器的背景等。有关信息，请参阅 [Shape Layout Format](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape)。

然而，当 PowerPoint 处理墨水对象时，它会忽略对象框架（容器）的所有属性，除非其大小。容器区域的大小由标准的 `width` 和 `height` 值决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape Traces**

Trace 是用于记录用户书写数字墨水时笔迹轨迹的基本元素或标准。Trace 是描述一系列相连点的记录。

最简单的编码形式指定每个采样点的 X 和 Y 坐标。当所有相连点被渲染时，会生成如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## **绘图的笔刷属性**

您可以使用笔刷绘制连接 trace 元素点的线条。笔刷有其自己的颜色和大小，对应于 `Brush.Color` 和 `Brush.Size` 属性。

### **设置 Ink 笔刷颜色**

以下 Java 代码展示了如何设置笔刷的颜色：
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


### **设置 Ink 笔刷大小**

以下 Java 代码展示了如何设置笔刷的大小：
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


通常，笔刷的宽度和高度不匹配，PowerPoint 不会显示笔刷大小（数据区域呈灰色）。但当笔刷宽度和高度匹配时，PowerPoint 会如此显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为便于说明，我们增加墨水对象的高度并查看重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑笔刷的尺寸——它始终假设线条的粗细为零（见最后一张图）。

因此，要确定整个墨水对象的可见区域，必须考虑 trace 对象的笔刷尺寸。此处，目标对象（手写文本 trace 对象）已按容器（框架）大小进行缩放。当容器（框架）大小改变时，笔刷尺寸保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 在处理文本时表现出相同的行为：

![ink_powerpoint6](ink_powerpoint6.png)

**进一步阅读**

* 要了解一般形状，请参阅 [PowerPoint Shapes](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/) 部分。
* 有关有效值的更多信息，请参阅 [Shape Effective Properties](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value)。