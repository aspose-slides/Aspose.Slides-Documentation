---
title: 在 Java 中将 PPT 转换为 PPTX
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/java/convert-ppt-to-pptx/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- PPT 转 PPTX
- 将 PPT 保存为 PPTX
- 将 PPT 导出为 PPTX
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中将传统 PPT 文件转换为 PPTX。包括单文件和批量转换的 Java 示例、错误处理和保真度说明。"
---
## **概览**

PPT 是传统的二进制 PowerPoint 格式，而 PPTX 是较新的 Open XML 格式。Aspose.Slides for Java 可以在不使用 Microsoft PowerPoint 的情况下加载 PPT 文件并将其保存为 PPTX。本文展示了如何转换单个文件或整个文件夹，并说明了转换后需要验证的内容。

## **将 PPT 文件转换为 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类加载源文件，然后调用 [Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 并使用 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveformat/#Pptx) 参数。`finally` 块会释放演示文稿并释放其资源。

```java
// 加载传统 PPT 演示文稿.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // 将演示文稿保存为 PPTX 格式.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

文件扩展名本身并不会决定输出格式；是 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveformat/#Pptx) 参数决定的。如果需要保留原始 PPT 文件，请确保输入和输出路径不同。

## **批量转换多个 PPT 文件**

下面的示例会转换指定目录下的每个 `.ppt` 文件。每个文件独立处理，单个转换失败不会导致批处理停止。

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

在生产环境中，记录完整的异常信息，决定是否可以覆盖已存在的输出文件，并将失败的文件名写入重试或审查队列。文件损坏、未提供正确密码的受密码保护文件、无法访问的路径以及不受支持的内容都可能导致转换失败。有关加载加密文件，请参阅 [Password-Protected Presentations](/java/password-protected-presentation/)。

## **保真度与遗留功能**

转换通常会保留幻灯片、母版、布局、文本、形状、图像、表格和图表。但 PPT 和 PPTX 并未以完全相同的方式表示所有功能。没有 PPTX 等价或库不支持的遗留功能可能会被标准化、省略或以不同方式显示。

当文件包含动画、转场、嵌入或链接的 OLE 对象、ActiveX 控件、嵌入媒体、非常用字体或 VBA 宏时，请检查转换后的文件。普通 PPTX 文件不是宏启用格式，因此在必须保留 VBA 时请使用相应的宏启用工作流。同时确认所需字体和外部资源在将要打开或渲染转换后演示文稿的环境中可用。

对于重要文档，建议在程序中重新打开生成的 PPTX，检查关键幻灯片计数和内容，然后在目标查看器中比较其外观和放映行为。不要将一次成功的 [Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 调用视为所有遗留功能都有完全对应的 PPTX 表现的证明。

## **何时使用 PPTX**

当演示文稿需要在当前版本的 PowerPoint 中编辑、与使用 Open XML 包的系统交换，或存储为比传统二进制 PPT 更易检查和恢复的格式时，请使用 PPTX。将原始 PPT 保留为归档或回滚副本，直至转换后的演示文稿通过您的保真度检查。

如果需要 PDF、HTML、图像、XPS 或其他输出类型，请参考 [Convert Presentations to Multiple Formats](/java/convert-presentation/) 中的特定格式指南，而不要假设所有目标都能保留可编辑的 PowerPoint 功能。

## **在线转换器**

对于偶尔的文件或快速比较，您可以使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx)。对于可重复的转换、批处理或应用级错误处理，请使用 Java API。

## **相关文档**

- [PPT vs PPTX](/java/ppt-vs-pptx/)
- [Save Presentations in Java](/java/save-presentation/)
- [Supported File Formats](/java/supported-file-formats/)
- [Open Presentations in Java](/java/open-presentation/)

## **常见问题解答**

**可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX 吗？**

可以。Aspose.Slides for Java 能够在不依赖 Microsoft PowerPoint 的情况下加载和保存演示文稿文件。

**PPT 转 PPTX 的转换会完全保留所有内容吗？**

它会保留常见的演示文稿内容，但并不能保证每个遗留或不受支持的功能都能完全保真。当文件包含宏、OLE 或 ActiveX 对象、媒体、特殊动画或非常用字体时，请检查生成的文件。

**可以转换受密码保护的 PPT 文件吗？**

可以，只需在加载文件时提供正确的密码。缺少或密码错误会导致加载操作失败。

**转换后是否应该删除 PPT 文件？**

在您已在相关查看器和工作流中验证 PPTX 之前，请保留原始文件。这可以在遗留功能转换出现差异时提供回滚副本。