---
title: 在 Android 上将 PPT 转换为 PPTX
linktitle: PPT 到 PPTX
type: docs
weight: 20
url: /zh/androidjava/convert-ppt-to-pptx/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- PPT 到 PPTX
- 将 PPT 保存为 PPTX
- 导出 PPT 为 PPTX
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Android 上将旧版 PPT 文件转换为 PPTX。包括单文件和批量转换的 Java 示例、错误处理以及保真度说明。"
---
## **概述**

PPT 是传统的二进制 PowerPoint 格式，而 PPTX 是更新的 Open XML 格式。Aspose.Slides for Android via Java 可以在没有 Microsoft PowerPoint 的情况下加载 PPT 文件并将其保存为 PPTX。本文介绍如何转换单个文件或文件夹中的文件，并说明转换后需要验证的内容。

## **将 PPT 文件转换为 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类加载源文件，然后调用带有 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveformat/#Pptx) 参数的 [Presentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法。`finally` 块会释放演示文稿并释放其资源。

```java
// 加载旧版 PPT 演示文稿.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // 将演示文稿保存为 PPTX 格式.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

文件扩展名本身不会决定输出格式；必须使用 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveformat/#Pptx) 参数来指定。若需保留原始 PPT 文件，请确保输入路径和输出路径不同。

## **转换多个 PPT 文件**

以下示例将一个目录中的所有 `.ppt` 文件逐个转换。每个文件独立处理，单个转换失败不会导致其余批次停止。

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

在生产环境中，记录完整异常，决定是否覆盖已存在的输出文件，并将失败的文件名写入重试或审查队列。损坏的文件、未提供正确密码而打开的受密码保护的文件、不可访问的路径以及不受支持的内容都可能导致转换失败。有关加载加密文件，请参阅 [Password-Protected Presentations](/androidjava/password-protected-presentation/)。

## **保真度和遗留功能**

转换通常会保留幻灯片、母版、布局、文本、形状、图像、表格和图表。但 PPT 与 PPTX 并非以完全相同的方式表示所有功能。没有 PPTX 对应项的遗留功能，或库不支持的功能，可能会被标准化、忽略或以不同方式显示。

当转换的文件包含动画、转场、嵌入或链接的 OLE 对象、ActiveX 控件、嵌入媒体、非常规字体或 VBA 宏时，请检查转换结果。普通 PPTX 文件不是宏启用格式，如需保留 VBA，请使用相应的宏启用工作流。同时确认所需字体和外部资源在打开或渲染转换后演示文稿的环境中可用。

对于重要文档，建议以编程方式重新打开生成的 PPTX，检查关键幻灯片数量和内容，然后在目标查看器中比较其外观和放映行为。不要因为一次成功的 [Presentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 调用就认为每个遗留功能都有完全对应的 PPTX 表现。

## **何时使用 PPTX**

当演示文稿将在当前版本的 PowerPoint 中进行编辑、需要与支持 Open XML 包的系统交换，或希望以更易检查和恢复的格式存储时，请使用 PPTX。保留原始 PPT 作为归档或回滚副本，直至转换后的演示文稿通过您的保真度检查。

如果需要 PDF、HTML、图像、XPS 或其他输出格式，请参考 [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/) 中的特定格式指南，而不要假设所有目标都保留可编辑的 PowerPoint 功能。

## **在线转换器**

对于偶尔的文件或快速对比，您可以使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx)。对于可重复的转换、批处理或应用级错误处理，请使用 Android via Java API。

## **相关文章**

- [PPT 与 PPTX](/androidjava/ppt-vs-pptx/)
- [在 Android 上保存演示文稿](/androidjava/save-presentation/)
- [受支持的文件格式](/androidjava/supported-file-formats/)
- [在 Android 上打开演示文稿](/androidjava/open-presentation/)

## **常见问题**

**我可以在没有安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX 吗？**

可以。Aspose.Slides for Android via Java 能够加载和保存演示文稿文件，而无需 Microsoft PowerPoint。

**PPT 转换为 PPTX 能够完全保留所有内容吗？**

它会保留常见的演示文稿内容，但对每个遗留或不受支持的功能并不能保证完全一致的保真度。当文件包含宏、OLE 或 ActiveX 对象、媒体、特定动画或非常规字体时，请检查生成的文件。

**我可以转换受密码保护的 PPT 文件吗？**

可以，只要在加载文件时提供正确的密码。如果密码缺失或不正确，加载操作将失败。

**转换后我应该删除 PPT 文件吗？**

请保留原始文件，直至您在相关查看器和工作流中验证了 PPTX。这样若某些遗留功能转换后有所不同，您仍有回滚副本。