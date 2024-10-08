---
title: 饼图
type: docs
url: /zh/cpp/pie-chart/
---



## **饼图和条形图的第二绘图选项**
Aspose.Slides for C++ 现在支持饼图和条形图的第二绘图选项。在本主题中，我们将通过示例查看如何使用 Aspose.Slides 指定这些选项。为了指定属性，请按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类对象。
1. 在幻灯片上添加图表。
1. 指定图表的第二绘图选项。
1. 将演示文稿写入磁盘。

在下面给出的示例中，我们设置了饼图的不同属性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}



## **设置自动饼图切片颜色**
Aspose.Slides for C++ 提供了一个简单的 API 用于设置自动饼图切片颜色。示例代码应用了上述属性设置。

1. 创建 Presentation 类的实例。
1. 访问第一张幻灯片。
1. 添加默认数据的图表。
1. 设置图表标题。
1. 设置第一系列显示值。
1. 设置图表数据表的索引。
1. 获取图表数据工作表。
1. 删除默认生成的系列和类别。
1. 添加新类别。
1. 添加新系列。

将修改后的演示文稿写入 PPTX 文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}