---
title: 在 PHP 中编辑 PDF 文档
linktitle: 编辑 PDF
type: docs
weight: 65
url: /zh/php-java/edit-pdf/
keywords:
- 编辑 PDF
- 替换 PDF 文本
- PDF 转 PPTX
- PPTX 转 PDF
- PHP
- Aspose.Slides
description: "在 PHP 中通过将 PDF 文档导入 Aspose.Slides、替换文本并将修改后的演示文稿保存回 PDF 来编辑 PDF 文档。"
---
## **概述**

Aspose.Slides for PHP via Java 允许您通过将 PDF 页面导入为幻灯片、修改演示文稿，然后再导出回 PDF 来编辑 PDF 内容。本文展示了一个简单的文本替换示例。演示文稿保持在内存中，因此保存中间的 PPTX 文件是可选的。

## **在 PDF 中替换文本**

使用[SlideCollection::addFromPdf](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/#addFromPdf)导入页面，使用[Presentation::replaceText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#replaceText)更新文本，使用[Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save)导出结果。

以下示例假设 `input.pdf` 在导入后包含可编辑的单词 “Draft”。它将该单词替换为 “Final”，并写入 `edited.pdf`。在导入前清除初始幻灯片可防止输出中出现额外的空白页。搜索匹配完整单词且区分大小写；`null` 表示不需要结果回调。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

有关更多选项，请参阅[Search and Replace Text](/slides/zh/php-java/search-and-replace-text/)和[Convert PowerPoint to PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/)。

{{% alert color="info" title="Note" %}}
文本替换适用于导入的文本，而不适用于扫描图像中的文本。转换可能影响布局和格式，因此请检查输出，特别是当替换文本比原文本更长时。
{{% /alert %}}

## **常见问题**

**是否需要在导出 PDF 之前保存 PPTX 文件？**

不需要。您可以在内存中编辑并导出同一演示文稿。仅在希望继续在 PowerPoint 中编辑时才保存 PPTX 副本；请参阅[Save Presentations](/slides/zh/php-java/save-presentation/)。

**为什么有些文本仍未改变？**

示例匹配的是完整单词 “Draft”，且大小写完全一致。以图像形式导入的文本或跨多个文本框的文本可能不会匹配搜索。请检查导入的内容并针对您的文档调整搜索条件。