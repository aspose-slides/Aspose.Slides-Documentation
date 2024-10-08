---
title: 趋势线
type: docs
url: /cpp/trend-line/
---

## **添加趋势线**
Aspose.Slides for C++ 提供了一个简单的 API 用于管理不同的图表趋势线：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表以及任何所需类型（本示例使用 ChartType.ClusteredColumn）。
1. 为图表系列 1 添加指数趋势线。
1. 为图表系列 1 添加线性趋势线。
1. 为图表系列 2 添加对数趋势线。
1. 为图表系列 2 添加移动平均趋势线。
1. 为图表系列 3 添加多项式趋势线。
1. 为图表系列 3 添加幂趋势线。
1. 将修改后的演示文稿写入 PPTX 文件。

以下代码用于创建带有趋势线的图表。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **添加自定义线**
Aspose.Slides for C++ 提供了一个简单的 API 来在图表中添加自定义线。要向演示文稿的选定幻灯片添加一条简单的直线，请按照以下步骤操作：

- 创建一个 Presentation 类的实例
- 通过使用其索引获得幻灯片的引用
- 使用 Shapes 对象暴露的 AddChart 方法创建一个新图表
- 使用 Shapes 对象暴露的 AddAutoShape 方法添加一个类型为线的 AutoShape
- 设置形状线条的颜色。
- 将修改后的演示文稿写入 PPTX 文件

以下代码用于创建带有自定义线的图表。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}