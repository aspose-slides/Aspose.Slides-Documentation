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
description: "了解 Aspose.Slides for C++ 中的图表格式化，并通过专业、引人注目的样式提升您的 PowerPoint 演示文稿。"
---

## **格式图表实体**
Aspose.Slides for C++ 让开发人员可以从头开始向幻灯片添加自定义图表。本文介绍了如何格式化不同的图表实体，包括图表类目轴和数值轴。

Aspose.Slides for C++ 提供了一个简易的 API，用于管理各种图表实体并使用自定义值进行格式化：

1. 创建 **Presentation** 类的实例。  
1. 按索引获取幻灯片的引用。  
1. 添加带有默认数据的图表，并指定所需的类型（本例使用 ChartType.LineWithMarkers）。  
1. 访问图表的数值轴并设置以下属性：  
   1. 为数值轴主网格线设置 **Line format**  
   1. 为数值轴次网格线设置 **Line format**  
   1. 为数值轴设置 **Number Format**  
   1. 为数值轴设置 **Min, Max, Major and Minor units**  
   1. 为数值轴数据设置 **Text Properties**  
   1. 为数值轴设置 **Title**  
   1. 为数值轴设置 **Line Format**  
1. 访问图表的类目轴并设置以下属性：  
   1. 为类目轴主网格线设置 **Line format**  
   1. 为类目轴次网格线设置 **Line format**  
   1. 为类目轴数据设置 **Text Properties**  
   1. 为类目轴设置 **Title**  
   1. 为类目轴设置 **Label Positioning**  
   1. 为类目轴标签设置 **Rotation Angle**  
1. 访问图表图例并为其设置 **Text Properties**  
1. 设置显示图例且不与图表重叠  
1. 访问图表的 **Secondary Value Axis** 并设置以下属性：  
   1. 启用次要 **Value Axis**  
   1. 为次要数值轴设置 **Line Format**  
   1. 为次要数值轴设置 **Number Format**  
   1. 为次要数值轴设置 **Min, Max, Major and Minor units**  
1. 将第一条图表系列绘制在次要数值轴上  
1. 将图表背墙填充颜色  
1. 为图表绘图区域填充颜色  
1. 将修改后的演示文稿写入 PPTX 文件  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **为图表设置字体属性**
Aspose.Slides for C++ 支持为图表设置与字体相关的属性。请按以下步骤为图表设置字体属性。

- 实例化 **Presentation** 类对象。  
- 在幻灯片上添加图表。  
- 设置字体高度。  
- 保存修改后的演示文稿。  

下面给出示例代码。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **为图表数据表设置字体属性**
Aspose.Slides for C++ 支持更改系列中类别的颜色。

1. 实例化 **Presentation** 类对象。  
1. 在幻灯片上添加图表。  
1. 设置图表表格。  
1. 设置字体高度。  
1. 保存修改后的演示文稿。  

下面给出示例代码。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **为图表区域设置圆角边框**
Aspose.Slides for C++ 提供了对图表区域进行设置的支持。已在 Aspose.Slides 中添加 **IChart.HasRoundedCorners** 和 **Chart.HasRoundedCorners** 属性。

1. 实例化 **Presentation** 类对象。  
1. 在幻灯片上添加图表。  
1. 设置图表的填充类型和填充颜色。  
1. 将圆角属性设为 True。  
1. 保存修改后的演示文稿。  

下面给出示例代码。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **设置数字格式**
Aspose.Slides for C++ 提供了一个简易的 API，用于管理图表数据格式：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片的引用。  
1. 添加带有默认数据的图表，并指定所需的类型（本例使用 **ChartType.ClusteredColumn**）。  
1. 从可能的预设值中设置预设数字格式。  
1. 遍历每个系列的图表数据单元格并设置图表数据数字格式。  
1. 保存演示文稿。  
1. 设置自定义数字格式。  
1. 遍历每个系列的图表数据单元格并设置不同的图表数据数字格式。  
1. 保存演示文稿。  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**以下给出可使用的预设数字格式值及其对应的索引**|
| :- | :- |
|**0**|常规|
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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0/)|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |

## **常见问题**

**我可以为柱形/区域设置半透明填充，同时保持边框不透明吗？**

可以。填充透明度和轮廓是分开配置的，这有助于在密集的可视化中提升网格和数据的可读性。

**当数据标签重叠时该怎么办？**

可以减小字体大小，禁用非必要的标签组件（例如类别），调整标签的偏移/位置，必要时仅为选定点显示标签，或改用 “值 + 图例” 的格式。

**我可以为系列应用渐变或图案填充吗？**

可以。通常同时提供纯色和渐变/图案填充。实际使用时请适度使用渐变，并避免与网格和文字的对比度降低的组合。