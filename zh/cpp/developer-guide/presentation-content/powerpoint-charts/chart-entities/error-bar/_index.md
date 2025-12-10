---
title: 使用 C++ 在演示文稿图表中自定义误差线
linktitle: 误差线
type: docs
url: /zh/cpp/error-bar/
keywords:
- 误差线
- 自定义值
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在图表中添加和自定义误差线——优化 PowerPoint 演示文稿中的数据可视化。"
---

## **添加误差线**
Aspose.Slides for C++ 提供了用于管理误差线值的简单 API。示例代码适用于使用自定义值类型的情况。要指定值，请使用系列 **DataPoints** 集合中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 在所需的幻灯片上添加气泡图表。
1. 访问第一个图表系列并设置误差线 X 方向格式。
1. 访问第一个图表系列并设置误差线 Y 方向格式。
1. 设置误差线的值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}


## **添加自定义误差线**
Aspose.Slides for C++ 提供了用于管理自定义误差线值的简单 API。当 **IErrorBarsFormat.ValueType** 属性等于 **Custom** 时，示例代码适用。要指定值，请使用系列 **DataPoints** 集合中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 在所需的幻灯片上添加气泡图表。
1. 访问第一个图表系列并设置误差线 X 方向格式。
1. 访问第一个图表系列并设置误差线 Y 方向格式。
1. 访问图表系列的单个数据点并为该数据点设置误差线值。
1. 设置误差线的值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**将演示文稿导出为 PDF 或图像时误差线会怎样？**

误差线作为图表的一部分渲染，并在转换过程中与图表的其他格式一起保留，前提是使用兼容的版本或渲染器。

**误差线可以与标记和数据标签组合使用吗？**

可以。误差线是独立的元素，能够与标记和数据标签兼容；如果元素重叠，可能需要调整格式。

**在哪里可以找到 API 中用于处理误差线的属性和枚举列表？**

在 API 参考中：[ErrorBarsFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbarsformat/) 类以及相关枚举 [ErrorBarType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbartype/) 和 [ErrorBarValueType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbarvaluetype/)。