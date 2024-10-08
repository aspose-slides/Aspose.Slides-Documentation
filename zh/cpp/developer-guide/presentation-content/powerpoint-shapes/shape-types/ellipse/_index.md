---
title: 椭圆
type: docs
weight: 30
url: /cpp/ellipse/
---


## **创建椭圆**
在本主题中，我们将向开发人员介绍如何使用 Aspose.Slides for C++ 向他们的幻灯片添加椭圆形状。Aspose.Slides for C++ 提供了一组更简单的 API，可以用几行代码绘制不同种类的形状。要向演示文稿的选定幻灯片添加一个简单的椭圆，请按照以下步骤操作：

1. 创建一个 [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/) 的实例
1. 通过其索引获取幻灯片的引用
1. 使用 IShapes 对象暴露的 AddAutoShape 方法添加一个椭圆类型的 AutoShape
1. 将修改后的演示文稿写入 PPTX 文件

在下面给出的示例中，我们已向第一张幻灯片添加了一个椭圆。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}


## **创建格式化的椭圆**
要向幻灯片添加更好格式化的椭圆，请按照以下步骤操作：

1. 创建一个 [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/) 的实例。
1. 通过其索引获取幻灯片的引用。
1. 使用 IShapes 对象暴露的 AddAutoShape 方法添加一个椭圆类型的 AutoShape。
1. 将椭圆的填充类型设置为实心。
1. 使用 FillFormat 对象中与 IShape 对象关联的 SolidFillColor.Color 属性设置椭圆的颜色。
1. 设置椭圆边框的颜色。
1. 设置椭圆边框的宽度。
1. 将修改后的演示文稿写入 PPTX 文件。

在下面给出的示例中，我们已向演示文稿的第一张幻灯片添加了一个格式化的椭圆。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}