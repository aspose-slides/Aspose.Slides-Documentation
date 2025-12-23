---
title: 在 PHP 中管理演示文稿墨迹对象
linktitle: 管理墨迹
type: docs
weight: 95
url: /zh/php-java/manage-ink/
keywords:
- 墨迹
- 墨迹对象
- 墨迹轨迹
- 管理墨迹
- 绘制墨迹
- 绘图
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "管理 PowerPoint 墨迹对象——使用 Aspose.Slides for PHP via Java 创建、编辑和设置数字墨迹的样式。获取轨迹、画笔颜色和大小的代码示例。"
---

PowerPoint 提供了墨迹功能，允许您绘制非标准形状，可用于突出显示其他对象、展示连接和流程，并将注意力吸引到幻灯片上的特定项目。

Aspose.Slides 提供了所有所需的 Ink 类型（例如 [Ink](https://reference.aspose.com/slides/php-java/aspose.slides/ink/) 类），帮助您创建和管理墨迹对象。

## **常规对象与墨迹对象的区别**

PowerPoint 幻灯片上的对象通常由形状对象表示。形状对象在最简形式下是一个容器，定义对象本身的区域（即其框架）以及其属性。后者包括容器区域的大小、容器的形状、容器的背景等。有关信息，请参阅 [形状布局格式](https://docs.aspose.com/slides/php-java/shape-manipulations/#access-layout-formats-for-shape)。

但是，当 PowerPoint 处理墨迹对象时，它会忽略对象框架（容器）的所有属性，只保留其大小。容器区域的大小由标准的 `width` 和 `height` 值决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨迹形状轨迹**

轨迹是用于记录用户书写数字墨迹时笔迹轨迹的基本元素或标准。轨迹是描述一系列连接点的记录。

最简的编码形式指定每个采样点的 X 和 Y 坐标。当所有连接点渲染完成后，会生成如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## **绘图的画笔属性**

您可以使用画笔绘制连接轨迹元素点的线条。画笔具有自己的颜色和大小，对应于 `Brush.Color` 和 `Brush.Size` 属性。

### **设置墨迹画笔颜色**

下面的 PHP 代码演示如何设置画笔的颜色：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **设置墨迹画笔大小**

下面的 PHP 代码演示如何设置画笔的大小：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


通常情况下，画笔的宽度和高度不匹配，PowerPoint 不会显示画笔大小（数据区为灰色）。但当画笔的宽度和高度相匹配时，PowerPoint 会以如下方式显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为便于说明，我们将增加墨迹对象的高度并查看重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑画笔的大小——它始终假设线条粗细为零（见最后的图像）。

因此，要确定整个墨迹对象的可见区域，必须考虑轨迹对象的画笔大小。此处，目标对象（手写文字轨迹对象）已被缩放到容器（框架）大小。当容器（框架）尺寸变化时，画笔大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 在处理文本时也表现出相同的行为：

![ink_powerpoint6](ink_powerpoint6.png)

**进一步阅读**

* 若要了解总体形状信息，请参阅 [PowerPoint 形状](https://docs.aspose.com/slides/php-java/powerpoint-shapes/) 部分。
* 欲获取有关有效值的更多信息，请参阅 [形状有效属性](https://docs.aspose.com/slides/php-java/shape-effective-properties/#getting-effective-font-height-value)。