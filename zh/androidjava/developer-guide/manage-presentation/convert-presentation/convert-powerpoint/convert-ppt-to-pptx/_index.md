---
title: 在 Android 上将 PPT 转换为 PPTX
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 将传统 PPT 文件转换为 PPTX。包含单文件和批量转换的 Java 示例、错误处理以及保真度说明。"
---
## **概述**

PPT 是传统的二进制 PowerPoint 格式，而 PPTX 是更新的 Open XML 格式。Aspose.Slides for Android via Java 可以在没有 Microsoft PowerPoint 的情况下加载 PPT 文件并将其保存为 PPTX。本文展示如何转换单个文件或整个目录的文件，并说明转换后需要验证的内容。

## **将 PPT 文件转换为 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类加载源文件，然后调用 [Presentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 并传入 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveformat/#Pptx)。`finally` 块负责释放演示文稿并释放其资源。

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

文件扩展名本身不会决定输出格式；由 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveformat/#Pptx) 参数决定。如果需要保留原始 PPT 文件，请确保输入和输出路径不同。

## **批量转换多个 PPT 文件**

以下示例将一个目录中的每个 `.ppt` 文件进行转换。每个文件独立处理，因此单个转换失败不会阻止批次的其余文件。

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

在生产环境中，记录完整的异常信息，决定是否允许覆盖已存在的输出文件，并将失败的文件名写入重试或审核队列。损坏的文件、未提供正确密码的受密码保护文件、无法访问的路径以及不受支持的内容都可能导致转换失败。请参阅 [密码保护的演示文稿](/androidjava/password-protected-presentation/) 了解加载加密文件的方法。

## **保真度和遗留功能**

转换通常会保留幻灯片、母版、布局、文本、形状、图像、表格和图表。然而，PPT 与 PPTX 并不以完全相同的方式表示所有功能。没有 PPTX 等价项的遗留功能，或库不支持的功能，可能会被标准化、省略或以不同方式显示。

当转换后的文件包含动画、过渡、嵌入或链接的 OLE 对象、ActiveX 控件、嵌入媒体、罕见字体或 VBA 宏时，请检查文件。普通 PPTX 文件不是宏启用格式，因此在必须保留 VBA 时请使用相应的宏启用工作流。同时验证所需的字体和外部资源是否在将要打开或渲染该演示文稿的环境中可用。

对于重要文档，建议以编程方式重新打开生成的 PPTX，检查关键幻灯片数量和内容，然后在目标查看器中比较其外观和幻灯片放映行为。不要将成功调用 [Presentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 视为所有遗留功能都有精确 PPTX 表示的证明。

## **何时使用 PPTX**

当演示文稿将在当前版本的 PowerPoint 中编辑、与使用 Open XML 包的系统交换，或需要一种比传统二进制 PPT 更易检查和恢复的存储格式时，请使用 PPTX。在转换后的演示文稿通过保真度检查之前，保留原始 PPT 作为归档或回滚副本。

如果需要 PDF、HTML、图像、XPS 或其他输出类型，请参阅 [将演示文稿转换为多种格式](/slides/zh/androidjava/convert-presentation/) 中的特定格式指南，而不要假设所有目标都能保留可编辑的 PowerPoint 功能。

## **在线转换器**

对于偶尔的文件或快速比较，可以使用 [在线 PPT 转 PPTX 转换器](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx)。对于可重复的转换、批量处理或应用级错误处理，请使用 Android via Java API。

## **相关文章**

- [PPT 与 PPTX](/slides/zh/androidjava/ppt-vs-pptx/)
- [在 Android 上保存演示文稿](/slides/zh/androidjava/save-presentation/)
- [受支持的文件格式](/slides/zh/androidjava/supported-file-formats/)
- [在 Android 上打开演示文稿](/slides/zh/androidjava/open-presentation/)

## **常见问题**

**我可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX 吗？**

是的。Aspose.Slides for Android via Java 可以在不需要 Microsoft PowerPoint 的情况下加载和保存演示文稿文件。

**PPT 转 PPTX 的转换会完全保留所有内容吗？**

它会保留常见的演示文稿内容，但对于每个遗留或不受支持的功能，无法保证完全相同的保真度。当文件包含宏、OLE 或 ActiveX 对象、媒体、专用动画或罕见字体时，请审阅生成的文件。

**我可以转换受密码保护的 PPT 文件吗？**

可以，只要在加载文件时提供正确的密码。缺少或错误的密码会导致加载操作失败。

**转换后我应该删除 PPT 文件吗？**

在您在相关查看器和工作流中验证 PPTX 之前，保留原始文件。这样可以在遗留功能转换不同的情况下提供回滚副本。