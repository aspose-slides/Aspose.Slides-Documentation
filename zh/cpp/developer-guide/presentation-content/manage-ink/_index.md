---
title: 在 C++ 中管理演示文稿墨迹对象
linktitle: 管理墨迹
type: docs
weight: 95
url: /zh/cpp/manage-ink/
keywords:
- 墨迹
- 墨迹对象
- 墨迹轨迹
- 管理墨迹
- 绘制墨迹
- 绘图
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "管理 PowerPoint 墨迹对象——使用 Aspose.Slides for C++ 创建、编辑和设置数字墨迹样式。获取轨迹、笔刷颜色和大小的代码示例。"
---

PowerPoint 提供了墨迹功能，允许您绘制非标准图形，可用于突出其他对象、显示连接和流程，以及在幻灯片上引起对特定项的注意。

Aspose.Slides 提供了 [Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/) 接口，包含创建和管理墨迹对象所需的类型。

## **常规对象与墨迹对象的区别**

PowerPoint 幻灯片上的对象通常由形状对象表示。形状对象在最简单的形式下是一个容器，定义对象本身的区域（其框架）以及其属性。后者包括容器区域大小、容器的形状、容器的背景等。有关信息，请参阅 [Shape Layout Format](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape)。

然而，当 PowerPoint 处理墨迹对象时，它会忽略对象框架（容器）的所有属性，只保留其大小。容器区域的大小由标准的 `width` 和 `height` 值决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨迹形状轨迹**

轨迹是记录用户书写数字墨迹时笔尖轨迹的基本元素或标准。轨迹是描述一系列相连点的记录。

最简单的编码形式指定每个采样点的 X 和 Y 坐标。当所有相连点被渲染时，会产生如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## **绘图的笔刷属性**

您可以使用笔刷绘制连接轨迹元素点的线条。笔刷具有自己的颜色和大小，对应 `Brush.Color` 和 `Brush.Size` 属性。

### **设置墨迹笔刷颜色**

此 C++ 代码示例展示如何设置笔刷的颜色：
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```


### **设置墨迹笔刷大小**

此 C++ 代码示例展示如何设置笔刷的大小：
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```


通常情况下，笔刷的宽度和高度不相等，PowerPoint 不会显示笔刷大小（数据区为灰色）。但当笔刷的宽度和高度相等时，PowerPoint 会以如下方式显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为便于说明，我们将墨迹对象的高度增加，并查看重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑笔刷的大小——它始终假定线条的粗细为零（见最后一幅图）。

因此，要确定整个墨迹对象的可见区域，必须考虑轨迹对象的笔刷大小。此处，目标对象（手写文本轨迹对象）已按容器（框架）大小进行缩放。当容器（框架）大小改变时，笔刷大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 在处理文本时表现相同：

![ink_powerpoint6](ink_powerpoint6.png)

**进一步阅读**

* 要了解一般形状，请参阅 [PowerPoint Shapes](https://docs.aspose.com/slides/cpp/powerpoint-shapes/) 部分。 
* 有关有效值的更多信息，请参阅 [Shape Effective Properties](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value)。