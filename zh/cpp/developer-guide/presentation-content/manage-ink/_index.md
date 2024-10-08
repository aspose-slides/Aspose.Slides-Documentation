---
title: 管理墨水
type: docs
weight: 95
url: /zh/cpp/manage-ink/
keywords: "PowerPoint中的墨水, 墨水工具, C++墨水, 在PowerPoint中绘图, PowerPoint演示文稿, C++, CPP, Aspose.Slides for C++"
description: "使用墨水工具在PowerPoint C++中绘制对象"
---

PowerPoint提供了墨水功能，允许您绘制非标准图形，可用于突出显示其他对象、显示连接和过程，并引起对幻灯片中特定项目的注意。

Aspose.Slides提供了[Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/)接口，其中包含您需要创建和管理墨水对象的类型。

## **常规对象与墨水对象的区别**

PowerPoint幻灯片上的对象通常由形状对象表示。形状对象在其最简单的形式上是一个容器，定义了对象本身的区域（其框架）及其属性。后者包括容器区域大小、容器的形状、容器的背景等。有关信息，请参见[形状布局格式](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape)。

然而，当PowerPoint处理墨水对象时，它会忽略对象框架（容器）的所有属性，除了它的大小。容器区域的大小由标准的`width`和`height`值确定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨水轨迹**

轨迹是记录用户书写数字墨水时笔的轨迹的基本元素或标准。轨迹是描述连接点序列的记录。

编码的最简单形式指定了每个采样点的X和Y坐标。当所有连接点被渲染时，它们生成这样的图像：

![ink_powerpoint2](ink_powerpoint2.png)

## 绘图的画刷属性

您可以使用画刷来绘制连接轨迹元素点的线。画刷具有自己的颜色和尺寸，对应于`Brush.Color`和`Brush.Size`属性。

### **设置墨水画刷颜色**

以下C++代码演示如何设置画刷的颜色：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **设置墨水画刷大小**

以下C++代码演示如何设置画刷的大小：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

通常，画刷的宽度和高度不匹配，因此PowerPoint不显示画刷的大小（数据部分为灰色）。但当画刷的宽度和高度匹配时，PowerPoint会以这种方式显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为了更清晰，我们增加墨水对象的高度并查看重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑画刷的大小——它总是认为线条的厚度为零（见最后一张图像）。

因此，为了确定整个墨水对象的可见区域，我们必须考虑轨迹对象的画刷大小。在这里，目标对象（手写文本轨迹对象）已缩放到容器（框架）大小。当容器（框架）大小改变时，画刷大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint在处理文本时表现出相同的行为：

![ink_powerpoint6](ink_powerpoint6.png)

**进一步阅读**

* 要了解形状的一般信息，请参见[PowerPoint形状](https://docs.aspose.com/slides/cpp/powerpoint-shapes/)部分。
* 有关有效值的更多信息，请参见[形状有效属性](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value)。