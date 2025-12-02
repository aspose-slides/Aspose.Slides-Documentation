---
title: 在 Python 中创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/python-net/create-presentation/
keywords:
- 创建演示文稿
- 新建演示文稿
- 创建 PPT
- 新 PPT
- 创建 PPTX
- 新 PPTX
- 创建 ODP
- 新 ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中创建 PowerPoint 演示文稿——生成 PPT、PPTX 和 ODP 文件，受益于 OpenDocument 支持，并以编程方式保存以获得可靠的结果。"
---

## **概述**

Aspose.Slides for Python 让您可以完全通过代码构建全新的演示文稿文件。本文展示了核心工作流——创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象，获取第一张幻灯片，注入一个简单形状，并保存结果——从而让您看到在没有 Microsoft Office 的情况下生成演示文稿所需的最少设置。由于相同的 API 能写入 PPT、PPTX 和 ODP 文件，您可以从单一代码库同时针对传统 PowerPoint 和 OpenDocument 格式。Aspose.Slides 适用于桌面、Web 或服务器环境，为您的 Python 应用程序提供一个高效的起点，以便在初始幻灯片集合就绪后添加更丰富的内容，如文本、图像或图表。

## **创建演示文稿**

在 Aspose.Slides for Python 中从头创建 PowerPoint 文件就像实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类一样直接。构造函数会自动提供一个只有一张幻灯片的空白文稿，为形状、文本、图表或应用程序需要的任何其他内容提供即时画布。修改该幻灯片或添加新幻灯片后，您可以将结果持久化为 PPTX、旧版 PPT，甚至 OpenDocument 格式。下面的简短代码示例通过在第一张幻灯片上添加一个简单形状来演示此工作流。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片的引用。  
1. 使用 `shapes` 集合暴露的 `add_auto_shape` 方法，添加 `CLOUD` 类型的 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象。  
1. 向自动形状添加文本。  
1. 将修改后的演示文稿保存为 PPTX 文件。

在下面的示例中，向演示文稿的第一张幻灯片添加了云形状。
```py
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:
    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加类型为 CLOUD 的自动形状。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![新的演示文稿](new_presentation.png)

## **常见问题**

**可以将新演示文稿保存为何种格式？**

您可以保存为 [PPTX, PPT, and ODP](/slides/zh/python-net/save-presentation/)，并导出为 [PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/zh/python-net/convert-powerpoint-to-html/)、[SVG](/slides/zh/python-net/convert-powerpoint-to-png/) 以及 [images](/slides/zh/python-net/convert-powerpoint-to-png/)，等等。

**可以从模板（POTX/POTM）开始并保存为普通 PPTX 吗？**

可以。加载模板后保存为所需格式；POTX/POTM/PPTM 等类似格式 [受支持](/slides/zh/python-net/supported-file-formats/)。

**创建演示文稿时如何控制幻灯片大小/宽高比？**

设置 [slide size](/slides/zh/python-net/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

**尺寸和坐标使用什么单位？**

使用点：1 英寸等于 72 单位。

**如何处理包含大量媒体文件的大型演示文稿以降低内存使用？**

使用 [BLOB management strategies](/slides/zh/python-net/manage-blob/)，通过临时文件限制内存存储，并倾向于基于文件的工作流而非纯内存流。

**可以并行创建/保存演示文稿吗？**

不能对同一 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例进行 [multiple threads](/slides/zh/python-net/multithreading/) 操作。请在每个线程或进程中运行独立的实例。

**如何去除试用水印和限制？**

在每个进程中 [Apply a license](/slides/zh/python-net/licensing/)。许可证 XML 必须保持未修改，并且在涉及多个线程时应同步许可证设置。

**可以对创建的 PPTX 进行数字签名吗？**

可以。支持 [Digital signatures](/slides/zh/python-net/digital-signature-in-powerpoint/)（添加和验证）演示文稿。

**创建的演示文稿是否支持宏（VBA）？**

支持。您可以 [create/edit VBA projects](/slides/zh/python-net/presentation-via-vba/) 并保存为启用宏的文件，如 PPTM/PPSM。