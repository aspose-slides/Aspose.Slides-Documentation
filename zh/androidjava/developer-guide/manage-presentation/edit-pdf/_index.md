---
title: 在 Android 上编辑 PDF 文档
linktitle: 编辑 PDF
type: docs
weight: 65
url: /zh/androidjava/edit-pdf/
keywords:
- 编辑 PDF
- 替换 PDF 文本
- PDF 转 PPTX
- PPTX 转 PDF
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Java，通过将 PDF 导入 Aspose.Slides、替换文本并将修改后的演示文稿保存回 PDF，来编辑 PDF 文档。"
---
## **概述**

Aspose.Slides for Android via Java 允许您通过将 PDF 页面导入为幻灯片、修改演示文稿并将其导出回 PDF 来编辑 PDF 内容。本教程展示了一个简单的文本替换。演示文稿保持在内存中，因此保存中间的 PPTX 文件是可选的。

## **在 PDF 中替换文本**

使用 [addFromPdf](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) 导入页面，使用 [replaceText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 更新文本，使用 [save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 导出结果。

以下示例假设 `input.pdf` 在导入后包含可编辑的单词 “Draft”。它将该单词替换为 “Final”，并写入 `edited.pdf`。在导入前清除初始幻灯片可避免输出中出现额外的空白页。搜索匹配大小写相同的完整单词；`null` 表示不需要结果回调。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

欲了解更多选项，请参阅 [搜索和替换文本](/slides/zh/androidjava/search-and-replace-text/) 和 [将 PowerPoint 转换为 PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/)。

{{% alert color="info" title="Note" %}}
文本替换仅适用于导入的文本，不适用于扫描图像中的文本。转换可能会影响布局和格式，因此请检查输出，尤其是在替换文本比原始文本更长的情况下。
{{% /alert %}}

## **常见问题**

**在导出 PDF 之前需要保存 PPTX 文件吗？**

不需要。您可以在内存中编辑并导出同一演示文稿。仅在您还希望在 PowerPoint 中继续编辑时才保存 PPTX 副本；请参阅 [保存演示文稿](/slides/zh/androidjava/save-presentation/)。

**为什么某些文本可能保持不变？**

示例使用完全匹配大小写的完整单词 “Draft”。以图像形式导入的文本或跨多个文本框分割的文本未必能匹配搜索。请检查导入的内容并根据文档调整搜索。