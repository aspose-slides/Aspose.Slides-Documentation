---
title: 在 C++ 中创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/cpp/create-presentation/
keywords:
- 创建演示文稿
- 新建演示文稿
- 创建 PPT
- 新建 PPT
- 创建 PPTX
- 新建 PPTX
- 创建 ODP
- 新建 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 C++ 中使用 Aspose.Slides 创建演示文稿——生成 PPT、PPTX 和 ODP 文件，受益于 OpenDocument 支持，并以编程方式保存，确保可靠的结果。"
---

## **创建 PowerPoint 演示文稿**
要在演示文稿的选定幻灯片上添加一条简单的直线，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过使用其 Index 获取幻灯片的引用。
3. 使用 Shapes 对象公开的 AddAutoShape 方法添加一种线类型的 AutoShape。
4. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们在演示文稿的第一张幻灯片上添加了一条直线。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **常见问题**

**可以将新演示文稿保存为什么格式？**

您可以保存为 [PPTX、PPT 和 ODP](/slides/zh/cpp/save-presentation/)，并导出为 [PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/cpp/convert-powerpoint-to-xps/)、[HTML](/slides/zh/cpp/convert-powerpoint-to-html/)、[SVG](/slides/zh/cpp/convert-powerpoint-to-png/) 和 [图片](/slides/zh/cpp/convert-powerpoint-to-png/)，等等。

**我可以从模板 (POTX/POTM) 开始并保存为普通 PPTX 吗？**

可以。加载模板后保存为所需格式；POTX/POTM/PPTM 等类似格式 [受支持](/slides/zh/cpp/supported-file-formats/)。

**创建演示文稿时如何控制幻灯片尺寸/宽高比？**

设置 [幻灯片尺寸](/slides/zh/cpp/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

**尺寸和坐标使用什么单位？**

使用点（points）：1 英寸等于 72 单位。

**如何处理包含大量媒体文件的超大演示文稿以降低内存使用？**

使用 [BLOB 管理策略](/slides/zh/cpp/manage-blob/)，通过临时文件限制内存存储，并优先采用基于文件的工作流而非纯内存流。

**可以并行创建/保存演示文稿吗？**

不能从 [多个线程](/slides/zh/cpp/multithreading/) 同时操作同一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 实例。请为每个线程或进程运行独立的实例。

**如何去除试用水印和限制？**

在每个进程中 [应用许可证](/slides/zh/cpp/licensing/)。许可证 XML 必须保持未修改，并在多线程环境下同步许可证设置。

**我可以对创建的 PPTX 进行数字签名吗？**

可以。支持演示文稿的 [数字签名](/slides/zh/cpp/digital-signature-in-powerpoint/)（添加和验证）。

**在创建的演示文稿中是否支持宏 (VBA)？**

支持。您可以 [创建/编辑 VBA 项目](/slides/zh/cpp/presentation-via-vba/) 并保存为支持宏的文件，如 PPTM/PPSM。