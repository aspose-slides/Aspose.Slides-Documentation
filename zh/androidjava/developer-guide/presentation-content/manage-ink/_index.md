---
title: 在 Android 上管理演示文稿墨迹对象
linktitle: 管理墨迹
type: docs
weight: 95
url: /zh/androidjava/manage-ink/
keywords:
- 墨迹
- 墨迹对象
- 墨迹痕迹
- 管理墨迹
- 绘制墨迹
- 绘图
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "管理 PowerPoint 墨迹对象——使用 Aspose.Slides for Android 创建、编辑和设置数字墨迹的样式。获取用于痕迹、刷子颜色和大小的 Java 代码示例。"
---

PowerPoint 提供了墨迹功能，允许您绘制非标准图形，可用于突出其他对象、显示连接和流程、并将注意力集中在幻灯片的特定项目上。

Aspose.Slides 提供了创建和管理墨迹对象所需的全部 Ink 类型（例如 [Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/) 类）。

## **常规对象与墨迹对象的区别**

PowerPoint 幻灯片上的对象通常由形状对象表示。形状对象在最简单的形式下是一个容器，定义对象本身的区域（即其框架）以及其属性。后者包括容器区域的大小、容器的形状、容器的背景等。有关信息，请参阅 [Shape Layout Format](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape)。

然而，当 PowerPoint 处理墨迹对象时，它会忽略对象框架（容器）的所有属性，除大小外。容器区域的大小由标准的 `width` 和 `height` 值决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨迹形状痕迹**

痕迹是一种基本元素或标准，用于记录用户在编写数字墨迹时笔的轨迹。痕迹是描述一系列连接点的记录。

最简单的编码形式指定每个采样点的 X 和 Y 坐标。当所有连接点被渲染时，它们会产生如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## **绘图刷属性**

您可以使用刷子绘制连接痕迹元素点的线条。刷子具有自己的颜色和大小，对应于 `Brush.Color` 和 `Brush.Size` 属性。

### **设置墨迹刷颜色**

以下 Java 代码演示如何设置刷子的颜色：
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


### **设置墨迹刷大小**

以下 Java 代码演示如何设置刷子的大小：
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


通常，刷子的宽度和高度不匹配，因此 PowerPoint 不会显示刷子大小（数据部分呈灰色）。但当刷子的宽度和高度匹配时，PowerPoint 会以如下方式显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为清晰起见，我们将增加墨迹对象的高度并查看重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑刷子的大小——它始终假设线的粗细为零（见最后的图像）。

因此，要确定整个墨迹对象的可见区域，需要考虑痕迹对象的刷子大小。这里，目标对象（手写文本痕迹对象）已按容器（框架）大小进行缩放。当容器（框架）大小改变时，刷子大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 处理文本时表现出相同的行为：

![ink_powerpoint6](ink_powerpoint6.png)

**进一步阅读**

* 若要了解一般形状，请参阅 [PowerPoint Shapes](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/) 部分。
* 欲了解更多有效值信息，请参阅 [Shape Effective Properties](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value)。