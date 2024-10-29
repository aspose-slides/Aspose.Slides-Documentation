---
title: 转换 OpenOffice ODP
type: docs
weight: 10
url: /zh/cpp/convert-openoffice-odp/
keywords: "将 ODP 转换为 PDF，ODP 转换为 HTML，ODP 转换为 TIFF"
description: "使用 Aspose.Slides 将 ODP 转换为 PDF，ODP 转换为 PPT，ODP 转换为 PPTX，ODP 转换为 HTML 和其他格式。"
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) 允许您将 OpenOffice ODP 演示文稿转换为多种格式。用于将 ODP 文件转换为其他文档格式的 API 与用于 PowerPoint (PPT 和 PPTX) 转换操作的 API 相同。

这些示例向您展示如何将 ODP 文档转换为其他格式（只需更改源 ODP 文件）：

- [将 ODP 转换为 HTML](/slides/zh/cpp/convert-powerpoint-ppt-and-pptx-to-html/)
- [将 ODP 转换为 PDF](/slides/zh/cpp/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [将 ODP 转换为 TIFF](/slides/zh/cpp/convert-powerpoint-ppt-and-pptx-to-tiff/)
- [将 ODP 转换为 SWF Flash](/slides/zh/cpp/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [将 ODP 转换为 XPS](/slides/zh/cpp/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [将 ODP 转换为带注释的 PDF](/slides/zh/cpp/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [将 ODP 转换为带注释的 TIFF](/slides/zh/cpp/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

例如，如果您需要将 ODP 演示文稿转换为 PDF，可以这样完成：

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
```