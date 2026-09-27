---
title: 在 Python 中创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/python-net/create-presentation/
keywords:
- 创建演示文稿
- 新演示文稿
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
description: "使用 Aspose.Slides 在 Python 中创建 PowerPoint 演示文稿——生成 PPT、PPTX 和 ODP 文件，受益于 OpenDocument 支持，并通过编程方式保存，以获得可靠的结果。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for Python via .NET 创建演示文稿，在其第一张幻灯片上添加带文本的形状，并将结果保存为 PPTX 文件。相同的 API 也可以将演示文稿保存为 PPT 和 ODP，因此您可以在同一代码库中针对 PowerPoint 和 OpenDocument 格式，而无需 Microsoft Office。文末的简短 FAQ 覆盖了有关格式、模板、幻灯片大小、单位、内存使用、线程、授权、数字签名和 VBA 支持的常见问题。

在开始之前，请使用 `pip install aspose.slides` 从 PyPI 安装该包。请参阅[安装](/slides/zh/python-net/installation/)了解 Linux 和 macOS 需要的库，以及 Debian 和 Ubuntu 的系统 Python 所需的虚拟环境。

## **创建演示文稿**

要创建演示文稿并在其第一张幻灯片上放置带文本的形状，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。新的演示文稿已经包含一个空幻灯片。
1. 通过索引 0 从 [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) 集合中获取该幻灯片。
1. 使用幻灯片的 [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) 集合的 [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) 方法添加一个云形的 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)，并设置其 [text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text/)。
1. 使用 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法将演示文稿保存为 PPTX 文件。

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

云形的左上角距幻灯片左边缘 20 点，距顶部边缘 20 点，云形宽 200 点，高 80 点。`with` 语句在代码块结束时释放演示文稿的资源。脚本将在当前文件夹中保存 *new_presentation.pptx*，其中包含一个包含云形及其文本的幻灯片。未授权时，Aspose.Slides 会在每个保存的幻灯片上添加评估水印；请参阅[授权](/slides/zh/python-net/licensing/)。

结果：

![新的演示文稿](new_presentation.png)

## **常见问题**

### 可以将新演示文稿保存为何种格式？

您可以保存为 [PPTX、PPT 和 ODP](/slides/zh/python-net/save-presentation/)，并导出为 [PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/zh/python-net/convert-powerpoint-to-html/)、[SVG](/slides/zh/python-net/render-a-slide-as-an-svg-image/) 和 [图像](/slides/zh/python-net/convert-powerpoint-to-png/)，等等。

### 我可以从模板 (POTX/POTM) 开始并保存为普通 PPTX 吗？

可以。加载模板并保存为所需格式；POTX/POTM/PPTM 等格式均[受支持](/slides/zh/python-net/supported-file-formats/)。

### 创建演示文稿时，如何控制幻灯片大小/宽高比？

设置[幻灯片大小](/slides/zh/python-net/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

### 尺寸和坐标使用什么单位？

使用点（point）作为单位：1 英寸等于 72 点。

### 如何处理包含大量媒体文件的超大演示文稿以降低内存使用？

使用[BLOB 管理策略](/slides/zh/python-net/manage-blob/)，通过使用临时文件限制内存存储，并倾向于基于文件的工作流而非纯内存流。

### 我可以并行创建/保存演示文稿吗？

不能在[多个线程](/slides/zh/python-net/multithreading/)中对同一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例进行操作。请为每个线程或进程运行独立的实例。

### 如何移除试用水印和限制？

[为进程应用许可证](/slides/zh/python-net/licensing/)一次。许可证 XML 必须保持未被修改，如果涉及多个线程，则应同步许可证设置。

### 我可以对创建的 PPTX 进行数字签名吗？

可以。[数字签名](/slides/zh/python-net/digital-signature-in-powerpoint/)（添加和验证）在演示文稿中受支持。

### 创建的演示文稿是否支持宏 (VBA)？

可以。您可以[创建/编辑 VBA 项目](/slides/zh/python-net/presentation-via-vba/)，并保存如 PPTM/PPSM 等宏启用文件。