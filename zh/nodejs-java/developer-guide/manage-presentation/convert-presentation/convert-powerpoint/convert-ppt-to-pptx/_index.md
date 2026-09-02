---
title: 在 Node.js 中将 PPT 转换为 PPTX
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/nodejs-java/convert-ppt-to-pptx/
keywords:
  - 转换 PowerPoint
  - 转换演示文稿
  - 转换幻灯片
  - 转换 PPT
  - PPT 转 PPTX
  - 将 PPT 保存为 PPTX
  - 导出 PPT 为 PPTX
  - PowerPoint
  - 演示文稿
  - Node.js
  - JavaScript
  - Aspose.Slides
description: 使用 Aspose.Slides 在 Node.js 中将传统 PPT 文件转换为 PPTX。包括单文件和批量转换的 JavaScript 示例、错误处理以及保真度说明。
---
## **概述**

PPT 是传统的二进制 PowerPoint 格式，而 PPTX 是更新的 Open XML 格式。Aspose.Slides for Node.js via Java 可以在不安装 Microsoft PowerPoint 的情况下加载 PPT 文件并将其保存为 PPTX。本文展示了如何转换单个文件或整个文件夹，并说明转换后需要检查哪些内容。

## **将 PPT 文件转换为 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类加载源文件，然后使用 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveformat/) 调用 [Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save)。`finally` 块会释放演示文稿并释放其资源。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 加载旧版 PPT 演示文稿。
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // 将演示文稿保存为 PPTX 格式。
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

文件扩展名本身并不会决定输出格式；由 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveformat/) 参数决定。如果需要保留原始 PPT 文件，请确保输入和输出路径不同。

## **批量转换 PPT 文件**

下面的示例会转换指定目录中的每个 `.ppt` 文件。每个文件独立处理，因此一次转换失败不会阻止批处理的其余文件。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

在生产环境中，记录完整错误，决定是否覆盖已有的输出文件，并将失败的文件名写入重试或审查队列。损坏的文件、未提供正确密码而打开的受密码保护的文件、不可访问的路径以及不受支持的内容都可能导致转换失败。有关加载加密文件，请参阅 [Password-Protected Presentations](/nodejs-java/password-protected-presentation/)。

## **保真度与遗留功能**

转换通常会保留幻灯片、母版、布局、文本、形状、图像、表格和图表。但 PPT 和 PPTX 并未以完全相同的方式表示所有功能。没有对应 PPTX 的遗留功能，或库不支持的功能，可能会被标准化、省略或以不同方式显示。

当转换文件包含动画、转场、嵌入或链接的 OLE 对象、ActiveX 控件、嵌入媒体、罕见字体或 VBA 宏时，请检查转换后的文件。普通的 PPTX 文件不是宏启用格式，因此在需要保留 VBA 时应使用相应的宏启用工作流。同时确认在打开或渲染转换后演示文稿的环境中，所需的字体和外部资源均已就绪。

对于重要文档，建议以编程方式重新打开生成的 PPTX，检查关键的幻灯片数量和内容，然后在预期的查看器中比较其外观和放映行为。不要将一次成功的 [Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save) 调用视为所有遗留功能都有精确 PPTX 表现的证明。

## **何时使用 PPTX**

当演示文稿将在当前版本的 PowerPoint 中编辑、与使用 Open XML 包的系统交换，或需要以更易检查和恢复的形式存储时，请使用 PPTX。保留原始 PPT 作为归档或回滚副本，直至转换后的演示文稿通过您的保真度检查。

如果需要 PDF、HTML、图像、XPS 或其他输出类型，请参考 [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) 中的特定格式指南，而不要假设所有目标格式都能保留可编辑的 PowerPoint 功能。

## **在线转换器**

对于偶尔的文件或快速对比，可使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx)。若需重复转换、批处理或应用级错误处理，请使用 Node.js via Java API。

## **相关文章**

- [PPT 与 PPTX](/nodejs-java/ppt-vs-pptx/)
- [在 Node.js 中保存演示文稿](/nodejs-java/save-presentation/)
- [支持的文件格式](/nodejs-java/supported-file-formats/)
- [在 Node.js 中打开演示文稿](/nodejs-java/open-presentation/)

## **常见问题**

**我可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX 吗？**

可以。Aspose.Slides for Node.js via Java 能在不依赖 Microsoft PowerPoint 的情况下加载并保存演示文稿文件。

**PPT 转换为 PPTX 能完全保留所有内容吗？**

它会保留常见的演示文稿内容，但对于每个遗留或不受支持的功能，无法保证完全一致的保真度。当文件包含宏、OLE 或 ActiveX 对象、媒体、特定动画或罕见字体时，请检查生成的文件。

**我可以转换受密码保护的 PPT 文件吗？**

可以，只要在加载文件时提供正确的密码。缺少或错误的密码会导致加载操作失败。

**转换后我应该删除 PPT 文件吗？**

在您使用重要的查看器和工作流验证 PPTX 之前，请保留原始文件。这可以在遗留功能转换出现差异时提供回滚副本。