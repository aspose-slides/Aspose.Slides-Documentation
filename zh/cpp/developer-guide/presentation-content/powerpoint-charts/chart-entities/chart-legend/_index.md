---
title: 使用 C++ 在演示文稿中自定义图表图例
linktitle: 图表图例
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
description: "使用 Aspose.Slides for C++ 定制图表图例，以针对 PowerPoint 演示文稿进行专属图例格式优化。"
---
## **概述**

Aspose.Slides 提供在 PowerPoint 演示文稿中自定义图例的选项。本文展示了如何定位和设置图例的大小、为整个图例设置字体大小以及对单个图例项进行格式化。

文中还在 FAQ 中覆盖了若干相关行为，包括使用非覆盖模式让绘图区域为图例留出空间、允许长图例标签自动换行或使用换行符、以及在未设置显式文字和填充时让图例格式继承演示文稿主题。

## **图例定位**
为了设置图例属性，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。
- 获取幻灯片的引用。
- 在幻灯片上添加图表。
- 设置图例的属性。
- 将演示文稿写入为 PPTX 文件。

在下面的示例中，我们为图表图例设置了位置和大小。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **设置图例的字体大小**
Aspose.Slides for C++ 允许开发者设置图例的字体大小。请按以下步骤操作：

- 实例化 Presentation 类。
- 创建默认图表。
- 设置字体大小。
- 设置最小轴值。
- 设置最大轴值。
- 将演示文稿写入磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **设置单个图例项的字体大小**
Aspose.Slides for C++ 允许开发者设置单个图例项的字体大小。请按以下步骤操作：

- 实例化 Presentation 类。
- 创建默认图表。
- 访问图例项。
- 设置字体大小。
- 设置最小轴值。
- 设置最大轴值。
- 将演示文稿写入磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**是否可以启用图例，使图表自动为其分配空间而不是覆盖？**

是。使用非覆盖模式（[set_Overlay(false)](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/legend/set_overlay/)）；此时绘图区域会收缩以容纳图例。

**如何实现多行图例标签？**

可以。长标签在空间不足时会自动换行；通过在系列名称中插入换行符可以强制换行。

**如何让图例遵循演示文稿主题的配色方案？**

不要为图例或其文字设置显式的颜色/填充/字体。这样它们会从主题继承，并在更改设计时正确更新。