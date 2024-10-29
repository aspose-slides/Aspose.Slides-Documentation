---
title: 图表格式化
type: docs
weight: 60
url: /zh/cpp/chart-formatting/
---



## **格式化图表实体**
Aspose.Slides for C++ 允许开发者从头开始向幻灯片添加自定义图表。本文解释了如何格式化不同的图表实体，包括图表类别和数值轴。

Aspose.Slides for C++ 提供了一个简单的 API，用于管理不同的图表实体并使用自定义值进行格式化：

1. 创建一个 **Presentation** 类的实例。
1. 根据索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表，并选择所需的任何类型（在此示例中我们将使用 ChartType.LineWithMarkers）。
1. 访问图表的值轴并设置以下属性：
   1. 为值轴主网格线设置 **线格式**
   1. 为值轴次网格线设置 **线格式**
   1. 为值轴设置 **数字格式**
   1. 为值轴设置 **最小、最大、主要和次要单位**
   1. 为值轴数据设置 **文本属性**
   1. 为值轴设置 **标题**
   1. 为值轴设置 **线格式**
1. 访问图表的类别轴并设置以下属性：
   1. 为类别轴主网格线设置 **线格式**
   1. 为类别轴次网格线设置 **线格式**
   1. 为类别轴数据设置 **文本属性**
   1. 为类别轴设置 **标题**
   1. 为类别轴设置 **标签位置**
   1. 为类别轴标签设置 **旋转角度**
1. 访问图表图例并为其设置 **文本属性**
1. 设置图表图例不重叠
1. 访问图表的 **次要值轴** 并设置以下属性：
   1. 启用次要 **值轴**
   1. 为次要值轴设置 **线格式**
   1. 为次要值轴设置 **数字格式**
   1. 为次要值轴设置 **最小、最大、主要和次要单位**
1. 现在在次要值轴上绘制第一个图表系列
1. 设置图表背景墙的填充颜色
1. 设置图表绘图区域的填充颜色
1. 将修改后的演示文稿写入 PPTX 文件

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **设置图表的字体属性**
Aspose.Slides for C++ 支持为图表设置字体相关属性。请按照以下步骤设置图表的字体属性。

- 实例化 Presentation 类对象。
- 在幻灯片上添加图表。
- 设置字体高度。
- 保存修改后的演示文稿。

以下示例给出。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **设置图表数据表的字体属性**
Aspose.Slides for C++ 支持更改系列颜色中的类别。

1. 实例化 Presentation 类对象。
1. 在幻灯片上添加图表。
1. 设置图表表格。
1. 设置字体高度。
1. 保存修改后的演示文稿。

以下示例给出。 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **设置图表区域的圆角边框**
Aspose.Slides for C++ 支持设置图表区域。 **IChart.HasRoundedCorners** 和 **Chart.HasRoundedCorners** 属性已在 Aspose.Slides 中添加。

1. 实例化 Presentation 类对象。
1. 在幻灯片上添加图表。
1. 设置图表的填充类型和填充颜色
1. 设置圆角属性为 True。
1. 保存修改后的演示文稿。 

以下示例给出。 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **设置图表数据数字**
Aspose.Slides for C++ 提供了一个简单的 API 用于管理图表数据格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 根据索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表，并选择所需的任何类型（此示例使用 **ChartType.ClusteredColumn**）。
1. 从可能的预设值中设置预设数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置图表数据数字格式。
1. 保存演示文稿。
1. 设置自定义数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置不同的图表数据数字格式。
1. 保存演示文稿。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**可用的预设数字格式值及其预设索引如下：**|
| :- | :- |

|**0**|常规|
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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0/)|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |