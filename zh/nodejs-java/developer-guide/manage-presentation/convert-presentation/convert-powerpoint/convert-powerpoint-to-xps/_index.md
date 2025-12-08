---
title: 将 PowerPoint 转换为 XPS
type: docs
weight: 70
url: /zh/nodejs-java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX 转 XPS"
description: "在 JavaScript 中将 PowerPoint PPT(X) 转换为 XPS"
---

## **关于 XPS**

Microsoft 将 [XPS](https://docs.fileformat.com/page-description-language/xps/) 开发为 [PDF](https://docs.fileformat.com/pdf/) 的替代方案。它允许您通过输出与 PDF 非常相似的文件来打印内容。XPS 格式基于 XML。XPS 文件的布局或结构在所有操作系统和打印机上保持一致。

## **何时使用 Microsoft XPS 格式**

{{% alert color="primary" %}} 
要了解 Aspose.Slides 如何将 PPT 或 PPTX 演示文稿转换为 XPS 格式，您可以查看 [此免费在线转换应用](https://products.aspose.app/slides/conversion)。 
{{% /alert %}} 

如果您想降低存储成本，可以将 Microsoft PowerPoint 演示文稿转换为 XPS 格式。这样，您会发现保存、共享和打印文档更加容易。

Microsoft 继续在 Windows（甚至在 Windows 10）中实现对 XPS 的强力支持，因此您可以考虑将文件保存为此格式。如果您使用 Windows 8.1、Windows 8、Windows 7 和 Windows Vista，则 XPS 可能是某些操作的最佳选项。

- **Windows 8** 使用 OXPS（Open XPS）格式来保存 XPS 文件。OXPS 是原始 XPS 格式的标准化版本。Windows 8 对 XPS 文件的支持优于对 PDF 文件的支持。  
  - **XPS:** 内置 XPS 查看器/阅读器并提供打印到 XPS 的功能。  
  - **PDF:** 提供 PDF 阅读器，但不具备打印到 PDF 的功能。  

- **Windows 7 和 Windows Vista** 使用原始 XPS 格式。这些操作系统对 XPS 文件的支持也优于对 PDF 的支持。  
  - **XPS:** 内置 XPS 查看器并提供打印到 XPS 的功能。  
  - **PDF:** 没有 PDF 阅读器，也没有打印到 PDF 的功能。  

|<p>**输入 PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**输出 XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|

Microsoft 最终通过 Windows 10 中的“Print to PDF”功能实现了对 PDF 打印操作的支持。此前，用户需要通过 XPS 格式来打印文档。

## **使用 Aspose.Slides 进行 XPS 转换**

在 [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/) 中，您可以使用由 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类公开的 [**save**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) 方法将整个演示文稿转换为 XPS 文档。

在将演示文稿转换为 XPS 时，必须使用以下任一设置保存演示文稿：

- 默认设置（不使用 [**XPSOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions)）
- 自定义设置（使用 [**XPSOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions)）

### **使用默认设置将演示文稿转换为 XPS**

此 JavaScript 示例代码演示如何使用标准设置将演示文稿转换为 XPS 文档：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // 将演示文稿保存为 XPS 文档
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **使用自定义设置将演示文稿转换为 XPS**

此示例代码演示如何在 JavaScript 中使用自定义设置将演示文稿转换为 XPS 文档：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // 实例化 TiffOptions 类
    var options = new aspose.slides.XpsOptions();
    // 将 MetaFiles 保存为 PNG
    options.setSaveMetafilesAsPng(true);
    // 将演示文稿保存为 XPS 文档
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**我可以将 XPS 保存到流中而不是文件吗？**  

是的——Aspose.Slides 允许您直接导出到流，这对于 Web API、服务器端管道或任何希望在不接触文件系统的情况下发送 XPS 的场景都非常理想。

**隐藏幻灯片会被携带到 XPS 中吗？我可以排除它们吗？**  

默认情况下，仅渲染常规（可见）幻灯片。您可以通过在保存为 XPS 之前使用 [包含或排除隐藏幻灯片](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/)的 [导出设置](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/)来实现，确保输出恰好包含您想要的页面。