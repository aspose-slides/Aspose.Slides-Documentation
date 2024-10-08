---
title: 转换 OpenOffice ODP
type: docs
weight: 10
url: /zh/net/convert-openoffice-odp/
keywords: "将 ODP 转换为 PDF, ODP 转换为 PPT, ODP 转换为 PPTX, ODP 转换为 XPS, ODP 转换为 HTML, ODP 转换为 TIFF"
description: "使用 Aspose.Slides 将 ODP 转换为 PDF，ODP 转换为 PPT，ODP 转换为 PPTX，ODP 转换为 HTML 和其他格式。"
---

[**Aspose.Slides API**](https://products.aspose.com/slides/net/) 允许您将 OpenOffice ODP 演示文稿转换为多种格式。用于将 ODP 文件转换为其他文档格式的 API 与用于 PowerPoint (PPT 和 PPTX) 转换操作的 API 是相同的。

这些示例向您展示如何将 ODP 文档转换为其他格式（只需更改源 ODP 文件）：

- [将 ODP 转换为 HTML](/slides/zh/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [将 ODP 转换为 PDF](/slides/zh/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [将 ODP 转换为 TIFF](/slides/zh/net/convert-powerpoint-to-tiff/)
- [将 ODP 转换为 SWF Flash](/slides/zh/net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [将 ODP 转换为 XPS](/slides/zh/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [将 ODP 转换为带备注的 PDF](/slides/zh/net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [将 ODP 转换为带备注的 TIFF](/slides/zh/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

例如，如果您需要将 ODP 演示文稿转换为 PDF，可以这样做：

```csharp
using (Presentation pres = new Presentation("pres.odp"))
{
    pres.Save("pres.pdf", SaveFormat.Pdf);
}
```



## 在不同应用程序中打开的 OpenDocument 演示文稿

当 OpenDocument 演示文稿文件在 PowerPoint 中打开时，它可能缺少在创建其的原始应用程序中具有的格式，因为 OpenDocument 演示文稿应用程序和 PowerPoint 应用程序提供的功能和选项不同。

以下是一些差异：
- 在 PowerPoint 中，所有表格通常最后加载并覆盖其他形状（不管 ODP 幻灯片上的形状排列）。
- PowerPoint 不支持 ODP 表格的图片填充。
- LibreOffice/OpenOffice Impress 不支持文本的垂直旋转（270，堆叠）和分布对齐。
- LibreOffice/OpenOffice Impress 不支持文本的图片填充、渐变填充和图案填充。

MS PowerPoint 和 LibreOffice/OpenOffice Impress 处理列表的方式也不同。在 PowerPoint 中创建的 ODP 文件在 LibreOffice/OpenOffice 中打开时不能正确显示，反之亦然。

这张图片展示了在 LibreOffice Impress 中创建的列表视图：

![odp-list-example](odp-list-example.png)



**Aspose.Slides** 保存 ODP 列表，以确保它们在 LibreOffice/OpenOffice Impress 中正确显示。

[了解更多关于 OpenDocument 格式和 PowerPoint 的信息](https://support.microsoft.com/en-gb/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0/)。