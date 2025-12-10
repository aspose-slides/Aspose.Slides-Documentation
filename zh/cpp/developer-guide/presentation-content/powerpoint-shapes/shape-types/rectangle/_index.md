---
title: 在 C++ 中向演示文稿添加矩形
linktitle: 矩形
type: docs
weight: 80
url: /zh/cpp/rectangle/
keywords:
- 添加矩形
- 创建矩形
- 矩形形状
- 简单矩形
- 格式化矩形
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 添加矩形，提升您的 PowerPoint 演示文稿——轻松以编程方式设计和修改形状。"
---

## **创建简单矩形**
像之前的主题一样，这个主题也关于添加形状，这次我们将讨论的形状是矩形。在本主题中，我们描述了开发人员如何使用 Aspose.Slides for C++ 向幻灯片添加简单或格式化的矩形。要向演示文稿中选定的幻灯片添加一个简单矩形，请按照以下步骤操作：

1. 创建一个 [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 的实例。
1. 使用其 Index 获取幻灯片的引用。
1. 使用 IShapes 对象公开的 AddAutoShape 方法添加类型为 Rectangle 的 IAutoShape。
1. 将修改后的演示文稿写入为 PPTX 文件。

下面的示例中，我们向演示文稿的第一张幻灯片添加了一个简单矩形。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **创建格式化矩形**
要向幻灯片添加格式化矩形，请按照以下步骤操作：

1. 创建一个 [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 的实例。
1. 使用其 Index 获取幻灯片的引用。
1. 使用 IShapes 对象公开的 AddAutoShape 方法添加类型为 Rectangle 的 IAutoShape。
1. 将矩形的填充类型设置为 Solid。
1. 使用与 IShape 对象关联的 FillFormat 对象公开的 SolidFillColor.Color 属性设置矩形的颜色。
1. 设置矩形线条的颜色。
1. 设置矩形线条的宽度。
1. 将修改后的演示文稿写入为 PPTX 文件。
上述步骤已在下面的示例中实现。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **常见问题**

**如何添加圆角矩形？**  
使用圆角 [shape type](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/) 并在形状属性中调整角半径；也可以通过几何调整对每个角单独进行圆角处理。

**如何使用图像（纹理）填充矩形？**  
选择图片 [fill type](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)，提供图像来源，并配置 [stretching/tiling modes](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/)。

**矩形可以有阴影和发光效果吗？**  
可以。可使用 [Outer/inner shadow, glow, and soft edges](/slides/zh/cpp/shape-effect/) 并通过可调参数进行设置。

**我可以将矩形转换为带超链接的按钮吗？**  
可以。请 [Assign a hyperlink](/slides/zh/cpp/manage-hyperlinks/) 到形状的点击（跳转到幻灯片、文件、网页地址或电子邮件）。

**如何保护矩形不被移动或修改？**  
[Use shape locks](/slides/zh/cpp/applying-protection-to-presentation/)：您可以禁止移动、调整大小、选择或文本编辑，以保持布局。

**我可以将矩形转换为光栅图像或 SVG 吗？**  
可以。您可以 [render the shape](http://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) 为指定尺寸/比例的图像，或 [export it as SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) 用于矢量使用。

**如何快速获取考虑主题和继承的矩形实际（有效）属性？**  
[Use the shape’s effective properties](/slides/zh/cpp/shape-effective-properties/)：API 返回考虑主题样式、布局和本地设置的计算值，简化格式分析。