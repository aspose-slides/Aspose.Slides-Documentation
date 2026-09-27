---
title: 在 Node.js via .NET 中将 PowerPoint 转换为 PDF
linktitle: PowerPoint 转 PDF
type: docs
weight: 30
url: /zh/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint 转 PDF
- 将 PowerPoint 转换为 PDF
- PPTX 转 PDF
- PPT 转 PDF
- ODP 转 PDF
- 将演示文稿保存为 PDF
- PDF/A
- PdfOptions
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via .NET 在 JavaScript 中将 PPTX、PPT 和 ODP 演示文稿转换为 PDF，并使用 PdfOptions 生成归档的 PDF/A 文件。"
---
## **概述**

Aspose.Slides for Node.js via .NET 在没有 Microsoft PowerPoint 的情况下将 PowerPoint 和 OpenDocument 演示文稿转换为 PDF。每个可见的幻灯片会生成与幻灯片尺寸相同的 PDF 页面，文本保持可选择和可搜索。本文展示了使用 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 的默认转换以及转换为 PDF/A 的示例。

示例假设项目文件夹中存在名为 `sample.pptx` 的演示文稿，您可以在[Installation](/slides/zh/nodejs-net/installation/) 中进行设置。任何 PowerPoint 演示文稿均可使用。将每个示例保存为项目文件夹中的 `.js` 文件，并使用 `node` 在该文件夹中运行。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET 没有自己的 API 参考。它以 camelCase 名称镜像 Aspose.Slides for .NET API，因此本文中的 API 链接指向 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) 中相应的类和成员。
{{% /alert %}}

## **将演示文稿转换为 PDF**

要将演示文稿转换为 PDF，请按以下步骤操作：

1. 通过将其路径传递给 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) 构造函数打开演示文稿。相同的代码适用于 PPTX、PPT 和 ODP 文件。  
2. 使用输出路径和 `SaveFormat.Pdf` 调用 [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法。  
3. 在 `finally` 块中调用 `dispose` 以释放支持演示文稿的 .NET 资源。

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

脚本将 `sample.pdf` 写入项目文件夹。转换使用默认设置：每个未隐藏的幻灯片都会生成一页，按幻灯片顺序。没有许可证时，每页还会显示评估水印；请参阅[Licensing](/slides/zh/nodejs-net/licensing/)。

## **将演示文稿转换为 PDF/A**

要控制输出，请将 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 对象作为 `save` 的第三个参数传入。以下示例将 [compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) 属性设置为 `PdfCompliance.PdfA2b`，从而生成 PDF/A-2b 文件。PDF/A 是用于长期存档的 ISO 标准：除其他规则外，它要求文档使用的每种字体都嵌入文件中。

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

脚本将 `sample-pdfa.pdf` 写入项目文件夹，页面与默认转换相同。要确认文件符合标准，可使用如 [veraPDF](https://verapdf.org/) 的 PDF/A 验证器进行检查。其他 [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) 值可选择其他标准，例如 `PdfA1b`、`PdfA2a` 或用于可访问性的 `PdfUa`。

## **常见问题**

**如何在 PDF 中包含隐藏的幻灯片？**

隐藏的幻灯片默认会被跳过。将 `PdfOptions` 的 [showHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) 属性设为 `true` 并将该选项传递给 `save`。

**我可以用密码保护 PDF 吗？**

可以。 在调用 `save` 之前，将 `PdfOptions` 的 [password](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/password/) 属性设置为相应的密码。PDF 阅读器会在打开文件前要求输入该密码。

**我可以只转换部分幻灯片吗？**

可以。将幻灯片位置数组作为 `save` 的第四个参数传入。位置从 1 开始，如果不需要选项，第三个参数可以为 `null`：`presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` 将生成仅包含第一个和第三个幻灯片的 PDF。

**在 Linux 上转换时文本为何看起来不同？**

Aspose.Slides 只能使用运行转换的机器上已安装的字体。当演示文稿使用的字体缺失（例如典型的 Linux 服务器上缺少 Calibri）时，Aspose.Slides 会使用已安装的其他字体替代，导致文本外观和换行位置改变。请安装演示文稿所需的字体，以在 Linux 上获得与 Windows 相同的结果。

**我可以将 PDF 作为 Buffer 而不是文件获取吗？**

可以。`presentation.saveToBuffer(SaveFormat.Pdf)` 会返回一个 Node.js `Buffer`，在将结果通过 HTTP 响应返回时非常方便。它同样接受 `PdfOptions` 作为第二个参数。