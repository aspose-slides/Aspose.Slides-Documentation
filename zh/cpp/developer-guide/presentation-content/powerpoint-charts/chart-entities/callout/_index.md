---
title: 使用 C++ 管理演示文稿图表中的标注线
linktitle: 标注线
type: docs
url: /zh/cpp/callout/
keywords:
- 图表标注线
- 使用标注线
- 数据标签
- 标签格式
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用简洁的代码示例在 Aspose.Slides for C++ 中创建和设置标注线，兼容 PPT 和 PPTX，以自动化演示文稿工作流。"
---
## **概述**

本文说明如何在 Aspose.Slides 中使用图表数据标签的标注线。展示了如何使用 `set_ShowLabelAsDataCallout` 方法将标签显示为标注线，如何为环形图配置与标注线相关的标签设置，并指出在将演示文稿导出为 PDF、HTML5、SVG 和光栅图像格式时，标注线及其外观会被保留。

## **使用标注线**
已在 **DataLabelFormat** 类和 **IDataLabelFormat** 接口中添加新属性 **ShowLabelAsDataCallout**，用于确定指定图表的数据标签是显示为数据标注线还是普通数据标签。在下面的示例中，我们已设置标注线。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **为环形图设置标注线**
Aspose.Slides for C++ 提供了为环形图设置系列数据标签标注线形状的支持。下面给出示例。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **常见问题**

**在将演示文稿转换为 PDF、HTML5、SVG 或图像时，标注线会被保留吗？**

是的。标注线是图表渲染的一部分，因此在导出为[PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)、[HTML5](/slides/zh/cpp/export-to-html5/)、[SVG](/slides/zh/cpp/render-a-slide-as-an-svg-image/)或[光栅图像](/slides/zh/cpp/convert-powerpoint-to-png/)时，它们会与幻灯片的格式一起被保留。

**自定义字体在标注线中是否有效，导出后外观会被保留吗？**

是的。Aspose.Slides 支持在演示文稿中[嵌入字体](/slides/zh/cpp/embedded-font/)，并在导出为[PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)等格式时控制字体嵌入，确保标注线在不同系统上保持相同外观。