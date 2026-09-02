---
title: 将 PPT 转换为 PPTX（PHP）
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/php-java/convert-ppt-to-pptx/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- PPT 转 PPTX
- 将 PPT 保存为 PPTX
- 导出 PPT 为 PPTX
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中将传统 PPT 文件转换为 PPTX。包含单文件和批量转换的 PHP 示例、错误处理以及保真度说明。"
---
## **概述**

PPT 是传统的二进制 PowerPoint 格式，而 PPTX 是更新的 Open XML 格式。Aspose.Slides for PHP via Java 可以在没有 Microsoft PowerPoint 的情况下加载 PPT 文件并将其保存为 PPTX。本文展示如何转换单个文件或整个文件夹，并说明转换后需要验证的事项。

## **将 PPT 文件转换为 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类加载源文件，然后使用 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/#Pptx) 调用 [Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save)。`finally` 块会释放演示文稿并释放其资源。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// 加载遗留 PPT 演示文稿。
$presentation = new Presentation("presentation.ppt");
try {
    // 保存演示文稿为 PPTX 格式。
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

文件扩展名本身不会决定输出格式；需要使用 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/#Pptx) 参数来指定。如果需要保留原始 PPT 文件，请确保输入和输出路径不同。

## **转换多个 PPT 文件**

以下示例会转换指定目录下的每个 `.ppt` 文件。每个文件独立处理，单个转换失败不会导致整个批次中止。

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

在生产环境中，需记录完整异常，决定是否可以覆盖已存在的输出文件，并将失败的文件名写入重试或审查队列。损坏的文件、未提供正确密码而打开的受密码保护的文件、不可访问的路径以及不受支持的内容都可能导致转换失败。有关加载加密文件，请参阅 [Password-Protected Presentations](/php-java/password-protected-presentation/)。

## **保真度和遗留功能**

转换通常会保留幻灯片、母版、版式、文本、形状、图像、表格和图表。然而，PPT 与 PPTX 并未以完全相同的方式表示所有功能。若某个遗留功能在 PPTX 中没有对应或库不支持，可能会被标准化、省略或以不同方式显示。

当转换的文件包含动画、切换、嵌入或链接的 OLE 对象、ActiveX 控件、嵌入媒体、罕见字体或 VBA 宏时，请检查转换后的文件。普通 PPTX 并非支持宏的格式，若需保留 VBA，请使用相应的支持宏的工作流。同时确认所需字体和外部资源在打开或渲染转换后演示文稿的环境中可用。

对于重要文档，建议以编程方式重新打开生成的 PPTX，检查关键的幻灯片数量和内容，然后在目标查看器中比较其外观和放映行为。不要将一次成功的 [Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save) 调用视为所有遗留功能都已在 PPTX 中得到精确映射的证明。

## **何时使用 PPTX**

当演示文稿需要在当前版本的 PowerPoint 中编辑、与使用 Open XML 包的系统进行交换，或需要以比传统二进制 PPT 更易检查和恢复的格式存储时，请使用 PPTX。在转换后的演示文稿通过保真度检查之前，请保留原始 PPT 作为归档或回滚副本。

如果需要 PDF、HTML、图像、XPS 或其他输出类型，请参考 [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) 中的特定格式指南，而不要假设所有目标格式都能保留可编辑的 PowerPoint 功能。

## **在线转换器**

对于偶尔的文件或快速比较，可使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx)。若需可重复的转换、批处理或应用层错误处理，请使用 PHP API。

## **相关文章**

- [PPT 与 PPTX](/php-java/ppt-vs-pptx/)
- [在 PHP 中保存演示文稿](/php-java/save-presentation/)
- [支持的文件格式](/php-java/supported-file-formats/)
- [在 PHP 中打开演示文稿](/php-java/open-presentation/)

## **常见问题**

**我可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX 吗？**

可以。Aspose.Slides for PHP via Java 能在不需要 Microsoft PowerPoint 的情况下加载和保存演示文稿文件。

**PPT 转换为 PPTX 是否能完整保留所有内容？**

它会保留常见的演示文稿内容，但并不能保证对每个遗留或不受支持的特性都能完全一致。若生成的文件包含宏、OLE 或 ActiveX 对象、媒体、特殊动画或罕见字体，请对其进行检查。

**我可以转换受密码保护的 PPT 文件吗？**

可以，只要在加载文件时提供正确的密码。缺少或密码错误会导致加载操作失败。

**转换后我应该删除 PPT 文件吗？**

在确认 PPTX 在您关心的查看器和工作流中通过验证之前，请保留原始文件。这可以在遗留特性转换后出现差异时提供回滚副本。