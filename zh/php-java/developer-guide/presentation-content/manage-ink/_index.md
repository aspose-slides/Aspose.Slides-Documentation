---
title: 管理墨水
type: docs
weight: 95
url: /zh/php-java/manage-ink/
keywords: "PowerPoint中的墨水, 墨水工具, Java墨水, 在PowerPoint中绘图, PowerPoint演示文稿, Java, 通过Java的Aspose.Slides for PHP"
description: "使用墨水工具在PowerPoint Java中绘制对象"
---

PowerPoint提供墨水功能，允许您绘制非标准图形，可用于突出显示其他对象、展示连接和过程，并吸引观众对幻灯片中特定项目的注意。

Aspose.Slides提供您所需的所有墨水类型（例如，[墨水](https://reference.aspose.com/slides/php-java/aspose.slides/ink/)类）来创建和管理墨水对象。

## **常规对象与墨水对象的区别**

PowerPoint幻灯片上的对象通常由形状对象表示。形状对象在其最简单的形式中，包含定义对象本身区域（其框架）及其属性的容器。后者包括容器区域的大小、容器的形状、容器的背景等。有关信息，请参见[形状布局格式](https://docs.aspose.com/slides/php-java/shape-manipulations/#access-layout-formats-for-shape)。

然而，当PowerPoint处理墨水对象时，它会忽略对象框架（容器）的所有属性，除了其大小。容器区域的大小由标准的`width`和`height`值决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨水形状轨迹**

轨迹是记录用户撰写数字墨水时笔的轨迹的基本元素或标准。轨迹是描述连接点序列的记录。

最简单的编码形式指定每个采样点的X和Y坐标。当所有连接的点被渲染时，它们生成这样的图像：

![ink_powerpoint2](ink_powerpoint2.png)

## 绘图的画笔属性

您可以使用画笔绘制连接轨迹元素的线条。画笔有自己的颜色和大小，分别对应于`Brush.Color`和`Brush.Size`属性。

### **设置墨水画笔颜色**

以下PHP代码演示如何设置画笔的颜色：

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

### **设置墨水画笔大小** 

以下PHP代码演示如何设置画笔的大小：

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

通常，画笔的宽度和高度不匹配，因此PowerPoint不显示画笔大小（数据部分为灰色）。但当画笔的宽度和高度匹配时，PowerPoint以这种方式显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为了更清楚，让我们增加墨水对象的高度并审查重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑画笔的大小——它始终假设线条的厚度为零（见最后一张图像）。

因此，要确定整个墨水对象的可见区域，我们必须考虑轨迹对象的画笔大小。在这里，目标对象（手写文本轨迹对象）已经缩放到容器（框架）大小。当容器（框架）的大小改变时，画笔大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint在处理文本时表现出相同的行为：

![ink_powerpoint6](ink_powerpoint6.png)

**进一步阅读**

* 要了解一般形状，请参见[PowerPoint形状](https://docs.aspose.com/slides/php-java/powerpoint-shapes/)部分。
* 有关有效值的更多信息，请参见[形状有效属性](https://docs.aspose.com/slides/php-java/shape-effective-properties/#getting-effective-font-height-value)。