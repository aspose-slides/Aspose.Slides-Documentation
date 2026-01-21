---
title: 在 Python 中转换 OpenDocument 演示文稿
linktitle: 转换 OpenDocument
type: docs
weight: 10
url: /zh/python-net/convert-openoffice-odp/
keywords:
- 转换 OpenDocument
- 转换 ODP
- ODP 转 PDF
- ODP 转 PPT
- ODP 转 PPTX
- ODP 转 XPS
- ODP 转 HTML
- ODP 转 TIFF
- ODP 转 SWF
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中将 OpenDocument ODP 转换为 PDF、PPT、PPTX、XPS、HTML、TIFF 或 SWF：代码示例、高保真、批量转换和自定义。"
---

## **转换 ODP 文件**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) 允许您将 OpenDocument (ODP) 演示文稿转换为多种格式 (HTML、PDF、TIFF、SWF、XPS 等)。用于将 ODP 文件转换为其他文档格式的 API 与用于 PowerPoint (PPT 和 PPTX) 转换操作的 API 相同。

例如，如果您需要将 ODP 演示文稿转换为 PDF，可以按以下方式操作：
```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```


## **常见问题**

**我可以在不安装 LibreOffice 或 OpenOffice 的情况下将 ODP 转换为 PPTX 吗？**

是的。Aspose.Slides 是一个完全独立的库，能够处理 PowerPoint 和 OpenOffice 格式，无需任何外部应用程序。

**Aspose.Slides 能够打开和保存受密码保护的 ODP/OTP 文件吗？**

是的。提供密码后，它可以[加载加密演示文稿](/slides/zh/python-net/password-protected-presentation/)，并且还能使用加密和保护设置保存演示文稿。

**我可以在转换 ODP 之前提取嵌入的媒体文件（音频/视频）吗？**

是的。Aspose.Slides 允许您访问并提取演示文稿中嵌入的[audio](/slides/zh/python-net/audio-frame/)和[video](/slides/zh/python-net/video-frame/)，这对预转换处理或单独重用非常有帮助。

**我可以将转换后的 ODP 保存为 Strict Office Open XML 吗？**

是的。保存为 PPTX 时，您可以通过[save options](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)启用 Strict OOXML，以满足更严格的合规性要求。