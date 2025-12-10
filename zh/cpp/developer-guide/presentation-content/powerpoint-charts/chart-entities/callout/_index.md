---
title: 在演示文稿图表中使用 С++ 管理标注
linktitle: 标注
type: docs
url: /zh/cpp/callout/
keywords:
- 图表标注
- 使用标注
- 数据标签
- 标签格式
- PowerPoint
- 演示文稿
- С++
- Aspose.Slides
description: "使用 Aspose.Slides for С++ 创建和设置标注，提供简洁的代码示例，兼容 PPT 和 PPTX，帮助自动化演示工作流。"
---

## **使用标注(Callouts)**
已向 **DataLabelFormat** 类和 **IDataLabelFormat** 接口添加了新属性 **ShowLabelAsDataCallout**，用于确定指定图表的数据标签是显示为数据标注还是显示为普通数据标签。在下面的示例中，我们已设置标注。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **为环形图设置标注**
Aspose.Slides for C++ 提供了为环形图设置系列数据标签标注形状的支持。下面给出示例代码。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **常见问题**

**将演示文稿转换为 PDF、HTML5、SVG 或图像时，标注是否会被保留？**

是的。标注是图表渲染的一部分，因此在导出为[PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)、[HTML5](/slides/zh/cpp/export-to-html5/)、[SVG](/slides/zh/cpp/render-a-slide-as-an-svg-image/)或[光栅图像](/slides/zh/cpp/convert-powerpoint-to-png/)时，它们会随幻灯片的格式一起被保留。

**自定义字体在标注中是否有效，导出时其外观能否保持？**

是的。Aspose.Slides 支持将[嵌入字体](/slides/zh/cpp/embedded-font/)嵌入到演示文稿中，并在导出为[PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)等格式时控制字体嵌入，确保标注在不同系统上保持一致的外观。