---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /zh/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- PowerPoint 自动化 Python
- Python PPT 库
- 将 PowerPoint 导出为 PDF Python
- 将 PowerPoint 导出为 SVG Python
- 在 Python 中编辑 PowerPoint
- Python PowerPoint（无需 Microsoft Office）
- 使用 Python 管理 PPTX
- Python 幻灯片预览
- Python 为幻灯片添加音频
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET 提供全面的功能集，包括管理文本、形状、表格和动画，向幻灯片添加音频和视频，预览幻灯片，以及导出为 SVG、PDF 等格式。"
---
{{% alert color="primary" %}}

**欢迎使用 Aspose.Slides for Python via .NET**

![Aspose.Slides for Python via .NET Product Logo](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET 是一个强大的类库，允许您的应用程序读取和写入 PowerPoint® 演示文稿，且无需 Microsoft PowerPoint®。

它是首个也是唯一一个为 Python 开发者提供完整 PowerPoint® 文档管理功能的组件。

Aspose.Slides for Python via .NET 包含丰富的功能，例如处理文本、形状、表格和动画；添加音频和视频；预览幻灯片；以及将幻灯片导出为 SVG、PDF 等格式。

{{% /alert %}}

## 安装 Aspose.Slides for Python via .NET

```bash
pip install aspose.slides
```

该软件包自带所需的 .NET 运行时，无需额外安装，也不需要 Microsoft PowerPoint。支持 Windows、Linux 或 macOS 上的 Python 3.7 及更高版本。

## 在 Python 中创建 PowerPoint 演示文稿

以下示例创建一个演示文稿，在第一张幻灯片上添加一个带文本的形状，并将结果分别保存为 PPTX 和 PDF。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

运行后会在工作目录生成 `presentation.pptx`（约 34 KB）和 `presentation.pdf`（约 36 KB）。

如果没有许可证，库将以评估模式运行，添加水印并限制幻灯片数量。请参阅 [Licensing](/slides/zh/python-net/licensing/) 进行许可证激活。

## Aspose.Slides for Python via .NET 资源

探索以下实用资源：

- [Aspose.Slides for Python via .NET 在线文档](/slides/zh/python-net/)
- [Aspose.Slides for Python via .NET 功能概述](/slides/zh/python-net/features-overview/)
- [Aspose.Slides for Python via .NET 发行说明](https://releases.aspose.com/slides/zh/python-net/release-notes/)
- [Aspose.Slides for Python via .NET 产品页面](https://products.aspose.com/slides/zh/python-net/)
- [下载 Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/zh/python-net/)
- [安装 Aspose.Slides for Python via .NET PyPi 包](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET API 参考指南](https://reference.aspose.com/slides/zh/python-net/)
- [Aspose.Slides for Python via .NET 免费支持论坛](https://forum.aspose.com/c/slides/zh/11)
- [Aspose.Slides for Python via .NET 付费支持帮助台](https://helpdesk.aspose.com/)

## FAQ

### 什么是 Aspose.Slides for Python via .NET？

Aspose.Slides for Python via .NET 是一个强大的 Python 库，允许您在没有安装 Microsoft PowerPoint 的情况下，以编程方式创建、编辑和转换 PowerPoint 演示文稿（PPT、PPTX、ODP）。

### Aspose.Slides 支持哪些演示文稿功能？

该库支持管理文本、形状、表格、图表、动画、母版幻灯片、音频、视频等。还可进行幻灯片预览、渲染、打印，以及导出为 PDF、SVG、HTML、图像等格式。

### 可以使用 Aspose.Slides 将演示文稿转换为其他格式吗？

可以。Aspose.Slides 能将 PowerPoint 文件高保真且高性能地转换为 PDF、SVG、HTML、JPG、PNG、TIFF 等多种格式。

### 使用 Aspose.Slides 是否必须安装 Microsoft PowerPoint？

不需要。Aspose.Slides 是独立的 API，无需 Microsoft Office 或任何第三方软件。

### Aspose.Slides for Python via .NET 支持哪些平台？

它是跨平台的，可在 Windows、Linux 和 macOS 环境中运行。

### 如何快速上手 Aspose.Slides for Python？

您可以通过 PyPi 安装，并查阅 [Developer Guide](/slides/zh/python-net/developer-guide/) 获取示例、API 参考和教程，快速开始使用。