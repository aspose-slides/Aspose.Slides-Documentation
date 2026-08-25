---
title: 在 PHP 中将 PPT 转换为 PPTX
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/php-java/convert-ppt-to-pptx/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中将旧版 PPT 文件转换为 PPTX。包括单文件和批量转换的 PHP 示例、错误处理以及保真度说明。"
---
## **概述**

PPT 是旧的二进制 PowerPoint 格式，而 PPTX 是更新的 Open XML 格式。Aspose.Slides for PHP via Java 可以在不依赖 Microsoft PowerPoint 的情况下加载 PPT 文件并将其保存为 PPTX。本文展示如何转换单个文件或整个目录的文件，并说明转换后需要检查哪些内容。

## **将 PPT 文件转换为 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类加载源文件，然后调用 [Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save) 并传入 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/#Pptx)。`finally` 块会释放演示文稿并释放其资源。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// 加载旧版 PPT 演示文稿。
$presentation = new Presentation("presentation.ppt");
try {
    // 将演示文稿保存为 PPTX 格式。
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

文件扩展名本身并不会决定输出格式；真正决定的是 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/#Pptx) 参数。如果需要保留原始 PPT 文件，请确保输入路径和输出路径不同。

## **批量转换 PPT 文件**

下面的示例会转换指定目录下的所有 `.ppt` 文件。每个文件独立处理，单个转换失败不会导致整个批处理停止。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

在生产环境中，记录完整的异常信息，判断是否允许覆盖已有的输出文件，并将失败的文件名写入重试或审查队列。文件损坏、未提供正确密码的受密码保护文件、路径不可访问以及不受支持的内容都可能导致转换失败。有关加载加密文件，请参阅 [Password-Protected Presentations](/slides/zh/php-java/password-protected-presentation/)。

## **保真度与旧版特性**

转换通常会保留幻灯片、母版、布局、文本、形状、图像、表格和图表。但 PPT 与 PPTX 并非以完全相同的方式表示所有特性。没有 PPTX 对应项的旧版特性，或库不支持的特性，可能会被标准化、忽略或以不同方式显示。

当转换后的文件包含动画、转场、嵌入或链接的 OLE 对象、ActiveX 控件、嵌入媒体、非常规字体或 VBA 宏时，请仔细检查。普通 PPTX 文件不是宏启用格式，因此在必须保留 VBA 时请使用相应的宏启用工作流。同时，确保所需的字体和外部资源在打开或渲染转换后演示文稿的环境中可用。

对于重要文档，建议以编程方式重新打开生成的 PPTX，检查关键幻灯片数量和内容，然后在目标查看器中比较其外观和放映行为。不要把一次成功的 [Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save) 调用视为所有旧版特性都有精确 PPTX 表现的证明。

## **何时使用 PPTX**

当演示文稿需要在当前版本的 PowerPoint 中编辑、与使用 Open XML 包的系统交换，或以更易检查和恢复的格式存储时，使用 PPTX。将原始 PPT 保留为归档或回滚副本，直到转换后的演示文稿通过了您的保真度检查。

如果需要 PDF、HTML、图像、XPS 或其他输出类型，请参阅 [Convert Presentations to Multiple Formats](/slides/zh/php-java/convert-presentation/) 中针对各格式的指南，而不要假设所有目标都能保留可编辑的 PowerPoint 特性。

## **在线转换器**

对于偶尔的文件或快速比较，您可以使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx)。如需重复转换、批量处理或在应用层面进行错误处理，请使用 PHP API。

## **相关文章**

- [PPT vs PPTX](/slides/zh/php-java/ppt-vs-pptx/)
- [Save Presentations in PHP](/slides/zh/php-java/save-presentation/)
- [Supported File Formats](/slides/zh/php-java/supported-file-formats/)
- [Open Presentations in PHP](/slides/zh/php-java/open-presentation/)

## **常见问答**

**是否可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX？**

可以。Aspose.Slides for PHP via Java 能在不依赖 Microsoft PowerPoint 的情况下加载和保存演示文稿文件。

**PPT 转 PPTX 转换能完全保留所有内容吗？**

它能保留常见的演示文稿内容，但对每个旧版或不受支持的特性并不保证完全保真。若文件包含宏、OLE 或 ActiveX 对象、媒体、专用动画或非常规字体，请仔细检查生成的文件。

**可以转换受密码保护的 PPT 文件吗？**

可以，只要在加载文件时提供正确的密码。缺少或错误的密码会导致加载失败。

**转换后是否应删除原始 PPT 文件？**

请保留原始文件，直到您在相关查看器和工作流中验证了 PPTX 的正确性。这可以在出现旧版特性转换差异时提供回滚副本。