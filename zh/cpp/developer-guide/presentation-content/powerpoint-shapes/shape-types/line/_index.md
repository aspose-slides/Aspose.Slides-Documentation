---
title: 在 C++ 中向演示文稿添加线形状
linktitle: 线条
type: docs
weight: 50
url: /zh/cpp/line/
keywords:
- 线条
- 创建线条
- 添加线条
- 普通线条
- 配置线条
- 自定义线条
- 虚线样式
- 箭头
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中操作线条格式。发现属性、方法和示例。"
---

## **创建普通线条**
要向演示文稿的选定幻灯片添加一条简单的普通线，请按照以下步骤操作：

- 创建一个[Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)的实例。
- 通过使用其 Index 获取幻灯片的引用。
- 使用 Shapes 对象公开的[AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/)方法添加 Line 类型的 AutoShape。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们在演示文稿的第一张幻灯片上添加了一条线。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}


## **创建箭头形状的线条**
Aspose.Slides for C++ 还允许开发者配置线条的某些属性，使其更具吸引力。让我们尝试配置一些线条属性，使其呈现为箭头。请按以下步骤操作：

- 创建一个[Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)的实例。
- 通过使用其 Index 获取幻灯片的引用。
- 使用 Shapes 对象公开的 AddAutoShape 方法添加 Line 类型的 AutoShape。
- 将 Line Style 设置为 Aspose.Slides for C++ 提供的样式之一。
- 设置线条的宽度。
- 将线条的[Dash Style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/)设置为 Aspose.Slides for C++ 提供的样式之一。
- 设置线条起点的[Arrow Head Style](https://reference.aspose.com/slides/cpp/aspose.slides/lineformat/)及长度。
- 设置线条终点的 Arrow Head Style 和长度。
- 将修改后的演示文稿写入为 PPTX 文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **常见问题**

**我可以将普通线转换为连接线，使其“自动对齐”到形状吗？**

不行。普通线（类型为[Line](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/)的[AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/)）不会自动变为连接线。若要使其对齐到形状，请使用专用的[Connector](https://reference.aspose.com/slides/cpp/aspose.slides/connector/) 类型以及用于连接的[corresponding APIs](/slides/zh/cpp/connector/)。

**如果线条的属性继承自主题，且难以确定最终值，我该怎么办？**

通过[ILineFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformateffectivedata/) 接口[读取有效属性](/slides/zh/cpp/shape-effective-properties/)，这些已经考虑了继承和主题样式。

**我可以锁定线条以防止编辑（移动、调整大小）吗？**

可以。Shapes 提供[lock objects](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/get_autoshapelock/)，可用于[disallow editing operations](/slides/zh/cpp/applying-protection-to-presentation/)。