---
title: 在 C++ 中向演示文稿添加椭圆
linktitle: 椭圆
type: docs
weight: 30
url: /zh/cpp/ellipse/
keywords:
- 椭圆
- 形状
- 添加椭圆
- 创建椭圆
- 绘制椭圆
- 格式化椭圆
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中创建、格式化和操作 PPT 及 PPTX 演示文稿中的椭圆形状——包含 C++ 代码示例。"
---

## **创建椭圆**
在本主题中，我们将向开发者介绍如何使用 Aspose.Slides for C++ 在幻灯片中添加椭圆形状。Aspose.Slides for C++ 提供了一套更简便的 API，只需几行代码即可绘制各种形状。要在演示文稿的选定幻灯片上添加一个简单的椭圆，请按照以下步骤操作：

1. 创建一个[Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)的实例
1. 通过使用其 Index 获取幻灯片的引用
1. 使用 IShapes 对象提供的 AddAutoShape 方法添加 Ellipse 类型的 AutoShape
1. 将修改后的演示文稿写入为 PPTX 文件

在下面的示例中，我们在第一张幻灯片上添加了一个椭圆。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **创建格式化椭圆**
要在幻灯片上添加格式更好的椭圆，请按照以下步骤操作：

1. 创建一个[Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)的实例。
1. 通过使用其 Index 获取幻灯片的引用。
1. 使用 IShapes 对象提供的 AddAutoShape 方法添加 Ellipse 类型的 AutoShape。
1. 将椭圆的填充类型设置为 Solid。
1. 使用与 IShape 对象关联的 FillFormat 对象提供的 SolidFillColor.Color 属性设置椭圆的颜色。
1. 设置椭圆线条的颜色。
1. 设置椭圆线条的宽度。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们在演示文稿的第一张幻灯片上添加了一个格式化的椭圆。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **常见问题**

**如何相对于幻灯片单位设置椭圆的精确位置和大小？**

坐标和尺寸通常以 **点** 为单位指定。为获得可预测的结果，请基于幻灯片大小进行计算，并在赋值前将所需的毫米或英寸转换为点。

**如何将椭圆置于其他对象之上或之下（控制堆叠顺序）？**

通过将对象置于前面或发送到后台来调整绘制顺序。这样可使椭圆覆盖其他对象或显示其下方的对象。

**如何为椭圆添加出现或强调动画？**

[应用](/slides/zh/cpp/shape-animation/) 入口、强调或退出效果于形状，并配置触发器和时间，以编排动画的播放时机和方式。