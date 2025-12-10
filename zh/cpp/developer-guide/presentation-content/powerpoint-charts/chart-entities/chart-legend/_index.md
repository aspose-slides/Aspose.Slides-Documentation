---
title: 在演示文稿中使用 C++ 自定义图表图例
linktitle: 图例
type: docs
url: /zh/cpp/chart-legend/
keywords:
- 图表图例
- 图例位置
- 字体大小
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 定制图表图例，以针对 PowerPoint 演示文稿进行优化并实现个性化的图例格式设置。"
---

## **图例定位**
要设置图例属性，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
- 获取幻灯片的引用。
- 在幻灯片上添加图表。
- 设置图例的属性。
- 将演示文稿写入为 PPTX 文件。

在下面的示例中，我们已为图表图例设置了位置和大小。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **设置图例的字体大小**
Aspose.Slides for C++ 允许开发人员设置图例的字体大小。请按照以下步骤操作：

- 实例化 Presentation 类。
- 创建默认图表。
- 设置字体大小。
- 设置最小轴值。
- 设置最大轴值。
- 将演示文稿写入磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **设置单个图例项的字体大小**
Aspose.Slides for C++ 允许开发人员设置单个图例项的字体大小。请按照以下步骤操作：

- 实例化 Presentation 类。
- 创建默认图表。
- 访问图例项。
- 设置字体大小。
- 设置最小轴值。
- 设置最大轴值。
- 将演示文稿写入磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **常见问题**

**我可以启用图例，让图表自动为其分配空间，而不是覆盖吗？**

是的。使用非覆盖模式（[set_Overlay(false)](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/)）；在这种情况下，绘图区域会缩小以容纳图例。

**我可以使用多行图例标签吗？**

可以。当空间不足时，长标签会自动换行；通过在系列名称中插入换行符可以实现强制换行。

**我如何让图例遵循演示文稿主题的配色方案？**

不要为图例或其文本设置显式的颜色/填充/字体。它们将从主题继承，并在设计更改时正确更新。