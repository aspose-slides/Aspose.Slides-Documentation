---
title: 更新图表
type: docs
weight: 10
url: /zh/cpp/update-chart/
---


## **更新图表**
Aspose.Slides for C++ 提供了最简单的 API 以最简单的方式更新图表。要更新幻灯片中的图表：

- 打开包含图表的 Presentation 类的实例。
- 使用其索引获取幻灯片的引用。
- 遍历所有形状以找到所需的图表。
- 访问图表数据工作表。
- 通过更改系列值修改图表数据系列数据。
- 添加新的系列并在其中填充数据。
- 将修改后的演示文稿写入 PPTX 文件。

以下是更新图表的代码示例。


{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ExistingChart-ExistingChart.cpp" >}}