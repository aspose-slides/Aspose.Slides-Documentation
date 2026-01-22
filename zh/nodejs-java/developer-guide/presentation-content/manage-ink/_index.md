---
title: 管理 JavaScript 中的演示文稿墨水对象
linktitle: 管理墨水
type: docs
weight: 95
url: /zh/nodejs-java/manage-ink/
keywords:
- 墨水
- 墨水对象
- 墨水轨迹
- 管理墨水
- 绘制墨水
- 绘图
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 管理 PowerPoint 墨水对象——创建、编辑和样式化数字墨水。获取 JavaScript 代码示例，包括轨迹、笔刷颜色和大小。"
---

PowerPoint 提供了墨水功能，使您能够绘制非标准图形，可用于突出显示其他对象、展示连接和流程，并将注意力吸引到幻灯片上的特定项目。

Aspose.Slides 提供了所有所需的墨水类型（例如 [Ink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ink/) 类），帮助您创建和管理墨水对象。

## **常规对象与墨水对象的区别**

PowerPoint 幻灯片上的对象通常由形状对象表示。形状对象在最简单的形式下是一个容器，定义了对象本身的区域（即框架）以及其属性。后者包括容器区域的大小、容器的形状、容器的背景等。有关信息，请参阅 [Shape Layout Format](https://docs.aspose.com/slides/nodejs-java/shape-manipulations/#access-layout-formats-for-shape)。

然而，当 PowerPoint 处理墨水对象时，它会忽略对象框架（容器）的所有属性，只保留其大小。容器区域的大小由标准的 `width` 和 `height` 值决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape 轨迹**

轨迹是记录用户使用数字墨水书写时笔尖轨迹的基本元素或标准。轨迹是描述一系列连接点的记录。

最简单的编码形式指定每个采样点的 X 和 Y 坐标。当所有连接点被渲染时，会生成如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## 绘制用的笔刷属性

您可以使用笔刷绘制连接轨迹点的线。笔刷具有自己的颜色和大小，对应 `Brush.setColor` 和 `Brush.setSize` 方法。

### **设置墨水笔刷颜色**

以下 JavaScript 代码演示如何设置笔刷颜色：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **设置墨水笔刷大小**

以下 JavaScript 代码演示如何设置笔刷大小：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


通常，笔刷的宽度和高度不匹配，PowerPoint 不会显示笔刷大小（数据部分呈灰色）。但当笔刷的宽度和高度匹配时，PowerPoint 会如此显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为更清晰起见，我们将增加墨水对象的高度并查看重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑笔刷的大小——它始终假设线条的粗细为零（见最后一图）。

因此，要确定整个墨水对象的可见区域，必须考虑轨迹对象的笔刷大小。此处，目标对象（手写文字轨迹对象）已按容器（框架）大小进行缩放。当容器（框架）大小改变时，笔刷大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 在处理文本时表现相同：

![ink_powerpoint6](ink_powerpoint6.png)

**进一步阅读**

* 要了解形状的通用信息，请参阅 [PowerPoint Shapes](https://docs.aspose.com/slides/nodejs-java/powerpoint-shapes/) 部分。
* 有关有效值的更多信息，请参阅 [Shape Effective Properties](https://docs.aspose.com/slides/nodejs-java/shape-effective-properties/#getting-effective-font-height-value)。