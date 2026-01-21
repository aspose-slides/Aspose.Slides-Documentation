---
title: 在 C++ 中转换 OpenDocument 演示文稿
linktitle: 转换 OpenDocument
type: docs
weight: 10
url: /zh/cpp/convert-openoffice-odp/
keywords:
- 转换 ODP
- ODP 转图像
- ODP 转 GIF
- ODP 转 HTML
- ODP 转 JPG
- ODP 转 MD
- ODP 转 PDF
- ODP 转 PNG
- ODP 转 PPT
- ODP 转 PPTX
- ODP 转 TIFF
- ODP 转视频
- ODP 转 Word
- ODP 转 XPS
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 可轻松将 ODP 转换为 PDF、HTML 和图像格式。通过快速且准确的演示文稿转换，提升您的 C++ 应用程序。"
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) 允许您将 OpenDocument (ODP) 演示文稿转换为多种格式（HTML、PDF、TIFF、SWF、XPS 等）。
用于将 ODP 文件转换为其他文档格式的 API 与用于 PowerPoint（PPT 和 PPTX）转换操作的 API 相同。

例如，如果您需要将 ODP 演示文稿转换为 PDF，可以按如下方式执行：
```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```
