---
title: 在 C++ 中格式化演示文稿图表
linktitle: 图表格式化
type: docs
weight: 60
url: /zh/cpp/chart-formatting/
keywords:
- 格式化图表
- 图表格式化
- 图表实体
- 图表属性
- 图表设置
- 图表选项
- 字体属性
- 圆角边框
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 中的图表格式化，并通过专业、抢眼的样式提升您的 PowerPoint 演示文稿。"
---
## **概述**

本文介绍如何使用 Aspose.Slides 在 PowerPoint 演示文稿中格式化图表。它展示了如何自定义关键图表元素，例如坐标轴、网格线、标题、图例、绘图区和墙面填充，以提升图表数据的外观和可读性。

它还演示了如何为图表文本设置字体属性、对图表数据应用预设和自定义数字格式，以及为图表区域启用圆角。这些示例共同展示了如何控制演示文稿中图表的视觉样式和数据呈现。

## **格式化图表实体**
Aspose.Slides for C++ 允许开发者从头为幻灯片添加自定义图表。本文解释了如何格式化不同的图表实体，包括图表类别轴和数值轴。

Aspose.Slides for C++ 提供了一个简单的 API 用于管理不同的图表实体并使用自定义值进行格式化：

1. 创建 **Presentation** 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带默认数据的图表，并指定所需的类型（本例中使用 ChartType.LineWithMarkers）。
1. 访问图表的数值轴并设置以下属性：
   1. 为数值轴主网格线设置 **Line format**。
   1. 为数值轴次网格线设置 **Line format**。
   1. 为数值轴设置 **Number Format**。
   1. 为数值轴设置 **Min, Max, Major and Minor units**。
   1. 为数值轴数据设置 **Text Properties**。
   1. 为数值轴设置 **Title**。
   1. 为数值轴设置 **Line Format**。
1. 访问图表的类别轴并设置以下属性：
   1. 为类别轴主网格线设置 **Line format**。
   1. 为类别轴次网格线设置 **Line format**。
   1. 为类别轴数据设置 **Text Properties**。
   1. 为类别轴设置 **Title**。
   1. 为类别轴设置 **Label Positioning**。
   1. 为类别轴标签设置 **Rotation Angle**。
1. 访问图表图例并为其设置 **Text Properties**。
1. 设置显示图表图例而不与图表重叠。
1. 访问图表的 **Secondary Value Axis** 并设置以下属性：
   1. 启用次要 **Value Axis**。
   1. 为次要数值轴设置 **Line Format**。
   1. 为次要数值轴设置 **Number Format**。
   1. 为次要数值轴设置 **Min, Max, Major and Minor units**。
1. 现在在次要数值轴上绘制第一条图表系列。
1. 将图表背面墙设置为填充颜色。
1. 设置图表绘图区的填充颜色。
1. 将修改后的演示文稿写入 PPTX 文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **为图表设置字体属性**
Aspose.Slides for C++ 支持为图表设置字体相关属性。请按照以下步骤为图表设置字体属性。

- 实例化 Presentation 类对象。
- 在幻灯片上添加图表。
- 设置字体高度。
- 保存修改后的演示文稿。

以下提供示例代码。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **为图表数据表设置字体属性**
Aspose.Slides for C++ 支持更改系列中类别的颜色。

1. 实例化 Presentation 类对象。
1. 在幻灯片上添加图表。
1. 设置图表表格。
1. 设置字体高度。
1. 保存修改后的演示文稿。

以下提供示例代码。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **设置图表区域圆角边框**
Aspose.Slides for C++ 支持设置图表区域。已在 Aspose.Slides 中添加了 **IChart.HasRoundedCorners** 和 **Chart.HasRoundedCorners** 属性。

1. 实例化 Presentation 类对象。
1. 在幻灯片上添加图表。
1. 设置图表的填充类型和填充颜色
1. 将圆角属性设为 True。
1. 保存修改后的演示文稿。

以下提供示例代码。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **设置数值格式**
Aspose.Slides for C++ 提供了一个简单的 API 用于管理图表数据格式：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带默认数据的图表，并指定所需的类型（本例使用 **ChartType.ClusteredColumn**）。
1. 从可能的预设值中设置预设数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置图表数据的数字格式。
1. 保存演示文稿。
1. 设置自定义数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置不同的图表数据数字格式。
1. 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**以下给出了可使用的可能预设数字格式值及其对应的预设索引：**|
| :- | :- |
|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|
|||
| :- | :- |

## **常见问题**

**我可以为柱形/区域设置半透明填充，同时保持边框不透明吗？**

可以。填充透明度和轮廓是分别配置的。这对于在密集的可视化中提高网格和数据的可读性非常有用。

**当数据标签重叠时该如何处理？**

可以减小字体大小，禁用非必要的标签组件（例如类别），设置标签的偏移/位置，必要时仅为选定的点显示标签，或将格式切换为“值 + 图例”。

**我可以对系列应用渐变或图案填充吗？**

可以。通常同时提供纯色和渐变/图案填充。实际使用时建议少用渐变，并避免与网格和文本的对比度降低的组合。