---
title: 转换 OpenOffice ODP
type: docs
weight: 10
url: /python-net/convert-openoffice-odp/
keywords: "将 ODP 转换为 PDF, ODP 转换为 PPT, ODP 转换为 PPTX, ODP 转换为 XPS, ODP 转换为 HTML, ODP 转换为 TIFF"
description: "使用 Aspose.Slides 将 ODP 转换为 PDF、ODP 转换为 PPT、ODP 转换为 PPTX、ODP 转换为 HTML 及其他格式。"
---

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) 允许您将 OpenOffice ODP 演示文稿转换为多种格式。用于将 ODP 文件转换为其他文档格式的 API 与用于 PowerPoint (PPT 和 PPTX) 转换操作的 API 相同。

这些示例向您展示了如何将 ODP 文档转换为其他格式（只需更改源 ODP 文件）：

- [将 ODP 转换为 HTML](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [将 ODP 转换为 PDF](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [将 ODP 转换为 TIFF](/slides/python-net/convert-powerpoint-to-tiff/)
- [将 ODP 转换为 SWF Flash](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [将 ODP 转换为 XPS](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [将 ODP 转换为带注释的 PDF](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [将 ODP 转换为带注释的 TIFF](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

例如，如果您需要将 ODP 演示文稿转换为 PDF，可以按以下方式进行：

```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```