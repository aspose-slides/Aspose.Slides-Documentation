---
title: 矩形
type: docs
weight: 80
url: /cpp/rectangle/
---


## **创建简单矩形**
与之前的主题一样，这个主题也是关于添加形状的，这次我们讨论的形状是矩形。在这个主题中，我们描述了开发人员如何使用 Aspose.Slides for C++ 将简单或格式化的矩形添加到他们的幻灯片中。要在演示文稿的选定幻灯片中添加简单矩形，请按照以下步骤操作：

1. 创建一个 [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/) 的实例。
1. 使用其索引获取幻灯片的引用。
1. 使用 IShapes 对象提供的 AddAutoShape 方法添加一个矩形类型的 IAutoShape。
1. 将修改后的演示文稿写入 PPTX 文件。

在下面给出的示例中，我们已经在演示文稿的第一张幻灯片上添加了一个简单矩形。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **创建格式化矩形**
要在幻灯片中添加格式化矩形，请按照以下步骤操作：

1. 创建一个 [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/) 的实例。
1. 使用其索引获取幻灯片的引用。
1. 使用 IShapes 对象提供的 AddAutoShape 方法添加一个矩形类型的 IAutoShape。
1. 将矩形的填充类型设置为纯色。
1. 使用与 IShape 对象关联的 FillFormat 对象提供的 SolidFillColor.Color 属性设置矩形的颜色。
1. 设置矩形线条的颜色。
1. 设置矩形线条的宽度。
1. 将修改后的演示文稿写入 PPTX 文件。
   上述步骤在下面给出的示例中得到了实现。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}