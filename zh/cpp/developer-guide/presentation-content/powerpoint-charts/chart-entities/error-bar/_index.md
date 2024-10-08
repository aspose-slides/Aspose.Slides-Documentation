---
title: 误差线
type: docs
url: /cpp/error-bar/
---

## **添加误差线**
Aspose.Slides for C++ 提供了一个简单的 API 来管理误差线值。示例代码适用于使用自定义值类型的情况。要指定一个值，请使用 **ErrorBarCustomValues** 属性在系列的 **DataPoints** 集合中特定数据点上：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 在所需的幻灯片上添加一个气泡图表。
1. 访问第一个图表系列并设置误差线 X 格式。
1. 访问第一个图表系列并设置误差线 Y 格式。
1. 设置误差线值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}


## **添加自定义误差线**
Aspose.Slides for C++ 提供了一个简单的 API 来管理自定义误差线值。示例代码适用于 **IErrorBarsFormat.ValueType** 属性等于 **Custom** 的情况。要指定一个值，请使用 **ErrorBarCustomValues** 属性在系列的 **DataPoints** 集合中特定数据点上：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 在所需的幻灯片上添加一个气泡图表。
1. 访问第一个图表系列并设置误差线 X 格式。
1. 访问第一个图表系列并设置误差线 Y 格式。
1. 访问图表系列的单个数据点并为单个系列数据点设置误差线值。
1. 设置误差线值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}